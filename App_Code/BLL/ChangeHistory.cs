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
/// Summary description for ChangeHistory
/// </summary>
public class ChangeHistory
{
	
    #region Private Fields
    private string _operationtime;
    private int _operationownerid;
    private string _operation;
    private int _Changeid;
    private int _historyid;
    private string _description;
    #endregion
    #region Constructor Fields
    public ChangeHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public ChangeHistory(string operationtime, int operationownerid, string operation, int Changeid, int historyid, string description)
    {
        _operationtime = operationtime;
        _operationownerid = operationownerid;
        _operation = operation;
        _Changeid = Changeid;
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
     public int Changeid
     {
         get { return _Changeid; }
         set { _Changeid = value; }
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
     
         return db.Insert_ChangeHistory_mst(this);

     }
     public int Get_Current_ChangeHistoryid()
     {
         SqlDataProvider db = new SqlDataProvider();

     
         return db.ChangeHistory_mst_Get_Current_ChangeHistoryid();
         
     }
     public BLLCollection<ChangeHistory> Get_All_By_Changeid(int changeid)
     {
         SqlDataProvider db = new SqlDataProvider();
         //return db.Get_IncidentHistory_mst_All_By_incidentid(incidentid);
        
         return db.Get_ChangeHistory_mst_All_By_changeid(changeid);
     }
     #endregion
}
