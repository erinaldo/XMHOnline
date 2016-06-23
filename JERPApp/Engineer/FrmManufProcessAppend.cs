using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmManufProcessAppend : Form
    {
        public FrmManufProcessAppend()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.accPrds = new JERPData.Product.Product();
            this.accProcessType = new JERPData.Manufacture.ProcessType();
            this.accTempletItems = new JERPData.Manufacture.ProcessTempletItems(); 
            this.accSupplier = new JERPData.General.Supplier();
            this.SetColumnSrc();  ;
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
        public delegate void AffterSaveDelegate(DataRow drow);
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

            DataRow drowNew; 
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
        public void ManufProcessOper(int PrdID)
        {
            this.PrdID = PrdID;
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(-1).Tables[0];
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
        private string GetProcessTypeName(int ProcessTypeID)
        {
            DataRow[] drows = this.dtblProcessType.Select("ProcessTypeID=" + ProcessTypeID.ToString());
            if(drows .Length >0)
            {
                return drows [0]["ProcessTypeName"].ToString ();
            }
            return string.Empty ;

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string errormsg = string.Empty;
            object objManufProcessID = DBNull.Value;
            foreach (DataRow drow in this.dtblManufProcess.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                flag = this.accManufProcess.InsertManufProcess(ref errormsg,
                    ref objManufProcessID,
                    PrdID,
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
                    drow["ProcessTypeName"] = this.GetProcessTypeName((int)drow["ProcessTypeID"]);
                    if (this.affterSave != null) this.affterSave(drow);
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
                 
            }
            this.accPrds.UpdateProductForManufProcessList(ref errormsg, PrdID);
            this.Close();
           
        }

  
    }
}
