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

public partial class admin_AddPriority : System.Web.UI.Page
{
    Priority_mst Priorityobj = new Priority_mst(); 
    public int prioritycount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValPriority.ErrorMessage = Resources.MessageResource.errPriorityName.ToString();
            BindGrid();
        }
    }

    protected void btnPriorityAdd_Click(object sender, EventArgs e)
    {
        prioritycount = Priorityobj.Get_By_PriorityName(txtPriorityName.Text.ToString());
        if (prioritycount == 0)
        {
            Priorityobj.Name = txtPriorityName.Text.Trim();
            Priorityobj.Description = txtPriorityDesc.Text.Trim();
            Priorityobj.Insert();
            BindGrid();
            lblerrmsg.Text = Resources.MessageResource.erradd.ToString();
        }
        else
        {
            lblerrmsg.Text = Resources.MessageResource.errPriorityExist;
        }
    }

    public void BindGrid()
    {
       BLLCollection<Priority_mst> col = new BLLCollection<Priority_mst>();
       col = Priorityobj.Get_All();
       Prioritygrdvw.DataSource=col;
       Prioritygrdvw.DataBind();
       ClearControl();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    protected void ClearControl()
    {
        txtPriorityDesc.Text = "";
        txtPriorityName.Text = "";
        lblerrmsg.Text = "";
    }

       protected void Prioritygrdvw_RowEditing(object sender, GridViewEditEventArgs e)
       {
           Prioritygrdvw.EditIndex = e.NewEditIndex;
           BindGrid();
       }

       protected void Prioritygrdvw_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
       {
           Prioritygrdvw.EditIndex = -1;
           BindGrid();
       }

       protected void Prioritygrdvw_RowUpdating(object sender, GridViewUpdateEventArgs e)
       {
           Priority_mst obj = new Priority_mst();
           string name, desc, id;
           int PriorityId = 0;
           name = ((TextBox)Prioritygrdvw.Rows[e.RowIndex].Cells[1].Controls[0].FindControl("txtPriorityName")).Text;
           desc = ((TextBox)Prioritygrdvw.Rows[e.RowIndex].Cells[2].Controls[0].FindControl("txtprioritydesc")).Text;
           id = Convert.ToString(Prioritygrdvw.Rows[e.RowIndex].Cells[0].Text);
           PriorityId = Convert.ToInt32(id);
           prioritycount=Priorityobj.Get_By_PriorityName(name);
           obj = obj.Get_By_id(PriorityId);

           if ((prioritycount == 0)&&(name!=""))
           {
               Priorityobj.Priorityid = PriorityId;
               Priorityobj.Name = name;
               Priorityobj.Description = desc;
               Priorityobj.Update();
               Prioritygrdvw.EditIndex = -1;
               BindGrid();
               lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
           }
           else if(name == "")
           {
               lblerrmsg.Text = Resources.MessageResource.errnotempty.ToString();
           }
           else if (obj.Name == name)
           {
               Priorityobj.Priorityid = PriorityId;
               Priorityobj.Name = name;
               Priorityobj.Description = desc;
               Priorityobj.Update();
               Prioritygrdvw.EditIndex = -1;
               BindGrid();
               lblerrmsg.Text = Resources.MessageResource.errupdate.ToString();
           }
           else
           {
               Prioritygrdvw.EditIndex = -1;
               BindGrid();
               lblerrmsg.Text = Resources.MessageResource.errPriorityExist.ToString();
           }
       }

       protected void Prioritygrdvw_RowDeleting(object sender, GridViewDeleteEventArgs e)
       {
           int PriorityId = 0;
           PriorityId = Convert.ToInt32(Prioritygrdvw.Rows[e.RowIndex].Cells[0].Text);
           Priorityobj.Delete(PriorityId);
           BindGrid();
           lblerrmsg.Text = Resources.MessageResource.errdelete.ToString();
       }

       protected void Prioritygrdvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           Prioritygrdvw.PageIndex = e.NewPageIndex;
           BindGrid();
       }
}
