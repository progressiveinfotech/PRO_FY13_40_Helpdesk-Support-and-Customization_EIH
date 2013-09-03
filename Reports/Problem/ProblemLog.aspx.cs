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

public partial class Problem_ProblemLog : System.Web.UI.Page
{
    Subcategory_mst objSubCategory = new Subcategory_mst();
    Priority_mst objPriority = new Priority_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    Category_mst objCategory = new Category_mst();
    Status_mst objStatus = new Status_mst();
    Problem_mst ObjProblem = new Problem_mst();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objuser = new UserLogin_mst();
    ProblemHistory ObjProblemHistory = new ProblemHistory();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<Status_mst> colStatus = new BLLCollection<Status_mst>();
    Service_mst objService = new Service_mst();
    BLLCollection<Service_mst> colService = new BLLCollection<Service_mst>();
    SentMailToUser objSentMailToUser = new SentMailToUser();
    public int requesterid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropStatus();
            BindDropCategory();
            BindDropSubCategory();
            BindDropTechnician();
            BindDropPriority();
            //BindDropService();
           
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
    protected void BindDropStatus()
    {
        colStatus = objStatus.Get_All_By_OpenStatus();
        drpStatus.DataTextField = "statusname";
        drpStatus.DataValueField = "statusid";
        drpStatus.DataSource = colStatus;
        drpStatus.DataBind();

    }
    //protected void BindDropService()
    //{
    //    colService = objService.Get_All();
    //    drpservices.DataTextField = "servicename";
    //    drpservices.DataValueField = "serviceid";
    //    drpservices.DataSource = colService;
    //    drpservices.DataBind();
    //    ListItem item = new ListItem();
    //    item.Text = "-------Select Services------";
    //    item.Value = "0";
    //    drpservices.Items.Add(item);
    //    drpservices.SelectedValue = "0";
    
    
    //}
    
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
    protected void BindDropTechnician()
    {
        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        int roleid=Convert.ToInt32(objRole.Roleid);
        coltechnician = ObjUserLogin.Get_All_By_Role(roleid);
        drpTechnician.DataTextField = "username";
        drpTechnician.DataValueField = "userid";
        drpTechnician.DataSource = coltechnician;
        drpTechnician.DataBind();
        ListItem item = new ListItem();
        item.Text = "---Select Technician---";
        item.Value = "0";
        drpTechnician.Items.Add(item);
        drpTechnician.SelectedValue="0";

        
  
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
    protected void txtUsername_TextChanged(object sender, EventArgs e)
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
        else { 
            
            ViewState["UserCreate"] = "Exist";
            ContactInfo_mst objCont = new ContactInfo_mst();
            objCont = objCont.Get_By_id(ObjUserLogin.Userid);
            txtEmail.Text = objCont.Emailid;
        
        }

        #endregion

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool FlagUserStatus=true ;
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
            {                 string varEmail ="";
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
                if (status==1)
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
                FlagUserStatus = false;

            }
            #endregion

            #endregion
       
        MembershipUser User = Membership.GetUser();
        string userName;
        userName = User.UserName.ToString();
        if (FlagUserStatus == true)
        { 

        objOrganization = objOrganization.Get_Organization();
        objuser = objuser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
        ObjProblem.CreatedByid = objuser.Userid;
        ObjProblem.Requesterid = requesterid;
        ObjProblem.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
        ObjProblem.Subcategoryid = Convert.ToInt32(drpSubcategory.SelectedValue);

        ObjProblem.Priorityid = Convert.ToInt32(drpPriority.SelectedValue);
        ObjProblem.Statusid = Convert.ToInt32(drpStatus.SelectedValue);
        ObjProblem.Technicianid = Convert.ToInt32(drpTechnician.SelectedValue);
        ObjProblem.title = txtTitle.Text;
        ObjProblem.Description = txtDescription.Text;
        if (Convert.ToInt32(drpTechnician.SelectedValue) != 0)
        {
        ObjProblem.AssginedTime = DateTime.Now.ToString();
        }

        ObjProblem.Insert();
        int problemid = ObjProblem.Get_Current_Problemid();

        ObjProblemHistory.Operationtime = DateTime.Now.ToString();
        ObjProblemHistory.Problemid = problemid;
        ObjProblemHistory.Operation = "create";
        ObjProblemHistory.Operationownerid = objuser.Userid;
        if (Convert.ToInt32(drpTechnician.SelectedValue) != 0)
        {
        objSentMailToUser.SentMailToTechnicianForProblemCall(problemid, Convert.ToInt32(drpTechnician.SelectedValue));

        }

        ObjProblemHistory.Insert();



        ResetControls();

     
        Response.Redirect("~/Problem/EditProblem.aspx?" + problemid + " ");
        }
      
}
    protected void ResetControls()
    {
        drpCategory.SelectedValue = "0";
        drpSubcategory.SelectedValue = "0";
        drpTechnician.SelectedValue = "0";
      
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

    }

