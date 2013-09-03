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
/// Summary description for ContractToAssetMapping
/// </summary>
public class ContractToAssetMapping
{
    #region Private Fields
    private int _contractid;
    private int _assetid;
    #endregion

    #region Public Fields
    public int Contractid
    {
        get { return _contractid; }
        set { _contractid = value; }
    }
    public int Assetid
    {
        get { return _assetid; }
        set { _assetid = value; }
    }
    #endregion

    #region Constructors
    public ContractToAssetMapping()
    {
    }
    public ContractToAssetMapping(int contractid, int assetid)
    {
        _contractid = contractid;
        _assetid = assetid;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ContractToAssetMapping(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ContractToAssetMapping_By_id(this);
    }
    public int Delete(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ContractToAssetMapping_By_id(contractid);
    }
    public int Delete_by_Contractid_Assetid(int contractid,int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ContractToAssetMapping_By_Contractid_Assetid(contractid, assetid);
    }
    public BLLCollection<ContractToAssetMapping> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ContractToAssetMapping_All();
    }

    public ContractToAssetMapping Get_By_id(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ContractToAssetMapping_Get_By_contractid(contractid);
    }

    public int Get_By_Assetid(int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ContractToAssetMapping_By_Assetid(assetid);
    }
    public BLLCollection<ContractToAssetMapping> Get_All_By_contractid(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ContractToAssetMapping_All_By_contractid(contractid);
    }

    public int Get_by_Contractid_Assetid(int contractid, int assetid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ContractToAssetMapping_By_Contractid_Assetid(contractid, assetid);
    }
    #endregion
}
