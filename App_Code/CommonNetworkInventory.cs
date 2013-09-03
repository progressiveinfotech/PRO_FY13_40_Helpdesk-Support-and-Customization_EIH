using System;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.XPath;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CommonNetworkInventory
/// </summary>
public class CommonNetworkInventory : System.Web.UI.Page
{

    /* General Device Information */
    public string computer_name;
    public string description;
    public string inventory_date;

    public string contact;
    public string location;
    public string platform_id;
    public string up_time;


    public void Load_Data(string node_name)
    {
        ////////////////////////////////////////////////////
        //XmlDocument xmldoc = new XmlDocument();
        //string nodename = node_name;


        //string path = "C:\\Asset\\NetworkData\\" + nodename + "xmd";
        //xmldoc.Load(path);

        //General_Info(xmldoc);

        ///////////////////////////////////////////////
        //XmlDocument xmldoc = new XmlDocument();
        //string path =Server.MapPath("..//Files//Network.xml");
        //String filestr1 = File.ReadAllText(path);
        //xmldoc.LoadXml(filestr1);
        //General_Info(xmldoc);
        //////////////////////////////////////////////////////////        
        DirectoryInfo di = new DirectoryInfo("C://Asset//NetworkData");
        FileInfo[] fi = di.GetFiles();


        foreach (FileInfo K in fi)
        {
            string filename = node_name;
            if (filename.Contains("xmd") || filename.Contains("xmu") || filename.Contains("xml"))
            {
                string path = "C:\\Asset\\NetworkData\\" + filename;
                XmlDocument xmldoc = new XmlDocument();
                String filestr = File.ReadAllText(path);
                xmldoc.LoadXml(filestr);
                General_Info(xmldoc);
                return;
            }
            else
            {
                if (K.ToString().Contains(filename))
                {
                    if (K.ToString().Contains("xmd"))

                    //if (filename == "C:\\Asset\\NetworkData\\" + filename + "xmd")
                    {
                        string path1 = "C:\\Asset\\NetworkData\\" + filename + ".xmd";
                        XmlDocument xmldoc = new XmlDocument();
                        String filestr = File.ReadAllText(path1);
                        xmldoc.LoadXml(filestr);
                        General_Info(xmldoc);
                        return;
                    }
                    else if (K.ToString().Contains("xmu"))
                    {
                        string path = "C:\\Asset\\NetworkData\\" + filename + ".xmu";
                        XmlDocument xmldoc = new XmlDocument();
                        String filestr = File.ReadAllText(path);
                        xmldoc.LoadXml(filestr);
                        General_Info(xmldoc);
                        return;
                    }
                    else if (K.ToString().Contains("xml"))
                    {
                        string path = "C:\\Asset\\NetworkData\\" + filename + ".xml";
                        XmlDocument xmldoc = new XmlDocument();
                        String filestr = File.ReadAllText(path);
                        xmldoc.LoadXml(filestr);
                        General_Info(xmldoc);
                        return;
                    }
                }

            }

        }
    }

    public void General_Info(XmlDocument xmldoc)
    {
        XmlNode node_computer_name = xmldoc.DocumentElement.SelectSingleNode("//Device//Computer_name");
        XmlNode node_inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Device//Created_on");
        XmlNode node_description = xmldoc.DocumentElement.SelectSingleNode("//Device//System//Description");
        XmlNode node_contact = xmldoc.DocumentElement.SelectSingleNode("//Device//System//Contact");
        XmlNode node_location = xmldoc.DocumentElement.SelectSingleNode("//Device//System//Location");
        XmlNode node_platform_id = xmldoc.DocumentElement.SelectSingleNode("//Device//System//Platform_ID");
        XmlNode node_up_time = xmldoc.DocumentElement.SelectSingleNode("//Device//System//Up_time");

        computer_name = node_computer_name.InnerText;
        inventory_date = node_inventory_date.InnerText;
        description = node_description.InnerText;
        contact = node_contact.InnerText;
        location = node_location.InnerText;
        platform_id = node_platform_id.InnerText;
        up_time = node_up_time.InnerText;

    }





}



