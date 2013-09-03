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
using System.Xml;
using System.IO;

public partial class Asset_ViewAssetDetails : System.Web.UI.Page
{
    #region Create Object and Define Global Variable
    Asset_mst objasset = new Asset_mst();
    BLLCollection<Asset_mst> colAssetmst = new BLLCollection<Asset_mst>();//added by Vishal on 16 may 2012
    UserToAssetMapping objusertoasset = new UserToAssetMapping(); //added by lalit on 24feb 2012
    BLLCollection<UserToAssetMapping> col = new BLLCollection<UserToAssetMapping>();//added by lalit on 24feb 2012
    Site_mst objsite = new Site_mst();
    Customer_mst objcust = new Customer_mst(); //added by lalit on 24feb 2012
    public int count_processors;
    public int count_network_adapters;
    public int flagProssCnt, flaglogdvCnt, flagnetworkCnt;
    public string[,] processors;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int flagStatus = 0;
            XmlDocument xmldoc = new XmlDocument();
            int temp = Convert.ToInt32(Session["temp"]);
            if (temp == 1)
            {
                string compname1 = (string)(Session["param_node"]);
                objasset = objasset.Get_Asset_By_Computername(compname1);

                int assetid = Convert.ToInt32(objasset.Assetid);
                lblAssetId.Text = assetid.ToString();
                string path = "C:\\Asset\\Data\\" + compname1 + ".xml";
                flagStatus = 1;
                String filestr = File.ReadAllText(path);
                xmldoc.LoadXml(filestr);
                //xmldoc.Load(path);
            }

            else
            {
                string compane = Request.QueryString[0];
                string assetid = (string)(Session["Assetid"]);
                lblAssetId.Text = assetid;

                DirectoryInfo di = new DirectoryInfo("C://Asset//Data");
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo K in fi)
                {
                    string[] fname = K.Name.Split(new char[] { '.' });

                    if (fname[0].ToString() == compane)
                    {
                        string path = "C:\\Asset\\Data\\" + compane + ".xml";
                        String filestr = File.ReadAllText(path);
                        xmldoc.LoadXml(filestr);
                        //  xmldoc.Load(path);
                        flagStatus = 1;

                    }


                }


            }
            if (flagStatus == 1)
            {
                #region Call Display Function
                DisplayComputerDetails(xmldoc);
                DisplayProcessorDetails(xmldoc);
                DisplayProductDetails(xmldoc);
                DisplayMemoryDetails(xmldoc);
                DisplayOSDetails(xmldoc);
                DisplayPhysicalDriveDetails(xmldoc);
                DisplayLogicalDriveDetails(xmldoc);
                DisplayNetworkDetails(xmldoc);
                DisplayMonitorDetails(xmldoc);
                #endregion
                visiblefun();
                pancomputer.Visible = true;
            }
            else
            {

                string myScript;
                myScript = "<script language=javascript>alert('Computer not found!, Ensure that computer is in the Domain and User Login to the Domain.'); </script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);
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
    #endregion

    #region ImageClickEvents
    protected void imgcomputer_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            pancomputer.Visible = true;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }


    }

    protected void imgproduct_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            if (count_processors > 1)
            {
                Panproduct.Visible = true;

            }
            else
            {
                PanHardware.Visible = true;
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

    protected void imgnetwork_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            visiblefun();
            if (count_network_adapters > 1)
            {
                Pannetwork1.Visible = true;
            }
            else
            {
                Pannetwork.Visible = true;
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
    protected void Imageoperatingsystem_Click(object sender, EventArgs e)
    {
        //visiblefun();
        //Panos.Visible = true;
    }
    protected void imgMultimedia_Click(object sender, EventArgs e)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            visiblefun();
            Panmultimedia.Visible = true;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }


    #endregion

    #region Panelsreset
    protected void visiblefun()
    {
        pancomputer.Visible = false;
        Panproduct.Visible = false;
        Pannetwork.Visible = false;
        Panos.Visible = false;
        PanHardware.Visible = false;
        Pannetwork1.Visible = false;
        ////Added by Vishal 17-05-2012
        Panmultimedia.Visible = false;
    }
    #endregion

    //protected string GetSiteId(int assetid)
    //{
    //    int siteid=objusertoasset.Get_SiteId_From_UserToAssetMap(assetid);
    //    objsite = objsite.Get_By_id(siteid);
    //    string sitename = objsite.Sitename;
    //    return sitename;
    //}

    #region Display function
    protected void DisplayComputerDetails(XmlDocument xmldoc)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode compname = xmldoc.DocumentElement.SelectSingleNode("//Computer//Computer_name");
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            XmlNode domain = xmldoc.DocumentElement.SelectSingleNode("//Computer//Domain");

            //added by lalit
            //XmlNode TagNo = xmldoc.DocumentElement.SelectSingleNode("//Computer//TagNo");
            //XmlNode PONo = xmldoc.DocumentElement.SelectSingleNode("//Computer//PONo");
            //XmlNode AssetOwner = xmldoc.DocumentElement.SelectSingleNode("//Computer//AssetOwner");
            //XmlNode IsInStock = xmldoc.DocumentElement.SelectSingleNode("//Computer//IsInStock");
            //end

            ///add by Vishal 16-05-2012
            /////Get_AssetGet_By_id
            objasset = objasset.Get_By_id(Convert.ToInt32(lblAssetId.Text));
            string strTagNo = objasset.TagNo;
            string strPoNo = objasset.PONo;
            string strAssetOwner = objasset.AssetOwner;
            ///end///
            ///change done by meenakshi
            //string strCompanyCode = objasset.CompanyCode;
            //string strPurchaseDate = objasset.PurchaseDate;
            //string strAssetCategory = objasset.AssetCategory;
            //string strRemarks = objasset.Remarks;
            ///end///
            lblcomputername.Text = compname.InnerText;
            ///Comment by Vishal 17-05-2012
            // lblassetname.Text = compname.InnerText + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            lblassetname.Text = compname.InnerText + "";
            lblassetid1.Text = lblAssetId.Text;
            lblcreateddate.Text = inventory_date.InnerText;
            ///Comment by Vishal 17-05-2012
            //lbllastinventory.Text = inventory_date.InnerText + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            lbllastinventory.Text = inventory_date.InnerText + "";
            lbldomain.Text = domain.InnerText;
            //if (TagNo != null)
            //{
            //    LblTageno.Text = TagNo.InnerText;
            //}
            //if (PONo != null)
            //{
            //    LblPONo.Text = PONo.InnerText;
            //}
            //if (AssetOwner != null)
            //{
            //    LblAssetOwner.Text = AssetOwner.InnerText;
            //}

            //else if (AssetOwner == null)
            //{
            //    objusertoasset = objusertoasset.Get_By_id(objasset.Assetid);
            //    if(objusertoasset!=null)
            //    {
            //       LblAssetOwner.Text = objusertoasset.AssetCompanyName;
            //    }
            //}
            //if (IsInStock != null)
            //{
            //    lblStock.Text = IsInStock.InnerText;
            //}
            ///add by Vishal

            if (strTagNo != "")
            {
                LblTageno.Text = strTagNo;
            }
            if (strPoNo != "")
            {
                LblPONo.Text = strPoNo;
            }
            if (strAssetOwner != "")
            {
                LblAssetOwner.Text = strAssetOwner;
            }

            else if (strAssetOwner == "")
            {
                objusertoasset = objusertoasset.Get_By_id(objasset.Assetid);
                if (objusertoasset != null)
                {
                    LblAssetOwner.Text = objusertoasset.AssetCompanyName;
                }
            }
            ///
            //if (IsInStock != null)
            //{
            //    lblStock.Text = IsInStock.InnerText;
            //}
            objasset = objasset.Get_Asset_By_Computername(lblcomputername.Text);
            if (objusertoasset != null)
            {
                LblAssetLocation.Text = objusertoasset.AssetLocation;
            }
            //add by meenakshi 22 june
            /////////////////////////////////////
            //if (strCompanyCode != "")
            //{
            //    LblCompanyCode.Text = strCompanyCode;
            //}
            //if (strPurchaseDate != "")
            //{
            //    LblPurchaseDate.Text = strCompanyCode;
            //}
            //if (strAssetCategory != "")
            //{
            //    LblAssetCategory.Text = strCompanyCode;
            //}
            //if (strRemarks != "")
            //{
            //    LblRemarks.Text = strCompanyCode;
            //}//////////////////////////////
            
            //end


        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void DisplayProductDetails(XmlDocument xmldoc)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode product_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Name");
            XmlNode product_manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Manufacturer");
            XmlNode Serial_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Serial_number");
            XmlNode UUID = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//UUID");
            XmlNode SKU_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//SKU_number");
            if (count_processors > 1)
            {
                lblproduct.Text = product_name.InnerText;
                lblgenprodname.Text = product_name.InnerText;
                lblproductmanu.Text = product_manufacturer.InnerText;
                lblserialno.Text = Serial_number.InnerText;
                lblUuid.Text = UUID.InnerText;
                lblskuno.Text = SKU_number.InnerText;
            }
            else
            {
                lblgenprodname.Text = product_name.InnerText;
                lblproduct1.Text = product_name.InnerText;
                lblproductmanu1.Text = product_manufacturer.InnerText;
                lblserialno1.Text = Serial_number.InnerText;
                lblUuid1.Text = UUID.InnerText;
                lblskuno1.Text = SKU_number.InnerText;
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
    protected void DisplayProcessorDetails(XmlDocument xmldoc)
    {
        ////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNodeList nodes_processors = xmldoc.DocumentElement.SelectNodes("//Computer//Hardware//Processors//Processor");
            XmlNode Family = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Family");
            XmlNode Manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Manufacturer");
            XmlNode Max_speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Max_speed");
            XmlNode Model = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Model");
            XmlNode processors = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Processor");
            XmlNode Speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Speed");
            XmlNode Stepping = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Stepping");
            count_processors = nodes_processors.Count;
            if (count_processors > 1)
            {
                string[,] strArray = new string[count_processors, 20];
                XmlNode xn;
                for (int i = 0; i < count_processors; i++)
                {
                    xn = nodes_processors.Item(i);
                    strArray[i, 0] = xn["Name"].InnerText;
                    strArray[i, 1] = xn["Manufacturer"].InnerText;
                    strArray[i, 2] = xn["Speed"].InnerText;
                    strArray[i, 3] = xn["Family"].InnerText;
                    strArray[i, 4] = xn["Model"].InnerText;
                    strArray[i, 5] = xn["Stepping"].InnerText;
                    strArray[i, 6] = xn["L1_data_cache"].InnerText;
                    strArray[i, 7] = xn["L1_code_cache"].InnerText;
                    strArray[i, 8] = xn["L2_cache"].InnerText;
                    strArray[i, 9] = xn["Vendor_ID"].InnerText;
                    strArray[i, 10] = xn["Brand_ID"].InnerText;
                    strArray[i, 11] = xn["Serial_number"].InnerText;
                    strArray[i, 12] = xn["Socket_designation"].InnerText;
                    strArray[i, 13] = xn["Voltage"].InnerText;
                    strArray[i, 14] = xn["Type"].InnerText;
                    strArray[i, 15] = xn["External_clock"].InnerText;
                    strArray[i, 16] = xn["Max_speed"].InnerText;
                    strArray[i, 17] = xn["Upgrade"].InnerText;
                    flagProssCnt = flagProssCnt + 1;
                }
                Processor_PlaceHolder.Controls.Clear();
                phprocessor.Controls.Clear();
                int tblRows = count_processors;
                Table tbl = new Table();
                Table tbl1 = new Table();
                Processor_PlaceHolder.Controls.Add(tbl);
                phprocessor.Controls.Add(tbl1);
                #region Create Table and rows
                for (int i = 0; i < tblRows; i++)
                {
                    TableRow tr0 = new TableRow();
                    TableCell tc0 = new TableCell();
                    tc0.Width = 140;
                    TableCell tc00 = new TableCell();
                    tc00.Width = 200;
                    Label lbl0 = new Label();
                    Label lbl00 = new Label();
                    lbl0.Text = "Name";
                    //lbl0.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name";
                    lbl0.Font.Bold = true;
                    lbl00.Text = strArray[i, 0];
                    lbl00.Font.Bold = false;
                    tc0.Controls.Add(lbl0);
                    tc00.Controls.Add(lbl00);
                    tr0.Cells.Add(tc0);
                    tr0.Cells.Add(tc00);
                    tbl.Rows.Add(tr0);

                    TableRow tr1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc11 = new TableCell();
                    Label lbl1 = new Label();
                    Label lbl11 = new Label();
                    lbl1.Text = "Manufacturer:";
                    //lbl1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manufacturer:";
                    lbl1.Font.Bold = true;
                    lbl11.Text = strArray[i, 1];
                    lbl11.Font.Bold = false;
                    tc1.Controls.Add(lbl1);
                    tc11.Controls.Add(lbl11);
                    tr1.Cells.Add(tc1);
                    tr1.Cells.Add(tc11);
                    tbl.Rows.Add(tr1);

                    TableRow tr2 = new TableRow();
                    TableCell tc2 = new TableCell();
                    tc2.Width = 140;
                    TableCell tc22 = new TableCell();
                    tc22.Width = 200;
                    Label lbl2 = new Label();
                    Label lbl22 = new Label();
                    lbl2.Text = "Speed:";
                    //lbl2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speed:";
                    lbl2.Font.Bold = true;
                    lbl22.Text = strArray[i, 2] + " mHz";
                    lbl22.Font.Bold = false;
                    tc2.Controls.Add(lbl2);
                    tc22.Controls.Add(lbl22);
                    tr2.Cells.Add(tc2);
                    tr2.Cells.Add(tc22);
                    tbl.Rows.Add(tr2);


                    TableRow tr3 = new TableRow();
                    TableCell tc3 = new TableCell();
                    tc3.Width = 140;
                    TableCell tc33 = new TableCell();
                    tc33.Width = 200;
                    Label lbl3 = new Label();
                    Label lbl33 = new Label();
                    lbl3.Text = "Family:";
                    //lbl3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Family:";
                    lbl3.Font.Bold = true;
                    lbl33.Text = strArray[i, 3];
                    lbl33.Font.Bold = false;
                    tc3.Controls.Add(lbl3);
                    tc33.Controls.Add(lbl33);
                    tr3.Cells.Add(tc3);
                    tr3.Cells.Add(tc33);
                    tbl.Rows.Add(tr3);

                    TableRow tr4 = new TableRow();
                    TableCell tc4 = new TableCell();
                    tc4.Width = 140;
                    TableCell tc44 = new TableCell();
                    tc44.Width = 200;
                    Label lbl4 = new Label();
                    Label lbl44 = new Label();
                    lbl4.Text = "Model:";
                    //lbl4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model:";
                    lbl4.Font.Bold = true;
                    lbl44.Text = strArray[i, 4];
                    lbl44.Font.Bold = false;
                    tc4.Controls.Add(lbl4);
                    tc44.Controls.Add(lbl44);
                    tr4.Cells.Add(tc4);
                    tr4.Cells.Add(tc44);
                    tbl.Rows.Add(tr4);

                    TableRow tr5 = new TableRow();
                    TableCell tc5 = new TableCell();
                    tc5.Width = 140;
                    TableCell tc55 = new TableCell();
                    tc55.Width = 200;
                    Label lbl5 = new Label();
                    Label lbl55 = new Label();
                    lbl5.Text = "Stepping:";
                    //lbl5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stepping:";
                    lbl5.Font.Bold = true;
                    lbl55.Text = strArray[i, 5];
                    lbl55.Font.Bold = false;
                    tc5.Controls.Add(lbl5);
                    tc55.Controls.Add(lbl55);
                    tr5.Cells.Add(tc5);
                    tr5.Cells.Add(tc55);
                    tbl.Rows.Add(tr5);

                    TableRow tr6 = new TableRow();
                    TableCell tc6 = new TableCell();
                    tc6.Width = 140;
                    TableCell tc66 = new TableCell();
                    tc66.Width = 200;
                    Label lbl6 = new Label();
                    Label lbl66 = new Label();
                    lbl6.Text = "Max Speed:";
                    //lbl6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Max Speed:";
                    lbl6.Font.Bold = true;
                    lbl66.Text = strArray[i, 6];
                    lbl66.Font.Bold = false;
                    tc6.Controls.Add(lbl6);
                    tc66.Controls.Add(lbl66);
                    tr6.Cells.Add(tc6);
                    tr6.Cells.Add(tc66);
                    tbl.Rows.Add(tr6);
                    TableRow tr7 = new TableRow();
                    TableCell tc7 = new TableCell();
                    tr7.Cells.Add(tc7);
                    tbl.Rows.Add(tr7);
                    TableRow tr8 = new TableRow();
                    TableCell tc8 = new TableCell();
                    tr8.Cells.Add(tc8);
                    tbl.Rows.Add(tr8);
                }

                for (int i = 0; i < tblRows; i++)
                {
                    TableRow tr01 = new TableRow();
                    TableCell tc01 = new TableCell();
                    tc01.Width = 140;
                    TableCell tc001 = new TableCell();
                    tc001.Width = 500;
                    Label lbl01 = new Label();
                    Label lbl001 = new Label();
                    lbl01.Text = "Processor Name";
                    //lbl01.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processor Name";
                    lbl01.Font.Bold = true;
                    //lbl001.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + strArray[i, 0];
                    lbl001.Text = "" + strArray[i, 0];
                    lbl001.Font.Bold = true;
                    tc01.Controls.Add(lbl01);
                    tc001.Controls.Add(lbl001);
                    tr01.Cells.Add(tc01);
                    tr01.Cells.Add(tc001);
                    tbl1.Rows.Add(tr01);
                }
                #endregion


                XmlNodeList nodes_logical_drives = xmldoc.DocumentElement.SelectNodes("//Computer//Hardware//Logical_drives//Drive");
                int count_logical_drives = nodes_logical_drives.Count;
                string[,] strArray1 = new string[count_logical_drives, 15];
                for (int i = 0; i < count_logical_drives; i++)
                {
                    xn = nodes_logical_drives.Item(i);
                    strArray1[i, 0] = xn["Drive_letter"].InnerText;
                    strArray1[i, 1] = xn["Drive_type"].InnerText;
                    strArray1[i, 2] = xn["Total_bytes"].InnerText;
                    strArray1[i, 3] = xn["Free_bytes"].InnerText;
                    strArray1[i, 4] = xn["File_system_name"].InnerText;
                    strArray1[i, 5] = xn["Volume_label"].InnerText;
                    strArray1[i, 6] = xn["File_system_properties"].InnerText;
                    strArray1[i, 7] = xn["Serial_number"].InnerText;
                    strArray1[i, 8] = xn["Max_component_length"].InnerText;
                    strArray1[i, 9] = xn["UNC_name"].InnerText;
                    strArray1[i, 10] = xn["Recycle_bin_max_size"].InnerText;
                    strArray1[i, 11] = xn["Recycle_bin_size"].InnerText;
                    strArray1[i, 12] = xn["Recycle_bin_num_items"].InnerText;
                    flaglogdvCnt = flaglogdvCnt + 1;
                }

                Disk_PlaceHolder.Controls.Clear();
                int disk_tblRows = count_logical_drives;
                int disk_tblCols = 1;
                Table disk_tbl = new Table();
                Disk_PlaceHolder.Controls.Add(disk_tbl);
                for (int i = 0; i < disk_tblRows; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < disk_tblCols; j++)
                    {
                        TableCell tc = new TableCell();
                        Label lbl = new Label();
                        //                    lbl.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disk " + strArray1[i, 0] + ":  " + Convert_MB(strArray1[i, 2]) + " ( " + Convert_MB(strArray1[i, 3]) + " free )";
                        lbl.Text = "Disk " + strArray1[i, 0] + ":  " + Convert_MB(strArray1[i, 2]) + " ( " + Convert_MB(strArray1[i, 3]) + " free )";
                        tc.Controls.Add(lbl);
                        tr.Cells.Add(tc);
                    }
                    disk_tbl.Rows.Add(tr);
                }
            }
            else
            {

                lblprocessor1.Text = processors.InnerText;
                lblgenprocname.Text = processors.InnerText;
                lblfamily1.Text = Family.InnerText;
                lblmenufec1.Text = Manufacturer.InnerText;
                lblmaxspeed1.Text = Max_speed.InnerText;
                lblmodel1.Text = Model.InnerText;
                lblspeed1.Text = Speed.InnerText;
                lblstepping1.Text = Stepping.InnerText;
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
    protected void DisplayMemoryDetails(XmlDocument xmldoc)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode physical_mem = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Physical_memory");
            XmlNode virtual_mem = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Virtual_memory");
            XmlNode page_file = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Page_file_size");
            if (count_processors > 1)
            {
                lblphysical.Text = Convert_MB(physical_mem.InnerText);
                lbllogical.Text = Convert_MB(virtual_mem.InnerText);
                lblpagefile.Text = Convert_MB(page_file.InnerText);
            }
            else
            {
                lblphysical1.Text = Convert_MB(physical_mem.InnerText);
                lbllogical1.Text = Convert_MB(virtual_mem.InnerText);
                lblpagefile1.Text = Convert_MB(page_file.InnerText);
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
    protected void DisplayOSDetails(XmlDocument xmldoc)
    {
        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode os_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Name");
            XmlNode major_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Major_version");
            XmlNode minor_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Minor_version");
            XmlNode build_no = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Build_number");
            XmlNode add_info = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Additional_information");
            XmlNode user_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//User_name");
            XmlNode reg_to = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registered_to");
            XmlNode reg_org = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registered_organization");
            XmlNode reg_code = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registration_code");
            XmlNode localization = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Locale");
            XmlNode product_key = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Product_key");

            //  lblmonitorname.Text = os_name.InnerText;
            //  lblmonitorproductId.Text = major_version.InnerText;
            //  lblgenosname.Text = os_name.InnerText;
            //  lblgenmv.Text = major_version.InnerText;
            //  lblmanufacture.Text = minor_version.InnerText;
            ////  lblSerialNo.Text = build_no.InnerText;
            //  lblhorizontalresolution.Text = add_info.InnerText;
            ////  lblusername.Text = user_name.InnerText;
            //  lblverticalresolution.Text = reg_code.InnerText;
            ////  lblregorg.Text = reg_org.InnerText;
            //  lblgenorg.Text = reg_org.InnerText;
            //  lblmaxhorizontalsize.Text = reg_to.InnerText;
            ////  lbllocalization.Text = localization.InnerText;
            //  lblgenlocal.Text = localization.InnerText;
            //  lblmaxverticalsize.Text = product_key.InnerText;
            lblosname.Text = os_name.InnerText;
            lblmajorversion.Text = major_version.InnerText;
            lblgenosname.Text = os_name.InnerText;
            lblgenmv.Text = major_version.InnerText;
            lblminorversion.Text = minor_version.InnerText;
            lblbuildno.Text = build_no.InnerText;
            lbladdinfo.Text = add_info.InnerText;
            lblusername.Text = user_name.InnerText;
            lblregcode.Text = reg_code.InnerText;
            lblregorg.Text = reg_org.InnerText;
            lblgenorg.Text = reg_org.InnerText;
            lblregto.Text = reg_to.InnerText;
            lbllocalization.Text = localization.InnerText;
            lblgenlocal.Text = localization.InnerText;
            lblproductkey.Text = product_key.InnerText;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void DisplayPhysicalDriveDetails(XmlDocument xmldoc)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode physical_drives = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Drive");
            XmlNode Capacity = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Capacity");
            XmlNode Manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Manufacturer");
            XmlNode Product_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Drive");
            XmlNode Serial_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Serial_number");
            if (count_processors == 1)
            {
                lbldrivename1.Text = physical_drives.InnerText;
                lblcapacity1.Text = Capacity.InnerText;
                lbldrivemanufec1.Text = Manufacturer.InnerText;
                lblproductversion1.Text = Product_version.InnerText;
                lblserialno1.Text = Serial_number.InnerText;
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
    protected void DisplayLogicalDriveDetails(XmlDocument xmldoc)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode Drive_letter = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Drive_letter");
            XmlNode Drive_type = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Drive_type");
            XmlNode File_system_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//File_system_name");
            XmlNode Free_bytes = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Free_bytes");
            XmlNode Total_bytes = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Total_bytes");
            if (count_processors == 1)
            {
                lbldriveletter1.Text = Drive_letter.InnerText;
                lbldrivetype1.Text = Drive_type.InnerText;
                lblfilesystemname1.Text = File_system_name.InnerText;
                lblfreebytes1.Text = Free_bytes.InnerText;
                lbltotalbytes1.Text = Total_bytes.InnerText;
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
    protected void DisplayNetworkDetails(XmlDocument xmldoc)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNodeList nodes_network_adapter = xmldoc.DocumentElement.SelectNodes("//Computer//Network_adapters//Adapter");
            XmlNodeList nodes_network_adapter_protocol = xmldoc.DocumentElement.SelectNodes("//Computer//Network_adapters//Adapter//Network_protocols//Protocol");
            XmlNodeList nodes_network_adapter_protocol_IP_Addresses_Address = xmldoc.DocumentElement.SelectNodes("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//IP_Addresses//Address");
            XmlNodeList nodes_network_adapter_protocol_Gateways = xmldoc.DocumentElement.SelectNodes("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//Gateways");
            XmlNodeList nodes_network_adapter_protocol_DHCP_parameters = xmldoc.DocumentElement.SelectNodes("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//DHCP_parameters");
            XmlNode adapter = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter");
            XmlNode protocol = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol");
            XmlNode protocol_IP_Addresses_Address = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//IP_Addresses//Address//Address");
            XmlNode protocol_Gateways = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//Gateways");
            XmlNode Link_speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Link_speed");

            count_network_adapters = nodes_network_adapter.Count;
            if (count_network_adapters > 1)
            {
                XmlNode xn;
                XmlNode xn1;
                XmlNode xn2;
                XmlNode xn3;
                XmlNode xn4;
                string[,] strArray = new string[count_network_adapters, 10];

                for (int i = 0; i < count_network_adapters; i++)
                {
                    string temp;
                    Boolean index;
                    xn = nodes_network_adapter.Item(i);
                    xn1 = nodes_network_adapter_protocol.Item(i);
                    xn2 = nodes_network_adapter_protocol_IP_Addresses_Address.Item(i);
                    xn3 = nodes_network_adapter_protocol_Gateways.Item(i);
                    xn4 = nodes_network_adapter_protocol_DHCP_parameters.Item(i);
                    strArray[i, 0] = xn["Name"].InnerText;
                    strArray[i, 1] = xn["MAC_Address"].InnerText;
                    strArray[i, 2] = xn["Link_speed"].InnerText;
                    strArray[i, 3] = xn["MTU"].InnerText;
                    strArray[i, 4] = xn["Type"].InnerText;
                    strArray[i, 5] = xn1["Name"].InnerText;
                    temp = xn2.InnerXml;

                    index = (Boolean)temp.Contains("<");
                    if (index == true)
                    {
                        strArray[i, 6] = xn2["Address"].InnerText;
                        strArray[i, 7] = xn2["Subnet_mask"].InnerText;
                    }
                    else
                    {
                        strArray[i, 6] = null;
                        strArray[i, 7] = null;

                    }
                    temp = xn3.InnerXml;
                    index = (Boolean)temp.Contains("<");
                    if (index == true)
                    {
                        strArray[i, 8] = xn3["Gateway"].InnerText;
                    }
                    else
                    {
                        strArray[i, 8] = null;
                    }
                    strArray[i, 9] = xn4["DHCP_enabled"].InnerText;
                    flagnetworkCnt = flagnetworkCnt + 1;

                }
                Network_PlaceHolder.Controls.Clear();
                phadaptor.Controls.Clear();
                int tblRows = count_network_adapters;
                Table tbl = new Table();
                Table tbl1 = new Table();
                Network_PlaceHolder.Controls.Add(tbl);
                phadaptor.Controls.Add(tbl1);
                #region Create Table and Rows
                for (int i = 0; i < tblRows; i++)
                {

                    TableRow tr0 = new TableRow();
                    TableCell tc0 = new TableCell();
                    tc0.Width = 80;
                    TableCell tc00 = new TableCell();
                    tc00.Width = 500;
                    Label lbl0 = new Label();
                    Label lbl00 = new Label();
                    lbl0.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:";
                    lbl0.Font.Bold = true;
                    lbl00.Text = strArray[i, 0];
                    lbl00.Font.Bold = false;
                    tc0.Controls.Add(lbl0);
                    tc00.Controls.Add(lbl00);
                    tr0.Cells.Add(tc0);
                    tr0.Cells.Add(tc00);

                    TableCell tc000 = new TableCell();
                    tc000.Width = 120;
                    TableCell tc0000 = new TableCell();
                    tc0000.Width = 390;
                    Label lbl000 = new Label();
                    Label lbl0000 = new Label();
                    lbl000.Text = "MAC Address:";
                    lbl000.Font.Bold = true;
                    lbl0000.Text = strArray[i, 1];
                    lbl0000.Font.Bold = false;
                    tc000.Controls.Add(lbl000);
                    tc0000.Controls.Add(lbl0000);
                    tr0.Cells.Add(tc000);
                    tr0.Cells.Add(tc0000);
                    tbl.Rows.Add(tr0);



                    string tempLnkSpeed;
                    tempLnkSpeed = strArray[i, 2];
                    tempLnkSpeed = Convert_MB(tempLnkSpeed);

                    TableRow tr1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    tc1.Width = 100;
                    TableCell tc11 = new TableCell();
                    tc11.Width = 500;
                    Label lbl1 = new Label();
                    Label lbl11 = new Label();
                    lbl1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Link Speed:";
                    lbl1.Font.Bold = true;
                    lbl11.Text = tempLnkSpeed + "/sec";
                    lbl11.Font.Bold = false;
                    tc1.Controls.Add(lbl1);
                    tc11.Controls.Add(lbl11);
                    tr1.Cells.Add(tc1);
                    tr1.Cells.Add(tc11);

                    TableCell tc111 = new TableCell();
                    tc111.Width = 120;
                    TableCell tc1111 = new TableCell();
                    tc1111.Width = 390;
                    Label lbl111 = new Label();
                    Label lbl1111 = new Label();
                    lbl111.Text = "MTU:";
                    lbl111.Font.Bold = true;
                    lbl1111.Text = strArray[i, 3];
                    lbl1111.Font.Bold = false;
                    tc111.Controls.Add(lbl111);
                    tc1111.Controls.Add(lbl1111);
                    tr1.Cells.Add(tc111);
                    tr1.Cells.Add(tc1111);
                    tbl.Rows.Add(tr1);


                    TableRow tr2 = new TableRow();
                    TableCell tc2 = new TableCell();
                    tc2.Width = 80;
                    TableCell tc22 = new TableCell();
                    tc22.Width = 500;
                    Label lbl2 = new Label();
                    Label lbl22 = new Label();
                    lbl2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type:";
                    lbl2.Font.Bold = true;
                    lbl22.Text = strArray[i, 4];
                    lbl22.Font.Bold = false;
                    tc2.Controls.Add(lbl2);
                    tc22.Controls.Add(lbl22);
                    tr2.Cells.Add(tc2);
                    tr2.Cells.Add(tc22);

                    TableCell tc222 = new TableCell();
                    tc222.Width = 120;
                    TableCell tc2222 = new TableCell();
                    tc2222.Width = 390;
                    Label lbl222 = new Label();
                    Label lbl2222 = new Label();
                    lbl222.Text = "Protocol Name:";
                    lbl222.Font.Bold = true;
                    lbl2222.Text = strArray[i, 5];
                    lbl2222.Font.Bold = false;
                    tc222.Controls.Add(lbl222);
                    tc2222.Controls.Add(lbl2222);
                    tr2.Cells.Add(tc222);
                    tr2.Cells.Add(tc2222);
                    tbl.Rows.Add(tr2);

                    TableRow tr3 = new TableRow();
                    TableCell tc3 = new TableCell();
                    tc3.Width = 105;
                    TableCell tc33 = new TableCell();
                    tc33.Width = 500;
                    Label lbl3 = new Label();
                    Label lbl33 = new Label();
                    lbl3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IP Address:";
                    lbl3.Font.Bold = true;
                    lbl33.Text = strArray[i, 6];
                    lbl33.Font.Bold = false;
                    tc3.Controls.Add(lbl3);
                    tc33.Controls.Add(lbl33);
                    tr3.Cells.Add(tc3);
                    tr3.Cells.Add(tc33);

                    TableCell tc333 = new TableCell();
                    tc333.Width = 120;
                    TableCell tc3333 = new TableCell();
                    tc3333.Width = 390;
                    Label lbl333 = new Label();
                    Label lbl3333 = new Label();
                    lbl333.Text = "Subnet Mask:";
                    lbl333.Font.Bold = true;
                    lbl3333.Text = strArray[i, 7];
                    lbl3333.Font.Bold = false;
                    tc333.Controls.Add(lbl333);
                    tc3333.Controls.Add(lbl3333);
                    tr3.Cells.Add(tc333);
                    tr3.Cells.Add(tc3333);
                    tbl.Rows.Add(tr3);


                    string varIPAdd;
                    string ipaddress;
                    TableRow tr4 = new TableRow();
                    TableCell tc444 = new TableCell();
                    tc444.Width = 120;
                    TableCell tc4444 = new TableCell();
                    tc4444.Width = 390;
                    Label lbl444 = new Label();
                    Label lbl4444 = new Label();
                    lbl444.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IP type:";
                    lbl444.Font.Bold = true;

                    varIPAdd = strArray[i, 9];
                    ipaddress = strArray[i, 6];
                    if (ipaddress != "" && ipaddress != null)
                    {
                        if (varIPAdd == "0")
                        {
                            lbl4444.Text = "Static IP Address";
                        }
                        else
                        {
                            lbl4444.Text = "Dynamic IP Address";
                        }

                    }
                    else
                    {
                        lbl4444.Text = "";
                    }

                    lbl4444.Font.Bold = false;
                    tc444.Controls.Add(lbl444);
                    tc4444.Controls.Add(lbl4444);
                    tr4.Cells.Add(tc444);
                    tr4.Cells.Add(tc4444);

                    TableCell tc4 = new TableCell();
                    tc4.Width = 80;
                    TableCell tc44 = new TableCell();
                    tc44.Width = 500;
                    Label lbl4 = new Label();
                    Label lbl44 = new Label();
                    lbl4.Text = "Gateway:";
                    lbl4.Font.Bold = true;
                    lbl44.Text = strArray[i, 8];
                    lbl44.Font.Bold = false;
                    tc4.Controls.Add(lbl4);
                    tc44.Controls.Add(lbl44);
                    tr4.Cells.Add(tc4);
                    tr4.Cells.Add(tc44);
                    tbl.Rows.Add(tr4);

                    // tbl.Rows.Add(tr4);
                    TableRow tr5 = new TableRow();
                    TableCell tc5 = new TableCell();
                    tr5.Cells.Add(tc5);
                    tbl.Rows.Add(tr5);

                    TableRow tr6 = new TableRow();
                    TableCell tc6 = new TableCell();
                    tr6.Cells.Add(tc6);
                    tbl.Rows.Add(tr6);

                    TableRow tr7 = new TableRow();
                    TableCell tc7 = new TableCell();
                    tr7.Cells.Add(tc7);
                    tbl.Rows.Add(tr7);

                    TableRow tr8 = new TableRow();
                    TableCell tc8 = new TableCell();
                    tr8.Cells.Add(tc8);
                    tbl.Rows.Add(tr8);

                    TableRow tr9 = new TableRow();
                    TableCell tc9 = new TableCell();
                    tr9.Cells.Add(tc9);
                    tbl.Rows.Add(tr9);

                    TableRow tr10 = new TableRow();
                    TableCell tc10 = new TableCell();
                    tr10.Cells.Add(tc10);
                    tbl.Rows.Add(tr10);

                    TableRow tr14 = new TableRow();
                    TableCell tc14 = new TableCell();
                    tr14.Cells.Add(tc14);
                    tbl.Rows.Add(tr14);

                    TableRow tr12 = new TableRow();
                    TableCell tc12 = new TableCell();
                    tr12.Cells.Add(tc12);
                    tbl.Rows.Add(tr12);

                }

                for (int i = 0; i < tblRows; i++)
                {

                    TableRow tr01 = new TableRow();
                    TableCell tc01 = new TableCell();
                    tc01.Width = 80;
                    TableCell tc001 = new TableCell();
                    tc001.Width = 500;
                    Label lbl01 = new Label();
                    Label lbl001 = new Label();
                    lbl01.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:";
                    lbl01.Font.Bold = true;
                    lbl001.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + strArray[i, 0];
                    lbl001.Font.Bold = false;
                    tc01.Controls.Add(lbl01);
                    tc001.Controls.Add(lbl001);
                    tr01.Cells.Add(tc01);
                    tr01.Cells.Add(tc001);
                    tbl1.Rows.Add(tr01);

                }
                #endregion
            }
            else
            {


                lbladaptor.Text = adapter.InnerText;
                lblgenadaptor.Text = adapter.InnerText;
                lblprotocol.Text = protocol.InnerText;
                if (protocol_IP_Addresses_Address != null)  //added by lalit
                {
                    lblipaddress.Text = protocol_IP_Addresses_Address.InnerText;
                }
                lblgatway.Text = protocol_Gateways.InnerText;
                lbllinkspeed.Text = Link_speed.InnerText;
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
    //added by lalit to display monitor detials
    protected void DisplayMonitorDetails(XmlDocument xmldoc)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            XmlNode monitor_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor/Name");
            XmlNode manufacture = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Manufacture");
            XmlNode horizontal_resolution = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Horizontal_resolution");
            XmlNode vertical_resolution = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Vertical_resolution");
            XmlNode max_horizontalsize = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Max_horizontal_size");
            XmlNode max_verticalsize = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Max_vertical_size");
            XmlNode monitor_Productid = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Product_ID");
            XmlNode monitor_serialno = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Serial_number");
            XmlNode manitor_manufacturedate = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Monitors/Monitor//Manufacturing_Date");

            if (monitor_name != null)
            {
                lblmonitorname.Text = monitor_name.InnerText;
            }
            if (manufacture != null)
            {
                lblmanufacture.Text = manufacture.InnerText;
            }
            if (horizontal_resolution != null)
            {
                lblhorizontalresolution.Text = horizontal_resolution.InnerText;
            }
            if (vertical_resolution != null)
            {
                lblverticalresolution.Text = vertical_resolution.InnerText;
            }
            if (max_horizontalsize != null)
            {
                lblmaxhorizontalsize.Text = max_horizontalsize.InnerText;
            }
            if (max_verticalsize != null)
            {
                lblmaxverticalsize.Text = max_verticalsize.InnerText;
            }
            if (monitor_Productid != null)
            {
                lblmonitorproductId.Text = monitor_Productid.InnerText;
            }
            if (monitor_serialno != null)
            {
                lblserialnomonitor.Text = monitor_serialno.InnerText;
            }
            if (manitor_manufacturedate != null)
            {
                lblmonimanudate.Text = manitor_manufacturedate.InnerText;
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
    //end lalit

    #endregion


    #region Function for Convert byte to MB
    public string Convert_MB(string byte_value)
    {
        long temp = 0;
        //if (byte_value == "")///16-05-2012 comment by vishal
        //{

        if (byte_value != "")  //added by lalit
        {
            temp = Convert.ToInt64(byte_value) / 1048576;
        }
        //}
        return temp.ToString() + " MB";
    }
    #endregion

    #region More Info Link Buttons
    protected void lnkhrd_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            if (count_processors > 1)
            {
                Panproduct.Visible = true;
            }
            else
            {
                PanHardware.Visible = true;
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
    protected void lnkos_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            Panos.Visible = true;
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void lnkadaptor_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            if (count_network_adapters > 1)
            {
                Pannetwork1.Visible = true;
            }
            else
            {
                Pannetwork.Visible = true;
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
    #endregion

    protected void Imageoperatingsystem_Click1(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            visiblefun();
            Panos.Visible = true;
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

