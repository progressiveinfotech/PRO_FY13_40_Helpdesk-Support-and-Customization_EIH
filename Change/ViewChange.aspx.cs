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

public partial class Change_ViewChange : System.Web.UI.Page
{
    BLLCollection<Change_mst> col = new BLLCollection<Change_mst>();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    ChangeStatus_mst ObjChangeStatus = new ChangeStatus_mst();
    Change_mst ObjChange = new Change_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    Problem_mst ObjProblem = new Problem_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Priority_mst objPriority = new Priority_mst();
    Organization_mst objOrganization = new Organization_mst();

    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                string fromdate = null;
                string todate = null;
                ViewState["fromdate"] = fromdate;
                ViewState["todate"] = todate;
                //Bindgrid();
                BindDropTechnician();
                BindDropTechnicianAssign();
                BindGridForAllParameter();
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

    protected void BindGrid()
    {
        col = ObjChange.Get_All();
        grdvwChange.DataSource = col;
        grdvwChange.DataBind();

    }
    protected void BindDropTechnician()
    {
        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        int roleid = Convert.ToInt32(objRole.Roleid);
        coltechnician = ObjUserLogin.Get_All_By_Role(roleid);
        drpTechnician.DataTextField = "username";
        drpTechnician.DataValueField = "userid";
        drpTechnician.DataSource = coltechnician;
        drpTechnician.DataBind();
        ListItem item = new ListItem();
        item.Text = "---Select Technician---";
        item.Value = "0";
        drpTechnician.Items.Add(item);
        drpTechnician.SelectedValue = "0";



    }
    #region Bind Grid For All Parameter
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
        #endregion
        #region if UserExist
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
            #region Declare Local Variables and Collection of Incident_mst Type
            string Status;

            //            int siteid;
            #endregion
            #region Get the Siteid and Filter Parameter
            //siteid = obj.Siteid;
            filterId = Convert.ToInt32(drpFilter.SelectedValue);
            #endregion
            #region If Role of User is Technician
            if (varUserRole == varRoleTechnician)
            {
                lblTechnician.Visible = false;
                drpTechnician.Visible = false;
                //lblTechnician1.Visible = false;
                //drpTechnician1.Visible = false;
                //btnAssigned.Visible = false;
                #region If Filter Variable is All
                if (filterId == 0)
                {
                    //  col = objIncident.Get_All_By_Siteid_Technicianid(siteid, objUser.Userid, fromdate, todate, varSortParameter);
                    ////////////change done by meenakshi
                    col = ObjChange.Get_All();

                    ///////////end

                }
                #endregion
                    ///////////////////////////////////////////////change done by meenakshi
                #region If Filter Variable is Requested
                else if (filterId == 1)
                {

                    Status = Resources.MessageResource.strChangestatusrequested.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Completed
                else if (filterId == 2)
                {

                    Status = Resources.MessageResource.StrCompleted.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Approved
                else if (filterId == 3)
                {

                    Status = Resources.MessageResource.StrApproved.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Planning
                else if (filterId == 4)
                {

                    Status = Resources.MessageResource.StrPlanning.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Testing
                else if (filterId == 5)
                {

                    Status = Resources.MessageResource.StrTesting.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Release
                else if (filterId == 6)
                {

                    Status = Resources.MessageResource.StrRelease.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Implemented
                else if (filterId == 7)
                {

                    Status = Resources.MessageResource.StrImplemented.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Approval
                else if (filterId == 8)
                {

                    Status = Resources.MessageResource.StrApproval.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
               
                #region If Filter Variable is Rejected
                else if (filterId == 9)
                {

                    Status = Resources.MessageResource.StrRejected.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }

                #endregion
                
                
            }
            #endregion
            #region If User Role is other then technician
            else
            {
                #region If Filter Variable is All
                if (filterId == 0)
                {
                      //col = objIncident.Get_All_By_Siteid_Technicianid(siteid, objUser.Userid, fromdate, todate, varSortParameter);
                    ////////////change done by meenakshi
                    col = ObjChange.Get_All();

                    ///////////end

                }
                #endregion
                #region If Filter Variable is Requested
                else if (filterId == 1)
                {

                    Status = Resources.MessageResource.strChangestatusrequested.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);


                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Completed
                else if (filterId == 2)
                {

                    Status = Resources.MessageResource.StrCompleted.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

               
                #endregion
                #region If Filter Variable is Approved
                else if (filterId == 3)
                {

                    Status = Resources.MessageResource.StrApproved.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Planning
                else if (filterId == 4)
                {

                    Status = Resources.MessageResource.StrPlanning.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Testing
                else if (filterId == 5)
                {

                    Status = Resources.MessageResource.StrTesting.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Release
                else if (filterId == 6)
                {

                    Status = Resources.MessageResource.StrRelease.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Implemented
                else if (filterId == 7)
                {

                    Status = Resources.MessageResource.StrImplemented.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                #region If Filter Variable is Approval
                else if (filterId == 8)
                {

                    Status = Resources.MessageResource.StrApproval.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                
                #region If Filter Variable is Rejected
                else if (filterId == 9)
                {

                    Status = Resources.MessageResource.StrRejected.ToString();
                    int statusid;

                    statusid = ObjChangeStatus.Get_By_StatusName(Status);

                    col = ObjChange.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }

                #endregion
                
                
                ////////////////////////////////////////////////////////////end
            }
            #endregion

        }
        #endregion
        #region Fetch Each object of type Change_mst from Collection Change_mst
        foreach (Change_mst obj in col)
        {

            #region Create Table row and assign value to it
            DataRow row;
            row = dtTable.NewRow();
            row["Changeid"] = Convert.ToString(obj.Changeid);
            row["title"] = obj.Title;
            row["Requestedby"] = Convert.ToString(obj.Requestedby);
            row["CreatedByid"] = Convert.ToString(obj.CreatedByID);
            row["Technician"] = Convert.ToString(obj.Technician);
            row["Statusid"] = obj.Statusid;
            row["Priority"] = obj.Priority;
            row["Createdtime"] = obj.Createdtime;
            dtTable.Rows.Add(row);
            #endregion


        }
        //}
        #endregion
        #region Bind Grid from datasource dtTable
        grdvwChange.DataSource = dtTable;
        grdvwChange.DataBind();

        #endregion
    }
    #endregion
    #region Handling GridView Row Databound Event
    int i = 1;
    protected void grdvwChange_RowDataBound(Object sender, GridViewRowEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //System.Drawing.ColorConverter colConvert = new ColorConverter();
            //BLLCollection<ColorScheme_mst> colColor = new BLLCollection<ColorScheme_mst>();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if(col.Count!=0)
                //{

                #region Autogenerate Serial number
                //Label lblSerial = (Label)e.Row.FindControl("lblSerial");
                //lblSerial.Text = i.ToString();
                //i++;
                #endregion

                int TotalTimeSpentonCall;
                int TotalResolutionTime;



                string varStatusOpen = Resources.MessageResource.strStatusOpen.ToString();
                string varStatusClose = Resources.MessageResource.strStatusClose.ToString();
                string varStatusOnHold = Resources.MessageResource.strStatusOnHold.ToString();
                string varStatusResolved = Resources.MessageResource.strStatusResolved.ToString();

                #region Bind Data Row at Run time with requesterid to Requester name
                int requesterid = Convert.ToInt32(e.Row.Cells[2].Text);
                objUser = objUser.Get_By_id(requesterid);

                if (objUser.Userid != 0)
                {
                    e.Row.Cells[2].Text = objUser.Username.ToString();
                }
                else { e.Row.Cells[2].Text = ""; }
                #endregion

                #region Bind Datarow at Run Time with Createdbyid to Created by name
                int createdbyid = Convert.ToInt32(e.Row.Cells[3].Text);
                objUser = objUser.Get_By_id(createdbyid);
                if (objUser.Userid != 0)
                {
                    e.Row.Cells[3].Text = objUser.Username.ToString();
                }
                else { e.Row.Cells[3].Text = ""; }
                #endregion

                #region Bind Datarow at Run Time with technicianid to technician name
                int technicianid = Convert.ToInt32(e.Row.Cells[4].Text);
                objUser = objUser.Get_By_id(technicianid);
                if (objUser.Userid != 0)
                {
                    e.Row.Cells[4].Text = objUser.Username.ToString();
                }
                else { e.Row.Cells[4].Text = ""; }
                #endregion

                #region Bind Datarow at run time with Statusid to Status
                int statusid = Convert.ToInt32(e.Row.Cells[5].Text);

                ObjChangeStatus = ObjChangeStatus.Get_By_id(statusid);
                if (ObjChangeStatus.ChangeStatusid != 0)
                {


                    e.Row.Cells[5].Text = ObjChangeStatus.Statusname.ToString();


                }
                else { e.Row.Cells[5].Text = ""; }
                #endregion

                #region Bind Datarow at run time with Priorityid to Priority
                int priorityid = Convert.ToInt32(e.Row.Cells[6].Text);
                objPriority = objPriority.Get_By_id(priorityid);
                if (objPriority.Priorityid != 0)
                { e.Row.Cells[6].Text = objPriority.Name.ToString(); }
                else { e.Row.Cells[6].Text = ""; }
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
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ChangeID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "title";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Requestedby";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CreatedByid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Technician";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Statusid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Priority";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Createdtime";
        myDataTable.Columns.Add(myDataColumn);



        return myDataTable;
    }
    #endregion
    #region Handle Button Show Click Event
    protected void btnShow_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
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



            BindGridForAllParameter();

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
    protected void BindDropTechnicianAssign()
    {
        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        int roleid = Convert.ToInt32(objRole.Roleid);
        coltechnician = ObjUserLogin.Get_All_By_Role(roleid);
        //drpTechnician1.DataTextField = "username";
        //drpTechnician1.DataValueField = "userid";
        //drpTechnician1.DataSource = coltechnician;
        //drpTechnician1.DataBind();
        //ListItem item = new ListItem();
        //item.Text = "---Select Technician---";
        //item.Value = "0";
        //drpTechnician1.Items.Add(item);
        //drpTechnician1.SelectedValue = "0";



    }
    //#region Handle Button btnAssigned Click Event
    //protected void btnAssigned_Click(object sender, EventArgs e)
    //{
    //    #region Fetch Each Row from GridView,and Check Which Check Box is Selected
    //    foreach (GridViewRow gv in grdvwChange.Rows)
    //    {
    //        string gvIDs;
    //        #region Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
    //        CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
    //        #endregion
    //        #region If deleteChkBxItem is Checked then ,mapped Current site to this user
    //        if (deleteChkBxItem.Checked)
    //        {
    //            #region Declare local Variables
    //            int Changeid;
    //            int varSiteid;
    //            int oldtechnicianvalue;
    //            #endregion
    //            #region Get the Problemid from variable of Label type declare in GridView of grdvwSite
    //            gvIDs = ((Label)gv.FindControl("Changeid")).Text.ToString();
    //            #endregion
    //            #region Convert to incident id into integer
    //            Changeid = Convert.ToInt32(gvIDs);
    //            #endregion
    //            #region If Incident id in Not Null
    //            if (gvIDs != "")
    //            {
    //                Change_mst Obj = new Change_mst();

    //                Obj = ObjChange.Get_By_id(Changeid);
    //                if (Obj.Changeid!= 0)
    //                {
    //                    int technicianid = Convert.ToInt32(drpTechnician1.SelectedValue);
    //                    if (technicianid != 0)
    //                    {
    //                        Obj.Technician= technicianid;
    //                        Obj.Update();
    //                    }
    //                }
    //            }
    //            #endregion










    //        }
    //        #endregion

    //    }
    //    BindGridForAllParameter();
    //    #endregion
    //}
    //#endregion
    #region Handle Button btnCancell Click Event
    protected void btnCancell_Click(object sender, EventArgs e)
    {
        #region Fetch Each Row from GridView,and Check Which Check Box is Selected
        foreach (GridViewRow gv in grdvwChange.Rows)
        {
            string gvIDs;
            #region Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            #endregion
            #region If deleteChkBxItem is Checked then ,mapped Current site to this user
            if (deleteChkBxItem.Checked)
            {
                #region Declare local Variables
                int Changeid;
                int varSiteid;
                int oldtechnicianvalue;
                #endregion
                #region Get the Problemid from variable of Label type declare in GridView of grdvwSite
                gvIDs = ((Label)gv.FindControl("Changeid")).Text.ToString();
                #endregion
                #region Convert to incident id into integer
                Changeid = Convert.ToInt32(gvIDs);
                #endregion
                #region If Incident id in Not Null
                if (gvIDs != "")
                {
                    Change_mst Obj = new Change_mst();

                    Obj = ObjChange.Get_By_id(Changeid);
                    if (Obj.Changeid != 0)
                    {


                        Obj.Active = false;

                        Obj.Update();

                    }
                }
                #endregion










            }
            #endregion

        }
        BindGridForAllParameter();
        #endregion
    }
    #endregion
    protected void grdvwChange_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            grdvwChange.PageIndex = e.NewPageIndex;
            BindGridForAllParameter();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void grdvwChange_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
