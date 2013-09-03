using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ChangeTask_mst
	{
		#region Private Fields
		private string _title;
		private int _taskstatusid;
		private int _taskid;
		private string _scheduledstarttime;
        private string _scheduledendtime;
		private int _ownerid;
		private string _description;
		private string _comment;
		private int _changeid;
        private string _actualstarttime;
        private string _actualendtime;
		#endregion

		#region Public Fields
		public string Title
		{
			 get{ return _title; }
			 set{ _title = value; }
		}
		public int Taskstatusid
		{
			 get{ return _taskstatusid; }
			 set{ _taskstatusid = value; }
		}
		public int Taskid
		{
			 get{ return _taskid; }
			 set{ _taskid = value; }
		}
        public string Scheduledstarttime
		{
			 get{ return _scheduledstarttime; }
			 set{ _scheduledstarttime = value; }
		}
        public string Scheduledendtime
		{
			 get{ return _scheduledendtime; }
			 set{ _scheduledendtime = value; }
		}
		public int Ownerid
		{
			 get{ return _ownerid; }
			 set{ _ownerid = value; }
		}
		public string Description
		{
			 get{ return _description; }
			 set{ _description = value; }
		}
		public string Comment
		{
			 get{ return _comment; }
			 set{ _comment = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
        public string Actualstarttime
		{
			 get{ return _actualstarttime; }
			 set{ _actualstarttime = value; }
		}
        public string Actualendtime
		{
			 get{ return _actualendtime; }
			 set{ _actualendtime = value; }
		}
		#endregion

		#region Constructors
		public ChangeTask_mst()		{
		}
        public ChangeTask_mst(string title, int taskstatusid, int taskid, string scheduledstarttime, string scheduledendtime, int ownerid, string description, string comment, int changeid, string actualstarttime, string actualendtime)
        {
			_title = title;
			_taskstatusid = taskstatusid;
			_taskid = taskid;
			_scheduledstarttime = scheduledstarttime;
			_scheduledendtime = scheduledendtime;
			_ownerid = ownerid;
			_description = description;
			_comment = comment;
			_changeid = changeid;
			_actualstarttime = actualstarttime;
			_actualendtime = actualendtime;
		}
		#endregion
        #region Public methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();



            return db.Insert_ChangeTask_mst(this);



        }
        public BLLCollection<ChangeTask_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_ChangeTask_All();
        }
        public BLLCollection<ChangeTask_mst> Get_All_Changeid(int Changeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Get_ChangeTask_mst_All_By_Changeid(Changeid);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Update_ChangeTask_By_id(this);
        }
        public ChangeTask_mst Get_By_id(int taskid)
        {
            SqlDataProvider db = new SqlDataProvider();

       
            return db.ChangeTask_mst_Get_By_taskid(taskid);

        }
        #endregion
    }

