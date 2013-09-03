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
/// Summary description for ProblemSymptom
/// </summary>
public class ProblemSymptom
{
     #region Private Fields
   
    private int _Problemid;
    private int _Symptomid;
    private string _Description;
    #endregion
    #region Public Fields
    public int Problemid
    {
        get { return _Problemid; }
        set { _Problemid = value; }
    }

   
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public int Symtomid
    {
        get { return _Symptomid; }
        set {_Symptomid = value; }
    }

    #endregion
	
    #region Constructor Fields
   public ProblemSymptom()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public ProblemSymptom(int Problemid, int Symtomid,string Description)
    {
        _Problemid = Problemid;

        _Description = Description;
        _Symptomid = Symtomid;

    }
    #endregion
   #region Public Methods
   public int Insert()
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Insert_ProblemSymptom_mst(this);

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
       return db.Update_ProblemSymptom_By_id(this);
   }
   public ProblemSymptom Get_By_id(int problemid)
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.ProblemSymptom_mst_Get_By_problemid(problemid);
   }
   #endregion

	
}
