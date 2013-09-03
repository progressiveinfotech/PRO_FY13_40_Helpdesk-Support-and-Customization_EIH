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
using System.Text.RegularExpressions;

public partial class KEDB_ViewSolution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            MembershipUser User = Membership.GetUser();
            string userName = User.UserName.ToString();
            if (!IsPostBack)
            {
                if (Roles.IsUserInRole(userName, "PManager"))
                {
                    drpfilter.SelectedValue = "0";
                    LoadDataForFilterParameter();
                }
                else
                {
                    LoadData();
                }



            }

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
    Category_mst ObjCategory = new Category_mst();
    SolutionKeyword ObjSolutionKeyword = new SolutionKeyword();
    SolutionCreator Objsolutioncreator = new SolutionCreator();
    public int Solutionid;
    public int approvestatus;



    public string ConvertHtmlToPlainText(string htmlText)
    {
        string temp;
        return Regex.Replace(htmlText, "<[^>]*>", string.Empty);

    }










    public void Repeter_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            int topicid;

            //topicid = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "topicid"));
            Label topicidL = (Label)e.Item.FindControl("lbltopicid");
            topicid = Convert.ToInt32(topicidL.Text);
            ObjCategory = ObjCategory.Get_By_id(topicid);
            topicidL.Text = ObjCategory.CategoryName;
            topicidL.Visible = true;


        }
        else if (e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int topicid;

            //topicid = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "topicid"));
            Label topicidL = (Label)e.Item.FindControl("lbltopicid");
            topicid = Convert.ToInt32(topicidL.Text);
            ObjCategory = ObjCategory.Get_By_id(topicid);
            topicidL.Text = ObjCategory.CategoryName;
            topicidL.Visible = true;


        }


        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            CheckBox ck = (CheckBox)e.Item.FindControl("CheckBox1");

            Label lbl = (Label)e.Item.FindControl("lblapprove");
            Label solutionid = (Label)e.Item.FindControl("lblsolutionid");
            Image imgapprove = (Image)e.Item.FindControl("imgapprove");
            Image imgreject = (Image)e.Item.FindControl("Imgunapproved");
            int slid = Convert.ToInt32(solutionid.Text);
            int solid = Convert.ToInt32(solutionid.Text);

            ObjSolution = ObjSolution.Get_By_id(solid);
            approvestatus = Convert.ToInt32(ObjSolution.SolutionStatus);
            if (approvestatus == 1)
            {


                lbl.Text = "Approved";
                imgapprove.Visible = true;
                imgreject.Visible = false;


            }

            else if (approvestatus == 2)
            {

                lbl.Text = "Rejected";
                imgapprove.Visible = false;
                imgreject.Visible = true;

            }
            else
            {

                lbl.Text = "Unapproved";
                imgapprove.Visible = false;
                imgreject.Visible = false;

            }

        }
    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand += new RepeaterCommandEventHandler(rptPages_ItemCommand);

    }
    private void LoadData()
    {
        BLLCollection<Solution_mst> col = new BLLCollection<Solution_mst>();
        if (txtsearch.Text == "")
        {
            col = ObjSolution.Get_All();

        }
        else
        {

            string kewords = txtsearch.Text.ToString();
            col = ObjSolution.Get_SearchSolution_All(kewords);

        }


        PagedDataSource pgitems = new PagedDataSource();

        pgitems.DataSource = col;
        pgitems.AllowPaging = true;
        pgitems.PageSize = 5;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPages.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages.Visible = true;
            rptPages.DataSource = pages;

            rptPages.DataBind();

        }
        else


            rptPages.Visible = false;

        Repeter.DataSource = pgitems;
        Repeter.DataBind();


    }
    void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        LoadData();
    }



    protected void btnsearch_Click(object sender, EventArgs e)
    {
        LoadData();
        txtsearch.Text = "";
    }
    protected void drpfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpfilter.SelectedValue == "3")
        {
            LoadData();
        }
        else { LoadDataForFilterParameter(); }


    }


    protected void btn_Click(object sender, EventArgs e)
    {
        LoadData();
        CheckBox rdo = new CheckBox();



        foreach (RepeaterItem ri in Repeter.Items)
        {
            CheckBox rb = (CheckBox)ri.FindControl("CheckBox1");
            if (rb.Checked)
            {
                // value = value + rb.Checked;
            }


            txtsearch.Text = rb.Checked.ToString();

        }



    }


    //protected void lnkEdit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/KEDB/AddSolution.aspx");

    //}


    protected void lnkapprovesolution_Click(object sender, EventArgs e)
    {
        string SolutionId = "";
        foreach (RepeaterItem gv in Repeter.Items)
        {
            string gvIDs;

            int FlagStatus = 0;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // Get the Site Id from variable of Label type declare in GridView of grdvwSite
            gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
            // Check if gvIDs is not null
            if (gvIDs != "")
            {


                if (deleteChkBxItem.Checked)
                {
                    SolutionId = SolutionId + Convert.ToInt32(gvIDs) + ",";

                }



            }

        }
        Session["SolutionId"] = SolutionId;
        string myScript;
        myScript = "<script language=javascript>OpenNewApprovewindow();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

    }

    protected void lnkrejectsolution_Click(object sender, EventArgs e)
    {
        string SolutionId = "";
        foreach (RepeaterItem gv in Repeter.Items)
        {
            string gvIDs;

            int FlagStatus = 0;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // Get the Site Id from variable of Label type declare in GridView of grdvwSite
            gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
            // Check if gvIDs is not null
            if (gvIDs != "")
            {


                if (deleteChkBxItem.Checked)
                {
                    SolutionId = SolutionId + Convert.ToInt32(gvIDs) + ",";

                }



            }

        }
        Session["SolutionId"] = SolutionId;
        string myScript;
        myScript = "<script language=javascript>OpenNewRejectwindow();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

    }

    //protected void lnkdelete_Click(object sender, EventArgs e)
    //{
    //    string SolutionId = "";
    //    foreach (RepeaterItem gv in Repeter.Items)
    //    {
    //        string gvIDs;

    //        int FlagStatus = 0;
    //        // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
    //        CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
    //        // Get the Site Id from variable of Label type declare in GridView of grdvwSite
    //        gvIDs = ((Label)gv.FindControl("SiteID")).Text.ToString();
    //        // Check if gvIDs is not null
    //        if (gvIDs != "")
    //        {


    //            if (deleteChkBxItem.Checked)
    //            {
    //                SolutionId = SolutionId + Convert.ToInt32(gvIDs) + ",";

    //            }



    //        }

    //    }



    //     string[] str = SolutionId.Split(new char[] { ',' });
    //        foreach (string s in str)
    //        {
    //            if (s == "")
    //            {
    //                break;
    //            }
    //            int solid = Convert.ToInt32(s);
    //            Objsolutioncreator.Delete(solid);
    //            ObjSolutionKeyword.Delete(solid);
    //            ObjSolution.Delete(solid);
    //        }

    //        Response.Redirect("~/KEDB/ViewSolution.aspx");


    //}



    private void LoadDataForFilterParameter()
    {
        BLLCollection<Solution_mst> col = new BLLCollection<Solution_mst>();
        string filterid = drpfilter.SelectedValue;
        col = ObjSolution.Get_All_By_Filterid(filterid);





        PagedDataSource pgitems = new PagedDataSource();

        pgitems.DataSource = col;
        pgitems.AllowPaging = true;
        pgitems.PageSize = 5;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPages.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages.Visible = true;
            rptPages.DataSource = pages;

            rptPages.DataBind();

        }
        else


            rptPages.Visible = false;

        Repeter.DataSource = pgitems;
        Repeter.DataBind();


    }
}
