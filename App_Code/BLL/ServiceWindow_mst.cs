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
/// Summary description for ServiceWindow_mst
/// </summary>
public class ServiceWindow_mst
{
    #region Private Fields
    private int _siteid;
    private int _servicewindowid;
    #endregion

    #region Public Fields
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public int Servicewindowid
    {
        get { return _servicewindowid; }
        set { _servicewindowid = value; }
    }
    #endregion

    #region Constructors
    public ServiceWindow_mst()
    {
    }
    public ServiceWindow_mst(int siteid, int servicewindowid)
    {
        _siteid = siteid;
        _servicewindowid = servicewindowid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ServiceWindow_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ServiceWindow_mst_By_id(this);
    }

    public int Delete(int servicewindowid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ServiceWindow_mst_By_id(servicewindowid);
    }
    public ServiceWindow_mst Get_By_id(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ServiceWindow_mst_Get_By_Siteid(siteid);
    }

    public ServiceWindow_mst Get_By_serviceid(int serviceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ServiceWindow_mst_Get_By_serviceid(serviceid);
    }

    public BLLCollection<ServiceWindow_mst> Get_All_By_RegionId(int regionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ServiceWindow_mst_All_By_RegionId(regionid);
    }

    public BLLCollection<ServiceWindow_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ServiceWindow_mst_All();
    }
    public int Get_ServiceWindow_By_Siteid(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_ServiceWindow_By_Siteid(siteid);
    }
    #endregion
}
