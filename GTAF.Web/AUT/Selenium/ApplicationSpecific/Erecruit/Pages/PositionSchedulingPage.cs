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
    public class PositionSchedulingPage : AbstractTemplatePage
    {

        HomePage home = new HomePage();

        #region Constructors
        public PositionSchedulingPage()
        {
        }

        public PositionSchedulingPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region UI Object Repository
        private By txtShiftDates = By.XPath(".//*[starts-with(@id,'view_ShiftCalendar')]/div/span[contains(.,'9:00a - 5:00p')]");
        private By lnkShiftDetail = By.XPath(".//div[starts-with(@data-tipurl,'/Mvc/Shift/ShiftDetail?')]");
        private By lnkAssignCandidate = By.XPath(".//div[starts-with(@data-tipurl,'/Mvc/Shift/Assign?')]");
        private By lnkEarmarkCandidates = By.XPath(".//div[starts-with(@data-tipurl,'/Mvc/Shift/Earmark?')]");
        private By lnkChangeStatus = By.XPath(".//div[starts-with(@data-tipurl,'/Mvc/Shift/Status?')]");
        private By lnkCloseCancelShifts = By.XPath(".//div[starts-with(@data-tipurl,'/Mvc/Shift/Cancellation?')]");
        private By lnkDeleteShifts = By.XPath(".//div[@onclick='deleteShifts();']");
        private By lnkAddANote = By.XPath(".//div[@data-tipsource='ManageScheduledItem, app/BL/ScheduledItem/ScheduledItem']");
        private By lblAssignCandidateTitle = By.XPath(".//*[@id='form0']/div/div[1]");
        private By btnAssignCandidate = By.XPath("//div[@class='widgetFooter'][1]/div/button[contains(., 'Assign Candidate')]");
        private By ddnAll = By.XPath(".//*[@id='ui-accordion-AssignOptions-header-2']/a[contains(., 'All')]");
        private By txtAllCandidates = By.XPath(".//*[@id='s2id_Candidates']/a/span");
        private By ddlAllCandidates = By.XPath("//div[contains(@class,'select2-drop-active')]/div/input"); //By.XPath("//div[@class='select2-drop select2-drop-active select2-with-searchbox select2-drop-above']/div/input"); //By.XPath("//div[@class='select2-drop select2-with-searchbox select2-drop-active select2-offscreen']/div/input");//By.XPath("//div[@id='s2id_Candidates']/div/div/input");//By.XPath("//div[@class='select2-drop select2-drop-active select2-with-searchbox select2-drop-above']/div/input");
        private By btnCloseAssignCandidate = By.XPath("//div[@class='t_Tooltip t_visible t_Tooltip_erecruitDefault t_hidden'][2]/div[5]/div/div[1]/canvas");
        private By lblCandidateName = By.XPath("//div[@class='fc-candidate-info']/span");
        //Right click on requirements
        private By lnkRequirements = By.XPath("//span[@data-tiprefid='5146406']//span[@id='RequirementCount']");
        private By lnkCandidateRequirements = By.XPath("//span[@id='RequirementCount']");
        private By frameManageCandidate = By.XPath("//iframe[contains(@id,'candidate_manage')]");
        private By lnkattach = By.XPath("//button[@class='btn btn-sm btn-link padding-none icon-attachment']");
        private By lnkAddNewAttachment = By.XPath("//a[contains(text(),'Add New Attachment')]");
        private By ddlAttachmnetType = By.XPath("//div[@id='ctl00_typePanel']//input[@class='ui-autocomplete-input']");
        private By btnAttachment = By.XPath("//span[contains(text(),'Add Attachment')]");
        private By headerCalendar = By.XPath("//div[contains(@id,'calendar')]/table/tbody//h2");
        private By framePositionManage = By.XPath("//iframe[contains(@id,'position_manage')]");
        private By lnkPositionScheduling = By.XPath("//*[@id='actions_section']//div[starts-with(@data-tipurl,'/MVC/Shift/Scheduling')]");
        private By ttlPositionCalendar = By.XPath("//*[starts-with(@id,'view_ShiftCalendar')]/div[2]/div[contains(.,'Position Calendar')]");

        private By txtSelectedDate = By.XPath("//div[contains(@id,'_Shift_')][1]/div");
        //Right click on Education History
        private By lnkEduHistory = By.XPath("//span[@title='Right click to manage education history']");
        //Right click on Work History
        private By btnMaximizeWorkHistory = By.XPath("//div[contains(text(),'Related')]//following-sibling::span");
        private By lnkWorkHistory = By.XPath("//span[@title='Right click to manage work history']");
        private By lnkClonePosition = By.XPath("//div[@id='ctl00_ctl00_cphMain_cphRightBar_divClonePosition']");
        private By lblPositionHeading = By.XPath("//h1[contains(text(),'Position - Contract Position')]");
        //Verify workView Tab
        private By btnWorkView = By.XPath("//button[text()='Work View']");
        private By frameObjectRequirement = By.XPath("//iframe[contains(@id,'objectrequirement_workview')]");
        private By lnkBackGroundCheck = By.XPath("//table[@id='candidatetable']//span[text()='Background Check'][1]");
        private By txtGenral = By.XPath("//label[text()='Status']");
        //private By txtHeading = By.XPath("//h4[text()='Background Check']");
        private By txtToWait = By.XPath("//h4[text()='General']");
        private By txtStatus = By.XPath("//h4[text()='General']//following-sibling::div//label[text()='Status']");
        private By btnAddAttachment = By.XPath("//button[text()='Add Attachment']");
        #endregion

        #region Public Methods
        public void RightClickOnAssignedDate()
        {
            try
            {
                driver.sleepTime(20000);
                var opt = driver.FindElement(By.XPath("//span[text()='9:00a - 5:00p']"));
                opt.Click();
                driver.sleepTime(5000);
                Actions act = new Actions(driver);
                act.ContextClick(opt).Build().Perform();

                driver.sleepTime(10000);
                driver.WaitElementPresent(lnkShiftDetail);
                //  driver.VerifyWebElementPresent(lnkShiftDetail,"Shift Detail");

                driver.WaitElementPresent(lnkAssignCandidate);
                //driver.sleepTime(1000);
                //driver.VerifyWebElementPresent(lnkEarmarkCandidates,"EarMark Candidates");
                driver.VerifyWebElementPresent(lnkChangeStatus, "Change Status");
                driver.VerifyWebElementPresent(lnkCloseCancelShifts, "Close Cancel Shifts");
                driver.VerifyWebElementPresent(lnkDeleteShifts, "Delete Shifts");
                driver.VerifyWebElementPresent(lnkAddANote, "Add a Note");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("RightClickOnAssignedDate", "Failed to Right click on Assigned Date:", EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        /// Right click on Requirements
        /// </summary>
        public void RightClickOnRequirements(string ddlType)
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                driver.ScrollPage();
                driver.ScrollPage();
                driver.ScrollPage();
                //var lnkRequirement = driver.FindElement(lnkRequirements);
                var lnkRequirement = driver.FindElement(By.XPath("//span[@title='Left click to view Requirements, right click to preview.']"));
                Actions act = new Actions(driver);
                act.ContextClick(lnkRequirement).Build().Perform();
                driver.sleepTime(20000);
                driver.WaitElementPresent(lnkattach);
                driver.ClickElement(lnkattach, "Link Attach");             
                driver.WaitElementPresent(btnAddAttachment);
                driver.ClickElement(btnAddAttachment, "Add Attachment button");
                //driver.ClickElement(lnkAddNewAttachment, "Link new attachment");
                driver.sleepTime(10000);
                driver.ClickElementAndSendKeys(ddlAttachmnetType, ddlType, "DropDown attachmnet type");
                driver.SendKeysToElement(ddlAttachmnetType, OpenQA.Selenium.Keys.Down + OpenQA.Selenium.Keys.Enter, "");
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAttachment);
                driver.ClickElement(btnAttachment, "Add Attachment button");
            }
            catch (Exception Ex)
            {
                this.TESTREPORT.LogFailure("RightClickOnRequiremnets", "Failed to Right click on Requirements:", EngineSetup.GetScreenShotPath());

            }
        }
        /// <summary>
        /// Right click on the requirements
        /// </summary>
        public void RightClickOnRequirement()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                driver.WaitElementPresent(frameManageCandidate);
                driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.sleepTime(5000);
                var lnkRequirement = driver.FindElement(lnkCandidateRequirements);
                driver.ScrollPage();
                Actions act = new Actions(driver);
                act.ContextClick(lnkRequirement).Build().Perform();
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnWorkView);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Right Click On Requirement", "Failed to Right Click On Requirement", EngineSetup.GetScreenShotPath());
            }
        }




        /// <summary>
        /// Verify the workview tab
        /// </summary>
        public void VerifyWorkViewTabAndValidate()
        {
            try
            {
                driver.CheckElementExists(btnWorkView, "Work view button");
                driver.WaitElementPresent(btnWorkView);
                driver.ClickElement(btnWorkView, "Work View button");
                driver.SwitchToDefaultFrame();
                driver.sleepTime(5000);
                // driver.SwitchToFrameByLocator(frameManageCandidate);
                driver.WaitElementPresent(frameObjectRequirement);
                driver.SwitchToFrameByLocator(frameObjectRequirement);
                driver.WaitElementPresent(lnkBackGroundCheck);
                driver.ClickElement(lnkBackGroundCheck, "BackGround Check");
                driver.sleepTime(2000);
                driver.WaitElementPresent(txtToWait);
                if (driver.ElementPresent(txtStatus, "Status"))
                    TESTREPORT.LogSuccess("Verify WorkView TabAndValidate", "Failed to Verify WorkView TabAndValidate:");
                else
                    TESTREPORT.LogFailure("Verify WorkView TabAndValidate", "Failed to Verify WorkView TabAndValidate:");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify WorkView TabAndValidate", "Failed to Verify WorkView TabAndValidate:", EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Right click on the Education history
        /// </summary>
        public void RightClickonEducationHistory()
        {
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.ScrollPage();
            driver.ScrollPage();
            driver.ScrollPage();
            driver.ScrollPage();
            driver.RightClickElement(lnkEduHistory, "Education History");
            driver.sleepTime(15000);
        }

        public void RightClickOnEducationHistory()
        {
            //driver.SwitchToDefaultFrame();
            //driver.SwitchToFrameByLocator(frameManageCandidate);
            driver.RightClickElement(lnkEduHistory, "Education History");
            driver.sleepTime(15000);

        }

        /// <summary>
        /// Right click on the work history
        /// </summary>
        public void RightClickonWorkHistory()
        {
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.SwitchToFrameByLocator(frameManageCandidate);
            // driver.ClickElement(btnMaximizeWorkHistory, "Maximize workHistory");
            driver.ScrollPage();
            driver.ScrollPage();
            driver.ScrollPage();
            driver.RightClickElement(lnkWorkHistory, "work history");
            //var lnkWorkHistoryVar = driver.FindElement(lnkWorkHistory);
            //Actions act = new Actions(driver);
            //act.ContextClick(lnkWorkHistoryVar).Build().Perform();
            driver.sleepTime(10000);
        }

        public void RighClickWorkHistoryWithoutMaximize()
        {
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.SwitchToFrameByLocator(frameManageCandidate);
            // driver.ClickElement(btnMaximizeWorkHistory, "Maximize workHistory");
            driver.ScrollPage();
            var lnkWorkHistoryVar = driver.FindElement(lnkWorkHistory);
            Actions act = new Actions(driver);
            act.ContextClick(lnkWorkHistoryVar).Build().Perform();
            driver.sleepTime(15000);

        }
        public void ClickOnShiftDetailLink()
        {
            try
            {
                driver.ClickElement(lnkShiftDetail, "Click on Shift Detail");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Shift Detail link", "Failed to Click on Shift Detail link:", EngineSetup.GetScreenShotPath());
            }
        }

        public void ClickOnAssignCandidateLink()
        {
            try
            {
                driver.ClickElement(lnkAssignCandidate, "Click on Assign Candidate");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Assign Candidate", "Failed to Click on Assign Candidate:", EngineSetup.GetScreenShotPath());
            }
        }

        public void AssignCandidate()
        {
            try
            {
                driver.IsElementPresent(lblAssignCandidateTitle);
                driver.ClickElement(ddnAll, "Click on All");
                driver.WaitElementPresent(txtAllCandidates);
                driver.ClickElement(txtAllCandidates, "Click on All Candidates dropdown");
                driver.WaitElementPresent(ddlAllCandidates);
                driver.SendKeysToElement(ddlAllCandidates, "Test", "Click on Candidates dropdown");
                driver.sleepTime(5000);
                driver.FindElement(ddlAllCandidates).SendKeys(OpenQA.Selenium.Keys.Enter);
                // driver.SendKeysToElementAndPressEnter(ddlAllCandidates, "Test", "Enter position");
                //var CandidateOptions = driver.FindElements(By.XPath("//div[@class='select2-drop select2-drop-active select2-with-searchbox']/ul"));
                //var Companyoptions = CandidateOptions.First().FindElements(By.TagName("li"));
                // CandidateOptions[0].Click();
                driver.sleepTime(10000);
                //driver.ClickElement(btnAssignCandidate, "Click on Assign Candidate button");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Click on Assign Candidate", "Failed to Click on Assign Candidate:", EngineSetup.GetScreenShotPath());
            }
        }

        public void CloseAssignCandidateWindow()
        {
            try
            {
                driver.ClickElement(btnCloseAssignCandidate, "Close Assign Candidate window");
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Close Assign Candidate window", "Failed to Close Assign Candidate window:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyAssignedCandidate()
        {
            try
            {
                driver.IsElementPresent(lblCandidateName);
            }

            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("VerifyAssignedCandidate", "Failed to Verify Assigned Candidate:", EngineSetup.GetScreenShotPath());
            }
        }

        public void VerifyCalenderMonth(string currentMonth)
        {
            try
            {
                driver.WaitElementPresent(headerCalendar);
                driver.VerifyWebElementPresent(headerCalendar, " Calendar header");
                string month = driver.FindElement(headerCalendar).Text;
                if (month.Contains(currentMonth))
                {
                    TESTREPORT.LogSuccess("Verify Calender Month", "Able to view current month in the Shift Calendar", EngineSetup.GetScreenShotPath());
                }
                else
                {
                    TESTREPORT.LogFailure("Verify Calender Month", "Failed to view current month in the Shift Calendar", EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Verify Calender Month", "Failed to Verify Calender Month", EngineSetup.GetScreenShotPath());
            }

        }

        public void PositionScheduling()
        {
            try
            {
                driver.SwitchToDefaultFrame();
                driver.sleepTime(10000);
              //  driver.WaitElementPresent(framePositionManage);
                driver.SwitchToFrameByLocator(framePositionManage);
                driver.ScrollPage();
                driver.WaitElementPresent(lnkPositionScheduling);
                driver.ClickElement(lnkPositionScheduling, "Click on Position Scheduling");
                driver.sleepTime(20000);
                driver.WaitElementPresent(ttlPositionCalendar);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Position Scheduling", "Failed to Click Position Scheduling", EngineSetup.GetScreenShotPath());
            }
        }
        public void VerifyCloneThisPosition(string positionId)
        {
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            driver.SwitchToFrameByLocator(framePositionManage);
            driver.ScrollToPageBottom();
            driver.ClickElement(lnkClonePosition, "Clone This Position");
            home.HandleAlert();
            driver.sleepTime(10000);
            CreatePositionPage positionPage = new CreatePositionPage();
            string newPositionId = positionPage.GetPositionTitle();
            try
            {
                driver.AssertTextNotMatching(positionId, newPositionId);
                TESTREPORT.LogSuccess("Verify CloneThisPosition", " Successfully created CloneThisPosition");
            }
            catch (Exception ex)
            {
                TESTREPORT.LogFailure("Verify CloneThisPosition", "Failed to create CloneThisPosition", EngineSetup.GetScreenShotPath());
            }
        }
        #endregion
    }
}
