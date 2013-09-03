using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;
using System.Xml;

public partial class Asset_Network_Discovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnScan_Click(object sender, EventArgs e)
    {
        try
        {
            string switches = " /inventory /startaddress:" + txt_range_from.Text + " /endaddress:" + txt_range_to.Text + " /computers:no /devices:yes /community:" + txt_community.Text;
            ProcessStartInfo info = new ProcessStartInfo(Server.MapPath("~/binaries/Admin.exe"), switches);
            Process pro = new Process();
            pro.StartInfo = info;
            pro.Start();
            pro.WaitForExit();
           // lbl_status.Text = "Scanning completed...";
            txt_community.Text = "";
            txt_range_from.Text = "";
            txt_range_to.Text = "";
            string myScript;
            myScript = "<script language=javascript>alert('Scanning completed successfully...');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
          //  return;

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

   

}
