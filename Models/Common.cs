using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FabulousWorkplaceWebsite.Models
{
    public class Common
    {
        public static bool SendEmail(string EmailTo, string EmailFrom, string EmailSubject, string EmailBody, string EmailCC = null)
        {
            bool Result = false;
            try
            {
                if (Convert.ToString(Convert.ToString(ConfigurationManager.AppSettings["IsMailSendFlag"])) == "true")
                {
                    MailMessage mail = new MailMessage();
                    //mail.From = new MailAddress(EmailFrom);
                    mail.From = new MailAddress(EmailFrom, ConfigurationManager.AppSettings["EmailDisplayName"]);
                    mail.To.Add(EmailTo);
                    if (!string.IsNullOrEmpty(EmailCC))
                    {
                        mail.CC.Add(EmailCC);
                    }
                    mail.Subject = EmailSubject;
                    mail.IsBodyHtml = true;
                    mail.Body = EmailBody;
                    SmtpClient Smtpobj = new SmtpClient(Convert.ToString(ConfigurationManager.AppSettings["Host"]));
                    Smtpobj.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                    Smtpobj.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["EmailUsername"]), Convert.ToString(ConfigurationManager.AppSettings["EmailPassword"]));
                    Smtpobj.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailSSL"]);
                    Smtpobj.Send(mail);
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                Common.errorlog(Convert.ToString(ex.Message) + " Inner Msg:" + Convert.ToString(ex.StackTrace), "SendEmail", "Common");
            }
            return Result;
        }

        public static void errorlog(string error, string method, string controller)
        {
            string Path = HttpContext.Current.Server.MapPath("~/Error.txt");
            string Contents = "\n DateTime: " + DateTime.Now + "\n===========================\n Method Name: " + method + "\n Error: \n" + error + "\n controller: \n" + controller;
            File.AppendAllText(Path, Contents);
        }

    }
}