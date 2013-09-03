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
/// Summary description for Asset_Network_mst
/// </summary>
public class Asset_Network_mst
{
	    #region Private Fields
		private string _type;
		private string _subnet_mask;
		private string _protocol_name;
		private string _mtu;
		private string _mac_address;
		private string _link_speed;
		private string _ip_address;
		private string _inventory_date;
		private string _gateway;
		private int _assetnetworkid;
		private int _assetid;
		private string _adapter_name;
		#endregion

		#region Public Fields
		public string Type
		{
			 get{ return _type; }
			 set{ _type = value; }
		}
		public string Subnet_mask
		{
			 get{ return _subnet_mask; }
			 set{ _subnet_mask = value; }
		}
		public string Protocol_name
		{
			 get{ return _protocol_name; }
			 set{ _protocol_name = value; }
		}
		public string Mtu
		{
			 get{ return _mtu; }
			 set{ _mtu = value; }
		}
		public string Mac_address
		{
			 get{ return _mac_address; }
			 set{ _mac_address = value; }
		}
		public string Link_speed
		{
			 get{ return _link_speed; }
			 set{ _link_speed = value; }
		}
		public string Ip_address
		{
			 get{ return _ip_address; }
			 set{ _ip_address = value; }
		}
		public string Inventory_date
		{
			 get{ return _inventory_date; }
			 set{ _inventory_date = value; }
		}
		public string Gateway
		{
			 get{ return _gateway; }
			 set{ _gateway = value; }
		}
		public int Assetnetworkid
		{
			 get{ return _assetnetworkid; }
			 set{ _assetnetworkid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		public string Adapter_name
		{
			 get{ return _adapter_name; }
			 set{ _adapter_name = value; }
		}
		#endregion

		#region Constructors
		public Asset_Network_mst()		{
		}
        public Asset_Network_mst(string type, string subnet_mask, string protocol_name, string mtu, string mac_address, string link_speed, string ip_address, string inventory_date, string gateway, int assetnetworkid, int assetid, string adapter_name)
        {
			_type = type;
			_subnet_mask = subnet_mask;
			_protocol_name = protocol_name;
			_mtu = mtu;
			_mac_address = mac_address;
			_link_speed = link_speed;
			_ip_address = ip_address;
			_inventory_date = inventory_date;
			_gateway = gateway;
			_assetnetworkid = assetnetworkid;
			_assetid = assetid;
			_adapter_name = adapter_name;
		}
		#endregion

        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Asset_Network_mst(this);

        }

        public int Insert1()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert1_Asset_Network_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Asset_Network_mst_By_id(this);
        }
        public int Delete(int assetNetworkId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Asset_Network_mst_By_id(assetNetworkId);
        }


        public BLLCollection<Asset_Network_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Asset_Network_mst_All();
        }

        public Asset_Network_mst Get_By_id(int assetNetworkId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Asset_Network_mst_Get_By_assetid(assetNetworkId);
        }

        #endregion
}
