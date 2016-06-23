using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Report.Bill
{
    public partial class CtrlWorkingSheet : UserControl 
    {
        public CtrlWorkingSheet()
        {
            InitializeComponent();
            this.dgrdvSchedule.AutoGenerateColumns = false;
            this.dgrdvOutSrc.AutoGenerateColumns = false;
            this.WorkingSheetEntity = new JERPBiz.Manufacture.WorkingSheetEntity();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.accOutSrcOrderItems = new JERPData.Manufacture.OutSrcOrderItems(); 
            this.dgrdvSchedule.CellContentClick += new DataGridViewCellEventHandler(dgrdvSchedule_CellContentClick); 
        }

        private JERPBiz.Manufacture.WorkingSheetEntity WorkingSheetEntity;
        private JERPData.Manufacture.ManufSchedules accManufSchedules; 
        private JERPData.Manufacture.OutSrcOrderItems accOutSrcOrderItems;
        private FrmBOM frmBOM; 
        private FrmManufScheduleWIP frmWIP;
        private DataTable dtblSchedule,dtblOutSrcItems;
        private long WorkingSheetID = -1; 
        public void WorkingSheet(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode; 
            this.txtDateTarget .Text = string.Format("{0:MM-dd H:m}", this.WorkingSheetEntity .DateTarget); 
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WorkingSheetEntity.Quantity); 
            this.txtMakerPsn.Text = this.WorkingSheetEntity.MakerPsn;
            //Ã÷Ï¸
            this.dtblSchedule = this.accManufSchedules.GetDataManufSchedulesByWorkingSheetID(this.WorkingSheetID).Tables[0];
            this.dgrdvSchedule.DataSource = this.dtblSchedule;

            this.dtblOutSrcItems = this.accOutSrcOrderItems.GetDataOutSrcOrderItemsByWorkingSheetID(this.WorkingSheetID).Tables[0];
            this.dgrdvOutSrc.DataSource = this.dtblOutSrcItems;
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
                    new FrmStyle(frmBOM).SetPopFrmStyle(this.ParentForm );                    
                }
                this.frmBOM.BOMDetail(ManufScheduleID);
                this.frmBOM.ShowDialog();
            }
            if (this.dgrdvSchedule.Columns[icol].Name == this.ColumnFinishedQty.Name)
            {               
                if (this.frmWIP  == null)
                {
                    this.frmWIP = new FrmManufScheduleWIP();
                    new FrmStyle(frmWIP).SetPopFrmStyle(this.ParentForm);
                }
                this.frmWIP.ScheduleWIP(ManufScheduleID);
                this.frmWIP.ShowDialog();
            }
        }
     

    
    }
}