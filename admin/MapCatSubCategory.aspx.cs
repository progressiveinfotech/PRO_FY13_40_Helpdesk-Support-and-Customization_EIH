///////////////////////////////////////////Code designed and developed by lalit joshi on 02 nov 2011////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

public partial class admin_MapCatSubCategory : System.Web.UI.Page
{
    Category_mst objCategory = new Category_mst();
    Subcategory_mst ObjSubcategory = new Subcategory_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    CategoryAssignToUser_mst objCategoryAssignToUser = new CategoryAssignToUser_mst();
    BLLCollection<Subcategory_mst> colSubCategory = new BLLCollection<Subcategory_mst>();
    BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();
    BLLCollection<CategoryAssignToUser_mst> colcategoryassigntouser = new BLLCollection<CategoryAssignToUser_mst>();
    UserLogin_mst objUser = new UserLogin_mst();

    #region Event to Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValSubcategory.ErrorMessage = Resources.MessageResource.errSubcategoryname.ToString();
            reqValDrpCatg.ErrorMessage = Resources.MessageResource.errValdrpcategory.ToString();
            BindDrpCategory();
            BindDropSubCategory();
            BindDropTechnician();
            //col = objUser.Get_SDETechAdmin();
            //drpUserList.DataTextField = "username";
            //drpUserList.DataValueField = "userid";
            //drpUserList.DataSource = col;
            //drpUserList.DataBind();
            //ListItem item = new ListItem();
            //item.Text = "--------------Select--------------";
            //item.Value = "0";
            //drpUserList.Items.Add(item);
            //drpUserList.SelectedValue = "0";
        }
    }
    #endregion
    protected void BindDropTechnician()
    {
        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        if (objRole.Roleid != 0)
        {
            int roleid;
            roleid = objRole.Roleid;
            if (roleid != 0)
            {
                colUser = objUser.Get_All_By_Role(roleid);
                drpUserList.DataTextField = "username";
                drpUserList.DataValueField = "userid";
                drpUserList.DataSource = colUser;
                drpUserList.DataBind();
                ListItem item = new ListItem();
                item.Text = "-------------Select-------------";
                item.Value = "0";
                drpUserList.Items.Add(item);
                drpUserList.SelectedValue = "0";
            }

        }
    }
    #region Event to bind category
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
    #endregion

    #region Event to category selected index changed
    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropSubCategory();
    }
    #endregion

    #region Event to assign Technician on category and subcategory. if already exist then update otherwise add
    protected void btnSubcategoryadd_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt16(drpUserList.SelectedValue);
        //first check user exist or not if exist then update else add
        int categoryid = Convert.ToInt32(drpCategory.SelectedValue);
        int subcateogryid = Convert.ToInt32(drpSubCategory.SelectedValue);
      
        if (IsUserExist(categoryid, subcateogryid))
        {
            int updated=objCategoryAssignToUser.Update(categoryid, subcateogryid, userid);
            if (updated == 1)
            {
                lblerrmsg.Text = "Technician Updated";
            }
        }
        else
        {
            objCategoryAssignToUser.Categoryid = categoryid;
            objCategoryAssignToUser.Subcategoryid = subcateogryid;
            objCategoryAssignToUser.Userid = userid;
            int added=objCategoryAssignToUser.Insert();
            if (added == 1)
            {
                lblerrmsg.Text = "Technician Assigned";
            }
            else
            {
                lblerrmsg.Text = "Technician not Assigned";
            }
        }
    }
    #endregion

    #region Event to clear controls
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }
    protected void ClearControl()
    {
       // txtSubcategorydesc.Text = "";
       // txtSubcategoryName.Text = "";
        lblerrmsg.Text = "";
    }
    #endregion

    #region Event to bind already existing user when subcategory selected
    protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //check wheter user is already assigned to perticular category and subcategory
        lblerrmsg.Text = "";
        try
        {
            int categoryid = Convert.ToInt32(drpCategory.SelectedItem.Value);
            int subcateogryid = Convert.ToInt32(drpSubCategory.SelectedItem.Value);
            if (IsUserExist(categoryid, subcateogryid))
            {
                drpUserList.SelectedItem.Selected = false;
                drpUserList.Items.FindByValue(objCategoryAssignToUser.Userid.ToString()).Selected = true;
            }
            else
            {
              
              drpUserList.SelectedItem.Selected = false;
              drpUserList.Items.FindByValue("0").Selected = true;
            } 
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    #endregion

    #region Event to bind SubCategoryId on the basis of categoryid
    protected void BindDropSubCategory()
    {
        try
        {
            int categoryid = Convert.ToInt16(drpCategory.SelectedValue);
            colSubCategory = ObjSubcategory.Get_All_By_Categoryid(categoryid);
            drpSubCategory.DataTextField = "subcategoryname";
            drpSubCategory.DataValueField = "subcategoryid";
            drpSubCategory.DataSource = colSubCategory;
            drpSubCategory.DataBind();
            ListItem item = new ListItem();
            item.Text = "-------------Select-------------";
            item.Value = "0";
            drpSubCategory.Items.Add(item);
            drpSubCategory.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    #endregion

    #region Event to check user exist or not
    protected bool IsUserExist(int categoryid,int subcategoryid)
    {
        bool userexist=false;
        int catid = Convert.ToInt32(drpCategory.SelectedItem.Value);
        int subcateogryid = Convert.ToInt32(drpSubCategory.SelectedItem.Value);
        objCategoryAssignToUser = objCategoryAssignToUser.Get_By_Categoryid_Subcategoryid(categoryid, subcateogryid);
        if (objCategoryAssignToUser.Userid != 0)
        {
            userexist=true;
        }
        return userexist;
    }
    #endregion

   
}
