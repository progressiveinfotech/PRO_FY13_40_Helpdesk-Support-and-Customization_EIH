using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_HubToSiteMapping : System.Web.UI.Page
{
    Site_mst objSite = new Site_mst();
    Hub_mst objHub = new Hub_mst();
    HubToSiteMapping objHubToSite = new HubToSiteMapping();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindDrpCategory();
            BindSite();
            BindHub();
        }
    }
    #region Event to bind category
    public void BindSite()
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        col = objSite.Get_All();
        drpSite.DataTextField = "SiteName";
        drpSite.DataValueField = "Siteid";
        drpSite.DataSource = col;
        drpSite.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select--------------";
        item.Value = "0";
        drpSite.Items.Add(item);
        drpSite.SelectedValue = "0";
    }
    #endregion

    #region Event to bind category
    public void BindHub()
    {
        BLLCollection<Hub_mst> col = new BLLCollection<Hub_mst>();
        col = objHub.Get_All();
        drpHub.DataTextField = "HubName";
        drpHub.DataValueField = "Hubid";
        drpHub.DataSource = col;
        drpHub.DataBind();
        ListItem item = new ListItem();
        item.Text = "--------------Select--------------";
        item.Value = "0";
        drpHub.Items.Add(item);
        drpHub.SelectedValue = "0";
    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected bool IsSiteExist(int siteid)
    {
        bool siteexist = false;
        objHubToSite = objHubToSite.Get_By_Siteid(siteid);
        if (objHubToSite.Hubid != 0)
        {
            siteexist = true;
        }
        return siteexist;
    }
    protected int Hubid(int siteid)
    {
        objHubToSite = objHubToSite.Get_By_Siteid(siteid);
        return objHubToSite.Hubid;
    }
    protected bool IsSiteHubExist(int siteid,int Hubid)
    {
        bool sitehubexist = false;
        objHubToSite = objHubToSite.Get_By_Siteid_Hubid(siteid,Hubid);
        if (objHubToSite.Hubid != 0)
        {
            sitehubexist = true;
        }
        return sitehubexist;
    }
    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        //check whether site mapped to hub
        //if mapped then bind Hub and select site
        try
        {
            int siteid = Convert.ToInt32(drpSite.SelectedItem.Value);
            if (IsSiteExist(siteid))
            { 
                //find siteid
                int hubid = Hubid(siteid);
                //BindHub();
                drpHub.SelectedItem.Selected = false;
                drpHub.Items.FindByValue(objHubToSite.Hubid.ToString()).Selected = true;
                lblerrmsg.Text = "";
            }
            else
            {
                BindHub();
            } 
        }
        catch (Exception ex)
        {

        }
        //end
        //else bind hub all data
        //end
        //end
        

    }
    protected void btnSubcategoryadd_Click(object sender, EventArgs e)
    {
        int siteid = Convert.ToInt32(drpSite.SelectedItem.Value);
        int Hubid = Convert.ToInt32(drpHub.SelectedItem.Value);
        //check where siteid and hubid exist
        //first check user exist or not if exist then update else add
        if (IsSiteExist(siteid))
           {
            //objHubToSite.Siteid = siteid;
            //objHubToSite.Hubid = Hubid;
            //objHubToSite.Update();
            lblerrmsg.Text = "Hub is already added";
           }
        else
        {
            objHubToSite.Hubid = Hubid;
            objHubToSite.Siteid = siteid;
            objHubToSite.Insert();
            lblerrmsg.Text = "New Hub added";
        }
        //end
        //
        //save site id and hubid
    }
}
