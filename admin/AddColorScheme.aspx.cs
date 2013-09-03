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

#region AddColorScheme.aspx.cs
public partial class admin_AddColorScheme : System.Web.UI.Page
{
    #region Create Objects of class
    ColorScheme_mst ColorSchemeObj = new ColorScheme_mst();
    BLLCollection<ColorScheme_mst> col = new BLLCollection<ColorScheme_mst>();
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //reqValcolor.Text = "Enter the Color Name";
            //reqValPercent.Text = "Enter Percent Value";
            //reqValPercentTo.Text = "Enter the Value of PercentTo";
            //reqValcallstatus.Text = "Select Call Status";
            BindGrid();
        }
    }
    #endregion

    #region Grid Binding
    public void BindGrid()
    {        
        col = ColorSchemeObj.Get_All();
        grdvwColor.DataSource = col;
        grdvwColor.DataBind();
    }
    #endregion

    #region function for Clear the controls
    protected void ClearControl()
    {
        txtcolorname.Text = "";
        txtPercent.Text = "";
        txtPercentTo.Text = "";
        txtcallstatus.Text = "";
        lblErrorMsg.Text = "";
    }
    #endregion

    #region Reset controls
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
        BindGrid();
    }
    #endregion

    #region Page Index of Grid View
    protected void grdvwColor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwColor.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    #endregion

    #region Add Details
    protected void btnColorAdd_Click(object sender, EventArgs e)
    {
        int colorcount;
        string colorname= txtcolorname.Text.ToString();
        colorcount = ColorSchemeObj.Check_Colorname(colorname);
        if (colorcount == 0)
        {
            ColorSchemeObj.Colorname = txtcolorname.Text.ToString();
            ColorSchemeObj.Percnt = Convert.ToInt32(txtPercent.Text);
            ColorSchemeObj.Percnt_to = Convert.ToInt32(txtPercentTo.Text);
            ColorSchemeObj.CallStatus = txtcallstatus.Text.ToString();
            ColorSchemeObj.Insert();
            BindGrid();
            ClearControl();
            lblErrorMsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblErrorMsg.Text = "Color Name Already Exist";
            txtcolorname.Text = "";

        }
    }
    #endregion

    #region Edit Color Scheme
    protected void grdvwColor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int colorid = Convert.ToInt32(grdvwColor.Rows[e.NewEditIndex].Cells[0].Text);
        Response.Redirect("~/admin/EditColorScheme.aspx?" + colorid + " ");
    }
    #endregion

    #region Delete Color Scheme
    protected void grdvwColor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ColorId = 0;
        ColorId = Convert.ToInt32(grdvwColor.Rows[e.RowIndex].Cells[0].Text);
        ColorSchemeObj.Delete(ColorId);
        BindGrid();
        ClearControl();
        lblErrorMsg.Text = Resources.MessageResource.errdelete;
    }
    #endregion

}
#endregion