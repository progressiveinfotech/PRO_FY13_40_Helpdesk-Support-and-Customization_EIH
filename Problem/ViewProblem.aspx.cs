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

public partial class Problem_ViewProblem : System.Web.UI.Page
{
    Problem_mst ObjProblem = new Problem_mst();
    BLLCollection<Problem_mst> col = new BLLCollection<Problem_mst>();
    Priority_mst objPriority = new Priority_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Status_mst objStatus = new Status_mst();
    Organization_mst objOrganization = new Organization_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();


    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
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
                    BindDropTechnician();
                    BindDropTechnicianAssign();
                    BindGridForAllParameter();
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

                btnCancell.Visible = false;
                #region If Filter Variable is All
                if (filterId == 0)
                {
                    //  col = objIncident.Get_All_By_Siteid_Technicianid(siteid, objUser.Userid, fromdate, todate, varSortParameter);

                }
                #endregion
                #region If Filter Variable is Open
                else if (filterId == 1)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);

                }
                #endregion
                #region If Filter variable is Onhold
                else if (filterId == 2)
                {
                    Status = Resources.MessageResource.strStatusOnHold.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);

                }
                #endregion
                #region If Filter Variable is Close
                else if (filterId == 3)
                {
                    Status = Resources.MessageResource.strStatusClose.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
                }
                #endregion
                #region If filter variable is resolved
                else if (filterId == 4)
                {
                    Status = Resources.MessageResource.strStatusResolved.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid_technicianid(statusid, objUser.Userid, fromdate, todate, varSortParameter);
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

                    col = ObjProblem.Get_All_By_Createdbyid(fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Open
                else if (filterId == 1)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);

                    col = ObjProblem.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter variable is Onhold
                else if (filterId == 2)
                {
                    Status = Resources.MessageResource.strStatusOnHold.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If Filter Variable is Close
                else if (filterId == 3)
                {
                    Status = Resources.MessageResource.strStatusClose.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);
                    col = ObjProblem.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If filter variable is resolved
                else if (filterId == 4)
                {
                    Status = Resources.MessageResource.strStatusResolved.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);

                    col = ObjProblem.Get_All_By_Statusid(statusid, fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion
                #region If filter variable is UnAssigned
                else if (filterId == 5)
                {
                    Status = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid;
                    statusid = objStatus.Get_By_StatusName(Status);

                    col = ObjProblem.Get_All_By_Statusid_Unassigned(statusid, fromdate, todate, varSortParameter);

                }
                #endregion
                #region If filter variable is Assigned
                else if (filterId == 6)
                {


                    col = ObjProblem.Get_All_By_Assigned(fromdate, todate, varSortParameter);
                }
                #endregion
                #region Else Condition will call using Filter variable all
                else
                {

                    col = ObjProblem.Get_All_By_Createdbyid(fromdate, todate, varTechnicianId, varSortParameter);
                }
                #endregion

            }
            #endregion




        }


        #region Fetch Each object of type Incident_mst from Collection Incident_mst
        foreach (Problem_mst obj in col)
        {

            #region Create Table row and assign value to it
            DataRow row;
            row = dtTable.NewRow();
            row["ProblemId"] = Convert.ToString(obj.ProblemId);
            row["title"] = obj.title;
            row["Requesterid"] = Convert.ToString(obj.Requesterid);
            row["CreatedByid"] = Convert.ToString(obj.CreatedByid);
            row["Technicianid"] = Convert.ToString(obj.Technicianid);
            row["Statusid"] = obj.Statusid;
            row["Priorityid"] = obj.Priorityid;
            row["CreateDatetime"] = obj.CreateDatetime;
            dtTable.Rows.Add(row);
            #endregion


        }
        //}
        #endregion
        #region Bind Grid from datasource dtTable
        grdvwProblem.DataSource = dtTable;
        grdvwProblem.DataBind();

        #endregion
        #endregion
        if (varUserRole == varRoleTechnician)
        {
            ///RoleTechnician();
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
        myDataColumn.ColumnName = "ProblemId";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "title";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Requesterid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CreatedByid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "technicianid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Statusid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Priorityid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CreateDatetime";
        myDataTable.Columns.Add(myDataColumn);



        return myDataTable;
    }
    #endregion
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
    #region Handling GridView Row Databound Event
    int i = 1;
    protected void grdvwProblem_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //System.Drawing.ColorConverter colConvert = new ColorConverter();
        //BLLCollection<ColorScheme_mst> colColor = new BLLCollection<ColorScheme_mst>();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


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
            objStatus = objStatus.Get_By_id(statusid);
            if (objStatus.Statusid != 0)
            {


                e.Row.Cells[5].Text = objStatus.Statusname.ToString();


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
    #endregion
    #region Handle Button Show Click Event
    protected void btnShow_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
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




    }





    #region Handle Button btnCancell Click Event
    protected void btnCancell_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            #region Fetch Each Row from GridView,and Check Which Check Box is Selected
            foreach (GridViewRow gv in grdvwProblem.Rows)
            {
                string gvIDs;
                #region Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                #endregion
                #region If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {
                    #region Declare local Variables
                    int Problemid;
                    int varSiteid;
                    int oldtechnicianvalue;
                    #endregion
                    #region Get the Problemid from variable of Label type declare in GridView of grdvwSite
                    gvIDs = ((Label)gv.FindControl("Problemid")).Text.ToString();
                    #endregion
                    #region Convert to incident id into integer
                    Problemid = Convert.ToInt32(gvIDs);
                    #endregion
                    #region If Incident id in Not Null
                    if (gvIDs != "")
                    {
                        Problem_mst Obj = new Problem_mst();
                        Obj = ObjProblem.Get_By_id(Problemid);
                        if (Obj.ProblemId != 0)
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
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    #endregion
    protected void BindSelectedFilter()
    {
        string keyword = Session["keyword"].ToString();
        string Filterid = Session["Filterid"].ToString();

        col = ObjProblem.Get_All_Problemidid_By_SearchParameter(Filterid, keyword);



        grdvwProblem.DataSource = col;
        grdvwProblem.DataBind();




        Session.Remove("Filterid");
        Session.Remove("keyword");

    }

}
