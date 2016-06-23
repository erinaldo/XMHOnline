using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.Technology
{
    /// <描述>
    /// 表[ProcessType]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/11 8:45:33
    ///</时间> 
    public partial class CtrlDevelopProcessForSchedule : UserControl
    {
        public CtrlDevelopProcessForSchedule()
        {
            InitializeComponent();
            this.accDevelopProcess  = new JERPData.Technology.DevelopProcess ();
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);          
        }
        private JERPData.Technology.DevelopProcess  accDevelopProcess;
        private DataTable dtblDevelopProcess;
        public  void LoadData(int PrdID)
        {
            this.dtblDevelopProcess =this.accDevelopProcess .GetDataDevelopProcessForScheduleByPrdID (PrdID).Tables[0];
             this.cmbItem.DataSource = this.dtblDevelopProcess ;
            this.cmbItem.ValueMember = "DevelopProcessID";
            this.cmbItem.DisplayMember = "PrdStatus";
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
            if (this.affterSelected != null)
            {
                this.affterSelected();
            }
        }
        public long DevelopProcessID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;
                return (long)this.cmbItem.SelectedValue;
            }
            set
            {
                if (value == -1)
                {
                    this.cmbItem.SelectedIndex = -1;
                }
                else
                {
                    this.cmbItem.SelectedValue = value;
                }
            }
        }
        private object GetFieldValue(string FieldName)
        {
            if (this.cmbItem.SelectedIndex == -1) return DBNull.Value;
            return this.dtblDevelopProcess.Rows[this.cmbItem.SelectedIndex][FieldName];
        }
        public int PrdID
        {
            get
            {
                object objValue = this.GetFieldValue("PrdID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public int SerialNo
        {
            get
            {
                object objValue = this.GetFieldValue("SerialNo");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public int ProcessTypeID
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeID");
                if (objValue == DBNull.Value)
                {
                    return -1;
                }
                else
                {
                    return (int)objValue;
                }
            }
        }
        public string PrdStatus
        {
            get
            {
                object objValue = this.GetFieldValue("PrdStatus");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string Memo
        {
            get
            {
                object objValue = this.GetFieldValue("Memo");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public DateTime DateTarget
        {
            get
            {
                object objValue = this.GetFieldValue("DateTarget");
                if (objValue == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return (DateTime)objValue;
                }
            }
        }
        public DateTime DateFinished
        {
            get
            {
                object objValue = this.GetFieldValue("DateFinished");
                if (objValue == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return (DateTime)objValue;
                }
            }
        }
        public string FinishedRemark
        {
            get
            {
                object objValue = this.GetFieldValue("FinishedRemark");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }
        public string ProcessTypeName
        {
            get
            {
                object objValue = this.GetFieldValue("ProcessTypeName");
                if (objValue == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return objValue.ToString();
                }
            }
        }



    }
}