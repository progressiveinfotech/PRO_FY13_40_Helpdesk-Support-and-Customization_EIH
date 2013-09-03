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




public partial class admin_AddUser : System.Web.UI.Page
{
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    Organization_mst objOrganization = new Organization_mst();
    // Created on  - 8 Jan 2010
    // Created by  -Sumit Gupta
    // Description -To Create Users in the Organization
    protected void Page_Load(object sender, EventArgs e)
    {
      
        
        if(! IsPostBack )
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            // Start 
            reqValUsername.ErrorMessage = Resources.MessageResource.errUserName.ToString();
            reqValPassword.ErrorMessage = Resources.MessageResource.errPassword.ToString();
            reqValtxtFname.ErrorMessage = Resources.MessageResource.errFstName.ToString();
            reqValtxtLname.ErrorMessage = Resources.MessageResource.errLstName.ToString();
            reqValtxtRetypePassword.ErrorMessage = Resources.MessageResource.errRePassword.ToString();
            cmpPassw.ErrorMessage = Resources.MessageResource.errCmpPassword.ToString();
            reqValdropRole.ErrorMessage = Resources.MessageResource.errDrpRole.ToString();
            regxtxtPassword.ErrorMessage = Resources.MessageResource.errRegexpPass.ToString();
            // End 
            
            // Functions BinddropRole() and  BindDrpOrg() to fill dropdown droprole and dropOrg at page Load
            // Start
               BinddropRole();
               //BindDrpOrg();
            // End.
               BindDropCustomer();
            BindDrpsite();
            BindDrpDepartment();
        }
    }
    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";


    }

   protected void btnSave_Click(object sender, EventArgs e)
    {
        // Save User to Database on Button Save click Event
        // Start
        objOrganization = objOrganization.Get_Organization();
            //Declare Local Variables - Flag,varRolename,FlagMembership
              int Flag;
              string varRoleName;
              bool FlagMembership;
              // Use Asp.Net Membership Validator Control Membership.ValidateUser to check User Exist in aspnet Database 
                 FlagMembership = Membership.ValidateUser(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());
              
             //  Create Object of UserLogin_mst Class to Check User Exist in Database UserLogin_mst table 
                  UserLogin_mst objUserLogin = new UserLogin_mst();
             //  Declare local Variable Flag to Check Status User Exist in databse
                  Flag = objUserLogin.Get_By_UserName(txtUserName.Text.ToString().Trim(), objOrganization.Orgid );
             //  If User Does'nt exist in Database and in aspnet databse then flag value will 0 and FlagMembership value will be False
                 if (Flag == 0 && FlagMembership==false)
                {
                    // Declare status local variable
                    int status;
                    // Create Object objUserLogin of UserLogin_mst() Class to insert record in table
                    objUserLogin = new UserLogin_mst();
                    objUserLogin.Username = txtUserName.Text.ToString().Trim();
                    objUserLogin.Password = txtPassword.Text.ToString().Trim();
                    objUserLogin.Company = txtCompany.Text.ToString().Trim();
                    objUserLogin.City = txtCity.Text.ToString().Trim();
                    objUserLogin.Roleid = Convert.ToInt32(dropRole.SelectedValue);
                    objUserLogin.Orgid = objOrganization.Orgid ;                    
                    objUserLogin.ADEnable = false;
                    objUserLogin.Enable = true;
                    objUserLogin.Createdatetime = DateTime.Now.ToString();
                    // Call Insert function to insert record in UserLogin_mst table
                    // Check status whether Record inserted Successfully or Not,If status=1 then Success otherwise Operation Fail
                       status = objUserLogin.Insert();
                       if (status == 1)
                       {
                           // Declare local variable varEmail to fetch email of user from textbox
                              string varEmail;
                           //If Email field is Not Empty then Assign value to varEmail Local Variable
                           if (txtEmailId.Text != "")
                           {
                               varEmail = txtEmailId.Text.Trim();
                           }
                           // Else Assign value define in MessagesResources.resx file in errMemshipCreateUserEmail field
                           else
                           {
                               varEmail = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                           }
                           // Assign selected text from droprole down to  local variable field varRoleName
                              varRoleName = dropRole.SelectedItem.Text.ToString().Trim();
                           // Create Mstatus field to send in Membership.CreateUser function as Out Variable for creating Membership User database
                              MembershipCreateStatus Mstatus = default(MembershipCreateStatus);
                              // Call Membership.CreateUser function to create Membership user 
                                 Membership.CreateUser(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim(), varEmail, "Project Name", "Helpdesk", true, out Mstatus);
                                // Call Roles.AddUserToRole Function to Add User To Role
                                Roles.AddUserToRole(txtUserName.Text.ToString().Trim(), varRoleName);
                                // Declare Local Variable Userid to fetch userid of newly created user
                                int userid;
                                // Create Object objUserLogin of UserLogin_mst()Class
                                  objUserLogin = new UserLogin_mst();
                                  // Fetch userid of Newly created user and assign to local variable userid by calling function objUserLogin.Get_By_UserName
                                  userid = objUserLogin.Get_By_UserName(txtUserName.Text.ToString().Trim(), objOrganization.Orgid );
                                  // If userid not equal to 0 then we get userid of Newly created user otherwise error Occured
                                    UserToSiteMapping objusertositemapping = new UserToSiteMapping();
                                    if (userid != 0)
                                    {
                                        // Create Object objContactInfo of ContactInfo_mst class to Store User Contact Information in Contact_info table
                                        ContactInfo_mst objContactInfo = new ContactInfo_mst();
                                        objContactInfo.Userid = userid;
                                        objContactInfo.Firstname = txtFname.Text.ToString().Trim();
                                        objContactInfo.Lastname = txtLname.Text.ToString().Trim();
                                        objContactInfo.Description = txtDesc.Text.ToString().Trim();
                                        objContactInfo.Empid = txtEmpId.Text;
                                        objContactInfo.Emailid = txtEmailId.Text.ToString().Trim();
                                        objContactInfo.Landline = txtLandline.Text.ToString().Trim();
                                        objContactInfo.Mobile = txtMobile.Text.ToString().Trim();
                                        objContactInfo.Siteid = Convert.ToInt32(DrpSite.SelectedValue);
                                        
                                        //if (DrpDepartment.SelectedItem.ToString() != null)
                                        //{
                                            objContactInfo.Deptid = Convert.ToInt32(DrpDepartment.SelectedValue);
                                        //}

                                        // Call objContactInfo.Insert function to Insert record in Contact_info table
                                        objContactInfo.Insert();
                                        // Show Message Operation perform successfully
                                           //lblMessage.Text = Resources.MessageResource.errDataSave.ToString();
                                        // Calling Function Clear() to Clear all controls on Form
                                           objusertositemapping.Userid = userid;
                                           objusertositemapping.Siteid = Convert.ToInt32(DrpSite.SelectedValue);
                                           objusertositemapping.Insert();
                                          Clear();
                                          Response.Redirect("~/admin/ViewUser.aspx");

                                    }
                                    else 
                                    {
                                        // Show Message Error Occured due to some Reason
                                        lblMessage.Text = Resources.MessageResource.errOccured.ToString();
                                    }

                       }
                       else 
                       {
                           // Show Message Error Occured due to some Reason
                           lblMessage.Text = Resources.MessageResource.errOccured.ToString();
                       }

               }
              else 
               {
                   // Show Message User Already Exist
                lblMessage.Text = Resources.MessageResource.errUserExist.ToString();
            
               }
           

       
       // End Save button Click

        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        // To Clear All Controls on Form by Calling Clear() function
        lblMessage.Text = "";
        Clear();
    }
    // Define Clear() function to Clear all COntrols on Form
    public void Clear()
    {
        txtFname.Text = "";
        txtLname.Text = "";
        txtDesc.Text = "";
        txtEmpId.Text = "";
        txtEmailId.Text = "";
        txtLandline.Text = "";
        txtMobile.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        dropRole.SelectedValue = "0";
        DrpDepartment.SelectedValue = "0";
        //DrpOrg.SelectedValue = "0";
        DrpSite.SelectedValue = "0";
       
    
    
    }
    // Define Function BinddropRole to Bind DropDown Role 
    public void BinddropRole()
    {
        // Declare col as Collection of RoleInfo_mst Object to get all records from table 
        BLLCollection<RoleInfo_mst> col = new BLLCollection<RoleInfo_mst>();
        // declare object objRole of RoleInfo_mst Class to call function Get_All() to fetch all records from database
        RoleInfo_mst objRole = new RoleInfo_mst();
        // Assign all records to variable col 
            col = objRole.Get_All();
            dropRole.DataTextField = "rolename";
            dropRole.DataValueField = "roleid";
            dropRole.DataSource = col;
            dropRole.DataBind();
        // Declare item as listItem to assign default value to drop down
            ListItem item = new ListItem();
            item.Text = "--------------Select---------------";
            item.Value = "0";
            dropRole.Items.Add(item);
            dropRole.SelectedValue = "0";
          
    }
    // Define Function BindDrpOrg to Bind DropDown Organization 
  //public void BindDrpOrg()
  //  {
  //      // Declare col as Collection of Organization_mst Object to get all records from table 
  //     BLLCollection<Organization_mst> col = new BLLCollection<Organization_mst>();
  //      // declare object objOrganization of Organization_mst Class to call function Get_All() to fetch all records from database
  //     Organization_mst objOrganization = new Organization_mst();
  //      // Assign all records to variable col 
  //      col = objOrganization.Get_All();
  //      DrpOrg.DataTextField = "orgname";
  //      DrpOrg.DataValueField = "orgid";
  //      DrpOrg.DataSource = col;
  //      DrpOrg.DataBind();
       
    
  //  }
  protected void lnkbtnBack_Click(object sender, EventArgs e)
  {
      // On Click Back Button redirect to page AddSite.aspx
      Response.Redirect("~/admin/AddSite.aspx");
  }
    public void BindDrpsite()
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid = Convert.ToInt32(drpCustomer.SelectedValue);
        Site_mst ObjSite = new Site_mst();
        col = ObjSite.Get_All();
        foreach (Site_mst obj in col)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colSite1.Add(obj);

            }
        }
        DrpSite.DataTextField = "sitename";
        DrpSite.DataValueField = "siteid";
        DrpSite.DataSource = colSite1;
        DrpSite.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        DrpSite.Items.Add(item);
        DrpSite.SelectedValue = "0";

    }

    public void BindDrpDepartment()
    {
        BLLCollection<Department_mst> col = new BLLCollection<Department_mst>();
        Department_mst Objdepartment = new Department_mst();
        int Selectedsiteval = Convert.ToInt32(DrpSite.SelectedValue);
        if (Selectedsiteval==0)
        {
            DrpDepartment.DataSource = col;
            DrpDepartment.DataBind();
            ListItem item = new ListItem();
            item.Text = "--------------Select---------------";
            item.Value = "0";
            DrpDepartment.Items.Add(item);
            DrpDepartment.SelectedValue = "0";
         }
          else
         {
             col = Objdepartment.Get_All_By_SiteId(Selectedsiteval);

             DrpDepartment.DataTextField = "departmentName";
             DrpDepartment.DataValueField = "deptid";
             DrpDepartment.DataSource = col;
             DrpDepartment.DataBind();
             ListItem item = new ListItem();
             item.Text = Resources.MessageResource.errSelectDept.ToString();
             item.Value = "0";
             DrpDepartment.Items.Add(item);
             DrpDepartment.SelectedValue = "0";
        }
       
        
      

    }

    protected void Drpsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["password"] = txtPassword.Text;
        Session["Repassword"] = txtRetypePassword.Text;
        BindDrpDepartment();
        txtPassword.Attributes.Add("value", Session["password"].ToString());
        txtRetypePassword.Attributes.Add("value", Session["Repassword"].ToString());
    }
    protected void lnkViewUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/ViewUser.aspx");
    }
    
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["password"] = txtPassword.Text;
        Session["Repassword"] = txtRetypePassword.Text;
        BindDrpsite();
        txtPassword.Attributes.Add("value", Session["password"].ToString());
        txtRetypePassword.Attributes.Add("value", Session["Repassword"].ToString());
    }
}
