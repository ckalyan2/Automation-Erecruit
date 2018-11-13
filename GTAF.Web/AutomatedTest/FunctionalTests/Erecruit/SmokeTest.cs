using System;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.Erecruit.Pages;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AutomatedTest.FunctionalTests.Erecruit;
using System.Diagnostics;
using System.Configuration;
using Engine.TestRail;//using static AUT.Selenium.ApplicationSpecific.MAW.Pages.UserTransaction;
using Engine.UIHandlers.Selenium;
using StandardUtilities;

namespace AutomatedTest.FunctionalTests.Erecruit
{
    [TestClass]
    public class SmokeTest : TestBaseTemplate
    {
        #region constants & fields
        private const string FILETESTCONFIGURATION = "TestConfiguration.properties";
        /// <summary>
        /// URL
        /// </summary>
        private static string webURL = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "appUrl");
        /// <summary>
        /// Vendor Manager User Name
        /// </summary>
        private static string vendorManagerUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorManagerUserName");
        /// <summary>
        /// Recruiter User Name
        /// </summary>
        private static string recruiterUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "recruiterUserName");
        /// <summary>
        /// Recruiter Password
        /// </summary>
        private static string recruiterPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "recruiterPassword");
        /// <summary>
        /// Vendor Manager User Password
        /// </summary>
        private static string vendorManagerUserPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorManagerPassword");
        /// <summary>
        /// Vendor Contact User Name
        /// </summary>
        private static string vendorContactName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorContactName");
        /// <summary>
        /// Vendor Contact User Password
        /// </summary>
        private static string vendorContactPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorContactPassword");
        ///// <summary>
        ///// Candidate User Name
        ///// </summary>
        //private static string candidateUserName = ConfigurationManager.AppSettings["CandidateUserName"];

        ///// <summary>
        ///// Candidate Password
        ///// </summary>
        //private static string candidatePassword = ConfigurationManager.AppSettings["CandidatePassword"];
        /// candidate User Name
        /// </summary>
        private static string CandidateUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidateusername");
        /// <summary>
        /// Vendor Contact User Password
        /// </summary>
        private static string CandidatePassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidatepassword");

        #endregion

        #region constructor
        public SmokeTest()
        {
            //string vendorContact = ConfigurationManager.AppSettings["VendorManagerUserNameAndPassword"];
            //string vendorManagerUser = vendorManagerUserName;
        }
        #endregion

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281115_Verify_Recruiter_Login_With_Valid_Credentials()
        {
            #region TC_C281115_Verify_Recruiter_Login_With_Valid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281115_Verify_Recruiter_Login_With_Valid_Credentials", "Verify Login with valid Credentials");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.VerifyLogin();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281115", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion          
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281114_Add_Candidate_Without_Resume()
        {
            #region TC_WEB_Add_Candidate_Without_Resume
            this.TESTREPORT.InitTestCase("TC_C281114_WEB_Add_Candidate_Without_Resume", "Add New Candidate Without Resume");
            #endregion
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281114", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281114", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281114", "SearchName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281114", "FolderGroupId"));
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281114", "TaskName");
            string note = ExcelOperations.GetCellValueFromExcel("TCIdC281114", "NoteName");
            int id = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281114", "FrameId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //candidate.ClickonTagsEdit(id);
            //candidate.AddNote(task, note);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281114", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281330_Verify_Recruiter_Saves_Current_Search()
        {
            #region TC_C281330_Verify_Recruiter_Saves_Current_Search
            this.TESTREPORT.InitTestCase("TC_C281330_Verify_Recruiter_Saves_Current_Search", "Recruiter Saves Current Search");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281330", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281330", "SearchName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnCandidate();
            search.ClickOnSavedSearches();
            search.SearchElementsDisplayed();
            //search.EnterSearchName(searchname);          
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281330", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281366_Verify_Add_Note()
        {
            //AddCandidatePage candidate1 = new AddCandidatePage();           
            #region TC_C281366_Verify_Add_Note
            this.TESTREPORT.InitTestCase("TC_C281366_Verify_Add_Note", "Verify Add Note");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281366", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281366", "MailID");
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281366", "TaskName");
            string note = ExcelOperations.GetCellValueFromExcel("TCIdC281366", "NoteName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281366", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);            
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //string ID = AddCandidatePage.id;
            //driver.SwitchToDefaultFrame();
            //home.SearchCandidate(ID);
            candidate.AddNote(task, note);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281366", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281367_Verify_Add_Schedule_Item()
        {
            #region TC_C281367_Verify_Add_Schedule_Item
            this.TESTREPORT.InitTestCase("TC_C281367_Verify_Add_Schedule_Item", "Verify Add Schedule Item");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281367", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281367", "MailID");
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281367", "TaskName");
            string schedule = ExcelOperations.GetCellValueFromExcel("TCIdC281367", "ScheduleName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281367", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup,mailID);
            //string ID = AddCandidatePage.id;
            //home.SearchCandidate(ID);
            //search.ClickOnCandidateLink();
            candidate.AddSchedule(task, schedule);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281367", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281368_Verify_Add_Task()
        {
            #region TC_C281368_Verify_Add_Task
            this.TESTREPORT.InitTestCase("TC_C281368_Verify_Add_Task", "Verify Add Task");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281368", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281368", "MailID");
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281368", "TaskName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281368", "FolderGroupId"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //string ID = AddCandidatePage.id;
            //driver.SwitchToDefaultFrame();
            //home.SearchCandidate(ID);            
            candidate.AddTask(task);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281368", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281147_SearchWithValid_PositionId()
        {
            #region TC_C281147_SearchWithValid_PositionId
            this.TESTREPORT.InitTestCase("TC_C281147_WEB_SearchWithValid_PositionId", "Search With Valid Position id");
            #endregion
            #region TestData
            string Id = ExcelOperations.GetCellValueFromExcel("TCIdC281147", "PositionId");
            #endregion
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.NavigateToPositionvendor(Id);
            searchposition.CheckPosition();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281147", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281161_Add_Company_VendorManager()
        {
            #region TC_C281161_Add_Company
            this.TESTREPORT.InitTestCase("TC_C281161_Add_Company", "Add New Company");
            #endregion
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "City");
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "PostalCode");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281161", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(candidateName, city, PostalCode, email, url, PhoneNumber);
            home.Logout();
            home.HandleAlert();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281161", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281160_Add_Vendor()
        {
            #region TC_C281160_Add_Vendor
            this.TESTREPORT.InitTestCase("TC_C281160_WEB_Add_Vendor", "Add New Vendor");
            #endregion
            string vendorname = ExcelOperations.GetCellValueFromExcel("TCIdC281160", "Vendor");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddvendor();
            vendor.AddNewVendor(vendorname);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281160", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281162_Add_Contact_VendorManager()
        {
            #region TC_C281162_Add_Contact
            this.TESTREPORT.InitTestCase("TC_C281162_Add_Contact_VendorManager", "Add New Contact from Vendor Manager");
            #endregion
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281162", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281162", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281162", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281162", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281162", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281162", "FolderGroupId"));
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281162", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281101_Verify_AddContact()
        {

            #region TC_C281101_Verify_AddContact
            this.TESTREPORT.InitTestCase("TC_C281101_Verify_AddContact", "Add New Contact as Recruiter");
            #endregion
            
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281101", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281101", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281101", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281101", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281101", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281101", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281101", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281112_Verify_ManageLoginAccess_Contact()
        {
            #region TC_C281112_Verify_ManageLoginAccess
            this.TESTREPORT.InitTestCase("TC_C281112_WEB_Verify_ManageLoginAccess", "Manage Login Access Using Recruiter");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281112", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281112", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281112", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281112", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281112", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281112", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281112", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281113_Verify_GiveAccess_Contact()
        {
            #region TC_C281113_Verify_GiveAccess
            this.TESTREPORT.InitTestCase("TC_C281113_WEB_Verify_GiveAccess", "Verify Give Access through Contact");
            #endregion
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281113", "FolderGroupId"));
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "ActionStatusG");
            string currentpassword = ExcelOperations.GetCellValueFromExcel("TCIdC281113", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.GiveAccess(currentpassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281113", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281196_Verify_QuickAddhours_Timesheetprocess()
        {
            #region TC_C281196_Verify_QuickAddhours_Timesheetprocess
            this.TESTREPORT.InitTestCase("TC_C281196_Verify_QuickAddhours_Timesheetprocess", "Verify Quick Add hours from TimeSheet Processing");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.TimeProcessSheets();
            accounting.TimeSheetProcess();
            accounting.AddhoursthroughTimesheet();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281196", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            this.TESTREPORT.UpdateTestCaseStatus();
            #endregion
        }
        //[TestMethod]
        //[TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        //public void TC_C281197_Verify_Submithours_Timesheetprocessing()

        //[TestMethod]
        //[TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        //public void TC_C281196_Verify_QuickAddhours_Timesheetprocess()
        //{
        //    #region TC_C281196_Verify_QuickAddhours_Timesheetprocess
        //    this.TESTREPORT.InitTestCase("TC_C281196_Verify_QuickAddhours_Timesheetprocess", "Verify Quick Add hours from TimeSheet Processing");
        //    home.Login(webURL, recruiterUserName, recruiterPassword);
        //    home.ClickOnLogoMenu();
        //    home.TimeProcessSheets();
        //    accounting.TimeSheetProcess();
        //    accounting.AddhoursthroughTimesheet();
        //    home.Logout();
        //    home.HandleAlert();
        //    #region Test Rail Integration
        //    string status = TestRailIntegration.PublishResultsToTestRail("C281196", this.TESTREPORT.GetCurrentStatus());
        //    if (status != "")
        //        this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
        //    else
        //        this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
        //    #endregion

        //    #endregion
        //}
        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281197_Verify_Submithours_Timesheetprocessing()
        {
            #region TC_C281197_Verify_Submithours_Timesheetprocessing
            this.TESTREPORT.InitTestCase("TC_C281197_WEB_Verify_Submithours_Timesheetprocessing", "Verify Submit hours through Timesheet Processing");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.TimeProcessSheets();
            accounting.TimeSheetProcess();
            accounting.SubmitTimesheet();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281197", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            this.TESTREPORT.UpdateTestCaseStatus();
            #endregion
        }
        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281198_Verify_Approvehours_Timesheetprocessing()
        {
            #region TC_C281198_WEB_Verify_Approvehours_Timesheetprocessing
            this.TESTREPORT.InitTestCase("TC_C281198_WEB_Verify_Approvehours_Timesheetprocessing", "Approve from Timesheet Processing");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.TimeProcessSheets();
            accounting.TimeSheetProcess();
            accounting.ApproveTimesheet();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281198", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            this.TESTREPORT.UpdateTestCaseStatus();
            #endregion
        }
    //    {
    //        #region TC_C281197_Verify_Submithours_Timesheetprocessing
    //        this.TESTREPORT.InitTestCase("TC_C281197_WEB_Verify_Submithours_Timesheetprocessing", "Verify Submit hours through Timesheet Processing");
    //        home.Login(webURL, recruiterUserName, recruiterPassword);
    //        home.ClickOnLogoMenu();
    //        home.TimeProcessSheets();
    //        accounting.TimeSheetProcess();
    //        accounting.SubmitTimesheet();
    //        home.Logout();
    //        home.HandleAlert();
    //        #region Test Rail Integration
    //        string status = TestRailIntegration.PublishResultsToTestRail("C281197", this.TESTREPORT.GetCurrentStatus());
    //        if (status != "")
    //            this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
    //        else
    //            this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
    //        #endregion

    //        #endregion
    //    }
    //[TestMethod]
    //[TestCategory("Recruiter")]
    ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
    //public void TC_C281198_Verify_Approvehours_Timesheetprocessing()
    //{
    //    #region TC_C281198_WEB_Verify_Approvehours_Timesheetprocessing
    //    this.TESTREPORT.InitTestCase("TC_C281198_WEB_Verify_Approvehours_Timesheetprocessing", "Approve from Timesheet Processing");
    //    home.Login(webURL, recruiterUserName, recruiterPassword);
    //    home.ClickOnLogoMenu();
    //    home.TimeProcessSheets();
    //    accounting.TimeSheetProcess();
    //    accounting.ApproveTimesheet();
    //    home.Logout();
    //    home.HandleAlert();
    //    #region Test Rail Integration
    //    string status = TestRailIntegration.PublishResultsToTestRail("C281198", this.TESTREPORT.GetCurrentStatus());
    //    if (status != "")
    //        this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
    //    else
    //        this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
    //    #endregion

    //    #endregion
    //}

    [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281378_Verify_Add_Company()
        {
            #region TC_C281378_Verify_Add_Company
            this.TESTREPORT.InitTestCase("TC_C281378_Verify_Add_Company", "Verify Add Company");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "City");
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "PostalCode");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281378", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(candidateName, city, PostalCode, email, url, PhoneNumber);
            //company.AddCompany("Automation Company");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281378", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281186_QuickAddhours_Timesheet_Search()
        {
            #region TC_C281186_QuickAddhours_Timesheet_Search
            this.TESTREPORT.InitTestCase("TC_C281186_QuickAddhours_Timesheet_Search", "Verify Quick Add hours from timesheet search");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281186", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281186", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281186", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281186", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "",false,true,false,false,true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            // accounting.AddFilters();
            accounting.TimesheetSearch(timesheetid);
            accounting.AddHoursthroughTimesheetbysearch();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281186", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281246_Verify_Add_Requirement()
        {
            #region TC_C281246_Verify_Add_Requirement
            this.TESTREPORT.InitTestCase("TC_C281246_Verify_Add_Requirement", "Verify Add Requirement");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281246", "RequirementName");
            string reqtype = ExcelOperations.GetCellValueFromExcel("TCIdC281246", "RequirementType");
            string reqtarget = ExcelOperations.GetCellValueFromExcel("TCIdC281246", "RequirementTarget");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC281246", "RequirementWeight");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.AddNewRequirement(req, reqtype, reqtarget, reqweight);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281246", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281247_Verify_Edit_Requirement()
        {
            #region TC_C281247_Verify_Edit_Requirement
            this.TESTREPORT.InitTestCase("TC_C281247_Verify_Edit_Requirement", "Verify Edit Requirement");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281247", "RequirementName");
            string requirementname = ExcelOperations.GetCellValueFromExcel("TCIdC281247", "EditRequirementName");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC281247", "RequirementWeight");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.EditRequirement(req, reqweight, "",requirementname);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281247", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281163_Verify_VendorManager_Login_With_Valid_Credentials()
        {
            #region TC_C281163_Verify_VendorManager_Login_With_Valid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281163_Verify_VendorManager_Login_With_Valid_Credentials", "Verify Login with valid Credentials");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.VerifyLogin();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281163", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281267_Verify_Create_Quick_Match()
        {
            #region TC_C281267_Verify_Create_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C281267_Verify_Create_Quick_Match", "Verify Create Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281267", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281267", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC281267", "PreviousDate");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candid = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreateContractPosition(companyName, foldergroup);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            home.ClickOnQuick();
            matchPage.VerifyMatchWithoutCandStatus(positionID, candid);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281267", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281331_Verify_Recruiter_Shared_Searches()
        {
            #region TC_C281331_Verify_Recruiter_Shared_Searches
            this.TESTREPORT.InitTestCase("TC_C281331_Verify_Recruiter_Shared_Searches", "Recruiter Shared Searches");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281330", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281330", "SearchName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnCandidate();
            search.ClickOnSavedSearches();
            search.SearchElementsDisplayed();
            //search.EnterSearchName(searchname);
            //search.VerifySearchNameInSearchList(searchname);           
            //search.EnterPeople();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281331", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281200_EnterTime_on_Timesheetrecord()

        {
            #region TC_EnterTime_on_Timesheetrecord
            this.TESTREPORT.InitTestCase("TC_C281200_EnterTime_on_Timesheetrecord", "Enter Time on Timesheet record");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281200", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281200", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281200", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281200", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");
            matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281200", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281201_Submit_from_Timesheetrecord()
        {
            #region TC_C281201_WEB_Submit_from_Timesheetrecord
            this.TESTREPORT.InitTestCase("TC_C281201_WEB_Submit_from_Timesheetrecord", "submit Time on Timesheet record");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281201", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281201", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281201", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281201", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");

            matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            Match.SubmitTimesheetrecord();
            home.Logout();
            home.HandleAlert();
            driver.AcceptAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281201", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281237_Verify_Add_Position_Simple()
        {
            #region TC_C281290_Verify_Add_Position_Simple
            this.TESTREPORT.InitTestCase("TC_C281290_Verify_Add_Position_Simple", "Verify Add Position(simple)");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281237", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281237", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281234_Verify_Shift_Calendar()
        {
            #region TC_C281234_Verify_Shift_Calendar
            this.TESTREPORT.InitTestCase("TC_C281234_Verify_Shift_Calendar", "Verify Recruiter Shift Calendar");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281234", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            string id = positionPage.GetPositionTitle();
            //home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            position.ClosePositionCalendarWidget();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281234", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281236_Verify_Assign_Candidate()
        {
            #region TC_C281236_Verify_Assign_Candidate
            this.TESTREPORT.InitTestCase("TC_C281236_Verify_Assign_Candidate", "Verify Assign Candidate");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281236", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            driver.sleepTime(10000);
            string id = positionPage.GetPositionTitle();
            home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            schedulingPage.RightClickOnAssignedDate();
            schedulingPage.ClickOnAssignCandidateLink();
            schedulingPage.AssignCandidate();
            schedulingPage.CloseAssignCandidateWindow();
            schedulingPage.VerifyAssignedCandidate();
            position.ClosePositionCalendarWidget();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281236", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281280_Verify_Create_Permanent_Position()
        {
            #region TC_C281280_Verify_Create_Permanent_Position
            this.TESTREPORT.InitTestCase("TC_C281280_Verify_Create_Permanent_Position", "Verify Create Permanent Position");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "InitialStatus");         
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "BillRate");
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "CandidateSearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "Postalcode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281280", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281280", "AvailableId"));
            //string folderGroupIndex =ExcelOperations.GetCellValueFromExcel("TCIdC281280", "AvailableId");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281280", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            string positionSearchname = ExcelOperations.GetCellValueFromExcel("TCIdC281280", "PositionSearchName");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281280", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            string candidateID = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            //home.NavigateToAddPosition();
            //searchposition.ClickOnPositionLink();
            position.ClickButtonAddPosition();
            positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, true);
            positionPage.VerifyPositionTitle();
            string id = positionPage.GetPositionTitle();
            home.SearchPosition(id);
            positionPage.VerifyPositionTitle();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281280", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        //[TestMethod]
        //[TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        //public void TC_C281181_Verify_VendorManager_Add_Widgets()
        //{
        //    #region TC_C281181_Verify_Add_Widgets
        //    this.TESTREPORT.InitTestCase("TC_C281181_Verify_Add_Widgets", "Verify Add Widgets");
        //    home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
        //    dashboard.ClickOnModifyDashboard();
        //    dashboard.SelectWidgetAndZoneForVendorManager();
        //    dashboard.ClickOnAddWidgetButton();
        //    dashboard.VerifyAddWidget();
        //    dashboard.ClickOnSubmit();
        //    dashboard.VerifyAddWidget();
        //    home.Logout();
        //    home.HandleAlert();
        //    #region Test Rail Integration
        //    string status = TestRailIntegration.PublishResultsToTestRail("C281181", this.TESTREPORT.GetCurrentStatus());
        //    if (status != "")
        //        this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
        //    else
        //        this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
        //    #endregion
        //    this.TESTREPORT.UpdateTestCaseStatus();
        //    #endregion
        //}

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281265_Verify_Creating_New_Contract_Match_Full_Placement()
        {
            #region TC_C281265_Verify_Creating_New_Contract_Match_Full_Placement
            this.TESTREPORT.InitTestCase("TC_C281265_Verify_Creating_New_Contract_Match_Full_Placement", "Verify_Creating_New_Contract_Match_Full_Placement");

            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281265", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));

            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');

            #endregion
            #region Recruiter
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281265", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281265", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281265", "AvailableId"));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate,positionFolder,statusId, "");
            home.Logout();
            home.HandleAlert();
            #endregion
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281265", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281222_Verify_Add_New_Timesheet_LogoMenu()
        {
            #region TC_C281222_Verify_Add_New_Timesheet_LogoMenu
            this.TESTREPORT.InitTestCase("TC_C281222_Verify_Add_New_Timesheet_LogoMenu", "Verify Add New Timesheet From Logo Menu");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281222", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281222", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281222", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281222", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate,positionFolder,statusId, "");
            matchPage.CreateTimesheets(matchId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281222", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281238_Verify_Create_Match_Shift_Assignment()
        {
            #region TC_C281238_Verify_Create_Match_Shift_Assignment
            this.TESTREPORT.InitTestCase("TC_C281238_Verify_Create_Match_Shift_Assignment", "Verify Create Match through Shift Assignment");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281238", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));            
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281238", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.VerifyPositionSuccefulMessage();
            position.ClickOnContinueToPosition();
            position.ClickOnPositionScheduling();
            //candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            position.ShiftAssignment();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281238", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281239_Verify_Move_Match_FullPlacement_Shift_Assignment()
        {
            #region TC_C281239_WEB_Verify_Move_Match_FullPlacement_Shift_Assignment
            this.TESTREPORT.InitTestCase("TC_C281239_WEB_Verify_Move_Match_FullPlacement_Shift_Assignment", "Verify Create Match through Shift Assignment");
            #region Test Data 
            //TCIdC281239
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "SearchName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281239", "FolderGroupId"));
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281239","TaskName");
            string note = ExcelOperations.GetCellValueFromExcel("TCIdC281239", "NoteName");
            int id = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281239", "Frameid"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281239", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            candidate.UpdateCandidateStatus(statusId);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.VerifyPositionSuccefulMessage();
            position.ClickOnContinueToPosition();
            position.ClickOnPositionScheduling();
            position.ShiftAssignment();
            position.Matchtofullplacement();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281239", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281231_Verify_Add_Credentialing_Request_Candidate_Record()
        {
            #region TC_Verify_Add_Credentialing_Request_Candidate_Record
            this.TESTREPORT.InitTestCase("TC_C281231_Verify_Add_Credentialing_Request_Candidate_Record", "Verify Add Credentialing Request Candidate Record");
            //#region Test Data
            //string candidate = ExcelOperations.GetCellValueFromExcel("TCIdC281231", "CredentialCandidate");
            //string facility = ExcelOperations.GetCellValueFromExcel("TCIdC281231", "Facility");
            //string position = ExcelOperations.GetCellValueFromExcel("TCIdC281231", "Position");
            //#endregion
            //home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.SearchCandidate(candidate);
            //search.AddCredentialRequest(facility, position);
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "MailID");
            string departmentValue = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "DepartmentValue");
            string classification = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "Classification");
            string tier = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "Tier");
            string ptype = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "Ptype");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281232", "FolderGroupId"));
            string folderGroupValue = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "FolderGroup");
            string company = ExcelOperations.GetCellValueFromExcel("TCIdC281232", "CompanyName1");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.Clickonclose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateId();
            search.AddCredentialingRequest(departmentValue, ptype, folderGroupValue, company);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281231", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281277_Verify_Mandatory_Validation_Checks_in_Advance_Match_Timeline()
        {
            #region TC_C281277_Verify_Mandatory_Validation_Checks_in_Advance_Match_Timeline
            this.TESTREPORT.InitTestCase("TC_C281277_Verify_Mandatory_Validation_Checks_in_Advance_Match_Timeline", "Verify Mandatory Validation Checks in Advance Match Timeline");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "RequirementName");
            string reqtype = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "RequirementType");
            string reqtarget = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "RequirementTarget");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "RequirementWeight");
            //string candidate = ExcelOperations.GetCellValueFromExcel("CredentialCandidate");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281277", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281277", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281277", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281277", "AvailableId"));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            string requirement = home.AddNewRequirement(req, reqtype, reqtarget, reqweight);
            driver.SwitchToDefaultFrame();
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281277", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281266_Verify_Convert_Contract_Match_to_Permanent_Match()
        {
            #region TC_C281266_Verify_Convert_Contract_Match_to_Permanent_Match
            this.TESTREPORT.InitTestCase("TC_C281266_Verify_Convert_Contract_Match_to_Permanent_Match", "Verify Quick search box with atleast 2 Words (combination of alphabets and dot)");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281266", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281266", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281266", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281266", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate,positionFolder,statusId, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281266", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion

        }

        //[TestMethod]
        //[TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        //public void TC_AddPosition_150()
        //{
        //    #region TC_AddPosition_150
        //    this.TESTREPORT.InitTestCase("TC_AddPosition_150", "Verify Logo Menu");
        //    home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);

        //    timesheet.AddPosition_Temp();

        //    home.Logout();
        //    
        //    #endregion
        //}

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281199_Verify_Create_Timesheet_LogoMenu_TimeandExpenses_Enabled()
        {
            #region TC_C281199_Verify_Create_Timesheet_LogoMenu_TimeandExpenses_Enabled
            this.TESTREPORT.InitTestCase("TC_C281199_Verify_Create_Timesheet_LogoMenu_TimeandExpenses_Enabled", "Verify Add New Timesheet From Logo Menu with Time and Expenses Enabled");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281199", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281199", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281199", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281199", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281199", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281221_Timesheet_Creation_Automatically_Accounting_Approval()
        {
            #region TC_C281221_Timesheet_Creation_Automatically_Accounting_Approval
            this.TESTREPORT.InitTestCase("TC_C281221_Timesheet_Creation_Automatically_Accounting_Approval", "Creation of Timesheets option Automatically on Accounting Approval");

            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281221", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "Website");
            string connection = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "Connection");
            string command = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "Command");
            //  Database.ExecuteSqlCommand(connection, command);
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281221", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281221", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281221", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate,positionFolder,statusId, "");

            home.Logout();
            home.HandleAlert();
            #region testrail
            string status = TestRailIntegration.PublishResultsToTestRail("C281221", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281443_Verify_Recruiter_Generate_Document_PDF()
        {
            string pdfDoc = "true";
            #region TC_281443_Verify_Recruiter_Generate_Document_PDF
            this.TESTREPORT.InitTestCase("TC_WEB_281443_Verify_Recruiter_Generate_Document_PDF", "Verify that the Recruiter Generate Document in PDF format");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281443", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281443", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281443", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281443", "AvailableId"));
            //string pdfDoc = "false";
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            matchPage.GenerateDocument(pdfDoc);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281443", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281384_Verify_Dashboard_In_IE11_Browser()
        {
            #region TC_C281384_Verify_Dashboard_In_IE11_Browser
            this.TESTREPORT.InitTestCase("TC_C281384_Verify_Dashboard_In_IE11_Browser", "Verify Dashboard In IE11 Browser");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.VerifyLogin();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281384", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281444_Verify_Creating_New_Quick_Match()
        {
            #region TC_C281444_Verify_Creating_New_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C281444 Verify Creating New Quick Match", "Verify Creating New Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "BillRate");
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281444","CandidateSearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "Postalcode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281444", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281444", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281444", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281444", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281444", "AvailableId"));
            string companyIdAndName = string.Empty;
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName,foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate,false,true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281444", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281202_Approve_from_Timesheetrecord()
        {
            #region TC_C281202_WEB_Approve_from_Timesheetrecord
            this.TESTREPORT.InitTestCase("TC_C281202_WEB_Approve_from_Timesheetrecord", "Approve from Timesheet Record");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281202", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "Website");
            string connection = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "Connection");
            string command = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "Command");
            //  Database.ExecuteSqlCommand(connection, command);
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281202", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281202", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281202", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate, positionFolder,statusId,"");
            matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            Match.SubmitTimesheetrecord();
            Match.ApproveTimesheetrecord();
            home.Logout();
            home.HandleAlert();
            //driver.AcceptAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281202", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281203_Reject_from_Timesheetrecord()
        {
            #region TC_C281203_WEB_Reject_from_Timesheetrecord
            this.TESTREPORT.InitTestCase("TC_C281203_WEB_Reject_from_Timesheetrecord", "Reject from Timesheet Record");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281203", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "Website");
            string connection = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "Connection");
            string command = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "Command");
            //  Database.ExecuteSqlCommand(connection, command);
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281203", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281203", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281203", "AvailableId"));
            string Type = "single";
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate,positionFolder,statusId, "");
            matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            accounting.RejectTimesheetRecord(Type);
            home.Logout();
            home.HandleAlert();
            //driver.AcceptAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281203", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281240_Verify_Availability_Shift()
        {
            #region TC_C281240_Verify_Availability_Shift
            this.TESTREPORT.InitTestCase("TC_C281240_Verify_Availability_Shift", "Verify Availability for Shift");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281240", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            driver.sleepTime(10000);
            string id = positionPage.GetPositionTitle();
            home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            schedulingPage.RightClickOnAssignedDate();
            schedulingPage.ClickOnShiftDetailLink();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281240", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281445_Confirm_enddate_functionality()
        {
            #region TC_C281445_Confirm_enddate_functionality
            this.TESTREPORT.InitTestCase("TC_C281445_Confirm_enddate_functionality", "Verify Confirm end date functionality");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "TaxType");
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "BillRate");
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "CandidateSearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "PlacementGrade");

            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "Postalcode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281445", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy").Replace('-', '/');
            DateTime edate = DateTime.Now.AddMonths(2);
            string endDate = edate.ToString("MM/dd/yyyy").Replace('-', '/');
            string cendDate = edate.AddDays(-1).ToString("M/d/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281445", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281445", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281445", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281445", "AvailableId"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);

            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();

            companyIdAndName = company.AddCompany(companyName, city, PostalCode, Email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();

            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName,foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, PayRate, BillRate, endDate,false,true);
            positionPage.VerifyPopUp(endDate, endReason, placementGrade);
            positionPage.VerifyMatchTimeline(cendDate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281445", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281442_Verify_VendorContact_Login_With_Valid_Credentials()
        {
            #region TC_C281442_Verify_VendorContact_Login_With_Valid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281442_Verify_VendorContact_Login_With_Valid_Credentials", "Verify Login with valid Credentials");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            //home.VerifyLoginMessage("Welcome to erecruit.");
            home.VerifyLogin();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281442", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }
        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281298_Verify_Recruiter_Login_With_Valid_Credentials()
        {
            #region TC_C281298_Verify_Recruiter_Login_With_Valid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281298_Verify_Recruiter_Login_With_Valid_Credentials", "Verify Login with valid Credentials");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281298", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281226_Create_Invoice_Record()
        {
            #region TC_C281226_Create_Invoice_Record
            this.TESTREPORT.InitTestCase("TC_C281226_Create_Invoice_Record", "Approve from Timesheet Record");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281226", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "Website");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281226", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281226", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281226", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, payRate, billRate,positionFolder,statusId, "");
            //matchPage.CreateTimesheets(matchId);
            //driver.SwitchToDefaultFrame();
            //Match.AddhoursTimesheetsearch();
            //accounting.ApproveTimesheetRecord();
            //accounting.ScheduleProcessing();
            //accounting.ScheduleInvoiceCreation();
            //accounting.ScheduleWIPRecordCreation();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281226", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

    }

}










