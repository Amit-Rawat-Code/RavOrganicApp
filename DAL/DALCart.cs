using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public partial class DLL
    {
        public async Task<string> InsertUpdateDeleteCart(BALCart obj)
        {
            string result = "";
            var param = new List<SqlParameter>
            {
                new SqlParameter("@MODE", "INSERT"),
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@JsonData", obj.CartJsonstring),
                new SqlParameter("@Result", "")
            };
            //DataTable dt = null;
            //string[] pName = { "@MODE", "@CustomerId", "@JsonData"};
            //string[] pValue = { "INSERT", obj.CustomerId, obj.CartJsonData};
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_InsertCustomerCartList", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertCustomerCartList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
    }
}
