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

public partial class admin_EscalateUsersList : System.Web.UI.Page
{
    BLLCollection<EscalateEmail_mst> col = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            BindGrid();
        }
    }
    
    protected void BindGrid()
    {
        col = objEscalateEmail.Get_All();
        grdvwEscalate.DataSource = col;
        grdvwEscalate.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Email = "";
        foreach (GridViewRow gv in grdvwEscalate.Rows)
        {
            string ID;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // If deleteChkBxItem is Checked then ,mapped Current site to this user
            if (deleteChkBxItem.Checked)
            {
                int varId;
                // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                ID = ((Label)gv.FindControl("id")).Text.ToString();
                varId = Convert.ToInt32(ID);
                // Check if gvIDs is not null
                if (ID != "")
                {
                    EscalateEmail_mst obj = new EscalateEmail_mst();
                    obj = objEscalateEmail.Get_By_id(varId);
                    Email = Email + obj.Email.ToString() + "," ;
                }
            }
        }
        Session["UsersEmail"] = Email.ToString();
        string myScript;
        myScript = "<script language=javascript>javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
}
