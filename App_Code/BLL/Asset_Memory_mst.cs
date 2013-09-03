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
/// Summary description for Asset_Memory_mst
/// </summary>
public class Asset_Memory_mst
{
	#region Private Fields
		private string _virtual_mem;
		private string _physical_mem;
		private string _page_file;
		private string _inventory_date;
		private int _assetmemoryid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Virtual_mem
		{
			 get{ return _virtual_mem; }
			 set{ _virtual_mem = value; }
		}
		public string Physical_mem
		{
			 get{ return _physical_mem; }
			 set{ _physical_mem = value; }
		}
		public string Page_file
		{
			 get{ return _page_file; }
			 set{ _page_file = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public int Assetmemoryid
		{
			 get{ return _assetmemoryid; }
			 set{ _assetmemoryid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_Memory_mst()		{
		}
        public Asset_Memory_mst(string virtual_mem, string physical_mem, string page_file, string inventory_date, int assetmemoryid, int assetid)
        {
			_virtual_mem = virtual_mem;
			_physical_mem = physical_mem;
			_page_file = page_file;
			_inventory_date = inventory_date;
			_assetmemoryid = assetmemoryid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_Memory_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_Memory_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_Memory_mst_By_id(this);
        }
        public int Delete(int assetMemoryId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_Memory_mst_By_id(assetMemoryId);
        }


        public BLLCollection<Asset_Memory_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_Memory_mst_All();
        }

        public Asset_Memory_mst Get_By_id(int assetMemoryId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_Memory_mst_Get_By_assetid(assetMemoryId);
        }

        public Asset_Memory_mst Get_By_Assetid(int assetId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetMemory_mst_Get_By_assetid(assetId);
        }

        #endregion
}
