
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
using OpenQA.Selenium.Interactions;
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
    public class AddCompanyPage : AbstractTemplatePage
    {
        Utility utility = new Utility();
        #region UI objectRepository
        #region Add Company
        private By txtCompany = By.Id("ctl00_cphMain_ctlAddress_txtCompany");
        private By txtCompanycity = By.Id("ctl00_cphMain_ctlAddress_txtCity");
        private By ddlCompanySource = By.Id("AdSourceDropdown_ddladsource");
        private By txtCompanyPhone = By.Id("ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl01_txtValue");
        private By txtCompanyEmail = By.Id("ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl02_txtValue");
        private By txtCompanyWebsite = By.Id("ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl03_txtValue");
        private By txtCompanySource = By.XPath("//ul/li/a[text()='Admin Source']");
        private By btnSave = By.Id("ctl00_cphMain_btnSave_input");
        private By lblId = By.XPath("//div[@id='pagetitle']/h1");
        private By txtAddress = By.XPath("//input[contains(@id,'cphMain_ctlAddress_txtAddr1')]");
        private By ddlState = By.Id("ctl00_cphMain_ctlAddress_ddlState_Input");
        private By txtZip = By.XPath("//input[contains(@id,'cphMain_ctlAddress_txtZip')]");
        private By lblCompany = By.XPath(".//div[@id='pagetitle']/h1");
        private By btnCloseCompany = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnClose_input");

        private By btnAccounting = By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphTabs_tabsPages']/div/ul/li[5]/a/span/span/span");
        private By lblVMS = By.XPath("//span[text()='VMS Burden']");
        private By btnEditStatus = By.XPath(".//*[@data-tipname='company/status']");
        private By btnEditVMS = By.XPath("//div[@data-tipname='company/accounting']");
        private By txtVMSburden = By.XPath(".//input[contains(@id, 'ddlvmsburden')]");
        private By lnkVMSburden = By.XPath("//a[text()='Test VMS']");
        private By txtWorkerComp = By.XPath("//*[contains(@id, 'ddlworkerscomp')]/ul");
        private By inputWorkerComp = By.XPath("//*[contains(@id, 'ddlworkerscomp')]/ul/li/input");
        private By btnSaveVMS = By.XPath(".//*[contains(@id, '_btnsave')]");
        private By tabAccounting = By.XPath("//span[text()='Accounting']");
        private By frameManage = By.XPath("//iframe[contains(@id,'company_manage')]");
        private By frameAccoounting = By.XPath("//iframe[contains(@id,'Accounting_frame')]");
        private By frameCandidateMatch = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By frameAccountingPv = By.XPath("//iframe[@id='pvAccounting_frame']");
        private By folderGroup = By.Id("ctl00_cphMain_ddlFolderGroups_Input");
        private By verifyAddress = By.Id("ctl00_cphMain_ucAddress_lblExistingAddress");
        private By VerifyCity = By.XPath("//span[@id='ctl00_cphMain_ucAddress_lblExistingAddress']/b/following-sibling::br[1]");
        private By VerifyCountry = By.XPath("//span[@id='ctl00_cphMain_ucAddress_lblExistingAddress']/b/following-sibling::br[2]");
        private By verifyCompanyName = By.XPath("//input[contains(@id,'ctl00_cphMain_ddlCompany_Input')]");
        private By verifyFolderGroup = By.XPath("//input[contains(@id,'ctl00_cphMain_ddlFolderGroups_Input')]");
        private By verifyContactOwner = By.Id("ctl00_cphMain_ddlContactOwner_Input");
        private By frameNewCompany = By.XPath("//iframe[contains(@id,'company_new')]");
        //create client project
        private By btnAddDepartment = By.XPath(" //button[@title='Add Department']");
        private By txtEnterDeptName = By.XPath("//input[contains(@id,'_txtname')]");
        private By btnClientProject = By.XPath("//button[@id='btnAddNewClientProject']");
        private By btnSaveDept = By.XPath("//span[text()='Save']");
        private By btnRefresh = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input");
        #endregion
        #region  Search Contact
        private By lblContactName = By.XPath("//div[contains(@class,'k-grid-content')]/table/tbody/tr[1]/td[2]/div/a");
        private By frameManageContact = By.XPath("//iframe[contains(@id,'contact_manage')]");
        private By lblActions = By.XPath("//div[@class='rightbar_container group']/div//div[@class='section rightbar']");
        private By lnkManageLogin = By.XPath("//div[@id='actions_section']//div[@title='Manage Login Access']");
        //By.XPath("//div[@class='rightbar_container group']/div//div[@class='section rightbar']//div[@title='Manage Login Access']");
        private By lblAccessmgmt = By.XPath("//div[@class='widgetTitle']");
        private By btnClose = By.XPath("//div[@class='t_CloseButtonShift']");
        private By btnGiveAccess = By.XPath("//div[contains(@id,'widget_provision')]/div[@class='widgetBody']/div[@class='ui-helper-clearfix']/button[contains(@id,'_btngiveaccess')]");
        private By txtPassword = By.XPath("//input[contains(@id,'_give_txtpassword1')]");
        private By txtConfirmPassword = By.XPath("//input[contains(@id,'_give_txtpassword2')]");
        private By txtEmail = By.XPath("//input[contains(@id,'_give_txtemail')]");
        private By btnToggleFed = By.XPath("//button[contains(@id,'_btntogglefederation')]");
        private By btnRevoke = By.XPath("//button[contains(@id,'_btnrevokeaccess')]");
        private By lblGranted = By.XPath("//span[contains(text(),'Granted')]");
        private By txtChangeEmail = By.XPath("//div[contains(@id,'widget_provision')]/div[@class='widgetBody']/div[@class='form-group']/div/input[contains(@id,'_change_txtemail')]");
        private By txtNewPassword = By.XPath("//input[contains(@id,'change_txtpassword1')]");
        private By txtConfrimNewPassword = By.XPath("//input[contains(@id,'change_txtpassword2')]");
        private By lblLastlogged = By.XPath("//label[contains(text(),'Last Logged In')]");
        private By lbltimeFrame = By.XPath("//div[contains(@id,'widget_provision')]/div[2]/div[3]/div[2]/span");
        private By btnSetnewEmail = By.XPath("//button[contains(@id,'_btnsetnewemail')]");
        private By btnSetnewPassword = By.XPath("//button[contains(@id,'btnsetnewpassword')]");
        private By lblLoginAs = By.XPath("//div[contains(text(),'Login as')]");
        private By txtEnterPassword = By.XPath("//input[contains(@id,'txtloginpassword')]");
        private By btnLoginasuser = By.XPath("//span/button[contains(@id,'widget_loginasuser')]");
        private By btnAddContact = By.XPath("//div[@class='related_buttons group']/button[@id='btnAddNewContact']");
        //Agreement 
        private By btnAddAgreement = By.Id("btnAddNewAgreement");
        private By frameagreement = By.XPath("//iframe[contains(@id,'agreement_new_')]");
        private By txtContact = By.Id("ctl00_cphMain_ddlContact_Input");
        private By txtAgreementName = By.Name("ctl00$cphMain$txtAgreeName");
        private By txtLegalName = By.Id("ctl00_cphMain_txtLNameOnAgree");
        private By ddlAgreementType = By.Id("ctl00_cphMain_ddlAgreementType_Input");
        private By ddlBillingTerm = By.Id("ctl00_cphMain_ddlBillingTerm_Input");
        private By btnAgreementSave = By.Name("ctl00$cphMain$btnSave_input");
        private By btnAccountingForPositionTemp = By.XPath("//span[@class='rtsOut']//span[contains(text(),'Accounting')]");
        private By btnAddPositionTemplate = By.XPath("//div[contains(@id,'view_ManagePositionTemplates')]//button[@class='clicktip btn-xs icon-add']");
        //Adding Position Template
        private By txtPositionTitle = By.XPath("//div[@id='field_PositionTitle']//input[@data-helptip='_PositionTitle']");
        private By ddlFacilityDept = By.XPath("//input[@data-helptip='_FacilityDepartmentIds']");
        private By ddlAgreement = By.XPath("//div[@id='field_Agreement']//span[contains(text(),'Select Agreement')]");
        private By txtSearchAgreement = By.XPath("//div[@class='select2-search']//input[@data-helptip='_Agreement']");
        private By ddlRatetype = By.XPath("//div[@id='s2id_RateType_SelectedItem']");
        private By txtSearchRatetype = By.XPath("//div[@class='select2-search']//input[@data-helptip='RateType']");
        private By effectiveDate = By.XPath("//input[@name='EffectiveDate']");
        private By btnSaveTemplatePosition = By.XPath("//button[@id='SavePositionTemplate']");
        private By ddlFolderGroup = By.XPath("//div[@id='s2id_FolderGroup_SelectedItem']/a");
        private By txtSearchFolderGroup = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        //Verify warning message
        private By framePosition = By.XPath("//iframe[contains(@id,'position_new')]");
        private By ddlTemplatePosition = By.XPath("//input[contains(@id,'ctl00_cphMain_ddlPositionTemplate_Input')]");
        private By warningDiv = By.XPath("//div[@class='messages messagingContainer with-rightbar']//div[@id='message_1']");
        private By lblActionStatus = By.XPath("//label[contains(text(),'Access Status')]");
        private By frameContactQuickSearch = By.XPath("//iframe[contains(@id,'contact_By-quick')]");
        private By lblAccessType = By.XPath("//label[contains(text(),'Access Type')]");
        private By btnAccessManagementClose = By.XPath("//div[@class='t_CloseButtonShift']//canvas");
        private By frameCompanyNew = By.XPath("//iframe[contains(@id,'company_new')]");
        private By frameContactNew = By.XPath("//iframe[contains(@id,'contact_new')]");
        private By titleActions = By.XPath("//div[contains(text(),'Actions')]");
        private By lblChangeLoginEmail = By.XPath("//span[contains(text(),'Change Login Email For')]");
        private By lblRememberDisplayText = By.XPath("//div[contains(text(),'Remember: The email that a user logs in with can be different from the email on their record - changing one does not change the other!')]");
        private By lblChangePassword = By.XPath("//span[contains(text(),'Change Password For')]");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By imgEdit = By.XPath("//span[@id='editbuttoncomm' and @data-tipcontext='Company']/img");
        private By contactWidgetTitle = By.XPath("//div[text()='Edit Communication Methods']");
        private By ddnCommunicationType = By.XPath("//input[contains(@id,'widget_communicationlist_') and @class='ui-autocomplete-input' and @data-selectedvalue='201']");
        private By txtCommunicationValue = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtvalue')]");
        private By txtCommunicationNote = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtnote')]");
        private By btnAddCommunication = By.XPath("//button[contains(@id,'_AddCommunication') and @title='Click to add this communication']");
        private By tblCommunication = By.XPath("//div[contains(@id,'_editmode')]/table/tbody");
        private By btnExpand = By.XPath("//div[@id='contact_section']/div[1]/span");
        private By btnPopupClose = By.XPath("//div[@class='t_CloseButtonShift']//canvas");
        //Verify mandatory fields
        private By txtContactOwner = By.XPath("//div[@class='user_menu']/span");
        private By txtDuplicateMessage = By.XPath("//div[contains(@id,'cphMain_pnlDuplicates')]");
        //rates
        private By lnkRates = By.XPath("//a[text()='0 rates']");
        private By btnAddNewRate = By.XPath("//button[text()='Add a new Rate']");
        private By ddlClass = By.XPath("//input[contains(@id,'_ddltrc')]");
        private By lnkClass = By.XPath("//input[contains(@id,'_ddltrc')]");
        private By txtPayRates = By.XPath("//span[text()='Pay Rate']/..//following-sibling::input[2]");
        private By txtBillRates = By.XPath("//span[text()='Bill Rate']/..//following-sibling::input[2]");
        private By candPayRate = By.XPath("//span[text()='Candidate Pay Rate']/..//following-sibling::input[2]");
        private By vendorBillRate = By.XPath("//span[text()='Vendor Bill Rate']/..//following-sibling::input[2]");
        private By clientBillRate = By.XPath("//span[text()='Client Bill Rate']/..//following-sibling::input[2]");
        private By btnSaveRate = By.XPath("//span[text()='Save']");
        private By btnCompanyRefresh = By.XPath("//div[@class='rightbar_container']//following-sibling::div[@class='bottombuttons']//span[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh']");
        private By btnCompanyRequirement = By.XPath("//button[@id='btnAddNewRequirement']");
        private By ddnCompanyRequirement = By.XPath("//label[text()='Requirement']/../div[1]/a");
        private By ddnRequirementInput = By.XPath("//div[text()='Select a value...']/following-sibling::div/div/input");
            //By.XPath("//label[text()='Requirement']/../div[1]/div/div/input");
        private By btnAddRequirement = By.XPath("//button[@class='close-tooltip']//following-sibling::button[text()='Add Requirement']");
        #endregion

        public static string title = "";
        /// <summary>
        /// Method to Add Company
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="postal"></param>
        /// <returns></returns>
        public string AddCompany(string name, string city, string postal, string email, string url, string phoneNumber)
        {
            try
            {
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameCompanyNew);
                driver.SwitchToFrameByLocator(frameCompanyNew);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCompany);
                driver.SendKeysToElementClearFirst(txtCompany, name , "Company Name");
                driver.WaitElementPresent(txtAddress);
                driver.SendKeysToElementClearFirst(txtAddress, city, "Address");
                driver.WaitElementPresent(txtCompanycity);
                driver.SendKeysToElementClearFirst(txtCompanycity, city, "City");
                driver.WaitElementPresent(ddlState);
                driver.ClickElement(ddlState, "State");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(By.XPath("//iframe[@class='active']"));
                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='active']")));
                driver.sleepTime(5000);
                var state = driver.FindElements(By.XPath("//html//form/div[@class='rcbSlide']/div/div[@class='rcbScroll rcbWidth']/ul"));
                var stateoptions = state.First().FindElements(By.TagName("li"));
                stateoptions[1].Click();
                driver.sleepTime(15000);
                driver.WaitElementPresent(txtZip);
                driver.SendKeysToElementClearFirst(txtZip, postal, "PostalCode");
                driver.WaitElementPresent(ddlCompanySource);                
                driver.ClickElement(ddlCompanySource, "Company Source");
               // driver.WaitElementExistsAndVisible(txtCompanySource);
                //driver.sleepTime(30000);
                driver.WaitElementPresent(txtCompanySource);                
                driver.ClickElement(txtCompanySource, "CompanySource");               
                driver.WaitElementPresent(txtCompanyPhone);              
                driver.SendKeysToElementClearFirst(txtCompanyPhone, phoneNumber, "Company Phone");
                // driver.SendKeysToElementClearFirst(txtCompanyWebsite, url, "Website"); 
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save Company");
                driver.sleepTime(30000);
                driver.WaitElementPresent(lblId);
                title = GetCompanyTitle();
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add Company", "Failed to Add Company", EngineSetup.GetScreenShotPath());
            }
            return title;
        }

        public void AddContactFromCompany()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(btnAddContact, "Add New Contact");
               // driver.WaitElementExistsAndVisible(btnAddContact);                
                driver.ClickElement(btnAddContact, "Click Add New Contact");
                driver.sleepTime(20000);
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add Contact", "Failed to Add Contact from Company, Exception:" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add Agreement 
        /// </summary>
        public void AddAgreement()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageContact);
                driver.SwitchToFrameByLocator(frameManageContact);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(btnAddAgreement, "Agreement button");
                driver.WaitElementExistsAndVisible(btnAddAgreement);
                driver.ClickElement(btnAddAgreement, "Click Add Agreement");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add Agreement", "Failed to Add Agreement:Exception" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Create New Agreement
        /// </summary>
        public void CreateNewAgreement(string selectCompanySource, string agreementName, string legalName, string agreementType, string billingTerm)
        {
            try
            {
                driver.SwitchToFrameByLocator(frameagreement);
                //driver.SendKeysToElementAndPressEnter(txtContact, selectCompanySource, "Company Source");
                //driver.SendKeysToElement(txtContact, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.SendKeysToElement(txtAgreementName, agreementName, "AgreementName");
                driver.SendKeysToElement(txtLegalName, legalName, "legal Name");
                driver.ClickElementAndSendKeys(ddlAgreementType, agreementType, "Agreement Type");
                driver.ClickElementAndSendKeys(ddlBillingTerm, billingTerm, "Billing Term");
                driver.ClickElement(btnAgreementSave, "Agreement Save");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Create Agreement", "Failed to create agreement;Exception:" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void CreatAgreementFromContact(string agreementName, string legalName, string agreementType, string billingTerm)
        {
            try
            {
                driver.WaitElementPresent(frameagreement);
                driver.SwitchToFrameByLocator(frameagreement);
                driver.ClickElement(txtContact, "Contact");
                driver.sleepTime(5000);
               // driver.SendKeysToElement(txtContact, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.SendKeysToElement(txtAgreementName, agreementName, "AgreementName");
                driver.SendKeysToElement(txtLegalName, legalName, "legal Name");
                driver.ClickElementAndSendKeys(ddlAgreementType, agreementType, "Agreement Type");
                driver.ClickElementAndSendKeys(ddlBillingTerm, billingTerm, "Billing Term");
                driver.ClickElement(btnAgreementSave, "Agreement Save");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Creat Agreement From Contact", "Failed Creat Agreement from Contact" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void AddDepartment()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.ClickElement(btnAccountingForPositionTemp, "Accounting");
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAccountingPv);
                driver.ClickElement(btnAddDepartment, "button Add");
                driver.sleepTime(1000);
                driver.SendKeysToElement(txtEnterDeptName, "TestDept", "Department Name");
                driver.ClickElement(btnSaveDept, "save button");
                driver.sleepTime(1000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Department", "Failed to Add Department" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Adding Position Template
        /// </summary>

        public void AddPositionTemplate(string agreementName, string today)
        {

            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.WaitElementPresent(btnAccountingForPositionTemp);
                driver.ClickElement(btnAccountingForPositionTemp, "Accounting");
                driver.sleepTime(10000);
                driver.SwitchToFrameByLocator(frameAccoounting);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddPositionTemplate);
                driver.ClickElement(btnAddPositionTemplate, "Add Position Template");
                driver.sleepTime(5000);
                driver.SendKeysToElement(txtPositionTitle, "TestPosition2", "PositionTitle");
                driver.ClickDropdownAndSearchText(ddlAgreement, txtSearchAgreement, agreementName, "DropDownSearchAgreement");
                driver.ClickDropdownAndSearchText(ddlRatetype, txtSearchRatetype, "Standard", "DropDownRateType");
                driver.ClickElement(effectiveDate, "Effective date");
                driver.SendKeysToElementAndPressEnter(effectiveDate, today, "Effective Date");
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.WaitElementPresent(btnSaveTemplatePosition);
                driver.ClickElement(btnSaveTemplatePosition, "SaveTemplatePosition");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add Position Template", " Failed to Add position Template:Exception" + Ex.Message, EngineSetup.GetScreenShotPath());

            }

        }

        /// <summary>
        /// Adding Position Template
        /// </summary>

        public void AddPositionTemplateAndVerify(string agreementName, string today, string folderGroupForContact)
        {

            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.ClickElement(btnAccountingForPositionTemp, "Accounting");
                driver.sleepTime(10000);
                driver.SwitchToFrameByLocator(frameAccoounting);
                driver.ClickElement(btnAddPositionTemplate, "Add Position Template");
                driver.sleepTime(6000);
                driver.SendKeysToElement(txtPositionTitle, "TestPosition", "PositionTitle");
                driver.ClickDropdownAndSearchText(ddlFolderGroup, txtSearchFolderGroup, folderGroupForContact, "FolderGroup");
                driver.ClickElement(ddlFacilityDept, "Facility Dept");
                driver.SendKeysToElementAndPressEnter(ddlFacilityDept, "", "");
                //driver.SendKeysToElement(ddlFacilityDept, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.ClickDropdownAndSearchText(ddlAgreement, txtSearchAgreement, agreementName, "DropDownSearchAgreement");
                driver.ClickDropdownAndSearchText(ddlRatetype, txtSearchRatetype, "Standard", "DropDownRateType");
                driver.ClickElement(effectiveDate, "Effective date");
                driver.SendKeysToElementAndPressEnter(effectiveDate, today, "Effective Date");
                driver.ClickElement(btnSaveTemplatePosition, "SaveTemplatePosition");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add position Template and Verify", "Failed to Add position Template and Verify:Exception" + Ex.Message, EngineSetup.GetScreenShotPath());

            }

        }

        public void AddRates(string payrate,string vendorbillrate,string clientbillrate,string txtClass)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.WaitElementPresent(frameAccountingPv);
                driver.SwitchToFrameByLocator(frameAccountingPv);
                driver.sleepTime(5000);
                driver.ClickElement(lnkRates, "Link Rates");
                driver.sleepTime(5000);
                driver.ClickElement(btnAddNewRate, "Button Add Rates");              
                driver.ClickElement(lnkClass, "Class dropdown");
                driver.sleepTime(2000);
                driver.SendKeysToElement(lnkClass, txtClass, "Class");
                driver.sleepTime(2000);
                driver.SendKeysToElement(lnkClass, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "Class");
                driver.SendKeysUsingActions(candPayRate, payrate, "Payrate");
                driver.SendKeysUsingActions(vendorBillRate, vendorbillrate, "vendorBillRate");
                driver.SendKeysUsingActions(clientBillRate, clientbillrate, "clientBillRate");
                driver.sleepTime(2000);
                driver.ClickElement(btnSaveRate, "Save");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Rates", " Failed to Add Rates" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>        
/// Select PositionTemplate and verify the warning message
        /// </summary>
        public void SelectPostionAndVerify()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framePosition);
                driver.SendKeysToElementOneAtATime(ddlTemplatePosition, "TestPosition2", "Position Template");
                driver.SendKeysToElement(ddlTemplatePosition, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(20000);
                driver.AssertTextEqual(warningDiv, "The agreement associated with the selected position template is invalid because agreement is in an invalid status. Please select a valid agreement.");
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Verify the warning message of selected Position Template", " Failed to Verify the warning message of selected Position Template, Exception" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void CompanyClose()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.ClickElement(btnCloseCompany, "Click on Close button");

            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Close Company", "Failed to Click on Close button of Company", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add Company Mandatory fields
        /// </summary>

        public string AddCompanyMandatoryFields(string companyName, string city, string postalCode, string foldergroup, string companySource)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameCompanyNew);
                driver.ClickElementAndSendKeys(txtCompany, companyName, "Company Name");
                driver.ClickElementAndSendKeys(txtCompanycity, city, "Comapny City");
                driver.SendKeysToElementClearFirst(txtZip, postalCode, "Postal Code");
                driver.SendKeysToElement(folderGroup, foldergroup, "Folder Group");
                driver.ClickElement(ddlCompanySource, "Company Source");
                driver.WaitElementExistsAndVisible(txtCompanySource);
                driver.ClickElement(txtCompanySource, "CompanySource");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save Company");
                driver.sleepTime(25000);
                if (driver.IsElementPresent(txtDuplicateMessage))
                {
                    driver.WaitElementPresent(btnSave);
                    driver.ClickElement(btnSave, "Save Company");
                    driver.sleepTime(10000);
                }

                driver.WaitElementPresent(lblId);
                title = GetCompanyTitle();
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Add company mandatory fields", "Exception occured while Adding company mandatory fields, Exception:" + Ex.Message, EngineSetup.GetScreenShotPath());
            }
            return title;
        }
        /// <summary>
        /// Verify Company Address and other fields
        /// </summary>

        public void VerifyMandatoryFields(string mainAddress, string cityVerify, string zipCode, string countryVerify, string folderGroup, string contactOwner)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameContactNew);
                driver.SwitchToFrameByLocator(frameContactNew);
                driver.sleepTime(5000);
                driver.AssertTextContains(verifyAddress, mainAddress);
                driver.AssertTextContains(verifyAddress, cityVerify);
                driver.AssertTextContains(verifyAddress, zipCode);
                driver.AssertTextContains(verifyAddress, countryVerify);
                driver.AssertTextEqualFromTextBox(verifyFolderGroup, folderGroup);
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.CheckElementExists(txtContactOwner, "Contact Owner name");
                string txtContactOwne = driver.GetElementText(By.XPath("//div[@class='user_menu']/span"));//txtContactOwner
                driver.WaitElementPresent(frameContactNew);
                driver.SwitchToFrameByLocator(frameContactNew);
                driver.sleepTime(5000);
                driver.AssertTextEqualFromTextBox(verifyContactOwner, txtContactOwne);
                // driver.GetElementText
            }
            catch (Exception Ex)
            {

                this.TESTREPORT.LogFailure("Verify company mandatory fields", "Failed to verify company mandatory fields, Exception" + Ex.Message, EngineSetup.GetScreenShotPath());

            }
        }

        public void ManageLogin(bool candidate = false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                if (candidate)
                {
                    driver.sleepTime(10000);
                    driver.WaitElementPresent(frameManageCandidate);                    
                    driver.SwitchToFrameByLocator(frameManageCandidate);
                }
                else
                {
                    driver.sleepTime(10000);
                    driver.WaitElementPresent(frameManageContact);
                    driver.SwitchToFrameByLocator(frameManageContact);
                }
                driver.ScrollPage();
                driver.WaitElementPresent(titleActions);
                driver.VerifyTextValue(lnkManageLogin, "Manage Login Access", "Manage Login");
                driver.ClickElement(lnkManageLogin, "Manage Login");
                driver.WaitElementPresent(lblAccessmgmt);
                //driver.VerifyWebElementPresent(lblAccessmgmt, "Access Management Widget Title");
               // driver.sleepTime(5000);
                //driver.ClickElement(lnkManageLogin, "Manage Login");
               // driver.sleepTime(5000);
               // driver.ClickElement(lnkManageLogin, "Manage Login");
                //driver.sleepTime(5000);
                driver.VerifyWebElementPresent(lblAccessmgmt, "Access Management Widget Title");
                driver.VerifyWebElementPresent(btnGiveAccess, "Give Access Button");
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Manage Login Access", "Failed to Click on Manage login Access", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnGiveAccess()
        {
            try
            {
                driver.ClickElement(btnGiveAccess, "Give Access Button");
                driver.sleepTime(10000);
                driver.ScrollToPageTop();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Give Access", "Failed to Click on Give Access", EngineSetup.GetScreenShotPath());
            }
        }
       
        public void CloseManageLoginAccess()
        {
            try
            {
                driver.ClickElementWithJavascript(btnClose, "Close Button");
                //driver.sleepTime(30000);
                driver.ScrollPage();
                driver.ClickElement(lnkManageLogin, "Manage Login");
                driver.ScrollToPageBottom();
                driver.WaitElementPresent(btnGiveAccess);
            }
            catch (Exception Ex)
            {

                this.TESTREPORT.LogFailure("Close Login Access", "Failed to Close Login Access", EngineSetup.GetScreenShotPath());
            }
        }

        public void GiveAccess(string password)
        {
            try
            {
                driver.VerifyWebElementPresent(txtEmail, "Email Address");
                //driver.SendKeysToElement(txtEmail, "contact@erecruit.com", "Contact Email");
                driver.SendKeysToElement(txtPassword, password, "Password");
                driver.SendKeysToElement(txtConfirmPassword, password, "ConfirmPassword");
                driver.VerifyWebElementPresent(btnGiveAccess, "Give Access Button");
                driver.ClickElement(btnGiveAccess, "Click Give Access");
                driver.sleepTime(10000);
                this.TESTREPORT.LogSuccess("Give Access as Recruiter", "Able to Give Access Successfully");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Give Acces as Recruiter", "Failed to Give Access", EngineSetup.GetScreenShotPath());
            }
        }

        public void ContactGiveAccess(string contactAccessEmail,string password)
        {
            try
            {
                driver.VerifyWebElementPresent(txtEmail, "Email Address");
                driver.SendKeysToElement(txtEmail, contactAccessEmail, "Contact Email Address");
                driver.SendKeysToElement(txtPassword, password, "Password");
                driver.SendKeysToElement(txtConfirmPassword, password, "ConfirmPassword");
                driver.VerifyWebElementPresent(btnGiveAccess, "Give Access Button");
                driver.ClickElement(btnGiveAccess, "Click Give Access");
                driver.sleepTime(10000);
                this.TESTREPORT.LogSuccess("Give Access as Recruiter", "Able to Give Access Successfully");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Give Acces as Recruiter", "Failed to Give Access", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyLoginUserButton()
        {
            try
            {
                // driver.ScrollToPageBottom();
                driver.ScrollPage();
                driver.VerifyWebElementPresent(btnLoginasuser, "Login As User Button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Login As User Button", "Failed to verify Login As User Button", EngineSetup.GetScreenShotPath());
            }
        }

        public void ValidateElements_ManageLogin(string Email)
        {
            try
            {
                driver.sleepTime(20000);
                driver.VerifyWebElementPresent(lblGranted, "Granted");
                driver.VerifyWebElementPresent(btnToggleFed, "Toggle Federation");
                driver.VerifyWebElementPresent(btnRevoke, "Revoke Access");
                driver.VerifyWebElementPresent(lblChangePassword, "Change Password label");
                driver.VerifyWebElementPresent(txtNewPassword, "New Password");
                driver.VerifyWebElementPresent(txtConfrimNewPassword, "Confirm New Password");
                if (driver.IsElementPresent(btnSetnewPassword))
                    this.TESTREPORT.LogSuccess("Verify Set New Password button", "Set New Password button is displayed beneath Change Password label ");
                else
                    this.TESTREPORT.LogFailure("Verify Set New Password button", "Set New Password button is not displayed beneath Change Password label ");
                driver.WaitForElement(lblChangeLoginEmail, TimeSpan.FromSeconds(30));
                driver.VerifyWebElementPresent(lblChangeLoginEmail, "Change Login Email label");
                driver.VerifyWebElementPresent(txtChangeEmail, "Change Email");
                By by = By.XPath(string.Format("//input[@value='{0}']", Email));
                string actualEmail = driver.FindElement(by).GetAttribute("value").ToString();
                driver.AssertTextMatching(actualEmail, Email);
                driver.VerifyWebElementPresent(lblRememberDisplayText, "Remember Display Text");
                driver.VerifyWebElementPresent(lblLastlogged, "Last Logged");
                driver.ScrollToPageBottom();
                driver.sleepTime(20000);
                driver.VerifyWebElementPresent(btnSetnewEmail, "Set New Email");
                driver.VerifyWebElementPresent(lblLoginAs, "Login As");
                driver.VerifyWebElementPresent(txtEnterPassword, "Enter Password");
                driver.VerifyWebElementPresent(btnLoginasuser, "Login As A User");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ValidateElements_ManageLogin", "Failed to Validate Elements in ManageLogin", EngineSetup.GetScreenShotPath());
            }

        }

        public string GetCompanyTitle()
        {
            string contactTitle = null;
            int startIndex = 0;
            try
            {
                contactTitle = driver.GetElementText(lblCompany);
                startIndex = contactTitle.IndexOf("(");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Get Company Title", "Failed to Retrieve Company Title", EngineSetup.GetScreenShotPath());
            }
            return contactTitle.Substring(startIndex + 1, contactTitle.Length - startIndex - 2);

        }

        public void ClickonAccountingTab()
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAccounting);
                driver.ClickElement(btnAccounting, "Click on Accounting tab");
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//span[text()='VMS']"));
                driver.ClickElement(By.XPath("//span[text()='VMS']"), "Click on VMS");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAccounting);
                driver.ClickElement(btnAccounting, "Click on Accounting tab");                
                //driver.WaitElementPresent(By.XPath("//iframe[@id='pvAccounting_frame']"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[@id='pvAccounting_frame']"));
                driver.sleepTime(5000);
                driver.MouseHoverByJavaScript(lblVMS, "Mousehover on VMS board");
                driver.WaitElementPresent(btnEditVMS);
                driver.ClickElementWithJavascript(btnEditVMS, "Click on Edit");
                driver.sleepTime(5000);
                driver.ClickElement(txtVMSburden, "Click on VMS Burden");
                driver.WaitElementPresent(lnkVMSburden);
                driver.ClickElement(lnkVMSburden, "select VMS burden");
                driver.WaitElementPresent(txtWorkerComp);
                driver.ClickElement(txtWorkerComp, "Click on Worker's Comp");
                driver.sleepTime(2000);
                driver.SendKeysToElementAndPressEnter(inputWorkerComp, "TEST-TEST-JZ", "Worker's comp");
                driver.SendKeysToElementAndPressEnter(inputWorkerComp, "CA-Admin", "Worker's comp");
                driver.SendKeysToElementAndPressEnter(inputWorkerComp, "MA-Admin", "Worker's comp");
                driver.SendKeysToElementAndPressEnter(inputWorkerComp, "WA Test", "Worker's comp");
                driver.WaitElementPresent(btnSaveVMS);
                driver.ClickElement(btnSaveVMS, "Click on Save");
                driver.sleepTime(5000);
            }
            catch (Exception E)
            {
                this.TESTREPORT.LogFailure("Edit Accounting Tab", "Failed to Edit Accounting Tab", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyActionStatus(string actionStatus)
        {
            try
            {
                By lblStatus = By.XPath(string.Format("//span[contains(text(),'{0}')]", actionStatus));
                driver.WaitElementPresent(lblActionStatus);
                if (driver.ElementPresent(lblActionStatus, "Action Status"))
                {
                    driver.WaitElementPresent(lblStatus);
                    driver.AssertTextEqual(lblStatus, actionStatus);
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Action Status", "Not able to verify Action Status", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyToggleFederation(string actionType)
        {
            try
            {
                  driver.sleepTime(10000);
                //if (driver.ElementPresent(btnToggleFed, "Toggle Federation"))
                //{
                //this.TESTREPORT.LogSuccess("Toggle Federation Button", "Toggle Federation Button is visible");
                   driver.WaitElementPresent(btnToggleFed);
                    driver.ClickElement(btnToggleFed, "Click Toggle Federation Button");
                    driver.sleepTime(5000);
                    By lblType = By.XPath(string.Format("//span[contains(text(),'{0}')]", actionType));                   
                    driver.WaitElementPresent(lblAccessType);
                    //if (driver.ElementPresent(lblAccessType, "Action Type"))
                    //{
                        driver.WaitElementPresent(lblType);
                        driver.AssertTextEqual(lblType, actionType);
                    //}
                    driver.sleepTime(5000);
                    //driver.VerifyWebElementPresent(btnToggleFed, "Toggle Federation Button");
                    //driver.WaitElementPresent(btnToggleFed);
                    //driver.VerifyWebElementPresent(btnRevoke, "Revoke Access Button");
                    driver.IsElementPresent(btnRevoke);
                   // driver.VerifyWebElementNotPresent(btnGiveAccess, "Give Access Button");
               // driver.IsElementPresent(btnGiveAccess);
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Toggle Federation Button", "Toggle Federation Button is not visible", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyButtonElements_AccessMgmPopup()
        {
            try
            {
                driver.VerifyWebElementPresent(lblActionStatus, "Action Status section is available above Toggle Federation and Give/Revoke Access buttons");
                driver.VerifyWebElementPresent(btnToggleFed, "Toggle Federation Button");
                if (driver.ElementPresent(btnGiveAccess, "Give Access Button"))
                {
                    driver.ElementPresent(btnGiveAccess, "Give Access Button");
                   // driver.VerifyWebElementNotPresent(btnRevoke, "Revoke Access Button");
                    driver.sleepTime(5000);
                }
                else
                {
                   // driver.VerifyWebElementNotPresent(btnGiveAccess, "Give Access Button");
                    driver.sleepTime(5000);
                    driver.VerifyWebElementPresent(btnRevoke, "Revoke Access Button");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Access Management Popup Buttons ", "Failed to find Access Management Popup Buttons ", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickRevokeAccess()
        {
            try
            {
                driver.VerifyWebElementPresent(btnRevoke, "Revoke Button");
                driver.ClickElement(btnRevoke, "Click Revoke Button");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Revoke Button", "Failed to click Revoke Button ", EngineSetup.GetScreenShotPath());
            }
        }

        public void EditContactMethod(string mainPhone, string communicationValue, string communicationNote)
        {
            try

            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                //By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitElementPresent(by);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(tblCommunication);
               // ExpectedConditions.ElementIsVisible(tblCommunication);
               IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                //ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id,'_editmode')]/table/tbody/tr"));
                int count = 0;
  
                foreach (IWebElement row in tableRow)
                {                  
                    //ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id,'_editmode')]/table/tbody/tr"));                  
                    if (row.Text.Contains(mainPhone) && row.Text.Contains(communicationValue) && row.Text.Contains(communicationNote))
                    {
                        count++;
                    }

                }
                if (count >= 2)
                    TESTREPORT.LogSuccess("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
                else
                    TESTREPORT.LogFailure("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is not added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
                driver.ClickElement(btnAccessManagementClose, "Close Button");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Communication values", "Failed to add Communication Values", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyDefaultTypeMarked(string mainPhone, string communicationValue, string communicationNote)
        {
            try
            { 
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);               
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.WaitElementPresent(txtCommunicationValue);
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                By btnStar = By.XPath(string.Format("//div[text()='{0}']/..//following::td[3]/button[@title='This is the primary method of communication within its category']", mainPhone));
                if (driver.ElementPresent(btnStar, "Default star button"))
                {
                    TESTREPORT.LogSuccess("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is marked as default for the first time", mainPhone));
                }
                else
                {
                    TESTREPORT.LogFailure("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is not marked as default", mainPhone));
                }
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAccessManagementClose);
                driver.ClickElement(btnAccessManagementClose, "Close Button");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Communication values", "Failed to add Communication Values", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyDisplayPhoneNumber(string mainPhone, string communicationValue)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(1000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                By phoneNumber = By.XPath(string.Format("//div[contains(@id,'_editmode')]//td[2]/div[contains(text(),'{0}')]", communicationValue));
                string phoneNumberValue = driver.GetElementText(phoneNumber);
                bool result = utility.isAlphaNumeric(phoneNumberValue);
                if (result == true)
                {
                    TESTREPORT.LogSuccess("Verify Phone Number", string.Format("mainPhone : <Mark>{0}</Mark> accepts alphanumeric value", mainPhone));
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Phone Number", string.Format("mainPhone : <Mark>{0}</Mark> doesn't accepts alphanumeric value", mainPhone));
                }
                driver.ClickElement(btnPopupClose, "Close Button");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Phone Number", "Failed to Verify Phone Number", EngineSetup.GetScreenShotPath());
            }
        }

        public void AddRequirementToCompany(string reqname)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.WaitElementPresent(btnCompanyRequirement);
                driver.ClickElement(btnCompanyRequirement, "Company Requirement");
                driver.sleepTime(15000);
                driver.WaitElementPresent(ddnCompanyRequirement);
                driver.ClickElement(ddnCompanyRequirement, " Requirement dropdown");
                driver.WaitElementPresent(ddnRequirementInput);
                driver.SendKeysToElementAndPressEnter(ddnRequirementInput, reqname, " Requirement Input");
                driver.WaitElementPresent(btnAddRequirement);
                driver.ClickElement(btnAddRequirement,"Add Requirement");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Requirement To Company", "Failed to Add Requirement To Company", EngineSetup.GetScreenShotPath());
            }
        }

        #endregion
    }
}

