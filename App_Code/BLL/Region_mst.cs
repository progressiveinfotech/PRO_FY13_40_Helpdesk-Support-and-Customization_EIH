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
/// Summary description for Region_mst
/// </summary>
public class Region_mst
{

    #region Private Fields
    private string _regionname;
    private int _regionid;
    private int _orgid;
    private string _description;
    private String _createdatetime;
    #endregion

    #region Public Fields
    public string Regionname
    {
        get { return _regionname; }
        set { _regionname = value; }
    }
    public int Regionid
    {
        get { return _regionid; }
        set { _regionid = value; }
    }
    public int Orgid
    {
        get { return _orgid; }
        set { _orgid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }

    
    #endregion

    #region Constructors
    public Region_mst()
    {
    }
    public Region_mst(string regionname, int regionid, int orgid, string description, String createdatetime)
    {
        _regionname = regionname;
        _regionid = regionid;
        _orgid = orgid;
        _description = description;
        _createdatetime = createdatetime;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Region_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Region_mst_By_id(this);
    }
    public int Delete(int regionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Region_mst_By_id(regionid);
    }
    public int Get_By_RegionName(string RegionName, int orgid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Region_mst_Get_By_RegionName(RegionName, orgid);
    }
    public BLLCollection<Region_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Region_mst_All();
    }
    //public BLLCollection<Region_mst> Get_All_By_RegionId(int rid)
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_All_mst_By_RegionId(rid);
    //}
    public Region_mst Get_By_id(int regionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Region_mst_Get_By_regionid(regionid);
    }
    
    #endregion
}
