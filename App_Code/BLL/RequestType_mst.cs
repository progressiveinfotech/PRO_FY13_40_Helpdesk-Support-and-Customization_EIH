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
/// Summary description for RequestType
/// </summary>
public class RequestType_mst
{
    #region Private Fields
    private string _requesttypename;
    private int _requesttypeid;
    private string _description;
    #endregion

    #region Public Fields
    public string Requesttypename
    {
        get { return _requesttypename; }
        set { _requesttypename = value; }
    }
    public int Requesttypeid
    {
        get { return _requesttypeid; }
        set { _requesttypeid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion


    #region Constructors
    public RequestType_mst()
    {
    }
    public RequestType_mst(string requesttypename, int requesttypeid, string description)
    {
        _requesttypename = requesttypename;
        _requesttypeid = requesttypeid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_RequestType_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_RequestType_mst_By_id(this);
    }
    public int Delete(int requesttypeid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_RequestType_mst_By_id(requesttypeid);
    }
    public BLLCollection<RequestType_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_RequestType_mst_All();
    }
    
    public RequestType_mst Get_By_id(int requesttypeid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.RequestType_mst_Get_By_RequestTypeid(requesttypeid);
    }
    #endregion

    

}
