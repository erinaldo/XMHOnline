using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmRepairInvoiceFieldTitle : Form
    {
        public FrmRepairInvoiceFieldTitle()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accFieldDetail = new JERPData.Product.RepairInvoiceFieldDetail();
            this.accFieldTitle = new JERPData.Product.RepairInvoiceFieldTitle();
            this.accField = new JERPData.Product.RepairInvoiceField();
            this.SetDataSrc();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete .Click +=new EventHandler(btnDelete_Click);
        }

    
        JERPData.Product.RepairInvoiceFieldTitle accFieldTitle;
        JERPData.Product.RepairInvoiceFieldDetail accFieldDetail;
        JERPData.Product.RepairInvoiceField accField;
        private void SetDataSrc()
        {
            DataTable dtlbField = this.accField.GetDataRepairInvoiceField().Tables[0];
            JCommon.Others.SetColumnBindSrc(this.ColumnFieldID, dtlbField, "FieldID", "FieldCaption");
        }
        private DataTable dtblFieldDetail;
        private int  FormatID = -1;
        private long fieldTitleID = -1;
        private long FieldTitelID
        {
            get
            {
                return fieldTitleID;
            }
            set
            {
                this.fieldTitleID = value;
            }
        }
        public void NewFieldTitle(int  FormatID)
        {
            this.FieldTitelID = -1;
            this.txtFieldTitle.Text = string.Empty;
            this.ckbSerialNoFlag.Checked = false;
            this.ckbGroupFlag .Checked = false;
            this.ckbSumFlag .Checked = false;
         
            this.txtColumnName.Text = string.Empty;
            this.FormatID = FormatID;
            this.LoadDetail();
        }
        public void EditFieldTitle(long FieldTitelID)
        {
            this.FieldTitelID = FieldTitelID;
            DataTable dtbl = this.accFieldTitle.GetDataRepairInvoiceFieldTitleByFieldTitleID(FieldTitelID).Tables[0];
            if (dtbl.Rows.Count > 0)
            {
                this.FormatID = (int)dtbl.Rows[0]["FormatID"];
                this.txtFieldTitle.Text = dtbl.Rows[0]["FieldTitle"].ToString();
                this.txtColumnName.Text = dtbl.Rows[0]["ColumnName"].ToString();
                this.ckbSerialNoFlag.Checked = (bool)dtbl.Rows[0]["SerialNoFlag"];
                this.ckbGroupFlag.Checked = (bool)dtbl.Rows[0]["GroupFlag"];
                this.ckbSumFlag.Checked = (bool)dtbl.Rows[0]["SumFlag"];
            }
            this.LoadDetail(); 
        }
        private void LoadDetail()
        {
            this.dtblFieldDetail = this.accFieldDetail.GetDataRepairInvoiceFieldDetailByFieldTitleID(this.FieldTitelID).Tables[0];
            this.dgrdv.DataSource = this.dtblFieldDetail;
        }
        public delegate void AffterSaveDelegate();
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
        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewFieldTitle(this.FormatID);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            if(this.FieldTitelID ==-1)
            {
                object objFieldTitleID=DBNull .Value ;
                 flag = this.accFieldTitle.InsertRepairInvoiceFieldTitle (ref errormsg,
                ref objFieldTitleID ,this.FormatID ,this.txtFieldTitle.Text,this.txtColumnName .Text ,this.ckbSerialNoFlag .Checked,
                this.ckbGroupFlag .Checked ,this.ckbSumFlag .Checked );
                if(flag)
                {
                    this.FieldTitelID =(long)objFieldTitleID ;
                }
            }
            else
            {
                flag = this.accFieldTitle.UpdateRepairInvoiceFieldTitle(ref errormsg,
                this.FieldTitelID, this.txtFieldTitle.Text, this.txtColumnName.Text, this.ckbSerialNoFlag.Checked,
                this.ckbGroupFlag.Checked, this.ckbSumFlag.Checked);
            }
            if(!flag)
            {
                MessageBox .Show (errormsg );
                return;
            }
            flag = this.accFieldDetail.DeleteRepairInvoiceFieldDetailBatch(ref errormsg, this.FieldTitelID);
            foreach (DataRow drow in this.dtblFieldDetail .Select ("","",DataViewRowState .CurrentRows ))
            {
                flag=this.accFieldDetail .InsertRepairInvoiceFieldDetail (ref errormsg ,this.FieldTitelID,drow["FieldID"]);
            }
            if(this.affterSave !=null)this.affterSave ();
            this.NewFieldTitle(this.FormatID);
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accFieldTitle.DeleteRepairInvoiceFieldTitle (ref errormsg, this.FieldTitelID);
            if (flag)
            {
                MessageBox.Show("成功删除当前记录");
                if (this.affterSave != null) this.affterSave();
                this.NewFieldTitle(this.FormatID);
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

    }
}