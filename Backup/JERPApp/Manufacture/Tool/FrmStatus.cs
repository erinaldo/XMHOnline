using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmStatus : Form
    {
        public FrmStatus()
        {
            InitializeComponent();
         
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Tool.Product ();
            this.accStatus = new JERPData.Tool.Status ();
            this.SetDataSrc();
            this.SetPermit();
        }
        private JERPData.Tool .Product  accPrds;
        private JERPData.Tool .Status accStatus;
        private JERPApp.Define.Tool.FrmStatus frmStatus;
        private DataTable dtblPrds;      
        private bool enableBrowse = false;
        private bool enableSave = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(409);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(410);
            if (this.enableBrowse)
            {
                this.ctrlQFind .SeachGridView = this.dgrdv ;               
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);             
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.btnSave .Enabled  = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave .Click += new EventHandler(btnSave_Click);
              
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "治具状态一览表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv , ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "StatusID")
            {
                if (frmStatus  == null)
                {
                    this.frmStatus = new JERPApp.Define.Tool.FrmStatus();
                    new FrmStyle(this.frmStatus).SetPopFrmStyle(this);
                    this.frmStatus.AffterSave += this.SetDataSrc;
                }
                frmStatus.ShowDialog();
            }
           
        }
        private void SetDataSrc()
        {
            DataTable dtblStatus = this.accStatus.GetDataStatus ().Tables[0];
            this.ColumnStatusID.DataSource =dtblStatus ;
            this.ColumnStatusID.ValueMember = "StatusID";
            this.ColumnStatusID.DisplayMember = "StatusName";
        } 
  
        private void LoadData()
        {
            this.dtblPrds  = this.accPrds.GetDataProduct ().Tables[0];      
            this.dgrdv.DataSource = this.dtblPrds;
        }      
        void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult rul = MessageBox.Show("你将对变更进行保存，请确认！", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;        
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblPrds.Select ("","",DataViewRowState.ModifiedCurrent))
            { 
                flag=this.accPrds.UpdateProductForStatus (ref errormsg ,
                    drow["PrdID"],
                    drow["StatusID"],
                    drow["StatusSummary"]);               
                if (flag)
                {
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
            }
            MessageBox.Show("成功保存当前参数设置");
        }

     
    }
}