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
/// Summary description for SolutionKeyword
/// </summary>
public class SolutionKeyword
{
    #region Private Field
    int _keywordid;
    int _solutionid;
    string _Keywords;

    #endregion
    #region Public Fields
    public int Keywordid
    {

        get { return _keywordid; }
        set { _keywordid = value; }

    }

    public int Solutionid
    {
        get { return _solutionid; }
        set { _solutionid = value; }
    }

    public string Keywords
    {
        get { return _Keywords; }
        set { _Keywords = value; }
    }
    #endregion
    #region Constructur
    public SolutionKeyword()
    {
    }

    public SolutionKeyword(int keywordid, int solutionid, string keywords)
    {
        _keywordid = keywordid;
        _solutionid = solutionid;
        _Keywords = keywords;
    
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_SolutionKeyword_mst(this);

    }
    public int Update() 
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_SolutionKeyword_mst_By_id(this);
    
    }

    public int Delete(int Solutionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_SolutionKeyword_mst_By_id(Solutionid);
    }
    public int Get_SolutionId()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.SolutionKeyword_Get_SolutionId();
    }
    public SolutionKeyword Get_By_id(int Solutionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.SolutionKeyword_mst_Get_By_Solutionid(Solutionid);
    } 

    #endregion





}
