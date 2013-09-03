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
/// Summary description for ContractNotification
/// </summary>
public class ContractNotification
{

    #region Private Fields
    private string _sentto;
    private bool _sendnotification;
    private int _contractid;
    private int _beforedays;
    #endregion

    #region Public Fields
    public string Sentto
    {
        get { return _sentto; }
        set { _sentto = value; }
    }
    public bool Sendnotification
    {
        get { return _sendnotification; }
        set { _sendnotification = value; }
    }
    public int Contractid
    {
        get { return _contractid; }
        set { _contractid = value; }
    }
    public int Beforedays
    {
        get { return _beforedays; }
        set { _beforedays = value; }
    }
    #endregion

    #region Constructors
    public ContractNotification()
    {
    }
    public ContractNotification(string sentto, bool sendnotification, int contractid, int beforedays)
    {
        _sentto = sentto;
        _sendnotification = sendnotification;
        _contractid = contractid;
        _beforedays = beforedays;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ContractNotification(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_ContractNotification_By_id(this);
    }
    public int Delete(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_ContractNotification_By_id(contractid);
    }
    public BLLCollection<ContractNotification> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ContractNotification_All();
    }

    public ContractNotification Get_By_id(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.ContractNotification_Get_By_contractid(contractid);
    }
    #endregion
}
