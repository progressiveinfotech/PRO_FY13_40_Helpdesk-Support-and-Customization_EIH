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

public partial class KEDB_ApproveActions : System.Web.UI.Page
{
    Solution_mst ObjSolution = new Solution_mst();
    SolutionCreator ObjSolutionCreator = new SolutionCreator();
    UserLogin_mst objUser = new UserLogin_mst();
    Organization_mst Objorganization = new Organization_mst();
    public int flag;
    public int solutionstatusid;


    protected void Page_Load(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (!IsPostBack)
            {
                int stid = Convert.ToInt32(Request.QueryString[0]);
                flag = Convert.ToInt32(Request.QueryString[1]);
                solutionstatusid = Convert.ToInt32(Request.QueryString[0]);

                if (stid == 1)
                {
                    lblapprove.Visible = true;
                    lblreject.Visible = false;
                    lblapprove.Text = "Approve Comments";
                    btnreject.Visible = false;

                }
                else
                {
                    lblapprove.Visible = false;
                    lblreject.Visible = true;
                    lblreject.Text = "Reject Comments";
                    btnapprove.Visible = false;
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
    public void updatecomment()
    {
        string userName;
        MembershipUser User = Membership.GetUser();

        solutionstatusid = Convert.ToInt32(Request.QueryString[0]);
        flag = Convert.ToInt32(Request.QueryString[1]);
        int userid;
        if (flag == 3)
        {
            string seeionsid = Session["SolutionId"].ToString();

            string[] str = seeionsid.Split(new char[] { ',' });
            foreach (string s in str)
            {
                if (s == "")
                {
                    break;
                }
                int solid = Convert.ToInt32(s);
                ObjSolution = ObjSolution.Get_By_id(solid);
                ObjSolution.Title = ObjSolution.Title;
                ObjSolution.Topicid = ObjSolution.Topicid;
                ObjSolution.Content = ObjSolution.Content;
                ObjSolution.Comments = txtcomments.Text;
                ObjSolution.SolutionStatus = solutionstatusid;
                ObjSolution.Update();

                userName = User.UserName.ToString();

                Objorganization = Objorganization.Get_Organization();
                objUser = objUser.Get_UserLogin_By_UserName(userName, Objorganization.Orgid);
                ObjSolutionCreator.Solutionid = solid;
                ObjSolutionCreator.LastUpdateBy = objUser.Userid;
                ObjSolutionCreator.Update();
            }
        }
        else
        {
            int solutionid = Convert.ToInt32(Request.QueryString[1]);

            ObjSolution = ObjSolution.Get_By_id(solutionid);
            ObjSolution.Title = ObjSolution.Title;
            ObjSolution.Topicid = ObjSolution.Topicid;
            ObjSolution.Content = ObjSolution.Content;
            ObjSolution.Comments = txtcomments.Text;
            ObjSolution.SolutionStatus = solutionstatusid;
            ObjSolution.Update();

            userName = User.UserName.ToString();

            Objorganization = Objorganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, Objorganization.Orgid);
            ObjSolutionCreator.Solutionid = solutionid;
            ObjSolutionCreator.LastUpdateBy = objUser.Userid;
            ObjSolutionCreator.Update();
        }

    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            updatecomment();
            int x = 2;
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
    protected void btnreject_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            updatecomment();
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

    }


}
