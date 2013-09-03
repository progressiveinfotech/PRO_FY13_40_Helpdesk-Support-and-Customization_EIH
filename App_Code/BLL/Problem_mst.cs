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
/// Summary description for Problem_mst
/// </summary>
public class Problem_mst
{
#region Private Fields


    private int _ProblemId;
    private int _CreatedByid;
    private int _Requesterid;
    private int _technicianid;
    private int _categoryid;
    private int _statusid;
    private int _priorityid;
    private int _Subcategoryid;
    private string _Title;
    private string _description;
    private string _CreateDatetime;
    private string _Closedatetime;
    private string _CompletedTime; 
    private string _AssignedTime;
    private bool _Active;

#endregion
#region Public Fields
    public int ProblemId
    {
        get { return _ProblemId; }
        set { _ProblemId = value; }
    }
    public int CreatedByid
    {
        get { return _CreatedByid; }
        set { _CreatedByid = value; }
    }
    public int Requesterid
    {
        get { return _Requesterid; }
        set { _Requesterid = value; }
    }
    public int Technicianid
    {
        get { return _technicianid; }
        set { _technicianid = value; }
    }
    public int Categoryid
    {
        get { return _categoryid; }
        set { _categoryid = value; }
    }
    public int Statusid
    {
        get { return _statusid; }
        set { _statusid = value; }
    }
    public int Priorityid
    {
        get { return _priorityid; }
        set { _priorityid = value; }
    }
    public int Subcategoryid
    {
        get { return _Subcategoryid; }
        set { _Subcategoryid = value; }
    }
    public string title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string CreateDatetime
    {
        get { return _CreateDatetime; }
        set { _CreateDatetime = value; }
    }
    public string Closedatetime
    {
        get { return _Closedatetime; }
        set { _Closedatetime = value; }
    }
    public string CompletedTime
    {
        get { return _CompletedTime; }
        set { _CompletedTime = value; }
    }
    public string AssginedTime
    {
        get { return _AssignedTime; }
        set { _AssignedTime = value; }
    }
    public bool  Active
    {
        get { return _Active; }
        set { _Active = value; }
    }
 
    #endregion
#region Public Method
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Problem_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Problem_By_id(this);
    }
    public int Delete(int Problemid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Problem_By_id(Problemid);
    }
    public BLLCollection<Problem_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Problem_All();
    }
    public int Get_Current_Problemid()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Problem_mst_Get_Current_Problemid();
    }
    public BLLCollection<Problem_mst> Get_All_Problemid(int Problemid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Problem_mst_All_By_Problemid(Problemid);
    }
    public  Problem_mst Get_By_id(int problemid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Problem_mst_Get_By_problemid(problemid);
    }
    public BLLCollection<Problem_mst> Get_All_By_Statusid_technicianid(int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
       
        return db.Get_Problem_mst_All_By_statusid_technicianid(statusid, technicianid, fromdate, todate, varSortParameter);
    }
    public BLLCollection<Problem_mst> Get_All_By_Createdbyid(string fromdate, string todate, int technicianid, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        
       
        return db.Get_Problem_mst_All_By_Createdbyid(fromdate, todate, technicianid, varSortParameter);
    }

    public BLLCollection<Problem_mst> Get_All_By_Statusid(int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();

        return db.Get_Problem_mst_All_By_statusid(statusid, fromdate, todate, technicianid, varSortParameter);
        
      
        
    }
    public BLLCollection<Problem_mst> Get_All_By_Statusid_Unassigned(int statusid, string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Problem_mst_All_By_statusid_Unassigned(statusid, fromdate, todate, varSortParameter);
    }
    public BLLCollection<Problem_mst> Get_All_By_Assigned(string fromdate, string todate, string varSortParameter)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Problem_mst_All_By_Assigned(fromdate, todate, varSortParameter);
    }

    public BLLCollection<Problem_mst> Get_All_Problemidid_By_SearchParameter(string Filterid, string keyword)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Problem_mst_All_By_SearchParameter(Filterid, keyword);
    }
#endregion

    public Problem_mst()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
