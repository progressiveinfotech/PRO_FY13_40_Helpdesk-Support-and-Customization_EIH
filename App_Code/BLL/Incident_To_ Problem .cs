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
/// Summary description for Incident__To__Problem
/// </summary>
public class Incident_To_Problem
{
    #region Private Fields
    private int _problemid;
    private int _incidentid;
    #endregion

    #region Public Fields
    public int Problemid
    {
        get { return _problemid; }
        set { _problemid = value; }
    }
    public int Incidentid
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    #endregion

    #region Constructors
    public Incident_To_Problem()
    {	}
		public Incident_To_Problem (int problemid,int incidentid)		
        {
			_problemid = problemid;
			_incidentid = incidentid;
		}
		#endregion

    #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Incident_To_Problem(this);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Incident_To_Problem_By_id(this);
        }
        public int Delete(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Incident_To_Problem_By_id(incidentid);
        }

        public BLLCollection<Incident_To_Problem> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Incident_To_Problem_All();
        }

        public BLLCollection<Incident_To_Problem> Get_All_By_Problemid(int problemid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Incident_To_Problem_All_By_Problemid(problemid);
        }
        public Incident_To_Problem Get_By_id(int incidentid,int problemid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Incident_To_Problem_Get_By_incidentid(incidentid, problemid);
        }


        #endregion
}
