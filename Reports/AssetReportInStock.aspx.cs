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
using System.Xml.Linq;


public partial class Reports_AssetReportInStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                ReportViewer1.ShowCredentialPrompts = true;
                ReportViewer1.ShowFindControls = true;
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.ShowToolBar = true;
                ReportViewer1.ShowZoomControl = true;
                ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
                ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/AssetReportInStock";
                ReportViewer1.Visible = true;
                ReportViewer1.ServerReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
}
