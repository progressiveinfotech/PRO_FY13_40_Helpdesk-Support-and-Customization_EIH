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

#region EditColorScheme.aspx.cs
public partial class admin_EditColorScheme : System.Web.UI.Page
{
    #region Create Objects of BLL Classes

    ColorScheme_mst objcolor = new ColorScheme_mst();
    BLLCollection<Status_mst> col = new BLLCollection<Status_mst>();
    Status_mst StatusObj = new Status_mst();

    #endregion

    #region Page Load
    int colorid;
    protected void Page_Load(object sender, EventArgs e)
    {
        colorid = Convert.ToInt32(Request.QueryString[0]);

        if (!IsPostBack)
        {
            colorid = Convert.ToInt32(Request.QueryString[0]);
            objcolor = objcolor.Get_By_id(colorid);
            txtcolorname.Text = objcolor.Colorname.ToString();
            txtPercent.Text = objcolor.Percnt.ToString(); ;
            txtPercentTo.Text = objcolor.Percnt_to.ToString();
            txtcallstatus.Text = objcolor.CallStatus.ToString();
            //reqValcolor.Text = "Enter the Color Name";
            //reqValPercent.Text = "Enter Percent Value";
            //reqValPercentTo.Text = "Enter the Value of PercentTo";
            //reqValcallstatus.Text = "Select Call Status";

        }
    }
    #endregion

    #region Update Color Scheme
    protected void btnColorupdate_Click(object sender, EventArgs e)
    {
        int colorcount;
        string colorname = txtcolorname.Text.ToString();
        objcolor = objcolor.Get_By_id(colorid);
        if (objcolor.Colorid!=0)
        {
            if (objcolor.Colorname.ToLower() == txtcolorname.Text.ToString().ToLower())
            {

                objcolor.Colorid = colorid;
                objcolor.Colorname = txtcolorname.Text.ToString();
                objcolor.Percnt = Convert.ToInt32(txtPercent.Text);
                objcolor.Percnt_to = Convert.ToInt32(txtPercentTo.Text);
                objcolor.CallStatus = txtcallstatus.Text.ToString();
                objcolor.Update();
                Response.Redirect("../admin/AddcolorScheme.aspx");


            }
            else 
            {

                colorcount = objcolor.Check_Colorname(colorname);
                if (colorcount == 0)
                {
                    objcolor.Colorid = colorid;
                    objcolor.Colorname = txtcolorname.Text.ToString();
                    objcolor.Percnt = Convert.ToInt32(txtPercent.Text);
                    objcolor.Percnt_to = Convert.ToInt32(txtPercentTo.Text);
                    objcolor.CallStatus = txtcallstatus.Text.ToString();
                    objcolor.Update();
                    Response.Redirect("../admin/AddcolorScheme.aspx");
                }
                else
                {
                    lblErrorMsg.Text = "Color Name Already Exist";
                }
            
            }

        
        }

        //colorcount = objcolor.Check_Colorname(colorname);
        //if (colorcount == 0)
        //{
        //    objcolor.Colorid = colorid;
        //    objcolor.Colorname = txtcolorname.Text.ToString();
        //    objcolor.Percnt = Convert.ToInt32(txtPercent.Text);
        //    objcolor.Percnt_to = Convert.ToInt32(txtPercentTo.Text);
        //    objcolor.CallStatus = txtcallstatus.Text.ToString();
        //    objcolor.Update();
        //    Response.Redirect("../admin/AddcolorScheme.aspx");
        //}
        //else
        //{
        //    lblErrorMsg.Text = "Color Name Already Exist";
        //}

    }
    #endregion

    #region
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Back to AddColorScheme.aspx page
    protected void lnkback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddColorScheme.aspx");
    }
    #endregion
}
#endregion
