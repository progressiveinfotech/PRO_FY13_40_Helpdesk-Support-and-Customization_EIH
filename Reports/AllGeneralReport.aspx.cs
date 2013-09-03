using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;


public partial class Reports_AllGeneralReport : System.Web.UI.Page
{
    public int count = 1;
    //CommonUtility common_utility = new CommonUtility();
    //DataUtility data_utility = new DataUtility();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        //try
        //{
        //    //All_Info_Placeholder.Controls.Clear();
        //    //Table tbl = new Table();

        //    //All_Info_Placeholder.Controls.Add(tbl);


        //    string report_query = "select distinct os.domain_workgroup, os.computer_name ,os.os_name,os.user_name,os.reg_to,os.reg_org,os.product_key,m.physical_mem,m.virtual_mem,m.page_file,pd.product_name,pd.product_manufacturer,pd.serial_number,p.processor_name from operating_system as os inner join  memory as m on os.computer_name=m.computer_name and os.domain_workgroup=m.domain_workgroup and os.inventory_date=m.inventory_date inner join product_info as pd on os.computer_name=pd.computer_name and os.domain_workgroup=pd.domain_workgroup and os.inventory_date=pd.inventory_date inner join processors as p on os.computer_name=p.computer_name and os.domain_workgroup=p.domain_workgroup and os.inventory_date=p.inventory_date  where os.inventory_date in( select max(inventory_date) from operating_system group by computer_name) order by os.computer_name";
        //    DataSet ds = data_utility.GetDataSet(report_query);
        //    dtgrid.DataSource = ds;
        //    dtgrid.DataBind();
        //}
        //catch (Exception ex)
        //{ 
        
        //}
    }

    protected void dtgrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label lbl = new Label();
            lbl = (Label)e.Item.FindControl("lblsrno");
            lbl.Text = (string)count.ToString();
            count = count + 1;

        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=AllSystemInfo.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        dtgrid.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //count = 1;
        //string datestr = TextBox1.Text.Trim();
        //string vardate;
        //string[] tempdate = datestr.ToString().Split(("/").ToCharArray());
        //vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        //string report_query = "select distinct os.domain_workgroup, os.computer_name ,os.os_name,os.user_name,os.reg_to,os.reg_org,os.product_key,m.physical_mem,m.virtual_mem,m.page_file,pd.product_name,pd.product_manufacturer,pd.serial_number,p.processor_name from operating_system as os inner join  memory as m on os.computer_name=m.computer_name and os.domain_workgroup=m.domain_workgroup and os.inventory_date=m.inventory_date inner join product_info as pd on os.computer_name=pd.computer_name and os.domain_workgroup=pd.domain_workgroup and os.inventory_date=pd.inventory_date inner join processors as p on os.computer_name=p.computer_name and os.domain_workgroup=p.domain_workgroup and os.inventory_date=p.inventory_date  where os.inventory_date in( ( select * from fn_returndate('" + vardate.Trim() + "'))) order by os.computer_name";
        //DataSet ds = data_utility.GetDataSet(report_query);
        //dtgrid.DataSource = ds;
        //dtgrid.DataBind();
    }
}
