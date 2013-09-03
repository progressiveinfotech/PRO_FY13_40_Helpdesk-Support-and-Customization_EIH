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
using System.Web.Mail;



using System.Collections.Generic;  
 


public partial class test_testGeneric : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void Display<GenericArray>(GenericArray[] array)
    {
        //for (int i = 0; i < array.Length; i++)
          //Response.Write(array[i]);
    }

    protected void btnClick_Click(object sender, EventArgs e)
    {
      
        string myScript;
        myScript = "<script language=javascript> var Flag= confirm('User Does not Exist,Do You Want to Create User');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

        int flag;
        flag = 1;
        if (flag == 2)
        { check(); }
    

    }
    protected void check()
    {
        Response.Redirect("http://www.google.com");
    
    }
    protected void txt_TextChanged(object sender, EventArgs e)
    {
        string myScript;
        myScript = "<script language=javascript> var Flag= confirm('User Does not Exist,Do You Want to Create User');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

    }
    protected void txt2_TextChanged(object sender, EventArgs e)
    {
        string myScript;
        myScript = "<script language=javascript> var Flag= confirm('User Does not Exist,Do You Want to Create User');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProcessEscalateEmail objPro = new ProcessEscalateEmail();
        objPro.GetAllCalls();
    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();

        msg.To = "sumit.gupta@progressive.in";

        msg.From = "sumit.gupta@progressive.in"; 

        msg.Subject = "test";

        msg.Body = "test";

        SmtpMail.SmtpServer = "mail.progressive.in";

        SmtpMail.Send(msg); 
    

    }
    //protected void btnNotification_Click(object sender, EventArgs e)
    //{
    //    EscalateContractNotification objEscalate = new EscalateContractNotification();
    //    objEscalate.GetAllContract();


    //}
}
