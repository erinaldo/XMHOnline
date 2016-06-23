using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmBOMMove : Form
    {
        public FrmBOMMove()
        {
            InitializeComponent();
            this.dgrdvBOM.AutoGenerateColumns = false;
            this.dgrdvParent.AutoGenerateColumns = false; 
            this.accBOM = new JERPData.Product.BOM();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.ctrlPrdID.AffterSelected += new JERPApp.Define.Material.CtrlProduct.AffterSelectedDelegate(ctrlPrdID_AffterSelected);
            this.dgrdvParent.CellContentClick += new DataGridViewCellEventHandler(dgrdvParent_CellContentClick);
            this.btnBOMClear.Click += new EventHandler(btnBOMClear_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        
        }

     
        private FrmPrdDelete frmDelete;
        private FrmBOMMoveOper frmOper;
        private DataTable dtblParent,dtblBOM; 
        private JERPData.Product.BOM accBOM;
        private JERPData.Manufacture.ManufProcess accManufProcess; 
        private void LoadBOM()
        {
            this.dtblBOM = this.accBOM.GetDataBOMByParentID(this.ctrlPrdID.PrdID).Tables[0];
            this.dgrdvBOM.DataSource = this.dtblBOM;
        }
        private void LoadParent()
        {
            this.dtblParent = this.accBOM .GetDataBOMByChildPrdID(this.ctrlPrdID.PrdID).Tables[0];
            this.dgrdvParent.DataSource = this.dtblParent;
        }
        void ctrlPrdID_AffterSelected()
        {
            this.LoadBOM();
            this.LoadParent();
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (frmDelete == null)
            {
                frmDelete = new FrmPrdDelete();
                new FrmStyle(frmDelete).SetPopFrmStyle(this);
                frmDelete.AffterSave += new FrmPrdDelete.AffterSaveDelegate(frmDelete_AffterSave);
            }
            frmDelete.PrdDelete(this.ctrlPrdID.PrdID);
            frmDelete.ShowDialog();
        }

        void frmDelete_AffterSave()
        {
            if (frmDelete.DeleteFlag)
            {
                this.ctrlPrdID.PrdID = -1;
            }
        }

        void btnBOMClear_Click(object sender, EventArgs e)
        { 
            DialogResult rul; 
            if(this.dtblParent .Rows .Count >0)
            {
                rul = MessageBox.Show("对不起，存在引用项，不能清除当前物料清单！", "出错提醒", MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
             rul = MessageBox.Show("您将清除当前物料，一经清除不能恢复，请确认！", "清除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rul ==DialogResult .No )return;
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblBOM.Rows)
            {
                flag=this.accBOM.DeleteBOM(ref errormsg,
                    drow["ID"]);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            MessageBox.Show("成功清除当前物料");
            this.LoadBOM(); 
        }

        void dgrdvParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvParent.Columns[icol].Name == this.ColumnbtnRemove.Name)
            {
                int ParentID = (int)this.dtblParent.DefaultView[irow]["ParentID"];
                if (frmOper == null)
                {
                    frmOper = new FrmBOMMoveOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSelect += new FrmBOMMoveOper.AffterSelectDelegate(frmOper_AffterSelect);
                }
                frmOper.BOMMoveOper(ParentID);
                frmOper.ShowDialog();
            }

        }

        void frmOper_AffterSelect(long ManufProcessID)
        {
            
            DialogResult rul = MessageBox.Show("您将把当前产品的物料转入所选的产品的工序里，并从此工序清单中去除当前产品！", "清除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg=string.Empty ; 
            object objID=DBNull .Value ;
            int irow = this.dgrdvParent.CurrentCell.RowIndex;
            int ParentID = (int)this.dtblParent.DefaultView[irow]["ParentID"]; 
            long OldBOMID = (long)this.dtblParent.DefaultView[irow]["ID"];
            bool flag=this.accBOM.DeleteBOM (ref errormsg,
                OldBOMID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            } 
            foreach (DataRow drow in this.dtblBOM.Rows)
            {
                this.accBOM.InsertBOM (
                    ref errormsg ,
                    ref objID ,
                    ParentID,
                    ManufProcessID ,
                    drow["PrdID"],
                    drow["AssemblyQty"],
                    drow["SourceTypeID"],
                    drow["Element"],
                    drow["Substitute"],
                    drow["Technology"],
                    drow["PostProcessing"],
                    drow["LossRate"],
                    drow["FixedFlag"],
                    drow["Memo"]);

            }
            this.accManufProcess.UpdateManufProcessForMtrCostPrice(ref errormsg, ManufProcessID); 
            this.LoadParent();
            this.LoadBOM();
            MessageBox.Show("成功进行物料转移");

        }
    }
}