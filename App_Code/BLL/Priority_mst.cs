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
/// Summary description for Priority_mst
/// </summary>
public class Priority_mst
{
    #region Private Fields
    private int _priorityid;
    private string _name;
    private string _description;
    #endregion

    #region Public Fields
    public int Priorityid
    {
        get { return _priorityid; }
        set { _priorityid = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Priority_mst()
    {
    }
    public Priority_mst(int priorityid, string name, string description)
    {
        _priorityid = priorityid;
        _name = name;
        _description = description;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Priority_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Priority_mst_By_id(this);
    }
    public int Delete(int priorityid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Priority_mst_By_id(priorityid);
    }

    public BLLCollection<Priority_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Priority_mst_All();
    }

    public int Get_By_PriorityName(string PriorityName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Priority_mst_Get_By_PriorityName(PriorityName);
    }
    public Priority_mst Get_By_id(int priorityid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Priority_By_priorityid(priorityid);
    }

    #endregion
    
    
}
