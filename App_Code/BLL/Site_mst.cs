using System;

/// <summary>
/// Summary description for Site_mst
/// </summary>
public class Site_mst
{
    #region Private Fields
    private string _website;
    private int _timezoneid;
    private string _state;
    private string _sitename;
    private int _siteid;
    private int _regionid;
    private string _postalcode;
    private string _phoneno;
    private string _mobileno;
    private string _faxno;
    private bool _enable;
    private string _emailid;
    private string _description;
    private string  _createdatetime;
    private int _countryid;
    private string _contactpersonname;
    private string _city;
    private string _address;
    #endregion

    #region Public Fields
    public string Website
    {
        get { return _website; }
        set { _website = value; }
    }
    public int Timezoneid
    {
        get { return _timezoneid; }
        set { _timezoneid = value; }
    }
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public string Sitename
    {
        get { return _sitename; }
        set { _sitename = value; }
    }
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public int Regionid
    {
        get { return _regionid; }
        set { _regionid = value; }
    }
    public string Postalcode
    {
        get { return _postalcode; }
        set { _postalcode = value; }
    }
    public string Phoneno
    {
        get { return _phoneno; }
        set { _phoneno = value; }
    }
    public string Mobileno
    {
        get { return _mobileno; }
        set { _mobileno = value; }
    }
    public string Faxno
    {
        get { return _faxno; }
        set { _faxno = value; }
    }
    public bool Enable
    {
        get { return _enable; }
        set { _enable = value; }
    }
    public string Emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public String Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    public int Countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    public string Contactpersonname
    {
        get { return _contactpersonname; }
        set { _contactpersonname = value; }
    }
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    #endregion
    #region Constructors
    public Site_mst()
    {
    }
    public Site_mst(string website, int timezoneid, string state, string sitename, int siteid, int regionid, string postalcode, string phoneno, string mobileno, string faxno, bool enable, string emailid, string description, string createdatetime, int countryid, string contactpersonname, string city, string address)
    {
        _website = website;
        _timezoneid = timezoneid;
        _state = state;
        _sitename = sitename;
        _siteid = siteid;
        _regionid = regionid;
        _postalcode = postalcode;
        _phoneno = phoneno;
        _mobileno = mobileno;
        _faxno = faxno;
        _enable = enable;
        _emailid = emailid;
        _description = description;
        _createdatetime = createdatetime;
        _countryid = countryid;
        _contactpersonname = contactpersonname;
        _city = city;
        _address = address;
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Site_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Site_mst_By_id(this);
    }
    public int Delete(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Site_mst_By_id(siteid);
    }
    public int Get_By_SiteName(string SiteName, int regionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_sitId_mst_Get_By_SiteName(SiteName, regionid);
    }
    //change done by meenakshi
    
    public BLLCollection<Site_mst> Get_By_hubid_site(int hubid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.sp_Get_By_sitename_mst(hubid);
    }
  //end
    public BLLCollection<Site_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Site_mst_All();
    }
    public Site_mst Get_By_id(int Siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Site_mst_Get_By_Siteid(Siteid);
    }
    public BLLCollection<Site_mst> Get_All_By_RegionId(int regionid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Site_mst_All_By_RegionId(regionid);
    }

    public int Get_TopSiteId()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_TopSiteId_mst();
    }

    #endregion

}
