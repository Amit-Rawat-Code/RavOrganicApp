using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BAL;
using DAL;
using RavOrganicAPI.Models;
using static System.Net.WebRequestMethods;

namespace RavOrganicAPI.Controllers
{
    public class MobileVerificationApiController : ApiController
    {
        string controllerName = "MobileVerificationApi";
        string actionName;
        private static Dictionary<string, string> mobileOtpDictionary = new Dictionary<string, string>();
        [System.Web.Http.HttpPost]
        public IHttpActionResult SendOtp(BALCommon obj)
        {
            string _mess = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "SendOtp";
                actionName = "SendOtp";

                if (string.IsNullOrEmpty(obj.MobileNumber))
                {
                    return BadRequest("Mobile number is required.");
                }
                if (obj.MobileNumber.Length != 10)
                {
                    return BadRequest("Invalid Mobile number.");
                }
                if (!obj.MobileNumber.All(char.IsDigit))
                {
                    return BadRequest("Invalid Mobile number.");
                }
                // Generate a 6-digit OTP
                var otp = new Random().Next(100000, 999999).ToString();
                mobileOtpDictionary[obj.MobileNumber] = otp;

                string msg = "Dear Customer your OTP for Mobile Verification is " + otp + " TANTRASH";
                string temltID = ConfigurationManager.AppSettings["OTP"].ToString();
                if (OrgOtherApis.SendSMS(temltID, obj.MobileNumber, msg))
                {
                    _mess = "OTP sent successfully.";
                }
                else
                {
                    _mess = "There is something wrong, please try after sometime.";
                }
                return Ok(new { OTP = otp, Message = _mess });
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> VerifyOTP(BALCommon obj)
        {
            DataTable dt = null;
            string _mess = "";
            string _sts = "";
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "VerifyOTP";
                actionName = "VerifyOTP";

                if (string.IsNullOrEmpty(obj.MobileNumber) || string.IsNullOrEmpty(obj.OTP))
                {
                    _sts = "ERROR";
                    _mess = "Mobile number and OTP are required.";
                }
                Dictionary<string, object> dictRow = null;
                // Check if the provided OTP matches the stored OTP
                if (mobileOtpDictionary.ContainsKey(obj.MobileNumber) && mobileOtpDictionary[obj.MobileNumber] == obj.OTP)
                {
                    obj.Mode = "VERIFICATION";
                    // OTP is correct, remove the entry (if necessary)
                    string result = await DLL.dLL.AddCustomerVerification(obj).ConfigureAwait(false);
                    if (result.Length > 3)
                    {
                        BALCustomer _customer = Newtonsoft.Json.JsonConvert.DeserializeObject<BALCustomer>(result.Replace("[", "").Replace("]", ""));

                        mobileOtpDictionary.Remove(obj.MobileNumber);
                        dictRow = new Dictionary<string, object>();
                        dictRow.Add("CustomerId", _customer.CustomerId);
                        dictRow.Add("CustomerCode", _customer.CustomerCode);
                        dictRow.Add("CustomerPassword", _customer.CustomerPassword);
                        dictRow.Add("Solutation", _customer.Solutation);
                        dictRow.Add("CustomerName", _customer.CustomerName);
                        dictRow.Add("CustomerEmail", _customer.CustomerEmail);

                        _sts = "OK";
                        _mess = "Mobile number verified successfully.";
                        return Json(new { STATUS = _sts, MESSAGE = _mess, COUNT = "1", RECORD = dictRow });
                    }
                    else
                    {
                        _sts = "ERROR";
                        _mess = "Mobile number not verified, Please check your number.";
                        return Json(new { STATUS = _sts, MESSAGE = _mess, COUNT = "0", RECORD = "" });
                    }
                }
                else
                {
                    _sts = "ERROR";
                    _mess = "Invalid OTP.";
                    return Json(new { STATUS = _sts, MESSAGE = _mess, COUNT = "0", RECORD = "" });
                }                
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
                return Json(new { STATUS = "ERROR", MESSAGE = ex.Message });
            }
        }
    }
}
