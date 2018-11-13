using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTest.FunctionalTests.Erecruit;
using System.Configuration;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;
using TestReporter;

namespace AutomatedTest.FunctionalTests.Erecruit
{
    class Utility : TestBaseTemplate
    {
        #region constants & fields
        #region Login
        private static By txtEmail = By.Id("ctl00_cphMain_logIn_UserName");
        private static By txtPassword = By.Id("ctl00_cphMain_logIn_Password");
        private static By btnLogin = By.Id("ctl00_cphMain_logIn_Login");

        #endregion
        #endregion

        /// <summary>
        /// Utility
        /// </summary>
        public Utility()
        {

        }

        public static void RecruiterLogin()
        {
            //string userName = vendorManagerUserName;
            //string password = vendorManagerUserPassword;
        }

        public static void VendorManagerLogin()
        {

        }
    }
}
