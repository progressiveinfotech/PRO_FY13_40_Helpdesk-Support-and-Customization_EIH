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

public partial class Problem_EditProblem : System.Web.UI.Page
{
    Problem_mst ObjProblem = new Problem_mst();
    Priority_mst ObjPriority = new Priority_mst();
    Status_mst ObjStatus = new Status_mst();
    Category_mst ObjCategory = new Category_mst();
    Subcategory_mst Objsubcategory = new Subcategory_mst();
    UserLogin_mst ObjUser = new UserLogin_mst();
    Impact_mst objImpact = new Impact_mst();
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    Mode_mst objMode = new Mode_mst();

    SLA_mst objSLA = new SLA_mst();
    Site_mst objSite = new Site_mst();
    Department_mst objDept = new Department_mst();
    Vendor_mst objVendor = new Vendor_mst();
    RequestType_mst objRequestType = new RequestType_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<Incident_mst> colincident = new BLLCollection<Incident_mst>();
    Incident_mst objIncident = new Incident_mst();
    IncidentStates objIncidentStates = new IncidentStates();
    Incident_To_Problem objIncidentToProblem = new Incident_To_Problem();
    ProblemHistory ObjProblemHistory = new ProblemHistory();
    ProblemHistoryDiff ObjProblemHistoryDiff = new ProblemHistoryDiff();
    Organization_mst Objorganization = new Organization_mst();
    ProblemNotes ObjProblemNotes = new ProblemNotes();
    Problem_mst ObjProblemnew = new Problem_mst();
    ProblemAnalysis ObjProblemAnalysis = new ProblemAnalysis();
    ProblemSymptom ObjProblemSymptom = new ProblemSymptom();
    ProblemRootcause ObjProblemRootcause = new ProblemRootcause();
    ProblemImpact ObjProblemImpact = new ProblemImpact();
    ProblemToSolution ObjProblemToSolution = new ProblemToSolution();
    Solution_mst ObjSolution = new Solution_mst();
    BLLCollection<Incident_To_Problem> colIncidentToProblem = new BLLCollection<Incident_To_Problem>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    BLLCollection<Problem_mst> colproblem = new BLLCollection<Problem_mst>();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<Status_mst> colStatus = new BLLCollection<Status_mst>();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    BLLCollection<ProblemHistory> colProblemHistory = new BLLCollection<ProblemHistory>();
    BLLCollection<ProblemHistoryDiff> colProblemHistoryDiff = new BLLCollection<ProblemHistoryDiff>();
    BLLCollection<ProblemNotes> colProblemNotes = new BLLCollection<ProblemNotes>();
    BLLCollection<ProblemToSolution> colproblemtosolution = new BLLCollection<ProblemToSolution>();
    SentMailToUser objSentMailToUser = new SentMailToUser();
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                ShowSolutionPlaceholder();
                Showproblempanal();
                LogNoteUpdatePanel();
                HistoryUpdatePanel();

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
    protected void Showproblempanal()
    {
        panelProblem.Visible = true;
        pan1.Visible = true;
        panelincidentproblem.Visible = false;
        //panelHistory.Visible = false;
        panaleditproblem.Visible = false;
        panalanalysis.Visible = false;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
        lnkEdit.Visible = true;
        panalsolution.Visible = false;
        panelHistory.Visible = false;

        int problemid = Convert.ToInt32(Request.QueryString[0]);
        lblProblemId.Text = problemid.ToString();
        ObjProblem = ObjProblem.Get_By_id(problemid);

        if (ObjProblem.title != null)
        {

            lblTitle.Text = ObjProblem.title.ToString();
        }

        if (ObjProblem.Description != null)
        {

            lblDescription.Text = ObjProblem.Description.ToString();
        }

        int priorityid = Convert.ToInt32(ObjProblem.Priorityid);
        ObjPriority = ObjPriority.Get_By_id(priorityid);
        if (priorityid != 0)
        {
            lblpriority.Text = ObjPriority.Name.ToString();

        }
        else
        {
            lblpriority.Text = "";

        }
        int status = Convert.ToInt32(ObjProblem.Statusid);
        ObjStatus = ObjStatus.Get_By_id(status);

        lblStatus.Text = ObjStatus.Statusname.ToString();

        int category = Convert.ToInt32(ObjProblem.Categoryid);
        ObjCategory = ObjCategory.Get_By_id(category);
        if (category != 0)
        {
            lblcategory.Text = ObjCategory.CategoryName.ToString();

        }
        else
        {
            lblcategory.Text = "";

        }


        int subcategory = Convert.ToInt32(ObjProblem.Subcategoryid);
        Objsubcategory = Objsubcategory.Get_By_id(subcategory);
        if (subcategory != 0)
        {
            lblsubcategory.Text = Objsubcategory.Subcategoryname.ToString();

        }
        else
        {
            lblsubcategory.Text = "";

        }


        int requesterid = Convert.ToInt32(ObjProblem.Requesterid);
        ObjUser = ObjUser.Get_By_id(requesterid);
        lblRequesterDisp.Text = ObjUser.Username;
        int techid = Convert.ToInt32(ObjProblem.Technicianid);
        ObjUser = ObjUser.Get_By_id(techid);

        if (techid != 0)
        {
            lbltechid.Text = ObjUser.Username.ToString();

        }
        else
        {
            lbltechid.Text = "";

        }

        int creator = Convert.ToInt32(ObjProblem.CreatedByid);
        ObjUser = ObjUser.Get_By_id(creator);
        lblCreatedby.Text = ObjUser.Username.ToString();
        lblCreatedDate.Text = ObjProblem.CreateDatetime.ToString();
        lblDateDisp.Text = ObjProblem.CreateDatetime.ToString();
        lblProblemId.Text = ObjProblem.ProblemId.ToString();
        if (ObjProblem.Closedatetime != null)
        {
            lblCompletedDate.Text = ObjProblem.Closedatetime.ToString();
        }
        else
        {
            lblCompletedDate.Text = "";
        }







    }
    protected void imgproblem_Click(object sender, ImageClickEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            panelincidentproblem.Visible = false;
            panelProblem.Visible = false;
            //panelHistory.Visible = false;
            panelProblem.Visible = true;
            pan1.Visible = true;
            panaleditproblem.Visible = false;
            panalanalysis.Visible = false;
            panalsolution.Visible = false;
            panelHistory.Visible = false;
            LogNoteUpdatePanel();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imganalysis_Click(object sender, ImageClickEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            panelProblem.Visible = false;
            panalanalysis.Visible = true;
            pan1.Visible = false;
            panelRequest.Visible = false;
            panalrequestinfo.Visible = false;
            panalsolution.Visible = false;
            panelHistory.Visible = false;

            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemSymptom = ObjProblemSymptom.Get_By_id(problemid);
            ObjProblemImpact = ObjProblemImpact.Get_By_id(problemid);
            ObjProblemRootcause = ObjProblemRootcause.Get_By_id(problemid);
            string description;
            if (ObjProblemSymptom.Symtomid == 0)
            {
                lnksymptomadd.Visible = true;
                lnksymptomedit.Visible = false;

            }
            else
            {
                lnksymptomadd.Visible = false;
                lnksymptomedit.Visible = true;
            }

            if (ObjProblemImpact.Impactid == 0)
            {
                lnkimpadd.Visible = true;
                lnimpedit.Visible = false;

            }
            else
            {
                lnimpedit.Visible = true;
                lnkimpadd.Visible = false;
            }
            if (ObjProblemRootcause.Rootcauseid == 0)
            {
                lnkRootcauseadd.Visible = true;
                lnkRootcauseedit.Visible = false;

            }
            else
            {
                lnkRootcauseadd.Visible = false;
                lnkRootcauseedit.Visible = true;
            }


            ShowSymptomPlaceholder();
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imgSolution_Click(object sender, ImageClickEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelProblem.Visible = false;
            panalanalysis.Visible = false;
            panalsolution.Visible = true;
            panalrequestinfo.Visible = false;
            panaleditproblem.Visible = false;
            pan1.Visible = false;
            panelHistory.Visible = false;

            int problemid = Convert.ToInt32(Request.QueryString[0]);
            colproblemtosolution = ObjProblemToSolution.Get_All_Problemid(problemid);

            if (colproblemtosolution.Count == 0)
            {

                lnkSolutionadd.Visible = true;
                lnkSolutionedit.Visible = false;
                lnkwrkaround.Visible = true;
                lnkwrkedit.Visible = false;
            }
            else
            {
                foreach (ProblemToSolution obj in colproblemtosolution)
                {
                    if (obj.Solutiontype == "WorkAround")
                    {
                        lnkwrkaround.Visible = false;
                        lnkwrkedit.Visible = true;
                    }
                    if (obj.Solutiontype == "Solution")
                    {
                        lnkSolutionadd.Visible = false;
                        lnkSolutionedit.Visible = true;
                    }
                }

            }



            ShowSolutionPlaceholder();
            ShowWorkaroundPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imgincident_Click(object sender, ImageClickEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ShowIncidentToProblemPanel();
            panelincidentproblem.Visible = true;


            panelProblem.Visible = false;
            // panelHistory.Visible = false;
            pan1.Visible = false;
            panelRequest.Visible = false;
            panalrequestinfo.Visible = false;
            LogNoteUpdatePanel();
            HistoryUpdatePanel();
            panalanalysis.Visible = false;
            panalsolution.Visible = false;
            panelHistory.Visible = false;

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imghistory_Click(object sender, ImageClickEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelProblem.Visible = false;
            //panelHistory.Visible = true;
            panelincidentproblem.Visible = false;
            panelProblem.Visible = false;
            pan1.Visible = false;
            panelRequest.Visible = false;
            panalanalysis.Visible = false;
            panalsolution.Visible = false;
            panelHistory.Visible = true;
            panDynamic.Visible = true;
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
        ObjStatus = ObjStatus.Get_By_id(statusid);
        if (ObjStatus.Statusid != 0)
        {
            statusname = ObjStatus.Statusname;

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
        ObjPriority = ObjPriority.Get_By_id(priorityid);
        if (ObjPriority.Priorityid != 0)
        {
            priorityname = ObjPriority.Name;
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
        ObjCategory = ObjCategory.Get_By_id(categoryid);
        if (ObjCategory.Categoryid != 0)
        {
            categoryname = ObjCategory.CategoryName;
        }
        return categoryname;

    }
    string GetSubCategoryName(int subcategoryid)
    {
        string subcategoryname = "";
        Objsubcategory = Objsubcategory.Get_By_id(subcategoryid);
        if (Objsubcategory.Subcategoryid != 0)
        {
            subcategoryname = Objsubcategory.Subcategoryname;

        }
        return subcategoryname;

    }
    string GetUsername(int userid)
    {
        string username = "";
        ObjUser = ObjUser.Get_By_id(userid);
        if (ObjUser.Userid != 0)
        {
            username = ObjUser.Username;
        }
        return username;
    }
    #endregion
    #region DropDown Binding()



    protected void BindDropPriority()
    {
        colPriority = ObjPriority.Get_All();
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

    protected void BindDropStatus()
    {
        colStatus = ObjStatus.Get_All();
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




    protected void BindDropCategory()
    {
        colCategory = ObjCategory.Get_All();
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

        colSubCategory = Objsubcategory.Get_All_By_Categoryid(categoryid);
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
    protected void ShowIncidentToProblemPanel()
    {
        Bindgrid();
        grdvwincidentproblem.Visible = true;


    }
    protected void Showpanalshowincidentinformation()
    {

        //panalshowincidentinformation.Visible = true;
        //pan1.visible = false;
        //panelProblem.Visible = false;
        //panelHistory.Visible = false;
        //panelincidentproblem.Visible = true;


    }
    protected void Bindgrid()
    {
        #region Declaration of  table Variable

        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();

        #endregion
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        colIncidentToProblem = objIncidentToProblem.Get_All_By_Problemid(problemid);
        if (colIncidentToProblem.Count == 0)
        {
            DataRow row;
            row = dtTable.NewRow();
            row["ID"] = "";
            row["title"] = "";
            row["requesterid"] = "";
            row["technicianid"] = "";

            row["statusid"] = "";
            row["createdatetime"] = "";

            dtTable.Rows.Add(row);
        }
        foreach (Incident_To_Problem obj in colIncidentToProblem)
        {
            int id = Convert.ToInt32(obj.Incidentid);
            objIncident = objIncident.Get_By_id(id);
            DataRow row;
            row = dtTable.NewRow();
            //  row["incidentid"] = Convert.ToString(objIncident.Incidentid);
            row["ID"] = objIncident.Incidentid;
            row["title"] = objIncident.Title;
            row["requesterid"] = Convert.ToString(objIncident.Requesterid);
            row["technicianid"] = objIncidentStates.Technicianid;
            objIncidentStates = objIncidentStates.Get_By_id(objIncident.Incidentid);
            row["statusid"] = objIncidentStates.Statusid;
            row["createdatetime"] = Convert.ToString(objIncident.Createdatetime);
            //row["createdbyid"] = Convert.ToString(objIncident.Createdbyid);
            //row["siteid"] = Convert.ToString(objIncident.Siteid);



            //row["priorityid"] = objIncidentStates.Priorityid;
            dtTable.Rows.Add(row);


        }
        grdvwincidentproblem.DataSource = dtTable;
        grdvwincidentproblem.DataBind();

        //#region Fetch Each object of type Incident_mst from Collection Incident_mst
        //foreach (Incident_mst objIncident in col)
        //{

        //    #region Create Table row and assign value to it
        //    DataRow row;
        //    row = dtTable.NewRow();
        //  //  row["incidentid"] = Convert.ToString(objIncident.Incidentid);
        //    row["title"] = objIncident.Title;
        //    row["requesterid"] = Convert.ToString(objIncident.Requesterid);
        //    row["technicianid"] = objIncidentStates.Technicianid;
        //    objIncidentStates = objIncidentStates.Get_By_id(objIncident.Incidentid);
        //    row["statusid"] = objIncidentStates.Statusid;
        //    row["createdatetime"] = Convert.ToString(objIncident.Createdatetime);
        //    //row["createdbyid"] = Convert.ToString(objIncident.Createdbyid);
        //    //row["siteid"] = Convert.ToString(objIncident.Siteid);



        //    //row["priorityid"] = objIncidentStates.Priorityid;
        //    dtTable.Rows.Add(row);
        //    #endregion


        //}
        //#endregion
    }
    protected void grdvwincidentproblem_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (colIncidentToProblem.Count != 0)
            {
                int requesterid = Convert.ToInt32(e.Row.Cells[2].Text);
                ObjUser = ObjUser.Get_By_id(requesterid);

                if (ObjUser.Userid != 0)
                {
                    e.Row.Cells[2].Text = ObjUser.Username.ToString();
                }
                else { e.Row.Cells[2].Text = ""; }
                #region Bind Datarow at Run Time with technicianid to technician name
                int technicianid = Convert.ToInt32(e.Row.Cells[3].Text);
                ObjUser = ObjUser.Get_By_id(technicianid);
                if (ObjUser.Userid != 0)
                {
                    e.Row.Cells[3].Text = ObjUser.Username.ToString();
                }
                else { e.Row.Cells[3].Text = ""; }
                #endregion
                #region Bind Datarow at run time with Statusid to Status
                int statusid = Convert.ToInt32(e.Row.Cells[4].Text);
                ObjStatus = ObjStatus.Get_By_id(statusid);
                if (ObjStatus.Statusid != 0)
                { e.Row.Cells[4].Text = ObjStatus.Statusname.ToString(); }
                else { e.Row.Cells[4].Text = ""; }
                #endregion
            }
            else
            {
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[3].Text = "No Record Found";
            }


        }
    }
    #region Create Datatable at Runtime
    protected DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ID";
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



        return myDataTable;
    }
    #endregion
    protected void grdvwincidentproblem_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int incidentid = Convert.ToInt32(grdvwincidentproblem.Rows[e.NewEditIndex].Cells[0].Text);
            ViewState["ID"] = incidentid;
            UpdatePanel1();
            //Response.Redirect("~/Incident/IncidentRequestUpdate.aspx?" + incidentid + " ");
            // Showpanalshowincidentinformation();
            // Showproblempanal();
            //  Showproblempanal();
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
        panelRequest.Visible = true;
        panalrequestinfo.Visible = true;
        pan1.Visible = false;
        //panelHistory.Visible = false;
        panelProblem.Visible = false;

        lnkEdit.Visible = true;
        btnCancel.Visible = false;
        btnUpdate.Visible = false;
        int incidentid = Convert.ToInt32(ViewState["ID"]);
        if (incidentid != 0)
        {
            Session["incidentid"] = incidentid;
            //lblIncidentId.Text = incidentid.ToString();
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
                    lblrequeststatus.Text = GetStatusString(objIncidentStates.Statusid);

                    lblMode.Text = GetModeString(objIncident.Modeid);
                    lblincidentPriority.Text = GetPriorityString(objIncidentStates.Priorityid);
                    lblSLA.Text = GetSLAName(objIncident.Slaid);
                    lblSite.Text = GetSiteName(objIncident.Siteid);
                    lblDept.Text = GetDepartmentName(objIncident.Deptid);
                    lblincidentCategory.Text = GetCategoryName(objIncidentStates.Categoryid);
                    lblincidentSubCategory.Text = GetSubCategoryName(objIncidentStates.Subcategoryid);
                    lblTechnician.Text = GetUsername(objIncidentStates.Technicianid);
                    lblrequestby.Text = GetUsername(objIncident.Createdbyid);
                    lblproblemtorequest.Text = GetUsername(objIncident.Requesterid);
                    lblrequestdatedisp.Text = objIncident.Createdatetime.ToString().Trim();
                    lblrequestdate.Text = objIncident.Createdatetime.ToString().Trim();
                    if (objIncident.ExternalTicketNo != null)
                    {
                        lblExternalTicket.Text = objIncident.ExternalTicketNo.ToString().Trim();
                    }
                    lblVendor.Text = GetVendorName(Convert.ToInt32(objIncident.VendorId.ToString()));

                    if (objIncident.Completedtime != null)
                    {
                        lblrequestcompleteddate.Text = objIncident.Completedtime.ToString().Trim();
                        lblrequesttimespentonDisp.Visible = true;
                        int varTimeSpentonCall = 0;
                        varTimeSpentonCall = Convert.ToInt32(objIncident.Timespentonreq.ToString());
                        if (varTimeSpentonCall < 60)
                        {
                            lblspenttimeonreq.Text = varTimeSpentonCall.ToString() + " min";
                        }
                        else
                        {
                            int hr;
                            int min;
                            hr = varTimeSpentonCall / 60;
                            min = varTimeSpentonCall % 60;
                            lblspenttimeonreq.Text = hr + " hr" + ":" + min + " min";

                        }

                    }
                    else
                    {

                        lblCompletedDate.Text = "-";
                    }
                    lblrequesttitle.Text = objIncident.Title;
                    lblrequestdescription.Text = objIncident.Description;

                }

            }

        }


    }
    #endregion
    #region UpdatePanel2
    protected void UpdatePanel2()
    {
        pan1.Visible = false;
        panaleditproblem.Visible = true;
        panelProblem.Visible = true;

        //panalrequestinfo.Visible = false;
        //panelHistory.Visible = false;
        //panelincidentproblem.Visible = false;

        //lbltimespentonDisp.Visible = false;
        //lbltimespentonreq.Text = "";

        BindDropCategory();
        //BindDropImpact();
        BindDropStatus();
        // BindDropMode();
        BindDropPriority();
        BindDropTechnician();
        //  BindDropRequestType();
        //BindDropVendor();

        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ObjProblem = ObjProblem.Get_By_id(problemid);
        if (problemid != 0)
        {

            drpTechnician.SelectedValue = ObjProblem.Technicianid.ToString();
            drpStatus.SelectedValue = ObjProblem.Statusid.ToString();
            drpPriority.SelectedValue = ObjProblem.Priorityid.ToString();
            drpCategory.SelectedValue = ObjProblem.Categoryid.ToString();
            BindDropSubCategory();
            drpSubcategory.SelectedValue = ObjProblem.Subcategoryid.ToString();



            drpTechnician.SelectedValue = ObjProblem.Technicianid.ToString();
            if (ObjProblem.CompletedTime != null)
            {
                lblCompletedDateeditproblem.Text = ObjProblem.CompletedTime.ToString();
            }
            else
            {

                lblCompletedDateeditproblem.Text = "";
            }


            int createdby = Convert.ToInt32(ObjProblem.CreatedByid);
            ObjUser = ObjUser.Get_By_id(createdby);

            if (createdby != 0)
            {
                lblcreatedbyditproblem.Text = ObjUser.Username.ToString();

            }
            else
            {
                lblcreatedbyditproblem.Text = "";

            }
            lblCreateddateeditproblem.Text = ObjProblem.CreateDatetime.ToString();

        }



    }
    #endregion
    protected void lnkEdit_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan1.Visible = false;
            panaleditproblem.Visible = true;
            UpdatePanel2();
            lnkEdit.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;

            LogNoteUpdatePanel();
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
    protected void lnkcancel_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelProblem.Visible = true;
            pan1.Visible = true;
            panaleditproblem.Visible = false;
            Showproblempanal();
            lnkEdit.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkclose_Click(object sender, EventArgs e)
    {
        panelRequest.Visible = false;
        panalrequestinfo.Visible = false;
    }
    protected void grdvwincidentproblem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        grdvwincidentproblem.PageIndex = e.NewPageIndex;
        Bindgrid();

    }
    protected void problemrca_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            Response.Redirect("ProblemRCA.aspx?" + problemid);
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
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            #region Get problemid from QueryString
            int problemid = Convert.ToInt32(Request.QueryString[0]);
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
            Problem_mst objproblemstatusold = new Problem_mst();

            objproblemstatusold = objproblemstatusold.Get_By_id(problemid);

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
            #region On the basis of Username ,get Userid by calling Function Get_UserLogin_By_UserName(),via passing parameter Username and organizationid

            if (userName != "")
            {
                Objorganization = Objorganization.Get_Organization();
                ObjUser = ObjUser.Get_UserLogin_By_UserName(userName, Objorganization.Orgid);
                if (ObjUser.Userid != 0)
                {
                    userid = ObjUser.Userid;
                }
            }
            #endregion
            #region Insert value in IncidentHistory Table ,for every update of Page

            if (statusString.ToLower() == strStatusClose.ToLower())
            {

                ObjProblemHistory.Problemid = problemid;
                ObjProblemHistory.Operationownerid = userid;
                ObjProblemHistory.Operation = "closed";
                ObjProblemHistory.Insert();



            }
            else if (statusString.ToLower() == strStatusResolved.ToLower())
            {

                ObjProblemHistory.Problemid = problemid;
                ObjProblemHistory.Operationownerid = userid;
                ObjProblemHistory.Operation = "resolved";
                ObjProblemHistory.Insert();
            }
            else
            {

                ObjProblemHistory.Problemid = problemid;
                ObjProblemHistory.Operationownerid = userid;
                ObjProblemHistory.Operation = "update";
                ObjProblemHistory.Insert();


            }
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjProblemHistory.Get_Current_ProblemHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid
            ObjProblem = ObjProblem.Get_By_id(problemid);

            #endregion

            #region Insert into IncidentHistoryDiff table ,By Comparing Current value and Updated Values
            if (ObjProblem.ProblemId != 0)
            {
                #region Declare local variable
                string columnName;
                string prev_value;
                string curnt_value;
                #endregion
                #region If Priority value is changed,Insert into IncidentHistoryDiff table


                if (ObjProblem.Priorityid != Convert.ToInt32(drpPriority.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnPriorityid.ToString();
                    prev_value = Convert.ToString(ObjProblem.Priorityid);
                    curnt_value = Convert.ToString(drpPriority.SelectedValue);
                    ObjProblemHistoryDiff.Historyid = historyid;
                    ObjProblemHistoryDiff.Columnname = columnName;
                    ObjProblemHistoryDiff.Current_value = curnt_value;
                    ObjProblemHistoryDiff.Prev_value = prev_value;
                    ObjProblemHistoryDiff.Insert();
                }
                #endregion
                #region If Category value is changed,Insert into IncidentHistoryDiff table
                if (ObjProblem.Categoryid != Convert.ToInt32(drpCategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnCategoryid.ToString();
                    prev_value = Convert.ToString(ObjProblem.Categoryid);
                    curnt_value = Convert.ToString(drpCategory.SelectedValue);
                    ObjProblemHistoryDiff.Historyid = historyid;
                    ObjProblemHistoryDiff.Columnname = columnName;
                    ObjProblemHistoryDiff.Current_value = curnt_value;
                    ObjProblemHistoryDiff.Prev_value = prev_value;
                    ObjProblemHistoryDiff.Insert();
                }
                #endregion
                #region If SubCategory value is changed,Insert into IncidentHistoryDiff table
                if (ObjProblem.Subcategoryid != Convert.ToInt32(drpSubcategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnSubcategoryid.ToString();
                    prev_value = Convert.ToString(ObjProblem.Subcategoryid);
                    curnt_value = Convert.ToString(drpSubcategory.SelectedValue);
                    ObjProblemHistoryDiff.Historyid = historyid;
                    ObjProblemHistoryDiff.Columnname = columnName;
                    ObjProblemHistoryDiff.Current_value = curnt_value;
                    ObjProblemHistoryDiff.Prev_value = prev_value;
                    ObjProblemHistoryDiff.Insert();
                }
                #endregion
                #region If Status value is changed,Insert into IncidentHistoryDiff table

                if (ObjProblem.Statusid != Convert.ToInt32(drpStatus.SelectedValue))
                {
                    string Statusprev;
                    string StatusCurrent;

                    columnName = Resources.MessageResource.strColumnstatusid.ToString();
                    prev_value = Convert.ToString(ObjProblem.Statusid);
                    curnt_value = Convert.ToString(drpStatus.SelectedValue);
                    ObjProblemHistoryDiff.Historyid = historyid;
                    ObjProblemHistoryDiff.Columnname = columnName;
                    ObjProblemHistoryDiff.Current_value = curnt_value;
                    ObjProblemHistoryDiff.Prev_value = prev_value;
                    ObjProblemHistoryDiff.Insert();
                    Statusprev = GetStatusString(Convert.ToInt32(objproblemstatusold.Statusid));
                    StatusCurrent = GetStatusString(Convert.ToInt32(drpStatus.SelectedValue));
                    if (Statusprev == strStatusOpen && StatusCurrent == strStatusOnHold)
                    {
                        columnName = Resources.MessageResource.strColumnStarttime.ToString();
                        prev_value = "0";
                        curnt_value = DateTime.Now.ToString();
                        ObjProblemHistoryDiff.Historyid = historyid;
                        ObjProblemHistoryDiff.Columnname = columnName;
                        ObjProblemHistoryDiff.Current_value = curnt_value;
                        ObjProblemHistoryDiff.Prev_value = prev_value;
                        ObjProblemHistoryDiff.Insert();

                    }

                    if (Statusprev == strStatusOnHold && StatusCurrent != strStatusOnHold)
                    {
                        columnName = Resources.MessageResource.srColumnEndtime.ToString();
                        prev_value = "0";
                        curnt_value = DateTime.Now.ToString();
                        ObjProblemHistoryDiff.Historyid = historyid;
                        ObjProblemHistoryDiff.Columnname = columnName;
                        ObjProblemHistoryDiff.Current_value = curnt_value;
                        ObjProblemHistoryDiff.Prev_value = prev_value;
                        ObjProblemHistoryDiff.Insert();

                    }



                }
                #endregion
                #region If technician value is changed,Insert into IncidentHistoryDiff table
                if (ObjProblem.Technicianid != Convert.ToInt32(drpTechnician.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnTechnicianid.ToString();
                    prev_value = Convert.ToString(ObjProblem.Technicianid);
                    curnt_value = Convert.ToString(drpTechnician.SelectedValue);
                    ObjProblemHistoryDiff.Historyid = historyid;
                    ObjProblemHistoryDiff.Columnname = columnName;
                    ObjProblemHistoryDiff.Current_value = curnt_value;
                    ObjProblemHistoryDiff.Prev_value = prev_value;
                    ObjProblemHistoryDiff.Insert();
                    objSentMailToUser.SentMailToTechnicianForProblemCall(problemid, Convert.ToInt32(drpTechnician.SelectedValue));
                    if (objproblemstatusold.AssginedTime == null)
                    {
                        columnName = Resources.MessageResource.strColumnAssignedTime.ToString();
                        prev_value = "0";
                        curnt_value = DateTime.Now.ToString();
                        ObjProblemHistoryDiff.Historyid = historyid;
                        ObjProblemHistoryDiff.Columnname = columnName;
                        ObjProblemHistoryDiff.Current_value = curnt_value;
                        ObjProblemHistoryDiff.Prev_value = prev_value;
                        ObjProblemHistoryDiff.Insert();

                    }
                    else
                    {
                        columnName = "AssignedTime";
                        prev_value = objproblemstatusold.AssginedTime;
                        curnt_value = DateTime.Now.ToString();
                        ObjProblemHistoryDiff.Historyid = historyid;
                        ObjProblemHistoryDiff.Columnname = columnName;
                        ObjProblemHistoryDiff.Current_value = curnt_value;
                        ObjProblemHistoryDiff.Prev_value = prev_value;
                        ObjProblemHistoryDiff.Insert();
                    }

                    FlagTechnicianId = true;
                }
                #endregion


            }




            #endregion



            #region Update values in Problem Table

            ObjProblemnew.ProblemId = problemid;
            ObjProblemnew.Technicianid = Convert.ToInt32(drpTechnician.SelectedValue);
            ObjProblemnew.Statusid = Convert.ToInt32(drpStatus.SelectedValue);
            ObjProblemnew.Priorityid = Convert.ToInt32(drpPriority.SelectedValue);
            ObjProblemnew.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
            ObjProblemnew.Subcategoryid = Convert.ToInt32(drpSubcategory.SelectedValue);
            ObjProblemnew.Active = true;
            if (ObjProblem.Technicianid != Convert.ToInt32(drpTechnician.SelectedValue))
            {
                ObjProblemnew.AssginedTime = DateTime.Now.ToString();
            }
            else
            {
                ObjProblemnew.AssginedTime = ObjProblem.AssginedTime;
            }
            #region If Current status is closed,then Assign Completed time
            if (statusString.ToLower() == strStatusClose.ToLower())
            {
                #region If FlagCloseStatus=flase ie Currrent status is closed ,and old status is not Closed
                int status = ObjProblem.Statusid;
                ObjStatus = ObjStatus.Get_By_id(status);
                if (ObjStatus.Statusname == "closed")
                {
                    ObjProblemnew.Closedatetime = ObjProblem.Closedatetime;


                    // varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(incidentid, Convert.ToInt32(drpSite.SelectedValue), strCreateDatetime, DateTime.Now.ToString());
                    //CalculateTotalTimeofRequest();
                    //varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(strCreateDatetime, DateTime.Now.ToString());
                }
                else
                {
                    ObjProblemnew.Closedatetime = DateTime.Now.ToString();
                    //varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(strCreateDatetime, oldCompletedTime);
                    // varTotalTimeSpentonCall = objIncident.Get_TimeSpentonRequest(incidentid, Convert.ToInt32(drpSite.SelectedValue), strCreateDatetime, oldCompletedTime);

                }
                #endregion

            }
            #endregion

            ObjProblemnew.Update();
            #endregion

            Showproblempanal();
            LogNoteUpdatePanel();
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
    protected void HistoryUpdatePanel()
    {
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderHistory.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderHistory.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Get problemid from QueryString
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Get Collection of ProblemHistory on the basis of incidentid

        colProblemHistory = ObjProblemHistory.Get_All_By_Problemid(problemid);
        #endregion
        #region Fetch each object of IncidentHistory from Collection of colIncidentHistory
        foreach (ProblemHistory obj in colProblemHistory)
        {
            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            ObjUser = ObjUser.Get_By_id(obj.Operationownerid);
            username = ObjUser.Username.ToString();
            #endregion
            #region Declaration of Tablerow,TableCell and lable object
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            tabRow.BackColor = System.Drawing.Color.PaleGreen;

            tbCell.Width = hdwidth;
            Label lbl = new Label();
            #endregion
            #region Print Each Operation Performed by User
            lbl.Font.Bold = true;
            lbl.Text = "&nbsp;&nbsp;" + obj.Operation.ToString() + "&nbsp;&nbsp;&nbsp;by&nbsp;&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Operationtime.ToString();
            #endregion
            #region Fix background color of row according the operation,Create operation shown by PaleGreen color,Update by Silver and Closed by Wheat
            if (obj.Operation.ToLower() == "create")
            {
                tabRow.BackColor = System.Drawing.Color.PaleGreen;
            }
            else if (obj.Operation.ToLower() == "closed")
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
                tabRow1.BackColor = System.Drawing.Color.White;
            }
            #endregion
            #region If Operation type is create,then Print username who Performed operation and add to table
            if (obj.Operation == "SymptomAdded" || obj.Operation == "RootcauseAdded" || obj.Operation == "ImpactAdded")
            {
                TableRow tabRow1 = new TableRow();
                TableCell tbCell1 = new TableCell();

                tbCell1.Width = hdwidth;
                tbCell1.Height = height;
                Label lbl1 = new Label();
                lbl1.Text = "&nbsp;&nbsp;Operation: <b>" + obj.Operation + "</b> , Performed by :&nbsp;<b>" + username + "</b>";
                lbl1.Font.Size = FontUnit.Smaller;
                tbCell1.Controls.Add(lbl1);
                tabRow1.Cells.Add(tbCell1);
                tbl.Rows.Add(tabRow1);
                tabRow1.BackColor = System.Drawing.Color.White;
            }
            #endregion
            #region If Operation type is Update Operation,then Print username who Performed operation and add to table
            if (obj.Operation == "SymptomUpdated" || obj.Operation == "RootcauseUpdated" || obj.Operation == "ImpactUpdated")
            {
                TableRow tabRow1 = new TableRow();
                TableCell tbCell1 = new TableCell();
                tbCell1.Width = hdwidth;
                tbCell1.Height = height;
                Label lbl1 = new Label();
                lbl1.Text = "&nbsp;&nbsp;Operation: <b>" + obj.Operation + "</b> , Performed by :&nbsp;<b>" + username + "</b>";
                lbl1.Font.Size = FontUnit.Smaller;
                tbCell1.Controls.Add(lbl1);
                tabRow1.Cells.Add(tbCell1);
                tbl.Rows.Add(tabRow1);
                tabRow1.BackColor = System.Drawing.Color.White;
            }
            #endregion


            #region Get Collection of IncidentHistoryDiff on the basis of historyid
            colProblemHistoryDiff = ObjProblemHistoryDiff.Get_All_By_Historyid(obj.Historyid);
            #endregion
            if (colProblemHistoryDiff.Count != 0)
            {
                #region Fetch each object of IncidentHistoryDiff from Collection of colIncidentHistoryDiff
                foreach (ProblemHistoryDiff objDiff in colProblemHistoryDiff)
                {
                    #region Declaration of local variables,tablerow,tablecell and label
                    string strPrevValue;
                    string strCurrentValue;
                    TableRow tabRowInner = new TableRow();

                    TableCell tbCellInner = new TableCell();
                    tbCellInner.Width = hdwidth;
                    tbCellInner.BackColor = System.Drawing.Color.White;
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
                    #region If only Impact,Rootcause,Symptom is changed

                    if (objDiff.Columnname == "Description")
                    {

                        strPrevValue = objDiff.Prev_value.ToString();
                        strCurrentValue = objDiff.Current_value;
                        if (strPrevValue == "")
                        { strPrevValue = "-"; }
                        if (strCurrentValue == "")
                        { strCurrentValue = "-"; }
                        lblinner.Text = "&nbsp;&nbsp;Description Changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
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
                    #region If Modification is done at Resolution of call,then Print Resolution History
                    if (objDiff.Columnname == "Resolution")
                    {
                        strPrevValue = objDiff.Prev_value;
                        strCurrentValue = objDiff.Current_value;
                        if (strPrevValue == "")
                        { strPrevValue = "-"; }
                        if (strCurrentValue == "")
                        { strCurrentValue = "-"; }
                        lblinner.Text = "&nbsp;&nbsp; <b>Added Resolution is</b> &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";

                    }
                    #endregion

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
            }

                #endregion
        }

        #endregion

    }
    protected void LogNoteUpdatePanel()
    {
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolder1.Controls.Clear();
        Table tbl = new Table();
        PlaceHolder1.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Get problemid from QueryString
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Get Collection of ProblemHistory on the basis of incidentid

        colProblemNotes = ObjProblemNotes.Get_All_By_Problemid(problemid);
        #endregion
        if (colProblemNotes.Count == 0)
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
        #region Fetch each object of IncidentHistory from Collection of colIncidentHistory
        foreach (ProblemNotes obj in colProblemNotes)
        {
            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            ObjUser = ObjUser.Get_By_id(obj.UserName);
            username = ObjUser.Username.ToString();
            string Date = obj.Date.ToString();
            #endregion
            #region Declaration of Tablerow,TableCell and lable object
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            tbCell.Width = hdwidth;
            Label lbl = new Label();
            #endregion
            #region Print Each Operation Performed by User
            //lbl.Font.Bold = true;
            //lbl.Text = "&nbsp;&nbsp;" + obj.Operation.ToString() + "&nbsp;&nbsp;&nbsp;by&nbsp;&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Operationtime.ToString();
            #endregion
            #region Add label,cell,and Row to tabel
            tbCell.Controls.Add(lbl);
            tabRow.Cells.Add(tbCell);
            tbl.Rows.Add(tabRow);
            #endregion
            #region If Operation type is create,then Print username who Performed operation and add to table

            TableRow tabRow1 = new TableRow();
            TableCell tbCell1 = new TableCell();
            tbCell1.Width = hdwidth;
            tbCell1.Height = height;
            Label lbl1 = new Label();
            lbl1.Text = "<b>" + username + "</b> said On " + Date;
            lbl1.Font.Size = FontUnit.Smaller;
            tbCell1.Controls.Add(lbl1);
            tabRow1.Cells.Add(tbCell1);
            tabRow1.BackColor = System.Drawing.Color.Lavender;
            tbl.Rows.Add(tabRow1);


            TableRow tabRow2 = new TableRow();
            TableCell tbCell2 = new TableCell();
            tbCell2.Width = hdwidth;
            tbCell2.Height = height;
            Label lbl2 = new Label();
            lbl2.Text = obj.Comments.ToString();
            lbl2.Font.Size = FontUnit.Smaller;
            tbCell2.Controls.Add(lbl2);
            tabRow2.Cells.Add(tbCell2);
            tbl.Rows.Add(tabRow2);
            tbl.BorderWidth = 1;
            tbl.CellSpacing = 2;
            tbl.CellPadding = 2;

            #endregion





        }
        #endregion

    }
    protected void lnknewwindow_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //Response.Redirect("~/KEDB/ViewSolution.aspx");
            //string myScript;
            //myScript = "<script language=javascript>EndRequestHandler();</script>";
            //Page.RegisterClientScriptBlock("MyScript", myScript);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SomeUniqueID", "function HelloWorld() { alert('Hello World'); }", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Opencommentwindow()", "Opencommentwindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkimpadd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = true;
            btnsaveimpact.Visible = true;
            btncancellImpact.Visible = true;
            EditorRootcause.Visible = false;
            btnupdateRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            Editorsymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            btnupdatesymptom.Visible = false;
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnimpedit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = true;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = true;
            btnupdateImpact.Visible = true;
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemImpact = ObjProblemImpact.Get_By_id(problemid);
            Editorimpact.Text = ObjProblemImpact.Description.ToString();
            EditorRootcause.Visible = false;
            btnupdateRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            Editorsymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            btnupdatesymptom.Visible = false;
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void lnkRootcauseadd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRootcause.Visible = true;
            btnsaveRootcause.Visible = true;
            btncancellRootcause.Visible = true;
            Editorsymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            btnupdatesymptom.Visible = false;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowSymptomPlaceholder();
            ShowImpactPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void lnkRootcauseedit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRootcause.Visible = true;
            btnsaveRootcause.Visible = false;
            btncancellRootcause.Visible = true;
            btnupdateRootcause.Visible = true;
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemRootcause = ObjProblemRootcause.Get_By_id(problemid);
            EditorRootcause.Text = ObjProblemRootcause.Description.ToString();
            Editorsymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            btnupdatesymptom.Visible = false;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowSymptomPlaceholder();
            ShowImpactPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void lnksymptomadd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorsymptom.Visible = true;
            btnsaveSymtom.Visible = true;
            btncancellSymptom.Visible = true;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            EditorRootcause.Visible = false;
            btnupdateRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnksymptomedit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRootcause.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = true;
            btnupdatesymptom.Visible = true;
            Editorsymptom.Visible = true;
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemSymptom = ObjProblemSymptom.Get_By_id(problemid);
            Editorsymptom.Text = ObjProblemSymptom.Description.ToString();
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            EditorRootcause.Visible = false;
            btnupdateRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btncancellSymptom_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorsymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            btnupdatesymptom.Visible = false;

            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btncancellRootcause_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            btnupdateRootcause.Visible = false;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btncancellimpact_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
    protected void btnsaveSymtom_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemSymptom.Problemid = problemid;
            ObjProblemSymptom.Description = Editorsymptom.Text.ToString();
            ObjProblemSymptom.Insert();
            Editorsymptom.Visible = false;
            ShowSymptomPlaceholder();
            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "SymptomAdded";
            ObjProblemHistory.Insert();
            #endregion
            btnupdatesymptom.Visible = false;
            btnsaveSymtom.Visible = false;
            btncancellSymptom.Visible = false;
            Editorsymptom.Visible = false;
            lnksymptomedit.Visible = true;
            lnksymptomadd.Visible = false;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }

    protected void btnupdatesymptom_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int problemid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "SymptomUpdate";
            ObjProblemHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjProblemHistory.Get_Current_ProblemHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid
            ObjProblem = ObjProblem.Get_By_id(problemid);

            #endregion
            #region Find the value of current symptom
            ObjProblemSymptom = ObjProblemSymptom.Get_By_id(ObjProblem.ProblemId);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjProblemSymptom.Description);
            curnt_value = Convert.ToString(Editorsymptom.Text);
            ObjProblemHistoryDiff.Historyid = historyid;
            ObjProblemHistoryDiff.Columnname = "Description";
            ObjProblemHistoryDiff.Current_value = curnt_value;
            ObjProblemHistoryDiff.Prev_value = prev_value;
            ObjProblemHistoryDiff.Insert();
            #endregion
            ObjProblemSymptom.Problemid = problemid;
            ObjProblemSymptom.Description = Editorsymptom.Text.ToString();
            ObjProblemSymptom.Update();
            ShowSymptomPlaceholder();
            btnupdatesymptom.Visible = false;
            btncancellSymptom.Visible = false;
            btncancellSymptom.Visible = false;
            Editorsymptom.Visible = false;
            lnksymptomadd.Visible = false;
            lnksymptomedit.Visible = true;
            ShowImpactPlaceholder();
            ShowRootcausePlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btnsaveRootcause_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            int problemid = Convert.ToInt32(Request.QueryString[0]);

            ObjProblemRootcause.Problemid = problemid;
            ObjProblemRootcause.Description = EditorRootcause.Text.ToString();
            ObjProblemRootcause.Insert();
            EditorRootcause.Visible = false;
            ShowRootcausePlaceholder();
            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "RootcauseAdded";
            ObjProblemHistory.Insert();
            #endregion
            btnupdateRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            EditorRootcause.Visible = false;
            lnkRootcauseedit.Visible = true;
            lnkRootcauseadd.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
    protected void btnupdateRootcause_Click(object sender, EventArgs e)
    {        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int problemid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "RootcauseUpdated";
            ObjProblemHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjProblemHistory.Get_Current_ProblemHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid
            ObjProblem = ObjProblem.Get_By_id(problemid);

            #endregion
            #region Find the value of current symptom
            ObjProblemRootcause = ObjProblemRootcause.Get_By_id(ObjProblem.ProblemId);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjProblemRootcause.Description);
            curnt_value = Convert.ToString(EditorRootcause.Text);
            ObjProblemHistoryDiff.Historyid = historyid;
            ObjProblemHistoryDiff.Columnname = "Description";
            ObjProblemHistoryDiff.Current_value = curnt_value;
            ObjProblemHistoryDiff.Prev_value = prev_value;
            ObjProblemHistoryDiff.Insert();
            #endregion
            ObjProblemRootcause.Problemid = problemid;
            ObjProblemRootcause.Description = EditorRootcause.Text.ToString();
            ObjProblemRootcause.Update();
            ShowRootcausePlaceholder();
            btnupdateRootcause.Visible = false;
            btnsaveRootcause.Visible = false;
            btncancellRootcause.Visible = false;
            EditorRootcause.Visible = false;
            lnkRootcauseedit.Visible = true;
            lnkRootcauseadd.Visible = false;
            ShowImpactPlaceholder();
            ShowSymptomPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
    protected void btnsaveImpact_Click(object sender, EventArgs e)
    {        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int problemid = Convert.ToInt32(Request.QueryString[0]);

            ObjProblemImpact.Problemid = problemid;
            ObjProblemImpact.Description = Editorimpact.Text.ToString();
            ObjProblemImpact.Insert();
            Editorimpact.Visible = false;
            ShowImpactPlaceholder();
            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "ImpactAdded";
            ObjProblemHistory.Insert();
            #endregion
            btnupdateImpact.Visible = false;
            btnsaveimpact.Visible = false;

            btncancellImpact.Visible = false;
            Editorimpact.Visible = false;
            lnimpedit.Visible = true;
            lnkimpadd.Visible = false;
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnupdateImpact_Click(object sender, EventArgs e)
    {  //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int problemid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjProblemHistory.Problemid = problemid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjProblemHistory.Operationownerid = userid;
            ObjProblemHistory.Operation = "ImpactUpdated";
            ObjProblemHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjProblemHistory.Get_Current_ProblemHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid
            ObjProblem = ObjProblem.Get_By_id(problemid);

            #endregion
            #region Find the value of current symptom
            ObjProblemImpact = ObjProblemImpact.Get_By_id(ObjProblem.ProblemId);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjProblemImpact.Description);
            curnt_value = Convert.ToString(Editorimpact.Text);
            ObjProblemHistoryDiff.Historyid = historyid;
            ObjProblemHistoryDiff.Columnname = "Description";
            ObjProblemHistoryDiff.Current_value = curnt_value;
            ObjProblemHistoryDiff.Prev_value = prev_value;
            ObjProblemHistoryDiff.Insert();
            #endregion
            ObjProblemImpact.Problemid = problemid;
            ObjProblemImpact.Description = Editorimpact.Text.ToString();
            ObjProblemImpact.Update();
            ShowImpactPlaceholder();
            btnupdateImpact.Visible = false;
            btncancellImpact.Visible = false;
            btncancellImpact.Visible = false;
            Editorimpact.Visible = false;
            lnimpedit.Visible = true;
            lnkimpadd.Visible = false;
            ShowRootcausePlaceholder();
            ShowSymptomPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void ShowSymptomPlaceholder()
    {
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ObjProblemSymptom = ObjProblemSymptom.Get_By_id(problemid);
        string description;
        if (ObjProblemSymptom.Description == null)
        {
            description = "";
        }
        else
        {
            description = ObjProblemSymptom.Description.ToString();
        }
        PlaceholderSymtom.Visible = true;
        #region Declaration of Dynamic Table,and Placeholder
        PlaceholderSymtom.Controls.Clear();
        Table tbl = new Table();
        PlaceholderSymtom.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Declaration of Tablerow,TableCell and lable object
        TableRow tabRow = new TableRow();
        TableCell tbCell = new TableCell();
        tbCell.Width = hdwidth;
        Label lbl = new Label();
        #endregion
        TableRow tabRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Width = hdwidth;
        tbCell1.Height = height;
        Label lbl1 = new Label();
        lbl1.Text = description;
        lbl1.Font.Size = FontUnit.Smaller;
        tbCell1.Controls.Add(lbl1);
        tabRow1.Cells.Add(tbCell1);
        tbl.Rows.Add(tabRow1);
        Editorsymptom.Visible = false;

    }
    protected void ShowRootcausePlaceholder()
    {
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ProblemRootcause obj = new ProblemRootcause();
        ObjProblemRootcause = obj.Get_By_id(problemid);
        string description;
        if (ObjProblemRootcause.Rootcauseid == 0)
        {
            description = "";
        }
        else
        {
            description = ObjProblemRootcause.Description.ToString();
        }
        PlaceholderRootcause.Visible = true;
        #region Declaration of Dynamic Table,and Placeholder
        PlaceholderRootcause.Controls.Clear();
        Table tbl = new Table();
        PlaceholderRootcause.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Declaration of Tablerow,TableCell and lable object
        TableRow tabRow = new TableRow();
        TableCell tbCell = new TableCell();
        tbCell.Width = hdwidth;
        Label lbl = new Label();
        #endregion
        TableRow tabRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Width = hdwidth;
        tbCell1.Height = height;
        Label lbl1 = new Label();
        lbl1.Text = description;
        lbl1.Font.Size = FontUnit.Smaller;
        tbCell1.Controls.Add(lbl1);
        tabRow1.Cells.Add(tbCell1);
        tbl.Rows.Add(tabRow1);
        EditorRootcause.Visible = false;

    }
    protected void ShowImpactPlaceholder()
    {
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ProblemImpact obj = new ProblemImpact();
        ObjProblemImpact = obj.Get_By_id(problemid);
        string description;
        if (ObjProblemImpact.Impactid == 0)
        {
            description = "";
        }
        else
        {
            description = ObjProblemImpact.Description.ToString();
        }
        Placeholderimpact.Visible = true;
        #region Declaration of Dynamic Table,and Placeholder
        Placeholderimpact.Controls.Clear();
        Table tbl = new Table();
        Placeholderimpact.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Declaration of Tablerow,TableCell and lable object
        TableRow tabRow = new TableRow();
        TableCell tbCell = new TableCell();
        tbCell.Width = hdwidth;
        Label lbl = new Label();
        #endregion
        TableRow tabRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Width = hdwidth;
        tbCell1.Height = height;
        Label lbl1 = new Label();
        lbl1.Text = description;
        lbl1.Font.Size = FontUnit.Smaller;
        tbCell1.Controls.Add(lbl1);
        tabRow1.Cells.Add(tbCell1);
        tbl.Rows.Add(tabRow1);
        Editorimpact.Visible = false;


    }
    protected void lnkwrkaround_Click(object sender, EventArgs e)
    {  //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewWorkAroundwindow()", "OpenNewWorkAroundwindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkSolutionadd_Click(object sender, EventArgs e)
    {  //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewSolutionwindow()", "OpenNewSolutionwindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void ShowSolutionPlaceholder()
    {
        panelHistory.Visible = false;
        panelRequest.Visible = false;
        panalanalysis.Visible = false;
        panalrequestinfo.Visible = false;
        panelincidentproblem.Visible = false;
        string description = "";
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ObjProblemToSolution = ObjProblemToSolution.Get_By_id(problemid);
        colproblemtosolution = ObjProblemToSolution.Get_All_Problemid(problemid);
        if (colproblemtosolution.Count != 0)
        {
            foreach (ProblemToSolution obj in colproblemtosolution)
            {
                if (obj.Solutiontype == "Solution")
                {
                    ObjSolution = ObjSolution.Get_By_id(obj.Solutionid);
                    if (ObjSolution.Solution == "Solution")
                    {
                        description = ObjSolution.Content.ToString();
                    }

                }
            }
        }
        else
        {
            description = "";
        }

        PlaceHolderSolution.Visible = true;

        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderSolution.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderSolution.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Declaration of Tablerow,TableCell and lable object
        TableRow tabRow = new TableRow();
        TableCell tbCell = new TableCell();
        tbCell.Width = hdwidth;
        Label lbl = new Label();
        #endregion
        TableRow tabRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Width = hdwidth;
        tbCell1.Height = height;
        Label lbl1 = new Label();
        lbl1.Text = description;
        lbl1.Font.Size = FontUnit.Smaller;
        tbCell1.Controls.Add(lbl1);
        tabRow1.Cells.Add(tbCell1);
        tbl.Rows.Add(tabRow1);

    }
    protected void ShowWorkaroundPlaceholder()
    {
        panelHistory.Visible = false;
        panelRequest.Visible = false;
        panalanalysis.Visible = false;
        panalrequestinfo.Visible = false;
        panelincidentproblem.Visible = false;

        string description = "";
        int problemid = Convert.ToInt32(Request.QueryString[0]);
        ObjProblemToSolution = ObjProblemToSolution.Get_By_id(problemid);
        if (colproblemtosolution.Count != 0)
        {
            foreach (ProblemToSolution obj in colproblemtosolution)
            {
                if (obj.Solutiontype == "WorkAround")
                {
                    ObjSolution = ObjSolution.Get_By_id(obj.Solutionid);
                    if (ObjSolution.Solution == "WorkAround")
                    {
                        description = ObjSolution.Content.ToString();
                    }

                }
            }
        }
        else
        {
            description = "";
        }

        PlaceHolderWrkaround.Visible = true;

        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderWrkaround.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderWrkaround.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Declaration of Tablerow,TableCell and lable object
        TableRow tabRow = new TableRow();
        TableCell tbCell = new TableCell();
        tbCell.Width = hdwidth;
        Label lbl = new Label();
        #endregion
        TableRow tabRow1 = new TableRow();
        TableCell tbCell1 = new TableCell();
        tbCell1.Width = hdwidth;
        tbCell1.Height = height;
        Label lbl1 = new Label();
        lbl1.Text = description;
        lbl1.Font.Size = FontUnit.Smaller;
        tbCell1.Controls.Add(lbl1);
        tabRow1.Cells.Add(tbCell1);
        tbl.Rows.Add(tabRow1);

    }

    protected void lnkSolutionedit_Click(object sender, EventArgs e)
    { //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenEditSolutionwindow()", "OpenEditSolutionwindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkwrkedit_Click(object sender, EventArgs e)
    { //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenEditWorkAroundwindow()", "OpenEditWorkAroundwindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkNewProblem_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Session["problemid"] = Convert.ToInt32(Request.QueryString[0]);
            string myScript;
            Session["RequestFromProblem"] = "True";
            myScript = "<script language=javascript>javascript:window.open('../Change/CreateChangefromProblem.aspx','popupwindow','width=950,height=640,left=200,top=250,Scrollbars=yes');</script>";
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
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Session["problemid"] = Convert.ToInt32(Request.QueryString[0]);
            string myScript;
            Session["RequestFromProblem"] = "True";
            myScript = "<script language=javascript>javascript:window.open('../Change/DisplayLinkChanges.aspx','popupwindow','width=950,height=480,left=200,top=250,Scrollbars=yes');</script>";
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

}
