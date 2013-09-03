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
/// Summary description for IncidentDeactiveCalls
/// </summary>
public class IncidentDeactiveCalls
{
    #region Private Fields
    private string _title;
    private int _timespentonreq;
    private int _technicianid;
    private int _statusid;
    private int _slaid;
    private int _siteid;
    private int _requesterid;
    private int _priorityid;
    private int _modeid;
    private int _incidentid;
    private string _description;
    private int _deptid;
    private string _deletedtime;
    private int _deletedby;
    private int _deactiveid;
    private int _createdbyid;
    private string _createdatetime;
    private string _completedtime;
    #endregion

    #region Public Fields
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public int Timespentonreq
    {
        get { return _timespentonreq; }
        set { _timespentonreq = value; }
    }
    public int Technicianid
    {
        get { return _technicianid; }
        set { _technicianid = value; }
    }
    public int Statusid
    {
        get { return _statusid; }
        set { _statusid = value; }
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
    public int Requesterid
    {
        get { return _requesterid; }
        set { _requesterid = value; }
    }
    public int Priorityid
    {
        get { return _priorityid; }
        set { _priorityid = value; }
    }
    public int Modeid
    {
        get { return _modeid; }
        set { _modeid = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Deptid
    {
        get { return _deptid; }
        set { _deptid = value; }
    }
    public string Deletedtime
    {
        get { return _deletedtime; }
        set { _deletedtime = value; }
    }
    public int Deletedby
    {
        get { return _deletedby; }
        set { _deletedby = value; }
    }
    public int Deactiveid
    {
        get { return _deactiveid; }
        set { _deactiveid = value; }
    }
    public int Createdbyid
    {
        get { return _createdbyid; }
        set { _createdbyid = value; }
    }
    public string Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    public string Completedtime
    {
        get { return _completedtime; }
        set { _completedtime = value; }
    }
    #endregion

    #region Constructors
    public IncidentDeactiveCalls()
    {
    }
    public IncidentDeactiveCalls(string title, int timespentonreq, int technicianid, int statusid, int slaid, int siteid, int requesterid, int priorityid, int modeid, int incidentid, string description, int deptid, string deletedtime, int deletedby, int deactiveid, int createdbyid, string createdatetime, string completedtime)
    {
        _title = title;
        _timespentonreq = timespentonreq;
        _technicianid = technicianid;
        _statusid = statusid;
        _slaid = slaid;
        _siteid = siteid;
        _requesterid = requesterid;
        _priorityid = priorityid;
        _modeid = modeid;
        _incidentid = incidentid;
        _description = description;
        _deptid = deptid;
        _deletedtime = deletedtime;
        _deletedby = deletedby;
        _deactiveid = deactiveid;
        _createdbyid = createdbyid;
        _createdatetime = createdatetime;
        _completedtime = completedtime;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentDeactiveCalls(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentDeactiveCalls_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentDeactiveCalls_By_id(incidentid);
    }
   

   

    #endregion
}
