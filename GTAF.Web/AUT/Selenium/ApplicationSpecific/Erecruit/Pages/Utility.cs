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
    public class Utility : AbstractTemplatePage
    {
        #region Constants and Fields

        private static Random randomValue = null;
        #endregion

        #region -------------- UI Object Repository -------------------------------
        /// <summary>
        /// lbl company
        /// </summary>
        private By lblCompany = By.XPath("//div[@id='pagetitle']/h1");

        #endregion

        #region constructor
        /// <summary>
        /// Utility
        /// </summary>
       static  Utility()
        {
            randomValue = new Random();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates random number
        /// </summary>
        /// <returns>Generates random number</returns>
        public static int GenerateRandomNumber()
        {
            return randomValue.Next(2000);
        }

        /// <summary>
        /// Generates mobile number
        /// </summary>
        /// <returns>Generates 10 digit mobile number</returns>
        public static string GenerateMobileNumber()
        {
            return randomValue.Next(111111111, 999999999).ToString();
        }

        /// <summary>
        /// GetCompanyTitle
        /// </summary>
        /// <returns> Company title </returns>
        public string GetTitleId()
        {
            driver.sleepTime(10000);
            driver.WaitElementPresent(lblCompany);
            string contactTitle = driver.GetElementText(lblCompany);
            int startIndex = contactTitle.IndexOf("(");
            return contactTitle.Substring(startIndex + 1, contactTitle.Length - startIndex - 2);          
        }

        public string GetTitle()
        {
            driver.sleepTime(20000);
            //driver.WaitElementPresent(lblCompany);
            string contactTitle = driver.GetElementText(lblCompany);
            return contactTitle;
        }

        public bool isAlphaNumeric(string N)
        {
            bool YesNumeric = false;
            bool YesAlpha = false;
            bool BothStatus = false;

            for (int i = 0; i < N.Length; i++)
            {
                if (char.IsLetter(N[i]))
                    YesAlpha = true;

                if (char.IsNumber(N[i]))
                    YesNumeric = true;
            }

            if (YesAlpha == true && YesNumeric == true)
            {
                BothStatus = true;
            }
            else
            {
                BothStatus = false;
            }
            return BothStatus;
        }

        #endregion
    }
}
