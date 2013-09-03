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

public partial class Incident_IncidentResolution : System.Web.UI.Page
{
    IncidentHistory objIncidentHistory = new IncidentHistory();
    BLLCollection<IncidentHistory> colIncidentHistory = new BLLCollection<IncidentHistory>();
    IncidentResolution objIncidentResolution = new IncidentResolution();
    BLLCollection<IncidentResolution> colIncidentResolution = new BLLCollection<IncidentResolution>();
    IncidentHistoryDiff objIncidentHistoryDiff = new IncidentHistoryDiff();
    BLLCollection<IncidentHistoryDiff> colIncidentHistoryDiff = new BLLCollection<IncidentHistoryDiff>();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
       
         //ShowResolution();
        }
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string userName;
            int userid = 0;
            int incidentid = Convert.ToInt32(Session["incidentid"].ToString());

            #region Fetch Current User
            // Fetch Current User and assign to local variable userName
            MembershipUser User = Membership.GetUser();
            userName = User.UserName.ToString();
            #endregion



            #region On the basis of Username ,get Userid by calling Function Get_UserLogin_By_UserName(),via passing parameter Username and organizationid

            if (userName != "")
            {
                objOrganization = objOrganization.Get_Organization();
                objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
                if (objUser.Userid != 0)
                {
                    userid = objUser.Userid;
                }
            }
            #endregion

            //objIncidentHistory.Incidentid = incidentid;
            //objIncidentHistory.Operationownerid = userid;
            //objIncidentHistory.Operation = "update";
            //objIncidentHistory.Insert();
            //#region Get the Current historyid by calling function Get_Current_IncidentHistoryid()
            //int historyid = objIncidentHistory.Get_Current_IncidentHistoryid();
            //#endregion

            //#region Insert into IncidentHistoryDiff table ,By Comparing Current value and Updated Values
            //#region Declare local variable
            //string columnName;
            //string prev_value;
            //string curnt_value;
            //#endregion

            //columnName = "Resolution";
            //prev_value = "";
            //curnt_value = Editor.Text ;
            //objIncidentHistoryDiff.Historyid = historyid;
            //objIncidentHistoryDiff.Columnname = columnName;
            //objIncidentHistoryDiff.Current_value = curnt_value;
            //objIncidentHistoryDiff.Prev_value = prev_value;
            //objIncidentHistoryDiff.Insert();


            //#endregion
            Session["ResolutionAdded"] = "true";
            objIncidentResolution.Incidentid = incidentid;
            objIncidentResolution.Lastupdatetime = DateTime.Now.ToString();
            objIncidentResolution.Resolution = Editor.Text;
            objIncidentResolution.Userid = userid;
            Editor.Text = "";
            objIncidentResolution.Insert();
            //ShowResolution();

            string myScript;
            myScript = "<script language=javascript>javascript:window.close();</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    //protected void ShowResolution()
    //{
    //    #region Declaration of Dynamic Table,and Placeholder
    //    PlaceHolderResolution.Controls.Clear();
    //    Table tbl = new Table();
    //    PlaceHolderResolution.Controls.Add(tbl);
    //    int hdwidth = 1500;
    //    int height = 5;
    //    #endregion

    //    int incidentid = Convert.ToInt32(Session["incidentid"].ToString());

    //    #region Get Collection of Log From IncidentLog table via incidentid
    //    colIncidentResolution = objIncidentResolution.Get_All_By_incidentid(incidentid);
    //    foreach (IncidentResolution obj in colIncidentResolution)
    //    {

    //        #region Fetch Username on the basis of Operationownerid,by calling Get_By_id() function of Userlogin_mst Instance
    //        string username;
    //        objUser = objUser.Get_By_id(obj.Userid);
    //        username = objUser.Username.ToString();
    //        #endregion
    //        #region Declaration of Tablerow,TableCell and lable object
    //        TableRow tabRow = new TableRow();
    //        TableCell tbCell = new TableCell();
    //        tbCell.Width = hdwidth;
    //        Label lbl = new Label();
    //        #endregion
    //        #region Print Each Operation Performed by User
    //        lbl.Font.Bold = true;
    //        lbl.Text = "&nbsp;&nbsp;" + username + "&nbsp;&nbsp;&nbsp;&nbsp;said on&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Lastupdatetime.ToString();
    //        #endregion
    //        #region Fix background color of Row

    //        tabRow.BackColor = System.Drawing.Color.Lavender;

    //        #endregion
    //        #region Add label,cell,and Row to tabel
    //        tbCell.Controls.Add(lbl);
    //        tabRow.Cells.Add(tbCell);
    //        tbl.Rows.Add(tabRow);
    //        #endregion

    //        #region Declaration of local variables,tablerow,tablecell and label
    //        TableRow tabRowInner = new TableRow();
    //        TableCell tbCellInner = new TableCell();
    //        tbCellInner.Width = hdwidth;
    //        Label lblinner = new Label();
    //        lblinner.Font.Size = FontUnit.Smaller;
    //        #endregion

    //        #region Print Each Operation Performed by User
    //        lblinner.Font.Bold = true;
    //        lblinner.Text = "&nbsp;&nbsp;&nbsp;&nbsp;" + obj.Resolution.ToString();
    //        #endregion


    //        #region Label,cells and rows to Tabel of inner loop
    //        tabRowInner.BackColor = System.Drawing.Color.White;
    //        tbCellInner.Controls.Add(lblinner);
    //        tabRowInner.Cells.Add(tbCellInner);
    //        tbl.Rows.Add(tabRowInner);
    //        #endregion


    //    }

    //    #endregion

    //}

   
}
