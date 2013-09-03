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

public partial class Contract_AddContract : System.Web.UI.Page
{
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    BLLCollection<EscalateEmail_mst> colEscalateEmail = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    Contract_mst objContract = new Contract_mst();
    ContractToAssetMapping objContractToAsset = new ContractToAssetMapping();
    ContractNotification objContractNotfy = new ContractNotification();

    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindEmailListbox();
                BindVendor();
                string varAsset = "";
                if (Session["AssetContract"] != null)
                {
                    varAsset = Session["AssetContract"].ToString();
                }

                if (varAsset != "")
                {
                    BindListBox();
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
    protected void BindVendor()
    {
        colVendor = objVendor.Get_All();
        drpVendor.DataTextField = "vendorname";
        drpVendor.DataValueField = "vendorid";
        drpVendor.DataSource = colVendor;
        drpVendor.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Vendor------";
        item.Value = "0";
        drpVendor.Items.Add(item);
        drpVendor.SelectedValue = "0";

    }
    protected void lnkAddVendor_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');", "javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');", true);
            string myScript;
            myScript = "<script language=javascript>javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');</script>";
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
    protected void lnkAddAsset_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            Session["contractname"] = txtContractName.Text;
            Session["description"] = txtdesc.Text;
            Session["vendorid"] = drpVendor.SelectedValue;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", "javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", true);
            string myScript;
            myScript = "<script language=javascript>javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');</script>";
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

    protected void BindListBox()
    {
        txtContractName.Text = Session["contractname"].ToString();
        txtdesc.Text = Session["description"].ToString();
        drpVendor.SelectedValue = Session["vendorid"].ToString();
        Asset_mst ObjAsset = new Asset_mst();
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        string varAsset = Session["AssetContract"].ToString();
        string[] arrAsset = varAsset.Split(',');
        int FlagCount = arrAsset.Length;
        for (int i = 0; i < FlagCount; i++)
        {
            if (arrAsset[i] != "," && arrAsset[i] != "")
            {
                Asset_mst obj = new Asset_mst();
                obj = ObjAsset.Get_By_id(Convert.ToInt32(arrAsset[i].ToString()));
                col.Add(obj);
            }

        }
        ListAsset.DataTextField = "computerName";
        ListAsset.DataValueField = "assetid";
        ListAsset.DataSource = col;
        ListAsset.DataBind();
        Session["AssetContract"] = "";


    }

    protected void BindEmailListbox()
    {
        colEscalateEmail = objEscalateEmail.Get_All();
        listLevel1.DataTextField = "email";
        listLevel1.DataValueField = "id";

        listLevel1.DataSource = colEscalateEmail;
        listLevel1.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            string vardateFrom;
            string vardateTo;
            string varemail = "";
            int FlagCount = 0;
            int contractid;
            FlagCount = objContract.Get_By_Contractname(txtContractName.Text);
            if (FlagCount == 0)
            {
                string[] tempdate = txtActiveFrom.Text.ToString().Split(("/").ToCharArray());
                vardateFrom = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];

                string[] tempdate1 = txtActiveTo.Text.ToString().Split(("/").ToCharArray());
                vardateTo = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];


                objContract.Activefrom = vardateFrom;
                objContract.Activeto = vardateTo;
                objContract.Contractname = txtContractName.Text;
                objContract.Description = txtdesc.Text;
                objContract.Vendorid = Convert.ToInt32(drpVendor.SelectedValue);
                objContract.Insert();
                contractid = objContract.Get_TopContractId();

                for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
                {

                    objContractToAsset.Assetid = Convert.ToInt32(ListAsset.Items[i].Value);
                    objContractToAsset.Contractid = contractid;
                    objContractToAsset.Insert();


                }
                if (chkLevel1.Checked == true)
                {
                    for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
                    {
                        if (listLevel1.Items[i].Selected == true)
                        {
                            varemail = varemail + listLevel1.Items[i].Text + ",";
                        }
                    }

                    objContractNotfy.Contractid = contractid;
                    objContractNotfy.Sendnotification = false;
                    objContractNotfy.Sentto = varemail;
                    objContractNotfy.Beforedays = Convert.ToInt32(txtBeforeDays.Text);
                    objContractNotfy.Insert();


                }
                ClearControl();
                Response.Redirect("~/Contract/ViewContract.aspx?" + contractid + "");
            }
            else
            {
                lblErrorMsg.Text = "Contract of this name already exist";
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

    protected void ClearControl()
    {

        txtContractName.Text = "";
        txtdesc.Text = "";
        txtActiveFrom.Text = "";
        txtActiveTo.Text = "";
        drpVendor.SelectedValue = "0";
        lblErrorMsg.Text = "";
        txtBeforeDays.Text = "";


        chkLevel1.Checked = false;

        for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel1.Items[i].Selected == true)
            {
                listLevel1.Items[i].Selected = false;
            }
        }

        for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
        {
            if (ListAsset.Items[i].Selected == true)
            {
                ListAsset.Items[i].Selected = false;
            }
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            ClearControl();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void lnkRemove_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
            {
                if (ListAsset.Items[i].Selected == true)
                {
                    int assetid = Convert.ToInt32(ListAsset.Items[i].Value);
                    ListItem item = new ListItem();
                    item.Value = ListAsset.Items[i].Value;
                    item.Text = ListAsset.Items[i].Text;
                    ListAsset.Items.Remove(item);



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
