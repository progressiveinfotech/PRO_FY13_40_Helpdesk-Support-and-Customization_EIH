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

public partial class Contract_AddAsset : System.Web.UI.Page
{
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
    ContractToAssetMapping objContToAsset = new ContractToAssetMapping();
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
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

        col = ObjAsset.Get_By_comandname("A");
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        ViewState["commandname"] = "a";

    }

    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            grdvwViewAsset.PageIndex = e.NewPageIndex;
            BindGrid1();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void grdvwViewAsset_RowCreated(object sender, GridViewRowEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                TableCell cell = e.Row.Cells[0];

                cell.ColumnSpan = 6;

                for (int i = 65; i <= (65 + 25); i++)
                {

                    LinkButton lb = new LinkButton();

                    lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";

                    lb.CommandArgument = Char.ConvertFromUtf32(i);

                    lb.CommandName = "AlphaPaging";
                    lb.Font.Size = FontUnit.Large;
                    cell.Controls.Add(lb);

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

    protected void grdvwViewAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (e.CommandName.Equals("AlphaPaging"))
            {
                string commandname = e.CommandArgument.ToString();
                ViewState["commandname"] = e.CommandArgument.ToString();
                col = ObjAsset.Get_By_comandname(commandname);
                if (col.Count != 0)
                {
                    grdvwViewAsset.DataSource = col;
                    grdvwViewAsset.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("assetid");
                    dt.Columns.Add("computername");
                    dt.Columns.Add("domain");

                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);

                    grdvwViewAsset.DataSource = dt;
                    grdvwViewAsset.DataBind();

                    //grdvwViewAsset.Rows[0].Cells[3].Visible = false;
                    //grdvwViewAsset.Rows[0].Cells[5].Visible = false;


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
    protected void BindGrid1()
    {
        string commandname;
        commandname = ViewState["commandname"].ToString();
        col = ObjAsset.Get_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string name;

            if (txtAssets.Text == "")
            {
                col = ObjAsset.Get_By_comandname("");
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
                ViewState["commandname"] = "";
            }
            else
            {
                name = txtAssets.Text.ToString();
                col = ObjAsset.Get_By_comandname(name);
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
                ViewState["commandname"] = name;
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

    //protected void grdvwViewAsset_RowEdit(object sender, GridViewEditEventArgs e)
    //{
    //    int temp = 0;
    //    int Assetid = Convert.ToInt32(grdvwViewAsset.Rows[e.NewEditIndex].Cells[0].Text);
    //    string compname = grdvwViewAsset.Rows[e.NewEditIndex].Cells[1].Text.ToString();
    //    Session["Assetid"] = Assetid.ToString();
    //    Session["temp"] = temp;
    //    //Response.Redirect("~/Asset/ViewAssetDetails.aspx?" + compname + "");



    //}

    protected void grdvwViewAsset_RowDataBound(Object sender, GridViewRowEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.FindControl("assetid")).Text != "")
                {
                    int assetid = Convert.ToInt32(((Label)e.Row.FindControl("assetid")).Text.ToString());
                    int FlagCount;
                    FlagCount = objContToAsset.Get_By_Assetid(assetid);
                    Label lbl = ((Label)e.Row.FindControl("lblContract"));
                    if (FlagCount > 0)
                    {
                        lbl.Text = "Yes";
                    }
                    else
                    {
                        lbl.Text = "No";
                    }

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
    protected void btnAddAsset_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
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


                    ObjAsset = ObjAsset.Get_By_id(Convert.ToInt32(gvIDs));
                    item.Text = ObjAsset.Computername;
                    item.Value = Convert.ToString(ObjAsset.Assetid);

                    for (int i = listAsset.Items.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(listAsset.Items[i].Value) == ObjAsset.Assetid)
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
    {//Add Exception handilng try catch change by vishal 21-05-2012
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
