using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutStoreNoteOper : Form
    {
        public FrmOutStoreNoteOper()
        {
            InitializeComponent();    
            this.accManufBOM = new JERPData.Manufacture.BOM();
            this.accPackingBOM = new JERPData.Packing.BOM();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accWorkingSheets = new JERPData.Packing.WorkingSheets();
            this.btnSave.Click += new EventHandler(btnSave_Click);
         
        } 
      
        private JERPData.Manufacture.BOM accManufBOM;
        private JERPData.Packing .BOM accPackingBOM; 
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPData.Packing.WorkingSheets accWorkingSheets;
        private DataRow[] drowManufSchedules,drowWorkingSheets;
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
       
        public void NewNote(DataRow[] drowManufSchedules,DataRow[] drowWorkingSheets)
        {
            this.drowManufSchedules = drowManufSchedules;
            this.drowWorkingSheets = drowWorkingSheets;
            this.ctrlOutStoreOper.NoteOper();
            this.ctrlOutOEMStoreItemOper.NoteOper();
            foreach (DataRow drowManufSchedule in drowManufSchedules)
            {
                this.ComputeBOM(drowManufSchedule);
            }
            foreach (DataRow drowWorkingSheet in drowWorkingSheets)
            {
                this.ComputePackingBOM (drowWorkingSheet);
            }
            this.pageStore.Text = "采购库[" + this.ctrlOutStoreOper.RowCount.ToString() + "]";
            this.pageOEMStore.Text = "客供库[" + this.ctrlOutOEMStoreItemOper.RowCount.ToString() + "]";
        } 
       
        private void ComputeBOM(DataRow drowManufSchdule)
        {

            long ManufScheduleID = (long)drowManufSchdule["ManufScheduleID"];
            long WorkingSheetID = (long)drowManufSchdule["WorkingSheetID"]; 
            decimal ManufQty = (decimal)drowManufSchdule["ManufQty"];
            int CustomerID = (int)drowManufSchdule["CompanyID"];
            string Customer = drowManufSchdule["Customer"].ToString();
            //等一阵改
           DataTable dtblBom = this.accManufBOM.GetDataBOMForOutStore(ManufScheduleID).Tables[0];
           if (dtblBom.Columns.IndexOf("RequireQty") == -1)
           {
               dtblBom.Columns.Add("RequireQty", typeof(decimal));
           } 
            dtblBom.Columns.Add("CustomerID", typeof(int ));
            dtblBom.Columns.Add("Customer", typeof(string)); 
            int PrdID = -1;
            int SourceTypeID = -1;
            decimal LossRate = 0;
            decimal AssemblyQty = 0;
            foreach(DataRow drowBom in dtblBom .Rows )
            {
                SourceTypeID = (int)drowBom["SourceTypeID"];
                PrdID = (int)drowBom["PrdID"];
                LossRate = 0;
                AssemblyQty = 1;
                if (drowBom["LossRate"] != DBNull.Value)
                {
                    LossRate = (decimal)drowBom["LossRate"];
                }
                if (drowBom["AssemblyQty"]!=DBNull .Value)
                {
                    AssemblyQty = (decimal)drowBom["AssemblyQty"];
                }
                drowBom["RequireQty"] = Convert.ToInt32(ManufQty * AssemblyQty * (1 + LossRate));
                if ((SourceTypeID <3) || (CustomerID == -1))
                {
                    this.ctrlOutStoreOper.AppendItem(drowBom);
                }
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    drowBom["CustomerID"] = CustomerID;
                    drowBom["Customer"] = Customer;
                    this.ctrlOutOEMStoreItemOper.AppendItem(drowBom);
                }
            }
         
            
        }
        private void ComputePackingBOM(DataRow drowWorkingSheet)
        { 
            long WorkingSheetID = (long)drowWorkingSheet["WorkingSheetID"];
            decimal PackingQty = (decimal)drowWorkingSheet["PackingQty"];
            int CustomerID = (int)drowWorkingSheet["CompanyID"];
            string Customer = drowWorkingSheet["Customer"].ToString();
            //等一阵改
            DataTable dtblBom = this.accPackingBOM.GetDataBOMForOutStore (WorkingSheetID).Tables[0];
            if (dtblBom.Columns.IndexOf("RequireQty") == -1)
            {
                dtblBom.Columns.Add("RequireQty", typeof(decimal));
            }
            dtblBom.Columns.Add("CustomerID", typeof(int));
            dtblBom.Columns.Add("Customer", typeof(string));
            int PrdID = -1;
            int SourceTypeID = -1; 
            int PrdAssembly = 0,PackageAssembly=0;
            foreach (DataRow drowBom in dtblBom.Rows)
            {
                SourceTypeID = (int)drowBom["SourceTypeID"];
                PrdID = (int)drowBom["PrdID"]; 
                PrdAssembly = (int)drowBom["PrdAssembly"];
                PackageAssembly = (int)drowBom["PackageAssembly"]; 
                drowBom["RequireQty"] = Convert.ToInt32(PackingQty * PackageAssembly / PrdAssembly);
                if ((SourceTypeID < 3) || (CustomerID == -1))
                {
                    this.ctrlOutStoreOper.AppendItem(drowBom);
                }
                if ((SourceTypeID == 3) && (CustomerID > -1))
                {
                    drowBom["CustomerID"] = CustomerID;
                    drowBom["Customer"] = Customer;
                    this.ctrlOutOEMStoreItemOper.AppendItem(drowBom);
                }
            }


        }
        private bool ValidateData()
        {
            if (this.drowManufSchedules .Length +this.drowWorkingSheets .Length ==0)
            {
                MessageBox.Show("没有任何出货项");
                return false;
            }
            string errormsg = string.Empty;
            if (!this.ctrlOutStoreOper.ValidateData(out errormsg))
            {
                MessageBox.Show(errormsg );
                return false;
            }
            if (!this.ctrlOutOEMStoreItemOper.ValidateData(out errormsg))
            {
                MessageBox.Show(errormsg);
                return false;
            }
            return true;
        }
       
 
      
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            foreach (DataRow drow in this.drowManufSchedules)
            {
                //弄完成
                this.accManufSchedules.UpdateManufSchedulesAppBOMFinishedQty(ref errormsg,
                    drow["ManufScheduleID"],
                    drow["ManufQty"]);
             
            }
            foreach (DataRow drow in this.drowWorkingSheets)
            {
                this.accWorkingSheets.UpdateWorkingSheetsForAppendBOMFinishedQty (ref errormsg,
                    drow["WorkingSheetID"],
                    drow["PackingQty"]);
            }
            this.ctrlOutStoreOper.Save();
            this.ctrlOutOEMStoreItemOper.Save();  
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.Close();

        }
  
     

    }
}