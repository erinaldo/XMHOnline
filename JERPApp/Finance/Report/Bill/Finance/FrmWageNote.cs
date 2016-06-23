using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report.Bill
{
    public partial class FrmWageNote : Form
    {
        public FrmWageNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Finance.WageItems();
            this.NoteEntity = new JERPBiz.Finance.WageNoteEntity();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.accBasicWages = new JERPData.Finance.BasicWages();
            this.accOtherItems = new JERPData.Finance.WageOtherItems();
            this.CreateColumn();
            this.btnExport .Click +=new EventHandler(btnExport_Click);
        }        
        private JERPData.Finance.WageItems accItems;
        private JERPBiz.Finance.WageNoteEntity NoteEntity;
        private JERPData.Finance.OtherWageType accWageType;
        private JERPData.Finance.BasicWages accBasicWages;
        private JERPData.Finance.WageOtherItems accOtherItems;
        private DataTable dtblItems,dtblWageType;
        private void CreateColumn()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            DataGridViewTextBoxColumn txtcol;          
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = drow["WageTypeName"].ToString();
                txtcol.HeaderText = drow["WageTypeName"].ToString();
                txtcol.DefaultCellStyle.Format = "0.#####"; 
                this.dgrdv.Columns.Add(txtcol);
            }
            txtcol = new DataGridViewTextBoxColumn();
            txtcol.Width = 60;
            txtcol.DataPropertyName = "TotalWage";
            txtcol.HeaderText = "合计";
            txtcol.DefaultCellStyle.Format  = "0.#####";      
            this.dgrdv.Columns.Add(txtcol);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
       
        public void Detail(long NoteID)
        {
            this.NoteEntity.LoadData(NoteID);
            this.txtYear .Text  = this.NoteEntity.Year.ToString ();
            this.txtMonth .Text  = this.NoteEntity.Month.ToString ();
            this.txtDateBegin.Text  = this.NoteEntity.DateBegin.ToShortDateString ();
            this.txtDateEnd.Text = this.NoteEntity.DateEnd.ToShortDateString ();
            this.dtblItems = this.accItems.GetDataWageItemsPivotWageTypeByNoteID (NoteID).Tables[0];         
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.txtYear .Text +"年"+this.txtMonth .Text+ "月工资表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.SetCellVal("A1", "起始日期:" + this.txtDateBegin .Text  + " 截止日期:" + this.txtDateEnd .Text );
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}