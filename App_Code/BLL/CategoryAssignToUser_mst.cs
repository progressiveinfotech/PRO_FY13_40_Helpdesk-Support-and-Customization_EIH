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
/// Summary description for CategoryAssignToUser_mst
/// </summary>
public class CategoryAssignToUser_mst
{

    #region Private Fields
    private int _categoryid;
    private int _subcategoryid;
    private int _userid;
    private int _username;
    #endregion

    #region Public Fields
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    public int Subcategoryid
    {
        get { return _subcategoryid; }
        set { _subcategoryid = value; }
    }
    public int Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    public int Username
    {
        get { return _username; }
        set { _username = value; }
    }
    #endregion

	public CategoryAssignToUser_mst()
	{
        
	}
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        //return db.Insert_SubCategory_mst;
        return db.Insert_CategoryAssignToUser_mst(this);

    }
    public CategoryAssignToUser_mst Get_By_Categoryid_Subcategoryid(int categoryid, int subcategoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_CategoryAssignUser_mst_Get_By_CategorySubcategory(categoryid, subcategoryid);
    }
    public int Update(int categoryid,int subcategoryid,int userid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_CategoryAssignToUser_mst(categoryid, subcategoryid, userid);
    }
    #endregion
}
