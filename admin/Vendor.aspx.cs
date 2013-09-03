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

public partial class admin_Vendor : System.Web.UI.Page
{
    Vendor_mst ObjVendor = new Vendor_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValVendor.ErrorMessage = Resources.MessageResource.errVendorname.ToString();
            BindGrid();
        }
    }

    protected void btnVendoradd_Click(object sender, EventArgs e)
    {
        int count_vendor;
        count_vendor = ObjVendor.Get_Vendor_By_Vname(txtvendorname.Text.ToString());
        if (count_vendor == 0)
        {
            ObjVendor.Vendorname = txtvendorname.Text;
            ObjVendor.Contactperson = txtcontactperson.Text;
            ObjVendor.Insert();
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
        BLLCollection<Vendor_mst> col = new BLLCollection<Vendor_mst>();
        col = ObjVendor.Get_All();
        Vendorgrdw.DataSource = col;
        Vendorgrdw.DataBind();
        ClearControl();
    }

    protected void Vendorgrdw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Vendorgrdw.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void Vendorgrdw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Vendorgrdw.EditIndex = -1;
        BindGrid();
    }

    protected void Vendorgrdw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Vendor_mst Obj = new Vendor_mst();
        string vendorname, contactperson, id;
        int vendorid = 0, count;
        vendorname = ((TextBox)Vendorgrdw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        contactperson = ((TextBox)Vendorgrdw.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        id = Convert.ToString(Vendorgrdw.Rows[e.RowIndex].Cells[0].Text);
        vendorid = Convert.ToInt32(id);
        count = Obj.Get_Vendor_By_Vname(vendorname);
        ObjVendor = ObjVendor.Get_By_id(vendorid);

        if ((count == 0) && (vendorname != ""))
        {
            ObjVendor.Vendorid = vendorid;
            ObjVendor.Contactperson = contactperson;
            ObjVendor.Vendorname = vendorname;
            ObjVendor.Update();
            Vendorgrdw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (ObjVendor.Vendorname == vendorname)
        {
            ObjVendor.Vendorid = vendorid;
            ObjVendor.Contactperson = contactperson;
            ObjVendor.Vendorname = vendorname;
            ObjVendor.Update();
            Vendorgrdw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (vendorname == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errVendorname.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }

    protected void Vendorgrdw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int vendorid= 0;
        vendorid = Convert.ToInt32(Vendorgrdw.Rows[e.RowIndex].Cells[0].Text);
        ObjVendor.Delete(vendorid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void ClearControl()
    {
        txtcontactperson.Text = "";
        txtvendorname.Text = "";
        lblerrmsg.Text = "";
    }

    protected void Vendrogrdw_Pageindexchanging(object sender, GridViewPageEventArgs e)
    {
        Vendorgrdw.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Vendorgrdw_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void Vendorgrdw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Vendorgrdw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}