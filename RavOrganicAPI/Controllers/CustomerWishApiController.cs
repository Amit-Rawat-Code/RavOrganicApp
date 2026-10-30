using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace RavOrganicAPI.Controllers
{
    public class CustomerWishApiController : ApiController
    {
        string controllerName = "CustomerWishApi";
        string actionName;
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddCustomerWish(BALCart obj)
        {
            string _mess = "";
            string _sts = "";
            string _stsCode = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "AddCustomerWish";
                actionName = "AddCustomerWish";
                obj.Mode = "INSERT";
                string result = await DLL.dLL.InsertUpdateDeleteCustomerWish(obj).ConfigureAwait(false);
                if (result.Length > 3)
                {
                    BALStatus _status = Newtonsoft.Json.JsonConvert.DeserializeObject<BALStatus>(result);
                    _stsCode = _status.Code;
                    _sts = "OK";
                    _mess = _status.Remark;
                }
                else
                {
                    _sts = "ERROR";
                    _mess = "Failed";
                }
            }
            catch (Exception ex)
            {
                _stsCode = "";
                _sts = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return Json(new { CODE = _stsCode, STATUS = _sts, MESSAGE = _mess });
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> DeleteCustomerWish(BALCart obj)
        {
            string _mess = "";
            string _sts = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "DeleteCustomerWish";
                actionName = "DeleteCustomerWish";
                obj.Mode = "DELETE";
                string result = await DLL.dLL.InsertUpdateDeleteCustomerWish(obj).ConfigureAwait(false);
                BALStatus _status = Newtonsoft.Json.JsonConvert.DeserializeObject<BALStatus>(result);
                if (_status.Code == "1")
                {
                    _sts = "OK";
                    _mess = _status.Remark;
                }
                else
                {
                    _sts = "ERROR";
                    _mess = _status.Remark;
                }
            }
            catch (Exception ex)
            {
                _sts = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return Json(new { STATUS = _sts, MESSAGE = _mess });
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> CustomerWishList(BALCart obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "CustomerWishList";
                actionName = "CustomerWishList";
                dt = await DLL.dLL.CustomerWishList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> SearchCustomerWishBYProductId(BALCart obj)
        {
            Dictionary<string, object> dictRow = null;
            string _sts = "";
            string _msg = "";
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "SearchCustomerWishBYProductId";
                actionName = "SearchCustomerWishBYProductId";
                dt = await DLL.dLL.CustomerWishList(obj).ConfigureAwait(false);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        dictRow = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            dictRow.Add(col.ColumnName, dr[col]);
                        }
                    }
                    _sts = "OK";
                    _msg = "SUCCESS";
                    return Json(new { STATUS = _sts, MESSAGE = _msg, RECORD = dictRow });
                }
                else
                {
                    _sts = "ERROR";
                    _msg = "Data not found";
                    return Json(new { STATUS = _sts, MESSAGE = _msg, RECORD = "" });
                }
            }
            catch (Exception ex)
            {
                _sts = "ERROR";
                _msg = "Exception found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
                return Json(new { STATUS = _sts, MESSAGE = _msg, RECORD = "" });
            }            
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddCustomerWishToCart(BALCart obj)
        {
            string _mess = "";
            string _sts = "";
            string _stsCode = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "AddCustomerWish";
                actionName = "AddCustomerWish";
                obj.Mode = "ADDTOCART";
                string result = await DLL.dLL.InsertUpdateDeleteCustomerWish(obj).ConfigureAwait(false);
                if (result.Length > 3)
                {
                    BALStatus _status = Newtonsoft.Json.JsonConvert.DeserializeObject<BALStatus>(result);
                    _stsCode = _status.Code;
                    _sts = "OK";
                    _mess = _status.Remark;
                }
                else
                {
                    _sts = "ERROR";
                    _mess = "Failed";
                }
            }
            catch (Exception ex)
            {
                _stsCode = "";
                _sts = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return Json(new { CODE = _stsCode, STATUS = _sts, MESSAGE = _mess });
        }
    }
}
