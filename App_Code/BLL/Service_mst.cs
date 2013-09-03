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
/// Summary description for Service
/// </summary>
public class Service_mst
{
	#region Private Fields
    private string _servicename;
    private int _serviceid;
    private string _description;
    #endregion

    #region Public Fields
    public string servicename
    {
        get { return _servicename; }
        set { _servicename = value; }
    }
    public int Serviceid
    {
        get { return _serviceid; }
        set { _serviceid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Service_mst()
    {
    }
    public Service_mst(string servicename, int serviceid, string description)
    {
        _servicename = servicename;
        _serviceid = serviceid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Service_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Service_mst_By_id(this);
    }
    public int Delete(int serviceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Service_mst_By_id(serviceid);
    }
    public BLLCollection<Service_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Service_mst_All();
    }
    public int Get_By_ServiceName(string ServiceName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Service_mst_Get_By_ServiceName(ServiceName);
    }
    public Service_mst Get_By_id(int serviceid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Service_mst_Get_By_serviceid(serviceid);
    }
   
    #endregion
}
