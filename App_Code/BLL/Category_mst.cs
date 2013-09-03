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
/// Summary description for Category_mst
/// </summary>
public class Category_mst
{
    #region Private Fields
    private int _categoryid;
    private string _CategoryName;
    private string _categorydescription;
    #endregion

    #region Public Fields
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    public string CategoryName
    {
        get { return _CategoryName; }
        set { _CategoryName = value; }
    }
    public string Categorydescription
    {
        get { return _categorydescription; }
        set { _categorydescription = value; }
    }
    #endregion
    #region Constructors
    public Category_mst()
    {
    }
    public Category_mst(int categoryid, string CategoryName ,string categorydescription)
    {
        _categoryid = categoryid;
        _CategoryName = CategoryName;
        _categorydescription = categorydescription;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Category_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Category_mst_By_id(this);
    }
    public int Delete(int categoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Category_mst_By_id(categoryid);
    }
    public int Get_By_CategoryName(string CategoryName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Category_mst_Get_By_CategoryName(CategoryName);
    }
    //public int Get_By_siteid_holiday_check(int siteid, int holidaydate)
    //{

    //}

    public BLLCollection<Category_mst> Get_All()
    {
     SqlDataProvider db = new SqlDataProvider();
        return db.Get_Category_mst_All();
    }
    public Category_mst Get_By_id(int categoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.category_mst_Get_By_categoryid(categoryid);
    } 
   
   
    #endregion
}
