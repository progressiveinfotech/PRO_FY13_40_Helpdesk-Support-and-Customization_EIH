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

public partial class admin_AddCabMembers : System.Web.UI.Page
{
    ChangeType_mst objct = new ChangeType_mst();
    Cab_mst ObjCab = new Cab_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDrpcab();
            BindGrid();
        }
    }

    public void BindGrid()
    {
        BLLCollection<Cab_mst> col = new BLLCollection<Cab_mst>();
        col = ObjCab.Get_All();
        Cabgrdvw.DataSource = col;
        Cabgrdvw.DataBind();
    
    }

    protected void Cabgrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Cabgrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void Cabgrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Cabgrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Cabgrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, email, id, phone;
        int CabId;
        id = Convert.ToString(Cabgrdvw.Rows[e.RowIndex].Cells[0].Text);
        DropDownList cabdrp1 = ((DropDownList)Cabgrdvw.Rows[e.RowIndex].Cells[2].FindControl("drpcab1"));
        int changeid = Convert.ToInt32(cabdrp1.SelectedValue);
        name = ((TextBox)Cabgrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtmembername1")).Text;
        email = ((TextBox)Cabgrdvw.Rows[e.RowIndex].Cells[3].Controls[0].FindControl("txtemail1")).Text;
        phone = ((TextBox)Cabgrdvw.Rows[e.RowIndex].Cells[4].Controls[0].FindControl("txtphone1")).Text;
        CabId = Convert.ToInt32(id);

        if (name == "")
        {
            lblerrmsg.Text = "Member Name should not be Empty";
        }
        else
        {
            ObjCab.Cabid=CabId;
            ObjCab.Changetypeid = changeid;
            ObjCab.Emailid = email;
            ObjCab.Membername = name;
            ObjCab.Phone=phone;
            ObjCab.Update();
            Cabgrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate;
        }
    }

    protected void Cabgrdvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        {
            int statusid;
            Label lblstatusid = (Label)e.Row.FindControl("lblchangetypeid1");
            if (lblstatusid != null)
            {
                statusid = Convert.ToInt32(lblstatusid.Text);
                ViewState["statusid"] = lblstatusid.Text;
                objct = objct.Get_By_id(statusid);
                lblstatusid.Text = objct.Changetypename.ToString();
            }
        }

        if (e.Row.RowState == (System.Web.UI.WebControls.DataControlRowState.Alternate | System.Web.UI.WebControls.DataControlRowState.Edit))
        {
            DropDownList drpcab1 = (DropDownList)e.Row.FindControl("drpcab1");
            BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
            col = objct.Get_All();
            drpcab1.DataSource = col;
            drpcab1.DataTextField = "ChangeTypename";
            drpcab1.DataValueField = "ChangeTypeid";
            drpcab1.DataBind();
            drpcab1.SelectedValue = ViewState["statusid"].ToString();
        }
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            DropDownList drpcab1 = (DropDownList)e.Row.FindControl("drpcab1");
            BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
            col = objct.Get_All();
            drpcab1.DataSource = col;
            drpcab1.DataTextField = "ChangeTypename";
            drpcab1.DataValueField = "ChangeTypeid";
            drpcab1.DataBind();
            drpcab1.SelectedValue = ViewState["statusid"].ToString();
        }
    }


    protected void Cabgrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Cabid = 0;
        Cabid = Convert.ToInt32(Cabgrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjCab.Delete(Cabid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete;
    }
    protected void Cabgrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Cabgrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }


    public void BindDrpcab()
    {
        BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
        col = objct.Get_All();
        drpCab.DataTextField = "ChangeTypename";
        drpCab.DataValueField = "ChangeTypeid";
        drpCab.DataSource = col;
        drpCab.DataBind();
        ListItem item = new ListItem();
        item.Text = "---Select Status---";
        item.Value = "0";
        drpCab.Items.Add(item);
        drpCab.SelectedValue = "0";
        lblerrmsg.Text = "";
    }
    protected void btnAdd_click(object sender, EventArgs e)
    {
        string vardate;
        lblerrmsg.Text = "";
        int varstatusid;
        varstatusid = Convert.ToInt32(drpCab.SelectedValue);
        ObjCab.Membername = txtmembername.Text.ToString();
        
        if (varstatusid == 0)
        {
            lblerrmsg.Text = "Select the Status";
        }
        else
        {
            ObjCab.Date = DateTime.Now.ToString();
            ObjCab.Changetypeid = Convert.ToInt32(drpCab.SelectedValue);
            ObjCab.Emailid = txtemail.Text.ToString();
            ObjCab.Membername = txtmembername.Text.ToString();
            ObjCab.Phone = txtphone.Text.ToString();
            ObjCab.Insert();
           
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
            BindGrid();
        }
    }

    protected void clear()
    {
        txtmembername.Text = "";
        txtphone.Text = "";
        txtemail.Text = "";
       
        lblerrmsg.Text = "";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
}
