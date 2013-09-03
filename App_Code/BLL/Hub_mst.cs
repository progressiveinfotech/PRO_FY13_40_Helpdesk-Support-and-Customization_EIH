using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hub_mst
/// </summary>
public class Hub_mst
{
    #region Private Fields
    private string _Hubname;
    private int _Hubid;
    private string _Hubdescription;
    #endregion
    #region Public Fields
    public string Hubname
    {
        get { return _Hubname; }
        set { _Hubname = value; }
    }
    public int Hubid
    {
        get { return _Hubid; }
        set { _Hubid = value; }
    }
    public string Description
    {
        get { return _Hubdescription; }
        set { _Hubdescription = value; }
    }
    #endregion

    #region Constructors
    public Hub_mst()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Hub_mst(string hubname, int hubid, string description)
    {
        _Hubname = hubname;
        _Hubid = hubid;
        _Hubdescription = description;
    }
    #endregion
	

    public BLLCollection<Hub_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Hub_mst_All();
    }
    public int Get_Hub_By_Mname(String Hname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Check_Mode_By_Hname(Hname);
    }
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Hub_mst(this);

    }
}
