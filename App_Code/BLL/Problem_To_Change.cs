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
/// Summary description for Problem_To_Change
/// </summary>
public class Problem_To_Change
{
    #region Private Fields
    private int _problemid;
    private int _changeid;
    #endregion
    #region Public Fields
    public int Problemid
    {
        get { return _problemid; }
        set { _problemid = value; }
    }
    public int Changeid
    {
        get { return _changeid; }
        set { _changeid = value; }
    }
    #endregion

    #region Constructors
    public Problem_To_Change()
    {	}
    public Problem_To_Change(int problemid, int changeid)		
        {
			_problemid = problemid;
            _changeid = changeid;
		}
		#endregion

    #region Public Methods
        public int Insert()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Insert_Problem_To_Change(this);

        }
        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Update_Problem_To_Change_By_id(this);
        }
        public int Delete(int problemid)
        {
            SqlDataProvider db = new SqlDataProvider();
           
            return db.Delete_Problem_To_Change_By_id(problemid);
        }

        public BLLCollection<Problem_To_Change> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            
            return db.Get_Problem_To_Change_All();
        }

        public BLLCollection<Problem_To_Change> Get_All_By_changeid(int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_Problem_To_Change_All_By_Changeid(changeid);
        }
        public Problem_To_Change Get_By_id(int problemid,int changeid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Problem_To_Change_Get_By_problemid(problemid, changeid);


           
        }


        #endregion
	

}
