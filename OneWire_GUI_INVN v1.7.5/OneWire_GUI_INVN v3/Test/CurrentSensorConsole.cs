using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ADI.DMY2;
using System.Windows.Forms;
using System.Threading;

namespace Test
{
    public partial class CurrentSensorConsole : Form
    {
        public CurrentSensorConsole()
        {
            InitializeComponent();

            ConnectDevice();

            //Refresh pilot width
            Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth(8000));
            //numUD_pilotwidth_ow_ValueChanged(null, null);

            //Fill all the tables for internal tab
            FilledRoughTable();
            FilledPreciseTable();
            FilledOffsetTableA();
            FilledOffsetTableB();

            //Fill all the tables for customer tab
            FilledRoughTable_Customer();
            FilledPreciseTable_Customer();
            FilledOffsetTableA_Customer();
            FilledOffsetTableB_Customer();

            //Initialize Target Gain Combox
            this.cmb_TargetGain_Customer.SelectedIndex = 0;
            //IP15 for default.
            this.cmb_IPxForCalc_Customer.SelectedIndex = 2;

            //Remove Internal Tab
            if (!bAutoTrimTest)
            {
                this.tabControl1.Controls.Remove(InternalTab);
            }
            //
        }

        #region Param Definition

        bool bAutoTrimTest = true;          //Debug mode, display engineer tab
        //bool bAutoTrimTest = false;          //Release mode, bon't display engineer tab

        double IP20 = 0;
        double IP15 = 0;
        double IP10 = 0;
        double IP5 = 0;
        double IP0 = 0;

        //double IP15_Auto = 0;
        double IP0_Auto = 0;
        double IPx_Auto = 0;
        string StrIPx_Auto = "15A";
        uint selectedCurrent_Auto = 15;
        int ix_IPx_Customer = 0;

        uint Reg80Value = 0;
        uint Reg81Value = 0;
        uint Reg82Value = 0;
        uint Reg83Value = 0;
        //uint Reg84Value = 0;

        double[][] RoughTable = new double[3][];        //3x16: 0x80,0x81,Rough
        double[][] PreciseTable = new double[2][];      //2x32: 0x80,Precise
        double[][] OffsetTableA = new double[3][];      //3x16: 0x81,0x82,OffsetA
        double[][] OffsetTableB = new double[2][];      //2x16: 0x83,OffsetB

        double[][] RoughTable_Customer = new double[3][];        //3x16: 0x80,0x81,Rough
        double[][] PreciseTable_Customer = new double[2][];      //2x32: 0x80,Precise
        double[][] OffsetTableA_Customer = new double[3][];      //3x16: 0x81,0x82,OffsetA
        double[][] OffsetTableB_Customer = new double[2][];      //2x16: 0x83,OffsetB

        #endregion

        #region Device Connection
        OneWireInterface oneWrie_device = new OneWireInterface();

        private int WM_DEVICECHANGE = 0x0219;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {
                ConnectDevice();
            }
        }

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
        #endregion Device Connection

        #region Device Setting
        private decimal pilotwidth_ow_value_backup = 80000;
        private void numUD_pilotwidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.numUD_pilotwidth_ow.Value = (decimal)((int)Math.Round((double)this.numUD_pilotwidth_ow.Value / 20d) * 20);
            if (this.numUD_pilotwidth_ow.Value % 20 == 0 & this.numUD_pilotwidth_ow.Value != pilotwidth_ow_value_backup)
            {
                this.pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow.Value;
                Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth((uint)this.numUD_pilotwidth_ow.Value));
            }
        }

        private void num_UD_pulsewidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.num_UD_pulsewidth_ow.Value = (decimal)((int)Math.Round((double)this.num_UD_pulsewidth_ow.Value / 5d) * 5);
        }

        private void btn_fuse_action_ow_Click(object sender, EventArgs e)
        {
            //bool fuseMasterBit = false;
            DialogResult dr = MessageBox.Show("Please Change Power To 6V", "Change Power", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;

            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);
            //rbt_withCap_Vout.Checked = false;
            rbt_withoutCap_Vout.Checked = true;
            //rbt_signalPathSeting_Vout.Checked = false;

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                //0x03->0x43
                uint _reg_addr = 0x43;
                uint _reg_data = 0x03;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                //0xAA->0x44
                _reg_addr = 0x44;
                _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
            }
            catch
            {
                MessageBox.Show("Device data format error!");
            }

            Console.WriteLine("Fuse write result->{0}", oneWrie_device.FuseClockSwitch((double)this.num_UD_pulsewidth_ow.Value, (double)this.numUD_pulsedurationtime_ow.Value));
        }

        private void btn_flash_onewire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Flash result->{0}", oneWrie_device.FlashLED());
        }

        private void btn_GetFW_OneWire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Enter Get FW Interface");
            byte[] info = oneWrie_device.GetFirmwareInfo();

            if (info == null)
                return;

            string fwVersion = "v" + info[1].ToString() + "." + info[0].ToString() + " ";

            char[] dataInfo = new char[12];
            Array.Copy(info, 8, dataInfo, 0, 12);

            char[] timeInfo = new char[8];
            Array.Copy(info, 20, timeInfo, 0, 8);

            string data = new string(dataInfo);
            string time = "Build @ " + new string(timeInfo);

            this.toolStripStatusLabel_FWInfo.Text = fwVersion + time + " " + data;
            //this.lbl_FW_onewire.Text = "FW Version:" + oneWrie_device.GetFWVersion();
        }

        #endregion Device Setting

        #region Methods
        private double AverageVout(string current)
        {
            double result = 0;
            try
            {
                string temp = this.txt_sampleNum.Text;
                uint SampleRateNum = UInt32.Parse((temp == "" ? "0" : temp));

                temp = this.txt_sampleRate.Text;
                uint SampleRate = UInt32.Parse((temp == "" ? "0" : temp));  //Get sample rate in KHz
                SampleRate *= 1000;                                         //Changed to Hz

                result = oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, SampleRateNum));
            }
            catch
            {
                MessageBox.Show("Get Vout Failed @ " + current);
            }
            result = (result * 5d / 4096d);
            return result;
        }

        private double AverageVout_Customer(string current, uint sampleNum)
        {
            double result = 0;
            try
            {
                string temp = this.txt_sampleRate.Text;
                uint SampleRate = UInt32.Parse((temp == "" ? "0" : temp));  //Get sample rate in KHz
                SampleRate *= 1000;                                         //Changed to Hz

                result = oneWrie_device.AverageADCSamples(oneWrie_device.ADCSampleTransfer(SampleRate, sampleNum));
            }
            catch
            {
                MessageBox.Show("Get Vout Failed @ " + current);
            }
            result = (result * 5d / 4096d);
            return result;
        }

        /// <summary>
        /// 根据采集的IP5，IP10，IP15的平均值计算出Gain
        /// </summary>
        /// <returns>计算出的Gain供查表用</returns>
        private double GainCalculate()
        {
            double result = 0;

            result = 1000d * ((IP15 - IP5) / 10d + (IP15 - IP10) / 5d) / 2d;

            return result;
        }

        /// <summary>
        /// 根据采集的IP0，IP15的平均值计算出Gain
        /// </summary>
        /// <returns>计算出的Gain供查表用</returns>
        //private double GainCalculateForCustomer()
        //{
        //    //double result = 0;

        //    //result = 1000d * (IP15_Auto - IP0_Auto) / 15d;

        //    //return result;
        //}

        /// <summary>
        /// 根据采集的IP0，IPx的平均值计算出Gain
        /// </summary>
        /// <returns>计算出的Gain供查表用</returns>
        private double GainCalculateForCustomer(double _IPx, double _IP0, uint selectCurrent)
        {
            double result = 0;

            //result = 1000d * (_IPx - _IP0) / 15d;
            //Ding Hao
            result = 1000d * (_IPx - _IP0) / selectCurrent;

            return result;
        }

        /// <summary>
        /// 根据第二次计算的IP0计算，公式：（2.5 - IP0)/IP0
        /// </summary>
        /// <returns>计算出的Offset供查表用</returns>
        private double OffsetTuningCalc()
        {
            return (2.5 - IP0) / IP0;
        }

        private double OffsetTuningCalc_Customer()
        {
            return 2.5 / IP0_Auto;
        }

        private double GainTuningCalc(double testValue, double targetValue)
        {
            return (targetValue - testValue) / testValue;
        }

        private double GainTuningCalc_Customer(double testValue, double targetValue)
        {
            return targetValue / testValue;
        }

        private void FilledRoughTable()
        {
            for (int i = 0; i < RoughTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Rough
                        RoughTable[i] = new double[]{
                            -87.75,
                            -85.91,
                            -83.76,
                            -81.26,
                            -78.44,
                            -75.19,
                            -71.27,
                            -67.16,
                            -62.28,
                            -56.52,
                            -50.05,
                            -42.45,
                            -33.83,
                            -24.01,
                            -12.47,
                            0.00
                            };
                        break;
                    case 2: //0x81
                        RoughTable[i] = new double[]{
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0
                        };
                        break;
                    case 1: //0x80
                        RoughTable[i] = new double[]{
                        0xE0,
                        0xE0,
                        0x60,
                        0x60,
                        0xA0,
                        0xA0,
                        0x20,
                        0x20,
                        0xC0,
                        0xC0,
                        0x40,
                        0x40,
                        0x80,
                        0x80,
                        0x0,
                        0x0
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledPreciseTable()
        {
            for (int i = 0; i < PreciseTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Precise
                        PreciseTable[i] = new double[]{
                            0.00,
                            -0.45,
                            -0.90,
                            -1.35,
                            -1.80,
                            -2.25,
                            -2.69,
                            -3.14,
                            -3.59,
                            -4.04,
                            -4.49,
                            -4.94,
                            -5.38,
                            -5.83,
                            -6.28,
                            -6.73,
                            -7.18,
                            -7.63,
                            -8.08,
                            -8.52,
                            -8.97,
                            -9.42,
                            -9.87,
                            -10.32,
                            -10.77,
                            -11.21,
                            -11.66,
                            -12.11,
                            -12.56,
                            -13.01,
                            -13.46,
                            -13.90
                        };
                        break;
                    case 1: //0x80
                        PreciseTable[i] = new double[]{
                            0x0,
                            0x8,
                            0x4,
                            0xC,
                            0x2,
                            0xA,
                            0x6,
                            0xE,
                            0x1,
                            0x9,
                            0x5,
                            0xD,
                            0x3,
                            0xB,
                            0x7,
                            0xF,
                            0x10,
                            0x18,
                            0x14,
                            0x1C,
                            0x12,
                            0x1A,
                            0x16,
                            0x1E,
                            0x11,
                            0x19,
                            0x15,
                            0x1D,
                            0x13,
                            0x1B,
                            0x17,
                            0x1F        
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableA()
        {
            for (int i = 0; i < OffsetTableA.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableA[i] = new double[]{
                            0,
                            -1.08,
                            -2.160,
                            -3.240,
                            -4.320,
                            -5.400,
                            -6.480,
                            -7.560,
                            8.28,
                            7.2450,
                            6.2100,
                            5.1750,
                            4.1400,
                            3.1050,
                            2.0700,
                            1.0350
                            };
                        break;
                    case 1: //0x81
                        OffsetTableA[i] = new double[]{
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80    
                        };
                        break;
                    case 2: //0x82
                        OffsetTableA[i] = new double[]{
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7,
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7   
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableB()
        {
            for (int i = 0; i < OffsetTableB.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableB[i] = new double[]{
                            0,
                            -0.29,
                            -0.58,
                            -0.87,
                            -1.16,
                            -1.45,
                            -1.74,
                            -2.03,
                            2.32,
                            2.03,
                            1.74,
                            1.45,
                            1.16,
                            0.87,
                            0.58,
                            0.29   
                        };
                        break;
                    case 1: //0x83
                        OffsetTableB[i] = new double[]{
                            0x0,
                            0x20,
                            0x10,
                            0x30,
                            0x8,
                            0x28,
                            0x18,
                            0x38,
                            0x4,
                            0x24,
                            0x14,
                            0x34,
                            0xC,
                            0x2C,
                            0x1C,
                            0x3C  
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledRoughTable_Customer()
        {
            for (int i = 0; i < RoughTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Rough
                        RoughTable_Customer[i] = new double[]{
                            12.36,
                            14.13,
                            16.26,
                            18.73,
                            21.52,
                            24.74,
                            28.64,
                            32.74,
                            37.76,
                            43.51,
                            49.97,
                            57.56,
                            66.19,
                            76.00,
                            87.54,
                            100.00
                        };
                        break;
                    case 2: //0x81
                        RoughTable_Customer[i] = new double[]{
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0,
                            1,
                            0
                        };
                        break;
                    case 1: //0x80
                        RoughTable_Customer[i] = new double[]{
                        0xE0,
                        0xE0,
                        0x60,
                        0x60,
                        0xA0,
                        0xA0,
                        0x20,
                        0x20,
                        0xC0,
                        0xC0,
                        0x40,
                        0x40,
                        0x80,
                        0x80,
                        0x0,
                        0x0
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledPreciseTable_Customer()
        {
            for (int i = 0; i < PreciseTable.Length; i++)
            {
                switch (i)
                {
                    case 0: //Precise
                        PreciseTable_Customer[i] = new double[]{
                            100.00,
                            99.51,
                            99.09,
                            98.64,
                            98.19,
                            97.73,
                            97.22,
                            96.79,
                            96.33,
                            95.91,
                            95.48,
                            95.00,
                            94.59,
                            94.22,
                            93.69,
                            93.25,
                            92.83,
                            92.38,
                            91.90,
                            91.50,
                            91.03,
                            90.55,
                            90.09,
                            89.66,
                            89.21,
                            88.76,
                            88.29,
                            87.85,
                            87.40,
                            86.96,
                            86.49,
                            86.07
                        };
                        break;
                    case 1: //0x80
                        PreciseTable_Customer[i] = new double[]{
                            0x0,
                            0x8,
                            0x4,
                            0xC,
                            0x2,
                            0xA,
                            0x6,
                            0xE,
                            0x1,
                            0x9,
                            0x5,
                            0xD,
                            0x3,
                            0xB,
                            0x7,
                            0xF,
                            0x10,
                            0x18,
                            0x14,
                            0x1C,
                            0x12,
                            0x1A,
                            0x16,
                            0x1E,
                            0x11,
                            0x19,
                            0x15,
                            0x1D,
                            0x13,
                            0x1B,
                            0x17,
                            0x1F        
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableA_Customer()
        {
            for (int i = 0; i < OffsetTableA.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableA_Customer[i] = new double[]{
                            100.00,
                            98.94,
                            97.87,
                            96.78,
                            95.68,
                            94.60,
                            93.50,
                            92.39,
                            108.27,
                            107.27,
                            106.26,
                            105.23,
                            104.20,
                            103.16,
                            102.12,
                            101.07
                        };
                        break;
                    case 1: //0x81
                        OffsetTableA_Customer[i] = new double[]{
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x0,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80,
                            0x80    
                        };
                        break;
                    case 2: //0x82
                        OffsetTableA_Customer[i] = new double[]{
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7,
                            0x0,
                            0x4,
                            0x2,
                            0x6,
                            0x1,
                            0x5,
                            0x3,
                            0x7   
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        private void FilledOffsetTableB_Customer()
        {
            for (int i = 0; i < OffsetTableB.Length; i++)
            {
                switch (i)
                {
                    case 0: //Offset
                        OffsetTableB_Customer[i] = new double[]{
                            100.00,
                            99.72,
                            99.43,
                            99.14,
                            98.85,
                            98.56,
                            98.28,
                            98.00,
                            102.39,
                            102.10,
                            101.80,
                            101.48,
                            101.19,
                            100.89,
                            100.60,
                            100.31
                        };
                        break;
                    case 1: //0x83
                        OffsetTableB_Customer[i] = new double[]{
                            0x0,
                            0x20,
                            0x10,
                            0x30,
                            0x8,
                            0x28,
                            0x18,
                            0x38,
                            0x4,
                            0x24,
                            0x14,
                            0x34,
                            0xC,
                            0x2C,
                            0x1C,
                            0x3C  
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        //Abs(Value) decreased table
        private int LookupRoughGain(double tuningGain, double[][] gainTable)
        {
            if (tuningGain.ToString() == "Infinity")
            {
                return gainTable[0].Length - 1;
            }

            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) >= 0)
                    return i;
            }
            return gainTable[0].Length - 1;
        }

        //Abs(Value) increased table
        private int LookupPreciseGain(double tuningGain, double[][] gainTable)
        {
            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) <= 0)
                {
                    if ((i > 0) && (i < gainTable[0].Length - 1))
                    {
                        if (Math.Abs(temp - Math.Abs(gainTable[0][i - 1])) <= Math.Abs(temp - Math.Abs(gainTable[0][i])))
                            return (i - 1);
                        else
                            return i;
                    }
                }
            }
            return 0;
        }

        private int LookupOffset(ref double offset, double[][] offsetTable)
        {
            double temp = offset - offsetTable[0][0];
            int ix = 0;
            for (int i = 1; i < offsetTable[0].Length; i++)
            {
                if (Math.Abs(temp) > Math.Abs(offset - offsetTable[0][i]))
                {
                    temp = offset - offsetTable[0][i];
                    ix = i;
                }
            }
            offset = temp;
            return ix;
        }

        //Abs(Value) increased table
        private int LookupRoughGain_Customer(double tuningGain, double[][] gainTable)
        {
            if (tuningGain.ToString() == "Infinity")
            {
                return gainTable[0].Length - 1;
            }

            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) <= 0)
                    return i;
            }
            return gainTable[0].Length - 1;
        }

        //Abs(Value) decreased table
        private int LookupPreciseGain_Customer(double tuningGain, double[][] gainTable)
        {
            double temp = Math.Abs(tuningGain);
            for (int i = 0; i < gainTable[0].Length; i++)
            {
                if (temp - Math.Abs(gainTable[0][i]) >= 0)
                {
                    if ((i > 0) && (i < gainTable[0].Length - 1))
                    {
                        if (Math.Abs(temp - Math.Abs(gainTable[0][i - 1])) <= Math.Abs(temp - Math.Abs(gainTable[0][i])))
                            return (i - 1);
                        else
                            return i;
                    }
                }
            }
            return 0;
        }

        private int LookupOffset_Customer(ref double offset, double[][] offsetTable)
        {
            //Offset = 2.5/IP0_Auto
            double temp = offset - offsetTable[0][0];
            int ix = 0;
            for (int i = 1; i < offsetTable[0].Length; i++)
            {
                if (Math.Abs(temp) > Math.Abs(offset - offsetTable[0][i]))
                {
                    temp = offset - offsetTable[0][i];
                    ix = i;
                }
            }

            offset = 100 * offset / offsetTable[0][ix];  //Return (2.5/IP0_Auto)/offsetTable[ix] which will used for next lookup table operation
            return ix;
        }

        public void DisplayOperateMes(string strError, Color fontColor)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputMessage.Text.Length;
            txt_OutputMessage.AppendText(strError + "\r\n");
            //txt_OutputMessage.ForeColor = Color.Chartreuse;
            txt_OutputMessage.Select(beginIndex, length);
            txt_OutputMessage.SelectionColor = fontColor;
            txt_OutputMessage.Select(txt_OutputMessage.Text.Length, 0);//.SelectedText = "";
            txt_OutputMessage.ScrollToCaret();
            txt_OutputMessage.Refresh();
        }

        public void DisplayOperateMes(string strError)
        {
            int length = strError.Length;
            int beginIndex = txt_OutputMessage.Text.Length;
            txt_OutputMessage.AppendText(strError + "\r\n");
            //txt_OutputMessage.ForeColor = Color.Chartreuse;
            txt_OutputMessage.Select(beginIndex, length);
            //txt_OutputMessage.SelectionColor = fontColor;
            txt_OutputMessage.Select(txt_OutputMessage.Text.Length, 0);//.SelectedText = "";
            txt_OutputMessage.ScrollToCaret();
            txt_OutputMessage.Refresh();
        }

        private void DisplayAutoTrimOperateMes(string strMes, bool ifSucceeded, int step)
        {
            if (bAutoTrimTest)
            {
                if (step == 0)
                {
                    if (ifSucceeded)
                        DisplayOperateMes("-------------------Automatica Trim Start(Debug Mode)-------------------\r\n");
                    else
                        DisplayOperateMes("-------------------Automatica Trim Finished(Debug Mode)-------------------\r\n");

                    return;
                }

                //DisplayOperateMes("Step " + step + ":");
                strMes = "Step" + step.ToString() + ":" + strMes;
                if (ifSucceeded)
                {
                    strMes += " succeeded!";
                    DisplayOperateMes(strMes);
                }
                else
                {
                    strMes += " Failed!";
                    DisplayOperateMes(strMes, Color.Red);
                }
            }
        }

        private void DisplayAutoTrimOperateMes(string strMes, int step)
        {
            if (bAutoTrimTest)
            {
                strMes = "Step" + step.ToString() + ":" + strMes;
                DisplayOperateMes(strMes);
            }
        }

        private void DisplayAutoTrimOperateMes(string strMes)
        {
            if (bAutoTrimTest)
            {
                DisplayOperateMes(strMes);
            }
        }

        private void DisplayAutoTrimResult(bool ifPass)
        {
            if (ifPass)
            {
                this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                this.lbl_passOrFailed.Text = "PASS!";
            }
            else
            {
                this.lbl_passOrFailed.ForeColor = Color.Red;
                this.lbl_passOrFailed.Text = "FAIL!";
            }
        }

        private void DisplayAutoTrimResult( UInt16 errorCode)
        {
            switch ( errorCode & 0x000F )
            {
                case 0x0000:
                    this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                    this.lbl_passOrFailed.Text = "PASS!";
                    break;

                case 0x0001:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "S.N.E";
                    break;

                case 0x0002:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.R.E";
                    break;

                case 0x0003:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "O.P.E";
                    break;

                case 0x0004:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "M.T.E";
                    break;

                case 0x0005:
                    this.lbl_passOrFailed.ForeColor = Color.Red;
                    this.lbl_passOrFailed.Text = "FAIL!";
                    break;

                default:
                    break;

            
            }
        }

        private void DisplayAutoTrimResult(bool ifPass, UInt16 errorCode,string strResult)
        {
            if (ifPass)
            {
                this.lbl_passOrFailed.ForeColor = Color.DarkGreen;
                this.lbl_passOrFailed.Text = "PASS!";

                autoTrimResultIndicator.Clear();
                autoTrimResultIndicator.AppendText( "PASS!\t\t" + strResult);
                autoTrimResultIndicator.Refresh();

            }
            else
            {
                switch (errorCode & 0x000F)
                {
                    case 0x0001:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "S.N.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Sentisivity NOT Enough!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0002:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "M.R.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Marginal Read Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0003:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "O.P.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Output Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0004:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "M.T.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Master Bits Trim Error!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0005:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "H.W.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("No Hardware!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0006:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "I2C.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("I2C Comunication Error\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0007:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "O.P.C";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Operation Canceled!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x0008:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "T.M.E";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("Trim Master Bits Again!\t\t" + strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    case 0x000F:
                        this.lbl_passOrFailed.ForeColor = Color.Red;
                        this.lbl_passOrFailed.Text = "FAIL!";

                        autoTrimResultIndicator.Clear();
                        autoTrimResultIndicator.SelectionColor = Color.DarkRed;
                        autoTrimResultIndicator.AppendText("FAIL!\t\t"+ strResult);
                        autoTrimResultIndicator.Refresh();
                        break;

                    default:
                        break;


                }           
            }
        }

        private uint[] ReadBackReg1ToReg4(uint DevAddr)
        {
            uint _dev_addr = DevAddr;

            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            //Read Back 0x80~0x84
            uint _reg_addr_start = 0x80;
            uint[] _readBack_data = new uint[4];

            if (oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr_start, 4, _readBack_data) != 0)
            {
                DisplayAutoTrimOperateMes("Burst Read Back failed!");
                return null;
            }
            else
            {
                DisplayAutoTrimOperateMes("Reg1 = 0x" + _readBack_data[0].ToString("X") +
                    "\r\nReg2 = 0x" + _readBack_data[1].ToString("X") +
                    "\r\nReg3 = 0x" + _readBack_data[2].ToString("X") +
                    "\r\nReg4 = 0x" + _readBack_data[3].ToString("X"));
            }

            return _readBack_data;
        }

        private uint[] ReadBackReg1ToReg5(uint DevAddr)
        {
            uint _dev_addr = DevAddr;

            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            //Read Back 0x80~0x85
            uint _reg_addr_start = 0x80;
            uint[] _readBack_data = new uint[5];

            if (oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr_start, 5, _readBack_data) != 0)
            {
                DisplayAutoTrimOperateMes("Burst Read Back failed!");
                return null;
            }
            else
            {
                DisplayAutoTrimOperateMes("Reg1 = 0x" + _readBack_data[0].ToString("X") +
                    "\r\nReg2 = 0x" + _readBack_data[1].ToString("X") +
                    "\r\nReg3 = 0x" + _readBack_data[2].ToString("X") +
                    "\r\nReg4 = 0x" + _readBack_data[3].ToString("X") +
                    "\r\nReg5 = 0x" + _readBack_data[4].ToString("X"));
            }

            return _readBack_data;
        }

        private bool CheckReg1ToReg4(uint[] readBackData, uint Reg1, uint Reg2, uint Reg3, uint Reg4)
        {
            if (readBackData == null)
                return false;

            if ((readBackData[0] >= Reg1) &&
                (readBackData[1] >= Reg2) &&
                (readBackData[2] >= Reg3) &&
                (readBackData[3] >= Reg4))
                return true;
            else if((readBackData[0] == Reg1) &&
                    (readBackData[1] == Reg2) &&
                    (readBackData[2] == Reg3) &&
                    (readBackData[3] == Reg4))
                return true;
            else
                return false;
        }

        private bool MarginalCheckReg1ToReg4(uint[] readBackData, uint _dev_addr, double testGain_Auto)
        {
            if (readBackData == null)
                return false;

            #region Setup Marginal Read
            uint _reg_addr = 0x55;
            uint _reg_data = 0xAA;
            oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

            _reg_addr = 0x43;
            _reg_data = 0x0E;

            bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
            if (writeResult)
                DisplayOperateMes("Marginal Read succeeded!\r\n");
            else
                DisplayOperateMes("I2C write failed, Marginal Read Failed!\r\n", Color.Red);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayOperateMes("Delay 50ms");

            _reg_addr = 0x43;
            _reg_data = 0x0;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
            //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            if (writeResult)
                DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
            else
                DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);
            #endregion Setup Marginal Read

            uint[] _MarginalreadBack_data = new uint[4];
            _MarginalreadBack_data = ReadBackReg1ToReg4(_dev_addr);

            if ((readBackData[0] == _MarginalreadBack_data[0]) &&
                (readBackData[1] == _MarginalreadBack_data[1]) &&
                (readBackData[2] == _MarginalreadBack_data[2]) &&
                (readBackData[3] == _MarginalreadBack_data[3]))
                return true;
            else
            {
                //if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x20) == 0x20 )
                //{
                //    return false;
                //}
                //else if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x40) == 0x40 && (readBackData[0] & 0x20) == 0x20 )
                //{
                //    return false;
                //}
                //else if (((readBackData[0] ^ _MarginalreadBack_data[0]) & 0x80) == 0x80 && (readBackData[0] & 0x40) == 0x40 && (readBackData[0] & 0x20) == 0x20)
                //{
                //    return false;
                //}
                //else if (((readBackData[1] ^ _MarginalreadBack_data[1]) & 0x80)==0x80 || ((readBackData[2] ^ _MarginalreadBack_data[2]) & 0x01 )== 0x01 )
                //{
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
                return false;
            }
        }

        private bool FuseClockOn(uint _dev_addr, double fusePulseWidth, double fuseDurationTime, int step)
        {
            //0x03->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x03;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 1 before Fuse Clock", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 2 before Fuse Clock", true, step);
            else
            {
                return false; ;
            }

            //Delay 50ms
            Thread.Sleep(200);
            DisplayAutoTrimOperateMes("Delay 200ms", step);

            //Fuse 
            if (oneWrie_device.FuseClockSwitch(fusePulseWidth, fuseDurationTime))
                DisplayAutoTrimOperateMes("Fuse Clock On", true, step);
            else
            {
                return false;
            }

            //Delay 700ms -> changed to 100ms @ 2014-09-04
            Thread.Sleep(100);
            DisplayAutoTrimOperateMes("Delay 100ms", step);
            return true;
        }

        private bool FuseClockOn(uint _dev_addr, double fusePulseWidth, double fuseDurationTime, int delayTime , int step)
        {
            //0x03->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x03;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 1 before Fuse Clock", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("I2C Write 2 before Fuse Clock", true, step);
            else
            {
                return false; ;
            }

            //Delay 50ms
            Thread.Sleep(delayTime);
            DisplayAutoTrimOperateMes("Delay x00ms", step);

            //Fuse 
            if (oneWrie_device.FuseClockSwitch(fusePulseWidth, fuseDurationTime))
                DisplayAutoTrimOperateMes("Fuse Clock On", true, step);
            else
            {
                return false;
            }

            //Delay 700ms -> changed to 100ms @ 2014-09-04
            Thread.Sleep(100);
            DisplayAutoTrimOperateMes("Delay 100ms", step);
            return true;
        }

        private bool WriteBlankFuseCode(uint _dev_addr, uint _reg1Addr, uint _reg2Addr, uint _reg3Addr, int step)
        {
            uint _reg_Value = 00;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg1Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.1"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg2Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.2"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg3Addr, _reg_Value))
                DisplayAutoTrimOperateMes(string.Format("Write 0 to other 3 Regs:No.3"), true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            return true;
        }

        private bool WriteMasterBit(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x07;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool WriteMasterBit0(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x01;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool WriteMasterBit1(uint _dev_addr, int step)
        {
            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x81, 0x82, step))
                return false;
            //Reg83 <-- 0x0
            uint _reg_Addr = 0x83;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write 0 to Reg4", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }

            //Reg84, Fuse with master bit
            _reg_Addr = 0x84;
            _reg_Value = 0x02;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg5(0x" + _reg_Value.ToString("X") + ")", true, step);
            else
            {
                DisplayAutoTrimResult(false);
                return false;
            }
            return true;
        }

        private bool ResetReg43And44(uint _dev_addr, int step)
        {
            //0x00->0x43
            uint _reg_Addr = 0x43;
            uint _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Reset Reg0x43 before new bit Fuse", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);

            //0xAA->0x44
            _reg_Addr = 0x44;
            _reg_Value = 0x0;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Reset Reg0x44 before new bit Fuse", true, step);
            else
            {
                return false;
            }

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", step);
            return true;
        }
        #endregion Methods

        #region Events
        private void contextMenuStrip_Copy_MouseUp(object sender, MouseEventArgs e)
        {
            this.txt_OutputMessage.Copy();
        }

        private void contextMenuStrip_Paste_Click(object sender, EventArgs e)
        {
            this.txt_OutputMessage.Paste();
        }

        private void contextMenuStrip_Clear_MouseUp(object sender, MouseEventArgs e)
        {
            this.txt_OutputMessage.Text = null;
            //解决Scroll Bar的刷新问题。
            this.txt_OutputMessage.ScrollBars = RichTextBoxScrollBars.None;
            this.txt_OutputMessage.ScrollBars = RichTextBoxScrollBars.Both;
        }

        private void contextMenuStrip_SelAll_Click(object sender, EventArgs e)
        {
            this.txt_OutputMessage.SelectAll();
        }

        private void txt_TargetGain_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            try
            {
                //temp = (4500d - 2000d) / double.Parse(this.txt_TargetGain.Text);
                temp = 2000d / double.Parse(this.txt_TargetGain.Text);
            }
            catch
            {
                temp = 0;
            }

            if (temp == 0)
                this.txt_FullScale.Text = "Error";
            else
                this.txt_FullScale.Text = temp.ToString();
        }

        private void btn_PowerOn_OWCI_ADC_Click(object sender, EventArgs e)
        {
            if (oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON))
                DisplayOperateMes("Power on succeeded!\r\n");
            else
                DisplayOperateMes("Power on failed!\r\n");
        }

        private void btn_PowerOff_OWCI_ADC_Click(object sender, EventArgs e)
        {
            if (oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF))
                DisplayOperateMes("Power off succeeded!\r\n");
            else
                DisplayOperateMes("Power off failed!\r\n");
        }

        private void btn_enterNomalMode_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;
            Thread.Sleep(100);

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                _reg_addr = 0x42;
                _reg_data = 0x04;

                bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Enter Nomal Mode succeeded!\r\n");
                else
                    DisplayOperateMes("I2C write failed, Enter Normal Mode Failed!\r\n", Color.Red);
            }
            catch
            {
                DisplayOperateMes("Enter Normal Mode Failed!\r\n", Color.Red);
            }

            Thread.Sleep(100);

            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn.Checked = true;
        }

        private void btn_Vout_15A_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn.Checked = true;

            IP15 = AverageVout("15 A");
            DisplayOperateMes("Vout @ 15A = " + IP15.ToString("F3"));
            //DisplayOperateMes("Vout @ 15A = " + (IP15 * 5d / 4096).ToString("F3"));
        }

        private void btn_Vout_10A_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn.Checked = true;

            IP10 = AverageVout("10 A");
            DisplayOperateMes("Vout @ 10A = " + IP10.ToString("F3"));
        }

        private void btn_Vout_5A_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn.Checked = true;

            IP5 = AverageVout("5 A");
            DisplayOperateMes("Vout @ 5A = " + IP5.ToString("F3"));
        }

        private void btn_Vout_0A_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            rbt_signalPathSeting_AIn.Checked = true;

            IP0 = AverageVout("0 A");
            DisplayOperateMes("Vout @ 0A = " + IP0.ToString("F3"));
        }

        private void btn_ADCReset_Click(object sender, EventArgs e)
        {
            if (!oneWrie_device.ADCReset())
                DisplayOperateMes("ADC Reset Failed!\r\n", Color.Red);
            else
                DisplayOperateMes("ADC Reset succeeded!");
        }

        private void btn_roughTrim_Click(object sender, EventArgs e)
        {
            string baseMes = "Rough Trim Operation:";
            DisplayOperateMes(baseMes);

            ////Test Lookup Table
            //IP15 = 4.244;
            //IP10 = 3.643;
            //IP5 = 3.048;
            //IP0 = 2.447;

            //DisplayOperateMes("before gain calc: \r\nIP15 = " + IP15.ToString() +
            //    "\r\nIP10 = " + IP10.ToString() + "\r\nIP5 = " + IP5.ToString() + "\r\nIP0 = " + IP0.ToString());
            double testGain = GainCalculate();
            DisplayOperateMes("Test Gain = " + testGain.ToString());
            double targetGain = 0;
            try
            {
                targetGain = double.Parse(this.txt_TargetGain.Text);
            }
            catch
            {
                //MessageBox.Show("Pls Input Correct Target Gain~");
                return;
            }

            double gainTuning = 100 * GainTuningCalc(testGain, targetGain);   //计算修正值，供查表用
            DisplayOperateMes("Choose Gain = " + gainTuning.ToString("F4") + "%");

            int ix = LookupRoughGain(gainTuning, RoughTable);
            DisplayOperateMes("Rough Gain Index = " + ix.ToString() + ";Choosed Gain = " + RoughTable[0][ix].ToString() + "%");

            Reg80Value = Convert.ToUInt32(RoughTable[1][ix]);
            Reg81Value = Convert.ToUInt32(RoughTable[2][ix]);
            DisplayOperateMes("Reg1 Value = 0x" + Reg80Value.ToString("X"));
            DisplayOperateMes("Reg2 Value = 0x" + Reg81Value.ToString("X") + "\r\n");

            this.txt_reg80.Text = "0x" + Reg80Value.ToString("X");
            this.txt_reg81.Text = "0x" + Reg81Value.ToString("X");

            //todo Power Control
            //MessageBox.Show("Please Change Power");
        }

        private void btn_preciseTrim_Click(object sender, EventArgs e)
        {
            string baseMes = "Precise Trim Operation:";
            DisplayOperateMes(baseMes);

            ////Test Lookup Table
            //IP15 = 2.952;
            //IP10 = 2.8183;
            //IP5 = 2.6845;
            //IP0 = 2.5502;

            double testGain = GainCalculate();
            DisplayOperateMes("Test Gain = " + testGain.ToString());
            double targetGain = 0;
            try
            {
                targetGain = double.Parse(this.txt_TargetGain.Text);
            }
            catch
            {
                //MessageBox.Show("Pls Input Correct Target Gain~");
                return;
            }

            double gainTuning = 100 * GainTuningCalc(testGain, targetGain);   //计算修正值，供查表用
            DisplayOperateMes("Choose Gain = " + gainTuning.ToString("F4") + "%");

            int ix = LookupPreciseGain(gainTuning, PreciseTable);
            DisplayOperateMes("Precise Gain Index = " + ix.ToString() + ";Choosed Gain = " + PreciseTable[0][ix].ToString() + "%");

            Reg80Value += Convert.ToUInt32(PreciseTable[1][ix]);
            DisplayOperateMes("Reg1 Value = " + Reg80Value.ToString() + "(+ 0x" + Convert.ToInt32(PreciseTable[1][ix]).ToString("X") + ")\r\n");

            this.txt_reg80.Text = "0x" + Reg80Value.ToString("X");

            //todo Power Control
            //MessageBox.Show("Change Power");
        }

        private void btn_offset_Click(object sender, EventArgs e)
        {
            string baseMes = "Offset Trim Operation:";
            DisplayOperateMes(baseMes);
            double offsetTuning = 100 * OffsetTuningCalc();
            DisplayOperateMes("Lookup offset = " + offsetTuning.ToString("F4") + "%");

            int ixA = LookupOffset(ref offsetTuning, OffsetTableA);
            int ixB = LookupOffset(ref offsetTuning, OffsetTableB);

            DisplayOperateMes("Offset TableA chose Index = " + ixA.ToString() + ";Choosed OffsetA = " + OffsetTableA[0][ixA].ToString("F4"));
            DisplayOperateMes("Offset TableB chose Index = " + ixB.ToString() + ";Choosed OffsetB = " + OffsetTableB[0][ixB].ToString("F4"));

            Reg81Value += Convert.ToUInt32(OffsetTableA[1][ixA]);
            Reg82Value += Convert.ToUInt32(OffsetTableA[2][ixA]);
            DisplayOperateMes("Reg2 Value = " + Reg81Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableA[1][ixA]).ToString("X") + ")\r\n");
            DisplayOperateMes("Reg3 Value = " + Reg82Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableA[2][ixA]).ToString("X") + ")\r\n");

            this.txt_reg81.Text = "0x" + Reg81Value.ToString("X");
            this.txt_reg82.Text = "0x" + Reg82Value.ToString("X");

            Reg83Value += Convert.ToUInt32(OffsetTableB[1][ixB]);
            DisplayOperateMes("Reg4 Value = " + Reg83Value.ToString() + "(+ 0x" + Convert.ToInt32(OffsetTableB[1][ixB]).ToString("X") + ")\r\n");

            this.txt_reg83.Text = "0x" + Reg83Value.ToString("X");

            //todo Power Control
            //MessageBox.Show("Change Power");
        }

        private void btn_writeFuseCode_Click(object sender, EventArgs e)
        {
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);

            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;


            bool fuseMasterBit = false;
            DialogResult dr = MessageBox.Show("Do you want to Fuse master bit?", "Fuse master bit??", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
                return;
            else if (dr == System.Windows.Forms.DialogResult.Yes)
                fuseMasterBit = true;

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                //Enter test mode
                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                //Reg80
                temp = this.txt_reg80.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _reg_Addr = 0x80;
                uint _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg1(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg1 Failed!", Color.Red);

                //Reg81
                temp = this.txt_reg81.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x81;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg2(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg2 Failed!", Color.Red);

                //Reg82
                temp = this.txt_reg82.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x82;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg3(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg3 Failed!", Color.Red);

                //Reg83
                temp = this.txt_reg83.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                _reg_Addr = 0x83;
                _reg_Value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayOperateMes("Write Reg4(0x" + _reg_Value.ToString("X") + ") succeeded!");
                else
                    DisplayOperateMes("Write Reg4 Failed!", Color.Red);

                if (fuseMasterBit)
                {
                    //Reg84
                    _reg_Addr = 0x84;
                    _reg_Value = 0x07;

                    if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                        DisplayOperateMes("Master bit fused succeeded!");
                    else
                        DisplayOperateMes("Master bit fused Failed!", Color.Red);
                }

            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }
        }

        private void txt_reg80_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg80.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (this.Reg80Value == regValue)
                    return;
                else
                {
                    this.Reg80Value = regValue;
                    DisplayOperateMes("Enter Reg1 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg1 value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg80.Text = "0x" + this.Reg80Value.ToString("X2");
            }
        }

        private void txt_reg81_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg81.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (Reg81Value == regValue)
                    return;
                else
                {
                    this.Reg81Value = regValue;
                    DisplayOperateMes("Enter Reg2 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg2 value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg81.Text = "0x" + this.Reg81Value.ToString("X2");
            }
        }

        private void txt_reg82_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg82.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                if (Reg82Value == regValue)
                    return;
                else
                {
                    this.Reg82Value = regValue;
                    DisplayOperateMes("Enter Reg3 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg3 value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg82.Text = "0x" + this.Reg82Value.ToString("X2");
            }
        }

        private void txt_reg83_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_reg83.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                if (temp.Length > 2)
                    temp = temp.Substring(0, 2);
                uint regValue = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
                if (Reg83Value == regValue)
                    return;
                else
                {
                    this.Reg83Value = regValue;
                    DisplayOperateMes("Enter Reg3 value succeeded!");
                }
            }
            catch
            {
                DisplayOperateMes("Enter Reg value failed!", Color.Red);
            }
            finally
            {
                this.txt_reg83.Text = "0x" + this.Reg83Value.ToString("X2");
            }
        }

        private void txt_RegValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt_Regx = sender as TextBox;
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            string str = "\r\b0123456789abcdefABCDEF";//This will allow the user to enter numeric HEX values only.

            e.Handled = !(str.Contains(e.KeyChar.ToString()));

            if (e.Handled)
                return;
            else
            {
                if (e.KeyChar.ToString() == "\r")
                {
                    RegTextChangedDisplay(txt_Regx);
                    txt_Regx.SelectionStart = txt_Regx.Text.Length;
                    //try
                    //{
                    //    //string temp = txt_Regx.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                    //    //uint _reg_value = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);
                    //    RegTextChangedDisplay(txt_Regx);
                    //}
                    //catch
                    //{
                    //    txt_Regx.Text = this.
                    //}
                }
            }

            #region Comment out
            //if (txt_Regx.Text.Length >= 2)
            //{
            //    if (txt_Regx.Text.StartsWith("0x") | txt_Regx.Text.StartsWith("0X"))
            //    {
            //        if (txt_Regx.Text.Length >= 4)
            //        {
            //            if ((e.KeyChar == '\b') | ((txt_Regx.SelectionLength >= 1) & (txt_Regx.SelectionStart >= 2)) |
            //                           (txt_Regx.SelectionLength == txt_Regx.Text.Length))
            //            {
            //                e.Handled = !(str.Contains(e.KeyChar.ToString()));
            //                RegTextChangedDisplay(txt_Regx);
            //                return;
            //            }
            //            else
            //            {
            //                e.Handled = true;
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (e.KeyChar != '\b' | (txt_Regx.SelectionLength == txt_Regx.Text.Length))
            //        {
            //            e.Handled = true;
            //            txt_Regx.Text = "0x" + txt_Regx.Text;
            //            RegTextChangedDisplay(txt_Regx);
            //            return;
            //        }

            //    }
            //}
            //e.Handled = !(str.Contains(e.KeyChar.ToString()));
            //if (e.Handled | txt_Regx.Text.StartsWith("0x") | txt_Regx.Text.StartsWith("0X"))
            //{
            //    return;
            //}
            //else
            //{
            //    txt_Regx.Text = "0x" + txt_Regx.Text;
            //    RegTextChangedDisplay(txt_Regx);
            //    txt_Regx.SelectionStart = txt_Regx.Text.Length;
            //}
            #endregion Comment out
        }

        private void RegTextChangedDisplay(TextBox txtReg)
        {
            if (txtReg == this.txt_reg80)
                this.txt_reg80_TextChanged(null, null);
            else if (txtReg == this.txt_reg81)
                this.txt_reg81_TextChanged(null, null);
            else if (txtReg == this.txt_reg82)
                this.txt_reg82_TextChanged(null, null);
            else if (txtReg == this.txt_reg83)
                this.txt_reg83_TextChanged(null, null);
        }

        private void rbt_5V_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_5V.Checked)
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_5V);
            else
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_EXT);

            string message;
            if (rbt_5V.Checked)
                message = "VDD chose 5V";
            else
                message = "VDD chose external power";

            if (setResult)
            {
                message += " succeeded!\r\n";
                DisplayOperateMes(message);
            }
            else
            {
                message += " Failed!\r\n";
                DisplayOperateMes(message, Color.Red);
            }
        }

        private void rbt_withCap_Vout_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_withCap_Vout.Checked)
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
            else
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);

            string message;
            if (rbt_withCap_Vout.Checked)
                message = "Vout with Cap set";
            else
                message = "Vout without Cap set";

            if (setResult)
            {
                message += " succeeded!\r\n";
                DisplayOperateMes(message);
            }
            else
            {
                message += " Failed!\r\n";
                DisplayOperateMes(message, Color.Red);
            }
        }

        private void rbt_withCap_Vref_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            if (rbt_withCap_Vref.Checked)
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITH_CAP);
            else
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITHOUT_CAP);

            string message;
            if (rbt_withCap_Vref.Checked)
                message = "Vref with Cap set";
            else
                message = "Vref without Cap set";
            if (setResult)
            {
                message += " succeeded!\r\n";
                DisplayOperateMes(message);
            }
            else
            {
                message += " Failed!\r\n";
                DisplayOperateMes(message, Color.Red);
            }
        }

        private void rbt_signalPathSeting_CheckedChanged(object sender, EventArgs e)
        {
            bool setResult;
            string message;
            if (rbt_signalPathSeting_Vout.Checked && rbt_signalPathSeting_AIn.Checked)
            {
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
                message = "Vout to VIn set";
            }
            else if (rbt_signalPathSeting_Vout.Checked && rbt_signalPathSeting_Config.Checked)
            {
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
                message = "Vout to CONFIG set";
            }
            else if (rbt_signalPathSeting_Vref.Checked && rbt_signalPathSeting_AIn.Checked)
            {
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VREF);
                message = "Vref to VIn set";
            }
            else if (rbt_signalPathSeting_Vref.Checked && rbt_signalPathSeting_Config.Checked)
            {
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VREF);
                message = "Vref to CONFIG set";
            }
            else
            {
                message = "Signal path routing failed!\r\n";
                return;
            }

            if (setResult)
            {
                message += " succeeded!\r\n";
                DisplayOperateMes(message);
            }
            else
            {
                message += " Failed!\r\n";
                DisplayOperateMes(message, Color.Red);
            }
        }

        private void btn_burstRead_Click(object sender, EventArgs e)
        {
            //set pilot firstly
            numUD_pilotwidth_ow_ValueChanged(null, null);

            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                //Read Back 0x80~0x85
                uint _reg_addr_start = 0x80;
                uint[] _readBack_data = new uint[5];

                if (oneWrie_device.I2CRead_Burst(_dev_addr, _reg_addr_start, 5, _readBack_data) == 0)
                {
                    DisplayOperateMes("Reg1 = 0x" + _readBack_data[0].ToString("X") +
                        "\r\nReg2 = 0x" + _readBack_data[1].ToString("X") +
                        "\r\nReg3 = 0x" + _readBack_data[2].ToString("X") +
                        "\r\nReg4 = 0x" + _readBack_data[3].ToString("X") +
                        "\r\nReg5 = 0x" + _readBack_data[4].ToString("X"));
                }
                else
                {
                    DisplayOperateMes("Read Back Failed!");
                }
            }
            catch
            {
                DisplayOperateMes("Read Back Failed!\r\n", Color.Red);
            }
        }

        private void btn_MarginalRead_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                _reg_addr = 0x43;
                _reg_data = 0x0E;

                bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Marginal Read succeeded!\r\n");
                else
                    DisplayOperateMes("I2C write failed, Marginal Read Failed!\r\n", Color.Red);

                //Delay 100ms
                Thread.Sleep(100);
                DisplayOperateMes("Delay 100ms");

                _reg_addr = 0x43;
                _reg_data = 0x0;

                writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
                else
                    DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);
            }
            catch
            {
                DisplayOperateMes("Marginal Read Failed!\r\n", Color.Red);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            rbt_signalPathSeting_Config.Checked = true;

            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint _dev_addr = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                uint _reg_addr = 0x55;
                uint _reg_data = 0xAA;
                oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);

                _reg_addr = 0x43;
                _reg_data = 0x0B;

                bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reload succeeded!\r\n");
                else
                    DisplayOperateMes("I2C write failed, Reload Failed!\r\n", Color.Red);

                //Delay 100ms
                Thread.Sleep(100);
                DisplayOperateMes("Delay 100ms");

                _reg_addr = 0x43;
                _reg_data = 0x0;

                writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
                else
                    DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);
            }
            catch
            {
                DisplayOperateMes("Reload Failed!\r\n", Color.Red);
            }
        }


        private void cmb_TargetGain_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_TargetGain_Customer.SelectedIndex != ix_IPx_Customer)
            {
                double targetGain = 0;
                try
                {
                    int tempIndex = this.cmb_TargetGain_Customer.SelectedItem.ToString().IndexOf('m');
                    string tempTargetG = this.cmb_TargetGain_Customer.SelectedItem.ToString().Remove(tempIndex).TrimEnd();
                    targetGain = double.Parse(tempTargetG);
                }
                catch
                {
                    this.cmb_TargetGain_Customer.SelectedIndex = ix_IPx_Customer;
                    return;
                }

                DialogResult dr = MessageBox.Show(string.Format("Please confirm the Target Gain is {0} mV/A?", targetGain), "Target Gain", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                    this.cmb_TargetGain_Customer.SelectedIndex = ix_IPx_Customer;
                else
                    ix_IPx_Customer = this.cmb_TargetGain_Customer.SelectedIndex;
            }

        }

        private void cmb_IPxForCalc_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            StrIPx_Auto = (sender as ComboBox).SelectedItem.ToString().Substring(2) + "A";
            selectedCurrent_Auto = uint.Parse(StrIPx_Auto.TrimEnd('A'));
        }

        //bool bAutoTrimTest = false;
        private void btn_AutomaticaTrim_Click(object sender, EventArgs e)
        {
            #region 1. Define variables
            bool setResult;
            string message;
            int judgeRegValueLoopCount = 3;
            double tempV = 0;
            double fusePulseWidth = 200;    //ns
            double fuseDurationTime = 10;   //ms
            uint sampleNum = 1024;

            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;

            DisplayAutoTrimOperateMes("", true, 0);  //Start
            #endregion

            #region 2. Start! Reset variable value, warning target gain.
            this.lbl_passOrFailed.ForeColor = Color.Black;
            this.lbl_passOrFailed.Text = "START!";

            //Clear All Parameters
            IP0_Auto = 0;
            IPx_Auto = 0;
            Reg80Value = 0;
            Reg81Value = 0;
            Reg82Value = 0;
            Reg83Value = 0;
            DisplayAutoTrimOperateMes("Start Operation!");

            double targetGain = 0;
            try
            {
                int tempIndex = this.cmb_TargetGain_Customer.SelectedItem.ToString().IndexOf('m');
                string tempTargetG = this.cmb_TargetGain_Customer.SelectedItem.ToString().Remove(tempIndex).TrimEnd();
                targetGain = double.Parse(tempTargetG);
                DisplayAutoTrimOperateMes(string.Format("TargetGain = {0} mV/A", targetGain));
            }
            catch
            {
                DisplayAutoTrimResult(false);
                return;
            }

            //DialogResult dr = MessageBox.Show(string.Format("Please confirm the Target Gain is {0} mV/A?",targetGain), "Target Gain", MessageBoxButtons.OKCancel);
            //if (dr == DialogResult.Cancel)
            //{
            //    DisplayAutoTrimResult(false);
            //    return;
            //}
            #endregion

            #region 3. Power on and Capture Vout @ 15A and 0A for calc
            #region 3.1 Power 0n @ 5V

            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_5V);
            if ( setResult )
            {
                message = "Set VDD from 5V";
                DisplayAutoTrimOperateMes(message, setResult, 31);
            }
            else
            {
                message = "No Hardware!";
                DisplayAutoTrimOperateMes(message, setResult, 31);
                DisplayAutoTrimResult(false, 0x0005, "Hardware Connection Error!");
                return;
            }
            

            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
            message = "Set VDD Power On";
            DisplayAutoTrimOperateMes(message, setResult, 31);

            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
            message = "Set Vout with Cap";
            DisplayAutoTrimOperateMes(message, setResult, 31);

            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITH_CAP);
            message = "Set Vref with Cap";
            DisplayAutoTrimOperateMes(message, setResult, 31);

            //setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VREF);
            //message = "Set Vref to VIN";
            //DisplayAutoTrimOperateMes(message, setResult,1);

            Thread.Sleep(100);  //Delay 100ms
            DisplayAutoTrimOperateMes("Delay 10ms", 31);
            #endregion

            #region 3.2 Capture Vout @ 15A
            //Set Config to Vout
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            message = "Set Config to Vout";
            DisplayAutoTrimOperateMes(message, setResult, 32);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 32);

            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            if (oneWrie_device.I2CRead_Single(_dev_addr, _reg_Addr) == 0x00)
            {
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x42;
            _reg_Value = 0x04;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            //Vout to Vin
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            message = "Set Vin to Vout";
            DisplayAutoTrimOperateMes(message, setResult, 32);

            //Change Current to IPx A
            DialogResult dr = MessageBox.Show(String.Format("Please Change Current To {0}A",selectedCurrent_Auto), "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                //DisplayAutoTrimResult(false)
                //this.lbl_passOrFailed.ForeColor = Color.Green;
                //this.lbl_passOrFailed.Text = "C.N.D!"; ;
                DisplayAutoTrimResult(false, 0x0007, "Auto Trim Canceled!");
                return;
            }

            //Delay 200ms
            Thread.Sleep(200);
            DisplayAutoTrimOperateMes("Delay 200ms", 32);

            //Capture Vout@IPx
            IPx_Auto = AverageVout_Customer(StrIPx_Auto, sampleNum);
            DisplayAutoTrimOperateMes(string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"), StrIPx_Auto), 32);

            //Modified @ 2014-09-02 by doc v1.3.9.7
            //double temp = 2.5+ targetGain * 15d/1000d;
            if (!(IPx_Auto <= 5 && IPx_Auto >= 2))
            {
                DisplayAutoTrimOperateMes(String.Format("Vout = {0}, Vout is abnormal!", IPx_Auto), 32);
                //DisplayAutoTrimResult(false);
                //this.lbl_passOrFailed.ForeColor = Color.Red;
                //this.lbl_passOrFailed.Text = "O.P.E!";
                DisplayAutoTrimResult(false, 0x0003, string.Format("Vout Error!\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                return;
            }
            //else if( IP15_Auto < temp)
            //{
            //    MessageBox.Show("Sensitivity NOT Enough！");
            //    DisplayAutoTrimOperateMes(String.Format("Vout({0}) < {1}, Sensitivity NOT Enough！", IP15_Auto, temp), 2);
            //    DisplayAutoTrimResult(false);
            //    return;
            //}
            #endregion

            #region 3.3 Capture Vout @ 0A
            dr = MessageBox.Show("Please Change Current To 0A", "Change Current", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                //DisplayAutoTrimResult(false);
                //this.lbl_passOrFailed.ForeColor = Color.Red;
                //this.lbl_passOrFailed.Text = "C.N.E!";
                DisplayAutoTrimResult(false, 0x0007, "Operation Canceled!");
                return;
            }

            //Delay 200ms
            Thread.Sleep(200);
            DisplayAutoTrimOperateMes("Delay 200ms", 33);

            IP0_Auto = AverageVout_Customer("0 A", sampleNum);
            DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 33);
            #endregion
            #endregion

            #region 4.Get Rough ,Precision trim value;Auto re-power and captrue Vout@0A; offset trim value
            //Real gain calculate by Vout@15A and Vout@0A

            #region 4.1 Calc gain trim code
            double testGain = GainCalculateForCustomer(IPx_Auto,IP0_Auto,selectedCurrent_Auto);

            if (testGain < (targetGain - 1.5))
            {
                //MessageBox.Show("Sensitivity NOT Enough！");
                DisplayAutoTrimOperateMes(String.Format("TestGain({0}) < (targetGain - 1.5)({1}), Sensitivity NOT Enough！", testGain.ToString("F1"), targetGain - 1.5), 41);
                DisplayAutoTrimResult(false, 0x0001, "Test Gain = "+testGain.ToString("F1") + " < " +targetGain.ToString("F1") + " - 1.5");
                //this.lbl_passOrFailed.ForeColor = Color.Red;
                //this.lbl_passOrFailed.Text = "S.N.E!";

                #region 4.1.1 Re-power on at 6V
                //VDD to EXT
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_EXT);
                message = "Set VDD to EXT";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Power Off
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
                message = "Set VDD Power Off";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Delay 500ms
                Thread.Sleep(500);
                DisplayAutoTrimOperateMes("Delay 500ms", 41);

                //Power On
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
                message = "Set VDD Power On";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Delay 50ms
                Thread.Sleep(50);
                DisplayAutoTrimOperateMes("Delay 50ms", 41);

                #endregion

                #region 4.1.2 Setup signal path for Reg operation and Fuse
                //Vout without cap
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);
                message = "Set Vout without Cap";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Vref without cap
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITHOUT_CAP);
                message = "Set Vref without Cap";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Vout to Config
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
                message = "Set Vout to CONFIG";
                DisplayAutoTrimOperateMes(message, setResult, 41);

                //Delay 50ms
                Thread.Sleep(100);
                DisplayAutoTrimOperateMes("Delay 100ms", 41);
                #endregion

                #region 4.1.3 Enter test mode and write NC_1X bit
                //Changed @ 2014-09-02 by doc v1.3.9.7
                _reg_Addr = 0x55;
                _reg_Value = 0xAA;
                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayAutoTrimOperateMes("Enter Test Mode Before Fuse Code", true, 41);
                else
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }


                //Delay 50ms
                Thread.Sleep(50);
                DisplayAutoTrimOperateMes("Delay 50ms", 41);

                _reg_Addr = 0x83;
                _reg_Value = 0x01;
                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayAutoTrimOperateMes("Write NC_1X bit", true, 41);
                else
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }

                //return;



                #endregion

                #region 4.1.4 Fuse clock on
                if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 400, 41))
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }
                #endregion

                MessageBox.Show("Try again！");

                return;
            }

            DisplayAutoTrimOperateMes("Test Gain = " + testGain.ToString("F3"), 41);
            //double targetGain = 0;
            //try
            //{
            //    targetGain = double.Parse(this.txt_TargetGain_CustomerTab.Text);
            //}
            //catch
            //{
            //    DisplayAutoTrimResult(false);
            //    return;
            //}

            //Calculate gainTuing for Lookup Table
            double gainTuning = 100 * GainTuningCalc_Customer(testGain, targetGain);   //计算修正值，供查表用
            DisplayAutoTrimOperateMes("Choose Gain = " + gainTuning.ToString("F4") + "%", 41);

            //Rough Lookup Table
            int ix = LookupRoughGain_Customer(gainTuning, RoughTable_Customer);
            DisplayAutoTrimOperateMes("Rough Gain Index = " + ix.ToString() + ";Choosed Gain = " + RoughTable_Customer[0][ix].ToString() + "%", 41);

            Reg80Value = Convert.ToUInt32(RoughTable_Customer[1][ix]);
            Reg81Value = Convert.ToUInt32(RoughTable_Customer[2][ix]);
            DisplayAutoTrimOperateMes("@Rough: Reg1 Value = 0x" + Reg80Value.ToString("X"), 41);
            DisplayAutoTrimOperateMes("@Rough: Reg2 Value = 0x" + Reg81Value.ToString("X"), 41);

            //this.txt_reg80.Text = "0x" + Reg80Value.ToString("X");
            //this.txt_reg81.Text = "0x" + Reg81Value.ToString("X");

            //Precise Lookup Table
            gainTuning = 100 * GainTuningCalc_Customer(RoughTable_Customer[0][ix], gainTuning);   //x/y: x 为供rough查表用的值，y为rough查表得到的值，计算修正值，供查表用
            ix = LookupPreciseGain_Customer(gainTuning, PreciseTable_Customer);
            DisplayAutoTrimOperateMes("Precise Gain Index = " + ix.ToString() + ";Choosed Gain = " + PreciseTable_Customer[0][ix].ToString() + "%", 41);

            Reg80Value += Convert.ToUInt32(PreciseTable_Customer[1][ix]);
            DisplayAutoTrimOperateMes("@Precise: Reg1 Value = " + Reg80Value.ToString("X") + "(+ 0x" + Convert.ToInt32(PreciseTable_Customer[1][ix]).ToString("X") + ")", 41);

            //this.txt_reg80.Text = "0x" + Reg80Value.ToString("X");

            //Auto Re-Power(Power off;delay 200ms;power on;delay 200ms;Vout to CONFIG;Change gain's fuse code without master bit) 
            //Delay 50ms; enter normal mode;Vout to AIN;capture Vout@0A for offset calculation

            #endregion

            #region 4.2 Auto-Repower at 5V
            //Power Off
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
            message = "Set VDD Power Off";
            DisplayAutoTrimOperateMes(message, setResult, 42);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 42);

            //Vout to CONFIG
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            message = "Set Vout to CONFIG";
            DisplayAutoTrimOperateMes(message, setResult, 42);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 42);

            //Power On
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
            message = "Set VDD Power On";
            DisplayAutoTrimOperateMes(message, setResult, 42);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 42);
            #endregion Auto-Repower

            #region 4.3 Enter test mode, write Gain trim Code to calc offset trim code
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Change Gain's Fuse Code", true, 43);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            //Reg80
            _reg_Addr = 0x80;
            _reg_Value = Reg80Value;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg1(0x" + _reg_Value.ToString("X") + ")", true, 43);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            //Reg81
            _reg_Addr = 0x81;
            _reg_Value = Reg81Value;

            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write Reg2(0x" + _reg_Value.ToString("X") + ")", true, 43);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
            //#endregion 
            //Delay 50ms
            //Thread.Sleep(50);
            //DisplayAutoTrimOperateMes("Delay 50ms", 43);

            //Enter normal mode,already in test mode, so can omit this operations
            //_reg_Addr = 0x55;
            //_reg_Value = 0xAA;
            //if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
            //    DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 4);
            //else
            //{
            //    DisplayAutoTrimResult(false);
            //    return;
            //}

            _reg_Addr = 0x42;
            _reg_Value = 0x04;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 43);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            //Vout to VIN
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            message = "Set Vout to VIN";
            DisplayAutoTrimOperateMes(message, setResult, 43);

            //Delay 50ms
            Thread.Sleep(200);
            DisplayAutoTrimOperateMes("Delay 200ms", 43);

            //Capture Vout@0A
            IP0_Auto = AverageVout_Customer("0 A", sampleNum);
            DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 43);

            //Offset Lookup Table
            double offsetTuning = 100 * OffsetTuningCalc_Customer();
            DisplayAutoTrimOperateMes("Lookup offset = " + offsetTuning.ToString("F4") + "%", 43);

            int ixA = LookupOffset_Customer(ref offsetTuning, OffsetTableA_Customer);
            int ixB = LookupOffset_Customer(ref offsetTuning, OffsetTableB_Customer);

            DisplayAutoTrimOperateMes("Offset TableA chose Index = " + ixA.ToString() + ";Choosed OffsetA = " + OffsetTableA_Customer[0][ixA].ToString("F4"), 43);
            DisplayAutoTrimOperateMes("Offset TableB chose Index = " + ixB.ToString() + ";Choosed OffsetB = " + OffsetTableB_Customer[0][ixB].ToString("F4"), 43);

            Reg81Value += Convert.ToUInt32(OffsetTableA_Customer[1][ixA]);
            Reg82Value += Convert.ToUInt32(OffsetTableA_Customer[2][ixA]);
            DisplayAutoTrimOperateMes("@Offset: Reg2 Value = " + Reg81Value.ToString("X") + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[1][ixA]).ToString("X") + ")", 43);
            DisplayAutoTrimOperateMes("@Offset: Reg3 Value = " + Reg82Value.ToString("X") + "(+ 0x" + Convert.ToInt32(OffsetTableA_Customer[2][ixA]).ToString("X") + ")", 43);

            //this.txt_reg81.Text = "0x" + Reg81Value.ToString("X");
            //this.txt_reg82.Text = "0x" + Reg82Value.ToString("X");

            Reg83Value += Convert.ToUInt32(OffsetTableB_Customer[1][ixB]);
            DisplayAutoTrimOperateMes("@Offset: Reg4 Value = " + Reg83Value.ToString("X") + "(+ 0x" + Convert.ToInt32(OffsetTableB_Customer[1][ixB]).ToString("X") + ")", 43);

            //this.txt_reg83.Text = "0x" + Reg83Value.ToString("X");
            //return;
            //dr = MessageBox.Show("Return", "Return", MessageBoxButtons.OKCancel);
            //if (dr == DialogResult.Cancel)
            //{
            //    //DisplayAutoTrimResult(false);
            //    this.lbl_passOrFailed.ForeColor = Color.Red;
            //    this.lbl_passOrFailed.Text = "RETURN";
            //    return;
            //}
            //else
            //{
            //    DisplayAutoTrimResult(false, 0x0007, "Operation Canceled!");
            //    return;

            //}
            #endregion

            #endregion

            #region 5. Re-Power at 6V, Do Fuse operation one bit by one bit

            #region 5.1 Re-power on at 6V
            //VDD to EXT
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_EXT);
            message = "Set VDD to EXT";
            DisplayAutoTrimOperateMes(message, setResult, 51);

            //Power Off
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
            message = "Set VDD Power Off";
            DisplayAutoTrimOperateMes(message, setResult, 51);

            //Delay 500ms
            Thread.Sleep(500);
            DisplayAutoTrimOperateMes("Delay 500ms", 51);

            //Power On
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
            message = "Set VDD Power On";
            DisplayAutoTrimOperateMes(message, setResult, 51);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 51);

            #endregion

            #region 5.2 Setup signal path for Reg operation and Fuse
            //Vout without cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);
            message = "Set Vout without Cap";
            DisplayAutoTrimOperateMes(message, setResult, 52);

            //Vref without cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITHOUT_CAP);
            message = "Set Vref without Cap";
            DisplayAutoTrimOperateMes(message, setResult, 52);

            //Vout to Config
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            message = "Set Vout to CONFIG";
            DisplayAutoTrimOperateMes(message, setResult, 52);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 52);
            #endregion

            #region 5.3 Enter test mode
            //Changed @ 2014-09-02 by doc v1.3.9.7
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Fuse Code", true, 53);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
            #endregion

            #region 5.4 Write Fuse Code bit by bit
              
                int loopCount = 8;
                uint maskBit = 0x01;
                //Reg80
                _reg_Addr = 0x80;
                _reg_Value = Reg80Value;

                for (int i = 0; i < loopCount; i++)
                {
                    if ((_reg_Value & maskBit) != 0)
                    {
                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value & maskBit))
                        {
                            DisplayAutoTrimOperateMes(string.Format("Write Reg1 bit{0}", i), true, 54);
                            //Write 0 to 3 other regs
                            if (!WriteBlankFuseCode(_dev_addr, 0x81, 0x82, 0x83, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }

                            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }
                            ResetReg43And44(_dev_addr, 54);  //Rest Reg0x43 and Reg0x44
                        }
                        else
                        {
                            //DisplayAutoTrimResult(false);
                            DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                            return;
                        }
                    }

                    maskBit = maskBit << 1;
                }

                //Reg81
                _reg_Addr = 0x81;
                _reg_Value = Reg81Value;

                maskBit = 0x01;
                for (int i = 0; i < loopCount; i++)
                {
                    if ((_reg_Value & maskBit) != 0)
                    {
                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value & maskBit))
                        {
                            DisplayAutoTrimOperateMes(string.Format("Write Reg2 bit{0}", i), true, 54);
                            //Write 0 to 3 other regs
                            if (!WriteBlankFuseCode(_dev_addr, 0x80, 0x82, 0x83, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }

                            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }
                            ResetReg43And44(_dev_addr, 54);  //Rest Reg0x43 and Reg0x44
                        }
                        else
                        {
                            //DisplayAutoTrimResult(false);
                            DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                            return;
                        }
                    }

                    maskBit = maskBit << 1;
                }

                //Reg82
                _reg_Addr = 0x82;
                _reg_Value = Reg82Value;

                maskBit = 0x01;
                for (int i = 0; i < loopCount; i++)
                {
                    if ((_reg_Value & maskBit) != 0)
                    {
                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value & maskBit))
                        {
                            DisplayAutoTrimOperateMes(string.Format("Write Reg3 bit{0}", i), true, 54);
                            //Write 0 to 3 other regs
                            if (!WriteBlankFuseCode(_dev_addr, 0x81, 0x80, 0x83, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }

                            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }
                            ResetReg43And44(_dev_addr, 54);  //Rest Reg0x43 and Reg0x44
                        }
                        else
                        {
                            //DisplayAutoTrimResult(false);
                            DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                            return;
                        }
                    }

                    maskBit = maskBit << 1;
                }

                //Reg83
                _reg_Addr = 0x83;
                _reg_Value = Reg83Value;

                maskBit = 0x01;
                for (int i = 0; i < loopCount; i++)
                {
                    if ((_reg_Value & maskBit) != 0)
                    {
                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value & maskBit))
                        {
                            DisplayAutoTrimOperateMes(string.Format("Write Reg4 bit{0}", i), true, 54);
                            //Write 0 to 3 other regs
                            if (!WriteBlankFuseCode(_dev_addr, 0x81, 0x82, 0x80, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }

                            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 54))
                            {
                                //DisplayAutoTrimResult(false);
                                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                                return;
                            }
                            ResetReg43And44(_dev_addr, 54);  //Rest Reg0x43 and Reg0x44
                        }
                        else
                        {
                            //DisplayAutoTrimResult(false);
                            DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                            return;
                        }
                    }

                    maskBit = maskBit << 1;
                }

            #region Don't fuse master bit
                //Reg84, Fuse with master bit
                //_reg_Addr = 0x84;
                //_reg_Value = 0x07;

                //maskBit = 0x01;
                //for (int i = 0; i < loopCount; i++)
                //{
                //    if ((_reg_Value & maskBit) != 0)
                //    {
                //        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value & maskBit))
                //        {
                //            DisplayAutoTrimOperateMes(string.Format("Write Reg5 bit{0}", i), true, 4);
                //            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 4))
                //            {
                //                DisplayAutoTrimResult(false);
                //                return;
                //            }
                //            ResetReg43And44(_dev_addr, 4);  //Rest Reg0x43 and Reg0x44
                //        }
                //        else
                //        {
                //            DisplayAutoTrimResult(false);
                //            return;
                //        }
                //    }

                //    maskBit = maskBit << 1;
                //}
                #endregion Don't fuse master bit           
            #endregion

            #endregion

            #region 6. Re-power at 6V, read back trim code and compare, marginal read back compare

                #region 6.1 Re-Power at 6V
                //Power Off
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
                message = "Set VDD Power Off";
                DisplayAutoTrimOperateMes(message, setResult, 61);

                ////VDD to 5V
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_EXT);
                message = "Set VDD to 5V";
                DisplayAutoTrimOperateMes(message, setResult, 61);

                //Delay 500ms
                Thread.Sleep(500);
                DisplayAutoTrimOperateMes("Delay 500ms", 61);

                //Power On
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
                message = "Set VDD Power On";
                DisplayAutoTrimOperateMes(message, setResult, 61);

                Thread.Sleep(50);
                DisplayAutoTrimOperateMes("Delay 50ms", 61);

                #endregion

                #region 6.2 Enter test mode
                _reg_Addr = 0x55;
                _reg_Value = 0xAA;
                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayAutoTrimOperateMes("Enter Test Mode Before Another Judgment", true, 62);
                else
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }

                //Delay 50ms
                Thread.Sleep(50);
                DisplayAutoTrimOperateMes("Delay 50ms", 62);
                #endregion

                #region 6.3 Read back trim code and compare
                for (int j = 0; j < judgeRegValueLoopCount; j++)
                {
                    //Flag Enter loop judgment
                    DisplayAutoTrimOperateMes(string.Format("Enter Loop Judgment, LoopCount:{0}", judgeRegValueLoopCount + 1), 63);

                    #region Reset Reg0x43 and Reg0x44
                    ResetReg43And44(_dev_addr, 63);  //Rest Reg0x43 and Reg0x44
                    //Delay 50ms
                    Thread.Sleep(50);
                    DisplayAutoTrimOperateMes("Delay 50ms", 63);
                    #endregion

                    #region Normal Read Reg1,2,3,4
                    uint[] tempRBValue = ReadBackReg1ToReg4(_dev_addr);
                    if (tempRBValue == null)
                    {
                        DisplayAutoTrimOperateMes("ReadBack Data Error", 63);
                        //DisplayAutoTrimResult(false);
                        DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                        return;
                    }
                    #endregion                    

                    #region Reg1,2,3,4 trim == Read back value, break
                    if (CheckReg1ToReg4(tempRBValue, Reg80Value, Reg81Value, Reg82Value, Reg83Value))
                    {
                        break;
                    }
                    #endregion

                    #region Reg1,2,3,4 trim != Read back value, loop until loopcount = 0
                    else
                    {
                        #region Write Reg1 to Reg4 again
                        //Reg80
                        _reg_Addr = 0x80;
                        _reg_Value = Reg80Value ^ tempRBValue[0];

                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                            DisplayAutoTrimOperateMes("Write Reg1(0x" + _reg_Value.ToString("X") + ")", true, 63);
                        else
                        {
                            DisplayAutoTrimResult(false);
                            return;
                        }

                        //Reg81
                        _reg_Addr = 0x81;
                        _reg_Value = Reg81Value ^ tempRBValue[1];

                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                            DisplayAutoTrimOperateMes("Write Reg2(0x" + _reg_Value.ToString("X") + ")", true, 63);
                        else
                        {
                            DisplayAutoTrimResult(false);
                            return;
                        }

                        //Reg82
                        _reg_Addr = 0x82;
                        _reg_Value = Reg82Value ^ tempRBValue[2];

                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                            DisplayAutoTrimOperateMes("Write Reg3(0x" + _reg_Value.ToString("X") + ")", true, 63);
                        else
                        {
                            DisplayAutoTrimResult(false);
                            return;
                        }

                        //Reg83
                        _reg_Addr = 0x83;
                        _reg_Value = Reg83Value ^ tempRBValue[3];

                        if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                            DisplayAutoTrimOperateMes("Write Reg4(0x" + _reg_Value.ToString("X") + ")", true, 63);
                        else
                        {
                            DisplayAutoTrimResult(false);
                            return;
                        }
                        #endregion Write Reg1 to Reg4 again

                        ////Fuse Master Bit at the last Loop
                        //if (judgeRegValueLoopCount == 0)
                        //{
                        //    if (!WriteMasterBit(_dev_addr, 4))
                        //    {
                        //        DisplayAutoTrimOperateMes("Fuse Master bit", false, 4);
                        //        DisplayAutoTrimResult(false);
                        //        return;
                        //    }
                        //}

                        ReadBackReg1ToReg4(_dev_addr);

                        //Delay 50ms
                        Thread.Sleep(50);
                        DisplayAutoTrimOperateMes("Delay 50ms", 63);

                        //New fuse clock method
                        if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 63))
                        {
                            //DisplayAutoTrimResult(false);
                            DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                            return;
                        }
                    }
                    #endregion
                }
                #endregion

                #region 6.4 Normal read back vs Marginal read back

                #region Re-power on at 5V
                //Power Off
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
                message = "Set VDD Power Off";
                DisplayAutoTrimOperateMes(message, setResult, 64);

                ////VDD to 5V
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_5V);
                message = "Set VDD to 5V";
                DisplayAutoTrimOperateMes(message, setResult, 64);

                //Delay 500ms
                Thread.Sleep(500);
                DisplayAutoTrimOperateMes("Delay 500ms", 64);

                //Power On
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
                message = "Set VDD Power On";
                DisplayAutoTrimOperateMes(message, setResult, 64);

                Thread.Sleep(50);
                DisplayAutoTrimOperateMes("Delay 50ms", 64);

                #endregion

                #region Normal Read Reg1,2,3,4
                uint[] tempNormalRBValue = ReadBackReg1ToReg4(_dev_addr);
                if (tempNormalRBValue == null)
                {
                    DisplayAutoTrimOperateMes("ReadBack Data Error", 64);
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }
                else if(tempNormalRBValue[0] + tempNormalRBValue[1] + tempNormalRBValue[2] + tempNormalRBValue[3] == 0x00)
                {
                    if (Reg80Value + Reg81Value + Reg82Value + Reg83Value != 0x00)
                    {
                        DisplayAutoTrimOperateMes("ReadBack Data Error", 64);
                        //DisplayAutoTrimResult(false);
                        DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                        return;
                    }
                }

                Thread.Sleep(5);
                DisplayAutoTrimOperateMes("Delay 5ms", 64);
                #endregion                    

                #region Marginal Read Reg1,2,3,4 don't pass

                #region Setup Marginal Read

                _reg_Addr = 0x43;
                _reg_Value = 0x0E;

                bool writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
                if (writeResult)
                    DisplayOperateMes("Marginal Read succeeded!\r\n");
                else
                    DisplayOperateMes("I2C write failed, Marginal Read Failed!\r\n", Color.Red);

                //Delay 50ms
                Thread.Sleep(50);
                DisplayOperateMes("Delay 50ms");

                _reg_Addr = 0x43;
                _reg_Value = 0x0;

                writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
                //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
                if (writeResult)
                    DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
                else
                    DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);
                #endregion Setup Marginal Read

                uint[] _MarginalreadBack_data = new uint[4];
                _MarginalreadBack_data = ReadBackReg1ToReg4(_dev_addr);

                #region Enter normal mode
                _reg_Addr = 0x42;
                _reg_Value = 0x04;
                if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                    DisplayAutoTrimOperateMes("Enter Normal Mode", true, 64);
                else
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                    return;
                }

                //Vout with cap
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
                message = "Set Vout with Cap";
                DisplayAutoTrimOperateMes(message, setResult, 64);

                //Vref with cap
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITH_CAP);
                message = "Set Vref with Cap";
                DisplayAutoTrimOperateMes(message, setResult, 64);

                //Vout to Vin
                setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
                message = "Set Vin to Vout";
                DisplayAutoTrimOperateMes(message, setResult, 64);
                #endregion

                #region Capture Vout @ 0A and 15A
                //Capture Vout@0A
                IP0_Auto = AverageVout_Customer("0 A", sampleNum);
                DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 64);
            
                //Change Current to IPx A
                dr = MessageBox.Show(String.Format("Please Change Current To {0}A", selectedCurrent_Auto), "Change Current", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    //DisplayAutoTrimResult(false)
                    //this.lbl_passOrFailed.ForeColor = Color.Green;
                    //this.lbl_passOrFailed.Text = "C.N.D!"; ;
                    DisplayAutoTrimResult(false, 0x0007, "Operation Canceled!");
                    return;
                }

                //Delay 200ms
                Thread.Sleep(200);
                DisplayAutoTrimOperateMes("Delay 200ms", 64);

                //Capture Vout@IPx
                IPx_Auto = AverageVout_Customer(StrIPx_Auto, sampleNum);
                DisplayAutoTrimOperateMes(string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"), StrIPx_Auto), 64);
                #endregion

                //Judge Vout@0A
                bool ifPass_IP0 = false;
                bool ifMginalRead_IP0 = false;
                bool ifPass_IP15 = false;
                bool ifMginalRead_IP15 = false;
                bool ifPass_IP15_Last = false;
                bool ifMginalRead_IP15_Last = false;

                DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 64);
                if (IP0_Auto <= 2.530 && IP0_Auto >= 2.470)
                {
                    ifPass_IP0 = true;
                    //DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 64);
                }
                else if (IP0_Auto <= 2.550 && IP0_Auto >= 2.450)
                {
                    ifMginalRead_IP0 = true;
                    //DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 64);
                }
                else
                {
                    //DisplayAutoTrimResult(false);
                    DisplayAutoTrimResult(false, 0x0002, "M.R.E\tVout@0A = " + IP0_Auto.ToString("F3"));
                    return;
                }

                //Judge Vout@IPx
                //bool ifPass_IP15 = false;
                DisplayAutoTrimOperateMes(string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"), StrIPx_Auto), 64);
                if (IPx_Auto <= (2.530 + targetGain * selectedCurrent_Auto / 1000d) && IPx_Auto >= (2.470 + targetGain * selectedCurrent_Auto / 1000d))
                {
                    ifPass_IP15 = true;
                }
                else if (IPx_Auto <= (2.750 + targetGain * selectedCurrent_Auto / 1000d) && IPx_Auto >= (2.250 + targetGain * selectedCurrent_Auto / 1000d))
                {
                    ifMginalRead_IP15 = true;
                }

                else
                {
                    DisplayAutoTrimResult(false, 0x0002, string.Format("M.R.E\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                    return;
                }


                //if (!MarginalCheckReg1ToReg4(tempNormalRBValue, _dev_addr, testGain))
                //{
                    //DisplayAutoTrimOperateMes("Marginal read back data checking didn't pass!", 64);
                    //DisplayAutoTrimResult(false, 0x0002, "Marginal Read Error!");
                    //return;
                //}
                #endregion

                #endregion
            #endregion

            #region 7. Re-power at 6V, trim master bit

            #region 7.1 Re-Power at 6V
            ////VDD to 6V
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_EXT);
            message = "Set VDD to 6V";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            //Power Off
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
            message = "Set VDD Power Off";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            //Vout without cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITHOUT_CAP);
            message = "Set Vout without Cap";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            //Vref without cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITHOUT_CAP);
            message = "Set Vref without Cap";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            //Vout to Config
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_CONFIG_TO_VOUT);
            message = "Set VIN to Vout";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            //Delay 500ms
            Thread.Sleep(500);
            DisplayAutoTrimOperateMes("Delay 500ms", 71);

            //Power On
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
            message = "Set VDD Power On";
            DisplayAutoTrimOperateMes(message, setResult, 71);

            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 71);

            #endregion

            #region 7.2 Enter test mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before trim master bit", true, 72);
            else
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            ResetReg43And44(_dev_addr, 72);  //Rest Reg0x43 and Reg0x44

            //Delay 50ms
            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 72);
            #endregion

            #region 7.3 Trim master bit
            if (!WriteMasterBit0(_dev_addr, 73))
            {
                DisplayAutoTrimOperateMes("Fuse Master bit", false, 73);
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 73);

            ReadBackReg1ToReg5(_dev_addr);

            Thread.Sleep(20);
            DisplayAutoTrimOperateMes("Delay 20ms", 73);

            //New fuse clock method
            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 500, 73))
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            ResetReg43And44(_dev_addr, 73);  //Rest Reg0x43 and Reg0x44

            if (!WriteMasterBit1(_dev_addr, 73))
            {
                DisplayAutoTrimOperateMes("Fuse Master bit", false, 73);
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 73);

            ReadBackReg1ToReg5(_dev_addr);

            Thread.Sleep(20);
            DisplayAutoTrimOperateMes("Delay 20ms", 73);

            //New fuse clock method
            if (!FuseClockOn(_dev_addr, fusePulseWidth, fuseDurationTime, 500, 73))
            {
                //DisplayAutoTrimResult(false);
                DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            ResetReg43And44(_dev_addr, 73);  //Rest Reg0x43 and Reg0x44

            #endregion

            #region 7.4 Marginal Read Master Bits

            uint masterReg = 0;

            _reg_Addr = 0x43;
            _reg_Value = 0x0B;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
            if (writeResult)
                DisplayOperateMes("Re-load succeeded!\r\n");
            else
                DisplayOperateMes("I2C write failed,  Re-load Failed!\r\n", Color.Red);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayOperateMes("Delay 50ms");

            _reg_Addr = 0x43;
            _reg_Value = 0x0;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
            //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            if (writeResult)
                DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
            else
                DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);

            Thread.Sleep(50);
            DisplayOperateMes("Delay 50ms");

            masterReg = oneWrie_device.I2CRead_Single(_dev_addr, 0x84);
            DisplayAutoTrimOperateMes("Read back master bits", 74);
            DisplayAutoTrimOperateMes("Reg84 = 0x" + masterReg.ToString("X"));

            _reg_Addr = 0x43;
            _reg_Value = 0x0E;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
            if (writeResult)
                DisplayOperateMes("Marginal Read succeeded!\r\n");
            else
                DisplayOperateMes("I2C write failed, Marginal Read Failed!\r\n", Color.Red);

            //Delay 50ms
            Thread.Sleep(50);
            DisplayOperateMes("Delay 50ms");

            _reg_Addr = 0x43;
            _reg_Value = 0x0;

            writeResult = oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value);
            //Console.WriteLine("I2C write result->{0}", oneWrie_device.I2CWrite_Single(_dev_addr, _reg_addr, _reg_data));
            if (writeResult)
                DisplayOperateMes("Reset Reg0x43 succeeded!\r\n");
            else
                DisplayOperateMes("Reset Reg0x43 failed!\r\n", Color.Red);

            Thread.Sleep(100);
            DisplayOperateMes("Delay 100ms");

            //masterReg = 0;
            masterReg = oneWrie_device.I2CRead_Single(_dev_addr, 0x84);
            DisplayAutoTrimOperateMes("Reg84 = 0x" + masterReg.ToString("X"));

            if (masterReg == 0)
            {
                DisplayAutoTrimOperateMes("Marginal read back data checking didn't pass!", 74);
                //DisplayAutoTrimOperateMes("Reg84 = 0x" + masterReg.ToString("X"));
                DisplayAutoTrimResult(false, 0x0004, "Marginal Read Error!");
                return;
            }


            #endregion

            #endregion

            #region 8. Re-power on at 5V, capture Vout@0A and Vout@15A

            #region 8.1 Re-Power at 5V
            //Power Off
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_OFF);
            message = "Set VDD Power Off";
            DisplayAutoTrimOperateMes(message, setResult, 81);

            ////VDD to 5V
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_FROM_5V);
            message = "Set VDD to 5V";
            DisplayAutoTrimOperateMes(message, setResult, 81);

            //Delay 500ms
            Thread.Sleep(500);
            DisplayAutoTrimOperateMes("Delay 500ms", 81);

            //Power On
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VDD_POWER_ON);
            message = "Set VDD Power On";
            DisplayAutoTrimOperateMes(message, setResult, 81);

            Thread.Sleep(50);
            DisplayAutoTrimOperateMes("Delay 50ms", 81);

            #endregion

            #region 8.2 Set up signal path for AIN capture
            //Vout with cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VOUT_WITH_CAP);
            message = "Set Vout with Cap";
            DisplayAutoTrimOperateMes(message, setResult, 82);

            //Vref with cap
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VREF_WITH_CAP);
            message = "Set Vref with Cap";
            DisplayAutoTrimOperateMes(message, setResult, 82);

            //Vout to Vin
            setResult = oneWrie_device.ADCSigPathSet(OneWireInterface.ADCControlCommand.ADC_VIN_TO_VOUT);
            message = "Set VIN to Vout";
            DisplayAutoTrimOperateMes(message, setResult, 82);

            //Delay 200ms
            Thread.Sleep(200);
            DisplayAutoTrimOperateMes("Delay 200ms", 82);

            #endregion

            #region 8.3 Capture Vout @ 0A and IPx
            //Capture Vout@0A
            //IP0_Auto = AverageVout_Customer("0 A", sampleNum);
            //DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 83);

            //Change Current to 15A
            //dr = MessageBox.Show("Please Change Current To 15A", "Change Current", MessageBoxButtons.OKCancel);
            //if (dr == DialogResult.Cancel)
            //{
                //DisplayAutoTrimResult(false);
                //this.lbl_passOrFailed.ForeColor = Color.Red;
                //this.lbl_passOrFailed.Text = "C.N.D!";
                //DisplayAutoTrimResult(false, 0x0007, "Operation Canceled!");
                //return;
            //}

            //Delay 200ms
            //Thread.Sleep(200);
            //DisplayAutoTrimOperateMes("Delay 200ms", 83);

            //Capture Vout@IPx
            IPx_Auto = AverageVout_Customer(StrIPx_Auto, sampleNum);
            DisplayAutoTrimOperateMes(string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"), StrIPx_Auto), 83);
            #endregion

            #region 8.4 Verdict Pass! or Fail!
            //Judge Vout@0A
            //bool ifPass_IP0 = false;
            //if (!(IP0_Auto <= 2.530 && IP0_Auto >= 2.470))
            //{
            //    //DisplayAutoTrimResult(false);
            //    DisplayAutoTrimResult(false, 0x000F, "Vout@0A = " + IP0_Auto.ToString("F3"));
            //    if (IP0_Auto < 2)
            //    {
            //        DisplayAutoTrimResult(false, 0x0004, "Please Re-Trim Master Bits!");
            //    }
            //    return;
            //}
            //else
            //{
            //    ifPass_IP0 = true;
            //}

            //Judge Vout@15A
            //bool ifPass_IP15 = false;

            if ((IPx_Auto <= (2.530 + targetGain * selectedCurrent_Auto / 1000d) && IPx_Auto >= (2.470 + targetGain * selectedCurrent_Auto / 1000d)))
            {
                //DisplayAutoTrimResult(false);
                ifPass_IP15_Last = true;
                //DisplayAutoTrimResult(false, 0x000F, "Vout@15A = " + IP15_Auto.ToString("F3"));
                //return;
            }
            else if (IPx_Auto <= (2.750 + targetGain * selectedCurrent_Auto / 1000d) && IPx_Auto >= (2.250 + targetGain * selectedCurrent_Auto / 1000d))
            {
                ifMginalRead_IP15_Last = true;
            }
            else
            {
                if (IPx_Auto < 2)
                {
                    DisplayAutoTrimResult(false, 0x0004, "Please Re-Trim Master Bits!");
                }
                else
                {
                    DisplayAutoTrimResult(false, 0x000F, string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                }

                return;
            }

            if (masterReg == 3 || masterReg == 2)
            {
                //Final Judgement
                if (ifPass_IP0 && ifPass_IP15 && ifPass_IP15_Last)
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin1\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                else if (ifMginalRead_IP15_Last)
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin3\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                else
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin2\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                //else
                    //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(true, 0x0000, "Bin4\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
            }
            else
            {
                //Final Judgement
                if (ifPass_IP0 && ifPass_IP15 && ifPass_IP15_Last)
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin4\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                else if (ifMginalRead_IP15_Last)
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin6\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                else
                    DisplayAutoTrimResult(true, 0x0000, string.Format("Bin5\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto));
                //Final Judgement
                //if (ifPass_IP0 && ifPass_IP15 && ifMginalRead)
                //    DisplayAutoTrimResult(true, 0x0000, "Bin5\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
                //else if (ifPass_IP0 && ifPass_IP15)
                //    DisplayAutoTrimResult(true, 0x0000, "Bin4\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
                //else if (ifMginalRead)
                //{
                //    DisplayAutoTrimResult(true, 0x0000, "Bin6\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
                //}
                //else
                //    DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(true, 0x0000, "Bin5\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
            }

            //Final Judgement
            //if (ifPass_IP0 && ifPass_IP15 && ifMginalRead)
            //    DisplayAutoTrimResult(true, 0x0000, "Bin2\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
            //else if (ifPass_IP0 && ifPass_IP15  )
            //    DisplayAutoTrimResult(true, 0x0000, "Bin1\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
            //else if ( ifMginalRead )
            //{
            //    DisplayAutoTrimResult(true, 0x0000, "Bin3\tVout@0A = " + IP0_Auto.ToString("F3") + "\tVout@15A = " + IP15_Auto.ToString("F3"));
            //}
            //else
            //    DisplayAutoTrimResult(false);

            DisplayAutoTrimOperateMes("Vout@0A = " + IP0_Auto.ToString("F3"), 83);
            DisplayAutoTrimOperateMes(string.Format("Vout@{0} = " + IPx_Auto.ToString("F3"),StrIPx_Auto), 83);
            #endregion

            #endregion

            #region 9. Reset Vout@0A,Vout@15A and Reg0x80~Reg0x84
            IP0_Auto = 0;
            IPx_Auto = 0;
            Reg80Value = 0;
            Reg81Value = 0;
            Reg82Value = 0;
            Reg83Value = 0;
            //Reg84Value = 0;
            #endregion
             
        }

        //sel_vr button
        private void btn_sel_vr_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x82;
            _reg_Value = 0x08;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_nc_1x_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x83;
            _reg_Value = 0x01;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Write NC_1X", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_ch_ck_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x82;
            _reg_Value = 0x80;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        private void btn_sel_cap_Click(object sender, EventArgs e)
        {
            uint _dev_addr = 0x73;  //Device Address
            uint _reg_Addr;
            uint _reg_Value;


            //Enter normal mode
            _reg_Addr = 0x55;
            _reg_Value = 0xAA;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Test Mode Before Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }

            _reg_Addr = 0x81;
            _reg_Value = 0x08;
            if (oneWrie_device.I2CWrite_Single(_dev_addr, _reg_Addr, _reg_Value))
                DisplayAutoTrimOperateMes("Enter Normal Mode", true, 32);
            else
            {
                //DisplayAutoTrimResult(false);
                //DisplayAutoTrimResult(false, 0x0006, "I2C Conmunication Error!");
                return;
            }
        }

        #endregion Events


    }

    
}
