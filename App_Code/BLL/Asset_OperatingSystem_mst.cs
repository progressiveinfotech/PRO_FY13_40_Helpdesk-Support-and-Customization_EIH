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


public class Asset_OperatingSystem_mst
{
	    #region Private Fields
		private string _user_name;
		private string _reg_to;
		private string _reg_org;
		private string _reg_code;
		private string _product_key;
		private string _os_name;
		private string _minor_version;
		private string _major_version;
		private string _login_date;
		private string _localization;
		private string _inventory_date;
		private string _install_date;
		private string _build_no;
		private int _assetoperatingid;
		private int _assetid;
		private string _add_info;
		#endregion

		#region Public Fields
		public string User_name
		{
			 get{ return _user_name; }
			 set{ _user_name = value; }
		}
		public string Reg_to
		{
			 get{ return _reg_to; }
			 set{ _reg_to = value; }
		}
		public string Reg_org
		{
			 get{ return _reg_org; }
			 set{ _reg_org = value; }
		}
		public string Reg_code
		{
			 get{ return _reg_code; }
			 set{ _reg_code = value; }
		}
		public string Product_key
		{
			 get{ return _product_key; }
			 set{ _product_key = value; }
		}
		public string Os_name
		{
			 get{ return _os_name; }
			 set{ _os_name = value; }
		}
		public string Minor_version
		{
			 get{ return _minor_version; }
			 set{ _minor_version = value; }
		}
		public string Major_version
		{
			 get{ return _major_version; }
			 set{ _major_version = value; }
		}
		public string Login_date
		{
			 get{ return _login_date; }
			 set{ _login_date = value; }
		}
		public string Localization
		{
			 get{ return _localization; }
			 set{ _localization = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public string Install_date
		{
			 get{ return _install_date; }
			 set{ _install_date = value; }
		}
		public string Build_no
		{
			 get{ return _build_no; }
			 set{ _build_no = value; }
		}
		public int Assetoperatingid
		{
			 get{ return _assetoperatingid; }
			 set{ _assetoperatingid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		public string Add_info
		{
			 get{ return _add_info; }
			 set{ _add_info = value; }
		}
		#endregion

		#region Constructors
		public Asset_OperatingSystem_mst()		{
		}
        public Asset_OperatingSystem_mst(string user_name, string reg_to, string reg_org, string reg_code, string product_key, string os_name, string minor_version, string major_version, string login_date, string localization, string inventory_date, string install_date, string build_no, int assetoperatingid, int assetid, string add_info)
        {
			_user_name = user_name;
			_reg_to = reg_to;
			_reg_org = reg_org;
			_reg_code = reg_code;
			_product_key = product_key;
			_os_name = os_name;
			_minor_version = minor_version;
			_major_version = major_version;
			_login_date = login_date;
			_localization = localization;
			_inventory_date = inventory_date;
			_install_date = install_date;
			_build_no = build_no;
			_assetoperatingid = assetoperatingid;
			_assetid = assetid;
			_add_info = add_info;
		}
		#endregion

        #region Public Methods

        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_OperatingSystem_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_OperatingSystem_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_OperatingSystem_mst_By_id(this);
        }

        public int Delete(int assetOperatingSystemId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_OperatingSystem_mst_By_id(assetOperatingSystemId);
        }

        public BLLCollection<Asset_OperatingSystem_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_OperatingSystem_mst_All();
        }

        public Asset_OperatingSystem_mst Get_By_id(int assetOperatingSystemId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_OperatingSystem_mst_Get_By_assetid(assetOperatingSystemId);
        }
        public Asset_OperatingSystem_mst Get_By_Assetid(int assetId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetOperatingSystem_mst_Get_By_assetid(assetId);
        }

        //Added by lalit on 29 feb
        public BLLCollection<Asset_OperatingSystem_mst> Get_Users()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_OperatingSyste_mst_AllUsers();
        }
        //end
      
        #endregion
}
