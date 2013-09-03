using System;
using System.Security.Principal;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Reports_PendingCallReport : System.Web.UI.Page
{
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindSite();

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
    protected void BindSite()
    {
        colSite = objSite.Get_All();
        for (int i = 0; i < colSite.Count; i++)
        {
            for (int j = i; j < colSite.Count; j++)
            {

                if (String.Compare(colSite[i].Sitename, colSite[j].Sitename) > 0)
                {
                    Site_mst obj = new Site_mst();
                    obj = colSite[i];
                    colSite[i] = colSite[j];
                    colSite[j] = obj;

                }
            }

        }
        drpsite.DataTextField = "sitename";
        drpsite.DataValueField = "siteid";
        drpsite.DataSource = colSite;
        drpsite.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drpsite.Items.Add(item);
        //item.Text = "---Select Site---";
        //item.Value = "0";
        //drpsite.Items.Add(item);
        drpsite.SelectedValue = "0";

    }
    protected void btnViewreport_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardate;

            string siteid;

            siteid = drpsite.SelectedValue;
            ReportParameter[] Param = new ReportParameter[1];

            Param[0] = new ReportParameter("siteid", siteid);
            ReportViewer1.Attributes.Add("style", "overflow:auto;");
            ReportViewer1.ShowCredentialPrompts = false;
            ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/Pendingcallreport";
            ReportViewer1.ServerReport.SetParameters(Param);
            ReportViewer1.ServerReport.Refresh();
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
