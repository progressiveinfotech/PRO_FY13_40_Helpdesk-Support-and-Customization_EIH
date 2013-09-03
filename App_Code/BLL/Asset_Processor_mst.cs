using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class Asset_Processor_mst
{
		#region Private Fields
		private string _stepping;
		private string _speed;
		private string _processor_name;
		private string _model;
		private string _max_speed;
		private string _manufacturer;
		private string _inventory_date;
		private string _family;
		private int _assetprocessorid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Stepping
		{
			 get{ return _stepping; }
			 set{ _stepping = value; }
		}
		public string Speed
		{
			 get{ return _speed; }
			 set{ _speed = value; }
		}
		public string Processor_name
		{
			 get{ return _processor_name; }
			 set{ _processor_name = value; }
		}
		public string Model
		{
			 get{ return _model; }
			 set{ _model = value; }
		}
		public string Max_speed
		{
			 get{ return _max_speed; }
			 set{ _max_speed = value; }
		}
		public string Manufacturer
		{
			 get{ return _manufacturer; }
			 set{ _manufacturer = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public string Family
		{
			 get{ return _family; }
			 set{ _family = value; }
		}
		public int Assetprocessorid
		{
			 get{ return _assetprocessorid; }
			 set{ _assetprocessorid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_Processor_mst()		{
		}
        public Asset_Processor_mst(string stepping, string speed, string processor_name, string model, string max_speed, string manufacturer, string inventory_date, string family, int assetprocessorid, int assetid)
        {
			_stepping = stepping;
			_speed = speed;
			_processor_name = processor_name;
			_model = model;
			_max_speed = max_speed;
			_manufacturer = manufacturer;
			_inventory_date = inventory_date;
			_family = family;
			_assetprocessorid = assetprocessorid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods

        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_Processor_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_Processor_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_Processor_mst_By_id(this);
        }

        public int Delete(int assetProcessorId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_Processor_mst_By_id(assetProcessorId);
        }

        public BLLCollection<Asset_Processor_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_Processor_mst_All();
        }

        public Asset_Processor_mst Get_By_id(int assetProcessorId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_Processor_mst_Get_By_assetid(assetProcessorId);
        }
        public Asset_Processor_mst Get_By_Assetid(int assetId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetProcessor_mst_Get_By_assetid(assetId);
        }
        #endregion
}
