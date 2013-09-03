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

public partial class Problem_SolutionandWorkaroundWindow : System.Web.UI.Page
{
    Problem_mst Objproblem = new Problem_mst();
    SolutionKeyword ObjSolutionKeyword = new SolutionKeyword();
    SolutionCreator ObjSolutionCreator = new SolutionCreator();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Category_mst ObjCategory = new Category_mst();
    Solution_mst ObjSolution = new Solution_mst();
    ProblemToSolution ObjproblemToSolution = new ProblemToSolution();
    BLLCollection<ProblemToSolution> colproblems = new BLLCollection<ProblemToSolution>();
    ProblemHistory ObjProblemHistory = new ProblemHistory();
    ProblemHistoryDiff ObjProblemHistoryDiff = new ProblemHistoryDiff();
    SentMailToUser objSentMailToUser = new SentMailToUser();

    int problemid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                int problemid = Convert.ToInt32(Request.QueryString[1]);
                int flag = Convert.ToInt32(Request.QueryString[0]);

                Objproblem = Objproblem.Get_By_id(problemid);
                txtTitle.Text = Objproblem.title.ToString();
                BindDrpCategory();
                if (flag == 3)
                {
                    updateSolution();
                }
                if (flag == 4)
                {

                    updateWorkaround();
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
    protected void updateWorkaround()
    {
        int problemid = Convert.ToInt32(Request.QueryString[1]);
        int flag = Convert.ToInt32(Request.QueryString[0]);
        colproblems = ObjproblemToSolution.Get_All_Problemid(problemid);
        foreach (ProblemToSolution obj in colproblems)
        {

            if (obj.Solutiontype == "WorkAround")
            {
                ObjSolution = ObjSolution.Get_By_id(obj.Solutionid);
                if (ObjSolution.Solution == "WorkAround")
                {
                    ObjSolutionKeyword = ObjSolutionKeyword.Get_By_id(obj.Solutionid);
                    txtTitle.Text = ObjSolution.Title.ToString();
                    txtKeywords.Text = ObjSolutionKeyword.Keywords.ToString();
                    drpTopic.SelectedValue = Convert.ToString(ObjSolution.Topicid);
                    Editor.Text = ObjSolution.Content.ToString();
                }
            }

        }

    }



    protected void updateSolution()
    {
        int problemid = Convert.ToInt32(Request.QueryString[1]);
        int flag = Convert.ToInt32(Request.QueryString[0]);
        colproblems = ObjproblemToSolution.Get_All_Problemid(problemid);
        foreach (ProblemToSolution obj in colproblems)
        {
            if (obj.Problemid != 0)
            {
                if (obj.Solutiontype == "Solution")
                {
                    ObjSolution = ObjSolution.Get_By_id(obj.Solutionid);
                    if (ObjSolution.Solution == "Solution")
                    {
                        ObjSolutionKeyword = ObjSolutionKeyword.Get_By_id(ObjSolution.Solutionid);
                        txtTitle.Text = ObjSolution.Title.ToString();
                        txtKeywords.Text = ObjSolutionKeyword.Keywords.ToString();
                        drpTopic.SelectedValue = Convert.ToString(ObjSolution.Topicid);
                        Editor.Text = ObjSolution.Content.ToString();
                    }
                }

            }

        }


    }

    protected void btnSolutionAdd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string Prev_value = "";
            string Curr_value = "";
            int SolutionType = Convert.ToInt32(Request.QueryString[0]);
            int problemid = Convert.ToInt32(Request.QueryString[1]);
            if (SolutionType != 0)
            {
                if (SolutionType == 1)
                {
                    string userName;
                    MembershipUser User = Membership.GetUser();
                    userName = User.UserName.ToString();
                    int userid;
                    objOrganization = objOrganization.Get_Organization();
                    objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);

                    int Solutionid;
                    ObjSolution.Title = txtTitle.Text.ToString();
                    ObjSolution.Content = Editor.Text.ToString();
                    ObjSolution.Topicid = Convert.ToInt32(drpTopic.SelectedValue);
                    ObjSolution.Solution = "WorkAround";
                    ObjSolution.Insert();
                    Solutionid = ObjSolutionKeyword.Get_SolutionId();
                    ObjproblemToSolution.Problemid = problemid;
                    ObjproblemToSolution.Solutionid = Solutionid;
                    ObjproblemToSolution.Solutiontype = "WorkAround";
                    ObjproblemToSolution.Insert();
                    ObjSolutionKeyword.Keywords = txtKeywords.Text.ToString();
                    ObjSolutionKeyword.Solutionid = Solutionid;
                    ObjSolutionKeyword.Insert();
                    ObjSolutionCreator.Solutionid = Solutionid;
                    ObjSolutionCreator.Createdby = objUser.Userid;
                    ObjSolutionCreator.Insert();
                    objSentMailToUser.SentMailToPManager(Solutionid);
                }
                if (SolutionType == 4)
                {
                    string userName;
                    MembershipUser User = Membership.GetUser();
                    userName = User.UserName.ToString();
                    int userid;
                    objOrganization = objOrganization.Get_Organization();
                    objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
                    problemid = Convert.ToInt32(Request.QueryString[1]);
                    colproblems = ObjproblemToSolution.Get_All_Problemid(problemid);
                    foreach (ProblemToSolution obj in colproblems)
                    {
                        if (obj.Solutiontype == "WorkAround")
                        {
                            ObjSolution.Solutionid = obj.Solutionid;

                        }

                    }

                    ObjSolution.Solution = "WorkAround";
                    ObjSolution.Content = Editor.Text.ToString();
                    ObjSolution.Title = txtTitle.Text.ToString();
                    ObjSolution.Topicid = Convert.ToInt32(drpTopic.SelectedValue);
                    ObjSolution.Update();
                    ObjSolutionKeyword.Keywords = txtKeywords.Text.ToString();
                    ObjSolutionKeyword.Solutionid = Convert.ToInt32(ObjSolution.Solutionid);
                    ObjSolutionKeyword.Update();
                    ObjSolutionCreator.LastUpdateBy = objUser.Userid;
                    ObjSolutionCreator.LastUpdateon = DateTime.Now.ToString();
                    ObjSolutionCreator.Update();

                }




                if (SolutionType == 3)
                {
                    string userName;
                    MembershipUser User = Membership.GetUser();
                    userName = User.UserName.ToString();
                    int userid;
                    objOrganization = objOrganization.Get_Organization();
                    objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
                    problemid = Convert.ToInt32(Request.QueryString[1]);
                    colproblems = ObjproblemToSolution.Get_All_Problemid(problemid);
                    foreach (ProblemToSolution obj in colproblems)
                    {
                        if (obj.Solutiontype == "Solution")
                        {
                            ObjSolution.Solutionid = obj.Solutionid;

                        }

                    }

                    ObjSolution.Solution = "Solution";
                    ObjSolution.Content = Editor.Text.ToString();
                    ObjSolution.Title = txtTitle.Text.ToString();
                    ObjSolution.Topicid = Convert.ToInt32(drpTopic.SelectedValue);
                    ObjSolution.Update();
                    ObjSolutionKeyword.Keywords = txtKeywords.Text.ToString();
                    ObjSolutionKeyword.Solutionid = Convert.ToInt32(ObjSolution.Solutionid);
                    ObjSolutionKeyword.Update();
                    ObjSolutionCreator.LastUpdateBy = objUser.Userid;
                    ObjSolutionCreator.LastUpdateon = DateTime.Now.ToString();
                    ObjSolutionCreator.Update();



                }
                if (SolutionType == 2)
                {
                    string userName;
                    MembershipUser User = Membership.GetUser();
                    userName = User.UserName.ToString();
                    int userid;
                    objOrganization = objOrganization.Get_Organization();
                    objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);

                    // ObjproblemToSolution = ObjproblemToSolution.Get_All_Problemid(problemid);
                    int Solutionid;
                    ObjSolution.Title = txtTitle.Text.ToString();
                    ObjSolution.Content = Editor.Text.ToString();
                    ObjSolution.Topicid = Convert.ToInt32(drpTopic.SelectedValue);
                    ObjSolution.Solution = "Solution";
                    ObjSolution.Insert();
                    Solutionid = ObjSolutionKeyword.Get_SolutionId();
                    ObjproblemToSolution.Problemid = problemid;
                    ObjproblemToSolution.Solutionid = Solutionid;
                    ObjproblemToSolution.Solutiontype = "Solution";
                    ObjproblemToSolution.Insert();
                    ObjSolutionKeyword.Keywords = txtKeywords.Text.ToString();
                    ObjSolutionKeyword.Solutionid = Solutionid;
                    ObjSolutionKeyword.Insert();
                    ObjSolutionCreator.Solutionid = Solutionid;
                    ObjSolutionCreator.Createdby = objUser.Userid;
                    ObjSolutionCreator.Insert();
                    objSentMailToUser.SentMailToPManager(Solutionid);

                }

            }

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
    public void BindDrpCategory()
    {
        // Declare col as Collection of Category_mst Object to get all records from table 
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        // declare object objOrganization of Category_mst_mst Class to call function Get_All() to fetch all records from database

        // Assign all records to variable col 
        col = ObjCategory.Get_All();
        drpTopic.DataTextField = "CategoryName";
        drpTopic.DataValueField = "categoryid";
        drpTopic.DataSource = col;
        drpTopic.DataBind();


        // Declare item as listItem to assign default value to drop down
        ListItem item = new ListItem();
        item.Text = Resources.MessageResource.errSelectTopic.ToString();
        item.Value = "0";
        drpTopic.Items.Add(item);
        drpTopic.SelectedValue = "0";






    }

    protected void btnbtnclose_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
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

}
