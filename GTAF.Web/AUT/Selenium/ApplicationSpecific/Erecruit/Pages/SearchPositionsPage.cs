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

namespace AUT.Selenium.ApplicationSpecific.Erecruit.Pages
{
    public class SearchPositionsPage : AbstractTemplatePage
    { 
       HomePage home = new HomePage();
      

    public static string positionID = null;
    #region Constructors
    public SearchPositionsPage()
    {
    }

    public SearchPositionsPage(IWebDriver driver)
    {
        this.driver = driver;
    }
        #endregion
  
        #region Objectrepository
        private By lblPositionId = By.XPath("//div[@id='pagetile']/h1");
        private By lnkPosition = By.XPath("//span[text()='Position']");
        private By txtPositionNameorID = By.XPath(".//li[@class='position']/span/div/div/input");
        #endregion


        public void ClickOnPositionLink()
        {
            try
            {
                driver.VerifyWebElementPresent(lnkPosition, "Position");
                driver.ClickElement(lnkPosition, "Click on Position");
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("ClickPositionPage", "Failed to Click on Position Page", EngineSetup.GetScreenShotPath());
            }
        }


        public void CheckPosition()
        {
            try
            {
                driver.IsElementPresent(lblPositionId);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("CheckPositionPage", "Failed to Display Position Page", EngineSetup.GetScreenShotPath());
            }
        }

    }
    }


