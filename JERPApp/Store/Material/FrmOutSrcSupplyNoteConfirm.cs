using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcSupplyConfirm : Form
    {
        public FrmOutSrcSupplyConfirm()
        {
            InitializeComponent(); 
            this.dgrdvPlan.AutoGenerateColumns = false; 
            this.accNotes = new JERPData.Material.OutSrcSupplyNotes();
            this.NoteEntity = new JERPBiz.Material.OutSrcSupplyNoteEntity();
            this.printhelper = new JERPBiz.Material.OutSrcSupplyNotePrintHelper();
            this.accSupplyPlans = new JERPData.Material.OutSrcSupplyPlans();
            this.tabMain.Padding = new Point(0); 
            this.btnSave .Click +=new EventHandler(btnSave_Click);  
        }


        
        private JERPData.Material.OutSrcSupplyNotes accNotes;
        private JERPBiz.Material.OutSrcSupplyNoteEntity NoteEntity;
        private JERPBiz.Material.OutSrcSupplyNotePrintHelper printhelper;
        private JERPData.Material.OutSrcSupplyPlans accSupplyPlans;
        private long NoteID = -1;
        private DataTable  dtblSupplyPlans;  
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
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName ;
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtSupplyAddress.Text = this.NoteEntity.SupplierAddress;
            this.dtblSupplyPlans = this.accSupplyPlans .GetDataOutSrcSupplyPlansByNoteID (NoteID ).Tables[0];
            this.dgrdvPlan.DataSource = this.dtblSupplyPlans;
            this.ctrlOutSrcSupplyItem.ConfirmOper(NoteID, this.NoteEntity.NoteCode, this.NoteEntity.CompanyID);
            while (this.tabMain.TabCount > 1)
            {
                this.tabMain.TabPages.RemoveAt(1);
            }
            CtrlOutSrcSupplyRequireConfirm ctrlRequire;
            TabPage page;
            foreach (DataRow drow in this.dtblSupplyPlans.Rows)
            {
                Application.DoEvents(); 
                ctrlRequire = new CtrlOutSrcSupplyRequireConfirm();
                ctrlRequire.ConfirmOper ((long)drow["OutSrcSupplyPlanID"]);
                ctrlRequire.Dock = DockStyle.Fill;
                page = new TabPage();
                page.Text = drow["PONo"].ToString() + "[" + string.Format("{0:0.####}", drow["Quantity"]) + "]";
                page.Controls.Add(ctrlRequire);
                this.tabMain.TabPages.Add(page);
               
            }
        } 
     
       
        void btnSave_Click(object sender, EventArgs e)
        {
            
            if(this.ctrlOutSrcSupplyItem .ValidateData ()==false)return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag =this.accNotes.UpdateOutSrcSupplyNotesForConfirm(ref errormsg,
                this.NoteID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            } 
            //保存总数
            this.ctrlOutSrcSupplyItem.Save (); 
            rul = MessageBox.Show("成功进行发料，需要立即打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                this.printhelper.ExportToExcel(NoteID); 
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
 

    }
}