using FabulousWorkplaceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FabulousWorkplaceWebsite.Controllers
{
    public class ContactController : Controller
    {
        ContactOperation objContactOperation = new ContactOperation();
        [Route("workplace-Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact objContact)
        {
            try
            {
                TempData["Message"] = objContactOperation.AddConatct(objContact);
                return RedirectToAction("Contact");
            }
            catch (Exception ex)
            {
                Common.errorlog(Convert.ToString(ex.Message) + " Inner Msg:" + Convert.ToString(ex.StackTrace), "Contact", "ContactController");
            }
            return View();
        }
    }
}