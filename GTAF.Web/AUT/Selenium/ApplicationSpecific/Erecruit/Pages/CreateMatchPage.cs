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


namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class CreateMatchPage : AbstractTemplatePage
    {
        HomePage home = new HomePage();
        CreatePositionPage positionPage = new CreatePositionPage();
        AddCandidatePage candidatePage = new AddCandidatePage();
        Utility utility = new Utility();
        public static string TimesheetId;

        #region Constructors
        public CreateMatchPage()
        {
        }

        public CreateMatchPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        private By ddnSelectPosition = By.XPath("//div[@id='s2id_Position']/a/span");
        private By btnNext = By.XPath("//input[@data-panel='timelineCandidates']");
        private By btnNextSubmital = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By ddlSubmitalType = By.XPath("//div[@id='s2id_SubmitMode_SelectedItem']");
        private By txtSubmital = By.XPath("//input[@data-helptip='MatchSubmittalType']");
        private By btnCreateOnlyMatch = By.XPath("//button[@value='Create Match Only']");
        private By txtEnterPosition = By.XPath("//div[@class='select2-drop select2-drop-active select2-with-searchbox']//input[@data-helptip='MatchPositions']");
            //By.XPath("//div[text()='Select a candidate to view details']//following-sibling::div/div/input");
        //By.XPath("//div[@class='select2-drop select2-drop-active']/div/input[@data-helptip='MatchPositions']");

        private By txtCandidates = By.XPath("//div[@id='s2id_Candidates']/ul/li/input");
        private By txtBillRate = By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]");
        private By txtPayRate = By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]");
        private By btnNextCandidate = By.XPath("//input[@data-panel='timelineSubmittal']");
        private By rerroMsgPosition = By.XPath("//div[@id='message_1']");
        //  private By btnApproveWithoutSendingMail = By.XPath("//input[@value='Approve without Sending Email']");
        private By btnTimeLineNext = By.XPath("//img[contains(@id,'imgNext')]");
        private By btnApproverWithoutEmail = By.XPath("//button[@value='Approve without Sending Email']");
        private By btnApproveEmail = By.XPath("//div[@id='submitIsValid']//button[text()='Approve and Email Contact']");
        private By btnRequestApproval = By.XPath("//div[@id='submitIsValid']//button[text()='Request Approval']");
        private By lnkAdvanceToAccepted = By.XPath(".//div[starts-with(@id, 'widget_statusadvance')]/img[@src='/Mvc/Content/Images/icons/thumb_up.png']");
        private By iframeCandidateinMatch = By.XPath("//iframe[contains(@id,'match_manage')]");
        private By btnRefreshCandidate = By.XPath("//input[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input']");
        private By lnkAcceptMatch = By.XPath("//div[@class='widgetBody']/div[3]//div[contains(@id,'widget_statusadvance')]/img");
        private By lnkAccounting = By.Id("ctl00_hpSendInvoiceToView");
        private By btnEditAccounting = By.XPath("//div[@data-tipname='match/accountingdetails']");
        private By txtBillContact = By.XPath("//div[@id='ctl00_hpSendInvoiceToEdit']//input[contains(@id,'widget_accountingdetails_')]");
        private By inputBillContact = By.XPath("//html/body/ul/li/a");
        private By chbAllowZeroHour = By.XPath("//input[contains(@id,'_chkallowemptytimesheets')]");
        private By ddlTimesheetBatch = By.XPath("//input[contains(@id,'_ddltimesheetbatch')]");
        private By txtTimesheetBatch = By.XPath("//a[text()='Default Batch']");
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
        private By frameMatchNew = By.XPath("//iframe[contains(@id,'match_new')]");
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
        private By lnkTimeSheetsinMatch = By.XPath("//div[contains(@id,'widget_timesheets_')]");
        private By btnEditTimesheets = By.XPath("//div[@data-tipname='match/timesheets']");
        private By txtTimesheetApprover1 = By.XPath("//input[contains(@id,'_ddltimesheetapprover1')]");
        private By btnSaveTimesheet = By.XPath("//button[contains(@id,'_btnsave')]");
        private By chckEnableTime = By.XPath("//input[@data-bind='checked: EnableTime']");
        private By btnAddExpenses = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//span[text()='Add Expense']");
        private By ddlRate = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_ddlrate')]");
        private By txtPaid = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_txtexpensepaid')]");
        private By txtRate = By.XPath("//a[text()='Per Diem']");
        private By txtBilled = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_txtexpensebilled')]");
        private By txtLoad = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_txtexpenseload')]");
        private By txtUnit = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_txtexpenseunits')]");
        private By ddlPo = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//input[contains(@id,'_ddltf1')]");
        private By txtPo = By.XPath("//a[text()='PO-123']");

        private By btnAddExpensestime = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblExpenseDays']//td[1]//span[text()='Add']");
        private By chckExpenses = By.XPath("//input[@data-bind='checked: EnableExpenses']");
        private By txtErrorTime = By.XPath("//div[@class='cooltipmessage error']");


        private By lnkRejectMatch = By.XPath("//div[@class='widgetBody']/div[4]/img");
        private By ddlRejectedBy = By.XPath("//div[@id='s2id_autogen1']/a");
        private By txtRejectedBy = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By ddlRejectReason = By.XPath("//div[@id='s2id_autogen5']/a");
        private By txtRejectReason = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnSaveReject = By.XPath("//div[@class='t_Content']//button[@class='btn btn-success']");
        private By btnRejectedStatus = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_pvEdit']/div[1]/div[4]");

        private By ddlRejectRecruiter = By.XPath("//div[@class='col-2']//div[@id='s2id_autogen2']/a");
        private By txtRejectRecruiter = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
       //Verify  Credit Distribution tab 
        private By lnkCreditDistribution = By.XPath("//span[text()='Credit Distribution']");

        private By txtCreditDistribution = By.XPath("//div[@class='highlight']//following-sibling::h3[text()='Current Credit Distribution']");
        private By txtRequiterCredits = By.XPath("//div[@class='highlight']//following-sibling::h3[text()='Recruiter Credits from Transactions']");
        private By txtDepartmentsCredits = By.XPath("//div[@class='highlight']//following-sibling::h3[text()='Department Credits from Transactions']");

        private By btnEditCreditDistribution = By.XPath("//button[text()='Edit Credit Distribution']");
        private By btnCancel = By.XPath("//button[text()='Edit Credit Distribution']//following-sibling::button[text()='Cancel']");
        private By bntResetChanges = By.XPath("//button[text()='Edit Credit Distribution']//following-sibling::button[text()='Reset Changes']");
        private By btnSaveChanges = By.XPath("//button[text()='Edit Credit Distribution']//following-sibling::button[text()='Save Changes']");
        private By btnAddRequiter = By.XPath("//button[text()='Add Recruiter']");
        private By framepvCreditDistribution = By.Id("pvCreditDistribution_frame");
        private By chkChangeCreditTransaction = By.XPath("//label[text()=' Change credit for all transactions']/input");
        private By calander = By.XPath("//label[text()='since ']/span/input"); 		private By rdbtnCreateReversal = By.XPath("//input[@name='ko_unique_2']");
        private By ddlTimesheetToadjust = By.XPath("//div[@id='s2id_autogen11']/a");
        private By txtTimesheetToadjust = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']//input");
        private By txtTimesheetEntryTemplate = By.XPath("//div[@id='ctl00_hpTimesheetEntryTemplateEdit']//input");
        private By lnkRatesovertime = By.Id("ctl00_hpOvertime");
        private By btnRatesEdit = By.XPath("//div[@data-tipname='match/rates']");
        private By ddlperdiem = By.XPath("//input[contains(@id,'ddlperdiemtype')]");
        private By txtdiemType = By.XPath("//a[text()='Tim Hourly']");
        private By btnRateSave = By.XPath("//div[contains(@id,'widget_rates')]//button[contains(@id,'_btnsave')]");
        private By lnkRatesLink = By.XPath("//*[contains(@id,'view_RateGroupList__')]/div/div[2]/div[4]/a");
        private By frameMatcManage = By.XPath("//iframe[contains(@id,'match_manage_')]");
        private By WarningmsgCandidate = By.XPath("//div[@class='warning message']/span[@class='text-bold']");
        private By lnkPayRates = By.XPath("//a[@title='Click to edit this rate']");
        private By imgGreenArrow = By.XPath("//img[contains(@id,'_imgNext')]");
        private By approve = By.XPath("//div[contains(@id,'_divQuestionnaireAnchor')]/div");
        private By popupMsg = By.XPath("//div[@class='t_Tooltip t_Tooltip_blue t_hidden']");
        private By lnkRegisterInvite = By.XPath("//div[starts-with(@id, 'widget_statusadvance')]/img[@src='/Mvc/Content/Images/icons/check.png']");
        private By ddnItemType = By.XPath("//label[text()='Item Type']/../div[1]/a/div/b");
           // By.XPath("//div[@id='s2id_autogen17']/a");
        private By txtItemType = By.XPath("//div[@id='s2id_autogen17']//input[@class='select2-input']");
        private By ddnItemCategory = By.XPath("//label[text()='Item Category']/../div[1]/a/div/b");
            //By.XPath("//div[@id='s2id_autogen16']");
        private By txtItemCategory = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']//input[@class='select2-input']");
        private By btnSave = By.XPath("//div[contains(@id,'manageScheduledItemWidget')]/footer/div/button[text()='Save']");
        private By lnkInterviewscomplete = By.XPath("//div[contains(@id, 'action_status')]/img[@src='/Mvc/Content/Images/icons/check.png']");
        private By lnkAdvanceToIntsComplete = By.XPath("//div[contains(., 'Advance to Ints Complete') and contains(@id,'action_status')]");
        private By lnkAdvanceToofferMade = By.XPath("//div[contains(., 'Advance to Offer Made') and contains(@id,'action_status')]");
        private By lnkScheduleInterview = By.XPath("//div[contains(@id, 'action_scheduleinterview')]/img[@src='/Mvc/Content/Images/icons/check.png']");

        private By txtErrorPositionMatch = By.XPath("//div[@class='t_ContentContainer t_clearfix t_Content_blue']/span");
        private By txtEnterPositionMatch = By.XPath("//div[@class='select2-drop select2-drop-active select2-with-searchbox']//input");
        private By lnkConfirmStart = By.XPath("//div[contains(@id,'action_confirmstart')]/img");
        private By lnkExtendEnddate = By.XPath("//div[contains(@data-tipurl,'endtype=Extend')]");
            //By.XPath("//div[@class='cooltipmenuoption clicktip']/img[@src='/Mvc/Content/Images/icons/check.png']");
        private By txtEstimatedEndDateMatch = By.XPath("//div[@class='range-date']/input");
        private By txtExtensionReason = By.XPath("//label[text()='Extension Reason']/../div/a/span");
            //By.XPath("//div[@id='s2id_autogen2']");
        private By ddnExtensionReason = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnSaveExtension = By.XPath("//header[@class='widgetTitle' and contains(text(),'Extend')]/../footer/div/button[text()='Save']");
        private By rightLinkMatch = By.XPath("//*[@id='RecordCounts']//span[@data-tipname='matchlist' and @data-tipcontext='company']");
        private By rightLinkPosition = By.XPath("//*[@id='RecordCounts']//span[@data-tipname='positionlist' and @data-tipcontext='company']");
        private By frameCompanyMatch = By.XPath("//iframe[contains(@id,'match_By-Company')]");
        private By frameCompanyPosition = By.XPath("//iframe[contains(@id,'position_By-Company')]");
        #endregion

        #region Generate PDF
        private By lnkGenerateDocument = By.XPath("//div[contains(@data-tipurl,'/MVC/Document/GenerateDocument')]");
        private By txtTemplate = By.Id("s2id_PrintTemplate");
        private By btnDownloadDocument = By.XPath("//button[@id='Download']");
        private By inputTemplate =By.XPath("//ul/li//div[text()='DEV-7489 MT']");
        private By radioWordDocument = By.XPath("//input[@id='DocumentTypeWord']");
        private By radioPdfDocument = By.XPath("//input[@id='DocumentTypePDF']");     
        private By lnkMatch = By.XPath("//span[@data-tipname='matchlist']");
        private By lnkNewMatch = By.XPath("//div[text()='New Match']");
        private By btnNewQp = By.XPath("//div[text()='New QP']");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By ddlTimesheetEntryTemplate = By.XPath("//li/a[text()='Detail 6min']");
        private By ddlTimesheetEntryTemplate1 = By.XPath("//li/a[text()='Regression Testing']");
        private By ddnCreditDept = By.XPath("//div[@id='field_SelectedCandidates[5146483]_ContractRequiredCredits[0]_CreditedPerson']/div/a");
        private By inputCreditDept = By.XPath("//div[@id='s2id_SelectedCandidates_5146483__ContractRequiredCredits_0__CreditedPerson']//input");
        private By inputCreditrecruit = By.XPath("//div[@class='t_Tooltip t_Tooltip_red t_hidden']//following-sibling::div[@class='select2-drop select2-drop-active']//input");
        //By.XPath("//div[@id='field_SelectedCandidates[5146483]_ContractRequiredCredits[0]_CreditedPerson']//div/input[@data-helptip='CreditTypePerson']");

        private By msgcandidateAlert = By.XPath("//span[text()='Candidate is in a status that cannot be moved to full placement']");
        private By chckAdjustment = By.XPath("//input[@data-bind='checked: IsAdjustment']");
        #endregion

        public static string contractMatchId = string.Empty;
        #region ------------- Public Methods -------------------------------
        /// <summary>
        /// CreateContractMatch
        /// </summary>
        public string CreateContractMatch(string positionId, string candidateId,string billRate,string PayRate, bool match =false)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(10000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                //driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                //driver.SendKeysToElementAndPressEnter(txtCandidates, candidateId, "Enter candidate");               
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate); 
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(30000);
                contractMatchId = utility.GetTitleId();

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }

        /// <summary>
        /// CreateContractMatchForValidate
        /// </summary>
        /// <param name="positionId"></param>
        /// <param name="candidateId"></param>
        /// <param name="billRate"></param>
        /// <param name="PayRate"></param>
        /// <returns></returns>
        public string CreateContractMatchForValidate(string positionId, string candidateId, string billRate, string PayRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.ClickElement(btnNext, "Next");                         
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(10000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate); //billRate PayRate
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);// PayRate
                actionsnew.Build().Perform();
                driver.ClickElement(btnNextCandidate, "Next");
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Button");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }

        /// <summary>
        /// VerifySubmitalPopUpMsg
        /// </summary>
        public void VerifySubmitalPopUpMsg()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatcManage);
                driver.SwitchToFrameByLocator(frameMatcManage);
                driver.ClickElement(imgGreenArrow, "Green Arrow");
                driver.sleepTime(5000);
                driver.MouseHover(lnkAcceptMatch, "Approve");
                // driver.VerifyWebElementNotPresent(popupMsg, "Popup Message");
                //driver.sleepTime(2000);
                //By by = By.XPath("//div[@class='t_Tooltip t_Tooltip_blue t_hidden']//span[contains(text(),'Not all requirements have been met.')]");
                //driver.VerifyWebElementPresent(popupMsg, "Popup Message");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Submital PopUp Message", "Failed to Verify Submital PopUp Message", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// VerifyAfterChangingStatus
        /// </summary>
        public void VerifyAfterChangingStatus()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatcManage);
                driver.SwitchToFrameByLocator(frameMatcManage);
                driver.WaitElementPresent(imgGreenArrow);
                driver.ClickElement(imgGreenArrow, "Green Arrow");
                driver.MouseHover(lnkAcceptMatch, "Approve");
                driver.sleepTime(5000);
                // driver.VerifyWebElementNotPresent(popupMsg, "Popup Message");
                driver.VerifyWebElementNotPresent(popupMsg, "Popup Message");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Submital PopUp Message", "Failed to Verify Submital PopUp Message", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// Verify Match without updateing the candidate
        /// </summary>
        public void VerifyMatchWithoutCandStatus(string positionID, string candidateName)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.sleepTime(3000);
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionID);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(WarningmsgCandidate);
               // driver.AssertTextContains(WarningmsgCandidate, "is in a status that is not valid for Full Placement.");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Match Without Candidate Status", "Failed Verify Match Without Candidate Status", EngineSetup.GetScreenShotPath());

            }
        }
        
        /// <summary>
        /// Verify without updateing the position status
        /// </summary>
        /// <param name="positionID"></param>
        /// <param name="candidateName"></param>
        public void VefiryMatchWithoutPositionUpdate(string positionID, string candidateName,string endDate,string taxType, string payRate, string billRate,bool QP=true,bool match=false)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.sleepTime(3000);
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionID);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.WaitElementPresent(btnNext);
                //driver.ClickElement(btnNext, "Next");
                //driver.sleepTime(10000);
                //driver.WaitElementPresent(txtCandidates);
                //driver.FindElement(txtCandidates).SendKeys(candidateName);
                //driver.sleepTime(5000);
                //driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.WaitElementPresent(txtEstimatedEndDate);
                //driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                //driver.SendKeysToElementClearFirst(txtEstimatedEndDate, endDate, "Match End Date");
                //driver.ClickElement(txtTaxtype, "Tax type");
                //driver.SendKeysToElementAndPressEnter(inputTaxType, taxType, "Tax Type");
                //driver.ScrollPage();
                //Actions actions = new Actions(driver);
                //actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_PayRate')]/input[2]")));
                //actions.Click();
                //actions.SendKeys(payRate);
                //actions.Build().Perform();
                //actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(@id,'_BillRate')]/input[2]")));
                //actions.Click();
                //actions.SendKeys(billRate);
                //actions.Build().Perform();
                //driver.WaitElementPresent(btnNextQp);
                //driver.ClickElement(btnNextQp, "Next");
                //driver.sleepTime(10000);
                 driver.WaitElementPresent(rerroMsgPosition);
                //if (QP)
                //{
                //    driver.WaitElementPresent(btnCreateOnlyMatch);
                //    driver.ClickElement(btnCreateOnlyMatch, "Create button");
                //}
                //if (match)
                //{
                //    driver.WaitElementPresent(btnApproverWithoutEmail);
                //    driver.ClickElement(btnApproverWithoutEmail, "Approve");
                //}
                driver.sleepTime(5000);
                //  driver.AssertTextContains(rerroMsgPosition, "The selected position is not eligible for matching due to its status.");            
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Vefiry MatchWithout Position Update", "Failed Vefiry MatchWithout Position Update", EngineSetup.GetScreenShotPath());
            }
        }

        /// <summary>
        /// CreateMatchForHourly
        /// </summary>
        /// <param name="positionId"></param>
        /// <param name="candidateId"></param>
        /// <param name="payRate"></param>
        /// <param name="billRate"></param>
        public void CreateMatchForHourly(string positionId, string candidateId,string payRate,string billRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(payRate); //billRate PayRate
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);// PayRate
                actionsnew.Build().Perform();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateMatchForPermHourly(string positionId, string candidateId,string PayRate,string billRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(3000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyRatesInMatch()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameMatcManage);
                driver.VerifyWebElementPresent(lnkRatesLink, "Link Rates");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Rates ", "Failed to verify rates in match", EngineSetup.GetScreenShotPath());

            }
        }
        public void VerifyRatesAfterCreatingMatch()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(20000);
                driver.WaitElementPresent(frameMatcManage);
                driver.SwitchToFrameByLocator(frameMatcManage);
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(lnkPayRates, "Rates link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify match rates ", "Failed to Verify match rates ", EngineSetup.GetScreenShotPath());
            }
        }
     
        /// <summary>
        /// Creating single MatchOnly
        /// </summary>
        /// <param name="positionId"></param>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public string CreateMatchOnly(string positionId, string candidateId)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.ClickElement(btnNext, "Next"); 
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Match Only ", "Failed to Create Match Only", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }
        public void MatchtoFullplacement(string contactid,string date, bool isrequired=false,bool timesheettemplate=false,bool candidateAlert=false,bool matchAlert=true)
        {
             string TimesheetId = string.Empty;
            string template = string.Empty;
            try
            {
                driver.sleepTime(30000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.MouseHover(lnkContract, "Contract start date");
                driver.ClickElementWithJavascript(btnEditContract, "");
                driver.SendKeysToElementAndPressEnter(txtStartDate, date, "Start Date");
                driver.ClickElement(btnSaveStartDate, "Save startdate");
                //driver.ClickElement(btnClosestartDate, "Close Start date");
                home.HandleAlert();
                driver.sleepTime(5000);
                driver.MouseHover(lnkAccounting, "Accounting Tab");
                driver.ClickElementWithJavascript(btnEditAccounting, "Edit button");
                driver.ClickElement(txtBillContact, "Contact");
                driver.ClickElement(inputBillContact, "Billing Contact");
                driver.WaitElementPresent(ddlTimesheetBatch);
                driver.ClickElement(ddlTimesheetBatch, "Timesheet Batch");
                driver.WaitElementPresent(txtTimesheetBatch);
                driver.ClickElement(txtTimesheetBatch, "Select Timesheet Batch");
                driver.ClickElement(btnSaveAccounting, "Save Accounting");
                driver.sleepTime(15000);
                // driver.ClickElement(btnCloseAccounting, "Close Accounting");
                driver.ScrollPage();
                driver.sleepTime(15000);
                driver.MouseHover(lnkTaxinfo, "Tax info");
                driver.WaitElementPresent(btnTaxEdit);
                driver.ClickElementWithJavascript(btnTaxEdit, "TaxEdit");
                driver.ClickElement(ddlBurdenTax, "Burden Tax");
                driver.WaitElementPresent(inputBurdenTax);
                driver.ClickElement(inputBurdenTax, "Burden Tax");
                driver.WaitElementPresent(txtWorkedinstate);
                driver.ClickElement(txtWorkedinstate, "Worked in state");
                driver.WaitElementPresent(inputWorkedinstate);
                driver.ClickElement(inputWorkedinstate, "Worked in local state");
                driver.WaitElementPresent(btnSaveTax);
                driver.ClickElement(btnSaveTax, "Save Tax");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkTimeSheetsinMatch);
                //driver.ClickElement(btnCloseAccounting, "Close Tax");
                driver.MouseHover(lnkTimeSheetsinMatch, "Timesheets Approver in Match");
                //driver.WaitElementPresent(btnEditTimesheets);
                driver.ClickElementWithJavascript(btnEditTimesheets, "Edit Timesheet Approvers");
                driver.WaitElementPresent(txtTimesheetApprover1);
                driver.ClickElement(txtTimesheetApprover1, "Timesheet Approver");
                driver.WaitElementPresent(inputBillContact);
                driver.ClickElement(inputBillContact, "Timesheet Approver");
                By ddntemplate = By.XPath("//input[contains(@id,'ddltimesheetentrytemplate')]");
                driver.ClickElement(ddntemplate, "Timesheet Entry Template Drop down");
                //By by = By.XPath("//span[@role='status' and text()='9 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitElementPresent(by);

                if (timesheettemplate == false)
                    driver.ClickElement(ddlTimesheetEntryTemplate, "Enter Template Value");
                else
                    driver.ClickElement(ddlTimesheetEntryTemplate1, "Enter Template Value");

                if (isrequired==true)
                {                   
                    driver.ClickElement(chbAllowZeroHour, "Click Allow Zero Hour Timesheet");
                }
                driver.WaitElementPresent(btnSaveTimesheet);
                driver.ClickElement(btnSaveTimesheet, "Save Timesheet Approver");
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.WaitElementPresent(btnlocalstatus);
                driver.ClickElement(btnlocalstatus, "Local Status");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ChckLocale);
                driver.ClickElement(ChckLocale, "Checkbox locale");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnSuccess);
                driver.ClickElement(btnSuccess, "Save");
                driver.ScrollPage();
                driver.sleepTime(1000);
                driver.ScrollPage();
                driver.sleepTime(1000);
                driver.ScrollPage();
                driver.WaitElementPresent(lnkRatesovertime);
                driver.MouseHover(lnkRatesovertime, "Ratesovertime");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRatesEdit);
                driver.ClickElementWithJavascript(btnRatesEdit, "RatesEdit");
                driver.sleepTime(5000);
                //driver.WaitElementPresent(ddlperdiem);
                //driver.ClickElement(ddlperdiem, "Diem Type");
                //driver.sleepTime(5000);
                //driver.ClickElement(txtdiemType, "Select Diem Type");
                //driver.sleepTime(5000);
                driver.WaitElementPresent(btnRateSave);
                driver.ClickElement(btnRateSave, "SaveRate");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkRates);
                driver.ClickElement(lnkRates, "Rates");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ChckPublishRates);
                driver.ClickElement(ChckPublishRates, "Publish Rates");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSaveRates);
                driver.ClickElement(btnSaveRates, "Save Published Rates");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkAcceptMatch);
                driver.ClickElement(lnkAcceptMatch, "Accept Match");
                driver.sleepTime(5000);
                //if(candidateAlert==false)
                //{
                if(driver.IsElementPresent(msgcandidateAlert))
                {
                    driver.VerifyWebElementPresent(By.XPath("//span[text()='Candidate is in a status that cannot be moved to full placement']"), "");
                }
                else
                {
                    driver.AcceptAlert();
                }
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Match Full Placement", "Failed to Match Full Placement", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Full placement for perm
        /// </summary>
        public void CreateFullPlacementForPerm(string contactid, string date)
        {
            string TimesheetId = string.Empty;
            try
            {
                //  string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.MouseHover(lnkContract, "Contract start date");
                driver.WaitElementPresent(btnEditContract);
                driver.ClickElementWithJavascript(btnEditContract, "Edit contract");
                driver.SendKeysToElementAndPressEnter(txtStartDate, date, "Start Date");
                driver.WaitElementPresent(btnSaveStartDate);
                driver.ClickElement(btnSaveStartDate, "Save startdate");
                driver.WaitElementPresent(btnClosestartDate);
                driver.ClickElement(btnClosestartDate, "Close Start date");
                driver.MouseHover(lnkAccounting, "Accounting Tab");
                driver.ClickElementWithJavascript(btnEditAccounting, "Edit button");
                driver.WaitElementPresent(txtBillContact);
                driver.ClickElement(txtBillContact, "Contact");
                driver.WaitElementPresent(inputBillContact);
                driver.ClickElement(inputBillContact, "Billing Contact");
                driver.WaitElementPresent(btnSaveAccounting);
                driver.ClickElement(btnSaveAccounting, "Save Accounting");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnCloseAccounting);
                driver.ClickElement(btnCloseAccounting, "Close Accounting");
                driver.ScrollPage();
                driver.MouseHover(lnkTaxinfo, "Tax info");
                driver.ClickElementWithJavascript(btnTaxEdit, "TaxEdit");
                //driver.ClickElement(ddlBurdenTax, "Burden Tax");
                driver.sleepTime(5000);
                //driver.ClickElement(inputBurdenTax, "Burden Tax");
                driver.ClickElement(txtWorkedinstate, "Worked in state");
                driver.WaitElementPresent(inputWorkedinstate);
                driver.ClickElement(inputWorkedinstate, "Worked in local state");
                driver.WaitElementPresent(btnSaveTax);
                driver.ClickElement(btnSaveTax, "Save Tax");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnCloseAccounting);
                driver.ClickElement(btnCloseAccounting, "Close Tax");
                driver.ScrollPage();
                driver.WaitElementPresent(btnlocalstatus);
                driver.ClickElement(btnlocalstatus, "Local Status");
                driver.WaitElementPresent(ChckLocale);
                driver.ClickElement(ChckLocale, "Checkbox locale");
                driver.WaitElementPresent(btnSuccess);
                driver.ClickElement(btnSuccess, "Save");
                driver.ScrollPage();
                //driver.ClickElement(lnkRates, "Rates");
                //driver.ClickElement(ChckPublishRates, "Publish Rates");
                //driver.ClickElement(btnSaveRates, "Save Published Rates");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElementWithJavascript(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkAcceptMatch);
                driver.ClickElement(lnkAcceptMatch, "Accept Match");
                //driver.AcceptAlert();
                home.HandleAlert();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Full Placement For Perm", "Failed to Create Full Placement For Perm", EngineSetup.GetScreenShotPath());
            }
        }
        public string CreateTimesheets(string matchID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.FindElement(txtMatch).SendKeys(matchID);
                driver.sleepTime(5000);
                driver.FindElement(txtMatch).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlPeriod);
                driver.ClickElement(ddlPeriod, "Period");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lstPeriod);
                driver.ClickElement(lstPeriod, "Select Period");
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create timesheet");
                driver.sleepTime(5000); 
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByLocator(iframeTimesheetManage);
                driver.WaitElementPresent(lblTimesheet);
                TimesheetId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Timesheets", "Failed to Create Timesheets", EngineSetup.GetScreenShotPath());
            }
            return TimesheetId;
        }

        public void AddNewPosition()
        {
            try
            {
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.ScrollPage();
                driver.ClickElement(btnAddNewPosition, "Add New Position from Company");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Match from QP", "Failed to Create Match from Qp", EngineSetup.GetScreenShotPath());
            }

        }
        public string SubmitMatchfromcandidatepage(string positionId, string taxType, string payRate, string billRate, string endDate)
        {
            string matchId = string.Empty;
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.ClickElement(btnNextPosition, "Next button");
                //driver.WaitElementPresent(txtCandidates);
                //driver.FindElement(txtCandidates).SendKeys(candidateName);
                driver.sleepTime(30000);
                //driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(txtEstimatedEndDate);
                driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                driver.SendKeysToElementClearFirst(txtEstimatedEndDate, endDate, "Match End Date");
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
                driver.ClickElement(btnNextQp, "Next");
                driver.ClickElement(btnCreateMatchOnly, "Create Match through quick placement");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.ClickElement(imgTimeLine, "Click Image text line");
                driver.ClickElement(lnkConvertToPerm, "Convert To Permanent");
                driver.ClickElement(txtEndDate, "End Date");
                driver.SendKeysToElementAndPressEnter(txtEndDate, endDate, "End Date");
                driver.ClickElement(txtStartConversionDate, "Start Conversion Date");
                //driver.SendKeysToElementAndPressEnter(txtStartConversionDate, today, "Start Conversion Date");
                driver.SendKeysToElementAndPressEnter(txtSalary, "32300", "Salary");
                driver.SendKeysToElementAndPressEnter(txtConversionFee, "200", "Conversion Fee");
                driver.ClickElement(txtEndReason, "End Reason");
                Thread.Sleep(5000);
                // driver.SwitchToDefaultFrame();
                //  driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                //driver.SendKeysToElement(inputEndReason, "Converted to Perm", "EndReason");
                // driver.FindElement(inputEndReason).SendKeys(OpenQA.Selenium.Keys.Tab);                              
                // Thread.Sleep(5000);
                driver.ClickElement(inputEndReason, "Input End Reason");
                driver.ClickElement(btnSavePermanent, "Convert Qp Match to Permanent");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.ClickElement(lnkConvertedMatch, "Timeline");
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.ClickElement(btnTimeLineNext, "Time line next");
                driver.ClickElement(txtCancelledBy, "Cancelled By");
                driver.SendKeysToElementAndPressEnter(txtCancelledBy, "Candidate", "Cancelled By");
                driver.ClickElement(txtCancelReason, "Cancel Reason");
                driver.SendKeysToElementAndPressEnter(txtCancelReason, "Other", "Cancel Reason");
                driver.ClickElement(btnSavePermanent, "Save");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Submit Match", "Failed to Submit Match", EngineSetup.GetScreenShotPath());
            }
            return matchId;
        }

        public void GenerateDocument(string pdfDoc)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(lnkGenerateDocument,"Genereate Document");
                driver.ClickElement(lnkGenerateDocument, "Generate Document");
                driver.ClickElement(txtTemplate, "Template");
                driver.sleepTime(2000);
                driver.ClickElement(inputTemplate, "Template");
                //var options = driver.FindElements(By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/ul"));
                //int optsize = options.Count();
                //Random num = new Random();
                //int Select = num.Next(optsize);
                //string selectopt = string.Format("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/ul/li[{0}]", Select.ToString());
                // var inputTemplate = driver.FindElement(By.XPath("//ul/li//div[text()='DEV-7489 MT']"));
                driver.sleepTime(2000);

                //Select Word/PDF
                if (pdfDoc == "false")
                {
                    driver.ClickElement(radioWordDocument, "Word Format");
                }
                else if (pdfDoc == "true")
                {
                    driver.ClickElement(radioPdfDocument, "Pdf Format");
                }
                //Word OR PDF status check
                //var pdfStatus = driver.FindElement(btnpdfDocument).GetAttribute("checked");
                //var wordStatus = driver.FindElement(btnwordDocument).GetAttribute("checked");
               
                    driver.ClickElement(btnDownloadDocument, "Download Document");
           

                 
                //Actions action = new Actions(driver);
                ////action.KeyDown
                //action.KeyDown(OpenQA.Selenium.Keys.Control).KeyDown(OpenQA.Selenium.Keys.Return).KeyUp(OpenQA.Selenium.Keys.Control).KeyUp(OpenQA.Selenium.Keys.Return).Perform();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Generate PDF Document", "Failed to Generate PDF Document", EngineSetup.GetScreenShotPath());
            }
        }

        public string CreateTimesheetswithExpenses(string matchID,string paid,string Billed,string load,string unit)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtMatch);
                driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlPeriod);
                driver.ClickElement(ddlPeriod, "Period");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lstPeriod);
                driver.ClickElement(lstPeriod, "Select Period");
                driver.WaitElementPresent(chckEnableTime);
                driver.ClickElement(chckEnableTime, "Enable time");
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create timesheet");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkContinuetimesheet);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByLocator(iframeTimesheetManage);
                driver.WaitElementPresent(lblTimesheet);            
                TimesheetId = utility.GetTitleId();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeTimesheetManage);
                driver.SwitchToFrameByLocator(iframeTimesheetManage);
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnAddExpenses);
                driver.ClickElement(btnAddExpenses, "Add Expenses");
                driver.WaitElementPresent(ddlRate);
                driver.ClickElement(ddlRate, "Rate");
                driver.WaitElementPresent(txtRate);
                driver.ClickElement(txtRate, "Rate");
                driver.WaitElementPresent(txtPaid);
                driver.SendKeysToElement(txtPaid, paid, "Paid");
                driver.SendKeysToElement(txtBilled, Billed, "Billed");
                driver.SendKeysToElementClearFirst(txtUnit,unit, "Unit");
                driver.SendKeysToElement(txtLoad, load, "Load");
                driver.WaitElementPresent(btnAddExpensestime);
                driver.ClickElement(btnAddExpensestime, "Add button");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Timesheet with Expenses", "Failed to create timesheet with expenses", EngineSetup.GetScreenShotPath());
            }
            return TimesheetId;
        }
        public string CreateTimesheetswithTimeenables(string matchID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.WaitElementPresent(txtMatch);
                driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlPeriod);
                driver.ClickElement(ddlPeriod, "Period");
                driver.WaitElementPresent(lstPeriod);
                driver.ClickElement(lstPeriod, "Select Period");
                driver.WaitElementPresent(chckExpenses);
                driver.ClickElement(chckExpenses, "Enable time");
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create timesheet");
                driver.sleepTime(2000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkContinuetimesheet);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.SwitchToDefaultFrame();             
                driver.WaitElementPresent(lblTimesheet);
                TimesheetId = utility.GetTitleId();             
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Timesheet with TimeEnabled", "Failed to Create Timesheet with TimeEnabled", EngineSetup.GetScreenShotPath());
            }
            return TimesheetId;
        }

        public void CreateTimesheetwithoutTimeandExpenses(string matchID,string msg)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.WaitElementPresent(txtMatch);
                driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlPeriod);
                driver.ClickElement(ddlPeriod, "Period");
                driver.WaitElementPresent(lstPeriod);
                driver.ClickElement(lstPeriod, "Select Period");
                driver.WaitElementPresent(chckEnableTime);
                driver.ClickElement(chckEnableTime, "Enable time");
                driver.WaitElementPresent(chckExpenses);
                driver.ClickElement(chckExpenses, "Enable time");
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create timesheet");
                driver.sleepTime(3000);
                IWebElement Errormsg = driver.FindElement(By.XPath("//div[@class='cooltipmessage error']"));
                var ErrorTxt = Errormsg.Text.ToString();
                driver.AssertTextMatching(ErrorTxt, msg);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Timesheet with TimeEnabled", "Failed to Create Timesheet with TimeEnabled", EngineSetup.GetScreenShotPath());
            }
            //return TimesheetId;
        }
        public void RejectMatch(string RejectedBy,string RejectReason)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRejectMatch);
                driver.ClickElement(lnkRejectMatch, "Reject Match");
                driver.WaitElementPresent(ddlRejectedBy);
                driver.ClickElement(ddlRejectedBy, "Rejected By");
                driver.SendKeysToElementAndPressEnter(txtRejectedBy, RejectedBy, "Rejected By");
                driver.WaitElementPresent(ddlRejectReason);
                driver.ClickElement(ddlRejectReason, "Reject Reason");
                driver.SendKeysToElementAndPressEnter(txtRejectReason, RejectReason, "Reject Reason");
                driver.ClickElement(btnSaveReject, "Reject Save");
                driver.sleepTime(5000);
                // driver.ClickElement(btnRejectedStatus, "Rejected");
                home.HandleAlert();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Reject Match Link", "Failed to Reject Match Link", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyCreditDistributionTab(string txtCreditDribution)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkCreditDistribution);
                driver.ClickElement(lnkCreditDistribution,"Credit Distribution");
                driver.sleepTime(5000);
                driver.WaitElementPresent(framepvCreditDistribution);
                driver.SwitchToFrameByLocator(framepvCreditDistribution);
                driver.sleepTime(5000);
                //driver.AssertTextContains(txtCreditDistribution, txtCreditDribution);
                //driver.AssertTextContains(txtCreditDistribution, txtCreditDribution);
                driver.AssertTextContains(txtCreditDistribution, txtCreditDribution);
                driver.WaitElementPresent(btnEditCreditDistribution);
                driver.ClickElement(btnEditCreditDistribution, "Edit Credit Distribution");
                driver.VerifyWebElementEnabled(btnCancel, "Button cancel");
                driver.VerifyWebElementEnabled(bntResetChanges, "Reset Changes Button");
                driver.VerifyWebElementEnabled(btnSaveChanges, "Save Changes Button");
                driver.VerifyWebElementEnabled(btnAddRequiter, "Add Reqruiter Button");
                driver.VerifyWebElementEnabled(chkChangeCreditTransaction, "CheckBox");
                bool chkStatus = Convert.ToBoolean(driver.GetElementAttribute(chkChangeCreditTransaction, "checked"));

                if (Convert.ToBoolean(chkStatus) == true)
                {
                    driver.VerifyWebElementEnabled(calander, "CheckBox");
                    driver.WaitElementPresent(calander);
                    driver.ClickElement(calander, "Calander control");
                   // Assert.IsTrue(chkStatus, "Credit Distribution checkbox is checked");
                    //driver.AssertTrue(chkStatus, "Credit Distribution checkbox is checked");
                    TESTREPORT.LogSuccess("Verify Credit Distribution Tab", "Credit Distribution checkbox is checked");
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Credit Distribution Tab", "Credit Distribution checkbox is Not checked");
                   // Assert.IsFalse(chkStatus, "Credit Distribution checkbox is Not checked");
                }
               
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("Verify Credit Distribution Tab", "Failed to Verify Credit Distribution Tab", EngineSetup.GetScreenShotPath());
            }
        }

        public string CreateReversalandAdjustment(string matchID,string timesheetID)
        {
            try
            {

                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.WaitElementPresent(rdbtnCreateReversal);
                driver.ClickElement(rdbtnCreateReversal, "Create Reversal adjustments");
                driver.WaitElementPresent(ddlTimesheetToadjust);
                driver.ClickElement(ddlTimesheetToadjust, "Select Timesheet to adjust");
                driver.SendKeysToElementAndPressEnter(txtTimesheetToadjust,timesheetID, "Sendkeys to timesheet adjustment");
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create Timesheet");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkContinuetimesheet);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByLocator(iframeTimesheetManage);
                driver.WaitElementPresent(lblTimesheet);
                TimesheetId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Reversal and Adjustment Timesheet", "Failed to Create Reversal and Adjustment Timesheet", EngineSetup.GetScreenShotPath());
            }
            return TimesheetId;
        }
        public void CreateNewMatch(string positionId, string candidateId, string billRate, string PayRate)
        {
            try
            {
                driver.sleepTime(10000);
                contractMatchId = string.Empty;                
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);                
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);              
                driver.ScrollPage();
                driver.sleepTime(5000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(25000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create new match", "Failed to Create new match", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyCreateNewMatch(string billRate, string PayRate)
        {
            DateTime ago = DateTime.Now.AddMonths(-3);
            string Previousdate = ago.ToString("M/d/yyyy");
            string EndDate = DateTime.Now.AddDays(-2).ToString("M/d/yyyy");
            string today = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new_candidateapplicationid_')]"));
                driver.sleepTime(5000);                
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");               
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtMatchStartDate);
                driver.ClickElement(txtMatchStartDate, "Match Start Date");
                driver.SendKeysToElementClearFirst(txtMatchStartDate, Previousdate, "Match Start Date");
                driver.sleepTime(3000);
                driver.FindElement(By.XPath("//input[@data-helptip='MatchStartDate']")).SendKeys(OpenQA.Selenium.Keys.Return);
                driver.WaitElementPresent(txtEstimatedEndDate);
                driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                driver.SendKeysToElementClearFirst(txtEstimatedEndDate, EndDate, "Match End Date");
                driver.sleepTime(3000);
                driver.FindElement(txtEstimatedEndDate).SendKeys(OpenQA.Selenium.Keys.Return);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate); 
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.ClickElement(ddnCreditDept, "Select a position");
                driver.sleepTime(5000);
                Actions act = new Actions(driver);
                act.SendKeys("rafael").Perform();
                driver.sleepTime(5000);
                act.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                //driver.sleepTime(10000);
                //contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create new match", "Failed to Create new match", EngineSetup.GetScreenShotPath());
            }
        }

        public string CreateMatchfromRightClick(string positionId, string candidateId, string billRate, string PayRate,string Taxtype,string enddate, bool candidate=true,bool QP=false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                if (candidate)
                {
                    driver.WaitElementPresent(txtCandidates);
                    driver.FindElement(txtCandidates).SendKeys(candidateId);
                    driver.sleepTime(5000);
                    driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                }
                if (QP)
                {
                    driver.sleepTime(10000);
                    driver.WaitElementPresent(txtEstimatedEndDate);
                    driver.ClickElement(txtEstimatedEndDate, "Estimated End Date");
                    driver.WaitElementPresent(txtEstimatedEndDate);
                    driver.SendKeysToElementClearFirst(txtEstimatedEndDate, enddate, "Match End Date");
                    driver.sleepTime(5000);
                    driver.WaitElementPresent(txtTaxtype);
                    driver.ClickElement(txtTaxtype, "Tax type");
                    driver.WaitElementPresent(inputTaxType);
                    driver.SendKeysToElementAndPressEnter(inputTaxType, Taxtype, "Tax Type");
                }
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(10000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.sleepTime(10000);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.WaitElementPresent(btnCreateOnlyMatch);
                driver.ClickElement(btnCreateOnlyMatch, "Create button");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
               
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create new match", "Failed to Create new match", EngineSetup.GetScreenShotPath());
            }

            return contractMatchId;
        }

        public void RightClickToAddNewMatch()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkMatch);
                Actions action = new Actions(driver);
                action.ContextClick(driver.FindElement(lnkMatch)).Build().Perform();
                driver.WaitElementPresent(lnkNewMatch);
                driver.ClickElementWithJavascript(lnkNewMatch, "New Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddcandidateMandatoryWithoutResume", "Failed to AddcandidateMandatoryWithoutResume ", EngineSetup.GetScreenShotPath());
            }
        }
        public void RightClickToAddQPMatch()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkMatch);
                //driver.MouseHover(lnkMatch,"Matches");
                //driver.RightClickElement(lnkMatch,"Matches");
                Actions action = new Actions(driver);
                action.ContextClick(driver.FindElement(lnkMatch)).Build().Perform();
                driver.WaitElementPresent(btnNewQp);
                driver.ClickElementWithJavascript(btnNewQp, "New QP Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddcandidateMandatoryWithoutResume", "Failed to AddcandidateMandatoryWithoutResume ", EngineSetup.GetScreenShotPath());
            }
        }
        public void SubmittalToOffermade(string InterviewItemType,string ItemCat)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Register Invite");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Schedule Interview");
                driver.sleepTime(15000);
                driver.WaitElementPresent(ddnItemType);
                driver.ClickElement(ddnItemType, "Select Item Type");
                //driver.SendKeysToElementAndPressEnter(By.XPath(" //label[text()='Item Type']/../div[1]/div/div/input"), InterviewItemType, "");
                Actions act = new Actions(driver);
                act.SendKeys(InterviewItemType + OpenQA.Selenium.Keys.Enter).Perform();
               //// driver.sleepTime(5000);
               // act.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtItemType, InterviewItemType, "Send Item Type");
                driver.WaitElementPresent(ddnItemCategory);
                driver.ClickElement(ddnItemCategory, "Item Category");
                act.Click();
                //driver.SendKeysToElementAndPressEnter(By.XPath("//label[text()='Item Category']/../div[1]/div/div/input"), ItemCat, "");
                act.SendKeys(ItemCat + OpenQA.Selenium.Keys.Enter).Perform();
               //// driver.sleepTime(5000);
               // act.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtItemCategory, ItemCat, "");
                driver.WaitElementPresent(btnSave);
                driver.ClickElementWithJavascript(btnSave, "Save");
                driver.sleepTime(20000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Past First round");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkInterviewscomplete);
                driver.ClickElement(lnkInterviewscomplete, "Interviews Complete");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "offer will be Made");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "offer Made");
                driver.sleepTime(5000);
            }
           catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Submital to offer", "Failed to submit offer ", EngineSetup.GetScreenShotPath());
            }

        }
        public void firstroundinterviewTooffermade(string InterviewItemType, string ItemCat)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Register Invite");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Schedule Interview");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddnItemType);
                driver.ClickElement(ddnItemType, "Select Item Type");
                //driver.SendKeysToElementAndPressEnter(By.XPath(" //label[text()='Item Type']/../div[1]/div/div/input"), InterviewItemType, "");
                Actions act = new Actions(driver);
                act.SendKeys(InterviewItemType + OpenQA.Selenium.Keys.Enter).Perform();
                //// driver.sleepTime(5000);
                // act.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtItemType, InterviewItemType, "Send Item Type");
                driver.WaitElementPresent(ddnItemCategory);
                driver.ClickElement(ddnItemCategory, "Item Category");
                act.Click();
                //driver.SendKeysToElementAndPressEnter(By.XPath("//label[text()='Item Category']/../div[1]/div/div/input"), ItemCat, "");
                act.SendKeys(ItemCat + OpenQA.Selenium.Keys.Enter).Perform();
                //// driver.sleepTime(5000);
                // act.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnSave);
                driver.ClickElementWithJavascript(btnSave, "Save");
                driver.sleepTime(20000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkAdvanceToIntsComplete);
                driver.ClickElement(lnkAdvanceToIntsComplete, "Advance To Ints complete");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElementWithJavascript(lnkRegisterInvite, "offer will be Made");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElementWithJavascript(lnkRegisterInvite, "offer Made");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("First round interview to offer", "Failed to First round interview to offer ", EngineSetup.GetScreenShotPath());
            }
        }
        public void firstroundinterviewTooffermadethroughAdvancetooffermade(string InterviewItemType, string ItemCat)
        {
            try
            {
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.WaitElementPresent(iframeCandidateinMatch);
            driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
            driver.WaitElementPresent(btnTimeLineNext);
            driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(2000);
            driver.WaitElementPresent(lnkRegisterInvite);
            driver.ClickElement(lnkRegisterInvite, "Register Invite");
                driver.sleepTime(5000);
            driver.WaitElementPresent(btnRefreshCandidate);
            driver.ClickElementWithJavascript(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
            driver.WaitElementPresent(btnTimeLineNext);
            driver.ClickElementWithJavascript(btnTimeLineNext, "Next Button");
                driver.sleepTime(2000);
            driver.WaitElementPresent(lnkRegisterInvite);
            driver.ClickElement(lnkRegisterInvite, "Schedule Interview");
            driver.sleepTime(10000);
            driver.WaitElementPresent(ddnItemType);
            driver.ClickElement(ddnItemType, "Select Item Type");
            //driver.SendKeysToElementAndPressEnter(By.XPath(" //label[text()='Item Type']/../div[1]/div/div/input"), InterviewItemType, "");
            Actions act = new Actions(driver);
            act.SendKeys(InterviewItemType + OpenQA.Selenium.Keys.Enter).Perform();
            //// driver.sleepTime(5000);
            // act.SendKeys(OpenQA.Selenium.Keys.Enter);
            driver.sleepTime(5000);
            //driver.SendKeysToElementAndPressEnter(txtItemType, InterviewItemType, "Send Item Type");
            driver.WaitElementPresent(ddnItemCategory);
            driver.ClickElement(ddnItemCategory, "Item Category");
            act.Click();
            //driver.SendKeysToElementAndPressEnter(By.XPath("//label[text()='Item Category']/../div[1]/div/div/input"), ItemCat, "");
            act.SendKeys(ItemCat + OpenQA.Selenium.Keys.Enter).Perform();
            //// driver.sleepTime(5000);
            // act.SendKeys(OpenQA.Selenium.Keys.Enter);
            driver.sleepTime(5000);
            driver.WaitElementPresent(btnSave);
            driver.ClickElementWithJavascript(btnSave, "Save");
                driver.sleepTime(20000);
            driver.WaitElementPresent(btnRefreshCandidate);
            driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(10000);
            driver.WaitElementPresent(btnTimeLineNext);
            driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(2000);
            driver.WaitElementPresent(lnkAdvanceToofferMade);
            driver.ClickElement(lnkAdvanceToofferMade, "Advance To offermade");
            driver.sleepTime(10000);
            driver.WaitElementPresent(btnRefreshCandidate);
            driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
            driver.sleepTime(10000);
            driver.WaitElementPresent(btnTimeLineNext);
            driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(2000);
            driver.WaitElementPresent(lnkRegisterInvite);
            driver.ClickElement(lnkRegisterInvite, "offer Made");
            driver.sleepTime(10000);
        }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("firstround interview Tooffermade throughAdvancetooffermade", "Failed to firstround interview Tooffermade throughAdvancetooffermade", EngineSetup.GetScreenShotPath());
            }
        }

        public void SubmittalTooffermadeincluding1stroundand2ndround(string InterviewItemType, string ItemCat)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Register Invite");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Schedule Interview");
                driver.WaitElementPresent(ddnItemType);
                driver.ClickElement(ddnItemType, "Select Item Type");
                driver.SendKeysToElementAndPressEnter(txtItemType, InterviewItemType, "Send Item Type");
                driver.WaitElementPresent(ddnItemCategory);
                driver.ClickElement(ddnItemCategory, "Item Category");
                driver.SendKeysToElementAndPressEnter(txtItemCategory, ItemCat, "");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(3000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "Past First round");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkScheduleInterview);
                driver.ClickElement(lnkScheduleInterview, "Interviews Complete");
                driver.WaitElementPresent(ddnItemType);
                driver.sleepTime(10000);
                driver.ClickElement(ddnItemType, "Select Item Type");
                //driver.SendKeysToElementAndPressEnter(txtItemType, InterviewItemType, "Send Item Type");
                Actions act = new Actions(driver);
                act.SendKeys(InterviewItemType + OpenQA.Selenium.Keys.Enter).Perform();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnItemCategory);
                driver.ClickElement(ddnItemCategory, "Item Category");
                act.Click();
                act.SendKeys(ItemCat + OpenQA.Selenium.Keys.Enter).Perform();
                driver.sleepTime(5000);
                //driver.SendKeysToElementAndPressEnter(txtItemCategory, ItemCat, "");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(3000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkInterviewscomplete);
                driver.ClickElement(lnkInterviewscomplete, "Interviews Complete");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "offer will be Made");
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.WaitElementPresent(lnkRegisterInvite);
                driver.ClickElement(lnkRegisterInvite, "offer Made");
                driver.sleepTime(2000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Submittal To offermade including 1stroundand2ndround", "Failed to Submit To offermade including 1stroundand2ndround", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyerrormessageMatchtoFullplacement(string date,string Errormessage)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.MouseHover(lnkContract, "Contract start date");
                driver.ClickElementWithJavascript(btnEditContract, "");
                driver.SendKeysToElementAndPressEnter(txtStartDate, date, "Start Date");
                driver.ClickElement(btnSaveStartDate, "Save startdate");
                driver.ClickElement(btnClosestartDate, "Close Start date");
                driver.MouseHover(lnkAccounting, "Accounting Tab");
                driver.ClickElementWithJavascript(btnEditAccounting, "Edit button");
                driver.ClickElementWithJavascript(txtBillContact, "Contact");
                driver.ClickElementWithJavascript(inputBillContact, "Billing Contact");               
                driver.ClickElement(ddlTimesheetBatch, "Timesheet Batch");                
                driver.ClickElement(txtTimesheetBatch, "Select Timesheet Batch");
                driver.ClickElement(btnSaveAccounting, "Save Accounting");
                driver.ClickElement(btnCloseAccounting, "Close Accounting");
                driver.ScrollPage();
                driver.MouseHover(lnkTaxinfo, "Tax info");
                driver.ClickElementWithJavascript(btnTaxEdit, "TaxEdit");
                driver.ClickElement(ddlBurdenTax, "Burden Tax");
                driver.sleepTime(10000);
                driver.ClickElement(inputBurdenTax, "Burden Tax");
                driver.ClickElement(txtWorkedinstate, "Worked in state");
                driver.ClickElement(inputWorkedinstate, "Worked in local state");
                driver.ClickElementWithJavascript(btnSaveTax, "Save Tax");
                driver.sleepTime(10000);
                //driver.WaitElementPresent(btnCloseAccounting);
                //driver.ClickElementWithJavascript(btnCloseAccounting, "Close Tax");
                //driver.sleepTime(10000);
                driver.ScrollToPageTop();
                driver.sleepTime(5000);
                driver.MouseHover(lnkTimeSheetsinMatch, "Timesheets Approver in Match");
                driver.WaitElementPresent(btnEditTimesheets);
                driver.ClickElementWithJavascript(btnEditTimesheets, "Edit Timesheet Approvers");
                driver.ClickElement(txtTimesheetApprover1, "Timesheet Approver");
                driver.ClickElementWithJavascript(inputBillContact, "Timesheet Approver");
                driver.ClickElementWithJavascript(btnSaveTimesheet, "Save Timesheet Approver");
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnlocalstatus);
                driver.ClickElement(btnlocalstatus, "Local Status");
                driver.WaitElementPresent(ChckLocale);
                driver.ClickElement(ChckLocale, "Checkbox locale");
                driver.ClickElementWithJavascript(btnSuccess, "Save");
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                driver.MouseHoverByJavaScript(lnkRatesovertime, "Ratesovertime");
                driver.WaitElementPresent(btnRatesEdit);
                driver.ClickElementWithJavascript(btnRatesEdit, "RatesEdit");
                driver.ClickElementWithJavascript(ddlperdiem, "Diem Type");
                driver.ClickElementWithJavascript(txtdiemType, "Select Diem Type");
                driver.ClickElementWithJavascript(btnRateSave, "SaveRate");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkRates);
                driver.ClickElementWithJavascript(lnkRates, "Rates");
                driver.ClickElement(ChckPublishRates, "Publish Rates");
                driver.ClickElement(btnSaveRates, "Save Published Rates");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElementWithJavascript(btnTimeLineNext, "Next Button");
                driver.sleepTime(10000);
                driver.MouseHover(lnkAcceptMatch, "Accept Match");
                driver.VerifyTextValue(txtErrorPositionMatch, Errormessage, "Manage Login");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Match from QP", "Failed to Create Match from Qp", EngineSetup.GetScreenShotPath());
            }

        }
        public string CreateMatchfromRightPanel(string positionId, string candidateId, string billRate, string PayRate,bool Position=true)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(10000);
                if (Position)
                {
                    driver.WaitElementPresent(ddnSelectPosition);
                    driver.ClickElement(ddnSelectPosition, "Select a position");
                    driver.WaitElementPresent(txtEnterPosition);
                    driver.FindElement(txtEnterPosition).SendKeys(positionId);
                    driver.sleepTime(5000);
                    driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.sleepTime(5000);
                }
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCandidates);
                driver.SendKeysToElement(txtCandidates, candidateId, "Enter candidate");
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.sleepTime(5000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(10000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Match from Right Panel", "Failed to Create Match from Right Panel", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }
        public void ExtendEndDate(string nextmnth)
        {
            try
            {
                //driver.sleepTime(2000);
                //driver.WaitElementPresent(btnRefreshCandidate);
                //driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkConfirmStart);
                driver.ClickElement(lnkConfirmStart, "Confirm Start");
                //driver.sleepTime(2000);
                //driver.WaitElementPresent(btnRefreshCandidate);
                //driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkExtendEnddate);
                driver.ClickElement(lnkExtendEnddate, "Extend");
                driver.sleepTime(2000);
                driver.WaitElementPresent(txtEstimatedEndDateMatch);
                driver.SendKeysToElement(txtEstimatedEndDateMatch, nextmnth, "ExtendDate");
                driver.sleepTime(1000);
                driver.FindElement(txtEstimatedEndDateMatch).SendKeys(OpenQA.Selenium.Keys.Tab);
                driver.sleepTime(3000);
                driver.WaitElementPresent(txtExtensionReason);
                driver.ClickElement(txtExtensionReason, "Extension Reason");
                driver.SendKeysToElement(ddnExtensionReason, "Completed Eng - Favorable", "Extension Reason");
                driver.sleepTime(2000);
                driver.FindElement(ddnExtensionReason).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnSaveExtension);
                driver.ClickElement(btnSaveExtension, "Save");
                driver.sleepTime(2000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Extend End Date", "Failed to Extend End Date", EngineSetup.GetScreenShotPath());
            }
        }
        public string CreateMatchfrompositionRightPanel(string positionId, string candidateId, string billRate, string PayRate)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.ClickElement(ddnSelectPosition, "Select a position");
               driver.FindElement(txtEnterPositionMatch).SendKeys(positionId);
                driver.sleepTime(15000);
                driver.FindElement(txtEnterPositionMatch).SendKeys(OpenQA.Selenium.Keys.Enter);
                //  driver.SendKeysToElementAndPressEnter(txtEnterPosition, positionId, "Enter position");
                driver.ClickElement(btnNext, "Next");
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                //driver.SendKeysToElementAndPressEnter(txtCandidates, candidateId, "Enter candidate");
                //driver.FindElement(txtCandidates).SendKeys(candidateId);
                //driver.sleepTime(15000);
                //driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.ClickElement(btnNextSubmital, "Next");
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(billRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(PayRate);
                actionsnew.Build().Perform();
                driver.ClickElement(btnNextCandidate, "Next");
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }

       public string CreateMatchForMultipleCandidate(string positionId, string candidateId,string candidateId1, string billRate, string PayRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId1);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(string.Format("//div[@id='field_SelectedCandidates[{0}]_PayRate']//input[2]", candidateId))));
                actions.Click();
                actions.SendKeys(PayRate); 
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(string.Format("//div[@id='field_SelectedCandidates[{0}]_BillRate']//input[2]", candidateId))));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.ScrollPage();
                driver.ScrollPage();
                driver.ScrollPage();
                driver.ScrollPage();
                driver.ScrollPage();
                Actions actions1 = new Actions(driver);
                actions1.MoveToElement(driver.FindElement(By.XPath(string.Format("//div[@id='field_SelectedCandidates[{0}]_PayRate']//input[2]", candidateId1))));
                actions1.Click();
                actions1.SendKeys(PayRate); 
                actions1.Build().Perform();
                Actions actionsnew1 = new Actions(driver);
                actionsnew1.MoveToElement(driver.FindElement(By.XPath(string.Format("//div[@id='field_SelectedCandidates[{0}]_BillRate']//input[2]", candidateId1))));
                actionsnew1.Click();
                actionsnew1.SendKeys(billRate);
                actionsnew1.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(10000);
                //driver.sleepTime(20000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                By frmMatchReview=By.XPath("//iframe[contains(@id,'match_review')]");
                driver.SwitchToFrameByLocator(frmMatchReview);
                By lnkMatchForCand1 = By.XPath("//*[@id='matchesToReview']/form/div/table/tbody/tr[1]/td[1]/a");
                driver.ClickElement(lnkMatchForCand1, "Click on Match Id for Candidate1");
               // contractMatchId = utility.GetTitleId();
                
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match for multiple candidates", "Failed to Create contract match for multiple candidates", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }


        public string CreatePermMatch(string positionId, string candidateId)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(2000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(3000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnNextSubmital);
                driver.ClickElement(btnNextSubmital, "Next");
                driver.WaitElementPresent(btnApproverWithoutEmail);
                driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                driver.sleepTime(20000);
                contractMatchId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Permanent match", "Failed to Create Permanent match", EngineSetup.GetScreenShotPath());
            }
            return contractMatchId;
        }

        public void VerfiyMatchfromCompany(string companyID,string matchID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                By by = By.XPath(string.Format("//div[contains(@id,'tab_company_manage')]//span[contains(@data-tabtext,'{0}')]", companyID));
                driver.ClickElement(by, "Click on company tab");
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameCompanyManage);
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(rightLinkMatch);
                driver.ClickElement(rightLinkMatch, "Click on match in right pane");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameCompanyMatch);
                driver.SwitchToFrameByLocator(frameCompanyMatch);
                driver.sleepTime(20000);
                By match = By.XPath(string.Format("//div/a[contains(text(),'{0}')]", matchID));
                driver.WaitElementPresent(match);
                if (driver.IsElementPresent(match))
                    TESTREPORT.LogSuccess("Verfiy Match from Company", "Match is linked to Company");
                else
                    TESTREPORT.LogFailure("Verfiy Match from Company", "Match is not linked to Company");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verfiy Match from Company", "Failed to Verfiy Match from Company", EngineSetup.GetScreenShotPath());
            }
        }

        
        public void VerfiyPositionfromCompany(string companyID,string positionID)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                By by = By.XPath(string.Format("//div[contains(@id,'tab_company_manage')]//span[contains(@data-tabtext,'{0}')]", companyID));
                driver.ClickElement(by, "Click on company tab");
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameCompanyManage);
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(rightLinkPosition);
                driver.ClickElement(rightLinkPosition, "Click on position in right pane");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameCompanyPosition);
                driver.SwitchToFrameByLocator(frameCompanyPosition);
                driver.sleepTime(10000);
                By position = By.XPath(string.Format("//div/a[contains(text(),'{0}')]", positionID));
                driver.WaitElementPresent(position);
                if (driver.IsElementPresent(position))
                    TESTREPORT.LogSuccess("Verfiy Position from Company", "Position is linked to Company");
                else
                    TESTREPORT.LogFailure("Verfiy Position from Company", "Position is not linked to Company");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verfiy Position from Company", "Failed to Verfiy Position from Company", EngineSetup.GetScreenShotPath());
            }
        }


       /* public void MatchtoFullplacement1(string contactid, string date, bool isrequired = false, bool timesheettemplate = false, bool candidateAlert = false, bool matchAlert = true)
        {
            string TimesheetId = string.Empty;
            string template = string.Empty;
            try
            {
                driver.sleepTime(30000);
                driver.WaitElementPresent(iframeCandidateinMatch);
                driver.SwitchToFrameByLocator(iframeCandidateinMatch);
                driver.MouseHover(lnkContract, "Contract start date");
                driver.ClickElementWithJavascript(btnEditContract, "");
                driver.SendKeysToElementAndPressEnter(txtStartDate, date, "Start Date");
                driver.ClickElement(btnSaveStartDate, "Save startdate");
                //driver.ClickElement(btnClosestartDate, "Close Start date");
                driver.sleepTime(5000);
                driver.MouseHover(lnkAccounting, "Accounting Tab");
                driver.ClickElementWithJavascript(btnEditAccounting, "Edit button");
                driver.ClickElement(txtBillContact, "Contact");
                driver.ClickElement(inputBillContact, "Billing Contact");
                driver.WaitElementPresent(ddlTimesheetBatch);
                driver.ClickElement(ddlTimesheetBatch, "Timesheet Batch");
                driver.WaitElementPresent(txtTimesheetBatch);
                driver.ClickElement(txtTimesheetBatch, "Select Timesheet Batch");
                driver.ClickElement(btnSaveAccounting, "Save Accounting");
                driver.sleepTime(15000);
                // driver.ClickElement(btnCloseAccounting, "Close Accounting");
                driver.ScrollPage();
                driver.sleepTime(15000);
                driver.MouseHover(lnkTaxinfo, "Tax info");
                driver.WaitElementPresent(btnTaxEdit);
                driver.ClickElementWithJavascript(btnTaxEdit, "TaxEdit");
                driver.ClickElement(ddlBurdenTax, "Burden Tax");
                driver.WaitElementPresent(inputBurdenTax);
                driver.ClickElement(inputBurdenTax, "Burden Tax");
                driver.WaitElementPresent(txtWorkedinstate);
                driver.ClickElement(txtWorkedinstate, "Worked in state");
                driver.WaitElementPresent(inputWorkedinstate);
                driver.ClickElement(inputWorkedinstate, "Worked in local state");
                driver.WaitElementPresent(btnSaveTax);
                driver.ClickElement(btnSaveTax, "Save Tax");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkTimeSheetsinMatch);
                //driver.ClickElement(btnCloseAccounting, "Close Tax");
                driver.MouseHover(lnkTimeSheetsinMatch, "Timesheets Approver in Match");
                //driver.WaitElementPresent(btnEditTimesheets);
                driver.ClickElementWithJavascript(btnEditTimesheets, "Edit Timesheet Approvers");
                driver.WaitElementPresent(txtTimesheetApprover1);
                driver.ClickElement(txtTimesheetApprover1, "Timesheet Approver");
                driver.WaitElementPresent(inputBillContact);
                driver.ClickElement(inputBillContact, "Timesheet Approver");
                By ddntemplate = By.XPath("//input[contains(@id,'ddltimesheetentrytemplate')]");
                driver.ClickElement(ddntemplate, "Timesheet Entry Template Drop down");
                //By by = By.XPath("//span[@role='status' and text()='9 results are available, use up and down arrow keys to navigate.']");
                //driver.WaitElementPresent(by);

                if (timesheettemplate == false)
                    driver.ClickElement(ddlTimesheetEntryTemplate, "Enter Template Value");
                else
                    driver.ClickElement(ddlTimesheetEntryTemplate1, "Enter Template Value");

                if (isrequired == true)
                {
                    driver.ClickElement(chbAllowZeroHour, "Click Allow Zero Hour Timesheet");
                }
                driver.WaitElementPresent(btnSaveTimesheet);
                driver.ClickElement(btnSaveTimesheet, "Save Timesheet Approver");
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.WaitElementPresent(btnlocalstatus);
                driver.ClickElement(btnlocalstatus, "Local Status");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ChckLocale);
                driver.ClickElement(ChckLocale, "Checkbox locale");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnSuccess);
                driver.ClickElement(btnSuccess, "Save");
                driver.ScrollPage();
                driver.sleepTime(1000);
                driver.ScrollPage();
                driver.sleepTime(1000);
                driver.ScrollPage();
                driver.WaitElementPresent(lnkRatesovertime);
                driver.MouseHover(lnkRatesovertime, "Ratesovertime");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRatesEdit);
                driver.ClickElementWithJavascript(btnRatesEdit, "RatesEdit");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlperdiem);
                driver.ClickElement(ddlperdiem, "Diem Type");
                driver.sleepTime(5000);
                driver.ClickElement(txtdiemType, "Select Diem Type");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRateSave);
                driver.ClickElement(btnRateSave, "SaveRate");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkRates);
                driver.ClickElement(lnkRates, "Rates");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ChckPublishRates);
                driver.ClickElement(ChckPublishRates, "Publish Rates");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSaveRates);
                driver.ClickElement(btnSaveRates, "Save Published Rates");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnRefreshCandidate);
                driver.ClickElement(btnRefreshCandidate, "Refresh Match Page");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkAcceptMatch);
                driver.ClickElement(lnkAcceptMatch, "Accept Match");
                driver.sleepTime(10000);
                //if(candidateAlert==false)
                //{
                //    driver.VerifyWebElementPresent(By.XPath("//span[text()='Candidate is in a status that cannot be moved to full placement']"),"");
                //}
                ////driver.sleepTime(1000);
                //if (matchAlert==true)
                //{
                //    driver.AcceptAlert();
                //}
                if (driver.IsElementPresent(msgcandidateAlert))
                {
                    driver.VerifyWebElementPresent(By.XPath("//span[text()='Candidate is in a status that cannot be moved to full placement']"), "");
                }
                //driver.sleepTime(1000);
                if (matchAlert == true)
                {
                    driver.AcceptAlert();
                }
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Match Full Placement", "Failed to Match Full Placement", EngineSetup.GetScreenShotPath());
            }

        }*/

        public void UnRejectMatch()
        {
            try
            {
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnTimeLineNext);
                driver.ClickElement(btnTimeLineNext, "Next Button");
                By byUnRejectMatch = By.XPath("//div[contains(@id,'action_unreject')]");
                driver.WaitElementPresent(byUnRejectMatch);
                driver.ClickElement(byUnRejectMatch, "unReject Match");
                driver.sleepTime(5000);
         
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("UnReject Match Link", "Failed to UnReject Match Link", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateMatch_ApproveandEmailContact(string positionId, string candidateId, string PayRate, string billRate)
        {
            try
            {
                //contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(10000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Approve and Email Contact", "Selecting Approve and Email Contact");
                driver.WaitElementPresent(btnApproveEmail);
                driver.ClickElement(btnApproveEmail, "Click on Approve");
                driver.sleepTime(30000);
                contractMatchId = utility.GetTitleId();
                if (!string.IsNullOrEmpty(contractMatchId))
                    TESTREPORT.LogSuccess("Create Match", "Able to create match using Approve and Email Contact option");
                else
                    TESTREPORT.LogFailure("Create Match", "Failed to create match using Approve and Email Contact option");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            }


        public void CreateMatch_CreateMatchonly(string positionId, string candidateId, string PayRate, string billRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(10000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Create Match Only", "Selecting Create Match Only");
                driver.WaitElementPresent(btnCreateMatchOnly);
                driver.ClickElement(btnCreateMatchOnly, "Click on Create Match only");
                driver.sleepTime(30000);
                contractMatchId = utility.GetTitleId();
                if(!string.IsNullOrEmpty(contractMatchId))
                    TESTREPORT.LogSuccess("Create Match", "Able to create match using Create Match only option");
                else
                    TESTREPORT.LogFailure("Create Match", "Failed to create match using Create Match only option");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            }

        public void CreateMatch_RequestApproval(string positionId, string candidateId, string PayRate, string billRate)
        {
            try
            {
                contractMatchId = string.Empty;
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAddNew();
                home.MouseHoverOnMatch();
                home.ClickOnMatch();
                driver.sleepTime(10000);
                driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnSelectPosition);
                driver.ClickElement(ddnSelectPosition, "Select a position");
                driver.WaitElementPresent(txtEnterPosition);
                driver.FindElement(txtEnterPosition).SendKeys(positionId);
                driver.sleepTime(5000);
                driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnNext);
                driver.ClickElement(btnNext, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtCandidates);
                driver.FindElement(txtCandidates).SendKeys(candidateId);
                driver.sleepTime(5000);
                driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(10000);
                driver.ScrollPage();
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                actions.Click();
                actions.SendKeys(PayRate);
                actions.Build().Perform();
                Actions actionsnew = new Actions(driver);
                actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                actionsnew.Click();
                actionsnew.SendKeys(billRate);
                actionsnew.Build().Perform();
                driver.WaitElementPresent(btnNextCandidate);
                driver.ClickElement(btnNextCandidate, "Next");
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlSubmitalType);
                driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                driver.SendKeysToElementAndPressEnter(txtSubmital, "Request Approval", "Selecting Approve");
                driver.WaitElementPresent(btnRequestApproval);
                driver.ClickElement(btnRequestApproval, "Click on Approve");
                driver.sleepTime(30000);
                contractMatchId = utility.GetTitleId();
                if (!string.IsNullOrEmpty(contractMatchId))
                    TESTREPORT.LogSuccess("Create Match", "Able to create match using Request Approval option");
                else
                    TESTREPORT.LogFailure("Create Match", "Failed to create match using Request Approval option");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
            }
            }

        /* public string CreateMatch_ApprovewithoutsendingEmail(string positionId, string candidateId, string billRate, string PayRate)
         {
             try
             {
                 contractMatchId = string.Empty;
                 driver.SwitchToDefaultFrame();
                 home.ClickOnLogoMenu();
                 home.MouseHoverOnAddNew();
                 home.MouseHoverOnMatch();
                 home.ClickOnMatch();
                 driver.sleepTime(10000);
                 driver.WaitElementPresent(By.XPath(".//iframe[contains(@id,'match_new')]"));
                 driver.SwitchToFrameByLocator(By.XPath(".//iframe[contains(@id,'match_new')]"));
                 driver.sleepTime(5000);
                 driver.WaitElementPresent(ddnSelectPosition);
                 driver.ClickElement(ddnSelectPosition, "Select a position");
                 driver.WaitElementPresent(txtEnterPosition);
                 driver.FindElement(txtEnterPosition).SendKeys(positionId);
                 driver.sleepTime(5000);
                 driver.FindElement(txtEnterPosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                 driver.WaitElementPresent(btnNext);
                 driver.ClickElement(btnNext, "Next");
                 driver.sleepTime(10000);
                 driver.WaitElementPresent(txtCandidates);
                 driver.FindElement(txtCandidates).SendKeys(candidateId);
                 driver.sleepTime(5000);
                 driver.FindElement(txtCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                 driver.sleepTime(10000);
                 driver.ScrollPage();
                 Actions actions = new Actions(driver);
                 actions.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divPayRate']/div/label/following-sibling::input[2]")));
                 actions.Click();
                 actions.SendKeys(PayRate);
                 actions.Build().Perform();
                 Actions actionsnew = new Actions(driver);
                 actionsnew.MoveToElement(driver.FindElement(By.XPath(".//span[@class='divBillRate']/div/label/following-sibling::input[2]")));
                 actionsnew.Click();
                 actionsnew.SendKeys(billRate);
                 actionsnew.Build().Perform();
                 driver.WaitElementPresent(btnNextCandidate);
                 driver.ClickElement(btnNextCandidate, "Next");
                 driver.sleepTime(10000);
                 driver.WaitElementPresent(ddlSubmitalType);
                 driver.ClickElement(ddlSubmitalType, "Drop down submital type");
                 driver.SendKeysToElementAndPressEnter(txtSubmital, "Approve and Email Contact", "Selecting Approve and Email Contact");
                 driver.WaitElementPresent(btnApproverWithoutEmail);
                 driver.ClickElement(btnApproverWithoutEmail, "Click on Approve");
                 driver.sleepTime(30000);
                 contractMatchId = utility.GetTitleId();
             }
             catch (Exception ex)
             {
                 this.TESTREPORT.LogFailure("Create contract match", "Failed to Create contract match", EngineSetup.GetScreenShotPath());
             }
             return contractMatchId;
         }*/

        #endregion

        public string CreateTimesheetswithTimeenables(string matchID, bool time = false, bool expense = false, bool adjustment = false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                home.MouseHoverOnAccounting();
                home.MouseHoverOnCreateTimesheet();
                home.ClickOnOneTimesheet();
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlMatch);
                driver.ClickElement(ddlMatch, "Match");
                driver.WaitElementPresent(txtMatch);
                driver.SendKeysToElementAndPressEnter(txtMatch, matchID, "Match");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlPeriod);
                driver.ClickElement(ddlPeriod, "Period");
                driver.WaitElementPresent(lstPeriod);
                driver.ClickElement(lstPeriod, "Select Period");
                driver.sleepTime(3000);
                if (time)
                {
                    driver.WaitElementPresent(chckExpenses);
                    driver.ClickElement(chckExpenses, "Enable time");
                }
                if (expense)
                {
                    driver.WaitElementPresent(chckEnableTime);
                    driver.ClickElement(chckEnableTime, "Enable Expense");
                }
                if (adjustment)
                {
                    driver.WaitElementPresent(chckAdjustment);
                    driver.ClickElement(chckAdjustment, "Enable Adjustment");
                    driver.WaitElementPresent(chckEnableTime);
                    driver.ClickElement(chckEnableTime, "Enable time");
                }
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnCreate);
                driver.ClickElement(btnCreate, "Create timesheet");
                driver.sleepTime(2000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframetimesheet);
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkContinuetimesheet);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.WaitElementPresent(lblTimesheet);
                TimesheetId = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Timesheet with TimeEnabled", "Failed to Create Timesheet with TimeEnabled", EngineSetup.GetScreenShotPath());
            }
            return TimesheetId;
        }

    }
}
