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
/// Summary description for Holiday_mst
/// </summary>
public class Holiday_mst
{
    #region Private Fields
    private int _siteid;
    private int _holidayid;
    private String _holidaydate;
    private string _description;
    #endregion

    #region Public Fields
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public int Holidayid
    {
        get { return _holidayid; }
        set { _holidayid = value; }
    }
    public String Holidaydate
    {
        get { return _holidaydate; }
        set { _holidaydate = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    //public string Sitename
    //{
    //    get { return _sitename; }
    //    set { _sitename = value; }
    //}
    #endregion

    #region Constructors
    public Holiday_mst()
    {
    }
    public Holiday_mst(int siteid, int holidayid, String holidaydate, string description)
    {
        _siteid = siteid;
        _holidayid = holidayid;
        _holidaydate = holidaydate;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Holiday_mst(this);

    }

    public BLLCollection<Holiday_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Holiday_mst_All();
    }

    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Holiday_mst_By_id(this);
    }
    public int Delete(int holidayid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Holiday_mst_By_id(holidayid);
    }

    public BLLCollection<Holiday_mst> Get_Holiday_By_SiteId(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Holiday_All_By_SiteId(siteid);
    }
    public int Get_By_HolidayDate_Siteid(int siteid, string hdate)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Holiday_mst_Get_By_HolidayDate_Siteid(siteid, hdate);
    }

    public Holiday_mst Get_Description_By_Holidayid(int holidayid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Holidaydesc_Desc_By_Holidayid(holidayid);

    }
    #endregion
}
