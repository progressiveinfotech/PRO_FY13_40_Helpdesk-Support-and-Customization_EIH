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
/// Summary description for RoleInfo_mst
/// </summary>
public class RoleInfo_mst
{
    #region Private Fields
    private string _rolename;
    private int _roleid;
    private string _description;
    #endregion

    #region Public Fields
    public string Rolename
    {
        get { return _rolename; }
        set { _rolename = value; }
    }
    public int Roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public RoleInfo_mst()
    {
    }
    public RoleInfo_mst(string rolename, int roleid, string description)
    {
        _rolename = rolename;
        _roleid = roleid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_RoleInfo_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_RoleInfo_mst_By_id(this);
    }
    public int Delete(int roleid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_RoleInfo_mst_By_id(roleid);
    }
    public BLLCollection<RoleInfo_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_RoleInfo_mst_All();
    }
    public int Get_By_RoleName(string RoleName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.RoleInfo_mst_Get_By_RoleName(RoleName);
    }
    public RoleInfo_mst Get_By_id(int roleid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.RoleInfo_mst_Get_By_Roleid(roleid);
    }

    public RoleInfo_mst Get_RoleInfo_By_RoleName(string RoleName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.RoleInfo_Get_By_RoleName_mst(RoleName);
    }

    public int Get_Role_By_Roleid(String rolename)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Role_By_Roleid(rolename);
    }

    #endregion
}
