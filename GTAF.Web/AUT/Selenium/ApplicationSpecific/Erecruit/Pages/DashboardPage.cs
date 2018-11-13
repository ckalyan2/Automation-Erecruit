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

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class DashboardPage : AbstractTemplatePage
    {
        #region Constructors
        public DashboardPage()
        {
        }

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        #region Dashboard
        private By ttlGoals = By.XPath(".//em[contains(., 'Goals')]");
        private By ttlModifyDashboard = By.XPath(".//*[@id='ctl00_cphMain_RadDock0_T']/em");
        private By ddnModifyDashboard = By.XPath("//div[@id='ctl00_cphMain_RadDock0_T']/ul/li/a[@title='Expand']/span");
        private By btnAddWidgetDropdown = By.XPath(".//*[@id='WIDGETID_ddlwidget']");
        private By ddnAddWidget = By.XPath("//input[@id='WIDGETID_ddlwidget']");
        private By ttlAccountingPayroll = By.XPath(".//em[contains(., 'Accounting/Payroll')]");
        private By btnAddWidget = By.XPath("//*[@id='ctl00_cphMain_RadDock0_C_ctl00_btnAdd_input']");
        private By btnWidghetZoneLeft = By.XPath("//input[@id='ctl00_cphMain_RadDock0_C_ctl00_rbZoneLeft' and @type='radio']");
        private By btnWidghetZoneRight = By.XPath("//*[@id='ctl00_cphMain_RadDock0_C_ctl00_rbZoneRight']");
        private By ttlCompaniesAndContractPlacements = By.XPath(".//em[contains(., 'Companies with Active Contract Placements')]");
        private By btnSubmit = By.XPath(".//button[contains(text(),'Submit')]");
        private By ttlClientProjectApproval = By.XPath(".//em[contains(., 'Client Projects Approval')]");
        //private By ttlAccounting = By.XPath(".//em[contains(., 'Accounting/Payroll')]");
        private By pgeDashboard = By.XPath(".//*[@id='ctl00_cphMain_tableZones']");
        private By columnWidth = By.XPath(".//*[@id='ctl00_cphMain_RadDock0_C_ctl00_rblColumnWidths_5']");
        private By btnApplyDistribution = By.XPath(".//*[@id='ctl00_cphMain_RadDock0_C_ctl00_btnApplyColumns_input']");
        private By lblPageTitle = By.XPath("//div[@id='pagetitle']/h1");
        private By frameDashboardCandidate = By.XPath("//iframe[contains(@id,'dashboard_candidate_designdashboard')]");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'dashboard')]");
        private By frameTimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");
        private By frameVendorDashboard = By.XPath("//iframe[contains(@id,'dashboard_vendor_designdashboard')]");
        private By btnClose = By.XPath("//a/span[@class='rdClose']");
            //By.XPath("//em[text()='Leaderboard']/../ul/li/a[@title='Close']");
        private By lblLeaderboard = By.XPath("//em[contains(text(),'Leaderboard')]");
        private By lblActiveMileStone = By.XPath("//em[contains(text(),'Active Milestones')]");        
        #endregion

        #region Candidate
        private By ttlJobActivity = By.XPath(".//em[contains(., 'Job Activity')]");
        private By ttlCredentialingRequest = By.XPath(".//em[contains(., 'Credentialing Requests')]");
        #endregion

        #region Vendor
        private By ttlActiveMilestones = By.XPath("..//em[contains(., 'Active Milestones')]");
        private By ttlActivePositions = By.XPath(".//em[contains(., 'Active Positions')]");
        private By ttlContactInformation = By.XPath(".//em[contains(., 'Contact Information')]");
        #endregion

        private By lnkTimesheet = By.XPath("//*[@id='ctl00_cphMain_RadDock5051_C_ctl00_gridTimesheets_ctl00__0']/td[2]/a");

        #endregion

        #region
        public void VerifyGoalsWidget()
        {
            try
            {
                driver.SwitchToFrameByIndex(0);
                driver.IsElementPresent(ttlGoals);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyGoalsWidget", "Goals Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyModifyDashboard()
        {
            try
            {
                driver.IsElementPresent(ttlModifyDashboard);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyModifyDashboard", "Modify Dashboard Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnModifyDashboard(bool vendor=false)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                if (vendor)
                {
                    driver.sleepTime(5000);
                    driver.SwitchToFrameByLocator(frameVendorDashboard);
                }
                else
                {
                    driver.sleepTime(5000);
                    driver.SwitchToFrameByLocator(frameDashboard);
                }
                driver.WaitElementPresent(ddnModifyDashboard);
                driver.ClickElement(ddnModifyDashboard, "Click on Modify Dashboard dropdown");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Modify Dashboard dropdown", "Modify Dashboard", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectOnWidget(int addWidgetIndexNumber)
        {
            try
            {
                driver.ClickElement(btnAddWidgetDropdown, "Click on Add Widget dropdown");
                //24 results are available, use up and down arrow keys to navigate.
                var element = driver.FindElements(By.XPath("//ul[@class='ui-autocomplete ui-menu ui-widget ui-widget-content ui-corner-all']"));
                    //XPath("//html/body/ul[@id='ui-id']"));
                var options = element.First().FindElements(By.TagName("li"));
                options[addWidgetIndexNumber].Click();
                driver.VerifyWebElementPresent(btnAddWidget, "Add Widget button");
                driver.ClickElementWithJavascript(btnAddWidget, "Click on Add Widget button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SelectOnWidget", "Select On Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAddWidgetButton()
        {
            try
            {                
                driver.WaitElementPresent(btnAddWidget);
                driver.sleepTime(5000);
                driver.ClickElementWithJavascript(btnAddWidget, "Click on Add Widget button");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Add Widget button", "Add Widget button", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyWidget()
        {
            try
            {
                driver.IsElementPresent(ttlAccountingPayroll);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Widget", "Verify Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectWidgetAndZoneForVendorManager()
        {
            try
            {
                driver.ClickElement(btnAddWidgetDropdown, "Click on Add Widget dropdown");
                var elemen1t = driver.FindElements(By.XPath("//html/body/ul[contains(@id,'ui-id')]"));
                var options = elemen1t.First().FindElements(By.TagName("li"));
                options[5].Click();
                driver.ClickElement(btnWidghetZoneLeft, "Select Widget Zone");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SelectWidgetAndZoneForVendorManager", "Select widget and Zone for Vendor Manager", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddWidget()
        {
            try
            {
                driver.IsElementPresent(ttlCompaniesAndContractPlacements);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Widget", "Verify Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnSubmit()
        {
            try
            {
                driver.WaitElementPresent(btnSubmit);
                driver.ClickElement(btnSubmit, "Click on Submit");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Submit", "Click on Submit", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectWidgetAndZoneForRecruiter()
        {
            try
            {
                driver.ClickElement(btnAddWidgetDropdown, "Click on Add Widget dropdown");
                var elemen1t = driver.FindElements(By.XPath("//html/body/ul[@id='ui-id-1']"));
                var options = elemen1t.First().FindElements(By.TagName("li"));
                options[0].Click();
                driver.ClickElement(btnWidghetZoneRight, "Select Widget Zone");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SelectWidgetAndZoneForRecruiter", "Select widget and Zone for Recruiter", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddedWidgetInRecruiter()
        {
            try
            {
                driver.sleepTime(2000);
                driver.VerifyWebElementPresent(ttlAccountingPayroll, " Accounting/Payroll");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Added Widget In Recruiter", "Verify Added Widget In Recruiter", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddWidgetsInCandidate()
        {
            try
            {
                driver.VerifyWebElementPresent(ttlJobActivity,"Job Activity");
                driver.VerifyWebElementPresent(ttlCredentialingRequest, "Credentialing Request");
              
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Added Widgets In Candidate", "Verify Added Widgets In Candidate", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAddWidgetsInVendor()
        {
            try
            {
                driver.IsElementPresent(ttlActiveMilestones);
                driver.IsElementPresent(ttlActivePositions);
                driver.IsElementPresent(ttlContactInformation);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Added Widgets In Vendor", "Verify Added Widgets In Vendor", EngineSetup.GetScreenShotPath());
            }
        }

        public void SelectZoneForVendor(string widgenetName)
        {
            try
            {
                driver.ClickElement(btnAddWidgetDropdown, "Click on Add Widget dropdown");
                //IList<IWebElement> elemen1t = driver.FindElements(By.XPath("//ul[contains(@id,'ui-id')]"));
                //var options = elemen1t.First().FindElements(By.XPath("//li/a[contains(@id,'ui-id')]"));
                //options[5].Click();
                By by = By.XPath("//span[@role='status' and contains(text(),'results are available, use up and down arrow keys to navigate.')]");
                driver.WaitForElement(by, TimeSpan.MaxValue);
                By WidgetList = By.XPath(string.Format("//ul[contains(@id,'ui-id')]/li/a[text()='{0}']", widgenetName));
                driver.ClickElement(WidgetList, "Select a Widget");
                driver.SendKeysToElement(ddnAddWidget, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(1000);
                By rbLeftZone = By.XPath("//input[@id='ctl00_cphMain_RadDock0_C_ctl00_rbZoneLeft']");
                driver.ClickElement(rbLeftZone, "Select Widget Zone");
                driver.ClickElement(btnAddWidget, "Click Add Widget");
               // driver.ClickElement(btnWidghetZoneRight, "Select Widget Zone");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("SelectcZone", "Select Zone", EngineSetup.GetScreenShotPath());
            }

        }

        public void ChangeColumnWidthDistribution(int number)
        {
            try
            {
                driver.sleepTime(5000);
                By columnWidth = By.XPath(string.Format("//*[@id='ctl00_cphMain_RadDock0_C_ctl00_rblColumnWidths_{0}']",number));
                //driver.VerifyWebElementPresent(columnWidth, "Column Width Distribution");
                driver.WaitElementPresent(columnWidth);
                driver.ClickElementWithJavascript(columnWidth, "Column Width Distribution");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ChangeColumnWidthDistribution", "Change Column Width Distribution", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnApplyDistributionButton()
        {
            try
            {
                driver.WaitElementPresent(btnApplyDistribution);
                driver.VerifyWebElementPresent(btnApplyDistribution, "Click on Apply Distribution");
                driver.ClickElementWithJavascript(btnApplyDistribution, "Click on Apply Distribution");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickOnApplyDistributionButton", "Click On Apply Distribution Button", EngineSetup.GetScreenShotPath());
            }

        }
                
        public void VerifyColumnWidthDistribution(int number)
        {
            try
            {
                By columnWidth = By.XPath(string.Format("//*[@id='ctl00_cphMain_RadDock0_C_ctl00_rblColumnWidths_{0}']", number));
                driver.VerifyWebElementPresent(columnWidth, "Column Width Distribution");
                string selected = driver.FindElement(columnWidth).GetAttribute("checked");
                if (selected == "true")
                    this.TESTREPORT.LogSuccess("ChangeColumnWidthDistribution", "Column Width Distribution is successfully changed");
                else
                    this.TESTREPORT.LogFailure("ChangeColumnWidthDistribution", "Column Width Distribution is not changed");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ChangeColumnWidthDistribution", "Change Column Width Distribution", EngineSetup.GetScreenShotPath());
            }

        }

        public void VerifyPageTitle(string pageTitleInput)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                var pageTitle = driver.GetElementText(lblPageTitle);
                driver.AssertTextMatching(pageTitleInput, pageTitle);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Page title", "Failed to Verify Page title", EngineSetup.GetScreenShotPath());
            }

        }

        public void AddWidget(string widgenetName)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnAddWidget);
                driver.ClickElement(ddnAddWidget, "Select Widget list");
                By by = By.XPath("//span[@role='status' and contains(text(),'results are available, use up and down arrow keys to navigate.')]");
                driver.WaitElementPresent(by);
                By WidgetList = By.XPath(string.Format("//ul[contains(@id,'ui-id')]/li/a[text()='{0}']", widgenetName));
                driver.WaitElementPresent(WidgetList);
                driver.ClickElement(WidgetList, "Select a Widget");
                driver.SendKeysToElement(ddnAddWidget, OpenQA.Selenium.Keys.Tab,"");
                driver.sleepTime(1000);
                By rbLeftZone = By.XPath("//input[@id='ctl00_cphMain_RadDock0_C_ctl00_rbZoneLeft']");
                driver.WaitElementPresent(rbLeftZone);
                driver.ClickElement(rbLeftZone, "Select Widget Zone");
                driver.WaitElementPresent(btnAddWidget);
                driver.ClickElement(btnAddWidget, "Click Add Widget");
                driver.sleepTime(10000);              
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Widget", "Failed to Add Widget", EngineSetup.GetScreenShotPath());
            }

        }

        public void CloseWidgets()
        {
            try
            {
                driver.WaitElementPresent(btnClose);
                driver.ClickElement(btnClose, "Close the Widget");
                By btnSaveChanges = By.XPath("//input[@id='ctl00_cphMain_btnSave_input']");
                driver.ClickElement(btnSaveChanges, "Click Save Changes");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Widget", "Failed to Add Widget", EngineSetup.GetScreenShotPath());
            }
        }


        public void VerifyAddWidgetInDashBoard(string widgetName)
        {
            try
            {
                AddWidget(widgetName);
                By label = By.XPath(string.Format("//em[contains(text(),'{0}')]", widgetName));
                driver.WaitElementPresent(label);
                if (driver.IsElementPresent(label))
                {
                    TESTREPORT.LogSuccess("Verify Widget Label", string.Format("Able to view newly Added Widget in the Dashboard {0}",widgetName));
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Widget Label", "Failed to view newly Added Widget in the Dashboard");
                }
            }
            catch(Exception ex)
            {
                TESTREPORT.LogFailure("Verify Add Widget In VMS DashBoard", "Failed to Add Widget in VMS DashBoard ", EngineSetup.GetScreenShotPath());
            }

        }

        public void SelectTimesheetinTimesheetWidget(string matchId)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameDashboard);
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.sleepTime(5000);
                By lnkTimesheet = By.XPath("//*[@id='ctl00_cphMain_RadDock7311_C_ctl00_gridTimesheets_ctl00__0']/td[2]/a");
                driver.ClickElement(lnkTimesheet, "Click on Timesheet");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameTimesheetManage);
                driver.SwitchToFrameByLocator(frameTimesheetManage);

            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Select Timesheet in Timesheet Widget", "Failed to Select Timesheet in Timesheet Widget ", EngineSetup.GetScreenShotPath());
            }
        }      
        #endregion
    }
}
