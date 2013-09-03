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
using System.Xml;
using System.Data.SqlClient;
using System.IO;

public partial class Asset_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lbluser = new Label();
        //lbluser = (Label)Master.FindControl("lblUserIdentity");
        //lbluser.Text = "Sign in as : " + User.Identity.Name.ToString();

        //Master.FindControl("General").Visible = false;
        //Master.FindControl("os").Visible = false;
        //Master.FindControl("Hardware").Visible = false;
        //Master.FindControl("Multimedia").Visible = false;
        //Master.FindControl("Network").Visible = false;
        //Master.FindControl("software").Visible = false;

        //if (!(this.User.IsInRole("admins")))
        //{
            
        //    Master.FindControl("imgBtnAdmin").Visible = false;
        //    Master.FindControl("Imgsaveinventory").Visible = false;
        //    Master.FindControl("lnkSaveinventory").Visible = false;
        //    Master.FindControl("imgAdminM").Visible = false;
        //    Master.FindControl("lnkAdminM").Visible = false;
        //}
        //DataUtility dut = new DataUtility();

        
        XmlDocument xmldoc = new XmlDocument();
        int WorkStationCount;
        int NetworksCount;
        int totalCount;
        int diffCountAsset;
        string query;
        DataSet ds = new DataSet();
        int countOsXp;
        countOsXp = 0;
        int countOsServer2003;
        countOsServer2003 = 0;
        int countOsServer2000;
        countOsServer2000 = 0;
        int countOsVista;
        countOsVista = 0;
        int countOthers;
        countOthers = 0;
        int totalCountOS;
        totalCountOS = 0;
        int countwindow7 = 0;
        string path = Server.MapPath("..//Files//Asset.xml");
        int i = 0;

        xmldoc.Load(path);
        WorkStationCount = xmldoc.DocumentElement.ChildNodes.Count;
        lblWorkStations.Text = WorkStationCount.ToString();        
        path = "";
        NetworksCount = 0;
        lblNetworkdevices.Text = NetworksCount.ToString();
        totalCount = WorkStationCount+NetworksCount;
        lblTotal.Text = totalCount.ToString();
        DirectoryInfo di = new DirectoryInfo("C://Asset//Data");
        FileInfo[] fi = di.GetFiles();

        foreach (FileInfo K in fi)
        {
            string filename;
            string os_name;
            string[] fname = K.Name.Split(new char[] { '.' });
            filename = fname[0].ToString();
            XmlDocument xmldoc1 = new XmlDocument();



            string path1 = "C:\\Asset\\Data\\" + filename + ".xml";
            xmldoc1.Load(path1);
            XmlNode node_os_name = xmldoc1.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Name");
            os_name = node_os_name.InnerText;
            if (os_name == "Microsoft Windows XP  Professional")
            {
                countOsXp = countOsXp + 1;

            }
            else if (os_name == "Microsoft Windows Server 2003 Enterprise Edition")
            {
                countOsServer2003 = countOsServer2003 + 1;
            }
            else if (os_name == "Microsoft Windows 2000  Enterprise Server")
            {
                countOsServer2000 = countOsServer2000 + 1;
            }
            else if (os_name == "Microsoft Windows Vista Business Edition 32-bit")
            {
                countOsVista = countOsVista + 1;
            }
            else if (os_name == "Microsoft Windows")
            {
                countwindow7 = countwindow7 + 1;
            }
            else
            {
                countOthers = countOthers + 1;
            }





        }





        lblWindowsXp.Text = countOsXp.ToString();
        lblWindows2003.Text = countOsServer2003.ToString();
        lblWindows2000.Text = countOsServer2000.ToString();
        lblWindowsVista.Text = countOsVista.ToString();
        Labelwindow7.Text = countwindow7.ToString();
        lblOsOthers.Text = countOthers.ToString();


        totalCountOS = countOthers + countOsVista + countOsServer2000 + countOsServer2003 + countOsXp;
        lblTotalOS.Text = totalCountOS.ToString();





        string url;
        string url1;
        string chd1;
        int workstation1, networksDevice1;
        workstation1 = 0;
        networksDevice1 = 0;







        if (WorkStationCount >= NetworksCount)
        {
            diffCountAsset = WorkStationCount - NetworksCount;
            if (diffCountAsset > 90)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 30;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset > 80 && diffCountAsset <= 90)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 35;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset > 70 && diffCountAsset <= 80)
            {

                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 40;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }


            }
            else if (diffCountAsset > 60 && diffCountAsset <= 70)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 45;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }


            }
            else if (diffCountAsset > 50 && diffCountAsset <= 60)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 50;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }


            }
            else if (diffCountAsset > 40 && diffCountAsset <= 50)
            {

                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 60;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset > 30 && diffCountAsset <= 40)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 70;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset > 20 && diffCountAsset <= 30)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 80;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset > 10 && diffCountAsset <= 20)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 90;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }


            }
            else if (diffCountAsset > 5 && diffCountAsset <= 10)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 95;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }


            }
            else if (diffCountAsset > 2 && diffCountAsset <= 5)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 99;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset >= 1 && diffCountAsset <= 2)
            {
                if (NetworksCount != 0)
                {
                    workstation1 = 100;
                    networksDevice1 = 100;
                }
                else
                {
                    workstation1 = 100;
                    networksDevice1 = 0;
                }

            }
            else if (diffCountAsset == 0)
            {
                workstation1 = WorkStationCount;
                networksDevice1 = NetworksCount;
            }





        }
        else
        {

            diffCountAsset = NetworksCount - WorkStationCount;

            if (diffCountAsset > 90)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 30;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }


            }
            else if (diffCountAsset > 80 && diffCountAsset <= 90)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 35;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 70 && diffCountAsset <= 80)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 40;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 60 && diffCountAsset <= 70)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 45;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 50 && diffCountAsset <= 60)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 50;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }


            }
            else if (diffCountAsset > 40 && diffCountAsset <= 50)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 60;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 30 && diffCountAsset <= 40)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 70;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }


            }
            else if (diffCountAsset > 20 && diffCountAsset <= 30)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 80;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 10 && diffCountAsset <= 20)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 90;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 5 && diffCountAsset <= 10)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 95;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset > 2 && diffCountAsset <= 5)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 99;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset >= 1 && diffCountAsset <= 2)
            {
                if (WorkStationCount != 0)
                {
                    networksDevice1 = 100;
                    workstation1 = 100;
                }
                else
                {
                    networksDevice1 = 100;
                    workstation1 = 0;
                }

            }
            else if (diffCountAsset == 0)
            {
                workstation1 = WorkStationCount;
                networksDevice1 = NetworksCount;
            }




        }


















        string cht1, chs1, chds1, chco1, chxt1, chg1, chbh1, chxl1;

        cht1 = "bvs";
        chs1 = "380x150";
        chds1 = "0,10";
        chco1 = "3399cc,339966";
        chxt1 = "x";
        chg1 = "0,8.3,5,5";
        chd1 = "t:" + workstation1 + ",0|0," + networksDevice1;
        chbh1 = "35,105,200";

        chxl1 = "0:|Workstations(" + WorkStationCount + ")|" + "Network Devices(" + NetworksCount + ")";
        url = "http://chart.apis.google.com/chart?" + "cht=" + cht1 + "&chs=" + chs1 + "&chco=" + chco1 + "&chbh=" + chbh1 + "&chxt=" + chxt1 + "&chd=" + chd1 + "&chxl=" + chxl1;

        //  url = "http://chart.apis.google.com/chart?cht=bvs&chs=380x150&chco=3399cc&chbh=35,55,115&chxt=x,y&chd=t:100,50&chxl=0:|Workstations|Network Devices";
        int osxp, os2003, os2000, osvista;
        osxp = 0;
        os2003 = 0;
        os2000 = 0;
        osvista = 0;
        if (countOsXp > 500)
        {
            osxp = 100;

        }
        else if (countOsXp > 450 && countOsXp <= 500)
        {
            osxp = 95;

        }
        else if (countOsXp > 400 && countOsXp <= 450)
        {
            osxp = 90;

        }
        else if (countOsXp > 350 && countOsXp <= 400)
        {
            osxp = 85;

        }
        else if (countOsXp > 300 && countOsXp <= 350)
        {
            osxp = 80;

        }
        else if (countOsXp > 250 && countOsXp <= 300)
        {
            osxp = 75;

        }
        else if (countOsXp > 200 && countOsXp <= 250)
        {
            osxp = 70;

        }
        else if (countOsXp > 150 && countOsXp <= 200)
        {
            osxp = 70;

        }
        else if (countOsXp > 100 && countOsXp <= 150)
        {
            osxp = 65;

        }
        else if (countOsXp > 80 && countOsXp <= 100)
        {
            osxp = 60;

        }
        else if (countOsXp > 70 && countOsXp <= 80)
        {
            osxp = 55;

        }
        else if (countOsXp > 65 && countOsXp <= 70)
        {
            osxp = 50;

        }
        else if (countOsXp > 50 && countOsXp <= 65)
        {
            osxp = 45;

        }
        else if (countOsXp > 40 && countOsXp <= 50)
        {
            osxp = 40;

        }
        else if (countOsXp > 35 && countOsXp <= 40)
        {
            osxp = 35;

        }
        else if (countOsXp > 25 && countOsXp <= 35)
        {
            osxp = 30;

        }
        else if (countOsXp > 15 && countOsXp <= 25)
        {
            osxp = 25;

        }
        else if (countOsXp > 10 && countOsXp <= 15)
        {
            osxp = 20;

        }
        else if (countOsXp > 5 && countOsXp <= 10)
        {
            osxp = 15;

        }
        else if (countOsXp > 0 && countOsXp <= 5)
        {
            osxp = 10;

        }


        //Server 2003


        if (countOsServer2003 > 500)
        {
            os2003 = 100;

        }
        else if (countOsServer2003 > 450 && countOsServer2003 <= 500)
        {
            os2003 = 95;

        }
        else if (countOsServer2003 > 400 && countOsServer2003 <= 450)
        {
            os2003 = 90;

        }
        else if (countOsServer2003 > 350 && countOsServer2003 <= 400)
        {
            os2003 = 85;

        }
        else if (countOsServer2003 > 300 && countOsServer2003 <= 350)
        {
            os2003 = 80;

        }
        else if (countOsServer2003 > 250 && countOsServer2003 <= 300)
        {
            os2003 = 75;

        }
        else if (countOsServer2003 > 200 && countOsServer2003 <= 250)
        {
            os2003 = 70;

        }
        else if (countOsServer2003 > 150 && countOsServer2003 <= 200)
        {
            os2003 = 70;

        }
        else if (countOsServer2003 > 100 && countOsServer2003 <= 150)
        {
            os2003 = 65;

        }
        else if (countOsServer2003 > 80 && countOsServer2003 <= 100)
        {
            os2003 = 60;

        }
        else if (countOsServer2003 > 70 && countOsServer2003 <= 80)
        {
            os2003 = 55;

        }
        else if (countOsServer2003 > 65 && countOsServer2003 <= 70)
        {
            os2003 = 50;

        }
        else if (countOsServer2003 > 50 && countOsServer2003 <= 65)
        {
            os2003 = 45;

        }
        else if (countOsServer2003 > 40 && countOsServer2003 <= 50)
        {
            os2003 = 40;

        }
        else if (countOsServer2003 > 35 && countOsServer2003 <= 40)
        {
            os2003 = 35;

        }
        else if (countOsServer2003 > 25 && countOsServer2003 <= 35)
        {
            os2003 = 30;

        }
        else if (countOsServer2003 > 15 && countOsServer2003 <= 25)
        {
            os2003 = 25;

        }
        else if (countOsServer2003 > 10 && countOsServer2003 <= 15)
        {
            os2003 = 20;

        }
        else if (countOsServer2003 > 5 && countOsServer2003 <= 10)
        {
            os2003 = 15;

        }
        else if (countOsServer2003 > 0 && countOsServer2003 <= 5)
        {
            os2003 = 10;

        }




        //Server 2000




        if (countOsServer2000 > 500)
        {
            os2000 = 100;

        }
        else if (countOsServer2000 > 450 && countOsServer2000 <= 500)
        {
            os2000 = 95;

        }
        else if (countOsServer2000 > 400 && countOsServer2000 <= 450)
        {
            os2000 = 90;

        }
        else if (countOsServer2000 > 350 && countOsServer2000 <= 400)
        {
            os2000 = 85;

        }
        else if (countOsServer2000 > 300 && countOsServer2000 <= 350)
        {
            os2000 = 80;

        }
        else if (countOsServer2000 > 250 && countOsServer2000 <= 300)
        {
            os2000 = 75;

        }
        else if (countOsServer2000 > 200 && countOsServer2000 <= 250)
        {
            os2000 = 70;

        }
        else if (countOsServer2000 > 150 && countOsServer2000 <= 200)
        {
            os2000 = 70;

        }
        else if (countOsServer2000 > 100 && countOsServer2000 <= 150)
        {
            os2000 = 65;

        }
        else if (countOsServer2000 > 80 && countOsServer2000 <= 100)
        {
            os2000 = 60;

        }
        else if (countOsServer2000 > 70 && countOsServer2000 <= 80)
        {
            os2000 = 55;

        }
        else if (countOsServer2000 > 65 && countOsServer2000 <= 70)
        {
            os2000 = 50;

        }
        else if (countOsServer2000 > 50 && countOsServer2000 <= 65)
        {
            os2000 = 45;

        }
        else if (countOsServer2000 > 40 && countOsServer2000 <= 50)
        {
            os2000 = 40;

        }
        else if (countOsServer2000 > 35 && countOsServer2000 <= 40)
        {
            os2000 = 35;

        }
        else if (countOsServer2000 > 25 && countOsServer2000 <= 35)
        {
            os2003 = 30;

        }
        else if (countOsServer2000 > 15 && countOsServer2000 <= 25)
        {
            os2000 = 25;

        }
        else if (countOsServer2000 > 10 && countOsServer2000 <= 15)
        {
            os2000 = 20;

        }
        else if (countOsServer2000 > 5 && countOsServer2000 <= 10)
        {
            os2000 = 15;

        }
        else if (countOsServer2000 > 0 && countOsServer2000 <= 5)
        {
            os2000 = 10;

        }

        // Windows Vista


        if (countOsVista > 500)
        {
            osvista = 100;

        }
        else if (countOsVista > 450 && countOsVista <= 500)
        {
            osvista = 95;

        }
        else if (countOsVista > 400 && countOsVista <= 450)
        {
            osvista = 90;

        }
        else if (countOsVista > 350 && countOsVista <= 400)
        {
            osvista = 85;

        }
        else if (countOsVista > 300 && countOsVista <= 350)
        {
            osvista = 80;

        }
        else if (countOsVista > 250 && countOsVista <= 300)
        {
            osvista = 75;

        }
        else if (countOsVista > 200 && countOsVista <= 250)
        {
            osvista = 70;

        }
        else if (countOsVista > 150 && countOsVista <= 200)
        {
            osvista = 70;

        }
        else if (countOsVista > 100 && countOsVista <= 150)
        {
            osvista = 65;

        }
        else if (countOsVista > 80 && countOsVista <= 100)
        {
            osvista = 60;

        }
        else if (countOsVista > 70 && countOsVista <= 80)
        {
            osvista = 55;

        }
        else if (countOsVista > 65 && countOsVista <= 70)
        {
            osvista = 50;

        }
        else if (countOsVista > 50 && countOsVista <= 65)
        {
            osvista = 45;

        }
        else if (countOsVista > 40 && countOsVista <= 50)
        {
            osvista = 40;

        }
        else if (countOsVista > 35 && countOsVista <= 40)
        {
            osvista = 35;

        }
        else if (countOsVista > 25 && countOsVista <= 35)
        {
            osvista = 30;

        }
        else if (countOsVista > 15 && countOsVista <= 25)
        {
            osvista = 25;

        }
        else if (countOsVista > 10 && countOsVista <= 15)
        {
            osvista = 20;

        }
        else if (countOsVista > 5 && countOsVista <= 10)
        {
            osvista = 15;

        }
        else if (countOsVista > 0 && countOsVista <= 5)
        {
            osvista = 10;

        }







        cht1 = "bvs";
        chs1 = "380x150";
        chds1 = "0,10";
        chco1 = "3399cc,339966,ff9900,33CCFF";
        chxt1 = "x";
        chg1 = "0,8.3,5,5";
        chd1 = "t:" + osxp + ",0,0,0|0," + os2003 + ",0,0|" + "0,0," + osvista + ",0|" + "0,0,0," + os2000;
        chbh1 = "35,60,50";

        chxl1 = "0:|Windoxs XP(" + countOsXp + ")|" + "Server 2003(" + countOsServer2003 + ")|" + "Windows Vista(" + countOsVista + ")|" + "Server 2000(" + countOsServer2000 + ")";


        url1 = "http://chart.apis.google.com/chart?" + "cht=" + cht1 + "&chs=" + chs1 + "&chco=" + chco1 + "&chbh=" + chbh1 + "&chxt=" + chxt1 + "&chd=" + chd1 + "&chxl=" + chxl1;





        //url1 = "http://chart.apis.google.com/chart?cht=bvs&chs=380x150&chco=339966&chbh=35,55,115&chxt=x,y&chd=t:80,30";
        imgAsset.ImageUrl = url;
        imageOS.ImageUrl = url1;

    }
}