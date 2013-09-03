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
/// Summary description for Technician_To_Group
/// </summary>
public class Technician_To_Group
{
    #region Private Fields
    private int _technicianid;
    private int _groupid;
    #endregion

    #region Public Fields
    public int Technicianid
    {
        get { return _technicianid; }
        set { _technicianid = value; }
    }
    public int Groupid
    {
        get { return _groupid; }
        set { _groupid = value; }
    }
    #endregion

    #region Constructors
    public Technician_To_Group()
    {
    }
    public Technician_To_Group(int technicianid, int groupid)
    {
        _technicianid = technicianid;
        _groupid = groupid;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Technician_To_Group(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Technician_To_Group(this);
    }
    public int Delete(int technicianid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_Technician_To_Group(technicianid);
    }

    public BLLCollection<Technician_To_Group> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Technician_To_Group_All();
    }

    public Technician_To_Group Get_By_id(int technicianid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Technician_To_Group_Get_By_incidentid(technicianid);
    }


    #endregion
}
