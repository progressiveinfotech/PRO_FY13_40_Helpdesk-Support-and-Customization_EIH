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

public partial class Reports_RepeatcallAnalysis : System.Web.UI.Page
{
    Subcategory_mst objSubCategory = new Subcategory_mst();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    Title_mst objTitle = new Title_mst();
    BLLCollection<Title_mst> colTitle = new BLLCollection<Title_mst>();
    Category_mst objCategory = new Category_mst();
    Asset_mst objAsset = new Asset_mst();                                                   //coded by lalit
    BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();                    //coded by lalit
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    UserLogin_mst objuserlogin = new UserLogin_mst();
    BLLCollection<UserLogin_mst> coluser = new BLLCollection<UserLogin_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindDropCategory();
                BindDropSubCategory();
                BindTitle();
                BindUser();
                BindAsset();               //coded by lalit
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
    protected void BindDropCategory()
    {
        colCategory = objCategory.Get_All();
        drpcategory.DataTextField = "categoryname";
        drpcategory.DataValueField = "categoryid";
        drpcategory.DataSource = colCategory;
        drpcategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drpcategory.Items.Add(item);
        drpcategory.SelectedValue = "0";
    }

    protected void drpcategory_SelectedIndexChanged(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindDropSubCategory();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void BindDropSubCategory()
    {
        int categoryid = Convert.ToInt32(drpcategory.SelectedValue);

        colSubCategory = objSubCategory.Get_All_By_Categoryid(categoryid);
        drpsubcategory.DataTextField = "subcategoryname";
        drpsubcategory.DataValueField = "subcategoryid";
        drpsubcategory.DataSource = colSubCategory;
        drpsubcategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drpsubcategory.Items.Add(item);
        drpsubcategory.SelectedValue = "0";

    }
    protected void BindTitle()
    {

        int categoryid = Convert.ToInt32(drpcategory.SelectedValue);
        int subcategoryid = Convert.ToInt32(drpsubcategory.SelectedValue);
        colTitle = objTitle.Get_All_By_Categoryid(categoryid, subcategoryid);
        drptitle.DataTextField = "title";
        drptitle.DataValueField = "title";
        drptitle.DataSource = colTitle;
        drptitle.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drptitle.Items.Add(item);
    }
    protected void BindUser()
    {
        coluser = objuserlogin.Get_All();
        drpuser.DataTextField = "username";
        drpuser.DataValueField = "userid";
        drpuser.DataSource = coluser;
        drpuser.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        drpuser.Items.Add(item);
        drpuser.SelectedValue = "0";

    }

    //Coded by lalit
    protected void BindAsset()
    {
        colAsset = objAsset.Get_All();
        DrpAsset.DataTextField = "computername";
        DrpAsset.DataValueField = "assetid";
        DrpAsset.DataSource = colAsset;
        DrpAsset.DataBind();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        DrpAsset.Items.Add(item);
        DrpAsset.SelectedValue = "0";

    }
    //Ended by lalit

    protected void drpsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindTitle();
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
            string categoryid;
            string subcategoryid;
            string title;
            string subcategory;
            string user;
            string asset;                                                                     //added by lalit
            string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
            vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
            vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
            categoryid = drpcategory.SelectedValue;
            subcategoryid = drpsubcategory.SelectedValue;
            title = drptitle.SelectedItem.Text;
            user = drpuser.SelectedValue;
            asset = DrpAsset.SelectedValue;                                                   //added by lalit 
            subcategory = drpsubcategory.SelectedValue;
            ReportParameter[] Param = new ReportParameter[7];                                 //changed by lalit
            Param[0] = new ReportParameter("FromDate", vardate);
            Param[1] = new ReportParameter("ToDate", vardate1);
            Param[2] = new ReportParameter("categoryid", categoryid);
            Param[3] = new ReportParameter("subcategoryid", subcategory);
            Param[4] = new ReportParameter("title", title);
            Param[5] = new ReportParameter("Userid", user);
            Param[6] = new ReportParameter("assetid", asset);                                   //added by lalit

            ReportViewer1.ShowCredentialPrompts = false;
            ReportViewer1.Attributes.Add("style", "overflow:auto;");
            ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/Repeatcall";
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
