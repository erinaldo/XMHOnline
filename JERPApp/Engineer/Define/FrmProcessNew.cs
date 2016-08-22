using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmProcessNew : Form
    {
        public FrmProcessNew()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accToolProcess = new JERPData.Product.ToolProcessTypeNew();
            this.accMachineProcess = new JERPData.Product.MachineProcessTypeNew();
            this.accModelProcess = new JERPData.Product.ModelProcessTypeNew();
            this.accProcessNew = new JERPData.Product.ProcessNew();

            this.SetPermit();
        }

        private JERPData.Product.ToolProcessTypeNew accToolProcess;
        private JERPData.Product.MachineProcessTypeNew accMachineProcess;
        private JERPData.Product.ModelProcessTypeNew accModelProcess;
        private JERPData.Product.ProcessNew accProcessNew;



        private DataTable dtblToolProcess, dtblMachineProcess, dtblModelProcess;
        private DataTable dtbliniProcessNew, dtblProcessNew;

         private JCommon.FrmExcelImport frmImport;

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(96);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(97);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);


            }
            this.btnImport.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;

                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnExport.Click += new EventHandler(btnExport_Click);

            }
        }


        private void SetColumnSrc()
        {
            this.dtblToolProcess = this.accToolProcess.GetDataToolProcessTypeNew().Tables[0];
            this.ToolsID.DataSource = this.dtblToolProcess;
            this.ToolsID.ValueMember = "ToolProcessID";
            this.ToolsID.DisplayMember = "ToolProcessName";


            this.dtblMachineProcess = this.accMachineProcess.GetDataMachineProcessTypeNew().Tables[0];
            this.UseMachineID.DataSource = this.dtblMachineProcess;
            this.UseMachineID.ValueMember = "MachineProcessID";
            this.UseMachineID.DisplayMember = "MachineProcessName";

            this.dtblModelProcess = this.accModelProcess.GetDataModeProcessTypeNew().Tables[0];
            this.ModelID.DataSource = this.dtblModelProcess;
            this.ModelID.ValueMember = "ModelProcessID";
            this.ModelID.DisplayMember = "ModelProcessName";

        }

        private void LoadData()
        {

            this.dtbliniProcessNew = this.accProcessNew.GetDataProcessNew().Tables[0];
            this.dtbliniProcessNew.Columns["ProcessCode"].Unique = true;
            this.dtbliniProcessNew.Columns["ProcessCode"].AllowDBNull = false;
            this.dtbliniProcessNew.Columns["ProcessName"].AllowDBNull = false;

            this.dtblProcessNew = this.dtbliniProcessNew.Copy();
            this.dgrdv.DataSource = this.dtblProcessNew;

        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            foreach (DataRow drow in this.dtblProcessNew.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SaveRow(drow);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存");
        }


        //下拉选择
        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow < 1) || (icol == -1)) return;


            object objToolID = this.dgrdv[this.ToolsID.Name, irow].Value;
            if ((objToolID == null) || (objToolID == DBNull.Value))
            {
                this.dgrdv[this.ToolsID.Name, irow].Value = this.dgrdv[this.ToolsID.Name, irow - 1].Value;
            }

            object UseMachineID = this.dgrdv[this.UseMachineID.Name, irow].Value;
            if ((UseMachineID == null) || (UseMachineID == DBNull.Value))
            {
                this.dgrdv[this.UseMachineID.Name, irow].Value = this.dgrdv[this.UseMachineID.Name, irow - 1].Value;
            }

            object objModelID = this.dgrdv[this.ModelID.Name, irow].Value;
            if ((objModelID == null) || (objModelID == DBNull.Value))
            {
                this.dgrdv[this.ModelID.Name, irow].Value = this.dgrdv[this.ModelID.Name, irow - 1].Value;
            }
        } 

        //查询
        void ctrlQFind_BeforeFilter()
        {
            this.dtblProcessNew = this.dtbliniProcessNew.Copy();
            this.dgrdv.DataSource = this.dtblProcessNew;
        }

        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        //datagrid点击事件
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objID = this.dtblProcessNew.DefaultView[irow]["ProcessID"];
            if ((objID == null) || (objID == DBNull.Value)) return;
            string errormsg = string.Empty;
        }

        //保存
        private void SaveRow( DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;
            int oldId = this.GetID(drow["ProcessCode"].ToString());

            int UseMachineID = -1;
            UseMachineID = GetMachineProcessName(drow["UseMachineID"].ToString());

            int ModelID = -1;
            ModelID = GetModelProcessName(drow["ModelID"].ToString());

            int ToolsID = -1;
            ToolsID = GetToolProcessName(drow["ToolsID"].ToString());

            if (drow["ProcessID"] == DBNull.Value)
            {
                if (oldId > -1)
                {
                    drow.RowError = "对不起，此编号已存在";
                    return;
                }

                object objID = DBNull.Value;
                flag = this.accProcessNew.InsertProcessNew(
                        ref errormsg,
                        ref objID,
                        drow["ProcessCode"],
                        drow["ProcessName"],
                        drow["ModeMachineTime"],
                        drow["TimeCost"],
                        2,
                        UseMachineID,
                        ModelID,
                        ToolsID,
                        drow["MoneyCost"],
                        drow["ConfirmPsnID"],//貌似没用
                        drow["ProcessMemo"]);
                if (flag)
                {
                    drow["ProcessID"] = objID;
                    drow.AcceptChanges();
                    return;
                }

            }
            else
            {

                if ((oldId > -1) && (oldId != (int)drow["ProcessID"]))
                {
                    drow.RowError = "此编号已被使用";
                    return;
                }
                flag = this.accProcessNew.UpdateProcessNew(
                        ref errormsg,
                        drow["ProcessID"],
                        drow["ProcessCode"],
                        drow["ProcessName"],
                        drow["ModeMachineTime"],
                        drow["TimeCost"],
                        drow["TimeTypeID"],
                        UseMachineID,
                        ModelID,
                        ToolsID,
                        drow["MoneyCost"],
                        drow["ProcessMemo"]);
            }
            if (flag)
            {
                drow.AcceptChanges();
            }
            else
            {
                MessageBox.Show(errormsg);
            }

        }

        private int GetID(string ProcessCode)
        {
            int rut = -1;
            this.accProcessNew.GetParmProcessNewProcessID(ProcessCode, ref rut);
            return rut;

        }


        void btnImport_Click(object sender, EventArgs e)
        {

            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {      
                    new DataColumn ("工序代码",typeof (string)),
                    new DataColumn ("工序名称",typeof (string)),              

                    new DataColumn ("调机时间",typeof (string)),              
                    new DataColumn ("人工耗时",typeof (string)),              

                    new DataColumn ("机台",typeof (string)),              
                    new DataColumn ("磨具",typeof (string)),              
                    new DataColumn ("工具",typeof (string)),              

                    new DataColumn ("成本",typeof (string)),              
                    new DataColumn ("备注",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "产品编号不能为空，单位不填默认为PCS,保税料,Rohs填是或不填");
            }
            this.frmImport.ShowDialog();

        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
            FrmMsg.Hide();
        }

        void frmImport_AffterSave()
        {
            this.SetColumnSrc();
        }

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objID = DBNull.Value;

            string UnitName = "PCS";
            if (drow["单位"] != DBNull.Value)
            {
                UnitName = drow["单位"].ToString();
            }
            int PrdID = this.GetID(drow["产品编号"].ToString());
            if (PrdID > -1)
            {
                flag = false;
                msg = "已存在此编号";
                return;
                DataRow drowNew = this.dtblProcessNew.NewRow();
                drowNew["ProcessCode"] = drow["工序代码"];
                drowNew["ProcessName"] = drow["工序名称"];
                drowNew["ModeMachineTime"] = drow["调机时间"];
                drowNew["TimeCost"] = drow["人工耗时"];

                drowNew["UseMachineID"] = drow["机台"];
                drowNew["ModelID"] = drow["磨具"];
                drowNew["ToolsID"] = drow["工具"];

                drowNew["Memo"] = drow["备注"];

                this.dtblProcessNew.Rows.Add(drowNew);
            }
        }
        //机台
        int GetMachineProcessName(String MachineProcessName){
            int MachineProcessID = 1;
            this.accMachineProcess.GetParmMachineProcessByName(MachineProcessName, ref MachineProcessID);
            return MachineProcessID;
        }
        //磨具
        int GetModelProcessName(String ModelProcessName)
         {
             int ModelProcessID = 1;
             this.accModelProcess.GetParmModelProcessByName(ModelProcessName, ref ModelProcessID);
             return ModelProcessID;
            
         }
        //工具
        int GetToolProcessName(String ToolProcessName)
         {
             int ToolProcessID = 1;
             this.accModelProcess.GetParmModelProcessByName(ToolProcessName, ref ToolProcessID);
             return ToolProcessID;
         }

        private bool ValidateData()
        {
            DataRow[] drows = this.dtblProcessNew.Select("ProcessCode is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            drows = this.dtblProcessNew.Select("ProcessName is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("名称不能为空");
                return false;
            }
            return true;
        }

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            DataRow drow = this.dtblProcessNew.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ProcessID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            bool flag = false;
            int ProcessID = (int)drow["ProcessID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accProcessNew.DeleteProcessNew(ref ErrorMsg,
                    ProcessID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                    MessageBox.Show("此记录已被其他业务引用，不能从数据库中删除此单位");
                }
            }
            else
            {
                e.Cancel = true;
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
    }
}
