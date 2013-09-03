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

/// <summary>
/// Summary description for Asset_ProductInfo_mst
/// </summary>
public class Asset_ProductInfo_mst
{
		#region Private Fields
		private string _uuid;
		private string _sku_no;
		private string _serial_number;
		private string _product_name;
		private string _product_manufacturer;
		private string _inventory_date;
		private int _assetproductinfoid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Uuid
		{
			 get{ return _uuid; }
			 set{ _uuid = value; }
		}
		public string Sku_no
		{
			 get{ return _sku_no; }
			 set{ _sku_no = value; }
		}
		public string Serial_number
		{
			 get{ return _serial_number; }
			 set{ _serial_number = value; }
		}
		public string Product_name
		{
			 get{ return _product_name; }
			 set{ _product_name = value; }
		}
		public string Product_manufacturer
		{
			 get{ return _product_manufacturer; }
			 set{ _product_manufacturer = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public int Assetproductinfoid
		{
			 get{ return _assetproductinfoid; }
			 set{ _assetproductinfoid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_ProductInfo_mst()		{
		}
        public Asset_ProductInfo_mst(string uuid, string sku_no, string serial_number, string product_name, string product_manufacturer, string inventory_date, int assetproductinfoid, int assetid)
        {
			_uuid = uuid;
			_sku_no = sku_no;
			_serial_number = serial_number;
			_product_name = product_name;
			_product_manufacturer = product_manufacturer;
			_inventory_date = inventory_date;
			_assetproductinfoid = assetproductinfoid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods

        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_ProductInfo_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_ProductInfo_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_ProductInfo_mst_By_id(this);
        }

        public int Delete(int assetProductInfoId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_ProductInfo_mst_By_id(assetProductInfoId);
        }

        public BLLCollection<Asset_ProductInfo_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_ProductInfo_mst_All();
        }

        public Asset_ProductInfo_mst Get_By_id(int assetProductInfoId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_ProductInfo_mst_Get_By_assetid(assetProductInfoId);
        }

        public Asset_ProductInfo_mst Get_By_Assetid(int assetId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetProductInfo_mst_Get_By_assetid(assetId);
        }
        #endregion

}
