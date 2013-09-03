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

public partial class Change_SelectAssetFromCMDB : System.Web.UI.Page
{
    BLLCollection<Configuration_mst> col = new BLLCollection<Configuration_mst>();
    Configuration_mst ObjConfigurationmst = new Configuration_mst();
    Category_mst objcategory = new Category_mst();
    Vendor_mst ObjVendor = new Vendor_mst();
    protected void Page_Load(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindGrid();

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
    public void BindGrid()
    {


        col = ObjConfigurationmst.Get_All();
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();


    }
    protected void grdvwViewAsset_RowDataBound(Object sender, GridViewRowEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int id = Convert.ToInt32(e.Row.Cells[3].Text);

                objcategory = objcategory.Get_By_id(id);
                //objcategory = objcategory.Get_By_CategoryName();
                e.Row.Cells[3].Text = objcategory.CategoryName.ToString();
                int vendorid = Convert.ToInt32(e.Row.Cells[4].Text);
                ObjVendor = ObjVendor.Get_By_id(vendorid);
                e.Row.Cells[4].Text = ObjVendor.Vendorname.ToString();
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
    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            grdvwViewAsset.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string serialno = txtAssets.Text.ToString();
            col = ObjConfigurationmst.Get_All_By_SerialNo(serialno);
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
            txtAssets.Text = "";
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnAddAsset_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            foreach (GridViewRow gv in grdvwViewAsset.Rows)
            {

                string gvIDs;
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {
                    ListItem item = new ListItem();
                    int varSiteid;
                    int FlagCheckAsset = 0;
                    // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                    gvIDs = ((Label)gv.FindControl("assetid")).Text.ToString();



                    ObjConfigurationmst = ObjConfigurationmst.Get_By_id(Convert.ToInt32(gvIDs));
                    item.Text = ObjConfigurationmst.Serialno;
                    item.Value = ObjConfigurationmst.Assetid.ToString();


                    for (int i = listAsset.Items.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(listAsset.Items[i].Value) == ObjConfigurationmst.Assetid)
                        {
                            FlagCheckAsset = 1;

                        }


                    }
                    if (FlagCheckAsset == 0)
                    { listAsset.Items.Add(item); }


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
    protected void btnAsset_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string varAllAssetId = "";
            for (int i = listAsset.Items.Count - 1; i >= 0; i--)
            {

                varAllAssetId = varAllAssetId + listAsset.Items[i].Value + ",";



            }
            Session["AssetContract"] = varAllAssetId;
            string myScript;
            myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);

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





















































