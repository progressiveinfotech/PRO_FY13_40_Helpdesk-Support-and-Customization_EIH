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

public partial class Change_CreateChangefromProblem : System.Web.UI.Page
{
    BLLCollection<ChangeStatus_mst> colchangestatus = new BLLCollection<ChangeStatus_mst>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    BLLCollection<ChangeType_mst> colchangetype = new BLLCollection<ChangeType_mst>();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    ChangeStatus_mst Objchangestatus = new ChangeStatus_mst();
    Priority_mst ObjPriority = new Priority_mst();
    Category_mst ObjCategory = new Category_mst();
    Subcategory_mst ObjSubcategory = new Subcategory_mst();
    ChangeType_mst ObjChangeType = new ChangeType_mst();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    UserLogin_mst objuser = new UserLogin_mst();
    Change_mst ObjChange = new Change_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    IncludedAssetinchange Objincludeaasetchange = new IncludedAssetinchange();
    Problem_mst ObjProblem = new Problem_mst();
    Problem_To_Change ObjProblemToChange = new Problem_To_Change();

    public int requesterid;
    protected void Page_Load(object sender, EventArgs e)
    {  /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindDropChangeStatus();
                BindDropPriority();
                BindDropCategory();

                BindDropChangeType();
                BindDropTechnician();
                Showvalues();
                string varAsset = "";
                if (Session["AssetContract"] != null)
                {
                    varAsset = Session["AssetContract"].ToString();
                }

                if (varAsset != "")
                {
                    BindListBox();
                }

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

    #region Function For all the Dropdown Binding
    protected void BindDropChangeStatus()
    {

        colchangestatus = Objchangestatus.Get_All();
        drpStatus.DataTextField = "statusname";
        drpStatus.DataValueField = "changestatusid";
        drpStatus.DataSource = colchangestatus;
        drpStatus.DataBind();

    }
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

        colSubCategory = ObjSubcategory.Get_All_By_Categoryid(categoryid);
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
    #endregion
    protected void BindListBox()
    {

        drpCategory.SelectedValue = Session["Categoryid"].ToString();
        drpSubcategory.SelectedValue = Session["Subcategoryid"].ToString();
        drpTechnician.SelectedValue = Session["Technician"].ToString();
        txtTitle.Text = Session["Title"].ToString();
        drpchangetype.SelectedValue = Session["Changetype"].ToString();

        Asset_mst ObjAsset = new Asset_mst();
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        string varAsset = Session["AssetContract"].ToString();
        string[] arrAsset = varAsset.Split(',');
        int FlagCount = arrAsset.Length;
        for (int i = 0; i < FlagCount; i++)
        {
            if (arrAsset[i] != "," && arrAsset[i] != "")
            {
                Asset_mst obj = new Asset_mst();
                obj = ObjAsset.Get_By_id(Convert.ToInt32(arrAsset[i].ToString()));
                col.Add(obj);
            }

        }
        ListAsset.DataTextField = "computerName";
        ListAsset.DataValueField = "assetid";
        ListAsset.DataSource = col;
        ListAsset.DataBind();
        for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
        {
            ListAsset.Items[i].Selected = true;

        }
        Session["AssetContract"] = "";


    }
    protected void buttonadd_click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            #region Find Userid of User who is Requesting to log a call

            #region If User Already Exist
            if (ViewState["UserCreate"].ToString() == "Exist")
            {
                objOrganization = objOrganization.Get_Organization();
                ObjUserLogin = ObjUserLogin.Get_UserLogin_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
                if (ObjUserLogin.Userid != 0)
                {
                    requesterid = ObjUserLogin.Userid;
                }
            }
            #endregion
            #region If New User is to be Created
            else if (ViewState["UserCreate"].ToString() == "create")
            {
                string varEmail = "";
                string varRoleName = Resources.MessageResource.BasicUserRole.ToString();
                if (txtEmail.Text == "")
                {
                    varEmail = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                }
                else
                {
                    varEmail = txtEmail.Text;
                }


                int roleid = objRole.Get_By_RoleName(varRoleName);
                int status;
                objOrganization = objOrganization.Get_Organization();

                objuser.Username = txtUsername.Text.ToString();
                objuser.Password = Resources.MessageResource.strDefaultPassword.ToString();
                objuser.Roleid = roleid;
                objuser.Orgid = objOrganization.Orgid;
                objuser.ADEnable = false;
                objuser.Enable = true;
                objuser.Createdatetime = DateTime.Now.ToString();
                status = objuser.Insert();
                if (status == 1)
                {
                    // Create Mstatus field to send in Membership.CreateUser function as Out Variable for creating Membership User database
                    MembershipCreateStatus Mstatus = default(MembershipCreateStatus);
                    // Call Membership.CreateUser function to create Membership user 
                    Membership.CreateUser(txtUsername.Text.ToString().Trim(), Resources.MessageResource.strDefaultPassword.ToString(), varEmail, "Project Name", "Helpdesk", true, out Mstatus);
                    // Call Roles.AddUserToRole Function to Add User To Role
                    Roles.AddUserToRole(txtUsername.Text.ToString().Trim(), varRoleName);
                    // Declare Local Variable Userid to fetch userid of newly created user

                    // Create Object objUserLogin of UserLogin_mst()Class
                    objuser = new UserLogin_mst();
                    // Fetch userid of Newly created user and assign to local variable userid by calling function objUserLogin.Get_By_UserName
                    requesterid = objuser.Get_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
                    // If userid not equal to 0 then we get userid of Newly created user otherwise error Occured

                    ContactInfo_mst objContactInfo = new ContactInfo_mst();
                    objContactInfo.Userid = requesterid;
                    objContactInfo.Emailid = varEmail;
                    objContactInfo.Firstname = txtUsername.Text.ToString();
                    objContactInfo.Lastname = txtUsername.Text.ToString();
                    objContactInfo.Insert();



                }
            }
            #endregion
            #region If User is Not to be Created
            else if (ViewState["UserCreate"].ToString() == "notcreate")
            {
                // FlagUserStatus = false;

            }
            #endregion

            #endregion
            ObjChange.Active = true;

            ObjChange.Statusid = Convert.ToInt32(drpStatus.SelectedValue);
            ObjChange.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
            ObjChange.Subcategoryid = Convert.ToInt32(drpSubcategory.SelectedValue);
            ObjChange.Technician = Convert.ToInt32(drpTechnician.SelectedValue);
            ObjChange.Title = txtTitle.Text;
            ObjChange.Description = txtDescription.Text;
            ObjChange.Createdtime = DateTime.Now.ToString();
            ObjChange.Changetype = Convert.ToInt32(drpchangetype.SelectedValue);
            ObjChange.Approvalstatus = "Send For Approval";
            MembershipUser user = Membership.GetUser();
            string username = user.UserName.ToString();
            objOrganization = objOrganization.Get_Organization();
            ObjUserLogin = ObjUserLogin.Get_UserLogin_By_UserName(username, objOrganization.Orgid);
            int userid = Convert.ToInt32(ObjUserLogin.Userid);
            ObjChange.CreatedByID = userid;
            ObjUserLogin = ObjUserLogin.Get_UserLogin_By_UserName(txtUsername.Text, objOrganization.Orgid);
            ObjChange.Requestedby = ObjUserLogin.Userid;
            ObjChange.Priority = Convert.ToInt32(drpPriority.SelectedValue);
            ObjChange.Insert();
            int changeid = ObjChange.Get_Current_Changeid();
            for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
            {
                if (ListAsset.Items[i].Selected == true)
                {
                    Objincludeaasetchange.Assetid = Convert.ToInt32(ListAsset.Items[i].Value);
                    Objincludeaasetchange.Changeid = changeid;
                    Objincludeaasetchange.Insert();

                }
            }
            ObjProblemToChange.Changeid = changeid;
            ObjProblemToChange.Problemid = Convert.ToInt32(Session["problemid"]);
            ObjProblemToChange.Insert();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close()", "Close();", true);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void ResetControls()
    {
        drpCategory.SelectedValue = "0";
        drpSubcategory.SelectedValue = "0";
        drpTechnician.SelectedValue = "0";
        drpservices.SelectedValue = "0";
        drpPriority.SelectedValue = "0";
        //drpStatus.SelectedValue = "0";
        txtUsername.Text = "";
        txtTitle.Text = "";
        txtDescription.Text = "";
        reqValSubject.Text = "";



    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetControls();
    }
    protected void Showvalues()
    {
        int problemid = Convert.ToInt32(Session["problemid"]);
        ObjProblem = ObjProblem.Get_By_id(problemid);
        drpTechnician.SelectedValue = ObjProblem.Technicianid.ToString();
        drpCategory.SelectedValue = ObjProblem.Categoryid.ToString();
        BindDropSubCategory();
        drpSubcategory.SelectedValue = ObjProblem.Subcategoryid.ToString();
        drpPriority.SelectedValue = ObjProblem.Priorityid.ToString();
        txtTitle.Text = ObjProblem.title.ToString();
        txtDescription.Text = ObjProblem.Description.ToString();
        ObjUserLogin = ObjUserLogin.Get_By_id(ObjProblem.Requesterid);


    }
    protected void lnkopennewwindow_Click(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Session["Categoryid"] = drpCategory.SelectedValue;
            Session["Subcategoryid"] = drpSubcategory.SelectedValue;
            Session["Technician"] = drpTechnician.SelectedValue;
            Session["Title"] = txtTitle.Text;
            Session["Changetype"] = drpchangetype.SelectedValue;




            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('../Contract/AddAsset.aspx','popupwindow','width=600,height=423,left=230,top=300,Scrollbars=yes');", "javascript:window.open('../Contract/AddAsset.aspx','popupwindow1','width=990,height=590,left=230,top=300,Scrollbars=yes');", true);
            string myScript;
            myScript = "<script language=javascript>javascript:window.open('../Contract/AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');</script>";
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
    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            #region Find Userid of User who is Requesting to log a call
            objOrganization = objOrganization.Get_Organization();
            ObjUserLogin = ObjUserLogin.Get_UserLogin_By_UserName(txtUsername.Text.ToString().Trim(), objOrganization.Orgid);
            if (ObjUserLogin.Userid == 0)
            {
                string myScript;
                myScript = "<script language=javascript>function __doPostBack(eventTarget, eventArgument){var theForm = document.forms['aspnetForm'];  if (theForm){  theForm.__EVENTTARGET.value = eventTarget;theForm.__EVENTARGUMENT.value = eventArgument;theForm.submit(); }} var Flag= confirm('User Does not Exist,Do You Want to Create User');if(Flag==true){ __doPostBack('callPostBack', 'create');}if(Flag==false){ __doPostBack('callPostBack', 'notcreate');}</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);

            }
            else { ViewState["UserCreate"] = "Exist"; }

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
}
