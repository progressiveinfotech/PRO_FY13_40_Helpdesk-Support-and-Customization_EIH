using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;

public partial class admin_AppSetting : System.Web.UI.Page
{
    XmlDocument loResource = new XmlDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadResource();
        }
    }
    protected void LoadResource()
    {
        loResource.Load(Server.MapPath("~/App_LocalResources/resouce.resx"));
        XmlNode loservername = loResource.SelectSingleNode("root/data[@name='serverNameForChangePage']/value");
        XmlNode lomailserver = loResource.SelectSingleNode("root/data[@name='strMailServer']/value");
        XmlNode loadminmail = loResource.SelectSingleNode("root/data[@name='strAdminEmail']/value");
        XmlNode lolevel1esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel1Escalate']/value");
        XmlNode lolevel2esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel2Escalate']/value");
        XmlNode lolevel3esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel3Escalate']/value");
        XmlNode lostrcontactno = loResource.SelectSingleNode("root/data[@name='strContactNumber']/value");
        XmlNode loCallReporingtime = loResource.SelectSingleNode("root/data[@name='strCallReportingTime']/value");
        XmlNode loAutoCalls = loResource.SelectSingleNode("root/data[@name='strAutoCallsLogging']/value");
        XmlNode loenabletechnicianmapping = loResource.SelectSingleNode("root/data[@name='strTechnicianMapping']/value");
        XmlNode lostrfeedbackmode = loResource.SelectSingleNode("root/data[@name='strFeedBackMode']/value");
        txtservername.Text=loservername.InnerText;
        txtmailserver.Text = lomailserver.InnerText;
        txtadminmailid.Text = loadminmail.InnerText;
        txtlevel1esc.Text = lolevel1esc.InnerText;
        txtlevel2esc.Text = lolevel2esc.InnerText;
        txtlevel3esc.Text = lolevel3esc.InnerText;
        txtcontactno.Text = lostrcontactno.InnerText;
        DdlCallReportingTime.SelectedValue = loCallReporingtime.InnerText;
        DdlAutoCallLogging.SelectedValue = loAutoCalls.InnerText;
        if(loenabletechnicianmapping.InnerText=="1")
        {
            chkbxtechmapping.Checked = true;
        }
        if (lostrfeedbackmode.InnerText == "0")
        {
            Ddlfeedbackmode.SelectedItem.Selected = false;
            Ddlfeedbackmode.Items.FindByValue("0").Selected = true;
        }
        else
        {
            Ddlfeedbackmode.SelectedItem.Selected = false;
            Ddlfeedbackmode.Items.FindByText("Call wise").Selected = true;
        }
    }
   protected void BtnSave_Click(object sender, EventArgs e)
    {
        loResource.Load(Server.MapPath("~/App_LocalResources/resouce.resx"));
        XmlNode loservername = loResource.SelectSingleNode("root/data[@name='serverNameForChangePage']/value");
        XmlNode lomailserver = loResource.SelectSingleNode("root/data[@name='strMailServer']/value");
        XmlNode lomailserver2 = loResource.SelectSingleNode("root/data[@name='strSMTPServer']/value");
        XmlNode loadminmail = loResource.SelectSingleNode("root/data[@name='strAdminEmail']/value");
        XmlNode lolevel1esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel1Escalate']/value");
        XmlNode lolevel2esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel2Escalate']/value");
        XmlNode lolevel3esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel3Escalate']/value");
        XmlNode lostrcontactno = loResource.SelectSingleNode("root/data[@name='strContactNumber']/value");
        XmlNode loCallReporingtime = loResource.SelectSingleNode("root/data[@name='strCallReportingTime']/value");
        XmlNode loAutoCalls = loResource.SelectSingleNode("root/data[@name='strAutoCallsLogging']/value");
        XmlNode loenabletechnicianmapping = loResource.SelectSingleNode("root/data[@name='strTechnicianMapping']/value");
        XmlNode lostrfeedbackmode = loResource.SelectSingleNode("root/data[@name='strFeedBackMode']/value");
        loservername.InnerText = txtservername.Text;
        lomailserver.InnerText = txtmailserver.Text;
        lomailserver2.InnerText = txtmailserver.Text;
        loadminmail.InnerText = txtadminmailid.Text;
        lolevel1esc.InnerText = txtlevel1esc.Text;
        lolevel2esc.InnerText = txtlevel2esc.Text;
        lolevel3esc.InnerText = txtlevel3esc.Text;
        lostrcontactno.InnerText = txtcontactno.Text;
        loCallReporingtime.InnerText = DdlCallReportingTime.SelectedValue;
        loAutoCalls.InnerText = DdlAutoCallLogging.SelectedValue;
        if (chkbxtechmapping.Checked)
        {
            loenabletechnicianmapping.InnerText = "1";
        }
        else
        {
            loenabletechnicianmapping.InnerText = "0";
        }
        if (Ddlfeedbackmode.SelectedItem.Value == "1")
        {
            lostrfeedbackmode.InnerText = "1";
        }
        else
        {
            lostrfeedbackmode.InnerText = "0";
        }
        loResource.Save(Server.MapPath("~/App_LocalResources/resouce.resx"));
        lblMessage.Text = "Record Updated successfully";
    }
}
