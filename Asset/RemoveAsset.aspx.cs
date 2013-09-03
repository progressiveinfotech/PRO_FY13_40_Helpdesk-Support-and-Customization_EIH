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
using System.Data.SqlClient;

public partial class Asset_RemoveAsset : System.Web.UI.Page
{
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
    public string[] filenames;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string xmlfilePath;
            DataSet ds = new DataSet();
            xmlfilePath = Server.MapPath("~/files/Asset.xml");
            ds.ReadXml(xmlfilePath);
            if (ds.Tables.Count > 0)
            {
                drpCmpList.DataSource = ds;
                drpCmpList.DataTextField = ds.Tables[0].Columns[0].ToString();
                drpCmpList.DataValueField = ds.Tables[0].Columns[0].ToString();
                drpCmpList.DataBind();
            }

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {


            string compname;
            compname = drpCmpList.SelectedItem.ToString();
            if (compname != null && compname != "")
            {
                lbl_status.Text = compname;

                string path = "C:\\Asset\\Data\\" + compname + ".xml";
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    fi.Delete();
 /////////////////////////////////////////////////////////////////////////////change done by meenakshi
                    
                    string sQuery = ("select assetId from Asset_mst where computerName='"+compname+"'");
                    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ToString();
                    SqlConnection sc = new SqlConnection(constr);
                    sc.Open();
                    SqlCommand cmd = new SqlCommand(sQuery, sc);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        ObjAsset.Assetid = Convert.ToInt32(dr["assetId"].ToString());

                    }
                    dr.Close();
                    sc.Close();

                    
                    ObjAsset.UpdateDeleteFlag_Asset_id();
//////////////////////////////////////////////////////////////////////////////end
                    //lbl_status.Text = "Inventory removed...";
                    string myScript;
                    myScript = "<script language=javascript>alert('Inventory removed successfully....');</script>";
                    Page.RegisterClientScriptBlock("MyScript", myScript);
                
                    filenames = Get_Data_Files();
                    Write_Computer_List(filenames);



                    string xmlfilePath;
                    DataSet ds = new DataSet();
                    xmlfilePath = Server.MapPath("~/files/Asset.xml");
                    ds.ReadXml(xmlfilePath);
                    drpCmpList.DataSource = ds;
                    drpCmpList.DataTextField = ds.Tables[0].Columns[0].ToString();
                    drpCmpList.DataValueField = ds.Tables[0].Columns[0].ToString();
                    drpCmpList.DataBind();



                }
                else
                {
                    //lbl_status.Text = "Computer not found..";
                    string myScript;
                    myScript = "<script language=javascript>alert('Computer not found.'); </script>";
                    Page.RegisterClientScriptBlock("MyScript", myScript);
                }


            }

        }
        catch (Exception ex)
        {

            string myScript;
            myScript = "<script language=javascript>alert('Record Not Found'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);

        }

    }
    public string[] Get_Data_Files()
    {
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

            XmlElement xeComputer = xd.CreateElement("Computer");
            xeroot.AppendChild(xeComputer);
            XmlAttribute xa = xd.CreateAttribute("Name");
            xa.Value = K.ToString();
            xeComputer.Attributes.Append(xa);
        }

        xd.Save(Server.MapPath("~/files/Asset.xml"));

    }
  
}
