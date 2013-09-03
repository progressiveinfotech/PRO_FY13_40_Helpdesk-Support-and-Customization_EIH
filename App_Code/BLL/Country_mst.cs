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
/// Summary description for Country_mst
/// </summary>
public class Country_mst
{
    #region Private Fields
    private string _countryname;
    private int _countryid;
    #endregion 
    #region Public Fields
    public string Countryname
    {
        get { return _countryname; }
        set { _countryname = value; }
    }
    public int Countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    #endregion 
    #region Constructors
    public Country_mst()
    {
    }
    public Country_mst(string countryname, int countryid)
    {
        _countryname = countryname;
        _countryid = countryid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Country_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Country_mst_By_id(this);
    }
    public int Delete(int countryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Country_mst_By_id(countryid);
    }
    public BLLCollection<Country_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Country_mst_All();
    }
    public int Get_By_CountryName(string CountryName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Country_mst_Get_By_CountryName(CountryName);
    }
    public Country_mst Get_By_id(int countryid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Country_mst_Get_By_countryid(countryid);
    } 
    #endregion
}
