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
/// Summary description for csm_calls
/// </summary>
public class csm_calls
{


    #region Private Fields
    private string _customername;
    private string _location;
    private string _callNo;
    private string _logDate;
    private string _Logtime;
    private string _user;
    private string _problemDesc;
    private string _callType;
    private string _severitylevel;
    private string _engineer;
    private string _StartDate;
    private string _StartTime;
    private string _responsetimeinminutes;
    private string _allowedResponseTimeinminutes;
    private string _closeddate;
    private string _closedTime;
    private string _resolutionTimeinMinutes;
    private string _allowedResolutionTimeinMinutes;
    private string _CallStatus;
    private string _CaseHistoryLastUpdate;
    private string _SLAType;
   


    #endregion



    #region Public Fields
    public string Customername
    {
        get { return _customername; }
        set { _customername = value; }
    }
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    public string CallNo
    {
        get { return _callNo; }
        set { _callNo = value; }
    }
    public string LogDate
    {
        get { return _logDate; }
        set { _logDate = value; }
    }
    public string Logtime
    {
        get { return _Logtime; }
        set { _Logtime = value; }
    }
    public string User
    {
        get { return _user; }
        set { _user = value; }
    }
    public string ProblemDesc
    {
        get { return _problemDesc; }
        set { _problemDesc = value; }
    }
    public string CallType
    {
        get { return _callType; }
        set { _callType = value; }
    }
    public string Severitylevel
    {
        get { return _severitylevel; }
        set { _severitylevel = value; }
    }
    public string Engineer
    {
        get { return _engineer; }
        set { _engineer = value; }
    }
    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
    public string StartTime
    {
        get { return _StartTime; }
        set { _StartTime = value; }
    }
    public string Responsetimeinminutes
    {
        get { return _responsetimeinminutes; }
        set { _responsetimeinminutes = value; }
    }
    public string AllowedResponseTimeinminutes
    {
        get { return _allowedResponseTimeinminutes; }
        set { _allowedResponseTimeinminutes = value; }
    }
    public string Closeddate
    {
        get { return _closeddate; }
        set { _closeddate = value; }
    }
    public string ClosedTime
    {
        get { return _closedTime; }
        set { _closedTime = value; }
    }
    public string ResolutionTimeinMinutes
    {
        get { return _resolutionTimeinMinutes; }
        set { _resolutionTimeinMinutes = value; }
    }
    public string AllowedResolutionTimeinMinutes
    {
        get { return _allowedResolutionTimeinMinutes; }
        set { _allowedResolutionTimeinMinutes = value; }
    }
    public string CallStatus
    {
        get { return _CallStatus; }
        set { _CallStatus = value; }
    }
    public string CaseHistoryLastUpdate
    {
        get { return _CaseHistoryLastUpdate; }
        set { _CaseHistoryLastUpdate = value; }
    }
    public string SLAType
    {
        get { return _SLAType; }
        set { _SLAType = value; }
    }
   

    #endregion

	public csm_calls()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region Public Methods



    //public BLLCollection<csm_CaseHistory_trans> Get_All()
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_csm_CaseHistory_trans_All();
    //}

    public csm_calls Get_By_id(string callno)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.csm_calls_Get_By_ComplaintId(callno);
    }

    public BLLCollection<csm_calls> Get_All_By_Complaintdate(string Fromdate, string Todate)
    {
        SqlDataProvider db = new SqlDataProvider();


        return db.Get_csm_calls_All_By_ComplaintDate(Fromdate, Todate);
    }


    #endregion
}
