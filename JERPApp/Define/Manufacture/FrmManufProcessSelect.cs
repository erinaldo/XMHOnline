using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmManufProcessSelect : Form
    {
        public FrmManufProcessSelect()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.ctrlProcessTypeID.AffterSelected +=LoadData;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.LoadData();
        }

     
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;       
        public delegate void AffterSelectedDelegate(DataRow drow);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSalected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        void LoadData()
        {
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByProcessTypeID(this.ctrlProcessTypeID.ProcessTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblManufProcess;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                DataRow drow = this.dtblManufProcess.DefaultView[irow].Row;
                if (this.affterSelected != null) this.affterSelected(drow);
            }
        }
    }
}