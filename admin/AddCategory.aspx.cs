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

public partial class admin_AddCategory : System.Web.UI.Page
{
    Category_mst CategoryObj = new Category_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValCategory.ErrorMessage = Resources.MessageResource.errCategoryName;
            BindGrid();
        }
    }
    protected void btnCategoryadd_Click(object sender, EventArgs e)
    {
        int categoryname;
        categoryname = CategoryObj.Get_By_CategoryName(txtCategoryName.Text.ToString());
        if (categoryname == 0)
        {
            CategoryObj.CategoryName = txtCategoryName.Text.ToString();
            CategoryObj.Categorydescription = txtCategoryDesc.Text.ToString();
            CategoryObj.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd;
            txtCategoryName.Text = "";
            txtCategoryDesc.Text = "";
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errCategoryExist;
        }

        Dispose();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }
    protected void ClearControl()
    {
        txtCategoryDesc.Text = "";
        txtCategoryName.Text = "";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();

        col = CategoryObj.Get_All();
        Categorygrdvw.DataSource = col;
        Categorygrdvw.DataBind();
        

    }
    protected void Categorygrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ClearControl();

        Categorygrdvw.EditIndex = e.NewEditIndex;
        //((TextBox)Regiongrdvw.Rows.[e..Cells[1].Controls[0]).MaxLength  = 50;
        //((TextBox)Regiongrdvw.Rows[e.NewEditIndex].Cells[4].Controls[0]).MaxLength = 50;

        BindGrid();
    }
    protected void Categorygrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Categorygrdvw.EditIndex = -1;
        BindGrid();
        ClearControl();
    }
   
    //*Start Code added by Shrikant
    protected void Categorygrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ClearControl();
        string name, desc, id;
        int CategoryId;
        int FlagCategory;
              
        name = ((TextBox)Categorygrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtCategoryName")).Text;
        desc = ((TextBox)Categorygrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtCategorydesc")).Text;
        id = Convert.ToString(Categorygrdvw.Rows[e.RowIndex].Cells[0].Text);
        CategoryId = Convert.ToInt32(id);
        CategoryObj = CategoryObj.Get_By_id(CategoryId);
       
        if (CategoryObj.CategoryName == name)
        {
            CategoryObj.Categoryid = CategoryId;
            CategoryObj.CategoryName = name;
            CategoryObj.Categorydescription = desc;
            CategoryObj.Update();
            Categorygrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate;
        }
        else if(name == "")
        {
            lblerrmsg.Text = "Category Nome should not be Empty";
        }
        else
        {
            FlagCategory = CategoryObj.Get_By_CategoryName(name);

            if ((FlagCategory == 0)&&(name!=""))
            {
            CategoryObj.Categoryid = CategoryId;
            CategoryObj.CategoryName = name;
            CategoryObj.Categorydescription = desc;
            CategoryObj.Update();
            Categorygrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate;
            }
            else
            {
                Categorygrdvw.EditIndex = -1;
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.errCategoryExist.ToString();
            }

        }

    }
    
    //*End 
   
    protected void Categorygrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int CategoryId = 0;

        CategoryId = Convert.ToInt32(Categorygrdvw.Rows[e.RowIndex].Cells[0].Text);
        CategoryObj.Delete(CategoryId);
        BindGrid();
        ClearControl();
        lblerrmsg.Text = Resources.MessageResource.errdelete;


    }
    protected void Categorygrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        Categorygrdvw.PageIndex = e.NewPageIndex;
        BindGrid();

    }

}
