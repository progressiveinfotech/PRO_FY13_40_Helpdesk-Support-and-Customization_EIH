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

public partial class admin_AddImpact : System.Web.UI.Page
{
    Impact_mst ImpactObj = new Impact_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValImpact.ErrorMessage = Resources.MessageResource.errSelectImpact.ToString(); ;
            BindGrid();
        }
    }

    protected void btnImpactadd_Click(object sender, EventArgs e)
    {
        int impactname;
        impactname = ImpactObj.Get_By_ImpactName(txtImpactName.Text.ToString());
        if (impactname == 0)
        {
            ImpactObj.Impactname = txtImpactName.Text.ToString();
            ImpactObj.Description = txtImpactDesc.Text.ToString();
            ImpactObj.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errImpactExist;
        }

        Dispose();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    protected void ClearControl()
    {
        txtImpactDesc.Text = "";
        txtImpactName.Text = "";
        lblerrmsg.Text = "";
    }

    public void BindGrid()
    {
        BLLCollection<Impact_mst> col = new BLLCollection<Impact_mst>();
        col = ImpactObj.Get_All();
        Impactgrdvw.DataSource = col;
        Impactgrdvw.DataBind();
        ClearControl();
    }

    protected void Impactgrdvw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Impactgrdvw.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void Impactgrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Impactgrdvw.EditIndex = -1;
        BindGrid();
    }

    protected void Impactgrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name, desc, id;
        int ImpactId;
        int FlagImpact;
        name = ((TextBox)Impactgrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtImpactName")).Text;
        desc = ((TextBox)Impactgrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtImpactdesc")).Text;
        id = Convert.ToString(Impactgrdvw.Rows[e.RowIndex].Cells[0].Text);
        ImpactId = Convert.ToInt32(id);
        ImpactObj = ImpactObj.Get_By_id(ImpactId);
            if (ImpactObj.Impactname == name)
            {
                ImpactObj.Impactname = name;
                ImpactObj.Description = desc;
                ImpactObj.Update();
                Impactgrdvw.EditIndex = -1;
                BindGrid();
                lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
            }
            else
            {
                FlagImpact = ImpactObj.Get_By_ImpactName(name);
                if ((FlagImpact == 0)&&(name!=""))
                {
                    ImpactObj.Impactname = name;
                    ImpactObj.Description = desc;
                    ImpactObj.Update();
                    Impactgrdvw.EditIndex = -1;
                    BindGrid();
                    lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
                }
                else if(name == "")
                {
                    lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
                }
                else
                {
                    Impactgrdvw.EditIndex = -1;
                    BindGrid();
                    lblerrmsg.Text = Resources.MessageResource.errImpactExist.ToString();
                }
            }
    }
    
    protected void Impactgrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClearControl();
        int ImpactId = 0;
        ImpactId = Convert.ToInt32(Impactgrdvw.Rows[e.RowIndex].Cells[0].Text);
        ImpactObj.Delete(ImpactId);
        BindGrid();
        lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
    }

    protected void Impactgrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Impactgrdvw.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
