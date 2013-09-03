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

public partial class Change_EditChange : System.Web.UI.Page
{
    Change_mst ObjChange = new Change_mst();
    UserLogin_mst ObjUser = new UserLogin_mst();
    ChangeStatus_mst Objchangestatus = new ChangeStatus_mst();
    Category_mst ObjCategory = new Category_mst();
    Subcategory_mst Objsubcategory = new Subcategory_mst();
    Priority_mst ObjPriority = new Priority_mst();
    ChangeType_mst ObjChangeType = new ChangeType_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    Organization_mst Objorganization = new Organization_mst();
    ChangeHistory ObjChangeHistory = new ChangeHistory();
    ChangeHistoryDiff ObjChangeHistoryDiff = new ChangeHistoryDiff();
    Incident_To_Change ObjIncidenttoChanges = new Incident_To_Change();
    Incident_mst objIncident = new Incident_mst();
    IncidentStates objIncidentStates = new IncidentStates();
    Status_mst ObjStatus = new Status_mst();
    Mode_mst objMode = new Mode_mst();

    SLA_mst objSLA = new SLA_mst();
    Site_mst objSite = new Site_mst();
    Department_mst objDept = new Department_mst();
    Vendor_mst objVendor = new Vendor_mst();
    RequestType_mst objRequestType = new RequestType_mst();
    Impact_mst objImpact = new Impact_mst();
    Problem_mst ObjProblem = new Problem_mst();
    Problem_To_Change ObjProblemToChange = new Problem_To_Change();
    ChangeImpact ObjChangeImpact = new ChangeImpact();
    ChangeRollOut ObjChangeRollOutPlan = new ChangeRollOut();
    ChangeBackoutPlan ObjChangeBackOutPlan = new ChangeBackoutPlan();
    ChangeNotes ObjChangeNotes = new ChangeNotes();
    ChangeTask_mst ObjChangeTask = new ChangeTask_mst();


    BLLCollection<IncludedAssetinchange> colassetincludeinchange = new BLLCollection<IncludedAssetinchange>();
    BLLCollection<ChangeStatus_mst> colchangestatus = new BLLCollection<ChangeStatus_mst>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    BLLCollection<ChangeType_mst> colchangetype = new BLLCollection<ChangeType_mst>();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    BLLCollection<ChangeHistoryDiff> colChangeHistoryDiff = new BLLCollection<ChangeHistoryDiff>();
    BLLCollection<ChangeHistory> colChangeHistory = new BLLCollection<ChangeHistory>();
    BLLCollection<Incident_To_Change> colincidenttochange = new BLLCollection<Incident_To_Change>();
    BLLCollection<Problem_To_Change> colproblemtochange = new BLLCollection<Problem_To_Change>();
    BLLCollection<ChangeNotes> colchangenotes = new BLLCollection<ChangeNotes>();
    BLLCollection<ChangeTask_mst> colchangetask = new BLLCollection<ChangeTask_mst>();
    BLLCollection<ChangeApprove_trans> colapprovechange = new BLLCollection<ChangeApprove_trans>();
    IncludedAssetinchange objincludeasset = new IncludedAssetinchange();
    Asset_mst ObjAsset = new Asset_mst();
    Incident_To_Change Objincidenttochange = new Incident_To_Change();
    ChangeApprove_trans Objchnageapprovetrans = new ChangeApprove_trans();
    Service_mst objservice= new Service_mst();
    BLLCollection<Service_mst> colservice=new BLLCollection<Service_mst>();


    public int changeid;
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {

                Showchangeinfo();
                LogNoteUpdatePanel();
                //BindDropServiceEffected();


            }
            string varAsset = "";
            if (Session["AssetContract"] != null)
            {
                varAsset = Session["AssetContract"].ToString();
            }

            if (varAsset != "")
            {
                BindListBox();
            }
            if (IsPostBack)
            {
                string eventTarget = this.Request["__EVENTTARGET"];
                string eventArgument = this.Request["__EVENTARGUMENT"];
                if (eventTarget != string.Empty && eventTarget == "callPostBack")
                {
                    if (eventArgument != string.Empty)
                    {
                        ViewState["UserCreate"] = eventArgument.ToString();


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
    #region Bind all the dropdowns
    #region Function For all the Dropdown Binding
    protected void BindDropChangeStatus()
    {

        colchangestatus = Objchangestatus.Get_All();
        drpStatus.DataTextField = "statusname";
        drpStatus.DataValueField = "changestatusid";
        drpStatus.DataSource = colchangestatus;
        drpStatus.DataBind();

    }
    //protected void BindDropPriority()
    //{
    //    colPriority = ObjPriority.Get_All();

    //    drpPriority.DataTextField = "name";
    //    drpPriority.DataValueField = "priorityid";
    //    drpPriority.DataSource = colPriority;
    //    drpPriority.DataBind();
    //    ListItem item = new ListItem();
    //    item.Text = "------Select Priority------";
    //    item.Value = "0";
    //    drpPriority.Items.Add(item);
    //    drpPriority.SelectedValue = "0";




    //}

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
    protected void BindDropChangeType()
    {



        colchangetype = ObjChangeType.Get_All();
        drpchangetype.DataTextField = "ChangeTypename";
        drpchangetype.DataValueField = "ChangeTypeid";
        drpchangetype.DataSource = colchangetype;
        drpchangetype.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Change Type------";
        item.Value = "0";
        drpchangetype.Items.Add(item);
        drpchangetype.SelectedValue = "0";



    }
    //protected void BindDropTechnician()
    //{
    //    objRole = objRole.Get_RoleInfo_By_RoleName("technician");
    //    int roleid = Convert.ToInt32(objRole.Roleid);
    //    coltechnician = ObjUser.Get_All_By_Role(roleid);
    //    drpTechnician.DataTextField = "username";
    //    drpTechnician.DataValueField = "userid";
    //    drpTechnician.DataSource = coltechnician;
    //    drpTechnician.DataBind();
    //    ListItem item = new ListItem();
    //    item.Text = "---Select Technician---";
    //    item.Value = "0";
    //    drpTechnician.Items.Add(item);
    //    drpTechnician.SelectedValue = "0";



    //}
    /// <summary>
    /// //////////////
    /// </summary>
    protected void BindDropServiceEffected()
    {



        colservice = objservice.Get_All();
        drpserviceeffect.DataTextField = "servicename";
        drpserviceeffect.DataValueField = "serviceid";
        drpserviceeffect.DataSource = colservice;
        drpserviceeffect.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Service Effected------";
        item.Value = "0";
        drpserviceeffect.Items.Add(item);
        drpserviceeffect.SelectedValue = "0";



    }
    #endregion
    #endregion
    protected void imgchange_Click(object sender, ImageClickEventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan1.Visible = true;
            panaleditchange.Visible = false;
            panalproblemchange.Visible = false;
            panalprobleminfo.Visible = false;
            panalrequestinfo.Visible = false;
            panelincidentchange.Visible = false;
            panelHistory.Visible = false;
            panelchange.Visible = true;
            panalanalysis.Visible = false;
            LogNoteUpdatePanel();
            panalimplementation.Visible = false;

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
    {

        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int changeid = Convert.ToInt32(Request.QueryString[0]);

            ObjChangeBackOutPlan = ObjChangeBackOutPlan.Get_By_id(changeid);
            ObjChangeRollOutPlan = ObjChangeRollOutPlan.Get_By_id(changeid);
            ObjChangeImpact = ObjChangeImpact.Get_By_id(changeid);
            string description;
            if (ObjChangeBackOutPlan.Backoutid == 0)
            {
                lnkBackOutPlanadd.Visible = true;
                lnkBackOutPlanedit.Visible = false;

            }
            else
            {
                lnkBackOutPlanadd.Visible = false;
                lnkBackOutPlanedit.Visible = true;
            }

            if (ObjChangeImpact.Impactid == 0)
            {
                lnkimpadd.Visible = true;
                lnimpedit.Visible = false;

            }
            else
            {
                lnimpedit.Visible = true;
                lnkimpadd.Visible = false;
            }
            if (ObjChangeRollOutPlan.Rolloutid == 0)
            {
                lnkRollOutPlanadd.Visible = true;
                lnkRollOutPlanedit.Visible = false;

            }
            else
            {
                lnkRollOutPlanadd.Visible = false;
                lnkRollOutPlanedit.Visible = true;
            }
            ShowRollOutPlanPlaceholder();
            ShowBackOutPlanPlaceholder();
            ShowImpactPlaceholder();


            panalanalysis.Visible = true;
            panaleditchange.Visible = false;
            panalproblemchange.Visible = false;
            panalprobleminfo.Visible = false;
            panalrequestinfo.Visible = false;
            panelHistory.Visible = false;
            panDynamic.Visible = false;
            panelshowproblemchange.Visible = false;
            pan1.Visible = false;
            panelchange.Visible = false;
            panalimplementation.Visible = false;
            panelincidentchange.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void imgProblems_Click(object sender, ImageClickEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //panelProblem.Visible = false;
            //panalanalysis.Visible = false;
            //panalsolution.Visible = true;
            //panalrequestinfo.Visible = false;
            //panaleditproblem.Visible = false;
            //pan1.Visible = false;
            //panelHistory.Visible = false;

            //int problemid = Convert.ToInt32(Request.QueryString[0]);
            //colproblemtosolution = ObjProblemToSolution.Get_All_Problemid(problemid);

            //if (colproblemtosolution.Count == 0)
            //{

            //    lnkSolutionadd.Visible = true;
            //    lnkSolutionedit.Visible = false;
            //    lnkwrkaround.Visible = true;
            //    lnkwrkedit.Visible = false;
            //}
            //else
            //{
            //    foreach (ProblemToSolution obj in colproblemtosolution)
            //    {
            //        if (obj.Solutiontype == "WorkAround")
            //        {
            //            lnkwrkaround.Visible = false;
            //            lnkwrkedit.Visible = true;
            //        }
            //        if (obj.Solutiontype == "Solution")
            //        {
            //            lnkSolutionadd.Visible = false;
            //            lnkSolutionedit.Visible = true;
            //        }
            //    }

            //}



            //ShowSolutionPlaceholder();
            //ShowWorkaroundPlaceholder();
            ShowProblemToChange();
            pan1.Visible = false;
            panelHistory.Visible = false;
            panelchange.Visible = false;
            panalrequestinfo.Visible = false;
            panelRequest.Visible = false;
            panalproblemchange.Visible = true;
            panelshowproblemchange.Visible = false;
            panelincidentchange.Visible = false;
            panalanalysis.Visible = false;
            panalimplementation.Visible = false;

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
            //ShowIncidentToProblemPanel();
            //panelincidentproblem.Visible = true;
            //panelProblem.Visible = false;
            //// panelHistory.Visible = false;
            //pan1.Visible = false;
            //panelRequest.Visible = false;
            //panalrequestinfo.Visible = false;
            //LogNoteUpdatePanel();
            //HistoryUpdatePanel();
            //panalanalysis.Visible = false;
            //panalsolution.Visible = false;
            //panelHistory.Visible = false;
            panelchange.Visible = true;
            ShowIncidentToChange();
            pan1.Visible = false;
            panelHistory.Visible = false;
            panelchange.Visible = false;
            panalrequestinfo.Visible = false;
            panelRequest.Visible = false;
            panalproblemchange.Visible = false;
            panelshowproblemchange.Visible = false;
            panalanalysis.Visible = false;
            panalimplementation.Visible = false;
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
            //panelProblem.Visible = false;
            ////panelHistory.Visible = true;
            //panelincidentproblem.Visible = false;
            //panelProblem.Visible = false;
            //pan1.Visible = false;
            //panelRequest.Visible = false;
            //panalanalysis.Visible = false;
            //panalsolution.Visible = false;
            //panelHistory.Visible = true;
            //panDynamic.Visible = true;
            //HistoryUpdatePanel();
            panelHistory.Visible = true;
            panaleditchange.Visible = false;
            pan1.Visible = false;
            panelchange.Visible = false;
            panalanalysis.Visible = false;
            pan1.Visible = false;
            panDynamic.Visible = true;
            panalproblemchange.Visible = false;
            panalprobleminfo.Visible = false;
            panalrequestinfo.Visible = false;
            panelincidentchange.Visible = false;
            panalimplementation.Visible = false;

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
    protected void imgimplementation_Click(object sender, ImageClickEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            panelHistory.Visible = true;
            panaleditchange.Visible = false;
            pan1.Visible = false;
            panelchange.Visible = false;
            panalanalysis.Visible = false;
            pan1.Visible = false;
            panDynamic.Visible = false;
            panalproblemchange.Visible = false;
            panalprobleminfo.Visible = false;
            panalrequestinfo.Visible = false;
            panelincidentchange.Visible = false;
            panalimplementation.Visible = true;
            ShowImplementationChangetask();
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

    #region show change information
    protected void Showchangeinfo()
    {
        changeid = Convert.ToInt32(Request.QueryString[0]);
        colapprovechange = Objchnageapprovetrans.Get_All_Changeid(changeid);
        panelchange.Visible = true;
        if (colapprovechange.Count == 0)
        {

           // lnkEdit.Visible = false;
            lnkEdit.Visible = true;
        }

        pan1.Visible = true;
        panaleditchange.Visible = false;
        panalanalysis.Visible = false;
        panalprobleminfo.Visible = false;
        panalrequestinfo.Visible = false;
        panelincidentchange.Visible = false;
        panelRequest.Visible = false;
        panelHistory.Visible = false;

        lblchangeid.Text = changeid.ToString();
        ObjChange = ObjChange.Get_By_id(changeid);
        int statusid = Convert.ToInt32(ObjChange.Statusid);
        ObjStatus = ObjStatus.Get_By_id(statusid);
        Objchangestatus = Objchangestatus.Get_By_id(statusid);
        if (Objchangestatus.Statusname == Resources.MessageResource.StrRejected.ToString())
        {
            //lnkEdit.Visible = false;
            lnkEdit.Visible = true;
        }
        lblDateDisp.Text = ObjChange.Createdtime.ToString();
        int requesterid = Convert.ToInt32(ObjChange.Requestedby);
        ObjUser = ObjUser.Get_By_id(requesterid);
        if (requesterid != 0)
        {
            lblRequesterDisp.Text = ObjUser.Username.ToString();

        }


        lblTitle.Text = ObjChange.Title.ToString();

        lblDescription.Text = ObjChange.Description.ToString();
        ///////////////////////////////change done by meenakshi
        //lblserviceeffected.Text = "Email";
        if (ObjChange.servicename != null)
        {
            lblserviceeffected.Text = ObjChange.servicename.ToString();
        }
        else
        {
            lblserviceeffected.Text = "";
        }
            //////////////////////////////end
        int chantypeid = Convert.ToInt32(ObjChange.Changetype);
        ObjChangeType = ObjChangeType.Get_By_id(chantypeid);
        if (chantypeid != 0)
        {
            lblchangetype.Text = ObjChangeType.Changetypename.ToString();
        }
        int changestatus = Convert.ToInt32(ObjChange.Statusid);
        Objchangestatus = Objchangestatus.Get_By_id(changestatus);
        if (changestatus != 0)
        {
            lblStatus.Text = Objchangestatus.Statusname;
        }
        //int priorityid = Convert.ToInt32(ObjChange.Priority);
        //ObjPriority = ObjPriority.Get_By_id(priorityid);
        //if (priorityid != 0)
        //{
        //    lblpriority.Text = ObjPriority.Name.ToString();

        //}
        //else
        //{
        //    lblpriority.Text = "";

        //}

        int category = Convert.ToInt32(ObjChange.Categoryid);
        ObjCategory = ObjCategory.Get_By_id(category);
        if (category != 0)
        {
            lblcategory.Text = ObjCategory.CategoryName.ToString();

        }
        else
        {
            lblcategory.Text = "";

        }


        int subcategory = Convert.ToInt32(ObjChange.Subcategoryid);
        Objsubcategory = Objsubcategory.Get_By_id(subcategory);
        if (subcategory != 0)
        {
            lblsubcategory.Text = Objsubcategory.Subcategoryname.ToString();

        }
        else
        {
            lblsubcategory.Text = "";

        }

        int creator = Convert.ToInt32(ObjChange.CreatedByID);
        ObjUser = ObjUser.Get_By_id(creator);
        lblCreatedby.Text = ObjUser.Username.ToString();
        lblCreatedDate.Text = ObjChange.Createdtime.ToString();
        int techid = Convert.ToInt32(ObjChange.Technician);
        ObjUser = ObjUser.Get_By_id(techid);

        //if (techid != 0)
        //{
        //    lbltechid.Text = ObjUser.Username.ToString();

        //}
        //else
        //{
        //    lbltechid.Text = "";

        //}
        if (ObjChange.Completedtime != null)
        {
            lblCompletedDate.Text = ObjChange.Completedtime.ToString();
        }

        colassetincludeinchange = objincludeasset.Get_All_IncludeAssetinchange(changeid);
        BLLCollection<Configuration_mst> colasset = new BLLCollection<Configuration_mst>();


        foreach (IncludedAssetinchange obj in colassetincludeinchange)
        {
            Configuration_mst ObjAsset = new Configuration_mst();
            ObjAsset = ObjAsset.Get_By_id(obj.Assetid);
            colasset.Add(ObjAsset);

        }
        lstAsset.DataTextField = "Serialno";
        lstAsset.DataValueField = "assetid";
        lstAsset.DataSource = colasset;
        lstAsset.DataBind();

    }
    # endregion

    #region FetchData Function

    string GetChangeStatusString(int statusid)
    {
        string statusname = "";
        Objchangestatus = Objchangestatus.Get_By_id(statusid);
        if (Objchangestatus.ChangeStatusid != 0)
        {
            statusname = Objchangestatus.Statusname;

        }
        return statusname;

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

    protected void lnkEdit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan1.Visible = false;
            panaleditchange.Visible = true;
            editpanal();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
    #region edit the values of a change
    protected void editpanal()
    {
        BindDropChangeStatus();
        //BindDropPriority();
        BindDropCategory();
        // BindDropSubCategory();
        BindDropChangeType();
        BindDropServiceEffected();
        //BindDropTechnician();
        btnUpdate.Visible = true;
        btnCancel.Visible = true;
        changeid = Convert.ToInt32(Request.QueryString[0]);
        ObjChange = ObjChange.Get_By_id(changeid);
        ////drpTechnician.SelectedValue = ObjChange.Technician.ToString();
        ////////////////////////////////////change done by meenakshi
        int objser ;
        objser = objservice.Get_By_ServiceName(ObjChange.servicename);
        drpserviceeffect.SelectedValue = objser.ToString();
        
        //lblchangeserviceeffected.Text = "Email";
        //////////////////////////////////end
        drpStatus.SelectedValue = ObjChange.Statusid.ToString();
        //drpPriority.SelectedValue = ObjChange.Priority.ToString();
        drpCategory.SelectedValue = ObjChange.Categoryid.ToString();
        BindDropSubCategory();
        drpSubcategory.SelectedValue = ObjChange.Subcategoryid.ToString();

        drpchangetype.SelectedValue = ObjChange.Changetype.ToString();
        ObjUser = ObjUser.Get_By_id(ObjChange.CreatedByID);
        lblcreatedbyuser.Text = ObjUser.Username.ToString();
        lblcreatedchangedate.Text = ObjChange.Createdtime.ToString();
        if (ObjChange.Completedtime != null)
        {
            lblchangecompleteddate.Text = ObjChange.Completedtime.ToString();
        }

        colassetincludeinchange = objincludeasset.Get_All_IncludeAssetinchange(changeid);
        BLLCollection<Configuration_mst> colasset = new BLLCollection<Configuration_mst>();
        Configuration_mst ObjAsset = new Configuration_mst();

        foreach (IncludedAssetinchange obj in colassetincludeinchange)
        {
            ObjAsset = ObjAsset.Get_By_id(obj.Assetid);
            colasset.Add(ObjAsset);

        }
        lstassetupdate.DataTextField = "Serialno";
        lstassetupdate.DataValueField = "assetid";
        lstassetupdate.DataSource = colasset;
        lstassetupdate.DataBind();


    }
    #endregion
    #region History Update Panal Shows the history
    protected void HistoryUpdatePanel()
    {
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolderHistory.Controls.Clear();
        Table tbl = new Table();
        PlaceHolderHistory.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Get Changeid from QueryString
        int changeid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Get Collection of ChangeHistory on the basis of changeid
        colChangeHistory = ObjChangeHistory.Get_All_By_Changeid(changeid);
        #endregion
        #region Fetch each object of IncidentHistory from Collection of colIncidentHistory
        foreach (ChangeHistory obj in colChangeHistory)
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

            if (obj.Operation == Resources.MessageResource.StrRequested.ToString())
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
            if (obj.Operation == "BackOutPlanAdded" || obj.Operation == "RollOut Plan Added" || obj.Operation == "ImpactAdded")
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
            if (obj.Operation == "BackOutPlanChanged" || obj.Operation == "RollOutPlanUpdated" || obj.Operation == "ImpactUpdated")
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

            #region Get Collection of ChnageHistoryDiff on the basis of historyid

            colChangeHistoryDiff = ObjChangeHistoryDiff.Get_All_By_Historyid(obj.Historyid);
            #endregion
            if (colChangeHistoryDiff.Count != 0)
            {
                #region Fetch each object of IncidentHistoryDiff from Collection of colIncidentHistoryDiff
                foreach (ChangeHistoryDiff objDiff in colChangeHistoryDiff)
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
                    #region If Modification is done at ChangeType of Item,then print Category History
                    if (objDiff.Columnname == Resources.MessageResource.strColumnChangeType.ToString())
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
                    #region If only BackoutPlan,RolloutPlan,Impact is changed

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
                    //if (objDiff.Columnname == Resources.MessageResource.strColumnAssignedTime.ToString())
                    //{

                    //    strPrevValue = Convert.ToString(objDiff.Prev_value);
                    //    strCurrentValue = Convert.ToString(objDiff.Current_value);
                    //    if (strPrevValue == "")
                    //    { strPrevValue = "-"; }
                    //    if (strCurrentValue == "")
                    //    { strCurrentValue = "-"; }
                    //    lblinner.Text = "&nbsp;&nbsp;Time of technician assignment changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
                    //}
                    #endregion

                    #region If Modification is done at Status of call,then print Status History
                    if (objDiff.Columnname == Resources.MessageResource.strColumnstatusid.ToString())
                    {
                        int prevchangestatusid = Convert.ToInt32(objDiff.Prev_value);
                        int curentchangestatusid = Convert.ToInt32(objDiff.Current_value);

                        strPrevValue = GetChangeStatusString(prevchangestatusid);

                        strCurrentValue = GetChangeStatusString(curentchangestatusid);
                        if (strPrevValue == "")
                        { strPrevValue = "-"; }
                        if (strCurrentValue == "")
                        { strCurrentValue = "-"; }
                        lblinner.Text = "&nbsp;&nbsp;Status  changed  from &nbsp;<b>" + strPrevValue + "</b>&nbsp;&nbsp;to&nbsp;&nbsp;<b>" + strCurrentValue + "</b>";
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
    #endregion

    #region Function for updating the values of change in database

    protected void btnUpdate_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            # region Declare Local Variable
            string StrStatusRequested;
            string StrStatusRejected;
            string StrStatusApproval;
            string StrStatusApproved;
            string StrStatusPlanning;
            string StrStatusTesting;
            string StrStatusRelease;
            string StrStatusImplemented;
            string StrStatusCompleted;
            string StrStatusString = "";
            int userid = 0;
            int changeid = Convert.ToInt32(Request.QueryString[0]);
            string userName = "";
            #endregion
            #region Fetch the Status Value from Resource File
            StrStatusString = GetChangeStatusString(Convert.ToInt32(drpStatus.SelectedValue));
            StrStatusRejected = Resources.MessageResource.StrRejected.ToString();
            StrStatusApproval = Resources.MessageResource.StrApproval.ToString();
            StrStatusRequested = Resources.MessageResource.StrRequested.ToString();
            StrStatusApproved = Resources.MessageResource.StrApproved.ToString();
            StrStatusPlanning = Resources.MessageResource.StrPlanning.ToString();
            StrStatusTesting = Resources.MessageResource.StrTesting.ToString();
            StrStatusRelease = Resources.MessageResource.StrRelease.ToString();
            StrStatusImplemented = Resources.MessageResource.StrImplemented.ToString();
            StrStatusCompleted = Resources.MessageResource.StrCompleted.ToString();

            #endregion
            MembershipUser User = Membership.GetUser();
            userName = User.UserName.ToString();

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

            #region Insert Historyvalue in Change History Table
            int result = String.Compare(StrStatusString, StrStatusRequested, true);
            /////////////////////////////////////////////change in status done by meenakshi 3rd oct
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Requested";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusRejected, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Closed";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusApproval, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Approved";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusApproved, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Planning";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusPlanning, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Testing";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusTesting, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Release";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusRelease, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Implemented";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusImplemented, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Approval";
                ObjChangeHistory.Insert();
            }
            result = String.Compare(StrStatusString, StrStatusCompleted, true);
            if (result == 0)
            {
                ObjChangeHistory.Changeid = changeid;
                ObjChangeHistory.Operationownerid = userid;
                ObjChangeHistory.Operation = "Rejected";
                ObjChangeHistory.Insert();
            }
            #endregion

            /////////////////////////////////////////end
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()

            int historyid = ObjChangeHistory.Get_Current_ChangeHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid

            ObjChange = ObjChange.Get_By_id(changeid);


            #endregion
            #region Insert into ChangeHistoryDiff table ,By Comparing Current value and Updated Values
            if (ObjChange.Changeid != 0)
            {
                #region Declare local variable
                string columnName;
                string prev_value;
                string curnt_value;
                #endregion
                //#region If Priority value is changed,Insert into ChangeHistoryDiff table


                //if (ObjChange.Priority != Convert.ToInt32(drpPriority.SelectedValue))
                //{
                //    columnName = Resources.MessageResource.strColumnPriorityid.ToString();
                //    prev_value = Convert.ToString(ObjChange.Priority);
                //    curnt_value = Convert.ToString(drpPriority.SelectedValue);
                //    ObjChangeHistoryDiff.Historyid = historyid;
                //    ObjChangeHistoryDiff.Columnname = columnName;
                //    ObjChangeHistoryDiff.Current_value = curnt_value;
                //    ObjChangeHistoryDiff.Prev_value = prev_value;
                //    ObjChangeHistoryDiff.Insert();
                //}
                //#endregion
                //#region If Technician value is changed,Insert into ChangeHistoryDiff table
                //if (ObjChange.Technician != Convert.ToInt32(drpTechnician.SelectedValue))
                //{
                //    columnName = Resources.MessageResource.strColumnTechnicianid.ToString();
                //    prev_value = Convert.ToString(ObjChange.Technician);
                //    curnt_value = Convert.ToString(drpTechnician.SelectedValue);
                //    ObjChangeHistoryDiff.Historyid = historyid;
                //    ObjChangeHistoryDiff.Columnname = columnName;
                //    ObjChangeHistoryDiff.Current_value = curnt_value;
                //    ObjChangeHistoryDiff.Prev_value = prev_value;
                //    ObjChangeHistoryDiff.Insert();

                //}
                //#endregion
                #region If category value is changed,Insert into ChangeHistoryDiff table


                if (ObjChange.Categoryid != Convert.ToInt32(drpCategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnCategoryid.ToString();
                    prev_value = Convert.ToString(ObjChange.Categoryid);
                    curnt_value = Convert.ToString(drpCategory.SelectedValue);
                    ObjChangeHistoryDiff.Historyid = historyid;
                    ObjChangeHistoryDiff.Columnname = columnName;
                    ObjChangeHistoryDiff.Current_value = curnt_value;
                    ObjChangeHistoryDiff.Prev_value = prev_value;
                    ObjChangeHistoryDiff.Insert();
                }
                #endregion
                #region If Subcategory value is changed,Insert into ChangeHistoryDiff table


                if (ObjChange.Subcategoryid != Convert.ToInt32(drpSubcategory.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnSubcategoryid.ToString();
                    prev_value = Convert.ToString(ObjChange.Subcategoryid);
                    curnt_value = Convert.ToString(drpSubcategory.SelectedValue);
                    ObjChangeHistoryDiff.Historyid = historyid;
                    ObjChangeHistoryDiff.Columnname = columnName;
                    ObjChangeHistoryDiff.Current_value = curnt_value;
                    ObjChangeHistoryDiff.Prev_value = prev_value;
                    ObjChangeHistoryDiff.Insert();
                }
                #endregion
                #region If Changetype value is changed,Insert into ChangeHistoryDiff table


                if (ObjChange.Changetype != Convert.ToInt32(drpchangetype.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnChangeType.ToString();
                    prev_value = Convert.ToString(ObjChange.Changetype);
                    curnt_value = Convert.ToString(drpchangetype.SelectedValue);
                    ObjChangeHistoryDiff.Historyid = historyid;
                    ObjChangeHistoryDiff.Columnname = columnName;
                    ObjChangeHistoryDiff.Current_value = curnt_value;
                    ObjChangeHistoryDiff.Prev_value = prev_value;
                    ObjChangeHistoryDiff.Insert();
                }
                #endregion
                #region If Changestatus value is changed,Insert into ChangeHistoryDiff table


                if (ObjChange.Changetype != Convert.ToInt32(drpStatus.SelectedValue))
                {
                    columnName = Resources.MessageResource.strColumnstatusid.ToString();
                    prev_value = Convert.ToString(ObjChange.Statusid);
                    curnt_value = Convert.ToString(drpStatus.SelectedValue);
                    ObjChangeHistoryDiff.Historyid = historyid;
                    ObjChangeHistoryDiff.Columnname = columnName;
                    ObjChangeHistoryDiff.Current_value = curnt_value;
                    ObjChangeHistoryDiff.Prev_value = prev_value;
                    ObjChangeHistoryDiff.Insert();
                }
                #endregion
                ////////////////////////////////////////////////////////////////change done by meenakshi
                //#region If serviceeffected value is changed,Insert into ChangeHistoryDiff table


                //if (ObjChange.servicename!= Convert.ToInt32(drpserviceeffect.SelectedValue))
                //{
                //    columnName = Resources.MessageResource.strColumnserviceeffected.ToString();
                //    prev_value = Convert.ToString(ObjChange.Statusid);
                //    curnt_value = Convert.ToString(drpStatus.SelectedValue);
                //    ObjChangeHistoryDiff.Historyid = historyid;
                //    ObjChangeHistoryDiff.Columnname = columnName;
                //    ObjChangeHistoryDiff.Current_value = curnt_value;
                //    ObjChangeHistoryDiff.Prev_value = prev_value;
                //    ObjChangeHistoryDiff.Insert();
                //}
                //#endregion
                ////////////////////////////////////////////////////////////////end

            }
            #endregion
            #region Update the completed status

            #endregion
            #region update the data in change_mst table

            //ObjChange.Technician = Convert.ToInt32(drpTechnician.SelectedValue);
            ObjChange.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
            ObjChange.Subcategoryid = Convert.ToInt32(drpSubcategory.SelectedValue);
            //ObjChange.Priority = Convert.ToInt32(drpPriority.SelectedValue);
            ObjChange.Changetype = Convert.ToInt32(drpchangetype.SelectedValue);
            ObjChange.Statusid = Convert.ToInt32(drpStatus.SelectedValue);
            ObjChange.Changeid = Convert.ToInt32(Request.QueryString[0]);
            //////change done by meenakshi
            objservice = objservice.Get_By_id(Convert.ToInt32(drpserviceeffect.SelectedValue));
            ObjChange.servicename = objservice.servicename;
            //ObjChange.servicename = drpserviceeffect.SelectedValue;
            /////end
            ObjChange.Active = true;
            #region If Current status is closed,then Assign Completed time
            result = String.Compare(StrStatusString, StrStatusCompleted, true);
            if (result == 0)
            {
                BLLCollection<Incident_To_Change> colincidentchnage = new BLLCollection<Incident_To_Change>();
                colincidentchnage = Objincidenttochange.Get_All_By_Changeid(changeid);
                int id = 0;
                foreach (Incident_To_Change objitoc in colincidentchnage)
                {
                    id = Convert.ToInt32(objitoc.Incidentid);
                }

                IncidentStates objstate = new IncidentStates();
                objstate = objstate.Get_By_id(id);
                Status_mst objincidentstats = new Status_mst();

                objincidentstats = objincidentstats.Get_By_id(objstate.Statusid);
                string currentincidentstatus = objincidentstats.Statusname.ToString();
                int comparestatus = String.Compare(currentincidentstatus, Resources.MessageResource.strStatusClose.ToString(), true);
                if (comparestatus == 0)
                {
                    ObjChange.Completedtime = DateTime.Now.ToString();
                    Change_mst Objcurrentchange = new Change_mst();
                    ChangeStatus_mst Objchangestatus = new ChangeStatus_mst();
                    Objcurrentchange = Objcurrentchange.Get_By_id(changeid);
                    Objchangestatus = Objchangestatus.Get_By_id(Objcurrentchange.Statusid);
                    string status = Objchangestatus.Statusname.ToString();

                    int result1 = String.Compare(status, StrStatusCompleted, true);
                    if (result1 == 0)
                    {
                        ObjChange.Completedtime = Objcurrentchange.Completedtime;
                        ObjChange.Update();

                    }
                    else
                    {
                        ObjChange.Completedtime = DateTime.Now.ToString();
                        ObjChange.Update();

                    }
                }

                else
                {
                    string myScript;
                    //myScript = "<script language=javascript>javascript:alert('Please Close All the Attached Incident');</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript:alert('Please Close Alll the attached incident');", "Javascript:alert('Please Close Alll the attached incident');", true);
                    ///'''Page.RegisterClientScriptBlock("MyScript", myScript);
                }



            }
            else
            {

            #endregion

                ObjChange.Update();

            }


            #endregion
            //   #region Update Include Assets in Change value in IncludedAssetinchange

            //objincludeasset.Delete(changeid);
            //for (int i = lstassetupdate.Items.Count - 1; i >= 0; i--)
            //{
            //    if (lstassetupdate.Items[i].Selected == true)
            //    {
            //        objincludeasset.Assetid = Convert.ToInt32(lstassetupdate.Items[i].Value);
            //        objincludeasset.Changeid = changeid;
            //        objincludeasset.Insert();

            //    }
            //}

            //#endregion
            Showchangeinfo();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
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
    #region Cancell the edit page
    protected void btnCancel_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Showchangeinfo();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
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

    protected void lnkopennewwindow_Click(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('SelectAssetFromCMDB.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", "javascript:window.open('SelectAssetFromCMDB.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", true);
            string myScript;
            myScript = "<script language=javascript>javascript:window.open('SelectAssetFromCMDB.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');</script>";
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
    protected void BindListBox()
    {

        Configuration_mst ObjAsset = new Configuration_mst();
        BLLCollection<Configuration_mst> col = new BLLCollection<Configuration_mst>();
        string varAsset = Session["AssetContract"].ToString();
        string[] arrAsset = varAsset.Split(',');
        int FlagCount = arrAsset.Length;
        for (int i = 0; i < FlagCount; i++)
        {
            if (arrAsset[i] != "," && arrAsset[i] != "")
            {
                Configuration_mst obj = new Configuration_mst();
                obj = ObjAsset.Get_By_id(Convert.ToInt32(arrAsset[i].ToString()));

                col.Add(obj);
            }

        }
        lstassetupdate.DataTextField = "Serialno";
        lstassetupdate.DataValueField = "assetid";
        lstassetupdate.DataSource = col;
        lstassetupdate.DataBind();
        for (int i = lstassetupdate.Items.Count - 1; i >= 0; i--)
        {
            lstassetupdate.Items[i].Selected = true;

        }
        Session["AssetContract"] = "";
        panaleditchange.Visible = true;
        pan1.Visible = false;
        editpanal();

    }
    #region
    protected void BindIncidentToChangegrid()
    {
        #region Declaration of  table Variable

        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();

        #endregion
        int changeid = Convert.ToInt32(Request.QueryString[0]);
        colincidenttochange = ObjIncidenttoChanges.Get_All_By_Changeid(changeid);
        foreach (Incident_To_Change obj in colincidenttochange)
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
        grdvwincidentchange.DataSource = dtTable;
        grdvwincidentchange.DataBind();
    }
    #endregion
    protected void grdvwincidentchange_RowDataBound(Object sender, GridViewRowEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
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
    protected void grdvwincidentchange_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int incidentid = Convert.ToInt32(grdvwincidentchange.Rows[e.NewEditIndex].Cells[0].Text);
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
    protected void lnkclose_Click(object sender, EventArgs e)
    {
        panelRequest.Visible = false;
        panalrequestinfo.Visible = false;
    }

    protected void lnkproblemclose_Click(object sender, EventArgs e)
    {
        panelRequest.Visible = false;
        panalrequestinfo.Visible = false;
        panalprobleminfo.Visible = false;
        panalproblemchange.Visible = true;

        panelshowproblemchange.Visible = false;
    }

    #endregion
    protected void grdvwincidentchange_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            grdvwincidentchange.PageIndex = e.NewPageIndex;
            BindIncidentToChangegrid();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void ShowIncidentToChange()
    {
        BindIncidentToChangegrid();
        panelincidentchange.Visible = true;

    }
    #region For binding the data in a grid to display linked Problems
    protected void BindProblemToChangegrid()
    {
        #region Declaration of  table Variable

        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();

        #endregion
        int changeid = Convert.ToInt32(Request.QueryString[0]);

        colproblemtochange = ObjProblemToChange.Get_All_By_changeid(changeid);
        foreach (Problem_To_Change obj in colproblemtochange)
        {
            int id = Convert.ToInt32(obj.Problemid);

            ObjProblem = ObjProblem.Get_By_id(id);

            DataRow row;
            row = dtTable.NewRow();
            //  row["incidentid"] = Convert.ToString(objIncident.Incidentid);
            row["ID"] = ObjProblem.ProblemId;
            row["title"] = ObjProblem.title;
            row["requesterid"] = Convert.ToString(ObjProblem.Requesterid);
            row["technicianid"] = ObjProblem.Technicianid;

            row["statusid"] = ObjProblem.Statusid;
            row["createdatetime"] = Convert.ToString(ObjProblem.CreateDatetime);
            //row["createdbyid"] = Convert.ToString(objIncident.Createdbyid);
            //row["siteid"] = Convert.ToString(objIncident.Siteid);



            //row["priorityid"] = objIncidentStates.Priorityid;
            dtTable.Rows.Add(row);


        }
        grdvwproblemchange.DataSource = dtTable;
        grdvwproblemchange.DataBind();
    }
    #endregion
    protected void grdvwproblemchange_RowEditing(object sender, GridViewEditEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            int problemid = Convert.ToInt32(grdvwproblemchange.Rows[e.NewEditIndex].Cells[0].Text);
            ViewState["ProblemId"] = problemid;
            ShowSelectedProblemDetails();
            //UpdatePanel1();
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
    protected void grdvwproblemchange_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {


            grdvwproblemchange.PageIndex = e.NewPageIndex;
            BindProblemToChangegrid();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void ShowProblemToChange()
    {
        BindProblemToChangegrid();
        panalproblemchange.Visible = true;

    }
    protected void grdvwproblemchange_RowDataBound(Object sender, GridViewRowEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
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
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    #region This function is for showing the details of a Linked Problem
    protected void ShowSelectedProblemDetails()
    {
        panalprobleminfo.Visible = true;
        panalproblemchange.Visible = true;
        grdvwproblemchange.Visible = true;
        panelshowproblemchange.Visible = true;
        int problemid = Convert.ToInt32(ViewState["ProblemId"]);
        ObjProblem = ObjProblem.Get_By_id(problemid);
        if (ObjProblem.ProblemId != 0)
        {
            ObjUser = ObjUser.Get_By_id(ObjProblem.Requesterid);
            lblproblemrequestedby.Text = ObjUser.Username.ToString();
            lblproblemcreateddate.Text = ObjProblem.CreateDatetime.ToString();
            if (ObjProblem.Description != null)
            {
                lblproblemdescription.Text = ObjProblem.Description.ToString();
            }
            lblproblemtitle.Text = ObjProblem.title.ToString();
            lblproblemserviceeffected.Text = "Email";
            ObjUser = ObjUser.Get_By_id(ObjProblem.Technicianid);
            lblproblemtechnician.Text = ObjUser.Username.ToString();
            ObjStatus = ObjStatus.Get_By_id(ObjProblem.Statusid);
            lblproblemstatus.Text = ObjStatus.Statusname.ToString();
            ObjPriority = ObjPriority.Get_By_id(ObjProblem.Priorityid);
            lblproblempriority.Text = ObjPriority.Name.ToString();
            ObjCategory = ObjCategory.Get_By_id(ObjProblem.Categoryid);
            lblproblemcategory.Text = ObjCategory.CategoryName.ToString();
            Objsubcategory = Objsubcategory.Get_By_id(ObjProblem.Subcategoryid);
            lblproblemsubcategory.Text = Objsubcategory.Subcategoryname.ToString();
            lblproblemcreateddate1.Text = ObjProblem.CreateDatetime.ToString();
            ObjUser = ObjUser.Get_By_id(ObjProblem.CreatedByid);
            lblproblemcreatedby.Text = ObjUser.Username.ToString();
            if (ObjProblem.CompletedTime != null)
            {
                lblproblemcompletedate.Text = ObjProblem.CompletedTime.ToString();
            }




        }

    }





    #endregion

    protected void lnkimpadd_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = true;
            btnsaveimpact.Visible = true;
            btncancellImpact.Visible = true;
            EditorRollOutPlan.Visible = false;
            btnupdateRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            EditorBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btnupdateBackOutPlan.Visible = false;
            ShowRollOutPlanPlaceholder();
            ShowBackOutPlanPlaceholder();
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
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = true;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = true;
            btnupdateImpact.Visible = true;
            int changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeImpact = ObjChangeImpact.Get_By_id(changeid);
            Editorimpact.Text = ObjChangeImpact.Description.ToString();
            EditorRollOutPlan.Visible = false;
            btnupdateRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            EditorBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btnupdateBackOutPlan.Visible = false;
            ShowRollOutPlanPlaceholder();
            ShowBackOutPlanPlaceholder();
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
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();
            ShowBackOutPlanPlaceholder();

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
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int changeid = Convert.ToInt32(Request.QueryString[0]);

            ObjChangeImpact.Changeid = changeid;
            ObjChangeImpact.Description = Editorimpact.Text.ToString();
            ObjChangeImpact.Insert();
            Editorimpact.Visible = false;
            ShowImpactPlaceholder();
            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "ImpactAdded";
            ObjChangeHistory.Insert();
            #endregion
            btnupdateImpact.Visible = false;
            btnsaveimpact.Visible = false;

            btncancellImpact.Visible = false;
            Editorimpact.Visible = false;
            lnimpedit.Visible = true;
            lnkimpadd.Visible = false;
            ShowBackOutPlanPlaceholder();
            ShowRollOutPlanPlaceholder();
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
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int changeid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "ImpactUpdated";
            ObjChangeHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjChangeHistory.Get_Current_ChangeHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling   ObjProblem = ObjProblem.Get_By_id(problemid);
            ObjChange = ObjChange.Get_By_id(changeid);

            #endregion
            #region Find the value of current symptom
            ObjChangeImpact = ObjChangeImpact.Get_By_id(ObjChange.Changeid);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjChangeImpact.Description);
            curnt_value = Convert.ToString(Editorimpact.Text);
            ObjChangeHistoryDiff.Historyid = historyid;
            ObjChangeHistoryDiff.Columnname = "Description";
            ObjChangeHistoryDiff.Current_value = curnt_value;
            ObjChangeHistoryDiff.Prev_value = prev_value;
            ObjChangeHistoryDiff.Insert();
            #endregion
            ObjChangeImpact.Changeid = changeid;
            ObjChangeImpact.Description = Editorimpact.Text.ToString();
            ObjChangeImpact.Update();
            ShowImpactPlaceholder();
            btnupdateImpact.Visible = false;
            btncancellImpact.Visible = false;
            btncancellImpact.Visible = false;
            Editorimpact.Visible = false;
            lnimpedit.Visible = true;
            lnkimpadd.Visible = false;
            ShowImpactPlaceholder();
            ShowBackOutPlanPlaceholder();
            ShowRollOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void ShowImpactPlaceholder()
    {
        int changeid = Convert.ToInt32(Request.QueryString[0]);
        ChangeImpact obj = new ChangeImpact();
        ObjChangeImpact = obj.Get_By_id(changeid);
        string description;
        if (ObjChangeImpact.Description == "")
        {
            lnkimpadd.Visible = true;
            lnimpedit.Visible = false;

        }

        if (ObjChangeImpact.Impactid == 0)
        {
            description = "";
        }
        else
        {
            description = ObjChangeImpact.Description.ToString();
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
    protected void lnkRollOutPlanadd_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRollOutPlan.Visible = true;
            btnsaveRollOutPlan.Visible = true;
            btncancellRollOutPlan.Visible = true;
            EditorBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btnupdateBackOutPlan.Visible = false;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowImpactPlaceholder();
            ShowBackOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkRollOutPlanedit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRollOutPlan.Visible = true;
            btnsaveRollOutPlan.Visible = false;
            EditorRollOutPlan.Visible = true;
            btncancellRollOutPlan.Visible = true;
            btnupdateRollOutPlan.Visible = true;
            int changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeRollOutPlan = ObjChangeRollOutPlan.Get_By_id(changeid);
            EditorRollOutPlan.Text = ObjChangeRollOutPlan.Description.ToString();
            EditorBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btnupdateBackOutPlan.Visible = false;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            ShowImpactPlaceholder();
            ShowBackOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnsaveRollOutPlan_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int changeid = Convert.ToInt32(Request.QueryString[0]);

            ObjChangeRollOutPlan.Changeid = changeid;
            ObjChangeRollOutPlan.Description = EditorRollOutPlan.Text.ToString();
            ObjChangeRollOutPlan.Insert();
            EditorRollOutPlan.Visible = false;
            ShowRollOutPlanPlaceholder();
            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "RollOut Plan Added";
            ObjChangeHistory.Insert();
            #endregion
            btnupdateRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            EditorRollOutPlan.Visible = false;
            lnkRollOutPlanedit.Visible = true;
            lnkRollOutPlanadd.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnupdateRollOutPlan_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int changeid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;

            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "RollOutPlanUpdated";
            ObjChangeHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()

            historyid = ObjChangeHistory.Get_Current_ChangeHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid

            ObjChange = ObjChange.Get_By_id(changeid);

            #endregion
            #region Find the value of current symptom
            ObjChangeRollOutPlan = ObjChangeRollOutPlan.Get_By_id(ObjChange.Changeid);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjChangeRollOutPlan.Description);
            curnt_value = Convert.ToString(EditorRollOutPlan.Text);
            ObjChangeHistoryDiff.Historyid = historyid;
            ObjChangeHistoryDiff.Columnname = "Description";
            ObjChangeHistoryDiff.Current_value = curnt_value;
            ObjChangeHistoryDiff.Prev_value = prev_value;
            ObjChangeHistoryDiff.Insert();
            #endregion
            ObjChangeRollOutPlan.Changeid = changeid;
            ObjChangeRollOutPlan.Description = EditorRollOutPlan.Text.ToString();
            ObjChangeRollOutPlan.Update();
            ShowRollOutPlanPlaceholder();
            btnupdateRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            EditorRollOutPlan.Visible = false;
            lnkRollOutPlanedit.Visible = true;

            lnkRollOutPlanadd.Visible = false;
            ShowImpactPlaceholder();
            ShowBackOutPlanPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void ShowRollOutPlanPlaceholder()
    {
        int changeid = Convert.ToInt32(Request.QueryString[0]);
        ChangeRollOut obj = new ChangeRollOut();
        ObjChangeRollOutPlan = obj.Get_By_id(changeid);
        if (ObjChangeRollOutPlan.Description == "")
        {
            lnkRollOutPlanedit.Visible = false;
            lnkRollOutPlanadd.Visible = true;
        }
        string description;
        if (ObjChangeRollOutPlan.Rolloutid == 0)
        {
            description = "";
        }
        else
        {
            description = ObjChangeRollOutPlan.Description.ToString();
        }
        PlaceholderRollOutPlan.Visible = true;
        #region Declaration of Dynamic Table,and Placeholder
        PlaceholderRollOutPlan.Controls.Clear();
        Table tbl = new Table();
        PlaceholderRollOutPlan.Controls.Add(tbl);
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
        EditorRollOutPlan.Visible = false;

    }
    protected void lnkBackOutPlanadd_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorBackOutPlan.Visible = true;

            btnsaveBackOutPlan.Visible = true;
            btncancellBackOutPlan.Visible = true;
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            EditorRollOutPlan.Visible = false;
            btnupdateRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            ShowRollOutPlanPlaceholder();
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
    protected void lnkBackOutPlanedit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorBackOutPlan.Visible = true;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = true;
            btnupdateBackOutPlan.Visible = true;

            int changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeBackOutPlan = ObjChangeBackOutPlan.Get_By_id(changeid);
            EditorBackOutPlan.Text = ObjChangeBackOutPlan.Descripion.ToString();
            Editorimpact.Visible = false;
            btnsaveimpact.Visible = false;
            btncancellImpact.Visible = false;
            btnupdateImpact.Visible = false;
            EditorRollOutPlan.Visible = false;
            btnupdateRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btnsaveBackOutPlan_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeBackOutPlan.Changeid = changeid;
            ObjChangeBackOutPlan.Descripion = EditorBackOutPlan.Text.ToString();
            ObjChangeBackOutPlan.Insert();
            EditorBackOutPlan.Visible = false;
            ShowBackOutPlanPlaceholder();
            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;

            MembershipUser User = Membership.GetUser();

            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "BackOutPlanAdded";
            ObjChangeHistory.Insert();
            #endregion
            btnupdateBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            EditorBackOutPlan.Visible = false;
            lnkBackOutPlanedit.Visible = true;
            lnkBackOutPlanadd.Visible = false;
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }

    protected void btnupdateBackOutPlan_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string prev_value;
            string curnt_value;
            int historyid;
            int changeid = Convert.ToInt32(Request.QueryString[0]);


            #region For updating values in Problem history table
            ObjChangeHistory.Changeid = changeid;
            MembershipUser User = Membership.GetUser();
            string username = User.UserName.ToString();
            Objorganization = Objorganization.Get_Organization();
            int userid = ObjUser.Get_By_UserName(username, Objorganization.Orgid);
            ObjChangeHistory.Operationownerid = userid;
            ObjChangeHistory.Operation = "BackOutPlanChanged";
            ObjChangeHistory.Insert();
            #endregion
            #region Get the Current historyid by calling function Get_Current_ProblemHistoryid()
            historyid = ObjChangeHistory.Get_Current_ChangeHistoryid();
            #endregion
            #region Find Current value of Problem aBy Calling Function Get_By_id(),via passing problemid
            ObjChange = ObjChange.Get_By_id(changeid);

            #endregion
            #region Find the value of current symptom
            ObjChangeBackOutPlan = ObjChangeBackOutPlan.Get_By_id(ObjChange.Changeid);


            #endregion
            #region Insert the values in history difference table
            prev_value = Convert.ToString(ObjChangeBackOutPlan.Descripion);
            curnt_value = Convert.ToString(EditorBackOutPlan.Text);
            ObjChangeHistoryDiff.Historyid = historyid;
            ObjChangeHistoryDiff.Columnname = "Description";
            ObjChangeHistoryDiff.Current_value = curnt_value;
            ObjChangeHistoryDiff.Prev_value = prev_value;
            ObjChangeHistoryDiff.Insert();
            #endregion
            ObjChangeBackOutPlan.Changeid = changeid;
            ObjChangeBackOutPlan.Descripion = EditorBackOutPlan.Text.ToString();
            ObjChangeBackOutPlan.Update();
            ShowBackOutPlanPlaceholder();
            btnupdateBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            EditorBackOutPlan.Visible = false;
            lnkBackOutPlanadd.Visible = false;
            lnkBackOutPlanedit.Visible = true;
            ShowBackOutPlanPlaceholder();
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
    protected void ShowBackOutPlanPlaceholder()
    {
        int changeid = Convert.ToInt32(Request.QueryString[0]);

        ObjChangeBackOutPlan = ObjChangeBackOutPlan.Get_By_id(changeid);
        string description;
        if (ObjChangeBackOutPlan.Descripion == "")
        {
            lnkBackOutPlanadd.Visible = true;
            lnkBackOutPlanedit.Visible = false;

        }
        if (ObjChangeBackOutPlan.Descripion == null)
        {
            description = "";
        }
        else
        {
            description = ObjChangeBackOutPlan.Descripion.ToString();
        }
        PlaceholderBackOutPlan.Visible = true;

        #region Declaration of Dynamic Table,and Placeholder
        PlaceholderBackOutPlan.Controls.Clear();
        Table tbl = new Table();
        PlaceholderBackOutPlan.Controls.Add(tbl);
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
        EditorBackOutPlan.Visible = false;



    }
    protected void btncancellBackOutPlan_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorBackOutPlan.Visible = false;
            btnsaveBackOutPlan.Visible = false;
            btncancellBackOutPlan.Visible = false;
            btnupdateBackOutPlan.Visible = false;

            ShowBackOutPlanPlaceholder();
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btncancellRollOutPlan_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            EditorRollOutPlan.Visible = false;
            btnsaveRollOutPlan.Visible = false;
            btncancellRollOutPlan.Visible = false;
            btnupdateRollOutPlan.Visible = false;
            ShowBackOutPlanPlaceholder();
            ShowImpactPlaceholder();
            ShowRollOutPlanPlaceholder();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
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
    protected void LogNoteUpdatePanel()
    {
        #region Declaration of Dynamic Table,and Placeholder
        PlaceHolder1.Controls.Clear();
        Table tbl = new Table();
        PlaceHolder1.Controls.Add(tbl);
        int hdwidth = 1500;
        int height = 5;
        #endregion
        #region Get changeid from QueryString
        int changeid = Convert.ToInt32(Request.QueryString[0]);
        #endregion
        #region Get Collection of ChangeNotes on the basis of Changeid

        colchangenotes = ObjChangeNotes.Get_All_By_Changeid(changeid);
        #endregion
        if (colchangenotes.Count == 0)
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
        foreach (ChangeNotes obj in colchangenotes)
        {
            #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
            string username;
            ObjUser = ObjUser.Get_By_id(obj.Username);
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
    protected void lnknewtask_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            //Response.Redirect("~/KEDB/ViewSolution.aspx");
            //string myScript;
            //myScript = "<script language=javascript>EndRequestHandler();</script>";
            //Page.RegisterClientScriptBlock("MyScript", myScript);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SomeUniqueID", "function HelloWorld() { alert('Hello World'); }", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewTaskWindow()", "OpenNewTaskWindow();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void BindChangeTask()
    {
        #region Declaration of  table Variable

        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable1();

        #endregion
        int changeid = Convert.ToInt32(Request.QueryString[0]);

        colchangetask = ObjChangeTask.Get_All_Changeid(changeid);
        foreach (ChangeTask_mst obj in colchangetask)
        {
            //int id = Convert.ToInt32(obj.Changeid);
            //objIncident = objIncident.Get_By_id(id);

            DataRow row;
            row = dtTable.NewRow();
            //  row["incidentid"] = Convert.ToString(objIncident.Incidentid);
            row["TaskId"] = Convert.ToInt32(obj.Taskid);
            row["Title"] = obj.Title.ToString();
            if (obj.Scheduledstarttime == null)
            {
                row["Scheduledstarttime"] = "";
            }
            else
            {
                row["Scheduledstarttime"] = obj.Scheduledstarttime.ToString();
            }
            if (obj.Scheduledendtime == null)
            {
                row["Scheduledendtime"] = "";
            }
            else
            {

                row["Scheduledendtime"] = obj.Scheduledendtime.ToString();
            }
            row["Taskstatusid"] = obj.Taskstatusid;
            row["Ownerid"] = obj.Ownerid;





            dtTable.Rows.Add(row);


        }
        grdvwimplementation.DataSource = dtTable;
        grdvwimplementation.DataBind();



    }
    protected DataTable CreateDataTable1()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TaskId";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Title";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Scheduledstarttime";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Scheduledendtime";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Taskstatusid";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Ownerid";
        myDataTable.Columns.Add(myDataColumn);



        return myDataTable;
    }
    protected void ShowImplementationChangetask()
    {
        BindChangeTask();
        panalimplementation.Visible = true;

    }
    protected void grdvwimplementation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {




                #region Bind Datarow at Run Time with technicianid to technician name
                int technicianid = Convert.ToInt32(e.Row.Cells[5].Text);
                ObjUser = ObjUser.Get_By_id(technicianid);
                if (ObjUser.Userid != 0)
                {
                    e.Row.Cells[5].Text = ObjUser.Username.ToString();
                }
                else { e.Row.Cells[5].Text = ""; }
                #endregion
                int taskstatusid = Convert.ToInt32(e.Row.Cells[4].Text);
                if (taskstatusid == 1)
                {
                    e.Row.Cells[4].Text = "Open";
                }
                else
                {
                    e.Row.Cells[4].Text = "Closed";
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
    protected void grdvwimplementation_RowEdit(object sender, GridViewEditEventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int temp = 0;
            int taskid = Convert.ToInt32(grdvwimplementation.Rows[e.NewEditIndex].Cells[0].Text);

            string url = "../Change/InsertChangeTask.aspx?taskid=" + taskid;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('" + url + "','popupwindow','width=600,height=400,left=230,top=300,Scrollbars=yes');", "javascript:window.open('" + url + "','popupwindow','width=600,height=400,left=230,top=300,Scrollbars=yes');", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void drpserviceeffect_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropServiceEffected();
    }
}
