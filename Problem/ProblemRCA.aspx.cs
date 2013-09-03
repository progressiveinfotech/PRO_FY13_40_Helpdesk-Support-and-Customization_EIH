using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;

public partial class Problem_ProblemRCA : System.Web.UI.Page
{
    Incident_mst Objincident = new Incident_mst();
    IncidentStates Objincidentstate = new IncidentStates();
    IncidentResolution Objincidentresoution = new IncidentResolution();
    Category_mst Objcategory = new Category_mst();
    Subcategory_mst objsubcategory = new Subcategory_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    Problem_mst ObjProbelm = new Problem_mst();
    Solution_mst Objsolution = new Solution_mst();
    ProblemToSolution objproblemtosolution = new ProblemToSolution();
    ProblemSymptom objproblemsysmptom = new ProblemSymptom();
    ProblemRootcause objrootcause = new ProblemRootcause();
    ProblemImpact objimpact = new ProblemImpact();
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
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string strStatusClose = Resources.MessageResource.strStatusClose.ToString().Trim();
            string statusString = "";
            int problemid = Convert.ToInt32(Request.QueryString[0]);
            ObjProbelm = ObjProbelm.Get_By_id(problemid);
            objrootcause = objrootcause.Get_By_id(problemid);
            objimpact = objimpact.Get_By_id(problemid);
            objstatus = objstatus.Get_By_id(ObjProbelm.Statusid);
            statusString = objstatus.Statusname.ToString();
            if (statusString.ToLower() == strStatusClose.ToLower())
            {


                string ii = objimpact.Description.ToString();
                string stripped4 = Regex.Replace(ii, @"<(.|\n)*?>", string.Empty);
                lblserviceeffected.Text = objimpact.Description.ToString();
                string rr = objrootcause.Description.ToString();
                string stripped1 = Regex.Replace(rr, @"<(.|\n)*?>", string.Empty);
                lblcause.Text = stripped1.ToString();
                objproblemsysmptom = objproblemsysmptom.Get_By_id(problemid);
                string ss = objproblemsysmptom.Description.ToString();
                string stripped3 = Regex.Replace(ss, @"<(.|\n)*?>", string.Empty);
                lblsymptom.Text = stripped3.ToString();
                lbltcktno.Text = ObjProbelm.ProblemId.ToString();
                lblcreatedate.Text = ObjProbelm.CreateDatetime.ToString();
                if (ObjProbelm.AssginedTime != null)
                {
                    lblstarttime.Text = ObjProbelm.AssginedTime.ToString();
                }
                lblendtime.Text = ObjProbelm.Closedatetime.ToString();
                Objcategory = Objcategory.Get_By_id(ObjProbelm.Categoryid);

                lblcomponenteffected.Text = Objcategory.CategoryName.ToString();
                lbldescription.Text = ObjProbelm.title.ToString();
                objproblemtosolution = objproblemtosolution.Get_By_id(ObjProbelm.ProblemId);
                Objsolution = Objsolution.Get_By_id(objproblemtosolution.Solutionid);
                string bb = Objsolution.Solution.ToString();
                string stripped = Regex.Replace(bb, @"<(.|\n)*?>", string.Empty);
                lblresolution.Text = stripped.ToString();
                //bind data to data bound controls and do other stuff
                objUser = objUser.Get_By_id(ObjProbelm.Requesterid);
                lblcustomer.Text = objUser.Username.ToString();
                objUser = objUser.Get_By_id(ObjProbelm.Technicianid);
                lblengineer.Text = objUser.Username.ToString();
                lblrcaresult.Text = "Completed";
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
