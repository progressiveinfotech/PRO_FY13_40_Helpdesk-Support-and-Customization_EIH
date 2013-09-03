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

public partial class test_testDynamic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox tb = new TextBox();
        tb.ID = "tb1";


       place.Controls.Add(tb);   
    }
    protected void btnClick_Click(object sender, EventArgs e)
    {

        TextBox tbox = (TextBox)Page.FindControl("tb1");

        if (tbox != null)
        {
            Response.Write(tbox.Text);
        } 
    }
}
