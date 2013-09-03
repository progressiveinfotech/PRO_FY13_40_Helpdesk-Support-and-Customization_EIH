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
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

/// <summary>
/// Summary description for SqlDataProvider
/// </summary>


public partial class SqlDataProvider
{
    #region Insert Procedure Description
    private const string Sp_Get_Cab_By_Membername = "Sp_Get_Cab_By_Membername_mst";
    private const string Sp_Get_Customer_By_Customername = "Sp_Get_Customer_By_Custname_mst";
    private const string Sp_ChangeTask_Insert = "sp_ChangeTask_Insert_mst";
    private const string Sp_Get_Cab_By_Cabid = "Sp_Get_Cab_By_Cabid_mst";
    private const string Sp_Get_Customer_By_Cabid = "Sp_Get_Customer_By_Custid_mst";
    private const string Sp_Service_Insert = "Sp_Service_Insert_mst";
    private const string Sp_Get_Holidaydesc_Desc_By_Holidayid = "Sp_Get_Holidaydesc_Desc_By_Holidayid_mst";
    private const string Sp_Check_Mode = "Sp_Check_Mode_mst";
    private const string Sp_Check_Hub = "Sp_Check_Hub";
    private const string Sp_Check_TechnicianSLAStop = "Sp_Check_TechnicianSLAStop";
    private const string sp_CategoryAssigntoUSer_Insert_mst = "sp_CategoryAssigntoUSer_Insert_mst";
    private const string sp_CategoryAssigntoUSer_Update_mst = "sp_CategoryAssigntoUSer_Update_mst";
    private const string Sp_Check_Email = "Sp_Check_Email_mst";
    private const string Sp_Check_Asset = "Sp_Check_Asset_mst";
    private const string Sp_Check_ServiceWindow = "Sp_Check_ServiceWindow_mst";
    private const string Sp_Check_Vendor = "Sp_Check_Vendor_mst";
    private const string Sp_Check_Role = "Sp_Check_Role_mst";
    private const string Sp_Check_Customer = "Sp_Check_Customer_mst";
    private const string Sp_Check_Holiday = "Sp_check_Holiday_mst";
    private const string Sp_Check_AssetId_From_UserToAssetMap = "Sp_Check_AssetId_From_UserToAssetMap";
    private const string Sp_Check_UserId_From_UserToAssetMap = "Sp_Check_UserId_From_UserToAssetMap";
    private const string Sp_Check_SiteId_From_UserToAssetMap = "Sp_Check_SiteId_From_UserToAssetMap";

    private const string Sp_Organization_Insert = "sp_Organization_Insert_mst";
    private const string Sp_Region_Insert = "sp_Region_Insert_mst";
    private const string Sp_Site_Insert = "sp_Site_Insert_mst";
    private const string Sp_Country_Insert = "sp_Country_Insert_mst";
    private const string Sp_Holiday_Insert = "sp_Holiday_Insert_mst";
    private const string Sp_Cab_Insert = "Sp_Cab_Insert_mst";
    private const string Sp_Customer_Insert = "Sp_Customer_Insert_mst";
    private const string Sp_Mode_Insert = "sp_Mode_Insert_mst";
    private const string Sp_Hub_Insert = "Sp_Hub_Insert";

    private const string Sp_Impact_Insert = "sp_Impact_Insert_mst";
    private const string Sp_Category_Insert = "sp_Category_Insert_mst";
    private const string Sp_SubCategory_Insert = "sp_SubCategory_Insert_mst";
    private const string Sp_Priority_Insert = "sp_Priority_Insert_mst";
    private const string Sp_UserLogin_Insert = "sp_UserLogin_Insert_mst";
    private const string Sp_UserToEmail_Insert = "Sp_UserToEmail_Insert";
    private const string Sp_FeedbackCustomer_Insert = "Sp_FeedbackCustomer_Insert";
    private const string Sp_ContactInfo_Insert = "sp_ContactInfo_Insert_mst";
    private const string Sp_RoleInfo_Insert = "sp_RoleInfo_Insert_mst";
    private const string Sp_CabCommittee_Insert = "sp_CabCommittee_Insert_mst";
    private const string Sp_CabMember_Insert = "sp_CabMember_Insert_mst";
    private const string Sp_SLA_Insert = "sp_SLA_Insert_mst";
    private const string Sp_Status_Insert = "sp_Status_Insert_mst";
    private const string Sp_ChangeStatus_Insert = "sp_ChangeStatus_Insert_mst";
    private const string Sp_ChangeType_Insert = "sp_ChangeType_Insert_mst";
    private const string Sp_ServiceWindow_Insert = "sp_ServiceWindow_Insert_mst";
    private const string Sp_Servicehours_Insert = "sp_Servicehours_Insert_mst";
    private const string Sp_ServiceDay_Insert = "sp_ServiceDay_Insert_mst";
    private const string Sp_Vendor_Insert = "sp_Vendor_Insert_mst";
    private const string Sp_SLA_Priority_Insert = "sp_SLA_Priority_Insert_mst";
    private const string Sp_UserToSiteMapping_Insert = "sp_UserToSiteMapping_Insert_mst";
    private const string Sp_State_Insert = "sp_State_Insert_mst";
    private const string Sp_Department_Insert = "sp_Department_Insert_mst";
    private const string Sp_Incident_Insert = "sp_Incident_Insert_mst";
    private const string Sp_IncidentStates_Insert = "sp_IncidentStates_Insert_mst";
    private const string Sp_Get_Impact_By_id = "sp_Get_Impactid_By_id_mst";
    private const string Sp_IncidentHistory_Insert = "sp_IncidentHistory_Insert_mst";
    private const string Sp_IncidentHistoryDiff_Insert = "sp_IncidentHistoryDiff_Insert_mst";
    private const string Sp_ProblemHistoryDiff_Insert = "sp_ProblemHistoryDiff_Insert_mst";
    private const string Sp_ChangeHistoryDiff_Insert = "Sp_ChangeHistoryDiff_Insert_mst";
    private const string Sp_Solution_Insert = "sp_Solution_Insert_mst";
    private const string Sp_SolutionKeyword_Insert = "sp_SolutionKeyword_Insert_mst";
    private const string Sp_SolutionCreator_Insert = "sp_SolutionCreator_Insert_mst";
    private const string Sp_RequestType_Insert = "sp_RequestType_Insert_mst";
    private const string Sp_IncidentResolution_Insert = "sp_IncidentResolution_Insert_mst";
    private const string Sp_IncidentLog_Insert = "sp_IncidentLog_Insert_mst";
    private const string Sp_Problem_Insert = "sp_Problem_Insert_mst";
    private const string Sp_Change_Insert = "sp_Change_Insert_mst";
    private const string Sp_Title_Insert = "Sp_Title_Insert_mst";
    private const string Sp_ChangeApprove_trans_Insert = "Sp_ChangeApprove_trans_Insert";
    private const string Sp_IncludeassetChange_Insert = "sp_IncludeassetChange_Insert_mst";
    private const string Sp_Incident_To_Problem_Insert = "sp_Incident_To_Problem_Insert_mst";
    private const string Sp_Incident_To_Change_Insert = "sp_Incident_To_Change_Insert_mst";
    private const string Sp_Problem_To_Change_Insert = "Sp_Problem_To_Change_Insert_mst ";
    private const string Sp_Group_mst_Insert = "sp_Group_mst_Insert_mst";
    private const string Sp_Technician_To_Group_Insert = "sp_Technician_To_Group_Insert_mst";
    private const string Sp_ProblemHistory_Insert = "sp_ProblemHistory_Insert_mst";
    private const string Sp_ChangeHistory_Insert = "sp_ChangeHistory_Insert_mst";
    private const string Sp_ProblemNotes_Insert = "sp_ProblemNotes_Insert_mst";
    private const string Sp_ChangeNotes_Insert = "sp_ChangeNotes_Insert_mst";
    private const string Sp_ConfigurableItems_Insert = "Sp_ConfigurableItems_Insert_mst";
    private const string Sp_CMDBTrans_Insert = "Sp_CMDBTrans_Insert_mst";
    private const string Sp_CMDB_Insert = "Sp_CMDB_Insert_mst";
    private const string sp_Get_CategoryAssignTouser_mst_By_Category_SubCategory = "sp_Get_CategoryAssignTouser_mst_By_Category_SubCategory";
    private const string Sp_Configuration_Insert = "Sp_Configuration_Insert_mst";
    private const string Sp_CustomerFeedback_Insert = "Sp_CustomerFeedback_Insert_mst";
    private const string Sp_ProblemToSolution_Insert = "sp_ProblemToSolution_Insert_mst";
    private const string Sp_Update_Assetid_By_id = "Sp_Update_Assetid_By_id_mst";
    private const string Sp_ProblemAnalysis_Insert = "sp_ProblemAnalysis_Insert_mst";
    private const string Sp_ProblemSymptom_Insert = "sp_ProblemSymptom_Insert_mst";
    private const string Sp_ProblemRootcause_Insert = "sp_ProblemRootcause_Insert_mst";
    private const string Sp_ProblemImpact_Insert = "sp_ProblemImpact_Insert_mst";
    private const string Sp_ChangeBackoutPlan_Insert = "sp_ChangeBackoutPlan_Insert_mst";
    private const string Sp_ChangeRollOut_Insert = "sp_ChangeRollOut_Insert_mst";
    private const string Sp_ChangeImpact_Insert = "sp_ChangeImpact_Insert_mst";
    private const string Sp_Asset_Insert = "sp_Asset_Insert_mst";
    private const string Sp_Asset_Insert1 = "Sp_Asset_Insert1_mst";
    private const string sp_Asset_Inventory_Insert = "sp_Asset_Inventory_Insert_mst";
    private const string sp_Asset_Inventory_Insert1 = "sp_Asset_Inventory_Insert1_mst";
    private const string sp_Asset_LogicalDrive_Insert = "sp_Asset_LogicalDrive_Insert_mst";
    private const string sp_Asset_LogicalDrive_Insert1 = "sp_Asset_LogicalDrive_Insert1_mst";
    private const string sp_Asset_Memory_Insert = "sp_Asset_Memory_Insert_mst";
    private const string sp_Asset_Memory_Insert1 = "sp_Asset_Memory_Insert1_mst";
    private const string sp_Asset_Network_Insert = "sp_Asset_Network_Insert_mst";
    private const string sp_Asset_Network_Insert1 = "sp_Asset_Network_Insert1_mst";
    //added by lalit 02nov 2011

    private const string sp_Get_UserLogin_mst = "sp_Get_UserLogin_mst";
    private const string sp_Asset_OperatingSystem_Insert = "sp_Asset_OperatingSystem_Insert_mst";
    private const string sp_Asset_OperatingSystem_Insert1 = "sp_Asset_OperatingSystem_Insert1_mst";
    private const string sp_Asset_PhysicalDrive_Insert = "sp_Asset_PhysicalDrive_Insert_mst";
    private const string sp_Asset_PhysicalDrive_Insert1 = "sp_Asset_PhysicalDrive_Insert1_mst";
    private const string sp_Asset_Processor_Insert = "sp_Asset_Processor_Insert_mst";
    private const string sp_Asset_Processor_Insert1 = "sp_Asset_Processor_Insert1_mst";
    private const string sp_Asset_ProductInfo_Insert = "sp_Asset_ProductInfo_Insert_mst";
    private const string sp_multimedia_insert = "sp_multimedia_insert";
    private const string sp_Asset_ProductInfo_Insert1 = "sp_Asset_ProductInfo_Insert1_mst";
    private const string sp_UserToAssetMapping_Insert = "sp_UserToAssetMapping_Insert";
    private const string sp_EscalateEmail_mst_Insert = "sp_EscalateEmail_Insert_mst";
    private const string Sp_Check_ComputerName = "Sp_Check_ComputerName_mst";
    private const string sp_EscalateLevel1_mst_Insert = "sp_EscalateLevel1_Insert_mst";
    private const string sp_EscalateLevel2_mst_Insert = "sp_EscalateLevel2_Insert_mst";
    private const string sp_EscalateLevel3_mst_Insert = "sp_EscalateLevel3_Insert_mst";
    private const string sp_CheckEmailEscalate_Insert = "sp_CheckEmailEscalate_Insert_mst";
    private const string sp_CheckLevel1Escalate_Insert = "sp_CheckLevel1Escalate_Insert";
    private const string sp_CheckLevel2Escalate_Insert = "sp_CheckLevel2Escalate_Insert";
    private const string sp_CheckLevel3Escalate_Insert = "sp_CheckLevel3Escalate_Insert";
    private const string sp_ColorScheme_Insert = "sp_ColorScheme_Insert_mst";
    private const string sp_IncidentToAssetMapping_Insert = "sp_IncidentToAssetMapping_Insert";
    private const string Sp_Check_AssetId_From_IncidentToAssetMap = "Sp_Check_AssetId_From_IncidentToAssetMap";
    private const string Sp_Check_IncidentId_From_IncidentToAssetMap = "Sp_Check_IncidentId_From_IncidentToAssetMap";
    private const string sp_IncidentDeactiveCalls_Insert = "sp_IncidentDeactiveCalls_Insert_mst";
    private const string sp_Contract_Insert = "sp_Contract_Insert_mst";
    private const string sp_ContractNotification_Insert = "sp_ContractNotification_Insert_mst";
    private const string sp_ContractToAssetMapping_Insert = "sp_ContractToAssetMapping_Insert_mst";
    private const string Sp_ColorName_From_ColorScheme = "Sp_Check_ColorName_From_ColorScheme_mst";
    private const string sp_ContractRenewed_Insert = "sp_ContractRenewed_Insert_mst";
    private const string sp_CustomerToSiteMapping_Insert = "sp_CustomerToSiteMapping_Insert_mst";
    private const string Sp_GetCustomerFeedback__By_incidentid_mst_By_Call = "Sp_GetCustomerFeedback__By_incidentid_mst_By_Call";
    private const string Sp_CustomerFeedback_Insert_mst_callwise = "Sp_CustomerFeedback_Insert_mst_callwise";


    #endregion

    #region Update Procedure Description
    //private const string Sp_ChangeTask_Update = "Sp_ChangeTask_Update_mst";
    private const string Sp_ChangeTask_Update = "sp_ChangeTask_Update";
    private const string Sp_Service_Update = "Sp_Service_Update_mst";
    private const string Sp_Organization_Update = "sp_Organization_Update_mst";
    private const string Sp_Region_Update = "sp_Region_Update_mst";
    private const string Sp_Site_Update = "sp_Site_Update_mst";
    private const string Sp_Hub_Update = "Sp_Hub_Update";
    private const string Sp_Hubsite_Insert = "Sp_Hubsite_Insert";
    private const string Sp_CabCommittee_Update = "sp_CabCommittee_Update_mst";
    private const string Sp_CabMember_Update = "sp_CabMember_Update_mst";
    private const string Sp_Category_Update = "sp_Category_Update_mst";
    private const string Sp_Configurable_Update = "Sp_Configurable_Update_mst";
    private const string Sp_CMDB_Update = "Sp_CMDB_Update_mst";
    private const string Sp_Configuration_Update = "Sp_Configuration_Update_mst";
    private const string Sp_ContactInfo_Update = "sp_ContactInfo_Update_mst";
    private const string Sp_Country_Update = "sp_Country_Update_mst";
    private const string Sp_Holiday_Update = "sp_Holiday_Update_mst";
    private const string Sp_Cab_Update = "Sp_Cab_Update_mst";
    private const string Sp_Customer_Update = "Sp_Customer_Update_mst";
    private const string Sp_Impact_Update = "sp_Impact_Update_mst";
    private const string Sp_Mode_Update = "sp_Mode_Update_mst";
    private const string Sp_Priority_Update = "sp_Priority_Update_mst";
    private const string Sp_RoleInfo_Update = "sp_RoleInfo_Update_mst";
    private const string Sp_ServiceDay_Update = "sp_ServiceDay_Update_mst";
    private const string Sp_Servicehours_Update = "sp_Servicehours_Update_mst";
    private const string Sp_ServiceWindow_Update = "sp_ServiceWindow_Update_mst";
    private const string Sp_SLA_Update = "sp_SLA_Update_mst";
    private const string Sp_SLA_Priority_Update = "sp_SLA_Priority_Update_mst";
    private const string Sp_Status_Update = "sp_Status_Update_mst";
    private const string Sp_ChangeStatus_Update = "sp_ChangeStatus_Update_mst";
    private const string Sp_ChangeType_Update = "sp_ChangeType_Update_mst";
    private const string Sp_SubCategory_Update = "sp_SubCategory_Update_mst";
    private const string Sp_UserLogin_Update = "sp_UserLogin_Update_mst";
    private const string Sp_UserEmail_Update = "Sp_UserEmail_Update";
    private const string Sp_Vendor_Update = "sp_Vendor_Update_mst";
    private const string Sp_State_Update = "sp_State_Update_mst";
    private const string Sp_Department_Update = "sp_Department_Update_mst";
    private const string Sp_Incident_Update = "sp_Incident_Update_mst";
    private const string Sp_IncidentStates_Update = "sp_IncidentStates_Update_mst";
    private const string Sp_IncidentHistory_Update = "sp_IncidentHistory_Update_mst";
    private const string Sp_IncidentHistoryDiff_Update = "sp_IncidentHistoryDIff_Update_mst";
    private const string Sp_ProblemHistoryDiff_Update = "sp_ProblemHistoryDIff_Update_mst";
    private const string Sp_ChangeHistoryDiff_Update = "sp_ChangeHistoryDIff_Update_mst";
    private const string Sp_Solution_Update = "sp_Solution_Update_mst";
    private const string Sp_SolutionKeyword_Update = "sp_SolutionKeyword_Update_mst";
    private const string Sp_SolutionCreator_Update = "sp_SolutionCreator_Update_mst";
    private const string Sp_RequestType_Update = "sp_RequestType_Update_mst";
    private const string Sp_IncidentResolution_Update = "sp_IncidentResolution_Update_mst";
    private const string Sp_IncidentLog_Update = "sp_IncidentLog_Update_mst";
    private const string Sp_Problem_Update = "sp_Problem_Update_mst";
    private const string Sp_Change_Update = "sp_Change_Update_mst";
    private const string Sp_ProblemAnalysis_Update = "Sp_ProblemAnalysis_Update";
    private const string Sp_ProblemSymptom_Update = "Sp_ProblemSymptom_Update";
    private const string Sp_ProblemRootcause_Update = "Sp_ProblemRootcause_Update";
    private const string Sp_ProblemImpact_Update = "Sp_ProblemImpact_Update";
    private const string Sp_ChangeBackoutPlan_Update = "Sp_ChangeBackoutPlan_Update";
    private const string Sp_ChangeRollOut_Update = "Sp_ChangeRollOutPlan_Update";
    private const string Sp_ChangeImpact_Update = "Sp_ChangeImpact_Update";
    private const string Sp_Incident_To_Problem_Update = "sp_Incident_To_Problem_Update_mst";
    private const string Sp_Incident_To_Change_Update = "sp_Incident_To_Change_Update_mst";
    private const string Sp_Problem_To_Change_Update = "Sp_Problem_To_Change_Update";
    private const string Sp_Group_mst_Update = "sp_Group_mst_Update_mst";
    private const string Sp_Technician_To_Group_Update = "sp_Technician_To_Group_Update_mst";
    private const string Sp_Asset_Update = "Sp_Asset_Update_mst";
    private const string Sp_Asset_Inventory_Update = "Sp_Asset_Inventory_Update_mst";
    private const string Sp_Asset_LogicalDrive_Update = "Sp_Asset_LogicalDrive_Update_mst";
    private const string Sp_Asset_Memory_Update = "Sp_Asset_Memory_Update_mst";
    private const string Sp_Asset_Network_Update = "Sp_Asset_Network_Update_mst";
    private const string Sp_Asset_OperatingSystem_Update = "Sp_Asset_OperatingSystem_Update_mst";
    private const string Sp_Asset_PhysicalDrive_Update = "Sp_Asset_PhysicalDrive_Update_mst";
    private const string Sp_Asset_Processor_Update = "Sp_Asset_Processor_Update_mst";
    private const string Sp_Asset_ProductInfo_Update = "Sp_Asset_ProductInfo_Update_mst";
    private const string Sp_UserToAssetMapping_Update = "Sp_UserToAssetMapping_Update";
    private const string sp_EscalateEmail_mst_Update = "sp_EscalateEmail_Update_mst";
    private const string sp_EscalateLevel1_mst_Update = "sp_EscalateLevel1_Update_mst";
    private const string sp_EscalateLevel2_mst_Update = "sp_EscalateLevel2_Update_mst";
    private const string sp_EscalateLevel3_mst_Update = "sp_EscalateLevel3_Update_mst";
    private const string sp_CheckEmailEscalate_Update = "sp_CheckEmailEscalate_Update_mst";
    private const string sp_CheckLevel1Escalate_Update = "sp_CheckLevel1Escalate_Update";
    private const string sp_CheckLevel2Escalate_Update = "sp_CheckLevel2Escalate_Update";
    private const string sp_CheckLevel3Escalate_Update = "sp_CheckLevel3Escalate_Update";
    private const string sp_ColorScheme_Update = "sp_ColorScheme_Update_mst";
    private const string Sp_IncidentToAssetMapping_Update = "Sp_IncidentToAssetMapping_Update";
    private const string sp_IncidentDeactiveCalls_Update = "sp_IncidentDeactiveCalls_Update_mst";
    private const string sp_Contract_Update = "sp_Contract_Update_mst";
    private const string sp_ContractNotification_Update = "sp_ContractNotification_Update_mst";
    private const string sp_ContractToAssetMapping_Update = "sp_ContractToAssetMapping_Update_mst";
    private const string sp_ContractRenewed_Update = "sp_ContractRenewed_Update_mst";
    private const string sp_CustomerToSiteMapping_Update = "sp_CustomerToSiteMapping_Update_mst";
    #endregion

    #region Delete Procedure Description
    private const string Sp_Service_Delete = "Sp_Service_Delete_mst";
    private const string Sp_Organization_Delete = "sp_Organization_Delete_mst";
    private const string Sp_Region_Delete = "sp_Region_Delete_mst";
    private const string Sp_Site_Delete = "sp_Site_Delete_mst";
    private const string Sp_CabCommittee_Delete = "sp_CabCommittee_Delete_mst";
    private const string Sp_CabMember_Delete = "sp_CabMember_Delete_mst";
    private const string Sp_Category_Delete = "sp_Category_Delete_mst";
    private const string Sp_ContactInfo_Delete = "sp_ContactInfo_Delete_mst";
    private const string Sp_Country_Delete = "sp_Country_Delete_mst";
    private const string Sp_Holiday_Delete = "sp_Holiday_Delete_mst";
    private const string Sp_Cab_Delete = "Sp_Cab_Delete_mst";
    private const string Sp_Customer_Delete = "Sp_Customer_Delete_mst";
    private const string Sp_Impact_Delete = "sp_Impact_Delete_mst";
    private const string Sp_Mode_Delete = "sp_Mode_Delete_mst";
    private const string Sp_Priority_Delete = "sp_Priority_Delete_mst";
    private const string Sp_RoleInfo_Delete = "sp_RoleInfo_Delete_mst";
    private const string Sp_ServiceDay_Delete = "sp_ServiceDay_Delete_mst";
    private const string Sp_Servicehours_Delete = "sp_Servicehours_Delete_mst";
    private const string Sp_ServiceWindow_Delete = "sp_ServiceWindow_Delete_mst";
    private const string Sp_SLA_Delete = "sp_SLA_Delete_mst";
    private const string Sp_SLA_Priority_Delete = "sp_SLA_Priority_Delete_mst";
    private const string Sp_Status_Delete = "sp_Status_Delete_mst";
    private const string Sp_ChangeStatus_Delete = "sp_ChangeStatus_Delete_mst";
    private const string Sp_ChangeType_Delete = "Sp_ChangeType_Delete_mst";
    private const string Sp_SubCategory_Delete = "sp_SubCategory_Delete_mst";
    private const string Sp_UserLogin_Delete = "sp_UserLogin_Delete_mst";
    private const string Sp_Vendor_Delete = "sp_Vendor_Delete_mst";
    private const string Sp_UserToSiteMapping_Delete = "sp_UserToSiteMapping_Delete_mst";
    private const string Sp_State_Delete = "sp_State_Delete_mst";
    private const string Sp_Department_Delete = "sp_Department_Delete_mst";
    private const string Sp_Incident_Delete = "sp_Incident_Delete_mst";
    private const string Sp_Includeassetinchange_Delete = "sp_Includeassetinchange_Delete_mst";
    private const string Sp_IncidentStates_Delete = "sp_IncidentStates_Delete_mst";
    private const string Sp_IncidentHistory_Delete = "sp_IncidentHistory_Delete_mst";
    private const string Sp_IncidentHistoryDiff_Delete = "sp_IncidentHistoryDiff_Delete_mst";
    private const string Sp_ProblemHistoryDiff_Delete = "sp_ProblemHistoryDiff_Delete_mst";
    private const string Sp_ChangeHistoryDiff_Delete = "sp_ChangeHistoryDiff_Delete_mst";
    private const string Sp_Solution_Delete = "sp_Solution_Delete_mst";
    private const string Sp_SolutionKeyword_Delete = "sp_SolutionKeyword_Delete_mst";
    private const string Sp_SolutionCreator_Delete = "sp_SolutionCreator_Delete_mst";
    private const string Sp_RequestType_Delete = "sp_RequestType_Delete_mst";
    private const string Sp_IncidentHistory_Delete_By_incidentid = "Sp_IncidentHistory_Delete_By_incidentid";
    private const string Sp_IncidentHistoryDiff_Delete_By_historyid = "Sp_IncidentHistoryDiff_Delete_By_historyid";
    private const string Sp_IncidentResolution_Delete = "sp_IncidentResolution_Delete_mst";
    private const string Sp_IncidentLog_Delete = "sp_IncidentLog_Delete_mst";
    private const string Sp_Problem_Delete = "sp_Problem_Delete_mst";
    private const string Sp_Incident_To_Problem_Delete = "sp_Incident_To_Problem_Delete_mst";
    private const string Sp_Incident_To_Change_Delete = "Sp_Incident_To_Change_Delete";
    private const string Sp_Problem_To_Change_Delete = "Sp_Problem_To_Change_Delete";
    private const string Sp_Group_mst_Delete = "sp_Group_mst_Delete_mst";
    private const string Sp_Technician_To_Group_Delete = "sp_Technician_To_Group_Delete_mst";
    private const string Sp_Asset_Delete = "Sp_Asset_Delete_mst";
    private const string Sp_Asset_Inventory_Delete = "Sp_Asset_Inventory_Delete_mst";
    private const string Sp_Asset_LogicalDrive_Delete = "Sp_Asset_LogicalDrive_Delete_mst";
    private const string Sp_Asset_Memory_Delete = "Sp_Asset_Memory_Delete_mst";
    private const string Sp_Asset_Network_Delete = "Sp_Asset_Network_Delete_mst";
    private const string Sp_Asset_OperatingSystem_Delete = "Sp_Asset_OperatingSystem_Delete_mst";
    private const string Sp_Asset_PhysicalDrive_Delete = "Sp_Asset_PhysicalDrive_Delete_mst";
    private const string Sp_Asset_Processor_Delete = "Sp_Asset_Processor_Delete_mst";
    private const string Sp_Asset_ProductInfo_Delete = "Sp_Asset_ProductInfo_Delete_mst";
    private const string Sp_UserToAssetMapping_Delete = "Sp_UserToAssetMapping_Delete";
    private const string sp_EscalateEmail_mst_Delete = "sp_EscalateEmail_Delete_mst";
    private const string sp_EscalateLevel1_mst_Delete = "sp_EscalateLevel1_Delete_mst";
    private const string sp_EscalateLevel2_mst_Delete = "sp_EscalateLevel2_Delete_mst";
    private const string sp_EscalateLevel3_mst_Delete = "sp_EscalateLevel3_Delete_mst";
    private const string sp_CheckEmailEscalate_Delete = "sp_CheckEmailEscalate_Delete_mst";
    private const string sp_CheckLevel1Escalate_Delete = "sp_CheckLevel1Escalate_Delete";
    private const string sp_CheckLevel2Escalate_Delete = "sp_CheckLevel2Escalate_Delete";
    private const string sp_CheckLevel3Escalate_Delete = "sp_CheckLevel3Escalate_Delete";
    private const string sp_ColorScheme_Delete = "sp_ColorScheme_Delete_mst";
    private const string Sp_IncidentToAssetMapping_Delete = "Sp_IncidentToAssetMapping_Delete";
    private const string sp_IncidentDeactiveCalls_Delete = "sp_IncidentDeactiveCalls_Delete_mst";
    private const string sp_Contract_Delete = "sp_Contract_Delete_mst";
    private const string sp_ContractNotification_Delete = "sp_ContractNotification_Delete_mst";
    private const string sp_ContractToAssetMapping_Delete = "sp_ContractToAssetMapping_Delete_mst";
    private const string sp_ContractRenewed_Delete = "sp_ContractRenewed_Delete_mst";
    private const string sp_CustomerToSiteMapping_Delete = "sp_CustomerToSiteMapping_Delete_mst";
    #endregion


    #region Procedure Get All Description
    private const string Sp_Get_ChangeTask_All = "Sp_Get_ChangeTask_All";
    private const string Sp_Get_ChangeTask_All_By_Changeid = "Sp_Get_ChangeTask_All_By_Changeid_mst";
    private const string Sp_Get_Cab_All = "Sp_Get_Cab_All_mst";
    private const string Sp_Get_Customer_All = "Sp_Get_Customer_All_mst";
    private const string Sp_Get_Service_All = "Sp_Get_Service_All_mst";
    private const string Sp_Get_ServiceWindow_All = "Sp_Get_ServiceWindow_All_mst";
    private const string Sp_Get_All_By_Regionid = "Sp_Get_All_By_Regionid_mst";
    private const string Sp_Get_Holiday_All = "Sp_Get_Holiday_All_mst";
    private const string Sp_Get_CabCommittee_All = "sp_Get_CabCommittee_All_mst";
    private const string Sp_Get_Organization_All = "sp_Get_Organization_All_mst";
    private const string Sp_Get_RoleInfo_All = "sp_Get_RoleInfo_All_mst";
    private const string Sp_Get_Region_All = "sp_Get_Region_All_mst";
    private const string Sp_Get_Category_All = "sp_Get_Category_All_mst";
    private const string Sp_Get_Subcategory_All = "sp_Get_Subcategory_All_mst";
    private const string Sp_Get_Country_All = "sp_Get_Country_All_mst";
    private const string Sp_Get_Site_All = "sp_Get_Site_All_mst";
    private const string Sp_Get_UserToSiteMapping_All = "sp_Get_UserToSiteMapping_All_mst";
    private const string Sp_Get_UserLogin_All = "sp_Get_UserLogin_All_mst";
    private const string sp_Get_ContactInfo_All_mst = "sp_Get_ContactInfo_All_mst";
    private const string Sp_Get_Priority_All = "sp_Get_Priority_All_mst";
    private const string Sp_Get_State_All = "sp_Get_State_All_mst";
    private const string Sp_Get_Impact_All = "sp_Get_Impact_All_mst";
    private const string Sp_Get_Department_All = "sp_Get_Department_All_mst";
    private const string Sp_Get_Status_All = "sp_Get_Status_All_mst";
    private const string Sp_Get_ChangeStatus_All = "sp_Get_ChangeStatus_All_mst";
    private const string Sp_Get_ChangeStatus_All_By_Statusname = "Sp_Get_ChangeStatus_All_By_Statusname";
    private const string Sp_Get_ChangeType_All = "sp_Get_ChangeType_All_mst";
    private const string Sp_Get_SLA_All = "sp_Get_SLA_All_mst";
    private const string Sp_Get_SLA_All_By_Siteid = "sp_Get_SLA_All_By_Siteid_mst";
    private const string Sp_Get_Incident_All = "sp_Get_Incident_All_mst";
    private const string Sp_Get_IncidentStates_All = "sp_Get_IncidentStates_All_mst";
    private const string Sp_Get_IncidentHistory_All = "sp_Get_IncidentHistory_All_mst";
    private const string Sp_Get_IncidentHistoryDiff_All = "sp_Get_IncidentHistoryDiff_All_mst";
    private const string Sp_Get_ProblemHistoryDiff_All = "sp_Get_ProblemHistoryDiff_All_mst";
    private const string Sp_Get_ChangeHistoryDiff_All = "Sp_Get_ChangeHistoryDiff_All_mst";
    private const string Sp_Get_UserToSiteMapping_All_By_userid = "sp_Get_UserToSiteMapping_All_By_userid_mst";
    private const string Sp_Get_UserToSiteMapping_All_By_siteid = "sp_Get_UserToSiteMapping_All_By_siteid_mst";
    private const string Sp_Get_UserLogin_All_By_role_Site = "sp_Get_UserLogin_All_By_role_Site_mst";
    private const string Sp_Get_UserLogin_All_By_role = "sp_Get_UserLogin_All_By_role";
    private const string Sp_Get_Mode_All = "sp_Get_Mode_All_mst";
    private const string Sp_Get_Hub_All = "Sp_Get_Hub_All_mst";
    private const string Sp_Get_SearchSolution_All = "sp_Get_SearchSolution_All_mst";
    private const string Sp_Get_Solution_All = "sp_Get_Solution_All_mst";
    private const string Sp_Get_RequestType_All = "sp_Get_RequestType_All_mst";
    private const string Sp_Get_IncidentHistory_All_By_incidentid = "sp_Get_IncidentHistory_All_By_incidentid_mst";
    private const string Sp_Get_ProblemHistory_All_By_problemid = "sp_Get_ProblemHistory_All_By_problemid_mst";
    private const string Sp_Get_ChangeHistory_All_By_changeid = "sp_Get_ChangeHistory_All_By_changeid_mst";
    private const string Sp_Get_ProblemNotes_All_By_problemid = "sp_Get_ProblemNotes_All_By_problemid_mst";
    private const string Sp_Get_ChangeNotes_All_By_changeid = "sp_Get_ChangeNotes_All_By_changeid_mst";
    private const string Sp_Get_IncidentHistoryDiff_All_By_historyid = "sp_Get_IncidentHistoryDiff_All_By_historyid_mst";
    private const string Sp_Get_ProblemHistoryDiff_All_By_historyid = "sp_Get_ProblemHistoryDiff_All_By_historyid_mst";
    private const string Sp_Get_ChangeHistoryDiff_All_By_historyid = "sp_Get_ChangeHistoryDiff_All_By_historyid_mst";
    private const string Sp_Get_Incident_All_By_Siteid_Createdbyid = "sp_Get_Incident_All_By_Siteid_Createdbyid_mst";
    private const string Sp_Get_Problem_All_By_Createdbyid = "sp_Get_Problem_All_By_Createdbyid_mst";
    private const string Sp_Get_Asset_All_By_Serialno = "Sp_Get_Asset_All_By_Serialno_mst";
    private const string Sp_Get_Incident_All_By_Siteid_statusid = "Sp_Get_Incident_All_By_Siteid_statusid";
    private const string Sp_Get_Problem_All_By_statusid = "Sp_Get_Problem_All_By_statusid";
    private const string Sp_Get_Change_All_By_statusid = "Sp_Get_Change_All_By_statusid";
    private const string Sp_Get_Incident_All_By_Siteid_statusid_Unassigned = "Sp_Get_Incident_All_By_Siteid_statusid_Unassigned";
    private const string Sp_Get_Problem_All_By_statusid_Unassigned = "Sp_Get_Problem_All_By_statusid_Unassigned";
    private const string Sp_Get_Incident_All_By_Siteid_statusid_technicianid = "Sp_Get_Incident_All_By_Siteid_statusid_technicianid";
    private const string Sp_Get_Problem_All_By_statusid_technicianid = "Sp_Get_Problem_All_By_statusid_technicianid";
    private const string Sp_Get_Change_All_By_statusid_technicianid = "Sp_Get_Change_All_By_statusid_technicianid";
    private const string Sp_Get_Incident_All_By_Siteid_technicianid = "Sp_Get_Incident_All_By_Siteid_technicianid";
    private const string Sp_Get_Incident_All_By_Incidentid = "Sp_Get_Incident_All_By_Incidentid";
    private const string Sp_Get_IncidentResolution_All = "sp_Get_IncidentResolution_All_mst";
    private const string Sp_Get_Status_All_By_OpenStatus = "Sp_Get_Status_All_By_OpenStatus";
    private const string Sp_Get_Vendor_All = "Sp_Get_Vendor_All_mst";
    private const string Sp_Get_IncidentLog_All = "sp_Get_IncidentLog_All_mst";
    private const string Sp_Get_Incident_All_By_Siteid_Assigned = "Sp_Get_Incident_All_By_Siteid_Assigned";
    private const string Sp_Get_Problem_All_By_Assigned = "Sp_Get_Problem_All_By_Assigned";
    private const string Sp_Get_Problem_All = "sp_Get_Problem_All_mst";
    private const string Sp_Get_ConfigurableItems_All = "Sp_Get_ConfigurableItems_All_mst";
    private const string Sp_Get_Change_All = "sp_Get_Change_All_mst";
    private const string Sp_Get_Configuration_All = "Sp_Get_Configuration_All_mst";
    private const string Sp_Get_Incident_To_Problem_All = "sp_Get_Incident_To_Problem_All_mst";
    private const string Sp_Get_Incident_To_Change_All = "sp_Get_Incident_To_Change_All_mst";
    private const string Sp_Get_Problem_To_Change_All = "Sp_Get_Problem_To_Change_All_mst";
    private const string Sp_Get_Group_mst_All = "sp_Get_Group_mst_All";
    private const string Sp_Technician_To_Group_All = "sp_Technician_To_Group_All";
    private const string Sp_Problem_mst_All = "sp_Get_Problem_All_mst";
    private const string Sp_Get_Problem_All_By_Problemid = "Sp_Get_Problem_All_By_Problemid";
    private const string Sp_Get_UserEmail_All_By_userid = "Sp_Get_UserEmail_All_By_userid";
    private const string Sp_Get_ConfigurableItems_All_By_itemid = "Sp_Get_Configurableitem_By_id_mst";

    private const string Sp_Get_ChangeApprove_trans_All_By_Changeid = "Sp_Get_ChangeApprove_trans_All_By_Changeid";
    private const string Sp_Get_includeaaset_All_By_Changeid = "Sp_Get_includeasset_All_By_Changeid";
    private const string Sp_Get_ProblemToSolution_All_By_Problemid = "Sp_Get_ProblemToSolution_All_By_Problemid";
    private const string Sp_Get_CabMember_All_By_ChangeTypeid = "Sp_Get_CabMember_All_By_ChangeTypeid";
    private const string Sp_Get_Incident_To_Problem_All_By_problemid = "Sp_Get_Incident_To_Problem_All_By_problemid";
    private const string Sp_Get_Incident_To_change_All_By_changeid = "Sp_Get_Incident_To_change_All_By_changeid";
    private const string Sp_Get_Problem_To_Change_All_By_changeid = "Sp_Get_Problem_To_Change_All_By_changeid";
    private const string Sp_Get_Asset_All = "Sp_Get_Asset_All_mst";
    private const string Sp_Get_Asset_Inventory_All = "Sp_Get_Asset_Inventory_All_mst";
    private const string Sp_Get_Asset_LogicalDrive_All = "Sp_Get_Asset_LogicalDrive_All_mst";
    private const string Sp_Get_Asset_Memory_All = "Sp_Get_Asset_Memory_All_mst";
    private const string Sp_Get_Asset_Network_All = "Sp_Get_Asset_Network_All_mst";
    private const string Sp_Get_Asset_OperatingSystem_All = "Sp_Get_Asset_OperatingSystem_All_mst";
    private const string Sp_Get_Asset_PhysicalDrive_All = "Sp_Get_Asset_PhysicalDrive_All_mst";
    private const string Sp_Get_Asset_Processor_All = "Sp_Get_Asset_Processor_All_mst";
    private const string Sp_Get_Asset_ProductInfo_All = "Sp_Get_Asset_ProductInfo_All_mst";
    private const string Sp_Get_UserToAssetMapping_All = "Sp_Get_UserToAssetMapping_All";
    private const string sp_EscalateEmail_All = "sp_EscalateEmail_All_mst";
    private const string sp_EscalateLevel1_mst_All = "sp_EscalateLevel1_All_mst";
    private const string sp_EscalateLevel2_mst_All = "sp_EscalateLevel2_All_mst";
    private const string sp_EscalateLevel3_mst_All = "sp_EscalateLevel3_All_mst";
    private const string sp_CheckEmailEscalate_All = "sp_CheckEmailEscalate_All_mst";
    private const string sp_Get_EscalateLevel1_All = "sp_Get_EscalateLevel1_All";
    private const string sp_Get_EscalateLevel2_All = "sp_Get_EscalateLevel2_All";
    private const string sp_Get_EscalateLevel3_All = "sp_Get_EscalateLevel3_All";
    private const string sp_ColorScheme_All = "sp_ColorScheme_All_mst";
    private const string Sp_Get_contactinfo_By_siteid = "Sp_Get_contactinfo_By_siteid_mst";
    private const string Sp_Get_IncidentLog_All_By_incidentid = "sp_Get_IncidentLog_All_By_incidentid_mst";
    private const string Sp_Get_IncidentToAssetMapping_All = "Sp_Get_IncidentToAssetMapping_All";
    private const string Sp_Get_IncidentResolution_All_By_incidentid = "sp_Get_IncidentResolution_All_By_incidentid";
    private const string sp_ColorScheme_All_By_CallStatus = "sp_ColorScheme_All_By_CallStatus";
    private const string sp_IncidentDeactiveCalls_All = "sp_IncidentDeactiveCalls_All";
    private const string sp_Contract_All = "sp_Contract_All_mst";
    private const string sp_ContractNotification_All = "sp_ContractNotification_All_mst";
    private const string sp_ContractToAssetMapping_All = "sp_ContractToAssetMapping_All_mst";
    private const string sp_ContractRenewed_All = "sp_ContractRenewed_All_mst";
    private const string sp_CustomerToSiteMapping_All = "sp_CustomerToSiteMapping_All_mst";
    private const string Sp_Get_Asset_OperatingSystem_AllUsers = "Sp_Get_Asset_OperatingSystem_AllUsers";
    #endregion

    #region Procedure Get By Id Description
    private const string Sp_Get_Changetask_By_id = "Sp_Get_Changetask_By_id";
    private const string Sp_Get_CabCommittee_By_id = "sp_Get_CabCommittee_By_id_mst";
    private const string Sp_Get_Organization_By_id = "sp_Get_Organization_By_id_mst";
    private const string Sp_Get_Category_By_id = "sp_Get_Category_By_id_mst";
    private const string Sp_Get_Region_By_id = "sp_Get_Region_By_id_mst";
    private const string Sp_Get_Site_By_id = "sp_Get_Site_By_id_mst";
    private const string Sp_Get_Hub_BySiteid = "Sp_Get_Hub_BySiteid";
    private const string Sp_Get_Hub_BySite_Hub_id = "Sp_Get_Hub_BySite_Hub_id";
    //change done by meenakshi
    private const string sp_Get_sitename_by_id = "sp_Get_Site_mst";
    //end
    

    private const string Sp_Get_RoleInfo_By_id = "sp_Get_RoleInfo_By_id_mst";
    private const string Sp_Get_Country_By_id = "sp_Get_Country_By_id_mst";
    private const string Sp_Get_ServiceWindow_By_id = "sp_Get_ServiceWindow_By_id_mst";
    private const string Sp_Get_ServiceWindow_By_serviceid = "Sp_Get_ServiceWindow_By_serviceid_mst";
    private const string Sp_Get_Servicehours_By_id = "sp_Get_Servicehours_By_id_mst";
    private const string Sp_Get_ServiceDay_All = "sp_Get_ServiceDay_All_By_id_mst";
    private const string Sp_Get_Department_By_id = "sp_Get_Department_By_id_mst";
    private const string Sp_Get_SLA_Priority_By_Siteid = "sp_Get_SLA_Priority_By_Siteid_mst";
    private const string Sp_Get_SLA_By_id = "sp_Get_SLA_By_id_mst";
    private const string Sp_Get_SLA_Priority_By_Slaid = "sp_Get_SLA_Priority_By_Slaid_mst";
    private const string Sp_Get_Priority_By_priorityid = "sp_Get_Priority_By_priorityid_mst";
    private const string Sp_Get_User_By_id = "sp_Get_UserLogin_By_id_mst";
    private const string Sp_Get_UserEmail_By_id = "Sp_Get_UserEmail_By_id";
    private const string Sp_Get_ContactInfo_By_id = "sp_Get_contactinfo_By_id_mst";
    private const string Sp_Get_Incident_By_id = "sp_Get_Incident_By_id_mst";
    private const string Sp_Get_Problem_By_id = "sp_Get_Problem_By_id_mst";
    private const string Sp_Get_IncludeAsset_By_changeidid = "Sp_Get_IncludeAsset_By_changeidid_mst";
    private const string Sp_Get_Incident_To_Change_By_incidentid = "Sp_Get_Incident_To_Change_By_incidentid_mst";
    private const string Sp_GetCustomerFeedback__By_incidentid = "Sp_GetCustomerFeedback__By_incidentid_mst";
    private const string Sp_Get_CMDBAsset_By_id = "Sp_Get_CMDBAsset_By_id_mst";
    private const string Sp_Get_CMDBAsset_By_Assetid = "Sp_Get_CMDBAsset_By_Assetid_mst";
    private const string Sp_Get_Change_By_id = "sp_Get_Change_By_id_mst";
    private const string Sp_Get_Configurableitem_By_id = "Sp_Get_Configurableitem_By_id_mst";
    private const string Sp_Get_ProblemToSolution_By_id = "sp_Get_ProblemToSolution_By_id_mst";
    private const string Sp_Get_ProblemAnalysis_By_id = "sp_Get_ProblemAnalysis_By_id_mst";
    private const string Sp_Get_ProblemSymptom_By_id = "sp_Get_ProblemSymptomBy_id_mst";
    private const string Sp_Get_ProblemImpact_By_id = "sp_Get_ProblemImpactBy_id_mst";
    private const string Sp_Get_ChangeBackoutPlan_By_id = "sp_Get_ChangeBackoutPlanBy_id_mst";
    private const string Sp_Get_ChangeRollOut_By_id = "sp_Get_ChangeRollOutBy_id_mst";
    private const string Sp_Get_ChangeImpact_By_id = "sp_Get_ChangeImpactBy_id_mst";
    private const string Sp_Get_ProblemRootcause_By_id = "sp_Get_ProblemRootcauseBy_id_mst";
    private const string Sp_Get_IncidentStates_By_id = "sp_Get_IncidentStates_By_id_mst";
    private const string Sp_Get_IncidentHistory_By_id = "sp_Get_IncidentHistory_By_id_mst";
    private const string Sp_Get_IncidentHistoryDiff_By_id = "sp_Get_IncidentHistoryDiff_By_id_mst";
    private const string Sp_Get_ProblemHistoryDiff_By_id = "sp_Get_ProblemHistoryDiff_By_id_mst";
    private const string Sp_Get_ChangeHistoryDiff_By_id = "sp_Get_ChangeHistoryDiff_By_id_mst";
    private const string Sp_Get_Solution_By_id = "sp_Get_Solution_By_id_mst";
    private const string Sp_Get_SolutionKeyword_By_id = "sp_Get_SolutionKeyword_By_id_mst";
    private const string Sp_Get_RequestType_By_id = "sp_Get_RequestType_By_id_mst";
    private const string Sp_Get_IncidentResolution_By_id = "sp_Get_IncidentResolution_By_id_mst";
    private const string Sp_Get_csm_CaseHistory_trans_By_id = "Sp_Get_csm_CaseHistory_trans_By_id_mst";
    private const string Sp_Get_csm_calls_By_id = "Sp_Get_csm_calls_By_id";
    private const string Sp_Get_csm_complaint_mst_By_id = "Sp_Get_csm_complaint_mst_By_id";
    private const string Sp_Get_csm_complaint_mst_By_ComplaintDate = "Sp_Get_csm_complaint_mst_By_ComplaintDate";
    private const string Sp_Get_csm_calls_By_ComplaintDate = "Sp_Get_csm_calls_By_ComplaintDate";
    private const string Sp_Get_SolutionCreator_By_id = "sp_Get_SolutionCreator_By_id_mst";
    private const string Sp_Get_Vendor_By_id = "Sp_Get_Vendor_By_id_mst";
    private const string Sp_Get_IncidentLog_By_id = "sp_Get_IncidentLog_By_id_mst";
    private const string Sp_Get_Incident_To_Problem_By_id = "sp_Get_Incident_To_Problem_By_id_mst";
    private const string Sp_Get_Incident_To_Changeid_By_id = "Sp_Get_Incident_To_Changeid_By_id";
    private const string Sp_Get_Group_mst_By_id = "sp_Get_Group_mst_By_id_mst";
    private const string Sp_Get_Technician_To_Group_By_id = "sp_Get_Technician_To_Group_By_id";
    private const string Sp_Get_Asset_By_id = "Sp_Get_Asset_By_id_mst";
    private const string Sp_Get_Asset_Inventory_By_id = "Sp_Get_Asset_Inventory_By_id_mst";
    private const string Sp_Get_Asset_LogicalDrive_By_id = "Sp_Get_Asset_LogicalDrive_By_id_mst";
    private const string Sp_Get_Asset_Memory_By_id = "Sp_Get_Asset_Memory_By_id_mst";
    private const string Sp_Get_Asset_Memory_By_Assetid = "Sp_Get_Asset_Memory_By_Assetid_mst";
    private const string Sp_Get_Asset_Network_By_id = "Sp_Get_Asset_Network_By_id_mst";
    private const string Sp_Get_Asset_OperatingSystem_By_id = "Sp_Get_Asset_OperatingSystem_By_id_mst";
    private const string Sp_Get_Asset_OperatingSystem_By_Assetid = "Sp_Get_Asset_OperatingSystem_By_Assetid_mst";
    private const string Sp_Get_Asset_PhysicalDrive_By_id = "Sp_Get_Asset_PhysicalDrive_By_id_mst";
    private const string Sp_Get_Asset_Processor_By_id = "Sp_Get_Asset_Processor_By_id_mst";
    private const string Sp_Get_Asset_Processor_By_Assetid = "Sp_Get_Asset_Processor_By_Assetid_mst";
    private const string Sp_Get_Asset_ProductInfo_By_id = "Sp_Get_Asset_ProductInfo_By_id_mst";
    private const string Sp_Get_Asset_ProductInfo_By_Assetid = "Sp_Get_Asset_ProductInfo_By_Assetid_mst";
    private const string Sp_Get_UserToAssetMapping_By_id = "Sp_Get_UserToAssetMapping_By_id";
    private const string sp_EscalateEmail_By_id = "sp_EscalateEmail_By_id_mst";
    private const string sp_EscalateLevel1_mst_By_id = "sp_EscalateLevel1_By_id_mst";
    private const string sp_EscalateLevel2_mst_By_id = "sp_EscalateLevel2_By_id_mst";
    private const string sp_EscalateLevel3_mst_By_id = "sp_EscalateLevel3_By_id_mst";
    private const string Sp_Get_AssetId_By_ComputerName_DomainName = "Sp_Get_AssetId_By_ComputerName_DomainName_mst";
    private const string sp_CheckEmailEscalate_By_id = "sp_CheckEmailEscalate_By_id_mst";
    private const string sp_Get_EscalateLevel1_By_id = "sp_Get_EscalateLevel1_By_id";
    private const string sp_Get_EscalateLevel2_By_id = "sp_Get_EscalateLevel2_By_id";
    private const string sp_Get_EscalateLevel3_By_id = "sp_Get_EscalateLevel3_By_id";
    private const string Sp_Assetdetails_By_Assetid = "Sp_Assetdetails_By_Assetid_mst";
    private const string sp_ColorScheme_By_id = "sp_ColorScheme_By_id";
    private const string Sp_Get_IncidentToAssetMapping_By_id = "Sp_Get_IncidentToAssetMapping_By_id";
    private const string sp_IncidentDeactiveCalls_By_id = "sp_IncidentDeactiveCalls_By_id";
    private const string sp_Contract_By_id = "sp_Contract_By_id";
    private const string sp_ContractNotification_By_id = "sp_ContractNotification_By_id_mst";
    private const string sp_ContractToAssetMapping_By_id = "sp_ContractToAssetMapping_By_id";
    private const string sp_ContractRenewed_By_id = "sp_ContractRenewed_By_id_mst";

    #endregion

    #region Procedure Get By Other Field
    private const string sp_ColorScheme_By_colorName = "sp_ColorScheme_By_colorName";
    private const string Sp_AssetId_By_UserId = "Sp_AssetId_By_UserId";
    private const string Sp_Get_Inventorydetails_By_AssetId_InventoryDate = "Sp_Get_Inventorydetails_By_AssetId_InventoryDate_mst";
    private const string Sp_Delete_ExistingDetails_From_AssetTables = "Sp_Delete_ExistingDetails_From_AssetTables_mst";
    private const string Sp_Get_Service_By_id = "Sp_Get_Service_By_id_mst";
    private const string sp_Get_Serviceid_By_Servicename = "sp_Get_Serviceid_By_Servicename_mst";
    private const string sp_Get_Holiday_All_By_SiteId = "sp_Get_Holiday_All_By_SiteId_mst";
    private const string Sp_Get_Status_By_id = "sp_Get_Status_By_id_mst";
    private const string Sp_Get_Mode_By_id = "sp_Get_Mode_By_id_mst";
    private const string Sp_Get_State_By_id = "Sp_Get_State_By_id_mst";
    private const string Sp_Get_Subcategory_By_id = "sp_Get_Subcategory_By_id_mst";
    private const string Sp_Get_UserId_By_UserName = "sp_Get_UserId_By_UserName_mst";
    private const string Sp_Update_CityCompany_By_UserName = "Sp_Update_CityCompany_By_UserName";
    private const string Sp_Get_Organization = "sp_Get_Organization_mst";
    private const string Sp_Get_Region_By_RegionName = "sp_Get_RegionName_By_Region_mst";
    private const string Sp_Get_RoleInfo_By_RoleName = "sp_Get_RoleInfo_By_RoleName_mst";
    private const string Sp_Get_Category_By_CategoryName = "sp_Get_CategoryName_By_Category_mst";
    private const string Sp_Get_UserLogin_By_UserName = "sp_Get_UserLogin_By_UserName_mst";
    private const string Sp_Get_Subcategory_By_SubcategoryName = "sp_Get_SubcategoryName_By_Subcategory_mst";
    private const string Sp_Get_SiteId_By_SiteName = "sp_Get_SiteId_By_Site_mst";
    private const string Sp_Get_Country_By_CountryName = "sp_Get_CountryName_By_Country_mst";
    private const string Sp_Get_Site_All_By_RegionId = "sp_Get_Site_All_By_RegionId_mst";
    private const string Sp_Get_ServiceWindow_All_By_RegionId = "Sp_Get_ServiceWindow_All_By_RegionId_mst";
    private const string Sp_Get_Priority_By_PriorityName = "sp_Get_PriorityName_By_Priority_mst";
    private const string Sp_Get_UserLogin_By_UserName_Like = "sp_Get_UserLogin_By_UserName_Like_mst";
    private const string sp_Get_UserLogin_By_UserName_mst_Ex = "sp_Get_UserLogin_By_UserName_mst_Ex";


    private const string Sp_Get_UserId_By_SiteId = "sp_Get_UserId_By_SiteId_mst";
    private const string Sp_Get_StateId_By_Statename = "sp_Get_StateId_By_Statename_mst";
    private const string Sp_Get_Impact_By_ImpactName = "sp_Get_Impact_By_Impact_mst";
    private const string Sp_Get_deptid_By_DepartmentName = "sp_Get_deptid_By_Department_mst";
    private const string Sp_Get_Department_All_By_Site_Id = "sp_Get_Department_All_By_SiteId_mst";
    private const string Sp_Get_Status_By_StatusName = "sp_Get_StatusName_By_Status_mst";
    private const string Sp_Get_ChangeStatus_By_StatusName = "sp_Get_ChangeStatusName_By_ChangeStatus_mst";
    private const string Sp_Get_ChangeType_mst_Get_By_ChangeTypeName = "Sp_Get_ChangeType_mst_Get_By_ChangeTypeName_mst";
    private const string Sp_Get_SLA_By_SLAName = "sp_Get_SLA_By_SLAName_mst";
    private const string Sp_Get_User_By_Commandname = "sp_Get_Userinfo_By_commandname_mst";
    private const string Sp_Get_RoleInfo = "sp_Get_RoleInfo_mst";
    private const string Sp_Get_SolutionId = "sp_Get_SolutionId";
    private const string Sp_Get_SLAid = "sp_Get_SLAid_mst";
    private const string Sp_Get_Current_Incidentid = "sp_Get_Current_Incidentid_mst";
    private const string Sp_Get_Current_CMDBAssetid = "Sp_Get_Current_CMDBAssetid_mst";
    private const string Sp_Get_Current_Problemid = "sp_Get_Current_Problemid_mst";
    private const string Sp_Get_Current_Changeid = "sp_Get_Current_Changeid_mst";
    private const string Sp_Get_Subcategory_All_By_Categoryid = "sp_Get_Subcategory_All_By_Categoryid_mst";
    private const string Sp_Get_Title_mst_By_Categoryid = "Sp_Get_Title_mst_By_Categoryid11";
    private const string Sp_Get_TimeSpentonRequest = "sp_CalculateSLA";
    private const string Sp_Get_Current_IncidentHistoryid = "sp_Get_Current_IncidentHistoryid_mst";
    private const string Sp_Get_Current_ProblemHistoryid = "sp_Get_Current_ProblemHistoryid_mst";
    private const string Sp_Get_Current_ChangeHistoryid = "sp_Get_Current_ChangeHistoryid_mst";
    private const string Sp_Get_Current_Assetid = "Sp_Get_Current_Assetid_mst";
    private const string Sp_Get_Incident_All_For_ProcessEmailEscalate = "Sp_Get_Incident_All_For_ProcessEmailEscalate";
    private const string sp_EscalateLevel1_mst_By_slaid = "sp_EscalateLevel1_mst_By_slaid";
    private const string sp_EscalateLevel2_mst_By_slaid = "sp_EscalateLevel2_mst_By_slaid";
    private const string sp_EscalateLevel3_mst_By_slaid = "sp_EscalateLevel3_mst_By_slaid";
    private const string Sp_Get_Asset_By_Commandname = "Sp_Get_Asset_By_Commandname_mst";
    private const string Sp_Get_contactinfo_By_Commandname = "Sp_Get_contactinfo_By_Commandname";
    private const string Sp_Get_NotAssignAsset_By_Commandname = "Sp_Get_NotAssignAsset_By_Commandname_mst";
    private const string Sp_AssetId_By_IncidentId = "Sp_AssetId_By_IncidentId";
    private const string sp_Get_TopIncidentId = "sp_Get_TopIncidentId_mst";
    private const string sp_Get_Asset_By_Computername = "sp_Get_Asset_By_Computername_mst";
    private const string sp_ContractToAssetMapping_By_Assetid = "sp_ContractToAssetMapping_By_Assetid";
    private const string Sp_Get_ChangeStatus_By_id = "Sp_Get_ChangeStatus_By_id_mst";
    private const string Sp_Get_ChangeType_By_ChangeTypeid = "Sp_Get_ChangeType_By_ChangeTypeid_mst";
    private const string sp_Contract_mst_By_name = "sp_Contract_mst_By_name";
    private const string sp_Get_TopContractId = "sp_Get_TopContractId";
    private const string sp_ContractToAssetMapping_All_By_Contractid = "sp_ContractToAssetMapping_All_By_Contractid";
    private const string sp_Get_ContractActive = "sp_Get_ContractActive";
    private const string sp_ContractToAssetMapping_Delete_By_Contractid_Assetid = "sp_ContractToAssetMapping_Delete_By_Contractid_Assetid";
    private const string sp_ContractToAssetMapping_Get_By_Contractid_Assetid = "sp_ContractToAssetMapping_Get_By_Contractid_Assetid";
    private const string sp_EscalateEmail_By_emailid = "sp_EscalateEmail_By_emailid";
    private const string sp_Contract_All_Escalate_Notification = "sp_Contract_All_Escalate_Notification";
    private const string sp_Get_Notification_Time = "sp_Get_Notification_Time";
    private const string Sp_Get_Incident_All_By_SearchParameter = "Sp_Get_Incident_All_By_SearchParameter";
    private const string Sp_Get_Solution_All_Filterid = "Sp_Get_Solution_All_Filterid";
    private const string Sp_Get_Problem_All_By_SearchParameter = "Sp_Get_Problem_All_By_SearchParameter";

    private const string Sp_CustomerToSiteMapping_mst_All_By_CustId = "Sp_CustomerToSiteMapping_mst_All_By_CustId";
    private const string Sp_CustomerToSiteMapping_mst_All_By_siteid = "Sp_CustomerToSiteMapping_mst_All_By_siteid";
    private const string Sp_Get_CustId_By_SiteId = "Sp_Get_CustId_By_SiteId";
    private const string sp_Get_TopCustomerId = "sp_Get_TopCustomerId";
    private const string sp_Get_TopSiteId = "sp_Get_TopSiteId";
    private const string Sp_Get_Incident_All_By_Siteid_Userid = "Sp_Get_Incident_All_By_Siteid_Userid";

    /// <summary>
    /// added by vishal 18-05-2012
    /// </summary>
    private const string Sp_username_mst_All_By_usernamelike = "Sp_username_mst_All_By_usernamelike";

    #endregion

    #region Public Insert Function

    public int Insert_CustomerToSiteMapping_mst(CustomerToSiteMapping objCustomerToSiteMapping)
    {
        return (int)ExecuteNonQuery(sp_CustomerToSiteMapping_Insert, new object[] { objCustomerToSiteMapping.Siteid, objCustomerToSiteMapping.Custid });
    }

    public int Insert_ChangeTask_mst(ChangeTask_mst ObjChangeTask)
    {
        return (int)ExecuteNonQuery(Sp_ChangeTask_Insert, new object[] { ObjChangeTask.Changeid, ObjChangeTask.Title, ObjChangeTask.Description, ObjChangeTask.Scheduledstarttime, ObjChangeTask.Scheduledendtime, ObjChangeTask.Actualstarttime, ObjChangeTask.Actualendtime, ObjChangeTask.Comment, ObjChangeTask.Ownerid, ObjChangeTask.Taskstatusid });
    }

    public int Insert_ContractRenewed(ContractRenewed objContractRenewed)
    {
        return (int)ExecuteNonQuery(sp_ContractRenewed_Insert, new object[] { objContractRenewed.Renewedcontractid, objContractRenewed.Contractid });
    }

    public int Insert_ContractToAssetMapping(ContractToAssetMapping objContractToAssetMapping)
    {
        return (int)ExecuteNonQuery(sp_ContractToAssetMapping_Insert, new object[] { objContractToAssetMapping.Contractid, objContractToAssetMapping.Assetid });
    }
    public int Insert_ContractNotification(ContractNotification objContractNotification)
    {
        return (int)ExecuteNonQuery(sp_ContractNotification_Insert, new object[] { objContractNotification.Sentto, objContractNotification.Sendnotification, objContractNotification.Contractid, objContractNotification.Beforedays });
    }

    public int Insert_Contract_mst(Contract_mst objContract_mst)
    {
        return (int)ExecuteNonQuery(sp_Contract_Insert, new object[] { objContract_mst.Vendorid, objContract_mst.Description, objContract_mst.Contractname, objContract_mst.Activeto, objContract_mst.Activefrom });
    }

    public int Insert_IncidentDeactiveCalls(IncidentDeactiveCalls objIncidentDeactiveCalls)
    {
        return (int)ExecuteNonQuery(sp_IncidentDeactiveCalls_Insert, new object[] { objIncidentDeactiveCalls.Title, objIncidentDeactiveCalls.Timespentonreq, objIncidentDeactiveCalls.Technicianid, objIncidentDeactiveCalls.Statusid, objIncidentDeactiveCalls.Slaid, objIncidentDeactiveCalls.Siteid, objIncidentDeactiveCalls.Requesterid, objIncidentDeactiveCalls.Priorityid, objIncidentDeactiveCalls.Modeid, objIncidentDeactiveCalls.Incidentid, objIncidentDeactiveCalls.Description, objIncidentDeactiveCalls.Deptid, objIncidentDeactiveCalls.Deletedtime, objIncidentDeactiveCalls.Deletedby, objIncidentDeactiveCalls.Createdbyid, objIncidentDeactiveCalls.Createdatetime, objIncidentDeactiveCalls.Completedtime });
    }

    public int Insert_ColorScheme_mst(ColorScheme_mst objColorScheme_mst)
    {
        return (int)ExecuteNonQuery(sp_ColorScheme_Insert, new object[] { objColorScheme_mst.Percnt, objColorScheme_mst.Colorname, objColorScheme_mst.Percnt_to, objColorScheme_mst.CallStatus });
    }

    public int Insert_CheckLevel1Escalate(CheckLevel1Escalate objCheckLevel1Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel1Escalate_Insert, new object[] { objCheckLevel1Escalate.Level1escalate, objCheckLevel1Escalate.Incidentid });
    }

    public int Insert_CheckLevel2Escalate(CheckLevel2Escalate objCheckLevel2Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel2Escalate_Insert, new object[] { objCheckLevel2Escalate.Level2escalate, objCheckLevel2Escalate.Incidentid });
    }

    public int Insert_CheckLevel3Escalate(CheckLevel3Escalate objCheckLevel3Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel3Escalate_Insert, new object[] { objCheckLevel3Escalate.Level3escalate, objCheckLevel3Escalate.Incidentid });
    }

    public int Insert_CheckEmailEscalate(CheckEmailEscalate objCheckEmailEscalate)
    {
        return (int)ExecuteNonQuery(sp_CheckEmailEscalate_Insert, new object[] { objCheckEmailEscalate.Level3escalate, objCheckEmailEscalate.Level2escalate, objCheckEmailEscalate.Level1escalate, objCheckEmailEscalate.Incidentid });
    }

    public int Insert_EscalateLevel1(EscalateLevel1 objEscalateLevel1)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel1_mst_Insert, new object[] { objEscalateLevel1.Slaid, objEscalateLevel1.Min, objEscalateLevel1.Hours, objEscalateLevel1.Emailid, objEscalateLevel1.Days, objEscalateLevel1.Before, objEscalateLevel1.After });
    }
    public int Insert_EscalateLevel2(EscalateLevel2 objEscalateLevel2)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel2_mst_Insert, new object[] { objEscalateLevel2.Slaid, objEscalateLevel2.Min, objEscalateLevel2.Hours, objEscalateLevel2.Emailid, objEscalateLevel2.Days, objEscalateLevel2.Before, objEscalateLevel2.After });
    }
    public int Insert_EscalateLevel3(EscalateLevel3 objEscalateLevel3)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel3_mst_Insert, new object[] { objEscalateLevel3.Slaid, objEscalateLevel3.Min, objEscalateLevel3.Hours, objEscalateLevel3.Emailid, objEscalateLevel3.Days, objEscalateLevel3.Before, objEscalateLevel3.After });
    }

    public int Insert_EscalateEmail_mst(EscalateEmail_mst objEscalateEmail_mst)
    {
        return (int)ExecuteNonQuery(sp_EscalateEmail_mst_Insert, new object[] { objEscalateEmail_mst.Email });
    }

    public int Insert_ProblemHistory_mst(ProblemHistory ObjProblemHistory)
    {
        return (int)ExecuteNonQuery(Sp_ProblemHistory_Insert, new object[] { ObjProblemHistory.Operationtime, ObjProblemHistory.Problemid, ObjProblemHistory.Operationownerid, ObjProblemHistory.Operation, ObjProblemHistory.Description });
    }
    public int Insert_ChangeHistory_mst(ChangeHistory ObjChangeHistory)
    {
        return (int)ExecuteNonQuery(Sp_ChangeHistory_Insert, new object[] { ObjChangeHistory.Operationtime, ObjChangeHistory.Changeid, ObjChangeHistory.Operationownerid, ObjChangeHistory.Operation, ObjChangeHistory.Description });
    }
    public int Insert_ProblemNotes_mst(ProblemNotes ObjProblemNotes)
    {
        return (int)ExecuteNonQuery(Sp_ProblemNotes_Insert, new object[] { ObjProblemNotes.Problemid, ObjProblemNotes.Comments, ObjProblemNotes.UserName });
    }
    public int Insert_ChangeNotes_mst(ChangeNotes ObjChangeNotes)
    {
        return (int)ExecuteNonQuery(Sp_ChangeNotes_Insert, new object[] { ObjChangeNotes.Changeid, ObjChangeNotes.Comments, ObjChangeNotes.Username });
    }
    public int Insert_ConfigurableItems_mst(ConfigurableItems_mst ObjCMDB)
    {
        return (int)ExecuteNonQuery(Sp_ConfigurableItems_Insert, new object[] { ObjCMDB.Itemid, ObjCMDB.Param1, ObjCMDB.Param2, ObjCMDB.Param3, ObjCMDB.Param4, ObjCMDB.Param5, ObjCMDB.Param6, ObjCMDB.Param7, ObjCMDB.Param8, ObjCMDB.Param9, ObjCMDB.Param10, ObjCMDB.Param11, ObjCMDB.Param12, ObjCMDB.Param13, ObjCMDB.Param14, ObjCMDB.Param15 });
    }
    public int Insert_CMDBTrans_mst(CMDB_trans ObjCMDBTrans)
    {
        return (int)ExecuteNonQuery(Sp_CMDBTrans_Insert, new object[] { ObjCMDBTrans.Assetid, ObjCMDBTrans.Parametername, ObjCMDBTrans.Previousvalue, ObjCMDBTrans.Currentvalue });
    }
    public int Insert_CMDB_mst(CMDB ObjCMDB)
    {
        return (int)ExecuteNonQuery(Sp_CMDB_Insert, new object[] { ObjCMDB.Assetid, ObjCMDB.Param1, ObjCMDB.Param2, ObjCMDB.Param3, ObjCMDB.Param4, ObjCMDB.Param5, ObjCMDB.Param6, ObjCMDB.Param7, ObjCMDB.Param8, ObjCMDB.Param9, ObjCMDB.Param10, ObjCMDB.Param11, ObjCMDB.Param12, ObjCMDB.Param13, ObjCMDB.Param14, ObjCMDB.Param15 });
    }
    public int Insert_CustomerFeedback_mst(CustomerFeedback ObjCustomerFeedback)
    {
        return (int)ExecuteNonQuery(Sp_CustomerFeedback_Insert, new object[] { ObjCustomerFeedback.Id, ObjCustomerFeedback.Feedback });
    }
    public int Insert_Configuration_mst(Configuration_mst ObjConfigurationmst)
    {
        return (int)ExecuteNonQuery(Sp_Configuration_Insert, new object[] { ObjConfigurationmst.Itemid, ObjConfigurationmst.Purchasedate, ObjConfigurationmst.Serialno, ObjConfigurationmst.Severity, ObjConfigurationmst.Siteid, ObjConfigurationmst.Vendorid, });
    }
    public int Insert_ProblemToSlotion_mst(ProblemToSolution ObjProblemtoSolotion)
    {
        return (int)ExecuteNonQuery(Sp_ProblemToSolution_Insert, new object[] { ObjProblemtoSolotion.Problemid, ObjProblemtoSolotion.Solutionid, ObjProblemtoSolotion.Solutiontype });
    }
    public int Insert_ProblemAnalysis_mst(ProblemAnalysis ObjProblemAnalysis)
    {
        return (int)ExecuteNonQuery(Sp_ProblemAnalysis_Insert, new object[] { ObjProblemAnalysis.Problemid, ObjProblemAnalysis.Impact, ObjProblemAnalysis.RootCause, ObjProblemAnalysis.Symtom });
    }
    public int Insert_ProblemSymptom_mst(ProblemSymptom ObjProblemSymptom)
    {
        return (int)ExecuteNonQuery(Sp_ProblemSymptom_Insert, new object[] { ObjProblemSymptom.Problemid, ObjProblemSymptom.Description });
    }
    public int Insert_ProblemRootcause_mst(ProblemRootcause ObjProblemRootcause)
    {
        return (int)ExecuteNonQuery(Sp_ProblemRootcause_Insert, new object[] { ObjProblemRootcause.Problemid, ObjProblemRootcause.Description });
    }
    public int Insert_ProblemImpact_mst(ProblemImpact ObjProblemImpact)
    {
        return (int)ExecuteNonQuery(Sp_ProblemImpact_Insert, new object[] { ObjProblemImpact.Problemid, ObjProblemImpact.Description });
    }
    public int Insert_ChangeBackoutPlan_mst(ChangeBackoutPlan ObjChangeBackoutPlan)
    {
        return (int)ExecuteNonQuery(Sp_ChangeBackoutPlan_Insert, new object[] { ObjChangeBackoutPlan.Changeid, ObjChangeBackoutPlan.Descripion });
    }
    public int Insert_ChangeRollOut_mst(ChangeRollOut ObjChangeRollOut)
    {
        return (int)ExecuteNonQuery(Sp_ChangeRollOut_Insert, new object[] { ObjChangeRollOut.Changeid, ObjChangeRollOut.Description });
    }
    public int Insert_ChangeImpact_mst(ChangeImpact ObjChangeImpact)
    {
        return (int)ExecuteNonQuery(Sp_ChangeImpact_Insert, new object[] { ObjChangeImpact.Changeid, ObjChangeImpact.Description });
    }
    public int Insert_Technician_To_Group(Technician_To_Group objTechnician_To_Group)
    {
        return (int)ExecuteNonQuery(Sp_Technician_To_Group_Insert, new object[] { objTechnician_To_Group.Technicianid, objTechnician_To_Group.Groupid });
    }

    public int Insert_Group_mst(Group_mst objGroup_mst)
    {
        return (int)ExecuteNonQuery(Sp_Group_mst_Insert, new object[] { objGroup_mst.Groupname, objGroup_mst.Description });
    }
    public int Insert_Incident_To_Problem(Incident_To_Problem objIncident_To_Problem)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Problem_Insert, new object[] { objIncident_To_Problem.Problemid, objIncident_To_Problem.Incidentid });
    }
    public int Insert_Incident_To_Change(Incident_To_Change objIncident_To_Change)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Change_Insert, new object[] { objIncident_To_Change.Changeid, objIncident_To_Change.Incidentid });
    }
    public int Insert_Problem_To_Change(Problem_To_Change ObjProblem_To_Change)
    {
        return (int)ExecuteNonQuery(Sp_Problem_To_Change_Insert, new object[] { ObjProblem_To_Change.Changeid, ObjProblem_To_Change.Problemid });
    }
    public int Insert_Problem_mst(Problem_mst ObjProblem)
    {
        return (int)ExecuteNonQuery(Sp_Problem_Insert, new object[] { ObjProblem.CreatedByid, ObjProblem.Requesterid, ObjProblem.Technicianid, ObjProblem.Categoryid, ObjProblem.Statusid, ObjProblem.Priorityid, ObjProblem.Subcategoryid, ObjProblem.title, ObjProblem.Description, ObjProblem.AssginedTime });
    }
    public int Insert_ChangeApprove_trans(ChangeApprove_trans ObjChangeApprovetrans)
    {
        return (int)ExecuteNonQuery(Sp_ChangeApprove_trans_Insert, new object[] { ObjChangeApprovetrans.Changeid, ObjChangeApprovetrans.ApproverName, ObjChangeApprovetrans.Approvestatus, ObjChangeApprovetrans.Approvalcomment });
    }
    public int Insert_Change_mst(Change_mst ObjChange)
    {
        return (int)ExecuteNonQuery(Sp_Change_Insert, new object[] { ObjChange.Categoryid, ObjChange.Subcategoryid, ObjChange.Statusid, ObjChange.Technician, ObjChange.Priority, ObjChange.Changetype, ObjChange.Impact, ObjChange.Requestedby, ObjChange.Approvalstatus, ObjChange.Assignetime, ObjChange.Title, ObjChange.Description, ObjChange.CreatedByID ,ObjChange.servicename});
    }
    public int Insert_Title_mst(Title_mst Objtitle)
    {
        return (int)ExecuteNonQuery(Sp_Title_Insert, new object[] { Objtitle.Categoryid, Objtitle.Subacetgoryid, Objtitle.Title });
    }

    public int Insert_IncludeassetChange_mst(IncludedAssetinchange objincludeassetinchange)
    {
        return (int)ExecuteNonQuery(Sp_IncludeassetChange_Insert, new object[] { objincludeassetinchange.Changeid, objincludeassetinchange.Assetid });
    }

    public int Insert_IncidentLog(IncidentLog objIncidentLog)
    {
        return (int)ExecuteNonQuery(Sp_IncidentLog_Insert, new object[] { objIncidentLog.Incidentlog, objIncidentLog.Incidentid, objIncidentLog.Userid });
    }

    public int Insert_IncidentResolution(IncidentResolution objIncidentResolution)
    {
        return (int)ExecuteNonQuery(Sp_IncidentResolution_Insert, new object[] { objIncidentResolution.Resolution, objIncidentResolution.Lastupdatetime, objIncidentResolution.Incidentid, objIncidentResolution.Userid });
    }

    public int Insert_RequestType_mst(RequestType_mst objRequestType)
    {
        return (int)ExecuteNonQuery(Sp_RequestType_Insert, new object[] { objRequestType.Requesttypename, objRequestType.Description });
    }

    public int Insert_SolutionCreator_mst(SolutionCreator objSolutionCreator)
    {
        return (int)ExecuteNonQuery(Sp_SolutionCreator_Insert, new object[] { objSolutionCreator.Solutionid, objSolutionCreator.Createdby });
    }
    public int Insert_SolutionKeyword_mst(SolutionKeyword objSolutionKeyword)
    {
        return (int)ExecuteNonQuery(Sp_SolutionKeyword_Insert, new object[] { objSolutionKeyword.Solutionid, objSolutionKeyword.Keywords });
    }

    public int Insert_Solution_mst(Solution_mst objSolution)
    {
        return (int)ExecuteNonQuery(Sp_Solution_Insert, new object[] { objSolution.Title, objSolution.Content, objSolution.Topicid, objSolution.Solution, objSolution.Comments, objSolution.SolutionStatus });
    }

    public int Insert_Department_mst(Department_mst objDepartment)
    {
        return (int)ExecuteNonQuery(Sp_Department_Insert, new object[] { objDepartment.Siteid, objDepartment.Deptid, objDepartment.Departmentname, objDepartment.Description, });
    }

    public int Insert_State_mst(State_mst objState)
    {
        return (int)ExecuteNonQuery(Sp_State_Insert, new object[] { objState.Statename, objState.Countryid });
    }

    public int Insert_UserToSiteMapping_mst(UserToSiteMapping objUserToSiteMapping)
    {
        return (int)ExecuteNonQuery(Sp_UserToSiteMapping_Insert, new object[] { objUserToSiteMapping.Userid, objUserToSiteMapping.Siteid });
    }

    public int Insert_Organization_mst(Organization_mst objOrganization)
    {
        return (int)ExecuteNonQuery(Sp_Organization_Insert, new object[] { objOrganization.Orgname, objOrganization.Orgid, objOrganization.Description, objOrganization.Createdatetime });
    }

    public int Insert_Region_mst(Region_mst objRegion)
    {
        return (int)ExecuteNonQuery(Sp_Region_Insert, new object[] { objRegion.Regionname, objRegion.Regionid, objRegion.Orgid, objRegion.Description, objRegion.Createdatetime });
    }

    public int Insert_Site_mst(Site_mst objSite)
    {
        return (int)ExecuteNonQuery(Sp_Site_Insert, new object[] { objSite.Website, objSite.Timezoneid, objSite.State, objSite.Sitename, objSite.Siteid, objSite.Regionid, objSite.Postalcode, objSite.Phoneno, objSite.Mobileno, objSite.Faxno, objSite.Enable, objSite.Emailid, objSite.Description, objSite.Createdatetime, objSite.Countryid, objSite.Contactpersonname, objSite.City, objSite.Address });
    }

    public int Insert_Country_mst(Country_mst objCountry)
    {
        return (int)ExecuteNonQuery(Sp_Country_Insert, new object[] { objCountry.Countryname, objCountry.Countryid });
    }


    public int Insert_Holiday_mst(Holiday_mst objHoliday)
    {
        return (int)ExecuteNonQuery(Sp_Holiday_Insert, new object[] { objHoliday.Siteid, objHoliday.Holidayid, objHoliday.Holidaydate, objHoliday.Description });
    }

    public int Insert_Cab_mst(Cab_mst objCab)
    {
        return (int)ExecuteNonQuery(Sp_Cab_Insert, new object[] { objCab.Membername, objCab.Changetypeid, objCab.Date, objCab.Emailid, objCab.Phone });
    }

    public int Insert_Customer_mst(Customer_mst objCust)
    {
        return (int)ExecuteNonQuery(Sp_Customer_Insert, new object[] { objCust.Customer_name, objCust.Address, objCust.Emailid, objCust.Contact_no, objCust.Contact_person });
    }

    public int Insert_Mode_mst(Mode_mst objMode)
    {
        return (int)ExecuteNonQuery(Sp_Mode_Insert, new object[] { objMode.Modename, objMode.Modeid, objMode.Description });
    }
    //add hub lalit
    public int Insert_Hub_mst(Hub_mst objHub)
    {
        return (int)ExecuteNonQuery(Sp_Hub_Insert, new object[] { objHub.Hubname, objHub.Hubid, objHub.Description });
    }
    //end

    public int Insert_Impact_mst(Impact_mst objImpact)
    {
        return (int)ExecuteNonQuery(Sp_Impact_Insert, new object[] { objImpact.Impactname, objImpact.Description });
    }

    public int Insert_Category_mst(Category_mst objCategory)
    {
        return (int)ExecuteNonQuery(Sp_Category_Insert, new object[] { objCategory.Categoryid, objCategory.CategoryName, objCategory.Categorydescription });
    }

    public int Insert_Asset_mst(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Insert, new object[] { objAsset.Domain, objAsset.Createdatetime, objAsset.Computername, objAsset.TagNo, objAsset.PONo, objAsset.IsInStock });
    }

    public int Insert1_Asset_mst(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Insert1, new object[] { objAsset.Domain, objAsset.Createdatetime, objAsset.Computername, objAsset.TagNo, objAsset.PONo, objAsset.AssetOwner, objAsset.location, objAsset.IsInStock, objAsset.CompanyCode, objAsset.PurchaseDate, objAsset.AssetCategory, objAsset.Remarks });
    }

    public int Insert_Asset_Inventory_mst(Asset_Inventory_mst objinventoryAsset)
    {
        return (int)ExecuteNonQuery(sp_Asset_Inventory_Insert, new object[] { objinventoryAsset.Assetid, objinventoryAsset.Inventorydate, objinventoryAsset.Computername });
    }

    public int Insert1_Asset_Inventory_mst(Asset_Inventory_mst objinventoryAsset)
    {
        return (int)ExecuteNonQuery(sp_Asset_Inventory_Insert1, new object[] { objinventoryAsset.Assetid, objinventoryAsset.Inventorydate, objinventoryAsset.Computername });
    }


    public int Insert_Asset_LogicalDrive_mst(Asset_LogicalDrive_mst objAssetlogicaldrive)
    {
        return (int)ExecuteNonQuery(sp_Asset_LogicalDrive_Insert, new object[] { objAssetlogicaldrive.Assetlogicaldriveid, objAssetlogicaldrive.Assetid, objAssetlogicaldrive.Drive_letter, objAssetlogicaldrive.Drive_type, objAssetlogicaldrive.File_system_name, objAssetlogicaldrive.Free_bytes, objAssetlogicaldrive.Inventory_date, objAssetlogicaldrive.Total_bytes });
    }

    public int Insert1_Asset_LogicalDrive_mst(Asset_LogicalDrive_mst objAssetlogicaldrive)
    {
        return (int)ExecuteNonQuery(sp_Asset_LogicalDrive_Insert1, new object[] { objAssetlogicaldrive.Assetlogicaldriveid, objAssetlogicaldrive.Assetid, objAssetlogicaldrive.Drive_letter, objAssetlogicaldrive.Drive_type, objAssetlogicaldrive.File_system_name, objAssetlogicaldrive.Free_bytes, objAssetlogicaldrive.Inventory_date, objAssetlogicaldrive.Total_bytes });
    }

    public int Insert_Asset_Memory_mst(Asset_Memory_mst objAssetMemory)
    {
        return (int)ExecuteNonQuery(sp_Asset_Memory_Insert, new object[] { objAssetMemory.Assetmemoryid, objAssetMemory.Assetid, objAssetMemory.Inventory_date, objAssetMemory.Page_file, objAssetMemory.Physical_mem, objAssetMemory.Virtual_mem });
    }

    public int Insert1_Asset_Memory_mst(Asset_Memory_mst objAssetMemory)
    {
        return (int)ExecuteNonQuery(sp_Asset_Memory_Insert1, new object[] { objAssetMemory.Assetmemoryid, objAssetMemory.Assetid, objAssetMemory.Inventory_date, objAssetMemory.Page_file, objAssetMemory.Physical_mem, objAssetMemory.Virtual_mem });
    }


    public int Insert_Asset_Network_mst(Asset_Network_mst objAssetNetwork)
    {
        return (int)ExecuteNonQuery(sp_Asset_Network_Insert, new object[] { objAssetNetwork.Assetnetworkid, objAssetNetwork.Adapter_name, objAssetNetwork.Assetid, objAssetNetwork.Gateway, objAssetNetwork.Inventory_date, objAssetNetwork.Ip_address, objAssetNetwork.Link_speed, objAssetNetwork.Mac_address, objAssetNetwork.Mtu, objAssetNetwork.Protocol_name, objAssetNetwork.Subnet_mask, objAssetNetwork.Type });
    }

    public int Insert1_Asset_Network_mst(Asset_Network_mst objAssetNetwork)
    {
        return (int)ExecuteNonQuery(sp_Asset_Network_Insert1, new object[] { objAssetNetwork.Assetnetworkid, objAssetNetwork.Adapter_name, objAssetNetwork.Assetid, objAssetNetwork.Gateway, objAssetNetwork.Inventory_date, objAssetNetwork.Ip_address, objAssetNetwork.Link_speed, objAssetNetwork.Mac_address, objAssetNetwork.Mtu, objAssetNetwork.Protocol_name, objAssetNetwork.Subnet_mask, objAssetNetwork.Type });
    }

    public int Insert_Asset_OperatingSystem_mst(Asset_OperatingSystem_mst objAssetOperatingSystem)
    {
        return (int)ExecuteNonQuery(sp_Asset_OperatingSystem_Insert, new object[] { objAssetOperatingSystem.Add_info, objAssetOperatingSystem.Assetid, objAssetOperatingSystem.Assetoperatingid, objAssetOperatingSystem.Build_no, objAssetOperatingSystem.Install_date, objAssetOperatingSystem.Inventory_date, objAssetOperatingSystem.Localization, objAssetOperatingSystem.Login_date, objAssetOperatingSystem.Major_version, objAssetOperatingSystem.Minor_version, objAssetOperatingSystem.Os_name, objAssetOperatingSystem.Product_key, objAssetOperatingSystem.Reg_code, objAssetOperatingSystem.Reg_org, objAssetOperatingSystem.Reg_to, objAssetOperatingSystem.User_name });
    }

    public int Insert1_Asset_OperatingSystem_mst(Asset_OperatingSystem_mst objAssetOperatingSystem)
    {
        return (int)ExecuteNonQuery(sp_Asset_OperatingSystem_Insert1, new object[] { objAssetOperatingSystem.Add_info, objAssetOperatingSystem.Assetid, objAssetOperatingSystem.Assetoperatingid, objAssetOperatingSystem.Build_no, objAssetOperatingSystem.Install_date, objAssetOperatingSystem.Inventory_date, objAssetOperatingSystem.Localization, objAssetOperatingSystem.Login_date, objAssetOperatingSystem.Major_version, objAssetOperatingSystem.Minor_version, objAssetOperatingSystem.Os_name, objAssetOperatingSystem.Product_key, objAssetOperatingSystem.Reg_code, objAssetOperatingSystem.Reg_org, objAssetOperatingSystem.Reg_to, objAssetOperatingSystem.User_name });
    }

    public int Insert_Asset_PhysicalDrive_mst(Asset_PhysicalDrive_mst objAssetPhysicalDrive)
    {
        return (int)ExecuteNonQuery(sp_Asset_PhysicalDrive_Insert, new object[] { objAssetPhysicalDrive.Assetid, objAssetPhysicalDrive.Assetphysicaldriveid, objAssetPhysicalDrive.Capacity, objAssetPhysicalDrive.Drive_name, objAssetPhysicalDrive.Inventory_date, objAssetPhysicalDrive.Manufacturer, objAssetPhysicalDrive.Product_id, objAssetPhysicalDrive.Product_version, objAssetPhysicalDrive.Serial_number });
    }

    public int Insert1_Asset_PhysicalDrive_mst(Asset_PhysicalDrive_mst objAssetPhysicalDrive)
    {
        return (int)ExecuteNonQuery(sp_Asset_PhysicalDrive_Insert1, new object[] { objAssetPhysicalDrive.Assetid, objAssetPhysicalDrive.Assetphysicaldriveid, objAssetPhysicalDrive.Capacity, objAssetPhysicalDrive.Drive_name, objAssetPhysicalDrive.Inventory_date, objAssetPhysicalDrive.Manufacturer, objAssetPhysicalDrive.Product_id, objAssetPhysicalDrive.Product_version, objAssetPhysicalDrive.Serial_number });
    }

    public int Insert_Asset_Processor_mst(Asset_Processor_mst objAssetProcessor)
    {
        return (int)ExecuteNonQuery(sp_Asset_Processor_Insert, new object[] { objAssetProcessor.Assetprocessorid, objAssetProcessor.Assetid, objAssetProcessor.Inventory_date, objAssetProcessor.Processor_name, objAssetProcessor.Manufacturer, objAssetProcessor.Speed, objAssetProcessor.Family, objAssetProcessor.Model, objAssetProcessor.Stepping, objAssetProcessor.Max_speed });
    }

    public int Insert1_Asset_Processor_mst(Asset_Processor_mst objAssetProcessor)
    {
        return (int)ExecuteNonQuery(sp_Asset_Processor_Insert1, new object[] { objAssetProcessor.Assetprocessorid, objAssetProcessor.Assetid, objAssetProcessor.Inventory_date, objAssetProcessor.Processor_name, objAssetProcessor.Manufacturer, objAssetProcessor.Speed, objAssetProcessor.Family, objAssetProcessor.Model, objAssetProcessor.Stepping, objAssetProcessor.Max_speed });
    }

    public int Insert_Asset_ProductInfo_mst(Asset_ProductInfo_mst objAssetProductInfo)
    {
        return (int)ExecuteNonQuery(sp_Asset_ProductInfo_Insert, new object[] { objAssetProductInfo.Assetproductinfoid, objAssetProductInfo.Assetid, objAssetProductInfo.Inventory_date, objAssetProductInfo.Product_name, objAssetProductInfo.Product_manufacturer, objAssetProductInfo.Serial_number, objAssetProductInfo.Uuid, objAssetProductInfo.Sku_no });
    }
    public int Insert_Asset_MUltimedia(Asset_Multimedia objAssetmultimedia)
    {
        return (int)ExecuteNonQuery(sp_multimedia_insert, new object[] { objAssetmultimedia.Computer_Name, objAssetmultimedia.Domain_Workgroup, objAssetmultimedia.Inventory_Date, objAssetmultimedia.Monitor_Name, objAssetmultimedia.Manufacturer, objAssetmultimedia.Horizontal_res, objAssetmultimedia.Vertical_res, objAssetmultimedia.Features, objAssetmultimedia.Gamma, objAssetmultimedia.Max_Horizontal_Size, objAssetmultimedia.Max_Vertical_Size, objAssetmultimedia.Type, objAssetmultimedia.Product_id, objAssetmultimedia.Serial_Number, objAssetmultimedia.Vendor_Id, objAssetmultimedia.Manufacturing_Date });
    }

    public int Insert1_Asset_ProductInfo_mst(Asset_ProductInfo_mst objAssetProductInfo)
    {
        return (int)ExecuteNonQuery(sp_Asset_ProductInfo_Insert1, new object[] { objAssetProductInfo.Assetproductinfoid, objAssetProductInfo.Assetid, objAssetProductInfo.Inventory_date, objAssetProductInfo.Product_name, objAssetProductInfo.Product_manufacturer, objAssetProductInfo.Serial_number, objAssetProductInfo.Uuid, objAssetProductInfo.Sku_no });
    }

    public int Insert_UserToAssetMapping(int userid, int assetid, string assetlocation, string companyname)
    {
        return (int)ExecuteNonQuery(sp_UserToAssetMapping_Insert, new object[] { userid, assetid, assetlocation, companyname });
    }

    public int Insert_IncidentToAssetMapping(int incidentid, int assetid)
    {
        return (int)ExecuteNonQuery(sp_IncidentToAssetMapping_Insert, new object[] { incidentid, assetid });
    }


    public int Insert_SubCategory_mst(Subcategory_mst objSubcategory)
    {
        return (int)ExecuteNonQuery(Sp_SubCategory_Insert, new object[] { objSubcategory.Subcategoryid, objSubcategory.Subcategoryname, objSubcategory.Subcategorydescription, objSubcategory.Categoryid });
    }

    public int Insert_Priority_mst(Priority_mst objPriority)
    {
        return (int)ExecuteNonQuery(Sp_Priority_Insert, new object[] { objPriority.Priorityid, objPriority.Name, objPriority.Description });
    }
    public int Insert_UserToEmail_mst(UserEmail objuseremail)
    {
        return (int)ExecuteNonQuery(Sp_UserToEmail_Insert, new object[] { objuseremail.Userid, objuseremail.Emailid });
    }
    public int Insert_FeedbackCustomer_mst(UserEmail objuseremail)
    {
        return (int)ExecuteNonQuery(Sp_FeedbackCustomer_Insert, new object[] { objuseremail.Userid, objuseremail.Emailid });
    }

    public int Insert_UserLogin_mst(UserLogin_mst objUserLogin)
    {
        return (int)ExecuteNonQuery(Sp_UserLogin_Insert, new object[] { objUserLogin.Username, objUserLogin.Userid, objUserLogin.Roleid, objUserLogin.Password, objUserLogin.Orgid, objUserLogin.Enable, objUserLogin.Createdatetime, objUserLogin.ADEnable, objUserLogin.DomainName, objUserLogin.Company, objUserLogin.City });
    }

    public int Insert_ContactInfo_mst(ContactInfo_mst objContactInfo)
    {
        return (int)ExecuteNonQuery(Sp_ContactInfo_Insert, new object[] { objContactInfo.Userid, objContactInfo.Mobile, objContactInfo.Lastname, objContactInfo.Landline, objContactInfo.Firstname, objContactInfo.Empid, objContactInfo.Emailid, objContactInfo.Description, objContactInfo.Siteid, objContactInfo.Deptid });
    }

    public int Insert_RoleInfo_mst(RoleInfo_mst objRoleInfo)
    {
        return (int)ExecuteNonQuery(Sp_RoleInfo_Insert, new object[] { objRoleInfo.Rolename, objRoleInfo.Roleid, objRoleInfo.Description });
    }



    public int Insert_SLA_mst(SLA_mst objSLA)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Insert, new object[] { objSLA.Slaname, objSLA.Slaid, objSLA.Siteid, objSLA.Enable, objSLA.Createdatetime, objSLA.Description });
    }

    public int Insert_Status_mst(Status_mst objStatus)
    {
        return (int)ExecuteNonQuery(Sp_Status_Insert, new object[] { objStatus.Statusname, objStatus.Statusid, objStatus.Description });
    }
    public int Insert_ChangeStatus_mst(ChangeStatus_mst objChangeStatus)
    {
        return (int)ExecuteNonQuery(Sp_ChangeStatus_Insert, new object[] { objChangeStatus.Statusname, objChangeStatus.Description });
    }
    public int Insert_ChangeType_mst(ChangeType_mst objChangeType)
    {
        return (int)ExecuteNonQuery(Sp_ChangeType_Insert, new object[] { objChangeType.Changetypename, objChangeType.Description });
    }
    public int Insert_Service_mst(Service_mst objService)
    {
        return (int)ExecuteNonQuery(Sp_Service_Insert, new object[] { objService.servicename, objService.Serviceid, objService.Description });
    }

    public int Insert_ServiceWindow_mst(ServiceWindow_mst objServiceWindow)
    {
        return (int)ExecuteNonQuery(Sp_ServiceWindow_Insert, new object[] { objServiceWindow.Siteid, objServiceWindow.Servicewindowid });
    }

    public int Insert_Servicehours_mst(Servicehours_mst objServicehours)
    {
        return (int)ExecuteNonQuery(Sp_Servicehours_Insert, new object[] { objServicehours.Startmin, objServicehours.Starthour, objServicehours.Servicewindowid, objServicehours.Endmin, objServicehours.Endhour });
    }

    public int Insert_ServiceDay_mst(ServiceDay_mst objServiceDay)
    {
        return (int)ExecuteNonQuery(Sp_ServiceDay_Insert, new object[] { objServiceDay.Weekday, objServiceDay.Servicewindowid, objServiceDay.Isworking });
    }

    public int Insert_Vendor_mst(Vendor_mst objVendor)
    {
        return (int)ExecuteNonQuery(Sp_Vendor_Insert, new object[] { objVendor.Vendorname, objVendor.Vendorid, objVendor.Contactperson });
    }
    public int Insert_SLA_Priority_mst(SLA_Priority_mst objSLAPriority)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Priority_Insert, new object[] { objSLAPriority.Slaid, objSLAPriority.Responsemin, objSLAPriority.Responsehours, objSLAPriority.Responsedays, objSLAPriority.Resolutionmin, objSLAPriority.Resolutionhours, objSLAPriority.Resolutiondays, objSLAPriority.Priorityid, objSLAPriority.Siteid });
    }

    public int Insert_Incident_mst(Incident_mst objIncident)
    {
        return (int)ExecuteNonQuery(Sp_Incident_Insert, new object[] { objIncident.Title, objIncident.Timespentonreq, objIncident.Slaid, objIncident.Siteid, objIncident.Requesterid, objIncident.Modeid, objIncident.Description, objIncident.Deptid, objIncident.Createdbyid, objIncident.Createdatetime, objIncident.Extension, objIncident.Completedtime, objIncident.ExternalTicketNo, objIncident.VendorId, objIncident.AMCCall ,objIncident.Reporteddatetime});
    }

    public int Insert_IncidentStates_mst(IncidentStates objIncidentStates)
    {
        return (int)ExecuteNonQuery(Sp_IncidentStates_Insert, new object[] { objIncidentStates.Technicianid, objIncidentStates.Subcategoryid, objIncidentStates.Statusid, objIncidentStates.Requesttypeid, objIncidentStates.Reqapproval, objIncidentStates.Reopened, objIncidentStates.Priorityid, objIncidentStates.Isescalated, objIncidentStates.Incidentid, objIncidentStates.Impactid, objIncidentStates.Hasattachment, objIncidentStates.Closecomments, objIncidentStates.Closeaccepted, objIncidentStates.Categoryid, objIncidentStates.AssignedTime });
    }

    public int Insert_IncidentHistory_mst(IncidentHistory objIncidentHistory)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistory_Insert, new object[] { objIncidentHistory.Operationtime, objIncidentHistory.Operationownerid, objIncidentHistory.Operation, objIncidentHistory.Incidentid, objIncidentHistory.Description });
    }

    public int Insert_IncidentHistoryDiff_mst(IncidentHistoryDiff objIncidentHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistoryDiff_Insert, new object[] { objIncidentHistoryDiff.Prev_value, objIncidentHistoryDiff.Historyid, objIncidentHistoryDiff.Current_value, objIncidentHistoryDiff.Columnname });
    }
    public int Insert_ProblemHistoryDiff_mst(ProblemHistoryDiff objProblemHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_ProblemHistoryDiff_Insert, new object[] { objProblemHistoryDiff.Prev_value, objProblemHistoryDiff.Historyid, objProblemHistoryDiff.Current_value, objProblemHistoryDiff.Columnname });
    }
    public int Insert_ChangeHistoryDiff_mst(ChangeHistoryDiff objChangeHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_ChangeHistoryDiff_Insert, new object[] { objChangeHistoryDiff.Prev_value, objChangeHistoryDiff.Historyid, objChangeHistoryDiff.Current_value, objChangeHistoryDiff.Columnname });
    }

    #endregion

    #region Public Update Function



    public int Update_ChangeTask_By_id(ChangeTask_mst ObjChangeTask)
    {
        return (int)ExecuteNonQuery(Sp_ChangeTask_Update, new object[] { ObjChangeTask.Taskid, ObjChangeTask.Title, ObjChangeTask.Description, ObjChangeTask.Scheduledstarttime, ObjChangeTask.Scheduledendtime, ObjChangeTask.Actualstarttime, ObjChangeTask.Actualendtime, ObjChangeTask.Ownerid, ObjChangeTask.Taskstatusid });
    }

    public int Update_ContractRenewed_By_id(ContractRenewed objContractRenewed)
    {
        return (int)ExecuteNonQuery(sp_ContractRenewed_Update, new object[] { objContractRenewed.Renewedcontractid, objContractRenewed.Contractid });
    }

    public int Update_ContractToAssetMapping_By_id(ContractToAssetMapping objContractToAssetMapping)
    {
        return (int)ExecuteNonQuery(sp_ContractToAssetMapping_Update, new object[] { objContractToAssetMapping.Contractid, objContractToAssetMapping.Assetid });
    }

    public int Update_ContractNotification_By_id(ContractNotification objContractNotification)
    {
        return (int)ExecuteNonQuery(sp_ContractNotification_Update, new object[] { objContractNotification.Sentto, objContractNotification.Sendnotification, objContractNotification.Contractid, objContractNotification.Beforedays });
    }

    public int Update_Contract_mst_By_id(Contract_mst objContract_mst)
    {
        return (int)ExecuteNonQuery(sp_Contract_Update, new object[] { objContract_mst.Vendorid, objContract_mst.Description, objContract_mst.Contractname, objContract_mst.Contractid, objContract_mst.Activeto, objContract_mst.Activefrom });
    }

    public int Update_IncidentDeactiveCalls_By_id(IncidentDeactiveCalls objIncidentDeactiveCalls)
    {
        return (int)ExecuteNonQuery(sp_IncidentDeactiveCalls_Update, new object[] { objIncidentDeactiveCalls.Title, objIncidentDeactiveCalls.Timespentonreq, objIncidentDeactiveCalls.Technicianid, objIncidentDeactiveCalls.Statusid, objIncidentDeactiveCalls.Slaid, objIncidentDeactiveCalls.Siteid, objIncidentDeactiveCalls.Requesterid, objIncidentDeactiveCalls.Priorityid, objIncidentDeactiveCalls.Modeid, objIncidentDeactiveCalls.Incidentid, objIncidentDeactiveCalls.Description, objIncidentDeactiveCalls.Deptid, objIncidentDeactiveCalls.Deletedtime, objIncidentDeactiveCalls.Deletedby, objIncidentDeactiveCalls.Deactiveid, objIncidentDeactiveCalls.Createdbyid, objIncidentDeactiveCalls.Createdatetime, objIncidentDeactiveCalls.Completedtime });
    }
    public int Update_ColorScheme_mst_By_id(ColorScheme_mst objColorScheme_mst)
    {
        return (int)ExecuteNonQuery(sp_ColorScheme_Update, new object[] { objColorScheme_mst.Percnt, objColorScheme_mst.Colorname, objColorScheme_mst.Colorid, objColorScheme_mst.Percnt_to, objColorScheme_mst.CallStatus });
    }

    public int Update_CheckLevel1Escalate_By_id(CheckLevel1Escalate objCheckLevel1Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel1Escalate_Update, new object[] { objCheckLevel1Escalate.Level1escalate, objCheckLevel1Escalate.Incidentid });
    }

    public int Update_CheckLevel2Escalate_By_id(CheckLevel2Escalate objCheckLevel2Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel2Escalate_Update, new object[] { objCheckLevel2Escalate.Level2escalate, objCheckLevel2Escalate.Incidentid });
    }

    public int Update_CheckLevel3Escalate_By_id(CheckLevel3Escalate objCheckLevel3Escalate)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel3Escalate_Update, new object[] { objCheckLevel3Escalate.Level3escalate, objCheckLevel3Escalate.Incidentid });
    }

    public int Update_CheckEmailEscalate_By_id(CheckEmailEscalate objCheckEmailEscalate)
    {
        return (int)ExecuteNonQuery(sp_CheckEmailEscalate_Update, new object[] { objCheckEmailEscalate.Level3escalate, objCheckEmailEscalate.Level2escalate, objCheckEmailEscalate.Level1escalate, objCheckEmailEscalate.Incidentid });
    }

    public int Update_EscalateLevel1_By_id(EscalateLevel1 objEscalateLevel1)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel1_mst_Update, new object[] { objEscalateLevel1.Slaid, objEscalateLevel1.Min, objEscalateLevel1.Level1id, objEscalateLevel1.Hours, objEscalateLevel1.Emailid, objEscalateLevel1.Days, objEscalateLevel1.Before, objEscalateLevel1.After });
    }
    public int Update_EscalateLevel2_By_id(EscalateLevel2 objEscalateLevel2)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel2_mst_Update, new object[] { objEscalateLevel2.Slaid, objEscalateLevel2.Min, objEscalateLevel2.Level2id, objEscalateLevel2.Hours, objEscalateLevel2.Emailid, objEscalateLevel2.Days, objEscalateLevel2.Before, objEscalateLevel2.After });
    }
    public int Update_EscalateLevel3_By_id(EscalateLevel3 objEscalateLevel3)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel3_mst_Update, new object[] { objEscalateLevel3.Slaid, objEscalateLevel3.Min, objEscalateLevel3.Level3id, objEscalateLevel3.Hours, objEscalateLevel3.Emailid, objEscalateLevel3.Days, objEscalateLevel3.Before, objEscalateLevel3.After });
    }

    public int Update_EscalateEmail_mst_By_id(EscalateEmail_mst objEscalateEmail_mst)
    {
        return (int)ExecuteNonQuery(sp_EscalateEmail_mst_Update, new object[] { objEscalateEmail_mst.Id, objEscalateEmail_mst.Email });
    }

    public int Update_Technician_To_Group(Technician_To_Group objTechnician_To_Group)
    {
        return (int)ExecuteNonQuery(Sp_Technician_To_Group_Update, new object[] { objTechnician_To_Group.Technicianid, objTechnician_To_Group.Groupid });
    }

    public int Update_Group_mst(Group_mst objGroup_mst)
    {
        return (int)ExecuteNonQuery(Sp_Group_mst_Update, new object[] { objGroup_mst.Groupname, objGroup_mst.Groupid, objGroup_mst.Description });
    }
    public int Update_Incident_To_Problem_By_id(Incident_To_Problem objIncident_To_Problem)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Problem_Update, new object[] { objIncident_To_Problem.Problemid, objIncident_To_Problem.Incidentid });
    }
    public int Update_Incident_To_Change_By_id(Incident_To_Change objIncident_To_Change)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Change_Update, new object[] { objIncident_To_Change.Changeid, objIncident_To_Change.Incidentid });
    }
    public int Update_Problem_To_Change_By_id(Problem_To_Change objProblem_To_Change)
    {
        return (int)ExecuteNonQuery(Sp_Problem_To_Change_Update, new object[] { objProblem_To_Change.Changeid, objProblem_To_Change.Problemid });
    }

    public int Update_Problem_By_id(Problem_mst ObjProblem)
    {
        return (int)ExecuteNonQuery(Sp_Problem_Update, new object[] { ObjProblem.Technicianid, ObjProblem.Categoryid, ObjProblem.Statusid, ObjProblem.Priorityid, ObjProblem.Subcategoryid, ObjProblem.Description, ObjProblem.ProblemId, ObjProblem.Closedatetime, ObjProblem.AssginedTime, ObjProblem.Active });
    }
    public int Update_Change_By_id(Change_mst ObjChange)
    {
        return (int)ExecuteNonQuery(Sp_Change_Update, new object[] { ObjChange.Technician, ObjChange.Statusid, ObjChange.Priority, ObjChange.Categoryid, ObjChange.Subcategoryid, ObjChange.Changetype, ObjChange.Completedtime, ObjChange.Sceduledstarttime, ObjChange.Sceduledendtime, ObjChange.Assignetime, ObjChange.Active, ObjChange.Changeid ,ObjChange.servicename});
    }
    public int Update_ProblemAnalysis_By_id(ProblemAnalysis ObjProblemAnalysis)
    {
        return (int)ExecuteNonQuery(Sp_ProblemAnalysis_Update, new object[] { ObjProblemAnalysis.Problemid, ObjProblemAnalysis.Impact, ObjProblemAnalysis.RootCause, ObjProblemAnalysis.Symtom });
    }
    public int Update_ProblemSymptom_By_id(ProblemSymptom ObjProblemSymptom)
    {
        return (int)ExecuteNonQuery(Sp_ProblemSymptom_Update, new object[] { ObjProblemSymptom.Problemid, ObjProblemSymptom.Description });
    }
    public int Update_ProblemRootcause_By_id(ProblemRootcause ObjProblemRootcause)
    {
        return (int)ExecuteNonQuery(Sp_ProblemRootcause_Update, new object[] { ObjProblemRootcause.Problemid, ObjProblemRootcause.Description });
    }
    public int Update_ProblemImpact_By_id(ProblemImpact ObjProblemImpact)
    {
        return (int)ExecuteNonQuery(Sp_ProblemImpact_Update, new object[] { ObjProblemImpact.Problemid, ObjProblemImpact.Description });
    }
    public int Update_ChangeBackoutPlan_By_id(ChangeBackoutPlan ObjChangeBackoutPlan)
    {
        return (int)ExecuteNonQuery(Sp_ChangeBackoutPlan_Update, new object[] { ObjChangeBackoutPlan.Changeid, ObjChangeBackoutPlan.Descripion });
    }
    public int Update_ChangeRollOut_By_id(ChangeRollOut ObjChangeRollOut)
    {
        return (int)ExecuteNonQuery(Sp_ChangeRollOut_Update, new object[] { ObjChangeRollOut.Changeid, ObjChangeRollOut.Description });
    }
    public int Update_ChangeImpact_By_id(ChangeImpact ObjChangeImpact)
    {
        return (int)ExecuteNonQuery(Sp_ChangeImpact_Update, new object[] { ObjChangeImpact.Changeid, ObjChangeImpact.Description });
    }
    public int Update_IncidentLog_By_id(IncidentLog objIncidentLog)
    {
        return (int)ExecuteNonQuery(Sp_IncidentLog_Update, new object[] { objIncidentLog.Incidentlog, objIncidentLog.Incidentid });
    }



    public int Update_IncidentResolution_By_id(IncidentResolution objIncidentResolution)
    {
        return (int)ExecuteNonQuery(Sp_IncidentResolution_Update, new object[] { objIncidentResolution.Resolution, objIncidentResolution.Lastupdatetime, objIncidentResolution.Incidentid });
    }
    public int Update_RequestType_mst_By_id(RequestType_mst objRequestType)
    {
        return (int)ExecuteNonQuery(Sp_RequestType_Update, new object[] { objRequestType.Requesttypename, objRequestType.Requesttypeid, objRequestType.Description });
    }

    public int Update_SolutionCreator_mst_By_id(SolutionCreator ObjSolutionCreator)
    {
        return (int)ExecuteNonQuery(Sp_SolutionCreator_Update, new object[] { ObjSolutionCreator.Solutionid, ObjSolutionCreator.LastUpdateBy });
    }
    public int Update_SolutionKeyword_mst_By_id(SolutionKeyword ObjSolutionKeyword)
    {
        return (int)ExecuteNonQuery(Sp_SolutionKeyword_Update, new object[] { ObjSolutionKeyword.Solutionid, ObjSolutionKeyword.Keywordid, ObjSolutionKeyword.Keywords });
    }
    public int Update_Solution_mst_By_id(Solution_mst ObjSolution)
    {
        return (int)ExecuteNonQuery(Sp_Solution_Update, new object[] { ObjSolution.Solutionid, ObjSolution.Title, ObjSolution.Content, ObjSolution.Topicid, ObjSolution.Solution, ObjSolution.Comments, ObjSolution.SolutionStatus });
    }
    public int Update_IncidentHistoryDiff_mst_By_id(IncidentHistoryDiff objIncidentHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistoryDiff_Update, new object[] { objIncidentHistoryDiff.Prev_value, objIncidentHistoryDiff.Historyid, objIncidentHistoryDiff.Historydiffid, objIncidentHistoryDiff.Current_value, objIncidentHistoryDiff.Columnname });
    }
    public int Update_ProblemHistoryDiff_mst_By_id(ProblemHistoryDiff objProblemHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_ProblemHistoryDiff_Update, new object[] { objProblemHistoryDiff.Prev_value, objProblemHistoryDiff.Historyid, objProblemHistoryDiff.Historydiffid, objProblemHistoryDiff.Current_value, objProblemHistoryDiff.Columnname });
    }
    public int Update_ChangeHistoryDiff_mst_By_id(ChangeHistoryDiff objChageHistoryDiff)
    {
        return (int)ExecuteNonQuery(Sp_ChangeHistoryDiff_Update, new object[] { objChageHistoryDiff.Prev_value, objChageHistoryDiff.Historyid, objChageHistoryDiff.Historydiffid, objChageHistoryDiff.Current_value, objChageHistoryDiff.Columnname });
    }

    public int Update_IncidentHistory_mst_By_id(IncidentHistory objIncidentHistory)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistory_Update, new object[] { objIncidentHistory.Operationtime, objIncidentHistory.Operationownerid, objIncidentHistory.Operation, objIncidentHistory.Incidentid, objIncidentHistory.Historyid, objIncidentHistory.Description });
    }

    public int Update_IncidentStates_mst_By_id(IncidentStates objIncidentStates)
    {
        return (int)ExecuteNonQuery(Sp_IncidentStates_Update, new object[] { objIncidentStates.Technicianid, objIncidentStates.Subcategoryid, objIncidentStates.Statusid, objIncidentStates.Requesttypeid, objIncidentStates.Reqapproval, objIncidentStates.Reopened, objIncidentStates.Priorityid, objIncidentStates.Isescalated, objIncidentStates.Incidentid, objIncidentStates.Impactid, objIncidentStates.Hasattachment, objIncidentStates.Closecomments, objIncidentStates.Closeaccepted, objIncidentStates.Categoryid, objIncidentStates.AssignedTime });
    }
    public int Update_Incident_mst_By_id(Incident_mst objIncident)
    {
        return (int)ExecuteNonQuery(Sp_Incident_Update, new object[] { objIncident.Title, objIncident.Timespentonreq, objIncident.Slaid, objIncident.Siteid, objIncident.Requesterid, objIncident.Modeid, objIncident.Incidentid, objIncident.Description, objIncident.Deptid, objIncident.Createdbyid, objIncident.Createdatetime, objIncident.Extension, objIncident.Completedtime, objIncident.ExternalTicketNo, objIncident.VendorId, objIncident.Active, objIncident.AMCCall });
    }

    public int Update_Department_mst_By_id(Department_mst objDepartment)
    {
        return (int)ExecuteNonQuery(Sp_Department_Update, new object[] { objDepartment.Siteid, objDepartment.Deptid, objDepartment.Departmentname, objDepartment.Description });
    }

    public int Update_State_mst_By_id(State_mst objState)
    {
        return (int)ExecuteNonQuery(Sp_State_Update, new object[] { objState.Statename, objState.Stateid, objState.Countryid });
    }

    public int Update_Organization_mst_By_id(Organization_mst objOrganization)
    {
        return (int)ExecuteNonQuery(Sp_Organization_Update, new object[] { objOrganization.Orgname, objOrganization.Orgid, objOrganization.Description, objOrganization.Createdatetime });
    }

    public int Update_Region_mst_By_id(Region_mst objRegion)
    {
        return (int)ExecuteNonQuery(Sp_Region_Update, new object[] { objRegion.Regionname, objRegion.Regionid, objRegion.Orgid, objRegion.Description, objRegion.Createdatetime });
    }
    public int Update_Site_mst_By_id(Site_mst objSite)
    {
        return (int)ExecuteNonQuery(Sp_Site_Update, new object[] { objSite.Website, objSite.Timezoneid, objSite.State, objSite.Sitename, objSite.Siteid, objSite.Regionid, objSite.Postalcode, objSite.Phoneno, objSite.Mobileno, objSite.Faxno, objSite.Enable, objSite.Emailid, objSite.Description, objSite.Createdatetime, objSite.Countryid, objSite.Contactpersonname, objSite.City, objSite.Address });
    }

    //update hub
    public int Update_Hub_mst_By_id(HubToSiteMapping objhubtosite)
    {
        return (int)ExecuteNonQuery(Sp_Hub_Update, new object[] { objhubtosite.Siteid, objhubtosite.Hubid });
    }
    public int Insert_Hubsite_mst(HubToSiteMapping objhubtosite)
    {
        return (int)ExecuteNonQuery(Sp_Hubsite_Insert, new object[] { objhubtosite.Hubid, objhubtosite.Siteid });
    }
    //end

    public int Update_Category_mst_By_id(Category_mst objCategory)
    {
        return (int)ExecuteNonQuery(Sp_Category_Update, new object[] { objCategory.Categoryid, objCategory.CategoryName, objCategory.Categorydescription });
    }
    public int Update_Configurable_mst_By_id(ConfigurableItems_mst ObjCMDB)
    {
        return (int)ExecuteNonQuery(Sp_Configurable_Update, new object[] { ObjCMDB.Itemid, ObjCMDB.Param1, ObjCMDB.Param2, ObjCMDB.Param3, ObjCMDB.Param4, ObjCMDB.Param5, ObjCMDB.Param6, ObjCMDB.Param7, ObjCMDB.Param8, ObjCMDB.Param9, ObjCMDB.Param10, ObjCMDB.Param11, ObjCMDB.Param12, ObjCMDB.Param13, ObjCMDB.Param14, ObjCMDB.Param15 });
    }
    public int Update_Configuration_mst_By_id(Configuration_mst ObjConfiguration)
    {
        return (int)ExecuteNonQuery(Sp_Configuration_Update, new object[] { ObjConfiguration.Assetid, ObjConfiguration.Vendorid, ObjConfiguration.Itemid, ObjConfiguration.Version, ObjConfiguration.Serialno, ObjConfiguration.Siteid, ObjConfiguration.Purchasedate, ObjConfiguration.Severity });
    }
    public int Update_CMDB_mst_By_id(CMDB ObjCMDB)
    {
        return (int)ExecuteNonQuery(Sp_CMDB_Update, new object[] { ObjCMDB.Assetid, ObjCMDB.Param1, ObjCMDB.Param2, ObjCMDB.Param3, ObjCMDB.Param4, ObjCMDB.Param5, ObjCMDB.Param6, ObjCMDB.Param7, ObjCMDB.Param8, ObjCMDB.Param9, ObjCMDB.Param10, ObjCMDB.Param11, ObjCMDB.Param12, ObjCMDB.Param13, ObjCMDB.Param14, ObjCMDB.Param15 });
    }

    public int Update_Asset_mst_By_id(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Update, new object[] { objAsset.Assetid, objAsset.Computername, objAsset.Createdatetime, objAsset.Domain, objAsset.TagNo, objAsset.PONo, objAsset.IsInStock });
    }

    public int Update_Asset_Inventory_mst_By_id(Asset_Inventory_mst objAssetInventory)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Inventory_Update, new object[] { objAssetInventory.Assetid, objAssetInventory.Computername, objAssetInventory.Inventorydate });
    }

    public int Update_Asset_LogicalDrive_mst_By_id(Asset_LogicalDrive_mst objAssetlogicaldrive)
    {
        return (int)ExecuteNonQuery(Sp_Asset_LogicalDrive_Update, new object[] { objAssetlogicaldrive.Assetlogicaldriveid, objAssetlogicaldrive.Assetid, objAssetlogicaldrive.Drive_letter, objAssetlogicaldrive.Drive_type, objAssetlogicaldrive.File_system_name, objAssetlogicaldrive.Free_bytes, objAssetlogicaldrive.Inventory_date, objAssetlogicaldrive.Total_bytes });
    }

    public int Update_Asset_Memory_mst_By_id(Asset_Memory_mst objAssetMemory)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Memory_Update, new object[] { objAssetMemory.Assetmemoryid, objAssetMemory.Assetid, objAssetMemory.Inventory_date, objAssetMemory.Page_file, objAssetMemory.Physical_mem, objAssetMemory.Virtual_mem });
    }

    public int Update_Asset_Network_mst_By_id(Asset_Network_mst objAssetNetwork)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Network_Update, new object[] { objAssetNetwork.Assetnetworkid, objAssetNetwork.Adapter_name, objAssetNetwork.Assetid, objAssetNetwork.Gateway, objAssetNetwork.Inventory_date, objAssetNetwork.Ip_address, objAssetNetwork.Link_speed, objAssetNetwork.Mac_address, objAssetNetwork.Mtu, objAssetNetwork.Protocol_name, objAssetNetwork.Subnet_mask, objAssetNetwork.Type });
    }

    public int Update_Asset_OperatingSystem_mst_By_id(Asset_OperatingSystem_mst objAssetOperatingSystem)
    {
        return (int)ExecuteNonQuery(Sp_Asset_OperatingSystem_Update, new object[] { objAssetOperatingSystem.Add_info, objAssetOperatingSystem.Assetid, objAssetOperatingSystem.Assetoperatingid, objAssetOperatingSystem.Build_no, objAssetOperatingSystem.Install_date, objAssetOperatingSystem.Inventory_date, objAssetOperatingSystem.Localization, objAssetOperatingSystem.Login_date, objAssetOperatingSystem.Major_version, objAssetOperatingSystem.Minor_version, objAssetOperatingSystem.Os_name, objAssetOperatingSystem.Product_key, objAssetOperatingSystem.Reg_code, objAssetOperatingSystem.Reg_org, objAssetOperatingSystem.Reg_to, objAssetOperatingSystem.User_name });
    }

    public int Update_Asset_PhysicalDrive_mst_By_id(Asset_PhysicalDrive_mst objAssetPhysicalDrive)
    {
        return (int)ExecuteNonQuery(Sp_Asset_PhysicalDrive_Update, new object[] { objAssetPhysicalDrive.Assetid, objAssetPhysicalDrive.Assetphysicaldriveid, objAssetPhysicalDrive.Capacity, objAssetPhysicalDrive.Drive_name, objAssetPhysicalDrive.Inventory_date, objAssetPhysicalDrive.Manufacturer, objAssetPhysicalDrive.Product_id, objAssetPhysicalDrive.Product_version, objAssetPhysicalDrive.Serial_number });
    }

    public int Update_Asset_Processor_mst_By_id(Asset_Processor_mst objAssetProcessor)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Processor_Update, new object[] { objAssetProcessor.Assetprocessorid, objAssetProcessor.Assetid, objAssetProcessor.Inventory_date, objAssetProcessor.Processor_name, objAssetProcessor.Manufacturer, objAssetProcessor.Speed, objAssetProcessor.Family, objAssetProcessor.Model, objAssetProcessor.Stepping, objAssetProcessor.Max_speed });
    }

    public int Update_Asset_ProductInfo_mst_By_id(Asset_ProductInfo_mst objAssetProductInfo)
    {
        return (int)ExecuteNonQuery(Sp_Asset_ProductInfo_Update, new object[] { objAssetProductInfo.Assetproductinfoid, objAssetProductInfo.Assetid, objAssetProductInfo.Inventory_date, objAssetProductInfo.Product_name, objAssetProductInfo.Product_manufacturer, objAssetProductInfo.Serial_number, objAssetProductInfo.Uuid, objAssetProductInfo.Sku_no });
    }

    public int Update_UserToAssetMapping_By_id(UserToAssetMapping objUserToAssetMapping)
    {
        return (int)ExecuteNonQuery(Sp_UserToAssetMapping_Update, new object[] { objUserToAssetMapping.Userid, objUserToAssetMapping.Assetid });
    }

    public int Update_IncidentToAssetMapping_By_id(IncidentToAssetMapping objIncidentToAssetMapping)
    {
        return (int)ExecuteNonQuery(Sp_IncidentToAssetMapping_Update, new object[] { objIncidentToAssetMapping.incidentid, objIncidentToAssetMapping.Assetid });
    }

    public int Update_ContactInfo_mst_By_id(ContactInfo_mst objContactInfo)
    {
        return (int)ExecuteNonQuery(Sp_ContactInfo_Update, new object[] { objContactInfo.Userid, objContactInfo.Mobile, objContactInfo.Lastname, objContactInfo.Landline, objContactInfo.Firstname, objContactInfo.Empid, objContactInfo.Emailid, objContactInfo.Description, objContactInfo.Siteid, objContactInfo.Deptid });
    }
    public int Update_Country_mst_By_id(Country_mst objCountry)
    {
        return (int)ExecuteNonQuery(Sp_Country_Update, new object[] { objCountry.Countryname, objCountry.Countryid });
    }
    public int Update_Holiday_mst_By_id(Holiday_mst objHoliday)
    {
        return (int)ExecuteNonQuery(Sp_Holiday_Update, new object[] { objHoliday.Siteid, objHoliday.Holidayid, objHoliday.Holidaydate, objHoliday.Description });
    }

    public int Update_Cab_mst_By_id(Cab_mst objCab)
    {
        return (int)ExecuteNonQuery(Sp_Cab_Update, new object[] { objCab.Cabid, objCab.Membername, objCab.Changetypeid, objCab.Emailid, objCab.Phone });
    }

    public int Update_Customer_mst_By_id(Customer_mst objCust)
    {
        return (int)ExecuteNonQuery(Sp_Customer_Update, new object[] { objCust.Custid, objCust.Customer_name, objCust.Address, objCust.Emailid, objCust.Contact_no, objCust.Contact_person });
    }

    public int Update_Impact_mst_By_id(Impact_mst objImpact)
    {
        return (int)ExecuteNonQuery(Sp_Impact_Update, new object[] { objImpact.Impactname, objImpact.Impactid, objImpact.Description });
    }
    public int Update_Mode_mst_By_id(Mode_mst objMode)
    {
        return (int)ExecuteNonQuery(Sp_Mode_Update, new object[] { objMode.Modename, objMode.Modeid, objMode.Description });
    }
    public int Update_Priority_mst_By_id(Priority_mst objPriority)
    {
        return (int)ExecuteNonQuery(Sp_Priority_Update, new object[] { objPriority.Priorityid, objPriority.Name, objPriority.Description });
    }
    public int Update_RoleInfo_mst_By_id(RoleInfo_mst objRoleInfo)
    {
        return (int)ExecuteNonQuery(Sp_RoleInfo_Update, new object[] { objRoleInfo.Rolename, objRoleInfo.Roleid, objRoleInfo.Description });
    }
    public int Update_ServiceDay_mst_By_id(ServiceDay_mst objServiceDay)
    {
        return (int)ExecuteNonQuery(Sp_ServiceDay_Update, new object[] { objServiceDay.Weekday, objServiceDay.Servicewindowid, objServiceDay.Isworking });
    }

    public int Update_Servicehours_mst_By_id(Servicehours_mst objServicehours)
    {
        return (int)ExecuteNonQuery(Sp_Servicehours_Update, new object[] { objServicehours.Startmin, objServicehours.Starthour, objServicehours.Servicewindowid, objServicehours.Endmin, objServicehours.Endhour });
    }

    public int Update_ServiceWindow_mst_By_id(ServiceWindow_mst objServiceWindow)
    {
        return (int)ExecuteNonQuery(Sp_ServiceWindow_Update, new object[] { objServiceWindow.Siteid, objServiceWindow.Servicewindowid });
    }

    public int Update_SLA_mst_By_id(SLA_mst objSLA)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Update, new object[] { objSLA.Slaname, objSLA.Slaid, objSLA.Siteid, objSLA.Enable, objSLA.Createdatetime, objSLA.Description });
    }

    public int Update_SLA_Priority_mst_By_id(SLA_Priority_mst objSLAPriority)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Priority_Update, new object[] { objSLAPriority.Slaid, objSLAPriority.Responsemin, objSLAPriority.Responsehours, objSLAPriority.Responsedays, objSLAPriority.Resolutionmin, objSLAPriority.Resolutionhours, objSLAPriority.Resolutiondays, objSLAPriority.Priorityid, objSLAPriority.Siteid });
    }
    public int Update_Status_mst_By_id(Status_mst objStatus)
    {
        return (int)ExecuteNonQuery(Sp_Status_Update, new object[] { objStatus.Statusname, objStatus.Statusid, objStatus.Description });
    }
    public int Update_ChangeStatus_mst_By_id(ChangeStatus_mst objChangeStatus)
    {
        return (int)ExecuteNonQuery(Sp_ChangeStatus_Update, new object[] { objChangeStatus.Statusname, objChangeStatus.ChangeStatusid, objChangeStatus.Description });
    }
    public int Update_ChangeType_mst_By_id(ChangeType_mst objChangeType)
    {
        return (int)ExecuteNonQuery(Sp_ChangeType_Update, new object[] { objChangeType.Changetypeid, objChangeType.Changetypename, objChangeType.Description });
    }


    public int Update_Service_mst_By_id(Service_mst objService)
    {
        return (int)ExecuteNonQuery(Sp_Service_Update, new object[] { objService.servicename, objService.Serviceid, objService.Description });
    }

    public int Update_SubCategory_mst_By_id(Subcategory_mst objSubcategory)
    {
        return (int)ExecuteNonQuery(Sp_SubCategory_Update, new object[] { objSubcategory.Subcategoryid, objSubcategory.Subcategoryname, objSubcategory.Subcategorydescription, objSubcategory.Categoryid });
    }
    public int Update_UserLogin_mst_By_id(UserLogin_mst objUserLogin)
    {
        return (int)ExecuteNonQuery(Sp_UserLogin_Update, new object[] { objUserLogin.Username, objUserLogin.Userid, objUserLogin.Roleid, objUserLogin.Password, objUserLogin.Orgid, objUserLogin.Enable, objUserLogin.Createdatetime, objUserLogin.ADEnable, objUserLogin.DomainName, objUserLogin.Company, objUserLogin.City });
    }
    public int Update_UserEmail_mst_By_id(UserEmail objUserEmail)
    {
        return (int)ExecuteNonQuery(Sp_UserEmail_Update, new object[] { objUserEmail.Emailid, objUserEmail.Active, objUserEmail.Userid });
    }
    public int Update_Vendor_mst_By_id(Vendor_mst objVendor)
    {
        return (int)ExecuteNonQuery(Sp_Vendor_Update, new object[] { objVendor.Vendorname, objVendor.Vendorid, objVendor.Contactperson });
    }


    #endregion

    #region Public Delete Function

    public int Delete_CustomerToSiteMapping_mst_By_id(int CustId, int siteid)
    {
        return (int)ExecuteNonQuery(sp_CustomerToSiteMapping_Delete, new object[] { CustId, siteid });
    }

    public int Delete_ContractRenewed_By_id(int contractid)
    {
        return (int)ExecuteNonQuery(sp_ContractRenewed_Delete, new object[] { contractid });
    }


    public int Delete_ContractToAssetMapping_By_Contractid_Assetid(int contractid, int assetid)
    {
        return (int)ExecuteNonQuery(sp_ContractToAssetMapping_Delete_By_Contractid_Assetid, new object[] { contractid, assetid });
    }

    public int Delete_ContractToAssetMapping_By_id(int contractid)
    {
        return (int)ExecuteNonQuery(sp_ContractToAssetMapping_Delete, new object[] { contractid });
    }

    public int Delete_ContractNotification_By_id(int contractid)
    {
        return (int)ExecuteNonQuery(sp_ContractNotification_Delete, new object[] { contractid });
    }

    public int Delete_Contract_mst_By_id(int contractid)
    {
        return (int)ExecuteNonQuery(sp_Contract_Delete, new object[] { contractid });
    }

    public int Delete_IncidentDeactiveCalls_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(sp_IncidentDeactiveCalls_Delete, new object[] { incidentid });
    }

    public int Delete_ColorScheme_mst_By_id(int colorid)
    {
        return (int)ExecuteNonQuery(sp_ColorScheme_Delete, new object[] { colorid });
    }

    public int Delete_CheckLevel1Escalate_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel1Escalate_Delete, new object[] { incidentid });
    }

    public int Delete_CheckLevel2Escalate_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel2Escalate_Delete, new object[] { incidentid });
    }

    public int Delete_CheckLevel3Escalate_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(sp_CheckLevel3Escalate_Delete, new object[] { incidentid });
    }

    public int Delete_CheckEmailEscalate_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(sp_CheckEmailEscalate_Delete, new object[] { incidentid });
    }

    public int Delete_EscalateLevel1_By_id(int level1id)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel1_mst_Delete, new object[] { level1id });
    }
    public int Delete_EscalateLevel2_By_id(int level2id)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel2_mst_Delete, new object[] { level2id });
    }
    public int Delete_EscalateLevel3_By_id(int level3id)
    {
        return (int)ExecuteNonQuery(sp_EscalateLevel3_mst_Delete, new object[] { level3id });
    }

    public int Delete_EscalateEmail_mst_By_id(int id)
    {
        return (int)ExecuteNonQuery(sp_EscalateEmail_mst_Delete, new object[] { id });
    }

    public int Delete_Technician_To_Group(int technicianid)
    {
        return (int)ExecuteNonQuery(Sp_Technician_To_Group_Delete, new object[] { technicianid });
    }

    public int Delete_Group_mst(int groupid)
    {
        return (int)ExecuteNonQuery(Sp_Group_mst_Delete, new object[] { groupid });
    }

    public int Delete_Incident_To_Problem_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Problem_Delete, new object[] { incidentid });
    }
    public int Delete_Incident_To_Change_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_Incident_To_Change_Delete, new object[] { incidentid });
    }
    public int Delete_Problem_To_Change_By_id(int problemid)
    {
        return (int)ExecuteNonQuery(Sp_Problem_To_Change_Delete, new object[] { problemid });
    }
    public int Delete_Problem_By_id(int Problemid)
    {
        return (int)ExecuteNonQuery(Sp_Problem_Delete, new object[] { Problemid });
    }
    public int Delete_IncidentLog_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentLog_Delete, new object[] { incidentid });
    }

    public int Delete_IncidentResolution_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentResolution_Delete, new object[] { incidentid });
    }

    public int Delete_RequestType_mst_By_id(int requesttypeid)
    {
        return (int)ExecuteNonQuery(Sp_RequestType_Delete, new object[] { requesttypeid });
    }
    public int Delete_SolutionCreator_mst_By_id(int Solutionid)
    {
        return (int)ExecuteNonQuery(Sp_SolutionCreator_Delete, new object[] { Solutionid });
    }
    public int Delete_SolutionKeyword_mst_By_id(int Solutionid)
    {
        return (int)ExecuteNonQuery(Sp_SolutionKeyword_Delete, new object[] { Solutionid });
    }
    public int Delete_Solution_mst_By_id(int solutionid)
    {
        return (int)ExecuteNonQuery(Sp_Solution_Delete, new object[] { solutionid });
    }

    public int Delete_IncidentHistoryDiff_mst_By_historyid(int historyid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistoryDiff_Delete_By_historyid, new object[] { historyid });
    }


    public int Delete_IncidentHistoryDiff_mst_By_id(int historydiffid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistoryDiff_Delete, new object[] { historydiffid });
    }
    public int Delete_ProblemHistoryDiff_mst_By_id(int historydiffid)
    {
        return (int)ExecuteNonQuery(Sp_ProblemHistoryDiff_Delete, new object[] { historydiffid });
    }
    public int Delete_ChangeHistoryDiff_mst_By_id(int historydiffid)
    {
        return (int)ExecuteNonQuery(Sp_ChangeHistoryDiff_Delete, new object[] { historydiffid });
    }

    public int Delete_IncidentHistory_mst_By_id(int historyid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistory_Delete, new object[] { historyid });
    }


    public int Delete_IncidentHistory_mst_By_incidentid(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentHistory_Delete_By_incidentid, new object[] { incidentid });
    }

    public int Delete_IncidentStates_mst_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentStates_Delete, new object[] { incidentid });
    }

    public int Delete_Incident_mst_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_Incident_Delete, new object[] { incidentid });
    }
    public int Delete_Includeassetinchange_mst_By_id(int changeid)
    {
        return (int)ExecuteNonQuery(Sp_Includeassetinchange_Delete, new object[] { changeid });
    }
    public int Delete_Department_mst_By_id(int deptid)
    {
        return (int)ExecuteNonQuery(Sp_Department_Delete, new object[] { deptid });
    }

    public int Delete_State_mst_By_id(int stateid)
    {
        return (int)ExecuteNonQuery(Sp_State_Delete, new object[] { stateid });
    }

    public int Delete_UserToSiteMapping_mst_By_id(int userid, int siteid)
    {
        return (int)ExecuteNonQuery(Sp_UserToSiteMapping_Delete, new object[] { userid, siteid });
    }

    public int Delete_Organization_mst_By_id(int orgid)
    {
        return (int)ExecuteNonQuery(Sp_Organization_Delete, new object[] { orgid });
    }

    public int Delete_Region_mst_By_id(int regionid)
    {
        return (int)ExecuteNonQuery(Sp_Region_Delete, new object[] { regionid });
    }
    public int Delete_Site_mst_By_id(int siteid)
    {
        return (int)ExecuteNonQuery(Sp_Site_Delete, new object[] { siteid });
    }

    public int Delete_CabCommittee_mst_By_id(int cabid)
    {
        return (int)ExecuteNonQuery(Sp_CabCommittee_Delete, new object[] { cabid });
    }

    public int Delete_CabMember_mst_By_id(int userid)
    {
        return (int)ExecuteNonQuery(Sp_CabMember_Delete, new object[] { userid });
    }
    public int Delete_Category_mst_By_id(int categoryid)
    {
        return (int)ExecuteNonQuery(Sp_Category_Delete, new object[] { categoryid });
    }

    public int Delete_Asset_mst_By_id(int assetid)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Delete, new object[] { assetid });
    }

    public int Delete_Asset_Inventory_mst_By_id(int assetid)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Inventory_Delete, new object[] { assetid });
    }

    public int Delete_Asset_LogicalDrive_mst_By_id(int assetLogicalDriveId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_LogicalDrive_Delete, new object[] { assetLogicalDriveId });
    }

    public int Delete_Asset_Memory_mst_By_id(int assetMemoryId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Memory_Delete, new object[] { assetMemoryId });
    }

    public int Delete_Asset_Network_mst_By_id(int assetNetworkId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Network_Delete, new object[] { assetNetworkId });
    }

    public int Delete_Asset_OperatingSystem_mst_By_id(int assetOperatingSystemId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_OperatingSystem_Delete, new object[] { assetOperatingSystemId });
    }

    public int Delete_Asset_PhysicalDrive_mst_By_id(int assetPhysicalDriveId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_PhysicalDrive_Delete, new object[] { assetPhysicalDriveId });
    }

    public int Delete_Asset_Processor_mst_By_id(int assetProcessorId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Processor_Delete, new object[] { assetProcessorId });
    }

    public int Delete_Asset_ProductInfo_mst_By_id(int assetProductInfoId)
    {
        return (int)ExecuteNonQuery(Sp_Asset_ProductInfo_Delete, new object[] { assetProductInfoId });
    }

    public int Delete_UserToAssetMapping_By_id(int assetId)
    {
        return (int)ExecuteNonQuery(Sp_UserToAssetMapping_Delete, new object[] { assetId });
    }

    public int Delete_IncidentToAssetMapping_By_id(int incidentid)
    {
        return (int)ExecuteNonQuery(Sp_IncidentToAssetMapping_Delete, new object[] { incidentid });
    }

    public int Delete_ContactInfo_mst_By_id(int userid)
    {
        return (int)ExecuteNonQuery(Sp_ContactInfo_Delete, new object[] { userid });
    }
    public int Delete_Country_mst_By_id(int countryid)
    {
        return (int)ExecuteNonQuery(Sp_Country_Delete, new object[] { countryid });
    }
    public int Delete_Holiday_mst_By_id(int holidayid)
    {
        return (int)ExecuteNonQuery(Sp_Holiday_Delete, new object[] { holidayid });
    }

    public int Delete_Cab_mst_By_id(int cabid)
    {
        return (int)ExecuteNonQuery(Sp_Cab_Delete, new object[] { cabid });
    }

    public int Delete_Customer_mst_By_id(int custid)
    {
        return (int)ExecuteNonQuery(Sp_Customer_Delete, new object[] { custid });
    }

    public int Delete_Impact_mst_By_id(int impactid)
    {
        return (int)ExecuteNonQuery(Sp_Impact_Delete, new object[] { impactid });
    }
    public int Delete_Mode_mst_By_id(int modeid)
    {
        return (int)ExecuteNonQuery(Sp_Mode_Delete, new object[] { modeid });
    }
    public int Delete_Priority_mst_By_id(int priorityid)
    {
        return (int)ExecuteNonQuery(Sp_Priority_Delete, new object[] { priorityid });
    }
    public int Delete_RoleInfo_mst_By_id(int roleid)
    {
        return (int)ExecuteNonQuery(Sp_RoleInfo_Delete, new object[] { roleid });
    }
    public int Delete_ServiceDay_mst_By_id(int servicewindowid)
    {
        return (int)ExecuteNonQuery(Sp_ServiceDay_Delete, new object[] { servicewindowid });
    }

    public int Delete_Servicehours_mst_By_id(int servicewindowid)
    {
        return (int)ExecuteNonQuery(Sp_Servicehours_Delete, new object[] { servicewindowid });
    }

    public int Delete_ServiceWindow_mst_By_id(int servicewindowid)
    {
        return (int)ExecuteNonQuery(Sp_ServiceWindow_Delete, new object[] { servicewindowid });
    }

    public int Delete_SLA_mst_By_id(int slaid)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Delete, new object[] { slaid });
    }

    public int Delete_SLA_Priority_mst_By_id(int slaid)
    {
        return (int)ExecuteNonQuery(Sp_SLA_Priority_Delete, new object[] { slaid });
    }
    public int Delete_Status_mst_By_id(int statusid)
    {
        return (int)ExecuteNonQuery(Sp_Status_Delete, new object[] { statusid });
    }
    public int Delete_ChangeStatus_mst_By_id(int Changestatusid)
    {
        return (int)ExecuteNonQuery(Sp_ChangeStatus_Delete, new object[] { Changestatusid });
    }
    public int Delete_ChangeType_mst_By_id(int Changetypeid)
    {
        return (int)ExecuteNonQuery(Sp_ChangeType_Delete, new object[] { Changetypeid });
    }

    public int Delete_Service_mst_By_id(int serviceid)
    {
        return (int)ExecuteNonQuery(Sp_Service_Delete, new object[] { serviceid });
    }

    public int Delete_SubCategory_mst_By_id(int subcategoryid)
    {
        return (int)ExecuteNonQuery(Sp_SubCategory_Delete, new object[] { subcategoryid });
    }
    public int Delete_UserLogin_mst_By_id(int userid)
    {
        return (int)ExecuteNonQuery(Sp_UserLogin_Delete, new object[] { userid });
    }
    public int Delete_Vendor_mst_By_id(int vendorid)
    {
        return (int)ExecuteNonQuery(Sp_Vendor_Delete, new object[] { vendorid });
    }

    #endregion

    #region Public Function Get All()

    public BLLCollection<CustomerToSiteMapping> Get_CustomerToSiteMapping_mst_All_By_siteid(int siteid)
    {
        return (BLLCollection<CustomerToSiteMapping>)ExecuteReader(Sp_CustomerToSiteMapping_mst_All_By_siteid, new object[] { siteid }, new GenerateCollectionFromReader(GenerateCustomerToSiteMapping_mstCollection));
    }

    public BLLCollection<CustomerToSiteMapping> Get_CustomerToSiteMapping_mst_All_By_CustId(int CustId)
    {
        return (BLLCollection<CustomerToSiteMapping>)ExecuteReader(Sp_CustomerToSiteMapping_mst_All_By_CustId, new object[] { CustId }, new GenerateCollectionFromReader(GenerateCustomerToSiteMapping_mstCollection));
    }

    public BLLCollection<CustomerToSiteMapping> Get_CustomerToSiteMapping_mst_All()
    {
        return (BLLCollection<CustomerToSiteMapping>)ExecuteReader(sp_CustomerToSiteMapping_All, new object[] { }, new GenerateCollectionFromReader(GenerateCustomerToSiteMapping_mstCollection));
    }


    public CollectionBase GenerateCustomerToSiteMapping_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<CustomerToSiteMapping> col = new BLLCollection<CustomerToSiteMapping>();
        while (returnData.Read())
        {


            CustomerToSiteMapping obj = new CustomerToSiteMapping();
            obj.Custid = (int)returnData["Custid"];
            obj.Siteid = (int)returnData["Siteid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<ChangeTask_mst> Get_ChangeTask_mst_All_By_Changeid(int Changeid)
    {
        return (BLLCollection<ChangeTask_mst>)ExecuteReader(Sp_Get_ChangeTask_All_By_Changeid, new object[] { Changeid }, new GenerateCollectionFromReader(GenerateChangeTask_mstCollection));
    }
    public BLLCollection<ChangeTask_mst> Get_ChangeTask_All()
    {
        return (BLLCollection<ChangeTask_mst>)ExecuteReader(Sp_Get_ChangeTask_All, new object[] { }, new GenerateCollectionFromReader(GenerateChangeTask_mstCollection));
    }
    public CollectionBase GenerateChangeTask_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeTask_mst> col = new BLLCollection<ChangeTask_mst>();
        while (returnData.Read())
        {


            ChangeTask_mst obj = new ChangeTask_mst();
            obj.Taskid = (int)returnData["Taskid"];
            obj.Changeid = (int)returnData["Changeid"];
            obj.Taskstatusid = (int)returnData["Taskstatusid"];
            obj.Ownerid = (int)returnData["Ownerid"];
            obj.Title = (string)returnData["Title"];






            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }



            if (returnData["Comment"] != DBNull.Value)
            {
                obj.Comment = (string)returnData["Comment"];
            }
            if (returnData["Scheduledstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Scheduledstarttime"];
                obj.Scheduledstarttime = Mydatetime.ToString();
            }
            if (returnData["Scheduledendtime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Scheduledendtime"];
                obj.Scheduledendtime = Mydatetime1.ToString();

            }

            if (returnData["Actualstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["Actualstarttime"];
                obj.Actualstarttime = Mydatetime3.ToString();
            }
            if (returnData["Actualendtime"] != DBNull.Value)
            {
                DateTime Mydatetime4 = new DateTime();
                Mydatetime4 = (DateTime)returnData["Actualendtime"];
                obj.Actualendtime = Mydatetime4.ToString();
            }



            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ContractRenewed> Get_ContractRenewed_All()
    {
        return (BLLCollection<ContractRenewed>)ExecuteReader(sp_ContractRenewed_All, new object[] { }, new GenerateCollectionFromReader(GenerateContractRenewedCollection));
    }

    public CollectionBase GenerateContractRenewedCollection(ref IDataReader returnData)
    {
        BLLCollection<ContractRenewed> col = new BLLCollection<ContractRenewed>();
        while (returnData.Read())
        {

            ContractRenewed obj = new ContractRenewed();
            obj.Contractid = (int)returnData["Contractid"];
            obj.Renewedcontractid = (int)returnData["Renewedcontractid"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Reneweddate"];
            obj.Reneweddate = Mydatetime.ToString();
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<ContractToAssetMapping> Get_ContractToAssetMapping_All_By_contractid(int contractid)
    {
        return (BLLCollection<ContractToAssetMapping>)ExecuteReader(sp_ContractToAssetMapping_All_By_Contractid, new object[] { contractid }, new GenerateCollectionFromReader(GenerateContractToAssetMappingCollection));
    }

    public BLLCollection<ContractToAssetMapping> Get_ContractToAssetMapping_All()
    {
        return (BLLCollection<ContractToAssetMapping>)ExecuteReader(sp_ContractToAssetMapping_All, new object[] { }, new GenerateCollectionFromReader(GenerateContractToAssetMappingCollection));
    }

    public CollectionBase GenerateContractToAssetMappingCollection(ref IDataReader returnData)
    {
        BLLCollection<ContractToAssetMapping> col = new BLLCollection<ContractToAssetMapping>();
        while (returnData.Read())
        {


            ContractToAssetMapping obj = new ContractToAssetMapping();
            obj.Contractid = (int)returnData["Contractid"];
            obj.Assetid = (int)returnData["Assetid"];



            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ContractNotification> Get_ContractNotification_All()
    {
        return (BLLCollection<ContractNotification>)ExecuteReader(sp_ContractNotification_All, new object[] { }, new GenerateCollectionFromReader(GenerateContractNotificationCollection));
    }

    public CollectionBase GenerateContractNotificationCollection(ref IDataReader returnData)
    {
        BLLCollection<ContractNotification> col = new BLLCollection<ContractNotification>();
        while (returnData.Read())
        {


            ContractNotification obj = new ContractNotification();
            obj.Contractid = (int)returnData["Contractid"];
            obj.Beforedays = (int)returnData["Beforedays"];
            obj.Sentto = (string)returnData["Sentto"];
            obj.Sendnotification = (bool)returnData["Sendnotification"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Contract_mst> Get_Contract_mst_All_Escalate_Notification()
    {
        return (BLLCollection<Contract_mst>)ExecuteReader(sp_Contract_All_Escalate_Notification, new object[] { }, new GenerateCollectionFromReader(GenerateContract_mstCollection));
    }

    public BLLCollection<Contract_mst> Get_Contract_mst_All()
    {
        return (BLLCollection<Contract_mst>)ExecuteReader(sp_Contract_All, new object[] { }, new GenerateCollectionFromReader(GenerateContract_mstCollection));
    }

    public CollectionBase GenerateContract_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Contract_mst> col = new BLLCollection<Contract_mst>();
        while (returnData.Read())
        {


            Contract_mst obj = new Contract_mst();
            obj.Contractid = (int)returnData["Contractid"];
            obj.Contractname = (string)returnData["Contractname"];
            obj.Vendorid = (int)returnData["Vendorid"];
            obj.Description = (string)returnData["Description"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Activefrom"];
            obj.Activefrom = Mydatetime.ToString();
            DateTime Mydatetime1 = new DateTime();
            Mydatetime1 = (DateTime)returnData["Activeto"];
            obj.Activeto = Mydatetime1.ToString();
            DateTime Mydatetime2 = new DateTime();
            Mydatetime2 = (DateTime)returnData["CreateDateTime"];
            obj.CreateDateTime = Mydatetime2.ToString();


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<ColorScheme_mst> Get_ColorScheme_mst_All_By_CallStatus(string callStatus)
    {
        return (BLLCollection<ColorScheme_mst>)ExecuteReader(sp_ColorScheme_All_By_CallStatus, new object[] { callStatus }, new GenerateCollectionFromReader(GenerateColorScheme_mstCollection));
    }

    public BLLCollection<ColorScheme_mst> Get_ColorScheme_mst_All()
    {
        return (BLLCollection<ColorScheme_mst>)ExecuteReader(sp_ColorScheme_All, new object[] { }, new GenerateCollectionFromReader(GenerateColorScheme_mstCollection));
    }

    public CollectionBase GenerateColorScheme_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ColorScheme_mst> col = new BLLCollection<ColorScheme_mst>();
        while (returnData.Read())
        {


            ColorScheme_mst obj = new ColorScheme_mst();
            obj.Colorid = (int)returnData["Colorid"];
            obj.Percnt = (int)returnData["Percnt"];
            obj.Percnt_to = (int)returnData["Percnt_to"];
            obj.Colorname = (string)returnData["Colorname"];
            obj.CallStatus = (string)returnData["CallStatus"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<CheckLevel3Escalate> Get_CheckLevel3Escalate_All()
    {
        return (BLLCollection<CheckLevel3Escalate>)ExecuteReader(sp_Get_EscalateLevel3_All, new object[] { }, new GenerateCollectionFromReader(GenerateCheckLevel3EscalateCollection));
    }

    public CollectionBase GenerateCheckLevel3EscalateCollection(ref IDataReader returnData)
    {
        BLLCollection<CheckLevel3Escalate> col = new BLLCollection<CheckLevel3Escalate>();
        while (returnData.Read())
        {


            CheckLevel3Escalate obj = new CheckLevel3Escalate();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level3escalate = (bool)returnData["Level3escalate"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<CheckLevel2Escalate> Get_CheckLevel2Escalate_All()
    {
        return (BLLCollection<CheckLevel2Escalate>)ExecuteReader(sp_Get_EscalateLevel2_All, new object[] { }, new GenerateCollectionFromReader(GenerateCheckLevel2EscalateCollection));
    }

    public CollectionBase GenerateCheckLevel2EscalateCollection(ref IDataReader returnData)
    {
        BLLCollection<CheckLevel2Escalate> col = new BLLCollection<CheckLevel2Escalate>();
        while (returnData.Read())
        {


            CheckLevel2Escalate obj = new CheckLevel2Escalate();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level2escalate = (bool)returnData["Level2escalate"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<CheckLevel1Escalate> Get_CheckLevel1Escalate_All()
    {
        return (BLLCollection<CheckLevel1Escalate>)ExecuteReader(sp_Get_EscalateLevel1_All, new object[] { }, new GenerateCollectionFromReader(GenerateCheckLevel1EscalateCollection));
    }

    public CollectionBase GenerateCheckLevel1EscalateCollection(ref IDataReader returnData)
    {
        BLLCollection<CheckLevel1Escalate> col = new BLLCollection<CheckLevel1Escalate>();
        while (returnData.Read())
        {


            CheckLevel1Escalate obj = new CheckLevel1Escalate();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level1escalate = (bool)returnData["Level1escalate"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<CheckEmailEscalate> Get_CheckEmailEscalate_All()
    {
        return (BLLCollection<CheckEmailEscalate>)ExecuteReader(sp_CheckEmailEscalate_All, new object[] { }, new GenerateCollectionFromReader(GenerateCheckEmailEscalateCollection));
    }

    public CollectionBase GenerateCheckEmailEscalateCollection(ref IDataReader returnData)
    {
        BLLCollection<CheckEmailEscalate> col = new BLLCollection<CheckEmailEscalate>();
        while (returnData.Read())
        {


            CheckEmailEscalate obj = new CheckEmailEscalate();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level1escalate = (bool)returnData["Level1escalate"];
            obj.Level2escalate = (bool)returnData["Level2escalate"];
            obj.Level3escalate = (bool)returnData["Level3escalate"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<EscalateLevel1> Get_EscalateLevel1_All()
    {
        return (BLLCollection<EscalateLevel1>)ExecuteReader(sp_EscalateLevel1_mst_All, new object[] { }, new GenerateCollectionFromReader(GenerateEscalateLevel1Collection));
    }

    public CollectionBase GenerateEscalateLevel1Collection(ref IDataReader returnData)
    {
        BLLCollection<EscalateLevel1> col = new BLLCollection<EscalateLevel1>();
        while (returnData.Read())
        {


            EscalateLevel1 obj = new EscalateLevel1();
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level1id = (int)returnData["Level1id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<EscalateLevel2> Get_EscalateLevel2_All()
    {
        return (BLLCollection<EscalateLevel2>)ExecuteReader(sp_EscalateLevel2_mst_All, new object[] { }, new GenerateCollectionFromReader(GenerateEscalateLevel2Collection));
    }

    public CollectionBase GenerateEscalateLevel2Collection(ref IDataReader returnData)
    {
        BLLCollection<EscalateLevel2> col = new BLLCollection<EscalateLevel2>();
        while (returnData.Read())
        {


            EscalateLevel2 obj = new EscalateLevel2();
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level2id = (int)returnData["Level2id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<EscalateLevel3> Get_EscalateLevel3_All()
    {
        return (BLLCollection<EscalateLevel3>)ExecuteReader(sp_EscalateLevel3_mst_All, new object[] { }, new GenerateCollectionFromReader(GenerateEscalateLevel3Collection));
    }

    public CollectionBase GenerateEscalateLevel3Collection(ref IDataReader returnData)
    {
        BLLCollection<EscalateLevel3> col = new BLLCollection<EscalateLevel3>();
        while (returnData.Read())
        {


            EscalateLevel3 obj = new EscalateLevel3();
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level3id = (int)returnData["Level3id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<EscalateEmail_mst> Get_EscalateEmail_mst_All()
    {
        return (BLLCollection<EscalateEmail_mst>)ExecuteReader(sp_EscalateEmail_All, new object[] { }, new GenerateCollectionFromReader(GenerateEscalateEmail_mstCollection));
    }

    public CollectionBase GenerateEscalateEmail_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<EscalateEmail_mst> col = new BLLCollection<EscalateEmail_mst>();
        while (returnData.Read())
        {


            EscalateEmail_mst obj = new EscalateEmail_mst();
            obj.Id = (int)returnData["Id"];
            obj.Email = (string)returnData["Email"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Technician_To_Group> Get_Technician_To_Group_All()
    {
        return (BLLCollection<Technician_To_Group>)ExecuteReader(Sp_Technician_To_Group_All, new object[] { }, new GenerateCollectionFromReader(GenerateTechnician_To_GroupCollection));
    }

    public CollectionBase GenerateTechnician_To_GroupCollection(ref IDataReader returnData)
    {
        BLLCollection<Technician_To_Group> col = new BLLCollection<Technician_To_Group>();
        while (returnData.Read())
        {


            Technician_To_Group obj = new Technician_To_Group();
            obj.Groupid = (int)returnData["Groupid"];
            obj.Technicianid = (int)returnData["Technicianid"];



            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Group_mst> Get_Group_mst_All()
    {
        return (BLLCollection<Group_mst>)ExecuteReader(Sp_Get_Group_mst_All, new object[] { }, new GenerateCollectionFromReader(GenerateGroup_mstCollection));
    }

    public CollectionBase GenerateGroup_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Group_mst> col = new BLLCollection<Group_mst>();
        while (returnData.Read())
        {


            Group_mst obj = new Group_mst();
            obj.Groupid = (int)returnData["Groupid"];
            obj.Groupname = (string)returnData["Groupname"];
            if (returnData["Description"] != DBNull.Value)
            { obj.Description = (string)returnData["Description"]; }




            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    //
    public BLLCollection<Incident_To_Problem> Get_Incident_To_Problem_All_By_Problemid(int problemid)
    {
        return (BLLCollection<Incident_To_Problem>)ExecuteReader(Sp_Get_Incident_To_Problem_All_By_problemid, new object[] { problemid }, new GenerateCollectionFromReader(GenerateIncident_To_Problem_mstCollection));
    }

    public BLLCollection<Incident_To_Problem> Get_Incident_To_Problem_All()
    {
        return (BLLCollection<Incident_To_Problem>)ExecuteReader(Sp_Get_Incident_To_Problem_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncident_To_Problem_mstCollection));
    }

    public CollectionBase GenerateIncident_To_Problem_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Incident_To_Problem> col = new BLLCollection<Incident_To_Problem>();
        while (returnData.Read())
        {


            Incident_To_Problem obj = new Incident_To_Problem();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Problemid = (int)returnData["Problemid"];




            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Incident_To_Change> Get_Incident_To_change_All_By_changeid(int changeid)
    {
        return (BLLCollection<Incident_To_Change>)ExecuteReader(Sp_Get_Incident_To_change_All_By_changeid, new object[] { changeid }, new GenerateCollectionFromReader(GenerateIncident_To_Change_mstCollection));
    }

    public BLLCollection<Incident_To_Change> Get_Incident_To_Change_All()
    {
        return (BLLCollection<Incident_To_Change>)ExecuteReader(Sp_Get_Incident_To_Change_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncident_To_Change_mstCollection));
    }

    public CollectionBase GenerateIncident_To_Change_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Incident_To_Change> col = new BLLCollection<Incident_To_Change>();
        while (returnData.Read())
        {


            Incident_To_Change obj = new Incident_To_Change();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Changeid = (int)returnData["Changeid"];





            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Problem_To_Change> Get_Problem_To_Change_All_By_Changeid(int changeid)
    {
        return (BLLCollection<Problem_To_Change>)ExecuteReader(Sp_Get_Problem_To_Change_All_By_changeid, new object[] { changeid }, new GenerateCollectionFromReader(GenerateProblem_To_Change_mstCollection));
    }
    public BLLCollection<Problem_To_Change> Get_Problem_To_Change_All()
    {
        return (BLLCollection<Problem_To_Change>)ExecuteReader(Sp_Get_Problem_To_Change_All, new object[] { }, new GenerateCollectionFromReader(GenerateProblem_To_Change_mstCollection));
    }

    public CollectionBase GenerateProblem_To_Change_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Problem_To_Change> col = new BLLCollection<Problem_To_Change>();
        while (returnData.Read())
        {


            Problem_To_Change obj = new Problem_To_Change();
            obj.Problemid = (int)returnData["ProblemId"];
            obj.Changeid = (int)returnData["ChangeId"];




            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ConfigurableItems_mst> Get_ConfigurableItems_mst_All_By_itemid(int itemid)
    {
        return (BLLCollection<ConfigurableItems_mst>)ExecuteReader(Sp_Get_ConfigurableItems_All_By_itemid, new object[] { itemid }, new GenerateCollectionFromReader(GenerateConfigurableItems_mstCollection));
    }
    public BLLCollection<ConfigurableItems_mst> Get_ConfigurableItems_All()
    {
        return (BLLCollection<ConfigurableItems_mst>)ExecuteReader(Sp_Get_ConfigurableItems_All, new object[] { }, new GenerateCollectionFromReader(GenerateConfigurableItems_mstCollection));
    }
    public CollectionBase GenerateConfigurableItems_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ConfigurableItems_mst> col = new BLLCollection<ConfigurableItems_mst>();
        while (returnData.Read())
        {
            ConfigurableItems_mst obj = new ConfigurableItems_mst();
            obj.Itemid = (int)returnData["Itemid"];





            if (returnData["Param1"] != DBNull.Value)
            {
                obj.Param1 = (string)returnData["Param1"];
            }
            if (returnData["Param2"] != DBNull.Value)
            {
                obj.Param2 = (string)returnData["Param2"];
            }
            if (returnData["Param3"] != DBNull.Value)
            {
                obj.Param3 = (string)returnData["Param3"];
            }
            if (returnData["Param4"] != DBNull.Value)
            {
                obj.Param4 = (string)returnData["Param4"];
            }
            if (returnData["Param5"] != DBNull.Value)
            {
                obj.Param5 = (string)returnData["Param5"];
            }
            if (returnData["Param6"] != DBNull.Value)
            {
                obj.Param6 = (string)returnData["Param6"];
            }
            if (returnData["Param7"] != DBNull.Value)
            {
                obj.Param7 = (string)returnData["Param7"];
            }
            if (returnData["Param8"] != DBNull.Value)
            {
                obj.Param8 = (string)returnData["Param8"];
            }
            if (returnData["Param9"] != DBNull.Value)
            {
                obj.Param9 = (string)returnData["Param9"];
            }
            if (returnData["Param10"] != DBNull.Value)
            {
                obj.Param10 = (string)returnData["Param10"];
            }
            if (returnData["Param11"] != DBNull.Value)
            {
                obj.Param11 = (string)returnData["Param11"];
            }
            if (returnData["Param12"] != DBNull.Value)
            {
                obj.Param12 = (string)returnData["Param12"];
            }
            if (returnData["Param13"] != DBNull.Value)
            {
                obj.Param13 = (string)returnData["Param13"];
            }
            if (returnData["Param14"] != DBNull.Value)
            {
                obj.Param14 = (string)returnData["Param14"];
            }
            if (returnData["Param15"] != DBNull.Value)
            {
                obj.Param15 = (string)returnData["Param15"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;

    }

    public BLLCollection<Problem_mst> Get_Problem_All()
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All, new object[] { }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }

    public CollectionBase GenerateProblem_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Problem_mst> col = new BLLCollection<Problem_mst>();
        while (returnData.Read())
        {


            Problem_mst obj = new Problem_mst();

            obj.ProblemId = (int)returnData["ProblemId"];
            obj.CreatedByid = (int)returnData["CreatedByid"];
            obj.Requesterid = (int)returnData["Requesterid"];
            obj.Technicianid = (int)returnData["Technicianid"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.title = (string)returnData["title"];

            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }
            if (returnData["CreateDatetime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["CreateDatetime"];
                obj.CreateDatetime = Mydatetime.ToString();
            }
            if (returnData["Closedatetime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Closedatetime"];
                obj.Closedatetime = Mydatetime1.ToString();

            }
            if (returnData["CompletedTime"] != DBNull.Value)
            {
                DateTime Mydatetime2 = new DateTime();
                Mydatetime2 = (DateTime)returnData["CompletedTime"];
                obj.CompletedTime = Mydatetime2.ToString();
            }
            if (returnData["AssignedTime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["AssignedTime"];
                obj.AssginedTime = Mydatetime3.ToString();
            }




            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Configuration_mst> Get_Configuration_All()
    {
        return (BLLCollection<Configuration_mst>)ExecuteReader(Sp_Get_Configuration_All, new object[] { }, new GenerateCollectionFromReader(GenerateConfiguration_mstCollection));
    }
    public CollectionBase GenerateConfiguration_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Configuration_mst> col = new BLLCollection<Configuration_mst>();
        while (returnData.Read())
        {


            Configuration_mst obj = new Configuration_mst();
            obj.Assetid = (int)returnData["Assetid"];
            obj.Serialno = (string)returnData["Serialno"];
            obj.Itemid = (int)returnData["Itemid"];
            obj.Vendorid = (int)returnData["VendorId"];
            obj.Version = (int)returnData["Version"];
            if (returnData["Warranty"] != DBNull.Value)
            {

                obj.Warranty = (string)returnData["Warranty"];

            }

            obj.Siteid = (int)returnData["Siteid"];
            obj.Severity = (string)returnData["Severity"];

            if (returnData["PurchaseDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["PurchaseDate"];
                obj.Purchasedate = Mydatetime.ToString();

            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;


    }
    public BLLCollection<Change_mst> Get_Change_All()
    {
        return (BLLCollection<Change_mst>)ExecuteReader(Sp_Get_Change_All, new object[] { }, new GenerateCollectionFromReader(GenerateChange_mstCollection));
    }

    public CollectionBase GenerateChange_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Change_mst> col = new BLLCollection<Change_mst>();
        while (returnData.Read())
        {


            Change_mst obj = new Change_mst();
            obj.Changeid = (int)returnData["Changeid"];
            obj.Active = (bool)returnData["Active"];
            obj.Approvalstatus = (string)returnData["ApprovalStatus"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.Changetype = (int)returnData["ChangeType"];
            obj.Requestedby = (int)returnData["RequestedBy"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Technician = (int)returnData["Technician"];
            obj.Priority = (int)returnData["Priority"];
            obj.Impact = (int)returnData["Impact"];
            obj.CreatedByID = (int)returnData["CreatedBy"];



            obj.Title = (string)returnData["Title"];

            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            if (returnData["CreatedTime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["CreatedTime"];
                obj.Createdtime = Mydatetime.ToString();
            }
            if (returnData["CompletedTime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["CompletedTime"];
                obj.Completedtime = Mydatetime1.ToString();

            }

            if (returnData["Assignetime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["Assignetime"];
                obj.Assignetime = Mydatetime3.ToString();
            }
            if (returnData["Sceduledstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime4 = new DateTime();
                Mydatetime4 = (DateTime)returnData["Sceduledstarttime"];
                obj.Sceduledstarttime = Mydatetime4.ToString();
            }

            if (returnData["Sceduledendtime"] != DBNull.Value)
            {
                DateTime Mydatetime5 = new DateTime();
                Mydatetime5 = (DateTime)returnData["Sceduledendtime"];
                obj.Sceduledendtime = Mydatetime5.ToString();
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Vendor_mst> Get_Vendor_All()
    {
        return (BLLCollection<Vendor_mst>)ExecuteReader(Sp_Get_Vendor_All, new object[] { }, new GenerateCollectionFromReader(GenerateVendor_mstCollection));
    }

    public CollectionBase GenerateVendor_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Vendor_mst> col = new BLLCollection<Vendor_mst>();
        while (returnData.Read())
        {


            Vendor_mst obj = new Vendor_mst();
            obj.Vendorid = (int)returnData["vendorid"];
            obj.Vendorname = (string)returnData["vendorname"];
            obj.Contactperson = (string)returnData["contactperson"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<IncidentLog> Get_IncidentLog_All_By_incidentid(int incidentid)
    {
        return (BLLCollection<IncidentLog>)ExecuteReader(Sp_Get_IncidentLog_All_By_incidentid, new object[] { incidentid }, new GenerateCollectionFromReader(GenerateIncidentLog_mstCollection));
    }

    public BLLCollection<IncidentLog> Get_IncidentLog_All()
    {
        return (BLLCollection<IncidentLog>)ExecuteReader(Sp_Get_IncidentLog_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentLog_mstCollection));
    }

    public CollectionBase GenerateIncidentLog_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentLog> col = new BLLCollection<IncidentLog>();
        while (returnData.Read())
        {


            IncidentLog obj = new IncidentLog();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Userid = (int)returnData["Userid"];
            obj.Incidentlog = (string)returnData["Incidentlog"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["CreateDateTime"];
            obj.CreateDateTime = Mydatetime.ToString();



            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<IncidentResolution> Get_IncidentResolution_All_By_incidentid(int incidentid)
    {
        return (BLLCollection<IncidentResolution>)ExecuteReader(Sp_Get_IncidentResolution_All_By_incidentid, new object[] { incidentid }, new GenerateCollectionFromReader(GenerateIncidentResolution_mstCollection));
    }

    public BLLCollection<IncidentResolution> Get_IncidentResolution_All()
    {
        return (BLLCollection<IncidentResolution>)ExecuteReader(Sp_Get_IncidentResolution_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentResolution_mstCollection));
    }

    public CollectionBase GenerateIncidentResolution_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentResolution> col = new BLLCollection<IncidentResolution>();
        while (returnData.Read())
        {


            IncidentResolution obj = new IncidentResolution();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Userid = (int)returnData["Userid"];
            obj.Resolution = (string)returnData["Resolution"];
            if (returnData["Lastupdatetime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Lastupdatetime"];
                obj.Lastupdatetime = Mydatetime.ToString();
            }


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<RequestType_mst> Get_RequestType_mst_All()
    {
        return (BLLCollection<RequestType_mst>)ExecuteReader(Sp_Get_RequestType_All, new object[] { }, new GenerateCollectionFromReader(GenerateRequestType_mstCollection));
    }
    public CollectionBase GenerateRequestType_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<RequestType_mst> col = new BLLCollection<RequestType_mst>();
        while (returnData.Read())
        {


            RequestType_mst obj = new RequestType_mst();
            obj.Requesttypeid = (int)returnData["Requesttypeid"];
            obj.Requesttypename = (string)returnData["Requesttypename"];
            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Title_mst> Get_Title_mst_All_By_Categoryid(int categoryid, int subcategoryid)
    {
        return (BLLCollection<Title_mst>)ExecuteReader(Sp_Get_Title_mst_By_Categoryid, new object[] { categoryid, subcategoryid }, new GenerateCollectionFromReader(GenerateTitle_mstCollection));
    }


    public CollectionBase GenerateTitle_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Title_mst> col = new BLLCollection<Title_mst>();
        while (returnData.Read())
        {


            Title_mst obj = new Title_mst();
            obj.Id = (int)returnData["Id"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Title = (string)returnData["Title"];
            obj.Subacetgoryid = (int)returnData["subcategoryid"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Subcategory_mst> Get_Subcategory_mst_All_By_Categoryid(int categoryid)
    {
        return (BLLCollection<Subcategory_mst>)ExecuteReader(Sp_Get_Subcategory_All_By_Categoryid, new object[] { categoryid }, new GenerateCollectionFromReader(GenerateSubcategory_mstCollection));
    }

    public BLLCollection<Solution_mst> Get_SearchSolution_mst_All(string keywords)
    {
        return (BLLCollection<Solution_mst>)ExecuteReader(Sp_Get_SearchSolution_All, new object[] { keywords }, new GenerateCollectionFromReader(GenerateSolution_mstCollection));
    }


    public BLLCollection<Solution_mst> Get_Solution_mst_All_By_Filterid(string filterid)
    {
        return (BLLCollection<Solution_mst>)ExecuteReader(Sp_Get_Solution_All_Filterid, new object[] { filterid }, new GenerateCollectionFromReader(GenerateSolution_mstCollection));
    }

    public BLLCollection<Solution_mst> Get_Solution_mst_All()
    {
        return (BLLCollection<Solution_mst>)ExecuteReader(Sp_Get_Solution_All, new object[] { }, new GenerateCollectionFromReader(GenerateSolution_mstCollection));
    }
    public CollectionBase GenerateSolution_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Solution_mst> col = new BLLCollection<Solution_mst>();
        while (returnData.Read())
        {


            Solution_mst obj = new Solution_mst();
            if (returnData["Solutionid"] != DBNull.Value)
            {
                obj.Solutionid = (int)returnData["Solutionid"];
            }
            if (returnData["Title"] != DBNull.Value)
            {
                obj.Title = (string)returnData["Title"];
            }
            if (returnData["Content"] != DBNull.Value)
            {
                obj.Content = (string)returnData["Content"];
            }

            if (returnData["Solution"] != DBNull.Value)
            {
                obj.Solution = (string)returnData["Solution"];
            }
            if (returnData["Topicid"] != DBNull.Value)
            {
                obj.Topicid = (int)returnData["Topicid"];
            }
            if (returnData["Comments"] != DBNull.Value)
            {
                obj.Comments = (string)returnData["Comments"];
            }
            if (returnData["Solutionstatusid"] != DBNull.Value)
            {
                obj.SolutionStatus = (int)returnData["Solutionstatusid"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Mode_mst> Get_Mode_mst_All()
    {
        return (BLLCollection<Mode_mst>)ExecuteReader(Sp_Get_Mode_All, new object[] { }, new GenerateCollectionFromReader(GenerateMode_mstCollection));
    }
    public CollectionBase GenerateMode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Mode_mst> col = new BLLCollection<Mode_mst>();
        while (returnData.Read())
        {
            Mode_mst obj = new Mode_mst();
            obj.Modeid = (int)returnData["Modeid"];
            obj.Modename = (string)returnData["Modename"];
            obj.Description = (string)returnData["Description"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    //add hub
    public BLLCollection<Hub_mst> Get_Hub_mst_All()
    {
        return (BLLCollection<Hub_mst>)ExecuteReader(Sp_Get_Hub_All, new object[] { }, new GenerateCollectionFromReader(GenerateHub_mstCollection));
    }
    public CollectionBase GenerateHub_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Hub_mst> col = new BLLCollection<Hub_mst>();
        while (returnData.Read())
        {
            Hub_mst obj = new Hub_mst();
            obj.Hubid = (int)returnData["Hubid"];
            obj.Hubname = (string)returnData["Hubname"];
            obj.Description = (string)returnData["Hubdescription"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    //end







    public BLLCollection<IncidentHistoryDiff> Get_IncidentHistoryDiff_mst_All_By_Historyid(int historyid)
    {
        return (BLLCollection<IncidentHistoryDiff>)ExecuteReader(Sp_Get_IncidentHistoryDiff_All_By_historyid, new object[] { historyid }, new GenerateCollectionFromReader(GenerateIncidentHistoryDiff_mstCollection));
    }

    public BLLCollection<IncidentHistoryDiff> Get_IncidentHistoryDiff_mst_All()
    {
        return (BLLCollection<IncidentHistoryDiff>)ExecuteReader(Sp_Get_IncidentHistoryDiff_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentHistoryDiff_mstCollection));
    }

    public CollectionBase GenerateIncidentHistoryDiff_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentHistoryDiff> col = new BLLCollection<IncidentHistoryDiff>();
        while (returnData.Read())
        {
            IncidentHistoryDiff obj = new IncidentHistoryDiff();
            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Prev_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ProblemHistoryDiff> Get_ProblemHistoryDiff_mst_All_By_Historyid(int historyid)
    {
        return (BLLCollection<ProblemHistoryDiff>)ExecuteReader(Sp_Get_ProblemHistoryDiff_All_By_historyid, new object[] { historyid }, new GenerateCollectionFromReader(GenerateProblemHistoryDiff_mstCollection));
    }
    public BLLCollection<ProblemHistoryDiff> Get_ProblemHistoryDiff_mst_All()
    {
        return (BLLCollection<ProblemHistoryDiff>)ExecuteReader(Sp_Get_ProblemHistoryDiff_All, new object[] { }, new GenerateCollectionFromReader(GenerateProblemHistoryDiff_mstCollection));
    }
    public CollectionBase GenerateProblemHistoryDiff_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ProblemHistoryDiff> col = new BLLCollection<ProblemHistoryDiff>();
        while (returnData.Read())
        {
            ProblemHistoryDiff obj = new ProblemHistoryDiff();
            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Pre_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ChangeHistoryDiff> Get_ChangeHistoryDiff_mst_All_By_Historyid(int historyid)
    {
        return (BLLCollection<ChangeHistoryDiff>)ExecuteReader(Sp_Get_ChangeHistoryDiff_All_By_historyid, new object[] { historyid }, new GenerateCollectionFromReader(GenerateChangeHistoryDiff_mstCollection));
    }
    public BLLCollection<ChangeHistoryDiff> Get_ChangeHistoryDiff_mst_All()
    {
        return (BLLCollection<ChangeHistoryDiff>)ExecuteReader(Sp_Get_ChangeHistoryDiff_All, new object[] { }, new GenerateCollectionFromReader(GenerateChangeHistoryDiff_mstCollection));
    }
    public CollectionBase GenerateChangeHistoryDiff_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeHistoryDiff> col = new BLLCollection<ChangeHistoryDiff>();
        while (returnData.Read())
        {
            ChangeHistoryDiff obj = new ChangeHistoryDiff();
            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Pre_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<IncidentHistory> Get_IncidentHistory_mst_All_By_incidentid(int incidentid)
    {
        return (BLLCollection<IncidentHistory>)ExecuteReader(Sp_Get_IncidentHistory_All_By_incidentid, new object[] { incidentid }, new GenerateCollectionFromReader(GenerateIncidentHistory_mstCollection));
    }

    public BLLCollection<IncidentHistory> Get_IncidentHistory_mst_All()
    {
        return (BLLCollection<IncidentHistory>)ExecuteReader(Sp_Get_IncidentHistory_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentHistory_mstCollection));
    }


    public CollectionBase GenerateIncidentHistory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentHistory> col = new BLLCollection<IncidentHistory>();
        while (returnData.Read())
        {


            IncidentHistory obj = new IncidentHistory();
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Operationtime"];
            obj.Operationtime = Mydatetime.ToString();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Historyid = (int)returnData["Historyid"];
            obj.Operationownerid = (int)returnData["Operationownerid"];
            obj.Operation = (string)returnData["Operation"];
            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ProblemHistory> Get_ProblemHistory_mst_All_By_problemid(int problemid)
    {
        return (BLLCollection<ProblemHistory>)ExecuteReader(Sp_Get_ProblemHistory_All_By_problemid, new object[] { problemid }, new GenerateCollectionFromReader(GenerateProblemHistory_mstCollection));
    }


    public CollectionBase GenerateProblemHistory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ProblemHistory> col = new BLLCollection<ProblemHistory>();
        while (returnData.Read())
        {


            ProblemHistory obj = new ProblemHistory();
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Operationtime"];
            obj.Operationtime = Mydatetime.ToString();
            obj.Problemid = (int)returnData["Problemid"];
            obj.Historyid = (int)returnData["Historyid"];
            obj.Operationownerid = (int)returnData["opertaionownerid"];
            obj.Operation = (string)returnData["Operation"];
            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ChangeHistory> Get_ChangeHistory_mst_All_By_changeid(int changeid)
    {
        return (BLLCollection<ChangeHistory>)ExecuteReader(Sp_Get_ChangeHistory_All_By_changeid, new object[] { changeid }, new GenerateCollectionFromReader(GenerateChangeHistory_mstCollection));
    }


    public CollectionBase GenerateChangeHistory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeHistory> col = new BLLCollection<ChangeHistory>();
        while (returnData.Read())
        {


            ChangeHistory obj = new ChangeHistory();
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Operationtime"];
            obj.Operationtime = Mydatetime.ToString();
            obj.Changeid = (int)returnData["Changeid"];

            obj.Historyid = (int)returnData["Historyid"];
            obj.Operationownerid = (int)returnData["opertaionownerid"];
            obj.Operation = (string)returnData["Operation"];
            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ProblemNotes> Get_ProblemNotes_mst_All_By_problemid(int problemid)
    {
        return (BLLCollection<ProblemNotes>)ExecuteReader(Sp_Get_ProblemNotes_All_By_problemid, new object[] { problemid }, new GenerateCollectionFromReader(GenerateProblemNotes_mstCollection));
    }
    public CollectionBase GenerateProblemNotes_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ProblemNotes> col = new BLLCollection<ProblemNotes>();
        while (returnData.Read())
        {


            ProblemNotes obj = new ProblemNotes();
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Date"];
            obj.Date = Mydatetime.ToString();
            obj.Problemid = (int)returnData["Problemid"];


            obj.UserName = (int)returnData["UserName"];
            if (returnData["Comments"] != DBNull.Value)
            {
                obj.Comments = (string)returnData["Comments"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ChangeNotes> Get_ChangeNotes_mst_All_By_changeid(int changeid)
    {
        return (BLLCollection<ChangeNotes>)ExecuteReader(Sp_Get_ChangeNotes_All_By_changeid, new object[] { changeid }, new GenerateCollectionFromReader(GenerateChangeNotes_mstCollection));
    }
    public CollectionBase GenerateChangeNotes_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeNotes> col = new BLLCollection<ChangeNotes>();
        while (returnData.Read())
        {


            ChangeNotes obj = new ChangeNotes();
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Date"];
            obj.Date = Mydatetime.ToString();
            obj.Changeid = (int)returnData["Changeid"];


            obj.Username = (int)returnData["Username"];
            if (returnData["Comments"] != DBNull.Value)
            {
                obj.Comments = (string)returnData["Comments"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<IncidentStates> Get_IncidentStates_mst_All()
    {
        return (BLLCollection<IncidentStates>)ExecuteReader(Sp_Get_IncidentStates_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentStates_mstCollection));
    }

    public CollectionBase GenerateIncidentStates_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentStates> col = new BLLCollection<IncidentStates>();
        while (returnData.Read())
        {


            IncidentStates obj = new IncidentStates();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.Technicianid = (int)returnData["Technicianid"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Requesttypeid = (int)returnData["Requesttypeid"];
            obj.Reqapproval = (bool)returnData["Reqapproval"];
            obj.Reopened = (bool)returnData["Reopened"];
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Isescalated = (bool)returnData["Isescalated"];
            obj.Impactid = (int)returnData["Impactid"];
            obj.Hasattachment = (bool)returnData["Hasattachment"];
            obj.Closecomments = (string)returnData["Closecomments"];
            obj.Closeaccepted = (string)returnData["Closeaccepted"];
            obj.Categoryid = (int)returnData["Categoryid"];
            if (returnData["AssignedTime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["AssignedTime"];
                obj.AssignedTime = Mydatetime.ToString();
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_Get_All_For_ProcessEmailEscalate(int statusid, int requesttypeid)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_For_ProcessEmailEscalate, new object[] { statusid, requesttypeid }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_Assigned(int siteid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_Assigned, new object[] { siteid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_statusid_Unassigned(int siteid, int statusid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_statusid_Unassigned, new object[] { siteid, statusid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_statusid_technicianid(int siteid, int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_statusid_technicianid, new object[] { siteid, statusid, technicianid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }


    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_statusid(int siteid, int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_statusid, new object[] { siteid, statusid, fromdate, todate, technicianid, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_Createdbyid(int siteid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_Createdbyid, new object[] { siteid, fromdate, todate, technicianid, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }


    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_Technicianid(int siteid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_technicianid, new object[] { siteid, technicianid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Siteid_Requesterid(int siteid, int requesterid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Siteid_Userid, new object[] { siteid, requesterid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }



    public BLLCollection<Incident_mst> Get_Incident_mst_All()
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }

    public CollectionBase Generateincludeasset_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncludedAssetinchange> col = new BLLCollection<IncludedAssetinchange>();
        while (returnData.Read())
        {


            IncludedAssetinchange obj = new IncludedAssetinchange();
            obj.Changeid = (int)returnData["Changeid"];
            obj.Assetid = (int)returnData["Assetid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public CollectionBase GenerateChangeApprove_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeApprove_trans> col = new BLLCollection<ChangeApprove_trans>();
        while (returnData.Read())
        {


            ChangeApprove_trans obj = new ChangeApprove_trans();
            if (returnData["Approvalcomment"] != DBNull.Value)
            {
                obj.Approvalcomment = (string)returnData["Approvalcomment"];
            }

            obj.ApproverName = (string)returnData["ApproverName"];
            obj.Approvestatus = (int)returnData["Approvestatus"];
            obj.Changeid = (int)returnData["Changeid"];
            DateTime Changestatusdate = new DateTime();
            if (returnData["Changestatusdatetime"] != DBNull.Value)
            {
                Changestatusdate = (DateTime)returnData["Changestatusdatetime"];
                obj.Changestatusdatetime = Changestatusdate.ToString();
            }
            // obj.Changestatusdatetime = (string)returnData["Changestatusdatetime"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ChangeApprove_trans> Get_ChangeApprove_trans_All_By_Changeid(int changeid)
    {
        return (BLLCollection<ChangeApprove_trans>)ExecuteReader(Sp_Get_ChangeApprove_trans_All_By_Changeid, new object[] { changeid }, new GenerateCollectionFromReader(GenerateChangeApprove_mstCollection));
    }

    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_SearchParameter(string Filterid, string keyword)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_SearchParameter, new object[] { Filterid, keyword }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<UserEmail> Get_UserEmail_All_By_userid(int userid)
    {
        return (BLLCollection<UserEmail>)ExecuteReader(Sp_Get_UserEmail_All_By_userid, new object[] { userid }, new GenerateCollectionFromReader(Generateuseremail_mstCollection));
    }
    public CollectionBase Generateuseremail_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<UserEmail> col = new BLLCollection<UserEmail>();
        while (returnData.Read())
        {


            UserEmail obj = new UserEmail();
            obj.Userid = (int)returnData["userid"];
            obj.Emailid = (string)returnData["emailid"];




            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_Problemid(int Problemid)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_Problemid, new object[] { Problemid }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<IncludedAssetinchange> Get_includeasset_mst_All_By_Changeid(int Changeid)
    {
        return (BLLCollection<IncludedAssetinchange>)ExecuteReader(Sp_Get_includeaaset_All_By_Changeid, new object[] { Changeid }, new GenerateCollectionFromReader(Generateincludeasset_mstCollection));
    }
    public BLLCollection<Change_mst> Get_Change_mst_All_By_statusid_technicianid(int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Change_mst>)ExecuteReader(Sp_Get_Change_All_By_statusid_technicianid, new object[] { statusid, technicianid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateChange_mstCollection));
    }
    public BLLCollection<Change_mst> Get_Change_mst_All_By_statusid(int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        return (BLLCollection<Change_mst>)ExecuteReader(Sp_Get_Change_All_By_statusid, new object[] { statusid, fromdate, todate, technicianid, varSortParameter }, new GenerateCollectionFromReader(GenerateChange_mstCollection));
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_statusid_technicianid(int statusid, int technicianid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_statusid_technicianid, new object[] { statusid, technicianid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<Configuration_mst> Get_Asset_mst_All_By_serialno(string serialno)
    {
        return (BLLCollection<Configuration_mst>)ExecuteReader(Sp_Get_Asset_All_By_Serialno, new object[] { serialno }, new GenerateCollectionFromReader(GenerateConfiguration_mstCollection));
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_Createdbyid(string fromdate, string todate, int technicianid, string varSortParameter)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_Createdbyid, new object[] { fromdate, todate, technicianid, varSortParameter }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_statusid(int statusid, string fromdate, string todate, int technicianid, string varSortParameter)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_statusid, new object[] { statusid, fromdate, todate, technicianid, varSortParameter }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_statusid_Unassigned(int statusid, string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_statusid_Unassigned, new object[] { statusid, fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<Problem_mst> Get_Problem_mst_All_By_Assigned(string fromdate, string todate, string varSortParameter)
    {
        return (BLLCollection<Problem_mst>)ExecuteReader(Sp_Get_Problem_All_By_Assigned, new object[] { fromdate, todate, varSortParameter }, new GenerateCollectionFromReader(GenerateProblem_mstCollection));
    }
    public BLLCollection<ProblemToSolution> Get_ProblemToSolution_mst_All_By_Problemid(int Problemid)
    {
        return (BLLCollection<ProblemToSolution>)ExecuteReader(Sp_Get_ProblemToSolution_All_By_Problemid, new object[] { Problemid }, new GenerateCollectionFromReader(GenerateProblemToSolution_mstCollection));
    }
    public CollectionBase GenerateProblemToSolution_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ProblemToSolution> col = new BLLCollection<ProblemToSolution>();
        while (returnData.Read())
        {


            ProblemToSolution obj = new ProblemToSolution();
            obj.Problemid = (int)returnData["Problemid"];
            obj.WorkAroundid = (int)returnData["WorkAroundid"];
            obj.Solutionid = (int)returnData["Solutionid"];
            obj.Solutiontype = (String)returnData["Solutiontype"];





            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Cab_mst> Get_CabMember_mst_All_By_ChangeTypeid(int ChangeTypeid)
    {
        return (BLLCollection<Cab_mst>)ExecuteReader(Sp_Get_CabMember_All_By_ChangeTypeid, new object[] { ChangeTypeid }, new GenerateCollectionFromReader(GenerateCabMember_mstCollection));
    }
    public CollectionBase GenerateCabMember_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Cab_mst> col = new BLLCollection<Cab_mst>();
        while (returnData.Read())
        {


            Cab_mst obj = new Cab_mst();
            obj.Cabid = (int)returnData["Cabid"];
            obj.Membername = (string)returnData["Membername"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Changetypeid = (int)returnData["Changetypeid"];






            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    //Modified by Lalit as Location wise ticket should come
    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_SearchParameter(string Filterid, string keyword,string UId)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_SearchParameter, new object[] { Filterid, keyword, UId}, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }
    public BLLCollection<Incident_mst> Get_Incident_mst_All_By_Incidentid(int incidentid)
    {
        return (BLLCollection<Incident_mst>)ExecuteReader(Sp_Get_Incident_All_By_Incidentid, new object[] { incidentid }, new GenerateCollectionFromReader(GenerateIncident_mstCollection));
    }


    public CollectionBase GenerateIncident_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Incident_mst> col = new BLLCollection<Incident_mst>();
        while (returnData.Read())
        {


            Incident_mst obj = new Incident_mst();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Title = (String)returnData["Title"];

            obj.Timespentonreq = (int)returnData["Timespentonreq"];
            obj.Slaid = (int)returnData["Slaid"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Requesterid = (int)returnData["Requesterid"];
            if (returnData["Modeid"] != DBNull.Value)
            {
                obj.Modeid = (int)returnData["Modeid"];
            }
            if (returnData["Description"] != DBNull.Value)
            { obj.Description = (String)returnData["Description"]; }
            if (returnData["Deptid"] != DBNull.Value)
            { obj.Deptid = (int)returnData["Deptid"]; }

            obj.Createdbyid = (int)returnData["Createdbyid"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            DateTime Complettime = new DateTime();
            if (returnData["Completedtime"] != DBNull.Value)
            {
                Complettime = (DateTime)returnData["Completedtime"];
                obj.Completedtime = Complettime.ToString();
            }
            if (returnData["ExternalTicketNo"] != DBNull.Value)
            {
                obj.ExternalTicketNo = (String)returnData["ExternalTicketNo"];
            }
            if (returnData["VendorId"] != DBNull.Value)
            {
                obj.VendorId = (int)returnData["VendorId"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<SLA_mst> Get_SLA_mst_All_By_Siteid(int siteid)
    {
        return (BLLCollection<SLA_mst>)ExecuteReader(Sp_Get_SLA_All_By_Siteid, new object[] { siteid }, new GenerateCollectionFromReader(GenerateSLA_mstCollection));
    }

    public BLLCollection<SLA_mst> Get_SLA_mst_All()
    {
        return (BLLCollection<SLA_mst>)ExecuteReader(Sp_Get_SLA_All, new object[] { }, new GenerateCollectionFromReader(GenerateSLA_mstCollection));
    }


    public CollectionBase GenerateSLA_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<SLA_mst> col = new BLLCollection<SLA_mst>();
        while (returnData.Read())
        {


            SLA_mst obj = new SLA_mst();
            obj.Slaid = (int)returnData["Slaid"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Slaname = (String)returnData["Slaname"];
            obj.Description = (string)returnData["description"];
            obj.Enable = (bool)returnData["Enable"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Department_mst> Get_Department_mst_All_By_SieId(int siteid)
    {
        return (BLLCollection<Department_mst>)ExecuteReader(Sp_Get_Department_All_By_Site_Id, new object[] { siteid }, new GenerateCollectionFromReader(GenerateDepartment_mstCollection));
    }


    public BLLCollection<Holiday_mst> Get_Holiday_All_By_SiteId(int siteid)
    {
        return (BLLCollection<Holiday_mst>)ExecuteReader(sp_Get_Holiday_All_By_SiteId, new object[] { siteid }, new GenerateCollectionFromReader(GenerateHolidaydesc_mstCollection));
    }

    public CollectionBase GenerateHolidaydesc_mstCollection(ref IDataReader returndata)
    {
        BLLCollection<Holiday_mst> col = new BLLCollection<Holiday_mst>();

        while (returndata.Read())
        {


            Holiday_mst obj = new Holiday_mst();
            //Site_mst obj1 = new Site_mst();

            obj.Holidayid = (int)(returndata["holidayid"]);

            DateTime holidaydatetime = new DateTime();
            holidaydatetime = (DateTime)returndata["holidaydate"];
            obj.Holidaydate = holidaydatetime.ToString();

            obj.Description = (string)returndata["Description"];
            obj.Siteid = (int)(returndata["siteid"]);

            col.Add(obj);
        }
        returndata.Close();
        returndata.Dispose();
        return col;

    }


    public BLLCollection<Department_mst> Get_Department_mst_All()
    {
        return (BLLCollection<Department_mst>)ExecuteReader(Sp_Get_Department_All, new object[] { }, new GenerateCollectionFromReader(GenerateDepartment_mstCollection));
    }

    public CollectionBase GenerateDepartment_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Department_mst> col = new BLLCollection<Department_mst>();
        while (returnData.Read())
        {


            Department_mst obj = new Department_mst();
            obj.Deptid = (int)returnData["Deptid"];
            obj.Departmentname = (string)returnData["Departmentname"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Description = (string)returnData["Description"];
            //obj.Company = (string)returnData["Company"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }








    public BLLCollection<Impact_mst> Get_Impact_mst_All()
    {
        return (BLLCollection<Impact_mst>)ExecuteReader(Sp_Get_Impact_All, new object[] { }, new GenerateCollectionFromReader(GenerateImpact_mstCollection));
    }
    public CollectionBase GenerateImpact_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Impact_mst> col = new BLLCollection<Impact_mst>();
        while (returnData.Read())
        {


            Impact_mst obj = new Impact_mst();
            obj.Impactid = (int)returnData["Impactid"];
            obj.Impactname = (string)returnData["Impactname"];
            obj.Description = (string)returnData["Description"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Status_mst> Get_Status_mst_All_By_OpenStatus()
    {
        return (BLLCollection<Status_mst>)ExecuteReader(Sp_Get_Status_All_By_OpenStatus, new object[] { }, new GenerateCollectionFromReader(GenerateStatus_mstCollection));
    }
    public BLLCollection<Status_mst> Get_Status_mst_All()
    {
        return (BLLCollection<Status_mst>)ExecuteReader(Sp_Get_Status_All, new object[] { }, new GenerateCollectionFromReader(GenerateStatus_mstCollection));
    }

    public CollectionBase GenerateStatus_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Status_mst> col = new BLLCollection<Status_mst>();
        while (returnData.Read())
        {


            Status_mst obj = new Status_mst();
            obj.Statusid = (int)returnData["statusid"];
            obj.Description = (string)returnData["description"];
            obj.Statusname = (string)returnData["statusname"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<ChangeStatus_mst> Get_ChangeStatus_mst_All_By_Statusname(string statusname)
    {
        return (BLLCollection<ChangeStatus_mst>)ExecuteReader(Sp_Get_ChangeStatus_All_By_Statusname, new object[] { statusname }, new GenerateCollectionFromReader(GenerateChangeStatus_mstCollection));
    }
    public BLLCollection<ChangeStatus_mst> Get_ChangeStatus_mst_All()
    {
        return (BLLCollection<ChangeStatus_mst>)ExecuteReader(Sp_Get_ChangeStatus_All, new object[] { }, new GenerateCollectionFromReader(GenerateChangeStatus_mstCollection));
    }
    public CollectionBase GenerateChangeStatus_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeStatus_mst> col = new BLLCollection<ChangeStatus_mst>();
        while (returnData.Read())
        {


            ChangeStatus_mst obj = new ChangeStatus_mst();
            obj.ChangeStatusid = (int)returnData["changestatusid"];
            obj.Description = (string)returnData["description"];
            obj.Statusname = (string)returnData["statusname"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ChangeType_mst> Get_ChangeType_mst_All()
    {
        return (BLLCollection<ChangeType_mst>)ExecuteReader(Sp_Get_ChangeType_All, new object[] { }, new GenerateCollectionFromReader(GenerateChangeType_mstCollection));
    }
    public CollectionBase GenerateChangeType_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ChangeType_mst> col = new BLLCollection<ChangeType_mst>();
        while (returnData.Read())
        {


            ChangeType_mst obj = new ChangeType_mst();
            obj.Changetypeid = (int)returnData["ChangeTypeid"];
            obj.Changetypename = (string)returnData["ChangeTypename"];

            obj.Description = (string)returnData["Description"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<Service_mst> Get_Service_mst_All()
    {
        return (BLLCollection<Service_mst>)ExecuteReader(Sp_Get_Service_All, new object[] { }, new GenerateCollectionFromReader(GenerateService_mstCollection));
    }

    public CollectionBase GenerateService_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Service_mst> col = new BLLCollection<Service_mst>();
        while (returnData.Read())
        {


            Service_mst obj = new Service_mst();
            obj.Serviceid = (int)returnData["serviceid"];
            obj.Description = (string)returnData["description"];
            obj.servicename = (string)returnData["servicename"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<State_mst> Get_State_mst_All()
    {
        return (BLLCollection<State_mst>)ExecuteReader(Sp_Get_State_All, new object[] { }, new GenerateCollectionFromReader(GenerateState_mstCollection));
    }

    public CollectionBase GenerateState_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<State_mst> col = new BLLCollection<State_mst>();
        while (returnData.Read())
        {
            State_mst obj = new State_mst();
            obj.Stateid = (int)returnData["Stateid"];
            obj.Statename = (string)returnData["Statename"];
            obj.Countryid = (int)returnData["Countryid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Priority_mst> Get_Priority_mst_All()
    {
        return (BLLCollection<Priority_mst>)ExecuteReader(Sp_Get_Priority_All, new object[] { }, new GenerateCollectionFromReader(GeneratePriority_mstCollection));
    }


    public CollectionBase GeneratePriority_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Priority_mst> col = new BLLCollection<Priority_mst>();
        while (returnData.Read())
        {


            Priority_mst obj = new Priority_mst();
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Name = (string)returnData["Name"];
            obj.Description = (string)returnData["description"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ContactInfo_mst> Get_ContactInfo_All()
    {
        return (BLLCollection<ContactInfo_mst>)ExecuteReader(sp_Get_ContactInfo_All_mst, new object[] { }, new GenerateCollectionFromReader(GenerateContactInfo_mstCollection));
    }
    public CollectionBase GenerateContactInfo_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ContactInfo_mst> col = new BLLCollection<ContactInfo_mst>();
        while (returnData.Read())
        {
            ContactInfo_mst obj = new ContactInfo_mst();
            //obj.Emailid=(string)returnData["emailid"];
            //obj.Userid=(int)returnData["userid"];
            //obj.Firstname=(string)returnData["firstname"];
            //obj.Lastname = (string)returnData["lastname"];
            //start changed by prachi 14th feb 2012

            if (returnData["emailid"].ToString().Length > 0) obj.Emailid = returnData["emailid"].ToString();
            else obj.Emailid = "";


            obj.Userid = (int)returnData["userid"];



            if (returnData["firstname"].ToString().Length > 0) obj.Firstname = returnData["firstname"].ToString();
            else obj.Firstname = "";
            if (returnData["lastname"].ToString().Length > 0) obj.Lastname = returnData["lastname"].ToString();
            else obj.Lastname = "";
            //end 

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<UserLogin_mst> Get_UserLogin_mst_All()
    {
        return (BLLCollection<UserLogin_mst>)ExecuteReader(Sp_Get_UserLogin_All, new object[] { }, new GenerateCollectionFromReader(GenerateUserLogin_mstCollection));
    }
    public BLLCollection<UserLogin_mst> UserLogin_mst_Get_By_Roleid(int roleid)
    {
        return (BLLCollection<UserLogin_mst>)ExecuteReader(Sp_Get_UserLogin_All_By_role, new object[] { roleid }, new GenerateCollectionFromReader(GenerateUserLogin_mstCollection));
    }
    public BLLCollection<UserLogin_mst> UserLogin_mst_Get_By_Role_Site(int roleid, int siteid)
    {
        return (BLLCollection<UserLogin_mst>)ExecuteReader(Sp_Get_UserLogin_All_By_role_Site, new object[] { roleid, siteid }, new GenerateCollectionFromReader(GenerateUserLogin_mstCollection));
    }

    public CollectionBase GenerateUserLogin_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();
        while (returnData.Read())
        {
            UserLogin_mst obj = new UserLogin_mst();
            obj.Userid = (int)returnData["Userid"];
            obj.Username = (string)returnData["Username"];
            obj.Roleid = (int)returnData["Roleid"];
            obj.Password = (string)returnData["Password"];
            obj.Orgid = (int)returnData["Orgid"];
            obj.Enable = (bool)returnData["Enable"];
            if (returnData["DomainName"] != DBNull.Value)
            {
                obj.DomainName = (string)returnData["DomainName"];
            }
            //obj.Company = (string)returnData["Company"];
            //obj.City = (string)returnData["City"];
            obj.ADEnable = (bool)returnData["ADEnable"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<UserToSiteMapping> Get_UserToSiteMapping_mst_All()
    {
        return (BLLCollection<UserToSiteMapping>)ExecuteReader(Sp_Get_UserToSiteMapping_All, new object[] { }, new GenerateCollectionFromReader(GenerateUserToSiteMapping_mstCollection));
    }


    public BLLCollection<UserToSiteMapping> Get_UserToSiteMapping_mst_All_By_Userid(int userid)
    {
        return (BLLCollection<UserToSiteMapping>)ExecuteReader(Sp_Get_UserToSiteMapping_All_By_userid, new object[] { userid }, new GenerateCollectionFromReader(GenerateUserToSiteMapping_mstCollection));
    }


    public BLLCollection<UserToSiteMapping> Get_UserToSiteMapping_mst_All_By_siteid(int siteid)
    {
        return (BLLCollection<UserToSiteMapping>)ExecuteReader(Sp_Get_UserToSiteMapping_All_By_siteid, new object[] { siteid }, new GenerateCollectionFromReader(GenerateUserToSiteMapping_mstCollection));
    }


    public CollectionBase GenerateUserToSiteMapping_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<UserToSiteMapping> col = new BLLCollection<UserToSiteMapping>();
        while (returnData.Read())
        {


            UserToSiteMapping obj = new UserToSiteMapping();
            obj.Userid = (int)returnData["Userid"];
            obj.Siteid = (int)returnData["Siteid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Site_mst> Get_Site_mst_All_By_RegionId(int regionid)
    {
        return (BLLCollection<Site_mst>)ExecuteReader(Sp_Get_Site_All_By_RegionId, new object[] { regionid }, new GenerateCollectionFromReader(GenerateSite_mstCollection));
    }
    /////////////////meenakshi
    public BLLCollection<Site_mst> sp_Get_By_sitename_mst(int hubid)
    {
        return (BLLCollection<Site_mst>)ExecuteReader(sp_Get_sitename_by_id, new object[] { hubid }, new GenerateCollectionFromReader(GenerateSitename_mstCollection));
    }

    public CollectionBase GenerateSitename_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        while (returnData.Read())
        {
            Site_mst obj = new Site_mst();
            //obj.Siteid = (int)returnData["Siteid"];
            obj.Sitename = (string)returnData["Sitename"];

            obj.Siteid = (int)returnData["Siteid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    ////////////////////end
    public BLLCollection<ServiceWindow_mst> Get_ServiceWindow_mst_All_By_RegionId(int regionid)
    {
        return (BLLCollection<ServiceWindow_mst>)ExecuteReader(Sp_Get_ServiceWindow_All_By_RegionId, new object[] { regionid }, new GenerateCollectionFromReader(GenerateViewServiceWindow_mstCollection));
    }

    public CollectionBase GenerateViewServiceWindow_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ServiceWindow_mst> col = new BLLCollection<ServiceWindow_mst>();
        while (returnData.Read())
        {
            ServiceWindow_mst obj = new ServiceWindow_mst();
            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Siteid = (int)returnData["Siteid"];
            col.Add(obj);
        }

        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<ServiceWindow_mst> Get_ServiceWindow_mst_All()
    {
        return (BLLCollection<ServiceWindow_mst>)ExecuteReader(Sp_Get_ServiceWindow_All, new object[] { }, new GenerateCollectionFromReader(GenerateViewServiceWindowGetAll_mstCollection));
    }

    public CollectionBase GenerateViewServiceWindowGetAll_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ServiceWindow_mst> col = new BLLCollection<ServiceWindow_mst>();

        while (returnData.Read())
        {
            ServiceWindow_mst obj = new ServiceWindow_mst();
            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Siteid = (int)returnData["Siteid"];
            col.Add(obj);
        }

        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Site_mst> Get_Site_mst_All()
    {
        return (BLLCollection<Site_mst>)ExecuteReader(Sp_Get_Site_All, new object[] { }, new GenerateCollectionFromReader(GenerateSite_mstCollection));
    }

    public CollectionBase GenerateSite_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Site_mst> col = new BLLCollection<Site_mst>();
        while (returnData.Read())
        {


            Site_mst obj = new Site_mst();
            obj.Siteid = (int)returnData["Siteid"];
            obj.Sitename = (string)returnData["Sitename"];
            obj.Regionid = (int)returnData["Regionid"];
            obj.Address = (string)returnData["Address"];
            obj.City = (string)returnData["City"];
            obj.Contactpersonname = (string)returnData["Contactpersonname"];
            obj.Countryid = (int)returnData["Countryid"];
            obj.Description = (string)returnData["Description"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Faxno = (string)returnData["Faxno"];
            obj.Mobileno = (string)returnData["Mobileno"];
            obj.Phoneno = (string)returnData["Phoneno"];
            obj.Postalcode = (string)returnData["Postalcode"];
            obj.State = (string)returnData["State"];
            obj.Timezoneid = (int)returnData["Timezoneid"];
            obj.Website = (string)returnData["Website"];
            obj.Enable = (bool)returnData["Enable"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Holiday_mst> Get_Holiday_mst_All()
    {
        return (BLLCollection<Holiday_mst>)ExecuteReader(Sp_Get_Holiday_All, new object[] { }, new GenerateCollectionFromReader(GenerateHoliday_mstCollection));
    }

    public CollectionBase GenerateHoliday_mstCollection(ref IDataReader returndata)
    {
        BLLCollection<Holiday_mst> col = new BLLCollection<Holiday_mst>();
        while (returndata.Read())
        {
            Holiday_mst obj = new Holiday_mst();

            DateTime holidaydatetime = new DateTime();
            holidaydatetime = (DateTime)returndata["holidaydate"];
            obj.Holidaydate = holidaydatetime.ToString();

            obj.Description = (string)returndata["Description"];
            obj.Siteid = (int)returndata["Siteid"];

            col.Add(obj);
        }
        returndata.Close();
        returndata.Dispose();
        return col;
    }

    public BLLCollection<Cab_mst> Get_Cab_mst_All()
    {
        return (BLLCollection<Cab_mst>)ExecuteReader(Sp_Get_Cab_All, new object[] { }, new GenerateCollectionFromReader(GenerateCab_mstCollection));
    }

    public CollectionBase GenerateCab_mstCollection(ref IDataReader returndata)
    {
        BLLCollection<Cab_mst> col = new BLLCollection<Cab_mst>();
        while (returndata.Read())
        {
            Cab_mst obj = new Cab_mst();

            DateTime date = new DateTime();
            date = (DateTime)returndata["date"];
            obj.Date = date.ToString();
            obj.Cabid = (int)returndata["cabid"];
            obj.Changetypeid = (int)returndata["changetypeid"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Membername = (string)returndata["membername"];
            obj.Phone = (string)returndata["phone"];
            col.Add(obj);
        }
        returndata.Close();
        returndata.Dispose();
        return col;
    }

    public BLLCollection<Customer_mst> Get_Customer_mst_All()
    {
        return (BLLCollection<Customer_mst>)ExecuteReader(Sp_Get_Customer_All, new object[] { }, new GenerateCollectionFromReader(GenerateCustomer_mstCollection));
    }

    public CollectionBase GenerateCustomer_mstCollection(ref IDataReader returndata)
    {
        BLLCollection<Customer_mst> col = new BLLCollection<Customer_mst>();
        while (returndata.Read())
        {
            Customer_mst obj = new Customer_mst();

            obj.Custid = (int)returndata["custid"];
            obj.Customer_name = (string)returndata["customer_name"];
            obj.Address = (string)returndata["address"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Contact_no = (string)returndata["contact_no"];
            obj.Contact_person = (string)returndata["contact_person"];
            col.Add(obj);
        }
        returndata.Close();
        returndata.Dispose();
        return col;
    }


    public BLLCollection<Country_mst> Get_Country_mst_All()
    {
        return (BLLCollection<Country_mst>)ExecuteReader(Sp_Get_Country_All, new object[] { }, new GenerateCollectionFromReader(GenerateCountry_mstCollection));
    }

    public CollectionBase GenerateCountry_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Country_mst> col = new BLLCollection<Country_mst>();
        while (returnData.Read())
        {


            Country_mst obj = new Country_mst();
            obj.Countryid = (int)returnData["Countryid"];
            obj.Countryname = (string)returnData["Countryname"];


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<RoleInfo_mst> Get_RoleInfo_mst_All()
    {
        return (BLLCollection<RoleInfo_mst>)ExecuteReader(Sp_Get_RoleInfo_All, new object[] { }, new GenerateCollectionFromReader(GenerateRoleInfo_mstCollection));
    }

    public CollectionBase GenerateRoleInfo_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<RoleInfo_mst> col = new BLLCollection<RoleInfo_mst>();
        while (returnData.Read())
        {


            RoleInfo_mst obj = new RoleInfo_mst();
            obj.Roleid = (int)returnData["Roleid"];
            obj.Rolename = (string)returnData["Rolename"];
            obj.Description = (string)returnData["Description"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Organization_mst> Get_Organization_mst_All()
    {
        return (BLLCollection<Organization_mst>)ExecuteReader(Sp_Get_Organization_All, new object[] { }, new GenerateCollectionFromReader(GenerateOrganization_mstCollection));
    }



    public CollectionBase GenerateOrganization_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Organization_mst> col = new BLLCollection<Organization_mst>();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();

            Organization_mst obj = new Organization_mst();
            obj.Orgid = (int)returnData["Orgid"];
            obj.Orgname = (string)returnData["Orgname"];
            obj.Description = (string)returnData["Description"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Category_mst> Get_Category_mst_All()
    {
        return (BLLCollection<Category_mst>)ExecuteReader(Sp_Get_Category_All, new object[] { }, new GenerateCollectionFromReader(GenerateCategory_mstCollection));
    }



    public CollectionBase GenerateCategory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        while (returnData.Read())
        {


            Category_mst obj = new Category_mst();
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.CategoryName = (string)returnData["CategoryName"];
            obj.Categorydescription = (string)returnData["categorydescription"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_mst> Get_Asset_mst_All()
    {
        return (BLLCollection<Asset_mst>)ExecuteReader(Sp_Get_Asset_All, new object[] { }, new GenerateCollectionFromReader(GenerateAsset_mstCollection));
    }
    public CollectionBase GenerateAsset_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        while (returnData.Read())
        {


            Asset_mst obj = new Asset_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["ComputerName"];
            obj.Domain = (string)returnData["Domain"];
            DateTime Createdate = new DateTime();
            Createdate = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Createdate.ToString();
            if (returnData["TagNo"] != DBNull.Value)
            {
                obj.TagNo = (string)returnData["TagNo"];
            }
            if (returnData["PONo"] != DBNull.Value)
            {
                obj.PONo = (string)returnData["PONo"];
            }
            if (returnData["AssetOwner"] != DBNull.Value)
            {
                obj.AssetOwner = (string)returnData["AssetOwner"];
            }
            if (returnData["IsInStock"] != DBNull.Value)
            {
                obj.IsInStock = (bool)returnData["IsInStock"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }



    public BLLCollection<Asset_Inventory_mst> Get_Asset_Inventory_mst_All()
    {
        return (BLLCollection<Asset_Inventory_mst>)ExecuteReader(Sp_Get_Asset_Inventory_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetInventory_mstCollection));
    }
    public CollectionBase GenerateAssetInventory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_Inventory_mst> col = new BLLCollection<Asset_Inventory_mst>();
        while (returnData.Read())
        {


            Asset_Inventory_mst obj = new Asset_Inventory_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["ComputerName"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventorydate = inventorydatetime.ToString();
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_LogicalDrive_mst> Get_Asset_LogicalDrive_mst_All()
    {
        return (BLLCollection<Asset_LogicalDrive_mst>)ExecuteReader(Sp_Get_Asset_LogicalDrive_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetLogicalDrive_mstCollection));
    }
    public CollectionBase GenerateAssetLogicalDrive_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_LogicalDrive_mst> col = new BLLCollection<Asset_LogicalDrive_mst>();
        while (returnData.Read())
        {


            Asset_LogicalDrive_mst obj = new Asset_LogicalDrive_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetlogicaldriveid = (int)returnData["assetlogicaldriveid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Drive_letter = (string)returnData["drive_letter"];
            obj.Drive_type = (string)returnData["drive_type"];
            obj.File_system_name = (string)returnData["file_system_name"];
            obj.Free_bytes = (string)returnData["free_bytes"];
            obj.Total_bytes = (string)returnData["total_bytes"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_Memory_mst> Get_Asset_Memory_mst_All()
    {
        return (BLLCollection<Asset_Memory_mst>)ExecuteReader(Sp_Get_Asset_Memory_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetMemory_mstCollection));
    }
    public CollectionBase GenerateAssetMemory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_Memory_mst> col = new BLLCollection<Asset_Memory_mst>();
        while (returnData.Read())
        {


            Asset_Memory_mst obj = new Asset_Memory_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetmemoryid = (int)returnData["assetmemoryid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Page_file = (string)returnData["page_file"];
            obj.Physical_mem = (string)returnData["physical_mem"];
            obj.Virtual_mem = (string)returnData["virtual_mem"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_Network_mst> Get_Asset_Network_mst_All()
    {
        return (BLLCollection<Asset_Network_mst>)ExecuteReader(Sp_Get_Asset_Network_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetNetwork_mstCollection));
    }
    public CollectionBase GenerateAssetNetwork_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_Network_mst> col = new BLLCollection<Asset_Network_mst>();
        while (returnData.Read())
        {
            Asset_Network_mst obj = new Asset_Network_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetnetworkid = (int)returnData["assetnetworkid"];
            obj.Adapter_name = (string)returnData["adapter_name"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Gateway = (string)returnData["gateway"];
            obj.Ip_address = (string)returnData["ip_address"];
            obj.Link_speed = (string)returnData["link_speed"];
            obj.Mac_address = (string)returnData["mac_address"];
            obj.Mtu = (string)returnData["mtu"];
            obj.Protocol_name = (string)returnData["protocol_name"];
            obj.Subnet_mask = (string)returnData["subnet_mask"];
            obj.Type = (string)returnData["type"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_OperatingSystem_mst> Get_Asset_OperatingSystem_mst_All()
    {
        return (BLLCollection<Asset_OperatingSystem_mst>)ExecuteReader(Sp_Get_Asset_OperatingSystem_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetOperatingSystem_mstCollection));
    }
    public CollectionBase GenerateAssetOperatingSystem_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_OperatingSystem_mst> col = new BLLCollection<Asset_OperatingSystem_mst>();
        while (returnData.Read())
        {
            Asset_OperatingSystem_mst obj = new Asset_OperatingSystem_mst();

            obj.Assetid = (int)returnData["assetid"];
            obj.Assetoperatingid = (int)returnData["assetoperatingid"];
            obj.Add_info = (string)returnData["add_info"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventory_date"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Build_no = (string)returnData["build_no"];
            obj.Localization = (string)returnData["localization"];
            obj.Major_version = (string)returnData["major_version"];
            obj.Minor_version = (string)returnData["minor_version"];
            obj.Os_name = (string)returnData["os_name"];
            obj.Product_key = (string)returnData["product_key"];
            obj.Reg_code = (string)returnData["reg_code"];
            obj.Reg_org = (string)returnData["reg_org"];
            obj.Reg_to = (string)returnData["reg_to"];
            obj.User_name = (string)returnData["user_name"];
            DateTime installdatetime = new DateTime();
            if (returnData["install_date"] != DBNull.Value)
            {
                installdatetime = (DateTime)returnData["install_date"];
                obj.Install_date = installdatetime.ToString();
            }

            DateTime logindatetime = new DateTime();
            if (returnData["login_date"] != DBNull.Value)
            {
                logindatetime = (DateTime)returnData["login_date"];
                obj.Login_date = logindatetime.ToString();
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    //added by lalit 29 feb
    public BLLCollection<Asset_OperatingSystem_mst> Get_Asset_OperatingSyste_mst_AllUsers()
    {
        return (BLLCollection<Asset_OperatingSystem_mst>)ExecuteReader(Sp_Get_Asset_OperatingSystem_AllUsers, new object[] { }, new GenerateCollectionFromReader(GenerateAssetOperatingSystem_mstCollectionUsers));
    }

    public CollectionBase GenerateAssetOperatingSystem_mstCollectionUsers(ref IDataReader returnData)
    {
        BLLCollection<Asset_OperatingSystem_mst> col = new BLLCollection<Asset_OperatingSystem_mst>();
        while (returnData.Read())
        {
            Asset_OperatingSystem_mst obj = new Asset_OperatingSystem_mst();
            if (returnData["user_name"] != "")
            {
                obj.User_name = (string)returnData["user_name"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    //end

    public BLLCollection<Asset_PhysicalDrive_mst> Get_Asset_PhysicalDrive_mst_All()
    {
        return (BLLCollection<Asset_PhysicalDrive_mst>)ExecuteReader(Sp_Get_Asset_PhysicalDrive_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetPhysicalDrive_mstCollection));
    }
    public CollectionBase GenerateAssetPhysicalDrive_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_PhysicalDrive_mst> col = new BLLCollection<Asset_PhysicalDrive_mst>();
        while (returnData.Read())
        {
            Asset_PhysicalDrive_mst obj = new Asset_PhysicalDrive_mst();

            obj.Assetid = (int)returnData["assetid"];
            obj.Assetphysicaldriveid = (int)returnData["assetphysicaldriveid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Capacity = (string)returnData["capacity"];
            obj.Drive_name = (string)returnData["drive_name"];
            obj.Manufacturer = (string)returnData["manufacturer"];
            obj.Product_id = (string)returnData["product_id"];
            obj.Product_version = (string)returnData["product_version"];
            obj.Serial_number = (string)returnData["serial_number"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_Processor_mst> Get_Asset_Processor_mst_All()
    {
        return (BLLCollection<Asset_Processor_mst>)ExecuteReader(Sp_Get_Asset_Processor_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetProcessor_mstCollection));
    }
    public CollectionBase GenerateAssetProcessor_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_Processor_mst> col = new BLLCollection<Asset_Processor_mst>();
        while (returnData.Read())
        {
            Asset_Processor_mst obj = new Asset_Processor_mst();

            obj.Assetid = (int)returnData["assetid"];
            obj.Assetprocessorid = (int)returnData["assetprocessorid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Family = (string)returnData["family"];
            obj.Manufacturer = (string)returnData["manufacturer"];
            obj.Max_speed = (string)returnData["max_speed"];
            obj.Model = (string)returnData["model"];
            obj.Processor_name = (string)returnData["processor_name"];
            obj.Speed = (string)returnData["speed"];
            obj.Stepping = (string)returnData["stepping"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_ProductInfo_mst> Get_Asset_ProductInfo_mst_All()
    {
        return (BLLCollection<Asset_ProductInfo_mst>)ExecuteReader(Sp_Get_Asset_ProductInfo_All, new object[] { }, new GenerateCollectionFromReader(GenerateAssetProductInfo_mstCollection));
    }
    public CollectionBase GenerateAssetProductInfo_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_ProductInfo_mst> col = new BLLCollection<Asset_ProductInfo_mst>();
        while (returnData.Read())
        {
            Asset_ProductInfo_mst obj = new Asset_ProductInfo_mst();

            obj.Assetid = (int)returnData["assetid"];
            obj.Assetproductinfoid = (int)returnData["assetproductinfoid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Product_manufacturer = (string)returnData["product_manufacturer"];
            obj.Product_name = (string)returnData["product_name"];
            obj.Serial_number = (string)returnData["serial_number"];
            obj.Sku_no = (string)returnData["sku_no"];
            obj.Uuid = (string)returnData["uuid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<UserToAssetMapping> Get_UserToAssetMapping_All()
    {
        return (BLLCollection<UserToAssetMapping>)ExecuteReader(Sp_Get_UserToAssetMapping_All, new object[] { }, new GenerateCollectionFromReader(GenerateUserToAssetMapping_mstCollection));
    }
    public CollectionBase GenerateUserToAssetMapping_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<UserToAssetMapping> col = new BLLCollection<UserToAssetMapping>();
        while (returnData.Read())
        {
            UserToAssetMapping obj = new UserToAssetMapping();

            obj.Assetid = (int)returnData["assetid"];
            obj.Userid = (int)returnData["userid"];
            if (returnData["assetlocation"] != DBNull.Value)
            {
                obj.AssetLocation = (string)returnData["assetlocation"];
            }
            if (returnData["companyname"] != DBNull.Value)
            {
                obj.AssetCompanyName = (string)returnData["companyname"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<IncidentToAssetMapping> Get_IncidentToAssetMapping_All()
    {
        return (BLLCollection<IncidentToAssetMapping>)ExecuteReader(Sp_Get_IncidentToAssetMapping_All, new object[] { }, new GenerateCollectionFromReader(GenerateIncidentToAssetMapping_mstCollection));
    }
    public CollectionBase GenerateIncidentToAssetMapping_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<IncidentToAssetMapping> col = new BLLCollection<IncidentToAssetMapping>();
        while (returnData.Read())
        {
            IncidentToAssetMapping obj = new IncidentToAssetMapping();

            obj.Assetid = (int)returnData["assetid"];
            obj.incidentid = (int)returnData["incidentid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    ///------------------------- added by lalit

    public IDataReader Get_contactInfo_ms_By_siteid()
    {
        return ExecuteReader(Sp_Get_contactinfo_By_siteid, new object[0]);
    }


    //--------------------------------------------------------

    //public BLLCollection<Region_mst> Get_All_mst_By_RegionId(int rid)
    //{
    //    return (BLLCollection<Region_mst>)ExecuteReader(Sp_Get_Region_By_id, new object[] { rid }, new GenerateCollectionFromReader(GenerateAllByRegion_mstCollection));
    //}
    //public CollectionBase GenerateAllByRegion_mstCollection(ref IDataReader returnData)
    //{
    //    BLLCollection<Region_mst> col = new BLLCollection<Region_mst>();

    //    while (returnData.Read())
    //    {
    //        DateTime Mydatetime = new DateTime();

    //        Region_mst obj = new Region_mst();
    //        obj.Regionid = (int)returnData["RegionId"];
    //        obj.Regionname = (string)returnData["Regionname"];
    //        obj.Description = (string)returnData["Description"];
    //        obj.Orgid = (int)returnData["Orgid"];
    //        Mydatetime = (DateTime)returnData["Createdatetime"];
    //        obj.Createdatetime = Mydatetime.ToString();
    //        col.Add(obj);
    //    }
    //    returnData.Close();
    //    returnData.Dispose();
    //    return col;

    //}

    public BLLCollection<Region_mst> Get_Region_mst_All()
    {
        return (BLLCollection<Region_mst>)ExecuteReader(Sp_Get_Region_All, new object[] { }, new GenerateCollectionFromReader(GenerateRegion_mstCollection));
    }



    public CollectionBase GenerateRegion_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Region_mst> col = new BLLCollection<Region_mst>();

        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();

            Region_mst obj = new Region_mst();
            obj.Regionid = (int)returnData["RegionId"];
            obj.Regionname = (string)returnData["Regionname"];
            obj.Description = (string)returnData["Description"];
            obj.Orgid = (int)returnData["Orgid"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Subcategory_mst> Get_Subcategory_mst_All()
    {
        return (BLLCollection<Subcategory_mst>)ExecuteReader(Sp_Get_Subcategory_All, new object[] { }, new GenerateCollectionFromReader(GenerateSubcategory_mstCollection));
    }



    public CollectionBase GenerateSubcategory_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Subcategory_mst> col = new BLLCollection<Subcategory_mst>();
        while (returnData.Read())
        {


            Subcategory_mst obj = new Subcategory_mst();
            obj.Subcategoryid = (int)returnData["subcategoryid"];
            obj.Subcategoryname = (string)returnData["subcategoryname"];
            obj.Subcategorydescription = (string)returnData["subcategorydescription"];
            obj.Categoryid = (int)returnData["categoryid"];

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    /* Created on 5 Dec 2010 by Sumit Gupta 
     * Function Get_CabCommittee_mst_All() fetch all record from CabCommittee_mst table by 
     * execute sp_Get_CabCommittee_All_mst procedure and call function  GenerateCabCommittee_mstCollection
     * which insert all records in CabCommittee_mst object
    */










    #endregion

    #region Public Function Get By Id()
    public ChangeTask_mst ChangeTask_mst_Get_By_taskid(int Taskid)
    {
        return (ChangeTask_mst)ExecuteReader(Sp_Get_Changetask_By_id, new object[] { Taskid }, new GenerateObjectFromReader(GenerateChangeTask_mstObject));
    }
    public object GenerateChangeTask_mstObject(ref IDataReader returnData)
    {

        ChangeTask_mst obj = new ChangeTask_mst();
        while (returnData.Read())
        {



            obj.Taskid = (int)returnData["Taskid"];
            obj.Changeid = (int)returnData["Changeid"];
            obj.Taskstatusid = (int)returnData["Taskstatusid"];
            obj.Ownerid = (int)returnData["Ownerid"];
            obj.Title = (string)returnData["Title"];






            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }



            if (returnData["Comment"] != DBNull.Value)
            {
                obj.Comment = (string)returnData["Comment"];
            }
            if (returnData["Scheduledstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Scheduledstarttime"];
                obj.Scheduledstarttime = Mydatetime.ToString();
            }
            if (returnData["Scheduledendtime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Scheduledendtime"];
                obj.Scheduledendtime = Mydatetime1.ToString();

            }

            if (returnData["Actualstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["Actualstarttime"];
                obj.Actualstarttime = Mydatetime3.ToString();
            }
            if (returnData["Actualendtime"] != DBNull.Value)
            {
                DateTime Mydatetime4 = new DateTime();
                Mydatetime4 = (DateTime)returnData["Actualendtime"];
                obj.Actualendtime = Mydatetime4.ToString();
            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ContractRenewed ContractRenewed_Get_By_id(int renewedContractid)
    {
        return (ContractRenewed)ExecuteReader(sp_ContractRenewed_By_id, new object[] { renewedContractid }, new GenerateObjectFromReader(GenerateContractRenewedObject));
    }

    public object GenerateContractRenewedObject(ref IDataReader returnData)
    {
        ContractRenewed obj = new ContractRenewed();
        while (returnData.Read())
        {

            obj.Contractid = (int)returnData["Contractid"];
            obj.Renewedcontractid = (int)returnData["Renewedcontractid"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Reneweddate"];
            obj.Reneweddate = Mydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ContractToAssetMapping ContractToAssetMapping_Get_By_contractid(int contractid)
    {
        return (ContractToAssetMapping)ExecuteReader(sp_ContractToAssetMapping_By_id, new object[] { contractid }, new GenerateObjectFromReader(GenerateContractToAssetMappingObject));
    }

    public object GenerateContractToAssetMappingObject(ref IDataReader returnData)
    {
        ContractToAssetMapping obj = new ContractToAssetMapping();
        while (returnData.Read())
        {

            obj.Contractid = (int)returnData["Contractid"];
            obj.Assetid = (int)returnData["Assetid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ContractNotification ContractNotification_Get_By_contractid(int contractid)
    {
        return (ContractNotification)ExecuteReader(sp_ContractNotification_By_id, new object[] { contractid }, new GenerateObjectFromReader(GenerateContractNotificationObject));
    }

    public object GenerateContractNotificationObject(ref IDataReader returnData)
    {
        ContractNotification obj = new ContractNotification();
        while (returnData.Read())
        {

            obj.Contractid = (int)returnData["Contractid"];
            obj.Beforedays = (int)returnData["Beforedays"];
            obj.Sentto = (string)returnData["Sentto"];
            obj.Sendnotification = (bool)returnData["Sendnotification"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Contract_mst Contract_mst_Get_By_contractid(int contractid)
    {
        return (Contract_mst)ExecuteReader(sp_Contract_By_id, new object[] { contractid }, new GenerateObjectFromReader(GenerateContract_mstObject));
    }

    public object GenerateContract_mstObject(ref IDataReader returnData)
    {
        Contract_mst obj = new Contract_mst();
        while (returnData.Read())
        {

            obj.Contractid = (int)returnData["Contractid"];
            obj.Contractname = (string)returnData["Contractname"];
            obj.Vendorid = (int)returnData["Vendorid"];
            obj.Description = (string)returnData["Description"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Activefrom"];
            obj.Activefrom = Mydatetime.ToString();
            DateTime Mydatetime1 = new DateTime();
            Mydatetime1 = (DateTime)returnData["Activeto"];
            obj.Activeto = Mydatetime1.ToString();
            DateTime Mydatetime2 = new DateTime();
            Mydatetime2 = (DateTime)returnData["CreateDateTime"];
            obj.CreateDateTime = Mydatetime2.ToString();


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ColorScheme_mst ColorScheme_mst_Get_By_colorName(string colorname)
    {
        return (ColorScheme_mst)ExecuteReader(sp_ColorScheme_By_colorName, new object[] { colorname }, new GenerateObjectFromReader(GenerateColorScheme_mstObject));
    }
    public ColorScheme_mst ColorScheme_mst_Get_By_id(int colorid)
    {
        return (ColorScheme_mst)ExecuteReader(sp_ColorScheme_By_id, new object[] { colorid }, new GenerateObjectFromReader(GenerateColorScheme_mstObject));
    }

    public object GenerateColorScheme_mstObject(ref IDataReader returnData)
    {
        ColorScheme_mst obj = new ColorScheme_mst();
        while (returnData.Read())
        {
            obj.Colorid = (int)returnData["Colorid"];
            obj.Percnt = (int)returnData["Percnt"];
            obj.Percnt_to = (int)returnData["Percnt_to"];
            obj.Colorname = (string)returnData["Colorname"];
            obj.CallStatus = (string)returnData["CallStatus"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public CheckLevel3Escalate CheckLevel3Escalate_Get_By_incidentid(int incidentid)
    {
        return (CheckLevel3Escalate)ExecuteReader(sp_Get_EscalateLevel3_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateCheckLevel3EscalateObject));
    }

    public object GenerateCheckLevel3EscalateObject(ref IDataReader returnData)
    {
        CheckLevel3Escalate obj = new CheckLevel3Escalate();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level3escalate = (bool)returnData["Level3escalate"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public CheckLevel2Escalate CheckLevel2Escalate_Get_By_incidentid(int incidentid)
    {
        return (CheckLevel2Escalate)ExecuteReader(sp_Get_EscalateLevel2_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateCheckLevel2EscalateObject));
    }

    public object GenerateCheckLevel2EscalateObject(ref IDataReader returnData)
    {
        CheckLevel2Escalate obj = new CheckLevel2Escalate();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level2escalate = (bool)returnData["Level2escalate"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public CheckLevel1Escalate CheckLevel1Escalate_Get_By_incidentid(int incidentid)
    {
        return (CheckLevel1Escalate)ExecuteReader(sp_Get_EscalateLevel1_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateCheckLevel1EscalateObject));
    }

    public object GenerateCheckLevel1EscalateObject(ref IDataReader returnData)
    {
        CheckLevel1Escalate obj = new CheckLevel1Escalate();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level1escalate = (bool)returnData["Level1escalate"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public CheckEmailEscalate CheckEmailEscalate_Get_By_incidentid(int incidentid)
    {
        return (CheckEmailEscalate)ExecuteReader(sp_EscalateLevel1_mst_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateCheckEmailEscalateObject));
    }

    public object GenerateCheckEmailEscalateObject(ref IDataReader returnData)
    {
        CheckEmailEscalate obj = new CheckEmailEscalate();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Level1escalate = (bool)returnData["Level1escalate"];
            obj.Level2escalate = (bool)returnData["Level2escalate"];
            obj.Level3escalate = (bool)returnData["Level3escalate"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public EscalateLevel3 EscalateLevel3_Get_By_slaid(int slaid)
    {
        return (EscalateLevel3)ExecuteReader(sp_EscalateLevel3_mst_By_slaid, new object[] { slaid }, new GenerateObjectFromReader(GenerateEscalateLevel3Object));
    }
    public EscalateLevel2 EscalateLevel2_Get_By_slaid(int slaid)
    {
        return (EscalateLevel2)ExecuteReader(sp_EscalateLevel2_mst_By_slaid, new object[] { slaid }, new GenerateObjectFromReader(GenerateEscalateLevel2Object));
    }
    public EscalateLevel1 EscalateLevel1_Get_By_slaid(int slaid)
    {
        return (EscalateLevel1)ExecuteReader(sp_EscalateLevel1_mst_By_slaid, new object[] { slaid }, new GenerateObjectFromReader(GenerateEscalateLevel1Object));
    }
    public EscalateLevel1 EscalateLevel1_Get_By_id(int level1id)
    {
        return (EscalateLevel1)ExecuteReader(sp_EscalateLevel1_mst_By_id, new object[] { level1id }, new GenerateObjectFromReader(GenerateEscalateLevel1Object));
    }

    public object GenerateEscalateLevel1Object(ref IDataReader returnData)
    {
        EscalateLevel1 obj = new EscalateLevel1();
        while (returnData.Read())
        {
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level1id = (int)returnData["Level1id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    //lalit 24 march
    public int GetTechincianSLAStop(int technicianid)
    {
        return (int)ExecuteScalar(Sp_Check_TechnicianSLAStop, new object[] { technicianid });
    }
    //end

    public EscalateLevel2 EscalateLevel2_Get_By_id(int level2id)
    {
        return (EscalateLevel2)ExecuteReader(sp_EscalateLevel2_mst_By_id, new object[] { level2id }, new GenerateObjectFromReader(GenerateEscalateLevel2Object));
    }

    public object GenerateEscalateLevel2Object(ref IDataReader returnData)
    {
        EscalateLevel2 obj = new EscalateLevel2();
        while (returnData.Read())
        {
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level2id = (int)returnData["Level2id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public EscalateLevel3 EscalateLevel3_Get_By_id(int level3id)
    {
        return (EscalateLevel3)ExecuteReader(sp_EscalateLevel3_mst_By_id, new object[] { level3id }, new GenerateObjectFromReader(GenerateEscalateLevel3Object));
    }

    public object GenerateEscalateLevel3Object(ref IDataReader returnData)
    {
        EscalateLevel3 obj = new EscalateLevel3();
        while (returnData.Read())
        {
            obj.Slaid = (int)returnData["Slaid"];
            obj.Min = (int)returnData["Min"];
            obj.Level3id = (int)returnData["Level3id"];
            obj.Hours = (int)returnData["Hours"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Days = (int)returnData["Days"];
            obj.Before = (bool)returnData["Before"];
            obj.After = (bool)returnData["After"];
            if (returnData["Sent"] != DBNull.Value)
            {
                obj.Sent = (bool)returnData["Sent"];
            }

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public EscalateEmail_mst EscalateEmail_mst_Get_By_emailid(string emailid)
    {
        return (EscalateEmail_mst)ExecuteReader(sp_EscalateEmail_By_emailid, new object[] { emailid }, new GenerateObjectFromReader(GenerateEscalateEmail_mstObject));
    }

    public EscalateEmail_mst EscalateEmail_mst_Get_By_id(int id)
    {
        return (EscalateEmail_mst)ExecuteReader(sp_EscalateEmail_By_id, new object[] { id }, new GenerateObjectFromReader(GenerateEscalateEmail_mstObject));
    }

    public object GenerateEscalateEmail_mstObject(ref IDataReader returnData)
    {
        EscalateEmail_mst obj = new EscalateEmail_mst();
        while (returnData.Read())
        {
            obj.Id = (int)returnData["Id"];
            obj.Email = (string)returnData["Email"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Technician_To_Group Technician_To_Group_Get_By_incidentid(int technicianid)
    {
        return (Technician_To_Group)ExecuteReader(Sp_Get_Technician_To_Group_By_id, new object[] { technicianid }, new GenerateObjectFromReader(GenerateTechnician_To_GroupObject));
    }

    public object GenerateTechnician_To_GroupObject(ref IDataReader returnData)
    {
        Technician_To_Group obj = new Technician_To_Group();
        while (returnData.Read())
        {
            obj.Groupid = (int)returnData["Groupid"];
            obj.Technicianid = (int)returnData["Technicianid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Group_mst Group_mst_Get_By_incidentid(int groupid)
    {
        return (Group_mst)ExecuteReader(Sp_Get_Group_mst_By_id, new object[] { groupid }, new GenerateObjectFromReader(GenerateGroup_mst_mstObject));
    }

    public object GenerateGroup_mst_mstObject(ref IDataReader returnData)
    {
        Group_mst obj = new Group_mst();
        while (returnData.Read())
        {
            obj.Groupid = (int)returnData["Groupid"];
            obj.Groupname = (string)returnData["Groupname"];
            if (returnData["Description"] != DBNull.Value)
            { obj.Description = (string)returnData["Description"]; }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Incident_To_Problem Incident_To_Problem_Get_By_incidentid(int incidentid, int problemid)
    {
        return (Incident_To_Problem)ExecuteReader(Sp_Get_Incident_To_Problem_By_id, new object[] { incidentid, problemid }, new GenerateObjectFromReader(GenerateIncident_To_Problem_mstObject));
    }

    public object GenerateIncident_To_Problem_mstObject(ref IDataReader returnData)
    {
        Incident_To_Problem obj = new Incident_To_Problem();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Problemid = (int)returnData["Problemid"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public Incident_To_Change Incident_To_Change_Get_By_incidentid(int incidentid, int changeid)
    {
        return (Incident_To_Change)ExecuteReader(Sp_Get_Incident_To_Changeid_By_id, new object[] { incidentid, changeid }, new GenerateObjectFromReader(GenerateIncident_To_Changeid_mstObject));
    }

    public object GenerateIncident_To_Changeid_mstObject(ref IDataReader returnData)
    {
        Incident_To_Change obj = new Incident_To_Change();
        while (returnData.Read())
        {

            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Changeid = (int)returnData["Changeid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public Problem_To_Change Problem_To_Change_Get_By_problemid(int problemid, int changeid)
    {
        return (Problem_To_Change)ExecuteReader(Sp_Get_Incident_To_Problem_By_id, new object[] { problemid, changeid }, new GenerateObjectFromReader(GenerateProblem_To_Change_mstObject));
    }

    public object GenerateProblem_To_Change_mstObject(ref IDataReader returnData)
    {
        Problem_To_Change obj = new Problem_To_Change();

        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["Changeid"];
            obj.Changeid = (int)returnData["Problemid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public Vendor_mst Vendor_mst_Get_By_vendorid(int vendorid)
    {

        return (Vendor_mst)ExecuteReader(Sp_Get_Vendor_By_id, new object[] { vendorid }, new GenerateObjectFromReader(GenerateVendor_mstObject));
    }

    public object GenerateVendor_mstObject(ref IDataReader returnData)
    {
        Vendor_mst obj = new Vendor_mst();
        while (returnData.Read())
        {
            obj.Contactperson = (string)returnData["Contactperson"];
            obj.Vendorid = (int)returnData["Vendorid"];
            obj.Vendorname = (string)returnData["Vendorname"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Holiday_mst Get_Holidaydesc_Desc_By_Holidayid(int holidayid)
    {
        return (Holiday_mst)ExecuteReader(Sp_Get_Holidaydesc_Desc_By_Holidayid, new object[] { holidayid }, new GenerateObjectFromReader(GenerateHolidaydesciption_mstObject));

    }
    public object GenerateHolidaydesciption_mstObject(ref IDataReader returndata)
    {
        Holiday_mst obj = new Holiday_mst();

        while (returndata.Read())
        {
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returndata["Holidaydate"];
            obj.Holidaydate = Mydatetime.ToString();
            obj.Description = (string)returndata["Description"];
            obj.Holidayid = (int)returndata["Holidayid"];
            obj.Siteid = (int)returndata["Siteid"];

        }
        returndata.Close();
        returndata.Dispose();
        return obj;

    }

    public Cab_mst Cab_mst_Get_By_cabid(int cabid)
    {
        return (Cab_mst)ExecuteReader(Sp_Get_Cab_By_Cabid, new object[] { cabid }, new GenerateObjectFromReader(GenerateCabDetails_mstObject));

    }
    public object GenerateCabDetails_mstObject(ref IDataReader returndata)
    {
        Cab_mst obj = new Cab_mst();

        while (returndata.Read())
        {
            DateTime date = new DateTime();
            date = (DateTime)returndata["date"];
            obj.Date = date.ToString();
            obj.Cabid = (int)returndata["cabid"];
            obj.Changetypeid = (int)returndata["changetypeid"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Membername = (string)returndata["membername"];
            obj.Phone = (string)returndata["phone"];
        }
        returndata.Close();
        returndata.Dispose();
        return obj;

    }


    public Customer_mst Customer_mst_Get_By_Customerid(int custid)
    {
        return (Customer_mst)ExecuteReader(Sp_Get_Customer_By_Cabid, new object[] { custid }, new GenerateObjectFromReader(GenerateCustomerDetails_mstObject));

    }
    public object GenerateCustomerDetails_mstObject(ref IDataReader returndata)
    {
        Customer_mst obj = new Customer_mst();

        while (returndata.Read())
        {
            obj.Custid = (int)returndata["custid"];
            obj.Customer_name = (string)returndata["customer_name"];
            obj.Address = (string)returndata["address"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Contact_no = (string)returndata["contact_no"];
            obj.Contact_person = (string)returndata["contact_person"];
        }
        returndata.Close();
        returndata.Dispose();
        return obj;

    }

    public Cab_mst Get_Cab_By_membername(string membername)
    {
        return (Cab_mst)ExecuteReader(Sp_Get_Cab_By_Membername, new object[] { membername }, new GenerateObjectFromReader(GenerateCabDetailsByMembername_mstObject));

    }
    public object GenerateCabDetailsByMembername_mstObject(ref IDataReader returndata)
    {
        Cab_mst obj = new Cab_mst();

        while (returndata.Read())
        {
            DateTime date = new DateTime();
            date = (DateTime)returndata["date"];
            obj.Date = date.ToString();
            obj.Cabid = (int)returndata["cabid"];
            obj.Changetypeid = (int)returndata["changetypeid"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Membername = (string)returndata["membername"];
            obj.Phone = (string)returndata["phone"];
        }
        returndata.Close();
        returndata.Dispose();
        return obj;

    }

    public Customer_mst Get_Customer_By_customername(string customername)
    {
        return (Customer_mst)ExecuteReader(Sp_Get_Customer_By_Customername, new object[] { customername }, new GenerateObjectFromReader(GenerateCustomerDetailsByCustomername_mstObject));

    }
    public object GenerateCustomerDetailsByCustomername_mstObject(ref IDataReader returndata)
    {
        Customer_mst obj = new Customer_mst();

        while (returndata.Read())
        {
            obj.Custid = (int)returndata["custid"];
            obj.Customer_name = (string)returndata["customer_name"];
            obj.Address = (string)returndata["address"];
            obj.Emailid = (string)returndata["emailid"];
            obj.Contact_no = (string)returndata["contact_no"];
            obj.Contact_person = (string)returndata["contact_person"];
        }
        returndata.Close();
        returndata.Dispose();
        return obj;

    }

    public IncidentLog IncidentLog_Get_By_incidentid(int incidentid)
    {
        return (IncidentLog)ExecuteReader(Sp_Get_IncidentLog_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateIncidentLog_mstObject));
    }

    public object GenerateIncidentLog_mstObject(ref IDataReader returnData)
    {
        IncidentLog obj = new IncidentLog();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Incidentlog = (string)returnData["Incidentlog"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public BLLCollection<csm_calls> Get_csm_calls_All_By_ComplaintDate(string fromdate, string ToDate)
    {
        return (BLLCollection<csm_calls>)ExecuteReader(Sp_Get_csm_calls_By_ComplaintDate, new object[] { fromdate, ToDate }, new GenerateCollectionFromReader(Generatecsm_callsCollection));
    }

    public CollectionBase Generatecsm_callsCollection(ref IDataReader returnData)
    {
        BLLCollection<csm_calls> col = new BLLCollection<csm_calls>();
        while (returnData.Read())
        {


            csm_calls obj = new csm_calls();
            obj.User = (string)returnData["User"];
            if (returnData["Start Time"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Start Time"];
                obj.StartTime = Mydatetime.ToString();
            }
            if (returnData["Start Date"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Start Date"];
                obj.StartDate = Mydatetime1.ToString();
            }

            if (returnData["SLA Type"] != DBNull.Value)
            {
                obj.SLAType = (string)returnData["SLA Type"];
            }
            if (returnData["Severity Level"] != DBNull.Value)
            {
                obj.Severitylevel = (string)returnData["Severity Level"];
            }
            if (returnData["Response Time in Minutes"] != DBNull.Value)
            {
                obj.Responsetimeinminutes = (string)returnData["Response Time in Minutes"];
            }
            if (returnData["Resolution Time in Minutes"] != DBNull.Value)
            {
                obj.ResolutionTimeinMinutes = (string)returnData["Resolution Time in Minutes"];
            }
            if (returnData["Problem Desc"] != DBNull.Value)
            {
                obj.ProblemDesc = (string)returnData["Problem Desc"];
            }


            if (returnData["logtime"] != DBNull.Value)
            {

                obj.Logtime = (string)returnData["logtime"];

            }
            if (returnData["logdate"] != DBNull.Value)
            {
                obj.LogDate = (string)returnData["logdate"];

            }

            if (returnData["Location"] != DBNull.Value)
            {
                obj.Location = (string)returnData["Location"];
            }
            if (returnData["Customer Name"] != DBNull.Value)
            {
                obj.Location = (string)returnData["Customer Name"];
            }
            if (returnData["Engineer"] != DBNull.Value)
            {
                obj.Engineer = (string)returnData["Engineer"];
            }

            if (returnData["Closetime"] != DBNull.Value)
            {
                obj.ClosedTime = (string)returnData["Closetime"];

            }

            if (returnData["ClosedDate"] != DBNull.Value)
            {

                obj.Closeddate = (string)returnData["ClosedDate"];

            }

            if (returnData["Case History Last Update"] != DBNull.Value)
            {
                obj.CaseHistoryLastUpdate = (string)returnData["Case History Last Update"];
            }
            if (returnData["Call Type"] != DBNull.Value)
            {
                obj.CallType = (string)returnData["Call Type"];
            }
            if (returnData["Call Status"] != DBNull.Value)
            {
                obj.CallStatus = (string)returnData["Call Status"];
            }


            obj.CallNo = (string)returnData["Call No"];
            if (returnData["Allowed Response Time in Minutes"] != DBNull.Value)
            {
                obj.AllowedResponseTimeinminutes = (string)returnData["Allowed Response Time in Minutes"];
            }
            if (returnData["Allowed Resolution Time in Minutes"] != DBNull.Value)
            {
                obj.AllowedResolutionTimeinMinutes = (string)returnData["Allowed Resolution Time in Minutes"];
            }










            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<csm_complaint_mst> Get_csm_complaint_mst_All_By_ComplaintDate(string fromdate, string ToDate)
    {
        return (BLLCollection<csm_complaint_mst>)ExecuteReader(Sp_Get_csm_complaint_mst_By_ComplaintDate, new object[] { fromdate, ToDate }, new GenerateCollectionFromReader(Generatecsm_complaint_mst_mstCollection));
    }
    public BLLCollection<csm_complaint_mst> Get_csm_complaint_mst_All_By_ComplaintId(string ComplaintId)
    {
        return (BLLCollection<csm_complaint_mst>)ExecuteReader(Sp_Get_csm_complaint_mst_By_id, new object[] { ComplaintId }, new GenerateCollectionFromReader(Generatecsm_complaint_mst_mstCollection));
    }
    public CollectionBase Generatecsm_complaint_mst_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<csm_complaint_mst> col = new BLLCollection<csm_complaint_mst>();
        while (returnData.Read())
        {


            csm_complaint_mst obj = new csm_complaint_mst();
            obj.ComplaintId = (string)returnData["ComplaintId"];
            obj.ComplaintDesc = (string)returnData["ComplaintDesc"];
            obj.CustomerName = (string)returnData["CustomerName"];


            if (returnData["ComplaintDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ComplaintDate"];
                obj.ComplaintDate = Mydatetime.ToString();
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    //Get_csm_CaseHistory_trans
    public BLLCollection<csm_CaseHistory_trans> Get_csm_CaseHistory_trans_All_By_ComplaintId(string ComplaintId)
    {
        return (BLLCollection<csm_CaseHistory_trans>)ExecuteReader(Sp_Get_csm_CaseHistory_trans_By_id, new object[] { ComplaintId }, new GenerateCollectionFromReader(Generatecsm_CaseHistory_trans_mstCollection));
    }

    public CollectionBase Generatecsm_CaseHistory_trans_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<csm_CaseHistory_trans> col = new BLLCollection<csm_CaseHistory_trans>();
        while (returnData.Read())
        {


            csm_CaseHistory_trans obj = new csm_CaseHistory_trans();
            obj.ComplaintId = (string)returnData["ComplaintId"];

            obj.CompId = (string)returnData["CompId"];


            obj.ItemId = (string)returnData["ItemId"];
            obj.OrgId = (string)returnData["OrgId"];
            if (returnData["CallLogNotes"] != DBNull.Value)
            {

                obj.CallLogNotes = (string)returnData["CallLogNotes"];
            }
            if (returnData["ComplaintStatus"] != DBNull.Value)
            {

                obj.ComplaintStatus = (string)returnData["ComplaintStatus"];
            }
            if (returnData["EngineerId"] != DBNull.Value)
            {

                obj.EngineerId = (string)returnData["EngineerId"];
            }

            if (returnData["UserName"] != DBNull.Value)
            {

                obj.UserName = (string)returnData["UserName"];
            }

            if (returnData["ChangedStatusDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ChangedStatusDate"];
                obj.ChangedStatusDate = Mydatetime.ToString();
            }
            if (returnData["PendingReason"] != DBNull.Value)
            {

                obj.PendingReason = (string)returnData["PendingReason"];
            }
            if (returnData["ComplaintDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ComplaintDate"];
                obj.ComplaintDate = Mydatetime.ToString();
            }


            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    //csm_complaint_mst

    public csm_complaint_mst csm_complaint_mst_Get_By_ComplaintId(string ComplaintId)
    {
        return (csm_complaint_mst)ExecuteReader(Sp_Get_csm_complaint_mst_By_id, new object[] { ComplaintId }, new GenerateObjectFromReader(Generatecsm_complaint_mst_mstObject));
    }

    public object Generatecsm_complaint_mst_mstObject(ref IDataReader returnData)
    {
        csm_complaint_mst obj = new csm_complaint_mst();
        while (returnData.Read())
        {
            obj.ComplaintId = (string)returnData["ComplaintId"];
            obj.ComplaintDesc = (string)returnData["ComplaintDesc"];
            obj.CustomerName = (string)returnData["CustomerName"];


            if (returnData["ComplaintDate "] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ComplaintDate "];
                obj.ComplaintDate = Mydatetime.ToString();
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public csm_calls csm_calls_Get_By_ComplaintId(string callno)
    {
        return (csm_calls)ExecuteReader(Sp_Get_csm_calls_By_id, new object[] { callno }, new GenerateObjectFromReader(Generatecsm_callsObject));
    }


    public object Generatecsm_callsObject(ref IDataReader returnData)
    {
        csm_calls obj = new csm_calls();
        while (returnData.Read())
        {
            obj.Customername = (string)returnData["Customer Name"];
            obj.User = (string)returnData["User"];
            if (returnData["Start Time"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Start Time"];
                obj.StartTime = Mydatetime.ToString();
            }
            if (returnData["Start Date"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Start Date"];
                obj.StartDate = Mydatetime1.ToString();
            }

            if (returnData["SLA Type"] != DBNull.Value)
            {
                obj.SLAType = (string)returnData["SLA Type"];
            }
            if (returnData["Severity Level"] != DBNull.Value)
            {
                obj.Severitylevel = (string)returnData["Severity Level"];
            }
            if (returnData["Response Time in Minutes"] != DBNull.Value)
            {
                obj.Responsetimeinminutes = (string)returnData["Response Time in Minutes"];
            }
            if (returnData["Resolution Time in Minutes"] != DBNull.Value)
            {
                obj.ResolutionTimeinMinutes = (string)returnData["Resolution Time in Minutes"];
            }
            if (returnData["Problem Desc"] != DBNull.Value)
            {
                obj.ProblemDesc = (string)returnData["Problem Desc"];
            }


            if (returnData["Log Time"] != DBNull.Value)
            {
                DateTime Mydatetime2 = new DateTime();
                Mydatetime2 = (DateTime)returnData["Log Time"];
                obj.Logtime = Mydatetime2.ToString();
            }
            if (returnData["Log Date"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["Log Date"];
                obj.LogDate = Mydatetime3.ToString();
            }

            if (returnData["Location"] != DBNull.Value)
            {
                obj.Location = (string)returnData["Location"];
            }
            if (returnData["Engineer"] != DBNull.Value)
            {
                obj.Engineer = (string)returnData["Engineer"];
            }

            if (returnData["Closed Time"] != DBNull.Value)
            {
                DateTime Mydatetime4 = new DateTime();
                Mydatetime4 = (DateTime)returnData["Closed Time"];
                obj.ClosedTime = Mydatetime4.ToString();
            }

            if (returnData["Closed Date"] != DBNull.Value)
            {
                DateTime Mydatetime5 = new DateTime();
                Mydatetime5 = (DateTime)returnData["Closed Date"];
                obj.Closeddate = Mydatetime5.ToString();
            }

            if (returnData["Case History Last Update"] != DBNull.Value)
            {
                obj.CaseHistoryLastUpdate = (string)returnData["Case History Last Update"];
            }
            if (returnData["Call Type"] != DBNull.Value)
            {
                obj.CallType = (string)returnData["Call Type"];
            }
            if (returnData["Call Status"] != DBNull.Value)
            {
                obj.CallStatus = (string)returnData["Call Status"];
            }


            obj.CallNo = (string)returnData["Call No"];
            if (returnData["Allowed Response Time in Minutes"] != DBNull.Value)
            {
                obj.AllowedResponseTimeinminutes = (string)returnData["Allowed Response Time in Minutes"];
            }
            if (returnData["Allowed Resolution Time in Minutes"] != DBNull.Value)
            {
                obj.AllowedResolutionTimeinMinutes = (string)returnData["Allowed Resolution Time in Minutes"];
            }







        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public csm_CaseHistory_trans csm_CaseHistory_trans_Get_By_ComplaintId(string ComplaintId)
    {
        return (csm_CaseHistory_trans)ExecuteReader(Sp_Get_csm_CaseHistory_trans_By_id, new object[] { ComplaintId }, new GenerateObjectFromReader(Generatecsm_CaseHistory_trans_mstObject));
    }
    public object Generatecsm_CaseHistory_trans_mstObject(ref IDataReader returnData)
    {
        csm_CaseHistory_trans obj = new csm_CaseHistory_trans();
        while (returnData.Read())
        {
            obj.ComplaintId = (string)returnData["ComplaintId"];
            obj.CallLogNotes = (string)returnData["CallLogNotes"];
            obj.CompId = (string)returnData["CompId"];
            obj.ComplaintStatus = (string)returnData["ComplaintStatus"];
            obj.EngineerId = (string)returnData["EngineerId"];
            obj.ItemId = (string)returnData["ItemId"];
            obj.OrgId = (string)returnData["OrgId"];
            obj.UserName = (string)returnData["UserName"];



            if (returnData["ChangedStatusDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ChangedStatusDate"];
                obj.ChangedStatusDate = Mydatetime.ToString();
            }
            if (returnData["PendingReason"] != DBNull.Value)
            {

                obj.PendingReason = (string)returnData["PendingReason"];
            }
            if (returnData["ComplaintDate "] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["ComplaintDate "];
                obj.ComplaintDate = Mydatetime.ToString();
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public IncidentResolution IncidentResolution_Get_By_incidentid(int incidentid)
    {
        return (IncidentResolution)ExecuteReader(Sp_Get_IncidentResolution_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateIncidentResolution_mstObject));
    }

    public object GenerateIncidentResolution_mstObject(ref IDataReader returnData)
    {
        IncidentResolution obj = new IncidentResolution();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Userid = (int)returnData["Userid"];
            obj.Resolution = (string)returnData["Resolution"];
            if (returnData["Lastupdatetime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["Lastupdatetime"];
                obj.Lastupdatetime = Mydatetime.ToString();
            }

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public RequestType_mst RequestType_mst_Get_By_RequestTypeid(int requesttypeid)
    {

        return (RequestType_mst)ExecuteReader(Sp_Get_RequestType_By_id, new object[] { requesttypeid }, new GenerateObjectFromReader(GenerateRequestType_mstObject));
    }

    public object GenerateRequestType_mstObject(ref IDataReader returnData)
    {
        RequestType_mst obj = new RequestType_mst();
        while (returnData.Read())
        {
            obj.Requesttypeid = (int)returnData["Requesttypeid"];
            obj.Requesttypename = (string)returnData["Requesttypename"];
            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Subcategory_mst Subcategory_mst_Get_By_subcategoryid(int subcategoryid)
    {

        return (Subcategory_mst)ExecuteReader(Sp_Get_Subcategory_By_id, new object[] { subcategoryid }, new GenerateObjectFromReader(GenerateSubCategory_mstObject));
    }

    public object GenerateSubCategory_mstObject(ref IDataReader returnData)
    {
        Subcategory_mst obj = new Subcategory_mst();
        while (returnData.Read())
        {
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.Subcategoryname = (string)returnData["Subcategoryname"];
            obj.Subcategorydescription = (string)returnData["Subcategorydescription"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public Mode_mst Mode_mst_Get_By_modeid(int modeid)
    {

        return (Mode_mst)ExecuteReader(Sp_Get_Mode_By_id, new object[] { modeid }, new GenerateObjectFromReader(GenerateMode_mstObject));
    }

    public object GenerateMode_mstObject(ref IDataReader returnData)
    {
        Mode_mst obj = new Mode_mst();
        while (returnData.Read())
        {
            obj.Modeid = (int)returnData["Modeid"];
            obj.Modename = (string)returnData["Modename"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public State_mst State_mst_Get_By_stateid(int stateid)
    {

        return (State_mst)ExecuteReader(Sp_Get_State_By_id, new object[] { stateid }, new GenerateObjectFromReader(GenerateState_mstObject));
    }

    public object GenerateState_mstObject(ref IDataReader returnData)
    {
        State_mst obj = new State_mst();
        while (returnData.Read())
        {
            obj.Countryid = (int)returnData["countryid"];
            obj.Stateid = (int)returnData["stateid"];
            obj.Statename = (string)returnData["statename"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public Status_mst Status_mst_Get_By_statusid(int statusid)
    {

        return (Status_mst)ExecuteReader(Sp_Get_Status_By_id, new object[] { statusid }, new GenerateObjectFromReader(GenerateStatus_mstObject));
    }


    public object GenerateStatus_mstObject(ref IDataReader returnData)
    {
        Status_mst obj = new Status_mst();
        while (returnData.Read())
        {
            obj.Statusid = (int)returnData["Statusid"];
            obj.Statusname = (string)returnData["Statusname"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ChangeStatus_mst ChangeStatus_mst_Get_By_changestatusid(int statusid)
    {

        return (ChangeStatus_mst)ExecuteReader(Sp_Get_ChangeStatus_By_id, new object[] { statusid }, new GenerateObjectFromReader(GenerateChangeStatus_mstObject));
    }


    public object GenerateChangeStatus_mstObject(ref IDataReader returnData)
    {
        ChangeStatus_mst obj = new ChangeStatus_mst();
        while (returnData.Read())
        {
            obj.ChangeStatusid = (int)returnData["changestatusid"];
            obj.Statusname = (string)returnData["statusname"];
            obj.Description = (string)returnData["description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ChangeType_mst ChangeType_mst_Get_By_ChangeTypeid(int ChangeTypeid)
    {

        return (ChangeType_mst)ExecuteReader(Sp_Get_ChangeType_By_ChangeTypeid, new object[] { ChangeTypeid }, new GenerateObjectFromReader(GenerateChangeType_mstObject));
    }


    public object GenerateChangeType_mstObject(ref IDataReader returnData)
    {
        ChangeType_mst obj = new ChangeType_mst();
        while (returnData.Read())
        {
            obj.Changetypeid = (int)returnData["changetypeid"];
            obj.Changetypename = (string)returnData["changetypename"];
            obj.Description = (string)returnData["description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Service_mst Service_mst_Get_By_serviceid(int serviceid)
    {

        return (Service_mst)ExecuteReader(Sp_Get_Service_By_id, new object[] { serviceid }, new GenerateObjectFromReader(GenerateService_mstObject));
    }

    public object GenerateService_mstObject(ref IDataReader returnData)
    {
        Service_mst obj = new Service_mst();
        while (returnData.Read())
        {
            obj.Serviceid = (int)returnData["serviceid"];
            obj.servicename = (string)returnData["servicename"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public SolutionCreator SolutionCreator_mst_Get_By_Solutionid(int Solutionid)
    {

        return (SolutionCreator)ExecuteReader(Sp_Get_SolutionCreator_By_id, new object[] { Solutionid }, new GenerateObjectFromReader(GenerateSolutionCreator_mstCollection_mstObject));
    }
    public object GenerateSolutionCreator_mstCollection_mstObject(ref IDataReader returnData)
    {
        SolutionCreator obj = new SolutionCreator();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["CreateDatetime"];
            DateTime Mydatetime1 = new DateTime();
            Mydatetime1 = (DateTime)returnData["CreateDatetime"];
            if (returnData["Solutionid"] != DBNull.Value)
            {
                obj.Solutionid = (int)returnData["Solutionid"];
            }
            if (returnData["CreatedBy"] != DBNull.Value)
            {
                obj.Createdby = (int)returnData["CreatedBy"];
            }
            if (returnData["CreateDatetime"] != DBNull.Value)
            {
                obj.CreateDatetime = Mydatetime.ToString();
            }

            if (returnData["LastUpdateBy"] != DBNull.Value)
            {
                obj.LastUpdateBy = (int)returnData["LastUpdateBy"];
            }
            if (returnData["LastUpdateon"] != DBNull.Value)
            {
                obj.LastUpdateon = Mydatetime1.ToString();
            }

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public SolutionKeyword SolutionKeyword_mst_Get_By_Solutionid(int Solutionid)
    {

        return (SolutionKeyword)ExecuteReader(Sp_Get_SolutionKeyword_By_id, new object[] { Solutionid }, new GenerateObjectFromReader(GenerateSolutionKeyword_mstCollection_mstObject));
    }
    public object GenerateSolutionKeyword_mstCollection_mstObject(ref IDataReader returnData)
    {
        SolutionKeyword obj = new SolutionKeyword();
        while (returnData.Read())
        {

            obj.Keywordid = (int)returnData["Keywordid"];
            obj.Solutionid = (int)returnData["Solutionid"];
            obj.Keywords = (string)returnData["keywords"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Solution_mst Solution_mst_Get_By_Solutionid(int Solutionid)
    {
        return (Solution_mst)ExecuteReader(Sp_Get_Solution_By_id, new object[] { Solutionid }, new GenerateObjectFromReader(GenerateSolution_mstObject));

    }
    public Object GenerateSolution_mstObject(ref IDataReader returnData)
    {
        Solution_mst obj = new Solution_mst();
        while (returnData.Read())
        {



            if (returnData["Solutionid"] != DBNull.Value)
            {
                obj.Solutionid = (int)returnData["Solutionid"];
            }
            if (returnData["Title"] != DBNull.Value)
            {
                obj.Title = (string)returnData["Title"];
            }
            if (returnData["Content"] != DBNull.Value)
            {
                obj.Content = (string)returnData["Content"];
            }

            if (returnData["Solution"] != DBNull.Value)
            {
                obj.Solution = (string)returnData["Solution"];
            }
            if (returnData["Topicid"] != DBNull.Value)
            {
                obj.Topicid = (int)returnData["Topicid"];
            }
            if (returnData["Comments"] != DBNull.Value)
            {
                obj.Comments = (string)returnData["Comments"];
            }
            if (returnData["Solutionstatusid"] != DBNull.Value)
            {
                obj.SolutionStatus = (int)returnData["Solutionstatusid"];
            }





        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public IncidentHistoryDiff IncidentHistoryDiff_mst_Get_By_historydiffid(int historydiffid)
    {

        return (IncidentHistoryDiff)ExecuteReader(Sp_Get_IncidentHistoryDiff_By_id, new object[] { historydiffid }, new GenerateObjectFromReader(GenerateIncidentHistoryDiff_mstObject));
    }

    public object GenerateIncidentHistoryDiff_mstObject(ref IDataReader returnData)
    {
        IncidentHistoryDiff obj = new IncidentHistoryDiff();
        while (returnData.Read())
        {

            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Prev_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ProblemHistoryDiff ProblemHistoryDiff_mst_Get_By_historydiffid(int historydiffid)
    {

        return (ProblemHistoryDiff)ExecuteReader(Sp_Get_ProblemHistoryDiff_By_id, new object[] { historydiffid }, new GenerateObjectFromReader(GenerateProblemHistoryDiff_mstObject));
    }
    public object GenerateProblemHistoryDiff_mstObject(ref IDataReader returnData)
    {
        ProblemHistoryDiff obj = new ProblemHistoryDiff();
        while (returnData.Read())
        {

            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Prev_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ChangeHistoryDiff ChangeHistoryDiff_mst_Get_By_historydiffid(int historydiffid)
    {

        return (ChangeHistoryDiff)ExecuteReader(Sp_Get_ChangeHistoryDiff_By_id, new object[] { historydiffid }, new GenerateObjectFromReader(GenerateChangeHistoryDiff_mstObject));
    }
    public object GenerateChangeHistoryDiff_mstObject(ref IDataReader returnData)
    {
        ChangeHistoryDiff obj = new ChangeHistoryDiff();
        while (returnData.Read())
        {

            obj.Historyid = (int)returnData["Historyid"];
            obj.Historydiffid = (int)returnData["Historydiffid"];
            obj.Prev_value = (string)returnData["Prev_value"];
            obj.Current_value = (string)returnData["Current_value"];
            obj.Columnname = (string)returnData["Columnname"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public IncidentHistory IncidentHistory_mst_Get_By_historyid(int historyid)
    {

        return (IncidentHistory)ExecuteReader(Sp_Get_IncidentHistory_By_id, new object[] { historyid }, new GenerateObjectFromReader(GenerateIncidentHistory_mstObject));
    }


    public object GenerateIncidentHistory_mstObject(ref IDataReader returnData)
    {
        IncidentHistory obj = new IncidentHistory();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Operationtime"];
            obj.Operationtime = Mydatetime.ToString();
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Historyid = (int)returnData["Historyid"];
            obj.Operationownerid = (int)returnData["Operationownerid"];
            obj.Operation = (string)returnData["Operation"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public IncidentStates IncidentStates_mst_Get_By_incidentid(int incidentid)
    {

        return (IncidentStates)ExecuteReader(Sp_Get_IncidentStates_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateIncidentStates_mstObject));
    }

    public object GenerateIncidentStates_mstObject(ref IDataReader returnData)
    {
        IncidentStates obj = new IncidentStates();
        while (returnData.Read())
        {
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.Technicianid = (int)returnData["Technicianid"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Requesttypeid = (int)returnData["Requesttypeid"];
            obj.Reqapproval = (bool)returnData["Reqapproval"];
            obj.Reopened = (bool)returnData["Reopened"];
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Isescalated = (bool)returnData["Isescalated"];
            obj.Impactid = (int)returnData["Impactid"];
            obj.Hasattachment = (bool)returnData["Hasattachment"];
            if (returnData["Closecomments"] != DBNull.Value)
            {
                obj.Closecomments = (string)returnData["Closecomments"];
            }
            if (returnData["Closeaccepted"] != DBNull.Value)
            {
                obj.Closeaccepted = (string)returnData["Closeaccepted"];
            }
            if (returnData["AssignedTime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["AssignedTime"];
                obj.AssignedTime = Mydatetime.ToString();
            }




        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public CMDB CMDB_mst_Get_By_Assetid(int assetid)
    {

        return (CMDB)ExecuteReader(Sp_Get_CMDBAsset_By_Assetid, new object[] { assetid }, new GenerateObjectFromReader(GenerateCMDBAsset_Byid_mstObject));
    }
    public object GenerateCMDBAsset_Byid_mstObject(ref IDataReader returnData)
    {
        CMDB Obj = new CMDB();
        while (returnData.Read())
        {
            Obj.Assetid = (int)returnData["Assetid"];
            if (returnData["Param1"] != DBNull.Value)
            {

                Obj.Param1 = (string)returnData["Param1"];

            }
            if (returnData["Param2"] != DBNull.Value)
            {

                Obj.Param2 = (string)returnData["Param2"];

            }
            if (returnData["Param3"] != DBNull.Value)
            {

                Obj.Param3 = (string)returnData["Param3"];

            }
            if (returnData["Param4"] != DBNull.Value)
            {

                Obj.Param4 = (string)returnData["Param4"];

            }
            if (returnData["Param5"] != DBNull.Value)
            {

                Obj.Param5 = (string)returnData["Param5"];

            }
            if (returnData["Param6"] != DBNull.Value)
            {

                Obj.Param6 = (string)returnData["Param6"];

            }
            if (returnData["Param7"] != DBNull.Value)
            {

                Obj.Param7 = (string)returnData["Param7"];

            }
            if (returnData["Param8"] != DBNull.Value)
            {

                Obj.Param8 = (string)returnData["Param8"];

            }
            if (returnData["Param9"] != DBNull.Value)
            {

                Obj.Param9 = (string)returnData["Param9"];

            }
            if (returnData["Param10"] != DBNull.Value)
            {

                Obj.Param10 = (string)returnData["Param10"];

            }
            if (returnData["Param11"] != DBNull.Value)
            {

                Obj.Param11 = (string)returnData["Param11"];

            }
            if (returnData["Param12"] != DBNull.Value)
            {

                Obj.Param12 = (string)returnData["Param12"];

            }
            if (returnData["Param13"] != DBNull.Value)
            {

                Obj.Param13 = (string)returnData["Param13"];

            }
            if (returnData["Param14"] != DBNull.Value)
            {

                Obj.Param14 = (string)returnData["Param14"];

            }
            if (returnData["Param15"] != DBNull.Value)
            {

                Obj.Param15 = (string)returnData["Param15"];

            }
        }
        returnData.Close();
        returnData.Dispose();
        return Obj;
    }

    public CustomerFeedback CustomerFeedback_mst_Get_By_Userid_Incidentid(int userid, int incidentid)
    {

        return (CustomerFeedback)ExecuteReader(Sp_GetCustomerFeedback__By_incidentid_mst_By_Call, new object[] { userid, incidentid }, new GenerateObjectFromReader(GenerateCustomerFeedback_incidentid_mstObject_Usermst));
    }

    public object GenerateCustomerFeedback_incidentid_mstObject_Usermst(ref IDataReader returnData)
    {
        CustomerFeedback Obj = new CustomerFeedback();
        while (returnData.Read())
        {
            Obj.Id = (int)returnData["ID"];
            Obj.Feedback = (string)returnData["Feedback"];
            Obj.IncidentId = (int)returnData["incidentid"];
            Obj.Remark = (string)returnData["Remark"];
       }
        returnData.Close();
        returnData.Dispose();
        return Obj;
    }
    //added by lalit
    public int Insert_CustomerFeedback_mst_callwise(CustomerFeedback ObjCustomerFeedback)
    {
        return (int)ExecuteNonQuery(Sp_CustomerFeedback_Insert_mst_callwise, new object[] { ObjCustomerFeedback.Id, ObjCustomerFeedback.Feedback, ObjCustomerFeedback.IncidentId, ObjCustomerFeedback.Remark, ObjCustomerFeedback.FeedbackType });
    }
    public Configuration_mst Asset_mst_Get_By_Assetid(int assetid)
    {

        return (Configuration_mst)ExecuteReader(Sp_Get_CMDBAsset_By_id, new object[] { assetid }, new GenerateObjectFromReader(GenerateCMDBAsset_mstObject));
    }
    public object GenerateCMDBAsset_mstObject(ref IDataReader returnData)
    {
        Configuration_mst obj = new Configuration_mst();
        while (returnData.Read())
        {

            obj.Assetid = (int)returnData["Assetid"];
            obj.Serialno = (string)returnData["Serialno"];
            obj.Itemid = (int)returnData["Itemid"];
            obj.Vendorid = (int)returnData["VendorId"];
            obj.Version = (int)returnData["Version"];
            if (returnData["Warranty"] != DBNull.Value)
            {

                obj.Warranty = (string)returnData["Warranty"];

            }

            obj.Siteid = (int)returnData["Siteid"];
            obj.Severity = (string)returnData["Severity"];

            if (returnData["PurchaseDate"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["PurchaseDate"];
                obj.Purchasedate = Mydatetime.ToString();

            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public CustomerFeedback CustomerFeedback_mst_Get_By_Incidentid(int incidentid)
    {

        return (CustomerFeedback)ExecuteReader(Sp_GetCustomerFeedback__By_incidentid, new object[] { incidentid }, new GenerateObjectFromReader(GenerateCustomerFeedback_incidentid_mstObject));
    }
    public object GenerateCustomerFeedback_incidentid_mstObject(ref IDataReader returnData)
    {
        CustomerFeedback Obj = new CustomerFeedback();
        while (returnData.Read())
        {
            Obj.Id = (int)returnData["ID"];
            Obj.Feedback = (string)returnData["Feedback"];



        }
        returnData.Close();
        returnData.Dispose();
        return Obj;
    }
    public Incident_To_Change Incident_To_Change_mst_Get_By_Incidentid(int incidentid)
    {

        return (Incident_To_Change)ExecuteReader(Sp_Get_Incident_To_Change_By_incidentid, new object[] { incidentid }, new GenerateObjectFromReader(GenerateIncidet_to_change_incidentid_mstObject));
    }
    public object GenerateIncidet_to_change_incidentid_mstObject(ref IDataReader returnData)
    {
        Incident_To_Change Obj = new Incident_To_Change();
        while (returnData.Read())
        {
            Obj.Changeid = (int)returnData["Changeid"];
            Obj.Incidentid = (int)returnData["Incidentid"];


        }
        returnData.Close();
        returnData.Dispose();
        return Obj;
    }
    public IncludedAssetinchange IncludeAsset_mst_Get_By_changeid(int changeid)
    {

        return (IncludedAssetinchange)ExecuteReader(Sp_Get_IncludeAsset_By_changeidid, new object[] { changeid }, new GenerateObjectFromReader(Generateincludeasset_mstObject));
    }
    public object Generateincludeasset_mstObject(ref IDataReader returnData)
    {
        IncludedAssetinchange Obj = new IncludedAssetinchange();
        while (returnData.Read())
        {

            Obj.Changeid = (int)returnData["Changeid"];
            Obj.Assetid = (int)returnData["Assetid"];
        }
        returnData.Close();
        returnData.Dispose();
        return Obj;
    }
    public Problem_mst Problem_mst_Get_By_problemid(int problemid)
    {

        return (Problem_mst)ExecuteReader(Sp_Get_Problem_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblem_mstObject));
    }
    public object GenerateProblem_mstObject(ref IDataReader returnData)
    {
        Problem_mst obj = new Problem_mst();
        while (returnData.Read())
        {
            obj.ProblemId = (int)returnData["ProblemId"];
            obj.CreatedByid = (int)returnData["CreatedByid"];
            obj.Requesterid = (int)returnData["Requesterid"];
            obj.Technicianid = (int)returnData["Technicianid"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.title = (string)returnData["title"];

            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }
            if (returnData["CreateDatetime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["CreateDatetime"];
                obj.CreateDatetime = Mydatetime.ToString();
            }
            if (returnData["Closedatetime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["Closedatetime"];
                obj.Closedatetime = Mydatetime1.ToString();

            }
            if (returnData["CompletedTime"] != DBNull.Value)
            {
                DateTime Mydatetime2 = new DateTime();
                Mydatetime2 = (DateTime)returnData["CompletedTime"];
                obj.CompletedTime = Mydatetime2.ToString();
            }
            if (returnData["AssignedTime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["AssignedTime"];
                obj.AssginedTime = Mydatetime3.ToString();
            }

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ConfigurableItems_mst Configurableitem_mst_Get_By_item(int itemid)
    {
        return (ConfigurableItems_mst)ExecuteReader(Sp_Get_Configurableitem_By_id, new object[] { itemid }, new GenerateObjectFromReader(GenerateConfigurableitem_mstObject));
    }
    public object GenerateConfigurableitem_mstObject(ref IDataReader returnData)
    {


        ConfigurableItems_mst obj = new ConfigurableItems_mst();
        while (returnData.Read())
        {


            obj.Itemid = (int)returnData["Itemid"];





            if (returnData["Param1"] != DBNull.Value)
            {
                obj.Param1 = (string)returnData["Param1"];
            }
            if (returnData["Param2"] != DBNull.Value)
            {
                obj.Param2 = (string)returnData["Param2"];
            }
            if (returnData["Param3"] != DBNull.Value)
            {
                obj.Param3 = (string)returnData["Param3"];
            }
            if (returnData["Param4"] != DBNull.Value)
            {
                obj.Param4 = (string)returnData["Param4"];
            }
            if (returnData["Param5"] != DBNull.Value)
            {
                obj.Param5 = (string)returnData["Param5"];
            }
            if (returnData["Param6"] != DBNull.Value)
            {
                obj.Param6 = (string)returnData["Param6"];
            }
            if (returnData["Param7"] != DBNull.Value)
            {
                obj.Param7 = (string)returnData["Param7"];
            }
            if (returnData["Param8"] != DBNull.Value)
            {
                obj.Param8 = (string)returnData["Param8"];
            }
            if (returnData["Param9"] != DBNull.Value)
            {
                obj.Param9 = (string)returnData["Param9"];
            }
            if (returnData["Param10"] != DBNull.Value)
            {
                obj.Param10 = (string)returnData["Param10"];
            }
            if (returnData["Param11"] != DBNull.Value)
            {
                obj.Param11 = (string)returnData["Param11"];
            }
            if (returnData["Param12"] != DBNull.Value)
            {
                obj.Param12 = (string)returnData["Param12"];
            }
            if (returnData["Param13"] != DBNull.Value)
            {
                obj.Param13 = (string)returnData["Param13"];
            }
            if (returnData["Param14"] != DBNull.Value)
            {
                obj.Param14 = (string)returnData["Param14"];
            }
            if (returnData["Param15"] != DBNull.Value)
            {
                obj.Param15 = (string)returnData["Param15"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public Change_mst Change_mst_Get_By_changeid(int changeid)
    {
        return (Change_mst)ExecuteReader(Sp_Get_Change_By_id, new object[] { changeid }, new GenerateObjectFromReader(GenerateChange_mstObject));
    }
    public object GenerateChange_mstObject(ref IDataReader returnData)
    {

        Change_mst obj = new Change_mst();
        while (returnData.Read())
        {



            obj.Changeid = (int)returnData["Changeid"];
            obj.Active = (bool)returnData["Active"];
            obj.Approvalstatus = (string)returnData["ApprovalStatus"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Subcategoryid = (int)returnData["Subcategoryid"];
            obj.Changetype = (int)returnData["ChangeType"];
            obj.Requestedby = (int)returnData["RequestedBy"];
            obj.Statusid = (int)returnData["Statusid"];
            obj.Technician = (int)returnData["Technician"];
            obj.Priority = (int)returnData["Priority"];
            obj.Impact = (int)returnData["Impact"];
            obj.CreatedByID = (int)returnData["CreatedBy"];
            //////////////////////////////change dne by meenakshi 4th oct
           // obj.servicename = (string)returnData["servicename"];
            if (returnData["servicename"] != DBNull.Value)
            {
                obj.servicename = (string)returnData["servicename"];
            }
            ////////////////////////////////////////end

            obj.Title = (string)returnData["Title"];

            if (returnData["Description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["Description"];
            }

            if (returnData["CreatedTime"] != DBNull.Value)
            {
                DateTime Mydatetime = new DateTime();
                Mydatetime = (DateTime)returnData["CreatedTime"];
                obj.Createdtime = Mydatetime.ToString();
            }
            if (returnData["CompletedTime"] != DBNull.Value)
            {
                DateTime Mydatetime1 = new DateTime();
                Mydatetime1 = (DateTime)returnData["CompletedTime"];
                obj.Completedtime = Mydatetime1.ToString();

            }

            if (returnData["Assignetime"] != DBNull.Value)
            {
                DateTime Mydatetime3 = new DateTime();
                Mydatetime3 = (DateTime)returnData["Assignetime"];
                obj.Assignetime = Mydatetime3.ToString();
            }
            if (returnData["Sceduledstarttime"] != DBNull.Value)
            {
                DateTime Mydatetime4 = new DateTime();
                Mydatetime4 = (DateTime)returnData["Sceduledstarttime"];
                obj.Sceduledstarttime = Mydatetime4.ToString();
            }

            if (returnData["Sceduledendtime"] != DBNull.Value)
            {
                DateTime Mydatetime5 = new DateTime();
                Mydatetime5 = (DateTime)returnData["Sceduledendtime"];
                obj.Sceduledendtime = Mydatetime5.ToString();
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ProblemToSolution ProblemTosolution_mst_Get_By_problemid(int problemid)
    {

        return (ProblemToSolution)ExecuteReader(Sp_Get_ProblemToSolution_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblemToSolution_mstObject));
    }
    public object GenerateProblemToSolution_mstObject(ref IDataReader returnData)
    {
        ProblemToSolution obj = new ProblemToSolution();
        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["ProblemId"];
            obj.WorkAroundid = (int)returnData["WorkAroundid"];
            obj.Solutionid = (int)returnData["Solutionid"];
            obj.Solutiontype = (string)returnData["Solutiontype"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ProblemAnalysis ProblemAnalysis_mst_Get_By_problemid(int problemid)
    {

        return (ProblemAnalysis)ExecuteReader(Sp_Get_ProblemAnalysis_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblemAnalysis_mstObject));
    }
    public object GenerateProblemAnalysis_mstObject(ref IDataReader returnData)
    {
        ProblemAnalysis obj = new ProblemAnalysis();
        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["Problemid"];
            obj.Impact = (string)returnData["Impact"];
            obj.RootCause = (string)returnData["RootCause"];
            obj.Symtom = (string)returnData["Symptoms"];
            if (returnData["Symptoms"] != DBNull.Value)
            {

                obj.Symtom = (string)returnData["Symptoms"];
            }
            if (returnData["RootCause"] != DBNull.Value)
            {

                obj.RootCause = (string)returnData["RootCause"];
            }
            if (returnData["Symtom"] != DBNull.Value)
            {

                obj.Symtom = (string)returnData["Symtom"];
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ProblemSymptom ProblemSymptom_mst_Get_By_problemid(int problemid)
    {

        return (ProblemSymptom)ExecuteReader(Sp_Get_ProblemSymptom_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblemSymptom_mstObject));
    }
    public object GenerateProblemSymptom_mstObject(ref IDataReader returnData)
    {
        ProblemSymptom obj = new ProblemSymptom();
        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["Problemid"];
            obj.Symtomid = (int)returnData["Symptomid"];

            if (returnData["Description"] != DBNull.Value)
            {

                obj.Description = (string)returnData["Description"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ProblemRootcause ProblemRootcause_mst_Get_By_problemid(int problemid)
    {

        return (ProblemRootcause)ExecuteReader(Sp_Get_ProblemRootcause_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblemRootcause_mstObject));
    }
    public object GenerateProblemRootcause_mstObject(ref IDataReader returnData)
    {
        ProblemRootcause obj = new ProblemRootcause();
        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["Problemid"];
            obj.Rootcauseid = (int)returnData["Rootcauseid"];

            if (returnData["Description"] != DBNull.Value)
            {

                obj.Description = (string)returnData["Description"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ProblemImpact ProblemImpact_mst_Get_By_problemid(int problemid)
    {

        return (ProblemImpact)ExecuteReader(Sp_Get_ProblemImpact_By_id, new object[] { problemid }, new GenerateObjectFromReader(GenerateProblemImpact_mstObject));
    }

    public object GenerateProblemImpact_mstObject(ref IDataReader returnData)
    {
        ProblemImpact obj = new ProblemImpact();
        while (returnData.Read())
        {
            obj.Problemid = (int)returnData["Problemid"];
            obj.Impactid = (int)returnData["Impactid"];

            if (returnData["Description"] != DBNull.Value)
            {

                obj.Description = (string)returnData["Description"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ChangeBackoutPlan ChangeBackoutPlan_mst_Get_By_changeid(int changeid)
    {

        return (ChangeBackoutPlan)ExecuteReader(Sp_Get_ChangeBackoutPlan_By_id, new object[] { changeid }, new GenerateObjectFromReader(GenerateChangeBackoutPlan_mstObject));
    }

    public object GenerateChangeBackoutPlan_mstObject(ref IDataReader returnData)
    {
        ChangeBackoutPlan obj = new ChangeBackoutPlan();
        while (returnData.Read())
        {
            obj.Changeid = (int)returnData["Changeid"];

            obj.Backoutid = (int)returnData["Backoutid"];

            if (returnData["Description"] != DBNull.Value)
            {

                obj.Descripion = (string)returnData["Description"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ChangeRollOut ChangeRollOut_mst_Get_By_changeid(int changeid)
    {

        return (ChangeRollOut)ExecuteReader(Sp_Get_ChangeRollOut_By_id, new object[] { changeid }, new GenerateObjectFromReader(GenerateChangeRollOut_mstObject));
    }

    public object GenerateChangeRollOut_mstObject(ref IDataReader returnData)
    {
        ChangeRollOut obj = new ChangeRollOut();
        while (returnData.Read())
        {
            obj.Changeid = (int)returnData["Changeid"];

            obj.Rolloutid = (int)returnData["Rolloutid"];

            if (returnData["Description"] != DBNull.Value)
            {

                obj.Description = (string)returnData["Description"];
            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public ChangeImpact ChangeImpact_mst_Get_By_changeid(int changeid)
    {

        return (ChangeImpact)ExecuteReader(Sp_Get_ChangeImpact_By_id, new object[] { changeid }, new GenerateObjectFromReader(GenerateChangeImpact_mstObject));
    }

    public object GenerateChangeImpact_mstObject(ref IDataReader returnData)
    {
        ChangeImpact obj = new ChangeImpact();
        while (returnData.Read())
        {
            obj.Changeid = (int)returnData["Changeid"];
            obj.Impactid = (int)returnData["Impactid"];


            if (returnData["Description"] != DBNull.Value)
            {

                obj.Description = (string)returnData["Description"];

            }



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public Incident_mst Incident_mst_Get_By_incidentid(int incidentid)
    {

        return (Incident_mst)ExecuteReader(Sp_Get_Incident_By_id, new object[] { incidentid }, new GenerateObjectFromReader(GenerateIncident_mstObject));
    }

    public object GenerateIncident_mstObject(ref IDataReader returnData)
    {
        Incident_mst obj = new Incident_mst();
        while (returnData.Read())
        {
            obj.Incidentid = (int)returnData["Incidentid"];
            obj.Title = (String)returnData["Title"];
            if (returnData["Extension"] != DBNull.Value)
            {
                obj.Extension = Convert.ToInt64(returnData["Extension"]); //uncommented by lalit
            }
            //if (returnData["Extension"].ToString().Length > 0)
            //{
            //    obj.Extension = (int)returnData["Extension"];
            //}
            //else
            //{
            //    obj.Extension = 0;
            //}
            if (returnData["AMCCall"] != DBNull.Value)
            {
                obj.AMCCall = (bool)returnData["AMCCall"];
            }
            obj.Timespentonreq = (int)returnData["Timespentonreq"];
            obj.Slaid = (int)returnData["Slaid"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Requesterid = (int)returnData["Requesterid"];
            obj.Modeid = (int)returnData["Modeid"];
            if (returnData["Description"] != DBNull.Value)
            { obj.Description = (String)returnData["Description"]; }

            obj.Deptid = (int)returnData["Deptid"];
            obj.Createdbyid = (int)returnData["Createdbyid"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            DateTime Complettime = new DateTime();
            if (returnData["Completedtime"] != DBNull.Value)
            {
                Complettime = (DateTime)returnData["Completedtime"];
                obj.Completedtime = Complettime.ToString();
            }
            if (returnData["ExternalTicketNo"] != DBNull.Value)
            {
                obj.ExternalTicketNo = (String)returnData["ExternalTicketNo"];
            }

            if (returnData["VendorId"] != DBNull.Value)
            {
                obj.VendorId = (int)returnData["VendorId"];
            }
            if (returnData["Reporteddatetime"] != DBNull.Value)
            {
                DateTime reporteddatetime = new DateTime();
                reporteddatetime = (DateTime)returnData["Reporteddatetime"];
                obj.Reporteddatetime = reporteddatetime.ToString("dd/MM/yyyy hh:mm:ss tt");
            }

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Impact_mst Impact_mst_Get_By_Impactid(int impactid)
    {

        return (Impact_mst)ExecuteReader(Sp_Get_Impact_By_id, new object[] { impactid }, new GenerateObjectFromReader(GenerateImpact_mstObject));
    }

    public object GenerateImpact_mstObject(ref IDataReader returnData)
    {
        Impact_mst obj = new Impact_mst();
        while (returnData.Read())
        {
            obj.Impactid = (int)returnData["impactid"];
            obj.Impactname = (string)returnData["impactname"];
            obj.Description = (string)returnData["description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Priority_mst Get_Priority_By_priorityid(int priorityid)
    {

        return (Priority_mst)ExecuteReader(Sp_Get_Priority_By_priorityid, new object[] { priorityid }, new GenerateObjectFromReader(GeneratePriority_mstObject));
    }

    public object GeneratePriority_mstObject(ref IDataReader returnData)
    {
        Priority_mst obj = new Priority_mst();
        while (returnData.Read())
        {


            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Name = (string)returnData["Name"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public SLA_mst SLA_mst_Get_By_Slaid(int Slaid)
    {

        return (SLA_mst)ExecuteReader(Sp_Get_SLA_By_id, new object[] { Slaid }, new GenerateObjectFromReader(GenerateSLA_mstObject));
    }





    public Department_mst Department_mst_Get_By_deptid(int deptid)
    {

        return (Department_mst)ExecuteReader(Sp_Get_Department_By_id, new object[] { deptid }, new GenerateObjectFromReader(GenerateDepartment_mstObject));
    }

    public object GenerateDepartment_mstObject(ref IDataReader returnData)
    {
        Department_mst obj = new Department_mst();
        while (returnData.Read())
        {
            obj.Siteid = (int)returnData["Siteid"];
            obj.Deptid = (int)returnData["Deptid"];
            obj.Departmentname = (string)returnData["Departmentname"];
            obj.Description = (string)returnData["Description"];
            //obj.Company = (string)returnData["Company"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public BLLCollection<ServiceDay_mst> Get_ServiceDay_mst_All_By_Id(int servicewindowid)
    {

        return (BLLCollection<ServiceDay_mst>)ExecuteReader(Sp_Get_ServiceDay_All, new object[] { servicewindowid }, new GenerateCollectionFromReader(GenerateServiceDay_mstCollection));
    }

    public CollectionBase GenerateServiceDay_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<ServiceDay_mst> col = new BLLCollection<ServiceDay_mst>();
        while (returnData.Read())
        {
            ServiceDay_mst obj = new ServiceDay_mst();
            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Weekday = (string)returnData["Weekday"];
            obj.Isworking = (bool)returnData["Isworking"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }



    public Servicehours_mst Servicehours_mst_Get_By_servicewindowid(int servicewindowid)
    {

        return (Servicehours_mst)ExecuteReader(Sp_Get_Servicehours_By_id, new object[] { servicewindowid }, new GenerateObjectFromReader(GenerateServicehours_mstObject));
    }

    public object GenerateServicehours_mstObject(ref IDataReader returnData)
    {
        Servicehours_mst obj = new Servicehours_mst();
        while (returnData.Read())
        {

            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Starthour = (int)returnData["Starthour"];
            obj.Startmin = (int)returnData["Startmin"];
            obj.Endhour = (int)returnData["Endhour"];
            obj.Endmin = (int)returnData["Endmin"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public ServiceWindow_mst ServiceWindow_mst_Get_By_Siteid(int siteid)
    {

        return (ServiceWindow_mst)ExecuteReader(Sp_Get_ServiceWindow_By_id, new object[] { siteid }, new GenerateObjectFromReader(GenerateServiceWindow_mstObject));
    }

    public object GenerateServiceWindow_mstObject(ref IDataReader returnData)
    {
        ServiceWindow_mst obj = new ServiceWindow_mst();
        while (returnData.Read())
        {

            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Siteid = (int)returnData["Siteid"];



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ServiceWindow_mst ServiceWindow_mst_Get_By_serviceid(int serviceid)
    {
        return (ServiceWindow_mst)ExecuteReader(Sp_Get_ServiceWindow_By_serviceid, new object[] { serviceid }, new GenerateObjectFromReader(GenerateServiceWindowId_mstObject));
    }

    public object GenerateServiceWindowId_mstObject(ref IDataReader returnData)
    {
        ServiceWindow_mst obj = new ServiceWindow_mst();
        while (returnData.Read())
        {

            obj.Servicewindowid = (int)returnData["Servicewindowid"];
            obj.Siteid = (int)returnData["Siteid"];



        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public RoleInfo_mst RoleInfo_mst_Get_By_Roleid(int roleid)
    {

        return (RoleInfo_mst)ExecuteReader(Sp_Get_RoleInfo_By_id, new object[] { roleid }, new GenerateObjectFromReader(GenerateRoleInfo_mstObject));
    }

    public object GenerateRoleInfo_mstObject(ref IDataReader returnData)
    {
        RoleInfo_mst obj = new RoleInfo_mst();
        while (returnData.Read())
        {

            obj.Roleid = (int)returnData["Roleid"];
            obj.Rolename = (string)returnData["Rolename"];
            obj.Description = (string)returnData["Description"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Organization_mst Organization_mst_Get_By_Orgid(int orgid)
    {

        return (Organization_mst)ExecuteReader(Sp_Get_Organization_By_id, new object[] { orgid }, new GenerateObjectFromReader(GenerateOrganization_mstObject));
    }

    public object GenerateOrganization_mstObject(ref IDataReader returnData)
    {
        Organization_mst obj = new Organization_mst();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            obj.Orgid = (int)returnData["Orgid"];
            obj.Orgname = (string)returnData["Orgname"];
            obj.Description = (string)returnData["Description"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public Country_mst Country_mst_Get_By_countryid(int countryid)
    {

        return (Country_mst)ExecuteReader(Sp_Get_Country_By_id, new object[] { countryid }, new GenerateObjectFromReader(GenerateCountry_mstObject));
    }

    public object GenerateCountry_mstObject(ref IDataReader returnData)
    {
        Country_mst obj = new Country_mst();
        while (returnData.Read())
        {

            obj.Countryid = (int)returnData["Countryid"];
            obj.Countryname = (string)returnData["Countryname"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public Region_mst Region_mst_Get_By_regionid(int regionid)
    {

        return (Region_mst)ExecuteReader(Sp_Get_Region_By_id, new object[] { regionid }, new GenerateObjectFromReader(GenerateRegion_mstObject));
    }

    public object GenerateRegion_mstObject(ref IDataReader returnData)
    {
        Region_mst obj = new Region_mst();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            obj.Regionid = (int)returnData["Regionid"];
            obj.Regionname = (string)returnData["Regionname"];
            obj.Description = (string)returnData["Description"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Site_mst Site_mst_Get_By_Siteid(int Siteid)
    {
        return (Site_mst)ExecuteReader(Sp_Get_Site_By_id, new object[] { Siteid }, new GenerateObjectFromReader(GenerateSite_mstObject));
    }

    public object GenerateSite_mstObject(ref IDataReader returnData)
    {
        Site_mst obj = new Site_mst();
        while (returnData.Read())
        {
            obj.Siteid = (int)returnData["Siteid"];
            obj.Sitename = (string)returnData["Sitename"];
            obj.Regionid = (int)returnData["Regionid"];
            obj.Address = (string)returnData["Address"];
            obj.City = (string)returnData["City"];
            obj.Contactpersonname = (string)returnData["Contactpersonname"];
            obj.Countryid = (int)returnData["Countryid"];
            obj.Description = (string)returnData["Description"];
            obj.Emailid = (string)returnData["Emailid"];
            obj.Faxno = (string)returnData["Faxno"];
            obj.Mobileno = (string)returnData["Mobileno"];
            obj.Phoneno = (string)returnData["Phoneno"];
            obj.Postalcode = (string)returnData["Postalcode"];
            obj.State = (string)returnData["State"];
            obj.Timezoneid = (int)returnData["Timezoneid"];
            obj.Website = (string)returnData["Website"];
            obj.Enable = (bool)returnData["Enable"];
            DateTime Mydatetime = new DateTime();
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    //add hub to site mapping
    public HubToSiteMapping Hub_mst_Get_By_Siteid(int Siteid)
    {

        return (HubToSiteMapping)ExecuteReader(Sp_Get_Hub_BySiteid, new object[] { Siteid }, new GenerateObjectFromReader(GenerateHubTositemapping_mstObject));
    }
    public object GenerateHubTositemapping_mstObject(ref IDataReader returnData)
    {
        HubToSiteMapping obj = new HubToSiteMapping();
        while (returnData.Read())
        {
            obj.Hubid = (int)returnData["Hubid"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    public HubToSiteMapping Hub_mst_Get_By_Site_Hub_id(int Siteid, int Hubid)
    {
        return (HubToSiteMapping)ExecuteReader(Sp_Get_Hub_BySite_Hub_id, new object[] { Siteid, Hubid }, new GenerateObjectFromReader(GenerateHubTositehubmapping_mstObject));
    }
    public object GenerateHubTositehubmapping_mstObject(ref IDataReader returnData)
    {
        HubToSiteMapping obj = new HubToSiteMapping();
        while (returnData.Read())
        {
            obj.Hubid = (int)returnData["Hubid"];
            obj.Siteid = (int)returnData["Siteid"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    //end



    public UserEmail UserEmail_mst_Get_By_userid(int userid)
    {

        return (UserEmail)ExecuteReader(Sp_Get_UserEmail_By_id, new object[] { userid }, new GenerateObjectFromReader(GenerateUserEmail_mstObject));
    }
    public object GenerateUserEmail_mstObject(ref IDataReader returnData)
    {
        UserEmail obj = new UserEmail();
        while (returnData.Read())
        {
            obj.Userid = (int)returnData["userid"];
            obj.Emailid = (string)returnData["emailid"];
            obj.Active = (int)returnData["Active"];


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public UserLogin_mst UserLogin_mst_Get_By_userid(int userid)
    {

        return (UserLogin_mst)ExecuteReader(Sp_Get_User_By_id, new object[] { userid }, new GenerateObjectFromReader(GenerateUser_mstObject));
    }

    public object GenerateUser_mstObject(ref IDataReader returnData)
    {
        UserLogin_mst obj = new UserLogin_mst();
        while (returnData.Read())
        {
            obj.Password = (string)returnData["Password"];
            obj.Userid = (int)returnData["userid"];
            obj.Username = (string)returnData["username"];
            obj.Roleid = (int)returnData["Roleid"];
            obj.Orgid = (int)returnData["Orgid"];
            obj.Enable = (bool)returnData["Enable"];
            obj.ADEnable = (bool)returnData["ADEnable"];
            if (returnData["Company"] != DBNull.Value)
            {
                obj.Company = (string)returnData["Company"];
            }
            if (returnData["City"] != DBNull.Value)
            {
                obj.City = (string)returnData["City"];
            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public ContactInfo_mst ContactInfo_mst_Get_By_Userid(int userid)
    {

        return (ContactInfo_mst)ExecuteReader(Sp_Get_ContactInfo_By_id, new object[] { userid }, new GenerateObjectFromReader(GenerateContact_mstObject));
    }

    public object GenerateContact_mstObject(ref IDataReader returnData)
    {
        ContactInfo_mst obj = new ContactInfo_mst();
        while (returnData.Read())
        {
            obj.Userid = (int)returnData["Userid"];
            obj.Deptid = (int)returnData["Deptid"];
            obj.userpriority = (int)returnData["userpriority"];
            if (returnData["description"] != DBNull.Value)
            {
                obj.Description = (string)returnData["description"];
            }

            if (returnData["emailid"] != DBNull.Value)
            {
                obj.Emailid = (string)returnData["emailid"];
            }

            if (returnData["empid"] != DBNull.Value)
            {
                obj.Empid = (string)returnData["empid"];
            }
            if (returnData["firstname"] != DBNull.Value)
            {
                obj.Firstname = (string)returnData["firstname"];
            }
            if (returnData["lastname"] != DBNull.Value)
            {
                obj.Lastname = (string)returnData["lastname"];
            }


            if (returnData["landline"] != DBNull.Value)
            {
                obj.Landline = (string)returnData["landline"];
            }
            if (returnData["mobile"] != DBNull.Value)
            {
                obj.Mobile = (string)returnData["mobile"];
            }
            if (returnData["siteid"] != DBNull.Value)
            {
                obj.Siteid = (int)returnData["siteid"];
            }


        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }






    public Category_mst category_mst_Get_By_categoryid(int categoryid)
    {

        return (Category_mst)ExecuteReader(Sp_Get_Category_By_id, new object[] { categoryid }, new GenerateObjectFromReader(GenerateCategory_mstObject));
    }

    public object GenerateCategory_mstObject(ref IDataReader returnData)
    {
        Category_mst obj = new Category_mst();
        while (returnData.Read())
        {
            obj.CategoryName = (string)returnData["Categoryname"];
            obj.Categoryid = (int)returnData["Categoryid"];
            obj.Categorydescription = (string)returnData["Categorydescription"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_mst Asset_mst_Get_By_assetid(int assetid)
    {

        return (Asset_mst)ExecuteReader(Sp_Get_Asset_By_id, new object[] { assetid }, new GenerateObjectFromReader(GenerateAsset_mstObject));
    }
    public object GenerateAsset_mstObject(ref IDataReader returnData)
    {
        Asset_mst obj = new Asset_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["ComputerName"];
            obj.Domain = (string)returnData["Domain"];
            DateTime Createdate = new DateTime();
            Createdate = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Createdate.ToString();

            if (returnData["TagNo"] != DBNull.Value)
            {
                obj.TagNo = (string)returnData["TagNo"];
            }
            if (returnData["PONo"] != DBNull.Value)
            {
                obj.PONo = (string)returnData["PONo"];
            }
            if (returnData["AssetOwner"] != DBNull.Value)
            {
                obj.AssetOwner = (string)returnData["AssetOwner"];
            }
            if (returnData["Is In Stock"] != DBNull.Value)
            {////change by vishal 16-05-2012
                //obj.IsInStock = (bool)returnData["IsInStock"];
                obj.IsInStock = (bool)returnData["Is In Stock"];
            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_mst Get_Asset_By_Computername(string compname)
    {

        return (Asset_mst)ExecuteReader(sp_Get_Asset_By_Computername, new object[] { compname }, new GenerateObjectFromReader(GenerateAssetbycompname_mstObject));
    }
    public object GenerateAssetbycompname_mstObject(ref IDataReader returnData)
    {
        Asset_mst obj = new Asset_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["ComputerName"];
            obj.Domain = (string)returnData["Domain"];
            if (returnData["TagNo"] != DBNull.Value)
            {
                obj.TagNo = (string)returnData["TagNo"];
            }
            if (returnData["PONo"] != DBNull.Value)
            {
                obj.PONo = (string)returnData["PONo"];
            }
            if (returnData["AssetOwner"] != DBNull.Value)
            {
                obj.AssetOwner = (string)returnData["AssetOwner"];
            }
            if (returnData["Is In Stock"] != DBNull.Value)
            {
                obj.IsInStock = (bool)returnData["Is In Stock"];
            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_mst Get_AssetId_By_ComputerName_DomainName(string compname, string domain)
    {

        return (Asset_mst)ExecuteReader(Sp_Get_AssetId_By_ComputerName_DomainName, new object[] { compname, domain }, new GenerateObjectFromReader(GenerateAssetId_mstObject));
    }
    public object GenerateAssetId_mstObject(ref IDataReader returnData)
    {
        Asset_mst obj = new Asset_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }



    public Asset_Inventory_mst Asset_Inventory_mst_Get_By_assetid(int assetid)
    {

        return (Asset_Inventory_mst)ExecuteReader(Sp_Get_Asset_Inventory_By_id, new object[] { assetid }, new GenerateObjectFromReader(GenerateAssetinventory_mstObject));
    }
    public object GenerateAssetinventory_mstObject(ref IDataReader returnData)
    {
        Asset_Inventory_mst obj = new Asset_Inventory_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["ComputerName"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventorydate = inventorydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_LogicalDrive_mst Asset_LogicalDrive_mst_Get_By_assetid(int assetLogicalDriveId)
    {
        return (Asset_LogicalDrive_mst)ExecuteReader(Sp_Get_Asset_LogicalDrive_By_id, new object[] { assetLogicalDriveId }, new GenerateObjectFromReader(GenerateAssetLogicalDrive_mstObject));
    }
    public object GenerateAssetLogicalDrive_mstObject(ref IDataReader returnData)
    {
        Asset_LogicalDrive_mst obj = new Asset_LogicalDrive_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetlogicaldriveid = (int)returnData["assetlogicaldriveid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Drive_letter = (string)returnData["drive_letter"];
            obj.Drive_type = (string)returnData["drive_type"];
            obj.File_system_name = (string)returnData["file_system_name"];
            obj.Free_bytes = (string)returnData["free_bytes"];
            obj.Total_bytes = (string)returnData["total_bytes"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_Memory_mst Asset_Memory_mst_Get_By_assetid(int assetMemoryId)
    {
        return (Asset_Memory_mst)ExecuteReader(Sp_Get_Asset_Memory_By_id, new object[] { assetMemoryId }, new GenerateObjectFromReader(GenerateAssetMemory_mstObject));
    }
    public object GenerateAssetMemory_mstObject(ref IDataReader returnData)
    {
        Asset_Memory_mst obj = new Asset_Memory_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetmemoryid = (int)returnData["assetmemoryid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Page_file = (string)returnData["page_file"];
            obj.Physical_mem = (string)returnData["physical_mem"];
            obj.Virtual_mem = (string)returnData["virtual_mem"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_Memory_mst AssetMemory_mst_Get_By_assetid(int assetId)
    {
        return (Asset_Memory_mst)ExecuteReader(Sp_Get_Asset_Memory_By_Assetid, new object[] { assetId }, new GenerateObjectFromReader(GenerateAssetMemory_mstByAssetidObject));
    }
    public object GenerateAssetMemory_mstByAssetidObject(ref IDataReader returnData)
    {
        Asset_Memory_mst obj = new Asset_Memory_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetmemoryid = (int)returnData["assetmemoryid"];
            //DateTime inventorydatetime = new DateTime();
            //inventorydatetime = (DateTime)returnData["inventorydate"];
            //obj.Inventory_date = inventorydatetime.ToString();
            obj.Page_file = (string)returnData["page_file"];
            obj.Physical_mem = (string)returnData["physical_mem"];
            obj.Virtual_mem = (string)returnData["virtual_mem"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_Network_mst Asset_Network_mst_Get_By_assetid(int assetNetworkId)
    {
        return (Asset_Network_mst)ExecuteReader(Sp_Get_Asset_Network_By_id, new object[] { assetNetworkId }, new GenerateObjectFromReader(GenerateAssetNetwork_mstObject));
    }
    public object GenerateAssetNetwork_mstObject(ref IDataReader returnData)
    {
        Asset_Network_mst obj = new Asset_Network_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetnetworkid = (int)returnData["assetnetworkid"];
            obj.Adapter_name = (string)returnData["adapter_name"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Gateway = (string)returnData["gateway"];
            obj.Ip_address = (string)returnData["ip_address"];
            obj.Link_speed = (string)returnData["link_speed"];
            obj.Mac_address = (string)returnData["mac_address"];
            obj.Mtu = (string)returnData["mtu"];
            obj.Protocol_name = (string)returnData["protocol_name"];
            obj.Subnet_mask = (string)returnData["subnet_mask"];
            obj.Type = (string)returnData["type"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_OperatingSystem_mst Asset_OperatingSystem_mst_Get_By_assetid(int assetOperatingSystemId)
    {
        return (Asset_OperatingSystem_mst)ExecuteReader(Sp_Get_Asset_OperatingSystem_By_id, new object[] { assetOperatingSystemId }, new GenerateObjectFromReader(GenerateAssetOperatingSystem_mstObject));
    }
    public object GenerateAssetOperatingSystem_mstObject(ref IDataReader returnData)
    {
        Asset_OperatingSystem_mst obj = new Asset_OperatingSystem_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetoperatingid = (int)returnData["assetoperatingid"];
            obj.Add_info = (string)returnData["add_info"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Build_no = (string)returnData["build_no"];
            obj.Localization = (string)returnData["localization"];
            obj.Major_version = (string)returnData["major_version"];
            obj.Minor_version = (string)returnData["minor_version"];
            obj.Os_name = (string)returnData["os_name"];
            obj.Product_key = (string)returnData["product_key"];
            obj.Reg_code = (string)returnData["reg_code"];
            obj.Reg_org = (string)returnData["reg_org"];
            obj.Reg_to = (string)returnData["reg_to"];
            obj.User_name = (string)returnData["user_name"];
            DateTime installdatetime = new DateTime();
            installdatetime = (DateTime)returnData["install_date"];
            obj.Install_date = installdatetime.ToString();
            DateTime logindatetime = new DateTime();
            logindatetime = (DateTime)returnData["login_date"];
            obj.Login_date = logindatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_OperatingSystem_mst AssetOperatingSystem_mst_Get_By_assetid(int assetId)
    {
        return (Asset_OperatingSystem_mst)ExecuteReader(Sp_Get_Asset_OperatingSystem_By_Assetid, new object[] { assetId }, new GenerateObjectFromReader(GenerateAssetOperatingSystem_mst_ByAssetidObject));
    }
    public object GenerateAssetOperatingSystem_mst_ByAssetidObject(ref IDataReader returnData)
    {
        Asset_OperatingSystem_mst obj = new Asset_OperatingSystem_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetoperatingid = (int)returnData["assetoperatingid"];
            obj.Add_info = (string)returnData["add_info"];
            obj.Build_no = (string)returnData["build_no"];
            obj.Localization = (string)returnData["localization"];
            obj.Major_version = (string)returnData["major_version"];
            obj.Minor_version = (string)returnData["minor_version"];
            obj.Os_name = (string)returnData["os_name"];
            obj.Product_key = (string)returnData["product_key"];
            obj.Reg_code = (string)returnData["reg_code"];
            obj.Reg_org = (string)returnData["reg_org"];
            obj.Reg_to = (string)returnData["reg_to"];
            obj.User_name = (string)returnData["user_name"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_PhysicalDrive_mst Asset_PhysicalDrive_mst_Get_By_assetid(int assetPhysicalDriveId)
    {
        return (Asset_PhysicalDrive_mst)ExecuteReader(Sp_Get_Asset_PhysicalDrive_By_id, new object[] { assetPhysicalDriveId }, new GenerateObjectFromReader(GenerateAssetPhysicalDrive_mstObject));
    }
    public object GenerateAssetPhysicalDrive_mstObject(ref IDataReader returnData)
    {
        Asset_PhysicalDrive_mst obj = new Asset_PhysicalDrive_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetphysicaldriveid = (int)returnData["assetphysicaldriveid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Capacity = (string)returnData["capacity"];
            obj.Drive_name = (string)returnData["drive_name"];
            obj.Manufacturer = (string)returnData["manufacturer"];
            obj.Product_id = (string)returnData["product_id"];
            obj.Product_version = (string)returnData["product_version"];
            obj.Serial_number = (string)returnData["serial_number"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_Processor_mst Asset_Processor_mst_Get_By_assetid(int assetProcessorId)
    {
        return (Asset_Processor_mst)ExecuteReader(Sp_Get_Asset_Processor_By_id, new object[] { assetProcessorId }, new GenerateObjectFromReader(GenerateAssetProcessor_mstObject));
    }
    public object GenerateAssetProcessor_mstObject(ref IDataReader returnData)
    {
        Asset_Processor_mst obj = new Asset_Processor_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetprocessorid = (int)returnData["assetprocessorid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Family = (string)returnData["family"];
            obj.Manufacturer = (string)returnData["manufacturer"];
            obj.Max_speed = (string)returnData["max_speed"];
            obj.Model = (string)returnData["model"];
            obj.Processor_name = (string)returnData["processor_name"];
            obj.Speed = (string)returnData["speed"];
            obj.Stepping = (string)returnData["stepping"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_Processor_mst AssetProcessor_mst_Get_By_assetid(int assetId)
    {
        return (Asset_Processor_mst)ExecuteReader(Sp_Get_Asset_Processor_By_Assetid, new object[] { assetId }, new GenerateObjectFromReader(GenerateAssetProcessor_mst_ByAssetidObject));
    }
    public object GenerateAssetProcessor_mst_ByAssetidObject(ref IDataReader returnData)
    {
        Asset_Processor_mst obj = new Asset_Processor_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetprocessorid = (int)returnData["assetprocessorid"];
            //DateTime inventorydatetime = new DateTime();
            //inventorydatetime = (DateTime)returnData["inventorydate"];
            //obj.Inventory_date = inventorydatetime.ToString();
            obj.Family = (string)returnData["family"];
            obj.Manufacturer = (string)returnData["manufacturer"];
            obj.Max_speed = (string)returnData["max_speed"];
            obj.Model = (string)returnData["model"];
            obj.Processor_name = (string)returnData["processor_name"];
            obj.Speed = (string)returnData["speed"];
            obj.Stepping = (string)returnData["stepping"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_ProductInfo_mst Asset_ProductInfo_mst_Get_By_assetid(int assetProductInfoId)
    {
        return (Asset_ProductInfo_mst)ExecuteReader(Sp_Get_Asset_ProductInfo_By_id, new object[] { assetProductInfoId }, new GenerateObjectFromReader(GenerateAssetProductInfo_mstObject));
    }
    public object GenerateAssetProductInfo_mstObject(ref IDataReader returnData)
    {
        Asset_ProductInfo_mst obj = new Asset_ProductInfo_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetproductinfoid = (int)returnData["assetproductinfoid"];
            DateTime inventorydatetime = new DateTime();
            inventorydatetime = (DateTime)returnData["inventorydate"];
            obj.Inventory_date = inventorydatetime.ToString();
            obj.Product_manufacturer = (string)returnData["product_manufacturer"];
            obj.Product_name = (string)returnData["product_name"];
            obj.Serial_number = (string)returnData["serial_number"];
            obj.Sku_no = (string)returnData["sku_no"];
            obj.Uuid = (string)returnData["uuid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public Asset_ProductInfo_mst AssetProductInfo_mst_Get_By_assetid(int assetId)
    {
        return (Asset_ProductInfo_mst)ExecuteReader(Sp_Get_Asset_ProductInfo_By_Assetid, new object[] { assetId }, new GenerateObjectFromReader(GenerateAssetProductInfo_mst_ByAssetidObject));
    }
    public object GenerateAssetProductInfo_mst_ByAssetidObject(ref IDataReader returnData)
    {
        Asset_ProductInfo_mst obj = new Asset_ProductInfo_mst();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Assetproductinfoid = (int)returnData["assetproductinfoid"];
            //DateTime inventorydatetime = new DateTime();
            //inventorydatetime = (DateTime)returnData["inventorydate"];
            //obj.Inventory_date = inventorydatetime.ToString();
            obj.Product_manufacturer = (string)returnData["product_manufacturer"];
            obj.Product_name = (string)returnData["product_name"];
            obj.Serial_number = (string)returnData["serial_number"];
            obj.Sku_no = (string)returnData["sku_no"];
            obj.Uuid = (string)returnData["uuid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public UserToAssetMapping UserToAssetMapping_Get_By_assetid(int assetid)
    {
        return (UserToAssetMapping)ExecuteReader(Sp_Get_UserToAssetMapping_By_id, new object[] { assetid }, new GenerateObjectFromReader(GenerateUserToAssetMapping_mstObject));
    }
    public object GenerateUserToAssetMapping_mstObject(ref IDataReader returnData)
    {
        UserToAssetMapping obj = new UserToAssetMapping();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.Userid = (int)returnData["userid"];
            if (returnData["assetlocation"] != DBNull.Value)
            {
                obj.AssetLocation = (string)returnData["assetlocation"];
            }
            if (returnData["companyname"] != DBNull.Value)
            {
                obj.AssetCompanyName = (string)returnData["companyname"];
            }
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public IncidentToAssetMapping IncidentToAssetMapping_Get_By_assetid(int assetid)
    {
        return (IncidentToAssetMapping)ExecuteReader(Sp_Get_IncidentToAssetMapping_By_id, new object[] { assetid }, new GenerateObjectFromReader(GenerateIncidentToAssetMapping_mstObject));
    }
    public object GenerateIncidentToAssetMapping_mstObject(ref IDataReader returnData)
    {
        IncidentToAssetMapping obj = new IncidentToAssetMapping();
        while (returnData.Read())
        {
            obj.Assetid = (int)returnData["assetid"];
            obj.incidentid = (int)returnData["incidentid"];

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    #endregion

    #region Public Function Get By Other Field()

    public int Get_TopSiteId_mst()
    {
        return (int)ExecuteScalar(sp_Get_TopSiteId, new object[] { });
    }

    public int Get_TopCustomerId()
    {
        return (int)ExecuteScalar(sp_Get_TopCustomerId, new object[] { });
    }
    public int Get_CustId_mst_Get_By_SiteId(int CustId, int siteid)
    {
        return (int)ExecuteScalar(Sp_Get_CustId_By_SiteId, new object[] { CustId, siteid });
    }

    public int Get_ContractToAssetMapping_By_Contractid_Assetid(int contractid, int assetid)
    {
        return (int)ExecuteScalar(sp_ContractToAssetMapping_Get_By_Contractid_Assetid, new object[] { contractid, assetid });
    }

    public int Contract_mst_By_name(string contractname)
    {
        return (int)ExecuteScalar(sp_Contract_mst_By_name, new object[] { contractname });
    }

    public int ContractToAssetMapping_By_Assetid(int assetid)
    {
        return (int)ExecuteScalar(sp_ContractToAssetMapping_By_Assetid, new object[] { assetid });
    }
    public int Problem_mst_Get_Current_Problemid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_Problemid, new object[] { });
    }
    public int Change_mst_Get_Current_Changeid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_Changeid, new object[] { });
    }

    public int AssetId_From_UserToAssetMap(int assetid)
    {
        return (int)ExecuteScalar(Sp_Check_AssetId_From_UserToAssetMap, new object[] { assetid });

    }

    public int Update_Assetid_By_id(int oldassetid, int assetid, string assetlocation, string companyname)
    {
        return (int)ExecuteScalar(Sp_Update_Assetid_By_id, new object[] { oldassetid, assetid, assetlocation, companyname });
    }

    public int AssetId_From_incidentToAssetMap(int assetid)
    {
        return (int)ExecuteScalar(Sp_Check_AssetId_From_IncidentToAssetMap, new object[] { assetid });

    }

    public int UserId_From_UserToAssetMap(int userid)
    {
        return (int)ExecuteScalar(Sp_Check_UserId_From_UserToAssetMap, new object[] { userid });

    }
    //added by lalit 24 feb 2012
    public int SiteId_From_UserToAssetMap(int assetid)
    {
        return (int)ExecuteScalar(Sp_Check_SiteId_From_UserToAssetMap, new object[] { assetid });

    }
    //end


    public int incidentId_From_incidentToAssetMap(int incidentid)
    {
        return (int)ExecuteScalar(Sp_Check_IncidentId_From_IncidentToAssetMap, new object[] { incidentid });

    }

    public int AssetId_By_UserId(int userid)
    {
        return (int)ExecuteScalar(Sp_AssetId_By_UserId, new object[] { userid });

    }

    public int AssetId_By_incidentId(int incidentid)
    {
        return (int)ExecuteScalar(Sp_AssetId_By_IncidentId, new object[] { incidentid });

    }

    public int Holiday_mst_Get_By_HolidayDate_Siteid(int siteid, string hdate)
    {
        return (int)ExecuteScalar(Sp_Check_Holiday, new object[] { siteid, hdate });

    }

    public int Get_Inventorydetails_By_AssetId_InventoryDate(int assetid, string inventorydate)
    {
        return (int)ExecuteScalar(Sp_Get_Inventorydetails_By_AssetId_InventoryDate, new object[] { assetid, inventorydate });

    }

    public int Delete_ExistingDetails_From_AssetTables(int assetid, string inventorydate)
    {
        return (int)ExecuteNonQuery(Sp_Delete_ExistingDetails_From_AssetTables, new object[] { assetid, inventorydate });

    }

    public int Asset_mst_Get_ComputerName(string compname, string domain)
    {
        return (int)ExecuteScalar(Sp_Check_ComputerName, new object[] { compname, domain });

    }

    public int Check_Colorname_From_ColorScheme(string colorname)
    {
        return (int)ExecuteScalar(Sp_ColorName_From_ColorScheme, new object[] { colorname });

    }

    public int Check_Role_By_Roleid(string rolename)
    {
        return (int)ExecuteScalar(Sp_Check_Role, new object[] { rolename });

    }

    public int Check_Customer_By_Custid(string customername)
    {
        return (int)ExecuteScalar(Sp_Check_Customer, new object[] { customername });

    }

    public int Check_Vendor_By_Vname(string vname)
    {
        return (int)ExecuteScalar(Sp_Check_Vendor, new object[] { vname });
    }

    public int Check_Mode_By_Mname(string mname)
    {
        return (int)ExecuteScalar(Sp_Check_Mode, new object[] { mname });
    }
    // add hub by lalit
    public int Check_Mode_By_Hname(string Hname)
    {
        return (int)ExecuteScalar(Sp_Check_Hub, new object[] { Hname });
    }
    //end hub
    public int Check_Email_Id(string email)
    {
        return (int)ExecuteScalar(Sp_Check_Email, new object[] { email });
    }

    public int Check_Asset_By_Cname(string cname)
    {
        return (int)ExecuteScalar(Sp_Check_Asset, new object[] { cname });
    }

    public int Check_ServiceWindow_By_Siteid(int siteid)
    {
        return (int)ExecuteScalar(Sp_Check_ServiceWindow, new object[] { siteid });
    }

    public int IncidentHistory_mst_Get_Current_IncidentHistoryid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_IncidentHistoryid, new object[] { });
    }
    public int ProblemHistory_mst_Get_Current_ProblemHistoryid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_ProblemHistoryid, new object[] { });
    }
    public int ChangeHistory_mst_Get_Current_ChangeHistoryid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_ChangeHistoryid, new object[] { });
    }

    public int Incident_mst_Get_TimeSpentonRequest(int incidentid, int siteid, string starttime, string endtime)
    {
        return (int)ExecuteScalar(Sp_Get_TimeSpentonRequest, new object[] { incidentid, siteid, starttime, endtime });
    }

    public int Incident_mst_Get_Current_Incidentid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_Incidentid, new object[] { });
    }
    public int Configurationmst_mst_Get_Current_CMDBAssetid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_CMDBAssetid, new object[] { });
    }

    public int Assett_mst_Get_Current_Assetid()
    {
        return (int)ExecuteScalar(Sp_Get_Current_Assetid, new object[] { });
    }



    public int Incident_mst_Get_SLAid(int siteid, int priorityid)
    {
        return (int)ExecuteScalar(Sp_Get_SLAid, new object[] { siteid, priorityid });
    }

    public int Contract_mst_TopContractId()
    {
        return (int)ExecuteScalar(sp_Get_TopContractId, new object[] { });
    }

    public int Contract_mst_Notification_Time(int contractid)
    {
        return (int)ExecuteScalar(sp_Get_Notification_Time, new object[] { contractid });
    }

    public int Contract_mst_Status(string ActiveToDate)
    {
        return (int)ExecuteScalar(sp_Get_ContractActive, new object[] { ActiveToDate });
    }

    public int Get_TopIncidentId()
    {
        return (int)ExecuteScalar(sp_Get_TopIncidentId, new object[] { });
    }

    public SLA_Priority_mst Get_SLA_Priority_By_Slaid(int Slaid)
    {

        return (SLA_Priority_mst)ExecuteReader(Sp_Get_SLA_Priority_By_Slaid, new object[] { Slaid }, new GenerateObjectFromReader(GenerateSLAPriority_mstObject));
    }


    public SLA_Priority_mst Get_SLA_Priority_By_Siteid(int siteid, int priorityid)
    {

        return (SLA_Priority_mst)ExecuteReader(Sp_Get_SLA_Priority_By_Siteid, new object[] { siteid, priorityid }, new GenerateObjectFromReader(GenerateSLAPriority_mstObject));
    }

    public object GenerateSLAPriority_mstObject(ref IDataReader returnData)
    {
        SLA_Priority_mst obj = new SLA_Priority_mst();
        while (returnData.Read())
        {

            obj.Slaid = (int)returnData["Slaid"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Priorityid = (int)returnData["Priorityid"];
            obj.Resolutiondays = (int)returnData["Resolutiondays"];
            obj.Resolutionhours = (int)returnData["Resolutionhours"];
            obj.Resolutionmin = (int)returnData["Resolutionmin"];
            obj.Responsedays = (int)returnData["Responsedays"];
            obj.Responsehours = (int)returnData["Responsehours"];
            obj.Responsemin = (int)returnData["Responsemin"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }

    public BLLCollection<Asset_mst> Assetdetails_By_Assetid(int assetid)
    {

        return (BLLCollection<Asset_mst>)ExecuteReader(Sp_Assetdetails_By_Assetid, new object[] { assetid }, new GenerateCollectionFromReader(GenerateAssetdetails_mstCollection));
    }

    public CollectionBase GenerateAssetdetails_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        while (returnData.Read())
        {
            Asset_mst obj = new Asset_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["computername"];
            if (returnData["domain"] != DBNull.Value)
            {
                obj.Domain = (string)returnData["domain"];
            }
            if (returnData["TagNo"] != DBNull.Value)
            {
                obj.TagNo = (string)returnData["TagNo"];
            }
            if (returnData["PONo"] != DBNull.Value)
            {
                obj.PONo = (string)returnData["PONo"];
            }
            ////add by Vishal 16-05-2011 
            if (returnData["AssetOwner"] != DBNull.Value)
            {
                obj.AssetOwner = (string)returnData["AssetOwner"];
            }
            ///end
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    public BLLCollection<ContactInfo_mst> Get_ContactInfo_ms_By_commandname(string commandname)
    {

        return (BLLCollection<ContactInfo_mst>)ExecuteReader(Sp_Get_contactinfo_By_Commandname, new object[] { commandname }, new GenerateCollectionFromReader(GenerateContactInfo_mstCollection));
    }


    public BLLCollection<Asset_mst> Get_Asset_Info_By_commandname(string commandname)
    {

        return (BLLCollection<Asset_mst>)ExecuteReader(Sp_Get_Asset_By_Commandname, new object[] { commandname }, new GenerateCollectionFromReader(GenerateUserViewAsset_mstCollection));
    }

    public CollectionBase GenerateUserViewAsset_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        while (returnData.Read())
        {
            Asset_mst obj = new Asset_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["computername"];
            //DateTime Mydatetime = new DateTime();
            //Mydatetime = (DateTime)returnData["createdatetime"];
            //obj.Createdatetime = Mydatetime.ToString();  
            if (returnData["domain"] != DBNull.Value)
            {
                obj.Domain = (string)returnData["domain"];
            }
            if (returnData["TagNo"] != DBNull.Value)
            {
                obj.TagNo = (string)returnData["TagNo"];
            }
            if (returnData["PONo"] != DBNull.Value)
            {
                obj.PONo = (string)returnData["PONo"];
            }
            if (returnData["AssetOwner"] != DBNull.Value)
            {
                obj.AssetOwner = (string)returnData["AssetOwner"];
            }
            ///////////add by vishal 01-06-2012
            if (returnData["Is in stock"] != DBNull.Value)
            {
                obj.IsInStock = (bool)returnData["Is in stock"];
            }
            if (returnData["Manual"] != DBNull.Value)
            {
                obj.manaul = (bool)returnData["Manual"];
            }

            if (returnData["Location"] != DBNull.Value)
            {
                obj.location = (string)returnData["Location"];
            }
            if (returnData["CompanyCode"] != DBNull.Value)
            {
                obj.CompanyCode = (string)returnData["CompanyCode"];
            }
            if (returnData["PurchaseDate"] != DBNull.Value)
            {
                //obj.PurchaseDate = (string) returnData["PurchaseDate"];
                obj.PurchaseDate = ((DateTime)returnData["PurchaseDate"]).ToString();
                //obj.PurchaseDate = DateTime.ParseExact("dd/MM/yyyy").ToString("PurchaseDate");

            }
            if (returnData["AssetCategory"] != DBNull.Value)
            {
                obj.AssetCategory = (string)returnData["AssetCategory"];
            }
            if (returnData["Remarks"] != DBNull.Value)
            {
                obj.Remarks = (string)returnData["Remarks"];
            }
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public BLLCollection<Asset_mst> Get_NotAssignAsset_Info_By_commandname(string commandname)
    {

        return (BLLCollection<Asset_mst>)ExecuteReader(Sp_Get_NotAssignAsset_By_Commandname, new object[] { commandname }, new GenerateCollectionFromReader(GenerateUserViewNotAssignAsset_mstCollection));
    }

    public CollectionBase GenerateUserViewNotAssignAsset_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        while (returnData.Read())
        {
            Asset_mst obj = new Asset_mst();
            obj.Assetid = (int)returnData["assetid"];
            obj.Computername = (string)returnData["computername"];
            //DateTime Mydatetime = new DateTime();
            //Mydatetime = (DateTime)returnData["createdatetime"];
            //obj.Createdatetime = Mydatetime.ToString();  
            if (returnData["domain"] != DBNull.Value)
            {
                obj.Domain = (string)returnData["domain"];
            }

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    public BLLCollection<UserLogin_mst> Get_User_Info_By_commandname(string commandname)
    {

        return (BLLCollection<UserLogin_mst>)ExecuteReader(Sp_Get_User_By_Commandname, new object[] { commandname }, new GenerateCollectionFromReader(GenerateUserLogin_mstCollection));
    }



    public SLA_mst Get_SLA_mst_Get_By_SLAName(string Slaname, int siteid)
    {

        return (SLA_mst)ExecuteReader(Sp_Get_SLA_By_SLAName, new object[] { Slaname, siteid }, new GenerateObjectFromReader(GenerateSLA_mstObject));
    }

    public object GenerateSLA_mstObject(ref IDataReader returnData)
    {
        SLA_mst obj = new SLA_mst();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            obj.Slaid = (int)returnData["Slaid"];
            obj.Siteid = (int)returnData["Siteid"];
            obj.Slaname = (string)returnData["Slaname"];
            obj.Description = (string)returnData["Description"];
            obj.Enable = (bool)returnData["Enable"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();

        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public int Get_deptid_mst_Get_By_DepartmentName(string departmentname, int siteid)
    {
        return (int)ExecuteScalar(Sp_Get_deptid_By_DepartmentName, new object[] { departmentname, siteid });
    }


    public int Impact_mst_Get_By_ImpactName(string Impactname)
    {
        return (int)ExecuteScalar(Sp_Get_Impact_By_ImpactName, new object[] { Impactname });
    }

    public int State_mst_Get_By_StateName(string statename)
    {
        return (int)ExecuteScalar(Sp_Get_StateId_By_Statename, new object[] { statename });
    }

    public int Get_UserId_mst_Get_By_SiteId(int userid, int siteid)
    {
        return (int)ExecuteScalar(Sp_Get_UserId_By_SiteId, new object[] { userid, siteid });
    }

    public int Country_mst_Get_By_CountryName(string CountryName)
    {
        return (int)ExecuteScalar(Sp_Get_Country_By_CountryName, new object[] { CountryName });
    }

    public int Get_sitId_mst_Get_By_SiteName(string SiteName, int regionid)
    {
        return (int)ExecuteScalar(Sp_Get_SiteId_By_SiteName, new object[] { SiteName, regionid });
    }

    public int Get_UserId_mst_Get_By_UserName(string UserName, int orgid)
    {
        return (int)ExecuteScalar(Sp_Get_UserId_By_UserName, new object[] { UserName, orgid });
    }
    //update city and company when user alreay exist
    public int Update_Userloginmst_City_Company(string username, string city, string companyname)
    {
        return (int)ExecuteScalar(Sp_Update_CityCompany_By_UserName, new object[] { username, city, companyname });
    }
    //end
    public UserLogin_mst Get_UserLogin_mst_By_UserName_Like(string UserName)
    {

        return (UserLogin_mst)ExecuteReader(Sp_Get_UserLogin_By_UserName_Like, new object[] { UserName }, new GenerateObjectFromReader(GenerateUserLogin_mstObject));
    }

    public UserLogin_mst Get_UserLogin_mst_By_UserName(string UserName, int orgid)
    {

        return (UserLogin_mst)ExecuteReader(Sp_Get_UserLogin_By_UserName, new object[] { UserName, orgid }, new GenerateObjectFromReader(GenerateUserLogin_mstObject));
    }

    public UserLogin_mst Get_UserLogin_mst_By_UserName_Ex(string UserName, int orgid)
    {

        return (UserLogin_mst)ExecuteReader(sp_Get_UserLogin_By_UserName_mst_Ex, new object[] { UserName, orgid }, new GenerateObjectFromReader(GenerateUserLogin_mstObject));
    }
    public object GenerateUserLogin_mstObject(ref IDataReader returnData)
    {
        UserLogin_mst obj = new UserLogin_mst();
        while (returnData.Read())
        {
            DateTime Mydatetime = new DateTime();
            obj.Userid = (int)returnData["Userid"];
            obj.Username = (string)returnData["Username"];
            obj.Roleid = (int)returnData["Roleid"];
            obj.Orgid = (int)returnData["Orgid"];
            obj.Password = (string)returnData["Password"];
            obj.Enable = (bool)returnData["Enable"];
            obj.ADEnable = (bool)returnData["ADEnable"];
            Mydatetime = (DateTime)returnData["Createdatetime"];
            obj.Createdatetime = Mydatetime.ToString();
            //if (returnData["DomainName"] != null)
            //{
            //    obj.DomainName = (string)returnData["DomainName"];
            //}
            //if (returnData["Company"] != null)
            //{
            //    obj.Company = (string)returnData["Company"];
            //}
            //if (returnData["City"]!= null)
            //{
            //    obj.City = (string)returnData["City"];
            //}
            //start CHanged by prachi-19thmarch
            if (returnData["DomainName"] != DBNull.Value)
            {
                obj.DomainName = (string)returnData["DomainName"];
            }
            if (returnData["Company"] != DBNull.Value)
            {
                obj.Company = (string)returnData["Company"];
            }
            if (returnData["City"] != DBNull.Value)
            {
                obj.City = (string)returnData["City"];
            }
            //end
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }


    public Organization_mst Get_Organization_mst()
    {

        return (Organization_mst)ExecuteReader(Sp_Get_Organization, new object[] { }, new GenerateObjectFromReader(GenerateOrganization_mstObject));
    }
    public int Region_mst_Get_By_RegionName(string RegionName, int orgid)
    {
        return (int)ExecuteScalar(Sp_Get_Region_By_RegionName, new object[] { RegionName, orgid });
    }

    public int RoleInfo_mst_Get_By_RoleName(string RoleName)
    {
        return (int)ExecuteScalar(Sp_Get_RoleInfo_By_RoleName, new object[] { RoleName });
    }

    public RoleInfo_mst RoleInfo_Get_By_RoleName_mst(string RoleName)
    {
        return (RoleInfo_mst)ExecuteReader(Sp_Get_RoleInfo, new object[] { RoleName }, new GenerateObjectFromReader(GenerateRoleInfo_mstObject));
    }

    public int Category_mst_Get_By_CategoryName(string CategoryName)
    {
        return (int)ExecuteScalar(Sp_Get_Category_By_CategoryName, new object[] { CategoryName });
    }
    public int Subcategory_mst_Get_By_SubcategoryName(string Subcategoryname, int categoryid)
    {
        return (int)ExecuteScalar(Sp_Get_Subcategory_By_SubcategoryName, new object[] { Subcategoryname, categoryid });
    }

    public int Priority_mst_Get_By_PriorityName(string PriorityName)
    {
        return (int)ExecuteScalar(Sp_Get_Priority_By_PriorityName, new object[] { PriorityName });
    }

    public int Status_mst_Get_By_StatusName(string StatusName)
    {
        return (int)ExecuteScalar(Sp_Get_Status_By_StatusName, new object[] { StatusName });
    }

    public int ChangeStatus_mst_Get_By_StatusName(string StatusName)
    {
        return (int)ExecuteScalar(Sp_Get_ChangeStatus_By_StatusName, new object[] { StatusName });
    }

    public int ChangeType_mst_Get_By_ChangeTypeName(string ChangeTypeName)
    {
        return (int)ExecuteScalar(Sp_Get_ChangeType_mst_Get_By_ChangeTypeName, new object[] { ChangeTypeName });
    }

    public int Service_mst_Get_By_ServiceName(string Servicename)
    {
        return (int)ExecuteScalar(sp_Get_Serviceid_By_Servicename, new object[] { Servicename });
    }

    public int SolutionKeyword_Get_SolutionId()
    {
        return (int)ExecuteScalar(Sp_Get_SolutionId, new object[] { });
    }
    #endregion

    public SqlDataProvider()
    {

    }


    /// <summary>
    /// //////Create by Vishal 16-05-2012 
    /// </summary>
    /// <param name="objAsset"></param>
    /// <returns></returns>


    public int Update_Asset_mst_Tag_PO_By_id(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Tag_Update, new object[] { objAsset.Assetid, objAsset.TagNo, objAsset.PONo, objAsset.AssetOwner, objAsset.location, objAsset.IsInStock, objAsset.CompanyCode, objAsset.PurchaseDate, objAsset.AssetCategory, objAsset.Remarks });
    }

    private const string Sp_Asset_Tag_Update = "Sp_Asset_Tag_Update";


    //public UserToAssetMapping AssetGet_By_id(int assetid)
    //{
    //    return (UserToAssetMapping)ExecuteReader(Sp_Assetdetails_By_Assetid, new object[] { assetid }, new GenerateObjectFromReader(GenerateAsset_mstObject));
    //}
    //public object GenerateAsset_mstObject(ref IDataReader returnData)
    //{
    //    Asset_mst obj = new Asset_mst();
    //    while (returnData.Read())
    //    {
    //        obj.Assetid = (int)returnData["assetid"];
    //        obj.Computername = (string)returnData["computername"];
    //        if (returnData["domain"] != DBNull.Value)
    //        {
    //            obj.Domain = (string)returnData["domain"];
    //        }
    //        if (returnData["TagNo"] != DBNull.Value)
    //        {
    //            obj.TagNo = (string)returnData["TagNo"];
    //        }
    //        if (returnData["PONo"] != DBNull.Value)
    //        {
    //            obj.PONo = (string)returnData["PONo"];
    //        }
    //        ////add by Vishal 16-05-2011 
    //        if (returnData["AssetOwner"] != DBNull.Value)
    //        {
    //            obj.AssetOwner = (string)returnData["AssetOwner"];
    //        }
    //    }
    //    returnData.Close();
    //    returnData.Dispose();
    //    return obj;
    //}

    ///End 16-05-2012
    ///
    /////create by vishal 18-05-2012

    public BLLCollection<Customer_mst> Get_UserName_All_By_Likename(string strusername)
    {
        return (BLLCollection<Customer_mst>)ExecuteReader(Sp_username_mst_All_By_usernamelike, new object[] { strusername }, new GenerateCollectionFromReader(GenerateUsername_mstCollection));
    }

    public CollectionBase GenerateUsername_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Customer_mst> col = new BLLCollection<Customer_mst>();
        while (returnData.Read())
        {

            Customer_mst obj = new Customer_mst();
            obj.Customer_name = (string)returnData["customerName"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }


    /// <summary>
    /// //////Create by Vishal 02-06-2012 
    /// </summary>
    /// <param name="objAsset"></param>
    /// <returns></returns>



    public int UpdateDeleteFlag_Asset_id(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(UpdateDeleteFlag_Asset, new object[] { objAsset.Assetid });
    }

    private const string UpdateDeleteFlag_Asset = "UpdateDeleteFlag_Asset_id";
    ////////end 02-06-2012


    /////////////Create by Vishal 04-06-2012


    public int Update_Asset_mst_Tag_PO_IsInStockBy_id(Asset_mst objAsset)
    {
        return (int)ExecuteNonQuery(Sp_Asset_Tag_ISINSTOCK_Update, new object[] { objAsset.Assetid, objAsset.TagNo, objAsset.PONo, objAsset.AssetOwner, objAsset.location, objAsset.CompanyCode, objAsset.PurchaseDate, objAsset.AssetCategory, objAsset.Remarks });
    }

    private const string Sp_Asset_Tag_ISINSTOCK_Update = "Sp_Asset_Tag_ISINSTOCK_Update";

    /// <summary>
    /// //////add by vishal software add 06-06-2012
    /// </summary>
    /// <param name="objinventoryAsset"></param>
    /// <returns></returns>
    public int Insert_Asset_Software_mst(Asset_Software_mst objSoftwareAsset)
    {
        return (int)ExecuteNonQuery(sp_Asset_Software_Insert, new object[] {objSoftwareAsset.AssetSoftwareid, objSoftwareAsset.Assetid, objSoftwareAsset.Inventorydate, objSoftwareAsset.Computername, objSoftwareAsset.Domainname, objSoftwareAsset.Software_name, objSoftwareAsset.Software_manufacturer, objSoftwareAsset.Install_directory, objSoftwareAsset.Software_version, objSoftwareAsset.Software_version_major, objSoftwareAsset.Software_version_minor, objSoftwareAsset.Software_registered_to, objSoftwareAsset.Software_registration_code, objSoftwareAsset.Software_registered_organization, objSoftwareAsset.Software_product_key,objSoftwareAsset.Installed_on });
    }

    private const string sp_Asset_Software_Insert = "sp_Asset_Software_Insert";


    #region Terex Merge
    //added by lalit 02nov2011 to insert. insert to mapped user with category ,subcateogry
    public int Insert_CategoryAssignToUser_mst(CategoryAssignToUser_mst objCategoryAssignToUser)
    {
        return (int)ExecuteNonQuery(sp_CategoryAssigntoUSer_Insert_mst, new object[] { objCategoryAssignToUser.Categoryid, objCategoryAssignToUser.Subcategoryid, objCategoryAssignToUser.Userid });
    }
    //added by lalit 02nov2011 to update.update user with category ,subcateogry
    public int Update_CategoryAssignToUser_mst(int categoryid, int subcategoryid, int userid)
    {
        return (int)ExecuteNonQuery(sp_CategoryAssigntoUSer_Update_mst, new object[] { categoryid, subcategoryid, userid });
    }
    //added by lalit 02nov to get user mapped with categoryid and subcategoryid
    public CategoryAssignToUser_mst Get_CategoryAssignUser_mst_Get_By_CategorySubcategory(int categoryid, int subcategoryid)
    {
        return (CategoryAssignToUser_mst)ExecuteReader(sp_Get_CategoryAssignTouser_mst_By_Category_SubCategory, new object[] { categoryid, subcategoryid }, new GenerateObjectFromReader(GenerateCategoryAssignToUser_mstObject));
    }
    public object GenerateCategoryAssignToUser_mstObject(ref IDataReader returnData)
    {
        CategoryAssignToUser_mst obj = new CategoryAssignToUser_mst();
        while (returnData.Read())
        {
            obj.Userid = (int)returnData["Userid"];
        }
        returnData.Close();
        returnData.Dispose();
        return obj;
    }
    //added by lalit to get admin,technician,sde. when technician has to be mapped on basis of category and subcategory.
    public BLLCollection<UserLogin_mst> Get_UserLogin_mst_AdminTechSDE()
    {
        return (BLLCollection<UserLogin_mst>)ExecuteReader(sp_Get_UserLogin_mst, new object[] { }, new GenerateCollectionFromReader(GenerateUserLogin_mstCollection_TechAdminSDE));
    }
    //added by lalit 02nov2011 to fetch users who has role admin,technician,sde to be mapped with category and subcategory
    public CollectionBase GenerateUserLogin_mstCollection_TechAdminSDE(ref IDataReader returnData)
    {
        BLLCollection<UserLogin_mst> col = new BLLCollection<UserLogin_mst>();
        while (returnData.Read())
        {
            UserLogin_mst obj = new UserLogin_mst();
            obj.Userid = (int)returnData["Userid"];
            obj.Username = (string)returnData["Username"];
            obj.Roleid = (int)returnData["Roleid"];
            obj.Orgid = (int)returnData["Orgid"];
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }
    #endregion
}
