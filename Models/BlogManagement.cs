using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Models
{

    public class BlogManagement
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogOneLinerDiscription { get; set; }
        [AllowHtml]
        public string BlogDiscription { get; set; }
        public HttpPostedFileBase BlogImage1 { get; set; }
        public HttpPostedFileBase BlogImage2 { get; set; }
        public HttpPostedFileBase BlogImage3 { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int IsActive { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string WebsiteTitle { get; set; }
        public string WebsiteDescription { get; set; }
        public string WebsiteKeyword { get; set; }
        public string WebsiteURL { get; set; }

    }

    public class BlogManagementOperations
    {

        static string sqlConnStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        static SqlConnection conn = new SqlConnection(sqlConnStr);

        Common Common = new Common();
        public List<BlogManagement> GetBlogsDetails()
        {

            List<BlogManagement> lstBlogManagement = new List<BlogManagement>();
            try
            {
                var para = new DynamicParameters();
                lstBlogManagement = conn.Query<BlogManagement>("usp_GetBlogList", null, null, true, 0, CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                Common.errorlog(Convert.ToString(ex.Message) + " Inner Msg:" + Convert.ToString(ex.StackTrace), "GetBlogsDetails", "BlogManagementOperations");
            }
            return lstBlogManagement;

        }
        public BlogManagement GetBlogsById(int Id)
        {
            BlogManagement objBlogManagement = new BlogManagement();
            try
            {
                var para = new DynamicParameters();
                para.Add("@Id", Id);
                objBlogManagement = conn.Query<BlogManagement>("usp_BlogsGetById", para, null, true, 0, CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Common.errorlog(Convert.ToString(ex.Message) + " Inner Msg:" + Convert.ToString(ex.StackTrace), "GetBlogsById", "BlogManagementOperations");
            }
            return objBlogManagement;
        }
    }
}