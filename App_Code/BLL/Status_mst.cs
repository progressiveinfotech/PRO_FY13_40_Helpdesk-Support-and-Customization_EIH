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
/// Summary description for Status_mst
/// </summary>
public class Status_mst
{
    #region Private Fields
    private string _statusname;
    private int _statusid;
    private string _description;
    #endregion

    #region Public Fields
    public string Statusname
    {
        get { return _statusname; }
        set { _statusname = value; }
    }
    public int Statusid
    {
        get { return _statusid; }
        set { _statusid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Status_mst()
    {
    }
    public Status_mst(string statusname, int statusid, string description)
    {
        _statusname = statusname;
        _statusid = statusid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Status_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Status_mst_By_id(this);
    }
    public int Delete(int statusid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Status_mst_By_id(statusid);
    }
    public BLLCollection<Status_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Status_mst_All();
    }
    public int Get_By_StatusName(string StatusName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Status_mst_Get_By_StatusName(StatusName);
    }
    public Status_mst Get_By_id(int statusid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Status_mst_Get_By_statusid(statusid);
    }
    public BLLCollection<Status_mst> Get_All_By_OpenStatus()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Status_mst_All_By_OpenStatus();
    }
    #endregion
}
