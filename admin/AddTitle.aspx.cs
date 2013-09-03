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

public partial class admin_AddTitle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDrpCategory();
            
        }

    }
    Title_mst objtitle = new Title_mst();
    Category_mst objCategory = new Category_mst();
    Subcategory_mst ObjSubcategory = new Subcategory_mst();
    BLLCollection<Subcategory_mst> colsubcategory = new BLLCollection<Subcategory_mst>();
    public void BindDrpCategory()
    {
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        col = objCategory.Get_All();
        drpCategory.DataTextField = "CategoryName";
        drpCategory.DataValueField = "categoryid";
        drpCategory.DataSource = col;
        drpCategory.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select--------------";
        item.Value = "0";
        drpCategory.Items.Add(item);
        drpCategory.SelectedValue = "0";
    }
    public void BinddrpSubcategory()
    {
        int categoryid = Convert.ToInt32(drpCategory.SelectedValue);
        colsubcategory = ObjSubcategory.Get_All_By_Categoryid(categoryid);
        drpsubcategory.DataTextField = "subcategoryname";
        drpsubcategory.DataValueField = "subcategoryid";
        drpsubcategory.DataSource = colsubcategory;
        drpsubcategory.DataBind();

    }
    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BinddrpSubcategory();
    }


    protected void btnSubcategoryadd_Click(object sender, EventArgs e)
    {
         int categoryid1 = Convert.ToInt32(drpCategory.SelectedValue);
         objtitle.Categoryid = categoryid1;
         objtitle.Subacetgoryid =Convert.ToInt32(drpsubcategory.SelectedValue);
         objtitle.Title = txttitle.Text.ToString();
         objtitle.Insert();
        
    }
}
