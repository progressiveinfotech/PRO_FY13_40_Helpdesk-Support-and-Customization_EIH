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
/// Summary description for ServiceDay_mst
/// </summary>
public class ServiceDay_mst
{
    #region Private Fields
    private string _weekday;
    private int _servicewindowid;
    private bool _isworking;
    #endregion

    #region Public Fields
    public string Weekday
    {
        get { return _weekday; }
        set { _weekday = value; }
    }
    public int Servicewindowid
    {
        get { return _servicewindowid; }
        set { _servicewindowid = value; }
    }
    public bool Isworking
    {
        get { return _isworking; }
        set { _isworking = value; }
    }
    #endregion

    #region Constructors
    public ServiceDay_mst()
    {
    }
    public ServiceDay_mst(string weekday, int servicewindowid, bool isworking)
    {
        _weekday = weekday;
        _servicewindowid = servicewindowid;
        _isworking = isworking;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ServiceDay_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ServiceDay_mst_By_id(this);
    }
    public int Delete(int servicewindowid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ServiceDay_mst_By_id(servicewindowid);
    }
    public BLLCollection<ServiceDay_mst> Get_All_By_Id(int servicewindowid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ServiceDay_mst_All_By_Id(servicewindowid);
    }
    #endregion
}
