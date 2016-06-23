using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JCEApp.Define.Product
{
    public partial class CtrlBoxItemRow : UserControl
    {
        public CtrlBoxItemRow()
        {
            InitializeComponent();
             ControlStyle.SetStyle(this);
            this.ColumnHeaderVisible = false;
        }


        //列标题显示
        private  bool columnheadervisible = false;
        public bool ColumnHeaderVisible
        {
            get
            {
                return this.columnheadervisible;
            }
            set
            {
                this.columnheadervisible = value;
                this.pnlHeader.Visible = value;
                this.Height = (value) ? HeaderHeight + RowHeight : RowHeight;
            }
        }
        public int HeaderHeight = 24;
        public int RowHeight = 22;
        private  DataTable dtblSrc;
        public DataRow Row
        {
            get
            {
                return this.dtblSrc.Rows[0];
            }
        }     
        public void BindData(DataRow drow)
        {
            this.dtblSrc = drow.Table.Clone();
            this.dtblSrc.ImportRow(drow);
            this.txtBarcode.DataBindings.Add("Text", this.dtblSrc, "Barcode");         
        }
  
    }
}
