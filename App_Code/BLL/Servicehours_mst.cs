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
/// Summary description for Servicehours_mst
/// </summary>
public class Servicehours_mst
{
    #region Private Fields
    private int _startmin;
    private int _starthour;
    private int _servicewindowid;
    private int _endmin;
    private int _endhour;
    #endregion

    #region Public Fields
    public int Startmin
    {
        get { return _startmin; }
        set { _startmin = value; }
    }
    public int Starthour
    {
        get { return _starthour; }
        set { _starthour = value; }
    }
    public int Servicewindowid
    {
        get { return _servicewindowid; }
        set { _servicewindowid = value; }
    }
    public int Endmin
    {
        get { return _endmin; }
        set { _endmin = value; }
    }
    public int Endhour
    {
        get { return _endhour; }
        set { _endhour = value; }
    }
    #endregion

    #region Constructors
    public Servicehours_mst()
    {
    }
    public Servicehours_mst(int startmin, int starthour, int servicewindowid, int endmin, int endhour)
    {
        _startmin = startmin;
        _starthour = starthour;
        _servicewindowid = servicewindowid;
        _endmin = endmin;
        _endhour = endhour;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Servicehours_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Servicehours_mst_By_id(this);
    }
    public int Delete(int servicewindowid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Servicehours_mst_By_id(servicewindowid);
    }
    public Servicehours_mst Get_By_id(int servicewindowid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Servicehours_mst_Get_By_servicewindowid(servicewindowid);
    } 
    #endregion
}
