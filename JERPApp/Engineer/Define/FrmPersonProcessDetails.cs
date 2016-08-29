using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Define
{
    public partial class FrmPersonProcessDetails : Form
    {

        public FrmPersonProcessDetails()
        {
            InitializeComponent();
            this.dgrdvItems.AutoGenerateColumns = false;
            this.accProcessNew = new JERPData.Product.ProcessNew();
            this.accPersonDayWorkinghour = new JERPData.Product.PersonDayWorkinghour();
        }

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存

        private JERPData.Product.PersonDayWorkinghour accPersonDayWorkinghour;
        private JERPData.Product.ProcessNew accProcessNew;


        private DataTable dtblPersonDayWorkinghourNotes;
        private DataTable dtbliniPersonDayWorkinghourItems, dtblPersonDayWorkinghourItems;
        private DataTable dtblProcessNew;

        private JERPApp.Define.Manufacture.FrmFinishedProcessNew frmAddProess;


        public String PsnName {
            get { return this.lblPsnName.Text; }
            set { this.lblPsnName.Text = value; }
        }

        public long sWorkingDayID{
            get {return long.Parse(this.lblWorkingDayID.Text) ;}
            set {this.lblWorkingDayID.Text = value.ToString(); }
            
        }

        private void FrmPersonProcessDetails_Load(object sender, EventArgs e)
        {
            this.SetPermit();
        }

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(100);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(101);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
                this.btnCancle.Click += new EventHandler(btnCancle_Close);
            }

            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnSel.Click += new EventHandler(btnSel_Click);
                this.dgrdvItems.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvItem_UserDeletingRow);

            }
        }

        private void btnCancle_Close(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
                 Boolean flag = false;
                 Object workingDayID = lblWorkingDayID.Text;
                 String errormsg = String.Empty;
                foreach (DataRow drow in this.dtblPersonDayWorkinghourItems.Rows)
                {
                    if (drow.RowState == DataRowState.Deleted)
                    {
                        Object ItemID = drow["ItemID", DataRowVersion.Original];//获取已删除值的写法    
                        flag = this.accPersonDayWorkinghour.DeletePersonDayWorkinghourItems(ref errormsg, ItemID, workingDayID);
                            if (!flag)
                            {
                                MessageBox.Show(errormsg);
                            }
                        continue;
                    }
                    if (drow.RowState == DataRowState.Unchanged) continue;
                    this.SaveRow(drow);
                    drow.AcceptChanges();
                }
                MessageBox.Show("成功保存"); 

        }

        private Boolean ValidateData() {
            return true;
        }
        //保存
        private void SaveRow(DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;

            object objItemID = drow["ItemID"];
            Object workingDayID = lblWorkingDayID.Text;
            //再新增表体
            if (objItemID == DBNull.Value)
            {
                flag = this.accPersonDayWorkinghour.InsertPersonDayWorkinghourItems(
                  ref errormsg,
                  ref  objItemID,
                  workingDayID,
                  drow["ProcessTempIndex"],
                  drow["ProcessID"],
                  drow["ModeMachineTime"],
                  2,
                  drow["TimeCost"],
                  drow["MoneyCost"],
                  drow["TimeCount"],
                  drow["TotalTimeCost"],
                  drow["TotalMoneyCost"],
                  drow["ProcessMemo"]
                  );
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
                flag = this.accPersonDayWorkinghour.UpdatePersonDayWorkinghourItems(
                        ref errormsg,
                        objItemID,
                        workingDayID,
                        drow["ProcessTempIndex"],
                        drow["ProcessID"],
                        drow["ModeMachineTime"],
                        2,
                        drow["TimeCost"],
                        drow["MoneyCost"],
                        drow["TimeCount"],
                        drow["TotalTimeCost"],
                        drow["TotalMoneyCost"],
                        drow["ProcessMemo"]
                        );
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
        }
        private void dgrdvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
           this.Close();
        }



        private void LoadData()
        {
            long WorkingDayID = long.Parse(this.lblWorkingDayID.Text);
            this.dtbliniPersonDayWorkinghourItems = this.accPersonDayWorkinghour.GetDataPersonDayWorkinghourItemsByWorkingDayID(WorkingDayID).Tables[0];
            this.dtblPersonDayWorkinghourItems = this.dtbliniPersonDayWorkinghourItems.Copy();
            this.dgrdvItems.DataSource = this.dtblPersonDayWorkinghourItems;
        }



        private void SetColumnSrc()
        {
            this.dtblProcessNew = this.accProcessNew.GetDataProcessNew().Tables[0];
            this.ProcessID.DataSource = this.dtblProcessNew;
            this.ProcessID.ValueMember = "ProcessID";
            this.ProcessID.DisplayMember = "ProcessName";
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
            //可以重复
            //int ItemID = (int)drow["ItemID"];

            //if (this.dtblPersonDayWorkinghourItems != null)
            //{
            //    if (this.dtblPersonDayWorkinghourItems.Select("ItemID=" + ItemID.ToString(), "", DataViewRowState.CurrentRows).Length > 0) return;
            //}
            DataRow drowNew = this.dtblPersonDayWorkinghourItems.NewRow();
            drowNew["WorkingDayID"] = lblWorkingDayID.Text;
            drowNew["ProcessID"] = drow["ProcessID"];

            drowNew["ProcessTempIndex"] = this.dtblPersonDayWorkinghourItems.Rows.Count + 1;

            drowNew["ProcessName"] = drow["ProcessName"];
            drowNew["MachineProcessName"] = drow["MachineProcessName"];
            drowNew["ModelProcessName"] = drow["ModelProcessName"];
            drowNew["ToolProcessName"] = drow["ToolProcessName"];


            drowNew["ModeMachineTime"] = drow["ModeMachineTime"];
            drowNew["TimeCost"] = drow["TimeCost"];
            drowNew["MoneyCost"] = drow["MoneyCost"];
            drowNew["ProcessMemo"] = drow["ProcessMemo"];
            this.dtblPersonDayWorkinghourItems.Rows.Add(drowNew);
        }

    }
}
