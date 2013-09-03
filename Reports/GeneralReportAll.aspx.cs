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
using System.Text.RegularExpressions;


public partial class Reports_GeneralReportAll : System.Web.UI.Page
{
    public int count = 1;
    int assetid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    public void BindGrid()
    {
        DataTable dtTable = new DataTable();
        dtTable = CreateDataTable();
        Asset_mst objAsset = new Asset_mst();
        BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();
        colAsset = objAsset.Get_All();
        foreach (Asset_mst obj in colAsset)
        {
            DataRow row;
            row = dtTable.NewRow();
            row["computername"] = Convert.ToString(obj.Computername);
            assetid = Convert.ToInt32(obj.Assetid);
            Asset_OperatingSystem_mst objos = new Asset_OperatingSystem_mst();
            objos = objos.Get_By_Assetid(assetid);
            row["osname"] = Convert.ToString(objos.Os_name);
            row["username"] = Convert.ToString(objos.User_name);
            row["productkey"] = Convert.ToString(objos.Product_key);
            Asset_ProductInfo_mst objproduct = new Asset_ProductInfo_mst();
            objproduct = objproduct.Get_By_Assetid(assetid);
            row["productname"] = Convert.ToString(objproduct.Product_name);
            row["productmanu"] = Convert.ToString(objproduct.Product_manufacturer);
            row["serialno"] = Convert.ToString(objproduct.Serial_number);
            Asset_Processor_mst objprocessor = new Asset_Processor_mst();
            objprocessor = objprocessor.Get_By_Assetid(assetid);
            row["processorname"] = Convert.ToString(objprocessor.Processor_name);
            Asset_Memory_mst objmemory = new Asset_Memory_mst();
            objmemory = objmemory.Get_By_Assetid(assetid);
            row["physicalmemory"] = Convert.ToString(objmemory.Physical_mem);
            dtTable.Rows.Add(row);
        }
        dtgrid.DataSource = dtTable;
        dtgrid.DataBind();
    }

    protected DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "computername";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "osname";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "username";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "productkey";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "productname";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "productmanu";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "serialno";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "processorname";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "physicalmemory";
        myDataTable.Columns.Add(myDataColumn);

        return myDataTable;
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
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
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
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //count = 1;
    //string datestr = TextBox1.Text.Trim();
    //string vardate;
    //string[] tempdate = datestr.ToString().Split(("/").ToCharArray());
    //vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
    //string report_query = "select distinct os.domain_workgroup, os.computer_name ,os.os_name,os.user_name,os.reg_to,os.reg_org,os.product_key,m.physical_mem,m.virtual_mem,m.page_file,pd.product_name,pd.product_manufacturer,pd.serial_number,p.processor_name from operating_system as os inner join  memory as m on os.computer_name=m.computer_name and os.domain_workgroup=m.domain_workgroup and os.inventory_date=m.inventory_date inner join product_info as pd on os.computer_name=pd.computer_name and os.domain_workgroup=pd.domain_workgroup and os.inventory_date=pd.inventory_date inner join processors as p on os.computer_name=p.computer_name and os.domain_workgroup=p.domain_workgroup and os.inventory_date=p.inventory_date  where os.inventory_date in( ( select * from fn_returndate('" + vardate.Trim() + "'))) order by os.computer_name";
    //DataSet ds = data_utility.GetDataSet(report_query);
    //dtgrid.DataSource = ds;
    //dtgrid.DataBind();
    //}
}
