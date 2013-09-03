using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Title_mst
/// </summary>
public class Title_mst
{

    #region Private Fields
    private int _categoryid;
    private int _id;
    private string _title;
   
    private int _subcategoryid;
    
    #endregion

    #region Public Fields
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    public int  Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public int Subacetgoryid
    {
        get { return _subcategoryid; }
        set { _subcategoryid = value; }
    }
    #endregion

	public Title_mst()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();


      
        return db.Insert_Title_mst(this);


    }

    #region Public Function

    public BLLCollection<Title_mst> Get_All_By_Categoryid(int categoryid,int subcategoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Title_mst_All_By_Categoryid(categoryid,subcategoryid);
    }

    #endregion
}
