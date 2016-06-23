using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class CtrlPrdParmValueOper : UserControl
    {
        public CtrlPrdParmValueOper()
        {
            InitializeComponent();

            this.accParmType = new JERPData.Product.ParmType();
            this.accParmValue = new JERPData.Product.ParmValues();
            this.accTempletValue = new JERPData.Product.ParmTempletValues();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellEnter += new DataGridViewCellEventHandler(dgrdv_CellEnter);
            this.SetColumnSrc();
            this.btnTemplet.Click += new EventHandler(btnTemplet_Click);
        }

     
        private DataTable dtblParmValues, dtblParmTypes;
        private JERPData.Product.ParmValues accParmValue;
        private JERPData.Product.ParmTempletValues accTempletValue;
        private JERPData.Product.ParmType accParmType;
        private JERPApp.Define.Product.FrmParmItemValue frmItemValue;
      
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objParmTypeID = grow.Cells[this.ColumnParmTypeID.Name].Value;
                if ((objParmTypeID != null) && (objParmTypeID != DBNull.Value))
                {
                    DataRow[] drowTypes = this.dtblParmTypes.Select("ParmTypeID=" + objParmTypeID.ToString());
                    if (drowTypes.Length == 0) return;
                    DataRow drowType = drowTypes[0];
                    if (drowType["ItemValues"] != DBNull.Value)
                    {
                        grow.Cells[this.ColumnItemValues.Name].Value = drowType["ItemValues"];
                        grow.Cells[this.ColumnParmValue.Name].ReadOnly = true;
                    }
                    else
                    {
                        grow.Cells[this.ColumnParmValue.Name].ReadOnly = false;
                    }

                }
            }
        }


        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnParmTypeID.Name)
            {
                object objParmTypeID = this.dgrdv[icol, irow].Value;
                if ((objParmTypeID != null) && (objParmTypeID != DBNull.Value))
                {
                    DataRow[] drowTypes = this.dtblParmTypes.Select("ParmTypeID=" + objParmTypeID.ToString());
                    if (drowTypes.Length == 0) return;
                    DataRow drowType = drowTypes[0];
                    if (drowType["DefaultValue"] != DBNull.Value)
                    {
                        this.dgrdv[this.ColumnParmValue.Name, irow].Value = drowType["DefaultValue"];
                    }

                    if (drowType["ItemValues"] != DBNull.Value)
                    {
                        this.dgrdv[this.ColumnItemValues.Name, irow].Value = drowType["ItemValues"];
                        this.dgrdv[this.ColumnParmValue.Name, irow].ReadOnly = true;
                    }
                    else
                    {
                        this.dgrdv[this.ColumnParmValue.Name, irow].ReadOnly = false;
                    }

                }

            }
        }
        private void SetColumnSrc()
        {
            this.dtblParmTypes = this.accParmType.GetDataParmType().Tables[0];
            this.ColumnParmTypeID.DataSource = this.dtblParmTypes;
            this.ColumnParmTypeID.ValueMember = "ParmTypeID";
            this.ColumnParmTypeID.DisplayMember = "ParmTypeName";

        }
        public void ParmValueOper(int PrdID)
        {
           
            this.dtblParmValues = this.accParmValue.GetDataParmValuesByPrdID(PrdID).Tables[0];
            this.dgrdv.DataSource = this.dtblParmValues;
        }
        void dgrdv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnParmValue.Name)
            {
                if (this.dgrdv[icol, irow].ReadOnly)
                {
                    if (this.frmItemValue == null)
                    {
                        this.frmItemValue = new JERPApp.Define.Product.FrmParmItemValue();
                        new FrmStyle(frmItemValue).SetPopFrmStyle(this.ParentForm );
                        this.frmItemValue.AffterSelect += new JERPApp.Define.Product.FrmParmItemValue.AffterSelectDelegate(frmItemValue_AffterSelect);
                    }
                    this.frmItemValue.SetParmSrc(this.dgrdv[this.ColumnItemValues.Name, irow].Value.ToString());
                    this.frmItemValue.ShowDialog();
                }
            }
        }

        void frmItemValue_AffterSelect(object ParmValue)
        {
            this.dgrdv.CurrentCell.Value = ParmValue;
        }

        public void Save(int PrdID)
        {
           
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblParmValues.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ParmID"] == DBNull.Value)
                {
                    object objParmID = DBNull.Value;
                    flag = this.accParmValue .InsertParmValues (
                        ref errormsg,
                        ref objParmID,
                        PrdID ,
                        drow["ParmTypeID"],
                        drow["ParmValue"]);
                    if (flag)
                    {
                        drow["ParmID"] = objParmID;
                    }
                }
                else
                {
                    flag = this.accParmValue .UpdateParmValues (ref errormsg,
                        drow["ParmID"],
                        drow["ParmTypeID"],
                        drow["ParmValue"]);

                }
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }

            
        }

        void btnTemplet_Click(object sender, EventArgs e)
        {
            DataTable dtblTmpValues = this.accTempletValue.GetDataParmTempletValuesByTempletID(this.ctrlTempletID.TempletID).Tables[0];
            foreach (DataRow drow in dtblTmpValues.Rows)
            {
                if (this.dtblParmValues.Select("ParmTypeID=" + drow["ParmTypeID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0) continue;
                DataRow drowNew = this.dtblParmValues.NewRow();
                drowNew["ParmTypeID"] = drow["ParmTypeID"];
                drowNew["ParmValue"] = drow["ParmValue"];
                this.dtblParmValues.Rows.Add(drowNew);
            }
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            if (irow == this.dgrdv.RowCount - 1) return;
            DataRow drow = this.dtblParmTypes.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ParmID"] == DBNull.Value)
            {
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            flag = this.accParmType.DeleteParmType(ref ErrorMsg,
                drow["ParmID"]);
            if (!flag)
            {
                MessageBox.Show(ErrorMsg);
                e.Cancel = true;
            }

        }
    }
}
