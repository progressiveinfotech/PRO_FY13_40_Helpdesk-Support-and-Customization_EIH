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
using System.Data.SqlClient;

public partial class Incident_SelectAsset : System.Web.UI.Page
{
    
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objcontactinfo = new ContactInfo_mst(); //added by lalit 24feb 2012
    Incident_mst objincident = new Incident_mst();  ///added by meenakshi
    BLLCollection<Incident_mst> coli =new BLLCollection<Incident_mst>(); //added by meenakshi
    IncidentToAssetMapping objintoass=new IncidentToAssetMapping();//added by meenakshi
    BLLCollection<IncidentToAssetMapping> colin=new BLLCollection<IncidentToAssetMapping>();  //added by meenakshi                                     
    UserToAssetMapping objusertoasset = new UserToAssetMapping();
    
                                                
    int userid, assetcount, usercount;

    protected void Page_Load(object sender, EventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            string username = (string)(Session["Username"]);
            string usersess = (string)(Session["Us"]);
            Session["UName"] = usersess;
            Session["Username"] = usersess;
            int flag1 = 0;

            if (username == null)
            {
                lblusername.Text = "";

            }
            else
            {
                lblusername.Text = username.ToString();
            }
            //lblErrorMsg.Text = "";
            if (!IsPostBack)
            {
                col = ObjAsset.Get_NotAssign_By_comandname("");
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
                ViewState["commandname"] = "";
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
    //////////////////////////////////////////////////////////////////meenakshi
    //protected void btnMapped_Click(object sender, EventArgs e)
    //{/////Add Exception handilng try catch change by vishal 21-05-2012
    //    try
    //    {
    //        //lblErrorMsg.Text = "";
    //        int flag = 0;
    //        int tempuser;
    //        tempuser = Convert.ToInt32(Session["tempuser"]);

    //        foreach (GridViewRow gv in grdvwViewAsset.Rows)
    //        {
    //            string gvIDs;
    //            RadioButton selectonebutton = (RadioButton)gv.FindControl("selectone");
    //            if (selectonebutton.Checked)
    //            {
    //                flag = 1;
    //                int assetid;
    //                gvIDs = ((Label)gv.FindControl("lblAssetID")).Text.ToString();
    //                assetid = Convert.ToInt32(gvIDs);
    //                string Username = lblusername.Text.ToString().Trim();
    //                objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
    //                userid = objUser.Userid;
    //                if (lblusername.Text == "")
    //                {

    //                    //lblErrorMsg.Text = "Enter the user name for mapped a particular Asset";
    //                    break;
    //                }

    //                else if (tempuser == 1)
    //                {
    //                    assetcount = objusertoasset.Get_AssetId_From_UserToAssetMap(assetid);
    //                    int tempuser1 = 0;
    //                    if (assetcount == 0)
    //                    {
    //                        int flag1 = 1;
    //                        ObjAsset = ObjAsset.Get_By_id(assetid);
    //                        string compname = ObjAsset.Computername.ToString();
    //                        string username = lblusername.Text.ToString();
    //                        Session["compname"] = compname;
    //                        Session["flag"] = flag1;
    //                        Session["username"] = username;
    //                        Session["assetid"] = assetid;
    //                        Session["userid"] = userid;
    //                        tempuser1 = 1;
    //                        Session["tempuser1"] = tempuser1;
    //                        Session["flag1"] = flag1;
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        //lblErrorMsg.Text = "Asset already mapped";
    //                        break;
    //                    }
    //                }
    //                else if (userid == 0)
    //                {
    //                    //lblErrorMsg.Text = "User Name doen not exist";
    //                    break;
    //                }
    //                else
    //                {
    //                    assetcount = objusertoasset.Get_AssetId_From_UserToAssetMap(assetid);
    //                    usercount = objusertoasset.Get_UserId_From_UserToAssetMap(userid);
    //                    //  objcontactinfo = objcontactinfo.Get_By_id(userid);
    //                    objUser = objUser.Get_By_id(userid);
    //                    if (assetcount == 0)
    //                    {
    //                        if (usercount == 0)
    //                        {
    //                            int flag1 = 1;
    //                            objusertoasset.Insert(userid, assetid, objUser.City, objUser.Company);
    //                            //lblErrorMsg.Text = "Mapped Succussfully";
    //                            ObjAsset = ObjAsset.Get_By_id(assetid);
    //                            string compname = ObjAsset.Computername.ToString();
    //                            string username = lblusername.Text.ToString();
    //                            Session["compname"] = compname;
    //                            Session["flag"] = flag1;
    //                            Session["username"] = username;
    //                            Session["assetid"] = assetid;
    //                            Session["userid"] = userid;
    //                            Session["flag1"] = flag1;
    //                            break;

    //                        }
    //                        else  //Update Asset id from UserToAsset table.
    //                        {
    //                            int flag1 = 1;
    //                            int oldassetid = Convert.ToInt32(Session["assignassetid"]);
    //                            objusertoasset.Update_Assetid(oldassetid, assetid, objUser.City, objUser.Company);
    //                            ObjAsset = ObjAsset.Get_By_id(assetid);
    //                            string compname = ObjAsset.Computername.ToString();
    //                            string username = lblusername.Text.ToString();
    //                            Session["compname"] = compname;
    //                            Session["flag"] = flag1;
    //                            Session["username"] = username;
    //                            Session["assetid"] = assetid;
    //                            Session["userid"] = userid;
    //                            Session["flag1"] = flag1;
    //                            break;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        //lblErrorMsg.Text = "Asset already mapped";
    //                        break;
    //                    }
    //                }
    //            }

    //        }
    //        if (flag == 0)
    //        {
    //            //lblErrorMsg.Text = "Select Asset for mapping";
    //        }

    //        string myScript;
    //        myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
    //        Page.RegisterClientScriptBlock("MyScript", myScript);
    //    }
    //    catch (Exception ex)
        
    //        string myScript;
    //        myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
    //        Page.RegisterClientScriptBlock("MyScript", myScript);
    //        return;
    //    }
   // }




    protected void btnSelect_Click(object sender, EventArgs e)
    {
        try
        {
            int flag = 0;
            foreach (GridViewRow gv in grdvwViewAsset.Rows)
            {
                string gvIDs;
                RadioButton selectonebutton = (RadioButton)gv.FindControl("selectone");
                if (selectonebutton.Checked)
                {
                    flag = 1;
                    int assetid;
                    gvIDs = ((Label)gv.FindControl("lblAssetID")).Text.ToString();
                    assetid = Convert.ToInt32(gvIDs);
                    Session["assId"] = assetid;
                    int incidentid = Convert.ToInt32(Session["incidentid"]);

                    colin = objintoass.Get_All();
                    //objintoass.incidentid=Convert.ToInt32(objintoass.Get_incidentId_From_incidentToAssetMap(incidentid));
                    int Count = Convert.ToInt32(objintoass.Get_incidentId_From_incidentToAssetMap(incidentid));
                    IncidentToAssetMapping objincass = new IncidentToAssetMapping();
                    if (incidentid != 0 && assetid != 0)
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            string sQuery = ("update IncidentToAssetMapping set assetid='" + assetid + "' where incidentid='" + incidentid + "'");
                            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CSM_DB"].ToString();
                            SqlConnection sc = new SqlConnection(constr);
                            sc.Open();
                            SqlCommand cmd = new SqlCommand(sQuery, sc);
                            SqlDataReader dr = cmd.ExecuteReader();
                            dr.Read();
                            //ObjAsset = ObjAsset.Get_By_id(assetid);
                            //string compname = ObjAsset.Computername.ToString();
                            //Session["compname"] = compname;
                            //Session["flag"] = flag;
                        }

                        if (Count == 0)
                        {
                            objincass.Insert(incidentid, assetid);
                            //ObjAsset = ObjAsset.Get_By_id(assetid);
                            //string compname = ObjAsset.Computername.ToString();
                            //Session["compname"] = compname;
                            //Session["flag"] = flag;
                            break;
                        }
                        
                    }
                    ObjAsset = ObjAsset.Get_By_id(assetid);
                    string compname = ObjAsset.Computername.ToString();
                    Session["compname"] = compname;
                    Session["flag"] = flag;
                }
            }
                string myScript;
                myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
                Page.RegisterClientScriptBlock("MyScript", myScript);

            
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
 }

  
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////end
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        //lblErrorMsg.Text = "";
        try
        {
            grdvwViewAsset.PageIndex = e.NewPageIndex;
            BindGrid1();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }

    public void BindGrid()
    {
        //lblErrorMsg.Text = "";
        col = ObjAsset.Get_By_comandname("A");
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        ViewState["commandname"] = "a";
    }

    protected void BindGrid1()
    {
        //lblErrorMsg.Text = "";
        string commandname;
        commandname = ViewState["commandname"].ToString();
        col = ObjAsset.Get_NotAssign_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
            
        }
    }

    protected void grdvwViewAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        //lblErrorMsg.Text = "";
        try
        {
            if (e.CommandName.Equals("AlphaPaging"))
            {
                string commandname = e.CommandArgument.ToString();
                ViewState["commandname"] = e.CommandArgument.ToString();
                col = ObjAsset.Get_By_comandname(commandname);
                if (col.Count != 0)
                {
                    grdvwViewAsset.DataSource = col;
                    grdvwViewAsset.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("assetid");
                    dt.Columns.Add("computername");
                    dt.Columns.Add("domain");
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    grdvwViewAsset.DataSource = dt;
                    grdvwViewAsset.DataBind();
                }
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

    protected void grdvwViewAsset_RowCreated(object sender, GridViewRowEventArgs e)
    {/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            //lblErrorMsg.Text = "";
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
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }
    }
}
