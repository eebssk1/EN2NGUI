namespace EN2NGui
{
    partial class GUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ENone = new System.Windows.Forms.RadioButton();
            this.ETwofish = new System.Windows.Forms.RadioButton();
            this.EAes = new System.Windows.Forms.RadioButton();
            this.EChacha20 = new System.Windows.Forms.RadioButton();
            this.ESpeck = new System.Windows.Forms.RadioButton();
            this.LbServer = new System.Windows.Forms.Label();
            this.TxtServer = new System.Windows.Forms.TextBox();
            this.LblComm = new System.Windows.Forms.Label();
            this.TxtComm = new System.Windows.Forms.TextBox();
            this.LblPort = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CNone = new System.Windows.Forms.RadioButton();
            this.CLzo = new System.Windows.Forms.RadioButton();
            this.Czstd = new System.Windows.Forms.RadioButton();
            this.LblCompress = new System.Windows.Forms.Label();
            this.LblEncrypt = new System.Windows.Forms.Label();
            this.LblMtu = new System.Windows.Forms.Label();
            this.TxtMTU = new System.Windows.Forms.TextBox();
            this.LblMDis = new System.Windows.Forms.Label();
            this.CboxMD = new System.Windows.Forms.CheckBox();
            this.Lblbroa = new System.Windows.Forms.Label();
            this.CboxBroa = new System.Windows.Forms.CheckBox();
            this.LblHeaderEn = new System.Windows.Forms.Label();
            this.CboxHeaderEn = new System.Windows.Forms.CheckBox();
            this.LblNickname = new System.Windows.Forms.Label();
            this.TxtNickname = new System.Windows.Forms.TextBox();
            this.LblTap = new System.Windows.Forms.Label();
            this.LblFwd = new System.Windows.Forms.Label();
            this.CboxTap = new System.Windows.Forms.ComboBox();
            this.CboxRt = new System.Windows.Forms.CheckBox();
            this.LblMt = new System.Windows.Forms.Label();
            this.CboxMt = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblUD = new System.Windows.Forms.Label();
            this.BtnPer = new System.Windows.Forms.Button();
            this.BtnInsTAP = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblTAPname = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.LblIP = new System.Windows.Forms.Label();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 271);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.LbServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblComm, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtComm, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblPort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblPassword, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtPassword, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblCompress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblEncrypt, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblMtu, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtMTU, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LblMDis, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.CboxMD, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Lblbroa, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CboxBroa, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblHeaderEn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.CboxHeaderEn, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblNickname, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.TxtNickname, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.LblTap, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.LblFwd, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.CboxTap, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.CboxRt, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.LblMt, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.CboxMt, 3, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 271);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.ENone);
            this.flowLayoutPanel2.Controls.Add(this.ETwofish);
            this.flowLayoutPanel2.Controls.Add(this.EAes);
            this.flowLayoutPanel2.Controls.Add(this.EChacha20);
            this.flowLayoutPanel2.Controls.Add(this.ESpeck);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(369, 57);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(77, 110);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // ENone
            // 
            this.ENone.AutoSize = true;
            this.ENone.Location = new System.Drawing.Point(3, 3);
            this.ENone.Name = "ENone";
            this.ENone.Size = new System.Drawing.Size(47, 16);
            this.ENone.TabIndex = 0;
            this.ENone.TabStop = true;
            this.ENone.Text = "None";
            this.ENone.UseVisualStyleBackColor = true;
            // 
            // ETwofish
            // 
            this.ETwofish.AutoSize = true;
            this.ETwofish.Location = new System.Drawing.Point(3, 25);
            this.ETwofish.Name = "ETwofish";
            this.ETwofish.Size = new System.Drawing.Size(71, 16);
            this.ETwofish.TabIndex = 1;
            this.ETwofish.TabStop = true;
            this.ETwofish.Text = "Two Fish";
            this.ETwofish.UseVisualStyleBackColor = true;
            // 
            // EAes
            // 
            this.EAes.AutoSize = true;
            this.EAes.Location = new System.Drawing.Point(3, 47);
            this.EAes.Name = "EAes";
            this.EAes.Size = new System.Drawing.Size(41, 16);
            this.EAes.TabIndex = 2;
            this.EAes.TabStop = true;
            this.EAes.Text = "AES";
            this.EAes.UseVisualStyleBackColor = true;
            // 
            // EChacha20
            // 
            this.EChacha20.AutoSize = true;
            this.EChacha20.Location = new System.Drawing.Point(3, 69);
            this.EChacha20.Name = "EChacha20";
            this.EChacha20.Size = new System.Drawing.Size(71, 16);
            this.EChacha20.TabIndex = 3;
            this.EChacha20.TabStop = true;
            this.EChacha20.Text = "Chacha20";
            this.EChacha20.UseVisualStyleBackColor = true;
            // 
            // ESpeck
            // 
            this.ESpeck.AutoSize = true;
            this.ESpeck.Location = new System.Drawing.Point(3, 91);
            this.ESpeck.Name = "ESpeck";
            this.ESpeck.Size = new System.Drawing.Size(53, 16);
            this.ESpeck.TabIndex = 4;
            this.ESpeck.TabStop = true;
            this.ESpeck.Text = "SPECK";
            this.ESpeck.UseVisualStyleBackColor = true;
            // 
            // LbServer
            // 
            this.LbServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LbServer.AutoSize = true;
            this.LbServer.Location = new System.Drawing.Point(33, 7);
            this.LbServer.Name = "LbServer";
            this.LbServer.Size = new System.Drawing.Size(41, 12);
            this.LbServer.TabIndex = 0;
            this.LbServer.Text = "Server";
            // 
            // TxtServer
            // 
            this.TxtServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtServer.Location = new System.Drawing.Point(110, 3);
            this.TxtServer.Name = "TxtServer";
            this.TxtServer.Size = new System.Drawing.Size(123, 21);
            this.TxtServer.TabIndex = 1;
            // 
            // LblComm
            // 
            this.LblComm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblComm.AutoSize = true;
            this.LblComm.Location = new System.Drawing.Point(260, 7);
            this.LblComm.Name = "LblComm";
            this.LblComm.Size = new System.Drawing.Size(59, 12);
            this.LblComm.TabIndex = 2;
            this.LblComm.Text = "Community";
            // 
            // TxtComm
            // 
            this.TxtComm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtComm.Location = new System.Drawing.Point(346, 3);
            this.TxtComm.Name = "TxtComm";
            this.TxtComm.Size = new System.Drawing.Size(123, 21);
            this.TxtComm.TabIndex = 3;
            // 
            // LblPort
            // 
            this.LblPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(39, 34);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(29, 12);
            this.LblPort.TabIndex = 4;
            this.LblPort.Text = "Port";
            // 
            // TxtPort
            // 
            this.TxtPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtPort.Location = new System.Drawing.Point(121, 30);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(100, 21);
            this.TxtPort.TabIndex = 5;
            this.TxtPort.TextChanged += new System.EventHandler(this.TxtPort_TextChanged);
            // 
            // LblPassword
            // 
            this.LblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblPassword.AutoSize = true;
            this.LblPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblPassword.Location = new System.Drawing.Point(263, 34);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 12);
            this.LblPassword.TabIndex = 6;
            this.LblPassword.Text = "Password";
            this.LblPassword.Click += new System.EventHandler(this.LblPassword_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Location = new System.Drawing.Point(346, 30);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(123, 21);
            this.TxtPassword.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.CNone);
            this.flowLayoutPanel1.Controls.Add(this.CLzo);
            this.flowLayoutPanel1.Controls.Add(this.Czstd);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(115, 90);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(112, 44);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // CNone
            // 
            this.CNone.AutoSize = true;
            this.CNone.Location = new System.Drawing.Point(3, 3);
            this.CNone.Name = "CNone";
            this.CNone.Size = new System.Drawing.Size(47, 16);
            this.CNone.TabIndex = 0;
            this.CNone.TabStop = true;
            this.CNone.Text = "None";
            this.CNone.UseVisualStyleBackColor = true;
            // 
            // CLzo
            // 
            this.CLzo.AutoSize = true;
            this.CLzo.Location = new System.Drawing.Point(56, 3);
            this.CLzo.Name = "CLzo";
            this.CLzo.Size = new System.Drawing.Size(53, 16);
            this.CLzo.TabIndex = 1;
            this.CLzo.TabStop = true;
            this.CLzo.Text = "LZO1x";
            this.CLzo.UseVisualStyleBackColor = true;
            // 
            // Czstd
            // 
            this.Czstd.AutoSize = true;
            this.Czstd.Location = new System.Drawing.Point(3, 25);
            this.Czstd.Name = "Czstd";
            this.Czstd.Size = new System.Drawing.Size(47, 16);
            this.Czstd.TabIndex = 2;
            this.Czstd.TabStop = true;
            this.Czstd.Text = "Zstd";
            this.Czstd.UseVisualStyleBackColor = true;
            // 
            // LblCompress
            // 
            this.LblCompress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblCompress.AutoSize = true;
            this.LblCompress.Location = new System.Drawing.Point(27, 106);
            this.LblCompress.Name = "LblCompress";
            this.LblCompress.Size = new System.Drawing.Size(53, 12);
            this.LblCompress.TabIndex = 9;
            this.LblCompress.Text = "Compress";
            // 
            // LblEncrypt
            // 
            this.LblEncrypt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblEncrypt.AutoSize = true;
            this.LblEncrypt.Location = new System.Drawing.Point(257, 106);
            this.LblEncrypt.Name = "LblEncrypt";
            this.LblEncrypt.Size = new System.Drawing.Size(65, 12);
            this.LblEncrypt.TabIndex = 10;
            this.LblEncrypt.Text = "Encryption";
            // 
            // LblMtu
            // 
            this.LblMtu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMtu.AutoSize = true;
            this.LblMtu.Location = new System.Drawing.Point(42, 177);
            this.LblMtu.Name = "LblMtu";
            this.LblMtu.Size = new System.Drawing.Size(23, 12);
            this.LblMtu.TabIndex = 12;
            this.LblMtu.Text = "MTU";
            // 
            // TxtMTU
            // 
            this.TxtMTU.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtMTU.Location = new System.Drawing.Point(121, 173);
            this.TxtMTU.Name = "TxtMTU";
            this.TxtMTU.Size = new System.Drawing.Size(100, 21);
            this.TxtMTU.TabIndex = 13;
            this.TxtMTU.TextChanged += new System.EventHandler(this.TxtMTU_TextChanged);
            // 
            // LblMDis
            // 
            this.LblMDis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMDis.AutoSize = true;
            this.LblMDis.Location = new System.Drawing.Point(248, 177);
            this.LblMDis.Name = "LblMDis";
            this.LblMDis.Size = new System.Drawing.Size(83, 12);
            this.LblMDis.TabIndex = 14;
            this.LblMDis.Text = "MTU Discovery";
            // 
            // CboxMD
            // 
            this.CboxMD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CboxMD.AutoSize = true;
            this.CboxMD.Location = new System.Drawing.Point(377, 175);
            this.CboxMD.Name = "CboxMD";
            this.CboxMD.Size = new System.Drawing.Size(60, 16);
            this.CboxMD.TabIndex = 15;
            this.CboxMD.Text = "Enable";
            this.CboxMD.UseVisualStyleBackColor = true;
            // 
            // Lblbroa
            // 
            this.Lblbroa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lblbroa.AutoSize = true;
            this.Lblbroa.Location = new System.Drawing.Point(3, 202);
            this.Lblbroa.Name = "Lblbroa";
            this.Lblbroa.Size = new System.Drawing.Size(101, 12);
            this.Lblbroa.TabIndex = 16;
            this.Lblbroa.Text = "Accept Broadcast";
            // 
            // CboxBroa
            // 
            this.CboxBroa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CboxBroa.AutoSize = true;
            this.CboxBroa.Location = new System.Drawing.Point(141, 200);
            this.CboxBroa.Name = "CboxBroa";
            this.CboxBroa.Size = new System.Drawing.Size(60, 16);
            this.CboxBroa.TabIndex = 17;
            this.CboxBroa.Text = "Enable";
            this.CboxBroa.UseVisualStyleBackColor = true;
            // 
            // LblHeaderEn
            // 
            this.LblHeaderEn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblHeaderEn.AutoSize = true;
            this.LblHeaderEn.Location = new System.Drawing.Point(239, 202);
            this.LblHeaderEn.Name = "LblHeaderEn";
            this.LblHeaderEn.Size = new System.Drawing.Size(101, 12);
            this.LblHeaderEn.TabIndex = 18;
            this.LblHeaderEn.Text = "Header Encrytion";
            // 
            // CboxHeaderEn
            // 
            this.CboxHeaderEn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CboxHeaderEn.AutoSize = true;
            this.CboxHeaderEn.Location = new System.Drawing.Point(377, 200);
            this.CboxHeaderEn.Name = "CboxHeaderEn";
            this.CboxHeaderEn.Size = new System.Drawing.Size(60, 16);
            this.CboxHeaderEn.TabIndex = 19;
            this.CboxHeaderEn.Text = "Enable";
            this.CboxHeaderEn.UseVisualStyleBackColor = true;
            // 
            // LblNickname
            // 
            this.LblNickname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblNickname.AutoSize = true;
            this.LblNickname.Location = new System.Drawing.Point(27, 226);
            this.LblNickname.Name = "LblNickname";
            this.LblNickname.Size = new System.Drawing.Size(53, 12);
            this.LblNickname.TabIndex = 20;
            this.LblNickname.Text = "Nickname";
            // 
            // TxtNickname
            // 
            this.TxtNickname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNickname.Location = new System.Drawing.Point(110, 222);
            this.TxtNickname.Name = "TxtNickname";
            this.TxtNickname.Size = new System.Drawing.Size(123, 21);
            this.TxtNickname.TabIndex = 21;
            // 
            // LblTap
            // 
            this.LblTap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTap.AutoSize = true;
            this.LblTap.Location = new System.Drawing.Point(248, 226);
            this.LblTap.Name = "LblTap";
            this.LblTap.Size = new System.Drawing.Size(83, 12);
            this.LblTap.TabIndex = 22;
            this.LblTap.Text = "TAP Interface";
            // 
            // LblFwd
            // 
            this.LblFwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblFwd.AutoSize = true;
            this.LblFwd.Location = new System.Drawing.Point(12, 252);
            this.LblFwd.Name = "LblFwd";
            this.LblFwd.Size = new System.Drawing.Size(83, 12);
            this.LblFwd.TabIndex = 24;
            this.LblFwd.Text = "Allow Routing";
            // 
            // CboxTap
            // 
            this.CboxTap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CboxTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxTap.Font = new System.Drawing.Font("等线", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboxTap.FormattingEnabled = true;
            this.CboxTap.Location = new System.Drawing.Point(346, 222);
            this.CboxTap.Name = "CboxTap";
            this.CboxTap.Size = new System.Drawing.Size(123, 18);
            this.CboxTap.Sorted = true;
            this.CboxTap.TabIndex = 26;
            this.CboxTap.SelectedValueChanged += new System.EventHandler(this.CboxTap_SelectedValueChanged);
            // 
            // CboxRt
            // 
            this.CboxRt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CboxRt.AutoSize = true;
            this.CboxRt.Location = new System.Drawing.Point(141, 250);
            this.CboxRt.Name = "CboxRt";
            this.CboxRt.Size = new System.Drawing.Size(60, 16);
            this.CboxRt.TabIndex = 25;
            this.CboxRt.Text = "Enable";
            this.CboxRt.UseVisualStyleBackColor = true;
            // 
            // LblMt
            // 
            this.LblMt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMt.AutoSize = true;
            this.LblMt.Location = new System.Drawing.Point(257, 252);
            this.LblMt.Name = "LblMt";
            this.LblMt.Size = new System.Drawing.Size(65, 12);
            this.LblMt.TabIndex = 27;
            this.LblMt.Text = "Set Metric";
            // 
            // CboxMt
            // 
            this.CboxMt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CboxMt.AutoSize = true;
            this.CboxMt.Location = new System.Drawing.Point(377, 250);
            this.CboxMt.Name = "CboxMt";
            this.CboxMt.Size = new System.Drawing.Size(60, 16);
            this.CboxMt.TabIndex = 28;
            this.CboxMt.Text = "Enable";
            this.CboxMt.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAbout);
            this.panel2.Controls.Add(this.LblUD);
            this.panel2.Controls.Add(this.BtnPer);
            this.panel2.Controls.Add(this.BtnInsTAP);
            this.panel2.Controls.Add(this.BtnStart);
            this.panel2.Controls.Add(this.LblTAPname);
            this.panel2.Controls.Add(this.txtLog);
            this.panel2.Controls.Add(this.LblIP);
            this.panel2.Location = new System.Drawing.Point(6, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 373);
            this.panel2.TabIndex = 1;
            // 
            // LblUD
            // 
            this.LblUD.AutoSize = true;
            this.LblUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUD.Location = new System.Drawing.Point(356, 2);
            this.LblUD.Name = "LblUD";
            this.LblUD.Size = new System.Drawing.Size(42, 12);
            this.LblUD.TabIndex = 32;
            this.LblUD.Text = "UpDown";
            // 
            // BtnPer
            // 
            this.BtnPer.AutoSize = true;
            this.BtnPer.Location = new System.Drawing.Point(141, 324);
            this.BtnPer.Name = "BtnPer";
            this.BtnPer.Size = new System.Drawing.Size(80, 25);
            this.BtnPer.TabIndex = 31;
            this.BtnPer.Text = "Show Peers";
            this.BtnPer.UseVisualStyleBackColor = true;
            this.BtnPer.Click += new System.EventHandler(this.BtnPer_Click);
            // 
            // BtnInsTAP
            // 
            this.BtnInsTAP.AutoSize = true;
            this.BtnInsTAP.Location = new System.Drawing.Point(3, 347);
            this.BtnInsTAP.Margin = new System.Windows.Forms.Padding(1);
            this.BtnInsTAP.Name = "BtnInsTAP";
            this.BtnInsTAP.Size = new System.Drawing.Size(81, 25);
            this.BtnInsTAP.TabIndex = 30;
            this.BtnInsTAP.Text = "Install TAP";
            this.BtnInsTAP.UseVisualStyleBackColor = true;
            this.BtnInsTAP.Click += new System.EventHandler(this.BtnInsTAP_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnStart.Location = new System.Drawing.Point(377, 324);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(80, 40);
            this.BtnStart.TabIndex = 29;
            this.BtnStart.Text = "Launch!";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblTAPname
            // 
            this.LblTAPname.AutoSize = true;
            this.LblTAPname.Font = new System.Drawing.Font("等线", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTAPname.Location = new System.Drawing.Point(153, 4);
            this.LblTAPname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTAPname.Name = "LblTAPname";
            this.LblTAPname.Size = new System.Drawing.Size(22, 10);
            this.LblTAPname.TabIndex = 28;
            this.LblTAPname.Text = "TAP";
            this.LblTAPname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLog
            // 
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(6, 43);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(459, 275);
            this.txtLog.TabIndex = 1;
            // 
            // LblIP
            // 
            this.LblIP.AutoSize = true;
            this.LblIP.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIP.Location = new System.Drawing.Point(6, 14);
            this.LblIP.Name = "LblIP";
            this.LblIP.Size = new System.Drawing.Size(23, 16);
            this.LblIP.TabIndex = 0;
            this.LblIP.Text = "IP:";
            // 
            // BtnAbout
            // 
            this.BtnAbout.Location = new System.Drawing.Point(265, 324);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(75, 23);
            this.BtnAbout.TabIndex = 33;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EN2NGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LbServer;
        private System.Windows.Forms.TextBox TxtServer;
        private System.Windows.Forms.Label LblComm;
        private System.Windows.Forms.TextBox TxtComm;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton CNone;
        private System.Windows.Forms.RadioButton CLzo;
        private System.Windows.Forms.RadioButton Czstd;
        private System.Windows.Forms.Label LblCompress;
        private System.Windows.Forms.Label LblEncrypt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton ENone;
        private System.Windows.Forms.RadioButton ETwofish;
        private System.Windows.Forms.RadioButton EAes;
        private System.Windows.Forms.RadioButton EChacha20;
        private System.Windows.Forms.RadioButton ESpeck;
        private System.Windows.Forms.Label LblMtu;
        private System.Windows.Forms.TextBox TxtMTU;
        private System.Windows.Forms.Label LblMDis;
        private System.Windows.Forms.CheckBox CboxMD;
        private System.Windows.Forms.Label Lblbroa;
        private System.Windows.Forms.CheckBox CboxBroa;
        private System.Windows.Forms.Label LblHeaderEn;
        private System.Windows.Forms.CheckBox CboxHeaderEn;
        private System.Windows.Forms.Label LblNickname;
        private System.Windows.Forms.TextBox TxtNickname;
        private System.Windows.Forms.Label LblTap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label LblFwd;
        private System.Windows.Forms.CheckBox CboxRt;
        private System.Windows.Forms.ComboBox CboxTap;
        private System.Windows.Forms.Label LblTAPname;
        private System.Windows.Forms.Label LblMt;
        private System.Windows.Forms.CheckBox CboxMt;
        internal System.Windows.Forms.Button BtnStart;
        internal System.Windows.Forms.Label LblIP;
        internal System.Windows.Forms.Button BtnInsTAP;
        private System.Windows.Forms.Button BtnPer;
        internal System.Windows.Forms.Label LblUD;
        private System.Windows.Forms.Button BtnAbout;
    }
}

