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
/// Summary description for csm_complaint_mst
/// </summary>
public class csm_complaint_mst
{

    #region Private Fields
    private string _complaintId;
    private string _complaintDesc;
    private string _customerName;
    private string _complaintdate;
    


    #endregion

    #region Public Fields
    public string ComplaintId
    {
        get { return _complaintId; }
        set { _complaintId = value; }
    }
    public string ComplaintDesc
    {
        get { return _complaintDesc; }
        set { _complaintDesc = value; }
    }
    public string CustomerName
    {
        get { return _customerName; }
        set { _customerName = value; }
    }
    
    public string ComplaintDate
    {
        get { return _complaintdate; }
        set { _complaintdate = value; }
    }
    

    #endregion
	public csm_complaint_mst()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region Public Methods





    public csm_complaint_mst Get_By_id(string ComplaintId)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.csm_complaint_mst_Get_By_ComplaintId(ComplaintId);
    }
    public BLLCollection<csm_complaint_mst> Get_All_By_ComplaintId(string ComplaintId)
    {
        SqlDataProvider db = new SqlDataProvider();
   
        return db.Get_csm_complaint_mst_All_By_ComplaintId(ComplaintId);
    }
    public BLLCollection<csm_complaint_mst> Get_All_By_Complaintdate(string Fromdate,string Todate)
    {
        SqlDataProvider db = new SqlDataProvider();

       
        return db.Get_csm_complaint_mst_All_By_ComplaintDate(Fromdate,Todate);
    }

   

    #endregion
}
