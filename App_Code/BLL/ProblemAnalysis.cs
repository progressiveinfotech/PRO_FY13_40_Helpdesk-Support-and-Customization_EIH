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
/// Summary description for ProblemAnalysis
/// </summary>
public class ProblemAnalysis
{
    #region Private Fields
   
    private int _Problemid;
    private string _Impact;
    private string _RootCause;
    private string _Symptom;



    #endregion
    #region Public Fields
    public int Problemid
    {
        get { return _Problemid; }
        set { _Problemid = value; }
    }

    public string Impact
    {
        get { return _Impact; }
        set { _Impact = value; }
    }
    public string RootCause
    {
        get { return _RootCause; }
        set { _RootCause = value; }
    }
    public string Symtom
    {
        get { return _Symptom; }
        set { _Symptom = value; }
    }

    #endregion
	
    #region Constructor Fields
   public ProblemAnalysis()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public ProblemAnalysis(int Problemid, string Impact, string RootCause, string Symtom)
    {
        _Problemid = Problemid;
        _Impact = Impact;
        _RootCause=RootCause;
        _Symptom = Symtom;

    }
    #endregion
   #region Public Methods
   public int Insert()
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Insert_ProblemAnalysis_mst(this);

   }
   //public int Get_Current_ProblemHistoryid()
   //{
   //    SqlDataProvider db = new SqlDataProvider();

   //    return db.ProblemHistory_mst_Get_Current_ProblemHistoryid();
   //}
   public BLLCollection<ProblemNotes> Get_All_By_Problemid(int problemid)
   {
       SqlDataProvider db = new SqlDataProvider();
       //return db.Get_IncidentHistory_mst_All_By_incidentid(incidentid);
       return db.Get_ProblemNotes_mst_All_By_problemid(problemid);
   }

   public int Update()
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Update_ProblemAnalysis_By_id(this);
   }
   public ProblemAnalysis Get_By_id(int problemid)
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.ProblemAnalysis_mst_Get_By_problemid(problemid);
   }
   #endregion
    
}
