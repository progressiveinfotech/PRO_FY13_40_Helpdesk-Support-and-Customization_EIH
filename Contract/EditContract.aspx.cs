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

public partial class Contract_EditContract : System.Web.UI.Page
{
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    BLLCollection<EscalateEmail_mst> colEscalateEmail = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    Contract_mst objContract = new Contract_mst();
    ContractToAssetMapping objContractToAsset = new ContractToAssetMapping();
    ContractNotification objContractNotfy = new ContractNotification();
    BLLCollection<ContractToAssetMapping> colContractToAssetMapping = new BLLCollection<ContractToAssetMapping>();
    BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            if (!IsPostBack)
            {
                string varAsset = "";
                if (Session["AssetContract"] != null)
                {
                    varAsset = Session["AssetContract"].ToString();
                }


                BindEmailListbox();
                BindVendor();
                BindContractData();
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
    protected void BindEmailListbox()
    {
        colEscalateEmail = objEscalateEmail.Get_All();
        listLevel1.DataTextField = "email";
        listLevel1.DataValueField = "id";

        listLevel1.DataSource = colEscalateEmail;
        listLevel1.DataBind();

    }
    protected void BindContractData()
    {

        int contractid = Convert.ToInt32(Request.QueryString[0]);
        objContract = objContract.Get_By_id(contractid);
        if (objContract != null)
        {
            string dd;
            string mm;
            string yy;
            txtContractName.Text = objContract.Contractname;
            txtdesc.Text = objContract.Description.ToString();
            string[] tempdate = objContract.Activefrom.ToString().Split(("/").ToCharArray());
            string StrData = tempdate[2].ToString();
            string[] temp1 = StrData.Split((" ").ToCharArray());

            if (Convert.ToInt32(tempdate[1]) < 10)
            {
                dd = "0" + tempdate[1];
            }
            else
            {
                dd = tempdate[1];

            }
            if (Convert.ToInt32(tempdate[0]) < 10)
            {
                mm = "0" + tempdate[0];
            }
            else
            {
                mm = tempdate[0];

            }
            string vardateFrom = dd + "/" + mm + "/" + temp1[0];
            txtActiveFrom.Text = vardateFrom;


            string[] tempdate1 = objContract.Activeto.ToString().Split(("/").ToCharArray());
            string StrData1 = tempdate1[2].ToString();
            string[] temp2 = StrData1.Split((" ").ToCharArray());

            if (Convert.ToInt32(tempdate1[1]) < 10)
            {
                dd = "0" + tempdate1[1];
            }
            else
            {
                dd = tempdate1[1];

            }
            if (Convert.ToInt32(tempdate1[0]) < 10)
            {
                mm = "0" + tempdate1[0];
            }
            else
            {
                mm = tempdate1[0];

            }
            string vardateTo = dd + "/" + mm + "/" + temp2[0];


            txtActiveTo.Text = vardateTo;
            drpVendor.SelectedValue = Convert.ToString(objContract.Vendorid);

            colContractToAssetMapping = objContractToAsset.Get_All_By_contractid(objContract.Contractid);
            foreach (ContractToAssetMapping obj in colContractToAssetMapping)
            {
                Asset_mst objA = new Asset_mst();
                objA = objA.Get_By_id(obj.Assetid);
                colAsset.Add(objA);
            }
            ListAsset.DataTextField = "computername";
            ListAsset.DataValueField = "Assetid";
            ListAsset.DataSource = colAsset;
            ListAsset.DataBind();
        }

        objContractNotfy = objContractNotfy.Get_By_id(contractid);
        if (objContractNotfy.Contractid != 0)
        {
            EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
            chkLevel1.Checked = true;
            txtBeforeDays.Text = objContractNotfy.Beforedays.ToString();
            string varEmail = objContractNotfy.Sentto;
            string[] arrEmail = varEmail.Split((",").ToCharArray());
            for (int i = 0; i < arrEmail.Length - 1; i++)
            {
                if (arrEmail[i] != "," && arrEmail[i] != " ")
                {
                    objEscalateEmail = objEscalateEmail.Get_By_Emailid(arrEmail[i]);
                    for (int j = listLevel1.Items.Count - 1; j >= 0; j--)
                    {
                        if (Convert.ToInt32(listLevel1.Items[j].Value) == objEscalateEmail.Id)
                        {
                            listLevel1.Items[j].Selected = true;
                        }
                    }

                }


            }


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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardateFrom;
            string vardateTo;
            string varemail = "";
            int contractid = Convert.ToInt32(Request.QueryString[0]);
            objContract.Contractname = txtContractName.Text;
            objContract.Contractid = contractid;
            string[] tempdate = txtActiveFrom.Text.ToString().Split(("/").ToCharArray());
            vardateFrom = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];

            objContract.Activefrom = vardateFrom;

            string[] tempdate1 = txtActiveTo.Text.ToString().Split(("/").ToCharArray());
            vardateTo = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
            objContract.Activeto = vardateTo;
            objContract.Description = txtdesc.Text;
            objContract.Vendorid = Convert.ToInt32(drpVendor.SelectedValue);
            objContract.Update();
            objContractToAsset.Delete(contractid);
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
                objContractNotfy.Update();
                Response.Redirect("../Contract/DisplayAllContract.aspx");

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
        int contractid = Convert.ToInt32(Request.QueryString[0]);
        Asset_mst ObjAsset = new Asset_mst();
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        string varAsset = Session["AssetContract"].ToString();
        string[] arrAsset = varAsset.Split(',');
        int FlagCount = arrAsset.Length;
        for (int i = 0; i < FlagCount; i++)
        {
            if (arrAsset[i] != "," && arrAsset[i] != "")
            {
                ContractToAssetMapping objCoAsset = new ContractToAssetMapping();
                ListItem item = new ListItem();
                int flagcount;
                Asset_mst obj = new Asset_mst();
                obj = ObjAsset.Get_By_id(Convert.ToInt32(arrAsset[i].ToString()));
                flagcount = objCoAsset.Get_by_Contractid_Assetid(contractid, Convert.ToInt32(arrAsset[i].ToString()));
                if (flagcount == 0)
                {
                    item.Text = obj.Computername;
                    item.Value = Convert.ToString(obj.Assetid);
                    ListAsset.Items.Add(item);

                }
            }

        }


    }
    protected void lnkAddVendor_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
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
    protected void btnCancel_Click(object sender, EventArgs e)
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
