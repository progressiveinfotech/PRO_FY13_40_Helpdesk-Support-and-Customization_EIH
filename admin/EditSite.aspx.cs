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

public partial class admin_EditSite : System.Web.UI.Page
{
    //Coded by - Sumit Gupta
    //Coded On - 19 Jan 2010
    //Purpose  - Update Site Information

    // Create Objects of various Classes and used later
    Site_mst objSite = new Site_mst();
    Region_mst ObjRegion = new Region_mst();
    Country_mst objCountry = new Country_mst();
    BLLCollection<Region_mst> col = new BLLCollection<Region_mst>();
    BLLCollection<Country_mst> col1 = new BLLCollection<Country_mst>();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    BLLCollection<CustomerToSiteMapping> colCustToSite = new BLLCollection<CustomerToSiteMapping>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            // Start 
            reqValSiteName.ErrorMessage = Resources.MessageResource.errSiteName.ToString();
            reqValdrpRgn.ErrorMessage = Resources.MessageResource.errRegnName.ToString();
            regExtxtEmailId.ErrorMessage = Resources.MessageResource.errValidEmail.ToString();
            RegExpWebUrl.ErrorMessage = Resources.MessageResource.errValidUrl.ToString();
            // End
            // Functions BindDrpRegion() and BindDrpCountry() to fill Drop Down DrpRegion and DrpCountry at Page Load
            BindDropCustomer();
            BindDrpRegion();
            BindDrpCountry();
            // Call UpdateSite() function to assign form controls value
            UpdateSite(); 
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // On Click Cancel Button ,Redirect to ViewSite.aspx Page
        Response.Redirect("~/admin/ViewSite.aspx");
    }

    protected void UpdateSite()
    {
        int varFlagSiteExist;
        int Custid=0;
        // To Check Whether Site Exist in Particular Region ,and assign status to field varFlagSiteExist
        varFlagSiteExist = objSite.Get_By_SiteName(txtSitename.Text.ToString().Trim(), Convert.ToInt32(drpRegion.SelectedValue)); 
        // Declare Local Variable siteid ,hold the Query String value passed from ViewSite.aspx page
        int siteid = Convert.ToInt32(Request.QueryString[0]);
        // Get the Instance of Site_mst Class and Assign to Object Variable objSite
        objSite = objSite.Get_By_id(siteid);
        // Check ,Instance Exist or Not
        if ((objSite.Siteid !=0)&&(varFlagSiteExist==0))
        {       
            // Assign form fields values via object fields values
            txtSitename.Text = objSite.Sitename.ToString().Trim();
            txtSitedesc.Text = objSite.Description.ToString().Trim();
            drpRegion.SelectedValue = Convert.ToString(objSite.Regionid);
            drpCountry.SelectedValue = Convert.ToString(objSite.Countryid);
            txtAddress.Text = objSite.Address.ToString().Trim();
            txtCity.Text = objSite.City.ToString().Trim();
            txtEmailId.Text = objSite.Emailid.ToString().Trim();
            txtFaxNo.Text = objSite.Faxno.ToString().Trim();
            txtMobileno.Text = objSite.Mobileno.ToString().Trim();
            txtPersonName.Text = objSite.Contactpersonname.ToString().Trim();
            txtPhoneNo.Text = objSite.Phoneno.ToString().Trim();
            txtPostalCode.Text = objSite.Postalcode.ToString().Trim();
            txtState.Text = objSite.State.ToString().Trim();
            txtWebSiteUrl.Text = objSite.Website.ToString().Trim();
            colCustToSite = objCustToSite.Get_All_By_siteid(objSite.Siteid);

            foreach (CustomerToSiteMapping obj in colCustToSite)
            {
                Custid = obj.Custid;

            }
            ViewState["CustId"] = Custid;
            drpCustomer.SelectedValue = Convert.ToString(Custid);

            if (objSite.Enable == true)
            { 
                dropEnable.SelectedValue = "1"; 
            }
            else 
            { 
                dropEnable.SelectedValue = "0"; 
            }
           
        }
        else
        {
            // Show Message Site Already Exist
            lblErrorMsg.Text = Resources.MessageResource.errSiteExist.ToString();
        }    
    }

    public void BindDrpRegion()
    {
        //Bind Drop Down Region
        col = ObjRegion.Get_All();
        drpRegion.DataTextField = "RegionName";
        drpRegion.DataValueField = "Regionid";
        drpRegion.DataSource = col;
        drpRegion.DataBind();              
    }

    public void BindDrpCountry()
    {
        //Bind Drop Down Country
        col1 = objCountry.Get_All();
        drpCountry.DataTextField = "countryname";
        drpCountry.DataValueField = "countryid";
        drpCountry.DataSource = col1;
        drpCountry.DataBind();       
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int FlagStatus;
        int siteid = Convert.ToInt32(Request.QueryString[0]);
        objSite = objSite.Get_By_id(siteid);
        int varFlagSiteExist;
        varFlagSiteExist = objSite.Get_By_SiteName(txtSitename.Text.ToString().Trim(), Convert.ToInt32(drpRegion.SelectedValue));

        if ((varFlagSiteExist == 0)||(objSite.Sitename==txtSitename.Text.ToString().Trim()))
        {
            int Custid;
            objSite.Siteid = siteid;
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
            Custid = Convert.ToInt32(ViewState["CustId"].ToString());
            objCustToSite.Delete(Custid, siteid);
            objCustToSite.Custid = Convert.ToInt32(drpCustomer.SelectedValue);
            objCustToSite.Siteid = siteid;
            objCustToSite.Insert();


            if (dropEnable.SelectedValue == "1")
            { 
                objSite.Enable = true; 
            }
            else 
            { 
                objSite.Enable = false; 
            }
            //  Call Function objSite.Update() to update the Site values in Database
            FlagStatus = objSite.Update();

            if (FlagStatus == 1)
            {
                // Redirect to page ViewSite.aspx page after successfully Updation
                Response.Redirect("~/admin/ViewSite.aspx");
            }
            else
            {
                // If Updation is not successfully,Display Error Message
                lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString().Trim();
            }
        }
        else
        {
            // Show Message Site Already Exist
            lblErrorMsg.Text = Resources.MessageResource.errSiteExist.ToString();
        }        
    }           
}