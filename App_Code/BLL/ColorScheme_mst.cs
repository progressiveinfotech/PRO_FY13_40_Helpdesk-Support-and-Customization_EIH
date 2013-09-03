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
/// Summary description for ColorScheme_mst
/// </summary>
public class ColorScheme_mst
{
    #region Private Fields
    private int _percnt;
    private string _colorname;
    private int _colorid;
    private int _percnt_to;
    private string _callStatus;
    #endregion

    #region Public Fields
    public int Percnt_to
    {
        get { return _percnt_to; }
        set { _percnt_to = value; }
    }
    public int Percnt
    {
        get { return _percnt; }
        set { _percnt = value; }
    }
    public string Colorname
    {
        get { return _colorname; }
        set { _colorname = value; }
    }
    public int Colorid
    {
        get { return _colorid; }
        set { _colorid = value; }
    }
    public string CallStatus
    {
        get { return _callStatus; }
        set { _callStatus = value; }
    }
    #endregion

    #region Constructors
    public ColorScheme_mst()
    {
    }
    public ColorScheme_mst(int percnt, string colorname, int colorid,int percnt_to,string CallStatus)
    {
        _percnt = percnt;
        _colorname = colorname;
        _colorid = colorid;
        _percnt_to = percnt_to;
        _callStatus = CallStatus;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ColorScheme_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ColorScheme_mst_By_id(this);
    }

    

    public int Delete(int colorid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ColorScheme_mst_By_id(colorid);
    }
    public BLLCollection<ColorScheme_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ColorScheme_mst_All();
    }

    public ColorScheme_mst Get_By_id(int colorid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ColorScheme_mst_Get_By_id(colorid);
    }
    public ColorScheme_mst Get_By_colorName(string colorname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ColorScheme_mst_Get_By_colorName(colorname);
    }

    public BLLCollection<ColorScheme_mst> Get_All_By_CallStatus(string callStatus)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ColorScheme_mst_All_By_CallStatus(callStatus);
    }

    public int Check_Colorname(string colorname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Colorname_From_ColorScheme(colorname);
    }


    #endregion
}
