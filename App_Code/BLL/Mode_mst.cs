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
/// Summary description for Mode_mst
/// </summary>
public class Mode_mst
{
    #region Private Fields
    private string _modename;
    private int _modeid;
    private string _description;
    #endregion
    #region Public Fields
    public string Modename
    {
        get { return _modename; }
        set { _modename = value; }
    }
    public int Modeid
    {
        get { return _modeid; }
        set { _modeid = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    #endregion

    #region Constructors
    public Mode_mst()
    {
    }
    public Mode_mst(string modename, int modeid, string description)
    {
        _modename = modename;
        _modeid = modeid;
        _description = description;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Mode_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Mode_mst_By_id(this);
    }
    public int Delete(int modeid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Mode_mst_By_id(modeid);
    }

    public BLLCollection<Mode_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Mode_mst_All();
    }

    public Mode_mst Get_By_id(int modeid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Mode_mst_Get_By_modeid(modeid);
    }
    public int Get_Mode_By_Mname(String Mname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Mode_By_Mname(Mname);
    }
    

    #endregion

	
}
