using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace JERPBiz.Base
{
    public class TableDesignEntity
    {
        public TableDesignEntity()
        {
            this.accData = new JERPData.Base.TableDesign();
        }
        private JERPData.Base.TableDesign accData;
        public int ID = -1;
        public string FType = string.Empty;
        public string FTable = string.Empty;
        public int FTableIndex = -1;
        public string FColType = string.Empty;
        public string FColField = string.Empty;
        public string FColFieldText = string.Empty;
        public string FControlType = string.Empty;
        public bool FVisable = false;
        public bool FEnable = false;
        public bool FSave = false;
        public bool FIsSource = false;
        public string FSoureTable = string.Empty;
        public string FSoureTableType = string.Empty;
        public string FSoureFilter = string.Empty;
        public string FOther = string.Empty;
        public void LoadData(String FType)
        {
            DataTable dtbl = this.accData.GetDataTableDesignByFType(FType).Tables[0];
            if (dtbl.Rows.Count == 0)
            {
                this.ID = -1;
                this.FType = string.Empty;
                this.FTable = string.Empty;
                this.FTableIndex = -1;
                this.FColType = string.Empty;
                this.FColField = string.Empty;
                this.FColFieldText = string.Empty;
                this.FControlType = string.Empty;
                this.FVisable = false;
                this.FEnable = false;
                this.FSave = false;
                this.FIsSource = false;
                this.FSoureTable = string.Empty;
                this.FSoureTableType = string.Empty;
                this.FSoureFilter = string.Empty;
                this.FOther = string.Empty;
                return;
            }
            DataRow drow = dtbl.Rows[0];
            if (drow["FType"] == DBNull.Value)
            {
                this.FType = string.Empty;
            }
            else
            {
                this.FType = drow["FType"].ToString();
            }
            if (drow["FTable"] == DBNull.Value)
            {
                this.FTable = string.Empty;
            }
            else
            {
                this.FTable = drow["FTable"].ToString();
            }
            if (drow["FTableIndex"] == DBNull.Value)
            {
                this.FTableIndex = -1;
            }
            else
            {
                this.FTableIndex = (int)drow["FTableIndex"];
            }
            if (drow["FColType"] == DBNull.Value)
            {
                this.FColType = string.Empty;
            }
            else
            {
                this.FColType = drow["FColType"].ToString();
            }
            if (drow["FColField"] == DBNull.Value)
            {
                this.FColField = string.Empty;
            }
            else
            {
                this.FColField = drow["FColField"].ToString();
            }
            if (drow["FColFieldText"] == DBNull.Value)
            {
                this.FColFieldText = string.Empty;
            }
            else
            {
                this.FColFieldText = drow["FColFieldText"].ToString();
            }
            if (drow["FControlType"] == DBNull.Value)
            {
                this.FControlType = string.Empty;
            }
            else
            {
                this.FControlType = drow["FControlType"].ToString();
            }
            if (drow["FVisable"] == DBNull.Value)
            {
                this.FVisable = false;
            }
            else
            {
                this.FVisable = (bool)drow["FVisable"];
            }
            if (drow["FEnable"] == DBNull.Value)
            {
                this.FEnable = false;
            }
            else
            {
                this.FEnable = (bool)drow["FEnable"];
            }
            if (drow["FSave"] == DBNull.Value)
            {
                this.FSave = false;
            }
            else
            {
                this.FSave = (bool)drow["FSave"];
            }
            if (drow["FIsSource"] == DBNull.Value)
            {
                this.FIsSource = false;
            }
            else
            {
                this.FIsSource = (bool)drow["FIsSource"];
            }
            if (drow["FSoureTable"] == DBNull.Value)
            {
                this.FSoureTable = string.Empty;
            }
            else
            {
                this.FSoureTable = drow["FSoureTable"].ToString();
            }
            if (drow["FSoureTableType"] == DBNull.Value)
            {
                this.FSoureTableType = string.Empty;
            }
            else
            {
                this.FSoureTableType = drow["FSoureTableType"].ToString();
            }
            if (drow["FSoureFilter"] == DBNull.Value)
            {
                this.FSoureFilter = string.Empty;
            }
            else
            {
                this.FSoureFilter = drow["FSoureFilter"].ToString();
            }
            if (drow["FOther"] == DBNull.Value)
            {
                this.FOther = string.Empty;
            }
            else
            {
                this.FOther = drow["FOther"].ToString();
            }
        }
    }

}
