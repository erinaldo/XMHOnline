using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverAlter : Form
    {
        public FrmSaleDeliverAlter()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accNotes = new JERPData.Product.SaleDeliverNotes();
            this.SetPermit();
        }
        private JERPData.Product.SaleDeliverNotes accNotes;
        private FrmSaleDeliverAlterOper frmOper;
        private DataTable dtblNotes;
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(41);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(42);
            if (this.enableBrowse)
            {
                this.whereclause = string.Empty;
                //加载数据
                this.LoadData();
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }          
            this.ColumnbtnAlter.Visible = this.enableSave; 
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

      

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbNoteCode.Checked)
            {
                this.whereclause += " and (NoteCode like '%" + this.txtNoteCode.Text + "%')";
            }
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCompanyID.CompanyID.ToString() + ")";
            }
            if (this.ckbDateNote.Checked)
            {
                this.whereclause += " and (DateNote>='" + this.dtpDateBegin.Value.ToShortDateString() + "' and DateNote<='" + this.dtpDateEnd.Value.Date.ToShortDateString() + "')";
            }
            this.LoadData();
        }
        private void LoadData()
        {
            int recordCount=0;
            this.dtblNotes = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch(1, this.pbar.PageSize,
                ref recordCount, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
            this.pbar.Init(1, recordCount);

        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int recordCount = 0;
            this.dtblNotes = this.accNotes.GetDataSaleDeliverNotesDescPagesFreeSearch(this.pbar .PageIndex , this.pbar.PageSize,
                ref recordCount, this.whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblNotes;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];            
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnAlter.Name)
            {
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmSaleDeliverAlterOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.EditNote(NoteID);
                this.frmOper.ShowDialog();
            }
        }
    }
}