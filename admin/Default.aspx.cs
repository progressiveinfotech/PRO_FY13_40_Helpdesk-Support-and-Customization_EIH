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

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string techmapping = Resources.MessageResource.strTechMapping.ToString();
            if (techmapping == "0")
            {
                trtechmapping.Visible = false;
            }
        }
    }
    protected void lnkCreateUser_Click(object sender, EventArgs e)
    {
      //  Response.Redirect(Request.ApplicationPath + "/admin/Adduser.aspx");
        Response.Redirect("~/admin/Adduser.aspx");
    }
    protected void lnkViewUser_Click(object sender, EventArgs e)
    {
       // Response.Redirect(Request.ApplicationPath + "/admin/ViewUser.aspx");
        Response.Redirect("~/admin/ViewUser.aspx");
    }
    protected void lnkAddCabMember_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddCabMembers.aspx");
        Response.Redirect("~/admin/AddCabMembers.aspx");
    }
    protected void lnkAddHoliday_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/EditHoliday.aspx");
        Response.Redirect("~/admin/EditHoliday.aspx");
    }
    //protected void lnkEditHoliday_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.ApplicationPath + "/admin/EditHoliday.aspx");
    //}
    protected void lnkViewServiceWindow_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/ViewServiceWindow.aspx");
        Response.Redirect("~/admin/ViewServiceWindow.aspx");
    }
    protected void lnkViewsla_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/Viewsla.aspx");
        Response.Redirect("~/admin/Viewsla.aspx");
    }
    protected void lnkAddOrganization_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddOrganization.aspx");
        Response.Redirect("~/admin/AddOrganization.aspx");
    }
    protected void lnkAddRegion_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddRegion.aspx");
        Response.Redirect("~/admin/AddRegion.aspx");
        
    }
    protected void lnkAddCountry_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddCountry.aspx");
        Response.Redirect("~/admin/AddCountry.aspx");
    }
    //protected void lnkAddSite_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.ApplicationPath + "/admin/AddSite.aspx");
    //}
    protected void lnkViewSite_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/ViewSite.aspx");
        Response.Redirect("~/admin/ViewSite.aspx");
    }
    protected void lnkAddDepartment_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddDepartment.aspx");
        Response.Redirect("~/admin/AddDepartment.aspx");
    }
    protected void LnkBtnmultipleusersitemapping_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/UserToMultipleSiteMapping.aspx");
        Response.Redirect("~/admin/UserToMultipleSiteMapping.aspx");
    }

    protected void lnkAddServiceEffected_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddServiceEffected.aspx");
        Response.Redirect("~/admin/AddServiceEffected.aspx");
    }
    //protected void lnkAddServiceWindow_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.ApplicationPath + "/admin/AddServiceWindow.aspx");
    //}
    protected void lnkUserToSiteMapping_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/UserToSiteMapping.aspx");
        Response.Redirect("~/admin/UserToSiteMapping.aspx");
    }
    protected void lnkImportUserAd_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/ImportUserAd.aspx");
        Response.Redirect("~/admin/ImportUserAd.aspx");
    }
    //protected void lnkAddRole_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.ApplicationPath + "/admin/AddRole.aspx");
    //}
    protected void lnkAddCategory_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddCategory.aspx");
        Response.Redirect("~/admin/AddCategory.aspx");
    }
    protected void lnkAddSubcategory_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddSubcategory.aspx");
        Response.Redirect("~/admin/AddSubcategory.aspx");
    }
    protected void lnkAddMode_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddMode.aspx");
        Response.Redirect("~/admin/AddMode.aspx");
    }
    protected void lnkAddPriority_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddPriority.aspx");
        Response.Redirect("~/admin/AddPriority.aspx");
    }
    protected void lnkAddStatus_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddStatus.aspx");
        Response.Redirect("~/admin/AddStatus.aspx");
    }
    protected void lnkAddChangeStatus_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddChangeStatus.aspx");
        Response.Redirect("~/admin/AddChangeStatus.aspx");
    }
    protected void lnkAddChangeType_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddChangeType.aspx");
        Response.Redirect("~/admin/AddChangeType.aspx");
    }
    protected void lnkAddVendor_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/Vendor.aspx");
        Response.Redirect("~/admin/Vendor.aspx");
    }
    protected void lnkAddColorScheme_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddColorScheme.aspx");
        Response.Redirect("~/admin/AddColorScheme.aspx");
    }
    //protected void lnkaddsla_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.ApplicationPath + "/admin/AddSlaDefinition.aspx");
    //}
    protected void lnkAddEmail_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddEmail.aspx");
        Response.Redirect("~/admin/AddEmail.aspx");
    }
    protected void lnkCreateCustomer_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddCustomer.aspx");
        Response.Redirect("~/admin/AddCustomer.aspx");
    }
    protected void lnkcmdb_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/CMDB/ViewCI.aspx");
        Response.Redirect("~/CMDB/ViewCI.aspx");
    }
    protected void lnkserviceproduct_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/CMDB/AddServiceProduct.aspx");
        Response.Redirect("~/CMDB/AddServiceProduct.aspx");
    }
    protected void lnkaddtitle_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddTitle.aspx");
        Response.Redirect("~/admin/AddTitle.aspx");
    }
    protected void lnkuseremail_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/UserToEmailMapping.aspx");
        Response.Redirect("~/admin/UserToEmailMapping.aspx");
    }
    protected void lnkusersurvey_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/UserSurvey.aspx");
        Response.Redirect("~/admin/UserSurvey.aspx");
    }
    protected void Lnkchangesetting_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/appsetting.aspx");
        Response.Redirect("~/admin/appsetting.aspx");
    }
    protected void LnkAddHub_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/AddHub.aspx");
        Response.Redirect("~/admin/AddHub.aspx");
    }
    protected void LnkMapHubToSite_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Request.ApplicationPath + "/admin/HubToSiteMapping.aspx");
        Response.Redirect("~/admin/HubToSiteMapping.aspx");
    }
    protected void LnkMapCatSubCatToTechnician_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/MapCatSubCategory.aspx");
    }
}
