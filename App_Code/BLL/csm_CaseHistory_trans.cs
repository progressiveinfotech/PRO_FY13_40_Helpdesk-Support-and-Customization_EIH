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
/// Summary description for csm_CaseHistory_trans
/// </summary>
public class csm_CaseHistory_trans
{
    #region Private Fields
    private string _complaintId;
    private string _compId;
    private string _orgId;
    private string _itemId;
    private string _complaintStatus;
    private string _username;
    private string _engineerId;
    private string _callLognotes;
    private string _complaintdate;
    private string _changedstatusdate;
    private string _pendingreason;
    

    #endregion
        
    #region Public Fields
    public string ComplaintId
    {
        get { return _complaintId; }
        set { _complaintId = value; }
    }
    public string CompId
    {
        get { return _compId; }
        set { _compId = value; }
    }
    public string OrgId
    {
        get { return _orgId; }
        set { _orgId = value; }
    }
    public string ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }
    public string ComplaintStatus
    {
        get { return _complaintStatus; }
        set { _complaintStatus = value; }
    }
    public string UserName
    {
        get { return _username; }
        set { _username = value; }
    }
    public string EngineerId
    {
        get { return _engineerId; }
        set { _engineerId = value; }
    }
    public string CallLogNotes
    {
        get { return _callLognotes; }
        set { _callLognotes = value; }
    }
    public string ComplaintDate
    {
        get { return _complaintdate; }
        set { _complaintdate = value; }
    }
    public string ChangedStatusDate
    {
        get { return _changedstatusdate; }
        set { _changedstatusdate = value; }
    }
    public string PendingReason
    {
        get { return _pendingreason; }
        set { _pendingreason = value; }
    }
    
    #endregion

    #region Public Methods



    //public BLLCollection<csm_CaseHistory_trans> Get_All()
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_csm_CaseHistory_trans_All();
    //}

    public csm_CaseHistory_trans Get_By_id(string ComplaintId)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.csm_CaseHistory_trans_Get_By_ComplaintId(ComplaintId);
    }

    public BLLCollection<csm_CaseHistory_trans> Get_All_By_ComplaintId(string ComplaintId)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_csm_CaseHistory_trans_All_By_ComplaintId(ComplaintId);
    }


    #endregion
}
