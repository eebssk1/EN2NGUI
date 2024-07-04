using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFirewallHelper;
using WindowsFirewallHelper.FirewallRules;
using ThreadState = System.Threading.ThreadState;

namespace EN2NGui
{
    public partial class GUI : Form
    {
        internal bool started = false;
        internal bool needStop = false;
        internal static FirewallWAS fW = FirewallWAS.Instance;
        private Thread N2NStart;
        private Thread N2NStop;
        private PeerForm peerForm;
        internal static GUI instance;
        internal bool closed = false;
        private bool hidesens = false;
        public GUI()
        {
            InitializeComponent();
            instance = this;
            if (StringRes.locale == StringRes.LocaleT.ChN)
            {
                LbServer.Text = "服务器地址";
                LblComm.Text = "社群名称";
                LblPort.Text = "端号";
                LblPassword.Text = "密码";
                LblCompress.Text = "压缩";
                LblEncrypt.Text = "加密";
                LblMDis.Text = "MTU探测";
                Lblbroa.Text = "接受多播";
                LblHeaderEn.Text = "加密头部";
                LblNickname.Text = "昵称(必须英文)";
                LblTap.Text = "TAP网卡";
                LblFwd.Text = "启用路由";
                LblMt.Text = "设置跳数";
                BtnStart.Text = "启动！";
                BtnInsTAP.Text = "安装TAP";
                BtnPer.Text = "显示对等方";
                BtnAbout.Text = "关于";
                BtnWd.Text = "打开工作文件夹";
                CboxBroa.Text = StringRes.GetString(StringRes.StringT.Enable);
                CboxHeaderEn.Text = StringRes.GetString(StringRes.StringT.Enable);
                CboxMD.Text = StringRes.GetString(StringRes.StringT.Enable);
                CboxRt.Text = StringRes.GetString(StringRes.StringT.Enable);
                CboxMt.Text = StringRes.GetString(StringRes.StringT.Enable);
            }
        }

        private void GUI_Load(object sender, System.EventArgs e)
        {
            LblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CboxTap.DataSource = MiscData.TAPs.ToList();
            CboxTap.DisplayMember = "Value";
            CboxTap.ValueMember = "Key";
            peerForm = new PeerForm();
            if (!MiscData.haveExe) BtnStart.Enabled = false;
            if (!MiscData.isAdmin) BtnInsTAP.Enabled = false;
            TxtServer.Text = MiscData.settings.Server;
            TxtComm.Text = MiscData.settings.Community;
            TxtPort.Text = MiscData.settings.Port.ToString();
            TxtPassword.Text = MiscData.settings.Password;
            TxtMTU.Text = MiscData.settings.MTU.ToString();
            TxtNickname.Text = MiscData.settings.NickName;
            CboxMD.Checked = MiscData.settings.MTUDiscovery;
            CboxBroa.Checked = MiscData.settings.AllowBroadcast;
            CboxHeaderEn.Checked = MiscData.settings.EncryptHeader;
            CboxRt.Checked = MiscData.settings.AllowRouting;
            CboxMt.Checked = MiscData.settings.SetMetric;
            switch (MiscData.settings.UseCompression)
            {
                case ConfigEnum.Compression.None: CNone.Checked = true; break;
                case ConfigEnum.Compression.Lzo1x: CLzo.Checked = true; break;
                case ConfigEnum.Compression.Zstd: Czstd.Checked = true; break;
            }
            switch (MiscData.settings.UseEncryption)
            {
                case ConfigEnum.Encryption.None: ENone.Checked = true; break;
                case ConfigEnum.Encryption.TwoFish: ETwofish.Checked = true; break;
                case ConfigEnum.Encryption.Aes: EAes.Checked = true; break;
                case ConfigEnum.Encryption.Chacha20: EChacha20.Checked = true; break;
                case ConfigEnum.Encryption.Speck: ESpeck.Checked = true; break;
            }
            if (!string.IsNullOrEmpty(MiscData.settings.TAPInterface))
            {
                if (MiscData.TAPs.ContainsKey(MiscData.settings.TAPInterface))
                {
                    foreach (KeyValuePair<string, string> i in CboxTap.Items)
                    {
                        if (i.Key == MiscData.settings.TAPInterface)
                        {
                            CboxTap.SelectedItem = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (CboxTap.Items.Count != 0)
                {
                    CboxTap.SelectedIndex = 0;
                    foreach (KeyValuePair<string, string> i in CboxTap.Items)
                    {
                        if (i.Value.Contains("EBK") || i.Value.Contains("N2N"))
                        {
                            CboxTap.SelectedItem = i;
                            break;
                        }
                    }
                }
            }
            CboxTap_SelectedValueChanged(sender, e);
            if (!MiscData.isN2NmatchHash)
                UpdateTxtBox(StringRes.GetString(StringRes.StringT.NEnotMatch));
        }

        private void CboxTap_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (CboxTap.SelectedItem != null)
            {
                var s = ((KeyValuePair<string, string>)CboxTap.SelectedItem).Value;
                s = s.Replace("_", Environment.NewLine);
                LblTAPname.Text = s;

            }
        }
        internal void UpdateConf()
        {
            MiscData.settings.Server = TxtServer.Text;
            MiscData.settings.Community = TxtComm.Text;
            MiscData.settings.Port = int.Parse(TxtPort.Text);
            MiscData.settings.Password = TxtPassword.Text;
            MiscData.settings.MTU = int.Parse(TxtMTU.Text);
            MiscData.settings.NickName = TxtNickname.Text;
            MiscData.settings.MTUDiscovery = CboxMD.Checked;
            MiscData.settings.AllowBroadcast = CboxBroa.Checked;
            MiscData.settings.EncryptHeader = CboxHeaderEn.Checked;
            MiscData.settings.AllowRouting = CboxRt.Checked;
            MiscData.settings.SetMetric = CboxMt.Checked;
            if (CNone.Checked) MiscData.settings.UseCompression = ConfigEnum.Compression.None;
            if (CLzo.Checked) MiscData.settings.UseCompression = ConfigEnum.Compression.Lzo1x;
            if (Czstd.Checked) MiscData.settings.UseCompression = ConfigEnum.Compression.Zstd;
            if (ENone.Checked) MiscData.settings.UseEncryption = ConfigEnum.Encryption.None;
            if (ETwofish.Checked) MiscData.settings.UseEncryption = ConfigEnum.Encryption.TwoFish;
            if (EAes.Checked) MiscData.settings.UseEncryption = ConfigEnum.Encryption.Aes;
            if (EChacha20.Checked) MiscData.settings.UseEncryption = ConfigEnum.Encryption.Chacha20;
            if (ESpeck.Checked) MiscData.settings.UseEncryption = ConfigEnum.Encryption.Speck;
            if (CboxTap.InvokeRequired)
            {
                Action ca = () =>
                {
                    if (CboxTap.SelectedItem != null)
                        MiscData.settings.TAPInterface = ((KeyValuePair<string, string>)CboxTap.SelectedItem).Key;
                };
                CboxTap.Invoke(ca);
            }
            else
            {
                if (CboxTap.SelectedItem != null)
                    MiscData.settings.TAPInterface = ((KeyValuePair<string, string>)CboxTap.SelectedItem).Key;
            }
            MiscData.settings.Save();
        }

        private async void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConf();
            if (started && !needStop)
            {
                var result = MessageBox.Show(StringRes.GetString(StringRes.StringT.ConfrExit), ">Exit<", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (started && !needStop && (N2NStop != null && N2NStop.ThreadState != ThreadState.Running))
                    {
                        e.Cancel = true;
                        needStop = true;
                        N2NStop.Start();
                        BtnStart.Enabled = false;
                        await Task.Run(() =>
                        {
                            while (started != false)
                            {
                                if (!Thread.Yield())
                                    Thread.Sleep(150);
                                else
                                    Thread.Sleep(100);
                            }
                            Thread.Sleep(200);
                            closed = true;
                            Action act = () => { Close(); };
                            Invoke(act);
                        });
                    }
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            closed = true;
        }

        private void TxtPort_TextChanged(object sender, System.EventArgs e)
        {
            var value = TxtPort.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^0-9]"))
            {

                TxtPort.Text = MiscData.settings.Port.ToString();
                return;
            }
            var num = int.TryParse(value, out var port);
            if (num && port > 65534)
            {
                TxtPort.Text = "6969";
            }
        }

        private void TxtMTU_TextChanged(object sender, System.EventArgs e)
        {
            var value = TxtMTU.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^0-9]"))
            {

                TxtMTU.Text = MiscData.settings.MTU.ToString();
                return;
            }
            var num = int.TryParse(value, out var mtu);
            if (num && mtu > 1498)
            {
                TxtMTU.Text = "1280";
            }
        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            if (!started)
            {
                if (Uri.CheckHostName(TxtServer.Text) == UriHostNameType.Unknown)
                {
                    MessageBox.Show("Server Name Error !!!", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CboxTap.SelectedItem == null)
                {
                    MessageBox.Show("No TAP Adapter !!!", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TxtComm.Text == "")
                {
                    MessageBox.Show("Community Name Error !!!", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BtnInsTAP.Enabled = false;
                BtnStart.Enabled = false;
                BtnStart.Text = "...";
                UpdateConf();
                MiscData.currentTAP = NetworkInterface.GetAllNetworkInterfaces().Where((x) => x.Id == MiscData.settings.TAPInterface).SingleOrDefault();
                if (MiscData.isAdmin)
                {
                    var rlS = fW.Rules.Where((x) => x.Name == "n2n-edge");
                    if (rlS.Count() != 0)
                    {
                        foreach (var r in rlS)
                        {
                            fW.Rules.Remove(r);
                            UpdateTxtBox("Removed system firewall rule");
                        }
                    }
                    var rlN = fW.Rules.Where((x) => x.Name == "ebk-n2n-edge");
                    if (rlN.Count() != 0)
                    {
                        foreach (var r in rlN)
                        {
                            fW.Rules.Remove(r);
                            UpdateTxtBox("Removed previous firewall rule");
                        }
                    }
                    var fr0 = new FirewallWASRuleWin7("ebk-n2n-edge", FirewallAction.Allow, FirewallDirection.Inbound, FirewallProfiles.Private | FirewallProfiles.Public)
                    {
                        EdgeTraversal = true,
                        EdgeTraversalOptions = EdgeTraversalAction.Allow,
                        ApplicationName = MiscData.PWD + StringRes.exe,
                    };
                    fW.Rules.Add(fr0);
                    fW = (FirewallWAS)fW.Reload();
                }
                else
                {
                    new Thread(() => MessageBox.Show(StringRes.GetString(StringRes.StringT.CantFW), "!X!", MessageBoxButtons.OK, MessageBoxIcon.Warning)).Start();
                }
                txtLog.Enabled = true;
                N2NStart = new Thread(N2NHandler.getInstance(instance).Do);
                N2NStart.Start();
                started = true;
            }
            else
            {
                needStop = true;
                BtnStart.Enabled = false;
                BtnInsTAP.Enabled = true;
                BtnStart.Text = "...";
                N2NStop = new Thread(N2NHandler.getInstance(instance).Stop);
                N2NStop.Start();
            }
        }
        internal void UpdateButtonEn(Button b, bool e)
        {
            if (b.InvokeRequired)
            {
                Action<bool> act = (x) => { b.Enabled = x; };
                b.Invoke(act, e);
            }
            else
            {
                b.Enabled = e;
            }
        }
        internal void UpdateButtonSt(Button b, string s)
        {
            if (b.InvokeRequired)
            {
                Action<string> act = (x) => { b.Text = x; };
                b.Invoke(act, s);
            }
            else
            {
                b.Text = s;
            }
        }

        internal void UpdateLabel(Label label, string s)
        {
            if (label.InvokeRequired)
            {
                Action<string> act = (x) => { label.Text = x; };
                label.Invoke(act, s);
            }
            else
            {
                label.Text = s;
            }
        }
        internal void UpdateTxtBox(string s, bool newline = true)
        {
            if (txtLog.InvokeRequired)
            {

                Action<string> actionDelegate = (x) => { txtLog.AppendText(x + (newline ? Environment.NewLine : null)); };
                txtLog.Invoke(actionDelegate, s);
            }
            else
            {
                txtLog.AppendText(s + (newline ? Environment.NewLine : null));
            }
        }

        private async void BtnInsTAP_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(StringRes.GetString(StringRes.StringT.ITDiscla), "TAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;
            NativeM.DisableCloseButton(this);
            UpdateButtonEn(BtnInsTAP, false);
            var ret = await Task.Run(() =>
            {
                var reg = Encoding.UTF8.GetBytes(Properties.Resources.TrustSig.ToCharArray());
                var zip = Properties.Resources.tapebk1;
                var regpath = Path.GetTempPath() + "ebk-sig.reg";
                var zippath = Path.GetTempPath() + "tapebk01.zip";
                FileStream regf = null;
                FileStream zipf = null;
                try { regf = new FileStream(regpath, FileMode.Create, FileAccess.ReadWrite, FileShare.None); zipf = new FileStream(zippath, FileMode.Create, FileAccess.ReadWrite, FileShare.None); } catch (Exception) { return false; }
                if (regf == null || zipf == null) return false;
                regf.Write(reg, 0, reg.Length);
                zipf.Write(zip, 0, zip.Length);
                regf.Close();
                zipf.Close();
                try { Directory.Delete(Path.GetTempPath() + "TAP"); } catch (Exception) { };
                try { ZipFile.ExtractToDirectory(zippath, Path.GetTempPath()); } catch (Exception) { return false; }
                Process process = Process.Start("reg", "IMPORT " + regpath);
                process.WaitForExit();
                if (process.ExitCode != 0) { process.Close(); return false; }
                process.Close();
                process = Process.Start(Path.GetTempPath() + @"TAP\devcon.exe", "install " + Path.GetTempPath() + @"TAP\OemVista.inf " + @"root\tapebk1");
                process.WaitForExit();
                if (process.ExitCode > 1) { process.Close(); return false; }
                process.Close();
                return true;
            });
            NativeM.EnableCloseButton(this);
            UpdateButtonEn(BtnInsTAP, true);
            if (ret)
            {
                MessageBox.Show(StringRes.GetString(StringRes.StringT.ITDone), "^_^", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("ERROR!!", "^X^", MessageBoxButtons.OK);
            }
        }

        private void BtnPer_Click(object sender, EventArgs e)
        {
            if (!peerForm.Visible)
                peerForm.Show(this);
        }

        private void LblPassword_Click(object sender, EventArgs e)
        {
            if (!hidesens)
            {
                TxtPassword.UseSystemPasswordChar = true;
                TxtComm.UseSystemPasswordChar = true;
                TxtServer.UseSystemPasswordChar = true;
                hidesens = true;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
                TxtComm.UseSystemPasswordChar = false;
                TxtServer.UseSystemPasswordChar = false;
                hidesens = false;
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            string s = "A simple windows c# winforms based frontend of N2N VPN." + Environment.NewLine +
                "Made by EBK21<chkd13303@gmail.com>" + Environment.NewLine +
                "https://github.com/eebssk1/EN2NGUI" + Environment.NewLine + Environment.NewLine +
                "Inbuilt N2N exe md5 hash: " + MiscData.inbuiltN2NHash;
            MessageBox.Show(s, "About");
        }

        private void LblWd_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", MiscData.PWD);
        }
    }
}
