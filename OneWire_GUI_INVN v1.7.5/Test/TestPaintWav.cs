using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADI.DMY2;
using System.IO;

namespace Test
{
    public partial class TestPaintWav : Form
    {
        //private double[] basePoints = new double[32] {8.4, 8.6, 8.9, 9.2, 9.6, 10.2,11.4,12.4,13.6,
        //    12.5,11.8,10.5,9.8,9.6,9.2,8.8,8.6,8.5,8.4,8.3,8.25,8.20,8.16,8.13,8.12,8.11,8.10,8.09,8.08,8.07,8.06,8.06 };

        private double[] basePoints = new double[32] {8.4, 8.6, 8.9, 9.2, 9.6, 10.2,11.2,12.4,13.6,
            12.5,11.6,10.5,9.8,9.4,9.2,9.0,8.8,8.7,8.6,8.5,8.45,8.40,8.36,8.33,8.32,8.31,8.30,8.29,8.28,8.27,8.26,8.26 };

        private double[] willFixed1 = new double[32] { 8.4,10.8,9.5,9.9,9.2,11.2,12.2,12.1,12.1,
            11.2,10.4,10.6,10.1,9.5,9.0,9.2,9.1,10.5,8.8,8.7,8.6,8.8,8.5,8.45,8.40,8.35,8.32,8.30,8.29,8.28,8.27,8.26};
        //private double[] willFixed1 = new double[32] { 8.1399998664856,8.69999933242798,8.52999949455261, 8.56999945640564,
        //    9.33999872207642,10.3899977207184, 11.7399964332581, 10.9499971866608, 12.4799957275391, 13.6899945735931,
        //    11.2799968719482, 10.60999751091, 10.0599980354309, 9.34999871253967, 9.10999894142151, 9.49999856948853, 
        //    8.77999925613403, 8.4399995803833, 8.34999966621399, 8.18999981880188, 8.02999997138977, 8.05999994277954,
        //    8.02999997138977, 8.07999992370605, 7.89000010490417, 7.83000016212463, 7.91000008583069, 7.81000018119812,
        //    7.77000021934509, 7.8600001335144, 7.88000011444092, 7.91000008583069};

        private int[] paintPointsY;
        //private double[] fixedData = new double[64];
        private Point[] paintPoints;
        ADI.DMY2.SPKProtection mydevice = new SPKProtection();
        private string str_SavePath = "";

        public TestPaintWav()
        {
            InitializeComponent();
            //paintPointsY = PointsPrcess(basePoints);
            //paintPoints = GeneratePoints(paintPointsY);

            paintPointsY = RawPointsPrcess1(basePoints);
            mydevice.Calibrate(paintPointsY);
        }

        private int[] PointsPrcess(double[] _points)
        {
            int[] pp = new int[_points.Length];
            for (int i = 0; i < _points.Length; i++)
            {
                pp[i] = this.paintPanal1.Size.Height - (Convert.ToInt32(_points[i] * 50) - 350);
            }
            return pp;
        }

        private int[] RawPointsPrcess1(double[] _points)
        {
            int[] pp = new int[_points.Length];
            for (int i = 0; i < _points.Length; i++)
            {
                pp[i] = Convert.ToInt32(_points[i] * 50);
            }
            return pp;
        }

        private int[] RawPointsPrcess2(int[] _points)
        {
            int[] pp = new int[_points.Length];
            for (int i = 0; i < _points.Length; i++)
            {
                pp[i] = this.paintPanal1.Size.Height - (_points[i] - 350);
            }
            return pp;
        }


        private Point[] GeneratePoints(int[] _intP)
        {
            Point[] Ps = new Point[_intP.Length];
            for (int i = 0; i < _intP.Length; i++)
            {
                Ps[i] = new Point(i * 25, _intP[i]);
            }

            return Ps;
        }

        private void picB_wavPanal_Paint(object sender, PaintEventArgs e)
        {
        }

        //private void DrawPoints(Point[] _points)
        //{
        //    Graphics g = this.CreateGraphics();
        //    for (int i = 0; i < _points.Length; i++)
        //    {
        //        g.DrawEllipse(Pens.Black, _points[i].X - 1, _points[i].Y - 1, 2, 2);
        //    }
        //    g.Dispose();
        //}

        private void RePaint()
        {
            this.paintPanal1.Refresh();

            #region drawPoints
            // Point 1
            if (basePoints != null && chb_baseP.Checked)
            {
                paintPointsY = PointsPrcess(basePoints);
                paintPoints = GeneratePoints(paintPointsY);
                this.paintPanal1.DrawPoints(new Pen(Color.Red, 2), paintPoints);
            }
            // Point 2
            if (willFixed1 != null && chb_willFixP.Checked)
            {
                paintPointsY = PointsPrcess(willFixed1);
                paintPoints = GeneratePoints(paintPointsY);
                this.paintPanal1.DrawPoints(new Pen(Color.Blue, 2), paintPoints);
            }
            //Point 3
            if (willFixed1 != null && chb_FixedP.Checked)
            {
                paintPointsY = RawPointsPrcess1(willFixed1);
                paintPointsY = mydevice.FixPointsY(paintPointsY,false);
                paintPointsY = RawPointsPrcess2(paintPointsY);
                paintPoints = GeneratePoints(paintPointsY);
                //for (int i = 0; i < paintPoints.Length; i++)
                //{
                //    paintPoints[i].X *= 25;
                this.paintPanal1.DrawPoints(new Pen(Color.Green, 2), paintPoints);
                //}
            }
            #endregion

            #region drawCurves
            //curve 1
            if (basePoints != null && chb_baseCurve.Checked)
            {
                paintPointsY = PointsPrcess(basePoints);
                paintPoints = GeneratePoints(paintPointsY);
                this.paintPanal1.DrawLines(new Pen(Color.Red, 2), paintPoints);
            }
            //curve 2
            if (willFixed1 != null && chb_willFixCurve.Checked)
            {
                paintPointsY = PointsPrcess(willFixed1);
                paintPoints = GeneratePoints(paintPointsY);
                this.paintPanal1.DrawLines(new Pen(Color.Blue, 2), paintPoints);
            }
            //curve 3
            if (willFixed1 != null && chb_fixedCurve.Checked)
            {
                paintPointsY = RawPointsPrcess1(willFixed1);
                paintPointsY = mydevice.FixPointsY(paintPointsY,false);
                paintPointsY = RawPointsPrcess2(paintPointsY);
                paintPoints = GeneratePoints(paintPointsY);
                //for (int i = 0; i < paintPoints.Length; i++)
                //{
                //    paintPoints[i].X *= 25;
                this.paintPanal1.DrawLines(new Pen(Color.Green, 2), paintPoints);
                //}
            }
            #endregion

            //Fixed by slope
            if (willFixed1 != null && chb_fixedBySlop.Checked)
            {
                paintPointsY = RawPointsPrcess1(willFixed1);
                paintPointsY = mydevice.FixPointsY(paintPointsY, true);
                paintPointsY = RawPointsPrcess2(paintPointsY);
                paintPoints = GeneratePoints(paintPointsY);
                //for (int i = 0; i < paintPoints.Length; i++)
                //{
                //    paintPoints[i].X *= 25;
                this.paintPanal1.DrawPoints(new Pen(Color.Black, 2), paintPoints);
                this.paintPanal1.DrawLines(new Pen(Color.Black, 2), paintPoints);
                //}
            }
        }

        private void ExportFile(string DesPath, List<double> X, List<double> Y)
        {
            if (willFixed1 != null)
            {
                paintPointsY = RawPointsPrcess1(Y.ToArray());
                paintPointsY = mydevice.FixPointsY(paintPointsY, true);

                //for (int i = 0; i < paintPointsY.Length; i++)
                //{
                //    fixedData[32 + i] = (double)paintPointsY[i] / (double)50;
                //}

                if (File.Exists(DesPath))
                {
                    File.Delete(DesPath);
                }
                StreamWriter strWrite = File.CreateText(DesPath);
                strWrite.WriteLine("(x,y)");
                for (int i = 0; i < X.Count; i++)
                {
                    strWrite.WriteLine(X[i].ToString() + "," + ((double)paintPointsY[i] / (double)50).ToString());
                }
                strWrite.Close();
                
            }
        }

        private void chb_baseP_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_baseP.Checked)
                chb_baseP.BackColor = Color.IndianRed;
            else
                chb_baseP.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void chb_willFixP_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_willFixP.Checked)
                chb_willFixP.BackColor = Color.SkyBlue;
            else
                chb_willFixP.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void chb_FixedP_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_FixedP.Checked)
                chb_FixedP.BackColor = Color.YellowGreen;
            else
                chb_FixedP.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void chb_baseCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_baseCurve.Checked)
                chb_baseCurve.BackColor = Color.IndianRed;
            else
                chb_baseCurve.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void chb_willFixCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_willFixCurve.Checked)
                chb_willFixCurve.BackColor = Color.SkyBlue;
            else
                chb_willFixCurve.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void chb_fixedCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_fixedCurve.Checked)
                chb_fixedCurve.BackColor = Color.YellowGreen;
            else
                chb_fixedCurve.UseVisualStyleBackColor = true;
            RePaint();
        }

        private void btn_openData_Click(object sender, EventArgs e)
        {
            //double[] readDataX = new double[32];
            //double[] readDataY = new double[32];
            List<double> readDataX = new List<double> { };
            List<double> readDataY = new List<double> { };
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Read from ...";
            ofd.Filter = "txt files(*.txt)|*.txt|All Files(*.*)|*.*";
            //ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string str_regFilePath = ofd.FileName;
                str_SavePath = Path.GetDirectoryName(str_regFilePath) + "\\Fiexd";
                if (!Directory.Exists(str_SavePath))
                    Directory.CreateDirectory(str_SavePath);

                str_SavePath = str_SavePath + "\\new_" + Path.GetFileName(str_regFilePath);
                StreamReader strRead = File.OpenText(str_regFilePath);
                strRead.ReadLine();
                string[] strArray_readLine = new string[2];
               
                #region Read data from local file
                while (!strRead.EndOfStream)
                {
                    strArray_readLine = strRead.ReadLine().Trim().Split(',');
                    try
                    {
                        readDataX.Add(Convert.ToDouble(strArray_readLine[0]));
                        readDataY.Add(Convert.ToDouble(strArray_readLine[1]));
                    }
                    catch
                    {
                        strRead.Close();
                        MessageBox.Show("Read error, please check the data file.");
                        return;
                    }
                }
                strRead.Close();
                #endregion 

                //show frequency scope
                this.lbl_frequency.Text = Convert.ToInt32(readDataX[0]).ToString() + " - " + Convert.ToInt32(readDataX[readDataX.Count - 1]).ToString() + "(HZ)";
                this.lbl_fileName.Text = ofd.FileName;
                //replace Y value for fixing.
                //readDataX.CopyTo(fixedData,0);
                ExportFile(str_SavePath, readDataX, readDataY);
                willFixed1 = readDataY.ToArray();
                RePaint();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mydevice.RiseRatio = Convert.ToDouble(this.numUD_riseRatio.Value);
        }

        private void chb_fixedBySlop_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_fixedBySlop.Checked)
                chb_fixedBySlop.BackColor = Color.YellowGreen;
            else
                chb_fixedBySlop.UseVisualStyleBackColor = true;
            RePaint();
        }
    }
}
