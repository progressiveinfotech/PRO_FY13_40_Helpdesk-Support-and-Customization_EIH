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
/// Summary description for CheckEmailEscalate
/// </summary>
public class CheckEmailEscalate
{
    #region Private Fields
    private bool _level3escalate;
    private bool _level2escalate;
    private bool _level1escalate;
    private int _incidentid;
    #endregion

    #region Public Fields
    public bool Level3escalate
    {
        get { return _level3escalate; }
        set { _level3escalate = value; }
    }
    public bool Level2escalate
    {
        get { return _level2escalate; }
        set { _level2escalate = value; }
    }
    public bool Level1escalate
    {
        get { return _level1escalate; }
        set { _level1escalate = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    #endregion

    #region Constructors
    public CheckEmailEscalate()
    {
    }
    public CheckEmailEscalate(bool level3escalate, bool level2escalate, bool level1escalate, int incidentid)
    {
        _level3escalate = level3escalate;
        _level2escalate = level2escalate;
        _level1escalate = level1escalate;
        _incidentid = incidentid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CheckEmailEscalate(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_CheckEmailEscalate_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_CheckEmailEscalate_By_id(incidentid );
    }
    public BLLCollection<CheckEmailEscalate> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_CheckEmailEscalate_All();
    }

    public CheckEmailEscalate Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.CheckEmailEscalate_Get_By_incidentid(incidentid);
    }


    #endregion
}
