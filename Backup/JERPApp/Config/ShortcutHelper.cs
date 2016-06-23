using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Collections ;
namespace JERPApp.Config
{
    public class ShortcutHelper
    {
       
        public static DataTable dtblUserShortFrms;
        public static Hashtable frmstores=new Hashtable ();

        private static void CatchImg(Form frm)
        {

            Bitmap bit = new Bitmap(frm.Width, frm.Height);
            Rectangle rut = new Rectangle(0, 0, frm.Width, frm.Height);
            frm.DrawToBitmap(bit, rut);
            string caption = frm.Text;
            SaveFileDialog filedlg = new SaveFileDialog();
            caption = caption.Replace(" ", "").Replace(":", "_");
            filedlg.FileName = caption;
            filedlg.Filter = "Í¼Æ¬ÎÄ¼þ(*.jpeg)|*.jpeg";
            Clipboard.Clear();

            Clipboard.SetImage(bit);
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                bit.Save(filedlg.FileName, ImageFormat.Jpeg);
            }
            bit.Dispose();
        }
        public static void ShortcutHandle(object Sender,KeyEventArgs e, bool showInMainFlag)
        {

            if ((e.Control) && (e.Alt) && (e.KeyCode == Keys.P))
            {
                CatchImg((Form)Sender);
                return;
            }
            if (e.KeyCode == Keys.F10)
            {
                Config.FrmExpress.ExpressPrint();
               
            }
            if ((e.Control) && (e.Shift) && (e.KeyCode == Keys.Z))
            {
                JCommon.FrmCasio.ShowCasio();
                return;
            }
            if (dtblUserShortFrms == null)
            {
                JERPData.Frame.ShortcutForms accDa = new JERPData.Frame.ShortcutForms();
                dtblUserShortFrms = accDa.GetDataShortcutFormsByUser(JERPBiz.Frame.UserBiz.UserID).Tables[0];
            }
            string ModifierCode = e.Modifiers.ToString();          
            string KeyCode = e.KeyCode.ToString();           
            string sqls="KeyCode='"+KeyCode+"'";
            if (ModifierCode == "None")
            {
                sqls += " and ModifierCode is null";
            }
            else
            {
                sqls += " and ModifierCode='" + ModifierCode + "'";
            }

            DataRow[] drows = dtblUserShortFrms.Select(sqls);
            if (drows.Length > 0)
            {
                int FormID = (int)drows[0]["FormID"];
                string StepInfo = drows[0]["StepInfo"].ToString ();
                string FormName = drows[0]["FormName"].ToString();
                string NameSpace = drows[0]["FormPath"].ToString();

                if (showInMainFlag)
                {
                    ((FrmMain)Sender).ShowInMainFrm(FormID, FormName, NameSpace, StepInfo);
                }
                else
                {
                    Form frm;
                    if (frmstores.ContainsKey(FormID))
                    {
                       frm=(Form)frmstores[FormID];
                    }
                    else
                    {
                        System.Reflection.Assembly tempAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                        frm= (Form)tempAssembly.CreateInstance(NameSpace);
                        frm.Text = StepInfo;
                        new FrmStyle(frm).SetPopFrmStyle((Form)Sender);
                        frmstores.Add(FormID, frm);
                    }
                    frm.ShowDialog();
                }
            }
           
           
        }
        
    }
}
