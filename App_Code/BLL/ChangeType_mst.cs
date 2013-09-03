using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;



	public class ChangeType_mst
	{
		#region Private Fields
		private string _description;
		private string _changetypename;
		private int _changetypeid;
		#endregion

		#region Public Fields
		public string Description
		{
			 get{ return _description; }
			 set{ _description = value; }
		}
		public string Changetypename
		{
			 get{ return _changetypename; }
			 set{ _changetypename = value; }
		}
		public int Changetypeid
		{
			 get{ return _changetypeid; }
			 set{ _changetypeid = value; }
		}
		#endregion

		#region Constructors
		public ChangeType_mst()		{
		}
		public ChangeType_mst(string description,string changetypename,int changetypeid)		{
			_description = description;
			_changetypename = changetypename;
			_changetypeid = changetypeid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        { 
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_ChangeType_mst(this);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_ChangeType_mst_By_id(this);
        
        }
        public int Delete(int changetypeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Delete_ChangeType_mst_By_id(changetypeid);
        }
        public BLLCollection<ChangeType_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_ChangeType_mst_All();

        }
        public int Get_By_ChangeTypeName(string ChangeTypeName)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.ChangeType_mst_Get_By_ChangeTypeName(ChangeTypeName);
        }
        public ChangeType_mst Get_By_id(int ChangeTypeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.ChangeType_mst_Get_By_ChangeTypeid(ChangeTypeid);
        }
        #endregion
	}

