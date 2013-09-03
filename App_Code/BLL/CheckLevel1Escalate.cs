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
/// Summary description for CheckLevel1Escalate
/// </summary>
public class CheckLevel1Escalate
{
    #region Private Fields
    private bool _level1escalate;
    private int _incidentid;
    #endregion

    #region Public Fields
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
    public CheckLevel1Escalate()
    {
    }
    public CheckLevel1Escalate(bool level1escalate, int incidentid)
    {
        _level1escalate = level1escalate;
        _incidentid = incidentid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CheckLevel1Escalate(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_CheckLevel1Escalate_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_CheckLevel1Escalate_By_id(incidentid);
    }
    public BLLCollection<CheckLevel1Escalate> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_CheckLevel1Escalate_All();
    }

    public CheckLevel1Escalate Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.CheckLevel1Escalate_Get_By_incidentid(incidentid);
    }


    #endregion

}
