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
    public class SearchMatchPage : AbstractTemplatePage
    {
        private By lnkTimesheetsinMatch = By.XPath("//div[@id='RecordCounts']//span[@id='TimesheetCount']");
        private By SubmittedStatus = By.XPath("//tr/td[9]//span[text()='0.00 %']");
        private By lnkTimesheet = By.XPath("//table[@class='k-selectable']//td[2]/a");
        private By btnAddTime = By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//td[1]//div[contains(@class,'widgetfooter text')]/button");
        private By txtStartTime = By.XPath("//td[1]//tr[@id='trStartEnd']//input[contains(@id,'_starttime')]");
        private By selectstartTimeHours = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[1]/table/tbody/tr[1]/td[1]");
        private By selectStartTimeMinutes = By.XPath("//div[@id='ui-timepicker-div']/ table/tbody/tr/td[2]/table/tbody/tr[1]/td[1]/a");
        private By txtEndTime = By.XPath("//td[1]//tr[@id='trStartEnd']//input[contains(@id,'_endtime')]");
        private By selectEndtimeHours = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[1]/table/tbody/tr[2]/td[2]/a");
        private By selectEndtimeMinutes = By.XPath("//div[@id='ui-timepicker-div']/table/tbody/tr/td[2]/table/tbody/tr[1]/td[1]/a");
        private By btnAdd = By.XPath("//div[contains(@id,'widget_day')]/div[2]//div[contains(@id,'_edit')]/div[2]//button[contains(@id,'_btnsaveadd')]");
        private By btnSubmit = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnSubmit_input");
        private By btnSubmitConfirm = By.XPath("//button[contains(@id,'widget_submittimesheet')][2]");
        private By btnApprove = By.Id("ctl00_ctl00_cphMain_cphBottomButtons_btnApprove_input");
        private By btnAddTimesheet=By.XPath("//table[@id='ctl00_ctl00_cphMain_cphMain_tblTimeDays']//tr[1]/td[1]//button[contains(@id,'btnadd')]");
        private By frameTimesheetManage = By.XPath("//iframe[contains(@id,'timesheet_manage')]");
        private By frameTimesheetByMatch = By.XPath("//iframe[contains(@id,'timesheet_By-Match')]");
        private By frameTimesheetByCompany = By.XPath("//iframe[contains(@id,'timesheet_By-Company')]");
        private By txtStartDate = By.XPath("//div[@id='ctl00_hpStartDate']/h5//following-sibling::input");
        private By btnSave = By.XPath("//span[text()='Save']");
        private By frameMatchManage = By.XPath("//iframe[contains(@id,'match_manage')]");
        private By btneditbutton = By.XPath("//div[contains(@id,'viewmode')]//div[@id='editbutton' and @data-tipname='match/general']");
        private By divPotential = By.XPath("//div/h5[text()='Potential Close Date']");
        #region Public Methods
        public void AddhoursTimesheetsearch()
        {
            try
            {
                driver.sleepTime(10000);
                // driver.SwitchToFrameByLocator(frameTimesheetByMatch);
                // driver.ClickElement(lnkTimesheet, "Click on timesheet");
                driver.SwitchToDefaultFrame();
                driver.WaitElementPresent(frameTimesheetManage);
                driver.SwitchToFrameByLocator(frameTimesheetManage);
                driver.sleepTime(5000);
                driver.WaitElementPresent(btnAddTimesheet);
                driver.ClickElement(btnAddTimesheet, "Add Time");
                driver.WaitElementPresent(txtStartTime);
                driver.ClickElement(txtStartTime, "Start Time Input");
                driver.WaitElementPresent(selectstartTimeHours);
                driver.ClickElement(selectstartTimeHours, "Select Time");
                driver.ClickElement(selectStartTimeMinutes, "Select Time");
                driver.WaitElementPresent(txtEndTime);
                driver.ClickElement(txtEndTime, "End time input");
                driver.WaitElementPresent(selectEndtimeHours);
                driver.ClickElement(selectEndtimeHours, "End Time");
                driver.ClickElement(selectStartTimeMinutes, "End Time");
                driver.sleepTime(10000);
                driver.ClickElementWithJavascript(btnAdd, "Addhours");

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Clickon Timesheet", "Failed to navigate to Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ClickonTimesheetlink()
        {
            try
            {
                driver.SwitchToFrameByLocator(frameTimesheetByCompany);
                driver.ScrollPage();                
                driver.ClickElementWithJavascript(lnkTimesheetsinMatch, "Timesheet");
                driver.SwitchToDefaultFrame();
            }
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Clickon Timesheet", "Failed to navigate to Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        public void SubmitTimesheetrecord()
        {
            try
            {
                driver.ClickElement(btnSubmit, "Submit");
                driver.ClickElement(btnSubmitConfirm, "Confirm Leave Submit");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Clickon Timesheet", "Failed to navigate to Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        public void ApproveTimesheetrecord()
        {
            try
            {
                driver.ClickElement(btnApprove, "Approve");
                driver.sleepTime(5000);

            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("Clickon Timesheet", "Failed to navigate to Timesheet:", EngineSetup.GetScreenShotPath());
            }
        }
        
        public void EnterStartDate(string startdate)
        {
            try
            {
                driver.WaitElementPresent(frameMatchManage);
                driver.SwitchToFrameByLocator(frameMatchManage);
                driver.MouseHover(divPotential, "Hover the Potential to view Edit button");
                driver.WaitElementPresent(btneditbutton);
                driver.ClickElementWithJavascript(btneditbutton, "Click Edit Button");
                driver.sleepTime(1000);
                driver.SendKeysToElementClearFirst(txtStartDate, startdate, "Enter Start Date");
                driver.WaitElementPresent(btnSave);
                driver.ClickElement(btnSave, "Save Button");
                driver.sleepTime(1000);
                By by = By.XPath("//div[contains(@id,'widget_general')]//div[2]/div[2]/div/..//div[2]/div");
                driver.WaitElementPresent(by);
                driver.sleepTime(10000);
                string date = driver.FindElement(by).Text;
                driver.sleepTime(5000);
                if(date.Contains(startdate))
                    this.TESTREPORT.LogSuccess("Start Date Value", "Start Date Value has been Changed successfully ");
                else
                    this.TESTREPORT.LogFailure("Start Date Value", "Failed to Change Start Date Value");
}
            catch(Exception ex)
            {
                this.TESTREPORT.LogFailure("Enter Start Date", "Failed to enter start date:", EngineSetup.GetScreenShotPath());
            }
        }
        #endregion
    }
}
