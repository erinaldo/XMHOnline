using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Technology
{
    public partial class CtrlDevelopScheduleOperForPsn : UserControl
    {
        public CtrlDevelopScheduleOperForPsn()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dtpDateSchedule.Value = DateTime.Now.Date;
            this.accSchedule = new JERPData.Technology.DevelopSchedules();
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.btnAddDate.Click += new EventHandler(btnAddDate_Click);
            this.PsnEntity = new JERPBiz.Hr.PersonnelEntity();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.ctrlPrdID.AffterSelected += new JERPApp.Define.Product.CtrlPrdForDevelopSchedule.AffterSelectedDelegate(ctrlPrdID_AffterSelected);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }


        private int DataScheduleIndex = 6;//看存贮过程
        private int GridScheduleIndex = 5;
        private JERPData.Technology.DevelopSchedules accSchedule;
        private JERPBiz.Hr.PersonnelEntity PsnEntity;
        private DataTable dtblSchedule;      
        private int PsnID=-1;      
        public void ScheduleOper(int PsnID)
        {
            this.PsnID = PsnID;
            this.PsnEntity .LoadData(PsnID);
            this.dtblSchedule = this.accSchedule.GetDataDevelopSchedulesForPsnSeeting(PsnID).Tables[0];
            while (this.dgrdv.Columns.Count > GridScheduleIndex)
            {
                this.dgrdv.Columns.RemoveAt(GridScheduleIndex);
            }
            DataGridViewCheckBoxColumn  ckbcol;
            string columnname = string.Empty;
            for (int j = DataScheduleIndex; j < this.dtblSchedule.Columns.Count; j++)
            {
                columnname = this.dtblSchedule.Columns[j].ColumnName;              
                ckbcol = new DataGridViewCheckBoxColumn();
                ckbcol.DataPropertyName = columnname;
                ckbcol.Width = 66;
                ckbcol.HeaderText = columnname.Remove(0, 5);
                if (DateTime.Parse(columnname).DayOfWeek == 0)
                {
                    ckbcol.Width = 70;
                    ckbcol.HeaderText = ckbcol.HeaderText + "日";
                }
                
                this.dgrdv.Columns.Add(ckbcol);
            }
            this.dgrdv.DataSource = this.dtblSchedule;
        }



        void ctrlPrdID_AffterSelected()
        {
            this.ctrlDevelopProcessID.LoadData(this.ctrlPrdID.PrdID);
        }
  
        void btnAddItem_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblSchedule.Select("DevelopProcessID=" + this.ctrlDevelopProcessID.DevelopProcessID.ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("已存在当前项");
                return;
            }
            DataRow drowNew = this.dtblSchedule.NewRow();
            drowNew["PrdCode"] = this.ctrlPrdID.PrdEntity.PrdCode;
            drowNew["PrdName"] = this.ctrlPrdID.PrdEntity.PrdName;
            drowNew["PrdSpec"] = this.ctrlPrdID.PrdEntity.PrdSpec;
            drowNew["DevelopProcessID"] = this.ctrlDevelopProcessID.DevelopProcessID ;
            drowNew["PrdStatus"] = this.ctrlDevelopProcessID.PrdStatus;
            drowNew["DateTarget"] = this.ctrlDevelopProcessID.DateTarget;
            this.dtblSchedule.Rows.Add(drowNew);
        }
        void btnAddDate_Click(object sender, EventArgs e)
        {
            string columnname = string.Empty;
            string str_date = this.dtpDateSchedule.Value.ToShortDateString();
            for (int j = this.DataScheduleIndex; j < this.dtblSchedule.Columns.Count; j++)
            {
                columnname = this.dtblSchedule.Columns[j].ColumnName;
                if (DateTime.Parse(columnname).Date == this.dtpDateSchedule.Value.Date)
                {
                    MessageBox.Show("此日期已加入");
                    return;
                }
            }
            columnname = this.dtpDateSchedule.Value.ToShortDateString();
            this.dtblSchedule.Columns.Add(columnname, typeof(bool));
            DataGridViewCheckBoxColumn ckbcol = new DataGridViewCheckBoxColumn();
            ckbcol.DataPropertyName = columnname;
            ckbcol.Width = 66;
            ckbcol.HeaderText = columnname.Remove(0, 5);
            if (DateTime.Parse(columnname).DayOfWeek == 0)
            {
                ckbcol.Width = 70;
                ckbcol.HeaderText = ckbcol.HeaderText + "日";
            }
            this.dgrdv.Columns.Add(ckbcol);
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row .Index;
            DataRow drow = this.dtblSchedule.DefaultView[irow].Row;
            if (drow != null)
            {
                string errormsg=string.Empty ;
                this.accSchedule.DeleteDevelopSchedules (ref errormsg,
                    drow["DevelopProcessID"],
                    this.PsnID );
            }
        }
        public void Save()
        {
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblSchedule.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;          
                for (int j = this.DataScheduleIndex; j < this.dtblSchedule.Columns.Count; j++)
                {
                    if (drow[j] == DBNull.Value) continue;
                    this.accSchedule.SaveDevelopSchedules(ref errormsg,
                        drow["DevelopProcessID"],
                        this.PsnID ,
                        this.dtblSchedule.Columns[j].ColumnName,
                        drow[j]);
                }
                drow.AcceptChanges();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "("+this.PsnEntity.PsnName  +")开发排期");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            for (int i = 4; i <=rowIndex; i++)
            {
              
                //列
                for (int j = this.GridScheduleIndex + 2; j <=colIndex; j++)
                {
                    if (excel.GetCellVal(i, j).ToString() == "是")
                    {                        
                        excel.SetCellColor(Color.White, Color.Red, i, j);                      
                    }
                    excel.SetCellVal(i, j, null);
                }
            }
            FrmMsg.Hide();
            excel.Show();
        }


    }
}
