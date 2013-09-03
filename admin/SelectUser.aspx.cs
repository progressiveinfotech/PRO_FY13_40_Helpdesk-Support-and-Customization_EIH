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

public partial class admin_SelectUser : System.Web.UI.Page
{
    
    BLLCollection<UserLogin_mst> col=new BLLCollection<UserLogin_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            col = objUser.Get_By_comandname("");
            grdvwViewUser.DataSource = col;
            grdvwViewUser.DataBind();
            ViewState["commandname"] = "";
        }
    }
    protected void btnMapped_Click(object sender, EventArgs e)
    {
        //lblErrorMsg.Text = "";
        int flag = 0;
        foreach (GridViewRow gv in grdvwViewUser.Rows)
        {
            string gvIDs;
            RadioButton selectonebutton = (RadioButton)gv.FindControl("selectone");
            if (selectonebutton.Checked)
            {
                flag = 1;
                gvIDs = ((Label)gv.FindControl("lblUserID")).Text.ToString();
                userid = Convert.ToInt32(gvIDs);
                objUser = objUser.Get_By_id(userid);
                string username = objUser.Username.ToString();
                Session["username"] = username;
                Session["userid"] = userid;
                Session["flag"] = flag;
                Session["flag2"] = flag;
                break;
           }
       }
        string myScript;
        myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }

    protected void grdvwViewUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwViewUser.PageIndex = e.NewPageIndex;
        BindGrid1();
    }

    public void BindGrid()
    {
        col = objUser.Get_By_comandname("A");
        grdvwViewUser.DataSource = col;
        grdvwViewUser.DataBind();
        ViewState["commandname"] = "a";
    }

    protected void BindGrid1()
    {
        string commandname;
        commandname = ViewState["commandname"].ToString();
        col = objUser.Get_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwViewUser.DataSource = col;
            grdvwViewUser.DataBind();

        }
    }

    protected void grdvwViewUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AlphaPaging"))
        {
            string commandname = e.CommandArgument.ToString();
            ViewState["commandname"] = e.CommandArgument.ToString();
            col = objUser.Get_By_comandname(commandname);
            if (col.Count != 0)
            {
                grdvwViewUser.DataSource = col;
                grdvwViewUser.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("userid");
                dt.Columns.Add("username");
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                grdvwViewUser.DataSource = dt;
                grdvwViewUser.DataBind();
            }
        }
    }

    protected void grdvwViewUser_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TableCell cell = e.Row.Cells[0];
            cell.ColumnSpan = 6;
            for (int i = 65; i <= (65 + 25); i++)
            {
                LinkButton lb = new LinkButton();
                lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";
                lb.CommandArgument = Char.ConvertFromUtf32(i);
                lb.CommandName = "AlphaPaging";
                lb.Font.Size = FontUnit.Large;
                cell.Controls.Add(lb);
            }
        }
    }
}
