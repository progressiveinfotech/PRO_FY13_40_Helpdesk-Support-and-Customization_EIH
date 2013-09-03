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
using System.IO;

public partial class admin_csmolddata : System.Web.UI.Page
{
    //csm_CaseHistory_trans objCsm = new csm_CaseHistory_trans();
    //BLLCollection<csm_CaseHistory_trans> colCsm = new BLLCollection<csm_CaseHistory_trans>();
    //csm_complaint_mst objcomplaint = new csm_complaint_mst();
    //BLLCollection<csm_complaint_mst> colcsm1=new BLLCollection<csm_complaint_mst> ();

    csm_calls objCalls = new csm_calls();
    BLLCollection<csm_calls> colCalls = new BLLCollection<csm_calls>();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void drpFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        ///Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            int id;
            id = Convert.ToInt32(drpFilter.SelectedValue);
            if (id == 1)
            {
                txtticket.Enabled = true;
                Label1.Enabled = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Enabled = false;
                LabelFrom.Enabled = false;
                TextBox2.Enabled = false;

                Labelto.Enabled = false;
            }
            if (id == 2)
            {
                txtticket.Text = "";
                TextBox1.Enabled = true;
                LabelFrom.Enabled = true;

                TextBox2.Enabled = true;
                Labelto.Enabled = true;
                txtticket.Enabled = false;
                Label1.Enabled = false;

            }
            else { Bindgrid(); }
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
    protected void Bindgrid()
    {
        string complaintid = txtticket.Text;
        objCalls = objCalls.Get_By_id(complaintid);
        colCalls.Add(objCalls);
        grdvwRequest.DataSource = colCalls;
        grdvwRequest.DataBind();

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {

            int id;
            id = Convert.ToInt32(drpFilter.SelectedValue);
            if (id == 1)
            {
                Bindgrid();
            }

            if (id == 2)
            {
                BindgridDate();
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

    protected void BindgridDate()
    {

        string vardate;
        string vardate1;

        string[] tempdate = TextBox1.Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        string[] tempdate1 = TextBox2.Text.ToString().Split(("/").ToCharArray());
        vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
        colCalls = objCalls.Get_All_By_Complaintdate(vardate, vardate1);
        grdvwRequest.DataSource = colCalls;
        grdvwRequest.DataBind();

    }

    #region Handling Gridview Page Indexing Event
    protected void grdvwRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        grdvwRequest.PageIndex = e.NewPageIndex;

        BindgridDate();


    }
    #endregion

    //protected void grdvwRequest_RowEditing(object sender, GridViewEditEventArgs e)
    //{

    //    string  complaintid = grdvwRequest.Rows[e.NewEditIndex].Cells[0].Text;
    //    Session["csmid"] = complaintid;
    //    string myScript;
    //    myScript = "<script language=javascript>javascript:window.open('../reports/ViewcsmData.aspx','popupwindow','width=650,height=400,left=180,top=130,Scrollbars=yes');</script>";
    //    Page.RegisterClientScriptBlock("MyScript", myScript);
    //}
    protected void btnExcel_Click(object sender, EventArgs e)
    {

        //  Master_MasterReports myMaster = (Master_MasterReports)this.Master;
        //  ContentPlaceHolder mpContentPlaceHolder;
        //  mpContentPlaceHolder =
        //(ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

        //  string attachment = "attachment; filename=Contacts.xls";
        //  GridView gv = new GridView();
        // // gv = (GridView)mpContentPlaceHolder.FindControl("grdvwRequest");
        //  gv = (GridView)myMaster.FindControl("grdvwRequest");
        //  Response.ClearContent();

        //  Response.AddHeader("content-disposition", attachment);

        //  Response.ContentType = "application/ms-excel";

        //  StringWriter sw = new StringWriter();

        //  HtmlTextWriter htw = new HtmlTextWriter(sw);

        // // grdvwRequest.RenderControl(htw);

        //  Response.Write(sw.ToString());

        //  Response.End();

        //Add Exception handilng try catch change by vishal 21-05-2012
        try
        {


            GridViewExportUtil.Export("callsheet.xls", this.grdvwRequest);
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
