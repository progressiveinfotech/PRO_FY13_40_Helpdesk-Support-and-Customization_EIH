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
/// Summary description for Incident_mst
/// </summary>
public class Incident_mst
{
    #region Private Fields
    private string _title;
   
    private int _timespentonreq;
    private int _slaid;
    private int _siteid;
    private int _requesterid;
    private int _modeid;
    private int _incidentid;
    private string _description;
    private int _deptid;
    private int _createdbyid;
    private string  _createdatetime;
    private Int64 _extension;
     
    private string _completedtime;
    private string _externalticketno;
    private int _vendorid;
    private bool _active;
    private bool _Amccall;
    //begin by lalit 21Nov2011
    private string _reporteddatetime;
    //end by lalit
    #endregion

    #region Public Fields

    public bool  Active
    {
        get { return _active; }
        set { _active = value; }
    }
    public string ExternalTicketNo
    {
        get { return _externalticketno; }
        set { _externalticketno = value; }
    }
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
    public Int64 Extension
    {
        get { return _extension; }
        set { _extension = value; }
    }
    public string Completedtime
    {
        get { return _completedtime; }
        set { _completedtime = value; }
    }
    public int VendorId
    {
        get { return _vendorid; }
        set { _vendorid = value; }
    }
    public bool AMCCall
    {
        get { return _Amccall; }
        set { _Amccall = value; }
    }
    //begin by lalit 21nov2011
    public string Reporteddatetime
    {
        get { return _reporteddatetime; }
        set { _reporteddatetime = value; }
    }
    //end lalit
    #endregion

    #region Constructors
    public Incident_mst()
    {
    }
    public Incident_mst(string title, int timespentonreq, int slaid, int siteid, int requesterid, int modeid, int incidentid, string description, int deptid, int createdbyid, string createdatetime, Int64 extension, string completedtime, string externalticketno, int vendorid, bool Amccall,string reporteddatetime)
    {
        _title = title;
        _timespentonreq = timespentonreq;
        _slaid = slaid;
        _siteid = siteid;
        _requesterid = requesterid;
        _modeid = modeid;
        _incidentid = incidentid;
        _description = description;
        _deptid = deptid;
        _createdbyid = createdbyid;
        _extension = extension;
        _createdatetime = createdatetime;
        _completedtime = completedtime;
        _externalticketno = externalticketno;
        _vendorid = vendorid;
        _Amccall = Amccall;
        _reporteddatetime = reporteddatetime;
    }
    #endregion



    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Incident_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Incident_mst_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Incident_mst_By_id(incidentid);
    }


    public BLLCollection<Incident_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All();
    }
    public Incident_mst Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Incident_mst_Get_By_incidentid(incidentid);
    }
    public int Get_By_SLAid(int siteid,int priorityid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Incident_mst_Get_SLAid(siteid, priorityid);
    }

    public int Get_TopIncidentId()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_TopIncidentId();
    }
 
    public int Get_Current_Incidentid()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Incident_mst_Get_Current_Incidentid();
    }

    public int Get_TimeSpentonRequest(int incidentid,int siteid,string starttime,string endtime)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Incident_mst_Get_TimeSpentonRequest(incidentid, siteid, starttime, endtime);
    }
    public BLLCollection<Incident_mst> Get_All_By_Siteid_Createdbyid(int siteid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_Createdbyid(siteid, fromdate, todate, technicianid, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_By_Siteid_Statusid(int siteid, int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_statusid(siteid, statusid, fromdate, todate, technicianid, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_By_Siteid_Statusid_Unassigned(int siteid, int statusid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_statusid_Unassigned(siteid, statusid, fromdate, todate, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_By_Siteid_Statusid_technicianid(int siteid, int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_statusid_technicianid(siteid, statusid, technicianid, fromdate, todate, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_By_Siteid_Technicianid(int siteid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_Technicianid(siteid, technicianid, fromdate, todate, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_Incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Incidentid(incidentid);
    }
    public BLLCollection<Incident_mst> Get_All_By_Siteid_Assigned(int siteid,  string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_Assigned(siteid, fromdate, todate, varSortParameter);
    }

    public BLLCollection<Incident_mst> Get_All_For_ProcessEmailEscalate(int statusid,int requesttypeid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_Get_All_For_ProcessEmailEscalate(statusid, requesttypeid);
    }
    //changed by lalit 3 july added uid
    public BLLCollection<Incident_mst> Get_All_Incidentid_By_SearchParameter(string Filterid, string keyword,string uid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_SearchParameter(Filterid, keyword,uid);
    }
    //end

    public BLLCollection<Incident_mst> Get_All_By_Siteid_Requesterid(int siteid, int requesterid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Incident_mst_All_By_Siteid_Requesterid(siteid, requesterid, fromdate, todate, varSortParameter);
    }
    #endregion

}
