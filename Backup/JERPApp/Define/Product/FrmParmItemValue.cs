using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmParmItemValue : Form
    {
        public FrmParmItemValue()
        {
            InitializeComponent();
            this.dtblValues = new DataTable();
            this.dtblValues.Columns.Add("ParmValue", typeof(string));
            this.dgrdv.DataSource = this.dtblValues;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private DataTable dtblValues;
        public void SetParmSrc(string ItemValues)
        {
            string[] ValueList = ItemValues.Split(';');
            this.dtblValues.Clear();
            foreach (string vl in ValueList)
            {
                this.dtblValues.Rows.Add(vl);
            }

        }
        public delegate void AffterSelectDelegate(object  ParmValue);
        private AffterSelectDelegate affterSelect;
        public event AffterSelectDelegate AffterSelect
        {
            add
            {
                affterSelect += value;
            }
            remove
            {
                affterSelect -= value;
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                object  ParmValue = this.dgrdv[this.ColumnParmValue.Name, irow].Value;
                if (this.affterSelect  != null) this.affterSelect (ParmValue);
                this.Close();
            }
        }
    }
}