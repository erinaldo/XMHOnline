using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class CtrlPurchaseSetting: UserControl 
    {
        public CtrlPurchaseSetting()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();
            this.accPrdXBuyer = new JERPData.Product.ProductXBuyer();
            this.accPrds = new JERPData.Product.Product();
            this.ctrlPrdTypeID.AffterSelected += this.LoadData;
            this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemSupplier.Click += new EventHandler(mItemSupplier_Click);
            this.mItemBuyer.Click += new EventHandler(mItemBuyer_Click);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnSave.Click += new EventHandler(btnSave_Click);
           
        } 
        private JERPData.Product.Product  accPrds; 
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode;
        private JERPData.Product.ProductXBuyer accPrdXBuyer;
        private DataTable dtblPrds;
        private JERPApp.Engineer.FrmSupplierPrdCode frmSupplierPrdCode;
        private JERPApp.Engineer.FrmBuyer  frmBuyer;
        private JERPApp.Engineer .FrmBatchSupplier frmBatchSupplier;
        private JERPApp.Engineer.FrmBatchBuyer frmBatchBuer; 
        private string GetSupplier(int PrdID)
        {
            string supplier = string.Empty;
            this.accPrds.GetParmProductSupplier(PrdID, ref supplier);
            if (supplier == string.Empty) return "未设置";
            return supplier;
        }
        private string GetBuyer(int PrdID)
        {
            string buyer = string.Empty;
            this.accPrds.GetParmProductBuyer(PrdID, ref buyer);
            if (buyer == string.Empty) return "未设置";
            return buyer;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblPrds .DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnSupplier.Name)
            {

                if (frmSupplierPrdCode == null)
                {
                    frmSupplierPrdCode = new JERPApp.Engineer.FrmSupplierPrdCode();
                    new FrmStyle(frmSupplierPrdCode).SetPopFrmStyle(this);
                }
                this.frmSupplierPrdCode.SupplierPrdCode((int)objPrdID);
                this.frmSupplierPrdCode.ShowDialog(); 
                this.dgrdv[icol, irow].Value = this.GetSupplier((int)objPrdID);
            } 
            if (this.dgrdv.Columns[icol].Name == this.ColumnBuyer.Name)
            {

                if (frmBuyer == null)
                {
                    frmBuyer = new JERPApp.Engineer.FrmBuyer();
                    new FrmStyle(frmBuyer).SetPopFrmStyle(this);
                }
                this.frmBuyer.Buyer((int)objPrdID);
                this.frmBuyer.ShowDialog();
                this.dgrdv[icol, irow].Value = this.GetBuyer((int)objPrdID);
            }
            
          
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void mItemSupplier_Click(object sender, EventArgs e)
        {
            if (frmBatchSupplier == null)
            {
                frmBatchSupplier = new JERPApp.Engineer.FrmBatchSupplier();
                new FrmStyle(frmBatchSupplier).SetPopFrmStyle(this);
                frmBatchSupplier.AffterSave += new JERPApp.Engineer.FrmBatchSupplier.AffterSaveDelegate(frmBatchSupplier_AffterSave);
            }
            frmBatchSupplier.BatchSupplier ();
            frmBatchSupplier.ShowDialog();
        }

        void frmBatchSupplier_AffterSave(DataRow[] drowSuppliers, bool SettingFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblPrds .DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowSupplier in drowSuppliers)
                    {
                        if (SettingFlag)
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeForSupplier(ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);

                        }
                        else
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeCancelSupplier(
                                ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);
                        }
                    }
                    drow["Supplier"] = this.GetSupplier((int)drow["PrdID"]);
                }
            }
            this.frmBatchSupplier.Close();
             
        }

        void frmBatchBuer_AffterSave(DataRow[] drowBuyers, bool BuyFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count ; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblPrds .DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowBuyer in drowBuyers)
                    {
                        this.accPrdXBuyer.SaveProductXBuyer(ref errormsg,
                            drow["PrdID"],
                            drowBuyer["PsnID"],
                            BuyFlag);
                    }
                    drow["Buyer"] = this.GetBuyer((int)drow["PrdID"]);
                }
            }
            this.frmBatchBuer.Close(); 
        }
   
        void mItemBuyer_Click(object sender, EventArgs e)
        {
            if (frmBatchBuer == null)
            {
                frmBatchBuer = new JERPApp.Engineer.FrmBatchBuyer();
                new FrmStyle(frmBatchBuer).SetPopFrmStyle(this);
                frmBatchBuer.AffterSave +=new JERPApp.Engineer.FrmBatchBuyer.AffterSaveDelegate(frmBatchBuer_AffterSave);
            }
            frmBatchBuer.BatchBuyer();
            frmBatchBuer.ShowDialog();
        }



        public void LoadData()
        {
            this.dtblPrds = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0]; 
            this.dgrdv.DataSource = this.dtblPrds;
        }
        void ctrlQFind_BeforeFilter()
        {
            this.LoadData();
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在保存变动的记录，涉及到成本计算可能需要稍长时间...");
            string errormsg=string.Empty ; 
            foreach (DataRow drow in this.dtblPrds.Rows)
            {               
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accPrds.UpdateProductForMinPackingQty(ref errormsg,
                    drow["PrdID"],
                    drow["MinPackingQty"]);
                this.accPrds.UpdateProductForCostPrice(
                    ref errormsg,
                    drow["PrdID"],
                    drow["CostPrice"]);
                this.accPrds.UpdateProductForManufDays(ref errormsg,
                    drow["PrdID"],
                    drow["ManufDays"]);
                drow.AcceptChanges();
            }
             
            FrmMsg.Hide();
            MessageBox.Show("成功保存当前设置");
        }
    }
}