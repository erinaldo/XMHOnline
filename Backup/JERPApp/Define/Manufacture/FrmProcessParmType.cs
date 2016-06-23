using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmProcessParmType : Form
    {
        public FrmProcessParmType()
        {
            InitializeComponent();
            this.accParmType = new JERPData.Manufacture .ProcessParmType();
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }

        private JERPData.Manufacture .ProcessParmType  accParmType;
        private DataTable dtblParmType;
        public void LoadData(int ProcessTypeID)
        {
            this.dtblParmType = this.accParmType.GetDataProcessParmTypeByProcessTypeID (ProcessTypeID ).Tables[0];
            this.pnlMain.Controls.Clear();
            JERPApp .Define.Manufacture .CtrlProcessParmType  ctrlParmType;
            foreach (DataRow drow in this.dtblParmType.Rows)
            {
                ctrlParmType = new CtrlProcessParmType (
                    drow["ParmTypeName"].ToString(),
                    drow["DefaultValue"].ToString(),
                    drow["ItemValues"].ToString());
                ctrlParmType.Dock = DockStyle.Top;                
                this.pnlMain.Controls.Add(ctrlParmType);
                ctrlParmType.BringToFront();
            }
        }
        public delegate void AffterConfirmDelegate(string ParmValueInfor);
        private AffterConfirmDelegate affterConfirm;
        public event AffterConfirmDelegate AffterConfirm
        {
            add
            {
                affterConfirm += value;
            }
            remove
            {
                affterConfirm -= value;
            }
        }
        void btnConfirm_Click(object sender, EventArgs e)
        {
            string parmInfor = string.Empty;
            JERPApp.Define.Manufacture.CtrlProcessParmType ctrlProcessParmType;
            foreach (Control ctrl in this.pnlMain.Controls)
            {
                ctrlProcessParmType = (JERPApp.Define.Manufacture.CtrlProcessParmType)ctrl;
                if (ctrlProcessParmType.ParmValue  != string.Empty)
                {
                    parmInfor += ctrlProcessParmType.ParmValue + ";";
                }
            }
            if (this.affterConfirm != null) this.affterConfirm(parmInfor);
            this.Close();
        }
    }
}