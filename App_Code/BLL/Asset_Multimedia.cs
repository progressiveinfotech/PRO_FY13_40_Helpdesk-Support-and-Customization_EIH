using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Asset_Multimedia
/// </summary>
public class Asset_Multimedia
{
    #region Private Fields
    public string _monitor_name;
    public string _manufacturer;
    public string _horizontal_res;
    public string _vertical_res;
    public string _features;
    public string _gamma;
    public string _max_horizontal_size;
    public string _max_vertical_size;
    public string _type;
    public string _product_id;
    public string _serial_number;
    public string _vendor_id;
    public string _manufacturing_date;
    public string _computer_name;
    public string _inventory_date;
    public string _domain_workgroup;
    #endregion
    #region Public Fields
    public string Monitor_Name
    {
        get { return _monitor_name; }
        set { _monitor_name = value; }
    }
    public string Manufacturer
    {
        get { return _manufacturer; }
        set { _manufacturer = value; }
    }
    public string Horizontal_res
    {
        get { return _horizontal_res; }
        set { _horizontal_res = value; }
    }
    public string Vertical_res
    {
        get { return _vertical_res; }
        set { _vertical_res = value; }
    }
    public string Features
    {
        get { return _features; }
        set { _features = value; }
    }
    public string Gamma
    {
        get { return _gamma; }
        set { _gamma = value; }
    }
    public string Max_Horizontal_Size
    {
        get { return _max_horizontal_size; }
        set { _max_horizontal_size = value; }
    }
    public string Max_Vertical_Size
    {
        get { return _max_vertical_size; }
        set { _max_vertical_size = value; }
    }
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public string Product_id
    {
        get { return _product_id; }
        set { _product_id = value; }
    }
    public string Serial_Number
    {
        get { return _serial_number; }
        set { _serial_number = value; }
    }
    public string Vendor_Id
    {
        get { return _vendor_id; }
        set { _vendor_id = value; }
    }
    public string Manufacturing_Date
    {
        get { return _manufacturing_date; }
        set { _manufacturing_date = value; }
    }
    public string Computer_Name
    {
        get { return _computer_name; }
        set { _computer_name = value; }
    }
    public string Inventory_Date
    {
        get { return _inventory_date; }
        set { _inventory_date = value; }
    }
    public string Domain_Workgroup
    {
        get { return _domain_workgroup; }
        set { _domain_workgroup = value; }
    }
    #endregion
    #region Constructors
    public Asset_Multimedia()
    {
    }
    public Asset_Multimedia(string monitor_name, string manufacturer, string vertical_res, string features, string gamma,
        string max_horizontal_size, string max_vertical_size, string type, string product_id, string serial_number, string vendor_id,
        string manufacturing_date, string computer_name, string inventory_date, string domain_workgroup)
    {
        _monitor_name = monitor_name;
        _manufacturer = manufacturer;
        _vertical_res = vertical_res;
        _features = features;
        _gamma = gamma;
        _max_horizontal_size = max_horizontal_size;
        _max_vertical_size = max_vertical_size;
        _type = type;
        _product_id = product_id;
        _serial_number = serial_number;
        _vendor_id = Vendor_Id;
        _manufacturing_date = Manufacturing_Date;
        _computer_name = computer_name;
        _inventory_date = inventory_date;
        _domain_workgroup = domain_workgroup;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_Asset_MUltimedia(this);

    }
    #endregion
}

