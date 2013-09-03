using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;



	public class ChangeApprove_trans
	{
		#region Private Fields
		private string _changestatusdatetime;
		private int _changeid;
		private int _approvestatus;
        private string _ApproverName;
		private string _approvalcomment;
		#endregion

		#region Public Fields
		public string Changestatusdatetime
		{
			 get{ return _changestatusdatetime; }
			 set{ _changestatusdatetime = value; }
		}
		public int Changeid
		{
			 get{ return _changeid; }
			 set{ _changeid = value; }
		}
		public int Approvestatus
		{
			 get{ return _approvestatus; }
			 set{ _approvestatus = value; }
		}
        public string ApproverName
		{
            get { return _ApproverName; }
            set { _ApproverName = value; }
		}
		public string Approvalcomment
		{
			 get{ return _approvalcomment; }
			 set{ _approvalcomment = value; }
		}
		#endregion

		#region Constructors
		public ChangeApprove_trans()		{
		}
		public ChangeApprove_trans(string changestatusdatetime,int changeid,int approvestatus,string approvepersoname,string approvalcomment)		{
			_changestatusdatetime = changestatusdatetime;
			_changeid = changeid;
            _approvestatus = approvestatus;
            _ApproverName = approvepersoname;
			_approvalcomment = approvalcomment;
		}
		#endregion
        #region
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();

            
            return db.Insert_ChangeApprove_trans(this);



        }
        public BLLCollection<ChangeApprove_trans> Get_All_Changeid(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Get_ChangeApprove_trans_All_By_Changeid(changeid);
        }
        #endregion



    } 