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
/// Summary description for Asset_Inventory
/// </summary>
public class Asset_Inventory_mst
{
	
		#region Private Fields
        private string _inventorydate;
		private string _computername;
		private int _assetid;
		#endregion

		#region Public Fields
        public string Inventorydate
		{
			 get{ return _inventorydate; }
			 set{ _inventorydate = value; }
		}
		public string Computername
		{
			 get{ return _computername; }
			 set{ _computername = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_Inventory_mst()		{
		}
        public Asset_Inventory_mst(string inventorydate, string computername, int assetid)
        {
			_inventorydate = inventorydate;
			_computername = computername;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_Inventory_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_Inventory_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_Inventory_mst_By_id(this);
        }
        public int Delete(int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_Inventory_mst_By_id(assetid);
        }


        public BLLCollection<Asset_Inventory_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_Inventory_mst_All();
        }

        public Asset_Inventory_mst Get_By_id(int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_Inventory_mst_Get_By_assetid(assetid);
        }

        public int Get_Inventory_By_Assetid_InventoryDate(int assetid, string inventorydate)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Inventorydetails_By_AssetId_InventoryDate(assetid, inventorydate);
        }
        public int delete_Existingdetails_From_Asset(int assetid, string inventorydate)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_ExistingDetails_From_AssetTables(assetid, inventorydate);
        }

        #endregion

}
