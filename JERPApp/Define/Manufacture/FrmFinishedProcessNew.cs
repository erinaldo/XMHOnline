using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmFinishedProcessNew : Form
    {
        public FrmFinishedProcessNew()
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

        //private DataTable dtblToolProcess, dtblMachineProcess, dtblModelProcess;
        private DataTable dtbliniProcessNew, dtblProcessNew;

        private string whereclause = string.Empty;

        private void SetPermit()
        {
                //this.SetColumnSrc();
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnClose.Click += new EventHandler(btnClose_Click);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //private void SetColumnSrc()
        //{
        //    this.dtblToolProcess = this.accToolProcess.GetDataToolProcessTypeNew().Tables[0];
        //    this.ToolsID.DataSource = this.dtblToolProcess;
        //    this.ToolsID.ValueMember = "ToolProcessID";
        //    this.ToolsID.DisplayMember = "ToolProcessName";


        //    this.dtblMachineProcess = this.accMachineProcess.GetDataMachineProcessTypeNew().Tables[0];
        //    this.UseMachineID.DataSource = this.dtblMachineProcess;
        //    this.UseMachineID.ValueMember = "MachineProcessID";
        //    this.UseMachineID.DisplayMember = "MachineProcessName";

        //    this.dtblModelProcess = this.accModelProcess.GetDataModeProcessTypeNew().Tables[0];
        //    this.ModelID.DataSource = this.dtblModelProcess;
        //    this.ModelID.ValueMember = "ModelProcessID";
        //    this.ModelID.DisplayMember = "ModelProcessName";

        //}

        private void LoadData()
        {

            this.dtbliniProcessNew = this.accProcessNew.GetDataProcessNewUnion().Tables[0];
            this.dtblProcessNew = this.dtbliniProcessNew.Copy();
            this.dgrdv.DataSource = this.dtblProcessNew;

        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }



        //查询
        void ctrlQFind_BeforeFilter()
        {
            this.dtblProcessNew = this.dtbliniProcessNew.Copy();
            this.dgrdv.DataSource = this.dtblProcessNew;
        }


        //datagrid点击事件
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow = this.dtblProcessNew.DefaultView[irow].Row;
            if (this.dgrdv.Columns[icol].Name == this.btnSelect.Name)
            {
                if (this.affterSelected != null) this.affterSelected(drow);
            }
        }

        public delegate void AffterSelectedDelegate(DataRow drow);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
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


    }
}
