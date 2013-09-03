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

public partial class CMDB_EditCI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindDropCategory();
                ShowCI();
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
    BLLCollection<ConfigurableItems_mst> col = new BLLCollection<ConfigurableItems_mst>();
    ConfigurableItems_mst Objconfigurableitem = new ConfigurableItems_mst();
    Category_mst objCategory = new Category_mst();

    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();

    protected void ShowCI()
    {
        panaledit.Visible = false;
        panelshow.Visible = true;
        int itemid = Convert.ToInt32(Request.QueryString[0]);

        Objconfigurableitem = Objconfigurableitem.Get_By_id(itemid);

        drpitem.SelectedValue = itemid.ToString();
        txtparam1.Text = Objconfigurableitem.Param1.ToString();
        txtparam2.Text = Objconfigurableitem.Param2.ToString();
        txtparam3.Text = Objconfigurableitem.Param3.ToString();
        txtparam4.Text = Objconfigurableitem.Param4.ToString();
        txtparam5.Text = Objconfigurableitem.Param5.ToString();
        txtparam6.Text = Objconfigurableitem.Param6.ToString();
        txtparam7.Text = Objconfigurableitem.Param7.ToString();
        txtparam8.Text = Objconfigurableitem.Param8.ToString();
        txtparam9.Text = Objconfigurableitem.Param9.ToString();
        txtparam10.Text = Objconfigurableitem.Param10.ToString();
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
    protected void ShoweditCI()
    {
        //BindDropCategory();
        int itemid = Convert.ToInt32(Request.QueryString[0]);

        Objconfigurableitem = Objconfigurableitem.Get_By_id(itemid);

        drpedititem.SelectedValue = itemid.ToString();
        txteditparam1.Text = Objconfigurableitem.Param1.ToString();
        txteditparam2.Text = Objconfigurableitem.Param2.ToString();
        txteditparam3.Text = Objconfigurableitem.Param3.ToString();
        txteditparam4.Text = Objconfigurableitem.Param4.ToString();
        txteditparam5.Text = Objconfigurableitem.Param5.ToString();
        txteditparam6.Text = Objconfigurableitem.Param6.ToString();
        txteditparam7.Text = Objconfigurableitem.Param7.ToString();
        txteditparam8.Text = Objconfigurableitem.Param8.ToString();
        txteditparam9.Text = Objconfigurableitem.Param9.ToString();
        txteditparam10.Text = Objconfigurableitem.Param10.ToString();

    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindDropCategory1();
            panaledit.Visible = true;
            panelshow.Visible = false;
            btnupdate.Visible = true;
            btncancell.Visible = true;
            ShoweditCI();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btncancell_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            BindDropCategory();
            panaledit.Visible = false;
            panelshow.Visible = true;
            btnupdate.Visible = false;
            btncancell.Visible = false;
            ShowCI();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            btnupdate.Visible = false;
            btncancell.Visible = false;
            int itemid = Convert.ToInt32(Request.QueryString[0]);
            Objconfigurableitem.Itemid = itemid;
            Objconfigurableitem.Param1 = txteditparam1.Text;
            Objconfigurableitem.Param2 = txteditparam2.Text;
            Objconfigurableitem.Param3 = txteditparam3.Text;
            Objconfigurableitem.Param4 = txteditparam4.Text;
            Objconfigurableitem.Param5 = txteditparam5.Text;
            Objconfigurableitem.Param6 = txteditparam6.Text;
            Objconfigurableitem.Param7 = txteditparam7.Text;
            Objconfigurableitem.Param8 = txteditparam8.Text;
            Objconfigurableitem.Param9 = txteditparam9.Text;
            Objconfigurableitem.Param10 = txteditparam10.Text;
            Objconfigurableitem.Param12 = "";
            Objconfigurableitem.Param13 = "";
            Objconfigurableitem.Param14 = "";
            Objconfigurableitem.Param15 = "";

            Objconfigurableitem.Param11 = "";
            Objconfigurableitem.Update();
            ShowCI();
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
    protected void BindDropCategory1()
    {
        colCategory = objCategory.Get_All();
        drpedititem.DataTextField = "categoryname";
        drpedititem.DataValueField = "categoryid";
        drpedititem.DataSource = colCategory;
        drpedititem.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Item------";
        item.Value = "0";
        drpedititem.Items.Add(item);
        drpedititem.SelectedValue = "0";


    }




    #endregion

}
