using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Hr
{
    public partial class FrmPsnSel : Form
    {
        public FrmPsnSel()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPersonnel = new JERPData.Hr.Personnel();  
            this.SetPermit();
        }

        private DataTable dtblPsns;
        private JERPData.Hr.Personnel accPersonnel;

        private string whereclause = string.Empty;

        private void SetPermit()
        {
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.btnClose.Click += new EventHandler(btnClose_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadData()
        {
            this.dtblPsns = this.accPersonnel.GetDataPersonnelOnjob().Tables[0];
            this.dgrdv.DataSource = this.dtblPsns;
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        //datagrid点击事件
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow = this.dtblPsns.DefaultView[irow].Row;
            if (this.dgrdv.Columns[icol].Name == this.btnSelect.Name)
            {
                if (this.affterSelected != null) this.affterSelected(drow);
            }
        }

        //查询
        void ctrlQFind_BeforeFilter()
        {
            this.dgrdv.DataSource = this.dtblPsns;
        }


        public delegate void AffterSelectedDelegate(DataRow drow);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
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

    }
}
