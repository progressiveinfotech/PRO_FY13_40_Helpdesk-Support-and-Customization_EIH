using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;



public partial class test_RCA : System.Web.UI.Page
{
    Incident_mst Objincident = new Incident_mst();
    IncidentStates Objincidentstate = new IncidentStates();
    IncidentResolution Objincidentresoution = new IncidentResolution();
    Category_mst Objcategory = new Category_mst();
    Subcategory_mst objsubcategory = new Subcategory_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Status_mst objstatus = new Status_mst();
    string GetUsername(int userid)
    {
        string username = "";
        objUser = objUser.Get_By_id(userid);
        if (objUser.Userid != 0)
        {
            username = objUser.Username;
        }
        return username;
    }
    protected void Page_Load(object sender, EventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string strStatusClose = Resources.MessageResource.strStatusClose.ToString().Trim();
            string statusString = "";
            int incidentid = Convert.ToInt32(Request.QueryString[0]);
            Objincident = Objincident.Get_By_id(incidentid);
            Objincidentstate = Objincidentstate.Get_By_id(incidentid);
            Objincidentresoution = Objincidentresoution.Get_By_id(incidentid);
            objstatus = objstatus.Get_By_id(Objincidentstate.Statusid);
            statusString = objstatus.Statusname.ToString();
            if (statusString.ToLower() == strStatusClose.ToLower())
            {
                lbltcktno.Text = Objincident.Incidentid.ToString();
                lblcreatedate.Text = Objincident.Createdatetime.ToString();

                if (Objincidentstate.AssignedTime != null)
                {
                    lblstarttime.Text = Objincidentstate.AssignedTime.ToString();
                }
                lblendtime.Text = Objincident.Completedtime.ToString();
                Objcategory = Objcategory.Get_By_id(Objincidentstate.Categoryid);

                lblcomponenteffected.Text = Objcategory.CategoryName.ToString();
                lbldescription.Text = Objincident.Title.ToString();
                string bb = Objincidentresoution.Resolution.ToString();
                string stripped = Regex.Replace(bb, @"<(.|\n)*?>", string.Empty);
                lblresolution.Text = stripped.ToString();
                //bind data to data bound controls and do other stuff
                objUser = objUser.Get_By_id(Objincident.Requesterid);
                lblcustomer.Text = objUser.Username.ToString();
                objUser = objUser.Get_By_id(Objincidentstate.Technicianid);
                lblengineer.Text = objUser.Username.ToString();
                objstatus = objstatus.Get_By_id(Objincidentstate.Statusid);
                lblrcaresult.Text = objstatus.Statusname.ToString();
            }
            Response.Clear(); //this clears the Response of any headers or previous output 
            Response.Buffer = true; //make sure that the entire output is rendered simultaneously

            ///
            ///Set content type to MS Excel sheet
            ///Use "application/msword" for MS Word doc files
            ///"application/pdf" for PDF files
            ///

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter stringWriter = new StringWriter(); //System.IO namespace should be used

            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

            ///
            ///Render the entire Page control in the HtmlTextWriter object
            ///We can render individual controls also, like a DataGrid to be
            ///exported in custom format (excel, word etc)
            ///
            this.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();

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
