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

public partial class Change_InsertChangeTask : System.Web.UI.Page
{
    UserLogin_mst ObjUserLogin = new UserLogin_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> coltechnician = new BLLCollection<UserLogin_mst>();
    ChangeTask_mst objChangetask = new ChangeTask_mst();

    protected void Page_Load(object sender, EventArgs e)
    {////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            if (!IsPostBack)
            {
                ShowValues();

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

    protected void BindOwner()
    {
        objRole = objRole.Get_RoleInfo_By_RoleName("technician");
        int roleid = Convert.ToInt32(objRole.Roleid);
        coltechnician = ObjUserLogin.Get_All_By_Role(roleid);
        drpTechnician1.DataTextField = "username";
        drpTechnician1.DataValueField = "userid";
        drpTechnician1.DataSource = coltechnician;
        drpTechnician1.DataBind();
        ListItem item = new ListItem();
        item.Text = "---Select Owner---";
        item.Value = "0";
        drpTechnician1.Items.Add(item);
        drpTechnician1.SelectedValue = "0";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardate = "";
            string vardate1 = "";
            string vardate2 = "";
            string vardate3 = "";

            DateTime dtendtime = new DateTime();
            if (txtatendtime.Text != "")
            {
                // string[] tempdate = txtatendtime.Text.ToString().Split(("/").ToCharArray());
                vardate = txtatendtime.Text.ToString();
                dtendtime = Convert.ToDateTime(vardate);
                objChangetask.Actualendtime = dtendtime.ToString();
            }
            else
            {
                vardate = null;
                objChangetask.Actualendtime = vardate;

            }


            DateTime actstarttime = new DateTime();
            if (txtatsttime.Text != "")
            {
                //  string[] Actualstarttime = txtatsttime.Text.ToString().Split(("/").ToCharArray());
                vardate1 = txtatsttime.Text.ToString();
                actstarttime = Convert.ToDateTime(vardate1);
                objChangetask.Actualstarttime = actstarttime.ToString();

            }
            else
            {
                vardate1 = null;
                objChangetask.Actualstarttime = vardate1;
            }


            DateTime schdstime = new DateTime();
            if (txtschedlstarttime.Text != "")
            {
                //  string[] Scheduledstarttime = txtschedlstarttime.Text.ToString().Split(("/").ToCharArray());
                vardate2 = txtschedlstarttime.Text.ToString();
                schdstime = Convert.ToDateTime(vardate2);
                objChangetask.Scheduledstarttime = schdstime.ToString();
            }
            else
            {
                vardate2 = null;
                objChangetask.Scheduledstarttime = vardate2;
            }

            DateTime dt = new DateTime();
            if (txtschdlendtime.Text != "")
            {
                //string[] Scheduledendtime = txtschdlendtime.Text.ToString().Split(("/").ToCharArray());
                //vardate3 = Scheduledendtime[2] + "-" + Scheduledendtime[1] + "-" + Scheduledendtime[0];
                vardate3 = txtschdlendtime.Text.ToString();

                dt = Convert.ToDateTime(vardate3);
                objChangetask.Scheduledendtime = dt.ToString();



            }
            else
            {
                vardate3 = null;
                objChangetask.Scheduledendtime = vardate3;
            }

            objChangetask.Title = txttitle.Text;
            objChangetask.Description = txtdescription.Text;
            objChangetask.Ownerid = Convert.ToInt32(drpTechnician1.SelectedValue);
            objChangetask.Taskstatusid = Convert.ToInt32(drptaskstatus.SelectedValue);
            objChangetask.Changeid = Convert.ToInt32(Request.QueryString[0]);
            objChangetask.Comment = "";
            objChangetask.Insert();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    protected void ShowValues()
    {
        BindOwner();
        int taskid = Convert.ToInt32(Request.QueryString[0]);
        objChangetask = objChangetask.Get_By_id(taskid);
        if (objChangetask.Taskid != 0)
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            txttitle.Text = objChangetask.Title.ToString();
            txtdescription.Text = objChangetask.Description.ToString();
            if (objChangetask.Scheduledendtime == null)
            {
                txtschdlendtime.Text = "";
            }
            else
            {
                txtschdlendtime.Text = objChangetask.Scheduledendtime.ToString();
            }
            if (objChangetask.Scheduledstarttime == null)
            {
                txtschedlstarttime.Text = "";
            }
            else
            {
                txtschedlstarttime.Text = objChangetask.Scheduledstarttime.ToString();
            }
            if (objChangetask.Actualendtime == null)
            {
                txtatendtime.Text = "";
            }
            else
            {
                txtatendtime.Text = objChangetask.Actualendtime.ToString();
            }

            if (objChangetask.Actualstarttime == null)
            {
                txtatsttime.Text = "";
            }
            else
            {
                txtatsttime.Text = objChangetask.Actualstarttime.ToString();
            }


            drpTechnician1.SelectedValue = objChangetask.Ownerid.ToString();
            drptaskstatus.SelectedValue = objChangetask.Taskstatusid.ToString();
        }



    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    { /////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string vardate = "";
            string vardate1 = "";
            string vardate2 = "";
            string vardate3 = "";


            DateTime dtendtime = new DateTime();
            if (txtatendtime.Text != "")
            {
                // string[] tempdate = txtatendtime.Text.ToString().Split(("/").ToCharArray());
                vardate = txtatendtime.Text.ToString();
                dtendtime = Convert.ToDateTime(vardate);
                objChangetask.Actualendtime = dtendtime.ToString();
            }
            else
            {
                vardate = null;
                objChangetask.Actualendtime = vardate;

            }


            DateTime actstarttime = new DateTime();
            if (txtatsttime.Text != "")
            {
                //  string[] Actualstarttime = txtatsttime.Text.ToString().Split(("/").ToCharArray());
                vardate1 = txtatsttime.Text.ToString();
                actstarttime = Convert.ToDateTime(vardate1);
                objChangetask.Actualstarttime = actstarttime.ToString();

            }
            else
            {
                vardate1 = null;
                objChangetask.Actualstarttime = vardate1;
            }


            DateTime schdstime = new DateTime();
            if (txtschedlstarttime.Text != "")
            {
                //  string[] Scheduledstarttime = txtschedlstarttime.Text.ToString().Split(("/").ToCharArray());
                vardate2 = txtschedlstarttime.Text.ToString();
                schdstime = Convert.ToDateTime(vardate2);
                objChangetask.Scheduledstarttime = schdstime.ToString();
            }
            else
            {
                vardate2 = null;
                objChangetask.Scheduledstarttime = vardate2;
            }

            DateTime dt = new DateTime();
            if (txtschdlendtime.Text != "")
            {
                //string[] Scheduledendtime = txtschdlendtime.Text.ToString().Split(("/").ToCharArray());
                //vardate3 = Scheduledendtime[2] + "-" + Scheduledendtime[1] + "-" + Scheduledendtime[0];
                vardate3 = txtschdlendtime.Text.ToString();

                dt = Convert.ToDateTime(vardate3);
                objChangetask.Scheduledendtime = dt.ToString();



            }
            else
            {
                vardate3 = null;
                objChangetask.Scheduledendtime = vardate3;
            }

            objChangetask.Title = txttitle.Text;
            objChangetask.Description = txtdescription.Text;
            objChangetask.Ownerid = Convert.ToInt32(drpTechnician1.SelectedValue);
            objChangetask.Taskstatusid = Convert.ToInt32(drptaskstatus.SelectedValue);
            objChangetask.Taskid = Convert.ToInt32(Request.QueryString[0]);
            objChangetask.Comment = "";
            objChangetask.Update();

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
