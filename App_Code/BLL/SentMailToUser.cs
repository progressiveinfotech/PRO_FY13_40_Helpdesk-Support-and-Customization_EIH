using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

/// <summary>
/// Summary description for SentMailToUser
/// </summary>
public class SentMailToUser
{
    Incident_mst objIncident = new Incident_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    IncidentStates objIncidentStates = new IncidentStates();
    IncidentResolution objIncidentResolution = new IncidentResolution();
    Priority_mst objPriority = new Priority_mst();
    Site_mst objSite = new Site_mst();
    ContactInfo_mst objC_info = new ContactInfo_mst();
    UserLogin_mst objtech = new UserLogin_mst();
    UserLogin_mst objSDE = new UserLogin_mst();
    ContactInfo_mst objUserInfo = new ContactInfo_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    UserToSiteMapping objUserToSiteMapping = new UserToSiteMapping();
    Change_mst ObjChange = new Change_mst();
    UserEmail objemail = new UserEmail();
    BLLCollection<UserEmail> colemailid = new BLLCollection<UserEmail>();
    SentEmail obj = new SentEmail();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    public SentMailToUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Function Definition of Calculate Total Resolution time define for particular SLA
    public string GetResolutionTimeInHours(int slaid)
    {
        int varDays = 0;
        int varHours = 0;
        int VarMins = 0;
        int TotalHours = 0;
        string total = "";
        objSlaPriority = objSlaPriority.Get_By_id(slaid);
        if (objSlaPriority.Slaid != 0)
        {
            varDays = objSlaPriority.Resolutiondays;
            varHours = objSlaPriority.Resolutionhours;
            VarMins = objSlaPriority.Resolutionmin;
            if (VarMins <= 0)
            {
                TotalHours = (varDays * 24) + (varHours);
                total = TotalHours.ToString() + " " + "Hours";
            }
            else
            {
                TotalHours = (varDays * 24) + (varHours);
                total = TotalHours.ToString() + " " + "Hours" + VarMins + " " + "Minutes";
            }
        }

        return total;


    }
    #endregion
    public void SentmailUser(int userid, int incidentid, string status)
    {
        objIncident = objIncident.Get_By_id(incidentid);
        //added by lalit 02 nov to get resolution and show it to user when call closed mail goes to user
        objIncidentResolution = objIncidentResolution.Get_By_id(incidentid);
        //end
         objSite = objSite.Get_By_id(objIncident.Siteid);
        objIncidentStates = objIncidentStates.Get_By_id(incidentid);
        objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);
        objUser = objUser.Get_By_id(objIncident.Requesterid);
        objC_info = objC_info.Get_By_id(userid);
        objtech = objtech.Get_By_id(objIncidentStates.Technicianid);
        colemailid = objemail.Get_All_userid(userid);
        string strStatusOpen = Resources.MessageResource.strStatusOpen.ToString();
        string strStatusClose = Resources.MessageResource.strStatusClose.ToString();
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();

        if (strStatusOpen.ToLower() == status.ToLower())
        {
          foreach (UserEmail obj1 in colemailid)
            {
                if (obj1.Emailid != null)
                {
                    obj.From = Resources.MessageResource.strAdminEmail.ToString();
                    obj.To = obj1.Emailid;
                    obj.Subject = "Call Logged. Ticket Id : " + incidentid;
                    LogMessage("Call Open TicketId" + incidentid);
                    ///////////////////////////////////////////////////commented by meenakshi 2nd july 2013
                   // obj.Body = "Dear " + objC_info.Firstname + ",<br/><br/> Thank you for contacting IT Service desk, please find below the new Ticket Id details for your future reference.<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                      // + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                     //  + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                    //   + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                    //   + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                    //   + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                     //  + objUser.Username + "<br/><b>ResolutionTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                     //  + GetResolutionTimeInHours(objIncident.Slaid)
                                    //   + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 

                                    //   + objC_info.Emailid + "<br/><br/> For any other support, kindly get in touch with us at " + strContactNumber + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> " + strYourSinscerely + "</b>";
                   
                       ////////////////////////////////////////////////////end
                      
                      string strBody = "Dear " + objC_info.Firstname+ ",<br/><br/> Thank you for contacting IT Service desk, please find below the new Ticket Id details for your future reference.<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + incidentid ;
                        strBody = strBody + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objSite.Sitename ;
                        strBody = strBody + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objIncident.Createdatetime;
                        strBody = strBody + "<br/><b>Description</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:" + objIncident.Description;
                        strBody = strBody + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name;
                        strBody = strBody + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username;
                        strBody = strBody + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objC_info.Emailid;
                        strBody = strBody + "<br/><b>ResolutionTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + GetResolutionTimeInHours(objIncident.Slaid);

                        if (objIncident.Siteid ==1)
                        {
                            //location = "1";
                            //contactnum = "9811801977";
                            //mailid = "Helpdesk.Corporate@oberoigroup.com";
                            //techid = "16";
                            //cmd.CommandText = "insert into Incident_mst(Title, Timespentonreq, Slaid, Siteid, Requesterid, Modeid, Description, Deptid, Createdbyid, Createdatetime,Extension,Completedtime, ExternalTicketNo, VendorId,active,AMCCall ,Reporteddatetime)values(@Title, 0, 3, '" + location + "', 2, 5, @Description, 0, 2, @Createdatetime,0,null, null, 0,1, 0 ,@Reporteddatetime)";
                            //// SentMail("Helpdesk.Corporate@oberoigroup.com", "CSM.Admin@progressive.in", subject, body);

                            //strBody = strBody + "<br/><br/>For any other support kindly get in touch with us at 9811801977.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";

                            strBody = strBody + "<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";

                        }
                        else if (objIncident.Siteid ==2)
                        {
                            strBody = strBody + "<br/><br/><b>For any other support, kindly get in touch with us at +912266326582 and 6587 or +91 9820831745 (24/7)<br/><br/> In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Name & Contact Details</b><br/><br/><b>Maruti Aldar : 6587</b><br/><b>Ranjana Kamle : 6587</b><br/><b>Brijesh Singh: 6587</b><br/>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b>  Trident NarimanPoint IT Support Desk, Ext. 6587 </b>";

                        }
                        else if (objIncident.Siteid == 3)
                        {
                            strBody = strBody + "<br/><br/><b>For any other support kindly get in touch with us at +919930455789 and Extn:7411 / 7412, +917875551291 or at +912266727411/12<br/><br/> In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Tier 1:  Darshan Trivedi – (+91 9819404011)</b><br/><b>Tier 2: Sudhir Nate (+91 9930455714), Jignesh Patel (+91 9987228227)</b><br/><b>Tier 3: Apurv Sharma (+91 9930455781)</b>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident BandraKurla IT Support, Ext. 7411 / 7412 </b>";
                        }
                        else if (objIncident.Siteid == 4)
                        {
                            strBody = strBody + "<br/><br/><b>For any other support kindly get in touch with us at +918041358518, Extn:8516 / 8517 or email at itsupport.tobl@oberoihotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Chethan Kumar. J</b><br/><b>Chethankumar.j@oberoihotels.com</b><br/><b>System Administrator</b>";
                            strBody = strBody + "<br/><b>91-9916033777</b><br/><br/><b>Yunus Khatib</b><br/><b>Yunus.khatib@oberoihotels.com</b><br/><b>Systems Manager</b><br/><b>91-9886058585</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> The Oberoi Bangalore IT Support, Ext. 8546 / 8517 </b>";
                        }
                        else if (objIncident.Siteid == 5)
                        {
                            strBody = strBody + "<br/><br/> <b>For any other support kindly get in touch with us at +91 33 2249 2323 2323 or at +919831519900/ arindam.banerjee@oberoihotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Arindam Banerjee </b><br/><b>Systems Manager</b><br/><b>The Oberoi Grand</b>";
                            strBody = strBody + "<br/><b>Email: arindam.banerjee@oberoihotels.com</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> The Oberoi Grand Kolkata IT Support </b>";
                        }
                        else if (objIncident.Siteid == 6)
                        {
                            //strBody = strBody + "<br/><br/> <b>For any other support kindly get in touch with the </b><br/><br/><b>IT Support team on Extension 6252,Direct Number +91 40 6603 6252,Mobile Number + 91  88860 48662</b><br/><br/><b>Telephone Support staff  on  Extension 6253, Direct Number +91 40 6603 6253, Mobile Number +91 88860 48663</b><br/><br/><b>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b>";
                            //strBody = strBody + "<br/><b>IT Supervisor on extension 6251 (or) +91 40 6603 6251</b><br/><b>IT Manager on extension 6250   (or) +91 40 6603 6250 </b>";
                            //    //<br/><br/><b>Name of Contact</b><br/><br/><b>Manoj Kumar</b><br/><b>Shashikanth. J</b><br/><b>Vivekanand Kaatpally</b><br/><br/><b>All the above engineers are available in the above extension number only except</b>";
                            ////strBody = strBody + "<br/><br/><b>Dasani Malla Reddy</b><br/><br/><b>Extension 6253 </b><br/><b>Direct Number +91 40 6603 6253 </b><br/><br/><b>Mobile Number + 91  88860 48663</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident Hyderabad IT Support </b>";
                            //strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident Hyderabad IT Support </b>";
                            strBody = strBody + "<br/><br/> For any other support kindly get in touch with the <br/><br/>IT Support team &nbsp&nbsp&nbsp&nbsp on Extension 6252,Direct Number +91 40 6603 6252,Mobile Number + 91  88860 48662<br/><br/>Telephone Support staff &nbsp&nbsp&nbsp&nbsp on  Extension 6253, Direct Number +91 40 6603 6253, Mobile Number +91 88860 48663<br/><br/>If your queries are unresolved, please call us at the following extension / mobile numbers:";
                            strBody = strBody + "<br/><br/>IT Supervisor &nbsp&nbsp&nbsp&nbsp&nbsp on extension 6251 (or) +91 40 6603 6251<br/>IT Manager &nbsp&nbsp&nbsp&nbsp on extension 6250   (or) +91 40 6603 6250 ";
                            strBody = strBody + "<br/><br/>Yours sincerely,<br/><br/>  Trident Hyderabad IT Support ";

                        }
                        else if (objIncident.Siteid == 7)
                        {
                            //strBody = strBody + "<br/><br/>For any other support kindly get in touch with us at 9811801977.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                            strBody = strBody + "<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                        }
                        else if (objIncident.Siteid == 8)
                        {
                            strBody = strBody + "<br/><br/><b>For any other support kindly get in touch with us at Extn:8271 or at +919962218422/ itsupport.ttch@tridenthotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Satheesh Kumar.S,</b><br/><b>Extn: 8270</b><br/><b>Mobile: +919884398638</b><br/><b>Email: satheesh.kumar@tridenthotels.com</b>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident Chennai IT Support, Ext. 8271 </b>";
                        }
                        else if (objIncident.Siteid == 9)
                        {
                            strBody = strBody + "<br/><br/><b>For any other support kindly get in touch with us at +911123890505, Extn:2370 or at +911123906180/81<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Pawan Suman & Contact Details +91 7838651733 with email address pawan.suman@maidenshotel.com</b>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b>  Maidens Hotel IT Support, Ext, 2370 </b>";
                        }
                        else
                        {
                            strBody = strBody + "<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>";
                            strBody = strBody + "<br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                            //strBody = strBody + "<br/><br/>For any other support kindly get in touch with us at 9811801977.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";

                        }
                    LogMessage("Before mail send(Call Open)");
                    obj.Body = strBody;
                    obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                    obj.SentMail();
                    string varPriority = Resources.MessageResource.strPriorityHigh.ToString();
                    if (objPriority.Priorityid != 0)
                    {
                        if (objPriority.Name.ToLower() == varPriority.ToLower())
                        {
                            SentMailToSDM(objSite.Siteid, incidentid, objUser.Userid);
                        }
                    }
                 }
            }
            //if (objC_info.Emailid != null)
            //{
            //    obj.From = Resources.MessageResource.strAdminEmail.ToString();
            //    obj.To = objC_info.Emailid;
            //    obj.Subject = " New Call Logged. Ticket Id : " + incidentid;
            //    obj.Body = "Dear User,<br/> Thank you for contacting Service desk, please find below the Ticket Id details for your future reference.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            //    obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            //   //obj.SentMail();
            //    string varPriority = Resources.MessageResource.strPriorityHigh.ToString();
            //    if (objPriority.Priorityid != 0)
            //    {
            //        if (objPriority.Name.ToLower() == varPriority.ToLower())
            //        {
            //            SentMailToSDM(objSite.Siteid, incidentid, objUser.Userid);
            //        }
            //    }
            //}
        }
        if (strStatusClose.ToLower() == status.ToLower())
        {
            foreach (UserEmail obj1 in colemailid)
            {
                if (obj1.Emailid != null)
                {
                    int id = Convert.ToInt32(objIncident.Incidentid);
                    string varServerName1;
                    string varfeedbackmode="0";
                    varServerName1 = Resources.MessageResource.serverNameForChangePage.ToString();
                    //added by lalit to check feedback mode. feedback should add in mail or not.
                    varfeedbackmode = Resources.MessageResource.UserFeedbackmode.ToString(); ;
                    string url11;
                    url11 = "http://" + varServerName1 + "/"+ getpath()+"/LoginPageAccess/CustomerFeedback.aspx?userid=" + userid+"&Clid="+objIncident.Incidentid;
                    //url11 = "../LoginPageAccess/CustomerFeedback.aspx?userid=" + userid + "&Clid=" + objIncident.Incidentid;
                    if (objC_info.Emailid != null)
                    {
                        //string url;
                        //url = "<a  href=" + url11 + "&userid=" + objC_info.Firstname + " ' onclick=window.open()>Your Feedback</a>";
                        string url = "<a  href=" + url11 + " onclick=window.open()>Your Feedback</a>";
                        obj.From = Resources.MessageResource.strAdminEmail.ToString();
                        obj.To = obj1.Emailid;
                        /////////////////////////////////////////added on 04July13 02:18PM
                        #region Define Regards and ContactNo for differenct Sites
                        string Regards = "";
                        string Contactno = "";
                        if (objIncident.Siteid == 1) { Regards = "EIH Central Helpdesk"; Contactno = "+911123890505, Extn:2180 / 2181"; }
                        if (objIncident.Siteid == 2) { Regards = "Trident NarimanPoint IT Support Desk, Ext. 6587"; Contactno = "+912266326582 and 6587 or +91 9820831745 (24/7)"; }
                        if (objIncident.Siteid == 3) { Regards = "Trident BandraKurla IT Support, Ext. 7411 / 7412"; Contactno = "+919930455789 and Extn:7411 / 7412, +917875551291 or at +912266727411/12"; }
                        if (objIncident.Siteid == 4) { Regards = "The Oberoi Bangalore IT Support, Ext. 8546 / 8517 "; Contactno = "+918041358518, Extn:8516 / 8517"; }
                        if (objIncident.Siteid == 5) { Regards = "The Oberoi Grand Kolkata IT Support"; Contactno = "+91 33 2249 2323 2323 or at +919831519900"; }
                        if (objIncident.Siteid == 6) { Regards = "Trident Hyderabad IT Support"; Contactno = "+91 40 6603 6252 and 6252 or + 91  88860 48662"; }
                        if (objIncident.Siteid == 7) { Regards = "EIH Central Helpdesk"; Contactno = "9811801977"; }
                        if (objIncident.Siteid == 8) { Regards = "Trident Chennai IT Support, Ext. 8271"; Contactno = "Extn:8271 or at +919962218422"; }
                        if (objIncident.Siteid == 9) { Regards = "Maidens Hotel IT Support, Ext, 2370"; Contactno = "+911123890505, Extn:2370 or at +911123906180/81"; }
                        #endregion

                        ///////////////////////////////////////////end

                        obj.Subject = "Call Closed Ticket id : " + incidentid;
                        LogMessage("Call Closed TicketId" + incidentid);
                        //added by lalit
                        if (varfeedbackmode == "0") //0 means default mode where user will not recieve link in mail to give feedback
                        {
                            obj.Body = "Dear " + objC_info.Firstname
                            + ",<br/><br/> <b>Incident Status:</b> Issue Resolved and call closed by&nbsp;<b>"
                            + objtech.Username + "</b>&nbsp;on&nbsp;<b>"
                            + objIncident.Completedtime + ".<br/><br/></b>We are pleased to confirm that the Service Call reported by you has been attended and resolved, should there be any further questions or queries, please do not hesitate to contact the Service Desk." + "<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;:</b> "
                            + objIncident.Createdatetime + "<br/><b>Closed Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objIncident.Completedtime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objIncident.Description + "<br/><b>Resolution&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objIncidentResolution.Resolution + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objUser.Username + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                            + objC_info.Emailid;
                            if (objIncident.Siteid == 1)
                            {
                                obj.Body = obj.Body + @"<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>
                                <br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                            }
                            else if (objIncident.Siteid == 2)
                            {
                                obj.Body = obj.Body + @"<br/><br/> <b>For any other support, kindly get in touch with us at +912266326582 and 6587 or +91 9820831745 (24/7)<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Name & Contact Details</b><br/><br/><b>Maruti Aldar : 6587</b><br/><b>Ranjana Kamle : 6587</b><br/><b>Brijesh Singh: 6587</b><br/>
                                   <br/><br/><b>Yours sincerely,</b><br/><br/> <b>  Trident NarimanPoint IT Support Desk, Ext. 6587 </b>";
                            }
                            else  if (objIncident.Siteid == 3)
                            {
                                obj.Body = obj.Body + @"<br/><br/><b>For any other support kindly get in touch with us at +919930455789 and Extn:7411 / 7412, +917875551291 or at +912266727411/12<br/><br/> <b>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/>Tier 1:  Darshan Trivedi – (+91 9819404011)</b><br/><b>Tier 2: Sudhir Nate (+91 9930455714), Jignesh Patel (+91 9987228227)</b><br/><b>Tier 3: Apurv Sharma (+91 9930455781)</b>
                                <br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident BandraKurla IT Support, Ext. 7411 / 7412 </b>";
                            }
                            else if (objIncident.Siteid == 4)
                            {
                                obj.Body = obj.Body + @"<br/><br/> <b>For any other support kindly get in touch with us at +918041358518, Extn:8516 / 8517 or email at itsupport.tobl@oberoihotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Chethan Kumar. J</b><br/><b>Chethankumar.j@oberoihotels.com</b><br/><b>System Administrator</b>
                                <br/><b>91-9916033777</b><br/><br/><b>Yunus Khatib</b><br/><b>Yunus.khatib@oberoihotels.com</b><br/><b>Systems Manager</b><br/><b>91-9886058585</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> The Oberoi Bangalore IT Support, Ext. 8546 / 8517 </b>";
                            }
                            else if (objIncident.Siteid == 5)
                            {
                                obj.Body = obj.Body + @"<br/><br/><b>For any other support kindly get in touch with us at +91 33 2249 2323 2323 or at +919831519900/ arindam.banerjee@oberoihotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Arindam Banerjee </b><br/><b>Systems Manager</b><br/><b>The Oberoi Grand</b>
                                <br/><b>Email: arindam.banerjee@oberoihotels.com</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> The Oberoi Grand Kolkata IT Support </b>";
                            }
                            else if (objIncident.Siteid == 6)
                            {
                                // obj.Body = obj.Body + @"<br/><br/> <b>For any other support kindly get in touch with the IT Support team on  <br/><br/>Extension 6252  </b><br/><br/><b>Direct Number +91 40 6603 6252 </b><br/><b>Mobile Number + 91  88860 48662</b><br/><br/><b>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b>
                                // <br/><b>IT Supervisor on extension 6251 (or) +91 40 6603 6251</b><br/><b>IT Manager on extension 6250   (or) +91 40 6603 6250 </b><br/><br/><b>Name of Contact</b> <br/><br/><b>Manoj Kumar</b><br/><b>Shashikanth. J</b><br/><b>Vivekanand Kaatpally</b><br/><br/><b>All the above engineers are available in the above extension number only except</b>
                                // <br/><br/><b>Dasani Malla Reddy</b><br/><br/><b>Extension 6253 </b><br/><b>Direct Number +91 40 6603 6253 </b><br/><br/><b>Mobile Number + 91  88860 48663</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident Hyderabad IT Support </b>";
                                obj.Body = obj.Body + @"<br/><br/> For any other support kindly get in touch with the <br/><br/>IT Support team &nbsp&nbsp&nbsp&nbsp on Extension 6252,Direct Number +91 40 6603 6252,Mobile Number + 91  88860 48662<br/><br/>Telephone Support staff &nbsp&nbsp&nbsp&nbsp on  Extension 6253, Direct Number +91 40 6603 6253, Mobile Number +91 88860 48663<br/><br/>If your queries are unresolved, please call us at the following extension / mobile numbers:
                                <br/><br/>IT Supervisor &nbsp&nbsp&nbsp&nbsp&nbsp on extension 6251 (or) +91 40 6603 6251<br/>IT Manager &nbsp&nbsp&nbsp&nbsp on extension 6250   (or) +91 40 6603 6250
                                <br/><br/>Yours sincerely,<br/><br/>  Trident Hyderabad IT Support ";
                            }
                            else if (objIncident.Siteid == 7)
                            {
                                obj.Body = obj.Body + @"<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>
                                <br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                            }
                            else if (objIncident.Siteid == 8)
                            {
                                obj.Body = obj.Body + @"<br/><br/><b>For any other support kindly get in touch with us at Extn:8271 or at +919962218422/ itsupport.ttch@tridenthotels.com<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Satheesh Kumar.S,</b><br/><b>Extn: 8270</b><br/><b>Mobile: +919884398638</b><br/><b>Email: satheesh.kumar@tridenthotels.com</b>
                                <br/><br/><b>Yours sincerely,</b><br/><br/> <b> Trident Chennai IT Support, Ext. 8271 </b>";
                            }
                            else if (objIncident.Siteid == 9)
                            {
                                obj.Body = obj.Body + @"<br/><br/><b>For any other support kindly get in touch with us at +911123890505, Extn:2370 or at +911123906180/81<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>Pawan Suman & Contact Details +91 7838651733 with email address pawan.suman@maidenshotel.com</b>
                              <br/><br/><b>Yours sincerely,</b><br/><br/> <b>  Maidens Hotel IT Support, Ext, 2370 </b>";
                            }
                             else
                             {
                                 obj.Body = obj.Body + @"<br/><br/> <b>For any other support, kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<br/><br/>In case your queries unresolved or not satisfactory  kindly reach to below escalation matrix:</b><br/><br/><b>1st Level : Arshad.Ali@oberoigroup.com, Ext: 2259 or +919999969434</b><br/><b>2nd Level : Ashish.Khanna@oberoigroup.com, Ext: 2178 or +919871164411</b><br/><b>3rd Level : Rajesh.Chopra@oberoigroup.com, Ext: 2175 or +919810079140</b><br/>
                                <br/><br/><b>Yours sincerely,</b><br/><br/> <b> EIH Central Helpdesk </b>";
                             }
                                //+ "<br/><br/> For any other support, kindly get in touch with us at "
                                //+ Contactno + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b>"
                                //+ Regards + "</b>";
                        }
                        else
                        {
                                obj.Body = "Dear " + objC_info.Firstname 
                                + ",<br/><br/> <b>Incident Status:</b> Issue Resolved and call closed by&nbsp;<b>" 
                                + objtech.Username + "</b>&nbsp;on&nbsp;<b>" 
                                + objIncident.Completedtime + ".<br/><br/></b>We are pleased to confirm that the Service Call reported by you has been attended and resolved, should there be any further questions or queries, please do not hesitate to contact the Service Desk." + "<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;:</b> " 
                                + objIncident.Createdatetime + "<br/><b>Closed Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objIncident.Completedtime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                + objIncident.Description + "<br/><b>Resolution&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                + objIncidentResolution.Resolution + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objUser.Username + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objC_info.Emailid + "<br/><br/> For any other support, kindly get in touch with us at "
                                + Contactno + ".<br/><br/>To give feedback click on "
                                + url + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b>"
                                + Regards + "</b>";
                        }
                        LogMessage("Before mail send(Call Closed)");
                        obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                        obj.SentMail();
                    }
                }
            }
            //int id = Convert.ToInt32(objIncident.Incidentid);
            //string varServerName1;
            //varServerName1 = Resources.MessageResource.serverNameForChangePage.ToString();
            //// varServerName = "10.80.0.15";
            //string url11;
            //url11 = "http://" + varServerName1 + "/BESTN/LoginPageAccess/CustomerFeedback.aspx?incident=" + id;
            //if (objC_info.Emailid != null)
            //{
            //    string url;
            //    url = "<a  href=" + url11 + "&userid=" + objC_info.Firstname + " ' onclick=window.open()>Your Feedback</a>";
            //    obj.From = Resources.MessageResource.strAdminEmail.ToString();
            //    obj.To = objC_info.Emailid;
            //    obj.Subject = "Call Closed Ticket id : " + incidentid;
            //    obj.Body = "Dear User,<br/> <b>Complaint Status:</b>Problem solved and call closed by&nbsp;<b>" + objtech.Username + "</b>&nbsp;on&nbsp;<b>" + objIncident.Completedtime + "</b>.We are pleased to inform you that your reported Service Call has been attended and problem solved as informed by our engineer.<br/>Should there be any further questions or queries, please do not hesitate to contact the Service Desk on 0120 4393941, quoting your Ticket Reference Number.   " + "<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "</br><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Your Feedback</b><br/><br/>" + url + "<br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            //    obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            //   // obj.SentMail();
           //}
        }
    }

    public void LogMessage(string sMsg)
    {
        File.AppendAllText(@"C:\ScheduledService.log", sMsg + Environment.NewLine);
    }

    public void SentFeedbackmailToUser(int userid, string Emailid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string varServerName = Resources.MessageResource.serverNameForChangePage.ToString();
        string url11;
        url11 = "http://" + varServerName + "/" + getpath() + "/LoginPageAccess/CustomerFeedback.aspx?userid=" + userid;

        string url = "<a  href=" + url11 + " onclick=window.open()>Your Feedback</a>";
        obj.From = Resources.MessageResource.strAdminEmail.ToString();
        obj.To = Emailid;
        obj.Subject = "User Survey";
        obj.Body = "Dear User,<br/> Please provide the feedback for the user <br/>" + url + "</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
        obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
        obj.SentMail();
    }
    public string getpath()
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        string del = string.Empty;
        if (url.Contains("/"))
        {
            del = "/";
        }
        string[] splitUrl = url.Split(del.ToCharArray());
        string applicationname = splitUrl[1].ToString();
        return applicationname;
    }
    public void SentmailTechnician(int technicianid, int incidentid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        objIncident = objIncident.Get_By_id(incidentid);
        objSite = objSite.Get_By_id(objIncident.Siteid);
        objIncidentStates = objIncidentStates.Get_By_id(incidentid);
        objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);
        objUser = objUser.Get_By_id(objIncident.Requesterid);
        objtech = objtech.Get_By_id(technicianid);
        objSDE = objSDE.Get_By_id(objIncident.Createdbyid);
        objC_info = objC_info.Get_By_id(technicianid);
        objUserInfo = objUserInfo.Get_By_id(objIncident.Requesterid);

        if (objC_info.Emailid != null)
        {
            obj.To = objC_info.Emailid;
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            if (objIncident.Siteid == 1)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +911123890505, Extn:2180 / 2181  or at +911123906180/81.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>EIH Central Helpdesk <b></b>";
            }
            if (objIncident.Siteid == 2)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +912266326582 and 6587 or +91 9820831745 (24/7).<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>Trident NarimanPoint IT Support Desk, Ext. 6587<b></b>";
            }
            if (objIncident.Siteid == 3)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +919930455789, +917875551291 or at +912266727411/12.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>Trident BandraKurla IT Support, Ext. 7411 / 7412<b></b>";
            }
            if (objIncident.Siteid == 4)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +918041358518, Extn:8516 / 8517.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>The Oberoi Bangalore IT Support, Ext. 8546 / 8517 <b></b>";
            }
            if (objIncident.Siteid == 5)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +912266326582 and 6587 or +91 9820831745 (24/7).<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>The Oberoi Grand Kolkata IT Support<b></b>";
            }
            if (objIncident.Siteid == 6)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at Ext: 6252 or at +91 40 6603 6252 and + 91  88860 48662<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>Trident Hyderabad IT Support<b></b>";
            }
            if (objIncident.Siteid == 7)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at 9811801977.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>EIH Central Helpdesk<b></b>";
            }
            if (objIncident.Siteid == 8)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at Extn:8271 or at +919962218422.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>Trident Chennai IT Support, Ext. 8271<b></b>";
            }
            if (objIncident.Siteid == 9)
            {
                obj.Body = @"Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at +911123890505, Extn:2370 or at +911123906180/81.<b></b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/>Maidens Hotel IT Support<b></b>";
            }



            obj.Subject = " New Call Assigned to you. Ticket id : " + incidentid;
            
            obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();
        }

    }
    public void SentMailToSDM(int siteid, int incidentid, int requesterid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        int FlagUser;
        string varRole = Resources.MessageResource.strSDMRole.ToString();
        int roleid;
        roleid = objRole.Get_By_RoleName(varRole);
        colUser = objUser.Get_All_By_Role(roleid);
        foreach (UserLogin_mst objusr in colUser)
        {

            FlagUser = objUserToSiteMapping.Get_By_Id(objusr.Userid, siteid);
            if (FlagUser != 0)
            {
                objIncident = objIncident.Get_By_id(incidentid);
                objSite = objSite.Get_By_id(objIncident.Siteid);
                objIncidentStates = objIncidentStates.Get_By_id(incidentid);
                objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);

                UserLogin_mst obju = new UserLogin_mst();
                UserLogin_mst objReq = new UserLogin_mst();
                obju = obju.Get_By_id(objUserToSiteMapping.Userid);
                objC_info = objC_info.Get_By_id(objusr.Userid);
                objReq = objReq.Get_By_id(requesterid);
                ContactInfo_mst objReqContInfo = new ContactInfo_mst();
                objReqContInfo = objReqContInfo.Get_By_id(objReq.Userid);

                obj.From = Resources.MessageResource.strAdminEmail.ToString();
                obj.To = objC_info.Emailid;
                obj.Subject = "High Priority Call. Ticket Id: " + incidentid;
                obj.Body = "Dear Sir/Madam,<br/>High Priority Call has been logged, please find below the Complaint  details .<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReq.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReqContInfo.Emailid + "<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
                obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                obj.SentMail();


            }

        }

    }
    public void SentMailToPManager(int solutionid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Solution_mst objSolution = new Solution_mst();
        SolutionCreator objSolutionCreator = new SolutionCreator();
        objSolution = objSolution.Get_By_id(solutionid);
        objSolutionCreator = objSolutionCreator.Get_By_id(solutionid);
        UserLogin_mst objUserCreator = new UserLogin_mst();
        objUserCreator = objUserCreator.Get_By_id(objSolutionCreator.Createdby);
        int FlagUser;
        string varRole = Resources.MessageResource.strPManagerRole.ToString();
        int roleid;
        roleid = objRole.Get_By_RoleName(varRole);
        colUser = objUser.Get_All_By_Role(roleid);
        foreach (UserLogin_mst objusr in colUser)
        {

            objC_info = objC_info.Get_By_id(objusr.Userid);
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            obj.To = objC_info.Emailid;
            obj.Subject = "New Solution Added. Solution Id : " + solutionid;
            obj.Body = "Dear Sir/Madam,<br/>A New Solution has been Added.Please find the New Solution details .<br/><br/><b>Solution Details : </b> <br/><br/><b>Solution Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Solutionid + "<br/><b>Title &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Title + " <br/><b>Added By &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUserCreator.Username + "<br/><b>Created Date &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolutionCreator.CreateDatetime + "<br/><b>Content&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Content + "<br/><br/>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();

        }


    }
    public void SentMailToTechnicianForProblemCall(int problemid, int userid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Problem_mst objProblem = new Problem_mst();
        objUser = objUser.Get_By_id(userid);
        ContactInfo_mst objCont_info = new ContactInfo_mst();
        objCont_info = objCont_info.Get_By_id(objUser.Userid);
        objProblem = objProblem.Get_By_id(problemid);
        objPriority = objPriority.Get_By_id(objProblem.Priorityid);
        UserLogin_mst objReq = new UserLogin_mst();
        objReq = objReq.Get_By_id(objProblem.Requesterid);
        ContactInfo_mst objReqCont = new ContactInfo_mst();
        objReqCont = objReqCont.Get_By_id(objReq.Userid);
        objSDE = objSDE.Get_By_id(objProblem.CreatedByid);

        if (objCont_info.Emailid != null)
        {
            obj.To = objCont_info.Emailid;
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            obj.Subject = " New Problem Call Assigned to you. Problem Id : " + problemid;
            obj.Body = "Dear&nbsp;" + objUser.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Problem Details : </b> <br/><br/><b>Problem Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.ProblemId + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.title + " <br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objProblem.CreateDatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReq.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objReqCont.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objReqCont.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReqCont.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();

        }



    }
    public void SentMailToChangeCommittee(int changeid, int changetypeid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Cab_mst Objcabmember = new Cab_mst();
        ObjChange = ObjChange.Get_By_id(changeid);

        BLLCollection<Cab_mst> colmembers = new BLLCollection<Cab_mst>();
        UserLogin_mst objUserCreator = new UserLogin_mst();

        int FlagUser;

        int roleid;
        string varServerName;
        varServerName = Resources.MessageResource.serverNameForChangePage.ToString();

        string url11;
        //////////////change done by meenakshi
        //url11 = "http://" + varServerName + "/BEST/LoginPageAccess/ApproveorRejectChangeRequest.aspx?changeid=" + changeid;
        url11 = "http://" + varServerName + "/" + getpath() + "/LoginPageAccess/ApproveorRejectChangeRequest.aspx?changeid=" + changeid;

        ///////////////end
        colmembers = Objcabmember.Get_All_By_ChangeTypeid(changetypeid);



        string url;
        foreach (Cab_mst objmember in colmembers)
        {
            url = "<a  href=" + url11 + "&userid=" + objmember.Membername + " onclick=window.open()>Click Here For Approval</a>";

            //url = "<a id=" + mylink + " runat=" + varServerName + " href=" + url11 + "&userid=" + objmember.Membername + " 'onclick=window.open()></a>";
            //////////change don eby meenakshi

            objUserCreator = objUserCreator.Get_By_id(ObjChange.CreatedByID);
            ///////////////end
            obj.From = Resources.MessageResource.strAdminEmail.ToString();

            obj.To = objmember.Emailid;
            obj.Subject = "New Change Added. Change Id : " + changeid;
            obj.Body = "Dear Sir/Madam,<br/>A New Change has been requested.Please.<br/><br/><b>Solution Description & Plan of Action : </b> <br/><br/><b>Changeid Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Changeid + "<br/><b>Title &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Title + " <br/><b>Added By &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUserCreator.Username + "<br/><b>Created Date &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Createdtime + "<br/><b>Solution Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Description + "<br/><br/>This is an auto generated mail. Please do not reply.</b><br/><br/></b><br/><b>Kindly Click the following link to Aprove or Reject the Change Request. <br></br>" + url + " <b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            ////obj.Body="Dear Sir/Madam,<br/>A New Change has been requested.Please.<br/><br/><b>Solution Details : </b> <br/><br/><b>Changeid Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>10<br/><b>Title &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>testcall done by meenakshi <br/><b>Added By &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>1<br/><b>Created Date &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>8/30/2012 4:45:17 PM<br/><b>Content&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>testcall done by meenakshi<br/><br/>This is an auto generated mail. Please do not reply.</b><br/><br/></b><br/><b>Kindly Click the following link to Aprove or Reject the Change Request. <br></br> "<a  href="http://10.80.0.136/GPI/LoginPageAccess/ApproveorRejetChangeRequest.aspx?changeid=10&userid=meenakshi 'onclick=window.open()">Click Here For Approval</a>"
            obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();


        }


    }

}
