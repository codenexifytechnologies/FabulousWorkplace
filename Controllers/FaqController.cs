using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        [Route("workplace-Faq")]
        public ActionResult Faq()
        {
            return View();
        }
    }
}