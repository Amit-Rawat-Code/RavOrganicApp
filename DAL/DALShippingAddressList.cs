using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;

namespace DAL
{
    public partial class DLL
    {
        public async Task<string> InsertUpdateDeleteShippingAddress(BALShippingAddress obj)
        {
            string result = "";
            var param = new List<SqlParameter> {
                new SqlParameter("@Mode", obj.Mode),
                new SqlParameter("@ShipAddressId", obj.AddressId),
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@PersonName", obj.PesronName),
                new SqlParameter("@Address", obj.ActionName),
                new SqlParameter("@AddressType", obj.AddressType),
                new SqlParameter("@IsDefault", obj.IsDefaultAddress),
                new SqlParameter("@AddressContactNo", obj.AddressContactNo),
                new SqlParameter("@State", obj.State),
                new SqlParameter("@City", obj.City),
                new SqlParameter("@Country", obj.Country),
                new SqlParameter("@Pincode", obj.PinCode),
                new SqlParameter("@CreatedBy", obj.CreatedBy),
                new SqlParameter("@Result", "")
            };
            //string[] pName = { "@Mode", "@ShipAddressId", "@CustomerId", "@PersonName", "@Address", "@AddressType", "@IsDefault", "@AddressContactNo", "@State", "@City", "@Country", "@Pincode", "@CreatedBy" };
            //string[] pValue = { obj.Mode, obj.AddressId, obj.CustomerId, obj.PesronName, obj.AddressName, obj.AddressType, obj.IsDefaultAddress, obj.AddressContactNo, obj.State, obj.City, obj.Country, obj.PinCode, obj.CreatedBy };
            //return result = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureINSERT("spORG_InsertUpdateDeleteShippingAddress", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertUpdateDeleteShippingAddress", CommandType.StoredProcedure,param.ToArray())).ConfigureAwait(false);
        }
        public async Task<string> InsertUpdateDeleteShippingAddressWithResponse(BALShippingAddress obj)
        {
            string result = "";
            var param = new List<SqlParameter> {
                new SqlParameter("@Mode", obj.Mode),
                new SqlParameter("@ShipAddressId", obj.AddressId),
                new SqlParameter("@CustomerId", obj.CustomerId),
                new SqlParameter("@PersonName", obj.PesronName),
                new SqlParameter("@Address", obj.ActionName),
                new SqlParameter("@AddressType", obj.AddressType),
                new SqlParameter("@IsDefault", obj.IsDefaultAddress),
                new SqlParameter("@AddressContactNo", obj.AddressContactNo),
                new SqlParameter("@State", obj.State),
                new SqlParameter("@City", obj.City),
                new SqlParameter("@Country", obj.Country),
                new SqlParameter("@Pincode", obj.PinCode),
                new SqlParameter("@CreatedBy", obj.CreatedBy),
                new SqlParameter("@Result", "")
            };
            //DataTable dt = null;
            //string[] pName = { "@Mode", "@ShipAddressId", "@CustomerId", "@PersonName", "@Address", "@AddressType", "@IsDefault", "@AddressContactNo", "@State", "@City", "@Country", "@Pincode", "@CreatedBy" };
            //string[] pValue = { obj.Mode, obj.AddressId, obj.CustomerId, obj.PesronName, obj.AddressName, obj.AddressType, obj.IsDefaultAddress, obj.AddressContactNo, obj.State, obj.City, obj.Country, obj.PinCode, obj.CreatedBy };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_InsertUpdateDeleteShippingAddress", pName, pValue)).ConfigureAwait(false);
            return result = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteNonQuery("spORG_InsertUpdateDeleteShippingAddress", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> ShippingAddressList(BALShippingAddress obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@CustomerId", obj.CustomerId),
            };
            //string[] pName = { "@CustomerId" };
            //string[] pValue = { obj.CustomerId };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetShippingAddressList", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetShippingAddressList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
    }
}
