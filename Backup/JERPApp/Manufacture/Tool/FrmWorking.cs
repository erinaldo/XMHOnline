using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmWorking : Form
    {
        public FrmWorking()
        {
            InitializeComponent();
         
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Tool.Product ();
          
            this.SetPermit();
        }
        private JERPData.Tool.Product  accPrds;
        private DataTable dtblPrds,dtblWorking;
        private JERPApp.Define.Tool.FrmProduct frmPrd;
        private bool enableBrowse = false;
        private bool enableSave = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(412);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(413);
            if (this.enableBrowse)
            {
                this.SetDataSrc();
                this.LoadData();      
                
            }
            this.btnSave .Enabled  = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave .Click += new EventHandler(btnSave_Click);
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            }
        }

       
        private void SetDataSrc()
        {
            this.dtblPrds = this.accPrds.GetDataProduct ().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

        }
  
        private void LoadData()
        {
            this.dtblWorking =  new DataTable ();
            this.dtblWorking.Columns.Add("PrdID", typeof(int));
            this.dtblWorking.Columns.Add("Quantity", typeof(decimal));
            this.dtblWorking.Columns["Quantity"].AllowDBNull = false;
            this.dtblWorking.Columns["PrdID"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblWorking;
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Tool.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Tool.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            this.dgrdv.CurrentCell.Value = drow["PrdID"];
            this.frmPrd.Close();
        }

      
     
    
      
        void btnSave_Click(object sender, EventArgs e)
        {            
            DialogResult rul = MessageBox.Show("请确认你的治具生产量，一经保存不能变更！", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;        
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblWorking .Rows )
            {
                this.accPrds.UpdateProductForAppendManufQty(ref errormsg,
                    drow["PrdID"],
                    drow["Quantity"]);               
                if (flag)
                {
                    drow.AcceptChanges();
                }                
            }
            MessageBox.Show("成功保存当前产量设置");
            this.LoadData();
        }

     
    }
}