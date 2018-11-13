﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using Keys = OpenQA.Selenium.Keys;
using TestReporter;
using Engine.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engine.UIHandlers.Selenium
{
    /// <summary>
    /// @Author - Pavan Parmar
    /// </summary>
    public static class SeleniumElementActions
    {
        private static IReporter testReport = EngineSetup.TestReport;
        #region Public Methods

        /// <summary>
        /// clicks a given element found by locator
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver ClickElement(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            if (driver is InternetExplorerDriver)
            {
                try
                {
                    if (defaultTimeout != 0)
                    {
                        driver.WaitElementExistsAndVisible(locator);
                    }
                    try
                    {
                        IWebElement webElement = null;
                        try
                        {
                            webElement = driver.FindElement(locator);
                            webElement.Click();
                            //webElement.SendKeys(Keys.Enter);
                            Thread.Sleep(2000);
                            testReport.LogSuccess("ClickElement - " + controlName, String.Format("Performed action 'CLICK' on element - ControlName: <mark>{0}</mark>", controlName));
                        }
                        catch (Exception)
                        {
                            try
                            {
                                //if previous click did not work, fall back to advanced action click
                                if (driver.IsElementPresent(locator) && webElement.Displayed == true)
                                {
                                    driver.ClickElementUsingAdvancedAction(locator, controlName, 10);

                                }
                            }
                            catch (Exception)
                            {
                                //if advanced action did not work then go for JavaScriptExecutor
                                if (driver.IsElementPresent(locator) && webElement.Displayed == true)
                                {
                                    driver.ClickElementWithJavascript(locator, controlName, 10);
                                }

                            }
                        }

                    }
                    catch (System.InvalidOperationException)
                    {
                        driver.ClickElementWithJavascript(locator, controlName);
                    }
                }
                catch (Exception ex)
                {

                    testReport.LogFailure("ClickElement- " + controlName, String.Format("Unable to perform 'CLICK' on element - controlName : <mark>{0}</mark>, with By - <mark>{1}</mark>", controlName, locator.ToString()), EngineSetup.GetScreenShotPath());
                    testReport.LogException(ex);
                }

                return driver;
            }
            else if (driver is ChromeDriver || driver is FirefoxDriver) //chrome driver
            {
                try
                {
                    return SeleniumFrameworkExtensions.CompleteAction(() =>
                    {
                        if (defaultTimeout != 0)
                        {
                            driver.WaitElementExistsAndVisible(locator);
                        }
                        try
                        {
                            driver.FindElement(locator).Click();
                            //System.Threading.Thread.Sleep(2000);
                        }
                        catch (System.InvalidOperationException ex)
                        {
                            //  testReport.LogWarning("ClickElement- " + controlName, string.Format("Trying with Javascript Click, as normal click threw exception - <mark>{0}</mark>", ex.Message), EngineSetup.GetScreenShotPath());
                            //testReport.LogWarning("ClickElement- " + controlName, string.Format("Trying with Javascript Click, as normal click threw exception - <mark>{0}</mark>", ex.Message), EngineSetup.GetScreenShotPath());
                            driver.ClickElementWithJavascript(locator, controlName);
                        }
                        return driver;

                    }, defaultTimeout, driver,
                            String.Format("Performed action 'CLICK' on element - ControlName: <mark>{0}</mark>, locator - <mark>{1}</mark>", controlName, locator), "ClickElement-" + controlName);
                }
                catch (Exception ex)
                {
                    testReport.LogException(ex);
                }
                return driver;

            }
            else //edge
            {
                try
                {
                    return SeleniumFrameworkExtensions.CompleteAction(() =>
                    {
                        if (defaultTimeout != 0)
                        {
                            driver.WaitElementExistsAndVisible(locator);
                        }
                        try
                        {
                            driver.FindElement(locator).Click();
                            System.Threading.Thread.Sleep(2000);
                        }
                        catch (System.InvalidOperationException)
                        {
                            driver.ScrollPage();
                            Thread.Sleep(1000);
                            driver.FindElement(locator).Click();
                        }
                        return driver;

                    }, 10, driver,
                        String.Format("Performed action 'CLICK' on element - ControlName: <mark>{0}</mark>", controlName), "ClickElement-" + controlName);
                }
                //exception may appear in case of edge "element is obscured"
                catch (System.InvalidOperationException)
                {

                    driver.ScrollPage();
                    Thread.Sleep(1000);
                    driver.FindElement(locator).Click();
                    System.Threading.Thread.Sleep(2000);
                    testReport.LogSuccess("ClickElement- " + controlName, String.Format("Performed action 'CLICK' on element - ControlName: <mark>{0}</mark>", controlName));
                }
                return driver;

            }

        }

        /// <summary>
        /// Clicks the element using web element.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver ClickElementUsingWebElement(this IWebDriver driver, By locator, string controlName,
        int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            if (driver is InternetExplorerDriver)
            {
                return SeleniumFrameworkExtensions.CompleteAction(() =>
                {
                    if (defaultTimeout != 0)
                    {
                        driver.WaitElementExistsAndVisible(locator);
                    }
                    IWebElement webelement = driver.FindElement(locator);
                    try
                    {
                        webelement.Click();
                    }
                    catch (WebDriverException e)
                    {
                        if (e.Message != "Timed out waiting for page to load.")
                        {
                            //webelement.SendKeys("\n");
                        }
                    }
                    return driver;

                }, defaultTimeout, driver,
                    String.Format("Performed action 'CLICK USING WEBELEMENT' on element - ControlName: <mark>{0}</mark>", controlName), "ClickElementUsingWebElement-" + controlName);
            }
            else if (driver is ChromeDriver || driver is FirefoxDriver) //chrome driver
            {

                driver.ClickElement(locator, controlName);
                return driver;
            }
            else //edge
            {
                try
                {
                    driver.ClickElement(locator, controlName, 10);
                }
                //exception may appear in case of edge "element is obscured"
                catch (System.InvalidOperationException)
                {

                    driver.ScrollPage();
                    Thread.Sleep(1000);
                    driver.ClickElement(locator, controlName, 10);
                }
                return driver;

            }

        }

        /// <summary>
        /// click on a given element using javascript
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver ClickElementWithJavascript(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
                return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(locator));
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'CLICK(Javascript)' on element: <mark>{0}</mark>, locator - <mark>{1}</mark>", controlName, locator), "ClickElementWithJavascript-" + controlName);
        }
          

        /// <summary>
        /// clicks on an element and waits for the next page to finish load. 
        /// a timeout can be designated or the default timeoujt will be assigned
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver ClickWaitNextPageLoad(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            var element = driver.FindElement(locator);
            driver.ClickElement(locator, controlName);
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                try
                {
                    element.GetAttribute("id");
                    //?element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return driver;
                }
                //make custom exception
                throw new Exception(String.Format(
                    "Next page did not load within {0} seconds after element was clicked", defaultTimeout));
            }, defaultTimeout, driver,
                String.Format("Performed action 'CLICK AND WAIT' on element - ControlName: <mark>{0}</mark>", controlName), "ClickWaitNextPageLoad-" + controlName);
        }

        /// <summary>
        /// Double-clicks the given element by locator
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver DoubleClickElement(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                SeleniumFrameworkExtensions.activeDriverActions.DoubleClick(driver.FindElement(locator)).Perform();
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'DOUBLE CLICK' on element - ControlName: <mark>{0}</mark>", controlName), "DoubleClickElement-" + controlName);
        }

        /// <summary>
        /// Double clicks an element based on IWebElement
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="controlName"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver DoubleClickElement(this IWebDriver driver, IWebElement locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                SeleniumFrameworkExtensions.activeDriverActions.DoubleClick(locator).Perform();
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'DOUBLE CLICK' on element - ControlName: <mark>{0}</mark>", controlName), "DoubleClickElement-" + controlName);
        }

        /// <summary>
        /// right-clicks the given element by locator
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver RightClickElement(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                Actions action = new Actions(driver);
                action.ContextClick(driver.FindElement(locator)).Build().Perform();
                //SeleniumFrameworkExtensions.activeDriverActions.ContextClick(driver.FindElement(locator)).Build().Perform();
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'RIGHT CLICK' on element - Locator: <mark>{0}</mark>", locator), "RightClickElement-" + controlName);
        }

        /// <summary>
        /// Sends the keys to element with javascript.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="text">The text.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver SendKeysToElementWithJavascript(this IWebDriver driver, By locator, string text, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            try
            {
                testReport.LogInfo(String.Format("SeleniumElementActions.SendKeysToElementWithJavascript, control Name - {0}, Will Try With JavaScript - arguments[0].setAttribute(arguments[1],arguments[2])", locator));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", driver.FindElement(locator), "value", text);
                testReport.LogSuccess("SendKeysToElementWithJavascript", String.Format("Executed JavaScript - arguments[0].setAttribute(arguments[1],arguments[2])"));
            }
            catch (Exception ex)
            {
                testReport.LogException(ex);
                //testReport.LogFailure("SendKeysToElementWithJavascript", String.Format("SeleniumElementExceptions.SendKeysToElementWithJavascript - Exception Caught From JavaScript Executor - {0}", ex.Message), EngineSetup.GetScreenShotPath());           
            }
            return driver;
        }

        /// <summary>
        /// Method to verify if alert is present on screen
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static bool isAlertPresent(this IWebDriver driver)
        {
                driver.sleepTime(3000);
                IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(driver);
                return (alert != null);
        }

        /// <summary>
        /// send text to a given elemment (determined by the locator). a timeout can be specified or the default timeout will be assigned.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver SendKeysToElement(this IWebDriver driver, By locator, string text, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            if (driver is InternetExplorerDriver)
            {
                try
                {
                    driver.WaitElementExistsAndVisible(locator);
                    if (driver.FindElements(locator).Count > 0)
                    {
                        driver.FindElement(locator).SendKeys(text);
                        testReport.LogSuccess("SendKeysToElement - " + controlName, String.Format("Performed action 'SEND KEYS' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Text: <mark>{2}</mark>", controlName, locator, text));
                    }

                }
                catch (Exception ex)
                {
                    testReport.LogFailure("SendKeysToElement - " + controlName, String.Format("Trying With Javascript, Could not  Perform Action 'SEND KEYS' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Text: <mark>{2}</mark>, Exception - <mark>{3}</mark>",
                   controlName, locator, text, ex.Message), EngineSetup.GetScreenShotPath());
                    driver.SendKeysToElementWithJavascript(locator, text, controlName);
                }
                return driver;
            }
            else // if not IE
            {
                return SeleniumFrameworkExtensions.CompleteAction(() =>
                {
                    driver.WaitElementExistsAndVisible(locator);
                    Thread.Sleep(100);
                    driver.FindElement(locator).SendKeys(text);
                    string elementText = driver.GetElementAttribute(locator, "value");
                    int elapsedTime = 0;
                    int timeOut = defaultTimeout / 2 * 1000;
                    int count = 1;
                    int effectiveTextLength = text.Length;
                    for (int curLoc = text.Length - 1; curLoc >= 0; curLoc--)
                    {
                        string currentCharacter = text.Substring(curLoc, 1);
                        if (currentCharacter.Equals(OpenQA.Selenium.Keys.Enter) || currentCharacter.Equals(OpenQA.Selenium.Keys.Tab))
                        {
                            effectiveTextLength--;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (driver.GetElementAttribute(locator, "type").Equals("file", StringComparison.OrdinalIgnoreCase) == false) // if its not file upload button
                    {
                        if (driver.GetElementAttribute(locator, "readonly") == null) //if textbox is not readonly
                        {
                            while (elementText.Length < effectiveTextLength && elapsedTime < timeOut)
                            {
                                testReport.LogInfo(String.Format("Attempt - {0} Not Successful. Entered Text - {1} Does Not Match With Desired Text - {2} On Control - {3}, Locator - {4}", count, elementText, text, controlName, locator));
                                count++;
                                driver.FindElement(locator).SendKeys(text);
                                Thread.Sleep(500);
                                elapsedTime = elapsedTime + 1000;
                                elementText = driver.GetElementAttribute(locator, "value");
                            }//while ends
                            if (elementText.Length < effectiveTextLength)
                            {
                                testReport.LogFailure("SendKeysToElement - " + controlName, String.Format("Entered Text - <mark>{0}</mark> Does Not Match With Desired Text - <mark>{1}</mark> On Control - <mark>{2}</mark>, Locator - <mark>{3}</mark>", elementText, text, controlName, locator), EngineSetup.GetScreenShotPath());
                            }
                        }

                    }
                    return driver;
                }, defaultTimeout, driver,
                     String.Format("Performed action 'SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>", controlName, locator, text), "SendKeysToElement-" + controlName);
            }
        }

        /// <summary>
        /// SendKeys
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>

        public static IWebDriver SendKeysToLocator(this IWebDriver driver, By locator, string text, string controlName)
        {
            try
            {
                Thread.Sleep(100);
                driver.FindElement(locator).SendKeys(text);
                testReport.LogSuccess("SendKeysToElement - " + controlName, String.Format("Performed send keys - <mark>{0}</mark> On Control - <mark>{1}</mark>, Locator - <mark>{2}</mark>", text, controlName, locator.ToString()));
                return driver;
            }
            catch (Exception ex)
            {
                testReport.LogFailure("SendKeysToElement - " + controlName, String.Format("Failed to performed send keys - <mark>{0}</mark> On Control - <mark>{1}</mark>, Locator - <mark>{2}</mark>", text, controlName, locator.ToString()),EngineSetup.GetScreenShotPath());
                return driver;
            }
        }

        /// <summary>
        /// Sends the keys to element one at a time.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="text">The text.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver SendKeysToElementOneAtATime(this IWebDriver driver, By locator, string text,
            string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                Thread.Sleep(100);
                for (int i = 0; i < text.Length; i++)
                {
                    driver.FindElement(locator).SendKeys(text[i].ToString());
                    Thread.Sleep(100);
                }
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>", controlName, locator, text), "SendKeysToElementOneAtATime-" + controlName);
        }

        public static IWebDriver SendKeysToElementClearFirst(this IWebDriver driver, By locator, string text,
            string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {

            if (driver is InternetExplorerDriver)
            {
                try
                {
                    driver.WaitElementExistsAndVisible(locator);
                    if (driver.FindElements(locator).Count > 0)
                    {
                        if (driver.FindElement(locator).GetAttribute("value") != "")
                        {
                            driver.FindElement(locator).Clear();
                        }
                        driver.FindElement(locator).SendKeys(text);
                        testReport.LogSuccess("SendKeysToElementClearFirst - " + controlName, String.Format("Performed action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>",
                    controlName, locator, text));
                    }

                }
                catch (Exception ex)
                {
                    testReport.LogWarning("SendKeysToElementClearFirst - " + controlName, String.Format("Trying Javascript, Could not  Perform Action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>, Exception - <mark>{3}</mark>",
                   controlName, locator, text, ex.Message));
                    testReport.LogWarning("SendKeysToElementClearFirst - " + controlName, String.Format("Detailed Exception - <mark>{0}</mark>", ex.Message));
                    driver.SendKeysToElementWithJavascript(locator, text, controlName);
                }
                return driver;
            }
            else // if not IE
            {
                return SeleniumFrameworkExtensions.CompleteAction(() =>
                {
                    driver.WaitElementExistsAndVisible(locator);
                    System.Threading.Thread.Sleep(100);

                    if (driver.FindElement(locator).GetAttribute("value") != "")
                    {
                        driver.FindElement(locator).Clear();
                    }
                    driver.FindElement(locator).SendKeys(text);

                    string elementText = driver.GetElementAttribute(locator, "value");
                    int elapsedTime = 0;
                    int timeOut = defaultTimeout / 2 * 1000;
                    int count = 0;
                    int effectiveTextLength = text.Length;

                    for (int curLoc = text.Length - 1; curLoc >= 0; curLoc--)
                    {
                        string currentCharacter = text.Substring(curLoc, 1);
                        if (currentCharacter.Equals(OpenQA.Selenium.Keys.Enter) || currentCharacter.Equals(OpenQA.Selenium.Keys.Tab))
                        {
                            effectiveTextLength--;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (driver.GetElementAttribute(locator, "type").Equals("file", StringComparison.OrdinalIgnoreCase) == false)// if its not file upload button
                    {
                        if (driver.GetElementAttribute(locator, "readonly") == null) //if textbox is not readonly
                        {
                            while (elementText.Length < effectiveTextLength && elapsedTime < timeOut)
                            {
                                testReport.LogInfo(String.Format("Attempt - {0} Not Successful. Entered Text - {1} Does Not Match With Desired Text - {2} On ContorlName - {3}, Locator - {4}", count, elementText, text, controlName, locator));
                                count++;
                                if (driver.FindElement(locator).GetAttribute("value") != "")
                                {
                                    driver.FindElement(locator).Clear();
                                }
                                driver.FindElement(locator).SendKeys(text);
                                Thread.Sleep(500);
                                elapsedTime = elapsedTime + 1000;
                                elementText = driver.GetElementAttribute(locator, "value");
                            }//while ends
                            if (elementText.Length < effectiveTextLength)
                            {
                                testReport.LogFailure("SendKeysToElementClearFirst - " + controlName, String.Format("Entered Text - <mark>{0}</mark> Does Not Match With Desired Text - <mark>{1}</mark> On On ContorlName - <mark>{2}</mark>,Locator - <mark>{3}</mark>", elementText, text, controlName, locator), EngineSetup.GetScreenShotPath());

                            }

                        }

                    }
                    return driver;
                }, defaultTimeout, driver,
                    String.Format("Performed action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Text: <mark>{2}</mark>",
                        controlName, locator, text), "SendKeysToElementClearFirst-" + controlName);
            }
        }


        public static IWebDriver SendKeysToElementAndPressEnter(this IWebDriver driver, By locator, string text,
           string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {

            if (driver is InternetExplorerDriver)
            {
                try
                {
                    driver.WaitElementExistsAndVisible(locator);
                    if (driver.FindElements(locator).Count > 0)
                    {
                        if (driver.FindElement(locator).GetAttribute("value") != "")
                        {
                            driver.FindElement(locator).Clear();
                        }
                        driver.FindElement(locator).SendKeys(text);
                        Thread.Sleep(2000);
                        driver.FindElement(locator).SendKeys(Keys.Enter);
                        testReport.LogSuccess("SendKeysToElementAndPressEnter - " + controlName, String.Format("Performed action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>",
                    controlName, locator, text));
                    }

                }
                catch (Exception ex)
                {
                    testReport.LogWarning("SendKeysToElementAndPressEnter - " + controlName, String.Format("Trying Javascript, Could not  Perform Action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>, Exception - <mark>{3}</mark>",
                   controlName, locator, text, ex.Message));
                    testReport.LogWarning("SendKeysToElementAndPressEnter - " + controlName, String.Format("Detailed Exception - <mark>{0}</mark>", ex.Message));
                    driver.SendKeysToElementWithJavascript(locator, text, controlName);
                }
                return driver;
            }
            else // if not IE
            {
                return SeleniumFrameworkExtensions.CompleteAction(() =>
                {
                    System.Threading.Thread.Sleep(100);
                    driver.WaitElementExistsAndVisible(locator);
                    System.Threading.Thread.Sleep(100);

                    if (driver.FindElement(locator).GetAttribute("value") != "")
                    {
                        driver.FindElement(locator).Clear();
                    }
                    driver.FindElement(locator).SendKeys(text);
                    Thread.Sleep(2000);
                 
                    driver.FindElement(locator).SendKeys(Keys.Enter);
                    //Thread.Sleep(1000);
                 
                    return driver;
                }, defaultTimeout, driver,
                    String.Format("Performed action 'Clear, then SEND KEYS' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Text: <mark>{2}</mark>",
                        controlName, locator, text), "SendKeysToElementAndPressEnter-" + controlName);
            }
        }

        public static IWebDriver SendKeysUsingActions(this IWebDriver driver, By locator, string text,
           string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {

            try
            {
                Thread.Sleep(2000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(driver.FindElement(locator));
                actions.Click();
                actions.SendKeys(text);
                actions.Build().Perform();
                testReport.LogSuccess("SendKeysUsingActions - " + controlName, String.Format("Performed action 'SEND KEYS' on element - ControlName: <mark>{0}</mark>, Loctor : <mark>{1}</mark>, Text: <mark>{2}</mark>",
                    controlName, locator, text));
            }
            catch (Exception ex)
            {
                // driver.SendKeysUsingActions(locator, text, controlName);
                testReport.LogException(ex);
            }
            return driver;


        }


        /// <summary>
        /// Moves to element.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver MoveToElement(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));

                Actions action = new Actions(driver);
                action.MoveToElement(element).Build();
                action.MoveToElement(element).Perform();
                return driver;
            }, defaultTimeout, driver, String.Format("Performed action 'MOVE TO' on element - <mark>{0}</mark>, loctor - <mark>{1}</mark>", controlName, locator), "MoveToElement-" + controlName);
        }

        /// <summary>
        /// drags one control "dragLocator" to another control "dragToLocator"
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elementStart"></param>
        /// <param name="elementEnd"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver Drag(this IWebDriver driver, By elementStart, By elementEnd,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(elementStart);
                driver.WaitElementExistsAndVisible(elementEnd);
                SeleniumFrameworkExtensions.activeDriverActions.DragAndDrop(driver.FindElement(elementStart),
                    driver.FindElement(elementEnd)).Perform();
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'DRAG' on element - <mark>{0}</mark>, to element - <mark>{1}</mark>", elementStart, elementEnd), "Drag Element");
        }

        /// <summary>
        /// select an item in the given droipdown by the index
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="index"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver SelectDropdownItemByIndex(this IWebDriver driver, By locator, int index,
            string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                new SelectElement(driver.FindElement(locator)).SelectByIndex(index);
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'SELECT BY INDEX' on element - ContorlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Index: <mark>{2}</mark>", controlName, locator, index), "SelectDropdownItemByIndex-" + controlName);
        }

        /// <summary>
        /// select an item by the given text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver SelectDropdownItemByText(this IWebDriver driver, By locator, string text,
            string controlName, UIControlStyle.DropDownStyle style = UIControlStyle.DropDownStyle.NativeDropDown, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                int timeOut = defaultTimeout / 2 * 1000;
                int elapsedTime = 0;
                if (style == UIControlStyle.DropDownStyle.NativeDropDown) // if native drop down
                {
                    SelectElement selectElement = new SelectElement(driver.FindElement(locator));
                    if ((driver is EdgeDriver) == false) // not edge
                    {
                        selectElement.SelectByText(text);
                        string selectedText = selectElement.SelectedOption.Text;
                        if (selectedText.Contains(text) == false)
                        {
                            throw new Exception(String.Format("Failed To Select Item <mark>{0}</mark> in DropDown - Name - <mark>{1}</mark>, Loctor - <mark>{2}</mark>", text, controlName, locator.ToString()));
                        }
                        else
                        {
                            testReport.LogSuccess("SelectDropdownItemByText - " + controlName, string.Format("Intended option to be selected was - <mark>{0}</mark>, Option finally got selected was - <mark>{1}</mark>", text, selectedText));
                        }
                    }
                    else //edge
                    {
                        IWebElement webElement = driver.FindElement(locator);
                        /*Work around as US Dollar Selects Singapore Dollar. Typing S next to U selects Singapore*/
                        if (text.Contains("US Dollar"))
                        {
                            text = "U";
                        }
                        webElement.Click();
                        webElement.SendKeys(text);
                        webElement.SendKeys(Keys.Enter);
                        Thread.Sleep(1000);

                    }
                }
                else if (style == UIControlStyle.DropDownStyle.KendoDropDown)//drop down is not native, then some work around
                {
                    IWebElement webElement = driver.FindElement(locator);
                    webElement.Click();
                    Thread.Sleep(1000);
                    int count = 1;
                    SeleniumElementUtilities.SimulateSendKeys(driver, text);
                    SeleniumElementUtilities.SimulateSendKeys(driver, "{ENTER}");
                    Thread.Sleep(1000);
                    string dropDownText = webElement.Text;
                    Actions builder = new Actions(driver);
                    if (dropDownText.Contains(text) == false)
                    {
                        testReport.LogInfo(String.Format("Attempt - {0} Not Successful.Selected Text - {1} Instead of desired text - {2} On Kendo DropDown Control Name - {3}, Loctor - {4}, Trying One More Time", count, dropDownText, text, controlName, locator.ToString()));
                        try
                        {
                            count++;
                            builder.Click(webElement).SendKeys(text).Build().Perform();
                            Thread.Sleep(500);
                        }
                        catch (Exception ex)
                        {
                            testReport.LogFailure("SelectDropdownItemByText - " + controlName, String.Format("Attempt - <mark>{0}</mark>,  Unable To Select Text - <mark>{1}</mark> On Kendo DropDown Control - Name - <mark>{2}</mark>, locator - <mark>{3}</mark>, Exception - <mark>{4}</mark>", count, text, controlName, locator.ToString(), ex.Message));
                        }
                    }
                    //if required item not selected, then fall back to different approach                    
                    elapsedTime = 0;

                    dropDownText = webElement.Text;
                    while ((dropDownText.Contains(text) == false) && elapsedTime < timeOut)
                    {
                        testReport.LogInfo(String.Format("Attempt - {0} Not Successful.Selected Text - {1} Instead of desired text - {2} On Kendo DropDown Control Name - {3}, Loctor - {4}, Trying One More Time", count, dropDownText, text, controlName, locator.ToString()));

                        By byListItem = By.XPath(String.Format("//li[@role='option' and text()='{0}']", text));
                        try
                        {
                            count++;
                            IWebElement weListItem = driver.FindElement(byListItem);
                            builder.Click(webElement).Click(weListItem).Build().Perform();
                        }
                        catch (Exception ex)
                        {
                            testReport.LogFailure("SelectDropdownItemByText - " + controlName, String.Format("Attempt - <mark>{0}</mark>,  Unable To Select Text - <mark>{1}</mark> On Kendo DropDown Control - Name - <mark>{2}</mark>, locator - <mark>{3}</mark>, Exception - <mark>{4}</mark>", count, text, controlName, locator.ToString(), ex.Message));
                        }
                        Thread.Sleep(500);
                        elapsedTime = elapsedTime + 1000;
                        dropDownText = webElement.Text;

                    }//while ends

                    //throw error if text could not be set
                    dropDownText = webElement.Text;
                    if (dropDownText.Contains(text) == false)
                    {
                        throw new Exception(String.Format("Failed To Select Item <mark>{0}</mark> in Kendo DropDown - Name : <mark>{1}</mark>, Loctor : <mark>{2}</mark>", text, controlName, locator.ToString()));
                    }
                    else
                    {
                        testReport.LogSuccess("SelectDropdownItemByText - " + controlName, string.Format("Intended option to be selected from Kendo Dropdown was - <mark>{0}</mark>, Option finally got selected was - <mark>{1}</mark>", text, webElement.Text));
                    }


                }
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'SELECT BY TEXT' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Text: <mark>{2}</mark>", controlName,
                    locator, text), "SelectDropdownItemByText-" + controlName);
        }

        /// <summary>
        /// select a dropdown item by the given value
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver SelectDropdownItemByValue(this IWebDriver driver, By locator, string value,
            string controlName, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                new SelectElement(driver.FindElement(locator)).SelectByValue(value);
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'SELECT BY VALUE' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>, Value: <mark>{2}</mark>",
                    controlName, locator, value), "SelectDropdownItemByValue-" + controlName);
        }

        /// <summary>
        /// click the submit button for a given element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="defaultTimeout"></param>
        /// <returns></returns>
        public static IWebDriver SubmitElement(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            return SeleniumFrameworkExtensions.CompleteAction(() =>
            {
                driver.WaitElementExistsAndVisible(locator);
                driver.FindElement(locator).Submit();
                return driver;
            }, defaultTimeout, driver,
                String.Format("Performed action 'SUBMIT' on element - ControlName: <mark>{0}</mark>, Locator: <mark>{1}</mark>", controlName, locator), "SubmitElement-" + controlName);
        }

        //added by debasish : ClickElementUsingAdvancedAction
        /// <summary>
        /// Clicks the element using advanced action.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver ClickElementUsingAdvancedAction(this IWebDriver driver, By locator, string controlName,
            int defaultTimeout = EngineSetup.TimeOutConstant)
        {

            try
            {
                if (defaultTimeout != 0)
                {
                    driver.WaitElementExistsAndVisible(locator);
                }
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                Actions action = new Actions(driver);
                action.MoveToElement(element).Click().Build().Perform();
                testReport.LogSuccess("ClickElementUsingAdvancedAction - " + controlName, String.Format("Performed AdvancedAction 'CLICK' on element - ControlName: <mark>{0}</mark>, locator - <mark>{1}</mark>", controlName, locator));
            }
            catch (WebDriverException e)
            {
                if (e.Message != "Timed out waiting for page to load.")
                {
                    testReport.LogFailure("ClickElementUsingAdvancedAction - " + controlName, String.Format("Could Not Perform AdvancedAction 'CLICK' on element - ControlName: <mark>{0}</mark>, locator - <mark>{1}</mark>, Exception Msg - <mark>{2}</mark>", controlName, locator, e.Message), EngineSetup.GetScreenShotPath());
                }
            }
            return driver;
        }
        /// <summary>
        /// Sets the value in integer input box.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locatorForClick">The locator for click.</param>
        /// <param name="locatorForValueCheck">The locator for value check.</param>
        /// <param name="text">The text.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver SetValueInIntegerInputBox(this IWebDriver driver, By locatorForClick, By locatorForValueCheck, string text, int defaultTimeout = EngineSetup.TimeOutConstant)
        {

            try
            {
                driver.ClickElementUsingWebElement(locatorForClick, locatorForClick.ToString());
                SeleniumElementUtilities.SimulateSendKeys(driver, text);
                int timeOut = defaultTimeout / 2 * 1000;
                int elapsedTime = 0;
                int count = 1;

                string strtext = driver.GetElementAttribute(locatorForValueCheck, "value");


                while ((driver.GetElementAttribute(locatorForValueCheck, "value").Contains(text) == false) && elapsedTime < timeOut)
                {
                    testReport.LogInfo(String.Format("Attempt - {1}, Text - {0} was not found to be set using Windows Native SendKeys , trying Windows Native SendKeys again", text, count));
                    try
                    {
                        driver.ClickElementUsingWebElement(locatorForClick, locatorForClick.ToString());
                        SeleniumElementUtilities.SimulateSendKeys(driver, text);
                        if (driver.GetElementAttribute(locatorForValueCheck, "value").Contains(text) == false)
                        {
                            testReport.LogInfo(String.Format("Attempt - {1}, Text - {0} was not found to be set using Windows Native SendKeys , trying SendKeysToElement set", text, count));
                            driver.SendKeysToElementClearFirst(locatorForClick, text, locatorForClick.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        testReport.LogFailure("SetValueInIntegerInputBox", String.Format("Exception Encoutered - <mark>{0}</mark>)", ex.Message));
                    }

                    Thread.Sleep(500);
                    elapsedTime = elapsedTime + 1000;
                    count++;
                }//while ends
                if (driver.GetElementAttribute(locatorForValueCheck, "value").Contains(text) == false)
                {
                    testReport.LogFailure("SetValueInIntegerInputBox", String.Format("text - <mark>{0}</mark> could not be set in - <mark>{1}</mark>", text, locatorForValueCheck.ToString()), EngineSetup.GetScreenShotPath());
                }
                else
                {
                    testReport.LogSuccess("SetValueInIntegerInputBox", String.Format("text - <mark>{0}</mark> was set in - <mark>{1}</mark>", text, locatorForValueCheck.ToString()));
                }
            }
            catch (Exception ex)
            {
                testReport.LogFailure("SetValueInIntegerInputBox", String.Format("text - <mark>{0}</mark> could not be set in - <mark>{1}</mark>", text, locatorForValueCheck.ToString()), EngineSetup.GetScreenShotPath());
                testReport.LogException(ex);
            }
            return driver;
        }
        /// <summary>
        /// Sets the value in date input box.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="locator">The locator.</param>
        /// <param name="dateText">The date text.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <param name="isEnterKeyPressedAtEnd">if set to <c>true</c> [is enter key pressed at end].</param>
        /// <returns></returns>
        public static IWebDriver SetValueInDateInputBox(this IWebDriver driver, By locator, string dateText, int defaultTimeout = EngineSetup.TimeOutConstant, bool isEnterKeyPressedAtEnd = true)
        {

            try
            {
                if (isEnterKeyPressedAtEnd == true) // Enter Key To Be Pressed After Setting Date In TextBox
                {
                    driver.SendKeysToElementClearFirst(locator, dateText + OpenQA.Selenium.Keys.Enter, locator.ToString());
                }
                else // Enter Key Not To Be Pressed After Setting Date In TextBox
                {
                    driver.SendKeysToElementClearFirst(locator, dateText, locator.ToString());
                }
                //if text is not set

                int timeOut = defaultTimeout / 2 * 1000;
                int elapsedTime = 0;
                string strtext = "";
                int count = 1;
                strtext = driver.GetElementAttribute(locator, "value");

                while (strtext.Substring(0, dateText.Length).Equals(dateText) == false && elapsedTime < timeOut)
                {
                    testReport.LogInfo(String.Format("Attempt - {2}, Expected Text - {0} was not found , Actual Text - {1} was found, trying one more time", dateText, strtext, count));

                    driver.SendKeysToElementClearFirst(locator, dateText + OpenQA.Selenium.Keys.Enter, locator.ToString());
                    strtext = driver.GetElementAttribute(locator, "value");


                    Thread.Sleep(500);
                    elapsedTime = elapsedTime + 1000;
                    count++;
                }//while ends

                if (strtext.Substring(0, dateText.Length).Equals(dateText) == false)
                {
                    testReport.LogFailure("SetValueInDateInputBox", String.Format("text - <mark>{0}</mark> could not be set in - <mark>{1}</mark>, Actual Text - <mark>{2}</mark> was found", dateText, locator.ToString(), strtext), EngineSetup.GetScreenShotPath());
                }
                else
                {
                    testReport.LogSuccess("SetValueInDateInputBox", String.Format("text - <mark>{0}</mark> was set in - <mark>{1}</mark>", dateText, locator.ToString()));
                }
            }
            catch (Exception ex)
            {
                testReport.LogFailure("SetValueInDateInputBox", String.Format("text - <mark>{0}</mark> could not be set in - <mark>{1}</mark>", dateText, locator.ToString()), EngineSetup.GetScreenShotPath());
                testReport.LogException(ex);
            }
            return driver;
        }
        /// <summary>
        /// Sets the value in spread sheet for quotation.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="text">The text.</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver SetValueInSpreadSheetForQuotation(this IWebDriver driver, string tableName, string columnName, string text, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            string strText = null;
            try
            {
                int numericText;
                try
                {
                    if (int.TryParse(text, System.Globalization.NumberStyles.AllowThousands, null, out numericText))
                    {
                        testReport.LogInfo(String.Format("Given Text - {0} Will Be Formatted To Thousand Separator", text));
                        numericText = Int32.Parse(text, System.Globalization.NumberStyles.AllowThousands);
                        text = numericText.ToString("#,##0.#");
                        testReport.LogInfo(String.Format("Given Text Was Formatted To Thousand Separator, After Conversion Text Becomes - {0}", text));
                    }
                }
                catch (Exception ex)
                {
                    testReport.LogFailure("SetValueInSpreadSheetForQuotation", String.Format("Exception Encountered While Converting Text - <mark>{0}</mark> To Thousand Separator, Exception - <mark>{1}</mark>", text, ex.Message));
                }
                int localWaitTimeBeforeSendKeys = 500;
                int localWaitTimeAfterSendKeys = 500;
                By byCurrentCell = By.XPath("//td[contains(@class,'current')]");

                strText = driver.GetElementText(byCurrentCell);
                int timeOut = defaultTimeout / 2 * 1000;
                int elapsedTime = 0;
                int count = 1;
                while ((strText.Contains(text) == false) && elapsedTime < timeOut)
                {
                    try
                    {

                        Thread.Sleep(localWaitTimeAfterSendKeys);
                        SeleniumElementUtilities.SimulateSendKeys(driver, "{ENTER}");
                        Thread.Sleep(localWaitTimeBeforeSendKeys);
                        SeleniumElementUtilities.SimulateSendKeys(driver, text);
                        Thread.Sleep(localWaitTimeAfterSendKeys);
                        SeleniumElementUtilities.SimulateSendKeys(driver, "{ENTER}");
                        strText = driver.GetElementText(byCurrentCell);

                        if (strText.Contains(text) == true)
                        {
                            testReport.LogInfo(String.Format("Attempt - {3}, Table - {0}, Column - {1} Was Set, With Value - {2}", tableName, columnName, text, count));
                        }
                        else
                        {
                            testReport.LogInfo(String.Format("Attempt - {4}, Table - {0}, Column - {1} Could Not Be Set, With Value - {2}, Current Value - {3}, Trying One More Time", tableName, columnName, text, strText, count));
                        }
                        Thread.Sleep(500);
                        elapsedTime = elapsedTime + 1000;
                    }
                    catch (Exception ex)
                    {
                        testReport.LogFailure("SetValueInSpreadSheetForQuotation", String.Format("Table - <mark>{0}</mark>, Column - <mark>{1}</mark> Could Not Be Set, With Value -<mark>{2}</mark>", tableName, columnName, text), EngineSetup.GetScreenShotPath());
                    }
                    count++;
                }//while ends
                strText = driver.GetElementText(byCurrentCell);
                if (strText.Contains(text) == true)
                {
                    testReport.LogSuccess("SetValueInSpreadSheetForQuotation", String.Format("Table - <mark>{0}</mark>, Column - <mark>{1}</mark> Was Set, With Value - <mark>{2}</mark>", tableName, columnName, text));
                }
                else
                {
                    testReport.LogFailure("SetValueInSpreadSheetForQuotation", String.Format("Table - <mark>{0}</mark>, Column - <mark>{1}</mark> Could Not Be Set, With Value - <mark>{2}</mark>, Current Value - <mark>{3}</mark>, Trying One More Time", tableName, columnName, text, strText), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }
            return driver;
        }

        /// <summary>
        /// Sets the value in spread sheet with multiple rows for quotation.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="text">The text.</param>
        /// <param name="isLastColumn">if set to <c>true</c> [is last column].</param>
        /// <param name="defaultTimeout">The default timeout.</param>
        /// <returns></returns>
        public static IWebDriver SetValueInSpreadSheetWithMultipleRowsForQuotation(this IWebDriver driver, string tableName, string columnName, string text, bool isLastColumn = false, int defaultTimeout = EngineSetup.TimeOutConstant)
        {
            string strText = null;
            try
            {
                int numericText;
                try
                {
                    if (int.TryParse(text, System.Globalization.NumberStyles.AllowThousands, null, out numericText))
                    {
                        testReport.LogInfo(String.Format("Given Text - {0} Will Be Formatted To Thousand Separator", text));
                        numericText = Int32.Parse(text, System.Globalization.NumberStyles.AllowThousands);
                        text = numericText.ToString("#,##0.#");
                        testReport.LogSuccess("SetValueInSpreadSheetWithMultipleRowsForQuotation", String.Format("Given Text Was Formatted To Thousand Separator, After Conversion Text Becomes - <mark>{0}</mark>", text));
                    }
                }
                catch (Exception ex)
                {
                    testReport.LogWarning("SetValueInSpreadSheetWithMultipleRowsForQuotation", String.Format("Exception Encountered While Converting Text - <mark>{0}</mark> To Thousand Separator, Exception - <mark>{1}</mark>", text, ex.Message));
                }
                int localWaitTimeBeforeSendKeys = 500;
                int localWaitTimeAfterSendKeys = 500;
                By byCurrentCell = By.XPath("//td[contains(@class,'current')]");
                // type text
                Thread.Sleep(localWaitTimeAfterSendKeys);
                SeleniumElementUtilities.SimulateSendKeys(driver, "{ENTER}");
                Thread.Sleep(localWaitTimeBeforeSendKeys);
                SeleniumElementUtilities.SimulateSendKeys(driver, text);
                Thread.Sleep(localWaitTimeAfterSendKeys);
                //Type Text Ends
                //Press TAB or Shift Tab based on column position in table
                //By byTableColumn = null;
                if (isLastColumn == false) //not last column
                {
                    SeleniumElementUtilities.SimulateSendKeys(driver, "{TAB}");
                    Thread.Sleep(localWaitTimeAfterSendKeys);
                    //byTableColumn = By.XPath("//td[contains(@class,'current')]/preceding-sibling::td[1]");
                    SeleniumElementUtilities.SimulateSendKeys(driver, "+{TAB}");

                }
                else //last column
                {
                    SeleniumElementUtilities.SimulateSendKeys(driver, "+{TAB}");
                    Thread.Sleep(localWaitTimeAfterSendKeys);
                    SeleniumElementUtilities.SimulateSendKeys(driver, "{TAB}");

                }
                //
                Thread.Sleep(localWaitTimeAfterSendKeys);

                strText = driver.GetElementText(byCurrentCell);
                int timeOut = defaultTimeout / 2 * 1000;
                int elapsedTime = 0;
                int count = 1;
                strText = driver.GetElementText(byCurrentCell);

                if (strText.Contains(text) == true)
                {
                    testReport.LogInfo(String.Format("Attempt - {3}, Table - {0}, Column - {1} Was Set, With Value - {2}", tableName, columnName, text, count));
                }
                else
                {
                    testReport.LogInfo(String.Format("Attempt - {4}, Table - {0}, Column - {1} Could Not Be Set, With Value - {2}, Current Value - {3}, Trying One More Time", tableName, columnName, text, strText, count));
                }

                while ((strText.Contains(text) == false) && elapsedTime < timeOut)
                {
                    count++;
                    try
                    {

                        // type text
                        Thread.Sleep(localWaitTimeAfterSendKeys);
                        SeleniumElementUtilities.SimulateSendKeys(driver, "{ENTER}");
                        Thread.Sleep(localWaitTimeBeforeSendKeys);
                        SeleniumElementUtilities.SimulateSendKeys(driver, text);
                        Thread.Sleep(localWaitTimeAfterSendKeys);
                        //Type Text Ends
                        //Press TAB or Shift Tab based on column position in table

                        if (isLastColumn == false)
                        {
                            SeleniumElementUtilities.SimulateSendKeys(driver, "{TAB}");
                            Thread.Sleep(localWaitTimeAfterSendKeys);
                            SeleniumElementUtilities.SimulateSendKeys(driver, "+{TAB}");

                        }
                        else //last column
                        {
                            SeleniumElementUtilities.SimulateSendKeys(driver, "+{TAB}");
                            Thread.Sleep(localWaitTimeAfterSendKeys);
                            //byTableColumn = By.XPath("//td[contains(@class,'current')]/following-sibling::td[1]");
                            SeleniumElementUtilities.SimulateSendKeys(driver, "{TAB}");

                        }
                        //
                        Thread.Sleep(localWaitTimeAfterSendKeys);

                        strText = driver.GetElementText(byCurrentCell);

                        if (strText.Contains(text) == true)
                        {
                            testReport.LogInfo(String.Format("Attempt - {3}, Table - {0}, Column - {1} Was Set, With Value - {2}", tableName, columnName, text, count));
                        }
                        else
                        {
                            testReport.LogInfo(String.Format("Attempt - {4}, Table - {0}, Column - {1} Could Not Be Set, With Value - {2}, Current Value - {3}, Trying One More Time", tableName, columnName, text, strText, count));
                        }
                        Thread.Sleep(500);
                        elapsedTime = elapsedTime + 1000;
                    }
                    catch (Exception ex)
                    {
                        testReport.LogException(ex, EngineSetup.GetScreenShotPath());
                    }

                }//while ends
                strText = driver.GetElementText(byCurrentCell);
                if (strText.Contains(text) == true)
                {
                    testReport.LogInfo(String.Format("Table - {0}, Column - {1} Was Set, With Value - {2}", tableName, columnName, text));
                }
                else
                {
                    testReport.LogFailure("SetValueInSpreadSheetWithMultipleRowsForQuotation", String.Format("Table - {0}, Column - {1} Could Not Be Set, With Value - {2}, Current Value - {3}, Trying One More Time", tableName, columnName, text, strText), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception ex)
            {
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }
            return driver;
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <returns></returns>
        public static IWebDriver RefreshPage(this IWebDriver driver)
        {
            string preRefreshUrl = driver.Url;
            driver.Navigate().Refresh();
            string postRefreshUrl = driver.Url;
            testReport.LogSuccess("RefreshPage", String.Format("Page Was Refreshed - PreRefresh Url - <mark>{0}</mark>, PostRefresh Url - <mark>{1}</mark>", preRefreshUrl, postRefreshUrl));
            return driver;
        }

        public static void SwitchToDefaultFrame(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                testReport.LogSuccess("SwitchToDefaultFrame", String.Format("Switch to default frame was successful"));

            }
            catch (Exception ex)
            {

                testReport.LogFailure("SwitchToDefaultFrame", String.Format("Failed to Switch to Default Frame"));
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }

        }

        public static void SwitchToFrameById(this IWebDriver driver, string idValue)
        {
            try
            {
                driver.SwitchTo().Frame(idValue);
                testReport.LogSuccess("SwitchToFrameById", String.Format("Switch to Frame by id: <mark>{0}</mark> was successful", idValue));

            }
            catch (Exception ex)
            {

                testReport.LogFailure("SwitchToFrameById", String.Format("Failed to Switch to Frame by Id: <mark>{0}</mark>", idValue));
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }
        }

        public static void SwitchToFrameByIndex(this IWebDriver driver, int index)
        {
            try
            {
                driver.SwitchTo().Frame(index);
                testReport.LogSuccess("SwitchToFrameByIndex", String.Format("Switch to Frame by Index: <mark>{0}</mark> was successful", index.ToString()));

            }
            catch (Exception ex)
            {

                testReport.LogFailure("SwitchToFrameByIndex", String.Format("Failed to Switch to Frame by Index: <mark>{0}</mark>", index.ToString()));
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }

        }

        public static void SwitchToFrameByLocator(this IWebDriver driver, By locator)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(locator));
                testReport.LogSuccess("SwitchToFrameByLocator", String.Format("Switch to Frame by Locator: <mark>{0}</mark> was successful", locator.ToString()));

            }
            catch (Exception ex)
            {

                testReport.LogFailure("SwitchToFrameByLocator", String.Format("Failed to Switch to Frame by Locator: <mark>{0}</mark>", locator.ToString()));
                testReport.LogException(ex, EngineSetup.GetScreenShotPath());
            }
        }

        public static bool MouseHoverByJavaScript(this IWebDriver driver, By locator, string locatorName)
        {
            bool flag = false;
            try
            {
                IWebElement mo = driver.FindElement(locator);
                string javaScript = "var evObj = document.createEvent('MouseEvents');" + "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" + "arguments[0].dispatchEvent(evObj);";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(javaScript, mo);
                flag = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool MouseHover(this IWebDriver driver, By locator, string locatorName)
        {
            bool flag = false;
            try
            {
                IWebElement mo = driver.FindElement(locator);
                Actions action = new Actions(driver);
                action.MoveToElement(mo).Build().Perform();
                flag = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static void sleepTime(this IWebDriver driver, int milliSecondsTimeOut)
        {
            if (driver is InternetExplorerDriver)
            {
                Thread.Sleep(milliSecondsTimeOut / 2);
            }
            else if (driver is ChromeDriver || driver is FirefoxDriver)
            {
                Thread.Sleep((milliSecondsTimeOut / 2));
            }
        }

        /// <summary>
        /// Accept Alert
        /// </summary>
        /// <param name="driver"></param>
        public static void AcceptAlert(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                testReport.LogFailure("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected:  are not matching"), EngineSetup.GetScreenShotPath());
        }
           // catch { Console.WriteLine("[Info]: Alert Not  Presented"); }            
        }

        public static void SelectDropdownValue(this IWebDriver driver, string xpath, string dropdownValue)
        {
            List<IWebElement> dropdownElements = driver.FindElements(By.XPath(xpath)).ToList();
          
            foreach (IWebElement options in dropdownElements)
            {
                string dropdownTextValue = options.Text.Trim(); ;
                if (dropdownTextValue.Equals(dropdownValue, StringComparison.CurrentCultureIgnoreCase))
                {
                    options.Click();
                    break;
                }
            }
            
        }

        public static void AssertTextEqual(this IWebDriver driver, By locator, string text)
        {
            String actual = "";
            try
            {
                if (driver.IsElementPresent(locator))
                {
                    actual = driver.FindElement(locator).Text.Trim();
                    Assert.AreEqual(actual, text.Trim());
                    testReport.LogSuccess("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, text));
                }
                else
                {
                    testReport.LogFailure("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Assert Tex tEqual
        /// </summary>
        /// <param name="driver">Locators,text</param>
        /// <returns></returns>
        public static void AssertTextNotEqual(this IWebDriver driver, By locator, string text)
        {
            String actual = "";
            try
            {
                if (driver.IsElementPresent(locator))
                {
                    actual = driver.FindElement(locator).Text.Trim();
                    Assert.AreNotEqual(actual, text.Trim());
                    testReport.LogSuccess("Verify Not Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, text));
                }
                else
                {
                    testReport.LogFailure("Verify Not Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, text), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Verify Not Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, text), EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Assert Tex tEqual
        /// </summary>
        /// <param>Locators,text</param>
        /// <returns></returns>
        public static void AssertTextMatching(this IWebDriver driver, string actual, string expected)
        {
            try
            {
                Assert.AreEqual(actual.Trim(), expected.Trim());
                testReport.LogSuccess("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> not matching", actual, expected), EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Assert Tex tEqual
        /// </summary>
        /// <param>Locators,text</param>
        /// <returns></returns>
        public static void AssertTextMatching(this IWebDriver driver, double actual, double expected)
        {
            try
            {
                Assert.AreEqual(actual, expected);
                testReport.LogSuccess("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> not matching", actual, expected), EngineSetup.GetScreenShotPath());
            }
        }
        public static void AssertTrue(this IWebDriver driver, string actual, string expected)
        {
            try
            {
                Assert.AreEqual(actual.Contains(expected), true);
                testReport.LogSuccess("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> not matching", actual, expected), EngineSetup.GetScreenShotPath());
            }
        }
        public static void AssertNotTrue(this IWebDriver driver, string actual, string expected)
        {
            try
            {
                Assert.AreNotEqual(expected.Contains(actual), true);
                testReport.LogSuccess("Text not contains", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> is not displayed", expected, actual));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text not contains", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> is displayed", expected, actual), EngineSetup.GetScreenShotPath());
            }
        }

        public static void AssertTextEqualFromTextBox(this IWebDriver driver, By locator, string text)
        {
            String actual = "";
            try
            {
                if (driver.IsElementPresent(locator))
                {
                    actual = driver.FindElement(locator).GetAttribute("value").Trim();
                    Assert.AreEqual(actual, text.Trim());
                    //Assert.IsTrue(actual.Contains(text.Trim()));
                    testReport.LogSuccess("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, text));
                }
                else
                {
                    testReport.LogFailure("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Verify Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
            }
        }
        /// <summary>
        /// Assert Text Contains
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void AssertTextContains(this IWebDriver driver, By locator, string text)
        {
            string actual = "";
            try
            {
                if (driver.IsElementPresent(locator))
                {
                    actual = driver.FindElement(locator).Text;
                    Assert.IsTrue(actual.Contains(text.Trim()));
                    testReport.LogSuccess("Verify text Contains", String.Format("Actual: <mark>{0}</mark>,Contains: <mark>{1}</mark> are matching", actual, text));


                }
                else
                {
                    testReport.LogFailure("Verify text Contains", String.Format("Actual: <mark>{0}</mark>,Contains: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
                }

            }
            catch (Exception e)
            {
                testReport.LogFailure("Verify text Contains", String.Format("Actual: <mark>{0}</mark>,Contains: <mark>{1}</mark> are not matching", actual, text), EngineSetup.GetScreenShotPath());
            }


        }
        
        public static void AssertTextNotMatching(this IWebDriver driver, String actual, String expected)
        {
            try
            {
                Assert.AreNotEqual(actual, expected);
                testReport.LogSuccess("Text Not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, expected));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text Not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected), EngineSetup.GetScreenShotPath());
            }
        }
        public static void AssertAreEqual(this IWebDriver driver, String actual, String expected)
        {
            try
            {
                Assert.AreEqual(actual, expected);
                testReport.LogSuccess("Text Not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, expected));
            }
            catch (Exception e)
            {
                testReport.LogFailure("Text Not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected), EngineSetup.GetScreenShotPath());
            }
        }
        
      //public static void AssertAreEqual(this IWebDriver driver, String actual, String expected)
      //  {
      //      try
      //      {
      //          Assert.AreEqual(actual, expected);
      //          testReport.LogSuccess("Assert Are Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", actual, expected));
      //      }
      //      catch (Exception e)
      //      {
      //          testReport.LogFailure("Assert Are Equal", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", actual, expected), EngineSetup.GetScreenShotPath());
      //      }
      //  }
        /// <summary>
        /// Verify Element present
        /// </summary>
        /// <param name="driver">Locators</param>
        /// <returns></returns>
        public static void VerifyWebElementPresent(this IWebDriver driver, By locator, string controlName)
        {
            try
            {
                driver.WaitElementPresent(locator);
                if (driver.IsWebElementDisplayed(locator))
                {
                    testReport.LogSuccess("Element Present", String.Format("Element is present - <mark>{0}</mark>", controlName));
                }
                else
                {
                    testReport.LogFailure("Element Present", String.Format("Element not present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Element Present", String.Format("Element not present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// Verify Element Disabled
        /// </summary>
        /// <param name="driver">Locators</param>
        /// <returns></returns>
        public static void VerifyWebElementDisabled(this IWebDriver driver, By locator, string controlName)
        {
            try
            {
                driver.WaitElementPresent(locator);
                if (driver.FindElement(locator).Enabled==false)
                {
                    testReport.LogSuccess("Element Disabled - "+controlName, String.Format("Element is in disabled state - <mark>{0}</mark>", controlName));
                }
                else
                {
                    testReport.LogFailure("Element Disabled - " + controlName, String.Format("Element is not in disabled state - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Element Disabled - " + controlName, String.Format("Element not present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// Verify Element Enabled
        /// </summary>
        /// <param name="driver">Locators</param>
        /// <returns></returns>
        public static void VerifyWebElementEnabled(this IWebDriver driver, By locator, string controlName)
        {
            try
            {
                driver.WaitElementPresent(locator);
                if (driver.FindElement(locator).Enabled == true)
                {
                    testReport.LogSuccess("Element Enabled - " + controlName, String.Format("Element is in Enabled state - <mark>{0}</mark>", controlName));
                }
                else
                {
                    testReport.LogFailure("Element Enabled - " + controlName, String.Format("Element is not in Enabled state - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
                }
            }
            catch (Exception e)
            {
                testReport.LogFailure("Element Enabled - " + controlName, String.Format("Element not present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }

        /// <summary>
        /// Reusable method to click dropdown and search text
        /// </summary>
        /// <param name="driver">webdriver object</param>
        /// <param name="elementToClick">element to click</param>
        /// <param name="elementToSendKeys">element to enter the text</param>
        /// <param name="textForSendKeys">text to enter</param>
        /// <param name="controlName">control name</param>
        public static void ClickDropdownAndSearchText(this IWebDriver driver, By elementToClick, By elementToSendKeys, string textForSendKeys, string controlName)
        {
            try
            {
                driver.ClickElement(elementToClick, controlName);
                driver.SendKeysToElementAndPressEnter(elementToSendKeys, textForSendKeys, controlName);
                driver.sleepTime(15000);
            }
            catch (Exception e)
            {
                testReport.LogFailure("ClickDropdownAndSearchText - "+controlName, String.Format("Error occurred while performing action on - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }
        /// <summary>
        ///  Reusable method to click Element and Send Keys
        /// </summary>
        /// <param name="driver">webdriver object</param>
        /// <param name="elementToClick">element to click</param>
        /// <param name="txtForSendKeys">text to enter</param>
        /// <param name="controlName">>control name</param>
        public static void ClickElementAndSendKeys(this IWebDriver driver,By elementToClick,string txtForSendKeys,string controlName)
        {
            try
            {
               driver.SendKeysToElement(elementToClick, txtForSendKeys, controlName);
            }
            catch (Exception ex)
            {
                testReport.LogFailure("ClickDropdownAndSearchText - " + controlName, String.Format("Error occurred while performing action on - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }

        public static void VerifyWebElementNotPresent(this IWebDriver driver, By locator, string controlName)
        {
            if (driver.IsWebElementDisplayed(locator))
            {
                testReport.LogFailure("Element Present", String.Format("Element is present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }
            else
            {
                testReport.LogSuccess("Element Not Present", String.Format("Element is not present - <mark>{0}</mark>", controlName), EngineSetup.GetScreenShotPath());
            }

        }

       #endregion

    }
}
