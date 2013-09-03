using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Asset_Software_mst
/// </summary>
public class Asset_Software_mst
{
    #region Private Fields
    private string _inventorydate;
    private string _computername;
    private int _assetid;
    private int _assetsoftwared;
    private string _domainname;
    private string _software_name;
    private string _software_manufacturer;
    private string _install_directory;
    private string _installed_on;
    private string _software_version;
    private string _software_version_major;
    private string _software_version_minor;
    private string _software_registered_to;
    private string _software_registration_code;
    private string _software_registered_organization;
    private string _software_product_key;

    #endregion

    #region Public Fields
    public string Inventorydate
    {
        get { return _inventorydate; }
        set { _inventorydate = value; }
    }
    public string Computername
    {
        get { return _computername; }
        set { _computername = value; }
    }
    public string Domainname
    {
        get { return _domainname; }
        set { _domainname = value; }
    }
    public int Assetid
    {
        get { return _assetid; }
        set { _assetid = value; }
    }
    public int AssetSoftwareid
    {
        get { return _assetsoftwared; }
        set { _assetsoftwared = value; }
    }
    public string Software_name
    {
        get { return _software_name; }
        set { _software_name = value; }
    }

    public string Software_manufacturer
    {
        get { return _software_manufacturer; }
        set { _software_manufacturer = value; }
    }

    public string Install_directory
    {
        get { return _install_directory; }
        set { _install_directory = value; }
    }

    public string Installed_on
    {
        get { return _installed_on; }
        set { _installed_on = value; }
    }
    public string Software_version
    {
        get { return _software_version; }
        set { _software_version = value; }
    }
    public string Software_version_major
    {
        get { return _software_version_major; }
        set { _software_version_major = value; }
    }

    public string Software_version_minor
    {
        get { return _software_version_minor; }
        set { _software_version_minor = value; }
    }

    public string Software_registered_to
    {
        get { return _software_registered_to; }
        set { _software_registered_to = value; }
    }

    public string Software_registration_code
    {
        get { return _software_registration_code; }
        set { _software_registration_code = value; }
    }

    public string Software_registered_organization
    {
        get { return _software_registered_organization; }
        set { _software_registered_organization = value; }
    }
    public string Software_product_key
    {
        get { return _software_product_key; }
        set { _software_product_key = value; }
    }
    #endregion
    #region Constructors
    public Asset_Software_mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Asset_Software_mst(int assetsoftwareid, string inventorydate, string computername, string domainname, int assetid, string Softwarename, string Softwaremanufacturer, string Installdirectory, string Installedon, string Softwareversion, string Softwareversionmajor, string Softwareversionminor, string Softwareregisteredto, string Softwareregistrationcode, string Softwareregisteredorganization, string Softwareproductkey)
    {
        _inventorydate = inventorydate;
        _computername = computername;
        _domainname = domainname;
        _assetid = assetid;
        _assetsoftwared = assetsoftwareid;
        _software_name = Softwarename;
        _software_manufacturer = Softwaremanufacturer;
        _install_directory = Installdirectory;
        _installed_on = Installedon;
        _software_version = Softwareversion;
        _software_version_major = Softwareversionmajor;
        _software_version_minor = Softwareversionminor;
        _software_registered_to = Softwareregisteredto;
        _software_registration_code = Softwareregistrationcode;
        _software_registered_organization = Softwareregisteredorganization;
        _software_product_key = Softwareproductkey;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Asset_Software_mst(this);

    }
    #endregion
}
