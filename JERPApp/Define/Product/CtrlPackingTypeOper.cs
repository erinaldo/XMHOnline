using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Define.Product
{
    public partial class CtrlPackingTypeOper : UserControl
    {
        public CtrlPackingTypeOper()
        {
            InitializeComponent();
            this.accBom = new JERPData.Product.PackingBOM();
            this.prdEntity = new JERPBiz.Product .ProductEntity();
            this.gridhelper = new JCommon.DataGridViewHelper();
            this.accPakingType = new JERPData.Product.PackingType();
            this.PackingTypeEntity = new JERPBiz.Product.PackingTypeEntity();
            this.accSourceType = new JERPData.Product .SourceType();
            this.ctrlFileBrowse.ReadOnly = true;
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrd = new JERPData.Product.Product();
            this.accUnits = new JERPData.General.Unit();
            this.SetColumnSrc();
            new ToolTip().SetToolTip(this.btnRemove, "移除");
           
            this.btnRemove.Click += new EventHandler(btnRemove_Click);
            this.dgrdv.CellPainting += new DataGridViewCellPaintingEventHandler(dgrdv_CellPainting);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click); 
        }

        private JERPBiz.Product.ProductEntity prdEntity;
        private JERPData.Product.PackingBOM  accBom;
        private JERPData.Product.PackingType accPakingType;
        private JERPData.Product .Product   accPrd;
        private JERPData.Product .SourceType accSourceType;
        
        private JERPData.General.Unit accUnits;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;
        private DataTable dtblBom,dtblSourceType;
        private JCommon.FrmExcelImport frmImport;
        private JERPBiz.Product.PackingTypeEntity PackingTypeEntity; 
        private void SetColumnSrc()
        {
          

            this.dtblSourceType = this.accSourceType.GetDataSourceType().Tables[0];
            this.ColumnSourceTypeName.DataSource = this.dtblSourceType;
            this.ColumnSourceTypeName.ValueMember = "SourceTypeID";
            this.ColumnSourceTypeName.DisplayMember = "SourceTypeName";

        }
        private int prdid= -1;
        public int PrdID
        {

            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value; 
                this.dgrdv.AllowUserToDeleteRows = (value > -1);
                this.dgrdv.ReadOnly = (value == -1);
             
                
            }
        }
        private int packingtypeid = -1;
        private int PackingTypeID
        {
            get
            {
                return this.packingtypeid;
            }
            set
            {
                this.packingtypeid = value;
                this.ctrlFileBrowse.ReadOnly = (value == -1);
            }

        }
        private JCommon.DataGridViewHelper gridhelper;
        public void New(int PrdID)
        {
            this.PackingTypeID = -1;
            this.PrdID = PrdID;
            this.txtPackingTypeName.Text ="方案1";
            this.rchDescription.Text = string.Empty;
            this.ctrlFileBrowse.Clear();
            this.LoadBom();
        }
        public void Edit(int PackingTypeID)
        {
            this.PackingTypeID = PackingTypeID;
            this.PackingTypeEntity.LoadData(PackingTypeID);
            this.PrdID = this.PackingTypeEntity.PrdID;       
            this.txtPackingTypeName.Text = this.PackingTypeEntity.PackingTypeName;
            this.rchDescription.Text = this.PackingTypeEntity.Description;
            this.LoadFile();
            this.LoadBom();
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
                || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
                || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
                || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrdAlter == null)
                {
                    frmPrdAlter = new JERPApp.Define.Product .FrmProduct();
                    frmPrdAlter.AllowAppendFlag = true;
                    new FrmStyle(frmPrdAlter).SetPopFrmStyle(this.ParentForm);
                    frmPrdAlter.AffterSelected += frmPrdAlter_AffterSelected;
                }
                frmPrdAlter.ShowDialog();
            }
        }

        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName .Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"]; 
            grow.Cells[this.ColumnUnitName .Name].Value = drow["UnitName"]; 
            this.frmPrdAlter .Close();
        }

    
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmPrd == null)
            {
                frmPrd = new JERPApp.Define.Product .FrmProduct();
                new FrmStyle(frmPrd).SetPopFrmStyle(this.ParentForm);
                frmPrd.AllowAppendFlag = true;
                frmPrd.AffterSelected +=frmPrd_AffterSelected;
            }
            frmPrd.ShowDialog();
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataRow[] drows = this.dtblBom.Select("PrdID=" + drow["PrdID"].ToString());
            if (drows.Length > 0)
            {
                MessageBox.Show("已存在此包材");
                return;
            }
            DataRow drowNew = this.dtblBom.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["PackageAssembly"] = 1;
            drowNew["PrdAssembly"] = 1;
            drowNew["SourceTypeID"] = 2;
            drowNew["RecycleFlag"] =false;
            this.dtblBom.Rows.Add(drowNew);
        }
        private void LoadFile()
        {
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\Packing\" + this.PackingTypeID.ToString();
            this.ctrlFileBrowse.Browse(dir);
        }
        public delegate void AffterRemoveDelegate(object sender);
        private AffterRemoveDelegate affterRemove;
        public event AffterRemoveDelegate AffterRemove
        {
            add
            {
                affterRemove += value;
            }
            remove
            {
                affterRemove -= value;
            }
        }
        private void LoadBom()
        {
            this.dtblBom = this.accBom.GetDataPackingBOMByPackingTypeID(PackingTypeID).Tables[0];
            this.dtblBom.Columns["PrdID"].AllowDBNull = false; 
            this.dtblBom.Columns["PackageAssembly"].AllowDBNull = false;
            this.dtblBom.Columns["PrdAssembly"].AllowDBNull = false;
            this.dtblBom.Columns["RecycleFlag"].DefaultValue  = false;
            this.dtblBom.Columns["SourceTypeID"].DefaultValue = 2;
            this.dgrdv.DataSource = this.dtblBom;   
        }
        void dgrdv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (irow > -1) return;
            if ((icol ==4) || (icol == 5))
            {
                this.gridhelper.MerageColumnHeaderSpan(this.dgrdv, e,4, 5, "用量比");
            }
        }
        public string PackingTypeName
        {
            get
            {
                return this.txtPackingTypeName.Text;
            }
        }

        void btnImport_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            if (this.frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                DataColumn[] columns = new DataColumn[]{        
                    new DataColumn ("包材编号",typeof (string)),    
                    new DataColumn ("包材名称",typeof (string)), 
                    new DataColumn ("包材规格",typeof (string)),    
                    new DataColumn ("单位",typeof (string)),          
                    new DataColumn ("包材用量",typeof (int)),   
                    new DataColumn ("产品用量",typeof (int)),   
                    new DataColumn ("备注",typeof (string)),                 
                    new DataColumn ("位置",typeof (string)),        
                    new DataColumn ("来源",typeof (string)) ,          
                    new DataColumn ("回收",typeof (string))
                };

                frmImport.SetImportColumn(columns, "包材编号不能重,用量>0" +
                    "\n来源方式:采购或客供;");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
            }
            frmImport.ShowDialog();
        }
        void frmImport_AffterSave()
        {
            MessageBox.Show("导入完成,请仔细检查数据,再保存!");
            this.frmImport.Close();
        }
        private bool GetBool(string BoolInfor)
        {
            return (BoolInfor == "是");
        } 
        private int GetSourceTypeID(string SourceTypeName)
        {
            if (SourceTypeName == string.Empty) return 2;
            DataRow[] drows = this.dtblSourceType.Select("SourceTypeName='" + SourceTypeName + "'");
            if (drows.Length > 0)
            {
                return (int)drows[0]["SourceTypeID"];
            }
            return 2;
        }
        private int GetPrdID(string PrdCode,string PrdName,string PrdSpec)
        {
            int prdid = -1;
            this.accPrd.GetParmProductPrdID(PrdCode, ref prdid);
            if (prdid > -1)
            {
                return prdid;
            }
            this.accPrd.GetParmProductPrdIDFromOtherInfor(PrdName, PrdSpec,ref prdid);
            return prdid;
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                int PrdID = (int)grow.Cells[this.ColumnPrdID.Name].Value;
                if (PrdID == -1)
                {
                    grow.ErrorText = "不存在此包材";
                    continue;
                }
            }
        }

      
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = string.Empty;
            string errormsg = string.Empty;          
            int PrdID = this.GetPrdID(drow["包材编号"].ToString(),drow["包材名称"].ToString (),drow["包材规格"].ToString());
            if (PrdID > -1)
            {
                DataRow[] drowBoms = this.dtblBom.Select("PrdID=" + PrdID.ToString());
                if (drowBoms.Length > 0)
                {
                    msg = "此包材已录入";
                    flag = false;
                    return;
                }
            }
            DataRow drowBom = this.dtblBom.NewRow();
            drowBom["PrdID"] = PrdID;
            drowBom["PrdCode"] = drow["包材编号"];
            drowBom["PrdName"] = drow["包材名称"];
            drowBom["PrdSpec"] = drow["包材规格"];
            this.prdEntity.LoadData(PrdID);
            drowBom["UnitName"] = this.prdEntity.UnitName ;
            drowBom["PackageAssembly"] = drow["包材用量"];
            drowBom["PrdAssembly"] = drow["产品用量"];
            drowBom["SourceTypeID"] = this.GetSourceTypeID(drow["来源"].ToString());
            drowBom["RecycleFlag"] = this.GetBool(drow["回收"].ToString());         
            drowBom["Memo"] = drow["备注"];
            drowBom["Position"] = drow["位置"];
            this.dtblBom.Rows.Add(drowBom);

        }
        bool ValidateData()
        {
            bool flag = true;
         
            if (this.txtPackingTypeName.Text == string.Empty)
            {
                MessageBox.Show("方案名称不能为空");
                return false;
            }
            if (this.dtblBom .Select("", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("没有任何记录");
                return false;
            }
            if (this.dtblBom.Select("PrdID=-1 or PackageAssembly is null or PrdAssembly is null", "", DataViewRowState.CurrentRows).Length> 0)
            {
                MessageBox.Show("存在产品或用量不全记录!");
                return false;
            }
            return flag;
        }
        public void Save()
        {
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.PackingTypeID == -1)
            {
                object objPackingTypeID = DBNull.Value;
                flag = this.accPakingType.InsertPackingType(ref errormsg,
                    ref objPackingTypeID,
                    this.PrdID,
                    this.txtPackingTypeName.Text,
                    this.rchDescription.Text);
                if (flag)
                {
                    this.PackingTypeID = (int)objPackingTypeID;
                    this.LoadFile();
                }
            }
            else
            {
                flag = this.accPakingType.UpdatePackingType(
                    ref errormsg,
                    this.PackingTypeID,
                    this.txtPackingTypeName.Text,
                    this.rchDescription.Text);
            }
            //物料
            if (this.PackingTypeID == -1) return;
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag = this.accBom.InsertPackingBOM (
                        ref errormsg,
                        ref objID,
                        this.PackingTypeID,
                        drow["PrdID"],
                        drow["SourceTypeID"],
                        drow["PrdAssembly"],
                        drow["PackageAssembly"],
                        drow["RecycleFlag"],
                        drow["Position"],
                        drow["Memo"]);
                    if (flag)
                    {
                        drow["ID"] = objID;
                    }
                  
                }
                else
                {
                    flag = this.accBom .UpdatePackingBOM (
                        ref errormsg,
                        drow["ID"],
                        drow["PrdID"],
                        drow["SourceTypeID"],
                        drow["PrdAssembly"],
                        drow["PackageAssembly"],
                        drow["RecycleFlag"],
                        drow["Position"],
                        drow["Memo"]);                   
                }

            }
        }
        void btnRemove_Click(object sender, EventArgs e)
        {
           
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                if (this.PackingTypeID > -1)
                {
                    string errormsg = string.Empty;
                    bool flag = this.accPakingType.DeletePackingType(ref errormsg, this.PackingTypeID);
                }               
                if (this.affterRemove != null) this.affterRemove(this);
               
            }
        }

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblBom .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }       
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accBom .DeletePackingBOM (ref ErrorMsg,
                    drow["ID"]);
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
         
    }
}
