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
    public class ReportsPage : AbstractTemplatePage
    {
        HomePage home = new HomePage();

        #region Constructors
        public ReportsPage()
        {
        }

        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        #region Funnel Reports
        private By lnkReports = By.XPath(".//span[text()='Reports']");
        private By lblFunnelReports = By.XPath(".//div[@class='dropdown_section ']/h3[contains(text(),'The Funnel')]");
        private By lnkCandidates = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Candidates']");
        private By lnkContacts = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Contacts']");
        private By lnkPositions = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Positions']");
        private By lnkSeeds = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Seeds']");
        private By lnkOpportunities = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Opportunities']");
        private By lnkMatches = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Matches']");
        private By lblPageTitle = By.XPath("//div[@id='pagetitle']/h1");
        #endregion
        #region Accounitng Reports
        private By lblAccountingReports = By.XPath(".//div[@class='dropdown_section ']/h3[contains(text(),'Accounting')]");
        private By lnkBatchRegister = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Batch Register']");
        private By lnkCandidateAdditions = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Candidate Additions']");
        private By lnkCandidateChanges = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Candidate Changes']");
        private By lnkCashReceipts = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Cash Receipts']");
        private By lnkGPExportLog = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='GP Export Log']");
        private By lnkInvoiceSummary = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Invoice Summary']");
        private By lnkTransactionCredit = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Transaction Credit']");
        private By lnkWorkersComp = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Workers Comp']");
        #endregion
        #region Other Reports
        private By lblOtherReports = By.XPath(".//div[@class='dropdown_section ']/h3[contains(text(),'Other Reports')]");
        private By lnkAccountsReceivableAnalysis = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Accounts Receivable Analysis ']");
        private By lnkGPAccountsReceivableAnalysis = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='GP Accounts Receivable Analysis ']");
        private By lnkActiveContractNumberTrend = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Active Contract Number Trend ']");
        private By lnkActiveContractPlacements = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Active Contract Placements ']");
        private By lnkActivityAnalysis = By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='Activity Analysis ']");
        private By FrameAccountsReceivableAnalysis = By.XPath("//iframe[contains(@id, 'report_aranalysis')]");
        private By FrameGPAccountsReceivableAnalysis = By.XPath("//iframe[contains(@id, 'report_argpanalysis')]");
        private By FrameActiveContractNumberTrend = By.XPath("//iframe[contains(@id, 'report_activecontractnumbertrend')]");
        private By FrameActiveContractPlacements = By.XPath("//iframe[contains(@id, 'report_activecontractplacements')]");
        private By FrameActivityAnalysis = By.XPath("//iframe[contains(@id, 'report_activityanalysis')]");
        #endregion
        #region Generate Report
        public By lnkGenerateReport = By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphRightBar_btnGenerateReport']");
        private By ddlSelectGroupBy = By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphRightBar_ddlGroupBy_Input']");

        #endregion
        #region Dynamic Reports
        private By lblDynamicReports = By.XPath(".//div[@class='dropdown_section ']/h3[contains(text(),'Dynamic Reports')]");
        private By lnkForBrian = By.XPath("//span[text()='BRAIN']");
            //By.XPath(".//div[@class='dropdown_section ']/ul/li/span[text()='For Brian']");
        private By iFrameDynamicReports = By.XPath(".//iframe[contains(@id, 'report_dynamicreport')]");
        #endregion
        #region Filter
        private By txtFilter = By.XPath(".//div[@class='filter']/input");
        private By txtFilterNotExist = By.XPath(".//li[@class='reports maintain_hover']/div/ul");
        #endregion

        private By btnRefresh = By.XPath("//input[@value='Refresh Dashboard']");
        #endregion


        #region Public Methods
        public void NavigateToReportsLink()
        {
            try
            {
                driver.MouseHover(lnkReports, "Reports link");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("NavigateToReports", "Failed to navigate to Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyFunnelReportsHeader()
        {
            try
            {
                driver.IsElementPresent(lblFunnelReports);
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyFunnelReportsHeader", "Failed to Verify Funnel Reports Header:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnFunnelCandidatesLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                VerifyFunnelReportsHeader();
                driver.ClickElement(lnkCandidates, "Candidates Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidates Funnel Reports", "Failed to Candidates Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnFunnelContactsLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkContacts, "Contacts Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Contacts Funnel Reports", "Failed to Contacts Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnFunnelPositionsLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkPositions, "Positions Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Positions Funnel Reports", "Failed to Positions Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnFunnelSeedsLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkSeeds, "Seeds Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Seeds Funnel Reports", "Failed to Seeds Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnFunnelOpportunitiesLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkOpportunities, "Opportunities Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Opportunities Funnel Reports", "Failed to Opportunities Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void ClickOnFunnelMatchesLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkMatches, "Matches Funnel Reports");
                driver.sleepTime(15000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Matches Funnel Reports", "Failed to Matches Funnel Reports:", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyReportsTitle(string pageTitleInput)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(15000);
                driver.WaitElementPresent(lblPageTitle);
                var pageTitle = driver.GetElementText(lblPageTitle);
                driver.sleepTime(5000);
               driver.AssertTextMatching(pageTitleInput, pageTitle);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Reports title", "Failed to Verify Reports Title", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyAccountingReportsHeader()
        {
            try
            {
                driver.VerifyWebElementPresent(lblAccountingReports,"Accounting Reports");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyAccountingReportsHeader", "Failed to Verify Accounting Reports Header:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccountingBatchRegisterLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                VerifyAccountingReportsHeader();
                driver.ClickElement(lnkBatchRegister, "Batch Register Accounting Reports");
                driver.sleepTime(20000);


            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Batch Register Accounting Reports", "Failed to Batch Register Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingCandidateAdditionsLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkCandidateAdditions, "Candidate Additions Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Additions Accounting Reports", "Failed to Candidate Additions Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingCandidateChangesLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkCandidateChanges, "Candidate Changes Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Candidate Changes Accounting Reports", "Failed to Candidate Changes Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingCashReceiptsLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkCashReceipts, "Cash Receipts Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Cash Receipts Accounting Reports", "Failed to Cash Receipts Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingGPExportLogLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkGPExportLog, "GP Export Log Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("GP Export Log Accounting Reports", "Failed to GP Export Log Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingInvoiceSummaryLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkInvoiceSummary, "Invoice Summary Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Invoice Summary Accounting Reports", "Failed to Invoice Summary Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingTransactionCreditLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkTransactionCredit, "Transaction Credit Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Transaction Credit Accounting Reports", "Failed to Transaction Credit Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccoutingWorkersCompLink()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.ClickElement(lnkWorkersComp, "Workers Comp Accounting Reports");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Workers Comp Accounting Reports", "Failed to Workers Comp Accounting Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyOtherReportsHeader()
        {
            try
            {
                driver.VerifyWebElementPresent(lblOtherReports,"OtherReports");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyOtherReportsHeader", "Failed to Verify Other Reports Header:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAccountsReceivableAnalysis()
         {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                VerifyOtherReportsHeader();
                //driver.sleepTime(15000);
                driver.WaitElementPresent(lnkAccountsReceivableAnalysis);
                driver.ClickElement(lnkAccountsReceivableAnalysis, "Accounts Receivable Analysis Reports");
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameAccountsReceivableAnalysis);
                driver.SwitchToFrameByLocator(FrameAccountsReceivableAnalysis);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlSelectGroupBy);
                driver.ClickElement(ddlSelectGroupBy, "Select Group by");
                driver.sleepTime(10000);
                IList<IWebElement> GroupByElement = driver.FindElements(By.XPath("//div[@id='ctl00_ctl00_cphMain_cphRightBar_ddlGroupBy_DropDown']//ul"));
                var TypeOptions = GroupByElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                TypeOptions[1].Click();
                driver.sleepTime(10000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Accounts Receivable Analysis Reports", "Failed to Accounts Receivable Analysis Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnGPAccountsReceivableAnalysis()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                //driver.sleepTime(10000);
                driver.WaitElementPresent(lnkGPAccountsReceivableAnalysis);
                driver.ClickElement(lnkGPAccountsReceivableAnalysis, "GP Accounts Receivable Analysis Reports");
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(FrameGPAccountsReceivableAnalysis);
                driver.SwitchToFrameByLocator(FrameGPAccountsReceivableAnalysis);
                driver.WaitElementPresent(ddlSelectGroupBy);
                driver.ClickElement(ddlSelectGroupBy, "Select Group by");
                IList<IWebElement> GroupByElement = driver.FindElements(By.XPath("//div[@id='ctl00_ctl00_cphMain_cphRightBar_ddlGroupBy_DropDown']//ul"));
                var TypeOptions = GroupByElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(2000);
                TypeOptions[1].Click();
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("GP Accounts Receivable Analysis Reports", "Failed to GP Accounts Receivable Analysis Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnActiveContractNumberTrend()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                //driver.sleepTime(10000);
                driver.WaitElementPresent(lnkActiveContractNumberTrend);
                driver.ClickElement(lnkActiveContractNumberTrend, "Active Contract Number Trend Reports");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameActiveContractNumberTrend);
                driver.SwitchToFrameByLocator(FrameActiveContractNumberTrend);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Active Contract Number Trend Reports", "Failed to Active Contract Number Trend Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnActiveContractPlacements()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                driver.WaitElementPresent(lnkActiveContractPlacements);
                driver.ClickElement(lnkActiveContractPlacements, "Active Contract Placements Reports");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameActiveContractPlacements);
                driver.SwitchToFrameByLocator(FrameActiveContractPlacements);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Active Contract Placements Reports", "Failed to Active Contract Placements Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnActivityAnalysis()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                //driver.sleepTime(10000);
                driver.WaitElementPresent(lnkActivityAnalysis);
                driver.ClickElement(lnkActivityAnalysis, "Activity Analysis Reports");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameActivityAnalysis);
                driver.SwitchToFrameByLocator(FrameActivityAnalysis);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Activity Analysis Reports", "Failed to Activity Analysis Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnGenerateReport()
        {
            try
            {
                //driver.sleepTime(5000);
                driver.WaitElementPresent(lnkGenerateReport);
                driver.ClickElement(lnkGenerateReport, "Generate Report");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Generate Report", "Failed to Click on Generate Report:", EngineSetup.GetScreenShotPath());
            }
        }

        public void SwitchToDynamicReportsFrame()
        {
            try
            {
                driver.SwitchToFrameByLocator(iFrameDynamicReports);
            }
             catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SwitchToDynamicReportsFrame", "Failed to Switch To Dynamic Reports iFrame:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyDynamicReportsHeader()
        {
            try
            {
                driver.sleepTime(10000);
                driver.VerifyWebElementPresent(lblDynamicReports,"Dynamic Reports");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyDynamicReportsHeader", "Failed to Verify Dynamic Reports Header:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnForBrain()
        {
            try
            {
                home.ClickOnLogoMenu();
                NavigateToReportsLink();
                VerifyDynamicReportsHeader();
                driver.ClickElement(lnkForBrian, "Click On For Brain Reports");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("For Brain Reports", "Failed to Click On For Brain Reports:", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectGroupByValue(string groupByValue)
        {
            try
            {
                driver.ClickElement(ddlSelectGroupBy, "Click on Select Group By dropdown");
                driver.SelectDropdownValue(".//*[@id='ctl00_ctl00_cphMain_cphRightBar_ddlGroupBy_DropDown']/div/ul/li", groupByValue);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SelectGroupByValue", "Failed to Select Group By Value:", EngineSetup.GetScreenShotPath());
            }
        }

        public void EnterFiterText(string filterText)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtFilter, filterText, "Enter Filter text");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("EnterFiterText", "Failed to Enter Fiter Text:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyFilterText()
        {
            try
            {
                driver.IsElementPresent(lnkCandidates);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyFilterText", "Failed to Verify Fiter Text:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyFilterNotExist()
        {
            try
            {
                driver.CheckElementDoesnotExists(lnkCandidates, "Filter text not exist");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyFilterNotExist", "Failed to Verify Filter Not Exist:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickOnRefresh()
        {
            driver.SwitchToFrameById("dashboard");
            driver.WaitElementPresent(btnRefresh);
            driver.ClickElement(btnRefresh, "Refresh");
        }
         #endregion

        }
}

