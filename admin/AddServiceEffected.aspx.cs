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

public partial class admin_AddServiceEffected : System.Web.UI.Page
{
    Service_mst ObjService = new Service_mst();
    public int servicenamecount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValService.ErrorMessage = Resources.MessageResource.errservice.ToString();
            BindGrid();
        }

    }
    protected void btnServiceAdd_Click(object sender, EventArgs e)
    {
        servicenamecount = ObjService.Get_By_ServiceName(txtServiceName.Text.ToString());
        if (servicenamecount == 0)
        {
            ObjService.Description = txtServiceDesc.Text.ToString();
            ObjService.servicename = txtServiceName.Text.ToString();
            ObjService.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errServiceExist.ToString();
        }
        txtServiceName.Text = "";
        txtServiceDesc.Text = "";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearcontrol();
    }
    protected void Clearcontrol()
    {
        txtServiceName.Text = "";
        txtServiceDesc.Text = "";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        BLLCollection<Service_mst> col = new BLLCollection<Service_mst>();
        col = ObjService.Get_All();
        Servicegrdvw.DataSource = col;
        Servicegrdvw.DataBind();
        Clearcontrol();
    }

    protected void Servicegrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Servicegrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void Servicegrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Servicegrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Servicegrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, desc, id;
        int ServiceId = 0;
        name = ((TextBox)Servicegrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtServiceName")).Text;
        desc = ((TextBox)Servicegrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtServicedesc")).Text;
        id = Convert.ToString(Servicegrdvw.Rows[e.RowIndex].Cells[0].Text);
        ServiceId = Convert.ToInt32(id);
        servicenamecount = ObjService.Get_By_ServiceName(name);
        ObjService = ObjService.Get_By_id(ServiceId);

        if ((servicenamecount == 0) && (name != ""))
        {
            ObjService.Serviceid = ServiceId;
            ObjService.servicename = name;
            ObjService.Description = desc;
            ObjService.Update();
            Servicegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (name == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else if (ObjService.servicename == name)
        {
            ObjService.Serviceid = ServiceId;
            ObjService.servicename = name;
            ObjService.Description = desc;
            ObjService.Update();
            Servicegrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errServiceExist.ToString();
        }
        Servicegrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Servicegrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ServiceId = 0;
        ServiceId = Convert.ToInt32(Servicegrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjService.Delete(ServiceId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void Servicegrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Servicegrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
