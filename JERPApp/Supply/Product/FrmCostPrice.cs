using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Product
{
    public partial class FrmCostPrice: Form
    {
        public FrmCostPrice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.Product();
            this.SetPermit();
        }
        private JERPData.Product.Product  accPrds;
        private DataTable dtblPrds;
        private JCommon.FrmExcelImport frmImport;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(389);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(390);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            }       
            this.dgrdv.ReadOnly = !enableSave;
            if (this.enableSave)
            {
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }


        }

     

        private void LoadData()
        {
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = (grow.Cells[this.ColumnCostPrice.Name].Value == DBNull.Value) ? "未设" : string.Empty;
            }
        }
        void btnImport_Click(object sender, EventArgs e)
        {
            if (frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                DataColumn[] columns = new DataColumn[]{    
                    new DataColumn ("产品编号",typeof (string)), 
                    new DataColumn ("产品名称",typeof (string)), 
                    new DataColumn ("产品规格",typeof (string)),  
                    new DataColumn ("机型",typeof (string)),  
                    new DataColumn ("成本价",typeof (decimal)) 
                 };
                frmImport.SetImportColumn(columns, "产品编号不能为空,新导入的成本价将会覆盖之前的单价");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
            }
            frmImport.ShowDialog();
        }
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功";
            DataRow[] drowPrds = this.dtblPrds .Select("PrdCode='" + drow["产品编号"].ToString() + "'");         
            if (drowPrds.Length == 0)
            {
                flag = false;
                msg = "不存此产品编号";
                return;
            }
            else
            {
                drowPrds[0]["CostPrice"] = drow["成本价"];
            }
        }
        void frmImport_AffterSave()
        {
            MessageBox.Show("导入完成，请点击保存");
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在保存变动的记录，因为涉及产成品成本计算，需要一段时间...");
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblPrds.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accPrds.UpdateProductForCostPrice (ref errormsg,
                    drow["PrdID"],
                    drow["CostPrice"]);
                
            }
            this.dtblPrds.AcceptChanges();
            FrmMsg.Hide();
        }
    }
}