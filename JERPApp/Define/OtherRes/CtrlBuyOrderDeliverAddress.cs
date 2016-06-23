using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Define.OtherRes
{
    /// <描述>
    /// 表[BuyOrderNotesDeliverAddress]控件类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/6/29 14:32:52
    ///</时间> 
    public partial class CtrlBuyOrderDeliverAddress : UserControl
    {
        public CtrlBuyOrderDeliverAddress()
        {
            InitializeComponent();
            this.accOrderNotes = new JERPData.OtherRes.BuyOrderNotes();
            this.LoadData();
        }
        private JERPData.OtherRes.BuyOrderNotes  accOrderNotes;
        private DataTable dtblDeliverAddress;
        public  void LoadData()
        {
            this.cmbItem.Items.Clear();
            this.dtblDeliverAddress = this.accOrderNotes .GetDataBuyOrderNotesDeliverAddress().Tables[0];
            foreach (DataRow drow in this.dtblDeliverAddress.Rows)
            {
                this.cmbItem.Items.Add(drow["DeliverAddress"].ToString());
            }
            if (this.cmbItem.Items.Count > 0)
            {
                this.cmbItem.SelectedIndex = 0;
            }
        }       
        public string DeliverAddress
        {
            get
            {
                return this.cmbItem.Text;
            }
            set
            {
                this.cmbItem.Text = value;
            }
        }
    
    }
}