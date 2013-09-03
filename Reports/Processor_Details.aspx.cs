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

public partial class Reports_Processor_Details : System.Web.UI.Page
{
    int assetid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    string report_path = Server.MapPath("Processor_count.rpt");
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(report_path);
        //    //rd.SetDataSource(report_path);
        //    //rd.SetDatabaseLogon("sa", "rimc@123");
        //    //CrystalReportViewer1.ReportSource = rd;
        //    //CrystalReportViewer1.DataBind();

        //    DataTable dtTable = new DataTable();
        //    dtTable = CreateDataTable();
        //    Asset_mst objAsset = new Asset_mst();
        //    BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();
        //    colAsset = objAsset.Get_All();
        //    foreach (Asset_mst obj in colAsset)
        //    {
        //        DataRow row;
        //        row = dtTable.NewRow();
        //        row["computername"] = Convert.ToString(obj.Computername);
        //        assetid = Convert.ToInt32(obj.Assetid);
        //        Asset_Processor_mst objprocessor = new Asset_Processor_mst();
        //        objprocessor = objprocessor.Get_By_Assetid(assetid);
        //        row["manufacturer"] = Convert.ToString(objprocessor.Manufacturer);
        //        row["processorname"] = Convert.ToString(objprocessor.Processor_name);
        //        row["family"] = Convert.ToString(objprocessor.Family);
        //        row["model"] = Convert.ToString(objprocessor.Model);
        //        row["stepping"] = Convert.ToString(objprocessor.Stepping);
        //        dtTable.Rows.Add(row);
        //    }
        //    rd.SetDataSource(dtTable);
        //    rd.SetDatabaseLogon("sa", "rimc@123");
        //    CrystalReportViewer1.ReportSource = rd;
        //    CrystalReportViewer1.DataBind();


        //}
        
    }

    //protected DataTable CreateDataTable()
    //{
    //    DataTable myDataTable = new DataTable();

    //    DataColumn myDataColumn;

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "computername";
    //    myDataTable.Columns.Add(myDataColumn);

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "manufacturer";
    //    myDataTable.Columns.Add(myDataColumn);

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "processorname";
    //    myDataTable.Columns.Add(myDataColumn);

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "family";
    //    myDataTable.Columns.Add(myDataColumn);

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "model";
    //    myDataTable.Columns.Add(myDataColumn);

    //    myDataColumn = new DataColumn();
    //    myDataColumn.DataType = Type.GetType("System.String");
    //    myDataColumn.ColumnName = "stepping";
    //    myDataTable.Columns.Add(myDataColumn);

    //    return myDataTable;
    //}
}
