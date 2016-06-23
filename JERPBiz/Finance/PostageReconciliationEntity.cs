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
namespace JERPBiz.Finance
{
    /// <描述>
    /// 表[PostageReconciliations]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/22 20:44:24
    ///</时间>  
    public class PostageReconciliationEntity
    {
        public PostageReconciliationEntity()
        {
            this.accData = new JERPData.Finance.PostageReconciliations();
        }
        private JERPData.Finance.PostageReconciliations accData;
        public long ReconciliationID = -1;
        public string ReconciliationCode = string.Empty;
        public string ReconciliationName = string.Empty;
        public int CompanyID = -1;
        public int Year = -1;
        public int Month = -1;
        public DateTime DateNote = DateTime.MinValue;
        public DateTime DateSettle = DateTime.MinValue;
        public int MakerPsnID = -1;
        public decimal TotalAMT = 0;
        public decimal FinishedAMT = 0;
        public decimal NonFinishedAMT = 0;
        public string CompanyName = string.Empty;
        public string MakerPsn = string.Empty;
        public void LoadData(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            DataTable dtbl = this.accData.GetDataPostageReconciliationsByReconciliationID(ReconciliationID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.ReconciliationCode = string.Empty;
                this.ReconciliationName = string.Empty;
                this.CompanyID = -1;
                this.Year = -1;
                this.Month = -1;
                this.DateNote = DateTime.MinValue;
                this.DateSettle = DateTime.MinValue;
                this.MakerPsnID = -1;
                this.TotalAMT = 0;
                this.FinishedAMT = 0;
                this.NonFinishedAMT = 0;
                this.CompanyName = string.Empty;
                this.MakerPsn = string.Empty;
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
            if (drow["CompanyID"] == DBNull.Value)
            {
                this.CompanyID = -1;
            }
            else
            {
                this.CompanyID = (int)drow["CompanyID"];
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
            if (drow["DateSettle"] == DBNull.Value)
            {
                this.DateSettle = DateTime.MinValue;
            }
            else
            {
                this.DateSettle = (DateTime)drow["DateSettle"];
            }
            if (drow["MakerPsnID"] == DBNull.Value)
            {
                this.MakerPsnID = -1;
            }
            else
            {
                this.MakerPsnID = (int)drow["MakerPsnID"];
            }
            if (drow["TotalAMT"] == DBNull.Value)
            {
                this.TotalAMT = 0;
            }
            else
            {
                this.TotalAMT = (decimal)drow["TotalAMT"];
            }
            if (drow["FinishedAMT"] == DBNull.Value)
            {
                this.FinishedAMT = 0;
            }
            else
            {
                this.FinishedAMT = (decimal)drow["FinishedAMT"];
            }
            if (drow["NonFinishedAMT"] == DBNull.Value)
            {
                this.NonFinishedAMT = 0;
            }
            else
            {
                this.NonFinishedAMT = (decimal)drow["NonFinishedAMT"];
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
        }
    }
}