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
public class ChangeStatus_mst
{ 
    #region Private Fields
    private string _statusname;
    private int _changestatusid;
    private string _description;
    #endregion

    #region Public Fields
    public string Statusname
    {
        get { return _statusname; }
        set { _statusname = value; }
    }
    public int ChangeStatusid
    {
        get { return _changestatusid; }
        set { _changestatusid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public ChangeStatus_mst()
    {
    }
    public ChangeStatus_mst(string statusname, int changestatusid, string description)
    {
        _statusname = statusname;
        _changestatusid = changestatusid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ChangeStatus_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ChangeStatus_mst_By_id(this);
    }
    public int Delete(int changestatusid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ChangeStatus_mst_By_id(changestatusid);
    }
    public BLLCollection<ChangeStatus_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ChangeStatus_mst_All();
    
    }
    public BLLCollection<ChangeStatus_mst> Get_All_By_Statusname(string statusname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ChangeStatus_mst_All_By_Statusname(statusname);

    }

    public int Get_By_StatusName(string StatusName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ChangeStatus_mst_Get_By_StatusName(StatusName);
    }
    public ChangeStatus_mst Get_By_id(int statusid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ChangeStatus_mst_Get_By_changestatusid(statusid);
    }
    #endregion
}
