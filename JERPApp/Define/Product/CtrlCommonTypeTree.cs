using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlCommonTypeTree : UserControl
    {
        private int m_flag = 0;
        public CtrlCommonTypeTree()
        {
            InitializeComponent();
            this.accCommomPrdType = new JERPData.Product.ManuCommonPrdType();
            this.treePrdType.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treePrdType.DrawNode += new DrawTreeNodeEventHandler(treePrdType_DrawNode);
            this.treePrdType.AfterSelect += new TreeViewEventHandler(treePrdType_AfterSelect);
            this.treePrdType.BeforeSelect += new TreeViewCancelEventHandler(treePrdType_BeforeSelect);

            this.mItemDefine.Enabled = false;
            this.treePrdType .ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.mItemDefine.Click += new EventHandler(mItemDefine_Click);
            LoadData();
        }

        public void InitiaParam(int type) 
        {
            this.LoadData(type);
        }


        void treePrdType_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;
           // e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显  
            if ((e.State & TreeNodeStates.Selected) != 0)  
            {  
                //演示为绿底白字  
                e.Graphics.FillRectangle(Brushes.Blue, e.Node.Bounds);  
                Font nodeFont = e.Node.NodeFont;  
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;  
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,Rectangle.Inflate(e.Bounds, 2, 0));  
            }  
            else  
            {  
                e.DrawDefault = true;  
            }  

            if ((e.State & TreeNodeStates.Focused) != 0)  
            {  
                using (Pen focusPen = new Pen(Color.White ))  
                {  
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;  
                    Rectangle focusBounds = e.Node.Bounds;  
                    focusBounds.Size = new Size(focusBounds.Width - 1,  
                    focusBounds.Height - 1);  
                    e.Graphics.DrawRectangle(focusPen, focusBounds);  
                }  
            }  

        }

        private JERPData.Product.ManuCommonPrdType accCommomPrdType;
        private DataTable dtblPrdType;
        //private JERPApp.Engineer.Define.FrmManuCommonPrdType frmConmomPrdType;
        public void AllowDefine()
        {
            this.mItemDefine.Enabled = true;
        }

        public void LoadData()
        {
            this.LoadData(m_flag);
        }

        public void LoadData(int type)
        {
            m_flag = type;
            this.treePrdType.Nodes.Clear();
            if (type == 0)
            {
                this.dtblPrdType = this.accCommomPrdType.GetDataPrdTypeAll().Tables[0];
            }
            else {
                this.dtblPrdType = this.accCommomPrdType.GetDataPrdTypeByType(type).Tables[0];
            } 

            DataRow drow = this.dtblPrdType.NewRow();
            drow["PrdTypeID"] = 0;
            drow["ParentID"] = -1;
            drow["PrdTypeCode"] = "0";
            drow["PrdTypeName"] = "类型分类";
            if (this.dtblPrdType.Rows.Count == 0)
            {
                this.dtblPrdType.Rows.Add(drow);
            }
            else
            {
                this.dtblPrdType.Rows.InsertAt(drow, 0);
            }

            this.InitTree(this.treePrdType.Nodes, -1);
            if (this.treePrdType.Nodes.Count > 0)
            {
                this.treePrdType.SelectedNode = this.treePrdType.Nodes[0];
            }
            this.treePrdType.Refresh();
        }

        void mItemDefine_Click(object sender, EventArgs e)
        {
            //if (frmConmomPrdType == null)
            //{
            //    frmConmomPrdType = new JERPApp.Engineer.Define.FrmManuCommonPrdType();
            //    new FrmStyle(frmConmomPrdType).SetPopFrmStyle(this.ParentForm);                
            //}
            //frmConmomPrdType.ShowDialog();
        }

      

        //建树的基本思路是：从根节点开始递归调用显示子树
        private void InitTree(TreeNodeCollection Nds, int parent_id)//建树的基本思路是：从根节点开始递归调用显示子树
        {
            foreach (DataRow drow in this.dtblPrdType .Select("ParentID=" + parent_id.ToString(), "", DataViewRowState.CurrentRows))
            {
                TreeNode tmpNd = new TreeNode();
                tmpNd.Name = drow["PrdTypeID"].ToString();               
                tmpNd.Text = drow["PrdTypeName"].ToString();
                Nds.Add(tmpNd);                
                this.InitTree(tmpNd.Nodes, int.Parse(tmpNd.Name));
                

            }

        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        void treePrdType_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            bool CancelFlag;
            if (this.beforeSelected != null)
            {
                this.beforeSelected(out CancelFlag );
                if (CancelFlag)
                {
                    e.Cancel = true;
                }
            }
        }

      
 
        void treePrdType_AfterSelect(object sender, TreeViewEventArgs e)
        {
         
            if (this.affterSelected != null)
            { 
                this.affterSelected( );
                
            }
            
        }

        //取得当前        
        public int PrdTypeID
        {
            get
            {
                if (this.treePrdType.SelectedNode ==null) return -1;
                return int.Parse(this.treePrdType.SelectedNode.Name);
            }
            
        }
     
        public string PrdTypeName
        {
            get
            {
                if (this.treePrdType.SelectedNode == null) return "";
                return this.treePrdType.SelectedNode.Text;
                //string rut=string .Empty ;
                //this.accPrdType.GetParmPrdTypeTreePrdTypeName(this.PrdTypeID, ref rut);
                //return rut;
            }
        }     
        public delegate void AffterSelectDelegate();
        private AffterSelectDelegate affterSelected;
        public event AffterSelectDelegate AffterSelected
        {
            add
            {
                this.affterSelected += value;
            }
            remove
            {
                this.affterSelected -= value;
            }

        }

        public delegate void BeforeSelectDelegate(out bool CancelFlag);
        private BeforeSelectDelegate beforeSelected;
        public event BeforeSelectDelegate BeforeSelected
        {
            add
            {
                this.beforeSelected += value;
            }
            remove
            {
                this.beforeSelected -= value;
            }

        }
       
    }
}
