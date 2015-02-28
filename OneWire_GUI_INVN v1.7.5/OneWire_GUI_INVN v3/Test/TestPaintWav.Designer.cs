namespace Test
{
    partial class TestPaintWav
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
            this.grb_drawPoints = new System.Windows.Forms.GroupBox();
            this.chb_FixedP = new System.Windows.Forms.CheckBox();
            this.chb_willFixP = new System.Windows.Forms.CheckBox();
            this.chb_baseP = new System.Windows.Forms.CheckBox();
            this.grb_drawCurve = new System.Windows.Forms.GroupBox();
            this.chb_fixedCurve = new System.Windows.Forms.CheckBox();
            this.chb_willFixCurve = new System.Windows.Forms.CheckBox();
            this.chb_baseCurve = new System.Windows.Forms.CheckBox();
            this.btn_openData = new System.Windows.Forms.Button();
            this.lbl_frequency = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_fileName = new System.Windows.Forms.Label();
            this.numUD_riseRatio = new System.Windows.Forms.NumericUpDown();
            this.chb_fixedBySlop = new System.Windows.Forms.CheckBox();
            this.paintPanal1 = new Test.PaintPanal();
            this.grb_drawPoints.SuspendLayout();
            this.grb_drawCurve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_riseRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_drawPoints
            // 
            this.grb_drawPoints.Controls.Add(this.chb_FixedP);
            this.grb_drawPoints.Controls.Add(this.chb_willFixP);
            this.grb_drawPoints.Controls.Add(this.chb_baseP);
            this.grb_drawPoints.Location = new System.Drawing.Point(11, 12);
            this.grb_drawPoints.Name = "grb_drawPoints";
            this.grb_drawPoints.Size = new System.Drawing.Size(95, 118);
            this.grb_drawPoints.TabIndex = 7;
            this.grb_drawPoints.TabStop = false;
            this.grb_drawPoints.Text = "Draw Points";
            // 
            // chb_FixedP
            // 
            this.chb_FixedP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_FixedP.Location = new System.Drawing.Point(14, 81);
            this.chb_FixedP.Name = "chb_FixedP";
            this.chb_FixedP.Size = new System.Drawing.Size(63, 23);
            this.chb_FixedP.TabIndex = 2;
            this.chb_FixedP.Text = "Fixed";
            this.chb_FixedP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_FixedP.UseVisualStyleBackColor = true;
            this.chb_FixedP.CheckedChanged += new System.EventHandler(this.chb_FixedP_CheckedChanged);
            // 
            // chb_willFixP
            // 
            this.chb_willFixP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_willFixP.Location = new System.Drawing.Point(14, 50);
            this.chb_willFixP.Name = "chb_willFixP";
            this.chb_willFixP.Size = new System.Drawing.Size(63, 23);
            this.chb_willFixP.TabIndex = 1;
            this.chb_willFixP.Text = "Will Fix";
            this.chb_willFixP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_willFixP.UseVisualStyleBackColor = true;
            this.chb_willFixP.CheckedChanged += new System.EventHandler(this.chb_willFixP_CheckedChanged);
            // 
            // chb_baseP
            // 
            this.chb_baseP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_baseP.Location = new System.Drawing.Point(14, 19);
            this.chb_baseP.Name = "chb_baseP";
            this.chb_baseP.Size = new System.Drawing.Size(63, 23);
            this.chb_baseP.TabIndex = 0;
            this.chb_baseP.Text = "Base";
            this.chb_baseP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_baseP.UseVisualStyleBackColor = true;
            this.chb_baseP.CheckedChanged += new System.EventHandler(this.chb_baseP_CheckedChanged);
            // 
            // grb_drawCurve
            // 
            this.grb_drawCurve.Controls.Add(this.chb_fixedCurve);
            this.grb_drawCurve.Controls.Add(this.chb_willFixCurve);
            this.grb_drawCurve.Controls.Add(this.chb_baseCurve);
            this.grb_drawCurve.Location = new System.Drawing.Point(12, 166);
            this.grb_drawCurve.Name = "grb_drawCurve";
            this.grb_drawCurve.Size = new System.Drawing.Size(95, 118);
            this.grb_drawCurve.TabIndex = 8;
            this.grb_drawCurve.TabStop = false;
            this.grb_drawCurve.Text = "Draw Curve";
            // 
            // chb_fixedCurve
            // 
            this.chb_fixedCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_fixedCurve.Location = new System.Drawing.Point(14, 79);
            this.chb_fixedCurve.Name = "chb_fixedCurve";
            this.chb_fixedCurve.Size = new System.Drawing.Size(63, 23);
            this.chb_fixedCurve.TabIndex = 5;
            this.chb_fixedCurve.Text = "Fixed";
            this.chb_fixedCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_fixedCurve.UseVisualStyleBackColor = true;
            this.chb_fixedCurve.CheckedChanged += new System.EventHandler(this.chb_fixedCurve_CheckedChanged);
            // 
            // chb_willFixCurve
            // 
            this.chb_willFixCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_willFixCurve.Location = new System.Drawing.Point(14, 48);
            this.chb_willFixCurve.Name = "chb_willFixCurve";
            this.chb_willFixCurve.Size = new System.Drawing.Size(63, 23);
            this.chb_willFixCurve.TabIndex = 4;
            this.chb_willFixCurve.Text = "Will Fix";
            this.chb_willFixCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_willFixCurve.UseVisualStyleBackColor = true;
            this.chb_willFixCurve.CheckedChanged += new System.EventHandler(this.chb_willFixCurve_CheckedChanged);
            // 
            // chb_baseCurve
            // 
            this.chb_baseCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_baseCurve.Location = new System.Drawing.Point(14, 17);
            this.chb_baseCurve.Name = "chb_baseCurve";
            this.chb_baseCurve.Size = new System.Drawing.Size(63, 23);
            this.chb_baseCurve.TabIndex = 3;
            this.chb_baseCurve.Text = "Base";
            this.chb_baseCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_baseCurve.UseVisualStyleBackColor = true;
            this.chb_baseCurve.CheckedChanged += new System.EventHandler(this.chb_baseCurve_CheckedChanged);
            // 
            // btn_openData
            // 
            this.btn_openData.Location = new System.Drawing.Point(25, 347);
            this.btn_openData.Name = "btn_openData";
            this.btn_openData.Size = new System.Drawing.Size(75, 23);
            this.btn_openData.TabIndex = 9;
            this.btn_openData.Text = "Open Data";
            this.btn_openData.UseVisualStyleBackColor = true;
            this.btn_openData.Click += new System.EventHandler(this.btn_openData_Click);
            // 
            // lbl_frequency
            // 
            this.lbl_frequency.AutoSize = true;
            this.lbl_frequency.Location = new System.Drawing.Point(528, 475);
            this.lbl_frequency.Name = "lbl_frequency";
            this.lbl_frequency.Size = new System.Drawing.Size(79, 13);
            this.lbl_frequency.TabIndex = 10;
            this.lbl_frequency.Text = "400 - 1950(HZ)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "8.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "9.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "10.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "11.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "12.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "13.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "14.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "15.0";
            // 
            // lbl_fileName
            // 
            this.lbl_fileName.AutoSize = true;
            this.lbl_fileName.Location = new System.Drawing.Point(22, 475);
            this.lbl_fileName.Name = "lbl_fileName";
            this.lbl_fileName.Size = new System.Drawing.Size(0, 13);
            this.lbl_fileName.TabIndex = 19;
            // 
            // numUD_riseRatio
            // 
            this.numUD_riseRatio.DecimalPlaces = 2;
            this.numUD_riseRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUD_riseRatio.Location = new System.Drawing.Point(27, 382);
            this.numUD_riseRatio.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.numUD_riseRatio.Minimum = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.numUD_riseRatio.Name = "numUD_riseRatio";
            this.numUD_riseRatio.Size = new System.Drawing.Size(73, 20);
            this.numUD_riseRatio.TabIndex = 20;
            this.numUD_riseRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_riseRatio.Value = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.numUD_riseRatio.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chb_fixedBySlop
            // 
            this.chb_fixedBySlop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_fixedBySlop.Location = new System.Drawing.Point(12, 297);
            this.chb_fixedBySlop.Name = "chb_fixedBySlop";
            this.chb_fixedBySlop.Size = new System.Drawing.Size(100, 30);
            this.chb_fixedBySlop.TabIndex = 21;
            this.chb_fixedBySlop.Text = "Fixed Bt Slope";
            this.chb_fixedBySlop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_fixedBySlop.UseVisualStyleBackColor = true;
            this.chb_fixedBySlop.CheckedChanged += new System.EventHandler(this.chb_fixedBySlop_CheckedChanged);
            // 
            // paintPanal1
            // 
            this.paintPanal1.BackColor = System.Drawing.Color.White;
            this.paintPanal1.Location = new System.Drawing.Point(187, 12);
            this.paintPanal1.Name = "paintPanal1";
            this.paintPanal1.Size = new System.Drawing.Size(801, 451);
            this.paintPanal1.TabIndex = 2;
            // 
            // TestPaintWav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1013, 510);
            this.Controls.Add(this.chb_fixedBySlop);
            this.Controls.Add(this.numUD_riseRatio);
            this.Controls.Add(this.lbl_fileName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_frequency);
            this.Controls.Add(this.btn_openData);
            this.Controls.Add(this.grb_drawCurve);
            this.Controls.Add(this.grb_drawPoints);
            this.Controls.Add(this.paintPanal1);
            this.Name = "TestPaintWav";
            this.Text = "TestPaintCurve v1.1";
            this.grb_drawPoints.ResumeLayout(false);
            this.grb_drawCurve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_riseRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PaintPanal paintPanal1;
        private System.Windows.Forms.GroupBox grb_drawPoints;
        private System.Windows.Forms.GroupBox grb_drawCurve;
        private System.Windows.Forms.CheckBox chb_baseP;
        private System.Windows.Forms.CheckBox chb_FixedP;
        private System.Windows.Forms.CheckBox chb_willFixP;
        private System.Windows.Forms.CheckBox chb_fixedCurve;
        private System.Windows.Forms.CheckBox chb_willFixCurve;
        private System.Windows.Forms.CheckBox chb_baseCurve;
        private System.Windows.Forms.Button btn_openData;
        private System.Windows.Forms.Label lbl_frequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_fileName;
        private System.Windows.Forms.NumericUpDown numUD_riseRatio;
        private System.Windows.Forms.CheckBox chb_fixedBySlop;
    }
}