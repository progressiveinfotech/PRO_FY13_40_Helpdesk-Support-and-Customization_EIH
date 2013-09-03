using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class UserEmail
	{
		#region Private Fields
		private int _userid;
		
		private string _emailid;
		private int _active;
		#endregion

		#region Public Fields
		public int Userid
		{
			 get{ return _userid; }
			 set{ _userid = value; }
		}
		
		public string Emailid
		{
			 get{ return _emailid; }
			 set{ _emailid = value; }
		}
		public int Active
		{
			 get{ return _active; }
			 set{ _active = value; }
		}
		#endregion

		#region Constructors
		public UserEmail()		{
		}
		public UserEmail(int userid,string emailid,int active)		{
			_userid = userid;
			
			_emailid = emailid;
			_active = active;
		}
		#endregion
        #region Public Method
        public BLLCollection<UserEmail> Get_All_userid(int userid)
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Get_UserEmail_All_By_userid(userid);
        }
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Insert_UserToEmail_mst(this);

        }
        public int InsertFeedbackCustomer()
        {
            SqlDataProvider db = new SqlDataProvider();

           // return db.Insert_UserToEmail_mst(this);
            return db.Insert_FeedbackCustomer_mst(this);

        }
        public UserEmail Get_By_id(int userid)
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.UserEmail_mst_Get_By_userid(userid);
        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Update_UserEmail_mst_By_id(this);
        }

        #endregion
    }

