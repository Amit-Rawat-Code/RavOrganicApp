using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Diagnostics;

namespace DAL
{
    public partial class DLL
    {
        public static readonly DLL dLL = new DLL();

        public async Task<DataTable> GroupList()
        {
            DataTable dt = null;
            //await Task.Delay(10000);
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GroupMasterList")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GroupMasterList", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> SubGroupList(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@GroupHeaderID", obj.GroupHeaderID)
            };
            //string[] pName = { "@GroupHeaderID" };
            //string[] pValue = { obj.GroupHeaderID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_SubGroupMasterList", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_SubGroupMasterList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> GroupWiseProductList( BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@GroupHeaderID", obj.GroupHeaderID)
            };
            //string[] pName = { "@GroupHeaderID" };
            //string[] pValue = { obj.GroupHeaderID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GroupMasterDetail", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GroupMasterDetail", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> SubGroupWiseProductList(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@GroupHeaderID", obj.GroupHeaderID)
            };
            //string[] pName = { "@GroupHeaderID" };
            //string[] pValue = { obj.GroupHeaderID};
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_SubGroupMasterDetail", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_SubGroupMasterDetail", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> CategoryList()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetCategoryList")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetCategoryList", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> TrendingProductList()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetTrendingProduct")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetTrendingProduct", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> CategorywiseProduct()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetCategorywiseProduct")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetCategorywiseProduct", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> LatestProduct()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetLatestProduct")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetLatestProduct", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> ProductsList(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@SubcategoryID", obj.SubcategoryID)
            };
            //string[] pName = { "@SubcategoryID" };
            //string[] pValue = { obj.SubcategoryID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetProductListCategorywise", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetProductListCategorywise", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> SearchProducts(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@searchtext", obj.SearchText)
            };
            //string[] pName = { "@searchtext" };
            //string[] pValue = { obj.SearchText };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetProductSearchResult", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetProductSearchResult", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> ProductDetail(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@productID", obj.ProductID)
            };
            //string[] pName = { "@productID" };
            //string[] pValue = { obj.ProductID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetProductDetail", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetProductDetail", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> BannerMasterForWeb()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetBannerMasterForWeb")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetBannerMasterForWeb", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> BannerMasterForApp()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetBannerMasterForApp")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetBannerMasterForApp", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
        public async Task<DataTable> RecentlyViewedProducts(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@ProductIDs", obj.ProductIDs)
            };
            //string[] pName = { "@ProductIDs" };
            //string[] pValue = { obj.ProductIDs };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetProductDetailListForRecentlyViewed", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetProductDetailListForRecentlyViewed", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> SimilarProductList(BALProduct obj)
        {
            DataTable dt = null;
            var param = new List<SqlParameter>
            {
                new SqlParameter("@proid", obj.ProductID)
            };
            //string[] pName = { "@proid" };
            //string[] pValue = { obj.ProductID };
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTable("spORG_GetSimilarProductList", pName, pValue)).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteParameterizedSelectCommand("spORG_GetSimilarProductList", CommandType.StoredProcedure, param.ToArray())).ConfigureAwait(false);
        }
        public async Task<DataTable> ComboProductOfferList()
        {
            DataTable dt = null;
            //return dt = await Task.Factory.StartNew(() => DALBase.sql.ExecuteProcedureWithDataTableWithoutPara("spORG_GetComboProductOfferList")).ConfigureAwait(false);
            return dt = await Task.Factory.StartNew(() => SqlDBHelper.sqlDBHelper.ExecuteSelectCommand("spORG_GetComboProductOfferList", CommandType.StoredProcedure)).ConfigureAwait(false);
        }
    }
}
