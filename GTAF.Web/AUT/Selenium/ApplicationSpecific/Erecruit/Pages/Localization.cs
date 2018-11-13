using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Engine.UIHandlers.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using GallopReporter;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class Localization : AbstractTemplatePage
    {

        #region Constructors
        public Localization()
        {
        }

        public Localization(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion
        HomePage hm = new HomePage();
        #region UI Object Repository

        private By txtSearch = By.Id("txtAdminMenuFilter");
        private By lnkFolderGroups = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Folder Groups']");
        //By.XPath("//a[text()='Folder Groups']");
        private By lnkFolderGroupStatus = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Folder Group Statuses']");
        private By lnkResumeBoardLogin = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Resume Board Logins']");
        private By frameResumeBoard = By.XPath("//iframe[contains(@id,'JobBoard_Index')]");
        private By frameManageFolderGroups = By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroups')]");
        private By lnkAddNewStatus = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/h2/span/a[text()='Add New Status']");
        private By popupAddNewStatus = By.XPath("//div[contains(@class,' t_Content_erecruitDefault')]");
        private By txtNewFolderGroup = By.Id("ctl00_ctl00_cphMain_cphMain_txtName");
        private By ddlCategory = By.Id("ctl00_ctl00_cphMain_cphMain_ddlCategory_Input");
        private By btnAddFolderGroup = By.Id("ctl00_ctl00_cphMain_cphMain_btnAdd");
        private By btnEditFolderGroup = By.Id("ctl00_ctl00_cphMain_cphMain_gridFolderGroups_ctl00_ctl04_EditButton");
        private By txtNameEdit = By.Id("ctl00_ctl00_cphMain_cphMain_gridFolderGroups_ctl00_ctl04_TB_Name");
        private By btnUpdateFolderGroup = By.Id("ctl00_ctl00_cphMain_cphMain_gridFolderGroups_ctl00_ctl04_UpdateButton");
        private By corruptedFileMessage = By.XPath("//div[@id='message_1']/b[text()='Check For Corrupted Files']/../div[@onclick='CloseMessage($(this));']");
        private By updateMessage = By.XPath("//div[@id='message_2' and text()='Folder Group updated']");
        private By txtName = By.XPath("//div[@class='Group']/div/label[text()='Name:']/../input");
        private By colorPicker = By.XPath("//div[@class='Group']/div/label[text()='Color:']/../div/div[@class='CurrentDisplay']");
        private By txtSortedOrder = By.XPath("//div[@class='Group']/div/label[text()='Sort Order:']/../input[@type='number']");
        private By btnCreateSave = By.XPath("//span/button[contains(text(),'Create')]");
        private By lnkControlPanelModule = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin']/ul/li[2]/a//span[contains(text(),'Control Panel Modules')]");
        private By btnClose = By.XPath("//div[@onclick='CloseMessage($(this));']");
        private By sectionResumeBoardLogins = By.XPath("//div[@class='pageContainer']/div[contains(@class,'jobBoardLoginsPage')]//div[@class='widgetBody col-4']");
        private By headerResumeBoardLogins = By.XPath("//div[@class='pageContainer']/div[contains(@class,'jobBoardLoginsPage')]/header[contains(@class,'widgetTitle')]/h1[text()='Resume Board Logins']");
        private By txtDepartmentSearch = By.XPath("//div[@class='pageContainer']/div[contains(@class,'jobBoardLoginsPage')]/header[contains(@class,'widgetTitle')]/h1[text()='Resume Board Logins']/../div/input");
        private By frameAgreementNew = By.XPath("//iframe[contains(@id,'agreement_new')]");
        private By ddlCompany = By.Id("ctl00_cphMain_ddlCompany_Input");
        private By ddlContact = By.XPath("//input[@id='ctl00_cphMain_ddlContact_Input']");
            //By.Id("ctl00_cphMain_ddlContact_Input");
        private By txtAgreementName = By.Id("ctl00_cphMain_txtAgreeName");
        private By ddlAgreementType = By.Id("ctl00_cphMain_ddlAgreementType_Input");
        private By ddlBilling = By.Id("ctl00_cphMain_ddlBillingTerm_Input");
        private By btnSaveAgreement = By.Id("ctl00_cphMain_btnSave_input");
        private By frameAgreementManage = By.XPath("//iframe[contains(@id,'agreement_manage')]");
        private By lnkGenerateDocument = By.XPath("//div[contains(@id,'widget_generatedocument')]/div[1]/div");
        private By ddlDocument = By.XPath("//input[contains(@id,'ddldocument')]");
        private By chkDoc = By.XPath("//input[contains(@id,'_chkdoc') and @type='radio']");
        private By ddlAttachmentType = By.XPath("//input[contains(@id,'_ddlattachmenttype')]");
        private By txtAttachmentName = By.XPath("//input[contains(@id,'_txtattachmentname')]");
        private By btnDownloadDocument = By.XPath("//span[text()='Download Document']");
        private By lnkCustomRules = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Custom Rules']");
        private By frameManageRules = By.XPath("//iframe[contains(@id,'admin_site-ManageRules')]");
        private By frameManageFields = By.XPath("//iframe[contains(@id,'admin_site-ManageCustomFields')]");
        private By ddlChooseType = By.Id("ctl00_ctl00_cphMain_cphMain_ddlAboutType_Input");
        private By ddlProcess = By.Id("ctl00_ctl00_cphMain_cphMain_ddlEvent_Input");
        private By lblMatchType = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_pnlRuleEvents']//h5[text()='Only for the following match type']");
        private By ddlMatchType = By.Id("ctl00_ctl00_cphMain_cphMain_ddlMatchType_Input");
        private By lblLeaderboard = By.XPath("//em[contains(text(),'Leaderboard')]");
        private By lblPlacement= By.XPath("//div[contains(@id,'ctl00_cphMain_RadDock8')]/em");
        private By txtShowTop = By.XPath("//div[@id='field_ShowTop']/input[2]");
        private By txtFor = By.XPath("//div[@id='s2id_View']/a/span");
        private By lnkCache = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//ul/li/a[text()='Cache']");
        private By frameManageCache = By.XPath("//iframe[contains(@id,'admin_site-ManageCache')]");
        private By btnClearAllItems = By.Id("ctl00_ctl00_cphMain_cphMain_btnClearCache");
        private By msgClear = By.XPath("//div[@id='message_1' and text()='Cache has been cleared.']");
        private By btnClearAllWebItems = By.Id("ctl00_ctl00_cphMain_cphMain_btnClearWebPagesCache");
        //private By tableCache = By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_gridCache_ctl00']/tbody/tr");
        private By tableWebCache = By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_gridWebPagesCache_ctl00']/tbody");
        private By lnkCredentialRequest = By.XPath("//div[@id='RecordCounts']//ul/li//span[@id='RequirementCount']");
        private By tabCredentialRequest = By.XPath("//a[contains(@id,'ui-id') and text()='DHP Credentialing Requests']");
        private By btnAddCredentialRequest = By.XPath("//div[contains(@id,'dhpTargets')]//button[text()='Add DHP Credentialing Request']");
        private By ddldepartments = By.XPath("//div[contains(@id,'ddlfacilitydepartments')]/ul/li/input");
        private By ddlClassification = By.XPath("//input[contains(@id,'ddlfoldergroup')]");
        private By ddlTier = By.XPath("//input[contains(@id,'ddlcredentialrequesttier')]");
        private By ddlPositionType = By.XPath("//input[contains(@id,'ddlpositiontypes')]");
        private By btnAddDHPReq = By.XPath("//button[contains(@id,'savetarget')]/span[text()='Add DHP Req.']");
        private By tableTargets = By.XPath("//div[contains(@id,'dhpTargets')]//table/tbody");
        private By btnRefresh = By.XPath("//div[contains(@id,'dhpTargets')]//button[@class='btn-sm text-color-success icon-refresh btnrefresh'] ");
        private By lblNoData = By.XPath("//div[contains(@id,'dhpTargets')]//h4[text()='There are no related requests on this record.']");
        private By btnclose = By.XPath("//div[contains(@id,'dhpTargets')]//button[text()='Close']");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By lnkDesignDashboards = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Design Dashboards']");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'admin_site-DashboardDesign')]");
        private By txtWidgetName = By.Id("ctl00_ctl00_cphMain_cphMain_txtName");
        private By ddlEntity = By.Id("ctl00_ctl00_cphMain_cphMain_ddlEntity_Input");
        private By ddlRole = By.Id("ctl00_ctl00_cphMain_cphMain_ddlLoggedInAsMode_Input");
        private By ddlDepartmentRole = By.Id("ctl00_ctl00_cphMain_cphMain_ddlDepartmentRoles_Input");
        private By ddlWidth = By.Id("ctl00_ctl00_cphMain_cphMain_ddlLayout_Input");
        private By btnAddDashboard = By.Id("ctl00_ctl00_cphMain_cphMain_btnAdd");
        private By tableDashboard = By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_gridDashboards_ctl00']/tbody");
        private By btnInitializePages = By.Id("ctl00_ctl00_cphMain_cphMain_btnInitializePages_input");
        private By ddlAvailableFields = By.Id("ctl00_ctl00_cphMain_cphMain_ddlAvailableFields_Input");
        private By lblAddCustomRule = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_hpAddField']//h3");
        private By cbRequired = By.Id("ctl00_ctl00_cphMain_cphMain_chkIsRequired");
        private By btnAddField = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_btnAddFieldRule_input' and @value='Add Field Rule']");
        private By lblContactType = By.XPath("//div[@id='ctl00_cphMain_phContactType']/h5/span");
        private By imgMandatory = By.XPath("//div[@id='ctl00_cphMain_phContactType']/h5/img");
        private By tableRules = By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_grdRuleFields_ctl00']/tbody");
        private By btnContactCancel = By.XPath("//input[@id='ctl00_cphMain_btnClose_input' and @value='Cancel']");
        private By lnkTravelStatus = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Travel Statuses']");
        private By frameTravelStatus = By.XPath("//iframe[contains(@id,'admin_site-ManageTravelStatuses')]");
        private By txtStatus = By.Id("ctl00_ctl00_cphMain_cphMain_txtStatusName");
        private By txtSortOrder = By.Id("ctl00_ctl00_cphMain_cphMain_txtSortOrder");
        private By ddlToPerrmission = By.Id("ctl00_ctl00_cphMain_cphMain_ddlPermission_Input");
        private By ddlFromPerrmission = By.Id("ctl00_ctl00_cphMain_cphMain_ddlPermissionFrom_Input");
        private By btnAddStatus = By.Id("ctl00_ctl00_cphMain_cphMain_btnAdd");
        private By cbxTravel = By.Id("ctl00_ctl00_cphMain_cphMain_cbTravelRequired");
        private By msgSuccess = By.XPath("//div[@id='message_1' and text()='Travel Status added successfully.']");
        private By msgUpdateSuccess = By.XPath(" //div[@id='message_2' and text()='Travel Status updated successfully.']");
        private By btnEdit = By.Id("ctl00_ctl00_cphMain_cphMain_gridTravelStatuses_ctl00_ctl04_EditButton");
        private By txtEditStatus = By.Id("ctl00_ctl00_cphMain_cphMain_gridTravelStatuses_ctl00_ctl04_gridtxtName");
        private By btnUpdateIcon = By.Id("ctl00_ctl00_cphMain_cphMain_gridTravelStatuses_ctl00_ctl04_UpdateButton");
        private By tblStatus = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_gridTravelStatuses_ctl00']/tbody");
        private By btnCloseMsg = By.XPath("//*[@id='message_1']/div[@onclick='CloseMessage($(this));']");
        private By lblDatePicker = By.XPath("//div[contains(@id,'DatePickerCandidate')]/h5/span");
        private By btneditbutton = By.XPath("//div[contains(@id,'viewmode')]//div[@id='editbutton' and @data-tipname='candidate/description']");
        private By divSummary = By.XPath("//div[@id='ctl00_summaryPanel']");
        private By txtDatePicker = By.XPath("//input[contains(@id,'DatePickerCandidate_input')]");
        private By btnSave = By.XPath("//button[contains(@id,'btnsave')]/span[text()='Save']");
        private By datePickerValue = By.XPath("//div[@id='ctl00_Norm']/..//following::div[@id='ctl00_DatePickerCandidate']");
        private By lblMyActivePlacements = By.XPath("//em[contains(text(),'My Active Placements')]");
        private By ddlSortBy = By.XPath("//div[@id='s2id_SortBy']/a/span");
        private By ddlDefaultView = By.XPath("//div[@id='s2id_DefaultView']/a/span");
        private By txtPageSize = By.XPath("//div[@id='field_PageSize']/input[2]");
        private By lnkRecruiters = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[contains(text(),'Recruiters') and contains(@href,'recruiters/ManageRecruiters')]");
        private By frameManageRecuriters = By.XPath("//iframe[contains(@id,'admin_recruiters-ManageRecruiters')]");
        private By tableCache = By.XPath("//table[contains(@id,'cphMain_cphMain_gridCache')]/tbody");
        private By frameNewRecruiters = By.XPath("//iframe[contains(@id,'recruiter_new')]");
        private By btnCancelRecruiter = By.XPath("//input[@id='ctl00_cphMain_btnClose_input' and @value='Cancel']");
        private By lnkShiftStatus = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Shift Statuses']");
        private By frameManageShift = By.XPath("//iframe[contains(@id,'admin_site-ManageShiftStatuses')]");
        private By ddlMinimumMatchStatus = By.Id("ctl00_ctl00_cphMain_cphMain_ddlMinMatchStatus_Input");
        private By ddlTimeSheetLineStatus = By.Id("ctl00_ctl00_cphMain_cphMain_ddlTimesheetStatus_Input");
        private By btnEditShiftStatus = By.Id("ctl00_ctl00_cphMain_cphMain_gridShiftStatuses_ctl00_ctl10_EditButton");
        private By txtEditShiftStatus = By.Id("ctl00_ctl00_cphMain_cphMain_gridShiftStatuses_ctl00_ctl10_gridtxtName");
        private By btnUpdateShiftStatus = By.Id("ctl00_ctl00_cphMain_cphMain_gridShiftStatuses_ctl00_ctl10_UpdateButton");
        private By tblShiftStatus = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_gridShiftStatuses_ctl00']/tbody");
        private By msgSuccessShiftStatus = By.XPath("//div[@id='message_1' and text()='Shift Status added successfully.']");
        private By msgUpdateSuccessShiftStatus = By.XPath("//div[@id='message_2' and text()='Shift Status updated successfully.']");
        private By lnkRangecalender = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Range Calendars']");
        private By frameManageRangeCalender = By.XPath("//iframe[contains(@id,'admin_site-ManageRangeCalendars')]");
        private By btnAddNewRangeCalender = By.XPath("//div[@class='bottombuttons']//button");
        private By txtRangeCalenderName = By.XPath("//input[@id='rcName']");
        private By chbInvoiceBilling = By.XPath("//span[text()='Invoice Billing Cycle']/../input");
        private By btnCreateAddRangeCalender = By.XPath("//button[text()='Create New Range Calendar']");
        private By btnPlusIcon = By.XPath("//button[@data-bind='click: AddPeriod']");
        private By txtEndDate = By.XPath("//div[@class='range-date EndDate']/input[contains(@id,'dp')]");
        private By btnSavePeriods = By.XPath("//button[@title='Save Periods']");
        private By msgSuccessPeriods = By.XPath("//div[contains(text(),'Successfully saved the added periods to the range calendar')]");
        private By lnkCustomField = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']//a[text()='Custom Fields']");

        private By btnUserSetting = By.XPath("//span[contains(@id,'xpnlHeader')]/div/span");
        private By lnkPersonalSetting = By.XPath("//a[text()='Personal Settings']");
        private By frameProfileSetting = By.XPath("//iframe[contains(@id,'profile_settings')]");
        private By tabResumeBoardLogins = By.XPath("//div[contains(@id,'cphMain_cphTabs_tabsPages')]//span[text()='Resume Board Logins']");
        private By tblLogins = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[@class='widgetBody']/table/tbody");
        private By headerJobBoard = By.XPath("//th[text()='Job Board']");
        private By headerLogin = By.XPath("//th[text()='Login']");
        private By headerPassword = By.XPath("//th[text()='Password']");
        private By btnAssignPassword = By.XPath("//td[text()='Monster']/following::td//button/span[text()='Assign Password']");
        private By btnChangePassword = By.XPath("//td[text()='Monster']/following::td//button/span[text()='Change Password']");
        private By btnSave1 = By.XPath("//button[text()='Save']");
        private By btnSaveSettings = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnSave_input' and @value='Save Settings']");
        private By btnCancel = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnClose_input' and @value='Cancel']");
        private By txtNewPassword = By.Id("changePasswordNew");
        private By txtRetypeNewPassword = By.Id("changePasswordNewRetype");
        private By btnPasswordSave = By.XPath("//div[@class='widgetContainer widget-md changePasswordWidget']//button[text()='Save']");
        private By txtLogin = By.XPath("//td[text()='Monster']/following::td/input[contains(@data-bind,'value: Login')]");
        private By msgToast = By.XPath("//div[@data-bind='html:Text' and text()='Please assign a new non empty Login and save changes before assigning a new password.']");
        private By msgClose = By.XPath("//div[@title='Dismiss this message.']");
        private By msgPwdSucess = By.XPath("//div[text()='Password successfully changed!']");
        private By txtPwd = By.XPath("//td[text()='Monster']/following::td/input[@type='password']");

        private By txtNewCustomField = By.XPath("//input[contains(@id,'cphMain_cphMain_txtFieldName')]");
        private By ddlType = By.XPath("//input[contains(@id,'cphMain_cphMain_ddlAboutType_Input')]");
        private By ddlDataType = By.XPath("//input[contains(@id,'cphMain_cphMain_ddlDataType_Input')]");
        private By ddlSearchType = By.XPath("//input[contains(@id,'cphMain_cphMain_ddlSearchType_Input')]");
        private By ddlVisibleTo = By.XPath("//input[contains(@id,'cphMain_cphMain_chksVisibleTo_ddlList_Input')]");
        private By txtDefaultValue = By.XPath("//input[contains(@id,'cphMain_cphMain_txtDefaultVal')]");
        private By btnAddCustomField = By.XPath("//input[contains(@id,'cphMain_cphMain_btnAdd')]");
 //Verify user able give empty password
        private By txtSearchControlPanelModule = By.Id("txtAdminMenuFilter");
        private By lnkResumeBoardLoginNew = By.XPath("//a[contains(text(),'Resume Board Logins')]");
        private By SandboxEdit = By.XPath("//div[@class='widgetBody col-4']/div[1]/label//following-sibling::button");
        private By frameJobIndex = By.XPath("//iframe[contains(@id,'JobBoard_Index')]");
        private By btnCancelNew = By.XPath("//button[text()='Cancel']");
        private By bntDisabledSave = By.XPath("//button[text()='Cancel']//following-sibling::button");
        private By txtLoginTextBox = By.XPath("//table[@class='table']//tbody/tr[1]/td[2]/input");
        private By txtPasswordTextBox = By.XPath("//table[@class='table']//tbody/tr[1]/td[3]/input[@type='password']");
        private By btnChangePasswordButton = By.XPath("//table[@class='table']//tbody/tr[1]/td[4]/button/span[text()='Change Password']");
        private By txtPasswordEmpty = By.XPath("//table[@class='table']/tbody/tr[2]/td[3]/input");
        private By btnAssignPwd = By.XPath("//table[@class='table']/tbody/tr[2]/td[4]/button/span[text()='Assign Password']");
        private By txtOptions = By.XPath("//table[@class='table']/tbody/tr[1]/td[5]/input");
        private By btnOverWrite = By.XPath("//table[@class='table']/tbody/tr[1]/td[7]/button[text()='Overwrite']");
        private By msgtoastSuccess = By.XPath("//div[@class='messaging success']");
        private By msgToastDissmiss = By.XPath("//div[@class='messaging success']/div");
        private By newPasswordTextBox = By.XPath("//td[text()='Monster']//following-sibling::td[2]/input");
        private By newChangeButton = By.XPath("//td[text()='Monster']/following::td//button/span[text()='Assign Password']");
        private By txtPwdNew = By.XPath("//input[@id='changePasswordNew']");
        private By txtRetypePwd = By.XPath("//input[@id='changePasswordNewRetype']");
        //verify overwrite button disabled
        private By emptyLoginTxtbox = By.XPath("//tr[2]/td[text()='Dice']//following-sibling::td[1]/input[@type='text']");
        private By btnOverwrite = By.XPath("//tr[1]/td[text()='CareerBuilder']//following-sibling::td[6]/button[text()='Overwrite']");
        private By btnOverWriteCheck = By.XPath("//tr[2]/td[text()='Dice']//following-sibling::td//button[text()='Overwrite']");
        //verify empty password for the sub department
        private By subDeptSandBox = By.XPath("//label[text()='Sandbox II Sub-Department']//following-sibling::button");
        private By btnInherit = By.XPath("//table[@class='table']/tbody/tr[1]/td[6]/button");
        private By copyBtnMsg = By.XPath("//div[@class='widget-sm']/div[2]");
        private By btnCopy = By.XPath("//button[text()='Copy']");
        private By btnCancelSandbox = By.XPath("//div[contains(@id,'_cooltipBridgeId')]//button[text()='Cancel']");
        private By btnSaveSubDepartment = By.XPath("//div[contains(@id,'_cooltipBridgeId')]//button[text()='Save']");
        //verify recuiter able to save empty password

        private By lnkRecruiter = By.XPath("//a[text()='QA Automation']");//Resume Board logins credentials


        //private By lnkResumeBoardLoginNew = By.XPath("//a[contains(text(),'Resume Board Logins')]");
        private By lnkQaAutomation = By.XPath("//a[text()='QA Automation']");
        //private By btnCancelNew = By.XPath("//button[text()='Cancel']");
        //private By bntDisabledSave = By.XPath("//button[text()='Cancel']//following-sibling::button");

        //private By txtLoginTextBox = By.XPath("//table[@class='table']//tbody/tr[1]/td[2]/input");
        //private By txtPasswordTextBox = By.XPath("//table[@class='table']//tbody/tr[1]/td[3]/input[@type='password']");
        //private By btnChangePasswordButton = By.XPath("//table[@class='table']//tbody/tr[1]/td[4]/button/span[text()='Change Password']");
        //private By txtPasswordEmpty = By.XPath("//table[@class='table']/tbody/tr[2]/td[3]/input");
        //private By btnAssignPwd = By.XPath("//table[@class='table']/tbody/tr[2]/td[4]/button/span[text()='Assign Password']");
        //private By txtOptions = By.XPath("//table[@class='table']/tbody/tr[1]/td[5]/input");
        //private By btnOverWrite = By.XPath("//table[@class='table']/tbody/tr[1]/td[7]/button[text()='Overwrite']");
        //private By btnInherit = By.XPath("//table[@class='table']/tbody/tr[1]/td[6]/button");
        //private By SandboxEdit = By.XPath("//div[@class='widgetBody col-4']/div[1]/label//following-sibling::button");

        //Verify Manage Entities
        private By lnkEntities = By.XPath("//a[text()='Entities']");
        private By btnEditEntity = By.XPath("//tr/td[text()='PR_ML_Testing']/../td[5]");
        private By frameManageEntities = By.XPath("//iframe[contains(@id,'admin_site-ManageEntities')]");
        private By ddlLocalResource= By.XPath("//tr[@class='rgEditRow']/td[3]/select");
        private By btnUpadteEntity = By.XPath("//tr[@class='rgEditRow']/td[5]/input[1]");
        private By lnkUpdateMessage = By.XPath("//div[@class='info message']");
        private By lnkUpdatedOption = By.XPath("//tr[@class='rgEditRow']/td[3]/select/option[text()='English (United Kingdom) Default']");
        private By lnkDefaultOption= By.XPath("//tr[@class='rgEditRow']/td[3]/select/option[text()='English (United States) Default']");        
        #endregion
        #region Public Methods

        public void ClickOnFolderGroups(string folderGroups)
        {
            try
            {
                driver.WaitElementPresent(txtSearch);
                driver.SendKeysToElement(txtSearch, folderGroups, "Search");
                driver.WaitElementPresent(lnkFolderGroups);
                driver.ClickElement(lnkFolderGroups, "Folder Groups");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Folder Groups", "Failed to click on Folder Groups:", EngineSetup.GetScreenShotPath());
            }
        }

        public void UpdateFolderGroups(string newFolderGroup, string newFolderName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroups')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroups')]"));
                driver.SendKeysToElement(txtNewFolderGroup, newFolderGroup, "Enter New Folder Group");
                driver.WaitElementPresent(ddlCategory);
                driver.ClickElement(ddlCategory, "Select Category");
                driver.sleepTime(1000);
                IList<IWebElement> CategoryElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlCategory_DropDown']/div/ul"));
                var CategoryOptions = CategoryElement.First().FindElements(By.TagName("li"));
                CategoryOptions[0].Click();
                driver.WaitElementPresent(btnAddFolderGroup);
                driver.ClickElement(btnAddFolderGroup, "Click Add Folder Group");
                //driver.sleepTime(5000);
                driver.WaitElementPresent(btnClose);
                driver.ClickElement(btnClose, "Close Message Box");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnEditFolderGroup);
                driver.ClickElement(btnEditFolderGroup, "Edit Folder Group");
                driver.SendKeysToElementAndPressEnter(txtNameEdit, newFolderName, "Folder Group Name");
                driver.WaitElementPresent(btnUpdateFolderGroup);
                driver.sleepTime(5000);
                driver.ClickElement(btnUpdateFolderGroup, "Update Folder Group");
                driver.WaitElementPresent(updateMessage);
                driver.VerifyWebElementPresent(updateMessage, "Update Message");
                driver.sleepTime(5000);
                driver.ClickElement(btnClose, "Close Message Box");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Update Folder Groups", "Failed to update Folder Groups:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnFolderGroupStatus(string folderGroupStatus)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, folderGroupStatus, "Search");
                driver.WaitElementPresent(lnkFolderGroupStatus);
                driver.ClickElement(lnkFolderGroupStatus, "Folder Group Status");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Folder Groups Status", "Failed to click on Folder Group status", EngineSetup.GetScreenShotPath());
            }
        }

        public void AddFolderGroupStatus(string name, string sortby)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroupStatuses')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroupStatuses')]"));
                driver.VerifyWebElementPresent(lnkAddNewStatus, "Add New Status Link");
                driver.ClickElement(lnkAddNewStatus, "Click on Add New Status Link");
                driver.sleepTime(2000);
                driver.VerifyWebElementPresent(popupAddNewStatus, "Pop up Add new status");
                driver.SendKeysToElementAndPressEnter(txtName, name, "Name:");
                driver.ClickElement(colorPicker, "Click ColorPicker");
                By by = By.XPath("/html/body/div[3]/div/div[1]/a[3]");
                driver.ClickElement(by, "Click on a random color");
                driver.SendKeysToElementAndPressEnter(txtSortedOrder, sortby, "Sort Order:");
                driver.ClickElement(btnCreateSave, "click on Create");
                driver.sleepTime(2000);
                IWebElement tableElement = this.driver.FindElement(By.XPath("//div[contains(@id,'cooltipBridgeId')]/div/table/tbody"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(name))
                    {
                        count++;
                    }
                }
                if (count == 1)
                    TESTREPORT.LogSuccess("Add Folder Group Status", string.Format("Name : <Mark>{0}</Mark> is added Successfully", name));
                else
                    TESTREPORT.LogFailure("Add Folder Group Status", string.Format("Name : <Mark>{0}</Mark> is not added ", name));

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Folder Group Status", "Failed to Add Folder Group Status:", EngineSetup.GetScreenShotPath());
            }
        }

        public void DeleteFolderGroupStatus(string name)
        {
            try
            {
                By by = By.XPath(string.Format("//table/tbody/tr/td/div[text()='{0}']/../following::td//div[@class='Delete']", name));
                driver.ClickElement(by, "Delete");
                driver.sleepTime(1000);
                hm.HandleAlert();
                //driver.RefreshPage();
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(By.XPath("//div[contains(@id,'cooltipBridgeId')]/div/table/tbody"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(name))
                    {
                        count++;
                    }
                }
                driver.sleepTime(5000);
                if (count == 0)
                    TESTREPORT.LogSuccess("Delete Folder Group Status", string.Format("Name : <Mark>{0}</Mark> is deleted Successfully", name));
                else
                    TESTREPORT.LogFailure("Delete Folder Group Status", string.Format("Name : <Mark>{0}</Mark> is not deleted ", name));
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Delete Folder Group Status", "Failed to Delete Folder Group Status:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnResumeBoardLogin(string resumeBoardLogin)
        {
            try
            {
                driver.WaitElementPresent(txtSearch);
                driver.SendKeysToElement(txtSearch, resumeBoardLogin, "Search");
                driver.WaitElementPresent(lnkResumeBoardLogin);
                driver.ClickElement(lnkResumeBoardLogin, "Click on Resume Board Login");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Resume Board Login", "Failed to click on Resume Board Login:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyDepartmentTree(string label)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameResumeBoard);
                driver.SwitchToFrameByLocator(frameResumeBoard);               
                By departmentWithoutExpansion = By.XPath(string.Format("//div[@class='departmentChildren']//label[@class='departmentName expandable-label' and text()='{0}']", label));
                driver.WaitElementPresent(departmentWithoutExpansion);
                if (driver.IsElementPresent(departmentWithoutExpansion))
                    TESTREPORT.LogSuccess("Department Tree", "Able to view collapsed Department tree");
                else
                    TESTREPORT.LogFailure("Department Tree", "Unable to view collapsed Department tree");
                driver.SendKeysToElementAndPressEnter(txtDepartmentSearch, label, "Search Department");
                By departmentWithExpansion = By.XPath(string.Format("//div[@class='departmentChildren']//label[@class='departmentName expandable-label open' and text()='{0}']", label));
                driver.WaitElementPresent(departmentWithExpansion);
                if (driver.IsElementPresent(departmentWithExpansion))
                    TESTREPORT.LogSuccess("Department Tree", "Able to view expanded Department tree");
                else
                    TESTREPORT.LogFailure("Department Tree", "Unable to view expanded Department tree");
                driver.WaitElementPresent(departmentWithExpansion);
                driver.ClickElement(departmentWithExpansion, "Click Department With Expansion");               
                if (driver.IsElementPresent(departmentWithoutExpansion))
                    TESTREPORT.LogSuccess("Department Tree", "Able to view collapsed Department tree");
                else
                    TESTREPORT.LogFailure("Department Tree", "Unable to view collapsed Department tree");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Department Tree", "Failed to Verify Department Tree:", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateAgreement(string agreementName)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameAgreementNew);
                driver.SwitchToFrameByLocator(frameAgreementNew);
                driver.WaitElementPresent(ddlCompany);
                driver.ClickElement(ddlCompany, "Select Company");
                driver.sleepTime(2000);
                //By selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitElementPresent(selectDdn);
                IList<IWebElement> CompanyElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlCompany_DropDown']/div[1]/ul"));
                var CompanyOptions = CompanyElement.First().FindElements(By.TagName("li"));
                CompanyOptions[0].Click();
                driver.WaitElementPresent(ddlContact);
                driver.ClickElement(ddlContact, "Select Contact");
                driver.sleepTime(1000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitForElement(selectDdn, TimeSpan.MaxValue);
                IList<IWebElement> ContactElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlContact_DropDown']/div[1]/ul"));
                var ContactOptions = ContactElement.First().FindElements(By.TagName("li"));
                ContactOptions[0].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtAgreementName);
                driver.SendKeysToElement(txtAgreementName, agreementName, "Enter Agreement Name");
                driver.sleepTime(2000);
                driver.ClickElement(ddlAgreementType, "Select Agreement Type");
                driver.sleepTime(2000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitElementPresent(selectDdn);
                IList<IWebElement> AgreementElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlAgreementType_DropDown']/div/ul"));
                var AgreementOptions = AgreementElement.First().FindElements(By.TagName("li"));
                AgreementOptions[0].Click();
                driver.WaitElementPresent(ddlBilling);
                driver.ClickElement(ddlBilling, "Select Billing");
                driver.sleepTime(2000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitForElement(selectDdn, TimeSpan.MaxValue);
                IList<IWebElement> BillingElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlBillingTerm_DropDown']/div/ul"));
                var BillingOptions = BillingElement.First().FindElements(By.TagName("li"));
                BillingOptions[0].Click();
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnSaveAgreement);
                driver.ClickElement(btnSaveAgreement, "Save Agreement");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Agreement", "Failed to Create Agreement", EngineSetup.GetScreenShotPath());
            }
        }

        public void GenerateDocument(string agreement, string attachmentValue, string attachmentName)
        {
            try
            {               
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAgreementManage);
                driver.SwitchToFrameByLocator(frameAgreementManage);
                driver.WaitElementPresent(lnkGenerateDocument);
                driver.ClickElement(lnkGenerateDocument, "Click Generate Document");
                driver.WaitElementPresent(ddlDocument);
                driver.ClickElement(ddlDocument, "Select Document");
                By by = By.XPath("//span[@role='status' and contains(text(),'results are available, use up and down arrow keys to navigate.')]");
                driver.WaitElementPresent(by);
                By documentList = By.XPath(string.Format("//ul[contains(@id,'ui-id')]/li[2]//a[contains(@id,'ui-id') and text()='{0}']", agreement));
                driver.ClickElement(documentList, "Select a document");
                driver.WaitElementPresent(chkDoc);
                driver.ClickElement(chkDoc, "Select Doc radio button");
                driver.ClickElement(ddlAttachmentType, "Select Attachment type");
                by = By.XPath("//span[@role='status' and contains(text(),'results are available, use up and down arrow keys to navigate.')]");
                driver.WaitElementPresent(by);
                By attachmentList = By.XPath(string.Format("//ul[contains(@id,'ui-id')]/li[1]//a[contains(@id,'ui-id') and text()='{0}']", attachmentValue));
                driver.ClickElement(attachmentList, "Select Attachment Value");
                driver.sleepTime(1000);
                driver.WaitElementPresent(txtAttachmentName);
                driver.SendKeysToElementAndPressEnter(txtAttachmentName, attachmentName, "Attachment Name");
                driver.WaitElementPresent(btnDownloadDocument);
                driver.ClickElement(btnDownloadDocument, "Click Download Document");
                TESTREPORT.LogSuccess("Generate Document", "Generated Document Successfully");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Generate Document", "Failed to Generate Document");
            }

            #endregion
        }

        public void ClickOnCustomRules(string customRules)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, customRules, "Search");
                driver.WaitElementPresent(lnkCustomRules);
                driver.ClickElement(lnkCustomRules, "Click Custom Rules");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Custom Rules", "Failed to click on Custom Rules", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyMatchTypeCustomRules(string MatchType1, string MatchType2)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageRules);
                driver.SwitchToFrameByLocator(frameManageRules);
                driver.WaitElementPresent(btnInitializePages);
                driver.ClickElement(btnInitializePages, "Initialize Pages");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlChooseType);
                driver.ClickElement(ddlChooseType, "Choose Type");
                driver.sleepTime(2000);
                //By selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitForElement(selectDdn, TimeSpan.MaxValue);
                IList<IWebElement> TypeElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlAboutType_DropDown']/div/ul"));
                var TypeOptions = TypeElement.First().FindElements(By.TagName("li"));
                TypeOptions[4].Click();
                driver.sleepTime(2000);
                driver.WaitElementPresent(ddlProcess);
                driver.ClickElement(ddlProcess, "Process When drop down");
                driver.sleepTime(1000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitForElement(selectDdn, TimeSpan.MaxValue);
                IList<IWebElement> ProcessElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlEvent_DropDown']/div/ul"));
                var ProcessOptions = ProcessElement.First().FindElements(By.TagName("li"));
                ProcessOptions[2].Click();
                driver.WaitElementPresent(lblMatchType);
                if (driver.IsElementPresent(lblMatchType))
                {
                    TESTREPORT.LogSuccess("Label Match Type", "Label Match type is available");
                }
                else
                {
                    TESTREPORT.LogFailure("Label Match Type", "Label Match type is not available");
                }
                driver.WaitElementPresent(ddlMatchType);
                driver.ClickElement(ddlMatchType, "Click Match Type Ddn");
                 driver.sleepTime(1000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitForElement(selectDdn, TimeSpan.MaxValue);
                IList<IWebElement> MatchElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlMatchType_DropDown']/div/ul/li"));
                driver.sleepTime(5000);
                string s1 = MatchElement[0].Text;
                string s2 = MatchElement[1].Text;
                if (MatchType1.Equals(s1) && MatchType2.Equals(s2))
                {
                    TESTREPORT.LogSuccess("Verify Match Type elements", "Contract and Perm palcements are available");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Match Type elements", "Contract and Perm palcements are not available");
                }
                driver.sleepTime(10000);

            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Match Type Custom Rules", "Failed to verify Match Type Custom Rules", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyLeaderboardWidget()
        {
            try
            {
                driver.WaitElementPresent(lblLeaderboard);
                driver.VerifyWebElementPresent(lblLeaderboard, "Leaderboard Label");
                string value1 = driver.GetElementText(txtShowTop);
                string value2 = driver.GetElementText(txtFor);
                if (value1 != null && value2 != null)
                {
                    TESTREPORT.LogSuccess("Verify Pulled up data", "Able to view data being pulled to Leaderboard widget");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Pulled up data", "Failed to view data being pulled to Leaderboard widget");
                }
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Leaderboard Widget", "Failed to Verify Leaderboard Widget", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify Current Placement Dashboard
        /// </summary>
        public void VerifyCurrentPlacementWedget()
        {
            try
            {
                driver.WaitElementPresent(lblPlacement);
                driver.VerifyWebElementPresent(lblPlacement, "Placement");
                //    string value1 = driver.GetElementText(txtShowTop);
                //    string value2 = driver.GetElementText(txtFor);
                //    if (value1 != null && value2 != null)
                //    {
                //        TESTREPORT.LogSuccess("Verify Pulled up data", "Able to view data being pulled to Leaderboard widget");
                //    }
                //    else
                //    {
                //        TESTREPORT.LogFailure("Verify Pulled up data", "Failed to view data being pulled to Leaderboard widget");
                //    }
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Placement Widget", "Failed to Verify Placement Widget", EngineSetup.GetScreenShotPath());
            }

        }
        public void ClickOnCache(string cache)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, cache, "Search");
                driver.WaitElementPresent(lnkCache);
                driver.ClickElement(lnkCache, "Click on Cache");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Cache", "Failed to click on Cache:", EngineSetup.GetScreenShotPath());
            }
        }

        public void DeleteCacheItems()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManageCache);
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCache);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnClearAllItems);
                driver.ClickElement(btnClearAllItems, "Click Clear All items of Cache");
                driver.WaitElementPresent(msgClear);
                driver.VerifyWebElementPresent(msgClear, "Cache has been cleared.");
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(tableCache);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                if (tableRow.Count == 1)
                    TESTREPORT.LogSuccess("Items count in Cache", "Cache has been cleared:");
                else
                    TESTREPORT.LogFailure("Items count in Cache", "Cache has not been cleared:");
                driver.ScrollPage();
                driver.WaitElementPresent(btnClearAllWebItems);
                driver.ClickElement(btnClearAllWebItems, "Click Clear All items of Web Page Cache");
                driver.sleepTime(10000);
                tableElement = this.driver.FindElement(tableWebCache);
                IList<IWebElement> tableRow1 = tableElement.FindElements(By.TagName("tr"));
                if (tableRow1.Count == 1)
                    TESTREPORT.LogSuccess("Items count in Web Page Cache", "Web Page Cache has been cleared:");
                else
                    TESTREPORT.LogFailure("Items count in Web Page Cache", "Web Page Cache has not been cleared:");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Delete Cache Items", "Failed to delete Cache:", EngineSetup.GetScreenShotPath());
            }
        }

        public void DeleteDHPCredentialingRequest(string departmentValue, string classification, string tier, string ptype)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameManageCandidate);
                var requirement = driver.FindElement(lnkCredentialRequest);
                Actions act = new Actions(driver);
                act.ContextClick(requirement).Build().Perform();
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                driver.ClickElement(tabCredentialRequest, "Tab DHP Credential Request");
                driver.WaitForElement(btnAddCredentialRequest, TimeSpan.FromSeconds(30));
                driver.ClickElement(btnAddCredentialRequest, "Click Add DHP Credentialing Request");
                driver.ClickElement(ddldepartments, "select departments");
                By by = By.XPath("//div[@class='select2-container select2-container-multi select2-dropdown-open']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                driver.SendKeysToElement(ddldepartments, "te", "enter a random value");
                by = By.XPath(string.Format("//div[@class='select2-drop select2-drop-multi select2-drop-active']/ul/li/div[contains(text(),'{0}')]", departmentValue));
                driver.ClickElement(by, "");
                driver.SendKeysToElement(ddldepartments, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(10000);
                driver.ClickElement(ddlClassification, "select Classification");
                by = By.XPath("//span[@role='status' and text()='378 results are available, use up and down arrow keys to navigate.']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                by = By.XPath(string.Format("//a[contains(@id,'ui-id') and text()='{0}']", classification));
                driver.ClickElement(by, "");
                driver.SendKeysToElement(ddlClassification, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(1000);
                driver.ClickElement(ddlTier, "select Classification");
                by = By.XPath("//span[@role='status' and text()='3 results are available, use up and down arrow keys to navigate.']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                by = By.XPath(string.Format("//a[contains(@id,'ui-id') and text()='{0}']", tier));
                driver.ClickElement(by, "");
                driver.SendKeysToElement(ddlTier, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(1000);
                driver.ClickElement(ddlPositionType, "select Classification");
                by = By.XPath("//span[@role='status' and text()='6 results are available, use up and down arrow keys to navigate.']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                by = By.XPath(string.Format("//a[contains(@id,'ui-id') and text()='{0}']", ptype));
                driver.ClickElement(by, "");
                driver.SendKeysToElement(ddlPositionType, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(1000);
                driver.ClickElement(btnAddDHPReq, "Click Add DHP Req");
                driver.WaitForPageLoad(TimeSpan.MaxValue);
                driver.ScrollPage();
                act.ContextClick(requirement).Build().Perform();
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                driver.ClickElement(tabCredentialRequest, "Tab DHP Credential Request");
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                By btnDelete = By.XPath("//div[contains(@id,'dhpTargets')]/div[2]/table/tbody/tr[2]/td[10]/div[@title='Remove this target']/span");
                driver.ClickElement(btnDelete, "Click Delete");
                hm.HandleAlert();
                driver.ClickElement(btnRefresh, "Click Refresh");
                if (driver.IsElementPresent(lblNoData))
                {
                    TESTREPORT.LogSuccess("No Data Request", "There are no related requests on this record:", EngineSetup.GetScreenShotPath());
                }
                else
                {
                    TESTREPORT.LogFailure("No Data Request", "There are related requests on this record:", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Delete DHP Credentialing Request", "Failed to Delete DHP Credentialing Request:", EngineSetup.GetScreenShotPath());
            }
            driver.ClickElement(btnclose, "Click Close");
        }

        public void ClickDesignDashboard(string designDashboard)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, designDashboard, "Search");
                driver.WaitElementPresent(lnkDesignDashboards);
                driver.ClickElement(lnkDesignDashboards, "Click on Design Dashboard");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Design Dashboard", "Failed to click on Design Dashboard", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyFieldsBehavoir(string wName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameDashboard);
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.WaitElementPresent(txtWidgetName);
                driver.FindElement(txtWidgetName).Click();
                driver.SendKeysToElement(txtWidgetName, wName, "Enter Widget Name");
                driver.SendKeysToElement(txtWidgetName, OpenQA.Selenium.Keys.Tab, "");
                driver.ClickElement(ddlEntity, "Select Entity");
                driver.sleepTime(1000);
                IList<IWebElement> EntityElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlEntity_DropDown']/div/ul"));
                var EntityOptions = EntityElement.First().FindElements(By.TagName("li"));
                EntityOptions[0].Click();
                driver.SendKeysToElement(ddlEntity, OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(1000);
                driver.WaitElementPresent(ddlRole);
                driver.ClickElement(ddlRole, "Select Role");
                driver.sleepTime(1000);
                IList<IWebElement> RoleElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlLoggedInAsMode_DropDown']/div/ul"));
                var RoleOptions = RoleElement.First().FindElements(By.TagName("li"));
                RoleOptions[0].Click();
                driver.SendKeysToElement(ddlRole, OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(1000);
                driver.WaitElementPresent(ddlDepartmentRole);
                driver.ClickElement(ddlDepartmentRole, "Select Department Role");
                driver.sleepTime(1000);
                IList<IWebElement> DeptRoleElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlDepartmentRoles_DropDown']/div/ul"));
                var DeptRoleOptions = DeptRoleElement.First().FindElements(By.TagName("li"));
                DeptRoleOptions[0].Click();
                driver.sleepTime(1000);
                driver.WaitElementPresent(ddlWidth);
                driver.ClickElement(ddlWidth, "Select Width");
                driver.sleepTime(1000);
                IList<IWebElement> WidthElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlLayout_DropDown']/div/ul"));
                var WidthOptions = WidthElement.First().FindElements(By.TagName("li"));
                WidthOptions[0].Click();
                driver.sleepTime(1000);
                driver.WaitElementPresent(btnAddDashboard);
                driver.ClickElement(btnAddDashboard, "Click Add Dashboard");
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(tableDashboard);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(wName))
                    {
                        count++;
                    }
                }
                driver.sleepTime(10000);
                if (count >= 1)
                    TESTREPORT.LogSuccess("Add Widget to Dashboard", "Successfully added item to dashboard");
                else
                    TESTREPORT.LogFailure("Add Widget to Dashboard", "Unable to add item to dashboard:");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Fields Behavoir", "Failed to Verify Fields Behavoir", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddContactCustomRules()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageRules);
                driver.SwitchToFrameByLocator(frameManageRules);
                driver.WaitElementPresent(btnInitializePages);
                driver.ClickElement(btnInitializePages, "Initialize Pages");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlChooseType);
                driver.ClickElement(ddlChooseType, "Choose Type");
                driver.sleepTime(1000);
                //By selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitElementPresent(selectDdn);
                IList<IWebElement> TypeElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlAboutType_DropDown']/div/ul"));
                var TypeOptions = TypeElement.First().FindElements(By.TagName("li"));
                TypeOptions[1].Click();
                driver.WaitElementPresent(ddlProcess);
                driver.ClickElement(ddlProcess, "Process When drop down");
                driver.sleepTime(1000);
                //selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                //driver.WaitElementPresent(selectDdn);
                IList<IWebElement> ProcessElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlEvent_DropDown']/div/ul"));
                var ProcessOptions = ProcessElement.First().FindElements(By.TagName("li"));
                ProcessOptions[0].Click();
                driver.WaitElementPresent(lblAddCustomRule);
                if (driver.IsElementPresent(lblAddCustomRule))
                {
                    TESTREPORT.LogSuccess("Label Add Custom Rule", "Label Add Custom Rule is available");
                }
                else
                {
                    TESTREPORT.LogFailure("Label Add Custom Rule", "Label Add Custom Rule is not available");
                }
                driver.sleepTime(2000);
                driver.WaitElementPresent(ddlAvailableFields);
                driver.ClickElement(ddlAvailableFields, "Click Available Fields Ddn");
                driver.sleepTime(5000);
                IList<IWebElement> AvailFieldElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlAvailableFields_DropDown']/div/ul"));
                var AvailOptions = AvailFieldElement.First().FindElements(By.TagName("li"));
                AvailOptions[3].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(cbRequired);
                driver.ClickElement(cbRequired, "Required field");
                driver.WaitElementPresent(btnAddField);
                driver.ClickElement(btnAddField, "Click Add Field");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Contact Custom Rules", "Failed to Add Contact Custom Rule", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyContactCustomRule()
        {
            try
            {
                driver.sleepTime(20000);
                driver.VerifyWebElementPresent(lblContactType, "Label Contact Type");
                driver.WaitElementPresent(imgMandatory);
                if (driver.IsElementPresent(imgMandatory))
                {
                    TESTREPORT.LogSuccess("Verify Contact Custom Rule", "Able to view custom rule applied to Contact Type");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Contact Custom Rule", "Failed to view custom rule applied to Contact Type");
                }
                driver.ClickElement(btnContactCancel, "Click Cancel button in Add Contact Screen");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Contact Custom Rule", "Failed to view custom rule applied to Contact Type", EngineSetup.GetScreenShotPath());
            }

        }

        public void DeleteContactCustomRule(string contactCustomRule)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageRules);
                driver.SwitchToFrameByLocator(frameManageRules);
                By btnDelete = By.XPath("//input[contains(@id,'gbcDelete')]");
                //By.XPath(string.Format("//td//span[@id='ctl00_ctl00_cphMain_cphMain_grdRuleFields_ctl00_ctl05_lblFieldName' and text()='{0}']/../..//following::td//input[@id='ctl00_ctl00_cphMain_cphMain_grdRuleFields_ctl00_ctl05_gbcDelete']", contactCustomRule));
                IWebElement tableElement = this.driver.FindElement(tableRules);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(contactCustomRule))
                    {
                        driver.ClickElement(btnDelete, "Delete the Custom Rule");
                    }
                }
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Delete Contact Custom Rule", "Failed to Delete custom rule applied to Contact Type", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickTravelStatus(string travelStatus)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, travelStatus, "Search");
                driver.WaitElementPresent(lnkTravelStatus);
                driver.ClickElement(lnkTravelStatus, "Click on Travel Statuses");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Travel Statuses", "Failed to click on Travel Statuses", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddTravelStatus(string statusName, string sortorder)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameTravelStatus);
                driver.SwitchToFrameByLocator(frameTravelStatus);
                driver.WaitElementPresent(txtStatus);
                driver.SendKeysToElement(txtStatus, statusName, "Status Name");
                driver.SendKeysToElement(txtStatus, OpenQA.Selenium.Keys.Tab, "");
                driver.WaitElementPresent(txtSortOrder);
                driver.SendKeysToElement(txtSortOrder, sortorder, "Sort order");
                driver.SendKeysToElement(txtSortOrder, OpenQA.Selenium.Keys.Tab, "");
                driver.WaitElementPresent(ddlToPerrmission);
                driver.ClickElement(ddlToPerrmission, "To Permission");
                driver.sleepTime(1000);
                IList<IWebElement> PermissionElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlPermission_DropDown']/div/ul"));
                var PermissionOptions = PermissionElement.First().FindElements(By.TagName("li"));
                PermissionOptions[1].Click();
                driver.sleepTime(1000);
                driver.WaitElementPresent(ddlFromPerrmission);
                driver.ClickElement(ddlFromPerrmission, "From Permission");
                driver.sleepTime(1000);
                IList<IWebElement> PermissionElement1 = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlPermissionFrom_DropDown']/div/ul"));
                var PermissionOptions1 = PermissionElement1.First().FindElements(By.TagName("li"));
                PermissionOptions1[1].Click();
                driver.sleepTime(1000);
                //driver.ClickElement(ddlMinimumMatchStatus, "Click on Minimum Match Status");
                //IList<IWebElement> MatchElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlMinMatchStatus_DropDown']/div/ul"));
                //var MatchOptions = MatchElement.First().FindElements(By.TagName("li"));
                //MatchOptions[1].Click();
                //driver.ClickElement(ddlTimeSheetLineStatus, "Click on Timesheet Line Status");
                //IList<IWebElement> TimeSheetElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlTimesheetStatus_DropDown']/div/ul"));
                //var TimeSheetOptions = TimeSheetElement.First().FindElements(By.TagName("li"));
                //TimeSheetOptions[1].Click();
                driver.ClickElement(btnAddStatus, "Click Add Status");
                driver.WaitElementPresent(msgSuccess);
                if (driver.IsElementPresent(msgSuccess))
                {
                    TESTREPORT.LogSuccess("Add Travel Statuses", "Able to view Success message after adding new  Travel Statuses");
                }
                else
                {
                    TESTREPORT.LogFailure("Add Travel Statuses", "Failed to view Success message after adding new  Travel Statuses");
                }
                driver.WaitElementPresent(btnCloseMsg);
                driver.ClickElement(btnCloseMsg, "Close the Messgebox");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Travel Statuses", "Failed to Add Travel Statuses", EngineSetup.GetScreenShotPath());
            }

        }

        public void EditTravelStatus(string statusName)
        {
            try
            {
                IWebElement tableElement = this.driver.FindElement(tblStatus);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(statusName))
                    {
                        driver.ClickElement(btnEdit, "Edit the existing Status");
                    }
                }
                statusName = statusName + "A";
                driver.SendKeysToElementClearFirst(txtEditStatus, statusName, "Modify Status Name");
                driver.SendKeysToElement(txtEditStatus, OpenQA.Selenium.Keys.Tab, "");
                driver.ClickElement(btnUpdateIcon, "Click on Update Icon");
                driver.WaitForElement(msgUpdateSuccess, TimeSpan.FromSeconds(30));
                if (driver.IsElementPresent(msgUpdateSuccess))
                {
                    TESTREPORT.LogSuccess("Edit Travel Statuses", "Able to view Update Success message after updating existing Travel Statuses");
                }
                else
                {
                    TESTREPORT.LogFailure("Edit Travel Statuses", "Failed to view Update Success message after updating existing Travel Statuses");
                }
                //By btnDelete = By.Id("ctl00_ctl00_cphMain_cphMain_gridTravelStatuses_ctl00_ctl04_gbcDeleteColumn");
                //driver.ClickElement(btnDelete, "eDelete status");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Edit Travel Statuses", "Failed to Edit Travel Statuses", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyDatePicker(string date)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.MouseHover(divSummary, "Hover the Summary to view Edit button");
                driver.WaitElementPresent(btneditbutton);
                driver.ClickElementWithJavascript(btneditbutton, "Click Edit Button");
                driver.sleepTime(1000);
                driver.ScrollPage();
                driver.SendKeysToElementClearFirst(txtDatePicker, date, "Enter the date");
                driver.ClickElement(btnSave, "Click Save button");
                driver.WaitElementPresent(lblDatePicker);
                driver.VerifyWebElementPresent(lblDatePicker, "DatePicker");
                driver.WaitElementPresent(datePickerValue);
                driver.sleepTime(3000);
                string newDate = driver.GetElementText(datePickerValue);
                    //driver.FindElement(datePickerValue).ToString();
                    //.Text.Split('\n').ToString();
                if (newDate.Contains(date))
                {
                    TESTREPORT.LogSuccess("Verify Date Picker", "Able to view Updated value under the datepicker");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Date Picker", "Failed to view Updated value under the datepicker");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Date Picker", "Failed to view Updated value under the datepicker", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyMyActivePlacementWidget()
        {
            try
            {
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                driver.VerifyWebElementPresent(lblMyActivePlacements, "My Active Placements Label");
                string value1 = driver.GetElementText(ddlSortBy);
                string value2 = driver.GetElementText(ddlDefaultView);
                string value3 = driver.GetElementAttribute(txtPageSize, "value");
                if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2) && !string.IsNullOrEmpty(value3))
                {
                    TESTREPORT.LogSuccess("Verify Pulled up data", "Able to view data being pulled to My Active Placement widget");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Pulled up data", "Failed to view data being pulled to My Active Placement widget");
                }
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify My Active Placement Widget", "Failed to Verify My Active Placement Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnRecuriters(string recuriter)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, recuriter, "Search");
                driver.WaitElementPresent(lnkRecruiters);
                driver.ClickElement(lnkRecruiters, "Click on Recruiters");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Recruiters", "Failed to click on Recruiters", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectDepartment(string recuriterdept)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManageRecuriters);
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageRecuriters);
                By department = By.XPath(string.Format("//div[@id='ctl00_ctl00_cphMain_cphMain_treeUsers']/ul//span[text()='{0}']", recuriterdept));
                driver.ClickElement(department, "Select Department");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameNewRecruiters);
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameNewRecruiters);
                driver.ClickElement(btnCancelRecruiter, "Click Cancel");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Select Department", "Failed to select Department", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyCache(string lookupValue)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManageCache);
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCache);
                IWebElement tableElement = this.driver.FindElement(tableCache);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(lookupValue))
                    {
                        count++;
                    }
                }
                if (count > 0)
                    TESTREPORT.LogSuccess("Verify Cache for Lookup Value", string.Format("Department Look up Value : <Mark>{0}</Mark> is available in cache", lookupValue));
                else
                    TESTREPORT.LogFailure("Verify Cache for Lookup Value", string.Format("Department Look up Value : <Mark>{0}</Mark> is not available in cache", lookupValue));
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Cache", "Failed to select Department", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickonShiftStatues(string shiftStatues)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, shiftStatues, "Search");
                driver.WaitElementPresent(lnkShiftStatus);
                driver.ClickElement(lnkShiftStatus, "Click on Shift Statues");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Shift Statues", "Failed to click on Shift Statues", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddShiftStatus(string shiftStatus, string sortorder)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameManageShift);
                driver.SwitchToFrameByLocator(frameManageShift);
                driver.SendKeysToElement(txtStatus, shiftStatus, "Status Name");
                driver.SendKeysToElement(txtStatus, OpenQA.Selenium.Keys.Tab, "");
                driver.SendKeysToElement(txtSortOrder, sortorder, "Sort order");
                driver.SendKeysToElement(txtSortOrder, OpenQA.Selenium.Keys.Tab, "");
                driver.ClickElement(ddlToPerrmission, "To Permission");
                driver.sleepTime(1000);
                IList<IWebElement> PermissionElement = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlPermission_DropDown']/div/ul"));
                var PermissionOptions = PermissionElement.First().FindElements(By.TagName("li"));
                PermissionOptions[1].Click();
                driver.SendKeysToElement(ddlToPerrmission, OpenQA.Selenium.Keys.Enter, "");
                driver.WaitElementPresent(ddlFromPerrmission);
                driver.ClickElement(ddlFromPerrmission, "From Permission");
                driver.sleepTime(1000);
                IList<IWebElement> PermissionElement1 = driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlPermissionFrom_DropDown']/div/ul"));
                var PermissionOptions1 = PermissionElement1.First().FindElements(By.TagName("li"));
                PermissionOptions1[1].Click();
                driver.sleepTime(1000);
                driver.ClickElement(btnAddStatus, "Click Add Status");
                driver.WaitElementPresent(msgSuccessShiftStatus);
                if (driver.IsElementPresent(msgSuccessShiftStatus))
                {
                    TESTREPORT.LogSuccess("Add Shift Statuses", "Able to view Success message after adding new  Shift Statuses");
                }
                else
                {
                    TESTREPORT.LogFailure("Add Shift Statuses", "Failed to view Success message after adding new  Shift Statuses");
                }
                driver.ClickElement(btnCloseMsg, "Close the Messgebox");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Travel Statuses", "Failed to Add Travel Statuses", EngineSetup.GetScreenShotPath());
            }


        }

        public void EditShiftStatus(string shiftStatus)
        {
            try
            {
                IWebElement tableElement = this.driver.FindElement(tblShiftStatus);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(shiftStatus))
                    {
                        driver.ClickElement(btnEditShiftStatus, "Edit the existing Status");
                        shiftStatus = shiftStatus + "A";
                        driver.SendKeysToElementClearFirst(txtEditShiftStatus, shiftStatus, "Modify Status Name");
                        driver.SendKeysToElement(txtEditShiftStatus, OpenQA.Selenium.Keys.Enter, "");
                        driver.ClickElement(btnUpdateShiftStatus, "Click on Update Icon");
                        break;
                    }
                }
                driver.WaitForElement(msgUpdateSuccessShiftStatus, TimeSpan.FromSeconds(30));
                if (driver.IsElementPresent(msgUpdateSuccessShiftStatus))
                {
                    TESTREPORT.LogSuccess("Edit Shift Statuses", "Able to view Update Success message after updating existing Shift Statuses");
                }
                else
                {
                    TESTREPORT.LogFailure("Edit Shift Statuses", "Failed to view Update Success message after updating existing Shift Statuses");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Edit Shift Statuses", "Failed to Edit Shift Statuses", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnRangeCalender(string rangeCalender)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, rangeCalender, "Search");
                driver.WaitElementPresent(lnkRangecalender);
                driver.ClickElement(lnkRangecalender, "Click on Range Calender");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Range Calender", "Failed to click on Range Calender", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddNewRangeCalender(string rangeCalenderText)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageRangeCalender);
                driver.ClickElement(btnAddNewRangeCalender, "Click Add New Range Calender");
                driver.SendKeysToElementAndPressEnter(txtRangeCalenderName, rangeCalenderText, "Enter Range Calender Name");
                driver.ClickElement(chbInvoiceBilling, "Click on Invoice Billing Cycle");
                driver.ClickElement(btnCreateAddRangeCalender, "Click on Create Add Range Calender");
                driver.ScrollToPageBottom();
                By by = By.XPath(string.Format("//div[contains(@id,'cooltipBridgeId')]//table/tbody//td[text()='{0}']/../td//button[contains(text(),'Browse Periods')]", rangeCalenderText));
                driver.ClickElement(by, "Click Browse Periods");

                string endDate = DateTime.Now.AddDays(2).ToString("MM/dd/yyyy");
                driver.SendKeysToElementClearFirst(txtEndDate, endDate, "Enter the end date");

                driver.WaitForElement(btnPlusIcon, TimeSpan.FromSeconds(30));
                driver.ClickElement(btnPlusIcon, "Click Pus Icon");

                driver.ClickElement(btnSavePeriods, "Click on Save Periods");
                driver.VerifyWebElementPresent(msgSuccessPeriods, "Success message");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add New Range Calender", "Failed to Add New Range Calender", EngineSetup.GetScreenShotPath());
            }

        }

        public void NavigateToResumeBoardLogins(string loginValue, string pwdValue, string pwdStatus)
        {
            try
            {
                driver.ClickElement(btnUserSetting, "Click on User Setting Button");
                driver.ClickElement(lnkPersonalSetting, "Click on Personal Setting link");
                driver.sleepTime(2000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameProfileSetting);
                driver.SwitchToFrameByLocator(frameProfileSetting);
                driver.WaitElementPresent(tabResumeBoardLogins);
                driver.ClickElement(tabResumeBoardLogins, "Click Resume Board Logins");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(headerJobBoard, "JobBoard");
                driver.VerifyWebElementPresent(headerLogin, "Login");
                driver.VerifyWebElementPresent(headerPassword, "Password");
                driver.VerifyWebElementPresent(btnSave1, "Save");
                if (driver.ElementPresent(btnChangePassword, "Change Password is available"))
                {
                    driver.ClickElement(btnChangePassword, "Click Change Password");
                    driver.sleepTime(3000);
                    driver.WaitElementPresent(txtNewPassword);
                    driver.SendKeysToElementAndPressEnter(txtNewPassword, "", "Enter New Password");
                    driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, "", "ReEnter New Password");
                    driver.ClickElement(btnPasswordSave, "Save the Password");
                    driver.SendKeysToElementClearFirst(txtLogin, "", "Enter Login");
                    driver.ClickElement(btnSave1, "Click Save");
                }
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(btnAssignPassword, "Assign Password");
                driver.WaitElementPresent(txtLogin);
                driver.SendKeysToElementClearFirst(txtLogin, "", "Enter Login");
                driver.WaitElementPresent(btnSave1);
                driver.ClickElement(btnSave1, "Click Save");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAssignPassword);
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.VerifyWebElementPresent(msgToast, "Please assign a new non empty Login and save changes before assigning a new password. message box is displayed.");
                driver.ClickElement(msgClose, "Close the Toast");
                driver.WaitElementPresent(txtLogin);
                driver.SendKeysToElement(txtLogin, loginValue, "Enter Login Value");
                driver.WaitElementPresent(btnSave1);
                driver.ClickElement(btnSave1, "Click Save");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAssignPassword);
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.SendKeysToElementAndPressEnter(txtNewPassword, "", "Enter New Password");
                driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, "", "ReEnter New Password");
                driver.WaitElementPresent(btnPasswordSave);
                driver.ClickElement(btnPasswordSave, "Save the Password");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(msgPwdSucess, "Password successfully changed. Message box is displayed");
                driver.ClickElement(msgClose, "Close the Toast");
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.SendKeysToElementAndPressEnter(txtNewPassword, pwdValue, "Enter New Password");
                driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, pwdValue, "ReEnter New Password");
                driver.ClickElement(btnPasswordSave, "Save the Password");
                driver.sleepTime(5000);
                string pwdDisable = driver.FindElement(txtPwd).GetAttribute("disabled").ToUpper();
                if (pwdDisable.Equals(pwdStatus))
                    TESTREPORT.LogSuccess("Verify Password Masked", "Password field is Masked");
                else
                    TESTREPORT.LogFailure("Verify Password Masked", "Password field is not Masked");
                driver.VerifyWebElementPresent(btnChangePassword, "Change Password");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Navigate To Resume Board Logins", "Failed to Navigate To Resume Board Logins", EngineSetup.GetScreenShotPath());
            }
        }

        public void OpenResumeBoardAndVerifyDepartment(string resumeBoardsLogin)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtSearchControlPanelModule, resumeBoardsLogin, "Resume Board Logins");
                driver.WaitElementPresent(lnkResumeBoardLoginNew);
                driver.ClickElement(lnkResumeBoardLoginNew, "Resume Board Logins");
                driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameJobIndex);
                driver.SwitchToFrameByLocator(frameJobIndex);
                driver.sleepTime(5000);
                driver.ClickElement(SandboxEdit, "Edit Sandbox");
                driver.VerifyWebElementEnabled(btnCancelNew, "Cancel button");
                driver.VerifyWebElementDisabled(bntDisabledSave, "Save button");
                driver.VerifyWebElementPresent(txtLoginTextBox,"Login Textbox");
                driver.VerifyWebElementPresent(txtPasswordTextBox,"Password Textbox");
                string txtPassword = driver.GetElementValue(txtPasswordTextBox);
                if (txtPassword != "")
                {
                    driver.VerifyWebElementPresent(btnChangePasswordButton, "Change Password Button");
                }
                string txtEmptyPassword = driver.GetElementValue(txtPasswordEmpty);
                if (txtEmptyPassword == "")
                {
                    driver.VerifyWebElementPresent(btnAssignPwd, "Assign Password Button");
                }
                driver.VerifyWebElementPresent(txtOptions, "Options Text Box");
                driver.VerifyWebElementPresent(btnOverWrite, "Overwrite button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Department table", "Failed to verify department table", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyUserAbleToAddEmptyPassword(string pwdValue)
        {
            try

            {
                driver.ClickElement(btnChangePassword, "Change Password button");
                driver.ClickElement(btnPasswordSave, "Save Password");
                string changePwdMsg = driver.GetElementText(msgtoastSuccess);
                if (changePwdMsg == "Password successfully changed!")
                {
                    TESTREPORT.LogSuccess("Verify Password Has Changed", "Password is updated sucessfully");
                    driver.ClickElement(msgToastDissmiss,"Diss miss toast message");
                }
                string newPasswordTextbox = driver.GetElementValue(newPasswordTextBox);
                if (newPasswordTextbox == "")
                {
                    TESTREPORT.LogSuccess("Password Saved Empty", "Password is updated sucessfully as empty");
                }
                driver.ElementPresent(newChangeButton,"New Password button");
                //Click and Assign the password
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.SendKeysToElementAndPressEnter(txtNewPassword, pwdValue, "Enter New Password");
                driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, pwdValue, "ReEnter New Password");
                driver.ClickElement(btnPasswordSave, "Save the Password");
                driver.ClickElement(btnCancelNew, "Cancel button");


            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Empty password", "Faild to verify Empty password save ", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyOverWriteButton()
        {
            try
            {
                string txtEmptyLogin = driver.GetElementValue(emptyLoginTxtbox);
                if (txtEmptyLogin != "")
                {
                    driver.FindElement(emptyLoginTxtbox).Clear();
                    driver.ClickElement(bntDisabledSave,"Save button");
                    driver.ClickElement(SandboxEdit, "Edit Sandbox");
                }
               
                 txtEmptyLogin = driver.GetElementValue(emptyLoginTxtbox);
                if (txtEmptyLogin == "")
                {
                    driver.VerifyWebElementDisabled(btnOverWriteCheck, "OverWrite button");
                    driver.ClickElement(btnCancelNew, "Cancel button");
                }
  
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Overwrite button", "Faild to verify overwrite button is disabled ", EngineSetup.GetScreenShotPath());
            }
        }

        public void VeridyOverwritebuttonDisabledInsubDept(string resumeBoardsLogin)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtSearchControlPanelModule, resumeBoardsLogin, "Resume Board Logins");
                driver.ClickElement(lnkResumeBoardLoginNew, "Resume Board Logins");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameJobIndex);
                driver.ClickElement(subDeptSandBox, "Sub department");
                driver.VerifyWebElementEnabled(btnCancelNew, "Cancel button");
                driver.VerifyWebElementDisabled(bntDisabledSave, "Save button");
                driver.IsElementPresent(txtLoginTextBox);
                driver.IsElementPresent(txtPasswordTextBox);
                string txtPassword = driver.GetElementValue(txtPasswordTextBox);
                if (txtPassword != "")
                {
                    driver.ElementPresent(btnChangePasswordButton, "Change Password Button");
                }
                string txtEmptyPassword = driver.GetElementValue(txtPasswordEmpty);
                if (txtEmptyPassword == "")
                {
                    driver.ElementPresent(btnAssignPwd, "Assign Password Button");
                }
                driver.ElementPresent(txtOptions, "Options Text Box");
                driver.ElementPresent(btnOverWrite, "Overwrite button");
                driver.ElementPresent(btnInherit, "Inherit button");
                string txtEmptyLogin = driver.GetElementValue(emptyLoginTxtbox);
                if (txtEmptyLogin != "")
                {
                    driver.FindElement(emptyLoginTxtbox).Clear();
                    driver.ClickElement(bntDisabledSave, "Save button");
                    driver.ClickElement(subDeptSandBox, "Edit Sandbox");
                }

                txtEmptyLogin = driver.GetElementValue(emptyLoginTxtbox);
                if (txtEmptyLogin == "")
                {
                    driver.VerifyWebElementDisabled(btnOverWriteCheck, "OverWrite button");
                    driver.ClickElement(btnCancelNew, "Cancel button");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Overwrite button", "Faild to verify overwrite button is disabled in sub department ", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyEmptyPwdCanAbleToSave(string pwdValue)
        {
            try
            {
                driver.ElementPresent(btnInherit, "Inherit button");
                driver.WaitElementPresent(btnChangePassword);
                driver.ClickElement(btnChangePassword, "Change Password button");
                driver.WaitElementPresent(btnPasswordSave);
                driver.ClickElement(btnPasswordSave, "Save Password");
                string changePwdMsg = driver.GetElementText(msgtoastSuccess);
                if (changePwdMsg == "Password successfully changed!")
                {
                    TESTREPORT.LogSuccess("Verify Password Has Changed", "Password is updated sucessfully");
                    driver.ClickElement(msgToastDissmiss, "Diss miss toast message");
                }
                string newPasswordTextbox = driver.GetElementValue(newPasswordTextBox);
                if (newPasswordTextbox == "")
                {
                    TESTREPORT.LogSuccess("Password Saved Empty", "Password is updated sucessfully as empty");
                }
                driver.ElementPresent(newChangeButton, "New Password button");
                driver.WaitElementPresent(btnAssignPassword);
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.SendKeysToElementAndPressEnter(txtNewPassword, pwdValue, "Enter New Password");
                driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, pwdValue, "ReEnter New Password");
                driver.WaitElementPresent(btnPasswordSave);
                driver.ClickElement(btnPasswordSave, "Save the Password");
                driver.WaitElementPresent(btnCancelNew);
                driver.ClickElement(btnCancelNew, "Cancel button");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Save Empty Password for sub department", "Faild to save empty password for sub department", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyRecruiterAbleToSaveEmptyPwd(string resumeBoardsLogin)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtSearchControlPanelModule, resumeBoardsLogin, "Resume Board Logins");
                driver.ClickElement(lnkResumeBoardLoginNew, "Resume Board Logins");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameJobIndex);
                driver.ClickElement(lnkRecruiter, "Recruiter");
                driver.sleepTime(10000);
                driver.VerifyWebElementEnabled(btnCancelNew, "Cancel button");
                driver.VerifyWebElementDisabled(bntDisabledSave, "Save button");
                driver.ElementPresent(txtLoginTextBox,"Login Text box");
                driver.ElementPresent(txtPasswordTextBox,"Password Textbox");
                string txtPassword = driver.GetElementValue(txtPasswordTextBox);
                if (txtPassword != "")
                {
                    driver.ElementPresent(btnChangePasswordButton, "Change Password Button");
                }
                string txtEmptyPassword = driver.GetElementValue(txtPasswordEmpty);
                if (txtEmptyPassword == "")
                {
                    driver.ElementPresent(btnAssignPwd, "Assign Password Button");
                }
                driver.ElementPresent(txtOptions, "Options Text Box");
                driver.ElementPresent(btnInherit, "Inherit button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Save Empty Password for Recruiter", "Faild to save empty password for recruiter", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyCredentialsCopied(string loginValueToOverwrite,string ValueToBeOverriden,string copyBtnMessage,string newLoginCredentials)
        {
            try
            {
               
                string txtLoginCredentials = driver.GetElementValue(txtLoginTextBox);
                driver.AssertTextMatching(txtLoginCredentials, loginValueToOverwrite);
                driver.WaitElementPresent(btnCancelNew);
                driver.ClickElement(btnCancelNew, "Cancel button");
                driver.WaitElementPresent(subDeptSandBox);
                driver.ClickElement(subDeptSandBox, "Sub department sanbox");
                driver.WaitElementPresent(txtLoginTextBox);
                string txtLoginCredentialsSubDept = driver.GetElementValue(txtLoginTextBox);
                //driver.AssertTextMatching(txtLoginCredentialsSubDept, ValueToBeOverriden);
                driver.WaitElementPresent(btnCancelNew);
                driver.WaitElementPresent(btnCancelNew);
                driver.ClickElement(btnCancelNew, "Cancel button");
                driver.WaitElementPresent(SandboxEdit);
                driver.ClickElement(SandboxEdit, "Sandbox edit");
                driver.WaitElementPresent(btnOverwrite);
                driver.ClickElement(btnOverwrite, "OverWrite button");
                driver.sleepTime(3000);
                driver.WaitElementPresent(copyBtnMsg);
                string copyBtnMessag = driver.GetElementText(copyBtnMsg);
                driver.AssertTextMatching(copyBtnMessage, copyBtnMessage);
                driver.WaitElementPresent(btnCopy);
                driver.ClickElement(btnCopy, "Copy button");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnCancelNew);
                driver.ClickElement(btnCancelNew, "Cancel");
                driver.WaitElementPresent(subDeptSandBox);
                driver.ClickElement(subDeptSandBox, "Sub dept sandbox");
                driver.sleepTime(2000);
                driver.WaitElementPresent(txtLoginTextBox);
                txtLoginCredentialsSubDept = driver.GetElementValue(txtLoginTextBox);
                driver.AssertTextMatching(txtLoginCredentials, loginValueToOverwrite);
                driver.WaitElementPresent(btnCancelSandbox);
                driver.ClickElement(btnCancelSandbox, "Cancel");
                driver.sleepTime(3000);
                //change credntial for execute every time
                driver.WaitElementPresent(subDeptSandBox);
                driver.ClickElement(subDeptSandBox, "Sub Department");
                driver.sleepTime(3000);
                driver.FindElement(txtLoginTextBox).Clear();
                driver.SendKeysToElement(txtLoginTextBox, newLoginCredentials, "LoginTextBox");
                driver.WaitElementPresent(btnSaveSubDepartment);
                driver.ClickElement(btnSaveSubDepartment, "Saved");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Copy credentials to sub departments", "Faild to copy credentials to sub departments", EngineSetup.GetScreenShotPath());
            }


        }

        public void AssignPassword(string pwdValue)
        {
            try
            {
                driver.ClickElement(btnAssignPassword, "Click Assign Password");
                driver.SendKeysToElementAndPressEnter(txtNewPassword, pwdValue, "Enter New Password");
                driver.SendKeysToElementAndPressEnter(txtRetypeNewPassword, pwdValue, "ReEnter New Password");
                driver.ClickElement(btnPasswordSave, "Save the Password");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Assign Password", "Failed to Assign Password", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnCustomFields(string customField)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, customField, "Search");
                driver.WaitElementPresent(lnkCustomField);
                driver.ClickElement(lnkCustomField, "Click Custom Field");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Custom Field", "Failed to click on Custom Field", EngineSetup.GetScreenShotPath());
            }
        }

        public void AddContactCustomField(string newCustomField, string defaultValue)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageFields);
                driver.SwitchToFrameByLocator(frameManageFields);
                driver.sleepTime(30000);
                driver.ClickElement(txtNewCustomField,"Click New Custom field textbox");
                driver.SendKeysToElement(txtNewCustomField, newCustomField, "Enter New Custom Field Name");
                driver.WaitElementPresent(ddlType);
                driver.ClickElement(ddlType, "Choose Type");
                driver.sleepTime(2000);
                IList<IWebElement> TypeElement = driver.FindElements(By.XPath("//div[contains(@id,'cphMain_cphMain_ddlAboutType_DropDown')]//ul"));
                var TypeOptions = TypeElement.First().FindElements(By.TagName("li"));
                TypeOptions[0].Click();
                driver.WaitElementPresent(ddlDataType);
                driver.ClickElement(ddlDataType, "Data Type");
                driver.sleepTime(2000);
                IList<IWebElement> DataTypeElement = driver.FindElements(By.XPath("//div[contains(@id,'cphMain_cphMain_ddlDataType_DropDown')]/div/ul"));
                var DataTypeOptions = DataTypeElement.First().FindElements(By.TagName("li"));
                DataTypeOptions[0].Click();
                driver.WaitElementPresent(ddlSearchType);
                driver.ClickElement(ddlSearchType, "Search Type");
                driver.sleepTime(2000);
                IList<IWebElement> SearchTypeElement = driver.FindElements(By.XPath("//div[contains(@id,'cphMain_cphMain_ddlSearchType_DropDown')]/div/ul"));
                var SearchTypeOptions = SearchTypeElement.First().FindElements(By.TagName("li"));
                SearchTypeOptions[1].Click();
                driver.sleepTime(2000);
                //driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                //driver.ClickElement(ddlVisibleTo, "Search Type");
                //driver.sleepTime(1000);
                //IList<IWebElement> VisibleToElement = driver.FindElements(By.XPath("//div[contains(@id,'cphMain_cphMain_chksVisibleTo_ddlList_i0_lstList')]/div/ul"));
                //var VisibleToOptions = VisibleToElement.First().FindElements(By.XPath("//li[contains(@id,'cphMain_cphMain_chksVisibleTo_ddlList')]/input"));
                //SearchTypeOptions[1].Click();
                driver.WaitElementPresent(txtDefaultValue);
                driver.SendKeysToElement(txtDefaultValue, defaultValue, "Default Value");
                driver.WaitElementPresent(btnAddCustomField);
                driver.ClickElement(btnAddCustomField, "Click Add Custom Field");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Custom Field", "Failed to Add Custom Field", EngineSetup.GetScreenShotPath());
            }
        }

        public void CopyCredentialsToJobBoard()
        {
            try
            {
                //driver.FindElement(txtSearch);
                //driver.ClickElement(txtSearch, "Resume board");
                //driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                //driver.SendKeysToElement(txtSearch, "Resume Board Logins", "Resume Board ");
                //driver.ClickElement(lnkResumeBoardLoginNew, "Resume Board Logins");
                driver.WaitElementPresent(frameResumeBoard);
                driver.SwitchToFrameByLocator(frameResumeBoard);
                driver.ClickElement(lnkQaAutomation, "QA Automation");
                driver.VerifyWebElementEnabled(btnCancelNew, "Cancel button");
                driver.VerifyWebElementDisabled(bntDisabledSave, "Save button");
                driver.VerifyWebElementPresent(txtLoginTextBox,"Login Text box");
                driver.VerifyWebElementPresent(txtPasswordTextBox,"Password Text box");                
                string txtPassword = driver.GetElementValue(txtPasswordTextBox);
                if (txtPassword != "")
                {
                    driver.VerifyWebElementPresent(btnChangePasswordButton, "Change Password Button");
                }
                string txtEmptyPassword = driver.GetElementValue(txtPasswordEmpty);
                if (txtEmptyPassword == "")
                {
                    driver.VerifyWebElementPresent(btnAssignPwd, "Assign Password Button");
                }
                driver.VerifyWebElementPresent(txtOptions, "Options Text Box");
                driver.VerifyWebElementPresent(btnInherit, "Inherit");
                driver.ClickElement(btnInherit, "Inherit");
                string txtQaLogin = driver.GetElementValue(txtLoginTextBox);
                string txtQaPassword= driver.GetElementValue(txtPasswordTextBox);
                driver.FindElement(SandboxEdit);
                driver.ClickElement(SandboxEdit, "SandBox Edit");
                string txtSandboxLogin = driver.GetElementValue(txtLoginTextBox);
                string txtSandboxPassword = driver.GetElementValue(txtPasswordTextBox);
                driver.AssertTextMatching(txtQaLogin, txtSandboxLogin);
                driver.AssertTextMatching(txtQaPassword, txtSandboxPassword);

            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verified Credentials copied to the specific Job Board from Department", "Failed to copy credentials from Department", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnBussinessEntity(string entity)
        {
            try
            {
                driver.SendKeysToElement(txtSearch, entity, "Search");
                driver.WaitElementPresent(lnkEntities);
                driver.ClickElement(lnkEntities, "Click on Bussiness Entities");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Bussiness Entities", "Failed to click on Bussiness Entities:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyManageEnitites(string txtLocalResourceDefault,string txtLocalResourceUpdated)
        {
            try
            {
            driver.WaitForPageLoad(TimeSpan.FromSeconds(10));
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(frameManageEntities);         
            driver.FindElement(btnEditEntity);
            driver.ClickElement(btnEditEntity,"Edit Entity");
            driver.FindElement(ddlLocalResource);
            driver.ClickElement(ddlLocalResource,"Local Resource");
            driver.FindElement(lnkUpdatedOption);
            driver.ClickElement(lnkUpdatedOption,"Local Resource");
            driver.ClickElement(btnUpadteEntity, "Update");
            driver.CheckElementExists(lnkUpdateMessage,"Update Message");
            driver.ClickElement(btnEditEntity, "Edit Entity");
            driver.ClickElement(ddlLocalResource, "Local Resource");
            driver.FindElement(lnkDefaultOption);
            driver.ClickElement(lnkDefaultOption, "Local Resource");
            driver.ClickElement(btnUpadteEntity, "Update");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Update Bussiness Entities", "Failed to update Bussiness Entities:", EngineSetup.GetScreenShotPath());
            }
        }
    }
}
