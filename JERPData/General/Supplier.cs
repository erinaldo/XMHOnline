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
    /// 表[general.Supplier]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-01-18 09:17:28
    ///</时间>  
    public class Supplier
    {
        private SqlConnection sqlConn;
        public Supplier()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteSupplier(ref string ErrorMsg, object CompanyID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.DeleteSupplier", arParams);
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
        public DataSet GetDataSupplier()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplier");
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
        public bool GetParmSupplierCompanyID(string CompanyAbbName, ref int CompanyID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyAbbName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyAbbName;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "general.GetParmSupplierCompanyID", arParams);
                CompanyID = (int)arParams[1].Value;
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
        public DataSet GetDataSupplierByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataSupplierByCompanyID", arParams);
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

        public DataSet GetDataSupplierForMaterial()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForMaterial");
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
        public DataSet GetDataSupplierForOtherRes()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForOtherRes");
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
        public DataSet GetDataSupplierForOutSrc()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForOutSrc");
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
        public DataSet GetDataSupplierForProduct()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForProduct");
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
        public DataSet GetDataSupplierForTool()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForTool");
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

        public DataSet GetDataSupplierForSolution()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "general.GetDataSupplierForSolution");
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


        public bool InsertSupplier(ref string ErrorMsg, ref object CompanyID, object CompanyCode, object CompanyAbbName, object CompanyAllName, object LegalPerson, object MtrFlag, object PrdFlag, object OtherResFlag, object ToolFlag, object OutSrcFlag, object SolutionFlag, object Linkman, object Telephone, object Mobile, object Fax, object QQ, object Wechat, object Email, object URL, object Address, object BankInfor, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[22];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@CompanyAbbName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@CompanyAllName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@LegalPerson", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@MtrFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@PrdFlag", SqlDbType.Bit);
            arParams[7] = new SqlParameter("@OtherResFlag", SqlDbType.Bit);
            arParams[8] = new SqlParameter("@ToolFlag", SqlDbType.Bit);
            arParams[9] = new SqlParameter("@OutSrcFlag", SqlDbType.Bit);
            arParams[10] = new SqlParameter("@SolutionFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@Linkman", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@Fax", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@QQ", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@Wechat", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@Email", SqlDbType.VarChar);
            arParams[17].Size = 100;
            arParams[18] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@Address", SqlDbType.VarChar);
            arParams[19].Size = 100;
            arParams[20] = new SqlParameter("@BankInfor", SqlDbType.VarChar);
            arParams[20].Size = 200;
            arParams[21] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[21].Size = 200;
            arParams[0].Value = CompanyID;
            arParams[1].Value = CompanyCode;
            arParams[2].Value = CompanyAbbName;
            arParams[3].Value = CompanyAllName;
            arParams[4].Value = LegalPerson;
            arParams[5].Value = MtrFlag;
            arParams[6].Value = PrdFlag;
            arParams[7].Value = OtherResFlag;
            arParams[8].Value = ToolFlag;
            arParams[9].Value = OutSrcFlag;
            arParams[10].Value = SolutionFlag;
            arParams[11].Value = Linkman;
            arParams[12].Value = Telephone;
            arParams[13].Value = Mobile;
            arParams[14].Value = Fax;
            arParams[15].Value = QQ;
            arParams[16].Value = Wechat;
            arParams[17].Value = Email;
            arParams[18].Value = URL;
            arParams[19].Value = Address;
            arParams[20].Value = BankInfor;
            arParams[21].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.InsertSupplier", arParams);
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
        public bool UpdateSupplier(ref string ErrorMsg, object CompanyID, object CompanyCode, object CompanyAbbName, object CompanyAllName, object LegalPerson, object MtrFlag, object PrdFlag, object OtherResFlag, object ToolFlag, object OutSrcFlag, object SolutionFlag, object Linkman, object Telephone, object Mobile, object Fax, object QQ, object Wechat, object Email, object URL, object Address, object BankInfor, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[22];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@CompanyAbbName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@CompanyAllName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@LegalPerson", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@MtrFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@PrdFlag", SqlDbType.Bit);
            arParams[7] = new SqlParameter("@OtherResFlag", SqlDbType.Bit);
            arParams[8] = new SqlParameter("@ToolFlag", SqlDbType.Bit);
            arParams[9] = new SqlParameter("@OutSrcFlag", SqlDbType.Bit);
            arParams[10] = new SqlParameter("@SolutionFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@Linkman", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@Telephone", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@Mobile", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@Fax", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@QQ", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@Wechat", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@Email", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@Address", SqlDbType.VarChar);
            arParams[19].Size = 100;
            arParams[20] = new SqlParameter("@BankInfor", SqlDbType.VarChar);
            arParams[20].Size = 200;
            arParams[21] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[21].Size = 200;
            arParams[0].Value = CompanyID;
            arParams[1].Value = CompanyCode;
            arParams[2].Value = CompanyAbbName;
            arParams[3].Value = CompanyAllName;
            arParams[4].Value = LegalPerson;
            arParams[5].Value = MtrFlag;
            arParams[6].Value = PrdFlag;
            arParams[7].Value = OtherResFlag;
            arParams[8].Value = ToolFlag;
            arParams[9].Value = OutSrcFlag;
            arParams[10].Value = SolutionFlag;
            arParams[11].Value = Linkman;
            arParams[12].Value = Telephone;
            arParams[13].Value = Mobile;
            arParams[14].Value = Fax;
            arParams[15].Value = QQ;
            arParams[16].Value = Wechat;
            arParams[17].Value = Email;
            arParams[18].Value = URL;
            arParams[19].Value = Address;
            arParams[20].Value = BankInfor;
            arParams[21].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdateSupplier", arParams);
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
        public bool UpdateSupplierForDateLastOrder(ref string ErrorMsg, object CompanyID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdateSupplierForDateLastOrder", arParams);
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