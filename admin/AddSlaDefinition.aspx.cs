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

public partial class admin_AddSlaDefinition : System.Web.UI.Page
{
    // Coded By - Sumit gupta
    // Coded On - 23 jan 2010
    // Purpose  - Add Service level Aggrement(SLA) on the site basis
    // Declare Objects of various classes ,Used later
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    Priority_mst objPriority = new Priority_mst();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    SLA_mst objSla = new SLA_mst();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    Region_mst objRegion = new Region_mst();
    BLLCollection<Region_mst> colRegion = new BLLCollection<Region_mst>();
    BLLCollection<EscalateEmail_mst> col = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    EscalateLevel1 objLevel1 = new EscalateLevel1();
    EscalateLevel2 objLevel2 = new EscalateLevel2();
    EscalateLevel3 objLevel3 = new EscalateLevel3();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCustomer = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            reqValSite.ErrorMessage = Resources.MessageResource.errSelectSite.ToString();
            reqValDrpPriority.ErrorMessage = Resources.MessageResource.errSelectPrty.ToString();
            reqValtxtDays.ErrorMessage = Resources.MessageResource.errEnterDays.ToString();
            reqValtxtSla.ErrorMessage = Resources.MessageResource.errSLAName.ToString();
            txtDays.Text = "0";
            txtDaysLevel1.Text = "0";
            txtDaysLevel2.Text = "0";
            txtDaysLevel3.Text = "0";
            //BindDropDown at Page Load
            //BindDropDown();
            BindDropDownPriority();
            BindDropRegion();
            BindDropDownSiteRegionWise();
            CheckDefaultValueForEscalation();
        
        }
        
    }
    protected void BindListBox()
    {
        col = objEscalateEmail.Get_All();
        listLevel1.DataTextField = "email";
        listLevel1.DataValueField = "id";

        listLevel1.DataSource = col;
        listLevel1.DataBind();

        listLevel2.DataTextField = "email";
        listLevel2.DataValueField = "id";

        listLevel2.DataSource = col;
        listLevel2.DataBind();

        listLevel3.DataTextField = "email";
        listLevel3.DataValueField = "id";

        listLevel3.DataSource = col;
        listLevel3.DataBind();
    }
    protected void BindDropRegion()
    {
        colCustomer = objCustomer.Get_All();
        drpRegion.DataTextField = "Customer_Name";
        drpRegion.DataValueField = "custid";
        drpRegion.DataSource = colCustomer;
        drpRegion.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select------------";
        item.Value = "0";
        drpRegion.Items.Add(item);
        drpRegion.SelectedValue = "0";
    
    
    
    }
    // Definition of BindDropDown()
    protected void BindDropDown()
    {
        colSite = objSite.Get_All();
        for (int i = 0; i < colSite.Count; i++)
        {
            for (int j = i; j < colSite.Count; j++)
            {

                if (String.Compare(colSite[i].Sitename, colSite[j].Sitename) > 0)
                {
                    Site_mst obj = new Site_mst();
                    obj = colSite[i];
                    colSite[i] = colSite[j];
                    colSite[j] = obj;

                }
            }

        }
        drpSites.DataTextField = "sitename";
        drpSites.DataValueField = "siteid";
        drpSites.DataSource = colSite;
        drpSites.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------Select----------";
        item.Value = "0";
        drpSites.Items.Add(item);
        drpSites.SelectedValue = "0";


    }
    //Definition of BindDropDownPriority()
    protected void BindDropDownPriority()
    {
        colPriority = objPriority.Get_All();
        drpPriority.DataTextField = "name";
        drpPriority.DataValueField = "priorityid";
        drpPriority.DataSource = colPriority;
        drpPriority.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------Select----------";
        item.Value = "0";
        drpPriority.Items.Add(item);
        drpPriority.SelectedValue = "0";
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Declare local variable varsiteid,FlagInsertSla and FlagStatus
        int varsiteid;
        ServiceWindow_mst objservicewindow = new ServiceWindow_mst();
        varsiteid = Convert.ToInt32(drpSites.SelectedValue);
        int count = objservicewindow.Get_ServiceWindow_By_Siteid(varsiteid);
        if (count >= 1)
        {
            int FlagInsertSla;
            int FlagStatus;
            bool FlagEscalateLevel1 = true;
            bool FlagEscalateLevel2 = true;
            bool FlagEscalateLevel3 = true;
            lblErrorTimeSelect.Text = "";
            if (txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0")
            {
                lblErrorTimeSelect.Text = Resources.MessageResource.errResTime.ToString();
            }
            else
            {

                if (chkLevel1.Checked == true)
                {
                    if (radio1Level1.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel1 = calculateTotalminutesLevel1();
                        if (varTotalTimeLevel1 > varTotalTime)
                        { FlagEscalateLevel1 = false; }
                    }
                    if (radio2Level1.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel1 = calculateTotalminutesLevel1();
                        if (varTotalTimeLevel1 ==0)
                        { FlagEscalateLevel1 = false; }
                    }


                }
                if (chkLevel2.Checked == true)
                {
                    if (radio1Level2.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel2 = calculateTotalminutesLevel2();
                        if (varTotalTimeLevel2 > varTotalTime)
                        { FlagEscalateLevel2 = false; }
                    }
                    if (radio2Level2.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel2 = calculateTotalminutesLevel2();
                        if (varTotalTimeLevel2 == 0)
                        { FlagEscalateLevel2 = false; }
                    }


                }

                if (chkLevel3.Checked == true)
                {
                    if (radio1Level3.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel3 = calculateTotalminutesLevel3();
                        if (varTotalTimeLevel3 > varTotalTime)
                        { FlagEscalateLevel3 = false; }
                    }

                    if (radio2Level3.Checked == true)
                    {
                        int varTotalTime = calculateTotalminutes();
                        int varTotalTimeLevel3 = calculateTotalminutesLevel3();
                        if (varTotalTimeLevel3 == 0)
                        { FlagEscalateLevel3 = false; }
                    }

                }

                // get sitetd from dropdown to variable varsiteid

                // Check SLA Definition is exist in database with same name and site
                objSla = objSla.Get_By_SLAName(txtSlaName.Text.ToString().Trim(), varsiteid);
                // Check SLA Priority definition is exist in databse with siteid and priorityid
                objSlaPriority = objSlaPriority.Get_By_Siteid(varsiteid, Convert.ToInt32(drpPriority.SelectedValue));
                // if both objSla.Siteid and objSlaPriority.Slaid is zero then,No SLA Definition is exist in database
                if (objSla.Siteid == 0 && objSlaPriority.Slaid == 0)
                {

                    if (FlagEscalateLevel1 == true && FlagEscalateLevel2 == true && FlagEscalateLevel3 == true)
                    {



                        objSla.Siteid = varsiteid;
                        objSla.Slaname = txtSlaName.Text.ToString().Trim();
                        objSla.Createdatetime = DateTime.Now.ToString();
                        objSla.Enable = true;
                        objSla.Description = txtDescription.Text.ToString().Trim();
                        // Call objSla.Insert() to insert records in database
                        FlagInsertSla = objSla.Insert();
                        // If FlagInsertSla is 1 then record insert in database successfully
                        if (FlagInsertSla == 1)
                        {
                            // Call Function objSla.Get_By_SLAName() to get Slaid of created sla
                            objSla = objSla.Get_By_SLAName(txtSlaName.Text.ToString().Trim(), varsiteid);

                            if (objSla.Siteid != 0)
                            {
                                // declare local variable FlagInsertPriority
                                int FlagInsertPriority;
                                objSlaPriority.Slaid = objSla.Slaid;
                                objSlaPriority.Siteid = varsiteid;
                                objSlaPriority.Priorityid = Convert.ToInt32(drpPriority.SelectedValue);
                                objSlaPriority.Resolutiondays = Convert.ToInt32(txtDays.Text);
                                objSlaPriority.Resolutionhours = Convert.ToInt32(drphr.SelectedValue);
                                objSlaPriority.Resolutionmin = Convert.ToInt32(drpMin.SelectedValue);
                                // Call function objSlaPriority.Insert() to insert records in SLA_Priority_mst
                                FlagInsertPriority = objSlaPriority.Insert();
                                // if FlagInsertPriority is not zero then records insert successfully
                                if (FlagInsertPriority != 0)
                                {
                                    //lblErrorMsg.Text = Resources.MessageResource.errSLADef.ToString();



                                    if (chkLevel1.Checked == true)
                                    {
                                        InsertIntoLevel1(objSla.Slaid);
                                    }
                                    if (chkLevel2.Checked == true)
                                    {
                                        InsertIntoLevel2(objSla.Slaid);
                                    }
                                    if (chkLevel3.Checked == true)
                                    {
                                        InsertIntoLevel3(objSla.Slaid);
                                    }

                                    Clear();
                                    Response.Redirect("~/admin/viewsla.aspx");
                                    //CheckDefaultValueForEscalation();
                                }
                                else
                                {
                                    // Call objSla.Delete to delete record from SLA_mst to delete sla definition,because some error occurred in SLA_Priority_mst
                                    objSla.Delete(objSla.Slaid);
                                    // Display Error message some error occurred
                                    lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();
                                }


                            }

                        }
                    }
                    else
                    {
                        if (FlagEscalateLevel1 == false)
                        {
                            lblErrorMsg.Text = Resources.MessageResource.strLevel1.ToString();

                        }
                        if (FlagEscalateLevel2 == false)
                        {
                            lblErrorMsg.Text = Resources.MessageResource.strLevel2.ToString();

                        }
                        if (FlagEscalateLevel3 == false)
                        {
                            lblErrorMsg.Text = Resources.MessageResource.strLevel3.ToString();

                        }

                    }
                }
                else
                {


                    lblErrorMsg.Text = Resources.MessageResource.errSLAExist.ToString();
                }
            }
        }
        else
        {
            lblErrorMsg.Text = "Service Window not set for this Site,Set the Service Window for this Site";
        }
        
       

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblErrorTimeSelect.Text = "";
        lblErrorMsg.Text = "";
        Clear();
        CheckDefaultValueForEscalation();
        
       
    }
    protected void lnkViewSla_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/ViewSLA.aspx");
    }
    protected void Clear()
    {
        txtDays.Text = "0";
        txtDescription.Text = "";
        txtSlaName.Text = "";
        drpMin.SelectedValue = "0";
        drpPriority.SelectedValue = "0";
        BindDropRegion();
        BindDropDown();
        drpSites.SelectedValue = "0";
        drphr.SelectedValue = "0";
    
    }
    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionid = Convert.ToInt32(drpRegion.SelectedValue);
        if (regionid == 0)
        {
            //BindDropDown();
            BindDropDownSiteRegionWise();
        }
        else
        {
            BindDropDownSiteRegionWise();
        }
    }

    protected void BindDropDownSiteRegionWise()
    {
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid = Convert.ToInt32(drpRegion.SelectedValue);
        // Declare collection col as Site_mst to get all Sites from database

        // By Calling Function objSite.Get_All() assign to col object
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
    
    }


    protected int  calculateTotalminutes()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;

        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDays.Text != "0")
        {
            varDays = Convert.ToInt32(txtDays.Text);
            
        
        }
        if (drphr.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drphr.SelectedValue);
        }
        if (drpMin.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMin.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected int calculateTotalminutesLevel1()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;

        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel1.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel1.Text);


        }
        if (drpHoursLevel1.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel1.SelectedValue);
        }
        if (drpMinlevel1.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinlevel1.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }


    protected int calculateTotalminutesLevel2()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;
        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel2.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel2.Text);


        }
        if (drpHoursLevel2.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel2.SelectedValue);
        }
        if (drpMinLevel2.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinLevel2.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected int calculateTotalminutesLevel3()
    {
        int varDays = 0;
        int varHours=0;
        int varMin=0;
        int vatTotalMin=0;

        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel3.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel3.Text);


        }
        if (drpHoursLevel3.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel3.SelectedValue);
        }
        if (drpMinLevel3.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinLevel3.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected void InsertIntoLevel1(int slaid)
    {
        string varemail="";
        if (radio1Level1.Checked == true)
        {
            objLevel1.After = false;
            objLevel1.Before = true;
        }
        else 
        {
            objLevel1.After = true;
            objLevel1.Before = false ;
        }
        objLevel1.Slaid = slaid;

        for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel1.Items[i].Selected == true)
            {
                varemail = varemail + listLevel1.Items[i].Text + ",";
               
            }
        }

        objLevel1.Emailid = varemail; 
        objLevel1.Days = Convert.ToInt32(txtDaysLevel1.Text);
        objLevel1.Hours = Convert.ToInt32(drpHoursLevel1.SelectedValue);
        objLevel1.Min = Convert.ToInt32(drpMinlevel1.SelectedValue);

        objLevel1.Insert();
    
    
    }

    protected void InsertIntoLevel2(int slaid)
    {
        string varemail = "";
        if (radio1Level2.Checked == true)
        {
            objLevel2.After = false;
            objLevel2.Before = true;
        }
        else
        {
            objLevel2.After = true;
            objLevel2.Before = false;
        }
        objLevel2.Slaid = slaid;
        for (int i = listLevel2.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel2.Items[i].Selected == true)
            {
                varemail = varemail + listLevel2.Items[i].Text + ",";

            }
        }

        objLevel2.Emailid = varemail; 
        objLevel2.Days = Convert.ToInt32(txtDaysLevel2.Text);
        objLevel2.Hours = Convert.ToInt32(drpHoursLevel2.SelectedValue);
        objLevel2.Min = Convert.ToInt32(drpMinLevel2.SelectedValue);


        objLevel2.Insert();

    }

    protected void InsertIntoLevel3(int slaid)
    {
        string varemail = "";
        if (radio1Level3.Checked == true)
        {
            objLevel3.After = false;
            objLevel3.Before = true;
        }
        else
        {
            objLevel3.After = true;
            objLevel3.Before = false;
        }
        objLevel3.Slaid = slaid;
        for (int i = listLevel3.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel3.Items[i].Selected == true)
            {
                varemail = varemail + listLevel3.Items[i].Text + ",";

            }
        }
        objLevel3.Emailid = varemail; 
        objLevel3.Days = Convert.ToInt32(txtDaysLevel2.Text);
        objLevel3.Hours = Convert.ToInt32(drpHoursLevel3.SelectedValue);
        objLevel3.Min = Convert.ToInt32(drpMinLevel3.SelectedValue);

        objLevel3.Insert();


    }
    protected void CheckDefaultValueForEscalation()
    {
        radio1Level1.Checked = true;
        radio1Level2.Checked = true;
        radio1Level3.Checked = true;
        chkLevel1.Checked = false;
        chkLevel2.Checked = false;
        chkLevel3.Checked = false;
        BindListBox(); 
    
    }
}
