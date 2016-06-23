using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class CtrlArea : UserControl
    {

        public CtrlArea()
        {
            InitializeComponent();
            this.accArea = new JERPData.General.Area();
            this.cmbItem.SelectedIndexChanged +=new EventHandler(cmbItem_SelectedIndexChanged);
            this.RefreshDate();           
        }
        private DataTable dtblAreas;
        private JERPData.General.Area accArea;
        private FrmArea frmArea;
        private void RefreshDate()
        {
            dtblAreas = this.accArea.GetDataArea().Tables[0];
            if (this.insertAllRowFlag)
            {
                this.InsertAllRow();
            }
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, dtblAreas, "AreaID", "AreaName");
        } 
        private bool insertAllRowFlag = false;
        public bool InsertAllRowFlag
        {
            get
            {
                return this.insertAllRowFlag;
            }
            set
            {
                this.insertAllRowFlag = value;
                if (value)
                {
                    this.InsertAllRow();
                }

            }
        }
        private void InsertAllRow()
        {
            DataRow drow = this.dtblAreas .NewRow();
            drow["AreaID"] = -1;
            drow["AreaName"] = "全部";
            if (this.dtblAreas.Rows.Count > 0)
            {
                this.dtblAreas.Rows.InsertAt(drow, 0);
            }
            else
            {
                this.dtblAreas.Rows.Add(drow);
            }
            this.cmbItem.SelectedIndex = 0;
        }
        public bool DefineFlag
        {
            set
            {
                if (value)
                {
                    new ToolTip().SetToolTip(this.cmbItem, "右击定义");
                    this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
                }
            }
        }

        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Right)
            {
                if (frmArea == null)
                {
                    frmArea = new FrmArea();
                    new FrmStyle(frmArea).SetPopFrmStyle(this.ParentForm);
                    frmArea.AffterSave += this.RefreshDate;
                }
                frmArea.ShowDialog();
            }
        }        
        public int AreaID
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
        public string  AreaName
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return string.Empty;
                return this.dtblAreas.Rows[this.cmbItem.SelectedIndex]["AreaName"].ToString();
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
