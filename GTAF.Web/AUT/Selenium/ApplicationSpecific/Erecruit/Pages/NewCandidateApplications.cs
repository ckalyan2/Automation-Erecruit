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
using OpenQA.Selenium.Interactions;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class NewCandidateApplications: AbstractTemplatePage
    {
        #region Constructors
        public NewCandidateApplications()
        {
        }

        public NewCandidateApplications(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository

        #region New Candidate Application

        private By frameCandidateApplication = By.XPath("//iframe[@src='..//Mvc/candidateapplication/new']");
        private By ddlCandidate = By.XPath("//span[text()='Choose candidate']");
        private By txtSearchChooseCandidate = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By ddlPosition = By.XPath("//span[text()='Choose position']");
        private By txtSearchChoosePosition = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
        private By txtApplicationNote = By.XPath(".//*[contains(text(),'Application Note')]//following-sibling::textarea");
        private By ddlApplicationNote = By.XPath("//span[text()='Choose candidate application source']");
        private By txtSearchApplicationNote = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnSave = By.XPath(".//*[contains(text(),'Save')]");
        private By tblCandidateName = By.XPath("//table[@class='k-selectable']");
        private By txtStartDate = By.Id("dp1513922842922");
        private By txtFromDate = By.Id("dp1514894341655");
        private By lblStartDate = By.XPath("//div/label[text()='Date Created:']");
        private By btnSearch = By.XPath("//input[@value='Search']");
        private By txtDateCreated = By.XPath("//div[@class='date-range-filter Display']/label[contains(text(),'Date Created:')]");
        private By frameManageCandidateApp=By.XPath("//iframe[contains(@id,'candidateapplication_manage')]");
        private By lnkNewMatch = By.XPath("//div[@id='actions_section']/div[2]/div[2]");
        private By lblCandidateTitle = By.XPath("//div[@id='pagetitle']/h1[contains(text(),'Candidate  Application - ')]");
        private By frameCandidateApp = By.XPath("//iframe[contains(@src,'..//Search/candidateapplication/')]");
        private By lnkMatch = By.XPath("//img[@src='../../Mvc/Content/Images/icons/newmatch.png']");

        #endregion

        #region CreateCandidateApplication

        public void CreateCandidateApplication(string candidateName,string position,string note,string source)
        {
            try
            {
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameCandidateApplication);
                driver.SwitchToFrameByLocator(frameCandidateApplication);
                driver.sleepTime(15000);
                driver.WaitElementPresent(ddlCandidate);
                driver.ClickDropdownAndSearchText(ddlCandidate, txtSearchChooseCandidate, candidateName, "Choose Candidate");
                driver.sleepTime(10000);
                //driver.ClickDropdownAndSearchText(ddlPosition, txtSearchChoosePosition, position, "Choose Position");
                driver.ClickElement(ddlPosition, "");
                driver.sleepTime(5000);
                driver.SendKeysToElement(txtSearchChoosePosition, position, "");
                driver.sleepTime(5000);
                driver.FindElement(txtSearchChoosePosition).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtApplicationNote);
                driver.ClickElement(txtApplicationNote, "ApplicationNote");
                driver.SendKeysToElement(txtApplicationNote, "TestData", "Application Note");
                driver.sleepTime(5000);
                driver.ClickDropdownAndSearchText(ddlApplicationNote, txtSearchApplicationNote, source, "Candidate Application Source");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(10000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("New Candidate Application", "Create Candidate Application", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyExistingCandidate(string candidateName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameCandidateApplication);
                driver.SwitchToFrameByLocator(frameCandidateApplication);
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddlCandidate);
                driver.ClickDropdownAndSearchText(ddlCandidate, txtSearchChooseCandidate, candidateName, "Choose Candidate");                
                var tableElement = this.driver.FindElement(tblCandidateName);
                var testCandidateApplication = tableElement.FindElement(By.XPath("//a[contains(text(),'" + candidateName + "')]"));
                Assert.IsNotNull(testCandidateApplication, "Candidate Application is not present");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Existing Candidate Application", " Faild to verify Existing Candidate Application" + ex.Message, EngineSetup.GetScreenShotPath());
            }


        }

        public void SearchCandidateApplication(string candidateID)
        {
            try
            {
                //string date = System.DateTime.Now.Date.ToString();
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameCandidateApp);
                driver.SwitchToFrameByLocator(frameCandidateApp);
                driver.sleepTime(10000);
                //driver.WaitElementPresent(lblStartDate);
                //driver.ClickElement(txtDateCreated, "Start Date");
                //driver.SendKeysToElement(txtFromDate, date, "Enter From Date");
                By ddlIDFilter = By.XPath("//div[@class='select-filter Display']/label[text()='Candidates:']");
                driver.ClickElementWithJavascript(ddlIDFilter, "Click on Candidates Filter");
                By txtFilter = By.XPath("//div[@id='s2id_autogen6']/ul/li/input");
                driver.SendKeysToElementAndPressEnter(txtFilter, candidateID, "Search First Name field");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnSearch);
                driver.ClickElement(btnSearch, "Click Search");
                driver.sleepTime(10000);
                
            }
           catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Search Candidate Application", " Failed to verify Search Candidate Application" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void AddNewQP()
        {
            try
            {
                By lnkNewQP = By.XPath("//a[text()='New QP']");
                //By.XPath(string.Format("//a[contains(text(),'{0}')]/../..//a[text()='New QP']", CandidateAppID));
                driver.ClickElement(lnkNewQP, "Click New QP Link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add New QP", " Failed to add new QP" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        

        public void AddNewMatch(string CandidateAppID)
        {
            try
            {
                //By lnkNewMatch = By.XPath(string.Format("//a[contains(text(),'{0}')]/../..//a[text()='New Match']", CandidateAppID));
                //driver.ClickElement(lnkNewMatch, "Click New Match Link");
                By btnNewMatch = By.XPath("//div[text()='New Match']");
                driver.WaitElementPresent(btnNewMatch);
                driver.ClickElement(btnNewMatch, "Click on New Match");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add New Match", " Failed to add New Match" + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickAddNewMatch(string CandidateAppID)
        {
            try
            { 
                //By by=By.XPath(string.Format("//a[contains(text(),'{0}')]", CandidateAppID));
                //driver.ClickElement(by, "Click App ID");
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameManageCandidateApp);
                driver.SwitchToFrameByLocator(frameManageCandidateApp);
                driver.sleepTime(5000);
                driver.WaitElementPresent(lnkNewMatch);
                driver.ClickElement(lnkNewMatch, "Click New Match link");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add New Match", " Faild to add new Match" + ex.Message, EngineSetup.GetScreenShotPath());
            }

        }

        public string GetCandidateID()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                string title = driver.FindElement(lblCandidateTitle).Text;
                int startIndex = title.IndexOf("(");
                return title.Substring(startIndex + 1, title.Length - startIndex - 2);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Get Candidate ID", " Failed to retrieve Candidate ID " + ex.Message, EngineSetup.GetScreenShotPath());
            }
            return null;


        }

        
        public void ClickOnCandidateAppQP()
        {
            try
            {
               
                By lnkNewQP = By.XPath("//a[text()='New QP']");
                driver.WaitElementPresent(lnkNewQP);
                driver.ClickElement(lnkNewQP, "Click New QP Link");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Candidate App QP", " Failed to Click On Candidate App QP " + ex.Message, EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnCandidateAppMatch()
        {
            try
            {
                driver.WaitElementPresent(frameManageCandidateApp);
                driver.SwitchToFrameByLocator(frameManageCandidateApp);
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkMatch);
                driver.ClickElement(lnkMatch, "");
                driver.sleepTime(5000);
            }
            catch(Exception E)
            {
                this.TESTREPORT.LogFailure("Click On Candidate App Match", " Failed to Click On Candidate App Match " + E.Message, EngineSetup.GetScreenShotPath());
            }
        }
        
          
        
        #endregion

        #endregion
    }
}
