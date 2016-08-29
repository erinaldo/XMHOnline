using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmManuPersonDayTime : Form
    {
        public FrmManuPersonDayTime()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPersonDayWorkinghour = new JERPData.Product.PersonDayWorkinghour();
            this.accProcessNew = new JERPData.Product.ProcessNew();

            this.SetPermit();
        }


        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private JERPData.Product.PersonDayWorkinghour accPersonDayWorkinghour;
        private JERPData.Product.ProcessNew accProcessNew;


        private DataTable dtblPersonDayWorkinghourNotes;
        private DataTable dtblProcessNew;

        private JERPApp.Define.Hr.FrmPsnSel frmPsnSel;


        private JERPApp.Engineer.Define.FrmPersonProcessDetails frmPersonProcessDetails;

        private int lastRow = 0;


        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(100);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(101);
            if (this.enableBrowse)
            {;
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
                //this.dgrdv.CellClick += new DataGridViewCellEventHandler(dgrdvNotes_CellClick);
                this.dgrdv.ContextMenuStrip = this.cMenu;

            }

            if (this.enableSave)
            {
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnCancle.Click += new EventHandler(btnCancle_Click);
                this.btnAddPerson.Click += new EventHandler(btnAddPerson_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }



        private void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow == -1 || icol == -1) return ;

            DataRow row = this.dtblPersonDayWorkinghourNotes.DefaultView[irow].Row;

            if (this.dgrdv.Columns[icol].Name ==  this.btnProcessDetails.Name) {
                showProcessDetail(row);
            }


        }

        private void showProcessDetail(DataRow row){
            if (frmPersonProcessDetails == null) {
                frmPersonProcessDetails = new JERPApp.Engineer.Define.FrmPersonProcessDetails();
                new FrmStyle(frmPersonProcessDetails).SetPopFrmStyle(this);

            }
            frmPersonProcessDetails.sWorkingDayID = long.Parse(row["WorkingDayID"].ToString());
            frmPersonProcessDetails.PsnName = row["PsnName"].ToString();
            frmPersonProcessDetails.ShowDialog();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (frmPsnSel == null)
            {
                frmPsnSel = new JERPApp.Define.Hr.FrmPsnSel();
                new FrmStyle(frmPsnSel).SetPopFrmStyle(this);
                frmPsnSel.AffterSelected += new JERPApp.Define.Hr.FrmPsnSel.AffterSelectedDelegate(frmPsnSel_AffterSelected);
            }
            frmPsnSel.ShowDialog();
        }


        //查询
        void ctrlQFind_BeforeFilter()
        {
            this.dgrdv.DataSource = this.dtblPersonDayWorkinghourNotes;
        }

        private void mItemRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        private void LoadData()
        {
            this.dtblPersonDayWorkinghourNotes = this.accPersonDayWorkinghour.GetDataPersonDayWorkinghourNotesByWorkDate(this.dtpDateManuf.Value.Date).Tables[0];
            this.dgrdv.DataSource = this.dtblPersonDayWorkinghourNotes;
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            SaveNotes();
        }

        //先保存头
        private void SaveNotes()
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            object objID = DBNull.Value;
            foreach (DataRow drow in this.dtblPersonDayWorkinghourNotes.Rows)
            {
                if (drow.RowState == DataRowState.Deleted)
                {
                    Object WorkingDayID = drow["WorkingDayID", DataRowVersion.Original];//获取已删除值的写法   
                    if (WorkingDayID != DBNull.Value)
                    {
                        flag = this.accPersonDayWorkinghour.DeletePersonDayWorkinghourNotes(ref errormsg, WorkingDayID);
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
         
        }

      //保存
        private void SaveRow(DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;
            Object WorkingDayID = drow["WorkingDayID"];
                //再新增表体
            if (WorkingDayID == DBNull.Value)
            {
                      flag = this.accPersonDayWorkinghour.InsertPersonDayWorkinghourNotes(
                        ref errormsg,
                        ref  WorkingDayID,
                        dtpDateManuf.Value.Date,
                        drow["PsnID"],
                        0,
                        drow["WorkTime"],
                        null,
                        drow["WorkingMemo"]);
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
                flag = this.accPersonDayWorkinghour.UpdatePersonDayWorkinghourNotes(
                       ref errormsg,
                        WorkingDayID,
                        dtpDateManuf.Value.Date,
                        drow["PsnID"],
                        0,
                        drow["WorkTime"],
                        drow["WorkingMemo"]);
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

        //检查
        private bool ValidateData()
        {
            //foreach (DataRow drow in this.dtblPersonDayWorkinghourNotes.Rows)
            //{
                //if (!isNum(drow["WorkTime"])) {
                    //MessageBox.Show(drow["WorkTime"]+ "：时间格式不对，必须为数字");
                    //return false;
                //}
            //}
            return true;
        }

        private void frmPsnSel_AffterSelected(DataRow drow)
        {
            int PsnID = (int)drow["PsnID"];
            if (this.dtblPersonDayWorkinghourNotes != null)
            {
                if (this.dtblPersonDayWorkinghourNotes.Select("PsnID=" + PsnID.ToString(), "", DataViewRowState.CurrentRows).Length > 0) return;
            }
            DataRow drowNew = this.dtblPersonDayWorkinghourNotes.NewRow();
            drowNew["PsnID"] = PsnID;
            drowNew["PsnCode"] = drow["PsnCode"];
            drowNew["PsnName"] = drow["PsnName"];
            drowNew["DeptName"] = drow["DeptName"];
            //drowNew["WorkingMemo"] = drow["WorkingMemo"];
            this.dtblPersonDayWorkinghourNotes.Rows.Add(drowNew);
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

        private Boolean isNum(Object obj) {
            try{
                String strObj = (string)obj;
                int intObjt = int.Parse(strObj); 
            }catch{
                return false;
            }
            return true;
        }

        private void dtpDateManuf_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
