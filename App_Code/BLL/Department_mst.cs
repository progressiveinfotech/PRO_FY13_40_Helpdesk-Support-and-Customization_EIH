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
/// Summary description for Department_mst
/// </summary>
public class Department_mst
{
    #region Private Fields
    private int _siteid;
    private int _deptid;
    private string _departmentname;
    private string  _description;
   
    #endregion
    #region Public Fields
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    public int Deptid
    {
        get { return _deptid; }
        set { _deptid = value; }
    }
    public string Departmentname
    {
        get { return _departmentname; }
        set { _departmentname = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
   
    
    #endregion

    #region Constructors
    public Department_mst()
    {
    }
    public Department_mst(int siteid, int deptid, string departmentname, string description)
    {
        _siteid = siteid;
        _deptid = deptid;
        _departmentname = departmentname;
        _description = description;
       
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Department_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Department_mst_By_id(this);
    }
    public int Delete(int deptid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Department_mst_By_id( deptid);
    }
    public int Get_By_DepartmentName(string departmentname, int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_deptid_mst_Get_By_DepartmentName(departmentname, siteid);
    }

    public BLLCollection<Department_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Department_mst_All();
    }
    public Department_mst Get_By_id(int deptid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Department_mst_Get_By_deptid(deptid);
    }
    public BLLCollection<Department_mst> Get_All_By_SiteId(int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Department_mst_All_By_SieId(siteid);
    }
    
    #endregion
}
