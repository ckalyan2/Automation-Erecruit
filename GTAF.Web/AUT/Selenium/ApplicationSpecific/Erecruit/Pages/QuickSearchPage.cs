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
using System;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
   public class QuickSearchPage : AbstractTemplatePage
    {
        HomePage home = new HomePage();
        AddCandidatePage candidate = new AddCandidatePage();

        #region Constructors
        public QuickSearchPage()
        {
        }

        public QuickSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository

        private By txtQuickSearchBox = By.Id("ctl00_txtQuickSearch");
        private By lblPageTitle = By.XPath("//div[@id='pagetitle']/h1");
        private By msgNoResults = By.XPath(".//*[@id='ctl00_ctl00_cphMain_cphMain_gridResult_ctl00']/tbody/tr/td[2]");
        private By iFrameQuickSearch = By.XPath(".//iframe[contains(@id, 'general_quicksearchresults')]");
        #endregion

        #region Public Methods
        public void EnterSearchName(string quickSearchName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(txtQuickSearchBox);
                driver.SendKeysToElementAndPressEnter(txtQuickSearchBox, quickSearchName, "Enter Search Name");
                driver.sleepTime(2000);
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("EnterSearchName", "Failed to Enter Search Name", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifySearchPageTitle()
        {
            try
            {
                driver.VerifyWebElementPresent(lblPageTitle,"Page Title");
            }
           catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("VerifySearchPageTitle", "Failed to Verify Search Page Title", EngineSetup.GetScreenShotPath());
            }
        }


        public void VerifyNoResultsMessage(string message)
        {
            try
            {
                driver.SwitchToFrameByLocator(iFrameQuickSearch);
                var noResultsMessage = driver.GetElementText(msgNoResults).Trim(); 
                Assert.AreEqual(message, noResultsMessage);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyNoResultsMessage", "Failed to Verify No Results Message", EngineSetup.GetScreenShotPath());
            }

        }

        #endregion
    }
}
