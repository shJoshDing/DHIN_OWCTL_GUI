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

namespace Test
{
    public partial class TestGUI : Form
    {
        public TestGUI()
        {
            InitializeComponent();
            lbl_dllVersion.Text = "Dll Version:" + Methods.GetDllVersion();

            //initialize default device
            this.cmb_devSel.SelectedIndex = 0;
            OneWrieInit();

            //init 2b
            for (int i = 0; i < read_array.Length; i++)
                read_array[i] = 0x2b;

            //Remove 
            this.tabCtrl_ForSDP.TabPages.Remove(this.tabPage_ADMP521);
            this.tabCtrl_ForSDP.TabPages.Remove(this.tabPage_SPK);
        }

        ADI.DMY2.SPKProtection spk_device = new SPKProtection();
        ADMP521T admp521T_device = new ADMP521T();
        OneWireInterface oneWrie_device = new OneWireInterface();
        WaveOperate wavOperation = new WaveOperate();
        
        private void btn_connect_Click(object sender, EventArgs e)
        {
            bool result;
            switch (this.cmb_devSel.SelectedItem.ToString())
            {
                case "One Wire":
                    #region One wire
                    if (txt_GUID_Write.Text == null | txt_GUID_Write.Text == "")
                        result = oneWrie_device.ConnectDevice();
                    else
                        result = oneWrie_device.ConnectDevice(this.txt_GUID_Write.Text);

                    if (result)
                    {
                        chb_status.BackColor = Color.YellowGreen;
                        chb_status.Text = "Connected";
                        txt_deviceNum.Text = oneWrie_device.TotalDevices.ToString();
                        txt_GUID_Read.Text = oneWrie_device.GUID;
                    }
                    else
                    {
                        chb_status.BackColor = Color.IndianRed;
                        chb_status.Text = "Disconnected";
                    }
                    #endregion
                    break;
                case "SPK Protection":
                    #region spk
                    if (txt_GUID_Write.Text == null | txt_GUID_Write.Text == "")
                        result = spk_device.ConnectDevice();
                    else
                        result = spk_device.ConnectDevice(this.txt_GUID_Write.Text);

                    if (result)
                    {
                        chb_status.BackColor = Color.YellowGreen;
                        chb_status.Text = "Connected";
                        txt_deviceNum.Text = spk_device.TotalDevices.ToString();
                        txt_GUID_Read.Text = spk_device.GUID;
                    }
                    else
                    {
                        chb_status.BackColor = Color.IndianRed;
                        chb_status.Text = "Disconnected";
                    }
                    #endregion
                    break;
                case "ADMP521T":
                    #region 521T
                    if (txt_GUID_Write.Text == null | txt_GUID_Write.Text == "")
                        result = admp521T_device.ConnectDevice();
                    else
                        result = admp521T_device.ConnectDevice(this.txt_GUID_Write.Text);

                    if (result)
                    {
                        chb_status.BackColor = Color.YellowGreen;
                        chb_status.Text = "Connected";
                        txt_deviceNum.Text = admp521T_device.TotalDevices.ToString();
                        txt_GUID_Read.Text = admp521T_device.GUID;
                    }
                    else
                    {
                        chb_status.BackColor = Color.IndianRed;
                        chb_status.Text = "Disconnected";
                    }
                    #endregion 521T
                    break;
                default:
                    break;
            }
        }

        #region Params Shared
        double[] dwArray = new double[128];        //should use u32 write interface.
        uint[] u32Array = new uint[128];
        byte[] write_array = new byte[512];

        int[] int32Array = new int[128];
        byte[] read_array = new byte[128 * 16 * 4 * 8];
        int receiveSizeOf8k = 20;

        //New thread for PDM data receiving.
        Thread T_pdmReveiveData;

        //跨线程初始化Timer for Record
        private delegate void DelegateInvoke(int i);
        private void DriveProgressBar(int i)
        {
            if (this.InvokeRequired)
            {
                DelegateInvoke sbv = new DelegateInvoke(DriveProgressBar);
                this.Invoke(sbv,i);
            }
            else
            {
                this.pgb_PDMreceive.Value = this.pgb_PDMreceive.Maximum + 1 - i;
            }
        }
        #endregion Params Shared

        #region Common events
        private int WM_DEVICECHANGE = 0x0219;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE)
            {
                btn_connect_Click(null, null);
            }
        }

        private void cmb_devSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_connect_Click(sender, e);
        }
        #endregion 

        #region SPK
        byte[] outPutReport_arr = new byte[64];
        byte[] readData = new byte[65472];
        private void btn_readData_Click(object sender, EventArgs e)
        {
            //UsbClosed();
            //Thread.Sleep(100);
            //outPutReport_arr[OutRptIndex.header_hid_cmd] = (byte)_USB_COMMAND.AUDIO_FORMAT;
            //outPutReport_arr[OutRptIndex.header_audio_if] = 4;
            //mydevice.Write(outPutReport_arr);
            //UsbOpen();
            //Thread.Sleep(100);
            //outPutReport_arr[OutRptIndex.header_hid_cmd] = (byte)_USB_COMMAND.USBIO_START;
            //bool b_usbReport = mydevice.Write(outPutReport_arr);
            //if (!b_usbReport)
            //{
            //    Console.WriteLine("Write USBIO_START command error, start record failed!!");
            //    return;
            //}
            ////Thread.Sleep(100);
            //int count = 100;
            //int length = 0;
            //while (count-- > 0)
            //{
            //    mydevice.Read(readData, 512);
            //    bool result =
            //    if (!result)
            //    {
            //        //if (ParamDefine.b_KeepRecording)
            //        //{
            //        //OperationLog("Read from device Error", Color.Red);
            //        Console.WriteLine("Read from device Error");
            //        //}
            //        //ParamDefine.b_KeepRecording = false;
            //    }
            //    else
            //        txt_readlength.Text = (++length * 1024).ToString();
               
            //}

            //outPutReport_arr[OutRptIndex.header_hid_cmd] = (byte)_USB_COMMAND.USBIO_STOP;
            //b_usbReport = mydevice.Write(outPutReport_arr);

            //Thread.Sleep(100);
            //UsbClosed();
        }

        private bool UsbClosed()
        {
            //outPutReport_arr[OutRptIndex.header_hid_cmd] = (byte)_USB_COMMAND.USBIO_CLOSE;
            //bool result = mydevice.Write(outPutReport_arr);
            ////if (result)
            ////    OperationLog("Usb closed succeeded.", Color.Blue);
            ////else
            ////    OperationLog("Usb closed failed.", Color.Red);
            //return result;
            return false;
        }

        private bool UsbOpen()
        {
            //outPutReport_arr[OutRptIndex.header_hid_cmd] = (byte)_USB_COMMAND.USBIO_OPEN;
            //bool result = mydevice.Write(outPutReport_arr);
            ////if (result)
            ////    OperationLog("Usb open succeeded.", Color.Blue);
            ////else
            ////    OperationLog("Usb open failed.", Color.Red);
            //return result;
            return false;
        }

        private void btn_write_Click(object sender, EventArgs e)
        {

            //write_array[0] = 0x0A;
            //write_array[1] = 4;
            //write_array[2] = 0;
            //write_array[3] = 0xCA;

            write_array[0] = 0x00;
            write_array[1] = 0;
            write_array[2] = 0;
            write_array[3] = 0x01;

            write_array[4] = 0x00;
            write_array[5] = 0;
            write_array[6] = 0;
            write_array[7] = 0;

            int[] test = new int[128];
            test[0] = 0x01000000;
            test[1] = 0x00000000;
            //if (mydevice.Write(test))
            //    Console.WriteLine("write succeeded");
            //else
            //    Console.WriteLine("write failed.");

        }

        private void btn_getWav_Click(object sender, EventArgs e)
        {
            byte[] test;
            test = spk_device.Test_GetWav(32, 2, SPKProtection.TestWavType.Line);
            test = spk_device.Test_GetWav(32, 2, SPKProtection.TestWavType.Sawtooth);
            test = spk_device.Test_GetWav(32, 2, SPKProtection.TestWavType.Sine);
            test = spk_device.Test_GetWav(32, 2, SPKProtection.TestWavType.Square);
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            byte[] writeBuf = new byte[12] ;
            int readLength = 512;

            writeBuf[0] = 0x00;
            writeBuf[1] = 0x00;
            writeBuf[2] = 0;
            writeBuf[3] = 0xDC;

            writeBuf[4] = 0;
            writeBuf[5] = 0;
            writeBuf[6] = 0;
            writeBuf[7] = 0;

            writeBuf[8] = 0;
            writeBuf[9] = 2;
            writeBuf[10] = 0;
            writeBuf[11] = 0;

            //byte[] result = mydevice.Read(writeBuf, readLength);
            ////byte[] readBuf = new byte[readLength];
            //Console.WriteLine("read result:{0}", result[1]);
        }

        GeneralMethods Methods = new GeneralMethods();
        private void btn_ReadLocalIV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                double[] temp = Methods.Read_LocalIVCoefs(ofd.FileName);
                Methods.Write_LocalFile(ofd.FileName.TrimEnd(".dat".ToArray()) + "new.dat", temp);
            }
        }

        private void btn_testIntArrayToBytes_Click(object sender, EventArgs e)
        {
            //mydevice.Test();
        }

        private void btn_testArrayCompare_Click(object sender, EventArgs e)
        {
            double[] test1 = new double[] {1.31,3.42,444.22 };
            double[] test2 = new double[] { 1.31, 3.42, 444.22 };
            Array.Equals(test1, test2);
            //if (test1 == test2)
            //{
                //Console.WriteLine(Array.Equals(test1, test2));
            //}

            if (test1.Length!= test2.Length)
            {
                Console.WriteLine("False");
                return;
            }
            else
            {
                for (int i = 0; i < test1.Length; i++)
                {
                    if (test1[i] != test2[i])
                    {
                        Console.WriteLine("False");
                        return;
                    }
                }
            }

            Console.WriteLine("True");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dwArray[0] = 1;
            dwArray[1] = 1;
            dwArray[2] = 1;
            dwArray[3] = 1;

            int indexFrom = 84;
            dwArray[indexFrom + 4] = 0.5;
            dwArray[indexFrom + 5] = -125;
            dwArray[indexFrom + 6] = -30;
            dwArray[indexFrom + 7] = -40;
            dwArray[indexFrom + 8] = -50;
            dwArray[indexFrom + 9] = -70;
            dwArray[indexFrom + 10] = -30;
            dwArray[indexFrom + 11] = -80;
            dwArray[indexFrom + 12] = 0;
            dwArray[indexFrom + 13] = 0;
            dwArray[indexFrom + 14] = 0;
            dwArray[indexFrom + 15] = -6;
            dwArray[indexFrom + 16] = -6;
            dwArray[indexFrom + 17] = -6;
            dwArray[indexFrom + 18] = -6;
            dwArray[indexFrom + 19] = -8;
            dwArray[indexFrom + 20] = -22;
            dwArray[indexFrom + 21] = 2400;
            dwArray[indexFrom + 22] = 2400;
            dwArray[indexFrom + 23] = 0;
            dwArray[indexFrom + 24] = 1;


            Console.WriteLine("write result:{0}", spk_device.Write(USB_COMMAND.Write_Param, dwArray, ""));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //byte[] test11 = new byte[512];
            //Console.WriteLine("write result:{0}", mydevice.StatusRead(test11));
            //Console.WriteLine(test11[0]);

            double[] test12 = new double[128];
            Console.WriteLine("Read result:{0}", spk_device.StatusRead(test12));
            Console.WriteLine("Rrdc-> {0}",test12[1]);
            Console.WriteLine("TestCount-> {0}", test12[46]);
            lbl_firmVersion.Text = "Firm Version:" + test12[47].ToString("0.00");
        }

        private void btn_testFixFloatConv_Click(object sender, EventArgs e)
        {
            //double[] data = new double[] { 1.222121234,10.4423333,0.00001320111};
            //double[] result = new double[3];
            //mydevice.Test(data, result);
            //Console.WriteLine("");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void btn_timerEnable_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        double value = 1;
        private void btn_ModuleEnable_Click(object sender, EventArgs e)
        {
            
            dwArray[0] = 0;
            dwArray[1] = 0;
            dwArray[2] = 0;
            dwArray[3] = 0;

            int indexFrom = 0;
            dwArray[indexFrom + 4] = value;
            dwArray[indexFrom + 5] = value;
            dwArray[indexFrom + 6] = value;
            dwArray[indexFrom + 7] = value;
            dwArray[indexFrom + 8] = value;
            dwArray[indexFrom + 9] = value;
            dwArray[indexFrom + 10] = value;
            //test[indexFrom + 11] = 1;
            //test[indexFrom + 12] = 0;
            //test[indexFrom + 13] = 0;
            //test[indexFrom + 14] = 0;
            //test[indexFrom + 15] = -6;
            //test[indexFrom + 16] = -6;
            //test[indexFrom + 17] = -6;
            //test[indexFrom + 18] = -6;
            //test[indexFrom + 19] = -8;
            //test[indexFrom + 20] = -22;
            //test[indexFrom + 21] = 2400;
            //test[indexFrom + 22] = 2400;
            //test[indexFrom + 23] = 0;
            //test[indexFrom + 24] = 1;
            Console.WriteLine("write result:{0}", spk_device.Write(USB_COMMAND.ModuleEnable, dwArray, ""));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            value =Convert.ToDouble(checkBox1.Checked);
        }
        #endregion SPK

        #region ADMP521
        #region Common Parameters
        int length_BitArrayForCSV = (int)Math.Pow(2,10) - 1;
        volatile bool underRec = false;
        #endregion 

        #region Functions
        private void PDM_ReceiveData()
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(recRawDataPath, FileMode.Create));
            bool result;
            u32Array[0] = (uint)ADMP521_USB_COMMAND.SportPDM_Start;
            Console.WriteLine("PDM start result:{0}", admp521T_device.Write(ADMP521_USB_COMMAND.SportPDM_Start, u32Array));

            //Thread.Sleep(20);
            //Console.WriteLine("PDM Read result:{0}", mydevice.Read(read_array));
            //pgb_PDMreceive.Maximum = Convert.ToInt32(numUD_num8K.Value);
            //pgb_PDMreceive.Value = 0;
            underRec = true;
            for (int i = Convert.ToInt32(numUD_num8K.Value); i > 0 & underRec; i--)
            {
                //Console.WriteLine("PDM Read result:No{0}->{1}", i, mydevice.Read(read_array));
                result = admp521T_device.Read(read_array);
                Console.WriteLine("PDM Read result:No{0}->{1}", i, result);
                if (!result)
                {
                    underRec = false;
                    continue;
                }
                wavOperation.WriteWaveDataToFile(bw, read_array);
                //DriveProgressBar(i);
                //pgb_PDMreceive.Value = pgb_PDMreceive.Maximum - i;
                //pgb_PDMreceive.Update();
                //Thread.Sleep(10);
                //Console.WriteLine("Read result:{0}:{1}", i, mydevice.Read(int32Array));
            }

            bw.Close();

            u32Array[0] = (uint)ADMP521_USB_COMMAND.SportPDM_Stop; ;
            Console.WriteLine("PDM stop result:{0}", admp521T_device.Write(ADMP521_USB_COMMAND.SportPDM_Start, u32Array));
            

            //DecorderFile(recRawDataPath);
        }

        private void GenerateCSVHead(TextWriter tw)
        {
            string str = "\"DATA\"\r\n";
            str += "\"Pod 6[0]\"\r\n";
            str += "*Init Start\r\n";
            str += "*Init End\r\n";
            str += "*Main Start\r\n";
            tw.Write(str);
        }

        private void GenerateCSVMainStart(TextWriter tw, string oldFilePath)
        {            
            string str_Pattern = File.ReadAllText(oldFilePath).Trim();
            string baseStr = "0123456789abcdef";
            string[] patterns = str_Pattern.Split(',');
            string str_willWrite = "";
            string temp;
            byte tempValue;
            for (int i = 0; i < patterns.Length; i++)
            {
                str_willWrite = "";
                temp = patterns[i].TrimStart("0x".ToCharArray());
                if (temp.Length == 0)
                {
                    for (int j = 0; j < 8; j++)
                        str_willWrite += "0\r\n";                   
                    tw.Write(str_willWrite);
                }
                else if (temp.Length == 1)
                {
                    for (int j = 0; j < 4; j++)
                        str_willWrite += "0\r\n";
                    tempValue = Convert.ToByte(baseStr.ToUpper().IndexOf(temp) << 4);

                    for (int j = 0; j < 4; j++)
                    {
                        str_willWrite += Convert.ToByte(Convert.ToBoolean((tempValue & 0x80))).ToString() + "\r\n";
                        tempValue <<= 1;
                    }
                    tw.Write(str_willWrite);
                }
                else if (temp.Length == 2)
                {
                    //for (int j = 0; j < 4; j++)
                    //    str_willWrite += "0\r\n";
                    tempValue = Convert.ToByte(baseStr.ToUpper().IndexOf(temp.ToCharArray()[0]) << 4);

                    for (int j = 0; j < 4; j++)
                    {
                        str_willWrite += Convert.ToByte(Convert.ToBoolean((tempValue & 0x80))).ToString() + "\r\n";
                        tempValue <<= 1;
                    }

                    tempValue = Convert.ToByte(baseStr.ToUpper().IndexOf(temp.ToCharArray()[1]) << 4);

                    for (int j = 0; j < 4; j++)
                    {
                        str_willWrite += Convert.ToByte(Convert.ToBoolean((tempValue & 0x80))).ToString() + "\r\n";
                        tempValue <<= 1;
                    }
                    tw.Write(str_willWrite);
                }
                else
                    MessageBox.Show("Formate Error!", "Error", MessageBoxButtons.OK);
            }
            
 
        }

        private void GenerateCSVMainStart(TextWriter tw, BitArray bitsSource)
        {
            int count = 0;
            string strWillWrite = "";
            for (int i = 0; i < bitsSource.Length; i++)
            {
                strWillWrite += Convert.ToByte(bitsSource[i]) + "\r\n";
                count++;
            }
            tw.Write(strWillWrite);
            Console.WriteLine("count : {0}", count);
        }

        private void GenerateCSVTail(TextWriter tw)
        {
            string str = "*Main End\r\n";
            tw.Write(str);
            tw.Close();
        }

        //加码器(1 + x^3 + x^10)
        private BitArray Scrambler(BitArray InputBits, BitArray OutputBits)
        {
            //BitArray OutputBits = new BitArray(InputBits.Length);
            //OutputBits.SetAll(false);
            int loopCount = 0;

            while (loopCount < InputBits.Length)
            {
                if (loopCount >= 10)
                {
                    OutputBits[loopCount] = InputBits[loopCount] ^ (OutputBits[loopCount - 3] ^ OutputBits[loopCount - 10]);
                }
                else if (loopCount >= 3)
                {
                    OutputBits[loopCount] = InputBits[loopCount] ^ (OutputBits[loopCount - 3] ^ OutputBits[InputBits.Length + loopCount - 10]);
                }
                else
                    OutputBits[loopCount] = InputBits[loopCount] ^ (OutputBits[InputBits.Length + loopCount - 3] ^ OutputBits[InputBits.Length + loopCount - 10]);

                loopCount++;
            }

            return OutputBits;
        }

        //解码器
        private BitArray Decoder(BitArray InputBits, BitArray OutputBits)
        {
            //BitArray OutputBits = new BitArray(InputBits.Length);
            //OutputBits.SetAll(false);
            int loopCount = 0;

            while (loopCount < InputBits.Length)
            {
                if (loopCount >= 10)
                {
                    OutputBits[loopCount] = InputBits[loopCount] ^ (InputBits[loopCount - 3] ^ InputBits[loopCount - 10]);
                }
                else if (loopCount >= 3)
                {
                    OutputBits[loopCount] = InputBits[loopCount] ^ (InputBits[loopCount - 3] ^ InputBits[InputBits.Length + loopCount - 10]);
                }
                else
                    OutputBits[loopCount] = InputBits[loopCount] ^ (InputBits[InputBits.Length + loopCount - 3] ^ InputBits[InputBits.Length + loopCount - 10]);

                loopCount++;
            }

            return OutputBits;
        }

        //byte高低翻转
        uint[] mask1 = new uint[8] { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        private byte ReverseByte(byte value, int bitStart, int convertNum)
        {
            int result = 0;
            uint convertValue = Convert.ToUInt32(value);
            uint myMask = 0;
            int tempConvNum = convertNum;
            int tempBitStart = bitStart;
            for (; tempConvNum > 0; tempConvNum--)
            {
                myMask = myMask | mask1[tempBitStart++];
            }

            convertValue = convertValue & myMask;
            convertValue = (convertValue & 0x55555555) << 1 | (convertValue & 0xAAAAAAAA) >> 1;
            convertValue = (convertValue & 0x33333333) << 2 | (convertValue & 0xCCCCCCCC) >> 2;
            convertValue = (convertValue & 0x0F0F0F0F) << 4 | (convertValue & 0xF0F0F0F0) >> 4;

            convertValue = convertValue & 0x000000FF;
            convertValue = convertValue >> (8 - (convertNum + bitStart));
            convertValue = convertValue << bitStart;                    // get the reverse value

            uint changelessValue = Convert.ToUInt32(value);
            changelessValue = changelessValue & (~myMask);

            result = Convert.ToByte(convertValue | changelessValue);
            //int shiftBase = 1;          //it shift from right to left again and again
            //int rightShift = 8;         //it shift from left to right again and again 
            //int notChangeValue = (int)value;
            //for (int i = 0; i < convertNum; convertNum++)
            //{
            //    notChangeValue = notChangeValue & (0 << 
            //}

            //result = (result | (value & leftShift)) << 8;
            //for( int myIndex = 0; myIndex < 8; myIndex++)
            //{
            //    result = (result | (value & shiftBase)) << 1;
            //    shiftBase = shiftBase << 1;
            //}



            return Convert.ToByte(result);
        }
        #endregion Functions

        #region Events
        private void btn_falsh_Click(object sender, EventArgs e)
        {
            u32Array[0] = 0xCA000001;
            
/*          u32Array[indexFrom + 4] = 0.5;
            u32Array[indexFrom + 5] = -125;
            u32Array[indexFrom + 6] = -30;
            u32Array[indexFrom + 7] = -40;
            u32Array[indexFrom + 8] = -50;
            u32Array[indexFrom + 9] = -70;
            u32Array[indexFrom + 10] = -30;
            u32Array[indexFrom + 11] = -80;
            u32Array[indexFrom + 12] = 0;
            u32Array[indexFrom + 13] = 0;
            u32Array[indexFrom + 14] = 0;
            u32Array[indexFrom + 15] = -6;
            u32Array[indexFrom + 16] = -6;
            u32Array[indexFrom + 17] = -6;
            u32Array[indexFrom + 18] = -6;
            u32Array[indexFrom + 19] = -8;
            u32Array[indexFrom + 20] = -22;
            u32Array[indexFrom + 21] = 2400;
            u32Array[indexFrom + 22] = 2400;
            u32Array[indexFrom + 23] = 0;
            u32Array[indexFrom + 24] = 1;
*/
            //Console.WriteLine("write result:{0}", admp521T_device.Write(ADMP521_USB_COMMAND.FlashLED, u32Array));
            Console.WriteLine("write result:{0}",admp521T_device.FlashLED());
        }

        volatile string recRawDataPath;
        private void btn_PDMStart_Click(object sender, EventArgs e)
        {
            #region prepare to save rec file
            SaveFileDialog saveRECFile = new SaveFileDialog();
            saveRECFile.Title = "Save the raw wave file as...";
            //saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            saveRECFile.RestoreDirectory = true;
            saveRECFile.Filter = "Raw Data file (*.dat)|*.dat|All Files (*.*)|*.*";
            saveRECFile.FileName = "ADMP521Data.dat";            
            if (saveRECFile.ShowDialog() == DialogResult.OK)
            {
                recRawDataPath = saveRECFile.FileName;
            }
            else
            {
                return;
            }
            #endregion 

            pgb_PDMreceive.Maximum = Convert.ToInt32(numUD_num8K.Value);
            pgb_PDMreceive.Value = 0;


            //admp521T_device.PDMRecording(recRawDataPath);
            #region Creat new thread to receive raw data
            T_pdmReveiveData = new Thread(PDM_ReceiveData);
            T_pdmReveiveData.Start();
            #endregion

            #region Get data in the main thread
            //BinaryWriter bw = new BinaryWriter(new FileStream(recRawDataPath, FileMode.Create));
            //bool result;
            //u32Array[0] = 0xCA00040C;
            //Console.WriteLine("PDM start result:{0}", mydevice.Write(ADMP521_USB_COMMAND.SportPDM, u32Array));

            ////Thread.Sleep(20);
            ////Console.WriteLine("PDM Read result:{0}", mydevice.Read(read_array));
            ////pgb_PDMreceive.Maximum = Convert.ToInt32(numUD_num8K.Value);
            ////pgb_PDMreceive.Value = 0;
            //for (int i = Convert.ToInt32(numUD_num8K.Value); i > 0; i--)
            //{
            //    //Console.WriteLine("PDM Read result:No{0}->{1}", i, mydevice.Read(read_array));
            //    result = mydevice.Read(read_array);
            //    Console.WriteLine("PDM Read result:No{0}->{1}", i, result);
            //    if (!result)
            //        continue;
            //    wavOperation.WriteWaveDataToFile(bw, read_array);
            //    //DriveProgressBar(i);
            //    //pgb_PDMreceive.Value = pgb_PDMreceive.Maximum - i;
            //    //pgb_PDMreceive.Update();
            //    //Thread.Sleep(10);
            //    //Console.WriteLine("Read result:{0}:{1}", i, mydevice.Read(int32Array));
            //}

            //bw.Close();

            //u32Array[0] = 0xCA00040E;
            //Console.WriteLine("PDM stop result:{0}", mydevice.Write(ADMP521_USB_COMMAND.SportPDM, u32Array));
            #endregion 

            //pgb_PDMreceive.Maximum = Convert.ToInt32(numUD_num8K.Value);
            //pgb_PDMreceive.Value = 0;


            //u32Array[0] = 0xCA00040C;
            //Console.WriteLine("PDM start result:{0}", mydevice.Write(ADMP521_USB_COMMAND.SportPDM, u32Array));

            ////Thread.Sleep(20);
            ////Console.WriteLine("PDM Read result:{0}", mydevice.Read(read_array));
            ////pgb_PDMreceive.Maximum = Convert.ToInt32(numUD_num8K.Value);
            ////pgb_PDMreceive.Value = 0;
            //for (int i = Convert.ToInt32(numUD_num8K.Value); i > 0; i--)
            //{
            //    Console.WriteLine("PDM Read result:No{0}->{1}", i,mydevice.Read(read_array));
            //    wavOperation.WriteWaveDataToFile(bw, read_array);
            //    //pgb_PDMreceive.Value = pgb_PDMreceive.Maximum - i;
            //    //pgb_PDMreceive.Update();
            //    //Thread.Sleep(10);
            //    //Console.WriteLine("Read result:{0}:{1}", i, mydevice.Read(int32Array));
            //}

            //bw.Close();
            //btn_PDMStop_Click(sender, e);
            //MessageBox.Show("PDM transfer finished!");
            //Console.WriteLine("Over"); 
        }

        private void btn_TestRead_Click(object sender, EventArgs e)
        {
            //u32Array[0] = 0xCA00040D;
            //Console.WriteLine("Test Read_write command result:{0}", admp521T_device.Write(ADMP521_USB_COMMAND.SportPDM_Start, u32Array));

            //Console.WriteLine(" Test Read_read result:{0}", admp521T_device.Read(int32Array));
            ////Thread.Sleep(20);
            //lbl_testCount.Text = "Read Report count:\r\n" + int32Array[0].ToString("X");
           
        }

        private void btn_PDMStop_Click(object sender, EventArgs e)
        {
            //u32Array[0] = 0xCA00040E;
            //Console.WriteLine("PDM stop result:{0}", admp521T_device.Write(ADMP521_USB_COMMAND.SportPDM_Start, u32Array));
            underRec = false;
            admp521T_device.PDMStop();
            //Thread.Sleep(20);

            //for (int i = receiveSizeOf8k; i > 0; i--)
            //{
            //    Console.WriteLine("Read result:{0}", mydevice.Read(int32Array));
            //}
        }
        
        private void btn_generateCSV_Click(object sender, EventArgs e)
        {
            #region Switch data source for generating
            DialogResult dr = MessageBox.Show("Generate from all 1 BitArray source?\r\nYes:From BitArray. No:From local *.dat file.", "Choose",MessageBoxButtons.YesNo);
            #region 通过全1的BitArray生产
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                #region Choose save path
                string csvPath = "";
                //string oldFilePath = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save as...";
                //saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                saveFile.RestoreDirectory = true;
                saveFile.Filter = "CSV file (*.csv)|*.csv|All Files (*.*)|*.*";
                //openFile.FileName = "ADMP521_Pattern.csv";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    csvPath = saveFile.FileName;
                }
                else
                {
                    return;
                }
                #endregion

                //csvPath += ".csv";
                //csvPath = oldFilePath.Replace(".dat", ".csv");

                //Creat csv file
                TextWriter tw = File.CreateText(csvPath);
                BitArray bitsSource = new BitArray(length_BitArrayForCSV);
                BitArray bitResult = new BitArray(length_BitArrayForCSV);
                bitResult.SetAll(false);
                bitsSource.SetAll(true);
                GenerateCSVHead(tw);
                GenerateCSVMainStart(tw, Scrambler(bitsSource, bitResult));
                GenerateCSVTail(tw);
                return;
            }
            #endregion 
            #region 通过本地的.dat文件生产
            else
            {
                #region Open file for converting.
                string csvPath = "";
                string oldFilePath = "";
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Choose the .dat file for converting...";
                //saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openFile.RestoreDirectory = true;
                openFile.Filter = "Raw data file (*.dat)|*.dat|All Files (*.*)|*.*";
                //openFile.FileName = "ADMP521_Pattern.csv";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    oldFilePath = openFile.FileName;
                }
                else
                {
                    return;
                }
                #endregion

                csvPath = oldFilePath.Replace(".dat", ".csv");

                //Creat csv file
                TextWriter tw = File.CreateText(csvPath);
                GenerateCSVHead(tw);
                GenerateCSVMainStart(tw, oldFilePath);
                GenerateCSVTail(tw);
                return;
            }
            #endregion 
            #endregion Switch data source for generating
        }

        private void btn_PDMDataAnalysis_Click(object sender, EventArgs e)
        {
            string pdmBase = txt_PDMBaseData.Text.ToUpper();
            #region Open the PDM data
            string dataPath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Choose the .dat file for analysis...";
            //saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            openFile.RestoreDirectory = true;
            openFile.Filter = "Raw data file (*.dat)|*.dat|All Files (*.*)|*.*";
            //openFile.FileName = "ADMP521_Pattern.csv";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                dataPath = openFile.FileName;
            }
            else
            {
                return;
            }
            #endregion 
            string convertStr;
            bool ifContainPattern = false;
            BinaryReader br = new BinaryReader(File.OpenRead(dataPath));
            #region Judge if it contain the gived pattern.
            byte[] temp = br.ReadBytes(4 * pdmBase.Length);
            byte[] dataBytes = new byte[temp.Length];
            #region 调整byte位置：低位先行->高位先行（FW以u32收数据，故需要没四个bytes调整一次）
            for (int i = 0; i < pdmBase.Length; i++)
            {
                dataBytes[4 * i] = temp[4 * i + 3];
                dataBytes[4 * i + 1] = temp[4 * i + 2];
                dataBytes[4 * i + 2] = temp[4 * i + 1];
                dataBytes[4 * i + 3] = temp[4 * i];
            }
            #endregion
            //BitArray ba = new BitArray(bytes);
            int count = pdmBase.Length;
            //对bytes进行移位对比
            Console.WriteLine("Raw Data:\r\n" + BitConverter.ToString(dataBytes));
            while(--count > 0)
            {
                convertStr = "";
                //compare with base
                //for (int i = 0; i < pdmBase.Length; i++)
                //    convertStr += bytes[i].ToString("X2");
                convertStr = BitConverter.ToString(dataBytes).Replace("-","");
                if (convertStr.Contains(pdmBase))
                {
                    Console.WriteLine("Get the base data after {0} times left shift.",
                        pdmBase.Length - count - 1);
                    ifContainPattern = true;
                    break;
                }

                for (int i = 0; i < 4 * pdmBase.Length - 1; i++)
                {
                    dataBytes[i] = Convert.ToByte(((dataBytes[i] << 1) & 0x000000FF) | ((dataBytes[i + 1] >> 7) & 0x01));
                }
                dataBytes[4 * pdmBase.Length - 1] <<= 1;

                //foreach (byte b1 in bytes)
                //{
                //    Console.Write(b1.ToString("X2"));
                //}                
                Console.WriteLine("Shift left {0} times.\r\n" + BitConverter.ToString(dataBytes), pdmBase.Length - count - 1);
            }
            #endregion Judge if it contain the gived pattern.

            if (!ifContainPattern)
                return;

            #region Judge if the data all right
            double realSizeReadOneTime = 0;
            int errorCount = 0;
            long default20M = 0x1400000;
            int readOneTime = pdmBase.Length;
            //Get length for one time read.
            while(readOneTime < default20M)
                readOneTime *= 2;

            realSizeReadOneTime = readOneTime / (1024 * 1024);
            byte[] data;
            int flagTemp = 0;
            count = pdmBase.Length;
            br.BaseStream.Seek(0,SeekOrigin.Begin);
            string baseBytes = BitConverter.ToString(br.ReadBytes(count));    //2倍base值
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            //If remainder data is bigger than 20M
            while(br.BaseStream.Position + readOneTime < br.BaseStream.Length)
            {
                flagTemp++;
                data = br.ReadBytes(readOneTime);   //get data
                //逐个判断是否等于baseBytes
                for (int i = 0; i < readOneTime / count; i++)
                {
                    if (baseBytes != BitConverter.ToString(data, i * count, count))
                    {
                        errorCount++;
                        Console.WriteLine("error info No.{0}->location:{1}",errorCount,
                            (br.BaseStream.Position - readOneTime + i * count).ToString("X8"));
                    }
                }
                Console.WriteLine("Had analysed {0} * {1}M data.", flagTemp, realSizeReadOneTime);
            }

            int remainderDataLength = (int)(br.BaseStream.Length - br.BaseStream.Position);
            data = br.ReadBytes(remainderDataLength);   //get data            
            //逐个判断是否等于baseBytes
            for (int i = 0; i < remainderDataLength / count; i++)
            {
                if (baseBytes != BitConverter.ToString(data, i * count, count))
                {
                    errorCount++;
                    Console.WriteLine("error info No.{0}->location:{1}", errorCount,
                            (br.BaseStream.Position - remainderDataLength + i * count).ToString("X8"));
                }
            }
            br.Close();
            Console.WriteLine("Analysed data finished.");
            Console.WriteLine("error data Num.:{0}",errorCount);
            #endregion             
        }

        private void btn_scrambler_Click(object sender, EventArgs e)
        {
            //string str_bitSource = "11111111";
            BitArray arr_result;
            BitArray arr_bitSource = new BitArray(length_BitArrayForCSV);
            arr_bitSource.SetAll(false);
            BitArray arr_bitResult = new BitArray(length_BitArrayForCSV);
            arr_bitResult.SetAll(false);

            arr_bitSource[0] = true;
            Console.WriteLine();
            Console.WriteLine("Bit Source:");
            for(int i = 0; i < arr_bitSource.Length; i++)
            {                
                if (i % 32 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}-{1}:", i.ToString("0000"), (i + 31).ToString("0000"));                    
                }
                Console.Write(Convert.ToByte(arr_bitSource[i]));
            }

            arr_result = Scrambler(arr_bitSource,arr_bitResult);

            Console.WriteLine();
            Console.WriteLine("Scrambler Result:");
            int count_T = 0;
            int count_F = 0;

            for (int i = 0; i < arr_result.Length; i++)
            {
                if (i % 32 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}-{1}:", i.ToString("0000"), (i + 31).ToString("0000"));
                    //Console.WriteLine();
                }
                Console.Write(Convert.ToByte(arr_result[i]));
                if (arr_result[i])
                    count_T++;
                else
                    count_F++;
            }

            Console.WriteLine();
            Console.WriteLine("count_T:{0},count_F:{1}",count_T,count_F);
            BitArray testTemp = new BitArray(arr_result.Length);

            for (int i = (int)numUD_num8K.Value; i < testTemp.Length; i++)
                testTemp[i - (int)numUD_num8K.Value] = arr_result[i];
            for (int i = 0; i < (int)numUD_num8K.Value; i++)
                testTemp[arr_result.Length - (int)numUD_num8K.Value + i] = arr_result[i];

            arr_result.SetAll(false);
            arr_bitResult.SetAll(false);

            //arr_result = Decoder(testTemp, arr_bitResult);
            Decoder(testTemp, arr_result);
            //arr_result = Decoder(Scrambler(arr_bitSource));
            Console.WriteLine();
            Console.WriteLine("Decoder Result:");

            for (int i = 0; i < arr_result.Length; i++)
            {
                if (i % 32 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}-{1}:", i.ToString("0000"), (i + 31).ToString("0000")); 
                    //Console.WriteLine();
                }
                Console.Write(Convert.ToByte(arr_result[i]));
            }

            //arr_result = Decoder(testTemp, arr_bitResult);
            Decoder(testTemp, arr_result);
            //arr_result = Decoder(Scrambler(arr_bitSource));
            Console.WriteLine();
            Console.WriteLine("Decoder Result:");

            for (int i = 0; i < arr_result.Length; i++)
            {
                if (i % 32 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}-{1}:", i.ToString("0000"), (i + 31).ToString("0000"));
                    //Console.WriteLine();
                }
                Console.Write(Convert.ToByte(arr_result[i]));
            }
            
        }

        private void btn_DecoderLocalFile_Click(object sender, EventArgs e)
        {
            #region Open the PDM data
            string oldDataPath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Choose the .dat file for analysis...";
            //saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            openFile.RestoreDirectory = true;
            openFile.Filter = "Raw data file (*.dat)|*.dat|All Files (*.*)|*.*";
            //openFile.FileName = "ADMP521_Pattern.csv";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                oldDataPath = openFile.FileName;
            }
            else
            {
                return;
            }
            #endregion

            //string newDataPath = oldDataPath.Replace(".dat", "_Fixed.dat");
            string newDataPath_decoder = oldDataPath.Replace(".dat", "_Decoder.dat");

            BinaryReader br = new BinaryReader(File.OpenRead(oldDataPath));
            //BinaryWriter bw = new BinaryWriter(File.Create(newDataPath));
            //BinaryWriter bw_decoder = new BinaryWriter(File.Create(newDataPath_decoder));
            TextWriter bw_decoder = File.CreateText(newDataPath_decoder);

            long default10M = 0xA00000;
            int readOneTime = length_BitArrayForCSV * 32;
            //Get length for one time read.
            while (readOneTime < default10M)
                readOneTime *= 2;
            Console.WriteLine("Read {0}M({1} bytes) one time.",(double)readOneTime/(1024 * 1024),readOneTime);

            byte[] data; 
            byte[] tempData;
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            BitArray tempBits;// = new BitArray(data);
            BitArray analysisBits = new BitArray(length_BitArrayForCSV);
            BitArray bitsResult = new BitArray(length_BitArrayForCSV);
            int count = 0;
            int handleCount = 1;
            //If remainder data is bigger than 20M
            while (br.BaseStream.Position + readOneTime < br.BaseStream.Length)
            {
                Console.WriteLine("Analyse the {0} pack data.",handleCount++);
                tempData = br.ReadBytes((int)readOneTime);   //get data
                data = new byte[tempData.Length];
                #region 调整byte位置：低位先行->高位先行（FW以u32收数据，故需要没四个bytes调整一次）
                for (int i = 0; i < tempData.Length / 4; i++)
                {
                    data[4 * i] = tempData[4 * i + 3];
                    data[4 * i + 1] = tempData[4 * i + 2];
                    data[4 * i + 2] = tempData[4 * i + 1];
                    data[4 * i + 3] = tempData[4 * i];
                }
                #endregion
                //byte 高低位翻转
                for (int i = 0; i < data.Length; i++)
                    data[i] = ReverseByte(data[i], 0, 8);

                //bw.Write(data);
                #region Decoder
                //tempData = File.ReadAllBytes(newDataPath);
                tempBits = new BitArray(data);
                //analysisBits = new BitArray(length_BitArrayForCSV);
                //bitsResult = new BitArray(length_BitArrayForCSV);
                //string str_decoder = "";                
                if (data.Length >= 128)
                {
                    for (int i = 0; i + length_BitArrayForCSV <= tempBits.Length; i += length_BitArrayForCSV)
                    {
                        //copy all the bits for analysis.
                        for (int j = 0; j < length_BitArrayForCSV; j++)
                            analysisBits[j] = tempBits[i + j];

                        Decoder(analysisBits, bitsResult);
                        #region print decoder result
                        //str_decoder = "";
                        for (int j = 0; j < bitsResult.Length; j++)
                        {
                            if (!bitsResult[j])
                            {
                                count++;
                                Console.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Position - readOneTime + ((i + j) / 8)).ToString("X8"));
                                bw_decoder.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Position - readOneTime + ((i + j) / 8)).ToString("X8"));
                            }
                            //bw_decoder.Write(bitsResult[j]);
                            //str_decoder += bitsResult[j] ? "1":"0";
                            //if (j % 32 == 0)
                            //{
                            //    Console.WriteLine();
                            //    Console.Write("{0}-{1}:", j.ToString("0000"), (j + 31).ToString("0000"));
                            //    //Console.WriteLine();
                            //}
                            //Console.Write(Convert.ToByte(bitsResult[j]));
                        }
                        //bw_decoder.Write(str_decoder);
                        #endregion
                        //Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Raw data is too short to analysis.");

                //bw_decoder.WriteLine("Error Count:{0}", count);
                //bw_decoder.Close();
                #endregion Decoder
            }

            Console.WriteLine("Analyse the last pack data.");
            int remainderDataLength = (int)(br.BaseStream.Length - br.BaseStream.Position);
            tempData = br.ReadBytes((int)remainderDataLength);   //get data
            data = new byte[tempData.Length - tempData.Length%4];
            #region 调整byte位置：低位先行->高位先行（FW以u32收数据，故需要没四个bytes调整一次）
            for (int i = 0; i < tempData.Length / 4; i++)
            {
                data[4 * i] = tempData[4 * i + 3];
                data[4 * i + 1] = tempData[4 * i + 2];
                data[4 * i + 2] = tempData[4 * i + 1];
                data[4 * i + 3] = tempData[4 * i];
            }
            #endregion
            //byte 高低为翻转
            for (int i = 0; i < data.Length; i++)
                data[i] = ReverseByte(data[i], 0, 8);

            #region Decoder
            //tempData = File.ReadAllBytes(newDataPath);
            tempBits = new BitArray(data);
            //analysisBits = new BitArray(length_BitArrayForCSV);
            //bitsResult = new BitArray(length_BitArrayForCSV);
            //string str_decoder = "";
            //int count = 0;
            if (tempData.Length >= 128)
            {
                for (int i = 0; i + length_BitArrayForCSV <= tempBits.Length; i += length_BitArrayForCSV)
                {
                    //copy all the bits for analysis.
                    for (int j = 0; j < length_BitArrayForCSV; j++)
                        analysisBits[j] = tempBits[i + j];

                    Decoder(analysisBits, bitsResult);
                    #region print decoder result
                    //str_decoder = "";
                    for (int j = 0; j < bitsResult.Length; j++)
                    {
                        if (!bitsResult[j])
                        {
                            count++;
                            Console.WriteLine("Error Count:{0}->location:{1}", count, 
                                (br.BaseStream.Length - remainderDataLength + ((i + j) / 8)).ToString("X8"));
                            bw_decoder.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Length - remainderDataLength + ((i + j) / 8)).ToString("X8"));
                        }
                        //bw_decoder.Write(bitsResult[j]);
                        //str_decoder += bitsResult[j] ? "1":"0";
                        //if (j % 32 == 0)
                        //{
                        //    Console.WriteLine();
                        //    Console.Write("{0}-{1}:", j.ToString("0000"), (j + 31).ToString("0000"));
                        //    //Console.WriteLine();
                        //}
                        //Console.Write(Convert.ToByte(bitsResult[j]));
                    }
                    //bw_decoder.Write(str_decoder);
                    #endregion
                    //Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Raw data is too short to analysis.");

            //bw_decoder.WriteLine("Error Count:{0}", count);
            //bw_decoder.Close();
            #endregion Decoder
            bw_decoder.WriteLine("Error Count:{0}", count);
            bw_decoder.Close();
            br.Close();

            #region Decoder
            //TextWriter bw_decoder = File.CreateText(newDataPath_decoder);
            //BinaryReader br_decoder = new BinaryReader(File.OpenRead(newDataPath_decoder));

            //tempData = File.ReadAllBytes(newDataPath);
            //BitArray tempBits = new BitArray(tempData);
            //BitArray analysisBits = new BitArray(length_BitArrayForCSV);
            //BitArray bitsResult = new BitArray(length_BitArrayForCSV);
            ////string str_decoder = "";
            //int count = 0;
            //if (tempData.Length >= 128)
            //{
            //    for (int i = 0; i + length_BitArrayForCSV <= tempBits.Length; i += length_BitArrayForCSV)
            //    {
            //        //copy all the bits for analysis.
            //        for (int j = 0; j < length_BitArrayForCSV; j++)
            //            analysisBits[j] = tempBits[i + j];

            //        Decoder(analysisBits, bitsResult);
            //        #region print decoder result
            //        //str_decoder = "";
            //        for (int j = 0; j < bitsResult.Length; j++)
            //        {
            //            if (!bitsResult[j])
            //                bw_decoder.WriteLine("Error Count:{0}->location:{1}",++count, ((i + j)/8).ToString("X8"));
            //            //bw_decoder.Write(bitsResult[j]);
            //            //str_decoder += bitsResult[j] ? "1":"0";
            //            //if (j % 32 == 0)
            //            //{
            //            //    Console.WriteLine();
            //            //    Console.Write("{0}-{1}:", j.ToString("0000"), (j + 31).ToString("0000"));
            //            //    //Console.WriteLine();
            //            //}
            //            //Console.Write(Convert.ToByte(bitsResult[j]));
            //        }
            //        //bw_decoder.Write(str_decoder);
            //        #endregion
            //        //Console.WriteLine();
            //    }
            //}
            //else
            //    Console.WriteLine("Raw data is too short to analysis.");

            //bw_decoder.WriteLine("Error Count:{0}", count);
            //bw_decoder.Close();
            #endregion Decoder
        }

        private void btn_ConvertRaw2Text_Click(object sender, EventArgs e)
        {
            #region Open the raw data
            string oldDataPath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Choose the .dat file for conveting...";
            openFile.RestoreDirectory = true;
            openFile.Filter = "Raw data file (*.dat)|*.dat|All Files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                oldDataPath = openFile.FileName;
            }
            else
            {
                return;
            }
            #endregion

            if (Methods.ConvertRawData2TextFile(oldDataPath))
                Console.WriteLine("Convert succeeded.");
            else
                Console.WriteLine("Convert failed.");
        }

        private void DecorderFile(string path)
        {
            #region Open the PDM data
            string oldDataPath = path;
            //OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Title = "Choose the .dat file for analysis...";
            ////saveRECFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //openFile.RestoreDirectory = true;
            //openFile.Filter = "Raw data file (*.dat)|*.dat|All Files (*.*)|*.*";
            ////openFile.FileName = "ADMP521_Pattern.csv";
            //if (openFile.ShowDialog() == DialogResult.OK)
            //{
            //    oldDataPath = openFile.FileName;
            //}
            //else
            //{
            //    return;
            //}
            #endregion

            //string newDataPath = oldDataPath.Replace(".dat", "_Fixed.dat");
            string newDataPath_decoder = oldDataPath.Replace(".dat", "_Decoder.dat");

            BinaryReader br = new BinaryReader(File.OpenRead(oldDataPath));
            //BinaryWriter bw = new BinaryWriter(File.Create(newDataPath));
            //BinaryWriter bw_decoder = new BinaryWriter(File.Create(newDataPath_decoder));
            TextWriter bw_decoder = File.CreateText(newDataPath_decoder);

            long default10M = 0xA00000;
            int readOneTime = length_BitArrayForCSV * 32;
            //Get length for one time read.
            while (readOneTime < default10M)
                readOneTime *= 2;
            Console.WriteLine("Read {0}M({1} bytes) one time.", (double)readOneTime / (1024 * 1024), readOneTime);

            byte[] data;
            byte[] tempData;
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            BitArray tempBits;// = new BitArray(data);
            BitArray analysisBits = new BitArray(length_BitArrayForCSV);
            BitArray bitsResult = new BitArray(length_BitArrayForCSV);
            int count = 0;
            int handleCount = 1;
            //If remainder data is bigger than 20M
            while (br.BaseStream.Position + readOneTime < br.BaseStream.Length)
            {
                Console.WriteLine("Analyse the {0} pack data.", handleCount++);
                tempData = br.ReadBytes((int)readOneTime);   //get data
                data = new byte[tempData.Length];
                #region 调整byte位置：低位先行->高位先行（FW以u32收数据，故需要没四个bytes调整一次）
                for (int i = 0; i < tempData.Length / 4; i++)
                {
                    data[4 * i] = tempData[4 * i + 3];
                    data[4 * i + 1] = tempData[4 * i + 2];
                    data[4 * i + 2] = tempData[4 * i + 1];
                    data[4 * i + 3] = tempData[4 * i];
                }
                #endregion
                //byte 高低位翻转
                for (int i = 0; i < data.Length; i++)
                    data[i] = ReverseByte(data[i], 0, 8);

                //bw.Write(data);
                #region Decoder
                //tempData = File.ReadAllBytes(newDataPath);
                tempBits = new BitArray(data);
                //analysisBits = new BitArray(length_BitArrayForCSV);
                //bitsResult = new BitArray(length_BitArrayForCSV);
                //string str_decoder = "";                
                if (data.Length >= 128)
                {
                    for (int i = 0; i + length_BitArrayForCSV <= tempBits.Length; i += length_BitArrayForCSV)
                    {
                        //copy all the bits for analysis.
                        for (int j = 0; j < length_BitArrayForCSV; j++)
                            analysisBits[j] = tempBits[i + j];

                        Decoder(analysisBits, bitsResult);
                        #region print decoder result
                        //str_decoder = "";
                        for (int j = 0; j < bitsResult.Length; j++)
                        {
                            if (!bitsResult[j])
                            {
                                count++;
                                //Console.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Position - readOneTime + ((i + j) / 8)).ToString("X8"));
                                //bw_decoder.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Position - readOneTime + ((i + j) / 8)).ToString("X8"));
                            }
                            //bw_decoder.Write(bitsResult[j]);
                            //str_decoder += bitsResult[j] ? "1":"0";
                            //if (j % 32 == 0)
                            //{
                            //    Console.WriteLine();
                            //    Console.Write("{0}-{1}:", j.ToString("0000"), (j + 31).ToString("0000"));
                            //    //Console.WriteLine();
                            //}
                            //Console.Write(Convert.ToByte(bitsResult[j]));
                        }
                        //bw_decoder.Write(str_decoder);
                        #endregion
                        //Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Raw data is too short to analysis.");

                //bw_decoder.WriteLine("Error Count:{0}", count);
                //bw_decoder.Close();
                #endregion Decoder
            }

            Console.WriteLine("Analyse the last pack data.");
            int remainderDataLength = (int)(br.BaseStream.Length - br.BaseStream.Position);
            tempData = br.ReadBytes((int)remainderDataLength);   //get data
            data = new byte[tempData.Length - tempData.Length % 4];
            #region 调整byte位置：低位先行->高位先行（FW以u32收数据，故需要没四个bytes调整一次）
            for (int i = 0; i < tempData.Length / 4; i++)
            {
                data[4 * i] = tempData[4 * i + 3];
                data[4 * i + 1] = tempData[4 * i + 2];
                data[4 * i + 2] = tempData[4 * i + 1];
                data[4 * i + 3] = tempData[4 * i];
            }
            #endregion
            //byte 高低为翻转
            for (int i = 0; i < data.Length; i++)
                data[i] = ReverseByte(data[i], 0, 8);

            #region Decoder
            //tempData = File.ReadAllBytes(newDataPath);
            tempBits = new BitArray(data);
            //analysisBits = new BitArray(length_BitArrayForCSV);
            //bitsResult = new BitArray(length_BitArrayForCSV);
            //string str_decoder = "";
            //int count = 0;
            if (tempData.Length >= 128)
            {
                for (int i = 0; i + length_BitArrayForCSV <= tempBits.Length; i += length_BitArrayForCSV)
                {
                    //copy all the bits for analysis.
                    for (int j = 0; j < length_BitArrayForCSV; j++)
                        analysisBits[j] = tempBits[i + j];

                    Decoder(analysisBits, bitsResult);
                    #region print decoder result
                    //str_decoder = "";
                    for (int j = 0; j < bitsResult.Length; j++)
                    {
                        if (!bitsResult[j])
                        {
                            count++;
                            //Console.WriteLine("Error Count:{0}->location:{1}", count,
                            //    (br.BaseStream.Length - remainderDataLength + ((i + j) / 8)).ToString("X8"));
                            //bw_decoder.WriteLine("Error Count:{0}->location:{1}", count, (br.BaseStream.Length - remainderDataLength + ((i + j) / 8)).ToString("X8"));
                        }
                        //bw_decoder.Write(bitsResult[j]);
                        //str_decoder += bitsResult[j] ? "1":"0";
                        //if (j % 32 == 0)
                        //{
                        //    Console.WriteLine();
                        //    Console.Write("{0}-{1}:", j.ToString("0000"), (j + 31).ToString("0000"));
                        //    //Console.WriteLine();
                        //}
                        //Console.Write(Convert.ToByte(bitsResult[j]));
                    }
                    //bw_decoder.Write(str_decoder);
                    #endregion
                    //Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Raw data is too short to analysis.");

            //bw_decoder.WriteLine("Error Count:{0}", count);
            //bw_decoder.Close();
            #endregion Decoder
            Console.WriteLine("Error Count:{0}", count);
            bw_decoder.WriteLine("Error Count:{0}", count);
            bw_decoder.Close();
            br.Close();

           
        }
        #endregion ADMP521

        private void btn_Decoder_Click(object sender, EventArgs e)
        {
            byte[] test = {0x00,0x0F};
            BitArray ba = new BitArray(test);
            for (int i = 0; i < ba.Length; i++)
            {
                Console.Write(Convert.ToByte(ba[i]));
            }
        }

        private void btn_testBtn_Click(object sender, EventArgs e)
        {
            uint[] test = new uint[2]{0xF1,0xFF};
            admp521T_device.Test(this.chb_TestBool.Checked);

            //admp521T_device.I2CRead(1, 0x28, u32Array);
        }

        private void btn_I2CWrite_Click(object sender, EventArgs e)
        {
            //uint[] test = new uint[6] { 0x00, 0x55,01,0xAA,02,04 };
            //admp521T_device.Write(ADMP521T_MODE.Test, 3, 0x28, test,this.chb_postTrim.Checked);

            uint[] test = new uint[4] { 0xF0, 0x5A , 0xF1,0xA5};
          
            uint[] writeVal = new uint[2];
            try
            {
                string temp = this.txt_i2cWriteAdd.Text.TrimStart("0x".ToCharArray());
                writeVal[0] = UInt32.Parse((temp == "" ? "0" : temp) ,System.Globalization.NumberStyles.HexNumber);

                temp = this.txt_i2cWriteVal.Text.TrimStart("0x".ToCharArray());
                writeVal[1] = UInt32.Parse((temp == "" ? "0" : temp) , System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Write data format error!");
            }

            admp521T_device.Write(ADMP521T_MODE.Test, 1, 0x28, writeVal, this.chb_postTrim.Checked);
        }

        private void btn_TestI2CRead_Click(object sender, EventArgs e)
        {
            //uint[] test = new uint[12] { 0xF0, 0xFF, 0xF1, 0xFF, 0xF2, 0xFF, 0xF3, 0xFF, 0xF4, 0xFF, 0xF5, 0xFF };
            //admp521T_device.I2CRead(6, 0x28, test,this.chb_postTrim.Checked);
            //foreach (uint val in test)
            //    Console.Write(val.ToString("X2") + "    ");
            //Console.WriteLine();

            uint[] test = new uint[14] { 0xF0, 0x00, 0xF1, 0x00, 0xF2, 0x00, 0xF3, 0x00, 0xF4, 0x00, 0xF5, 0x00 ,0xF6,0x00};
            admp521T_device.I2CRead((uint)(test.Length / 2), 0x28, test, this.chb_postTrim.Checked);
            this.txt_i2cRead.Text = "";
            foreach (uint val in test)
                this.txt_i2cRead.Text += val.ToString("X2") + "     ";
                //Console.Write(val.ToString("X2") + "    ");
            
            Console.WriteLine("read done");
        }

        private void btn_GetFWVersion_Click(object sender, EventArgs e)
        {
            this.lbl_FWVesion_521.Text = "FW Version:" + admp521T_device.GetFWVersion();
        }

        private void chb_SetLR_CheckedChanged(object sender, EventArgs e)
        {
            admp521T_device.SetLR(chb_SetLR.Checked,2, this.chb_TestBool.Checked);
        }

        private void chb_TestBool_CheckedChanged(object sender, EventArgs e)
        {
            //admp521T_device.Test(chb_TestBool.Checked);
        }

        private void btn_enterFuseMode_Click(object sender, EventArgs e)
        {
            admp521T_device.SelectMode(ADMP521T_MODE.Fuse, false);           
        }

        private void btn_initMode_Click(object sender, EventArgs e)
        {
            if(chb_TestBool.Checked)
                Console.WriteLine(admp521T_device.InitializationMode(ADMP521T_MODE_INIT.Normal,true));
            else
                Console.WriteLine(admp521T_device.InitializationMode(ADMP521T_MODE_INIT.Test,true));
        }

        private void btn_fuseOperation_Click(object sender, EventArgs e)
        {
            uint[] temp = new uint[] { 0x0F02, 0x00 };
            admp521T_device.Write(ADMP521T_MODE.Fuse, 1,(uint)this.numUD_fuseClk.Value, temp, false);
        }

        private void btn_NormalTest_Click(object sender, EventArgs e)
        {
            admp521T_device.SelectMode(ADMP521T_MODE.Normal_Test, this.chb_TestBool.Checked);
        }

        private void chb_clkSetting_CheckedChanged(object sender, EventArgs e)
        {
            admp521T_device.ClkSwitch(this.chb_clkSetting.Checked);
            if (chb_clkSetting.Checked)
                this.chb_clkSetting.Text = "CLK ON";
            else
                this.chb_clkSetting.Text = "CLK OFF";
        }

        private void btn_normalMode_Click(object sender, EventArgs e)
        {
            admp521T_device.SelectMode(ADMP521T_MODE.Normal, this.chb_TestBool.Checked);
        }

        private void chb_postTrim_CheckedChanged(object sender, EventArgs e)
        {
            admp521T_device.SetPostTrim(this.chb_postTrim.Checked);
        }

        private void btn_TestMode_Click(object sender, EventArgs e)
        {
            admp521T_device.SelectMode(ADMP521T_MODE.Test, this.chb_TestBool.Checked);
        }

        private void btn_testReadSize_Click(object sender, EventArgs e)
        {
            UInt32[] testRead = new UInt32[1024+512];
            testRead[0] = 0xCA000411;
            admp521T_device.Read(testRead);
            Console.WriteLine("First u32 and last u32 value:{0},{1}",testRead[1].ToString("X"),testRead[testRead.Length - 1].ToString("X"));
        }

        #endregion 521T
              
        #region One Wire Interface

        #region Functions
        private void OneWrieInit()
        {
            this.cmb_fusepulsewidth.SelectedIndex = 2;  //Default Fuse pulse width

            pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow.Value;
            //Disable Fuse operation
            //this.cmb_fusepulsewidth.Enabled = false;
            //this.rbtn_FuseClkOn.Enabled = false;
            //this.rbtn_FuseClkOff.Enabled = false;
            this.num_UD_pulsewidth_ow.Enabled = false;
            this.numUD_pulsedurationtime_ow.Enabled = false;
            this.btn_fuse_action_ow.Enabled = false;
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

        private void ScanWriteOperationOW()
        {
            if (CanWriteScan && (LoadedData != null))
            {
                for (int i = 0; i < LoadedData.Length / 2; i++)
                {
                    if (!oneWrie_device.I2CWrite_Single(Dev_Add_OW, LoadedData[2 * i], LoadedData[2 * i + 1]))
                    {
                        DriveScanWroteNum("Write Error!");
                        return;
                    }
                        
                    //Console.WriteLine("I2C write single result->{0}",
                    //    oneWrie_device.I2CWrite_Single(_dev_addr, LoadedData[2 * i], LoadedData[2 * i + 1]));
                    //Console.WriteLine("I2C write single result->{0}");
                    if (i % 100 == 0)
                    {
                        DriveScanWroteNum(i.ToString());
                        DriveScanProgressBar(i);
                        //this.txt_WroteNum_OW.Text = (i / 2).ToString();
                        //this.pgb_ProcessedRate_OW.Value = (i / 2);
                    }
                }

                DriveScanWroteNum((LoadedData.Length / 2).ToString());
                DriveScanProgressBar(LoadedData.Length / 2);
                //this.txt_WroteNum_OW.Text = (LoadedData.Length / 2).ToString();
                //this.pgb_ProcessedRate_OW.Value = (LoadedData.Length / 2);
                //this.Refresh();
            }
            else
            {
                DriveScanWroteNum("Failed!!");
            }
        }

        //跨线程操作
        //private delegate void DelegateInvoke(int i);
        private void DriveScanProgressBar(int i)
        {
            if (this.InvokeRequired)
            {
                DelegateInvoke sbv = new DelegateInvoke(DriveScanProgressBar);
                this.Invoke(sbv, i);
            }
            else
            {
                this.pgb_ProcessedRate_OW.Value = i;
            }
        }

        private delegate void DelegateInvokeText(string text);
        private void DriveScanWroteNum(string text)
        {
            if (this.InvokeRequired)
            {
                DelegateInvokeText sbv = new DelegateInvokeText(DriveScanWroteNum);
                this.Invoke(sbv, text);
            }
            else
            {
                this.txt_WroteNum_OW.Text = text;
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
        }

        private void btn_flash_onewire_Click(object sender, EventArgs e)
        {
           Console.WriteLine("Flash result->{0}",oneWrie_device.FlashLED());
        }

        private void btn_GetFW_OneWire_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Enter Get FW Interface");
            this.lbl_FW_onewire.Text = "FW Version:" + oneWrie_device.GetFWVersion();
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

        OneWireInterface.FusePulseWidth fusePW = OneWireInterface.FusePulseWidth.width_150ns;
        private void rbtn_FuseClkOn_CheckedChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Fuse write result->{0}", oneWrie_device.FuseClockSwitch(this.rbtn_FuseClkOn.Checked, fusePW));
        }

        

        private void cmb_fusepulsewidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmb_fusepulsewidth.SelectedItem.ToString())
            {
                case "100 ns":
                    fusePW = OneWireInterface.FusePulseWidth.width_100ns;
                    break;
                case "125 ns":
                    fusePW = OneWireInterface.FusePulseWidth.width_125ns;
                    break;
                case "150 ns":
                    fusePW = OneWireInterface.FusePulseWidth.width_150ns;
                    break;
                case "175 ns":
                    fusePW = OneWireInterface.FusePulseWidth.width_175ns;
                    break;
                case "200 ns":
                    fusePW = OneWireInterface.FusePulseWidth.width_200ns;
                    break;
            }
            
        }

        private decimal pilotwidth_ow_value_backup = 4000;
        private void numUD_pilotwidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.numUD_pilotwidth_ow.Value = (decimal)((int)Math.Round((double)this.numUD_pilotwidth_ow.Value / 20d) * 20);
            if (this.numUD_pilotwidth_ow.Value % 20 == 0 & this.numUD_pilotwidth_ow.Value != pilotwidth_ow_value_backup)
            {
                this.pilotwidth_ow_value_backup = this.numUD_pilotwidth_ow.Value;
                Console.WriteLine("Set pilot width result->{0}", oneWrie_device.SetPilotWidth((uint)this.numUD_pilotwidth_ow.Value));
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
        }

        private void num_UD_pulsewidth_ow_ValueChanged(object sender, EventArgs e)
        {
            this.num_UD_pulsewidth_ow.Value = (decimal)((int)Math.Round((double)this.num_UD_pulsewidth_ow.Value / 5d) * 5);
        }

        private void btn_test_ow_Click(object sender, EventArgs e)
        {
            oneWrie_device.Test(true);
        }

        uint[] LoadedData;
        bool CanWriteScan = false;
        private void btn_LoadScanData_OW_Click(object sender, EventArgs e)
        {
            StreamReader sr;
            string registerstate;
            string[] temp;
            uint[] registerValue = new uint[2];
            List<uint> loadDataList = new List<uint>();
            try
            {
                OpenFileDialog openfiledlg = new OpenFileDialog();
                openfiledlg.Title = "Please choose load file...";
                openfiledlg.Filter = "RCF files(*.rcf)|*.rcf";
                string filename = "";
                if (openfiledlg.ShowDialog() == DialogResult.OK)
                {
                    filename = openfiledlg.FileName;
                }
                else
                    return;

                sr = new StreamReader(filename);
                registerstate = sr.ReadLine();
                while (registerstate != null)
                {
                    //1. skipped if comment line
                    if (registerstate.StartsWith("#"))
                    {
                        registerstate = sr.ReadLine();
                        continue;
                    }
                    //2. Get string before "#" to remove comments.
                    temp = registerstate.Split('#');  //Split string by "#"
                    registerstate = temp[0];

                    //3. Split string by "=" to get Add and Value
                    temp = registerstate.Trim('\t').Trim().Split('=');
                    if (temp.Length != 2)     //Formate Error
                    {
                        registerstate = sr.ReadLine();
                        continue;
                    }

                    try
                    {
                        registerValue[0] = Convert.ToUInt32(temp[0].Trim(), 16);   //Add
                        registerValue[1] = Convert.ToUInt32(temp[1].Trim(), 16);   //Data
                        loadDataList.Add(registerValue[0]);
                        loadDataList.Add(registerValue[1]);
                    }
                    catch
                    {
                        continue;
                    }

                    registerstate = sr.ReadLine();
                }

                sr.Close();
                CanWriteScan = true;
            }
            catch
            {
                CanWriteScan = false;
                this.txt_loadNum_OW.Text = "Load Error!!";
            }
            finally
            {
                if (CanWriteScan)
                {
                    LoadedData = loadDataList.ToArray();
                    this.txt_loadNum_OW.Text = (LoadedData.Length / 2).ToString();
                    this.pgb_ProcessedRate_OW.Maximum = (LoadedData.Length / 2);
                }
                //sr = null;
                registerstate = null;
                temp = null;
                registerValue = null;
                loadDataList = null;
            }
        }

        Thread T_ScanWrite_OW;
        uint Dev_Add_OW;
        private void btn_startScanWrite_OW_Click(object sender, EventArgs e)
        {
            Dev_Add_OW = 0x54;
            try
            {
                string temp = this.txt_dev_addr_onewire.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                Dev_Add_OW = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

            }
            catch
            {
                MessageBox.Show("Get device address error, will use default value 0x54");
            }

            T_ScanWrite_OW = new Thread(ScanWriteOperationOW);
            T_ScanWrite_OW.Start();
        }


        #endregion Events

        private void btn_WriteUserCMD_OW_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = this.txt_userCMD_OWI.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint cmd = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = this.txt_userCMD_DownCount_OWI.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint downCount = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = this.txt_userCMD_UPCount_OWI.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint upCount = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                temp = this.txt_userCMD_ParamNum_OWI.Text.TrimStart("0x".ToCharArray()).TrimEnd("H".ToCharArray());
                uint paramNum = UInt32.Parse((temp == "" ? "0" : temp), System.Globalization.NumberStyles.HexNumber);

                Console.WriteLine("User command write succeeded ->{0}", oneWrie_device.UserCommand(cmd,downCount,upCount,paramNum));
            }
            catch
            {
                MessageBox.Show("Data format error, please correct and try again!");
            }
        }

        
        #endregion
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
