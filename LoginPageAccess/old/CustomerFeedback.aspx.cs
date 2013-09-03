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

public partial class WithoutLoginPageAccess_CustomerFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string Feedback;
    CustomerFeedback ObjCustomerfeedback = new CustomerFeedback();
    protected void btnFeedback_Click(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int userid = Convert.ToInt32(Request.QueryString[0]);
            ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Incidentid(userid);

            if (satisfiedrdbutton.Checked == true)
            {

                Feedback = "Satisfied";

            }
            if (verysatisfied.Checked == true)
            {
                Feedback = "Very Satisfied";
            }
            if (Rddisatisfied.Checked == true)
            {
                Feedback = "Dissatisfied";
            }
            if (Rdverydissatisfied.Checked == true)
            {
                Feedback = "Very Dissatisfied";
            }
            if (ObjCustomerfeedback.Id == 0)
            {
                ObjCustomerfeedback.Id = Convert.ToInt32(Request.QueryString[0]);
                ObjCustomerfeedback.Feedback = Feedback;
                ObjCustomerfeedback.Insert();
            }

            string myScript;
            myScript = "<script language=javascript></script>";
            myScript = "<script language=javascript>CloseWindow();</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshParent();", "refreshParent();", true);
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
