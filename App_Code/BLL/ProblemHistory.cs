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
/// Summary description for ProblemHistory
/// </summary>
public class ProblemHistory
{
    #region Private Fields
    private string _operationtime;
    private int _operationownerid;
    private string _operation;
    private int _Problemid;
    private int _historyid;
    private string _description;
    #endregion
    #region Constructor Fields
    public ProblemHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public ProblemHistory(string operationtime, int operationownerid, string operation, int problemid, int historyid, string description)
    {
        _operationtime = operationtime;
        _operationownerid = operationownerid;
        _operation = operation;
      _Problemid = problemid;
        _historyid = historyid;
        _description = description;
    }
#endregion
    #region Public Fields
    public string Operationtime
    {
        get { return _operationtime; }
        set { _operationtime = value; }
    }
    public int Operationownerid
    {
        get { return _operationownerid; }
        set { _operationownerid = value; }
    }
    public string Operation
    {
        get { return _operation; }
        set { _operation = value; }
    }
    public int Problemid
    {
        get { return _Problemid; }
        set { _Problemid = value; }
    }
    public int Historyid
    {
        get { return _historyid; }
        set { _historyid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ProblemHistory_mst(this);

    }
    public int Get_Current_ProblemHistoryid()
    {
        SqlDataProvider db = new SqlDataProvider();
      
        return db.ProblemHistory_mst_Get_Current_ProblemHistoryid();
    }
    public BLLCollection<ProblemHistory> Get_All_By_Problemid(int problemid)
    {
        SqlDataProvider db = new SqlDataProvider();
        //return db.Get_IncidentHistory_mst_All_By_incidentid(incidentid);
        return db.Get_ProblemHistory_mst_All_By_problemid(problemid);
    }
    #endregion

}
