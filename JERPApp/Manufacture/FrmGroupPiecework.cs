using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmGroupPiecework : Form
    {
        public FrmGroupPiecework()
        {
            InitializeComponent();
            this.accPiecework = new JERPData.Manufacture.GroupPiecework();
            this.accProcessType = new JERPData.Manufacture.ProcessType();
            this.accPieceworkItems = new JERPData.Manufacture.GroupPieceworkItems();
            this.accPrds = new JERPData.Product.Product();
            this.accXPsn = new JERPData.Manufacture.WorkgroupXPsn();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private JERPData.Manufacture.GroupPiecework accPiecework;
        private JERPData.Manufacture.ProcessType accProcessType;
        private JERPData.Manufacture.GroupPieceworkItems accPieceworkItems;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmManufPrd frmPrd;
        private JERPApp.Define.Product.FrmManufPrd frmAddPrd;
        private JERPData.Manufacture.WorkgroupXPsn accXPsn;
        private DataTable dtblPiecework, dtblProcessType, dtblPrds;
        private JCommon.FrmGridFind frmGridPrd;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(625);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(626);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.dtpDateManuf.Value = DateTime.Now.Date;
                this.LoadData();
                this.dtpDateManuf.ValueChanged += new EventHandler(dtpDateManuf_ValueChanged);
            }          
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnAddPrd .Click +=new EventHandler(btnAddPrd_Click);
                this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
                this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
                this.dgrdv .RowEnter +=new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnAddPsn.Click += new EventHandler(btnAddPsn_Click);
                this.btnAddMorePsn.Click += new EventHandler(btnAddMorePsn_Click);
            }
        }

        private void SetColumnSrc()
        {

            this.dtblProcessType = this.accProcessType.GetDataProcessType().Tables[0];
            this.ColumnProcessTypeName.DataSource = this.dtblProcessType;
            this.ColumnProcessTypeName.ValueMember = "ProcessTypeID";
            this.ColumnProcessTypeName.DisplayMember = "ProcessTypeName";

            this.ColumnPriceUnitName.DataSource = this.dtblProcessType;
            this.ColumnPriceUnitName.ValueMember = "ProcessTypeID";
            this.ColumnPriceUnitName.DisplayMember = "UnitName";


            this.dtblPrds = this.accPrds.GetDataProductForManufPrd ().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

         

            this.ColumnUnitName.DataSource = this.dtblPrds;
            this.ColumnUnitName.ValueMember = "PrdID";
            this.ColumnUnitName.DisplayMember = "UnitName";
        }
        void dtpDateManuf_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private const int PSNGridIndex = 13;
        private const int PSNDtblIndex =10;
        private void AddPsnColumn(int PsnID, string PsnCode, string PsnName)
        {
            //加一列
            DataGridViewTextBoxColumn txtcol = new DataGridViewTextBoxColumn();
            txtcol.DataPropertyName = PsnID.ToString();
            txtcol.HeaderText = PsnCode + @"
" + PsnName;
            txtcol.Width = 66;
            this.dgrdv.Columns.Add(txtcol);
        }
        private void LoadData()
        {
            while (this.dgrdv.ColumnCount > PSNGridIndex)
            {
                this.dgrdv.Columns.RemoveAt(PSNGridIndex);
            }
            DataTable dtblPsns = this.accPieceworkItems .GetDataGroupPieceworkItemsPersonnelByDateManuf (this.dtpDateManuf .Value .Date).Tables[0];
            foreach (DataRow drow in dtblPsns.Rows)
            {
                this.AddPsnColumn((int)drow["PsnID"], drow["PsnCode"].ToString(), drow["PsnName"].ToString());
            }
            this.dtblPiecework = this.accPiecework.GetDataGroupPieceworkForSetting(this.dtpDateManuf.Value.Date).Tables[0];
            UniqueConstraint c = new UniqueConstraint("c", new DataColumn[] {
                this.dtblPiecework .Columns ["ProcessTypeID"],
                this.dtblPiecework .Columns ["PrdID"],
                this.dtblPiecework .Columns ["ReworkFlag"]
            });
            this.dtblPiecework.Constraints.Add(c);
            this.dtblPiecework.Columns["ReworkFlag"].DefaultValue = false;
            this.dgrdv.DataSource = this.dtblPiecework;

        }
        private void AddPsn(int PsnID,string PsnCode,string PsnName)
        {
            if (PsnID == -1) return;
            for (int j = PSNDtblIndex; j < this.dtblPiecework.Columns.Count; j++)
            {
                if (this.dtblPiecework.Columns[j].ColumnName == PsnID.ToString())
                {                  
                    return;
                }
            }
            this.dtblPiecework.Columns.Add(PsnID.ToString(), typeof(decimal));
            this.AddPsnColumn(PsnID, PsnCode, PsnName);
        }
        void btnAddPsn_Click(object sender, EventArgs e)
        {
            this.AddPsn(this.ctrlPsnID.PsnID, this.ctrlPsnID.PsnCode, this.ctrlPsnID.PsnName);
        }

        void btnAddMorePsn_Click(object sender, EventArgs e)
        {
            DataTable dtblPsns = this.accXPsn.GetDataWorkgroupXPsnForDailyWorking(this.ctrlWorkgroupID.WorkgroupID,this.ctrlShiftID .ShiftID  ).Tables[0];
            foreach (DataRow drow in dtblPsns.Rows)
            {
                this.AddPsn((int)drow["PsnID"], drow["PsnCode"].ToString(), drow["PsnName"].ToString());
            }
        }


        private decimal GetLaborPrice(int ProcessTypeID,bool ReworkFlag)
        {
            string fieldname = (ReworkFlag) ? "ReworkLaborPrice" : "LaborPrice";
            DataRow[] drows = this.dtblProcessType.Select("ProcessTypeID=" + ProcessTypeID.ToString());
            if (drows.Length > 0)
            {

                if (drows[0][fieldname] == DBNull.Value) return 0;
                return (decimal)drows[0][fieldname];
            }
            return 0;
        }
        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        { 
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
               
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdID"];
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmManufPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            this.dgrdv.CurrentCell.Value = PrdID;
            frmPrd.Close();

        }

        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmManufPrd();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += frmAddPrd_AffterSelected;
            }
            this.frmAddPrd.ShowDialog();
        }
        void frmAddPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"]; 
            DataRow drowNew = this.dtblPiecework .NewRow();
            drowNew["PrdID"] = PrdID;
            this.dtblPiecework.Rows.Add(drowNew);

        }
        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            if (irow <= 0) return;
           if ((this.dgrdv[this.ColumnProcessTypeName.Name, irow].Value == DBNull.Value)
                ||(this.dgrdv[this.ColumnProcessTypeName.Name, irow].Value == null))
            {
                this.dgrdv[this.ColumnProcessTypeName.Name, irow].Value = this.dgrdv[this.ColumnProcessTypeName.Name, irow - 1].Value;
                this.dgrdv[this.ColumnLaborPrice.Name, irow].Value = this.dgrdv[this.ColumnLaborPrice.Name, irow - 1].Value;
           }
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name == this.ColumnQuantity.Name)
              || (this.dgrdv.Columns[icol].Name == this.ColumnUnitName.Name)
              || (this.dgrdv.Columns[icol].Name == this.ColumnPriceUnitName.Name))
            {
                object objQuantity = this.dgrdv[this.ColumnQuantity.Name, irow].Value;
                bool flag = (this.dgrdv[this.ColumnUnitName.Name, irow].FormattedValue.ToString() == this.dgrdv[this.ColumnPriceUnitName.Name, irow].FormattedValue.ToString());
                this.dgrdv[this.ColumnPriceQty.Name, irow].ReadOnly = flag;
                if (flag)
                {
                    this.dgrdv[this.ColumnPriceQty.Name, irow].Value = objQuantity;
                }
            }
            if ((this.dgrdv.Columns[icol].Name == this.ColumnProcessTypeName.Name)
                ||(this.dgrdv.Columns[icol].Name == this.ColumnReworkFlag.Name))
            {
                object objProcessTypeID=this.dgrdv[this.ColumnProcessTypeName .Name ,irow ].Value ;
                object objReworkFlag = this.dgrdv[this.ColumnReworkFlag.Name, irow].Value;
                if ((objProcessTypeID != null) && (objProcessTypeID != DBNull.Value)
                    && (objReworkFlag  != null) && (objReworkFlag  != DBNull.Value))
                {
                   this.dgrdv [this.ColumnLaborPrice .Name ,irow].Value  = this.GetLaborPrice((int)objProcessTypeID,(bool)objReworkFlag);
                }
            }
            if ((this.dgrdv.Columns[icol].Name == this.ColumnLaborPrice.Name)
                || (this.dgrdv.Columns[icol].Name == this.ColumnPriceQty.Name))
            {
                object objLaborPrice = this.dgrdv[this.ColumnLaborPrice.Name, irow].Value;
                object objPriceQty = this.dgrdv[this.ColumnPriceQty.Name, irow].Value;
                if ((objLaborPrice != null) && (objLaborPrice != DBNull.Value)
                    && (objPriceQty != null) && (objPriceQty != DBNull.Value))
                {
                    this.dgrdv[this.ColumnLaborWage.Name, irow].Value = (decimal)objPriceQty * (decimal)objLaborPrice;
                
                }
            }
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPiecework .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PieceworkID"] == DBNull.Value)
            {
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPiecework .DeleteGroupPiecework (ref ErrorMsg,
                    drow["PieceworkID"]);
                if (!flag)
                {
                    MessageBox.Show(ErrorMsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnProcessTypeName.Name].Value == DBNull.Value)
                     || (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "记录输入不全";
                }
                grow.Cells[this.ColumnPriceQty.Name].ReadOnly = (grow.Cells[this.ColumnUnitName.Name].FormattedValue.ToString() == grow.Cells[this.ColumnPriceUnitName.Name].FormattedValue.ToString());

            }
        }

       
        private bool ValidateData()
        {
            DataRow[] drows = this.dtblPiecework.Select("ProcessTypeID is null or Quantity is null and PrdID is null", "", DataViewRowState.CurrentRows);
            if(drows .Length >0)
            {
                MessageBox .Show ("存在未填全记录");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            decimal totalparm, LaborWage;
            object objParm,objPieceworkID;
            int PsnID;
            foreach (DataRow drow in this.dtblPiecework.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                totalparm = 0;
                for (int j = PSNDtblIndex; j < this.dtblPiecework.Columns.Count; j++)
                {
                    if (drow[j] != DBNull.Value)
                    {
                        totalparm += (decimal)drow[j];
                    }
                }
                if (totalparm == 0)
                {
                    if (drow["PieceworkID"] != DBNull.Value)
                    {
                        this.accPiecework.DeleteGroupPiecework (ref errormsg, drow["PieceworkID"]);
                    }
                    drow["PieceworkID"] = DBNull.Value;
                    continue;
                }
                if (drow["PieceworkID"] == DBNull.Value)
                {
                    objPieceworkID = DBNull.Value;
                    flag = this.accPiecework.InsertGroupPiecework(ref errormsg,
                        ref objPieceworkID,
                        this.dtpDateManuf.Value.Date,
                        drow["ProcessTypeID"],
                        drow["PrdID"],
                        drow["ReworkFlag"],
                        drow["Quantity"],
                        drow["BadQty"],
                        drow["PriceQty"]);
                    if (flag)
                    {
                        drow["PieceworkID"] = objPieceworkID;
                    }

                }
                else
                {
                    flag=this.accPiecework .UpdateGroupPiecework (ref errormsg ,
                        drow["PieceworkID"],
                        drow["ProcessTypeID"],
                        drow["PrdID"],
                        drow["ReworkFlag"],
                        drow["Quantity"],
                        drow["BadQty"],
                        drow["PriceQty"]);
                }
                if (!flag) continue;
                LaborWage = (decimal)drow["LaborWage"];
                for (int j = PSNDtblIndex; j < this.dtblPiecework .Columns.Count; j++)
                {
                    objParm = drow[j];
                    PsnID = int.Parse(this.dtblPiecework.Columns[j].ColumnName);
                    if (objParm == DBNull.Value)
                    {
                        this.accPieceworkItems.DeleteGroupPieceworkItems(ref errormsg,
                            drow["PieceworkID"],
                            PsnID);
                    }
                    else
                    {
                        this.accPieceworkItems.SaveGroupPieceworkItems(
                        ref errormsg,
                          drow["PieceworkID"],
                            PsnID,
                            objParm,
                            LaborWage * (decimal)objParm / totalparm);
                    }

                }
                this.accPiecework.UpdateGroupPieceworkForPsnInfor(ref errormsg,
                    drow["PieceworkID"]);
                
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前设置");
        }
    }
}