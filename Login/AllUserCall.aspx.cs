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

public partial class Login_AllUserCall : System.Web.UI.Page
{
    #region Object Declaration
    Organization_mst objOrganization = new Organization_mst();
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
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                Bindgrid();
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
    protected void Bindgrid()
    {
        #region Declaration of localvariable and table Variable
        int filterId;
        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();
        string userName = "";
        int varTechnicianId = 0;
        string varSortParameter = "createdatetime";

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
                filterId = 0;
                #endregion

                #region If Role of User is Technician



                #region If Filter Variable is All
                if (filterId == 0)
                {
                    col = objIncident.Get_All_By_Siteid_Requesterid(siteid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion




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
                varSortParameter = "incidentid";
            }
            dvData.Sort = String.Format(sortFormat, varSortParameter, sortDirection);




            grdvwRequest.DataSource = dvData;
            grdvwRequest.DataBind();
            #endregion


        }
        #endregion

    }

    #region Create Datatable at Runtime
    protected DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "incidentid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "title";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "requesterid";
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
        myDataColumn.DataType = Type.GetType("System.String");
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


    #region Handling GridView Row Databound Event
    int i = 1;
    protected void grdvwRequest_RowDataBound(Object sender, GridViewRowEventArgs e)
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
            objUser = objUser.Get_By_id(requesterid);

            if (objUser.Userid != 0)
            {
                e.Row.Cells[3].Text = objUser.Username.ToString();
            }
            else { e.Row.Cells[3].Text = ""; }
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
            //e.Row.Cells[8].Text = ""; 

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
                        percent = (TotalTimeSpentonCall * 100) / TotalResolutionTime;

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
    #endregion



    #region Handling Gridview Page Indexing Event
    protected void grdvwRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        // Hndling GridView PageIndex Change Event for Paging  
        grdvwRequest.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here

        Bindgrid();


    }
    #endregion


}
