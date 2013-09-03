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
/// Summary description for CMDB_trans
/// </summary>
public class CMDB_trans
{
    #region Private Fields
    private string _previousvalue;
    private string _parametername;
    private string _datetime;
    private string _currentvalue;
    private int _assetid;
    #endregion

    #region Public Fields
    public string Previousvalue
    {
        get { return _previousvalue; }
        set { _previousvalue = value; }
    }
    public string Parametername
    {
        get { return _parametername; }
        set { _parametername = value; }
    }
    public string Datetime
    {
        get { return _datetime; }
        set { _datetime = value; }
    }
    public string Currentvalue
    {
        get { return _currentvalue; }
        set { _currentvalue = value; }
    }
    public int Assetid
    {
        get { return _assetid; }
        set { _assetid = value; }
    }
    #endregion

    #region Constructors
    public CMDB_trans()
    {
    }
    public CMDB_trans(string previousvalue, string parametername, string datetime, string currentvalue, int assetid)
    {
        _previousvalue = previousvalue;
        _parametername = parametername;
        _datetime = datetime;
        _currentvalue = currentvalue;
        _assetid = assetid;
    }

    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CMDBTrans_mst(this);

    }
    #endregion
}
