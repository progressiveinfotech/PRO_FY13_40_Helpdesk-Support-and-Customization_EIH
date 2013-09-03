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

public partial class Contract_DisplayAllContract : System.Web.UI.Page
{
    Contract_mst objContract = new Contract_mst();
    BLLCollection<Contract_mst> colContract = new BLLCollection<Contract_mst>();
    Vendor_mst objVendor = new Vendor_mst();
    ContractNotification objContNotfy = new ContractNotification();
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
    protected void BindGrid()
    {
        int TotalSpentTimeInMins = 0;
        int filterid = Convert.ToInt32(drpFilter.SelectedValue);
        BLLCollection<Contract_mst> col = new BLLCollection<Contract_mst>();
        colContract = objContract.Get_All();
        foreach (Contract_mst obj in colContract)
        {
            Contract_mst objCon = new Contract_mst();
            objCon = obj.Get_By_id(obj.Contractid);
            if (filterid == 1)
            {
                TotalSpentTimeInMins = obj.Get_Contract_Status(objCon.Activeto);
                if (TotalSpentTimeInMins > 0)
                {
                    col.Add(objCon);
                }

            }
            if (filterid == 2)
            {
                TotalSpentTimeInMins = obj.Get_Contract_Status(objCon.Activeto);
                if (TotalSpentTimeInMins <= 0)
                {
                    col.Add(objCon);
                }

            }
            if (filterid == 3)
            {
                TotalSpentTimeInMins = obj.Get_Contract_Status(objCon.Activeto);
                if (TotalSpentTimeInMins <= 0 && TotalSpentTimeInMins > (-10080))
                {
                    col.Add(objCon);
                }

            }
            if (filterid == 4)
            {
                TotalSpentTimeInMins = obj.Get_Contract_Status(objCon.Activeto);
                if (TotalSpentTimeInMins > 0 && TotalSpentTimeInMins < 10080)
                {
                    col.Add(objCon);
                }

            }
            if (filterid == 5)
            {
                TotalSpentTimeInMins = obj.Get_Contract_Status(objCon.Activeto);
                if (TotalSpentTimeInMins > 0 && TotalSpentTimeInMins < 21600)
                {
                    col.Add(objCon);
                }

            }

        }
        grvwContract.DataSource = col;
        grvwContract.DataBind();


    }

    protected void grvwContract_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hndling GridView RowDataBound  Event for Binding vendorid to Vendor name  
                int vendorid = Convert.ToInt32(e.Row.Cells[5].Text);
                objVendor = objVendor.Get_By_id(vendorid);
                e.Row.Cells[5].Text = objVendor.Vendorname.ToString();
                int contractid = Convert.ToInt32(e.Row.Cells[1].Text);
                objContract = objContract.Get_By_id(contractid);
                int TotalSpentTimeInMins = objContract.Get_Contract_Status(objContract.Activeto);
                Label lbl = ((Label)e.Row.FindControl("lblActive"));
                if (TotalSpentTimeInMins > 0)
                {
                    lbl.Text = "Active";

                }
                else { lbl.Text = "Not Active"; }

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
    protected void drpFilter_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            foreach (GridViewRow gv in grvwContract.Rows)
            {

                string gvIDs;
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {

                    int contractid;
                    gvIDs = ((Label)gv.FindControl("contractid")).Text.ToString();
                    contractid = Convert.ToInt32(gvIDs);
                    objContNotfy.Delete(contractid);
                    objContToAsset.Delete(contractid);
                    objContract.Delete(contractid);
                    BindGrid();

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

    protected void grvwContract_RowEditing(object sender, GridViewEditEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int contractid;
            contractid = Convert.ToInt32(grvwContract.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("~/Contract/EditContract.aspx?" + contractid + " ");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }

    protected void grvwContract_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            int contractid;
            contractid = Convert.ToInt32(grvwContract.Rows[e.RowIndex].Cells[1].Text);
            Response.Redirect("~/Contract/ViewContract.aspx?" + contractid + " ");
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void btnRenew_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            foreach (GridViewRow gv in grvwContract.Rows)
            {

                string gvIDs;
                // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
                // If deleteChkBxItem is Checked then ,mapped Current site to this user
                if (deleteChkBxItem.Checked)
                {

                    int contractid;
                    gvIDs = ((Label)gv.FindControl("contractid")).Text.ToString();
                    contractid = Convert.ToInt32(gvIDs);
                    Response.Redirect("~/Contract/RenewContract.aspx?" + contractid + " ");

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
}
