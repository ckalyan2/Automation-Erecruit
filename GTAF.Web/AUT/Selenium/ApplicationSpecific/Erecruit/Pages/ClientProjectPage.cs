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
    public class ClientProjectPage: AbstractTemplatePage
    {
        public static string id = "";
        Utility utility = new Utility();

        #region UI Object Repository

        #region ClientProject
        private By btnAddClientProject = By.XPath("//button[@id='btnAddNewClientProject']");
        private By frameManage = By.XPath("//iframe[contains(@id,'company_manage_')]");
        private By logoMenu = By.XPath("//div[@class='logo_inner']");
        private By lnkAddnew = By.XPath("//span[text()='Add New']");
        private By lnkClientProject = By.XPath("//span[text()='Client Project']");
        private By frameClientProject = By.XPath("//iframe[contains(@id,'clientproject_new')]");
        private By txtClientProjectName = By.Id("ctl00_cphMain_txtName");
        private By ddlClient = By.Id("ctl00_cphMain_ddlCompany_Input");
        private By txtClient = By.XPath("//li[text()='2016.38 Requirement Check']");
        private By ddlClientType = By.Id("ctl00_cphMain_ddlType_Input");
        private By txtClientType = By.XPath("//li[text()='VMS Only']");
        private By ddlStatus = By.Id("ctl00_cphMain_ddlStatus_Input");
        private By txtStatus = By.XPath("//li[text()='Approved']");
        private By btnSaveClientProject = By.Id("ctl00_cphMain_btnSave_input");
        private By lnkCompany = By.XPath("//div[contains(@id,'tab_company_manage_')]");
        private By lnkAccounting = By.XPath("//span[text()='Accounting']");
        private By framePvAccounting = By.XPath("//iframe[@id='pvAccounting_frame']");
        private By btnAddPositionTemp = By.XPath("//button[@title='Add a Position Template']");
        private By txtPositionTiltle = By.XPath("//input[@id='PositionTitle']");
        private By ddlRateType = By.XPath("//div[@id='s2id_RateType_SelectedItem']//following-sibling::div/b");
        private By txtSearchRateType = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By txtEffectiveDate = By.XPath("//input[@name='EffectiveDate']");
        private By btnSavePositionTemp = By.XPath("//button[@id='SavePositionTemplate']");
        #endregion
        #region Search ClientProject
        private By lnkSearchClientProject = By.XPath("//span[text()='Client Projects']");
        private By txtClientProjectId = By.XPath("//span[text()='Client Projects']//input");
        private By frameManageClientproject = By.XPath("//iframe[contains(@id,'clientproject_manage')]");
        private By imgMilestone = By.XPath("//img[@data-tipname='clientproject/milestone']");
        private By txtName = By.XPath("//input[contains(@id,'_txtname')]");
        private By txtComplete = By.XPath("//input[contains(@id,'txtpercentcomplete')]");
        private By txtFee = By.XPath("//input[contains(@id,'_txtfee')]");
        private By btnSave = By.XPath("//button[contains(@id,'_btnsave')]");
        private By lblCompletePercent = By.XPath("//div[contains(@id,'widget_milestones_')]/div[2]/table//td[3]");
        private By lblCompleteInvoice = By.XPath("//img[@title='Click to complete']");
        private By btnEdit= By.XPath("//div[@data-tipname='clientproject/general']");
        private By ddlResourceManager = By.XPath("//input[contains(@id,'ddlresourcemanager')]");
        private By btnSaveGeneral = By.XPath("//button[contains(@id,'btnsave')]");
        private By btnGeneral = By.XPath("//span[text()='Project Title']");
        // private By lnkResourceMngrWarning=By.XPath("//div[@class='bordered cooltipmessage error']");


        #endregion
        #endregion
        public void verifyAddClientProject(string ClientName)
        {
            try
            {
                driver.ClickElement(logoMenu, "ImageLogo");
                driver.MouseHover(lnkAddnew, "Add New");
                driver.WaitElementPresent(lnkClientProject);
                driver.ClickElement(lnkClientProject, "ClientProject");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameClientProject);
                driver.SwitchToFrameByLocator(frameClientProject);
                //driver.sleepTime(50000);
                //driver.WaitElementPresent(txtClientProjectName);
                //driver.SendKeysToElement(txtClientProjectName, ClientName, "Name");
                //driver.WaitElementPresent(ddlClient);
                //driver.ClickElement(ddlClient, "Client Name");
                //driver.ClickElement(txtClient, "Client Name");
                //driver.sleepTime(5000);
                //driver.WaitElementPresent(ddlClientType);
                //driver.ClickElement(ddlClientType, "Type");
                //driver.ClickElement(txtClientType, "Type");
                //driver.sleepTime(5000);
                //driver.WaitElementPresent(ddlStatus);
                //driver.ClickElement(ddlStatus, "Status");
                //driver.ClickElement(txtStatus, "Status");
                //driver.WaitElementPresent(btnSaveClientProject);
                //driver.ClickElement(btnSaveClientProject, "Save Client Project");
                driver.sleepTime(5000);
                driver.SendKeysToElement(txtClientProjectName, ClientName, "Name");
                driver.WaitElementPresent(ddlClientType);
                driver.ClickElement(ddlClientType, "Type");
                driver.WaitElementPresent(txtClientType);
                driver.ClickElement(txtClientType, "Type");
                driver.WaitElementPresent(ddlStatus);
                driver.ClickElement(ddlStatus, "Status");
                driver.WaitElementPresent(txtStatus);
                driver.ClickElement(txtStatus, "Status");
                driver.WaitElementPresent(btnSaveClientProject);
                driver.ClickElement(btnSaveClientProject, "Save Client Project");
                driver.sleepTime(5000);
                id = utility.GetTitleId();
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Client Project", "Failed to Click On Client Project", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Add Client Project
        /// </summary>
        public void AddClientProject(string ClientName)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManage);
                driver.SwitchToFrameByLocator(frameManage);
                driver.WaitElementPresent(btnAddClientProject);
                driver.ClickElement(btnAddClientProject, "Add button");
                driver.sleepTime(2000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameClientProject);
                driver.SwitchToFrameByLocator(frameClientProject);
                driver.sleepTime(5000);
                driver.SendKeysToElement(txtClientProjectName, ClientName, "Name");
                driver.WaitElementPresent(ddlClientType);
                driver.ClickElement(ddlClientType, "Type");
                driver.WaitElementPresent(txtClientType);
                driver.ClickElement(txtClientType, "Type");
                driver.WaitElementPresent(ddlStatus);
                driver.ClickElement(ddlStatus, "Status");
                driver.WaitElementPresent(txtStatus);
                driver.ClickElement(txtStatus, "Status");
                driver.WaitElementPresent(btnSaveClientProject);
                driver.ClickElement(btnSaveClientProject, "Save Client Project");
                driver.sleepTime(5000);
                ////Switvh To Company
                //driver.SwitchToDefaultFrame();
                //driver.ClickElement(lnkCompany, "Company");
                //driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //driver.SwitchToFrameByLocator(frameManage);
                //driver.ClickElement(lnkAccounting, "Tab Accounting");
                ////driver.sleepTime(10000);
                //driver.SwitchToDefaultFrame();
                //driver.sleepTime(5000);
                //driver.SwitchToFrameByLocator(frameManage);
                //driver.SwitchToFrameByLocator(framePvAccounting);
                //driver.ClickElement(btnAddPositionTemp, "Button Add");
                //driver.SendKeysToElement(txtPositionTiltle, "TestPositionTitle", "Position Title");
                //driver.ScrollPage();
                //driver.ClickElement(ddlRateType, "Type");
                //driver.SendKeysToElementAndPressEnter(txtSearchRateType, "Standard", "Type text");
                //driver.SendKeysToElementAndPressEnter(txtEffectiveDate,"12/14/2017","Effective Date");
                //driver.ClickElement(btnSavePositionTemp, "Save");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Client Project", "Failed to Add ClientProject", EngineSetup.GetScreenShotPath());
            }

        }
        public void SearchClientProject(string id)
        {
            try
            {
                driver.MouseHover(lnkSearchClientProject, "Client Project");
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageClientproject);
                driver.SwitchToFrameByLocator(frameManageClientproject);
                driver.sleepTime(5000);
                driver.WaitElementPresent(imgMilestone);
                driver.ClickElement(imgMilestone, "Milestone");
                driver.sleepTime(5000);
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Search Client Project", "Failed to Search Client Project", EngineSetup.GetScreenShotPath());
            }
        }

        public void Milestone100percent(string name,string percent,string fee,string txtResourceManger)
        {
            try
            {
                driver.WaitElementPresent(txtName);
                driver.SendKeysToElement(txtName, name, "Name");
                driver.SendKeysToElementClearFirst(txtComplete, percent, "Complete Percentage");
                driver.SendKeysToElementClearFirst(txtFee, fee, "fee");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save");
                driver.sleepTime(5000);
                driver.WaitElementPresent(lblCompleteInvoice);
                string completepercentage = percent + "%";
                driver.WaitElementPresent(lblCompleteInvoice);
                driver.ClickElement(lblCompleteInvoice, "Complete");
                driver.AcceptAlert();
                By warningMessage = By.XPath("//div[@class='bordered cooltipmessage error']");
                if(driver.FindElements(warningMessage).Count > 0)
                {
                    driver.MouseHover(btnGeneral, "");
                    driver.WaitElementPresent(btnEdit);
                    driver.ClickElementWithJavascript(btnEdit, "Edit");                   
                    driver.ClickElementAndSendKeys(ddlResourceManager, txtResourceManger, "Resource Manager");
                    driver.WaitElementPresent(btnSaveGeneral);
                    driver.ClickElement(btnSaveGeneral, "Save");
                }  
                else
                {
                    Console.WriteLine("Client Project is created");
                }             
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("100% Milestone", "Failed to Add 100% Milestone", EngineSetup.GetScreenShotPath());
            }


        }
    }
}
