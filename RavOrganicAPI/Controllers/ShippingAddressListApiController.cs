using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BAL;
using DAL;

namespace RavOrganicAPI.Controllers
{
    public class ShippingAddressListApiController : ApiController
    {
        string controllerName = "ShippingAddressListApi";
        string actionName;
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddEditShippingAddress(BALShippingAddress obj)
        {
            string result = "";
            string _status = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "AddEditShippingAddress";
                actionName = "AddEditShippingAddress";
                if (obj.AddressId == null || obj.AddressId == "")
                {
                    obj.Mode = "INSERT";
                }
                else
                {
                    obj.Mode = "UPDATE";
                }
                result = await DLL.dLL.InsertUpdateDeleteShippingAddressWithResponse(obj).ConfigureAwait(false);
                if (result == "1")
                {
                    _status = "OK";
                    _mess = "Address added successfully.";
                }
                else if(result == "2")
                {
                    _status = "OK";
                    _mess = "Address updated successfully.";
                }
                else
                {
                    _status = "ERROR";
                    _mess = "Failed.";
                }
            }
            catch(Exception ex) 
            {
                _status = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }            
            return Ok(new { STATUS = _status, Message = _mess });
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> UpdateDefaultShippingAddress(BALShippingAddress obj)
        {
            string result = "";
            string _status = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "UpdateDefaultShippingAddress";
                actionName = "UpdateDefaultShippingAddress";

                obj.Mode = "CONFIRMDEFAULTADDRESS";
                result = await DLL.dLL.InsertUpdateDeleteShippingAddressWithResponse(obj).ConfigureAwait(false);
                if (result == "4")
                {
                    _status = "OK";
                    _mess = "Default address updated";
                }
                else
                {
                    _status = "ERROR";
                    _mess = "Failed.";
                }
            }
            catch (Exception ex)
            {
                _status = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return Ok(new { STATUS = _status, Message = _mess });
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> UpdateShippingAddress(BALShippingAddress obj)
        {
            string _status = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "UpdateShippingAddress";
                actionName = "UpdateShippingAddress";

                obj.Mode = "UPDATE";
                string result = await DLL.dLL.InsertUpdateDeleteShippingAddress(obj).ConfigureAwait(false);
                if (result == "2")
                {
                    _status = "OK";
                    _mess = "Address updated successfully.";
                }
            }
            catch(Exception ex)
            {
                _status = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }            
            return Ok(new { STATUS = _status, Message = _mess });
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> DeleteShippingAddress(BALShippingAddress obj)
        {
            string _status = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "DeleteShippingAddress";
                actionName = "DeleteShippingAddress";

                obj.Mode = "DELETE";
                string result = await DLL.dLL.InsertUpdateDeleteShippingAddress(obj).ConfigureAwait(false);
                if (result == "3")
                {
                    _status = "OK";
                    _mess = "Address deleted successfully.";
                }
                else if (result == "-1")
                {
                    _status = "OK";
                    _mess = "Address does not exists.";
                }
            }
            catch (Exception ex)
            {
                _status = "ERROR";
                _mess = "Exception Found";
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return Ok(new { STATUS = _status, Message = _mess });
        }
        [System.Web.Http.HttpPost]
        public  async Task<DataTable> CustomerShippingAddressList(BALShippingAddress obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "CustomerAddressList";
                actionName = "CustomerAddressList";
                dt = await DLL.dLL.ShippingAddressList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
    }
}
