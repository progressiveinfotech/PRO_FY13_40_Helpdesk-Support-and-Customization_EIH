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
/// Summary description for Vendor_mst
/// </summary>
public class Vendor_mst
{
    #region Private Fields
    private string _vendorname;
    private int _vendorid;
    private string _contactperson;
    #endregion

    #region Public Fields
    public string Vendorname
    {
        get { return _vendorname; }
        set { _vendorname = value; }
    }
    public int Vendorid
    {
        get { return _vendorid; }
        set { _vendorid = value; }
    }
    public string Contactperson
    {
        get { return _contactperson; }
        set { _contactperson = value; }
    }
    #endregion

    #region Constructors
    public Vendor_mst()
    {
    }
    public Vendor_mst(string vendorname, int vendorid, string contactperson)
    {
        _vendorname = vendorname;
        _vendorid = vendorid;
        _contactperson = contactperson;
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Vendor_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Vendor_mst_By_id(this);
    }
    public int Delete(int vendorid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Vendor_mst_By_id(vendorid);
    }
    public BLLCollection<Vendor_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Vendor_All();
    }
    public Vendor_mst Get_By_id(int vendorid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Vendor_mst_Get_By_vendorid(vendorid);
    }
    public int Get_Vendor_By_Vname(String Vname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Vendor_By_Vname(Vname);
    }
   
    #endregion
}
