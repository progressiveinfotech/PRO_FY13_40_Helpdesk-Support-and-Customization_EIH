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
/// Summary description for IncidentStates
/// </summary>
public class IncidentStates
{

    #region Private Fields
    private int _technicianid;
    private int _subcategoryid;
    private int _statusid;
    private int _requesttypeid;
    private bool _reqapproval;
    private bool _reopened;
    private int _priorityid;
    private bool _isescalated;
    private int _incidentid;
    private int _impactid;
    private bool _hasattachment;
    private string _closecomments;
    private string _closeaccepted;
    private int _categoryid;
    private string _assignedtime;
    #endregion

    #region Public Fields
    public string AssignedTime
    {
        get { return _assignedtime; }
        set { _assignedtime = value; }
    }
    public int Technicianid
    {
        get { return _technicianid; }
        set { _technicianid = value; }
    }
    public int Subcategoryid
    {
        get { return _subcategoryid; }
        set { _subcategoryid = value; }
    }
    public int Statusid
    {
        get { return _statusid; }
        set { _statusid = value; }
    }
    public int Requesttypeid
    {
        get { return _requesttypeid; }
        set { _requesttypeid = value; }
    }
    public bool Reqapproval
    {
        get { return _reqapproval; }
        set { _reqapproval = value; }
    }
    public bool Reopened
    {
        get { return _reopened; }
        set { _reopened = value; }
    }
    public int Priorityid
    {
        get { return _priorityid; }
        set { _priorityid = value; }
    }
    public bool Isescalated
    {
        get { return _isescalated; }
        set { _isescalated = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    public int Impactid
    {
        get { return _impactid; }
        set { _impactid = value; }
    }
    public bool Hasattachment
    {
        get { return _hasattachment; }
        set { _hasattachment = value; }
    }
    public string Closecomments
    {
        get { return _closecomments; }
        set { _closecomments = value; }
    }
    public string Closeaccepted
    {
        get { return _closeaccepted; }
        set { _closeaccepted = value; }
    }
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    #endregion


    #region Constructors
    public IncidentStates()
    {
    }
    public IncidentStates(int technicianid, int subcategoryid, int statusid, int requesttypeid, bool reqapproval, bool reopened, int priorityid, bool isescalated, int incidentid, int impactid, bool hasattachment, string closecomments, string closeaccepted, int categoryid, string assignedtime)
    {
        _technicianid = technicianid;
        _subcategoryid = subcategoryid;
        _statusid = statusid;
        _requesttypeid = requesttypeid;
        _reqapproval = reqapproval;
        _reopened = reopened;
        _priorityid = priorityid;
        _isescalated = isescalated;
        _incidentid = incidentid;
        _impactid = impactid;
        _hasattachment = hasattachment;
        _closecomments = closecomments;
        _closeaccepted = closeaccepted;
        _categoryid = categoryid;
        _assignedtime = assignedtime;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentStates_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentStates_mst_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentStates_mst_By_id(incidentid);
    }


    public BLLCollection<IncidentStates> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentStates_mst_All();
    }
    public IncidentStates Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentStates_mst_Get_By_incidentid(incidentid);
    }


    #endregion

}
