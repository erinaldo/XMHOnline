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
namespace JERPData.General
{
    /// <描述>
    /// 表[general.PotentialCustomer]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-04-24 19:28:06
    ///</时间>  
    public class PotentialCustomer
    {
        private SqlConnection sqlConn;
        public PotentialCustomer()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataPotentialCustomerByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataPotentialCustomerByCompanyID", arParams);
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
        public DataSet GetDataPotentialCustomerBySalePsnID(int SalePsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@SalePsnID", SqlDbType.Int);
            arParams[0].Value = SalePsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataPotentialCustomerBySalePsnID", arParams);
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
         
        public DataSet GetDataPotentialCustomerPsnProcessRpt()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataPotentialCustomerPsnProcessRpt");
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
        public DataSet GetDataPotentialCustomerFreeSearch(string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WhereClause", SqlDbType.NVarChar);
            arParams[0].Size = -1;
            arParams[0].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataPotentialCustomerFreeSearch", arParams);
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
        public DataSet GetDataPotentialCustomerPsnRegisterMonthRpt(int Year)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[0].Value = Year;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataPotentialCustomerPsnRegisterMonthRpt", arParams);
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

        public DataSet GetDataPotentialCustomerForPause(bool PauseFlag)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PauseFlag", SqlDbType.Bit);
            arParams[0].Value = PauseFlag;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataPotentialCustomerForPause", arParams);
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
        public bool GetParmPotentialCustomerSalePsnID(int CompanyID, ref int SalePsnID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@SalePsnID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "general.GetParmPotentialCustomerSalePsnID", arParams);
                SalePsnID = (int)arParams[1].Value;
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

        public DataSet GetDataPotentialCustomerForPublic()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataPotentialCustomerForPublic");
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


        public bool InsertPotentialCustomer(ref string ErrorMsg, ref object CompanyID, object DateRegister, object SourceTypeID, object RegisterPsnID, object CompanyName, object Linkman, object Telephone, object Mobile, object QQ, object Wechat, object Email, object URL, object Address, object Memo, object SalePsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[15];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@DateRegister", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@CompanyName", SqlDbType.VarChar);
            arParams[4].Size = 100;
            arParams[5] = new SqlParameter("@Linkman", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@QQ", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@Wechat", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@Email", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@Address", SqlDbType.VarChar);
            arParams[12].Size = 200;
            arParams[13] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[13].Size = 200;
            arParams[14] = new SqlParameter("@SalePsnID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            arParams[1].Value = DateRegister;
            arParams[2].Value = SourceTypeID;
            arParams[3].Value = RegisterPsnID;
            arParams[4].Value = CompanyName;
            arParams[5].Value = Linkman;
            arParams[6].Value = Telephone;
            arParams[7].Value = Mobile;
            arParams[8].Value = QQ;
            arParams[9].Value = Wechat;
            arParams[10].Value = Email;
            arParams[11].Value = URL;
            arParams[12].Value = Address;
            arParams[13].Value = Memo;
            arParams[14].Value = SalePsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.InsertPotentialCustomer", arParams);
                CompanyID = arParams[0].Value;
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
        public bool UpdatePotentialCustomer(ref string ErrorMsg, object CompanyID, object CompanyName, object Linkman, object Telephone, object Mobile, object QQ, object Wechat, object Email, object URL, object Address, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@CompanyName", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@Linkman", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@QQ", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@Wechat", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Email", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@Address", SqlDbType.VarChar);
            arParams[9].Size = 200;
            arParams[10] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[10].Size = 200;
            arParams[0].Value = CompanyID;
            arParams[1].Value = CompanyName;
            arParams[2].Value = Linkman;
            arParams[3].Value = Telephone;
            arParams[4].Value = Mobile;
            arParams[5].Value = QQ;
            arParams[6].Value = Wechat;
            arParams[7].Value = Email;
            arParams[8].Value = URL;
            arParams[9].Value = Address;
            arParams[10].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdatePotentialCustomer", arParams);
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
        public bool UpdatePotentialCustomerForPause(ref string ErrorMsg, object CompanyID, object PauseFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PauseFlag", SqlDbType.Bit);
            arParams[0].Value = CompanyID;
            arParams[1].Value = PauseFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdatePotentialCustomerForPause", arParams);
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
        public bool UpdatePotentialCustomerForProcess(ref string ErrorMsg, object CompanyID, object ProcessTypeID, object DateContact, object ResultContact, object DateNextContact)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DateContact", SqlDbType.DateTime);
            arParams[3] = new SqlParameter("@ResultContact", SqlDbType.VarChar);
            arParams[3].Size = 200;
            arParams[4] = new SqlParameter("@DateNextContact", SqlDbType.DateTime);
            arParams[0].Value = CompanyID;
            arParams[1].Value = ProcessTypeID;
            arParams[2].Value = DateContact;
            arParams[3].Value = ResultContact;
            arParams[4].Value = DateNextContact;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdatePotentialCustomerForProcess", arParams);
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
        public bool UpdatePotentialCustomerForSalePsn(ref string ErrorMsg, object CompanyID, object SalePsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@SalePsnID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            arParams[1].Value = SalePsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdatePotentialCustomerForSalePsn", arParams);
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
        public bool UpdatePotentialCustomerForSuccess(ref string ErrorMsg, object CompanyID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdatePotentialCustomerForSuccess", arParams);
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