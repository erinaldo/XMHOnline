using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmManufProcessOper : Form
    {
        public FrmManufProcessOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.accPrds = new JERPData.Product.Product();
            this.accProcessType = new JERPData.Manufacture.ProcessType();
            this.accTempletItems = new JERPData.Manufacture.ProcessTempletItems(); 
            this.accSupplier = new JERPData.General.Supplier();
            this.SetColumnSrc();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow); 
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded); 
            this.btnLoad.Click += new EventHandler(btnLoad_Click); 
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

      
        private JERPData.Manufacture.ProcessType accProcessType;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private JERPData.Product.Product accPrds;
        private JERPData.Manufacture.ProcessTempletItems accTempletItems; 
        private JERPData.General.Supplier accSupplier;
        private DataTable dtblManufProcess, dtblProcessType,dtblOutSrcCompany;
        private JERPApp.Define.Manufacture.FrmProcessParmType frmParmType;      
        private int prdid = -1;
        private int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
            }
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
        private void SetColumnSrc()
        {
            this.dtblProcessType = this.accProcessType.GetDataProcessType().Tables[0];         
            this.ColumnProcessTypeID.DataSource = this.dtblProcessType;
            this.ColumnProcessTypeID.ValueMember = "ProcessTypeID";
            this.ColumnProcessTypeID.DisplayMember = "ProcessTypeName";

 

            this.dtblOutSrcCompany = this.accSupplier.GetDataSupplierForOutSrc().Tables[0];
            DataRow drowNew;
            if (this.dtblOutSrcCompany.Rows.Count > 0)
            {
                drowNew = this.dtblOutSrcCompany.NewRow();
                drowNew["CompanyID"] = DBNull.Value;
                drowNew["CompanyAbbName"] = DBNull.Value;
                this.dtblOutSrcCompany.Rows.InsertAt(drowNew, 0);
            }
            this.dtblOutSrcCompany.Columns.Add("Exp", typeof(string), "ISNULL(CompanyCode,'')+' '+ISNULL(CompanyAbbName,'')");
            this.ColumnOutSrcCompanyID.DataSource = this.dtblOutSrcCompany;
            this.ColumnOutSrcCompanyID.ValueMember = "CompanyID";
            this.ColumnOutSrcCompanyID.DisplayMember = "Exp";
        }
        public void ManufProcessOper(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(PrdID).Tables[0];
            this.dtblManufProcess.Columns["OutSrcFlag"].DefaultValue = false;  
            this.dtblManufProcess.Columns["SerialNo"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblManufProcess;

        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
            if (this.dgrdv.Columns[icol].Name == this.ColumnMemo.Name)
            {
                if(this.dgrdv .CurrentRow .IsNewRow )return;
                object  objProcessTypeID=this.dgrdv [this.ColumnProcessTypeID .Name ,irow].Value ;
                if((objProcessTypeID ==null)||(objProcessTypeID ==DBNull .Value ))return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmParmType  == null)
                {
                    frmParmType = new JERPApp.Define.Manufacture.FrmProcessParmType ();
                    new FrmStyle(frmParmType).SetPopFrmStyle(this.ParentForm );
                    frmParmType.AffterConfirm += new JERPApp.Define.Manufacture.FrmProcessParmType.AffterConfirmDelegate(frmParmType_AffterConfirm);
                }
                frmParmType.LoadData((int)objProcessTypeID);
                frmParmType.ShowDialog();
            }
           
            
        }
     
        void frmParmType_AffterConfirm(string ParmValueInfor)
        {
            this.dgrdv.CurrentCell.Value = ParmValueInfor;
        } 
        void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dtblProcessTemplet = this.accTempletItems.GetDataProcessTempletItemsByTempletID(this.ctrlProcessTempletID.TempletID).Tables[0];
            foreach (DataRow drow in dtblProcessTemplet.Rows)
            {
                 
                if (this.dtblManufProcess.Select("SerialNo=" + drow["SerialNo"].ToString() + " and ProcessTypeID=" + drow["ProcessTypeID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0) continue;
              
                this.dtblManufProcess.ImportRow(drow);
            }
        }
        
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblManufProcess .DefaultView[irow].Row;
            if (drow["ManufProcessID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，一经删除将会清除之下物料，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accManufProcess.DeleteManufProcess(ref errormsg, drow["ManufProcessID"]);
            }
            else
            {
                e.Cancel = true;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string errormsg = string.Empty;
            object objManufProcessID = DBNull.Value;
            foreach (DataRow drow in this.dtblManufProcess.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ManufProcessID"] == DBNull.Value)
                {
                    objManufProcessID = DBNull.Value;
                    flag = this.accManufProcess.InsertManufProcess(ref errormsg,
                        ref objManufProcessID,
                        this.PrdID,
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"],
                        drow["MouldCode"], 
                        drow["OutSrcFlag"],
                        drow["OutSrcCompanyID"]
                       );
                    if (flag)
                    {
                        drow["ManufProcessID"] = objManufProcessID; 
                    }
                    else
                    {
                        MessageBox.Show(errormsg);
                    }
                }
                else
                {
                    flag = this.accManufProcess.UpdateManufProcess(
                        ref errormsg,
                        drow["ManufProcessID"],
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"],
                        drow["MouldCode"], 
                        drow["OutSrcFlag"],
                        drow["OutSrcCompanyID"]);
                }
            }
            this.accPrds.UpdateProductForManufProcessList(ref errormsg, this.PrdID);
            if (this.affterSave != null) this.affterSave();
            this.Close();
           
        }

  
    }
}
