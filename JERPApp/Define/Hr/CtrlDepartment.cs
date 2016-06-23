using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Hr
{
    public partial class CtrlDepartment : UserControl
    {
       
        public CtrlDepartment()
        {
            InitializeComponent();
            this.accDepartment = new JERPData.Hr.Department();     
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
            this.cmbItem.MouseClick += new MouseEventHandler(cmbItem_MouseClick);
            this.RefreshDate();
           
        }
      
        private DataTable dtblDepts;
        private JERPData.Hr .Department accDepartment;
        JERPApp.Hr.FrmDepartment frmDept;
        private void RefreshDate()
        {
           this.dtblDepts = this.accDepartment.GetDataDepartment  ().Tables[0];
          
           this.dtblDepts.Columns.Add("ErpCode", typeof(string), "ISNULL(DeptCode,'')+' '+ISNULL(DeptName,'')");
           JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtblDepts, "DeptID", "ErpCode");
       }    
       
       void cmbItem_MouseClick(object sender, MouseEventArgs e)
       {
           if (e.Button == MouseButtons.Right)
           {
               if (frmDept == null)
               {
                   frmDept = new JERPApp.Hr.FrmDepartment();
                   new FrmStyle(frmDept).SetPopFrmStyle(this);
                   frmDept.AffterSave += this.RefreshDate;
               }
               frmDept.ShowDialog();
           }
       }  
        public int DeptID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (int)this.cmbItem.SelectedValue;               
            }
            set
            {
                this.cmbItem.SelectedValue = value;
            }
        }
        public string DeptCode
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return string.Empty;
                return this.dtblDepts.Rows[this.cmbItem.SelectedIndex]["DeptCode"].ToString();
            }

        }
        public string  DeptName
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return string.Empty ;
                return this.dtblDepts.Rows[this.cmbItem.SelectedIndex]["DeptName"].ToString();
            }
           
        }
        public delegate void AffterSelectedDelegate();
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
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (affterSelected != null) this.affterSelected();
        }
    }
}
