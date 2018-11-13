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
using System.Globalization;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class CreatePositionPage : AbstractTemplatePage
    {
        public static string positionId = string.Empty;
        HomePage home = new HomePage();
        Utility utility = new Utility();

        #region Constructors
        public CreatePositionPage()
        {
        }
        //public CreatePositionPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}
        #endregion

        #region UI Object Repository

        private By ddnCompanyName = By.Id("ctl00_cphMain_ddlCompany_Input");
        private By ddnContact = By.XPath("//*[@id='ctl00_cphMain_ddlContact_Input']");
        private By txtPositionTitle = By.XPath(".//*[@id='ctl00_cphMain_txtName']");
        private By txtEstimatedDate = By.XPath(".//*[@id='ctl00_cphMain_dpProjectedStartDate_dateInput']");
        private By txtCompanyDepartment = By.Id("ctl00_cphMain_ddlCompanyDepartment");
        private By ddnPositionType = By.Id("ctl00_cphMain_ddlPosType");
        private By ddnFolderGroup = By.XPath(".//*[@id='ctl00_cphMain_ddlFolderGroups']");
        private By ddnPrimaryDepartment = By.XPath(".//*[@id='ctl00_cphMain_ddlDepartment_Input']");
        private By txtPositionSource = By.XPath(".//*[@id='AdSourceDropdown_ddladsource']");
        private By txtInternalStatus = By.XPath(".//*[@id='ctl00_cphMain_ddlInternalSource_Input']");
        private By txtInitialStatus = By.XPath(".//*[@id='ctl00_cphMain_ddlStatus_Input']");
        private By txtDuration = By.XPath(".//*[@id='ctl00_cphMain_txtDurationQty']");
        private By ddnDurationUnit = By.XPath(".//*[@id='ctl00_cphMain_ddlDurationUnit']");
        private By btnSavePosition = By.XPath(".//*[@id='ctl00_cphMain_btnSave']");
        private By lblPosition = By.XPath(".//*[@id='pagetitle']/h1");
        private By btnEditAccounting = By.XPath(".//*[@data-tipname='position/accounting']");
        private By ddnWorkersComp = By.XPath(".//*[contains(@id, 'ddlworkerscomp')]/a/span");
        private By txtWorkersComp = By.XPath(".//div[@class='select2-drop select2-drop-active select2-with-searchbox']/div/input");
        private By btnEditTaxInfo = By.XPath(".//*[@data-tipname='position/taxinfo']");
        private By ddlSalesTax = By.XPath(".//*[contains(@id, '_ddlsalestax')]");
        private By SalesTax = By.XPath(".//*[starts-with(@id, 'ui-id')]/li/a");
        private By btnSaveSalesTax = By.XPath(".//*[contains(@id, '_btnsave')]");
        private By btnAddContact = By.Id("btnAddNewContact");
        private By FramePosition = By.XPath("//iframe[contains(@id,'position_new')]");
        private By ddnPositionTemplate = By.Id("ctl00_cphMain_ddlPositionTemplate_Input");
        private By ddnPositionTemplatelist = By.XPath("//div[@id='ctl00_cphMain_ddlPositionTemplate_DropDown']//ul/li[3]");
        private By ddlClientProject = By.Id("ctl00_cphMain_ddlClientProject_Input");
        private By ddlClientProjectList = By.XPath("//div[@id='ctl00_cphMain_ddlClientProject_DropDown']/div[1]/ul/li");
        private By ddlPositionRequest = By.Id("ctl00_cphMain_ddlCreationReason_Input");
        private By ddlPositionRequestLis = By.XPath("//div[@id='ctl00_cphMain_ddlCreationReason_DropDown']/div/ul/li[1]");
        private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage')]");
        private By btnClose = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnClose_input");
        private By ddnContactList = By.XPath("//div[@id='ctl00_cphMain_ddlContact_DropDown']/div[1]/ul/li");
        private By ddnTypePositionList = By.XPath("//div[@id='ctl00_cphMain_ddlPosType_DropDown']/div/ul/li[1]");
        private By ddnFoldergrouplist = By.XPath("//div[@id='ctl00_cphMain_ddlFolderGroupsVMS_DropDown']/div/ul/li[2]");
        private By ddnFoldergroup = By.Id("ctl00_cphMain_ddlFolderGroupsVMS");
        private By ddndurrationList = By.XPath("//div[@id='ctl00_cphMain_ddlDurationUnit_DropDown']/div/ul/li[3]");
        private By btnSavePositionVendormngr = By.XPath("//input[@id='ctl00_cphMain_btnSave_input']");
        private By btnQP = By.XPath("//button[@id='btnAddNewMatchQP']");
        private By ddnSelectPosition = By.XPath("//div[@id='s2id_Position']/a/span");
        private By btnNext = By.XPath("//input[@data-panel='timelineCandidates']");
        private By txtEnterPosition = By.XPath("//div[text()='Select a candidate to view details']//following-sibling::div/div/input");
        private By txtCandidates = By.XPath("//div[@id='s2id_Candidates']/ul/li/input");
        private By btnNextSubmital = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By ddlSubmitalType = By.XPath("//div[@id='s2id_SubmitMode_SelectedItem']");
        private By txtSubmital = By.XPath("//input[@data-helptip='MatchSubmittalType']");
        private By btnCreateOnlyMatch = By.XPath("//button[@value='Create Match Only']");
        private By warningMessages = By.XPath("//div[@class='validation-summary-errors']");
        private By txtBillRate = By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]");
        private By txtPayRate = By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]");
        private By btnNextCandidate = By.XPath("//input[@data-panel='timelineSubmittal']");
        //  private By btnApproveWithoutSendingMail = By.XPath("//input[@value='Approve without Sending Email']");
        private By btnTimeLineNext = By.XPath("//img[@id='ctl00_ctl00_cphMain_cphMain_rptTimeline_ctl04_imgNext']");
        private By btnApproverWithoutEmail = By.XPath("//button[@value='Approve without Sending Email']");
        private By warningMessagediv = By.XPath("//div[@class='validation-summary-errors']");
        private By lnkAdvanceToAccepted = By.XPath(".//div[starts-with(@id, 'widget_statusadvance')]/img[@src='/Mvc/Content/Images/icons/thumb_up.png']");
        private By iframeCandidateinMatch = By.XPath("//iframe[contains(@id,'match_manage')]");
        private By btnRefreshCandidate = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input']");
        private By lnkAcceptMatch = By.XPath("//div[@class='widgetBody']/div[3]//div[contains(@id,'widget_statusadvance')]/img");
        private By lnkAccounting = By.Id("ctl00_hpSendInvoiceToView");
        private By txtBillContact = By.XPath("//div[@id='ctl00_hpSendInvoiceToEdit']//input[contains(@id,'widget_accountingdetails_')]");
        private By inputBillContact = By.XPath("//html/body/ul/li/a");
        private By lnkTaxinfo = By.Id("ctl00_hpAccountingClassView");
        private By btnSaveAccounting = By.XPath("//button[contains(@id,'widget_accountingdetails')]");
        private By btnCloseAccounting = By.XPath("//div[@class='t_CloseButtonShift']/div[1]");
        private By btnTaxEdit = By.XPath("//div[@data-tipname='match/taxinfo']");
        private By inputBurdenTax = By.XPath("//html/body/ul/li[1]/a");
        private By ddlBurdenTax = By.XPath("//div[@id='ctl00_hpBurdenTax'] //input[contains(@id,'widget_taxinfo')]");
        private By btnSaveTax = By.XPath("//div[@class='widgetfooter']/span/button[contains(@id,'widget_taxinfo')]");
        private By txtWorkedinstate = By.XPath("//input[contains(@id,'_ddlworkedinstate')]");
        private By inputWorkedinstate = By.XPath("//ul/li/a[text()='Washington']");
        private By btnlocalstatus = By.XPath("//button[@class='btn-xs icon-pencil']");
        private By ChckLocale = By.XPath("//input[@type='checkbox']");
        private By btnSuccess = By.XPath("//button[@class='btn btn-success']");
        private By btnRefresh = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input");
        private By frameCompanyManage = By.XPath("//iframe[contains(@id,'company_manage')]");
        private By btnAddNewPosition = By.Id("btnAddNewPosition");

        private By iframetimesheet = By.XPath("//iframe[contains(@id,'timesheet_addnewtimesheet')]");
        private By ddlMatch = By.XPath("//div[@id='s2id_autogen1']/a");
        private By txtMatch = By.XPath("//div[@class='select2-drop select2-drop-active']//input");
        private By ddlPeriod = By.XPath("//div[@class='form-group']/label[@for='ddlRangeCalendarPeriod']/following-sibling::div[1]");
        private By lnkContract = By.XPath("//div[@data-widgetname='match/general']//div/h5");
        private By btnEditContract = By.XPath("//div[@data-tipname='match/general']");
        private By txtStartDate = By.XPath("//input[contains(@id,'_startdate')]");
        private By btnSaveStartDate = By.XPath("//button[contains(@id,'_btnsave')]");
        private By btnClosestartDate = By.XPath("//div[@class='t_CloseState']");
        private By txtPeriod = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By lstPeriod = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/ul/li[1]");
        private By btnCreate = By.XPath("//input[@value='Create']");
        private By lnkContinuetimesheet = By.XPath("//a[text()='Continue to timesheet']");
        private By iframeTimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");
        private By lblTimesheet = By.XPath("//div/h1");
        private By lnkRates = By.XPath("//div[@class='content legacy_scrollbars']/div[2]/div[3]/a");
        private By ChckPublishRates = By.Id("PublishRates");
        private By btnSaveRates = By.Id("SaveRateGroup");
        private By btnNextQp = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By txtEstimatedEndDate = By.XPath("//input[@data-helptip='MatchEstimatedEndDate']");
        private By txtMatchStartDate = By.XPath("//input[@data-helptip='MatchStartDate']");
        private By txtTaxtype = By.XPath("//div[contains(@id,'_TaxType_SelectedItem')]/a/span");
        private By txtQuickMatchPayRate = By.XPath("//div[contains(@id,'_PayRate')]/input[2]");
        private By btnCreateMatchOnly = By.XPath("//button[@value='Create Match Only']");
        private By imgTimeLine = By.Id("ctl00_ctl00_cphMain_cphMain_rptTimeline_ctl03_imgNext");
        private By lnkConvertToPerm = By.XPath("//div[contains(@data-tipurl,'endtype=Convert')]");
        private By txtEndDate = By.XPath("//div[@data-bind='control: EndCurrentMatchDate']/input");
        private By txtStartConversionDate = By.XPath("//div[@data-bind='control: StartConversionDate']/input");
        private By txtSalary = By.XPath("//input[@data-bind='value: Salary']");
        private By txtConversionFee = By.XPath("//input[@data-bind='value: ConversionFee']");
        private By txtEndReason = By.XPath("//div[@id='s2id_autogen2']/a/span");
        private By inputEndReason = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/ul/li/div[text()='Converted to Perm']");//By.XPath("//input[@class='select2-input']");//By.XPath("//label[text()='End Reason']/../div/a/../div/div/input");
        private By btnSavePermanent = By.XPath("//div[contains(@id,'view_MatchEndType')]//button[@class='btn btn-success']");
        private By btnCancelMatch = By.XPath("//div[contains(@data-tipurl,'endtype=Cancel')]");
        private By txtCancelledBy = By.XPath("//div[@id='s2id_autogen1']/a/span");
        private By txtCancelReason = By.XPath("//div[@id='s2id_autogen5']/a/span");
        private By inputTaxType = By.XPath("//input[@data-helptip='MatchTaxType']");
        private By btnNextPosition = By.XPath("//input[@data-panel='timelineCandidates']");
        private By imgCancel = By.XPath("//div[@data-tipname='match/statusadvance']");
        private By lnkConvertedMatch = By.XPath("//div[@id='message_3']/span");
        private By lnkConfirmEndDate = By.XPath("//div[contains(@data-tipurl,'endtype=End')]");
        private By headerEnd = By.XPath("//header[contains(text(),'End')]");
        private By txtActualEndDate = By.XPath("//div[@data-bind='control: ActualEndDate']/input");
        private By ddnEndReason = By.XPath("//div[@class='form-group']//div[@id='s2id_autogen2']/a/span");
        private By ddnPlacementGrade = By.XPath("//*[@id='s2id_autogen4']/a");
        private By rbMatchEarly = By.XPath("//div[contains(@id,'view_MatchEndType')]//label[2]/input");
        private By imgEndingsoon = By.XPath("//img[contains(@src,'ending-soon')]");
        private By frameMatchManage = By.XPath("//iframe[contains(@id,'match_manage')]");
        private By frameMatchNew = By.XPath("//iframe[contains(@id,'match_new')]");
        private By frameMatchNewCandidateApp = By.XPath("//iframe[contains(@id,'match_new_candidateid')]");
        private By frameMatchCandidateApp = By.XPath("//iframe[contains(@id,'match_new_candidateapplicationid')]");
        private By lnkMatch = By.XPath("//span[text()='Match']"); 
        private By lblPlacementGrade = By.XPath("//label[text()='Placement Grade']/../div/a");
        private By lblEndReason = By.XPath("//label[text()='End Reason']/../div/a/span");
        private By btnSkills = By.XPath("//a[@class='rtsLink']//span[contains(text(),'Skills (0)')]");
        private By ddnSkills = By.XPath("//input[@id='ctl06_ddlSkills_ddlTree_Input']");
        private By ddnLevel = By.Id("ctl06_ddlSkillLevels_Input");
        private By btnAdd = By.XPath("//input[@id='ctl06_btnAddSkills_input' and @value='Add']");
        private By msgSkillsAdded = By.XPath("//div[@class='info message' and text()='Skills added.']");
        private By imgEdit = By.XPath("//span[@id='editbuttoncomm']/img");
        private By contactWidgetTitle = By.XPath("//div[text()='Edit Communication Methods']");
        private By ddnCommunicationType = By.XPath("//input[contains(@id,'widget_communicationlist_') and @class='ui-autocomplete-input' and @data-selectedvalue='201']");
        private By txtCommunicationValue = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtvalue')]");
        private By txtCommunicationNote = By.XPath("//div[@class='commtype']/../following::td//input[contains(@id,'_txtnote')]");
        private By btnAddCommunication = By.XPath("//button[contains(@id,'_AddCommunication') and @title='Click to add this communication']");
        private By tblCommunication = By.XPath("//div[contains(@id,'_editmode')]/table/tbody");
        private By btnPopupClose = By.XPath("//div[@class='t_CloseButtonShift']//canvas");
        private By FrameManageContact = By.XPath("//iframe[contains(@id,'contact_manage')]");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By chkboxRequestReplacement = By.XPath("//input[@data-bind='checked: RequestReplacement']");
        private By ddnWorkerComp = By.XPath("//div[@id='s2id_WorkmansComp']/a");
        private By ddnVMSBurden = By.XPath("//div[@id='s2id_VMSBurden_SelectedItem']");
        private By btnEndDate = By.XPath("//input[@data-val-date='The field EndDate must be a date.']");
        private By warningDatesMessage = By.XPath("//div[@class='validation-summary-errors']/ul/li[contains(text(),' must be greater than or equal to the Estimated Start Date')]");

        //Extend

        private By btnExtend = By.XPath("//div[contains(@data-tipurl,'endtype=Extend')]");
        private By estimatedEndDate = By.XPath("//div[@data-bind='control: EstimatedEndDate']/input");
        private By ddlextensionReason = By.XPath("//div[@id='s2id_autogen2']");
        private By tbExtensionReasonSearch = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By txtExtensionComments = By.XPath("//textarea[@id='txtComment']");
        private By btnSave = By.XPath("//footer[@class='widgetFooter']/div/button[text()='Save']");
        private By lnkQuick = By.XPath("//span[text()='Match']//span[text()='Quick']");
        //Add Rates
        //private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage_')]");
        private By moseHoverRates = By.XPath("//div[contains(@id,'widget_rates_')]");
        private By editClickRates = By.XPath("//div[text()='Rates Overview']//following-sibling::div/div");
        private By minRate = By.XPath("//div[contains(@id,'hpProjectedHourlyPayRateEdit')]/input[2]");
        private By maxRate = By.XPath("//div[contains(@id,'hpHourlyEditMax')]/input[2]");
        private By btnSaveRatesOver = By.XPath("//button[contains(@id,'_btnsave')]/span[2]");
        //Add Rates for Perm salary

        private By minPermsalary = By.XPath("//div[@id='ctl00_hpProjectedHourlyPayRateEdit']/input[2]");
        //By.XPath("//div[contains(@id,'hpAnnualSalaryEdit')]//input[2]");
        private By maxPermsalary = By.XPath("//div[@id='ctl00_hpHourlyEditMax']/input[2]");
            //By.XPath("//div[contains(@id,'hpAnnualEditMax')]//input[2]");

        //Add Rates
        private By btnAddRates = By.XPath("//button[@title='Add a new set of rates']");
        private By rateName = By.XPath("//input[@data-helptip='RateGroupName']");
        private By ddlRateType = By.XPath("//div[contains(@id,'RateType_SelectedItem')]");
        private By searchRateType = By.XPath("//input[@data-helptip='RateType']");
        private By txtEffectiveDate = By.XPath("//input[@data-helptip='RateGroupEffectiveDate']");
        private By btnSaveNewRates = By.XPath("//button[@id='SaveNewRates']");
        private By btnAddPay = By.XPath("//button[@title='Add a rate']");
        private By txtClass = By.XPath("//div[@data-requirementmessage='Class is required']/input");
        private By txtPayrate = By.XPath("//div[@id='ctl00_hpPayRate']/input[2]/input");
        private By txtBillrate = By.XPath("//div[@id='ctl00_hpBillRate']/input[2]");
        private By btnsavePayrate = By.XPath("//div[@class='widgetfooter']/span/button[contains(@class,'save ui-button')]");
        private By lnkOption = By.XPath("//div[@data-requirementmessage='Class is required']/span[text()=1]");
        private By lnkClass = By.XPath("//input[contains(@id,'_ddltrc')]");
        private By txtPayRates = By.XPath("//span[text()='Pay Rate']/..//following-sibling::input[2]");
        private By txtBillRates = By.XPath("//span[text()='Bill Rate']/..//following-sibling::input[2]");
        private By btnAddNewMatch = By.XPath("//button[@id='btnAddNewMatch']");
        private By txtPositionIdRecruiter = By.XPath("//div[@id='topmenu']//ul/li[1]/div/ul/li[4]/span//input");
        private By ddlPositionReason = By.Id("ctl00_cphMain_ddlCreationReason_Input");
        private By ddlSelectDuration = By.XPath("//input[@id='ctl00_cphMain_ddlDurationUnit_Input']");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'dashboard')]");
        private By btnAddPosition = By.XPath("//button[text()='Add New Position']");
        private By ddnSelPosition = By.XPath("//a[@id='ctl00_cphMain_ddlPositionTemplate_Arrow']");
        #endregion

        #region Public Methods
        public string CreatePosition(string positionTitle, int positionTypeIndex, int folderGroupIndex, string commpanyName, string startDate = "28/12/2017", bool company = false, bool Position = true)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(FramePosition);
                driver.SwitchToFrameByLocator(FramePosition);
                if (company)
                {
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(ddnCompanyName);
                    driver.ClickElement(ddnCompanyName, "Company Name");
                    driver.sleepTime(3000);
                    driver.SendKeysToElement(ddnCompanyName, AddCompanyPage.title, "Company Name");
                    driver.sleepTime(3000);
                    driver.SendKeysToElement(ddnCompanyName, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "Company Name");
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(ddnContact);
                    driver.ClickElement(ddnContact, "Contact Name");
                    driver.sleepTime(5000);
                    //By selectDdn = By.XPath("//input[@class='rcbInput radPreventDecorate  valid']");
                    //driver.WaitElementPresent(selectDdn);
                    IList<IWebElement> ContactElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlContact_DropDown']/div[1]/ul"));
                    var ContactOptions = ContactElement.First().FindElements(By.TagName("li"));
                    ContactOptions[0].Click();
                    driver.sleepTime(2000);
                }
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(txtPositionTitle, positionTitle, "Position Title");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtEstimatedDate);
                driver.SendKeysToElementAndPressEnter(txtEstimatedDate, startDate, "Enter Estimated Date");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnPositionType);
                driver.ClickElement(ddnPositionType, "Position Type");
                driver.sleepTime(10000);
                var PositionTypeElement = driver.FindElements(By.XPath(".//*[@id='ctl00_cphMain_ddlPosType_DropDown']/div/ul"));
                var PositionTypeOptions = PositionTypeElement.First().FindElements(By.TagName("li"));
                PositionTypeOptions[positionTypeIndex].Click();
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnFolderGroup);
                driver.ClickElement(ddnFolderGroup, "Folder Group");
                driver.sleepTime(20000);
                var FolderGroupElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlFolderGroups_DropDown']/div/ul"));
                var FolderGroupOptions = FolderGroupElement.First().FindElements(By.TagName("li"));
                FolderGroupOptions[folderGroupIndex].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnPrimaryDepartment);
                driver.SendKeysToElementAndPressEnter(ddnPrimaryDepartment, "Test1", "Primary Department");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtPositionSource);
                driver.ClickElement(txtPositionSource, "Position Source ");
                //By by = By.XPath("//span[@role='status' and text()='95 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitElementPresent(by);
                driver.sleepTime(5000);
                By byPosition = By.XPath("//*[starts-with(@id,'ui-id')]/li[2]/a");
                driver.ClickElement(byPosition, "Select a position");
                driver.sleepTime(5000);
                if (Position)
                {
                    driver.SendKeysToElementAndPressEnter(txtInitialStatus, "Gold", "Initial Status");
                    driver.sleepTime(10000);
                }
                By byduration = By.Id("ctl00_cphMain_txtDurationQty");
                driver.SendKeysToElement(byduration,"52","Duration Value");
                driver.sleepTime(2000);
                driver.SendKeysToElement(byduration, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(5000);
                By byDurationUnits=By.Id("ctl00_cphMain_ddlDurationUnit_Input");
                driver.ClickElement(byDurationUnits,"Duration Units");
                driver.sleepTime(5000);
                var DurationUnitsElement = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlDurationUnit_DropDown']/div/ul"));
                var DurationUnitsOptions = DurationUnitsElement.First().FindElements(By.TagName("li"));
                DurationUnitsOptions[2].Click();
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSavePosition);
                driver.ClickElement(btnSavePosition, "Click on Save Position");
                driver.sleepTime(30000);
                positionId = GetPositionTitle();

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
            return positionId;
        }

        public string CreatePositionWithDefault(string positionTitle, int positionTypeIndex, int folderGroupIndex, string commpanyName, string startDate = "28/12/2017")
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(FramePosition);
                driver.SwitchToFrameByLocator(FramePosition);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtPositionTitle);
                driver.SendKeysToElementAndPressEnter(txtPositionTitle, positionTitle, "Position Title");
                driver.WaitElementPresent(txtEstimatedDate);
                driver.SendKeysToElementAndPressEnter(txtEstimatedDate, startDate, "Enter Estimated Date");
                driver.WaitElementPresent(ddnPositionType);
                driver.ClickElement(ddnPositionType, "Position Type");
                driver.sleepTime(5000);
                var PositionTypeElement = driver.FindElements(By.XPath(".//*[@id='ctl00_cphMain_ddlPosType_DropDown']/div/ul"));
                var PositionTypeOptions = PositionTypeElement.First().FindElements(By.TagName("li"));
                PositionTypeOptions[positionTypeIndex].Click();
                driver.sleepTime(10000);
                driver.ClickElement(ddnFolderGroup, "Folder Group");
                driver.sleepTime(10000);
                var FolderGroupElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlFolderGroups_DropDown']/div/ul"));
                var FolderGroupOptions = FolderGroupElement.First().FindElements(By.TagName("li"));
                FolderGroupOptions[folderGroupIndex].Click();
                driver.sleepTime(10000);
                driver.SendKeysToElementAndPressEnter(ddnPrimaryDepartment, "Test1", "Primary Department");
                driver.WaitElementPresent(txtPositionSource);
                driver.ClickElement(txtPositionSource, "Position Source ");
                //By by = By.XPath("//span[@role='status' and text()='95 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitElementPresent(by);
                By byPosition = By.XPath("//*[starts-with(@id,'ui-id')]/li[2]/a");
                driver.ClickElement(byPosition, "Select a position");
                driver.WaitElementPresent(btnSavePosition);
                driver.ClickElement(btnSavePosition, "Click on Save Position");
                driver.sleepTime(20000);
                positionId = GetPositionTitle();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add position", "Failed to add Position with default:", EngineSetup.GetScreenShotPath());
            }
            return positionId;
        }
        /// <summary>
        /// Create Position
        /// </summary>
        public string CreatePositionPerm(string positionTitle, int positionTypeIndex, int folderGroupIndex, string commpanyName, string startDate, bool company = false,bool contract=false)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameManageContact);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(10000);
                //driver.VerifyWebElementPresent(btnAddNewPosition, "Add New Position button");
                driver.WaitElementPresent(btnAddNewPosition);
                driver.ClickElement(btnAddNewPosition, "Click Add New Position button");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FramePosition);
                driver.SwitchToFrameByLocator(FramePosition);
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtPositionTitle);
                driver.SendKeysToElementAndPressEnter(txtPositionTitle, positionTitle, "Position Title");
                driver.WaitElementPresent(txtEstimatedDate);
                driver.SendKeysToElementAndPressEnter(txtEstimatedDate, startDate, "Enter Estimated Date");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnPositionType);
                driver.ClickElement(ddnPositionType, "Position Type");
                driver.sleepTime(1000);
                var PositionTypeElement = driver.FindElements(By.XPath(".//*[@id='ctl00_cphMain_ddlPosType_DropDown']/div/ul"));
                var PositionTypeOptions = PositionTypeElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(1000);
                PositionTypeOptions[positionTypeIndex].Click();
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnFolderGroup);
                driver.ClickElement(ddnFolderGroup, "Folder Group");
                driver.sleepTime(20000);
                var FolderGroupElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlFolderGroups_DropDown']/div/ul"));
                var FolderGroupOptions = FolderGroupElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                FolderGroupOptions[folderGroupIndex].Click();
                driver.sleepTime(7000);
                driver.SendKeysToElementAndPressEnter(ddnPrimaryDepartment, "Test1", "Primary Department");
                driver.WaitElementPresent(txtPositionSource);
                driver.ClickElement(txtPositionSource, "Position Source ");
                //By by = By.XPath("//span[@role='status' and contains(text(),'results are available, use up and down arrow keys to navigate.')]");
                //driver.WaitElementPresent(by);
                driver.sleepTime(5000);
                By byPosition = By.XPath("//*[starts-with(@id,'ui-id')]/li[2]/a");
                driver.ClickElement(byPosition, "Select a position");
                driver.sleepTime(5000);
                // if (company)
                //{
                driver.WaitElementPresent(txtInitialStatus);
                driver.SendKeysToElementAndPressEnter(txtInitialStatus, "Gold", "Initial Status");
                driver.sleepTime(10000);
                if(contract)
                {
                    By byduration = By.Id("ctl00_cphMain_txtDurationQty");
                    driver.SendKeysToElement(byduration, "52", "Duration Value");
                    driver.sleepTime(2000);
                    driver.SendKeysToElement(byduration, OpenQA.Selenium.Keys.Tab, "");
                    driver.sleepTime(5000);
                    By byDurationUnits = By.Id("ctl00_cphMain_ddlDurationUnit_Input");
                    driver.ClickElement(byDurationUnits, "Duration Units");
                    driver.sleepTime(5000);
                    var DurationUnitsElement = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlDurationUnit_DropDown']/div/ul"));
                    var DurationUnitsOptions = DurationUnitsElement.First().FindElements(By.TagName("li"));
                    DurationUnitsOptions[2].Click();
                    driver.sleepTime(10000);
                }
                //}
                driver.WaitElementPresent(btnSavePosition);
                driver.ClickElement(btnSavePosition, "Click on Save Position");
                driver.sleepTime(20000);
                positionId = GetPositionTitle();

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
            return positionId;
        }

        /// <summary>
        /// Create Position From Contact
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="positionTypeIndex"></param>
        public void CreatePositionFromContact( String positionTitle,string startDate, int positionTypeIndex,int folderGroupIndex)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.VerifyWebElementPresent(btnAddPosition, "Add New Position button");
                driver.ClickElement(btnAddPosition, "Click Add New Position button");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(FramePosition);
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtPositionTitle, positionTitle, "Position Title");
                //driver.sleepTime(5000);
                driver.ClickElement(ddnSelPosition, "");
                var element = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlPositionTemplate_DropDown']//ul"));
                var poptions = element.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                poptions[0].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtEstimatedDate);
                driver.SendKeysToElementAndPressEnter(txtEstimatedDate, startDate, "Enter Estimated Date");
                driver.sleepTime(2000);
                //driver.ClickElementAndSendKeys(txtEstimatedDate, startDate, "Enter Estimated Date");
                //driver.sleepTime(5000);
                //driver.FindElement(txtEstimatedDate).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(ddnPositionType);
                driver.ClickElement(ddnPositionType, "Position Type");
                var PositionTypeElement = driver.FindElements(By.XPath(".//*[@id='ctl00_cphMain_ddlPosType_DropDown']/div/ul"));
                var PositionTypeOptions = PositionTypeElement.First().FindElements(By.TagName("li"));
                PositionTypeOptions[positionTypeIndex].Click();
                driver.sleepTime(10000);
                driver.ClickElementAndSendKeys(ddlPositionReason, "test", "Position Reson");
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(txtInitialStatus, "Gold", "Initial Status");
                driver.sleepTime(10000);
                By byduration = By.Id("ctl00_cphMain_txtDurationQty");
                driver.SendKeysToElement(byduration, "52", "Duration Value");
                driver.sleepTime(2000);
                driver.SendKeysToElement(byduration, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(5000);
                By byDurationUnits = By.Id("ctl00_cphMain_ddlDurationUnit_Input");
                driver.ClickElement(byDurationUnits, "Duration Units");
                driver.sleepTime(5000);
                var DurationUnitsElement = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlDurationUnit_DropDown']/div/ul"));
                var DurationUnitsOptions = DurationUnitsElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                DurationUnitsOptions[2].Click();
                driver.sleepTime(10000);
                driver.ClickElement(btnSavePositionVendormngr, "Save Position");
                driver.sleepTime(10000);
                
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Change Password", "Change Password id not successfully", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyPositionTitle()
        {
            try
            {
                driver.WaitElementPresent(lblPosition);
                driver.VerifyWebElementPresent(lblPosition, "Position");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyPositionTitle", "Failed to Verify Position Title:", EngineSetup.GetScreenShotPath());
            }
        }
        public string GetPositionTitle()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchTo().DefaultContent();
                driver.WaitElementPresent(lblPosition);
                string PositionTitle = driver.GetElementText(lblPosition);
                int startIndex = PositionTitle.IndexOf("(");
                return PositionTitle.Substring(startIndex + 1, PositionTitle.Length - startIndex - 2);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("GetPositionTitle", "Failed to Get Position Title:", EngineSetup.GetScreenShotPath());
            }
            return string.Empty;
        }

        public string CreateContractPosition(string companyName, int foldergroup, string startDate, bool company = false)
        {
            string PositionId = string.Empty;
            try
            {
                if (company == true)
                {
                    PositionId=CreatePosition("Contract Position", 0, foldergroup, companyName, startDate, true);
                }
                else
                {
                    PositionId=CreatePosition("Contract Position", 0, foldergroup, companyName, startDate, false);
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
            return PositionId;


        }
        /// <summary>
        /// Create contract position
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public string CreateContractPosition(string companyName, int foldergroup)
        {
            //string positionId = string.Empty;
            try
            {

                positionId=CreatePosition("Contract Position", 0, foldergroup, companyName, "28/03/2018", false);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }

            return positionId;
        }
        /// <summary>
        /// Create contract position
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public string CreateContractPositionwithdefault(string companyName, int foldergroup)
        {
            //string positionId = string.Empty;
            try
            {

                CreatePositionWithDefault("Contract Position", 0, foldergroup, companyName, "28/11/2017");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }

            return positionId;
        }
        /// <summary>
        /// Creation perm position
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public string CreatePermPosition(string companyName)
        {
            string positionId = string.Empty;
            try
            {

                positionId=CreatePositionPerm("Permanent Position", 3, 0, companyName, "28/11/2017", false);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }

            return positionId;
        }
        /// <summary>
        /// Creation perm position
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public string CreateContractToPermPosition(string companyName)
        {
            string today = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                CreatePositionPerm("Contract Position", 1, 0, companyName, today, false,true);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
            return positionId;
        }
        /// <summary>
        /// Creation perm position
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public string CreatePermHourlyPosition(string companyName)
        {
            //string positionId = string.Empty;
            try
            {
                CreatePositionPerm("Contract Position", 2, 0, companyName, "28/11/2017", false);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToAddPosition", "Failed to navigate to Position:", EngineSetup.GetScreenShotPath());
            }
            return positionId;
        }
        /// <summary>
        /// Add Rates for per hourly in the position page
        /// </summary>
        public void AddRatesInPositionPage(string payRate, string billRate)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.sleepTime(5000);
                driver.ScrollToPageBottom();
                driver.MouseHover(moseHoverRates, "Mouse Hover On Rates");
                driver.WaitElementPresent(editClickRates);
                driver.ClickElementWithJavascript(editClickRates, "Edit Rates");
                driver.SendKeysUsingActions(minRate, payRate, "Min rate");
                driver.SendKeysUsingActions(maxRate, billRate, "Max rate");
                driver.WaitElementPresent(btnSaveRatesOver);
                driver.ClickElement(btnSaveRatesOver, "Save button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddRates In PositionPage", "Failed to Add Rates In PositionPage:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add rates for perm salary
        /// </summary>
        public void AddRatesForPermSalary()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.sleepTime(5000);
                driver.ScrollToPageBottom();
                driver.sleepTime(5000);
                driver.MouseHover(moseHoverRates, "Mouse Hover On Rates");
                driver.WaitElementPresent(editClickRates);
                driver.ClickElementWithJavascript(editClickRates, "Edit Rates");
                driver.sleepTime(5000);
                driver.SendKeysUsingActions(minPermsalary, "25", "Min rate");
                driver.SendKeysUsingActions(maxPermsalary, "50", "Max rate");
                driver.WaitElementPresent(btnSaveRatesOver);
                driver.ClickElement(btnSaveRatesOver, "Save button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddRates In PositionPage", "Failed to Add Rates In PositionPage:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add Rates for contract to perm
        /// </summary>
        /// <param name="rName"></param>
        public void AddRatesInPosition(string rName)
        {
            try
            {
                string today = DateTime.Now.ToString("M/d/yyyy");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.sleepTime(5000);
                driver.ScrollToPageBottom();
                driver.MouseHover(btnAddRates, "Add Rates");
                driver.ClickElementWithJavascript(btnAddRates, "Add Rates");
                driver.ClickElement(rateName, "Name");
                driver.SendKeysToElementAndPressEnter(rateName, rName, "Name");
                driver.ClickElement(ddlRateType, "Rate Type");
                driver.SendKeysToElementAndPressEnter(searchRateType, "Standard", "Search Rate Type");
                driver.ClickElement(txtEffectiveDate, "Effective Date");
                driver.ClickElementAndSendKeys(txtEffectiveDate, today, "Effective Date");
                driver.ClickElement(btnSaveNewRates, "Save");
                driver.sleepTime(20000);
                driver.ClickElementWithJavascript(btnAddPay, "Add Pay");
                driver.ClickElement(lnkClass, "Class dropdown");
                driver.SendKeysToElement(lnkClass, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.SendKeysUsingActions(txtPayRates, "15", "Payrate");
                driver.SendKeysUsingActions(txtBillRates, "35", "Billrate");
                driver.ClickElement(btnsavePayrate, "Save");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddRates In PositionPage", "Failed to Add Rates In PositionPage:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnAccountingTab()
        {
            try
            {
                driver.ClickElement(btnEditAccounting, "Click on Accounting Edit");
                driver.ClickElement(ddnWorkersComp, "Click on Worker's comp");
                driver.SendKeysToElementAndPressEnter(txtWorkersComp, "TEST-TEST-JZ", "Worker's Comp value");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnAccountingTab", "Failed to Click On Accounting Tab:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnTaxInfo()
        {
            try
            {
                driver.ClickElement(btnEditTaxInfo, "Click on Tax Info edit");
                driver.ClickElement(ddlSalesTax, "Click on Sales tax");
                driver.ClickElement(SalesTax, "Select Sales value");
                driver.ClickElement(btnSaveSalesTax, "Click on Save");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnTaxInfo", "Failed to Click On Tax Info:", EngineSetup.GetScreenShotPath());
            }
        }
        public void MatchfromQp(bool candidateframe = false)
        {
            try
            {
                if (candidateframe)
                {
                    driver.SwitchToFrameByLocator(frameManageCandidate);
                }
                else
                {
                    driver.SwitchToFrameByLocator(framePositionManage);
                }
                ClickOnQP();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOn QP", "Failed to Click On QP", EngineSetup.GetScreenShotPath());
            }
        }

        public string GetPositionID()
        {
            string ID = "";
            try
            {
                Utility utility = new Utility();
                ID = utility.GetTitleId();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ID;
        }

        public string SubmitMatch(string candidateName, string taxType, string payRate, string billRate, string endDate,bool QP=false,bool CandQP=false)
        {
            string matchId = string.Empty;
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                if (QP)
                {                  
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(ddnSelectPosition);
                    driver.ClickElement(ddnSelectPosition, "Select a position");
                    driver.sleepTime(5000);
                    driver.FindElement(txtEnterPosition).SendKeys(positionId);
                    driver.sleepTime(5000);
                    driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.sleepTime(5000);               
                }
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(btnNextPosition);
                    driver.ClickElement(btnNextPosition, "Next button");
                    driver.sleepTime(5000);
                if (CandQP)
                { 
                    driver.WaitElementPresent(txtCandidates);
                    //driver.SendKeysToElementAndPressEnter(txtCandidates, candidateName, "Enter candidate");
                    driver.FindElement(txtCandidates).SendKeys(candidateName);
                    driver.sleepTime(5000);
                    driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.sleepTime(5000);
                }
                //driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(txtEstimatedEndDate);
                driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                driver.SendKeysToElementClearFirst(txtEstimatedEndDate, endDate, "Match End Date");
                driver.WaitElementPresent(txtTaxtype);
                driver.ClickElement(txtTaxtype, "Tax type");
                driver.SendKeysToElementAndPressEnter(inputTaxType, taxType, "Tax Type");
                driver.sleepTime(5000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_PayRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(payRate);
                actions.Build().Perform();
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_BillRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(billRate);
                actions.Build().Perform();
                driver.WaitElementPresent(btnNextQp);
                driver.ClickElement(btnNextQp, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnCreateMatchOnly);
                driver.ClickElement(btnCreateMatchOnly, "Create Match through quick placement");
                driver.sleepTime(20000);
                matchId = utility.GetTitleId();
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Submit Match", "Failed to Submit Match", EngineSetup.GetScreenShotPath());
            }
            return matchId;
        }

        public void VerifyPopUp(string endDate, string endReason, string placementGrade, bool requestreplacement = false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchManage);
                driver.SwitchToFrameByLocator(frameMatchManage);
                driver.VerifyWebElementPresent(imgTimeLine, "Green Arrow button");
                driver.ClickElement(imgTimeLine, "Click Green Arrow button");
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(lnkConfirmEndDate, "Confirm End Date");
                driver.ClickElement(lnkConfirmEndDate, "Click Confirm End Date");
                driver.VerifyWebElementPresent(headerEnd, "End Pop up displayed");
                driver.sleepTime(3000);
                driver.VerifyWebElementPresent(txtActualEndDate, "Actual End Date");
                driver.SendKeysToElementAndPressEnter(txtActualEndDate, endDate, "Enter Actual End Date");
                driver.WaitElementPresent(lblPlacementGrade);
                driver.ClickElement(lblPlacementGrade, "Placement Grade ");
                //By by = By.XPath("//div[contains(@class,'select2-drop select2-with-searchbox select2-drop-active') and contains(@style,'display: block; top:')]");
                //driver.WaitElementPresent(by);
                By byPlacement = By.XPath(string.Format("//li/div[contains(text(),'{0}')]", placementGrade));
                driver.ClickElement(byPlacement, "Select a Placement");
                driver.VerifyWebElementPresent(lblEndReason, "End Reason");
                driver.ClickElement(lblEndReason, "End Reason");
                //by = By.XPath("//div[contains(@class,'select2-drop select2-with-searchbox select2-drop-active') and contains(@style,'display: block; top:')]");
                //driver.WaitElementPresent(by);
                By byEndReason = By.XPath(string.Format("//li/div[contains(text(),'{0}')]", endReason));
                driver.ClickElement(byEndReason, "Select a End Reason");
                driver.ClickElement(rbMatchEarly, "Click the Match Early check box");
                if (requestreplacement)
                {
                    driver.ClickElement(chkboxRequestReplacement, "Request Replacement");
                }
                driver.VerifyWebElementPresent(btnSavePermanent, "Save Button");
                driver.ClickElement(btnSavePermanent, "Click Save Button");
                driver.sleepTime(4000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Pop UP", "Failed to verify Pop up", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyMatchTimeline(string endDate)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchManage);
                driver.SwitchToFrameByLocator(frameMatchManage);
                driver.sleepTime(5000);
                //driver.sleepTime(20000);
                driver.VerifyWebElementPresent(imgEndingsoon, "Ending Soon Image");
                driver.ClickElement(imgEndingsoon, "Click on Ending Soon Image");
                driver.sleepTime(5000);
                By by = By.XPath("//div[@id='endedinfo']/div[@class='widgetBody']");
                string actualEndDate = driver.GetElementText(by);
                if (actualEndDate.Contains(endDate))
                {
                    this.TESTREPORT.LogSuccess("Verify Time Line Data", "Able to view end date in time line data", EngineSetup.GetScreenShotPath());
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Time Line Data", "Not able to view end date in time line data", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Time Line Data", "Failed to load time line data", EngineSetup.GetScreenShotPath());
            }
        }
        public void AddSkills(string skillDropdownValue, string levelDropdownValue)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.WaitElementPresent(btnSkills);
                driver.ClickElement(btnSkills, "Click Skills");
                driver.sleepTime(5000);              
                driver.SwitchToFrameById("pvSkills_frame");
                driver.sleepTime(5000);
                //driver.WaitElementPresent(ddnSkills);
                driver.WaitElementPresent(ddnSkills);
                driver.ClickElement(ddnSkills, "Click and Select Skills");
                driver.sleepTime(5000);
                By by = By.XPath(string.Format("//li[@class='rtLI']//span[contains(text(),'{0}')]", skillDropdownValue));
                driver.ClickElement(by, "Select Skills");
                driver.sleepTime(10000);
                driver.ClickElement(ddnLevel, "Select Level");
                IList<IWebElement> LevelElement = driver.FindElements(By.XPath("//*[@id='ctl06_ddlSkillLevels_DropDown']/div/ul"));
                var LevelOptions = LevelElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(10000);
                LevelOptions[0].Click();
                driver.sleepTime(10000);
                driver.FindElement(ddnLevel).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnAdd);
                driver.ClickElement(btnAdd, "Click Add button");
                driver.sleepTime(30000);
                driver.WaitElementPresent(msgSkillsAdded);
                    //if (driver.ElementPresent(msgSkillsAdded, "Skills Added"))
                //{
                //    this.TESTREPORT.LogSuccess("Verify Add Skills", "Able to Add Skills Successfully", EngineSetup.GetScreenShotPath());
                //}
                //else
                //{
                //    this.TESTREPORT.LogFailure("Verify Add Skills", "Not able to Add Skills ", EngineSetup.GetScreenShotPath());
                //}
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add Skills", "Failed to Add Skills ", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyDisplayPhoneNumber(string mainPhone, string communicationValue)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framePositionManage);
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

        public void VerifyWorkerCompQuickMatch(string position)
        {
            try
            {
                driver.WaitElementPresent(lnkQuick);
                driver.ClickElement(lnkQuick, "Click on Quick from Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a Position");
                driver.SendKeysToElementAndPressEnter(txtEnterPosition, position, "Enter position");
                driver.WaitElementPresent(ddnWorkerComp);
                driver.ClickElement(ddnWorkerComp, "Click on Worker's Comp");
                IList<IWebElement> workerCompElement = driver.FindElements(By.XPath("//div[11]//input[@data-helptip='MatchWorkersComp']/../..//ul"));
                var workerCompOptions = workerCompElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                if (workerCompOptions.Count > 0)
                    TESTREPORT.LogSuccess("Verify Worker Comp Value", "Worker Comp has certain values");
                else
                    TESTREPORT.LogFailure("Verify Worker Comp Value", "Worker Comp has no values");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Worker Comp Quick Match", "Failed to Verify Worker Comp in Quick Match", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyVMSBurdenQuickMatch(string position)
        {
            try
            {
                driver.WaitElementPresent(lnkQuick);
                driver.ClickElement(lnkQuick, "Click on Quick from Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a Position");
                driver.SendKeysToElementAndPressEnter(txtEnterPosition, position, "Enter position");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnVMSBurden);
                driver.ClickElement(ddnVMSBurden, "Click on VMSBurden");
                IList<IWebElement> VMSBurdenElement = driver.FindElements(By.XPath("//div[11]//input[@data-helptip='MatchVMSBurden']/../..//ul"));
                var VMSBurdenOption = VMSBurdenElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                if (VMSBurdenOption.Count > 0)
                    TESTREPORT.LogSuccess("Verify VMS Burden values", "VMS Burden values has certain values");
                else
                    TESTREPORT.LogFailure("Verify VMS Burden values", "VMS Burden values has no values");
            }

            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify VMSBurden Quick Match", "Failed to Verify VMSBurden Quick Match", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnQucickMatch(string positionID, string candidateName)
        {
            try
            {
                driver.WaitElementPresent(lnkQuick);
                driver.ClickElement(lnkQuick, "Click on Quick from Match");
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(15000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(10000);
                if (driver.IsElementPresent(warningMessages))
                    TESTREPORT.LogSuccess("Verify warning Message", "Warning  Message is displayed");
                else
                    TESTREPORT.LogFailure("Verify warning  Message", "Warning  Message is not displayed");
            }
            catch(Exception ex)
            {
                TESTREPORT.LogFailure("Click On Qucick Match", "Failed to Click On Qucick Match", EngineSetup.GetScreenShotPath());
            }

        }
        public void VerifyDatesValidation(string positionID, string candidateName, string PreviousDate)
        {
            try
            {
                driver.WaitElementPresent(lnkQuick);
                driver.ClickElement(lnkQuick, "Click on Quick from Match");
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(15000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnEndDate);
                driver.ClickElement(btnEndDate, "End Date");
                driver.SendKeysToElementAndPressEnter(btnEndDate, PreviousDate, "End Date");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(10000);
                if(driver.IsElementPresent(warningDatesMessage))
                    TESTREPORT.LogSuccess("Verify warning Dates Message", "Warning Dates Message is displayed");
                else
                    TESTREPORT.LogFailure("Verify warning Dates Message", "Warning Dates Message is not displayed");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Dates Validation", "Failed to Verify Dates Validation", EngineSetup.GetScreenShotPath());
            }

        }
        public void VerifyDatesInAddNewMatch(string positionID, string candidateName, string PreviousDate)
        {
            try
            {
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(10000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.sleepTime(15000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnEndDate);
                driver.ClickElement(btnEndDate, "End Date");
                driver.SendKeysToElementAndPressEnter(btnEndDate, PreviousDate, "End Date");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(10000);
                if (driver.IsElementPresent(warningDatesMessage))
                    TESTREPORT.LogSuccess("Verify warning Dates Message", "Warning Dates Message is displayed");
                else
                    TESTREPORT.LogFailure("Verify warning Dates Message", "Warning Dates Message is not displayed");

            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Dates In AddNewMatch", "Failed to Verify Dates In AddNewMatch", EngineSetup.GetScreenShotPath());
            }

        }
        public void VerifyWarningMesgCreatingMatch(string positionID, string candidateName)
        {
            try
            {
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(15000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(15000);
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next button to submital");
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Approve button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(warningMessagediv);
                if (driver.IsElementPresent(warningMessagediv))
                    TESTREPORT.LogSuccess("Verify warning  Message", "Warning  Message is displayed");
                else
                    TESTREPORT.LogFailure("Verify warning  Message", "Warning  Message is not displayed");

            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify WarningMesg Creating Match", "Failed to Verify WarningMesg Creating Match", EngineSetup.GetScreenShotPath());
            }

        }
        public void VerifyWorkerCompAddNewMatch(string position)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(15000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a Position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.SendKeysToElementAndPressEnter(txtEnterPosition, position, "Enter position");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnWorkerComp);
                driver.ClickElement(ddnWorkerComp, "Click on Worker's Comp");
                IList<IWebElement> workerCompElement = driver.FindElements(By.XPath("//div[11]//input[@data-helptip='MatchWorkersComp']/../..//ul"));
                var workerCompOptions = workerCompElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                if (workerCompOptions.Count > 0)
                    TESTREPORT.LogSuccess("Verify Worker Comp Value", "Worker Comp has certain values");
                else
                    TESTREPORT.LogFailure("Verify Worker Comp Value", "Worker Comp has no values");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify Worker Comp Add New Match", "Failed to Verify Worker Comp in Add New Match", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyVMSBurdenAndValueMatch(String position)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(15000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a Position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.SendKeysToElementAndPressEnter(txtEnterPosition, position, "Enter position");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnVMSBurden);
                driver.ClickElement(ddnVMSBurden, "Click on VMSBurden");
                IList<IWebElement> VMSBurdenElement = driver.FindElements(By.XPath("//div[11]//input[@data-helptip='MatchVMSBurden']/../..//ul"));
                var VMSBurdenOption = VMSBurdenElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                if (VMSBurdenOption.Count > 0)
                    TESTREPORT.LogSuccess("Verify VMS Burden values", "VMS Burden values has certain values");
                else
                    TESTREPORT.LogFailure("Verify VMS Burden values", "VMS Burden values has no values");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify VMSBurden And Value Match", "Failed to Verify VMSBurden And Value Match", EngineSetup.GetScreenShotPath());
            }

        }

        public void SubmitMatchQP(string candidateName, string taxType, string payRate, string billRate)
        {
            DateTime ago = DateTime.Now.AddMonths(-3);
            string Previousdate = ago.ToString("M/d/yyyy");
            string EndDate = DateTime.Now.AddDays(-2).ToString("M/d/yyyy").Replace('-','/');
            string today = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatchNew);
                driver.SwitchToFrameByLocator(frameMatchNew);
                driver.sleepTime(10000);
                driver.ClickElement(btnNextPosition, "Next button");
               // driver.WaitElementPresent(txtMatchStartDate);
                //driver.ClickElement(txtMatchStartDate, "Match Start Date");
                //driver.SendKeysToElementClearFirst(txtMatchStartDate, Previousdate, "Match Start Date");
                //driver.FindElement(By.XPath("//input[@data-helptip='MatchStartDate']")).SendKeys(OpenQA.Selenium.Keys.Return);
                driver.WaitElementPresent(txtEstimatedEndDate);
                driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                driver.SendKeysToElementClearFirst(txtEstimatedEndDate, EndDate, "Match End Date");
                driver.WaitElementPresent(txtTaxtype);
                driver.ClickElement(txtTaxtype, "Tax type");
                driver.SendKeysToElementAndPressEnter(inputTaxType, taxType, "Tax Type");
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_PayRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(payRate);
                actions.Build().Perform();
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_BillRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(billRate);
                actions.Build().Perform();
                driver.WaitElementPresent(btnNextQp);
                driver.ClickElement(btnNextQp, "Next");
                driver.WaitElementPresent(btnCreateMatchOnly);
                driver.ClickElement(btnCreateMatchOnly, "Create Match through quick placement");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Submit Match", "Failed to Submit Match", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnQP()
        {
            try
            {
                driver.ScrollPage();
                driver.WaitElementPresent(btnQP);
                driver.ClickElement(btnQP, "QP button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On QP", "Failed to Click On QP", EngineSetup.GetScreenShotPath());
            }
        }
        public void MatchfromRightPanel()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                //driver.SendKeysToElementAndPressEnter(txtPositionIdRecruiter, CreatePositionPage.positionId, "Position Id");
                //driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.ScrollPage();
                driver.ClickElement(btnAddNewMatch, "Add New Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOn Add New Match", "Failed to Click On Add New Match", EngineSetup.GetScreenShotPath());
            }

        }

        public void SubmitMatchFromCandidate(string candidateName, string taxType, string payRate, string billRate, string endDate, bool QP = false,bool CandApp=false)
        {
            try
            {
                driver.SwitchToDefaultFrame();

                driver.sleepTime(5000);
                if (CandApp)
                {
                    driver.WaitElementPresent(frameMatchCandidateApp);
                    driver.SwitchToFrameByLocator(frameMatchCandidateApp);
                    driver.sleepTime(5000);
                }
                else
                {
                    driver.WaitElementPresent(frameMatchNewCandidateApp);
                    driver.SwitchToFrameByLocator(frameMatchNewCandidateApp);
                    driver.sleepTime(5000);
                }
                if (QP)
                {
                    driver.WaitElementPresent(ddnSelectPosition);
                    driver.ClickElement(ddnSelectPosition, "Select a position");
                    driver.sleepTime(5000);
                    By txtPosition = By.XPath("//input[@data-helptip='MatchPositions' and contains(@class,'select2-input')]");
                    driver.FindElement(txtPosition).SendKeys(positionId);
                    driver.sleepTime(5000);
                    driver.FindElement(txtPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.sleepTime(5000);
                }
                //driver.sleepTime(5000);
                By btnNext = By.XPath("//div[@id='panelPosition']//span/input[@name='Next']");
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtEstimatedEndDate);
                driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                driver.SendKeysToElementClearFirst(txtEstimatedEndDate, endDate, "Match End Date");
                driver.WaitElementPresent(txtTaxtype);
                driver.ClickElement(txtTaxtype, "Tax type");
                driver.SendKeysToElementAndPressEnter(inputTaxType, taxType, "Tax Type");
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_PayRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(payRate);
                actions.Build().Perform();
                actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_BillRate')]/input[2]")));
                actions.Click();
                actions.SendKeys(billRate);
                actions.Build().Perform();
                driver.WaitElementPresent(btnNextQp);
                driver.ClickElement(btnNextQp, "Next");
                driver.sleepTime(10000);
                //driver.WaitElementPresent(btnCreateMatchOnly);
                //driver.ClickElement(btnCreateMatchOnly, "Create Match through quick placement");
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Approve without sending email");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Submit Match From Candidate App", "Failed to Submit Match From Candidate App", EngineSetup.GetScreenShotPath());
            }
        }
        #endregion
    }
}
