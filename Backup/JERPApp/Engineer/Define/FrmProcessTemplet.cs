using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmProcessTemplet : Form
    {
      
        public FrmProcessTemplet()
        {
            InitializeComponent();
            this.accProcessTemplet = new JERPData.Manufacture .ProcessTemplet();
            this.accTempletItems = new JERPData.Manufacture.ProcessTempletItems();
            this.accProcessType = new JERPData.Manufacture.ProcessType(); 
            this.accSupplier = new JERPData.General.Supplier();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private DataTable dtblItems, dtblProcessType, dtblOutSrcCompany;
        private JERPData.Manufacture.ProcessTempletItems accTempletItems;
        private JERPData.Manufacture.ProcessTemplet accProcessTemplet;
        private JERPData.Manufacture.ProcessType accProcessType; 
        private JERPData.General.Supplier accSupplier;
        private JERPApp.Define.Manufacture.FrmProcessParmType frmParmType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(418);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(419);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlTempletID.AllowDefine();
                this.ctrlTempletID.AffterSelected += this.LoadData;
               
            }          
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded); 
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }

        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnMemo.Name)
            {
                if (this.dgrdv.CurrentRow.IsNewRow) return;
                object objProcessTypeID = this.dgrdv[this.ColumnProcessTypeID.Name, irow].Value;
                if ((objProcessTypeID == null) || (objProcessTypeID == DBNull.Value)) return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmParmType == null)
                {
                    frmParmType = new JERPApp.Define.Manufacture.FrmProcessParmType();
                    new FrmStyle(frmParmType).SetPopFrmStyle(this.ParentForm);
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
        private void SetColumnSrc()
        {
            this.dtblProcessType = this.accProcessType.GetDataProcessType().Tables[0];
         
            this.ColumnProcessTypeID.DataSource = this.dtblProcessType;
            this.ColumnProcessTypeID.ValueMember = "ProcessTypeID";
            this.ColumnProcessTypeID.DisplayMember = "ProcessTypeName";

           
            DataRow drowNew ;
           

            this.dtblOutSrcCompany = this.accSupplier.GetDataSupplierForOutSrc().Tables[0];
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

      
        void ctrlTempletID_AffterSelected()
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblItems = this.accTempletItems.GetDataProcessTempletItemsByTempletID(this.ctrlTempletID.TempletID).Tables[0];
            this.dtblItems.Columns["OutSrcFlag"].DefaultValue = false;  
            this.dgrdv.DataSource = this.dtblItems;
            
          
        }
        private bool ValidateData()
        {
            if (this.ctrlTempletID.TempletID == -1)
            {
                MessageBox.Show("对不起，未选择任何模板");
                return false;
            }
            return true;
        }    
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag=false ;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    object objItemID = DBNull.Value;
                    flag = this.accTempletItems.InsertProcessTempletItems(
                        ref errormsg,
                        ref objItemID,
                        this.ctrlTempletID.TempletID,
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"], 
                        drow["OutSrcFlag"],
                        drow["OutSrcCompanyID"] 
                       );
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                    flag = this.accTempletItems.UpdateProcessTempletItems(ref errormsg,
                        drow["ItemID"],
                        drow["SerialNo"],
                        drow["ProcessTypeID"],
                        drow["Memo"], 
                        drow["OutSrcFlag"],
                        drow["OutSrcCompanyID"]);
                }
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }

            MessageBox.Show("成功进行当前保存");
        }

  
    
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            if (irow == this.dgrdv.RowCount - 1) return;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {
                return;
            }          
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No )
            {
                e.Cancel = true;
                return;

            }           
            flag = this.accProcessTemplet.DeleteProcessTemplet(ref ErrorMsg,
                drow["ItemID"]);
            if (!flag)
            {
               MessageBox .Show (ErrorMsg);
               e.Cancel = true;
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
    }
}