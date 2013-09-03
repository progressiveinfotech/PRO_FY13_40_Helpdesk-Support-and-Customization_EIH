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

public partial class admin_AddMode : System.Web.UI.Page
{
    Mode_mst ObjMode = new Mode_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValMode.ErrorMessage = Resources.MessageResource.errModename.ToString();
            BindGrid();
        }
    }
    protected void btnModeadd_Click(object sender, EventArgs e)
    {
        int modename;
        modename=ObjMode.Get_Mode_By_Mname(txtModename.Text.ToString());
        if (modename == 0)
        {
            ObjMode.Modename = txtModename.Text;
            ObjMode.Description = txtDescription.Text;
            ObjMode.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    public void BindGrid()
    {
        // Declare col as Collection of Region_mst Object to get all records from table 
        BLLCollection<Mode_mst> col = new BLLCollection<Mode_mst>();
        col = ObjMode.Get_All();
        Modegrdw.DataSource = col;
        Modegrdw.DataBind();
        ClearControl();
    }
    protected void Modegrdw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Modegrdw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void Modegrdw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Modegrdw.EditIndex = -1;
        BindGrid();
    }
    protected void Modegrdw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Mode_mst Obj = new Mode_mst();
        string Modename, Description, id;
        int Modeid = 0, count;
        Modename = ((TextBox)Modegrdw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtModeName")).Text;
        Description = ((TextBox)Modegrdw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtDescription")).Text;
        id = Convert.ToString(Modegrdw.Rows[e.RowIndex].Cells[0].Text);
        Modeid = Convert.ToInt32(id);
        count = Obj.Get_Mode_By_Mname(Modename);
        ObjMode = ObjMode.Get_By_id(Modeid);
        if ((count == 0) && (Modename != ""))
        {
            ObjMode.Modeid = Modeid;
            ObjMode.Description = Description;
            ObjMode.Modename = Modename;
            ObjMode.Update();
            Modegrdw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }

        else if (ObjMode.Modename == Modename)
        {
            ObjMode.Modeid = Modeid;
            ObjMode.Description = Description;
            ObjMode.Modename = Modename;
            ObjMode.Update();
            Modegrdw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }

        else if (Modename == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }

        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }

    }

    protected void Modegrdw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Modeid = 0;
        Modeid = Convert.ToInt32(Modegrdw.Rows[e.RowIndex].Cells[0].Text);
        ObjMode.Delete(Modeid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }
    protected void ClearControl()
    {
        txtDescription.Text = "";
        txtModename.Text = "";
        lblerrmsg.Text = "";
    }

    protected void Vendrogrdw_Pageindexchanging(object sender, GridViewPageEventArgs e)
    {
        Modegrdw.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Modegrdw_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Modegrdw_Pageindexchanging(object sender, GridViewPageEventArgs e)
    {
        Modegrdw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
