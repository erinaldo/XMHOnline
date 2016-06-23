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
    public partial class FrmIntoStore : Form
    {
        public FrmIntoStore()
        {
            InitializeComponent();
            this.accBoxs = new JCEData.Packing.Boxes();
            this.BoxEntity = new JCEBiz.Packing.BoxEntity();
            this.accItems = new JCEData.Product.IntoStoreItems();
            this.accNotes = new JCEData.Product.IntoStoreNotes();
            this.accPrd = new JCEData.Product.Product();
            this.accStore = new JCEData.Product.Store();
            this.accBoxItems = new JCEData.Packing.BoxItems();
            this.accWorkingSheets = new JCEData.Manufacture.WorkingSheets();
            this.accPackingSheets = new JCEData.Packing.WorkingSheets();
            this.txtBoxCode.KeyDown += new KeyEventHandler(txtBoxCode_KeyDown);
            this.lblError.Text = string.Empty;
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel .Click +=new EventHandler(btnCancel_Click);
            this.New();
        }

     

        private JCEData.Packing .Boxes accBoxs;
        private JCEData.Packing.BoxItems accBoxItems;
        private JCEBiz.Packing.BoxEntity BoxEntity;
        private JCEData.Product.IntoStoreItems accItems;
        private JCEData.Product.IntoStoreNotes accNotes;
        private JCEData.Product.Product accPrd;
        private JCEData.Product.Store accStore;
        private JCEData.Manufacture.WorkingSheets accWorkingSheets;
        private JCEData.Packing.WorkingSheets accPackingSheets;
        private DataTable dtblBoxes,dtblItems; 
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrd.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
       
        public void New()
        { 
            this.txtBoxCode.Focus();
            this.txtBoxCode.Text = string.Empty;
            this.dtblBoxes = this.accBoxs.GetDataBoxesByBoxCode (string .Empty).Tables[0];
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];
           
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
        private void AppendBoxingItem(string BoxCode)
        {
            DataTable dtblBoxItems = this.accBoxItems .GetDataBoxItemsByBoxCode (BoxCode).Tables[0];
            if (dtblBoxItems.Rows.Count == 0) return;
            int PrdID = -1; 
            DataRow[] drowItems;
            DataRow drowItem;
            foreach (DataRow drowBoxItem in dtblBoxItems.Rows)
            {
                PrdID = (int)drowBoxItem["PrdID"];
                if (drowBoxItem["WorkingSheetID"] == DBNull.Value)
                {
                    drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString() + " and WorkingSheetID is null");
                }
                else
                {

                    drowItems = this.dtblItems.Select("WorkingSheetID=" + drowBoxItem["WorkingSheetID"].ToString());
                }

                if (drowItems.Length > 0)
                {
                    drowItem = drowItems[0];
                    drowItem["Quantity"] = (decimal)drowItem["Quantity"] + 1;
                }
                else
                {
                    drowItem = this.dtblItems.NewRow();
                    drowItem["WorkingSheetID"] = drowBoxItem["WorkingSheetID"];
                    drowItem["PrdID"] = PrdID;
                    drowItem["Quantity"] = 1;
                    this.dtblItems.Rows.Add(drowItem);
                }
            }
        }
        private void Save()
        {
            if(this.ctrlBranchStoreID.BranchStoreID ==-1)
            {
                this.lblError .Text ="未选择任何库位";
                return;
            }
            string errormsg = string.Empty;         
            this.dtblItems .Clear ();
            int PrdID=-1;
            decimal Quantity=0;  
            foreach (DataRow drow in this.dtblBoxes .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.AppendBoxingItem(drow["BoxCode"].ToString ());
              
            }
             
            if (this.dtblItems .Rows .Count  == 0)
            {
                this.lblError.Text = "没有任何入库项!";
                return;
            }
            bool flag = false; 
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = -1;
            object  objNoteCode=string.Empty ;
            flag = this.accNotes.InsertIntoStoreNotes(ref errormsg,
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
            object objWorkingSheetID = DBNull.Value;
            int PackingQty=0;
            //这里弄的是包装
            foreach (DataRow drow in this.dtblBoxes.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                if (drow["WorkingSheetID"] != DBNull.Value)
                { 
                    PackingQty = this.accBoxItems.GetDataBoxItemsByBoxCode(drow["BoxCode"].ToString ()).Tables[0].Rows .Count;
                    this.accPackingSheets .UpdateWorkingSheetsForAppendFinishedQty (ref errormsg ,
                        drow["WorkingSheetID"], PackingQty);
                }
            }
            foreach (DataRow drow in this.dtblItems .Rows  )
            {
               
                PrdID = (int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"];
                CostPrice = this.GetCostPrice(PrdID);
                this.accItems.InsertIntoStoreItems(ref errormsg,
                    NoteID,
                    drow["WorkingSheetID"] ,
                    PrdID ,
                    Quantity ,
                    BranchStoreID,
                    CostPrice , 
                    string.Empty );
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                     JCEBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID,
                      NoteID,
                      NoteCode,
                      PrdID,
                      BranchStoreID,
                      Quantity,
                      CostPrice);   
                //弄批号完成
                if (drow["WorkingSheetID"] != DBNull.Value)
                {
                    this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                        drow["WorkingSheetID"],
                        Quantity);
                }
            }
            this.lblError.Text = "成功保存入库";
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
            bool ExisFlag = false;
            this.accBoxs.GetParmBoxesExistFlag(this.txtBoxCode.Text, ref ExisFlag);
            this.lblError.Text = string.Empty;
            if (ExisFlag == false)
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
            this.BoxEntity.LoadData(this.txtBoxCode .Text);           
            drowNew["BoxCode"] = this.txtBoxCode.Text ;
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