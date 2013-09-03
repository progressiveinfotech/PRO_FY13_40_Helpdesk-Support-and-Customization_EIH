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
using System.Drawing;


public partial class admin_ViewUser : System.Web.UI.Page
{
    UserLogin_mst ObjUserlogin = new UserLogin_mst();
    ContactInfo_mst Objcontactinfo = new ContactInfo_mst();
    BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
        }
    }
    
    public void BindGrid()
    {

        col = ObjUserlogin.Get_By_comandname("A");
        grdvwUser.DataSource = col;
        grdvwUser.DataBind();
        ViewState["commandname"] = "a";

    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        // On Click Back Button redirect to page AddSite.aspx
        Response.Redirect("~/admin/AddUser.aspx");
    }
    protected void grdvwUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Hndling GridView RowDeleting Event for deleting Row for selected UserId
        int userid;
        userid = Convert.ToInt32(grdvwUser.Rows[e.RowIndex].Cells[0].Text);
        UserLogin_mst obj = new UserLogin_mst();
        obj = ObjUserlogin.Get_By_id(userid);
        if (obj.Userid !=0)
        {
            Membership.DeleteUser(obj.Username , true);
        }
       
        Objcontactinfo.Delete(userid);
        ObjUserlogin.Delete(userid);
        
        // Bind GridView
        BindGrid();


    }
    protected void grdvwUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Hndling GridView PageIndex Change Event for Paging  
        grdvwUser.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here
        BindGrid1();

    }
    protected void grdvwUser_RowEditing(object sender, GridViewEditEventArgs e)
   {
        // Hndling GridView RowEditing  Event , Redirect to EditUser.aspx page for particular useridid 
      int userid = Convert.ToInt32(grdvwUser.Rows[e.NewEditIndex].Cells[0].Text);
       Response.Redirect("~/admin/EditUser.aspx?" + userid + " ");


    }

    protected void grdvwUser_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer )
        {

            TableCell cell = e.Row.Cells[0];

            cell.ColumnSpan = 6;
            
            for (int i = 65; i <= (65 + 25); i++)
            {

                LinkButton lb = new LinkButton();
                
                lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";

                lb.CommandArgument = Char.ConvertFromUtf32(i);

                lb.CommandName = "AlphaPaging";
                //lb.BorderWidth = 3;
                //lb.Font.Bold = true;
                lb.Font.Size = FontUnit.Large;
                //lb.BorderStyle = BorderStyle.Ridge;
                lb.ForeColor = Color.Gray;
                cell.Controls.Add(lb);

            }

        }
       
        

    }
    protected void grdvwUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        

        if (e.CommandName.Equals("AlphaPaging"))
        {
            string commandname = e.CommandArgument.ToString();
            ViewState["commandname"] = e.CommandArgument.ToString();
            col = ObjUserlogin.Get_By_comandname(commandname);
            if (col.Count!=0)
            {
                grdvwUser.DataSource = col;
                grdvwUser.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("userid");
                dt.Columns.Add("username");
                dt.Columns.Add("Enable");
                dt.Columns.Add("createdatetime");

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grdvwUser.DataSource = dt;
                grdvwUser.DataBind();

               grdvwUser.Rows[0].Cells[4].Visible = false;
               grdvwUser.Rows[0].Cells[5].Visible = false;


            }
            
          
        }

    }

    protected void BindGrid1()
    {
        string commandname;
        commandname = ViewState["commandname"].ToString(); 
        col = ObjUserlogin.Get_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwUser.DataSource = col;
            grdvwUser.DataBind();
        }
    
    }

    protected void btnsearch_Click(object sender, EventArgs e )
    {

        /* Modify by Lalit */
        string name;

        if (txtname.Text == "")
        {
            col = ObjUserlogin.Get_By_comandname("A");
            grdvwUser.DataSource = col;
            grdvwUser.DataBind();
            ViewState["commandname"] = "a";
        }
        else
        {
            name = txtname.Text.ToString();
            col = ObjUserlogin.Get_By_comandname(name);
            grdvwUser.DataSource = col;
            grdvwUser.DataBind();
            ViewState["commandname"] = name;
        }

        
    }
}
