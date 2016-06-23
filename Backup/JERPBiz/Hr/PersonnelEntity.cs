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
namespace JERPBiz.Hr
{
    /// <描述>
    /// 表[Personnel]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/8/3 21:31:38
    ///</时间>  
    public class PersonnelEntity
    {
        public PersonnelEntity()
        {
            this.accData = new JERPData.Hr.Personnel();
        }
        private JERPData.Hr.Personnel accData;
        public int PsnID = -1;
        public string PsnCode = string.Empty;
        public string PsnName = string.Empty;
        public string Sex = string.Empty;
        public string DeptName = string.Empty;
        public string Position = string.Empty;
        public string Nation = string.Empty;
        public DateTime DateHire = DateTime.MinValue;
        public string ProbationMonth = string.Empty;
        public string Province = string.Empty;
        public string Diploma = string.Empty;
        public string IDCode = string.Empty;
        public string IDAddress = string.Empty;
        public string Telephone = string.Empty;
        public string BankCode = string.Empty;
        public string BankName = string.Empty;
        public bool RoomFlag = false;
        public string RoomNo = string.Empty;
        public string Description = string.Empty;
        public DateTime DateDismiss = DateTime.MinValue;
        public bool EngineerFlag = false;
        public int SignImgCount = -1;
        public int PortraitImgCount = -1;
        public void LoadData(int PsnID)
        {
            this.PsnID = PsnID;
            DataTable dtbl = this.accData.GetDataPersonnelByPsnID(PsnID).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.PsnCode = string.Empty;
                this.PsnName = string.Empty;
                this.Sex = string.Empty;
                this.DeptName = string.Empty;
                this.Position = string.Empty;
                this.Nation = string.Empty;
                this.DateHire = DateTime.MinValue;
                this.ProbationMonth = string.Empty;
                this.Province = string.Empty;
                this.Diploma = string.Empty;
                this.IDCode = string.Empty;
                this.IDAddress = string.Empty;
                this.Telephone = string.Empty;
                this.BankCode = string.Empty;
                this.BankName = string.Empty;
                this.RoomFlag = false;
                this.RoomNo = string.Empty;
                this.Description = string.Empty;
                this.DateDismiss = DateTime.MinValue;
                this.EngineerFlag = false;
                this.SignImgCount = -1;
                this.PortraitImgCount = -1;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["PsnCode"] == DBNull.Value)
            {
                this.PsnCode = string.Empty;
            }
            else
            {
                this.PsnCode = drow["PsnCode"].ToString();
            }
            if (drow["PsnName"] == DBNull.Value)
            {
                this.PsnName = string.Empty;
            }
            else
            {
                this.PsnName = drow["PsnName"].ToString();
            }
            if (drow["Sex"] == DBNull.Value)
            {
                this.Sex = string.Empty;
            }
            else
            {
                this.Sex = drow["Sex"].ToString();
            }
            if (drow["DeptName"] == DBNull.Value)
            {
                this.DeptName = string.Empty;
            }
            else
            {
                this.DeptName = drow["DeptName"].ToString();
            }
            if (drow["Position"] == DBNull.Value)
            {
                this.Position = string.Empty;
            }
            else
            {
                this.Position = drow["Position"].ToString();
            }
            if (drow["Nation"] == DBNull.Value)
            {
                this.Nation = string.Empty;
            }
            else
            {
                this.Nation = drow["Nation"].ToString();
            }
            if (drow["DateHire"] == DBNull.Value)
            {
                this.DateHire = DateTime.MinValue;
            }
            else
            {
                this.DateHire = (DateTime)drow["DateHire"];
            }
            if (drow["ProbationMonth"] == DBNull.Value)
            {
                this.ProbationMonth = string.Empty;
            }
            else
            {
                this.ProbationMonth = drow["ProbationMonth"].ToString();
            }
            if (drow["Province"] == DBNull.Value)
            {
                this.Province = string.Empty;
            }
            else
            {
                this.Province = drow["Province"].ToString();
            }
            if (drow["Diploma"] == DBNull.Value)
            {
                this.Diploma = string.Empty;
            }
            else
            {
                this.Diploma = drow["Diploma"].ToString();
            }
            if (drow["IDCode"] == DBNull.Value)
            {
                this.IDCode = string.Empty;
            }
            else
            {
                this.IDCode = drow["IDCode"].ToString();
            }
            if (drow["IDAddress"] == DBNull.Value)
            {
                this.IDAddress = string.Empty;
            }
            else
            {
                this.IDAddress = drow["IDAddress"].ToString();
            }
            if (drow["Telephone"] == DBNull.Value)
            {
                this.Telephone = string.Empty;
            }
            else
            {
                this.Telephone = drow["Telephone"].ToString();
            }
            if (drow["BankCode"] == DBNull.Value)
            {
                this.BankCode = string.Empty;
            }
            else
            {
                this.BankCode = drow["BankCode"].ToString();
            }
            if (drow["BankName"] == DBNull.Value)
            {
                this.BankName = string.Empty;
            }
            else
            {
                this.BankName = drow["BankName"].ToString();
            }
            if (drow["RoomFlag"] == DBNull.Value)
            {
                this.RoomFlag = false;
            }
            else
            {
                this.RoomFlag = (bool)drow["RoomFlag"];
            }
            if (drow["RoomNo"] == DBNull.Value)
            {
                this.RoomNo = string.Empty;
            }
            else
            {
                this.RoomNo = drow["RoomNo"].ToString();
            }
            if (drow["Description"] == DBNull.Value)
            {
                this.Description = string.Empty;
            }
            else
            {
                this.Description = drow["Description"].ToString();
            }
            if (drow["DateDismiss"] == DBNull.Value)
            {
                this.DateDismiss = DateTime.MinValue;
            }
            else
            {
                this.DateDismiss = (DateTime)drow["DateDismiss"];
            }
            if (drow["EngineerFlag"] == DBNull.Value)
            {
                this.EngineerFlag = false;
            }
            else
            {
                this.EngineerFlag = (bool)drow["EngineerFlag"];
            }
            if (drow["SignImgCount"] == DBNull.Value)
            {
                this.SignImgCount = -1;
            }
            else
            {
                this.SignImgCount = (int)drow["SignImgCount"];
            }
            if (drow["PortraitImgCount"] == DBNull.Value)
            {
                this.PortraitImgCount = -1;
            }
            else
            {
                this.PortraitImgCount = (int)drow["PortraitImgCount"];
            }
        }
    }
}