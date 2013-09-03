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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class admin_Activate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string userName = "";
            #region Get Current User and his Role
            MembershipUser User = Membership.GetUser();
            string varUserRole = "";
            //string varRoleTechnician = "";
            if (User != null)
            {
                userName = User.UserName.ToString();

                string[] arrUserRole = Roles.GetRolesForUser();
                varUserRole = arrUserRole[0].ToString();

                if (varUserRole == "Admin")
                {
                    div1.Visible = true;
                }

            }
            #endregion
        }
    }

    protected void Btnclick_Click(object sender, EventArgs e)
    {
        DateTime date = System.DateTime.Now;
        DateTime dateto30 = System.DateTime.Now.AddYears(1);

        if (txtkey.Text == "bu$$1ne$$@2011" || txtkey.Text == "educ0mp#1nch1n@" || txtkey.Text == "c1v1l$0c1at@" || txtkey.Text == "11$1n2011" || txtkey.Text == "1nsp1r@t10n" || txtkey.Text == "c1rcum1nst@nce5" || txtkey.Text == "pipl$prog#" || txtkey.Text == "$1lverl1ghtc01n" || txtkey.Text == "A@B#Z123$*" || txtkey.Text == "Z001nP0lyt1c$")
        {
            string keyen = Encrypt(txtkey.Text.Trim(), "pipl?123");
            string keydate = Encrypt(date.ToString(), "pipl?123");
            string keydateto30 = Encrypt(dateto30.ToString(), "pipl?123");
            string keystatus = Encrypt("Active", "pipl?123");

            string sql = "insert into LoginKey(Lkey,currentdate,validdate,status)values('" + keyen + "','" + keydate + "','" + keydateto30 + "','" + keystatus + "')";
            Insert(sql);
            Lblmsg.Text = "Helpdesk tool re-activated successfully. Please login.";
        }
        else
        {
            Lblmsg.Text = "Invalid Product key. please try again";
        }
    }
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ToString();
    private SqlConnection mCon;
    private SqlCommand mCom;

    public void OpenConnection()
    {
        if (mCon == null)
        {

            mCon = new SqlConnection(constr);
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


}
