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
/// Summary description for Contract_mst
/// </summary>
public class Contract_mst
{
    #region Private Fields
    private int _vendorid;
    private string _description;
    private string _contractname;
    private int _contractid;
    private string _activeto;
    private string _activefrom;
    private string _createdatetime;
    #endregion

    #region Public Fields
    public int Vendorid
    {
        get { return _vendorid; }
        set { _vendorid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Contractname
    {
        get { return _contractname; }
        set { _contractname = value; }
    }
    public int Contractid
    {
        get { return _contractid; }
        set { _contractid = value; }
    }
    public string Activeto
    {
        get { return _activeto; }
        set { _activeto = value; }
    }
    public string Activefrom
    {
        get { return _activefrom; }
        set { _activefrom = value; }
    }
    public string CreateDateTime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    #endregion

    #region Constructors
    public Contract_mst()
    {
    }
    public Contract_mst(int vendorid, string description, string contractname, int contractid, string activeto, string activefrom,string createdatetime)
    {
        _vendorid = vendorid;
        _description = description;
        _contractname = contractname;
        _contractid = contractid;
        _activeto = activeto;
        _activefrom = activefrom;
        _createdatetime = createdatetime;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Contract_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Contract_mst_By_id(this);
    }
    public int Delete(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Contract_mst_By_id(contractid);
    }
    public BLLCollection<Contract_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Contract_mst_All();
    }

    public Contract_mst Get_By_id(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Contract_mst_Get_By_contractid(contractid);
    }

    public int Get_By_Contractname(string contractname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Contract_mst_By_name(contractname);
    }

    public int Get_TopContractId()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Contract_mst_TopContractId();
    }

    public int Get_Contract_Status(string ActiveToDate)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Contract_mst_Status(ActiveToDate);
    }

    public BLLCollection<Contract_mst> Get_All_Escalate_Notification()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Contract_mst_All_Escalate_Notification();
    }

    public int Get_Contract_Notification_Time(int contractid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Contract_mst_Notification_Time(contractid);
    }
    #endregion
}
