﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmFinishedPrdMore : Form
    {
        public FrmFinishedPrdMore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.ctrlCheckAll.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.ctrlPrdTypeID.AffterSelected += new CtrlPrdTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnCheckedFlag.ReadOnly = false; 
            this.btnSelect .Click +=new EventHandler(btnSelect_Click);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.whereclause = this.initwhereclause;
            this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
        }
        private JERPData.Product.Product accPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblIniPrds,dtblPrds;
        private string whereclause = string.Empty;
        private string initwhereclause = " and (SaleFlag=1)";
        private void LoadData()
        {

            this.dtblIniPrds = this.accPrds.GetDataProductByFreeSearch(this.whereclause).Tables[0];
            this.dtblIniPrds.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds;
        }
        void ctrlPrdTypeID_AffterSelected()
        {
            this.whereclause = this.initwhereclause;
            this.whereclause += " and (PrdTypeID=" + this.ctrlPrdTypeID.PrdTypeID.ToString() + ")";
            this.LoadData();
        }
        void ctrlQFind_BeforeFilter()
        {
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds;
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.initwhereclause;
            if (this.ckbPrdCode.Checked)
            {
                this.whereclause += "and (PrdCode like '%" + this.txtPrdCode.Text + "%')";
            }
            if (this.ckbPrdName.Checked)
            {
                this.whereclause += "and (PrdName like '%" + this.txtPrdName.Text + "%')";
            }
            if (this.ckbPrdSpec.Checked)
            {
                this.whereclause += "and (PrdSpec like '%" + this.txtPrdSpec.Text + "%')";
            }
            if (this.ckbModel.Checked)
            {
                this.whereclause += " and (Model like '%" + this.txtModel.Text + "%')";
            }
            if (this.ckbManufacturer.Checked)
            {
                this.whereclause += " and (Manufacturer like '%" + this.txtManufacturer.Text + "%')";
            }
            if (this.ckbAssistantCode.Checked)
            {
                this.whereclause += " and (AssistantCode like '%" + this.txtAssistantCode.Text + "%')";
            }
            this.LoadData();
        }

      
        public delegate void AffterSelectedDelegate(DataRow drow);
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
      

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            DataRow drow=this.dtblPrds .DefaultView [irow].Row ;
            int PrdID = (int)drow["PrdID"];
            string dir = string.Empty;           
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImgs.Name)
            {
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString();
                if (this.frmImgBrowse == null)
                {
                    this.frmImgBrowse = new JCommon.FrmImgBrowse();
                    new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
                    this.frmImgBrowse.ReadOnly = true;
                }
                this.frmImgBrowse.Browse(dir);
                this.frmImgBrowse.ShowDialog();
            }

        }
        void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.Cells[this.ColumnCheckedFlag.Name].Value == DBNull.Value) continue;
                if ((bool)grow.Cells[this.ColumnCheckedFlag.Name].Value == false) continue;
                if (this.affterSelected != null) this.affterSelected(this.dtblPrds.DefaultView[grow.Index].Row);
            }

        }
    }
}