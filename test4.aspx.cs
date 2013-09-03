using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class test4 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // InsertIncidentMst();
           // InsertIncidentstatus();
           // Insertslaprioritymst();
           // InsertCusfeedback();
           // InsertCategorymst();
        }
    }

    public void InsertIncidentMst()
    {
        SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");
        DataSet ds = new DataSet();
        ds = fromincidentxml();

        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int incidentid, requesterid, timespentonreq, slaid, siteid, LocationId;
            DateTime createdtime, createddatetime;
            DateTime? completedtime = null;
            string title, active;
            createddatetime = DateTime.Now;
            LocationId = 1;
            incidentid = Convert.ToInt32(ds.Tables[0].Rows[i]["incidentid"]);
            requesterid = Convert.ToInt32(ds.Tables[0].Rows[i]["requesterid"]);
            timespentonreq = Convert.ToInt32(ds.Tables[0].Rows[i]["timespentonreq"]);
            slaid = Convert.ToInt32(ds.Tables[0].Rows[i]["slaid"]);
            siteid = Convert.ToInt32(ds.Tables[0].Rows[i]["siteid"]);
            createdtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["createdatetime"]);
            if (ds.Tables[0].Rows[i]["completedtime"] == DBNull.Value)
            {
                completedtime = null;
            }
            else
            {
                completedtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["completedtime"]);
            }
            title = ds.Tables[0].Rows[i]["title"].ToString();
            title = title.Replace("'", "");
            active = ds.Tables[0].Rows[i]["active"].ToString();
            cmd.CommandText = "insert into incident_mst(incidentid,createdatetime,timespentonreq,slaid,active,siteid,title,requesterid,completedtime,createddatetime,LocationId)values('" + incidentid + "','" + createdtime + "','" + timespentonreq + "','" + slaid + "','" + active + "','" + siteid + "','" + title + "','" + requesterid + "','" + completedtime + "','" + createddatetime + "','" + LocationId + "')";
            cmd.ExecuteNonQuery();
        }
        ds.Clear();
        ds = fromincident2xml();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int incidentid, requesterid, timespentonreq, slaid, siteid, LocationId;
            DateTime createdtime, createddatetime;
            DateTime? completedtime = null;
            string title, active;
            createddatetime = DateTime.Now;
            LocationId = 2;
            incidentid = Convert.ToInt32(ds.Tables[0].Rows[i]["incidentid"]);
            requesterid = Convert.ToInt32(ds.Tables[0].Rows[i]["requesterid"]);
            timespentonreq = Convert.ToInt32(ds.Tables[0].Rows[i]["timespentonreq"]);
            slaid = Convert.ToInt32(ds.Tables[0].Rows[i]["slaid"]);
            siteid = Convert.ToInt32(ds.Tables[0].Rows[i]["siteid"]);
            createdtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["createdatetime"]);
            if (ds.Tables[0].Rows[i]["completedtime"] == DBNull.Value)
            {
                completedtime = null;
            }
            else
            {
                completedtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["completedtime"]);
            }
            title = ds.Tables[0].Rows[i]["title"].ToString();
            title = title.Replace("'", "");
            active = ds.Tables[0].Rows[i]["active"].ToString();
            cmd.CommandText = "insert into incident_mst(incidentid,createdatetime,timespentonreq,slaid,active,siteid,title,requesterid,completedtime,createddatetime,LocationId)values('" + incidentid + "','" + createdtime + "','" + timespentonreq + "','" + slaid + "','" + active + "','" + siteid + "','" + title + "','" + requesterid + "','" + completedtime + "','" + createddatetime + "','" + LocationId + "')";
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }
    public void InsertIncidentstatus()
    {
        SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");
        DataSet ds = new DataSet();
        ds = fromIncidentstatusmst();
        DateTime createddatetime;
        createddatetime = DateTime.Now;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int incidentid, categoryid, technicianid, statusid, priroityid, requesttypeid;
            incidentid = Convert.ToInt32(ds.Tables[0].Rows[i]["incidentid"]);
            categoryid = Convert.ToInt32(ds.Tables[0].Rows[i]["categoryid"]);
            technicianid = Convert.ToInt32(ds.Tables[0].Rows[i]["technicianid"]);
            statusid = Convert.ToInt32(ds.Tables[0].Rows[i]["statusid"]);
            priroityid = Convert.ToInt32(ds.Tables[0].Rows[i]["priorityid"]);
            requesttypeid = Convert.ToInt32(ds.Tables[0].Rows[i]["requesttypeid"]);
            cmd.CommandText = "insert into IncidentStates(incidentid,categoryid,technicianid,statusid,priorityid,requesttypeid,createddatetime,LocationId)values('" + incidentid + "','" + categoryid + "','" + technicianid + "','" + statusid + "','" + priroityid + "','" + requesttypeid + "','" + createddatetime + "','" + 1 + "')";
            cmd.ExecuteNonQuery();
        }
        ds.Clear();
        ds = fromIncidentstatus2mst();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int incidentid, categoryid, technicianid, statusid, priroityid, requesttypeid;
            incidentid = Convert.ToInt32(ds.Tables[0].Rows[i]["incidentid"]);
            categoryid = Convert.ToInt32(ds.Tables[0].Rows[i]["categoryid"]);
            technicianid = Convert.ToInt32(ds.Tables[0].Rows[i]["technicianid"]);
            statusid = Convert.ToInt32(ds.Tables[0].Rows[i]["statusid"]);
            priroityid = Convert.ToInt32(ds.Tables[0].Rows[i]["priorityid"]);
            requesttypeid = Convert.ToInt32(ds.Tables[0].Rows[i]["requesttypeid"]);
            cmd.CommandText = "insert into IncidentStates(incidentid,categoryid,technicianid,statusid,priorityid,requesttypeid,createddatetime,LocationId)values('" + incidentid + "','" + categoryid + "','" + technicianid + "','" + statusid + "','" + priroityid + "','" + requesttypeid + "','" + createddatetime + "','" + 2 + "')";
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }
    public void Insertslaprioritymst()
    {
        SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");
        DataSet ds = new DataSet();
        ds = fromslaprioritymst();
        DateTime createddatetime;
        createddatetime = DateTime.Now;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int prirityid, slaid, resolutiondays, resolutionhours, resolutionmins;
            prirityid = Convert.ToInt32(ds.Tables[0].Rows[i]["priorityid"]);
            slaid = Convert.ToInt32(ds.Tables[0].Rows[i]["SLAid"]);
            resolutiondays = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutiondays"]);
            resolutionhours = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutionhours"]);
            resolutionmins = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutionmin"]);
            cmd.CommandText = "insert into SLA_priority_mst(priorityid,slaid,resolutiondays,resolutionhours,resolutionmin,LocationId,createddatetime)values('" + prirityid + "','" + slaid + "','" + resolutiondays + "','" + resolutionhours + "','" + resolutionmins + "','" + 1 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }
        ds.Clear();
        ds = fromslaprioritymst2();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int prirityid, slaid, resolutiondays, resolutionhours, resolutionmins;
            prirityid = Convert.ToInt32(ds.Tables[0].Rows[i]["priorityid"]);
            slaid = Convert.ToInt32(ds.Tables[0].Rows[i]["SLAid"]);
            resolutiondays = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutiondays"]);
            resolutionhours = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutionhours"]);
            resolutionmins = Convert.ToInt32(ds.Tables[0].Rows[i]["resolutionmin"]);
            cmd.CommandText = "insert into SLA_priority_mst(priorityid,slaid,resolutiondays,resolutionhours,resolutionmin,LocationId,createddatetime)values('" + prirityid + "','" + slaid + "','" + resolutiondays + "','" + resolutionhours + "','" + resolutionmins + "','" + 2 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }
    public DataSet fromslaprioritymst2()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/Data2/SLAPriorityMst.xml");
        return dt;
    }
    public void InsertCusfeedback()
    {
        SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");
        DataSet ds = new DataSet();
        ds = fromcusfeedback();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int Id;
            string feedback;
            DateTime feedbackdate, createddatetime;
            createddatetime = DateTime.Now;
            Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
            feedback = ds.Tables[0].Rows[i]["Feedback"].ToString();
            feedbackdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FeedbackDate"]);
            cmd.CommandText = "insert into CustomerFeedback(Id,Feedback,FeedbackDate,LocationId,createddatetime)values('" + Id + "','" + feedback + "','" + feedbackdate + "','" + 1 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }
        ds.Clear();
        ds = fromcusfeedback2();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int Id;
            string feedback;
            DateTime feedbackdate, createddatetime;
            createddatetime = DateTime.Now;
            Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
            feedback = ds.Tables[0].Rows[i]["Feedback"].ToString();
            feedbackdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FeedbackDate"]);
            cmd.CommandText = "insert into CustomerFeedback(Id,Feedback,FeedbackDate,LocationId,createddatetime)values('" + Id + "','" + feedback + "','" + feedbackdate + "','" + 2 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }
    public void InsertCategorymst()
    {
        SqlConnection con = new SqlConnection("server=PPSO2063D;database=NewBITestDataBase;uid=sa;pwd=rimc_123");
        DataSet ds1 = new DataSet();
        ds1 = fromcategorymst();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            int cateid;
            string catename;
            cateid = Convert.ToInt32(ds1.Tables[0].Rows[i]["categoryid"]);
            catename = ds1.Tables[0].Rows[i]["categoryname"].ToString();
            DateTime createddatetime = DateTime.Now;
            cmd.CommandText = "insert into Category_mst(categoryid,categoryname,LocationId,createddatetime)values('" + cateid + "','" + catename + "','" + 1 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }

        ds1.Clear();
        ds1 = fromcategorymst2();
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            int cateid;
            string catename;
            cateid = Convert.ToInt32(ds1.Tables[0].Rows[i]["categoryid"]);
            catename = ds1.Tables[0].Rows[i]["categoryname"].ToString();
            DateTime createddatetime = DateTime.Now;
            cmd.CommandText = "insert into Category_mst(categoryid,categoryname,LocationId,createddatetime)values('" + cateid + "','" + catename + "','" + 2 + "','" + createddatetime + "')";
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }
    public DataSet fromcategorymst2()
   {
       DataSet dt = new DataSet();
       dt.ReadXml("C:/Data2/CategoryMst.xml");
       return dt;
   }
    public DataSet fromcusfeedback2()
   {
       DataSet dt = new DataSet();
       dt.ReadXml("C:/Data2/CustomerFeedbackMst.xml");
       return dt;
   }
    public DataSet fromincidentxml()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/BIDEsboard/IncidentMst.xml");
        return dt;
    }
    public DataSet fromIncidentstatusmst()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/BIDEsboard/IncidentstatesMst.xml");
        return dt;
    }
    public DataSet fromIncidentstatus2mst()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/Data2/IncidentstatesMst.xml");
        return dt;
    }
    public DataSet fromslaprioritymst()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/BIDEsboard/SLAPriorityMst.xml");
        return dt;
    }
    public DataSet fromcusfeedback()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/BIDEsboard/CustomerFeedbackMst.xml");
        return dt;
    }
    public DataSet fromcategorymst()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/BIDEsboard/CategoryMst.xml");
        return dt;
    }
    public DataSet fromincident2xml()
    {
        DataSet dt = new DataSet();
        dt.ReadXml("C:/Data2/IncidentMst.xml");
        return dt;
    }
}
