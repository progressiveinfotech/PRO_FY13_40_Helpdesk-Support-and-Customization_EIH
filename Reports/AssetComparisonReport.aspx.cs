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
using System.Text;

public partial class Reports_AssetComparisonReport : System.Web.UI.Page
{
    public string hardware;
    CommonFunction commonf = new CommonFunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hardware = "Select All";
            CompareAsset();
        }

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {

        hardware = drphrdwList.SelectedItem.ToString();

        CompareAsset();




    }



    public void CompareAsset()
    {
        lblmsg.Text = " Asset has changed for the following computers.";
        lblmsg1.Text = " Asset has not changed for any computers.";
        lblmsg1.Visible = true;
        string report_query = "";
        if (hardware == "Select All")
        {
            report_query = "select * from fn_AssetCompare_hardware('Memory')";
        }
        else if (hardware == "Memory")
        {
            report_query = " select * from fn_AssetCompare_hardware('Memory')";
        }
        else if (hardware == "Processor")
        {
            report_query = " select * from fn_AssetCompare_hardware('Processor')";
        }
        else if (hardware == "Adapter")
        {
            report_query = "select * from fn_AssetCompare_hardware('Adapter')";
        }
        else if (hardware == "Disk")
        {
            report_query = " select * from fn_AssetCompare_hardware('Disk')";
        }
        DataSet ds = commonf.GetDataSet(report_query);

        int x = 2;
        int flag;
        AssetCompare_placeholder_new.Controls.Clear();
        AssetCompare_placeholder_old.Controls.Clear();
        DataTable dt = ds.Tables[0];
        Table tbl_old = new Table();
        Table tbl_new = new Table();
        AssetCompare_placeholder_old.Controls.Add(tbl_old);
        AssetCompare_placeholder_new.Controls.Add(tbl_new);
        int hdwidth = 150;
        int infowidth = 550;

        foreach (DataRow row in dt.Rows)
        {
            DateTime invdate;
            int rowcntold = 0;
            int rowcntnew = 0;
            int rowdiff = 0;


            flag = x % 2;
            if (flag == 0)
            {
                int count_col = 0;

                // Temporary Table Rows   
                TableRow tr_temp_old = new TableRow();
                TableRow tr_temp_old1 = new TableRow();
                TableRow tr_temp_old2 = new TableRow();
                TableRow tr_temp_old3 = new TableRow();


                //Computer Name information 
                TableRow tr_name_old = new TableRow();
                TableCell tc_hdr_old_cname = new TableCell();
                tc_hdr_old_cname.Width = hdwidth;
                Label lbl_hdr_old_cname = new Label();
                lbl_hdr_old_cname.Font.Bold = true;
                lbl_hdr_old_cname.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Computer Name&nbsp;&nbsp;:";
                tc_hdr_old_cname.Controls.Add(lbl_hdr_old_cname);
                TableCell tc_hd_old_cname = new TableCell();
                tc_hd_old_cname.Width = infowidth;
                Label lbl_hd_old_cname = new Label();
                lbl_hd_old_cname.Font.Bold = true;
                //lbl_hd_old_cname.Font.Underline = true;

                //Inventory Date Information 
                TableRow tr_date_old = new TableRow();
                TableCell tc_hd_old_date = new TableCell();
                tc_hd_old_date.Width = hdwidth;
                Label lbl_hd_old_date = new Label();
                lbl_hd_old_date.Font.Bold = true;
                lbl_hd_old_date.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Inventory Date&nbsp;&nbsp; :";
                tc_hd_old_date.Controls.Add(lbl_hd_old_date);
                TableCell tc_old_dateinfo = new TableCell();
                tc_old_dateinfo.Width = infowidth;
                Label lbl_old_dateinfo = new Label();


                //Processor Name Information 

                TableRow tr_processor_old = new TableRow();
                TableCell tc_hd_old_processor = new TableCell();
                tc_hd_old_processor.Width = hdwidth;
                Label lbl_hd_old_processor = new Label();
                lbl_hd_old_processor.Font.Bold = true;
                lbl_hd_old_processor.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_old_processor.Controls.Add(lbl_hd_old_processor);
                TableCell tc_old_processorinfo = new TableCell();
                tc_old_processorinfo.Width = infowidth;
                Label lbl_old_processorinfo = new Label();


                //Physical Memory Information
                TableRow tr_memory_old = new TableRow();
                TableCell tc_hd_old_memory = new TableCell();
                tc_hd_old_memory.Width = hdwidth;
                Label lbl_hd_old_memory = new Label();
                lbl_hd_old_memory.Font.Bold = true;
                lbl_hd_old_memory.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Memory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_old_memory.Controls.Add(lbl_hd_old_memory);
                TableCell tc_old_memoryinfo = new TableCell();
                tc_old_memoryinfo.Width = infowidth;
                Label lbl_old_memoryinfo = new Label();



                //Adapter Information 
                TableRow tr_adapter_old = new TableRow();
                TableCell tc_hd_old_adapter = new TableCell();
                tc_hd_old_adapter.Width = hdwidth;
                Label lbl_hd_old_adapter = new Label();
                lbl_hd_old_adapter.Font.Bold = true;
                lbl_hd_old_adapter.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adapter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_old_adapter.Controls.Add(lbl_hd_old_adapter);
                TableCell tc_old_adapterinfo = new TableCell();
                tc_old_adapterinfo.Width = infowidth;
                Label lbl_old_adapterinfo = new Label();

                TableRow tr_adapter_ext_old = new TableRow();
                TableCell tc_old_adapter_ext = new TableCell();
                tc_old_adapter_ext.Width = hdwidth;
                TableCell tc_old_adapter_ext_info = new TableCell();
                tc_old_adapter_ext_info.Width = infowidth;
                tc_old_adapter_ext_info.Height = 10;
                Label lbl_old_adapter_ext = new Label();

                // Disk Information 

                TableRow tr_disk_old = new TableRow();
                TableCell tc_hd_old_disk = new TableCell();
                tc_hd_old_disk.Width = hdwidth;
                Label lbl_hd_old_disk = new Label();
                lbl_hd_old_disk.Font.Bold = true;
                lbl_hd_old_disk.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disk&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_old_disk.Controls.Add(lbl_hd_old_disk);
                TableCell tc_old_diskinfo = new TableCell();
                tc_old_diskinfo.Width = infowidth;
                Label lbl_old_diskinfo = new Label();

                TableRow tr_disk_ext_old = new TableRow();
                TableCell tc_old_disk_ext = new TableCell();
                tc_old_adapter_ext.Width = hdwidth;
                TableCell tc_old_disk_ext_info = new TableCell();
                tc_old_disk_ext_info.Width = infowidth;
                Label lbl_old_disk_ext = new Label();





                foreach (DataColumn col in dt.Columns)
                {
                    if (count_col == 0)
                    {
                        invdate = (DateTime)row[col];
                        lbl_old_dateinfo.Text = invdate.ToString();
                        tc_old_dateinfo.Controls.Add(lbl_old_dateinfo);
                    }
                    if (count_col == 1)
                    {
                        lbl_hd_old_cname.Text = (String)row[col];
                        tc_hd_old_cname.Controls.Add(lbl_hd_old_cname);


                    }
                    if (count_col == 2)
                    {
                        if (row[col] != System.DBNull.Value)
                        {
                            lbl_old_processorinfo.Text = (String)row[col];
                            tc_old_processorinfo.Controls.Add(lbl_old_processorinfo);
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;
                        }
                        else
                        {
                            lbl_old_processorinfo.Text = "-";
                            tc_old_processorinfo.Controls.Add(lbl_old_processorinfo);

                        }


                    }

                    if (count_col == 3)
                    {
                        if (row[col] != System.DBNull.Value)
                        {
                            lbl_old_memoryinfo.Text = (String)row[col];
                            tc_old_memoryinfo.Controls.Add(lbl_old_memoryinfo);
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;
                        }
                        else
                        {
                            lbl_old_memoryinfo.Text = "-";
                            tc_old_memoryinfo.Controls.Add(lbl_old_memoryinfo);

                        }


                    }

                    if (count_col == 4)
                    {
                        string varadapter;
                        int adapcount;
                        if (row[col] != System.DBNull.Value)
                        {
                            varadapter = (String)row[col];
                            string[] varadapterArr = varadapter.ToString().Split(("|").ToCharArray());
                            adapcount = varadapterArr.Length;
                            for (int i = 0; i < adapcount; i++)
                            {
                                rowcntold = rowcntold + 1;
                                if (i == 0)
                                {
                                    //lblmsg.Visible = true;
                                    //lblmsg1.Visible = false;
                                    //string tempAdapter;
                                    //tempAdapter = varadapterArr[0];
                                    //int cntadap;
                                    //cntadap = tempAdapter.Length;
                                    //string flagstr = "";
                                    //if (cntadap <= 45)
                                    //{
                                    //    for (int k = 0; k <= 10; k++)
                                    //    {
                                    //        flagstr = flagstr + "&nbsp;";
                                    //    }
                                    //    //flagstr = flagstr + "|";
                                    //}

                                    lbl_old_adapterinfo.Text = varadapterArr[0];
                                    tc_old_adapterinfo.Controls.Add(lbl_old_adapterinfo);
                                }
                                if (i != adapcount - 1 && i > 0)
                                {
                                    lbl_old_adapter_ext.Text = lbl_old_adapter_ext.Text + varadapterArr[i] + "&nbsp;";

                                }


                            }
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;

                            tc_old_adapter_ext_info.Controls.Add(lbl_old_adapter_ext);

                        }
                        else
                        {

                            //tr_Lan.Visible = false;
                            //tr_Lan_ext.Visible = false;
                            lbl_old_adapterinfo.Text = "-";
                            tc_old_adapterinfo.Controls.Add(lbl_old_adapterinfo);
                            lbl_old_adapter_ext.Text = "-";

                        }


                    }



                    if (count_col == 5)
                    {
                        string varphydisk;
                        int dskcount;
                        if (row[col] != System.DBNull.Value)
                        {

                            varphydisk = (String)row[col];
                            string[] varphydiskArr = varphydisk.ToString().Split(("|").ToCharArray());
                            dskcount = varphydiskArr.Length;
                            dskcount = dskcount / 2;
                            for (int i = 0; i < dskcount; i++)
                            {

                                if (i == 0)
                                {
                                    lbl_old_diskinfo.Text = varphydiskArr[0] + varphydiskArr[1];
                                    tc_old_diskinfo.Controls.Add(lbl_old_diskinfo);
                                }

                                if (i != dskcount && i > 0)
                                {

                                    lbl_old_disk_ext.Text = lbl_old_disk_ext.Text + varphydiskArr[i + 1] + varphydiskArr[i + 2] + "&nbsp;";


                                }

                            }
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;

                        }
                        else
                        {
                            lbl_old_diskinfo.Text = "-";
                            tc_old_diskinfo.Controls.Add(lbl_old_diskinfo);

                        }
                        tc_old_disk_ext_info.Controls.Add(lbl_old_disk_ext);


                    }



                    count_col = count_col + 1;
                }
                tr_name_old.Cells.Add(tc_hdr_old_cname);
                tr_name_old.Cells.Add(tc_hd_old_cname);
                tbl_old.Rows.Add(tr_name_old);

                tr_date_old.Cells.Add(tc_hd_old_date);
                tr_date_old.Cells.Add(tc_old_dateinfo);
                tbl_old.Rows.Add(tr_date_old);

                tr_processor_old.Cells.Add(tc_hd_old_processor);
                tr_processor_old.Cells.Add(tc_old_processorinfo);
                tbl_old.Rows.Add(tr_processor_old);


                tr_memory_old.Cells.Add(tc_hd_old_memory);
                tr_memory_old.Cells.Add(tc_old_memoryinfo);
                tbl_old.Rows.Add(tr_memory_old);


                tr_adapter_old.Cells.Add(tc_hd_old_adapter);
                tr_adapter_old.Cells.Add(tc_old_adapterinfo);
                tbl_old.Rows.Add(tr_adapter_old);
                tr_adapter_ext_old.Cells.Add(tc_old_adapter_ext);
                tr_adapter_ext_old.Cells.Add(tc_old_adapter_ext_info);
                tbl_old.Rows.Add(tr_adapter_ext_old);



                tr_disk_old.Cells.Add(tc_hd_old_disk);
                tr_disk_old.Cells.Add(tc_old_diskinfo);
                tbl_old.Rows.Add(tr_disk_old);
                tr_disk_ext_old.Cells.Add(tc_old_disk_ext);
                tr_disk_ext_old.Cells.Add(tc_old_disk_ext_info);
                tbl_old.Rows.Add(tr_disk_ext_old);






                tbl_old.Rows.Add(tr_temp_old);
                tbl_old.Rows.Add(tr_temp_old1);
                tbl_old.Rows.Add(tr_temp_old2);
                tbl_old.Rows.Add(tr_temp_old3);




            }
            else
            {

                // Temporary Table Rows   
                TableRow tr_temp_new = new TableRow();
                TableRow tr_temp_new1 = new TableRow();
                TableRow tr_temp_new2 = new TableRow();
                TableRow tr_temp_new3 = new TableRow();


                //Computer Name information 
                int count_col1 = 0;
                TableRow tr_name_new = new TableRow();


                TableCell tc_hd_new_cname = new TableCell();
                tc_hd_new_cname.Width = 150;
                Label lbl_hd_new_cname = new Label();
                lbl_hd_new_cname.Font.Bold = true;


                //Inventory Date Information 
                TableRow tr_date_new = new TableRow();
                TableCell tc_hd_new_date = new TableCell();
                tc_hd_new_date.Width = hdwidth;
                Label lbl_hd_new_date = new Label();
                lbl_hd_new_date.Font.Bold = true;
                lbl_hd_new_date.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Inventory Date&nbsp;&nbsp; :";
                tc_hd_new_date.Controls.Add(lbl_hd_new_date);
                TableCell tc_new_dateinfo = new TableCell();
                tc_new_dateinfo.Width = infowidth;
                Label lbl_new_dateinfo = new Label();

                //Processor Name Information 

                TableRow tr_processor_new = new TableRow();
                TableCell tc_hd_new_processor = new TableCell();
                tc_hd_new_processor.Width = hdwidth;
                Label lbl_hd_new_processor = new Label();
                lbl_hd_new_processor.Font.Bold = true;
                lbl_hd_new_processor.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processor &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_new_processor.Controls.Add(lbl_hd_new_processor);
                TableCell tc_new_processorinfo = new TableCell();
                tc_new_processorinfo.Width = infowidth;
                Label lbl_new_processorinfo = new Label();


                //Physical Memory Information 


                TableRow tr_memory_new = new TableRow();
                TableCell tc_hd_new_memory = new TableCell();
                tc_hd_new_memory.Width = hdwidth;
                Label lbl_hd_new_memory = new Label();
                lbl_hd_new_memory.Font.Bold = true;
                lbl_hd_new_memory.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Memory &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_new_memory.Controls.Add(lbl_hd_new_memory);
                TableCell tc_new_memoryinfo = new TableCell();
                tc_new_memoryinfo.Width = infowidth;
                Label lbl_new_memoryinfo = new Label();



                //Adapter Information 
                TableRow tr_adapter_new = new TableRow();
                TableCell tc_hd_new_adapter = new TableCell();
                tc_hd_new_adapter.Width = hdwidth;
                Label lbl_hd_new_adapter = new Label();
                lbl_hd_new_adapter.Font.Bold = true;
                lbl_hd_new_adapter.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adapter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_new_adapter.Controls.Add(lbl_hd_new_adapter);
                TableCell tc_new_adapterinfo = new TableCell();
                tc_new_adapterinfo.Width = infowidth;
                Label lbl_new_adapterinfo = new Label();

                TableRow tr_adapter_ext_new = new TableRow();
                TableCell tc_new_adapter_ext = new TableCell();
                tc_new_adapter_ext.Width = hdwidth;
                TableCell tc_new_adapter_ext_info = new TableCell();
                tc_new_adapter_ext_info.Width = infowidth;
                tc_new_adapter_ext_info.Height = 8;
                Label lbl_new_adapter_ext = new Label();


                // Disk Information 

                TableRow tr_disk_new = new TableRow();
                TableCell tc_hd_new_disk = new TableCell();
                tc_hd_new_disk.Width = hdwidth;
                Label lbl_hd_new_disk = new Label();
                lbl_hd_new_disk.Font.Bold = true;
                lbl_hd_new_disk.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disk&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:";
                tc_hd_new_disk.Controls.Add(lbl_hd_new_disk);
                TableCell tc_new_diskinfo = new TableCell();
                tc_new_diskinfo.Width = infowidth;
                Label lbl_new_diskinfo = new Label();

                TableRow tr_disk_ext_new = new TableRow();
                TableCell tc_new_disk_ext = new TableCell();
                tc_new_adapter_ext.Width = hdwidth;
                TableCell tc_new_disk_ext_info = new TableCell();
                tc_new_disk_ext_info.Width = infowidth;
                Label lbl_new_disk_ext = new Label();





                foreach (DataColumn col in dt.Columns)
                {
                    if (count_col1 == 0)
                    {
                        invdate = (DateTime)row[col];
                        lbl_new_dateinfo.Text = invdate.ToString();
                        tc_new_dateinfo.Controls.Add(lbl_new_dateinfo);
                    }
                    if (count_col1 == 1)
                    {
                        lbl_hd_new_cname.Text = " &nbsp;";
                        tc_hd_new_cname.Controls.Add(lbl_hd_new_cname);


                    }
                    if (count_col1 == 2)
                    {
                        if (row[col] != System.DBNull.Value)
                        {
                            lbl_new_processorinfo.Text = (String)row[col];
                            tc_new_processorinfo.Controls.Add(lbl_new_processorinfo);
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;
                        }
                        else
                        {
                            lbl_new_processorinfo.Text = "-";
                            tc_new_processorinfo.Controls.Add(lbl_new_processorinfo);

                        }

                    }
                    if (count_col1 == 3)
                    {
                        if (row[col] != System.DBNull.Value)
                        {
                            lbl_new_memoryinfo.Text = (String)row[col];
                            tc_new_memoryinfo.Controls.Add(lbl_new_memoryinfo);
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;
                        }
                        else
                        {
                            lbl_new_memoryinfo.Text = "-";
                            tc_new_memoryinfo.Controls.Add(lbl_new_memoryinfo);

                        }

                    }


                    if (count_col1 == 4)
                    {
                        string varadapter;
                        int adapcount;
                        if (row[col] != System.DBNull.Value)
                        {
                            varadapter = (String)row[col];
                            string[] varadapterArr = varadapter.ToString().Split(("|").ToCharArray());
                            adapcount = varadapterArr.Length;
                            for (int i = 0; i < adapcount; i++)
                            {
                                rowcntnew = rowcntnew + 1;
                                if (i == 0)
                                {

                                    lbl_new_adapterinfo.Text = varadapterArr[0];
                                    tc_new_adapterinfo.Controls.Add(lbl_new_adapterinfo);
                                }
                                if (i != adapcount - 1 && i > 0)
                                {
                                    lbl_new_adapter_ext.Text = lbl_new_adapter_ext.Text + varadapterArr[i] + "&nbsp;";

                                }


                            }
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;

                            tc_new_adapter_ext_info.Controls.Add(lbl_new_adapter_ext);

                        }
                        else
                        {
                            lbl_new_adapterinfo.Text = "-";
                            tc_new_adapterinfo.Controls.Add(lbl_new_adapterinfo);
                            lbl_new_adapter_ext.Text = "-";
                            //tr_Lan.Visible = false;
                            //tr_Lan_ext.Visible = false;

                        }


                    }

                    if (count_col1 == 5)
                    {
                        string varphydisk;
                        int dskcount;
                        if (row[col] != System.DBNull.Value)
                        {
                            //lblmsg.Visible = true;
                            //lblmsg1.Visible = false;
                            varphydisk = (String)row[col];
                            string[] varphydiskArr = varphydisk.ToString().Split(("|").ToCharArray());
                            dskcount = varphydiskArr.Length;
                            dskcount = dskcount / 2;
                            for (int i = 0; i < dskcount; i++)
                            {

                                if (i == 0)
                                {
                                    lbl_new_diskinfo.Text = varphydiskArr[0] + varphydiskArr[1];
                                    tc_new_diskinfo.Controls.Add(lbl_new_diskinfo);
                                }

                                if (i != dskcount && i > 0)
                                {

                                    lbl_new_disk_ext.Text = lbl_new_disk_ext.Text + varphydiskArr[i + 1] + varphydiskArr[i + 2] + "&nbsp;";


                                }

                            }
                            lblmsg.Visible = true;
                            lblmsg1.Visible = false;

                        }
                        else
                        {
                            lbl_new_diskinfo.Text = "-";
                            tc_new_diskinfo.Controls.Add(lbl_new_diskinfo);
                            //lbl_new_disk_ext.Text = "-";
                            //tr_phydsk.Visible = false;
                            //tr_phydsk_ext.Visible = false;

                        }

                        tc_new_disk_ext_info.Controls.Add(lbl_new_disk_ext);

                    }




                    count_col1 = count_col1 + 1;
                }


                tr_name_new.Cells.Add(tc_hd_new_cname);
                tbl_new.Rows.Add(tr_name_new);

                tr_date_new.Cells.Add(tc_hd_new_date);
                tr_date_new.Cells.Add(tc_new_dateinfo);
                tbl_new.Rows.Add(tr_date_new);

                tr_processor_new.Cells.Add(tc_hd_new_processor);
                tr_processor_new.Cells.Add(tc_new_processorinfo);
                tbl_new.Rows.Add(tr_processor_new);

                tr_memory_new.Cells.Add(tc_hd_new_memory);
                tr_memory_new.Cells.Add(tc_new_memoryinfo);
                tbl_new.Rows.Add(tr_memory_new);

                tr_adapter_new.Cells.Add(tc_hd_new_adapter);
                tr_adapter_new.Cells.Add(tc_new_adapterinfo);
                tbl_new.Rows.Add(tr_adapter_new);
                tr_adapter_ext_new.Cells.Add(tc_new_adapter_ext);
                tr_adapter_ext_new.Cells.Add(tc_new_adapter_ext_info);
                tbl_new.Rows.Add(tr_adapter_ext_new);

                tr_disk_new.Cells.Add(tc_hd_new_disk);
                tr_disk_new.Cells.Add(tc_new_diskinfo);
                tbl_new.Rows.Add(tr_disk_new);
                tr_disk_ext_new.Cells.Add(tc_new_disk_ext);
                tr_disk_ext_new.Cells.Add(tc_new_disk_ext_info);
                tbl_new.Rows.Add(tr_disk_ext_new);

                tbl_new.Rows.Add(tr_temp_new);
                tbl_new.Rows.Add(tr_temp_new1);
                tbl_new.Rows.Add(tr_temp_new2);
                tbl_new.Rows.Add(tr_temp_new3);

            }


            if (rowcntold > rowcntnew)
            {
                rowdiff = rowcntold - rowcntnew;
                for (int j = 0; j <= rowdiff; j++)
                {
                    TableRow tr_temp = new TableRow();
                    tbl_new.Rows.Add(tr_temp);
                }
            }
            else
            {
                rowdiff = rowcntnew - rowcntold;
                for (int j = 0; j < rowdiff; j++)
                {
                    TableRow tr_temp = new TableRow();
                    tbl_old.Rows.Add(tr_temp);
                }

            }




            x = x + 1;





        }



    }


    protected void Button1_Click(object sender, EventArgs e)
    {



        string report_query;
        report_query = "select distinct  * from assetcomparison_excel order by computer_name";
        DataSet ds = commonf.GetDataSet(report_query);
        DataTable dt = ds.Tables[0];
        string sValue = String.Empty;

        StringBuilder HTMLContent = new StringBuilder();
        sValue = "\t";
        HTMLContent.Append("Inventory Date" + sValue);
        HTMLContent.Append("Computer Name" + sValue);
        HTMLContent.Append("Processor" + sValue);
        HTMLContent.Append("Memory" + sValue);
        HTMLContent.Append("Adapter" + sValue);
        HTMLContent.Append("Disk" + sValue);
        HTMLContent.Append("\n");
        HTMLContent.Append("\n");
        int cnt;
        foreach (DataRow dRow in dt.Rows)
        {
            sValue = "";
            for (cnt = 0; cnt < dt.Columns.Count; cnt++)
            {
                HTMLContent.Append(sValue + dRow[cnt].ToString());
                sValue = "\t";
            }
            HTMLContent.Append("\n");
        }
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Asset_Comparison.xls");
        HttpContext.Current.Response.Write(HTMLContent);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.Close();





    }
}
