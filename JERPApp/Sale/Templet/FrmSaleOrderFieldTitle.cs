using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Templet
{
    public partial class FrmSaleOrderFieldTitle : Form
    {
        public FrmSaleOrderFieldTitle()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accFieldDetail = new JERPData.Product.SaleOrderFieldDetail();
            this.accFieldTitle = new JERPData.Product.SaleOrderFieldTitle();
            this.accField = new JERPData.Product.SaleOrderField();
            this.SetDataSrc();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }

       
        JERPData.Product.SaleOrderFieldTitle accFieldTitle;
        JERPData.Product.SaleOrderFieldDetail accFieldDetail;
        JERPData.Product.SaleOrderField accField;
        private void SetDataSrc()
        {
            DataTable dtlbField = this.accField.GetDataSaleOrderField().Tables[0];
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
                this.btnDelete.Enabled = (value > -1);
            }
        }
        public void NewFieldTitle(int  FormatID)
        {
            this.FieldTitelID = -1;
            this.txtFieldTitle.Text = string.Empty;
            this.ckbSerialNoFlag.Checked = false;
            this.txtColumnName.Text = string.Empty;
            this.FormatID = FormatID;
            this.LoadDetail();
        }
        public void EditFieldTitle(long FieldTitelID)
        {
            this.FieldTitelID = FieldTitelID;
            DataTable dtbl = this.accFieldTitle.GetDataSaleOrderFieldTitleByFieldTitleID(FieldTitelID).Tables[0];
            if (dtbl.Rows.Count > 0)
            {
                this.FormatID = (int)dtbl.Rows[0]["FormatID"];
                this.txtFieldTitle.Text = dtbl.Rows[0]["FieldTitle"].ToString();
                this.txtColumnName.Text = dtbl.Rows[0]["ColumnName"].ToString();
                this.ckbSerialNoFlag.Checked = (bool)dtbl.Rows[0]["SerialNoFlag"];
            }
            this.LoadDetail(); 
        }
        private void LoadDetail()
        {
            this.dtblFieldDetail = this.accFieldDetail.GetDataSaleOrderFieldDetailByFieldTitleID(this.FieldTitelID).Tables[0];
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
                 flag = this.accFieldTitle.InsertSaleOrderFieldTitle (ref errormsg,
                ref objFieldTitleID ,this.FormatID ,
                this.txtFieldTitle.Text,
                this.txtColumnName .Text ,
                this.ckbSerialNoFlag .Checked );
                if(flag)
                {
                    this.FieldTitelID =(long)objFieldTitleID ;
                }
            }
            else
            {
                flag = this.accFieldTitle.UpdateSaleOrderFieldTitle(ref errormsg,
                this.FieldTitelID, this.txtFieldTitle.Text,this.txtColumnName .Text ,this.ckbSerialNoFlag .Checked );
            }
            if(!flag)
            {
                MessageBox .Show (errormsg );
                return;
            }
            flag = this.accFieldDetail.DeleteSaleOrderFieldDetailBatch(ref errormsg, this.FieldTitelID);
            foreach (DataRow drow in this.dtblFieldDetail .Select ("","",DataViewRowState .CurrentRows ))
            {
                flag=this.accFieldDetail .InsertSaleOrderFieldDetail (ref errormsg ,this.FieldTitelID,drow["FieldID"]);
            }
            if(this.affterSave !=null)this.affterSave ();
            this.NewFieldTitle(this.FormatID);
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accFieldTitle.DeleteSaleOrderFieldTitle(ref errormsg, this.FieldTitelID);
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