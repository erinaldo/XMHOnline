using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmBoxing : Form
    {
        public FrmBoxing()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.accBoxs = new JERPData.Packing.Boxes();
            this.BoxEntity = new JERPBiz.Packing.BoxEntity(); 
            this.SetPermit();
        }
        private JERPData.Packing.Boxes accBoxs;
        private JERPData.Packing.BoxItems accBoxItems;
        private JERPBiz.Packing.BoxEntity BoxEntity; 
        private DataTable dtblBoxItems;
        private string boxcode = string.Empty;
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
                this.txtBoxCode.Text = value;
                this.txtPrdCode.Text = this.BoxEntity.PrdCode;
                this.txtPrdName.Text = this.BoxEntity.PrdName;
                this.txtPrdSpec.Text = this.BoxEntity.PrdSpec;
                this.txtModel.Text = this.BoxEntity.Model;
                this.dtblBoxItems = this.accBoxItems .GetDataBoxItemsByBoxCode (value).Tables[0];
                this.dgrdv.DataSource = this.dtblBoxItems;
            }
        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(449);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(450);
            if (this.enableBrowse)
            {
                this.New();
                this.lblError.Text = string.Empty;         
            }
            this.txtBarcode .ReadOnly=!this.enableSave ;
            if (this.enableSave)
            {
                this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
            }
        }

        private void New()
        {
            this.BoxCode =string.Empty ;
            this.txtBarcode.Text = string.Empty;
        }
        private void Save()
        {
            if (this.BoxCode == string.Empty)
            {
                this.lblError.Text = "箱号不能为空!";
                return;
            }
            string errormsg=string.Empty ;
            foreach (DataRow drow in this.dtblBoxItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                this.accBoxItems .UpdateBoxItemsForBoxCode  (ref errormsg,
                    drow["Barcode"],
                    this.BoxCode );

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
                this.accBoxItems.UpdateBoxItemsForBoxCode(ref errormsg,
                    drow["Barcode"],
                    DBNull.Value);
                    //设置其总数
                this.accBoxs.UpdateBoxesForQuantity(ref errormsg, this.BoxCode);
                drow.Delete();
            }
            else
            {
                if (this.BoxCode!=string.Empty )
                {
                    this.New();
                }
            }
            this.txtBarcode.Text = string.Empty;
        }
        private void AppendNote()
        {
            bool flag = false;
            this.accBoxs.GetParmBoxesExistFlag(this.txtBarcode.Text, ref flag);
            if (flag)
            {
                this.BoxCode = this.txtBarcode.Text;
                this.txtBarcode.Text = string.Empty;               
            }
            else
            {
                lblError.Text = "箱号不存在";
                this.BoxCode = string.Empty;
                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
            }
        }
        private void AppendItem()
        {
            bool MacthFlag = false;
            this.accBoxItems.GetParmBoxItemsBoxingMatch  (this.txtBarcode.Text, this.BoxEntity.PrdID, ref MacthFlag);
            this.lblError.Text = string.Empty;
            if (MacthFlag==false)
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
            if (this.BoxCode ==string.Empty)
            {
                this.AppendNote();
                return;
            }
            else
            {
                this.AppendItem();
            }

        }
    }
}