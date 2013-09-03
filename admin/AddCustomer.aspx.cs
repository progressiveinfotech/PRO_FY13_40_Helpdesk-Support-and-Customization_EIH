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

public partial class admin_AddCustomer : System.Web.UI.Page
{
    Customer_mst ObjCustomer = new Customer_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    public void BindGrid()
    {
        BLLCollection<Customer_mst> col = new BLLCollection<Customer_mst>();
        col = ObjCustomer.Get_All();
        Customergrdvw.DataSource = col;
        Customergrdvw.DataBind();
        clear();
    }

    protected void Customergrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Customergrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void Customergrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Customergrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Customergrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, email, id, phone, address, person;
        int CustomerId;
        id = Convert.ToString(Customergrdvw.Rows[e.RowIndex].Cells[0].Text);
        name = ((TextBox)Customergrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtCustomername1")).Text;
        address = ((TextBox)Customergrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtaddress1")).Text;
        email = ((TextBox)Customergrdvw.Rows[e.RowIndex].Cells[3].Controls[0].FindControl("txtemail1")).Text;
        phone = ((TextBox)Customergrdvw.Rows[e.RowIndex].Cells[4].Controls[0].FindControl("txtphone1")).Text;
        person = ((TextBox)Customergrdvw.Rows[e.RowIndex].Cells[5].Controls[0].FindControl("txtperson1")).Text;
        CustomerId = Convert.ToInt32(id);
        int count = Convert.ToInt32(ObjCustomer.Get_Customer_By_Custid(name));
        ObjCustomer = ObjCustomer.Get_By_id(CustomerId);
        if (name == "")
        {
            lblerrmsg.Text = "Customer Name should not be Empty";
        }

        else if(count==0)
        {
            ObjCustomer.Customer_name = name;
            ObjCustomer.Address = address;
            ObjCustomer.Emailid = email;
            ObjCustomer.Contact_no = phone;
            ObjCustomer.Contact_person = person;
            ObjCustomer.Update();
            Customergrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate;
        }
        else if (ObjCustomer.Customer_name == name)
        {
            ObjCustomer.Customer_name = name;
            ObjCustomer.Address = address;
            ObjCustomer.Emailid = email;
            ObjCustomer.Contact_no = phone;
            ObjCustomer.Contact_person = person;
            ObjCustomer.Update();
            Customergrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate;
        }
        else
        {
            Customergrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }

    }

    protected void Customergrdvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        //{
        //    int statusid;
        //    Label lblstatusid = (Label)e.Row.FindControl("lblchangetypeid1");
        //    if (lblstatusid != null)
        //    {
        //        statusid = Convert.ToInt32(lblstatusid.Text);
        //        ViewState["statusid"] = lblstatusid.Text;
        //        objct = objct.Get_By_id(statusid);
        //        lblstatusid.Text = objct.Changetypename.ToString();
        //    }
        //}

        //if (e.Row.RowState == (System.Web.UI.WebControls.DataControlRowState.Alternate | System.Web.UI.WebControls.DataControlRowState.Edit))
        //{
        //    DropDownList drpCustomer1 = (DropDownList)e.Row.FindControl("drpCustomer1");
        //    BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
        //    col = objct.Get_All();
        //    drpCustomer1.DataSource = col;
        //    drpCustomer1.DataTextField = "ChangeTypename";
        //    drpCustomer1.DataValueField = "ChangeTypeid";
        //    drpCustomer1.DataBind();
        //    drpCustomer1.SelectedValue = ViewState["statusid"].ToString();
        //}
        //if (e.Row.RowState == DataControlRowState.Edit)
        //{
        //    DropDownList drpCustomer1 = (DropDownList)e.Row.FindControl("drpCustomer1");
        //    BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
        //    col = objct.Get_All();
        //    drpCustomer1.DataSource = col;
        //    drpCustomer1.DataTextField = "ChangeTypename";
        //    drpCustomer1.DataValueField = "ChangeTypeid";
        //    drpCustomer1.DataBind();
        //    drpCustomer1.SelectedValue = ViewState["statusid"].ToString();
        //}
    }


    protected void Customergrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Customerid = 0;
        Customerid = Convert.ToInt32(Customergrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjCustomer.Delete(Customerid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete;
    }
    protected void Customergrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Customergrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }


    protected void btnAdd_click(object sender, EventArgs e)
    {
        string custname=txtCustomername.Text.ToString();
        int count = Convert.ToInt32(ObjCustomer.Get_Customer_By_Custid(custname));
        if (count == 0)
        {
            ObjCustomer.Customer_name = custname;
            ObjCustomer.Address = txtAddress.Text.ToString();
            ObjCustomer.Emailid = txtemail.Text.ToString();
            ObjCustomer.Contact_no = txtphone.Text.ToString();
            ObjCustomer.Contact_person = txtperson.Text.ToString();
            ObjCustomer.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }

    protected void clear()
    {
        txtCustomername.Text = "";
        txtphone.Text = "";
        txtemail.Text = "";
        txtAddress.Text = "";
        txtperson.Text = "";
        lblerrmsg.Text = "";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
}
