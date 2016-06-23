using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Engineer.Tool
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
         
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Tool.Product();
            this.accPositons = new JERPData.Tool.Position();
            this.frmFileBrowse = new JCommon.FrmFileBrowse();
            this.accPrdType = new JERPData.Tool.PrdType();
            this.accUnits = new JERPData.General.Unit();
            new FrmStyle(this.frmFileBrowse).SetPopFrmStyle(this);
            this.frmImgBrowse = new JCommon.FrmImgBrowse();
            new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
            this.SetPermit();
        }
        private JERPData.Tool .Product  accPrds;
        private JERPData.Tool .Position accPositons;
        private JERPData.General.Unit accUnits;
        private JERPData.Tool.PrdType accPrdType;
        private JERPApp.Define.Tool.FrmPosition frmPosition;
        
        private JCommon.FrmExcelImport frmImport;
        private DataTable dtblPrds,dtblPrdType,dtblPosition,dtblUnit;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private bool enableBrowse = false;
        private bool enableSave = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(405);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(406);
            if (this.enableBrowse)
            {
                this.ctrlQFind .SeachGridView = this.dgrdv ;               
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
                this.ctrlPrdTypeID.InsertAllRowFlag = true;
                this.SetDataSrc();
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
            }
            this.btnSave .Enabled  = this.enableSave;
            this.frmFileBrowse.ReadOnly = !this.enableSave;
            this.frmImgBrowse.ReadOnly = !this.enableSave;           
            if (this.enableSave)
            {
                this.ctrlPrdTypeID.AllowDefine();
                this.ctrlPrdTypeID.AffterRefreshData+= this.SetDataSrc ;
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnSave .Click += new EventHandler(btnSave_Click);              
            }
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.CurrentRow.IsNewRow) return;
            object objPrdID = this.dtblPrds.DefaultView[irow]["PrdID"];
            if (objPrdID == DBNull.Value) return;
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnFile.Name)
            {
                string filedir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\ToolFlie\"+objPrdID .ToString ();
                if (!Directory.Exists(filedir))
                {
                    Directory.CreateDirectory(filedir);
                }    
                this.frmFileBrowse.Browse(filedir);
                this.frmFileBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = this.frmFileBrowse.Count;
                this.accPrds.UpdateProductForFileCount(ref errormsg,
                    objPrdID,
                    this.frmFileBrowse.Count);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnImg.Name)
            {
                string imgdir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\ToolImg\" + objPrdID.ToString();
                if (!Directory.Exists(imgdir))
                {
                    Directory.CreateDirectory(imgdir);
                }
                this.frmImgBrowse.Browse(imgdir);
                this.frmImgBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = this.frmImgBrowse .Count;
                this.accPrds.UpdateProductForImgCount(ref errormsg,
                    objPrdID,
                    this.frmImgBrowse.Count);
            }

        }
        private void LoadData()
        {
            if (this.ctrlPrdTypeID.PrdTypeID == -1)
            {
                this.dtblPrds  = this.accPrds.GetDataProduct().Tables[0];
            }
            else
            {
                this.dtblPrds = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            } 
            this.dtblPrds.Columns["PrdTypeID"].AllowDBNull = false;
            this.dtblPrds.Columns["PrdCode"].AllowDBNull =false;
            this.dtblPrds.Columns["PrdCode"].Unique  = true;
            this.dtblPrds.Columns["StopFlag"].DefaultValue = false;
            this.dtblPrds.Columns["UnitID"].DefaultValue  = 1;
            this.dgrdv.DataSource = this.dtblPrds;
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            if (irow == this.dgrdv.Rows.Count - 1) return;
            bool flag = false;
            DataRow drow = this.dtblPrds .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdID"] == DBNull.Value)
            {
                return;
            }          
            DialogResult rul = MessageBox.Show("你的删除将不能恢复,不建议此种操作，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPrds.DeleteProduct  (ref ErrorMsg,
                    drow["PrdID"]);
                if (!flag)
                {
                    MessageBox.Show(ErrorMsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PositionID")
            {
                if (frmPosition == null)
                {
                    this.frmPosition = new JERPApp.Define.Tool.FrmPosition();
                    new FrmStyle(this.frmPosition).SetPopFrmStyle(this);
                    this.frmPosition.AffterSave += this.SetDataSrc;
                }
                frmPosition.ShowDialog();
            }
           
        } 
        private void SetDataSrc()
        {

            this.dtblPrdType = this.accPrdType.GetDataPrdType().Tables[0];
            this.ColumnPrdTypeID.DataSource = this.dtblPrdType;
            this.ColumnPrdTypeID.ValueMember = "PrdTypeID";
            this.ColumnPrdTypeID.DisplayMember = "PrdTypeName";


            this.dtblPosition = this.accPositons.GetDataPosition().Tables[0];
            this.ColumnPostionID.DataSource = this.dtblPosition;
            this.ColumnPostionID.ValueMember = "PositionID";
            this.ColumnPostionID.DisplayMember = "PositionName";

            this.dtblUnit = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitName.DataSource = this.dtblUnit;
            this.ColumnUnitName.ValueMember = "UnitID";
            this.ColumnUnitName.DisplayMember = "UnitName";
        }
        private int GetPrdID(string PrdCode)
        {
            int PrdID = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref PrdID);
            return PrdID;
        }
        private int  GetUnitID(string UnitName)
        {
            int UnitID = -1;
            this.accUnits.GetParmUnitUnitID(ref UnitID, UnitName);
            return UnitID;
        }
        private object GetPositionID(string PositionName)
        {
            object objPositionID = DBNull.Value;
            DataRow[] drows = this.dtblPosition.Select("PositionName='" + PositionName + "'");
            if (drows.Length > 0)
            {
                objPositionID = drows[0]["PositionID"];
            }
            return objPositionID;
        }
        private int GetPrdTypeID(string PrdTypeName)
        {

            DataRow[] drows = this.dtblPrdType.Select("PrdTypeName='" + PrdTypeName + "'");
            if (drows.Length > 0)
            {
                return (int)drows[0]["PrdTypeID"];
            }
            else
            {
                object objPrdTypeID = DBNull.Value;
                string errormsg = string.Empty;
                this.accPrdType.InsertPrdType(ref errormsg, ref objPrdTypeID, PrdTypeName);
                this.SetDataSrc ();
                return (int)objPrdTypeID;
            }

        }
        private bool GetBool(string BoolInfor)
        {
            return (BoolInfor == "是");
        }
       

        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {
                    new DataColumn ("类型",typeof (string)),
                    new DataColumn ("治具编号",typeof (string)),
                    new DataColumn ("治具名称",typeof (string)),
                    new DataColumn ("治具规格",typeof (string)),                    
                    new DataColumn ("单位",typeof (string)),
                    new DataColumn ("品牌",typeof (string)),  
                    new DataColumn ("联系人",typeof (string)),   
                    new DataColumn ("责任人",typeof (string)),
                    new DataColumn ("量产时间",typeof (DateTime)),
                    new DataColumn ("位置",typeof (string)),  
                    new DataColumn ("最大产量",typeof (decimal)),   
                    new DataColumn ("保养参数",typeof (decimal)),
                    new DataColumn ("生产累积",typeof (decimal)),  
                    new DataColumn ("保养后产量",typeof (decimal)),   
                    new DataColumn ("保养次数",typeof (int)),   
                    new DataColumn ("停产",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "治具编号不能为空，且不能重复");
            }
            this.frmImport.ShowDialog();

        }

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            //检查一下有没有这个简称
            int PrdID = this.GetPrdID(drow["治具编号"].ToString());
            if (PrdID == -1)
            {
                msg = "此治具编号已存在";
                flag = false;
                return;
            }
            DataRow[] drows = this.dtblPrds.Select("PrdCode='" + drow["治具编号"].ToString() + "'");
            if (drows.Length > 0)
            {
                msg = "此治具编号已存在";
                flag = false;
                return;
            }
            DataRow drowNew = this.dtblPrds.NewRow();
            int PrdTypeID = this.GetPrdTypeID(drow["类型"].ToString());
            drow["PrdTypeID"] = PrdTypeID;
            drowNew["PrdCode"] = drow["治具编号"];
            drowNew["PrdName"] = drow["治具名称"];
            drowNew["PrdSpec"] = drow["治具规格"];
            drowNew["UnitID"] = this.GetUnitID(drow["单位"].ToString());
            drowNew["Manufacturer"] = drow["品牌"];
            drowNew["ContactInfor"] = drow["联系人"];
            drowNew["ResponsiblePsnName"] = drow["责任人"];
            drowNew["DateBatch"] = drow["量产时间"];
            drowNew["PositionID"] = this.GetPositionID (drow["位置"].ToString ());
            drowNew["MaxManufQty"] = drow["最大产量"];
            drowNew["MaxRepairQty"] = drow["保养参数"];
            drowNew["ManufQty"] = drow["生产累积"];
            drowNew["RepairedQty"] = drow["保养后产量"];
            drowNew["RepairedCnt"] = drow["保养次数"];
            drowNew["StopFlag"] = this.GetBool (drow["停产"].ToString ());
            this.dtblPrds.Rows.Add(drowNew);
        }
    
      
        void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult rul = MessageBox.Show("你将对设置进行保存，请确认！", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;        
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblPrds .Rows )
            {
                if (drow.RowState == DataRowState.Unchanged) continue;     
                int OtherPrdID=this.GetPrdID(drow["PrdCode"].ToString());
                object objPrdID =drow["PrdID"];
                if (objPrdID == DBNull.Value)
                {

                    if (OtherPrdID > -1)
                    {
                        drow.RowError = "已存在此治具编号";
                        continue;
                    }
                    flag = this.accPrds.InsertProduct (ref errormsg,
                        ref objPrdID,
                        drow["PrdTypeID"],
                        drow["PrdCode"],
                        drow["PrdName"],
                        drow["PrdSpec"],
                        drow["UnitID"],
                        drow["Manufacturer"],
                        drow["ContactInfor"],
                        drow["ResponsiblePsnName"],
                        drow["DateBatch"],
                        drow["PositionID"],
                        drow["MaxManufQty"],
                        drow["MaxRepairQty"],
                        drow["ManufQty"],
                        drow["RepairedQty"],
                        drow["RepairedCnt"],
                        drow["StopFlag"]);
                    if (flag)
                    {
                        drow["PrdID"] = objPrdID;
                    }
                }
                else
                {
                    if (((int)objPrdID != OtherPrdID)&&(OtherPrdID >-1))
                    {
                        drow.RowError = "已存在此治具编号";
                        continue;
                    }
                    flag =this.accPrds.UpdateProduct(
                        ref errormsg ,
                        objPrdID ,
                        drow["PrdTypeID"],
                        drow["PrdCode"],
                        drow["PrdName"],
                        drow["PrdSpec"],
                        drow["UnitID"],
                        drow["Manufacturer"],
                        drow["ContactInfor"],
                        drow["ResponsiblePsnName"],
                        drow["DateBatch"],
                        drow["PositionID"],
                        drow["MaxManufQty"],
                        drow["MaxRepairQty"],
                        drow["ManufQty"],
                        drow["RepairedQty"],
                        drow["RepairedCnt"],
                        drow["StopFlag"]);
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
            MessageBox.Show("成功保存治具信息");
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "治具一览表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}