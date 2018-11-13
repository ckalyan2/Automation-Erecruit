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
using Engine.TestRail;
using Engine.UIHandlers.Selenium;
using StandardUtilities;

namespace AutomatedTest.FunctionalTests.Erecruit
{
    [TestClass]
    public class RegressionTest : TestBaseTemplate
    {
        public static string id = "";
        Utility utility = new Utility();

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

        /// <summary>
        ///  Contact User Name
        /// </summary>
        private static string contactUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "contactUserName");
        /// <summary>
        /// Contact User Password
        /// </summary>
        private static string contactPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "contactPassword");
        /// <summary>
        /// Candidate Password
        /// </summary>
        //private static string candidatePassword = ConfigurationManager.AppSettings["CandidatePassword"];

        /// candidate User Name
        /// </summary>
        private static string CandidateUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidateusername");
        /// <summary>
        /// Vendor Contact User Password
        /// </summary>
        private static string CandidatePassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidatepassword");
       // CreatePositionPage createposition = new CreatePositionPage();

        

        //CreateMatchPage createMatch = new CreateMatchPage();
        #endregion

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281150_Add_candidate()
        {
            #region TC_C281150_Add_candidate
            this.TESTREPORT.InitTestCase("TC_C281150_Add_candidate", "Add candidate");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281150", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281150", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281150", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.NavigateToAddCandidate();
            candidate.CreateCandidateWithoutResumeInVendorContact(candidateName, candidateName, phoneNumber, Email);
            candidate.VerifyHomePageTitle(candidateName);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281150", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281149_Launching_Dashboard_successfully_with_all_widgets_using_Vendor_contact_login()
        {
            #region TC_C281149_Launching_Dashboard_successfully_with_all_widgets_using_Vendor_contact_login
            this.TESTREPORT.InitTestCase("TC_C281149_Launching_Dashboard_successfully_with_all_widgets_using_Vendor_contact_login", "Launching Dashboard successfully with all widgets using Vendor contact login");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            dashboard.VerifyPageTitle("Dashboard");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281149", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281154_Verify_customizing_existing_Dashboard_in_Home_Screen_VendoContact()
        {
            #region TC_C281154_Verify_customizing_existing_Dashboard_in_Home_Screen_VendoContact
            this.TESTREPORT.InitTestCase("TC_C281154_Verify_customizing_existing_Dashboard_in_Home_Screen_VendoContact", "Verify customizing existing Dashboard in Home Screen");
            #region Testdata
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281154", "CalendarWidgenet");
            #endregion
            #region Recruiter
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            controlPanel.EnterAdminMenuFilter();
            controlPanel.ClickOnDesignDashboards();
            driver.SwitchToDefaultFrame();
            controlPanel.ClickOnVendorDesignDashboardButton();
            dashboard.ClickOnModifyDashboard(true);
            dashboard.SelectZoneForVendor(widgenetName);
            home.Logout();
            #endregion

            #region Vendor
            home.Login(webURL, vendorContactName, vendorContactPassword);
            dashboard.VerifyAddWidgetsInVendor();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281154", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281148_Verify_VendorContact_Login_With_Valid_Credentials()
        {
            #region TC_C281148_Verify_VendorContact_Login_With_Valid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281148_Verify_VendorContact_Login_With_Valid_Credentials", "Verify Login with valid Credentials");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.VerifyLogin();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281148", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281152_Search_with_Invalid_Candidate_ID()
        {
            #region TC_C281152_Search_with_Invalid_Candidate_ID
            this.TESTREPORT.InitTestCase("TC_C281152_Search_with_Invalid_Candidate_ID", "Search with Invalid Candidate ID");
            #region Test Data
            string candidateInvalidID = ExcelOperations.GetCellValueFromExcel("TCIdC281152", "CandidateInvalidId");
            #endregion
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchWithInvalidID(candidateInvalidID);
            candidate.VerifyHomePageTitle("Invalid ID");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281152", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281153_Search_with_Invalid_Position_ID()
        {
            #region TC_C281153_Search_with_Invalid_Position_ID
            this.TESTREPORT.InitTestCase("TC_C281153_Search_with_Invalid_Position_ID", "Search with Invalid Position ID");
            #region Test Data
            string positionInvalidId = ExcelOperations.GetCellValueFromExcel("TCIdC281153", "PositionInvalidId");
            #endregion
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.SearchPosition(positionInvalidId);
            candidate.VerifyHomePageTitle("Invalid ID");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281153", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281164_Make_sure_the_Dashboard_Loads()
        {
            #region TC_C281164_Make_sure_the_Dashboard_Loads
            this.TESTREPORT.InitTestCase("TC_C281164_Make_sure_the_Dashboard_Loads", "Make sure the dashboard loads");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            dashboard.VerifyPageTitle("Dashboard");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281164", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281165_Modify_Dashboard()
        {
            #region TC_C281165_Modify_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281165_Modify_Dashboard", "Verify Modify Dashboard");

            #region Testdata
            string dashBoardValue = ExcelOperations.GetCellValueFromExcel("TCIdC281165", "DashBoardValue");
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ModifyDashboard(dashBoardValue);
            home.Logout();
            home.HandleAlert();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281165", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281166_Column_Width_distribution()
        {
            #region TC_C281166_Column_Width_distribution
            this.TESTREPORT.InitTestCase("TC_C281166_Column_Width_distribution", "Verify Column Width distribution");

            #region Testdata
            string dashBoardValue = ExcelOperations.GetCellValueFromExcel("TCIdC281166", "DashBoardValue");
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ModifyDashboard(dashBoardValue);
            dashboard.ClickOnModifyDashboard();
            dashboard.ChangeColumnWidthDistribution(0);
            dashboard.ClickOnApplyDistributionButton();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyColumnWidthDistribution(0);
            home.Logout();
            home.HandleAlert();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281166", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281169_Display_LoginUserbutton_displayed_Contact_VendorManagerlogin()
        {
            #region TC_C281169_Display_LoginUserbutton_displayed_Contact_VendorManagerlogin()
            this.TESTREPORT.InitTestCase("TC_C281169_Display_LoginUserbutton_displayed_Contact_VendorManagerlogin", "Verfiy Display of Login as a User button is displayed for Contact using Vendor Manager login");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281169", "FolderGroupId"));
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281169", "CurrentPassword");
            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyLoginUserButton();
            home.Logout();
            home.HandleAlert();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281169", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281170_Provision_Contact_VendorManager()
        {
            #region TC_C281170_Provision_Contact_VendorManager()
            this.TESTREPORT.InitTestCase("TC_C281170_Provision_Contact_VendorManager", "Verfiy Provision Contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281170", "FolderGroupId"));
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "ActionStatusG");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "NewPassword");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281170", "CurrentPassword");
            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.Login(webURL, Email, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            home.Logout();
            home.HandleAlert();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281170", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281171_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactName_contact()
        {
            #region TC_C281171_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactName_contact()
            this.TESTREPORT.InitTestCase("TC_C281171_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactName_contact", "Verfiy Manage Login Access using Vendor Manager login and search criteria by Contact Name for contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281171", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281171", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281171", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281171", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281171", "ContactType");

            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact(candidateName);
            home.ClickOnFilteredCandidate(candidateName);
            driver.sleepTime(5000);
            company.ManageLogin();            
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281171", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281172_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactID_Contact()
        {
            #region TC_C281172_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactID_contact()
            this.TESTREPORT.InitTestCase("TC_C281172_ManageLoginAccess_VendorManagerlogin_searchcriteria_ContactID_contact", "Verfiy Manage Login Access using Vendor Manager login and search criteria by Contact ID for contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281172", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281172", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281172", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281172", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281172", "ContactType");

            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281172", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281173_Unprovisioned_status_AccessManagementpopup_Vendormanager_login_Contact()
        {
            #region TC_C281173_Unprovisioned_status_AccessManagementpopup_Vendormanager_login_Contact()
            this.TESTREPORT.InitTestCase("TC_C281173_Unprovisioned_status_AccessManagementpopup_Vendormanager_login_Contact", "Verfiy Unprovisioned status in Access Management pop up using Vendor manager login for Contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281173", "FolderGroupId"));
            string actionStatusUP = ExcelOperations.GetCellValueFromExcel("TCIdC281173", "ActionStatusUP");
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.VerifyActionStatus(actionStatusUP);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281173", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281175_Login_Userbutton_displayed_AccessManagementpopup_VendorManagerlogin_Contact()
        {
            #region TC_C281175_Login_Userbutton_displayed_AccessManagementpopup_VendorManagerlogin_Contact
            this.TESTREPORT.InitTestCase("TC_C281175_Login_Userbutton_displayed_AccessManagementpopup_VendorManagerlogin_Contact", "Verfiy Login as a User button is displayed in Access Management pop up using Vendor Manager login for Contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "ContactType");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281175", "CurrentPassword");
            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.ValidateElements_ManageLogin(Email);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281175", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281176_Toggle_Federationbutton_AccessManagementpopup_VendorManagerlogin_Contact()
        {

            #region TC_C281176_Toggle_Federationbutton_AccessManagementpopup_VendorManagerlogin_Contact()
            this.TESTREPORT.InitTestCase("TC_C281176_Toggle_Federationbutton_AccessManagementpopup_VendorManagerlogin_Contact", "Verfiy Toggle Federation button in Access Management pop up using Vendor Manager login for Contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "ContactType");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281176", "CurrentPassword");
            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyToggleFederation(actionType);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281176", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281177_Revoke_Accessbutton_AccessManagementpopup_VendorManagerlogin_Contact()
        {
            #region TC_C281177_Revoke_Accessbutton_AccessManagementpopup_VendorManagerlogin_Contact()
            this.TESTREPORT.InitTestCase("TC_C281177_Revoke_Accessbutton_AccessManagementpopup_VendorManagerlogin_Contact", "Verfiy Revoke Access button in Access Management pop up using Vendor Manager login for Contact");

            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "ContactType");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "ActionStatusG");
            string actionStatusR = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "ActionStatusR");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281177", "CurrentPassword");
            #endregion

            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchVendorContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            company.VerifyButtonElements_AccessMgmPopup();
            company.ClickRevokeAccess();
            company.VerifyActionStatus(actionStatusR);
            company.VerifyButtonElements_AccessMgmPopup();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281177", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281180_Verify_Customizing_existing_Dashboard_in_Home_Screen()
        {
            #region TC_C281180_Verify_Customizing_existing_Dashboard_in_Home_Screen
            this.TESTREPORT.InitTestCase("TC_C281180_Verify_Customizing_existing_Dashboard_in_Home_Screen", "Verify Modify Existing Dashboard in Home Screen");

            #region Testdata
            string dashBoardValue = ExcelOperations.GetCellValueFromExcel("TCIdC281180", "DashBoardValue");
            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ModifyDashboard(dashBoardValue);
            dashboard.ChangeColumnWidthDistribution(5);
            dashboard.ClickOnApplyDistributionButton();
            driver.sleepTime(10000);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281180", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281183_Verify_Logo_Menu_Vendor_Manager()
        {
            #region TC_C281183_Verify_Logo_Menu_Vendor_Manager
            this.TESTREPORT.InitTestCase("TC_C281183_Verify_Logo_Menu_Vendor_Manager", "Verify Logo Menu");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompany();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.NavigateToAddContact();
            home.NavigateToAddPosition();
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnAccounting();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281183", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281357_Verify_Manage_Tags_Present_MatchSearch_RightPane()
        {
            #region TC_C281357_Verify_Manage_Tags_Present_MatchSearch_RightPane
            this.TESTREPORT.InitTestCase("TC_C281357_Verify_Manage_Tags_Present_MatchSearch_RightPane", "Verify Manage Tags Present Match Search Right Pane");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            manage.VerifyManageTags();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281357", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281358_Verify_User_CreateTag_From_ManageTags_RightPane()
        {

            #region TC_C281358_Verify_User_CreateTag_From_ManageTags_RightPane
            this.TESTREPORT.InitTestCase("TC_C281358_Verify_User_CreateTag_From_ManageTags_RightPane", "Verify User Create Tag From Manage Tags Right Pane");
            string Tagname = ExcelOperations.GetCellValueFromExcel("TCIdC281358","TagName");
            string Tagdesc = ExcelOperations.GetCellValueFromExcel("TCIdC281358", "TagDescription");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            manage.CreateManageTags(Tagname, Tagdesc);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281358", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281359_Verify_Recruiter_Add_Tags()
        {
            #region TC_C281359_Verify_Recruiter_Add_Tags
            this.TESTREPORT.InitTestCase("TC_C281359_Verify_Recruiter_Add_Tags", "Verify Recruiter Add Tags");
            #region Test Data           
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281359", "CandidateName");           
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281359", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281359", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281359", "CommunicationNote");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281359", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281359", "FolderGroupId"));
            int id = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281359", "TagsID"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.ClickonTagsEdit(id);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281359", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281360_Verify_Changes_Workers_Comp_Manage_Page_Change_History_Page()
        {
            #region TC_C281360_Verify_Changes_Workers_Comp_Manage_Page_Change_History_Page
            this.TESTREPORT.InitTestCase("TC_C281360_Verify_Changes_Workers_Comp_Manage_Page_Change_History_Page", "Verify Changes Workers Comp Manage Page Change History Page");
            #region Test Data           
            string workerstemp = ExcelOperations.GetCellValueFromExcel("TCIdC281360", "WorkersTemplate");
            string workersweight = ExcelOperations.GetCellValueFromExcel("TCIdC281360", "RequirementWeight");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.ChangeWorkersComp(workerstemp, workersweight);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281360", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281248_Verify_Functionality_Types_Tab_Manage_Requirements_Page()
        {
            #region TC_C281248_Verify_Functionality_Types_Tab_Manage_Requirements_Page
            this.TESTREPORT.InitTestCase("TC_C281248_Verify_Functionality_Types_Tab_Manage_Requirements_Page", "Verify Functionality Types Tab Manage Requirements Page");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.ManageTypes();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281248", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281249_Verify_ManageRequirements_Page_Remains_Same_After_Scenario_Deleted()
        {
            #region TC_C281249_Verify_ManageRequirements_Page_Remains_Same_After_Scenario_Deleted
            this.TESTREPORT.InitTestCase("TC_C281249_Verify_ManageRequirements_Page_Remains_Same_After_Scenario_Deleted", "Verify Manage Requirements Page Remains Same After Scenario Deleted");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.RequirementScenarioDeletion();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281249", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281251_Verify_Add_Scenarios_Requirement()
        {

            #region TC_C281251_Verify_Add_Scenarios_Requirement
            this.TESTREPORT.InitTestCase("TC_C281251_Verify_Add_Scenarios_Requirement", "Verify Add Scenarios To Requirement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.AddScenarioToRequirement();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281251", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281252_Verify_Delete_Scenarios_Requirement()
        {

            #region TC_C281252_Verify_Delete_Scenarios_Requirement
            this.TESTREPORT.InitTestCase("TC_C281252_Verify_Delete_Scenarios_Requirement", "Verify Delete Scenarios To Requirement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.RequirementScenarioDeletion();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281252", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281254_Verify_Search_Requirement()
        {
            #region TC_C281254_Verify_Search_Requirement
            this.TESTREPORT.InitTestCase("TC_C281254_Verify_Search_Requirement", "Verify Search Requirement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchRequirement();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281254", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281256_Verify_Add_New_Candidate_Target_Requirement()
        {
            #region TC_C281256_Verify_Add_New_Candidate_Target_Requirement
            this.TESTREPORT.InitTestCase("TC_C281256_Verify_Add_New_Candidate_Target_Requirement", "Verify Add New Candidate Target Requirement");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281256", "RequirementName");
            string reqtype = ExcelOperations.GetCellValueFromExcel("TCIdC281256", "RequirementType");
            string reqtarget = ExcelOperations.GetCellValueFromExcel("TCIdC281256", "RequirementTarget");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC281256", "RequirementWeight");
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
            string status = TestRailIntegration.PublishResultsToTestRail("C281256", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281332_Verify_Permission_EditRequirementProvider_Renamed_To_EditRequirementIntegrationProvider()
        {
            #region TC_C281332_Verify_Permission_EditRequirementProvider_Renamed_To_EditRequirementIntegrationProvider
            this.TESTREPORT.InitTestCase("TC_C281332_Verify_Permission_EditRequirementProvider_Renamed_To_EditRequirementIntegrationProvider", "Verify that Permission for Edit Requirement Provider renamed to Edit Requirement Integration Provider");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.VerifyProviderPermissionTemplate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281332", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281333_Verify_Permission_EditRequirementProviderDetails_Renamed_To_EditRequirementIntegrationPackage()
        {
            #region TC_C281333_Verify_Permission_EditRequirementProviderDetails_Renamed_To_EditRequirementIntegrationPackage
            this.TESTREPORT.InitTestCase("TC_C281333_Verify_Permission_EditRequirementProviderDetails_Renamed_To_EditRequirementIntegrationPackage", "Verify that Permission for Edit Requirement Provider Details renamed to Edit Requirement Integration Package");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.VerifyPackagePermissionTemplate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281333", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281313_Verify_Quick_Search_Box_Without_Existing_Data()
        {
            #region TC_C281313_Verify_Quick_Search_Box_Without_Existing_Data
            this.TESTREPORT.InitTestCase("TC_C281313_Verify_Quick_Search_Box_Without_Existing_Data", "Verify Quick search box (without existing data)");
            #region Test Data
            string noResultsMessage = ExcelOperations.GetCellValueFromExcel("TCIdC281313", "NoResultsMessage");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            searchPage.EnterSearchName("xcom45");
            searchPage.VerifyNoResultsMessage(noResultsMessage);
            searchPage.EnterSearchName("xcan12");
            searchPage.VerifyNoResultsMessage(noResultsMessage);
            searchPage.EnterSearchName("xcon23");
            searchPage.VerifyNoResultsMessage(noResultsMessage);
            searchPage.EnterSearchName("xpos34");
            searchPage.VerifyNoResultsMessage(noResultsMessage);
            searchPage.EnterSearchName("xmat34");
            searchPage.VerifyNoResultsMessage(noResultsMessage);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281313", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281307_Verify_Reports_Funnel()
        {
            #region TC_C281307_Verify_Reports_Funnel
            this.TESTREPORT.InitTestCase("TC_C281307_Verify_Reports_Funnel", "Verify Reports:Funnel");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            reports.ClickOnFunnelCandidatesLink();
            reports.VerifyReportsTitle("The Funnel - Candidates");

            reports.ClickOnFunnelContactsLink();
            reports.VerifyReportsTitle("The Funnel - Contacts");

            reports.ClickOnFunnelPositionsLink();
            reports.VerifyReportsTitle("The Funnel - Positions");

            reports.ClickOnFunnelSeedsLink();
            reports.VerifyReportsTitle("The Funnel - Seeds");

            reports.ClickOnFunnelOpportunitiesLink();
            reports.VerifyReportsTitle("The Funnel - Opportunities");

            reports.ClickOnFunnelMatchesLink();
            reports.VerifyReportsTitle("The Funnel - Matches");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281307", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281306_Verify_Dashboard()
        {
            #region TC_C281306_Verify_Dashboard
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281306", "WidgenetName");
            this.TESTREPORT.InitTestCase("TC_C281306_Verify_Dashboard", "Verify Dashboard");
            //string widgenetName = ExcelOperations.GetCellValueFromExcel("","widgenetName");            
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            localization.VerifyLeaderboardWidget();
            dashboard.CloseWidgets();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281306", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281235_Verify_Shift_Details()
        {

            #region TC_C281235_Verify_Shift_Details
            this.TESTREPORT.InitTestCase("TC_C281235_Verify_Shift_Details", "Verify Shift Details");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281235", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            //string id = positionPage.GetPositionTitle();
            //home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            schedulingPage.RightClickOnAssignedDate();
            schedulingPage.ClickOnShiftDetailLink();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281235", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281334_Verify_Permission_EditRequirementIntegrationPackageService_Reflected_Add_Permission_Dropdown()
        {
            #region TC_C281334_Verify_Permission_EditRequirementIntegrationPackageService_Reflected_Add_Permission_Dropdown
            this.TESTREPORT.InitTestCase("TC_C281334_Verify_Permission_EditRequirementIntegrationPackageService_Reflected_Add_Permission_Dropdown", "Verify that Permission for Edit Requirement Integration Package/Service Reflected In Add Permission Dropdown");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.VerifyPackagePermissionTemplate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281334", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281308_Verify_Reports_Accounting()
        {
            #region TC_C281308_Verify_Reports_Accounting
            this.TESTREPORT.InitTestCase("TC_C281308_Verify_Reports_Accounting", "Verify Reports:Accounting");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            reports.ClickOnAccountingBatchRegisterLink();
            reports.VerifyReportsTitle("Batch Register");

            reports.ClickOnAccoutingCandidateAdditionsLink();
            reports.VerifyReportsTitle("Candidate Additions");

            reports.ClickOnAccoutingCandidateChangesLink();
            reports.VerifyReportsTitle("Candidate Changes");

            reports.ClickOnAccoutingCashReceiptsLink();
            reports.VerifyReportsTitle("Cash Receipts");

            reports.ClickOnAccoutingGPExportLogLink();
            reports.VerifyReportsTitle("GP Export Log");

            reports.ClickOnAccoutingInvoiceSummaryLink();
            reports.VerifyReportsTitle("Invoice Summary");

            reports.ClickOnAccoutingTransactionCreditLink();
            reports.VerifyReportsTitle("Search Transactions");

            reports.ClickOnAccoutingWorkersCompLink();
            reports.VerifyReportsTitle("Workers Comp");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281308", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281310_Verify_Reports_Other_Reports()
        {
            #region TC_C281310_Verify_Reports_Other_Reports
            this.TESTREPORT.InitTestCase("TC_C281310_Verify_Reports_Other_Reports", "Verify Reports:Other Reports");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            reports.ClickOnAccountsReceivableAnalysis();
            reports.ClickOnGenerateReport();
            reports.VerifyReportsTitle("Accounts Receivable Analysis");
            //reports.ClickOnGPAccountsReceivableAnalysis();
            //reports.ClickOnGenerateReport();
            //reports.VerifyReportsTitle("GP Accounts Receivable Analysis");
            //reports.ClickOnActiveContractNumberTrend();
            //reports.ClickOnGenerateReport();
            //reports.VerifyReportsTitle("Active Contract Number Trend");
            //reports.ClickOnActiveContractPlacements();
            //reports.VerifyReportsTitle("Active Contract Placements");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281310", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281312_Verify_Quick_Search_Box()
        {
            #region TC_C281312_Verify_Quick_Search_Box
            this.TESTREPORT.InitTestCase("TC_C281312_Verify_Quick_Search_Box", "Verify Quick Search Box");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            searchPage.EnterSearchName("Automation Candidate");
            searchPage.VerifySearchPageTitle();
            searchPage.EnterSearchName("Automation Company");
            searchPage.VerifySearchPageTitle();
            searchPage.EnterSearchName("Automation Contact");
            searchPage.VerifySearchPageTitle();
            searchPage.EnterSearchName("Automation Engineer");
            searchPage.VerifySearchPageTitle();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281312", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281309_Verify_Reports_Dynamic_Reports()
        {
            #region TC_C281309_Verify_Reports_Dynamic_Reports
            this.TESTREPORT.InitTestCase("TC_C281309_Verify_Reports_Dynamic_Reports", "Verify Reports:Dynamic Reports");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            reports.ClickOnForBrain();
            reports.SwitchToDynamicReportsFrame();
            reports.ClickOnGenerateReport();
            reports.VerifyReportsTitle("BRAIN");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281309", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281311_Verify_Reports_Filter()
        {
            #region TC_C281311_Verify_Reports_Filter
            this.TESTREPORT.InitTestCase("TC_C281311_Verify_Reports_Filter", "Verify Reports:Filter");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            reports.NavigateToReportsLink();
            reports.EnterFiterText("Candidates");
            reports.VerifyFilterText();
            reports.ClickOnRefresh();
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            home.ClickOnLogoMenu();
            reports.NavigateToReportsLink();
            reports.EnterFiterText("Concts");
            reports.VerifyFilterNotExist();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281311", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281295_Verify_that_Recruiter_able_to_Add_Candidate_Termination_date()
        {
            #region TC_C281295_Verify_that_Recruiter_able_to_Add_Candidate_Termination_date
            this.TESTREPORT.InitTestCase("TC_C281295_Verify_that_Recruiter_able_to_Add_Candidate_Termination_date", "Verify that Recruiter able to Add Candidate Termination date");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281295", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281295", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281295", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);           
            candidate.EnterTerminationDate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281295", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281102_Verify_ContactType_selected_New_Contact_screen_carry_contact_record()
        {
            #region TC_C281102_Verify_ContactType_selected_New_Contact_screen_carry_contact_record
            this.TESTREPORT.InitTestCase("TC_C281102_Verify_ContactType_selected_New_Contact_screen_carry_contact_record", "Verify Contact Type is selected on the New Contact screen carry to contact record");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281102", "CandidateName");//ExcelOperations.GetCellValueFromExcel("CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281102", "City");//ExcelOperations.GetCellValueFromExcel("City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281102", "Title");//ExcelOperations.GetCellValueFromExcel("Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281102", "ContactMail"); //ExcelOperations.GetCellValueFromExcel("ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281102", "ContactType");//ExcelOperations.GetCellValueFromExcel("ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281102", "FolderGroupId")); //Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            string searchValue = candidate.GetCandidateTitleIncludingId();
            candidate.SaveandCloseContact();
            candidate.QuickSearch(searchValue);
            candidate.ValidateContactType(contactType);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281102", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281106_Unprovisioned_status_Access_Management_popup_Recruiter_login_Contact()
        {
            #region TC_C281106_Unprovisioned_status_Access_Management_popup_Recruiter_login_Contact
            this.TESTREPORT.InitTestCase("TC_C281106_Unprovisioned_status_Access_Management_popup_Recruiter_login_Contact", "Unprovisioned status in Access Management pop up using Recruiter login for Contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281106", "FolderGroupId"));
            string actionStatusUP = ExcelOperations.GetCellValueFromExcel("TCIdC281106", "ActionStatusUP");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.VerifyActionStatus(actionStatusUP);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281106", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281110_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Contact()
        {
            #region TC_C281110_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Contact
            this.TESTREPORT.InitTestCase("TC_C281110_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Contact", "Toggle Federation button in Access Management pop up using Recruiter login for Contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "ContactType");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281110", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyToggleFederation(actionType);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281110", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281104_Provision_Contact()
        {
            #region TC_C281104_Provision_Contact
            this.TESTREPORT.InitTestCase("TC_C281104_Provision_Contact", "Provision Contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281104", "FolderGroupId"));
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "ActionStatusG");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "NewPassword");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281104", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.Login(webURL, Email, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281104", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281111_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Contact()
        {

            #region TC_C281111_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Contact()
            this.TESTREPORT.InitTestCase("TC_C281111_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Contact()", "Verify Revoke Access button and its functionality in Access Management pop up for a contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "ContactType");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "ActionStatusG");
            string actionStatusR = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "ActionStatusR");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            company.VerifyButtonElements_AccessMgmPopup();
            company.ClickRevokeAccess();
            company.VerifyActionStatus(actionStatusR);
            company.VerifyButtonElements_AccessMgmPopup();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281111", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281125_ManageLoginAccess_Recruiterlogin_searchcriteria_CandidateName_Candidate()
        {
            #region TC_C281125_ManageLoginAccess_Recruiterlogin_searchcriteria_CandidateName_Candidate()
            this.TESTREPORT.InitTestCase("TC_C281125_ManageLoginAccess_Recruiterlogin_searchcriteria_CandidateName_Candidate()", "Verify Manage Login Access using Recruiter login and search criteria by Candidate Name for Candidate");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281111", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281111", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //home.SearchCandidate(candidateName);
           // home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281125", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281126_ManageLoginAccess_Recruiterlogin_searchcriteria_Candidate()
        {
            #region TC_C281126_ManageLoginAccess_Recruiterlogin_searchcriteria_Candidate
            this.TESTREPORT.InitTestCase("TC_C281126_ManageLoginAccess_Recruiterlogin_searchcriteria_Candidate", "Manage Login Access using Recruiter login and search criteria by Candidate ID for Candidate");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281126", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281126", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281126","FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.Clickonclose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateId();
            company.ManageLogin(true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281126", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281335_Verify_Permission_EditRequirementIntegrationPackageService_Reflected_Add_Permission_Dropdown()
        {

            #region TC_C281335_Verify that Permission for Edit Requirement Integration Package/Service Reflected In Add Permission Dropdown
            this.TESTREPORT.InitTestCase("TC_C281335_Verify that Permission for Edit Requirement Integration Package/Service Reflected In Add Permission Dropdown", "VVerify that Permission for Edit Requirement Integration Package/Service Reflected In Add Permission Dropdown");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            manage.VerifyPackagePermissionTemplate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281335", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281296_Verify_that_Recruiter_able_to_Edit_Candidate_Termination_date()
        {
            #region TC_C281296_Verify_that_Recruiter_able_to_Edit_Candidate_Termination_date
            this.TESTREPORT.InitTestCase("TC_C281296_Verify_that_Recruiter_able_to_Edit_Candidate_Termination_date", "Verify that Recruiter able to Edit Candidate Termination date");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281296", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281296", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281296", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            candidate.EnterTerminationDate();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281296", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281297_Verify_that_Recruiter_able_to_Delete_Candidate_Termination_date()
        {
            #region TC_C281297_Verify_that_Recruiter_able_to_Delete_Candidate_Termination_date
            this.TESTREPORT.InitTestCase("TC_C281297_Verify_that_Recruiter_able_to_Delete_Candidate_Termination_date", "Verify that Recruiter able to Delete Candidate Termination date");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281297", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281297", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281297", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            candidate.EnterTerminationDate(true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281297", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281105_ManageLogin_Access_using_Recruiter_login_Contact()
        {
            #region TC_C281105_ManageLogin_Access_using_Recruiter_login_Contact
            this.TESTREPORT.InitTestCase("TC_C281105_ManageLogin_Access_using_Recruiter_login_Contact", "Manage Login Access using Recruiter login and search criteria by Contact ID for Contact");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281105", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281105", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281105", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281105", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281105", "FolderGroupId"));
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
            company.CloseManageLoginAccess();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281105", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy.csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281119_Verify_Add_Candidate_With_Tags()
        {
            #region TC_C281119_Verify_Add_Candidate_With_Tags
            this.TESTREPORT.InitTestCase("TC_C281119_Verify_Add_Candidate_With_Tags", "Add New Candidate with Tags");

            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281119", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281119", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281118", "FolderGroupId"));
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281119", "TaskName");
            string note = ExcelOperations.GetCellValueFromExcel("TCIdC281119", "NoteName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.ClickonTagsEdit(1);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281119", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281118_Verify_Add_Candidate_No_Resume()
        {
            #region TC_C281118_Verify_Add_Candidate_No_Resume
            this.TESTREPORT.InitTestCase("TC_C281118_Verify_Add_Candidate_No_Resume", "Add New Candidate without resume");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281118", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281118", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281118", "FolderGroupId"));
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281118", "TaskName");
            string note = ExcelOperations.GetCellValueFromExcel("TCIdC281118", "NoteName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string ID = AddCandidatePage.id;
            //string searchValue = candidate.GetCandidateTitleIncludingId();
            searchPage.EnterSearchName(ID);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281118", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281123_Provision_Candidate()
        {
            #region TC_C281123_Provision_Candidate
            this.TESTREPORT.InitTestCase("TC_C281123_Provision_Candidate", "Provision Candidate.");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "CandidateName");//ExcelOperations.GetCellValueFromExcel("CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281123", "FolderGroupId"));
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "ActionStatusG");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "NewPassword");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281123", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.SearchCandidate(candidateName);
           // home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.Login(webURL, email, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            driver.sleepTime(10000);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281123", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281250_Verify_Add_Requirement_EmptyData_Mandatory_Fields()
        {
            #region TC_C281250_Verify_Add_Requirement
            this.TESTREPORT.InitTestCase("TC_C281250_Verify_Add_Requirement(Empty data for mandatory fields)", "Verify Add Requirement(Empty data for mandatory fields)");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281250", "RequirementName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.AddNewRequirement(req, "", "", "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281250", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281127_Unprovisioned_status_Access_Management_popup_Recruiter_login_Candidate()
        {
            #region TC_C281127_Unprovisioned_status_Access_Management_popup_Recruiter_login_Candidate
            this.TESTREPORT.InitTestCase("TC_C281127_Unprovisioned_status_Access_Management_popup_Recruiter_login_Candidate", "Unprovisioned status in Access Management pop up using Recruiter login for Candidate");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "ContactType");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281127", "FolderGroupId"));
            string actionStatusUP = ExcelOperations.GetCellValueFromExcel("TCIdC281127", "ActionStatusUP");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.SearchCandidate(candidateName);
            //home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            company.VerifyActionStatus(actionStatusUP);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281127", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281272_Verify_Functionality_Position_Match_Links_Company_Page()
        {
            #region TC_C281272_Verify_Functionality_Position_Match_Links_Company_Page
            this.TESTREPORT.InitTestCase("TC_C281272_Verify_Functionality_Position_Match_Links_Company_Page", "Verify the functionality of position and match links from company page");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "Title");
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "PostalCode");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281272", "FolderGroupId"));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281272", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281272", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281272", "PositionFolderGroup"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
           company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            position.ClickButtonAddPositionFromCompany();
            PositionId=positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            bool companies = true;
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            candidate.MatchfromRightPanel(companyIdAndName, companies);
            matchId = createMatch.CreateMatchfromRightPanel(PositionId, CandidateId, billRate, payRate);
            int index = matchId.IndexOf("-");
            if (index > 0)
                matchId = matchId.Substring(0, index);
            matchId = matchId.Trim();
            createMatch.VerfiyMatchfromCompany(companyIdAndName,matchId);
            createMatch.VerfiyPositionfromCompany(companyIdAndName,PositionId);
            
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281272", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281274_Verify_Error_While_Creating_New_Quick_Match()
        {
            #region TC_C281274_Verify_Error_While_Creating_New_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C281274_Verify_Error_While_Creating_New_Quick_Match", "Verify Error While Creating New Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281274","Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281274","InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281274","TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281274","CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281274", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281274", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281274", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281274", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281274", "AvailableId"));
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate,false,true);
            home.Logout();

            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281274", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281278_Verify_Functionality_Of_Creating_Quick_Match()
        {
            #region TC_C281278_Verify_Functionality_Of_Creating_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C281278_Verify_Functionality_Of_Creating_Quick_Match", "Verify the functionality of Creating Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281278", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281278", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281278", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281278", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281278", "AvailableId"));
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
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate,false,true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281278", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281156_Verify_Logo_Menu()
        {
            #region TC_C281156_Verify_Logo_Menu
            this.TESTREPORT.InitTestCase("TC_C281156_Verify_Logo_Menu", "Verify Logo Menu Vendor Contact");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidate();
            //driver.SwitchTo().DefaultContent();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCompany();
            //driver.SwitchTo().DefaultContent();
            //home.MouseHoverOnAddNew();
            //home.NavigateToAddContact();
            //driver.SwitchTo().DefaultContent();
            home.NavigateToAddPosition();
            driver.SwitchToDefaultFrame();
            home.MouseHoverOnAccounting();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281156", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281130_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Candidate()
        {
            #region TC_C281130_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Candidate
            this.TESTREPORT.InitTestCase("TC_C281130_Toggle_Federation_button_Access_Management_popup_Recruiter_login_Candidate", "Toggle Federation button in Access Management pop up using Recruiter login for Candidate");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281129", "FolderGroupId"));
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281130", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.SearchCandidate(candidateName);
            //home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            company.GiveAccess(currentPassword);
            company.VerifyToggleFederation(actionType);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281130", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281133_Login_User_in_Access_Management_popup_using_Recruiter_login_Candidate()
        {
                
            #region TC_C281133_Login_User_in_Access_Management_popup_using_Recruiter_login_Candidate
            this.TESTREPORT.InitTestCase("TC_C281133_Login_User_in_Access_Management_popup_using_Recruiter_login_Candidate", "Login as a User in Access Management pop up using Recruiter login for Candidate");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281133", "FolderGroupId"));
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281133", "CurrentPassword");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.SearchCandidate(candidateName);
            //home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            company.GiveAccess(currentPassword);
            company.VerifyLoginUserButton();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281133", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281129_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Candidate()
        {

            #region TC_C281129_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Candidate
            this.TESTREPORT.InitTestCase("TC_C281129_RevokeAccess_button_AccessManagement_popup_Recruiter_login_Candidate", "Revoke Access button in Access Management pop up using Recruiter login for Candidate");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281129","Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281129", "FolderGroupId"));
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "CurrentPassword");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "ActionStatusG");
            string actionStatusR = ExcelOperations.GetCellValueFromExcel("TCIdC281129", "ActionStatusR");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.ClickOnFilteredCandidate(candidateName, true);
            company.ManageLogin(true);
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            company.VerifyButtonElements_AccessMgmPopup();
            company.ClickRevokeAccess();
            company.VerifyActionStatus(actionStatusR);
            company.VerifyButtonElements_AccessMgmPopup();
            home.Logout();
            home.HandleAlert();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281129", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281128_RGiveAccess_button_AccessManagement_popup_Recruiter_login_Candidate()
        {

            #region TC_C281128_RGiveAccess_button_AccessManagement_popup_Recruiter_login_Candidate
            this.TESTREPORT.InitTestCase("TC_C281128_RGiveAccess_button_AccessManagement_popup_Recruiter_login_Candidate", "Give Access button in Access Management pop up using Recruiter login for Candidate");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281128", "FolderGroupId"));
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "CurrentPassword");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "ActionStatusG");
            string actionStatusR = ExcelOperations.GetCellValueFromExcel("TCIdC281128", "ActionStatusR");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            home.SearchCandidate(candidateName);
            company.ManageLogin(true);
            company.GiveAccess(currentPassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281128", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281320_Verify_Match_Search()
        {
            #region TC_C281320_Verify_Match_Search
            this.TESTREPORT.InitTestCase("TC_C281320_Verify_Match_Search", "Verify_Match_Search");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281320", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281320", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281320", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281320", "AvailableId"));
            string Id = "1272272";
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            home.ClickOnLogoMenu();
            home.MouseHoverOnMatches(Id);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281320", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281327_Verify_Requirement_Search_With_Candidate_Status_Filter_Set()
        {
            #region TC_C281327_Verify_Requirement_Search_With_Candidate_Status_Filter_Set
            this.TESTREPORT.InitTestCase("TC_C281327_Verify_Requirement_Search_With_Candidate_Status_Filter_Set", "Verify Requirement Search With Candidate Status Filter Set");
            #region TestData
            string filterstatus = ExcelOperations.GetCellValueFromExcel("","candidatestatus");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.VerifyCandidateFilterStatus(filterstatus);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281327", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281326_Verify_Candidate_And_Match_Search_Filters()
        {
            #region TC_C281326_Verify_Candidate_And_Match_Search_Filters
            this.TESTREPORT.InitTestCase("TC_C281326_Verify_Candidate_And_Match_Search_Filters", "Verify Candidate And Match Search Filters");
            #region TestData
            string activestatus = ExcelOperations.GetCellValueFromExcel("","ActiveMatch");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.VerifyActiveMatchStatus(activestatus);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281326", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281325_Verify_User_Able_To_Search_Match_By_ID_LogoMenu()
        {
            #region TC_C281325_Verify_User_Able_To_Search_Match_By_ID_LogoMenu
            this.TESTREPORT.InitTestCase("TC_C281325_Verify_User_Able_To_Search_Match_By_ID_LogoMenu", "Verify user is able to search a Match by id through logo menu");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281325", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281325", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281325", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281325", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            //home.MouseHoverOnMatches(matchId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281325", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281321_Verify_Opportunity_Search()
        {
            #region TC_C281321_Verify_Opportunity_Search
            this.TESTREPORT.InitTestCase("TC_C281321_Verify_Opportunity_Search", "Verify_Opportunity_Search");
            #region TestData
            string id = ExcelOperations.GetCellValueFromExcel("TCIdC281321","Opportunityid");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchOpportunity(id);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281321", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281293_Verify_creating_Position_ContactManageScreen()
        {
            #region TC_C281293_Verify_creating_Position_ContactManageScreen
            this.TESTREPORT.InitTestCase("TC_C281293_Verify_creating_Position_ContactManageScreen", "Verify creating Position from Contact Manage Screen");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "InitialStatus");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "Title");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "PlacementGrade");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281293", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281293", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281293", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281293", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281293", "AvailableId"));
            string companyIdAndName = string.Empty;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281293", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281109_Login_User_AccessManagementpopup_Recruiterlogin_Contact()
        {
            #region TC_C281109_Login_User_AccessManagementpopup_Recruiterlogin_Contact
            this.TESTREPORT.InitTestCase("TC_C281109_Login_User_AccessManagementpopup_Recruiterlogin_Contact", "Verify Login as a User in Access Management pop up using Recruiter login for Contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "ContactType");
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281109", "CurrentPassword");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            candidate.SaveandCloseContact();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.GiveAccess(currentPassword);
            company.ValidateElements_ManageLogin(Email);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281109", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281281_Verify_Creating_newPosition_existingCompany()
        {
            #region TC_C281281_Verify_Creating_newPosition_existingCompany
            this.TESTREPORT.InitTestCase("TC_C281281_Verify_Creating_newPosition_existingCompany", "Verify Creating new Position to existing Company");
            #region Testdata
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "InitialStatus");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "Title");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "PlacementGrade");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281281", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy").Replace('-', '/');
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281281", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281281", "AvailableId"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            position.ClickButtonAddPositionFromCompany();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281281", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281322_Verify_Two_Different_Filters_Displayed_Type_And_Stage()
        {
            #region TC_C281322_Verify_Two_Different_Filters_Displayed_Type_And_Stage
            this.TESTREPORT.InitTestCase("TC_C281322_Verify_Two_Different_Filters_Displayed_Type_And_Stage", "Verify_Two_Different_Filters_Displayed_Type_And_Stage");
            #region TestData
            string typefilter = ExcelOperations.GetCellValueFromExcel("TCIdC281322", "TypesFilter");
            string stagefilter = ExcelOperations.GetCellValueFromExcel("TCIdC281322", "StagesFilter");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ClickOnOpportunities();
            home.VerifyTypesFilter(typefilter);
            driver.SwitchToDefaultFrame();
            home.VerifyStagesFilter(stagefilter);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281322", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        /*[TestMethod]
        [TestCategory("Recruiter")]
         //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281190_submitAddhours_Timesheet_Search()
        {
            #region TC_C281190_submitAddhours_Timesheet_Search
            this.TESTREPORT.InitTestCase("TC_C281190_submitAddhours_Timesheet_Search", "Submit from Timesheet Search");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281190", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281190", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281190", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281190", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);

            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.AddHoursthroughTimesheetbysearch();
            accounting.SubmitTimesheetSearch(ApproveSuccess);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281190", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }*/

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281187_ApproveAddhours_Timesheet_Search()
        {
            #region TC_C281187_ApproveAddhours_Timesheet_Search
            this.TESTREPORT.InitTestCase("TC_C281187_ApproveAddhours_Timesheet_Search", "Approve from Timesheet Search");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281187","City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281187", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281187", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281187", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281187", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.AddHoursthroughTimesheetbysearch();
            //accounting.AddhoursthroughTimesheet();
            accounting.SubmitTimesheetSearch(ApproveSuccess);
            //accounting.SubmitTimesheet();
            accounting.ApproveTimesheetSearch();
            //accounting.ApproveTimesheet();
            //matchPage.CreateTimesheets(matchId);
            //driver.SwitchToDefaultFrame();
            //Match.AddhoursTimesheetsearch();
            //Match.SubmitTimesheetrecord();
            //Match.ApproveTimesheetrecord();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281190", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281188_Delete_Timesheet_Search()
        {
            #region TC_C281188_Delete_Timesheet_Search
            this.TESTREPORT.InitTestCase("TC_C281188_Delete_Timesheet_Search", "Delete from Timesheet Search");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281188", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281188","Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281188", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281188", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281188", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.AddHoursthroughTimesheetbysearch();
            accounting.DeleteTimesheetSearch();
            home.Logout();

            // #endregion
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281190", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281289_Verify_Create_Candidate_Applications()
        {
            #region TC_C281289_Verify_Create_Candidate_Applications
            this.TESTREPORT.InitTestCase("TC_C281289_Verify_Create_Candidate_Applications", "Verify Create Candidate Applications");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281289", "ChooseCandidate");
            string position = ExcelOperations.GetCellValueFromExcel("TCIdC281289", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281289", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC281289", "ApplicationSource");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();
            newCandidateApp.CreateCandidateApplication(name, position, applicationNote, source);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281289", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281291_Verify_addingSkills_position()
        {
            #region TC_C281291_Verify_addingSkills_position
            this.TESTREPORT.InitTestCase("TC_C281291_Verify_addingSkills_position", "Verify adding Skills to position");
            #region Testdata
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "InitialStatus");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "Title");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281291","PlacementGrade");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy").Replace('-', '/');
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281291", "FolderGroupId"));
            string skillDropdownValue = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "skillDropdownValue");
            string levelDropdownValue = ExcelOperations.GetCellValueFromExcel("TCIdC281291", "levelDropdownValue");
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281291", "AvailableId"));
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
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            driver.sleepTime(5000);
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            positionPage.AddSkills(skillDropdownValue, levelDropdownValue);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281291", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281346_Verify_Warning_Alert_Message_More_Than_365_days_Add_New_Requirement()
        {
            #region TC_281346_Verify_Warning_Alert_Message_More_Than_365_days_Add_New_Requirement
            this.TESTREPORT.InitTestCase("TC_281346_Verify_Warning_Alert_Message_More_Than_365_days_Add_New_Requirement", "Verify an Alert Message is displayed if Expiration Warning days is more than 365 days on Add New Requirement");
            #region Test Data
            string requirementName = ExcelOperations.GetCellValueFromExcel("TCIdC281346","RequirementName");
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281346", "Type");
            string targetRecordedType = ExcelOperations.GetCellValueFromExcel("TCIdC281346", "TargetRecordedType");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281346", "Weight");
            string expirationWarningdays = ExcelOperations.GetCellValueFromExcel("TCIdC281346", "ExpirationWarningdays");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            controlPanel.VerifyWarningMessageExpire365Days(requirementName, type, targetRecordedType, weight, expirationWarningdays);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281346", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281347_Verify_Warning_Alert_Message_More_Than_365_days_Edit_Requirement()
        {
            #region TC_281347_Verify_Warning_Alert_Message_More_Than_365_days_Edit_Requirement
            this.TESTREPORT.InitTestCase("TC_281347_Verify_Warning_Alert_Message_More_Than_365_days_Edit_Requirement", "Verify an Alert Message is displayed if Expiration Warning days is more than 365 days edit object Requirement");
            #region Test Data
            string requirementName = ExcelOperations.GetCellValueFromExcel("TCIdC281347", "RequirementName");
            string editRequirementName = ExcelOperations.GetCellValueFromExcel("TCIdC281347", "EditRequirementName");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281347", "Weight");
            string expirationWarningdays = ExcelOperations.GetCellValueFromExcel("TCIdC281347", "ExpirationWarningdays");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            driver.sleepTime(5000);
            home.EditRequirement(requirementName, weight, expirationWarningdays, editRequirementName,true,true);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281347", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281351_Verify_Address_While_Cerating_Contact()
        {
            #region TC_281351_Verify_Address_While_Cerating_Contact
            this.TESTREPORT.InitTestCase("TC_281351_Verify_Address_While_Cerating_Contact", "Verify address while creating the contact");
            #region Test Data To Enter Data
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "CompanyNameNew");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "City");
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "PostalCode");
            string folderGroup = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "FolderGroup");
            string companySource = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "CompanySource11");
            #endregion
            #region Verify Test Data
            string mainAddress = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyMainAddress");
            string cityVerify = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyCity");
            string zipCode = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyZipcode");
            string countryVerify = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyCountry");
            string VfolderGroup = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyFolderGroup");
            string contactOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281351", "VerifyContactOwner");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompanyMandatoryFields(companyName, city, postalCode, folderGroup, companySource);
            company.AddContactFromCompany();
            company.VerifyMandatoryFields(mainAddress, cityVerify, zipCode, countryVerify, VfolderGroup, contactOwner);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281351", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281349_Verify_Warning_Message_Position_Selected_Invalid_Agreement()
        {
            #region TC -Verify that a warning message is displayed If the position template selected by the user is associated with an Invalid agreement
            this.TESTREPORT.InitTestCase("TC_281349_Verify_Warning_Message_Position_Selected_Invalid_Agreement", "Verify_Warning_Message_Position_Selected_Invalid_Agreement");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "City");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string companySource = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "SelectCompanySource");
            string selectCompanySource = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "ContactInfo");
            string agreementName = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "AgreementName");
            string legalName = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "LegalName");
            string agreementType = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "AgreementType");
            string billingTerm = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "BillingTerm");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "ContactTitle");
            string CompanyName = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "CompanyName");
            string companyName = CompanyName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "PostalCode");
            string foldergroup = ExcelOperations.GetCellValueFromExcel("TCIdC281349", "FolderGroup");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompanyMandatoryFields(companyName, city, postalCode, foldergroup, companySource);
           // string id = utility.GetTitleId();
            company.AddContactFromCompany();
            candidate.AddAndSaveContact(candidateName, title, Email);
           // candidate.SaveContact();
            company.AddAgreement();
            company.CreateNewAgreement(selectCompanySource, agreementName, legalName, agreementType, billingTerm);
            driver.sleepTime(5000);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyByPassingId();
            driver.sleepTime(10000);
            company.AddPositionTemplate(agreementName,today);
            position.ClickButtonAddPosition();
            company.SelectPostionAndVerify();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281349", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281191_Timesheet_Search_TimesheetID()
        {
            #region TC_C281191_Timesheet_Search_TimesheetID
            this.TESTREPORT.InitTestCase("TC_C281191_Timesheet_Search_TimesheetID", "Search Timesheet Id");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281191", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281191", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281191", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281191", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.ClickOnLogoMenu();
            home.SearchTimeSheetsBYMouseHover(timesheetid);
            accounting.VerifyTimesheetId(timesheetid);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281191", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281138_Verify_Custom_Rules()
        {
            #region TC_C281138_Verify_Custom_Rules
            this.TESTREPORT.InitTestCase("TC_C281138_Verify_Custom_Rules", "Verify Custom Rules");
            #region TestData
            string createRule = ExcelOperations.GetCellValueFromExcel("TCIdC281138", "CreateRule");
            string customRule = ExcelOperations.GetCellValueFromExcel("TCIdC281138", "CustomRule");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.ClickOnCustomrules();
            controlPanel.CreateCustomRules(createRule, customRule);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.ValidateRequiredField();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281138", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281189_Reject_Timesheet_Search()
        {
            #region TC_C281189_Reject_Timesheet_Search
            this.TESTREPORT.InitTestCase("TC_C281189_Reject_Timesheet_Search", "Submit from Timesheet Search");
            #region testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281189", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281189", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281189", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281189", "AvailableId"));
            //string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            //string timesheetid = matchPage.CreateTimesheets(matchId);
            string Type = "single";
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.ClickOnLogoMenu();
            ////home.SearchTimeSheetsBYMouseHover(timesheetid);
            //accounting.TimesheetSearch(timesheetid);
            //accounting.AddHoursthroughTimesheetbysearch();
            //accounting.RejectTimesheetRecord(Type);
            Match.AddhoursTimesheetsearch();
            timesheet.SubmittimesheetforReject();
            accounting.RejectTimesheetRecord(Type);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281189", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281143_Verify_Header_Menu_Candidate()
        {

            #region TC_C281143_Verify_Header_Menu_Candidate
            this.TESTREPORT.InitTestCase("TC_C281143_Verify_Header_Menu_Candidate", "Verify Header Menu" + "");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281143","CandidateUserName");
            string password = ExcelOperations.GetCellValueFromExcel("TCIdC281143", "CandidatePassword1");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281143", "CandidatePassword2");
            #endregion
            home.Login(webURL, CandidateUserName, CandidatePassword);
            candidate.VerifyHeaderCandidate(password, newPassword);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281143", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281144_Verify_Footer_Menu_Candidate()
        {
            #region TC_C281144_Verify_Footer_Menu_Candidate
            this.TESTREPORT.InitTestCase("TC_C281144_Verify_Footer_Menu_Candidate", "Verify Footer Menu");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281144", "CandidateUserName");
            string password = ExcelOperations.GetCellValueFromExcel("TCIdC281144", "CandidatePassword1");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281144", "CandidatePassword2");

            #endregion
            home.Login(webURL, CandidateUserName, CandidatePassword);
            home.RestoreDashboard();
            //home.SelectDashboard();
           //home.SelectDashboard();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281144", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281361_Verify_Recruiter_Set_Milestone_100perc()
        {
            #region TC_C281361_Verify_Recruiter_Set_Milestone_100perc
            this.TESTREPORT.InitTestCase("TC_C281361_Verify_Recruiter_Set_Milestone_100perc", "Verify Recruiter is able to set Milestone 100%");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281361", "ClientProjectName");
            string clientname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string milestone = ExcelOperations.GetCellValueFromExcel("TCIdC281361", "Milestone");
            string milestonename = milestone.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string percent = ExcelOperations.GetCellValueFromExcel("TCIdC281361", "Hunderedpercent");
            string fee = ExcelOperations.GetCellValueFromExcel("TCIdC281361", "Fee");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            clientproject.verifyAddClientProject(clientname);
            string id = ClientProjectPage.id;
            clientproject.SearchClientProject(id);
            clientproject.Milestone100percent(milestonename, percent, fee, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281361", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281363_Verify_Recruiter_Set_Milestone_50perc()
        {
            #region TC_C281363_Verify_Recruiter_Set_Milestone_50perc
            this.TESTREPORT.InitTestCase("TC_C281363_Verify_Recruiter_Set_Milestone_50perc", "Verify Recruiter is able to set Milestone 50%");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281363","ClientProjectName");
            string clientname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string milestone = ExcelOperations.GetCellValueFromExcel("TCIdC281363", "Milestone");
            string milestonename = milestone.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string percent = ExcelOperations.GetCellValueFromExcel("TCIdC281363", "FiftyPercent");
            string fee = ExcelOperations.GetCellValueFromExcel("TCIdC281363", "Fee");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            clientproject.AddClientProject(clientname);
            string id = ClientProjectPage.id;
            clientproject.SearchClientProject(id);
            clientproject.Milestone100percent(milestonename, percent, fee, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281363", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281145_Verify_LeftSidebar_Icons_Vendor_Contact()
        {
            #region TC_C281145_Verify_LeftSidebar_Icons_Vendor_Contact
            this.TESTREPORT.InitTestCase("TC_C281145_Verify_LeftSidebar_Icons_Vendor_Contact", "Verify Left Side bar Icons");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.VerifyLeftsidebarIcons();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281145", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281139_Verify_MangeAPIPermissions_Renamed_ManageAPIPermissions()
        {
            #region TC_C281139_Verify_MangeAPIPermissions_Renamed_ManageAPIPermissions
            this.TESTREPORT.InitTestCase("TC_C281139_Verify_MangeAPIPermissions_Renamed_ManageAPIPermissions", "Verify Mange API Permissions is renamed to Manage API Permissions");
            #region TestData
            string manage = ExcelOperations.GetCellValueFromExcel("TCIdC281139", "ManageAPI");
            string renamed = ExcelOperations.GetCellValueFromExcel("TCIdC281139", "RenamedManage");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            controlPanel.ManagePermissions(manage, renamed);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281139", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281140_Verify_MangeAPIPermissions_Reflected_AddPermissions_CandidatePage()
        {
            #region TC_C281140_Verify_MangeAPIPermissions_Reflected_AddPermissions_CandidatePage
            this.TESTREPORT.InitTestCase("TC_C281140_Verify_MangeAPIPermissions_Reflected_AddPermissions_CandidatePage", "Verify the permission Manage API Permissions is reflected in Add Permission dropdown in manage Candidate page");
            #region TestData
            string manage = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "ManageAPI");
            string renamed = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "RenamedManage");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));

            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281140", "FolderGroupId"));
            string actionType = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "ActionType");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "CurrentPassword");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "ActionStatusG");
            string actionStatusR = ExcelOperations.GetCellValueFromExcel("TCIdC281140", "ActionStatusR");
            #endregion
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            //home.SearchCandidate(candidateName);
            company.ManageLogin(true);
            company.ClickOnGiveAccess();
            candidate.ClickPermissionsTab(manage, renamed);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281140", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281286_Verify_system_allows_user_save_samevalue_samecontacttype_multipletimes_ContactDetailscreen()
        {
            #region TC_C281286_Verify_system_allows_user_save_samevalue_samecontacttype_multipletimes_ContactDetailscreen
            this.TESTREPORT.InitTestCase("TC_C281286_Verify_system_allows_user_save_samevalue_samecontacttype_multipletimes_ContactDetailscreen", "Verify system allows user to save same value for same contact type for multiple times in Contact Detail screen");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "Title");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "CommunicationNote");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281286", "ContactType");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            candidate.EditContactMethod(mainPhone, communicationValue, communicationNote);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281286", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281285_Verify_system_allows_user_clickplusbutton_multipletimes_enteringvalue_contactfield_CompanyDetailscreen()
        {
            #region TC_C281285_Verify_system_allows_user_clickplusbutton_multipletimes_enteringvalue_contactfield_CompanyDetailscreen
            this.TESTREPORT.InitTestCase("TC_C281285_Verify_system_allows_user_clickplusbutton_multipletimes_enteringvalue_contactfield_CompanyDetailscreen", "Verify system allows user to click \" + \" button multiple times entering a value in contact field in Company Detail screen");
            #region Testdata
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "Title");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "CommunicationNote");
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281285", "ContactType");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(companyName, city, postalCode, email, url, phoneNumber);
            company.EditContactMethod(mainPhone, communicationValue, communicationNote);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281285", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281352_Verify_user_able_addcontact_eachtype_EditCommunicationMethodswidget_Managecandidatescreen()
        {
            #region TC_C281352_Verify_user_able_addcontact_eachtype_EditCommunicationMethodswidget_Managecandidatescreen
            this.TESTREPORT.InitTestCase("TC_C281352_Verify_user_able_addcontact_eachtype_EditCommunicationMethodswidget_Managecandidatescreen", "Verify that user is able to add contact of each type on Edit Communication Methods widget in Manage candidate screen");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281352", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281352", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281352", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281352", "CommunicationNote");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281352", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281352", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            candidate.AddContactMethod(mainPhone, communicationValue, communicationNote);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281352", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281353_Verify_system_allow_user_save_samevalue_samecontacttype_multipletimes_Managecandidatescreen()
        {
            #region TC_C281353_Verify_system_allow_user_save_samevalue_samecontacttype_multipletimes_Managecandidatescreen
            this.TESTREPORT.InitTestCase("TC_C281353_Verify_system_allow_user_save_samevalue_samecontacttype_multipletimes_Managecandidatescreen", "Verify system allow user to save same value for same contact type for multiple times in Manage candidate screen");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281353", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281353", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281353", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281353", "CommunicationNote");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281353", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281353", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            candidate.EditContactMethod(mainPhone, communicationValue, communicationNote,true);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281353", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281336_Verify_Creating_Smart_Form_With_Negative_Values_Integer()
        {
            #region TC - Verify Creating Smart Form With Negative Values Integer
            this.TESTREPORT.InitTestCase("TC-C281336 Verify_Creating_Smart_Form_With_Negative_Values_Integer", "Verify_Creating_Smart_Form_With_Negative_Values_Integer");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281336","SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "NegativeOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "NegativeTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281336", "NegativeThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281336", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281337_Verify_Creating_Smart_Form_With_Positive_Values_Integer()
        {
            #region TC_C281337_Verify_Creating_Smart_Form_With_Positive_Values_Integer
            this.TESTREPORT.InitTestCase("TC_C281337_Verify_Creating_Smart_Form_With_Positive_Values_Integer", "Verify_Creating_Smart_Form_With_Negative_Values_Integer");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281337","SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "PositiveOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "PositiveTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281337", "PositiveThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281337", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281338_Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Integer()
        {
            #region TC_C281338_Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Integer
            this.TESTREPORT.InitTestCase("TC_C281338_Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Integer", "Verify_Creating_Smart_Form_With_Negative_Values_Integer");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281338","SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "NegativeOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "NegativeTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281338", "PositiveThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281338", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281339_Verify_Creating_Smart_Form_With_Negative_Values_Decimal()
        {
            #region TC_C281339 Verify Creating Smart Form With Negative Values Decimal
            this.TESTREPORT.InitTestCase("TC_C281339_Verify_Creating_Smart_Form_With_Negative_Values_Decimal", "Verify_Creating_Smart_Form_With_Negative_Values_Decimal");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281339","SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "NegativeDecimalOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "NegativeDecimalTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281339", "NegativeDecimalThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281339", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281340_Verify_Creating_Smart_Form_With_Positive_Values_Decimal()
        {
            #region TC_C281340 Verify Creating Smart Form With Negative Values Integer
            this.TESTREPORT.InitTestCase("TC_C281340_Verify_Creating_Smart_Form_With_Positive_Values_Decimal", "Verify_Creating_Smart_Form_With_Positive_Values_Decimal");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281340","SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "PositiveDecimalOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "PositiveDecimalTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281340", "PositiveDecimalThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281340", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281341_Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Decimal()
        {
            #region TC_C281341 - Verify Creating Smart Form With Positive And Negative Values Integer
            this.TESTREPORT.InitTestCase("TC_C281341_Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Decimal", "Verify_Creating_Smart_Form_With_Positive_And_Negative_Values_Decimal");
            #region Test Data
            string form = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "SmartForm");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "FormName");
            string formname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string field = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "Field");
            string prompt = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "Prompt");
            string numone = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "NegativeDecimalOne");
            string numtwo = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "PositiveDecimalTwo");
            string numthree = ExcelOperations.GetCellValueFromExcel("TCIdC281341", "PositiveDecimalThree");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            smartform.CreateSmartForm(form, formname, field, prompt, numone, numtwo, numthree);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281341", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281354_Verify_type_added_recordearlier_value_marked_default_whenadded_firsttime_Company()
        {
            #region TC_C281354_Verify_type_added_recordearlier_value_marked_default_whenadded_firsttime_Company
            this.TESTREPORT.InitTestCase("TC_C281354_Verify_type_added_recordearlier_value_marked_default_whenadded_firsttime_Company", "Verify that if a type has never been added to the record earlier the value will be marked as default when added for first time in Company");
            #region Testdata
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "Title");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "CommunicationNote");
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281354", "ContactType");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(companyName, city, postalcode, email, url, phoneNumber);
            //company.CompanyClose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCompanyById();
            company.VerifyDefaultTypeMarked(mainPhone, communicationValue, communicationNote);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281354", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281355_Verify_type_added_record_earlier_value_marked_default_added_firsttime_Contact()
        {
            #region TC_C281355_Verify_type_added_record_earlier_value_marked_default_added_firsttime_Contact
            this.TESTREPORT.InitTestCase("TC_C281355_Verify_type_added_record_earlier_value_marked_default_added_firsttime_Contact", "Verify that if a type has never been added to the record earlier the value will be marked as default when added for first time in Contact");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "Title");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "CommunicationNote");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281355", "ContactType");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            candidate.AddCompanytoContact(city);
            candidate.Addtitletocontact(title);
            candidate.AddContactType(contactType);
            candidate.AddMobileNumber();
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            //candidate.SaveandCloseContact();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchContact();
            candidate.VerifyDefaultTypeMarked(mainPhone, communicationValue, communicationNote);           
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281355", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281356_Verify_Display_PhoneNumber_ContactMethods_Candidate()
        {
            #region TC_C281356_Verify_display_PhoneNumber_ContactMethods_Candidate
            this.TESTREPORT.InitTestCase("TC_C281356_Verify_display_PhoneNumber_ContactMethods_Candidate", "Verify display of Phone Number in Contact Methods of a Candidate");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281356", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281356", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281356", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281356", "CommunicationNote");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281356", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281356", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            candidate.VerifyDisplayPhoneNumber(mainPhone, communicationValue);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281356", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SmartForms.csv", "SmartForms#csv", DataAccessMethod.Sequential), DeploymentItem("SmartForms.csv")]
        public void TC_C281342_Verify_Smart_Form_Response_V4_Search_Cooltip_For_A_Form()
        {
            #region TC_C281342_Verify_Smart_Form_Response_V4_Search_Cooltip_For_A_Form
            this.TESTREPORT.InitTestCase("TC_C281342_Verify_Smart_Form_Response_V4_Search_Cooltip_For_A_Form", "Verify_Smart_Form_Response_V4_Search_Cooltip_For_A_Form");
            #region Test Data

            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            smartform.ClickOnSmartForm();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281342", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281290_Verify_Create_Position_Simple()
        {
            #region TC_C281290_Verify_Create_Position_Simple
            this.TESTREPORT.InitTestCase("TC_C281290_Verify_Create_Position_Simple", "Verify Create Position(simple)");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281290", "CompanyName1");
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
            string status = TestRailIntegration.PublishResultsToTestRail("C281290", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281284_Verify_Added_ErecruitCompany_displayed_Seedmanagepage()
        {
            #region TC_C281284_Verify_Added_ErecruitCompany_displayed_Seedmanagepage
            this.TESTREPORT.InitTestCase("TC_C281284_Verify_Added_ErecruitCompany_displayed_Seedmanagepage", "Verify Added Erecruit Company is displayed on Seed manage page");
            #region Testdata
            string firstName = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "FirstName");
            string lastName = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "LastName");
            string lName = lastName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string createdThrough = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "CreatedThrough");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281284", "CommunicationNote");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToNewSeed();
            string selectedValue = seed.AddNewSeed(firstName, lName, createdThrough, mainPhone, communicationValue, communicationNote);
            seed.VerifySeedCompanyValue(selectedValue);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281284", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281294_Verify_Recruiter_Login_Invalid_Credentials()
        {
            #region TC_C281294_Verify_Recruiter_Login_Invalid_Credentials
            this.TESTREPORT.InitTestCase("TC_C281294_Verify_Recruiter_Login_Invalid_Credentials", "Verify Login (With In-valid Credentials) - Recruiter");
            #region Testdata
            string validUserName = ExcelOperations.GetCellValueFromExcel("TCIdC281294", "ValidUserName");
            string inValidUserName = ExcelOperations.GetCellValueFromExcel("TCIdC281294", "InValidUserName");
            string validPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281294", "ValidPassword");
            string inValidPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281294", "InValidPassword");
            #endregion
            home.LoginWithInValidCredentials(webURL, validUserName, inValidPassword);
            home.LoginWithInValidCredentials(webURL, inValidUserName, validPassword);
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281294", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281393_Verify_updating_FolderGroup_ManageFoldergroups_page()
        {
            #region TC_C281393_Verify_updating_FolderGroup_ManageFoldergroups_page
            this.TESTREPORT.InitTestCase("TC_C281393_Verify_updating_FolderGroup_ManageFoldergroups_page", "Verify updating the Folder Group in Manage Folder groups page");
            #region Testdata
            string folderGroups = ExcelOperations.GetCellValueFromExcel("TCIdC281393", "FolderGroups");
            string newFolderGroup = ExcelOperations.GetCellValueFromExcel("TCIdC281393", "NewFolderGroup");
            string newFolderName = ExcelOperations.GetCellValueFromExcel("TCIdC281393", " NewFolderName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnFolderGroups(folderGroups);
            localization.UpdateFolderGroups(newFolderGroup, newFolderName);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281393", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281394_Verify_adding_NewFolderGroupStatus_ManageFolderGroupStatuses_page()
        {
            #region TC_C281394_Verify_adding_NewFolderGroupStatus_ManageFolderGroupStatuses_page
            this.TESTREPORT.InitTestCase("TC_C281394_Verify_adding_NewFolderGroupStatus_ManageFolderGroupStatuses_page", "Verify adding New Folder Group Status in Manage Folder Group Statuses page");
            #region Testdata
            string folderGroupStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281394","FolderGroupStatus");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281394", "FolderName");
            string folderName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string sortby = ExcelOperations.GetCellValueFromExcel("TCIdC281394","Sortby");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnFolderGroupStatus(folderGroupStatus);
            localization.AddFolderGroupStatus(folderName, sortby);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281394", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281395_Verify_deleting_FolderGroupStatus_ManageFolderGroupStatuses_page()
        {
            #region TC_C281395_Verify_deleting_FolderGroupStatus_ManageFolderGroupStatuses_page
            this.TESTREPORT.InitTestCase("TC_C281395_Verify_deleting_FolderGroupStatus_ManageFolderGroupStatuses_page", "Verify deleting Folder Group Status in Manage Folder Group Statuses page");
            #region Testdata
            string folderGroupStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281395", "FolderGroupStatus");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281395", "FolderName");
            string folderName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string sortby = ExcelOperations.GetCellValueFromExcel("TCIdC281395", "Sortby");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnFolderGroupStatus(folderGroupStatus);
            localization.AddFolderGroupStatus(folderName, sortby);
            localization.DeleteFolderGroupStatus(folderName);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281395", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281391_Verify_Departmenttree_shown_ResumeBoardLoginscreen_without_anyerrors()
        {
            #region TC_C281391_Verify_Departmenttree_shown_ResumeBoardLoginscreen_without_anyerrors
            this.TESTREPORT.InitTestCase("TC_C281391_Verify_Departmenttree_shown_ResumeBoardLoginscreen_without_anyerrors", "Verify if Department tree is shown in Resume Board Login screen without any errors");
            #region Testdata
            string resumeBoardLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281391","ResumeBoardLogin");
            string departmentLabel = ExcelOperations.GetCellValueFromExcel("TCIdC281391","DepartmentLabel");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnResumeBoardLogin(resumeBoardLogin);
            localization.VerifyDepartmentTree(departmentLabel);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281391", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281385_Verify_Mange_AgreementTypes_Screenbehavior_ControlPanel()
        {
            #region TC_C281385_Verify_Mange_AgreementTypes_Screenbehavior_ControlPanel
            this.TESTREPORT.InitTestCase("TC_C281385_Verify_Mange_AgreementTypes_Screenbehavior_ControlPanel", "Verify Manage Agreement Types screen behavior in Control Panel");
            #region TestData
            string Agreement = ExcelOperations.GetCellValueFromExcel("TCIdC281385", "AgreementType");
            string sText = ExcelOperations.GetCellValueFromExcel("TCIdC281385", "SortText");
            string sortText = sText.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            controlPanel.ClickAgreementTypes(Agreement, sortText);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281385", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281386_Verify_Deleting_AgreementTypes_from_Manage_AgreementTypeScreen()
        {
            #region TC_C281386_Verify_Deleting_AgreementTypes_from_Manage_AgreementTypeScreen
            this.TESTREPORT.InitTestCase("TC_C281386_Verify_Deleting_AgreementTypes_from_Manage_AgreementTypeScreen", "Verify Deleting Agreement types from Manage Agreement Types screen");
            #region TestData
            string Agreement = ExcelOperations.GetCellValueFromExcel("TCIdC281386", "AgreementType");
            string sText = ExcelOperations.GetCellValueFromExcel("TCIdC281386", "SortText");
            string sortText = sText.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));

            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            controlPanel.ClickAgreementTypes(Agreement, sortText);
            controlPanel.DeleteAgreementTypes();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281386", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281387_Verify_Editing_Agreement_Types_from_Manage_Agreement_screen()
        {
            #region TC_C281387_Verify_Editing_Agreement_Types_from_Manage_Agreement_screen
            this.TESTREPORT.InitTestCase("TC_C281387_Verify_Editing_Agreement_Types_from_Manage_Agreement_screen", "Verify Editing Agreement types from Manage Agreement Types screen");
            #region TestData
            string Agreement = ExcelOperations.GetCellValueFromExcel("TCIdC281387", "AgreementType");
            string EditAgreement = ExcelOperations.GetCellValueFromExcel("TCIdC281387", "EditAgreement");
            string sText = ExcelOperations.GetCellValueFromExcel("TCIdC281387", "SortText");
            string sortText = sText.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            controlPanel.ClickAgreementTypes(Agreement, sortText);
            controlPanel.VerifyAddedAgreementTypes(EditAgreement);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281387", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281397_Verify_creating_newagreement_and_generatingdocument()
        {
            #region TC_C281397_Verify_creating_newagreement_and_generatingdocument
            this.TESTREPORT.InitTestCase("TC_C281397_Verify_creating_newagreement_and_generatingdocument", "Verify creating new agreement and generating document");
            #region Testdata
            string agreementName = ExcelOperations.GetCellValueFromExcel("TCIdC281397", "AgreementName");
            string agreement = ExcelOperations.GetCellValueFromExcel("TCIdC281397", "Agreement");
            string attachmentValue = ExcelOperations.GetCellValueFromExcel("TCIdC281397", "AttachmentValue");
            string attachmentName = ExcelOperations.GetCellValueFromExcel("TCIdC281397","AttachmentName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.ClickOnAgreement();
            localization.CreateAgreement(agreementName);
            localization.GenerateDocument(agreement, attachmentValue, attachmentName);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281397", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281398_Verify_Matchtype_CustomRulesscreen()
        {
            #region TC_C281398_Verify_Matchtype_CustomRulesscreen
            this.TESTREPORT.InitTestCase("TC_C281398_Verify_Matchtype_CustomRulesscreen", "Verify Match type in Custom Rules screen");
            #region Testdata
            string customRules = ExcelOperations.GetCellValueFromExcel("TCIdC281398", "CustomRules");
            string MatchType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281398", "MatchType1");
            string MatchType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281398", "MatchType2");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCustomRules(customRules);
            localization.VerifyMatchTypeCustomRules(MatchType1, MatchType2);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281398", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281206_Timesheet_With_Expenses()
        {
            #region TC_C281206_Timesheet_With_Expenses
            this.TESTREPORT.InitTestCase("TC_C281206_Timesheet_With_Expenses", "Timesheet with Expenses");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281206", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "Load");
            string unit = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "UnitExpense");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281206", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281206", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281206", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "",false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheetswithExpenses(matchId, paid, billed, load, unit);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281206", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
      //  //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281209_Timesheet_Creation_TimeEnabled()
        {
            #region TC_C281209_Timesheet_Creation_TimeEnabled
            this.TESTREPORT.InitTestCase("TC_C281209_Timesheet_Creation_TimeEnabled", "Timesheet creation for a Candidate with Time enabled");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281209", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "Load");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281209", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281209", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281209", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);

            string timesheetid = matchPage.CreateTimesheetswithTimeenables(matchId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281209", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281412_Verify_Leaderboardwidget_pullingdata()
        {
            #region TC_C281412_Verify_Leaderboardwidget_pullingdata
            this.TESTREPORT.InitTestCase("TC_C281412_Verify_Leaderboardwidget_pullingdata", "Verify Leaderboard widget is pulling data");
            #region Testdata
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281412", "WidgenetName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            localization.VerifyLeaderboardWidget();
            dashboard.CloseWidgets();
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281412", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281438_Verify_If_globallycached_canbe_cleared_manually()
        {
            #region TC_C281438_Verify_If_globallycached_canbe_cleared_manually
            this.TESTREPORT.InitTestCase("TC_C281438_Verify_If_globallycached_canbe_cleared_manually", "Verify If globally cached can be cleared manually");
            #region Testdata
            string cache = ExcelOperations.GetCellValueFromExcel("TCIdC281438", "Cache");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCache(cache);
            localization.DeleteCacheItems();
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281438", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281392_Verify_deleting_DHPcredentialingrequest()
        {
            #region TC_C281392_Verify_deleting_DHPcredentialingrequest
            this.TESTREPORT.InitTestCase("TC_C281392_Verify_deleting_DHPcredentialingrequest", "Verify deleting DHP credentialing request");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "MailID");
            string departmentValue = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "DepartmentValue");
            string classification = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "Classification");
            string tier = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "Tier");
            string ptype = ExcelOperations.GetCellValueFromExcel("TCIdC281392", "Ptype");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281392", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.Clickonclose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateId();
            localization.DeleteDHPCredentialingRequest(departmentValue, classification, tier, ptype);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281392", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recuriter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281232_Verify_status_AddCredentialingwidget()
        {
            #region TC_C281232_Verify_status_AddCredentialingwidget
            this.TESTREPORT.InitTestCase("TC_C281232_Verify_status_AddCredentialingwidget", "Verify the status in Add Credentialing widget");
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
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            search.AddCredentialingRequest(departmentValue, ptype, folderGroupValue, company);
            search.VerifyCompleteStatus();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281232", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recuriter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281233_Verify_CredentialingRequest_status_Completed()
        {

            #region TC_C281233_Verify_CredentialingRequest_status_Completed
            this.TESTREPORT.InitTestCase("TC_C281233_Verify_CredentialingRequest_status_Completed", "Verify Credentialing Request status to Completed");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "MailID");
            string departmentValue = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "DepartmentValue");
            string classification = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "Classification");
            string tier = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "Tier");
            string ptype = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "Ptype");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281233", "FolderGroupId"));
            string folderGroupValue = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "FolderGroup");
            string company = ExcelOperations.GetCellValueFromExcel("TCIdC281233", "CompanyName1");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //candidate.Clickonclose();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateId();
            search.AddCredentialingRequest(departmentValue, ptype, folderGroupValue, company);
            search.VerifyStatus();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281233", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281426_Verify_DropDownfields_behavior_DesignDashboardsscreen()
        {
            #region TC_C281426_Verify_DropDownfields_behavior_DesignDashboardsscreen
            this.TESTREPORT.InitTestCase("TC_C281426_Verify_DropDownfields_behavior_DesignDashboardsscreen", "Verify Drop Down fields behavior in Design Dashboards screen.");
            #region Testdata
            string designDashboard = ExcelOperations.GetCellValueFromExcel("TCIdC281426", "DesignDashboard");
            string wName = ExcelOperations.GetCellValueFromExcel("TCIdC281426", "WidgetName");
            string widgetName = wName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickDesignDashboard(designDashboard);
            localization.VerifyFieldsBehavoir(widgetName);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281426", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281343_Verify_View_Smart_Forms()
        {
            #region TC_C281343_Verify_View_Smart_Forms
            this.TESTREPORT.InitTestCase("TC_C281343_Verify_View_Smart_Forms", "Verify_View_Smart_Forms");
            #region Test Data

            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            smartform.ClickOnSmartForm();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281343", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Candidate")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281440_Verify_Candidate_Login_Invalid_Credentials()
        {
            #region TC_C281440_Verify_Candidate_Login_Invalid_Credentials_Candidate
            this.TESTREPORT.InitTestCase("TC_C281440_Verify_Candidate_Login_Invalid_Credentials_Candidate", "Verify Login (With In-valid Credentials) - Candidate");
            #region Testdata
            string validUserName = ExcelOperations.GetCellValueFromExcel("TCIdC281440", "ValidUserName");
            string inValidUserName = ExcelOperations.GetCellValueFromExcel("TCIdC281440", "InValidUserName");
            string validPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281440", "ValidPassword");
            string inValidPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281440", "InValidPassword");
            #endregion
            home.LoginWithInValidCredentials(webURL, validUserName, inValidPassword);
            home.LoginWithInValidCredentials(webURL, inValidUserName, validPassword);
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281440", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion

        }

        [TestMethod]
        [TestCategory("Candidate")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281151_Search_With_Valid_Candidate_ID()
        {
            #region TC_C281151_Search_With_Valid_Candidate_ID
            this.TESTREPORT.InitTestCase("TC_C281151_Search_With_Valid_Candidate_ID", "Search_With_Valid_Candidate_ID");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281151", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281151", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281151", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.NavigateToAddCandidate();
            candidate.CreateCandidateWithoutResumeInVendorContact(candidateName, candidateName, phoneNumber, Email);
            candidate.Clickonclose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateId();
            driver.sleepTime(10000);
            home.HandleAlert();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281151", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion

        }

        #region Email&Templates

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281369_Ensure_Related_Tasks_Widget_Prompt_Does_Not_Include_Completed_Tasks()
        {
            #region TC_Verify_Add_Task
            this.TESTREPORT.InitTestCase("TC_C281369_Ensure_Related_Tasks_Widget_Prompt_Does_Not_Include_Completed_Tasks", "Ensure_Related_Tasks_Widget_Prompt_Does_Not_Include_Completed_Tasks");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281369","CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281369", "MailID");
            string task = ExcelOperations.GetCellValueFromExcel("TCIdC281369", "TaskName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281369", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //string ID = AddCandidatePage.id;
            //home.SearchCandidate(ID);
            //search.ClickOnCandidateLink();
            candidate.AddTask(task);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281369", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }
        #endregion

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281323_Verify_Naming_Format_For_Stage_Values_In_List_Correct()
        {
            #region TC_C281323_Verify_Naming_Format_For_Stage_Values_In_List_Correct
            this.TESTREPORT.InitTestCase("TC_C281323_Verify_Naming_Format_For_Stage_Values_In_List_Correct", "Verify_Naming_Format_For_Stage_Values_In_List_Correct");
            #region TestData
            // string typefilter = ExcelOperations.GetCellValueFromExcel("TypesFilter");
            string stagefilter = ExcelOperations.GetCellValueFromExcel("TCIdC281323", "StagesFilter");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ClickOnOpportunities();          
            home.VerifyStagesFilter(stagefilter);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281323", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281324_Verify_List_Values_From_Stage_Filter_Based_On_Associated_Type_Filter()
        {
            #region TC_C281324 Verify_List_Values_From_Stage_Filter_Based_On_Associated_Type_Filter
            this.TESTREPORT.InitTestCase("TC_C281324_Verify_List_Values_From_Stage_Filter_Based_On_Associated_Type_Filter", "Verify_List_Values_From_Stage_Filter_Based_On_Associated_Type_Filter");
            #region TestData
            string typefilter = ExcelOperations.GetCellValueFromExcel("TCIdC281324","TypesFilter");
            string stagefilter = ExcelOperations.GetCellValueFromExcel("TCIdC281324", "StagesFilter");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ClickOnOpportunities();
            home.VerifyTypesFilter(typefilter);
            driver.SwitchToDefaultFrame();
            home.VerifyStagesFilter(stagefilter);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281324", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281379_Rejecting_Match_Company()
        {
            #region TC_C281379_Rejecting_Match_Company
            this.TESTREPORT.InitTestCase("TC_C281379_Rejecting_Match_Company", "Verify Rejecting Match as Company");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281379", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "Load");
            string RejectedBy = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "RejectCompany");
            string RejectReason = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "RejectResonCompany");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281379", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281379", "AvailableId"));
            string matchId = timesheet.RejectMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, RejectedBy, RejectReason, billRate, payRate, statusId);
            //  string timesheetid = matchPage.CreateTimesheetswithTimeenables(matchId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281379", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281303_Verify_Logo_Menu()
        {
            #region TC_C281303_Verify_Logo_Menu
            this.TESTREPORT.InitTestCase("TC_C281303_Verify_Logo_Menu", "Verify Logo Menu");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnCandidate();
            driver.sleepTime(5000);
            home.SearchCandidate();
            home.NavigateToAddCandidate();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAccounting();
            home.MouseHoverOnCreateTimesheet();
            home.ClickOnOneTimesheet();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            reports.NavigateToReportsLink();                       
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281303", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281304_Verify_Header_Menu()
        {
            #region TC_C281304_Verify_Header_Menu
            this.TESTREPORT.InitTestCase("TC_C281304_WEB_Verify_Header_Menu", "Verify Footer Menu");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.VerifyHeader();
            home.verifyMyCallPlanner();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281304", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281184_Verify_Header_Menu_VendorManager()
        {
            #region TC_C281184_Verify_Header_Menu_VendorManager
            this.TESTREPORT.InitTestCase("TC_C281184_Verify_Header_Menu_VendorManager", "Verify Header Menu");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            home.VerifyHeader();
            home.verifyMyCallPlanner();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281184", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281302_Verify_LeftSidebar_Icons()
        {
            #region TC_C281302_Verify_LeftSidebar_Icons
            this.TESTREPORT.InitTestCase("TC_C281302_Verify_LeftSidebar_Icons", "Verify Left Side bar Icons");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.VerifyLeftsidebarIcons();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281302", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281157_Verify_Header_Menu_VendorContact()
        {
            #region TC_C281157_Verify_Header_Menu_VendorContact
            this.TESTREPORT.InitTestCase("TC_C281157_WEB_Verify_Header_Menu_VendorContact", "Verify Header Menu" + "");

            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.VerifyHeader();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281157", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Candidate")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281146_Verify_the_Dashboard()
        {
            #region TC_C281146_Verify_the_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281146_Verify_the_Dashboard", "Verify the Dashboard");
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281146", "WidgenetName");
            string candidateUserName = ExcelOperations.GetCellValueFromExcel("TCIdC281146", "CandidateUserName");
            string candidatePassword = ExcelOperations.GetCellValueFromExcel("TCIdC281146", "CandidatePassword");
            #region Recruiter
            home.Login(webURL, CandidateUserName, CandidatePassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            //localization.VerifyLeaderboardWidget();
            localization.VerifyCurrentPlacementWedget();
            dashboard.CloseWidgets();
            home.Logout();
            #endregion
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281146", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281142_Verify_Customizing_existing_Dashboard()
        {
            #region TC_C281142_Verify_Customizing_existing_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281142_Verify_Customizing_existing_Dashboard", "Verify Modify Existing Dashboard");
            #region Testdata
            string dashBoardValue = ExcelOperations.GetCellValueFromExcel("TCIdC281142","DashBoardValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ModifyDashboard(dashBoardValue);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281142", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281158_Verify_Footer_Menu_Vendor_Contact()
        {
            #region TC_C281158_Verify_Footer_Menu_Vendor_Contact
            this.TESTREPORT.InitTestCase("TC_C281158_Verify_Footer_Menu_Vendor_Contact", "Verify Footer Menu");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.RestoreDashboard();
            //home.SelectDashboard();            
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281158", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281159_Verify_Dashboard()
        {
            #region TC_C281159_Verify_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281159_Verify_Dashboard", "Verify Dashboard");

            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281159", "WidgenetName");
            #region Recruiter
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            localization.VerifyLeaderboardWidget();
            dashboard.CloseWidgets();
            home.Logout();
            #endregion
            #region Vendor
            home.Login(webURL, vendorContactName, vendorContactPassword);
            dashboard.VerifyAddWidgetsInVendor();
            home.Logout();
            home.HandleAlert();
            #endregion
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281159", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281181_Verify_VendorManager_Add_Widgets()
        {
            #region TC_C281181_Verify_Add_Widgets
            this.TESTREPORT.InitTestCase("TC_C281181_Verify_Add_Widgets", "Verify Add Widgets");
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.SelectWidgetAndZoneForVendorManager();
            dashboard.ClickOnAddWidgetButton();
            driver.sleepTime(5000);
            dashboard.VerifyAddWidget();
            dashboard.ClickOnSubmit();
            dashboard.VerifyAddWidget();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281181", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281182_Verify_LeftSidebar_Icons_Vendor_Manager()
        {
            #region TC_C281182_Verify_LeftSidebar_Icons_Vendor_Manager
            this.TESTREPORT.InitTestCase("TC_C281182_Verify_LeftSidebar_Icons_Vendor_Manager", "Verify Left Side bar Icons");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.VerifyLeftsidebarIcons();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281182", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281185_Verify_Footer_Menu_Vendor_Manager()
        {
            #region TC_C281185_Verify_Footer_Menu_Vendor_Manager
            this.TESTREPORT.InitTestCase("TC_C281185_Verify_Footer_Menu_Vendor_Manager", "Verify Footer Menu");
            home.Login(webURL, vendorContactName, vendorContactPassword);
            home.RestoreDashboard();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281185", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281270_contractMatch()
        {
            #region TC_C281270_contractMatch
            this.TESTREPORT.InitTestCase("TC_C281270_contractMatch", "Verify Footer Menu");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281270", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281270", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281270", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281270", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281270", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281288_Verify_Add_Contract_Type_Position()
        {
            #region TC_C281288_Verify_Add_Contract_Type_Position
            this.TESTREPORT.InitTestCase("TC_C281288_Verify_Add_Contract_Type_Position", "Verify Add Contract type Position");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281288", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281288", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            string positionSearchname = ExcelOperations.GetCellValueFromExcel("TCIdC281288", "PositionSearchname");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281288", "AvailableId"));
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
            //home.NavigateToAddPosition();
            //searchposition.ClickOnPositionLink();
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate, true);
            positionPage.VerifyPositionTitle();
            searchPage.EnterSearchName(positionSearchname);
            positionPage.VerifyPositionTitle();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281288", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281301_Verify_Recruiter_Add_Widgets()
        {
            #region TC_C281301_Verify_Add_Widgets
            this.TESTREPORT.InitTestCase("TC_C281301_Verify_Add_Widgets", "Verify Add Widgets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.SelectWidgetAndZoneForRecruiter();
            dashboard.ClickOnAddWidgetButton();
            dashboard.VerifyAddedWidgetInRecruiter();
            dashboard.CloseWidgets();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281301", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281314_Verify_Quick_Search_With_Atleast_3orMore_Letters()
        {
            #region TC_C281314_Verify_Quick_Search_With_Atleast_3orMore_Letters
            this.TESTREPORT.InitTestCase("TC_C281314_Verify_Quick_Search_With_Atleast_3orMore_Letters", "Verify Quick Search with atleast 3 or more letters - combination of alphabets and dot");
            #region Testdata
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281314", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281314", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume("Tes.t", foldergroup, mailID);
            searchPage.EnterSearchName("Tes.t");
            searchPage.VerifySearchPageTitle();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281314", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281315_Verify_Quick_search_box_with_atleast_2_Words_combination_of_alphabets_and_dot()
        {
            #region TC_C281315_Verify_Quick_search_box_with_atleast_2_Words_combination_of_alphabets_and_dot
            this.TESTREPORT.InitTestCase("TC_C281315_Verify_Quick_search_box_with_atleast_2_Words_combination_of_alphabets_and_dot", "Verify Quick search box with atleast 2 Words (combination of alphabets and dot)");
            #region Test Data
            string CandidateSearchName = ExcelOperations.GetCellValueFromExcel("TCIdC281315", "CandidateSearchName");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281315", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281315", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(CandidateSearchName, foldergroup, mailID);
            searchPage.EnterSearchName(CandidateSearchName);
            searchPage.VerifySearchPageTitle();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281315", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281316_Verify_Candidate_Search()
        {
            #region TC_C281316_Verify_Candidate_Search

            this.TESTREPORT.InitTestCase("TC_C281316_Verify_Candidate_Search", "Add New Candidate Without Resume");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281316", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281316", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281316", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            candidate.Clickonclose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateId();
            candidate.VerifyNewlyAddedContact();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281316", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281317_Verify_Company_Search()
        {
            #region TC_C281317_Verify_Company_Search
            this.TESTREPORT.InitTestCase("TC_C281317_Verify_Company_Search", "Verify Search Company");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "City");
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "PostalCode");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281317", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(name, city, postalcode, email, url, phoneNumber);
            company.CompanyClose();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyById();
            candidate.VerifyNewlyAddedContact();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281317", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281319_Verify_Position_Search()
        {
            #region TC_C281319_Verify_Position_Search
            this.TESTREPORT.InitTestCase("TC_C281319_Verify_Position_Search", "Verify Search Company");
            string id = "221630";
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            home.SearchPosition(id);
            searchposition.CheckPosition();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281319", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281305_Verify_Footer_Menu()
        {
            #region TC_C281305_Verify_Footer_Menu
            this.TESTREPORT.InitTestCase("TC_C281305_Verify_Footer_Menu", "Verify Footer Menu");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.RestoreDashboard();
            home.SelectDashboard();            
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281305", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281318_Verify_Contact_Search()
        {
            #region TC_C281318_Verify_Contact_Search
            this.TESTREPORT.InitTestCase("TC_C281318_Verify_Contact_Search", "Verify Contact Search");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281318", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281318", "Website");
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
            candidate.VerifyNewlyAddedContact();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281318", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281141_Rejecting_Match_Candidate()
        {
            #region TC_C281141_Rejecting_Match_Candidate
            this.TESTREPORT.InitTestCase("TC_C281141_Rejecting_Match_Candidate", "Verify rejecting a match as Candidate");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281141", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "Load");
            string RejectedBy = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "RejectCandidate");
            string RejectReason = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "RejectReasonCandidate");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281141", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281141", "AvailableId"));
            timesheet.RejectMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, RejectedBy, RejectReason, billRate, payRate, statusId);
            home.HandleAlert();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281141", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281179_Rejecting_Match_VendorManager()
        {
            #region TC_C281179_Rejecting_Match_VendorManager
            this.TESTREPORT.InitTestCase("TC_C281179_Rejecting_Match_VendorManager", "Verify rejecting a match as Vendor Manager");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281179", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "Load");
            string RejectedBy = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "RejectVendor");
            string RejectReason = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "RejectedReasonVendor");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281179", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281179", "AvailableId"));
            string cname = ExcelOperations.GetCellValueFromExcel("TCIdC281361", "ClientProjectName");
            string clientname = cname.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string matchID = "1266745";
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SelectVMS();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.ClickOnSearchMatch();
            accounting.SearchMatch_VendorManager(matchID);
            createMatch.RejectMatch(RejectedBy, RejectReason);
            createMatch.UnRejectMatch();
            //timesheet.RejectMatchVM(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, RejectedBy, RejectReason, billRate, payRate, statusId, clientname);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281179", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281268_Rejecting_Match_Recruiter()
        {
            #region TC_C281268_Rejecting_Match_Recruiter
            this.TESTREPORT.InitTestCase("TC_C281268_Rejecting_Match_Recruiter", "Verify rejecting a match as Recruiter");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281268", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "Load");
            string RejectedBy = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "RejectVendor");
            string RejectReason = ExcelOperations.GetCellValueFromExcel("TCIdC281268", "RejectedReasonVendor");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281268", "AvailableId"));
            string matchId = timesheet.RejectMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, RejectedBy, RejectReason, billRate, payRate, statusId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281268", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }
        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281420_Verify_Create_newRule_field_that_appears_ManageContactscreen()
        {
            #region TC_C281420_Verify_Create_newRule_field_that_appears_ManageContactscreen
            this.TESTREPORT.InitTestCase("TC_C281420_Verify_Create_newRule_field_that_appears_ManageContactscreen", "Verify Create new Rule for field that appears in Manage Contact screen");
            #region Testdata
            string customRules = ExcelOperations.GetCellValueFromExcel("TCIdC281420", "CustomRules");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281420", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ContactCustomRule = ExcelOperations.GetCellValueFromExcel("TCIdC281420", "ContactCustomRule");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCustomRules(customRules);
            localization.AddContactCustomRules();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddContact();
            candidate.AddContact(candidateName);
            localization.VerifyContactCustomRule();
            localization.DeleteContactCustomRule(ContactCustomRule);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281420", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281419_Verify_Manage_TravelStatusesscreen_works_like_beforewith_newcodechange()
        {
            #region TC_C281419_Verify_Manage_TravelStatusesscreen_works_like_beforewith_newcodechange
            this.TESTREPORT.InitTestCase("TC_C281419_Verify_Manage_TravelStatusesscreen_works_like_beforewith_newcodechange", "Verify Manage Travel Statuses screen works like before with new code change");
            #region Testdata
            string travelStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281419", "TravelStatus");
            string sortorder = ExcelOperations.GetCellValueFromExcel("TCIdC281419", "Sortorder");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281419", "StatusName");
            string statusName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickTravelStatus(travelStatus);
            localization.AddTravelStatus(statusName, sortorder);
            localization.EditTravelStatus(statusName);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281419", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281417_Verify_behavior_Datepicker_Managecandidatescreen()
        {
            #region TC_C281417_Verify_behavior_Datepicker_Managecandidatescreen
            this.TESTREPORT.InitTestCase("TC_C281417_Verify_behavior_Datepicker_Managecandidatescreen", "Verify behavior of Date picker in Manage candidate screen");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281417", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281417", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281417", "FolderGroupId"));
            string newDate = DateTime.Now.AddDays(7).ToString("dd/M/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            localization.VerifyDatePicker(newDate);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281417", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281411_Verify_MyActivePlacementswidget_pulling_data()
        {
            #region TC_C281411_Verify_MyActivePlacementswidget_pulling_data
            this.TESTREPORT.InitTestCase("TC_C281411_Verify_MyActivePlacementswidget_pulling_data", "Verify My Active Placements widget is pulling data.");
            #region Testdata
            string designDashboard = ExcelOperations.GetCellValueFromExcel("TCIdC281411", "DesignDashboard");
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281411", "WidgetName1");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickDesignDashboard(designDashboard);
            localization.VerifyFieldsBehavoir(widgenetName);
            //Click on Dashboard rightside
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            localization.VerifyMyActivePlacementWidget();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281411", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281441_AddWidgetVMS_ActiveMilestones_ActiveSubmittals_CurrentlyWorking_OpenPositions_PendingApprovals_UnscreenedSubmittals()
        {
            #region TC_C281441_AddWidgetVMS_ActiveMilestones_ActiveSubmittals_CurrentlyWorking_OpenPositions_PendingApprovals_UnscreenedSubmittals
            this.TESTREPORT.InitTestCase("TC_C281441_AddWidgetVMS_ActiveMilestones_ActiveSubmittals_CurrentlyWorking_OpenPositions_PendingApprovals_UnscreenedSubmittals", "AddWidgetVMS_ActiveMilestones_ActiveSubmittals_CurrentlyWorking_OpenPositions_PendingApprovals_UnscreenedSubmittals");
            #region Testdata
            string Widget_ActiveMilestones = ExcelOperations.GetCellValueFromExcel("TCIdC281441", "Widget_ActiveMilestones");
            string Widget_ActiveSubmittals = ExcelOperations.GetCellValueFromExcel("TCIdC281441", "Widget_ActiveSubmittals");
            string Widget_CurrentlyWorking = ExcelOperations.GetCellValueFromExcel("TCIdC281441", "Widget_CurrentlyWorking");
            string Widget_OpenPositions = ExcelOperations.GetCellValueFromExcel("TCIdC281441", "Widget_OpenPositions");
            string Widget_PendingApprovals = ExcelOperations.GetCellValueFromExcel("TCIdC281441", " Widget_PendingApprovals");
            string Widget_UnscreenedSubmittals = ExcelOperations.GetCellValueFromExcel("TCIdC281441", " Widget_UnscreenedSubmittals");

            #endregion
            home.Login(webURL, vendorManagerUserName, vendorManagerUserPassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_ActiveMilestones);
            dashboard.CloseWidgets();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_ActiveSubmittals);
            dashboard.CloseWidgets();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_CurrentlyWorking);
            dashboard.CloseWidgets();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_OpenPositions);
            dashboard.CloseWidgets();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_PendingApprovals);
            dashboard.CloseWidgets();
            dashboard.ClickOnModifyDashboard();
            dashboard.VerifyAddWidgetInDashBoard(Widget_UnscreenedSubmittals);
            dashboard.CloseWidgets();
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281441", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281389_Verify_caching_accessing_Recruiters_ControlPanelsection()
        {
            #region TC_C281389_Verify_caching_accessing_Recruiters_ControlPanelsection
            this.TESTREPORT.InitTestCase("TC_C281389_Verify_caching_accessing_Recruiters_ControlPanelsection", "Verify caching on accessing Recruiters in Control Panel section");
            #region Testdata
            string cache = ExcelOperations.GetCellValueFromExcel("TCIdC281389", "Cache");
            string recuriter = ExcelOperations.GetCellValueFromExcel("TCIdC281389", "Recuriter");
            string recuriterdept = ExcelOperations.GetCellValueFromExcel("TCIdC281389", "RecuriterDept");
            string lookupValue = ExcelOperations.GetCellValueFromExcel("TCIdC281389", "LookupValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCache(cache);
            localization.DeleteCacheItems();
            home.Logout();
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnRecuriters(recuriter);
            localization.SelectDepartment(recuriterdept);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCache(cache);
            localization.VerifyCache(lookupValue);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281389", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281253_Verify_Requirement_Shared_With_Other_Records()
        {
            #region TC_C281253_Verify_Requirement_Shared_With_Other_Records
            this.TESTREPORT.InitTestCase("TC_C281253_Verify_Requirement_Shared_With_Other_Records", "Verify Requirement shared with other records");
            #region TestData
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281253", "RequirementName");
            string filterName = ExcelOperations.GetCellValueFromExcel("TCIdC281253", "FilterName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyRequirement(req, filterName);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281253", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\AdminControlPanel.csv", "AdminControlPanel#csv", DataAccessMethod.Sequential), DeploymentItem("AdminControlPanel.csv")]
        public void TC_C281257_Verify_Add_attachments_browse_in_Add_Requirements()
        {
            #region TC_C281257_Verify_Add_attachments_browse_in_Add_Requirements
            this.TESTREPORT.InitTestCase("TC_C281257_Verify_Add_attachments_browse_in_Add_Requirements", "Verify Add attachments browse in Add Requirements");
            #region TestData
            string candidateId = ExcelOperations.GetCellValueFromExcel("TCIdC281257", "CandidateId");
            string ddlType = ExcelOperations.GetCellValueFromExcel("TCIdC281257", "ddlType");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidateWithId(candidateId);
            schedulingPage.RightClickOnRequirements(ddlType);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281257", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281258_Verify_CustomField_added_to_the_requirement_and_displayed_in_RequirementPage()
        {

            #region TC_C281258_Verify_Add_attachments_browse_in_Add_Requirements
            this.TESTREPORT.InitTestCase(" TC_C281258_Verify_CustomField_added_to_the_requirement_and_displayed_in_RequirementPage", "Verify that the custom field is added to the requirement and displayed in Add Requirement page");
            #region TestData
            string customField = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "BusinessList");
            string newCustomField = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "NewCustomField");
            newCustomField = newCustomField.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string customType = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "CustomFieldType");
            string customDataType = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "CustomFieldDataType");
            string addValue = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "AddValue");
            string companyId = ExcelOperations.GetCellValueFromExcel("TCIdC281258", "CompanyId");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyCustomfieldsIsAdded(customField, newCustomField, customType, customDataType, addValue);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ValidateNewCustomField(companyId, newCustomField);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281258", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\AdminControlPanel.csv", "AdminControlPanel#csv", DataAccessMethod.Sequential), DeploymentItem("AdminControlPanel.csv")]
        public void TC_C281259_Verify_user_is_able_to_add_values_selected_from_the_custom_field_with_the_requirement()
        {
            #region TC_C281259_Verify_User_Able_To_Add_Values_Select_From_CustomField
            this.TESTREPORT.InitTestCase(" TC_C281259_Verify_user_is_able_to_add_values_selected_from_the_custom_field_with_the_requirement", "Verify User Able To Add Values Select From CustomField");
            #region TestData
            string customField = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "BusinessList");
            string newCustomField = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "NewCustomField");
            newCustomField = newCustomField.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string customType = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "CustomFieldType");
            string customDataType = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "CustomFieldDataType");
            string addValue = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "AddValue");
            string companyId = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "CompanyId");
            string searchReqTemplate = ExcelOperations.GetCellValueFromExcel("TCIdC281259", "SearchReqTemplate");

            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyCustomfieldsIsAdded(customField, newCustomField, customType, customDataType, addValue);
            driver.sleepTime(10000);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchComapany(companyId);
            home.AddAndSaveRequirement(searchReqTemplate);
            home.RightClickOnReqAndValidate(newCustomField, addValue);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281259", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\AdminControlPanel.csv", "AdminControlPanel#csv", DataAccessMethod.Sequential), DeploymentItem("AdminControlPanel.csv")]
        public void TC_C281263_Verify_user_select_requirement_export_to_excel()
        {

            #region  TC_C281263_Verify_user_select_requirement_export_to_excel()
            this.TESTREPORT.InitTestCase("  TC_C281263_Verify_user_select_requirement_export_to_excel", "Verify that user can Select one or More Requirements at a Time and then Export these to Excel in Requirement search Page");
            #region TestData
            string searchRequirement = ExcelOperations.GetCellValueFromExcel("TCIdC281263", "SearchRequirementName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.SearchRequirementPage(searchRequirement);
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281263", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281344_Verify_ViewOrEdit_Smart_forms_with_having_Manage_smart_form_permissions()
        {

            #region TC_C281344_Verify_ViewOrEdit_Smart_forms_with_having_Manage_smart_form_permissions
            this.TESTREPORT.InitTestCase("TC_C281344_Verify_ViewOrEdit_Smart_forms_with_having_Manage_smart_form_permissions", "Verify_ViewOrEdit_Smart_forms_with_having_Manage_smart_form_permissions");
            #region TestData
            string recruiter = ExcelOperations.GetCellValueFromExcel("TCIdC281344", "Recruiter");
            string smartForm = ExcelOperations.GetCellValueFromExcel("TCIdC281344", "SmartForm");
            string smartFormtxt = ExcelOperations.GetCellValueFromExcel("TCIdC281344", "SmartFormtxt");
            string loginName = ExcelOperations.GetCellValueFromExcel("TCIdC281344", "LoginName");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifySmartForms(recruiter, smartForm, loginName);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.SearchAndEditSmartForms(smartFormtxt);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281344", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281345_Verify_ViewOrEdit_Smart_forms_without_having_Manage_smart_form_permissions()
        {

            #region TC_C281345_Verify_ViewOrEdit_Smart_forms_without_having_Manage_smart_form_permissions
            this.TESTREPORT.InitTestCase("TC_C281345_Verify_ViewOrEdit_Smart_forms_without_having_Manage_smart_form_permissions", " Verify View/ Edit Smart forms without having Manage smart form permissions");
            #region TestData
            string recruiter = ExcelOperations.GetCellValueFromExcel("TCIdC281345", "Recruiter");
            string smartForm = ExcelOperations.GetCellValueFromExcel("TCIdC281345", "SmartForm");
            string loginName = ExcelOperations.GetCellValueFromExcel("TCIdC281345", "LoginName");
            string smartFormtxt = ExcelOperations.GetCellValueFromExcel("TCIdC281345", "SmartFormtxt");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.SearchSmartForms(smartFormtxt);
            driver.sleepTime(5000);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifySmartFormswithoutPermission(recruiter, loginName);
            home.HandleAlert();
            home.VerifySmartFormAbleToEdit();
            home.GiveSmartFormPermission();
            home.HandleAlert();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281345", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281373_Verify_display_of_Accented_Characters_in_first_name_of_the_Candidates()
        {

            #region TC_C281373_Verify_display_of_Accented_Characters_in_first_name_of_the_Candidates
            this.TESTREPORT.InitTestCase("TC_C281373_Verify_display_of_Accented_Characters_in_first_name_of_the_Candidates", "Verify display of  Accented Characters in  first name of the Candidate");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281373", "CandidateNameWithAccent");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281373", "MailID");
            string foldergroup = ExcelOperations.GetCellValueFromExcel("TCIdC281373", "FolderGroupNew");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddcandidateMandatoryWithoutResume(candidateName, foldergroup, mailID);
            driver.sleepTime(5000);
            candidate.VerifyCandidateNameWithAccentedChar(candidateName);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281373", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281329_Verify_that_command_tab_present_saved_search_screen_when_open_saved_search()
        {

            #region TC_C281329_Verify_that_command_tab_present_saved_search_screen_when_open_saved_search
            this.TESTREPORT.InitTestCase("TC_C281329_Verify_that_command_tab_present_saved_search_screen_when_open_saved_search", "Verify that the Commands tab is present on Saved search screen when Recruiter opens Saves search");
            #region TestData
            string searchName = ExcelOperations.GetCellValueFromExcel("TCIdC281329", "SearchName");
            string candidateName = searchName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnCandidate();
            home.SearchSavedCandidate(candidateName);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281329", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\AdminControlPanel.csv", "AdminControlPanel#csv", DataAccessMethod.Sequential), DeploymentItem("AdminControlPanel.csv")]
        public void TC_C281287_Verifyy_Position_Type_Edit_Widget_in_Control_Panel()
        {

            #region TC_C281287_Verify_Position_Type_Edit_Widget_in_Control_Panel
            this.TESTREPORT.InitTestCase("TC_C281287_Verify_Position_Type_Edit_Widget_in_Control_Panel", "Verify Position Type Edit Widget in Control_Panel");
            #region TestData
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281287", "PositionType");
            string errorMsg = ExcelOperations.GetCellValueFromExcel("TCIdC281287", "ErrorMessage");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyPositiontypeEdit(positionType, errorMsg);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281287", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281283_Verify_new_company_record_kept_during_merge_is_displayed_in_companies_and_Parent_Company_filters()
        {
            #region TC_C281283_Verify_new_company_record_kept_during_merge_is_displayed_in_companies_and_Parent_Company_filters
            this.TESTREPORT.InitTestCase("TC_C281283_Verify_new_company_record_kept_during_merge_is_displayed_in_companies_and_Parent_Company_filters", "Verify new company record kept during merge is displayed in companies and Parent Company filters");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "SearchName");
            searchname = searchname.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "City");
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "PostalCode");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mergCompanyName = ExcelOperations.GetCellValueFromExcel("TCIdC281283","MergeCompanyName");
            string searchResult = ExcelOperations.GetCellValueFromExcel("TCIdC281283", "SearchResult");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompany(candidateName, city, postalcode, email, url, phoneNumber);
            string newCreatedcompanyId = company.GetCompanyTitle();
            home.VerifyMergeCompany(mergCompanyName);
            home.HandleAlert();
            driver.sleepTime(5000);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.VerifyCompaniesShowing(newCreatedcompanyId, searchResult);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281283", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281137_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_Education_history_record_in_Candidate_Page()
        {
            #region TC_C281137_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_Education_history_record_in_Candidate_Page
            this.TESTREPORT.InitTestCase("TC_C281137_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_Education_history_record_in_Candidate_Page", "Verify  the changes made on Boolean Custom field  are saving on Education history record in Candidate Page");
            #region TestData
            string candidateId = ExcelOperations.GetCellValueFromExcel("TCIdC281137","CandidateId");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidateWithId(candidateId);
            schedulingPage.RightClickonEducationHistory();
            home.checkBooleanInEducationHistory();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281137", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281211_Timesheet_Creation_Candidate_Time_Expenses_disabled()
        {
            #region TC_C281211_Timesheet_Creation_Candidate_Time_Expenses_disabled
            this.TESTREPORT.InitTestCase("TC_C281211_Timesheet_Creation_Candidate_Time_Expenses_disabled", "Timesheet creation for a Candidate with Time & Expenses disabled");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281211", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "ApproveSuccess");
            string TimesheetError = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "ErrorTimesheet");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281211", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281211", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281211", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);

            // string timesheetid = matchPage.CreateTimesheetwithoutTimeandExpenses(matchId, TimesheetError);
            matchPage.CreateTimesheetwithoutTimeandExpenses(matchId, TimesheetError);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281211", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281217_Timesheet_Creation_Candidate_Providing_Negativerates_Expenses_Timesheets()
        {
            #region TC_C281217_Timesheet_Creation_Candidate_Providing_Negativerates_Expenses_Timesheets
            this.TESTREPORT.InitTestCase("TC_C281217_Timesheet_Creation_Candidate_Providing_Negativerates_Expenses_Timesheets", "Timesheet creation for a Candidate by providing negative Pay rates in Expenses to Timesheets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281217", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "NegativePayfield");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "NegativeBillfield");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "Load");
            string unit = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "UnitExpense");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281217", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281217", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281217", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);

            string timesheetid = matchPage.CreateTimesheetswithExpenses(matchId, paid, billed, load, unit);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281217", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281218_Timesheet_Creation_Candidate_Providing_NegativeUnits_Expenses_Timesheets()
        {
            #region TC_C281218_Timesheet_Creation_Candidate_Providing_NegativeUnits_Expenses_Timesheets
            this.TESTREPORT.InitTestCase("TC_C281218_Timesheet_Creation_Candidate_Providing_NegativeUnits_Expenses_Timesheets", "Timesheet creation for a Candidate by providing negative Units in Expenses to Timesheets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281218", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "Load");
            string unit = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "NegativeUnit");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281218", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281218", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281218", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheetswithExpenses(matchId, paid, billed, load, unit);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281218", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281425_Verify_Manage_EditingShifts_from_Manageshiftstatusesscreen()
        {
            #region TC_C281425_Verify_Manage_EditingShifts_from_Manageshiftstatusesscreen
            this.TESTREPORT.InitTestCase("TC_C281425_Verify_Manage_EditingShifts_from_Manageshiftstatusesscreen", "Verify Manage Editing Shifts from Manage shift statuses screen");
            #region Testdata
            string shiftStatues = ExcelOperations.GetCellValueFromExcel("TCIdC281425", "ShiftStatues");
            string sortorder = ExcelOperations.GetCellValueFromExcel("TCIdC281425", "Sortorder");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281425", "StatusName");
            string statusName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickonShiftStatues(shiftStatues);
            localization.AddShiftStatus(statusName, sortorder);
            localization.EditShiftStatus(statusName);
            home.Logout();


            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281425", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281241_Verify_ShiftCalendar_defaultview()
        {
            #region TC_C281241_Verify_ShiftCalendar_defaultview
            this.TESTREPORT.InitTestCase("TC_C281241_Verify_ShiftCalendar_defaultview", " Verify Shift Calendar default view");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281241", "CompanyName1");
            string currentMonth = DateTime.Now.ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            driver.sleepTime(5000);
            //string id = positionPage.GetPositionTitle();
            //home.SearchPosition(id);
            schedulingPage.PositionScheduling();
            schedulingPage.VerifyCalenderMonth(currentMonth);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281241", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion

        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281136_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_work_history_record_in_Candidate_Page()
        {
            #region TC_C281136_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_work_history_record_in_Candidate_Page
            this.TESTREPORT.InitTestCase("TC_C281136_Verify_the_changes_made_on_Boolean_Custom_field_are_saving_on_work_history_record_in_Candidate_Page", "Verify the changes made on Boolean Custom field are saving on work history record in Candidate Page");
            #region TestData
            string candidateId = ExcelOperations.GetCellValueFromExcel("TCIdC281136", "CandidateId");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidateWithId(candidateId);
            schedulingPage.RightClickonWorkHistory();
            home.checkBooleanInWorkHistory();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281136", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286742_Verify_Add_Tags_Candidate()
        {
            #region TC_C286742_Verify_Add_Tags_Candidate
            this.TESTREPORT.InitTestCase("TC_C286742_Verify_Add_Tags_Candidate", "Verify Add Tags Candidate");
            #region Test Data           
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286742", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286742", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286742", "FolderGroupId"));
            int id = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286742", "TagsID"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.SearchCandidate(name);
            //search.ClickOnCandidateLink();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //string ID = AddCandidatePage.id;
            //driver.SwitchToDefaultFrame();
            //home.SearchCandidate(ID);
            candidate.ClickonTagsEdit(id); 
            
            //home.HandleAlert();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286742", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData - Copy.csv", "TestData - Copy#csv", DataAccessMethod.Sequential), DeploymentItem("TestData - Copy.csv")]
        public void TC_C281134_Verify_that_the_selected_candidate_and_selected_position_that_already_have_the_Candidate_Application()
        {
            #region  TC_C281134_Verify_that_the_selected_candidate_and_selected_position_that_already_have_the_Candidate_Application
            this.TESTREPORT.InitTestCase(" TC_C281134_Verify_that_the_selected_candidate_and_selected_position_that_already_have_the_Candidate_Application", "Verify that the selected candidate and selected position that already have the Candidate Application");
            #region TestData
            string chooseCandidate = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "ChooseCandidate");
            string position = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "ApplicationSource");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "MailID");
            string foldergroup = ExcelOperations.GetCellValueFromExcel("TCIdC281134", "FolderGroup");
            
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddcandidateMandatoryWithoutResume(candidateName, foldergroup, mailID);
            //candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            home.NavigateAndClickCandidateApplication();
            newCandidateApp.CreateCandidateApplication(candidateName, position, applicationNote, source);
            driver.sleepTime(5000);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();            
            newCandidateApp.VerifyExistingCandidate(candidateName);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281134", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281384_Verify_Dashboard()
        {
            #region TC_C281384_Verify_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281384_Verify_Dashboard", "Verify Dashboard");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.VerifyGoalsWidget();
            dashboard.VerifyModifyDashboard();
            dashboard.ClickOnModifyDashboard();
            dashboard.SelectOnWidget(0);
            dashboard.ClickOnAddWidgetButton();
            dashboard.VerifyWidget();
            home.Logout();
            home.HandleAlert();
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
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281216_Create_Reversal_Restatement_Adjustment_Timesheets()
        {
            #region TC_C281216_Create_Reversal_Restatement_Adjustment_Timesheets
            this.TESTREPORT.InitTestCase("TC_C281216_Create_Reversal_Restatement_Adjustment_Timesheets", "Create Reversal and Restatement adjustment timesheets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281216", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "ApproveSuccess");
            string TimesheetError = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "ErrorTimesheet");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281216", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281216", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281216", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281216", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286743_Verify_Add_Scheduled_Item_Candidate_Search_Result()
        {
            #region TC_C286743_Verify_Add_Scheduled_Item_Candidate_Search_Result
            this.TESTREPORT.InitTestCase("TC_C286743_Verify_Add_Scheduled_Item_Candidate_Search_Result", "Verify_Add_Scheduled_Item_Candidate_Search_Result");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286743", "candidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286743", "MailID");
            string schedule = ExcelOperations.GetCellValueFromExcel("TCIdC286743", "ScheduleName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286743", "FolderGroupId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            //string ID = AddCandidatePage.id;
            //home.SearchCandidate(ID);
            //search.ClickOnCandidateLink();
            candidate.AddScheduleToCandidate(schedule);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286743", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }
        [TestMethod]
        [TestCategory("Recruiter")]
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281208_Timesheet_Creation_Candidate_Future_Period()

        {
            #region TC_C281208_Timesheet_Creation_Candidate_Future_Period
            this.TESTREPORT.InitTestCase("TC_C281208_Timesheet_Creation_Candidate_Futur_Period", "Timesheet creation for a Candidate with Future Time period");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281208", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281208", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281208", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281208", "AvailableId"));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "",false,true,false,false,true);
            matchPage.CreateTimesheets(matchId);
            //driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281208", this.TESTREPORT.GetCurrentStatus());
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
       // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281207_Timesheet_Creation_Candidate_Past_Period()

        {
            #region TC_C281207_Timesheet_Creation_Candidate_Past_Period
            this.TESTREPORT.InitTestCase("TC_C281207_Timesheet_Creation_Candidate_Past_Period", "Timesheet creation for a Candidate with Past Time period");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281207", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            DateTime date = DateTime.Now;
            string pastdate = date.AddMonths(-2).ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281207", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281207", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281207", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281207", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281242_Verify_Edit_Shift_Details()
        {
            #region  TC_C281242_Verify_Edit_Shift_Details
            this.TESTREPORT.InitTestCase(" TC_C281242_Verify_Edit_Shift_Details", "This test case verifies the Edit Shift Details assigned in position calendar");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281242", "CompanyName1");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            position.ClickOnPositionScheduling();
            position.EditShiftDetails();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281242", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286745_Verify_the_functionality_of_Clone_This_position()
        {
            #region TC_C286745_Verify_the_functionality_of_Clone_This_position
            this.TESTREPORT.InitTestCase("TC_C286745_Verify_the_functionality_of_Clone_This_position", " Verify the functionality of Clone This position");
            #region Test Data
            string positionId = ExcelOperations.GetCellValueFromExcel("TCIdC286745", "PositionId");

            #endregion           
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchPosition(positionId);
            schedulingPage.VerifyCloneThisPosition(positionId);
            home.Logout();
            //home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286745", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286749_Verify_View_Saved_Searches()
        {
            #region TC_C286749_Verify_View_Saved_Searches
            this.TESTREPORT.InitTestCase("TC_C286749_Verify_View_Saved_Searches", "Verify_View_Saved_Searches");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286749", "candidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286749", "MailID");
            string schedule = ExcelOperations.GetCellValueFromExcel("TCIdC286749", "ScheduleName");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286749", "FolderGroupId"));
            string positionID = "221630";
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchPosition(positionID);
            home.ClickOnSavedSearches();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286749", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281243_Verify_Change_Shift_Status()
        {
            #region  TC_C281243_Verify_Change_Shift_Status
            this.TESTREPORT.InitTestCase(" TC_C281243_Verify_Change_Shift_Status", "This test case verifies the change shift status to position calendar");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "CompanyName1");
            string shiftStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281243", "ShiftStatus");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            //string id = positionPage.GetPositionTitle();
            //home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            position.VerifyUpdatedStatus(shiftStatus);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281243", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            //this.TESTREPORT.UpdateTestCaseStatus();

            this.TESTREPORT.UpdateTestCaseStatus();




            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281418_Verify_behavior_Datepicker_RangeCalendarsscreen()
        {
            #region TC_C281418_Verify_behavior_Datepicker_RangeCalendarsscreen
            this.TESTREPORT.InitTestCase("TC_C281418_Verify_behavior_Datepicker_RangeCalendarsscreen", "Verify behavior of Date picker in Range Calendars screen");
            #region Testdata
            string rangeCalender = ExcelOperations.GetCellValueFromExcel("TCIdC281418", "RangeCalender");
            string rangeCalenderTextValue = ExcelOperations.GetCellValueFromExcel("TCIdC281418", "RangeCalenderText");
            string rangeCalenderText = rangeCalenderTextValue.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281418", "StatusName");
            string statusName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnRangeCalender(rangeCalender);
            localization.AddNewRangeCalender(rangeCalenderText); ;
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281418", this.TESTREPORT.GetCurrentStatus()); if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281422_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata()
        {
            #region TC_C281422_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata
            this.TESTREPORT.InitTestCase("TC_C281422_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata", "Verify that Recruiter able to Add Candidate Termination date");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281422", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281422", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281422", "FolderGroupId"));
            string amount = ExcelOperations.GetCellValueFromExcel("TCIdC281422", "Amount");
            string ctype = ExcelOperations.GetCellValueFromExcel("TCIdC281422", "Ctype");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.EditLookingForTab(amount, ctype);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281422", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281423_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata_CustomMoneyfields()
        {
            #region TC_C281423_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata_CustomMoneyfields
            this.TESTREPORT.InitTestCase("TC_C281423_Verify_Moneyfields_behaviour_serversidecode_using_CLDRdata_CustomMoneyfields", "Verify Money fields behaviour as server side code is using CLDR data");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281423", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281423", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281423", "FolderGroupId"));
            string amount = ExcelOperations.GetCellValueFromExcel("TCIdC281423", "Amount");
            string ctype = ExcelOperations.GetCellValueFromExcel("TCIdC281423", "Ctype");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.EditGeneralTab(amount);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281423", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281427_Verify_assigning_Passcode_to_Credentials()
        {
            #region TC_C281427_Verify_assigning_Passcode_to_Credentials
            this.TESTREPORT.InitTestCase("TC_C281427_Verify_assigning_Passcode_to_Credentials", "Verify assigning a Passcode to Credentials");
            #region Testdata
            string loginValue = ExcelOperations.GetCellValueFromExcel("TCIdC281427", "loginValue");
            string pwdValue = ExcelOperations.GetCellValueFromExcel("TCIdC281427", "PwdValue");
            string pwdStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281427", "PwdStatus");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            localization.NavigateToResumeBoardLogins(loginValue, pwdValue, pwdStatus);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281427", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286744_Add_new_Seedrecord()
        {
            #region TC_C286744_Add_new_Seedrecord
            this.TESTREPORT.InitTestCase("TC_C286744_Add_new_Seedrecord", "Verify Add new Seed record");
            #region Testdata
            string firstName = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "FirstName");
            string lastName = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "LastName");
            string lName = lastName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string createdThrough = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "CreatedThrough");
            string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "MainPhone");
            string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "CommunicationValue");
            string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC286744", "CommunicationNote");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToNewSeed();
            seed.AddNewSeed(firstName, lName, createdThrough, mainPhone, communicationValue, communicationNote);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286744", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("EC - Localization")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286747_Verify_creating_newCustomField_Manage_customfields_screen()
        {
            #region TC_C286747_Verify_creating_newCustomField_Manage_customfields_screen
            this.TESTREPORT.InitTestCase("TC_C286747_Verify_creating_newCustomField_Manage_customfields_screen", "Verify creating new Custom Field in Manage custom fields screen");
            #region Testdata
            string customField = ExcelOperations.GetCellValueFromExcel("TCIdC286747", "CustomField");
            string nCustomField = ExcelOperations.GetCellValueFromExcel("TCIdC286747", "NewCustomField");
            string newCustomField = nCustomField.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string defaultValue = ExcelOperations.GetCellValueFromExcel("TCIdC286747", "DefaultValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnCustomFields(customField);
            localization.AddContactCustomField(newCustomField, defaultValue);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286747", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            //this.TESTREPORT.UpdateTestCaseStatus();

            this.TESTREPORT.UpdateTestCaseStatus();




            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281260_Verify_Requirements_Column_links_are_disabled_under_Attachment_Dashboard_Widget()
        {
            #region  TC_C281260__Verify_Requirements_Column_links_are_disabled_under_Attachment_Dashboard_Widget
            this.TESTREPORT.InitTestCase("TC_C281260__Verify_Requirements_Column_links_are_disabled_under_Attachment_Dashboard_Widget", "This test case verifies Requirements Column links are disabled under Attachment Dashboard Widget.");

            #region Test Data
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281260", "WidgetName");
            string lblAttachment = ExcelOperations.GetCellValueFromExcel("TCIdC281260", "LblAttachment");
            #endregion
            home.Login(webURL, CandidateUserName, CandidatePassword);
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            candidate.VerifyAttachmentWidget(lblAttachment);
            dashboard.CloseWidgets();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281260", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281262_Verify_Added_Attachments_are_displayed_under_Candidate_Login_Dashboard()
        {
            #region  TC_C281262_Verify_Added_Attachments_are_displayed_under_Candidate_Login_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281262_Verify_Added_Attachments_are_displayed_under_Candidate_Login_Dashboard", "This test case verifies Added Attachments are displayed under Candidate Dashboard widget (Attachments)");
            #region Test Data
            string candidateId = ExcelOperations.GetCellValueFromExcel("TCIdC281262", "CandidateId");
            string candidatePswd = ExcelOperations.GetCellValueFromExcel("TCIdC281262", "Password");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidateWithId(candidateId);
            candidate.VerifyAttachment(candidatePswd);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281262", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C286740_Verify_that_Credit_Distribution_tab_is_displayed_for_a_Full_placement_match()
        {
            #region  TC_C286740_This_test_case_verifies_the_display_of_Credit_Distribution_tab_for_a_Full_placement_match
            this.TESTREPORT.InitTestCase("TC_C286740_This_test_case_verifies_the_display_of_Credit_Distribution_tab_for_a_Full_placement_match", "This test case verifies the display of Credit Distribution tab for a Full placement match");
            #region Test Data
            string matchId = ExcelOperations.GetCellValueFromExcel("TCIdC286740", "MatchId");
            string txtCreditDribution = ExcelOperations.GetCellValueFromExcel("TCIdC286740", "TxtCreditDistribution");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            //driver.sleepTime(10000);
            matchPage.VerifyCreditDistributionTab(txtCreditDribution);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286740", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281374_Verify_save_updates_to_Design_Pages_in_Design_Agreements_Page()
        {
            #region  TC_C281374_Verify_save_updates_to_Design_Pages_in_Design_Agreements_Page
            this.TESTREPORT.InitTestCase("TC_C281374_Verify_save_updates_to_Design_Pages_in_Design_Agreements_Page", "This test case verifies updates saved to Design Pages in Design Agreements Page");
            #region Test Data
            string designPage = ExcelOperations.GetCellValueFromExcel("TCIdC281374", "DesignPage");
            string txtAgreementOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281374", "TextAgreement");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            driver.sleepTime(5000);
            controlPanel.VerifyUpdatesSavedToDesignPage(designPage, txtAgreementOwner);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281374", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData - Copy.csv", "TestData - Copy#csv", DataAccessMethod.Sequential), DeploymentItem("TestData - Copy.csv")]
        public void TC_C286739_Verify_that_Recruiter_is_able_to_create_Contact_from_Company_Manage_page()
        {
            #region  TC_C286739 Verify that Recruiter is able to create Contact from Company Manage page
            this.TESTREPORT.InitTestCase("TC_C286739_Verify_that_Recruiter_is_able_to_create_Contact_from_Company_Manage_page", "Verify that Recruiter is able to create Contact from Company Manage page");
            #region Test Data
            //string companyId = ExcelOperations.GetCellValueFromExcel("","CompanyId");

            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "City");
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "PostalCode");
            string folderGroup = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "FolderGroup");
            string companySource = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "CompanySourceNew");
            //create contact
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "Title");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC286739", "ContactType");


            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            company.AddCompanyMandatoryFields(companyName, city, postalCode, folderGroup, companySource);
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            home.Logout();
            #region Test Rail Integration

            string status = TestRailIntegration.PublishResultsToTestRail("C286739", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281245_Verify_Scheduling_Administration()
        {
            #region TC_C281245_Verify_Scheduling_Administration
            this.TESTREPORT.InitTestCase("TC_C281245_Verify_Scheduling_Administration", "This test case verifies the Scheduling Administration");
            #region Test Data
            string shifStatus2 = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "ShifStatus2");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "TestCaseName");
            string testCaseName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string sortOrder = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "SortOrder");
            string minMatch = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "MinimumMatch");
            string timeSheet = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "TimeSheetLine");
            string newReason = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "NewReason");
            string reason = newReason.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string reqPermission = ExcelOperations.GetCellValueFromExcel("TCIdC281245", "RequiredPermission");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            driver.sleepTime(5000);
            controlPanel.ClickOnControlPanelModules();
            controlPanel.SchedulingAdministration(shifStatus2, testCaseName, sortOrder, minMatch, timeSheet, reason, reqPermission);

            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281245", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C286748_Verify_View_Candidate_History()
        {
            #region  TC286748 Verify View Candidate History
            this.TESTREPORT.InitTestCase("TC286748 Verify View Candidate History", "Verify View Candidate History");
            #region Test Data
            string id = ExcelOperations.GetCellValueFromExcel("TCIdC286748", "CandidateId");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidateWithId(id);
            candidate.VerifyCandidateHistory();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286748", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData - Copy.csv", "TestData - Copy#csv", DataAccessMethod.Sequential), DeploymentItem("TestData - Copy.csv")]
        public void TC_C281135_Verify_Integration_Partner_under_Integration_Settings_field_is_displayed_in_Add_Requirement_widget_when_Select_Target_Record_Type_as_Candidate()
        {
            #region  TC281135 Verify Integration Partner under Integration Settings field is displayed in Add Requirement widget 
            this.TESTREPORT.InitTestCase("TC281135_Verify_Integration_Partner_under_Integration_Settings_field_is_displayed_in_Add_Requirement_widget", "TC281153_Verify_Integration_Partner_under_Integration_Settings_field_is_displayed_in_Add_Requirement_widget");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281135", "SearchRequirementName");
            string requirementName = ExcelOperations.GetCellValueFromExcel("TCIdC281135", "RequirementName");
            string requirement = requirementName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281135", "Type");
            string targetRecordType = ExcelOperations.GetCellValueFromExcel("TCIdC281135", "TargetRecordType");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            home.VerifyIntegrationPartner(req, requirement, type, targetRecordType);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281135", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281299_Verify_Dashboard()
        {
            string widgenetName = ExcelOperations.GetCellValueFromExcel("TCIdC281299", "WidgenetName");
            #region TC_C281299_Verify_Dashboard
            this.TESTREPORT.InitTestCase("TC_C281299_Verify_Dashboard", "Verify Dashboard");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            dashboard.VerifyGoalsWidget();
            dashboard.ClickOnModifyDashboard();
            dashboard.AddWidget(widgenetName);
            localization.VerifyLeaderboardWidget();
            dashboard.CloseWidgets();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281299", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281244_Verify_Delete_Shifts()
        {
            #region  TC_C281244__Verify_Delete_Shifts
            this.TESTREPORT.InitTestCase(" TC_C281244__Verify_Delete_Shifts", "This test case verifies the Delete status of shifts");
            #region Test Data
            string positionType = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "PositionType");
            string primaryDept = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "PrimaryDept");
            string folderGroup1 = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "FolderGroup");
            string positionTitle1 = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "PositionTitle1");
            string contactName = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "ContactName");
            string facilityDept = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "FacilityDept");
            string positionOwner = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "PositionOwner");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "PositionSource");
            string shiftType1 = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "ShiftType1");
            string shiftType2 = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "ShiftType2");
            string shiftDescription = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "ShiftDescription");
            string companyName = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "CompanyName1");
            string shiftStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281244", "ShiftStatus");
            string currentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddPosition();
            home.ClickOnSimple();
            position.AddPosition(companyName, positionType, primaryDept, folderGroup1, positionTitle1, contactName, facilityDept, positionOwner, positionSource, shiftType1, shiftType2, shiftDescription, currentMonth);
            position.ClickOnContinueToPosition();
            //string id = positionPage.GetPositionTitle();
            //home.SearchPosition(id);
            position.ClickOnPositionScheduling();
            position.DeleteShifts();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281244", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281282_Verify_Position_count_increase_when_new_position_added()
        {
            #region  TC_C281282_Verify_Position_count_increase_when_new_position_added
            this.TESTREPORT.InitTestCase("TC_C281282_Verify_Position_count_increase_when_new_position_added", "Verify_Position_count_increase_when_new_position_added");
            #region Test Data
            string companyId = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "CompanyId");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "PositionTitle");
            string positionName = positionTitle.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string folderGroupForPosition = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "FolderGroup");
            string estimatedDate = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "EstimatedDate");
            string dropDownPositionText = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "NewPositionType");
            string positionSource = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "PositionSource");
            string additionalInfo = ExcelOperations.GetCellValueFromExcel("TCIdC281282", "AdditionalInfo");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchComapany(companyId);
            //string value = position.AddPositionToCompany(positionName, folderGroupForPosition, estimatedDate, dropDownPositionText, positionSource, additionalInfo);
            string value = position.AddPositionToCompany(positionName, folderGroupForPosition, estimatedDate, dropDownPositionText, positionSource, additionalInfo);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchComapany(companyId);
            position.VerifyPositionCount(value);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281282", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281429_Verify_that_an_Empty_Password_can_be_Saved()
        {
            #region  TC_C281429_Verify_that_an_Empty_Password_can_be_Saved
            this.TESTREPORT.InitTestCase("TC_C281429_Verify_that_an_Empty_Password_can_be_Saved", "This test case verifies whether empty password can be saved");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281429", "BoardLogins");
            string pwdValue = ExcelOperations.GetCellValueFromExcel("TCIdC281429", "PasswordValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.OpenResumeBoardAndVerifyDepartment(resumeBoardsLogin);
            localization.VerifyUserAbleToAddEmptyPassword(pwdValue);

            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281429", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281430_Verify_that_an_overwrite_button_can_be_disabled_when_empty_login_field()
        {
            #region  TC_C281430_Verify_that_an_overwrite_button_can_be_disabled_when_empty_login_field
            this.TESTREPORT.InitTestCase("TC_C281430_Verify_that_an_overwrite_button_can_be_disabled_when_empty_login_field", "Verify_that_an_overwrite_button_can_be_disabled_when_empty_login_field");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281430", "BoardLogins");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.OpenResumeBoardAndVerifyDepartment(resumeBoardsLogin);
            localization.VerifyOverWriteButton();

            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281430", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281435_Verify_that_Credentials_are_copied_to_the_specific_Job_Board_from_Department_by_using_Inherit_button_if_there_are_no_credentials_available_in_Parent_Department()
        {
            #region  TC_C281435_Verify_that_Credentials_are_copied_to_the_specific_Job_Board_from_Department_by_using_Inherit_button_if_there_are_no_credentials_available_in_Parent_Department
            this.TESTREPORT.InitTestCase("TC_C281435_Verify_that_Credentials_are_copied_to_the_specific_Job_Board_from_Department_by_using_Inherit_button_if_there_are_no_credentials_available_in_Parent_Department", "This test case verifies that Credentials are copied to the specific Job Board from Department by using Inherit button of that particular Job Board under Recruiter if there are no credentials available in Parent Department.");
            #region Test Data
            string resumeBoardLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281435", "ResumeBoardLogin");
            #endregion      
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            localization.ClickOnResumeBoardLogin(resumeBoardLogin);
            localization.CopyCredentialsToJobBoard();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281435", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281431_Verify_that_credentials_copied_to_all_sub_departments()
        {
            #region  TC_C281431_Verify_that_credentials_copied_to_all_sub_departments
            this.TESTREPORT.InitTestCase("TC_C281431_Verify_that_credentials_copied_to_all_sub_departments", "Verify_that_credentials_copied_to_all_sub_departments");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281431", "BoardLogins");
            string loginValueToOverwrite = ExcelOperations.GetCellValueFromExcel("TCIdC281431", "ValueToOverWrite");
            string ValueToBeOverriden = ExcelOperations.GetCellValueFromExcel("TCIdC281431", "ValueToBeOverriden");
            string copyBtnMessage = ExcelOperations.GetCellValueFromExcel("TCIdC281431", "CopybtnMessage");
            string newLoginCredentials = ExcelOperations.GetCellValueFromExcel("TCIdC281431", "NewLoginCredentials");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.OpenResumeBoardAndVerifyDepartment(resumeBoardsLogin);
            localization.VerifyCredentialsCopied(loginValueToOverwrite, ValueToBeOverriden, copyBtnMessage, newLoginCredentials);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281431", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281432_Verify_that_in_sub_department_we_can_save_empty_password()
        {
            #region  TC_C281432_Verify_that_in_sub_department_we_can_save_empty_password
            this.TESTREPORT.InitTestCase("TC_C281432_Verify_that_in_sub_department_we_can_save_empty_password", "Verify that in sub department we can save empty password");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281432", "BoardLogins");
            string pwdValue = ExcelOperations.GetCellValueFromExcel("TCIdC281432", "PasswordValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.OpenResumeBoardAndVerifyDepartment(resumeBoardsLogin);
            localization.VerifyEmptyPwdCanAbleToSave(pwdValue);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281432", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281433_Verify_that_in_sub_department_overwrite_button_should_disabled_when_login_field_is_empty()
        {
            #region  TC_C281433_Verify_that_in_sub_department_overwrite_button_should_disabled_when_login_field_is_empty
            this.TESTREPORT.InitTestCase("TC_C281433_Verify_that_in_sub_department_overwrite_button_should_disabled_when_login_field_is_empty", "verifies that Overwrite button is disabled if Login Field of a specific Job Board is blank under Sub Department");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281433", "BoardLogins");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.VeridyOverwritebuttonDisabledInsubDept(resumeBoardsLogin);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281433", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281434_Verify_that_empty_password_can_Provied_for_job_boards_for_recruiter()
        {
            #region  TC_C281434_Verify_that_empty_password_can_Provied_for_job_boards_for_recruiter
            this.TESTREPORT.InitTestCase("TC_C281434_Verify_that_empty_password_can_Provied_for_job_boards_for_recruiter", "Verify that empty password can Provied for job boards for recruiter");
            #region Test Data
            string resumeBoardsLogin = ExcelOperations.GetCellValueFromExcel("TCIdC281434", "BoardLogins");
            string pwdValue = ExcelOperations.GetCellValueFromExcel("TCIdC281434", "PasswordValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            controlPanel.MouseHoverOnTools();
            controlPanel.ClickOnControlPanel();
            controlPanel.ClickOnControlPanelModules();
            localization.VerifyRecruiterAbleToSaveEmptyPwd(resumeBoardsLogin);
            localization.VerifyEmptyPwdCanAbleToSave(pwdValue);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281434", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C286741_Verify_Add_New_Candidate_Target_Requirement()
        {
            #region  TC_C286741_Verify_Add_New_Candidate_Target_Requirement
            this.TESTREPORT.InitTestCase("TC_C286741 Verify Add New Candidate Target Requirement", "This Test case verifies Candidate Requirement from Control Panel");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC286741", "RequirementName");
            string reqtype = ExcelOperations.GetCellValueFromExcel("TCIdC286741", "RequirementType");
            string reqtarget = ExcelOperations.GetCellValueFromExcel("TCIdC286741", "RequirementTarget");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC286741", "RequirementWeight");
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
            string status = TestRailIntegration.PublishResultsToTestRail("C286741", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestData.csv")]
        public void TC_C281264_Verify_that_Onboarding_documen_eStaff365_Docs_preview_is_not_displaying_in_Requirements_Work_View()
        {
            #region  TC_C281264_Verify_that_Onboarding_documen_eStaff365_Docs_preview_is_not_displaying_in_Requirements_Work_View
            this.TESTREPORT.InitTestCase("TC_C281264_Verify_that_Onboarding_documen_eStaff365_Docs_preview_is_not_displaying_in_Requirements_Work_View", "Verify that Onboarding documen eStaff365 Docs preview is not displaying in Requirements Work View");
            #region Test Data
            //string candidateNewId = ExcelOperations.GetCellValueFromExcel("TCIdC281264", "CandidateNewId");
            //string pwdValue = ExcelOperations.GetCellValueFromExcel("","PasswordValue");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281264", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281264", "FolderGroupId"));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281264", "MailID");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281264", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.SearchCandidateWithId(candidateNewId);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            schedulingPage.RightClickOnRequirement();
            schedulingPage.VerifyWorkViewTabAndValidate();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281264", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C281390_Verify_Behavior_Date_Picker_Manage_Match_Screen()
        {
            #region  TC_C281390_Verify_Behavior_Date_Picker_Manage_Match_Screen
            this.TESTREPORT.InitTestCase("TC_C281390_Verify_Behavior_Date_Picker_Manage_Match_Screen", "This Test Case Verifies Date Picker In Manage Match Screen");
            #region Test Data
            string startdate = DateTime.Now.AddDays(-10).ToString("M/dd/yyyy").Replace('-', '/');
            //ExcelOperations.GetCellValueFromExcel("TCIdC281390", "StartDate"); 
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281390", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281390", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281390", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281390", "PositionFolderGroup"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //Searchmatch and navigate to match screen page
            timesheet.CreateMatchID(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            Match.EnterStartDate(startdate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281390", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281362_Verify_that_the_Recruiter_Creates_invoice_for_Milestone_100Percent_Complete()
        {
            #region TC_C281362_Verify_that_the_Recruiter_Creates_invoice_for_Milestone_100%_Complete
            this.TESTREPORT.InitTestCase("TC_C281362_Verify_that_the_Recruiter_Creates_invoice_for_Milestone_100%_Complete", "This test case verifies that the Recruiter Creates invoice for Milestone 100% Complete");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "ClientProjectName");
            string clientname = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string milestone = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "Milestone");
            string milestonename = milestone.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string percent = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "Hunderedpercent");
            string fee = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "Fee");
            string recordType = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "RecordType");
            string batch = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "Batch");
            string billingDate = DateTime.Now.AddDays(+1).ToString("M/d/yyyy");
            string txtResourceManger = ExcelOperations.GetCellValueFromExcel("TCIdC281362", "ResourceManager");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.ClickOnLogoMenu();
            //home.NavigateToAddnew();
            clientproject.verifyAddClientProject(clientname);
            string id = ClientProjectPage.id;
            clientproject.SearchClientProject(id);
            clientproject.Milestone100percent(milestonename, percent, fee, txtResourceManger);
            driver.sleepTime(5000);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAccounting();
            accounting.ClickOnScheduleTransactionInvoicing(recordType, batch, billingDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281362", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281375_Verify_that_the_Recruiter_Generate_Document_in_PDF_format()
        {
            #region TC_C281375_Verify_Recruiter_Generate_Document_PDF
            this.TESTREPORT.InitTestCase("TC_C281375_Verify_that_the_Recruiter_Generate_Document_in_PDF_format", "Verify that the Recruiter Generate Document in PDF format");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281375", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281375", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281375", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281375", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            string pdfDoc = "false";
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            matchPage.GenerateDocument(pdfDoc);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281375", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        //[TestMethod]
        //[TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        //public void TC_C281388_Verify_harvesting_seed_record_to_Contact_Record()
        //{
        //    #region TC_C281388_Verify_harvesting_seed_record_to_Contact_Record
        //    this.TESTREPORT.InitTestCase("TC_C281388 Verify_harvesting_seed_record_to_Contact_Record", "This test case verifies harvesting seeds from search results to Erecruit business entities like contacts.");
        //    #region Testdata
        //    string firstName = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "FirstName");
        //    string lastName = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "LastName");
        //    string lName = lastName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
        //    string createdThrough = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "CreatedThrough");
        //    string mainPhone = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "MainPhone");
        //    string communicationValue = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "CommunicationValue");
        //    string communicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC281388", "CommunicationNote");
        //    #endregion
        //    home.Login(webURL, recruiterUserName, recruiterPassword);
        //    home.NavigateToNewSeed();
        //    //seed.AddNewSeed(firstName, lName, createdThrough, mainPhone, communicationValue, communicationNote);
        //    //id = utility.GetTitleId();
        //    string selectedValue = seed.AddNewSeed(firstName, lName, createdThrough, mainPhone, communicationValue, communicationNote);
        //    seed.VerifySeedCompanyValue(selectedValue);
        //    home.Logout();
        //    home.HandleAlert();
        //    #region Test Rail Integration
        //    string status = TestRailIntegration.PublishResultsToTestRail("C281388", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286723_Verify_Functionality_Quick_Placement_From_Candidate_Search_Page()
        {
            #region TC_C286723_Verify_Functionality_Quick_Placement_From_Candidate_Search_Page
            this.TESTREPORT.InitTestCase("TC_C286723_Verify_Functionality_Quick_Placement_From_Candidate_Search_Page", "This test case verifies the functionality of quick placement from candidate search page");
            #region TestData
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286723", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286723", "PositionTypeIndex"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286723", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286723", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ClickOnCandidatesLink();
            home.ClickOnCandidateQP(candidateID);
            positionPage.SubmitMatchFromCandidate(candidateName, taxType, payRate, billRate, endDate, true,false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286723", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286724_Verify_Functionality_Quick_Placement_From_Manage_Candidate_Applications()
        {
            #region TC_C286724_C286724_Verify_Functionality_Quick_Placement_From_Manage_Candidate_Applications
            this.TESTREPORT.InitTestCase("TC_C286724_Verify_Functionality_Quick_Placement_From_Manage_Candidate_Applications", "This test case verifies the functionality of quick placement from manage candidate applications");
            #region TestData
            string Cname = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "ChooseCandidate");
            string position1 = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "ChooseCandidate_Application_Source");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286724", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286724", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286724", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();
            newCandidateApp.CreateCandidateApplication(candidateName, positionID, applicationNote, source);
            driver.SwitchToDefaultFrame();
            newCandidateApp.ClickOnCandidateAppMatch();
            positionPage.SubmitMatchFromCandidate(candidateName, taxType, payRate, billRate, endDate, false,true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286723", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286726_Verify_Quick_Placement_Manage_Contact_Page()
        {
            #region TC_C286726_Verify_Quick_Placement_Manage_Contact_Page
            this.TESTREPORT.InitTestCase("TC_C286726_Verify_Quick_Placement_Manage_Contact_Page", "This test case verifies the functionality of quick placement from manage contact page");
            #region Test Data
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286726", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286726", "PositionTypeIndex"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286726", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286726", "AvailableId"));
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
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            home.ClickOnContactQP();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate,true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286726", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286727_Verify_Quick_Placement_Manage_Company_Page()
        {
            #region TC_C286727_Verify_Quick_Placement_Manage_Company_Page
            this.TESTREPORT.InitTestCase("TC_C286727_Verify_Quick_Placement_Manage_Company_Page", "This test case verifies the functionality of quick placement from manage company page");
            #region Test Data
            
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286727", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286727", "PositionTypeIndex"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286727", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286727", "AvailableId"));

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
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate, true);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyById();
            home.ClickOnCompanyQP();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate, true);
            //Add match code
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286727", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281328_Verify_Entity_Seperate_Record_Filters_Opportunity_Search()
        {
            #region TC_C281328_Verify_Entity_Seperate_Record_Filters_Opportunity_Search
            this.TESTREPORT.InitTestCase("TC_C281328_Verify_Entity_Seperate_Record_Filters_Opportunity_Search", "Verify Entity Separate Record Filters - Opportunity Search");
            #region TestData
            // string id = ExcelOperations.GetCellValueFromExcel("","id");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            // home.SearchOpportunity(id);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281321", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281273_verify_error_while_creating_match_through_requirement_which_manadatory_submittal()
        {
            #region TC_C281273_verify_error_while_creating_match_through_requirement_which_manadatory_submittal
            this.TESTREPORT.InitTestCase("TC_C281273_verify_error_while_creating_match_through_requirement_which_manadatory_submittal", "Verify Error while Creating Match through Requirement which is mandatory for Submittal");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281273", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281273", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PositionFolderGroup"));

            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "RequirementName");
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "Type");
            string targetType = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "TargetType");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "Weight");
            string searchReqTemplate = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "SearchReqTemplate");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "TaxType");
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281273", "MailID");
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            string companyIdAndName = string.Empty;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            string requirement = home.AddRequirementForCompany(req, type, targetType, weight);
            driver.sleepTime(2000);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            home.AddAndsaveRequirements(searchReqTemplate, requirement);
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreateContractPosition(companyName, foldergroup);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            string matchId = matchPage.CreateContractMatch(positionID, candidateName, billRate, payRate);
            matchPage.VerifyAfterChangingStatus();

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281273", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286776_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_DoNotUse()
        {
            #region TC_C286776_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_DoNotUse
            this.TESTREPORT.InitTestCase("TC_C286776_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_DoNotUse", "Verify the functionality of moving Match from Submittal to Full Placement where candidate status =  Do Not Use");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286776", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286776", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286776", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286776", "PositionFolderGroup"));
            string matchId= timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "",false,false);
           // string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "", false, true, false, false, true, true, false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286776", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286777_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_Unknown()
        {
            #region TC_C286777_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_Unknown
            this.TESTREPORT.InitTestCase("TC_C286777_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_Unknown", "Verify the functionality of moving Match from Submittal to Full Placement where candidate status = Unknown");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286777", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286777", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286777", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286777", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "",false,false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286777", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286778_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_2WeekNoticePeriod()
        {
            #region TC_C286778_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_2WeekNoticePeriod
            this.TESTREPORT.InitTestCase("TC_C286778_verify_functionality_moving_match_submittal_Fullplacement_candidate_status_2WeekNoticePeriod", "Verify the functionality of moving Match from Submittal to Full Placement where candidate status = 2 Week Notice Peiod");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286778", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286778", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286778", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286778", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "", false,false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286778", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286767_verify_functionality_moving_match_submittal_to_Fullplacement()
        {
            #region TC_C286767_verify_functionality_moving_match_submittal_to_Fullplacement
            this.TESTREPORT.InitTestCase("TC_C286767_verify_functionality_moving_match_submittal_to_Fullplacement", "Verify the functionality of  Moving  Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286767", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286767", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286767", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286767", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286767", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286768_verify_display_Alertmessage_Billing_contact_field_empty_whilemoving_match_fullplacement()
        {
            #region TC_C286768_verify_display_Alertmessage_Billing_contact_field_empty_whilemoving_match_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286768_verify_display_Alertmessage_Billing_contact_field_empty_whilemoving_match_fullplacement", "Verify display of an Alert message when Billing Contact  fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286768", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286768", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286768", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286768", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286768", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281275_Verify_that_the_Recruiter_Confirm_End_Date_in_Match_Timeline()
        {
            #region TC_C281275_Verify_that_the_Recruiter_Confirm_End_Date_in_Match_Timeline
            this.TESTREPORT.InitTestCase("TC_C281275_Verify_that_the_Recruiter_Confirm_End_Date_in_Match_Timeline", "This test case verifies that the Recruiter Confirm End Date in Match Timeline");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "BillRate");
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "CandidateSearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "Title");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PlacementGrade");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy").Replace('-', '/');
            DateTime edate = DateTime.Now.AddMonths(2);
            string endDate = edate.ToString("MM/dd/yyyy").Replace('-', '/');
            string cendDate = edate.AddDays(-1).ToString("M/d/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281275", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281275", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281275", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281275", "AvailableId"));
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
            string ContactId = AddCandidatePage.id;
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate,false,true);
            positionPage.VerifyPopUp(endDate, endReason, placementGrade);
            positionPage.VerifyMatchTimeline(cendDate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281275", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281276_Edit_Verify_that_the_Recruiter_Extend_End_Date_in_Match_Timeline()
        {
            #region TC_C281276_Edit_Verify_that_the_Recruiter_Extend_End_Date_in_Match_Timeline
            this.TESTREPORT.InitTestCase("TC_C281276_Edit_Verify_that_the_Recruiter_Extend_End_Date_in_Match_Timeline", "This test case verifies that the Recruiter Extend End Date in Match Timeline");
          
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281276", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string nextmnth=DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281276", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PositionFolderGroup"));
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PositionTitle");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "TaxType");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PlacementGrade");
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281276", "MailID");
            string startDate = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy").Replace('-', '/');
            DateTime edate = DateTime.Now.AddMonths(2);
            string endDate = edate.ToString("MM/dd/yyyy").Replace('-', '/');
            string cendDate = edate.AddDays(-1).ToString("M/d/yyyy").Replace('-', '/');
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281276", "AvailableId"));

            #endregion
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            createMatch.ExtendEndDate(nextmnth);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281276", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281376_Verify_that_the_Recruiter_Generate_Document_in_Word_format()
        {
            #region  TC_C281376_Verify_that_the_Recruiter_Generate_Document_in_Word_format
            this.TESTREPORT.InitTestCase("TC_C281376_Verify_that_the_Recruiter_Generate_Document_in_Word_format", "This test case verifies behavior of the date picker after code change in Manage Match screen.");
            #endregion

            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281376", "FolderGroupId"));           
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281376", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281376", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281376", "PositionFolderGroup"));
            #endregion
            string pdfDoc = "false";
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            matchPage.GenerateDocument(pdfDoc);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281376", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion


        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286752_Verify_Display_WorkersComp_values_addingPosition_QuickMatch()
        {
            #region TC_C286752_Verify_Display_WorkersComp_values_addingPosition_QuickMatch
            this.TESTREPORT.InitTestCase("TC_C286752_Verify_Display_WorkersComp_values_addingPosition_QuickMatch", "Verify Display of Workers Comp and its values in adding (Position) Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286752", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286752", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286752", "AvailableId"));
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            positionPage.VerifyWorkerCompQuickMatch(positionID);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286752", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286750_Verify_Display_of_VMS_Burden_and_its_values_in_adding_Position_Quick_Match()
        {
            #region TC_C286750_Verify_Display_of_VMS_Burden_and_its_values_in_adding_Position_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C286750_Verify_Display_of_VMS_Burden_and_its_values_in_adding_Position_Quick_Match", "TC_C286750_Verify_Display_of_VMS_Burden_and_its_values_in_adding_Position_Quick_Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286750", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286750", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286750", "AvailableId"));
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            positionPage.VerifyVMSBurdenQuickMatch(positionID);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286750", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        //        [TestMethod]
        //        [TestCategory("Recruiter")]
        //        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        //        public void TC_C286759_Verify_the_rates_are_inherited_from_Position_when_Perm_Hourly_Placement_Match_is_created()
        //        {
        //            #region  TC_C286759 Verify the rates are inherited from Position when Perm Hourly Placement Match is created
        //            this.TESTREPORT.InitTestCase("TC_C286759_Verify_the_rates_are_inherited_from_Position_when_Perm_Hourly_Placement_Match_is_created", "Verify the rates are inherited from Position when Perm Hourly Placement Match is created");
        //            #region Test Data
        //            string name = ExcelOperations.GetCellValueFromExcel("","Candidate");
        //            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
        //            string city = ExcelOperations.GetCellValueFromExcel("","City");
        //            string title = ExcelOperations.GetCellValueFromExcel("","Title");
        //            string Email = ExcelOperations.GetCellValueFromExcel("","ContactMail");
        //            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
        //            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("","FolderGroupId"));
        //            string postalcode = ExcelOperations.GetCellValueFromExcel("","PostalCode");
        //            string url = ExcelOperations.GetCellValueFromExcel("","Website");
        //            string phoneNo = ExcelOperations.GetCellValueFromExcel("","PhoneNumber");
        //            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
        //            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
        //            string payRate = ExcelOperations.GetCellValueFromExcel("","PayRate");
        //            string billRate = ExcelOperations.GetCellValueFromExcel("","BillRate");
        //            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("","AvailableId"));
        //            #endregion
        //            home.Login(webURL, recruiterUserName, recruiterPassword);
        //            string matchId = timesheet.GeneratePremMatch(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate,statusId, "");

        //            #region Test Rail Integration
        //            string status = TestRailIntegration.PublishResultsToTestRail("C286759", this.TESTREPORT.GetCurrentStatus());
        //            if (status != "")
        //                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
        //            else
        //                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
        //            #endregion
        //            this.TESTREPORT.UpdateTestCaseStatus();
        //            #endregion
        //}

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286753_Verify_Display_WorkersComp_values_addingPosition_AddNewMatch()
        {
            #region TC_C286753_Verify_Display_WorkersComp_values_addingPosition_AddNewMatch
            this.TESTREPORT.InitTestCase("TC_C286753_Verify_Display_WorkersComp_values_addingPosition_AddNewMatch", "Verify Display of Workers Comp and its values in adding (Position) Add New Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286753", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286753", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286753", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnMatch();
            positionPage.VerifyWorkerCompAddNewMatch(positionID);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286753", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286751_Verify_Display_of_VMS_Burden_and_its_values_in_Position_Add_New_Match()
        {
            #region TC_C286751_Verify_Display_of_VMS_Burden_and_its_values_in_Position_Add_New_Match
            this.TESTREPORT.InitTestCase("TC_C286751_Verify_Display_of_VMS_Burden_and_its_values_in_Position_Add_New_Match", "Verify Display of VMS Burden and its values in Position Add New Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286751", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286751", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286751", "AvailableId"));
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnMatch();
            positionPage.VerifyVMSBurdenAndValueMatch(positionID);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286751", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Manager")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281300_Verify_Customizing_existing_Dashboard_in_Home_Screen()
        {
            #region TC_C281300_Verify_Customizing_existing_Dashboard_in_Home_Screen
            this.TESTREPORT.InitTestCase("TC_C281300_Verify_Customizing_existing_Dashboard_in_Home_Screen", "Verify Modify Existing Dashboard in Home Screen");
            #region Testdata
            string dashBoardValue = ExcelOperations.GetCellValueFromExcel("TCIdC281300", "DashBoardValue");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ModifyDashboard(dashBoardValue);
            driver.sleepTime(5000);
            dashboard.ChangeColumnWidthDistribution(5);
            driver.sleepTime(5000);
            dashboard.ClickOnApplyDistributionButton();
            driver.sleepTime(5000);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281300", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286725_Verify_Functionality_Quick_Placement_From_Position_Page()
        {
            #region TC_C286725_Verify_Functionality_Quick_Placement_From_Position_Page
            this.TESTREPORT.InitTestCase("TC_C286725_Verify_Functionality_Quick_Placement_From_Position_Page", "Verify functionality of quick placement from position page");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "BillRate");
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "CandidateSearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286725", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/'); 
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286725", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286725", "FolderGroup"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286725", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286725", "AvailableId"));
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
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromQp();
            positionPage.SubmitMatch(candidateName, taxType, payRate, billRate, endDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286725", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286781_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Closed()
        {
            #region TC_C286781_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Closed
            this.TESTREPORT.InitTestCase("TC_C286781_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Closed", "Verify Functionality Of Moving Match From Submittal To Full Placement Where Position Status Is Closed");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286781", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "BillRate");
            string error = ExcelOperations.GetCellValueFromExcel("TCIdC286781", "positionerror");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286781", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286781", "AvailableId"));
            string positionstatus = "Closed";
            bool Match = true;
            string matchId = timesheet.GenerateMatch(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            timesheet.NavigateToPositionFromMatch(positionstatus,Match);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            createMatch.VerifyerrormessageMatchtoFullplacement(today, error);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286781", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286775_verify_display_alert_message_when_mandatoryfields_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286775_verify_display_alert_message_when_mandatoryfields_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286775_verify_display_alert_message_when_mandatoryfields_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when any Mandatory fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286775", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286775", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286775", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286775", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286775", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286774_verify_display_alert_message_when_VMSBurden_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286774_verify_display_alert_message_when_VMSBurden_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286774_verify_display_alert_message_when_VMSBurden_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when VMS Burden fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286774", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286774", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286774", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286774", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286774", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286773_verify_display_alert_message_when_Burdenadmin_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286773_verify_display_alert_message_when_Burdenadmin_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286773_verify_display_alert_message_when_Burdenadmin_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when Burden Admin fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286773", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286773", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286773", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286773", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286773", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281271_Verify_creating_new_Perm_Match_Full_Placement()
        {
            #region  TC_C281271_Verify_creating_new_Perm_Match_Full_Placement
            this.TESTREPORT.InitTestCase("TC_C281271_Verify_creating_new_Perm_Match_Full_Placement", "Verify creating new Perm Match Full Placement");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281271", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281271", "BillRate");
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281271", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GeneratePremMatch(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, "", statusId);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281271", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData - Copy.csv", "TestData - Copy#csv", DataAccessMethod.Sequential), DeploymentItem("TestData - Copy.csv")]
        public void TC_C281279_Verify_Integration_Partner_when_Select_Target_Record_Type_as_Match()
        {
            #region  TC_C281279_Verify_Integration_Partner_when_Select_Target_Record_Type_as_Match
            this.TESTREPORT.InitTestCase("TC_C281279_Verify_Integration_Partner_when_Select_Target_Record_Type_as_Match", "Verify Integration Partner when Select Target Record Type as Match");
            #region Test Data
            //string companyName = ExcelOperations.GetCellValueFromExcel("","companyNameNew");
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281279", "SearchRequirementName");
            string requirementName = ExcelOperations.GetCellValueFromExcel("TCIdC281279", "RequirementName");
            string requirement = requirementName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281279", "Type");
            string targetRecordType = ExcelOperations.GetCellValueFromExcel("TCIdC281279", "TargetRecordMatch");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281279", "RequirementWeight");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyIntegrationPatnerWithMatch(req, requirement, type, targetRecordType, weight);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281279", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData - Copy.csv", "TestData - Copy#csv", DataAccessMethod.Sequential), DeploymentItem("TestData - Copy.csv")]
        public void TC_C281365_Verify_that_Image_Manager_present_in_Email_template_when_the_Recruiter_sends_Email_to_candidates()
        {
            #region  TC_C281365_Verify_that_Image_Manager_present_in_Email_template_when_the_Recruiter_sends_Email_to_candidates
            this.TESTREPORT.InitTestCase("TC_C281365_Verify_that_Image_Manager_present_in_Email_template_when_the_Recruiter_sends_Email_to_candidates", "Verify that Image Manager present in Email template when the Recruiter sends Email to candidates");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281365", "SearchEmail");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            home.VerifyImageManagerPresent(req);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281365", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286756_Verify_display_of_Alert_message_when_Mandatory_fields_are_missing_while_creating_Quick_Match()
        {
            #region TC_C286756_Verify_display_of_Alert_message_when_Mandatory_fields_are_missing_while_creating_Quick_Match
            this.TESTREPORT.InitTestCase("TC_C286756_Verify_display_of_Alert_message_when_Mandatory_fields_are_missing_while_creating_Quick_Match", "This test case verifies display of Alert message when Mandatory fields are missing while creating Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286756", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286756", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286756", "AvailableId"));

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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            positionPage.ClickOnQucickMatch(positionID, candidateName);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286756", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286754_Verify_an_Alert_Message_is_displayed_when_Estimated_End_Date_after_Estimated_Start_Date_in_Adding_candidate()
        {
            #region TC_C286754_Verify_an_Alert_Message_is_displayed_when_Estimated_End_Date_after_Estimated_Start_Date_in_Adding_candidate
            this.TESTREPORT.InitTestCase("TC_C286754_Verify_an_Alert_Message_is_displayed_when_Estimated_End_Date_after_Estimated_Start_Date_in_Adding_candidate", "verifies an Alert Message is displayed when Estimated End Date > Estimated Start Date in Adding candidate while creating Quick Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('/', '-');
            string endDate = DateTime.Now.AddMonths(1).ToString("M/dd/yyyy").Replace('/', '-');
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286754", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286754", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286754", "PreviousDate");
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            positionPage.VerifyDatesValidation(positionID, candidateName, previousDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration

            string status = TestRailIntegration.PublishResultsToTestRail("C286754", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286755_Verify_an_Alert_Message_when_Estimated_End_Date_after_Estimated_Start_Date_in_Adding_candidate_Add_New_Match()
        {
            #region TC_C286755 Verify an Alert Message when Estimated End Date after Estimated Start Date in Adding candidate Add New_Match
            this.TESTREPORT.InitTestCase("TC_C286755_Verify_an_Alert_Message_when_Estimated_End_Date_after_Estimated_Start_Date_in_Adding_candidate_Add_New_Match", "Verify an Alert Message when Estimated End Date after Estimated Start Date in Adding candidate Add New Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('/', '-');
            string endDate = DateTime.Now.AddMonths(1).ToString("M/dd/yyyy").Replace('/','-');
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286755", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286755", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286755", "PreviousDate");
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnAddNewMatch();
            positionPage.VerifyDatesInAddNewMatch(positionID, candidateName, previousDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration

            string status = TestRailIntegration.PublishResultsToTestRail("C286755", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286757_Verify_Verify_display_of_Alert_message_when_Mandatory_fields_are_missing_while_creating_New_Match()
        {
            #region TC_C286757 Verify display of Alert message when Mandatory field are missing while creating New Match
            this.TESTREPORT.InitTestCase("TC_C286757_Verify_Verify_display_of_Alert_message_when_Mandatory_fields_are_missing_while_creating_New_Match", "TC_C286757 Verify display of Alert message when Mandatory field are missing while creating New Match");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('/', '-');
            string endDate = DateTime.Now.AddMonths(1).ToString("M/dd/yyyy").Replace('/', '-');
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286757", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286757", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286757", "PreviousDate");
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnAddNewMatch();
            positionPage.VerifyWarningMesgCreatingMatch(positionID, candidateName);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration

            string status = TestRailIntegration.PublishResultsToTestRail("C286755", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286758_Verify_the_rates_are_inherited_from_Position_when_Contract_Match_is_created()
        {
            #region  TC_C286758_Verify_the_rates_are_inherited_from_Position_when_Contract_Match_is_created
            this.TESTREPORT.InitTestCase("TC_C286758_Verify_the_rates_are_inherited_from_Position_when_Contract_Match_is_created", "Verify the rates are inherited from Position when Contract Match is created");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286758", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286758", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286758", "PreviousDate");
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            CreateMatchPage createMatch = new CreateMatchPage();
            createMatch.CreateContractMatch(positionID, candidateName, billRate, payRate);
            matchPage.VerifyRatesInMatch();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286758", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286759_Verify_the_rates_are_inherited_from_Position_when_Hourly_Placement_Match_is_created()
        {
            #region  TC_C286759 Verify the rates are inherited from Position when Hourly Placement Match is created
            this.TESTREPORT.InitTestCase("TC_C286759_Verify_the_rates_are_inherited_from_Position_when_Hourly_Placement_Match_is_created", "Verify the rates are inherited from Position when Hourly Placement Match is created");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286759", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286759", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286759", "PreviousDate");
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
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            //string positionID = positionPage.CreatePermHourlyPosition(companyName);
            string positionID = positionPage.CreateContractPosition(companyName,foldergroup);
            positionPage.AddRatesInPositionPage(payRate,billRate);
            createMatch.CreateMatchForHourly(positionID, candidateName, payRate, billRate);
            matchPage.VerifyRatesInMatch();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286759", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286735_Verify_user_ableto_create_match_from_Newmatch_option_matchwidget_Searchcandidatepage()
        {
            #region TC_C286735_Verify_user_ableto_create_match_from_Newmatch_option_matchwidget_Searchcandidatepage
            this.TESTREPORT.InitTestCase("TC_C286735_Verify_user_ableto_create_match_from_Newmatch_option_matchwidget_Searchcandidatepage", "Verify user is able to create match from New match option on match widget in Search candidate page");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286735", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286735", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286735", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            home.ClickOnCandidate();
            candidate.VerifyCandidateSearch(candID);
            matchPage.CreateNewMatch(positionID, candID, billRate, payRate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286735", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286760_Verify_the_rates_are_inherited_from_Position_when_Perm_Salary_Placement_Match_is_created()
        {
            #region  TC_C286760 Verify the rates are inherited from Position when Perm Salary Placement Match is created
            this.TESTREPORT.InitTestCase("TC_C286760_Verify_the_rates_are_inherited_from_Position_when_Perm_Salary_Placement_Match_is_created", "Verify the rates are inherited from Position when Perm Salary Placement Match is created");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "InitialStatus");
           // string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            //int positionTypeIndex = 0;
            //int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286760", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286760", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286760", "PreviousDate");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candid = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePermPosition(companyName);
            positionPage.AddRatesForPermSalary();
            createMatch.CreateMatchForPermHourly(positionID, candid, payRate,billRate);
            //matchPage.VerifyRatesInMatch();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286760", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286761_Verify_the_rates_are_inherited_from_Position_when_Contract_to_Perm_Match_is_created()
        {
            #region  TC_C286761 Verify the rates are inherited from Position when Contract to Perm Match is created
            this.TESTREPORT.InitTestCase("TC_C286761_Verify_the_rates_are_inherited_from_Position_when_Contract_to_Perm_Match_is_created", "Verify the rates are inherited from Position when Contract to Perm Match is created");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286761", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286761", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "PreviousDate");
            string rname = ExcelOperations.GetCellValueFromExcel("TCIdC286761", "ratename");
            string ratename = rname.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candid = AddCandidatePage.id;
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
            string positionID = positionPage.CreateContractToPermPosition(companyName);
            positionPage.AddRatesInPosition(ratename);
            createMatch.CreateMatchForPermHourly(positionID, candid, payRate, billRate);
            matchPage.VerifyRatesAfterCreatingMatch();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286761", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286762_Verify_the_functionality_of_creating_Quick_Match_when_candidate_status_is_not_set()
        {
            #region  TC_C286762 Verify the functionality of creating Quick Match when candidate status is not set
            this.TESTREPORT.InitTestCase("TC_C286762_Verify_the_functionality_of_creating_Quick_Match_when_candidate_status_is_not_set", "Verify the functionality of creating Quick Match when candidate status is not set");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286762", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286762", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286762", "PreviousDate");
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
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286762", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            this.TESTREPORT.UpdateTestCaseStatus();
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286763_Verify_the_functionality_of_creating_Quick_Match_when_Position_status_is_not_set()
        {
            #region  TC_C286763 Verify the functionality of creating Quick Match when Position status is not set
            this.TESTREPORT.InitTestCase("TC_C286763_Verify_the_functionality_of_creating_Quick_Match_when_Position_status_is_not_set", "Verify the functionality of creating Quick Match when Position status is not set");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286763", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286763", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286763", "PreviousDate");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreateContractPositionwithdefault(companyName, foldergroup);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            home.ClickOnQuick();           
            matchPage.VefiryMatchWithoutPositionUpdate(positionID, candidateID, endDate, taxType,payRate,billRate);
            home.Logout();
            //matchPage.VerifyRatesInMatch();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286763", this.TESTREPORT.GetCurrentStatus());
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
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286737_Verify_user_able_create_AddNEWQP_SearchCandidateApplicationsPage()
        {
            #region TC_C286737_Verify_user_able_create_AddNEWQP_SearchCandidateApplicationsPage
            this.TESTREPORT.InitTestCase("TC_C286737_Verify_user_able_create_AddNEWQP_SearchCandidateApplicationsPage", "Verify user is able to create Add NEW QP from Search Candidate Applications Page.");
            #region TestData
            string Cname = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "ChooseCandidate");
            string position1 = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "ChooseCandidate_Application_Source");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286737", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286737", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286737", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            string candID = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();
            newCandidateApp.CreateCandidateApplication(candidateName, positionID, applicationNote, source);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCandidateApplications();
            newCandidateApp.SearchCandidateApplication(candidateName);
            newCandidateApp.AddNewQP();
            positionPage.SubmitMatchQP(candidateName, taxType, payRate, billRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286737", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286733_Verify_user_ableto_create_match_from_CandidateApplication_managepage()
        {
            #region TC_C286733_Verify_user_ableto_create_match_from_CandidateApplication_managepage
            this.TESTREPORT.InitTestCase("TC_C286733_Verify_user_ableto_create_match_from_CandidateApplication_managepage", "Verify user is able to create match from Candidate Application manage page");
            #region TestData
            string Cname = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "ChooseCandidate");
            string position1 = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "ChooseCandidate_Application_Source");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286733", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286733", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286733", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();
            newCandidateApp.CreateCandidateApplication(Cname, positionID, applicationNote, source);
            candID = newCandidateApp.GetCandidateID();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnSearch();
            //home.SearchCandidateApplications();
            //newCandidateApp.SearchCandidateApplication();
            newCandidateApp.ClickAddNewMatch(candID);
            matchPage.VerifyCreateNewMatch(billRate, payRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286733", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286734_Verify_user_ableto_creatematch_from_Searchcandidatepage()
        {
            #region TC_C286734_Verify_user_ableto_creatematch_from_Searchcandidatepage
            this.TESTREPORT.InitTestCase("TC_C286734_Verify_user_ableto_creatematch_from_Searchcandidatepage", "Verify user is able to create match from Search candidate page");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "InitialStatus");           
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286734", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286734", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286734", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnCandidate();
            candidate.VerifyCandidateSearch(candidateID);
            //candidate.ClickCreateMatchFor(candidateID);
            matchPage.CreateNewMatch(positionID, candidateID, billRate, payRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286734", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }
        //[TestMethod]
        //[TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        //public void TC_C267793_Verify_all_Requirement_fields_in_Add_Requirement_widget()
        //{
        //    #region TC_C267793 Verify all Requirement fields in Add Requirement widget
        //    this.TESTREPORT.InitTestCase("TC_C267793 Verify all Requirement fields in Add Requirement widget", "Verify all Requirement fields in Add Requirement widget");
        //    string candidateNewId = ExcelOperations.GetCellValueFromExcel("TCIdC281264", "CandidateNewId");
        //    home.Login(webURL, recruiterUserName, recruiterPassword);
        //    home.SearchCandidateWithId(candidateNewId);
        //    driver.sleepTime(10000);
        //    schedulingPage.RightClickOnRequirement();
        //    driver.sleepTime(10000);
        //    home.CilckRequirementAndValidateFields();
        //    home.Logout();
        //    home.HandleAlert();
        //    #region Test Rail Integration
        //    string status = TestRailIntegration.PublishResultsToTestRail("C281155", this.TESTREPORT.GetCurrentStatus());
        //    if (status != "")
        //        this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
        //    else
        //        this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
        //    #endregion

        //    #endregion

        //}

        [TestMethod]
        [TestCategory("Recruiter")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C269161_Verify_Clear_Items_button_erases_entered_amounts_from_all_fields_on_the_filter()
        {

            #region TC_C269161_Verify_Clear_Items_button_erases_entered_amounts_from_all_fields_on_the_filter
            this.TESTREPORT.InitTestCase("TC_C269161_Verify_Clear_Items_button_erases_entered_amounts_from_all_fields_on_the_filter", "Verify_Clear_Items_button_erases_entered_amounts_from_all_fields_on_the_filter");
            #region Test Data
          
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.MouseHoverOnSearch();
            home.ClickOnSearchMatch();



            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C269161", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }


        [TestMethod]
        [TestCategory("Recruiter")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C286736_Verify_user_ableto_createAddNEWMatch_from_SearchCandidateApplicationsPage()
        {
            #region TC_C286736_Verify_user_ableto_createAddNEWMatch_from_SearchCandidateApplicationsPage
            this.TESTREPORT.InitTestCase("TC_C286736_Verify_user_ableto_createAddNEWMatch_from_SearchCandidateApplicationsPage", "Verify user is able to create Add NEW Match from Search Candidate Applications Page.");
            #region TestData
            string Cname = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "ChooseCandidate");
            string position1 = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "ChoosePosition");
            string applicationNote = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "ApplicationNote");
            string source = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "ChooseCandidate_Application_Source");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286736", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286736", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286736", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            string candID = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnCandidateApplication();
            newCandidateApp.CreateCandidateApplication(Cname, positionID, applicationNote, source);
            home.ClickOnLogoMenu();
            home.SearchCandidateApplications();
            newCandidateApp.SearchCandidateApplication(candidateID);
            newCandidateApp.AddNewMatch(candID);
            matchPage.VerifyCreateNewMatch(billRate, payRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286736", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286772_verify_display_alert_message_when_workerscomp_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286772_verify_display_alert_message_when_workerscomp_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286772_verify_display_alert_message_when_workerscomp_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when Worker's Comp fields is empty while moving Match from Submittal to Full Placement");
            
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286772", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');          
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286772", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286772", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286772", "PositionFolderGroup"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286772", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv0, DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286771_verify_display_alert_message_when_salestaxfield_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286771_verify_display_alert_message_when_salestaxfield_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286771_verify_display_alert_message_when_salestaxfield_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when Sales Tax fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286771", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286771", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286771", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286771", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286771", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286770_verify_display_alert_message_when_burdentaxfield_empty_movingmatch_submittal_fullplacement()
        {
            #region TC_C286770_verify_display_alert_message_when_burdentaxfield_empty_movingmatch_submittal_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286770_verify_display_alert_message_when_burdentaxfield_empty_movingmatch_submittal_fullplacement", "Verify display of an Alert message when Burden Tax  fields is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286770", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286770", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286770", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286770", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286770", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

      
        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281192_Verify_draft_updated_search_timesheets_page_whenever_candidate_provides_TLE()
        {
            #region TC_C281192_Verify_draft_updated_search_timesheets_page_whenever_candidate_provides_TLE
            this.TESTREPORT.InitTestCase("TC_C281192_Verify_draft_updated_search_timesheets_page_whenever_candidate_provides_TLE", "Verify that % Draft is updated in Search Timesheets page whenever Candidate provides a TLE");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281192", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281192", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281192", "AvailableId"));
            string draftpercentage = ExcelOperations.GetCellValueFromExcel("TCIdC281192", "DraftPercentage");
            string Type = "draft";
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);

            //.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            //Match.SubmitTimesheetrecord();

            //driver.SwitchToDefaultFrame();
            //timesheet.AddTimeinTimesheet();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            //accounting.AddHoursthroughTimesheetbysearch();
            //accounting.SubmitTimesheetSearch(ApproveSuccess);
           // timesheet.EnterTimeInTimesheet();
            accounting.verifypercentageupdate(draftpercentage, Type);


            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281192", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286764_verify_functionality_Match_Creation_Candidate_Status_Notset()
        {
            #region TC_C286764_verify_functionality_Match_Creation_Candidate_Status_Notset
            this.TESTREPORT.InitTestCase("TC_C286764_verify_functionality_Match_Creation_Candidate_Status_Notset", "Verify the functionality of Match creation when candidate status is not set");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286764", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286764", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286764", "PreviousDate");
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
            home.ClickOnMatch();
            matchPage.VerifyMatchWithoutCandStatus(positionID, candid);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286764", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286765_verify_functionality_Match_Creation_Position_Status_Notset()
        {
            #region TC_C286765_verify_functionality_Match_Creation_Position_Status_Notset
            this.TESTREPORT.InitTestCase("TC_C286765_verify_functionality_Match_Creation_Position_Status_Notset", "Verify the functionality of Match creation when Position status is not set");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286765", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286765", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC286765", "PreviousDate");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreateContractPositionwithdefault(companyName, foldergroup);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.MouseHoverOnMatch();
            home.ClickOnMatch();           
            matchPage.VefiryMatchWithoutPositionUpdate(positionID, candidateID,endDate,taxType,payRate,billRate,false,true);            
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286765", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286728_verify_functionality_Moving_Match_from_Submittal_OfferMade()
        {
            #region TC_C286728_verify_functionality_Moving_Match_from_Submittal_OfferMade
            this.TESTREPORT.InitTestCase("TC_C286728_verify_functionality_Moving_Match_from_Submittal_OfferMade", "Verify the functionality of Moving Match from Submittal to Offer Made");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286728", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286728", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286728", "PositionFolderGroup"));
            string ItemType = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "InterviewItemType");
            string ItemCat = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "ItemCategory");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286728", "PositionTitle");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            string companyIdAndName = string.Empty;
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            string companyName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));


            #endregion
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            //string ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            string CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            string matchId = createMatch.CreateContractMatch(positionID, CandidateId, billRate, payRate);
            int index = matchId.IndexOf("-");
            if (index > 0)
                matchId = matchId.Substring(0, index);
            matchId = matchId.Trim();
           createMatch.SubmittalToOffermade(ItemType, ItemCat);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286728", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286729_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade()
        {
            #region TC_C286729_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade
            this.TESTREPORT.InitTestCase("TC_C286729_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade", "Verify the functionality of Moving Match from 1st round interview to Offer Made");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286729", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286729", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286729", "PositionFolderGroup"));
            string ItemType = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "InterviewItemType");
            string ItemCat = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "ItemCategory");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286729", "PositionTitle");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            string companyName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));

            #endregion
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            matchId = createMatch.CreateContractMatch(positionID, CandidateId, billRate, payRate);
            int index = matchId.IndexOf("-");
            if (index > 0)
                matchId = matchId.Substring(0, index);
            matchId = matchId.Trim();
            driver.SwitchToDefaultFrame();
            createMatch.firstroundinterviewTooffermade(ItemType, ItemCat);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286729", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286730_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directly_throughAdvance()
        {
            #region TC_C286730_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directly_throughAdvance
            this.TESTREPORT.InitTestCase("TC_C286730_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directly_throughAdvance", "Verify the functionality of  Moving  Match from 1st round  interview to Offer Made directly through Advance to Offer Made");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286730", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            //string matchId = string.Empty;
            //string companyIdAndName = string.Empty;
            //string ContactId = string.Empty;
            //string PositionId = string.Empty;
            //string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286730", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286730", "PositionFolderGroup"));
            string ItemType = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "InterviewItemType");
            string ItemCat = ExcelOperations.GetCellValueFromExcel("TCIdC286730", "ItemCategory");

            #endregion
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            string companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            string ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            string PositionId = createposition.CreateContractPosition(companyIdAndName, positionFolder);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            string CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            string matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
            int index = matchId.IndexOf("-");
            if (index > 0)
                matchId = matchId.Substring(0, index);
            matchId = matchId.Trim();
            createMatch.firstroundinterviewTooffermadethroughAdvancetooffermade(ItemType, ItemCat);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286730", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286738_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_including1st_2ndround_interview()
        {
            #region TC_C286738_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_including1st_2ndround_interview
            this.TESTREPORT.InitTestCase("TC_C286738_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_including1st_2ndround_interview", "Verify the functionality of Moving Match from Submittal to Offer Made including 1 and 2nd round interview");
            
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PositionFolderGroup"));
            string ItemType = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "InterviewItemType");
            string ItemCat = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "ItemCategory");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            PositionId = createposition.CreateContractPosition(companyIdAndName, positionFolder);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
            int index = matchId.IndexOf("-");
            if (index > 0)
                matchId = matchId.Substring(0, index);
            matchId = matchId.Trim();
            driver.SwitchToDefaultFrame();
            createMatch.SubmittalTooffermadeincluding1stroundand2ndround(ItemType, ItemCat);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286738", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286780_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Onhold()
        {
            #region TC_C286780_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Onhold
            this.TESTREPORT.InitTestCase("TC_C286780_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_Onhold", "Verify the functionality of moving Match from Submittal to Full Placement where Position status = On Hold");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286780", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "BillRate");
            string error = ExcelOperations.GetCellValueFromExcel("TCIdC286780", "positionerror");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286780", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286780", "AvailableId"));
            string positionstatus = "Onhold";
            bool Match = true;
            string matchId = timesheet.GenerateMatch(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            timesheet.NavigateToPositionFromMatch(positionstatus,Match);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            createMatch.VerifyerrormessageMatchtoFullplacement(today, error);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286780", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286779_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_bronze()
        {
            #region TC_C286779_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_bronze
            this.TESTREPORT.InitTestCase("TC_C286779_Verify_Functionality_Moving_Match_From_Submittal_To_Full_Placement_Position_Status_bronze", "Verify the functionality of moving Match from Submittal to Full Placement where Position status = Bronze");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286779", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "BillRate");
            string error = ExcelOperations.GetCellValueFromExcel("TCIdC286779", "positionerror");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286779", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286779", "AvailableId"));
            string positionstatus = "bronze";
            bool Match = true;
            string matchId = timesheet.GenerateMatch(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            timesheet.NavigateToPositionFromMatch(positionstatus,Match);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.MouseHoverOnMatches(matchId);
            createMatch.VerifyerrormessageMatchtoFullplacement(today, error);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286779", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286731_EditVerify_user_is_able_to_create_match_from_Contact_manage_page()
        {

           #region TC_C286731_EditVerify_user_is_able_to_create_match_from_Contact_manage_page
            this.TESTREPORT.InitTestCase("TC_C286731_EditVerify_user_is_able_to_create_match_from_Contact_manage_page", "This is to verify that user is able to create match from Contact manage page");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286731", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286731", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286731", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286731", "PositionFolderGroup"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            //company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            position.ClickButtonAddPosition();
            PositionId = positionPage.CreateContractPosition(companyIdAndName, positionFolder);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            //Match for right panel
           // positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            candidate.MatchfromRightPanel(companyIdAndName);
            CreateMatchPage createMatch = new CreateMatchPage();
            matchId = createMatch.CreateMatchfromRightPanel(PositionId, CandidateId, billRate, payRate);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286731", this.TESTREPORT.GetCurrentStatus());
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
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286732_EditVerify_user_is_able_to_create_match_from_Company_manage_page()
        {

            #region TC_C286732_EditVerify_user_is_able_to_create_match_from_Company_manage_page
            this.TESTREPORT.InitTestCase("TC_C286732_EditVerify_user_is_able_to_create_match_from_Company_manage_page", "This is to verify that user is able to create match from Contact manage page");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286732", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286732", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286732", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286732", "PositionFolderGroup"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
           // company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            position.ClickButtonAddPosition();
            PositionId = positionPage.CreateContractPosition(companyIdAndName, positionFolder);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            bool companies = true;
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            candidate.MatchfromRightPanel(companyIdAndName,companies);
            CreateMatchPage createMatch = new CreateMatchPage();
            matchId = createMatch.CreateMatchfromRightPanel(PositionId, CandidateId, billRate, payRate);
            home.Logout();

            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286731", this.TESTREPORT.GetCurrentStatus());
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
       // ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281193_Verify_submitted_updated_search_timesheets_page_whenever_candidate_submits_timesheet()
        {
            #region TC_C281193_Verify_submitted_updated_search_timesheets_page_whenever_candidate_submits_timesheet
            this.TESTREPORT.InitTestCase("TC_C281193_Verify_submitted_updated_search_timesheets_page_whenever_candidate_submits_timesheet", "Verify that % Submitted is updated in Search Timesheets page whenever Candidate submits a Timesheet");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281193", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281193", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281193", "AvailableId"));
            string Type = "submit";
            string draftpercentage = ExcelOperations.GetCellValueFromExcel("TCIdC281193", "DraftPercentage");
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            //driver.SwitchToDefaultFrame();
            //timesheet.AddTimeinTimesheet();
            //accounting.SubmitTimesheetSearch(ApproveSuccess);
            //driver.SwitchToDefaultFrame();
            //home.ClickOnLogoMenu();
            //home.SearchTimeSheets();
            //accounting.TimesheetSearch(timesheetid);
            //accounting.verifypercentageupdate(draftpercentage, Type);

            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            Match.SubmitTimesheetrecord();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.verifypercentageupdate(draftpercentage, Type);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281193", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281194_Verify_Approved_updated_search_timesheets_page_whenever_candidate_submits_timesheet()
        {
            #region TC_C281194_Verify_Approved_updated_search_timesheets_page_whenever_candidate_submits_timesheet
            this.TESTREPORT.InitTestCase("TC_C281194_Verify_Approved_updated_search_timesheets_page_whenever_candidate_submits_timesheet", "Verify that % Approved  is updated in Search Timesheets page whenever Candidate submits a Timesheet  and sends for an Approval");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281194", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281194", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281194", "AvailableId"));
            string Type = "Approved";
            string draftpercentage = ExcelOperations.GetCellValueFromExcel("TCIdC281194", "DraftPercentage");
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            //driver.SwitchToDefaultFrame();
            //timesheet.AddTimeinTimesheet();
            //accounting.SubmitTimesheetSearch(ApproveSuccess);
            //accounting.ApproveTimesheetSearch();
            //driver.SwitchToDefaultFrame();
            //home.ClickOnLogoMenu();
            //home.SearchTimeSheets();
            //accounting.TimesheetSearch(timesheetid);
            //accounting.verifypercentageupdate(draftpercentage, Type);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            Match.SubmitTimesheetrecord();
            Match.ApproveTimesheetrecord();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.verifypercentageupdate(draftpercentage, Type);

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281194", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        //////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281195_Verify_Rejected_updated_search_timesheets_page_whenever_candidate_Approved_updated()
        {
            #region TC_C281195_Verify_Rejected_updated_search_timesheets_page_whenever_candidate_Approved_updated
            this.TESTREPORT.InitTestCase("TC_C281195_Verify_Rejected_updated_search_timesheets_page_whenever_candidate_Approved_updated", "Verify that % Rejected  is updated in Search Timesheets page whenever Candidate % Approved  is updated in Search Timesheets page whenever Candidate submits a Timesheet  and is rejected by an approver");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281195", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281195", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281195", "AvailableId"));
            string Type = "Reject";
            string draftpercentage = ExcelOperations.GetCellValueFromExcel("TCIdC281195", "RejectPercentage");
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "",false,true,false,false,true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            driver.SwitchToDefaultFrame();
            Match.AddhoursTimesheetsearch();
            timesheet.SubmittimesheetforReject();
            accounting.RejectTimesheetRecord(Type);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.SearchTimeSheets();
            accounting.TimesheetSearch(timesheetid);
            accounting.verifypercentageupdate(draftpercentage, Type);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281195", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C290183_Verify_Functionality_AddMatch_from_ManagePosition()
        {
            #region TC_C290183_Verify_Functionality_AddMatch_from_ManagePosition
            this.TESTREPORT.InitTestCase("TC_C290183_Verify_Functionality_AddMatch_from_ManagePosition", "Verify the functionality of Add Match from Manage Position Page");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC290183", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290183", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290183", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            string CandidateId = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);            
            driver.SwitchToDefaultFrame();
            positionPage.MatchfromRightPanel();
            string matchId = createMatch.CreateMatchfromRightPanel(positionID, CandidateId, billRate, payRate,false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290183", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }
        
//        [TestMethod]
//        [TestCategory("Recruiter")]
//        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
//        public void TC_C286738_new_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directlythroughAdvancetooffermade()
//        {
//            #region TC_C286738__verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directlythroughAdvancetooffermade 
//            this.TESTREPORT.InitTestCase("TC_C286new_verify_functionality_Moving_Match_from_1stroundinterview_OfferMade_directlythroughAdvancetooffermade", "Verify the functionality of  Moving  Match from 1st round  interview to Offer Made directly through Advance to Offer Made");
//            home.Login(webURL, recruiterUserName, recruiterPassword);
//            #region Test Data
//            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "Candidate");
//            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
//            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "City");
//            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "Title");
//            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "ContactMail");
//            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
//            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "FolderGroupId"));
//            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PostalCode");
//            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "Website");
//            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PhoneNumber");
//            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
//            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
//            string matchId = string.Empty;
//            string companyIdAndName = string.Empty;
//            string ContactId = string.Empty;
//            string PositionId = string.Empty;
//            string CandidateId = string.Empty;
//            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PayRate");
//            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "BillRate");
//            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "AvailableId"));
//            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286738", "PositionFolderGroup"));
//            string ItemType = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "InterviewItemType");
//            string ItemCat = ExcelOperations.GetCellValueFromExcel("TCIdC286738", "ItemCategory");

//#endregion
//            home.ClickOnLogoMenu();
//            home.NavigateToAddnew();
//            home.NavigateToAddCompany();
//            companyIdAndName = company.AddCompany(name, city, postalcode, email, webURL, phoneNumber);
//            company.ClickonAccountingTab();
//            company.AddContactFromCompany();
//            driver.SwitchToDefaultFrame();
//            candidate.AddContact(name);
//            candidate.Addtitletocontact(title);
//            candidate.AddEmailToContact(email);
//            candidate.SaveContact();
//            ContactId = AddCandidatePage.id;
//            driver.SwitchToDefaultFrame();
//            position.ClickButtonAddPosition();
//            PositionId = createposition.CreateContractPosition(companyIdAndName, positionFolder);
//            driver.SwitchToDefaultFrame();
//            home.NavigateToAddCandidate();
//            candidate.AddCandidatewithoutResume(name, foldergroup, email);
//            CandidateId = AddCandidatePage.id;
//            candidate.UpdateCandidateStatus(candidateStatus);
//            matchId = createMatch.CreateContractMatch(PositionId, CandidateId, billRate, payRate);
//            int index = matchId.IndexOf("-");
//            if (index > 0)
//                matchId = matchId.Substring(0, index);
//            matchId = matchId.Trim();
//            driver.SwitchToDefaultFrame();
//            createMatch.SubmittalTooffermadeincluding1stroundand2ndround(ItemType, ItemCat);
//            home.Logout();
//            home.HandleAlert();
//            #region Test Rail Integration
//            string status = TestRailIntegration.PublishResultsToTestRail("C286738", this.TESTREPORT.GetCurrentStatus());
//            if (status != "")
//                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
//            else
//                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
//            #endregion

//            #endregion
//        }

        [TestMethod]
        [TestCategory("Recruiter")]
       // ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281230_Verify_Export_WIP_Disable_Export_Button_After_Single_Click()
        {
            #region TC_C281230_Verify_Export_WIP_Disable_Export_Button_After_Single_Click
            this.TESTREPORT.InitTestCase("TC_C281230_Verify_Export_WIP_Disable_Export_Button_After_Single_Click", "Verify Functionality Of Disable Export Button After Single Click");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAccounting();
            home.ExportWIPButtonDisabled();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281230", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281350_Verify_Mandatory_Validation_Checks_in_Advance_Match_Timeline_with_Missing_some_requirements()
        {
            #region  TC_C281350 Verify Mandatory Validation Checks in Advance Match Timeline with Missing some requirements
            this.TESTREPORT.InitTestCase("TC_C281350_Verify_Mandatory_Validation_Checks_in_Advance_Match_Timeline_with_Missing_some_requirements", "Verify Mandatory Validation Checks in Advance Match Timeline with Missing some requirements");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "RequirementName");
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "Type");
            string targetType = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "TargetType");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "Weight");
            string searchReqTemplate = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "SearchReqTemplate");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281350", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281350", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC281350", "PreviousDate");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
           // home.ClickControlPanelModules();
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
            // home.ClickControlPanelModules();
            string requirement = home.AddRequirementForCompany(req, type, targetType, weight);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            home.AddAndsaveRequirements(searchReqTemplate, requirement);
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreateContractPosition(companyName, foldergroup);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            string matchId = matchPage.CreateContractMatch(positionID, candidateName, billRate, payRate);
            //matchPage.CreateContractMatchForValidate(positionID, candidateName, billRate, payRate);
            matchPage.VerifySubmitalPopUpMsg();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyById();
            driver.sleepTime(10000);
            home.RightClickOnRequirementAndChangeStatus();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.RefreshMatch(matchId);
            matchPage.VerifyAfterChangingStatus();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("", this.TESTREPORT.GetCurrentStatus());
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
       // [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281103_Verify_that_Contact_is_able_to_create_a_Position_from_Client_Project()
        {
            #region  TC_C281103 Verify that Contact is able to create a Position from Client Project
            this.TESTREPORT.InitTestCase("TC_C281103_Verify_that_Contact_is_able_to_create_a_Position_from_Client_Project", "Verify that Contact is able to create a Position from Client Project");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281103","RequirementName");
            string type = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "Type");
            string targetType = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "TargetType");
            string weight = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "Weight");
            string searchReqTemplate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "SearchReqTemplate");
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "InitialStatus");
            string candidateID = AddCandidatePage.id;
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
           int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281103", "FolderGroupId"));
            string companyIdAndName = string.Empty;
           int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281103", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PreviousDate");
            //Agreement
            string selectCompanySource = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "ContactInfo");
            string agreementName = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "AgreementNameNew");
            string legalName = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "LegalName");
            string agreementType = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "AgreementType");
            string billingTerm = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "BillingTerm");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string folderGroupForContact = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "FolderGroupForContact");

            //Contact Access
            string contactType = ExcelOperations.GetCellValueFromExcel("TCIdC281103","ContactType");
            string actionStatusG = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "ActionStatusG");
            string newPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "NewPassword");
            string currentPassword = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "CurrentPassword");
            string vendorBillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "VendorBillRate");
            string clientBillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281103", "clientBillRate");
            string txtClass= ExcelOperations.GetCellValueFromExcel("TCIdC281103", "TxtClass");
            string ContactEmailAccses= ExcelOperations.GetCellValueFromExcel("TCIdC281103", "ContactAccessEmail");
            string contactAccessEmail = ContactEmailAccses.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281103", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281103", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyByPassingId();
            company.AddAgreement();
            company.CreatAgreementFromContact(agreementName, legalName, agreementType, billingTerm);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyByPassingId();
            home.AddFolderGroup(folderGroupForContact);
            company.AddDepartment();
            company.AddPositionTemplateAndVerify(agreementName, today, folderGroupForContact);
            company.AddRates(payRate, vendorBillRate, clientBillRate, txtClass);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchContact();
            company.ManageLogin();
            company.ContactGiveAccess(contactAccessEmail, currentPassword);
            company.VerifyActionStatus(actionStatusG);
            home.Logout();
            home.Login(webURL, contactAccessEmail, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            driver.sleepTime(15000);
            positionPage.CreatePositionFromContact(positionTitle,startDate, positionTypeIndex, folderGroupIndex);
            //driver.sleepTime(10000);
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281103", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C290184_Verify_functionality_Add_Match_from_Manage_Candidate_Page_Match_Widget()
        {

            #region TC_C290184_Verify_functionality_Add_Match_from_Manage_Candidate_Page_Match_Widget
            this.TESTREPORT.InitTestCase("TC_C290184_Verify_functionality_Add_Match_from_Manage_Candidate_Page_Match_Widget", "Verify functionality Add Match from Manage Candidate Page Match Widget");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290184", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC290184", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290184", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290184", "PositionFolderGroup"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            PositionId = positionPage.CreateContractPosition(companyIdAndName, positionFolder);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            // Create Match from Right Click
            createMatch.RightClickToAddNewMatch();
            createMatch.CreateMatchfromRightClick(PositionId, CandidateId, billRate, payRate,"","",false);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290184", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C290186_Verify_Functionality_Add_Match_From_Manage_Candidate_Page()
        {

            #region TC_C290186_Verify_Functionality_Add_Match_From_Manage_Candidate_Page
            this.TESTREPORT.InitTestCase("TC_C290186_Verify_Functionality_Add_Match_From_Manage_Candidate_Page", "Verify functionality of Add Match from Manage Candidate Page");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290186", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "TaxType");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC290186", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290186", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290186", "PositionFolderGroup"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            PositionId = positionPage.CreateContractPosition(companyIdAndName, positionFolder);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            positionPage.ClickOnQP();
            createMatch.CreateMatchfromRightClick(PositionId, CandidateId, billRate, payRate,taxType,endDate,false,true);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290186", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C290187_Verify_functionality_Add_QPMatch_from_Manage_Candidate_Page_Match_Widget()
        {

            #region TC_C290187_Verify_functionality_Add_QPMatch_from_Manage_Candidate_Page_Match_Widget
            this.TESTREPORT.InitTestCase("TC_C290187_Verify_functionality_Add_QPMatch_from_Manage_Candidate_Page_Match_Widget", "Verify functionality Add Match from Manage Candidate Page Match Widget");
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290187", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.ToString("dd/M/yyyy");
            string matchId = string.Empty;
            string companyIdAndName = string.Empty;
            string ContactId = string.Empty;
            string PositionId = string.Empty;
            string CandidateId = string.Empty;
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290187", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290187", "PositionFolderGroup"));
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC290187", "TaxType");
            string endDate = DateTime.Now.AddMonths(2).ToString("M/dd/yyyy").Replace('-', '/');
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(candidateName, city, postalcode, email, webURL, phoneNumber);
            company.ClickonAccountingTab();
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(email);
            candidate.SaveContact();
            ContactId = AddCandidatePage.id;
            driver.SwitchToDefaultFrame();
            position.ClickButtonAddPosition();
            PositionId = positionPage.CreateContractPosition(companyIdAndName, positionFolder);
            driver.SwitchToDefaultFrame();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, email);
            CandidateId = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(candidateStatus);
            // Create Match from Right Click
            createMatch.RightClickToAddQPMatch();
            createMatch.CreateMatchfromRightClick(PositionId, CandidateId, billRate, payRate,taxType,endDate,false,true);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290187", this.TESTREPORT.GetCurrentStatus());
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
       // [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281124_Login_Submit_Time_FullSite()
        {
            #region TC_C281124_Login_Submit_Time_FullSite
            this.TESTREPORT.InitTestCase("TC_C281124_Login_Submit_Time_FullSite", "Login and Submit Time - Full Site");
            #region TestData
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281124", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281124", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281124", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281124", "AvailableId"));
            string currentPassword = "password";
            string newPassword = "Password@123";
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false,true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            home.Logout();
            home.Login(webURL, email, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            dashboard.SelectTimesheetinTimesheetWidget(matchId);
            timesheet.AddTimeinTimesheet(false);
            timesheet.SubmitTimesheet_FullSite();
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281124", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C281219_Verifying_Message_Timesheet_Payroll_Edit()
        {
            #region TC_C281219_Verifying_Message_Timesheet_Payroll_Edit
            this.TESTREPORT.InitTestCase("TC_C281219_Verifying_Message_Timesheet_Payroll_Edit", "Verifying Message on Timesheet for Payroll Edit");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281219", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281219", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281219", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281219", "AvailableId"));
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "",false,true,true,false,true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            timesheet.AddTimeinTimesheet(true);
            timesheet.SubmitTimesheet();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281219", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281220_Verifying_SimpleHoursplusMinutes_Timesheets_TotalHours_should_match_Recruiterlogin_and_Candidatelogin()
        {
            #region TC_C281220_Verifying_SimpleHoursplusMinutes_Timesheets_TotalHours_should_match_Recruiterlogin_and_Candidatelogin
            this.TESTREPORT.InitTestCase("TC_C281220_Verifying_SimpleHoursplusMinutes_Timesheets_TotalHours_should_match_Recruiterlogin_and_Candidatelogin", "Verifying Simple Hours + Minutes Timesheets 'Total Hours' should match in Recruiter login and Candidate login");
            #region Testdata
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281220", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "ApproveSuccess");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281220", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281220", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281220", "AvailableId"));
            string currentPassword = "password";
            string newPassword = "Password@123";
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);
            string timesheetid = matchPage.CreateTimesheets(matchId);
            string totalCount = timesheet.AddTimeinTimesheet(true);
                //timesheet.AddTimeinTimesheet();
            //timesheet.SubmitTimesheet();
            home.Logout();
            home.Login(webURL, email, currentPassword);
            home.ChangePassword(currentPassword, newPassword);
            dashboard.SelectTimesheetinTimesheetWidget(matchId);
            string candidateTotalCount=timesheet.VerifyTimesheetinCandidateLogin();
            if(totalCount.Equals(candidateTotalCount))
               TESTREPORT.LogSuccess("Candidate Total Count", "Total hours entered in Time sheet in recruiter and candidate login are equal");
             else
               TESTREPORT.LogFailure("Candidate Total Count", "Total hours entered in Time sheet in recruiter and candidate login are not equal");
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281220", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C286766_Verify_Copyvalues_works_intended_when_creatingmatches_for_multiplecandidates_for_sameposition()
        {
            #region TC_C286766_Verify_Copyvalues_works_intended_when_creatingmatches_for_multiplecandidates_for_sameposition
            this.TESTREPORT.InitTestCase("TC_C286766_Verify_Copyvalues_works_intended_when_creatingmatches_for_multiplecandidates_for_sameposition", "Verify Copy values works as intended when creating matches for multiple candidates for the same position");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string name1 = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "CandidateName");
            string candidateName1 = name1.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC286766", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("","PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286766", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286766", "AvailableId"));
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            driver.sleepTime(1000);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName1, foldergroup, mailID);
            string candidateID1 = AddCandidatePage.id;
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
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName1);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.ClickOnMatch();
            matchPage.CreateMatchForMultipleCandidate(positionID, candidateID, candidateID1, billRate, payRate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286766", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281122_Timesheet_Creation_Candidate_Providing_NegativeHours_Expenses_Timesheets()
        {
            #region TC_C281122_Timesheet_Creation_Candidate_Providing_NegativeHours_Expenses_Timesheets
            this.TESTREPORT.InitTestCase("TC_C281122_Timesheet_Creation_Candidate_Providing_NegativeHours_Expenses_Timesheets", "Timesheet creation for a Candidate by providing Negative Hours in Timesheets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281122", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "NegativePayfield");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "NegativeBillfield");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "Load");
            string unit = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "UnitExpense");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281122", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281122", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281122", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "");
            string timesheetid = matchPage.CreateTimesheetswithExpenses(matchId, paid, billed, load, unit);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281122", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281155_Verify_VendorContact_Add_Widgets()
        {
            #region TC_C281155_Verify_VendorContact_Add_Widgets
            this.TESTREPORT.InitTestCase("TC_C281155_Verify_VendorContact_Add_Widgets", "Verify Vendor Contact Add Widgets");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnTools();
            //home.ClickOnControlPanel();
            //home.ClickOnControlPanelModules();
            ////a[text()='Design Dashboards']
            dashboard.ClickOnModifyDashboard();
            dashboard.SelectWidgetAndZoneForRecruiter();
            dashboard.ClickOnAddWidgetButton();
            //dashboard.VerifyAddedWidgetInRecruiter();
            //dashboard.ClickOnSubmit();
            //driver.sleepTime(5000);
            //dashboard.VerifyAddedWidgetInRecruiter();
            home.Logout();
            //home.HandleAlert();
            //home.Login(webURL, vendorContactName, vendorContactPassword);
            //dashboard.VerifyAddedWidgetInRecruiter();
            //home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281155", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C290442_Verify_all_Requirement_fields_in_Add_Requirement_widget()
        {
            #region TC_C290442 Verify all Requirement fields in Add Requirement widget
            this.TESTREPORT.InitTestCase("TC_C290442 Verify all Requirement fields in Add Requirement widget", "Verify all Requirement fields in Add Requirement widget");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC290442", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC290442", "MailID");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290442", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC290442", "AvailableId"));
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            candidate.UpdateCandidateStatus(statusId);
            //driver.sleepTime(10000);
            schedulingPage.RightClickOnRequirement();
            //driver.sleepTime(10000);
            home.CilckRequirementAndValidateFields();
            home.Logout();
            home.HandleAlert();
           
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290442", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C290441_Verify_Clear_Items_button_erases_entered_amounts_from_all_fields_on_the_filter()
        {
            #region TC_C290441 Verify Clear Items button erases entered amounts from all fields on the filter
            this.TESTREPORT.InitTestCase("TC_C290441 Verify Clear Items button erases entered amounts from all fields on the filter", "Verify Clear Items button erases entered amounts from all fields on the filter");
             string fromSalary = ExcelOperations.GetCellValueFromExcel("TCIdC290441", "FromSalary");
             string toSalary= ExcelOperations.GetCellValueFromExcel("TCIdC290441", "ToSalary");
             string OfferSalary= ExcelOperations.GetCellValueFromExcel("TCIdC290441", "OfferSalary");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.ClickMatchesAndValidate(fromSalary, toSalary, OfferSalary);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C290441", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            
            #endregion

}
        #endregion

        [TestMethod]
        [TestCategory("Recruiter")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\RecruiterTestData.csv", "RecruiterTestData#csv", DataAccessMethod.Sequential), DeploymentItem("RecruiterTestData.csv")]
        public void TC_C267315_Verify_the_company_record_link_in_Add_Credentialing_widget()
        {
            #region TC_C267315_Verify_the_company_record_link_in_Add_Credentialing_widget
            this.TESTREPORT.InitTestCase("TC_C267315_Verify_the_company_record_link_in_Add_Credentialing_widget", "This test case verifies the company record link open's in Add Credentialing widget Requirements");
           
            #region Test Data
            string candidate = TestContext.DataRow["CredentialCandidate"].ToString();
            #endregion

            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.SearchCandidate(candidate);
            //search.AddCredentialRequest();
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C267315", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }


        [TestMethod]
        [TestCategory("Recruiter")]
        // //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDataErecruit.csv", "TestDataErecruit#csv", DataAccessMethod.Sequential), DeploymentItem("TestDataErecruit.csv")]
        public void TC_C281292_Verify_creating_Position_CompanyManageScreen()
        {
            #region TC_C281292_Verify_creating_Position_ContactManageScreen
            this.TESTREPORT.InitTestCase("TC_C281292_Verify_creating_Position_CompanyManageScreen", "Verify creating Position from Company Manage Screen");
            #region Test Data
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "InitialStatus");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "Title");
            string endReason = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "EndReason");
            string placementGrade = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "PlacementGrade");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281292", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy").Replace('-', '/');
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281292", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281292", "FolderGroupId"));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281292", "FolderGroupId"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281292", "AvailableId"));
            string companyIdAndName = string.Empty;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.NavigateToAddnew();
            home.NavigateToAddCompany();
            companyIdAndName = company.AddCompany(companyName, city, postalCode, Email, webURL, phoneNumber);
            company.AddContactFromCompany();
            driver.SwitchToDefaultFrame();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddEmailToContact(Email);
            candidate.SaveContact();
            driver.SwitchToDefaultFrame();
            home.ClickOnLogoMenu();
            home.MouseHoverOnSearch();
            home.SearchCompanyByPassingId();
            driver.sleepTime(10000);
            position.ClickButtonAddPosition();
            positionPage.CreateContractPosition(companyIdAndName, foldergroup, startDate);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281292", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
        public void TC_C299042_Verify_match_created_when_ApproveandEmailContact_selected()
        {
            #region  TC_C299042 Verify whether match is created when 'Approve and Email Contact' is selected
            this.TESTREPORT.InitTestCase("TC_C299042_Verify_match_created_when_ApproveandEmailContact_selected", "Verify whether match is created when 'Approve and Email Contact' is selected.");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299042", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299042", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC299042", "PreviousDate");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            matchPage.CreateMatch_ApproveandEmailContact(positionID, candidateID, payRate, billRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C299042", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C299040_Verify_match_created_when_CreateMatchonly_selected()
        {
            #region  TC_C299040 Verify whether match is created when 'Create Match only' is selected
            this.TESTREPORT.InitTestCase("TC_C299040_Verify_match_created_when_CreateMatchonly_selected", "Verify whether match is created when 'Create Match only' is selected");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299040", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299040", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC299040", "PreviousDate");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            matchPage.CreateMatch_CreateMatchonly(positionID, candidateID, payRate, billRate);
            
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C299040", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C299041_Verify_match_created_when_RequestApproval_selected()
        {
            #region  TC_C299041 Verify whether match is created when 'Request Approval' is selected
            this.TESTREPORT.InitTestCase("TC_C299041_Verify_match_created_when_RequestApproval_selected", "Verify whether match is created when 'Request Approval' is selected");
            #region TestData
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "PositionTitle");
            string dept = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "Department");
            string initialStatus = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "InitialStatus");
            string taxType = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "TaxType");
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "BillRate");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "Title");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string postalCode = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "PostalCode");
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "MailID");
            string email = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "ContactMail");
            string Email = email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299041", "FolderGroupId"));
            string companyIdAndName = string.Empty;
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC299041", "AvailableId"));
            string previousDate = ExcelOperations.GetCellValueFromExcel("TCIdC299041", "PreviousDate");
            int positionTypeIndex = 0;
            int folderGroupIndex = 0;
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
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
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate, false);
            matchPage.CreateMatch_RequestApproval(positionID, candidateID, payRate, billRate);
            home.Logout();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C299041", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion
            this.TESTREPORT.UpdateTestCaseStatus();
            #endregion
        }

        [TestMethod]
        [TestCategory("Vendor Contact")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ErecruitTestDataCopy.csv", "ErecruitTestDataCopy#csv", DataAccessMethod.Sequential), DeploymentItem("ErecruitTestDataCopy.csv")]
        public void TC_C286769_verify_display_Alertmessage_StartDate_field_empty_whilemoving_match_fullplacement()
        {
            #region TC_C286769_verify_display_Alertmessage_StartDate_field_empty_whilemoving_match_fullplacement
            this.TESTREPORT.InitTestCase("TC_C286769_verify_display_Alertmessage_StartDate_field_empty_whilemoving_match_fullplacement", "Verify display of an Alert message when start date field is empty while moving Match from Submittal to Full Placement");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            #region Test Data
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286769", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            #endregion
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC286769", "BillRate");
            int candidateStatus = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286769", "AvailableId"));
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC286769", "PositionFolderGroup"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, candidateStatus, "");

            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C286769", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281210_Timesheet_Creation_Candidate_Expense_Enabled()
        {
            #region TC_C281210_Timesheet_Creation_TimeEnabled
            this.TESTREPORT.InitTestCase("TC_C281210_Timesheet_Creation_Candidate_Expense_Enabled", "Timesheet creation for a Candidate with expense enabled");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281210", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "Load");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281210", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281210", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281210", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);

            string timesheetid = matchPage.CreateTimesheetswithTimeenables(matchId, false, true, false);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("C281210", this.TESTREPORT.GetCurrentStatus());
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
        public void TC_C281215_Timesheet_Adjustment_Candidate_TimeDisabled_ExpenseEnabled()
        {
            #region TC_C281215_Timesheet_Adjustment_Candidate_TimeDisabled_ExpenseEnabled
            this.TESTREPORT.InitTestCase("TC_C281215_Timesheet_Adjustment_Candidate_TimeDisabled_ExpenseEnabled", "Timesheet adjustment for a candidate with time as disabled and expense as enabled");
            home.Login(webURL, recruiterUserName, recruiterPassword);
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "CandidateName");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281215", "FolderGroupId"));
            string postalcode = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "PhoneNumber");
            string phoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string ApproveSuccess = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "ApproveSuccess");
            string paid = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "Paid");
            string billed = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "Billed");
            string load = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "Load");
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string payRate = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "PayRate");
            string billRate = ExcelOperations.GetCellValueFromExcel("TCIdC281215", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281215", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281215", "AvailableId"));
            string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, postalcode, url, phoneNumber, today, payRate, billRate, positionFolder, statusId, "", false, true, false, false, true);

            string timesheetid = matchPage.CreateTimesheetswithTimeenables(matchId, false, false, true);
            home.Logout();
            home.HandleAlert();
            #region Test Rail Integration
            string status = TestRailIntegration.PublishResultsToTestRail("TCIdC281215", this.TESTREPORT.GetCurrentStatus());
            if (status != "")
                this.TESTREPORT.LogInfo("Publish Results", "Error: " + status);
            else
                this.TESTREPORT.LogSuccess("Publish Results", "Successfully published Test Results to Test Rail");
            #endregion

            #endregion
        }


        [TestMethod]
        [TestCategory("Recruiter")]
        public void TC_C281255_Verify_Requirement_Blocks_Moving_Match_FullPlacement()
        {
            #region TC_C281255_Verify_Requirement_Blocks_Moving_Match_FullPlacement
            this.TESTREPORT.InitTestCase("TC_C281255_Verify_Requirement_Blocks_Moving_Match_FullPlacement", "Verify Requirement Blocks Moving A Match To Full Placement");
            #region Test Data
            string req = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "RequirementName");
            string reqtype = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "RequirementType");
            string reqtarget = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "RequirementTarget");
            string reqweight = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "RequirementWeight");
            //string candidate = ExcelOperations.GetCellValueFromExcel("CredentialCandidate");
            string name = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "Candidate");
            string candidateName = name.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string searchname = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "SearchName");
            string city = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "City");
            string title = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "Title");
            string Email = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "ContactMail");
            string email = Email.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            int foldergroup = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281255", "FolderGroupId"));
            string PostalCode = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PostalCode");
            string url = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "Website");
            string phoneNo = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PhoneNumber");
            string PhoneNumber = phoneNo.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string today = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
            string positionTitle = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PositionTitle");
            string cName = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "CompanyName");
            string companyName = cName.Replace("{random}", DateTime.Now.ToString("MM:dd:hh:mm:ss").Replace(":", ""));
            string startDate = DateTime.Now.AddMonths(1).ToString("dd/M/yyyy");
            string endDate = DateTime.Now.AddMonths(2).ToString("dd/M/yyyy");
            int positionTypeIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PositionTypeIndex"));
            int folderGroupIndex = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281255", "AvailableId"));
            string PayRate = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PayRate");
            string BillRate = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "BillRate");
            int positionFolder = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281255", "PositionFolderGroup"));
            int statusId = Convert.ToInt32(ExcelOperations.GetCellValueFromExcel("TCIdC281255", "AvailableId"));
            string mailID = ExcelOperations.GetCellValueFromExcel("TCIdC281255", "MailID");
            #endregion
            home.Login(webURL, recruiterUserName, recruiterPassword);
            home.ClickOnLogoMenu();
            home.MouseHoverOnTools();
            home.ClickOnControlPanel();
            home.ClickOnControlPanelModules();
           // string requirement = home.AddNewRequirement(req, reqtype, reqtarget, reqweight, true);
            driver.SwitchToDefaultFrame();
            driver.sleepTime(5000);
            home.ClickOnLogoMenu();
            home.MouseHoverOnAddNew();
            home.NavigateToAddCompany();
            string companyIdAndName = company.AddCompany(candidateName, city, PostalCode, email, webURL, PhoneNumber);
            //string matchId = timesheet.GenerateContractMatchId(candidateName, city, title, email, foldergroup, PostalCode, url, PhoneNumber, today, PayRate, BillRate, positionFolder, statusId, "");
           // company.AddRequirementToCompany(requirement);
            //driver.SwitchToDefaultFrame();
            //home.ClickOnLogoMenu();
            //home.MouseHoverOnAddNew();
            home.NavigateToAddCandidate();
            candidate.AddCandidatewithoutResume(candidateName, foldergroup, mailID);
            string candidateID = AddCandidatePage.id;
            candidate.UpdateCandidateStatus(statusId);
            string candID = AddCandidatePage.id;
            company.AddContactFromCompany();
            candidate.AddContact(candidateName);
            candidate.Addtitletocontact(title);
            candidate.AddMobileNumber();
            candidate.SaveContact();
            position.ClickButtonAddPosition();
            string positionID = positionPage.CreatePosition(positionTitle, positionTypeIndex, folderGroupIndex, companyName, startDate);
            //matchPage.CreateMatchfromRightPanel(positionID, candID, BillRate, PayRate, false);
            home.Logout();
            home.HandleAlert();
            #endregion
        }

        [TestMethod]
        [TestCategory("Recruiter")]
       
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
                candidate.ClickonTagsEdit(id);
                candidate.AddNote(task, note);
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
        }

}


