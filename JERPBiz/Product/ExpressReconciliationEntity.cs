/*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
namespace JERPBiz.Product
{
    /// <描述>
    /// 表[ExpressReconciliation]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-31 07:03:55
    ///</时间>  
    public class ExpressReconciliationEntity
    {
        public ExpressReconciliationEntity()
        {
            this.accData = new JERPData.Product.ExpressReconciliations();
        }
        private JERPData.Product.ExpressReconciliations accData;
        public long ReconciliationID = -1;
        public string ReconciliationCode = string.Empty;
        public string ReconciliationName = string.Empty;
        public int SerialNo = -1;
        public int Year = -1;
        public int Month = -1;
        public DateTime DateNote = DateTime.MinValue;
        public int CompanyID = -1;
        public int MoneyTypeID = -1;
        public decimal TotalAMT = -1;
        public decimal FinishedAMT = -1;
        public decimal NonFinishedAMT = -1;
        public int MakerPsnID = -1;
        public string CompanyName = string.Empty;
        public string MakerPsn = string.Empty;
        public string MoneyTypeName = string.Empty;
        public void LoadData(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            DataTable dtbl = this.accData.GetDataExpressReconciliationsByReconciliationID(ReconciliationID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.ReconciliationCode = string.Empty;
                this.ReconciliationName = string.Empty;
                this.SerialNo = -1;
                this.Year = -1;
                this.Month = -1;
                this.DateNote = DateTime.MinValue;
                this.CompanyID = -1;
                this.MoneyTypeID = -1;
                this.TotalAMT = -1;
                this.FinishedAMT = -1;
                this.NonFinishedAMT = -1;
                this.MakerPsnID = -1;
                this.CompanyName = string.Empty;
                this.MakerPsn = string.Empty;
                this.MoneyTypeName = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["ReconciliationCode"] == DBNull.Value)
            {
                this.ReconciliationCode = string.Empty;
            }
            else
            {
                this.ReconciliationCode = drow["ReconciliationCode"].ToString();
            }
            if (drow["ReconciliationName"] == DBNull.Value)
            {
                this.ReconciliationName = string.Empty;
            }
            else
            {
                this.ReconciliationName = drow["ReconciliationName"].ToString();
            }
            if (drow["SerialNo"] == DBNull.Value)
            {
                this.SerialNo = -1;
            }
            else
            {
                this.SerialNo = (int)drow["SerialNo"];
            }
            if (drow["Year"] == DBNull.Value)
            {
                this.Year = -1;
            }
            else
            {
                this.Year = (int)drow["Year"];
            }
            if (drow["Month"] == DBNull.Value)
            {
                this.Month = -1;
            }
            else
            {
                this.Month = (int)drow["Month"];
            }
            if (drow["DateNote"] == DBNull.Value)
            {
                this.DateNote = DateTime.MinValue;
            }
            else
            {
                this.DateNote = (DateTime)drow["DateNote"];
            }
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
            }
            if (drow["MoneyTypeID"] == DBNull.Value)
            {
                this.MoneyTypeID = -1;
            }
            else
            {
                this.MoneyTypeID = (int)drow["MoneyTypeID"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = -1;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["FinishedAMT"] == DBNull.Value)
            {
                this.FinishedAMT = -1;
            }
            else
            {
                this.FinishedAMT = (decimal)drow["FinishedAMT"];
            }
            if (drow["NonFinishedAMT"] == DBNull.Value)
            {
                this.NonFinishedAMT = -1;
            }
            else
            {
                this.NonFinishedAMT = (decimal)drow["NonFinishedAMT"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["CompanyName"] == DBNull.Value)
            {
                this.CompanyName = string.Empty;
            }
            else
            {
                this.CompanyName = drow["CompanyName"].ToString();
            }
            if (drow["MakerPsn"] == DBNull.Value)
            {
                this.MakerPsn = string.Empty;
            }
            else
            {
                this.MakerPsn = drow["MakerPsn"].ToString();
            }
            if (drow["MoneyTypeName"] == DBNull.Value)
            {
                this.MoneyTypeName = string.Empty;
            }
            else
            {
                this.MoneyTypeName = drow["MoneyTypeName"].ToString();
            }
        }
    }
}