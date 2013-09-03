using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class Configuration_mst
	{
		#region Private Fields
		private string _warranty;
		private int _version;
		private int _vendorid;
		private int _siteid;
		private string _severity;
		private string _serialno;
		private string _purchasedate;
		private int _itemid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Warranty
		{
			 get{ return _warranty; }
			 set{ _warranty = value; }
		}
		public int Version
		{
			 get{ return _version; }
			 set{ _version = value; }
		}
		public int Vendorid
		{
			 get{ return _vendorid; }
			 set{ _vendorid = value; }
		}
		public int Siteid
		{
			 get{ return _siteid; }
			 set{ _siteid = value; }
		}
		public string Severity
		{
			 get{ return _severity; }
			 set{ _severity = value; }
		}
		public string Serialno
		{
			 get{ return _serialno; }
			 set{ _serialno = value; }
		}
		public string Purchasedate
		{
			 get{ return _purchasedate; }
			 set{ _purchasedate = value; }
		}
		public int Itemid
		{
			 get{ return _itemid; }
			 set{ _itemid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Configuration_mst()		{
		}
		public Configuration_mst(string warranty,int version,int vendorid,int siteid,string severity,string serialno,string purchasedate,int itemid,int assetid)		{
			_warranty = warranty;
			_version = version;
			_vendorid = vendorid;
			_siteid = siteid;
			_severity = severity;
			_serialno = serialno;
			_purchasedate = purchasedate;
			_itemid = itemid;
			_assetid = assetid;
		}
		#endregion
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();


            
            return db.Insert_Configuration_mst(this);

        }
        public int Get_Current_Assetid()
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Configurationmst_mst_Get_Current_CMDBAssetid();
        }
        public BLLCollection<Configuration_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
          
            return db.Get_Configuration_All();
        }
        public BLLCollection<Configuration_mst> Get_All_By_SerialNo(string serialno)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_mst_All_By_serialno(serialno);
            
        }

        public Configuration_mst Get_By_id(int Assetid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Asset_mst_Get_By_Assetid(Assetid);
        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Update_Configuration_mst_By_id(this);

        }

	}

