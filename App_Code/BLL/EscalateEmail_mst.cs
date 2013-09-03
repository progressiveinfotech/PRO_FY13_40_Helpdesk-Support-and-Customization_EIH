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
/// Summary description for EscalateEmail_mst
/// </summary>
public class EscalateEmail_mst
{
    #region Private Fields
    private int _id;
    private string _email;
    #endregion

    #region Public Fields
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    #endregion

    #region Constructors
    public EscalateEmail_mst()
    {
    }
    public EscalateEmail_mst(int id, string email)
    {
        _id = id;
        _email = email;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_EscalateEmail_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_EscalateEmail_mst_By_id(this);
    }
    public int Delete(int id)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_EscalateEmail_mst_By_id(id);
    }
    public BLLCollection<EscalateEmail_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_EscalateEmail_mst_All();
    }

    public EscalateEmail_mst Get_By_id(int id)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.EscalateEmail_mst_Get_By_id(id);
    }
    public EscalateEmail_mst Get_By_Emailid(string emailid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.EscalateEmail_mst_Get_By_emailid(emailid);
    }

    public int Check_Emailid(String Email)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Email_Id(Email);
    }

    #endregion
}
