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

public partial class admin_ViewcsmData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string complaintid = Session["csmid"].ToString();
            BLLCollection<csm_CaseHistory_trans> col = new BLLCollection<csm_CaseHistory_trans>();
            csm_CaseHistory_trans objhistory = new csm_CaseHistory_trans();
            col = objhistory.Get_All_By_ComplaintId(complaintid);
            grdvwdate.DataSource = col;
            grdvwdate.DataBind();
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
