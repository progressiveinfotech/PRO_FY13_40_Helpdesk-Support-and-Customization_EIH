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

public partial class admin_Addholiday : System.Web.UI.Page
{
    // Declare col as Collection of Site_mst Object to get all records from table 
    BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
    Site_mst ObjSite = new Site_mst();
    Holiday_mst ObjHoliday = new Holiday_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblerrmsg.Text = "";
        if (!IsPostBack)
        {
            BindDropCustomer();
            BindDrpsite();
        }
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

    public void BindDrpsite()
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid = Convert.ToInt32(drpCustomer.SelectedValue);
        col = ObjSite.Get_All();
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
        drpsite.DataValueField = "Siteid";
        drpsite.DataSource = colSite1;
        drpsite.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpsite.Items.Add(item);
        drpsite.SelectedValue = "0";
        lblerrmsg.Text = "";
    }

    protected void btnHolidayadd_Click(object sender, EventArgs e)
    {
        string vardate ;
        lblerrmsg.Text = "";
        int varholidaydate, varsiteid;
        varsiteid = Convert.ToInt32(drpsite.SelectedValue);
        string[] tempdate = txtHolidayDate.Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        varholidaydate = ObjHoliday.Get_By_HolidayDate_Siteid(varsiteid, vardate);
        if ((varholidaydate == 0)&&(varsiteid!=0)&&(txtHolidaydesc.Text!=""))
        {
            ObjHoliday.Holidaydate = vardate;
            ObjHoliday.Siteid = Convert.ToInt32(drpsite.SelectedValue);
            ObjHoliday.Description = txtHolidaydesc.Text.ToString();
            ObjHoliday.Insert();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
            txtHolidaydesc.Text = "";
            txtHolidayDate.Text = "";
        }
        else if (varholidaydate >= 1)
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
        //else if (varsiteid == 0)
        //{
        //    lblerrmsg.Text = "Select the site name";
        //}
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

        txtHolidaydesc.Text = "";
        txtHolidayDate.Text = "";
        lblerrmsg.Text = "";
              
    }
    protected void lnkeditholiday_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/EditHoliday.aspx");
    }
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDrpsite();
    }
}
