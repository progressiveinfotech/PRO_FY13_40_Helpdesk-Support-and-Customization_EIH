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
using System.Xml;
using System.IO;

public partial class Incident_IncidentRequestUpdate : System.Web.UI.Page
{
    #region Object Decalaration
    //IncidentResolution objIncidentResolution = new IncidentResolution();
    int assetid;
    SentMailToUser objSentMailtoUser = new SentMailToUser();
    BLLCollection<IncidentResolution> colIncidentResolution = new BLLCollection<IncidentResolution>();
    Incident_mst objIncident = new Incident_mst();
    ContactInfo_mst objcontactinfo = new ContactInfo_mst();                   //added by lalit joshi
    IncidentStates objIncidentStates = new IncidentStates();
    IncidentHistory objIncidentHistory = new IncidentHistory();
    BLLCollection<IncidentHistory> colIncidentHistory = new BLLCollection<IncidentHistory>();
    Impact_mst objImpact = new Impact_mst();
    Status_mst objStatus = new Status_mst();
    Mode_mst objMode = new Mode_mst();
    Priority_mst objPriority = new Priority_mst();
    SLA_mst objSLA = new SLA_mst();
    Site_mst objSite = new Site_mst();
    Department_mst objDept = new Department_mst();
    Category_mst objCategory = new Category_mst();
    Subcategory_mst objSubCategory = new Subcategory_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    BLLCollection<UserToSiteMapping> colUserToSite = new BLLCollection<UserToSiteMapping>();
    BLLCollection<Department_mst> colDept = new BLLCollection<Department_mst>();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<Impact_mst> colImpact = new BLLCollection<Impact_mst>();
    BLLCollection<Status_mst> colStatus = new BLLCollection<Status_mst>();
    BLLCollection<Mode_mst> colMode = new BLLCollection<Mode_mst>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    Organization_mst objOrganization = new Organization_mst();
    UserToSiteMapping ObjUserToSite = new UserToSiteMapping();
    RoleInfo_mst objRole = new RoleInfo_mst();
    RequestType_mst objRequestType = new RequestType_mst();
    BLLCollection<RequestType_mst> colRequesttype = new BLLCollection<RequestType_mst>();
    IncidentHistoryDiff objIncidentHistoryDiff = new IncidentHistoryDiff();
    BLLCollection<IncidentHistoryDiff> colIncidentHistoryDiff = new BLLCollection<IncidentHistoryDiff>();
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    IncidentLog objIncidentLog = new IncidentLog();
    BLLCollection<IncidentLog> colIncidentLog = new BLLCollection<IncidentLog>();
    IncidentToAssetMapping objincitiasset = new IncidentToAssetMapping();
    Asset_mst objaseetmst = new Asset_mst();
    TechnicianSLAStop objtechslastop = new TechnicianSLAStop();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Lblstatusupdatemsg.Text = "";
            this.ClientScript.GetPostBackEventReference(this, "arg");
            /////////////////////////////////change done by meenakshi
          
                     int flag = Convert.ToInt32(Session["flag"]);
                     if (flag == 1)
                     {
                         txtExternalTicket.Text = (string)Session["compname"];
                         Session["flag"] = "0";
                     }
                     
            //////////////////////////////////end
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            assetid = Convert.ToInt32(objincitiasset.Get_AssetId_By_incidentId(incidentid));

            if (assetid != 0)//Incase of no asset assign to user.
            {
                assetid = Convert.ToInt32(objincitiasset.Get_AssetId_By_incidentId(incidentid));
                objaseetmst = objaseetmst.Get_By_id(assetid);
                string compname = objaseetmst.Computername;
                XmlDocument xmldoc = new XmlDocument();
                DirectoryInfo di = new DirectoryInfo("C://Asset//Data");
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo K in fi)
                {
                    string[] fname = K.Name.Split(new char[] { '.' });

                    if (fname[0].ToString() == compname)
                    {
                        string path = "C:\\Asset\\Data\\" + compname + ".xml";
                        String filestr = File.ReadAllText(path);
                        xmldoc.LoadXml(filestr);
                        // xmldoc.Load(path);
                        DisplayComputerDetails(xmldoc);
                    }
                }
                // string path = "C:\\Asset\\Data\\" + compname + ".xml";
                //xmldoc.Load(path);

            }

            ///////////////////////changed///////////////////////////


            ///////////////////////////////////////////////////////////
            if (!IsPostBack)
            {
                LnkAttachment.Visible = false;
                lbltimespentonDisp.Visible = false;
                lbltimespentonreq.Text = "";
                pan1.Visible = true;
                pan2.Visible = false;
                UpdatePanel1();
                PanelShowNotes();
                /////////////////////////////////////added by lalit joshi ///////////////////////////////
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/FileAttach"));
                FileInfo[] fileinfo = dir.GetFiles();

                foreach (FileInfo f in fileinfo)
                {
                    string[] str = f.Name.Split(new char[] { '.' });
                    if (str[0] == Convert.ToString(incidentid))
                    {
                        LnkAttachment.Visible = true;
                    }

                }
                ////////////////////////////////////////////////////////////////////////////////////////////////
            }


            HistoryUpdatePanel();
            string CMDBUpdate = "";
            if (Session["CMDBUpdate"] != null)
            {
                CMDBUpdate = Session["CMDBUpdate"].ToString();
            }

            if (CMDBUpdate == "true")
            {
                pan1.Visible = false;
                pan2.Visible = true;
                UpdatePanel2();
                lnkEdit.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                HistoryUpdatePanel();
                drpStatus.SelectedValue = Session["drpStatus.SelectedValue"].ToString();
                drpMode.SelectedValue = Session["drpMode.SelectedValue"].ToString();
                drpCategory.SelectedValue = Session["drpCategory.SelectedValue"].ToString();
                drpSubcategory.SelectedValue = Session["drpSubcategory.SelectedValue"].ToString();
                drpAMCCall.SelectedValue = Session["drpAMCCall.SelectedValue"].ToString();
                Session["CMDBUpdate"] = "false";
                FunctionUpdate();
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

    #region UpdatePanel 1
    protected void UpdatePanel1()
    {
        pan1.Visible = true;
        pan2.Visible = false;
        lnkEdit.Visible = true;
        btnCancel.Visible = false;
        btnUpdate.Visible = false;
        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        if (incidentid != 0)
        {
            Session["incidentid"] = incidentid;
            lblIncidentId.Text = incidentid.ToString();
            objIncident = objIncident.Get_By_id(incidentid);
            if (objIncident.Incidentid != 0)
            {
                ViewState["CreatedbyId"] = Convert.ToString(objIncident.Createdbyid);
                objIncidentStates = objIncidentStates.Get_By_id(incidentid);
                if (objIncidentStates.Incidentid != 0)
                {
                    string status = Resources.MessageResource.strStatusOnHold.ToString();
                    lblCalltype.Text = GetRequestTypeName(objIncidentStates.Requesttypeid);
                    //lblImpact.Text = GetImpactString(objIncidentStates.Impactid);
                    lblStatus.Text = GetStatusString(objIncidentStates.Statusid);
                    lblMode.Text = GetModeString(objIncident.Modeid);
                    lblPriority.Text = GetPriorityString(objIncidentStates.Priorityid);
                    lblSLA.Text = GetSLAName(objIncident.Slaid);
                    lblSite.Text = GetSiteName(objIncident.Siteid);
                    lblDept.Text = GetDepartmentName(objIncident.Deptid);
                    lblCategory.Text = GetCategoryName(objIncidentStates.Categoryid);
                    lblAMCcall.Text = GetAMCCall(objIncident.Incidentid);
                    lblSubCategory.Text = GetSubCategoryName(objIncidentStates.Subcategoryid);
                    lblTechnician.Text = GetUsername(objIncidentStates.Technicianid);
                    lblCreatedby.Text = GetUsername(objIncident.Createdbyid);
                    lblReportedDate.Text = objIncident.Reporteddatetime;

                    lblRequesterDisp.Text = GetUsername(objIncident.Requesterid);

                    lblDateDisp.Text = objIncident.Createdatetime.ToString().Trim();
                    lblCreatedDate.Text = objIncident.Createdatetime.ToString().Trim();
                    //   lblAMCcall.Text = objIncident.AMCCall.ToString().Trim();
                    ////////////////////////////////////////////////////change done by meenakshi
                    if (objIncident.ExternalTicketNo != null)
                    {
                        //lblExternalTicket.Text = objIncident.ExternalTicketNo.ToString().Trim();
                        lblExternalTicket.Text = (string)Session["compname"];
                    }
                    ///////////////////////////////////////////////////end
                    //if (objIncident.AMCCall != null)
                    //{
                    //    lblAMCcall.Text = objIncident.AMCCall.ToString().Trim();
                    //}
                    lblVendor.Text = GetVendorName(Convert.ToInt32(objIncident.VendorId.ToString()));

                    if (objIncident.Completedtime != null)
                    {
                        lblCompletedDate.Text = objIncident.Completedtime.ToString().Trim();
                        lbltimespentonDisp.Visible = true;
                        int varTimeSpentonCall = 0;
                        varTimeSpentonCall = Convert.ToInt32(objIncident.Timespentonreq.ToString());
                        if (varTimeSpentonCall < 60)
                        {
                            lbltimespentonreq.Text = varTimeSpentonCall.ToString() + " min";
                        }
                        else
                        {
                            int hr;
                            int min;
                            hr = varTimeSpentonCall / 60;
                            min = varTimeSpentonCall % 60;
                            lbltimespentonreq.Text = hr + " hr" + ":" + min + " min";
                        }

                    }
                    else
                    {
                        lblCompletedDate.Text = "-";
                    }
                    lblTitle.Text = objIncident.Title;

                    //if (objIncident.Title.IndexOf("-") != -1)
                    //{
                    //    string[] extension = objIncident.Title.Split(("-").ToCharArray());
                    //    lblextension.Text = extension[1];
                    //    lblTitle.Text = extension[0];
                    //}
                    //else
                    //{

                    //    lblTitle.Text = objIncident.Title;
                    //    lblextension.Text = "No Extension";
                    //}
                    if (objIncident.Extension != null)
                    {
                        lblextension.Text = (objIncident.Extension).ToString();
                    }
                    lblDescription.Text = objIncident.Description;


                }


                //    //lblTitle.Text = objIncident.Title;
                //    if (objIncident.Title.Length > 0)
                //    {
                //        lblTitle.Text = objIncident.Title;
                //    }
                //    //if (objIncident.Title.IndexOf("-") != -1)
                //    if (objIncident.Extension > 0)
                //    {
                //        //string[] extension = objIncident.Title.Split(("-").ToCharArray());
                //        lblextension.Text = objIncident.Extension.ToString();

                //    }
                //    else
                //    {

                //        //lblTitle.Text = objIncident.Title;
                //        lblextension.Text = "No Extension";
                //    }
                //    lblDescription.Text = objIncident.Description;


                //}

            }

        }


    }
    #endregion

    #region FetchData Function

    string GetVendorName(int vendorid)
    {
        string vendorname = "";
        objVendor = objVendor.Get_By_id(vendorid);
        if (objVendor.Vendorid != 0)
        {
            vendorname = objVendor.Vendorname;
        }
        return vendorname;
    }
    string GetRequestTypeName(int requesttypeid)
    {
        string requesttypename = "";
        objRequestType = objRequestType.Get_By_id(requesttypeid);
        if (objRequestType.Requesttypeid != 0)
        {
            requesttypename = objRequestType.Requesttypename;
        }
        return requesttypename;
    }
    string GetImpactString(int impactid)
    {
        string impactname = "";
        objImpact = objImpact.Get_By_id(impactid);
        if (objImpact.Impactid != 0)
        {
            impactname = objImpact.Impactname;

        }
        return impactname;



    }
    string GetStatusString(int statusid)
    {
        string statusname = "";
        objStatus = objStatus.Get_By_id(statusid);
        if (objStatus.Statusid != 0)
        {
            statusname = objStatus.Statusname;

        }
        return statusname;

    }
    string GetModeString(int modeid)
    {
        string modename = "";
        objMode = objMode.Get_By_id(modeid);
        if (objMode.Modeid != 0)
        {
            modename = objMode.Modename;
        }
        return modename;
    }
    string GetPriorityString(int priorityid)
    {
        string priorityname = "";
        objPriority = objPriority.Get_By_id(priorityid);
        if (objPriority.Priorityid != 0)
        {
            priorityname = objPriority.Name;
        }
        return priorityname;

    }
    string GetSLAName(int slaid)
    {
        string SLAname = "";
        objSLA = objSLA.Get_By_id(slaid);
        if (objSLA.Slaid != 0)
        {
            SLAname = objSLA.Slaname;

        }

        return SLAname;

    }
    string GetSiteName(int siteid)
    {
        string sitename = "";
        objSite = objSite.Get_By_id(siteid);
        if (objSite.Siteid != 0)
        {
            sitename = objSite.Sitename;

        }
        return sitename;

    }
    string GetDepartmentName(int deptid)
    {
        string departmentname = "";
        objDept = objDept.Get_By_id(deptid);
        if (objDept.Deptid != 0)
        {
            departmentname = objDept.Departmentname;

        }
        return departmentname;
    }
    string GetCategoryName(int categoryid)
    {
        string categoryname = "";
        objCategory = objCategory.Get_By_id(categoryid);
        if (objCategory.Categoryid != 0)
        {
            categoryname = objCategory.CategoryName;
        }
        return categoryname;

    }

    string GetSubCategoryName(int subcategoryid)
    {
        string subcategoryname = "";
        objSubCategory = objSubCategory.Get_By_id(subcategoryid);
        if (objSubCategory.Subcategoryid != 0)
        {
            subcategoryname = objSubCategory.Subcategoryname;

        }
        return subcategoryname;

    }
    string GetAMCCall(int IncidentID)
    {
        string boolAmccall = "NO";
        objIncident = objIncident.Get_By_id(IncidentID);
        if (objIncident.AMCCall == true)
        {
            boolAmccall = "YES";
        }
        return boolAmccall;

    }
    string GetUsername(int userid)
    {
        string username = "";
        // objUser = objUser.Get_By_id(userid);
        objcontactinfo = objcontactinfo.Get_By_id(userid);
        //if (objUser.Userid != 0)
        //{
        //  username = objUser.Username;
        username = objcontactinfo.Firstname;
        //}
        return username;
    }
    #endregion

    //#region UpdatePanel2
    //protected void UpdatePanel2()
    //{
    //    lbltimespentonDisp.Visible = false;
    //    lbltimespentonreq.Text = "";
    //    BindDropSite();
    //    BindDropCategory();
    //    //BindDropImpact();
    //    BindDropStatus();
    //    BindDropMode();
    //    BindDropPriority();
    //    BindDropRequestType();
    //    BindDropVendor();

    //    int incidentid = Convert.ToInt32(Request.QueryString[0]);
    //    if (incidentid != 0)
    //    {
    //        objIncident = objIncident.Get_By_id(incidentid);
    //        if (objIncident.Incidentid != 0)
    //        {
    //            #region Get Current User and his Role
    //            MembershipUser User = Membership.GetUser();
    //            string varUserRole = "";
    //            string varRoleTechnician = "";
    //            string userName = "";
    //            if (User != null)
    //            {
    //                userName = User.UserName.ToString();

    //                string[] arrUserRole = Roles.GetRolesForUser();
    //                varUserRole = arrUserRole[0].ToString();
    //                varRoleTechnician = Resources.MessageResource.strTechnicianRole.ToString();
    //                if (varUserRole == varRoleTechnician)
    //                {
    //                    drpRequestType.Visible = false;
    //                    drpMode.Visible = false;
    //                    drpPriority.Visible = false;
    //                    drpSite.Visible = false;
    //                    drpDepartment.Visible = false;
    //                    drpTechnician.Visible = false;
    //                }

    //            }
    //            #endregion
    //            objIncidentStates = objIncidentStates.Get_By_id(incidentid);
    //            drpRequestType.SelectedValue = Convert.ToString(objIncidentStates.Requesttypeid);
    //            drpStatus.SelectedValue = Convert.ToString(objIncidentStates.Statusid);
    //            drpMode.SelectedValue = Convert.ToString(objIncident.Modeid);
    //            drpPriority.SelectedValue = Convert.ToString(objIncidentStates.Priorityid);
    //            lblslaPanel2.Text = GetSLAName(objIncident.Slaid);
    //            drpSite.SelectedValue = Convert.ToString(objIncident.Siteid);
    //            drpVendor.SelectedValue = Convert.ToString(objIncident.VendorId);
    //            BindDropDept();
    //            BindDropTechnician(); //lalit 30march
    //            if (objIncident.ExternalTicketNo != null)
    //            {
    //                txtExternalTicket.Text = objIncident.ExternalTicketNo.ToString().Trim();
    //            }

    //            drpDepartment.SelectedValue = Convert.ToString(objIncident.Deptid);
    //            //drpAMCCall.SelectedValue = Convert.ToString(objIncident.AMCCall);
    //            if (drpTechnician.SelectedValue != "0")
    //            {
    //              drpTechnician.SelectedValue = Convert.ToString(objIncidentStates.Technicianid);
    //             }
    //            drpCategory.SelectedValue = Convert.ToString(objIncidentStates.Categoryid);
    //            BindDropSubCategory();
    //            drpSubcategory.SelectedValue = Convert.ToString(objIncidentStates.Subcategoryid);
    //            lblCreatedbyPanel2.Text = GetUsername(objIncident.Createdbyid);
    //            lblCreateddatePanel2.Text = objIncident.Createdatetime.ToString().Trim();
    //            if (objIncident.Completedtime != null)
    //            {
    //                lblCompletedDatePanel2.Text = objIncident.Completedtime.ToString().Trim();

    //            }
    //            else
    //            {
    //                lblCompletedDatePanel2.Text = "";
    //            }
    //            lblTitle.Text = objIncident.Title;
    //            lblDescription.Text = objIncident.Description;

    //        }
    //    }


    //}
    //#endregion
    #region UpdatePanel2
    protected void UpdatePanel2()
    {
        string compname;
        lbltimespentonDisp.Visible = false;
        lbltimespentonreq.Text = "";
        BindDropSite();
        BindDropCategory();
        //BindDropImpact();
        BindDropStatus();
        BindDropMode();
        BindDropPriority();
        BindDropRequestType();
        BindDropVendor();

        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        if (incidentid != 0)
        {
            objIncident = objIncident.Get_By_id(incidentid);
            if (objIncident.Incidentid != 0)
            {
                #region Get Current User and his Role
                MembershipUser User = Membership.GetUser();
                string varUserRole = "";
                string varRoleTechnician = "";
                string userName = "";
                if (User != null)
                {
                    userName = User.UserName.ToString();

                    string[] arrUserRole = Roles.GetRolesForUser();
                    varUserRole = arrUserRole[0].ToString();
                    varRoleTechnician =Resources.MessageResource.strTechnicianRole.ToString();
                    if (varUserRole == varRoleTechnician)
                    {
                        drpRequestType.Visible = false;
                        drpMode.Visible = false;
                        drpPriority.Visible = false;
                        drpSite.Visible = false;
                        drpDepartment.Visible = false;
                        drpTechnician.Visible = false;
                    }

                }
                #endregion
                objIncidentStates = objIncidentStates.Get_By_id(incidentid);
                drpRequestType.SelectedValue = Convert.ToString(objIncidentStates.Requesttypeid);
                drpStatus.SelectedValue = Convert.ToString(objIncidentStates.Statusid);
                drpMode.SelectedValue = Convert.ToString(objIncident.Modeid);
                drpPriority.SelectedValue = Convert.ToString(objIncidentStates.Priorityid);
                lblslaPanel2.Text = GetSLAName(objIncident.Slaid);
                drpSite.SelectedValue = Convert.ToString(objIncident.Siteid);
                drpVendor.SelectedValue = Convert.ToString(objIncident.VendorId);
                BindDropDept();
                BindDropTechnician();
                if (objIncident.ExternalTicketNo != null)
                {
                    //change done by meenakshi
                    //txtExternalTicket.Text = objIncident.ExternalTicketNo.ToString().Trim();
                    txtExternalTicket.Text = (string)(Session["compname"]); 
                    //compname = (string)(Session["compname"]);
                    //txtExternalTicket.Text=compname.ToString();
                    
                }

                drpDepartment.SelectedValue = Convert.ToString(objIncident.Deptid);

                //if (drpTechnician.SelectedValue != "0")
                //{
                drpTechnician.SelectedValue = Convert.ToString(objIncidentStates.Technicianid);
                // }
                drpCategory.SelectedValue = Convert.ToString(objIncidentStates.Categoryid);
                BindDropSubCategory();
                drpSubcategory.SelectedValue = Convert.ToString(objIncidentStates.Subcategoryid);
                lblCreatedbyPanel2.Text = GetUsername(objIncident.Createdbyid);
                lblCreateddatePanel2.Text = objIncident.Createdatetime.ToString().Trim();
                lblReportedDate.Text = objIncident.Createdatetime.ToString().Trim();
                if (objIncident.Completedtime != null)
                {
                    lblCompletedDatePanel2.Text = objIncident.Completedtime.ToString().Trim();

                }
                else
                {
                    lblCompletedDatePanel2.Text = "";
                }
                lblTitle.Text = objIncident.Title;
                lblDescription.Text = objIncident.Description;

            }
        }


    }
    #endregion

  
    #region DropDown Binding()
    protected void BindDropVendor()
    {
        colVendor = objVendor.Get_All();
        drpVendor.DataTextField = "vendorname";
        drpVendor.DataValueField = "vendorid";
        drpVendor.DataSource = colVendor;
        drpVendor.DataBind();
        ListItem item = new ListItem();
        item.Text = "------Select Vendor------";
        item.Value = "0";
        drpVendor.Items.Add(item);
        drpVendor.SelectedValue = "0";


    }
    protected void BindDropRequestType()
    {
        colRequesttype = objRequestType.Get_All();
        drpRequestType.DataTextField = "requesttypename";
        drpRequestType.DataValueField = "requesttypeid";
        drpRequestType.DataSource = colRequesttype;
        drpRequestType.DataBind();

    }

    protected void BindDropPriority()
    {
        colPriority = objPriority.Get_All();
        drpPriority.DataTextField = "name";
        drpPriority.DataValueField = "priorityid";
        drpPriority.DataSource = colPriority;
        drpPriority.DataBind();
        ListItem item = new ListItem();
        item.Text = "------Select Priority------";
        item.Value = "0";
        drpPriority.Items.Add(item);
        drpPriority.SelectedValue = "0";




    }
    protected void BindDropMode()
    {
        colMode = objMode.Get_All();
        drpMode.DataTextField = "modename";
        drpMode.DataValueField = "modeid";
        drpMode.DataSource = colMode;
        drpMode.DataBind();
        ListItem item = new ListItem();
        item.Text = "------Select Mode------";
        item.Value = "0";
        drpMode.Items.Add(item);
        drpMode.SelectedValue = "0";


    }
    protected void BindDropStatus()
    {
        colStatus = objStatus.Get_All();
        drpStatus.DataTextField = "statusname";
        drpStatus.DataValueField = "statusid";
        drpStatus.DataSource = colStatus;
        drpStatus.DataBind();
        ListItem item = new ListItem();
        item.Text = "------Select Status------";
        item.Value = "0";
        drpStatus.Items.Add(item);
        drpStatus.SelectedValue = "0";



    }
    //protected void BindDropImpact()
    //{
    //    colImpact = objImpact.Get_All();
    //    drpImpact.DataTextField = "impactname";
    //    drpImpact.DataValueField = "impactid";
    //    drpImpact.DataSource = colImpact;
    //    drpImpact.DataBind();
    //    ListItem item = new ListItem();
    //    item.Text = "------Select Impact------";
    //    item.Value = "0";
    //    drpImpact.Items.Add(item);
    //    drpImpact.SelectedValue = "0";
    //}
    protected void BindDropSite()
    {
        string userName;
        MembershipUser User = Membership.GetUser();
        userName = User.UserName.ToString();

        if (userName != "")
        {
            int userid;
            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
            if (objUser.Userid != 0)
            {
                userid = objUser.Userid;
                colUserToSite = ObjUserToSite.Get_All_By_userid(userid);
                foreach (UserToSiteMapping obj in colUserToSite)
                {
                    int siteid;
                    Site_mst objSite1 = new Site_mst();
                    siteid = obj.Siteid;
                    objSite1 = objSite1.Get_By_id(siteid);
                    if (objSite1.Siteid != 0)
                    {


                        colSite.Add(objSite1);
                    }

                }


            }
            //------------------------
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
            drpSite.DataTextField = "sitename";
            drpSite.DataValueField = "siteid";
            drpSite.DataSource = colSite;
            drpSite.DataBind();
            //ListItem item = new ListItem();
            //item.Text = "------Select Site------";
            //item.Value = "0";
            //drpSite.Items.Add(item);
            //drpSite.SelectedValue = "0";

        }




    }

    protected void BindDropTechnician()
    {

        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        if (objRole.Roleid != 0)
        {
            int siteid;
            int roleid;
            siteid = Convert.ToInt32(drpSite.SelectedValue);
            roleid = objRole.Roleid;
            if (siteid != 0 && roleid != 0)
            {
                colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
                drpTechnician.DataTextField = "username";
                drpTechnician.DataValueField = "userid";
                drpTechnician.DataSource = colUser;
                drpTechnician.DataBind();
                ListItem item = new ListItem();
                item.Text = "------Select Technician------";
                item.Value = "0";
                drpTechnician.Items.Add(item);
                drpTechnician.SelectedValue = "0";

            }
            else
            {

                colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
                drpTechnician.DataTextField = "username";
                drpTechnician.DataValueField = "userid";
                drpTechnician.DataSource = colUser;
                drpTechnician.DataBind();
                ListItem item = new ListItem();
                item.Text = "------Select Technician------";
                item.Value = "0";
                drpTechnician.Items.Add(item);
                drpTechnician.SelectedValue = "0";


            }

        }





    }

    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropTechnician();
        BindDropDept();
    }

    protected void BindDropDept()
    {
        int siteid = 0;
        siteid = Convert.ToInt32(drpSite.SelectedValue);
        colDept = objDept.Get_All_By_SiteId(siteid);
        drpDepartment.DataTextField = "departmentname";
        drpDepartment.DataValueField = "deptid";
        drpDepartment.DataSource = colDept;
        drpDepartment.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Department------";
        item.Value = "0";
        drpDepartment.Items.Add(item);
        drpDepartment.SelectedValue = "0";



    }

    protected void BindDropCategory()
    {
        colCategory = objCategory.Get_All();
        drpCategory.DataTextField = "categoryname";
        drpCategory.DataValueField = "categoryid";
        drpCategory.DataSource = colCategory;
        drpCategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Category------";
        item.Value = "0";
        drpCategory.Items.Add(item);
        drpCategory.SelectedValue = "0";


    }

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropSubCategory();
    }

    protected void BindDropSubCategory()
    {
        int categoryid = Convert.ToInt32(drpCategory.SelectedValue);

        colSubCategory = objSubCategory.Get_All_By_Categoryid(categoryid);
        drpSubcategory.DataTextField = "subcategoryname";
        drpSubcategory.DataValueField = "subcategoryid";
        drpSubcategory.DataSource = colSubCategory;
        drpSubcategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Sub Category------";
        item.Value = "0";
        drpSubcategory.Items.Add(item);
        drpSubcategory.SelectedValue = "0";



    }
   

    #endregion

    protected void imgRequest_Click(object sender, ImageClickEventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelRequest.Visible = true;
            panelHistory.Visible = false;
            pnlResolution.Visible = false;
            PanelShowNotes();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void imgHistory_Click(object sender, ImageClickEventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelRequest.Visible = false;
            panelHistory.Visible = true;

            pnlResolution.Visible = false;
            HistoryUpdatePanel();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imgResolution_Click(object sender, ImageClickEventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pnlResolution.Visible = true;
            panelRequest.Visible = false;
            panelHistory.Visible = false;
            ShowResolution();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan1.Visible = false;
            pan2.Visible = true;
            UpdatePanel2();
            lnkEdit.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            HistoryUpdatePanel();
            //changed by lalit on 14 march
            int currentstatusid = Convert.ToInt32(drpStatus.SelectedValue);
            ViewState["currentstatus"] = currentstatusid.ToString();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
        //end
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan1.Visible = true;
            pan2.Visible = false;
            lnkEdit.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            UpdatePanel1();
            HistoryUpdatePanel();
            PanelShowNotes();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //added by lalit on 14 march
            int currentstatus = Convert.ToInt32(ViewState["currentstatus"]);
            //////////////////////////////////////////change done by meenakshi 3rd october 2012
            if (Session["CMDBUpdate"] == "true")
            {
                currentstatus = 14;
            }
            //////////////////////////////////////////end
            string strStatusResolved = Resources.MessageResource.strStatusResolved.ToString();
            int statusidOnresolved = objStatus.Get_By_StatusName(strStatusResolved);
            string statusClose = Resources.MessageResource.strStatusClose.ToString();
            if (currentstatus != statusidOnresolved)
            {
                int statusidClose = objStatus.Get_By_StatusName(statusClose);
                if ((Convert.ToInt32(drpStatus.SelectedValue) == statusidClose))
                {
                    Lblstatusupdatemsg.Text = "You can not close this call. This call is not resolved yet.";
                    return;
                }
            }
            //end
            Incident_To_Change Objincidenttochange = new Incident_To_Change();
            Objincidenttochange = Objincidenttochange.Get_By_Incidentid(Convert.ToInt32(Request.QueryString[0]));
            /////////////////////////////////////////////////change done by meenakshi 3rd oct
            //if (Objincidenttochange.Incidentid != 0 )
           
            //////////////////////////////////////////////////end
            if (Objincidenttochange.Incidentid != 0 && Session["CMDBUpdate"] != "true")
            {

                string statusOnClose = Resources.MessageResource.strStatusClose.ToString();
                int statusidOnClose = objStatus.Get_By_StatusName(statusOnClose);
                if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnClose)
                {
                    Session["drpStatus.SelectedValue"] = drpStatus.SelectedValue;
                    Session["drpMode.SelectedValue"] = drpMode.SelectedValue;
                    Session["drpCategory.SelectedValue"] = drpCategory.SelectedValue;
                    Session["drpSubcategory.SelectedValue"] = drpSubcategory.SelectedValue; 
                    Session["Incidentidforchange"] = Convert.ToInt32(Request.QueryString[0]);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../CMDB/UpdateCMDB.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes')", "window.open('../CMDB/UpdateCMDB.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');", true);
                    string myScript;
                    myScript = "<script language=javascript>javascript:window.open('../CMDB/UpdateCMDB.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');</script>";
                    Page.RegisterClientScriptBlock("MyScript", myScript);

                }
                else
                {
                    FunctionUpdate();

                }
            }
            else { FunctionUpdate(); }



        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }

    #region Definition of HistoryUpdatePanel
    protected void HistoryUpdatePanel()
    {
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderHistory.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderHistory.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion

        #region Get incidentid from QueryString
        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        #endregion

        #region Get Collection of IncidentHistory on the basis of incidentid
        colIncidentHistory = objIncidentHistory.Get_All_By_Incidentid(incidentid);
        #endregion

        #region Fetch each object of IncidentHistory from Collection of colIncidentHistory
        foreach (IncidentHistory obj in colIncidentHistory)
        {
            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            objUser = objUser.Get_By_id(obj.Operationownerid);
            username = objUser.Username.ToString();
            #endregion
            #region Declaration of Tablerow,TableCell and lable object
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            tbCell.Width = hdwidth;
            Label lbl = new Label();
            #endregion
            #region Print Each Operation Performed by User
            lbl.Font.Bold = true;
            lbl.Text = "&nbsp;&nbsp;" + obj.Operation.ToString() + "&nbsp;&nbsp;&nbsp;by&nbsp;&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Operationtime.ToString();
            #endregion
            #region Fix background color of row according the operation,Create operation shown by PaleGreen color,Update by Silver and Closed by Wheat
            if (obj.Operation == "create")
            {
                tabRow.BackColor = System.Drawing.Color.PaleGreen;
            }
            else if (obj.Operation == "closed")
            {
                tabRow.BackColor = System.Drawing.Color.Wheat;
            }
            else
            {
                tabRow.BackColor = System.Drawing.Color.Lavender;
            }
            #endregion

            #region Add label,cell,and Row to tabel
            tbCell.Controls.Add(lbl);
            tabRow.Cells.Add(tbCell);
            tbl.Rows.Add(tabRow);
            #endregion
            #region If Operation type is create,then Print username who Performed operation and add to table
            if (obj.Operation == "create")
            {
                TableRow tabRow1 = new TableRow();
                TableCell tbCell1 = new TableCell();
                tbCell1.Width = hdwidth;
                tbCell1.Height = height;
                Label lbl1 = new Label();
                lbl1.Text = "&nbsp;&nbsp;Operation : <b>Create</b> , Performed by :&nbsp;<b>" + username + "</b>";
                lbl1.Font.Size = FontUnit.Smaller;
                tbCell1.Controls.Add(lbl1);
                tabRow1.Cells.Add(tbCell1);
                tbl.Rows.Add(tabRow1);
            }
            #endregion

            #region Get Collection of IncidentHistoryDiff on the basis of historyid
            colIncidentHistoryDiff = objIncidentHistoryDiff.Get_All_By_Historyid(obj.Historyid);
            #endregion

            #region Fetch each object of IncidentHistoryDiff from Collection of colIncidentHistoryDiff
            foreach (IncidentHistoryDiff objDiff in colIncidentHistoryDiff)
            {
                #region Declaration of local variables,tablerow,tablecell and label
                string strPrevValue;
                string strCurrentValue;
                TableRow tabRowInner = new TableRow();
                TableCell tbCellInner = new TableCell();
                tbCellInner.Width = hdwidth;
                Label lblinner = new Label();
                lblinner.Font.Size = FontUnit.Smaller;
                #endregion

                #region If Modification is done at Mode of call,then Print Mode History
                if (objDiff.Columnname == Resources.MessageResource.strColumnModeid.ToString())
                {
                    strPrevValue = GetModeString(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetModeString(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Mode Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                }
                #endregion
                #region If Modification is done at RequestType of call,then Print RequestType History
                if (objDiff.Columnname == Resources.MessageResource.strColumnRequesttypeid.ToString())
                {
                    strPrevValue = GetRequestTypeName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetRequestTypeName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Request type Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                }
                #endregion
                #region If Modification is done at Priority of call,then Print Priority History
                if (objDiff.Columnname == Resources.MessageResource.strColumnPriorityid.ToString())
                {

                    strPrevValue = GetPriorityString(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetPriorityString(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Priority Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region If Modification is done at Site,then Print Site History
                if (objDiff.Columnname == Resources.MessageResource.strColumnSiteid.ToString())
                {

                    strPrevValue = GetSiteName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetSiteName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Site Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";



                }
                #endregion

                #region If Modification is done at SAL,then print SLA History
                if (objDiff.Columnname == Resources.MessageResource.strColumnSLAid.ToString())
                {
                    strPrevValue = GetSLAName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetSLAName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;SLA Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                }
                #endregion
                #region If Modification is done at Department,then print Department History
                if (objDiff.Columnname == Resources.MessageResource.strColumnDeptid.ToString())
                {

                    strPrevValue = GetDepartmentName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetDepartmentName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Department Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region If Modification is done at Category of Item,then print Category History
                if (objDiff.Columnname == Resources.MessageResource.strColumnCategoryid.ToString())
                {

                    strPrevValue = GetCategoryName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetCategoryName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Category Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region If Modification is done at Sub Category ,then Print Sub Category History
                if (objDiff.Columnname == Resources.MessageResource.strColumnSubcategoryid.ToString())
                {

                    strPrevValue = GetSubCategoryName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetSubCategoryName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Sub Category Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region If Modification is done at technician ,then print technician History
                if (objDiff.Columnname == Resources.MessageResource.strColumnTechnicianid.ToString())
                {

                    strPrevValue = GetUsername(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetUsername(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Technician Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region Print the Change of Assignment Time of Technician
                if (objDiff.Columnname == Resources.MessageResource.strColumnAssignedTime.ToString())
                {

                    strPrevValue = Convert.ToString(objDiff.Prev_value);
                    strCurrentValue = Convert.ToString(objDiff.Current_value);
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Time of technician assignment changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion

                #region If Modification is done at Status of call,then print Status History
                if (objDiff.Columnname == Resources.MessageResource.strColumnstatusid.ToString())
                {

                    strPrevValue = GetStatusString(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetStatusString(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Status  changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion
                #region If Status of call Move from Open to On hold,then Print Start of Stop Timer History
                if (objDiff.Columnname == Resources.MessageResource.strColumnStarttime.ToString())
                {

                    strPrevValue = Convert.ToString(objDiff.Prev_value);
                    strCurrentValue = Convert.ToString(objDiff.Current_value);
                    if (strPrevValue == "")
                    { strPrevValue = "N/A"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Time of stops timer starts at - &nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion
                #region If Status of call move from On hold to open ,then print End of stop Timer history
                if (objDiff.Columnname == Resources.MessageResource.srColumnEndtime.ToString())
                {

                    strPrevValue = Convert.ToString(objDiff.Prev_value);
                    strCurrentValue = Convert.ToString(objDiff.Current_value);
                    if (strPrevValue == "")
                    { strPrevValue = "N/A"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Time of stops timer End at - &nbsp;<b>" + strCurrentValue + "</b>";
                }
                #endregion
                #region If Modification is done at External Ticket Number of call,then Print External Ticket History
                if (objDiff.Columnname == Resources.MessageResource.strColumnExternalTicket.ToString())
                {
                    strPrevValue = objDiff.Prev_value;
                    strCurrentValue = objDiff.Current_value;
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;External Ticket Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                }
                #endregion
                //#region If Modification is done at Resolution of call,then Print Resolution History
                //if (objDiff.Columnname == "Resolution")
                //{
                //    strPrevValue = objDiff.Prev_value;
                //    strCurrentValue = objDiff.Current_value;
                //    if (strPrevValue == "")
                //    { strPrevValue = "-"; }
                //    if (strCurrentValue == "")
                //    { strCurrentValue = "-"; }
                //    lblinner.Text = "&nbsp;&nbsp; <b>Added Resolution is</b> &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                //}
                //#endregion

                #region If Modification is done at Vendor Id  of call,then Print Vendor History
                if (objDiff.Columnname == Resources.MessageResource.strColumnVendorId.ToString())
                {
                    strPrevValue = GetVendorName(Convert.ToInt32(objDiff.Prev_value));
                    strCurrentValue = GetVendorName(Convert.ToInt32(objDiff.Current_value));
                    if (strPrevValue == "")
                    { strPrevValue = "-"; }
                    if (strCurrentValue == "")
                    { strCurrentValue = "-"; }
                    lblinner.Text = "&nbsp;&nbsp;Vendor Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                }
                #endregion

                #region Label,cells and rows to Tabel of inner loop
                tabRowInner.BackColor = System.Drawing.Color.White;
                tbCellInner.Controls.Add(lblinner);
                tabRowInner.Cells.Add(tbCellInner);
                tbl.Rows.Add(tabRowInner);
                #endregion

            }

            #endregion


        }
        #endregion










    }
    #endregion

    #region Definition of SolutionUpdatePanel
    protected void SolutionUpdatePanel()
    {
        #region Get incidentid from QueryString
        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Find Resoultion is Exist in Database
        //objIncidentResolution = objIncidentResolution.Get_By_id(incidentid);
        #endregion
        #region If Resolution is Exist in Database then show in pnlResolutionShow
        //if (objIncidentResolution.Incidentid !=0)
        //{
        //    //pnlResolutionShow.Visible = true;
        //    //pnlResolutionEdit.Visible = false;
        //    //lnkEditResolution.Visible = true;
        //    //lblSolution.Text = objIncidentResolution.Resolution.ToString();
        //    //lblUpdated.Text = objIncidentResolution.Lastupdatetime.ToString();
        //}
        #endregion
        #region If Resolution is Not Exist ,Then Show Panel Edit for Entering Resolution
        //else 
        //{
        //    //pnlResolutionShow.Visible = false ;
        //    //pnlResolutionEdit.Visible = true ;
        //    //lnkEditResolution.Visible = false;

        //}
        #endregion
    }
    #endregion

    #region Handling Click Event of Button Resolution
    protected void btnResolution_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int userid = 0;
            string userName;
            MembershipUser User = Membership.GetUser();
            userName = User.UserName.ToString();

            if (userName != "")
            {

                objOrganization = objOrganization.Get_Organization();
                objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
                if (objUser.Userid != 0)
                {
                    userid = objUser.Userid;
                }
            }
            IncidentResolution objIncidentResolution = new IncidentResolution();
            #region Get incidentid from QueryString
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            #endregion
            #region Check Is Resolution Exist in Database
            objIncidentResolution = objIncidentResolution.Get_By_id(incidentid);
            #endregion
            #region Add Resolution  in Database

            string varResolution;
            varResolution = Editor.Text;
            objIncidentResolution.Incidentid = incidentid;
            objIncidentResolution.Lastupdatetime = DateTime.Now.ToString();
            objIncidentResolution.Resolution = varResolution;
            objIncidentResolution.Userid = userid;
            objIncidentResolution.Insert();
            Editor.Text = "";
            ShowResolution();

            #endregion
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    #endregion
    #region Handling Click Event of Button Reset
    protected void btnReset_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editor.Text = "";
            ShowResolution();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    #endregion
    #region Handling Click Event of Link Button Edit
    //protected void lnkEditResolution_Click(object sender, EventArgs e)
    //{
    //    pnlResolutionShow.Visible = false;
    //    pnlResolutionEdit.Visible = true;
    //    lnkEditResolution.Visible = false;
    //    #region Get incidentid from QueryString
    //    int incidentid = Convert.ToInt32(Request.QueryString[0]);
    //    #endregion
    //    #region Find Resoultion is Exist in Database
    //    objIncidentResolution = objIncidentResolution.Get_By_id(incidentid);
    //    #endregion
    //    #region If Resolution Exist in Database,Show in Label Control
    //    if (objIncidentResolution.Incidentid != 0)
    //    {
    //        Editor.Text = objIncidentResolution.Resolution.ToString();
    //        lblUpdated.Text = objIncidentResolution.Lastupdatetime.ToString();
    //    }
    //    #endregion

    //}
    #endregion
    #region Handling Click Event of Export Resolution
    protected void btnrcaexport_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            Response.Redirect("RCA.aspx?incidentid=" + incidentid);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    #endregion


    #region Handler of DropDown drpVendor SelectIndex Change Event,to set onhold status when vendor select
    protected void drpVendor_SelectedIndexChanged(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            int varVendorid;
            varVendorid = Convert.ToInt32(drpVendor.SelectedValue);
            if (varVendorid != 0)
            {
                string status = Resources.MessageResource.strStatusOnHold.ToString();
                int statusid = objStatus.Get_By_StatusName(status);
                drpStatus.SelectedValue = Convert.ToString(statusid);
            }
            HistoryUpdatePanel();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    #endregion

    //#region Handler of Drop Down drpStatus select Index Change Event
    //protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string statusOnHold = Resources.MessageResource.strStatusOnHold.ToString();
    //    int statusidOnHold = objStatus.Get_By_StatusName(statusOnHold);
    //    if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnHold)
    //    {

    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes')", "window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes');", true);
    //        string myScript;
    //        myScript = "<script language=javascript>javascript:window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes');</script>";
    //        Page.RegisterClientScriptBlock("MyScript", myScript);

    //    }
    //    //else
    //    //{ lnkAddworklog1.Visible = false; }

    //    string statusOnClose = Resources.MessageResource.strStatusClose.ToString();
    //    int statusidOnClose = objStatus.Get_By_StatusName(statusOnClose);
    //    if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnClose)
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes')", "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');", true);
    //        string myScript;
    //        myScript = "<script language=javascript>javascript:window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');</script>";
    //        Page.RegisterClientScriptBlock("MyScript", myScript);

    //    }
    //    HistoryUpdatePanel();
    //}
    //#endregion
    #region Handler of Drop Down drpStatus select Index Change Event
    protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //added by lalit on 14 march
            int currentstatus = Convert.ToInt32(ViewState["currentstatus"]);
            string strStatusResolved = Resources.MessageResource.strStatusResolved.ToString();
            int statusidOnresolved = objStatus.Get_By_StatusName(strStatusResolved);
            string statusClose = Resources.MessageResource.strStatusClose.ToString();
            if (currentstatus != statusidOnresolved)
            {
                int statusidClose = objStatus.Get_By_StatusName(statusClose);
                if ((Convert.ToInt32(drpStatus.SelectedValue) == statusidClose))
                {
                    Lblstatusupdatemsg.Text = "You can not close this call. This call is not resolved yet.";
                    return;
                }
            }
            //end
            string statusOnHold = Resources.MessageResource.strStatusOnHold.ToString();
            int statusidOnHold = objStatus.Get_By_StatusName(statusOnHold);
            if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnHold)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes')", "window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes');", true);
                string myScript;
                myScript = "<script language=javascript>javascript:window.open('../Incident/IncidentLog1.aspx','popupwindow','width=500,height=240,left=380,top=230,Scrollbars=yes');</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
            }
            //else
            //{ lnkAddworklog1.Visible = false; }

            //string statusOnClose = Resources.MessageResource.strStatusClose.ToString();
            //int statusidOnClose = objStatus.Get_By_StatusName(statusOnClose);
            //if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnClose)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes')", "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');", true);
            //    string myScript;
            //    myScript = "<script language=javascript>javascript:window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');</script>";
            //    Page.RegisterClientScriptBlock("MyScript", myScript);

            //}
            string statusOnresolved = Resources.MessageResource.strStatusResolved.ToString();
            int statusidOnresolve = objStatus.Get_By_StatusName(statusOnresolved);
            if (Convert.ToInt32(drpStatus.SelectedValue) == statusidOnresolve)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes')", "window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');", true);
                string myScript;
                myScript = "<script language=javascript>javascript:window.open('../Incident/IncidentResolution.aspx','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);

            }

            HistoryUpdatePanel();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    #endregion

    protected void lnkNewProblem_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            Session["IncidentToProblem"] = incidentid;
            string myScript;
            Session["RequestFromProblem"] = "True";
            myScript = "<script language=javascript>javascript:window.open('../Problem/IncidentToProblem.aspx','popupwindow','width=950,height=640,left=200,top=250,Scrollbars=yes');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void lnkExistProblem_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string myScript;
            Session["RequestFromProblem"] = "True";
            myScript = "<script language=javascript>javascript:window.open('../Problem/DisplayProblem.aspx','popupwindow','width=950,height=480,left=200,top=250,Scrollbars=yes');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }



    protected void lnkExistingChange_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string myScript;
            Session["RequestFromProblem"] = "True";
            myScript = "<script language=javascript>javascript:window.open('../Change/DisplayLinkincidenttochanges.aspx','popupwindow','width=950,height=480,left=200,top=250,Scrollbars=yes');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void PanelShowNotes()
    {

        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderNotes.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderNotes.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Get incidentid from QueryString
        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Get Collection of Log From IncidentLog table via incidentid
        colIncidentLog = objIncidentLog.Get_All_By_incidentid(incidentid);
        if (colIncidentLog.Count == 0)
        {

            TableRow tabRow3 = new TableRow();
            TableCell tbCell3 = new TableCell();
            tbCell3.Width = hdwidth;
            tbCell3.Height = height;
            Label lbl3 = new Label();
            lbl3.Text = "No Record Found";
            lbl3.Font.Size = FontUnit.Smaller;
            tbCell3.Controls.Add(lbl3);
            tabRow3.Cells.Add(tbCell3);
            tbl.Rows.Add(tabRow3);


        }


        foreach (IncidentLog obj in colIncidentLog)
        {

            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            objUser = objUser.Get_By_id(obj.Userid);
            username = objUser.Username.ToString();
            #endregion
            #region Declaration of Tablerow,TableCell and lable object
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            tbCell.Width = hdwidth;
            Label lbl = new Label();
            #endregion
            #region Print Each Operation Performed by User
            lbl.Font.Bold = true;
            lbl.Text = "&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;said on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.CreateDateTime.ToString();
            #endregion
            #region Fix background color of Row

            tabRow.BackColor = System.Drawing.Color.Lavender;

            #endregion
            #region Add label,cell,and Row to tabel
            tbCell.Controls.Add(lbl);
            tabRow.Cells.Add(tbCell);
            tbl.Rows.Add(tabRow);
            #endregion

            #region Declaration of local variables,tablerow,tablecell and label
            TableRow tabRowInner = new TableRow();
            TableCell tbCellInner = new TableCell();
            tbCellInner.Width = hdwidth;
            Label lblinner = new Label();
            lblinner.Font.Size = FontUnit.Smaller;
            #endregion

            #region Print Each Operation Performed by User
            lblinner.Font.Bold = true;
            lblinner.Text = "&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Incidentlog.ToString();
            #endregion


            #region Label,cells and rows to Tabel of inner loop
            tabRowInner.BackColor = System.Drawing.Color.White;
            tbCellInner.Controls.Add(lblinner);
            tabRowInner.Cells.Add(tbCellInner);
            tbl.Rows.Add(tabRowInner);
            #endregion


        }

        #endregion




    }

    protected void DisplayComputerDetails(XmlDocument xmldoc)
    {
        XmlNode compname = xmldoc.DocumentElement.SelectSingleNode("//Computer//Computer_name");
        XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
        XmlNode domain = xmldoc.DocumentElement.SelectSingleNode("//Computer//Domain");

        lblcompname.Text = compname.InnerText;
        lblassetid.Text = assetid.ToString();
        lbldomainname.Text = domain.InnerText;

    }

    protected void lnkAddworklog1_Click(object sender, EventArgs e)
    {

    }
    protected void lnkAddLog_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void lnkNewchange_Click(object sender, EventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            Incident_To_Change Objincidenttochange = new Incident_To_Change();
            Objincidenttochange = Objincidenttochange.Get_By_Incidentid(Convert.ToInt32(Request.QueryString[0]));
            if (Objincidenttochange.Incidentid == 0)
            {
                Session["incidentid"] = Convert.ToInt32(Request.QueryString[0]);
                string myScript;
                Session["RequestFromProblem"] = "True";
                myScript = "<script language=javascript>javascript:window.open('../Change/CreateChangefromIncident.aspx','popupwindow2','width=950,height=640,left=200,top=250,Scrollbars=yes');</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
            }
            else
            {
                string myScript;
                Session["RequestFromProblem"] = "True";
                myScript = "<script language=javascript>javascript:alert('Change request is already opened for this ticket');</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
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
    protected void ShowResolution()
    {
        IncidentResolution objIncidentResolution = new IncidentResolution();
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderResolution.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderResolution.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion

        int incidentid = Convert.ToInt32(Session["incidentid"].ToString());

        #region Get Collection of Log From IncidentLog table via incidentid
        colIncidentResolution = objIncidentResolution.Get_All_By_incidentid(incidentid);
        if (colIncidentResolution.Count == 0)
        {

            TableRow tabRow3 = new TableRow();
            TableCell tbCell3 = new TableCell();
            tbCell3.Width = hdwidth;
            tbCell3.Height = height;
            Label lbl3 = new Label();
            lbl3.Text = "No Record Found";
            lbl3.Font.Size = FontUnit.Smaller;
            tbCell3.Controls.Add(lbl3);
            tabRow3.Cells.Add(tbCell3);
            tbl.Rows.Add(tabRow3);


        }
        foreach (IncidentResolution obj in colIncidentResolution)
        {

            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            objUser = objUser.Get_By_id(obj.Userid);
            username = objUser.Username.ToString();
            #endregion
            #region Declaration of Tablerow,TableCell and lable object
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            tbCell.Width = hdwidth;
            Label lbl = new Label();
            #endregion
            #region Print Each Operation Performed by User
            lbl.Font.Bold = true;
            lbl.Text = "&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;said on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Lastupdatetime.ToString();
            #endregion
            #region Fix background color of Row

            tabRow.BackColor = System.Drawing.Color.Lavender;

            #endregion
            #region Add label,cell,and Row to tabel
            tbCell.Controls.Add(lbl);
            tabRow.Cells.Add(tbCell);
            tbl.Rows.Add(tabRow);
            #endregion

            #region Declaration of local variables,tablerow,tablecell and label
            TableRow tabRowInner = new TableRow();
            TableCell tbCellInner = new TableCell();
            tbCellInner.Width = hdwidth;
            Label lblinner = new Label();
            lblinner.Font.Size = FontUnit.Smaller;
            #endregion

            #region Print Each Operation Performed by User
            lblinner.Font.Bold = true;
            lblinner.Text = "&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Resolution.ToString();
            #endregion


            #region Label,cells and rows to Tabel of inner loop
            tabRowInner.BackColor = System.Drawing.Color.White;
            tbCellInner.Controls.Add(lblinner);
            tabRowInner.Cells.Add(tbCellInner);
            tbl.Rows.Add(tabRowInner);
            #endregion


        }

        #endregion

    }

    protected void FunctionUpdate()
    {

        #region Get incidentid from QueryString
        int incidentid = Convert.ToInt32(Request.QueryString[0]);
        #endregion

        #region Declare Local Variable
        // Declare local Variable
        int historyid;
        int varTotalTimeSpentonCall = 0;
        int SLAid;
        string userName;
        int userid = 0;
        string strCreateDatetime = "";
        string statusString;
        string strStatusOpen;
        string strStatusClose;
        string strStatusResolved;
        string strStatusOnHold;
        bool FlagTechnicianId;
        bool FlagCloseStatus;
        int requesttypeid;
        string OldStatusString;
        FlagTechnicianId = false;
        FlagCloseStatus = false;
        string oldCompletedTime = "";
        Incident_mst objIncidentOld = new Incident_mst();
        IncidentStates objIncidentStatesOld = new IncidentStates();

        bool FlagClosedStatus = true;
        string VarResolutionAdded = "";
        #endregion


        #region Fetch Current User
        // Fetch Current User and assign to local variable userName
        MembershipUser User = Membership.GetUser();
        userName = User.UserName.ToString();
        #endregion





        #region Fetch Data from MessageResource file and assign to Local Variable

        statusString = GetStatusString(Convert.ToInt32(drpStatus.SelectedValue));
        strStatusOpen = Resources.MessageResource.strStatusOpen.ToString().Trim();
        strStatusClose = Resources.MessageResource.strStatusClose.ToString().Trim();
        strStatusResolved = Resources.MessageResource.strStatusResolved.ToString().Trim();
        strStatusOnHold = Resources.MessageResource.strStatusOnHold.ToString().Trim();

        #endregion

        # region Get SLAid by Calling Function Get_By_SLAid() ,via Passing Parameter siteid and priorityid

        SLAid = objIncident.Get_By_SLAid(Convert.ToInt32(drpSite.SelectedValue), Convert.ToInt32(drpPriority.SelectedValue));
        requesttypeid = Convert.ToInt32(Resources.MessageResource.strRequestTypeId.ToString());
        if (requesttypeid == Convert.ToInt32(drpRequestType.SelectedValue))
        {
            SLAid = 0;
        }
        #endregion


        #region On the basis of Username ,get Userid by calling Function Get_UserLogin_By_UserName(),via passing parameter Username and organizationid

        if (userName != "")
        {
            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
            if (objUser.Userid != 0)
            {
                userid = objUser.Userid;
            }
        }
        #endregion


        //#region Insert value in IncidentHistory Table ,for every update of Page

        //if (statusString.ToLower() == strStatusClose.ToLower())
        //{
        //    if (Session["ResolutionAdded"] != null)
        //    {
        //        VarResolutionAdded = Session["ResolutionAdded"].ToString();
        //    }

        //    if (VarResolutionAdded == "true")
        //    {
        //        objIncidentHistory.Incidentid = incidentid;
        //        objIncidentHistory.Operationownerid = userid;
        //        objIncidentHistory.Operation = "closed";
        //        objIncidentHistory.Insert();
        //        Session["ResolutionAdded"] = "false";
        //    }
        //    else { FlagClosedStatus = false; }
        //}
        //else if (statusString.ToLower() == strStatusResolved.ToLower())
        //{

        //    objIncidentHistory.Incidentid = incidentid;
        //    objIncidentHistory.Operationownerid = userid;
        //    objIncidentHistory.Operation = "resolved";
        //    objIncidentHistory.Insert();
        //}
        //else
        //{

        //    objIncidentHistory.Incidentid = incidentid;
        //    objIncidentHistory.Operationownerid = userid;
        //    objIncidentHistory.Operation = "update";
        //    objIncidentHistory.Insert();


        //}
        //#endregion
        #region Insert value in IncidentHistory Table ,for every update of Page 
        if (statusString.ToLower() == strStatusClose.ToLower())
        {
            objIncidentHistory.Incidentid = incidentid;
            objIncidentHistory.Operationownerid = userid;
            objIncidentHistory.Operation = "closed";
            objIncidentHistory.Insert();
        }
        else if (statusString.ToLower() == strStatusResolved.ToLower())
        {
            if (Session["ResolutionAdded"] != null)
            {
                VarResolutionAdded = Session["ResolutionAdded"].ToString();
            }

            if (VarResolutionAdded == "true")
            {
                objIncidentHistory.Incidentid = incidentid;
                objIncidentHistory.Operationownerid = userid;
                objIncidentHistory.Operation = "resolved";
                objIncidentHistory.Insert();
                Session["ResolutionAdded"] = "false";
            }
            else { FlagClosedStatus = false; }
            //objIncidentHistory.Incidentid = incidentid;
            //objIncidentHistory.Operationownerid = userid;
            //objIncidentHistory.Operation = "resolved";
            //objIncidentHistory.Insert();
        }
        else
        {

            objIncidentHistory.Incidentid = incidentid;
            objIncidentHistory.Operationownerid = userid;
            objIncidentHistory.Operation = "update";
            objIncidentHistory.Insert();
        }
        #endregion

        #region Get the Current historyid by calling function Get_Current_IncidentHistoryid()
        historyid = objIncidentHistory.Get_Current_IncidentHistoryid();
        #endregion

        #region Find Current value of Incident and IncidentStates object ,By Calling Function Get_By_id(),via passing incidentid
        objIncidentOld = objIncidentOld.Get_By_id(incidentid);
        objIncidentStatesOld = objIncidentStatesOld.Get_By_id(incidentid);
        #endregion

        if (FlagClosedStatus == true)
        {
            #region Insert into IncidentHistoryDiff table ,By Comparing Current value and Updated Values

            if (objIncidentOld.Incidentid != 0 && objIncidentStatesOld.Incidentid != 0)
            {
                #region Declare local variable
                string columnName;
                string prev_value;
                string curnt_value;
                #endregion


                #region If site value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentOld.Siteid != Convert.ToInt32(drpSite.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnSiteid.ToString();
                    prev_value = Convert.ToString(objIncidentOld.Siteid);
                    curnt_value = drpSite.SelectedValue;
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If Department value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentOld.Deptid != Convert.ToInt32(drpDepartment.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnDeptid.ToString();
                    prev_value = Convert.ToString(objIncidentOld.Deptid);
                    curnt_value = drpDepartment.SelectedValue;
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If Mode value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentOld.Modeid != Convert.ToInt32(drpMode.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnModeid.ToString();
                    prev_value = Convert.ToString(objIncidentOld.Modeid);
                    curnt_value = drpMode.SelectedValue;
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If SLA value is changed,Insert into IncidentHistoryDiff table

                if (objIncidentOld.Slaid != SLAid)
                {
                    columnName = Resources.MessageResource.strColumnSLAid.ToString();
                    prev_value = Convert.ToString(objIncidentOld.Slaid);
                    curnt_value = Convert.ToString(SLAid);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If Requesttype value is changed,Insert into IncidentHistoryDiff table

                if (objIncidentStatesOld.Requesttypeid != Convert.ToInt32(drpRequestType.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnRequesttypeid.ToString();
                    prev_value = Convert.ToString(objIncidentStatesOld.Requesttypeid);
                    curnt_value = Convert.ToString(drpRequestType.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion


                #region If Priority value is changed,Insert into IncidentHistoryDiff table

                if (objIncidentStatesOld.Priorityid != Convert.ToInt32(drpPriority.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnPriorityid.ToString();
                    prev_value = Convert.ToString(objIncidentStatesOld.Priorityid);
                    curnt_value = Convert.ToString(drpPriority.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If Category value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentStatesOld.Categoryid != Convert.ToInt32(drpCategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnCategoryid.ToString();
                    prev_value = Convert.ToString(objIncidentStatesOld.Categoryid);
                    curnt_value = Convert.ToString(drpCategory.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion
                #region If SubCategory value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentStatesOld.Subcategoryid != Convert.ToInt32(drpSubcategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnSubcategoryid.ToString();
                    prev_value = Convert.ToString(objIncidentStatesOld.Subcategoryid);
                    curnt_value = Convert.ToString(drpSubcategory.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion



                #region If Status value is changed,Insert into IncidentHistoryDiff table

                if (objIncidentStatesOld.Statusid != Convert.ToInt32(drpStatus.SelectedValue))
                {
                    string Statusprev;
                    string StatusCurrent;
                    columnName = Resources.MessageResource.strColumnstatusid.ToString();
                    prev_value = Convert.ToString(objIncidentStatesOld.Statusid);
                    curnt_value = Convert.ToString(drpStatus.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                    Statusprev = GetStatusString(Convert.ToInt32(objIncidentStatesOld.Statusid));
                    StatusCurrent = GetStatusString(Convert.ToInt32(drpStatus.SelectedValue));
                    if (Statusprev.ToLower() == strStatusOpen.ToLower() && StatusCurrent.ToLower() == strStatusOnHold.ToLower())
                    {
                        columnName = Resources.MessageResource.strColumnStarttime.ToString();
                        prev_value = "0";
                        curnt_value = DateTime.Now.ToString();
                        objIncidentHistoryDiff.Historyid = historyid;
                        objIncidentHistoryDiff.Columnname = columnName;
                        objIncidentHistoryDiff.Current_value = curnt_value;
                        objIncidentHistoryDiff.Prev_value = prev_value;
                        objIncidentHistoryDiff.Insert();
                    }

                    if (Statusprev.ToLower() == strStatusOnHold.ToLower() && StatusCurrent.ToLower() != strStatusOnHold.ToLower())
                    {
                        columnName = Resources.MessageResource.srColumnEndtime.ToString();
                        prev_value = "0";
                        curnt_value = DateTime.Now.ToString();
                        objIncidentHistoryDiff.Historyid = historyid;
                        objIncidentHistoryDiff.Columnname = columnName;
                        objIncidentHistoryDiff.Current_value = curnt_value;
                        objIncidentHistoryDiff.Prev_value = prev_value;
                        objIncidentHistoryDiff.Insert();
                    }
                    //Added by lalit
                    //if current techncian is wintel and current status is closed then 
                    string prev_valuetechid = Convert.ToString(objIncidentStatesOld.Technicianid);
                    if (StatusCurrent == "Closed")
                    {
                        // if (prev_valuetechid == "11740")
                        if (IsSLANeedsToBeStopped(prev_valuetechid) == 1)
                        {
                            columnName = Resources.MessageResource.srColumnEndtime.ToString();
                            prev_value = "0";
                            curnt_value = DateTime.Now.ToString();
                            objIncidentHistoryDiff.Historyid = historyid;
                            objIncidentHistoryDiff.Columnname = columnName;
                            objIncidentHistoryDiff.Current_value = curnt_value;
                            objIncidentHistoryDiff.Prev_value = prev_value;
                            objIncidentHistoryDiff.Insert();
                        }
                    }
                    //end
                    //end lalit
                }
                #endregion

                #region If technician value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentStatesOld.Technicianid != Convert.ToInt32(drpTechnician.SelectedValue))
                {
                    string columnNametechid = Resources.MessageResource.strColumnTechnicianid.ToString();
                    string prev_valuetechid = Convert.ToString(objIncidentStatesOld.Technicianid);
                    string curnt_valuetechid = Convert.ToString(drpTechnician.SelectedValue);
                    // string Id = "";

                    //if (curnt_valuetechid == "11740" && prev_valuetechid!="11740")
                    if (IsSLANeedsToBeStopped(curnt_valuetechid) == 1 && IsSLANeedsToBeStopped(prev_valuetechid) == 0)
                    {
                        string StatusCurrent = GetStatusString(Convert.ToInt32(drpStatus.SelectedValue));
                        if (StatusCurrent.ToLower() != strStatusOnHold.ToLower())
                        {
                            //insert start time

                            if (StatusCurrent.ToLower() != strStatusOnHold.ToLower())
                            {
                                columnName = Resources.MessageResource.strColumnStarttime.ToString();
                                prev_value = "0";
                                curnt_value = DateTime.Now.ToString();
                                objIncidentHistoryDiff.Historyid = historyid;
                                objIncidentHistoryDiff.Columnname = columnName;
                                objIncidentHistoryDiff.Current_value = curnt_value;
                                objIncidentHistoryDiff.Prev_value = prev_value;
                                objIncidentHistoryDiff.Insert();
                                //end
                            }
                            //insert techcianid
                            objIncidentHistoryDiff.Historyid = historyid;
                            objIncidentHistoryDiff.Columnname = columnNametechid;
                            objIncidentHistoryDiff.Current_value = curnt_valuetechid;
                            objIncidentHistoryDiff.Prev_value = prev_valuetechid;
                            objIncidentHistoryDiff.Insert();
                            //end
                            //insert assigntime
                            if (objIncidentStatesOld.AssignedTime == null)
                            {
                                columnName = Resources.MessageResource.strColumnAssignedTime.ToString();
                                prev_value = "0";
                                curnt_value = DateTime.Now.ToString();
                                objIncidentHistoryDiff.Historyid = historyid;
                                objIncidentHistoryDiff.Columnname = columnName;
                                objIncidentHistoryDiff.Current_value = curnt_value;
                                objIncidentHistoryDiff.Prev_value = prev_value;
                                objIncidentHistoryDiff.Insert();
                            }
                            else
                            {
                                columnName = "AssignedTime";
                                prev_value = objIncidentStatesOld.AssignedTime;
                                curnt_value = DateTime.Now.ToString();
                                objIncidentHistoryDiff.Historyid = historyid;
                                objIncidentHistoryDiff.Columnname = columnName;
                                objIncidentHistoryDiff.Current_value = curnt_value;
                                objIncidentHistoryDiff.Prev_value = prev_value;
                                objIncidentHistoryDiff.Insert();
                            }
                            //end
                        }
                    }

                    else
                    {
                        //if prev value- progress eng 
                        columnName = Resources.MessageResource.strColumnTechnicianid.ToString();
                        prev_value = Convert.ToString(objIncidentStatesOld.Technicianid);
                        curnt_value = Convert.ToString(drpTechnician.SelectedValue);
                        objIncidentHistoryDiff.Historyid = historyid;
                        objIncidentHistoryDiff.Columnname = columnName;
                        objIncidentHistoryDiff.Current_value = curnt_value;
                        objIncidentHistoryDiff.Prev_value = prev_value;
                        objIncidentHistoryDiff.Insert();

                        if (objIncidentStatesOld.AssignedTime == null)
                        {
                            columnName = Resources.MessageResource.strColumnAssignedTime.ToString();
                            prev_value = "0";
                            curnt_value = DateTime.Now.ToString();
                            objIncidentHistoryDiff.Historyid = historyid;
                            objIncidentHistoryDiff.Columnname = columnName;
                            objIncidentHistoryDiff.Current_value = curnt_value;
                            objIncidentHistoryDiff.Prev_value = prev_value;
                            objIncidentHistoryDiff.Insert();
                        }
                        else
                        {
                            columnName = "AssignedTime";
                            prev_value = objIncidentStatesOld.AssignedTime;
                            curnt_value = DateTime.Now.ToString();
                            objIncidentHistoryDiff.Historyid = historyid;
                            objIncidentHistoryDiff.Columnname = columnName;
                            objIncidentHistoryDiff.Current_value = curnt_value;
                            objIncidentHistoryDiff.Prev_value = prev_value;
                            objIncidentHistoryDiff.Insert();
                        }
                        // if (prev_valuetechid == "11740")
                        if (IsSLANeedsToBeStopped(prev_valuetechid) == 1)
                        {
                            string StatusCurrent = GetStatusString(Convert.ToInt32(drpStatus.SelectedValue));
                            if (StatusCurrent.ToLower() != strStatusOnHold.ToLower())
                            {
                                columnName = Resources.MessageResource.srColumnEndtime.ToString();
                                prev_value = "0";
                                curnt_value = DateTime.Now.ToString();
                                objIncidentHistoryDiff.Historyid = historyid;
                                objIncidentHistoryDiff.Columnname = columnName;
                                objIncidentHistoryDiff.Current_value = curnt_value;
                                objIncidentHistoryDiff.Prev_value = prev_value;
                                objIncidentHistoryDiff.Insert();
                            }
                            //end
                        }
                        //then insert end time 0
                        //end
                        //else
                        //end
                    }


                    if (Convert.ToInt32(drpTechnician.SelectedValue) != 0)
                    {
                        objSentMailtoUser.SentmailTechnician(Convert.ToInt32(drpTechnician.SelectedValue), objIncidentOld.Incidentid);
                    }
                    FlagTechnicianId = true;
                }
                #endregion

                #region If External Ticket value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentOld.ExternalTicketNo == null)
                { objIncidentOld.ExternalTicketNo = " "; }

                if (objIncidentOld.ExternalTicketNo.ToString().Trim() != txtExternalTicket.Text.ToString().Trim())
                {
                    //////////////////////////////////////////////////change done by meenakshi
                     int flag = Convert.ToInt32(Session["flag"]);
                     if (flag == 1)
                     {
                         columnName = Resources.MessageResource.strColumnExternalTicket.ToString();
                         prev_value = objIncidentOld.ExternalTicketNo.ToString().Trim();
                         txtExternalTicket.Text = (string)Session["compname"];
                         curnt_value = txtExternalTicket.Text.ToString().Trim();
                         //curnt_value =(string) Session["compname"];
                         objIncidentHistoryDiff.Historyid = historyid;
                         objIncidentHistoryDiff.Columnname = columnName;
                         objIncidentHistoryDiff.Current_value = curnt_value;
                         objIncidentHistoryDiff.Prev_value = prev_value;
                         objIncidentHistoryDiff.Insert();
                     }
                }
                #endregion

                #region If Vendor  value is changed,Insert into IncidentHistoryDiff table
                if (objIncidentOld.VendorId == null)
                { objIncidentOld.ExternalTicketNo = "0"; }

                if (objIncidentOld.VendorId != Convert.ToInt32(drpVendor.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnVendorId.ToString();
                    prev_value = Convert.ToString(objIncidentOld.VendorId);
                    curnt_value = Convert.ToString(drpVendor.SelectedValue);
                    objIncidentHistoryDiff.Historyid = historyid;
                    objIncidentHistoryDiff.Columnname = columnName;
                    objIncidentHistoryDiff.Current_value = curnt_value;
                    objIncidentHistoryDiff.Prev_value = prev_value;
                    objIncidentHistoryDiff.Insert();
                }
                #endregion


                #region Check  Old status is closed and current status is closed,then Assign value to localvariable FlagCloseStatus=true and used later
                OldStatusString = GetStatusString(objIncidentStatesOld.Statusid);
                strCreateDatetime = objIncidentOld.Createdatetime;
                if (strStatusClose.ToLower() == OldStatusString.ToLower() && statusString.ToLower() == strStatusClose.ToLower())
                {
                    FlagCloseStatus = true;
                    oldCompletedTime = objIncidentOld.Completedtime;
                }
                #endregion


            }
            #endregion
        }


        if (FlagClosedStatus == true)
        {
            #region Update values in Incident Table
            objIncident.Incidentid = incidentid;
            objIncident.Siteid = Convert.ToInt32(drpSite.SelectedValue);
            objIncident.Deptid = Convert.ToInt32(drpDepartment.SelectedValue);
            objIncident.Title = lblTitle.Text;
            objIncident.Description = lblDescription.Text;
            objIncident.Modeid = Convert.ToInt32(drpMode.SelectedValue);
            objIncident.Slaid = SLAid;
            objIncident.Active = true;
            if (drpAMCCall.Text.ToUpper() == "YES")
            {
                objIncident.AMCCall = true;
            }
            else if (drpAMCCall.Text.ToUpper() == "NO")
            {
                objIncident.AMCCall = false;
            }
/////////////////////////////////////////////////////////////////change done by meenakshi/////////////////////////
            //objIncident.ExternalTicketNo = txtExternalTicket.Text.ToString().Trim();
            objIncident.ExternalTicketNo = (string)(Session["compname"]);
/////////////////////////////////////////////////////////////////end/////////////////////////////////
            objIncident.VendorId = Convert.ToInt32(drpVendor.SelectedValue);
            //#region If Current status is closed,then Assign Completed time
            #region If Current status is resolved,then Assign Completed time
            if (statusString.ToLower() == strStatusResolved.ToLower())
            {
                #region If FlagCloseStatus=flase ie Currrent status is closed ,and old status is not Closed
                if (FlagCloseStatus == false)
                {
                    objIncident.Completedtime = DateTime.Now.ToString();
                    varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(incidentid, Convert.ToInt32(drpSite.SelectedValue), strCreateDatetime, DateTime.Now.ToString());
                }
                else
                {
                    objIncident.Completedtime = oldCompletedTime;
                    varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(incidentid, Convert.ToInt32(drpSite.SelectedValue), strCreateDatetime, oldCompletedTime);
                }
                #endregion
            }
            //added by lalit 27 march
            if (statusString.ToLower() == strStatusClose.ToLower())
            {
                #region If FlagCloseStatus=flase ie Currrent status is closed ,and old status is not Closed
                varTotalTimeSpentonCall = objIncident.Timespentonreq;
                objIncident.Completedtime = oldCompletedTime;
                #endregion
            }
            //end lalit
            if (varTotalTimeSpentonCall <= 0)
            {
                varTotalTimeSpentonCall = 0;
            }

            if (lblextension.Text != "")
            {

                objIncident.Extension = Convert.ToInt64(lblextension.Text);
            }
            //if (lblAMCcall.Text != "")
            //{

            //    objIncident.AMCCall = Convert.ToInt32(lblAMCcall.Text);
            //}
            objIncident.Timespentonreq = varTotalTimeSpentonCall;
            objIncident.Update();
            //if (statusString.ToLower() == strStatusClose.ToLower() && FlagClosedStatus == true)
            if (statusString.ToLower() == strStatusResolved.ToLower() && FlagClosedStatus == true)
            {
                objSentMailtoUser.SentmailUser(objIncidentOld.Requesterid, objIncidentOld.Incidentid, "closed");
            }
            #endregion
            #endregion
        }
        if (FlagClosedStatus == true)
        {
            #region Update Values in IncidentStates
            objIncidentStates.Incidentid = incidentid;
            objIncidentStates.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
            objIncidentStates.Subcategoryid = Convert.ToInt32(drpSubcategory.SelectedValue);
            objIncidentStates.Technicianid = Convert.ToInt32(drpTechnician.SelectedValue);
            if (FlagTechnicianId == true)
            {
                objIncidentStates.AssignedTime = DateTime.Now.ToString();

            }
            objIncidentStates.Statusid = Convert.ToInt32(drpStatus.SelectedValue);
            objIncidentStates.Priorityid = Convert.ToInt32(drpPriority.SelectedValue);
            objIncidentStates.Requesttypeid = Convert.ToInt32(drpRequestType.SelectedValue);
            objIncidentStates.Update();
            #endregion
        }
            #region Callint Updatepanel1() function to display value in Non Editable Mode
        UpdatePanel1();
        #endregion
        HistoryUpdatePanel();
    }

    protected void LnkAttachment_Click(object sender, EventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            bool flag = false;
            string[] str = new string[10];
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/FileAttach"));
            FileInfo[] fileinfo = dir.GetFiles();
            //  string path = "C://Inetpub/wwwroot/SEBY/FileAttach/";
            string path = Server.MapPath("~/FileAttach/");
            foreach (FileInfo f in fileinfo)
            {
                str = f.Name.Split(new char[] { '.' });
                if (str[0] == Convert.ToString(incidentid))
                {
                    flag = true;
                    break;
                }

            }
            if (flag == true)
            {
                string ext = str[1];
                path = path + str[0] + "." + str[1];
                FileStream liveStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[(int)liveStream.Length];
                liveStream.Read(buffer, 0, (int)liveStream.Length);
                liveStream.Close();
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Length", buffer.Length.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" + str[0] + "." + str[1]);
                Response.BinaryWrite(buffer);
                Response.End();
            }

            //string path = Server.MapPath("~/FileAttach/13.xlsx");
            //string myScript;
            //myScript = "<script language=javascript>javascript:window.open('" + path + "','popupwindow','width=650,height=400,left=380,top=230,Scrollbars=yes');</script>";
            //Page.RegisterClientScriptBlock("MyScript", myScript);
            //string sResDownLoad = "";
            //sResDownLoad = "C://Inetpub/wwwroot/SEBY/FileAttach/url.txt";
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected int IsSLANeedsToBeStopped(string technician)
    {
        int technician1 = Convert.ToInt32(technician);
        int tech = objtechslastop.GetTechnicianId(technician1);
        return tech;
    }
}
