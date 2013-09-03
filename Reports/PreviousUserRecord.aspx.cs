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

public partial class Reports_PreviousUserRecord : System.Web.UI.Page
{
    Asset_Inventory_mst objAsset = new Asset_Inventory_mst();
    BLLCollection<Asset_Inventory_mst> colAsset = new BLLCollection<Asset_Inventory_mst>();
    Asset_OperatingSystem_mst objoper = new Asset_OperatingSystem_mst();
    BLLCollection<Asset_OperatingSystem_mst> colAssetop = new BLLCollection<Asset_OperatingSystem_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!Page.IsPostBack)
            {
                //bind asset
                BindAsset();
                //bind user
                BindUser();

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
    protected void BindAsset()
    {
        colAsset = objAsset.Get_All();
        DdlistAsset.DataTextField = "ComputerName";
        DdlistAsset.DataValueField = "ComputerName";
        DdlistAsset.DataSource = colAsset;
        DdlistAsset.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        DdlistAsset.Items.Add(item);
        DdlistAsset.SelectedValue = "0";
    }
    protected void BindUser()
    {
        colAssetop = objoper.Get_Users();
        DdlistUser.DataTextField = "user_name";
        DdlistUser.DataValueField = "user_name";
        DdlistUser.DataSource = colAssetop;
        DdlistUser.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        DdlistUser.Items.Add(item);
        DdlistUser.SelectedValue = "0";
    }
    protected void btnViewreport_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
        string vardate;
        string vardate1;
        string assetname;
        string username;
        string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
        vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
        assetname = DdlistAsset.SelectedValue;
        username = DdlistUser.SelectedValue;
        ReportParameter[] Param = new ReportParameter[4];
        Param[0] = new ReportParameter("AssetName", assetname);
        Param[1] = new ReportParameter("username", username);
        Param[2] = new ReportParameter("inventorydatefrom", vardate);
        Param[3] = new ReportParameter("inventorydateTo", vardate1);
        ReportViewerUserRecord.Attributes.Add("style", "overflow:auto;");
        ReportViewerUserRecord.ShowCredentialPrompts = false;
        ReportViewerUserRecord.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
        ReportViewerUserRecord.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewerUserRecord.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
        ReportViewerUserRecord.ServerReport.ReportPath = "/BESTREPORT/PreviousUserTrack";
        ReportViewerUserRecord.ServerReport.SetParameters(Param);
        ReportViewerUserRecord.ServerReport.Refresh();
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
