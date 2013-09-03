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

public partial class admin_AddCountry : System.Web.UI.Page
{

    // Coded by -Sumit Gupta
    // Coded On -20 Jan 2010
    // Purpose  - Add Country to Database

    // Declare Objects of Various Classes ,Used later

    Country_mst objCountry = new Country_mst();
    BLLCollection<Country_mst> col = new BLLCollection<Country_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
               reqValCountry.ErrorMessage = Resources.MessageResource.errCountry.ToString();
            // Bind GridView at Page Load by Calling BindGrid() Function
               BindGrid();
        }
    }

    public void BindGrid()
    {

        // Initialize col objects, to get collection of Country_mst objects by Calling Function Get_All()
           col = objCountry.Get_All();
        // Bind GridView via col datasource
           grvwCountry.DataSource = col;
           grvwCountry.DataBind();


    }
    protected void btnCountryadd_Click(object sender, EventArgs e)
    {
        // Declare Local Variable FlagCountry and FlagInsert ,to fins the status of Functions  Get_By_CountryName() and Insert() Respectively
        int FlagCountry;
        int FlagInsert;
        // Get the Status of Get_By_CountryName(),to check country already exist
        FlagCountry = objCountry.Get_By_CountryName(txtCountryName.Text.ToString().Trim());
        // If FlagCountry is zero than,country not exist in database
        if (FlagCountry == 0)
        {
            objCountry.Countryname  = txtCountryName.Text.ToString().Trim();
            // Calling Insert() function to save data in database
            FlagInsert=objCountry.Insert();

            // If FlagInsert is 1 than operation perform successfully,otherwise some error happened
            if (FlagInsert == 1)
            {
                lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
                BindGrid();
            }
            else 
            {
                // Display Error Message Error Occurred during Insert Data in Database
                lblerrmsg.Text = Resources.MessageResource.errOccured.ToString();        
            }
            
        }
        else
        {
            // Dispaly Country Already Exist
            lblerrmsg.Text = Resources.MessageResource.errCountryExist.ToString();
        }

        Dispose();
        txtCountryName.Text = "";
    }

    protected void grvwCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Handling Event Page Indexing of GridView 
        grvwCountry.PageIndex = e.NewPageIndex;
        BindGrid();

    }
    protected void Clear()
    {
        txtCountryName.Text = "";
        lblerrmsg.Text = "";
    
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
        Clear();
    }

    protected void grvwCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Handling Event Page RowDeleting of GridView 
        Clear();
        int CountryId = 0;
        CountryId = Convert.ToInt32(grvwCountry.Rows[e.RowIndex].Cells[0].Text);
        objCountry.Delete(CountryId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void grvwCountry_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Handling Event Page RowEditing of GridView
        Clear();
        grvwCountry.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grvwCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Clear();
        grvwCountry.EditIndex = -1;
        BindGrid();
    }

    protected void grvwCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Handling Event Page RowUpdating of GridView 
        Clear();
        string name,id;
        int CountryId = 0;
        int FlagCountry;
        name = ((TextBox)grvwCountry.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        FlagCountry = objCountry.Get_By_CountryName(name);
        if ((FlagCountry == 0)&&(name!=""))
        {
            id = Convert.ToString(grvwCountry.Rows[e.RowIndex].Cells[0].Text);
            CountryId = Convert.ToInt32(id);
            objCountry.Countryid = CountryId;
            objCountry.Countryname = name;
            objCountry.Update();
            grvwCountry.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();

        }
        else if(name=="")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else
        {
            grvwCountry.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errCountryExist.ToString();
            
        }
        

    }
}
