using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Master_MasterUser : System.Web.UI.MasterPage
{
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (!IsPostBack)
            {

                MembershipUser User = Membership.GetUser();
                objOrganization = objOrganization.Get_Organization();
                int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
                if (userid != 0)
                {
                    objContact = objContact.Get_By_id(userid);
                    lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;


                }


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
    protected void lnkShowRequest_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            Response.Redirect("../Login/AllUserCall.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkNewRequest_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../Login/UserCall.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            string myScript;
            string solution = txtSolution.Text;
            string url = "../Incident/SearchSolution.aspx?solution=" + solution;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes')", "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');", true);

            myScript = "<script language=javascript>javascript:window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }
}
