using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ChangeBackoutPlan
	{
		#region Private Fields
		private string _descripion;
		private int _changeid;
		private int _backoutid;
		#endregion

		#region Public Fields
		public string Descripion
		{
			 get{ return _descripion; }
			 set{ _descripion = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		public int Backoutid
		{
			 get{ return _backoutid; }
			 set{ _backoutid = value; }
		}
		#endregion

		#region Constructors
		public ChangeBackoutPlan()		{
		}
		public ChangeBackoutPlan(string descripion,int changeid,int backoutid)		{
			_descripion = descripion;
			_changeid = changeid;
			_backoutid = backoutid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_ChangeBackoutPlan_mst(this);

        }
        //public int Get_Current_ProblemHistoryid()
        //{
        //    SqlDataProvider db = new SqlDataProvider();

        //    return db.ProblemHistory_mst_Get_Current_ProblemHistoryid();
        //}
        //public BLLCollection<ProblemNotes> Get_All_By_Problemid(int problemid)
        //{
        //    SqlDataProvider db = new SqlDataProvider();
        //    //return db.Get_IncidentHistory_mst_All_By_incidentid(incidentid);
        //    return db.Get_ProblemNotes_mst_All_By_problemid(problemid);
        //}

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            
          return  db.Update_ChangeBackoutPlan_By_id(this);
        }
        public ChangeBackoutPlan Get_By_id(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.ChangeBackoutPlan_mst_Get_By_changeid(changeid);
        }
        #endregion
	}

