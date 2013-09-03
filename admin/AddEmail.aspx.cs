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

public partial class admin_AddEmail : System.Web.UI.Page
{
    EscalateEmail_mst objemail = new EscalateEmail_mst();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    #endregion

    #region Add New Emailid
    protected void btnEmailadd_Click(object sender, EventArgs e)
    {
        int emailid;
        emailid = objemail.Check_Emailid(txtEmailid.Text.ToString());
        if (emailid == 0)
        {
            objemail.Email=txtEmailid.Text.ToString();
            objemail.Insert();
            BindGrid();
            lblerrmsg.Text=Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text=Resources.MessageResource.erralready.ToString();
        }
    }
    #endregion

    #region Bind the Grid
    public void BindGrid()
    {
        BLLCollection<EscalateEmail_mst> col = new BLLCollection<EscalateEmail_mst>();
        col = objemail.Get_All();
        Emailgrdvw.DataSource = col;
        Emailgrdvw.DataBind();
        resetcontrols();
    }
    #endregion

    #region Clear Controls
    protected void resetcontrols()
    {
        lblerrmsg.Text = "";
        txtEmailid.Text = "";
    }
    #endregion

    #region Grid Row Edit
    protected void Emailgrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        resetcontrols();
        Emailgrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    #endregion

    #region Cencel Editing
    protected void Emailgrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Emailgrdvw.EditIndex = -1;
        BindGrid();
    }
    #endregion

    #region Update Grid Row
    protected void Emailgrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        resetcontrols();
        int emailid, count;
        string email, id;
        id = Convert.ToString(Emailgrdvw.Rows[e.RowIndex].Cells[0].Text);
        email = ((TextBox)Emailgrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtEmail")).Text;
        emailid = Convert.ToInt32(id);
        objemail = objemail.Get_By_id(emailid);
        count=objemail.Check_Emailid(email);
        if (objemail.Email == email)
        {
            objemail.Email = email;
            objemail.Update();
            Emailgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (email == "")
        {
            lblerrmsg.Text = "Email should not be empty";
        }
        else if ((count == 0) && (email != ""))
        {
            objemail.Email = email;
            objemail.Update();
            Emailgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else
        {
            Emailgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }
    #endregion

    #region Delete row from Grid
    protected void Emailgrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id=0;
        id = Convert.ToInt32(Emailgrdvw.Rows[e.RowIndex].Cells[0].Text);
        objemail.Delete(id);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }
    #endregion

    #region Change Page Indexing in Grid
    protected void Emailgrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Emailgrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    #endregion

    #region Reset All Control
    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetcontrols();
    }
    #endregion
}
