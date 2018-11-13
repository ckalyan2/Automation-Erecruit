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
    public class SmartForms : AbstractTemplatePage
    {
        AddCandidatePage candidate = new AddCandidatePage();
        Utility utility = new Utility();
        

        #region Constructors
        public SmartForms()
        {
        }

        public SmartForms(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository

        #region Login
        private By txtEmail = By.Id("ctl00_cphMain_logIn_UserName");
        private By txtPassword = By.Id("ctl00_cphMain_logIn_Password");
        private By btnLogin = By.Id("ctl00_cphMain_logIn_Login");
        private By lblLoginMessage = By.XPath(".//*[@id='ctl00_cphMain_lblLogin']");
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
        private By lnkCandidate = By.XPath("//span[text()='Candidate']");
        private By lnkWithoutresume = By.XPath("//span[text()='Without Resume']");
        private By lnkCompany = By.XPath("//span[text()='Company']");
        private By lnkAccounting = By.XPath("//span[text()='Accounting']");
        private By lnkPosition = By.XPath("//span[text()='Position']");
        private By lnkSimple = By.XPath("//span[text()='Simple']");
        private By ttlAddNewPosition = By.XPath("//h1[contains(@title,'Add New Position')]");
        private By Position = By.XPath("//span[contains(.,'Positions')]");
        private By txtPositionNameorID = By.XPath("//li[@class='position']/span/div/div/input");
        // ----Add requirement --//
        private By lnkTools = By.XPath("//span[text()='Tools']");
        private By lnkControlPanel = By.XPath("//span[text()='Control Panel']");
        private By lnkControlPanelModule = By.XPath("//li[@class='rmItem rmLast']");
        private By txtRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/span[1]/input[1]");
        private By lnkRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[3]/li[4]/ul/li/a[text()='Requirement Definitions']");
        private By btnAddRequirement = By.XPath("//button[@title='Add a new Requirement']");
        private By txtEnterName = By.XPath("//input[@placeholder='Enter a Name']");
        private By ddntype = By.XPath("//div[@id='s2id_RequirementType_SelectedItem']/a/span");
        private By txttype = By.XPath("//input[@data-helptip='RequirementType']");
        private By ddntarget = By.XPath("//div[@id='s2id_TargetAboutTypeID_SelectedItem']/a/span");
        private By txttarget = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By txtWeight = By.Id("Weight");
        private By btnSave = By.XPath("//button[text()='Save']");
        private By lnkMatches = By.XPath("//span[@title='Keyboard Shortcut: Shift+S, T']"); //By.XPath("//li[@class='search maintain_hover']//li[@class='match']/span[contains(text(),'Matches')]");
        private By lnkMatchinput = By.XPath("//div//ul/li[@class='match']//input");
        private By iframeCompany = By.XPath("//iframe[contains(@id,'company')]");
        //--Edit Requirement--//
        private By txtFiltername = By.Id("txtfilter");
        private By btnEdit = By.XPath("//button[@class='btn editRequirement input-sm clicktip']");

        //--Match--//
        private By lnkMatch = By.XPath("//span[text()='Match']");
        private By btnQuick = By.XPath("//span[text()='Match']/div/div/div//span[text()='Quick']");
        private By ddnSelectPosition = By.XPath("//div[@id='s2id_Position']/a/span");
        private By txtEnterPosition = By.XPath("//div[text()='Select a candidate to view details']//following-sibling::div/div/input");
        private By btnNext = By.XPath("//input[@data-panel='timelineCandidates']");
        private By txtCandidates = By.XPath("//div[@id='s2id_Candidates']/ul/li/input");
        private By btnCandidatesNext = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By btnSubmitalNext = By.XPath("//input[@value='Approve without Sending Email']");

        private By lblRequirements = By.XPath("//span[text()='Scheduled Items']/../following-sibling::li/span[text()='Requirements']");
        private By lnkOpportunities = By.XPath("//span[text()='Legal Cases']/../..//li//span[text()='Opportunities']");
        private By txtinputOpportunities = By.XPath("//span[text()='Legal Cases']/../..//li//span[text()='Opportunities']/div/div/div/following-sibling::input");
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

        private By btnSearch = By.XPath("//input[@value='Search']");
        private By chkboxTimesheet = By.XPath("//input[@class='check-one']");
        private By txtDelete = By.XPath("//div[text()='Delete']");
        private By btnDelete = By.XPath("//button[text()='Delete']");
        private By ddnCandidateStatus = By.XPath("//div[text()='Candidate Status']");
        private By ddnActiveMatch = By.XPath("//div[text()='Active Matches Only']");
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
        private By txtCurrentPwd = By.XPath("//input[contains(@id,'_cphMain_CurrentPassword')]");
        private By txtNewPwd = By.XPath("//input[contains(@id,'_cphMain_NewPassword')]");
        private By txtConfirmPwd = By.XPath("//input[contains(@id,'_cphMain_ConfirmNewPassword')]");
        private By btnChangePassword = By.XPath("//input[contains(@id,'_cphMain_btnChangePassword_input')]");
        private By hdPageTitle = By.XPath("//div[@id='pagetitle']/h1[contains(text(),'Dashboard')]");
        #endregion

        private By frameCandidateQuick = By.XPath("//iframe[contains(@id,'candidate_By-quick')]");
        private By frameContactQuick = By.XPath("//iframe[contains(@id,'contact_By-quick')]");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'dashboard')]");        private By framematch = By.XPath("//iframe[@src='..//Mvc/match/new?quickplacement=true']");
        private By lbltypes = By.XPath("//label[text()='Types:']");
        private By icontypes = By.XPath("//label[text()='Types:']/../../../div[@class='filter-close-button k-icon k-group-delete']");
        private By lblstages = By.XPath("//label[text()='Stages:']");
        private By iconstages = By.XPath("//label[text()='Stages:']/../../../div[@class='filter-close-button k-icon k-group-delete']");

        #region smartform
        private By frameSmartform = By.XPath("//iframe[contains(@id,'admin_site-v4ControlPanelPage')]");
        private By lnkSmartforms = By.XPath("//a[text()='Smart Forms']");
        private By btnCreateform = By.XPath("//span[text()='Create Smart Form']");
        private By framenewform = By.XPath("//iframe[contains(@id,'clientpage_index')]");
        private By lnkInteger = By.XPath("//div[text()='Design a Form']//following-sibling::div//a[text()='Integer']");
        private By txtFormName = By.XPath("//input[@placeholder='Form Name']");
        private By txtfield = By.XPath("//h2[text()='Integer']/following-sibling::input[@placeholder='Field Name']");
        private By txtprompt = By.XPath("//h2[text()='Integer']/following-sibling::input[@placeholder='Field Prompt']");
        private By btnAdd = By.XPath("//button[@data-bind='click: AddItem, enable: IsEnabled']");
        private By txtnum1 = By.XPath("//div[@data-bind='control: LowInput']/input[2]");
        private By txtnum2 = By.XPath("//div[@data-bind='control: HighInput']/input[2]");
        private By txtnum3 = By.XPath("//div[@data-bind='control: ScoreInput']/input");
            //By.XPath("//div[@data-bind='control: ScoreInput']/input[3]");
        private By btnformsave = By.XPath("//div[text()='Design a Form']//following-sibling::div[2]//div[@class='widgetfooter']/div/button[text()='Save']");
        private By lnksmartformresponse = By.XPath("//span[text()='Smart Form Responses']");
        private By framesearchform = By.XPath("//iframe[contains(@id,'FormRespondent')]");
        private By lnkSmartForm = By.XPath("//a[@data-tipsource='app/Forms/Answers']");
        private By widgetSmartForm = By.XPath("//h3[@class='title']//span[text()='Score:']");
        #endregion

        #region Public Methods
        public void CreateSmartForm(string form, string formname, string field, string prompt, string numone, string numtwo, string numthree)
        {
            try
            {
                driver.SendKeysToElement(txtRequirementDef, form, "Smart Form");
                driver.WaitElementPresent(lnkSmartforms);
                driver.ClickElement(lnkSmartforms, "Smart Forms");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSmartform);
                driver.SwitchToFrameByLocator(frameSmartform);
                driver.WaitElementPresent(btnCreateform);
                driver.ClickElement(btnCreateform, "Create smart form");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framenewform);
                driver.SwitchToFrameByLocator(framenewform);
                driver.WaitElementPresent(lnkInteger);
                driver.ClickElement(lnkInteger, "Integer");
                driver.WaitElementPresent(txtFormName);
                driver.SendKeysToElement(txtFormName, formname, "Form name");
                driver.WaitElementPresent(txtfield);
                driver.SendKeysToElement(txtfield, field, " field");
                driver.WaitElementPresent(txtprompt);
                driver.SendKeysToElement(txtprompt, prompt, " prompt");
                driver.WaitElementPresent(btnAdd);
                driver.ClickElement(btnAdd, "Add button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtnum1);
                driver.SendKeysUsingActions(txtnum1,numone,"Number one");
                driver.WaitElementPresent(txtnum2);
                driver.SendKeysUsingActions(txtnum2, numtwo, "Number two");
                //driver.WaitElementPresent(txtnum3);
                //driver.SendKeysUsingActions(txtnum3,numthree, "Number three");
                driver.WaitElementPresent(btnformsave);
                driver.ClickElement(btnformsave,"save button");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Smart form", "Failed to Create Smart form : ", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnSmartForm()
        {
            try
            {
                driver.ClickElement(lnksmartformresponse, "Smart Form Response");
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framesearchform);
                driver.ClickElement(btnSearch,"Search Button");
                //driver.VerifyWebElementPresent(widgetSmartForm, "Smart Form widget is opened");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On SmartForm", "Failed to Click On SmartForm:", EngineSetup.GetScreenShotPath());
            }
        }


        #endregion
    }

}
