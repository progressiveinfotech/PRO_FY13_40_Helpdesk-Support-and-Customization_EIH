using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class IncludedAssetinchange
	{
		#region Private Fields
		private int _changeid;
		private int _assetid;
		#endregion

		#region Public Fields
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public IncludedAssetinchange()		{
		}
		public IncludedAssetinchange(int changeid,int assetid)		{
			_changeid = changeid;
			_assetid = assetid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Insert_IncludeassetChange_mst(this);


        }
        public BLLCollection<IncludedAssetinchange> Get_All_IncludeAssetinchange(int Changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_includeasset_mst_All_By_Changeid(Changeid);
        }

   
        public int Delete(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Includeassetinchange_mst_By_id(changeid);
        }

        public IncludedAssetinchange Get_By_Changeid(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.IncludeAsset_mst_Get_By_changeid(changeid);
            
        }
        #endregion
	}

