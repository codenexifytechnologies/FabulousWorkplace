using FabulousWorkplaceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class IndexController : Controller
    {
        BlogManagementOperations objBlogManagementOperations = new BlogManagementOperations();

        // GET: Index
        public ActionResult Index()
        {
            TempData["Index"] = "Index";
            try
            {
                List<BlogManagement> obj = objBlogManagementOperations.GetBlogsDetails();
                ViewBag.lstBlogManagement=obj;
                Common.errorlog(obj.Count.ToString(), "Index", "Index");
            }
            catch (Exception Ex)
            {
                Common.errorlog(Ex.Message, "Index", "Index");

            }
            return View();
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}