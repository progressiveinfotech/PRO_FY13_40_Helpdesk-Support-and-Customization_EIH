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
/// Summary description for State_mst
/// </summary>
public class State_mst
{
    #region Private Fields
    private string _statename;
    private int _stateid;
    private int _countryid;
    #endregion

    #region Public Fields
    public string Statename
    {
        get { return _statename; }
        set { _statename = value; }
    }
    public int Stateid
    {
        get { return _stateid; }
        set { _stateid = value; }
    }
    public int Countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    #endregion
    #region Constructors
    public State_mst()
    {
    }
    public State_mst(string statename, int stateid, int countryid)
    {
        _statename = statename;
        _stateid = stateid;
        _countryid = countryid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_State_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_State_mst_By_id(this);
    }

    public int Delete(int stateid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_State_mst_By_id(stateid);
    }
    public BLLCollection<State_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_State_mst_All();
    }

    public int Get_By_StateName(string statename)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.State_mst_Get_By_StateName(statename);
    }

    public State_mst Get_By_Stateid(int stateid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.State_mst_Get_By_stateid(stateid);
    }

    #endregion

   
}
