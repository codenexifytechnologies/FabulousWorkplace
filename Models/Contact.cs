using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using FabulousWorkplaceWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace FabulousWorkplaceWebsite.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10 digit mobile number")]
        public string Mobile { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }

    public class ContactOperation
    {
        public string AddConatct(Contact objContact)
        {
            string msg = string.Empty;
            try
            {
                msg = "Thank you for contacting us. Our team will connect with you shortly.";
                string body = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/Contact.html"));
                body = body.Replace("{{name}}", objContact.Name);
                body = body.Replace("{{subject}}", objContact.Subject);
                body = body.Replace("{{message}}", objContact.Message);
                Common.SendEmail(objContact.Email, Convert.ToString(ConfigurationManager.AppSettings["FromEmail"].ToString()), ConfigurationManager.AppSettings["ContactUs"].ToString(), body);
            }
            catch (Exception ex)
            {
                Common.errorlog(Convert.ToString(ex.Message) + " Inner Msg:" + Convert.ToString(ex.StackTrace), "AddConatct", "ContactOperation");
                throw ex;
            }
            return msg;
        }
    }
}

