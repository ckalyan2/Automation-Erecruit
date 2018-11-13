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
using System.Configuration;
using System.Data;


namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class TimeSheet : AbstractTemplatePage
    {

        //Verify
        private By txtRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/span[1]/input[1]");
        private By lnkRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[3]/li[4]/ul/li/a[text()='Requirement Definitions']");
        // private By btnAddRequirement = By.XPath("//button[@title='Add a new Requirement']");
        private By frameSitemanagementRequirement = By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]");
        private By btnAddRequirementNew = By.XPath("//button[@title='Add a new Requirement']");

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
        private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage')]");
        private By frameDashboard = By.XPath("//iframe[contains(@id,'dashboard')]");

        #region Constants and Fileds
        /// <summary>
        /// Candidate Id
        /// </summary>
        public static string CandidateId = string.Empty;

        /// <summary>
        /// Position Id
        /// </summary>
        public static string PositionId = string.Empty;
        /// <summary>
        /// Contact Id
        /// </summary>
        public static string ContactId = string.Empty;
        /// <summary>
        /// Match Id
        /// </summary>
        public static string matchId = string.Empty;

        /// <summary>
        /// URL
        /// </summary>
        private static string webURL = ConfigurationManager.AppSettings["URL"];

        /// <summary>
        /// Account Status
        /// </summary>
        private By accountStatus = By.XPath("//div[@data-tipname='match/accountingapproval']/img");

        /// <summary>
        /// Approved Status
        /// </summary>
        private By approvedStatus = By.XPath("//h5[text()='Change Status To:']/./following-sibling::div[text()=' Approved']");

        /// <summary>
        /// Match Manage Frame
        /// </summary>
        private By matchManageFrame = By.XPath("//iframe[contains(@id,'match_manage')]");

        /// <summary>
        /// Time Sheet Count 
        /// </summary>
        private By timeSheetCount = By.XPath("//span[@id='TimesheetCount']");
        private By btnRequirement = By.XPath("//button[@id='btnAddNewRequirement']");
        private By ddnRequirement = By.XPath("//label[text()='Requirement']/../div/a/span");
        private By txtRequirement = By.XPath("//label[text()='Requirement']/../div[1]/div/div/input");
        private By btnAddRequirement = By.XPath("//button[text()='Add Requirement']");
        private By lnkReversalTimesheet = By.XPath("//a[text()='Continue to Reversal timesheet']");
        private By iframetimesheet = By.XPath("//iframe[contains(@id,'timesheet_addnewtimesheet')]");
        private By txtReversal = By.XPath("//span[contains(@id,'lblTotal') and contains(text(),'-')]");
        private By btnCloseReversal = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnCommonClose_input");
        private By iframetimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");
        private By txtStartTime = By.XPath("//td[1]//tr[@id='trStartEnd']//input[contains(@id,'_starttime')]");
        private By selectstartTimeHours = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[1]/table/tbody/tr[1]/td[1]");
        private By selectStartTimeMinutes = By.XPath("//div[@id='ui-timepicker-div']/ table/tbody/tr/td[2]/table/tbody/tr[1]/td[1]/a");
        private By txtEndTime = By.XPath("//td[1]//tr[@id='trStartEnd']//input[contains(@id,'_endtime')]");
        private By selectEndtimeHours = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/a");
        private By selectEndtimeMinutes = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[2]/table/tbody/tr[1]/td[1]/a");
        private By btnAdd = By.XPath("//div[contains(@id,'widget_day')]/div[2]//div[contains(@id,'_edit')]/div[2]//button[contains(@id,'_btnsaveadd')]");
        private By btnSubmit = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnSubmit_input");
        private By btnAddTimesheet = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//tr[1]/td[1]//button[contains(@id,'btnadd')]");
        //Create timesheet
        private By btnAddTime = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//td[1]//span[text()='Add Time']");
        private By btnStartTime = By.XPath("//tr[@id='trStartEnd']//input[contains(@id,'_starttime')]");
        private By btnEndTime = By.XPath("//tr[@id='trStartEnd']//input[contains(@id,'_endtime')]");
        private By btnStartHour = By.XPath("//table[@class='ui-timepicker']//a[text()='6']");
        private By btnEndHour = By.XPath("//table[@class='ui-timepicker']//a[text()='7']");
        private By lnkPositionMatch = By.XPath("//div[@class='section_inner']/div//img[@title='Position']/../span");
        private By lnkPositionStatus = By.Id("ctl00_hpStatus");
        private By btnEditPosition = By.XPath("//div[@data-tipname='position/status']");
        private By ddnStatus = By.XPath("//div[@id='ctl00_hpStatusEdit']/h5/following-sibling::input");
        private By statusClosed = By.XPath("//a[text()='Closed']");
        private By statusGold = By.XPath("//a[text()='Gold']");
        private By statusOnhold = By.XPath("//a[text()='On Hold']");
        private By statusBronze = By.XPath("//a[text()='Bronze']");
        private By btnSave = By.XPath("//span[@class='ui-button-text']");
        #endregion
        #region Object creation
        AddCandidatePage candidate = new AddCandidatePage();
        AddCompanyPage companyDetails = new AddCompanyPage();
        CreatePositionPage createPosition = new CreatePositionPage();
        AddPositionPage position = new AddPositionPage();
        CreateMatchPage createMatch = new CreateMatchPage();
        HomePage home = new HomePage();
        ClientProjectPage clientPage = new ClientProjectPage();
        #endregion

        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <returns>Creates Company</returns>
        public string CreateCompany()
        {
            string company = string.Empty;
            string companyName = "erecruit";

            try
            {
                //   company = companyDetails.AddCompany(string.Format("{0}", companyName));

                if (!string.IsNullOrEmpty(company))
                {
                    this.TESTREPORT.LogSuccess("CreateCompany", "Company has been created successfully : ", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("CreateCompany", "Error while creating company : ", EngineSetup.GetScreenShotPath());
            }

            return company;
        }

        /// <summary>
        /// CreateMatch
        /// </summary>
        /// <returns>Creates and returns Match id </returns>
        public string GenerateContractMatchId(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, int positionfolder, int statusId, string reqname, bool Addrequirement = false, bool Candidate = true, bool isAllow = false, bool timesheettemplate = false, bool status = false, bool candidateAlert = false, bool matchAlert = true)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                //Add requirement code
                if (Addrequirement)
                {
                    driver.sleepTime(5000);
                    driver.SwitchToDefaultFrame();
                    driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'company_manage')]"));
                    driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'company_manage')]"));
                    driver.sleepTime(5000);
                    driver.ScrollPage();
                    driver.ClickElement(btnRequirement, "Add requirement");
                    driver.ClickElement(ddnRequirement, "Add requirement");
                    driver.SendKeysToElement(txtRequirement, reqname, "Requirement Name");
                    driver.ClickElement(btnAddRequirement, "");
                }
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                candidate.AddContact(name);
                candidate.Addtitletocontact(title);
                candidate.AddEmailToContact(email);
                candidate.SaveContact();
                ContactId = AddCandidatePage.id;
                //driver.ScrollToPageBottom();
                //companyDetails.ManageLogin();
                //companyDetails.GiveAccess("password");
                position.ClickButtonAddPosition();
                PositionId = createPosition.CreateContractPosition(companyIdAndName, positionfolder);
                // driver.sleepTime(5000);
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                if (Candidate)
                {
                    candidate.UpdateCandidateStatus(statusId);
                }
                driver.ScrollToPageBottom();
                companyDetails.ManageLogin(true);
                companyDetails.GiveAccess("password");
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();//Get match id
                driver.SwitchToDefaultFrame();
                createMatch.MatchtoFullplacement(ContactId, date, isAllow, timesheettemplate, candidateAlert, matchAlert);
                driver.SwitchToDefaultFrame();
                if (status)
                {
                    CheckAccountingStatus();
                }
                //createMatch.CreateTimesheets(matchId);
                if (!string.IsNullOrEmpty(matchId))
                {
                    this.TESTREPORT.LogSuccess("GenerateContractMatchId", "Match has been created successfully : ");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("GenerateContractMatchId", "Error while creating match : ", EngineSetup.GetScreenShotPath());
            }

            return matchId;
        }
        /// <summary>
        /// Generate Perm Match
        /// </summary>
        /// <returns></returns>
        public string GeneratePremMatch(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, string reqname, int statusid, bool Addrequirement = false)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                candidate.AddContact(name, title, email);
                ContactId = AddCandidatePage.id;
                companyDetails.ManageLogin();
                companyDetails.GiveAccess("password");
                PositionId = createPosition.CreatePermPosition(companyIdAndName);
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusid);
                matchId = createMatch.CreatePermMatch(PositionId, CandidateId);
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();
                driver.SwitchToDefaultFrame();
                createMatch.CreateFullPlacementForPerm(ContactId, date);
                driver.SwitchToDefaultFrame();
                //CheckAccountingStatus();
                if (!string.IsNullOrEmpty(matchId))
                {
                    this.TESTREPORT.LogSuccess("GeneratePermMatchId", "Perm Match has been created successfully : ");
                }

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("GeneratePermMatchId", "Error while creating perm match : ", EngineSetup.GetScreenShotPath());
            }
            return matchId;
        }
        /// <summary>
        /// Verify rates inherited from the position
        /// </summary>
        public void RatesInheritedFromPosition(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, int statusid)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                driver.SwitchToDefaultFrame();
                candidate.AddContact(name, title, email);
                ContactId = AddCandidatePage.id;
                PositionId = createPosition.CreateContractPosition(companyIdAndName, foldergroup);
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusid);
                createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);


            }
            catch (Exception ex)
            {


            }

        }
        /// <summary>
        /// Verify % submited update in timpe sheet
        /// </summary>

        public string VerifyTimesheetUpdated(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, string reqname, int statusid)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                candidate.AddContact(name, title, email);
                ContactId = AddCandidatePage.id;
                PositionId = createPosition.CreatePermPosition(companyIdAndName);
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusid);
                matchId = createMatch.CreateMatchOnly(PositionId, CandidateId);
                //matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();
                driver.SwitchToDefaultFrame();
                createMatch.MatchtoFullplacement(ContactId, date);
                driver.SwitchToDefaultFrame();
                CheckAccountingStatus();

                if (!string.IsNullOrEmpty(matchId))
                {
                    this.TESTREPORT.LogSuccess("GeneratePermMatchId", "Perm Match has been created successfully : ");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Timesheet Updated", "Failed to Verify Timesheet Updated ", EngineSetup.GetScreenShotPath());
            }
            return matchId;

        }
        /// <summary>
        /// Add time to time sheet
        /// </summary>
        // private By btnStartTime = By.XPath("//tr[@id='trStartEnd'] //input[contains(@id,'_starttime')]");
        //private By btnEndTime = By.XPath("//tr[@id='trStartEnd'] //input[contains(@id,'_endtime')]");
        //private By btnStartHour = By.XPath("//table[@class='ui-timepicker']//a[text()='6']");
        //private By btnEndHour = By.XPath("//table[@class='ui-timepicker']//a[text()='7']");
        public void AddTime()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(iframetimesheetManage);
                driver.ClickElement(btnAddTime, "Button add time");
                driver.ClickElement(btnStartTime, "Click on Start Time");
                driver.ClickElement(btnStartHour, "Select Time");
                driver.ClickElement(btnEndTime, "End Time");
                driver.ClickElement(btnEndHour, "End Hour");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Time ", "Failed to Add Time  ", EngineSetup.GetScreenShotPath());
            }
        }

        public string AddTimeinTimesheet(bool MealPeriods = false)
        {
            int j = 6, k = 10;
            string totalHours = null;
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(iframetimesheetManage);
                driver.SwitchToFrameByLocator(iframetimesheetManage);
                var tdtimecolumns = driver.FindElements(By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']/tbody/tr/td"));
                for (int i = 0; i < tdtimecolumns.Count; i++)
                {
                    driver.sleepTime(20000);
                    var btnAddTime = tdtimecolumns[i].FindElements(By.XPath(".//span[text()='Add Time']"));
                    btnAddTime[0].Click();
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    //IWebElement element = wait.Until<IWebElement>((d) =>
                    //{
                    //    return d.FindElement(By.XPath(".//span[text()='Add Time']"));
                    //});
                    //element.Click();
                    driver.sleepTime(5000);
                    if (MealPeriods)
                    {
                        if (i == 0 || i == 1)
                        {
                            var btnStartTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_starttime')]"));
                            btnStartTime1[0].Click();
                            var btnStartHour1 = btnStartTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                            btnStartHour1.Click();
                            driver.sleepTime(1000);
                            btnStartTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                            driver.sleepTime(5000);

                            driver.WaitElementPresent(By.XPath(".//input[contains(@id,'_endtime')]"));
                            var btnEndTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_endtime')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_endtime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_endtime')]"));
                            btnEndTime1[0].Click();
                            var btnEndHour1 = btnEndTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                            btnEndHour1.Click();
                            driver.sleepTime(1000);
                            btnEndTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                            driver.sleepTime(5000);
                            //driver.SwitchTo().DefaultContent();
                            var btnAdd = tdtimecolumns[i].FindElements(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            btnAdd[0].Click();
                            driver.sleepTime(5000);
                            //WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                            //IWebElement element1 = wait1.Until<IWebElement>((d) =>
                            //{
                            //    return d.FindElement(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            //});
                            //element1.Click();
                        }
                        else
                        {
                            var btnStartTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_starttime')]"));
                            btnStartTime1[0].Click();
                            var btnStartHour1 = btnStartTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                            btnStartHour1.Click();
                            driver.sleepTime(1000);
                            btnStartTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                            driver.sleepTime(5000);

                            driver.WaitElementPresent(By.XPath(".//input[contains(@id,'_endtime')]"));
                            var btnEndTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_endtime')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_endtime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_endtime')]"));
                            btnEndTime1[0].Click();
                            var btnEndHour1 = btnEndTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k)));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k)));
                            btnEndHour1.Click();
                            driver.sleepTime(1000);
                            btnEndTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                            driver.sleepTime(5000);
                            //driver.SwitchTo().DefaultContent();

                            var btnAdd = tdtimecolumns[i].FindElements(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            ExpectedConditions.ElementIsVisible(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            ExpectedConditions.ElementToBeClickable(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                            btnAdd[0].Click();
                            driver.sleepTime(5000);
                        }
                    }
                    else
                    {
                        var btnStartTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_starttime')]"));
                        ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_starttime')]"));
                        ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_starttime')]"));
                        btnStartTime1[0].Click();
                        driver.sleepTime(1000);
                        var btnStartHour1 = btnStartTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                        ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                        ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j)));
                        btnStartHour1.Click();
                        driver.sleepTime(1000);
                        btnStartTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                        driver.sleepTime(5000);

                        driver.WaitElementPresent(By.XPath(".//input[contains(@id,'_endtime')]"));
                        var btnEndTime1 = tdtimecolumns[i].FindElements(By.XPath(".//input[contains(@id,'_endtime')]"));
                        ExpectedConditions.ElementIsVisible(By.XPath(".//input[contains(@id,'_endtime')]"));
                        ExpectedConditions.ElementToBeClickable(By.XPath(".//input[contains(@id,'_endtime')]"));
                        btnEndTime1[0].Click();
                        driver.sleepTime(1000);
                        var btnEndHour1 = btnEndTime1[0].FindElement(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k)));
                        ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k)));
                        ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k)));
                        btnEndHour1.Click();
                        driver.sleepTime(1000);
                        btnEndTime1[0].SendKeys(OpenQA.Selenium.Keys.Escape);
                        driver.sleepTime(3000);
                        //driver.SwitchTo().DefaultContent();
                        var btnNotTaken = tdtimecolumns[i].FindElements(By.XPath(".//button[contains(@id,'_btnBreakDeclined')]"));
                        ExpectedConditions.ElementIsVisible(By.XPath(".//button[contains(@id,'_btnBreakDeclined')]"));
                        ExpectedConditions.ElementToBeClickable(By.XPath(".//button[contains(@id,'_btnBreakDeclined')]"));
                        btnNotTaken[0].Click();
                        //By btnNotTaken = By.XPath("//button[contains(@id,'_btnBreakDeclined')]");
                        //driver.ClickElement(btnNotTaken, "Click Not Taken ");
                        var btnAdd = tdtimecolumns[i].FindElements(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                        ExpectedConditions.ElementIsVisible(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                        ExpectedConditions.ElementToBeClickable(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                        btnAdd[0].Click();
                    }
                    driver.sleepTime(20000);
                    //By btnAdd = By.XPath("//button[contains(@id,'btnsaveadd')]");
                    //driver.ClickElement(btnAdd, "Click Add");
                    //driver.SwitchTo().DefaultContent();
                    ////IsStale(tdtimecolumns[i].FindElements());
                    //var btnAdd = tdtimecolumns[i].FindElements(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                    //ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@id,'btnsaveadd')]"));
                    //ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@id,'btnsaveadd')]"));
                    //btnAdd[0].Click();
                    //WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    //IWebElement element1 = wait.Until<IWebElement>((d) =>
                    //{
                    //    return d.FindElement(By.XPath(".//button[contains(@id,'btnsaveadd')]"));
                    //});
                    //element1.Click();
                }
                By btnTotalHours = By.XPath("//div/span[@id='ctl00_lblTitle']");
                totalHours = driver.GetElementText(btnTotalHours);

            }
            catch (Exception ex)
            {
                //this.TESTREPORT.LogFailure("Add Time in Timesheet", "Failed to Add Time in Timesheet ", EngineSetup.GetScreenShotPath());
            }
            return totalHours;
        }

        public void IsStale(By by)
        {
            bool i = false;
            int count = 0;
            while (!i)
            {
                try
                {

                    var r = driver.FindElement(by).Displayed;
                    i = true;
                }

                catch (Exception e)
                {
                }
                if (count++ >= 10)
                    break;
                else
                    driver.sleepTime(1000);
            }
        }
        public void IsStale(IWebElement by)
        {
            bool i = false;
            int count = 0;
            while (!i)
            {
                try
                {
                    by.Click();
                    i = true;
                }

                catch (Exception e)
                {
                }
                if (count++ >= 10)
                    break;
                else
                    driver.sleepTime(1000);
            }
        }
        public void CheckAccountingStatus()
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(matchManageFrame);
                driver.SwitchToFrameByLocator(matchManageFrame);
                driver.sleepTime(5000);
                driver.WaitElementPresent(accountStatus);
                driver.ClickElement(accountStatus, "Account status");
                driver.sleepTime(10000);
                driver.WaitElementPresent(approvedStatus);
                driver.ClickElement(approvedStatus, "Approved status");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Accounting Status", "Failed at Accounting Status ", EngineSetup.GetScreenShotPath());
            }

        }

        public string RejectMatchId(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string Rejectedby, string rejectReason, string billRate, string payRate, int statusId)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                driver.SwitchToDefaultFrame();
                candidate.AddContact(name);
                candidate.Addtitletocontact(title);
                candidate.AddEmailToContact(email);
                candidate.SaveContact();
                ContactId = AddCandidatePage.id;
                driver.SwitchToDefaultFrame();
                position.ClickButtonAddPosition();
                PositionId = createPosition.CreateContractPosition(companyIdAndName, foldergroup);
                driver.SwitchToDefaultFrame();
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusId);
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                createMatch.RejectMatch(Rejectedby, rejectReason);


            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Reject Match", "Error while rejecting match : ", EngineSetup.GetScreenShotPath());
            }

            return matchId;
        }

        public void ContinueReversalTimesheet()
        {
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(iframetimesheet);
            driver.ClickElement(lnkReversalTimesheet, "Click On Reversal Timesheet link");
            driver.VerifyWebElementPresent(txtReversal, "Reversal data");
            driver.ClickElement(btnCloseReversal, "Close Reversal");
        }

        public void ContinuetoReadjustmentTimesheet()
        {
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(iframetimesheetManage);
            driver.ClickElement(btnAddTimesheet, "Add Time");
            driver.ClickElement(txtStartTime, "Start Time Input");
            driver.ClickElement(selectstartTimeHours, "Select Time");
            driver.ClickElement(selectStartTimeMinutes, "Select Time");
            driver.ClickElement(txtEndTime, "End time input");
            driver.ClickElement(selectEndtimeHours, "End Time");
            driver.ClickElement(selectStartTimeMinutes, "End Time");
            driver.ClickElementWithJavascript(btnAdd, "Addhours");
        }
        /// <summary>
        /// Mandatory Validation Checks in Advance Match Timeline with Missing some requirements
        /// </summary>
        /// <param name="req"></param>
        /// <param name="requirement"></param>
        /// <param name="type"></param>
        /// <param name="targetRecordType"></param>
        public void VerifyMandatoryValidationCheck(string req, string requirement, string type, string targetRecordType)
        {
            try
            {

                driver.SendKeysToElementClearFirst(txtRequirementDef, req, "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameSitemanagementRequirement);
                driver.ClickElement(btnAddRequirementNew, "Add Requirement");
                driver.SendKeysToElement(btnRequiremetName, requirement, "Requirement Name");
                driver.ClickDropdownAndSearchText(ddlType, TypeSearch, type, "Requirement Type");
                driver.ClickDropdownAndSearchText(ddlTargetRecordType, TargetRecordSearch, targetRecordType, "Target Record Type");
                driver.ClickElement(ddlIntegrationPartner, "Integration Partner");
                driver.AssertTextContains(IntegrationPartnerText, "HRNX");
                driver.SendKeysToLocator(txtSearchDropDown, "HRNX" + OpenQA.Selenium.Keys.Enter, "Integrating partner");
                driver.ClickElement(btnSaveRequirement, "Save");
                driver.sleepTime(20000);
            }
            catch (Exception ex)
            {

            }

        }
        public string CreateCompanyAndProceedMatch(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string payRate, string billRate, int statusid)
        {
            string companyIdAndName = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                driver.SwitchToDefaultFrame();
                candidate.AddContact(name, title, email);
                ContactId = AddCandidatePage.id;
                PositionId = createPosition.CreatePermPosition(companyIdAndName);
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusid);
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();

            }
            catch (Exception ex)
            {

            }
            return companyIdAndName;
        }

        public string GenerateMatch(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, int positionfolder, int statusId, string reqname, bool Addrequirement = false)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                driver.SwitchToDefaultFrame();
                candidate.AddContact(name);
                candidate.Addtitletocontact(title);
                candidate.AddEmailToContact(email);
                candidate.SaveContact();
                ContactId = AddCandidatePage.id;
                driver.SwitchToDefaultFrame();
                position.ClickButtonAddPosition();
                PositionId = createPosition.CreateContractPosition(companyIdAndName, positionfolder);
                driver.SwitchToDefaultFrame();
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusId);
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                int index = matchId.IndexOf("-");
                if (index > 0)
                    matchId = matchId.Substring(0, index);
                matchId = matchId.Trim();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Generate MatchId", "Error while creating match : ", EngineSetup.GetScreenShotPath());
            }
            return matchId;
        }

        public void NavigateToPositionFromMatch(string status, bool Match = false)
        {
            try
            {
                if (Match)
                {
                    driver.SwitchToDefaultFrame();
                    driver.WaitElementPresent(matchManageFrame);
                    driver.sleepTime(5000);
                    driver.SwitchToFrameByLocator(matchManageFrame);
                    driver.ScrollPage();
                    driver.ScrollPage();
                    driver.ScrollPage();
                    driver.WaitElementPresent(lnkPositionMatch);
                    driver.ClickElement(lnkPositionMatch, "Position");
                }
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.MouseHover(lnkPositionStatus, "");
                driver.ClickElementWithJavascript(btnEditPosition, "");
                driver.ClickElementWithJavascript(ddnStatus, "status dropdown");
                driver.sleepTime(20000);
                if (status == "bronze")
                {
                    driver.ClickElement(statusBronze, "Bronze Status");
                    driver.sleepTime(10000);
                }
                if (status == "Onhold")
                {
                    driver.ClickElement(statusOnhold, "Onhold Status");
                }
                if (status == "Closed")
                {
                    driver.ClickElement(statusClosed, "Closed Status");
                }
                if (status == "Gold")
                {
                    driver.ClickElement(statusGold, "Closed Status");
                }
                //a[text()='Closed']
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
            }
            catch (Exception E)
            {
                this.TESTREPORT.LogFailure("Navigate to Position page", "Unable to navigate position page : ", EngineSetup.GetScreenShotPath());
            }
        }

        //public string AddTimeinTimesheet()
        //{
        //    int j = 6, k = 10;
        //    string totalHours = null;
        //    try
        //    {
        //        driver.SwitchToDefaultFrame();
        //        driver.SwitchToFrameByLocator(iframetimesheetManage);
        //        for (int i = 1; i <= 5; i++)
        //        {
        //            By btnAddTime1 = By.XPath(string.Format("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//td[{0}]//span[text()='Add Time']", i));
        //            driver.ClickElement(btnAddTime1, "Button add time");
        //            driver.ClickElement(btnStartTime, "Click on Start Time");
        //            if (i == 1 || i == 2)
        //            {
        //            By btnStartHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j));
        //            By btnEndHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j));
        //            driver.ClickElement(btnStartHour1, "Select Time");
        //            driver.ClickElement(btnEndTime, "End Time");
        //            driver.ClickElement(btnEndHour1, "End Hour");
        //            }
        //            else
        //            {
        //            By btnStartHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j));
        //            By btnEndHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", k));
        //            driver.ClickElement(btnStartHour1, "Select Time");
        //            driver.ClickElement(btnEndTime, "End Time");
        //            driver.ClickElement(btnEndHour1, "End Hour");
        //            }
        //            By btnAdd = By.XPath("//button[contains(@id,'btnsaveadd')]");
        //            driver.ClickElement(btnAdd, "Click Add");
        //        }
        //        By btnTotalHours = By.XPath("//div/span[@id='ctl00_lblTitle']");
        //        totalHours = driver.GetElementText(btnTotalHours);
        //    }
        //    catch (Exception ex)
        //    {
        //    this.TESTREPORT.LogFailure("Add Time in Timesheet", "Failed to Add Time in Timesheet ", EngineSetup.GetScreenShotPath());
        //    }
        //    return totalHours;
        //}

        //public string AddinTimesheet()
        //{
        //    int j = 6, k = 10;
        //    driver.SwitchToDefaultFrame();
        //    driver.SwitchToFrameByLocator(iframetimesheetManage);
        //    IWebElement TimeCollection = driver.FindElement(By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//td//span[text()='Add Time'])"));
        //    List<IWebElement> rows = TimeCollection.FindElements(By.TagName("tr")).ToList();
        //    foreach (IWebElement cell in rows)
        //    {
        //        driver.ClickElement(btnStartTime, "Click on Start Time");
        //        By btnStartHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j));
        //        By btnEndHour1 = By.XPath(string.Format("//table[@class='ui-timepicker']//a[text()='{0}']", j));
        //        driver.ClickElement(btnStartHour1, "Select Time");
        //        driver.ClickElement(btnEndTime, "End Time");
        //        driver.ClickElement(btnEndHour1, "End Hour");
        //        By btnAdd = By.XPath("//button[contains(@id,'btnsaveadd')]");
        //        driver.ClickElement(btnAdd, "Click Add");
        //    }
        //By btnTotalHours = By.XPath("//div/span[@id='ctl00_lblTitle']");
        //string totalHours = driver.GetElementText(btnTotalHours);

        //    return totalHours;
        //}

        public string VerifyTimesheetinCandidateLogin()
        {
            string totalHours = null;
            try
            {
                By btnTotalHours = By.XPath("//div/span[@id='ctl00_lblTitle']");
                totalHours = driver.GetElementText(btnTotalHours);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Timesheet in Candidate Login", "Failed to verify Timesheet in Candidate Login ", EngineSetup.GetScreenShotPath());
            }
            return totalHours;
        }

        public void SubmitTimesheet_FullSite()
        {
            try
            {
                driver.WaitElementPresent(btnSubmit);
                driver.ClickElement(btnSubmit, "Submit Timesheet");
                By by = By.XPath("//button[contains(@id,'btnsubmit')]");
                driver.WaitElementPresent(by);
                driver.ClickElement(by, "Confirm Submit");
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameDashboard);
                driver.SwitchToFrameByLocator(frameDashboard);
                driver.sleepTime(5000);
                By chkPast = By.Id("ctl00_cphMain_RadDock7311_C_ctl00_chkShowAllTimesheets");
                driver.ClickElement(chkPast, "Check show Past and submitted timesheets");
                driver.sleepTime(10000);
                By lnkTimesheet = By.XPath("//*[@id='ctl00_cphMain_RadDock7311_C_ctl00_gridTimesheets_ctl00__0']/td[6]");
                driver.WaitElementPresent(lnkTimesheet);
                string submitted = driver.FindElement(lnkTimesheet).Text.ToString();
                driver.sleepTime(5000);
                if (submitted.Equals("Submitted"))
                    this.TESTREPORT.LogSuccess("Submitted Value", "Timesheet has been submitted successfully ");
                else
                    this.TESTREPORT.LogFailure("Submitted Value", "Failed to submit Timesheet");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Submit Timesheet for FullSite", "Failed to verify Submit Timesheet for FullSite ", EngineSetup.GetScreenShotPath());
            }
        }


        public void SubmitTimesheet()
        {
            try
            {
                driver.ClickElement(btnSubmit, "Submit Timesheet");
                driver.sleepTime(5000);
                By by = By.XPath("//button[contains(@id,'btnsubmit')]");
               // driver.WaitElementPresent(by);
                driver.ClickElement(by, "Confirm Submit");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Submit Timesheet", "Failed to verify Submit Timesheet ", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateMatchID(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string date, string payRate, string billRate, int positionfolder, int statusId, string reqname, bool Addrequirement = false, bool Candidate = true, bool isAllow = false, bool timesheettemplate = false)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                //Add requirement code
                if (Addrequirement)
                {
                    driver.SwitchToDefaultFrame();
                    driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'company_manage')]"));
                    driver.ScrollPage();
                    driver.ClickElement(btnRequirement, "Add requirement");
                    driver.ClickElement(ddnRequirement, "Add requirement");
                    driver.SendKeysToElement(txtRequirement, reqname, "Requirement Name");
                    driver.ClickElement(btnAddRequirement, "");
                }
                companyDetails.ClickonAccountingTab();
                companyDetails.AddContactFromCompany();
                candidate.AddContact(name);
                candidate.Addtitletocontact(title);
                candidate.AddEmailToContact(email);
                candidate.SaveContact();
                ContactId = AddCandidatePage.id;
                position.ClickButtonAddPosition();
                PositionId = createPosition.CreateContractPosition(companyIdAndName, positionfolder);
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                if (Candidate)
                {
                    candidate.UpdateCandidateStatus(statusId);
                }
                driver.ScrollToPageBottom();
                companyDetails.ManageLogin(true);
                companyDetails.GiveAccess("password");
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Match ID", "Error while creating match : ", EngineSetup.GetScreenShotPath());
            }
        }

       
        public string RejectMatchVM(string name, string city, string title, string email, int foldergroup, string postalcode, string url, string phoneNumber, string Rejectedby, string rejectReason, string billRate, string payRate, int statusId,string clientname)
        {
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            try
            {
                home.ClickOnLogoMenu();
                home.NavigateToAddnew();
                home.NavigateToAddCompany();
                companyIdAndName = companyDetails.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
                companyDetails.ClickonAccountingTab();
                driver.sleepTime(1000);
                clientPage.AddClientProject(clientname);
                driver.sleepTime(1000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'clientproject_manage')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'clientproject_manage')]"));
                 By by = By.XPath(string.Format("//div[contains(@id,'wrapper_widget_relatedlinks')]//span/a[contains(text(),'{0}')]",name));
                driver.ClickElement(by, "Click candidate");
                companyDetails.AddContactFromCompany();
                candidate.AddContact(name);
                candidate.Addtitletocontact(title);
                candidate.AddEmailToContact(email);
                candidate.SaveContact();
                ContactId = AddCandidatePage.id;
                driver.SwitchToDefaultFrame();
                position.ClickButtonAddPosition();
                PositionId = createPosition.CreateContractPosition(companyIdAndName, foldergroup);
                driver.SwitchToDefaultFrame();
                home.NavigateToAddCandidate();
                candidate.AddCandidatewithoutResume(name, foldergroup, email);
                CandidateId = AddCandidatePage.id;
                candidate.UpdateCandidateStatus(statusId);
                matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
                createMatch.RejectMatch(Rejectedby, rejectReason);


            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Reject Match", "Error while rejecting match : ", EngineSetup.GetScreenShotPath());
            }

            return matchId;
        }
        public void SubmittimesheetforReject()
        {
            try
            {
                driver.ClickElement(btnSubmit, "Submit Timesheet");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Submit Timesheet", "Failed to verify Submit Timesheet ", EngineSetup.GetScreenShotPath());
            }
        }
        }
}

