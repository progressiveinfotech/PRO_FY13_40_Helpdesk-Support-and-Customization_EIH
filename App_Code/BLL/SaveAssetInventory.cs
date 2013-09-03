using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;


public class SaveAssetInventory
{
    int Assetid, count1;
    string inventorydate2;
    Asset_Inventory_mst objinventorymst = new Asset_Inventory_mst();
    Asset_Software_mst objsoftwaremst = new Asset_Software_mst();

    public SaveAssetInventory()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Load_Data(string[] filename)
    {
        XmlDocument xmldoc = new XmlDocument();
        //if ((filename[1].ToUpper().Contains("COM1") == true) || (filename[1].ToUpper().Contains("COM2") == true) || (filename[1].ToUpper().Contains("COM3") == true) || (filename[1].ToUpper().Contains("COM4") == true) || (filename[1].ToUpper().Contains("LPT1") == true))
        // {
        //continue;
        //}
        if (filename[1].ToString().ToLower() == "xml")
        //if (filename[1].ToString() == "xml")
        {
            string path = "C:\\Asset\\Data\\" + filename[0] + ".xml";
            String filestr = File.ReadAllText(path);
            xmldoc.LoadXml(filestr);
            //xmldoc.Load(path);

            Asset_Info(xmldoc);
            Asset_Inventory_Info(xmldoc);
            Asset_Product_Info(xmldoc);
            Asset_Processor_Info(xmldoc);

            Asset_Memory_Info(xmldoc);
            Asset_Network_Info(xmldoc);
            Asset_OS_Info(xmldoc);

            Asset_Physical_Drive_Info(xmldoc);
            Asset_Logical_Drive_Info(xmldoc);
            //  Asset_Multimedia(xmldoc); lalit 3 march
            ///////////Add by Vishal 06-06-2012
            Asset_Software(xmldoc);
        }
    }

    public void SaveInventory()
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo("C://Asset//Data");
            FileInfo[] fi = di.GetFiles();
            int countfile = fi.GetLength(0);

            int i = 0;
            foreach (FileInfo K in fi)
            {
                string fname1;
                string[] fname = K.Name.Split(new char[] { '.' });
                fname1 = fname[0].ToString();
                /////Change fname[1] to fname[0] date 01-06-2012 vishal 
                // if ((fname[0].ToString().Contains("COM1") == true) || (fname[0].ToString().Contains("COM2") == true) || (fname[0].ToString().Contains("COM3") == true) || (fname[0].ToString().Contains("COM4") == true) || (fname[0].ToString().Contains("LPT1") == true))
                //// if ((fname[1].ToString().Contains("COM1") == true) || (fname[1].ToString().Contains("COM2") == true) || (fname[1].ToString().Contains("COM3") == true) || (fname[1].ToString().Contains("COM4") == true) || (fname[1].ToString().Contains("LPT1") == true))
                // {
                //     continue;
                // }
                // // Load_Data(fname1);
                // Load_Data(fname);
                /////Change fname[1] to fname[0] date 01-06-2012 vishal
                try
                {
                    if ((fname[0].ToString().Contains("DLIM79709") == true) || (fname[0].ToString().Contains("COM1") == true) || (fname[0].ToString().Contains("COM2") == true) || (fname[0].ToString().Contains("COM3") == true) || (fname[0].ToString().Contains("COM4") == true) || (fname[0].ToString().Contains("LPT1") == true))
                    //if ((fname[1].ToString().Contains("COM1") == true) || (fname[1].ToString().Contains("COM2") == true) || (fname[1].ToString().Contains("COM3") == true) || (fname[1].ToString().Contains("COM4") == true) || (fname[1].ToString().Contains("LPT1") == true))
                    {
                        continue;
                    }
                    else
                    {
                        // Load_Data(fname1);
                        Load_Data(fname);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        catch (Exception ex)
        {
            string fname1;
        }
    }
    public void Asset_Info(XmlDocument xmldoc)
    {
        try
        {
            Asset_mst objAsset = new Asset_mst();
            int count;
            string compname1, domain1;
            XmlNode compname = xmldoc.DocumentElement.SelectSingleNode("//Computer//Computer_name");
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            XmlNode domain = xmldoc.DocumentElement.SelectSingleNode("//Computer//Domain");

            compname1 = compname.InnerText;
            domain1 = domain.InnerText;
            count = objAsset.Get_ComputerName(compname1, domain1);
            count1 = count;
            if (count == 0)
            {
                objAsset.Computername = compname.InnerText;
                objAsset.Domain = domain.InnerText;
                objAsset.Createdatetime = inventory_date.InnerText;
                objAsset.Insert();
            }
            else
            {
                objAsset = objAsset.Get_AssetId_By_ComputerName_Domain(compname1, domain1);
                Assetid = Convert.ToInt32(objAsset.Assetid);
                inventorydate2 = inventory_date.InnerText;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    public void Asset_Product_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode product_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Name");
            XmlNode product_manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Manufacturer");
            XmlNode Serial_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//Serial_number");
            XmlNode UUID = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//UUID");
            XmlNode SKU_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Product_details//SKU_number");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_ProductInfo_mst objprodinfo = new Asset_ProductInfo_mst();
            if (count1 == 0)
            {
                objprodinfo.Assetid = varassetid;
            }
            else
            {
                objprodinfo.Assetid = Assetid;
            }
            objprodinfo.Inventory_date = inventorydate2;
            objprodinfo.Product_manufacturer = product_manufacturer.InnerText;
            objprodinfo.Product_name = product_name.InnerText;
            objprodinfo.Serial_number = Serial_number.InnerText;
            objprodinfo.Sku_no = SKU_number.InnerText;
            objprodinfo.Uuid = UUID.InnerText;
            objprodinfo.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public void Asset_Processor_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode Family = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Family");
            XmlNode Manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Manufacturer");
            XmlNode Max_speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Max_speed");
            XmlNode Model = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Model");
            XmlNode processors = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Processor");
            XmlNode Speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Speed");
            XmlNode Stepping = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Processors//Stepping");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_Processor_mst objprocessor = new Asset_Processor_mst();
            if (count1 == 0)
            {
                objprocessor.Assetid = varassetid;
            }
            else
            {
                objprocessor.Assetid = Assetid;
            }

            objprocessor.Family = Family.InnerText;
            objprocessor.Inventory_date = inventorydate2;
            objprocessor.Manufacturer = Manufacturer.InnerText;
            objprocessor.Max_speed = Max_speed.InnerText;
            objprocessor.Model = Model.InnerText;
            objprocessor.Processor_name = processors.InnerText;
            objprocessor.Speed = Speed.InnerText;
            objprocessor.Stepping = Stepping.InnerText;
            objprocessor.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    public void Asset_Memory_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode physical_mem = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Physical_memory");
            XmlNode virtual_mem = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Virtual_memory");
            XmlNode page_file = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Memory//Page_file_size");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();

            Asset_Memory_mst objmemory = new Asset_Memory_mst();
            if (count1 == 0)
            {
                objmemory.Assetid = varassetid;
            }
            else
            {
                objmemory.Assetid = Assetid;
            }

            objmemory.Inventory_date = inventorydate2;
            objmemory.Page_file = page_file.InnerText;
            if (physical_mem.InnerText != "")
            {
                if (Convert.ToDecimal(physical_mem.InnerText) >= 1073741824)
                {
                    decimal physicalmem = Convert.ToDecimal(physical_mem.InnerText) / 1073741824;
                    //objmemory.Physical_mem = physicalmem.ToString() + " GB";
                    objmemory.Physical_mem = String.Format("{0:0.00}", physicalmem) + " GB";

                }
                else
                {
                    decimal physicalmem = Convert.ToDecimal(physical_mem.InnerText) / 1048576;
                    //objmemory.Physical_mem = physicalmem.ToString() + " MB";
                    objmemory.Physical_mem = String.Format("{0:0.00}", physicalmem) + " MB";
                }
            }
            //   objmemory.Physical_mem = physical_mem.InnerText;
            if (virtual_mem.InnerText != "")
            {
                if (Convert.ToDecimal(virtual_mem.InnerText) >= 1073741824)
                {
                    decimal virtualmem = Convert.ToDecimal(virtual_mem.InnerText) / 1073741824;
                    objmemory.Virtual_mem = String.Format("{0:0.00}", virtualmem) + " GB";

                }
                else
                {
                    decimal virtualmem = Convert.ToDecimal(virtual_mem.InnerText) / 1048576;
                    objmemory.Virtual_mem = String.Format("{0:0.00}", virtualmem) + " MB";
                }
            }
            //  objmemory.Virtual_mem = virtual_mem.InnerText;
            objmemory.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    public void Asset_Network_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode adapter = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter");
            XmlNode protocol = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol");
            XmlNode protocol_IP_Addresses_Address = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//IP_Addresses//Address//Address");
            XmlNode protocol_Gateways = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Adapter//Network_protocols//Protocol//Gateways");
            XmlNode Link_speed = xmldoc.DocumentElement.SelectSingleNode("//Computer//Network_adapters//Link_speed");

            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_Network_mst objnetwork = new Asset_Network_mst();
            objnetwork.Adapter_name = adapter.InnerText;
            if (count1 == 0)
            {
                objnetwork.Assetid = varassetid;
            }
            else
            {
                objnetwork.Assetid = Assetid;
            }

            objnetwork.Gateway = protocol_Gateways.InnerText;
            objnetwork.Inventory_date = inventorydate2;
            //change done by meenakshi
            if (protocol_IP_Addresses_Address != null)
            {
                objnetwork.Ip_address = protocol_IP_Addresses_Address.InnerText;
            }
            if (Link_speed != null)
            {
                objnetwork.Link_speed = Link_speed.InnerText;
            }
            if (protocol != null)
            {
                objnetwork.Protocol_name = protocol.InnerText;
            }
            objnetwork.Insert();

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public void Asset_OS_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;

            XmlNode os_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Name");
            XmlNode major_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Major_version");
            XmlNode minor_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Minor_version");
            XmlNode build_no = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Build_number");
            XmlNode add_info = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Additional_information");
            XmlNode user_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//User_name");
            XmlNode reg_to = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registered_to");
            XmlNode reg_org = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registered_organization");
            XmlNode reg_code = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Registration_code");
            XmlNode localization = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Locale");
            XmlNode product_key = xmldoc.DocumentElement.SelectSingleNode("//Computer//General_info//Operating_system//Product_key");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_OperatingSystem_mst objos = new Asset_OperatingSystem_mst();
            objos.Add_info = add_info.InnerText;
            if (count1 == 0)
            {
                objos.Assetid = varassetid;
            }
            else
            {
                objos.Assetid = Assetid;
            }

            objos.Build_no = build_no.InnerText;
            objos.Inventory_date = inventorydate2;
            objos.Localization = localization.InnerText;
            objos.Major_version = major_version.InnerText;
            objos.Minor_version = minor_version.InnerText;
            objos.Os_name = os_name.InnerText;
            objos.Product_key = product_key.InnerText;
            objos.Reg_code = reg_code.InnerText;
            objos.Reg_org = reg_org.InnerText;
            objos.Reg_to = reg_to.InnerText;
            objos.User_name = user_name.InnerText;
            objos.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public void Asset_Physical_Drive_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode physical_drives = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Drive");
            XmlNode Capacity = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Capacity");
            XmlNode Manufacturer = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Manufacturer");
            XmlNode physical_drives1 = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Product_version");
            XmlNode Product_version = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Drive");
            XmlNode Serial_number = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Physical_drives//Serial_number");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_PhysicalDrive_mst objphysical = new Asset_PhysicalDrive_mst();
            if (count1 == 0)
            {
                objphysical.Assetid = varassetid;
            }
            else
            {
                objphysical.Assetid = Assetid;
            }

            objphysical.Capacity = Capacity.InnerText;
            objphysical.Drive_name = physical_drives.InnerText;
            objphysical.Inventory_date = inventorydate2;
            objphysical.Manufacturer = Manufacturer.InnerText;
            objphysical.Product_version = Product_version.InnerText;
            objphysical.Serial_number = Serial_number.InnerText;
            objphysical.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    public void Asset_Logical_Drive_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode Drive_letter = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Drive_letter");
            XmlNode Drive_type = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Drive_type");
            XmlNode File_system_name = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//File_system_name");
            XmlNode Free_bytes = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Free_bytes");
            XmlNode Total_bytes = xmldoc.DocumentElement.SelectSingleNode("//Computer//Hardware//Logical_drives//Total_bytes");
            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_LogicalDrive_mst objlogical = new Asset_LogicalDrive_mst();
            if (count1 == 0)
            {
                objlogical.Assetid = varassetid;
            }
            else
            {
                objlogical.Assetid = Assetid;
            }

            objlogical.Drive_letter = Drive_letter.InnerText;
            objlogical.Drive_type = Drive_type.InnerText;
            objlogical.File_system_name = File_system_name.InnerText;
            objlogical.Free_bytes = Free_bytes.InnerText;
            objlogical.Inventory_date = inventorydate2;
            objlogical.Total_bytes = Total_bytes.InnerText;
            objlogical.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public void Asset_Inventory_Info(XmlDocument xmldoc)
    {
        try
        {
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            int countinventorydetails;
            XmlNode compname = xmldoc.DocumentElement.SelectSingleNode("//Computer//Computer_name");
            XmlNode domain = xmldoc.DocumentElement.SelectSingleNode("//Computer//Domain");

            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();
            Asset_Inventory_mst objinventory = new Asset_Inventory_mst();
            if (count1 == 0)
            {
                objinventory.Assetid = varassetid;
            }
            else
            {
                objinventory.Assetid = Assetid;
                countinventorydetails = objinventory.Get_Inventory_By_Assetid_InventoryDate(Assetid, inventorydate2);
                if (countinventorydetails != 0)
                {
                    objinventory.delete_Existingdetails_From_Asset(Assetid, inventorydate2);
                }
            }

            objinventory.Computername = compname.InnerText;
            objinventory.Inventorydate = inventory_date.InnerText;
            objinventory.Insert();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }


    public void Asset_Software(XmlDocument xmldoc)
    {
        try
        {
            int count;
            string compname1, domain1;
            XmlNode compname = xmldoc.DocumentElement.SelectSingleNode("//Computer//Computer_name");
            XmlNode inventory_date = xmldoc.DocumentElement.SelectSingleNode("//Computer//Created_on");
            inventorydate2 = inventory_date.InnerText;
            XmlNode domain = xmldoc.DocumentElement.SelectSingleNode("//Computer//Domain");

            compname1 = compname.InnerText;
            domain1 = domain.InnerText;

            Asset_mst objAsset = new Asset_mst();
            int varassetid = objAsset.Get_Current_Assetid();

            if (count1 == 0)
            {
                objsoftwaremst.Assetid = varassetid;
            }
            else
            {
                objsoftwaremst.Assetid = Assetid;
            }
            softwares = Softwares_info(xmldoc);

            for (int k = 0; k < flagsoftcount; k++)
            {

                software_name = softwares[k, 0];
                software_manufacturer = softwares[k, 1];
                install_directory = softwares[k, 2];
                software_version = softwares[k, 3];
                software_version_major = softwares[k, 4];
                software_version_minor = softwares[k, 5];
                installed_on = softwares[k, 6];
                software_registered_to = softwares[k, 7];
                software_registration_code = softwares[k, 8];
                software_registered_organization = softwares[k, 9];
                software_product_key = softwares[k, 10];
                bool check_date = CheckDate(installed_on);
                if (!check_date)
                {
                    installed_on = null;

                }
                objsoftwaremst.Inventorydate = inventorydate2;
                objsoftwaremst.Computername = compname1;
                objsoftwaremst.Domainname = domain1;
                objsoftwaremst.Software_name = software_name.Replace("?"," ").Trim();
                objsoftwaremst.Software_manufacturer = software_manufacturer;
                objsoftwaremst.Install_directory = install_directory;
                objsoftwaremst.Software_version = software_version;
                objsoftwaremst.Software_version_major = software_version_major;
                objsoftwaremst.Software_version_minor = software_version_minor;
                objsoftwaremst.Software_registered_to = software_registered_to;
                objsoftwaremst.Software_registration_code = software_registration_code;
                objsoftwaremst.Software_registered_organization = software_registered_organization;
                objsoftwaremst.Software_product_key = software_product_key;
                objsoftwaremst.Installed_on = installed_on;
                objsoftwaremst.Insert();
            }


            // objnetwork.Insert();

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public string[,] Softwares_info(XmlDocument xmldoc)
    {
        XmlNodeList nodes_software = xmldoc.DocumentElement.SelectNodes("//Computer//Software//Program");
        count_softwares = nodes_software.Count;
        string[,] strArray = new string[count_softwares, 20];
        XmlNode xn; flagsoftcount = 0;
        for (int i = 0; i < count_softwares; i++)
        {
            xn = nodes_software.Item(i);
            strArray[i, 0] = xn["Name"].InnerText;
            strArray[i, 1] = xn["Manufacturer"].InnerText;
            strArray[i, 2] = xn["Install_directory"].InnerText;
            strArray[i, 3] = xn["Version"].InnerText;
            strArray[i, 4] = xn["Version_major"].InnerText;
            strArray[i, 5] = xn["Version_minor"].InnerText;
            strArray[i, 6] = xn["Installed_on"].InnerText;
            strArray[i, 7] = xn["Registered_to"].InnerText;
            strArray[i, 8] = xn["Registration_code"].InnerText;
            strArray[i, 9] = xn["Registered_organization"].InnerText;
            strArray[i, 10] = xn["Product_key"].InnerText;
            flagsoftcount = flagsoftcount + 1;
        }
        return strArray;

    }

    public bool CheckDate(String date)
    {

        try
        {

            DateTime dt = DateTime.Parse(date);

            return true;

        }
        catch
        {

            return false;

        }

    }
    /*     Software Information      */

    public int flagsoftcount;
    public string[,] softwares;
    public int count_softwares;
    public string software_name;
    public string software_manufacturer;
    public string install_directory;
    public string installed_on;
    public string software_version;
    public string software_version_major;
    public string software_version_minor;
    public string software_registered_to;
    public string software_registration_code;
    public string software_registered_organization;
    public string software_product_key;

}
