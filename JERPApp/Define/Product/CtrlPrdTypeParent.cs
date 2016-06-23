using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class CtrlPrdTypeParent : UserControl
    {
        public CtrlPrdTypeParent()
        {
            InitializeComponent();
            this.accPrdType = new JERPData.Product.PrdType();

            this.treePrdType.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treePrdType.DrawNode += new DrawTreeNodeEventHandler(treePrdType_DrawNode);
            this.treePrdType.AfterSelect += new TreeViewEventHandler(treePrdType_AfterSelect);
            this.treePrdType.BeforeSelect += new TreeViewCancelEventHandler(treePrdType_BeforeSelect);
            this.LoadData();
            this.treePrdType .ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
        }

      

        private JERPData.Product.PrdType accPrdType;
        private DataTable dtblPrdType; 
        public void LoadData()
        {
            this.treePrdType.Nodes.Clear();
            this.dtblPrdType = this.accPrdType.GetDataPrdType ().Tables[0];
            DataRow drow = this.dtblPrdType.NewRow();
            drow["PrdTypeID"] = 0;
            drow["ParentID"] = -1;
            drow["PrdTypeName"] = "产品类型";
            if (this.dtblPrdType.Rows.Count == 0)
            {
                this.dtblPrdType.Rows.Add(drow);
            }
            else
            {
                this.dtblPrdType.Rows.InsertAt(drow, 0);
            }
            this.InitTree(this.treePrdType.Nodes, -1);
            this.treePrdType.SelectedNode = this.treePrdType.Nodes[0];
        }
        void treePrdType_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return; 
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字  
                e.Graphics.FillRectangle(Brushes.Blue, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

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
                this.beforeSelected(out CancelFlag);
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
                this.affterSelected();
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
                string rut=string .Empty ;
                this.accPrdType.GetParmPrdTypeTreePrdTypeName(this.PrdTypeID, ref rut);
                return rut;
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
