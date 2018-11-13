using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReporter;
using System.IO;
using Engine.Factories;
namespace Engine.Setup
{
    /// <summary>
    /// @Author - Pavan Parmar
    /// </summary>
    public class EngineSetup
    {
        private static string randomString = null;
        private const string FILETESTCONFIGURATION = "TestConfiguration.properties";        
        private static string executablePath = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "executablePath");
        private static string reportType = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "reportType"); 
        private static string testReportFile = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testReportFile");
        private static IReporter testReportInternal = null;
        private static string screenShotFolder = new FileInfo(testReportFile).Directory.FullName + Path.DirectorySeparatorChar + "ScreenShots";
        private static int lastScreenShotCount = 1;
        private static string browser = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "browser");
        private static string platform = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "platform");
        private static int defaultTimeOutForSelenium = Int32.Parse(StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "seleniumDefaultTimeOut"));
        public const int TimeOutConstant = 60;

        private static string testRailUrl = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailUrl");
        private static string testRailUserID = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailUserID");
        private static string testRailPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailPassword");
        private static string testRailProject = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailProject");
        private static string testRailMileStone = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailMileStone");
        private static string testRailSuite = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailSuite");
        private static string testRailAssignedTo = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailAssignedTo");
        private static string testRailTestRunName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testRailTestRunName");

        private static string appUrl = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "appUrl");
        private static string recruiterUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "recruiterusername");
        private static string recruiterPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "recruiterpassword");
        private static string vendorManagerUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendormanagerusername");
        private static string vendorManagerPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendormanagerpassword");
        private static string vendorContactUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorcontactusername");
        private static string vendorContactPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "vendorcontactpassword");
        private static string candidateUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidateusername");
        private static string candidatePassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "candidatepassword");
        private static string contactUserName = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "contactusername");
        private static string contactPassword = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "contactpassword");
        /// <summary>
        /// Initializes the <see cref="EngineSetup"/> class.
        /// </summary>
        static EngineSetup()
        {
            if (Directory.Exists(screenShotFolder))
            {
                Directory.Delete(screenShotFolder, true);
            }
        }
        /// <summary>
        /// Gets the random value.
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {
            if(EngineSetup.randomString == null)
            {
                EngineSetup.randomString = String.Format("{0}{1}", Environment.MachineName, DateTime.Now.ToString("ddmmssff"));
            }
            return EngineSetup.randomString;
        }

        /// <summary>
        /// Gets or sets the application path.
        /// </summary>
        /// <value>
        /// The application path.
        /// </value>
        public static string ApplicationPath
        {
            get { return new FileInfo(EngineSetup.executablePath).FullName; }
            set { EngineSetup.executablePath = value; }
           
        }
        /// <summary>
        /// Gets or sets the type of the test report.
        /// </summary>
        /// <value>
        /// The type of the test report.
        /// </value>
        public static string TestReportType
        {
            get {
                return EngineSetup.reportType; }
            set { EngineSetup.reportType = value; }
        }
        /// <summary>
        /// Gets or sets the name of the test report file.
        /// </summary>
        /// <value>
        /// The name of the test report file.
        /// </value>
        public static string TestReportFileName
        {
            get { return new FileInfo(EngineSetup.testReportFile).FullName; }
            set { EngineSetup.testReportFile = value; }
        }

        /// <summary>
        /// Gets or sets the test screen shot folder.
        /// </summary>
        /// <value>
        /// The test screen shot folder.
        /// </value>
        public static string TestScreenShotFolder
        {
            get { return EngineSetup.screenShotFolder; }
            set { EngineSetup.screenShotFolder = value; }
        }
        /// <summary>
        /// Gets the test report.
        /// </summary>
        /// <value>
        /// The test report.
        /// </value>
        public static IReporter TestReport
        {
            get
            {
                if(EngineSetup.testReportInternal == null)
                {
                    EngineSetup.testReportInternal = ReportFactory.GetReport(EngineSetup.TestReportType,true, true);
                }
                return EngineSetup.testReportInternal;
            }
        }

        /// <summary>
        /// Gets the screen shot path.
        /// </summary>
        /// <returns></returns>
        public static string GetScreenShotPath()
        {
            string fileName = String.Format("{0}{1}ScreenShot.jpeg", EngineSetup.TestScreenShotFolder, Path.DirectorySeparatorChar);
            try
            {
                //Verifying if the file already exists, if so append the numbers 1,2  so on to the fine name.			

                FileInfo myPngImage = new FileInfo(fileName);
                if(!myPngImage.Directory.Exists)
                {
                    myPngImage.Directory.Create();
                }
                
                while (myPngImage.Exists)
                {
                    try
                    {
                        string tempFileName = null;
                        if (fileName.Contains("_"))
                        {
                           tempFileName = fileName.Substring(0, fileName.IndexOf('_'));
                           
                        }
                        else
                        {
                            tempFileName = fileName.Substring(0, fileName.IndexOf(".jpeg"));
                        }
                        fileName = tempFileName;
                        fileName = String.Format("{0}_{1}.jpeg", fileName, EngineSetup.lastScreenShotCount++);
                        myPngImage = new FileInfo(fileName);
                    }
                    catch(Exception ex)
                    {
                        EngineSetup.TestReport.LogException(ex, EngineSetup.GetScreenShotPath());
                    }
                    
                   
                }
                return fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return fileName;
            }
        }

        /// <summary>
        /// Gets the default timeout for selenium.
        /// </summary>
        /// <value>
        /// The default timeout for selenium.
        /// </value>
        public static int DefaultTimeoutForSelenium
        {
            get
            {
                return EngineSetup.defaultTimeOutForSelenium;
            }
        }

        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public static string BROWSER
        {
            get
            {
                //environment variable will be read in case of Jenkins parameterized build execution
                return Environment.GetEnvironmentVariable("browser") !=null ? Environment.GetEnvironmentVariable("browser") : EngineSetup.browser;
            }
            set { EngineSetup.browser = value; }
        }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public static string PLATFORM
        {
            get
            {
                return  EngineSetup.platform;
            }
            set { EngineSetup.platform = value; }
        }


        #region Test Rail Properties
        public static string TESTRAILURL
        {
            get { return EngineSetup.testRailUrl; }
            set { EngineSetup.testRailUrl = value; }
        }

        public static string TESTRAILUSERID
        {
            get { return EngineSetup.testRailUserID; }
            set { EngineSetup.testRailUserID = value; }
        }

        public static string TESTRAILPASSWORD
        {
            get { return EngineSetup.testRailPassword; }
            set { EngineSetup.testRailPassword = value; }
        }
        public static string TESTRAILPROJECT
        {
            get { return EngineSetup.testRailProject; }
            set { EngineSetup.testRailProject = value; }
        }
        public static string TESTRAILMILESTONE
        {
            get { return EngineSetup.testRailMileStone; }
            set { EngineSetup.testRailMileStone = value; }
        }
        public static string TESTRAILSUITE
        {
            get { return EngineSetup.testRailSuite; }
            set { EngineSetup.testRailSuite = value; }
        }
        public static string TESTRAILASSIGNEDTO
        {
            get { return EngineSetup.testRailAssignedTo; }
            set { EngineSetup.testRailAssignedTo = value; }
        }
        public static string TESTRAILTESTRUNNAME
        {
            get { return EngineSetup.testRailTestRunName; }
            set { EngineSetup.testRailTestRunName = value; }
        }
        #endregion

        #region Environment Properties
        public static string APPURL
        {
            get { return EngineSetup.appUrl; }
            set { EngineSetup.appUrl = value; }
        }

        public static string RecruiterUserName
        {
            get { return EngineSetup.recruiterUserName; }
            set { EngineSetup.recruiterUserName = value; }
        }
        public static string RecruiterPassword
        {
            get { return EngineSetup.recruiterPassword; }
            set { EngineSetup.recruiterPassword = value; }
        }
public static string VendorManagerUserName
        {
            get { return EngineSetup.vendorManagerUserName; }
            set { EngineSetup.vendorManagerUserName = value; }
        }
        public static string VendorManagerPassword
        {
            get { return EngineSetup.vendorManagerPassword; }
            set { EngineSetup.vendorManagerPassword = value; }
        }
        public static string VendorContactUserName
        {
            get { return EngineSetup.vendorContactUserName; }
            set { EngineSetup.vendorContactUserName = value; }
        }
        public static string VendorContactPassword
        {
            get { return EngineSetup.vendorContactPassword; }
            set { EngineSetup.vendorContactPassword = value; }
        }

        public static string CandidateUserName
        {
            get { return EngineSetup.candidateUserName; }
            set { EngineSetup.candidateUserName = value; }
        }
        public static string CandidatePassword
        {
            get { return EngineSetup.candidatePassword; }
            set { EngineSetup.candidatePassword = value; }
        }
        public static string ContactUserName
        {
            get { return EngineSetup.contactUserName; }
            set { EngineSetup.contactUserName = value; }
        }
        public static string ContactPassword
        {
            get { return EngineSetup.contactPassword; }
            set { EngineSetup.contactPassword = value; }
        }

        #endregion

    }
}