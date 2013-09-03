using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddHub : System.Web.UI.Page
{
    //Mode_mst ObjMode = new Mode_mst();
    Hub_mst objhub = new Hub_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValMode.ErrorMessage = "Enter hub";
            BindGrid();
        }
    }
    public void BindGrid()
    {
        // Declare col as Collection of Region_mst Object to get all records from table 
        BLLCollection<Hub_mst> col = new BLLCollection<Hub_mst>();
        col = objhub.Get_All();
        Modegrdw.DataSource = col;
        Modegrdw.DataBind();
        ClearControl();
    }

    protected void btnHubadd_Click(object sender, EventArgs e)
    {
        int hubname;
        hubname = objhub.Get_Hub_By_Mname(txtHubName.Text.ToString());
        if (hubname == 0)
        {
            objhub.Hubname =txtHubName.Text;
            objhub.Description = txtHubDescription.Text;
            objhub.Insert();
            BindGrid();
            lblerrmsg.Text = "Hub details added";
        }
        else
        {
            lblerrmsg.Text = "Hub already exits";
        }
    }
    protected void ClearControl()
    {
        txtHubDescription.Text = "";
        txtHubName.Text = "";
        lblerrmsg.Text = "";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}
