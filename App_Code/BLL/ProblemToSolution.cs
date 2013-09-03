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
/// Summary description for ProblemToSolution
/// </summary>
public class ProblemToSolution
{
    #region Private Fields
   
    private int _Problemid;
    private int _WorkAroundid;
    private int _Solutionid;
    private string _Solutiontype;


    #endregion
    #region Public Fields
    public int Problemid
    {
        get { return _Problemid; }
        set { _Problemid = value; }
    }

    public int WorkAroundid
    {
        get { return _WorkAroundid; }
        set { _WorkAroundid = value; }
    }
    public string Solutiontype
    {
        get { return _Solutiontype; }
        set { _Solutiontype = value; }
    }
    public int Solutionid
    {
        get { return _Solutionid; }
        set { _Solutionid = value; }
    }
    
    #endregion
    #region Constructor Fields
   public ProblemToSolution()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public ProblemToSolution(int Problemid,int Workaroundid,int Solutionid,string SolutionType)
    {
        _Problemid = Problemid;
        _WorkAroundid=Workaroundid;
        _Solutionid=Solutionid;
        _Solutiontype = SolutionType;
    }
    #endregion
   #region Public Methods
   public int Insert()
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Insert_ProblemToSlotion_mst(this);

   }
   public ProblemToSolution Get_By_id(int problemid)
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.ProblemTosolution_mst_Get_By_problemid(problemid);
   }
   public BLLCollection<ProblemToSolution> Get_All_Problemid(int Problemid)
   {
       SqlDataProvider db = new SqlDataProvider();
       return db.Get_ProblemToSolution_mst_All_By_Problemid(Problemid);
   }
  
   #endregion

}
