using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class FrmWorkingSheet : Form
    {
        public FrmWorkingSheet()
        {
            InitializeComponent();
            this.dgrdvSchedule.AutoGenerateColumns = false;
            this.dgrdvOutSrc.AutoGenerateColumns = false;
            this.WorkingSheetEntity = new JERPBiz.Manufacture.WorkingSheetEntity();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accOutSrcOrderItems = new JERPData.Manufacture.OutSrcOrderItems(); 
            this.PrintHelper = new JERPBiz.Manufacture.WorkingSheetPrintHelper(); 
            this.dgrdvSchedule.CellContentClick += new DataGridViewCellEventHandler(dgrdvSchedule_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

      
        private JERPBiz.Manufacture.WorkingSheetEntity WorkingSheetEntity;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private JERPBiz.Manufacture.WorkingSheetPrintHelper PrintHelper;
        private JERPData.Manufacture.OutSrcOrderItems accOutSrcOrderItems;
        private FrmBOM frmBOM; 
        private FrmManufScheduleWIP frmWIP;
        private DataTable dtblSchedule, dtblOutSrcItems; 
       
        private long WorkingSheetID = -1;
        private void LoadScheduleData()
        {
          
            this.dtblSchedule = this.accManufSchedules.GetDataManufSchedulesByWorkingSheetID (this.WorkingSheetID).Tables[0]; 
            this.dgrdvSchedule.DataSource = this.dtblSchedule;
        }
        private void LoadOutSrcItem()
        {
            this.dtblOutSrcItems = this.accOutSrcOrderItems.GetDataOutSrcOrderItemsByWorkingSheetID(this.WorkingSheetID).Tables[0];
            this.dgrdvOutSrc.DataSource = this.dtblOutSrcItems;
        }
        public void WorkingSheet(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode;
            this.txtCompanyCode.Text = this.WorkingSheetEntity.CompanyCode ;
            this.txtPONo.Text = this.WorkingSheetEntity.PONo;
            this.txtPrdCode.Text = this.WorkingSheetEntity.PrdCode;
            this.txtPrdName.Text = this.WorkingSheetEntity.PrdName;
            this.txtPrdSpec.Text = this.WorkingSheetEntity.PrdSpec;
            this.txtModel.Text = this.WorkingSheetEntity.Model; 
            this.txtDateTarget .Text = string.Format("{0:MM-dd H:m}", this.WorkingSheetEntity .DateTarget);
            this.txtMemo.Text = this.WorkingSheetEntity.Memo;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.Quantity);
            this.LoadScheduleData();
            this.LoadOutSrcItem();
        }
 

 
        void dgrdvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long ManufScheduleID = (long)this.dtblSchedule.DefaultView[irow]["ManufScheduleID"];
            if (this.dgrdvSchedule.Columns[icol].Name == this.ColumnlnkBOM.Name)
            {
              
                if (this.frmBOM == null)
                {
                    this.frmBOM = new JERPApp.Manufacture.Report.Bill.FrmBOM();
                    new FrmStyle(frmBOM).SetPopFrmStyle(this);                    
                }
                this.frmBOM.BOMDetail(ManufScheduleID);
                this.frmBOM.ShowDialog();
            }
            if (this.dgrdvSchedule.Columns[icol].Name == this.ColumnFinishedQty.Name)
            {               
                if (this.frmWIP  == null)
                {
                    this.frmWIP = new FrmManufScheduleWIP();
                    new FrmStyle(frmWIP).SetPopFrmStyle(this);
                }
                this.frmWIP.ScheduleWIP(ManufScheduleID);
                this.frmWIP.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成生产制令单,请稍候....");
            this.PrintHelper.ExportToExcel(this.WorkingSheetID);
            FrmMsg.Hide();
        }

    
    }
}