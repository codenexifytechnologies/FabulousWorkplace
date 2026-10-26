using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        // GET: PrivacyPolicy
        [Route("workplace-PrivacyPolicy")]
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}