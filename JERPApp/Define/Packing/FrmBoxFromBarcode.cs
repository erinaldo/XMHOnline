using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Define.Packing
{
    public partial class FrmBoxFromBarcode : Form
    {
        public FrmBoxFromBarcode()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.BoxEntity = new JERPBiz.Packing .BoxEntity();
            this.accBoxs = new JERPData.Packing.Boxes();
            this.btnSelect.Click += new EventHandler(btnSelect_Click);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged); 
            this.dtblBox = this.accBoxs.GetDataBoxesByBoxCode(string.Empty).Tables[0];
            this.dgrdv.DataSource = this.dtblBox;
        } 
        private JERPBiz.Packing.BoxEntity BoxEntity;
        private JERPData.Packing.Boxes accBoxs;
        private DataTable dtblBox;
        private Hashtable hasLimitPrds;
        private int GetBoxCodeCount(string BoxCode)
        {
            int cnt=0;
            foreach(DataGridViewRow grow in this.dgrdv .Rows )
            {
                if (grow.IsNewRow) continue;
                if (grow.Cells[this.ColumnBoxCode.Name].Value.ToString() == BoxCode)
                {
                    cnt++;
                    continue;
                }
            }
            return cnt;
        }
        void SetGridRowNull(DataGridViewRow grow)
        {
            for (int j = 0; j < this.dgrdv.ColumnCount; j++)
            {
                grow.Cells[j].Value = DBNull.Value;
            }

        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBoxCode.Name)
            {
                DataGridViewRow grow = this.dgrdv.Rows[irow];
                string BoxCode = this.dgrdv[icol, irow].Value.ToString();
                int cnt = this.GetBoxCodeCount(BoxCode);
                if (cnt > 1)
                {
                    MessageBox.Show("已存在此箱号");
                    this.SetGridRowNull(grow);
                    return;
                }
                bool Existflag = false;
                this.accBoxs.GetParmBoxesExistFlag(BoxCode, ref Existflag);
                if (Existflag == false)
                {
                    MessageBox.Show("未存在此箱号");
                    this.SetGridRowNull(grow);
                    return;
                }
                this.BoxEntity.LoadData(BoxCode);
                if (this.hasLimitPrds.Count > 0)
                {
                    if(!this.hasLimitPrds.ContainsKey(this.BoxEntity .PrdID )) 
                    {
                        MessageBox.Show("不在限定范围");
                        this.SetGridRowNull(grow);
                        return;
                    }
                }
                this.dgrdv[this.ColumnPrdID.Name, irow].Value = this.BoxEntity.PrdID;
                this.dgrdv[this.ColumnPrdCode.Name, irow].Value = this.BoxEntity.PrdCode;
                this.dgrdv[this.ColumnPrdName.Name, irow].Value = this.BoxEntity.PrdName;
                this.dgrdv[this.ColumnPrdSpec.Name, irow].Value = this.BoxEntity.PrdSpec;
                this.dgrdv[this.ColumnModel.Name, irow].Value = this.BoxEntity.Model;
                this.dgrdv[this.ColumnModel.Name, irow].Value = this.BoxEntity.UnitName;
                this.dgrdv[this.ColumnQuantity.Name, irow].Value = this.BoxEntity.Quantity;
            }
        }


      
        public void New(Hashtable hasLimitPrds)
        {
            this.hasLimitPrds = hasLimitPrds;
            if (this.dtblBox != null) this.dtblBox.Clear(); 
        } 
        public delegate void AffterConfirmDelegate(DataRow drowBox);
        private AffterConfirmDelegate affterSelect;
        public event AffterConfirmDelegate AffterSelect
        {
            add
            {
                affterSelect += value;
            }
            remove
            {
                affterSelect -= value;
            }
        }
     
        void btnSelect_Click(object sender, EventArgs e)
        { 
            foreach (DataRow drow in this.dtblBox .Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (this.affterSelect != null) this.affterSelect(drow);
            }
            this.Close();
        }
    }
}