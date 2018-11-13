using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Engine.UIHandlers.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using GallopReporter;
using System.Windows.Forms;
using System.Threading;


namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class AddPositionPage : AbstractTemplatePage
    {
        CreatePositionPage positionPage = new CreatePositionPage();
        HomePage home = new HomePage();
        #region UI Object Repository
        private By txtCompany = By.XPath("//label[text()='Company:']/../div/a/span");
        //By.XPath("//label[contains(text(),'Company')]/../div/a");
        //By.XPath("//label[text()='Company:']/../div/a/span");
        private By ddlComapny = By.XPath("//div[contains(@class,'select2-drop-active')]/div/input");
        private By txtPositionType = By.XPath("//label[text()='Position Type:']/../div/a/span");
        private By ddlPositionType = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtPrimaryDepartment = By.XPath("//label[text()='Primary Department:']/../div/a/span");
        private By ddlPrimaryDepartment = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtFolderGroup = By.XPath("//span[text()='Folder Group']/../../div/a/span");
        private By ddlFolderGroup = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtContact = By.XPath("//label[text()='Contact:']/../div/a/span");
        private By ddlContact = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtFacilityDepartment = By.XPath("//label[text()='Facility Department:']/../div/a/span");
        private By ddlFacilityDepartment = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtPositionOwner = By.XPath("//label[text()='Position Owner:']/../div/a/span");
        private By ddlPositionOwner = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtPositionSource = By.XPath("//label[text()='Position Source:']/../div/a/span");
        private By ddlPositionSource = By.XPath("//div[@id='ui-datepicker-div']/following-sibling::div/div/input");
        private By txtPositionTitle = By.XPath(".//input[@placeholder='Position Title']");
        private By txtShiftTimePicker = By.XPath(".//div[@class='select2-drop select2-with-searchbox select2-drop-above select2-drop-active']/div/input");
        private By txtShiftDescription = By.XPath(".//input[contains(@placeholder,'Shift description')]");
        private By btnSave = By.XPath("//*[@id='save']");
        private By lblSuccessMessage = By.XPath("//div[contains(text(),'Position created successfully')]");
        private By lnkContinueToPosition = By.XPath("//a[(text()='Continue to position')]");
        private By txtPositionWidgetTitle = By.XPath("//div[@id='pagetitle']/h1");
        private By lnkPositionScheduling = By.XPath("//*[@id='actions_section']//div[starts-with(@data-tipurl,'/MVC/Shift/Scheduling')]");
        private By ttlPositionCalendar = By.XPath("//*[starts-with(@id,'view_ShiftCalendar')]/div[2]/div[contains(.,'Position Calendar')]");
        private By txtShiftDates = By.XPath("//*[starts-with(@id,'view_ShiftCalendar')]/div/span[contains(.,'9:00a - 5:00p')]//following-sibling::span");
        private By btnClosePositionCalendar = By.XPath(".//div[@class='t_CloseButtonShift']/div[1]/canvas");
        // private By lnkAssignCandidate = By.XPath("//div[contains(@id,'view_ShiftContext')]/div[2]/text()");
        private By lnkAssignCandidate = By.XPath("//div[contains(@id,'view_ShiftContext')]/div[2]");
        private By lnkAllCandidates = By.XPath("//*[@id='ui-accordion-AssignOptions-header-2']/a");
        private By ddlAllCandidates = By.XPath("//div[@id='s2id_Candidates']/a/span");
        private By txtAllCandidates = By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active']/div/input");
        private By ddlSelectAllCandidates = By.XPath("//div[@class='select2-search']/following-sibling::ul/li[1]");
        private By btnAssignCandidate = By.XPath("//button[@value='Assign Candidate']");
        private By lnkMatchAssignedMsg = By.XPath("//div[contains(@id,'message')]/span[2]");
        private By imgNext = By.Id("ctl00_ctl00_cphMain_cphMain_rptTimeline_ctl04_imgNext");
        private By lnkAcceptMatch = By.XPath("//div[@class='widgetBody']/div[3]//div[contains(@id,'widget_statusadvance')]/img");
        private By btnAddNewPosition = By.Id("btnAddNewPosition");
        private By FrameManageContact = By.XPath("//iframe[contains(@id,'contact_manage')]");
        private By frameCompanyManage = By.XPath("//iframe[contains(@id,'company_manage')]");
        private By FramePosition = By.XPath("//iframe[contains(@id,'position_new')]");
        private By frameShift = By.XPath("//iframe[contains(@id,'shift_addshiftandposition')]");
        private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage')]");

        //ShiftDetails
        private By lnkshiftDetails = By.XPath("//div[contains(@data-tiptarget,'view_ShiftCalendar')]");
        private By lnkEditShift = By.XPath("//span[contains(@data-tipurl,'/Mvc/Shift/UpdateShiftData')]");
        private By txtEditShiftDescription = By.XPath("//div[contains(@id,'view_ShiftDataModel')]//input[@data-helptip='_Name']");
        private By btnSaveShiftDetails = By.XPath("//button[text()='Save' and @name='Command']");
        private By lblShiftSuccessMessage = By.XPath("//div[contains(text(),'Shift successfully changed.')]");
        private By btnRefresh = By.XPath("//div[contains(@id,'view_ShiftDetail')]//button[text()='Refresh']");
        private By lblShiftDescription = By.XPath("//strong[contains(text(),'Shift Description:')]/..");

        //Update shift details

        private By lnkUpdateStatus = By.XPath("//img[@src='https://previewrc.erecruit.com//Mvc/Content/Images/icons/statusicons/5.png']/..");
        private By ddlShiftStatus = By.XPath("//span[text()='Select Shift Status']");
        private By txtSearchShiftstatus = By.XPath("//div[@class='select2-search']//input[@data-helptip='_Status']");
        private By btnUpdateStatus = By.XPath("//button[contains(text(),'Update Status')]");
        private By successMsg = By.XPath("//div[contains(text(),'Shifts updated successfully.')]");//("//div[@class='widgetBody']//div[@class='messaging-container']/div/div");
        private By successMsg2 = By.XPath("//div[@id='DetailTab']//div[text()='End']");

        //DeleteShifts
        private By lnkDeleteShifts = By.XPath("//div[@class='cooltipmenuoption noclose']");
        //Position count 

        private By lnkPositionCount = By.XPath("//span[@id='PositionCount']");
        private By txtNewPositionTitle = By.XPath("//input[contains(@id,'cphMain_txtName')]");
        private By txtDate = By.XPath("//input[contains(@id,'cphMain_dpProjectedStartDate_dateInput')]");
        private By txtEstimatedDate = By.XPath(".//*[@id='ctl00_cphMain_dpProjectedStartDate_dateInput']");
        private By ddlPositionTypeNew = By.XPath("//input[contains(@id,'cphMain_ddlPosType_Input')]");

        private By ddnFolderGroup = By.XPath("//input[contains(@id,'ctl00_cphMain_ddlFolderGroups_Input')]");
        private By ddlPositionSourceNew = By.XPath("//input[@id='AdSourceDropdown_ddladsource']");
        private By addInfo = By.XPath("//input[@id='Text']");
        private By btnSavePosition = By.XPath(".//*[@id='ctl00_cphMain_btnSave']");
        private By framePosition = By.XPath("//iframe[contains(@id,'position_new_')]");
        private By bntRefreshCompany = By.XPath("//input[contains(@id,'cphMain_cphBottomButtons_btnRefresh_input')]");
        #endregion

        #region Public Methods
        public void AddPosition(string companyName, string positionType, string primaryDept, string folderGroup1, string positionTitle1, string contactName, string facilityDept, string positionOwner, string positionSource, string shiftType1, string shiftType2, string shiftDescription, string Month)
        {
            try
            {
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameShift);
                driver.SwitchToFrameByLocator(frameShift);
                driver.sleepTime(5000);
                driver.WaitElementPresent(txtCompany);
                driver.ClickElement(txtCompany, "Company");
                driver.SendKeysToElementAndPressEnter(ddlComapny, companyName, "Comapny Name");
                driver.sleepTime(5000);
                //driver.WaitElementExistsAndVisible(txtPositionType);
                driver.WaitElementPresent(txtPositionType);
                driver.ClickElement(txtPositionType, "Position Type");
                driver.SendKeysToElementAndPressEnter(ddlPositionType, positionType, "Position Type");
                //driver.sleepTime(20000);
                //driver.WaitElementExistsAndVisible(txtPrimaryDepartment);
                driver.WaitElementPresent(txtPrimaryDepartment);
                driver.ClickElement(txtPrimaryDepartment, "Primary Department");
                driver.SendKeysToElementAndPressEnter(ddlPrimaryDepartment, primaryDept, "Primary Department");

                driver.sleepTime(20000);
                //driver.WaitElementExistsAndVisible(txtFolderGroup);
                driver.WaitElementPresent(txtFolderGroup);
                driver.ClickElement(txtFolderGroup, "Folder Group");
                driver.SendKeysToElementAndPressEnter(ddlFolderGroup, folderGroup1, "Folder Group");
                driver.sleepTime(3000);
                // driver.sleepTime(20000);
                //driver.WaitElementExistsAndVisible(txtPositionTitle);
                driver.WaitElementPresent(txtPositionTitle);
                driver.SendKeysToElementClearFirst(txtPositionTitle, positionTitle1, "Position Title");

                //driver.WaitElementExistsAndVisible(txtContact);
                driver.WaitElementPresent(txtContact);
                driver.ClickElement(txtContact, "Contact");
                driver.SendKeysToElementAndPressEnter(ddlContact, contactName, "Contact");
                //driver.sleepTime(20000);
                //driver.WaitElementExistsAndVisible(txtFacilityDepartment);
                driver.WaitElementPresent(txtFacilityDepartment);
                driver.ClickElement(txtFacilityDepartment, "Facility Department");
                driver.SendKeysToElementAndPressEnter(ddlFacilityDepartment, facilityDept, "Facility Department");

                //driver.ClickElement(txtPositionOwner, "Position Owner");
                //driver.SendKeysToElementAndPressEnter(ddlPositionOwner, positionOwner, "Position Owner");
                // driver.sleepTime(20000);
                // driver.WaitElementExistsAndVisible(txtPositionSource);
                driver.WaitElementPresent(txtPositionSource);
                driver.ClickElement(txtPositionSource, "Position Source");
                driver.sleepTime(20000);
                driver.SendKeysToElementAndPressEnter(ddlFolderGroup, positionSource, "Position Source");
                driver.ScrollPage();

                DateTime now = DateTime.Now;
                string year = DateTime.Now.Year.ToString();
                driver.SelectCalenderDates(Month, year, "1,5");

                driver.EnterShiftDetails(1, shiftType1, shiftDescription, "09:00 AM", "05:00 PM");
                driver.EnterShiftDetails(2, shiftType2, shiftDescription, "09:00 AM", "08:00 PM");

                driver.ClickElement(btnSave, "Click on Save");
                driver.sleepTime(30000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("AddPosition", "Failed to Add Position", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyPositionWidget()
        {
            try
            {
                driver.VerifyWebElementPresent(txtPositionWidgetTitle, "Position Widget Title");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyPositionWidget", "Failed to Verify Position Widget", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickButtonAddPosition()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(FrameManageContact);
                driver.SwitchToFrameByLocator(FrameManageContact);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(btnAddNewPosition, "Add New Position button");
                driver.ClickElement(btnAddNewPosition, "Click Add New Position button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add New Position button", "Failed to Click Add New Position button", EngineSetup.GetScreenShotPath());
            }
        }
        public void ShiftAssignment()
        {
            try
            {
                var lnkTimesheetsearch = driver.FindElement(By.XPath(".//*[starts-with(@id,'view_ShiftCalendar')]/div/span[contains(.,'9:00a - 5:00p')]"));
                Actions act = new Actions(driver);
                act.ContextClick(lnkTimesheetsearch).Build().Perform();
                driver.VerifyWebElementPresent(lnkAssignCandidate,"Assign Candidate");
                driver.ClickElement(lnkAssignCandidate, "Assign Candidate");
                driver.ClickElement(lnkAllCandidates, "All Candidates");
                driver.ClickElement(ddlAllCandidates, "All Candidates dropdown");
                driver.SendKeysToElement(ddlComapny, AddCandidatePage.id, "Click on Candidates dropdown");
                driver.sleepTime(5000);
                driver.FindElement(ddlComapny).SendKeys(OpenQA.Selenium.Keys.Enter);
                //driver.WaitElementPresent(btnAssignCandidate);
                //driver.ClickElement(btnAssignCandidate, "Assign Candidate");
                //driver.WaitElementPresent(lnkMatchAssignedMsg);
                //driver.ClickElement(lnkMatchAssignedMsg, "Click on Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Shift Assignment", "Failed to Create Shift Assignment", EngineSetup.GetScreenShotPath());
            }
        }

        public void Matchtofullplacement()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByIndex(3);
                driver.sleepTime(5000);
                //driver.WaitElementPresent(imgNext);
                //driver.ClickElement(imgNext, "Next");
                //driver.WaitElementPresent(lnkAcceptMatch);
                //driver.ClickElement(lnkAcceptMatch, "Accept Match");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Match to Full Placement", "Failed to Accept Match tp full placement", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyPositionSuccefulMessage()
        {
            try
            {
                driver.sleepTime(5000);
                driver.VerifyWebElementPresent(lblSuccessMessage, "Success Message is displayed");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyPositionSuccessfulMessage", "Failed to Verify Position Succeful Message", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnPositionScheduling()
        {
            try
            {
                driver.sleepTime(5000);
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.sleepTime(5000);
               // driver.WaitElementPresent(lnkPositionScheduling);
                driver.ClickElement(lnkPositionScheduling, "Click on Position Scheduling");
                driver.sleepTime(25000);
                driver.WaitElementPresent(ttlPositionCalendar);
                driver.WaitElementPresent(txtShiftDates);
                driver.FindElement(By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnRefresh_input")).Click();               
                driver.sleepTime(10000);
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.sleepTime(5000);
                // driver.WaitElementPresent(lnkPositionScheduling);
                driver.ClickElement(lnkPositionScheduling, "Click on Position Scheduling");
                driver.sleepTime(25000);
                driver.WaitElementPresent(ttlPositionCalendar);
                driver.WaitElementPresent(txtShiftDates);
                driver.ClickElementWithJavascript(txtShiftDates, "Shift Dates");
                //driver.WaitElementPresent(txtShiftDates);
                //driver.VerifyWebElementPresent(txtShiftDates, "Shift Dates");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click On Position Scheduling", "Failed to Click On Position Scheduling", EngineSetup.GetScreenShotPath());
            }
        }

        public void EditShiftDetails()
        {
            try
            {
                driver.WaitElementPresent(txtShiftDates);
                driver.ClickElement(txtShiftDates, "Shift Details");
                driver.WaitElementPresent(txtShiftDates);
                driver.RightClickElement(txtShiftDates, "Shift Dates");
                driver.WaitElementPresent(lnkshiftDetails);
                driver.ClickElement(lnkshiftDetails, "Shift Details");
                driver.WaitElementPresent(lnkEditShift);
                driver.ClickElement(lnkEditShift, "Edit Shift Details");
                driver.SendKeysToElementClearFirst(txtEditShiftDescription, "Text Shift Description", "Shift Description");
                driver.WaitElementPresent(btnSaveShiftDetails);
                driver.ClickElement(btnSaveShiftDetails, "Save");
                driver.sleepTime(5000);
                driver.AssertTextContains(lblShiftSuccessMessage, "Shift successfully changed.");
                driver.WaitElementPresent(btnRefresh);
                driver.ClickElement(btnRefresh, "Refresh");
                driver.sleepTime(10000);
                driver.AssertTextContains(lblShiftDescription, "Text Shift Description");
            }
            catch (Exception Ex)
            {
               this.TESTREPORT.LogFailure("Edit Shift Details", "Failed to Edit Shift Details ", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Verify updated status of the shift dates
        /// </summary>
        /// 

        public void VerifyUpdatedStatus(string shiftStatus)
        {
            //driver.ClickElement(txtShiftDates, "Shifts Dates");
            driver.WaitElementPresent(txtShiftDates);
            driver.RightClickElement(txtShiftDates, "Shift Dates");
            driver.WaitElementPresent(lnkUpdateStatus);
            driver.ClickElement(lnkUpdateStatus, "Status Update");
            driver.ClickDropdownAndSearchText(ddlShiftStatus, txtSearchShiftstatus, shiftStatus, "Shift Details Update");
            driver.sleepTime(1000);
            driver.ClickElement(btnUpdateStatus, "Button Update");
            //driver.AssertTextEqual(successMsg, "Shifts updated successfully.");
            driver.sleepTime(10000);
            driver.WaitElementPresent(txtShiftDates);
            driver.ClickElement(txtShiftDates, "Shifts Dates");
            driver.sleepTime(5000);
            driver.RightClickElement(txtShiftDates, "Shift Dates");
            driver.ClickElement(lnkshiftDetails, "Shift Details");
            driver.sleepTime(10000);
           // driver.WaitElementPresent(successMsg2);
           //driver.AssertTextContains(successMsg2, shiftStatus);
            //driver.sleepTime(10000);
        }

        public void DeleteShifts()
        {
            driver.ClickElement(txtShiftDates, "Shifts Dates");
            driver.RightClickElement(txtShiftDates, "Shift Dates");
            driver.ClickElement(lnkDeleteShifts, "Delete Shifts");

            if (driver.isAlertPresent())
            {
                IAlert devAlert = driver.SwitchTo().Alert();
                devAlert.Accept();
            }
            driver.sleepTime(5000);
            driver.CheckElementDoesnotExists(txtShiftDates, "Shift Dates");
        }
        public void ClosePositionCalendarWidget()
        {
            try
            {
                driver.WaitElementPresent(btnClosePositionCalendar);
                driver.ClickElement(btnClosePositionCalendar, "Close Position Calendar");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClosePositionCalendarWidget", "Failed to Close Position Calendar Widget:", EngineSetup.GetScreenShotPath());
            }
        }

        public void CreatePositionFromComapny()
        {
            try
            {
                driver.sleepTime(10000);
                ClickButtonAddPosition();
                positionPage.CreatePosition("CompanyPosition", 1, 1, "");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("CreatePositionFromComapny", "Failed to Create Position From Comapny:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnContinueToPosition()
        {
            try
            {
                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkContinueToPosition);               
                driver.ClickElement(lnkContinueToPosition, "Continue to Position");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Continue to Position", "Failed to Click On Continue To Position link", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Adding position to company
        /// </summary>
        public string AddPositionToCompany(string positionName, string folderGroupForPosition, string estimatedDate, string dropDownPositionText, string positionSource, string additionalInfo)
        {
            string countPosition = "";

            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.WaitElementPresent(lnkPositionCount);
                countPosition = driver.GetElementText(lnkPositionCount);
                driver.VerifyWebElementPresent(btnAddNewPosition, "Add New Position button");
                driver.ClickElement(btnAddNewPosition, "Click Add New Position button");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(framePosition);
                driver.SwitchToFrameByLocator(framePosition);
                driver.SendKeysToElement(txtNewPositionTitle, positionName, "Position Title");
                driver.SendKeysToElementAndPressEnter(txtEstimatedDate, estimatedDate, "Enter Estimated Date");
                driver.ClickElementAndSendKeys(ddlPositionTypeNew, dropDownPositionText, "drop down");
                driver.WaitElementPresent(btnSavePosition);
                driver.ClickElementAndSendKeys(ddnFolderGroup, folderGroupForPosition, "Folder group");
                driver.FindElement(ddnFolderGroup).SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.ClickElementAndSendKeys(ddlPositionSourceNew, positionSource + OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "Position Source");
                driver.SendKeysToElement(addInfo, additionalInfo, "Additional information");
                driver.WaitElementPresent(btnSavePosition);
                driver.ClickElement(btnSavePosition, "Save button");
                driver.sleepTime(10000);              
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add Position To Company", "Failed to Add Position To Company", EngineSetup.GetScreenShotPath());
            }

            return countPosition;

        }
        /// <summary>
        /// Verify the count increase of the Position added to the company
        /// </summary>
        /// <param name="value"></param>
        public void VerifyPositionCount(string value)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(bntRefreshCompany);
                driver.ClickElement(bntRefreshCompany, "Refresh company button");
                driver.sleepTime(10000);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.WaitElementPresent(lnkPositionCount);
                string newCountPosition = driver.GetElementText(lnkPositionCount);
                var oldPositionCount = Convert.ToInt32(value);
                var newpositionCount = Convert.ToInt32(newCountPosition);
                if ((oldPositionCount + 1) == newpositionCount)
                {
                    this.TESTREPORT.LogSuccess("Position Count value", "Position count value is increased Successfully");
                }
                else
                {
                    this.TESTREPORT.LogFailure("Position Count value", "Position count value is not increased", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            { 
                this.TESTREPORT.LogFailure("Verify Position Count", "Failed to Verify Position Count", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickButtonAddPositionFromCompany()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameCompanyManage);
                driver.SwitchToFrameByLocator(frameCompanyManage);
                driver.ScrollPage();
                driver.VerifyWebElementPresent(btnAddNewPosition, "Add New Position button");
                driver.ClickElement(btnAddNewPosition, "Click Add New Position button");
                driver.sleepTime(10000);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Add New Position button", "Failed to Click Add New Position button", EngineSetup.GetScreenShotPath());
            }
        }


        #endregion

    }

}
