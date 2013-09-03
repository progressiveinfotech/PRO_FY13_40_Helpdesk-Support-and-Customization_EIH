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

public partial class Asset_ViewAsset : System.Web.UI.Page
{
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
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
    {///Add Exception handilng try catch change by vishal 21-05-2012
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
    { ///Add Exception handilng try catch change by vishal 21-05-2012
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
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.CommandName == "ViewDetails")
            {
                int temp = 0;
                string strassecompany = e.CommandArgument.ToString();
                string[] splitchar = strassecompany.Split(new char[] { ',' });

                int Assetid = Convert.ToInt32(splitchar[0].ToString());
                string compname = splitchar[1].ToString();
                Session["Assetid"] = Assetid.ToString();
                Session["temp"] = temp;
                Response.Redirect("~/Asset/ViewAssetDetails.aspx?" + compname + "");
            }

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
            //////////add by vishal 02-06-2012
            if (e.CommandName == "Del")
            {
                string asset = e.CommandArgument.ToString();
                int assetid = Convert.ToInt32(asset);
                ObjAsset.Assetid = assetid;
                ObjAsset.UpdateDeleteFlag_Asset_id();
                string myScript;
                myScript = "<script language=javascript>alert('Record deleted successfully  !');</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
                // Refresh the data
                grdvwViewAsset.EditIndex = -1;
                BindGrid1();
            }
            ////////end 02-06-2012
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

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string name;

            if (txtname.Text == "")
            {
                col = ObjAsset.Get_By_comandname("");
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
                ViewState["commandname"] = "";
            }
            else
            {
                name = txtname.Text.ToString();
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


    protected void grdvwViewAsset_RowEdit(object sender, GridViewEditEventArgs e)
    {
        //int temp = 0;
        /////Comment by Vishal because Add edit button in grid and change cell number. Date 16-05-2012
        //int Assetid = Convert.ToInt32(grdvwViewAsset.Rows[e.NewEditIndex].Cells[0].Text);
        //string compname = grdvwViewAsset.Rows[e.NewEditIndex].Cells[1].Text.ToString();
        //int Assetid = Convert.ToInt32(grdvwViewAsset.Rows[e.NewEditIndex].Cells[1].Text);
        //string compname = grdvwViewAsset.Rows[e.NewEditIndex].Cells[2].Text.ToString();
        //Session["Assetid"] = Assetid.ToString();
        //Session["temp"] = temp;
        //Response.Redirect("~/Asset/ViewAssetDetails.aspx?" + compname + "" );


        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            grdvwViewAsset.EditIndex = e.NewEditIndex;

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
    protected void grdvwViewAsset_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            grdvwViewAsset.EditIndex = -1;

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
    protected void grdvwViewAsset_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            GridViewRow row = (GridViewRow)grdvwViewAsset.Rows[e.RowIndex];

            int assetid = Int32.Parse(grdvwViewAsset.DataKeys[e.RowIndex].Value.ToString());

            TextBox txtTagNo = (TextBox)row.FindControl("txtTagNo");

            TextBox txtPONo = (TextBox)row.FindControl("txtPONo");

            TextBox txtOwner = (TextBox)row.FindControl("txtOwner");

            TextBox txtLocation = (TextBox)row.FindControl("txtLocation");

            TextBox txtCompanyCode = (TextBox)row.FindControl("txtCompanyCode");
           
            TextBox txtPurchaseDate = (TextBox)row.FindControl("txtPurchaseDate");
           
            TextBox txtAssetCategory = (TextBox)row.FindControl("txtAssetCategory");
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

            DropDownList ddlstock = (DropDownList)row.FindControl("ddlstock");
            
            Label lblmanual = (Label)row.FindControl("lblmanual");

            ObjAsset.Assetid = assetid;
            ObjAsset.TagNo = txtTagNo.Text;
            ObjAsset.PONo = txtPONo.Text;
            ObjAsset.location = txtLocation.Text;
            //if (lblmanual.Text == "Yes")
            //{
            ObjAsset.IsInStock = Convert.ToBoolean(ddlstock.SelectedValue);
            ObjAsset.AssetOwner = txtOwner.Text;
            ObjAsset.CompanyCode = txtCompanyCode.Text;
            //if (txtPurchaseDate.Text.Trim() != "")
            //{
            //    ObjAsset.PurchaseDate = DateTime.ParseExact(txtPurchaseDate.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString();
            //}
            //else
            //{
            //    ObjAsset.PurchaseDate = null;
            //}
         //ObjAsset.PurchaseDate = txtPurchaseDate.Text;
            if (txtPurchaseDate.Text.ToString() != "")
            {
                ObjAsset.PurchaseDate = txtPurchaseDate.Text.ToString();
            }
            else
            {
                ObjAsset.PurchaseDate = null;
            }
            //ObjAsset.PurchaseDate = ((DateTime)returnData["PurchaseDate"]).ToString();
            ObjAsset.AssetCategory = txtAssetCategory.Text;
            ObjAsset.Remarks = txtRemarks.Text;


            ObjAsset.Update_Asset_mst_Tag_PO_By_id();
            //}
            //else if (ddlstock.SelectedValue == "True" && lblmanual.Text == "No")
            //{
            //    ObjAsset.IsInStock = Convert.ToBoolean(ddlstock.SelectedValue);
            //    ObjAsset.AssetOwner = txtOwner.Text;

            //    ObjAsset.Update_Asset_mst_Tag_PO_By_id();

            //}
            //else
            //{
            //    ObjAsset.AssetOwner = txtOwner.Text;

            //    ObjAsset.Update_Asset_mst_Tag_PO_IsInStockBy_id();
           
            //}
            //if (DdlOwner.SelectedItem.Text == "Other")
            //{

            // Refresh the data
            grdvwViewAsset.EditIndex = -1;
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

    /// <summary>
    /// /////////Add by vishal 02-06-2012 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void grdvwViewAsset_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStock = (Label)e.Row.FindControl("lblStock");
            if (lblStock != null)
            {
                if (lblStock.Text == "False")
                {
                    lblStock.Text = "No";
                }
                else
                {
                    lblStock.Text = "Yes";
                }
            }
            Label lblmanual = (Label)e.Row.FindControl("lblmanual");
            if (lblmanual != null)
            {
                if (lblmanual.Text == "False")
                {
                    lblmanual.Text = "No";
                }
                else
                {
                    lblmanual.Text = "Yes";
                }
            }

        }
    }


    /////////////////end 02-06-2012
}
