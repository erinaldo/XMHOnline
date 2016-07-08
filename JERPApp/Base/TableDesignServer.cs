using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Base
{
    public class TableDesignServer
    {
        JERPData.Base.TableDesign tableDesign;
        void Init()
        {
            tableDesign = new JERPData.Base.TableDesign();
        }

        private void initDgrdv(ref JCommon.MyDataGridView dgrdv, String type)
        {
            List<JERPBiz.Base.TableDesignEntity> tableDesignEntityList = new List<JERPBiz.Base.TableDesignEntity>();
            tableDesignEntityList = tableDesignList(type);


            for (int i = 0; i < tableDesignEntityList.Count; i++)
            {
                JERPBiz.Base.TableDesignEntity tableDesignEntity = tableDesignEntityList[i];

                String table = tableDesignEntity.FTable;  //表名
                String fieldName = tableDesignEntity.FColField;//字段名
                bool visable = tableDesignEntity.FVisable;//是否可见
                int index = tableDesignEntity.FTableIndex; //顺序
                string fieldText = tableDesignEntity.FColFieldText;//显示列名称
                bool isSource = tableDesignEntity.FIsSource;//是否有来源
                String controlType = tableDesignEntity.FControlType; //控件类型
                String soureTable = tableDesignEntity.FSoureTable; //来源表
                String soureFilter = tableDesignEntity.FSoureFilter;//过滤条件


                if (controlType.Equals("COMBOX")){
                    DataGridViewComboBoxColumn colbox = getDataGridViewComboBoxColumn(tableDesignEntity);


                    dgrdv.Columns.Add(colbox);
                }else if 
                    (controlType.Equals("TEXT")){
                        DataGridViewTextBoxColumn textbox = getDataGridViewTextBoxColumn(tableDesignEntity);
                        dgrdv.Columns.Add(textbox);
                }else{
                    //DataGridViewComboBoxColumn colbox = getDataGridViewComboBoxColumn(tableDesignEntity);
                    //dgrdv.Columns.Add(colbox);
                }
              
            }
        }


        private DataGridViewComboBoxColumn getDataGridViewComboBoxColumn(JERPBiz.Base.TableDesignEntity tableDesignEntity)
        {
            DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
            colbox.HeaderText = tableDesignEntity.FColFieldText;
            colbox.DataPropertyName = tableDesignEntity.FColField;
            colbox.Visible = tableDesignEntity.FVisable;
            colbox.DataSource = getDataFromSrc(tableDesignEntity.FTable, tableDesignEntity.FSoureFilter);
            return colbox;
        }

        private DataGridViewTextBoxColumn getDataGridViewTextBoxColumn(JERPBiz.Base.TableDesignEntity tableDesignEntity)
        {
            DataGridViewTextBoxColumn textbox = new DataGridViewTextBoxColumn();
            textbox.HeaderText = tableDesignEntity.FColFieldText;
            textbox.DataPropertyName = tableDesignEntity.FColField;
            textbox.Visible = tableDesignEntity.FVisable;
            return textbox;
        }

        private DataSet getDataFromSrc(String Table, String filter)
        {
            DataSet set = new DataSet();
            return set;
            //        int TypeSrcID = Int32.Parse(FTypeSrcID);
            //        colbox.DataSource = this.accDGPJPrdTyprPro.GetDataComTypeProByParentID(TypeSrcID).Tables[0];

        }

        private List<JERPBiz.Base.TableDesignEntity> tableDesignList(String type)
        {

            DataSet ds = tableDesign.GetDataTableDesignByFType(type);
            List<JERPBiz.Base.TableDesignEntity> tableDesignEntityList = new List<JERPBiz.Base.TableDesignEntity>();
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                DataRow drow = ds.Tables[0].Rows[row];

                JERPBiz.Base.TableDesignEntity tableDesignEntity = new JERPBiz.Base.TableDesignEntity();

                if (drow["FType"] == DBNull.Value)
                {
                    tableDesignEntity.FType = string.Empty;
                }
                else
                {
                    tableDesignEntity.FType = drow["FType"].ToString();
                }
                if (drow["FTable"] == DBNull.Value)
                {
                    tableDesignEntity.FTable = string.Empty;
                }
                else
                {
                    tableDesignEntity.FTable = drow["FTable"].ToString();
                }
                if (drow["FTableIndex"] == DBNull.Value)
                {
                    tableDesignEntity.FTableIndex = -1;
                }
                else
                {
                    tableDesignEntity.FTableIndex = (int)drow["FTableIndex"];
                }
                if (drow["FColType"] == DBNull.Value)
                {
                    tableDesignEntity.FColType = string.Empty;
                }
                else
                {
                    tableDesignEntity.FColType = drow["FColType"].ToString();
                }
                if (drow["FColField"] == DBNull.Value)
                {
                    tableDesignEntity.FColField = string.Empty;
                }
                else
                {
                    tableDesignEntity.FColField = drow["FColField"].ToString();
                }
                if (drow["FColFieldText"] == DBNull.Value)
                {
                    tableDesignEntity.FColFieldText = string.Empty;
                }
                else
                {
                    tableDesignEntity.FColFieldText = drow["FColFieldText"].ToString();
                }
                if (drow["FControlType"] == DBNull.Value)
                {
                    tableDesignEntity.FControlType = string.Empty;
                }
                else
                {
                    tableDesignEntity.FControlType = drow["FControlType"].ToString();
                }
                if (drow["FVisable"] == DBNull.Value)
                {
                    tableDesignEntity.FVisable = false;
                }
                else
                {
                    tableDesignEntity.FVisable = (bool)drow["FVisable"];
                }
                if (drow["FEnable"] == DBNull.Value)
                {
                    tableDesignEntity.FEnable = false;
                }
                else
                {
                    tableDesignEntity.FEnable = (bool)drow["FEnable"];
                }
                if (drow["FSave"] == DBNull.Value)
                {
                    tableDesignEntity.FSave = false;
                }
                else
                {
                    tableDesignEntity.FSave = (bool)drow["FSave"];
                }
                if (drow["FIsSource"] == DBNull.Value)
                {
                    tableDesignEntity.FIsSource = false;
                }
                else
                {
                    tableDesignEntity.FIsSource = (bool)drow["FIsSource"];
                }
                if (drow["FSoureTable"] == DBNull.Value)
                {
                    tableDesignEntity.FSoureTable = string.Empty;
                }
                else
                {
                    tableDesignEntity.FSoureTable = drow["FSoureTable"].ToString();
                }
                if (drow["FSoureTableType"] == DBNull.Value)
                {
                    tableDesignEntity.FSoureTableType = string.Empty;
                }
                else
                {
                    tableDesignEntity.FSoureTableType = drow["FSoureTableType"].ToString();
                }
                if (drow["FSoureFilter"] == DBNull.Value)
                {
                    tableDesignEntity.FSoureFilter = string.Empty;
                }
                else
                {
                    tableDesignEntity.FSoureFilter = drow["FSoureFilter"].ToString();
                }
                if (drow["FOther"] == DBNull.Value)
                {
                    tableDesignEntity.FOther = string.Empty;
                }
                else
                {
                    tableDesignEntity.FOther = drow["FOther"].ToString();
                }
                tableDesignEntityList.Add(tableDesignEntity);
            }

            return tableDesignEntityList;

        }

    }
}
