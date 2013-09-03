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

public partial class admin_AddSubcategory : System.Web.UI.Page
{
   Category_mst objCategory = new Category_mst();
   Subcategory_mst ObjSubcategory = new Subcategory_mst();
   int subcategoryid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            reqValSubcategory.ErrorMessage = Resources.MessageResource.errSubcategoryname.ToString();
            reqValDrpCatg.ErrorMessage = Resources.MessageResource.errValdrpcategory.ToString();
            BindDrpCategory();
            //BindGrid();
        }
    }

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

    protected void ClearControl()
    {
        txtSubcategorydesc.Text = "";
        txtSubcategoryName.Text = "";
        lblerrmsg.Text = "";
    }
    protected void btnSubcategoryadd_Click(object sender, EventArgs e)
    {
        int subcategoryid = 0;
        int varCategoryid;
        varCategoryid = Convert.ToInt32(drpCategory.SelectedValue);
        subcategoryid = ObjSubcategory.Get_By_SubcategoryName(txtSubcategoryName.Text.ToString(), varCategoryid);
        if (subcategoryid == 0)
        {
            ObjSubcategory.Subcategoryname = txtSubcategoryName.Text.ToString();
            ObjSubcategory.Categoryid = Convert.ToInt32(drpCategory.SelectedValue);
            ObjSubcategory.Subcategorydescription = txtSubcategorydesc.Text.ToString();
            ObjSubcategory.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errsubcategorysave.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errSubcategoryExist.ToString();
        }
    }

    public void BindGrid()
    {
        BLLCollection<Subcategory_mst> col = new BLLCollection<Subcategory_mst>();
        int varsubcatid;
        varsubcatid = Convert.ToInt32(drpCategory.SelectedValue);
        col = ObjSubcategory.Get_All_By_Categoryid(varsubcatid);
        //string s = ObjSubcategory.Subcategoryname;
        subcategorygrdvw.DataSource = col;
        subcategorygrdvw.DataBind();
        ClearControl();
    }

    protected void subcategorygrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        subcategorygrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void subcategorygrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        subcategorygrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void subcategorygrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int subcategoryid = 0; 
        string name, desc, id;
        int FlagCount;
        
        name = ((TextBox)subcategorygrdvw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        desc = ((TextBox)subcategorygrdvw.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        id = Convert.ToString(subcategorygrdvw.Rows[e.RowIndex].Cells[0].Text);

        //DropDownList categorydrp = ((DropDownList)subcategorygrdvw.Rows[e.RowIndex].Cells[4].FindControl("drpcategoryname"));
        int categoryid = Convert.ToInt32(drpCategory.SelectedValue);
        subcategoryid = Convert.ToInt32(id);
        ObjSubcategory = ObjSubcategory.Get_By_id(subcategoryid);

        FlagCount = ObjSubcategory.Get_By_SubcategoryName(name, categoryid);

        if ((FlagCount == 0)&&(name!=""))
        {
            ObjSubcategory.Categoryid = categoryid;
            ObjSubcategory.Subcategoryid = subcategoryid;
            ObjSubcategory.Subcategoryname = name;
            ObjSubcategory.Subcategorydescription = desc;
            ObjSubcategory.Update();
            subcategorygrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (ObjSubcategory.Subcategoryname == name)
        {
            ObjSubcategory.Categoryid = categoryid;
            ObjSubcategory.Subcategoryid = subcategoryid;
            ObjSubcategory.Subcategoryname = name;
            ObjSubcategory.Subcategorydescription = desc;
            ObjSubcategory.Update();
            subcategorygrdvw.EditIndex = -1;
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
        }
        else if (name == "")
        {
            lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errSubcategoryExist.ToString();
        }
    }

    protected void subcategorygrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        subcategoryid = Convert.ToInt32(subcategorygrdvw.Rows[e.RowIndex].Cells[0].Text);
        ObjSubcategory.Delete(subcategoryid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void subcategorygrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        subcategorygrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    
    protected void subcategorygrdvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int varcateid;
            varcateid = Convert.ToInt32(drpCategory.SelectedValue);
            objCategory = objCategory.Get_By_id(varcateid);
            e.Row.Cells[3].Text = objCategory.CategoryName;
        }

        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        //{
           
            
        //    int  categoryid;
        //    Label lblcategoryid = (Label)e.Row.FindControl("lblcategory");
        //    if (lblcategoryid != null)
        //    {
        //        categoryid = Convert.ToInt32(lblcategoryid.Text);
        //        ViewState["categoryid"] = lblcategoryid.Text;

        //        objCategory = objCategory.Get_By_id(categoryid);
        //        if (objCategory.Categoryid!=0)
        //        {
        //            lblcategoryid.Text = objCategory.CategoryName.ToString();
        //        }
                
        //    }
           
        //}
        //if (e.Row.RowState  == DataControlRowState.Edit  )
        //{
           
        //    DropDownList categorydrp = (DropDownList)e.Row.FindControl("drpcategoryname");
        //    BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        //    col = objCategory.Get_All();
        //    categorydrp.DataSource = col;
        //    categorydrp.DataTextField = "CategoryName";
        //    categorydrp.DataValueField = "categoryid";
        //    categorydrp.DataBind();
        //    categorydrp.SelectedValue = ViewState["categoryid"].ToString();  
        
           

        //}
        //if (e.Row.RowState == (System.Web.UI.WebControls.DataControlRowState.Alternate | System.Web.UI.WebControls.DataControlRowState.Edit))
        //{
        //    DropDownList categorydrp = (DropDownList)e.Row.FindControl("drpcategoryname");
        //    BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        //    col = objCategory.Get_All();
        //    categorydrp.DataSource = col;
        //    categorydrp.DataTextField = "CategoryName";
        //    categorydrp.DataValueField = "categoryid";
            
        //    categorydrp.DataBind();
        //    categorydrp.SelectedValue = ViewState["categoryid"].ToString();  
        //}
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }
    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}
