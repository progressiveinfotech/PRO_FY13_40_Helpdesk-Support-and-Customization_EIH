using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


	public class CMDB
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
		private int _assetid;
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
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public CMDB()		{
		}
		public CMDB(string param9,string param8,string param7,string param6,string param5,string param4,string param3,string param2,string param15,string param14,string param13,string param12,string param11,string param10,string param1,int assetid)		{
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
			_assetid = assetid;
		}
		#endregion
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();

            
            return db.Insert_CMDB_mst(this);

        }

        public CMDB Get_By_id(int Assetid)
        {
            SqlDataProvider db = new SqlDataProvider();

         
            return db.CMDB_mst_Get_By_Assetid(Assetid);
        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Update_CMDB_mst_By_id(this);
           
        }

	}

