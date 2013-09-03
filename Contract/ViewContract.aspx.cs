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

public partial class Contract_ViewContract : System.Web.UI.Page
{
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    BLLCollection<EscalateEmail_mst> colEscalateEmail = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    Contract_mst objContract = new Contract_mst();
    ContractToAssetMapping objContractToAsset = new ContractToAssetMapping();
    BLLCollection<ContractToAssetMapping> colContractToAssetMapping = new BLLCollection<ContractToAssetMapping>();
    ContractNotification objContractNotfy = new ContractNotification();
    Asset_mst objAsset = new Asset_mst();
    BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();
    ContractRenewed objConRenewed = new ContractRenewed();


    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindContract();

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
    protected void BindContract()
    {
        int contractid = Convert.ToInt32(Request.QueryString[0]);
        objContract = objContract.Get_By_id(contractid);
        if (objContract != null)
        {
            lblContractName.Text = objContract.Contractname;
            lblContractId.Text = objContract.Contractid.ToString();
            lblActiveFrom.Text = objContract.Activefrom.ToString();
            lblActiveTo.Text = objContract.Activeto.ToString();
            objVendor = objVendor.Get_By_id(objContract.Vendorid);
            lblVendorname.Text = objVendor.Vendorname.ToString();
            lblDesc.Text = objContract.Description.ToString();
            colContractToAssetMapping = objContractToAsset.Get_All_By_contractid(objContract.Contractid);
            foreach (ContractToAssetMapping obj in colContractToAssetMapping)
            {
                Asset_mst objA = new Asset_mst();
                objA = objA.Get_By_id(obj.Assetid);
                colAsset.Add(objA);
            }
            grdvwViewAsset.DataSource = colAsset;
            grdvwViewAsset.DataBind();
        }
        objConRenewed = objConRenewed.Get_By_id(contractid);
        if (objConRenewed.Contractid != 0)
        {
            lblRen.Visible = true;
            Contract_mst obj = new Contract_mst();
            obj = obj.Get_By_id(objConRenewed.Contractid);
            lblRenInfo.Text = obj.Contractname;
            lblRenInfo.Visible = true;

        }
        objContractNotfy = objContractNotfy.Get_By_id(contractid);
        if (objContractNotfy.Contractid != 0)
        {
            lblUsers.Text = objContractNotfy.Sentto;
            lblDays.Text = Convert.ToString(objContractNotfy.Beforedays);

        }
        else
        {
            lblUsers.Text = "-";
            lblDays.Text = "-";

        }
    }

    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            grdvwViewAsset.PageIndex = e.NewPageIndex;
            BindContract();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int contractid = Convert.ToInt32(Request.QueryString[0]);
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
    protected void lnkRenew_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("../Contract/DisplayAllContract.aspx");
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
