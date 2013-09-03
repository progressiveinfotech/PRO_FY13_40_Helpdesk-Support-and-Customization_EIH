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
/// Summary description for IncidentToAssetMapping
/// </summary>
public class IncidentToAssetMapping
{
		#region Private Fields
		private int _incidentid;
		private int _assetid;
		#endregion

		#region Public Fields
		public int incidentid
		{
			 get{ return _incidentid; }
			 set{ _incidentid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public IncidentToAssetMapping()		{
		}
        public IncidentToAssetMapping(int incidentid, int assetid)
        {
			_incidentid = incidentid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods
        public int Insert(int incidentid, int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_IncidentToAssetMapping(incidentid, assetid);
        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_IncidentToAssetMapping_By_id(this);
        }

        public int Delete(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_IncidentToAssetMapping_By_id(incidentid);
        }

        public BLLCollection<IncidentToAssetMapping> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_IncidentToAssetMapping_All();
        }

        public IncidentToAssetMapping Get_By_id(int assetId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.IncidentToAssetMapping_Get_By_assetid(assetId);
        }

        public int Get_AssetId_From_incidentToAssetMap(int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetId_From_incidentToAssetMap(assetid);
        }

        public int Get_incidentId_From_incidentToAssetMap(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.incidentId_From_incidentToAssetMap(incidentid);
        }

        public int Get_AssetId_By_incidentId(int incidentid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetId_By_incidentId(incidentid);
        }

        #endregion
}
