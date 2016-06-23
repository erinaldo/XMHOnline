using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmInstruct : Form 
    {
        public FrmInstruct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accInstruct = new JERPData.Manufacture.Instruct();
            this.accWorkgroup = new JERPData.Manufacture.Workgroup();
            this.accSchedules = new JERPData.Manufacture.ManufSchedules();
            this.printhelper = new JERPBiz.Manufacture.InstructPrintHelper();         
            for (int j = 0; j < iGrid; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
                this.dgrdv.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.SetPermit();
        }

     
        private JERPData.Manufacture.Workgroup  accWorkgroup;
        private JERPData.Manufacture.Instruct accInstruct;
        private JERPData.Manufacture.ManufSchedules accSchedules;
        private JERPBiz.Manufacture.InstructPrintHelper printhelper;
        private DataTable dtblWorkgroup, dtblInstruct; 
        private int iGrid = 8;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(655);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(656);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }
            this.btnSave.Enabled = this.enableSave; 
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
        }

     
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData ();
        } 
       
        private void Export()
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            printhelper.ExportToExcel();
            FrmMsg.Hide();

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }
        private void LoadData()
        {
          
            this.dtblWorkgroup = this.accWorkgroup .GetDataWorkgroup ().Tables[0];
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            DataGridViewTextBoxColumn txt;
            foreach (DataRow drow in this.dtblWorkgroup.Rows)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.Name ="ColumnQ"+ drow["WorkgroupID"].ToString();
                txt.DataPropertyName = "Q" + drow["WorkgroupID"].ToString();
                txt.Tag = drow["WorkgroupID"];
                txt.HeaderText = drow["WorkgroupName"].ToString();
                txt.Width = 66;
                txt.SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dgrdv.Columns.Add(txt);

                txt = new DataGridViewTextBoxColumn();
                txt.Name ="ColumnH" + drow["WorkgroupID"].ToString();
                txt.DataPropertyName = "H" + drow["WorkgroupID"].ToString();
                txt.Tag = drow["WorkgroupID"];
                txt.HeaderText = drow["WorkgroupName"].ToString();
                txt.Width = 66;
                txt.Visible = false;

                this.dgrdv.Columns.Add(txt);
            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dtblInstruct = this.accInstruct.GetDataInstructForSetting().Tables[0];
            if (this.dtblInstruct.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblInstruct.NewRow();
                drowNew["WorkingSheetCode"] = "合计数量";
                this.dtblInstruct.Rows.InsertAt(drowNew, 0);
                drowNew = this.dtblInstruct.NewRow();
                drowNew["WorkingSheetCode"] = "合计用时";                 
                this.dtblInstruct.Rows.InsertAt(drowNew, 0);
                this.SetTotalInfor();
            }
            this.dgrdv.DataSource = this.dtblInstruct; 
          

        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            if (this.dgrdv.RowCount > 2)
            {
                for (int j = iGrid; j < this.dgrdv.ColumnCount; j++)
                {
                    this.dgrdv[j, 0].ReadOnly = true;
                    this.dgrdv[j, 1].ReadOnly = true; 
                    this.dgrdv[j, 0].Style.ForeColor = Color.Red  ; 
                    this.dgrdv[j, 1].Style.ForeColor = Color.Red  ;
                }
                this.dgrdv.Rows[1].Frozen = true;
            }

            for (int irow = 2; irow < this.dgrdv.Rows.Count; irow++)
            {
                foreach (DataRow drowWorkgroup in this.dtblWorkgroup.Rows)
                {
                    if (this.dgrdv["ColumnH" + drowWorkgroup["WorkgroupID"].ToString(), irow].Value == DBNull.Value)
                    {
                        this.dgrdv["ColumnQ" + drowWorkgroup["WorkgroupID"].ToString(), irow].ReadOnly = true;
                        this.dgrdv["ColumnQ" + drowWorkgroup["WorkgroupID"].ToString(), irow].Style.BackColor = SystemColors.ControlDark ;
                    }
                     
                       
                    
                }
            } 
        }

        void SetTotalInfor()
        {
            //总数量
            string columnname = string.Empty;
            DataRow drow0 = this.dtblInstruct.Rows[0];
            DataRow drow1 = this.dtblInstruct.Rows[1];
            drow0["NonFinishedQty"] = this.dtblInstruct.Compute ("SUM(NonFinishedQty)", "ManufScheduleID is not null");
            drow0["Q0"] = this.dtblInstruct.Compute("SUM(Q0)", "ManufScheduleID is not null");
            drow1["NonFinishedQty"] = drow0["NonFinishedQty"];
            drow1["Q0"] = drow0["Q0"];
            DataRow[] drows;
            foreach (DataRow drowWorkgroup in this.dtblWorkgroup.Rows)
            {
                columnname = drowWorkgroup["WorkgroupID"].ToString();
                drow1["Q" + columnname] = this.dtblInstruct.Compute("SUM(Q" + columnname + ")", "ManufScheduleID is not null");
                drows = this.dtblInstruct.Select("ManufScheduleID is not null and Q" + columnname + ">0 and H" + columnname + ">0");
                decimal Hour = 0;
                foreach (DataRow drow in drows)
                {
                    Hour += (decimal)drow["Q" + columnname] / (decimal)drow["H" + columnname];
                }
                drow0["Q" + columnname] = Hour;
            }
        }
      
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow< 2) || (icol == -1)) return;
            if (icol >= iGrid)
            {
                decimal Qty = 0;
                foreach (DataRow drowWorkgroup in this.dtblWorkgroup.Rows)
                { 
                    object objQty = this.dgrdv["ColumnQ"+drowWorkgroup["WorkgroupID"].ToString (), irow].Value;
                    if (objQty != DBNull.Value)
                    {
                        Qty += (decimal)objQty;
                    }
                }
                this.dgrdv[this.ColumnQ0.Name, irow].Value = Qty;
            }
            this.SetTotalInfor();
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在保存中，请稍候....");
            string errormsg=string.Empty ;
            string columnname = string.Empty;
            foreach (DataRow drow in this.dtblInstruct.Rows)
            {

                if (drow.RowState == DataRowState.Unchanged) continue;
                if(drow["ManufScheduleID"]==DBNull .Value )continue ;
                foreach (DataRow drowColumn in this.dtblWorkgroup.Rows)
                {
                    columnname = drowColumn["WorkgroupID"].ToString();
                    this.accInstruct.SaveInstruct(ref errormsg,
                        drow["ManufScheduleID"],
                        columnname,
                        drow["Q"+columnname]);

                }
                drow.AcceptChanges();
            }
            FrmMsg.Hide();
            MessageBox.Show("成功保存当前设置");
        }

    }
}
