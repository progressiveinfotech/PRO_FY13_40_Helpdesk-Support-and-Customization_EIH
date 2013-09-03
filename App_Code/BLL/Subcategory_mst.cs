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
/// Summary description for Subcategory_mst
/// </summary>
public class Subcategory_mst
{
    #region Private Fields
    private int _subcategoryid;
    private string _subcategoryname;
    private string _subcategorydescription;
    private int _categoryid;
    
    #endregion

    #region Public Fields
    public int Subcategoryid
    {
        get { return _subcategoryid; }
        set { _subcategoryid = value; }
    }
    public string Subcategorydescription
    {
        get { return _subcategorydescription; }
        set { _subcategorydescription = value; }
    }
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    public string Subcategoryname
    {
        get { return _subcategoryname; }
        set { _subcategoryname = value; }
    }
    
    #endregion

    #region Constructors
    public Subcategory_mst()
    {
    }
    public Subcategory_mst(int subcategoryid, string subcategorydescription, string subcategoryname,int categoryid)
    {
        _subcategoryid = subcategoryid;
        _subcategorydescription = subcategorydescription;
        _categoryid = categoryid;
        _subcategoryname = subcategoryname;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_SubCategory_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_SubCategory_mst_By_id(this);
    }
    public int Delete(int subcategoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_SubCategory_mst_By_id(subcategoryid);
    }
    public int Get_By_SubcategoryName(string Subcategoryname, int categoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Subcategory_mst_Get_By_SubcategoryName(Subcategoryname, categoryid);
    }

    public BLLCollection<Subcategory_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Subcategory_mst_All();
    }
    public BLLCollection<Subcategory_mst> Get_All_By_Categoryid(int categoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Subcategory_mst_All_By_Categoryid(categoryid);
    }
    public Subcategory_mst Get_By_id(int subcategoryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Subcategory_mst_Get_By_subcategoryid(subcategoryid);
    }
    #endregion
}
