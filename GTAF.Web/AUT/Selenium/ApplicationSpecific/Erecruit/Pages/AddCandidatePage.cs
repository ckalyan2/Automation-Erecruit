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
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class AddCandidatePage : AbstractTemplatePage
    {
        public static string id = "";
        Utility utility = new Utility();

        #region UI Object Repository

        private By frameAddCandidate = By.XPath("//iframe[contains(@id,'candidate_new')]");
        private By txtFirstName = By.Id("ctl00_cphMain_Address_txtFName");
        private By txtLastName = By.Id("ctl00_cphMain_Address_txtLName");
        private By txtLastNameField = By.Name("ctl00$cphMain$Address$txtLName");
        private By ddlCandidateSource = By.XPath("//input[@id='AdSourceDropdown_ddladsource']");
        private By txtCandidateSource = By.XPath("//ul/li/a[text()='Admin Source']");
        private By ddlFolderGroup = By.Id("ctl00_cphMain_ddlFolderGroup_Input");
        private By txtFolderGroup = By.XPath("//div/ul/li[{0}]");
        private By ddlCandidateOwner = By.Id("ctl00_cphMain_ddlCandidateOwner_Input");
        private By txtMainphone = By.XPath("//input[@id='ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl01_txtValue']");
        private By txtEmail = By.XPath("//input[@id='ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl03_txtValue']");
        private By btnNext = By.Id("ctl00_cphMain_btnNext_input");
        private By btnNotaduplicate = By.Id("ctl00_cphMain_btnNext_input");
        private By lblcompanytid = By.XPath("//div[@id='pagetitle']/h1");
        private By lblCandidatetId = By.XPath("//div[@id='pagetitle']/h1");
        private By ddlState = By.Id("ctl00_cphMain_Address_ddlState_Input");
        private By txtState = By.XPath("//html//form/div[@class='rcbSlide']/div/div[@class='rcbScroll rcbWidth']/ul/li[text()='Massachusetts']");

        private By lblTags = By.XPath("//div[contains(@id,'widget_tags')]/div[@class='widgetBody']/div[2]");
        private By btnTagsedit = By.XPath("//div[@class='editbutton clicktip']");
        private By btnGeneraledit = By.XPath("//div[@id='ctl00_namePanel']/h5/span");
        private By txtNewtag = By.XPath("//div[@class='tags-selector']/div/ul/li/input");//By.XPath("//div[@id='s2id_autogen3']/ul/li/input");
        private By btnSave = By.XPath("//button[@class='save ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");

        private By btnAddNote = By.Id("btnAddNewNote");
        private By ddlNoteAction = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[3]//div[@class='form-group group row']/div[2]//label[text()='Note Action']/../div[1]/a");
        //private By txtNoteAction = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By txtNoteAction = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']//div/input");       
        private By ddlStartingTemplate = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[3]//div[@class='form-group group row']/div[2]//label[text()='Starting Template']/../div[1]/a");
        private By btnNoteSave = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[3]//footer[@class='widgetfooter']//div[@class='buttons']//button[text()='Save']");
        private By btnRefresh = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input");

        private By btnAddSchedule = By.XPath("//span[@id='btnAddNewScheduledItem']/img");
        private By ddlItemType = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[3]//div[@class='form-group group row']/div[1]//div[@class='widgetSection']//label[text()='Item Type']/../div[1]/a");
        private By ddlScheduleStartingTemplate = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[3]//div[@class='form-group group row']/div[1]//label[text()='Starting Template']/../div[1]/a");
        private By btnAddTask = By.XPath("//span[@id='btnAddNewNote']/../span[3]/img");

        private By lblStatusPanel = By.XPath(".//*[@id='ctl00_statusPanel']");
        private By btnStatusEdit = By.XPath(".//*[@data-tipname='candidate/status']");
        private By txtStatusValue = By.XPath(".//div[@id='ctl00_statusEditPanel']/input");
        private By ddnList = By.XPath(".//*[starts-with(@id, 'ui-id')]/li");
        private By btnStatusSave = By.XPath(".//*[starts-with(@id, 'widget_status')]/span[2]");
        private By btnCloseStatus = By.XPath(".//div[@class='t_Tooltip t_Tooltip_erecruitDefault'][1]/div[5]/div/div[2]/canvas");
        private By UpdateTerminationdate = By.XPath("//div[@id='ctl00_terminationDateEditPanel']/h5//following-sibling::img");
        private By Terminationdate = By.XPath("//div[@id='ctl00_terminationDateEditPanel']/h5//following-sibling::input");
        private By SaveOnGeneralEdit = By.XPath("//div[@id='ctl00_pnlCustomFieldsEdit']/../following-sibling::div/span/button");
        private By TerminationDate = By.XPath("//div[@id='ctl00_terminationDatePanel']/h5");
        private By btnEditGeneral = By.XPath("//div[@data-tipname='candidate/general']");
        private By btnLoginAsUser = By.XPath("//span[text()='Login As User']");
        private By imgRequired = By.XPath("//span[text()='State/Province']//following-sibling::img");
        //By.XPath("//*[@id='ctl00_cphMain_Address_hpState']/h5/img");
        private By lnkHeader = By.XPath("//div[@class='user_menu']");
        private By lnkSchedule = By.XPath("//a[text()='My Schedule']");
        private By frameSchedule = By.XPath("//iframe[contains(@id,'scheduling_candidateavailability')]");
        private By btnCloseschedule = By.Id("ctl00_cphMain_btnClose_input");
        private By lnkChangePassword = By.XPath("//a[text()='Change Password']");
        private By frameProfilePassword = By.Id("profile_changepassword");
        private By txtCurrentPassword = By.Id("ctl00_cphMain_pwdChange_ChangePasswordContainerID_CurrentPassword");
        private By txtNewPassword = By.Id("ctl00_cphMain_pwdChange_ChangePasswordContainerID_NewPassword");
        private By txtConfirmNewPassword = By.Id("ctl00_cphMain_pwdChange_ChangePasswordContainerID_ConfirmNewPassword");
        private By btnChangePassword = By.Id("ctl00_cphMain_pwdChange_ChangePasswordContainerID_btnChangePassword_input");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By lnkPermissions = By.XPath("//span[text()='Permissions']");
        private By txtAddPermissions = By.Id("ctl06_ddlAddPermission_Input");
        private By lblManageAPI = By.XPath("//td[text()='Manage API Permissions']");
        private By lblMangeRename = By.XPath("//td[text()='Mange API Permissions']");
        private By framePvPermission = By.XPath("//iframe[@id='pvPermissions_frame']");


        #region AddContact
        private By frameManage = By.XPath("//iframe[contains(@id,'company_manage_')]");
        private By FrameNewContact = By.XPath("//iframe[contains(@id,'contact_new')]");
        private By FrameManageContact = By.XPath("//iframe[contains(@id,'contact_manage')]");
        private By btnAddContact = By.Id("btnAddNewContact");
        private By txtFName = By.Id("ctl00_cphMain_txtFName");
        private By txtLName = By.Id("ctl00_cphMain_txtLName");
        private By txtCity = By.Id("ctl00_cphMain_ucAddress_txtCity");
        private By ddlCompany = By.Id("ctl00_cphMain_ddlCompany_Input");
        private By txtCompany = By.XPath("//div[@id='ctl00_cphMain_ddlCompany_DropDown']/div[1]/ul/li[2]");
        private By txtTitle = By.Id("ctl00_cphMain_txtTitle");
        private By ddlSource = By.XPath("//input[@id='AdSourceDropdown_ddladsource']");
        private By txtSource = By.XPath("//ul/li/a[text()='Admin Source']");
        private By txtPhone = By.Id("ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl01_txtValue");
        private By txtEmailcontact = By.Id("ctl00_cphMain_ucCommunicationMethods_rptEdit_ctl03_txtValue");
        private By btnSavecontact = By.XPath("//input[@name='ctl00$cphMain$btnSave_input']");
        private By btnSaveAndClose = By.XPath("//input[contains(@id,'cphMain_cphBottomButtons_btnSaveClose_input')]");

        //private By btnSaveconfirm =By.XPath("//span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input' and @value='Save']");
        //private By btnSavecontact = By.Id("ctl00_cphMain_btnSave");
        //private By btnSaveconfirm =By.XPath("//span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input' and @value='Save'");//By.XPath("//input[contains(@value,'Save') and @id='ctl00_cphMain_btnSave_input']");//By.XPath("//div[@class='bottombuttons']/span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input']");//By.XPath("  //div[@class='bottombuttons']/span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input']");
        private By btnSaveconfirm = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnSaveClose_input");//By.XPath("//div[@class='bottombuttons']/span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input']");//By.XPath("  //div[@class='bottombuttons']/span[@id='ctl00_cphMain_btnSave']/input[@id='ctl00_cphMain_btnSave_input']");
        private By lblcontactid = By.XPath("//div[@id='pagetitle']/h1");
        private By lblCompany = By.XPath(".//div[@id='pagetitle']/h1");
        private By lnkStatus = By.Id("ctl00_statusPanel");
        private By btnSaveClose = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnSaveClose_input");//By.XPath("//div[@id='ctl00_ctl00_cphMain_cphBottomButtons_upButtons']/span[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnSaveClose']/input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnSaveClose_input']");
        private By btnClose = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnClose_input");
        private By iframeCandidateinMatch = By.XPath("//iframe[contains(@id,'match_manage')]");
        private By iframeCandidateMatch = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By lnkCandidateMatch = By.XPath("//div[contains(@id,'wrapper_widget_relatedlinks')]//span[@data-tipcontext='candidate']");
        private By btnRefreshCandidate = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input']");
        private By cbxContactType = By.Id("ctl00_cphMain_ddlContactType_Input");
        private By txtQuickSearch = By.XPath("//input[@id='ctl00_txtQuickSearch']");
        private By btnSearch = By.XPath("//span[@id='ctl00_xpnlHeader']//input[2]");
        private By imgEdit = By.XPath("//span[@id='editbuttoncomm']/img");
        private By contactWidgetTitle = By.XPath("//div[text()='Edit Communication Methods']");
        private By ddnCommunicationType = By.XPath("//input[contains(@id,'widget_communicationlist_') and @class='ui-autocomplete-input' and @data-selectedvalue='201']");
        private By txtCommunicationValue = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtvalue')]");
        private By txtCommunicationNote = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtnote')]");
        private By btnAddCommunication = By.XPath("//button[contains(@id,'_AddCommunication') and @title='Click to add this communication']");
        private By tblCommunication = By.XPath("//div[contains(@id,'_editmode')]/table/tbody");
        private By btnPopupClose = By.XPath("//div[@class='t_CloseButtonShift']//canvas");
        private By btnEdit = By.XPath("//div[@id='editbutton' and @title='Click to edit' and @data-tipname='candidate/lookingfor']");
        private By lblLookingFor = By.XPath("//div[@id='ctl00_lookingForPanel']/h5/span[text()='Looking For']");
        private By txtAmountPayable = By.XPath("//*[@id='ctl00_desiredAnnualRateEditPanel']/input[2]");
        //By.XPath("//div[@id='ctl00_AmountPayable_inputcontent']//input[2]");
        private By ddlContractorType = By.XPath("//input[contains(@id,'ddlcontractortype')]");
        private By btnSaveLookingFor = By.XPath("//button[contains(@id,'btnsave')]");
        private By lblAmountPayable = By.XPath("//*[@id='ctl00_desiredAnnualRatePanel']");
        //By.XPath("//div[@id='ctl00_AmountPayable']");
        private By lblName = By.XPath("//div[@id='ctl00_namePanel']");
        private By btnGeneralEdit = By.XPath("//div[@id='editbutton' and @title='Click to edit' and @data-tipname='candidate/general']");
        private By txtMoney = By.XPath("//div[@id='ctl00_MoneyField_inputcontent']//input[2]");
        private By btnSaveGeneral = By.XPath("//button[contains(@id,'widget_general') and contains(@id,'btnsave')]");
        private By lblMoney = By.XPath("//*[@id='ctl00_MoneyField']");
        private By ddlCompanySource = By.Id("AdSourceDropdown_ddladsource");
        private By txtCompanySource = By.XPath("//ul/li/a[text()='Admin Source']");
        //--Verify the fistName of the candidate
.
        private By lblCandidateFname = By.XPath("//h1[@title='Candidate']");
        #endregion

        private By lblNote = By.XPath("//a[@class='rtsLink rtsAfter']/span/span/img//following-sibling::span");
        private By inputStatus = By.XPath("//ul/li/a[text()='Available']");
        //Verify attachment widget 
        private By frameDashboard = By.XPath("//iframe[@id='dashboard']");
        private By lblAttachmentMain = By.XPath("//div[contains(@id,'ctl00_cphMain_RadDock')]/em[contains(text(),'Attachments')]");
            //By.XPath("//div[@id='ctl00_cphMain_RadDock5061_T']//following-sibling::em");
        private By lnkRequirements = By.XPath("//table[contains(@id,'_attachmentsTable')]//following-sibling::table/tbody/tr[1]/td[5]");

        //Verify Manage Login Access
        private By lnkManageLoginAccess = By.XPath("//div[@title='Manage Login Access']");
        private By txtPassword = By.XPath("//h5[contains(text(),'Enter Your Password:')]//following-sibling::input");
        private By verifyAttachmentWidget = By.XPath("//div[@id='ctl00_cphMain_RadDock6632_T']//following-sibling::em");
        private By verifyRequirement = By.XPath("//p/span[contains(text(),'to upload requirement attachments and make payments on your behalf.')]");
            //By.XPath("//table[@class='tablesorter']//tbody/tr[1]/td[5]");

        //Verify Candidate history
        private By btnHistory = By.XPath("//span[text()='History']");
        private By framePvHistory = By.XPath("//iframe[contains(@id,'pvHistory_frame')]");
        private By lnkHistory = By.XPath("//a[text()='History']/..");
        private By lnkStatusTransitions = By.XPath("//a[text()='Status Transitions']/..");
        private By statusContent = By.XPath("//th[text()='Time']");
        private By lnkAccessLog = By.XPath("//a[text()='Access Log']");
        private By AccessLogContent = By.XPath("//th[text()='Time']");
        private By historyContent = By.XPath("//span[text()='Before']");
        //Navigate to add candidate
        private By logoMenu = By.XPath("//div[@class='logo_inner']");
        private By lnkAddnew = By.XPath("//span[text()='Add New']");
        private By lnkCandidate = By.XPath("//span[text()='Candidate']");
        private By lnkWithoutresume = By.XPath("//span[text()='Without Resume']");
        private By frameCandidateSearch = By.XPath("//iframe[contains(@id,'candidate')]");
        private By newframeCandidateSearch = By.XPath("//iframe[@src='..//Search/candidate/']");
        private By btnClearAllFilter = By.XPath("//div[@data-bind='control: EditorPopup']/a[text()='Clear Items' and @class='clear-filters']");
        private By txtStatusFilter = By.XPath("//div[@class='status-filter Display']/label");
        private By btnNewMatch = By.XPath("//div[text()='New Match']");
        private By frameMatchCandidate = By.XPath("//iframe[contains(@id,'match_new_candidateid')]");
        private By btnSearch1 = By.XPath("//input[@value='Search']");
        private By lnkCreateMatchFor = By.XPath("//div[@id='commands_section']//span[text()='Create Matches For']");
        //Create Match from right click
        private By lnkMatch = By.XPath("//span[@data-tipname='matchlist']");
        private By lnkNewMatch = By.XPath("//div[text()='New Match']"); private By searchCompanies = By.XPath("//span[text()='Companies']");
        private By txtCompaniesName = By.XPath("//span[text()='Companies']/div/div/div/following-sibling::input");
        private By Candidates = By.XPath("//span[text()='Candidates']");
        private By txtCandidateName = By.XPath("//span[text()='Candidates']/div/div/div/following-sibling::input");
        private By txtPositionIdRecruiter = By.XPath("//div[@id='topmenu']//ul/li[1]/div/ul/li[4]/span//input");
        private By btnAddNewMatch = By.XPath("//button[@id='btnAddNewMatch']");
        private By frameManageCompany = By.XPath("//iframe[contains(@id,'company_manage')]");
        private By ddlContacttype = By.XPath("//input[@name='ctl00$cphMain$ddlContactType']");
        private By txtContacttype = By.XPath("//ul/li[text()='test']");
        private By txtContactDuplicates = By.Id("ctl00_cphMain_pnlDuplicates");
        private By btnContactsave = By.XPath("//div[@id='ctl00_cphMain_upNewCompany']/div[@class='bottombuttons']/span[@id='ctl00_cphMain_btnSave']");
        private By lblId = By.XPath("//div[@id='pagetitle']/h1");
        private By txtStartingTemplate = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active'][2]/div/input");
        #region Public Methods

        /// <summary>
        /// Method to step verify Information 
        /// </summary>
        public void AddCandidatewithoutResume(string candidateName, int Id, string mailId)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameAddCandidate);
                driver.SwitchToFrameByLocator(frameAddCandidate);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtFirstName);
                driver.SendKeysToElementClearFirst(txtFirstName, candidateName, "First Name");
                driver.WaitElementPresent(txtLastName);
                driver.SendKeysToElementClearFirst(txtLastName, candidateName, "Last Name");
                driver.ScrollToPageBottom();
                driver.WaitElementPresent(ddlState);
                //driver.sleepTime(10000);
                driver.ClickElement(ddlState, "State");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlState);
                driver.ClickElement(txtState, "State");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlCandidateSource);
                driver.ScrollToPageTop();
                driver.WaitElementPresent(ddlCandidateSource);
                driver.ClickElement(ddlCandidateSource, "Candidate Source-RC");
                driver.WaitElementPresent(txtCandidateSource);
                driver.ClickElement(txtCandidateSource, "Candidate Source");
                driver.WaitElementPresent(ddlFolderGroup);
                driver.ClickElement(ddlFolderGroup, "Folder Group");
                string txtFldr = string.Format("//div/ul/li[{0}]", Id);
                var txtGroup = By.XPath(txtFldr);
                driver.ClickElement(txtGroup, "Folder Group");
                driver.WaitElementPresent(txtMainphone);
                driver.SendKeysToElementClearFirst(txtMainphone, Utility.GenerateMobileNumber(), "Phone Number");
                driver.WaitElementPresent(txtEmail);
                driver.SendKeysToElementClearFirst(txtEmail, mailId, "Email");
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(15000);
                By by = By.XPath("//h2[contains(text(),'Potential Duplicates Found')]");
                By btnNotDuplicate = By.XPath("//input[@id='ctl00_cphMain_btnNext_input' and @value='Not a Duplicate']");
                if (driver.FindElements(by).Count > 0)
                {
                    //driver.sleepTime(5000);
                    driver.WaitElementPresent(btnNotDuplicate);
                    driver.ClickElement(btnNotDuplicate, "Click Not a Duplicate");
                }
                driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
                id = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Candidate", "Failed to Add candidate", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add candidate without Resume using mandatory fields
        /// </summary>
        /// <param name="name"></param>
        /// <param name="foldergroup"></param>
        /// <param name="mailId"></param>
        public void AddcandidateMandatoryWithoutResume(string name, string foldergroup, String mailId)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameAddCandidate);
                driver.SendKeysToElementAndPressEnter(txtFirstName, name, "First Name");
                driver.SendKeysToElementAndPressEnter(txtLastNameField, name, "Last Name");
                driver.sleepTime(5000);
                driver.ScrollToPageBottom();
                driver.WaitElementPresent(ddlState);
                driver.ClickElement(ddlState, "State");
                driver.WaitElementPresent(txtState);
                driver.ClickElement(txtState, "State");
                driver.sleepTime(5000);
                driver.ScrollToPageTop();
                driver.WaitElementPresent(ddlCompanySource);
                driver.ClickElement(ddlCompanySource, "Company Source");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCompanySource);
                driver.ClickElement(txtCompanySource, "CompanySource");
                driver.WaitElementPresent(ddlFolderGroup);
                driver.ClickElement(ddlFolderGroup, "Folder Group");
                driver.SendKeysToElementAndPressEnter(ddlFolderGroup, foldergroup, "Folder Group");
                driver.SendKeysToElementClearFirst(txtEmail, mailId, "Email");
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add candidate Mandatory WithoutResume", "Failed to Add candidate Mandatory WithoutResume ", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Verify candidate name with accent char
        /// </summary>
        /// <param name="candidateName"></param>
        public void VerifyCandidateNameWithAccentedChar(string candidateName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(lblCandidateFname);
                driver.AssertTextContains(lblCandidateFname, candidateName);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Candidate Name WithAccented Char", "Failed to Verify Candidate Name WithAccented Char ", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lblAttachment"></param>
        public void VerifyAttachmentWidget(String lblAttachment)
        {
            try
            {
                driver.sleepTime(5000);
                //driver.WaitElementPresent(frameDashboard);
                //driver.SwitchToFrameByLocator(frameDashboard);
                driver.ScrollToPageBottom();
                driver.CheckElementExists(lblAttachmentMain, "Attachment wedget");
                driver.AssertTextContains(lblAttachmentMain, lblAttachment);
                driver.CheckElementExists(lnkRequirements, "link Requirement");
                driver.WaitElementPresent(lnkRequirements);
                driver.ClickElement(lnkRequirements, "link Requirement");
                this.TESTREPORT.LogSuccess("Requirement Link", "Requirement link clicked but not accessible by Candidate");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Requirement Link", "Requirement link is accessible by Candidate", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyCandidateHistory()
        {
            try
            {
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.ClickElement(btnHistory, "History Tab");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.SwitchToFrameByLocator(framePvHistory);
                driver.AssertTextContains(lnkStatusTransitions, "Status Transitions");
                driver.AssertTextContains(lnkAccessLog, "Access Log");
                driver.sleepTime(20000);
                driver.ClickElement(lnkStatusTransitions, "Status transitions");
                driver.sleepTime(20000);
                driver.CheckElementExists(statusContent, "Status Transaction Data");
                driver.ClickElement(lnkAccessLog, "Access Log");
                driver.sleepTime(20000);
                driver.CheckElementExists(AccessLogContent, "Access log");
                driver.ClickElement(lnkHistory, "History Tab");
                driver.sleepTime(20000);
                driver.CheckElementExists(historyContent, "History Table");
                this.TESTREPORT.LogSuccess("Candidate History", "Candidate History Verified Successfully");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate History", "Candidate History Failed To Verify", EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// verifies Added Attachments are displayed under Candidate Dashboard widget (Attachments)
        /// </summary>
        public void VerifyAttachment(string candidatePswd)
        {
            try
            {
                driver.WaitElementPresent(frameManageCandidate);
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.sleepTime(5000);
            driver.WaitElementPresent(lnkManageLoginAccess);
            driver.ClickElement(lnkManageLoginAccess, "Manage Login Access");
            driver.SendKeysToElement(txtPassword, candidatePswd, "Enter Password");
                driver.WaitElementPresent(btnLoginAsUser);
                driver.ClickElement(btnLoginAsUser, "Login As User");
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
                driver.WaitElementPresent(frameDashboard);
                driver.SwitchToFrameByLocator(frameDashboard);
            //driver.FindElement(verifyAttachmentWidget);
            //driver.CheckElementExists(verifyRequirement, "link Requirement");
                driver.WaitElementPresent(verifyRequirement);
                driver.VerifyWebElementPresent(verifyRequirement, "link Requirement");
                this.TESTREPORT.LogSuccess("Requirement Link", "Requirement link clicked but not accessible by Candidate");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Requirement Link", "Requirement link is accessible by Candidate", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Click on Not a Duplicate Button
        /// </summary>
        public void Clickonclose()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.ClickElement(btnClose, "Close Candidate");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Close", "Failed Add Candidate:", EngineSetup.GetScreenShotPath());
            }

        }
        public void EnterTerminationDate(bool delete = false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(By.XPath("//iframe[@class='active']"));
                driver.MouseHoverByJavaScript(btnGeneraledit, "Click on Edit button under General");
                driver.ClickElementWithJavascript(btnEditGeneral, "Click on Edit button at General Section");
                //driver.ClickElement(UpdateTerminationdate, "Click on Update Termination Date button");
                string currentdate = driver.GetElementText(Terminationdate);
                string terminationDate1 = System.DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
                string terminationDate2 = System.DateTime.Now.AddDays(25).ToString("dd/MM/yyyy");
                if (currentdate != terminationDate1)
                {
                    driver.SendKeysToElementAndPressEnter(Terminationdate, terminationDate1, "Termination date");
                }
                else
                {
                    driver.SendKeysToElementAndPressEnter(Terminationdate, terminationDate2, "Termination date");
                }
                if (delete)
                {
                    string date = driver.GetElementText(Terminationdate);
                    if (string.IsNullOrEmpty(date))
                    {
                        Console.WriteLine("Termination Date field is empty");
                    }
                    else
                    {
                        driver.FindElement(Terminationdate).Clear();
                    }
                }
                driver.ClickElement(SaveOnGeneralEdit, "Click on Update Termination Date button");
                // string date = driver.GetElementText(TerminationDate);
                //driver.ClickElement(btnClose, "Close Candidate");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("EnterTerminationDate", "Failed to Enter Termination Date", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Method to click on Edit button under Tags
        /// </summary>
        public void ClickonTagsEdit(int id)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                Thread.Sleep(3000);
                // driver.SwitchToFrameByIndex(id);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.MouseHoverByJavaScript(btnTagsedit, "Click on Edit button under Tags");
                driver.WaitElementPresent(btnTagsedit);
                driver.ClickElementWithJavascript(btnTagsedit, "Click on Edit button under Tags");
                //driver.sleepTime(5000);               
                driver.WaitElementPresent(txtNewtag);
                driver.ClickElementWithJavascript(txtNewtag, "New Tag");
                driver.SendKeysToElementAndPressEnter(txtNewtag, "New Tag", "New Tag");
                //driver.sleepTime(3000);
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Click on Save button");
                driver.sleepTime(10000);
                By by = By.XPath("//span[text()='New Tag']");
                driver.VerifyWebElementPresent(by,"New tag created");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Edit", "Failed to Click on Edit button", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Method to Add new Note from Right Pane
        /// </summary>
        public void AddNote(string task, string note)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lblNote);
                string act = driver.GetElementText(lblNote);
                driver.ClickElement(btnAddNote, "Add Note");
                driver.WaitElementPresent(ddlNoteAction);
                driver.ClickElement(ddlNoteAction, "Note Action Clicking");
                driver.SendKeysToElementAndPressEnter(txtNoteAction, note, "Note Action Selection");
                driver.ClickElement(ddlStartingTemplate, "Starting Template");
                driver.SendKeysToElementAndPressEnter(txtStartingTemplate, task, "Starting template Selection");
                driver.WaitElementPresent(btnNoteSave);
                driver.ClickElement(btnNoteSave, "Save Note button");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh Button");
                driver.sleepTime(20000);
                string exp = driver.GetElementText(lblNote);
                Assert.AreNotEqual(exp, act);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add a Note", "Failed to Add a Note", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Add new schedule from Right Pane
        /// </summary>
        public void AddSchedule(string task, string schedule)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddSchedule);
                driver.ClickElement(btnAddSchedule, "Add Schedule");
                driver.WaitElementPresent(ddlItemType);
                driver.ClickElement(ddlItemType, "Item Type");
                driver.SendKeysToElementAndPressEnter(txtNoteAction, schedule, "Item Type Selection");
                driver.WaitElementPresent(ddlScheduleStartingTemplate);
                driver.ClickElement(ddlScheduleStartingTemplate, "Starting Template");
                driver.SendKeysToElementAndPressEnter(txtStartingTemplate, task, "Template Selection");
                driver.WaitElementPresent(btnNoteSave);
                driver.ClickElement(btnNoteSave, "Save");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh Button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Schedule", "Failed to Add a Schedule", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Add new Task from Right Pane
        /// </summary>
        public void AddTask(string task)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddTask);
                driver.ClickElement(btnAddTask, "Add Task");
                driver.WaitElementPresent(ddlScheduleStartingTemplate);
                driver.ClickElement(ddlScheduleStartingTemplate, "Starting Template");
                driver.WaitElementPresent(txtNoteAction);
                driver.SendKeysToElementAndPressEnter(txtNoteAction, task, "Template Selection");
                driver.WaitElementPresent(btnNoteSave);
                driver.ClickElement(btnNoteSave, "Save");
                //driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefresh);
                //driver.sleepTime(5000);
                driver.ClickElement(btnRefresh, "Refresh Button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add a task", "Failed to Add a task", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Add contact for Recruiter
        /// </summary>
        public void AddContact(string name)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(FrameNewContact);
                driver.SwitchToFrameByLocator(FrameNewContact);
                driver.sleepTime(10000);
                driver.SendKeysToElement(txtFName, name, "FirstName");
                driver.WaitElementPresent(txtLName);
                driver.SendKeysToElement(txtLName, name, "LastName");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddContact", "Failed to Add Contact", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Add and save contact complete
        /// </summary>
        public void AddAndSaveContact(string name, string title, string email)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                driver.WaitElementPresent(FrameNewContact);
                driver.SwitchToFrameByLocator(FrameNewContact);
                driver.SendKeysToElement(txtFName, name, "FirstName");
                driver.SendKeysToElement(txtLName, name, "LastName");
                driver.SendKeysToElement(txtTitle, title, "Title");
                driver.ClickElement(ddlSource, "Admin Source");
                driver.ClickElement(txtSource, "Source");
                driver.WaitElementPresent(ddlContacttype);
                driver.ClickElement(ddlContacttype, "Contact type");
                driver.ClickElement(txtContacttype, "Contact type text");
                driver.SendKeysToElementClearFirst(txtMainphone, Utility.GenerateMobileNumber(), "Phone Number");
                driver.FindElement(txtEmailcontact).Clear();
                driver.SendKeysToElement(txtEmailcontact, email, "Email");
                driver.VerifyWebElementPresent(btnSavecontact, "Click Save Button");
                driver.ClickElement(btnSavecontact, "Save Button");
                driver.sleepTime(15000);
                //driver.WaitElementPresent(txtContactDuplicates);              
                if (driver.FindElements(txtContactDuplicates).Count > 0)
                {
                    //driver.sleepTime(5000);
                    driver.WaitElementPresent(btnContactsave);
                    driver.ClickElement(btnContactsave, "Click Not a Duplicate");
                }
                driver.sleepTime(10000);
                id = utility.GetTitleId();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                //driver.WaitElementPresent(FrameManageContact);
                //driver.SwitchToFrameByLocator(FrameManageContact);
                //driver.ClickElement(btnSaveClose, "Save complete");
                //driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddAndSaveContact", "Failed to Add and Save Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Simple Add contact
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="email"></param>
        public void AddContact(string name, string title, string email)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(FrameNewContact);
                driver.SendKeysToElement(txtFName, name, "FirstName");
                driver.SendKeysToElement(txtLName, name, "LastName");
                driver.SendKeysToElement(txtTitle, title, "Title");
                driver.ClickElement(ddlSource, "Admin Source");
                driver.ClickElement(txtSource, "Source");
                driver.SendKeysToElementClearFirst(txtMainphone, Utility.GenerateMobileNumber(), "Phone Number");
                driver.FindElement(txtEmailcontact).Clear();
                driver.SendKeysToElement(txtEmailcontact, email, "Email");
                driver.VerifyWebElementPresent(btnSavecontact, "Click Save Button");
                driver.ClickElement(btnSavecontact, "Save Button");
                driver.sleepTime(20000);
                id = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddContact", "Failed to Add Contact", EngineSetup.GetScreenShotPath());
            }
        }
        public void SaveContactFromCompay(string name, string title)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManage);
                driver.ClickElement(btnAddContact, "Add button");
                //driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(FrameNewContact);
                driver.SendKeysToElement(txtFName, name, "FirstName");
                driver.SendKeysToElement(txtLName, name, "LastName");
                driver.SendKeysToElement(txtTitle, title, "Title");
                driver.ClickElement(ddlSource, "Admin Source");
                driver.ClickElement(txtSource, "Source");
                driver.SendKeysToElementClearFirst(txtMainphone, Utility.GenerateMobileNumber(), "Phone Number");
                driver.VerifyWebElementPresent(btnSavecontact, "Click Save Button");
                driver.ClickElement(btnSavecontact, "Save Button");
                driver.sleepTime(20000);
                //driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByLocator(FrameManageContact);
                //driver.ClickElement(btnSavecontact, "Save and close");
                //driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.ClickElement(btnSaveClose, "Save complete");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Save Contact From Compay", "Failed to Save Contact From Compay", EngineSetup.GetScreenShotPath());
            }
        }

        public void AddCompanytoContact(string city)
        {
            try
            {
                driver.WaitElementPresent(txtCity);
                driver.SendKeysToElement(txtCity, city, "City");
                driver.WaitElementPresent(ddlCompany);
                driver.ClickElement(ddlCompany, "CompanyName");
                driver.WaitElementPresent(txtCompany);
                driver.ClickElement(txtCompany, "Company");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Company to Contact", "Failed to Add Company to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        public void Addtitletocontact(string title)
        {
            try
            {
                driver.WaitElementPresent(txtTitle);
                driver.SendKeysToElement(txtTitle, title, "Title");
                driver.ClickElement(ddlSource, "Admin Source");
                driver.WaitElementPresent(txtSource);
                //driver.sleepTime(5000);
                driver.ClickElement(txtSource, "Source");
                driver.SendKeysToElement(ddlSource, OpenQA.Selenium.Keys.Tab, "");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Title to Contact", "Failed to Add title to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        public void AddMobileNumber()
        {
            try
            {
                driver.WaitElementPresent(txtPhone);
                driver.SendKeysToElementClearFirst(txtPhone, Utility.GenerateMobileNumber(), "PhoneNumber");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Mobile Number", "Failed to Add Mobile Number", EngineSetup.GetScreenShotPath());
            }
        }
        public void AddEmailToContact(string email)
        {
            try
            {
                driver.WaitElementPresent(txtEmailcontact);
                driver.SendKeysToElement(txtEmailcontact, email, "Email");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Email to Contact", "Failed to Add Email to Contact", EngineSetup.GetScreenShotPath());
            }
        }
        public void SaveContact()
        {
            try
            {
                By btnSavecontact1 = By.XPath("//input[@value='Save']");//input[@id='ctl00_cphMain_btnSave_input']"
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnSavecontact1);
                driver.ClickElement(btnSavecontact1, "Save Button");
                driver.sleepTime(20000);
                By by = By.XPath("//div[@id='ctl00_cphMain_pnlDuplicates']");
                if (driver.FindElements(by).Count > 0)
                {
                    driver.sleepTime(5000);
                    By btnSave = By.XPath("//span[@id='ctl00_cphMain_btnSave']");
                    driver.ClickElement(btnSave, "Save Button");
                    // driver.WaitForPageLoad(TimeSpan.FromSeconds(30));                        
                    driver.sleepTime(10000);
                }
                driver.sleepTime(10000);
                id = utility.GetTitleId();
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Save Contact", "Failed to Save Contact", EngineSetup.GetScreenShotPath());
            }

        }
        public void SaveandCloseContact()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.WaitElementPresent(btnSaveClose);
                driver.ClickElementWithJavascript(btnSaveClose, "Save and close");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SaveandCloseContact", "Failed to Save and Close Contact", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Verify Newly Added Contact By Recruiter
        /// </summary>
        public void VerifyNewlyAddedContact()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.VerifyWebElementPresent(lblcontactid, "Contact ID");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Newly Added Contact", "Failed to Verify Newly Added Contact", EngineSetup.GetScreenShotPath());
            }
        }

        public string GetConatctTitle()
        {
            try
            {
                string contactTitle = driver.GetElementText(lblcontactid);
                int startIndex = contactTitle.IndexOf("(");
                return contactTitle.Substring(startIndex + 1, contactTitle.Length - startIndex - 2);
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Contact Title", "Failed to retrieve Contact Title", EngineSetup.GetScreenShotPath());
            }
            return string.Empty;
        }

        public string GetCandidateTitle()
        {
            try
            {
                string candidateTitle = driver.GetElementText(lblcompanytid);
                int startIndex = candidateTitle.IndexOf("(");
                return candidateTitle.Substring(startIndex + 1, candidateTitle.Length - startIndex - 2);
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Candidate Title", "Failed to retrieve Candidate Title", EngineSetup.GetScreenShotPath());
            }
            return string.Empty;
        }

        public void VerifyHomePageTitle(string candidateName)
        {
            try
            {
                string candidateTitle = driver.GetElementText(lblCandidatetId);
                if (candidateTitle.Contains(candidateName))
                {
                    TESTREPORT.LogSuccess("Verify Contact", "Able to Verify Contact");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Contact", "Failed to Verify Contact");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyCandidateTitle", "Failed to Verify Candidate Title", EngineSetup.GetScreenShotPath());
            }
        }

        public void UpdateCandidateStatus(int StatusId)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateMatch);
                driver.SwitchToFrameByLocator(iframeCandidateMatch);
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefresh);
                driver.sleepTime(10000);
                driver.ClickElement(btnRefresh, "Refreshpage");
                driver.sleepTime(20000);
                driver.WaitElementPresent(lnkStatus);
                driver.MouseHover(lnkStatus, "MouseHover on Status");
                //driver.WaitElementPresent(btnStatusEdit);
                driver.ClickElementWithJavascript(btnStatusEdit, "Click on Edit button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtStatusValue);
                driver.ClickElementWithJavascript(txtStatusValue, "Click on Status text box");
                By lblType = By.XPath(string.Format("//ul[@id='ui-id-2']//li[{0}]/a", StatusId));
                driver.WaitElementPresent(lblType);
                driver.ClickElement(lblType, "Select Status");
                driver.WaitElementPresent(btnStatusSave);
                driver.ClickElement(btnStatusSave, "Click on Save");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Update Candidate Status", "Failed to Update a Candidate Status", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateCandidateWithoutResumeInVendorContact(string candidateFirstName, string candidateLastName, string phoneNumber, string email)
        {
            try
            {
                driver.SwitchToFrameByLocator(frameAddCandidate);
                driver.SendKeysToElementClearFirst(txtFirstName, candidateFirstName, "First Name");
                driver.SendKeysToElementClearFirst(txtLastName, candidateLastName, "Last Name");
                driver.ScrollPage();
                driver.ClickElement(ddlState, "State");
                driver.ClickElement(txtState, "State");
                driver.SendKeysToElementClearFirst(txtMainphone, phoneNumber, "Phone Number");
                driver.SendKeysToElementClearFirst(txtEmail, email, "Email");
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(20000);
                id = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Candidate WithoutResume InVendor Contact", "Failed to Create Candidate WithoutResume In Vendor Contact", EngineSetup.GetScreenShotPath());
            }
        }
        public void AddContactType(string contactType)
        {
            try
            {
                By txtContactType = By.XPath(string.Format("//*[@id='ctl00_cphMain_ddlContactType_DropDown']/div/ul/li[contains(text(),'{0}')]", contactType));
                driver.WaitElementPresent(cbxContactType);
                driver.ClickElement(cbxContactType, "ContactType");
                driver.WaitElementPresent(txtContactType);
                driver.ClickElement(txtContactType, "ContactType");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Contact Type", "Failed to Add Contact Type", EngineSetup.GetScreenShotPath());
            }
        }
        public string GetCandidateTitleIncludingId()
        {
            string TitleIncludingID = null;
            try
            {
                driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //if(contact==true)
                //driver.SwitchToFrameByLocator(FrameManageContact);
                //else
                //driver.SwitchToFrameByLocator(frameManageCandidate);
                string candidateTitle = utility.GetTitle();
                TitleIncludingID = candidateTitle.Split(' ')[2];
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Title with ID", "Failed to Retrieve CandidateTitle with ID", EngineSetup.GetScreenShotPath());
            }
            return TitleIncludingID;
        }

        public void QuickSearch(string searchName)
        {
            try
            {
                driver.WaitElementPresent(txtQuickSearch);
                driver.SendKeysToElementClearFirst(txtQuickSearch, searchName, "Quick Search Value");
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Click Search Button");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Quick Search", "Failed at Quick Search", EngineSetup.GetScreenShotPath());
            }
        }
        public void ValidateContactType(string contactType)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameManageContact);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.sleepTime(5000);
                By txtContactType = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlContactType']/table//td[1]/input");
                driver.WaitElementPresent(txtContactType);
                string contactTypeValue = driver.FindElement(txtContactType).GetAttribute("value").ToString();
                if (contactTypeValue.Equals(contactType))
                {
                    this.TESTREPORT.LogSuccess("Quick Search", "Contact Type is same, which was selected while adding the contact", EngineSetup.GetScreenShotPath());
                }
                else
                {
                    this.TESTREPORT.LogFailure("Quick Search", "Failed to Search Contact", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Validate Contact Type", "Failed to Validate Contact Type", EngineSetup.GetScreenShotPath());
            }
        }
        public void ValidateRequiredField()
        {
            try
            {
                driver.ScrollPage();
                //driver.VerifyWebElementPresent(imgRequired, "Required");
                driver.ElementPresent(imgRequired, "Required");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Validate Required Field", "Failed to Validate Reuired field for State/Province", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyHeaderCandidate(string password, string newpassword)
        {
            try
            {
                driver.ClickElement(lnkHeader, "Header Menu");
                driver.WaitElementPresent(lnkSchedule);
                driver.ClickElement(lnkSchedule, "My Schedule");
                driver.sleepTime(10000);
                driver.SwitchToFrameByLocator(frameSchedule);
                driver.ClickElement(btnCloseschedule, "Close Schedule");
                driver.WaitElementPresent(lnkHeader);
                driver.ClickElement(lnkHeader, "Header Menu");
                driver.ClickElement(lnkChangePassword, "Change Password");
                driver.sleepTime(15000);
                driver.SwitchToFrameByLocator(frameProfilePassword);
                driver.SendKeysToElement(txtCurrentPassword, password, "CurrentPassword");
                driver.SendKeysToElement(txtNewPassword, newpassword, "New Password");
                driver.SendKeysToElement(txtConfirmNewPassword, newpassword, "Confirm Password");
                driver.ClickElement(btnChangePassword, "Change Password");
                driver.WaitElementPresent(lnkHeader);
                driver.ClickElement(lnkHeader, "Header Menu");
                driver.ClickElement(lnkChangePassword, "Change Password");
                driver.sleepTime(15000);
                driver.SwitchToFrameByLocator(frameProfilePassword);
                driver.SendKeysToElement(txtCurrentPassword, newpassword, "CurrentPassword");
                driver.SendKeysToElement(txtNewPassword, password, "New Password");
                driver.SendKeysToElement(txtConfirmNewPassword, password, "Confirm Password");
                driver.ClickElement(btnChangePassword, "Change Password");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Header Candidate", "Failed to Verify Header Candidate", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickPermissionsTab(string Manage, string rename)
        {
            try
            {
                driver.ClickElement(lnkPermissions, "Permissions");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(2000);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(2000);
                driver.SwitchToFrameByLocator(framePvPermission);
                driver.sleepTime(5000);
                driver.ClickElement(txtAddPermissions, "Manage API Permission");
                driver.SendKeysToElementAndPressEnter(txtAddPermissions, Manage, "Manage API Permission");
                driver.WaitElementPresent(lblManageAPI);
                driver.VerifyWebElementPresent(lblManageAPI, "Manage API");
                driver.ClickElement(txtAddPermissions, "Manage API Permission");
                driver.SendKeysToElementAndPressEnter(txtAddPermissions, rename, "Manage API Permission");
                driver.VerifyWebElementNotPresent(lblMangeRename, "Mange API Not present");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Permission Tabs", "Failed to Click on Permission Tabs", EngineSetup.GetScreenShotPath());
            }
        }

        public void EditContactMethod(string mainPhone, string communicationValue, string communicationNote, bool candidate = false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                if (candidate)
                {
                    driver.WaitElementPresent(iframeCandidateMatch);
                    driver.SwitchToFrameByLocator(iframeCandidateMatch);
                }
                else
                {
                    driver.WaitElementPresent(FrameManageContact);
                    driver.SwitchToFrameByLocator(FrameManageContact);
                }
                driver.ScrollPage();
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                // driver.WaitForElement(by, TimeSpan.MaxValue);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.sleepTime(3000);
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                driver.WaitElementPresent(by);
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.sleepTime(000);
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(10000);
                IWebElement tableElement = this.driver.FindElement(tblCommunication);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(mainPhone) && row.Text.Contains(communicationValue) && row.Text.Contains(communicationNote))
                    {
                        count++;
                    }

                }
                driver.sleepTime(5000);
                if (count >= 2)
                    TESTREPORT.LogSuccess("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
                else
                    TESTREPORT.LogFailure("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is not added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Edit Contact Method", "Failed to Edit Contact Method", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddContactMethod(string mainPhone, string communicationValue, string communicationNote)
        {
            try
            {
                driver.WaitElementPresent(iframeCandidateMatch);
                driver.SwitchToFrameByLocator(iframeCandidateMatch);
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                driver.sleepTime(3000);
                By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                IWebElement tableElement = this.driver.FindElement(tblCommunication);
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                int count = 0;
                foreach (IWebElement row in tableRow)
                {
                    if (row.Text.Contains(mainPhone) && row.Text.Contains(communicationValue) && row.Text.Contains(communicationNote))
                    {
                        count++;
                    }
                }
                if (count >= 1)
                    TESTREPORT.LogSuccess("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
                else
                    TESTREPORT.LogFailure("Add Communication values", string.Format("mainPhone : <Mark>{0}</Mark> is not added more than once with the same values :<Mark>{1}</Mark>", mainPhone, communicationValue));
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Contact Method", "Failed to Add Contact Method");
            }

        }
        public void VerifyDefaultTypeMarked(string mainPhone, string communicationValue, string communicationNote)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameManageContact);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(imgEdit, "Pencil Icon (Edit)");
                driver.ClickElement(imgEdit, "Click Pencil Icon (Edit)");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(contactWidgetTitle, "Edit Communication Methods");
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                By by = By.XPath("//span[@role='status' and text()='15 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                By txtCommunicationType = By.XPath(string.Format("//li/a[contains(@id,'ui-id') and text()='{0}']", mainPhone));
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElementAndPressEnter(txtCommunicationValue, communicationValue, "Enter Communication Value");
                driver.SendKeysToElement(txtCommunicationNote, communicationNote, "Enter Communication Note");
                driver.WaitElementPresent(btnAddCommunication);
                driver.ClickElement(btnAddCommunication, "Click on Add Communication");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnCommunicationType);
                driver.ClickElement(ddnCommunicationType, "Communication Type Drop down");
                driver.WaitElementPresent(txtCommunicationType);
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
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
                driver.WaitElementPresent(btnPopupClose);
                driver.ClickElement(btnPopupClose, "Close Button");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Default Type Marked", "Failed to Verify Default Type Marked", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyDisplayPhoneNumber(string mainPhone, string communicationValue)
        {
            try
            {
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
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

        public void EditLookingForTab(string amount, string ctype)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.ScrollToPageBottom();
                driver.MouseHover(lblLookingFor, "Looking For Label");
                driver.ClickElementWithJavascript(btnEdit, "Click on Edit Button");
                driver.ClickElement(ddlContractorType, "Contractor Type Drop down");
                By by = By.XPath("//span[@role='status' and text()='4 results are available, use up and down arrow keys to navigate.']");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                by = By.XPath(string.Format("//a[contains(@id,'ui-id') and text()='{0}']", ctype));
                driver.ClickElement(by, "Contact Type");
                driver.SendKeysUsingActions(txtAmountPayable, amount, "Enter the Amount");
                driver.ClickElement(btnSaveLookingFor, "Click Save");
                driver.sleepTime(30000);
                driver.ScrollToPageBottom();
                string value = driver.FindElement(lblAmountPayable).Text;
                if (value.Contains(amount))
                    TESTREPORT.LogSuccess("Verify Amount Payable", "Amount Payable is updated with the given value");
                else
                    TESTREPORT.LogFailure("Verify Amount Payable", "Amount Payable is not updated with the given value");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Edit Looking For Tab", "Failed to Edit Looking For Tab", EngineSetup.GetScreenShotPath());
            }
        }

        public void AddScheduleToCandidate(string schedule)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddSchedule);
                driver.ClickElement(btnAddSchedule, "Add Schedule");
                driver.WaitElementPresent(ddlItemType);
                driver.ClickElement(ddlItemType, "Item Type");
                driver.SendKeysToElementAndPressEnter(txtNoteAction, schedule, "Item Type Selection");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Schedule To Candidate", "Failed to Add Schedule To Candidate", EngineSetup.GetScreenShotPath());
            }
        }

        public void EditGeneralTab(string amount)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.ScrollPage();
                driver.MouseHover(lblName, "Name Label");
                driver.ClickElementWithJavascript(btnGeneralEdit, "Click on Edit Button");
                driver.sleepTime(20000);
                driver.SendKeysUsingActions(txtMoney, amount, "Enter the Amount");
                driver.ClickElement(btnSaveGeneral, "Click Save");
                driver.sleepTime(30000);
                driver.ScrollToPageBottom();
                //driver.sleepTime(20000);
                string value = driver.FindElement(lblMoney).Text;
                if (value.Contains(amount))
                    TESTREPORT.LogSuccess("Verify Money Field", "Money Field is updated with the given value");
                else
                    TESTREPORT.LogFailure("Verify Money Field", "Money Field is not updated with the given value");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Edit General Tab", "Failed to Edit General Tab", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyCandidateSearch(string candidateID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(newframeCandidateSearch);
                driver.sleepTime(20000);
                driver.ClickElement(txtStatusFilter, "Click on status filter");
                if (driver.FindElement(btnClearAllFilter).GetAttribute("class").Contains("clear-filters"))
                {
                    driver.ClickElement(btnClearAllFilter, "Click Clear All");
                }
                By ddlIDFilter = By.XPath("//div[@class='TextFilter Display']/label[text()='ID:']");
                driver.ClickElement(ddlIDFilter, "Click on ID Filter");
                By txtFilter = By.XPath("//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");
                driver.SendKeysToElementAndPressEnter(txtFilter, candidateID, "Search First Name field");
                driver.ClickElement(btnSearch1, "Click Search");
                driver.sleepTime(20000);
                //driver.sleepTime(30000);
                IWebElement by = driver.FindElement(By.XPath(string.Format("//div/a[contains(text(),'{0}')]/../../following::td/a[@data-tipname='matchlist']", candidateID)));
                Actions act = new Actions(driver);
                act.ContextClick(by).Build().Perform();
                driver.WaitElementPresent(btnNewMatch);
                driver.ClickElement(btnNewMatch, "Click on New Match");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameMatchCandidate);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Candidate Search", "Candidate search is not successfully:", EngineSetup.GetScreenShotPath());
            }
        }

        public void CandidateSearch(string candidateID)
        {
            try
            {
                driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(newframeCandidateSearch);
                driver.ClickElement(txtStatusFilter, "Click on status filter");
                if (driver.FindElement(btnClearAllFilter).GetAttribute("class").Contains("clear-filters"))
                {
                    driver.ClickElement(btnClearAllFilter, "Click Clear All");
                }
                By ddlIDFilter = By.XPath("//div[@class='TextFilter Display']/label[text()='ID:']");
                driver.sleepTime(20000);
                driver.ClickElement(ddlIDFilter, "Click on ID Filter");
                By txtFilter = By.XPath("//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");
                driver.SendKeysToElementAndPressEnter(txtFilter, candidateID, "Search First Name field");
                driver.ClickElement(btnSearch1, "Click Search");
                //driver.sleepTime(30000);

                //click checkbox in candidate search page

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Candidate Search", "Candidate search is not successfully:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickCreateMatchFor(string candidateID)
        {
            try
            {
                By by = By.XPath(string.Format("//td/div/a[contains(text(),'{0}')]/../../preceding-sibling::td/input[@type='checkbox']", candidateID));
                driver.ClickElement(by, "Select the checkbox");
                driver.ClickElement(lnkCreateMatchFor, "Click create Match for link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Create Match For", " Failed to click create Match for" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void MatchfromRightPanel(string id, bool companies = true)
        {
            try
            {
                if (companies)
                {
                    driver.MouseHover(searchCompanies, "Companies");
                    driver.SendKeysToElementAndPressEnter(txtCompaniesName, id, "Companies");
                }
                else
                {
                    driver.MouseHover(Candidates, "Candidates");
                    driver.SendKeysToElementAndPressEnter(txtCandidateName, id, "Companies");
                }

                driver.SwitchToDefaultFrame();
                if (companies)
                {
                    driver.SwitchToFrameByLocator(frameManageCompany);
                }
                else
                {
                    driver.SwitchToFrameByLocator(FrameManageContact);
                }

                driver.ScrollPage();
                driver.ClickElement(btnAddNewMatch, "Add New Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOn Add New Match", "Failed to Click On Add New Match", EngineSetup.GetScreenShotPath());
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
        #endregion


    }
    #endregion
}