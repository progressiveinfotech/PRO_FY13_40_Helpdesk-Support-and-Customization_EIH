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


public partial class Reports_Processor_count : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string report_query = "select a.computerName, p.manufacturer, p.processor_name, p.family, p.model, p.stepping from Asset_Processor as p inner join Asset_mst as a on a.assetId=p.assetId)";
            //string report_path = Server.MapPath("Processor_count.rpt");
            ////DataSet ds = data_utility.GetDataSet(report_query);
            //ReportDocument rd = new ReportDocument();
            //rd.Load(report_path);
            //rd.SetDataSource(report_path);
            //rd.SetDatabaseLogon("sa", "rimc@123");
            ////CrystalReportViewer1.ReportSource = report_path;
            //CrystalReportViewer1.ReportSource = rd;
            //CrystalReportViewer1.DataBind();
        }
        catch (Exception)
        {

            string myScript;
            myScript = "<script language=javascript>alert('Error occurred, while performing the operation'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);

        }
    }
}
