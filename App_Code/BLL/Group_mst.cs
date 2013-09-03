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
/// Summary description for Group_mst
/// </summary>
public class Group_mst
{
    #region Private Fields
    private string _groupname;
    private int _groupid;
    private string _description;
    #endregion

    #region Public Fields
    public string Groupname
    {
        get { return _groupname; }
        set { _groupname = value; }
    }
    public int Groupid
    {
        get { return _groupid; }
        set { _groupid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Group_mst()
    {
    }
    public Group_mst(string groupname, int groupid, string description)
    {
        _groupname = groupname;
        _groupid = groupid;
        _description = description;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Group_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Group_mst(this);
    }
    public int Delete(int groupid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Group_mst(groupid);
    }

    public BLLCollection<Group_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Group_mst_All();
    }

    public Group_mst Get_By_id(int groupid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Group_mst_Get_By_incidentid(groupid);
    }


    #endregion
}
