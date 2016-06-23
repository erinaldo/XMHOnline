using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Product
{
    public partial class FrmBuyFineAMTOper : Form
    {
        public FrmBuyFineAMTOper()
        {
            InitializeComponent();
            this.accFineNote = new JERPData.Product.BuyFineAMTNotes();
            this.NoteEntity = new JERPBiz.Product.BuyFineAMTNoteEntity();
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Product.BuyFineAMTNotes accFineNote;
        private JERPBiz.Product.BuyFineAMTNoteEntity NoteEntity;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
                this.btnDelete.Enabled = (value > -1);
                this.dtpDateNote.Enabled = (value == -1);
            }
        }
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
        public  void New()
        {
            this.NoteID = -1;
            this.txtNoteCode.Text = string.Empty;
            this.txtAmount.Text = string.Empty;
            this.rchSummary.Text = string.Empty;
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity .LoadData (NoteID );
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlSupplierID.CompanyID = this.NoteEntity.CompanyID;
            this.ctrlMoneyTypeID.MoneyTypeID = this.NoteEntity.MoneyTypeID;
            this.txtAmount.Text = string.Format("{0:0.####}", this.NoteEntity.Amount);
            this.rchSummary.Text = this.NoteEntity.Summary;
        }
        private bool ValidateData()
        {
            if (this.ctrlSupplierID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空!");
                return false;
            }
            if (this.ctrlMoneyTypeID .MoneyTypeID == -1)
            {
                MessageBox.Show("币种不能为空!");
                return false;
            }
            decimal Amount;
            if (!decimal.TryParse(this.txtAmount.Text, out Amount))
            {
                MessageBox.Show("扣款金额输入有误");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                DialogResult rut = MessageBox.Show("将对扣款单进行新增，一经新增,日期不能变更?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.No) return;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accFineNote.InsertBuyFineAMTNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value.Date,
                    this.ctrlSupplierID.CompanyID,
                    this.ctrlMoneyTypeID.MoneyTypeID,
                    this.txtAmount.Text,
                    this.rchSummary.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }
            }
            else
            {
                flag=this.accFineNote .UpdateBuyFineAMTNotes (ref errormsg ,
                    this.NoteID ,
                    this.ctrlSupplierID .CompanyID ,
                    this.ctrlMoneyTypeID .MoneyTypeID ,
                    this.txtAmount.Text,
                    this.rchSummary.Text,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (flag)
            {
             
                if (this.affterSave != null) this.affterSave();
                DialogResult rut = MessageBox.Show("成功进行扣款保存,是否进行打印输出?", "输出确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.Yes)
                {
                    Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
                    excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"FineAMTNote.xlt");
                    excel.SetCellVal("B3", this.ctrlSupplierID .CompanyAllName );
                    excel.SetCellVal("B4", this.txtNoteCode .Text );
                    excel.SetCellVal("D4", this.dtpDateNote.Value.Date);

                    excel.SetCellVal("B5", this.txtAmount .Text );
                    excel.SetCellVal("C5", this.ctrlMoneyTypeID.MoneyTypeName);
                    excel.SetCellVal("E5", JERPBiz .Frame.UserBiz .PsnName );
                    excel.SetCellVal("B6", this.rchSummary .Text );
                    excel.Show();
                }
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("将对当前扣款单进行删除，一经删除不能恢复", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            string errormsg=string .Empty ;
            bool flag = this.accFineNote.DeleteBuyFineAMTNotes(
                ref errormsg,
                this.NoteID);
            if (flag)
            {
                MessageBox.Show("成功删除当前扣款单!");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}