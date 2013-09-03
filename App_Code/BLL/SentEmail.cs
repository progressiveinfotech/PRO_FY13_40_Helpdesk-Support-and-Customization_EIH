using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//using System.Web.Mail;
using System.Net.Mail;
using System.IO;

/// <summary>
/// Summary description for SentEmail
/// </summary>
public class SentEmail
{
    #region Private Fields

    private string _to;
    private string _from;
    private string _subject;
    private string _body;
    private string _smtpServer;

    #endregion

    #region Public Fields

    public string To
    {
        get { return _to; }
        set { _to = value; }
    }
    public string From
    {
        get { return _from; }
        set { _from = value; }
    }
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    public string Body
    {
        get { return _body; }
        set { _body = value; }
    }
    public string SmtpServer
    {
        get { return _smtpServer; }
        set { _smtpServer = value; }
    }
    #endregion

    public SentEmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void LogMessage(string sMsg)
    {
        File.AppendAllText(@"C:\ScheduledService_ClosedCalls.log", sMsg + Environment.NewLine);
    }
    public void SentMail()
    {
        try
        {
            //previous mail sending 
            //MailMessage msgMail = new MailMessage();
            //msgMail.To = To;
            //msgMail.From = From;
            //msgMail.Subject = Subject;
            //msgMail.BodyFormat = MailFormat.Html;
            //msgMail.Body = Body.ToString();
            //SmtpMail.SmtpServer = SmtpServer;
            //SmtpMail.Send(msgMail); 
            //end previous
            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(From);
            LogMessage("Close From:"+ From);
            myMessage.To.Add(To);
            LogMessage("To:" + To);
            //myMessage.CC.Add("lalit.joshi@progressive.in");
            myMessage.Subject = Subject;
            LogMessage("Subject:" + Subject);
            myMessage.IsBodyHtml = true;
            myMessage.Body = Body.ToString();
            SmtpClient mySmtpClient = new SmtpClient();
            //System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("dcoperation-gpi@Modi.com", "godfreyops");
            //mySmtpClient.Host = "10.250.1.149";
            //System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("csm.admin@progressive.in", "pipl?123");
            //mySmtpClient.Host = "10.1.0.12";
            //mySmtpClient.UseDefaultCredentials = false;
            //mySmtpClient.Credentials = myCredential;
            mySmtpClient.ServicePoint.MaxIdleTime = 1;
            //mySmtpClient.Port = 25;
            mySmtpClient.Send(myMessage);
            LogMessage("Mail Sent");
            myMessage.Dispose();
                   
        }
        catch (Exception ex)
        {

        }
    }
}

