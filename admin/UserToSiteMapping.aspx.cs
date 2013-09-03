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

public partial class admin_UserToSiteMapping : System.Web.UI.Page
{
    // Coded by -Sumit Gupta
    // Coded On -21 Jan 2010
    // Purpose  - User to Site Mapping
    
    // Declare Objects of various Classes ,Used later
    UserToSiteMapping objUserToSite = new UserToSiteMapping();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Site_mst objSites = new Site_mst();
    Region_mst objRegion = new Region_mst();
    BLLCollection<Region_mst> colRegion = new BLLCollection<Region_mst>();
    BLLCollection<Site_mst> colSites = new BLLCollection<Site_mst>();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    int userid = 0; 
    string username;

    protected void Page_Load(object sender, EventArgs e)
    {
         this.ClientScript.GetPostBackEventReference(this, "arg");

        // Values for SelectAsset Page after select the asset for a particular user
        int flag = Convert.ToInt32(Session["flag"]);
        if (flag == 1)
        {

            userid = Convert.ToInt32(Session["userid"]);
            username = (string)(Session["username"]);
           
            txtUserName.Text = username.ToString();
            Session["flag"] = "0";
            //Session.Abandon();
        }
        else
        {
            //txtUserName.Text = "";
        }

        if(! IsPostBack)
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
               //reqValUserName.ErrorMessage = Resources.MessageResource.errUserName.ToString();
           // Bind Drop Down drpRegion at Page Load Event()
               BindDropRegion();
        }
    }

    // Definition BindDropRegion() Function , To Bind Drop Down drpRegion
    public void BindDropRegion()
    {
        // Bind Drop Down Region,By Calling Function Get_All() via objRegion Object and assign to collection colRegion
        //colRegion = objRegion.Get_All();
        //drpRegion.DataTextField = "regionname";
        //drpRegion.DataValueField = "regionid";
        //drpRegion.DataSource = colRegion;
        //drpRegion.DataBind();
        //// Declare List Item item and add text ALL and value 0 to it and add to drpRegion Drop Down
        //ListItem item = new ListItem();
        //item.Text = "All";
        //item.Value = "0";
        //drpRegion.Items.Add(item);
        //drpRegion.SelectedValue = "0";

        colCustomer = objCustomer.Get_All();
        drpRegion.DataTextField = "Customer_Name";
        drpRegion.DataValueField = "custid";
        drpRegion.DataSource = colCustomer;
        drpRegion.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select------------";
        item.Value = "0";
        drpRegion.Items.Add(item);
        drpRegion.SelectedValue = "0";
    }

    // Event handler btnSearch_Click , To find user exist or not
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    // Declare Local Variable Username to get username from textbox
    //    string Username = txtUserName.Text.ToString().Trim();
    //    // Find User Exist in Database by Calling objUser.Get_UserLogin_By_UserName_Like() Function
    //    objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
    //    // If UserId is Not Zero than User Exist
    //    if (objUser.Userid != 0)
    //    {
    //        txtUserName.Text = objUser.Username.ToString().Trim();
    //    }
    //    else 
    //    {
    //        txtUserName.Text = "";
    //    }
    //}

   // Bind Grid of grdvwSite , on the basis of drop down value Selection
    protected void BindGrid()
    {
        // Declare Local Variable regionid to get regionid from drpRegion DropDown
        int custid;
        // Assign regionid to localvariable regionid from selected value of drop down
        custid = Convert.ToInt32(drpRegion.SelectedValue);
        // If region is Zero , ie All has been selected ,and bind all Sites Information to Grid
        if (custid == 0)
        {
            colSites = objSites.Get_All();
            grdvwSite.DataSource = colSites;
            grdvwSite.DataBind();
        }
        else
        {
            // Grid will bind only those sites ,which come under selected region
            BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
            colSites = objSites.Get_All();
            foreach (Site_mst obj in colSites)
            {
                int flag;
                flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
                if (flag == 1)
                {
                    colSite1.Add(obj);

                }
            }
            grdvwSite.DataSource = colSite1;
            grdvwSite.DataBind();
        }
    }

    // Event handler btnShow_Click , To Bind Sites to Grid View on the Selected Username and Region
    protected void btnShow_Click(object sender, EventArgs e)
    {
        // Declare local Variable gvIDs,Username,organizationId and FlagStatus
        string gvIDs;
        string Username;
        int organizationId;
        int FlagStatus;
        lblErrorMsg.Text="";
        // To get the Object of Organization ,to find the organization id
        objOrganization = objOrganization.Get_Organization();
        // Assign Organization Id to local variable organizationId
        organizationId = objOrganization.Orgid;
        // Assign Username from textbox to local variable Username
        Username = txtUserName.Text.ToString().Trim();
        // Get Object of UserLogin_mst Class on the basis of username and OrganizationId
        objUser = objUser.Get_UserLogin_By_UserName(Username, organizationId);
        // If Userid is not equal to Zero ,then user Exist
        if (objUser.Userid != 0)
        {
            // Bind Grid of Sites 
            BindGrid();
            // To check row by row of gridview ,how many sites have been mapped to this user from table UserToSiteMapping
            foreach (GridViewRow gv in grdvwSite.Rows)
            {
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // Get the Site Id from variable of Label type declare in GridView of grdvwSite
                gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                // Check if gvIDs is not null
                if (gvIDs != "")
                {
                    // Declare local variable userid and siteid to get userid and SiteId
                    int userid;
                    int siteid;
                    userid = Convert.ToInt32(objUser.Userid);
                    siteid = Convert.ToInt32(gvIDs);
                    // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
                    FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
                    // If FlagStatus is not zero then site is mapped to this user
                    if (FlagStatus != 0)
                    {
                        //Checked checkbox to show site is mapped to this user
                        deleteChkBxItem.Checked = true;
                    }
                }
            }
        }
    }

    // Handler grdvwSite_PageIndexChanging handling PageIndexChanging Event
    protected void grdvwSite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Hndling GridView PageIndex Change Event for Paging  
        grdvwSite.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here
        BindGrid();
    }

    // Handler grdvwSite_RowDataBound handling RowDataBound Event
    protected void grdvwSite_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        // If current row is data row then
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Hndling GridView RowDataBound  Event for Binding regionid to region name  
            int regionid = Convert.ToInt32(e.Row.Cells[3].Text);
            // Calling function objRegion.Get_By_id() to get region name via region id
            objRegion = objRegion.Get_By_id(regionid);
            // Assign region name to particular cell of Grid
            e.Row.Cells[3].Text = objRegion.Regionname.ToString();
        }
    }

    // Handler btnMapping_Click ,Handle btnMapped Button Click Event ,to mapped Sits to user
    protected void btnMapping_Click(object sender, EventArgs e)
    {
        // Declare local variable FlagInsert,FlagDelete,FlagStatus,Username,gvIDs and organizationId
        int FlagInsert=0;
        int FlagDelete = 0;
        int FlagStatus=0;
        string Username;
        string gvIDs;
        int organizationId;
        // Get object of Organization to get organization id and assign to local variable organizationId
        objOrganization = objOrganization.Get_Organization();
        organizationId = objOrganization.Orgid;
        // Get username from textbox and assign to local variable Username
        Username = txtUserName.Text.ToString().Trim();
        // Find User Exist ,by calling function Get_UserLogin_By_UserName()
        objUser = objUser.Get_UserLogin_By_UserName(Username, organizationId);
        // If Userid is not zero ,then user exist in database
        if (objUser.Userid != 0)
        {
            //'Navigate through each row in the GridView for checkbox items
            foreach (GridViewRow gv in grdvwSite.Rows)
            {
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {
                    // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                    gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                    // Check if gvIDs is not null
                    if (gvIDs != "")
                    {
                        // Declare local variable userid and siteid to get userid and SiteId
                        int userid;
                        int siteid;
                        userid = Convert.ToInt32(objUser.Userid);
                        siteid = Convert.ToInt32(gvIDs);
                        // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
                        FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
                        // If FlagStatus is  zero then site is not  mapped to this user
                        if (FlagStatus == 0)
                        {
                            objUserToSite.Siteid = siteid;
                            objUserToSite.Userid = userid;
                            // Mapped Current Site to this User by calling function objUserToSite.Insert()
                            FlagInsert = objUserToSite.Insert();
                        }
                    }
                }
                // If deleteChkBxItem is Un Checked then ,Un mapped Current site to this user
                else 
                {
                    // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                    gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                    // Check if gvIDs is not null
                    if (gvIDs != "")
                    {
                        // Declare local variable userid and siteid to get userid and SiteId
                        int userid;
                        int siteid;
                        userid = Convert.ToInt32(objUser.Userid);
                        siteid = Convert.ToInt32(gvIDs);
                        // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
                        FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
                        // If FlagStatus is not  zero then site is   mapped to this user
                        if (FlagStatus != 0)
                        {
                            // Un Mapped Current Site to this User by calling function objUserToSite.Delete()
                            FlagDelete = objUserToSite.Delete(userid, siteid);
                        }
                    }
                }
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            if (FlagInsert == 1 && FlagDelete==1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errSiteMpUmp.ToString();
            
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else  if (FlagInsert == 1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errSiteMapped.ToString();
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else if (FlagDelete == 1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errSitesUnMapped.ToString();
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else if (FlagStatus == 1 && FlagDelete == 1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errSitesUnMapped.ToString();
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else if (FlagStatus == 1 )
            {
                lblErrorMsg.Text = Resources.MessageResource.errAlrdyMapped.ToString();
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else
            {
                lblErrorMsg.Text = Resources.MessageResource.errNoOperation.ToString();
            }
        }
        else 
        {
            // Display message from MessageResource file located at App_GlobalResource Directory
            lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();
        }
    }
    // Handler btnReset_Click ,Handle Reset Button Click Event
    protected void btnReset_Click(object sender, EventArgs e)
    {
        // Reset all controls to inital state
        lblErrorMsg.Text = "";
        txtUserName.Text = "";
        grdvwSite.DataSource = colSites;
        grdvwSite.DataBind();
    }
}