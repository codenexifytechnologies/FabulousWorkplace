using FabulousWorkplaceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class BlogsController : Controller
    {
        BlogManagementOperations objBlogManagementOperations = new BlogManagementOperations();

        // GET: Blogs
        [Route("Best-workplace-Blogs")]
        public ActionResult Blogs()
        {
            try
            {
                ViewBag.lstBlogManagement = objBlogManagementOperations.GetBlogsDetails();
            }
            catch (Exception Ex)
            {
            }
            return View();
        }

        [Route("Blogs/{title}")]
        public ActionResult Blog(string title)
        {
            int Id = Convert.ToInt32(Session["ID"]);
            BlogManagement objBlogManagement = objBlogManagementOperations.GetBlogsById(Id);
            return View(objBlogManagement);
        }

        public ActionResult Blog(int Id)
        {
            Session["ID"] = Id;
            BlogManagement objBlogManagement = objBlogManagementOperations.GetBlogsById(Id);
            return RedirectToAction("Blog", new { title = objBlogManagement.WebsiteURL.Trim().Replace(" ", "-") });
        }
    }
}