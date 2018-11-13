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
    public class HomePage : AbstractTemplatePage
    {
        AddCandidatePage candidate = new AddCandidatePage();
        public static string id = "";
        Utility utility = new Utility();

        #region Constructors
        public HomePage()
        {
        }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository

        #region Login
        private By txtEmail = By.Name("ctl00$cphMain$logIn$UserName");
        //By.Id("ctl00_cphMain_logIn_UserName");
        private By txtPassword = By.Name("ctl00$cphMain$logIn$Password");
            //By.Id("ctl00_cphMain_logIn_Password");
        private By btnLogin = By.Id("ctl00_cphMain_logIn_Login");
        private By lblLoginMessage = By.XPath(".//*[@id='ctl00_cphMain_lblLogin']");
        private By errorMessage = By.XPath("//div[@id='message_1' and text()='Your login attempt was not successful. Please try again.']");
        private By btnClose = By.XPath("//div[@onclick='CloseMessage($(this));']");
        #endregion

        #region Logout
        private By mnuLogout = By.XPath("//div[@class='user_menu']/span");
        private By lnkLogout = By.CssSelector("a[onclick='OnLogout();']");

        #endregion

        #region Homepage
        private By logoMenu = By.XPath("//div[@class='logo_inner']");
        private By Search = By.XPath("//li[@class='search']");
        private By Candidates = By.XPath("//span[text()='Candidates']");
        private By txtCandidateName = By.XPath("//span[text()='Candidates']/div/div/div/following-sibling::input");
        private By lnkSearchCompanies = By.XPath("//span[text()='Companies']");
        private By txtCompaniesName = By.XPath("//span[text()='Companies']/div/div/div/following-sibling::input");
        private By lnkAddnew = By.XPath("//span[text()='Add New']");
        private By lnkManage = By.XPath("//span[text()='Manage']");
        private By lnkCandidate = By.XPath("//span[text()='Candidate']");
        private By lnkWithoutresume = By.XPath("//span[text()='Without Resume']");
        private By lnkCompany = By.XPath("//span[text()='Company']");
        private By lnkAccounting = By.XPath("//span[text()=' Accounting']");
            //By.XPath("//span[text()='Accounting']");
        private By lnkPosition = By.XPath("//span[text()='Position']");
        private By lnkSimple = By.XPath("//span[text()='Simple']");
        private By ttlAddNewPosition = By.XPath("//h1[contains(@title,'Add New Position')]");
        private By Position = By.XPath("//span[contains(.,'Positions')]");
        private By txtPositionNameorID = By.XPath("//li[@class='position']/span/div/div/input");
        // ----Add requirement --//
        private By lnkTools = By.XPath("//span[text()='Tools']");
        private By lnkControlPanel = By.XPath("//span[text()='Control Panel']");
        private By lnkControlPanelModule = By.XPath("//div[@id='ctl00_ctl00_cphMain_menuAdmin']/ul/li[2]/a//span[contains(text(),'Control Panel Modules')]");
        //By.XPath("//li[@class='rmItem rmLast']");
        private By txtSearch = By.Id("txtAdminMenuFilter");
        private By lnkFolderGroups = By.XPath("//*[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']/ul[1]/li[1]/ul/li[8]/a[text()='Folder Groups']");
        //By.XPath("//a[text()='Folder Groups']");
        private By lnkFolderGroupStatus = By.XPath("//*[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']/ul[4]/li[3]/ul/li[9]/a[text()='Folder Group Statuses']");
        private By frameManageFolderGroups = By.XPath("//iframe[contains(@id,'admin_site-ManageFolderGroups')");
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
        private By txtRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/span[1]/input[1]");
        private By lnkRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[3]/li[4]/ul/li/a[text()='Requirement Definitions']");
        private By lnkEmailNotes = By.XPath("//a[text()='Email & Note Templates']");
        private By btnEditEmail = By.XPath("//input[@name='ctl00$ctl00$cphMain$cphMain$editEmailTemplates$gridEmailTemplates$ctl00$ctl04$EditButton']");
        private By btnImageManager = By.XPath("//div[@title='Image']");
            //By.XPath("//div[@title='Insert Image']");
        private By frameSiteEmail = By.XPath("//iframe[contains(@id,'admin_site-EmailTemplates')]");
        private By btnAddRequirement = By.XPath("//button[@title='Add a new Requirement']");
        private By txtEnterName = By.XPath("//input[@placeholder='Enter a Name']");
        private By ddntype = By.XPath("//div[@id='s2id_RequirementType_SelectedItem']/a/span");
        // private By txttype = By.XPath("//input[@data-helptip='RequirementType']");
        private By txttype = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By ddntarget = By.XPath("//div[@id='s2id_TargetAboutTypeID_SelectedItem']/a/span");
        //private By txttarget = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By txttarget = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active'][2]/div/input");
        private By txtWeight = By.Id("Weight");
        private By chkFullPlacement = By.XPath("//input[@id='RequiredBeforePlacement']");
        private By btnSave = By.XPath("//button[text()='Save']");
        private By lnkMatches = By.XPath("//span[@title='Keyboard Shortcut: Shift+S, T']"); //By.XPath("//li[@class='search maintain_hover']//li[@class='match']/span[contains(text(),'Matches')]");
        private By lnkMatchinput = By.XPath("//div//ul/li[@class='match']//input");
        private By iframeCompany = By.XPath("//iframe[contains(@id,'company')]");
        private By lnkAgreement = By.XPath("//span[text()='Agreement']");
        //--Edit Requirement--//
        private By txtFiltername = By.Id("txtfilter");
        private By btnEdit = By.XPath("//button[@class='btn editRequirement input-sm clicktip']");
        //--Verify Requirement--//
        private By textFiltername = By.XPath("//input[@id='txtfilter']");
        private By btnAdd = By.XPath("//div[@class='expandButton']");
        private By btnDeleteRequirement = By.XPath("//button[@id='DeleteRequirement']");

        //--Verify Custom Field is added to requirementPage
        private By lnkCustomfield = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[1]/li[1]/ul/li/a[text()='Custom Fields']");

        private By iframeManageFields = By.XPath("//iframe[contains(@id,'admin_site-ManageCustomFields')]");
        private By txtNewCustomField = By.XPath("//h5[contains(text(),'New Custom Field')]//following-sibling::input[@id='ctl00_ctl00_cphMain_cphMain_txtFieldName']");
        private By ddlCustomFieldType = By.Id("ctl00_ctl00_cphMain_cphMain_ddlAboutType_Input");
        private By ddlRequirements = By.XPath("//input[contains(@id,'cphMain_cphMain_chkRequirements_ddlList_Input')]");
        private By chkAllRequirement = By.XPath("//img[contains(@id,'cphMain_cphMain_chkRequirements_imgToggleSelect')]");
       // private By chkRequirement = By.XPath("//span[text()='Background Check - Target Requirement']/preceding-sibling::input");
        private By ddlCustomFieldDatatype = By.Id("ctl00_ctl00_cphMain_cphMain_ddlDataType_Input");
        private By btnAddField = By.Id("ctl00_ctl00_cphMain_cphMain_btnAdd");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");

        private By txtAddValue = By.XPath("//input[contains(@id,'txtEnumVal')]");
        private By btnAddValue = By.XPath("//input[contains(@id,'btnAddValue')]");
        private By btnSaveValue = By.XPath("//input[contains(@id,'UpdateButton')]");
        private By btnAddRequirementToVerify = By.Id("btnAddNewRequirement");
        private By lnkShowMore = By.XPath("//span[contains(text(),'Show More')]");
        private By lnkShowLess = By.XPath("//span[text()='Show Less']");
        private By lableVerify = By.XPath("//label[@data-bind='text: Definition.Name, css: { required: Definition.Required }']");
        private By ddlRequirement = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_chkRequirements_ddlList_Input']");
        private By chkRequirement = By.XPath("//span[contains(text(),'Background Check - Target Requirement')]/..//input");
        private By chkDropRequirement = By.XPath("//li[text()='Object Requirement']");
        //--Verify Added custom fields

        private By txtCustomField = By.XPath("//div[@id='s2id_autogen47']");

        //--Click on the Requirements button
        private By btnRequirements = By.XPath("//label[contains(text(),'Requirement:')]");
        private By txtRequirements = By.XPath(".//*[contains(text(),'Clear Items')]//following-sibling::div/div[contains(@id,'s2id_autogen')]/ul/li/input");
        private By chkSelectRequirement1 = By.XPath("//table/tbody/tr[1]/td[1]/input[@class='check-one']");
        //By.XPath("//input[@data-rowid='6349']");
        private By chkSelectRequirement2 = By.XPath("//table/tbody/tr[2]/td[1]/input[@class='check-one']");
        private By framreObjectRequirement = By.XPath("//iframe[contains(@id,'objectrequirement')]");
        private By lnkExportToExcel = By.XPath("//span[contains(text(),'Export Selected to Excel')]");


        //--Verify samrtForms

        private By lnkRecruiter = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[2]/li[1]/ul/li/a[text()='Recruiters']");
        private By btnExpandSandbox = By.XPath("//span[contains(text(),'Sandbox') and contains(@title,'Click to add a recruiter')]/preceding-sibling::span[@class='rtPlus']");
        private By frameAdminManageRecruiter = By.XPath("//iframe[contains(@id,'admin_recruiters-ManageRecruiters_')]");
        private By txtSearchAdminRecruiter = By.XPath("//input[@onkeyup='UserTree_Filter(this.value)']");
        private By lnkAdminRecruiter = By.XPath("//span[contains(text(),'QA Automation')]");
        private By frameReqruiterManage = By.XPath("//iframe[contains(@id,'recruiter_manage')]");
        private By tabPermission = By.XPath("//span[contains(text(),'Permissions')]");
        private By framePermissions = By.XPath("//iframe[contains(@id,'pvPermissions_frame')]");
        private By ddlAddPermission = By.XPath("//input[@id='ctl06_ddlAddPermission_Input' and @value='Select a Permission']");
                                         //("//a[@id='ctl06_ddlAddPermission_Arrow' and text()='select']");
                                                                                                                               


        //--View/Edit smartforms
        private By btnDeleteSmaertForm = By.XPath("//td[text()='Manage Smart Forms']//following-sibling::td//following-sibling::td/input");
        //By.Id("ctl06_rgPermissions_ctl00_ctl1176_gbcDeleteColumn");
        private By lnkSmartForm = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[1]/li[1]/ul/li/a[text()='Smart Forms']");
        private By lnkControlPanleModule2 = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink']/img/following-sibling::span");
        private By frameAdminSite = By.XPath("//iframe[contains(@id,'admin_site-v4ControlPanelPage')]");
        private By btnEditSmartForm = By.XPath("//td[contains(text(),'ER')]//following-sibling::td/button");
        private By frameClientPageIndex = By.XPath("//iframe[contains(@id,'clientpage_index')]");
        private By frameAdminDefault = By.XPath("//iframe[contains(@id,'admin_Default')]");
        private By lnkControlPanelModules = By.XPath("//span[contains(text(),'Control Panel Modules')]");
        //private By txtActualText = By.XPath("//div[contains(text(),'Design a Form')]");
        private By txtactualTxt = By.XPath("//div[@class='widgettitle' and contains(text(),'Design a Form')]");

        //Left Pane//
        private By lnkManagesmartForm = By.XPath("//div[contains(@id,'tab_admin_site-v4ControlPanelPage')]");
        private By txtErrorMessage = By.XPath("//div[@class='messaging error']");
        private By frameClientIndex = By.XPath("//iframe[contains(@id,'clientpage_index')]");
        private By lnkManageRecruiter = By.XPath("//div[contains(@id,'tab_recruiter_manage')]");

        //--Candidate search

        // private By framecandidate = By.XPath("//iframe[@src='..//Search/candidate/']");
        private By framecandidate = By.XPath("//iframe[contains(@id,'candidate')]");
        private By btnSearchcandidate = By.XPath("//input[@value='Search']");
        private By lnkSavedSearch = By.XPath("//span[@class='button-title' and text()='Saved Searches']");
        private By btnSaveCurrentSearch = By.XPath("//span[text()='Save Current Search']/..");
        // private By btnSaveCurrentSearch1 = By.XPath("//div[@class='footerControls']//span[contains(text(),'Save Current Search')]");
        private By txtSearchName = By.XPath("//label[text()='Search Name']//following-sibling::input");
        // private By txtSearchName = By.XPath("//input[@data-bind='value: name']");
        private By btnSaveSearch = By.XPath("//span[text()='Save']");
        private By btnSaveSearchHome = By.XPath("//input[@title='Click to see available saved searches']");
        private By lnkCommands = By.XPath("//div[text()='Commands']");
        private By fndSavedSearch = By.XPath("//a[text()='TestNewSearch123'][1]");
        private By frameSavedsearchCand = By.XPath("//iframe[contains(@id,'candidate_')]");
        private By frameSaved = By.XPath("//iframe[contains(@id,'saved_329-SavedSearch')]");
        private By newframeCandidateSearch = By.XPath("//iframe[@src='..//Search/candidate/']");

        //-Position type edit

        private By lnkPositionType = By.XPath("//a[text()='Position Types']");
        private By btnPositiontypeEdit = By.XPath("//td[text()='Perm Salary']/..//td[@class='Buttons']/div[@class='icon-pencil']");
        private By chkCorp1Deselect = By.XPath("//label/span[text()='Corp 1'] ");
        private By btnPositionSave = By.XPath("//button[text()='Save']");
        private By txtAreaErrorMsg = By.XPath("//div[@class='cooltipmessage error']");
        private By frameAdminSiteMnagePosition = By.XPath("//iframe[contains(@id,'admin_site-ManagePositionTypes')]");
        //-Merge companies

        private By btnMergeSearch = By.XPath("//input[@value='Search']");
        private By lnkCompanyName = By.XPath("//a[contains(text(),'208821')]");
        private By frameCompany = By.XPath("//iframe[contains(@id,'company')]");
        private By frameManage = By.XPath("//iframe[contains(@id,'company_manage')]");
        private By lnkMergeCompany = By.XPath("//img[@src='../../Mvc/Content/Images/icons/arrowjoin.png']");
        private By frameGeneralMergeRecods = By.XPath("//iframe[contains(@id,'general_mergerecords_company')]");
        private By ddlCompanyName = By.XPath("//input[contains(@id,'ctl00_cphMain_ddlList2_Input')]");
        private By btnMerge = By.Id("ctl00_cphMain_btnMerge_input");
        private By ddlCompany = By.XPath("//label[contains(text(),'Company:')]");
        private By txtCompanySearch = By.XPath("//label[text()='Company:']//following-sibling::div[contains(@id,'s2id_autogen')]/ul/li/input");
        private By ddlParentCompany = By.XPath("//label[contains(text(),'Parent Company:')]");
        private By txtChooseCompany = By.XPath("//span[contains(text(),'Choose Company...')]");
        private By txtSearchcompany = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By frameContact = By.XPath("//iframe[contains(@id,'contact')]");
        private By txtResult = By.XPath("//li[@class='select2-no-results']");
        private By txtParentResult = By.XPath("//li[@class='select2-no-results']");
        private By CompanyTitle = By.XPath("//h1[@title='Company']");
        //Education History
        private By btnEduHistory = By.XPath("//td[text()='Ithaca College']/preceding-sibling::td[@data-bind='control: $data']//following-sibling::span[@class='icon icon-pencil']");
        private By chkCustomFieldEduHistory = By.XPath("//h5[text()='Test Custom Field - Education History']//following-sibling::span/input");
        private By btnsaveEduHistory = By.XPath("//button[text()='Save']");
        //Work History

        private By btnEditWorkHistory = By.XPath("//td[text()='Manual']/..//span[@class='icon icon-pencil']");
        private By chkCustomFiledWorkHistory = By.XPath("//h5[text()='Test Custom Field - Work History']//following-sibling::span/input");
        private By btnSaveWorkHistory = By.XPath("//button[text()='Save']");

        //Candidate Application

        private By ddlChooseCandidate = By.XPath("//span[text()='Choose candidate']");
        private By txtSearchChooseCandidate = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By ddlChoosePosition = By.XPath("//span[text()='Choose position']");
        private By txtSearchChoosePosition = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By btnSaveCandidate = By.XPath("//button[text()='Save']");

        //Right click on Work History
        private By btnMaximizeWorkHistory = By.XPath("//div[contains(text(),'Related')]//following-sibling::span");
        //Verify Requirement integration setting
        private By frameSitemanagementRequirement = By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]");
        private By btnRequiremetName = By.XPath("//input[@id='Name']");
        private By ddlType = By.XPath("//div[@id='s2id_RequirementType_SelectedItem']");
        private By TypeSearch = By.XPath("//input[@data-helptip='RequirementType']");

        private By ddlTargetRecordType = By.XPath("//div[@id='s2id_TargetAboutTypeID_SelectedItem']");
        private By TargetRecordSearch = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By IntegrationPartnerText = By.XPath("//div[text()='HRNX']");
        private By ddlIntegrationPartner = By.XPath("//div[@id='s2id_autogen2']");
        private By txtSearchDropDown = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By ddlProvider = By.XPath("//div[@id='s2id_autogen11']");
        private By chkServices = By.XPath("//input[@name='IntegrationProviderType' and @value='2']");
        private By chkPakeges = By.XPath("//input[@name='IntegrationProviderType' and @value='1']");
        private By ddlPakages = By.XPath("//div[@id='s2id_autogen23']");
        private By ddlPackagesAndService = By.XPath("//div[@class='select2-container select2-container-disabled']/a");
        private By ddlServices = By.XPath("//div[@id='s2id_autogen36']");
        private By btnSaveRequirement = By.XPath("//button[@id='SaveRequirement']");
        private By tbfilterName = By.XPath("//input[@id='txtfilter']");
        private By requirementData = By.XPath("//div[@class='col-sm-6']/h3");


        //--Match--//
        private By lnkMatch = By.XPath("//span[text()='Match']");
        private By btnQuick = By.XPath("//span[text()='Match']/div/div/div//span[text()='Quick']");
        private By ddnSelectPosition = By.XPath("//div[@id='s2id_Position']/a/span");
        private By txtEnterPosition = By.XPath("//div[text()='Select a candidate to view details']//following-sibling::div/div/input");
        private By btnNext = By.XPath("//input[@data-panel='timelineCandidates']");
        private By txtCandidates = By.XPath("//div[@id='s2id_Candidates']/ul/li/input");
        private By btnCandidatesNext = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By btnSubmitalNext = By.XPath("//input[@value='Approve without Sending Emails']"); //By.XPath("//input[@value='Approve without Sending Email']");
        private By btnApproverWithoutEmail = By.XPath("//button[@value='Approve without Sending Email']");
        private By lblRequirements = By.XPath("//span[text()='Scheduled Items']/../following-sibling::li/span[text()='Requirements']");
        private By lnkOpportunities = By.XPath("//span[text()='Legal Cases']/../..//li//span[text()='Opportunities']");
        private By txtinputOpportunities = By.XPath("//span[text()='Legal Cases']/../..//li//span[text()='Opportunities']/div/div/div/following-sibling::input");
        //--Matches--//

        private By txtSearchOfferSal = By.XPath("//div[@class='select2-drop add-filters select2-with-searchbox select2-drop-active']/div/input");
        private By txtAddFilter = By.XPath("//span[text()='Add Filters...']");
        private By txtOfferSalary = By.XPath("//label[text()='Offer Salary:']");
        private By txtFromSalary = By.XPath("//label[text()='From']//following-sibling::input[1]");
        private By txtToSalary = By.XPath("//label[text()='From']//following-sibling::input[2]");
        private By chkInclude = By.XPath("//label[text()='Include unspecified']//preceding-sibling::input");
        private By frameMatch = By.XPath("//iframe[contains(@id,'match__')]");
        //By.XPath("//iframe[@src='..//Search/match/']");
        private By clrItems = By.XPath("/html/body//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/a[@class='clear-filters' and text()='Clear Items']");
            //By.XPath("/html/body/div[9]/div/a");
        
        #endregion

        #region Footer
        private By btnRefresh = By.Id("ctl00_cphMain_btnRefresh_input");
        private By btnRestore = By.Id("ctl00_cphMain_btnReset_input");
        private By ddlDashboard = By.Id("ctl00_cphMain_ddlDashboards");
        private By chckDefault = By.Id("ctl00_cphMain_chkDefaultDashboard");
        #endregion

        #region Header
        private By RightHeaderMenu = By.XPath("//span[@id='ctl00_xpnlHeader']/div/span");
        private By lnkTasks = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='My Tasks']");
        private By lnkCallPlanner = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='My Call Planner']");
        private By lnkTags = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='My Tags']");
        private By lnkPersonal = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='Personal Settings']");
        private By lnkSignatures = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='Signatures']");
        private By lnkChangePassword = By.XPath("//span[@id='ctl00_xpnlHeader']/div/ul/li/a[text()='Change Password']");
        #endregion

        #region Positions
        private By lnkPositions = By.XPath("//span[text()='Positions']");
        private By txtPositionId = By.XPath("//div[@id='topmenu']/div/nav/ul/li[1]/div/ul/li[2]/span/div/div/input");
        private By txtPositionIdRecruiter = By.XPath("//div[@id='topmenu']//ul/li[1]/div/ul/li[4]/span//input");
        #endregion

        #region AddVendor
        private By lnkVendor = By.XPath("//span[text()='Vendor']");
        #endregion

        #region AddContact
        private By lnkContact = By.XPath("//span[text()='Contact']");
        private By lblCompany = By.XPath("//div[@id='pagetitle']/h1");
        #endregion

        #region SearchContact
        private By lnkSearchcontact = By.XPath("//span[text()='Contacts']");
        private By txtContactId = By.XPath("//div[@id='topmenu']/div/nav/ul/li[1]/div/ul/li[3]/span/div/div/input");
        #endregion

        #region TimeSheets
        private By lnkCreatetimeSheets = By.XPath("//span[text()='Create Timesheets']");
        private By lnkProcesstimeSheets = By.XPath("//span[text()='Process Timesheets']");
        private By lnkSearchtimesheets = By.XPath("//span[text()='Search Timesheets']");
        private By lnkOne = By.XPath("//span[text()='One']");
        private By ddnMatch = By.XPath("//label[text()='Match: ']/../div/a");
        private By txtMatch = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By ddnPeriod = By.XPath("//label[text()='Period: ']/../div/a");
        private By txtPeriod = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnCreate = By.XPath("//input[@value='Create']");
        private By lnkContinuetimesheet = By.XPath("//a[text()='Continue to timesheet']");
        private By ddnAddfilters = By.XPath("//span[text()='Add Filters...']");
        private By txtTimesheetinput = By.XPath("//div[@class='select2-drop add-filters select2-with-searchbox select2-drop-active']/div/input");
        private By ddnTimesheet = By.XPath("//label[text()='Timesheet ID:']");
        private By txtTimesheet = By.XPath("//div[@class='jquery-ui-v1-10-3 search-fullscreen']/../div[6]/div/div/div/input");
        private By SearchTimesheetinput = By.XPath("//span[text()='Search Timesheets']/div/div/input");
        private By btnSearch = By.XPath("//input[@value='Search']");
        private By chkboxTimesheet = By.XPath("//input[@class='check-one']");
        private By txtDelete = By.XPath("//div[text()='Delete']");
        private By btnDelete = By.XPath("//button[text()='Delete']");
        private By ddnCandidateStatus = By.XPath("//div[text()='Candidate Status']");
        private By ddnActiveMatch = By.XPath("//div[text()='Active Matches Only']");
        private By ddnTypes = By.XPath("//div[text()='Types']");
        private By ddnStages = By.XPath("//div[text()='Stages']");
        private By txtSearchTimesheets = By.XPath("//span[text()='Search Timesheets']//input");
        private By lnkMany = By.XPath("//span[text()='Many']");

        #endregion

        #region LeftSideBarIcons
        private By btnBug = By.Id("toolReportFeature");
        private By btnHistory = By.XPath("//input[@class='history clicktip']");
        private By HistoryTab = By.XPath("//div[@class='TabFilter widgettitle']");
        private By btnClosehistory = By.XPath("//div[@class='t_CloseState'][1]");
        private By btnFavorites = By.XPath("//input[@class='favorites clicktip']");
        private By FavoritesTab = By.XPath("//div[@class='TabFilter widgettitle']");
        private By btnTags = By.XPath("//input[@class='clicktip tags']");
        private By tagsTab = By.XPath("//div[@class='AboutTypeFilter TabFilter']/span");
        private By btnSavedSearches = By.XPath("//input[@class='clicktip savedsearch']");
        private By savedSearchesTab = By.XPath("//div[@class='widgettitle title']/span");
        private By btnCloseSavedSearch = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[5]//div[1]/canvas");
        private By btnAlerts = By.Id("alertsIcon");
        private By alertsTab = By.XPath("//div[@id='alerts']/div/text()");
        private By btnAlertClose = By.Id("ctl00_imgClose");
        private By btnHelp = By.Id("help");
        private By btnHideBar = By.XPath("//input[@class='hidebar']");
        #endregion

        #region Modify Dashboard
        private By btnModifyDashboard = By.XPath("//div[@id='ctl00_cphMain_RadDock0_T']/ul/li/a/span");
        private By btnSaveDashboard = By.Id("ctl00_cphMain_RadDock0_C_ctl00_btnSaveName_input");
        private By txtDashboardName = By.Id("ctl00_cphMain_RadDock0_C_ctl00_txtDashboardName");
        private By lblDashBoardName = By.XPath("//label[contains(text(),'Dashboard Name:')]");
        private By lblAddWidget = By.XPath("//span[contains(text(),'Add Widget:')]");
        private By lblColumnWidth = By.XPath("//label[contains(text(),'Column width distribution (%):')]");
        #endregion  
        private By lnkRequirements = By.XPath("//span[text()='Requirements']");
        private By lnkRequirements2 = By.XPath("//span[@data-tipname='requirement/manage']");
        private By txtCurrentPwd = By.XPath("//input[contains(@id,'_cphMain_CurrentPassword')]");
        private By txtNewPwd = By.XPath("//input[contains(@id,'_cphMain_NewPassword')]");
        private By txtConfirmPwd = By.XPath("//input[contains(@id,'_cphMain_ConfirmNewPassword')]");
        private By btnChangePassword = By.XPath("//input[contains(@id,'_cphMain_btnChangePassword_input')]");
        private By hdPageTitle = By.XPath("//div[@id='pagetitle']/h1[contains(text(),'Dashboard')]");
        #endregion

        private By frameCandidateQuick = By.XPath("//iframe[contains(@id,'candidate_By-quick')]");
        private By frameContactQuick = By.XPath("//iframe[contains(@id,'contact_By-quick')]");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'dashboard')]");
        private By framematch = By.XPath("//iframe[@src='..//Mvc/match/new?quickplacement=true']");
        private By lbltypes = By.XPath("//label[text()='Types:']");
        private By icontypes = By.XPath("//label[text()='Types:']/../../../div[@class='filter-close-button k-icon k-group-delete']");
        private By lblstages = By.XPath("//label[text()='Stages:']");
        private By iconstages = By.XPath("//label[text()='Stages:']/../../../div[@class='filter-close-button k-icon k-group-delete']");
        private By lnkCustomrules = By.XPath("//a[text()='Custom Rules']");
        private By frameAdminManage = By.XPath("//iframe[contains(@id,'admin_site-ManageRules')]");
        //private By frameAdminDefault = By.XPath("//iframe[contains(@id,'admin_Default')]");
        private By btnInitializePage = By.Id("ctl00_ctl00_cphMain_cphMain_btnInitializePages_input");
        //private By lnkCandidateApplications = By.XPath("//span[text()='Client Project']/../..//li//span[text()='Candidate Application']");
        private By txtPositionMessage = By.XPath("//div[@id='submitIsNotValid']");
        private By lnkSeed = By.XPath("//span[text()='Client Project']/../..//li//span[text()='Seed']");
        //AddCandidateApplication
        private By lnkCandidateApplications = By.XPath("//span[text()='Candidate Application']");

        private By txtExpirationWarningDays = By.Id("ExpirationWarningDays");
        private By warningMessage = By.XPath("//div[@class='error message messaging']");
        private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage')]");
        private By btnAddRequirements = By.XPath("//button[text()='Add Requirement']");
        private By lnkAudit = By.XPath("//table[@id='candidatetable']/tbody/tr[1]/td//span[text()='Audit']");
        private By btnEditDetails = By.XPath("//span[text()='Edit details']");
        private By lnkrequirements = By.XPath("//span[@id='RequirementCount']");
        // private By ddlNewCustField = By.XPath("//span[contains(text(),'MyCustField1116115008')]/..//following-sibling::select/option");
        private By ddlRequirementTemplate = By.XPath("//label[contains(text(),'Requirement Template')]//following-sibling::img//following-sibling::div/a/span");
        private By requirement = By.XPath("//div[@id='s2id_autogen2']");
        private By status = By.XPath("//label[text()='Status']");
        private By priority = By.XPath("//label[text()='Priority']");
        private By effectiveDate = By.XPath("//label[text()='Effective Date']");
        private By expirationDate = By.XPath("//label[text()='Expiration Date']");

        private By issueDate = By.XPath("//label[text()='Issue Date']");
        private By reference = By.XPath("//label[text()='Reference']");
        private By note = By.XPath("//label[text()='Note']");
        private By attachment = By.XPath("//label[text()='Attachment']");
        private By owner = By.XPath("//label[text()='Owner']");
        private By addOwner = By.XPath("//label[text()='Additional Owners']");
       
        //private By expirationDays = By.XPath("//label[text()='Expiration Warning Days']");
        //private By tags = By.XPath("//label[text()='Tags']");
        private By required = By.XPath("//h4[text()='Required']");
        private By from = By.XPath("//label[text()='From']");
        private By to = By.XPath("//label[text()='To']");
        private By mandatoryFor = By.XPath("//h4[text()='Mandatory For']");
        private By submital = By.XPath("//label[text()='Submittal']");
        private By fullPlacement = By.XPath("//label[text()='Full Placement']");
        private By timeSheetSubmission = By.XPath("//label[text()='Timesheet Submission']");
        private By burden = By.XPath("//h4[text()='Burdens']");
        private By burderPerHour = By.XPath("//label[text()='Burden Per Hour']");
        private By burdenPerTimeSheet = By.XPath("//label[text()='Burden Per Timesheet']");
        private By burdenBilled = By.XPath("//label[text()='Burden Billed %']");
        private By burdenPaid = By.XPath("//label[text()='Burden Paid %']");
        private By burdenOneTime = By.XPath("//label[text()='Burden One Time']");
        private By txtSearchReqTemplate = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By ddlRequirementForComp = By.XPath("//div[@id='s2id_autogen4']/a");
        private By txtSearchReq = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnSaveNewCustField = By.XPath("//span[text()='Save']");
        // private By ddlNewCustFiled = By.XPath("span[contains(text(),'" + newCustomField + "')]/..//following-sibling::span/input"));


        private By lblErecruit = By.XPath("//img[@src='/App_Themes/Default/images/logos/logo.png']");
        private By lnkSavedSearches = By.XPath("//span[text()='Saved Searches']");
        private By lnkCandidates = By.XPath("//h2[text()='Search']/../following-sibling::ul//span[text()='Candidates']");
        private By btnNewQP = By.XPath("//div[text()='New QP']");
        private By CandidateApplications = By.XPath("//span[text()='Candidate Applications']");
        private By btnContactQP = By.XPath("//span[@id='MatchCount']/../following-sibling::div/button[@id='btnAddNewMatchQP']");
        private By lnkExportWIP = By.XPath("//span[text()='Export WIP to GP']");
        private By ddnExportSelectAll = By.XPath("//img[@title='Select/Unselect All']");
        private By btnGo = By.XPath("//input[@value='Go']");
        private By SelectDate = By.XPath("//a[@id='ctl00_cphMain_ddlDate_Arrow']");
        private By btnExport = By.XPath("//input[@value='Export']");
        private By btnThreeSlashs = By.XPath("//div[text()='Yes']/..//following-sibling::td[3]/div");
        private By btnConfirm = By.XPath("//span[text()='Confirmed']");
        private By btnCloseReq = By.XPath("//button[text()='Close']");
        private By frameMatcManage = By.XPath("//iframe[contains(@id,'match_manage_')]");
        private By btnReferesh = By.XPath("//input[contains(@id,'_cphMain_cphBottomButtons_btnRefresh_input')]");
        //Add foldergroup
        private By lnkFolderGroup = By.XPath("//span[contains(text(),'Folder Groups/Industries')]");
        private By frameGroup = By.XPath("//iframe[@id='pvFolderGroupsNew_frame']");
        private By ddlfolderGroup = By.XPath("//div[@id='s2id_FolderGroupsDropDownList']/a");
        private By txtSearchFolderGroup = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnAddFolderGroupForContact = By.XPath("//input[@value='Add Folder Group']");
        //Add position from contact

        private By btnAddPosition = By.XPath("//button[contains(@id,'_btnAddNewPosition')]");
        private By frameDashBoard = By.XPath("//iframe[@id='dashboard']");
        private By ddlPositionTemp = By.XPath("//input[contains(@id,'_ddlPositionTemplate_Input')]");
        private By date = By.XPath("//input[contains(@id,'dpProjectedStartDate_dateInput')][1]");
        private By ddlTypePosition = By.XPath("//input[contains(@id,'cphMain_ddlPosType_Input')]");
        private By ddlReason = By.XPath("//input[contains(@id,'cphMain_ddlCreationReason_Input')]");
        private By ddlinitialState = By.XPath("//input[contains(@id,'cphMain_ddlStatus_Input')]");
        private By txtDuration = By.XPath("//input[contains(@id,'cphMain_txtDurationQty')]");
        private By duration = By.XPath("//input[contains(@id,'cphMain_ddlDurationUnit_Input')]");
        private By btnSavePosition = By.XPath("//input[contains(@id,'cphMain_btnSave_input')]");
        private By framePosition = By.XPath("//iframe[contains(@id,'position_new_')]");
        private By selectDashboard = By.Id("ctl00_cphMain_ddlDashboards");
        private By searchFrame = By.XPath("//iframe[@src='..//Search/opportunity/']");
        private By lnkDesignDashboard = By.XPath("//a[text()='Design Dashboards']");
        private By btnAddReq = By.XPath("//button[text()='Reset']/following-sibling::button[text()='Add Requirement']");
        private By ddnErecruitVMS = By.XPath("//*[@id='ctl00_ddlActiveMode']");
        #region Public Methods

        /// <summary>
        /// Method to Login to application
        /// </summary>
        /// <param name="url"></param>
        /// <param name="emailid"></param>
        /// <param name="pwd"></param>
        public void Login(string url, string emailid, string pwd)
        {
            try
            {
               
                driver.Navigate().GoToUrl("about:blank");
                //driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl(url);
                driver.SendKeysToElementClearFirst(txtEmail, emailid, "email");
                driver.SendKeysToElementClearFirst(txtPassword, pwd, "password");
                driver.ClickElement(btnLogin, "Login Button");
                driver.sleepTime(20000);
                this.TESTREPORT.LogSuccess("NavigateToHome", String.Format("Navigated to home: <mark>{0}</mark> successfully", url));
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToHome", "Failed to navigate to url:" + url, EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Logout from application
        /// </summary>


        public void Logout()

        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.ClickElementWithJavascript(mnuLogout, "Logout");
                driver.ClickElementWithJavascript(lnkLogout, "Logout");
                if (driver.isAlertPresent())
                {
                    IAlert devAlert = driver.SwitchTo().Alert();
                    devAlert.Accept();
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Logout", "Failed to Logout:", EngineSetup.GetScreenShotPath());
            }
        }
        public void NavigateToAddCandidate()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.ClickElement(logoMenu, "ImageLogo");
                driver.sleepTime(5000);
                driver.MouseHover(lnkAddnew, "Add New");
                driver.MouseHover(lnkCandidate, "Candidate");
                //driver.MouseHoverByJavaScript(lnkCandidate, "Candidate");
                driver.ClickElement(lnkWithoutresume, "WithOut Resume");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToHome", "Failed to navigate to url:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Click On Logo Menu
        /// </summary>
        public void ClickOnLogoMenu()
        {
            try
            {
                driver.WaitElementPresent(logoMenu);
                driver.ClickElement(logoMenu, "ImageLogo");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Logo Menu", "Failed to click on logo menu:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Click On Company
        /// </summary>
        public void ClickOnCompany()
        {
            try
            {
                driver.ClickElement(lnkCompany, "Company");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Company", "Failed to click on Company:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Mouse Hover On Search Menu
        /// </summary>
        public void MouseHoverOnSearch()
        {
            try
            {
                driver.MouseHover(Search, "Mouse Hover On Search");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Search", "Mouse Hover On Search:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnAddNewMatch()
        {
            try
            {
                driver.ClickElement(logoMenu, "ImageLogo");
                driver.MouseHover(lnkAddnew, "Mouse Hover On Add New");
                driver.MouseHover(lnkMatch, "Mouse Hover On Match");
                driver.ClickElement(lnkMatch, "Click on Add new match");
                driver.sleepTime(10000);

            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Method To Mouse Hover On Matches
        /// </summary>
        public void MouseHoverOnMatches(string matchId)
        {
            try
            {
                driver.MouseHover(lnkMatches, "Mouse Hover On Matches");
                driver.WaitElementPresent(lnkMatchinput);
                driver.SendKeysToElementAndPressEnter(lnkMatchinput, matchId, "Matches Input");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Matches", "Mouse Hover On Matches:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Click On Matches
        /// </summary>
        public void ClickMatchesAndValidate(string fromSalary,string toSalary,string OfferSalary)
        {
            try
            {
                driver.MouseHover(lnkMatches, "Mouse Hover On Matches");
                driver.ClickElement(lnkMatches, "Click On Matches");
                // driver.sleepTime(30000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatch);
                driver.SwitchToFrameByLocator(frameMatch);
                driver.sleepTime(5000);
                if (!driver.IsElementPresent(txtOfferSalary))
                {
                    driver.ClickElement(txtAddFilter, "Offer Salary");
                    driver.SendKeysToElementAndPressEnter(txtSearchOfferSal, OfferSalary, "Offer Salary");

                }
                driver.ClickElement(txtOfferSalary, "Offer Salary");
                driver.WaitElementPresent(txtFromSalary);
                driver.ClickElementAndSendKeys(txtFromSalary, fromSalary, "FromSalary");
                driver.sleepTime(2000);
                driver.WaitElementPresent(txtToSalary);
                driver.ClickElementAndSendKeys(txtToSalary, toSalary, "ToSalary");
                driver.WaitElementPresent(chkInclude);
                driver.ClickElement(chkInclude, "Chkbox");
                driver.WaitElementPresent(clrItems);
                driver.ClickElement(clrItems, "Clear Items");
                driver.sleepTime(5000);
               
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Matches", " Failed to Click On Matches:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnSearchMatch()
        {
            try
            {
                driver.MouseHover(lnkMatches, "Mouse Hover On Matches");
                driver.ClickElement(lnkMatches, "Click On Matches");
                driver.sleepTime(10000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Match", " Failed to ClickOnMatch:", EngineSetup.GetScreenShotPath());
            }
        }
        public void RefreshMatch(string matchId)
        {
            try
            {
                driver.MouseHover(lnkMatches, "Mouse Hover On Matches");
                driver.sleepTime(2000);
                driver.SendKeysToElementAndPressEnter(lnkMatchinput, matchId, "Matches Input");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatcManage);
                driver.SwitchToFrameByLocator(frameMatcManage);
                driver.ClickElement(btnReferesh, "Refresh");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Matches", "Mouse Hover On Matches:", EngineSetup.GetScreenShotPath());
            }
        }
        public void MouseHoverOnAccounting()
        {
            try
            {
                driver.MouseHover(lnkAccounting, "Mouse Hover On Accounting");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Accounting", "Mouse Hover On Accounting:", EngineSetup.GetScreenShotPath());
            }
        }
        public void MouseHoverOnCreateTimesheet()
        {
            try
            {
                driver.MouseHover(lnkCreatetimeSheets, "Mouse Hover On Create Timesheet");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Create Timesheet", "Mouse Hover On Create Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnOneTimesheet()
        {
            try
            {
                driver.ClickElement(lnkOne, "One");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On One", "Failed to click on One:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickonManyTimesheets()
        {
            try
            {
                driver.ClickElement(lnkMany, "Many Timesheets link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Many", "Failed to Click on Many", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnSearchTimesheet()
        {
            try
            {
                driver.ClickElement(lnkSearchtimesheets, "Search Timesheet");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Search Timesheet", "Failed to click on Search Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to search a candidate
        /// </summary>
        /// <param name="name"></param>
        public void SearchCandidate(string name)
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnSearch();
                driver.MouseHover(Candidates, "Mouse Hover On Candidates");
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(txtCandidateName, name, "candidate name");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameCandidateQuick);
                driver.SwitchToFrameByLocator(frameCandidateQuick);
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Click Search button");
                driver.sleepTime(5000);
                By by = By.XPath(string.Format("//table/tbody/tr/td[3]/div/a[contains(text(),'{0}')]", name));
                driver.WaitElementPresent(by);
                if (driver.ElementPresent(by, "Candidate Name"))
                {
                    this.TESTREPORT.LogSuccess("Candidate Search", String.Format("Candidate Search: <mark>{0}</mark> found successfully", name));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Candidate Search", "Candidate Search:", EngineSetup.GetScreenShotPath());
                }
                driver.ClickElement(by, "Click Candidate Name");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Search", "Candidate Search:", EngineSetup.GetScreenShotPath());
            }
        }
        public void SearchCandidateWithId(string id)
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnSearch();
                driver.MouseHover(Candidates, "Mouse Hover On Candidates");
                driver.SendKeysToElementAndPressEnter(txtCandidateName, id, "candidate name");
                driver.sleepTime(10000);

            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Candidate Search", "Candidate Search:", EngineSetup.GetScreenShotPath());

            }

        }
        /// <summary>
        /// Method to Restore Dashboard
        /// </summary>
        public void RestoreDashboard()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh Dashboard");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRestore);
               // driver.VerifyWebElementPresent(btnRestore, "Restore Dashboard");
                driver.ClickElement(btnRestore, "Restore Dashboard");
                HandleAlert();
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Restore Dashboard", "Restore Dashboard", EngineSetup.GetScreenShotPath());
            }
        }
        public void SelectDashboard()
        {
            try
            {
                //driver.SelectDropdownItemByValue(ddlDashboard, "330", "Dashboard");
                driver.WaitElementPresent(selectDashboard);
                driver.ClickElement(selectDashboard, "Select Dashboard");
                driver.WaitElementPresent(chckDefault);
                driver.ClickElement(chckDefault, "Default");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Restore Dashboard", "Restore Dashboard", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Verify Header Menu
        /// </summary>
        public void VerifyHeader()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(RightHeaderMenu);
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkTasks, "My Tasks");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementExistsAndVisible(lblCompany);
                driver.SwitchToDefaultFrame();
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkTags, "My Tags");
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(2);
                driver.WaitElementExistsAndVisible(lblCompany);
                driver.SwitchToDefaultFrame();
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkPersonal, "Personal Settings");
               driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(3);
                driver.WaitElementExistsAndVisible(lblCompany);
                driver.SwitchToDefaultFrame();
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkSignatures, "Signatures");
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(4);
                driver.WaitElementExistsAndVisible(lblCompany);
                driver.SwitchToDefaultFrame();
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkChangePassword, "Change Password");
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(5);
                driver.WaitElementExistsAndVisible(lblCompany);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Header", "Verify Header", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to verify My Tags link
        /// </summary>
        public void verifyMyCallPlanner()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.ClickElement(RightHeaderMenu, "Right Header Menu");
                driver.ClickElement(lnkCallPlanner, "My CallPlanner");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByIndex(6);
                driver.WaitElementExistsAndVisible(lblCompany);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify MyTags", "Verify MyTags", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyLeftsidebarIcons()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(btnHistory);
                driver.ClickElement(btnHistory, "Recent History");
                driver.VerifyWebElementPresent(HistoryTab,"History Tab");
                driver.WaitElementPresent(btnClosehistory);
                driver.ClickElement(btnClosehistory, "Close History Tab");

                driver.WaitElementPresent(btnFavorites);
                driver.ClickElement(btnFavorites, "Favorites");
                driver.VerifyWebElementPresent(FavoritesTab,"Favourite Tab");
                driver.WaitElementPresent(btnClosehistory);
                driver.ClickElement(btnClosehistory, "Close History Tab");

                //driver.WaitElementPresent(btnTags);
                //driver.ClickElement(btnTags, "Tags");
                //driver.VerifyWebElementPresent(tagsTab,"Tags Tab");
                //driver.WaitElementPresent(btnClosehistory);
                //driver.ClickElement(btnClosehistory, "Close Tags Tab");

                //driver.WaitElementPresent(btnSavedSearches);
                //driver.ClickElement(btnSavedSearches, "Saved Searches");
                //driver.VerifyWebElementPresent(savedSearchesTab,"Saved Searches Tab");
                //driver.WaitElementPresent(btnCloseSavedSearch);
                //driver.ClickElement(btnCloseSavedSearch, "Close SavedSearches Tab");

                driver.WaitElementPresent(btnAlerts);
                driver.ClickElement(btnAlerts, "Alerts");
                driver.VerifyWebElementPresent(btnAlerts,"Alert Tab");
                driver.WaitElementPresent(btnAlertClose);
                driver.ClickElement(btnAlertClose, "Close Alerts Tab");

                driver.WaitElementPresent(btnHelp);
                driver.ClickElement(btnHelp, "Help");
                //driver.SwitchToFrameByIndex(1);
                //driver.VerifyWebElementPresent(lblCompany,"Company");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Leftside Bar", "Verify Leftside Bar Icons", EngineSetup.GetScreenShotPath());
            }
        }
        public void ModifyDashboard(string dashBoardValue)
        {
            try
            {
                driver.WaitElementPresent(frameDashboard);
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnModifyDashboard);
                driver.ClickElement(btnModifyDashboard, "Modify Dashboard");

                driver.VerifyWebElementPresent(lblDashBoardName, "DashBoard Name");
                driver.VerifyWebElementPresent(lblAddWidget, "Add Widget");
                driver.VerifyWebElementPresent(lblColumnWidth, "Column width distribution (%)");
                driver.SendKeysToElementClearFirst(txtDashboardName, dashBoardValue, "Dashboard");

                var txtDashBoard = driver.FindElement(By.Id("ctl00_cphMain_RadDock0_C_ctl00_txtDashboardName"));
                string text = txtDashBoard.GetAttribute("value");
                driver.VerifyWebElementPresent(btnSaveDashboard, "Save DashBoard");
                driver.ClickElement(btnSaveDashboard, "Click Save DashBoard");
                string DDlDashboardname = driver.GetDropdownSelectedOptionText(ddlDashboard);
                driver.AssertTextMatching(text, DDlDashboardname);

                driver.sleepTime(5000);
                driver.WaitElementPresent(btnModifyDashboard);
                driver.ClickElement(btnModifyDashboard, "Modify Dashboard");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Modify Dashboard", "Failed while Modifying Dashboard", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Method to Search position in recruiter
        /// </summary>
        //public void SearchPos(string positionID)
        //{
        //    try
        //    {
        //        driver.MouseHover(lnkPositions, "Positions");
        //        driver.SendKeysToElementAndPressEnter(txtPositionIdRecruiter, positionID, "Position Id");
        //        driver.SwitchToDefaultFrame();
        //        driver.sleepTime(5000);
        //        driver.WaitElementPresent(framePositionManage);
        //        driver.SwitchToFrameByLocator(framePositionManage);
        //        driver.sleepTime(5000);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.TESTREPORT.LogFailure("Search Position", "Search Position", EngineSetup.GetScreenShotPath());
        //    }
        //}
        /// <summary>
        /// Method to Navigate to Position
        /// </summary>
        public void NavigateToPositionvendor(string positionId)
        {
            try
            {
                driver.MouseHover(lnkPositions, "Positions");
                driver.SendKeysToElementAndPressEnter(txtPositionId, positionId, "Position Id");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToVendor", "Failed to navigate to vendor", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Navigate to Add New link
        /// </summary>
        public void NavigateToAddnew()
        {
            try
            {
              driver.MouseHover(lnkAddnew, "Add New");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAdNewLink", "Failed to navigate to AddNew link", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Navigate to Add Company
        /// </summary>
        public void NavigateToAddCompany()
        {
            try
            {
                driver.WaitElementPresent(lnkCompany);
                driver.ClickElement(lnkCompany, "Company");
                //driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToCompany", "Failed to navigate to Company", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Navigate to Add Vendor
        /// </summary>
        public void NavigateToAddvendor()
        {
            try
            {
                driver.WaitElementPresent(lnkVendor);
                driver.ClickElement(lnkVendor, "Vendor");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToVendor", "Failed to navigate to vendor", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Navigate to Add contact
        /// </summary>
        public void NavigateToAddContact()
        {
            try
            {
                driver.WaitElementPresent(lnkContact);
                driver.ClickElement(lnkContact, "Contact");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        ///Method to search contact 
        /// </summary>
        public void SearchContact()
        {
            try
            {
                driver.MouseHover(lnkSearchcontact, "Search Contact");
                driver.SendKeysToElementAndPressEnter(txtContactId, AddCandidatePage.id, "Contact Id");
                driver.sleepTime(5000);
                this.TESTREPORT.LogSuccess("NavigateToContact", "Able to navigate to Contact Successfully");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }

        public void SearchVendorContact()
        {
            try
            {
                driver.MouseHover(lnkSearchcontact, "Search Contact");
                driver.SendKeysToElementAndPressEnter(By.XPath("//div[@id='topmenu']/div/nav/ul/li[1]/div/ul/li[2]/span/div/div/input"), AddCandidatePage.id, "Contact Id");
                this.TESTREPORT.LogSuccess("NavigateToContact", "Able to navigate to Contact Successfully");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Vendor Contact", EngineSetup.GetScreenShotPath());
            }
        }

        public void SearchContact(string contactName)
        {
            try
            {
                driver.MouseHover(lnkSearchcontact, "Search Contact");
                driver.SendKeysToElementAndPressEnter(By.XPath("//div[@id='topmenu']/div/nav/ul/li[1]/div/ul/li[2]/span/div/div/input"), contactName, "Contact Name");
                this.TESTREPORT.LogSuccess("NavigateToContact", "Able to navigate to Contact Successfully");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                driver.WaitElementPresent(frameContactQuick);
                driver.WaitElementPresent(frameContactQuick);
                driver.SwitchToFrameByLocator(frameContactQuick);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        ///Method to search candidate 
        /// </summary>
        public void SearchCandidateId()
        {
            try
            {
                driver.MouseHover(Candidates, "Search Candidate");
                driver.SendKeysToElementAndPressEnter(txtCandidateName, AddCandidatePage.id, "Candidate Id");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Click on Candidate Search
        /// </summary>
        public void SearchCandidate()
        {
            try
            {
                driver.ClickElementWithJavascript(Candidates, "Search Candidate");
                driver.sleepTime(5000);
                driver.WaitElementPresent(framecandidate);
                driver.SwitchToFrameByLocator(framecandidate);
                //string title = driver.GetElementText(lblCompany);
                //if (title.Contains("Candidates"))
                //    TESTREPORT.LogSuccess("Search Candidate Page", "Successfully redirected to Search candidate Page");
                //else
                //    TESTREPORT.LogFailure("Search Candidate Page", "Unable to redirected to Search candidate Page");

                
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Click Candidate", "Failed to Search Candidate", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        ///Method to search candidate 
        /// </summary>
        public void SearchCompanyById()
        {
            try
            {
                driver.MouseHover(lnkSearchCompanies, "Search Company");
                driver.SendKeysToElementAndPressEnter(txtCompaniesName, AddCompanyPage.title, "Companies Id");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Mouse Hover on companies
        /// </summary>
        public void SearchCompanyByPassingId( )
        {
            try
            {
                driver.MouseHover(lnkSearchCompanies, "Search Company");
                driver.SendKeysToElementAndPressEnter(txtCompaniesName, AddCompanyPage.title, "Search Company");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("MouseHover On Companies", "Failed to navigate to Companies", EngineSetup.GetScreenShotPath());
            }

        }
        public void AddFolderGroup(string folderGroupForContact)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.ClickElement(lnkFolderGroup, "Folder Group");
                driver.sleepTime(10000);
                driver.ScrollToPageTop();
                driver.SwitchToFrameByLocator(frameGroup);
                driver.ClickDropdownAndSearchText(ddlfolderGroup, txtSearchFolderGroup, folderGroupForContact, "Search Folder Group");
                driver.sleepTime(4000);
                driver.ClickElement(btnAddFolderGroupForContact, "Add Folder");
                driver.sleepTime(5000);


            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddFolderGroup", "Failed to AddFolderGroup", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Search company by passing id
        /// </summary>
        /// <param name="companyId"></param>
        public void SearchComapany(string companyId)
        {
            try
            {
                driver.MouseHover(lnkSearchCompanies, "Search Company");
                driver.SendKeysToElementAndPressEnter(txtCompaniesName, companyId, "Search Company");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("MouseHover On Companies", "Failed to navigate to Companies", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        ///Click Requirement and validate the fields
        /// </summary>
        public void CilckRequirementAndValidateFields()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.WaitElementPresent(btnAddRequirements);
                driver.ClickElement(btnAddRequirements, "Add Requirement");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(ddlRequirementTemplate, "Requirement Template");
                driver.VerifyWebElementPresent(requirement, "Requirement");
                driver.VerifyWebElementPresent(status, "Status");
                driver.VerifyWebElementPresent(issueDate, "issueDate");
                driver.VerifyWebElementPresent(reference, "reference");
                driver.VerifyWebElementPresent(note, "note");
                driver.VerifyWebElementPresent(attachment, "attachment");
                driver.VerifyWebElementPresent(owner, "owner");
                driver.VerifyWebElementPresent(addOwner, "addOwner");
                driver.ClickElement(lnkShowMore, "Link Show More");
                driver.VerifyWebElementPresent(required, "Required");
                driver.VerifyWebElementPresent(from, "From");
                driver.VerifyWebElementPresent(to, "To");
                driver.VerifyWebElementPresent(mandatoryFor, "Mandatory For");
                driver.VerifyWebElementPresent(submital, "Submital");
                driver.VerifyWebElementPresent(fullPlacement, "Full Placement");
                driver.VerifyWebElementPresent(timeSheetSubmission, "Time sheet");
                driver.VerifyWebElementPresent(burden, "Burden");
                driver.VerifyWebElementPresent(burderPerHour, "Burden per hour");
                driver.VerifyWebElementPresent(burdenPerTimeSheet, "burdenPerTimeSheet");
                driver.VerifyWebElementPresent(burdenBilled, "burdenBilled");
                driver.VerifyWebElementPresent(burdenPaid, "burdenPaid");
                driver.VerifyWebElementPresent(burdenOneTime, "burdenOneTime");
                driver.ClickElement(lnkShowLess, "Show Less");

           }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("CilckRequirementAndValidateFields", "Failed to Cilck Requirement And Validate Fields", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Add And Save Requirement
        /// </summary>
        /// 
        public void AddAndSaveRequirement(string searchReqTemplate)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCompany);
                driver.SwitchToFrameByLocator(iframeCompany);
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.WaitElementPresent(btnAddRequirementToVerify);
                driver.ClickElement(btnAddRequirementToVerify, "Add Requirement");
                driver.sleepTime(5000);
                driver.ClickDropdownAndSearchText(ddlRequirementTemplate, txtSearchReqTemplate, searchReqTemplate, "Requirement Template");
                driver.WaitElementPresent(btnAddRequirements);
                driver.ClickElement(btnAddRequirements, "Add Requirement");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddAndSaveRequirement", "Failed AddAndSaveRequirement", EngineSetup.GetScreenShotPath());
            }

        }
        public void AddAndsaveRequirements(string searchReqTemplate,string requirement)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframeCompany);
                driver.ScrollPage();
                driver.ClickElement(btnAddRequirementToVerify, "Add Requirement");
                driver.sleepTime(5000);
                driver.ClickDropdownAndSearchText(ddlRequirementTemplate, txtSearchReqTemplate, searchReqTemplate, "Requirement Template");
                driver.sleepTime(2000);
                driver.ClickDropdownAndSearchText(ddlRequirementForComp, txtSearchReq, requirement, "Requirement");
                driver.sleepTime(2000);
                driver.ClickElementWithJavascript(btnAddReq, "Add Requirement");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddAndSaveRequirement", "Failed AddAndSaveRequirement", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add And Save Requirement
        /// </summary>
        public void AddAndSaveRequirement()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframeCompany);
                driver.ScrollPage();
                driver.ClickElement(btnAddRequirementToVerify, "Add Requirement");
                driver.sleepTime(5000);
                driver.ClickElement(lnkShowMore, "Link Show More");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddAndSaveRequirement", "Failed AddAndSaveRequirement", EngineSetup.GetScreenShotPath());
            }
        }



        //}
        /// <summary>
        /// Validating the new custom field
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="newCustomField"></param>
        public void ValidateNewCustomField(string companyId, string newCustomField)
        {
            try
            {
                driver.MouseHover(lnkSearchCompanies, "Search Company");
                driver.SendKeysToElementAndPressEnter(txtCompaniesName, companyId, "Search Company");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCompany);
                driver.SwitchToFrameByLocator(iframeCompany);
                driver.ScrollPage();
                driver.ClickElement(btnAddRequirementToVerify, "Add Requirement");
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.ClickElement(lnkShowMore, "Link Show More");
                driver.sleepTime(5000);
                By lblCustomField = By.XPath("//label[contains(text(),'" + newCustomField + "')]");
                driver.CheckElementExists(lblCustomField, "Custom Field");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify new custom field", "Failed to Verify new custom field", EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// Method to click Search Click Company
        /// </summary>

        public void SearchCompany()
        {
            try
            {
                driver.ClickElement(lnkSearchCompanies, "Search Company");
                driver.sleepTime(20000);
                //driver.SwitchToFrameByLocator(iframeCompany);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(lblCompany);
                string title = driver.GetElementText(lblCompany);
                if (title.Contains("Companies"))
                    TESTREPORT.LogSuccess("Search Company Page", "Successfully redirected to Search Company Page");
                else
                    TESTREPORT.LogFailure("Search Company Page", "Unable to redirected to Search Company Page");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToContact", "Failed to navigate to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify the Company merge
        /// </summary>
        /// <param name="companyName"></param>
        public void VerifyMergeCompany(string mergCompanyName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.ScrollToPageBottom();
                driver.WaitElementPresent(lnkMergeCompany);
                driver.ClickElement(lnkMergeCompany, "Link Merge Company");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameGeneralMergeRecods);
                driver.SwitchToFrameByLocator(frameGeneralMergeRecods);
                driver.SendKeysToElement(ddlCompanyName, mergCompanyName, "Select Company Name");
                driver.sleepTime(2000);
                driver.SendKeysToElement(ddlCompanyName, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(1000);
                driver.WaitElementPresent(btnMerge);
                driver.ClickElement(btnMerge, "Merge button");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Merge Company", "Failed to Verify Merge Company", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify Company is showing or not
        /// </summary>

        public void VerifyCompaniesShowing(string newCreatedcompanyId, string searchResult)
        {
            try
            {
                driver.WaitElementPresent(lnkSearchcontact);
                driver.ClickElement(lnkSearchcontact, "Search Contact");
                driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameContact);
                driver.SwitchToFrameByLocator(frameContact);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlCompany);
                driver.ClickElement(ddlCompany, "Company drop down");
                driver.SendKeysToElement(txtCompanySearch, newCreatedcompanyId, "Search company textbox");
                driver.sleepTime(20000);
                driver.AssertTextEqual(txtResult, searchResult);
                driver.sleepTime(2000);
                if (!driver.FindElement(ddlParentCompany).Displayed)
                {
                    By by = By.XPath("//a/span[contains(text(),'Add Filters')]");
                    driver.ClickElement(by, "Click on Add filters");
                    by = By.XPath("//div[@class='select2-drop add-filters select2-with-searchbox select2-drop-active']/div/input[@class='select2-input']");
                    driver.SendKeysToLocator(by, "Parent Company" + OpenQA.Selenium.Keys.Enter, "Choose Parent company");
                }
                driver.WaitElementPresent(ddlParentCompany);
                driver.ClickElement(ddlParentCompany, "Parent drop down");
                driver.WaitElementPresent(txtChooseCompany);
                driver.ClickElement(txtChooseCompany, "Search Parent text box");
                driver.SendKeysToElement(txtSearchcompany, newCreatedcompanyId, "Search company text");
                driver.sleepTime(15000);
                driver.AssertTextEqual(txtResult, searchResult);
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Companies Showing", "Failed to Verify Companies Showing", EngineSetup.GetScreenShotPath());
            }


        }

        public void TimeProcessSheets()
        {
            try
            {
                driver.MouseHover(lnkAccounting, "Accounting");
                driver.ClickElement(lnkProcesstimeSheets, "Process TimeSheets");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToProcesssheets", "Failed to navigate to Process Sheets", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Search Timesheets
        /// </summary>
        public void SearchTimeSheets()
        {
            try
            {
                driver.sleepTime(25000);
                driver.MouseHover(lnkAccounting, "Accounting");
                driver.ClickElement(lnkSearchtimesheets, "Search Time Sheets");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToSearchTimeSheets", "Failed to navigate to Search Time Sheets", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Search Timesheets
        /// </summary>
        public void SearchTimeSheetsBYMouseHover(string timesheetid)
        {
            try
            {
                driver.MouseHover(lnkAccounting, "Accounting");
                driver.MouseHover(lnkSearchtimesheets, "Search Time Sheets");
                driver.SendKeysToElementAndPressEnter(txtSearchTimesheets, timesheetid, "Search timesheets");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToSearchTimeSheets", "Failed to navigate to Search Time Sheets", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Mouse Hover On Add New
        /// </summary>
        public void MouseHoverOnAddNew()
        {
            try
            {
                driver.MouseHover(lnkAddnew, "Mouse Hover On Add New");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Add New", "Mouse Hover On Add New:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Mouse Hover On Match
        /// </summary>
        public void MouseHoverOnMatch()
        {
            try
            {
                driver.MouseHover(lnkMatch, "Mouse Hover On Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Match", "Mouse Hover On Match:", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Method To Click On Match
        /// </summary>
        public void ClickOnMatch()
        {
            try
            {
                driver.ClickElement(lnkMatch, "Click On Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Match", "Click On Match:", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Method To Click On Quick
        /// </summary>
        public void ClickOnQuick()
        {
            try
            {
                driver.ClickElementWithJavascript(btnQuick, "Quick");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Quick", "Failed to click on Quick:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnCandidate()
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnSearch();
                driver.ClickElement(Candidates, "Click On Candidates");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Search", "Candidate Search:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Search Candidate
        /// </summary>

        public void SearchSavedCandidate(string candidateName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framecandidate);
                driver.ClickElement(btnSearchcandidate, "SearchCandidate");
                driver.sleepTime(10000);
                driver.ClickElement(lnkSavedSearch, "Link saved search");
                driver.sleepTime(5000);
                //driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framecandidate);
                driver.SwitchToFrameByLocator(framecandidate);
                driver.WaitElementPresent(btnSaveCurrentSearch);
                driver.ClickElement(btnSaveCurrentSearch, "Button Save current search");
                driver.sleepTime(10000);
                driver.SendKeysToElement(txtSearchName, candidateName, "Search Name textbox");
                driver.WaitElementPresent(btnSaveSearch);
                driver.ClickElement(btnSaveSearch, "Save search name");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.ClickElement(btnSaveSearchHome, "Home saved search");
                driver.sleepTime(10000);
                driver.WaitElementPresent(framecandidate);
                driver.SwitchToFrameByLocator(framecandidate);
                driver.FindElements(fndSavedSearch);
                driver.AssertTextEqual(lnkCommands, "Commands");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Search", "Candidate Search:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyLoginMessage(string pageTitleInput)
        {
            try
            {
                var pageTitle = driver.GetElementText(lblLoginMessage);
                Assert.AreEqual(pageTitleInput, pageTitle);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyLoginMessage", "Failed to Verify Login Message", EngineSetup.GetScreenShotPath());
            }

        }

        #region 277151
        /// <summary>
        /// Method To Mouse Hover On Tools
        /// </summary>
        public void MouseHoverOnTools()
        {
            try
            {
                driver.MouseHover(lnkTools, "Mouse Hover On Tools");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover On Tools", "Mouse Hover On Tools:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Click On Control Panel
        /// </summary>
        public void ClickOnControlPanel()
        {
            try
            {
                driver.WaitElementPresent(lnkControlPanel);
                driver.ClickElement(lnkControlPanel, "Control Panel");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Control Panel", "Failed to click on Control Panel:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method To Click On Control Panel Modules
        /// </summary>
        public void ClickOnControlPanelModules()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAdminDefault);
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkControlPanelModules);
                driver.ClickElement(lnkControlPanelModules, "Control Panel Modules");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Control Panel Module", "Failed to click on Control Panel Module:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnControlPanelModulessecond()
        {
            try
            {
               driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.ClickElement(lnkControlPanleModule2, "Control Panel ");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Control Panel Module", "Failed to click on Control Panel Module:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Go to Control panel modules
        /// </summary>
        //public void ClickControlPanelModules()
        //{
        //    try
        //    {
        //        driver.ClickElement(logoMenu, "ImageLogo");
        //        driver.MouseHover(lnkTools, "Mouse Hover On Tools");
        //        driver.WaitElementPresent(lnkControlPanel);
        //        driver.ClickElement(lnkControlPanel, "Control Panel");
        //       driver.sleepTime(5000);10));
        //        driver.SwitchTo().DefaultContent();
        //        driver.SwitchToFrameByLocator(frameAdminDefault);
        //        driver.ClickElement(lnkControlPanelModules, "Control Panel Modules");
        //    }

        //    catch (Exception Ex)
        //    {
        //        this.TESTREPORT.LogFailure("Click On Control Panel Module", "Failed to click on Control Panel Module:", EngineSetup.GetScreenShotPath());
        //    }
        //}
        /// <summary>
        /// Verify integration patner by selecting match 
        /// </summary>
        public void VerifyIntegrationPatnerWithMatch(string req, string requirement, string type, string targetRecordType, string weight)
        {
            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.WaitElementPresent(lnkRequirementDef);
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSitemanagementRequirement);
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddRequirement);
                driver.ClickElement(btnAddRequirement, "Add Requirement");
                driver.SendKeysToElement(btnRequiremetName, requirement, "Requirement Name");
                driver.WaitElementPresent(ddlType);
                driver.ClickDropdownAndSearchText(ddlType, TypeSearch, type, "Requirement Type");
                driver.ClickDropdownAndSearchText(ddlTargetRecordType, TargetRecordSearch, targetRecordType, "Target Record Type");
                driver.SendKeysToElementAndPressEnter(txtWeight, weight, "Weight");
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlIntegrationPartner);
                driver.ClickElement(ddlIntegrationPartner, "Integration Partner");
                driver.AssertTextContains(IntegrationPartnerText, "HRNX");
                driver.SendKeysToLocator(txtSearchDropDown, "HRNX" + OpenQA.Selenium.Keys.Enter, "Integrating partner");
                driver.WaitElementPresent(ddlProvider);
                driver.ClickElement(ddlProvider, "DropDown provider");
                driver.SendKeysToLocator(txtSearchDropDown, "Wonderlic" + OpenQA.Selenium.Keys.Enter, "Provider");
                driver.WaitElementPresent(chkServices);
                driver.ClickElement(chkServices, "Services check box");
                driver.WaitElementPresent(ddlPackagesAndService);
                driver.ClickElement(ddlPackagesAndService, "Dropdown Packages");
                driver.WaitElementPresent(chkPakeges);
                driver.ClickElement(chkPakeges, "Packegae check box");
                //driver.ClickElement(ddlServices, "Dropdown Services");
                driver.WaitElementPresent(ddlPakages);
                driver.ClickElement(ddlPakages, "Dropdown Packages");
                driver.SendKeysToLocator(txtSearchDropDown, "2-All Jobs" + OpenQA.Selenium.Keys.Enter, "Packages");
                driver.WaitElementPresent(btnSaveRequirement);
                driver.ClickElement(btnSaveRequirement, "Save");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Integration Patner With Match", "Failed Verify Integration Patner With Match:", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Verify Image Manager Present
        /// </summary>
        public void VerifyImageManagerPresent(string req)
        {

            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Email and Notes Template");
                driver.WaitElementPresent(lnkEmailNotes);
                driver.ClickElement(lnkEmailNotes, "Email & Notes");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSiteEmail);
                driver.SwitchToFrameByLocator(frameSiteEmail);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.WaitElementPresent(btnEditEmail);
                driver.ClickElement(btnEditEmail, "Button Edit Email");
                //driver.sleepTime(30000);
                driver.ElementPresent(btnImageManager, "Image Manager");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Image Manager Present", "Failed Verify Image Manager Present:", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Add New Requirement for match
        /// </summary>
        public void AddNewRequirementForMatch(string req, string requirement, string type, string targetRecordType, string weight)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                //driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.ClickElement(btnAddRequirement, "Add Requirement");
                driver.SendKeysToElement(btnRequiremetName, requirement, "Requirement Name");
                driver.ClickDropdownAndSearchText(ddlType, TypeSearch, type, "Requirement Type");
                driver.ClickDropdownAndSearchText(ddlTargetRecordType, TargetRecordSearch, targetRecordType, "Target Record Type");
                driver.SendKeysToElementClearFirst(txtWeight, weight, "Weight");
                driver.ClickElement(ddlIntegrationPartner, "Integration Partner");
                driver.AssertTextContains(IntegrationPartnerText, "HRNX");
                driver.SendKeysToLocator(txtSearchDropDown, "HRNX" + OpenQA.Selenium.Keys.Enter, "Integrating partner");

            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddNewRequirement For Match", "Failed AddNewRequirement For Match:", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Method to Click on Requirement Definition
        /// </summary>
        public string AddNewRequirement(string req, string type, string target, string weight)
        {
            Random r = new Random();
            int num = r.Next(10000);
            string name = "Test" + num;
            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddRequirement);
                driver.ClickElement(btnAddRequirement, "Add Requirement");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtEnterName);
                driver.SendKeysToElementWithJavascript(txtEnterName, name, "Enter Requirement Name");
                driver.sleepTime(2000);
                driver.WaitElementPresent(ddntype);
                driver.ClickElement(ddntype, "Type");
                driver.WaitElementPresent(txttype);
                driver.SendKeysToElementAndPressEnter(txttype, type, "Type");
                driver.sleepTime(2000);
                //driver.WaitElementPresent(ddntarget);
                driver.ClickElement(ddntarget, "Target Type");
                driver.WaitElementPresent(txttarget);
                driver.SendKeysToElementAndPressEnter(txttarget, target, "Type");
                driver.WaitElementPresent(txtWeight);
                driver.SendKeysToElementClearFirst(txtWeight, weight, "Weight");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add a new requirement", "Failed to Add a new requirement:", EngineSetup.GetScreenShotPath());
            }
            return name;
        }
        /// <summary>
        /// Adding new requirement for the company
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public string AddRequirementForCompany(string req,string type,string targetType,string weight)
        {
            Random r = new Random();
            int num = r.Next(10000);
            string name = "Test" + num;
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.sleepTime(5000);
                driver.ClickElementWithJavascript(btnAddRequirement, "Add Requirement");
                driver.WaitElementPresent(txtEnterName);
                driver.SendKeysToElementWithJavascript(txtEnterName, name, "Enter Requirement Name");
                driver.WaitElementPresent(ddntype);
                driver.ClickElement(ddntype, "Type");
                driver.SendKeysToElementAndPressEnter(txttype, type, "Type");
                driver.WaitElementPresent(ddntarget);
                driver.ClickElement(ddntarget, "Target Type");
                driver.SendKeysToElementAndPressEnter(txttarget, targetType, "Type");
                driver.SendKeysToElementClearFirst(txtWeight, weight, "Weight");
                driver.WaitElementPresent(chkFullPlacement);
                driver.ClickElement(chkFullPlacement, "Chkbox full placement");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(2000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddRequirement For Company", "Failed AddRequirement For Company:", EngineSetup.GetScreenShotPath());
            }
            return name;
        }
       /// <summary>
        /// Verify position type edit
        /// </summary>
        public void VerifyPositiontypeEdit(string positionType, string errorMsg)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, positionType, "Position Type");
                driver.WaitElementPresent(lnkPositionType);
                driver.ClickElement(lnkPositionType, "Position Type");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAdminSiteMnagePosition);
                driver.SwitchToFrameByLocator(frameAdminSiteMnagePosition);
                driver.WaitElementPresent(btnPositiontypeEdit);
                driver.ClickElement(btnPositiontypeEdit, "Position Edit");
                driver.WaitElementPresent(chkCorp1Deselect);
                driver.ClickElement(chkCorp1Deselect, "Corp1 checkbox");
                driver.WaitElementPresent(btnPositionSave);
                driver.ClickElement(btnPositionSave, "save Position");
                driver.sleepTime(5000);
                driver.AssertTextEqual(txtAreaErrorMsg, errorMsg);
                driver.WaitElementPresent(chkCorp1Deselect);
                driver.ClickElement(chkCorp1Deselect, "Corp1 checkbox");
                driver.WaitElementPresent(btnPositionSave);
                driver.ClickElement(btnPositionSave, "save Position");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();

            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Positiontype Edit", "Failed to Verify Positiontype Edit:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// To verify the Requirement
        /// </summary>
        public void VerifyRequirement(string req, string filterName)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");                               driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(txtFiltername);
                driver.SendKeysToElement(txtFiltername, filterName, "Requirement Name");
                driver.sleepTime(5000);
                driver.ClickElement(btnAdd, "Add button");
                driver.sleepTime(5000);
                driver.ClickElementWithJavascript(btnEdit, "Edit button");
                driver.VerifyWebElementDisabled(btnDeleteRequirement, "Delete Requirement");
                driver.SwitchToDefaultFrame();
            }
            catch (Exception Ex)
            {

                this.TESTREPORT.LogFailure("Verify requirement shared with other records", "Failed verify requirement shared with other records:Exception" + Ex.Message, EngineSetup.GetScreenShotPath());

            }
        }

        /// <summary>
        /// To Verify Integration Partner under integration
        /// </summary>
        public void VerifyIntegrationPartner(string req, string requirement, string type, string targetRecordType)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                //driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.ClickElement(btnAddRequirement, "Add Requirement");
                driver.SendKeysToElement(btnRequiremetName, requirement, "Requirement Name");
                driver.ClickDropdownAndSearchText(ddlType, TypeSearch, type, "Requirement Type");
                driver.ClickDropdownAndSearchText(ddlTargetRecordType, TargetRecordSearch, targetRecordType, "Target Record Type");
                driver.ClickElement(ddlIntegrationPartner, "Integration Partner");
                driver.AssertTextContains(IntegrationPartnerText, "HRNX");
                driver.SendKeysToLocator(txtSearchDropDown, "HRNX" + OpenQA.Selenium.Keys.Enter, "Integrating partner");
                driver.ClickElement(btnSaveRequirement, "Save");
                driver.sleepTime(20000);
                driver.WaitForElement(requirementData, TimeSpan.FromSeconds(60));
                driver.SendKeysToElementOneAtATime(tbfilterName, requirement, "Filter Name");
                //driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.AssertTextContains(requirementData, requirement);

            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Verify requirement shared with other records", "Failed verify requirement shared with other records:Exception" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Verify smart forms
        /// </summary>
        public void VerifySmartForms(string reqruiter, string smartForm, String loginName)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, reqruiter, "Recruiter");
                driver.ClickElement(lnkRecruiter, "Recruiter");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAdminManageRecruiter);
                driver.ClickElement(btnExpandSandbox, "SandBox");
                driver.WaitElementPresent(txtSearchAdminRecruiter);
                driver.SendKeysToElement(txtSearchAdminRecruiter, loginName, "LoginRecruiter");
                driver.ClickElement(lnkAdminRecruiter, "Link Admin Recruiter");               
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameReqruiterManage);
                driver.WaitElementPresent(tabPermission);
                driver.ClickElement(tabPermission, "Permission Tab");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameReqruiterManage);
                driver.SwitchToFrameByLocator(framePermissions);
                driver.ClickElement(ddlAddPermission, "Drop down Select permission");
                driver.SendKeysToElementAndPressEnter(ddlAddPermission, smartForm, "SmartForms");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify SmartForms", "Failed verify smartForms:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }


        }
        /// <summary>
        /// Search and Edit SmartForms
        /// </summary>
        public void SearchAndEditSmartForms(String smartFormtxt)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, smartFormtxt, "Smart Forms");
                driver.ClickElement(lnkSmartForm, "Smart Forms");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameAdminSite);
                driver.ClickElement(btnEditSmartForm, "Click Edit button");
                driver.sleepTime(25000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameClientPageIndex);
                driver.AssertTextEqual(txtactualTxt, "Design a Form");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search And Edit SmartForms", "Failed Search And Edit SmartForms:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Verify smart form without permission
        /// </summary>
        /// <param name="reqruiter"></param>
        /// <param name="loginName"></param>

        public void VerifySmartFormswithoutPermission(string reqruiter, String loginName)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, reqruiter, "Recruiter");
                driver.ClickElement(lnkRecruiter, "Recruiter");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAdminManageRecruiter);
                driver.SwitchToFrameByLocator(frameAdminManageRecruiter);
                driver.WaitElementPresent(btnExpandSandbox);
                driver.ClickElement(btnExpandSandbox, "SandBox");
                driver.SendKeysToElement(txtSearchAdminRecruiter, loginName, "LoginRecruiter");
                driver.WaitElementPresent(lnkAdminRecruiter);
                driver.ClickElement(lnkAdminRecruiter, "Link Admin Recruiter");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameReqruiterManage);
                driver.SwitchToFrameByLocator(frameReqruiterManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(tabPermission);
                driver.ClickElement(tabPermission, "Permission Tab");
                driver.WaitElementPresent(framePermissions);
                driver.SwitchToFrameByLocator(framePermissions);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnDeleteSmaertForm);
                driver.ClickElement(btnDeleteSmaertForm, "Delete Smart Forms");
                driver.sleepTime(15000);
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify SmartForms without Permission", "Failed Verify SmartForms without Permission:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Verify Smart forms able to edit
        /// </summary>
        public void VerifySmartFormAbleToEdit()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                driver.WaitElementPresent(lnkManagesmartForm);
                driver.ClickElement(lnkManagesmartForm, "Manage samrt form ");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAdminSite);
                driver.SwitchToFrameByLocator(frameAdminSite);
                driver.WaitElementPresent(btnEditSmartForm);
                driver.ClickElement(btnEditSmartForm, "Edit Smart Forms");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameClientIndex);
                driver.SwitchToFrameByLocator(frameClientIndex);
                driver.sleepTime(5000);
                driver.AssertTextEqual(txtErrorMessage, "You don't have permission to view/edit Smart Form");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify SmartForm able to edit", "Failed Verify SmartForm able to edit:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Check boolean in education history
        /// </summary>
        public void checkBooleanInEducationHistory()
        {
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.ClickElement(btnEduHistory, "EditEducationHistory");
            string chkStatus = driver.GetElementAttribute(chkCustomFieldEduHistory, "checked");
            driver.ClickElement(chkCustomFieldEduHistory, "Check box custom field");
            driver.ClickElement(btnsaveEduHistory, "Save History");
            driver.sleepTime(10000);
            PositionSchedulingPage ps = new PositionSchedulingPage();
            ps.RightClickOnEducationHistory();
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.ClickElement(btnEduHistory, "EditEducationHistory");
            string newStatus = driver.GetElementAttribute(chkCustomFieldEduHistory, "checked");
            if (chkStatus == null)
            {
                Assert.IsTrue(newStatus.Equals("true"), "Boolean Custom field on the Education history record is updated");
            }
            else
            {
                // var checkValue = newStatus.Equals("null");
                Assert.IsNull(newStatus, "Boolean Custom field on the Education history record is not updated");
            }
        }
        /// <summary>
        /// Check boolean in work history
        /// </summary>
        public void checkBooleanInWorkHistory()
        {
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.ClickElement(btnEditWorkHistory, "Edit Work History");
            // driver.ScrollToPageBottom();
            string chkStatus = driver.GetElementAttribute(chkCustomFiledWorkHistory, "checked");
            driver.ClickElement(chkCustomFiledWorkHistory, "Check box custom field");
            driver.ClickElement(btnSaveWorkHistory, "Save History");
            driver.sleepTime(10000);
            PositionSchedulingPage ps = new PositionSchedulingPage();
            ps.RighClickWorkHistoryWithoutMaximize();
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.ClickElement(btnEditWorkHistory, "EditEducationHistory");
            bool newStatus = Convert.ToBoolean(driver.GetElementAttribute(chkCustomFiledWorkHistory, "checked"));
            if (Convert.ToBoolean(chkStatus) == false)
            {
                Assert.IsTrue(newStatus, "Boolean Custom field on the work history record is not updated");
            }
            else
            {
                Assert.IsFalse(newStatus, "Boolean Custom field on the work history record is updated");
            }
        }

        /// Give smart form permissions to login recruiter
        /// </summary>
        public void GiveSmartFormPermission()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                driver.WaitElementPresent(lnkManageRecruiter);
                driver.ClickElement(lnkManageRecruiter, "Manage samrt form ");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameReqruiterManage);
                driver.SwitchToFrameByLocator(frameReqruiterManage);
                driver.WaitElementPresent(framePermissions);
                driver.SwitchToFrameByLocator(framePermissions);
                driver.ClickElement(btnDeleteSmaertForm, "Delete Smart Forms");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure(" Give SmartForm Permission", "Failed to give smartform Permission:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }


        }

        /// <summary>
        /// Search smart form
        /// </summary>
        /// <param name="smartFormtxt"></param>
        public void SearchSmartForms(String smartFormtxt)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, smartFormtxt, "Smart Forms");
                driver.WaitElementPresent(lnkSmartForm);
                driver.ClickElement(lnkSmartForm, "Smart Forms");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify search smart forms", "Failed Verify search smart forms:Exception" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }

        public void RightClickOnReqAndValidate(string newCustomField, string addValue)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                var lnkRequirement = driver.FindElement(lnkrequirements);
                driver.ScrollPage();
                Actions act = new Actions(driver);
                act.ContextClick(lnkRequirement).Build().Perform();
                driver.WaitElementPresent(lnkAudit);
                driver.ClickElement(lnkAudit, "Click on Audit to edit");
                driver.sleepTime(10000);
                By lblCustomField = By.XPath(string.Format("//span[contains(text(),'{0}')]", newCustomField));
                driver.WaitElementPresent(lblCustomField);
                driver.CheckElementExists(lblCustomField, "New CustomField");
                By ddlNewCusField = By.XPath(string.Format("//div[contains(@id,'{0}')]//input", newCustomField));
                driver.WaitElementPresent(ddlNewCusField);
                driver.ClickElement(ddlNewCusField, "dropdown NewCustomFiled");
                By chkboxCustomFieldValue = By.XPath(string.Format("//label[contains(text(),'{0}')]/input", addValue));
                driver.WaitElementPresent(chkboxCustomFieldValue);
                driver.ClickElement(chkboxCustomFieldValue, "CustomFieldValue");
                driver.WaitElementPresent(btnSaveNewCustField);
                driver.ClickElement(btnSaveNewCustField, "Save");
                driver.WaitElementPresent(lnkAudit);
                driver.ClickElement(lnkAudit, "Click on Audit to edit");
                //driver.ClickElement(btnEditDetails, "Edit Details");
                driver.sleepTime(10000);
                var ddlNewCustomField = driver.FindElement(By.XPath(string.Format("//span[contains(text(),'{0}')]/..//following-sibling::select/option", newCustomField)));
                string txt = ddlNewCustomField.GetAttribute("label");
                if (txt.Contains(addValue))
                {
                    this.TESTREPORT.LogSuccess("Verify value added to drop down", "Selected custom field value verified successfully");
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify value added to drop down", "Selected custom field value Failed to verify", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Right Click On ReqAndValidate", " Faild to Right Click On Requirement And Validate", EngineSetup.GetScreenShotPath());
            }

        }
        public void RightClickOnRequirementAndChangeStatus()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                var lnkRequirement = driver.FindElement(lnkrequirements);
                driver.ScrollPage();
                Actions act = new Actions(driver);
                act.ContextClick(lnkRequirement).Build().Perform();
                driver.sleepTime(15000);
                //driver.MouseHover(btnThreeSlashs, "Mouse Hover on Requirement");
                //driver.ClickElement(btnConfirm, "Confirm");
                //driver.sleepTime(10000);
                driver.ClickElement(btnCloseReq, "Close button");
             }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("RightClick On Requirement AndChange Status", " Faild Right Click On Requirement And ChangeStatus", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify CustomField is added to the requirement page
        /// </summary>
        /// <param name="customFeild"></param>
        /// <param name="newCustomField"></param>
        /// <param name="customType"></param>
        /// <param name="customDataType"></param>
        public void VerifyCustomfieldsIsAdded(string customFeild, string newCustomField, string customType, string customDataType, string addValue)
        {
            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, customFeild, "BusinessList");
                driver.WaitElementPresent(lnkCustomfield);
                driver.ClickElement(lnkCustomfield, "Custom Feild");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeManageFields);
                driver.SwitchToFrameByLocator(iframeManageFields);
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtNewCustomField);
                driver.SendKeysToElement(txtNewCustomField, newCustomField, "New Custom Field");
                driver.WaitElementPresent(ddlCustomFieldType);
                driver.ClickElement(ddlCustomFieldType, "CustomField Type");
                driver.WaitElementPresent(chkDropRequirement);
                driver.ClickElement(chkDropRequirement, "Requirement Type");
                //driver.ClickElement(ddlRequirement, "Requirement dropdown");
                //driver.ClickElement(chkRequirement, "CheckBox of requirement");
                driver.WaitElementPresent(chkAllRequirement);
                driver.ClickElement(chkAllRequirement, "Drop Down Requirement");
                //driver.ClickElement(chkRequirement, "Check box requirement");
                driver.WaitElementPresent(ddlCustomFieldDatatype);
                driver.ClickElementAndSendKeys(ddlCustomFieldDatatype, customDataType, "Custom Field DataType");
                driver.WaitElementPresent(btnAddField);
                driver.ClickElement(btnAddField, "Add custom field button");
                driver.sleepTime(5000);
                By btnEditField = By.XPath("//td[contains(text(),'" + newCustomField + "')]/..//input[@title='Edit']");
                driver.WaitElementPresent(btnEditField);
                driver.ClickElement(btnEditField, "Edit field");
                driver.WaitElementPresent(txtAddValue);
                driver.SendKeysToElement(txtAddValue, addValue, "Add Value ");
                driver.WaitElementPresent(btnAddValue);
                driver.ClickElement(btnAddValue, "Button to add value");
                driver.WaitElementPresent(btnSaveValue);
                driver.ClickElement(btnSaveValue, "Save value to requirement");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception Ex)
            {

                this.TESTREPORT.LogFailure("Verify Custom Field", "Failed to verify custom field is added", EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// Edit Requirement
        /// </summary>
        /// <param name="requirementDefinition"></param>
        /// <param name="requirementname"></param>
        /// <param name="weight"></param>
        /// <param name="expirationDays"></param>
        /// <param name="message"></param>
        /// <param name="assertion"></param>
        public void EditRequirement(string requirementDefinition, string weight, string expirationDays, string editRequirementName, bool message = false, bool assertion = false)
        {
            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, requirementDefinition, "Requirement Definition");
                driver.WaitElementPresent(lnkRequirementDef);
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]"));
                driver.WaitElementPresent(txtFiltername);
                driver.sleepTime(25000);
                driver.SendKeysToElementWithJavascript(txtFiltername, editRequirementName, "Requirement Name");
                driver.ClickElement(btnEdit, "Edit button");
                driver.sleepTime(10000);
                //driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(txtWeight);
                driver.SendKeysToElementClearFirst(txtWeight, weight, "Weight");
                if (message)
                {
                    driver.ClickElementAndSendKeys(txtExpirationWarningDays, expirationDays, "Expiration warning days");
                }
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(10000);
                if (assertion)
                {
                    driver.WaitElementPresent(warningMessage);
                    driver.AssertTextEqual(warningMessage, "Expiration warning days cannot be greater than 365");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add a new requirement", "Failed to Add a new requirement:", EngineSetup.GetScreenShotPath());
            }

        }

        #region 277141
        public void CreateMatch(string position, string candidate)
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnAddNew();
                MouseHoverOnMatch();
                ClickOnQuick();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framematch);
                driver.SwitchToFrameByLocator(framematch);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(position);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                //   driver.SendKeysToElementAndPressEnter(txtEnterPosition, position, "Enter position");
                driver.sleepTime(5000);
                driver.AcceptAlert();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNext);
               // driver.AcceptAlert();
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCandidates);
                driver.SendKeysToElementAndPressEnter(txtCandidates, candidate, "Candidate Name");
                
                //driver.FindElement(txtCandidates).SendKeys(Keys.Enter);
                driver.WaitElementPresent(btnCandidatesNext);
                driver.ClickElement(btnCandidatesNext, "Candidate Next Button");
                
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.sleepTime(5000);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Quick Match", "Failed to create a match:", EngineSetup.GetScreenShotPath());
            }
        }
        #endregion

        #endregion

        public void SearchPosition(string positionID)
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnSearch();
                driver.MouseHover(Position, "Mouse Hover On Position");
                driver.SendKeysToElementAndPressEnter(txtPositionNameorID, positionID, "Position name");
                driver.sleepTime(30000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Position Search", "Position Search:", EngineSetup.GetScreenShotPath());
            }
        }


        public void NavigateToAddPosition()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(logoMenu);
                driver.ClickElement(logoMenu, "Click on ImageLogo Menu");
                driver.MouseHover(lnkAddnew, "Add New");
                driver.MouseHover(lnkPosition, "Position");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickAddPosition()
        {
            try
            {
                driver.ClickElement(lnkPosition, "Position");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click Add Position", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddPositionTitle()
        {
            try
            {
                driver.IsElementPresent(ttlAddNewPosition);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyAddPositionTitle", "Failed to Verify Add Position Title:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnSimple()
        {
            try
            {
                driver.ClickElement(lnkSimple, "Click Simple Button");
                driver.WaitForPageLoad(TimeSpan.MaxValue);
                // driver.VerifyWebElementPresent(ttlAddNewPosition,"Add New Position");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnSimple", "Failed to Click On Simple:", EngineSetup.GetScreenShotPath());
            }
        }

        #region 277171
        public void AddTimesheet()
        {
            try
            {
                //TimeSheet timesheet = new TimeSheet();
                //string MatchId=timesheet.GenerateContractMatchId();
                ClickOnLogoMenu();
                MouseHoverOnAccounting();
                MouseHoverOnCreateTimesheet();
                ClickOnOneTimesheet();
                driver.SwitchToFrameByIndex(1);
                driver.ClickElement(ddnMatch, "Match");
                driver.SendKeysToElementAndPressEnter(txtMatch, "1270502", "Enter Match ID");
                Thread.Sleep(2000);
                driver.ClickElement(ddnPeriod, "Period");
                driver.SendKeysToElementAndPressEnter(txtPeriod, "9/11/2017 - 9/17/2017", "Enter Period Range");
                Thread.Sleep(2000);
                driver.ClickElement(btnCreate, "Create");
                if (driver.FindElements(By.XPath("//div[@class='messaging-container']/div")).Count > 0)
                {
                    Console.WriteLine("Timesheet is created");
                }
                GetTimesheetID();

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Timesheet", "Failed to Add Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        public void GetTimesheetID()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                string id = utility.GetTitleId();
                ClickOnLogoMenu();
                MouseHoverOnAccounting();
                ClickOnSearchTimesheet();
                driver.SwitchToFrameByLocator(By.XPath("//iframe[@src='..//Search/timesheet/']"));
                driver.ClickElement(ddnAddfilters, "Add filters");
                driver.SendKeysToElementAndPressEnter(txtTimesheetinput, "Timesheet ID", "Timesheet ID");
                driver.ClickElement(ddnTimesheet, "Timesheet");
                driver.SendKeysToElementAndPressEnter(txtTimesheet, id, "Timesheet ID");
                Thread.Sleep(2000);
                driver.ClickElement(btnSearch, "Search");
                driver.ClickElement(chkboxTimesheet, "checkbox");
                driver.ClickElement(txtDelete, "Delete Icon");
                Thread.Sleep(2000);
                driver.ClickElement(btnDelete, "Delete Button");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Get Timesheet ID", "Failed to Get Timesheet ID:", EngineSetup.GetScreenShotPath());
            }
        }

        #endregion

        public void ClickOnRequirement()
        {
            try
            {
                driver.WaitElementPresent(lnkRequirements);
                driver.ClickElement(lnkRequirements, "Click On Requirement");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Requirement", "Failed to Click On Requirement:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnSearchButton()
        {
            try
            {
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Search");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Search Button", "Failed to Click On Search Button:", EngineSetup.GetScreenShotPath());
            }
        }

        public void SearchRequirement()
        {
            try
            {
                ClickOnLogoMenu();
                MouseHoverOnSearch();
                ClickOnRequirement();
                driver.SwitchToFrameByIndex(1);
                ClickOnSearchButton();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Requirement", "Failed to Search Requirement:", EngineSetup.GetScreenShotPath());
            }
        }

        public void SearchRequirementPage(string searchRequirement)
        {
            try
            {
                MouseHoverOnSearch();
                ClickOnRequirement();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'objectrequirement')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'objectrequirement')]"));
                driver.sleepTime(20000);
                driver.WaitElementPresent(btnRequirements);
                driver.ClickElement(btnRequirements, "Requirements");
                driver.sleepTime(2000);
                driver.SendKeysToElement(txtRequirements, searchRequirement, "Search Requirements");
                driver.sleepTime(2000);
                driver.SendKeysToElement(txtRequirements, OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(5000);
                ClickOnSearchButton();
                driver.WaitElementPresent(chkSelectRequirement1);
                driver.ClickElement(chkSelectRequirement1, "First Req");
                driver.WaitElementPresent(chkSelectRequirement2);
                driver.ClickElement(chkSelectRequirement2, "Sec Req");
                //driver.WaitElementPresent(framreObjectRequirement);
                //driver.SwitchToFrameByLocator(framreObjectRequirement);
                driver.sleepTime(1000);
                driver.WaitElementPresent(lnkExportToExcel);
                driver.ClickElement(lnkExportToExcel, "Link Export Selected To Excel");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Requirement Page", "Failed to Search Requirement:", EngineSetup.GetScreenShotPath());
            }
        }

        public void SearchWithInvalidID(string candidateId)
        {
            try
            {
                driver.MouseHover(Candidates, "Mouse Hover On Candidates");
                driver.SendKeysToElementAndPressEnter(txtCandidateName, candidateId, "Position name");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search With Invalid ID", "Search With Invalid ID:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtCurrentPwd, currentPassword, "Enter Current Password");
                driver.SendKeysToElementClearFirst(txtNewPwd, newPassword, "Enter New Password");
                driver.SendKeysToElementClearFirst(txtConfirmPwd, newPassword, "Confirm New password");
                driver.WaitElementExistsAndVisible(btnChangePassword);
                driver.ClickElement(btnChangePassword, "Click Change Password");
                driver.sleepTime(20000);
                if (driver.ElementPresent(hdPageTitle, "Page Title"))
                {
                    this.TESTREPORT.LogSuccess("Change Password", "Changed Password successfully");
                }
                else
                {
                    this.TESTREPORT.LogFailure("Change Password", "Change Password id is not successfull:");
                }

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Change Password", "Change Password id not successfully", EngineSetup.GetScreenShotPath());
            }

        }


        public void ClickOnFilteredCandidate(string candidateName, bool candidate = false)
        {
            try
            {
                driver.sleepTime(5000);
                if (candidate)
                {
                    driver.SwitchToDefaultFrame();
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(frameCandidateQuick);
                    driver.SwitchToFrameByLocator(frameCandidateQuick);
                }
                By ddlFirstNameFilter = By.XPath("//div[@class='TextFilter Display']/label[text()='First Name:']");
                driver.WaitElementPresent(ddlFirstNameFilter);
                driver.ClickElement(ddlFirstNameFilter, "Click on First Name Filter");
                By txtFilter = By.XPath("//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");
                driver.SendKeysToElementAndPressEnter(txtFilter, candidateName, "Search First Name field");
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Click Search");
                By by = By.XPath(string.Format("//div/a[contains(text(),'{0}')]", candidateName));
                driver.WaitElementPresent(by);
                driver.ClickElementWithJavascript(by, "Click Candidate Name");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Filtered Candidate", "Click On Filtered Candidate is not successfully:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyCandidateStatus(string status, By Xpath)
        {
            try
            {
                driver.ClickElement(lblRequirements, "Requirements");
                driver.sleepTime(20000);
                driver.WaitElementPresent(By.XPath("//h1[text()='Search Requirements']"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[@src='..//Search/objectrequirement/']"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[@src='..//Search/objectrequirement/']"));
                driver.sleepTime(15000);
                if (driver.FindElements(By.XPath("//div[@class='status-filter Display']//span[text()='Candidate Status']")).Count > 0)
                {
                    Console.WriteLine("Type filter exist");
                }
                else
                {
                    driver.WaitElementPresent(ddnAddfilters);
                    driver.ClickElement(ddnAddfilters, "Add filters");
                    driver.WaitElementPresent(txtTimesheetinput);
                    driver.SendKeysToElementAndPressEnter(txtTimesheetinput, status, "Candidate Status");
                    driver.WaitElementPresent(Xpath);
                    driver.ClickElement(Xpath, "Candidate Status");
                    driver.sleepTime(5000);
                    driver.ClickElement(btnSearch, "Search");
                    driver.sleepTime(5000);
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Candidate Status", "Verify Candidate Status:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyCandidateFilterStatus(string status)
        {
            VerifyCandidateStatus(status, ddnCandidateStatus);
        }

        public void VerifyActiveMatchStatus(string status)
        {
            VerifyCandidateStatus(status, ddnActiveMatch);
        }

        public void SearchOpportunity(string ID)
        {
            try
            {
                driver.MouseHover(lnkOpportunities, "Opportunities");
                driver.SendKeysToElementAndPressEnter(txtinputOpportunities, ID, "Opportunity ID");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Opportunity", "Search Opportunity is not successfull:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnOpportunities()
        {
            try
            {
                driver.ClickElement(lnkOpportunities, "Click On Opportunities");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Opportunities", "Failed to Click On Opportunities:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyFilter(string status, By Xpath, By Object)
        {
            try
            {
                driver.sleepTime(20000);
                driver.WaitElementPresent(searchFrame);
                driver.SwitchToFrameByLocator(searchFrame);
                driver.sleepTime(5000);
                if (driver.FindElements(Object).Count > 0)
                {
                    Console.WriteLine("Type filter exist");
                }
                else
                {
                    driver.ClickElement(ddnAddfilters, "Add filters");
                    driver.WaitElementPresent(txtTimesheetinput);
                    driver.SendKeysToElementAndPressEnter(txtTimesheetinput, status, "Candidate Status");
                    driver.sleepTime(3000);
                    driver.ClickElement(Xpath, "Types filter");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Filter Status", "Verify Filter Status:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyTypesFilter(string status)
        {
            VerifyFilter(status, ddnTypes, lbltypes);
        }
        public void VerifyStagesFilter(string status)
        {
            VerifyFilter(status, ddnStages, lblstages);
        }
        public void ClickOnCustomrules()
        {
            try
            {
                driver.WaitElementPresent(lnkCustomrules);
                driver.ClickElement(lnkCustomrules, "Custom Rules");
                driver.sleepTime(30000);
                driver.SwitchToFrameByLocator(frameAdminManage);
                // driver.ClickElement(btnInitializePage, "Initialize Page");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Customrules", "Failed to Click On Customrules link", EngineSetup.GetScreenShotPath());
            }
        }

        #endregion

        #region AddCandidateApplication

        public void ClickOnCandidateApplication()
        {
            try
            {
                driver.WaitElementPresent(lnkCandidateApplications);
                driver.ClickElement(lnkCandidateApplications, "Candidate Applications");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Candidate Applications", "Click On Candidate Applications:", EngineSetup.GetScreenShotPath());
            }

        }

        #endregion

        public void NavigateAndClickCandidateApplication()
        {
            driver.SwitchToDefaultFrame();
            driver.VerifyWebElementPresent(logoMenu, "ImageLogo Menu");
            driver.ClickElement(logoMenu, "Click on ImageLogo Menu");
            driver.MouseHover(lnkAddnew, "Add New");
            driver.VerifyWebElementPresent(lnkCandidateApplications, "Candidate Applications");
            driver.MouseHover(lnkCandidateApplications, "Candidate Applications");
            driver.WaitElementPresent(lnkCandidateApplications);
            driver.ClickElement(lnkCandidateApplications, "Click Candidate Applications");
        }

        public void HandleAlert()
        {
            try
            {
                driver.WaitForPageLoad(TimeSpan.MaxValue);
                if (driver.isAlertPresent())
                {
                    IAlert devAlert = driver.SwitchTo().Alert();
                    devAlert.Accept();
                }
                else
                {
                    Console.WriteLine("There are no more alerts opened");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Handle Alert", "Failed to Handle Alert:", EngineSetup.GetScreenShotPath());
            }
        }

        public void NavigateToNewSeed()
        {
            try
            {
                driver.VerifyWebElementPresent(logoMenu, "ImageLogo Menu");
                driver.WaitElementPresent(logoMenu);
                driver.ClickElement(logoMenu, "Click on ImageLogo Menu");
                driver.MouseHover(lnkAddnew, "Add New");
                driver.VerifyWebElementPresent(lnkSeed, "Seed");
                driver.MouseHover(lnkSeed, "Seed");
                driver.WaitElementPresent(lnkSeed);
                driver.ClickElement(lnkSeed, "Click on Seed");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Navigate to New Seed", "Failed to Navigate New Seed", EngineSetup.GetScreenShotPath());
            }
        }

        public void LoginWithInValidCredentials(string url, string emailid, string pwd)
        {
            try
            {
                driver.Navigate().GoToUrl("about:blank");
                driver.Navigate().GoToUrl(url);
                if (driver.ElementPresent(txtEmail, "Login") && driver.ElementPresent(txtPassword, "Password"))
                {
                    this.TESTREPORT.LogSuccess("Verify Erecurit Login Page", String.Format("Able to view Erecurit Login Page with the : <mark>{0}</mark> successfully", url));
                }
                driver.SendKeysToElementClearFirst(txtEmail, emailid, "email");
                driver.SendKeysToElementClearFirst(txtPassword, pwd, "password");
                driver.ClickElement(btnLogin, "Login Button");
                if (driver.ElementPresent(errorMessage, "Error Message"))
                {
                    this.TESTREPORT.LogSuccess("Verify Erecurit Login Page Credentials", String.Format("Able to get error message \"Your login attempt was not successful. Please try again\" successfully on passing invalid credentials : LoginID <Mark>{0}</Mark> , Password <Mark>{1}</Mark>", emailid, pwd));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Erecurit Login Page Credentials", String.Format("Not able to get any error message on passing invalid credentials : LoginID <Mark>{0}</Mark> , Password <Mark>{1}</Mark>", emailid, pwd));
                }
                driver.ClickElement(btnClose, "Close the error message");


            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Erecurit Login Page Credentials", "Failed to navigate to url:" + url, EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAgreement()
        {
            try
            {
                driver.ClickElement(lnkAgreement, "Click on Agreement");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Agreement", "Failed to click on Agreement", EngineSetup.GetScreenShotPath());
            }
        }
        public void RefreshCurrentPage()
        {
            driver.Navigate().Refresh();
        }
        public void VerifyLogin()
        {
            try
            {
                driver.IsWebElementDisplayed(lblErecruit);
                this.TESTREPORT.LogSuccess("Verify Login", "User is logged in successfully");
            }
            catch (Exception EX)
            {
                this.TESTREPORT.LogFailure("Verify Login", "Failed to Verify Login", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnSavedSearches()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkSavedSearches);
                driver.ClickElement(lnkSavedSearches, "Saved Searches");
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Saved Searches", "Failed to Click On Saved Searches", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnCandidatesLink()
        {
            driver.WaitElementPresent(lnkCandidates);
            driver.ClickElement(lnkCandidates, "Candidates");
        }
        public void ClickOnCandidateQP(string candidateID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(20000);
                driver.WaitElementPresent(newframeCandidateSearch);
                driver.SwitchToFrameByLocator(newframeCandidateSearch);
                driver.sleepTime(5000);
                By ddlIDFilter = By.XPath("//div[@class='TextFilter Display']/label[text()='ID:']");
                driver.ClickElement(ddlIDFilter, "Click on ID Filter");
                By txtFilter = By.XPath("//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");
                driver.SendKeysToElementAndPressEnter(txtFilter, candidateID, "Search First Name field");
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Search");
                driver.sleepTime(20000);
                var candidateRec = driver.FindElement(By.XPath(string.Format("//a[contains(text(),'{0}')]",candidateID)));
                Actions act = new Actions(driver);
                act.ContextClick(candidateRec).Build().Perform();
                driver.sleepTime(15000);
                driver.WaitElementPresent(btnNewQP);
                driver.ClickElement(btnNewQP, "Quick Placement");
                driver.sleepTime(5000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Candidate QP", "Failed to Click On Candidate QP", EngineSetup.GetScreenShotPath());
            }
        }
        public void SearchCandidateApplications()
        {
            driver.WaitElementPresent(CandidateApplications);
            driver.ClickElement(CandidateApplications, "Candidate Applications");

        }
        public void ClickOnContactQP()
        {
            driver.SwitchToDefaultFrame();
            driver.WaitElementPresent(frameContact);
            driver.SwitchToFrameByLocator(frameContact);
            driver.WaitElementPresent(btnContactQP);
            driver.ClickElement(btnContactQP, "Quick Placement");
        }

        public void ClickOnCompanyQP()
        {
            driver.SwitchToDefaultFrame();
            driver.WaitElementPresent(frameManage);
            driver.SwitchToFrameByLocator(frameManage);
            driver.WaitElementPresent(btnContactQP);
            driver.ClickElement(btnContactQP, "Quick Placement");
        }
        
        public void ClickOnCreateMatch()
        {
            driver.WaitElementPresent(btnSearch);
            driver.ClickElement(btnSearch, "Search");
            ////input[@data-helptip='SearchColumn.SelectAllCheckbox']
        }

        public void ExportWIPButtonDisabled()
        {
            try
            {
                driver.ClickElement(lnkExportWIP, "Export WIP");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'accounting_exportjournalentries')]"));
                driver.WaitElementPresent(ddnExportSelectAll);
                driver.ClickElement(ddnExportSelectAll, "Select All");
                driver.WaitElementPresent(btnGo);
                driver.ClickElement(btnGo, "Go Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(SelectDate);
                driver.ClickElement(SelectDate, "");
                driver.sleepTime(10000);
                IList<IWebElement> dates = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlDate_DropDown']/div/ul"));
                var selectdate = dates.First().FindElements(By.TagName("li"));
                selectdate[0].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnExport);
                driver.ClickElement(btnExport, "Export Button");
                driver.sleepTime(5000);
                var exportbutton = driver.FindElement(By.XPath("//span[@id='ctl00_cphMain_btnExport']/span/following-sibling::input[@value='Export']"));
                string txt = exportbutton.GetAttribute("disabled");
                if (txt.Equals("true"))
                {
                    Console.WriteLine("Export Button is disabled");
                    this.TESTREPORT.LogSuccess("Verify Export Button is disabled", "Export Button is disabled successfully");
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Export Button is disabled", "Export Button is not disabled successfully");
                }
            }
            catch (Exception EX)
            {
                this.TESTREPORT.LogFailure("Verify Export Button is disabled", "Failed to Verify Export Button is disabled", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnDesignDashboard(string text)
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, text, "Requirement Definition");
                driver.ClickElement(lnkDesignDashboard, "Design Dashboard");
                driver.SwitchToDefaultFrame();
        }

        public void SelectVMS()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                //driver.WaitElementPresent(frameDashboard);
                //driver.SwitchToFrameByLocator(frameDashboard);
                driver.WaitElementPresent(ddnErecruitVMS);
                driver.ClickElement(ddnErecruitVMS,"Ddn Erecruit VMS");
                SelectElement selectElement = new SelectElement(driver.FindElement(ddnErecruitVMS));
                selectElement.SelectByText("erecruit VMS");
                HandleAlert();
                driver.sleepTime(5000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Select VMS", "Failed to Select VMS", EngineSetup.GetScreenShotPath());
            }
        }


        }
       
    }