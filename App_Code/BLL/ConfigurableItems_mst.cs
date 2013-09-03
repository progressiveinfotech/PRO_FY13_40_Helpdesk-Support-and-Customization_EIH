using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class ConfigurableItems_mst
	{
		#region Private Fields
		private string _param9;
		private string _param8;
		private string _param7;
		private string _param6;
		private string _param5;
		private string _param4;
		private string _param3;
		private string _param2;
		private string _param15;
		private string _param14;
		private string _param13;
		private string _param12;
		private string _param11;
		private string _param10;
		private string _param1;
		private int _itemid;
		#endregion

		#region Public Fields
		public string Param9
		{
			 get{ return _param9; }
			 set{ _param9 = value; }
		}
		public string Param8
		{
			 get{ return _param8; }
			 set{ _param8 = value; }
		}
		public string Param7
		{
			 get{ return _param7; }
			 set{ _param7 = value; }
		}
		public string Param6
		{
			 get{ return _param6; }
			 set{ _param6 = value; }
		}
		public string Param5
		{
			 get{ return _param5; }
			 set{ _param5 = value; }
		}
		public string Param4
		{
			 get{ return _param4; }
			 set{ _param4 = value; }
		}
		public string Param3
		{
			 get{ return _param3; }
			 set{ _param3 = value; }
		}
		public string Param2
		{
			 get{ return _param2; }
			 set{ _param2 = value; }
		}
		public string Param15
		{
			 get{ return _param15; }
			 set{ _param15 = value; }
		}
		public string Param14
		{
			 get{ return _param14; }
			 set{ _param14 = value; }
		}
		public string Param13
		{
			 get{ return _param13; }
			 set{ _param13 = value; }
		}
		public string Param12
		{
			 get{ return _param12; }
			 set{ _param12 = value; }
		}
		public string Param11
		{
			 get{ return _param11; }
			 set{ _param11 = value; }
		}
		public string Param10
		{
			 get{ return _param10; }
			 set{ _param10 = value; }
		}
		public string Param1
		{
			 get{ return _param1; }
			 set{ _param1 = value; }
		}
		public int Itemid
		{
			 get{ return _itemid; }
			 set{ _itemid = value; }
		}
		#endregion

		#region Constructors
		public ConfigurableItems_mst()		{
		}
		public ConfigurableItems_mst(string param9,string param8,string param7,string param6,string param5,string param4,string param3,string param2,string param15,string param14,string param13,string param12,string param11,string param10,string param1,int itemid)		{
			_param9 = param9;
			_param8 = param8;
			_param7 = param7;
			_param6 = param6;
			_param5 = param5;
			_param4 = param4;
			_param3 = param3;
			_param2 = param2;
			_param15 = param15;
			_param14 = param14;
			_param13 = param13;
			_param12 = param12;
			_param11 = param11;
			_param10 = param10;
			_param1 = param1;
			_itemid = itemid;
		}
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Insert_ConfigurableItems_mst(this);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Configurable_mst_By_id(this);
        }
        public ConfigurableItems_mst Get_By_id(int itemid)
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Configurableitem_mst_Get_By_item(itemid);

        }
        public BLLCollection<ConfigurableItems_mst> Get_All_CI_Byitems(int itemid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_ConfigurableItems_mst_All_By_itemid(itemid);
        }
        public BLLCollection<ConfigurableItems_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_ConfigurableItems_All();
        }
        #endregion
    }

