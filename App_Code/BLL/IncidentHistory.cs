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
/// Summary description for IncidentHistory
/// </summary>
public class IncidentHistory
{
    #region Private Fields
    private string  _operationtime;
    private int _operationownerid;
    private string _operation;
    private int _incidentid;
    private int _historyid;
    private string _description;
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
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
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

    #region Constructors
    public IncidentHistory()
    {
    }
    public IncidentHistory(string operationtime, int operationownerid, string operation, int incidentid, int historyid, string description)
    {
        _operationtime = operationtime;
        _operationownerid = operationownerid;
        _operation = operation;
        _incidentid = incidentid;
        _historyid = historyid;
        _description = description;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentHistory_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentHistory_mst_By_id(this);
    }
    public int Delete(int historyid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentHistory_mst_By_id(historyid);
    }


    public BLLCollection<IncidentHistory> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentHistory_mst_All();
    }
    public IncidentHistory Get_By_id(int historyid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentHistory_mst_Get_By_historyid(historyid);
    }
    public int Get_Current_IncidentHistoryid()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentHistory_mst_Get_Current_IncidentHistoryid();
    }

    public BLLCollection<IncidentHistory> Get_All_By_Incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentHistory_mst_All_By_incidentid(incidentid);
    }
    public int Delete_By_Incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentHistory_mst_By_incidentid(incidentid);
    }

    #endregion
}
