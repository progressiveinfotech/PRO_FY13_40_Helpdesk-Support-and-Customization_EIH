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
/// Summary description for Asset_LogicalDrive_mst
/// </summary>
public class Asset_LogicalDrive_mst
{
	    #region Private Fields
		private string _total_bytes;
		private string _inventory_date;
		private string _free_bytes;
		private string _file_system_name;
		private string _drive_type;
		private string _drive_letter;
		private int _assetlogicaldriveid;
		private int _assetid;
		#endregion

		#region Public Fields
		public string Total_bytes
		{
			 get{ return _total_bytes; }
			 set{ _total_bytes = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public string Free_bytes
		{
			 get{ return _free_bytes; }
			 set{ _free_bytes = value; }
		}
		public string File_system_name
		{
			 get{ return _file_system_name; }
			 set{ _file_system_name = value; }
		}
		public string Drive_type
		{
			 get{ return _drive_type; }
			 set{ _drive_type = value; }
		}
		public string Drive_letter
		{
			 get{ return _drive_letter; }
			 set{ _drive_letter = value; }
		}
		public int Assetlogicaldriveid
		{
			 get{ return _assetlogicaldriveid; }
			 set{ _assetlogicaldriveid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public Asset_LogicalDrive_mst()		
        {

		}
        public Asset_LogicalDrive_mst(string total_bytes, string inventory_date, string free_bytes, string file_system_name, string drive_type, string drive_letter, int assetlogicaldriveid, int assetid)
        {
			_total_bytes = total_bytes;
			_inventory_date = inventory_date;
			_free_bytes = free_bytes;
			_file_system_name = file_system_name;
			_drive_type = drive_type;
			_drive_letter = drive_letter;
			_assetlogicaldriveid = assetlogicaldriveid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_LogicalDrive_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_LogicalDrive_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_LogicalDrive_mst_By_id(this);
        }
        public int Delete(int assetLogicalDriveId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_LogicalDrive_mst_By_id(assetLogicalDriveId);
        }


        public BLLCollection<Asset_LogicalDrive_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_LogicalDrive_mst_All();
        }

        public Asset_LogicalDrive_mst Get_By_id(int assetLogicalDriveId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_LogicalDrive_mst_Get_By_assetid(assetLogicalDriveId);
        }

        #endregion

}
