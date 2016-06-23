using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCommon;
namespace JERPApp.Manufacture.Boxing.Templet
{
    public partial class FrmBoxFormat : Form
    {
        public FrmBoxFormat()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Packing.BoxFormat();
            this.accFormatColumn = new JERPData.Packing.BoxFormatColumn();
            this.FormatEntity = new JERPBiz.Packing.BoxFormatEntity();
            this.SetPermit();
        }
        private JERPData.Packing.BoxFormat accFormat;
        private JERPData.Packing.BoxFormatColumn accFormatColumn;
        private JERPBiz.Packing.BoxFormatEntity FormatEntity;
        private DataTable dtblFormatColumn;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(114);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(144);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave )
            {
                this.btnTest.Click += new EventHandler(btnTest_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            }
        }

        private void LoadData()
        {
            this.FormatEntity.LoadData();
            this.txtWidth.Text = this.FormatEntity.Width;
            this.txtHeight.Text = this.FormatEntity.Height;
         
            this.txtBarcodeName.Text = this.FormatEntity.BarcodeName;
            if (this.FormatEntity.FormatID == -1)
            {
                this.txtBarcodeVersion.Text = "4";
                this.txtFontSize.Text = "10";
                this.txtMargin.Text = "3";
                this.txtOffset.Text = "0";
                this.txtRepeat.Text  = "0";
            }
            else
            {
                this.txtBarcodeVersion.Text = this.FormatEntity.BarcodeVersion;
                this.txtFontSize.Text =this.FormatEntity .FontSize.ToString () ;
                this.txtMargin.Text = this.FormatEntity.Margin;
                this.txtOffset.Text = this.FormatEntity.Offset;
                this.txtRepeat.Text = this.FormatEntity.Repeat.ToString ();

            }
            this.dtblFormatColumn = this.accFormatColumn.GetDataBoxFormatColumn().Tables[0];
            this.dgrdv .DataSource =this.dtblFormatColumn ;
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnBarcodeX.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnBarcodeY.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnCaptionX.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnCaptionY.Name].Value == DBNull.Value)
                    )
                {
                    grow.ErrorText = "存在出错项!";
                }
            }
        }

       
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblFormatColumn .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["FormatID"] == DBNull.Value)
            {
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accFormatColumn.DeleteBoxFormatColumn (ref ErrorMsg,
                    drow["FormatID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                    e.Cancel = true;
                }
               
            }
            else
            {
                e.Cancel = true;
            }
        }
        private bool ValidateData()
        {
            if ((this.txtWidth.Text ==string.Empty)
                ||(this.txtHeight.Text ==string.Empty)
                ||(this.txtMargin.Text ==string.Empty)
                ||(this.txtOffset.Text ==string.Empty)
                ||(this.txtBarcodeName.Text ==string.Empty)
                ||(this.txtBarcodeVersion.Text ==string.Empty)
                || (this.txtFontSize .Text == string.Empty)
                || (this.txtRepeat .Text == string.Empty))
            {
                MessageBox.Show("对不起,标签设定有误");
                return false;
            }
            int i;
            if ((int.TryParse(this.txtFontSize.Text, out i) == false)
                || (i < 0))
            {
                MessageBox.Show("对不起,字号出错");
                return false;
            }
            if ((int.TryParse(this.txtRepeat .Text, out i) == false)
               || (i < 0))
            {
                MessageBox.Show("对不起,重复份数出错");
                return false;
            }
            DataRow[] drows = this.dtblFormatColumn.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("对不起,打印标签不能少于一列");
                return false;
            }
            drows = this.dtblFormatColumn.Select("BarcodeX is null or BarcodeY is null or CaptionX is null or CaptionY is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,列标签参数设置出错");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accFormat.SaveBoxFormat(
                ref errormsg,
                this.txtWidth.Text,
                this.txtHeight.Text,
                this.txtMargin.Text,
                this.txtOffset.Text,
                this.txtBarcodeName.Text,
                this.txtBarcodeVersion.Text,
                this.txtFontSize.Text,
                this.txtRepeat.Text );
            if (!flag)
            {
                MessageBox.Show(errormsg);
            }
            object objFormatID=DBNull .Value ;
            foreach (DataRow drow in this.dtblFormatColumn.Rows)
            {
                 if (drow.RowState == DataRowState.Deleted ) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["FormatID"] == DBNull.Value)
                {
                    objFormatID = DBNull.Value;
                    flag=this.accFormatColumn.InsertBoxFormatColumn(
                        ref errormsg,
                        ref objFormatID,
                        drow["BarcodeX"],
                        drow["BarcodeY"],
                        drow["CaptionX"],
                        drow["CaptionY"],
                        drow["CaptionWidth"]);
                    if (flag)
                    {
                        drow["FormatID"] = objFormatID;
                    }
                }
                else
                {
                    flag=this.accFormatColumn .UpdateBoxFormatColumn (
                        ref errormsg ,
                        drow["FormatID"],
                        drow["BarcodeX"],
                        drow["BarcodeY"],
                        drow["CaptionX"],
                        drow["CaptionY"],
                        drow["CaptionWidth"]);
                }
                if(flag)
                {
                    drow.AcceptChanges ();
                }
            }
            MessageBox.Show("成功保存当前格式");
        }
        private void ExportRow(DataRow drow)
        {
            string command = this.txtBarcodeName.Text + " " + drow["BarcodeX"].ToString() + "," + drow["BarcodeY"].ToString() + ",L," + this.txtBarcodeVersion.Text + ",A,0,M2,S3,\"" + this.txtBarcode.Text + "\"";
            TSCPrintHelper.sendcommand(command);
            string caption = this.txtCaption.Text;
            int FontSize = int.Parse(this.txtFontSize.Text);
            int CaptionX = (int)drow["CaptionX"];
            int CaptionY = (int)drow["CaptionY"];
            if (drow["CaptionWidth"] == DBNull.Value)
            {
                TSCPrintHelper.windowsfont(CaptionX, CaptionY, FontSize, 0, 0, 2, "宋体", caption);
            }
            else
            {
                int captionwidth = (int)drow["CaptionWidth"];
                if (caption.Length <= captionwidth)
                {
                    TSCPrintHelper.windowsfont(CaptionX, CaptionY, FontSize, 0, 2, 0, "宋体", caption);
                }
                else
                {
                    TSCPrintHelper.windowsfont(CaptionX, CaptionY, FontSize, 0, 2, 0, "宋体", caption.Substring(0, captionwidth));
                    TSCPrintHelper.windowsfont(CaptionX, CaptionY + FontSize + 2, FontSize, 0, 2, 0, "宋体", caption.Remove(0, captionwidth));
                }
            }
        }
        void btnTest_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            TSCPrintHelper.openport(JERPBiz.Config.ConfigInfo.GetBoxPrinter());
            TSCPrintHelper.clearbuffer();
            TSCPrintHelper.setup(
             this.txtWidth.Text,
             this.txtHeight.Text,
             "8",
             "10",
             "0",
             this.txtMargin.Text,
             this.txtOffset.Text);
            TSCPrintHelper.sendcommand("DIRECTION 1");
            int cnt = int.Parse(this.txtRepeat.Text) + 1;
            for (int i = 0; i < cnt; i++)
            {
                foreach (DataRow drow in this.dtblFormatColumn.Rows)
                {
                    this.ExportRow(drow);
                }
                TSCPrintHelper.printlabel("1", "1");
            }
            TSCPrintHelper.clearbuffer();
            TSCPrintHelper.closeport();
        }

    }
}