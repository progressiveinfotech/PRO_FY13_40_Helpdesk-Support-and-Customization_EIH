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

public partial class admin_AddState : System.Web.UI.Page
{
    //Coded by - Sumit Gupta
    //Coded On - 21 Jan 2010
    //Purpose  - Add State to Database 
    
    // Declare Objects of various Classes ,Used later
    State_mst objState = new State_mst();
    BLLCollection<Country_mst> col1 = new BLLCollection<Country_mst>();
    BLLCollection<State_mst> colState = new BLLCollection<State_mst>();
    Country_mst objCountry = new Country_mst();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            reqValtxtStateName.ErrorMessage = Resources.MessageResource.errStateName.ToString();
            // Bind Grid BindDrpCountry() and BindGrid()
            BindDrpCountry();
            BindGrid();
        }
       
    }

    // Definition of BindDrpCountry()
    public void BindDrpCountry()
    {
        col1 = objCountry.Get_All();
        drpCountry.DataTextField = "countryname";
        drpCountry.DataValueField = "countryid";
        drpCountry.DataSource = col1;
        drpCountry.DataBind();
        drpCountry.SelectedValue = "1";
    }

   // Handling of Button btnAdd Click Event , To Add State in Database 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Declare Local Variables FlagInsert,FlagState and countryid
        int FlagInsert;
        int FlagState;
        int countryid = Convert.ToInt32(drpCountry.SelectedValue);
        FlagState = objState.Get_By_StateName(txtStateName.Text.ToString().Trim());
        // Check whether state already exist , if FlagState is zero then State not exist in Database
        if (FlagState == 0)
        {
            objState.Countryid = countryid;
            objState.Statename = txtStateName.Text.ToString().Trim();
            // Insert data into Database by calling function objState.Insert()
            FlagInsert = objState.Insert();
            // If FlagInsert  is 1 then ,operation perform Successfully
            if (FlagInsert == 1)
            {
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
            }
                // Some Error Occured while inserting data into database
            else 
            {
                lblerrmsg.Text = Resources.MessageResource.errOccured.ToString();
            }
        }
        else 
        {
            // Display Message State Already Exist
            lblerrmsg.Text = Resources.MessageResource.errStateExist.ToString();
        }
       
    }

    protected void clear()
    {
        txtStateName.Text = "";
        lblerrmsg.Text = "";
    }

    // Definition of  BindGrid();
    protected void BindGrid()
    {
        colState = objState.Get_All();
        grvwObj.DataSource = colState;
        grvwObj.DataBind();
        clear();
    }

    // Handler grvwObj_PageIndexChanging handling GridView PageIndexing Event
    protected void grvwObj_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvwObj.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    // Handler grvwObj_RowDeleting handling GridView RowDeleting Event
    protected void grvwObj_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int stateid;
        stateid = Convert.ToInt32(grvwObj.Rows[e.RowIndex].Cells[0].Text);
        objState.Delete(stateid);
        BindGrid();
    }

    // Handler grvwObj_RowDataBound handling GridView RowDataBound Event
    protected void grvwObj_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        {
            int countryid;
            Label lblCountry = (Label)e.Row.FindControl("lblCountry");
            if (lblCountry!=null)
            {
                countryid = Convert.ToInt32(lblCountry.Text);
                ViewState["countryid"] = lblCountry.Text;
                objCountry = objCountry.Get_By_id(countryid);
                lblCountry.Text = objCountry.Countryname.ToString();
            }
        }
        if (e.Row.RowState == DataControlRowState.Edit )
        {

            DropDownList dropCountry = (DropDownList)e.Row.FindControl("dropCountry");
            BLLCollection<Country_mst> col = new BLLCollection<Country_mst>();
            col = objCountry.Get_All();
            dropCountry.DataSource = col;
            dropCountry.DataTextField = "countryname";
            dropCountry.DataValueField = "countryid";
            dropCountry.DataBind();
            dropCountry.SelectedValue = ViewState["countryid"].ToString();
        }
        if (e.Row.RowState == (System.Web.UI.WebControls.DataControlRowState.Alternate | System.Web.UI.WebControls.DataControlRowState.Edit))
        {
            DropDownList dropCountry = (DropDownList)e.Row.FindControl("dropCountry");
            BLLCollection<Country_mst> col = new BLLCollection<Country_mst>();
            col = objCountry.Get_All();
            dropCountry.DataSource = col;
            dropCountry.DataTextField = "countryname";
            dropCountry.DataValueField = "countryid";
            dropCountry.DataBind();
            dropCountry.SelectedValue = ViewState["countryid"].ToString();
        }
    }

    // Handler grvwObj_RowEditing handling GridView RowEditing  Event
    protected void grvwObj_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvwObj.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    // Handler grvwObj_RowCancelingEdit handling GridView RowCancelingEdit  Event
    protected void grvwObj_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvwObj.EditIndex = -1;
        BindGrid();
    }

    // Handler grvwObj_RowUpdating handling GridView RowUpdating  Event
    protected void grvwObj_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Declare local variables of name,id and stateid
        string name,  id;
        int stateid, count=0;
        // Assign state name to local variable name
        name = ((TextBox)grvwObj.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        // Assign State id to local variable id
        id = Convert.ToString(grvwObj.Rows[e.RowIndex].Cells[0].Text);
        DropDownList Countrydrp = ((DropDownList)grvwObj.Rows[e.RowIndex].Cells[3].FindControl("dropCountry"));
        // Declare local variable countryid and assign from drop down selected value
        int countryid = Convert.ToInt32(Countrydrp.SelectedValue);
        stateid = Convert.ToInt32(id);
        count = objState.Get_By_StateName(name);
        objState = objState.Get_By_Stateid(stateid);

        if ((count == 0) && (name != ""))
        {
            objState.Stateid = stateid;
            objState.Countryid = countryid;
            objState.Statename = name;
            objState.Update();
            grvwObj.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (objState.Statename == name)
        {
            objState.Stateid = stateid;
            objState.Countryid = countryid;
            objState.Statename = name;
            objState.Update();
            grvwObj.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (name == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.erralready.ToString();
        }
    }

    // Handling Event of  Button btnReset Click Event
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
}
