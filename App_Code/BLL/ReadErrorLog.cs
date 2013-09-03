using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;

/// <summary>
/// Create On  - 6 Dec 2010
/// Created by - Sumit Gupta
/// Description -ReadErrorLog Class to read particular node of  Xml file ErrorLog.xml on the basis of parameter Msg has 
/// been Passed for showing Error Messages across the Application
/// </summary>
public class ReadErrorLog
{
    public static   string  path;
    public ReadErrorLog()
    { 
    }
	
    public string  ErrorMessage(string Msg)
    {

       
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fs);
            XmlNodeList xmlnode = xmldoc.GetElementsByTagName("Error");
            string xPathExpression = "//ErrorMessages/Error[@ID='" + Msg + "']";
            XmlElement NewNode = (XmlElement)xmldoc.SelectSingleNode(xPathExpression);
            XmlAttributeCollection xmlattrc1 = NewNode.Attributes;
            string message;
            message = NewNode.FirstChild.InnerText;
            return message;
           
       

       
       
    }
    public void GetPath(string varPath)
    {
        path = varPath;
    }
    
   
}
