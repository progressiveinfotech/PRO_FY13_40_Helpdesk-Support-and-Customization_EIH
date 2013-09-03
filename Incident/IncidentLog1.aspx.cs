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

public partial class Incident_IncidentLog1 : System.Web.UI.Page
{
    Incident_mst objIncident = new Incident_mst();
    IncidentLog objIncidentLog = new IncidentLog();
    UserLogin_mst objUser = new UserLogin_mst();
    Organization_mst objOrganization = new Organization_mst();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnapprove_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int userid = 0;
            int incidentid = Convert.ToInt32(Session["incidentid"].ToString());
            if (incidentid != 0)
            {



                string userName = "";
                MembershipUser User = Membership.GetUser();
                if (User != null)
                {
                    userName = User.UserName.ToString();
                }


                if (userName != "")
                {

                    objOrganization = objOrganization.Get_Organization();
                    objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
                    if (objUser.Userid != 0)
                    {
                        userid = objUser.Userid;
                    }
                }

                objIncidentLog.Incidentid = incidentid;
                objIncidentLog.Userid = userid;
                objIncidentLog.Incidentlog = txtcomments.Text;
                objIncidentLog.Insert();

                string myScript;
                myScript = "<script language=javascript>javascript:window.close();</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);


            }
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
