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

public partial class admin_ViewSite : System.Web.UI.Page
{
    // Coded By - Sumit Gupta
    // Coded On - 19 Jan 2010
    // Purpose  - Show All Sites in Grid View

    // Create Objects of Various Classes and used later
    Site_mst objSite = new Site_mst();
    Region_mst objRegion = new Region_mst();
    BLLCollection<Region_mst> colRegion=new BLLCollection<Region_mst>();
    BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
    Customer_mst objCust = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownRegion();
            BindGrid();
        }
    }

    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        // On Click Back Button redirect to page AddSite.aspx
        Response.Redirect("~/admin/AddSite.aspx");
    }

    protected void BindDropDownRegion()
    {
        colCustomer = objCust.Get_All();
        drpRegion.DataTextField = "Customer_Name";
        drpRegion.DataValueField = "custid";
        drpRegion.DataSource = colCustomer;
        drpRegion.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select------------";
        item.Value = "0";
        drpRegion.Items.Add(item);
        drpRegion.SelectedValue = "0";
    }

    public void BindGrid()
    {
        // Declare collection col as Site_mst to get all Sites from database
       
        // By Calling Function objSite.Get_All() assign to col object
        col = objSite.Get_All();
        // Bind GridView by using Datasource and Databind Properties
       
        grdvwSite.DataSource = col;
        grdvwSite.DataBind();
    }

    public void BindGridRegion()
    {
        int custid = Convert.ToInt32(drpRegion.SelectedValue);
        // Declare collection col as Site_mst to get all Sites from database       
        // By Calling Function objSite.Get_All() assign to col object
        col = objSite.Get_All();

        // Bind GridView by using Datasource and Databind Properties

        BLLCollection<Site_mst> col1 = new BLLCollection<Site_mst>();
        foreach (Site_mst obj in col)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                col1.Add(obj);
     
            }
        }
        grdvwSite.DataSource = col1;
        grdvwSite.DataBind();
    }

    protected void grdvwSite_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Hndling GridView RowDeleting Event for deleting Row for selected SiteId
        int siteid;
        siteid = Convert.ToInt32(grdvwSite.Rows[e.RowIndex].Cells[0].Text);
        objSite.Delete(siteid);
        // Bind GridView
        BindGrid();
    }

    protected void grdvwSite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Hndling GridView PageIndex Change Event for Paging  
        grdvwSite.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here
        BindGrid();
    }

    protected void grdvwSite_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Hndling GridView RowDataBound  Event for Binding regionid to region name  
            int regionid = Convert.ToInt32(e.Row.Cells[2].Text);
            // Calling function objRegion.Get_By_id() to get region name via region id
            objRegion = objRegion.Get_By_id(regionid);
            // Assign region name to particular cell of Grid
            e.Row.Cells[2].Text = objRegion.Regionname.ToString();
        }
    }

    protected void grdvwSite_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Hndling GridView RowEditing  Event , Redirect to EditSite.aspx page for particular siteid 
        int siteid = Convert.ToInt32(grdvwSite.Rows[e.NewEditIndex].Cells[0].Text);
        Response.Redirect("~/admin/EditSite.aspx?" + siteid + " ");
    }

    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionid = Convert.ToInt32(drpRegion.SelectedValue);
        if (regionid==0)
        { 
            BindGrid(); 
        }
        else
        {
            BindGridRegion();
        }
    }
}
