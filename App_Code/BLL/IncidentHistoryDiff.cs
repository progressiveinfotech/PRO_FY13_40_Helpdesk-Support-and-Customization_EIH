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
/// Summary description for IncidentHistoryDiff
/// </summary>
public class IncidentHistoryDiff
{
    #region Private Fields
    private string _prev_value;
    private int _historyid;
    private int _historydiffid;
    private string _current_value;
    private string _columnname;
    #endregion

    #region Public Fields
    public string Prev_value
    {
        get { return _prev_value; }
        set { _prev_value = value; }
    }
    public int Historyid
    {
        get { return _historyid; }
        set { _historyid = value; }
    }
    public int Historydiffid
    {
        get { return _historydiffid; }
        set { _historydiffid = value; }
    }
    public string Current_value
    {
        get { return _current_value; }
        set { _current_value = value; }
    }
    public string Columnname
    {
        get { return _columnname; }
        set { _columnname = value; }
    }
    #endregion

    #region Constructors
    public IncidentHistoryDiff()
    {
    }
    public IncidentHistoryDiff(string prev_value, int historyid, int historydiffid, string current_value, string columnname)
    {
        _prev_value = prev_value;
        _historyid = historyid;
        _historydiffid = historydiffid;
        _current_value = current_value;
        _columnname = columnname;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_IncidentHistoryDiff_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_IncidentHistoryDiff_mst_By_id(this);
    }
    public int Delete(int historydiffid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentHistoryDiff_mst_By_id(historydiffid);
    }


    public BLLCollection<IncidentHistoryDiff> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentHistoryDiff_mst_All();
    }
    public IncidentHistoryDiff Get_By_id(int historydiffid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.IncidentHistoryDiff_mst_Get_By_historydiffid(historydiffid);
    }


    public BLLCollection<IncidentHistoryDiff> Get_All_By_Historyid(int historyid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_IncidentHistoryDiff_mst_All_By_Historyid(historyid);
    }

    public int Delete_By_Historyid(int historyid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_IncidentHistoryDiff_mst_By_historyid(historyid);
    }

    #endregion

}
