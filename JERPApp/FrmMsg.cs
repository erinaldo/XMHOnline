using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace JERPApp
{
    public partial class FrmMsg : Form
    {
        private static FrmMsg frmInfor;
        private  FrmMsg()
        {
            InitializeComponent();
            
        }
        private void  ShowInfor(string info)
        {
            Application.DoEvents();
            this.lblMsg.Text = info;
            this.Text = info; 
            this.BringToFront();           
            if (this.Visible == false)
            {
                this.proBar.Value = 10;
                this.Visible = true;
                Application.DoEvents();                
                this.Show();
                
            }
          
        }
        public static void Show(string info)
        {
            Application.DoEvents();
            if (frmInfor == null)
            {
                frmInfor = new FrmMsg();
            }
            frmInfor.ShowInfor(info);
        }
        public static new  void Hide()
        {
            if (frmInfor != null)
            {
                frmInfor.Hidden();
            }
        }
        private void Hidden()
        {
            this.Visible = false;
        }
        
        private void FrmMsg_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (this.bgwork.IsBusy)
                {
                    return;
                }
                this.bgwork.RunWorkerAsync(100);
            }
            else
            {
                this.bgwork.CancelAsync();
              
            }
        }

        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            
            for (int i = 10; i <= 100; i+=10)
            {
                if ((this.bgwork .CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    e.Result = i;
                    this.bgwork.ReportProgress(i,i);
                    Thread.Sleep(20);
                  
                }
            }
        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.proBar .Value = e.ProgressPercentage ;        
        }

        private void bgwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.proBar.Value = 100;
        }
    }
}