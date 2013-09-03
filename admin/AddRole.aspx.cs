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

public partial class admin_AddRole : System.Web.UI.Page
{
    RoleInfo_mst RoleObj = new RoleInfo_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValRole.ErrorMessage = Resources.MessageResource.errRoleName;
            BindGrid();
        }
    }

    protected void btnRoleadd_Click(object sender, EventArgs e)
    {
        int rolename;
        rolename = RoleObj.Get_By_RoleName(txtRoleName.Text.ToString());
        if (rolename == 0)
        {
            RoleObj.Rolename = txtRoleName.Text.ToString();
            RoleObj.Description = txtRoleDesc.Text.ToString();
            RoleObj.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errRoleExist;
        }

        Dispose();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    protected void ClearControl()
    {
        txtRoleDesc.Text = "";
        txtRoleName.Text = "";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        BLLCollection<RoleInfo_mst> col = new BLLCollection<RoleInfo_mst>();
        col = RoleObj.Get_All();
        Rolegrdvw.DataSource = col;
        Rolegrdvw.DataBind();
        ClearControl();

    }

    protected void Rolegrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Rolegrdvw.EditIndex = e.NewEditIndex;
        //((TextBox)Regiongrdvw.Rows.[e..Cells[1].Controls[0]).MaxLength  = 50;
        //((TextBox)Regiongrdvw.Rows[e.NewEditIndex].Cells[4].Controls[0]).MaxLength = 50;

        BindGrid();
    }

    protected void Rolegrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Rolegrdvw.EditIndex = -1;

        BindGrid();
    }

    protected void Rolegrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        RoleInfo_mst obj = new RoleInfo_mst();   
        string name, desc, id;
        int RoleId = 0, rid;
        name = ((TextBox)Rolegrdvw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        desc = ((TextBox)Rolegrdvw.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        id = Convert.ToString(Rolegrdvw.Rows[e.RowIndex].Cells[0].Text);
        RoleId = Convert.ToInt32(id);
        rid = obj.Get_Role_By_Roleid(name);
        RoleObj = RoleObj.Get_By_id(RoleId);

        if ((rid == 0)&&(name !=""))
        {
            RoleObj.Roleid = RoleId;
            RoleObj.Rolename = name;
            RoleObj.Description = desc;
            RoleObj.Update();
            Rolegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if(RoleObj.Rolename==name)
        {
            RoleObj.Roleid = RoleId;
            RoleObj.Rolename = name;
            RoleObj.Description = desc;
            RoleObj.Update();
            Rolegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if(name == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }

    }

    protected void Rolegrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int RoleId = 0;
        RoleId = Convert.ToInt32(Rolegrdvw.Rows[e.RowIndex].Cells[0].Text);
        RoleObj.Delete(RoleId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void Rolegrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Rolegrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
