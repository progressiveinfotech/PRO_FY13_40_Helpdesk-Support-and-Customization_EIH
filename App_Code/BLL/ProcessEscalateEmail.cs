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

/// <summary>
/// Summary description for ProcessEscalateEmail
/// </summary>
public class ProcessEscalateEmail
{
    #region Declaration  of Objects of Various Classes
    Incident_mst objIncident = new Incident_mst();
    BLLCollection<Incident_mst> colIncident = new BLLCollection<Incident_mst>();
    Status_mst objStatus = new Status_mst();
    RequestType_mst objrequest = new RequestType_mst();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    EscalateLevel1 objLevel1 = new EscalateLevel1();
    EscalateLevel2 objLevel2 = new EscalateLevel2();
    EscalateLevel3 objLevel3 = new EscalateLevel3();
    
    CheckLevel1Escalate objCheckLevel1 = new CheckLevel1Escalate();
    CheckLevel2Escalate objCheckLevel2 = new CheckLevel2Escalate();
    CheckLevel3Escalate objCheckLevel3 = new CheckLevel3Escalate();
    #endregion
    
    public void GetAllCalls()
    {
        #region Declaretion of local variables
        int totalResolutionTimeInMins;
        int totalSpentMinOnCall;
        int totalEscalateEmailLevel1Min;
        int totalEscalateEmailLevel2Min;
        int totalEscalateEmailLevel3Min;
        string status = Resources.MessageResource.strStatusOpen.ToString();
        int statusId = objStatus.Get_By_StatusName(status);
        int requesttypeid = Convert.ToInt32(Resources.MessageResource.strRequestTypeIncident.ToString());
        #endregion

        #region Get All Open Calls,of Incident Type
        colIncident = objIncident.Get_All_For_ProcessEmailEscalate(statusId, requesttypeid);
        #endregion
        #region Process Each Call , and check Time spent on call and Escalation Time
        foreach (Incident_mst obj in colIncident)
        {
            #region Get Total Resolution Time Define for Selected SLA
            totalResolutionTimeInMins = GetResolutionTimeInMins(obj.Slaid);
            #endregion
            #region Get Total time Spent on Call,till now
            totalSpentMinOnCall = obj.Get_TimeSpentonRequest(obj.Incidentid,obj.Siteid,obj.Createdatetime,DateTime.Now.ToString());
            #endregion
            #region Get Total Time Define for Level 1 Escalation to shoot mail
            totalEscalateEmailLevel1Min = GetLevel1EscalationTimeInMins(obj.Slaid);
            #endregion

            #region Check ,If Email Escalation time is defined to shoot mail
            if (totalEscalateEmailLevel1Min > 0)
            {
                #region If Call is not resolved till Email shoot time ,then Sent a mail
                if ((totalSpentMinOnCall + totalEscalateEmailLevel1Min) > totalResolutionTimeInMins)
               {
                   SendEmail(obj.Incidentid, 1, obj.Slaid);
               }
                #endregion
            }
            #endregion
            #region Get Total Time Define for Level 2 Escalation to shoot mail
            totalEscalateEmailLevel2Min = GetLevel2EscalationTimeInMins(obj.Slaid);
            #endregion
            #region Check ,If Email Escalation time is defined to shoot mail
            if (totalEscalateEmailLevel2Min>0)
            {
                #region If Call is not resolved till Email shoot time ,then Sent a mail
                if ((totalSpentMinOnCall + totalEscalateEmailLevel2Min) > totalResolutionTimeInMins)
                {
                    SendEmail(obj.Incidentid, 2, obj.Slaid);

                }
                #endregion
            }
            #endregion

            #region Get Total Time Define for Level 3 Escalation to shoot mail
            totalEscalateEmailLevel3Min = GetLevel3EscalationTimeInMins(obj.Slaid);
            if (totalEscalateEmailLevel3Min>0)
            {
                #region Check ,If Email Escalation time is defined to shoot mail
                if ((totalSpentMinOnCall + totalEscalateEmailLevel3Min) > totalResolutionTimeInMins)
                {
                    SendEmail(obj.Incidentid, 3, obj.Slaid);

                }
                #endregion
            }
            #endregion

        }
        #endregion

    }

    #region Function Definition of Calculate Total Resolution time define for particular SLA
    public int GetResolutionTimeInMins(int slaid)
    {
        int varDays=0;
        int varHours=0;
        int VarMins=0;
        int TotalMins=0;
        objSlaPriority = objSlaPriority.Get_By_id(slaid);
        if (objSlaPriority.Slaid != 0)
        {
            varDays = objSlaPriority.Resolutiondays;
            varHours = objSlaPriority.Resolutionhours;
            VarMins = objSlaPriority.Resolutionmin;
            TotalMins = (varDays * 24 * 60) + (varHours * 60) + VarMins;
        }

        return TotalMins;


    }
    #endregion

    #region Function Definition of Calculate Total Email Escalation  time define for Level 1 Escalation
    public int GetLevel1EscalationTimeInMins(int slaid)
    {
        int varDays = 0;
        int varHours = 0;
        int VarMins = 0;
        int TotalMins = 0;
        objLevel1 = objLevel1.Get_By_Slaid(slaid);
        if (objLevel1.Slaid!=0 )
        {
            varDays = objLevel1.Days;
            varHours = objLevel1.Hours;
            VarMins = objLevel1.Min;
            TotalMins = (varDays * 24 * 60) + (varHours * 60) + VarMins;
        }

        return TotalMins;
    }
    #endregion

    #region Function Definition of Calculate Total Email Escalation  time define for Level 2 Escalation
    public int GetLevel2EscalationTimeInMins(int slaid)
    {
        int varDays = 0;
        int varHours = 0;
        int VarMins = 0;
        int TotalMins = 0;
        objLevel2 = objLevel2.Get_By_Slaid(slaid);
        if (objLevel2.Slaid != 0 )
        {
            varDays = objLevel2.Days;
            varHours = objLevel2.Hours;
            VarMins = objLevel2.Min;
            TotalMins = (varDays * 24 * 60) + (varHours * 60) + VarMins;
        }

        return TotalMins;
    }
    #endregion
    #region Function Definition of Calculate Total Email Escalation  time define for Level 3 Escalation
    public int GetLevel3EscalationTimeInMins(int slaid)
    {
        int varDays = 0;
        int varHours = 0;
        int VarMins = 0;
        int TotalMins = 0;
        objLevel3 = objLevel3.Get_By_Slaid(slaid);
        if (objLevel3.Slaid != 0)
        {
            varDays = objLevel1.Days;
            varHours = objLevel1.Hours;
            VarMins = objLevel1.Min;
            TotalMins = (varDays * 24 * 60) + (varHours * 60) + VarMins;
        }

        return TotalMins;
    }
    #endregion
    #region Definition of SendEmail Function
    protected void SendEmail(int incidentid, int level,int slaid)
    {
        SentEmail objEmail = new SentEmail();
        #region Sent Mail for Level 1 Escalation 
        if (level==1)
      {
            objLevel1 = objLevel1.Get_By_Slaid(slaid);
            if (objLevel1!=null )
            {
                string varemail = objLevel1.Emailid;
                string[] arrEmail = varemail.Split(',');
                int lengthCount = Convert.ToInt32(arrEmail.Length.ToString());
                for (int i = 0; i < lengthCount - 1; i++)
                {
                    string emailId = arrEmail[i].ToString();
                    if (emailId != "," && emailId!="")
                    {
                        objIncident = objIncident.Get_By_id(incidentid);
                        if (objIncident!=null)
                        {
                            objCheckLevel1 = objCheckLevel1.Get_By_id(incidentid);
                            if (objCheckLevel1.Incidentid ==0)
                            {
                                CheckLevel1Escalate obj = new CheckLevel1Escalate();
                                obj.Incidentid = incidentid;
                                obj.Level1escalate = true;
                                obj.Insert();
                                objEmail.To = emailId;
                                objEmail.From = Resources.MessageResource.strEmailFromLevel1Escalate.ToString();
                                objEmail.Subject = "Problem Not Resolve for Call -" + objIncident.Title;
                                objEmail.Body = "Dear Sir, The Current Request is not Solved whose Incident Id is " + objIncident.Incidentid + " and Title of Call is " + objIncident.Title + " Thanks & Regards Admin";
                                objEmail.SmtpServer = Resources.MessageResource.strMailServer.ToString();
                                objEmail.SentMail();
                            }
                            
                                                                                
                        }
                            
                        }
                    
                    }
                
                }
      }
        #endregion
        #region Sent Mail for Level 2 Escalation
        if (level == 2)
        {
            objLevel2 = objLevel2.Get_By_Slaid(slaid);
            if (objLevel2.Slaid  != 0)
            {
                string varemail = objLevel2.Emailid;
                string[] arrEmail = varemail.Split(',');
                int lengthCount = Convert.ToInt32(arrEmail.Length.ToString());
                for (int i = 0; i < lengthCount - 1; i++)
                {
                    string emailId = arrEmail[i].ToString();
                    if (emailId != "," && emailId != "")
                    {
                        objIncident = objIncident.Get_By_id(incidentid);
                        if (objIncident != null)
                        {

                            objCheckLevel2 = objCheckLevel2.Get_By_id(incidentid);
                            if (objCheckLevel2.Incidentid == 0)
                            {
                                CheckLevel2Escalate obj = new CheckLevel2Escalate();
                                obj.Incidentid = incidentid;
                                obj.Level2escalate = true;
                                obj.Insert();
                                objEmail.To = emailId;
                                objEmail.From = Resources.MessageResource.strEmailFromLevel2Escalate.ToString();
                                objEmail.Subject = "Problem Not Resolve for Call -" + objIncident.Title;
                                objEmail.Body = "Dear Sir, The Current Request is not Solved whose Incident Id is " + objIncident.Incidentid + " and Title of Call is " + objIncident.Title + " Thanks & Regards <br/> Admin";
                                objEmail.SmtpServer = Resources.MessageResource.strMailServer.ToString();
                                objEmail.SentMail();
                            
                            }
                                


                            
                        }

                    }

                }

            }
        }
        #endregion
        #region Sent Mail for Level 3 Escalation
        if (level == 3)
        {
            objLevel3 = objLevel3.Get_By_Slaid(slaid);
            if (objLevel3.Slaid  != 0)
            {
                string varemail = objLevel3.Emailid;
                string[] arrEmail = varemail.Split(',');
                int lengthCount = Convert.ToInt32(arrEmail.Length.ToString());
                for (int i = 0; i < lengthCount - 1; i++)
                {
                    string emailId = arrEmail[i].ToString();
                    if (emailId != "," && emailId != "")
                    {
                        objIncident = objIncident.Get_By_id(incidentid);
                        if (objIncident != null)
                        {

                            objCheckLevel3 = objCheckLevel3.Get_By_id(incidentid);
                            if (objCheckLevel3.Incidentid == 0)
                            {
                                CheckLevel3Escalate obj = new CheckLevel3Escalate();
                                obj.Incidentid = incidentid;
                                obj.Level3escalate = true;
                                obj.Insert();

                                objEmail.To = emailId;
                                objEmail.From = Resources.MessageResource.strEmailFromLevel3Escalate.ToString();
                                objEmail.Subject = "Problem Not Resolve for Call -" + objIncident.Title;
                                objEmail.Body = "Dear Sir, The Current Request is not Solved whose Incident Id is " + objIncident.Incidentid + " and Title of Call is " + objIncident.Title + "  Thanks & Regards  Admin";
                                objEmail.SmtpServer = Resources.MessageResource.strMailServer.ToString();
                                objEmail.SentMail();
                            
                            }
                                


                            
                        }

                    }

                }

            }
        }
        #endregion

    }
    #endregion




}
