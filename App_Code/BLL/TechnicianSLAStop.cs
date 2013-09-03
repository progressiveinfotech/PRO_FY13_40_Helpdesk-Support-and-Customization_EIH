using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TechnicianSLAStop
/// </summary>
public class TechnicianSLAStop
{
	public TechnicianSLAStop()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int GetTechnicianId(int technicianid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetTechincianSLAStop(technicianid);
    }

}
