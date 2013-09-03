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

public partial class admin_AddChangeType : System.Web.UI.Page
{
    ChangeType_mst ObjChangeType = new ChangeType_mst();
    public int changetypecount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValStatus.ErrorMessage = Resources.MessageResource.errstatus.ToString();
            BindGrid();

        }

    }
    protected void btnChangeTypeAdd_Click(object sender, EventArgs e)
    {
        changetypecount = ObjChangeType.Get_By_ChangeTypeName(txtChangeTypeName.Text.ToString());
        if (changetypecount == 0)
        {
            ObjChangeType.Description = txtChangeTypeDesc.Text.ToString();
            ObjChangeType.Changetypename = txtChangeTypeName.Text.ToString();
            ObjChangeType.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();

        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
        txtChangeTypeName.Text = "";
        txtChangeTypeDesc.Text = "";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearcontrol();
    }
    protected void Clearcontrol()
    {
        txtChangeTypeName.Text = "";
        txtChangeTypeDesc.Text = "";
        lblerrmsg.Text = "";

    }

    public void BindGrid()
    {
        BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();

        col = ObjChangeType.Get_All();
        ChangeTypegrdvw.DataSource = col;
        ChangeTypegrdvw.DataBind();
        Clearcontrol();
    }

    protected void ChangeTypegrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ChangeTypegrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void ChangeTypegrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ChangeTypegrdvw.EditIndex = -1;

        BindGrid();
    }

    protected void ChangeTypegrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string name, desc, id;
        int ChangeTypeId = 0;

        name = ((TextBox)ChangeTypegrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtStatusName")).Text;
        desc = ((TextBox)ChangeTypegrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtStatusdesc")).Text;
        id = Convert.ToString(ChangeTypegrdvw.Rows[e.RowIndex].Cells[0].Text);

        ChangeTypeId = Convert.ToInt32(id);

        changetypecount = ObjChangeType.Get_By_ChangeTypeName(name);
        ObjChangeType = ObjChangeType.Get_By_id(ChangeTypeId);

        if ((changetypecount == 0) && (name != ""))
        {
            ObjChangeType.Changetypename = name;
            ObjChangeType.Changetypeid = ChangeTypeId;
            ObjChangeType.Description = desc;
            ObjChangeType.Update();
            ChangeTypegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (name == "")
        {
            lblerrmsg.Text = "Change Type Field should not be empty";
        }
        else if (ObjChangeType.Changetypename == name)
        {
            ObjChangeType.Changetypeid = ChangeTypeId;
            ObjChangeType.Changetypename = name;
            ObjChangeType.Description = desc;
            ObjChangeType.Update();
            ChangeTypegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }

        else
        {
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
        ChangeTypegrdvw.EditIndex = -1;
    }
    protected void ChangeTypegrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int ChangeTypeId = 0;

        ChangeTypeId = Convert.ToInt32(ChangeTypegrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjChangeType.Delete(ChangeTypeId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();


    }
    protected void ChangeTypegrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        ChangeTypegrdvw.PageIndex = e.NewPageIndex;
        BindGrid();

    }
}
