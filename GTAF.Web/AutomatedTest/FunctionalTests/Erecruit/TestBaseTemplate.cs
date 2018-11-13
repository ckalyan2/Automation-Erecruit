using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestReporter;
using Engine.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using StandardUtilities;
using Engine.Factories;
using AUT.Selenium.ApplicationSpecific.Erecruit.Pages;
namespace AutomatedTest.FunctionalTests.Erecruit
{
    [TestClass]
    public class TestBaseTemplate
    {

        private string dataFileName = null;
        private int currentFileRowPointer = 1;
        private TestContext testContextInstance;
        public static IWebDriver driver = null;        
        public HomePage home = null;
        public SearchCandidatesPage search = null;
        public AddCandidatePage candidate = null;
        public AddCompanyPage company = null;
        public SearchPositionsPage searchposition = null;
        public AddVendorPage vendor = null;
        public AccountingPage accounting = null;
        public SearchMatchPage Match = null;
        public AddPositionPage position = null;
        public PositionSchedulingPage schedulingPage = null;
        public CreatePositionPage positionPage = null;
        public DashboardPage dashboard = null;
        public ControlPanelPage controlPanel = null;
        public CreateMatchPage matchPage = null;
        public QuickSearchPage searchPage = null;
        public ReportsPage reports = null;
        public TimeSheet timesheet = null;
        public Utility util = null;
        public ManageRequirementsPage manage = null;
        public NewCandidateApplications newCandidateApp = null;
        public SmartForms smartform = null;
        public ClientProjectPage clientproject = null;
        public SeedPage seed = null;
        public Localization localization = null;
        public CreateMatchPage createMatch = null;
        public CreatePositionPage createposition = null;

        public TestBaseTemplate()
        {
         driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
         home = new HomePage();
         search = new SearchCandidatesPage();
         candidate = new AddCandidatePage();
         company = new AddCompanyPage();
         searchposition = new SearchPositionsPage();
         vendor = new AddVendorPage();
         accounting = new AccountingPage();
         Match = new SearchMatchPage();
         position = new AddPositionPage();
         schedulingPage = new PositionSchedulingPage();
         positionPage = new CreatePositionPage();
         dashboard = new DashboardPage();
         controlPanel = new ControlPanelPage();
         matchPage = new CreateMatchPage();
         searchPage = new QuickSearchPage();
         reports = new ReportsPage();
         timesheet = new TimeSheet();
         util = new Utility();
         manage = new ManageRequirementsPage();
         newCandidateApp = new NewCandidateApplications();
         smartform = new SmartForms();
         clientproject = new ClientProjectPage();
         seed = new SeedPage();
         localization = new Localization();
         createMatch = new CreateMatchPage();
         createposition = new CreatePositionPage();
        }


        public TestContext TestContext
        {
         get
            {
            return testContextInstance;
            }
           set
           {
           testContextInstance = value;
           }
        }

        [AssemblyInitialize]
        public static void BeforeAllTestsExecution(TestContext testContext)
        {
            //#region Get webdriver instance
            //Console.WriteLine(String.Format("Current Directory - {0}", System.IO.Directory.GetCurrentDirectory()));
            //driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
            //Console.WriteLine("title " + driver.Title);
            //#endregion       
        }
        [AssemblyCleanup]
        public static void AfterAllTestsExecution()
        {
            //after execution, update extent report with gallop logo 
            /*driver can not be initialized in static method as driver is instance variable*/
            driver.Quit();         
            WebDriverFactory.Free();
            EngineSetup.TestReport.Close();
            TestBaseTemplate.UpdateTestReport();
        }
        [ClassInitialize]
        public static void BeforeAllTestsInATestClassExecution(TestContext testContext)
        {

        }
        [ClassCleanup]
        public static void AfterAllTestsInATestClassExecution()
        {
        }


        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void BeforeEachTestCaseExecution()
        {
            

            #region Get webdriver instance
            //Console.WriteLine(String.Format("Current Directory - {0}", System.IO.Directory.GetCurrentDirectory()));

            driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
            //Console.WriteLine("title " + driver.Title);
            #endregion

            //#region WebApplication - Erecruit
            ////EngineSetup.TestReport.InitTestCase("Launch Application", "Verify Application Is Launched Successfully");

            ////driver.Navigate().GoToUrl(EngineSetup.WEBURL);
            ////EngineSetup.TestReport.LogSuccess(String.Format("Launch Application On Browser - {0}",EngineSetup.BROWSER), String.Format("Application - {0} Launch Successful", EngineSetup.WEBURL));
            //// EngineSetup.TestReport.UpdateTestCaseStatus();

            //#endregion       
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void AfterEachTestCaseExecution()
        {
            if (driver != null)
                driver.Quit();
            WebDriverFactory.Free();
            // EngineSetup.TestReport.Close();
            EngineSetup.TestReport.UpdateTestCaseStatus();
            TestBaseTemplate.UpdateTestReport();
          }
         /// <summary>



        protected string RANDVALUE
        {
            get { return EngineSetup.GetRandomValue(); }

        }

        protected string DATAFILENAME
        {
            get
            {
                //this.dataFileName = String.Format("{0}{1}", this.GetType().Name, ".csv");
                this.dataFileName = System.IO.Directory.GetCurrentDirectory();
                //this.dataFileName = System.IO.Directory.GetCurrentDirectory()+"\\TestData\\BKFS";   //uncomment for debugging             
                return this.dataFileName;
            }

        }

        protected int DATAFILEROWPOINTER
        {
            get { return this.currentFileRowPointer; }
            set { this.currentFileRowPointer = value; }
        }

        protected IReporter TESTREPORT
        {
            get { return EngineSetup.TestReport; }
        }

        protected string SCREENSHOTFILE
        {
            get { return EngineSetup.GetScreenShotPath(); }
        }
        /*To update extentReport to have Gallop Logo*/
        protected static void UpdateTestReport()
        {
            /*Dictionary should contain
            * SourceFile
            * Text1ToBeReplaced
            * Text1ToReplace
            * Text2ToBeReplaced
            * Text2ToReplace 
            * Text3ToBeReplaced
            * Text3ToReplace 
         
            */
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>();
            if (EngineSetup.TestReport is ExtentReporter)
            {

            keyValuePair["SourceFile"] = EngineSetup.TestReportFileName;

            //Text1ToBeReplaced
             string str = "<div class='logo-container'>\r\n                                    <a class='logo-content' href='http://extentreports.relevantcodes.com'>\r\n                                        <span>ExtentReports</span>\r\n                                    </a>\r\n                                    <a href='#' data-activates='slide-out' class='button-collapse hide-on-large-only'><i class='mdi-navigation-apps'></i></a>\r\n                                </div>";


             keyValuePair["Text1ToBeReplaced"] = str;


                //Text1ToReplace                
             str = "<div class='logo-container' style='height:50px;width:200px;'>\r\n                                    <a href='http://www.cigniti.com/'>\r\n                                        <img border='0' alt='Cigniti' src='gallop_logo.png' width='200' height='35'>\r\n                                    </a>\r\n                                     <a href='#' data-activates='slide-out' class='button-collapse hide-on-large-only'><i class='mdi-navigation-apps'></i></a>\r\n                                </div>";

             keyValuePair["Text1ToReplace"] = str;


                //Text2ToBeReplaced
               str = "<span class='report-name'>";
               keyValuePair["Text2ToBeReplaced"] = str;

                //Text2ToReplace
                str = "<span class='report-name'><div style='width:220px;' align='right'>";
                keyValuePair["Text2ToReplace"] = str;

                //Text3ToBeReplaced
                str = "</span> <span class='report-headline'>";
                keyValuePair["Text3ToBeReplaced"] = str;

                //Text3ToReplace
                str = "</div></span> <span class='report-headline'>";
                keyValuePair["Text3ToReplace"] = str;
            }
            ITestReportManipulator updateExtentReport = new ExtentReportManipulator(keyValuePair);
            EngineSetup.TestReport.ManipulateTestReport(updateExtentReport);

        }
}
}

