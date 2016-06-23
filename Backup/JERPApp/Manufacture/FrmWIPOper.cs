using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWIPOper : Form
    {
        public FrmWIPOper()
        {
            InitializeComponent();
        
            this.txtQuantity.KeyDown +=this.txtCompute_KeyDown;
            ToolTip tip = new ToolTip();
            tip .SetToolTip (this.txtQuantity ,"可以输入公式(如:1+2+3)回车计算");  
            this.dtpDateFinished.Value = DateTime.Now;
            this.accWIP = new JERPData.Manufacture.WIP();
            this.WIPEntity = new JERPBiz.Manufacture.WIPEntity();
            this.ScheduleEntity = new JERPBiz.Manufacture.ManufScheduleEntity();
            this.accManufBOM = new JERPData.Manufacture.BOM();
            this.accBOM = new JERPData.Product.BOM();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.btnSave.Click += new EventHandler(btnSave_Click);

        }

     
        private JERPData.Manufacture.WIP accWIP;
        private JERPBiz.Manufacture.WIPEntity WIPEntity;
        private JERPBiz.Manufacture.ManufScheduleEntity ScheduleEntity;
        private JERPData.Manufacture.BOM accManufBOM;
        private JERPData.Product.BOM accBOM;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        void txtCompute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txt = (TextBox)sender;
                string exp = txt.Text;
                try
                {
                    txt.Text  = string.Format ("{0:0.####}",new DataTable().Compute(exp, ""));
                }
                catch
                {
                    txt.Text = "0";
                }
            }
        }
        private long ManufScheduleID = -1;
        private long ManufProcessID = -1;
        private long WIPID = -1;
        public void New(long ManufScheduleID)
        {
            this.WIPID = -1;
            this.ManufScheduleID = ManufScheduleID;
            this.ScheduleEntity.LoadData(ManufScheduleID);
            this.ManufProcessID = this.ScheduleEntity.ManufProcessID;
            this.txtWorkingSheetCode.Text = this.ScheduleEntity.WorkingSheetCode;
            this.txtPrdCode.Text = this.ScheduleEntity.PrdCode;
            this.txtPrdName.Text = this.ScheduleEntity.PrdName;
            this.txtPrdSpec.Text = this.ScheduleEntity.PrdSpec;
            this.txtModel.Text = this.ScheduleEntity.Model;
            this.txtPrdStatus.Text = this.ScheduleEntity.PrdStatus ;    
            this.txtQuantity.Text = string.Format("{0:0.####}", this.ScheduleEntity.NonFinishedQty);
          
        }
        public void Edit(long WIPID)
        {
            this.WIPID = WIPID;
            this.WIPEntity.LoadData(WIPID);
            this.ManufScheduleID = this.WIPEntity.ManufScheduleID;
            this.ManufProcessID = this.WIPEntity.ManufProcessID;
            this.txtWorkingSheetCode.Text = this.WIPEntity.WorkingSheetCode;
            this.txtPrdCode.Text = this.WIPEntity.PrdCode;
            this.txtPrdName.Text = this.WIPEntity.PrdName;
            this.txtPrdSpec.Text = this.WIPEntity.PrdSpec;
            this.txtModel.Text = this.WIPEntity.Model;
            this.txtPrdStatus.Text = this.WIPEntity.PrdStatus;
            this.ctrlWorkgroupID.WorkgroupID = this.WIPEntity.WorkgroupID;
            this.txtQuantity.Text = string.Format("{0:0.####}", this.WIPEntity.Quantity);
            this.dtpDateFinished.Value = this.WIPEntity.DateFinished;
        }
        bool ValidateData()
        {
            decimal d;
            if (!decimal.TryParse(this.txtQuantity.Text, out d))
            {
                MessageBox.Show("对不起，数量输入不正确!");
                return false;
            } 
                  
            return true;
        }
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;         
            string errormsg = string.Empty;
            bool flag = false;
            decimal Quantity = decimal.Parse(this.txtQuantity.Text);
            if (this.WIPID == -1)
            {
                object objWIPID = DBNull.Value;
                flag = this.accWIP.InsertWIP(
                    ref errormsg,
                    ref objWIPID,
                    this.ManufScheduleID,
                    this.ctrlWorkgroupID .WorkgroupID ,
                    this.txtQuantity.Text,
                    this.dtpDateFinished.Value);
                if (flag)
                {
                    this.WIPID = (long)objWIPID;
                    //弄完成
                    this.accManufSchedules.UpdateManufSchedulesAppendFinishedQty(ref errormsg, this.ManufScheduleID, Quantity );
                 
            
                }
            }
            else
            {
                flag=this.accWIP .UpdateWIP (
                    ref errormsg ,
                    this.WIPID ,
                    this.ctrlWorkgroupID .WorkgroupID ,
                    this.txtQuantity.Text,
                    this.dtpDateFinished.Value);
                if (flag)
                {
                    //出入库
                    decimal AddQty = Quantity  - this.WIPEntity .Quantity;
                    if (AddQty > 0)
                    {
                      
                        this.accManufSchedules.UpdateManufSchedulesAppendFinishedQty(ref errormsg, this.ManufScheduleID ,
                            AddQty);
                    }
                   
                }
            }
            if (flag)
            {
                MessageBox.Show("成功保存当前进程");
                if (this.affterSave != null) this.affterSave();
            }
            else
            {
                MessageBox.Show(errormsg );
            }
        }
    }
}