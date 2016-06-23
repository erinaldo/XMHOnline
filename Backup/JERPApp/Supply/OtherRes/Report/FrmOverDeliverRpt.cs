using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.OtherRes.Report
{
    public partial class FrmOverDeliverRpt : Form
    {
        public FrmOverDeliverRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accOrderItems = new JERPData.OtherRes.BuyOrderItems();
            this.ctrlGridQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }

        private JERPData.OtherRes.BuyOrderItems accOrderItems;
        private DataTable dtblItems;

        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(501);
            if (this.enableBrowse)
            {
                this.ctrlSupplierID.AppendAll();
                this.ctrlYear.Year = DateTime.Now.Year;
                this.ctrlMonth.Month = DateTime.Now.Month;
                this.LoadData();
                this.ctrlYear.OnSelected += this.LoadData;
                this.ctrlMonth.OnSelected += this.LoadData;
                this.btnExplore.Click += new EventHandler(btnExplore_Click);
                this.ctrlSupplierID.AffterSelected += this.LoadData;
            }
        }

        void ctrlSupplierID_AffterSelected()
        {
           
                this.LoadData();
             
        }
 

        private void LoadData()
        {
            this.dtblItems = this.accOrderItems.GetDataBuyOrderItemsOverDeliver  (this.ctrlYear .Year ,
                this.ctrlMonth .Month ).Tables[0];
            if (this.ctrlSupplierID.CompanyID > -1)
            {
                DataRow[] drows = this.dtblItems.Select("CompanyID<>" + this.ctrlSupplierID.CompanyID.ToString(), "", DataViewRowState.CurrentRows);
                foreach (DataRow drow in drows)
                {
                    this.dtblItems.Rows.Remove(drow);
                }
            }
            this.dgrdv.DataSource = this.dtblItems;
            if (this.dtblItems.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblItems.NewRow();
                drowNew["CompanyAbbName"] = "合计";
                drowNew["Quantity"] = this.dtblItems.Compute("SUM(Quantity)", "");
                drowNew["DeliverQty"] = this.dtblItems.Compute("SUM(DeliverQty)", "");
                drowNew["OverDeliverQty"] = this.dtblItems.Compute("SUM(OverDeliverQty)", "");
                drowNew["OverDeliverRate"] = (decimal)drowNew["OverDeliverQty"] / (decimal)drowNew["Quantity"];
                this.dtblItems.Rows.Add(drowNew);
            }
        }


        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.ctrlYear.Year .ToString ()+"年"+this.ctrlMonth .Month .ToString ()+"月 P/O超送报告");           
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}