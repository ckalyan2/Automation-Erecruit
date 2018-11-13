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
    public class AddVendorPage : AbstractTemplatePage
    {
        #region UI Object Repository
        private By frameVendor = By.XPath("//div[@class='dialog']");
        private By txtVendorName = By.Id("ctl00_cphMain_Address_txtTitle");
        private By ddlVendormngr = By.Id("ctl00_cphMain_ddlVendorContact_Input");
        private By ddlVendormngrlist = By.Id("//div[@id='ctl00_cphMain_ddlVendorContact_DropDown']");
        private By ddlLocaleresource = By.Id("ctl00_cphMain_ddlLocaleResource_Input");
        private By btnSavevendor = By.Id("ctl00_cphMain_btnSave_input");
        private By lblId = By.XPath("//div[@id='pagetitle']/h1");
        private By btnSaveConfirm = By.XPath("//div[@class='bottombuttons']/div[2]/span[@id='ctl00_ctl00_cphMain_cphBottomButtons_btnSave']/input[1]");
        private By lblMessage = By.XPath("//div[@class= 'messages messagingContainer']/div");
        private By frameVendorcreated = By.XPath("//iframe[contains(@id,'vendor_manage')]");
        #endregion
        #region Public Methods
        /// <summary>
        /// Method to Add Vendor 
        /// </summary>
        public void AddNewVendor(string vendorname)
        {
            try
            {
                driver.SwitchToFrameByIndex(1);
                driver.SendKeysToElementClearFirst(txtVendorName, vendorname, "Vendor Name");
                driver.ClickElement(ddlVendormngr, "VendorManager");
                driver.sleepTime(5000);
                var vendor = driver.FindElement(By.XPath("//div[contains(@id, 'ctl00_cphMain_ddlVendorContact')]//ul"));
                vendor.FindElements(By.TagName("li"))[0].Click();
                driver.WaitElementPresent(ddlLocaleresource);
                driver.ClickElement(ddlLocaleresource, "LocaleResource");
                driver.sleepTime(5000);
                var locale = driver.FindElement(By.XPath("//div[contains(@id, 'ctl00_cphMain_ddlLocaleResource_DropDown')]//ul"));
                locale.FindElements(By.TagName("li"))[0].Click();
                driver.WaitElementPresent(btnSavevendor);
                driver.ClickElement(btnSavevendor, "SaveVendor");
                //driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //driver.SwitchToFrameByIndex(1);
                //driver.WaitElementExistsAndVisible(btnSaveConfirm);
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Vendor", "Failed to Add New Vendor", EngineSetup.GetScreenShotPath());
            }
            
        }
        #endregion
    }
}
