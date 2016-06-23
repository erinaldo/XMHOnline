using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmManufPlanFromPrdBackupOrder : Form
    {
        public FrmManufPlanFromPrdBackupOrder()
        {
            InitializeComponent();
            this.dgrdvPacking.AutoGenerateColumns = false;
            this.accBuyPlan = new JERPData.Product.BuyPlans();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans  ();
            this.accPackingPlans = new JERPData.Packing.PackingPlans();
            this.accPackingType = new JERPData.Product.PackingType();
            this.dtpDateTarget.Value = DateTime.Now.AddDays(15);
            this.dgrdvPacking.DataError +=new DataGridViewDataErrorEventHandler(dgrdvPacking_DataError);
            this.ctrlCompanyID.AppendAll();
            this.ctrlPrdID.AffterSelected += new JERPApp.Define.Product.CtrlFinishedPrd.AffterSelectedDelegate(ctrlPrdID_AffterSelected);
            this.btnSave.Click += new EventHandler(btnSave_Click);

            this.dtblPackingPlans = new DataTable();
            this.dtblPackingPlans.Columns.Add("PackingTypeID", typeof(int));
            this.dtblPackingPlans.Columns.Add("Quantity", typeof(decimal));
            this.dtblPackingPlans.Columns.Add("DateTarget", typeof(DateTime));
            this.dtblPackingPlans.Columns.Add("Memo", typeof(string));
            this.dtblPackingPlans.Columns["Quantity"].AllowDBNull = false;
            this.dtblPackingPlans.Columns["PackingTypeID"].AllowDBNull = false;
            this.dtblPackingPlans.Columns["Quantity"].AllowDBNull = false;
            this.dgrdvPacking.DataSource = this.dtblPackingPlans;

            this.ColumnPackingTypeID.ValueMember = "PackingTypeID";
            this.ColumnPackingTypeID.DisplayMember = "PackingTypeName";
        }

      
     
        private JERPData.Product.BuyPlans accBuyPlan;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private JERPData.Packing.PackingPlans accPackingPlans;
        private JERPData.Product.PackingType accPackingType;
        private DataTable dtblPackingPlans,dtblPackingType;
       
        private void LoadPackingPlan()
        {
            if (this.dtblPackingPlans != null) this.dtblPackingPlans.Clear();
            this.dtblPackingType = this.accPackingType.GetDataPackingTypeByPrdID(this.ctrlPrdID.PrdID).Tables[0];
            this.ColumnPackingTypeID.DataSource = this.dtblPackingType;
           
        }
        public void BackupOper()
        {

            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Enabled = true;
            this.txtQuantity.Text = "0";
            this.rchMemo.Text = string.Empty;
            this.radPrdStore.Checked = true; 
            this.LoadPackingPlan();
        }
        public void BackupOper(int PrdID,decimal RequireQty)
        {
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlPrdID.PrdID = PrdID;
            this.ctrlPrdID.Enabled = false;

            this.txtQuantity.Text = string.Format("{0:0.####}", RequireQty);
            this.lblUnitName.Text = this.ctrlPrdID.PrdEntity.UnitName;
            this.rchMemo.Text = string.Empty;
            this.radPrdStore.Checked = this.ctrlPrdID.PrdEntity.SaleFlag  ;
            this.radMtrStore.Checked = !this.ctrlPrdID.PrdEntity.SaleFlag;  
            this.LoadPackingPlan();
        } 
        void ctrlPrdID_AffterSelected()
        {
            
            this.lblUnitName.Text = this.ctrlPrdID.PrdEntity.UnitName;
            this.radPrdStore.Checked =true;
            this.radMtrStore.Checked = !this.radPrdStore.Checked;
            this.LoadPackingPlan();
        }


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
        bool ValidateData()
        {
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("未选择任何产品");
                return false;
            }
            decimal d;
            if (!decimal.TryParse(this.txtQuantity .Text, out d))
            {
                MessageBox.Show("数量格式出错!");
                return false;
            }

            return true;
        }
        void dgrdvPacking_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.dgrdvPacking[e.ColumnIndex, e.RowIndex].Value = DBNull.Value;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty; 
            //先整订单处理
            DialogResult rul = MessageBox.Show("您将进行备库下单，一经下达不能变更和取消，请确认！", "下单确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            decimal Quantity = decimal.Parse(this.txtQuantity.Text); 
            if (Quantity > 0)
            {             
                if (this.radManufFlag.Checked)
                {
                    this.accManufPlans.InsertManufPlans (ref errormsg, 
                        DateTime .Now.Date ,
                        DBNull .Value ,
                        this.ctrlCompanyID .CompanyID ,
                       this.ctrlPrdID .PrdID ,
                       Quantity,
                       this.radPrdStore .Checked ,
                       this.radMtrStore .Checked ,
                       this.dtpDateTarget .Value ,
                       this.rchMemo .Text ,
                       true ,
                       JERPBiz.Frame .UserBiz .PsnID 
                       );

                }
                if (this.radBuyFlag.Checked)
                {
                    this.accBuyPlan.SaveBuyPlans (ref errormsg,
                        this.ctrlPrdID.PrdID,
                        Quantity );
                }
            }
            object objPackingTypeID = DBNull.Value;
            foreach (DataRow drow in this.dtblPackingPlans.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.accPackingPlans.InsertPackingPlans (
                    ref errormsg ,
                    ref objPackingTypeID ,
                   DateTime.Now.Date,
                   DBNull.Value ,
                       this.ctrlCompanyID.CompanyID,
                       this.ctrlPrdID.PrdID,
                       drow["PackingTypeID"], 
                       drow["Quantity"],
                       drow["DateTarget"],
                       drow["Memo"],
                       JERPBiz.Frame.UserBiz.PsnID
                       );

            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功进行当前备库下单！");
            this.Close();
        }

    }
}