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
    /// 表[DGProDefine]数据实体类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016-09-03 15:21:58
    ///</时间>  
    public class DGProDefineEntity
    {
        public DGProDefineEntity()
        {
            this.accData = new JERPData.Product.DGProDefine();
        }
        private JERPData.Product.DGProDefine accData;
        public int Fid = -1;
        public string FFieldName = string.Empty;
        public string Fvisable = string.Empty;
        public int FType = -1;
        public string FFieldType = string.Empty;
        public string FFieldText = string.Empty;
        public string FTypeSrcID = string.Empty;
        public string FSrcTable = string.Empty;
        public void LoadData(int Fid)
        {
            this.Fid = Fid;
            DataTable dtbl = this.accData.GetDataDGProDefineByFid(Fid).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.FFieldName = string.Empty;
                this.Fvisable = string.Empty;
                this.FType = -1;
                this.FFieldType = string.Empty;
                this.FFieldText = string.Empty;
                this.FTypeSrcID = string.Empty;
                this.FSrcTable = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["FFieldName"] == DBNull.Value)
            {
                this.FFieldName = string.Empty;
            }
            else
            {
                this.FFieldName = drow["FFieldName"].ToString();
            }
            if (drow["Fvisable"] == DBNull.Value)
            {
                this.Fvisable = string.Empty;
            }
            else
            {
                this.Fvisable = drow["Fvisable"].ToString();
            }
            if (drow["FType"] == DBNull.Value)
            {
                this.FType = -1;
            }
            else
            {
                this.FType = (int)drow["FType"];
            }
            if (drow["FFieldType"] == DBNull.Value)
            {
                this.FFieldType = string.Empty;
            }
            else
            {
                this.FFieldType = drow["FFieldType"].ToString();
            }
            if (drow["FFieldText"] == DBNull.Value)
            {
                this.FFieldText = string.Empty;
            }
            else
            {
                this.FFieldText = drow["FFieldText"].ToString();
            }
            if (drow["FTypeSrcID"] == DBNull.Value)
            {
                this.FTypeSrcID = string.Empty;
            }
            else
            {
                this.FTypeSrcID = drow["FTypeSrcID"].ToString();
            }
            if (drow["FSrcTable"] == DBNull.Value)
            {
                this.FSrcTable = string.Empty;
            }
            else
            {
                this.FSrcTable = drow["FSrcTable"].ToString();
            }
        }
    }
}