using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;


using System.Collections;

using System.Web.Services.Protocols;

using System.Data.SqlClient;

using System.Web.Script.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{
    /// <summary>
    /// /added by vishal 18-05-2012
    /// </summary>
    BLLCollection<Customer_mst> colCustomerName = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping cus_mst = new CustomerToSiteMapping();

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
   
    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        
        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        String strCn = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString; // "Data Source=CSM-DEV\\SQL2008;Initial Catalog=hT_march;Persist Security Info=True;User ID=sa;Password=rimc@123;User Instance=False";// System.Configuration.ConfigurationManager.AppSettings["LocalSqlServer"].ToString();
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        //Compare String From Textbox(prefixText) AND String From 
        //Column in DataBase(CompanyName)
        //If String from DataBase is equal to String from TextBox(prefixText) 
        //then add it to return ItemList
        //-----I defined a parameter instead of passing value directly to 
        //prevent SQL injection--------//
        cmd.CommandText = "select distinct username from userlogin_mst where username  like @myParameter";
        cmd.Parameters.AddWithValue("@myParameter", "" + prefixText + "%");

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];

        //Then return List of string(txtItems) as result
        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["username"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();

    }



    [WebMethod]
    public string[] GetComputernameList(string prefixText, int count)
    {

        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String strCn = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString; // "Data Source=CSM-DEV\\SQL2008;Initial Catalog=hT_march;Persist Security Info=True;User ID=sa;Password=rimc@123;User Instance=False";// System.Configuration.ConfigurationManager.AppSettings["LocalSqlServer"].ToString();
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        //Compare String From Textbox(prefixText) AND String From 
        //Column in DataBase(CompanyName)
        //If String from DataBase is equal to String from TextBox(prefixText) 
        //then add it to return ItemList
        //-----I defined a parameter instead of passing value directly to 
        //prevent SQL injection--------//
        cmd.CommandText = "select distinct computerName from Asset_mst where computerName  like @myParameter";
        cmd.Parameters.AddWithValue("@myParameter", "" + prefixText + "%");

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];

        //Then return List of string(txtItems) as result
        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["computerName"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();

    }
}

