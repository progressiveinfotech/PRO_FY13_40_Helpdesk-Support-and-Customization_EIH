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
using System.IO;
using System.Xml;

public partial class Asset_Add_Network_Inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lbluser = new Label();
        //lbluser = (Label)Master.FindControl("lblUserIdentity");
        //lbluser.Text = "Sign in as : " + User.Identity.Name.ToString();


    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtinv.Text != "")
            {

                DirectoryInfo di = new DirectoryInfo("C://Asset//NetworkData");
                FileInfo[] fi = di.GetFiles();
                bool statusFile;
                statusFile = false;
                int countfile = fi.GetLength(0);
                //int i = 0;
                //filenames = new string[countfile];
                string currentfilename;
                string txtcurrentfilename;
                txtcurrentfilename = txtinv.Text + ".";
                foreach (FileInfo K in fi)
                {
                    string[] fname = K.Name.Split(new char[] { 'x' });
                    currentfilename = fname[0].ToString();
                    if (currentfilename.Trim() == txtcurrentfilename.Trim())
                    {
                        statusFile = true;
                    }


                }

                if (!statusFile)
                {



                    XmlDocument xd = new XmlDocument();
                    XmlDeclaration xdec = xd.CreateXmlDeclaration("1.0", "utf-8", null);
                    xd.InsertBefore(xdec, xd.DocumentElement);

                    XmlElement xeroot = xd.CreateElement("Devices");
                    xd.AppendChild(xeroot);
                    string tempfilename;
                    tempfilename = txtinv.Text + ".xml";
                    xd.Save("c://Asset//NetworkData//" + tempfilename);




                    //Create the XmlDocument.
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(("<Device><Created_on>" + txtInvntDate.Text + "</Created_on> <Computer_name>" + txtdeviceName.Text + "</Computer_name><System> <Description>" + txtDesc.Text + "</Description><Up_time>" + txtuptime.Text + "</Up_time><Platform_ID>" + txtPlatform.Text + " </Platform_ID><Contact>" + txtContact.Text + "</Contact><Location>" + txtLocation.Text + "</Location></System><Ip_addresses><Ip_address><Ip_address>" + txtinv.Text + "</Ip_address></Ip_address></Ip_addresses></Device>"));
                    //Save the document to a file.
                    doc.Save("c://Asset//NetworkData//" + tempfilename);


                    txtinv.Text = "";
                    txtInvntDate.Text = "";
                    txtdeviceName.Text = "";
                    txtDesc.Text = "";
                    txtuptime.Text = "";
                    txtPlatform.Text = "";
                    txtContact.Text = "";
                    txtLocation.Text = "";
                }
                else
                {
                    string myScript;
                    myScript = "<script language=javascript>alert('Following IP Address already Exist,Enter different IP Address'); </script>";
                    Page.RegisterClientScriptBlock("MyScript", myScript);

                }


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
}
