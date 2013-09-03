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

/* this page created by Lalit */

public partial class admin_EditHoliday : System.Web.UI.Page
{
    Holiday_mst objholiday = new Holiday_mst();
    Site_mst objsite = new Site_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropCustomer();
            BindDrpSite();
            
        }
    }
   
    protected void grdvwEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwEdit.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";


    }

    public void BindDrpSite()
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid = Convert.ToInt32(drpCustomer.SelectedValue);
        col = objsite.Get_All();
        foreach (Site_mst obj in col)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colSite1.Add(obj);

            }
        }
        drpsite.DataTextField = "SiteName";
        drpsite.DataValueField = "siteid";
        drpsite.DataSource = colSite1;
        drpsite.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select-------------";
        item.Value = "0";
        drpsite.Items.Add(item);
        drpsite.SelectedValue = "0";

    }
    public void BindGrid()
    {
        BLLCollection<Holiday_mst> col = new BLLCollection<Holiday_mst>();
        int varSiteid;
        varSiteid = Convert.ToInt32(drpsite.SelectedValue);
        col = objholiday.Get_Holiday_By_SiteId(varSiteid);
        grdvwEdit.DataSource = col;
        grdvwEdit.DataBind();
    }

    protected void drpsite_SelectedIndexChanged1(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdvwEdit_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int varSiteid;
            varSiteid = Convert.ToInt32(drpsite.SelectedValue);
            objsite = objsite.Get_By_id(varSiteid);
            e.Row.Cells[3].Text = objsite.Sitename;
        }
    }

    protected void grdvwEdit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblerrmsg.Text = "";
        grdvwEdit.EditIndex = e.NewEditIndex;
        BindGrid1();
    }

    public void BindGrid1()
    {
        BLLCollection<Holiday_mst> col = new BLLCollection<Holiday_mst>();
        int varSiteid;
        varSiteid = Convert.ToInt32(drpsite.SelectedValue);
        col = objholiday.Get_Holiday_By_SiteId(varSiteid);
        grdvwEdit.DataSource = col;
        grdvwEdit.DataBind();
    }

    protected void grdvwEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Holiday_mst obj = new Holiday_mst();
        Holiday_mst obj1 = new Holiday_mst();
        string hdate, vardate;
        string hdesc1,id;
        int hid, sid, varholidaydate;
        hdate = ((TextBox)grdvwEdit.Rows[e.RowIndex].Cells[1].Controls[1]).Text;        
        hdesc1 = ((TextBox)grdvwEdit.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        id = Convert.ToString(grdvwEdit.Rows[e.RowIndex].Cells[0].Text);
        hid = Convert.ToInt32(id);
        sid = Convert.ToInt32(drpsite.SelectedValue);
        string[] tempdate =((TextBox)grdvwEdit.Rows[e.RowIndex].Cells[1].Controls[1]).Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[0] + "/" + tempdate[1] + "/" + tempdate[2];
        varholidaydate = obj.Get_By_HolidayDate_Siteid(sid, vardate);
        objholiday = objholiday.Get_Description_By_Holidayid(hid);

        if ((objholiday.Holidaydate == vardate)&&(objholiday.Description!=""))
        {
            objholiday.Holidayid = hid;
            objholiday.Holidaydate = hdate;
            objholiday.Description = hdesc1;
            objholiday.Siteid = sid;
            objholiday.Update();
            grdvwEdit.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if ((varholidaydate == 0) &&( hdate!="") && (hdesc1 != ""))
        {
                objholiday.Holidayid = hid;
                objholiday.Holidaydate = hdate;
                objholiday.Description = hdesc1;
                objholiday.Siteid = sid;
                objholiday.Update();
                grdvwEdit.EditIndex = -1;
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if ((hdate == "") ||(hdesc1 == "" ))
        {
            lblerrmsg.Text = "Holiday Date or Description should not be empty";
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }

    protected void grdvwEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String id;
        int hid;
        id = Convert.ToString(grdvwEdit.Rows[e.RowIndex].Cells[0].Text);
        hid = Convert.ToInt32(id);
        objholiday.Delete(hid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
    }
        
    protected void grdvwEdit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblerrmsg.Text = "";
        grdvwEdit.EditIndex = -1;
        BindGrid1();
    }
    protected void lnkaddholiday_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/AddHoliday.aspx");
    }
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDrpSite();
    }
}

