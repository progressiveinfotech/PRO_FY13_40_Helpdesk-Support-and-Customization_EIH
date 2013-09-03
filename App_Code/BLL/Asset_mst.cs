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
using System.Data.SqlClient;

/// <summary>
/// Summary description for Asset_mst
/// </summary>
public class Asset_mst
{

    #region Private Fields
    private string _domain;
    private string _createdatetime;
    private string _computername;
    private int _assetid;
    //added by lalit
    private string _TagNo;
    private string _PoNo;
    private string _AssetOwner;
    //end
    //added by prachi
    private bool _IsInStock;        //end
    /// <summary>
    /// added by vishal 02-06-2012
    /// </summary>
    private bool _IsDelete;
    private string _Location;
    private bool _iManual;
    private string _companyCode;
    private string _purchaseDate;
    private string _assetCategory;
    private string _remarks;

    ////////end 02-06-2012
    #endregion

    #region Public Fields
    public string Domain
    {
        get { return _domain; }
        set { _domain = value; }
    }
    public string Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    public string Computername
    {
        get { return _computername; }
        set { _computername = value; }
    }
    public int Assetid
    {
        get { return _assetid; }
        set { _assetid = value; }
    }
    //added by lalit
    public string TagNo
    {
        get { return _TagNo; }
        set { _TagNo = value; }
    }
    public string PONo
    {
        get { return _PoNo; }
        set { _PoNo = value; }
    }
    public string AssetOwner
    {
        get { return _AssetOwner; }
        set { _AssetOwner = value; }
    }
    //added by lalit
    //added by prachi
    public bool IsInStock
    {
        get { return _IsInStock; }
        set { _IsInStock = value; }
    }
    //end
    /// <summary>
    /// add by vishal 02-06-2012
    /// </summary>
    public bool manaul
    {
        get { return _iManual; }
        set { _iManual = value; }
    }
    public string location
    {
        get { return _Location; }
        set { _Location = value; }
    }
    ////add by meenakshi
    public string CompanyCode
    {
        get { return _companyCode; }
        set { _companyCode = value; }
    }
    public string PurchaseDate
    {
        get { return _purchaseDate; }
        set { _purchaseDate = value; }
    }
    public string AssetCategory
    {
        get { return _assetCategory; }
        set { _assetCategory = value; }
    }
    public string Remarks
    {
        get { return _remarks; }
        set { _remarks = value; }
    }
    ///end 20-06-2012
    ////////end 02-06-2012
    #endregion

    #region Constructors
    public Asset_mst()
    {
    }
    //public Asset_mst(string domain, string createdatetime, string computername, int assetid, string TagNo, string PoNo, string assetowner, bool Isinstock)
    //{
    //    _domain = domain;
    //    _createdatetime = createdatetime;
    //    _computername = computername;
    //    _assetid = assetid;
    //    _TagNo = TagNo;
    //    _PoNo = PoNo;
    //    _AssetOwner = assetowner;
    //    _IsInStock = Isinstock;

    //}
    public Asset_mst(string domain, string createdatetime, string computername, string TagNo, string PoNo, string assetowner, bool Isinstock, bool isdelete, bool imanual, string strLocation, string companyCode, string purchaseDate, string assetCategory, string remarks)
    {
        _domain = domain;
        _createdatetime = createdatetime;
        _computername = computername;
        _TagNo = TagNo;
        _PoNo = PoNo;
        _AssetOwner = assetowner;
        _IsInStock = Isinstock;
        _IsDelete = isdelete;
        _iManual = imanual;
        _Location = strLocation;
        _companyCode = companyCode;
        _purchaseDate = purchaseDate;
        _assetCategory = assetCategory;
        _remarks = remarks;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Asset_mst(this);
    }

    public int Insert1()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert1_Asset_mst(this);
    }

    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Asset_mst_By_id(this);
    }
    public int Delete(int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Asset_mst_By_id(assetid);
    }
    public BLLCollection<Asset_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Asset_mst_All();
    }

    public Asset_mst Get_By_id(int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Asset_mst_Get_By_assetid(assetid);
    }

    public int Get_Current_Assetid()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Assett_mst_Get_Current_Assetid();
    }

    public Asset_mst Get_Asset_By_Computername(string compname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Asset_By_Computername(compname);
    }

    public int Get_ComputerName(string compname, string domain)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Asset_mst_Get_ComputerName(compname, domain);
    }
    public Asset_mst Get_AssetId_By_ComputerName_Domain(string compname, string domain)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AssetId_By_ComputerName_DomainName(compname, domain);
    }
    //public Asset_mst Get_Computername_By_Assetid(int assetid)
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_Computername_By_Assetid(assetid);
    //}
    public BLLCollection<Asset_mst> Get_Assetdetails_By_Assetid(int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Assetdetails_By_Assetid(assetid);
    }

    public BLLCollection<Asset_mst> Get_By_comandname(string commandname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Asset_Info_By_commandname(commandname);
    }

    public BLLCollection<Asset_mst> Get_NotAssign_By_comandname(string commandname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_NotAssignAsset_Info_By_commandname(commandname);
    }

    public int Get_Asset_By_Cname(String Cname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Asset_By_Cname(Cname);
    }

    //public DataSet GetDataSet(string strsql)
    //{
    //    DataSet ds = null;
    //    ds = new DataSet();
    //    SqlDataAdapter da = null;
    //    //da = new SqlDataAdapter(strsql);
    //    da.Fill(ds);
    //    return ds;
    //}
    /// <summary>
    /// //////Create by Vishal 16-05-2012 
    /// </summary>
    /// <param name="objAsset"></param>
    /// <returns></returns>



    public int Update_Asset_mst_Tag_PO_By_id()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Asset_mst_Tag_PO_By_id(this);
    }
    ///End 16-05-2012
    #endregion


    ///Create by Vishal 02-06-2012
    ///
    public int UpdateDeleteFlag_Asset_id()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.UpdateDeleteFlag_Asset_id(this);
    }
    ////////end 02-06-2012


    /////////////Create by vishal 04-06-2012


    public int Update_Asset_mst_Tag_PO_IsInStockBy_id()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Asset_mst_Tag_PO_IsInStockBy_id(this);
    }
}
