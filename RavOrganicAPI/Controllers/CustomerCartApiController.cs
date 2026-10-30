using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Web.Http.Cors;

namespace RavOrganicAPI.Controllers
{
    public class CustomerCartApiController : ApiController
    {
        string controllerName = "CustomerCartApi";
        string actionName;
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddCustomerCart(BALCart obj)
        {
            string _sts = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "AddCustomerCart";
                actionName = "AddCustomerCart";

                obj.CartJsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(obj.CartJsonData);

                string result = await DLL.dLL.InsertUpdateDeleteCart(obj).ConfigureAwait(false);
                if(result.Length > 3)
                {
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
                else
                {
                    _sts = "ERROR";
                    _mess = "Failed";
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
    }
}
