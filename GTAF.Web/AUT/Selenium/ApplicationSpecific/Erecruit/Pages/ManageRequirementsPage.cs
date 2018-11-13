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
using System.Threading;
using Keys = OpenQA.Selenium.Keys;

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class ManageRequirementsPage : AbstractTemplatePage
    {
        AddCandidatePage candidate = new AddCandidatePage();
        Utility utility = new Utility();
        HomePage home = new HomePage();

        #region Constructors
        public ManageRequirementsPage()
        {
        }

        public ManageRequirementsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        
        // ----Add requirement --//
        private By lnkTools = By.XPath("//span[text()='Tools']");
        private By lnkControlPanel = By.XPath("//span[text()='Control Panel']");
        private By lnkControlPanelModule = By.XPath("//li[@class='rmItem rmLast']");
        private By txtRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/span[1]/input[1]");
        private By lnkRequirementDef = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[3]/li[4]/ul/li/a[text()='Requirement Definitions']");
        private By btnAddRequirement = By.XPath("//button[@title='Add a new Requirement']");
        private By txtEnterName = By.XPath("//input[@placeholder='Enter a Name']");
        private By ddntype = By.XPath("//div[@id='s2id_RequirementType_SelectedItem']/a/span");
        private By txttype = By.XPath("//input[@data-helptip='RequirementType']");
        private By ddntarget = By.XPath("//div[@id='s2id_TargetAboutTypeID_SelectedItem']/a/span");
        private By txttarget = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By txtWeight = By.Id("Weight");
        private By btnSave = By.XPath("//button[text()='Save']");
        private By lnkMatches = By.XPath("//span[@title='Keyboard Shortcut: Shift+S, T']"); //By.XPath("//li[@class='search maintain_hover']//li[@class='match']/span[contains(text(),'Matches')]");
        private By lnkMatchinput = By.XPath("//div//ul/li[@class='match']//input");

        //--Edit Requirement--//
        private By txtFiltername = By.Id("txtfilter");
        private By btnEdit = By.XPath("//button[@class='btn editRequirement input-sm clicktip']");
        private By btnExpand = By.XPath("//div[@class='expandButton']");

        //Manage Requirement
        private By frameManageRequirement = By.XPath("//iframe[contains(@id,'admin_site-ManageRequirements')]");
        private By btnAddRequirements = By.XPath("//button[text()='Add Requirement']");
        private By txtRequirementName = By.XPath("//input[@id='Name']");
        private By ddlType= By.XPath("//div[@id='s2id_RequirementType_SelectedItem']");
        private By txtSearchType = By.XPath("//input[@data-helptip='RequirementType']");
        private By targetRecordType = By.XPath("//div[@id='s2id_TargetAboutTypeID_SelectedItem']");
        private By txtSearchTargetRecord = By.XPath("//input[@data-helptip='RequirementTargetAboutType']");
        private By btnSaveRequirement = By.XPath("//button[@id='SaveRequirement']");
        private By txtFilterName = By.XPath("//input[@id='txtfilter']");
        private By LnkPlusSign = By.XPath("//div[@class='expandButton']");
        private By AddScenarios = By.XPath("//button[@class='btn icon-add btn-xs clicktip']");
        private By AddStatuses = By.XPath("//button[@class='clicktip icon-add btn btn-xs']");
        private By ddlStatus = By.XPath("//label[text()='Status']/../div/a");
        private By txtStatus = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By lnkManageTags = By.XPath("//span[text()='Manage Tags']");
        private By txtName = By.XPath("//label[text()='Name:']//following-sibling::input");
        private By ddnclrPicker = By.XPath("//label[text()='Color:']/../div/div");
        private By selColor = By.XPath("//div[@class='ColorPicker_DropDown']/div[1]/a[10]");
        private By txtDesc = By.XPath("//label[text()='Description']//following-sibling::textarea");
        private By lnkWorkersComp = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[1]/li[3]/ul/li[1]/a");
        private By lnkWorkEdit = By.XPath("//tr[@data-bind='css: { warning: WarningMessage }'][1]/td[@class='Buttons']/button[1]");
        private By txtPercentageinput = By.XPath("//label[text()='Percentage: ']//following-sibling::input");
        private By btnTypes = By.XPath("//button[text()='Types']");
        private By lblMangeReq = By.XPath("//h1[text()='Manage Requirement Types']");
        private By ddnScenario = By.XPath("//label[text()='Scenario']/../div/a");
        private By txtScenario = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By btnScenarioSave = By.XPath("//div[@class='widgetContainer widget-md']/footer/div/button[text()='Save']");
        private By lnkPermissionTemp = By.XPath("//a[@class='rmLink adminmenuitem rmRootLink rmSelected rmExpanded']/../div/ul/li[4]/div/div/ul[1]/li[1]/ul/li[4]/a[text()='Permission Templates']");
        private By txtPermission = By.Id("ctl00_ctl00_cphMain_cphMain_txtFilter");
        private By lblPermission = By.XPath("//span[text()='Edit Requirement Integration Provider']");
        private By lblPackagePermission = By.XPath("//span[text()='Edit Requirement Integration Package/Service']");

        private By btnRefreshpage = By.XPath("//button[@id='RefreshListButton']");
        private By btnManageSave = By.XPath("//button[text()='Save']");
        private By frameSearchMatch = By.XPath("//iframe[@src='..//Search/match/']");
        #endregion

        #region Public Methods

        public void VerifyManageTags()
        {
            try
            {
                home.ClickOnLogoMenu();
                home.MouseHoverOnSearch();
                driver.WaitElementPresent(lnkMatches);
                driver.ClickElement(lnkMatches, "Click On Matches");
                driver.sleepTime(10000);
                driver.WaitElementPresent(frameSearchMatch);
                driver.SwitchToFrameByLocator(frameSearchMatch);
                driver.sleepTime(15000);
                driver.WaitElementPresent(lnkManageTags);               
                //driver.CheckElementExists(lnkManageTags, "Manage Tags");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Manage Tags", "Failed to Verify Manage Tags:", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreateManageTags( string tagname,string description)
        {
            try
            {
                home.ClickOnLogoMenu();
                home.MouseHoverOnSearch();
                driver.WaitElementPresent(lnkMatches);
                driver.ClickElement(lnkMatches, "Click On Matches");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameSearchMatch);
                driver.SwitchToFrameByLocator(frameSearchMatch);
                driver.sleepTime(20000);
                driver.WaitElementPresent(lnkManageTags);
                //ExpectedConditions.ElementIsVisible(lnkManageTags);
                driver.ClickElement(lnkManageTags, "Manage Tags");
                driver.sleepTime(15000);
                IList<IWebElement> create = driver.FindElements(By.XPath("//span[text()='Create New Tag']"));
                create[0].Click();
                driver.sleepTime(10000);
                driver.WaitElementPresent(txtName);
                driver.SendKeysToElementClearFirst(txtName, tagname, "Tag Name");
                driver.WaitElementPresent(ddnclrPicker);
                driver.ClickElement(ddnclrPicker, "Color");
                driver.WaitElementPresent(selColor);
                driver.ClickElement(selColor, "Select Color");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtDesc);
                driver.SendKeysToElement(txtDesc, description, "Description");
                driver.WaitElementPresent(btnManageSave);
                driver.ClickElement(btnManageSave, "Save button");
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Create Tag", "Failed to Create Tag:", EngineSetup.GetScreenShotPath());
            }
        }

       public void ChangeWorkersComp(string template,string weight)
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, template, "Worker's Compensation");
                driver.ClickElement(lnkWorkersComp, "Worker's Compensation");
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByIndex(1);
               // driver.WaitElementPresent(lnkWorkEdit);
                if (driver.FindElements(lnkWorkEdit).Count > 0)
                {
                    Thread.Sleep(2000);
                    driver.ClickElementWithJavascript(lnkWorkEdit, "Edit button");
                    driver.SendKeysToElementClearFirst(txtPercentageinput, weight, "Percentage");
                    driver.ClickElement(btnSave, "Save");
                }
                else
                {
                    Console.WriteLine("No Records are available");
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Change Workers Compensation", "Failed to Verify Change Workers Compensation:", EngineSetup.GetScreenShotPath());
            }
        }
       
       public void ManageTypes()
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(btnTypes);
                driver.ClickElementWithJavascript(btnTypes, "Types");
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(lblMangeReq);
                driver.VerifyWebElementPresent(lblMangeReq, "Manage Requirement Types");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Manage Types", "Failed to Verify Manage Types:", EngineSetup.GetScreenShotPath());
            }
        }

       public void RequirementScenarioDeletion()
        {
            try
            {
                //driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
                //driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                //driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //driver.SwitchToFrameByIndex(1);
                //driver.WaitElementPresent(txtFiltername);       
                //driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                ////driver.WaitElementPresent(btnExpand);
                //driver.sleepTime(10000);
                //IList<IWebElement> reqexpand = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                //reqexpand[0].Click();
                //driver.sleepTime(10000);
                //IList<IWebElement> scenario = driver.FindElements(By.XPath("//ul[@class='list-group']"));
                //var options = scenario.First().FindElements(By.TagName("li"));              
                //options[0].FindElement(By.TagName("span")).Click();
                //if (driver.isAlertPresent())
                //{
                //    IAlert devAlert = driver.SwitchTo().Alert();
                //    devAlert.Accept();
                //}
                //driver.sleepTime(10000);
                //if (driver.isAlertPresent())
                //{
                //    IAlert devAlert = driver.SwitchTo().Alert();
                //    devAlert.Accept();
                //}
                driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(txtFiltername);
                driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                //driver.WaitElementPresent(btnExpand);
                driver.sleepTime(10000);
                IList<IWebElement> reqexpand = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                reqexpand[0].Click();
                driver.sleepTime(10000);
                IList<IWebElement> add = driver.FindElements(By.XPath("//button[@class='btn icon-add btn-xs clicktip']"));
                add[0].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnScenario);
                driver.ClickElement(ddnScenario, "scenario");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtScenario);
                driver.SendKeysToLocator(txtScenario, "Add To New Companies" + OpenQA.Selenium.Keys.Enter, "Scenario name");
                // driver.SendKeysToElementAndPressEnter(txtScenario, "Add To New Companies","scenario name");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnScenarioSave);
                driver.ClickElement(btnScenarioSave, "Save");
                driver.sleepTime(15000);
                driver.WaitElementPresent(btnRefreshpage);
                driver.ClickElement(btnRefreshpage, "");
                driver.sleepTime(15000);
                driver.WaitElementPresent(txtFiltername);
                driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                //driver.WaitElementPresent(btnExpand);
                driver.sleepTime(10000);
                IList<IWebElement> reqexpand1 = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                reqexpand1[0].Click();
                driver.sleepTime(10000);
                IList<IWebElement> scenario = driver.FindElements(By.XPath("//ul[@class='list-group']"));
                var options = scenario.First().FindElements(By.TagName("li"));
                options[0].FindElement(By.TagName("span")).Click();
                if (driver.isAlertPresent())
                {
                    IAlert devAlert = driver.SwitchTo().Alert();
                    devAlert.Accept();
                }
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Requirement Scenario Deletion", "Failed to Verify Requirement Scenario Deletion:", EngineSetup.GetScreenShotPath());
            }
        }
       public void AddScenarioToRequirement()
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");                
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(txtFiltername);
                driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                //driver.WaitElementPresent(btnExpand);
                driver.sleepTime(10000);
                IList<IWebElement> reqexpand = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                reqexpand[0].Click();
                driver.sleepTime(10000);
                IList<IWebElement> add = driver.FindElements(By.XPath("//button[@class='btn icon-add btn-xs clicktip']"));
                add[0].Click();
                driver.sleepTime(5000);
                driver.WaitElementPresent(ddnScenario);
                driver.ClickElement(ddnScenario, "scenario");
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtScenario);
                driver.SendKeysToLocator(txtScenario, "Add To New Companies" + OpenQA.Selenium.Keys.Enter, "Scenario name");
               // driver.SendKeysToElementAndPressEnter(txtScenario, "Add To New Companies","scenario name");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnScenarioSave);
                driver.ClickElement(btnScenarioSave, "Save");
                driver.sleepTime(10000);
                //driver.WaitElementPresent(btnRefreshpage);
                //driver.ClickElement(btnRefreshpage, "");
                //driver.sleepTime(5000);
                //driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //driver.SwitchToFrameByIndex(1);
                //driver.WaitElementPresent(txtFiltername);
                //driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                ////driver.WaitElementPresent(btnExpand);
                //driver.sleepTime(10000);
                //IList<IWebElement> reqexpand1 = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                //reqexpand1[0].Click();
                //driver.sleepTime(10000);
                //IList<IWebElement> scenario = driver.FindElements(By.XPath("//ul[@class='list-group']"));
                //var options = scenario.First().FindElements(By.TagName("li"));
                //options[0].FindElement(By.TagName("span")).Click();
                //if (driver.isAlertPresent())
                //{
                //    IAlert devAlert = driver.SwitchTo().Alert();
                //    devAlert.Accept();
                //}
                //driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Add Scenario To Requirement", "Failed to Verify Add Scenario To Requirement:", EngineSetup.GetScreenShotPath());
            }
        }

        public void GetRequirement()
        {
            try
            {
                driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
                driver.ClickElement(lnkRequirementDef, "Requirement Definition");
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByIndex(1);
                driver.WaitElementPresent(txtFiltername);
                driver.SendKeysToElementWithJavascript(txtFiltername, "Test Req", "Requirement Name");
                Thread.Sleep(5000);
                IList<IWebElement> reqexpand = driver.FindElements(By.XPath("//div[@class='expandButton']"));
                reqexpand[0].Click();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Requirement is opened", "Failed to Verify Requirement is opened:", EngineSetup.GetScreenShotPath());
            }
        }

       public void PermissionTemplate(string Permission,By Xpath)
        {           
            try
            {
                driver.WaitElementPresent(txtRequirementDef);
                driver.SendKeysToElementClearFirst(txtRequirementDef, "permission Templates", "permission Templates");
                driver.WaitElementPresent(lnkPermissionTemp);
                driver.ClickElement(lnkPermissionTemp, "permission Templates");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(By.XPath("//iframe[contains(@id,'admin_site-ManagePermissionTemplates')]"));
                driver.SwitchToFrameByLocator(By.XPath("//iframe[contains(@id,'admin_site-ManagePermissionTemplates')]"));
                driver.WaitElementPresent(txtPermission);
                driver.SendKeysToElementClearFirst(txtPermission, Permission, "Permission name");
                driver.WaitElementPresent(Xpath);
                driver.CheckElementDisplayed(Xpath,"Permission name");
                driver.sleepTime(2000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add a new requirement", "Failed to Add a new requirement:", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyProviderPermissionTemplate()
        {
            PermissionTemplate("Edit Requirement Integration Provider",lblPermission);
        }
       
       public void VerifyPackagePermissionTemplate()
        {
            PermissionTemplate("Edit Requirement Integration Package", lblPackagePermission);
        }

        public void ClickOnRequirementDefinition(string txtName, string txtReqType, string txtTargetRecord)
        {
            driver.SendKeysToElementClearFirst(txtRequirementDef, "Requirement", "Requirement Definition");
            driver.ClickElement(lnkRequirementDef, "Requirement Definition");
            driver.SwitchToDefaultFrame();
            driver.SwitchToFrameByLocator(frameManageRequirement);
            driver.WaitForPageLoad(TimeSpan.FromSeconds(20));
            driver.ClickElement(btnAddRequirements,"Add Requirement");
            driver.FindElement(txtRequirementName);
            driver.SendKeysToElement(txtRequirementName, txtName, "Name");
            driver.ClickElement(ddlType,"Type");
            driver.SendKeysToElementAndPressEnter(txtSearchType, txtReqType, "Type");
            driver.ClickElement(targetRecordType,"Target Record Type");
            driver.SendKeysToElementAndPressEnter(txtSearchTargetRecord, txtTargetRecord, "Target Record Type");
            driver.ClickElement(btnSaveRequirement, "Save");
            driver.FindElement(txtFilterName);
            driver.SendKeysToElement(txtFilterName, txtName, "Filter Name");
            driver.WaitForPageLoad(TimeSpan.FromSeconds(10));
            driver.ClickElement(LnkPlusSign, "Plus");

            //Add Scenario
            driver.ClickElement(AddScenarios, "Plus");
            //driver.ClickElement(ddlSearchScenario);//div[@id='s2id_autogen6']
            driver.ClickElement(ddnScenario, "scenario");
            driver.SendKeysToElementAndPressEnter(txtScenario, "Add To New Companies", "");
            driver.ClickElement(btnScenarioSave, "Save");

            //Add Status
            driver.ClickElement(AddStatuses,"Plus");
            driver.ClickElement(ddlStatus,"Status");
            driver.SendKeysToElementAndPressEnter(txtStatus,"Confirmed","");
            driver.ClickElement(btnScenarioSave, "Save");

        }
     #endregion

    }

}
