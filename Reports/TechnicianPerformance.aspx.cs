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

public partial class Reports_TechnicianPerformance : System.Web.UI.Page
{
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindDropSite();
                BindDropTechnician();
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
    protected void BindDropTechnician()
    {

        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        if (objRole.Roleid != 0)
        {
            int siteid = 0;
            int roleid;
            if (drpSite.SelectedValue != "") { siteid = Convert.ToInt32(drpSite.SelectedValue); }

            roleid = objRole.Roleid;
            if (siteid != 0 && roleid != 0)
            {
                colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
                //meenakshi
                for (int i = 0; i < colUser.Count; i++)
                {
                    for (int j = i; j < colUser.Count; j++)
                    {

                        if (String.Compare(colUser[i].Username, colUser[j].Username) > 0)
                        {
                            UserLogin_mst obj = new UserLogin_mst();
                            obj = colUser[i];
                            colUser[i] = colUser[j];
                            colUser[j] = obj;

                        }
                    }

                }
                //end
                drpTechnician.DataTextField = "username";
                drpTechnician.DataValueField = "userid";
                drpTechnician.DataSource = colUser;
                drpTechnician.DataBind();
                ListItem item = new ListItem();
                item.Text = "All";
                item.Value = "0";
                drpTechnician.Items.Add(item);
                //item.Text = "-----------Select-----------";
                //item.Value = "0";
                //drpTechnician.Items.Add(item);
                drpTechnician.SelectedValue = "0";

            }
            else
            {

                colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
                //meenakshi
                for (int i = 0; i < colUser.Count; i++)
                {
                    for (int j = i; j < colUser.Count; j++)
                    {

                        if (String.Compare(colUser[i].Username, colUser[j].Username) > 0)
                        {
                            UserLogin_mst obj = new UserLogin_mst();
                            obj = colUser[i];
                            colUser[i] = colUser[j];
                            colUser[j] = obj;

                        }
                    }

                }
                //end
                drpTechnician.DataTextField = "username";
                drpTechnician.DataValueField = "userid";
                drpTechnician.DataSource = colUser;
                drpTechnician.DataBind();
                ListItem item = new ListItem();
                item.Text = "All";
                item.Value = "0";
                drpTechnician.Items.Add(item);
                //item.Text = "-----------Select-----------";
                //item.Value = "0";
                //drpTechnician.Items.Add(item);
                drpTechnician.SelectedValue = "0";


            }

        }





    }
    protected void BindDropSite()
    {
        colSite = objSite.Get_All();
        drpSite.DataTextField = "sitename";
        drpSite.DataValueField = "siteid";
        drpSite.DataSource = colSite;
        drpSite.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drpSite.Items.Add(item);
        //item.Text = "-----------Select-----------";
        //item.Value = "0";
        //drpSite.Items.Add(item);
        drpSite.SelectedValue = "0";






    }

    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindDropTechnician();
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
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardate;
            string vardate1;
            string siteid;
            string technicianid;
            string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
            vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
            vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
            siteid = drpSite.SelectedValue;
            technicianid = drpTechnician.SelectedValue;
            ReportParameter[] Param = new ReportParameter[4];
            Param[0] = new ReportParameter("Fromdate", vardate);
            Param[1] = new ReportParameter("Todate", vardate1);
            Param[2] = new ReportParameter("Siteid", siteid);
            Param[3] = new ReportParameter("technicianid", technicianid);
            ReportViewer1.ShowCredentialPrompts = false;
            ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/TechnicianPerformance";
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
