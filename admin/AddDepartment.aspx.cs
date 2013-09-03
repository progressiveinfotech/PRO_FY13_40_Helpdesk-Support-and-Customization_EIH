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

public partial class admin_AddDepartment : System.Web.UI.Page
{
    Site_mst objSite = new Site_mst();
    Department_mst objDepartment = new Department_mst();
    Customer_mst objCustomer = new Customer_mst();
    BLLCollection<Customer_mst> colCust = new BLLCollection<Customer_mst>();
    CustomerToSiteMapping objCustToSite = new CustomerToSiteMapping();
    int departmentid = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            reqValDepartment.ErrorMessage = Resources.MessageResource.errDepartment.ToString();
            reqValDrpSite.ErrorMessage = Resources.MessageResource.errValdrpSite.ToString();
            BindDropCustomer();
            BindDrpSite();
            BindGrid();
        }
    }
    public void BindDropCustomer()
    {
        colCust = objCustomer.Get_All();
        drpCustomer.DataTextField = "Customer_Name";
        drpCustomer.DataValueField = "CustId";
        drpCustomer.DataSource = colCust;
        drpCustomer.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select---------------";
        item.Value = "0";
        drpCustomer.Items.Add(item);
        drpCustomer.SelectedValue = "0";


    }

   public void BindDrpSite()
    {
        // Declare col as Collection of Site_mst Object to get all records from table 
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        BLLCollection<Site_mst> colSite1 = new BLLCollection<Site_mst>();
        int custid = Convert.ToInt32(drpCustomer.SelectedValue);
        // declare object objOrganization of Site_mst_mst Class to call function Get_All() to fetch all records from database

        // Assign all records to variable col 
        col = objSite.Get_All();
        foreach (Site_mst obj in col)
        {
            int flag;
            flag = objCustToSite.Get_By_Id(custid, obj.Siteid);
            if (flag == 1)
            {
                colSite1.Add(obj);

            }
        }
        drpSite.DataTextField = "SiteName";
        drpSite.DataValueField = "siteid";

        drpSite.DataSource = colSite1;
        drpSite.DataBind();
        // Declare item as listItem to assign default value to drop down
        ListItem item = new ListItem();
        item.Text = "--------------Select--------------";
        item.Value = "0";

        drpSite.Items.Add(item);
        drpSite.SelectedValue = "0";

    }

    protected void btnDepartmentadd_Click(object sender, EventArgs e)
    {

        int departmentid = 0;
        int varSiteid;
        varSiteid = Convert.ToInt32(drpSite.SelectedValue);
        departmentid = objDepartment.Get_By_DepartmentName(txtDepartmentName.Text.ToString(), varSiteid);
        if (departmentid == 0)
        {
            objDepartment.Departmentname = txtDepartmentName.Text.ToString();
            objDepartment.Siteid = Convert.ToInt32(drpSite.SelectedValue);
            objDepartment.Description = txtDepartmentdesc.Text.ToString();
            objDepartment.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }

        else
        {
            lblerrmsg.Text = Resources.MessageResource.errDepartmentExist.ToString();
        }


    }

    public void BindGrid()
    {
        // Declare col as Collection of Department_mst Object to get all records from table 
        BLLCollection<Department_mst> col = new BLLCollection<Department_mst>();
        int varSiteid;
        varSiteid = Convert.ToInt32(drpSite.SelectedValue);
        col = objDepartment.Get_All_By_SiteId(varSiteid);
        departmentgrdvw.DataSource = col;
        departmentgrdvw.DataBind();
        ClearControl(); 
    }

    protected void departmentgrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        departmentgrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void departmentgrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        departmentgrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void departmentgrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, desc, id;
        int FlagDepartment;
        int deptid;
        name = ((TextBox)departmentgrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtsiteName")).Text;
        desc = ((TextBox)departmentgrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtDepartmentdesc")).Text;
        id = Convert.ToString(departmentgrdvw.Rows[e.RowIndex].Cells[0].Text);
        deptid = Convert.ToInt32(id);
        objDepartment = objDepartment.Get_By_id(deptid);
        if (objDepartment.Deptid !=0)
        {
            DropDownList sitedrp = ((DropDownList)departmentgrdvw.Rows[e.RowIndex].Cells[4].FindControl("drpsitename"));
            int siteid = Convert.ToInt32(sitedrp.SelectedValue);
            if ((objDepartment.Departmentname == name)&&(objDepartment.Siteid == siteid))
            {
               
                objDepartment.Siteid = siteid;
                objDepartment.Deptid = deptid;
                objDepartment.Departmentname = name;
                objDepartment.Description = desc;
                objDepartment.Update();
                departmentgrdvw.EditIndex = -1;
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();

            }
            else
            {
                FlagDepartment = objDepartment.Get_By_DepartmentName(name, siteid);
                if ((FlagDepartment == 0)&&(name!=""))
                {
                    objDepartment.Siteid = siteid;
                    objDepartment.Deptid = deptid;
                    objDepartment.Departmentname = name;
                    objDepartment.Description = desc;
                    objDepartment.Update();
                    departmentgrdvw.EditIndex = -1;
                    BindGrid();
                    lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
                }
                else if(name == "")
                {
                    lblerrmsg.Text = Resources.MessageResource.errDeptName.ToString();
                }

                else
                {
                    departmentgrdvw.EditIndex = -1;
                    BindGrid();
                    lblerrmsg.Text = Resources.MessageResource.errDepartmentExist.ToString();
                }
            }
        }
    }
    
   
    protected void departmentgrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        departmentid = Convert.ToInt32(departmentgrdvw.Rows[e.RowIndex].Cells[0].Text);
        objDepartment.Delete(departmentid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void departmentgrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        departmentgrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }


    protected void departmentgrdvw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        {
            int siteid;
            Label lblsiteid = (Label)e.Row.FindControl("lblsite");
            if (lblsiteid != null)
            {
                siteid = Convert.ToInt32(lblsiteid.Text);
                ViewState["siteid"] = lblsiteid.Text;
                objSite = objSite.Get_By_id(siteid);
                lblsiteid.Text = objSite.Sitename.ToString();
            }
        }

        if (e.Row.RowState == (System.Web.UI.WebControls.DataControlRowState.Alternate | System.Web.UI.WebControls.DataControlRowState.Edit))
        {
            DropDownList drpsitename = (DropDownList)e.Row.FindControl("drpsitename");
            BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
            col = objSite.Get_All();
            drpsitename.DataSource = col;
            drpsitename.DataTextField = "sitename";
            drpsitename.DataValueField = "siteid";
            drpsitename.DataBind();
            drpsitename.SelectedValue = ViewState["siteid"].ToString();
        }
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            DropDownList drpsitename = (DropDownList)e.Row.FindControl("drpsitename");
            BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
            col = objSite.Get_All();
            drpsitename.DataSource = col;
            drpsitename.DataTextField = "SiteName";
            drpsitename.DataValueField = "siteid";
            drpsitename.DataBind();
            drpsitename.SelectedValue = ViewState["siteid"].ToString();
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
        lblerrmsg.Text = "";
    }
    protected void ClearControl()
    {
        txtDepartmentdesc.Text = "";
        txtDepartmentName.Text = "";
        lblerrmsg.Text = "";
    }
    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDrpSite();
    }
}
