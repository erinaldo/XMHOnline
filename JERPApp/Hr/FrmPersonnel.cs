using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Hr
{
    public partial class FrmPersonnel : Form
    {
        public FrmPersonnel()
        {
            InitializeComponent();
            this.dgrdvOnjob.AutoGenerateColumns = false;
            this.dgrdvOffjob.AutoGenerateColumns = false;
            this.accPsns = new JERPData.Hr.Personnel();
            this.SetPermit();
        }
        private JERPData.Hr.Personnel accPsns;
        private DataTable dtblPsnOnjob,dtblPsnOffjob;
        private JCommon.FrmExcelImport frmImport;
        private JCommon.FrmImgBrowse frmImgBrowse;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(9);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(10);
            if (this.enableBrowse)
            {
                this.ctrlOnjobFind.SeachGridView = this.dgrdvOnjob;
                this.ctrlOffjobFind.SeachGridView = this.dgrdvOffjob;
                this.ctrlOnjobFind.BeforeFilter += this.LoadOnjob;
                this.ctrlOffjobFind.BeforeFilter += this.LoadOffjob;
                this.dgrdvOnjob.ContextMenuStrip = this.cMenu;
                this.dgrdvOffjob.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnExportOnjob.Click+=new EventHandler(btnExportOnjob_Click);
                this.btnExportOutjob.Click += new EventHandler(btnExportOutjob_Click);
                //加载数据
                LoadData();
            }
            this.dgrdvOnjob.AllowUserToAddRows = enableSave;
            this.dgrdvOnjob.ReadOnly = !enableSave;
            this.btnSave.Enabled = this.enableSave;
            this.btnAlter.Enabled = this.enableSave;
            this.btnImport.Enabled = this.enableSave;
            if (this.enableSave)
            { 
                
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdvOffjob.CellContentClick += new DataGridViewCellEventHandler(dgrdvOffjob_CellContentClick);
                this.dgrdvOnjob.CellContentClick += new DataGridViewCellEventHandler(dgrdvOnjob_CellContentClick);
                this.dgrdvOnjob.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvOnjob_UserDeletingRow);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnAlter.Click += new EventHandler(btnAlter_Click);
            }

        
        }



        void dgrdvOnjob_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            object objPsnID = this.dtblPsnOnjob.DefaultView[e.Row.Index]["PsnID"];
            if (objPsnID != DBNull.Value)
            {
                MessageBox.Show("对不起,此人员已保存,不能删除,可以设置为备用");
                e.Cancel = true;
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdvOnjob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;            
            DataRow drow = this.dtblPsnOnjob.DefaultView[irow].Row;
            object objPsnID = drow["PsnID"];
            if ((objPsnID==null)||(objPsnID  == DBNull.Value)) return;
            string errormsg = string.Empty;
            if (this.dgrdvOnjob.Columns[icol].Name == this.ColumnbtnOffjob.Name)
            {
                if(this.dgrdvOnjob .Rows [irow].IsNewRow )return;
                DateTime DateDismiss = DateTime.Now.Date;
                JCommon.FrmSetDateTime.ShowDialog(ref DateDismiss);               
                this.accPsns.UpdatePersonnelForOffjob(ref errormsg,
                    objPsnID, DateDismiss);
                this.dgrdvOnjob.Rows.RemoveAt(irow);
                this.LoadOffjob();
            }
            if (this.dgrdvOnjob.Columns[icol].Name == this.ColumnSignImgCount.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = !this.enableSave;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Hr\SignImg\" + objPsnID.ToString());
                frmImgBrowse.ShowDialog();
                this.dgrdvOnjob[icol, irow].Value = frmImgBrowse.Count;
                this.accPsns .UpdatePersonnelForSignImgCount (ref errormsg,
                    objPsnID,
                    frmImgBrowse.Count);
            }
            if (this.dgrdvOnjob.Columns[icol].Name == this.ColumnPortraitImgCount.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = !this.enableSave;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Hr\PortraitImg\" + objPsnID.ToString());
                frmImgBrowse.ShowDialog();
                this.dgrdvOnjob[icol, irow].Value = frmImgBrowse.Count;
                this.accPsns.UpdatePersonnelForPortraitImgCount (ref errormsg,
                    objPsnID,
                    frmImgBrowse.Count);
            }
        }

        void dgrdvOffjob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvOffjob .Columns[icol].Name == this.ColumnbtnOnjob.Name)
            {
                if (this.dgrdvOffjob.Rows[irow].IsNewRow) return;
                DataRow drow = this.dtblPsnOffjob .DefaultView[irow].Row;
                string errormsg = string.Empty;
                this.accPsns.UpdatePersonnelForOnjob(ref errormsg, drow["PsnID"]);
                this.dgrdvOffjob.Rows.RemoveAt(irow);
                this.dtblPsnOnjob.ImportRow(drow);
                this.LoadOnjob();
            }
        }
        private void LoadOnjob()
        {
            this.dtblPsnOnjob = this.accPsns.GetDataPersonnelOnjob().Tables[0];
            this.dtblPsnOnjob.Columns["PsnName"].AllowDBNull = false;
            this.dgrdvOnjob.DataSource = this.dtblPsnOnjob;
        }
        private void LoadOffjob()
        {
            this.dtblPsnOffjob = this.accPsns.GetDataPersonnelOffjob().Tables[0];
            this.dgrdvOffjob.DataSource = this.dtblPsnOffjob;
        }
        private void LoadData()
        {

            this.LoadOnjob();
            this.LoadOffjob();
         
        }
        private int GetPsnID(string PsnCode)
        {
            int rut = -1;
            this.accPsns.GetParmPersonnelPnsID(PsnCode, ref rut);
            return rut;
        }
        private void SavePsn(DataRow drow)
        {
            bool flag = false;
            string errormsg = string.Empty;
            int psnid = -1;
            object objPsnID = DBNull.Value;
            psnid = this.GetPsnID(drow["PsnCode"].ToString());
            if (drow["PsnID"] == DBNull.Value)
            {
                if (psnid > -1)
                {
                    drow.RowError = "对不起,此工号已存在";
                    return;
                }
                objPsnID = DBNull.Value;
                flag = this.accPsns.InsertPersonnel(
                        ref errormsg,
                        ref objPsnID,
                        drow["PsnCode"],
                        drow["PsnName"],
                        drow["AssistantCode"],
                        drow["Sex"],
                        drow["JobType"],
                        drow["DeptName"],
                        drow["Position"],
                        drow["Nation"],
                        drow["DateHire"],
                        drow["ProbationMonth"],
                        drow["Province"],
                        drow["Diploma"],
                        drow["IDCode"],
                        drow["IDAddress"],
                        drow["BankCode"],
                        drow["BankName"],
                        drow["Telephone"],
                        drow["RoomFlag"],
                        drow["RoomNo"],
                        drow["Description"]);

                if (flag)
                {
                    drow["PsnID"] = objPsnID;
                }

            }
            else
            {
                if ((psnid > -1) && (psnid != (int)drow["PsnID"]))
                {

                    drow.RowError = "对不起,此工号已存在";
                    return;                  

                }
                flag = this.accPsns.UpdatePersonnel(
                        ref errormsg,
                        drow["PsnID"],
                        drow["PsnCode"],
                        drow["PsnName"],
                        drow["AssistantCode"],
                        drow["Sex"],
                        drow["JobType"],
                        drow["DeptName"],
                        drow["Position"],
                        drow["Nation"],
                        drow["DateHire"],
                        drow["ProbationMonth"],
                        drow["Province"],
                        drow["Diploma"],
                        drow["IDCode"],
                        drow["IDAddress"],
                        drow["BankCode"],
                        drow["BankName"],
                        drow["Telephone"],
                        drow["RoomFlag"],
                        drow["RoomNo"],
                        drow["Description"]);

                if (flag)
                {
                    drow.AcceptChanges();
                    drow.RowError = string.Empty;
                }
                else
                {
                    drow.RowError = errormsg;
                }

            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将进行保存,请检查您的输入！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
          
            foreach (DataRow drow in this.dtblPsnOnjob.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SavePsn(drow);
            }
            this.dgrdvOnjob.Refresh();
            MessageBox.Show("成功进行员工保存");
        }

        void btnAlter_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将进行保存,请检查您的输入！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            foreach (DataRow drow in this.dtblPsnOffjob.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SavePsn(drow);
            }
            this.dgrdvOffjob .Refresh();
            MessageBox.Show("成功进行员工保存");
        }
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.AffterSave += this.LoadData;
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {
                    new DataColumn ("类别",typeof (string)),   
                    new DataColumn ("部门",typeof (string)),   
                    new DataColumn ("姓名",typeof (string)),   
                    new DataColumn ("工号",typeof (string)),  
                    new DataColumn ("助记码",typeof (string)), 
                    new DataColumn ("入职时间",typeof (DateTime)),   
                    new DataColumn ("身份证号",typeof (string)),
                    new DataColumn ("居住地",typeof (string)), 
                    new DataColumn ("电话",typeof (string)),  
                    new DataColumn ("性别",typeof (string)),                                     
                    new DataColumn ("学历",typeof (string)),    
                    new DataColumn ("职务",typeof (string)),
                    new DataColumn ("民族",typeof (string)), 
                    new DataColumn ("试用期(月份)",typeof (int)),      
                    new DataColumn ("籍贯",typeof (string)),     
                    new DataColumn ("银行卡号",typeof (string)),
                    new DataColumn ("开户行",typeof (string)),
                    new DataColumn ("住宿",typeof (string)), 
                    new DataColumn ("宿舍号",typeof (string)),
                    new DataColumn ("描述",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "入职时间一定要规范,试用期是月份");
            }
            this.frmImport.ShowDialog();

        }
     
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            if (drow["工号"].ToString() == string.Empty)
            {
                msg = "工号不能为空";
                flag = false;
                return;
            }
            if (drow["姓名"].ToString() == string.Empty)
            {
                msg = "姓名不能为空";
                flag = false;
                return;
            }
            int PsnID = this.GetPsnID(drow["工号"].ToString());
            if (PsnID > -1)
            {
                msg = "此工号已存在";
                flag = false;
                return;
            }
            object objPsnID = DBNull.Value;           
            bool RoomFlag = false;
            if (drow["住宿"].ToString() == "是")
            {
                RoomFlag = true;
            }
            DataRow drowNew = this.dtblPsnOnjob.NewRow();
            drowNew["PsnCode"] = drow["工号"];
            drowNew["PsnName"] = drow["姓名"];
            drowNew["AssistantCode"] = drow["助记码"];
            drowNew["Sex"] = drow["性别"];
            drowNew["JobType"] = drow["类别"];
            drowNew["DeptName"] = drow["部门"];
            drowNew["Position"] = drow["职务"];
            drowNew["Nation"] = drow["民族"];
            drowNew["DateHire"] = drow["入职时间"];
            drowNew["ProbationMonth"] = drow["试用期(月份)"];
            drowNew["Province"] = drow["籍贯"];
            drowNew["Diploma"] = drow["学历"];
            drowNew["IDCode"] = drow["身份证号"];
            drowNew["IDAddress"] = drow["居住地"];
            drowNew["BankCode"] = drow["银行卡号"];
            drowNew["BankName"] = drow["开户行"];
            drowNew["Telephone"] = drow["电话"];
            drowNew["RoomFlag"] = RoomFlag;
            drowNew["RoomNo"] = drow["宿舍号"];
            drowNew["Description"] = drow["描述"];
            this.dtblPsnOnjob.Rows.Add(drowNew);
            

        }

        void btnExportOnjob_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "在职员工");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdvOnjob, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }

        void btnExportOutjob_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "离职员工");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdvOffjob , ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }


    }
}