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
using System.Data.SqlClient;

public partial class admin_AddOrganization : System.Web.UI.Page
{
    Organization_mst orgobj = new Organization_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        ///lblUser.Text = Session["User"].ToString();
        if (!IsPostBack)
        {
            reqValOrg.ErrorMessage = Resources.MessageResource.errorgname.ToString();
            BindGrid();  
        }
    }

    protected void btnorgadd_Click(object sender, EventArgs e)
    {
        orgobj = orgobj.Get_Organization();
        if (orgobj.Orgid == 0)
        {
            orgobj.Orgname = txtorgname.Text.Trim();
            orgobj.Description = txtorgdesc.Text.Trim();
            orgobj.Createdatetime = DateTime.Now.ToString();
            orgobj.Insert();
            BindGrid();
            lblErrorMsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else 
        {
            lblErrorMsg.Text = Resources.MessageResource.errAddOrg.ToString();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearControl();
    }

    public void clearControl()
    {
        lblErrorMsg.Text = "";
        txtorgname.Text = " ";
        txtorgdesc.Text = " ";
    }

    protected void Orggrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Orggrdvw.EditIndex = e.NewEditIndex;
        BindGrid();  
    }
    protected void Orggrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Orggrdvw.EditIndex = -1;
        BindGrid();  
    }
    protected void Orggrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
          Organization_mst orgobj = new Organization_mst();
          string name,desc,id;
          int orgid = 0;
          name = ((TextBox)Orggrdvw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
          desc = ((TextBox)Orggrdvw.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
          id = Convert.ToString(Orggrdvw.Rows[e.RowIndex].Cells[0].Text);
          if (name != "")
          {
              orgid = Convert.ToInt32(id);
              orgobj.Orgid = orgid;
              orgobj.Orgname = name;
              orgobj.Description = desc;
              orgobj.Update();
              Orggrdvw.EditIndex = -1;
              BindGrid();
              lblErrorMsg.Text = Resources.MessageResource.errupdate.ToString();
          }
          else
          {
              lblErrorMsg.Text = "Organization Name should not be empty";
          }
    }

    protected void Orggrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orgid=0;
        Organization_mst orgobj = new Organization_mst();
        orgid = Convert.ToInt32(Orggrdvw.Rows[e.RowIndex].Cells[0].Text);
        orgobj.Delete(orgid);
        BindGrid();
        lblErrorMsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    public void BindGrid()
    {
        BLLCollection<Organization_mst> col = new BLLCollection<Organization_mst>();
        Organization_mst orgobj = new Organization_mst();
        col = orgobj.Get_All();
        Orggrdvw.DataSource = col;
        Orggrdvw.DataBind();
        clearControl();
    }
    protected void Orggrdvw_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void Orggrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        Orggrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
        
    }

}
