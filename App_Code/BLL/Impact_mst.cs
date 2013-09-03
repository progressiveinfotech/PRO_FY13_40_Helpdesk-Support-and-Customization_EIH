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
/// Summary description for Impact_mst
/// </summary>
public class Impact_mst
{

    #region Private Fields
    private string _impactname;
    private int _impactid;
    private string _description;
    #endregion
    #region Public Fields
    public string Impactname
    {
        get { return _impactname; }
        set { _impactname = value; }
    }
    public int Impactid
    {
        get { return _impactid; }
        set { _impactid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Impact_mst()
    {
    }
    public Impact_mst(string impactname, int impactid, string description)
    {
        _impactname = impactname;
        _impactid = impactid;
        _description = description;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Impact_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Impact_mst_By_id(this);
    }
    public int Delete(int impactid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Impact_mst_By_id(impactid);
    }
    public BLLCollection<Impact_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Impact_mst_All();
    }
    public int Get_By_ImpactName(string Impactname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Impact_mst_Get_By_ImpactName(Impactname);
    }
    public Impact_mst Get_By_id(int impactid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Impact_mst_Get_By_Impactid(impactid);
    }
    #endregion
}
