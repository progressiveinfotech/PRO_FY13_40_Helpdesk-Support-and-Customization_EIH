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

public partial class KEDB_EditSolution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (!IsPostBack)
            {
                lnkapprovesolution.Attributes.Add("Onclick", "OpenNewwindow()");
                BindDrpCategory();
                ShowPanal1();


            }
            MembershipUser User = Membership.GetUser();
            string userName = User.UserName.ToString();
            if (Roles.IsUserInRole(userName, "PManager") || Roles.IsUserInRole(userName, "admin"))
            {
                lnkApprovesection.Visible = true;
                lnkapprovesolution.Visible = true;
                lnkrejectsolution.Visible = true;
            }
            else
            {
                lnkApprovesection.Visible = false;
                lnkapprovesolution.Visible = false;
                lnkrejectsolution.Visible = false;
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
    Solution_mst ObjSolution = new Solution_mst();
    SolutionKeyword ObjSolutionKeyword = new SolutionKeyword();
    Category_mst ObjCategory = new Category_mst();
    SolutionCreator ObjSolutionCreator = new SolutionCreator();
    UserLogin_mst objUser = new UserLogin_mst();

    protected void UpdateSolution()
    {
        int Solutionid = Convert.ToInt32(Request.QueryString[0]);
        ObjSolution = ObjSolution.Get_By_id(Solutionid);
        ObjSolutionKeyword = ObjSolutionKeyword.Get_By_id(Solutionid);
        txtTitle.Text = ObjSolution.Title.ToString();
        Editor.Text = ObjSolution.Content.ToString();
        drpTopic.SelectedValue = ObjSolution.Topicid.ToString();
        ObjSolutionKeyword = ObjSolutionKeyword.Get_By_id(Solutionid);
        txtKeywords.Text = ObjSolutionKeyword.Keywords.ToString();
    }

    public void BindDrpCategory()
    {
        // Declare col as Collection of Category_mst Object to get all records from table 
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        // declare object objOrganization of Category_mst_mst Class to call function Get_All() to fetch all records from database


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

    protected void ShowPanal1()
    {
        panShowdata.Visible = true;
        panEditData.Visible = false;

        int Solutionid = Convert.ToInt32(Request.QueryString[0]);
        ObjSolution = ObjSolution.Get_By_id(Solutionid);
        ObjSolutionKeyword = ObjSolutionKeyword.Get_By_id(Solutionid);
        if (ObjCategory.CategoryName == null)
        {
            lbltitle.Text = ObjSolution.Title.ToString();
            lblcontent.Text = ObjSolution.Content.ToString();
            ObjCategory = ObjCategory.Get_By_id(ObjSolution.Topicid);
            lbltopic.Text = "";
            lblkeyword.Text = ObjSolutionKeyword.Keywords.ToString();
            lblsolid.Text = Solutionid.ToString();
            editsolheader.Visible = false;
        }
        else
        {
            lbltitle.Text = ObjSolution.Title.ToString();
            lblcontent.Text = ObjSolution.Content.ToString();
            ObjCategory = ObjCategory.Get_By_id(ObjSolution.Topicid);
            lbltopic.Text = ObjCategory.CategoryName.ToString();
            lblkeyword.Text = ObjSolutionKeyword.Keywords.ToString();
            lblsolid.Text = Solutionid.ToString();
            editsolheader.Visible = false;
        }

        int status = Convert.ToInt32(ObjSolution.SolutionStatus);
        if (status == 1)
        {
            imgapprove.Visible = true;
            Imgunapproved.Visible = false;
            lblapprove.Text = "Approve";
        }
        else if (status == 2)
        {
            Imgunapproved.Visible = true;
            imgapprove.Visible = false;
            lblapprove.Text = "Rejected";
        }
        else
        {
            imgapprove.Visible = false;
            Imgunapproved.Visible = false;
            lblapprove.Text = "UnApproved";
        }

        ObjSolutionCreator = ObjSolutionCreator.Get_By_id(ObjSolution.Solutionid);

        int userid = Convert.ToInt32(ObjSolutionCreator.Createdby);
        objUser = objUser.Get_By_id(userid);

        lblcreatedby.Text = objUser.Username.ToString();
        lblcreatedon.Text = ObjSolutionCreator.CreateDatetime.ToString();
        int lastupdateid = Convert.ToInt32(ObjSolutionCreator.LastUpdateBy);
        if (lastupdateid != 0)
        {
            objUser = objUser.Get_By_id(lastupdateid);
            lbllastupdateon.Text = ObjSolutionCreator.LastUpdateon.ToString();
            lbllastupdate.Text = objUser.Username.ToString();

        }
        else
        {
            lbllastupdateon.Text = "";
            lbllastupdate.Text = "";

        }



        //if (objUser.Username == "")
        //{
        //    lbllastupdate.Text = objUser.Username.ToString();
        //    lbllastupdate.Text = objUser.Username.ToString();

        //}

        //else
        //{
        //    lbllastupdate.Text = "";
        //    lbllastupdateon.Text = "";
        //}
        //if (objUser.Username != "")
        //{
        //    lbllastupdate.Text = objUser.Username.ToString();

        //}
        //if (ObjSolutionCreator.LastUpdateon == "")
        //{
        //    lbllastupdateon.Text = ObjSolutionCreator.LastUpdateon.ToString();

        //}
        //if (ObjSolutionCreator.LastUpdateon != "")
        //{
        //    lbllastupdateon.Text = ObjSolutionCreator.LastUpdateon.ToString();

        //}

    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            editsolheader.Visible = false;
            panShowdata.Visible = false;
            panEditData.Visible = true;
            lnkEdit.Visible = true;
            editsolheader.Visible = true;
            solheader.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            UpdateSolution();
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
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            lnkEdit.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            solheader.Visible = true;
            editsolheader.Visible = false;
            ShowPanal1();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ObjSolution.Solutionid = Convert.ToInt32(Request.QueryString[0]);
            ObjSolution.Content = Editor.Text.ToString();
            ObjSolution.Title = txtTitle.Text.ToString();
            ObjSolution.Topicid = Convert.ToInt32(drpTopic.SelectedValue);
            ObjSolution.Update();
            ObjSolutionKeyword.Keywords = txtKeywords.Text.ToString();
            ObjSolutionKeyword.Solutionid = Convert.ToInt32(ObjSolution.Solutionid);
            ObjSolutionKeyword.Update();
            lnkEdit.Visible = true;
            ShowPanal1();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkapprovesolution_Click(object sender, EventArgs e)
    {


    }

    protected void lnkback_Click(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("~/KEDB/ViewSolution.aspx");
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
