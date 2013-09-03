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
/// Summary description for EscalateLevel2
/// </summary>
public class EscalateLevel2
{
	 #region Private Fields
    private int _slaid;
    private int _min;
    private int _level2id;
    private int _hours;
    private string _emailid;
    private int _days;
    private bool _before;
    private bool _after;
    private bool _sent;
    #endregion

    #region Public Fields
    public int Slaid
    {
        get { return _slaid; }
        set { _slaid = value; }
    }
    public int Min
    {
        get { return _min; }
        set { _min = value; }
    }
    public int Level2id
    {
        get { return _level2id; }
        set { _level2id = value; }
    }
    public int Hours
    {
        get { return _hours; }
        set { _hours = value; }
    }
    public string Emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }
    public int Days
    {
        get { return _days; }
        set { _days = value; }
    }
    public bool Before
    {
        get { return _before; }
        set { _before = value; }
    }
    public bool After
    {
        get { return _after; }
        set { _after = value; }
    }
    public bool Sent
    {
        get { return _sent; }
        set { _sent = value; }
    }
    #endregion

    #region Constructors
    public EscalateLevel2()
    {
    }
    public EscalateLevel2(int slaid, int min, int level2id, int hours, string emailid, int days, bool before, bool after,bool sent)
    {
        _slaid = slaid;
        _min = min;
        _level2id = level2id;
        _hours = hours;
        _emailid = emailid;
        _days = days;
        _before = before;
        _after = after;
        _sent = sent;
    }
    #endregion

    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_EscalateLevel2(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_EscalateLevel2_By_id(this);
    }
    public int Delete(int level2id)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_EscalateLevel2_By_id(level2id);
    }
    public BLLCollection<EscalateLevel2> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_EscalateLevel2_All();
    }

    public EscalateLevel2 Get_By_id(int level2id)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.EscalateLevel2_Get_By_id(level2id);
    }

    public EscalateLevel2 Get_By_Slaid(int slaid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.EscalateLevel2_Get_By_slaid(slaid);
    }

    #endregion
}
