using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBatchBuyer : Form
    {
        public FrmBatchBuyer()
        {
            InitializeComponent();
            this.accPsns = new JERPData.Hr.Personnel();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.SetColumnSrc();
        }
        private JERPData.Hr.Personnel accPsns;
        private DataTable dtblBuyer, dtblPsns;
        private void SetColumnSrc()
        {
            this.dtblPsns  = this.accPsns.GetDataPersonnel ().Tables[0];
            this.dtblPsns.Columns.Add("Exp", typeof(string), "ISNULL(AssistantCode,'')+ISNULL(PsnName,'')");
            this.ColumnPsnID.DataSource = this.dtblPsns;
            this.ColumnPsnID.ValueMember = "PsnID";
            this.ColumnPsnID.DisplayMember = "Exp";
        }
        public delegate void AffterSaveDelegate(DataRow[] drowPsns,bool BuyFlag);
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        public void BatchBuyer()
        {
            this.dtblBuyer  = new DataTable();
            this.dtblBuyer.Columns.Add("PsnID", typeof(int));
            this.dtblBuyer.Columns["PsnID"].AllowDBNull = false;
            this.dtblBuyer.Columns["PsnID"].Unique = true;
            this.dgrdv.DataSource = this.dtblBuyer;
        }
        bool ValidateData()
        {
            if (this.dtblBuyer .Select ("","",DataViewRowState.CurrentRows).Length ==0)
            {
                MessageBox.Show("对不起人员未选择");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("即将批量设定所选产品采购员，请确认！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            DataRow[] drows = this.dtblBuyer .Select("", "", DataViewRowState.CurrentRows);
            this.affterSave(drows, true);
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("即将批量取消所选产品采购员，请确认！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            DataRow[] drows = this.dtblBuyer.Select("", "", DataViewRowState.CurrentRows);
            this.affterSave(drows, false);
        }

    }
}