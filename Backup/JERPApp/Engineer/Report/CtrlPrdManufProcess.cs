using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdManufProcess : UserControl
    {
        public CtrlPrdManufProcess()
        {
            InitializeComponent();

            this.dgrdv.AutoGenerateColumns = false;
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }

       
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private DataTable dtblManufProcess;
        private JCommon.FrmFileBrowse frmFileBrowse;
        public void PrdManufProcess(int PrdID)
        {           
            this.dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(PrdID).Tables[0];
      
            this.dgrdv.DataSource = this.dtblManufProcess;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount.Name)
            {
                long ManufProcessID = (long)this.dtblManufProcess.DefaultView[irow]["ManufProcessID"];
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = true;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this.ParentForm);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Engineer\ManufProcess\" + ManufProcessID.ToString());
                frmFileBrowse.ShowDialog();
             
            } 
        } 

    }
}
