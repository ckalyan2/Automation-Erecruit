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
    public class SeedPage : AbstractTemplatePage
    {
        Utility utility = new Utility();
        #region Constructors
        public SeedPage()
        {
        }
        public SeedPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        private By frameSeedNew = By.XPath("//iframe[contains(@id,'seed_new')]");
        private By frameSeedManage = By.XPath("//iframe[contains(@id,'seed_manage')]");
        private By txtFirstName = By.XPath("//input[@id='ctl00_cphMain_ucAddress_txtFName']");
        private By txtLastName = By.XPath("//input[@id='ctl00_cphMain_ucAddress_txtLName']");
        private By ddnCreatedThrough = By.XPath("//input[@id='ctl00_cphMain_ddlSeedType_Input']");
        private By ddlCompany = By.XPath("//input[@id='ctl00_cphMain_ddlCompany_Input']");
        private By headerTitle = By.XPath("//*[@id='pagetitle']/h1[contains(text(),'Seed')]");
        private By btnSave=By.Id("ctl00_cphMain_btnSave_input");
        private By ddlCommunicationType = By.XPath("//input[@id='ctl00_cphMain_ucCommunicationMethods_ddlTypeNew_Input']");
        private By txtCommValue = By.Id("ctl00_cphMain_ucCommunicationMethods_txtValueNew");
        private By txtcommNote = By.Id("ctl00_cphMain_ucCommunicationMethods_txtNoteNew");
        private By btnCommAdd = By.XPath("//input[@id='ctl00_cphMain_ucCommunicationMethods_btnAdd' and @title='Add']");

        #endregion

        #region Public Methods
        public string AddNewSeed(string firstName,string lName,string createdBy,string mainPhone,string communicationValue,string communicationNote)
        {
            string option = string.Empty;
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSeedNew);
                driver.SwitchToFrameByLocator(frameSeedNew);
                driver.sleepTime(10000);
                driver.WaitElementPresent(ddlCommunicationType);
                driver.ClickElement(ddlCommunicationType, "Communication Type Drop down");
                By txtCommunicationType = By.XPath(string.Format("//*[@id='ctl00_cphMain_ucCommunicationMethods_ddlTypeNew_DropDown']/div/ul/li[text()='{0}']", mainPhone));
                driver.WaitElementPresent(txtCommunicationType);
                driver.ClickElement(txtCommunicationType, "Select a Communication type");
                driver.SendKeysToElement(txtCommValue, communicationValue, "Enter Communication Value");
                driver.WaitElementPresent(txtFirstName);
                driver.SendKeysToElement(txtFirstName, firstName, "Enter First Name");
                driver.WaitElementPresent(txtLastName);
                driver.SendKeysToElement(txtLastName, lName, "Enter Last Name");
                driver.WaitElementPresent(ddnCreatedThrough);
                driver.ClickElement(ddnCreatedThrough, "Created Through");
                driver.sleepTime(7000);
                IList<IWebElement> lstCreatedThrough = driver.FindElements(By.XPath("//div[@id='ctl00_cphMain_ddlSeedType_DropDown']/div[1]/ul"));
                //*[@id="ctl00_cphMain_ddlSeedType_DropDown"]/div[1]/ul/li[1]
                var createdThroughOptions = lstCreatedThrough.First().FindElements(By.TagName("li"));
                driver.sleepTime(3000);
                createdThroughOptions[2].Click();
                //By createdThrough = By.XPath("//input[@id='ctl00_cphMain_ddlSeedType_Input']");
                //driver.SendKeysToLocator(createdThrough, "Referral"+ OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(10000);
                driver.ScrollToPageBottom();
                driver.WaitElementPresent(ddlCompany);
                driver.ClickElement(ddlCompany, "Company Name");
                driver.sleepTime(10000);
                IList<IWebElement> companyElement = driver.FindElements(By.XPath("//*[@id='ctl00_cphMain_ddlCompany_DropDown']/div[1]/ul"));
                var companyOptions = companyElement.First().FindElements(By.TagName("li"));
                driver.sleepTime(3000);
                //(207247 - Boston, Massachusetts)
                companyOptions[0].Click();
                //By company = By.Id("ctl00_cphMain_ddlCompany_Input");
                //driver.SendKeysToLocator(company, "(207247 - Boston, Massachusetts)" + OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(10000);
                option = driver.GetElementAttribute(ddlCompany, "value");
                driver.sleepTime(2000);
                driver.ClickElement(btnSave, "Click on Save Button");
                driver.sleepTime(5000);
                
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add New Seed", "Failed Add New Seed", EngineSetup.GetScreenShotPath());
            }
            return option;
        }
                
        public void VerifySeedCompanyValue(string selectedValue)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.WaitElementPresent(frameSeedManage);
            driver.SwitchToFrameByLocator(frameSeedManage);
            driver.sleepTime(5000);
            driver.ScrollToPageBottom();
            driver.sleepTime(5000);
            By by = By.Id("ctl00_ctl00_cphMain_cphMain_ddlCompany_Input");
                driver.WaitElementPresent(by);
                driver.ClickElement(by, "Click Company dropdown");
                driver.sleepTime(20000);
            By val=By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlCompany_DropDown']/div/ul/li[1]");
                // By value = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphMain_ddlCompany']/table/tbody/tr/td[1]/input");
                // driver.WaitElementPresent(val);
                string element = driver.GetElementText(val);
            if(element.Equals(selectedValue))
                {
                    this.TESTREPORT.LogSuccess("Verify Seed Company Value", "Seed Company Value is listed by default");
                }
                else
                { 
                 this.TESTREPORT.LogFailure("Verify Seed Company Value", "Seed Company Value is not listed by default");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Seed Company Value", "Failed Verify Seed Company Value", EngineSetup.GetScreenShotPath());
            }

}

        #endregion
    }

}
