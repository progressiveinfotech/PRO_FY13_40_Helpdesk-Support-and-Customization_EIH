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

public partial class Reports_HTDashboard : System.Web.UI.Page
{
    Site_mst objSite = new Site_mst();
    Hub_mst objHub = new Hub_mst();
    HubToSiteMapping objhubsite = new HubToSiteMapping();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    BLLCollection<HubToSiteMapping> colhubsite = new BLLCollection<HubToSiteMapping>();
    protected void Page_Load(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                
                BindHub();
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
        //change done by meenakshi
        int hubid = 0;
         if (drpHub.SelectedValue != "")
            {
                hubid = Convert.ToInt32(drpHub.SelectedValue);
            }
           
            
            if (hubid != 0 )
            {
               colSite = objSite.Get_By_hubid_site(hubid);
               
                drpsite.DataTextField = "sitename";
                drpsite.DataValueField = "siteid";
                //drpsite.DataSource = colSite; 
                drpsite.DataSource = colSite;
                drpsite.DataBind();
                ListItem item = new ListItem();
                //item.Selected = true;
                item.Text = "All";
                item.Value = "0";
                drpsite.Items.Add(item);
                drpsite.SelectedValue = "0"; 

                
            }
            else
            {
                colSite = objSite.Get_All();
                //colSite = objSite.Get_By_hubid_site(hubid);
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
                //drpsite.DataSource = colSite;
                drpsite.DataSource = colSite;
                drpsite.DataBind();
                ListItem item = new ListItem();
                //item.Selected = true;
                item.Text = "All";
                item.Value = "0";
                drpsite.Items.Add(item);
                drpsite.SelectedValue = "0";

                
            }
        
    }
    public void BindHub()
    {
        BLLCollection<Hub_mst> col = new BLLCollection<Hub_mst>();
        col = objHub.Get_All();
        
        for (int i = 0; i < col.Count; i++)
        {
            for (int j = i; j < col.Count; j++)
            {

                if (String.Compare(col[i].Hubname, col[j].Hubname) > 0)
                {
                    Hub_mst obj = new Hub_mst();
                    obj = col[i];
                    col[i] = col[j];
                    col[j] = obj;

                }
            }

        }
        drpHub.DataTextField = "HubName";
        drpHub.DataValueField = "Hubid";
        drpHub.DataSource = col;
        drpHub.DataBind();
////////////////////////////////////////////////////// //change done by meenakshi 12 july 2102
        ListItem item = new ListItem();
        //item.Text = "--------------Select--------------";
        item.Text = "All";
        item.Value = "0";
        drpHub.Items.Add(item);
        drpHub.SelectedValue = "0";
        //item.Value = "0";
        //drpHub.Items.Add(item);
        //drpHub.SelectedValue = "0";
       

/////////////////////////////////////////////////////////////end
    }


    protected void drpHub_SelectedIndexChanged(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindSite();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnViewreport_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardate;
            string vardate1;
            string siteid;
            string hubid;

            string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
            vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
            vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
            siteid = drpsite.SelectedValue;
            hubid = drpHub.SelectedValue;

            ReportParameter[] Param = new ReportParameter[4];
            Param[0] = new ReportParameter("FromDate", vardate);
            Param[1] = new ReportParameter("ToDate", vardate1);
            // Param[2] = new ReportParameter("Site id", siteid);
            Param[2] = new ReportParameter("varSiteid", siteid);
            Param[3] = new ReportParameter("Hubid", hubid);

            ReportViewer1.Attributes.Add("style", "overflow:auto;");
            ReportViewer1.ShowCredentialPrompts = false;
            ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/HTDashboard";
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
