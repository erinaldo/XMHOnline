using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBOMMoveOper : Form
    {
        public FrmBOMMoveOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.lnkManufProcess.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkManufProcess_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

        private FrmManufProcessOper frmOper;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;
        public delegate void AffterSelectDelegate(long ManufProcessID);
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
        private int PrdID = -1;
        public void BOMMoveOper(int PrdID)
        {
            this.PrdID = PrdID;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(this.PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblManufProcess;
        }
        void lnkManufProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmManufProcessOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmManufProcessOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.ManufProcessOper(this.PrdID);
            frmOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.LoadData();
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol=e.ColumnIndex ;
            if((irow==-1)||(icol==-1))return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
            
                long ManufProcessID = (long)this.dtblManufProcess.DefaultView[irow]["ManufProcessID"];
                if (this.affterSelect != null)
                {
                    this.affterSelect (ManufProcessID);

                }
                this.Close();
            }
        }

    }
}