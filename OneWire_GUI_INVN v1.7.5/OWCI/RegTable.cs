using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OWCI
{
    public partial class RegTable : UserControl
    {
        public RegTable()
        {
            InitializeComponent();
        }

        public RegTable(BindingList<RegisterProperty_WithBitInfo> blist)
        {
            InitializeComponent();

            #region Comment out -- Adding column for RegiserProperty class.
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.AutoSize = true;
            //dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            //dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            //DataGridViewTextBoxColumn indexColumn = new DataGridViewTextBoxColumn();
            //indexColumn.DataPropertyName = "Index";
            //indexColumn.HeaderText = " ";
            //indexColumn.ReadOnly = true;
            //indexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //indexColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //indexColumn.Selected = false;
            //indexColumn.DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;
            //indexColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //DataGridViewTextBoxColumn regAddrColumn = new DataGridViewTextBoxColumn();
            //regAddrColumn.DataPropertyName = "regAddr";
            //regAddrColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //regAddrColumn.HeaderText = "Addr(H2)";
            //regAddrColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //regAddrColumn.DefaultCellStyle.Format = "X2";
            //regAddrColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //regAddrColumn.ReadOnly = true;
            //regAddrColumn.Selected = false;

            //DataGridViewTextBoxColumn regDataColumn = new DataGridViewTextBoxColumn();
            //regDataColumn.DataPropertyName = "regData";
            //regDataColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //regDataColumn.HeaderText = "Data(H2)";
            //regDataColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //regDataColumn.DefaultCellStyle.Format = "X2";
            //regDataColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ////regDataColumn.ReadOnly = true;
            //regDataColumn.Selected = false;
            

            //DataGridViewComboBoxColumn rwColumn = new DataGridViewComboBoxColumn();
            //rwColumn.DataPropertyName = "rw";
            //rwColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ////rwColumn.Width = 100;
            //rwColumn.HeaderText = "RW";
            //rwColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //rwColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //rwColumn.Items.AddRange(new object[] {
            //RWProperty.RW,
            //RWProperty.R,
            //RWProperty.W});
            //rwColumn.Selected = false;
            //rwColumn.ReadOnly = true;
            //rwColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

            //DataGridViewCheckBoxColumn ifReadColumn = new DataGridViewCheckBoxColumn();
            //ifReadColumn.DataPropertyName = "ifRead";
            //ifReadColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //ifReadColumn.HeaderText = "If Read";
            //ifReadColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //ifReadColumn.Selected = false;

            //DataGridViewCheckBoxColumn ifWriteColumn = new DataGridViewCheckBoxColumn();
            //ifWriteColumn.DataPropertyName = "ifWrite";
            //ifWriteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //ifWriteColumn.HeaderText = "If Write";
            //ifWriteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //ifWriteColumn.Selected = false;

            //DataGridViewButtonColumn test = new DataGridViewButtonColumn();
            //test.DataPropertyName = "test";
            //test.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //test.HeaderText = "Test R";
            //test.SortMode = DataGridViewColumnSortMode.NotSortable;
            //test.Selected = false;
            //test.Text = "asfds";
            //test.Name = "fasdfsa";

            //dataGridView1.Columns.Add(indexColumn);
            //dataGridView1.Columns.Add(regAddrColumn);
            //dataGridView1.Columns.Add(regDataColumn);
            //dataGridView1.Columns.Add(rwColumn);
            //dataGridView1.Columns.Add(ifReadColumn);
            //dataGridView1.Columns.Add(ifWriteColumn);
            //dataGridView1.Columns.Add(test);
            #endregion 

            #region Adding column for RegisterProperty_WithBitInfo class.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.AutoSize = true;
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            DataGridViewTextBoxColumn regAddrColumn = new DataGridViewTextBoxColumn();
            regAddrColumn.DataPropertyName = "regAddr";
            regAddrColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            regAddrColumn.HeaderText = "Addr(H2)";
            regAddrColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            regAddrColumn.DefaultCellStyle.Format = "X2";
            regAddrColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            regAddrColumn.ReadOnly = true;
            regAddrColumn.Selected = false;

            DataGridViewCheckBoxColumn Bit7 = new DataGridViewCheckBoxColumn();
            Bit7.DataPropertyName = "Bit7";
            Bit7.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            Bit7.HeaderText = "b7";
            Bit7.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit7.Selected = false;

            DataGridViewCheckBoxColumn Bit6 = new DataGridViewCheckBoxColumn();
            Bit6.DataPropertyName = "Bit6";
            Bit6.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit6.HeaderText = "b6";
            Bit6.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit6.Selected = false;

            DataGridViewCheckBoxColumn Bit5 = new DataGridViewCheckBoxColumn();
            Bit5.DataPropertyName = "Bit5";
            Bit5.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit5.HeaderText = "b5";
            Bit5.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit5.Selected = false;

            DataGridViewCheckBoxColumn Bit4 = new DataGridViewCheckBoxColumn();
            Bit4.DataPropertyName = "Bit4";
            Bit4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit4.HeaderText = "b4";
            Bit4.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit4.Selected = false;

            DataGridViewTextBoxColumn dummy = new DataGridViewTextBoxColumn();
            dummy.DataPropertyName = "dummy";
            dummy.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dummy.HeaderText = "";
            dummy.SortMode = DataGridViewColumnSortMode.NotSortable;
            dummy.DefaultCellStyle.Format = "X2";
            dummy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dummy.ReadOnly = true;
            dummy.Selected = false;

            DataGridViewCheckBoxColumn Bit3 = new DataGridViewCheckBoxColumn();
            Bit3.DataPropertyName = "Bit3";
            Bit3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit3.HeaderText = "b3";
            Bit3.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit3.Selected = false;

            DataGridViewCheckBoxColumn Bit2 = new DataGridViewCheckBoxColumn();
            Bit2.DataPropertyName = "Bit2";
            Bit2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit2.HeaderText = "b2";
            Bit2.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit2.Selected = false;

            DataGridViewCheckBoxColumn Bit1 = new DataGridViewCheckBoxColumn();
            Bit1.DataPropertyName = "Bit1";
            Bit1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit1.HeaderText = "b1";
            Bit1.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit1.Selected = false;

            DataGridViewCheckBoxColumn Bit0 = new DataGridViewCheckBoxColumn();
            Bit0.DataPropertyName = "Bit0";
            Bit0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Bit0.HeaderText = "b0";
            Bit0.SortMode = DataGridViewColumnSortMode.NotSortable;
            Bit0.Selected = false;

            DataGridViewTextBoxColumn regDataColumn = new DataGridViewTextBoxColumn();
            regDataColumn.DataPropertyName = "regDataStr";
            regDataColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            regDataColumn.HeaderText = "Data(H2)";
            regDataColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            regDataColumn.DefaultCellStyle.Format = "X2";
            regDataColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //regDataColumn.ReadOnly = true;
            regDataColumn.Selected = false;

            dataGridView1.Columns.Add(regAddrColumn);
            dataGridView1.Columns.Add(Bit7);
            dataGridView1.Columns.Add(Bit6);
            dataGridView1.Columns.Add(Bit5);
            dataGridView1.Columns.Add(Bit4);
            dataGridView1.Columns.Add(dummy);
            dataGridView1.Columns.Add(Bit3);
            dataGridView1.Columns.Add(Bit2);
            dataGridView1.Columns.Add(Bit1);
            dataGridView1.Columns.Add(Bit0);
            dataGridView1.Columns.Add(regDataColumn);
            #endregion 


            dataGridView1.DataSource = blist;
        }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex <= 8)
            //{
            //    e.
            //}
        }

        public void BindingDataSource(BindingList<RegisterProperty_WithBitInfo> regList)
        {
            dataGridView1.DataSource = regList;
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
                if (this.dataGridView1.CurrentCell.ColumnIndex == 10)
                {
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                }
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                //if (e.KeyChar != '\b' || !"abcdefABCDEF".Contains(e.KeyChar.ToString()) || e.KeyChar != '-' || e.KeyChar != '+') //allow the backspace and minus
                if (e.KeyChar != '\b' && !"abcdefABCDEF".Contains(e.KeyChar.ToString())) //allow the backspace and minus
                {
                    e.Handled = true;
                }
            }
        }
    }
}
