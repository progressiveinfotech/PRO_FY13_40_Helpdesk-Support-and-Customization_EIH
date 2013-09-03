using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public partial class Master_MasterAsset : System.Web.UI.MasterPage
{
    Asset_mst objasset = new Asset_mst();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        ////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                MembershipUser User = Membership.GetUser();
                objOrganization = objOrganization.Get_Organization();
                int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
                if (userid != 0)
                {
                    string userName;
                    userName = User.UserName.ToString();
                    if (Roles.IsUserInRole(userName, "admin"))
                    {
                        panel1.Visible = true;
                    }
                    objContact = objContact.Get_By_id(userid);
                    lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;
                    Bind_Tree();

                    //BindRepeater();

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


    //private void BindRepeater()
    //{
    //    string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
    //                 "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
    //                 "W", "X", "Y", "Z","0-9"};


    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("Name");

    //    char c = 'A';

    //    //    while (Strings.Asc(c) <= Strings.Asc("Z"))
    //    for (int i = 0; i < letters.Length; i++)
    //    {
    //        DataRow dr = dt.NewRow();
    //        dr[0] = letters[i];
    //        dt.Rows.Add(dr);

    //    }

    //    this.rptAlfha.DataSource = dt;
    //    this.rptAlfha.DataBind();
    //}





    public void Bind_Tree()
    {
        XmlDataSource ds = new XmlDataSource();
        ds.EnableCaching = false;
        //string path = Server.MapPath("..//Files//Network.xml");
        //ds.DataFile = path;
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("..//Files//Network.xml"));

        DataTable dt1 = ds1.Tables[0];


        dlSecondAplfha.DataSource = dt1;

        dlSecondAplfha.DataBind();
    }
/// <summary>
/// ///////////////////////////////////////////////////change done by meenakshi
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    //protected void dlSecondAplfha_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //int temp = 0;
    //    //string node_name = Treeview1.SelectedNode.Value;
    //    //ViewState["node_name"] = node_name;
    //    //if (node_name != "Computers")
    //    //{
    //    //    temp = 1;
    //    //    Session["temp"] = temp;
    //    //    Session["param_node"] = node_name;
    //    //    Response.Redirect("~/Asset/ViewAssetDetails.aspx");
    //    //}
    //    string device_name = dlSecondAplfha.SelectedValue.ToString();
    //    ViewState["device_name"] = device_name;
    //    string general;


    //    if (device_name != "Devices")
    //    {
    //        Session["param_device"] = device_name;
    //        Response.Redirect(Request.ApplicationPath + "/Asset/NetworkDiscover.aspx");
    //    }
    //}
/// <summary>
/// ///////////////////////////////////////////////////////////////end
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    protected void lnkrefresh_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string[] filenames;
            string[] Networknames;
            filenames = Get_Data_Files();
            Write_Computer_List(filenames);
            Networknames = Get_NetworkData_Files();
            Write_Network_List(Networknames);
           // BindRepeater();
            Bind_Tree();
          //  dlSecondAplfha.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkClick_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //string[] filenames;
            //filenames = Get_Data_Files();
            //Write_Computer_List(filenames);
            //BindRepeater();
            Bind_Tree();
            //dlSecondAplfha.Visible = false;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    public void Write_Computer_List(string[] filenames)
    {
        XmlDocument xd = new XmlDocument();
        XmlDeclaration xdec = xd.CreateXmlDeclaration("1.0", "utf-8", null);
        xd.InsertBefore(xdec, xd.DocumentElement);

        XmlElement xeroot = xd.CreateElement("Computers");
        xd.AppendChild(xeroot);

        foreach (string K in filenames)
        {
            string fname;
            fname = K.ToString();
            //getSerialNo(fname);
            XmlElement xeComputer = xd.CreateElement("Computer");
            xeroot.AppendChild(xeComputer);
            XmlAttribute xa = xd.CreateAttribute("Name");
            xa.Value = K.ToString();
            xeComputer.Attributes.Append(xa);
        }
        xd.Save(Server.MapPath("..//Files//Asset.xml"));


        ////////////  Add by Vishal for Networking 05-06-2012

        //XmlDocument xd1 = new XmlDocument();
        //XmlDeclaration xdec1 = xd1.CreateXmlDeclaration("1.0", "utf-8", null);
        //xd1.InsertBefore(xdec1, xd1.DocumentElement);

        //XmlElement xeroot1 = xd1.CreateElement("Devices");
        //xd1.AppendChild(xeroot1);

        //foreach (string K1 in filenames)
        //{
        //    string fname;
        //    fname = K1.ToString();
        //    //getSerialNo(fname);
        //    XmlElement xeComputer1 = xd1.CreateElement("Devices");
        //    xeroot1.AppendChild(xeComputer1);
        //    XmlAttribute xa1 = xd1.CreateAttribute("Name");
        //    xa1.Value = K1.ToString();
        //    xeComputer1.Attributes.Append(xa1);
        //}

        //xd.Save(Server.MapPath("..//Files//Network.xml"));

    }
    public void Write_Network_List(string[] filenames)
    {
        ////////////  Add by Vishal for Networking 05-06-2012

        XmlDocument xd1 = new XmlDocument();
        XmlDeclaration xdec1 = xd1.CreateXmlDeclaration("1.0", "utf-8", null);
        xd1.InsertBefore(xdec1, xd1.DocumentElement);

        XmlElement xeroot1 = xd1.CreateElement("Devices");
        xd1.AppendChild(xeroot1);

        foreach (string K1 in filenames)
        {
            string fname;
            fname = K1.ToString();
            //getSerialNo(fname);
            XmlElement xeComputer1 = xd1.CreateElement("Devices");
            xeroot1.AppendChild(xeComputer1);
            XmlAttribute xa1 = xd1.CreateAttribute("Name");
            xa1.Value = K1.ToString();
            xeComputer1.Attributes.Append(xa1);
        }

        xd1.Save(Server.MapPath("..//Files//Network.xml"));

    }

    public string[] Get_Data_Files()
    {
        string[] filenames;

        DirectoryInfo di = new DirectoryInfo("C://Asset//Data");

        FileInfo[] fi = di.GetFiles();
        int countfile = fi.GetLength(0);

        int i = 0;
        filenames = new string[countfile];
        foreach (FileInfo K in fi)
        {
            string[] fname = K.Name.Split(new char[] { '.' });
            filenames[i] = fname[0].ToString();
            i++;
        }
        return filenames;
    }


    public string[] Get_NetworkData_Files()
    {
        string[] filenames;

        DirectoryInfo di = new DirectoryInfo("C://Asset//NetworkData");

        FileInfo[] fi = di.GetFiles();
        int countfile = fi.GetLength(0);

        int i = 0;
        filenames = new string[countfile];
        foreach (FileInfo K in fi)
        {
            string fname = K.Name.Replace(".xmd", ""); //K.Name.Split(new char[] { '.' });
            filenames[i] = fname.ToString();
            i++;
        }
        return filenames;
    }

    protected void lnkSaveinventory_Click(object sender, EventArgs e)
    {
        try
        {
            SaveAssetInventory obj = new SaveAssetInventory();
            obj.SaveInventory();
            string myScript;
            myScript = "<script language=javascript>alert('Inventory of Assets has been Saved'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {

            string myScript;
            myScript = "<script language=javascript>alert('Error Occured ,While Saving the Inventory'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
    }

    protected void btnSearchComputer_Click(object sender, ImageClickEventArgs e)
    {
        ////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int count = 0;
            int temp = 0;
            count = objasset.Get_Asset_By_Cname(txtsearchcompname.Text.ToString());
            if (count != 0)
            {
                temp = 1;
                Session["temp"] = temp;
                Session["param_node"] = txtsearchcompname.Text.ToString();
                Response.Redirect("~/Asset/ViewAssetDetails.aspx");
            }
            else
            {
                string myScript;
                myScript = "<script language=javascript>alert('Computer not found!, Ensure that computer is in the Domain and User Login to the Domain.'); </script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
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
    protected void lnkAddAsset_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("~/Asset/AddAsset.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkShowAsset_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("~/Asset/ViewAsset.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkAssetToSiteMapping_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("~/Asset/UserToAssetMapping.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("../Login/Default.aspx");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void rptAlfha_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.CommandName == "AlfhaName")
            {
                string AlfhaCharacter = e.CommandArgument.ToString();

                //XmlDataSource ds = new XmlDataSource();
                //ds.EnableCaching = false;
                //string path = Server.MapPath("..//Files//Asset.xml");
                //ds.DataFile = path;


                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("..//Files//Asset.xml"));

                DataTable dt1 = ds1.Tables[0];

                //copy the schema of source table
                DataTable dtAlfha = dt1.Clone();

                //get only the rows you want
                DataRow[] results;
                if (AlfhaCharacter == "0-9")
                {
                    results = dt1.Select("Name like '0%' or Name like '1%' or Name like '2%' or Name like '3%'  or Name like '4%' or Name like '5%' or Name like '6%' or Name like '7%' or Name like '8%' or Name like '9%'");

                }
                else
                {
                    results = dt1.Select("Name like '" + AlfhaCharacter + "%'");
                }
                //populate new destination table
                foreach (DataRow dr in results)
                    dtAlfha.ImportRow(dr);


                // ds.Data = AlfhaCharacter.StartsWith(AlfhaCharacter);
                if (dtAlfha != null && dtAlfha.Rows.Count > 0)
                {
                    dlSecondAplfha.DataSource = dtAlfha;


                    //if (dlSecondAplfha.Visible == false)
                    //{
                    dlSecondAplfha.DataBind();
                    dlSecondAplfha.Visible = true;
                }
                //Session["param_node"] = "";
                // }
                //    XDocument xmlDoc = XDocument.Load("..//Files//Asset.xml");

                //    var Computer = from Computers in xmlDoc.Descendants("Computers")
                //                  select new
                //                  {
                //                      ComputerName = Computers.Element("Computer Name").Value.StartsWith(AlfhaCharacter),
                //                   };

                //    DataTable dt = new DataTable();
                //    dt.Columns.Add("ComputerName");
                //    foreach (var ComName in Computer)
                //    {

                //            DataRow dr = dt.NewRow();
                //            dr[0] = ComName.ComputerName;
                //            dt.Rows.Add(dr);

                //    }
                //    //DataSet ds = dt.TableName[0];
                //    //Treeview1.DataSource = ds;
                //    //if (Treeview1.Visible == false)
                //    //{
                //    //    Treeview1.DataBind();
                //    //    Treeview1.Visible = true;
                //    //}

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
    protected void dlSecondAplfha_ItemCommand(object source, DataListCommandEventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.CommandName == "AlfhaName")
            {
                string AlfhaCharacter = e.CommandArgument.ToString();

                int temp = 0;
                string node_name = AlfhaCharacter;
                ViewState["node_name"] = node_name;
                if (node_name != "Computers")
                {
                    temp = 1;
                    Session["temp"] = temp;
                    Session["param_node"] = node_name;
                    Response.Redirect("~/Asset/NetworkDiscover.aspx");
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
    protected void lnkAddNetworkDevice_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/Add_Network_Inventory.aspx");
    }
    protected void lnkNetworkScan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/Network_Discovery.aspx");
    }
    protected void lnkRemoveAsset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/RemoveAsset.aspx");
    }
}