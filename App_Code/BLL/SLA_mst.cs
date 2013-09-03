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
/// Summary description for SLA_mst
/// </summary>
public class SLA_mst
{
    #region Private Fields
    private string _slaname;
    private int _slaid;
    private int _siteid;
    private bool _enable;
    private String _createdatetime;
    private String _description;
    #endregion

    #region Public Fields
    public string Slaname
    {
        get { return _slaname; }
        set { _slaname = value; }
    }
    public int Slaid
    {
        get { return _slaid; }
        set { _slaid = value; }
    }
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public bool Enable
    {
        get { return _enable; }
        set { _enable = value; }
    }
    public String Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    public String Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion


    #region Constructors
    public SLA_mst()
    {
    }
    public SLA_mst(string slaname, int slaid, int siteid, bool enable, String createdatetime, string description)
    {
        _slaname = slaname;
        _slaid = slaid;
        _siteid = siteid;
        _enable = enable;
        _createdatetime = createdatetime;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_SLA_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_SLA_mst_By_id(this);
    }
    public int Delete(int slaid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_SLA_mst_By_id(slaid);
    }

    public SLA_mst Get_By_SLAName(string Slaname, int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SLA_mst_Get_By_SLAName(Slaname, siteid);
    }

    public BLLCollection<SLA_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SLA_mst_All();
    }
    public BLLCollection<SLA_mst> Get_All_By_Siteid(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SLA_mst_All_By_Siteid(siteid);
    }
    public SLA_mst Get_By_id(int Slaid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.SLA_mst_Get_By_Slaid(Slaid);
    }
    #endregion
}
