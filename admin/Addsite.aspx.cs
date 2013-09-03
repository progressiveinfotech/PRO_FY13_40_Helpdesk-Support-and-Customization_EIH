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

public partial class Addsite : System.Web.UI.Page
{
   // Coded by -Sumit Gupta
   // Coded on - 18 Jan 2010
   // Purpose  -  Create Site Under Selected Region
    // Create Objects of Various Classes and Used later
    BLLCollection<Region_mst> col = new BLLCollection<Region_mst>();
    BLLCollection<Country_mst> col1 = new BLLCollection<Country_mst>();
    Region_mst ObjRegion = new Region_mst();
    Country_mst objCountry = new Country_mst();
    Site_mst objSite = new Site_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            // Start 
            reqValSiteName.ErrorMessage = Resources.MessageResource.errSiteName.ToString();
            reqValdrpRgn.ErrorMessage = Resources.MessageResource.errRegnName.ToString();
            regExtxtEmailId.ErrorMessage = Resources.MessageResource.errValidEmail.ToString();
            RegExpWebUrl.ErrorMessage = Resources.MessageResource.errValidUrl.ToString();
            reqValdrpCustomer.ErrorMessage = Resources.MessageResource.errCustomername.ToString();
            // End

            BindDropCustomer();
            // Functions BindDrpRegion() and BindDrpCountry() to fill Drop Down DrpRegion and DrpCountry at Page Load
            BindDrpRegion();
            BindDrpCountry();
        }
    }
    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";
    
    
    }
    public void BindDrpRegion()
    {
        col = ObjRegion.Get_All();
        drpRegion.DataTextField = "RegionName";
        drpRegion.DataValueField = "Regionid";
        drpRegion.DataSource = col;
        drpRegion.DataBind();
        // Declare item as listItem to assign default value to drop down
        ListItem item = new ListItem();
        item.Value = "0";
        item.Text = "--------------Select--------------";
        drpRegion.Items.Add(item);
        drpRegion.SelectedValue = "0";
    }

    public void BindDrpCountry()
    {
        col1 = objCountry.Get_All();
        drpCountry.DataTextField = "countryname";
        drpCountry.DataValueField = "countryid";
        drpCountry.DataSource = col1;
        drpCountry.DataBind();
        drpCountry.SelectedValue = "1"; 
    }

    protected void btnregionadd_Click(object sender, EventArgs e)
    {
        // Declare Local variable varStatus and varFlagSiteExist
        int varStatus;
        int varFlagSiteExist;
        // To Check Whether Site Exist in Particular Region ,and assign status to field varFlagSiteExist
        varFlagSiteExist = objSite.Get_By_SiteName(txtSitename.Text.ToString().Trim(), Convert.ToInt32(drpRegion.SelectedValue));
        // If field varFlagSiteExist is zero than Site Not Exist
        if (varFlagSiteExist == 0)
        {
            // Assign Controls Values to Object Fields
            objSite.Sitename = txtSitename.Text.ToString().Trim();
            objSite.Description = txtSitedesc.Text.ToString().Trim();
            objSite.Regionid = Convert.ToInt32(drpRegion.SelectedValue);
            objSite.Address = txtAddress.Text.ToString().Trim();
            objSite.City = txtCity.Text.ToString().Trim();
            objSite.Postalcode = txtPostalCode.Text.ToString().Trim();
            objSite.State = txtState.Text.ToString().Trim();
            objSite.Countryid = Convert.ToInt32(drpCountry.SelectedValue);
            objSite.Createdatetime = DateTime.Now.ToString();
            objSite.Phoneno = txtPhoneNo.Text.ToString().Trim();
            objSite.Faxno = txtFaxNo.Text.ToString().Trim();
            objSite.Emailid = txtEmailId.Text.ToString().Trim();
            objSite.Website = txtWebSiteUrl.Text.ToString().Trim();
            objSite.Contactpersonname = txtPersonName.Text.ToString().Trim();
            objSite.Mobileno = txtMobileno.Text.ToString().Trim();
            objSite.Enable = true;
            // Check Status whether data inserted in Database is successfully or not,and assign status  to field  varStatus 
            varStatus = objSite.Insert();
            // If varStatus is 1 then data save successfully otherwies Error occurred
            if (varStatus == 1)
            {
                int siteid;
                siteid=objSite.Get_TopSiteId();
                int custid = Convert.ToInt32(drpCustomer.SelectedValue);
                objCustToSite.Custid = custid;
                objCustToSite.Siteid = siteid;
                objCustToSite.Insert();
                
                Response.Redirect("~/admin/ViewSite.aspx");
            }
            else { lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString(); }
            // Calling function Clear() to clear all fields in forms
            Clear();
        }
        else 
        {
            // Show Message Site Already Exist
            lblErrorMsg.Text = Resources.MessageResource.errSiteExist.ToString();
        }
    }

    protected void Clear()
    {
        txtSitename.Text = "";
        txtSitedesc.Text = "";
        drpRegion.SelectedValue = "0";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtPostalCode.Text = "";
        txtState.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtEmailId.Text = "";
        txtWebSiteUrl.Text = "";
        txtPersonName.Text = "";
        txtMobileno.Text = "";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
        lblErrorMsg.Text = "";
    }

    protected void lnkViewSite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/ViewSite.aspx");
    }
}
