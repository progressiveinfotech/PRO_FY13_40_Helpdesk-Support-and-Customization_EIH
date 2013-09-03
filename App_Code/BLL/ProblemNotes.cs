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
/// Summary description for ProblemNotes
/// </summary>
public class ProblemNotes
{
    #region Private Fields
    private int _UserName;
    private int _Problemid;
    private string _Comments;
    private string _Date;
  
   
    #endregion

    #region Public Fields
    public int Problemid
    {
        get { return _Problemid; }
        set { _Problemid = value; }
    }
  
    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public int UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    
    #endregion
    #region Constructor Fields
   public ProblemNotes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public ProblemNotes(int Problemid,string Comments,int UserName)
    {
        _Problemid = Problemid;
       
        _Comments = Comments;
               _UserName = UserName;

    }
    #endregion
   #region Public Methods
   public int Insert()
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Insert_ProblemNotes_mst(this);

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
   #endregion

	
}
