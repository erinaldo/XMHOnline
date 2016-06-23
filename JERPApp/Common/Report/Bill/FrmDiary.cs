using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Common.Report.Bill
{
    public partial class FrmDiary : Form
    {
        public FrmDiary()
        {
            InitializeComponent();
            this.DiaryEntity = new JERPBiz.General.DiaryEntity();
            this.ctrlFileBrowse.ReadOnly = true;
        }
        JERPBiz.General.DiaryEntity DiaryEntity;
        public void Detail(long DiaryID)
        {
            this.DiaryEntity.LoadData(DiaryID);
            this.txtDateDiary .Text  = this.DiaryEntity.DateDiary .ToShortDateString ();
            this.txtPsnName.Text = this.DiaryEntity.PsnName  ;
            this.txtDiaryTypeName.Text = this.DiaryEntity.DiaryTypeName;
            this.txtDiaryTitle.Text = this.DiaryEntity.DiaryTitle  ;          
            this.rchDiaryContent.Text = this.DiaryEntity.DiaryContent  ;

            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Common\Diary\" + DiaryID.ToString();
            if (Directory.Exists(dir))
            {
                this.ctrlFileBrowse.Browse(dir);
            }
            else
            {
                this.ctrlFileBrowse.Clear();
            }
        }
    }
}