using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Master_MasterAdmin : System.Web.UI.MasterPage
{
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();
    protected void Page_Load(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                MembershipUser User = Membership.GetUser();
                objOrganization = objOrganization.Get_Organization();
                int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
                if (userid != 0)
                {
                    objContact = objContact.Get_By_id(userid);
                    lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;
                }
            }
            XmlDataSource ds = new XmlDataSource();
            ds.EnableCaching = false;
            ds.DataFile = Server.MapPath("../Files/Admin.xml");
            TreeView1.DataSource = ds;
            TreeView1.DataBind();

        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    protected void Treeview1_SelectedNodeChanged(object sender, EventArgs e)
    {//Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string node_name = TreeView1.SelectedNode.Value;
            ViewState["node_name"] = node_name;
            if (node_name == "Admin")
            {
                Response.Redirect("~/admin/default.aspx");
            }
            else
            {
                if ((node_name != "UserTask") && (node_name != "OrganizationTask") && (node_name != "Services") && (node_name != "OtherTask"))
                {
                    Response.Redirect("~/admin/" + node_name);
                }
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
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        ////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            Response.Redirect("../Login/Default.aspx");
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
