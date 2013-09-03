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
/// Summary description for IncidentResolution
/// </summary>
public class IncidentResolution
{
    #region Private Fields
    private string _resolution;
    private string _lastupdatetime;
    private int _incidentid;
    private int _userid;

    #endregion

    #region Public Fields
    public string Resolution
    {
        get { return _resolution; }
        set { _resolution = value; }
    }
    public string Lastupdatetime
    {
        get { return _lastupdatetime; }
        set { _lastupdatetime = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    public int Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    #endregion


    #region Constructors
    public IncidentResolution()
    {
    }
    public IncidentResolution(string resolution, string lastupdatetime, int incidentid)
    {
        _resolution = resolution;
        _lastupdatetime = lastupdatetime;
        _incidentid = incidentid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentResolution(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentResolution_By_id(this);
    }
    public int Delete(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentResolution_By_id(incidentid);
    }

    public BLLCollection<IncidentResolution> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentResolution_All();
    }

    public IncidentResolution Get_By_id(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentResolution_Get_By_incidentid(incidentid);
    }

    public BLLCollection<IncidentResolution> Get_All_By_incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentResolution_All_By_incidentid(incidentid);
    }


    #endregion
}
