using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADI.DMY2;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace OWCI
{
    public partial class OWCIWinDLG : Form
    {
        public OWCIWinDLG()
        {
            InitializeComponent();
            OneWrieInit();
        }

        OneWireInterface oneWrie_device = new OneWireInterface();
               

        #region Params Shared
        double[] dwArray = new double[128];        //should use u32 write interface.
        uint[] u32Array = new uint[128];
        byte[] write_array = new byte[512];

        int u32OWCIDelay = 0;

        int[] int32Array = new int[128];

        BindingList<RegisterProperty> RegTabList_Cur;
        BindingList<RegisterProperty> RegTabList_Default;
        RegTable regTabCtrl;

        #endregion Params Shared

        #region Common events
        private int WM_DEVICECHANGE = 0x0219;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {
                ConnectDevice();
            }
        }         
        #endregion 
              
        #region One Wire Interface

        #region Functions
        private void ConnectDevice()
        {
            bool result;
            #region One wire
            result = oneWrie_device.ConnectDevice();

            if (result)
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.YellowGreen;
                this.toolStripStatusLabel_Connection.Text = "Connected";
                btn_GetFW_OneWire_Click(null, null);
            }
            else
            {
                this.toolStripStatusLabel_Connection.BackColor = Color.IndianRed;
                this.toolStripStatusLabel_Connection.Text = "Disconnected";
            }
            #endregion
        }

        private void OneWrieInit()
        {
            pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow.Value;
            //Disable Fuse operation
            //this.cmb_fusepulsewidth.Enabled = false;
            //this.rbtn_FuseClkOn.Enabled = false;
            //this.rbtn_FuseClkOff.Enabled = false;
            this.num_UD_pulsewidth_ow.Enabled = false;
            this.numUD_pulsedurationtime_ow.Enabled = false;
            this.btn_fuse_action_ow.Enabled = false;

            ConnectDevice();
            RegTabInit();
        }

        private void RegTabInit()
        {
            if (this.RegTabList_Cur != null)
                this.RegTabList_Cur = null;

            this.RegTabList_Cur = new BindingList<RegisterProperty>();
            RegTabList_Default = new BindingList<RegisterProperty>();
            uint ix = 1;

            #region Fill in register table
            this.RegTabList_Cur.Add(new RegisterProperty(ix, 0x40, "0", RWProperty.R, true, false));  //Reg40
            this.RegTabList_Default.Add(new RegisterProperty(ix++, 0x40, "0", RWProperty.R, true, false));
            //Reg41 - Reg4F
            for (uint addr = 0x41; addr <= 0x4F; )
            {
                if (addr != 0x4A)
                {
                    this.RegTabList_Cur.Add(new RegisterProperty(ix, addr, "0", RWProperty.RW, true, true));
                    this.RegTabList_Default.Add(new RegisterProperty(ix++, addr++, "0", RWProperty.RW, true, true));
                }
                else
                {
                    this.RegTabList_Cur.Add(new RegisterProperty(ix, addr, "0", RWProperty.R, true, false));
                    this.RegTabList_Default.Add(new RegisterProperty(ix++, addr++, "0", RWProperty.R, true, false));
                }
            }
            //RegAA
            this.RegTabList_Cur.Add(new RegisterProperty(ix, 0xAA, "0", RWProperty.W, false, true));
            this.RegTabList_Default.Add(new RegisterProperty(ix++, 0xAA, "0", RWProperty.W, false, true));
            //Reg80 - Reg98
            for (uint addr = 0x80; addr <= 0x98; )
            {
                if (addr != 0x90)
                {
                    this.RegTabList_Cur.Add(new RegisterProperty(ix, addr, "0", RWProperty.RW, true, true));
                    this.RegTabList_Default.Add(new RegisterProperty(ix++, addr++, "0", RWProperty.RW, true, true));
                }
                else
                {
                    this.RegTabList_Cur.Add(new RegisterProperty(ix, addr, "0", RWProperty.W, false, true));
                    this.RegTabList_Default.Add(new RegisterProperty(ix++, addr, "0", RWProperty.W, false, true));
                    this.RegTabList_Cur.Add(new RegisterProperty(ix, addr, "0", RWProperty.R, true, false));
                    this.RegTabList_Default.Add(new RegisterProperty(ix++, addr++, "0", RWProperty.R, true, false));
                }
            }

            regTabCtrl = new RegTable(RegTabList_Cur);
            //this.panelRegTable.Controls.Add(regTabCtrl);
            regTabCtrl.Dock = DockStyle.Fill;
            //this.regTable1.BindingDataSource(RegTabList);
            #endregion Fill in register table
        }

        private void I2CRead_Single_OneWire(TextBox reg_addr, TextBox reg_data)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = reg_addr.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                reg_data.Text = oneWrie_device.I2CRead_Single(_dev_addr, _reg_addr).ToString("X");
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void I2CWrite_Single_OneWire(TextBox reg_addr, TextBox reg_data)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = reg_addr.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = reg_data.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_data = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                Console.WriteLine("I2C write single result->{0}",oneWrie_device.I2CWrite_Single(_dev_addr,_reg_addr,_reg_data));
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void I2CRead_DVG_OneWire(BindingList<RegisterProperty> regTab)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                for (int ix = 0; ix < regTab.Count; ix++)
                {
                    if (!regTab[ix].ifRead)
                        continue;
                    uint _reg_addr = regTab[ix].RegAddr;
                    regTab[ix].RegData = oneWrie_device.I2CRead_Single(_dev_addr, _reg_addr).ToString("X2");
                    Console.WriteLine("{0}={1}", _reg_addr.ToString("X2"), regTab[ix].RegData);
                }
            }
            catch
            {
                MessageBox.Show("Read failed due to data format error!");
            }
            finally 
            {
                if (regTabCtrl != null)
                {
                    regTabCtrl.BindingDataSource(RegTabList_Cur);
                }
            }
        }

        private void I2CWrite_DVG_OneWire(BindingList<RegisterProperty> regTab)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                for (int ix = 0; ix < regTab.Count; ix++)
                {
                    if (!regTab[ix].ifWrite)
                        continue;
                    uint _reg_addr = regTab[ix].RegAddr;
                    temp = regTab[ix].RegData.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                    uint _reg_data = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
                    Console.WriteLine("{0}<--{1} : I2C write single result->{2}",_reg_addr.ToString("X2"),_reg_data.ToString("X2"), oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                }
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void I2CRead_Burst_OneWire(TextBox start_reg_addr, TextBox read_num, TextBox read_data)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = start_reg_addr.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = read_num.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _read_num = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint[] _read_date = new uint[_read_num];
                uint read_result = oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr, _read_num, _read_date);

                if (read_result != 0)
                {
                    MessageBox.Show("Read Error:" + read_result.ToString("X"));
                    return;
                }

                string text_output = "";
                for (int i = 0; i < _read_num; i++)
                {
                    text_output += _read_date[i].ToString("X")+";"+"\t";
                    if ((i + 1) % 4 == 0 && i > 0)
                        text_output += "\r\n";
                }
                read_data.Text = text_output;
                Console.WriteLine("I2C write single result->{0}", read_result);
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void I2CWrite_Burst_OneWire(TextBox start_reg_addr, TextBox write_num, TextBox write_data)
        {
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = start_reg_addr.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = write_num.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _write_num = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint[] _write_date = new uint[_write_num];
                //string text_input = write_data.Text.Trim();
                string[] write_data_str_arr = (write_data.Text.Trim((" \\\r\n").ToCharArray()).Split(";:".ToCharArray()));
                if (((uint)write_data_str_arr.Length) < _write_num)
                {
                    MessageBox.Show("Write Data number unmatched, please check and try again.");
                    return;
                }

                for (int i = 0; i < _write_num; i++)
                {
                    _write_date[i] = UInt32.Parse((write_data_str_arr[i] == "" ? "0" : write_data_str_arr[i]), System.Globalization.NumberStyles.HexNumber);
                }
               
                Console.WriteLine("I2C write single result->{0}", oneWrie_device.I2CWrite_Burst(_dev_addr,_reg_addr,_write_date,_write_num));
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        #endregion Functions

        #region Events
        private void chb_FuseModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_FuseModeSwitch.Checked)
            {
                this.grb_BurstI2CRW_OW.Enabled = false;
                this.grb_SingleI2CRW_OW.Enabled = false;
                this.num_UD_pulsewidth_ow.Enabled = true;
                this.numUD_pulsedurationtime_ow.Enabled = true;
                this.btn_fuse_action_ow.Enabled = true;
                //this.cmb_fusepulsewidth.Enabled = true;
                //this.rbtn_FuseClkOn.Enabled = true;
                //this.rbtn_FuseClkOff.Enabled = true;
            }
            else
            {
                this.grb_BurstI2CRW_OW.Enabled = true;
                this.grb_SingleI2CRW_OW.Enabled = true;
                this.num_UD_pulsewidth_ow.Enabled = false;
                this.numUD_pulsedurationtime_ow.Enabled = false;
                this.btn_fuse_action_ow.Enabled = false;
                //this.cmb_fusepulsewidth.Enabled = false;
                //this.rbtn_FuseClkOn.Enabled = false;
                //this.rbtn_FuseClkOff.Enabled = false;

                //this.rbtn_FuseClkOff.Checked = true;
            }

            //reg49 <- F0
            if (this.chb_FuseModeSwitch.Checked)
            {
                try
                {
                    string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                    uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                    uint _reg_addr = 0x49;
                    uint _reg_data = 0xF0;

                    Console.WriteLine("{0}<--{1} : I2C write single result->{2}", _reg_addr.ToString("X2"), _reg_data.ToString("X2"), oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                }
                catch
                {
                    MessageBox.Show("Write data format error!");
                }
            }
        }

        private void btn_flash_onewire_Click(object sender, EventArgs e)
        {
           Console.WriteLine("Flash result->{0}",oneWrie_device.FlashLED());
        }

        private void btn_GetFW_OneWire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Enter Get FW Interface");
            this.toolStripStatusLabel_FWInfo.Text = "FW Version:" + oneWrie_device.GetFWVersion();

        }

        private void btn_I2CRead_Single_Onewire1_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows1, this.txt_reg_data_ows1);
        }

        private void btn_I2CWrite_Single_Onewire1_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows1, this.txt_reg_data_ows1);
        }

        private void btn_I2CRead_Single_Onewire2_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows2, this.txt_reg_data_ows2);
        }

        private void btn_I2CWrite_Single_Onewire2_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows2, this.txt_reg_data_ows2);
        }

        private void btn_I2CRead_Single_Onewire3_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows3, this.txt_reg_data_ows3);
        }

        private void btn_I2CWrite_Single_Onewire3_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows3, this.txt_reg_data_ows3);
        }

        private void btn_I2CRead_Single_Onewire4_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows4, this.txt_reg_data_ows4);
        }

        private void btn_I2CWrite_Single_Onewire4_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows4, this.txt_reg_data_ows4);
        }

        private void btn_I2CRead_Single_Onewire5_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows5, this.txt_reg_data_ows5);
        }

        private void btn_I2CWrite_Single_Onewire5_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows5, this.txt_reg_data_ows5);
        }

        private void btn_I2CRead_Single_Onewire6_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows6, this.txt_reg_data_ows6);
        }

        private void btn_I2CWrite_Single_Onewire6_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows6, this.txt_reg_data_ows6);
        }

        private void btn_I2CRead_Single_Onewire7_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows7, this.txt_reg_data_ows7);
        }

        private void btn_I2CWrite_Single_Onewire7_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows7, this.txt_reg_data_ows7);
        }

        private void btn_I2CRead_Single_Onewire8_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows8, this.txt_reg_data_ows8);
        }

        private void btn_I2CWrite_Single_Onewire8_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows8, this.txt_reg_data_ows8);
        }

        private void btn_I2CRead_Single_Onewire9_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows9, this.txt_reg_data_ows9);
        }

        private void btn_I2CWrite_Single_Onewire9_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows9, this.txt_reg_data_ows9);
        }

        private void btn_I2CRead_Single_Onewire10_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows10, this.txt_reg_data_ows10);
        }

        private void btn_I2CWrite_Single_Onewire10_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows10, this.txt_reg_data_ows10);
        }

        private void btn_I2CRead_Single_Onewire11_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows11, this.txt_reg_data_ows11);
        }

        private void btn_I2CWrite_Single_Onewire11_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows11, this.txt_reg_data_ows11);
        }

        private void btn_I2CRead_Single_Onewire12_Click(object sender, EventArgs e)
        {
            I2CRead_Single_OneWire(this.txt_reg_addr_ows12, this.txt_reg_data_ows12);
        }

        private void btn_I2CWrite_Single_Onewire12_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows12, this.txt_reg_data_ows12);
        }               

        private decimal pilotwidth_ow_value_backup = 100; //100,000ns
        private void numUD_pilotwidth_ow_ValueChanged(object sender, EventArgs e)
        {
            //Make sure the minimum value is integer times of 20ns, but now the minimum is 1us,so doesn't need it.
            //this.numUD_pilotwidth_ow.Value = (decimal)((int)Math.Round((double)this.numUD_pilotwidth_ow.Value / 20d) * 20);
            if (this.numUD_pilotwidth_ow.Value != pilotwidth_ow_value_backup)
            {
                this.pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow.Value;
                Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth((uint)this.numUD_pilotwidth_ow.Value * 1000));
            }
        }

        private void btn_I2CRead_Burst_Onewire_Click(object sender, EventArgs e)
        {
            I2CRead_Burst_OneWire(txt_reg_addr_owb, txt_I2C_rw_num_owb, txt_reg_data_owb);
            //Console.WriteLine("Set pilot width result->{0}", 
        }
        

        private void btn_I2CWrite_Burst_Onewire_Click(object sender, EventArgs e)
        {
            I2CWrite_Burst_OneWire(txt_reg_addr_owb, txt_I2C_rw_num_owb, txt_reg_data_owb);
        }

        private void btn_fuse_action_ow_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Fuse write result->{0}",oneWrie_device.FuseClockSwitch((double)this.num_UD_pulsewidth_ow.Value,(double)this.numUD_pulsedurationtime_ow.Value));

            Thread.Sleep(110);

            //reg49 <- 00
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint _reg_addr = 0x49;
                uint _reg_data = 0x0;

                Console.WriteLine("{0}<--{1} : I2C write single result->{2}", _reg_addr.ToString("X2"), _reg_data.ToString("X2"), oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }

        }

        private void num_UD_pulsewidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.num_UD_pulsewidth_ow.Value = (decimal)((int)Math.Round((double)this.num_UD_pulsewidth_ow.Value / 5d) * 5);
        }   

        #endregion Events    

        
        #endregion

        private void IfReadWrite_DVG_AllNoneDefault_Changed(object sender, EventArgs e)
        {
            if (RegTabList_Cur == null)
                return;

            #region if Read
            if ((sender as CheckBox) == this.chb_ifRead_DVG_AllNone)
            {
                bool ifCh = (sender as CheckBox).Checked;
                if (ifCh)
                {
                    (sender as CheckBox).Text = "All";
                }
                else
                {
                    (sender as CheckBox).Text = "None";
                }

                for (int i = 0; i < RegTabList_Cur.Count; i++)
                {
                    if (RegTabList_Cur[i].RW != RWProperty.W)
                        RegTabList_Cur[i].ifRead = ifCh;
                    else
                        RegTabList_Cur[i].ifRead = false;
                }
            }
            #endregion if Read

            #region if write
            if ((sender as CheckBox) == this.chb_ifWrite_DVG_AllNone)
            {
                bool ifCh = (sender as CheckBox).Checked;
                if ((sender as CheckBox).Checked)
                {
                    (sender as CheckBox).Text = "All";
                }
                else
                {
                    (sender as CheckBox).Text = "None";
                }

                for (int i = 0; i < RegTabList_Cur.Count; i++)
                {
                    if (RegTabList_Cur[i].RW != RWProperty.R)
                        RegTabList_Cur[i].ifWrite = ifCh;
                    else
                        RegTabList_Cur[i].ifWrite = false;
                }
            }
            #endregion if write

            #region Default
            if ((sender as Button) == this.btn_IfRW_DVG_Default)
            {
                for (int i = 0; i < RegTabList_Cur.Count; i++)
                {
                    RegTabList_Cur[i].ifRead = RegTabList_Default[i].ifRead;
                    RegTabList_Cur[i].ifWrite = RegTabList_Default[i].ifWrite;
                }
            }
            #endregion default

            //update data source
            if (regTabCtrl != null)
                regTabCtrl.BindingDataSource(RegTabList_Cur);
        }

        private void btn_I2CRead_DGV_Onewire_Click(object sender, EventArgs e)
        {
            I2CRead_DVG_OneWire(this.RegTabList_Cur);
        }

        private void btn_I2CWrite_DGV_Onewire_Click(object sender, EventArgs e)
        {
            I2CWrite_DVG_OneWire(this.RegTabList_Cur);
        }

        private void btn_enterTestMode_OWCI_Click(object sender, EventArgs e)
        {
            //regAA <- 5A
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth((uint)this.numUD_pilotwidth_ow.Value * 1000));

                uint _reg_addr = 0xAA;
                uint _reg_data = 0x5A;
                Console.WriteLine("{0}<--{1} : I2C write single result->{2}", _reg_addr.ToString("X2"), _reg_data.ToString("X2"), oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));

                Thread.Sleep(u32OWCIDelay);
                uint readData = oneWrie_device.I2CRead_Single(_dev_addr, _reg_addr);
                if (readData == 0)
                    MessageBox.Show("Enter Failed!");
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void rbt_CLKBuffered_Yes_OWCI_CheckedChanged(object sender, EventArgs e)
        {
            oneWrie_device.GeneralBoolSet(OneWire_USB_COMMAND.CLK_Buffered, this.rbt_CLKBuffered_Yes_OWCI.Checked);
        }

        private void rbt_DataBuffered_Yes_OWCI_CheckedChanged(object sender, EventArgs e)
        {
            oneWrie_device.GeneralBoolSet(OneWire_USB_COMMAND.DATA_Buffered, this.rbt_DataBuffered_Yes_OWCI.Checked);
        }

        private void rbt_SetLR_High_OWCI_CheckedChanged(object sender, EventArgs e)
        {
            oneWrie_device.GeneralBoolSet(OneWire_USB_COMMAND.SET_LR, this.rbt_SetLR_High_OWCI.Checked);
        }

        private void rbt_OWCICTLThru_Config_OWCI_CheckedChanged(object sender, EventArgs e)
        {
            oneWrie_device.GeneralBoolSet(OneWire_USB_COMMAND.OWCI_PIN, this.rbt_OWCICTLThru_Config_OWCI.Checked);
        }

        private void txt_DelayTime_TextChanged(object sender, EventArgs e)
        {
            string temp;
            try
            {
                temp = this.txt_DelayTime.Text;
                u32OWCIDelay = Int32.Parse((temp == "" ? "0" : temp));
            }
            catch
            {
                temp = string.Format("Sample rate number set failed, will use default value {0}", this.u32OWCIDelay);
                //DisplayOperateMes(temp, Color.Red);
            }
            finally
            {
                this.txt_DelayTime.Text = this.u32OWCIDelay.ToString();
            }
        }

        private void btn_I2CWR_Single_Onewire1_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows1, this.txt_reg_data_ows1);

            Thread.Sleep(u32OWCIDelay);

            I2CRead_Single_OneWire(this.txt_reg_addr_ows1, this.txt_reg_data_ows1);
        }

        private void btn_I2CWR_Single_Onewire2_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows2, this.txt_reg_data_ows2);

            Thread.Sleep(u32OWCIDelay);

            I2CRead_Single_OneWire(this.txt_reg_addr_ows2, this.txt_reg_data_ows2);
        }

        private void btn_I2CWR_Single_Onewire3_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows3, this.txt_reg_data_ows3);

            Thread.Sleep(u32OWCIDelay);

            I2CRead_Single_OneWire(this.txt_reg_addr_ows3, this.txt_reg_data_ows3);
        }

        private void btn_I2CWR_Single_Onewire4_Click(object sender, EventArgs e)
        {
            I2CWrite_Single_OneWire(this.txt_reg_addr_ows4, this.txt_reg_data_ows4);

            Thread.Sleep(u32OWCIDelay);

            I2CRead_Single_OneWire(this.txt_reg_addr_ows4, this.txt_reg_data_ows4);
        }

        private void btn_Excute_Onewire_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledlg = new OpenFileDialog();
                openfiledlg.Title = "Please choose the config file to be imported...";
                openfiledlg.Filter = "Config file(*.cfg)|*.cfg";
                openfiledlg.RestoreDirectory = true;
                string filename = "";
                if (openfiledlg.ShowDialog() == DialogResult.OK)
                {
                    filename = openfiledlg.FileName;
                }
                else
                    return;

                StreamReader sr = new StreamReader(filename);
                string comment = sr.ReadLine();
                string msg;
                string[] sCommand;
                

                msg = sr.ReadLine();

                while ( msg != null)
                {
                    uint Ix = 0;
                    sCommand = msg.Split(':');

                    switch ( sCommand[0] )
                    {
                        case "WR":
                        case "wr":
                        case "WReg":
                        case "wreg":
                        case "WriteReg":
                        case "writereg":
                        case "WriteRegister":
                        case "writeregister":
                            txt_reg_data_owb.Text += "Write Registers\r\n";
                            for( Ix = 0; Ix < ((sCommand.Length - 1)/2); Ix++ )
                            {
                                //I2CWrite_Single_OneWire(UInt32.Parse(sCommand[2 * Ix + 1]), UInt32.Parse(sCommand[2 * Ix + 2]));
                            } 
                            break; 

                        case "RR":
                        case "rr":
                        case "RReg":
                        case "rreg":
                        case "ReadReg":
                        case "readreg":
                        case "ReadRegister":
                        case "readregister":
                            txt_reg_data_owb.Text += "Read Registers\r\n";
                            for (Ix = 0; Ix < (sCommand.Length - 1); Ix++)
                            {
                                //I2CRead_Single_OneWire(UInt32.Parse(sCommand[2 * Ix + 1]), UInt32.Parse(sCommand[2 * Ix + 2]));
                            } 
                            break;

                        case "Fuse":
                        case "fuse":
                            txt_reg_data_owb.Text += "Fuse\r\n";
                            break;

                        case "BWR":
                        case "bwr":
                        case "BurstWriteReg":
                        case "burstwritereg":
                        case "BurstWriteRegister":
                        case "burstwriteregister":
                            txt_reg_data_owb.Text += "Burst Write Registers\r\n";
                            break;

                        case "BRR":
                        case "brr":
                        case "BurstReadReg":
                        case "burstreadreg":
                        case "BurstReadRegister":
                        case "burstreadregister":
                            txt_reg_data_owb.Text += "Burst Write Registers\r\n";
                            break;

                        case "SetPilot":
                        case "setpilot":
                        case "SP":
                        case "sp":
                            txt_reg_data_owb.Text += "Set Pilot\r\n";
                            break;

                        case "SetDelay":
                        case "setdelay":
                        case "SD":
                        case "sd":
                            txt_reg_data_owb.Text += "Set Operation Delay Time\r\n";
                            break;

                        case "SetLRAsOWCI":
                        case "setlrasowci":
                        case "slao":
                        case "SLAO":
                            txt_reg_data_owb.Text += "Set LR As OWCI\r\n";
                            break;

                        case "SetConfigAsOWCI":
                        case "setconfigasowci":
                        case "SCAO":
                        case "scao":
                            txt_reg_data_owb.Text += "Set Config As OWCI\r\n";
                            break;




                        default:
                            break;


                    }
                    msg = sr.ReadLine();
                
                }

            }
            catch
            {
                MessageBox.Show("Load config file failed, please choose correct file!");
            }
        }

        private void btn_LoadScript_Onewire_Click(object sender, EventArgs e)
        {

        }

        private void btn_SaveScript_Onewire_Click(object sender, EventArgs e)
        {

        }

        private void btn_LoadOtp_Onewire_Click(object sender, EventArgs e)
        {

        }

        private void btn_SaveOtp_Onewire_Click(object sender, EventArgs e)
        {

        }

        private void btn_BlowOtp_Onewire_Click(object sender, EventArgs e)
        {

        }
       

    }

    public class OutRptIndex
    {
        public OutRptIndex() { }
        // header index (size = 14)
        public static readonly uint header_zero_flag = 0;
        public static readonly uint header_hid_cmd = 1;
        public static readonly uint header_ctrl_mode = 2;
        public static readonly uint header_i2c_addr = 3; //0x28,0x29
        public static readonly uint header_reg_length = 4; // stuffed valid reg number
        public static readonly uint header_audio_if = 5;
        public static readonly uint header_sample_rate = 6;
        public static readonly uint header_fw_ver = 7; // firmware version
        public static readonly uint header_gpio_ctrl = 8; // for amp_sd/gp_oe/usb_oe..
        public static readonly uint header_gpio3_ctrl = 9;
        public static readonly uint header_frame_id = 10;
        public static readonly uint header_i2c_ctrl = 11; //I2c mode and freq selection
        public static readonly uint header_stuff_0 = 12;
        public static readonly uint header_stuff_1 = 13;

        //reg map index (size = 25 * 2 )
        public static readonly uint reg0_add = 14;
        public static readonly uint reg0_val = 15;
        public static readonly uint reg1_add = 16;
        public static readonly uint reg1_val = 17;
        public static readonly uint reg2_add = 18;
        public static readonly uint reg2_val = 19;
        public static readonly uint reg3_add = 20;
        public static readonly uint reg3_val = 21;
        public static readonly uint reg4_add = 22;
        public static readonly uint reg4_val = 23;
        public static readonly uint reg5_add = 24;
        public static readonly uint reg5_val = 25;
        public static readonly uint reg6_add = 26;
        public static readonly uint reg6_val = 27;
        public static readonly uint reg7_add = 28;
        public static readonly uint reg7_val = 29;
        public static readonly uint reg8_add = 30;
        public static readonly uint reg8_val = 31;
        public static readonly uint reg9_add = 32;
        public static readonly uint reg9_val = 33;
        public static readonly uint reg10_add = 34;
        public static readonly uint reg10_val = 35;
        public static readonly uint reg11_add = 36;
        public static readonly uint reg11_val = 37;
        public static readonly uint reg12_add = 38;
        public static readonly uint reg12_val = 39;
        public static readonly uint reg13_add = 40;
        public static readonly uint reg13_val = 41;
        public static readonly uint reg14_add = 42;
        public static readonly uint reg14_val = 43;
        public static readonly uint reg15_add = 44;
        public static readonly uint reg15_val = 45;
        public static readonly uint reg16_add = 46;
        public static readonly uint reg16_val = 47;
        public static readonly uint reg17_add = 48;
        public static readonly uint reg17_val = 49;
        public static readonly uint reg18_add = 50;
        public static readonly uint reg18_val = 51;
        public static readonly uint reg19_add = 52;
        public static readonly uint reg19_val = 53;
        public static readonly uint reg20_add = 54;
        public static readonly uint reg20_val = 55;
        public static readonly uint reg21_add = 56;
        public static readonly uint reg21_val = 57;
        public static readonly uint reg22_add = 58;
        public static readonly uint reg22_val = 59;
        public static readonly uint reg23_add = 60;
        public static readonly uint reg23_val = 61;
        public static readonly uint reg24_add = 62;
        public static readonly uint reg24_val = 63;
    }

    public enum _USB_COMMAND : byte
    {
        NO_COMMAND,				/* nothing doing here... */
        GET_FW_VERSION,			/* get the firmware version */
        QUERY_SUPPORT,			/* query for support */
        QUERY_REPLY,			/* query reply */

        CH_SELECT,				/* run loopback on the device */
        REG_WRITE,
        REG_READ,
        SAMPLE_RATE,
        AUDIO_FORMAT,

        MEMORY_READ,			/* read from specified memory on the device */
        MEMORY_WRITE,			/* write to specified memory on the device */

        USBIO_START,			/* run USB IO on this device */
        USBIO_STOP,				/* stop USB IO on this device */
        USBIO_OPEN,				/* open file on host */
        USBIO_CLOSE,			/* close file on host */
        USBIO_READ,				/* read file on host */
        USBIO_READ_REPLY,		/* read reply from host */
        USBIO_WRITE,			/* write file on host */
        USBIO_WRITE_REPLY,		/* write reply from host */
        USBIO_SEEK_CUR,			/* seek from current position of file on host */
        USBIO_SEEK_END,			/* seek from end of file on host */
        USBIO_SEEK_SET,			/* seek from beginning of file on host */
        USBIO_SEEK_REPLY,		/* seek reply from host */
        USBIO_FILEPTR,			/* sending file pointer */

        SPORT_START		    	/* custom command */
    };
}
