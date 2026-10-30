using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DALExceptionLog
    {
        public static void ExceptionLog(string _mess,string stacktrace,string _controler, string _action)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@strMessage", _mess),
                new SqlParameter("@strExcpDsc", stacktrace),
                new SqlParameter("@strController", _controler),
                new SqlParameter("@strAction", _action),
                new SqlParameter("@Result", "")
            };
            string _resultT = SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_ExceptionLog", CommandType.StoredProcedure, param.ToArray());
        }
    }
}
