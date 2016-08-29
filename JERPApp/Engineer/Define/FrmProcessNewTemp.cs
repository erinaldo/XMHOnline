using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmProcessNewTemp : Form
    {
        public FrmProcessNewTemp()
        {
            InitializeComponent();
            this.dgrdvItems.AutoGenerateColumns = false;
            this.accProcessNewTemp = new JERPData.Product.ProcessNewTemp();
            this.accProcessNew = new JERPData.Product.ProcessNew();

            this.SetPermit();
        }

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private JERPData.Product.ProcessNewTemp accProcessNewTemp;
        private JERPData.Product.ProcessNew accProcessNew;


        private DataTable  dtblProcessNewTypeNotes;
        private DataTable dtbliniProcessNewTypeItems, dtblProcessNewTypeItems;
        private DataTable dtblProcessNew;

        private JERPApp.Define.Manufacture.FrmFinishedProcessNew frmAddProess; 

        private  int lastRow = 0 ;

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(98);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(99);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdvNotes;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
                //this.dgrdvNotes.CellContentClick += new DataGridViewCellEventHandler(dgrdvNotes_CellContentClick);
                this.dgrdvNotes.CellClick +=  new DataGridViewCellEventHandler(dgrdvNotes_CellClick);
                this.dgrdvNotes.ContextMenuStrip = this.cMenu;

            }

            if (this.enableSave)
            {
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnDel.Click += new EventHandler(btnDel_Click);
                this.btnSel.Click += new EventHandler(btnSel_Click);
                this.btnAdd.Click += new EventHandler(btnAdd_Click);

                this.dgrdvItems.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvItem_UserDeletingRow);
                this.dgrdvNotes.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvNote_UserDeletingRow);

            }
        }

        private void dgrdvNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            if (lastRow == irow) {
                return;
            }        
            lastRow = irow;
            clearData();//先清空数据
            Object ProcessTempId = this.dgrdvNotes.CurrentRow.Cells["ProcessTempId"].Value;
            loadNotesMain((int)ProcessTempId);
            LoadDataItems((int)ProcessTempId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearData();
        }

        void loadNotesMain(int ProcessTempId)
        {
            DataRow[] drows = dtblProcessNewTypeNotes.Select("ProcessTempId = " + ProcessTempId, "");
            if (drows.Length >0){
                txtProcessTempId.Text = drows[0]["ProcessTempId"].ToString();
                txtProcessTempCode.Text = drows[0]["ProcessTempCode"].ToString();
                txtProcessTempName.Text = drows[0]["ProcessTempName"].ToString();
                txtModeMachineTime.Text = drows[0]["SumModeMachineTime"].ToString();
                txtTimeCost.Text = drows[0]["SumTimeCost"].ToString();
                txtProcessMemo.Text = drows[0]["ProcessMemo"].ToString();
            }
        }

        private void dgrdvNote_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblProcessNewTypeNotes.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;

            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accProcessNewTemp.DeleteProcessTempNewNotes(ref ErrorMsg,
                    drow["ProcessTempId"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
                    return;
                }
                else {
                    flag = this.accProcessNewTemp.DeleteProcessTempNewItems(ref ErrorMsg,
                            drow["ProcessTempId"]);
                    //if (!flag)
                    //{

                    //    MessageBox.Show(ErrorMsg);
                    //    e.Cancel = true;
                    //    return;
                    //}
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgrdvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            Boolean flag = false;
            Object ProcessTempId = txtProcessTempId.Text;
            if (txtProcessTempId.Text.Trim() == "")
            {
                return;
            }
            else {

                flag = accProcessNewTemp.DeleteProcessTempNewNotes(ref errormsg, ProcessTempId);
                if (flag) {
                    flag = accProcessNewTemp.DeleteProcessTempNewItems(ref errormsg, ProcessTempId);
                    if (flag)
                    {
                        MessageBox.Show("删除成功");
                        return;
                    }
                }
                MessageBox.Show("删除失败");
            }
            clearData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            Boolean flag = SaveNotes();
            if (flag)
            {
                foreach (DataRow drow in this.dtblProcessNewTypeItems.Rows)
                {
                    if (drow.RowState == DataRowState.Deleted)
                    {
                        Object ItemID = drow["ItemID", DataRowVersion.Original];//获取已删除值的写法    
                        if (ItemID != DBNull.Value)
                        {
                            string errormsg = string.Empty;
                            Object ProcessTempId = txtProcessTempId.Text.Trim();
                           
                            flag = this.accProcessNewTemp.DeleteProcessTempNewItemsByItemID(ref errormsg, ItemID, ProcessTempId);
                            if (!flag)
                            {
                                MessageBox.Show(errormsg);
                            }  
                        }
                        continue;
                    }
                    if (drow.RowState == DataRowState.Unchanged) continue;
                    this.SaveRow(drow);
                    drow.AcceptChanges();
                }
                MessageBox.Show("成功保存");
                //clearData();
                //LoadDataNotes();
            }

        }

        private bool ValidateData()
        {
            if (txtProcessTempName.Text.Trim().Length < 1) {
                MessageBox.Show("工序模板名称不能为空");
                return false;
            }

            DataRow[] drows = this.dtblProcessNewTypeItems.Select("ProcessID is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("工序不能为空");
                return false;
            }
            return true;
        }

        //先保存头
        private Boolean SaveNotes()
        {
            string errormsg = string.Empty;
            bool flag = false;
            object objID = DBNull.Value;
            if (txtProcessTempId.Text.Trim()=="")
            {
                //先新增表头
                flag = this.accProcessNewTemp.InsertProcessTempNewNotes(
                        ref errormsg,
                        ref objID,
                        txtProcessTempCode.Text.Trim(),
                        txtProcessTempName.Text.Trim(),
                        Double.Parse(txtModeMachineTime.Text.Trim()),
                        2,
                        Double.Parse(txtTimeCost.Text.Trim()),
                        0,
                        txtProcessMemo.Text.Trim());
                if (flag)
                {
                    txtProcessTempId.Text = objID.ToString();
                }
            }else{
                objID = txtProcessTempId.Text.Trim();
                flag = this.accProcessNewTemp.UpdateProcessTempNewNotes(
                        ref errormsg,
                        objID,
                        txtProcessTempCode.Text.Trim(),
                        2,
                        txtProcessTempName.Text.Trim(),
                        Double.Parse(txtModeMachineTime.Text.Trim()),
                        Double.Parse(txtTimeCost.Text.Trim()),
                        0,
                        null,
                        txtProcessMemo.Text.Trim());
            }
            if (!flag){
                MessageBox.Show(errormsg);
            }
            return flag;
        }

        //保存
        private void SaveRow(DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;
            int PeocessId = this.GetProcessID(drow["ProcessID"].ToString());
            object objItemID = drow["ItemID"];

            Object ProcessTempId = txtProcessTempId.Text.Trim();
                //再新增表体
                if (objItemID == DBNull.Value){
                      flag = this.accProcessNewTemp.InsertProcessTempNewItems(
                        ref errormsg,
                        ref  objItemID,
                        ProcessTempId,
                        drow["ProcessTempIndex"],
                        drow["ProcessID"],
                        drow["ModeMachineTime"],
                        2,
                        drow["TimeCost"],
                        drow["MoneyCost"],
                        drow["ProcessMemo"]);
                      if (flag)
                      {
                          drow.AcceptChanges();
                          return;
                      }
                      else
                      {
                          MessageBox.Show(errormsg);
                      }
                }
            else
            {
                flag = this.accProcessNewTemp.UpdateProcessTempNewItems(
                        ref errormsg,
                        objItemID,
                        ProcessTempId,
                        drow["ProcessTempIndex"],
                        drow["ProcessID"],
                        drow["ModeMachineTime"],
                        2,
                        drow["TimeCost"],
                        drow["MoneyCost"],
                        drow["ProcessMemo"]);
                if (flag)
                {
                    drow.AcceptChanges();
                    return;
                }
                else {
                    MessageBox.Show(errormsg);
                }
            } 
        }


        //
        private int GetProcessID(String ProcessName) {
            int ProcessID = -1;
            this.accProcessNew.GetParmProcessNewProcessID(ProcessName,ref ProcessID);
            return ProcessID;

        }


        private void SetColumnSrc() {

            this.dtblProcessNew = this.accProcessNew.GetDataProcessNew().Tables[0];
            this.ProcessID.DataSource = this.dtblProcessNew;
            this.ProcessID.ValueMember = "ProcessID";
            this.ProcessID.DisplayMember = "ProcessName";
        
        }


        private void LoadData(){
            LoadDataNotes();
            int ProcessTempId = -1;
            LoadDataItems(ProcessTempId);
        }

        private void LoadDataNotes()
        {
            this.dtblProcessNewTypeNotes = this.accProcessNewTemp.GetDataProcessTempNewNotes().Tables[0];
            this.dgrdvNotes.DataSource = this.dtblProcessNewTypeNotes;

        }

        private void LoadDataItems(int ProcessTempId)
        {
            this.dtbliniProcessNewTypeItems = this.accProcessNewTemp.GetDataProcessTempNewItemsByProcessTempIdUnion(ProcessTempId).Tables[0];

            this.dtblProcessNewTypeItems = this.dtbliniProcessNewTypeItems.Copy();
            this.dgrdvItems.DataSource = this.dtblProcessNewTypeItems;

        }

        void btnSel_Click(object sender, EventArgs e)
        {
            if (frmAddProess == null)
            {
                frmAddProess = new JERPApp.Define.Manufacture.FrmFinishedProcessNew();
                new FrmStyle(frmAddProess).SetPopFrmStyle(this);
                frmAddProess.AffterSelected += new JERPApp.Define.Manufacture.FrmFinishedProcessNew.AffterSelectedDelegate(frmAddProess_AffterSelected);
            }
            frmAddProess.ShowDialog();
        }

        void frmAddProess_AffterSelected(DataRow drow)
        {
            int ProcessID = (int)drow["ProcessID"];

            if (this.dtblProcessNewTypeItems != null)
            {
                if (this.dtblProcessNewTypeItems.Select("ProcessID=" + ProcessID.ToString(), "", DataViewRowState.CurrentRows).Length > 0) return;
            }
            DataRow drowNew = this.dtblProcessNewTypeItems.NewRow();
            drowNew["ProcessID"] = ProcessID;

            drowNew["ProcessTempIndex"] = this.dtblProcessNewTypeItems.Rows.Count + 1;

            drowNew["ProcessName"] = drow["ProcessName"];
            drowNew["MachineProcessName"] = drow["MachineProcessName"];
            drowNew["ModelProcessName"] = drow["ModelProcessName"];
            drowNew["ToolProcessName"] = drow["ToolProcessName"];


            drowNew["ModeMachineTime"] = drow["ModeMachineTime"];
            drowNew["TimeCost"] = drow["TimeCost"];
            drowNew["MoneyCost"] = drow["MoneyCost"];
            drowNew["ProcessMemo"] = drow["ProcessMemo"];
            this.dtblProcessNewTypeItems.Rows.Add(drowNew);
        }



        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //查询
        void ctrlQFind_BeforeFilter()
        {
            this.dgrdvNotes.DataSource = this.dtblProcessNewTypeNotes;
        }



        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void clearData() {
            txtProcessTempId.Text = "";
            txtProcessTempCode.Text = "";
            txtProcessTempName.Text = "";
            txtModeMachineTime.Text = "0";
            txtTimeCost.Text = "0";
            txtProcessMemo.Text = "";

            //清空数据
            DataTable dt = (DataTable)dgrdvItems.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                this.dtblProcessNewTypeItems = dt;
                dgrdvItems.DataSource = dt;
            }
        }


        //void btnimport_click(object sender, eventargs e)
        //{

        //    if (this.frmimport == null)
        //    {
        //        this.frmimport = new jcommon.frmexcelimport();
        //        new frmstyle(frmimport).setpopfrmstyle(this);
        //        this.frmimport.afftersave += new jcommon.frmexcelimport.afftersavedelegate(frmimport_afftersave);
        //        this.frmimport.importhandle += new jcommon.frmexcelimport.importdelegate(frmimport_importhandle);
        //        datacolumn[] columns = new datacolumn[] {      
        //            new datacolumn ("工序代码",typeof (string)),
        //            new datacolumn ("工序名称",typeof (string)),              

        //            new datacolumn ("调机时间",typeof (string)),              
        //            new datacolumn ("人工耗时",typeof (string)),              

        //            new datacolumn ("机台",typeof (string)),              
        //            new datacolumn ("磨具",typeof (string)),              
        //            new datacolumn ("工具",typeof (string)),              

        //            new datacolumn ("成本",typeof (string)),              
        //            new datacolumn ("备注",typeof (string))
        //        };
        //        this.frmimport.setimportcolumn(columns, "产品编号不能为空，单位不填默认为pcs,保税料,rohs填是或不填");
        //    }
        //    this.frmimport.showdialog();

        //}

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
