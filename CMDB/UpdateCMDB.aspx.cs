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
using Microsoft.Reporting.WebForms;
public partial class CMDB_UpdateCMDB : System.Web.UI.Page
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
    {///Add Exception handilng try catch change by vishal 21-05-2012
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
            if (!IsPostBack)
            {
                showCMDBValues();
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
    Configuration_mst ObjConfiguration = new Configuration_mst();
    CMDB ObjCMDB = new CMDB();
    ConfigurableItems_mst ObjConfigurableitem = new ConfigurableItems_mst();
    Incident_To_Change ObjIncidentochange = new Incident_To_Change();
    Change_mst Objchange = new Change_mst();
    Category_mst Objcategory = new Category_mst();
    Subcategory_mst Objsubcategory = new Subcategory_mst();
    Vendor_mst Objvendor = new Vendor_mst();
    ChangeType_mst Objchangetype = new ChangeType_mst();
    CMDB_trans Objcmdbtrans = new CMDB_trans();
    IncludedAssetinchange Objincludeasset = new IncludedAssetinchange();
    protected void showCMDBValues()
    {

        panalupdatecmdb.Visible = true;
       
        int Incidentidforchange = Convert.ToInt32(Session["Incidentidforchange"]);
        ObjIncidentochange = ObjIncidentochange.Get_By_Incidentid(Incidentidforchange);
        int changeid = Convert.ToInt32(ObjIncidentochange.Changeid);
        Objincludeasset = Objincludeasset.Get_By_Changeid(changeid);
        int Assetid = Convert.ToInt32(Objincludeasset.Assetid);
        ObjConfiguration = ObjConfiguration.Get_By_id(Assetid);

        int itemid = Convert.ToInt32(ObjConfiguration.Itemid);
        ObjConfigurableitem = ObjConfigurableitem.Get_By_id(itemid);
        ObjCMDB = ObjCMDB.Get_By_id(Assetid);
        Objchange = Objchange.Get_By_id(changeid);
        int categoryid = Convert.ToInt32(Objchange.Categoryid);
        Objcategory = Objcategory.Get_By_id(categoryid);
        if (categoryid != 0)
        {
            lblcategory.Text = Objcategory.CategoryName.ToString();
        }

        int Subcategoryid = Convert.ToInt32(Objchange.Subcategoryid);
        Objsubcategory = Objsubcategory.Get_By_id(Subcategoryid);
        if (Subcategoryid != 0)
        {
            lblsubcategory.Text = Objsubcategory.Subcategoryname.ToString();
        }

        lblassetid.Text = ObjConfiguration.Assetid.ToString();
        int itemid1 = Convert.ToInt32(ObjConfiguration.Itemid);
        Objcategory = Objcategory.Get_By_id(itemid1);
        lblitemname.Text = Objcategory.CategoryName.ToString();
        Objvendor = Objvendor.Get_By_id(ObjConfiguration.Vendorid);
        lblvendor.Text = Objvendor.Vendorname.ToString();
        lblchangeid.Text = Objchange.Changeid.ToString();
        lblserialno.Text = ObjConfiguration.Serialno.ToString();
        int changetypid = Convert.ToInt32(Objchange.Changetype);
        Objchangetype = Objchangetype.Get_By_id(changetypid);
        lblchangetype.Text = Objchangetype.Changetypename.ToString();
        lbltitle.Text = Objchange.Title.ToString();
        if (ObjConfigurableitem.Param1 != "")
        {
            txtparam1.Visible = true;
            lblparam1.Text = ObjConfigurableitem.Param1.ToString();
            txtparam1.Text = ObjCMDB.Param1.ToString();



        }
        if (ObjConfigurableitem.Param2 != "")
        {
            txtparam2.Visible = true;
            lblparam2.Text = ObjConfigurableitem.Param2.ToString();
            txtparam2.Text = ObjCMDB.Param2.ToString();


        }

        if (ObjConfigurableitem.Param3 != "")
        {
            txtparam3.Visible = true;
            lblparam3.Text = ObjConfigurableitem.Param3.ToString();
            txtparam3.Text = ObjCMDB.Param3.ToString();


        }

        if (ObjConfigurableitem.Param4 != "")
        {
            txtparam4.Visible = true;
            lblparam4.Text = ObjConfigurableitem.Param4.ToString();
            txtparam4.Text = ObjCMDB.Param4.ToString();
        }

        if (ObjConfigurableitem.Param5 != "")
        {
            txtparam5.Visible = true;
            lblparam5.Text = ObjConfigurableitem.Param5.ToString();
            txtparam5.Text = ObjCMDB.Param5.ToString();
        }

        if (ObjConfigurableitem.Param6 != "")
        {
            txtparam6.Visible = true;
            lblparam6.Text = ObjConfigurableitem.Param6.ToString();
            txtparam6.Text = ObjCMDB.Param6.ToString();
        }
        if (ObjConfigurableitem.Param7 != "")
        {
            txtparam7.Visible = true;
            lblparam7.Text = ObjConfigurableitem.Param7.ToString();
            txtparam7.Text = ObjCMDB.Param7.ToString();
        }

        if (ObjConfigurableitem.Param8 != "")
        {
            txtparam8.Visible = true;
            lblparam8.Text = ObjConfigurableitem.Param8.ToString();
            txtparam8.Text = ObjCMDB.Param8.ToString();
        }

        if (ObjConfigurableitem.Param9 != "")
        {
            txtparam9.Visible = true;
            lblparam9.Text = ObjConfigurableitem.Param9.ToString();
            txtparam9.Text = ObjCMDB.Param9.ToString();
        }
        if (ObjConfigurableitem.Param10 != "")
        {
            txtparam10.Visible = true;
            lblparam10.Text = ObjConfigurableitem.Param10.ToString();
            txtparam10.Text = ObjCMDB.Param10.ToString();
        }



    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
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
            int Incidentidforchange = Convert.ToInt32(Session["Incidentidforchange"]);
            ObjIncidentochange = ObjIncidentochange.Get_By_Incidentid(Incidentidforchange);
            int changeid = Convert.ToInt32(ObjIncidentochange.Changeid);
            Objincludeasset = Objincludeasset.Get_By_Changeid(changeid);
            int Assetid = Convert.ToInt32(Objincludeasset.Assetid);
            ObjConfiguration = ObjConfiguration.Get_By_id(Assetid);

            int itemid = Convert.ToInt32(ObjConfiguration.Itemid);
            ObjConfigurableitem = ObjConfigurableitem.Get_By_id(itemid);
            ObjCMDB = ObjCMDB.Get_By_id(Assetid);
            //ObjCMDB.Assetid = ObjConfiguration.Assetid;
            CMDB objcmdb = new CMDB();
            objcmdb.Assetid = ObjConfiguration.Assetid;
            if (ObjConfigurableitem.Param1 != "")
            {

                if (txtp1.Text == ObjCMDB.Param1)
                {
                    objcmdb.Param1 = txtp1.Text.ToString();
                }
                else
                {
                    objcmdb.Param1 = txtp1.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp1.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param1;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param1;
                    Objcmdbtrans.Insert();
                }

            }
            else
            {
                objcmdb.Param1 = ObjCMDB.Param1;
            }

            if (ObjConfigurableitem.Param2 != "")
            {


                if (txtp2.Text == ObjCMDB.Param2)
                {
                    objcmdb.Param2 = txtp2.Text.ToString();
                }
                else
                {
                    objcmdb.Param2 = txtp2.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp2.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param2;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param2;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param2 = ObjCMDB.Param2;
            }

            if (ObjConfigurableitem.Param3 != "")
            {

                if (txtp3.Text == ObjCMDB.Param3)
                {
                    objcmdb.Param3 = txtp3.Text.ToString();
                }
                else
                {
                    objcmdb.Param3 = txtp3.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp3.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param3;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param3;
                    Objcmdbtrans.Insert();
                }

            }
            else
            {
                objcmdb.Param3 = ObjCMDB.Param3;
            }
            if (ObjConfigurableitem.Param4 != "")
            {

                if (txtp4.Text == ObjCMDB.Param4)
                {
                    objcmdb.Param4 = txtp4.Text.ToString();
                }
                else
                {
                    objcmdb.Param4 = txtp4.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp4.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param4;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param4;
                    Objcmdbtrans.Insert();
                }

            }
            else
            {
                objcmdb.Param4 = ObjCMDB.Param4;
            }
            if (ObjConfigurableitem.Param5 != "")
            {

                if (txtp5.Text == ObjCMDB.Param5)
                {
                    objcmdb.Param5 = txtp5.Text.ToString();
                }
                else
                {
                    objcmdb.Param5 = txtp5.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp5.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param5;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param5;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param5 = ObjCMDB.Param5;
            }

            if (ObjConfigurableitem.Param6 != "")
            {

                if (txtp6.Text == ObjCMDB.Param6)
                {
                    objcmdb.Param6 = txtp6.Text.ToString();
                }
                else
                {
                    objcmdb.Param6 = txtp6.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp6.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param6;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param6;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param6 = ObjCMDB.Param6;
            }
            if (ObjConfigurableitem.Param7 != "")
            {

                if (txtp7.Text == ObjCMDB.Param7)
                {
                    objcmdb.Param7 = txtp7.Text.ToString();
                }
                else
                {
                    objcmdb.Param7 = txtp7.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp7.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param7;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param7;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param7 = ObjCMDB.Param7;
            }
            if (ObjConfigurableitem.Param8 != "")
            {

                if (txtp8.Text == ObjCMDB.Param8)
                {
                    objcmdb.Param8 = txtp8.Text.ToString();
                }
                else
                {
                    objcmdb.Param8 = txtp8.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp8.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param8;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param8;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param8 = ObjCMDB.Param8;
            }
            if (ObjConfigurableitem.Param9 != "")
            {

                if (txtp8.Text == ObjCMDB.Param9)
                {
                    objcmdb.Param9 = txtp9.Text.ToString();
                }
                else
                {
                    objcmdb.Param9 = txtp9.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp9.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param9;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param9;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param9 = ObjCMDB.Param9;
            }
            if (ObjConfigurableitem.Param10 != "")
            {

                if (txtp10.Text == ObjCMDB.Param10)
                {
                    objcmdb.Param10 = txtp10.Text.ToString();
                }
                else
                {
                    objcmdb.Param10 = txtp10.Text.ToString();
                    Objcmdbtrans.Currentvalue = txtp10.Text.ToString();
                    Objcmdbtrans.Previousvalue = ObjCMDB.Param10;
                    Objcmdbtrans.Assetid = ObjConfiguration.Assetid;
                    Objcmdbtrans.Parametername = ObjConfigurableitem.Param10;
                    Objcmdbtrans.Insert();
                }
            }
            else
            {
                objcmdb.Param10 = ObjCMDB.Param10;
            }

            objcmdb.Update();
            Configuration_mst obj = new Configuration_mst();
            obj.Assetid = ObjConfiguration.Assetid;
            obj.Vendorid = ObjConfiguration.Vendorid;
            obj.Itemid = ObjConfiguration.Itemid;
            obj.Serialno = ObjConfiguration.Serialno;
            int versionno = ObjConfiguration.Version;
            versionno = versionno + 1;
            obj.Version = versionno;
            obj.Siteid = ObjConfiguration.Siteid;
            obj.Severity = ObjConfiguration.Severity;
            obj.Purchasedate = ObjConfiguration.Purchasedate;
            obj.Update();

            Session["CMDBUpdate"] = "true";

             //string myScript;
             //myScript = "<script language=javascript>javascript:window.close();</script>";
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshParent();", "refreshParent();", true);

            //  Page.RegisterClientScriptBlock("MyScript", myScript);
            ////////////change done by meenakhsi
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshParent", "refreshParent()", true);
            //string myScript;
            //myScript = "<script language=javascript>javascript:window.close();</script>";

            //Page.RegisterClientScriptBlock("MyScript", myScript);
            
            ////////////end
            
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
