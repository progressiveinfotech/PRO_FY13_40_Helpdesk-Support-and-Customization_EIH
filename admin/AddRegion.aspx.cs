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

public partial class admin_AddRegion : System.Web.UI.Page
{
    Organization_mst objOrganization = new Organization_mst();
    Region_mst Regionobj = new Region_mst();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValRegion.ErrorMessage = Resources.MessageResource.errRegionName.ToString();
            objOrganization = objOrganization.Get_Organization();
            BindGrid();
        }
    }
    
 
    protected void btnRegionadd_Click(object sender, EventArgs e)
    {
      int regionid=0;
      int organizationId;
      objOrganization = objOrganization.Get_Organization();
      organizationId=objOrganization.Orgid;
      regionid = Regionobj.Get_By_RegionName(txtregionname.Text.ToString(), organizationId);
          if(regionid ==0)
          {
                Regionobj.Regionname = txtregionname.Text.ToString();
                Regionobj.Description = txtregiondesc.Text.ToString();
                Regionobj.Orgid = organizationId;
                Regionobj.Insert();
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
          }
          else
          {
              lblerrmsg.Text = Resources.MessageResource.errRegionExist.ToString();
          }
        Dispose();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearControl();
    }
    public void clearControl()
    {
        txtregionname.Text = " ";
        txtregiondesc.Text = " ";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        // Declare col as Collection of Region_mst Object to get all records from table 
        BLLCollection<Region_mst> col = new BLLCollection<Region_mst>();
        col = Regionobj.Get_All();
        Regiongrdvw.DataSource = col;
        Regiongrdvw.DataBind();
        clearControl();
    }

    protected void Regiongrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Regiongrdvw.EditIndex = e.NewEditIndex;  
        BindGrid();
    }

    protected void Regiongrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Regiongrdvw.EditIndex = -1;
        BindGrid();
    }

    //*Start* Code added by Shrikant
    protected void Regiongrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, desc, id;
        int Regionid = 0;
        int FlagRegion;
        int organizationId;
     
        objOrganization = objOrganization.Get_Organization();
        organizationId=objOrganization.Orgid;
        clearControl();
        name = ((TextBox)Regiongrdvw.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        desc = ((TextBox)Regiongrdvw.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        id = Convert.ToString(Regiongrdvw.Rows[e.RowIndex].Cells[0].Text);
        Regionid = Convert.ToInt32(id);
        Regionobj = Regionobj.Get_By_id(Regionid);
        
            if (Regionobj.Regionname == name)
            {
                Regionobj.Regionname = name;
                Regionobj.Description = desc;
                Regionobj.Update();
                Regiongrdvw.EditIndex = -1;
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
            }
            else
            {
                FlagRegion = Regionobj.Get_By_RegionName(name, organizationId);
                if ((FlagRegion == 0)&&(name!=""))
                {
                    Regionobj.Regionname = name;
                    Regionobj.Description = desc;
                    Regionobj.Update();
                    Regiongrdvw.EditIndex = -1;
                    BindGrid();
                    lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
                }
                else if(name=="")
                {
                    lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
                }
                else
                {
                     Regiongrdvw.EditIndex = -1;
                     BindGrid();
                     lblerrmsg.Text = Resources.MessageResource.errRegionExist.ToString();
                }
            }
    }

   protected void Regiongrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orgid = 0;
        orgid = Convert.ToInt32(Regiongrdvw.Rows[e.RowIndex].Cells[0].Text);
        Regionobj.Delete(orgid);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();

    }

    protected void Regiongrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Regiongrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Regiongrdvw_OnRowCreated(object sender, GridViewRowEventArgs e)
    {

    }
   protected void Regiongrdvw_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           objOrganization = objOrganization.Get_Organization();
           e.Row.Cells[2].Text  = objOrganization.Orgname ;
        }
    }
}
