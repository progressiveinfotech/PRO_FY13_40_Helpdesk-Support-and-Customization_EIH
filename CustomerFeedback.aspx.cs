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
        if (!Page.IsPostBack)
        {
           if (Request.QueryString["userid"] != null)
            {
                int userid = Convert.ToInt16(Request.QueryString[0]);
                if (Request.QueryString["Clid"] != null)
                {
                 
                    int callid = Convert.ToInt16(Request.QueryString["Clid"]);
                    ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Userid_ByIncidentId(userid, callid);
                    GetRemark(userid, callid);
                }
                else
                {
                    ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Incidentid(userid);
                }
            }

            if (ObjCustomerfeedback.Id != 0)
            {
                btnFeedback.Enabled = false;
                satisfiedrdbutton.Enabled = false;
                verysatisfied.Enabled = false;
                Rddisatisfied.Enabled = false;
                Rdverydissatisfied.Enabled = false;
                TextRmk.Enabled = false;
            }

        }
    }
    public string Feedback;
    CustomerFeedback ObjCustomerfeedback = new CustomerFeedback();
    protected void btnFeedback_Click(object sender, EventArgs e)
    {
        if (satisfiedrdbutton.Checked == false && verysatisfied.Checked == false && Rddisatisfied.Checked == false && Rdverydissatisfied.Checked == false)
        {
            Lblmsg.Visible = true;
            Lblmsg.Text = "Please select your feedback";
            return;
        }

        //if (satisfiedrdbutton.Checked == true && verysatisfied.Checked == true && Rddisatisfied.Checked == true && Rdverydissatisfied.Checked == true)
        //{
        //    Lblmsg0.Visible = true;
        //    Lblmsg0.Text = "Your feedback has been saved";
        //    return;
        //}

        int userid = Convert.ToInt16(Request.QueryString["userid"]);
        //////////////Added by lalit. capture querystring of callid in case when user gives
        //feedback by call
        if (Request.QueryString["Clid"] != null)
        {
            int callid = Convert.ToInt16(Request.QueryString["Clid"]);
            ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Userid_ByIncidentId(userid, callid);
        }
        else
        {
            ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Incidentid(userid);
        }
        

        if (satisfiedrdbutton.Checked == true)
        {
            Feedback = "Good";
           

        }
        if (verysatisfied.Checked == true)
        {
            Feedback = "Very Good";
        }
        if (Rddisatisfied.Checked == true)
        {
            Feedback = "Average";
        }
        if (Rdverydissatisfied.Checked == true)
        {
            Feedback = "Poor";
        }
        
        if (ObjCustomerfeedback.Id == 0)
        {
            ObjCustomerfeedback.Id = Convert.ToInt16(Request.QueryString["userid"]);
            ObjCustomerfeedback.Feedback = Feedback;
            if (Request.QueryString["Clid"] != null)
            {
                ObjCustomerfeedback.IncidentId = Convert.ToInt16(Request.QueryString["Clid"]);
                ObjCustomerfeedback.FeedbackType = "CallWise";
                ObjCustomerfeedback.Remark = TextRmk.Text;
                ObjCustomerfeedback.Insert_CallWise();

                Lblmsg0.Visible = true;
                Lblmsg0.Text = "Your Feedback Has Been Submitted";

                btnFeedback.Visible = false;
                satisfiedrdbutton.Visible = false;
                verysatisfied.Visible = false;
                Rddisatisfied.Visible = false;
                Rdverydissatisfied.Visible = false;
                TextRmk.Visible = false;
                labGood.Visible = false;
                labVeryGood.Visible = false;
                labAverage.Visible = false;
                labPoor.Visible = false;
                lblApproved.Visible = false;
                lblRemark.Visible = false;
            }
            else
            {
                ObjCustomerfeedback.FeedbackType = "Default";
                ObjCustomerfeedback.Remark = "Default";
                ObjCustomerfeedback.Insert();
            }
        }
        string myScript;
        myScript = "<script language=javascript></script>";
        myScript = "<script language=javascript>CloseWindow();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshParent();", "refreshParent();", true);
    }
    protected void satisfiedrdbutton_CheckedChanged(object sender, EventArgs e)
    {
        if (satisfiedrdbutton.Checked == true)
        {
            Rmk.Visible = false;
        }
    }
    protected void verysatisfied_CheckedChanged(object sender, EventArgs e)
    {
        if (verysatisfied.Checked == true)
        {
            Rmk.Visible = false;
        }
    }
    protected void Rddisatisfied_CheckedChanged(object sender, EventArgs e)
    {

        if (Rddisatisfied.Checked == true)
        {
            Rmk.Visible = true;
        }
    }
    protected void Rdverydissatisfied_CheckedChanged(object sender, EventArgs e)
    {
        if (Rdverydissatisfied.Checked == true)
        {
            Rmk.Visible = true;
        }
    }
    protected void TextRmk_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GetRemark(int userID, int IncidentID)
    {
        CustomerFeedback ObjCustomerfeedback = new CustomerFeedback();
        ObjCustomerfeedback = ObjCustomerfeedback.Get_By_Userid_ByIncidentId(userID, IncidentID);
        TextRmk.Text=ObjCustomerfeedback.Remark;
        if (TextRmk.Text != "")
        {
            Rmk.Visible = true;
        }
        string Feedback = ObjCustomerfeedback.Feedback;
        if (Feedback == "Good")
        {
            satisfiedrdbutton.Checked = true;
        }
        else if (Feedback == "Very Good")
        {
            verysatisfied.Checked = true;
        }
        else if (Feedback == "Average")
        {
            Rddisatisfied.Checked = true;
        }
        else if (Feedback == "Poor")
        {
            Rdverydissatisfied.Checked = true;
        }
    }
    //Get_By_Userid_ByIncidentId
    //protected void BindRemark(string sSubject)
    //{
    //    string remark;
    //    remark = GetFieldData("Remark", sSubject);
    //    //for ( int i = 0; i < TextRmk.Text; i++)
    //    //{
    //    if (TextRmk.Text.ToString().ToLower() == remark.ToLower())
    //    {
    //        TextRmk.Text = remark;
    //        //break;
    //    }
    //    //}
    //}
    //protected string GetFieldData(string sFieldName, string sString)
    //{
    //    if (sString.Contains(sFieldName))
    //    {
    //        int iPos = sString.IndexOf(sFieldName + "[");
    //        string sTemp = sString.Substring(iPos + (sFieldName + "[").Length, sString.Length - (iPos + (sFieldName + "[").Length));
    //        iPos = sTemp.IndexOf("]");
    //        sTemp = sTemp.Substring(0, iPos);
    //        return sTemp;
    //    }
    //    return "";
    //}

}










