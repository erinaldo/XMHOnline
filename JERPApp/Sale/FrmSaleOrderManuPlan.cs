using JERPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleOrderManuPlan : Form
    {
        public FrmSaleOrderManuPlan()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdvPocess.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            this.printer = new JERPBiz.Product.SaleOrderNotePrintHelper();
            this.accItems = new JERPData.Product.SaleOrderItems();
            this.accManuProcessNew = new JERPData.Product.ManuProcessNew();
            this.SetPermit();
        }

        private JERPData.Product.SaleOrderNotes accNotes;
        private JERPData.Product.SaleOrderItems accItems;
        private JERPData.Product.ManuProcessNew accManuProcessNew;
        //private JERPApp.Define.Product.FrmMySaleOrderNoteFreeSearch frmSearch;
        //private FrmSaleOrderNoteOper frmOper;
        private JERPBiz.Product.SaleOrderNotePrintHelper printer;
        private string whereclause = string.Empty;
        private string initwhareclause = string.Empty;
        private DataTable dtblNoteItems;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private int lastRow = 0;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(104);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(105);
            if (this.enableBrowse)
            {
                //this.initwhareclause = " and ((MakerPsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString()
                //    + ") or (CompanyID in(select CompanyID from general.Customer where HandlePsnID="
                //    + JERPBiz.Frame.UserBiz.PsnID.ToString() + ")))";


                this.whereclause = this.initwhareclause;
                this.AppendWhereclause();
                //加载数据
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdvPocess.ContextMenuStrip = this.cMenuProcess;
                this.mProcessRefresh.Click += new EventHandler(mProcessRefresh_Click);

                this.up.Click += new EventHandler(mProcessUp_Click);
                this.down.Click += new EventHandler(mProcessDown_Click);

            }
            if (this.enableSave)
            {
                //this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellClick += new DataGridViewCellEventHandler(dgrdv_CellClick);
            }
        }

        private void mProcessDown_Click(object sender, EventArgs e)
        {
            upOrdownOrDelete("down",this.dgrdvPocess);
        }

        private void mProcessUp_Click(object sender, EventArgs e)
        {
            upOrdownOrDelete("up", this.dgrdvPocess);
        }

        private void mProcessRefresh_Click(object sender, EventArgs e)
        {
            int irow = this.dgrdv.SelectedRows[0].Index;
            LoadProcess(this.dtblNoteItems.DefaultView[irow]); ;
        }

        private void dgrdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            if (lastRow == irow)
            {
                return;
            }
            lastRow = irow;
            clearData();//先清空数据
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            LoadProcess(this.dtblNoteItems.DefaultView[irow]);
        }

        void clearData(){
            //清空数据
            DataTable dt = (DataTable)dgrdvPocess.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                dgrdvPocess.DataSource = dt;
            }
        }

        private void LoadProcess(DataRowView dataRowView)
        {
            int OrderItemID = Convert.ToInt32(dataRowView.Row["itemID"]);
            int PrdID = Convert.ToInt32(dataRowView.Row["PrdID"]);
            //根据物料查找相关工序
            int Quantity = Convert.ToInt32(dataRowView.Row["Quantity"]);

            DataTable dt = this.accManuProcessNew.GetDataManuProcessNewByPrdID(PrdID).Tables[0];
            dgrdvPocess.DataSource =dt;

            //DataTable dtNew = new DataTable();
            
            DataColumn dtcol = new DataColumn();
            dtcol.ColumnName="Count";
            dtcol.DataType = typeof(double);
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "SumTimeCost";
            dtcol.DataType = typeof(double);
            dt.Columns.Add(dtcol);
            double TotalSumTime = 0;
            double SumTime = 0;
            foreach (DataRow drow in dt.Rows)
            {
                drow["Count"] = Quantity;
                drow["SumTimeCost"] = Quantity * Convert.ToDouble(drow["TimeCost"]);

                SumTime = Quantity * Convert.ToDouble(drow["TimeCost"]);
                TotalSumTime += SumTime;
            }
            DataRow dr;
            dr = dt.NewRow();
            dr["ProcessName"] = "总计";
            dr["SumTimeCost"] = TotalSumTime;
            dt.Rows.Add(dr);
        }



        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.whereclause = this.initwhareclause;
            this.AppendWhereclause();
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtblNoteItems = getOrderItemNONFininsh().Tables[0]; ;
            this.dgrdv.DataSource = this.dtblNoteItems;
        }

        private void AppendWhereclause(){
              this.whereclause += " ";
        }





        private void upOrdownOrDelete(string type, JCommon.MyDataGridView dGVshowProcess)
        {

            if (dGVshowProcess.CurrentRow == null)
            {

                MessageBox.Show("请选择要需要操作的工序所在行");

            }

            else if (type == "del")//删
            {

                if (MessageBox.Show("确定要删除吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    dGVshowProcess.Rows.Remove(dGVshowProcess.CurrentRow);

                }

            }

            else if (type == "up")//上
            {

                if (dGVshowProcess.CurrentRow.Index <= 0)
                {

                    MessageBox.Show("此工序已在顶端，不能再上移！");

                }

                else
                {

                    int nowIndex = dGVshowProcess.CurrentRow.Index;

                    object[] _rowData = (dGVshowProcess.DataSource as DataTable).Rows[nowIndex].ItemArray;

                    (dGVshowProcess.DataSource as DataTable).Rows[nowIndex].ItemArray = (dGVshowProcess.DataSource as DataTable).Rows[nowIndex - 1].ItemArray;

                    (dGVshowProcess.DataSource as DataTable).Rows[nowIndex - 1].ItemArray = _rowData;

                    //dGVshowProcess.CurrentCell = dGVshowProcess.Rows[nowIndex - 1].Cells[0];//设定当前行

                }

            }

            else if (type == "down")//下
            {

                if (dGVshowProcess.CurrentRow.Index >= dGVshowProcess.Rows.Count - 1)
                {

                    MessageBox.Show("此工序已在底端，不能再下移！");

                }

                else
                {

                    int nowIndex = dGVshowProcess.CurrentRow.Index;

                    object[] _rowData = (dGVshowProcess.DataSource as DataTable).Rows[nowIndex].ItemArray;

                    (dGVshowProcess.DataSource as DataTable).Rows[nowIndex].ItemArray = (dGVshowProcess.DataSource as DataTable).Rows[nowIndex + 1].ItemArray;

                    (dGVshowProcess.DataSource as DataTable).Rows[nowIndex + 1].ItemArray = _rowData;

                    //dGVshowProcess.CurrentCell = dGVshowProcess.Rows[nowIndex + 1].Cells[0];//设定当前行

                }

            }
        }

       //SQL脚本
        private DataSet getOrderItemNONFininsh() {
            DataSet ds = new DataSet();
            String sql = "  select t1.NoteID,t1.SerialNo,t1.NoteCode,t1.PONo,t1.DateNote,t1.CompanyID, "
            + " t2.ItemID,t2.ItemNo,t2.BatchNo,t2.PrdID,t2.Quantity,t2.Price,t2.ItemAMT,t2.DateTarget,t2.Memo,t2.DeliverPlanQty,t2.NonDeliverPlanQty, "
            + " t2.FinishedQty,t2.NonFinishedQty,t2.HandleQty,t2.NonHandleQty,t3.PrdTypeID,t3.PrdCode,t3.PrdName,t3.PrdSpec,t3.Model "
            + " from prd.SaleOrderNotes t1 "
            + " inner join prd.SaleOrderItems t2 on t1.NoteID = t2.NoteID "
            + "  left join prd.Product t3 on t2.PrdID=t3.PrdID  "
            + " where (1=1) "
            + whereclause;
            ds = CommonTool.GetDateSet(sql); ;
            return ds;
        }
    }
}
