using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.DirectoryServices;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    // Coded By -Sumit Gupta
    // Coded  On-16 Jan 2010
    // Description - To Validate the User Credentials ,Eihter via Active Directory or By UserLogin_mst Database(or APSNET DB Table aspnet_users)
    // Create Objects of Classes UserLogin_mst  and Organization_mst 
    UserLogin_mst objUserLogin = new UserLogin_mst();
    Organization_mst objOrganization = new Organization_mst();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //if (dt.Rows.Count > 0)
            //{
            #region match keys with given keys
            // Create Local variable varOrganizationId to hold the Organization id from Organization_mst table
            int varOrganizationId;
            //  Call function objOrganization.Get_Organization(), to get Object of Organization_mst Class 
            objOrganization = objOrganization.Get_Organization();
            // Assign Organization Id to variable varOrganizationId
            varOrganizationId = objOrganization.Orgid;
            // Call Function objUserLogin.Get_UserLogin_By_UserName ,to get Object of UserLogin_mst Class by passing parameter username and organization id
            objUserLogin = objUserLogin.Get_UserLogin_By_UserName(txtUserName.Text.ToString().Trim(), varOrganizationId);
            // Create local Variable varDomainName to get the value of domain name    

            #region if user is AD user
            // Check whether User is from Active Directory User or Normal User,  if objUserLogin.ADEnable == true ie user is Active Directory User 
            if (objUserLogin.ADEnable == true)
            {
                //string varDomainName = objUserLogin.DomainName;
                // Create local Variable FlagStatus ,to hold the status of whether user have valid credentials against Active Directory

                // Call get DomainName from DB                  //added by lalit joshi
                string domainname = getdomain();
                bool FlagStatus;
                // Call Function Authenticate to validate user credentials by passing parameters Username,Password and DomainName and store Status in variable FlagStatus
                FlagStatus = Authenticate(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim(), getdomain());

                // If FlagStatus is True ,ie  User Credentials are Valid and it's Cookie Ticket Will be Generated
                if (FlagStatus == true)
                {
                    // Cookie Ticket is  Generated and redirected to the default page
                    FormsAuthentication.SetAuthCookie(txtUserName.Text.ToString().Trim(), false);

                    #region find last row of Key table
                    DataTable dt = Authenticate();
                    #endregion

                    if (dt.Rows.Count > 0)
                    {
                        string decrytkey = Decrypt(dt.Rows[0]["Lkey"].ToString(), "pipl?123");
                        string keystatus = Encrypt("InActive", "pipl?123");

                        if (decrytkey == "bu$$1ne$$@2011" || decrytkey == "educ0mp#1nch1n@" || decrytkey == "c1v1l$0c1at@" || decrytkey == "11$1n2011" || decrytkey == "1nsp1r@t10n" || decrytkey == "c1rcum1nst@nce5" || decrytkey == "pipl$prog#" || decrytkey == "$1lverl1ghtc01n" || decrytkey == "A@B#Z123$*" || decrytkey == "Z001nP0lyt1c$")
                        {
                            string decryptstatus = Decrypt(dt.Rows[0]["status"].ToString(), "pipl?123");
                            if (decryptstatus == "Active")
                            {
                                string dtvalid = dt.Rows[0]["validdate"].ToString();
                                string dtvaliddecry = Decrypt(dt.Rows[0]["validdate"].ToString(), "pipl?123");
                                DateTime dtvaliddecr = DateTime.Parse(dtvaliddecry);
                                DateTime dttoday = DateTime.Now;
                                #region if today date is exceeding expiry date
                                if (DateTime.Compare(dttoday, dtvaliddecr) >= 0)
                                {
                                    string sql = "update Loginkey set status='" + keystatus + "' where status='" + dt.Rows[0]["status"].ToString() + "'";
                                    UpdateRecord(sql);
                                    Response.Redirect("~/Admin/Activate.aspx");
                                }
                                #endregion

                                if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "PManager"))
                                {
                                    Response.Redirect("~/KEDB/ViewSolution.aspx");
                                }
                                else if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "User"))
                                {
                                    Response.Redirect("~/Login/Usercall.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Login/Default.aspx");
                                }

                            }
                            else
                            {
                                Response.Redirect("~/admin/Activate.aspx");
                            }
                        }

                    }
                    else
                    {
                        DateTime date = System.DateTime.Now;
                        DateTime dateto30 = System.DateTime.Now.AddMonths(1);
                        string keyen = Encrypt("bu$$1ne$$@2011", "pipl?123");
                        string keydate = Encrypt(date.ToString(), "pipl?123");
                        string keydateto30 = Encrypt(dateto30.ToString(), "pipl?123");
                        string keystatus = Encrypt("Active", "pipl?123");

                        string sql = "insert into LoginKey(Lkey,currentdate,validdate,status)values('" + keyen + "','" + keydate + "','" + keydateto30 + "','" + keystatus + "')";
                        Insert(sql);
                        if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "PManager"))
                        {
                            Response.Redirect("~/KEDB/ViewSolution.aspx");
                        }
                        else if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "User"))
                        {
                            Response.Redirect("~/Login/Usercall.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Login/Default.aspx");
                        }
                    }

                }
                else
                {
                    // If User Credentials is not valid against active directory,display message Either Username or Password is not Valid
                    lblErrorMsg.Text = Resources.MessageResource.errUserNotVaild.ToString();
                }

            }
            #endregion

            else
            {
                int userid = objUserLogin.Get_By_UserName(txtUserName.Text.Trim(), varOrganizationId);
                // Check User Credentials Against Database,We Use Membership Function Membership.ValidateUser to check User Credentials against aspnet database
                // If it's Returns True,ie user has valid Credentials and it's Cookir ticket wiil be generated 
                if (Membership.ValidateUser(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim()) || AuthenticateFromDB(userid, txtPassword.Text.Trim()))
                {
                    // Cookie Ticket is  Generated and redirected to the default page
                    FormsAuthentication.SetAuthCookie(txtUserName.Text.ToString().Trim(), false);

                    #region find last row of Key table
                    DataTable dt = Authenticate();
                    #endregion

                    if (dt.Rows.Count > 0)
                    {
                        string decrytkey = Decrypt(dt.Rows[0]["Lkey"].ToString(), "pipl?123");
                        string keystatus = Encrypt("InActive", "pipl?123");

                        if (decrytkey == "bu$$1ne$$@2011" || decrytkey == "educ0mp#1nch1n@" || decrytkey == "c1v1l$0c1at@" || decrytkey == "11$1n2011" || decrytkey == "1nsp1r@t10n" || decrytkey == "c1rcum1nst@nce5" || decrytkey == "pipl$prog#" || decrytkey == "$1lverl1ghtc01n" || decrytkey == "A@B#Z123$*" || decrytkey == "Z001nP0lyt1c$")
                        {
                            string decryptstatus = Decrypt(dt.Rows[0]["status"].ToString(), "pipl?123");
                            if (decryptstatus == "Active")
                            {
                                string dtvalid = dt.Rows[0]["validdate"].ToString();
                                string dtvaliddecry = Decrypt(dt.Rows[0]["validdate"].ToString(), "pipl?123");
                                DateTime dtvaliddecr = DateTime.Parse(dtvaliddecry);
                                DateTime dttoday = DateTime.Now;
                                #region if today date is exceeding expiry date
                                if (DateTime.Compare(dttoday, dtvaliddecr) >= 0)
                                {
                                    string sql = "update Loginkey set status='" + keystatus + "' where status='" + dt.Rows[0]["status"].ToString() + "'";
                                    UpdateRecord(sql);
                                    Response.Redirect("~/Admin/Activate.aspx");
                                }
                                #endregion

                                if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "PManager"))
                                {
                                    Response.Redirect("~/KEDB/ViewSolution.aspx");
                                }
                                else if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "User"))
                                {
                                    Response.Redirect("~/Login/Usercall.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Login/Default.aspx");
                                }

                            }
                            else
                            {
                                Response.Redirect("~/admin/Activate.aspx");
                            }
                        }

                    }
                    else
                    {
                        DateTime date = System.DateTime.Now;
                        DateTime dateto30 = System.DateTime.Now.AddMonths(1);
                        string keyen = Encrypt("bu$$1ne$$@2011", "pipl?123");
                        string keydate = Encrypt(date.ToString(), "pipl?123");
                        string keydateto30 = Encrypt(dateto30.ToString(), "pipl?123");
                        string keystatus = Encrypt("Active", "pipl?123");

                        string sql = "insert into LoginKey(Lkey,currentdate,validdate,status)values('" + keyen + "','" + keydate + "','" + keydateto30 + "','" + keystatus + "')";
                        Insert(sql);
                        if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "PManager"))
                        {
                            Response.Redirect("~/KEDB/ViewSolution.aspx");
                        }
                        else if (Roles.IsUserInRole(txtUserName.Text.ToString().Trim(), "User"))
                        {
                            Response.Redirect("~/Login/Usercall.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Login/Default.aspx");
                        }
                    }

                }
                else
                {
                    // If User Credentials is not valid against databse,display message Either Username or Password is not Valid
                    lblErrorMsg.Text = Resources.MessageResource.errUserNotVaild.ToString();
                }

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

    #region Authenticate Function to Check Whether User is valid credentials against Active Directory
    // code by lalit Joshi
    private bool Authenticate(string userName, string password, string domain)
    {
        bool authentic = false;

        try
        {

            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
            DirectorySearcher srchr = new DirectorySearcher(entry);

            srchr.Filter = string.Format("(SAMAccountName={0})", userName);
            //srchr.Filter = string.Format("SAMAccountName=0", userName);
            SearchResult res = srchr.FindOne();
            if (res != null)
                authentic = true;
        }
        catch (DirectoryServicesCOMException) { }
        return authentic;
    }

    #endregion


    #region Authenticate Function to Check Whether User is valid credentials against Database
    private bool AuthenticateFromDB(int userid, string password)        //added by lalit joshi
    {
        bool authentic = false;
        try
        {
            SqlCommand cmd = new SqlCommand();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from UserLogin_mst where UserId=@UserId and password=@password";
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                authentic = true;
            }

        }
        catch (DirectoryServicesCOMException) { }
        return authentic;
    }
    #endregion

    #region To get domain
    //code by lalit
    protected string getdomain()
    {
        string dcName = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select domainName from UserLogin_mst";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["domainName"].ToString() != "")
                    {
                        dcName = dt.Rows[i]["domainName"].ToString();
                        break;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
        return dcName;
    }
    #endregion

    protected void btnReset_Click1(object sender, EventArgs e)
    {
        txtPassword.Text = "";
        txtUserName.Text = "";
        lblErrorMsg.Text = "";
    }

    #region Code by Lalit Joshi to implement Activation key

    private SqlConnection mCon;
    private SqlCommand mCom;

    public DataTable Authenticate()
    {
        OpenConnection();
        string sql = "select * from Loginkey where Id in(select MAX(Id) from Loginkey)";
        DataTable dt = GetDataTable(sql);
        return dt;
    }
    public DataTable GetDataTable(string strsql)
    {
        OpenConnection();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(strsql, mCon);
        da.Fill(dt);
        CloseConnection();
        DisposeConnection();
        return dt;
    }

    public static string Decrypt(string data, string password) //This method is to decrypt the password given by user.
    {
        if (String.IsNullOrEmpty(data))
            throw new ArgumentException("No data given");
        if (String.IsNullOrEmpty(password))
            throw new ArgumentException("No password given");

        byte[] rawData = Convert.FromBase64String(data.Replace(" ", "+"));
        if (rawData.Length < 8)
            throw new ArgumentException("Invalid input data");

        // setup the decryption algorithm
        byte[] salt = new byte[8];
        for (int i = 0; i < salt.Length; i++)
            salt[i] = rawData[i];

        Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(password, salt);

        TripleDES tdes = TripleDES.Create();
        //Rijndael aes = Rijndael.Create();

        tdes.IV = keyGenerator.GetBytes(tdes.BlockSize / 8);
        tdes.Key = keyGenerator.GetBytes(tdes.KeySize / 8);
        // decrypt the data
        using (MemoryStream memoryStream = new MemoryStream())
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, tdes.CreateDecryptor(), CryptoStreamMode.Write))
        {
            cryptoStream.Write(rawData, 8, rawData.Length - 8);
            cryptoStream.Close();

            byte[] decrypted = memoryStream.ToArray();
            return Encoding.Unicode.GetString(decrypted);
        }
    }
    public static string Encrypt(string data, string password) //This method is to encrypt the password given by user.
    {
        if (String.IsNullOrEmpty(data))
            throw new ArgumentException("No data given");
        if (String.IsNullOrEmpty(password))
            throw new ArgumentException("No password given");

        // setup the encryption algorithm
        Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(password, 8);
        TripleDES tdes = TripleDES.Create();
        //Rijndael aes = Rijndael.Create();

        tdes.IV = keyGenerator.GetBytes(tdes.BlockSize / 8);
        tdes.Key = keyGenerator.GetBytes(tdes.KeySize / 8);

        // encrypt the data
        byte[] rawData = Encoding.Unicode.GetBytes(data);
        using (MemoryStream memoryStream = new MemoryStream())
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, tdes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            memoryStream.Write(keyGenerator.Salt, 0, keyGenerator.Salt.Length);
            cryptoStream.Write(rawData, 0, rawData.Length);
            cryptoStream.Close();

            byte[] encrypted = memoryStream.ToArray();
            return Convert.ToBase64String(encrypted);
        }
    }
    public void OpenConnection()
    {
        if (mCon == null)
        {

            mCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ToString());
            mCon.Open();
            mCom = new SqlCommand();
            mCom.Connection = mCon;
        }
    }

    public void CloseConnection()
    {
        mCon.Close();
    }
    public object DisposeConnection()
    {
        if (mCon != null)
        {
            mCon.Dispose();
            mCon = null;
        }
        return 1;
    }
    public bool UpdateRecord(string strsql)
    {
        int i = 0;
        OpenConnection();
        mCom.CommandType = CommandType.Text;
        mCom.CommandText = strsql;
        i = mCom.ExecuteNonQuery();
        CloseConnection();
        DisposeConnection();
        if (i == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool Insert(string strsql)
    {
        int i = 0;
        OpenConnection();
        mCom.CommandType = CommandType.Text;
        mCom.CommandText = strsql;
        i = mCom.ExecuteNonQuery();

        CloseConnection();
        DisposeConnection();
        if (i == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost/seby/test.aspx");
    }
}
