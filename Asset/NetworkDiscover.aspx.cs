using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Tracker_NetworkDiscover : System.Web.UI.Page
{
    CommonNetworkInventory common_network_invertoty = new CommonNetworkInventory();
    public string param_device;
    public string[] filenames;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lbluser = new Label();
        //lbluser = (Label)Master.FindControl("lblUserIdentity");
        //lbluser.Text = "Sign in as : " + User.Identity.Name.ToString();
        
        //if (!(this.User.IsInRole("admins")))
        //{

        //    Master.FindControl("ImgBtnAdmin").Visible = false;
        //    Master.FindControl("ImgBtnAddInventory").Visible = false;
        //    Master.FindControl("imgAdmin").Visible = false;
        //    Master.FindControl("lnkAdminM").Visible = false;
        //    Master.FindControl("ImgAddInventoryM").Visible = false;
        //    Master.FindControl("lnkAddInventoryM").Visible = false;


        //}
        
        int flagcnt;
        //param_device = (string)Session["param_device"];
        //if (param_device != null && param_device != "")
        //{

           
            // To Chekch Computer Exist In Organization via xml file
            filenames = Get_Data_Files();
            flagcnt = filenames.Length;
            int flag = 0;
            //for (int i = 0; i < flagcnt; i++)
            //{
            //    string f = filenames[i].ToString();

                //if (param_device.Trim() == f.Trim())
                //{
                    //common_network_invertoty.Load_Data(param_device);
            if (Session["param_node"] != null)
            {
                common_network_invertoty.Load_Data(Session["param_node"].ToString());
                Show_Inventory_Data();
            }
                    flag = 1;

                //}

            //}
            //if (flag == 0)
            //{
            //    Session["param_node"] = null;
            //    string myScript;
            //    myScript = "<script language=javascript>alert('Computer not found!, Ensure that computer is in the Domain and User Login to the Domain.'); </script>";
            //    Page.RegisterClientScriptBlock("MyScript", myScript);
            //}

        //}

    }

    public void Show_Inventory_Data()
    {
        /* General Device Information */
        lbl_device.Text = common_network_invertoty.computer_name;
        lbl_device_value.Text = common_network_invertoty.computer_name;
        lbl_inventory_value.Text = common_network_invertoty.inventory_date;
        lbl_description_value.Text = common_network_invertoty.description;
        lbl_contact_value.Text = common_network_invertoty.contact;
        lbl_location_value.Text = common_network_invertoty.location;
        lbl_platform_value.Text = common_network_invertoty.platform_id;
        lbl_up_time_value.Text = common_network_invertoty.up_time;
        
       

    }

    public string[] Get_Data_Files()
    {
        DirectoryInfo di = new DirectoryInfo("C://Asset//NetworkData");
        FileInfo[] fi = di.GetFiles();
        int countfile = fi.GetLength(0);
        int i = 0;
        filenames = new string[countfile];
        foreach (FileInfo K in fi)
        {
            string[] fname = K.Name.Split(new char[] { 'x' });

            filenames[i] = fname[0].ToString();
            i++;

        }
        return filenames;

    }
}
