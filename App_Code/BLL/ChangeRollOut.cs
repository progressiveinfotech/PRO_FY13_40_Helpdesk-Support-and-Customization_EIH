using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ChangeRollOut
	{
		#region Private Fields
		private int _rolloutid;
		private string _description;
		private int _changeid;
		#endregion

		#region Public Fields
		public int Rolloutid
		{
			 get{ return _rolloutid; }
			 set{ _rolloutid = value; }
		}
		public string Description
		{
			 get{ return _description; }
			 set{ _description = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		#endregion

		#region Constructors
		public ChangeRollOut()		{
		}
		public ChangeRollOut(int rolloutid,string description,int changeid)		{
			_rolloutid = rolloutid;
			_description = description;
			_changeid = changeid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
          
            return db.Insert_ChangeRollOut_mst(this);

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

            
            return db.Update_ChangeRollOut_By_id(this);
            
        }
        public ChangeRollOut Get_By_id(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            
            return db.ChangeRollOut_mst_Get_By_changeid(changeid);
        }
        #endregion

	}

