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
/// Summary description for CheckLevel3Escalate
/// </summary>
public class CheckLevel3Escalate
{
    #region Private Fields
    private bool _level3escalate;
    private int _incidentid;
    #endregion

    #region Public Fields
    public bool Level3escalate
    {
        get { return _level3escalate; }
        set { _level3escalate = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    #endregion

    #region Constructors
    public CheckLevel3Escalate()
    {
    }
    public CheckLevel3Escalate(bool level3escalate, int incidentid)
    {
        _level3escalate = level3escalate;
        _incidentid = incidentid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CheckLevel3Escalate(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_CheckLevel3Escalate_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_CheckLevel3Escalate_By_id(incidentid);
    }
    public BLLCollection<CheckLevel3Escalate> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_CheckLevel3Escalate_All();
    }

    public CheckLevel3Escalate Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.CheckLevel3Escalate_Get_By_incidentid(incidentid);
    }


    #endregion
}
