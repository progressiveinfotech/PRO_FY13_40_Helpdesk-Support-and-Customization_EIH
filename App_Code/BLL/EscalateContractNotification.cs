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
/// Summary description for EscalateContractNotification
/// </summary>
public class EscalateContractNotification
{
    Contract_mst objContract = new Contract_mst();
    BLLCollection<Contract_mst> colContract = new BLLCollection<Contract_mst>();
    ContractNotification objContractNotification = new ContractNotification();
    SentEmail objEmail = new SentEmail();

	public EscalateContractNotification()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void GetAllContract()
    {
        int FlagTotalTime;
        colContract = objContract.Get_All_Escalate_Notification();
        foreach (Contract_mst obj in colContract)
        {
            FlagTotalTime = objContract.Get_Contract_Notification_Time(obj.Contractid);
            if (FlagTotalTime <= 0 )
            {
                objContractNotification = objContractNotification.Get_By_id(obj.Contractid);
                objContractNotification.Sendnotification = true ;
                objContractNotification.Contractid = obj.Contractid;
               
                string varemail = objContractNotification.Sentto;
                string[] arrEmail = varemail.Split(',');
                int lengthCount = Convert.ToInt32(arrEmail.Length.ToString());
                for (int i = 0; i < lengthCount - 1; i++)
                {
                    string emailId = arrEmail[i].ToString();
                    if (emailId != "," && emailId != "")
                    {

                               
                                objEmail.To = emailId;
                                objEmail.From = Resources.MessageResource.strEmailFromLevel1Escalate.ToString();
                                objEmail.Subject = "Contract is About to Expire  -" + obj.Contractname;
                                objEmail.Body = "Dear Sir, The Contract " + obj.Contractname + " is going to expire on  " + obj.Activeto  + " Please send mail to Renew Contract.  Thanks & Regards Admin";
                                objEmail.SmtpServer = Resources.MessageResource.strMailServer.ToString();
                                objEmail.SentMail();
                          
                        
                      }

                    }
                 objContractNotification.Update();

                }


            }
        
        
        
        }
    
    
    

}
