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
    public class SearchCandidatesPage : AbstractTemplatePage
    {
        HomePage home = new HomePage();

        #region Constructors
        public SearchCandidatesPage()
        {
        }

        public SearchCandidatesPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository 
        private By lstCandidate = By.XPath("//a[@title='Left click to open Candidate. Right click to preview.']");
        private By lnkSavedSearches = By.XPath("//div[@class='search-sidebar-buttons section']/div[1]/div[3]/div/span[text()='Saved Searches']");
        private By txtMySearches = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible'][1]/div[3]//span[text()='My Searches']");
        private By txtSharedWithMe = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible'][1]/div[3]//span[text()='Shared With Me']");
        private By txtSaveCurrentSearch = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible'][1]/div[3]//span[text()='Save Current Search']");

        private By txtSearchName = By.XPath("//label[@data-bind='text: Labels.SearchName ']/../input");
        private By btnSave = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible'][2]/div[3]//div[@class='footerControls']/button/span");
        private By lstSavedSearch = By.XPath("//div[@class='listWidget widgetContainer widget-md']/div[2]/div[4]");
        //private By lnkCandidate = By.XPath("//a[text()='Candi Test (5147152)']");
        // private By lnkCandidate = By.XPath("//a[text()='Test Resume Reg335 Test Resume Reg (5147193)']");
        private By lnkCandidate = By.XPath("//a[@data-tipmode='overview']");
        private By frame = By.XPath("//iframe[@src='..//Search/candidate/By/quick?query=Test']");
        private By lnkPencil = By.XPath("//div[@class='t_Tooltip t_Tooltip_erecruitDefault t_visible'][1]/div[3]//span[text()='My Searches']/../../div[1]/span/span[1]");
        private By chckboxShare = By.XPath("//input[@data-bind='checked: shareChecked']");
        private By lnkpeople = By.XPath("//span[text()='People']");
        private By txtCanedit = By.XPath("//span[text()='People']/../../div/div[1]/div/ul/li/input");
        private By txtCanview = By.XPath("//span[text()='People']/../../div/div[2]/div/ul/li/input");
        private By btnShareSave = By.XPath("//button[@data-bind='click: save, enable: (currentEditingItem()!=null || canSaveQuery) && inProgress()==0']");
        private By btndel = By.XPath("//a[text()='Search Test']//following-sibling::span/span[1]//following-sibling::span[1]");
        private By frameCandidate = By.XPath("//iframe[contains(@id,'candidate_By-quick')]");
        private By frameCandidatemng = By.XPath("//iframe[contains(@id,'candidate_manage')]");


        #region C277150
        private By lnkcredcand = By.XPath("//a[text()='Test132 Xyz (5147171)']");
        private By lnkRequirements = By.XPath("//span[@id='RequirementCount']");
        private By btnCredentialReq = By.XPath("//a[text()='Credentialing Requests']");
        private By btnAddCredentialReq = By.XPath("//button[text()='Add Credentialing Request']");
        //private By ddnFacility = By.XPath("//div[@class='select2-container select2-container-multi select2-dropdown-open']/ul/li/input");
        private By ddnFacility = By.XPath("//span[text()='Facility Department']/../../div/ul/li/input");
        private By txtPosition = By.XPath("//div[@data-requirementmessage='Position Type is required']/h5//following-sibling::input");
        private By chckboxOngoing = By.XPath("//label[text()='Ongoing']");
        private By btnAddtarget = By.XPath("//span[text()='Add Target']");
        private By btnRefresh = By.XPath("//span[text()='Requirements for ']/../div/button[2]");
        private By lnkdelete = By.XPath("//div[@title='Remove this target']");
        private By btnsearch = By.XPath("//div[@class='listWidget widgetContainer widget-md']//button/span['Save Current Search']");
        #endregion

        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By lnkCredentialRequest = By.XPath("//div[@id='RecordCounts']//ul/li//span[@id='RequirementCount']");
        private By tabCredentialRequests = By.XPath("//a[contains(@id,'ui-id') and text()='Credentialing Requests']");
        private By btnAddCredentialRequests = By.XPath("//div[contains(@id,'targets')]//button[text()='Add Credentialing Request']");
        private By ddldepartments = By.XPath("//div[contains(@id,'ddlfacilitydepartments')]/ul/li/input");
        private By ddlPositionType = By.XPath("//*[@id='s2id_autogen17']/a/span");
            //By.XPath("//input[contains(@id,'ddlpositiontypes')]");
        private By cbxOngoing = By.XPath("//input[contains(@id,'targetstartdate_today') and @type='checkbox']");
        private By btnAddTarget = By.XPath("//button[contains(@id,'savetarget')]/span[text()='Add Target']");
        private By lnkStatus = By.XPath("//table/thead/tr/th/div[text()='Status']/../../..//following::tbody/tr/td/a[text()='Complete']");
        private By btnRefresh1 = By.XPath("//div[contains(@id,'targets')]//button[@class='btn-sm text-color-success icon-refresh btnrefresh'] ");
        private By divReqProgress = By.XPath("//div[contains(@id,'widget_requirementsprogress')]//div[text()='Requirements Progress']");
        private By lblIncomplete = By.XPath("//div[contains(@id,'widget_requirementsprogress')]//table/tbody//td[contains(text(),'There are no incomplete requirements')]");
        private By btnClose = By.XPath("//div[contains(@id','widget_requirementsprogress')]//button[text()='Close']");
        private By ddlFolderGroup = By.XPath("//div[@id='s2id_autogen6']/a/span");
        private By ddlCompany = By.XPath("//div[@id='s2id_autogen7']/a/span");
        private By lnkColumns = By.XPath("//div[text()='Columns']");
        private By chkboxApplicationID = By.XPath("//h3[text()='General']/../div//span[text()='Application ID']/../input");
        private By columnApplicationID = By.XPath("//a[@data-tipcontext='candidateapplication']");
        private By btnCloseReq = By.XPath("//div[contains(@id,'widget_requirementsprogress')]//button[text()='Close']");
        private By tabRequirements = By.XPath("//a[contains(@id,'ui-id') and text()='Requirements']");
        private By dotOptions = By.XPath("//div[contains(@id,'options')]");
            //By.XPath("//td/div/../../td//div[@class='requirementoptions cursor-pointer icon-options']");
        //By.XPath("//table[@id='candidatetable']//td/div[@title='ACLS']/../../td//div[@class='requirementoptions cursor-pointer icon-options']");
        private By dotOptions2 = By.XPath("//table[@id='candidatetable']//td/div[@title='Board Certificate - Internal Medicine']/../../td//div[@class='requirementoptions cursor-pointer icon-options']");
        private By optionConfirmed = By.XPath("//div[contains(@id,'RequirementOptions')]//span[text()='Confirmed']");
        private By framecandidate = By.XPath("//iframe[contains(@id,'candidate')]");
        #endregion

        #region Public Methods
        public void ClickOnSavedSearches()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(framecandidate);
                driver.sleepTime(20000);
                //driver.WaitElementPresent(lnkSavedSearches);
                //driver.sleepTime(10000);
                driver.ClickElementWithJavascript(lnkSavedSearches, "Saved Searches");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Saved Searches", "Failed to Click On Saved Searches:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to Check Elements Displayed
        /// </summary>
        public void SearchElementsDisplayed()
        {
            try
            {
                driver.sleepTime(5000);
                driver.CheckElementDisplayed(txtMySearches, "My Searches");
                driver.sleepTime(5000);
                driver.CheckElementDisplayed(txtSharedWithMe, "Shared With Me");
               // driver.CheckElementDisplayed(txtSaveCurrentSearch, "Save Current Search");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Elements are displayed", "Failed to Check Elements:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to click on save current search
        /// </summary>
        public void EnterSearchName(string searchname)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnsearch);            
                driver.ClickElementWithJavascript(btnsearch, "search button");
                IList<IWebElement> name = driver.FindElements(By.XPath("//label[@data-bind='text: Labels.SearchName ']/../input"));
                driver.sleepTime(3000);
                name[2].SendKeys(searchname);
               // IWebElement name = driver.FindElement(By.XPath("//div[@class='t_UpdateQueue']/following-sibling::div[2]//div[@class='widgettitle']//following-sibling::div[1]/div[3]/label/following-sibling::input"));
               // name.SendKeys(searchname);
                driver.sleepTime(5000);
                IList<IWebElement> save = driver.FindElements(By.XPath("//span[text()='Save']"));
                driver.sleepTime(3000);
                save[2].Click();
                driver.sleepTime(5000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Enter Search Name", "Failed to Enter Search Name:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Method to verify saved search
        /// </summary>
        /// <param name="savedname"></param>
        public void VerifySearchNameInSearchList(string savedname)
        {
            try
            {
                IReadOnlyCollection<IWebElement> search = driver.FindElements(By.XPath("//div[@class='listWidget widgetContainer widget-md']/div[2]/div[4]"));
                string list = search.ToString();
                foreach (var name in list)
                {
                    if (name.Equals(savedname))
                    {
                        Console.WriteLine("Search name is displayed");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Search name is not displayed");
                    }
                }
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Search Name", "Failed to Verify Search Name:", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Method to Click on Candidate Link
        /// </summary>
        public void ClickOnCandidateLink()
        {
            try
            {
                driver.SwitchToFrameByIndex(1);
                driver.ClickElement(lnkCandidate, "Candidate Link");             
                driver.SwitchToDefaultFrame();
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Candidate Link", "Failed to Click On Candidate Link:", EngineSetup.GetScreenShotPath());
            }

        }

        #region C277137
        
        /// <summary>
        /// Method to Enter people
        /// </summary>
        public void EnterPeople()
        {
            try
            {
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                driver.WaitElementPresent(lnkPencil);
                driver.ClickElementUsingWebElement(lnkPencil, "Pencil Icon");
                driver.sleepTime(3000);
                IList<IWebElement> check = driver.FindElements(By.XPath("//input[@data-bind='checked: shareChecked']"));
                driver.sleepTime(3000);
                check[2].Click();
                driver.ClickElementWithJavascript(lnkpeople, "People");
                driver.WaitElementPresent(btnShareSave);
                driver.ClickElementWithJavascript(btnShareSave, "Share search save");
                driver.sleepTime(3000);
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Enter People", "Failed to Enter People:", EngineSetup.GetScreenShotPath());
            }

        }
        #endregion

        #region C277150
        public void AddCredentialRequest(string facility ,string position)
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameCandidate);           
                driver.ClickElement(lnkcredcand, "Candidate Link");
                driver.sleepTime(5000);
                driver.WaitForPageLoad(TimeSpan.FromSeconds(30));
                driver.SwitchToDefaultFrame();
                driver.SwitchToFrameByLocator(frameCandidatemng);
                driver.sleepTime(5000);
                
                driver.ScrollPage();
                driver.sleepTime(2000);
                driver.ScrollPage();
                driver.sleepTime(2000);
                driver.ScrollPage();
                //driver.ScrollToPageBottom();
                var req = driver.FindElement(By.XPath("//span[@id='RequirementCount']"));
                Actions act = new Actions(driver);
                act.ContextClick(req).Build().Perform();
                driver.sleepTime(10000);
                driver.WaitElementPresent(btnCredentialReq);
                driver.ClickElement(btnCredentialReq, "Credentialing Request");
                var btn=driver.FindElement(By.XPath("//span[@class='requirementtitle']/following-sibling::div/button[@class='btn btn-sm icon-fullscreen btnfullscreen']"));
                btn.Click();
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameCandidatemng);
                driver.ScrollPage();
                driver.ScrollToPageBottom();               
                driver.ClickElement(btnAddCredentialReq, "Add Credentialing Request");               
                driver.SendKeysToElementAndPressEnter(ddnFacility, "AmeriLabs", "Facility Name");
                driver.WaitElementPresent(txtPosition);
                driver.SendKeysToElementClearFirst(txtPosition, "Contract", "Position Type");
                driver.sleepTime(5000);
                driver.FindElement(By.LinkText("Contract")).Click();               
                driver.ClickElement(chckboxOngoing, "Ongoing");
                driver.ClickElement(btnAddtarget, "Add Target");
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                driver.WaitElementPresent(btnCredentialReq);
                driver.ClickElementWithJavascript(btnCredentialReq, "Credentialing Request");
                driver.WaitElementPresent(lnkdelete);
                driver.ClickElement(lnkdelete, "Delete");
                driver.sleepTime(5000);
                if (driver.isAlertPresent())
                {
                    IAlert devAlert = driver.SwitchTo().Alert();
                    devAlert.Accept();
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Credential Request", "Failed to Add Credential Request:", EngineSetup.GetScreenShotPath());
            }
        }

        #endregion


        public void AddCredentialingRequest(string departmentValue, string ptype,string folderGroup,string company)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.WaitElementPresent(lnkCredentialRequest);
                var requirement = driver.FindElement(lnkCredentialRequest);
                Actions act = new Actions(driver);
                act.ContextClick(requirement).Build().Perform();
                driver.WaitElementPresent(tabCredentialRequests);
                driver.ClickElement(tabCredentialRequests, "Click Credential Requests Tab");
                driver.WaitElementPresent(btnAddCredentialRequests);
                driver.ClickElement(btnAddCredentialRequests, "Click Add Credentials Requests");
                driver.sleepTime(2000);
                By byddlFolderGroup = By.XPath("//label[text()='Folder Group']/..//div[contains(@id,'s2id_autogen')]//span");
                driver.WaitElementPresent(byddlFolderGroup);
                driver.ClickElement(byddlFolderGroup, "Select FolderGroup");
                //By by = By.XPath("//div[@class='select2-container select2-container-multi select2-dropdown-open']");
                //driver.WaitElementPresent(by);
                By searchBox = By.XPath("//div[@class='select2-drop select2-drop-active']/div/input");
                driver.SendKeysToElement(searchBox, folderGroup, "enter a random value");
                By by = By.XPath(string.Format("//div[@class='select2-drop select2-drop-active']/ul/li/div[contains(text(),'{0}')]", folderGroup));
                driver.ClickElement(by, "");
                //driver.SendKeysToElement(ddlFolderGroup, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(5000);
                By byddlCompany = By.XPath("//label[text()='Company']/..//div[contains(@id,'s2id_autogen')]//span");
                driver.ClickElement(byddlCompany, "Select Company");
                //by = By.XPath("//div[@class='select2-container select2-container-multi select2-dropdown-open']");
                //driver.WaitForElement(by);
                driver.SendKeysToElement(searchBox, "Offshore", "enter a random value");
                by = By.XPath(string.Format("//div[@class='select2-drop select2-drop-active']/ul/li/div[contains(text(),'{0}')]", company));
                driver.ClickElement(by, "");
                //driver.SendKeysToElement(byddlCompany, OpenQA.Selenium.Keys.Tab, "");
                driver.sleepTime(5000);
                //driver.ClickElement(ddldepartments, "select departments");
                //by = By.XPath("//div[@class='select2-container select2-container-multi select2-dropdown-open']");
                //driver.WaitForElement(by, TimeSpan.MaxValue);
                //driver.SendKeysToElement(ddldepartments, "te", "enter a random value");
                //by = By.XPath(string.Format("//div[@class='select2-drop select2-drop-multi select2-drop-active']/ul/li/div[contains(text(),'{0}')]", departmentValue));
                //driver.ClickElement(by, "");
                //driver.SendKeysToElement(ddldepartments, OpenQA.Selenium.Keys.Tab, "");
                //driver.sleepTime(10000);
                By ddlPType = By.XPath("//label[text()='Position Type']/..//div[contains(@id,'s2id_autogen')]//span");
                    //By.XPath("//div[@data-bind='attr: { title: PositionTypeSelectTitle }']/div/a/span");
                driver.ClickElement(ddlPType, "select Position");
                //by = By.XPath("//div[@class='select2-container select2-container-active select2-dropdown-open select2-drop-above']");
                //driver.WaitElementPresent(by);
                By sBox = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
                driver.SendKeysToElement(sBox, "Contract", "enter a random value");
                by = By.XPath(string.Format("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/ul/li/div[contains(text(),'{0}')]", ptype));
                //driver.WaitElementPresent(by);
                driver.ClickElement(by, "");
                driver.sleepTime(2000);
                By bycbxOngoing = By.XPath("//input[@data-bind='checked: Ongoing, disable: Ongoing' and @type='checkbox']");
                driver.WaitElementPresent(bycbxOngoing);
                driver.ClickElement(bycbxOngoing, "Checks the ongoing Checkbox");
                driver.sleepTime(2000);
                By byAddCRequest = By.XPath("//button[contains(text(),'Add Credentialing Request') and @class='btn btn-success']");
                driver.ClickElement(byAddCRequest, "Click Add Credentialing Request");
                driver.sleepTime(5000);
                //driver.WaitElementPresent(btnAddTarget);
                //driver.ClickElement(btnAddTarget, "Click Add Target");
                //driver.WaitElementPresent(btnRefresh1);
                //driver.ClickElement(btnRefresh1, "Click Refresh");
                //driver.WaitElementPresent(tabCredentialRequests);
                //driver.ClickElement(tabCredentialRequests, "Click Credential Requests");
                //if(driver.IsElementPresent(lnkStatus))
               
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Add Credential Request", "Failed to Add Credential Request:", EngineSetup.GetScreenShotPath());
            }
          }

        public void VerifyCompleteStatus()
        {
            try
            {
                By tdStatus = By.XPath("//td[@data-bind='text:Status, attr: {title: StatusTitle }']");
                string tdStatusValue = driver.FindElement(tdStatus).Text.ToString();
                if (tdStatusValue == "Complete")
                {
                    TESTREPORT.LogSuccess("Check Status", "Status column shows Çomplete as status :", EngineSetup.GetScreenShotPath());
                }
                else
                {
                    TESTREPORT.LogFailure("Check Status", "Status column doesn't shows Çomplete as status:", EngineSetup.GetScreenShotPath());
                }
            }
            catch(Exception ex)
            {
                TESTREPORT.LogFailure("Check Complete Status", "Failed to Check Complete Status:", EngineSetup.GetScreenShotPath());
            }
            }
        public  void VerifyStatus()
        {
            try
            {
                //driver.ClickElement(lnkStatus, "Click Status column data");
                //driver.VerifyWebElementPresent(divReqProgress, "Requirement Progress");
                //driver.VerifyWebElementPresent(lblIncomplete, "No Incomplete Requirements");
                //driver.ClickElement(btnClose, "Close the requirement Preogress Window");
                driver.sleepTime(5000);
                By IncompleteReq = By.XPath("//div[@class='pie-container' and @title='Requirements in this category are 0% confirmed.']");
                var IncomRequirement = driver.FindElement(IncompleteReq);
                Actions act = new Actions(driver);
                act.ContextClick(IncomRequirement).Build().Perform();
                driver.sleepTime(2000);
                driver.WaitElementPresent(btnCloseReq);
                driver.ClickElement(btnCloseReq,"Close Requirement Window");
                driver.WaitElementPresent(tabRequirements);
                driver.ClickElement(tabRequirements, "Click on Requirement Tab");
                //driver.WaitElementPresent(dotOptions1);
                //driver.MouseHover(dotOptions1, "Click on dot Options");
                //driver.WaitElementPresent(optionConfirmed);
                //driver.ClickElement(optionConfirmed, "Confirmed");
                //driver.sleepTime(5000);
                //driver.WaitElementPresent(dotOptions2);
                //driver.MouseHover(dotOptions2, "Click on dot Options");
                //driver.WaitElementPresent(optionConfirmed);
                //driver.ClickElement(optionConfirmed, "Confirmed");
                //driver.sleepTime(5000);

                IWebElement tableElement = this.driver.FindElement(By.XPath("//table[@id='candidatetable']/tbody"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                //foreach (IWebElement row in tableRow)
                    for(int i=1; i<=tableRow.Count;i++)
                {
                    //if (row.Text.Contains("ACLS")||row.Text.Contains("Board Certificate - Internal Medicine"))
                    //{
                        //ExpectedConditions.ElementExists(dotOptions);
                        By by = By.XPath("//*[@id='candidatetable']/tbody/tr["+i+"]/td[9]/div");
                        driver.MouseHover(by, "Click on dot Options");
                driver.WaitElementPresent(optionConfirmed);
                driver.ClickElement(optionConfirmed, "Confirmed");
                        driver.sleepTime(10000);
                       
                    //}

                }
               
                driver.WaitElementPresent(tabCredentialRequests);
                driver.ClickElement(tabCredentialRequests, "Click Credential Requests Tab");
                driver.sleepTime(3000);
                By tdStatus = By.XPath("//td[@data-bind='text:Status, attr: {title: StatusTitle }']");
                string tdStatusValue = driver.FindElement(tdStatus).Text.ToString();
                //if(driver.IsElementPresent(lnkStatus))
                if (tdStatusValue == "Complete")
                {
                    TESTREPORT.LogSuccess("Check Status", "Status column shows Çomplete as status :", EngineSetup.GetScreenShotPath());
            }
                else
                {
                    TESTREPORT.LogFailure("Check Status", "Status column doesn't shows Çomplete as status:", EngineSetup.GetScreenShotPath());
                }

            }
            catch(Exception ex)
            {
                TESTREPORT.LogFailure("Verify Requirement Progress status ", "Failed to Verify Requirement Progress status", EngineSetup.GetScreenShotPath());
            }
        }     
        #endregion

    }
}
