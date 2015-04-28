namespace Test
{
    partial class TestGUI
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
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_deviceNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chb_status = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_GUID_Read = new System.Windows.Forms.TextBox();
            this.txt_GUID_Write = new System.Windows.Forms.TextBox();
            this.btn_readData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_readlength = new System.Windows.Forms.TextBox();
            this.btn_write = new System.Windows.Forms.Button();
            this.btn_getWav = new System.Windows.Forms.Button();
            this.txt_writeData = new System.Windows.Forms.TextBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.grb_TestInterface = new System.Windows.Forms.GroupBox();
            this.btn_testFixFloatConv = new System.Windows.Forms.Button();
            this.btn_testArrayCompare = new System.Windows.Forms.Button();
            this.btn_testIntArrayToBytes = new System.Windows.Forms.Button();
            this.btn_ReadLocalIV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_timerEnable = new System.Windows.Forms.Button();
            this.lbl_firmVersion = new System.Windows.Forms.Label();
            this.btn_ModuleEnable = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbl_dllVersion = new System.Windows.Forms.Label();
            this.tabCtrl_ForSDP = new System.Windows.Forms.TabControl();
            this.tabPage_OneWire = new System.Windows.Forms.TabPage();
            this.groupBox_usercommand = new System.Windows.Forms.GroupBox();
            this.btn_WriteUserCMD_OW = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_userCMD_ParamNum_OWI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_userCMD_UPCount_OWI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_userCMD_DownCount_OWI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_userCMD_OWI = new System.Windows.Forms.TextBox();
            this.grb_ScanTest_OW = new System.Windows.Forms.GroupBox();
            this.pgb_ProcessedRate_OW = new System.Windows.Forms.ProgressBar();
            this.lbl_ScanWroteNum_OW = new System.Windows.Forms.Label();
            this.lbl_loadNum_OW = new System.Windows.Forms.Label();
            this.txt_WroteNum_OW = new System.Windows.Forms.TextBox();
            this.txt_loadNum_OW = new System.Windows.Forms.TextBox();
            this.btn_startScanWrite_OW = new System.Windows.Forms.Button();
            this.btn_LoadScanData_OW = new System.Windows.Forms.Button();
            this.btn_test_ow = new System.Windows.Forms.Button();
            this.cmb_fusepulsewidth = new System.Windows.Forms.ComboBox();
            this.grb_FuseMode_OW = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_fuse_action_ow = new System.Windows.Forms.Button();
            this.numUD_pulsedurationtime_ow = new System.Windows.Forms.NumericUpDown();
            this.lbl_pulsewidth_ow = new System.Windows.Forms.Label();
            this.num_UD_pulsewidth_ow = new System.Windows.Forms.NumericUpDown();
            this.chb_FuseModeSwitch = new System.Windows.Forms.CheckBox();
            this.lbl_pulsedurationtime_ow = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtn_FuseClkOn = new System.Windows.Forms.RadioButton();
            this.grb_BurstI2CRW_OW = new System.Windows.Forms.GroupBox();
            this.lbl_reg_data_burst_onewire = new System.Windows.Forms.Label();
            this.txt_reg_data_owb = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Burst_Onewire = new System.Windows.Forms.Button();
            this.btn_I2CRead_Burst_Onewire = new System.Windows.Forms.Button();
            this.txt_reg_addr_owb = new System.Windows.Forms.TextBox();
            this.txt_I2C_rw_num_owb = new System.Windows.Forms.TextBox();
            this.lbl_rw_num_burst_onewire = new System.Windows.Forms.Label();
            this.lbl_reg_addr_burst_onewire = new System.Windows.Forms.Label();
            this.grb_SingleI2CRW_OW = new System.Windows.Forms.GroupBox();
            this.btn_I2CWrite_Single_Onewire12 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire12 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows12 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows12 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire11 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire11 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows11 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows11 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire10 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire10 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows10 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows10 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire9 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire9 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows9 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows9 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire8 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire8 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows8 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows8 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire7 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire7 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows7 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows7 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire6 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire6 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows6 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows6 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire5 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire5 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows5 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows5 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire4 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire4 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows4 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows4 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire3 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire3 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows3 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows3 = new System.Windows.Forms.TextBox();
            this.btn_I2CWrite_Single_Onewire2 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire2 = new System.Windows.Forms.Button();
            this.txt_reg_addr_ows2 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows2 = new System.Windows.Forms.TextBox();
            this.lbl_reg_data_single_onewire = new System.Windows.Forms.Label();
            this.btn_I2CWrite_Single_Onewire1 = new System.Windows.Forms.Button();
            this.btn_I2CRead_Single_Onewire1 = new System.Windows.Forms.Button();
            this.lbl_reg_addr_single_onewire = new System.Windows.Forms.Label();
            this.txt_reg_addr_ows1 = new System.Windows.Forms.TextBox();
            this.txt_reg_data_ows1 = new System.Windows.Forms.TextBox();
            this.grb_devInfo_ow = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numUD_pilotwidth_ow = new System.Windows.Forms.NumericUpDown();
            this.lbl_pilotwidth_ow = new System.Windows.Forms.Label();
            this.txt_dev_addr_onewire = new System.Windows.Forms.TextBox();
            this.lbl_devAddr_onewire = new System.Windows.Forms.Label();
            this.lbl_FW_onewire = new System.Windows.Forms.Label();
            this.btn_flash_onewire = new System.Windows.Forms.Button();
            this.btn_GetFW_OneWire = new System.Windows.Forms.Button();
            this.rbtn_FuseClkOff = new System.Windows.Forms.RadioButton();
            this.tabPage_ADMP521 = new System.Windows.Forms.TabPage();
            this.btn_testReadSize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_i2cWriteVal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_i2cRead = new System.Windows.Forms.TextBox();
            this.txt_i2cWriteAdd = new System.Windows.Forms.TextBox();
            this.btn_TestMode = new System.Windows.Forms.Button();
            this.chb_clkSetting = new System.Windows.Forms.CheckBox();
            this.chb_postTrim = new System.Windows.Forms.CheckBox();
            this.numUD_fuseClk = new System.Windows.Forms.NumericUpDown();
            this.btn_normalMode = new System.Windows.Forms.Button();
            this.btn_NormalTest = new System.Windows.Forms.Button();
            this.btn_fuseOperation = new System.Windows.Forms.Button();
            this.btn_initMode = new System.Windows.Forms.Button();
            this.btn_enterFuseMode = new System.Windows.Forms.Button();
            this.chb_TestBool = new System.Windows.Forms.CheckBox();
            this.chb_SetLR = new System.Windows.Forms.CheckBox();
            this.btn_ContinuousRecord = new System.Windows.Forms.Button();
            this.btn_I2CWrite = new System.Windows.Forms.Button();
            this.btn_TestI2CRead = new System.Windows.Forms.Button();
            this.lbl_PDMBaseData = new System.Windows.Forms.Label();
            this.txt_PDMBaseData = new System.Windows.Forms.TextBox();
            this.grb_Tools = new System.Windows.Forms.GroupBox();
            this.btn_ConvertRaw2Text = new System.Windows.Forms.Button();
            this.btn_GetFWVersion = new System.Windows.Forms.Button();
            this.lbl_FWVesion_521 = new System.Windows.Forms.Label();
            this.btn_DecoderLocalFile = new System.Windows.Forms.Button();
            this.btn_Decoder = new System.Windows.Forms.Button();
            this.btn_scrambler = new System.Windows.Forms.Button();
            this.btn_generateCSV = new System.Windows.Forms.Button();
            this.btn_PDMDataAnalysis = new System.Windows.Forms.Button();
            this.pgb_PDMreceive = new System.Windows.Forms.ProgressBar();
            this.lbl_num_8kwillRead = new System.Windows.Forms.Label();
            this.grb_521Test = new System.Windows.Forms.GroupBox();
            this.btn_testBtn = new System.Windows.Forms.Button();
            this.lbl_testCount = new System.Windows.Forms.Label();
            this.btn_TestRead = new System.Windows.Forms.Button();
            this.btn_falsh = new System.Windows.Forms.Button();
            this.numUD_num8K = new System.Windows.Forms.NumericUpDown();
            this.btn_PDMStop = new System.Windows.Forms.Button();
            this.btn_PDMStart = new System.Windows.Forms.Button();
            this.tabPage_SPK = new System.Windows.Forms.TabPage();
            this.cmb_devSel = new System.Windows.Forms.ComboBox();
            this.grb_TestInterface.SuspendLayout();
            this.tabCtrl_ForSDP.SuspendLayout();
            this.tabPage_OneWire.SuspendLayout();
            this.groupBox_usercommand.SuspendLayout();
            this.grb_ScanTest_OW.SuspendLayout();
            this.grb_FuseMode_OW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow)).BeginInit();
            this.grb_BurstI2CRW_OW.SuspendLayout();
            this.grb_SingleI2CRW_OW.SuspendLayout();
            this.grb_devInfo_ow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow)).BeginInit();
            this.tabPage_ADMP521.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_fuseClk)).BeginInit();
            this.grb_Tools.SuspendLayout();
            this.grb_521Test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_num8K)).BeginInit();
            this.tabPage_SPK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(455, 9);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_deviceNum
            // 
            this.txt_deviceNum.Location = new System.Drawing.Point(455, 51);
            this.txt_deviceNum.Name = "txt_deviceNum";
            this.txt_deviceNum.Size = new System.Drawing.Size(75, 20);
            this.txt_deviceNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Device Num";
            // 
            // chb_status
            // 
            this.chb_status.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_status.BackColor = System.Drawing.Color.IndianRed;
            this.chb_status.Location = new System.Drawing.Point(679, 16);
            this.chb_status.Name = "chb_status";
            this.chb_status.Size = new System.Drawing.Size(101, 50);
            this.chb_status.TabIndex = 3;
            this.chb_status.Text = "Disconnected";
            this.chb_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_status.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "GUID";
            // 
            // txt_GUID_Read
            // 
            this.txt_GUID_Read.Location = new System.Drawing.Point(24, 51);
            this.txt_GUID_Read.Name = "txt_GUID_Read";
            this.txt_GUID_Read.Size = new System.Drawing.Size(395, 20);
            this.txt_GUID_Read.TabIndex = 4;
            // 
            // txt_GUID_Write
            // 
            this.txt_GUID_Write.Location = new System.Drawing.Point(24, 12);
            this.txt_GUID_Write.Name = "txt_GUID_Write";
            this.txt_GUID_Write.Size = new System.Drawing.Size(395, 20);
            this.txt_GUID_Write.TabIndex = 6;
            // 
            // btn_readData
            // 
            this.btn_readData.Location = new System.Drawing.Point(39, 160);
            this.btn_readData.Name = "btn_readData";
            this.btn_readData.Size = new System.Drawing.Size(75, 23);
            this.btn_readData.TabIndex = 7;
            this.btn_readData.Text = "Read Test";
            this.btn_readData.UseVisualStyleBackColor = true;
            this.btn_readData.Click += new System.EventHandler(this.btn_readData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Read length";
            // 
            // txt_readlength
            // 
            this.txt_readlength.Location = new System.Drawing.Point(39, 210);
            this.txt_readlength.Name = "txt_readlength";
            this.txt_readlength.Size = new System.Drawing.Size(100, 20);
            this.txt_readlength.TabIndex = 8;
            // 
            // btn_write
            // 
            this.btn_write.Location = new System.Drawing.Point(411, 194);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(75, 23);
            this.btn_write.TabIndex = 10;
            this.btn_write.Text = "Write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // btn_getWav
            // 
            this.btn_getWav.Location = new System.Drawing.Point(39, 86);
            this.btn_getWav.Name = "btn_getWav";
            this.btn_getWav.Size = new System.Drawing.Size(75, 23);
            this.btn_getWav.TabIndex = 11;
            this.btn_getWav.Text = "获取测试波形";
            this.btn_getWav.UseVisualStyleBackColor = true;
            this.btn_getWav.Click += new System.EventHandler(this.btn_getWav_Click);
            // 
            // txt_writeData
            // 
            this.txt_writeData.Location = new System.Drawing.Point(293, 197);
            this.txt_writeData.Name = "txt_writeData";
            this.txt_writeData.Size = new System.Drawing.Size(100, 20);
            this.txt_writeData.TabIndex = 12;
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(517, 195);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 23);
            this.btn_Read.TabIndex = 13;
            this.btn_Read.Text = "Read";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // grb_TestInterface
            // 
            this.grb_TestInterface.Controls.Add(this.btn_testFixFloatConv);
            this.grb_TestInterface.Controls.Add(this.btn_testArrayCompare);
            this.grb_TestInterface.Controls.Add(this.btn_testIntArrayToBytes);
            this.grb_TestInterface.Controls.Add(this.btn_ReadLocalIV);
            this.grb_TestInterface.Location = new System.Drawing.Point(39, 6);
            this.grb_TestInterface.Name = "grb_TestInterface";
            this.grb_TestInterface.Size = new System.Drawing.Size(560, 56);
            this.grb_TestInterface.TabIndex = 14;
            this.grb_TestInterface.TabStop = false;
            this.grb_TestInterface.Text = "接口测试";
            // 
            // btn_testFixFloatConv
            // 
            this.btn_testFixFloatConv.Location = new System.Drawing.Point(439, 19);
            this.btn_testFixFloatConv.Name = "btn_testFixFloatConv";
            this.btn_testFixFloatConv.Size = new System.Drawing.Size(107, 23);
            this.btn_testFixFloatConv.TabIndex = 12;
            this.btn_testFixFloatConv.Text = "Fix Point<-> Float Point";
            this.btn_testFixFloatConv.UseVisualStyleBackColor = true;
            this.btn_testFixFloatConv.Click += new System.EventHandler(this.btn_testFixFloatConv_Click);
            // 
            // btn_testArrayCompare
            // 
            this.btn_testArrayCompare.Location = new System.Drawing.Point(302, 19);
            this.btn_testArrayCompare.Name = "btn_testArrayCompare";
            this.btn_testArrayCompare.Size = new System.Drawing.Size(107, 23);
            this.btn_testArrayCompare.TabIndex = 11;
            this.btn_testArrayCompare.Text = "Compare two array";
            this.btn_testArrayCompare.UseVisualStyleBackColor = true;
            this.btn_testArrayCompare.Click += new System.EventHandler(this.btn_testArrayCompare_Click);
            // 
            // btn_testIntArrayToBytes
            // 
            this.btn_testIntArrayToBytes.Location = new System.Drawing.Point(136, 19);
            this.btn_testIntArrayToBytes.Name = "btn_testIntArrayToBytes";
            this.btn_testIntArrayToBytes.Size = new System.Drawing.Size(137, 23);
            this.btn_testIntArrayToBytes.TabIndex = 11;
            this.btn_testIntArrayToBytes.Text = "Convert Int[] -> byte[]";
            this.btn_testIntArrayToBytes.UseVisualStyleBackColor = true;
            this.btn_testIntArrayToBytes.Click += new System.EventHandler(this.btn_testIntArrayToBytes_Click);
            // 
            // btn_ReadLocalIV
            // 
            this.btn_ReadLocalIV.Location = new System.Drawing.Point(25, 19);
            this.btn_ReadLocalIV.Name = "btn_ReadLocalIV";
            this.btn_ReadLocalIV.Size = new System.Drawing.Size(75, 23);
            this.btn_ReadLocalIV.TabIndex = 11;
            this.btn_ReadLocalIV.Text = "Read IV";
            this.btn_ReadLocalIV.UseVisualStyleBackColor = true;
            this.btn_ReadLocalIV.Click += new System.EventHandler(this.btn_ReadLocalIV_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 37);
            this.button2.TabIndex = 15;
            this.button2.Text = "Read";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_timerEnable
            // 
            this.btn_timerEnable.Location = new System.Drawing.Point(517, 79);
            this.btn_timerEnable.Name = "btn_timerEnable";
            this.btn_timerEnable.Size = new System.Drawing.Size(93, 23);
            this.btn_timerEnable.TabIndex = 16;
            this.btn_timerEnable.Text = "Timer Enalbe";
            this.btn_timerEnable.UseVisualStyleBackColor = true;
            this.btn_timerEnable.Click += new System.EventHandler(this.btn_timerEnable_Click);
            // 
            // lbl_firmVersion
            // 
            this.lbl_firmVersion.AutoSize = true;
            this.lbl_firmVersion.Location = new System.Drawing.Point(425, 123);
            this.lbl_firmVersion.Name = "lbl_firmVersion";
            this.lbl_firmVersion.Size = new System.Drawing.Size(67, 13);
            this.lbl_firmVersion.TabIndex = 17;
            this.lbl_firmVersion.Text = "Firm Version:";
            // 
            // btn_ModuleEnable
            // 
            this.btn_ModuleEnable.Location = new System.Drawing.Point(189, 115);
            this.btn_ModuleEnable.Name = "btn_ModuleEnable";
            this.btn_ModuleEnable.Size = new System.Drawing.Size(151, 37);
            this.btn_ModuleEnable.TabIndex = 18;
            this.btn_ModuleEnable.Text = "Module Enable";
            this.btn_ModuleEnable.UseVisualStyleBackColor = true;
            this.btn_ModuleEnable.Click += new System.EventHandler(this.btn_ModuleEnable_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(87, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbl_dllVersion
            // 
            this.lbl_dllVersion.AutoSize = true;
            this.lbl_dllVersion.Location = new System.Drawing.Point(425, 142);
            this.lbl_dllVersion.Name = "lbl_dllVersion";
            this.lbl_dllVersion.Size = new System.Drawing.Size(60, 13);
            this.lbl_dllVersion.TabIndex = 20;
            this.lbl_dllVersion.Text = "Dll Version:";
            // 
            // tabCtrl_ForSDP
            // 
            this.tabCtrl_ForSDP.Controls.Add(this.tabPage_OneWire);
            this.tabCtrl_ForSDP.Controls.Add(this.tabPage_ADMP521);
            this.tabCtrl_ForSDP.Controls.Add(this.tabPage_SPK);
            this.tabCtrl_ForSDP.Location = new System.Drawing.Point(24, 77);
            this.tabCtrl_ForSDP.Name = "tabCtrl_ForSDP";
            this.tabCtrl_ForSDP.SelectedIndex = 0;
            this.tabCtrl_ForSDP.Size = new System.Drawing.Size(831, 468);
            this.tabCtrl_ForSDP.TabIndex = 21;
            // 
            // tabPage_OneWire
            // 
            this.tabPage_OneWire.Controls.Add(this.groupBox_usercommand);
            this.tabPage_OneWire.Controls.Add(this.grb_ScanTest_OW);
            this.tabPage_OneWire.Controls.Add(this.btn_test_ow);
            this.tabPage_OneWire.Controls.Add(this.cmb_fusepulsewidth);
            this.tabPage_OneWire.Controls.Add(this.grb_FuseMode_OW);
            this.tabPage_OneWire.Controls.Add(this.rbtn_FuseClkOn);
            this.tabPage_OneWire.Controls.Add(this.grb_BurstI2CRW_OW);
            this.tabPage_OneWire.Controls.Add(this.grb_SingleI2CRW_OW);
            this.tabPage_OneWire.Controls.Add(this.grb_devInfo_ow);
            this.tabPage_OneWire.Controls.Add(this.lbl_FW_onewire);
            this.tabPage_OneWire.Controls.Add(this.btn_flash_onewire);
            this.tabPage_OneWire.Controls.Add(this.btn_GetFW_OneWire);
            this.tabPage_OneWire.Controls.Add(this.rbtn_FuseClkOff);
            this.tabPage_OneWire.Location = new System.Drawing.Point(4, 22);
            this.tabPage_OneWire.Name = "tabPage_OneWire";
            this.tabPage_OneWire.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OneWire.Size = new System.Drawing.Size(823, 442);
            this.tabPage_OneWire.TabIndex = 2;
            this.tabPage_OneWire.Text = "OneWire";
            this.tabPage_OneWire.UseVisualStyleBackColor = true;
            // 
            // groupBox_usercommand
            // 
            this.groupBox_usercommand.Controls.Add(this.btn_WriteUserCMD_OW);
            this.groupBox_usercommand.Controls.Add(this.label12);
            this.groupBox_usercommand.Controls.Add(this.txt_userCMD_ParamNum_OWI);
            this.groupBox_usercommand.Controls.Add(this.label11);
            this.groupBox_usercommand.Controls.Add(this.txt_userCMD_UPCount_OWI);
            this.groupBox_usercommand.Controls.Add(this.label10);
            this.groupBox_usercommand.Controls.Add(this.txt_userCMD_DownCount_OWI);
            this.groupBox_usercommand.Controls.Add(this.label9);
            this.groupBox_usercommand.Controls.Add(this.txt_userCMD_OWI);
            this.groupBox_usercommand.Location = new System.Drawing.Point(6, 281);
            this.groupBox_usercommand.Name = "groupBox_usercommand";
            this.groupBox_usercommand.Size = new System.Drawing.Size(170, 155);
            this.groupBox_usercommand.TabIndex = 53;
            this.groupBox_usercommand.TabStop = false;
            this.groupBox_usercommand.Text = "User Command";
            // 
            // btn_WriteUserCMD_OW
            // 
            this.btn_WriteUserCMD_OW.Location = new System.Drawing.Point(46, 128);
            this.btn_WriteUserCMD_OW.Name = "btn_WriteUserCMD_OW";
            this.btn_WriteUserCMD_OW.Size = new System.Drawing.Size(78, 23);
            this.btn_WriteUserCMD_OW.TabIndex = 71;
            this.btn_WriteUserCMD_OW.Text = "DO IT";
            this.btn_WriteUserCMD_OW.UseVisualStyleBackColor = true;
            this.btn_WriteUserCMD_OW.Click += new System.EventHandler(this.btn_WriteUserCMD_OW_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "PNUM";
            // 
            // txt_userCMD_ParamNum_OWI
            // 
            this.txt_userCMD_ParamNum_OWI.BackColor = System.Drawing.Color.White;
            this.txt_userCMD_ParamNum_OWI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userCMD_ParamNum_OWI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_userCMD_ParamNum_OWI.Location = new System.Drawing.Point(59, 101);
            this.txt_userCMD_ParamNum_OWI.Name = "txt_userCMD_ParamNum_OWI";
            this.txt_userCMD_ParamNum_OWI.Size = new System.Drawing.Size(102, 20);
            this.txt_userCMD_ParamNum_OWI.TabIndex = 69;
            this.txt_userCMD_ParamNum_OWI.Text = "00";
            this.txt_userCMD_ParamNum_OWI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "UpCount";
            // 
            // txt_userCMD_UPCount_OWI
            // 
            this.txt_userCMD_UPCount_OWI.BackColor = System.Drawing.Color.White;
            this.txt_userCMD_UPCount_OWI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userCMD_UPCount_OWI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_userCMD_UPCount_OWI.Location = new System.Drawing.Point(59, 74);
            this.txt_userCMD_UPCount_OWI.Name = "txt_userCMD_UPCount_OWI";
            this.txt_userCMD_UPCount_OWI.Size = new System.Drawing.Size(102, 20);
            this.txt_userCMD_UPCount_OWI.TabIndex = 67;
            this.txt_userCMD_UPCount_OWI.Text = "00";
            this.txt_userCMD_UPCount_OWI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "DCount";
            // 
            // txt_userCMD_DownCount_OWI
            // 
            this.txt_userCMD_DownCount_OWI.BackColor = System.Drawing.Color.White;
            this.txt_userCMD_DownCount_OWI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userCMD_DownCount_OWI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_userCMD_DownCount_OWI.Location = new System.Drawing.Point(59, 47);
            this.txt_userCMD_DownCount_OWI.Name = "txt_userCMD_DownCount_OWI";
            this.txt_userCMD_DownCount_OWI.Size = new System.Drawing.Size(102, 20);
            this.txt_userCMD_DownCount_OWI.TabIndex = 65;
            this.txt_userCMD_DownCount_OWI.Text = "00";
            this.txt_userCMD_DownCount_OWI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "CMD";
            // 
            // txt_userCMD_OWI
            // 
            this.txt_userCMD_OWI.BackColor = System.Drawing.Color.White;
            this.txt_userCMD_OWI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userCMD_OWI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_userCMD_OWI.Location = new System.Drawing.Point(59, 20);
            this.txt_userCMD_OWI.Name = "txt_userCMD_OWI";
            this.txt_userCMD_OWI.Size = new System.Drawing.Size(102, 20);
            this.txt_userCMD_OWI.TabIndex = 63;
            this.txt_userCMD_OWI.Text = "0xCB000001";
            this.txt_userCMD_OWI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_ScanTest_OW
            // 
            this.grb_ScanTest_OW.Controls.Add(this.pgb_ProcessedRate_OW);
            this.grb_ScanTest_OW.Controls.Add(this.lbl_ScanWroteNum_OW);
            this.grb_ScanTest_OW.Controls.Add(this.lbl_loadNum_OW);
            this.grb_ScanTest_OW.Controls.Add(this.txt_WroteNum_OW);
            this.grb_ScanTest_OW.Controls.Add(this.txt_loadNum_OW);
            this.grb_ScanTest_OW.Controls.Add(this.btn_startScanWrite_OW);
            this.grb_ScanTest_OW.Controls.Add(this.btn_LoadScanData_OW);
            this.grb_ScanTest_OW.Location = new System.Drawing.Point(510, 313);
            this.grb_ScanTest_OW.Name = "grb_ScanTest_OW";
            this.grb_ScanTest_OW.Size = new System.Drawing.Size(307, 123);
            this.grb_ScanTest_OW.TabIndex = 52;
            this.grb_ScanTest_OW.TabStop = false;
            this.grb_ScanTest_OW.Text = "Scan Test";
            // 
            // pgb_ProcessedRate_OW
            // 
            this.pgb_ProcessedRate_OW.Location = new System.Drawing.Point(23, 97);
            this.pgb_ProcessedRate_OW.Name = "pgb_ProcessedRate_OW";
            this.pgb_ProcessedRate_OW.Size = new System.Drawing.Size(256, 10);
            this.pgb_ProcessedRate_OW.TabIndex = 43;
            // 
            // lbl_ScanWroteNum_OW
            // 
            this.lbl_ScanWroteNum_OW.AutoSize = true;
            this.lbl_ScanWroteNum_OW.Location = new System.Drawing.Point(118, 67);
            this.lbl_ScanWroteNum_OW.Name = "lbl_ScanWroteNum_OW";
            this.lbl_ScanWroteNum_OW.Size = new System.Drawing.Size(57, 13);
            this.lbl_ScanWroteNum_OW.TabIndex = 42;
            this.lbl_ScanWroteNum_OW.Text = "Processed";
            // 
            // lbl_loadNum_OW
            // 
            this.lbl_loadNum_OW.AutoSize = true;
            this.lbl_loadNum_OW.Location = new System.Drawing.Point(118, 29);
            this.lbl_loadNum_OW.Name = "lbl_loadNum_OW";
            this.lbl_loadNum_OW.Size = new System.Drawing.Size(31, 13);
            this.lbl_loadNum_OW.TabIndex = 41;
            this.lbl_loadNum_OW.Text = "Total";
            // 
            // txt_WroteNum_OW
            // 
            this.txt_WroteNum_OW.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_WroteNum_OW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_WroteNum_OW.ForeColor = System.Drawing.Color.White;
            this.txt_WroteNum_OW.Location = new System.Drawing.Point(181, 63);
            this.txt_WroteNum_OW.Name = "txt_WroteNum_OW";
            this.txt_WroteNum_OW.ReadOnly = true;
            this.txt_WroteNum_OW.Size = new System.Drawing.Size(95, 20);
            this.txt_WroteNum_OW.TabIndex = 40;
            this.txt_WroteNum_OW.Text = "xxxxxxxxx";
            this.txt_WroteNum_OW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_loadNum_OW
            // 
            this.txt_loadNum_OW.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_loadNum_OW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loadNum_OW.ForeColor = System.Drawing.Color.White;
            this.txt_loadNum_OW.Location = new System.Drawing.Point(181, 25);
            this.txt_loadNum_OW.Name = "txt_loadNum_OW";
            this.txt_loadNum_OW.ReadOnly = true;
            this.txt_loadNum_OW.Size = new System.Drawing.Size(95, 20);
            this.txt_loadNum_OW.TabIndex = 40;
            this.txt_loadNum_OW.Text = "xxxxxxxxx";
            this.txt_loadNum_OW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_startScanWrite_OW
            // 
            this.btn_startScanWrite_OW.Location = new System.Drawing.Point(23, 57);
            this.btn_startScanWrite_OW.Name = "btn_startScanWrite_OW";
            this.btn_startScanWrite_OW.Size = new System.Drawing.Size(75, 32);
            this.btn_startScanWrite_OW.TabIndex = 1;
            this.btn_startScanWrite_OW.Text = "Write All";
            this.btn_startScanWrite_OW.UseVisualStyleBackColor = true;
            this.btn_startScanWrite_OW.Click += new System.EventHandler(this.btn_startScanWrite_OW_Click);
            // 
            // btn_LoadScanData_OW
            // 
            this.btn_LoadScanData_OW.Location = new System.Drawing.Point(23, 19);
            this.btn_LoadScanData_OW.Name = "btn_LoadScanData_OW";
            this.btn_LoadScanData_OW.Size = new System.Drawing.Size(75, 32);
            this.btn_LoadScanData_OW.TabIndex = 0;
            this.btn_LoadScanData_OW.Text = "Load";
            this.btn_LoadScanData_OW.UseVisualStyleBackColor = true;
            this.btn_LoadScanData_OW.Click += new System.EventHandler(this.btn_LoadScanData_OW_Click);
            // 
            // btn_test_ow
            // 
            this.btn_test_ow.Location = new System.Drawing.Point(298, 442);
            this.btn_test_ow.Name = "btn_test_ow";
            this.btn_test_ow.Size = new System.Drawing.Size(65, 23);
            this.btn_test_ow.TabIndex = 51;
            this.btn_test_ow.Text = "Test";
            this.btn_test_ow.UseVisualStyleBackColor = true;
            this.btn_test_ow.Visible = false;
            this.btn_test_ow.Click += new System.EventHandler(this.btn_test_ow_Click);
            // 
            // cmb_fusepulsewidth
            // 
            this.cmb_fusepulsewidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fusepulsewidth.FormattingEnabled = true;
            this.cmb_fusepulsewidth.Items.AddRange(new object[] {
            "100 ns",
            "125 ns",
            "150 ns",
            "175 ns",
            "200 ns"});
            this.cmb_fusepulsewidth.Location = new System.Drawing.Point(192, 443);
            this.cmb_fusepulsewidth.Name = "cmb_fusepulsewidth";
            this.cmb_fusepulsewidth.Size = new System.Drawing.Size(91, 21);
            this.cmb_fusepulsewidth.TabIndex = 23;
            this.cmb_fusepulsewidth.Visible = false;
            this.cmb_fusepulsewidth.SelectedIndexChanged += new System.EventHandler(this.cmb_fusepulsewidth_SelectedIndexChanged);
            // 
            // grb_FuseMode_OW
            // 
            this.grb_FuseMode_OW.Controls.Add(this.label7);
            this.grb_FuseMode_OW.Controls.Add(this.btn_fuse_action_ow);
            this.grb_FuseMode_OW.Controls.Add(this.numUD_pulsedurationtime_ow);
            this.grb_FuseMode_OW.Controls.Add(this.lbl_pulsewidth_ow);
            this.grb_FuseMode_OW.Controls.Add(this.num_UD_pulsewidth_ow);
            this.grb_FuseMode_OW.Controls.Add(this.chb_FuseModeSwitch);
            this.grb_FuseMode_OW.Controls.Add(this.lbl_pulsedurationtime_ow);
            this.grb_FuseMode_OW.Controls.Add(this.label6);
            this.grb_FuseMode_OW.Location = new System.Drawing.Point(6, 87);
            this.grb_FuseMode_OW.Name = "grb_FuseMode_OW";
            this.grb_FuseMode_OW.Size = new System.Drawing.Size(160, 125);
            this.grb_FuseMode_OW.TabIndex = 50;
            this.grb_FuseMode_OW.TabStop = false;
            this.grb_FuseMode_OW.Text = "Fuse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "ns";
            // 
            // btn_fuse_action_ow
            // 
            this.btn_fuse_action_ow.Location = new System.Drawing.Point(37, 97);
            this.btn_fuse_action_ow.Name = "btn_fuse_action_ow";
            this.btn_fuse_action_ow.Size = new System.Drawing.Size(78, 23);
            this.btn_fuse_action_ow.TabIndex = 54;
            this.btn_fuse_action_ow.Text = "Fuse";
            this.btn_fuse_action_ow.UseVisualStyleBackColor = true;
            this.btn_fuse_action_ow.Click += new System.EventHandler(this.btn_fuse_action_ow_Click);
            // 
            // numUD_pulsedurationtime_ow
            // 
            this.numUD_pulsedurationtime_ow.Location = new System.Drawing.Point(89, 71);
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
            this.numUD_pulsedurationtime_ow.Size = new System.Drawing.Size(54, 20);
            this.numUD_pulsedurationtime_ow.TabIndex = 51;
            this.numUD_pulsedurationtime_ow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_pulsedurationtime_ow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_pulsewidth_ow
            // 
            this.lbl_pulsewidth_ow.AutoSize = true;
            this.lbl_pulsewidth_ow.Location = new System.Drawing.Point(14, 51);
            this.lbl_pulsewidth_ow.Name = "lbl_pulsewidth_ow";
            this.lbl_pulsewidth_ow.Size = new System.Drawing.Size(67, 13);
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
            this.num_UD_pulsewidth_ow.Location = new System.Drawing.Point(89, 47);
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
            this.num_UD_pulsewidth_ow.Size = new System.Drawing.Size(54, 20);
            this.num_UD_pulsewidth_ow.TabIndex = 48;
            this.num_UD_pulsewidth_ow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_UD_pulsewidth_ow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_UD_pulsewidth_ow.ValueChanged += new System.EventHandler(this.num_UD_pulsewidth_ow_ValueChanged);
            // 
            // chb_FuseModeSwitch
            // 
            this.chb_FuseModeSwitch.AutoSize = true;
            this.chb_FuseModeSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_FuseModeSwitch.Location = new System.Drawing.Point(10, 18);
            this.chb_FuseModeSwitch.Name = "chb_FuseModeSwitch";
            this.chb_FuseModeSwitch.Size = new System.Drawing.Size(144, 20);
            this.chb_FuseModeSwitch.TabIndex = 0;
            this.chb_FuseModeSwitch.Text = "Enter Fuse Mode";
            this.chb_FuseModeSwitch.UseVisualStyleBackColor = true;
            this.chb_FuseModeSwitch.CheckedChanged += new System.EventHandler(this.chb_FuseModeSwitch_CheckedChanged);
            // 
            // lbl_pulsedurationtime_ow
            // 
            this.lbl_pulsedurationtime_ow.AutoSize = true;
            this.lbl_pulsedurationtime_ow.Location = new System.Drawing.Point(14, 75);
            this.lbl_pulsedurationtime_ow.Name = "lbl_pulsedurationtime_ow";
            this.lbl_pulsedurationtime_ow.Size = new System.Drawing.Size(76, 13);
            this.lbl_pulsedurationtime_ow.TabIndex = 52;
            this.lbl_pulsedurationtime_ow.Text = "Duration Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "ms";
            // 
            // rbtn_FuseClkOn
            // 
            this.rbtn_FuseClkOn.AutoSize = true;
            this.rbtn_FuseClkOn.Location = new System.Drawing.Point(378, 445);
            this.rbtn_FuseClkOn.Name = "rbtn_FuseClkOn";
            this.rbtn_FuseClkOn.Size = new System.Drawing.Size(90, 17);
            this.rbtn_FuseClkOn.TabIndex = 1;
            this.rbtn_FuseClkOn.TabStop = true;
            this.rbtn_FuseClkOn.Text = "Fuse CLK ON";
            this.rbtn_FuseClkOn.UseVisualStyleBackColor = true;
            this.rbtn_FuseClkOn.Visible = false;
            this.rbtn_FuseClkOn.CheckedChanged += new System.EventHandler(this.rbtn_FuseClkOn_CheckedChanged);
            // 
            // grb_BurstI2CRW_OW
            // 
            this.grb_BurstI2CRW_OW.Controls.Add(this.lbl_reg_data_burst_onewire);
            this.grb_BurstI2CRW_OW.Controls.Add(this.txt_reg_data_owb);
            this.grb_BurstI2CRW_OW.Controls.Add(this.btn_I2CWrite_Burst_Onewire);
            this.grb_BurstI2CRW_OW.Controls.Add(this.btn_I2CRead_Burst_Onewire);
            this.grb_BurstI2CRW_OW.Controls.Add(this.txt_reg_addr_owb);
            this.grb_BurstI2CRW_OW.Controls.Add(this.txt_I2C_rw_num_owb);
            this.grb_BurstI2CRW_OW.Controls.Add(this.lbl_rw_num_burst_onewire);
            this.grb_BurstI2CRW_OW.Controls.Add(this.lbl_reg_addr_burst_onewire);
            this.grb_BurstI2CRW_OW.Location = new System.Drawing.Point(510, 6);
            this.grb_BurstI2CRW_OW.Name = "grb_BurstI2CRW_OW";
            this.grb_BurstI2CRW_OW.Size = new System.Drawing.Size(307, 295);
            this.grb_BurstI2CRW_OW.TabIndex = 49;
            this.grb_BurstI2CRW_OW.TabStop = false;
            this.grb_BurstI2CRW_OW.Text = "Burst I2C R/W";
            // 
            // lbl_reg_data_burst_onewire
            // 
            this.lbl_reg_data_burst_onewire.AutoSize = true;
            this.lbl_reg_data_burst_onewire.Location = new System.Drawing.Point(12, 70);
            this.lbl_reg_data_burst_onewire.Name = "lbl_reg_data_burst_onewire";
            this.lbl_reg_data_burst_onewire.Size = new System.Drawing.Size(140, 13);
            this.lbl_reg_data_burst_onewire.TabIndex = 55;
            this.lbl_reg_data_burst_onewire.Text = "Data( Hex, Separate by \";\" )";
            // 
            // txt_reg_data_owb
            // 
            this.txt_reg_data_owb.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_owb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_owb.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_owb.Location = new System.Drawing.Point(15, 94);
            this.txt_reg_data_owb.Multiline = true;
            this.txt_reg_data_owb.Name = "txt_reg_data_owb";
            this.txt_reg_data_owb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_reg_data_owb.Size = new System.Drawing.Size(278, 190);
            this.txt_reg_data_owb.TabIndex = 54;
            this.txt_reg_data_owb.Text = "00;00";
            // 
            // btn_I2CWrite_Burst_Onewire
            // 
            this.btn_I2CWrite_Burst_Onewire.Location = new System.Drawing.Point(237, 39);
            this.btn_I2CWrite_Burst_Onewire.Name = "btn_I2CWrite_Burst_Onewire";
            this.btn_I2CWrite_Burst_Onewire.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Burst_Onewire.TabIndex = 53;
            this.btn_I2CWrite_Burst_Onewire.Text = "Write";
            this.btn_I2CWrite_Burst_Onewire.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Burst_Onewire.Click += new System.EventHandler(this.btn_I2CWrite_Burst_Onewire_Click);
            // 
            // btn_I2CRead_Burst_Onewire
            // 
            this.btn_I2CRead_Burst_Onewire.Location = new System.Drawing.Point(162, 39);
            this.btn_I2CRead_Burst_Onewire.Name = "btn_I2CRead_Burst_Onewire";
            this.btn_I2CRead_Burst_Onewire.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Burst_Onewire.TabIndex = 52;
            this.btn_I2CRead_Burst_Onewire.Text = "Read";
            this.btn_I2CRead_Burst_Onewire.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Burst_Onewire.Click += new System.EventHandler(this.btn_I2CRead_Burst_Onewire_Click);
            // 
            // txt_reg_addr_owb
            // 
            this.txt_reg_addr_owb.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_owb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_owb.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_owb.Location = new System.Drawing.Point(12, 40);
            this.txt_reg_addr_owb.Name = "txt_reg_addr_owb";
            this.txt_reg_addr_owb.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_owb.TabIndex = 50;
            this.txt_reg_addr_owb.Text = "00";
            this.txt_reg_addr_owb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_I2C_rw_num_owb
            // 
            this.txt_I2C_rw_num_owb.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_I2C_rw_num_owb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_I2C_rw_num_owb.ForeColor = System.Drawing.Color.White;
            this.txt_I2C_rw_num_owb.Location = new System.Drawing.Point(87, 40);
            this.txt_I2C_rw_num_owb.Name = "txt_I2C_rw_num_owb";
            this.txt_I2C_rw_num_owb.Size = new System.Drawing.Size(56, 20);
            this.txt_I2C_rw_num_owb.TabIndex = 51;
            this.txt_I2C_rw_num_owb.Text = "2";
            this.txt_I2C_rw_num_owb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_rw_num_burst_onewire
            // 
            this.lbl_rw_num_burst_onewire.AutoSize = true;
            this.lbl_rw_num_burst_onewire.Location = new System.Drawing.Point(87, 22);
            this.lbl_rw_num_burst_onewire.Name = "lbl_rw_num_burst_onewire";
            this.lbl_rw_num_burst_onewire.Size = new System.Drawing.Size(69, 13);
            this.lbl_rw_num_burst_onewire.TabIndex = 49;
            this.lbl_rw_num_burst_onewire.Text = "R/W number";
            // 
            // lbl_reg_addr_burst_onewire
            // 
            this.lbl_reg_addr_burst_onewire.AutoSize = true;
            this.lbl_reg_addr_burst_onewire.Location = new System.Drawing.Point(12, 22);
            this.lbl_reg_addr_burst_onewire.Name = "lbl_reg_addr_burst_onewire";
            this.lbl_reg_addr_burst_onewire.Size = new System.Drawing.Size(46, 13);
            this.lbl_reg_addr_burst_onewire.TabIndex = 47;
            this.lbl_reg_addr_burst_onewire.Text = "Addr( H)";
            // 
            // grb_SingleI2CRW_OW
            // 
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire12);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire12);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows12);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows12);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire11);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire11);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows11);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows11);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire10);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire10);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows10);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows10);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire9);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire9);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows9);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows9);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire8);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire8);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows8);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows8);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire7);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire7);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows7);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows7);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire6);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire6);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows6);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows6);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire5);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire5);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows5);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows5);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire4);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire4);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows4);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows4);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire3);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire3);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows3);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows3);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire2);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire2);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows2);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows2);
            this.grb_SingleI2CRW_OW.Controls.Add(this.lbl_reg_data_single_onewire);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CWrite_Single_Onewire1);
            this.grb_SingleI2CRW_OW.Controls.Add(this.btn_I2CRead_Single_Onewire1);
            this.grb_SingleI2CRW_OW.Controls.Add(this.lbl_reg_addr_single_onewire);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_addr_ows1);
            this.grb_SingleI2CRW_OW.Controls.Add(this.txt_reg_data_ows1);
            this.grb_SingleI2CRW_OW.Location = new System.Drawing.Point(191, 6);
            this.grb_SingleI2CRW_OW.Name = "grb_SingleI2CRW_OW";
            this.grb_SingleI2CRW_OW.Size = new System.Drawing.Size(302, 430);
            this.grb_SingleI2CRW_OW.TabIndex = 48;
            this.grb_SingleI2CRW_OW.TabStop = false;
            this.grb_SingleI2CRW_OW.Text = "Single I2C R/W";
            // 
            // btn_I2CWrite_Single_Onewire12
            // 
            this.btn_I2CWrite_Single_Onewire12.Location = new System.Drawing.Point(234, 391);
            this.btn_I2CWrite_Single_Onewire12.Name = "btn_I2CWrite_Single_Onewire12";
            this.btn_I2CWrite_Single_Onewire12.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire12.TabIndex = 93;
            this.btn_I2CWrite_Single_Onewire12.Text = "Write";
            this.btn_I2CWrite_Single_Onewire12.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire12.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire12_Click);
            // 
            // btn_I2CRead_Single_Onewire12
            // 
            this.btn_I2CRead_Single_Onewire12.Location = new System.Drawing.Point(159, 391);
            this.btn_I2CRead_Single_Onewire12.Name = "btn_I2CRead_Single_Onewire12";
            this.btn_I2CRead_Single_Onewire12.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire12.TabIndex = 92;
            this.btn_I2CRead_Single_Onewire12.Text = "Read";
            this.btn_I2CRead_Single_Onewire12.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire12.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire12_Click);
            // 
            // txt_reg_addr_ows12
            // 
            this.txt_reg_addr_ows12.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows12.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows12.Location = new System.Drawing.Point(9, 392);
            this.txt_reg_addr_ows12.Name = "txt_reg_addr_ows12";
            this.txt_reg_addr_ows12.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows12.TabIndex = 90;
            this.txt_reg_addr_ows12.Text = "0B";
            this.txt_reg_addr_ows12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows12
            // 
            this.txt_reg_data_ows12.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows12.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows12.Location = new System.Drawing.Point(84, 392);
            this.txt_reg_data_ows12.Name = "txt_reg_data_ows12";
            this.txt_reg_data_ows12.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows12.TabIndex = 91;
            this.txt_reg_data_ows12.Text = "00";
            this.txt_reg_data_ows12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire11
            // 
            this.btn_I2CWrite_Single_Onewire11.Location = new System.Drawing.Point(234, 359);
            this.btn_I2CWrite_Single_Onewire11.Name = "btn_I2CWrite_Single_Onewire11";
            this.btn_I2CWrite_Single_Onewire11.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire11.TabIndex = 89;
            this.btn_I2CWrite_Single_Onewire11.Text = "Write";
            this.btn_I2CWrite_Single_Onewire11.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire11.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire11_Click);
            // 
            // btn_I2CRead_Single_Onewire11
            // 
            this.btn_I2CRead_Single_Onewire11.Location = new System.Drawing.Point(159, 359);
            this.btn_I2CRead_Single_Onewire11.Name = "btn_I2CRead_Single_Onewire11";
            this.btn_I2CRead_Single_Onewire11.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire11.TabIndex = 88;
            this.btn_I2CRead_Single_Onewire11.Text = "Read";
            this.btn_I2CRead_Single_Onewire11.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire11.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire11_Click);
            // 
            // txt_reg_addr_ows11
            // 
            this.txt_reg_addr_ows11.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows11.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows11.Location = new System.Drawing.Point(9, 360);
            this.txt_reg_addr_ows11.Name = "txt_reg_addr_ows11";
            this.txt_reg_addr_ows11.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows11.TabIndex = 86;
            this.txt_reg_addr_ows11.Text = "0A";
            this.txt_reg_addr_ows11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows11
            // 
            this.txt_reg_data_ows11.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows11.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows11.Location = new System.Drawing.Point(84, 360);
            this.txt_reg_data_ows11.Name = "txt_reg_data_ows11";
            this.txt_reg_data_ows11.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows11.TabIndex = 87;
            this.txt_reg_data_ows11.Text = "00";
            this.txt_reg_data_ows11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire10
            // 
            this.btn_I2CWrite_Single_Onewire10.Location = new System.Drawing.Point(234, 327);
            this.btn_I2CWrite_Single_Onewire10.Name = "btn_I2CWrite_Single_Onewire10";
            this.btn_I2CWrite_Single_Onewire10.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire10.TabIndex = 85;
            this.btn_I2CWrite_Single_Onewire10.Text = "Write";
            this.btn_I2CWrite_Single_Onewire10.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire10.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire10_Click);
            // 
            // btn_I2CRead_Single_Onewire10
            // 
            this.btn_I2CRead_Single_Onewire10.Location = new System.Drawing.Point(159, 327);
            this.btn_I2CRead_Single_Onewire10.Name = "btn_I2CRead_Single_Onewire10";
            this.btn_I2CRead_Single_Onewire10.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire10.TabIndex = 84;
            this.btn_I2CRead_Single_Onewire10.Text = "Read";
            this.btn_I2CRead_Single_Onewire10.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire10.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire10_Click);
            // 
            // txt_reg_addr_ows10
            // 
            this.txt_reg_addr_ows10.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows10.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows10.Location = new System.Drawing.Point(9, 328);
            this.txt_reg_addr_ows10.Name = "txt_reg_addr_ows10";
            this.txt_reg_addr_ows10.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows10.TabIndex = 82;
            this.txt_reg_addr_ows10.Text = "09";
            this.txt_reg_addr_ows10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows10
            // 
            this.txt_reg_data_ows10.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows10.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows10.Location = new System.Drawing.Point(84, 328);
            this.txt_reg_data_ows10.Name = "txt_reg_data_ows10";
            this.txt_reg_data_ows10.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows10.TabIndex = 83;
            this.txt_reg_data_ows10.Text = "00";
            this.txt_reg_data_ows10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire9
            // 
            this.btn_I2CWrite_Single_Onewire9.Location = new System.Drawing.Point(234, 295);
            this.btn_I2CWrite_Single_Onewire9.Name = "btn_I2CWrite_Single_Onewire9";
            this.btn_I2CWrite_Single_Onewire9.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire9.TabIndex = 81;
            this.btn_I2CWrite_Single_Onewire9.Text = "Write";
            this.btn_I2CWrite_Single_Onewire9.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire9.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire9_Click);
            // 
            // btn_I2CRead_Single_Onewire9
            // 
            this.btn_I2CRead_Single_Onewire9.Location = new System.Drawing.Point(159, 295);
            this.btn_I2CRead_Single_Onewire9.Name = "btn_I2CRead_Single_Onewire9";
            this.btn_I2CRead_Single_Onewire9.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire9.TabIndex = 80;
            this.btn_I2CRead_Single_Onewire9.Text = "Read";
            this.btn_I2CRead_Single_Onewire9.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire9.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire9_Click);
            // 
            // txt_reg_addr_ows9
            // 
            this.txt_reg_addr_ows9.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows9.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows9.Location = new System.Drawing.Point(9, 296);
            this.txt_reg_addr_ows9.Name = "txt_reg_addr_ows9";
            this.txt_reg_addr_ows9.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows9.TabIndex = 78;
            this.txt_reg_addr_ows9.Text = "08";
            this.txt_reg_addr_ows9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows9
            // 
            this.txt_reg_data_ows9.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows9.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows9.Location = new System.Drawing.Point(84, 296);
            this.txt_reg_data_ows9.Name = "txt_reg_data_ows9";
            this.txt_reg_data_ows9.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows9.TabIndex = 79;
            this.txt_reg_data_ows9.Text = "00";
            this.txt_reg_data_ows9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire8
            // 
            this.btn_I2CWrite_Single_Onewire8.Location = new System.Drawing.Point(234, 263);
            this.btn_I2CWrite_Single_Onewire8.Name = "btn_I2CWrite_Single_Onewire8";
            this.btn_I2CWrite_Single_Onewire8.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire8.TabIndex = 77;
            this.btn_I2CWrite_Single_Onewire8.Text = "Write";
            this.btn_I2CWrite_Single_Onewire8.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire8.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire8_Click);
            // 
            // btn_I2CRead_Single_Onewire8
            // 
            this.btn_I2CRead_Single_Onewire8.Location = new System.Drawing.Point(159, 263);
            this.btn_I2CRead_Single_Onewire8.Name = "btn_I2CRead_Single_Onewire8";
            this.btn_I2CRead_Single_Onewire8.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire8.TabIndex = 76;
            this.btn_I2CRead_Single_Onewire8.Text = "Read";
            this.btn_I2CRead_Single_Onewire8.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire8.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire8_Click);
            // 
            // txt_reg_addr_ows8
            // 
            this.txt_reg_addr_ows8.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows8.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows8.Location = new System.Drawing.Point(9, 264);
            this.txt_reg_addr_ows8.Name = "txt_reg_addr_ows8";
            this.txt_reg_addr_ows8.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows8.TabIndex = 74;
            this.txt_reg_addr_ows8.Text = "07";
            this.txt_reg_addr_ows8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows8
            // 
            this.txt_reg_data_ows8.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows8.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows8.Location = new System.Drawing.Point(84, 264);
            this.txt_reg_data_ows8.Name = "txt_reg_data_ows8";
            this.txt_reg_data_ows8.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows8.TabIndex = 75;
            this.txt_reg_data_ows8.Text = "00";
            this.txt_reg_data_ows8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire7
            // 
            this.btn_I2CWrite_Single_Onewire7.Location = new System.Drawing.Point(234, 231);
            this.btn_I2CWrite_Single_Onewire7.Name = "btn_I2CWrite_Single_Onewire7";
            this.btn_I2CWrite_Single_Onewire7.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire7.TabIndex = 73;
            this.btn_I2CWrite_Single_Onewire7.Text = "Write";
            this.btn_I2CWrite_Single_Onewire7.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire7.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire7_Click);
            // 
            // btn_I2CRead_Single_Onewire7
            // 
            this.btn_I2CRead_Single_Onewire7.Location = new System.Drawing.Point(159, 231);
            this.btn_I2CRead_Single_Onewire7.Name = "btn_I2CRead_Single_Onewire7";
            this.btn_I2CRead_Single_Onewire7.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire7.TabIndex = 72;
            this.btn_I2CRead_Single_Onewire7.Text = "Read";
            this.btn_I2CRead_Single_Onewire7.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire7.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire7_Click);
            // 
            // txt_reg_addr_ows7
            // 
            this.txt_reg_addr_ows7.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows7.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows7.Location = new System.Drawing.Point(9, 232);
            this.txt_reg_addr_ows7.Name = "txt_reg_addr_ows7";
            this.txt_reg_addr_ows7.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows7.TabIndex = 70;
            this.txt_reg_addr_ows7.Text = "06";
            this.txt_reg_addr_ows7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows7
            // 
            this.txt_reg_data_ows7.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows7.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows7.Location = new System.Drawing.Point(84, 232);
            this.txt_reg_data_ows7.Name = "txt_reg_data_ows7";
            this.txt_reg_data_ows7.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows7.TabIndex = 71;
            this.txt_reg_data_ows7.Text = "00";
            this.txt_reg_data_ows7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire6
            // 
            this.btn_I2CWrite_Single_Onewire6.Location = new System.Drawing.Point(234, 199);
            this.btn_I2CWrite_Single_Onewire6.Name = "btn_I2CWrite_Single_Onewire6";
            this.btn_I2CWrite_Single_Onewire6.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire6.TabIndex = 69;
            this.btn_I2CWrite_Single_Onewire6.Text = "Write";
            this.btn_I2CWrite_Single_Onewire6.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire6.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire6_Click);
            // 
            // btn_I2CRead_Single_Onewire6
            // 
            this.btn_I2CRead_Single_Onewire6.Location = new System.Drawing.Point(159, 199);
            this.btn_I2CRead_Single_Onewire6.Name = "btn_I2CRead_Single_Onewire6";
            this.btn_I2CRead_Single_Onewire6.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire6.TabIndex = 68;
            this.btn_I2CRead_Single_Onewire6.Text = "Read";
            this.btn_I2CRead_Single_Onewire6.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire6.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire6_Click);
            // 
            // txt_reg_addr_ows6
            // 
            this.txt_reg_addr_ows6.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows6.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows6.Location = new System.Drawing.Point(9, 200);
            this.txt_reg_addr_ows6.Name = "txt_reg_addr_ows6";
            this.txt_reg_addr_ows6.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows6.TabIndex = 66;
            this.txt_reg_addr_ows6.Text = "05";
            this.txt_reg_addr_ows6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows6
            // 
            this.txt_reg_data_ows6.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows6.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows6.Location = new System.Drawing.Point(84, 200);
            this.txt_reg_data_ows6.Name = "txt_reg_data_ows6";
            this.txt_reg_data_ows6.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows6.TabIndex = 67;
            this.txt_reg_data_ows6.Text = "00";
            this.txt_reg_data_ows6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire5
            // 
            this.btn_I2CWrite_Single_Onewire5.Location = new System.Drawing.Point(234, 167);
            this.btn_I2CWrite_Single_Onewire5.Name = "btn_I2CWrite_Single_Onewire5";
            this.btn_I2CWrite_Single_Onewire5.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire5.TabIndex = 65;
            this.btn_I2CWrite_Single_Onewire5.Text = "Write";
            this.btn_I2CWrite_Single_Onewire5.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire5.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire5_Click);
            // 
            // btn_I2CRead_Single_Onewire5
            // 
            this.btn_I2CRead_Single_Onewire5.Location = new System.Drawing.Point(159, 167);
            this.btn_I2CRead_Single_Onewire5.Name = "btn_I2CRead_Single_Onewire5";
            this.btn_I2CRead_Single_Onewire5.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire5.TabIndex = 64;
            this.btn_I2CRead_Single_Onewire5.Text = "Read";
            this.btn_I2CRead_Single_Onewire5.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire5.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire5_Click);
            // 
            // txt_reg_addr_ows5
            // 
            this.txt_reg_addr_ows5.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows5.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows5.Location = new System.Drawing.Point(9, 168);
            this.txt_reg_addr_ows5.Name = "txt_reg_addr_ows5";
            this.txt_reg_addr_ows5.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows5.TabIndex = 62;
            this.txt_reg_addr_ows5.Text = "04";
            this.txt_reg_addr_ows5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows5
            // 
            this.txt_reg_data_ows5.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows5.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows5.Location = new System.Drawing.Point(84, 168);
            this.txt_reg_data_ows5.Name = "txt_reg_data_ows5";
            this.txt_reg_data_ows5.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows5.TabIndex = 63;
            this.txt_reg_data_ows5.Text = "00";
            this.txt_reg_data_ows5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire4
            // 
            this.btn_I2CWrite_Single_Onewire4.Location = new System.Drawing.Point(234, 135);
            this.btn_I2CWrite_Single_Onewire4.Name = "btn_I2CWrite_Single_Onewire4";
            this.btn_I2CWrite_Single_Onewire4.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire4.TabIndex = 61;
            this.btn_I2CWrite_Single_Onewire4.Text = "Write";
            this.btn_I2CWrite_Single_Onewire4.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire4.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire4_Click);
            // 
            // btn_I2CRead_Single_Onewire4
            // 
            this.btn_I2CRead_Single_Onewire4.Location = new System.Drawing.Point(159, 135);
            this.btn_I2CRead_Single_Onewire4.Name = "btn_I2CRead_Single_Onewire4";
            this.btn_I2CRead_Single_Onewire4.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire4.TabIndex = 60;
            this.btn_I2CRead_Single_Onewire4.Text = "Read";
            this.btn_I2CRead_Single_Onewire4.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire4.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire4_Click);
            // 
            // txt_reg_addr_ows4
            // 
            this.txt_reg_addr_ows4.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows4.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows4.Location = new System.Drawing.Point(9, 136);
            this.txt_reg_addr_ows4.Name = "txt_reg_addr_ows4";
            this.txt_reg_addr_ows4.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows4.TabIndex = 58;
            this.txt_reg_addr_ows4.Text = "03";
            this.txt_reg_addr_ows4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows4
            // 
            this.txt_reg_data_ows4.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows4.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows4.Location = new System.Drawing.Point(84, 136);
            this.txt_reg_data_ows4.Name = "txt_reg_data_ows4";
            this.txt_reg_data_ows4.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows4.TabIndex = 59;
            this.txt_reg_data_ows4.Text = "00";
            this.txt_reg_data_ows4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire3
            // 
            this.btn_I2CWrite_Single_Onewire3.Location = new System.Drawing.Point(234, 103);
            this.btn_I2CWrite_Single_Onewire3.Name = "btn_I2CWrite_Single_Onewire3";
            this.btn_I2CWrite_Single_Onewire3.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire3.TabIndex = 57;
            this.btn_I2CWrite_Single_Onewire3.Text = "Write";
            this.btn_I2CWrite_Single_Onewire3.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire3.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire3_Click);
            // 
            // btn_I2CRead_Single_Onewire3
            // 
            this.btn_I2CRead_Single_Onewire3.Location = new System.Drawing.Point(159, 103);
            this.btn_I2CRead_Single_Onewire3.Name = "btn_I2CRead_Single_Onewire3";
            this.btn_I2CRead_Single_Onewire3.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire3.TabIndex = 56;
            this.btn_I2CRead_Single_Onewire3.Text = "Read";
            this.btn_I2CRead_Single_Onewire3.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire3.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire3_Click);
            // 
            // txt_reg_addr_ows3
            // 
            this.txt_reg_addr_ows3.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows3.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows3.Location = new System.Drawing.Point(9, 104);
            this.txt_reg_addr_ows3.Name = "txt_reg_addr_ows3";
            this.txt_reg_addr_ows3.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows3.TabIndex = 54;
            this.txt_reg_addr_ows3.Text = "02";
            this.txt_reg_addr_ows3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows3
            // 
            this.txt_reg_data_ows3.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows3.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows3.Location = new System.Drawing.Point(84, 104);
            this.txt_reg_data_ows3.Name = "txt_reg_data_ows3";
            this.txt_reg_data_ows3.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows3.TabIndex = 55;
            this.txt_reg_data_ows3.Text = "00";
            this.txt_reg_data_ows3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_I2CWrite_Single_Onewire2
            // 
            this.btn_I2CWrite_Single_Onewire2.Location = new System.Drawing.Point(234, 71);
            this.btn_I2CWrite_Single_Onewire2.Name = "btn_I2CWrite_Single_Onewire2";
            this.btn_I2CWrite_Single_Onewire2.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire2.TabIndex = 53;
            this.btn_I2CWrite_Single_Onewire2.Text = "Write";
            this.btn_I2CWrite_Single_Onewire2.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire2.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire2_Click);
            // 
            // btn_I2CRead_Single_Onewire2
            // 
            this.btn_I2CRead_Single_Onewire2.Location = new System.Drawing.Point(159, 71);
            this.btn_I2CRead_Single_Onewire2.Name = "btn_I2CRead_Single_Onewire2";
            this.btn_I2CRead_Single_Onewire2.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire2.TabIndex = 52;
            this.btn_I2CRead_Single_Onewire2.Text = "Read";
            this.btn_I2CRead_Single_Onewire2.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire2.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire2_Click);
            // 
            // txt_reg_addr_ows2
            // 
            this.txt_reg_addr_ows2.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows2.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows2.Location = new System.Drawing.Point(9, 72);
            this.txt_reg_addr_ows2.Name = "txt_reg_addr_ows2";
            this.txt_reg_addr_ows2.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows2.TabIndex = 50;
            this.txt_reg_addr_ows2.Text = "01";
            this.txt_reg_addr_ows2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows2
            // 
            this.txt_reg_data_ows2.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows2.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows2.Location = new System.Drawing.Point(84, 72);
            this.txt_reg_data_ows2.Name = "txt_reg_data_ows2";
            this.txt_reg_data_ows2.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows2.TabIndex = 51;
            this.txt_reg_data_ows2.Text = "00";
            this.txt_reg_data_ows2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_reg_data_single_onewire
            // 
            this.lbl_reg_data_single_onewire.AutoSize = true;
            this.lbl_reg_data_single_onewire.Location = new System.Drawing.Point(85, 22);
            this.lbl_reg_data_single_onewire.Name = "lbl_reg_data_single_onewire";
            this.lbl_reg_data_single_onewire.Size = new System.Drawing.Size(47, 13);
            this.lbl_reg_data_single_onewire.TabIndex = 49;
            this.lbl_reg_data_single_onewire.Text = "Data( H)";
            // 
            // btn_I2CWrite_Single_Onewire1
            // 
            this.btn_I2CWrite_Single_Onewire1.Location = new System.Drawing.Point(234, 39);
            this.btn_I2CWrite_Single_Onewire1.Name = "btn_I2CWrite_Single_Onewire1";
            this.btn_I2CWrite_Single_Onewire1.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CWrite_Single_Onewire1.TabIndex = 48;
            this.btn_I2CWrite_Single_Onewire1.Text = "Write";
            this.btn_I2CWrite_Single_Onewire1.UseVisualStyleBackColor = true;
            this.btn_I2CWrite_Single_Onewire1.Click += new System.EventHandler(this.btn_I2CWrite_Single_Onewire1_Click);
            // 
            // btn_I2CRead_Single_Onewire1
            // 
            this.btn_I2CRead_Single_Onewire1.Location = new System.Drawing.Point(159, 39);
            this.btn_I2CRead_Single_Onewire1.Name = "btn_I2CRead_Single_Onewire1";
            this.btn_I2CRead_Single_Onewire1.Size = new System.Drawing.Size(56, 23);
            this.btn_I2CRead_Single_Onewire1.TabIndex = 47;
            this.btn_I2CRead_Single_Onewire1.Text = "Read";
            this.btn_I2CRead_Single_Onewire1.UseVisualStyleBackColor = true;
            this.btn_I2CRead_Single_Onewire1.Click += new System.EventHandler(this.btn_I2CRead_Single_Onewire1_Click);
            // 
            // lbl_reg_addr_single_onewire
            // 
            this.lbl_reg_addr_single_onewire.AutoSize = true;
            this.lbl_reg_addr_single_onewire.Location = new System.Drawing.Point(10, 22);
            this.lbl_reg_addr_single_onewire.Name = "lbl_reg_addr_single_onewire";
            this.lbl_reg_addr_single_onewire.Size = new System.Drawing.Size(46, 13);
            this.lbl_reg_addr_single_onewire.TabIndex = 46;
            this.lbl_reg_addr_single_onewire.Text = "Addr( H)";
            // 
            // txt_reg_addr_ows1
            // 
            this.txt_reg_addr_ows1.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_addr_ows1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_addr_ows1.ForeColor = System.Drawing.Color.White;
            this.txt_reg_addr_ows1.Location = new System.Drawing.Point(9, 40);
            this.txt_reg_addr_ows1.Name = "txt_reg_addr_ows1";
            this.txt_reg_addr_ows1.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_addr_ows1.TabIndex = 39;
            this.txt_reg_addr_ows1.Text = "00";
            this.txt_reg_addr_ows1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reg_data_ows1
            // 
            this.txt_reg_data_ows1.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_reg_data_ows1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reg_data_ows1.ForeColor = System.Drawing.Color.White;
            this.txt_reg_data_ows1.Location = new System.Drawing.Point(84, 40);
            this.txt_reg_data_ows1.Name = "txt_reg_data_ows1";
            this.txt_reg_data_ows1.Size = new System.Drawing.Size(56, 20);
            this.txt_reg_data_ows1.TabIndex = 40;
            this.txt_reg_data_ows1.Text = "00";
            this.txt_reg_data_ows1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_devInfo_ow
            // 
            this.grb_devInfo_ow.Controls.Add(this.label8);
            this.grb_devInfo_ow.Controls.Add(this.numUD_pilotwidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.lbl_pilotwidth_ow);
            this.grb_devInfo_ow.Controls.Add(this.txt_dev_addr_onewire);
            this.grb_devInfo_ow.Controls.Add(this.lbl_devAddr_onewire);
            this.grb_devInfo_ow.Location = new System.Drawing.Point(6, 6);
            this.grb_devInfo_ow.Name = "grb_devInfo_ow";
            this.grb_devInfo_ow.Size = new System.Drawing.Size(160, 81);
            this.grb_devInfo_ow.TabIndex = 47;
            this.grb_devInfo_ow.TabStop = false;
            this.grb_devInfo_ow.Text = "Device Setting";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "ns";
            // 
            // numUD_pilotwidth_ow
            // 
            this.numUD_pilotwidth_ow.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.Location = new System.Drawing.Point(85, 19);
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
            4000,
            0,
            0,
            0});
            this.numUD_pilotwidth_ow.ValueChanged += new System.EventHandler(this.numUD_pilotwidth_ow_ValueChanged);
            // 
            // lbl_pilotwidth_ow
            // 
            this.lbl_pilotwidth_ow.AutoSize = true;
            this.lbl_pilotwidth_ow.Location = new System.Drawing.Point(14, 23);
            this.lbl_pilotwidth_ow.Name = "lbl_pilotwidth_ow";
            this.lbl_pilotwidth_ow.Size = new System.Drawing.Size(61, 13);
            this.lbl_pilotwidth_ow.TabIndex = 46;
            this.lbl_pilotwidth_ow.Text = "Pilot Width:";
            // 
            // txt_dev_addr_onewire
            // 
            this.txt_dev_addr_onewire.BackColor = System.Drawing.Color.CadetBlue;
            this.txt_dev_addr_onewire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dev_addr_onewire.ForeColor = System.Drawing.Color.White;
            this.txt_dev_addr_onewire.Location = new System.Drawing.Point(83, 50);
            this.txt_dev_addr_onewire.Name = "txt_dev_addr_onewire";
            this.txt_dev_addr_onewire.Size = new System.Drawing.Size(56, 20);
            this.txt_dev_addr_onewire.TabIndex = 45;
            this.txt_dev_addr_onewire.Text = "0x54";
            this.txt_dev_addr_onewire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_devAddr_onewire
            // 
            this.lbl_devAddr_onewire.AutoSize = true;
            this.lbl_devAddr_onewire.Location = new System.Drawing.Point(14, 54);
            this.lbl_devAddr_onewire.Name = "lbl_devAddr_onewire";
            this.lbl_devAddr_onewire.Size = new System.Drawing.Size(55, 13);
            this.lbl_devAddr_onewire.TabIndex = 44;
            this.lbl_devAddr_onewire.Text = "Dev Addr:";
            // 
            // lbl_FW_onewire
            // 
            this.lbl_FW_onewire.AutoSize = true;
            this.lbl_FW_onewire.Location = new System.Drawing.Point(7, 252);
            this.lbl_FW_onewire.Name = "lbl_FW_onewire";
            this.lbl_FW_onewire.Size = new System.Drawing.Size(65, 13);
            this.lbl_FW_onewire.TabIndex = 43;
            this.lbl_FW_onewire.Text = "FW Version:";
            // 
            // btn_flash_onewire
            // 
            this.btn_flash_onewire.Location = new System.Drawing.Point(99, 225);
            this.btn_flash_onewire.Name = "btn_flash_onewire";
            this.btn_flash_onewire.Size = new System.Drawing.Size(90, 23);
            this.btn_flash_onewire.TabIndex = 41;
            this.btn_flash_onewire.Text = "Flash LED";
            this.btn_flash_onewire.UseVisualStyleBackColor = true;
            this.btn_flash_onewire.Click += new System.EventHandler(this.btn_flash_onewire_Click);
            // 
            // btn_GetFW_OneWire
            // 
            this.btn_GetFW_OneWire.Location = new System.Drawing.Point(4, 225);
            this.btn_GetFW_OneWire.Name = "btn_GetFW_OneWire";
            this.btn_GetFW_OneWire.Size = new System.Drawing.Size(90, 23);
            this.btn_GetFW_OneWire.TabIndex = 42;
            this.btn_GetFW_OneWire.Text = "Get FW Version";
            this.btn_GetFW_OneWire.UseVisualStyleBackColor = true;
            this.btn_GetFW_OneWire.Click += new System.EventHandler(this.btn_GetFW_OneWire_Click);
            // 
            // rbtn_FuseClkOff
            // 
            this.rbtn_FuseClkOff.AutoSize = true;
            this.rbtn_FuseClkOff.Checked = true;
            this.rbtn_FuseClkOff.Location = new System.Drawing.Point(483, 445);
            this.rbtn_FuseClkOff.Name = "rbtn_FuseClkOff";
            this.rbtn_FuseClkOff.Size = new System.Drawing.Size(94, 17);
            this.rbtn_FuseClkOff.TabIndex = 2;
            this.rbtn_FuseClkOff.TabStop = true;
            this.rbtn_FuseClkOff.Text = "Fuse CLK OFF";
            this.rbtn_FuseClkOff.UseVisualStyleBackColor = true;
            this.rbtn_FuseClkOff.Visible = false;
            // 
            // tabPage_ADMP521
            // 
            this.tabPage_ADMP521.Controls.Add(this.btn_testReadSize);
            this.tabPage_ADMP521.Controls.Add(this.label5);
            this.tabPage_ADMP521.Controls.Add(this.txt_i2cWriteVal);
            this.tabPage_ADMP521.Controls.Add(this.label4);
            this.tabPage_ADMP521.Controls.Add(this.txt_i2cRead);
            this.tabPage_ADMP521.Controls.Add(this.txt_i2cWriteAdd);
            this.tabPage_ADMP521.Controls.Add(this.btn_TestMode);
            this.tabPage_ADMP521.Controls.Add(this.chb_clkSetting);
            this.tabPage_ADMP521.Controls.Add(this.chb_postTrim);
            this.tabPage_ADMP521.Controls.Add(this.numUD_fuseClk);
            this.tabPage_ADMP521.Controls.Add(this.btn_normalMode);
            this.tabPage_ADMP521.Controls.Add(this.btn_NormalTest);
            this.tabPage_ADMP521.Controls.Add(this.btn_fuseOperation);
            this.tabPage_ADMP521.Controls.Add(this.btn_initMode);
            this.tabPage_ADMP521.Controls.Add(this.btn_enterFuseMode);
            this.tabPage_ADMP521.Controls.Add(this.chb_TestBool);
            this.tabPage_ADMP521.Controls.Add(this.chb_SetLR);
            this.tabPage_ADMP521.Controls.Add(this.btn_ContinuousRecord);
            this.tabPage_ADMP521.Controls.Add(this.btn_I2CWrite);
            this.tabPage_ADMP521.Controls.Add(this.btn_TestI2CRead);
            this.tabPage_ADMP521.Controls.Add(this.lbl_PDMBaseData);
            this.tabPage_ADMP521.Controls.Add(this.txt_PDMBaseData);
            this.tabPage_ADMP521.Controls.Add(this.grb_Tools);
            this.tabPage_ADMP521.Controls.Add(this.pgb_PDMreceive);
            this.tabPage_ADMP521.Controls.Add(this.lbl_num_8kwillRead);
            this.tabPage_ADMP521.Controls.Add(this.grb_521Test);
            this.tabPage_ADMP521.Controls.Add(this.numUD_num8K);
            this.tabPage_ADMP521.Controls.Add(this.btn_PDMStop);
            this.tabPage_ADMP521.Controls.Add(this.btn_PDMStart);
            this.tabPage_ADMP521.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ADMP521.Name = "tabPage_ADMP521";
            this.tabPage_ADMP521.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ADMP521.Size = new System.Drawing.Size(823, 503);
            this.tabPage_ADMP521.TabIndex = 1;
            this.tabPage_ADMP521.Text = "ADMP521";
            this.tabPage_ADMP521.UseVisualStyleBackColor = true;
            // 
            // btn_testReadSize
            // 
            this.btn_testReadSize.AutoSize = true;
            this.btn_testReadSize.Location = new System.Drawing.Point(649, 104);
            this.btn_testReadSize.Name = "btn_testReadSize";
            this.btn_testReadSize.Size = new System.Drawing.Size(84, 23);
            this.btn_testReadSize.TabIndex = 40;
            this.btn_testReadSize.Text = "TestReadSize";
            this.btn_testReadSize.UseVisualStyleBackColor = true;
            this.btn_testReadSize.Click += new System.EventHandler(this.btn_testReadSize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Value";
            // 
            // txt_i2cWriteVal
            // 
            this.txt_i2cWriteVal.Location = new System.Drawing.Point(457, 207);
            this.txt_i2cWriteVal.Name = "txt_i2cWriteVal";
            this.txt_i2cWriteVal.Size = new System.Drawing.Size(56, 20);
            this.txt_i2cWriteVal.TabIndex = 38;
            this.txt_i2cWriteVal.Text = "00";
            this.txt_i2cWriteVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Address";
            // 
            // txt_i2cRead
            // 
            this.txt_i2cRead.Location = new System.Drawing.Point(362, 237);
            this.txt_i2cRead.Multiline = true;
            this.txt_i2cRead.Name = "txt_i2cRead";
            this.txt_i2cRead.Size = new System.Drawing.Size(266, 45);
            this.txt_i2cRead.TabIndex = 38;
            this.txt_i2cRead.Text = "-1";
            // 
            // txt_i2cWriteAdd
            // 
            this.txt_i2cWriteAdd.Location = new System.Drawing.Point(362, 207);
            this.txt_i2cWriteAdd.Name = "txt_i2cWriteAdd";
            this.txt_i2cWriteAdd.Size = new System.Drawing.Size(56, 20);
            this.txt_i2cWriteAdd.TabIndex = 38;
            this.txt_i2cWriteAdd.Text = "0xF0";
            this.txt_i2cWriteAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_TestMode
            // 
            this.btn_TestMode.Location = new System.Drawing.Point(283, 139);
            this.btn_TestMode.Name = "btn_TestMode";
            this.btn_TestMode.Size = new System.Drawing.Size(75, 23);
            this.btn_TestMode.TabIndex = 37;
            this.btn_TestMode.Text = "Test Mode";
            this.btn_TestMode.UseVisualStyleBackColor = true;
            this.btn_TestMode.Click += new System.EventHandler(this.btn_TestMode_Click);
            // 
            // chb_clkSetting
            // 
            this.chb_clkSetting.AutoSize = true;
            this.chb_clkSetting.Location = new System.Drawing.Point(260, 33);
            this.chb_clkSetting.Name = "chb_clkSetting";
            this.chb_clkSetting.Size = new System.Drawing.Size(69, 17);
            this.chb_clkSetting.TabIndex = 36;
            this.chb_clkSetting.Text = "CLK OFF";
            this.chb_clkSetting.UseVisualStyleBackColor = true;
            this.chb_clkSetting.CheckedChanged += new System.EventHandler(this.chb_clkSetting_CheckedChanged);
            // 
            // chb_postTrim
            // 
            this.chb_postTrim.AutoSize = true;
            this.chb_postTrim.Location = new System.Drawing.Point(260, 58);
            this.chb_postTrim.Name = "chb_postTrim";
            this.chb_postTrim.Size = new System.Drawing.Size(67, 17);
            this.chb_postTrim.TabIndex = 35;
            this.chb_postTrim.Text = "PostTrim";
            this.chb_postTrim.UseVisualStyleBackColor = true;
            this.chb_postTrim.CheckedChanged += new System.EventHandler(this.chb_postTrim_CheckedChanged);
            // 
            // numUD_fuseClk
            // 
            this.numUD_fuseClk.Location = new System.Drawing.Point(362, 86);
            this.numUD_fuseClk.Maximum = new decimal(new int[] {
            41943040,
            0,
            0,
            0});
            this.numUD_fuseClk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_fuseClk.Name = "numUD_fuseClk";
            this.numUD_fuseClk.Size = new System.Drawing.Size(75, 20);
            this.numUD_fuseClk.TabIndex = 34;
            this.numUD_fuseClk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_fuseClk.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btn_normalMode
            // 
            this.btn_normalMode.Location = new System.Drawing.Point(282, 78);
            this.btn_normalMode.Name = "btn_normalMode";
            this.btn_normalMode.Size = new System.Drawing.Size(75, 23);
            this.btn_normalMode.TabIndex = 33;
            this.btn_normalMode.Text = "Normal";
            this.btn_normalMode.UseVisualStyleBackColor = true;
            this.btn_normalMode.Click += new System.EventHandler(this.btn_normalMode_Click);
            // 
            // btn_NormalTest
            // 
            this.btn_NormalTest.Location = new System.Drawing.Point(283, 109);
            this.btn_NormalTest.Name = "btn_NormalTest";
            this.btn_NormalTest.Size = new System.Drawing.Size(75, 23);
            this.btn_NormalTest.TabIndex = 33;
            this.btn_NormalTest.Text = "Normal Test";
            this.btn_NormalTest.UseVisualStyleBackColor = true;
            this.btn_NormalTest.Click += new System.EventHandler(this.btn_NormalTest_Click);
            // 
            // btn_fuseOperation
            // 
            this.btn_fuseOperation.Location = new System.Drawing.Point(362, 107);
            this.btn_fuseOperation.Name = "btn_fuseOperation";
            this.btn_fuseOperation.Size = new System.Drawing.Size(75, 23);
            this.btn_fuseOperation.TabIndex = 33;
            this.btn_fuseOperation.Text = "Fuse";
            this.btn_fuseOperation.UseVisualStyleBackColor = true;
            this.btn_fuseOperation.Click += new System.EventHandler(this.btn_fuseOperation_Click);
            // 
            // btn_initMode
            // 
            this.btn_initMode.Location = new System.Drawing.Point(203, 78);
            this.btn_initMode.Name = "btn_initMode";
            this.btn_initMode.Size = new System.Drawing.Size(75, 23);
            this.btn_initMode.TabIndex = 32;
            this.btn_initMode.Text = "Init Mode";
            this.btn_initMode.UseVisualStyleBackColor = true;
            this.btn_initMode.Click += new System.EventHandler(this.btn_initMode_Click);
            // 
            // btn_enterFuseMode
            // 
            this.btn_enterFuseMode.Location = new System.Drawing.Point(203, 109);
            this.btn_enterFuseMode.Name = "btn_enterFuseMode";
            this.btn_enterFuseMode.Size = new System.Drawing.Size(75, 23);
            this.btn_enterFuseMode.TabIndex = 31;
            this.btn_enterFuseMode.Text = "Enter Fuse";
            this.btn_enterFuseMode.UseVisualStyleBackColor = true;
            this.btn_enterFuseMode.Click += new System.EventHandler(this.btn_enterFuseMode_Click);
            // 
            // chb_TestBool
            // 
            this.chb_TestBool.AutoSize = true;
            this.chb_TestBool.Location = new System.Drawing.Point(188, 58);
            this.chb_TestBool.Name = "chb_TestBool";
            this.chb_TestBool.Size = new System.Drawing.Size(66, 17);
            this.chb_TestBool.TabIndex = 30;
            this.chb_TestBool.Text = "Test Set";
            this.chb_TestBool.UseVisualStyleBackColor = true;
            this.chb_TestBool.CheckedChanged += new System.EventHandler(this.chb_TestBool_CheckedChanged);
            // 
            // chb_SetLR
            // 
            this.chb_SetLR.AutoSize = true;
            this.chb_SetLR.Location = new System.Drawing.Point(123, 58);
            this.chb_SetLR.Name = "chb_SetLR";
            this.chb_SetLR.Size = new System.Drawing.Size(59, 17);
            this.chb_SetLR.TabIndex = 29;
            this.chb_SetLR.Text = "Set LR";
            this.chb_SetLR.UseVisualStyleBackColor = true;
            this.chb_SetLR.CheckedChanged += new System.EventHandler(this.chb_SetLR_CheckedChanged);
            // 
            // btn_ContinuousRecord
            // 
            this.btn_ContinuousRecord.Location = new System.Drawing.Point(362, 44);
            this.btn_ContinuousRecord.Name = "btn_ContinuousRecord";
            this.btn_ContinuousRecord.Size = new System.Drawing.Size(87, 36);
            this.btn_ContinuousRecord.TabIndex = 28;
            this.btn_ContinuousRecord.Text = "Continuous Recording";
            this.btn_ContinuousRecord.UseVisualStyleBackColor = true;
            // 
            // btn_I2CWrite
            // 
            this.btn_I2CWrite.Location = new System.Drawing.Point(260, 205);
            this.btn_I2CWrite.Name = "btn_I2CWrite";
            this.btn_I2CWrite.Size = new System.Drawing.Size(75, 23);
            this.btn_I2CWrite.TabIndex = 27;
            this.btn_I2CWrite.Text = "I2C Write";
            this.btn_I2CWrite.UseVisualStyleBackColor = true;
            this.btn_I2CWrite.Click += new System.EventHandler(this.btn_I2CWrite_Click);
            // 
            // btn_TestI2CRead
            // 
            this.btn_TestI2CRead.Location = new System.Drawing.Point(260, 234);
            this.btn_TestI2CRead.Name = "btn_TestI2CRead";
            this.btn_TestI2CRead.Size = new System.Drawing.Size(75, 23);
            this.btn_TestI2CRead.TabIndex = 26;
            this.btn_TestI2CRead.Text = "I2C Read";
            this.btn_TestI2CRead.UseVisualStyleBackColor = true;
            this.btn_TestI2CRead.Click += new System.EventHandler(this.btn_TestI2CRead_Click);
            // 
            // lbl_PDMBaseData
            // 
            this.lbl_PDMBaseData.AutoSize = true;
            this.lbl_PDMBaseData.Location = new System.Drawing.Point(20, 303);
            this.lbl_PDMBaseData.Name = "lbl_PDMBaseData";
            this.lbl_PDMBaseData.Size = new System.Drawing.Size(84, 13);
            this.lbl_PDMBaseData.TabIndex = 24;
            this.lbl_PDMBaseData.Text = "PDM Base Data";
            // 
            // txt_PDMBaseData
            // 
            this.txt_PDMBaseData.Location = new System.Drawing.Point(23, 319);
            this.txt_PDMBaseData.Name = "txt_PDMBaseData";
            this.txt_PDMBaseData.Size = new System.Drawing.Size(395, 20);
            this.txt_PDMBaseData.TabIndex = 23;
            this.txt_PDMBaseData.Text = "12345670";
            // 
            // grb_Tools
            // 
            this.grb_Tools.Controls.Add(this.btn_ConvertRaw2Text);
            this.grb_Tools.Controls.Add(this.btn_GetFWVersion);
            this.grb_Tools.Controls.Add(this.lbl_FWVesion_521);
            this.grb_Tools.Controls.Add(this.btn_DecoderLocalFile);
            this.grb_Tools.Controls.Add(this.btn_Decoder);
            this.grb_Tools.Controls.Add(this.btn_scrambler);
            this.grb_Tools.Controls.Add(this.btn_generateCSV);
            this.grb_Tools.Controls.Add(this.btn_PDMDataAnalysis);
            this.grb_Tools.Location = new System.Drawing.Point(13, 138);
            this.grb_Tools.Name = "grb_Tools";
            this.grb_Tools.Size = new System.Drawing.Size(225, 162);
            this.grb_Tools.TabIndex = 22;
            this.grb_Tools.TabStop = false;
            this.grb_Tools.Text = "Tools";
            // 
            // btn_ConvertRaw2Text
            // 
            this.btn_ConvertRaw2Text.Location = new System.Drawing.Point(94, 126);
            this.btn_ConvertRaw2Text.Name = "btn_ConvertRaw2Text";
            this.btn_ConvertRaw2Text.Size = new System.Drawing.Size(122, 23);
            this.btn_ConvertRaw2Text.TabIndex = 27;
            this.btn_ConvertRaw2Text.Text = "Raw Data To ASCII";
            this.btn_ConvertRaw2Text.UseVisualStyleBackColor = true;
            this.btn_ConvertRaw2Text.Click += new System.EventHandler(this.btn_ConvertRaw2Text_Click);
            // 
            // btn_GetFWVersion
            // 
            this.btn_GetFWVersion.Location = new System.Drawing.Point(10, 96);
            this.btn_GetFWVersion.Name = "btn_GetFWVersion";
            this.btn_GetFWVersion.Size = new System.Drawing.Size(93, 23);
            this.btn_GetFWVersion.TabIndex = 26;
            this.btn_GetFWVersion.Text = "Get FW Version";
            this.btn_GetFWVersion.UseVisualStyleBackColor = true;
            this.btn_GetFWVersion.Click += new System.EventHandler(this.btn_GetFWVersion_Click);
            // 
            // lbl_FWVesion_521
            // 
            this.lbl_FWVesion_521.AutoSize = true;
            this.lbl_FWVesion_521.Location = new System.Drawing.Point(7, 131);
            this.lbl_FWVesion_521.Name = "lbl_FWVesion_521";
            this.lbl_FWVesion_521.Size = new System.Drawing.Size(65, 13);
            this.lbl_FWVesion_521.TabIndex = 25;
            this.lbl_FWVesion_521.Text = "FW Version:";
            // 
            // btn_DecoderLocalFile
            // 
            this.btn_DecoderLocalFile.Location = new System.Drawing.Point(125, 77);
            this.btn_DecoderLocalFile.Name = "btn_DecoderLocalFile";
            this.btn_DecoderLocalFile.Size = new System.Drawing.Size(75, 42);
            this.btn_DecoderLocalFile.TabIndex = 24;
            this.btn_DecoderLocalFile.Text = "Decoder Local File";
            this.btn_DecoderLocalFile.UseVisualStyleBackColor = true;
            this.btn_DecoderLocalFile.Click += new System.EventHandler(this.btn_DecoderLocalFile_Click);
            // 
            // btn_Decoder
            // 
            this.btn_Decoder.Location = new System.Drawing.Point(125, 48);
            this.btn_Decoder.Name = "btn_Decoder";
            this.btn_Decoder.Size = new System.Drawing.Size(75, 23);
            this.btn_Decoder.TabIndex = 23;
            this.btn_Decoder.Text = "Decoder";
            this.btn_Decoder.UseVisualStyleBackColor = true;
            this.btn_Decoder.Click += new System.EventHandler(this.btn_Decoder_Click);
            // 
            // btn_scrambler
            // 
            this.btn_scrambler.Location = new System.Drawing.Point(125, 19);
            this.btn_scrambler.Name = "btn_scrambler";
            this.btn_scrambler.Size = new System.Drawing.Size(75, 23);
            this.btn_scrambler.TabIndex = 22;
            this.btn_scrambler.Text = "Scrambler";
            this.btn_scrambler.UseVisualStyleBackColor = true;
            this.btn_scrambler.Click += new System.EventHandler(this.btn_scrambler_Click);
            // 
            // btn_generateCSV
            // 
            this.btn_generateCSV.Location = new System.Drawing.Point(10, 19);
            this.btn_generateCSV.Name = "btn_generateCSV";
            this.btn_generateCSV.Size = new System.Drawing.Size(93, 23);
            this.btn_generateCSV.TabIndex = 20;
            this.btn_generateCSV.Text = "Export CSV";
            this.btn_generateCSV.UseVisualStyleBackColor = true;
            this.btn_generateCSV.Click += new System.EventHandler(this.btn_generateCSV_Click);
            // 
            // btn_PDMDataAnalysis
            // 
            this.btn_PDMDataAnalysis.Location = new System.Drawing.Point(10, 48);
            this.btn_PDMDataAnalysis.Name = "btn_PDMDataAnalysis";
            this.btn_PDMDataAnalysis.Size = new System.Drawing.Size(93, 42);
            this.btn_PDMDataAnalysis.TabIndex = 21;
            this.btn_PDMDataAnalysis.Text = "PDM Data Analysis";
            this.btn_PDMDataAnalysis.UseVisualStyleBackColor = true;
            this.btn_PDMDataAnalysis.Click += new System.EventHandler(this.btn_PDMDataAnalysis_Click);
            // 
            // pgb_PDMreceive
            // 
            this.pgb_PDMreceive.Location = new System.Drawing.Point(560, 9);
            this.pgb_PDMreceive.Name = "pgb_PDMreceive";
            this.pgb_PDMreceive.Size = new System.Drawing.Size(257, 22);
            this.pgb_PDMreceive.TabIndex = 19;
            // 
            // lbl_num_8kwillRead
            // 
            this.lbl_num_8kwillRead.AutoSize = true;
            this.lbl_num_8kwillRead.Location = new System.Drawing.Point(120, 16);
            this.lbl_num_8kwillRead.Name = "lbl_num_8kwillRead";
            this.lbl_num_8kwillRead.Size = new System.Drawing.Size(109, 13);
            this.lbl_num_8kwillRead.TabIndex = 18;
            this.lbl_num_8kwillRead.Text = "Num of 64K will Read";
            // 
            // grb_521Test
            // 
            this.grb_521Test.Controls.Add(this.btn_testBtn);
            this.grb_521Test.Controls.Add(this.lbl_testCount);
            this.grb_521Test.Controls.Add(this.btn_TestRead);
            this.grb_521Test.Controls.Add(this.btn_falsh);
            this.grb_521Test.Location = new System.Drawing.Point(13, 13);
            this.grb_521Test.Name = "grb_521Test";
            this.grb_521Test.Size = new System.Drawing.Size(96, 119);
            this.grb_521Test.TabIndex = 17;
            this.grb_521Test.TabStop = false;
            this.grb_521Test.Text = "Test Functions";
            // 
            // btn_testBtn
            // 
            this.btn_testBtn.Location = new System.Drawing.Point(10, 91);
            this.btn_testBtn.Name = "btn_testBtn";
            this.btn_testBtn.Size = new System.Drawing.Size(75, 23);
            this.btn_testBtn.TabIndex = 25;
            this.btn_testBtn.Text = "Test Button";
            this.btn_testBtn.UseVisualStyleBackColor = true;
            this.btn_testBtn.Click += new System.EventHandler(this.btn_testBtn_Click);
            // 
            // lbl_testCount
            // 
            this.lbl_testCount.AutoSize = true;
            this.lbl_testCount.Location = new System.Drawing.Point(7, 75);
            this.lbl_testCount.Name = "lbl_testCount";
            this.lbl_testCount.Size = new System.Drawing.Size(13, 13);
            this.lbl_testCount.TabIndex = 20;
            this.lbl_testCount.Text = "0\r\n";
            // 
            // btn_TestRead
            // 
            this.btn_TestRead.Location = new System.Drawing.Point(10, 49);
            this.btn_TestRead.Name = "btn_TestRead";
            this.btn_TestRead.Size = new System.Drawing.Size(75, 23);
            this.btn_TestRead.TabIndex = 14;
            this.btn_TestRead.Text = "Test Read";
            this.btn_TestRead.UseVisualStyleBackColor = true;
            this.btn_TestRead.Click += new System.EventHandler(this.btn_TestRead_Click);
            // 
            // btn_falsh
            // 
            this.btn_falsh.Location = new System.Drawing.Point(10, 19);
            this.btn_falsh.Name = "btn_falsh";
            this.btn_falsh.Size = new System.Drawing.Size(75, 23);
            this.btn_falsh.TabIndex = 12;
            this.btn_falsh.Text = "Flash LED";
            this.btn_falsh.UseVisualStyleBackColor = true;
            this.btn_falsh.Click += new System.EventHandler(this.btn_falsh_Click);
            // 
            // numUD_num8K
            // 
            this.numUD_num8K.Location = new System.Drawing.Point(123, 32);
            this.numUD_num8K.Maximum = new decimal(new int[] {
            41943040,
            0,
            0,
            0});
            this.numUD_num8K.Name = "numUD_num8K";
            this.numUD_num8K.Size = new System.Drawing.Size(100, 20);
            this.numUD_num8K.TabIndex = 16;
            this.numUD_num8K.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_num8K.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_PDMStop
            // 
            this.btn_PDMStop.Location = new System.Drawing.Point(459, 4);
            this.btn_PDMStop.Name = "btn_PDMStop";
            this.btn_PDMStop.Size = new System.Drawing.Size(87, 36);
            this.btn_PDMStop.TabIndex = 15;
            this.btn_PDMStop.Text = "PDM Stp";
            this.btn_PDMStop.UseVisualStyleBackColor = true;
            this.btn_PDMStop.Click += new System.EventHandler(this.btn_PDMStop_Click);
            // 
            // btn_PDMStart
            // 
            this.btn_PDMStart.Location = new System.Drawing.Point(362, 4);
            this.btn_PDMStart.Name = "btn_PDMStart";
            this.btn_PDMStart.Size = new System.Drawing.Size(87, 36);
            this.btn_PDMStart.TabIndex = 13;
            this.btn_PDMStart.Text = "REC with given size";
            this.btn_PDMStart.UseVisualStyleBackColor = true;
            this.btn_PDMStart.Click += new System.EventHandler(this.btn_PDMStart_Click);
            // 
            // tabPage_SPK
            // 
            this.tabPage_SPK.Controls.Add(this.grb_TestInterface);
            this.tabPage_SPK.Controls.Add(this.btn_Read);
            this.tabPage_SPK.Controls.Add(this.lbl_dllVersion);
            this.tabPage_SPK.Controls.Add(this.txt_writeData);
            this.tabPage_SPK.Controls.Add(this.button1);
            this.tabPage_SPK.Controls.Add(this.btn_write);
            this.tabPage_SPK.Controls.Add(this.checkBox1);
            this.tabPage_SPK.Controls.Add(this.label3);
            this.tabPage_SPK.Controls.Add(this.txt_readlength);
            this.tabPage_SPK.Controls.Add(this.btn_getWav);
            this.tabPage_SPK.Controls.Add(this.btn_readData);
            this.tabPage_SPK.Controls.Add(this.btn_ModuleEnable);
            this.tabPage_SPK.Controls.Add(this.button2);
            this.tabPage_SPK.Controls.Add(this.lbl_firmVersion);
            this.tabPage_SPK.Controls.Add(this.btn_timerEnable);
            this.tabPage_SPK.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SPK.Name = "tabPage_SPK";
            this.tabPage_SPK.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SPK.Size = new System.Drawing.Size(823, 503);
            this.tabPage_SPK.TabIndex = 0;
            this.tabPage_SPK.Text = "SPK";
            this.tabPage_SPK.UseVisualStyleBackColor = true;
            // 
            // cmb_devSel
            // 
            this.cmb_devSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_devSel.FormattingEnabled = true;
            this.cmb_devSel.Items.AddRange(new object[] {
            "One Wire",
            "ADMP521T",
            "SPK Protection"});
            this.cmb_devSel.Location = new System.Drawing.Point(550, 10);
            this.cmb_devSel.Name = "cmb_devSel";
            this.cmb_devSel.Size = new System.Drawing.Size(95, 21);
            this.cmb_devSel.TabIndex = 22;
            this.cmb_devSel.Visible = false;
            this.cmb_devSel.SelectedIndexChanged += new System.EventHandler(this.cmb_devSel_SelectedIndexChanged);
            // 
            // TestGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 565);
            this.Controls.Add(this.cmb_devSel);
            this.Controls.Add(this.tabCtrl_ForSDP);
            this.Controls.Add(this.txt_GUID_Write);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_GUID_Read);
            this.Controls.Add(this.chb_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_deviceNum);
            this.Controls.Add(this.btn_connect);
            this.Name = "TestGUI";
            this.Text = "One Wire Control Interface v1.6";
            this.grb_TestInterface.ResumeLayout(false);
            this.tabCtrl_ForSDP.ResumeLayout(false);
            this.tabPage_OneWire.ResumeLayout(false);
            this.tabPage_OneWire.PerformLayout();
            this.groupBox_usercommand.ResumeLayout(false);
            this.groupBox_usercommand.PerformLayout();
            this.grb_ScanTest_OW.ResumeLayout(false);
            this.grb_ScanTest_OW.PerformLayout();
            this.grb_FuseMode_OW.ResumeLayout(false);
            this.grb_FuseMode_OW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pulsedurationtime_ow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_UD_pulsewidth_ow)).EndInit();
            this.grb_BurstI2CRW_OW.ResumeLayout(false);
            this.grb_BurstI2CRW_OW.PerformLayout();
            this.grb_SingleI2CRW_OW.ResumeLayout(false);
            this.grb_SingleI2CRW_OW.PerformLayout();
            this.grb_devInfo_ow.ResumeLayout(false);
            this.grb_devInfo_ow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_pilotwidth_ow)).EndInit();
            this.tabPage_ADMP521.ResumeLayout(false);
            this.tabPage_ADMP521.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_fuseClk)).EndInit();
            this.grb_Tools.ResumeLayout(false);
            this.grb_Tools.PerformLayout();
            this.grb_521Test.ResumeLayout(false);
            this.grb_521Test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_num8K)).EndInit();
            this.tabPage_SPK.ResumeLayout(false);
            this.tabPage_SPK.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_deviceNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_GUID_Read;
        private System.Windows.Forms.TextBox txt_GUID_Write;
        private System.Windows.Forms.Button btn_readData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_readlength;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.Button btn_getWav;
        private System.Windows.Forms.TextBox txt_writeData;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.GroupBox grb_TestInterface;
        private System.Windows.Forms.Button btn_ReadLocalIV;
        private System.Windows.Forms.Button btn_testIntArrayToBytes;
        private System.Windows.Forms.Button btn_testArrayCompare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_testFixFloatConv;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_timerEnable;
        private System.Windows.Forms.Label lbl_firmVersion;
        private System.Windows.Forms.Button btn_ModuleEnable;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbl_dllVersion;
        private System.Windows.Forms.TabControl tabCtrl_ForSDP;
        private System.Windows.Forms.TabPage tabPage_SPK;
        private System.Windows.Forms.TabPage tabPage_ADMP521;
        private System.Windows.Forms.Button btn_falsh;
        private System.Windows.Forms.Button btn_PDMStart;
        private System.Windows.Forms.Button btn_TestRead;
        private System.Windows.Forms.Button btn_PDMStop;
        private System.Windows.Forms.Label lbl_num_8kwillRead;
        private System.Windows.Forms.GroupBox grb_521Test;
        private System.Windows.Forms.NumericUpDown numUD_num8K;
        private System.Windows.Forms.ProgressBar pgb_PDMreceive;
        private System.Windows.Forms.Label lbl_testCount;
        private System.Windows.Forms.Button btn_generateCSV;
        private System.Windows.Forms.Button btn_PDMDataAnalysis;
        private System.Windows.Forms.GroupBox grb_Tools;
        private System.Windows.Forms.TextBox txt_PDMBaseData;
        private System.Windows.Forms.Label lbl_PDMBaseData;
        private System.Windows.Forms.Button btn_Decoder;
        private System.Windows.Forms.Button btn_scrambler;
        private System.Windows.Forms.Button btn_DecoderLocalFile;
        private System.Windows.Forms.Button btn_testBtn;
        private System.Windows.Forms.Button btn_I2CWrite;
        private System.Windows.Forms.Button btn_TestI2CRead;
        private System.Windows.Forms.Button btn_GetFWVersion;
        private System.Windows.Forms.Label lbl_FWVesion_521;
        private System.Windows.Forms.Button btn_ContinuousRecord;
        private System.Windows.Forms.CheckBox chb_SetLR;
        private System.Windows.Forms.CheckBox chb_TestBool;
        private System.Windows.Forms.Button btn_enterFuseMode;
        private System.Windows.Forms.Button btn_initMode;
        private System.Windows.Forms.Button btn_fuseOperation;
        private System.Windows.Forms.NumericUpDown numUD_fuseClk;
        private System.Windows.Forms.Button btn_NormalTest;
        private System.Windows.Forms.CheckBox chb_postTrim;
        private System.Windows.Forms.CheckBox chb_clkSetting;
        private System.Windows.Forms.Button btn_normalMode;
        private System.Windows.Forms.Button btn_TestMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_i2cWriteVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_i2cWriteAdd;
        private System.Windows.Forms.TextBox txt_i2cRead;
        private System.Windows.Forms.Button btn_ConvertRaw2Text;
        private System.Windows.Forms.Button btn_testReadSize;
        private System.Windows.Forms.TabPage tabPage_OneWire;
        private System.Windows.Forms.ComboBox cmb_devSel;
        private System.Windows.Forms.TextBox txt_reg_data_ows1;
        private System.Windows.Forms.TextBox txt_reg_addr_ows1;
        private System.Windows.Forms.Button btn_flash_onewire;
        private System.Windows.Forms.Button btn_GetFW_OneWire;
        private System.Windows.Forms.TextBox txt_dev_addr_onewire;
        private System.Windows.Forms.Label lbl_devAddr_onewire;
        private System.Windows.Forms.GroupBox grb_devInfo_ow;
        private System.Windows.Forms.Label lbl_reg_addr_single_onewire;
        private System.Windows.Forms.GroupBox grb_SingleI2CRW_OW;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire1;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire1;
        private System.Windows.Forms.Label lbl_reg_data_single_onewire;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire7;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire7;
        private System.Windows.Forms.TextBox txt_reg_addr_ows7;
        private System.Windows.Forms.TextBox txt_reg_data_ows7;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire6;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire6;
        private System.Windows.Forms.TextBox txt_reg_addr_ows6;
        private System.Windows.Forms.TextBox txt_reg_data_ows6;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire5;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire5;
        private System.Windows.Forms.TextBox txt_reg_addr_ows5;
        private System.Windows.Forms.TextBox txt_reg_data_ows5;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire4;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire4;
        private System.Windows.Forms.TextBox txt_reg_addr_ows4;
        private System.Windows.Forms.TextBox txt_reg_data_ows4;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire3;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire3;
        private System.Windows.Forms.TextBox txt_reg_addr_ows3;
        private System.Windows.Forms.TextBox txt_reg_data_ows3;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire2;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire2;
        private System.Windows.Forms.TextBox txt_reg_addr_ows2;
        private System.Windows.Forms.TextBox txt_reg_data_ows2;
        private System.Windows.Forms.GroupBox grb_BurstI2CRW_OW;
        private System.Windows.Forms.Button btn_I2CWrite_Burst_Onewire;
        private System.Windows.Forms.Button btn_I2CRead_Burst_Onewire;
        private System.Windows.Forms.TextBox txt_reg_addr_owb;
        private System.Windows.Forms.TextBox txt_I2C_rw_num_owb;
        private System.Windows.Forms.Label lbl_rw_num_burst_onewire;
        private System.Windows.Forms.Label lbl_reg_addr_burst_onewire;
        private System.Windows.Forms.Label lbl_reg_data_burst_onewire;
        private System.Windows.Forms.TextBox txt_reg_data_owb;
        private System.Windows.Forms.GroupBox grb_FuseMode_OW;
        private System.Windows.Forms.CheckBox chb_FuseModeSwitch;
        private System.Windows.Forms.RadioButton rbtn_FuseClkOff;
        private System.Windows.Forms.RadioButton rbtn_FuseClkOn;
        private System.Windows.Forms.ComboBox cmb_fusepulsewidth;
        private System.Windows.Forms.NumericUpDown numUD_pilotwidth_ow;
        private System.Windows.Forms.Label lbl_pilotwidth_ow;
        private System.Windows.Forms.Label lbl_FW_onewire;
        private System.Windows.Forms.Button btn_fuse_action_ow;
        private System.Windows.Forms.NumericUpDown numUD_pulsedurationtime_ow;
        private System.Windows.Forms.Label lbl_pulsewidth_ow;
        private System.Windows.Forms.NumericUpDown num_UD_pulsewidth_ow;
        private System.Windows.Forms.Label lbl_pulsedurationtime_ow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_test_ow;
        private System.Windows.Forms.GroupBox grb_ScanTest_OW;
        private System.Windows.Forms.Label lbl_loadNum_OW;
        private System.Windows.Forms.TextBox txt_loadNum_OW;
        private System.Windows.Forms.Button btn_startScanWrite_OW;
        private System.Windows.Forms.Button btn_LoadScanData_OW;
        private System.Windows.Forms.Label lbl_ScanWroteNum_OW;
        private System.Windows.Forms.ProgressBar pgb_ProcessedRate_OW;
        private System.Windows.Forms.TextBox txt_WroteNum_OW;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire10;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire10;
        private System.Windows.Forms.TextBox txt_reg_addr_ows10;
        private System.Windows.Forms.TextBox txt_reg_data_ows10;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire9;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire9;
        private System.Windows.Forms.TextBox txt_reg_addr_ows9;
        private System.Windows.Forms.TextBox txt_reg_data_ows9;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire8;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire8;
        private System.Windows.Forms.TextBox txt_reg_addr_ows8;
        private System.Windows.Forms.TextBox txt_reg_data_ows8;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire12;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire12;
        private System.Windows.Forms.TextBox txt_reg_addr_ows12;
        private System.Windows.Forms.TextBox txt_reg_data_ows12;
        private System.Windows.Forms.Button btn_I2CWrite_Single_Onewire11;
        private System.Windows.Forms.Button btn_I2CRead_Single_Onewire11;
        private System.Windows.Forms.TextBox txt_reg_addr_ows11;
        private System.Windows.Forms.TextBox txt_reg_data_ows11;
        private System.Windows.Forms.GroupBox groupBox_usercommand;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_userCMD_ParamNum_OWI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_userCMD_UPCount_OWI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_userCMD_DownCount_OWI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_userCMD_OWI;
        private System.Windows.Forms.Button btn_WriteUserCMD_OW;
    }
}

