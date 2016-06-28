using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmManuPrdTypeRelation : Form
    {
        public FrmManuPrdTypeRelation()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            accProRa = new JERPData.Product.ManuProductTypeProRelation();

            this.SetPermit();
        }

        private JERPData.Product.ManuProductTypeProRelation accProRa;
        private DataTable dtblProRas;

        private JERPApp.Define.Product.FrmManuPrdType frmSrcPrdType;
        private JERPApp.Define.Product.FrmManuPrdType frmDescPrdType;

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


        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(15);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(16);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }

            this.dgrdv.AllowUserToDeleteRows = enableSave;
            if (this.enableSave)
            {
                this.btnSrcType.Click += new EventHandler(btnSrcType_Click);
                this.btnDescType.Click += new EventHandler(btnDescType_Click);

                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnAdd.Click += new EventHandler(btnAdd_Click);
                this.btnDel.Click += new EventHandler(btnDel_Click);
            }

        }

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            DataRow drow = this.dtblProRas.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            string errorMsg = String.Empty;
            Boolean flag = accProRa.DeleteManuProductTypeProRelation(ref errorMsg, drow["ID"]);
            if (!flag)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = true;
            MessageBox.Show("删除成功。");
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtblProRas = this.accProRa.GetDataManuProductTypeProRelation().Tables[0];
            this.dtblProRas.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblProRas;
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
           DataRow[] drows = this.dtblProRas.Select("CheckedFlag=1");//勾选的行
           if (drows.Length <= 0) {
               MessageBox.Show("你未选择行！");
               return;
           }
           bool flag = false;
           String errormsg = String.Empty;
           foreach (DataRow drow in drows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                flag = accProRa.DeleteManuProductTypeProRelation(ref errormsg,drow["ID"]);
                if (!flag){
                    MessageBox.Show("发生错误："+ errormsg);
                    break;
                }
            }
           MessageBox.Show("删除成功。");
           this.LoadData();
        }


        void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            bool flag = false;

            String errormsg = String.Empty;
            object ID = DBNull.Value;
            int PrdIDSrc = Int32.Parse(txtSrcTypeID.Text);
            int PrdIDDesc = Int32.Parse(txtDescTypeID.Text);
            flag = accProRa.InsertManuProductTypeProRelation(ref errormsg, ref ID, PrdIDSrc, PrdIDDesc);
            if (flag)
            {
                this.LoadData();
                ClearContext();
                MessageBox.Show("添加成功。");
            }
            else
            {
                MessageBox.Show("发生错误："+ errormsg);
            }
        }

        private void ClearContext() {
            txtSrcTypeID.Text = String.Empty;
            txtDescTypeID.Text = String.Empty;
            txtSrcTypeName.Text = String.Empty;
            txtDescTypeName.Text = String.Empty;
        }

        private Boolean ValidateData()
        {
            if (txtSrcTypeName.Text.Equals(""))
            {
                MessageBox.Show("刀杆类型不能为空");
                return false;
            }

            if (txtDescTypeName.Text.Equals(""))
            {
                MessageBox.Show("刀片类型不能为空");
                return false;
            }
            return true;
        }



        void btnSrcType_Click(object sender, EventArgs e)
        {
            if (this.frmSrcPrdType == null)
            {
                this.frmSrcPrdType = new JERPApp.Define.Product.FrmManuPrdType(); ;

                new FrmStyle(this.frmSrcPrdType).SetPopFrmStyle(this);
                this.frmSrcPrdType.AffterSelected += frmSrcPrdType_AffterSelected;
            }
            this.frmSrcPrdType.ShowDialog();
        }

        void frmSrcPrdType_AffterSelected()
        {
            int prdTypeId = this.frmSrcPrdType.PrdTypeID;
            String prdYyprName = this.frmSrcPrdType.PrdTypeName;
            txtSrcTypeName.Text = prdYyprName;
            txtSrcTypeID.Text =prdTypeId +  "";
            frmSrcPrdType.Close();
        }

        void btnDescType_Click(object sender, EventArgs e)
        {
            if (this.frmDescPrdType == null)
            {
                this.frmDescPrdType = new JERPApp.Define.Product.FrmManuPrdType();
                new FrmStyle(this.frmDescPrdType).SetPopFrmStyle(this);
                this.frmDescPrdType.AffterSelected += frmDescPrdType_AffterSelected;
            }
            this.frmDescPrdType.ShowDialog();
        }

        void frmDescPrdType_AffterSelected()
        {
            int prdTypeId = this.frmDescPrdType.PrdTypeID;
            String prdYyprName = this.frmDescPrdType.PrdTypeName;
            txtDescTypeName.Text = prdYyprName;
            txtDescTypeID.Text = prdTypeId + "";
            frmDescPrdType.Close();
        }
    }
}
