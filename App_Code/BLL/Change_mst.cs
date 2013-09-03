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


	public class Change_mst
	{
		#region Private Fields
        private string _title;
        private int _technician;
        private int _subcategoryid;
        private int _statusid;
        private string _sceduledstarttime;
        private string _sceduledendtime;
        private int _requestedby;
        private int _priority;
        private int _impact;
        private string _description;
        private string _createdtime;
        private string _completedtime;
        private int _changetype;
        private int _changeid;
        private int _categoryid;
        private string _assignetime;
        private string _approvalstatus;
        private bool _Active;
        private int _CreatedByid;
        private string _Servicename;


		#endregion

		#region Public Fields
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int Technician
        {
            get { return _technician; }
            set { _technician = value; }
        }
        public int Subcategoryid
        {
            get { return _subcategoryid; }
            set { _subcategoryid = value; }
        }
        public int Statusid
        {
            get { return _statusid; }
            set { _statusid = value; }
        }
        public string Sceduledstarttime
        {
            get { return _sceduledstarttime; }
            set { _sceduledstarttime = value; }
        }
        public string Sceduledendtime
        {
            get { return _sceduledendtime; }
            set { _sceduledendtime = value; }
        }
        public int Requestedby
        {
            get { return _requestedby; }
            set { _requestedby = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public int Impact
        {
            get { return _impact; }
            set { _impact = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Createdtime
        {
            get { return _createdtime; }
            set { _createdtime = value; }
        }
        public string Completedtime
        {
            get { return _completedtime; }
            set { _completedtime = value; }
        }
        public int Changetype
        {
            get { return _changetype; }
            set { _changetype = value; }
        }
        public int Changeid
        {
            get { return _changeid; }
            set { _changeid = value; }
        }
        public int Categoryid
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }
        public string Assignetime
        {
            get { return _assignetime; }
            set { _assignetime = value; }
        }
        public string Approvalstatus
        {
            get { return _approvalstatus; }
            set { _approvalstatus = value; }
        }
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public int CreatedByID
        {
            get { return _CreatedByid; }
            set { _CreatedByid = value; }
        }
        public string servicename
        {
            get { return _Servicename; }
            set { _Servicename = value; }
        }
		#endregion

		#region Constructors
        public Change_mst()
        {
        }
        public Change_mst(string title, int technician, int subcategoryid, int statusid, string sceduledstarttime, string sceduledendtime, int requestedby, int priority, int impact, string description, string createdtime, string completedtime, int changetype, int changeid, int categoryid, string assignetime, string approvalstatus, bool active,int ceatedById,string servicename)
        {
            _title = title;
            _technician = technician;
            _subcategoryid = subcategoryid;
            _statusid = statusid;
            _sceduledstarttime = sceduledstarttime;
            _sceduledendtime = sceduledendtime;
            _requestedby = requestedby;
            _priority = priority;
            _impact = impact;
            _description = description;
            _createdtime = createdtime;
            _completedtime = completedtime;
            _changetype = changetype;
            _changeid = changeid;
            _categoryid = categoryid;
            _assignetime = assignetime;
            _approvalstatus = approvalstatus;
            _Active = active;
            _CreatedByid = ceatedById;
            _Servicename = servicename;
        }
		#endregion
        #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();      
            return db.Insert_Change_mst(this);
         }

        public int Get_Current_Changeid()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Change_mst_Get_Current_Changeid();
        }
        public BLLCollection<Change_mst> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Change_All();
        }
        public Change_mst Get_By_id(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Change_mst_Get_By_changeid(changeid);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
         
            return db.Update_Change_By_id(this);
        }
        public BLLCollection<Change_mst> Get_All_By_Statusid_technicianid(int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Change_mst_All_By_statusid_technicianid(statusid, technicianid, fromdate, todate, varSortParameter);
            
        }
        public BLLCollection<Change_mst> Get_All_By_Statusid(int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
        {
            SqlDataProvider db = new SqlDataProvider();

           
            return db.Get_Change_mst_All_By_statusid(statusid, fromdate, todate, technicianid, varSortParameter);


        }
        #endregion
       

    }

