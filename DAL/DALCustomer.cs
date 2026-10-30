using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public partial class DLL
    {
        public async Task<string> AddCustomerVerification(BALCommon obj)
        {
            string result = "";
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Mode", obj.Mode),
                new SqlParameter("@MobileNo", obj.MobileNumber),
                new SqlParameter("@OTP", obj.OTP),
                new SqlParameter("@Result", "")
            };
            //string[] pName = { "@Mode", "@MobileNo","@OTP" };
            //string[] pValue = { obj.Mode, obj.MobileNumber,obj.OTP };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_InsertUpdateDeleteCustomer", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(()=>SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertUpdateDeleteCustomer", CommandType.StoredProcedure,param.ToArray())).ConfigureAwait(false);
        }

        public async Task<string> InsertUpdateDeleteCustomer(BALCustomer obj)
        {
            string result = "";
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Mode", obj.Mode),
                new SqlParameter("@MobileNo", obj.MobileNumber),
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@CustomerCode", obj.CustomerCode),
                new SqlParameter("@CustPassword", obj.CustomerPassword),
                new SqlParameter("@Solutation", obj.Solutation),
                new SqlParameter("@CustomerName", obj.CustomerName),
                new SqlParameter("@EmailId", obj.CustomerEmail),
                new SqlParameter("@CreatedBy", obj.CreatedBy),
                new SqlParameter("@Result", "")
            };
            //string[] pName = { "@Mode", "@MobileNo", "@CustomerId", "@CustomerCode", "@CustPassword", "@Solutation", "@CustomerName", "@EmailId", "@CreatedBy" };
            //string[] pValue = { obj.Mode, obj.MobileNumber, obj.CustomerId, obj.CustomerCode, obj.CustomerPassword, obj.Solutation, obj.CustomerName, obj.CustomerEmail, obj.CreatedBy };
            //result = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureINSERT("spORG_InsertUpdateDeleteCustomer", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertUpdateDeleteCustomer", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
    }
}
