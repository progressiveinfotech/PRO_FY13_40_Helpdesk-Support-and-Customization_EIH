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

public partial class Problem_DisplayProblem : System.Web.UI.Page
{
    Problem_mst objProblem = new Problem_mst();
    BLLCollection<Problem_mst> colProblem = new BLLCollection<Problem_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    Status_mst objStatus = new Status_mst();
    Priority_mst objPriority = new Priority_mst();
    Category_mst objCategory = new Category_mst();
    Incident_To_Problem objIncidentToProblem = new Incident_To_Problem();
    protected void Page_Load(object sender, EventArgs e)
    {///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                BindGrid();
                FindIncidentToProblemAttach();

            }
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void BindGrid()
    {
        colProblem = objProblem.Get_All();
        grdvwProblem.DataSource = colProblem;
        grdvwProblem.DataBind();


    }

    #region Handling Gridview Page Indexing Event
    protected void grdvwProblem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        // Hndling GridView PageIndex Change Event for Paging  
        grdvwProblem.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here

        BindGrid();

    }
    #endregion

    #region Handling GridView Row Databound Event
    protected void grdvwProblem_RowDataBound(Object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            #region Bind Data Row at Run time with requesterid to Requester name
            int requesterid = Convert.ToInt32(e.Row.Cells[3].Text);
            objUser = objUser.Get_By_id(requesterid);

            if (objUser.Userid != 0)
            {
                e.Row.Cells[3].Text = objUser.Username.ToString();
            }
            else { e.Row.Cells[3].Text = ""; }
            #endregion

            #region Bind Datarow at Run Time with Createdbyid to Created by name
            int createdbyid = Convert.ToInt32(e.Row.Cells[4].Text);
            objUser = objUser.Get_By_id(createdbyid);
            if (objUser.Userid != 0)
            {
                e.Row.Cells[4].Text = objUser.Username.ToString();
            }
            else { e.Row.Cells[4].Text = ""; }
            #endregion

            #region Bind Datarow at Run Time with technicianid to technician name
            int technicianid = Convert.ToInt32(e.Row.Cells[5].Text);
            objUser = objUser.Get_By_id(technicianid);
            if (objUser.Userid != 0)
            {
                e.Row.Cells[5].Text = objUser.Username.ToString();
            }
            else { e.Row.Cells[5].Text = ""; }
            #endregion

            #region Bind Datarow at run time with Statusid to Status
            int statusid = Convert.ToInt32(e.Row.Cells[6].Text);
            objStatus = objStatus.Get_By_id(statusid);
            if (objStatus.Statusid != 0)
            { e.Row.Cells[6].Text = objStatus.Statusname.ToString(); }
            else { e.Row.Cells[6].Text = ""; }
            #endregion

            #region Bind Datarow at run time with Priorityid to Priority
            int priorityid = Convert.ToInt32(e.Row.Cells[7].Text);
            objPriority = objPriority.Get_By_id(priorityid);
            if (objPriority.Priorityid != 0)
            { e.Row.Cells[7].Text = objPriority.Name.ToString(); }
            else { e.Row.Cells[7].Text = ""; }
            #endregion


            #region Bind Datarow at run time with CategoryId to Category
            int categoryid = Convert.ToInt32(e.Row.Cells[8].Text);
            objCategory = objCategory.Get_By_id(categoryid);
            if (objCategory.Categoryid != 0)
            { e.Row.Cells[8].Text = objCategory.CategoryName.ToString(); }
            else { e.Row.Cells[8].Text = ""; }
            #endregion
        }



    }
    #endregion
    protected void btnAttach_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
        int incidentid = Convert.ToInt32(Session["incidentid"].ToString());
        foreach (GridViewRow gv in grdvwProblem.Rows)
        {
            string gvIDs;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // If deleteChkBxItem is Checked then ,mapped Current site to this user
            if (deleteChkBxItem.Checked)
            {
                int probId;

                gvIDs = ((Label)gv.FindControl("ProblemId")).Text.ToString();
                probId = Convert.ToInt32(gvIDs);
                // Check if gvIDs is not null
                if (gvIDs != "")
                {
                    objIncidentToProblem = objIncidentToProblem.Get_By_id(incidentid, probId);
                    if (objIncidentToProblem.Incidentid == 0)
                    {
                        objIncidentToProblem.Incidentid = incidentid;
                        objIncidentToProblem.Problemid = probId;
                        objIncidentToProblem.Insert();
                    }


                }

            }
        }


        lblErrorMsg.Text = "Incident Request is Attached to Current Problems";
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    //protected void btnReset_Click(object sender, EventArgs e)
    //{
    //    lblErrorMsg.Text = "";
    //    BindGrid();
    //}
    protected void FindIncidentToProblemAttach()
    {
        int incidentid = Convert.ToInt32(Session["incidentid"].ToString());
        foreach (GridViewRow gv in grdvwProblem.Rows)
        {
            string gvIDs;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // If deleteChkBxItem is Checked then ,mapped Current site to this user

            int probId;

            gvIDs = ((Label)gv.FindControl("ProblemId")).Text.ToString();
            probId = Convert.ToInt32(gvIDs);
            // Check if gvIDs is not null
            if (gvIDs != "")
            {
                objIncidentToProblem = objIncidentToProblem.Get_By_id(incidentid, probId);
                if (objIncidentToProblem.Incidentid != 0)
                {
                    deleteChkBxItem.Checked = true;
                }


            }


        }


    }
}
