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

public partial class Problem_ProblemNotes : System.Web.UI.Page
{
    ProblemNotes ObjProblemNotes = new ProblemNotes();
    UserLogin_mst ObjUser = new UserLogin_mst();
    Organization_mst ObjOrganization = new Organization_mst();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            #region Fetch Current User

            // Fetch Current User and assign to local variable userName
            MembershipUser User = Membership.GetUser();
            string userName = User.UserName.ToString();
            #endregion
            ObjOrganization = ObjOrganization.Get_Organization();
            int orgid = Convert.ToInt32(ObjOrganization.Orgid);
            int userid = ObjUser.Get_By_UserName(userName, orgid);
            ObjProblemNotes.UserName = userid;
            ObjProblemNotes.Problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProblemNotes.Comments = txtcomments.Text.ToString();
            ObjProblemNotes.Insert();
            string myScript;
            myScript = "<script language=javascript>refreshParent();</script>";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtcomments.Text = "";


    }
}
