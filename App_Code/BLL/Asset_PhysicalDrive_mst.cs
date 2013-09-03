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


public class Asset_PhysicalDrive_mst
{
		#region Private Fields
		private string _serial_number;
		private string _product_version;
		private string _product_id;
		private string _manufacturer;
		private string _inventory_date;
		private string _drive_name;
		private string _capacity;
		private int _assetphysicaldriveid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Serial_number
		{
			 get{ return _serial_number; }
			 set{ _serial_number = value; }
		}
		public string Product_version
		{
			 get{ return _product_version; }
			 set{ _product_version = value; }
		}
		public string Product_id
		{
			 get{ return _product_id; }
			 set{ _product_id = value; }
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
		public string Drive_name
		{
			 get{ return _drive_name; }
			 set{ _drive_name = value; }
		}
		public string Capacity
		{
			 get{ return _capacity; }
			 set{ _capacity = value; }
		}
		public int Assetphysicaldriveid
		{
			 get{ return _assetphysicaldriveid; }
			 set{ _assetphysicaldriveid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_PhysicalDrive_mst()		{
		}
        public Asset_PhysicalDrive_mst(string serial_number, string product_version, string product_id, string manufacturer, string inventory_date, string drive_name, string capacity, int assetphysicaldriveid, int assetid)
        {
			_serial_number = serial_number;
			_product_version = product_version;
			_product_id = product_id;
			_manufacturer = manufacturer;
			_inventory_date = inventory_date;
			_drive_name = drive_name;
			_capacity = capacity;
			_assetphysicaldriveid = assetphysicaldriveid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods

        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_PhysicalDrive_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_PhysicalDrive_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_PhysicalDrive_mst_By_id(this);
        }

        public int Delete(int assetPhysicalDriveId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_PhysicalDrive_mst_By_id(assetPhysicalDriveId);
        }

        public BLLCollection<Asset_PhysicalDrive_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_PhysicalDrive_mst_All();
        }

        public Asset_PhysicalDrive_mst Get_By_id(int assetPhysicalDriveId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_PhysicalDrive_mst_Get_By_assetid(assetPhysicalDriveId);
        }

        #endregion
}
