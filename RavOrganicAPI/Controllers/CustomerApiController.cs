using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BAL;
using DAL;
using static System.Net.WebRequestMethods;

namespace RavOrganicAPI.Controllers
{
    public class CustomerApiController : ApiController
    {
        string controllerName = "CustomerApi";
        string actionName;

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddCutomerDetail(BALCustomer obj)
        {
            string _status = "";
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "AddCutomerDetail";
                actionName = "AddCutomerDetail";

                obj.Mode = "ADDCUSTOMERDETAIL";
                string result = await DLL.dLL.InsertUpdateDeleteCustomer(obj).ConfigureAwait(false);
                if (result == "2")
                {
                    _status = "OK";
                    _mess = "Customer Detail Updated successfully.";
                }
                else
                {
                    _status = "ERROR";
                    _mess = "Customer detail does not exist.";
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
    }
}
