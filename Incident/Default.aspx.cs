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
using System.Drawing;
using System.IO;

public partial class helpdesk_Default : System.Web.UI.Page
{
    #region Object Declaration
    Organization_mst objOrganization = new Organization_mst();
    ContactInfo_mst objContactmst = new ContactInfo_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    UserToSiteMapping ObjUserToSite = new UserToSiteMapping();
    BLLCollection<UserToSiteMapping> colUserToSite = new BLLCollection<UserToSiteMapping>();
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    Incident_mst objIncident = new Incident_mst();
    BLLCollection<Incident_mst> colIncident = new BLLCollection<Incident_mst>();
    IncidentHistory objIncidentHistory = new IncidentHistory();
    BLLCollection<IncidentHistory> colIncidentHistory = new BLLCollection<IncidentHistory>();
    IncidentStates objIncidentStates = new IncidentStates();
    BLLCollection<IncidentStates> colIncidentStates = new BLLCollection<IncidentStates>();
    IncidentHistoryDiff objIncidentHistoryDiff = new IncidentHistoryDiff();
    BLLCollection<IncidentHistoryDiff> colIncidentHistoryDiff = new BLLCollection<IncidentHistoryDiff>();
    Status_mst objStatus = new Status_mst();
    Priority_mst objPriority = new Priority_mst();
    IncidentResolution objIncidentResolution = new IncidentResolution();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    IncidentToAssetMapping objIncidentToAsset = new IncidentToAssetMapping();
    IncidentDeactiveCalls objIncidentDeactiveCalls = new IncidentDeactiveCalls();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    BLLCollection<CustomerToSiteMapping> colCustToSite = new BLLCollection<CustomerToSiteMapping>();
    #endregion

    //protected override void OnInit(EventArgs e)
    //{

    //    base.OnInit(e);

    //    PnlLoader.Visible = true;

    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { /////Add Exception handilng try catch change by vishal 21-05-2012
            try
            {

                if (Session["Filterid"] != null)
                {
                    BindSelectedFilter();
                }
                else
                {
                    string fromdate = null;
                    string todate = null;
                    ViewState["fromdate"] = fromdate;
                    ViewState["todate"] = todate;
                    BindDropSite();
                    BindDropTechnician();
                    BindGridForAllParameter();
                    BindDropTechnician1();

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

    }
    protected void Log(string sMsg)
    {
        //File.AppendAllText(@"C:\Log\Log.txt", sMsg + Environment.NewLine);

    }

    #region Definition of BindGridForAllParameter() Function
    protected void BindGridForAllParameter()
    {
        
        #region Declaration of localvariable and table Variable
        int filterId;
        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();
        string userName = "";
        int varTechnicianId = 0;
        if (drpTechnician.SelectedValue != "") { varTechnicianId = Convert.ToInt32(drpTechnician.SelectedValue); }

        string varSortParameter = "";
        varSortParameter = drpSort.SelectedValue;
        if (varSortParameter == "0")
        { varSortParameter = "createdatetime"; }
        #endregion

        #region Get Current User and his Role
        MembershipUser User = Membership.GetUser();
        string varUserRole = "";
        string varRoleTechnician = "";
        if (User != null)
        {
            userName = User.UserName.ToString();

            string[] arrUserRole = Roles.GetRolesForUser();
            varUserRole = arrUserRole[0].ToString();
            varRoleTechnician = Resources.MessageResource.strTechnicianRole.ToString();


        }
        #endregion

        #region Get User object  by Calling Function Get_UserLogin_By_UserName() via passing parameter username and organizationid
        objOrganization = objOrganization.Get_Organization();
        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
        // objUser = objUser.Get_UserLogin_By_UserName_Ex(userName, objOrganization.Orgid);
        #endregion

        #region If User Exist
        if (objUser.Userid != 0)
        {
            ViewState["Userid"] = objUser.Userid;
            string fromdate = null;
            string todate = null;
            if (ViewState["fromdate"] != null)
            {
                fromdate = ViewState["fromdate"].ToString();
            }
            if (ViewState["todate"] != null)
            {
                todate = ViewState["todate"].ToString();
            }
            if (fromdate == "")
            { fromdate = null; }
            if (todate == "")
            { todate = null; }

            #region Find how many sites have been mapped to current user by calling function Get_All_By_userid() via passing parameter userid
            int userid = objUser.Userid;
            colUserToSite = ObjUserToSite.Get_All_By_userid(userid);
            #endregion
            #region Fetch each object from Collection of UserToSiteMapping
            foreach (UserToSiteMapping obj in colUserToSite)
            {
                #region Declare Local Variables and Collection of Incident_mst Type
                string Status;
                BLLCollection<Incident_mst> col = new BLLCollection<Incident_mst>();
                int siteid;
                #endregion
                #region Get the Siteid and Filter Parameter
                siteid = obj.Siteid;
                filterId = Convert.ToInt32(drpFilter.SelectedValue);
                #endregion

                #region If Role of User is Technician
                if (varUserRole == varRoleTechnician)
                {

                    lblTechnician.Visible = false;
                    drpTechnician.Visible = false;
                    #region If Filter Variable is All
                    if (filterId == 0)
                    {
                        col = objIncident.Get_All_By_Siteid_Technicianid(siteid, objUser.Userid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region If Filter Variable is Open
                    else if (filterId == 1)
                    {
                        Status = Resources.MessageResource.strStatusOpen.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region If Filter variable is Onhold
                    else if (filterId == 2)
                    {
                        Status = Resources.MessageResource.strStatusOnHold.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region If Filter Variable is Close
                    else if (filterId == 3)
                    {
                        Status = Resources.MessageResource.strStatusClose.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region If filter variable is resolved
                    else if (filterId == 4)
                    {
                        Status = Resources.MessageResource.strStatusResolved.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                    }
                    #endregion


                }
                #endregion
                #region If User Role is other than Technician
                else
                {
                    #region If Filter Variable is All
                    if (filterId == 0)
                    {
                        //varSortParameter
                        col = objIncident.Get_All_By_Siteid_Createdbyid(siteid, fromdate, todate, varTechnicianId, varSortParameter);
                    }
                    #endregion
                    #region If Filter Variable is Open
                    else if (filterId == 1)
                    {
                        Status = Resources.MessageResource.strStatusOpen.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                    }
                    #endregion
                    #region If Filter variable is Onhold
                    else if (filterId == 2)
                    {
                        Status = Resources.MessageResource.strStatusOnHold.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                    }
                    #endregion
                    #region If Filter Variable is Close
                    else if (filterId == 3)
                    {
                        Status = Resources.MessageResource.strStatusClose.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                    }
                    #endregion
                    #region If filter variable is resolved
                    else if (filterId == 4)
                    {
                        Status = Resources.MessageResource.strStatusResolved.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                    }
                    #endregion
                    #region If filter variable is UnAssigned
                    else if (filterId == 5)
                    {
                        Status = Resources.MessageResource.strStatusOpen.ToString();
                        int statusid;
                        statusid = objStatus.Get_By_StatusName(Status);
                        col = objIncident.Get_All_By_Siteid_Statusid_Unassigned(siteid, statusid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region If filter variable is Assigned
                    else if (filterId == 6)
                    {

                        col = objIncident.Get_All_By_Siteid_Assigned(siteid, fromdate, todate, varSortParameter);
                    }
                    #endregion
                    #region Else Condition will call using Filter variable all
                    else { col = objIncident.Get_All_By_Siteid_Createdbyid(siteid, fromdate, todate, varTechnicianId, varSortParameter); }
                    #endregion

                }
                #endregion



                #region Fetch Each object of type Incident_mst from Collection Incident_mst
                foreach (Incident_mst objInc in col)
                {

                    #region Create Table row and assign value to it
                    DataRow row;
                    row = dtTable.NewRow();
                    row["incidentid"] = Convert.ToString(objInc.Incidentid);
                    row["title"] = objInc.Title;
                    // row["extension"] = objInc.Extension;
                    row["requesterid"] = Convert.ToString(objInc.Requesterid);

                    row["createdbyid"] = Convert.ToString(objInc.Createdbyid);
                    row["siteid"] = Convert.ToString(objInc.Siteid);
                    row["createdatetime"] = Convert.ToString(objInc.Createdatetime);
                    objIncidentStates = objIncidentStates.Get_By_id(objInc.Incidentid);
                    row["statusid"] = objIncidentStates.Statusid;
                    row["technicianid"] = objIncidentStates.Technicianid;
                    row["priorityid"] = objIncidentStates.Priorityid;
                    dtTable.Rows.Add(row);
                    #endregion


                }
                #endregion
            }
            #endregion
            #region Bind Grid from datasource dtTable
            
            DataView dvData = new DataView(dtTable);
            //Log("dvData Count = " + dvData.Count.ToString());
            string sortFormat = "{0} {1}";
            //Log("sortFormat =" + sortFormat);
            String sortDirection = "DESC";
            //Log("sortDirection =" + sortDirection);
            if (varSortParameter == "createdatetime")
            {
                //Log("varSortParameter =" + varSortParameter);
                //varSortParameter = "incidentid";
                //Log("varSortParameter =" + varSortParameter);
            }
            dvData.Sort = String.Format(sortFormat, varSortParameter, sortDirection);
            //Log("********************************************");
            //for (int i = 0; i < dvData.Count; i++)
            //{
            //    Log(dvData[i][0].ToString());
            //}
            //Log("********************************************");
            grdvwRequest.DataSource = null;
            grdvwRequest.DataBind();

            grdvwRequest.DataSource = dvData;
            grdvwRequest.DataBind();
            
            #endregion
            if (varUserRole == varRoleTechnician)
            {
                RoleTechnician();
            }

        }
        #endregion



    }
    #endregion
    #region Handling GridView Row Databound Event
    int i = 1;
    protected void grdvwRequest_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            System.Drawing.ColorConverter colConvert = new ColorConverter();
            BLLCollection<ColorScheme_mst> colColor = new BLLCollection<ColorScheme_mst>();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region Autogenerate Serial number
                Label lblSerial = (Label)e.Row.FindControl("lblSerial");
                lblSerial.Text = i.ToString();
                i++;
                #endregion

                int TotalTimeSpentonCall;
                int TotalResolutionTime;


                int varIncidentid = Convert.ToInt32(((Label)e.Row.FindControl("incidentid")).Text.ToString());
                string varCreateDatetime = e.Row.Cells[9].Text;
                string varStatusOpen = Resources.MessageResource.strStatusOpen.ToString();
                string varStatusClose = Resources.MessageResource.strStatusClose.ToString();
                string varStatusOnHold = Resources.MessageResource.strStatusOnHold.ToString();

                string varStatusResolved = Resources.MessageResource.strStatusResolved.ToString();

                #region Bind Data Row at Run time with requesterid to Requester name
                int requesterid = Convert.ToInt32(e.Row.Cells[3].Text);
                //objUser = objUser.Get_By_id(requesterid);
                objContactmst = objContactmst.Get_By_id(requesterid);
                //if (objUser.Userid != 0)
                //{
                //    e.Row.Cells[3].Text = objUser.Username.ToString();
                //    //e.Row.Cells[3].Text = objContactmst.Firstname.ToString();
                //}
                //else { e.Row.Cells[3].Text = ""; }
                //if (objUser.Userid != 0)
                //{
                //e.Row.Cells[3].Text = objUser.Username.ToString();
                if (objContactmst.Firstname != null)
                {
                    e.Row.Cells[3].Text = objContactmst.Firstname.ToString();
                }
                // }else { e.Row.Cells[3].Text = ""; } 
                #endregion

                #region Bind Datarow at Run Time with Createdbyid to Created by name
                int createdbyid = Convert.ToInt32(e.Row.Cells[4].Text);
                objUser = objUser.Get_By_id(createdbyid);
                if (objUser.Userid != 0)
                {
                    e.Row.Cells[4].Text = objUser.Username.ToString();
                }
                else { e.Row.Cells[4].Text = ""; }
                #endregion

                #region Bind Datarow at Run Time with technicianid to technician name
                int technicianid = Convert.ToInt32(e.Row.Cells[5].Text);
                objUser = objUser.Get_By_id(technicianid);
                if (objUser.Userid != 0)
                {
                    e.Row.Cells[5].Text = objUser.Username.ToString();
                }
                else { e.Row.Cells[5].Text = ""; }
                #endregion

                #region Bind Datarow at run time with Statusid to Status
                int statusid = Convert.ToInt32(e.Row.Cells[6].Text);
                objStatus = objStatus.Get_By_id(statusid);
                if (objStatus.Statusid != 0)
                {


                    e.Row.Cells[6].Text = objStatus.Statusname.ToString();


                }
                else { e.Row.Cells[6].Text = ""; }
                #endregion

                #region Bind Datarow at run time with Priorityid to Priority
                int priorityid = Convert.ToInt32(e.Row.Cells[7].Text);
                objPriority = objPriority.Get_By_id(priorityid);
                if (objPriority.Priorityid != 0)
                { e.Row.Cells[7].Text = objPriority.Name.ToString(); }
                else { e.Row.Cells[7].Text = ""; }
                #endregion


                #region Bind Datarow at run time with Siteid to Site
                int siteid = Convert.ToInt32(e.Row.Cells[8].Text);
                objSite = objSite.Get_By_id(siteid);
                if (objSite.Siteid != 0)
                {
                    string custSiteName;
                    int custid = 0;
                    colCustToSite = objCustToSite.Get_All_By_siteid(objSite.Siteid);
                    foreach (CustomerToSiteMapping objCuToSite in colCustToSite)
                    {
                        custid = objCuToSite.Custid;

                    }
                    objCustomer = objCustomer.Get_By_id(custid);

                    e.Row.Cells[8].Text = objCustomer.Customer_name + "/" + objSite.Sitename.ToString();


                }
                else { e.Row.Cells[8].Text = ""; }
                #endregion

                #region Apply Color Coding to Open Calls,According to define SLA
                if (varStatusOpen.ToLower() == objStatus.Statusname.ToString().ToLower())
                {

                    Incident_mst obj = new Incident_mst();
                    obj = obj.Get_By_id(varIncidentid);
                    if (obj.Incidentid != 0)
                    {
                        if (obj.Slaid != 0)
                        {
                            #region Declare local variables,and objects of various classes
                            int percent;

                            ProcessEscalateEmail objPro = new ProcessEscalateEmail();
                            #endregion
                            #region Get Total Resolution time define for particular SLA and Time Spent on Request
                            TotalResolutionTime = objPro.GetResolutionTimeInMins(obj.Slaid);
                            TotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(varIncidentid, siteid, varCreateDatetime, DateTime.Now.ToString());
                            if (TotalTimeSpentonCall < 0)
                            {
                                TotalTimeSpentonCall = 0;
                            }
                            #endregion
                            #region Calculate Percent
                            if (TotalResolutionTime != 0)
                            {
                                percent = (TotalTimeSpentonCall * 100) / TotalResolutionTime;
                            }
                            else
                            {
                                percent = 0;
                            }

                            #endregion

                            ColorScheme_mst objColor = new ColorScheme_mst();
                            colColor = objColor.Get_All_By_CallStatus(varStatusOpen);


                            foreach (ColorScheme_mst objCol in colColor)
                            {
                                if (objCol.Percnt_to != 0)
                                {
                                    if (percent >= objCol.Percnt && percent <= objCol.Percnt_to)
                                    {
                                        e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(objCol.Colorname);
                                    }
                                }
                                else
                                {
                                    if (percent >= objCol.Percnt)
                                    {
                                        e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(objCol.Colorname);
                                    }

                                }

                            }


                        }
                        else
                        {
                            ColorScheme_mst objColor = new ColorScheme_mst();
                            colColor = objColor.Get_All_By_CallStatus("NonSLA");


                            foreach (ColorScheme_mst objCol in colColor)
                            {

                                e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(objCol.Colorname);
                            }

                        }
                    }





                }
                #endregion

                #region Apply Color Coding to Close Calls
                if (varStatusClose.ToLower() == objStatus.Statusname.ToString().ToLower())
                {
                    ColorScheme_mst objColor = new ColorScheme_mst();
                    colColor = objColor.Get_All_By_CallStatus(varStatusClose);
                    foreach (ColorScheme_mst obj in colColor)
                    {
                        try { e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(obj.Colorname); }
                        catch (Exception ex)
                        { e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("White"); }


                    }

                }
                #endregion

                #region Apply Color Coding to On Hold Calls
                if (varStatusOnHold.ToLower() == objStatus.Statusname.ToString().ToLower())
                {
                    ColorScheme_mst objColor = new ColorScheme_mst();
                    colColor = objColor.Get_All_By_CallStatus(varStatusOnHold);
                    foreach (ColorScheme_mst obj in colColor)
                    {
                        e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(obj.Colorname);

                    }

                }
                #endregion

                #region Apply Color Coding to Resolved Calls
                if (varStatusResolved.ToLower() == objStatus.Statusname.ToString().ToLower())
                {
                    ColorScheme_mst objColor = new ColorScheme_mst();
                    colColor = objColor.Get_All_By_CallStatus(varStatusResolved);
                    foreach (ColorScheme_mst obj in colColor)
                    {
                        e.Row.BackColor = (System.Drawing.Color)colConvert.ConvertFromString(obj.Colorname);

                    }

                }
                #endregion



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
    #endregion

    #region Create Datatable at Runtime
    protected DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.DataType = Type.GetType("System.Int32");
        myDataColumn.ColumnName = "incidentid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "title";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "requesterid";
        //  myDataColumn.ColumnName = "username";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "createdbyid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "technicianid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "statusid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.String");        
        myDataColumn.DataType = Type.GetType("System.DateTime");
        myDataColumn.ColumnName = "createdatetime";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "priorityid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "siteid";
        myDataTable.Columns.Add(myDataColumn);

        return myDataTable;
    }
    #endregion

    #region Handling Gridview Edit Button Event
    protected void grdvwRequest_RowEditing(object sender, GridViewEditEventArgs e)
    {

        int incidentid = Convert.ToInt32(grdvwRequest.Rows[e.NewEditIndex].Cells[0].Text);
        Response.Redirect("~/Incident/IncidentRequestUpdate.aspx?" + incidentid + " ");


    }
    #endregion
    //#region Handling Gridview Row Deleting Event
    //protected void grdvwRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    int incidentid;
    //    int varSiteid;
    //    incidentid = Convert.ToInt32(grdvwRequest.Rows[e.RowIndex].Cells[0].Text);

    //    objIncidentResolution.Delete(incidentid);

    //    colIncidentHistory = objIncidentHistory.Get_All_By_Incidentid(incidentid);
    //    foreach (IncidentHistory obj in colIncidentHistory)
    //    {
    //        int historyid = obj.Historyid;
    //        objIncidentHistoryDiff.Delete_By_Historyid(historyid);

    //    }
    //    objIncidentHistory.Delete_By_Incidentid(incidentid);
    //    objIncidentStates.Delete(incidentid);
    //    objIncident.Delete(incidentid);

    //    varSiteid = Convert.ToInt32(drpSite.SelectedValue);
    //    if (varSiteid == 0)
    //    { BindGridForAllParameter(); }
    //    else { BindGridForSelectedParameter(); }

    //}
    //#endregion

    #region Definition of Function BindDropSite()
    protected void BindDropSite()
    {
        string userName = "";
        MembershipUser User = Membership.GetUser();
        if (User != null)
        {
            userName = User.UserName.ToString();
        }

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
            ListItem item = new ListItem();
            item.Text = "-------------Select-------------";
            item.Value = "0";
            drpSite.Items.Add(item);
            drpSite.SelectedValue = "0";

            //drpSite1.DataTextField = "sitename";
            //drpSite1.DataValueField = "siteid";
            //drpSite1.DataSource = colSite;
            //drpSite1.DataBind();
            //ListItem item1= new ListItem();
            //item1.Text = "-------------Select-------------";
            //item1.Value = "0";
            //drpSite1.Items.Add(item1);
            //drpSite1.SelectedValue = "0";

        }




    }
    #endregion
    #region Handle Button Show Click Event
    protected void btnShow_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int varSiteid;
            int varFilterid;
            string vardate = "";
            string vardate1 = "";
            string datestr = TextBox1.Text.Trim();
            string datestr1 = TextBox2.Text.Trim();
            if (datestr != "")
            {
                string[] tempdate = datestr.ToString().Split(("/").ToCharArray());
                vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            }
            if (datestr1 != "")
            {
                string[] tempdate1 = datestr1.ToString().Split(("/").ToCharArray());
                vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];

            }



            ViewState["fromdate"] = vardate;
            ViewState["todate"] = vardate1;
            varSiteid = Convert.ToInt32(drpSite.SelectedValue);

            if (varSiteid == 0)
            { BindGridForAllParameter(); }
            else { BindGridForSelectedParameter(); }

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
    #region Definition of Function  BindGridForSelectedParameter()
    protected void BindGridForSelectedParameter()
    {
        
        #region Declaration of localvariable and table Variable
        int filterId;
        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();
        string userName = "";
        int varTechnicianId = Convert.ToInt32(drpTechnician.SelectedValue);
        string varSortParameter = "";
        varSortParameter = drpSort.SelectedValue;
        if (varSortParameter == "0")
        { varSortParameter = "createdatetime"; }
        #endregion

        #region Get Current User and his Role
        MembershipUser User = Membership.GetUser();
        string varUserRole = "";
        string varRoleTechnician = "";
        if (User != null)
        {
            userName = User.UserName.ToString();

            string[] arrUserRole = Roles.GetRolesForUser();
            varUserRole = arrUserRole[0].ToString();
            varRoleTechnician = Resources.MessageResource.strTechnicianRole.ToString();


        }
        #endregion

        #region Get User object  by Calling Function Get_UserLogin_By_UserName() via passing parameter username and organizationid
        objOrganization = objOrganization.Get_Organization();
        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
        #endregion



        #region If User Exist
        if (objUser.Userid != 0)
        {
            string fromdate = null;
            string todate = null;
            if (ViewState["fromdate"] != null)
            {
                fromdate = ViewState["fromdate"].ToString();
            }
            if (ViewState["todate"] != null)
            {
                todate = ViewState["todate"].ToString();
            }
            if (fromdate == "")
            { fromdate = null; }
            if (todate == "")
            { todate = null; }



            #region Declare Local Variables and Collection of Incident_mst Type
            string Status;
            BLLCollection<Incident_mst> col = new BLLCollection<Incident_mst>();
            int siteid;
            #endregion
            #region Get the Siteid and Filter Parameter
            siteid = Convert.ToInt32(drpSite.SelectedValue);
            filterId = Convert.ToInt32(drpFilter.SelectedValue);
            #endregion

            #region If Role of User is Technician
            if (varUserRole == varRoleTechnician)
            {

                lblTechnician.Visible = false;
                drpTechnician.Visible = false;
                #region If Filter Variable is All
                if (filterId == 0)
                {
                    col = objIncident.Get_All_By_Siteid_Technicianid(siteid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Open
                else if (filterId == 1)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region If Filter variable is Onhold
                else if (filterId == 2)
                {
                    Status = Resources.MessageResource.strStatusOnHold.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Close
                else if (filterId == 3)
                {
                    Status = Resources.MessageResource.strStatusClose.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region If filter variable is resolved
                else if (filterId == 4)
                {
                    Status = Resources.MessageResource.strStatusResolved.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid_technicianid(siteid, statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion


            }
            #endregion
            #region If User Role is other than Technician
            else
            {
                #region If Filter Variable is All
                if (filterId == 0)
                {

                    col = objIncident.Get_All_By_Siteid_Createdbyid(siteid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Open
                else if (filterId == 1)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter variable is Onhold
                else if (filterId == 2)
                {
                    Status = Resources.MessageResource.strStatusOnHold.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Close
                else if (filterId == 3)
                {
                    Status = Resources.MessageResource.strStatusClose.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If filter variable is resolved
                else if (filterId == 4)
                {
                    Status = Resources.MessageResource.strStatusResolved.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid(siteid, statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If filter variable is UnAssigned
                else if (filterId == 5)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = objIncident.Get_All_By_Siteid_Statusid_Unassigned(siteid, statusid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If filter variable is Assigned
                else if (filterId == 6)
                {

                    col = objIncident.Get_All_By_Siteid_Assigned(siteid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region Else Condition will call using Filter variable all
                else { col = objIncident.Get_All_By_Siteid_Createdbyid(siteid, fromdate, todate, varTechnicianId, varSortParameter); }
                #endregion

            }
            #endregion

            #region Fetch Each object of type Incident_mst from Collection Incident_mst
            foreach (Incident_mst objInc in col)
            {

                #region Create Table row and assign value to it
                DataRow row;
                row = dtTable.NewRow();
                row["incidentid"] = Convert.ToString(objInc.Incidentid);
                row["title"] = objInc.Title;
                row["requesterid"] = Convert.ToString(objInc.Requesterid);
                row["createdbyid"] = Convert.ToString(objInc.Createdbyid);
                row["siteid"] = Convert.ToString(objInc.Siteid);
                row["createdatetime"] = Convert.ToString(objInc.Createdatetime);
                objIncidentStates = objIncidentStates.Get_By_id(objInc.Incidentid);
                row["statusid"] = objIncidentStates.Statusid;
                row["technicianid"] = objIncidentStates.Technicianid;
                row["priorityid"] = objIncidentStates.Priorityid;
                dtTable.Rows.Add(row);
                #endregion


            }
            #endregion



        }
        #endregion

        #region Bind Grid from datasource dtTable
        DataView dvData = new DataView(dtTable);
        string sortFormat = "{0} {1}";
        String sortDirection = "DESC";
        if (varSortParameter == "createdatetime")
        {
            //varSortParameter = "incidentid";
        }
        if (varSortParameter == "incidentid")
        {
        }
        dvData.Sort = String.Format(sortFormat, varSortParameter, sortDirection);
        grdvwRequest.DataSource = null;
        grdvwRequest.DataBind();

        grdvwRequest.DataSource = dvData;
        grdvwRequest.DataBind();
        
        #endregion

        if (varUserRole == varRoleTechnician)
        {
            RoleTechnician();
        }


    }
    #endregion
    //#region Handle Button Find Click Event
    //protected void btnFind_Click(object sender, EventArgs e)
    //{
    //    #region Declaration of localvariable and table Variable

    //    int incidentid;
    //    incidentid = Convert.ToInt32(txtId.Text);
    //    DataTable dtTable = new DataTable();
    //    dtTable = CreateDataTable();
    //    string userName = "";
    //    BLLCollection<Incident_mst> col = new BLLCollection<Incident_mst>();
    //    #endregion
    //    col = objIncident.Get_All_Incidentid(incidentid);
    //    #region Fetch Each object of type Incident_mst from Collection Incident_mst
    //    foreach (Incident_mst objInc in col)
    //    {

    //        #region Create Table row and assign value to it
    //        DataRow row;
    //        row = dtTable.NewRow();
    //        row["incidentid"] = Convert.ToString(objInc.Incidentid);
    //        row["title"] = objInc.Title;
    //        row["requesterid"] = Convert.ToString(objInc.Requesterid);
    //        row["createdbyid"] = Convert.ToString(objInc.Createdbyid);
    //        row["siteid"] = Convert.ToString(objInc.Siteid);
    //        row["createdatetime"] = Convert.ToString(objInc.Createdatetime);
    //        objIncidentStates = objIncidentStates.Get_By_id(objInc.Incidentid);
    //        row["statusid"] = objIncidentStates.Statusid;
    //        row["technicianid"] = objIncidentStates.Technicianid;
    //        row["priorityid"] = objIncidentStates.Priorityid;
    //        dtTable.Rows.Add(row);
    //        #endregion


    //    }
    //    #endregion
    //    #region Bind Grid from datasource dtTable
    //    grdvwRequest.DataSource = dtTable;
    //    grdvwRequest.DataBind();
    //    #endregion
    //}
    //#endregion

    #region Handling Gridview Page Indexing Event
    protected void grdvwRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            // Hndling GridView PageIndex Change Event for Paging  
            grdvwRequest.PageIndex = e.NewPageIndex;
            // On Selected Page Index Bind Grid here

            if (ViewState["keyword"] != null)
            {
                Session["Filterid"] = ViewState["Filterid"].ToString();
                Session["keyword"] = ViewState["keyword"].ToString();
                ViewState.Remove("Filterid");
                ViewState.Remove("keyword");
                BindSelectedFilter();

            }
            else
            {


                if (drpSite.SelectedValue != "")
                {
                    int varSiteid = Convert.ToInt32(drpSite.SelectedValue);
                    if (varSiteid == 0)
                    { BindGridForAllParameter(); }
                    else { BindGridForSelectedParameter(); }
                }
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
    #endregion
    #region Handle Drop Down Select Index Change Event
    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
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
    #endregion
    #region Definition of BindDropTechnician()
    protected void BindDropTechnician()
    {
        string vartechnician = Resources.MessageResource.strTechnicianRole.ToString();
        objRole = objRole.Get_RoleInfo_By_RoleName(vartechnician);
        if (objRole.Roleid != 0)
        {
            int siteid;
            int roleid;
            if (drpSite.SelectedValue != "")
            {
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
                    item.Text = "-------------Select-------------";
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
                    item.Text = "-------------Select-------------";
                    item.Value = "0";
                    drpTechnician.Items.Add(item);
                    drpTechnician.SelectedValue = "0";


                }
            }

        }





    }
    #endregion

    #region Handle Button btnDelete_Click Event
    protected void btnDelete_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            foreach (GridViewRow gv in grdvwRequest.Rows)
            {
                string gvIDs;
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {
                    int incidentid;
                    int varSiteid = 0;
                    // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                    gvIDs = ((Label)gv.FindControl("incidentid")).Text.ToString();
                    incidentid = Convert.ToInt32(gvIDs);
                    // Check if gvIDs is not null
                    if (gvIDs != "")
                    {
                        Incident_mst objInc_mst = new Incident_mst();
                        objInc_mst = objIncident.Get_By_id(incidentid);
                        objInc_mst.Active = false;
                        objInc_mst.Update();

                        if (drpSite.SelectedValue != "")
                        {
                            varSiteid = Convert.ToInt32(drpSite.SelectedValue);
                        }

                        if (varSiteid == 0)
                        { BindGridForAllParameter(); }
                        else { BindGridForSelectedParameter(); }

                    }

                }
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
    #endregion
    protected void RoleTechnician()
    {
        btnDelete.Visible = false;
        //btnAssigned.Visible = false;
        //drpTechnician1.Visible = false;
        //drpSite1.Visible = false;
        //lblSite1.Visible = false;
        //lblTechnician1.Visible = false;
        foreach (GridViewRow gv in grdvwRequest.Rows)
        {
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            deleteChkBxItem.Visible = false;
            deleteChkBxItem.Enabled = false;
        }


    }
    #region Handle DropSite1 Select Index Change Event
    //protected void drpSite1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindDropTechnician1();
    //}
    #endregion


    #region Definition of BindDropTechnician1()
    protected void BindDropTechnician1()
    {

        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        if (objRole.Roleid != 0)
        {
            int siteid;
            int roleid;
            //if (drpSite1.SelectedValue != "")
            //{
            //    siteid = Convert.ToInt32(drpSite1.SelectedValue);
            //    roleid = objRole.Roleid;
            //    if (siteid != 0 && roleid != 0)
            //    {
            //        colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
            //        drpTechnician1.DataTextField = "username";
            //        drpTechnician1.DataValueField = "userid";
            //        drpTechnician1.DataSource = colUser;
            //        drpTechnician1.DataBind();
            //        ListItem item = new ListItem();
            //        item.Text = "-------------Select-------------";
            //        item.Value = "0";
            //        drpTechnician1.Items.Add(item);
            //        drpTechnician1.SelectedValue = "0";

            //    }
            //    else
            //    {

            //        colUser = objUser.Get_All_By_Role_Site(roleid, siteid);
            //        drpTechnician1.DataTextField = "username";
            //        drpTechnician1.DataValueField = "userid";
            //        drpTechnician1.DataSource = colUser;
            //        drpTechnician1.DataBind();
            //        ListItem item = new ListItem();
            //        item.Text = "-------------Select-------------";
            //        item.Value = "0";
            //        drpTechnician1.Items.Add(item);
            //        drpTechnician1.SelectedValue = "0";


            //    }
            //}

        }





    }
    #endregion


    //#region Handle Button btnAssigned Click Event
    //protected void btnAssigned_Click(object sender, EventArgs e)
    //{
    //    #region Fetch Each Row from GridView,and Check Which Check Box is Selected
    //    foreach (GridViewRow gv in grdvwRequest.Rows)
    //    {
    //        string gvIDs;
    //        #region Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
    //         CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
    //        #endregion
    //        #region If deleteChkBxItem is Checked then ,mapped Current site to this user
    //         if (deleteChkBxItem.Checked)
    //        {
    //            #region Declare local Variables
    //            int incidentid;
    //            int varSiteid;
    //            int oldtechnicianvalue;
    //            #endregion
    //            #region Get the Incident Id from variable of Label type declare in GridView of grdvwSite
    //              gvIDs = ((Label)gv.FindControl("incidentid")).Text.ToString();
    //            #endregion
    //            #region Convert to incident id into integer
    //              incidentid = Convert.ToInt32(gvIDs);
    //              #endregion 
    //            #region If Incident id in Not Null
    //            if (gvIDs != "")
    //            {
    //                Incident_mst objInc = new Incident_mst();

    //                IncidentStates objIncSta = new IncidentStates();
    //                objIncSta = objIncSta.Get_By_id(incidentid);
    //                if (objIncSta.Incidentid != 0)
    //                {
    //                    oldtechnicianvalue = objIncSta.Technicianid;
    //                    int technicianid=Convert.ToInt32(drpTechnician1.SelectedValue);
    //                    if(technicianid!=0)
    //                    {
    //                     int userid = Convert.ToInt32(ViewState["Userid"].ToString());
    //                    #region Update into IncidentStates Table
    //                     objIncidentStates.Incidentid = incidentid;
    //                    objIncidentStates.Technicianid = technicianid;
    //                    objIncidentStates.Subcategoryid = objIncSta.Subcategoryid;
    //                    objIncidentStates.Statusid = objIncSta.Statusid;
    //                    objIncidentStates.Requesttypeid = objIncSta.Requesttypeid;
    //                    objIncidentStates.Priorityid = objIncSta.Priorityid;
    //                    objIncidentStates.Categoryid = objIncSta.Categoryid;
    //                    objIncidentStates.AssignedTime = objIncSta.AssignedTime;
    //                    objIncidentStates.Update();
    //                     #endregion

    //                    #region Insert into IncidentHistory Table
    //                    objIncidentHistory.Incidentid = incidentid;
    //                    objIncidentHistory.Operationownerid = userid;
    //                    objIncidentHistory.Operation = "update";
    //                    objIncidentHistory.Insert();
    //                    #endregion

    //                    #region Get the Current historyid by calling function Get_Current_IncidentHistoryid()
    //                    int  historyid = objIncidentHistory.Get_Current_IncidentHistoryid();
    //                    #endregion

    //                   #region If technician value is changed,Insert into IncidentHistoryDiff table
    //                    #region Declare Local variables
    //                        string columnName;
    //                        string prev_value;
    //                        string curnt_value;
    //                    #endregion
    //                    #region Get Column Name from MessageResource File
    //                        columnName = Resources.MessageResource.strColumnTechnicianid.ToString();
    //                        #endregion
    //                       prev_value = Convert.ToString(oldtechnicianvalue);
    //                       curnt_value = Convert.ToString(drpTechnician1.SelectedValue);
    //                       objIncidentHistoryDiff.Historyid = historyid;
    //                       objIncidentHistoryDiff.Columnname = columnName;
    //                       objIncidentHistoryDiff.Current_value = curnt_value;
    //                       objIncidentHistoryDiff.Prev_value = prev_value;
    //                       objIncidentHistoryDiff.Insert();
    //                       if (objIncSta.AssignedTime == null)
    //                       {
    //                           columnName = Resources.MessageResource.strColumnAssignedTime.ToString();
    //                           prev_value = "0";
    //                           curnt_value = DateTime.Now.ToString();
    //                           objIncidentHistoryDiff.Historyid = historyid;
    //                           objIncidentHistoryDiff.Columnname = columnName;
    //                           objIncidentHistoryDiff.Current_value = curnt_value;
    //                           objIncidentHistoryDiff.Prev_value = prev_value;
    //                           objIncidentHistoryDiff.Insert();

    //                       }
    //                       else
    //                       {
    //                           columnName = "AssignedTime";
    //                           prev_value = objIncSta.AssignedTime;
    //                           curnt_value = DateTime.Now.ToString();
    //                           objIncidentHistoryDiff.Historyid = historyid;
    //                           objIncidentHistoryDiff.Columnname = columnName;
    //                           objIncidentHistoryDiff.Current_value = curnt_value;
    //                           objIncidentHistoryDiff.Prev_value = prev_value;
    //                           objIncidentHistoryDiff.Insert();
    //                       }



    //                   #endregion

    //                       objInc = objIncident.Get_By_id(incidentid);
    //                       if (objInc.Siteid != Convert.ToInt32(drpSite1.SelectedValue))
    //                       {
    //                           int oldsiteid = objInc.Siteid;
    //                           int oldslaid = objInc.Slaid;

    //                           objInc.Siteid = Convert.ToInt32(drpSite1.SelectedValue);
    //                           int SLAid = objIncident.Get_By_SLAid(Convert.ToInt32(drpSite1.SelectedValue), objIncSta.Priorityid );
    //                           int requesttypeid = Convert.ToInt32(Resources.MessageResource.strRequestTypeId.ToString());
    //                           if (requesttypeid == Convert.ToInt32(objIncSta.Requesttypeid ))
    //                           {
    //                               SLAid = 0;
    //                           }

    //                           objInc.Slaid = SLAid;
    //                           objInc.Active = true;
    //                           objInc.Update();

    //                           #region If site value is changed,Insert into IncidentHistoryDiff table

    //                           columnName = Resources.MessageResource.strColumnSiteid.ToString();
    //                           prev_value = Convert.ToString(oldsiteid);
    //                           curnt_value = drpSite1.SelectedValue;
    //                           objIncidentHistoryDiff.Historyid = historyid;
    //                           objIncidentHistoryDiff.Columnname = columnName;
    //                           objIncidentHistoryDiff.Current_value = curnt_value;
    //                           objIncidentHistoryDiff.Prev_value = prev_value;
    //                           objIncidentHistoryDiff.Insert();

    //                           #endregion
    //                           #region If SLA value is changed,Insert into IncidentHistoryDiff table


    //                           columnName = Resources.MessageResource.strColumnSLAid.ToString();
    //                           prev_value = Convert.ToString(oldslaid);
    //                           curnt_value = Convert.ToString(SLAid);
    //                           objIncidentHistoryDiff.Historyid = historyid;
    //                           objIncidentHistoryDiff.Columnname = columnName;
    //                           objIncidentHistoryDiff.Current_value = curnt_value;
    //                           objIncidentHistoryDiff.Prev_value = prev_value;
    //                           objIncidentHistoryDiff.Insert();

    //                           #endregion


    //                       }

    //                    }

    //                }





    //                varSiteid = Convert.ToInt32(drpSite.SelectedValue);
    //                if (varSiteid == 0)
    //                { BindGridForAllParameter(); }
    //                else { BindGridForSelectedParameter(); }

    //            }
    //            #endregion

    //        }
    //         #endregion
    //    }
    //    #endregion


    //}
    //#endregion


    protected void BindSelectedFilter()
    {
        string keyword = Session["keyword"].ToString();
        string Filterid = Session["Filterid"].ToString();
        string userName = "";
        MembershipUser User = Membership.GetUser();
        if (User != null)
        {
            userName = User.UserName.ToString();
        }
        objOrganization = objOrganization.Get_Organization();
        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
        string Uid = objUser.Userid.ToString();

        #region Declaration of localvariable and table Variable
        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();

        #endregion
        BLLCollection<Incident_mst> col = new BLLCollection<Incident_mst>();
        col = objIncident.Get_All_Incidentid_By_SearchParameter(Filterid, keyword,Uid);        
        #region Create Table row and assign value to it
        foreach (Incident_mst obj in col)
        {
            IncidentStates objS = new IncidentStates();
            DataRow row;
            row = dtTable.NewRow();
            row["incidentid"] = Convert.ToString(obj.Incidentid);
            row["title"] = obj.Title;
            row["requesterid"] = Convert.ToString(obj.Requesterid);
            row["createdbyid"] = Convert.ToString(obj.Createdbyid);
            row["siteid"] = Convert.ToString(obj.Siteid);
            row["createdatetime"] = Convert.ToString(obj.Createdatetime);
            objS = objS.Get_By_id(obj.Incidentid);
            row["statusid"] = objS.Statusid;
            row["technicianid"] = objS.Technicianid;
            row["priorityid"] = objS.Priorityid;
            dtTable.Rows.Add(row);
        }
        #endregion

        grdvwRequest.DataSource = dtTable;
        grdvwRequest.DataBind();
        Session.Remove("Filterid");
        Session.Remove("keyword");
        ViewState["keyword"] = keyword;
        ViewState["Filterid"] = Filterid;

    }
}
