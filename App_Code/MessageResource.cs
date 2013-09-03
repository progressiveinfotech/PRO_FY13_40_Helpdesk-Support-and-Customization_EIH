using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace Resources

{

  
public class MessageResource
{
    public static XmlDocument loResource;
    private static string _erradd;
    private static string _basicuserrole;
    private static string _close;
    private static string _erraddorg;
    private static string _erralreadymapped;
    private static string _erralready;
    private static string _errcategoryexist;
    private static string _errcategoryname;
    private static string _errcmppassword;
    private static string _errcompname;
    private static string _errcountry;
    private static string _errcountryexist;
    private static string _errcustomername;
    private static string _errdatasave;
    private static string _errdelete;
    private static string _errdepartment;
    private static string _errdepartmentexist;
    private static string _errdeptname;
    private static string _errdescription;
    private static string _errdomainname;
    private static string _errdrporg;
    private static string _errdrprole;
    private static string _errenterdays;
    private static string _errfstname;
    private static string _errimpactexist;
    private static string _errlstname;
    private static string _errmemshipcreateuseremail;
    private static string _errmodename;
    private static string _errnooperation;
    private static string _errnotempty;
    private static string _errOccured;
    private static string _erroption;
    private static string _errorgname;
    private static string _errPassword;
    
    private static string _errPriorityExist;
    private static string _errPriorityName;
    private static string _errprocessor;
    private static string _errproduct;
    private static string _errproductmanufacturer;
    private static string _errRegexpPass;
    private static string _errRegionExist;
    private static string _errRegionName;
    private static string _errRegnName;
    private static string _errRePassword;
    private static string _errResTime;
    private static string _errRoleExist;
    private static string _errRoleName;
    private static string _errSelectCategory;
    private static string _errselectdate;
    private static string _errSelectDept;
    private static string _errSelectImpact;
    private static string _errSelectOrg;
    private static string _errSelectPrty;
    private static string _errSelectregion;
    private static string _errSelectRole;
    private static string _errSelectSite;
    private static string _errselectstatus;
    private static string _errselectste;
    private static string _errSelectTopic;
    private static string _errserialno;
    private static string _errservice;
    private static string _errServiceExist;
    private static string _errServiceWindParm;
    private static string _errSiteExist;
    private static string _errSiteMapped;
    private static string _errSiteMpUmp;
    private static string _errSiteName;
    private static string _errSitesUnMapped;
    private static string _errSLADef;
    private static string _errSLAExist;
    private static string _errSLAName;
    private static string _errStateExist;
    private static string _errStateName;
    private static string _errstatus;
    private static string _errStatusExist;
    private static string _errSubcategoryExist;
    private static string _errSubcategoryname;
    private static string _errsubcategorysave;
    private static string _errTitle;
    private static string _errupdate;
    private static string _errUserDomainExist;
    private static string _errUserExist;
    private static string _errUserName;
    private static string _errUserNotVaild;
    private static string _errValdrpcategory;
    private static string _errValdrpSite;
    private static string _errValidEmail;
    private static string _errValidUrl;
    private static string _errVendorname;
    private static string _errWorkingDays;
    private static string _errWorkingTime;
    private static string _serverNameForChangePage;
    private static string _srColumnEndtime;
    private static string _strAdminEmail;
    private static string _strAdministratorRole;
    private static string _StrApproval;
    private static string _StrApproved;
    private static string _strChangestatusrequested;
    private static string _strColorGreen;
    private static string _strColorRed;
    private static string _strColorYellow;
    private static string _strColumnAssignedTime;
    private static string _strColumnCategoryid;
    private static string _strColumnChangeType;
    private static string _strColumnDeptid;
    private static string _strColumnExternalTicket;
    private static string _strColumnModeid;
    private static string _strColumnPriorityid;
    private static string _strColumnRequesttypeid;
    private static string _strColumnSiteid;
    private static string _strColumnSLAid;
    private static string _strColumnStarttime;
    private static string _strColumnstatusid;
    private static string _strColumnSubcategoryid;
    private static string _strColumnTechnicianid;
    private static string _strColumnVendorId;
    private static string _StrCompleted;
    private static string _strContactNumber;
    private static string _strDefaultPassword;
    private static string _strEmailFromLevel1Escalate;
    private static string _strEmailFromLevel2Escalate;
    private static string _strEmailFromLevel3Escalate;
    private static string _strEnterDays;
    private static string _strEnterSLA;
    private static string _StrImplemented;
    private static string _strLevel1;
    private static string _strLevel2;
    private static string _strLevel3;
    private static string _strMailServer;
    private static string _StrPlanning;
    private static string _strPManagerRole;
    private static string _strPriorityHigh;
    private static string _StrRejected;
    private static string _StrRelease;
    private static string _StrRequested;
    private static string _strRequestTypeId;
    private static string _strRequestTypeIncident;
    private static string _strSDMRole;
    private static string _strSMTPServer;
    private static string _strStatusClose;
    private static string _strStatusOnHold;
    private static string _strStatusOpen;
    private static string _strStatusResolved;
    private static string _strTechnicianRole;
    private static string _StrTesting;
    private static string _strYourSinscerely;
    private static string _strCallReportinTime;
    private static string _strAutoCallsLogging;
    private static string _strtechmapping;
    private static string _struserfeedbackmode;
    

    public static string erradd
    {
        get
        {
           
           loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _erradd = (loResource.SelectSingleNode("root/data[@name='erradd']/value")).InnerText;
            return _erradd;
        }
       set
        {
            _erradd = value; 
        }
    }
    public static string Close
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _close = (loResource.SelectSingleNode("root/data[@name='Close']/value")).InnerText;
            return _close;
        }
        set
        {
           _close = value; 
        }
    }
    public static string BasicUserRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _basicuserrole = (loResource.SelectSingleNode("root/data[@name='BasicUserRole']/value")).InnerText;
            return _basicuserrole;
        }
         set
        {
            _basicuserrole = value; 
        }
    }
    public static string errAddOrg
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _erraddorg = (loResource.SelectSingleNode("root/data[@name='errAddOrg']/value")).InnerText;
            return _erraddorg;
        }
         set
        {
            _erraddorg = value; 
        }
    }
    public static string errAlrdyMapped
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _erralreadymapped = (loResource.SelectSingleNode("root/data[@name='errAlrdyMapped']/value")).InnerText;
            return _erralreadymapped;
        }
         set
        {
            _erralreadymapped = value; 
        }
    }
    public static string erralready
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _erralready = (loResource.SelectSingleNode("root/data[@name='erralready']/value")).InnerText;
            return _erralready;
        }
         set
        {
            _erralready = value; 
        }
    }
    public static string errCategoryExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errcategoryexist = (loResource.SelectSingleNode("root/data[@name='errCategoryExist']/value")).InnerText;
            return _errcategoryexist;
        }
         set
        {
           _errcategoryexist = value; 
        }
    }
    public static string errCategoryName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errcategoryname = (loResource.SelectSingleNode("root/data[@name='errCategoryName']/value")).InnerText;
            return _errcategoryname;
        }
         set
        {
           _errcategoryname = value; 
        }
    }
    public static string errCmpPassword
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errcmppassword = (loResource.SelectSingleNode("root/data[@name='errCmpPassword']/value")).InnerText;
            return _errcmppassword;
        }
         set
        {
            _errcmppassword = value; 
        }
    }
    public static string errcompname
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
           _errcompname = (loResource.SelectSingleNode("root/data[@name='errcompname']/value")).InnerText; 
            return _errcompname;
        }
         set
        {
           _errcompname = value; 
        }
    }
    public static string errCountry
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errcountry = (loResource.SelectSingleNode("root/data[@name='errCountry']/value")).InnerText;
            return _errcountry;
        }
         set
        {
           _errcountry = value; 
        }
    }
    public static string errCountryExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
           _errcountryexist = (loResource.SelectSingleNode("root/data[@name='errCountryExist']/value")).InnerText; 
            return _errcountryexist;
        }
         set
        {
           _errcountryexist = value; 
        }
    }
    public static string errCustomername
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errcustomername = (loResource.SelectSingleNode("root/data[@name='errCustomername']/value")).InnerText;
            return _errcustomername;
        }
         set
        {
           _errcustomername = value; 
        }
    }
    public static string errDataSave
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errdatasave = (loResource.SelectSingleNode("root/data[@name='errDataSave']/value")).InnerText;
            return _errdatasave;
        }
         set
        {
            _errdatasave = value; 
        }
    }
    public static string errdelete
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errdelete = (loResource.SelectSingleNode("root/data[@name='errdelete']/value")).InnerText;     
            return _errdelete;
        }
         set
        {
            _errdelete = value; 
        }
    }
    public static string errDepartment
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errdepartment = (loResource.SelectSingleNode("root/data[@name='errDepartment']/value")).InnerText;     
            return _errdepartment;
        }
         set
        {
           _errdepartment = value; 
        }
    }
    public static string errDepartmentExist
    {
        get
        {
        loResource = new XmlDocument();
        loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
       _errdepartmentexist = (loResource.SelectSingleNode("root/data[@name='errDepartmentExist']/value")).InnerText;     
        return _errdepartmentexist;
        }
         set
        {
           _errdepartmentexist = value; 
        }
     }
    public static string errDeptName
    {
        get
        {
        loResource = new XmlDocument();
        loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
        _errdeptname = (loResource.SelectSingleNode("root/data[@name='errDeptName']/value")).InnerText;     
        return _errdeptname;
       }
         set
        {
           _errdeptname = value; 
        }
    }
    public static string errDescription
    {
    get
    {
        loResource = new XmlDocument();
        loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
        _errdescription = (loResource.SelectSingleNode("root/data[@name='errDescription']/value")).InnerText;
        return _errdescription;
    }
       set
        {
           _errdescription = value; 
        }
    }
    public static string errDomainName
     {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errdomainname = (loResource.SelectSingleNode("root/data[@name='errDomainName']/value")).InnerText;
            return _errdomainname;
        }
         set
        {
           _errdomainname = value; 
        }
     }
    public static string errDrpOrg
    {
        get
        {
        loResource = new XmlDocument();
        loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
        _errdrporg = (loResource.SelectSingleNode("root/data[@name='errDrpOrg']/value")).InnerText;
        return _errdrporg;
        }
         set
        {
            _errdrporg = value; 
        }
     }
    public static string errDrpRole
{
    get
    {
        loResource = new XmlDocument();
        loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
        _errdrprole = (loResource.SelectSingleNode("root/data[@name='errDrpRole']/value")).InnerText;
        return _errdrprole;
    }
         set
        {
           _errdrprole= value; 
        }
  }
    public static string errEnterDays
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errenterdays = (loResource.SelectSingleNode("root/data[@name='errEnterDays']/value")).InnerText;
          return _errenterdays;
      }
         set
        {
           _errenterdays = value; 
        }
  }
    public static string errFstName
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errfstname = (loResource.SelectSingleNode("root/data[@name='errFstName']/value")).InnerText;
          return _errfstname;
      }
         set
        {
           _errfstname = value; 
        }
  }
    public static string errImpactExist
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errimpactexist = (loResource.SelectSingleNode("root/data[@name='errImpactExist']/value")).InnerText;
          return _errimpactexist;
      }
         set
        {
            _errimpactexist = value; 
        }
  }
    public static string errLstName
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errlstname = (loResource.SelectSingleNode("root/data[@name='errLstName']/value")).InnerText;
          return _errlstname;
      }
         set
        {
            _errlstname = value; 
        }
  }
    public static string errMemshipCreateUserEmail
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errmemshipcreateuseremail = (loResource.SelectSingleNode("root/data[@name='errMemshipCreateUserEmail']/value")).InnerText;
          return _errmemshipcreateuseremail;
      }
         set
        {
            _errmemshipcreateuseremail = value; 
        }
  }
   
    public static string errNoOperation
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errnooperation = (loResource.SelectSingleNode("root/data[@name='errNoOperation']/value")).InnerText;
           return _errnooperation;
      }
         set
        {
           _errnooperation = value; 
        }
  }
    public static string errnotempty
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errnotempty = (loResource.SelectSingleNode("root/data[@name='errnotempty']/value")).InnerText;
          return _errnotempty;
      }
         set
        {
           _errnotempty= value; 
        }
  }
    public static string errOccured
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errOccured = (loResource.SelectSingleNode("root/data[@name='errOccured']/value")).InnerText;
          return _errOccured;
      }
         set
        {
           _errOccured = value; 
        }
  }
    public static string erroption
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _erroption = (loResource.SelectSingleNode("root/data[@name='erroption']/value")).InnerText;
          return _erroption;
      }
         set
        {
            _erroption = value; 
        }
  }
    public static string errorgname
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errorgname = (loResource.SelectSingleNode("root/data[@name='errorgname']/value")).InnerText;
          return _errorgname;
      }
         set
        {
           _errorgname = value; 
        }
  }
    public static string errPassword
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errPassword = (loResource.SelectSingleNode("root/data[@name='errPassword']/value")).InnerText;
          return _errPassword;
      }
         set
        {
            _errPassword = value; 
        }
  }
    
    public static string errPriorityExist
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errPriorityExist = (loResource.SelectSingleNode("root/data[@name='errPriorityExist']/value")).InnerText;
          return _errPriorityExist;
      }
         set
        {
           _errPriorityExist = value; 
        }
  }
    public static string errPriorityName
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errPriorityName = (loResource.SelectSingleNode("root/data[@name='errPriorityName']/value")).InnerText;
          return _errPriorityName;
      }
         set
        {
           _errPriorityName = value; 
        }
  }
    public static string errprocessor
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errprocessor = (loResource.SelectSingleNode("root/data[@name='errprocessor']/value")).InnerText;
          return _errprocessor;
      }
         set
        {
           _errprocessor = value; 
        }
  }
    public static string errproduct
  {
      get
      {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errproduct = (loResource.SelectSingleNode("root/data[@name='errproduct']/value")).InnerText;
          return _errproduct;
      }
         set
        {
           _errproduct = value; 
        }
  }
    public static string errproductmanufacturer
    {
        get
        {
          loResource = new XmlDocument();
          loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
          _errproductmanufacturer = (loResource.SelectSingleNode("root/data[@name='errproductmanufacturer']/value")).InnerText;
          return _errproductmanufacturer;
        }
         set
        {
           _errproductmanufacturer = value; 
        }
          }
    public static string errRegexpPass
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRegexpPass = (loResource.SelectSingleNode("root/data[@name='errRegexpPass']/value")).InnerText;
            return _errRegexpPass;
        }
         set
        {
            _errRegexpPass = value; 
        }
      }
    public static string errRegionExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRegionExist = (loResource.SelectSingleNode("root/data[@name='errRegionExist']/value")).InnerText;
            return _errRegionExist;
        }
         set
        {
            _errRegionExist = value; 
        }
      }
    public static string errRegionName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRegionName = (loResource.SelectSingleNode("root/data[@name='errRegionName']/value")).InnerText;
            return _errRegionName;
        }
         set
        {
          _errRegionName = value; 
        }
      }
    public static string errRegnName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRegnName = (loResource.SelectSingleNode("root/data[@name='errRegnName']/value")).InnerText;
            return _errRegnName;
        }
         set
        {
           _errRegnName = value; 
        }
      }
    public static string errRePassword
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRePassword =(loResource.SelectSingleNode("root/data[@name='errRePassword']/value")).InnerText;
            return _errRePassword;
        }
         set
        {
            _errRePassword = value; 
        }
      }

    public static string errResTime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errResTime = (loResource.SelectSingleNode("root/data[@name='errResTime']/value")).InnerText;
            return _errResTime;
        }
         set
        {
            _errResTime = value; 
        }
    }
    public static string errRoleExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRoleExist = (loResource.SelectSingleNode("root/data[@name='errRoleExist']/value")).InnerText;
            return _errRoleExist;
        }
         set
        {
           _errRoleExist = value; 
        }
    }
    public static string errRoleName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errRoleName = (loResource.SelectSingleNode("root/data[@name='errRoleName']/value")).InnerText;
             return _errRoleName;
        }
         set
        {
           _errRoleName = value; 
        }
    }
    public static string errselectdate
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errselectdate = (loResource.SelectSingleNode("root/data[@name='errselectdate']/value")).InnerText;
            return _errselectdate;
        }
         set
        {
          _errselectdate = value; 
        }
    }
    public static string errSelectDept
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectDept = (loResource.SelectSingleNode("root/data[@name='errSelectDept']/value")).InnerText;
            return _errSelectDept;
        }
         set
        {
            _errSelectDept = value; 
        }
    }
    public static string errSelectCategory
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectCategory=(loResource.SelectSingleNode("root/data[@name='errSelectCategory']/value")).InnerText;
            return _errSelectCategory;
        }
         set
        {
            _errSelectDept = value; 
        }
    }
    public static string errSelectImpact
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectImpact = (loResource.SelectSingleNode("root/data[@name='errSelectImpact']/value")).InnerText;
            return _errSelectImpact;
        }
         set
        {
           _errSelectImpact = value; 
        }
    }
    public static string errSelectOrg
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectOrg = (loResource.SelectSingleNode("root/data[@name='errSelectOrg']/value")).InnerText;
            return _errSelectOrg;
        }
         set
        {
            _errSelectOrg = value; 
        }
    }
    public static string errSelectPrty
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectPrty = (loResource.SelectSingleNode("root/data[@name='errSelectPrty']/value")).InnerText;
            return _errSelectPrty;
        }
         set
        {
           _errSelectPrty = value; 
        }
    }
    public static string errSelectregion
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectregion = (loResource.SelectSingleNode("root/data[@name='errSelectregion']/value")).InnerText;
            return _errSelectregion;
        }
         set
        {
            _errSelectregion = value; 
        }
    }
    public static string errSelectRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectRole = (loResource.SelectSingleNode("root/data[@name='errSelectRole']/value")).InnerText;
           return _errSelectRole;
        }
         set
        {
            _errSelectRole = value; 
        }
    }
    public static string errSelectSite
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectSite = (loResource.SelectSingleNode("root/data[@name='errSelectSite']/value")).InnerText;
            return _errSelectSite;
        }
         set
        {
          _errSelectSite = value; 
        }
    }
    public static string errselectstatus
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errselectstatus = (loResource.SelectSingleNode("root/data[@name='errselectstatus']/value")).InnerText;
           return _errselectstatus;
        }
         set
        {
           _errselectstatus = value; 
        }
    }
    public static string errselectste
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errselectste = (loResource.SelectSingleNode("root/data[@name='errselectste']/value")).InnerText;
            return _errselectste;
        }
         set
        {
            _errselectste = value; 
        }
    }
    public static string errSelectTopic
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSelectTopic = (loResource.SelectSingleNode("root/data[@name='errSelectTopic']/value")).InnerText;
            return _errSelectTopic;
        }
         set
        {
            _errSelectTopic = value; 
        }
    }
    public static string errserialno
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errserialno = (loResource.SelectSingleNode("root/data[@name='errserialno']/value")).InnerText;
            return _errserialno;
        }
         set
        {
            _errserialno = value; 
        }
    }
    public static string errservice
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errservice = (loResource.SelectSingleNode("root/data[@name='errservice']/value")).InnerText;
            return _errservice;
        }
         set
        {
            _errservice = value; 
        }
    }
    public static string errServiceExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errServiceExist = (loResource.SelectSingleNode("root/data[@name='errServiceExist']/value")).InnerText;
            return _errServiceExist;
        }
         set
        {
            _errServiceExist = value; 
        }
    }
    public static string errServiceWindParm
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errServiceWindParm = (loResource.SelectSingleNode("root/data[@name='errServiceWindParm']/value")).InnerText;
            return _errServiceWindParm;
        }
         set
        {
           _errServiceWindParm = value; 
        }
    }
    public static string errSiteExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSiteExist = (loResource.SelectSingleNode("root/data[@name='errSiteExist']/value")).InnerText;
            return _errSiteExist;
        }
         set
        {
           _errSiteExist = value; 
        }
    }
    public static string errSiteMapped
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSiteMapped = (loResource.SelectSingleNode("root/data[@name='errSiteMapped']/value")).InnerText;
            return _errSiteMapped;
        }
         set
        {
            _errSiteMapped = value; 
        }
    }
    public static string errSiteMpUmp
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSiteMpUmp = (loResource.SelectSingleNode("root/data[@name='errSiteMpUmp']/value")).InnerText;
            return _errSiteMpUmp;
        }
         set
        {
           _errSiteMpUmp = value; 
        }
    }
    public static string errSitesUnMapped
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSitesUnMapped = (loResource.SelectSingleNode("root/data[@name='errSitesUnMapped']/value")).InnerText;
            return _errSitesUnMapped;
        }
         set
        {
           _errSitesUnMapped = value; 
        }
    }
    public static string errSLADef
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSLADef = (loResource.SelectSingleNode("root/data[@name='errSLADef']/value")).InnerText;
            return _errSLADef;
        }
         set
        {
            _errSLADef = value; 
        }
    }
    public static string errSLAExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSLAExist = (loResource.SelectSingleNode("root/data[@name='errSLAExist']/value")).InnerText;
            return _errSLAExist;
        }
         set
        {
           _errSLAExist = value; 
        }
    }
    public static string errSLAName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSLAName = (loResource.SelectSingleNode("root/data[@name='errSLAName']/value")).InnerText;
            return _errSLAName;
        }
         set
        {
           _errSLAName = value; 
        }
    }
    public static string errStateExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errStateExist = (loResource.SelectSingleNode("root/data[@name='errStateExist']/value")).InnerText;
            return _errStateExist;
        }
         set
        {
           _errStateExist = value; 
        }
    }
    public static string errStateName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errStateName = (loResource.SelectSingleNode("root/data[@name='errStateName']/value")).InnerText;
            return _errStateName;
        }
         set
        {
           _errStateName = value; 
        }
    }
    public static string errstatus
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errstatus = (loResource.SelectSingleNode("root/data[@name='errstatus']/value")).InnerText;
            return _errstatus;
        }
         set
        {
           _errstatus = value; 
        }
    }
    public static string errStatusExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errStatusExist = (loResource.SelectSingleNode("root/data[@name='errStatusExist']/value")).InnerText;
            return _errStatusExist;
        }
         set
        {
            _errStatusExist = value; 
        }
    }
    public static string errSubcategoryExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSubcategoryExist = (loResource.SelectSingleNode("root/data[@name='errSubcategoryExist']/value")).InnerText;
            return _errSubcategoryExist;
        }
         set
        {
            _errSubcategoryExist = value; 
        }
    }
    public static string errSubcategoryname
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSubcategoryname = (loResource.SelectSingleNode("root/data[@name='errSubcategoryname']/value")).InnerText;
            return _errSubcategoryname;
        }
         set
        {
           _errSubcategoryname = value; 
        }
    }
    public static string errsubcategorysave
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errsubcategorysave = (loResource.SelectSingleNode("root/data[@name='errsubcategorysave']/value")).InnerText;
            return _errsubcategorysave;
        }
         set
        {
           _errsubcategorysave = value; 
        }
    }
    public static string errTitle
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errTitle = (loResource.SelectSingleNode("root/data[@name='errTitle']/value")).InnerText;
            return _errTitle;
        }
         set
        {
            _errTitle = value; 
        }
    }
    public static string errupdate
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errupdate = (loResource.SelectSingleNode("root/data[@name='errupdate']/value")).InnerText;
            return _errupdate;
        }
         set
        {
           _errupdate = value; 
        }
    }
    public static string errUserDomainExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errUserDomainExist = (loResource.SelectSingleNode("root/data[@name='errUserDomainExist']/value")).InnerText;
            return _errUserDomainExist;
        }
         set
        {
            _errUserDomainExist = value; 
        }
    }
    public static string errUserExist
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errUserExist = (loResource.SelectSingleNode("root/data[@name='errUserExist']/value")).InnerText;
            return _errUserExist;
        }
         set
        {
            _errUserExist = value; 
        }
    }
    public static string errUserName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errUserName = (loResource.SelectSingleNode("root/data[@name='errUserName']/value")).InnerText;
            return _errUserName;
        }
         set
        {
            _errUserName= value; 
        }
    }
   
    public static string errUserNotVaild
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errUserNotVaild = (loResource.SelectSingleNode("root/data[@name='errUserNotVaild']/value")).InnerText;
            return _errUserNotVaild;
        }
         set
        {
            _errUserNotVaild = value; 
        }
    }
    public static string errValdrpcategory
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errValdrpcategory = (loResource.SelectSingleNode("root/data[@name='errValdrpcategory']/value")).InnerText;
            return _errValdrpcategory;
        }
         set
        {
          _errValdrpcategory = value; 
        }
    }
    public static string errValdrpSite
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errValdrpSite = (loResource.SelectSingleNode("root/data[@name='errValdrpSite']/value")).InnerText;
            return _errValdrpSite;
        }
         set
        {
           _errValdrpSite = value; 
        }
    }
    public static string errValidEmail
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errValidEmail = (loResource.SelectSingleNode("root/data[@name='errValidEmail']/value")).InnerText;
            return _errValidEmail;
        }
         set
        {
            _errValidEmail = value; 
        }
    }
    public static string errValidUrl
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errValidUrl = (loResource.SelectSingleNode("root/data[@name='errValidUrl']/value")).InnerText;
            return _errValidUrl;
        }
         set
        {
           _errValidUrl = value; 
        }
    }
    public static string errVendorname
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errVendorname = (loResource.SelectSingleNode("root/data[@name='errVendorname']/value")).InnerText;
            return _errVendorname;
        }
         set
        {
           _errVendorname = value; 
        }
    }
    public static string errWorkingDays
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errWorkingDays = (loResource.SelectSingleNode("root/data[@name='errWorkingDays']/value")).InnerText;
            return _errWorkingDays;
        }
         set
        {
            _errWorkingDays = value; 
        }
    }
    public static string errWorkingTime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errWorkingTime = (loResource.SelectSingleNode("root/data[@name='errWorkingTime']/value")).InnerText;
            return _errWorkingTime;
        }
         set
        {
           _errWorkingTime = value; 
        }
    }
    public static string serverNameForChangePage
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _serverNameForChangePage = (loResource.SelectSingleNode("root/data[@name='serverNameForChangePage']/value")).InnerText;
            return _serverNameForChangePage;
        }
         set
        {
           _serverNameForChangePage = value; 
        }
    }
    public static string srColumnEndtime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _srColumnEndtime = (loResource.SelectSingleNode("root/data[@name='srColumnEndtime']/value")).InnerText;
            return _srColumnEndtime;
        }
         set
        {
            _srColumnEndtime = value; 
        }
    }
    public static string strAdminEmail
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strAdminEmail = (loResource.SelectSingleNode("root/data[@name='strAdminEmail']/value")).InnerText;
            return _strAdminEmail;
        }
         set
        {
           _strAdminEmail = value; 
        }
    }
    public static string strAdministratorRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strAdministratorRole = (loResource.SelectSingleNode("root/data[@name='strAdministratorRole']/value")).InnerText;
            return _strAdministratorRole;
        }
         set
        {
           _strAdministratorRole = value; 
        }
    }
    public static string StrApproval
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrApproval = (loResource.SelectSingleNode("root/data[@name='StrApproval']/value")).InnerText;
            return _StrApproval;
        }
         set
        {
            _StrApproval = value; 
        }
    }
    public static string StrApproved
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrApproved = (loResource.SelectSingleNode("root/data[@name='StrApproved']/value")).InnerText;
            return _StrApproved;
        }
         set
        {
           _StrApproved = value; 
        }
    }
    public static string strChangestatusrequested
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strChangestatusrequested = (loResource.SelectSingleNode("root/data[@name='strChangestatusrequested']/value")).InnerText;
            return _strChangestatusrequested;
        }
         set
        {
            _strChangestatusrequested = value; 
        }
    }
    public static string strColorGreen
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColorGreen = (loResource.SelectSingleNode("root/data[@name='strColorGreen']/value")).InnerText;
            return _strColorGreen;
        }
         set
        {
           _strColorGreen = value; 
        }
    }
    public static string strColorRed
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColorRed = (loResource.SelectSingleNode("root/data[@name='strColorRed']/value")).InnerText;
            return _strColorRed;
        }
         set
        {
           _strColorRed = value; 
        }

    }
    public static string strColorYellow
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
             _strColorYellow = (loResource.SelectSingleNode("root/data[@name='strColorYellow']/value")).InnerText;
            return _strColorYellow;
        }
         set
        {
           _strColorYellow = value; 
        }
    }
    public static string strColumnAssignedTime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnAssignedTime = (loResource.SelectSingleNode("root/data[@name='strColumnAssignedTime']/value")).InnerText;
            return _strColumnAssignedTime;
        }
         set
        {
            _strColumnAssignedTime = value; 
        }
    }
    public static string strColumnCategoryid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnCategoryid = (loResource.SelectSingleNode("root/data[@name='strColumnCategoryid']/value")).InnerText;
            return _strColumnCategoryid;
        }
         set
        {
           _strColumnCategoryid = value; 
        }
    }
    public static string strColumnChangeType
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnChangeType = (loResource.SelectSingleNode("root/data[@name='strColumnChangeType']/value")).InnerText;
            return _strColumnChangeType;
        }
         set
        {
            _strColumnChangeType = value; 
        }
    }
    public static string strColumnDeptid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnDeptid = (loResource.SelectSingleNode("root/data[@name='strColumnDeptid']/value")).InnerText;
            return _strColumnDeptid;
        }
         set
        {
            _strColumnDeptid = value; 
        }
    }
    public static string strColumnExternalTicket
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnExternalTicket = (loResource.SelectSingleNode("root/data[@name='strColumnExternalTicket']/value")).InnerText;
            return _strColumnExternalTicket;
        }
         set
        {
            _strColumnExternalTicket = value; 
        }
    }
    public static string strColumnModeid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnModeid = (loResource.SelectSingleNode("root/data[@name='strColumnModeid']/value")).InnerText;
            return _strColumnModeid;
        }
         set
        {
            _strColumnModeid = value; 
        }
    }
    public static string strColumnPriorityid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnPriorityid = (loResource.SelectSingleNode("root/data[@name='strColumnPriorityid']/value")).InnerText;
            return _strColumnPriorityid;
        }
         set
        {
            _strColumnPriorityid = value; 
        }
    }
    public static string strColumnRequesttypeid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnRequesttypeid = (loResource.SelectSingleNode("root/data[@name='strColumnRequesttypeid']/value")).InnerText;
            return _strColumnRequesttypeid;
        }
         set
        {
            _strColumnRequesttypeid = value; 
        }
    }
    public static string strColumnSiteid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnSiteid = (loResource.SelectSingleNode("root/data[@name='strColumnSiteid']/value")).InnerText;
            return _strColumnSiteid;
        }
         set
        {
            _strColumnSiteid = value; 
        }
    }
    public static string strColumnSLAid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnSLAid = (loResource.SelectSingleNode("root/data[@name='strColumnSLAid']/value")).InnerText;
            return _strColumnSLAid;
        }
         set
        {
            _strColumnSLAid = value; 
        }
    }
    public static string strColumnStarttime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnStarttime = (loResource.SelectSingleNode("root/data[@name='strColumnStarttime']/value")).InnerText;
            return _strColumnStarttime;
        }
         set
        {
            _strColumnStarttime = value; 
        }
    }
    public static string strColumnstatusid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnstatusid = (loResource.SelectSingleNode("root/data[@name='strColumnstatusid']/value")).InnerText;
            return _strColumnstatusid;
        }
         set
        {
           _strColumnstatusid = value; 
        }
    }
    public static string strColumnSubcategoryid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnSubcategoryid = (loResource.SelectSingleNode("root/data[@name='strColumnSubcategoryid']/value")).InnerText;
            return _strColumnSubcategoryid;
        }
         set
        {
            _strColumnSubcategoryid = value; 
        }
    }
    public static string strColumnTechnicianid
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnTechnicianid = (loResource.SelectSingleNode("root/data[@name='strColumnTechnicianid']/value")).InnerText;
            return _strColumnTechnicianid;
        }
         set
        {
           _strColumnTechnicianid = value; 
        }
    }
    public static string strColumnVendorId
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strColumnVendorId = (loResource.SelectSingleNode("root/data[@name='strColumnVendorId']/value")).InnerText;
            return _strColumnVendorId;
        }
         set
        {
            _strColumnVendorId = value; 
        }
    }
    public static string StrCompleted
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrCompleted = (loResource.SelectSingleNode("root/data[@name='StrCompleted']/value")).InnerText;
            return _StrCompleted;
        }
         set
        {
           _StrCompleted = value; 
        }
    }
    public static string strContactNumber
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strContactNumber = (loResource.SelectSingleNode("root/data[@name='strContactNumber']/value")).InnerText;
            return _strContactNumber;
        }
         set
        {
            _strContactNumber = value; 
        }
    }
    public static string strDefaultPassword
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strDefaultPassword = (loResource.SelectSingleNode("root/data[@name='strDefaultPassword']/value")).InnerText;
            return _strDefaultPassword;
        }
         set
        {
            _strDefaultPassword = value; 
        }
    }
    public static string strEmailFromLevel1Escalate
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strEmailFromLevel1Escalate = (loResource.SelectSingleNode("root/data[@name='strEmailFromLevel1Escalate']/value")).InnerText;
            return _strEmailFromLevel1Escalate;
        }
         set
        {
            _strEmailFromLevel1Escalate = value; 
        }
    }
    public static string strEmailFromLevel2Escalate
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strEmailFromLevel2Escalate = (loResource.SelectSingleNode("root/data[@name='strEmailFromLevel2Escalate']/value")).InnerText;
            return _strEmailFromLevel2Escalate;
        }
         set
        {
            _strEmailFromLevel2Escalate = value; 
        }
    }
    public static string strEmailFromLevel3Escalate
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strEmailFromLevel3Escalate = (loResource.SelectSingleNode("root/data[@name='strEmailFromLevel3Escalate']/value")).InnerText;
            return _strEmailFromLevel3Escalate;
        }
         set
        {
            _strEmailFromLevel3Escalate = value; 
        }
    }
    public static string strEnterDays
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strEnterDays = (loResource.SelectSingleNode("root/data[@name='strEnterDays']/value")).InnerText;
            return _strEnterDays;
        }
         set
        {
           _strEnterDays = value; 
        }
    }
    public static string strEnterSLA
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strEnterSLA = (loResource.SelectSingleNode("root/data[@name='strEnterSLA']/value")).InnerText;
            return _strEnterSLA;
        }
         set
        {
            _strEnterSLA = value; 
        }
    }
    public static string StrImplemented
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrImplemented = (loResource.SelectSingleNode("root/data[@name='StrImplemented']/value")).InnerText;
            return _StrImplemented;
        }
         set
        {
            _StrImplemented = value; 
        }
    }
    public static string strLevel1
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strLevel1 = (loResource.SelectSingleNode("root/data[@name='strLevel1']/value")).InnerText;
            return _strLevel1;
        }
         set
        {
            _strLevel1 = value; 
        }
    }
    public static string strLevel3
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strLevel3 = (loResource.SelectSingleNode("root/data[@name='strLevel3']/value")).InnerText;
            return  _strLevel3;
        }
         set
        {
           _strLevel2 = value; 
        }
    }
    public static string strLevel2
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strLevel2 = (loResource.SelectSingleNode("root/data[@name='strLevel2']/value")).InnerText;
            return _strLevel2;
        }
         set
        {
            _strLevel3 = value; 
        }
    }
    public static string strMailServer
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strMailServer = (loResource.SelectSingleNode("root/data[@name='strMailServer']/value")).InnerText;
            return _strMailServer;
        }
         set
        {
            _strMailServer = value; 
        }
    }
    public static string StrPlanning
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrPlanning = (loResource.SelectSingleNode("root/data[@name='StrPlanning']/value")).InnerText;
            return _StrPlanning;
        }
         set
        {
           _StrPlanning = value; 
        }
    }
    public static string strPManagerRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strPManagerRole = (loResource.SelectSingleNode("root/data[@name='strPManagerRole']/value")).InnerText;
            return _strPManagerRole;
        }
         set
        {
            _strPManagerRole = value; 
        }

    }
    public static string strPriorityHigh
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strPriorityHigh = (loResource.SelectSingleNode("root/data[@name='strPriorityHigh']/value")).InnerText;
            return _strPriorityHigh;
        }
         set
        {
           _strPriorityHigh = value; 
        }
    }
    public static string StrRejected
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrRejected = (loResource.SelectSingleNode("root/data[@name='StrRejected']/value")).InnerText;
           return _StrRejected;
        }
         set
        {
            _StrRejected = value; 
        }
    }
    public static string StrRelease
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrRelease = (loResource.SelectSingleNode("root/data[@name='StrRelease']/value")).InnerText;
            return _StrRelease;
        }
         set
        {
            _StrRelease = value; 
        }
    }
    public static string StrRequested
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrRequested = (loResource.SelectSingleNode("root/data[@name='StrRequested']/value")).InnerText;
            return _StrRequested;
        }
         set
        {
           _StrRequested = value; 
        }
    }
    public static string strRequestTypeId
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strRequestTypeId = (loResource.SelectSingleNode("root/data[@name='strRequestTypeId']/value")).InnerText;
            return _strRequestTypeId;
        }
         set
        {
            _strRequestTypeId = value; 
        }
    }
    public static string strRequestTypeIncident
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strRequestTypeIncident = (loResource.SelectSingleNode("root/data[@name='strRequestTypeIncident']/value")).InnerText;
            return _strRequestTypeIncident;
        }
         set
        {
            _strRequestTypeIncident = value; 
        }
    }
    public static string strSDMRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strSDMRole = (loResource.SelectSingleNode("root/data[@name='strSDMRole']/value")).InnerText;
            return _strSDMRole;
        }
         set
        {
            _strSDMRole = value; 
        }
    }
    public static string strSMTPServer
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strSMTPServer = (loResource.SelectSingleNode("root/data[@name='strSMTPServer']/value")).InnerText;
            return _strSMTPServer;
        }
         set
        {
            _strSMTPServer = value; 
        }
    }
    public static string strStatusClose
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strStatusClose = (loResource.SelectSingleNode("root/data[@name='strStatusClose']/value")).InnerText;
            return _strStatusClose;
        }
         set
        {
            _strStatusClose = value; 
        }
    }
    public static string UserFeedbackmode
    {
       get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _struserfeedbackmode = (loResource.SelectSingleNode("root/data[@name='strFeedBackMode']/value")).InnerText;
            return _struserfeedbackmode;
        }
        set
        {
            _struserfeedbackmode = value;
        }
    }

    public static string strCallReportingTime
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strCallReportinTime = (loResource.SelectSingleNode("root/data[@name='strCallReportingTime']/value")).InnerText;
            return _strCallReportinTime;
        }
        set
        {
            _strCallReportinTime = value;
        }
    }
    public static string strTechMapping
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strtechmapping = (loResource.SelectSingleNode("root/data[@name='strTechnicianMapping']/value")).InnerText;
            return _strtechmapping;
        }
        set
        {
            _strtechmapping = value;
        }
    }
    public static string strAutoCalls
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strAutoCallsLogging = (loResource.SelectSingleNode("root/data[@name='strAutoCallsLogging']/value")).InnerText;
            return _strAutoCallsLogging;
        }
        set
        {
            _strAutoCallsLogging = value;
        }
    }
    public static string strStatusOnHold
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strStatusOnHold = (loResource.SelectSingleNode("root/data[@name='strStatusOnHold']/value")).InnerText;
            return _strStatusOnHold;
        }
         set
        {
            _strStatusOnHold = value; 
        }
    }
    public static string strStatusOpen
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strStatusOpen = (loResource.SelectSingleNode("root/data[@name='strStatusOpen']/value")).InnerText;
            return _strStatusOpen;
        }
         set
        {
            
             _strStatusOpen= value; 
        }
    }
    public static string strStatusResolved
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strStatusResolved = (loResource.SelectSingleNode("root/data[@name='strStatusResolved']/value")).InnerText;
            return _strStatusResolved;
        }
         set
        {
            _strStatusResolved = value; 
        }
    }
    public static string strTechnicianRole
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strTechnicianRole = (loResource.SelectSingleNode("root/data[@name='strTechnicianRole']/value")).InnerText;
            return _strTechnicianRole;
        }
         set
        {
            _strTechnicianRole = value; 
        }
    }
    public static string StrTesting
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _StrTesting = (loResource.SelectSingleNode("root/data[@name='StrTesting']/value")).InnerText;
            return _StrTesting;
        }
         set
        {
            _StrTesting = value; 
        }
    }
    public static string strYourSinscerely
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _strYourSinscerely = (loResource.SelectSingleNode("root/data[@name='strYourSinscerely']/value")).InnerText;
            return _strYourSinscerely;
        }
         set
        {
            _strYourSinscerely = value; 
        }
    }
    public static string errSiteName
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errSiteName = (loResource.SelectSingleNode("root/data[@name='errSiteName']/value")).InnerText;     
            return _errSiteName;
        }
         set
        {
            _errSiteName = value; 
        }
    }
    public static string errModename
    {
        get
        {
            loResource = new XmlDocument();
            loResource.Load(HttpContext.Current.Server.MapPath("~/App_LocalResources/resouce.resx"));
            _errmodename = (loResource.SelectSingleNode("root/data[@name='errModename']/value")).InnerText;
            return _errmodename;
        }
         set
        {
            _errmodename = value; 
        }
    }

    public MessageResource()
    {
      
    }

  }
}
  
    
