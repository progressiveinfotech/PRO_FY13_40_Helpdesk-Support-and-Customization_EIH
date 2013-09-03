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

public partial class admin_EditUser : System.Web.UI.Page
{
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    ContactInfo_mst ObjContactInfo = new ContactInfo_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    Organization_mst objOrganization = new Organization_mst();
    BLLCollection<CustomerToSiteMapping> colCustToSite = new BLLCollection<CustomerToSiteMapping>();
    BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValUsername.ErrorMessage = Resources.MessageResource.errUserName.ToString();
            
            reqValPassword.ErrorMessage = Resources.MessageResource.errPassword.ToString();
            
            reqValtxtFname.ErrorMessage = Resources.MessageResource.errFstName.ToString();
            reqValtxtLname.ErrorMessage = Resources.MessageResource.errLstName.ToString();
            reqValtxtRetypePassword.ErrorMessage = Resources.MessageResource.errRePassword.ToString();
            cmpPassw.ErrorMessage = Resources.MessageResource.errCmpPassword.ToString();
            reqValdropRole.ErrorMessage = Resources.MessageResource.errDrpRole.ToString();
            regxtxtPassword.ErrorMessage = Resources.MessageResource.errRegexpPass.ToString();
            //BindDrpOrg();
            BindDropCustomer();
           BindDropCompany();
            BindDropCity();
            BinddropRole();
            UpdateUser();
            //BindDropCompany();
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
    public void BindDropCompany()
    {
        //col = ObjUserLogin.Get_All();
        //DrpCompany.DataTextField = "Company";
        //DrpCompany.DataValueField = "Company";
        //DrpCompany.DataSource = col;
        //DrpCompany.DataBind();
        //ListItem item = new ListItem();
        //item.Text = "--------------Select---------------";
        //item.Value = "0";
        //DrpCompany.Items.Add(item);
        //DrpCompany.SelectedValue = "0";


    }
    public void BindDropCity()
    {
                //col = ObjUserLogin.Get_All();
        //DrpCity.DataTextField = "City";
        //DrpCity.DataValueField = "City";
        //DrpCity.DataSource = col;
        //for (int i = 0; i < col.Count; i++)
        //{
        //    if (col[i].City!= null)
        //    { 
            
        //    }
        //}


        //DrpCity.DataBind();
        //ListItem item = new ListItem();
        //item.Text = "--------------Select---------------";
        //item.Value = "0";
        //DrpCity.Items.Add(item);
        //DrpCity.SelectedValue = "0";


    }
    protected void UpdateUser()
    {
        int Custid = 0;
        int userid = Convert.ToInt32(Request.QueryString[0]);
        ObjUserLogin = ObjUserLogin.Get_By_id(userid);
        ObjContactInfo = ObjContactInfo.Get_By_id(userid);
        
            if (ObjUserLogin.Userid != 0 && ObjContactInfo.Userid != 0)
            {
                txtUserName.Text = ObjUserLogin.Username.ToString().Trim();
                txtPassword.Attributes.Add("value", ObjUserLogin.Password.ToString());
                if (ObjUserLogin.City != null)
                {
                    txtCity.Text = ObjUserLogin.City.ToString().Trim();
                }
                
                if (ObjUserLogin.Company != null)
                {
               
                    txtCompany.Text = ObjUserLogin.Company.ToString().Trim();
                }
                
                txtRetypePassword.Attributes.Add("value", ObjUserLogin.Password.ToString());
                dropRole.SelectedValue = ObjUserLogin.Roleid.ToString().Trim();

                ViewState["Roleid"] = ObjUserLogin.Roleid;
                if (ObjUserLogin.ADEnable == true)
                {
                    lblAdUser.Text = "Yes";
                }
                else
                {
                    lblAdUser.Text = "No";
                }
                txtFname.Text = ObjContactInfo.Firstname.ToString().Trim();
                txtLname.Text = ObjContactInfo.Lastname.ToString().Trim();
                if (ObjContactInfo.Landline != null)
                {
                    txtLandline.Text = ObjContactInfo.Landline.ToString().Trim();
                }
                if (ObjContactInfo.Emailid != null)
                {
                    txtEmailId.Text = ObjContactInfo.Emailid.ToString().Trim();
                }
                if (ObjContactInfo.Empid != null)
                {
                    txtEmpId.Text = ObjContactInfo.Empid.ToString().Trim();
                }
                if (ObjContactInfo.Emailid != null)
                {
                    txtEmailId.Text = ObjContactInfo.Emailid.ToString();
                }
                if (ObjContactInfo.Mobile != null)
                {
                    txtMobile.Text = ObjContactInfo.Mobile.ToString();
                }
                if (ObjContactInfo.Description != null)
                {
                    txtDesc.Text = ObjContactInfo.Description.ToString();
                }
               

                colCustToSite = objCustToSite.Get_All_By_siteid(ObjContactInfo.Siteid);
                foreach (CustomerToSiteMapping obj in colCustToSite)
                {
                    Custid = obj.Custid;

                }
                ViewState["CustId"] = Custid;
                drpCustomer.SelectedValue = Convert.ToString(Custid);


                BindDrpsite();
                DrpSite.SelectedValue = ObjContactInfo.Siteid.ToString();
                //DrpOrg.SelectedValue = ObjUserLogin.Orgid.ToString();
                BindDrpDepartment();
                DrpDepartment.SelectedValue = ObjContactInfo.Deptid.ToString();

                if (ObjUserLogin.Enable == true)
                { DropEnable.SelectedValue = "1"; }
                else { DropEnable.SelectedValue = "0"; }
            }
        }
    
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
        item.Text = Resources.MessageResource.errSelectRole.ToString();
        item.Value = "0";
        dropRole.Items.Add(item);
        dropRole.SelectedValue = "0";
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
        item.Text = Resources.MessageResource.errselectste.ToString();
        item.Value = "0";
        DrpSite.Items.Add(item);
        //DrpSite.SelectedValue = "0";
    }

    public void BindDrpDepartment()
    {
        BLLCollection<Department_mst> col = new BLLCollection<Department_mst>();
        Department_mst Objdepartment = new Department_mst();
        int Selectedsiteval = Convert.ToInt32(DrpSite.SelectedValue);
        col = Objdepartment.Get_All_By_SiteId(Selectedsiteval);
        DrpDepartment.DataTextField = "departmentName";
        DrpDepartment.DataValueField = "deptid";

        DrpDepartment.DataSource = col;
        DrpDepartment.DataBind();
        ListItem item=new ListItem();
        item.Text = Resources.MessageResource.errSelectDept.ToString();
        item.Value = "0";
        DrpDepartment.Items.Add(item);
    }
    

    protected void DrpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDrpDepartment();
    }

    //public void BindDrpOrg()
    //{
    //    BLLCollection<Organization_mst> col = new BLLCollection<Organization_mst>();
    //    Organization_mst ObjOrganization = new Organization_mst();
    //    col = ObjOrganization.Get_All();
    //    DrpOrg.DataTextField = "Orgname";
    //    DrpOrg.DataValueField = "orgid";
    //    DrpOrg.DataSource = col;
    //    DrpOrg.DataBind();
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objOrganization = objOrganization.Get_Organization();
        int FlagStatus, FlagStatus1;
        int userid = Convert.ToInt32(Request.QueryString[0]);
        ObjUserLogin.Userid = userid;
        ObjUserLogin.Roleid = Convert.ToInt32(dropRole.SelectedValue.ToString());
        if (lblAdUser.Text.ToString().Trim() == "Yes")
        {
            ObjUserLogin.ADEnable=true ; 
        }
        else 
        { 
            ObjUserLogin.ADEnable = false; 
        }
        if (DropEnable.SelectedValue == "1")
        { 
            ObjUserLogin.Enable = true; 
        }
        else 
        { 
            ObjUserLogin.Enable = false; 
        }
        ObjUserLogin.Orgid = objOrganization.Orgid ;
        ObjUserLogin.Username = txtUserName.Text.ToString().Trim();
        ObjUserLogin.Password = txtPassword.Text.ToString().Trim();
        ObjUserLogin.Company = txtCompany.Text.ToString().Trim();
        ObjUserLogin.City = txtCity.Text.ToString().Trim();
        ObjContactInfo.Firstname = txtFname.Text.ToString().Trim();
        ObjContactInfo.Lastname = txtLname.Text.ToString().Trim();
        ObjContactInfo.Mobile = txtMobile.Text.ToString().Trim();
        ObjContactInfo.Landline = txtLandline.Text.ToString().Trim();
        ObjContactInfo.Empid = txtEmpId.Text.ToString().Trim();
        ObjContactInfo.Siteid = Convert.ToInt32(DrpSite.SelectedValue.ToString());
         ObjContactInfo.Deptid = Convert.ToInt32(DrpDepartment.SelectedValue.ToString());
        ObjContactInfo.Emailid = txtEmailId.Text.ToString().Trim();
        ObjContactInfo.Description = txtDesc.Text.ToString().Trim();
        ObjContactInfo.Userid = userid;
        FlagStatus = ObjUserLogin.Update();
        FlagStatus1 = ObjContactInfo.Update();
        RoleInfo_mst objR = new RoleInfo_mst();
        int roleid = Convert.ToInt32(ViewState["Roleid"].ToString());
        objR = objRole.Get_By_id(roleid);

        if (objR.Roleid!=0)
        {
            Roles.RemoveUserFromRole(txtUserName.Text.ToString().Trim(), objR.Rolename);
            Roles.AddUserToRole(txtUserName.Text.ToString().Trim(), dropRole.SelectedItem.Text.ToString().Trim());
        }
        if (FlagStatus == 1 && FlagStatus1 == 1)
        {
            // Redirect to page ViewSite.aspx page after successfully Updation
                Response.Redirect("~/admin/ViewUser.aspx");
        }
        else
        {
             //If Updation is not successfully,Display Error Message
             //lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString().Trim();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/ViewUser.aspx");
    }
}