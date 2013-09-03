using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class Incident_NNMcalls : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    int i = 1;
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        GetNNMCalls();
    //    }

    //}
    protected void Page_PreRender(object sender, EventArgs e)
    {
        GetNNMCalls();
    }
    public void OpenConnection()
    {
        string connection = ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString;
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
    }
    public void closeconnection()
    {
        con.Close();
        cmd.Dispose();
        con.Dispose();
    }
    public void GetNNMCalls()
    {
        OpenConnection();
       // cmd.CommandText = "select * from NNMcalls_mst where IsActive=1";
        //cmd.CommandText = "select * from storemail where IsActive=1 order by id";
        cmd.CommandText = "select * from storemail where IsActive=1 order by CreatedDateTime desc";
        SqlDataReader sda = cmd.ExecuteReader();
        DataTable dt = new DataTable();
       
            dt.Load(sda);
        if (dt.Rows.Count > 0)
        {
            gdvNNMcalls.DataSource = dt;
            gdvNNMcalls.DataBind();
        }
        else
        {
            Lblmsg.Visible = true;
            Lblmsg.Text = "No calls found";
        }
       
    }
    public DataTable GetNNMCallsById(int id)
    {
        OpenConnection();
       // cmd.CommandText = "select * from NNMcalls_mst where Id='" + id + "'";
        cmd.CommandText = "select * from storemail where Id='" + id + "'";
        SqlDataReader sda = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(sda);
        return dt;
    }
    protected void gdvNNMcalls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "click")
        {
            int id =Convert.ToInt32(e.CommandArgument);
            DataTable dt = new DataTable();
            dt = GetNNMCallsById(id);
            string subject = dt.Rows[0]["subject"].ToString();
            string body = dt.Rows[0]["Body"].ToString();
            string mailid=dt.Rows[0]["MailFrom"].ToString();
            Session["subject"] = subject;
            Session["body"] = body;
            Session["mail"] = mailid;
            Session["id"] = dt.Rows[0]["id"].ToString();
            string myScript = "<script language=javascript>javascript:window.open('../Incident/NNMtoIncident.aspx','popupwindow','width=540,height=300,left=200,top=250,Scrollbars=yes');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }

    }
    protected void gdvNNMcalls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvNNMcalls.PageIndex = e.NewPageIndex;
        GetNNMCalls();
    }
    protected void gdvNNMcalls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = i.ToString();
            i++;
            // get a refernce to the label 
            Label lbl = e.Row.FindControl("Lblbody") as Label;
            if (lbl.Text.Length > 100)
            {
                string tooltip = lbl.Text;
                string lblText = lbl.Text.Substring(0, 100) + "...";

                lbl.ToolTip = tooltip;
                lbl.Text = lblText;

            }
            else
            {
                lbl.ToolTip = lbl.Text;
                lbl.Text=lbl.Text;
            }

        }
    }
   
}
