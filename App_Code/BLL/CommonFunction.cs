using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
public class CommonFunction
{
        private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString;
    private SqlConnection mCon;
    private SqlCommand mCom;
    public CommonFunction()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetDataSet(string strsql)
    {
        OpenConnection();
        DataSet ds = null;
        ds = new DataSet();
        SqlDataAdapter da = null;
        da = new SqlDataAdapter(strsql, mCon);
        mCom.CommandTimeout = 240;
        da.Fill(ds, "myTable");
        CloseConnection();
        DisposeConnection();
        return ds;
    }

    private void OpenConnection()
    {
        if (mCon == null)
        {

            mCon = new SqlConnection(constr);
            mCon.Open();
            mCom = new SqlCommand();
         //   mCom.CommandTimeout = 240;
            mCom.Connection = mCon;
          
        }
    }

    private void CloseConnection()
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
}
