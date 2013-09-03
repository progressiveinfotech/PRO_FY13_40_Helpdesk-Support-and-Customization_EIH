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
using System.DirectoryServices;
using System.IO;

public partial class admin_ImportUserAD : System.Web.UI.Page
{
    //Created by-Sumit Gupta
    //Created on-13 Jan 2010
    //Purpose - Import Users from Domain and stored in Database

    // Create Variable Object of  Classes and used later
    UserLogin_mst objUserLogin = new UserLogin_mst();
    Organization_mst objOrg = new Organization_mst();
    RoleInfo_mst objRoleInfo = new RoleInfo_mst();
    ContactInfo_mst objContactInfo = new ContactInfo_mst();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void LogMessage(string sMsg)
    {
        File.AppendAllText(@"C:\ScheduledService_ADUser.log", sMsg + Environment.NewLine);
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            string varObjDomainName;
            string Username = "";
            string Password = "";
            Username = txtUserName.Text;
            Password = txtPassword.Text;
            //Assign domain name to variable varDomainName and varObjDomainName
            varObjDomainName = txtDomainName.Text.ToString().Trim();
            //Create object de of Directory Entry Class
            //DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}/ou=Mahim;dc=HTmedia;dc=net", varObjDomainName));
            //DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}", varObjDomainName)); Commented by lalit 
            //To Get AD users from OU

            string A = "Maidens Hotel, Delhi";
            
             string B=@"LDAP://oberoigroup.com/ou='Maidens Hotel\, Delhi';dc=Oberoigroup;dc=com";
            
            DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}/ou='"+A+"';dc=Oberoigroup;dc=com", varObjDomainName));
            //DirectoryEntry myDirectoryEntry = new DirectoryEntry("LDAP://" + varObjDomainName);
            myDirectoryEntry.Username = Username;
            myDirectoryEntry.Password = Password;
          //  DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}/ou=Sur;ou=apc;dc=Terex;dc=local",varObjDomainName));
            // Create object mySearcher of DirectorySearcher Class 
            DirectorySearcher mySearcher = new DirectorySearcher(myDirectoryEntry);
            mySearcher.SearchScope = SearchScope.Subtree;
             //mySearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
            // mySearcher.Filter = ("(objectCategory=person)");
            //mySearcher.Filter = ("(objectCategory=user)"); Commented by lalit Now we are getting All users
            // mySearcher.Filter = "(objectClass=person)";
            // Create Local Variable OrganizationId to get organization id
            int OrganizationId;
            // Call Function Get_Organization() to get the object of Organization_mst
            objOrg = objOrg.Get_Organization();
            // Assign Organization id to variable OrganizationId
            OrganizationId = objOrg.Orgid;
            //  Create Localvariable varRoleName get role form Gloabl Resource File MessageResource and later assign to user when user import to database
            string varRoleName = Resources.MessageResource.BasicUserRole.ToString();
            //  Assign roleid to local variable varRoleid by calling function Get_By_RoleName
            int varRoleid = objRoleInfo.Get_By_RoleName(varRoleName);
            //  Create Local Variable  FlagSave and FlagUserExist to check status of save and user Exist
            int FlagSave = 0;
            int FlagUserExist = 0;
            int count = 0;
            int count1 = 0;
            LogMessage("Total AD users of this Site" + mySearcher.FindAll().Count);
            foreach (SearchResult result in mySearcher.FindAll())
            {
                count++;
                count1 = result.Properties.Count;
                string LogMessageString=Convert.ToBoolean(result.Properties["sAMAccountName"].Count > 0) ? result.Properties["sAMAccountName"][0].ToString() : "";
               
                try
                {
                    //if (!String.IsNullOrEmpty(result.Properties["Mail"][0].ToString())
                    //    && System.Text.RegularExpressions.Regex.IsMatch(result.Properties["DisplayName"][0].ToString(), " |admin|test|service|system|[$]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)                                         )
                    //{
                    string SAMAccountName = Convert.ToBoolean(result.Properties["sAMAccountName"].Count > 0) ? result.Properties["sAMAccountName"][0].ToString() : "";
                    string DisplayName = Convert.ToBoolean(result.Properties["displayName"].Count > 0) ? result.Properties["displayName"][0].ToString() : "";
                    string mail = Convert.ToBoolean(result.Properties["mail"].Count > 0) ? result.Properties["mail"][0].ToString() : "";
                    string company = Convert.ToBoolean(result.Properties["company"].Count > 0) ? result.Properties["company"][0].ToString() : "";
                    string Site = Convert.ToBoolean(result.Properties["L"].Count > 0) ? result.Properties["L"][0].ToString() : "";
                    // Create loccal variable FlagStatus,varUsername 
                    int FlagStatus;
                    string varUserName;
                    string varCompany;
                    string varSite;
                   // varCompany = objUserLogin.Company;
                    varCompany = company;
                    //varSite = objUserLogin.Site;
                    varSite = Site;
                    // Assign username to variable varUserName
                    varUserName = SAMAccountName.ToString().Trim();
                    
                    //  Declare local Variable Flag to Check Status User Exist in databse
                    FlagStatus = objUserLogin.Get_By_UserName(varUserName, OrganizationId);
                    // If variable FlagStatus is zero  then User does not exist in database
                    if (FlagStatus == 0)
                    {
                        // Create local variable FlagInsertStatus to check insert status of function 
                        int FlagInsertStatus;
                        // Create local variable VarPassword to get passowrd which is generated using function GeneratePassword()
                        string VarPassword = Membership.GeneratePassword(8, 2);
                        objUserLogin.ADEnable = true;
                        objUserLogin.Createdatetime = DateTime.Now.ToString();
                        objUserLogin.Enable = true;
                        objUserLogin.Orgid = OrganizationId;
                        objUserLogin.Password = VarPassword;
                        objUserLogin.Username = varUserName;
                        objUserLogin.Roleid = varRoleid;
                        objUserLogin.DomainName = varObjDomainName;
                        objUserLogin.Company = varCompany;
                        objUserLogin.City = varSite;
                        // Call function objUserLogin.Insert to insert user data to UserLogin_mst table and assign  status in FlagInsertStatus variable
                        
                            FlagInsertStatus = objUserLogin.Insert();
                        
                        // If FlagInsertStatus is 1 then Insert operation is Success
                        if (FlagInsertStatus == 1)
                        {
                            // Create local variable UserId,varFirstName,varLastName,varFullname,arraycount,FlagContactInfo
                            int UserId;
                            string varFirstName = "";
                            string varLastName = "";
                            string[] varFullName;
                            int arraycount;
                            int FlagContactInfo;
                            // Assign Display Name to variable varFullname to get firstname and last name by calling split function
                            varFullName = DisplayName.Split(' ');
                            //Assign  the number of variables in array varFullName to arraycount  ,to check how many elements in varFullName array
                            arraycount = varFullName.Count();
                            varFirstName = varFullName[0].ToString().Trim();
                            // if arraycount is greater than one,than there is more than one values in array varFullName ie it also contain lastname value
                            if (arraycount > 1)
                            {
                                // lastname assign to variable varLastName 
                                varLastName = varFullName[1].ToString().Trim();
                            }
                            // Fetch userid of Newly created user and assign to local variable userid by calling function objUserLogin.Get_By_UserName
                            UserId = objUserLogin.Get_By_UserName(varUserName.ToString().Trim(), OrganizationId);
                            objContactInfo.Userid = UserId;
                            // objContactInfo.Deptname = department;
                            objContactInfo.Emailid = mail;
                            objContactInfo.Firstname = varFirstName;
                            objContactInfo.Lastname = varLastName;
                            // Local variable FlagContactInfo contain the status of Insert function objContactInfo.Insert()
                            FlagContactInfo = objContactInfo.Insert();
                            // if FlagContactInfo is zero,means error occured and delete the user record by calling objUserLogin.Delete function
                            if (FlagContactInfo == 0)
                            {
                                objUserLogin.Delete(UserId);
                            }
                            else
                            {
                                // Assign variable FlagSave =1 to show record added successfully in database
                                FlagSave = 1;
                                string varEmail;
                                if (mail == "")
                                {
                                    varEmail = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                                }
                                else { varEmail = mail.ToString().Trim(); }
                                //FlagSave = 1;
                                //string varCompany;
                                //if (company == "")
                                //{
                                //    varCompany = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                                //}
                                //else { varCompany = company.ToString().Trim(); }

                                //FlagSave = 1;
                                //string varSite;
                                //if (varSite == "")
                                //{
                                //    varSite = Resources.MessageResource.errMemshipCreateUserEmail.ToString();
                                //}
                                //else { varSIte = site.ToString().Trim(); }
                                // Create Mstatus field to send in Membership.CreateUser function as Out Variable for creating Membership User database
                                MembershipCreateStatus Mstatus = default(MembershipCreateStatus);
                                // Call Membership.CreateUser function to create Membership user 
                                Membership.CreateUser(varUserName.ToString().Trim(), VarPassword.ToString().Trim(), varEmail, "Project Name", "Helpdesk", true, out Mstatus);
                                // Call Roles.AddUserToRole Function to Add User To Role
                                Roles.AddUserToRole(varUserName.ToString().Trim(), varRoleName);
                                LogMessage("User" + LogMessageString + "Created");
                            }
                        }
                    }
                    else
                    {
                        //update city and company if user already exist
                        objUserLogin.UpdateCityCompany(varUserName, varCompany, varSite);
                        //end
                        FlagUserExist = 1;
                        LogMessage("User" + LogMessageString + "already exist");
                    }
                }
                //}
                catch(Exception ex)
                {
                    LogMessage("Exception reading user:" + LogMessageString);
                    LogMessage("Exception:"+ ex.ToString());
                }
            }
            
            if (FlagSave == 1)
            {
                // Show Messages from Resources.MessageResource resouces file located in App_GlobalResource Dir
                lblErrMsg.Text = Resources.MessageResource.errDataSave.ToString();
            }
            else
            {
                if (FlagUserExist == 1) { lblErrMsg.Text = Resources.MessageResource.errUserDomainExist.ToString(); }
                else { lblErrMsg.Text = Resources.MessageResource.errOccured.ToString(); }
            }
        }
        catch (Exception ex)
        {
            // Show Messages from Resources.MessageResource resouces file located in App_GlobalResource Dir
            lblErrMsg.Text = Resources.MessageResource.errDomainName.ToString();
        }
        Dispose();
    }
    // IsActive Function to Check whether User Account is Enable or Disable Active Directory
    //private bool IsActive(DirectoryEntry de)
    //{
    //    //0x0002
    //    if (de.NativeGuid == null) return false;
    //    if (de.Properties["userAccountControl"].Value != null)
    //    {
    //        int flags = (int)de.Properties["userAccountControl"].Value;
    //        if (!Convert.ToBoolean(flags & 0x0002)) return true; else return false;
    //    }
    //    else { return false; }
    //}

    protected void btnReset_Click(object sender, EventArgs e)
    {

        txtDomainName.Text = "";
        lblErrMsg.Text = "";
        txtPassword.Text = "";
        txtUserName.Text = "";
    }
}