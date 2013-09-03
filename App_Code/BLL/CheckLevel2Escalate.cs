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
/// Summary description for CheckLevel2Escalate
/// </summary>
public class CheckLevel2Escalate
{
    #region Private Fields
    private bool _level2escalate;
    private int _incidentid;
    #endregion

    #region Public Fields
    public bool Level2escalate
    {
        get { return _level2escalate; }
        set { _level2escalate = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    #endregion

    #region Constructors
    public CheckLevel2Escalate()
    {
    }
    public CheckLevel2Escalate(bool level2escalate, int incidentid)
    {
        _level2escalate = level2escalate;
        _incidentid = incidentid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CheckLevel2Escalate(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_CheckLevel2Escalate_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_CheckLevel2Escalate_By_id(incidentid);
    }
    public BLLCollection<CheckLevel2Escalate> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_CheckLevel2Escalate_All();
    }

    public CheckLevel2Escalate Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.CheckLevel2Escalate_Get_By_incidentid(incidentid);
    }


    #endregion
}
