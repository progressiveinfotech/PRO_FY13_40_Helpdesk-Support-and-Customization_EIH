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
/// Summary description for IncidentLog
/// </summary>
public class IncidentLog
{
    #region Private Fields
    private string _incidentlog;
    private int _incidentid;
    private int _userid;
    private string _createdatetime;
    #endregion
    #region Public Fields
    public string Incidentlog
    {
        get { return _incidentlog; }
        set { _incidentlog = value; }
    }
    public string CreateDateTime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }

    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    public int Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    #endregion
    #region Constructors
    public IncidentLog()
    {
    }
    public IncidentLog(string incidentlog, int incidentid,int userid,string createdatetime)
    {
        _incidentlog = incidentlog;
        _incidentid = incidentid;
        _userid = userid;
        _createdatetime = createdatetime;
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentLog(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentLog_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentLog_By_id(incidentid);
    }

    public BLLCollection<IncidentLog> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentLog_All();
    }

    public IncidentLog Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentLog_Get_By_incidentid(incidentid);
    }

    public BLLCollection<IncidentLog> Get_All_By_incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentLog_All_By_incidentid(incidentid);
    }


    #endregion

}
