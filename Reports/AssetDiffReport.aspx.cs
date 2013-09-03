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
using System.Data.SqlClient;

public partial class Reports_AssetDiffReport : System.Web.UI.Page
{
    CommonFunction commonf = new CommonFunction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string xmlfilePath;
            DataSet ds = new DataSet();
            xmlfilePath = Server.MapPath("~/Files/Asset.xml");
            ds.ReadXml(xmlfilePath);
            if (ds.Tables.Count > 0)
            {
                drpCmpList.DataSource = ds;
                drpCmpList.DataTextField = ds.Tables[0].Columns[0].ToString();
                drpCmpList.DataValueField = ds.Tables[0].Columns[0].ToString();
                drpCmpList.DataBind();
            }
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {


        string compname;
        compname = drpCmpList.SelectedItem.ToString();

        string datestr1 = TextBox2.Text.Trim();
        string datestr = TextBox1.Text.Trim();
        lblmsg.Text = "Asset of " + compname + " has been Changed in the following dates";
        lblmsg1.Text = "Asset of " + compname + " has Not  been Changed in the following dates";
        lblmsg1.Visible = true;
        string vardate;
        string vardate1;
        string[] tempdate = datestr.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        string[] tempdate1 = datestr1.ToString().Split(("/").ToCharArray());
        vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];



        string report_query = "select distinct * from  fn_AssetDifference_OnDate('" + compname + "',' " + vardate + " ','" + vardate1 + "')";
        DataSet ds = commonf.GetDataSet(report_query);

        Asset_Difference_Placeholder.Controls.Clear();
        DataTable dt = ds.Tables[0];
        Table tbl = new Table();
        Asset_Difference_Placeholder.Controls.Add(tbl);


        foreach (DataRow row in dt.Rows)
        {
            DateTime inv_date;
            TableRow tr_temp1 = new TableRow();
            TableRow tr_temp2 = new TableRow();
            TableRow tr_temp3 = new TableRow();
            TableRow tr_temp4 = new TableRow();

            TableRow tr_invdate = new TableRow();
            TableRow tr = new TableRow();
            TableRow tr_processor = new TableRow();
            TableRow tr_phymem = new TableRow();
            TableRow tr_Lan = new TableRow();
            TableRow tr_phydsk = new TableRow();
            TableRow tr_phydsk_ext = new TableRow();

            TableCell tc_hdr_invDate = new TableCell();
            tc_hdr_invDate.Width = 150;
            TableCell tc_hdr_invDate_info = new TableCell();
            //tc_hdr_invDate_info.Width = 500;
            Label lbl_hdr_invDate = new Label();
            Label lbl_hdr_invDate_info = new Label();
            lbl_hdr_invDate.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Inventory Date :";
            lbl_hdr_invDate.Font.Bold = true;
            tc_hdr_invDate.Controls.Add(lbl_hdr_invDate);

            TableCell tc_hdr_compname = new TableCell();
            TableCell tc_hdr_compname_info = new TableCell();
            Label lbl_hdr_compname = new Label();
            Label lbl_hdr_compname_info = new Label();
            lbl_hdr_compname.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Computer Name :";
            lbl_hdr_compname.Font.Bold = true;
            tc_hdr_compname.Controls.Add(lbl_hdr_compname);



            TableCell tc_processor = new TableCell();

            Label lbl_processor = new Label();
            TableCell tc_processor_info = new TableCell();

            Label lbl_processor_info = new Label();
            lbl_processor.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Processor :";
            lbl_processor.Font.Bold = true;
            tc_processor.Controls.Add(lbl_processor);

            TableCell tc_phymem = new TableCell();

            Label lbl_phymem = new Label();
            TableCell tc_phymem_info = new TableCell();

            Label lbl_phymem_info = new Label();
            lbl_phymem.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Physical Memory :";
            lbl_phymem.Font.Bold = true;
            tc_phymem.Controls.Add(lbl_phymem);
            int count_col = 0;

            TableCell tc_lan = new TableCell();

            Label lbl_lan = new Label();
            TableCell tc_lan_info = new TableCell();

            Label lbl_lan_info = new Label();
            lbl_lan.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "LAN CARD :";
            lbl_lan.Font.Bold = true;
            tc_lan.Controls.Add(lbl_lan);
            TableRow tr_Lan_ext = new TableRow();

            TableCell tc_lan_ext = new TableCell();

            Label lbl_lan_ext = new Label();
            TableCell tc_lan_ext1 = new TableCell();

            Label lbl_lan_ext1 = new Label();
            lbl_lan_ext1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";



            TableCell tc_phydsk = new TableCell();

            Label lbl_phydsk = new Label();
            TableCell tc_phydsk_info = new TableCell();

            Label lbl_phydsk_info = new Label();
            lbl_phydsk.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Physical Disk :";
            lbl_phydsk.Font.Bold = true;
            tc_phydsk.Controls.Add(lbl_phydsk);

            TableCell tc_phydsk_ext = new TableCell();

            Label lbl_phydsk_ext = new Label();
            lbl_phydsk_ext.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;";
            tc_phydsk_ext.Controls.Add(lbl_phydsk_ext);

            TableCell tc_phydsk_ext_info = new TableCell();

            Label lbl_phydsk_ext_info = new Label();




            foreach (DataColumn col in dt.Columns)
            {
                TableCell tc = new TableCell();
                if (count_col == 0)
                {
                    // lbl_hdr_invDate_info.Text = (String)row[col];
                    inv_date = (DateTime)row[col];
                    lbl_hdr_invDate_info.Text = inv_date.ToString();
                }
                if (count_col == 1)
                {
                    lbl_hdr_compname_info.Text = (String)row[col];
                    tc_hdr_compname_info.Controls.Add(lbl_hdr_compname_info);
                }

                if (count_col == 2)
                {
                    if (row[col] != System.DBNull.Value)
                    {
                        lblmsg.Visible = true;
                        lblmsg1.Visible = false;
                        lbl_processor_info.Text = (String)row[col]; ;
                        tc_processor_info.Controls.Add(lbl_processor_info);

                    }
                    else
                    {
                        tr_processor.Visible = false;

                    }







                }
                if (count_col == 3)
                {

                    if (row[col] != System.DBNull.Value)
                    {
                        lblmsg.Visible = true;
                        lblmsg1.Visible = false;
                        lbl_phymem_info.Text = (String)row[col];
                        tc_phymem_info.Controls.Add(lbl_phymem_info);
                    }
                    else
                    {

                        tr_phymem.Visible = false;
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
                            if (i == 0)
                            {
                                lblmsg.Visible = true;
                                lblmsg1.Visible = false;
                                lbl_lan_info.Text = varadapterArr[0];
                                tc_lan_info.Controls.Add(lbl_lan_info);
                            }
                            if (i != adapcount - 1 && i > 0)
                            {
                                lbl_lan_ext.Text = lbl_lan_ext.Text + varadapterArr[i] + "   ";

                            }


                        }



                    }
                    else
                    {

                        tr_Lan.Visible = false;
                        tr_Lan_ext.Visible = false;

                    }


                }

                if (count_col == 5)
                {
                    string varphydisk;
                    int dskcount;
                    if (row[col] != System.DBNull.Value)
                    {
                        lblmsg.Visible = true;
                        lblmsg1.Visible = false;
                        varphydisk = (String)row[col];
                        string[] varphydiskArr = varphydisk.ToString().Split(("|").ToCharArray());
                        dskcount = varphydiskArr.Length;
                        dskcount = dskcount / 2;
                        for (int i = 0; i < dskcount; i++)
                        {

                            if (i == 0)
                            {
                                lbl_phydsk_info.Text = varphydiskArr[0] + varphydiskArr[1];
                                tc_phydsk_info.Controls.Add(lbl_phydsk_info);
                            }
                            //lbl_phydsk_ext_info
                            if (i != dskcount - 1 && i > 0)
                            {

                                lbl_phydsk_ext_info.Text = lbl_lan_ext.Text + varphydiskArr[i + 1] + varphydiskArr[i + 2] + "   ";


                            }

                        }

                    }
                    else
                    {

                        tr_phydsk.Visible = false;
                        tr_phydsk_ext.Visible = false;

                    }



                }


                count_col = count_col + 1;
            }
            tc_hdr_invDate_info.Controls.Add(lbl_hdr_invDate_info);

            tr_invdate.Cells.Add(tc_hdr_invDate);
            tr_invdate.Cells.Add(tc_hdr_invDate_info);
            tr.Cells.Add(tc_hdr_compname);
            tr.Cells.Add(tc_hdr_compname_info);
            tr_processor.Cells.Add(tc_processor);
            tr_processor.Cells.Add(tc_processor_info);
            tr_phymem.Cells.Add(tc_phymem);
            tr_phymem.Cells.Add(tc_phymem_info);
            tr_Lan.Cells.Add(tc_lan);
            tr_Lan.Cells.Add(tc_lan_info);
            tr_phydsk.Cells.Add(tc_phydsk);
            tr_phydsk.Cells.Add(tc_phydsk_info);

            tr_phydsk_ext.Cells.Add(tc_phydsk_ext);
            tr_phydsk_ext.Cells.Add(tc_phydsk_ext_info);

            tbl.Rows.Add(tr_temp1);
            tbl.Rows.Add(tr_temp2);
            tbl.Rows.Add(tr_temp3);
            tbl.Rows.Add(tr_temp4);
            tbl.Rows.Add(tr_invdate);
            tbl.Rows.Add(tr);
            tbl.Rows.Add(tr_processor);
            tbl.Rows.Add(tr_phymem);
            tbl.Rows.Add(tr_Lan);
            tc_lan_ext.Controls.Add(lbl_lan_ext);
            tc_lan_ext1.Controls.Add(lbl_lan_ext1);
            tr_Lan_ext.Cells.Add(tc_lan_ext1);
            tr_Lan_ext.Cells.Add(tc_lan_ext);
            tbl.Rows.Add(tr_Lan_ext);
            tbl.Rows.Add(tr_phydsk);
            tbl.Rows.Add(tr_phydsk_ext);



        }


        // dtgrid1.DataSource = ds;
        //dtgrid1.DataBind();

    }


  
}
