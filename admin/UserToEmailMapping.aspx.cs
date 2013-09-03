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
using System.Data;
using System.Data.SqlClient;



public partial class admin_UserToEmailMapping : System.Web.UI.Page
{
    UserLogin_mst objuser = new UserLogin_mst();
    BLLCollection<UserLogin_mst> coluser = new BLLCollection<UserLogin_mst>();
    ContactInfo_mst objusercontact = new ContactInfo_mst();
    BLLCollection<ContactInfo_mst> colcontact = new BLLCollection<ContactInfo_mst>();
    UserEmail objuseremail = new UserEmail();

    public int CHECKED_ITEMS;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGrid();
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

    protected void BindGrid()
    {

        //coluser = objuser.Get_All();
        //grdvwSite.DataSource = coluser;
        //grdvwSite.DataBind();
        colcontact = objusercontact.Get_By_comandname("A");
        grdvwSite.DataSource = colcontact;
        grdvwSite.DataBind();
        ViewState["commandname"] = "a";

    }
    protected void grdvwsite_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            TableCell cell = e.Row.Cells[0];

            cell.ColumnSpan = 6;

            for (int i = 65; i <= (65 + 25); i++)
            {

                LinkButton lb = new LinkButton();

                lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";

                lb.CommandArgument = Char.ConvertFromUtf32(i);

                lb.CommandName = "AlphaPaging";
                lb.Font.Size = FontUnit.Large;
                cell.Controls.Add(lb);

            }

        }
    }
    protected void grdvwSite_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        if (e.CommandName.Equals("AlphaPaging"))
        {
            string commandname = e.CommandArgument.ToString();
            ViewState["commandname"] = e.CommandArgument.ToString();

            colcontact = objusercontact.Get_By_comandname(commandname);
            if (colcontact.Count != 0)
            {

                grdvwSite.DataSource = colcontact;
                grdvwSite.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("userid");
                dt.Columns.Add("firstname");
                dt.Columns.Add("lastname");
                dt.Columns.Add("emailid");

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grdvwSite.DataSource = dt;
                grdvwSite.DataBind();

                //grdvwViewAsset.Rows[0].Cells[3].Visible = false;
                //grdvwViewAsset.Rows[0].Cells[5].Visible = false;


            }


        }

    }
    protected void BindGrid1()
    {
        string commandname;
        commandname = ViewState["commandname"].ToString();

        colcontact = objusercontact.Get_By_comandname(commandname);
        if (colcontact.Count != 0)
        {
            grdvwSite.DataSource = colcontact;
            grdvwSite.DataBind();
        }

    }
    protected void grdvwSite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        RememberOldValues();

        // Hndling GridView PageIndex Change Event for Paging  
        grdvwSite.PageIndex = e.NewPageIndex;
        // On Selected Page Index Bind Grid here

        BindGrid1();
        RePopulateValues();

    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        int index = -1;
        foreach (GridViewRow row in grdvwSite.Rows)
        {
            index = (int)grdvwSite.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("CheckAll")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!categoryIDList.Contains(index))
                    categoryIDList.Add(index);
            }
            else
                categoryIDList.Remove(index);
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in grdvwSite.Rows)
            {
                int index = (int)grdvwSite.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("CheckAll");
                    myCheckBox.Checked = true;
                }
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        DataTable dtMealTemplate = new DataTable();


        dtMealTemplate.Columns.Add("Userid", Type.GetType("System.Int32"));
        dtMealTemplate.Columns.Add("Emailid", Type.GetType("System.String"));
        foreach (GridViewRow gvr in grdvwSite.Rows)
        {
            ///DataRow drMT = new DataRow();

            DataRow drMT = dtMealTemplate.NewRow();
            drMT["Userid"] = gvr.Cells[1].Text;
            drMT["Emailid"] = gvr.Cells[4].Text;

            dtMealTemplate.Rows.Add(drMT);
            CheckBox myCheckBox = (CheckBox)gvr.FindControl("CheckAll");
            if (myCheckBox.Checked == true)
            {
                if (drMT["Emailid"].ToString() != "")
                {
                    UserEmail obj1 = new UserEmail();

                    objuseremail.Userid = Convert.ToInt32(drMT["Userid"]);
                    objuseremail.Emailid = drMT["Emailid"].ToString();
                    obj1 = obj1.Get_By_id(objuseremail.Userid);
                    if (obj1.Userid != objuseremail.Userid)
                    {
                        objuseremail.Insert();
                    }
                    if (obj1.Active == 0)
                    {
                        obj1.Active = 1;
                        obj1.Userid = objuseremail.Userid;
                        obj1.Emailid = objuseremail.Emailid;
                        obj1.Update();
                    }
                }
            }
        }

    }
    protected void btnreject_Click(object sender, EventArgs e)
    {
        DataTable dtMealTemplate = new DataTable();


        dtMealTemplate.Columns.Add("Userid", Type.GetType("System.Int32"));
        dtMealTemplate.Columns.Add("Emailid", Type.GetType("System.String"));
        foreach (GridViewRow gvr in grdvwSite.Rows)
        {
            ///DataRow drMT = new DataRow();

            DataRow drMT = dtMealTemplate.NewRow();
            drMT["Userid"] = gvr.Cells[1].Text;
            drMT["Emailid"] = gvr.Cells[4].Text;

            dtMealTemplate.Rows.Add(drMT);
            CheckBox myCheckBox = (CheckBox)gvr.FindControl("CheckAll");
            if (myCheckBox.Checked == false)
            {
                UserEmail obj1 = new UserEmail();

                objuseremail.Userid = Convert.ToInt32(drMT["Userid"]);
                objuseremail.Emailid = drMT["Emailid"].ToString();
                objuseremail.Active = 0;
                obj1 = obj1.Get_By_id(objuseremail.Userid);
                if (obj1.Userid == objuseremail.Userid)
                {
                    objuseremail.Update();
                }
            }
        }


    }

    protected void grdvwSite_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ////////////////////////////meenakshi
            if ((e.Row.Cells[1].Text) != "&nbsp;")
            {
                /////////////////end
                int userid = Convert.ToInt32(e.Row.Cells[1].Text);


                UserEmail objemail = new UserEmail();
                CheckBox myCheckBox = (CheckBox)e.Row.FindControl("CheckAll");
                //CheckBox myCheckBox = new CheckBox();
                objemail = objemail.Get_By_id(userid);
                if (objemail.Userid == userid)
                {
                    if (objemail.Active == 1)
                    {

                        // myCheckBox.Checked = true;
                        myCheckBox.Checked = true;

                    }
                    else
                    {

                        myCheckBox.Checked = false;
                    }
                }
            }
          }
    }

    /// <summary>
    /// /added by vishal 30-05-2012
    /// </summary>
    protected void btnMapAll_Click(object sender, EventArgs e)
    {
        UserEmail obj1 = new UserEmail();
        DataTable dt = BindGridMapAll();
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Emailid"].ToString() != "")
                {
                    objuseremail.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
                    objuseremail.Emailid = dt.Rows[i]["Emailid"].ToString();
                    obj1 = obj1.Get_By_id(objuseremail.Userid);
                    if (obj1.Userid != objuseremail.Userid)
                    {
                        objuseremail.Insert();
                    }
                    if (obj1.Active == 0)
                    {
                        obj1.Active = 1;
                        obj1.Userid = objuseremail.Userid;
                        obj1.Emailid = objuseremail.Emailid;
                        obj1.Update();
                    }
                }
            }
            BindGrid();
            string myScript;
            myScript = "<script language=javascript>alert('All user mapping successfully !');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    ///// <summary>
    ///// /added by vishal 30-05-2012
    ///// </summary>
    protected DataTable BindGridMapAll()
    {

        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String strCn = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString; // "Data Source=CSM-DEV\\SQL2008;Initial Catalog=hT_march;Persist Security Info=True;User ID=sa;Password=rimc@123;User Instance=False";// System.Configuration.ConfigurationManager.AppSettings["LocalSqlServer"].ToString();
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select userid,firstname,lastname,emailid from ContactInfo_mst";


        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];
        return dt;
        // ViewState["MapALL"] = dt;

    }
}
