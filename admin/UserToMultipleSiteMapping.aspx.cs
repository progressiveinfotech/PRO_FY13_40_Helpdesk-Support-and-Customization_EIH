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

public partial class admin_UserToMultipleSiteMapping : System.Web.UI.Page
{
    UserToSiteMapping objUserToSite = new UserToSiteMapping();
    ContactInfo_mst objcontactinfo = new ContactInfo_mst();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Site_mst objSites = new Site_mst();
    Region_mst objRegion = new Region_mst();
    BLLCollection<Region_mst> colRegion = new BLLCollection<Region_mst>();
    BLLCollection<Site_mst> colSites = new BLLCollection<Site_mst>();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    BLLCollection<ContactInfo_mst> colcontactinfo = new BLLCollection<ContactInfo_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropRegion();
            BindGrid();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
     //   BindGrid();
       
    
    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        int index = -1;
        foreach (GridViewRow row in grdvwSitetest.Rows)
        {
            index = (int)grdvwSitetest.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("chkbxcheck")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!categoryIDList.Contains(index))
                    categoryIDList.Add(index);
            }
            else
                categoryIDList.Remove(index);
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }
    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in grdvwSitetest.Rows)
            {
                int index = (int)grdvwSitetest.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("chkbxcheck");
                    myCheckBox.Checked = true;
                }
            }
        }
    }
    protected void BindGrid()
    {
            IDataReader rdr = objcontactinfo.Get_By_siteid();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            grdvwSitetest.DataSource = dt;
            grdvwSitetest.DataBind();
    }
    protected void btnMapping_Click(object sender, EventArgs e)
    {
        int FlagInsert = 0;
        int FlagDelete = 0;
        int FlagStatus = 0;
       // string Username;
        string gvIDs;
     
            //'Navigate through each row in the GridView for checkbox items
            foreach (GridViewRow gv in grdvwSitetest.Rows)
            {
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("chkbxcheck");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {
                    // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                   // gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                    gvIDs = drpRegion.SelectedItem.Value;
                    // Check if gvIDs is not null
                    if (gvIDs != "")
                    {
                        // Declare local variable userid and siteid to get userid and SiteId
                        int userid;
                        int siteid;
                        Label usrid = (Label)gv.FindControl("Lbluserid");
                        userid = Convert.ToInt32(usrid.Text.ToString());
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
                    gvIDs = drpRegion.SelectedItem.Value;
                    // Check if gvIDs is not null
                    if (gvIDs != "")
                    {
                        // Declare local variable userid and siteid to get userid and SiteId
                        int userid;
                        int siteid;
                        Label usrid = (Label)gv.FindControl("Lbluserid");
                        userid = Convert.ToInt32(usrid.Text.ToString());
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
            if (FlagInsert == 1 && FlagDelete == 1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errSiteMpUmp.ToString();

            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            else if (FlagInsert == 1)
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
            else if (FlagStatus == 1)
            {
                lblErrorMsg.Text = Resources.MessageResource.errAlrdyMapped.ToString();
            }
            // Display message from MessageResource file located at App_GlobalResource Directory
            //else
            //{
            //    lblErrorMsg.Text = Resources.MessageResource.errNoOperation.ToString();
            //}
        //}
        //else
        //{
        //    // Display message from MessageResource file located at App_GlobalResource Directory
        //    lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();
        //}
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
    }
    public void BindDropRegion()
    {
        colSites = objSites.Get_All();
        drpRegion.DataTextField = "siteName";
        drpRegion.DataValueField = "siteid";
        drpRegion.DataSource =colSites;
        drpRegion.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select------------";
        item.Value = "0";
        drpRegion.Items.Add(item);
        drpRegion.SelectedValue = "0";
    }
    protected void grdvwSitetest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblErrorMsg.Text = "";
        RememberOldValues();
        // Hndling GridView PageIndex Change Event for Paging  
        grdvwSitetest.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here
        BindGrid();

        string gvIDs;
        int FlagStatus = 0;
        gvIDs = drpRegion.SelectedItem.Value;
        int siteid;
        siteid = Convert.ToInt32(gvIDs);
        
        foreach (GridViewRow gv in grdvwSitetest.Rows)
        {
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox checkbx = (CheckBox)gv.FindControl("chkbxcheck");
            int userid;
            Label usrid = (Label)gv.FindControl("Lbluserid");
            userid = Convert.ToInt32(usrid.Text.ToString());

            siteid = Convert.ToInt32(gvIDs);
            // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
            FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
            // If FlagStatus is not zero then site is mapped to this user
            if (FlagStatus != 0)
            {
                //Checked checkbox to show site is mapped to this user
                checkbx.Checked = true;
            }
        }
             //  RePopulateValues();
    }

    protected void grdvwSitetest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
   
    }
    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Session.Remove("CHECKED_ITEMS");
        lblErrorMsg.Text = "";
      //  RememberOldValues();
        BindGrid();
        string gvIDs;
        int FlagStatus = 0;
        gvIDs = drpRegion.SelectedItem.Value;
        int siteid;
        siteid = Convert.ToInt32(gvIDs);
        foreach (GridViewRow gv in grdvwSitetest.Rows)
        {
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox checkbx = (CheckBox)gv.FindControl("chkbxcheck");
            int userid;
            Label usrid = (Label)gv.FindControl("Lbluserid");
            userid = Convert.ToInt32(usrid.Text.ToString());

            siteid = Convert.ToInt32(gvIDs);
            // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
            FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
            // If FlagStatus is not zero then site is mapped to this user
            if (FlagStatus != 0)
            {
                //Checked checkbox to show site is mapped to this user
                checkbx.Checked = true;
            }
        }
      
    }
}
