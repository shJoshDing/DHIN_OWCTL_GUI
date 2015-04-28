namespace Test
{
    partial class CurrentSensorConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentSensorConsole));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_FWInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.InternalTab = new System.Windows.Forms.TabPage();
            this.txt_OutputMessage = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_SelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbt_signalPathSeting_Config = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_AIn = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbt_signalPathSeting_Vref = new System.Windows.Forms.RadioButton();
            this.rbt_signalPathSeting_Vout = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbt_withoutCap_Vref = new System.Windows.Forms.RadioButton();
            this.rbt_withCap_Vref = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbt_withoutCap_Vout = new System.Windows.Forms.RadioButton();
            this.rbt_withCap_Vout = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtb_Ext = new System.Windows.Forms.RadioButton();
            this.rbt_5V = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ADCReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_reg83 = new System.Windows.Forms.TextBox();
            this.txt_reg82 = new System.Windows.Forms.TextBox();
            this.txt_reg81 = new System.Windows.Forms.TextBox();
            this.txt_reg80 = new System.Windows.Forms.TextBox();
            this.btn_writeFuseCode = new System.Windows.Forms.Button();
            this.btn_Vout_0A = new System.Windows.Forms.Button();
            this.btn_Vout_5A = new System.Windows.Forms.Button();
            this.btn_Vout_10A = new System.Windows.Forms.Button();
            this.btn_fuse_action_ow = new System.Windows.Forms.Button();
            this.btn_Vout_15A = new System.Windows.Forms.Button();
            this.btn_enterNomalMode = new System.Windows.Forms.Button();
            this.btn_offset = new System.Windows.Forms.Button();
            this.btn_preciseTrim = new System.Windows.Forms.Button();
            this.btn_roughTrim = new System.Windows.Forms.Button();
            this.btn_PowerOff_OWCI_ADC = new System.Windows.Forms.Button();
            this.btn_PowerOn_OWCI_ADC = new System.Windows.Forms.Button();
            this.grb_devInfo_ow = new System.Windows.Forms.GroupBox();
            this.txt_sampleNum = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_sampleRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TargetGain = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_FullScale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numUD_pilotwidth_ow = new System.Windows.Forms.NumericUpDown();
            this.numUD_pulsedurationtime_ow = new System.Windows.Forms.NumericUpDown();
            this.lbl_pilotwidth_ow = new System.Windows.Forms.Label();
            this.lbl_pulsewidth_ow = new System.Windows.Forms.Label();
            this.num_UD_pulsewidth_ow = new System.Windows.Forms.NumericUpDown();
            this.txt_dev_addr_onewire = new System.Windows.Forms.TextBox();
            this.lbl_pulsedurationtime_ow = new System.Windows.Forms.Label();
            this.lbl_devAddr_onewire = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_flash_onewire = new System.Windows.Forms.Button();
            this.btn_GetFW_OneWire = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_sel_cap = new System.Windows.Forms.Button();
            this.btn_sel_vr = new System.Windows.Forms.Button();
            this.btn_ch_ck = new System.Windows.Forms.Button();
            this.btn_nc_1x = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_MarginalRead = new System.Windows.Forms.Button();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_burstRead = new System.Windows.Forms.Button();
            this.CustomerTab = new System.Windows.Forms.TabPage();
            this.cmb_IPxForCalc_Customer = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.autoTrimResultIndicator = new System.Windows.Forms.RichTextBox();
            this.cmb_TargetGain_Customer = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_passOrFailed = new System.Windows.Forms.Label();
            this.btn_AutomaticaTrim = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.InternalTab.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grb_devInfo_ow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.CustomerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Connection,
            this.toolStripStatusLabel_FWInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 478);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(864, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel_Connection
            // 
            this.toolStripStatusLabel_Connection.BackColor = System.Drawing.Color.IndianRed;
            this.toolStripStatusLabel_Connection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripStatusLabel_Connection.Name = "toolStripStatusLabel_Connection";
            this.toolStripStatusLabel_Connection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel_Connection.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel_Connection.Text = "Disconnected";
            // 
            // toolStripStatusLabel_FWInfo
            // 
            this.toolStripStatusLabel_FWInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripStatusLabel_FWInfo.Name = "toolStripStatusLabel_FWInfo";
            this.toolStripStatusLabel_FWInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(864, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printPreviewToolStripButton.Text = "Print Preview";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.InternalTab);
            this.tabControl1.Controls.Add(this.CustomerTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 453);
            this.tabControl1.TabIndex = 5;
            // 
            // InternalTab
            // 
            this.InternalTab.Controls.Add(this.txt_OutputMessage);
            this.InternalTab.Controls.Add(this.groupBox2);
            this.InternalTab.Controls.Add(this.groupBox1);
            this.InternalTab.Controls.Add(this.grb_devInfo_ow);
            this.InternalTab.Controls.Add(this.btn_flash_onewire);
            this.InternalTab.Controls.Add(this.btn_GetFW_OneWire);
            this.InternalTab.Controls.Add(this.groupBox5);
            this.InternalTab.Controls.Add(this.groupBox3);
            this.InternalTab.Location = new System.Drawing.Point(4, 22);
            this.InternalTab.Name = "InternalTab";
            this.InternalTab.Padding = new System.Windows.Forms.Padding(3);
            this.InternalTab.Size = new System.Drawing.Size(856, 427);
            this.InternalTab.TabIndex = 0;
            this.InternalTab.Text = "Enginner Tools";
            this.InternalTab.UseVisualStyleBackColor = true;
            // 
            // txt_OutputMessage
            // 
            this.txt_OutputMessage.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_OutputMessage.ContextMenuStrip = this.contextMenuStrip;
            this.txt_OutputMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_OutputMessage.ForeColor = System.Drawing.Color.White;
            this.txt_OutputMessage.Location = new System.Drawing.Point(8, 280);
            this.txt_OutputMessage.Name = "txt_OutputMessage";
            this.txt_OutputMessage.Size = new System.Drawing.Size(687, 140);
            this.txt_OutputMessage.TabIndex = 62;
            this.txt_OutputMessage.Text = "";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuStrip_SelAll,
            this.contextMenuStrip_Copy,
            this.contextMenuStrip_Paste,
            this.toolStripSeparator3,
            this.contextMenuStrip_Clear});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 98);
            // 
            // contextMenuStrip_SelAll
            // 
            this.contextMenuStrip_SelAll.Name = "contextMenuStrip_SelAll";
            this.contextMenuStrip_SelAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuStrip_SelAll.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_SelAll.Text = "Select &All";
            this.contextMenuStrip_SelAll.Click += new System.EventHandler(this.contextMenuStrip_SelAll_Click);
            // 
            // contextMenuStrip_Copy
            // 
            this.contextMenuStrip_Copy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Copy.Name = "contextMenuStrip_Copy";
            this.contextMenuStrip_Copy.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Copy.Text = "&Copy";
            this.contextMenuStrip_Copy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip_Copy_MouseUp);
            // 
            // contextMenuStrip_Paste
            // 
            this.contextMenuStrip_Paste.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Paste.Name = "contextMenuStrip_Paste";
            this.contextMenuStrip_Paste.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Paste.Text = "&Paste";
            this.contextMenuStrip_Paste.Visible = false;
            this.contextMenuStrip_Paste.Click += new System.EventHandler(this.contextMenuStrip_Paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // contextMenuStrip_Clear
            // 
            this.contextMenuStrip_Clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenuStrip_Clear.Name = "contextMenuStrip_Clear";
            this.contextMenuStrip_Clear.Size = new System.Drawing.Size(163, 22);
            this.contextMenuStrip_Clear.Text = "C&lear";
            this.contextMenuStrip_Clear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip_Clear_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 144);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hardware Control";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(103, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(151, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "------------------------------------";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbt_signalPathSeting_Config);
            this.panel4.Controls.Add(this.rbt_signalPathSeting_AIn);
            this.panel4.Location = new System.Drawing.Point(214, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(87, 45);
            this.panel4.TabIndex = 9;
            // 
            // rbt_signalPathSeting_Config
            // 
            this.rbt_signalPathSeting_Config.AutoSize = true;
            this.rbt_signalPathSeting_Config.Checked = true;
            this.rbt_signalPathSeting_Config.Location = new System.Drawing.Point(3, 25);
            this.rbt_signalPathSeting_Config.Name = "rbt_signalPathSeting_Config";
            this.rbt_signalPathSeting_Config.Size = new System.Drawing.Size(73, 19);
            this.rbt_signalPathSeting_Config.TabIndex = 1;
            this.rbt_signalPathSeting_Config.TabStop = true;
            this.rbt_signalPathSeting_Config.Text = "CONFIG";
            this.rbt_signalPathSeting_Config.UseVisualStyleBackColor = true;
            // 
            // rbt_signalPathSeting_AIn
            // 
            this.rbt_signalPathSeting_AIn.AutoSize = true;
            this.rbt_signalPathSeting_AIn.Location = new System.Drawing.Point(3, 3);
            this.rbt_signalPathSeting_AIn.Name = "rbt_signalPathSeting_AIn";
            this.rbt_signalPathSeting_AIn.Size = new System.Drawing.Size(47, 19);
            this.rbt_signalPathSeting_AIn.TabIndex = 0;
            this.rbt_signalPathSeting_AIn.Text = "VIN";
            this.rbt_signalPathSeting_AIn.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_AIn.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbt_signalPathSeting_Vref);
            this.panel5.Controls.Add(this.rbt_signalPathSeting_Vout);
            this.panel5.Location = new System.Drawing.Point(31, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(74, 45);
            this.panel5.TabIndex = 7;
            // 
            // rbt_signalPathSeting_Vref
            // 
            this.rbt_signalPathSeting_Vref.AutoSize = true;
            this.rbt_signalPathSeting_Vref.Location = new System.Drawing.Point(27, 25);
            this.rbt_signalPathSeting_Vref.Name = "rbt_signalPathSeting_Vref";
            this.rbt_signalPathSeting_Vref.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_Vref.Size = new System.Drawing.Size(49, 19);
            this.rbt_signalPathSeting_Vref.TabIndex = 1;
            this.rbt_signalPathSeting_Vref.Text = "Vref";
            this.rbt_signalPathSeting_Vref.UseVisualStyleBackColor = true;
            // 
            // rbt_signalPathSeting_Vout
            // 
            this.rbt_signalPathSeting_Vout.AutoSize = true;
            this.rbt_signalPathSeting_Vout.Checked = true;
            this.rbt_signalPathSeting_Vout.Location = new System.Drawing.Point(24, 3);
            this.rbt_signalPathSeting_Vout.Name = "rbt_signalPathSeting_Vout";
            this.rbt_signalPathSeting_Vout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbt_signalPathSeting_Vout.Size = new System.Drawing.Size(52, 19);
            this.rbt_signalPathSeting_Vout.TabIndex = 0;
            this.rbt_signalPathSeting_Vout.TabStop = true;
            this.rbt_signalPathSeting_Vout.Text = "Vout";
            this.rbt_signalPathSeting_Vout.UseVisualStyleBackColor = true;
            this.rbt_signalPathSeting_Vout.CheckedChanged += new System.EventHandler(this.rbt_signalPathSeting_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbt_withoutCap_Vref);
            this.panel3.Controls.Add(this.rbt_withCap_Vref);
            this.panel3.Location = new System.Drawing.Point(214, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(87, 45);
            this.panel3.TabIndex = 5;
            // 
            // rbt_withoutCap_Vref
            // 
            this.rbt_withoutCap_Vref.AutoSize = true;
            this.rbt_withoutCap_Vref.Location = new System.Drawing.Point(3, 25);
            this.rbt_withoutCap_Vref.Name = "rbt_withoutCap_Vref";
            this.rbt_withoutCap_Vref.Size = new System.Drawing.Size(94, 19);
            this.rbt_withoutCap_Vref.TabIndex = 1;
            this.rbt_withoutCap_Vref.Text = "Without Cap";
            this.rbt_withoutCap_Vref.UseVisualStyleBackColor = true;
            // 
            // rbt_withCap_Vref
            // 
            this.rbt_withCap_Vref.AutoSize = true;
            this.rbt_withCap_Vref.Checked = true;
            this.rbt_withCap_Vref.Location = new System.Drawing.Point(3, 3);
            this.rbt_withCap_Vref.Name = "rbt_withCap_Vref";
            this.rbt_withCap_Vref.Size = new System.Drawing.Size(77, 19);
            this.rbt_withCap_Vref.TabIndex = 0;
            this.rbt_withCap_Vref.TabStop = true;
            this.rbt_withCap_Vref.Text = "With Cap";
            this.rbt_withCap_Vref.UseVisualStyleBackColor = true;
            this.rbt_withCap_Vref.CheckedChanged += new System.EventHandler(this.rbt_withCap_Vref_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(214, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Vref";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbt_withoutCap_Vout);
            this.panel2.Controls.Add(this.rbt_withCap_Vout);
            this.panel2.Location = new System.Drawing.Point(121, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(87, 45);
            this.panel2.TabIndex = 3;
            // 
            // rbt_withoutCap_Vout
            // 
            this.rbt_withoutCap_Vout.AutoSize = true;
            this.rbt_withoutCap_Vout.Location = new System.Drawing.Point(3, 25);
            this.rbt_withoutCap_Vout.Name = "rbt_withoutCap_Vout";
            this.rbt_withoutCap_Vout.Size = new System.Drawing.Size(94, 19);
            this.rbt_withoutCap_Vout.TabIndex = 1;
            this.rbt_withoutCap_Vout.Text = "Without Cap";
            this.rbt_withoutCap_Vout.UseVisualStyleBackColor = true;
            // 
            // rbt_withCap_Vout
            // 
            this.rbt_withCap_Vout.AutoSize = true;
            this.rbt_withCap_Vout.Checked = true;
            this.rbt_withCap_Vout.Location = new System.Drawing.Point(3, 3);
            this.rbt_withCap_Vout.Name = "rbt_withCap_Vout";
            this.rbt_withCap_Vout.Size = new System.Drawing.Size(77, 19);
            this.rbt_withCap_Vout.TabIndex = 0;
            this.rbt_withCap_Vout.TabStop = true;
            this.rbt_withCap_Vout.Text = "With Cap";
            this.rbt_withCap_Vout.UseVisualStyleBackColor = true;
            this.rbt_withCap_Vout.CheckedChanged += new System.EventHandler(this.rbt_withCap_Vout_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(118, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Vout";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtb_Ext);
            this.panel1.Controls.Add(this.rbt_5V);
            this.panel1.Location = new System.Drawing.Point(31, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 45);
            this.panel1.TabIndex = 1;
            // 
            // rtb_Ext
            // 
            this.rtb_Ext.AutoSize = true;
            this.rtb_Ext.Location = new System.Drawing.Point(3, 25);
            this.rtb_Ext.Name = "rtb_Ext";
            this.rtb_Ext.Size = new System.Drawing.Size(83, 19);
            this.rtb_Ext.TabIndex = 1;
            this.rtb_Ext.Text = "Ext Power";
            this.rtb_Ext.UseVisualStyleBackColor = true;
            // 
            // rbt_5V
            // 
            this.rbt_5V.AutoSize = true;
            this.rbt_5V.Checked = true;
            this.rbt_5V.Location = new System.Drawing.Point(3, 3);
            this.rbt_5V.Name = "rbt_5V";
            this.rbt_5V.Size = new System.Drawing.Size(45, 19);
            this.rbt_5V.TabIndex = 0;
            this.rbt_5V.TabStop = true;
            this.rbt_5V.Text = "5 V";
            this.rbt_5V.UseVisualStyleBackColor = true;
            this.rbt_5V.CheckedChanged += new System.EventHandler(this.rbt_5V_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "VDD";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ADCReset);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_reg83);
            this.groupBox1.Controls.Add(this.txt_reg82);
            this.groupBox1.Controls.Add(this.txt_reg81);
            this.groupBox1.Controls.Add(this.txt_reg80);
            this.groupBox1.Controls.Add(this.btn_writeFuseCode);
            this.groupBox1.Controls.Add(this.btn_Vout_0A);
            this.groupBox1.Controls.Add(this.btn_Vout_5A);
            this.groupBox1.Controls.Add(this.btn_Vout_10A);
            this.groupBox1.Controls.Add(this.btn_fuse_action_ow);
            this.groupBox1.Controls.Add(this.btn_Vout_15A);
            this.groupBox1.Controls.Add(this.btn_enterNomalMode);
            this.groupBox1.Controls.Add(this.btn_offset);
            this.groupBox1.Controls.Add(this.btn_preciseTrim);
            this.groupBox1.Controls.Add(this.btn_roughTrim);
            this.groupBox1.Controls.Add(this.btn_PowerOff_OWCI_ADC);
            this.groupBox1.Controls.Add(this.btn_PowerOn_OWCI_ADC);
            this.groupBox1.Location = new System.Drawing.Point(357, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 268);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trim Sensor";
            // 
            // btn_ADCReset
            // 
            this.btn_ADCReset.Location = new System.Drawing.Point(193, 23);
            this.btn_ADCReset.Name = "btn_ADCReset";
            this.btn_ADCReset.Size = new System.Drawing.Size(135, 23);
            this.btn_ADCReset.TabIndex = 80;
            this.btn_ADCReset.Text = "Reset ADC";
            this.btn_ADCReset.UseVisualStyleBackColor = true;
            this.btn_ADCReset.Click += new System.EventHandler(this.btn_ADCReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(285, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 79;
            this.label5.Text = "Reg4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(200, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 78;
            this.label4.Text = "Reg3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(115, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 77;
            this.label3.Text = "Reg2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(30, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 76;
            this.label2.Text = "Reg1";
            // 
            // txt_reg83
            // 
            this.txt_reg83.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg83.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg83.ForeColor = System.Drawing.Color.White;
            this.txt_reg83.Location = new System.Drawing.Point(272, 233);
            this.txt_reg83.Name = "txt_reg83";
            this.txt_reg83.Size = new System.Drawing.Size(56, 20);
            this.txt_reg83.TabIndex = 75;
            this.txt_reg83.Text = "0x00";
            this.txt_reg83.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg83.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg82
            // 
            this.txt_reg82.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg82.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg82.ForeColor = System.Drawing.Color.White;
            this.txt_reg82.Location = new System.Drawing.Point(187, 233);
            this.txt_reg82.Name = "txt_reg82";
            this.txt_reg82.Size = new System.Drawing.Size(56, 20);
            this.txt_reg82.TabIndex = 74;
            this.txt_reg82.Text = "0x00";
            this.txt_reg82.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg82.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg81
            // 
            this.txt_reg81.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg81.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg81.ForeColor = System.Drawing.Color.White;
            this.txt_reg81.Location = new System.Drawing.Point(102, 233);
            this.txt_reg81.Name = "txt_reg81";
            this.txt_reg81.Size = new System.Drawing.Size(56, 20);
            this.txt_reg81.TabIndex = 73;
            this.txt_reg81.Text = "0x00";
            this.txt_reg81.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg81.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // txt_reg80
            // 
            this.txt_reg80.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg80.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reg80.ForeColor = System.Drawing.Color.White;
            this.txt_reg80.Location = new System.Drawing.Point(17, 233);
            this.txt_reg80.Name = "txt_reg80";
            this.txt_reg80.Size = new System.Drawing.Size(56, 20);
            this.txt_reg80.TabIndex = 72;
            this.txt_reg80.Text = "0x00";
            this.txt_reg80.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reg80.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RegValue_KeyPress);
            // 
            // btn_writeFuseCode
            // 
            this.btn_writeFuseCode.Location = new System.Drawing.Point(193, 151);
            this.btn_writeFuseCode.Name = "btn_writeFuseCode";
            this.btn_writeFuseCode.Size = new System.Drawing.Size(135, 23);
            this.btn_writeFuseCode.TabIndex = 71;
            this.btn_writeFuseCode.Text = "Write Fuse Code";
            this.btn_writeFuseCode.UseVisualStyleBackColor = true;
            this.btn_writeFuseCode.Click += new System.EventHandler(this.btn_writeFuseCode_Click);
            // 
            // btn_Vout_0A
            // 
            this.btn_Vout_0A.Location = new System.Drawing.Point(17, 183);
            this.btn_Vout_0A.Name = "btn_Vout_0A";
            this.btn_Vout_0A.Size = new System.Drawing.Size(135, 23);
            this.btn_Vout_0A.TabIndex = 66;
            this.btn_Vout_0A.Text = "Vout @ 0 A";
            this.btn_Vout_0A.UseVisualStyleBackColor = true;
            this.btn_Vout_0A.Click += new System.EventHandler(this.btn_Vout_0A_Click);
            // 
            // btn_Vout_5A
            // 
            this.btn_Vout_5A.Location = new System.Drawing.Point(17, 151);
            this.btn_Vout_5A.Name = "btn_Vout_5A";
            this.btn_Vout_5A.Size = new System.Drawing.Size(135, 23);
            this.btn_Vout_5A.TabIndex = 65;
            this.btn_Vout_5A.Text = "Vout @ 5 A";
            this.btn_Vout_5A.UseVisualStyleBackColor = true;
            this.btn_Vout_5A.Click += new System.EventHandler(this.btn_Vout_5A_Click);
            // 
            // btn_Vout_10A
            // 
            this.btn_Vout_10A.Location = new System.Drawing.Point(17, 119);
            this.btn_Vout_10A.Name = "btn_Vout_10A";
            this.btn_Vout_10A.Size = new System.Drawing.Size(135, 23);
            this.btn_Vout_10A.TabIndex = 64;
            this.btn_Vout_10A.Text = "Vout @ 10 A";
            this.btn_Vout_10A.UseVisualStyleBackColor = true;
            this.btn_Vout_10A.Click += new System.EventHandler(this.btn_Vout_10A_Click);
            // 
            // btn_fuse_action_ow
            // 
            this.btn_fuse_action_ow.Location = new System.Drawing.Point(193, 183);
            this.btn_fuse_action_ow.Name = "btn_fuse_action_ow";
            this.btn_fuse_action_ow.Size = new System.Drawing.Size(135, 23);
            this.btn_fuse_action_ow.TabIndex = 54;
            this.btn_fuse_action_ow.Text = "Fuse";
            this.btn_fuse_action_ow.UseVisualStyleBackColor = true;
            this.btn_fuse_action_ow.Click += new System.EventHandler(this.btn_fuse_action_ow_Click);
            // 
            // btn_Vout_15A
            // 
            this.btn_Vout_15A.Location = new System.Drawing.Point(17, 87);
            this.btn_Vout_15A.Name = "btn_Vout_15A";
            this.btn_Vout_15A.Size = new System.Drawing.Size(135, 23);
            this.btn_Vout_15A.TabIndex = 63;
            this.btn_Vout_15A.Text = "Vout @ 15 A";
            this.btn_Vout_15A.UseVisualStyleBackColor = true;
            this.btn_Vout_15A.Click += new System.EventHandler(this.btn_Vout_15A_Click);
            // 
            // btn_enterNomalMode
            // 
            this.btn_enterNomalMode.Location = new System.Drawing.Point(17, 55);
            this.btn_enterNomalMode.Name = "btn_enterNomalMode";
            this.btn_enterNomalMode.Size = new System.Drawing.Size(135, 23);
            this.btn_enterNomalMode.TabIndex = 61;
            this.btn_enterNomalMode.Text = "Enter Normal Mode";
            this.btn_enterNomalMode.UseVisualStyleBackColor = true;
            this.btn_enterNomalMode.Click += new System.EventHandler(this.btn_enterNomalMode_Click);
            // 
            // btn_offset
            // 
            this.btn_offset.Location = new System.Drawing.Point(193, 119);
            this.btn_offset.Name = "btn_offset";
            this.btn_offset.Size = new System.Drawing.Size(135, 23);
            this.btn_offset.TabIndex = 60;
            this.btn_offset.Text = "Calculate Offset Code";
            this.btn_offset.UseVisualStyleBackColor = true;
            this.btn_offset.Click += new System.EventHandler(this.btn_offset_Click);
            // 
            // btn_preciseTrim
            // 
            this.btn_preciseTrim.Location = new System.Drawing.Point(193, 87);
            this.btn_preciseTrim.Name = "btn_preciseTrim";
            this.btn_preciseTrim.Size = new System.Drawing.Size(135, 23);
            this.btn_preciseTrim.TabIndex = 59;
            this.btn_preciseTrim.Text = "Calculate Precise Code";
            this.btn_preciseTrim.UseVisualStyleBackColor = true;
            this.btn_preciseTrim.Click += new System.EventHandler(this.btn_preciseTrim_Click);
            // 
            // btn_roughTrim
            // 
            this.btn_roughTrim.Location = new System.Drawing.Point(193, 55);
            this.btn_roughTrim.Name = "btn_roughTrim";
            this.btn_roughTrim.Size = new System.Drawing.Size(135, 23);
            this.btn_roughTrim.TabIndex = 58;
            this.btn_roughTrim.Text = "Calculate Rough Code";
            this.btn_roughTrim.UseVisualStyleBackColor = true;
            this.btn_roughTrim.Click += new System.EventHandler(this.btn_roughTrim_Click);
            // 
            // btn_PowerOff_OWCI_ADC
            // 
            this.btn_PowerOff_OWCI_ADC.Location = new System.Drawing.Point(90, 23);
            this.btn_PowerOff_OWCI_ADC.Name = "btn_PowerOff_OWCI_ADC";
            this.btn_PowerOff_OWCI_ADC.Size = new System.Drawing.Size(62, 23);
            this.btn_PowerOff_OWCI_ADC.TabIndex = 57;
            this.btn_PowerOff_OWCI_ADC.Text = "Power Off";
            this.btn_PowerOff_OWCI_ADC.UseVisualStyleBackColor = true;
            this.btn_PowerOff_OWCI_ADC.Click += new System.EventHandler(this.btn_PowerOff_OWCI_ADC_Click);
            // 
            // btn_PowerOn_OWCI_ADC
            // 
            this.btn_PowerOn_OWCI_ADC.Location = new System.Drawing.Point(17, 23);
            this.btn_PowerOn_OWCI_ADC.Name = "btn_PowerOn_OWCI_ADC";
            this.btn_PowerOn_OWCI_ADC.Size = new System.Drawing.Size(62, 23);
            this.btn_PowerOn_OWCI_ADC.TabIndex = 56;
            this.btn_PowerOn_OWCI_ADC.Text = "Power On";
            this.btn_PowerOn_OWCI_ADC.UseVisualStyleBackColor = true;
            this.btn_PowerOn_OWCI_ADC.Click += new System.EventHandler(this.btn_PowerOn_OWCI_ADC_Click);
            // 
            // grb_devInfo_ow
            // 
            this.grb_devInfo_ow.Controls.Add(this.txt_sampleNum);
            this.grb_devInfo_ow.Controls.Add(this.label18);
            this.grb_devInfo_ow.Controls.Add(this.label16);
            this.grb_devInfo_ow.Controls.Add(this.txt_sampleRate);
            this.grb_devInfo_ow.Controls.Add(this.label15);
            this.grb_devInfo_ow.Controls.Add(this.label12);
            this.grb_devInfo_ow.Controls.Add(this.txt_TargetGain);
            this.grb_devInfo_ow.Controls.Add(this.label11);
            this.grb_devInfo_ow.Controls.Add(this.txt_FullScale);
            this.grb_devInfo_ow.Controls.Add(this.label7);
            this.grb_devInfo_ow.Controls.Add(this.label8);
            this.grb_devInfo_ow.Controls.Add(this.label10);
            this.grb_devInfo_ow.Controls.Add(this.label9);
            this.grb_devInfo_ow.Controls.Add(this.numUD_pilotwidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.numUD_pulsedurationtime_ow);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pilotwidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pulsewidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.num_UD_pulsewidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.txt_dev_addr_onewire);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pulsedurationtime_ow);
            this.grb_devInfo_ow.Controls.Add(this.lbl_devAddr_onewire);
            this.grb_devInfo_ow.Controls.Add(this.label6);
            this.grb_devInfo_ow.Location = new System.Drawing.Point(8, 6);
            this.grb_devInfo_ow.Name = "grb_devInfo_ow";
            this.grb_devInfo_ow.Size = new System.Drawing.Size(324, 118);
            this.grb_devInfo_ow.TabIndex = 57;
            this.grb_devInfo_ow.TabStop = false;
            this.grb_devInfo_ow.Text = "Device Setting";
            // 
            // txt_sampleNum
            // 
            this.txt_sampleNum.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_sampleNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_sampleNum.ForeColor = System.Drawing.Color.White;
            this.txt_sampleNum.Location = new System.Drawing.Point(242, 88);
            this.txt_sampleNum.Name = "txt_sampleNum";
            this.txt_sampleNum.Size = new System.Drawing.Size(56, 20);
            this.txt_sampleNum.TabIndex = 81;
            this.txt_sampleNum.Text = "1024";
            this.txt_sampleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label18.Location = new System.Drawing.Point(166, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 15);
            this.label18.TabIndex = 80;
            this.label18.Text = "Sample Num";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(136, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 15);
            this.label16.TabIndex = 79;
            this.label16.Text = "KHz";
            // 
            // txt_sampleRate
            // 
            this.txt_sampleRate.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_sampleRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_sampleRate.ForeColor = System.Drawing.Color.White;
            this.txt_sampleRate.Location = new System.Drawing.Point(74, 88);
            this.txt_sampleRate.Name = "txt_sampleRate";
            this.txt_sampleRate.Size = new System.Drawing.Size(56, 20);
            this.txt_sampleRate.TabIndex = 78;
            this.txt_sampleRate.Text = "1000";
            this.txt_sampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label15.Location = new System.Drawing.Point(9, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 15);
            this.label15.TabIndex = 77;
            this.label15.Text = "Sample Rate";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 15);
            this.label12.TabIndex = 76;
            this.label12.Text = "A";
            // 
            // txt_TargetGain
            // 
            this.txt_TargetGain.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_TargetGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TargetGain.ForeColor = System.Drawing.Color.White;
            this.txt_TargetGain.Location = new System.Drawing.Point(74, 43);
            this.txt_TargetGain.Name = "txt_TargetGain";
            this.txt_TargetGain.Size = new System.Drawing.Size(56, 20);
            this.txt_TargetGain.TabIndex = 73;
            this.txt_TargetGain.Text = "100";
            this.txt_TargetGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TargetGain.TextChanged += new System.EventHandler(this.txt_TargetGain_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(129, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 75;
            this.label11.Text = "mV/A";
            // 
            // txt_FullScale
            // 
            this.txt_FullScale.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_FullScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_FullScale.ForeColor = System.Drawing.Color.White;
            this.txt_FullScale.Location = new System.Drawing.Point(74, 66);
            this.txt_FullScale.Name = "txt_FullScale";
            this.txt_FullScale.ReadOnly = true;
            this.txt_FullScale.Size = new System.Drawing.Size(56, 20);
            this.txt_FullScale.TabIndex = 74;
            this.txt_FullScale.Text = "20";
            this.txt_FullScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 55;
            this.label7.Text = "ns";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 15);
            this.label8.TabIndex = 56;
            this.label8.Text = "ns";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.Location = new System.Drawing.Point(9, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 72;
            this.label10.Text = "Full Scale";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.Location = new System.Drawing.Point(9, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 71;
            this.label9.Text = "Target Gain";
            // 
            // numUD_pilotwidth_ow
            // 
            this.numUD_pilotwidth_ow.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.Location = new System.Drawing.Point(242, 18);
            this.numUD_pilotwidth_ow.Maximum = new decimal(new int[] {
            255000,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.Name = "numUD_pilotwidth_ow";
            this.numUD_pilotwidth_ow.Size = new System.Drawing.Size(56, 20);
            this.numUD_pilotwidth_ow.TabIndex = 47;
            this.numUD_pilotwidth_ow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_pilotwidth_ow.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.ValueChanged += new System.EventHandler(this.numUD_pilotwidth_ow_ValueChanged);
            // 
            // numUD_pulsedurationtime_ow
            // 
            this.numUD_pulsedurationtime_ow.Location = new System.Drawing.Point(242, 66);
            this.numUD_pulsedurationtime_ow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_pulsedurationtime_ow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUD_pulsedurationtime_ow.Name = "numUD_pulsedurationtime_ow";
            this.numUD_pulsedurationtime_ow.Size = new System.Drawing.Size(56, 20);
            this.numUD_pulsedurationtime_ow.TabIndex = 51;
            this.numUD_pulsedurationtime_ow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_pulsedurationtime_ow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_pilotwidth_ow
            // 
            this.lbl_pilotwidth_ow.AutoSize = true;
            this.lbl_pilotwidth_ow.Location = new System.Drawing.Point(166, 22);
            this.lbl_pilotwidth_ow.Name = "lbl_pilotwidth_ow";
            this.lbl_pilotwidth_ow.Size = new System.Drawing.Size(68, 15);
            this.lbl_pilotwidth_ow.TabIndex = 46;
            this.lbl_pilotwidth_ow.Text = "Pilot Width:";
            // 
            // lbl_pulsewidth_ow
            // 
            this.lbl_pulsewidth_ow.AutoSize = true;
            this.lbl_pulsewidth_ow.Location = new System.Drawing.Point(166, 47);
            this.lbl_pulsewidth_ow.Name = "lbl_pulsewidth_ow";
            this.lbl_pulsewidth_ow.Size = new System.Drawing.Size(75, 15);
            this.lbl_pulsewidth_ow.TabIndex = 49;
            this.lbl_pulsewidth_ow.Text = "Pulse Width:";
            // 
            // num_UD_pulsewidth_ow
            // 
            this.num_UD_pulsewidth_ow.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow.Location = new System.Drawing.Point(242, 43);
            this.num_UD_pulsewidth_ow.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow.Name = "num_UD_pulsewidth_ow";
            this.num_UD_pulsewidth_ow.Size = new System.Drawing.Size(56, 20);
            this.num_UD_pulsewidth_ow.TabIndex = 48;
            this.num_UD_pulsewidth_ow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_UD_pulsewidth_ow.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow.ValueChanged += new System.EventHandler(this.num_UD_pulsewidth_ow_ValueChanged);
            // 
            // txt_dev_addr_onewire
            // 
            this.txt_dev_addr_onewire.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_dev_addr_onewire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txt_dev_addr_onewire.ForeColor = System.Drawing.Color.White;
            this.txt_dev_addr_onewire.Location = new System.Drawing.Point(74, 18);
            this.txt_dev_addr_onewire.Name = "txt_dev_addr_onewire";
            this.txt_dev_addr_onewire.Size = new System.Drawing.Size(56, 20);
            this.txt_dev_addr_onewire.TabIndex = 45;
            this.txt_dev_addr_onewire.Text = "0x73";
            this.txt_dev_addr_onewire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_pulsedurationtime_ow
            // 
            this.lbl_pulsedurationtime_ow.AutoSize = true;
            this.lbl_pulsedurationtime_ow.Location = new System.Drawing.Point(166, 70);
            this.lbl_pulsedurationtime_ow.Name = "lbl_pulsedurationtime_ow";
            this.lbl_pulsedurationtime_ow.Size = new System.Drawing.Size(88, 15);
            this.lbl_pulsedurationtime_ow.TabIndex = 52;
            this.lbl_pulsedurationtime_ow.Text = "Duration Time:";
            // 
            // lbl_devAddr_onewire
            // 
            this.lbl_devAddr_onewire.AutoSize = true;
            this.lbl_devAddr_onewire.Location = new System.Drawing.Point(9, 22);
            this.lbl_devAddr_onewire.Name = "lbl_devAddr_onewire";
            this.lbl_devAddr_onewire.Size = new System.Drawing.Size(59, 15);
            this.lbl_devAddr_onewire.TabIndex = 44;
            this.lbl_devAddr_onewire.Text = "Dev Addr:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 15);
            this.label6.TabIndex = 53;
            this.label6.Text = "ms";
            // 
            // btn_flash_onewire
            // 
            this.btn_flash_onewire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_flash_onewire.Location = new System.Drawing.Point(787, 396);
            this.btn_flash_onewire.Name = "btn_flash_onewire";
            this.btn_flash_onewire.Size = new System.Drawing.Size(54, 24);
            this.btn_flash_onewire.TabIndex = 55;
            this.btn_flash_onewire.Text = "FlashLED";
            this.btn_flash_onewire.UseVisualStyleBackColor = true;
            this.btn_flash_onewire.Click += new System.EventHandler(this.btn_flash_onewire_Click);
            // 
            // btn_GetFW_OneWire
            // 
            this.btn_GetFW_OneWire.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_GetFW_OneWire.Location = new System.Drawing.Point(721, 397);
            this.btn_GetFW_OneWire.Name = "btn_GetFW_OneWire";
            this.btn_GetFW_OneWire.Size = new System.Drawing.Size(54, 23);
            this.btn_GetFW_OneWire.TabIndex = 56;
            this.btn_GetFW_OneWire.Text = "FW Ver";
            this.btn_GetFW_OneWire.UseVisualStyleBackColor = true;
            this.btn_GetFW_OneWire.Click += new System.EventHandler(this.btn_GetFW_OneWire_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_sel_cap);
            this.groupBox5.Controls.Add(this.btn_sel_vr);
            this.groupBox5.Controls.Add(this.btn_ch_ck);
            this.groupBox5.Controls.Add(this.btn_nc_1x);
            this.groupBox5.Location = new System.Drawing.Point(723, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 160);
            this.groupBox5.TabIndex = 67;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            // 
            // btn_sel_cap
            // 
            this.btn_sel_cap.Location = new System.Drawing.Point(14, 119);
            this.btn_sel_cap.Name = "btn_sel_cap";
            this.btn_sel_cap.Size = new System.Drawing.Size(90, 23);
            this.btn_sel_cap.TabIndex = 66;
            this.btn_sel_cap.Text = "SEL_CAP";
            this.btn_sel_cap.UseVisualStyleBackColor = true;
            this.btn_sel_cap.Click += new System.EventHandler(this.btn_sel_cap_Click);
            // 
            // btn_sel_vr
            // 
            this.btn_sel_vr.Location = new System.Drawing.Point(14, 23);
            this.btn_sel_vr.Name = "btn_sel_vr";
            this.btn_sel_vr.Size = new System.Drawing.Size(90, 23);
            this.btn_sel_vr.TabIndex = 66;
            this.btn_sel_vr.Text = "SEL_VR";
            this.btn_sel_vr.UseVisualStyleBackColor = true;
            this.btn_sel_vr.Click += new System.EventHandler(this.btn_sel_vr_Click);
            // 
            // btn_ch_ck
            // 
            this.btn_ch_ck.Location = new System.Drawing.Point(14, 86);
            this.btn_ch_ck.Name = "btn_ch_ck";
            this.btn_ch_ck.Size = new System.Drawing.Size(90, 23);
            this.btn_ch_ck.TabIndex = 66;
            this.btn_ch_ck.Text = "CH_CK";
            this.btn_ch_ck.UseVisualStyleBackColor = true;
            this.btn_ch_ck.Click += new System.EventHandler(this.btn_ch_ck_Click);
            // 
            // btn_nc_1x
            // 
            this.btn_nc_1x.Location = new System.Drawing.Point(14, 55);
            this.btn_nc_1x.Name = "btn_nc_1x";
            this.btn_nc_1x.Size = new System.Drawing.Size(90, 23);
            this.btn_nc_1x.TabIndex = 66;
            this.btn_nc_1x.Text = "NC_1X";
            this.btn_nc_1x.UseVisualStyleBackColor = true;
            this.btn_nc_1x.Click += new System.EventHandler(this.btn_nc_1x_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_MarginalRead);
            this.groupBox3.Controls.Add(this.btn_Reload);
            this.groupBox3.Controls.Add(this.btn_burstRead);
            this.groupBox3.Location = new System.Drawing.Point(721, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 189);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "I2C Read";
            // 
            // btn_MarginalRead
            // 
            this.btn_MarginalRead.Location = new System.Drawing.Point(16, 76);
            this.btn_MarginalRead.Name = "btn_MarginalRead";
            this.btn_MarginalRead.Size = new System.Drawing.Size(90, 38);
            this.btn_MarginalRead.TabIndex = 64;
            this.btn_MarginalRead.Text = "Marginal Read";
            this.btn_MarginalRead.UseVisualStyleBackColor = true;
            this.btn_MarginalRead.Click += new System.EventHandler(this.btn_MarginalRead_Click);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(16, 26);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(90, 38);
            this.btn_Reload.TabIndex = 65;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_burstRead
            // 
            this.btn_burstRead.Location = new System.Drawing.Point(16, 126);
            this.btn_burstRead.Name = "btn_burstRead";
            this.btn_burstRead.Size = new System.Drawing.Size(90, 38);
            this.btn_burstRead.TabIndex = 63;
            this.btn_burstRead.Text = "Read";
            this.btn_burstRead.UseVisualStyleBackColor = true;
            this.btn_burstRead.Click += new System.EventHandler(this.btn_burstRead_Click);
            // 
            // CustomerTab
            // 
            this.CustomerTab.Controls.Add(this.cmb_IPxForCalc_Customer);
            this.CustomerTab.Controls.Add(this.label19);
            this.CustomerTab.Controls.Add(this.autoTrimResultIndicator);
            this.CustomerTab.Controls.Add(this.cmb_TargetGain_Customer);
            this.CustomerTab.Controls.Add(this.label20);
            this.CustomerTab.Controls.Add(this.lbl_passOrFailed);
            this.CustomerTab.Controls.Add(this.btn_AutomaticaTrim);
            this.CustomerTab.Location = new System.Drawing.Point(4, 22);
            this.CustomerTab.Name = "CustomerTab";
            this.CustomerTab.Padding = new System.Windows.Forms.Padding(3);
            this.CustomerTab.Size = new System.Drawing.Size(856, 427);
            this.CustomerTab.TabIndex = 1;
            this.CustomerTab.Text = "Current Sensor Programming Tool";
            this.CustomerTab.UseVisualStyleBackColor = true;
            // 
            // cmb_IPxForCalc_Customer
            // 
            this.cmb_IPxForCalc_Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IPxForCalc_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmb_IPxForCalc_Customer.FormattingEnabled = true;
            this.cmb_IPxForCalc_Customer.Items.AddRange(new object[] {
            "IP5",
            "IP10",
            "IP15",
            "IP20"});
            this.cmb_IPxForCalc_Customer.Location = new System.Drawing.Point(273, 92);
            this.cmb_IPxForCalc_Customer.Name = "cmb_IPxForCalc_Customer";
            this.cmb_IPxForCalc_Customer.Size = new System.Drawing.Size(70, 28);
            this.cmb_IPxForCalc_Customer.TabIndex = 83;
            this.cmb_IPxForCalc_Customer.SelectedIndexChanged += new System.EventHandler(this.cmb_IPxForCalc_Customer_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label19.Location = new System.Drawing.Point(274, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 20);
            this.label19.TabIndex = 82;
            this.label19.Text = "IPx For Calc";
            // 
            // autoTrimResultIndicator
            // 
            this.autoTrimResultIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.autoTrimResultIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoTrimResultIndicator.Location = new System.Drawing.Point(3, 400);
            this.autoTrimResultIndicator.Name = "autoTrimResultIndicator";
            this.autoTrimResultIndicator.ReadOnly = true;
            this.autoTrimResultIndicator.Size = new System.Drawing.Size(850, 24);
            this.autoTrimResultIndicator.TabIndex = 80;
            this.autoTrimResultIndicator.Text = "";
            // 
            // cmb_TargetGain_Customer
            // 
            this.cmb_TargetGain_Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TargetGain_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmb_TargetGain_Customer.FormattingEnabled = true;
            this.cmb_TargetGain_Customer.Items.AddRange(new object[] {
            "25 mV/A",
            "40 mV/A",
            "80 mV/A",
            "100 mV/A"});
            this.cmb_TargetGain_Customer.Location = new System.Drawing.Point(392, 92);
            this.cmb_TargetGain_Customer.Name = "cmb_TargetGain_Customer";
            this.cmb_TargetGain_Customer.Size = new System.Drawing.Size(100, 28);
            this.cmb_TargetGain_Customer.TabIndex = 79;
            this.cmb_TargetGain_Customer.SelectedIndexChanged += new System.EventHandler(this.cmb_TargetGain_Customer_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label20.Location = new System.Drawing.Point(387, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(125, 26);
            this.label20.TabIndex = 76;
            this.label20.Text = "Target Gain";
            // 
            // lbl_passOrFailed
            // 
            this.lbl_passOrFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_passOrFailed.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_passOrFailed.Location = new System.Drawing.Point(244, 249);
            this.lbl_passOrFailed.Name = "lbl_passOrFailed";
            this.lbl_passOrFailed.Size = new System.Drawing.Size(290, 81);
            this.lbl_passOrFailed.TabIndex = 58;
            this.lbl_passOrFailed.Text = "START!";
            this.lbl_passOrFailed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AutomaticaTrim
            // 
            this.btn_AutomaticaTrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_AutomaticaTrim.Location = new System.Drawing.Point(273, 148);
            this.btn_AutomaticaTrim.Name = "btn_AutomaticaTrim";
            this.btn_AutomaticaTrim.Size = new System.Drawing.Size(219, 77);
            this.btn_AutomaticaTrim.TabIndex = 57;
            this.btn_AutomaticaTrim.Text = "Automatic Trim";
            this.btn_AutomaticaTrim.UseVisualStyleBackColor = true;
            this.btn_AutomaticaTrim.Click += new System.EventHandler(this.btn_AutomaticaTrim_Click);
            // 
            // CurrentSensorConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "CurrentSensorConsole";
            this.Text = "Current Sensor Console v3.0.0 - CopyRight of SenkoMicro, Inc";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.InternalTab.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb_devInfo_ow.ResumeLayout(false);
            this.grb_devInfo_ow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.CustomerTab.ResumeLayout(false);
            this.CustomerTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Connection;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage InternalTab;
        private System.Windows.Forms.TabPage CustomerTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_fuse_action_ow;
        private System.Windows.Forms.NumericUpDown numUD_pulsedurationtime_ow;
        private System.Windows.Forms.Label lbl_pulsewidth_ow;
        private System.Windows.Forms.NumericUpDown num_UD_pulsewidth_ow;
        private System.Windows.Forms.Label lbl_pulsedurationtime_ow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grb_devInfo_ow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUD_pilotwidth_ow;
        private System.Windows.Forms.Label lbl_pilotwidth_ow;
        private System.Windows.Forms.TextBox txt_dev_addr_onewire;
        private System.Windows.Forms.Label lbl_devAddr_onewire;
        private System.Windows.Forms.Button btn_flash_onewire;
        private System.Windows.Forms.Button btn_GetFW_OneWire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_PowerOff_OWCI_ADC;
        private System.Windows.Forms.Button btn_PowerOn_OWCI_ADC;
        private System.Windows.Forms.Button btn_preciseTrim;
        private System.Windows.Forms.Button btn_roughTrim;
        private System.Windows.Forms.Button btn_offset;
        private System.Windows.Forms.TextBox txt_FullScale;
        private System.Windows.Forms.TextBox txt_TargetGain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Vout_0A;
        private System.Windows.Forms.Button btn_Vout_5A;
        private System.Windows.Forms.Button btn_Vout_10A;
        private System.Windows.Forms.Button btn_Vout_15A;
        private System.Windows.Forms.Button btn_enterNomalMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_FWInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_writeFuseCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Config;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_AIn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Vref;
        private System.Windows.Forms.RadioButton rbt_signalPathSeting_Vout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbt_withoutCap_Vref;
        private System.Windows.Forms.RadioButton rbt_withCap_Vref;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbt_withoutCap_Vout;
        private System.Windows.Forms.RadioButton rbt_withCap_Vout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rtb_Ext;
        private System.Windows.Forms.RadioButton rbt_5V;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_reg83;
        private System.Windows.Forms.TextBox txt_reg82;
        private System.Windows.Forms.TextBox txt_reg81;
        private System.Windows.Forms.TextBox txt_reg80;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_sampleRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_sampleNum;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_ADCReset;
        private System.Windows.Forms.RichTextBox txt_OutputMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_SelAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Copy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStrip_Clear;
        private System.Windows.Forms.Button btn_burstRead;
        private System.Windows.Forms.Label lbl_passOrFailed;
        private System.Windows.Forms.Button btn_AutomaticaTrim;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmb_TargetGain_Customer;
        private System.Windows.Forms.Button btn_MarginalRead;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.RichTextBox autoTrimResultIndicator;
        private System.Windows.Forms.Button btn_ch_ck;
        private System.Windows.Forms.Button btn_nc_1x;
        private System.Windows.Forms.Button btn_sel_vr;
        private System.Windows.Forms.Button btn_sel_cap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmb_IPxForCalc_Customer;
        private System.Windows.Forms.Label label19;
    }
}