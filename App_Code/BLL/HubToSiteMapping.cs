using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HubToSiteMapping
/// </summary>
public class HubToSiteMapping
{

    private int _hubid;
    private int _siteid;
   

    public int Hubid
    {
        get { return _hubid; }
        set { _hubid = value; }
    }
    public int Siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
   	public HubToSiteMapping()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public HubToSiteMapping(int hubid,int siteid)
    {
       _siteid=siteid;
       _hubid = hubid;
     }
    public HubToSiteMapping Get_By_Siteid(int Siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Hub_mst_Get_By_Siteid(Siteid);
    }

    public HubToSiteMapping Get_By_Siteid_Hubid(int Siteid,int Hubid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Hub_mst_Get_By_Site_Hub_id(Siteid,Hubid);
    }
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Hubsite_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_Hub_mst_By_id(this);
    }

}
