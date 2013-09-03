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

public partial class Change_Select_Asset : System.Web.UI.Page
{
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> colasset = new BLLCollection<Asset_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                bindlist();
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

    protected void bindlist()
    {
        colasset = ObjAsset.Get_All();
        lstboxasset.DataSource = colasset;
        lstboxasset.DataTextField = "computerName";
        lstboxasset.DataValueField = "assetId";
        lstboxasset.DataBind();
    }
    protected void btnlisttoright_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ArrayList items = new ArrayList();
            int i = 0;
            int j = 0;

            foreach (ListItem item in lstboxasset.Items)
            {


                if (item.Selected)
                {

                    foreach (ListItem item1 in lstboxselecasset.Items)
                    {
                        if (item.Value == item1.Value)
                        {
                        }
                        else
                        {
                            lstboxselecasset.Items.Add(item);
                        }

                        j++;
                    }



                    i++;

                }

            }
            lstboxselecasset.DataBind();

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
