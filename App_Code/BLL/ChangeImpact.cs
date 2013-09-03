using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ChangeImpact
	{
		#region Private Fields
		private int _impactid;
		private string _description;
		private int _changeid;
		#endregion

		#region Public Fields
		public int Impactid
		{
			 get{ return _impactid; }
			 set{ _impactid = value; }
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
		public ChangeImpact()	
        {

		}
		public ChangeImpact(int impactid,string description,int changeid)		{
			_impactid = impactid;
			_description = description;
			_changeid = changeid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_ChangeImpact_mst(this);

        }
       
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Update_ChangeImpact_By_id(this);
        }
        public ChangeImpact Get_By_id(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.ChangeImpact_mst_Get_By_changeid(changeid);
        }
        #endregion
    }

