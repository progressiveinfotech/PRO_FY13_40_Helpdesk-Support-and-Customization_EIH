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

public partial class admin_EditSLADefinition : System.Web.UI.Page
{
    #region Declaration of objects of various classes
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    Priority_mst objPriority = new Priority_mst();
    BLLCollection<Priority_mst> colPriority = new BLLCollection<Priority_mst>();
    SLA_mst objSla = new SLA_mst();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    EscalateLevel1 objLevel1 = new EscalateLevel1();
    EscalateLevel2 objLevel2 = new EscalateLevel2();
    EscalateLevel3 objLevel3 = new EscalateLevel3();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    BLLCollection<EscalateEmail_mst> col = new BLLCollection<EscalateEmail_mst>();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region Validator Fields fetch Messages from MessagesResources.resx file located in App_GlobalResources  directory
            reqValtxtDays.ErrorMessage = Resources.MessageResource.strEnterDays.ToString();
            reqValtxtSla.ErrorMessage = Resources.MessageResource.strEnterSLA.ToString();
            #endregion
            #region Definition of Default values of controls
            txtDays.Text = "0";
            txtDaysLevel1.Text = "0";
            txtDaysLevel2.Text = "0";
            txtDaysLevel3.Text = "0";
            #endregion
            #region Call various functions to bind list box and show stored values in database
            BindListBox();
            Update();
            Level1Escalate();
            Level2Escalate();
            Level3Escalate();
            #endregion
        }
    }

    #region Definition of Update Functions
    protected void Update()
    {
        int Slaid = Convert.ToInt32(Request.QueryString[0]);
        objSla = objSla.Get_By_id(Slaid);
        if (objSla.Slaid!=0)
        {
            int siteid = objSla.Siteid;
            objSite = objSite.Get_By_id(siteid);
            if (objSite.Siteid !=0)
            {
                lblSite.Text = objSite.Sitename;
            }
            txtSlaName.Text = objSla.Slaname.ToString().Trim();
            txtDescription.Text = objSla.Description.ToString().Trim();
            objSlaPriority = objSlaPriority.Get_By_id(objSla.Slaid);
            if (objSlaPriority.Priorityid!=0)
            {
               objPriority= objPriority.Get_By_id(objSlaPriority.Priorityid);
               if (objPriority.Priorityid!=0)
                {
                    lblPriority.Text = objPriority.Name.ToString().Trim();
                    drphr.SelectedValue = Convert.ToString(objSlaPriority.Resolutionhours);
                    drpMin.SelectedValue = Convert.ToString(objSlaPriority.Resolutionmin);
                    txtDays.Text = Convert.ToString(objSlaPriority.Resolutiondays);
                }
            }
        }
    }
    #endregion
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/ViewSla.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool FlagEscalateLevel1 = true;
        bool FlagEscalateLevel2 = true;
        bool FlagEscalateLevel3 = true;
        lblErrorTimeSelect.Text = "";
        if (txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0")
        {
            lblErrorTimeSelect.Text = Resources.MessageResource.errResTime.ToString();
        }
        else 
        {
            if (chkLevel1.Checked == true)
            {
                if (radio1Level1.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel1 = calculateTotalminutesLevel1();
                    if (varTotalTimeLevel1 > varTotalTime)
                    { 
                        FlagEscalateLevel1 = false; 
                    }
                }
                if (radio2Level1.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel1 = calculateTotalminutesLevel1();
                    //if (varTotalTimeLevel1 < varTotalTime)
                    //{ 
                    //    FlagEscalateLevel1 = false; 
                    //}
                }
            }
            if (chkLevel2.Checked == true)
            {
                if (radio1Level2.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel2 = calculateTotalminutesLevel2();
                    if (varTotalTimeLevel2 > varTotalTime)
                    { FlagEscalateLevel2 = false; }
                }
                if (radio2Level2.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel2 = calculateTotalminutesLevel2();
                    //if (varTotalTimeLevel2 < varTotalTime)
                    //{ 
                    //    FlagEscalateLevel2 = false; 
                    //}
                }
            }
            if (chkLevel3.Checked == true)
            {
                if (radio1Level3.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel3 = calculateTotalminutesLevel3();
                    if (varTotalTimeLevel3 > varTotalTime)
                    { FlagEscalateLevel3 = false; }
                }
                if (radio2Level3.Checked == true)
                {
                    int varTotalTime = calculateTotalminutes();
                    int varTotalTimeLevel3 = calculateTotalminutesLevel3();
                    //if (varTotalTimeLevel3 < varTotalTime)
                    //{ 
                    //    FlagEscalateLevel3 = false; 
                    //}
                }
            }
            int Slaid = Convert.ToInt32(Request.QueryString[0]);
            objSla = objSla.Get_By_id(Slaid);
            if (objSla.Slaid != 0)
            {
                if (FlagEscalateLevel1 == true && FlagEscalateLevel2 == true && FlagEscalateLevel3 == true)
                {
                    if (chkLevel1.Checked == true)
                    {
                        UpdateLevel1Escalate(Slaid);
                    }
                    else 
                    {
                        UncheckedLevel1Escalate(Slaid);
                    }
                    if (chkLevel2.Checked == true)
                    {
                        UpdateLevel2Escalate(Slaid);
                    }
                    else 
                    {
                        UncheckedLevel2Escalate(Slaid);
                    }
                    if (chkLevel3.Checked == true)
                    {
                        UpdateLevel3Escalate(Slaid);
                    }
                    else
                    {
                        UncheckedLevel3Escalate(Slaid);
                    }
                    if (objSla.Slaname == txtSlaName.Text.ToString().Trim())
                    {
                        objSla.Description = txtDescription.Text.ToString().Trim();
                        objSlaPriority = objSlaPriority.Get_By_id(objSla.Slaid);
                        if (objSlaPriority.Slaid != 0)
                        {
                            objSlaPriority.Resolutiondays = Convert.ToInt32(txtDays.Text);
                            objSlaPriority.Resolutionhours = Convert.ToInt32(drphr.SelectedValue);
                            objSlaPriority.Resolutionmin = Convert.ToInt32(drpMin.SelectedValue);
                            objSla.Update();
                            objSlaPriority.Update();
                            Response.Redirect("~/admin/ViewSla.aspx");
                        }
                    }
                    else
                    {
                        SLA_mst objSLa1 = new SLA_mst();
                        objSLa1 = objSla.Get_By_SLAName(txtSlaName.Text.ToString().Trim(), objSla.Siteid);
                        if (objSLa1.Slaid == 0)
                        {
                            objSla.Slaname = txtSlaName.Text.ToString().Trim();
                            objSla.Description = txtDescription.Text.ToString().Trim();
                            objSlaPriority = objSlaPriority.Get_By_id(objSla.Slaid);
                            if (objSlaPriority.Slaid != 0)
                            {
                                objSlaPriority.Resolutiondays = Convert.ToInt32(txtDays.Text);
                                objSlaPriority.Resolutionhours = Convert.ToInt32(drphr.SelectedValue);
                                objSlaPriority.Resolutionmin = Convert.ToInt32(drpMin.SelectedValue);
                                objSla.Update();
                                objSlaPriority.Update();
                                Response.Redirect("~/admin/ViewSla.aspx");
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.MessageResource.errSLAExist.ToString();
                        }
                    }
                }
                else
                {
                    if (FlagEscalateLevel1 == false)
                    {
                        lblErrorMsg.Text = Resources.MessageResource.strLevel1.ToString();
                    }
                    if (FlagEscalateLevel2 == false)
                    {
                        lblErrorMsg.Text = Resources.MessageResource.strLevel2.ToString();
                    }
                    if (FlagEscalateLevel3 == false)
                    {
                        lblErrorMsg.Text = Resources.MessageResource.strLevel3.ToString();
                    }
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.MessageResource.errOccured.ToString();
            }
        }
    }

    protected void Level1Escalate()
    {
        int Slaid = Convert.ToInt32(Request.QueryString[0]);
        objLevel1 = objLevel1.Get_By_Slaid(Slaid);
        if (objLevel1.Slaid != 0)
        {
            string varEmail = objLevel1.Emailid;
            string[] arrEmail = varEmail.Split(',');

            if (arrEmail.Length > 2)
            {
                selectLevale1.Text = objLevel1.Emailid;
            }
            else { selectLevale1.Text = arrEmail[0].ToString(); }


            chkLevel1.Checked = true;
            if (objLevel1.Before == true)
            {
                radio1Level1.Checked = true;
            }
            else 
            { 
                radio2Level1.Checked = true; 
            }
            txtDaysLevel1.Text = Convert.ToString(objLevel1.Days);
            drpHoursLevel1.SelectedIndex = objLevel1.Hours;
            drpMinlevel1.SelectedIndex = objLevel1.Min;
        }
        else 
        {
            selectLevale1.Visible = false;
            listLevel1.Visible = true;
            radio1Level1.Checked = true;
        }
    }

    protected void Level2Escalate()
    {
        int Slaid = Convert.ToInt32(Request.QueryString[0]);
        objLevel2 = objLevel2.Get_By_Slaid(Slaid);
        if (objLevel2.Slaid != 0)
        {
            string varEmail = objLevel2.Emailid;
            string[] arrEmail = varEmail.Split(',');
            if (arrEmail.Length > 2)
            {
                selectLevale2.Text = objLevel2.Emailid;
            }
            else { selectLevale2.Text = arrEmail[0].ToString(); }
            chkLevel2.Checked = true;
            if (objLevel2.Before == true)
            {
                radio1Level2.Checked = true;
            }
            else { radio2Level2.Checked = true; }
            txtDaysLevel2.Text = Convert.ToString(objLevel2.Days);
            drpHoursLevel2.SelectedIndex = objLevel2.Hours;
            drpMinLevel2.SelectedIndex = objLevel2.Min;
        }
        else
        {
            selectLevale2.Visible = false;
            listLevel2.Visible = true;
            radio1Level2.Checked = true;
        }
    }

    protected void Level3Escalate()
    {
        int Slaid = Convert.ToInt32(Request.QueryString[0]);
        objLevel3 = objLevel3.Get_By_Slaid(Slaid);
        if (objLevel3.Slaid != 0)
        {
            string varEmail = objLevel3.Emailid;
            string[] arrEmail = varEmail.Split(',');
            if (arrEmail.Length > 2)
            {
                selectLevale3.Text = objLevel3.Emailid;
            }
            else { selectLevale3.Text = arrEmail[0].ToString(); }
            chkLevel3.Checked = true;
            if (objLevel3.Before == true)
            {
                radio1Level3.Checked = true;
            }
            else { radio2Level3.Checked = true; }
            txtDaysLevel3.Text = Convert.ToString(objLevel3.Days);
            drpHoursLevel3.SelectedIndex = objLevel3.Hours;
            drpMinLevel3.SelectedIndex = objLevel3.Min;
        }
        else
        {
            selectLevale3.Visible = false;
            listLevel3.Visible = true;
            radio1Level3.Checked = true;
        }
    }

    protected void BindListBox()
    {
        col = objEscalateEmail.Get_All();
        listLevel1.DataTextField = "email";
        listLevel1.DataValueField = "id";
        listLevel1.DataSource = col;
        listLevel1.DataBind();

        listLevel2.DataTextField = "email";
        listLevel2.DataValueField = "id";
        listLevel2.DataSource = col;
        listLevel2.DataBind();

        listLevel3.DataTextField = "email";
        listLevel3.DataValueField = "id";
        listLevel3.DataSource = col;
        listLevel3.DataBind();
    }

    protected void lnkLevel1_Click(object sender, EventArgs e)
    {
        selectLevale1.Visible = false;
        listLevel1.Visible = true;
        lnkLevel1.Visible = false;
        lnkCancelLevel1.Visible = true;
    }

    protected void lnkCancelLevel1_Click(object sender, EventArgs e)
    {
        selectLevale1.Visible = true;
        listLevel1.Visible = false;
        lnkLevel1.Visible = true;
        lnkCancelLevel1.Visible = false;
    }

    protected void lnkLevel2_Click(object sender, EventArgs e)
    {
        selectLevale2.Visible = false;
        listLevel2.Visible = true;
        lnkLevel2.Visible = false;
        lnkCancelLevel2.Visible = true;
    }

    protected void lnkCancelLevel2_Click(object sender, EventArgs e)
    {
        selectLevale2.Visible = true;
        listLevel2.Visible = false;
        lnkLevel2.Visible = true;
        lnkCancelLevel2.Visible = false;
    }

    protected void lnkLevel3_Click(object sender, EventArgs e)
    {
        selectLevale3.Visible = false;
        listLevel3.Visible = true;
        lnkLevel3.Visible = false;
        lnkCancelLevel3.Visible = true;
    }

    protected void lnkCancelLevel3_Click(object sender, EventArgs e)
    {
        selectLevale3.Visible = true;
        listLevel3.Visible = false;
        lnkLevel3.Visible = true;
        lnkCancelLevel3.Visible = false;
    }

    protected void UpdateLevel1Escalate(int Slaid)
    {
        EscalateLevel1 obj = new EscalateLevel1();
        string varemail = "";
        if (radio1Level1.Checked == true)
        {
            objLevel1.After = false;
            objLevel1.Before = true;
        }
        else
        {
            objLevel1.After = true;
            objLevel1.Before = false;
        }
        objLevel1.Slaid = Slaid;
        for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel1.Items[i].Selected == true)
            {
                varemail = varemail + listLevel1.Items[i].Text + ",";
            }
        }
        objLevel1.Days = Convert.ToInt32(txtDaysLevel1.Text);
        objLevel1.Hours = Convert.ToInt32(drpHoursLevel1.SelectedValue);
        objLevel1.Min = Convert.ToInt32(drpMinlevel1.SelectedValue);
        obj = obj.Get_By_Slaid(Slaid);
        if (obj.Slaid != 0)
        {
            if (varemail == "")
            {
                varemail = obj.Emailid;
            }
            objLevel1.Emailid = varemail;
            objLevel1.Level1id = obj.Level1id;
            objLevel1.Update();
        }
        else 
        {
            objLevel1.Emailid = varemail;
            objLevel1.Insert(); 
        }
    }


    protected void UpdateLevel2Escalate(int Slaid)
    {
        EscalateLevel2 obj = new EscalateLevel2();
        string varemail = "";
        if (radio1Level2.Checked == true)
        {
            objLevel2.After = false;
            objLevel2.Before = true;
        }
        else
        {
            objLevel2.After = true;
            objLevel2.Before = false;
        }
        objLevel2.Slaid = Slaid;
        for (int i = listLevel2.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel2.Items[i].Selected == true)
            {
                varemail = varemail + listLevel2.Items[i].Text + ",";
            }
        }
        objLevel2.Days = Convert.ToInt32(txtDaysLevel2.Text);
        objLevel2.Hours = Convert.ToInt32(drpHoursLevel2.SelectedValue);
        objLevel2.Min = Convert.ToInt32(drpMinLevel2.SelectedValue);
        obj = obj.Get_By_Slaid(Slaid);
        if (obj.Slaid != 0)
        {
            if (varemail == "")
            {
                varemail = obj.Emailid;
            }
            objLevel2.Emailid = varemail;
            objLevel2.Level2id = obj.Level2id;
            objLevel2.Update();
        }
        else 
        {
            objLevel2.Emailid = varemail;
            objLevel2.Insert();
        }
    }

    protected void UpdateLevel3Escalate(int Slaid)
    {
        EscalateLevel3 obj = new EscalateLevel3();
        string varemail = "";
        if (radio1Level3.Checked == true)
        {
            objLevel3.After = false;
            objLevel3.Before = true;
        }
        else
        {
            objLevel3.After = true;
            objLevel3.Before = false;
        }
        objLevel3.Slaid = Slaid;
        for (int i = listLevel3.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel3.Items[i].Selected == true)
            {
                varemail = varemail + listLevel3.Items[i].Text + ",";
            }
        }
        objLevel3.Days = Convert.ToInt32(txtDaysLevel3.Text);
        objLevel3.Hours = Convert.ToInt32(drpHoursLevel3.SelectedValue);
        objLevel3.Min = Convert.ToInt32(drpMinLevel3.SelectedValue);
        obj = obj.Get_By_Slaid(Slaid);
        if (obj.Slaid != 0)
        {
            if (varemail == "")
            {
                varemail = obj.Emailid;
            }
            objLevel3.Emailid = varemail;
            objLevel3.Level3id = obj.Level3id;
            objLevel3.Update();
        }
        else 
        {
            objLevel3.Emailid = varemail;
            objLevel3.Insert();
        }
    }

    protected int calculateTotalminutes()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;

        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDays.Text != "0")
        {
            varDays = Convert.ToInt32(txtDays.Text);
        }
        if (drphr.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drphr.SelectedValue);
        }
        if (drpMin.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMin.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected int calculateTotalminutesLevel1()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;

        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel1.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel1.Text);
        }
        if (drpHoursLevel1.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel1.SelectedValue);
        }
        if (drpMinlevel1.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinlevel1.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected int calculateTotalminutesLevel2()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;
        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel2.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel2.Text);
        }
        if (drpHoursLevel2.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel2.SelectedValue);
        }
        if (drpMinLevel2.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinLevel2.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected int calculateTotalminutesLevel3()
    {
        int varDays = 0;
        int varHours = 0;
        int varMin = 0;
        int vatTotalMin = 0;
        //txtDays.Text == "0" && drphr.SelectedValue == "0" && drpMin.SelectedValue == "0"
        if (txtDaysLevel3.Text != "0")
        {
            varDays = Convert.ToInt32(txtDaysLevel3.Text);
        }
        if (drpHoursLevel3.SelectedValue != "0")
        {
            varHours = Convert.ToInt32(drpHoursLevel3.SelectedValue);
        }
        if (drpMinLevel3.SelectedValue != "0")
        {
            varMin = Convert.ToInt32(drpMinLevel3.SelectedValue);
        }
        vatTotalMin = (varDays * 24 * 60) + (varHours * 60) + varMin;
        return vatTotalMin;
    }

    protected void UncheckedLevel1Escalate(int Slaid)
    {
        objLevel1 = objLevel1.Get_By_Slaid(Slaid);
        if (objLevel1.Slaid != 0)
        {
            int varLevelid1;
            varLevelid1 = objLevel1.Level1id;
            objLevel1.Delete(varLevelid1);
        }
    }

    protected void UncheckedLevel2Escalate(int Slaid)
    {
        objLevel2 = objLevel2.Get_By_Slaid(Slaid);
        if (objLevel2.Slaid != 0)
        {
            int varLevelid2;
            varLevelid2 = objLevel2.Level2id;
            objLevel2.Delete(varLevelid2);
        }
    }

    protected void UncheckedLevel3Escalate(int Slaid)
    {
        objLevel3 = objLevel3.Get_By_Slaid(Slaid);
        if (objLevel3.Slaid != 0)
        {
            int varLevelid3;
            varLevelid3 = objLevel3.Level3id;
            objLevel3.Delete(varLevelid3);
        }
    }
}
