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
using System.Threading;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class ControlPanelPage : AbstractTemplatePage
    {

        HomePage home = new HomePage();

        #region Constructors
        public ControlPanelPage()
        {
        }

        public ControlPanelPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        #region Recruiter
        private By logoMenu = By.XPath("//div[@class='logo_inner']");
        private By lnkAddnew = By.XPath("//span[text()='Add New']");
        private By lnkTools = By.XPath(".//span[text()='Tools']");
        private By lnkControlPanel = By.XPath(".//span[text()='Control Panel']");
        private By lnkControlPanelModules = By.XPath(".//*[@id='ctl00_ctl00_cphMain_menuAdmin']/ul/li[2]/a/span");
        private By txtAdminMenuFilter = By.Id("txtAdminMenuFilter");
        private By lnkDesignDashboards = By.XPath("//a[text()='Design Dashboards']");
        //By.XPath(".//*[@id='ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages']/ul[2]/li[3]/ul/li[2]/a[text()='Design Dashboards']");
        private By btnDesignCandidateDashboard = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_gridDashboards_ctl00_ctl06_gbcDesign']");
        //By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphMain_gridDashboards_ctl00_ctl04_gbcDesign']");
        private By btnDesignVendorDashboard = By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphMain_gridDashboards_ctl00_ctl15_gbcDesign']");
        private By lblCreateRuleDefinition = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_pnlRuleEvents']//h3");
        private By ddlChooseType = By.Id("ctl00_ctl00_cphMain_cphMain_ddlAboutType_Input");
        private By txtChooseCandidate = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlAboutType_DropDown']//ul/li[6]/h5");
        private By ddlProcessRules = By.Id("ctl00_ctl00_cphMain_cphMain_ddlEvent_Input");
        private By txtProcessRules = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlEvent_DropDown']//ul/li[1]/h5");
        private By lblAddCustomRule = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_hpAddField']//h3");
        private By txtAddCustomRule = By.Id("ctl00_ctl00_cphMain_cphMain_ddlAvailableFields_Input");
        private By ddlAddCustomRule = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlAvailableFields_DropDown']/div/ul/li[text()='Candidate: State/Province']");
        private By chckMarkFieldAsRequired = By.Id("ctl00_ctl00_cphMain_cphMain_chkIsRequired");
        private By btnAddField = By.Id("ctl00_ctl00_cphMain_cphMain_btnAddFieldRule_input");
        private By lnkPermissionTemplates = By.XPath("//a[text()='Permission Templates']");
        private By txtFilterPermission = By.Id("ctl00_ctl00_cphMain_cphMain_txtFilter");
        private By lnkManageAPIPermission = By.XPath("//span[text()='Manage API Permissions']");
        private By lnkAgreementTypes = By.XPath("//a[text()='Agreement Types']");
        private By txtNewType = By.Id("ctl00_ctl00_cphMain_cphMain_txtTypeName");
        private By txtSortOrder = By.Id("ctl00_ctl00_cphMain_cphMain_txtSortOrder");
        private By ddlPrintTemplates = By.Id("ctl00_ctl00_cphMain_cphMain_ddlPrintTemplates_ddlList_Input");
        private By chckPrintTemplates = By.XPath("//li[@id='ctl00_ctl00_cphMain_cphMain_ddlPrintTemplates_ddlList_i0_lstList_i0']/input");//By.XPath("//span[text()='Master Services Agreement']");
        private By btnAddAgreementType = By.Id("ctl00_ctl00_cphMain_cphMain_btnAdd");
        private By lnkAgreement = By.XPath("//span[text()='Agreement']");
        private By ddlAgreementinput = By.XPath("//tr[@id='ctl00_ctl00_cphMain_cphMain_gridAgreementTypes_ctl00__0']/td[6]/input");//By.Id("ctl00_cphMain_ddlAgreementType_Input");
        private By EditAgreementinput = By.XPath("//tr[@id='ctl00_ctl00_cphMain_cphMain_gridAgreementTypes_ctl00__0']/td[2]/input");
        private By UpdateAgreement = By.XPath("//tr[@id='ctl00_ctl00_cphMain_cphMain_gridAgreementTypes_ctl00__0']/td[6]/input[@title='Update']");
        private By deleteAgreement = By.XPath("//tr[@id='ctl00_ctl00_cphMain_cphMain_gridAgreementTypes_ctl00__0']/td[7]/input");

        private By frameAdminDefault = By.XPath("//iframe[contains(@id,'admin_Default')]");
        private By frameAdminDashboard = By.XPath("//iframe[contains(@id,'admin_site-DashboardDesign')]");
        private By framePermissionTemplate = By.XPath("//iframe[contains(@id,'admin_site-ManagePermissionTemplates')]");
        private By frameManageAgreementTypes = By.XPath("//iframe[contains(@id,'admin_site-ManageAgreementTypes')]");
        private By frameNewAgreement = By.XPath("//iframe[contains(@id,'agreement_new')]");
        #endregion

        private By frameControlPanel = By.XPath("//iframe[contains(@id,'admin_Default')]");
        private By lnkControlPanelModule = By.XPath("//img[@src='../../Mvc/Content/Images/icons/cog.png']//following-sibling::span");
        private By lnkRequirementDefinition = By.XPath("//div[contains(@id,'ctl00_ctl00_cphMain_menuAdmin_i1_i0_mapAdminPages')]//a[contains(text(),'Requirement Definitions')]");
        private By frameSitemanagementRequirement = By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]");
        private By btnAddRequirement = By.XPath(".//*[contains(text(),'Add Requirement')]");
        private By txtRequirementName = By.XPath("//input[@data-helptip='RequirementName']");
        private By ddlType = By.XPath("//div[contains(@id,'s2id_RequirementType_SelectedItem')]//a[@class='select2-choice']");
        private By txtSearchType = By.XPath("//input[@data-helptip='RequirementType']");
        private By ddlTaegetRecordType = By.XPath("//div[contains(@id,'s2id_TargetAboutTypeID_SelectedItem')]//a[@class='select2-choice']");
        private By txtSearchTargetRecordType = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By txtWeight = By.Id("Weight");
        private By txtExpirationWarningDays = By.Id("ExpirationWarningDays"); //By.XPath("//input[contains(@id,'ExpirationWarningDays')]//following-sibling::input[1]");
        private By btnSave = By.XPath("//button[@id='SaveRequirement']");
        private By warningMessage = By.XPath("//div[@class='error message messaging']");

        private By lnkPositiontypes = By.XPath("//a[text()='Position Types']");
        private By iframePositionTypeManage = By.XPath("//iframe[contains(@id,'admin_site-ManagePositionTypes_')]");
        private By btnEditPositionTypes = By.XPath("//tr[1]//td[@class='Buttons']/div[@class='icon-pencil']");
        private By lnkCorp1 = By.XPath("//span[text()='Corp 1']");
        private By btnSavePositionType = By.XPath("//button[text()='Save']");
        private By warningMessagePositionType = By.XPath("//div[@class='cooltipmessage error']");//By.XPath("//div[text()='Entities Corp 1 cannot be removed because there are dependent records.']");

        //Shift status
        private By txtSearchBox = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/span[1]/input[1]");
        private By lnkShiftStatus = By.XPath("//li[@class='rsmItem']/a[contains(text(),'Shift Statuses')]");
        private By frameShiftStatus = By.XPath("//iframe[contains(@id,'admin_site-ManageShiftStatuses_')]");
        private By chkColor = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_statusColor_label']/a");
        private By colorDarkblue = By.XPath("//span[text()='#3300FF']");
        private By txtStatusName = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_txtStatusName']");
        // private By txtSortOrder = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_txtSortOrder']");
        private By ddlToReqPermission = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_ddlPermission_Input']");
        private By ddlFromReqPermission = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_ddlPermissionFrom_Input']");
        private By ddlToMinStatusMatch = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_ddlMinMatchStatus_Input']");
        private By ddlTimeLineSheet = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_ddlTimesheetStatus_Input']");
        private By btnAddNewStatus = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphMain_btnAdd']");
        private By msgSuccessfullAdded = By.XPath("//div[@id='message_1']");
        private By lnkMngShiftCancelReason = By.XPath("//a[text()='Manage Shift Cancellation Reasons']");
        private By frameCancellationStatus = By.XPath("//iframe[contains(@id,'admin_site-ManageShiftCancellationReasons_')]");
        private By txtNewReason = By.Id("ctl00_ctl00_cphMain_cphMain_txtReasonName");
        private By ddlReqpermission = By.Id("ctl00_ctl00_cphMain_cphMain_ddlPermission_Input");
        private By ddlFromStatus = By.XPath("//input[contains(@id,'ddlUFromStatuses_ddlList_Input')]");
        private By listFromStatus = By.XPath("//ul[@class='rlbList']");
        private By btnAddNewReason = By.XPath("//input[@value='Add New Reason']");
        private By btnUpdateShift = By.XPath("//input[contains(@id,'UpdateButton')]");
        private By lblUpdateMessage = By.XPath("//div[text()='Cancellation reason update successfully.']");
        //Verify Design pages
        private By lnkDesignPages = By.XPath("//a[text()='Design Pages']");
        private By btnDesignAgreement = By.XPath("//input[contains(@id,'btnDesignAgreementPage_in')]");
        private By frameDailogDesign = By.XPath("//iframe[contains(@id,'admin_site-DialogDesign')]");
        private By ddlSelectFieldsToHide = By.XPath("//a[contains(@id,'_chksHideableFields_ddlList_Arrow')]");
        private By frameAgreementManage = By.XPath("//iframe[contains(@id,'agreement_manage')]");
        private By chkAgreementOwner = By.XPath("//span[text()='Agreement Owner']/preceding-sibling::input");
        private By btnSaveSelectHideField = By.XPath("//input[contains(@id,'btnSaveDesign')]");

        private By lblOwnerName = By.XPath("//span[text()='Agreement Owner']");
        private By btnInitializePages = By.Id("ctl00_ctl00_cphMain_cphMain_btnInitializePages_input");
        #endregion

        #region Public Methods
        public void MouseHoverOnTools()
        {
            try
            {
                driver.VerifyWebElementPresent(logoMenu, "ImageLogo");
                driver.ClickElement(logoMenu, "Click on ImageLogo");
                //driver.MouseHover(lnkAddnew, "Add New");
                driver.MouseHover(lnkTools, "Tools");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Mouse Hover on Tools", "Failed to MouseHover On Tools", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnControlPanel()
        {
            try
            {
                driver.VerifyWebElementPresent(lnkControlPanel, "Control Panel");
                driver.ClickElement(lnkControlPanel, "Control Panel");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnControlPanel", "Failed to Click On Control Panel", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnControlPanelModules()
        {
            try
            {
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.WaitElementPresent(lnkControlPanelModules);
                driver.ClickElement(lnkControlPanelModules, "Control Panel Modules");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnControlPanelModules", "Failed to Click On Control Panel Modules", EngineSetup.GetScreenShotPath());
            }
        }

        public void EnterAdminMenuFilter()
        {
            try
            {
                driver.WaitElementPresent(txtAdminMenuFilter);
                driver.SendKeysToElement(txtAdminMenuFilter, "Design Dashboards", "Design Dashboards");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("EnterTextAdminMenuFilter", "Failed to Enter Text to Admin Menu Filter", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnDesignDashboards()
        {
            try
            {
                driver.WaitElementPresent(lnkDesignDashboards);
                driver.ClickElement(lnkDesignDashboards, "Design Dashboards link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnDesignDashboards", "Failed to Click On Design Dashboards", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnDesignDashboardButton()
        {
            try
            {
                driver.SwitchToFrameByLocator(frameAdminDashboard);
                driver.WaitElementPresent(btnDesignCandidateDashboard);
                driver.ClickElement(btnDesignCandidateDashboard, "Design Dashboard button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnDesignDashboardsButton", "Failed to Click On Design Dashboards button", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnVendorDesignDashboardButton()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAdminDashboard);
                driver.WaitElementPresent(btnDesignCandidateDashboard);
                driver.ClickElement(btnDesignCandidateDashboard, "Vendor Design Dashboard button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnVendorDesignDashboardButton", "Failed to Click On Vendor Design Dashboard Button", EngineSetup.GetScreenShotPath());
            }

        }

        #region VerifyWarningMessageExpire365Days
        public void VerifyWarningMessageExpire365Days(string requirementName, string type, string targetRecordType, string weight, string expirationDays)
         {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAdminDefault);
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkControlPanelModule);
                driver.ClickElement(lnkControlPanelModule, "Control Panel Module");
                driver.WaitElementPresent(lnkRequirementDefinition);
                driver.ClickElement(lnkRequirementDefinition, "Requirement Definition");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSitemanagementRequirement);
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddRequirement);
                driver.ClickElement(btnAddRequirement, "Add Requirement");
                driver.ClickElementAndSendKeys(txtRequirementName, requirementName, "Requirement Name");
                driver.ClickDropdownAndSearchText(ddlType, txtSearchType, type, "Requirement Type");
                driver.ClickDropdownAndSearchText(ddlTaegetRecordType, txtSearchTargetRecordType, targetRecordType, "Target Record Type");
                driver.ClickElementAndSendKeys(txtWeight, weight, "Weight");
                driver.ClickElementAndSendKeys(txtExpirationWarningDays, expirationDays, "Expiriration warning days");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(10000);
                driver.WaitElementPresent(warningMessage);
                driver.AssertTextEqual(warningMessage, "Expiration warning days cannot be greater than 365");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Expiration warning days", "Expiration warning days", EngineSetup.GetScreenShotPath());
            }
        }

        #endregion


        public void CreateCustomRules(string createRule, string customRule)
        {
            try
            {
                driver.WaitElementPresent(btnInitializePages);
                driver.ClickElement(btnInitializePages, "Initialize Pages");
                driver.sleepTime(10000);
                driver.VerifyTextValue(lblCreateRuleDefinition, createRule, "Create rule Definition");
                driver.WaitElementPresent(ddlChooseType);
                driver.ClickElement(ddlChooseType, "Choose Type");
                driver.ClickElement(txtChooseCandidate, "Choose Candidate");
                driver.WaitElementPresent(ddlProcessRules);
                driver.ClickElement(ddlProcessRules, "Process Rules");
                driver.WaitElementPresent(txtProcessRules);
                driver.ClickElement(txtProcessRules, "Process Rules");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtAddCustomRule);
               // driver.VerifyTextValue(lblAddCustomRule, customRule, "Custom Rule");
                driver.ClickElement(txtAddCustomRule, "Add CustomRule");
                driver.WaitElementPresent(ddlAddCustomRule);
                driver.ClickElement(ddlAddCustomRule, "Add Custome Rule");
               // driver.WaitElementPresent(chckMarkFieldAsRequired);
                //driver.WaitElementStale(chckMarkFieldAsRequired);
                driver.sleepTime(3000);
                driver.WaitElementPresent(chckMarkFieldAsRequired);
                driver.ClickElement(chckMarkFieldAsRequired, "Mark As Required Field");
               // driver.sleepTime(3000);
                driver.WaitElementPresent(btnAddField);
                driver.ClickElement(btnAddField, "Add Field Rule");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Custom Rules", "Failed While Creating Custom rules", EngineSetup.GetScreenShotPath());
            }
        }

        public void ManagePermissions(string Manage, string Renamed)
        {
            try
            {
                driver.ClickElement(lnkPermissionTemplates, "Permission Templates");
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePermissionTemplate);
                driver.SwitchToFrameByLocator(framePermissionTemplate);
                driver.SendKeysToElement(txtFilterPermission, Manage, "Manage API Permissions");
                driver.VerifyWebElementPresent(lnkManageAPIPermission, "Manage API Permissions");
                driver.SendKeysToElementClearFirst(txtFilterPermission, Renamed, "Mange API Permissions");
                driver.FindElement(txtFilterPermission).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.VerifyWebElementPresent(lnkManageAPIPermission, "Manage API Permission");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Manage Permissions", "Failed to Manage Permissions", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickAgreementTypes(string NewType, string SortOrder)
        {
            try
            {
                driver.ClickElement(lnkAgreementTypes, "Agreement Type");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageAgreementTypes);
                driver.SendKeysToElement(txtNewType, NewType, "Select New Type");
                driver.WaitElementPresent(txtSortOrder);
                driver.SendKeysToElement(txtSortOrder, SortOrder, "Select Sort Order");
                driver.WaitElementPresent(ddlPrintTemplates);
                driver.ClickElement(ddlPrintTemplates, "Print Templates");
                driver.WaitElementPresent(chckPrintTemplates);
                driver.ClickElement(chckPrintTemplates, "Select Print Templates");
                driver.WaitElementPresent(btnAddAgreementType);
                driver.ClickElement(btnAddAgreementType, "Save Agreement Type");
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_gridAgreementTypes_ctl00']"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                string val = null;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(SortOrder.Substring(1)))
                    {
                        char delimiter = ' ';
                        String[] value = row.Text.Split(delimiter);
                        val = value[1].ToString();
                    }
                }
                driver.AssertTextMatching(val, NewType);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click Agreement Types", "Failed to Click Agreement Types", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddedAgreementTypes(string Agreement)
        {
            try
            {
                //driver.ClickElement(lnkAgreement, "Agreement");
                //driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                //driver.SwitchToFrameByLocator(frameNewAgreement);
                driver.ClickElement(ddlAgreementinput, "Agreement input");
                driver.SendKeysToElementClearFirst(EditAgreementinput, Agreement, "Agreement type");
                driver.ClickElement(UpdateAgreement, "Update Agreement");
                //string NewlyAddedAgreement = string.Format("//div[@id='ctl00_cphMain_ddlAgreementType_DropDown']/div/ul/li[text()='{[0]}'", Agreement);
                //string NewAgreement = driver.FindElement(By.XPath(NewlyAddedAgreement)).Text;
                //string Agrement = NewAgreement.GetAttribute("text");
                // driver.AssertTextMatching(NewAgreement, Agreement);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Added Agreement Types", "Failed to Verify Added Agreement Types", EngineSetup.GetScreenShotPath());
            }
        }

        public void DeleteAgreementTypes()
        {
            try
            {
                //driver.ClickElement(lnkAgreement, "Agreement");
                //driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                //driver.SwitchToFrameByLocator(frameNewAgreement);
                driver.ClickElement(deleteAgreement, "Delete Agreemetn");
                //string NewlyAddedAgreement = string.Format("//div[@id='ctl00_cphMain_ddlAgreementType_DropDown']/div/ul/li[text()='{[0]}'", Agreement);
                //string NewAgreement = driver.FindElement(By.XPath(NewlyAddedAgreement)).Text;
                //string Agrement = NewAgreement.GetAttribute("text");
                // driver.AssertTextMatching(NewAgreement, Agreement);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Delete Agreement Types", "Failed to Delete Agreement Types", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Scheduling Administration
        /// </summary>

        public void SchedulingAdministration(string shifStatus2, string testCaseName, string sortOrder, string minMatch, string timeSheet, string newReason, string reqPermission)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.SendKeysToElementClearFirst(txtSearchBox, shifStatus2, "Shift Statuses");
                driver.WaitElementPresent(lnkShiftStatus);
                driver.ClickElement(lnkShiftStatus, "Shift Status");
                //driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameShiftStatus);
                driver.SwitchToFrameByLocator(frameShiftStatus);
                driver.ClickElement(chkColor, "color check box");
                driver.ClickElement(colorDarkblue, "Dark blue color");
                driver.WaitElementPresent(txtStatusName);
                driver.SendKeysToElement(txtStatusName, testCaseName, "Test Status name");
                driver.WaitElementPresent(txtSortOrder);
                driver.SendKeysToElement(txtSortOrder, sortOrder, "Sort Order");
                driver.WaitElementPresent(ddlToMinStatusMatch);
                driver.SendKeysToElement(ddlToMinStatusMatch, minMatch, "Minimum Match");
                driver.WaitElementPresent(ddlTimeLineSheet);
                driver.SendKeysToElement(ddlTimeLineSheet, timeSheet, "Time line sheet");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddNewStatus);
                driver.ClickElement(btnAddNewStatus, "Button Add New Status");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameShiftStatus);
                driver.SwitchToFrameByLocator(frameShiftStatus);
                driver.sleepTime(5000);
                driver.WaitElementPresent(msgSuccessfullAdded);
                driver.AssertTextEqual(msgSuccessfullAdded, "Shift Status added successfully.");
                driver.WaitElementPresent(lnkMngShiftCancelReason);
                driver.ClickElement(lnkMngShiftCancelReason, "Shift cancellation Reson");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameCancellationStatus);
                driver.SwitchToFrameByLocator(frameCancellationStatus);
                driver.SendKeysToElement(txtNewReason, newReason, "New Reason");
                driver.ClickElement(btnAddNewReason, "Add New Reason");
                By editShiftStatus = By.XPath("//td[contains(text(),'" + newReason + "')]/..//input[@title='Edit']");
                driver.ClickElement(editShiftStatus, "Edit");
                driver.ClickElement(ddlFromStatus, "From Status");
                var statusText = driver.FindElement(listFromStatus).FindElement(By.XPath("//span[text()='" + testCaseName + "']/preceding-sibling::input"));
                statusText.Click();
                driver.WaitElementPresent(btnUpdateShift);
                driver.ClickElement(btnUpdateShift, "Update");
                driver.sleepTime(15000);
               // driver.CheckElementExists(lblUpdateMessage, "Update Message");
                //statusText.Click();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Scheduling Administration", "Failed to verify Scheduling Administration", EngineSetup.GetScreenShotPath());
            }
        }


        public void VerifyPositionTypes(string errormessage)
        {
            try
            {
                driver.ClickElement(lnkPositiontypes, "Position Types");
                driver.SwitchToFrameByLocator(iframePositionTypeManage);
                driver.ClickElement(btnEditPositionTypes, "Edit Position Types");
                driver.ClickElement(lnkCorp1, "Corp1 Link");
                driver.ClickElement(btnSavePositionType, "Save Position Types");
                //  driver.VerifyTextValue(warningMessagePositionType, " Warning Message for Position Types");
                IWebElement warningMessagePositionType = driver.FindElement(By.XPath("//div[@class='cooltipmessage error']"));
                string message = warningMessagePositionType.Text;
                driver.AssertTextMatching(errormessage, message);
                driver.ClickElement(lnkCorp1, "Corp1 Link");
                driver.ClickElement(btnSavePositionType, "Save Position Types");
                //driver.VerifyWebElementNotPresent("","");
                driver.ClickElement(btnEditPositionTypes, "Edit Position Types");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Position Types", "Failed to Verify Position Types", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify Updates saved to design page
        /// </summary>
        public void VerifyUpdatesSavedToDesignPage(string designPage, string txtAgreementOwner)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(15000);
                driver.WaitElementPresent(frameAdminDefault);
                driver.SwitchToFrameByLocator(frameAdminDefault);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtSearchBox);
                driver.SendKeysToElementClearFirst(txtSearchBox, designPage, "Design Page");
                driver.WaitElementPresent(lnkDesignPages);
                driver.ClickElement(lnkDesignPages, "Design Page");
                driver.sleepTime(5000);
                //driver.WaitForPageLoad(TimeSpan.FromSeconds(15));
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameDailogDesign);
                driver.SwitchToFrameByLocator(frameDailogDesign);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnDesignAgreement);
                driver.ClickElement(btnDesignAgreement, "Design Agreement");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAgreementManage);
                driver.SwitchToFrameByLocator(frameAgreementManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlSelectFieldsToHide);
                driver.ClickElement(ddlSelectFieldsToHide, "Drop down Select Filed to hide");
                driver.WaitElementPresent(chkAgreementOwner);
                driver.ClickElement(chkAgreementOwner, "Check box Agreement Owner");
                driver.WaitElementPresent(btnSaveSelectHideField);
                driver.ClickElement(btnSaveSelectHideField, "Save");
                driver.sleepTime(10000);
                driver.CheckElementNotDisplayed(lblOwnerName, "Agreement Owner");
                //Again uncheck Agreement owner and save
                driver.WaitElementPresent(ddlSelectFieldsToHide);
                driver.ClickElement(ddlSelectFieldsToHide, "Drop down Select Filed to hide");
                driver.WaitElementPresent(chkAgreementOwner);
                driver.ClickElement(chkAgreementOwner, "Uncheck Agreement Owner");
                driver.WaitElementPresent(btnSaveSelectHideField);
                driver.ClickElement(btnSaveSelectHideField, "Save");
                driver.sleepTime(5000);
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Agreement Owner Displayed", "Agreement owner field displayed", EngineSetup.GetScreenShotPath());
            }


        }
        #endregion
    }
}
