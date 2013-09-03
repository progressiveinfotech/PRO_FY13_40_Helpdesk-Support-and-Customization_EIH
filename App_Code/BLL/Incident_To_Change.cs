using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class Incident_To_Change
	{
		#region Private Fields
		private int _incidentid;
		private int _changeid;
		#endregion

		#region Public Fields
		public int Incidentid
		{
			 get{ return _incidentid; }
			 set{ _incidentid = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		#endregion

		#region Constructors
		public Incident_To_Change()		
        {
		}
        public Incident_To_Change(int incidentid, int changeid)		
        {
			_incidentid = incidentid;
			_changeid = changeid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Insert_Incident_To_Change(this);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Update_Incident_To_Change_By_id(this);
            
        }
        public int Delete(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Delete_Incident_To_Change_By_id(incidentid);
        }

        public BLLCollection<Incident_To_Change> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Get_Incident_To_Change_All();
        }

        public BLLCollection<Incident_To_Change> Get_All_By_Changeid(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Get_Incident_To_change_All_By_changeid(changeid);
        }

        public Incident_To_Change Get_By_id(int incidentid, int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Incident_To_Change_Get_By_incidentid(incidentid, changeid);
        }

        public Incident_To_Change Get_By_Incidentid(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();

           
           
            return db.Incident_To_Change_mst_Get_By_Incidentid(incidentid);
            
        }
        #endregion

	}

