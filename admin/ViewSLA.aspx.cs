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

public partial class admin_ViewSLA : System.Web.UI.Page
{
    // Coded By - Sumit gupta
    // Coded On - 25 jan 2010
    // Purpose  - View Service Level Aggrement

    // Declare Objects of various classes ,Used later
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    SLA_mst objSla = new SLA_mst();
    BLLCollection<SLA_mst> colSLA = new BLLCollection<SLA_mst>();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    Region_mst objRegion = new Region_mst();
    BLLCollection<Region_mst> colRegion = new BLLCollection<Region_mst>();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropRegion();
            BindGridALL();
            BindDropDown();

            
        }
    }

    protected void BindDropRegion()
    {
        colCustomer = objCustomer.Get_All();
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

    protected void BindDropDown()
    {
        colSite = objSite.Get_All();
        drpSites.DataTextField = "sitename";
        drpSites.DataValueField = "siteid";
        drpSites.DataSource = colSite;
        drpSites.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select---------------";
        item.Value = "0";
        drpSites.Items.Add(item);
        drpSites.SelectedValue = "0";
    }

    protected void BindGrid()
    {
        int varSiteid;
        if (drpSites.SelectedValue!="")
        {
            varSiteid = Convert.ToInt32(drpSites.SelectedValue);
            colSLA = objSla.Get_All_By_Siteid(varSiteid);
            grdvwSla.DataSource = colSLA;
            grdvwSla.DataBind();
        }
        
    }

    protected void grdvwSla_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int siteid = Convert.ToInt32(e.Row.Cells[2].Text);
            objSite = objSite.Get_By_id(siteid);
            e.Row.Cells[2].Text = objSite.Sitename.ToString();
        }
    }

    protected void drpSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        int varSiteid;
        varSiteid = Convert.ToInt32(drpSites.SelectedValue);
        if (varSiteid == 0)
        {
            BindGridALL();
        }
        else 
        {
            BindGrid();
        }
    }

    protected void grdvwSla_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int SLAid;
        SLAid = Convert.ToInt32(grdvwSla.Rows[e.RowIndex].Cells[0].Text);
        objSlaPriority.Delete(SLAid);
        objSla.Delete(SLAid);
        BindGrid();
    }

    protected void grdvwSla_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int slaid = Convert.ToInt32(grdvwSla.Rows[e.NewEditIndex].Cells[0].Text);
        Response.Redirect("~/admin/EditSLADefinition.aspx?" + slaid + " ");
    }

    protected void grdvwSla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwSla.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void lnkAddSLA_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/AddSlaDefinition.aspx");
    }

    protected void BindGridALL()
    {
        colSLA = objSla.Get_All();
        grdvwSla.DataSource = colSLA;
        grdvwSla.DataBind();
    }

    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionid = Convert.ToInt32(drpRegion.SelectedValue);
        if (regionid == 0)
        {
            BindGridALL();
            BindDropDown();
        }
        else
        {
            BindDropDownSiteRegionWise();
            BindGrid();
        }
    }

    protected void BindDropDownSiteRegionWise()
    {
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
     

        int custid = Convert.ToInt32(drpRegion.SelectedValue);
        colSite = objSite.Get_All();
        foreach (Site_mst obj in colSite)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colSite1.Add(obj);

            }
        }
        drpSites.DataTextField = "sitename";
        drpSites.DataValueField = "siteid";
        drpSites.DataSource = colSite1;
        drpSites.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select---------------";
        item.Value = "0";
        drpSites.Items.Add(item);
        drpSites.SelectedValue = "0";
    }
}
