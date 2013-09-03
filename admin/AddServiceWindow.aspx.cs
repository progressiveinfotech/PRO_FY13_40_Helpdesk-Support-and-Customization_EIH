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

public partial class admin_AddServiceWindow : System.Web.UI.Page
{
    // Coded By - Sumit gupta
    // Coded On - 23 jan 2010
    // Purpose  - Add Service Window on Site Base, ie Define operational hours of Site
    // Declare Objects of various classes ,Used later
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    ServiceWindow_mst objSerWindow = new ServiceWindow_mst();
    Servicehours_mst objSerHours = new Servicehours_mst();
    ServiceDay_mst objSerDay = new ServiceDay_mst();
    BLLCollection<ServiceDay_mst> colServiceDay = new BLLCollection<ServiceDay_mst>();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int servicewinid = 0;
            BindDropCustomer();

            if (Request.QueryString.Count  != 0)
            {
               servicewinid = Convert.ToInt32(Request.QueryString[0]);
            }
            if (servicewinid != 0)
            {
                BindDropDown();
                objSerWindow = objSerWindow.Get_By_serviceid(servicewinid);
                int varSiteId = objSerWindow.Siteid;
                drpSites.SelectedValue = Convert.ToString(varSiteId);
                DisplayServiceWindow(varSiteId);
            }
            else
            {
                reqValSite.ErrorMessage = Resources.MessageResource.errSelectSite.ToString();
               
                BindDropDown();

                DefaultSetting();
            }
        }
    }
    // Definition of BindDropDown()

    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "------------Select-------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";


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
    // Definition of Default Settings of Check box
    protected void ChkDefaultDays()
    {
        chkMonday.Checked = true;
        chkTuesday.Checked  = true;
        chkWednesday.Checked  = true;
        chkThursday.Checked = true;
        chkFriday.Checked  = true;
    
    }
    // Definition of Default Settings
    protected void DefaultSetting()
    {
        ChkDefaultDays();
        rdbtn24hr.Checked = true;
        rdbtnSelect.Checked = false;
        //drpSites.SelectedValue = "0";
        chkSaturday.Checked = false;
        chkSunday.Checked = false;
    }
    // Handler btnSave_click to handle event 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblErrorMsgWorkingTime.Text = "";
        lblErrorMsgWorkingDays.Text = "";
        // Declare local variables FlagStartEndTime and FlagDaysCheck and varSiteId and FlagInsert
        int FlagStartEndTime=0;
        int FlagDaysCheck = 0;
        int varSiteId; 
        int FlagInsert;
        // Declare locl variables starthr,startmin,endhr and endmin
        int starthr, startmin, endhr, endmin;
        // Check radio button 24 hr has checked 
        if (rdbtn24hr.Checked == true)
        {
            starthr = 0;
            startmin = 1;
            endhr = 23;
            endmin = 59;
        }
            // Select other check box
        else
        {
            starthr = Convert.ToInt32(drpStarthour.SelectedValue);
            startmin = Convert.ToInt32(drpStartmin.SelectedValue);
            endhr = Convert.ToInt32(drpEndhr.SelectedValue);
            endmin = Convert.ToInt32(drpEndmin.SelectedValue);
        }

        // Check Start time Should be less than End Time
        if (rdbtn24hr.Checked == true)
        {
            FlagStartEndTime = 1;

        }
        else
        { 
            // Check condition start hour  shoild less than End hour 
            if (starthr < endhr)
                {
                FlagStartEndTime = 1;
            
                }
           // Check condition start hour and end hour is equal,then start min should less than End min
              else if (starthr == endhr && startmin < endmin)
              {
                  FlagStartEndTime = 1;
              }
              else { FlagStartEndTime = 0; }
        }
       
        
        // Check At Least one Working Days has been Selected
        if (chkMonday.Checked == false && chkTuesday.Checked == false && chkWednesday.Checked == false && chkThursday.Checked == false && chkFriday.Checked == false && chkSaturday.Checked == false && chkSunday.Checked == false)
        {
            FlagDaysCheck = 0;

        }
        else 
        {
            FlagDaysCheck = 1;
        
        }
        // If FlagStartEndTime is zeros then display error message,start time should less than end time
        if(FlagStartEndTime==0)
        {
            lblErrorMsgWorkingTime.Text = Resources.MessageResource.errWorkingTime.ToString();
            lblErrorMsg.Text = "";
        }
        // If FlagDaysCheck is zeros then display error message,select at least one check box
        if (FlagDaysCheck == 0)
        {
            lblErrorMsgWorkingDays.Text = Resources.MessageResource.errWorkingDays.ToString();
            lblErrorMsg.Text = "";
        }

        // If FlagStartEndTime is one and FlagDaysCheck is one then 
        if (FlagStartEndTime == 1 && FlagDaysCheck == 1)
        {

            // Declare local variable varSiteId 
            varSiteId = Convert.ToInt32(drpSites.SelectedValue);
            // to get the object objSerWindow by calling function Get_By_id(varSiteId)
            objSerWindow = objSerWindow.Get_By_id(varSiteId);
            // If objSerWindow.Siteid  is not zero then object exist    
            if (objSerWindow.Siteid == 0)
                {
                    objSerWindow.Siteid = varSiteId;
                    FlagInsert = objSerWindow.Insert();
                // If Flag Insert is 1,then inser operation performed successfully    
                if (FlagInsert == 1)
                    {
                        // Definition of Service hours insertion -Start
                       // Declare local variable 
                        int FlagHrInsert;
                        int FlagDayInsert;

                        objSerWindow = objSerWindow.Get_By_id(varSiteId);
                        objSerHours.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerHours.Starthour = starthr;
                        objSerHours.Startmin = startmin;
                        objSerHours.Endhour = endhr;
                        objSerHours.Endmin = endmin;
                        FlagHrInsert = objSerHours.Insert();
                        // Definition of Service hours insertion -End

                        // Definition of Service Day insertion -Start

                    // find  which check box has been selected   
                    if (chkMonday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Monday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Monday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkTuesday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Tuesday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Tuesday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkWednesday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Wednesday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Wednesday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkThursday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Thursday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Thursday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkFriday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Friday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Friday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkSaturday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Saturday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Saturday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        if (chkSunday.Checked == true)
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Sunday";
                            objSerDay.Isworking = true;
                            FlagDayInsert = objSerDay.Insert();
                        }
                        else
                        {
                            objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                            objSerDay.Weekday = "Sunday";
                            objSerDay.Isworking = false;
                            FlagDayInsert = objSerDay.Insert();

                        }
                        // if FlagHrInsert and FlagDayInsert is one ie data hase been inserted successfully
                        if (FlagHrInsert == 1 && FlagDayInsert == 1)
                        {
                            lblErrorMsg.Text = Resources.MessageResource.errServiceWindParm.ToString();
                            
                        }
                        else
                        {
                            objSerDay.Delete(objSerWindow.Servicewindowid);
                            objSerHours.Delete(objSerWindow.Servicewindowid);
                            objSerWindow.Delete(objSerWindow.Servicewindowid);
                            lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();

                        }


                        // Definition of Service Day insertion -End




                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();
                    }

                }
                else 
                {

                    // Definition of Service hours Update -Start
                    int FlagHrUpdate;
                    int FlagDayUpdate;

                    objSerWindow = objSerWindow.Get_By_id(varSiteId);
                    objSerHours.Servicewindowid = objSerWindow.Servicewindowid;
                    objSerHours.Starthour = starthr;
                    objSerHours.Startmin = startmin;
                    objSerHours.Endhour = endhr;
                    objSerHours.Endmin = endmin;
                    FlagHrUpdate = objSerHours.Update();
                    // Definition of Service hours Update -End


                    // Definition of Service Day Updation -Start

                    if (chkMonday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Monday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Monday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkTuesday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Tuesday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Tuesday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkWednesday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Wednesday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Wednesday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkThursday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Thursday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Thursday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkFriday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Friday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Friday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkSaturday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Saturday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Saturday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (chkSunday.Checked == true)
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Sunday";
                        objSerDay.Isworking = true;
                        FlagDayUpdate = objSerDay.Update();
                    }
                    else
                    {
                        objSerDay.Servicewindowid = objSerWindow.Servicewindowid;
                        objSerDay.Weekday = "Sunday";
                        objSerDay.Isworking = false;
                        FlagDayUpdate = objSerDay.Update();

                    }
                    if (FlagHrUpdate == 1 && FlagDayUpdate == 1)
                    {
                        lblErrorMsg.Text = Resources.MessageResource.errServiceWindParm.ToString();

                    }
                    


                    // Definition of Service Day insertion -End

                
                }
            if (Request.QueryString.Count != 0)
            {
                Response.Redirect("~/admin/ViewServiceWindow.aspx");
            }

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        DefaultSetting();
        lblErrorMsg.Text = "";
        lblErrorMsgWorkingDays.Text = "";
        lblErrorMsgWorkingTime.Text = "";
    }
    protected void drpSites_SelectedIndexChanged(object sender, EventArgs e)
    {
        int varSiteId;
        varSiteId = Convert.ToInt32(drpSites.SelectedValue);

        objSerWindow = objSerWindow.Get_By_id(varSiteId);
        if (objSerWindow.Siteid != 0)
        {
            DefaultSetting();
            lblErrorMsg.Font.Bold = true;
            lblErrorMsg.Text = "The Following are the Service Window Parameters for this Site";
            lblErrorMsgWorkingDays.Text = "";
            lblErrorMsgWorkingTime.Text = "";
            DisplayServiceWindow(varSiteId);

        }

        else
        {
            DefaultSetting();
            lblErrorMsg.Font.Bold = true;
            lblErrorMsg.Text = "Service Window is not set for this Site";
            lblErrorMsgWorkingDays.Text = "";
            lblErrorMsgWorkingTime.Text = "";
            
        }


    }
    protected void DisplayServiceWindow(int varSiteId)
    {
        objSerWindow = objSerWindow.Get_By_id(varSiteId);
        if (objSerWindow.Siteid != 0)
        {
            objSerHours = objSerHours.Get_By_id(objSerWindow.Servicewindowid);
            if (objSerHours.Servicewindowid != 0)
            {

                if (objSerHours.Starthour == 0 && objSerHours.Startmin == 15 && objSerHours.Endhour == 23 && objSerHours.Endmin == 45)
                {
                    rdbtn24hr.Checked = true;
                    rdbtnSelect.Checked = false;
                }
                else
                {
                    rdbtn24hr.Checked = false;
                    rdbtnSelect.Checked = true;
                    drpStarthour.SelectedValue = Convert.ToString(objSerHours.Starthour);
                    drpStartmin.SelectedValue = Convert.ToString(objSerHours.Startmin);
                    drpEndhr.SelectedValue = Convert.ToString(objSerHours.Endhour);
                    drpEndmin.SelectedValue = Convert.ToString(objSerHours.Endmin);

                }

            }

            colServiceDay = objSerDay.Get_All_By_Id(objSerWindow.Servicewindowid);
            foreach (ServiceDay_mst service in colServiceDay)
            {
                string varServiceDay;
                varServiceDay = service.Weekday.ToString();
                if (varServiceDay == "Monday")
                {
                    if (service.Isworking == true)
                    {
                        chkMonday.Checked = true;

                    }
                    else
                    {
                        chkMonday.Checked = false;


                    }

                }
                if (varServiceDay == "Tuesday")
                {
                    if (service.Isworking == true)
                    {
                        chkTuesday.Checked = true;

                    }
                    else
                    {
                        chkTuesday.Checked = false;


                    }

                }
                if (varServiceDay == "Wednesday")
                {
                    if (service.Isworking == true)
                    {
                        chkWednesday.Checked = true;

                    }
                    else
                    {
                        chkWednesday.Checked = false;


                    }

                }

                if (varServiceDay == "Thursday")
                {
                    if (service.Isworking == true)
                    {
                        chkThursday.Checked = true;

                    }
                    else
                    {
                        chkThursday.Checked = false;


                    }

                }

                if (varServiceDay == "Friday")
                {
                    if (service.Isworking == true)
                    {
                        chkFriday.Checked = true;

                    }
                    else
                    {
                        chkFriday.Checked = false;


                    }

                }

                if (varServiceDay == "Saturday")
                {
                    if (service.Isworking == true)
                    {
                        chkSaturday.Checked = true;

                    }
                    else
                    {
                        chkSaturday.Checked = false;


                    }

                }

                if (varServiceDay == "Sunday")
                {
                    if (service.Isworking == true)
                    {
                        chkSunday.Checked = true;

                    }
                    else
                    {
                        chkSunday.Checked = false;


                    }

                }

            }

        }
        else
        {
            DefaultSetting();

        }
    
    }
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDown();
    }
}
