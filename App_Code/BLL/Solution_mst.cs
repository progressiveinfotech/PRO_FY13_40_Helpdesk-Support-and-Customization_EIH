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
/// Summary description for Solution_mst
/// </summary>
public class Solution_mst
{
#region Private Fields
    private int _Solutionid;
    private string _Title;
    private string _Content;
    private int _Topicid;
    private string _Solution;
    private string _Comments;
    private int _Solutionstatusid;

#endregion

# region Public Fields
    public int Solutionid 
    {

        get { return _Solutionid; }
        set { _Solutionid = value; }
    
    }

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    
    
    }
    public string Content
    {
        get { return _Content; }
        set { _Content = value; }


    }

    public int Topicid
    {
        get { return _Topicid; }
        set { _Topicid = value; }


    }

    public string Solution
    {
        get { return _Solution; }
        set { _Solution = value; }


    }

    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }


    }

    public int SolutionStatus
    {
        get { return _Solutionstatusid; }
        set { _Solutionstatusid = value; }


    }




    #endregion

#region Constructor
    public Solution_mst()
    { }

    public Solution_mst(int Solutionid, string Title, string Content, int Topicid, string Solution, string comments, int Solutionstatusid)
    {
        _Solutionid = Solutionid;
        _Title = Title;
        _Content = Content;
        _Topicid = Topicid;
        _Solution = Solution;
        _Comments = comments;
        _Solutionstatusid = Solutionstatusid;
    
    }
    #endregion
#region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
      return  db.Insert_Solution_mst(this);
    }

    public int Update ()
    {
        SqlDataProvider db = new SqlDataProvider();
     return   db.Update_Solution_mst_By_id(this);
    }

    public int Delete(int Solutionid)
    {
        SqlDataProvider db =new SqlDataProvider();
        return db.Delete_Solution_mst_By_id(Solutionid);
    }
    public BLLCollection<Solution_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Solution_mst_All();
    }
    public Solution_mst Get_By_id(int Solutionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Solution_mst_Get_By_Solutionid(Solutionid);
    }
    public BLLCollection<Solution_mst> Get_SearchSolution_All(string  keywords)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SearchSolution_mst_All(keywords);
    }
    public BLLCollection<Solution_mst> Get_All_By_Filterid(string filterid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Solution_mst_All_By_Filterid(filterid);
    }
#endregion






}
