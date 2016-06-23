using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Frame
{
    public partial class FrmRole : Form
    {
        public FrmRole()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accRoles = new JERPData.Frame.Roles();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mRefresh.Click += new EventHandler(mRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

    
        private DataTable dtblRoles;
        private JERPData.Frame.Roles accRoles;
        public delegate void AffterSelectDelegate(DataRow drow);
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

        public void LoadData()
        {
            this.dtblRoles = this.accRoles.GetDataRoles().Tables[0];
            this.dgrdv.DataSource = this.dtblRoles;
        }

        void mRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                if (this.affterSelect != null)
                {
                    this.affterSelect(this.dtblRoles.DefaultView[irow].Row);
                }

            }
        }


    }
}