using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class SeleniumSetMethodLibrary
    {
        public IWebDriver driver;
        public string TestCaseName;
        public ExtentTest ReportLogger;

        // Contructor for the class
        public SeleniumSetMethodLibrary(IWebDriver Driver, string TCName, ExtentTest ReportLogger)
        {
            this.driver = Driver;
            this.TestCaseName = TCName;
            this.ReportLogger = ReportLogger;
        }

        // -------------------- Generic Methods ----------------------
        // Navigate to Browser
        public void NavigateToURL(string URL)
        {
            string MethodName = "NavigateToURL";
            try
            {
                this.driver.Navigate().GoToUrl(URL);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }
        // Maximize the Browser
        public void Maximize()
        {
            string MethodName = "Maximize";
            try
            {
                driver.Manage().Window.Maximize();
                ThreadSleep(100);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        // Close the driver instance
        public void CloseDriver()
        {
            this.driver.Close();
        }

        // Thread sleep
        public void ThreadSleep(int no)
        {
            System.Threading.Thread.Sleep(no);
        }

        // Get current time
        public String GetTimestamp(DateTime value)
        {
            return value.ToString().Replace(":", "_");
        }

        public void clickElement(IWebElement webelement)
        {
            string MethodName = "clickElement";
            ThreadSleep(2000);
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                HighlighteElement(webelement, driver);
                mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webelement)).Click();
                ThreadSleep(700);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;

            }
        }

        public void enterText(IWebElement webelement, string value)
        {
            string MethodName = "enterText";
            ThreadSleep(300);
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                HighlighteElement(webelement, driver);
                mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webelement)).SendKeys(value);
                ThreadSleep(300);
            }
            catch (WebDriverTimeoutException e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public void SelectDropDown(IWebElement element, string text)
        {
            string MethodName = "SelectDropDown";
            ThreadSleep(1000);
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                HighlighteElement(element, driver);
                //mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                new SelectElement(element).SelectByText(text);
                ThreadSleep(1000);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }



        public void selectCheckBox(IWebElement webelement)
        {
            string MethodName = "selectCheckBox";
            try
            {
                if (webelement.Displayed)
                {
                    webelement.Click();
                    ThreadSleep(1000);
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public void SelectRadioBtn(IWebElement element)
        {
            string MethodName = "SelectRadioBtn";
            string WebElement = element.ToString();
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                HighlighteElement(element, driver);
                mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
                ThreadSleep(1000);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public string getText(IWebElement weblement)
        {
            string MethodName = "getText";
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                HighlighteElement(weblement, driver);
                mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(weblement));
                ThreadSleep(1000);
                return weblement.Text;
            }
            catch (Exception e)
            {
                ScreenShotonFailure();
                return e.Message;
            }
        }


        // Method to switch to Active window
        public void SwitchToActiveWindow()
        {
            string MethodName = "SwitchToActiveWindow";
            try
            {
                driver.SwitchTo().ActiveElement();
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Method to switch to Frame
        public void SwitchToFrame(IWebElement frame)
        {
            string MethodName = "SwitchToFrame";
            try
            {
                WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                HighlighteElement(frame, driver);
                mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(frame));
                driver.SwitchTo().Frame(frame);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Method to switch to default content(frame)
        public void SwitchToDefaultFrame()
        {
            string MethodName = "SwitchToDefaultFrame";
            try
            {
                driver.SwitchTo().DefaultContent();
                ThreadSleep(2000);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }

        }

        // Method to Clear text
        public void clearText(IWebElement webelement)
        {
            string MethodName = "clearText";
            try
            {
                if (webelement.Displayed)
                {
                    WebDriverWait mywait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    HighlighteElement(webelement, driver);
                    mywait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webelement)).Clear();
                    ThreadSleep(1000);
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public void acceptAlert(IWebElement webelement)
        {
            string MethodName = "acceptAlert";
            try
            {
                ReportLogger.Info("The alert: " + driver.SwitchTo().ActiveElement().Text + "started");
                ThreadSleep(500);
                driver.SwitchTo().ActiveElement();
                HighlighteElement(webelement, driver);
                webelement.Click();
                ReportLogger.Info("The alert: " + driver.SwitchTo().Alert().Text + "accepted");
                ThreadSleep(1000);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Below method is used to Select a Checkbox, if it is not selected already
        public void selectCheckbox(IWebElement webElement, string elementinfo, By byLocator)
        {
            string MethodName = "selectCheckbox";
            try
            {
                bool elementDisplayed = waitTillElementisDisplayed(driver, byLocator, 10);
                if (elementDisplayed == true && webElement.Selected)
                {
                    ReportLogger.Info("Checkbox: " + webElement.Text + "is already selected");
                }
                else if (elementDisplayed == true)
                {
                    webElement.Click();
                    ReportLogger.Info("Selected " + elementinfo);
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Below method is used to De-select a Checkbox, if it is selected already
        public void deselectCheckbox(IWebElement webelement, string elementinfo)
        {
            string MethodName = "deselectCheckbox";
            string WebElement = webelement.ToString();
            try
            {
                if (webelement.Selected)
                {
                    //De-select the checkbox
                    webelement.Click();
                    ReportLogger.Info("Deselected " + elementinfo);
                }
                else
                {
                    ReportLogger.Error(elementinfo + " is already deselected");
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }



        public Boolean isWebElementVisible(IWebElement webelement, string elementinfo)
        {
            string MethodName = "isWebElementVisible";
            try
            {
                WebDriverWait WaitforAjax = new WebDriverWait(driver, TimeSpan.FromSeconds(16));
                HighlighteElement(webelement, driver);
                WaitforAjax.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webelement));
                if (webelement.Displayed)
                {
                    return true;
                }
                else
                {
                    string MEssage = "WebElement Not Visible";
                    return (Exception_bool(MethodName, MEssage));
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                return (Exception_bool(MethodName, MEssage));
                throw e;
            }
        }



        public bool VerifyPageTitle(string ExpectedTitle)
        {
            string MethodName = "VerifyPageTitle";
            try
            {
                if (driver.Title.Trim().Equals(ExpectedTitle.Trim()))
                {
                    ThreadSleep(1000);
                    return true;
                }
                else
                {
                    throw new ElementNotVisibleException(ExpectedTitle + "not valid!");
                    
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }



        public Boolean isWebElementNotVisible(IWebElement webelement, string elementinfo)
        {
            string MethodName = "isWebElementNotVisible";
            try
            {
                if (!webelement.Displayed)
                {
                    ThreadSleep(1000);
                    HighlighteElement(webelement, driver);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                return (Exception_bool(MethodName, MEssage));
                throw e;
            }
        }


        // Method to check whether input field/text box is editable
        public Boolean isInputFieldEditable(IWebElement webelement)
        {
            string MethodName = "isInputFieldEditable";
            string WebElement = webelement.ToString();
            try
            {
                HighlighteElement(webelement, driver);
                webelement.Clear();
                return true;
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                return (Exception_bool(MethodName, MEssage));
                throw e;
            }
        }


        // Method to Verify WebElement Text
        public void VerifyText(IWebElement webElement, String ExpectedText)
        {
            string MethodName = "VerifyText";
            string WebElement = webElement.ToString();
            try
            {
                if (webElement.Text.Trim().Equals(ExpectedText.Trim()))
                {
                }
                else
                { 
                    throw new Exception("Wrong Text : " + webElement.Text + " ====> Expected Text : " + ExpectedText);
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Method to switch to another window based on the title
        public void windowSwitch(string PageTitle)
        {
            string MethodName = "windowSwitch";
            try
            {
                ReadOnlyCollection<string> handles = driver.WindowHandles;
                int a = 0;
                for (int i = 0; i < handles.Count; i++)

                {
                    if (driver.SwitchTo().Window(handles[i]).Title == PageTitle)
                    {
                        driver.SwitchTo().Window(handles[i]);
                        ReportLogger.Pass("Redirected to Correct page : " + driver.Title);
                        a = 1;
                        break;
                    }
                }
                if (a != 1)
                {
                    ReportLogger.Fail("The expected page " + PageTitle + " was not opened");
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        public void windowHandler(IWebElement webelement)
        {
            string MethodName = "windowHandler";
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                ReadOnlyCollection<string> originalHandles = driver.WindowHandles;
                PopupWindowFinder finder = new PopupWindowFinder(driver);
                string popupWindowHandle = finder.Click(webelement);
                driver.SwitchTo().Window(popupWindowHandle);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        public void switchToParentWindow()
        {
            string MethodName = "switchToParentWindow";
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                driver.Close();
                driver.SwitchTo().Window(parentWindow);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        // Close Browser
        public void windowClose()
        {
            string MethodName = "windowClose";
            try
            {
                driver.Close();
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        // Method to Navigate to previous page
        public void NavigateToPreviousPage()
        {
            string MethodName = "previousPage";
            try
            {
                driver.Navigate().Back();
                ThreadSleep(3000);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }



        public void VerifyLoginText(IWebElement element, string msg)
        {
            string MethodName = "VerifyLoginText";
            string WebElement = element.ToString();

            try
            {
                if (element.Text.Contains(msg))
                {

                }
                else
                {

                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }



        public void ChangeURL(string url)
        {
            string MethodName = "ChangeURL";
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public void ValidateNames(string name, string username)
        {
            string MethodName = "ValidateNames";
            try
            {
                if (!name.Equals(username))
                {
                    ThreadSleep(1000);

                    throw new ElementNotVisibleException(username + " invalid!");
                }
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }


        public void ScreenShotonFailure()
        {
            try
            {
                StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString("yyyy_MM_dd_hh_mm"));
                ITakesScreenshot driverScreenCapture = driver as ITakesScreenshot;
                Screenshot CurrentScreen = driverScreenCapture.GetScreenshot();
                string ScreenShotPathPrjFld = Path.Combine(ProjectConfiguration.Selenium_ScreenShotLocation, ProjectConfiguration.Selenium_ApplicationName + "_" + TimeAndDate + "_" + TestCaseName + ".JPEG");
                CurrentScreen.SaveAsFile(ScreenShotPathPrjFld, ScreenshotImageFormat.Jpeg);
                string ScreenShotPathCdrive = $"C:\\Projects\\Automation_ScreenShots\\{ProjectConfiguration.Selenium_ApplicationName}_{TimeAndDate}_{TestCaseName}.JPEG";
                CurrentScreen.SaveAsFile(ScreenShotPathCdrive, ScreenshotImageFormat.Jpeg);
                //ReportLogger.Fail("Screen capture of failure on screen", MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotPathPrjFld).Build());
                ReportLogger.AddScreenCaptureFromPath(ScreenShotPathCdrive);

            }
            catch (Exception ex)
            {

                ReportLogger.Error("Exception in ScreenShotonFailure Method");
            }
        }


        // Explicit wait
        public static bool waitTillElementisDisplayed(IWebDriver driver, By byLocator, int timeoutInSeconds)
        {
            bool elementDisplayed = false;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    myWait.Until(drv => drv.FindElement(byLocator).Displayed && drv.FindElement(byLocator).Enabled);
                }

                elementDisplayed = driver.FindElement(byLocator).Displayed;

            }
            catch (Exception e)
            {
                Assert.Fail("Exception in waitTillElementisDisplayed Method" + e.Message);
            }
            return elementDisplayed;
        }

        // Draw border around Webelement
        public void HighlighteElement(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript("arguments[0].style.border='4px solid purple'", element);
        }

        //Wait till the till disappears from the page
        public static bool waitTillElementisInvisible(IWebDriver driver, By byLocator, int timeoutInSeconds)
        {
            bool elementNotDisplayed = false;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    myWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(byLocator));
                }

                elementNotDisplayed = !driver.FindElement(byLocator).Displayed;


            }
            catch (Exception e)
            {
                Assert.Fail("Exception in waitTillElementisInvisible Method" + e.Message);
            }

            return elementNotDisplayed;
        }


        //Waits till the page is completely loaded
        public void waitForPageLoad(int timeoutInSeconds)
        {
            string MethodName = "waitForPageLoad";
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        //Scrolls down the page to get element in view
        public void getElementInView(IWebElement element)
        {
            string MethodName = "waitForPageLoad";
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //This will scroll the page till the element is found		
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception e)
            {
                String MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;

            }
        }

        public void clickElementJavaScript(IWebElement webelement, string message)
        {
            string MethodName = "clickElementJavaScript";
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //This will scroll the page till the element is found		
                js.ExecuteScript("arguments[0].click();", webelement);
            }
            catch (Exception e)
            {
                string MEssage = e.Message;
                Exception(MethodName, MEssage);
                throw e;
            }
        }

        public bool Exception_bool(string MethodName, string Message)
        {
            ReportLogger.Fail("Failure in" + " " + MethodName + "()" + Message);
            return false;
        }

        public void Exception(string MethodName, string Message)
        {
            ReportLogger.Fail("Failure in" + " " + MethodName + "()" + Message);
        }

    }
}
