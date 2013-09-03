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
/// Summary description for Cab_mst
/// </summary>
public class Cab_mst
{
  
        #region Private Fields
        private string _phone;
        private string _membername;
        private string _emailid;
        private string _date;
        private int _changetypeid;
        private int _cabid;
        #endregion

        #region Public Fields
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Membername
        {
            get { return _membername; }
            set { _membername = value; }
        }
        public string Emailid
        {
            get { return _emailid; }
            set { _emailid = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int Changetypeid
        {
            get { return _changetypeid; }
            set { _changetypeid = value; }
        }
        public int Cabid
        {
            get { return _cabid; }
            set { _cabid = value; }
        }
        #endregion

        #region Constructors
        public Cab_mst()
        {
        }
        public Cab_mst(string phone, string membername, string emailid, string date, int changetypeid, int cabid)
        {
            _phone = phone;
            _membername = membername;
            _emailid = emailid;
            _date = date;
            _changetypeid = changetypeid;
            _cabid = cabid;
        }
        #endregion

        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_Cab_mst(this);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Cab_mst_By_id(this);
        }
        public int Delete(int cabid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_Cab_mst_By_id(cabid);
        }
        public BLLCollection<Cab_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Cab_mst_All();
        }

        public Cab_mst Get_By_id(int cabid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Cab_mst_Get_By_cabid(cabid);
        }

        public Cab_mst Get_Cab_By_membername(string membername)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Cab_By_membername(membername);
        }

        public BLLCollection<Cab_mst> Get_All_By_ChangeTypeid(int Changetypeid)
        {
            SqlDataProvider db = new SqlDataProvider();

            return db.Get_CabMember_mst_All_By_ChangeTypeid(Changetypeid);

        }


        #endregion

}

