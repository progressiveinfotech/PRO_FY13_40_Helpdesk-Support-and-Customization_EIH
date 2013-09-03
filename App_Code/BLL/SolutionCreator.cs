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
/// Summary description for SolutionCrerator
/// </summary>
public class SolutionCreator
{
    #region Private Fields
    private int _Solutionid;
    private int _createdby;
    private string _createDatetime;
    private int _lastUpdateBy;
    private string _lastUpdateon;
    #endregion
    #region Public Fields
    public int Solutionid
    {
        get { return _Solutionid; }
        set { _Solutionid = value; }
    }

    public int Createdby
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
    public string CreateDatetime
    {
        get { return _createDatetime; }
        set { _createDatetime = value; }
    }
    public int LastUpdateBy
    {
        get { return _lastUpdateBy; }
        set { _lastUpdateBy = value; }
    }
    public string LastUpdateon
    {
        get { return _lastUpdateon; }
        set { _lastUpdateon = value; }
    }

#endregion
    
    #region Constructor
    public SolutionCreator()
    {
    }

    public SolutionCreator(int solutionid, int createdby)
    {
        _Solutionid = solutionid;
        _createdby = createdby;
    }

    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_SolutionCreator_mst(this);
    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
      return  db.Update_SolutionCreator_mst_By_id(this);
    }

    public int Delete(int Solutionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_SolutionCreator_mst_By_id(Solutionid);
    }
    public SolutionCreator Get_By_id(int Solutionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        
        return db.SolutionCreator_mst_Get_By_Solutionid(Solutionid);
    } 

    #endregion
}
