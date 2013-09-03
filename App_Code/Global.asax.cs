using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;

using System.Net.Mail;

/// <summary>
/// Summary description for Global
/// </summary>
namespace WebRole1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
           // string strerror = "";
           // if (Request.Params["aspxerrorpath"] != null)
           // {
           //     strerror = Request.Params["aspxerrorpath"].ToString();
           // }

           //string str = ConfigurationManager.AppSettings["RedirectOnError"].ToString();
           ////if (str.ToUpper().Trim() == "TRUE")
           //if (strerror != "")
           // {
           //     string url = "Host not found.";
           //     string errmsg = "Not determine error.";

           //     Exception ex = Server.GetLastError().GetBaseException();

           //     //bool processError = true;

           //     if (Server.GetLastError() != null)
           //     {
           //         //url = "http://" + Request.Url.Host + Request.Path;
           //         url = Request.Url.AbsoluteUri;
           //         errmsg = Server.GetLastError().ToString();
           //     }

           //     try
           //     {

           //         //if (ex.Message.Contains("invalid webresource"))
           //         //{
           //         //    processError = false;
           //         //}
           //         //if (processError == true)
           //         //{
           //         string _ToSend = ConfigurationSettings.AppSettings["SendErrorTo"].ToString();
           //         try
           //         {

           //             sendMail(_ToSend.Trim(), "Error in HT", ErrorHtml(url, errmsg), "pipl.noida@progressive.in");
           //             Response.Redirect("~/UnderCon.aspx");
           //             Server.ClearError();

           //         }
           //         catch(Exception exx)
           //         {
           //             // Response.Redirect("Default.aspx");
           //         }
           //         //}
           //     }
           //     catch(Exception exx)
           //     {

           //     }
           //     //Response.Redirect("~/UnderCon.aspx");
           //     //Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["ErrorPageURL"].ToString());
           // }
        }

        private string ErrorHtml(string url, string errmsg)
        {
            string FinalMsg = "";
            FinalMsg += "<html>";
            FinalMsg += "<body>";
            FinalMsg += "<font face='Verdana' size='2'>";

            FinalMsg += "<strong>A error has been detected in : </strong>";
            FinalMsg += url;

            FinalMsg += "<br><strong>On : </strong>";
            FinalMsg += DateTime.Now.ToString() + " by " + System.Net.Dns.GetHostName().ToString() + "/" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "</font>";

            FinalMsg += "<hr>";
            FinalMsg += ("<pre><font size='3'>" + errmsg + "</font></pre>");

            FinalMsg += "</body>";
            FinalMsg += "</html>";

            return FinalMsg;
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public void sendMail(string Sendmail, string subject, string body, string From)
        {
            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(From);
            myMessage.To.Add(Sendmail);
            myMessage.Subject = subject;
            myMessage.IsBodyHtml = true;
            myMessage.Body = body.ToString();
            SmtpClient mySmtpClient = new SmtpClient();
            // System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("prachi.sharma@progressive.in", "pipl?123");
            mySmtpClient.Host = "10.1.0.12";
            //  mySmtpClient.UseDefaultCredentials = false;
            //mySmtpClient.Credentials = myCredential;
            //  mySmtpClient.ServicePoint.MaxIdleTime = 1;
            //mySmtpClient.Port = 110;
            mySmtpClient.Send(myMessage);
            myMessage.Dispose();
        }
    }
}
