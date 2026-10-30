using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class DLL
    {
        public async Task<string> InsertUpdateDeleteCustomerWish(BALCart obj)
        {
            string result = "";
            var param = new List<SqlParameter>
            {
                new SqlParameter("@MODE", "INSERT"),
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@ProductId", obj.ProductID),
                new SqlParameter("@Result", "")
            };
            //DataTable dt = null;
            //string[] pName = { "@MODE", "@CustomerId", "@ProductId" };
            //string[] pValue = { obj.Mode, obj.CustomerId, obj.ProductID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_InsertUpdateDeleteCustomerWishList", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertUpdateDeleteCustomerWishList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> CustomerWishList(BALCart obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@ProductId", obj.ProductID)
            };
            //string[] pName = { "@CustomerId", "@ProductId" };
            //string[] pValue = { obj.CustomerId, obj.ProductID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetCustomerWishList", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetCustomerWishList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
    }
}
