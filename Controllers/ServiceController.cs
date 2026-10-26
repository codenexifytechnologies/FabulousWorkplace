using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        [Route("workplace-certification-service")]
        public ActionResult Service()
        {
            return View("Service");
        }
    }
}