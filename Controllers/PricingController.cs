using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class PricingController : Controller
    {
        // GET: Pricing
        [Route("Workplace-Certificate-Pricing")]
        public ActionResult Pricing()
        {
            return View();
        }
    }
}