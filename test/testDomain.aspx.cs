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
using System.Collections.Generic;
using System.DirectoryServices;


public partial class test_testDomain : System.Web.UI.Page
{
    IList<String> userList = new List<String>();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnClick_Click(object sender, EventArgs e)
    {

                    DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}", "Progressive.com"));
                    DirectorySearcher mySearcher = new DirectorySearcher(myDirectoryEntry);
                    
                    mySearcher.Filter = ("(objectCategory=person)");

                    foreach (SearchResult result in mySearcher.FindAll())
                    {
                       
                        try
                        {
                            if (!String.IsNullOrEmpty(result.Properties["Mail"][0].ToString())
                                && System.Text.RegularExpressions.Regex.IsMatch(result.Properties["DisplayName"][0].ToString(), " |admin|test|service|system|[$]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                                )
                                {
                                    //int space = resEnt.Properties["DisplayName"][0].ToString().IndexOf(" ");
                                    //string formattedName = String.Format("{0}{1}{2}",
                                    //    resEnt.Properties["DisplayName"][0].ToString().Substring(space).PadRight(25),
                                    //    resEnt.Properties["DisplayName"][0].ToString().Substring(0, space).PadRight(15),
                                    //    resEnt.Properties["Mail"][0].ToString()
                                    //    );
                                    //userList.Add(formattedName);
                                    string SAMAccountName = Convert.ToBoolean(result.Properties["sAMAccountName"].Count > 0) ? result.Properties["sAMAccountName"][0].ToString() : "";
                                    string DisplayName = Convert.ToBoolean(result.Properties["displayName"].Count > 0) ? result.Properties["displayName"][0].ToString() : "";
                                    string mail = Convert.ToBoolean(result.Properties["mail"].Count > 0) ? result.Properties["mail"][0].ToString() : "";
                                    string company = Convert.ToBoolean(result.Properties["company"].Count > 0) ? result.Properties["company"][0].ToString() : "";
                                    string department = Convert.ToBoolean(result.Properties["UserFlags"].Count > 0) ? result.Properties["UserFlags"][0].ToString() : "";
                                    Response.Write(SAMAccountName);
                                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                                    Response.Write(DisplayName);
                                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                                    Response.Write(mail);
                                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                                    Response.Write(company);
                                    Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                                    Response.Write(department);
                                    Response.Write("<br>");
                                }
 
                        }
                        catch
                        {
                           
                        }
                       
                    }
                    //if (userList.Count > 0)
                    //{

                    //    for (int i = 0; i < userList.Count - 1; i++)
                    //    {
                    //        Response.Write((userList[i].ToString()));
                    //        Response.Write("<br>");

                    //    }
                       
                        
                    //}
                    
       }
                



    }

