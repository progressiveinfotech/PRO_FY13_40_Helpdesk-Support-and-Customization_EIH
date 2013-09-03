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

/// <summary>
/// Summary description for ChangeHistoryDiff
/// </summary>
public class ChangeHistoryDiff
{
	
     #region Private Fields
    private string _Pre_value;
    private int _Historyid;
    private int _Historydiffid;
    private string _Current_value;
    private string _ColumnName;
    #endregion
    #region Public Fields
    public string Prev_value
    {
        get { return _Pre_value; }
        set { _Pre_value = value; }
    }
    public int Historyid
    {
        get { return _Historyid; }
        set { _Historyid = value; }
    }
    public int Historydiffid
    {
        get { return _Historydiffid; }
        set { _Historydiffid = value; }
    }
    public string Current_value
    {
        get { return _Current_value; }
        set { _Current_value = value; }
    }
    public string Columnname
    {
        get { return _ColumnName; }
        set { _ColumnName = value; }
    }
    #endregion
    #region Constructor
    public ChangeHistoryDiff()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public ChangeHistoryDiff(string prev_value, int historyid, int historydiffid, string current_value, string columnname)
    {
        _Pre_value = prev_value;
        _Historyid = historyid;
        _Historydiffid = historydiffid;
        _Current_value = current_value;
        _ColumnName = columnname;
    }

    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_ChangeHistoryDiff_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
      
        return db.Update_ChangeHistoryDiff_mst_By_id(this);
    }
    public int Delete(int historydiffid)
    {
        SqlDataProvider db = new SqlDataProvider();
        
        return db.Delete_ChangeHistoryDiff_mst_By_id(historydiffid);
    }
    public BLLCollection<ChangeHistoryDiff> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
     
        return db.Get_ChangeHistoryDiff_mst_All();
    }
    public ChangeHistoryDiff Get_By_id(int historydiffid)
    {
        SqlDataProvider db = new SqlDataProvider();
       
        return db.ChangeHistoryDiff_mst_Get_By_historydiffid(historydiffid);
    }
    public BLLCollection<ChangeHistoryDiff> Get_All_By_Historyid(int historyid)
    {
        SqlDataProvider db = new SqlDataProvider();
       
        return db.Get_ChangeHistoryDiff_mst_All_By_Historyid(historyid);
    }

    #endregion
}
