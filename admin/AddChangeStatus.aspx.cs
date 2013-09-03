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

public partial class admin_AddChangeStatus : System.Web.UI.Page
{
    ChangeStatus_mst ObjStatus = new ChangeStatus_mst();
    public int statusnamecount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValStatus.ErrorMessage = Resources.MessageResource.errstatus.ToString();
            BindGrid();

        }
 }
    protected void btnStatusAdd_Click(object sender, EventArgs e)
    {
        statusnamecount = ObjStatus.Get_By_StatusName(txtStatusName.Text.ToString());
        if (statusnamecount == 0)
        {
            ObjStatus.Description = txtStatusDesc.Text.ToString();
            ObjStatus.Statusname = txtStatusName.Text.ToString();
            ObjStatus.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errStatusExist.ToString();
        }
        txtStatusName.Text = "";
        txtStatusDesc.Text = "";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearcontrol();
    }
    protected void Clearcontrol()
    {
        txtStatusName.Text = "";
        txtStatusDesc.Text = "";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        BLLCollection<ChangeStatus_mst> col = new BLLCollection<ChangeStatus_mst>();
        ChangeStatus_mst ObjStatus2 = new ChangeStatus_mst();

        col = ObjStatus2.Get_All();
        Statusgrdvw.DataSource = col;
        Statusgrdvw.DataBind();
        Clearcontrol();
    }

    protected void Statusgrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Statusgrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void Statusgrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Statusgrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Statusgrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, desc, id;
        int StatusId = 0;
        ChangeStatus_mst ObjStatus1 = new ChangeStatus_mst();
           
            name = ((TextBox)Statusgrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtStatusName")).Text;
            desc = ((TextBox)Statusgrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtStatusdesc")).Text;
            id = Convert.ToString(Statusgrdvw.Rows[e.RowIndex].Cells[0].Text);

            StatusId = Convert.ToInt32(id);

        statusnamecount = ObjStatus1.Get_By_StatusName(name);
        ObjStatus1 = ObjStatus1.Get_By_id(StatusId);

        if ((statusnamecount == 0) && (name != ""))
        {
            ObjStatus1.Statusname = name;
            ObjStatus1.ChangeStatusid = StatusId;
            ObjStatus1.Description = desc;
            ObjStatus1.Update();
            Statusgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (name == "")
        {
            BindGrid();
            lblerrmsg.Text = "Status name should not be empty";
        }
        else if (ObjStatus1.Statusname == name)
        {
            ObjStatus1.ChangeStatusid = StatusId;
            ObjStatus1.Statusname = name;
            ObjStatus1.Description = desc;
            ObjStatus1.Update();
            Statusgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }

        else
        {
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errStatusExist.ToString();
        }
        Statusgrdvw.EditIndex = -1;
    }

    protected void Statusgrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int StatusId = 0;

        StatusId = Convert.ToInt32(Statusgrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjStatus.Delete(StatusId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();

    }
    protected void Statusgrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        Statusgrdvw.PageIndex = e.NewPageIndex;
        BindGrid();

    }
}
