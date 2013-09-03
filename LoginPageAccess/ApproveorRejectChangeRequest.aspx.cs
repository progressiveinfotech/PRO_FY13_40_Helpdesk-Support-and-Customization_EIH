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
using System.Collections.Specialized;


public partial class WithoutLoginPageAccess_ApproveorRejectChangeRequest : System.Web.UI.Page
{
    int changeid;
    UserLogin_mst ObjUser = new UserLogin_mst();
    ChangeType_mst ObjChangeType = new ChangeType_mst();
    ChangeStatus_mst Objchangestatus = new ChangeStatus_mst();
    Priority_mst ObjPriority = new Priority_mst();
    Category_mst ObjCategory = new Category_mst();
    Subcategory_mst Objsubcategory = new Subcategory_mst();
    BLLCollection<IncludedAssetinchange> colassetincludeinchange = new BLLCollection<IncludedAssetinchange>();
    Change_mst ObjChange = new Change_mst();
    IncludedAssetinchange objincludeasset = new IncludedAssetinchange();
    Asset_mst ObjAsset = new Asset_mst();
    ChangeApprove_trans ObjChangeApproveTrans = new ChangeApprove_trans();
    BLLCollection<ChangeApprove_trans> colapproversinfo = new BLLCollection<ChangeApprove_trans>();
    Configuration_mst Objconfiguration = new Configuration_mst();
    Status_mst Objstatus = new Status_mst();
    Incident_To_Change Objincidenttochange = new Incident_To_Change();
    IncludedAssetinchange Objincludeassetinchange = new IncludedAssetinchange();
    IncidentHistory objincidenthistory = new IncidentHistory();
    Mode_mst ObjMode = new Mode_mst();




    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {

                colapproversinfo = ObjChangeApproveTrans.Get_All_Changeid(Convert.ToInt32(Request.QueryString[0]));
                if (colapproversinfo.Count == 0)
                {
                    Showchangeinfo();
                    Alreadyapprovedpanal.Visible = false;
                }
                else
                {

                    Showchangeinfo();
                    Alreadyapprovedpanal.Visible = true;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;

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

    #region show change information
    protected void Showchangeinfo()
    {
        Approvalpanal.Visible = true;
        btnApprove.Visible = true;
        btnReject.Visible = true;
        Alreadyapprovedpanal.Visible = false;
        NameValueCollection n = Request.QueryString;

        int changeid = Convert.ToInt32(Request.QueryString[0]);
        //lblchangeid.Text = changeid.ToString();
        ObjChange = ObjChange.Get_By_id(changeid);
        lblchangeid.Text = ObjChange.Changeid.ToString();
        lbltitle.Text = ObjChange.Title;
        lbldescription.Text = ObjChange.Description;
        //lblDateDisp.Text = ObjChange.Createdtime.ToString();
        int requesterid = Convert.ToInt32(ObjChange.Requestedby);



        //lblTitle.Text = ObjChange.Title.ToString();

        //lblDescription.Text = ObjChange.Description.ToString();

        /////////////////////////change done by meenakshi
        lblserviceeffected.Text = ObjChange.servicename.ToString();
        //lblserviceeffected.Text = "Email";
        ////////////////////////end
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
        int priorityid = Convert.ToInt32(ObjChange.Priority);
        ObjPriority = ObjPriority.Get_By_id(priorityid);
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
        colassetincludeinchange = objincludeasset.Get_All_IncludeAssetinchange(changeid);
        BLLCollection<Configuration_mst> colasset = new BLLCollection<Configuration_mst>();
        Configuration_mst ObjAsset = new Configuration_mst();

        foreach (IncludedAssetinchange obj in colassetincludeinchange)
        {
            ObjAsset = ObjAsset.Get_By_id(obj.Assetid);
            colasset.Add(ObjAsset);

        }
        lstAsset.DataTextField = "Serialno";
        lstAsset.DataValueField = "assetid";
        lstAsset.DataSource = colasset;
        lstAsset.DataBind();

    }
    # endregion
    #region Add the Approval
    protected void btnApprove_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ObjChangeApproveTrans.Changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeApproveTrans.Approvalcomment = txtcomment.Text.ToString();
            ObjChangeApproveTrans.ApproverName = Request.QueryString[1];
            int changestatusid = Objchangestatus.Get_By_StatusName(Resources.MessageResource.StrApproved);

            ObjChangeApproveTrans.Approvestatus = changestatusid;
            ObjChangeApproveTrans.Insert();
            Change_mst Obj = new Change_mst();
            Obj = Obj.Get_By_id(Convert.ToInt32(Request.QueryString[0]));
            ObjChange.Statusid = changestatusid;
            ObjChange.Changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChange.Active = true;
            ObjChange.Assignetime = Obj.Assignetime;
            ObjChange.Categoryid = Obj.Categoryid;
            ObjChange.Changetype = Obj.Changetype;
            ObjChange.Subcategoryid = Obj.Subcategoryid;
            ObjChange.Technician = Obj.Technician;
            ObjChange.Title = Obj.Title;
            //ObjChange.Completedtime = "";
            ObjChange.CreatedByID = Obj.CreatedByID;
            ObjChange.Description = Obj.Description;
            ObjChange.Priority = Obj.Priority;
            ObjChange.Requestedby = Obj.Requestedby;
            ObjChange.Sceduledstarttime = Obj.Sceduledstarttime;
            ObjChange.Sceduledendtime = Obj.Sceduledendtime;
            ObjChange.Approvalstatus = Obj.Approvalstatus;
            ObjChange.Impact = Obj.Impact;
            ObjChange.Update();
            Change_mst ObjNewChange = new Change_mst();
            ObjNewChange = ObjNewChange.Get_By_id(Convert.ToInt32(Request.QueryString[0]));
            string approvalrequest = Resources.MessageResource.StrApproved.ToString();
            int modeid = ObjMode.Get_Mode_By_Mname("Email");
            if (approvalrequest == "Approved")
            {
                BLLCollection<Incident_To_Change> colIncToChng = new BLLCollection<Incident_To_Change>();
                colIncToChng = Objincidenttochange.Get_All_By_Changeid(ObjNewChange.Changeid);
                int FlagStatus = 0;
                foreach (Incident_To_Change obj in colIncToChng)
                {
                    FlagStatus = FlagStatus + 1;
                }
                if (FlagStatus == 0)
                {

                    string statusname = Resources.MessageResource.strStatusOpen.ToString();
                    int statusid = Convert.ToInt32(Objstatus.Get_By_StatusName(statusname));

                    Objincludeassetinchange = Objincludeassetinchange.Get_By_Changeid(ObjNewChange.Changeid);
                    Objconfiguration = Objconfiguration.Get_By_id(Objincludeassetinchange.Assetid);
                    int priorityid = Convert.ToInt32(Objconfiguration.Severity);
                    Incident_mst Objincident = new Incident_mst();
                    int slaid = Objincident.Get_By_SLAid(Objconfiguration.Siteid, priorityid);
                    Objincident.Requesterid = ObjNewChange.Requestedby;
                    Objincident.Title = ObjNewChange.Title;
                    Objincident.Siteid = Objconfiguration.Siteid;
                    Objincident.Createdbyid = ObjNewChange.CreatedByID;
                    Objincident.Slaid = Convert.ToInt32(slaid);
                    Objincident.Modeid = modeid;
                    Objincident.Insert();
                    int incidentid = Objincident.Get_Current_Incidentid();
                    IncidentStates Objincidentstattes = new IncidentStates();
                    Objincidentstattes.Incidentid = incidentid;
                    Objincidentstattes.Priorityid = Convert.ToInt32(Objconfiguration.Severity);
                    Objincidentstattes.Subcategoryid = ObjNewChange.Subcategoryid;
                    Objincidentstattes.Categoryid = ObjNewChange.Categoryid;
                    Objincidentstattes.Statusid = statusid;
                    Objincidentstattes.Requesttypeid = 2;
                    Objincidentstattes.Insert();
                    objincidenthistory.Incidentid = incidentid;
                    objincidenthistory.Operation = "create";
                    objincidenthistory.Operationownerid = ObjNewChange.CreatedByID;
                    objincidenthistory.Insert();
                    Objincidenttochange.Changeid = ObjNewChange.Changeid;
                    Objincidenttochange.Incidentid = incidentid;
                    Objincidenttochange.Insert();
                    string myScript;
                    myScript = "<script language=javascript>CloseWindow();</script>";
                    Page.RegisterClientScriptBlock("MyScript", myScript);
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
    #region To reject the Change
    protected void btnReject_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ObjChangeApproveTrans.Changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChangeApproveTrans.Approvalcomment = txtcomment.Text.ToString();
            ObjChangeApproveTrans.ApproverName = Request.QueryString[1];
            int changestatusid = Objchangestatus.Get_By_StatusName(Resources.MessageResource.StrRejected);

            ObjChangeApproveTrans.Approvestatus = changestatusid;
            ObjChangeApproveTrans.Insert();



            ObjChangeApproveTrans.Approvestatus = changestatusid;
            ObjChangeApproveTrans.Insert();
            Change_mst Obj = new Change_mst();
            Obj = Obj.Get_By_id(Convert.ToInt32(Request.QueryString[0]));
            ObjChange.Statusid = changestatusid;
            ObjChange.Changeid = Convert.ToInt32(Request.QueryString[0]);
            ObjChange.Active = true;
            ObjChange.Assignetime = Obj.Assignetime;
            ObjChange.Categoryid = Obj.Changetype;
            ObjChange.Subcategoryid = Obj.Subcategoryid;
            ObjChange.Technician = Obj.Technician;
            ObjChange.Title = Obj.Title;
            ObjChange.Completedtime = Obj.Createdtime;
            ObjChange.CreatedByID = Obj.CreatedByID;
            ObjChange.Description = Obj.Description;
            ObjChange.Priority = Obj.Priority;
            ObjChange.Requestedby = Obj.Requestedby;
            ObjChange.Sceduledstarttime = Obj.Sceduledstarttime;
            ObjChange.Sceduledendtime = Obj.Sceduledendtime;
            ObjChange.Approvalstatus = Obj.Approvalstatus;
            ObjChange.Impact = Obj.Impact;
            ObjChange.Update();
            string myScript;
            myScript = "<script language=javascript>CloseWindow();</script>";
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
    #endregion

}
