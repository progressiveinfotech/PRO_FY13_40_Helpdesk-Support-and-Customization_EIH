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

public partial class Asset_UserToAssetMapping : System.Web.UI.Page
{
    UserToAssetMapping objusertoasset = new UserToAssetMapping();
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objcontactinfo = new ContactInfo_mst(); //added by lalit 24feb 2012
    int userid, assetcount, usercount;
    string assetlocation,companyname;

    protected void Page_Load(object sender, EventArgs e)
    {
        
/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            this.ClientScript.GetPostBackEventReference(this, "arg");

            // Values for SelectAsset Page after select the asset for a particular user
            int flag = Convert.ToInt32(Session["flag2"]);
            if (flag == 1)
            {
                string username;
                userid = Convert.ToInt32(Session["userid"]);
                username = (string)(Session["username"]);
                txtusername.Text = username.ToString();
                Session["flag2"] = "0";

            }


            lblErrorMsg.Text = "";
            if (!IsPostBack)
            {
                //string name;
                //if (txtname.Text == "")
                //{

                //    ViewState["commandname"] = "";
                //}
                //else
                //{
                //    name = txtname.Text.ToString();
                //    col = ObjAsset.Get_By_comandname(name);
                //    grdvwViewAsset.DataSource = col;
                //    grdvwViewAsset.DataBind();
                //    ViewState["commandname"] = name;
                //}

                // col = ObjAsset.Get_By_comandname("");
                col = ObjAsset.Get_NotAssign_By_comandname("");
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
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
    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    lblErrorMsg.Text = "";
    //    string name;

    //    if (txtname.Text == "")
    //    {
    //        col = ObjAsset.Get_By_comandname("");
    //        grdvwViewAsset.DataSource = col;
    //        grdvwViewAsset.DataBind();
    //        ViewState["commandname"] = "";
    //    }
    //    else
    //    {
    //        name = txtname.Text.ToString();
    //        col = ObjAsset.Get_By_comandname(name);
    //        grdvwViewAsset.DataSource = col;
    //        grdvwViewAsset.DataBind();
    //        ViewState["commandname"] = name;
    //    }
    //}
    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            lblErrorMsg.Text = "";
            grdvwViewAsset.PageIndex = e.NewPageIndex;
            col = ObjAsset.Get_NotAssign_By_comandname("");
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Exception - '" + ex + "');</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
            return;
        }

    }
    //public void BindGrid()
    //{
    //    lblErrorMsg.Text = "";
    //    col = ObjAsset.Get_By_comandname("A");
    //    grdvwViewAsset.DataSource = col;
    //    grdvwViewAsset.DataBind();
    //    ViewState["commandname"] = "a";

    //}
    //protected void BindGrid1()
    //{
    //    lblErrorMsg.Text = "";
    //    string commandname;
    //    commandname = ViewState["commandname"].ToString();
    //    col = ObjAsset.Get_By_comandname(commandname);
    //    if (col.Count != 0)
    //    {
    //        grdvwViewAsset.DataSource = col;
    //        grdvwViewAsset.DataBind();
    //    }

    //}
   
    protected void grdvwViewAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            lblErrorMsg.Text = "";
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
    {
        //lblErrorMsg.Text = "";
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    TableCell cell = e.Row.Cells[0];

        //    cell.ColumnSpan = 6;

        //    for (int i = 65; i <= (65 + 25); i++)
        //    {

        //        LinkButton lb = new LinkButton();

        //        lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";

        //        lb.CommandArgument = Char.ConvertFromUtf32(i);

        //        lb.CommandName = "AlphaPaging";
        //        lb.Font.Size = FontUnit.Large;
        //        cell.Controls.Add(lb);

        //    }

        //}
    }

    //protected void btngetuser_Click(object sender, EventArgs e)
    //{
    //    lblErrorMsg.Text = "";
    //    string Username = txtusername.Text.ToString().Trim();
    //    objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
    //    if (objUser.Userid != 0)
    //    {
    //        txtusername.Text = objUser.Username.ToString().Trim();
    //        userid = objUser.Userid;
    //    }
    //    else
    //    {
    //        txtusername.Text = "";
            
    //    }
    //}
    
    //protected void btnshow_Click(object sender, EventArgs e)
    //{
    //    lblErrorMsg.Text = "";
    //    string Username = txtusername.Text.ToString().Trim();
    //    objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
    //    userid = objUser.Userid;
    //    int assid=Convert.ToInt32(objusertoasset.Get_AssetId_By_UserId(userid));
    //    int usercount = objusertoasset.Get_UserId_From_UserToAssetMap(userid);
    //    col = ObjAsset.Get_Assetdetails_By_Assetid(assid);
    //    grdvwViewAsset.DataSource = col;
    //    grdvwViewAsset.DataBind();
    //    foreach (GridViewRow gv in grdvwViewAsset.Rows)
    //    {
    //        RadioButton selectonebutton = (RadioButton)gv.FindControl("selectone");
    //        selectonebutton.Checked = true;
    //    }
    //}

    protected void btnMapped_Click(object sender, EventArgs e)
    {
        
/////Add Exception handilng try catch change by vishal 21-05-2012
        try
        {
            lblErrorMsg.Text = "";
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

                    string Username = txtusername.Text.ToString().Trim();
                    objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
                    //objcontactinfo = objcontactinfo.Get_By_id(objUser.Userid); //added by lalit 24 feb 2012
                    userid = objUser.Userid;
                    if (txtusername.Text == "")
                    {
                        lblErrorMsg.Text = "Enter the user name for mapped a particular Asset";
                        break;
                    }
                    else if (userid == 0)
                    {
                        lblErrorMsg.Text = "User Name doesn't  exist";
                        break;
                    }
                    else
                    {
                        assetcount = objusertoasset.Get_AssetId_From_UserToAssetMap(assetid);
                        usercount = objusertoasset.Get_UserId_From_UserToAssetMap(userid);
                        assetlocation = objUser.City;  //added by lalit 24 feb 2012
                        companyname = objUser.Company;
                        if (assetcount == 0)
                        {
                            if (usercount == 0)
                            {
                                objusertoasset.Insert(userid, assetid, assetlocation, companyname);  //added a new field siteid on 24 feb.
                                lblErrorMsg.Text = "Asset Mapped Successfully to the Current User";
                                break;
                            }
                            else
                            {
                                int oldassetid = Convert.ToInt32(objusertoasset.Get_AssetId_By_UserId(userid));
                                objusertoasset.Update_Assetid(oldassetid, assetid, assetlocation, companyname);
                                lblErrorMsg.Text = "Asset Mapped Successfully to the Current User";
                                break;
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = "Asset already Mapped";
                            break;
                        }
                    }
                }

            }
            if (flag == 0)
            {
                lblErrorMsg.Text = "Select Asset for mapping";
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
    }



}
