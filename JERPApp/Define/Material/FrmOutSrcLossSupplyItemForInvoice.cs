using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Material
{
    public partial class FrmOutSrcLossSupplyItemForInvoice : Form
    {
        public FrmOutSrcLossSupplyItemForInvoice()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.OutSrcLossSupplyItems();
            this.accInvoice = new JERPData.Material.OutSrcLossSupplyInvoices();
            this.ckbFiter.CheckedChanged += new EventHandler(ckbFiter_CheckedChanged);
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

     
        private JERPData.Material.OutSrcLossSupplyItems accItems;
        private JERPData.Material.OutSrcLossSupplyInvoices accInvoice;
        private long InvoiceID=-1;
        private DataTable dtblItems;
        public void InvoiceItem(long InvoiceID,int Year,int Month)
        {
            this.InvoiceID = InvoiceID;
            this.ckbFiter.Checked = false;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            this.LoadData();
           
        }
        private void LoadData()
        {
            this.dtblItems = this.accItems.GetDataOutSrcLossSupplyItemsForInvoice (this.InvoiceID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        private void FiterData()
        {
            
            DataRow[] drows= this.dtblItems.Select("DateNote<'"+this.dtpDateBegin .Value.ToShortDateString ()+"' or DateNote>'"+this.dtpDateEnd .Value .ToShortDateString ()+"'");
            foreach (DataRow drow in drows)
            {
                this.dtblItems.Rows.Remove(drow);
            }
        }

        void ckbFiter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiter.Checked)
            {
                FiterData();
            }
            else
            {
                this.LoadData();
            }
        }

        public delegate void AffterEnterDelegate();
        private AffterEnterDelegate affterEnter;
        public event AffterEnterDelegate AffterEnter
        {
            add
            {
                affterEnter += value;
            }
            remove
            {
                affterEnter -= value;
            }
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblItems.Select("", "", DataViewRowState.CurrentRows))
            {
                flag=this.accItems.UpdateOutSrcLossSupplyItemsForInvoice(ref errormsg,
                    drow["ItemID"], this.InvoiceID);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            if (this.affterEnter != null) this.affterEnter();
            this.Close();
        }

    }
}