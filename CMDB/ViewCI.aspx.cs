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

public partial class CMDB_ViewCI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindDropCategory();
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
    Category_mst objCategory = new Category_mst();
    ConfigurableItems_mst Objconfigurableitems = new ConfigurableItems_mst();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    BLLCollection<ConfigurableItems_mst> col = new BLLCollection<ConfigurableItems_mst>();
    #region Bind the Items
    protected void BindDropCategory()
    {
        colCategory = objCategory.Get_All();
        drpitem.DataTextField = "categoryname";
        drpitem.DataValueField = "categoryid";
        drpitem.DataSource = colCategory;
        drpitem.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Item------";
        item.Value = "0";
        drpitem.Items.Add(item);
        drpitem.SelectedValue = "0";


    }




    #endregion



    protected void drpitem_SelectedIndexChanged(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
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
    public void BindGrid()
    {
        int itemid = Convert.ToInt32(drpitem.SelectedValue);
        col = Objconfigurableitems.Get_All_CI_Byitems(itemid);



        grdvwCI.DataSource = col;
        grdvwCI.DataBind();

    }
    protected void grdvwCI_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int itemid = Convert.ToInt32(drpitem.SelectedValue);
                objCategory = objCategory.Get_By_id(itemid);
                if (objCategory.Categoryid != 0)
                {
                    e.Row.Cells[1].Text = objCategory.CategoryName.ToString();
                }
                else { e.Row.Cells[2].Text = ""; }
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
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("AddConfigurableitems.aspx");
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
