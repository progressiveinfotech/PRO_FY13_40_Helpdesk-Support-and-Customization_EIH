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

public partial class Change_AddServiceProduct : System.Web.UI.Page
{

    TextBox txtparam1 = new TextBox();
    Label lblparam1 = new Label();
    TextBox txtparam2 = new TextBox();
    Label lblparam2 = new Label();
    TextBox txtparam3 = new TextBox();
    Label lblparam3 = new Label();
    TextBox txtparam4 = new TextBox();
    Label lblparam4 = new Label();
    TextBox txtparam5 = new TextBox();
    Label lblparam5 = new Label();

    TextBox txtparam6 = new TextBox();
    Label lblparam6 = new Label();
    TextBox txtparam7 = new TextBox();
    Label lblparam7 = new Label();
    TextBox txtparam8 = new TextBox();
    Label lblparam8 = new Label();
    TextBox txtparam9 = new TextBox();
    Label lblparam9 = new Label();
    TextBox txtparam10 = new TextBox();
    Label lblparam10 = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {


            int hdwidth = 300;
            int height = 5;
            Table tbl = new Table();

            txtparam1.ID = "txtparam1Id";
            txtparam1.Width = 165;
            txtparam1.Visible = false;
            TableRow tabRow = new TableRow();
            TableCell tbCell = new TableCell();
            TableCell tbCell1 = new TableCell();
            tbCell.Width = hdwidth / 2;
            tbCell1.Width = hdwidth / 2;
            tbCell.Controls.Add(lblparam1);
            tbCell1.Controls.Add(txtparam1);
            tabRow.Cells.Add(tbCell);
            tabRow.Cells.Add(tbCell1);
            tbl.Rows.Add(tabRow);


            txtparam2.ID = "txtparam2Id";
            txtparam2.Width = 165;
            txtparam2.Visible = false;
            TableRow tabRow2 = new TableRow();
            TableCell tbCell2 = new TableCell();
            TableCell tbCell21 = new TableCell();
            tbCell2.Width = hdwidth / 2;
            tbCell21.Width = hdwidth / 2;
            tbCell2.Controls.Add(lblparam2);
            tbCell21.Controls.Add(txtparam2);
            tabRow2.Cells.Add(tbCell2);
            tabRow2.Cells.Add(tbCell21);
            tbl.Rows.Add(tabRow2);


            txtparam3.ID = "txtparam3Id";
            txtparam3.Width = 165;
            txtparam3.Visible = false;
            TableRow tabRow3 = new TableRow();
            TableCell tbCell3 = new TableCell();
            TableCell tbCell31 = new TableCell();
            tbCell3.Width = hdwidth / 2;
            tbCell31.Width = hdwidth / 2;
            tbCell3.Controls.Add(lblparam3);
            tbCell31.Controls.Add(txtparam3);
            tabRow3.Cells.Add(tbCell3);
            tabRow3.Cells.Add(tbCell31);
            tbl.Rows.Add(tabRow3);

            txtparam4.ID = "txtparam4Id";
            txtparam4.Width = 165;
            txtparam4.Visible = false;
            TableRow tabRow4 = new TableRow();
            TableCell tbCell4 = new TableCell();
            TableCell tbCell41 = new TableCell();
            tbCell4.Width = hdwidth / 2;
            tbCell41.Width = hdwidth / 2;
            tbCell4.Controls.Add(lblparam4);
            tbCell41.Controls.Add(txtparam4);
            tabRow4.Cells.Add(tbCell4);
            tabRow4.Cells.Add(tbCell41);
            tbl.Rows.Add(tabRow4);


            txtparam5.ID = "txtparam5Id";
            txtparam5.Width = 165;
            txtparam5.Visible = false;
            TableRow tabRow5 = new TableRow();
            TableCell tbCell5 = new TableCell();
            TableCell tbCell51 = new TableCell();
            tbCell5.Width = hdwidth / 2;
            tbCell51.Width = hdwidth / 2;
            tbCell5.Controls.Add(lblparam5);
            tbCell51.Controls.Add(txtparam5);
            tabRow5.Cells.Add(tbCell5);
            tabRow5.Cells.Add(tbCell51);
            tbl.Rows.Add(tabRow5);

            txtparam6.ID = "txtparam6Id";
            txtparam6.Width = 165;
            txtparam6.Visible = false;
            TableRow tabRow6 = new TableRow();
            TableCell tbCell6 = new TableCell();
            TableCell tbCell61 = new TableCell();
            tbCell6.Width = hdwidth / 2;
            tbCell61.Width = hdwidth / 2;
            tbCell6.Controls.Add(lblparam6);
            tbCell61.Controls.Add(txtparam6);
            tabRow6.Cells.Add(tbCell6);
            tabRow6.Cells.Add(tbCell61);
            tbl.Rows.Add(tabRow6);

            txtparam7.ID = "txtparam7Id";
            txtparam7.Width = 165;
            txtparam7.Visible = false;
            TableRow tabRow7 = new TableRow();
            TableCell tbCell7 = new TableCell();
            TableCell tbCell71 = new TableCell();
            tbCell7.Width = hdwidth / 2;
            tbCell71.Width = hdwidth / 2;
            tbCell7.Controls.Add(lblparam7);
            tbCell71.Controls.Add(txtparam7);
            tabRow7.Cells.Add(tbCell7);
            tabRow7.Cells.Add(tbCell71);
            tbl.Rows.Add(tabRow7);

            txtparam8.ID = "txtparam8Id";
            txtparam8.Width = 165;
            txtparam8.Visible = false;
            TableRow tabRow8 = new TableRow();
            TableCell tbCell8 = new TableCell();
            TableCell tbCell81 = new TableCell();
            tbCell8.Width = hdwidth / 2;
            tbCell81.Width = hdwidth / 2;
            tbCell8.Controls.Add(lblparam8);
            tbCell81.Controls.Add(txtparam8);
            tabRow8.Cells.Add(tbCell8);
            tabRow8.Cells.Add(tbCell81);
            tbl.Rows.Add(tabRow8);

            txtparam9.ID = "txtparam9Id";
            txtparam9.Width = 165;
            txtparam9.Visible = false;
            TableRow tabRow9 = new TableRow();
            TableCell tbCell9 = new TableCell();
            TableCell tbCell91 = new TableCell();
            tbCell9.Width = hdwidth / 2;
            tbCell91.Width = hdwidth / 2;
            tbCell9.Controls.Add(lblparam9);
            tbCell91.Controls.Add(txtparam9);
            tabRow9.Cells.Add(tbCell9);
            tabRow9.Cells.Add(tbCell91);
            tbl.Rows.Add(tabRow9);

            txtparam10.ID = "txtparam10Id";
            txtparam10.Width = 165;
            txtparam10.Visible = false;
            TableRow tabRow10 = new TableRow();
            TableCell tbCell10 = new TableCell();
            TableCell tbCell101 = new TableCell();
            tbCell10.Width = hdwidth / 2;
            tbCell101.Width = hdwidth / 2;
            tbCell10.Controls.Add(lblparam10);
            tbCell101.Controls.Add(txtparam10);
            tabRow10.Cells.Add(tbCell10);
            tabRow10.Cells.Add(tbCell101);
            tbl.Rows.Add(tabRow10);





            PlaceHolderParams.Controls.Add(tbl);

            #region Declaration of Dynamic Table,and Placeholder





            #endregion

            if (!IsPostBack)
            {
                BindDropCategory();
                BindDropCustomer();
                BindDropDown();
                BindVendor();
                BindDropPriority();
                reqValsite.ErrorMessage = Resources.MessageResource.errSelectSite.ToString();
                reqvalvendor.ErrorMessage = Resources.MessageResource.errVendorname.ToString();
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
    ConfigurableItems_mst ObjConfigurableitem = new ConfigurableItems_mst();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    Category_mst objCategory = new Category_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    Site_mst objSite = new Site_mst();
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    Priority_mst objPriority = new Priority_mst();
    Configuration_mst ObjConfigurationmst = new Configuration_mst();
    CMDB objcmdb = new CMDB();


    protected void BindDropPriority()
    {
        colPriority = objPriority.Get_All();
        drpPriority.DataTextField = "name";
        drpPriority.DataValueField = "priorityid";
        drpPriority.DataSource = colPriority;
        drpPriority.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------------Select-------------";
        item.Value = "0";
        drpPriority.Items.Add(item);
        drpPriority.SelectedValue = "0";




    }
    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";


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

    protected void BindDropDown()
    {
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid;
        custid = Convert.ToInt32(drpCustomer.SelectedValue);

        colSite = objSite.Get_All();
        foreach (Site_mst obj in colSite)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colSite1.Add(obj);

            }
        }
        drpSites.DataTextField = "sitename";
        drpSites.DataValueField = "siteid";
        drpSites.DataSource = colSite1;
        drpSites.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select-------------";
        item.Value = "0";
        drpSites.Items.Add(item);
        drpSites.SelectedValue = "0";
        //btnReset_Click();

    }
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindDropDown();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }


    protected void drpitem_SelectedIndexChanged(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            pan2.Visible = true;

            int itemid = Convert.ToInt32(drpitem.SelectedValue);
            ObjConfigurableitem = ObjConfigurableitem.Get_By_id(itemid);
            if (ObjConfigurableitem.Param1 != "")
            {
                txtparam1.Visible = true;
                lblparam1.Text = ObjConfigurableitem.Param1.ToString();



            }
            if (ObjConfigurableitem.Param2 != "")
            {
                txtparam2.Visible = true;
                lblparam2.Text = ObjConfigurableitem.Param2.ToString();



            }

            if (ObjConfigurableitem.Param3 != "")
            {
                txtparam3.Visible = true;
                lblparam3.Text = ObjConfigurableitem.Param3.ToString();



            }

            if (ObjConfigurableitem.Param4 != "")
            {
                txtparam4.Visible = true;
                lblparam4.Text = ObjConfigurableitem.Param4.ToString();

            }

            if (ObjConfigurableitem.Param5 != "")
            {
                txtparam5.Visible = true;
                lblparam5.Text = ObjConfigurableitem.Param5.ToString();

            }

            if (ObjConfigurableitem.Param6 != "")
            {
                txtparam6.Visible = true;
                lblparam6.Text = ObjConfigurableitem.Param6.ToString();

            }
            if (ObjConfigurableitem.Param7 != "")
            {
                txtparam7.Visible = true;
                lblparam7.Text = ObjConfigurableitem.Param7.ToString();

            }

            if (ObjConfigurableitem.Param8 != "")
            {
                txtparam8.Visible = true;
                lblparam8.Text = ObjConfigurableitem.Param8.ToString();

            }

            if (ObjConfigurableitem.Param9 != "")
            {
                txtparam9.Visible = true;
                lblparam9.Text = ObjConfigurableitem.Param9.ToString();

            }
            if (ObjConfigurableitem.Param10 != "")
            {
                txtparam10.Visible = true;
                lblparam10.Text = ObjConfigurableitem.Param10.ToString();

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
    protected void btnsave_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int site = Convert.ToInt32(drpSites.SelectedValue);

            // string val =txtparam1.Text;
            // TextBox text = .FindControl("text" + i.ToString()) as TextBox; 
            TextBox txtp1 = (TextBox)PlaceHolderParams.FindControl("txtparam1Id");
            TextBox txtp2 = (TextBox)PlaceHolderParams.FindControl("txtparam2Id");
            TextBox txtp3 = (TextBox)PlaceHolderParams.FindControl("txtparam3Id");
            TextBox txtp4 = (TextBox)PlaceHolderParams.FindControl("txtparam4Id");
            TextBox txtp5 = (TextBox)PlaceHolderParams.FindControl("txtparam5Id");
            TextBox txtp6 = (TextBox)PlaceHolderParams.FindControl("txtparam6Id");
            TextBox txtp7 = (TextBox)PlaceHolderParams.FindControl("txtparam7Id");
            TextBox txtp8 = (TextBox)PlaceHolderParams.FindControl("txtparam8Id");
            TextBox txtp9 = (TextBox)PlaceHolderParams.FindControl("txtparam9Id");
            TextBox txtp10 = (TextBox)PlaceHolderParams.FindControl("txtparam10Id");

            // Response.Write(test.Text);
            //string abc = txtparam1.Text;
            int itemid1 = Convert.ToInt32(drpitem.SelectedValue);
            string vardate2 = "";
            string vardate;
            int vendorid = Convert.ToInt32(drpVendor.SelectedValue);
            int siteid = Convert.ToInt32(drpSites.SelectedValue);
            string severity = drpPriority.SelectedValue;
            string serilo = txtitemsrlno.Text.ToString();
            ObjConfigurationmst.Itemid = itemid1;
            ObjConfigurationmst.Serialno = serilo;
            ObjConfigurationmst.Siteid = siteid;
            ObjConfigurationmst.Severity = severity;
            ObjConfigurationmst.Vendorid = vendorid;
            DateTime Date = new DateTime();
            string[] tempdate = txtpdate.Text.ToString().Split(("/").ToCharArray());
            vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            vardate2 = vardate;
            //Date = Convert.ToDateTime(vardate2);
            ObjConfigurationmst.Purchasedate = vardate2.ToString();
            ObjConfigurationmst.Insert();
            int Assetid = ObjConfigurationmst.Get_Current_Assetid();
            int itemid = Convert.ToInt32(drpitem.SelectedValue);
            ObjConfigurableitem = ObjConfigurableitem.Get_By_id(itemid);
            objcmdb.Assetid = Assetid;
            if (ObjConfigurableitem.Param1 != "")
            {
                objcmdb.Param1 = txtp1.Text.ToString();

            }
            else
            {
                objcmdb.Param1 = "";
            }

            if (ObjConfigurableitem.Param2 != "")
            {
                objcmdb.Param2 = txtp2.Text.ToString();

            }
            else
            {
                objcmdb.Param2 = "";
            }

            if (ObjConfigurableitem.Param3 != "")
            {
                objcmdb.Param3 = txtp3.Text.ToString();

            }
            else
            {
                objcmdb.Param3 = "";
            }
            if (ObjConfigurableitem.Param4 != "")
            {
                objcmdb.Param4 = txtp4.Text.ToString();

            }
            else
            {
                objcmdb.Param4 = "";
            }
            if (ObjConfigurableitem.Param5 != "")
            {
                objcmdb.Param5 = txtp5.Text.ToString();

            }
            else
            {
                objcmdb.Param5 = "";
            }

            if (ObjConfigurableitem.Param6 != "")
            {
                objcmdb.Param6 = txtp6.Text.ToString();

            }
            else
            {
                objcmdb.Param6 = "";
            }
            if (ObjConfigurableitem.Param7 != "")
            {
                objcmdb.Param7 = txtp7.Text.ToString();

            }
            else
            {
                objcmdb.Param7 = "";
            }
            if (ObjConfigurableitem.Param8 != "")
            {
                objcmdb.Param8 = txtp8.Text.ToString();

            }
            else
            {
                objcmdb.Param8 = "";
            }
            if (ObjConfigurableitem.Param9 != "")
            {
                objcmdb.Param9 = txtp9.Text.ToString();

            }
            else
            {
                objcmdb.Param9 = "";
            }
            if (ObjConfigurableitem.Param10 != "")
            {
                objcmdb.Param10 = txtp10.Text.ToString();

            }
            else
            {
                objcmdb.Param10 = "";
            }
            objcmdb.Param11 = "";
            objcmdb.Param12 = "";
            objcmdb.Param13 = "";
            objcmdb.Param14 = "";
            objcmdb.Param15 = "";
            objcmdb.Insert();
            lblmsg.Visible = true;
            lblmsg.Text = "Service Product Added Successfully";
            drpCustomer.SelectedValue = "0";
            drpSites.SelectedValue = "0";
            drpVendor.SelectedValue = "0";
            drpPriority.SelectedValue = "0";
            drpitem.SelectedValue = "0";
            txtpdate.Text = "";
            txtparam1.Visible = false;
            lblparam1.Visible = false;
            txtparam2.Visible = false;
            lblparam2.Visible = false;
            txtparam3.Visible = false;
            lblparam3.Visible = false;
            txtparam4.Visible = false;
            lblparam4.Visible = false;
            txtparam5.Visible = false;
            lblparam5.Visible = false;

            txtparam6.Visible = false;
            lblparam6.Visible = false;
            txtparam7.Visible = false;
            lblparam7.Visible = false;
            txtparam8.Visible = false;
            lblparam8.Visible = false;
            txtparam9.Visible = false;
            lblparam9.Visible = false;
            txtparam10.Visible = false;
            lblparam10.Visible = false;
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
