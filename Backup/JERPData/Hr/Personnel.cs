/*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Hr
{
    /// <描述>
    /// 表[hr.Personnels]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2011-1-27 16:14:35
    ///</时间>  
    public class Personnel
    {
        private SqlConnection sqlConn;
        public Personnel()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataPersonnelForSale()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnelForSale");
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
        public DataSet GetDataPersonnelForEngineer()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnelForEngineer");
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
        public DataSet GetDataPersonnelOnjob()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnelOnjob");
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
        public DataSet GetDataPersonnel()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnel");
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
        public DataSet GetDataPersonnelForUser()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnelForUser");
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
        public DataSet GetDataPersonnelByPsnID(int PsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "hr.GetDataPersonnelByPsnID", arParams);
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
       
        public bool GetParmPersonnelPnsID(string PsnCode, ref int PsnID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnCode", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PsnCode;
            arParams[1].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "hr.GetParmPersonnelPnsID", arParams);
                PsnID = (int)arParams[1].Value;
                flag = true;
            }
            catch//(SqlException ex)
            {
                flag = false;
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public DataSet GetDataPersonnelByFreeSearch(string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WhereClause", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "hr.GetDataPersonnelByFreeSearch", arParams);
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
        public DataSet GetDataPersonnelOffjob()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnelOffjob");
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

        public bool InsertPersonnel(ref string ErrorMsg, ref object PsnID, object PsnCode, object PsnName, object AssistantCode, object Sex, object JobType, object DeptName, object Position, object Nation, object DateHire, object ProbationMonth, object Province, object Diploma, object IDCode, object IDAddress, object BankCode, object BankName, object Telephone, object RoomFlag, object RoomNo, object Description)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[21];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PsnCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@PsnName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@Sex", SqlDbType.VarChar);
            arParams[4].Size = 10;
            arParams[5] = new SqlParameter("@JobType", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DeptName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Position", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@Nation", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DateHire", SqlDbType.DateTime);
            arParams[10] = new SqlParameter("@ProbationMonth", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@Province", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@Diploma", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@IDCode", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@IDAddress", SqlDbType.VarChar);
            arParams[14].Size = 200;
            arParams[15] = new SqlParameter("@BankCode", SqlDbType.VarChar);
            arParams[15].Size = 100;
            arParams[16] = new SqlParameter("@BankName", SqlDbType.VarChar);
            arParams[16].Size = 100;
            arParams[17] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@RoomFlag", SqlDbType.Bit);
            arParams[19] = new SqlParameter("@RoomNo", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@Description", SqlDbType.VarChar);
            arParams[20].Size = 200;
            arParams[0].Value = PsnID;
            arParams[1].Value = PsnCode;
            arParams[2].Value = PsnName;
            arParams[3].Value = AssistantCode;
            arParams[4].Value = Sex;
            arParams[5].Value = JobType;
            arParams[6].Value = DeptName;
            arParams[7].Value = Position;
            arParams[8].Value = Nation;
            arParams[9].Value = DateHire;
            arParams[10].Value = ProbationMonth;
            arParams[11].Value = Province;
            arParams[12].Value = Diploma;
            arParams[13].Value = IDCode;
            arParams[14].Value = IDAddress;
            arParams[15].Value = BankCode;
            arParams[16].Value = BankName;
            arParams[17].Value = Telephone;
            arParams[18].Value = RoomFlag;
            arParams[19].Value = RoomNo;
            arParams[20].Value = Description;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.InsertPersonnel", arParams);
                PsnID = arParams[0].Value;
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
        public bool UpdatePersonnel(ref string ErrorMsg, object PsnID, object PsnCode, object PsnName, object AssistantCode, object Sex, object JobType, object DeptName, object Position, object Nation, object DateHire, object ProbationMonth, object Province, object Diploma, object IDCode, object IDAddress, object BankCode, object BankName, object Telephone, object RoomFlag, object RoomNo, object Description)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[21];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PsnCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@PsnName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@Sex", SqlDbType.VarChar);
            arParams[4].Size = 10;
            arParams[5] = new SqlParameter("@JobType", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DeptName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Position", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@Nation", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DateHire", SqlDbType.DateTime);
            arParams[10] = new SqlParameter("@ProbationMonth", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@Province", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@Diploma", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@IDCode", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@IDAddress", SqlDbType.VarChar);
            arParams[14].Size = 200;
            arParams[15] = new SqlParameter("@BankCode", SqlDbType.VarChar);
            arParams[15].Size = 100;
            arParams[16] = new SqlParameter("@BankName", SqlDbType.VarChar);
            arParams[16].Size = 100;
            arParams[17] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@RoomFlag", SqlDbType.Bit);
            arParams[19] = new SqlParameter("@RoomNo", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@Description", SqlDbType.VarChar);
            arParams[20].Size = 200;
            arParams[0].Value = PsnID;
            arParams[1].Value = PsnCode;
            arParams[2].Value = PsnName;
            arParams[3].Value = AssistantCode;
            arParams[4].Value = Sex;
            arParams[5].Value = JobType;
            arParams[6].Value = DeptName;
            arParams[7].Value = Position;
            arParams[8].Value = Nation;
            arParams[9].Value = DateHire;
            arParams[10].Value = ProbationMonth;
            arParams[11].Value = Province;
            arParams[12].Value = Diploma;
            arParams[13].Value = IDCode;
            arParams[14].Value = IDAddress;
            arParams[15].Value = BankCode;
            arParams[16].Value = BankName;
            arParams[17].Value = Telephone;
            arParams[18].Value = RoomFlag;
            arParams[19].Value = RoomNo;
            arParams[20].Value = Description;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnel", arParams);
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
        public bool UpdatePersonnelForOffjob(ref string ErrorMsg, object PsnID, object DateDismiss)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DateDismiss", SqlDbType.DateTime);
            arParams[0].Value = PsnID;
            arParams[1].Value = DateDismiss;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnelForOffjob", arParams);
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
        public bool UpdatePersonnelForOnjob(ref string ErrorMsg, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnelForOnjob", arParams);
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
        public bool UpdatePersonnelForEngineer(ref string ErrorMsg, object PsnID, object EngineerFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@EngineerFlag", SqlDbType.Bit);
            arParams[0].Value = PsnID;
            arParams[1].Value = EngineerFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnelForEngineer", arParams);
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

        public bool UpdatePersonnelForPortraitImgCount(ref string ErrorMsg, object PsnID, object PortraitImgCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PortraitImgCount", SqlDbType.Int);
            arParams[0].Value = PsnID;
            arParams[1].Value = PortraitImgCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnelForPortraitImgCount", arParams);
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
        public bool UpdatePersonnelForSignImgCount(ref string ErrorMsg, object PsnID, object SignImgCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@SignImgCount", SqlDbType.Int);
            arParams[0].Value = PsnID;
            arParams[1].Value = SignImgCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "hr.UpdatePersonnelForSignImgCount", arParams);
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