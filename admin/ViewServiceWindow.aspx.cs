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

public partial class admin_ViewServiceWindow : System.Web.UI.Page
{
    BLLCollection<Region_mst> colRegion = new BLLCollection<Region_mst>();
    Region_mst objRegion = new Region_mst();
    BLLCollection<ServiceWindow_mst> colservicewindow = new BLLCollection<ServiceWindow_mst>();
    ServiceWindow_mst objservicewindow = new ServiceWindow_mst();
    Servicehours_mst objservicehrs = new Servicehours_mst();
    ServiceDay_mst objserviceday = new ServiceDay_mst();
    Site_mst objSite = new Site_mst();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    Customer_mst objCust = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddrpRegion();
            BindGridAll();
        }
    }

    protected void BinddrpRegion()
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
        int custid;
        custid = Convert.ToInt32(drpRegion.SelectedValue);
        colservicewindow = objservicewindow.Get_All();
        BLLCollection<ServiceWindow_mst> colservicewindow1 = new BLLCollection<ServiceWindow_mst>();
        foreach (ServiceWindow_mst obj in colservicewindow)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colservicewindow1.Add(obj);
            
            
            }
        
        
        }

        grdvwViewServiceWindow.DataSource = colservicewindow1;
        grdvwViewServiceWindow.DataBind();
    }

    protected void grdvwViewServiceWindow_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int siteid = Convert.ToInt32(e.Row.Cells[1].Text);
            objSite = objSite.Get_By_id(siteid);
            e.Row.Cells[1].Text = objSite.Sitename.ToString();
        }
    }

    public void BindGridAll()
    {
        colservicewindow = objservicewindow.Get_All();
        grdvwViewServiceWindow.DataSource = colservicewindow;
        grdvwViewServiceWindow.DataBind();
    }

    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionid = Convert.ToInt32(drpRegion.SelectedValue);
        if (regionid != 0)
        {
            BindGrid();
        }
        else
        {
            BindGridAll();            
        }        
    }

    protected void grdvwViewServiceWindow_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int servicewinid = Convert.ToInt32(grdvwViewServiceWindow.Rows[e.NewEditIndex].Cells[0].Text); 
        Response.Redirect("~/admin/AddServiceWindow.aspx?" + servicewinid + " ");
    }

    protected void grdvwViewServiceWindow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int servicewindowid;
        servicewindowid = Convert.ToInt32(grdvwViewServiceWindow.Rows[e.RowIndex].Cells[0].Text);        
        objservicehrs.Delete(servicewindowid);
        objserviceday.Delete(servicewindowid);
        objservicewindow.Delete(servicewindowid);
        BindGridAll();
    }
    protected void lnkAddServiceWindow_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/AddServiceWindow.aspx");
    }

  
    protected void grdvwViewServiceWindow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //    // Hndling GridView PageIndex Change Event for Paging  
        grdvwViewServiceWindow.PageIndex = e.NewPageIndex;
        //    // On Selected Page Index Bind Grid here
            BindGrid();
    }
}