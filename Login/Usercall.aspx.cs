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

public partial class Login_Usercall : System.Web.UI.Page
{
    SentMailToUser objSentmailtoUser = new SentMailToUser();
    UserToSiteMapping ObjUserToSite = new UserToSiteMapping();
    RoleInfo_mst objRole = new RoleInfo_mst();
    Site_mst objSite = new Site_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Organization_mst objOrganization = new Organization_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    BLLCollection<UserToSiteMapping> colUserToSite = new BLLCollection<UserToSiteMapping>();
    BLLCollection<Department_mst> colDept = new BLLCollection<Department_mst>();
    Department_mst objDept = new Department_mst();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    Category_mst objCategory = new Category_mst();
    Impact_mst objImpact = new Impact_mst();
    BLLCollection<Impact_mst> colImpact = new BLLCollection<Impact_mst>();
    Status_mst objStatus = new Status_mst();
    BLLCollection<Status_mst> colStatus = new BLLCollection<Status_mst>();
    Mode_mst objMode = new Mode_mst();
    BLLCollection<Mode_mst> colMode = new BLLCollection<Mode_mst>();
    Priority_mst objPriority = new Priority_mst();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    Incident_mst objIncident = new Incident_mst();
    IncidentStates objIncidentStates = new IncidentStates();
    Subcategory_mst objSubCategory = new Subcategory_mst();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    IncidentHistory objIncidentHistory = new IncidentHistory();
    RequestType_mst objRequestType = new RequestType_mst();
    BLLCollection<RequestType_mst> colRequesttype = new BLLCollection<RequestType_mst>();
    UserToAssetMapping objusertoasset = new UserToAssetMapping();
    IncidentToAssetMapping objincidenttoasset = new IncidentToAssetMapping();
    Asset_mst objassetmst = new Asset_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    BLLCollection<CustomerToSiteMapping> colCustToSite = new BLLCollection<CustomerToSiteMapping>();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    int assetid = 0;
    string compname;
    string username;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        try
        {
            BindDropRequestType();
            BindDropMode();
            BindDropStatus();
            BindDropPriority();
            GetUserDetail();
            BindDropCategory();
            BindDropSubCategory();
            BindDropCustomer();
            BindDropSite();
            }
            catch(Exception ex)
            {
            
            }
        }
    }
    protected void BindDropRequestType()
    {
        objRequestType = objRequestType.Get_By_id(2);
        colRequesttype.Add(objRequestType);
        drpRequestType.DataTextField = "requesttypename";
        drpRequestType.DataValueField = "requesttypeid";
        drpRequestType.DataSource = colRequesttype;
        drpRequestType.DataBind();

    }

    protected void BindDropMode()
    {
        Mode_mst objM = new Mode_mst();
        int modeid;
        modeid = objMode.Get_Mode_By_Mname("web");

        objM = objMode.Get_By_id(modeid);
        colMode.Add(objM);
        drpMode.DataTextField = "modename";
        drpMode.DataValueField = "modeid";
        drpMode.DataSource = colMode;
        drpMode.DataBind();
        


    }
    protected void BindDropStatus()
    {
        colStatus = objStatus.Get_All_By_OpenStatus();
        drpStatus.DataTextField = "statusname";
        drpStatus.DataValueField = "statusid";
        drpStatus.DataSource = colStatus;
        drpStatus.DataBind();

    }

    protected void BindDropPriority()
    {
        int priorityid;
        priorityid = objPriority.Get_By_PriorityName("Medium");
        Priority_mst objP = new Priority_mst();
         objP = objPriority.Get_By_id(priorityid);
         colPriority.Add(objP);
        drpPriority.DataTextField = "name";
        drpPriority.DataValueField = "priorityid";
        drpPriority.DataSource = colPriority;
        drpPriority.DataBind();
        

    }
    protected void BindDropCategory()
    {
        colCategory = objCategory.Get_All();
        drpCategory.DataTextField = "categoryname";
        drpCategory.DataValueField = "categoryid";
        drpCategory.DataSource = colCategory;
        drpCategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select-------------";
        item.Value = "0";
        drpCategory.Items.Add(item);
        drpCategory.SelectedValue = "0";


    }
    protected void GetUserDetail()
    {
        string userName = "";
        MembershipUser User = Membership.GetUser();
        if (User != null)
        {
            userName = User.UserName.ToString();
            txtUsername.Text = User.UserName.ToString();
        }
        if (userName != "")
        {
            int userid;
            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);

            if (objUser.Userid != 0)
            {
                ContactInfo_mst objConInfo = new ContactInfo_mst();
                userid = objUser.Userid;
                IncidentToAsset(userid);
                objConInfo = objConInfo.Get_By_id(userid);
                txtEmail.Text = objConInfo.Emailid;
                txtassignasset.Text = compname;

            }
        }
       
    
    
    }

    protected void IncidentToAsset(int userid)
    {

        objOrganization = objOrganization.Get_Organization();
        objUser = objUser.Get_UserLogin_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
        userid = Convert.ToInt16(objUser.Userid);
        assetid = Convert.ToInt16(objusertoasset.Get_AssetId_By_UserId(userid));
        objassetmst = objassetmst.Get_By_id(assetid);
        compname = objassetmst.Computername;

    }

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropSubCategory();
    }

    protected void BindDropSubCategory()
    {
        int categoryid = Convert.ToInt16(drpCategory.SelectedValue);

        colSubCategory = objSubCategory.Get_All_By_Categoryid(categoryid);
        drpSubcategory.DataTextField = "subcategoryname";
        drpSubcategory.DataValueField = "subcategoryid";
        drpSubcategory.DataSource = colSubCategory;
        drpSubcategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select-------------";
        item.Value = "0";
        drpSubcategory.Items.Add(item);
        drpSubcategory.SelectedValue = "0";

    }


    //protected void BindDropSite()
    //{
    //    string userName = "";
    //    MembershipUser User = Membership.GetUser();
    //    if (User != null)
    //    {
    //        userName = User.UserName.ToString();
    //    }


    //    if (userName != "")
    //    {
    //        int userid;
    //        objOrganization = objOrganization.Get_Organization();
    //        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
    //        if (objUser.Userid != 0)
    //        {
    //          userid = objUser.Userid;
    //          colUserToSite = ObjUserToSite.Get_All_By_userid(userid);
    public void BindDropCustomer()
    {
        colCustomer = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "custid";
        drpCustomer.DataSource = colCustomer;
        drpCustomer.DataBind();
        drpCustomer.Visible = false;
        //ListItem item = new ListItem();
        //item.Text = "------------Select------------";
        //item.Value = "0";
        //drpCustomer.Items.Add(item);
        //drpCustomer.SelectedValue = "0";
    }
    protected void BindDropSite()
    {
        int userid;
        userid = objUser.Userid;
        colUserToSite = ObjUserToSite.Get_All_By_userid(userid);
        foreach (UserToSiteMapping Obj in colUserToSite)
              {
                  int siteid;
                  Site_mst objSite1 = new Site_mst();
                  siteid = Obj.Siteid;
                  objSite1 = objSite.Get_By_id(siteid);
                  if (objSite1.Siteid != 0)
                  {
                      int custid = Convert.ToInt16(drpCustomer.SelectedValue);
                      int flag = objCustToSite.Get_By_Id(custid, objSite1.Siteid);
                      if (flag == 1)
                      {
                         colSite.Add(objSite1);
                      }


                  }

                }


            //}
            //drpSite.DataTextField = "sitename";
            //drpSite.DataValueField = "siteid";
            //drpSite.DataSource = colSite ;
            //drpSite.DataBind();

    //        if (colSite.Count == 0)
    //        {
    //            ListItem item = new ListItem();
    //            item.Text = "-------------Select-------------";
    //            item.Value = "0";
    //            drpSite.Items.Add(item);

    //        }
            

    //    }




    //}

    //protected void BindDropSite()
    //{
        //colSite = objSite.Get_All();
        drpSite.DataTextField = "sitename";
        drpSite.DataValueField = "siteid";
        drpSite.DataSource = colSite;
        drpSite.DataBind();
        //ListItem item = new ListItem();
        //item.Text = "-------------Select-------------";
        //item.Value = "0";
        //drpSite.Items.Add(item);
        //drpSite.SelectedValue = "0";

    }

    //protected void BindDropCustomer()
    //{
    //    BLLCollection<Customer_mst> colCtS = new BLLCollection<Customer_mst>();

    //    string userName = "";
    //    MembershipUser User = Membership.GetUser();
    //    if (User != null)
    //    {
    //        userName = User.UserName.ToString();
    //    }


    //    if (userName != "")
    //    {
    //        int userid;
    //        int Flagcount = 0;
    //        objOrganization = objOrganization.Get_Organization();
    //        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
    //        if (objUser.Userid != 0)
    //        {
    //            userid = objUser.Userid;
    //            colUserToSite = ObjUserToSite.Get_All_By_userid(userid);
    //            foreach (UserToSiteMapping obj in colUserToSite)
    //            {
    //                int siteid;
    //                Site_mst objSite1 = new Site_mst();
    //                siteid = obj.Siteid;
    //                objSite1 = objSite1.Get_By_id(siteid);
    //                if (objSite1.Siteid != 0)
    //                {
    //                    colCustToSite=objCustToSite.Get_All_By_siteid(objSite1.Siteid);
                       
                        
    //                    foreach (CustomerToSiteMapping objcts in colCustToSite)
    //                    {
    //                        Customer_mst objC = new Customer_mst();
    //                        int FlagStatus = 0;
    //                        objC = objC.Get_By_id(objcts.Custid);
    //                        if (Flagcount == 0)
    //                        {
    //                            colCtS.Add(objC);
    //                        }
    //                        else
    //                        {
    //                            foreach (Customer_mst objCus in colCtS)
    //                            {
    //                                if (objC.Custid == objCus.Custid)
    //                                {
    //                                    FlagStatus = 1;
    //                                }
                                            
    //                            }
    //                            if (FlagStatus==0)
    //                            {
    //                                colCtS.Add(objC);
    //                            }

    //                        }

    //                        Flagcount = Flagcount + 1;
                        
    //                    }
                        
    //                }

    //            }


    //        }
            

    //    }
      
    //    drpCustomer.DataTextField = "Customer_Name";
    //    drpCustomer.DataValueField = "CustId";
    //    drpCustomer.DataSource = colCtS;
    //    drpCustomer.DataBind();
    //    if (colCtS.Count  == 0)
    //    {
    //        ListItem item = new ListItem();
    //        item.Text = "-------------Select-------------";
    //        item.Value = "0";
    //        drpCustomer.Items.Add(item);
            
    //    }
       
    
    
    //}
    protected void btnAdd_Click(object sender, EventArgs e)
    {
    try
    {
        Session["UserCreate"] = "Exist";

        #region Declaration of Local Variables
        int siteid, priorityid;
        int SLAid = 0;
        int createdbyid = 0;
        int requesterid = 0;
        int FlagInsert;
        int requesttypeid;
        string userName;
        bool FlagUserStatus;
        FlagUserStatus = true;
        FlagInsert = 0;
        #endregion

        #region Fetch Current User
        MembershipUser User = Membership.GetUser();
        userName = User.UserName.ToString();
        #endregion
        #region Get Current Site and Priority id
        siteid = Convert.ToInt16(drpSite.SelectedValue);
        priorityid = Convert.ToInt16(drpPriority.SelectedValue);
        #endregion


        #region Get SLAid on the basis of siteid and Priority id

        if (siteid != 0 && priorityid != 0)
        {
            SLAid = objIncident.Get_By_SLAid(siteid, priorityid);
            requesttypeid = Convert.ToInt16(Resources.MessageResource.strRequestTypeId.ToString());
            if (requesttypeid == Convert.ToInt16(drpRequestType.SelectedValue))
            {
                SLAid = 0;
            }
        }
        #endregion
        if (userName != "")
        {
            #region Find Userid of User who Created this Request
            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
            if (objUser.Userid != 0)
            {
                createdbyid = objUser.Userid;
            }

            #endregion



            #region Find Userid of User who is Requesting to log a call

            #region If User Already Exist
            if (Session["UserCreate"].ToString() == "Exist")
            {
                objUser = objUser.Get_UserLogin_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
                if (objUser.Userid != 0)
                {
                    requesterid = objUser.Userid;
                }
            }
            #endregion



            #endregion

        }


        objIncident.Title = txtTitle.Text.ToString().Trim() + "-" + TxtExtension.Text.Trim();
        objIncident.Slaid = SLAid;
        objIncident.Createdbyid = createdbyid;
        objIncident.Requesterid = requesterid;
        objIncident.Siteid = siteid;
        objIncident.Description = txtDescription.Text.ToString().Trim();
        objIncident.Deptid = 0;
        objIncident.Createdatetime = DateTime.Now.ToString();
        objIncident.Modeid = Convert.ToInt16(drpMode.SelectedValue);
         UserToSiteMapping objUserToSite = new UserToSiteMapping();

        if (FlagUserStatus == true)
        {
            FlagInsert = objIncident.Insert();

            #region Save Assetid and incident id in incidenttoassetmaaping


            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
            int userid = Convert.ToInt16(objUser.Userid);
            int tempuser1 = Convert.ToInt16(Session["tempuser1"]);
            if (tempuser1 == 1)
            {
                assetid = Convert.ToInt16(Session["assetid"]);
            }
            else
            {
                assetid = Convert.ToInt16(objusertoasset.Get_AssetId_By_UserId(userid));
            }
            int incid = Convert.ToInt16(objIncident.Get_TopIncidentId());
            if (txtassignasset.Text != "")
            {
                //assetid = Convert.ToInt16(txtassignasset.Text);
                if (assetid != 0)
                {
                    objincidenttoasset.Insert(incid, assetid);
                    objusertoasset.Insert(userid, assetid, objUser.City, objUser.Company);    //added a new column siteid
                    Session.Abandon();
                }
            }

            #endregion

        }

        if (FlagInsert == 1)
        {
            int FlagIncdStatesInsert;
            int incidentid;
            incidentid = objIncident.Get_Current_Incidentid();
            objIncidentStates.Incidentid = incidentid;
            objIncidentStates.Priorityid = Convert.ToInt16(drpPriority.SelectedValue);
            objIncidentStates.Categoryid = Convert.ToInt16(drpCategory.SelectedValue);
            objIncidentStates.Statusid = Convert.ToInt16(drpStatus.SelectedValue);
            objIncidentStates.Subcategoryid = Convert.ToInt16(drpSubcategory.SelectedValue);
            objIncidentStates.Technicianid = 0;

            objIncidentStates.Requesttypeid = Convert.ToInt16(drpRequestType.SelectedValue);
            FlagIncdStatesInsert = objIncidentStates.Insert();
            if (FlagIncdStatesInsert == 1)
            {
                objIncidentHistory.Incidentid = incidentid;
                objIncidentHistory.Operation = "create";
                objIncidentHistory.Operationownerid = createdbyid;
                objIncidentHistory.Insert();
                objSentmailtoUser.SentmailUser(requesterid, incidentid, "open");
                // change code/////////////////////////////////////////////////////////////////
                if (FileUpload1.HasFile)
                {
                    string filepath = Server.MapPath("~/FileAttach/");
                    string[] filenameupd = FileUpload1.FileName.Split(new char[] { '.' });
                    string filenew = Convert.ToString(incidentid) + "." + filenameupd[1];
                    FileUpload1.PostedFile.SaveAs(filepath + filenew);
                }
                ///////////////////////////////////////////////////////////////////////////////
                ////////change code on 27 march///
                #region Map Site to user
                //FlagInsert=0;
                int FlagDelete = 0;
                int FlagStatus = 0;
                //string Username;
                //string gvIDs;
                int organizationId;
                //string gv;
                // Get object of Organization to get organization id and assign to local variable organizationId
                objOrganization = objOrganization.Get_Organization();
                organizationId = objOrganization.Orgid;
                // Get username from textbox and assign to local variable Username
                //Username = txtUserName.Text.ToString().Trim();
                // Find User Exist ,by calling function Get_UserLogin_By_UserName()
                //objUser = objUser.Get_UserLogin_By_UserName(Username, organizationId);
                // If Userid is not zero ,then user exist in database
                if (objUser.Userid != 0)
                {
                    //'Navigate through each row in the GridView for checkbox items
                    //foreach (GridViewRow gv in grdvwSite.Rows)
                    //{
                    // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                   // CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                    // If deleteChkBxItem is Checked then ,mapped Current site to this user
                    //if (deleteChkBxItem.Checked)
                    //{
                        // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                        //gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                        // Check if gvIDs is not null
                       // if (gvIDs != "")
                        //{
                            // Declare local variable userid and siteid to get userid and SiteId
                            int userid;
                            
                            userid = Convert.ToInt16(objUser.Userid);
                            //siteid = Convert.ToInt16(gvIDs);
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
                        //}
                    }
                    // If deleteChkBxItem is Un Checked then ,Un mapped Current site to this user
                    else
                    {
                        // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                       // gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
                        // Check if gvIDs is not null
                        //if (gvIDs != "")
                       // {
                            // Declare local variable userid and siteid to get userid and SiteId
                            int userid;
                           
                            userid = Convert.ToInt16(objUser.Userid);
                            //siteid = Convert.ToInt16(gvIDs);
                            // To Find Current Site to this User is Mapped by Calling Function objUserToSite.Get_By_Id()
                            FlagStatus = objUserToSite.Get_By_Id(userid, siteid);
                            // If FlagStatus is not  zero then site is   mapped to this user
                            if (FlagStatus != 0)
                            {
                                // Un Mapped Current Site to this User by calling function objUserToSite.Delete()
                                FlagDelete = objUserToSite.Delete(userid, siteid);
                            }
                        //}
                    }
                    //}
                #endregion

                    /////////////end/////////////////


                    Response.Redirect("../Login/AllUserCall.aspx");

                }

            }

}
catch(Exception ex)
{

}
        }
    
    protected void drpCustomer_SelectedIndexChanged (object sender, EventArgs e)
    {
        BindDropSite();
    }
}


