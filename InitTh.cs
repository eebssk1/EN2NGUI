using Nucs.JsonSettings;
using PeNet;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace EN2NGui
{
    internal class InitTh
    {
        private static InitTh self;
        private readonly Spla i;
        private bool error = false;
        private string FError = "NaN";

        private InitTh(Spla i)
        {
            this.i = i;
            self = this;
        }

        internal static InitTh getInstance(Spla i)
        {
            if (self != null) return self;
            self = new InitTh(i);
            return self;
        }

        private void handleError(StringRes.StringT T)
        {
            error = true;
            i.UpdateLabel(StringRes.GetString(T));
            i.UpdateButton(true);
            MessageBox.Show(StringRes.GetString(T), "/(ㄒoㄒ)/~~", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (FError == "NaN") FError = StringRes.GetString(T);
        }

        internal void Do()
        {
            Thread.Sleep(250);
            i.UpdateLabel(StringRes.GetString(StringRes.StringT.ChkAdmin));
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MiscData.isAdmin = false;
                handleError(StringRes.StringT.NoAdmin);
            }
            Thread.Sleep(60);
            NetworkInterface[] taps = NetworkInterface.GetAllNetworkInterfaces();
            var TAPFound = false;
            var TAPAConn = false;
            foreach (NetworkInterface intf in taps)
            {
                if (intf.Description.Contains("TAP"))
                {
                    TAPFound = true;
                    if (intf.OperationalStatus == OperationalStatus.Up)
                    {
                        TAPAConn = true;
                    }
                    MiscData.TAPs.Add(intf.Id, intf.Name + "_" + intf.Description + "_" + intf.Id);
                }
            }
            if (TAPAConn)
            {
                MessageBox.Show(StringRes.GetString(StringRes.StringT.TAPCfl), "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!TAPFound)
            {
                MessageBox.Show(StringRes.GetString(StringRes.StringT.NoTAP), "!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MiscData.haveTAP = false;
            }
            Thread.Sleep(60);
            i.UpdateLabel(StringRes.GetString(StringRes.StringT.FileCheck));
        fc:
            if (!File.Exists(StringRes.exe))
            {
                DialogResult res = MessageBox.Show(StringRes.GetString(StringRes.StringT.ExtExe), "*_*", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    FileStream f = null;
                    try { f = new FileStream(StringRes.exe, FileMode.Create); } catch (Exception) { };
                    if (f == null) goto fc;
                    f.Write(Properties.Resources.n2n_edge, 0, Properties.Resources.n2n_edge.Length);
                    f.Close();
                    goto fc;
                }
                else
                {
                    handleError(StringRes.StringT.NoFile);
                    MiscData.haveExe = false;
                }
            }
            if (MiscData.haveExe)
            {
                MD5 md5 = MD5.Create();
                var ehash = md5.ComputeHash(Properties.Resources.n2n_edge);
                MiscData.inbuiltN2NHash = string.Concat(ehash.Select(x => x.ToString("X2")));
                var fhash = md5.ComputeHash(File.ReadAllBytes(StringRes.exe));
                if (!ehash.SequenceEqual(fhash))
                {
                    MiscData.isN2NmatchHash = false;
                }
            }
            Thread.Sleep(60);
            PeFile PE = null;
            int isPe;
            try
            {
                isPe = PeFile.TryParse(StringRes.exe, out PE) ? 1 : 0;
            }
            catch (Exception) { isPe = 2; };
            if (isPe == 1)
            {
                var eArch = PE.ImageNtHeaders.FileHeader.Machine;
                var mArch = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture;
                if (!((eArch == PeNet.Header.Pe.MachineType.Amd64 &&
                    (mArch == System.Runtime.InteropServices.Architecture.X64 || mArch == System.Runtime.InteropServices.Architecture.X86)) ||
                    (eArch == PeNet.Header.Pe.MachineType.I386 && mArch == System.Runtime.InteropServices.Architecture.X86)))
                {
                    handleError(StringRes.StringT.WrongArch);
                }
            }
            else if (isPe != 2)
            {
                handleError(StringRes.StringT.FileDestr);
            }
            i.UpdateLabel(StringRes.GetString(StringRes.StringT.LoadConf));
            Thread.Sleep(60);
            i.tcursor = Cursors.Default;
            if (!File.Exists(StringRes.conf))
            {
                MessageBox.Show(StringRes.GetString(StringRes.StringT.NoConf), "*_*", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MiscData.settings = JsonSettings.Construct<Settings>();
                MiscData.settings.Save();
            }
            else
            {
                MiscData.settings = JsonSettings.Load<Settings>();
            }
            if (!error)
            {

                i.Close();
            }
            else
            {
                i.UpdateLabel(StringRes.GetString(StringRes.StringT.Error) + '\n' + StringRes.GetString(StringRes.StringT.FirsErr) + FError);
                i.UpdateCButton(true);
            };
            self = null;

        }
    }
}