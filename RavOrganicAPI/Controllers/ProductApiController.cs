using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using BAL;
using DAL;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace RavOrganicAPI.Controllers
{    
    public class ProductApiController : ApiController
    {
        string controllerName = "ProductApi";
        string actionName;
        public async Task<DataTable> GetGroupList()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetGroupList";                
                dt = await DLL.dLL.GroupList().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }

        [System.Web.Http.HttpPost]
        public async Task<DataTable> SubGroupList(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;                
                obj.ActionName = "SubGroupList";
                actionName = "SubGroupList";
                dt = await DLL.dLL.SubGroupList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> GroupWiseProductList(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "GroupWiseProductList";
                actionName = "GroupWiseProductList";
                dt = await DLL.dLL.GroupWiseProductList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> SubGroupWiseProductList(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "SubGroupWiseProductList";
                actionName = "SubGroupWiseProductList";
                dt = await DLL.dLL.SubGroupWiseProductList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetProductCategoryList()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetProductCategoryList";
                dt = await DLL.dLL.CategoryList().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetTrendingProductList()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetTrendingProductList";
                dt = await DLL.dLL.TrendingProductList().ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetCategorywiseProduct()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetCategorywiseProduct";
                //DALExceptionLog.ExceptionLog("TEST", "TEST", controllerName, actionName);
                dt = await DLL.dLL.CategorywiseProduct().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetLatestProduct()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetLatestProduct";
                dt = await DLL.dLL.LatestProduct().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }

        [System.Web.Http.HttpPost]
        public async Task<DataTable> ProductList(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "ProductList";
                actionName = "ProductList";
                dt = await DLL.dLL.ProductsList(obj).ConfigureAwait(false);
                //return JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> SearchProducts(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "SearchProducts";
                actionName = "SearchProducts";
                dt = await DLL.dLL.SearchProducts(obj).ConfigureAwait(false);
                //return JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<Dictionary<string, object>> ProductDetail(BALProduct obj)
        {
            Dictionary<string, object> dictRow = null;
            DataTable dt = null;
            try
            {
                obj.ControllerName = controllerName;
                obj.ActionName = "ProductDetail";
                actionName = "ProductDetail";
                dt = await DLL.dLL.ProductDetail(obj).ConfigureAwait(false);                
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
                }
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dictRow;
        }
        public async Task<DataTable> GetBannerMasterListForWeb()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetBannerMasterList";
                dt = await DLL.dLL.BannerMasterForWeb().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetBannerMasterListForApp()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetBannerMasterList";
                dt = await DLL.dLL.BannerMasterForApp().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> RecentlyViewedProducts(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                actionName = "RecentlyViewedProducts";
                dt = await DLL.dLL.RecentlyViewedProducts(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        [System.Web.Http.HttpPost]
        public async Task<DataTable> SimilarProductList(BALProduct obj)
        {
            DataTable dt = null;
            try
            {
                actionName = "SimilarProductList";
                dt = await DLL.dLL.SimilarProductList(obj).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
        public async Task<DataTable> GetComboProductOfferList()
        {
            DataTable dt = null;
            try
            {
                actionName = "GetComboProductOfferList";
                dt = await DLL.dLL.ComboProductOfferList().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                DALExceptionLog.ExceptionLog(ex.Message, ex.StackTrace, controllerName, actionName);
            }
            return dt;
        }
    }
}
