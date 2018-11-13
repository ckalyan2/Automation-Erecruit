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
    public class AccountingPage : AbstractTemplatePage
    {
        #region UI Object Repository
        private By ddlPayEndDate = By.Id("ctl00_ctl00_cphMain_cphRightBar_ddlPeriodEndDate_Input");
        private By txtPayEndDate = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphRightBar_ddlPeriodEndDate_DropDown']/div/ul/li");
        private By ChkIncludeW2 = By.XPath("//div[@id='report_options_section']/div[@class='section_content']/div[@id='ctl00_ctl00_cphMain_cphRightBar_ctl00']/div[3]/input[@id='chkIncludeW2']");
        private By ChKInclude1099 = By.XPath("//div[@id='report_options_section']/div[@class='section_content']/div[@id='ctl00_ctl00_cphMain_cphRightBar_ctl00']/div[3]/input[@id='chkInclude1099']");
        private By btnGenerateReport = By.XPath("//div[@id='report_options_section']/div[@class='section_content']/div[@id='ctl00_ctl00_cphMain_cphRightBar_ctl00']/div[@class='option nohover']/span");
        private By lnkTimeSheet = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet']/div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_GridData']/table/tbody/tr[2]/td[3]/nobr/span/a");
        private By btnEdithours = By.XPath("//div[@class='t_Content']/div[@class='t_ContentContainer t_clearfix t_Content_erecruitDefault']/div[@class='rcoptions ui-helper-clearfix']/div[5]/div/img");
        private By txtHours = By.XPath("//div[@class='widgetwrapper']/div/table/tbody/tr/td[1]/div/table/tbody/tr[2]/td[1]/input");
        private By btnSave = By.XPath("//div[@class='widgetwrapper']/div/div[@class='widgetfooter']/span[@class='buttons']/button[contains(@id,'_btnsave')]");
        private By iframeTimesheet = By.XPath("//iframe[contains(@id,'timesheet_manage')]");
        //ctl00_ctl00_cphMain_cphBottomButtons_btnSubmit_input
        private By btnSubmit = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnSubmit_input");
        private By btnApprove = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnApprove_input");
        private By btnReject = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnReject_input");
        //private By btnTooltipSubmit = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible']/div[@class='t_Content']/ div/div[2]/div[contains(@id,'widget_submittimesheet')]/div[@class='widgetfooter']/ span/button[contains(@id,'_btnsubmit')]");
        private By btnTooltipApprove = By.XPath("//button[contains(@id,'_btnsubmit')]");
        private By timeSheetID = By.XPath("//div[@class='Display']/div/label[text()='Timesheet ID:']");
        private By txtTimesheetID = By.XPath("//div[6]/div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");//By.XPath("//div[@class='filter-content']/div/input");
        private By lnkTimesheetId = By.XPath("//a[text()='2294807']");
        private By btnSearch = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[2]/div[1]/input");
        private By lnkSubmit = By.Id("ctl00_ctl00_cphMain_cphRightBar_btnSubmitSelected");
        private By lnkApprove = By.Id("//div[@id='with_selected_section']/div[2]/div[1]/div/text()");
        private By ChckReject = By.XPath("//input[contains(@id,'chkreject')]");
        private By txtRejectionReason = By.XPath("//input[contains(@id,'_ddlrejectionreason')]");
        private By inputRejectionReason = By.XPath("//ul/li/a[text()='Incomplete']");
        private By txtRejectionNote = By.XPath("//div[@id='ctl00_hpNote']/input[contains(@id,'widget_approveandreject')]");
        private By inputRejectionNote = By.XPath("//ul/li/a[text()='Email To']");
        private By btnRejectionConfirm = By.XPath("//button[contains(@id,'btnsubmit')]");
        private By ChckApprove = By.XPath("//input[contains(@id,'chkapprove')]");
        private By btnApproveConfirm = By.XPath("//button[contains(@id,'_btnsubmit')]");
        private By frameTimesheet = By.XPath("//iframe[contains(@id,'timesheet__')]");
        private By frameTimesheetLegacyAttribution=By.XPath("//iframe[contains(@id,'legacy_timesheetattribution')]");
        private By btnRefresh = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input");
        private By lnkContinuetimesheet = By.XPath("//a[text()='Continue to timesheet']");
        private By iframetimesheet = By.XPath("//iframe[contains(@id,'timesheet_addnewtimesheet')]");
        private By lnkScheduleProcessingnow = By.XPath("//div[text()='Schedule Processing Now']");
        private By lnkAttributions = By.XPath("//span[@title='Left click to view Attributions']");
        private By ChckTimesheet = By.XPath("//td[1]/input[@class='check-one']");
        private By lnkScheduleInvoiceCreation = By.XPath("//div[text()='Schedule Invoice Record Creation']");
        private By lblInvoiceDate = By.XPath("//label[text()='Invoice Date: ']");
        private By txtInvoiceDate = By.XPath("//*[@data-bind='jqWidget: { datepicker: {} }, value: InvoiceDate']");
        private By lblProcessdate = By.XPath("//label[text()='Processing Date (leave empty to process immediately): ']");
        
        private By txtProcessdate = By.XPath("//input[@data-bind='jqWidget: { datepicker: {} }, value: ProcessingDate']");
        private By btnCloseInvoice = By.XPath("//button[@data-bind='click: Close']");
        private By btnSchedule = By.XPath("//button[@data-bind='click: Schedule, visible: !Done()']");
        private By btnSearchload = By.XPath("//input[@data-bind='click: Reload']");
        private By lnkWipRecord=By.XPath("//div[text()='Schedule WIP Record Creation']");
        private By lblTransactionDate = By.XPath("//label[text()='Transaction Date: ']");
        private By txtTransactionDate = By.XPath("//input[@data-bind='jqWidget: { datepicker: {} }, value: TransactionDate']");
        private By lnkCreatedInvoice = By.XPath("//a[@title='Click to open invoice.']");
        private By lblId = By.XPath("//div[@id='pagetitle']/h1");
        private By btnSubmitTimesheetSearch = By.XPath("//div[text()='Submit']");
        private By btnSubmitConfirmTimesheetSearch = By.XPath("//button[@data-bind='click: Submit']");
        private By btnApproveTimesheetSearch = By.XPath("//div[text()='Approve']");
        private By btnApproveConfirmTimesheetSearch = By.XPath("//button[text()='Approve']");
        private By chckTimesheetsearch = By.XPath("//div[@class='grid k-grid k-widget k-reorderable']//td[1]");
        private By SuccessApproveMessage = By.XPath("//div[@class='cooltipmessage bordered info']");
        private By btnCloseTimesheet = By.XPath("//button[text()='Close']");
        private By btnDeleteTimesheet = By.XPath("//div[text()='Delete']");
        private By btnConfirmDeleteTimesheet = By.XPath("//button[text()='Delete']");
        private By frameTimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");

        //Schedule Transaction Invoicing
        private By lnkScheduleTransactionInvoicing = By.XPath("//span[@title='Schedule Transaction Invoicing']");
        private By iframeinvoiceTransactions = By.XPath("//iframe[contains(@id,'invoice_invoicetransactions')]");
        //By.XPath("//iframe[contains(@id,'invoice_invoicetransactions') and @class = 'active']");

        private By ddlRecordType = By.XPath("//input[@value='Select a Record Type']");
        private By ddlbatch = By.XPath("//input[@value ='Select a Batch']");
        private By ddlTemplate = By.XPath("//input[@value ='Select a Template']");
        private By btnLoadTransactions = By.XPath("//input[@class='rbDecorated rbPrimary']");
        private By frameInvoice = By.XPath("//iframe[contains(@id,'invoice_invoicetransactions_')]");
        private By chkTransactions = By.XPath("//tr[@class='rgRow']/td[1]");
        private By btnCreateInvoices = By.XPath("//input[@value='Create Invoices for Selected']");
        private By lnkInvoiceMessage = By.XPath("//span[text()='Invoice(s) created: ']");
        private By ddlBillingDate = By.XPath("//input[@class='riTextBox riEnabled txt']");
        private By ddlInvoiceDate = By.XPath("//input[@name='ctl00$ctl00$cphMain$cphRightBar$txtInvoiceDate$dateInput']");
        //By.XPath("//input[@class='riTextBox riHover txt']");
        private By iframetimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");

        #endregion
        #region TimesheetSearch Filters
        private By txtFilters = By.XPath("//div[@class='more-filters-wrapper']/div[1]/a");
        private By txtInput = By.XPath("//div[contains(@class,'select2-drop add-filters select2-with-searchbox select2-drop-active')]/div/input");
        #endregion
        #region Match
        private By lnkTimesheetsearch = By.XPath("//div[@class='k-grid-content']/table/tbody/tr/td[2]/a");
        private By txtdraftPercentage = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[3]/div[6]/table/tbody/tr/td[9]//span");
        private By txtsubmitPercentage = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[3]/div[6]/table/tbody/tr/td[10]//span");
        private By txtApprovePercentage = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[3]/div[6]/table/tbody/tr/td[11]//span");
        private By txtRejectPercentage = By.XPath("//div[contains(@id,'_cooltipBridgeId')]/div[3]/div[6]/table/tbody/tr/td[11]//span");
        private By chckRejectTimesheet = By.XPath("//div[contains(@id,'widget_approveandreject_')]/table/tbody/tr/td[1]/table/tbody/tr[2]/td[4]/input");

        private By frametimesheetsearch = By.XPath("//iframe[contains(@id,'timesheet__')]");
        private By frameMatch=By.XPath("//iframe[contains(@id,'match__')]");

        #endregion
        public void TimeSheetProcess()
        {
            try
            {
                driver.SwitchToFrameByIndex(1);
                driver.ClickElement(ddlPayEndDate, "Pay EndDate");
                var options = driver.FindElements(By.XPath("//div[@id='ctl00_ctl00_cphMain_cphRightBar_ddlPeriodEndDate_DropDown']/div/ul/li"));
                int optsize = options.Count();
                Random num = new Random();
                int Select = num.Next(optsize);
                string selectopt = string.Format("//div[@id='ctl00_ctl00_cphMain_cphRightBar_ddlPeriodEndDate_DropDown']/div/ul/li[{0}]", Select.ToString());
                var payend = driver.FindElement(By.XPath(selectopt));
                payend.Click();
                driver.CheckElementDisplayed(ChkIncludeW2, "Include W2");
                driver.CheckElementDisplayed(ChKInclude1099, "Include 1099");
                driver.ClickElement(btnGenerateReport, "Generate Report");
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("TimeSheetProcess", "Failed at TimeSheetProcess", EngineSetup.GetScreenShotPath());
            }
        }
        public void AddhoursthroughTimesheet()
        {
            try
            {
                string xpath = "//table[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_ctl00']//td[3]//span";
                var opt = driver.FindElement(By.XPath(xpath));
                Actions act = new Actions(driver);
                act.ContextClick(opt).Build().Perform();
                driver.ClickElement(btnEdithours, "Edit Hours");
                driver.SendKeysToElementClearFirst(txtHours, "12", "Hours");
                driver.ClickElement(btnSave, "Save");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddHours", "Failed at Addhours", EngineSetup.GetScreenShotPath());
            }
        }
        public void SubmitTimesheet()
        {
            try
            {
                string xpath = this.listofSubmitted("Draft");
                var opt = driver.FindElement(By.XPath(xpath));
                opt.Click();
                driver.ClickElement(lnkSubmit, "Submit Timesheet");
                //driver.SwitchToDefaultFrame();
                //driver.SwitchToFrameByIndex(2);
                //driver.ClickElement(btnSubmit,"Submit");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SubmitProcess", "Failed to Submit TimeSheetProcess", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Approve Timesheet through Timesheet processing
        /// </summary>
        public void ApproveTimesheet()
        {
            try
            {
                string xpath = this.listofSubmitted("Submitted");
                var opt = driver.FindElement(By.XPath(xpath));
                opt.Click();
                driver.ClickElement(lnkApprove, "Approve Timesheet");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SubmitProcess", "Failed to Approve TimeSheetProcess", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Approve Hours through TimeSheet Record
        /// </summary>
        public void ApproveTimesheetRecord()
        {
            try
            {
                driver.WaitElementPresent(btnApprove);
                driver.ClickElement(btnApprove, "Approve Timesheet");
                driver.WaitElementPresent(btnApproveConfirm);
                driver.ClickElement(btnApproveConfirm, "Approve");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Approve Timesheet Record", "Failed at Approve TimeSheet Record", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Reject Hours through TimeSheet Record
        /// </summary>
        public void RejectTimesheetRecord(string Type)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnReject);
                driver.ClickElement(btnReject, "Reject Timesheet");
                driver.WaitElementPresent(txtRejectionReason);
                driver.ClickElement(txtRejectionReason, "Rejection Reason");
                driver.WaitElementPresent(inputRejectionReason);
                driver.ClickElement(inputRejectionReason, "Rejection Reason");
                driver.WaitElementPresent(txtRejectionNote);
                driver.ClickElement(txtRejectionNote, "Rejection Note");
                driver.WaitElementPresent(inputRejectionNote);
                driver.ClickElement(inputRejectionNote, "Select Rejection Note");
                driver.WaitElementPresent(btnRejectionConfirm);
                driver.ClickElement(btnRejectionConfirm, "Rejection Confirm");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Reject Timesheet Record", "Failed at Reject TimeSheet Record", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        ///Method for  Schedule Processing Now
        /// </summary>
        public void ScheduleProcessing()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);                
                driver.SwitchToFrameByLocator(iframetimesheet);
                driver.ClickElement(lnkContinuetimesheet, "Timesheet");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                driver.WaitElementPresent(lnkScheduleProcessingnow);
                driver.ClickElement(lnkScheduleProcessingnow, "Schedule Processing Now");
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                var attributionCount = driver.FindElement(By.XPath("//span[@id='TimesheetAttributionCount']"));
                if (attributionCount.GetAttribute("text") == "1")
                {
                    driver.ClickElement(lnkAttributions, "Attributions");
                }
                else
                {
                    driver.WaitElementPresent(btnRefresh);
                    driver.ClickElement(btnRefresh, "Refresh");
                    driver.ClickElement(lnkAttributions, "Attributions");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Schedule Processing Now", "Failed at Schedule Processing Now", EngineSetup.GetScreenShotPath());
            }
        }
        public void ScheduleInvoiceCreation()
        {
            string InvoiceDate = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameTimesheetLegacyAttribution);
                //driver.WaitElementPresent(ChckTimesheet);
                //driver.ClickElement(ChckTimesheet, "TimeSheet");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lnkScheduleInvoiceCreation, "Schedule Invoice Creation");
                driver.sleepTime(10000);
                driver.ClickElement(lnkScheduleInvoiceCreation,"Schedule Invoice Creation");
                driver.sleepTime(10000);
                driver.WaitForElement(lblInvoiceDate, TimeSpan.MaxValue);
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lblInvoiceDate, "Invoice Date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(txtInvoiceDate, "Invoice Date");
                driver.sleepTime(10000);
                driver.SendKeysToElementAndPressEnter(txtInvoiceDate, InvoiceDate, "Invoice Date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lblProcessdate, "Processing Date Label");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(txtProcessdate, "Process date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(btnCloseInvoice, "Close button");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(btnSchedule, "Schedule Button");
                driver.sleepTime(10000);
                driver.ClickElement(btnSchedule, "Schedule Invoice");
                driver.WaitElementPresent(btnCloseInvoice);
                driver.ClickElement(btnCloseInvoice, "Close");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                var lblInvoicestatus = driver.FindElement(By.XPath("//div[6]//td[18]/span"));
                driver.sleepTime(10000);
                lblInvoicestatus.GetAttribute("text");
                driver.sleepTime(10000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure(" Schedule Invoice Creation", "Failed at Schedule Invoice Creation", EngineSetup.GetScreenShotPath());
            }
        }
        public void ScheduleWIPRecordCreation()
        {
            string TransactionDate = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");
            try
            {
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lnkWipRecord, "WIP Record Creation");
                driver.sleepTime(10000);
                driver.ClickElement(lnkWipRecord, "WIP Record Creation");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lblTransactionDate, "Transaction Date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(txtTransactionDate, "Transaction Date");
                driver.sleepTime(10000);
                driver.ClickElement(txtTransactionDate, "Transaction Date");
                driver.sleepTime(10000);
                driver.SendKeysToElementAndPressEnter(txtTransactionDate, TransactionDate, "Transaction Date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lblProcessdate, "Processing Date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(txtProcessdate, "Process date");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(btnCloseInvoice, "Close");
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(btnSchedule, "Schedule");
                driver.sleepTime(10000);
                driver.ClickElement(btnSchedule, "schedule");
                driver.sleepTime(10000);
                driver.ClickElement(btnCloseInvoice,"Close");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnSearchload);
                driver.sleepTime(10000);
                driver.ClickElement(btnSearchload, "Search load");
                driver.sleepTime(10000);
                var lblInvoicestatus = driver.FindElement(By.XPath("//div[6]//td[18]/span"));
                lblInvoicestatus.GetAttribute("text");
                driver.sleepTime(10000);
                var lblWIPstatus = driver.FindElement(By.XPath("//div[6]//td[17]/span"));
                lblWIPstatus.GetAttribute("text");
                driver.sleepTime(10000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Schedule WIP Record Creation", "Failed at Schedule WIP Record Creation", EngineSetup.GetScreenShotPath());
            }
        }
        public void InvoiceCreated()        
        {
            try
            {
                driver.ClickElement(lnkCreatedInvoice, "Created Invoice");
                driver.VerifyWebElementPresent(lblId, "ID");
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Invoice Created", "Failed to Invoice Created", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Submit hours through Timesheet Record
        /// </summary>
        public void SubmitTimesheetSearch(string submitsuccess)
        {
            try
            {
                driver.WaitElementPresent(chckTimesheetsearch);
                driver.ClickElement(chckTimesheetsearch, "Timesheet Search");
                driver.WaitElementPresent(btnSubmitTimesheetSearch);
                driver.ClickElement(btnSubmitTimesheetSearch, "Submit Timesheet Search");
                driver.sleepTime(2000);
                driver.ClickElement(btnSubmitConfirmTimesheetSearch, "Submit Confirm Timesheet Search");
                driver.WaitElementPresent(SuccessApproveMessage);
                driver.AssertTextEqual(SuccessApproveMessage, submitsuccess);
                //driver.ClickElement(btnCloseTimesheet, "Close");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Submit Timesheet Search", "Failed to submit Timesheet Search", EngineSetup.GetScreenShotPath());
            }
        }        
        /// <summary>
        /// Method To Approve Timesheet by Search
        /// </summary>
        public void ApproveTimesheetSearch()
        {
            try
            {
                driver.ClickElement(chckTimesheetsearch, "Timesheet Search");
                driver.ClickElement(btnApproveTimesheetSearch, "Approve Timesheet Search");
                // driver.ClickElement(btnApproveConfirmTimesheetSearch, "Approve Confirm Timesheet Search");
                //driver.ClickElement(btnCloseTimesheet, "Close");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Approve Timesheet Search", "Failed at Approve Time Sheet Search", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Delete Timesheet Search
        /// </summary>
        public void DeleteTimesheetSearch()
        {
            try
            {
                driver.ClickElement(chckTimesheetsearch, "Timesheet Search");
                driver.ClickElement(btnDeleteTimesheet, "Delete Timesheet Search");
                driver.ClickElement(btnConfirmDeleteTimesheet, "Delete Confirm Timesheet Search");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Delete Timesheet Record", "Failed at Delete TimeSheet Record", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        ///method to Submit add hours 
        /// </summary>
        /// <param name="statusopt"></param>
        /// <retu rns></returns>
        public string listofSubmitted(string statusopt)
        {
            int i = 0;
            string xpath = string.Empty;
            try
            {
                var status = driver.FindElements(By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet']/div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_GridData']/table/tbody/tr/td[4]"));
                foreach (var option in status)
                {
                    i = i + 1;
                    if (option.Text.Contains(statusopt))
                    {
                        xpath = string.Format("//div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet']/div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_GridData']/table/tbody/tr[{0}]/td[1]/input", i.ToString());
                        return xpath;
                    }
                    else
                    {
                        AccountingPage accounting = new AccountingPage();
                        accounting.TimeSheetProcess();
                        driver.SwitchToDefaultFrame();
                    }
                }
                return xpath;
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SubmitProcess", "Failed at TimeSheet Process", EngineSetup.GetScreenShotPath());
            }
            return string.Empty;
        }
        public string listofDraft(string statusopt)
        {
            int i = 0;
            string xpath = string.Empty;
            try
            {
                var status = driver.FindElements(By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet']/div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_GridData']/table/tbody/tr/td[4]"));

                foreach (var option in status)
                {
                    i = i + 1;
                    if (option.Text.Contains(statusopt))
                    {
                        xpath = string.Format("//div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet']/div[@id='ctl00_ctl00_cphMain_cphMain_gridTimesheet_GridData']/table/tbody/tr[{0}]/td[1]/nobr/span/a", i.ToString());
                        return xpath;
                    }
                    else
                    {
                        AccountingPage accounting = new AccountingPage();
                        accounting.TimeSheetProcess();
                    }
                }
                return xpath;
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SubmitProcess", "Failed at TimeSheet Process", EngineSetup.GetScreenShotPath());
            }
            return string.Empty;
        }
        public void TimesheetSearch(string timesheetid)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameTimesheet);
                driver.SwitchToFrameByLocator(frameTimesheet);
                driver.sleepTime(5000);
                driver.WaitElementPresent(timeSheetID);
                driver.ClickElement(timeSheetID, "TimeSheet Filter");
                driver.SendKeysToElementAndPressEnter(txtTimesheetID,timesheetid, "Timesheet");
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Search");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SubmitProcess", "Failed at TimeSheet Search", EngineSetup.GetScreenShotPath());
            }
        }
        public void SearchMatch_VendorManager(string matchID)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameMatch);
                driver.SwitchToFrameByLocator(frameMatch);
                driver.sleepTime(5000);
                By byMatchVM = By.XPath("//div/label[text()='ID:']");
                driver.ClickElement(byMatchVM, "Match Filter");
                driver.sleepTime(2000);
                By txtmatchID = By.XPath("//div[@class='jquery-ui-v1-10-3 dropdown-filter-edit-popup group']/div/div/input");
                driver.SendKeysToElementAndPressEnter(txtmatchID, matchID, "Match");
                driver.ClickElement(btnSearch, "Search");
                driver.sleepTime(5000);
                By lnkMatchID = By.XPath(string.Format("//div/a[text()='{0}']",matchID));
                driver.WaitElementPresent(lnkMatchID);
                driver.ClickElement(lnkMatchID, "Click on Match Id");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Match in Vendor Manager", "Failed at Search Match in Vendor Manager login", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add Quick hours through Timesheetsearch
        /// </summary>
        public void AddHoursthroughTimesheetbysearch()
        {
            try
            {
                driver.sleepTime(10000);
                var lnkTimesheetsearch = driver.FindElement(By.XPath("//div[@class='k-grid-content']/table/tbody/tr/td[2]/a"));
                Actions act = new Actions(driver);
                act.ContextClick(lnkTimesheetsearch).Build().Perform();
                driver.WaitElementPresent(btnEdithours);
                driver.ClickElement(btnEdithours, "Edit Hours");
                driver.SendKeysToElementClearFirst(txtHours, "12", "Hours");
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Hours through Timesheet", "Failed to Add Hours Through TimeSheetsearch", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyTimesheetId(string timesheet)
        {
            try
            {
                string contactTitle = driver.GetElementText(lblId);
                int startIndex = contactTitle.IndexOf("(");
                string timesheetid = contactTitle.Substring(startIndex + 1, contactTitle.Length - startIndex - 2);
                driver.AssertTextMatching(timesheetid, timesheet);             
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Timesheet Id", "Failed to Verify Timesheet Id", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnScheduleTransactionInvoicing(string recordType,string batch,string billingDate)
        {
            string InvoiceDate = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                driver.WaitElementPresent(lnkScheduleTransactionInvoicing);
                driver.ClickElement(lnkScheduleTransactionInvoicing, "Schedule Transaction Invoicing");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(iframeinvoiceTransactions);
                driver.SwitchToFrameByLocator(iframeinvoiceTransactions);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlRecordType);
                driver.ClickElement(ddlRecordType, "Record Type");
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(ddlRecordType, recordType, "Record Type");
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlBillingDate);
                driver.SendKeysToElementWithJavascript(ddlBillingDate, billingDate, "Billing Date");
                driver.sleepTime(3000);
                driver.FindElement(ddlBillingDate).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(ddlbatch);
                driver.ClickElement(ddlbatch, "Batch");
                driver.sleepTime(5000);
                driver.SendKeysToElementAndPressEnter(ddlbatch, batch, "Batch");
                driver.ClickElement(ddlTemplate, "Template");
                driver.SendKeysToElementAndPressEnter(ddlTemplate, recordType, "Template");
                driver.WaitElementPresent(btnLoadTransactions);
                driver.ClickElement(btnLoadTransactions, "Load Transactions");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameInvoice);
                driver.SwitchToFrameByLocator(frameInvoice);
                driver.sleepTime(5000);
                //driver.WaitElementPresent(chkTransactions);
                //driver.ClickElement(chkTransactions, "Transactions");
                //driver.sleepTime(5000);
                //driver.FindElement(ddlInvoiceDate).Clear();
                //driver.FindElement(ddlInvoiceDate).SendKeys(InvoiceDate);
                //driver.FindElement(ddlInvoiceDate).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(ddlInvoiceDate);
                driver.SendKeysToElementClearFirst(ddlInvoiceDate, InvoiceDate, "Invoice date");
                driver.FindElement(ddlInvoiceDate).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.WaitElementPresent(btnCreateInvoices);
                driver.ClickElement(btnCreateInvoices, "Create Invoices");
                driver.sleepTime(10000);
             //   driver.VerifyWebElementPresent(lnkInvoiceMessage,"lnk Invoice Message");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Invoice creation", "Failed to create Invoice", EngineSetup.GetScreenShotPath());
            }
        }
        public void verifypercentageupdate(string percentage,string type)
        {
            try
            {
                driver.sleepTime(5000);
                if(type=="draft")
                {
                    //driver.VerifyTextValue(txtdraftPercentage, percentage);
                    if (driver.FindElement(txtdraftPercentage).Text.Contains(percentage))
                        TESTREPORT.LogSuccess("Percentage value", "Percentage value is 100.00 %");
                    else
                        TESTREPORT.LogFailure("Percentage value", "Percentage value is not 100.00 %");


                }
                if(type== "submit")
                { //driver.VerifyTextValue(txtsubmitPercentage, percentage);
                    if (driver.FindElement(txtsubmitPercentage).Text.Contains(percentage))
                        TESTREPORT.LogSuccess("Percentage value", "Percentage value is 100.00 %");
                    else
                        TESTREPORT.LogFailure("Percentage value", "Percentage value is not 100.00 %");
                }
                if (type == "Approved")
                {
                    //driver.VerifyTextValue(txtsubmitPercentage, percentage);
                    if (driver.FindElement(txtsubmitPercentage).Text.Contains(percentage))
                        TESTREPORT.LogSuccess("Percentage value", "Percentage value is 100.00 %");
                    else
                        TESTREPORT.LogFailure("Percentage value", "Percentage value is not 100.00 %");
                }
                if (type == "Reject")
                {
                   // driver.VerifyTextValue(txtRejectPercentage, percentage);
                    if (driver.FindElement(txtRejectPercentage).Text.Contains(percentage))
                        TESTREPORT.LogSuccess("Percentage value", "Percentage value is 100.00 %");
                    else
                        TESTREPORT.LogFailure("Percentage value", "Percentage value is not 100.00 %");
                }               
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Invoice creation", "Percentage not Updated", EngineSetup.GetScreenShotPath());
            }
        }

       
    }
}
