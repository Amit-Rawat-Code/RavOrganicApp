using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace RavOrganicAPI.Models
{
    public class OrgOtherApis
    {
        public static bool SendSMS(string dltTemplatID, string mobile, string msg)
        {
            try
            {
                string SMSAPI = ConfigurationManager.AppSettings["SMSAPI"].ToString();
                SMSAPI = SMSAPI.Replace("[AND]", "&");
                SMSAPI = SMSAPI.Replace("[MOBILE]", mobile);
                SMSAPI = SMSAPI.Replace("[MESSAGE]", msg);
                SMSAPI = SMSAPI.Replace("[TEMPLATEID]", "" + dltTemplatID + "");

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(new Uri(SMSAPI, false));
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();

                myResp.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}