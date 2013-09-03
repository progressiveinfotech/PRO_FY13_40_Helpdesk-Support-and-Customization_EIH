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
/// Summary description for ContractRenewed
/// </summary>
public class ContractRenewed
{
    #region Private Fields
    private string _reneweddate;
    private int _renewedcontractid;
    private int _contractid;
    #endregion


    #region Public Fields
    public string Reneweddate
    {
        get { return _reneweddate; }
        set { _reneweddate = value; }
    }
    public int Renewedcontractid
    {
        get { return _renewedcontractid; }
        set { _renewedcontractid = value; }
    }
    public int Contractid
    {
        get { return _contractid; }
        set { _contractid = value; }
    }
    #endregion

    #region Constructors
    public ContractRenewed()
    {
    }
    public ContractRenewed(string reneweddate, int renewedcontractid, int contractid)
    {
        _reneweddate = reneweddate;
        _renewedcontractid = renewedcontractid;
        _contractid = contractid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ContractRenewed(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ContractRenewed_By_id(this);
    }
    public int Delete(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ContractRenewed_By_id(contractid);
    }

    public BLLCollection<ContractRenewed> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ContractRenewed_All();
    }

    public ContractRenewed Get_By_id(int renewedContractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ContractRenewed_Get_By_id(renewedContractid);
    }

        
    #endregion

}
