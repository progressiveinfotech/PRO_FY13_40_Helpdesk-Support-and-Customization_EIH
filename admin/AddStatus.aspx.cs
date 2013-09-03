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

public partial class admin_AddStatus : System.Web.UI.Page
{
    Status_mst ObjStatus = new Status_mst();
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
        if (statusnamecount==0)
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
        BLLCollection<Status_mst> col = new BLLCollection<Status_mst>();
        col = ObjStatus.Get_All();
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
        name = ((TextBox)Statusgrdvw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        desc = ((TextBox)Statusgrdvw.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        id = Convert.ToString(Statusgrdvw.Rows[e.RowIndex].Cells[0].Text);
        StatusId = Convert.ToInt32(id);
        statusnamecount = ObjStatus.Get_By_StatusName(name);
        ObjStatus = ObjStatus.Get_By_id(StatusId);

        if ((statusnamecount == 0)&&(name!=""))
       {
           ObjStatus.Statusid = StatusId;
           ObjStatus.Statusname = name;
           ObjStatus.Description = desc;
           ObjStatus.Update();
           Statusgrdvw.EditIndex = -1;
           BindGrid();
           lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
       }
        else if (name == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else if (ObjStatus.Statusname.ToLower() == name.ToLower())
        {
            ObjStatus.Statusid = StatusId;
            ObjStatus.Statusname = name;
            ObjStatus.Description = desc;
            ObjStatus.Update();
            Statusgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }    
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errStatusExist.ToString();
        }
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
