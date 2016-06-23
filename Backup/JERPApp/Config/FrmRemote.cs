using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JERPApp.Config
{
    public partial class FrmRemote : Form
    {
        public FrmRemote()
        {
            InitializeComponent();
            this.sqlConn = JERPData.DBConnection.JSqlDBConn;
            this.accDBParm = new JERPData.ServerParameter();
            this.Shown += new EventHandler(FrmRemote_Shown);
            this.txtPassword.KeyDown += new KeyEventHandler(txtPassword_KeyDown);
            this.btnPaste.Click += new EventHandler(btnPaste_Click);
            this.btnExcSql.Click += new EventHandler(btnExcSql_Click);
            this.LoadScheduleData();
            this.btnBatchClear.Click += new EventHandler(btnBatchClear_Click);
            this.cmbSchedule.SelectedIndexChanged += new EventHandler(cmbSchedule_SelectedIndexChanged);
            this.lsbSrcName.SelectedIndexChanged += new EventHandler(lsbSrcName_SelectedIndexChanged);
            this.radTop.CheckedChanged += new EventHandler(radTop_CheckedChanged);
            this.txtTop.KeyDown += new KeyEventHandler(txtTop_KeyDown);
            this.ckbAll.CheckedChanged += new EventHandler(ckbAll_CheckedChanged);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnExcute.Click += new EventHandler(btnExcute_Click);
            this.treeFold .NodeMouseClick +=new TreeNodeMouseClickEventHandler(treeFold_NodeMouseClick);
            this.btnBackup.Click += new EventHandler(btnBackup_Click);
        }

       
        private SqlConnection sqlConn;
        private JERPData.ServerParameter accDBParm;
        void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtPassword.Text == "jyfsoft888")
                {
                    this.btnBatchClear.Enabled = true;
                    this.btnExcute.Enabled = true;
                    this.btnPaste.Enabled = true;
                    this.btnExcSql.Enabled = true;
                    this.cmbSchedule.Enabled = true;
                    this.btnBackup.Enabled = true;
                    this.txtPassword.Text = string.Empty;
                    DataTable dtblFolder = this.accDBParm.GetDataServerFolder("").Tables[0];
                    this.treeFold.Nodes.Clear();
                    foreach (DataRow drow in dtblFolder.Rows)
                    {
                        this.treeFold.Nodes.Add(drow["name"].ToString());
                    }
                }
            }
        }
        void btnExcSql_Click(object sender, EventArgs e)
        {

            string sqltxt = (this.rchSQL.SelectedText == string.Empty) ? this.rchSQL.Text : this.rchSQL.SelectedText;       
            string[] sqls = sqltxt.Split(new string[] { "GO" }, StringSplitOptions.None);
            for (int i = 0; i < sqls.Length; i++)
            {
                if (sqls[i] != string.Empty)
                {
                    DataTable dtbl = new DataTable() ;
                    this.FillDataTable (dtbl,sqls[i]);
                    this.dgrdvQuery.Columns.Clear();
                    this.dgrdvQuery.DataSource = dtbl;
                }
            }
            MessageBox.Show("成功执行当前脚本,辛苦了");
        }

        void btnPaste_Click(object sender, EventArgs e)
        {
            this.rchSQL.Text = Clipboard.GetText();
        }
        public DataTable GetQuerySchema(string sqlstring)
        {
            SqlCommand cmd = this.sqlConn.CreateCommand();
            cmd.CommandText = sqlstring;
            this.sqlConn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo | CommandBehavior.CloseConnection); //
            DataTable tblMetaData = rdr.GetSchemaTable();
            rdr.Close();
            return tblMetaData;
        }
        //加载数据
        public bool FillDataTable(DataTable datatable, string sqlstring)
        {
            bool flag = false;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlstring, this.sqlConn );
                da.Fill(datatable);
                flag = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.sqlConn .Close();
            }
            return flag;
        }    
        //执行数据
        public bool ExecuteSqlCommand(string sqlstring)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.sqlConn ;
            cmd.CommandText = sqlstring;
            cmd.CommandType = CommandType.Text;
            if (this.sqlConn .State == System.Data.ConnectionState.Closed)
            {
                this.sqlConn.Open();
            }
            try
            {

                cmd.ExecuteNonQuery();
                flag = true;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                this.sqlConn.Close();
            }

            return flag;
        }
        void FrmRemote_Shown(object sender, EventArgs e)
        {
            this.txtPassword.Text = string.Empty;
            this.btnBatchClear.Enabled = false;
            this.btnExcute.Enabled = false;
            this.btnPaste.Enabled = false;
            this.btnExcSql.Enabled = false;
            this.cmbSchedule.Enabled = false;
        }
        private void LoadOperData()
        {
            DataTable dt = new DataTable();
            DataTable dtblData = new DataTable();
            DataTable dtblSchedule;
            string sqlstr = "select top 1  * from " + this.lsbSrcName.Text;
            dtblSchedule = this.GetQuerySchema(sqlstr);
            this.IDColumnName = string.Empty;
            DataRow[] rows = dtblSchedule.Select("IsIdentity=1");
            if (rows.Length > 0)
            {
                this.IDColumnName = rows[0]["ColumnName"].ToString();
            }
            sqlstr = "select * from " + this.lsbSrcName.Text;
            if (this.radTop.Checked)
            {
                sqlstr = "select top " + this.txtTop.Text + " * from " + this.lsbSrcName.Text;
                if (this.IDColumnName != string.Empty)
                {
                    sqlstr += " order by " + this.IDColumnName + " desc";
                }
            }
            this.FillDataTable(dtblData, sqlstr);
            this.dgrdv.DataSource = dtblData;
            if (this.IDColumnName != string.Empty)
            {
                this.dgrdv.Columns[this.IDColumnName].ReadOnly = true;
            }

        }
        private void LoadScheduleData()
        {
            string sqlstr = @"SELECT  schema_id,name from sys.schemas  where (Schema_id>4) and (schema_id<10000) order by name";
            DataTable dt = new DataTable() ;
            this.FillDataTable(dt, sqlstr);
            DataRow drow = dt.NewRow();
            drow["schema_id"] = -1;
            drow["name"] = "全部";
            if (dt.Rows.Count > 0)
            {
                dt.Rows.InsertAt(drow, 0);
            }
            else
            {
                dt.Rows.Add(drow);
            }
            this.cmbSchedule.DataSource = dt;
            this.cmbSchedule.DisplayMember = "name";
            this.cmbSchedule.ValueMember = "schema_id";
            this.cmbSchedule.SelectedIndex = -1;


        }
        private void lsbSrcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsbSrcName.SelectedIndex == -1) return;
            if (this.lsbSrcName.Text == "System.Data.DataRowView") return;
            this.dgrdv.DataSource = null;
            while (this.dgrdv.ColumnCount > 0)
            {
                this.dgrdv.Columns.RemoveAt(0);
            }
            this.LoadOperData();

        }
        void cmbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lsbSrcName.DataSource = null;
            int schema_id = (int)this.cmbSchedule.SelectedValue;
            string typename = "U";
            string sqlstr = @"Select object_id,((SELECT top 1 sc.name from sys.schemas sc where sc.schema_id=o.schema_id) +'.'+o.name) as name from sys.objects  o  where (type=N'" + typename + "') and [name] NOT like 'sp_%' and [name] <> N'sysdiagrams' order by name";
            if (schema_id != -1)
            {
                sqlstr = @"Select object_id,((SELECT top 1 sc.name from sys.schemas sc where sc.schema_id=o.schema_id) +'.'+o.name) as name from sys.objects  o  where (type=N'" + typename + "') and [name] NOT like 'sp_%' and o.schema_id=" + schema_id.ToString() + " order by name";
            }
            DataTable dt = new DataTable();

            this.FillDataTable(dt, sqlstr);
            this.lsbSrcName.DataSource = dt;
            this.lsbSrcName.DisplayMember = "name";
            this.lsbSrcName.ValueMember = "object_id";
        }
        private string IDColumnName = string.Empty;
      
        void btnExcute_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtblData = new DataTable();
                DataTable dtblSchedule;
                string sqlstr = "select top 1  * from " + this.lsbSrcName.Text;
                dtblSchedule = this.GetQuerySchema(sqlstr);
                this.IDColumnName = string.Empty;
                DataRow[] rows = dtblSchedule.Select("IsIdentity=1");
                if (rows.Length > 0)
                {
                    this.IDColumnName = rows[0]["ColumnName"].ToString();
                }
                sqlstr = "select * from " + this.lsbSrcName.Text;
                if (this.txtSql.Text != string.Empty)
                {
                    sqlstr += " where " + this.txtSql.Text;
                }
                this.FillDataTable(dtblData, sqlstr);
                this.dgrdv.DataSource = dtblData;
                if (this.IDColumnName != string.Empty)
                {
                    this.dgrdv.Columns[this.IDColumnName].ReadOnly = true;
                }
            }
            catch
            {
                this.dgrdv.DataSource = null;
            }
        }
        void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lsbSrcName.Items.Count; i++)
            {
                if (this.ckbAll.Checked)
                {
                    this.lsbSrcName.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    this.lsbSrcName.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
        void btnBatchClear_Click(object sender, EventArgs e)
        {
            if (this.lsbSrcName.CheckedItems.Count == 0)
            {
                MessageBox.Show("未选择任何表！");
                return;
            }
            string tablename;
            DialogResult rlt = MessageBox.Show("你将删除所选表数据，你的的删除将不能恢复！\n是，删除；否，取消",
              "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.No) return;
            for (int i = 0; i < this.lsbSrcName.Items.Count; i++)
            {
                if (this.lsbSrcName.GetItemChecked(i))
                {
                    this.lsbSrcName.SelectedIndex = i;
                    tablename = this.lsbSrcName.Text;
                    string sqlstr = "delete from " + tablename;
                    bool flag = this.ExecuteSqlCommand(sqlstr);
                    if (flag)
                    {
                        this.lsbSrcName.SetItemChecked(i, false);
                        //将自动增加号重置
                        if (this.IDColumnName != string.Empty)
                        {
                            sqlstr = "dbcc   checkident([" + tablename + "],reseed,0)";
                            this.ExecuteSqlCommand(sqlstr);
                        }
                        this.lsbSrcName_SelectedIndexChanged(null, null);
                    }
                }
            }
        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            if (this.IDColumnName == string.Empty)
            {
                MessageBox.Show("对不起，此表没有唯一标识列!");
                return;
            }
            string tablename = this.lsbSrcName.Text;
            string sqlstr = "delete from " + tablename + " where " + this.IDColumnName + "=" + this.dgrdv[this.IDColumnName, irow].Value.ToString();
            bool flag = this.ExecuteSqlCommand(sqlstr);
            if (!flag)
            {
                e.Cancel = true;
            }

        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.IDColumnName == string.Empty)
            {
                MessageBox.Show("对不起，此表没有唯一标识列!");
                return;
            }
            string tablename = this.lsbSrcName.Text;
            string value_ = (this.dgrdv[icol, irow].Value == DBNull.Value) ? "NULL" : "N'" + this.dgrdv[icol, irow].Value.ToString() + "'";
            string sqlstr = "update  " + tablename + " set " + this.dgrdv.Columns[icol].HeaderText + "=" + value_ +
                "  where " + this.IDColumnName + "=" + this.dgrdv[this.IDColumnName, irow].Value.ToString();
            bool flag = this.ExecuteSqlCommand(sqlstr);
        }

        void radTop_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadOperData();
        }
        void txtTop_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.radTop.Checked) && (e.KeyCode == Keys.Enter))
            {
                this.LoadOperData();
            }
        }

        void treeFold_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nd = e.Node;
            string path = this.GetPath(nd);
            if (nd.Nodes.Count == 0)
            {
                DataTable dtbl = this.accDBParm.GetDataServerFolder(path).Tables[0];
                foreach (DataRow drow in dtbl.Rows)
                {
                    nd.Nodes.Add(drow["subdirectory"].ToString());
                }
                if (dtbl.Rows.Count > 0)
                {
                    nd.Expand();
                }
            }
            this.txtBackupName.Text = path;
        }
        private string GetPath(TreeNode nd)
        {
            string rut = nd.Text + @"\";
            if (nd.Parent != null)
            {
                rut = this.GetPath(nd.Parent) + rut;
            }
            return rut;
        }
        void btnBackup_Click(object sender, EventArgs e)
        {
            string execsql="BACKUP DATABASE ["+ JERPData.ServerParameter .DbName+"] to disk='"+ this.txtBackupName .Text +"' with INIT";
            if (this.ExecuteSqlCommand(execsql))
            {
                MessageBox .Show ("成功备份了当前数据库");
            }
        }
    }
}