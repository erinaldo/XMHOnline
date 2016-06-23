using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JCEApp
{
    public partial class FrmBoxing : Form
    {
        public FrmBoxing()
        {
            InitializeComponent();
            this.accBoxItems = new JCEData.Packing.BoxItems();
            this.accBoxs = new JCEData.Packing.Boxes();
            this.BoxEntity = new JCEBiz.Packing.BoxEntity();
            this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
            this.lblError.Text = string.Empty;
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            
        }

        private JCEData.Packing.Boxes accBoxs;
        private JCEData.Packing.BoxItems accBoxItems;
        private JCEBiz.Packing.BoxEntity BoxEntity;
        private DataTable dtblBoxItems;
        private string boxcode = string.Empty ;
        private string BoxCode
        {
            get
            {
                return this.boxcode;
            }
            set
            {
                this.boxcode = value;
                this.BoxEntity.LoadData(value);
                this.txtBoxCode.Text =value;
                this.txtPrdCode.Text = this.BoxEntity.PrdCode;
                this.txtPrdName.Text = this.BoxEntity.PrdName;
                this.txtPrdSpec.Text = this.BoxEntity.PrdSpec;
                this.txtModel.Text = this.BoxEntity.Model;
                this.dtblBoxItems = this.accBoxItems .GetDataBoxItemsByBoxCode (value).Tables[0];
                foreach (DataRow drow in this.dtblBoxItems.Rows)
                {
                    this.BindRow(drow);
                }
            }
        }
        private void BindRow(DataRow drow)
        {
            JCEApp.Define.Product.CtrlBoxItemRow ctrlRowOper = new JCEApp.Define.Product.CtrlBoxItemRow();
            ctrlRowOper.ColumnHeaderVisible = (this.pnlBoxItem .Controls .Count ==0);
            ctrlRowOper.BindData(drow); 
            this.pnlBoxItem.Controls.Add(ctrlRowOper);
            ctrlRowOper.BringToFront();
            ctrlRowOper.Dock = DockStyle.Top;
        }
       
        private void New()
        { 
            this.BoxCode = string.Empty ;
            this.txtBarcode.Text = string.Empty;
            this.pnlBoxItem.Controls.Clear();
            this.txtBarcode.Focus();
        }
        private void Save()
        {
            if (this.BoxCode == string.Empty ) return;
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblBoxItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.accBoxItems .UpdateBoxItemsForBoxCode (ref errormsg,
                    drow["Barcode"],
                    this.BoxCode);

            }
            this.accBoxs.UpdateBoxesForQuantity(ref errormsg, this.BoxCode);
            this.lblError.Text = "成功完成装箱作业!";
            this.New();
        }
        private void Cancel()
        {
            string errormsg = string.Empty;
            if (this.dtblBoxItems.Rows.Count > 0)
            {
                DataRow drow = this.dtblBoxItems.Rows[this.dtblBoxItems.Rows.Count - 1];                
                this.accBoxItems .UpdateBoxItemsForBoxCode (ref errormsg, 
                    drow["Barcode"],
                    DBNull .Value );
                //设置其总数
                this.accBoxs.UpdateBoxesForQuantity(ref errormsg, this.BoxCode);               
                drow.Delete();
                if (this.pnlBoxItem.Controls.Count > 0)
                {
                    this.pnlBoxItem.Controls.RemoveAt(0);
                }
            }
            else
            {
                if (this.BoxCode !=string.Empty)
                {
                    this.New();
                }
            }
            this.txtBarcode.Text = string.Empty;
        }
        private void AppendNote()
        {
            bool ExistFlag = false;
            this.accBoxs.GetParmBoxesExistFlag(this.txtBarcode.Text, ref ExistFlag);
            this.lblError.Text = string.Empty;
            if (ExistFlag==false)
            {
                lblError.Text = "箱号不存在";
                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
            }
            else
            {
                this.BoxCode = this.txtBarcode.Text;
                this.txtBarcode.Text = string.Empty;
            }
        }
        private void AppendItem()
        {
            bool MatchFlag = false;
            this.accBoxItems.GetParmBoxItemsBoxingMatch(this.txtBarcode.Text, this.BoxEntity.PrdID, ref MatchFlag);
            this.lblError.Text = string.Empty;
            if (MatchFlag == false)
            {
                this.lblError.Text = "产品不匹配";
                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
                return;
            }
            DataRow[] drowItems = this.dtblBoxItems.Select("Barcode='" + this.txtBarcode .Text +"'", "", DataViewRowState.CurrentRows);
            if (drowItems.Length > 0)
            {
                this.lblError.Text = "此号已扫入";
                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
                return;
            }
            DataRow drowNew = this.dtblBoxItems.NewRow();
            drowNew["Barcode"] = this.txtBarcode.Text;
            this.dtblBoxItems.Rows.Add(drowNew);
            this.BindRow(drowNew);
            this.txtBarcode.Text = string.Empty;
        }
        void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.lblError.Text = string.Empty;
            if (this.txtBarcode.Text == "GOOD")
            {
                this.Save();
                return;
            }
            if (this.txtBarcode.Text == "NOGOOD")
            {
                this.Cancel();
                return;
            }
            if (this.BoxCode == string.Empty)
            {
                this.AppendNote();
                return;
            }
            else
            {
                this.AppendItem();
            }

        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }
    }
}