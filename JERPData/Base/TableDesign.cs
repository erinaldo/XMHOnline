using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Base
{
    public class TableDesign
    {
        private SqlConnection sqlConn;
        public TableDesign()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataTableDesignByFType(string FType)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FType", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[0].Value = FType;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "Base.GetDataTableDesignByFType", arParams);
            }
            catch//(SqlException ex)
            {
                // ex.Message --这里作调试用
            }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }



        public bool InsertTableDesign(ref string ErrorMsg, ref object ID, object FType, object FTable, object FTableIndex, 
            object FColType, object FColField, object FColFieldText, object FControlType, object FVisable, object FEnable, 
            object FSave, object FIsSource, object FSoureTable, object FSoureTableType, object FSoureFilter, object FOther)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[16];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@FType", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@FTable", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@FTableIndex", SqlDbType.Int);
            arParams[4] = new SqlParameter("@FColType", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FColField", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@FColFieldText", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@FControlType", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FVisable", SqlDbType.Bit);
            arParams[9] = new SqlParameter("@FEnable", SqlDbType.Bit);
            arParams[10] = new SqlParameter("@FSave", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@FIsSource", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@FSoureTable", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@FSoureTableType", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@FSoureFilter", SqlDbType.VarChar);
            arParams[14].Size = 500;
            arParams[15] = new SqlParameter("@FOther", SqlDbType.VarChar);
            arParams[15].Size = 500;
            arParams[0].Value = ID;
            arParams[1].Value = FType;
            arParams[2].Value = FTable;
            arParams[3].Value = FTableIndex;
            arParams[4].Value = FColType;
            arParams[5].Value = FColField;
            arParams[6].Value = FColFieldText;
            arParams[7].Value = FControlType;
            arParams[8].Value = FVisable;
            arParams[9].Value = FEnable;
            arParams[10].Value = FSave;
            arParams[11].Value = FIsSource;
            arParams[12].Value = FSoureTable;
            arParams[13].Value = FSoureTableType;
            arParams[14].Value = FSoureFilter;
            arParams[15].Value = FOther;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "Base.InsertTableDesign", arParams);
                ID = arParams[0].Value;
                DBTransaction.Commit();
                flag = true;
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message; //返回错误信息
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }


        public bool UpdateTableDesign(ref string ErrorMsg, object ID, object FType, object FTable, object FTableIndex, object FColType, 
            object FColField, object FColFieldText, object FControlType, object FVisable, object FEnable, object FSave, object FIsSource, 
            object FSoureTable, object FSoureTableType, object FSoureFilter, object FOther)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[16];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@FType", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@FTable", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@FTableIndex", SqlDbType.Int);
            arParams[4] = new SqlParameter("@FColType", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FColField", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@FColFieldText", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@FControlType", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FVisable", SqlDbType.Bit);
            arParams[9] = new SqlParameter("@FEnable", SqlDbType.Bit);
            arParams[10] = new SqlParameter("@FSave", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@FIsSource", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@FSoureTable", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@FSoureTableType", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@FSoureFilter", SqlDbType.VarChar);
            arParams[14].Size = 500;
            arParams[15] = new SqlParameter("@FOther", SqlDbType.VarChar);
            arParams[15].Size = 500;
            arParams[0].Value = ID;
            arParams[1].Value = FType;
            arParams[2].Value = FTable;
            arParams[3].Value = FTableIndex;
            arParams[4].Value = FColType;
            arParams[5].Value = FColField;
            arParams[6].Value = FColFieldText;
            arParams[7].Value = FControlType;
            arParams[8].Value = FVisable;
            arParams[9].Value = FEnable;
            arParams[10].Value = FSave;
            arParams[11].Value = FIsSource;
            arParams[12].Value = FSoureTable;
            arParams[13].Value = FSoureTableType;
            arParams[14].Value = FSoureFilter;
            arParams[15].Value = FOther;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "Base.UpdateTableDesign", arParams);
                DBTransaction.Commit();
                flag = true;
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message; //返回错误信息
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }

    }
}
