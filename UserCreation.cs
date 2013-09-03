using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for UserCreation
/// </summary>
public class UserCreation
{
	public UserCreation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    Organization_mst objOrganization = new Organization_mst();

    public string UserCreate(string UName, string Password, string Company, string city, string roleid,
                              string UserEmailId, string RoleName, string Description, string EmployeeId, string LandLineNo,
                              string MobileNo, string Location, string DepartmentId)
    {
        objOrganization = objOrganization.Get_Organization();
        //Declare Local Variables - Flag,varRolename,FlagMembership
        int Flag;
        string varRoleName;
        bool FlagMembership;
        // Use Asp.Net Membership Validator Control Membership.ValidateUser to check User Exist in aspnet Database 
        FlagMembership = Membership.ValidateUser(UName, Password);

        //  Create Object of UserLogin_mst Class to Check User Exist in Database UserLogin_mst table 
        UserLogin_mst objUserLogin = new UserLogin_mst();
        //  Declare local Variable Flag to Check Status User Exist in databse
        Flag = objUserLogin.Get_By_UserName(UName, objOrganization.Orgid);
        //  If User Does'nt exist in Database and in aspnet databse then flag value will 0 and FlagMembership value will be False
        if (Flag == 0 && FlagMembership == false)
        {
            // Declare status local variable
            int status;
            // Create Object objUserLogin of UserLogin_mst() Class to insert record in table
            objUserLogin = new UserLogin_mst();
            objUserLogin.Username = UName;
            objUserLogin.Password = Password;
            objUserLogin.Company = Company;
            objUserLogin.City = city;
            objUserLogin.Roleid = Convert.ToInt32(roleid);
            objUserLogin.Orgid = objOrganization.Orgid;
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
                if (UserEmailId != "")
                {
                    varEmail = UserEmailId.Trim();
                }
                // Else Assign value define in MessagesResources.resx file in errMemshipCreateUserEmail field
                else
                {
                    varEmail = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                }
                // Assign selected text from droprole down to  local variable field varRoleName
                varRoleName = RoleName.Trim();
                // Create Mstatus field to send in Membership.CreateUser function as Out Variable for creating Membership User database
                MembershipCreateStatus Mstatus = default(MembershipCreateStatus);
                // Call Membership.CreateUser function to create Membership user 

                Membership.CreateUser(UName.Trim(), Password.Trim(), varEmail, "Project Name", "Helpdesk", true, out Mstatus);
                // Call Roles.AddUserToRole Function to Add User To Role
                Roles.AddUserToRole(UName.Trim(), varRoleName);
                // Declare Local Variable Userid to fetch userid of newly created user
                int userid;
                // Create Object objUserLogin of UserLogin_mst()Class
                objUserLogin = new UserLogin_mst();
                // Fetch userid of Newly created user and assign to local variable userid by calling function objUserLogin.Get_By_UserName
                userid = objUserLogin.Get_By_UserName(UName.Trim(), objOrganization.Orgid);
                // If userid not equal to 0 then we get userid of Newly created user otherwise error Occured
                UserToSiteMapping objusertositemapping = new UserToSiteMapping();
                if (userid != 0)
                {
                    // Create Object objContactInfo of ContactInfo_mst class to Store User Contact Information in Contact_info table
                    ContactInfo_mst objContactInfo = new ContactInfo_mst();
                    objContactInfo.Userid = userid;
                    objContactInfo.Firstname = UName.Trim();
                    objContactInfo.Lastname = UName.Trim();
                    objContactInfo.Description = Description;
                    objContactInfo.Empid = EmployeeId;
                    objContactInfo.Emailid = UserEmailId;
                    objContactInfo.Landline = LandLineNo;
                    objContactInfo.Mobile = MobileNo;
                    objContactInfo.Siteid = Convert.ToInt32(Location);

                    //if (DrpDepartment.SelectedItem.ToString() != null)
                    //{
                    objContactInfo.Deptid = Convert.ToInt32(DepartmentId);
                    //}

                    // Call objContactInfo.Insert function to Insert record in Contact_info table
                    objContactInfo.Insert();
                    // Show Message Operation perform successfully
                    //lblMessage.Text = Resources.MessageResource.errDataSave.ToString();
                    // Calling Function Clear() to Clear all controls on Form
                    objusertositemapping.Userid = userid;
                    objusertositemapping.Siteid = Convert.ToInt32(Location);
                    objusertositemapping.Insert();
                    return "Created";
                }
                else
                {
                    return "Error";
                }

            }
            else
            {
                return "Error";
            }

        }
        else
        {
            return "Already Exist";
        }
    }
}
