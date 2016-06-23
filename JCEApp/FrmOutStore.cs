using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections ;
namespace JCEApp
{
    public partial class FrmOutStore : Form
    {
        public FrmOutStore()
        {
            InitializeComponent();
            this.accBoxs = new JCEData.Packing.Boxes();
            this.BoxEntity = new JCEBiz.Packing.BoxEntity();
            this.accItems = new JCEData.Product.OutStoreItems();
            this.accNotes = new JCEData.Product.OutStoreNotes();
            this.accPrd = new JCEData.Product.Product();
            this.accStore = new JCEData.Product.Store();
            this.txtBoxCode.KeyDown += new KeyEventHandler(txtBoxCode_KeyDown);
            this.lblError.Text = string.Empty;
            this.btnOK .Click +=new EventHandler(btnOK_Click);
            this.btnCancel .Click +=new EventHandler(btnCancel_Click);
            this.New();
        }

        private JCEData.Packing.Boxes accBoxs;
        private JCEBiz.Packing.BoxEntity BoxEntity;
        private JCEData.Product.OutStoreItems accItems;
        private JCEData.Product.OutStoreNotes accNotes;
        private JCEData.Product.Product accPrd;
        private JCEData.Product.Store accStore;
        private DataTable dtblBoxes,dtblItems; 
        private decimal GetCostPrice(int PrdID)
        {

            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, this.ctrlBranchStoreID.BranchStoreID, ref rut);
            if (rut > 0)
            {
                return rut;
            }
            this.accPrd.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        private decimal GetStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, this.ctrlBranchStoreID.BranchStoreID, ref rut);
            return rut;
        }
       
        public void New()
        {
           
            this.txtBoxCode.Focus();
            this.txtBoxCode.Text = string.Empty;
            this.dtblBoxes = this.accBoxs.GetDataBoxesByBoxCode (string.Empty).Tables[0];
            this.dtblItems = this.accItems.GetDataOutStoreItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("StoreQty", typeof(decimal));
           
        }
        private void BindRow(DataRow drow)
        {
            JCEApp.Define.Product.CtrlBoxRow ctrlRowOper = new JCEApp.Define.Product.CtrlBoxRow();
            ctrlRowOper.ColumnHeaderVisible = (this.pnlItem .Controls.Count == 0);
            ctrlRowOper.BindData(drow); 
            this.pnlItem .Controls.Add(ctrlRowOper);
            ctrlRowOper.BringToFront();
            ctrlRowOper.Dock = DockStyle.Top;
        }
        private void Save()
        {
            if(this.ctrlBranchStoreID  .BranchStoreID ==-1)
            {
                this.lblError .Text ="未选择任何库位";
                return;
            }
            string errormsg = string.Empty;         
            this.dtblItems .Clear ();
            int PrdID=-1;
            decimal Quantity=0;
            DataRow[] drowItems;
            DataRow drowItem;
            string BoxCode=string.Empty ;
            foreach (DataRow drow in this.dtblBoxes .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                PrdID = (int)drow["PrdID"];
                Quantity =(decimal)drow["Quantity"];
                BoxCode =drow["BoxCode"].ToString ();
                drowItems=this.dtblItems .Select ("PrdID="+PrdID .ToString ());
                if(drowItems .Length ==0)
                {
                    drowItem =this.dtblItems .NewRow ();
                    drowItem ["PrdID"] =PrdID ;
                    drowItem["Quantity"]=Quantity;
                    drowItem["StoreQty"] = this.GetStoreQty(PrdID);
                    drowItem["BoxInfor"]=BoxCode ;
                    this.dtblItems .Rows .Add (drowItem );
                }
                else
                {
                    drowItem =this.dtblItems .Rows [0];
                    drowItem["Quantity"] = (decimal) drowItem["Quantity"]+Quantity;
                    drowItem["BoxInfor"]=drowItem["BoxInfor"].ToString ()+";"+BoxCode ;
                }
            }
            if (this.dtblItems .Rows .Count  == 0)
            {
                this.lblError.Text = "没有任何入库项!";
                return;
            }
            if (this.dtblItems.Select ("Quantity>StoreQty").Length >0)
            {
                this.lblError.Text = "存在库存不足产品!";
                return;
            }
            bool flag = false; 
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID =-1;
            object  objNoteCode=string.Empty ;
            flag = this.accNotes.InsertOutStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                DateTime.Now.Date,
                JCEBiz.Frame.UserEntity.PsnID,
                string.Empty);
            if (!flag)
            {
                this.lblError.Text = errormsg;
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode =objNoteCode .ToString ();  
            int BranchStoreID=this.ctrlBranchStoreID .BranchStoreID ;
            decimal CostPrice = 0;
            object objItemID =-1;
            foreach (DataRow drow in this.dtblItems .Rows  )
            {
                PrdID = (int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"];
                CostPrice = this.GetCostPrice(PrdID);
                objItemID = DBNull.Value;
                this.accItems.InsertOutStoreItems(ref errormsg,
                    ref objItemID ,
                    NoteID,
                    PrdID ,
                    Quantity ,
                    BranchStoreID,
                    CostPrice ,
                    drow["BoxInfor"],
                    string.Empty);
                //入库
                this.accStore.InsertStoreForOutStore(ref errormsg,
                     JCEBiz.Finance.NoteNameParm.PrdOutStoreNoteNameID,
                      NoteID,
                      NoteCode,
                      PrdID,
                      BranchStoreID,
                      Quantity,
                      CostPrice);       
            }
            this.lblError.Text = "成功保存出库";
            this.New();
        }
        private void Cancel()
        {
            string errormsg = string.Empty;
            if (this.dtblBoxes .Rows.Count > 0)
            {
                DataRow drow = this.dtblBoxes.Rows[this.dtblBoxes.Rows.Count - 1];               
                drow.Delete();
                this.pnlItem.Controls.RemoveAt(0);               
            }
            this.txtBoxCode.Text = string.Empty;
        }
        private void AppendBox()
        {
            bool ExistFlag = false;
            this.accBoxs.GetParmBoxesExistFlag(this.txtBoxCode.Text, ref ExistFlag);
            this.lblError.Text = string.Empty;
            if (ExistFlag == false)
            {
                lblError.Text = "箱号不存在";
                this.txtBoxCode.Focus();
                this.txtBoxCode.SelectAll();
                return;
            }
            if(this.dtblBoxes .Select ("BoxCode='"+this.txtBoxCode .Text+"'","",DataViewRowState .CurrentRows ).Length >0)
            {
                lblError .Text ="此箱号已存在";
                this.txtBoxCode.Focus();
                this.txtBoxCode.SelectAll();
                return;
            }
            DataRow drowNew = this.dtblBoxes.NewRow(); 
            this.BoxEntity.LoadData(this.txtBoxCode .Text );           
            drowNew["BoxCode"] = this.txtBoxCode .Text ;
            drowNew["PrdID"] = this.BoxEntity .PrdID;
            drowNew["PrdCode"] = this.BoxEntity.PrdCode;
            drowNew["PrdName"] = this.BoxEntity.PrdName;
            drowNew["PrdSpec"] = this.BoxEntity.PrdSpec;           
            drowNew["Quantity"] = this.BoxEntity.Quantity;
            this.dtblBoxes.Rows.Add(drowNew);
            this.BindRow(drowNew);
            this.txtBoxCode.Text = string.Empty;
             
        }
   
        void txtBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.lblError.Text = string.Empty;
            if (this.txtBoxCode.Text == "GOOD")
            {
                this.Save();
                return;
            }
            if (this.txtBoxCode.Text == "NOGOOD")
            {
                this.Cancel();
                return;
            }
            this.AppendBox();
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}