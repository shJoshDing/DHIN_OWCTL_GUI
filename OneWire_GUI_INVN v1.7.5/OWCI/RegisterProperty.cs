using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using ADI.DMY2;

namespace OWCI
{
    public class RegisterProperty:INotifyPropertyChanged
    {
        private uint _index;
        private uint _regAddress;
        private string _regData;
        private bool _ifRead;
        private bool _ifWrite;
        //private string _Read;
        private uint maxData = 0xFF;
        private uint minData = 0x00;
        private RWProperty _rw;
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterProperty(uint index, uint regAddr, string regVal,
            RWProperty rw, bool ifRead, bool ifwrite)
        {
            this._index = index;
            this._regAddress = regAddr;
            this._regData = regVal;
            this._rw = rw;
            this._ifRead = ifRead;
            this._ifWrite = ifwrite;
            //_Read = "Read";
        }


        public event System.EventHandler GainChanged;
        protected virtual void OnGainChanged()
        {
            System.EventArgs e = new System.EventArgs();
            if (GainChanged != null) GainChanged(this, e);

        }

        public event System.EventHandler RegAddrChanged;
        protected virtual void OnRegAddrChanged()
        {
            System.EventArgs e = new System.EventArgs();
            if (RegAddrChanged != null) RegAddrChanged(this, e);

        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #region Register Properties
        public uint Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = (uint)value;
                NotifyPropertyChanged("Index");
            }

        }

        public uint RegAddr
        {
            get
            {
                return (uint)_regAddress;
            }
            set
            {
                if (value < 0xFF && value >= 0)
                {
                    _regAddress = (uint)value;
                    NotifyPropertyChanged("RegAddr");
                }
            }
        }

        public string RegData
        {
            get
            {
                return _regData;
            }
            set
            {
                if (UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber) <= 0xFF && UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber) >= 0)
                {
                    _regData = value.ToUpper();
                    NotifyPropertyChanged("RegData");
                }
            }
        }

        public RWProperty RW
        {
            get
            {
                return _rw;
            }
            set
            {
                _rw = value;
                NotifyPropertyChanged("RW");
            }
        }

        public bool ifRead
        {
            get
            {
                return _ifRead;
            }
            set
            {
                _ifRead = value;
                NotifyPropertyChanged("ifRead");
            }
        }

        public bool ifWrite
        {
            get
            {
                return _ifWrite;
            }
            set
            {
                _ifWrite = value;
                NotifyPropertyChanged("ifWrite");
            }
        }

        //public string Test
        //{
        //    get
        //    {
        //        return _Read;
        //    }
        //    set
        //    {
        //        _Read = value;
        //        NotifyPropertyChanged("Test");
        //    }
        //}
        #endregion
    }

    public class RegisterProperty_WithBitInfo : INotifyPropertyChanged
    {
        private uint _regAddress;
        private string _regDataStr;
        private uint _regData;
        private uint tempData;

        //private bool bit7;
        //private bool bit6;
        //private bool bit5;
        //private bool bit4;
        //private bool bit3;
        //private bool bit2;
        //private bool bit1;
        //private bool bit0;
        private List<bool> BitList = new List<bool>() { false, false, false, false, false, false, false, false };
        private System.Collections.BitArray bitArr;

        #region Bit Operation Mask
        readonly uint bit0_Mask = Convert.ToUInt32(Math.Pow(2, 0));
        readonly uint bit1_Mask = Convert.ToUInt32(Math.Pow(2, 1));
        readonly uint bit2_Mask = Convert.ToUInt32(Math.Pow(2, 2));
        readonly uint bit3_Mask = Convert.ToUInt32(Math.Pow(2, 3));
        readonly uint bit4_Mask = Convert.ToUInt32(Math.Pow(2, 4));
        readonly uint bit5_Mask = Convert.ToUInt32(Math.Pow(2, 5));
        readonly uint bit6_Mask = Convert.ToUInt32(Math.Pow(2, 6));
        readonly uint bit7_Mask = Convert.ToUInt32(Math.Pow(2, 7));
        #endregion Bit Mask

        private System.Collections.BitArray bits = new System.Collections.BitArray(8);
        private uint maxData = 0xFF;
        private uint minData = 0x00;

        private OneWireInterface _device;
        private uint _devAddr;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterProperty_WithBitInfo(uint regAddr, uint regVal, OneWireInterface dev, uint devAddr)
        {
            this._regAddress = regAddr;
            this._regData = regVal;
            this._regDataStr = regVal.ToString("X2");

            this._device = dev;
            this._devAddr = devAddr;

            /* Add to a list in order to opearate easier */
            //BitList.Clear();
            //BitList.Add(bit0);
            //BitList.Add(bit1);
            //BitList.Add(bit2);
            //BitList.Add(bit3);
            //BitList.Add(bit4);
            //BitList.Add(bit5);
            //BitList.Add(bit6);
            //BitList.Add(bit7);
            bitArr = new System.Collections.BitArray(new byte[] { (byte)_regData });
            for (int i = 0; i < 8; i++)
                BitList[i] = bitArr[i];
        }


        public event System.EventHandler GainChanged;
        protected virtual void OnGainChanged()
        {
            System.EventArgs e = new System.EventArgs();
            if (GainChanged != null) GainChanged(this, e);

        }

        public event System.EventHandler RegAddrChanged;
        protected virtual void OnRegAddrChanged()
        {
            System.EventArgs e = new System.EventArgs();
            if (RegAddrChanged != null) RegAddrChanged(this, e);

        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #region Register Properties
        public uint RegAddr
        {
            get
            {
                return (uint)_regAddress;
            }
            set
            {
                if (value <= maxData && value >= minData)
                {
                    _regAddress = (uint)value;
                    NotifyPropertyChanged("RegAddr");
                }
            }
        }

        public string RegDataStr
        {
            get
            {
                return _regDataStr;
            }
            set
            {
                uint tempValue = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);
                if (tempValue == RegData)
                    return;
                if (tempValue <= maxData && tempValue >= minData)
                {
                    _regDataStr = value.ToUpper();
                    RegData = tempValue;
                    //_device.I2CWrite_Single(this._devAddr, this._regAddress, RegData);
                    NotifyPropertyChanged("RegDataStr");
                }
            }
        }

        private uint RegData
        {
            get { return _regData; }
            set 
            {
                _regData = value;
                UpdateBitList(_regData);
            }
        }

        private void UpdateBitList(uint regVal)
        {
            bitArr = new System.Collections.BitArray(new byte[] { (byte)regVal });
            for (int i = 0; i < 8; i++)
            {
                BitList[i] = bitArr[i];
                NotifyPropertyChanged("Bit" + i.ToString());
            }
        }

        public bool Bit7
        {
            get
            {
                return BitList[7];
            }
            set
            {
                BitList[7] = value;
                if (BitList[7])
                    tempData = _regData | bit7_Mask;
                else
                    tempData = _regData & (~bit7_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit7");
            }
        }

        public bool Bit6
        {
            get
            {
                return BitList[6];
            }
            set
            {
                BitList[6] = value;
                if (BitList[6])
                    tempData = _regData | bit6_Mask;
                else
                    tempData = _regData & (~bit6_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit6");
            }
        }

        public bool Bit5
        {
            get
            {
                return BitList[5];
            }
            set
            {
                BitList[5] = value;
                if (BitList[5])
                    tempData = _regData | bit5_Mask;
                else
                    tempData = _regData & (~bit5_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit5");
            }
        }

        public bool Bit4
        {
            get
            {
                return BitList[4];
            }
            set
            {
                BitList[4] = value;
                if (BitList[4])
                    tempData = _regData | bit4_Mask;
                else
                    tempData = _regData & (~bit4_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit4");
            }
        }

        public bool Bit3
        {
            get
            {
                return BitList[3];
            }
            set
            {
                BitList[3] = value;
                if (BitList[3])
                    tempData = _regData | bit3_Mask;
                else
                    tempData = _regData & (~bit3_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit3");
            }
        }

        public bool Bit2
        {
            get
            {
                return BitList[2];
            }
            set
            {
                BitList[2] = value;
                if (BitList[2])
                    tempData = _regData | bit2_Mask;
                else
                    tempData = _regData & (~bit2_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit2");
            }
        }

        public bool Bit1
        {
            get
            {
                return BitList[1];
            }
            set
            {
                BitList[1] = value;
                if (BitList[1])
                    tempData = _regData | bit1_Mask;
                else
                    tempData = _regData & (~bit1_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit1");
            }
        }

        public bool Bit0
        {
            get
            {
                return BitList[0];
            }
            set
            {
                BitList[0] = value;
                if (BitList[0])
                    tempData = _regData | bit0_Mask;
                else
                    tempData = _regData & (~bit0_Mask);
                RegDataStr = tempData.ToString("X2");
                NotifyPropertyChanged("RegDataStr");
                NotifyPropertyChanged("Bit0");
            }
        }
        #endregion
    }

    public enum RWProperty
    {
        RW,
        R,
        W
    }

}
