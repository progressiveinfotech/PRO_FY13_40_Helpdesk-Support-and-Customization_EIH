using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


public class CustomerFeedback
{
    #region Private Fields
    private int _id;
    private string _feedback;
    private string _feedbacktype;
    private int _incidentid;
    private string _remark;
    #endregion

    #region Public Fields
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Feedback
    {
        get { return _feedback; }
        set { _feedback = value; }
    }
    public string FeedbackType
    {
        get { return _feedbacktype; }
        set { _feedbacktype = value; }
    }
    public int IncidentId
    {
        get { return _incidentid; }
        set { _incidentid = value; }
    }
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }
    #endregion

    #region Constructors
    public CustomerFeedback()
    {
    }
    public CustomerFeedback(int id, string feedback)
    {
        _id = id;
        _feedback = feedback;
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CustomerFeedback_mst(this);

    }

    public int Insert_CallWise()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_CustomerFeedback_mst_callwise(this);
    }


    public CustomerFeedback Get_By_Incidentid(int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();

        return db.CustomerFeedback_mst_Get_By_Incidentid(incidentid);

    }
    //added by lalit to filter user feedback by incidentid,userid to find duplicacy.....1dec2011
    public CustomerFeedback Get_By_Userid_ByIncidentId(int userid, int incidentid)
    {
        SqlDataProvider db = new SqlDataProvider();

        return db.CustomerFeedback_mst_Get_By_Userid_Incidentid(userid, incidentid);

    }
    #endregion
}


