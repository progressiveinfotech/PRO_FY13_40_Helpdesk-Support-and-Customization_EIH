using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ChangeNotes
	{
		#region Private Fields
		private int _username;
		private string _date;
		private string _comments;
		private int _changeid;
		#endregion

		#region Public Fields
		public int Username
		{
			 get{ return _username; }
			 set{ _username = value; }
		}
		public string Date
		{
			 get{ return _date; }
			 set{ _date = value; }
		}
		public string Comments
		{
			 get{ return _comments; }
			 set{ _comments = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		#endregion

		#region Constructors
		public ChangeNotes()		{
		}
		public ChangeNotes(int username,string date,string comments,int changeid)		{
			_username = username;
			_date = date;
			_comments = comments;
			_changeid = changeid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
         
            return db.Insert_ChangeNotes_mst(this);

        }
        
        public BLLCollection<ChangeNotes> Get_All_By_Changeid(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_ChangeNotes_mst_All_By_changeid(changeid);
           
            
        }
        #endregion
	}

