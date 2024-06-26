using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFirewallHelper;
using WindowsFirewallHelper.Addresses;
using WindowsFirewallHelper.FirewallRules;
using static EN2NGui.NativeM;
using static System.Net.IPNetwork2;

namespace EN2NGui
{
    internal class N2NHandler
    {
        internal static N2NHandler Instance;
        internal StringBuilder param = new StringBuilder();
        private readonly GUI i;
        internal Process process;
        internal int PID;
        private int timeout;
        int pIP = 0;
        internal int trycount = 0;
        private bool needworkdelay = false;
        private Thread workThread;
        private N2NHandler(GUI i)
        {
            Instance = this;
            this.i = i;
            workThread = new Thread(WorkTick);
            workThread.IsBackground = true;
            workThread.Priority = ThreadPriority.BelowNormal;
            workThread.Start();
        }
        internal static N2NHandler getInstance(GUI i)
        {
            if (Instance != null) return Instance;
            Instance = new N2NHandler(i);
            return Instance;
        }

        private void addtxt(object sender, DataReceivedEventArgs e)
        {
            if (!i.closed)
                i.UpdateTxtBox(e.Data);
        }

        private void handleExit(object sender, EventArgs e)
        {
            process.Exited -= handleExit;
            int ret;
            try
            {
                ret = -1;
                if (process != null)
                    ret = process.ExitCode;
            }
            catch (Exception)
            {
                ret = -1;
            }
            if (!i.needStop)
            {
                MessageBox.Show(StringRes.GetString(StringRes.StringT.WhyExit) + '\n' + "Ret " + ret, "!X!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            i.started = false;
            i.needStop = false;
            process?.Close();
            process = null;
            i.UpdateButtonSt(i.BtnStart, StringRes.GetString(StringRes.StringT.Launch));
            i.UpdateButtonEn(i.BtnStart, true);
        }

        internal void Stop()
        {
            PeerForm.instance.connected = false;
            if (timeout != 0) return;
            FreeConsole();
            if (AttachConsole((uint)PID))
            {
                SetConsoleCtrlHandler(null, true);
                try
                {
                    if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0)) return;
                    while (process != null && !process.HasExited)
                    {
                        if (!Thread.Yield())
                            Thread.Sleep(100);
                        else
                        {
                            Thread.Sleep(80);
                        }
                        timeout += 1;
                        if (timeout >= 185)
                        {
                            timeout = 0;
                            i.UpdateTxtBox("Too long... Request exit again...");
                            GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0);
                        }
                    }
                }
                finally
                {
                    SetConsoleCtrlHandler(null, false);
                    FreeConsole();
                }
            }
            timeout = 0;
        }
        internal void Do()
        {
            if (process != null) return;
            param.Clear();
            param.Append("-c " + MiscData.settings.Community + " ");
            param.Append("-l " + MiscData.settings.Server + ':' + MiscData.settings.Port + " ");
            if (MiscData.settings.MTUDiscovery) param.Append("-D ");
            if (!string.IsNullOrEmpty(MiscData.settings.Password)) param.Append("-k " + MiscData.settings.Password + " ");
            param.Append("-A" + (((int)MiscData.settings.UseEncryption) + 1) + " ");
            if (MiscData.settings.UseCompression != ConfigEnum.Compression.None)
                param.Append("-z" + ((int)MiscData.settings.UseCompression) + " ");
            if (MiscData.settings.EncryptHeader) param.Append("-H ");
            param.Append("-M " + MiscData.settings.MTU + " ");
            if (MiscData.settings.AllowRouting) param.Append("-r ");
            if (MiscData.settings.AllowBroadcast) param.Append("-E ");
            if (MiscData.settings.SetMetric) param.Append("-x 2 ");
            var nick = Environment.MachineName;
            if (!string.IsNullOrEmpty(MiscData.settings.NickName))
                nick = MiscData.settings.NickName;
            param.Append("-I " + '"' + nick + '"' + " ");
            param.Append("-d " + MiscData.settings.TAPInterface + " ");
            i.UpdateTxtBox("Arg: " + param);
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                Arguments = param.ToString(),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                FileName = StringRes.exe
            };
            process = null;
            process = new Process
            {
                StartInfo = pi,
                EnableRaisingEvents = true
            };
            process.OutputDataReceived += addtxt;
            process.ErrorDataReceived += addtxt;
            process.Exited += handleExit;
            process.Start();
            PID = process.Id;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            ChildProcessTracker.AddProcess(process);
            needworkdelay = true;
            trycount = 0;
            i.UpdateButtonSt(i.BtnStart, StringRes.GetString(StringRes.StringT.Stop));
            i.UpdateButtonEn(i.BtnStart, true);
        }

        private void WorkTick()
        {
            while (true)
            {
                if (i.needStop || !i.started)
                {
                    if (Thread.Yield())
                    {
                        Thread.Sleep(50);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                    continue;
                };
                if (needworkdelay)
                {
                    needworkdelay = false;
                    if (Thread.Yield())
                    {
                        Thread.Sleep(1250);
                    }
                    else
                    {
                        Thread.Sleep(1500);
                    }
                }
                NetworkInterface Int = null;
                if (i.WindowState != FormWindowState.Minimized)
                {
                    Int = NetworkInterface.GetAllNetworkInterfaces().SingleOrDefault(x => x.Id == MiscData.currentTAP.Id);
                    var d = Int.GetIPStatistics().BytesReceived / 1024;
                    var u = Int.GetIPStatistics().BytesSent / 1024;
                    i.UpdateLabel(i.LblUD, "Up: " + u + Environment.NewLine + "Down: " + d);
                }
                if (MiscData.isAdmin && !(trycount > 50))
                {
                    if (Int == null)
                        Int = NetworkInterface.GetAllNetworkInterfaces().SingleOrDefault(x => x.Id == MiscData.currentTAP.Id);
                    if (Int.GetIPProperties().UnicastAddresses.Count != 0)
                    {
                        UnicastIPAddressInformation ip = Int.GetIPProperties().UnicastAddresses.Where((x) => x.Address.AddressFamily == AddressFamily.InterNetwork).First();
                        if (string.IsNullOrEmpty(ip.Address.ToString()) || ip.Address.ToString().StartsWith("0.0"))
                        {
                            goto end;
                        }
                        string CIDR = Parse(ip.Address.ToString() + '/' + ip.PrefixLength).Network.ToString() + '/' + ip.PrefixLength;
                        if (CIDR.StartsWith("169.254"))
                        {
                            goto end;
                        }
                        if (pIP == ip.Address.ToString().GetHashCode())
                        {
                            trycount++;
                            goto end;
                        }
                        else
                        {
                            pIP = ip.Address.ToString().GetHashCode();
                        }
                        i.UpdateTxtBox("CIDR is " + CIDR);
                        i.UpdateLabel(i.LblIP, "IP: " + ip.Address.ToString());
                        FirewallWASRuleWin7 f = new FirewallWASRuleWin7("ebk-n2n-edge-tap", FirewallAction.Allow, FirewallDirection.Inbound, FirewallProfiles.Private | FirewallProfiles.Public)
                        {
                            EdgeTraversal = true,
                            EdgeTraversalOptions = EdgeTraversalAction.Allow,
                        };
                        f.Protocol = FirewallProtocol.Any;
                        NetworkAddress ipa;
                        if (!NetworkAddress.TryParse(CIDR, out ipa))
                        {
                            goto end;
                        }
                        List<IAddress> IP = new List<IAddress>
                    {
                        ipa
                    };
                        f.RemoteAddresses = IP.ToArray();
                        var rlT = GUI.fW.Rules.Where((x) => x.Name == "ebk-n2n-edge-tap");
                        if (rlT.Count() != 0)
                        {
                            foreach (var r in rlT)
                            {
                                GUI.fW.Rules.Remove(r);
                                i.UpdateTxtBox("Removed system firewall TAP rule");
                            }
                        }
                        GUI.fW.Rules.Add(f);
                    }
                    else
                    {
                        goto end;
                    }

                }
            end:
                if (Thread.Yield())
                {
                    Thread.Sleep(1750);
                }
                else
                {
                    Thread.Sleep(2050);
                }
            }
        }

    }
}
