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
/// Summary description for SLA_Priority_mst
/// </summary>
public class SLA_Priority_mst
{
    #region Private Fields
    private int _slaid;
    private int _siteid;
    private int _responsemin;
    private int _responsehours;
    private int _responsedays;
    private int _resolutionmin;
    private int _resolutionhours;
    private int _resolutiondays;
    private int _priorityid;
    #endregion
    #region Public Fields
    public int Slaid
    {
        get { return _slaid; }
        set { _slaid = value; }
    }
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public int Responsemin
    {
        get { return _responsemin; }
        set { _responsemin = value; }
    }
    public int Responsehours
    {
        get { return _responsehours; }
        set { _responsehours = value; }
    }
    public int Responsedays
    {
        get { return _responsedays; }
        set { _responsedays = value; }
    }
    public int Resolutionmin
    {
        get { return _resolutionmin; }
        set { _resolutionmin = value; }
    }
    public int Resolutionhours
    {
        get { return _resolutionhours; }
        set { _resolutionhours = value; }
    }
    public int Resolutiondays
    {
        get { return _resolutiondays; }
        set { _resolutiondays = value; }
    }
    public int Priorityid
    {
        get { return _priorityid; }
        set { _priorityid = value; }
    }
    #endregion

    #region Constructors
    public SLA_Priority_mst()
    {
    }
    public SLA_Priority_mst(int slaid, int responsemin, int responsehours, int responsedays, int resolutionmin, int resolutionhours, int resolutiondays, int priorityid, int siteid)
    {
        _slaid = slaid;
        _siteid = siteid;
        _responsemin = responsemin;
        _responsehours = responsehours;
        _responsedays = responsedays;
        _resolutionmin = resolutionmin;
        _resolutionhours = resolutionhours;
        _resolutiondays = resolutiondays;
        _priorityid = priorityid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_SLA_Priority_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_SLA_Priority_mst_By_id(this);
    }
    public int Delete(int slaid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_SLA_Priority_mst_By_id(slaid);
    }
    public SLA_Priority_mst Get_By_Siteid(int  siteid, int priorityid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SLA_Priority_By_Siteid(siteid, priorityid);
    }
    public SLA_Priority_mst Get_By_id(int Slaid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_SLA_Priority_By_Slaid(Slaid);
    }
    #endregion
}
