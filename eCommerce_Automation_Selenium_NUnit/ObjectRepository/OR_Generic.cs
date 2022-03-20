using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;
using System;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class OR_Generic
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;
        public ExtentTest ReportLogger;
        string TestCaseName;

        public OR_Generic(IWebDriver driver, string TCName, ExtentTest ReportLogger)
        {
            this.driver = driver;
            this.TestCaseName = TCName;
            this.ReportLogger = ReportLogger;
            objSeleniumMethodLib = new SeleniumSetMethodLibrary(this.driver,TestCaseName, ReportLogger);
        }

        #region Locators for Generic functionalities

        //Locator for Page Container
        public IWebElement Container_PageText => driver.FindElement(By.XPath(OR_eCommerceConsts.Container_PageText));

        //Locator for Entering Email Address
        public IWebElement TB_UserName_Email => driver.FindElement(By.Id("email"));

        //Locator for Entering Password Field
        public IWebElement TB_Password => driver.FindElement(By.Id("passwd"));

        //Locator for SignIn Link
        public IWebElement Link_SignIn => driver.FindElement(By.ClassName(OR_eCommerceConsts.Link_Sign_In));

        //Locator for SignOut Link
        public IWebElement Link_SignOut => driver.FindElement(By.XPath(OR_eCommerceConsts.Link_Sign_Out));


        //Locator for Sign In Button
        public IWebElement Button_Submit => driver.FindElement(By.Id("SubmitLogin"));

        //Locator for Home Link
        public IWebElement Link_Home => driver.FindElement(By.XPath(OR_eCommerceConsts.Link_Home));


        #endregion Locators for Generic functionalities

        #region Methods for Generic Functionalities

        public string GenerateRandomNumber()
        {
            Random randomnummer = new Random();

            return randomnummer.Next(1,100000).ToString("D10"); // returns random integers >= 10 and < 19
            
        }

        public string GenerateRandomText()
        {
            var CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var arr_Char = new char[10];
            var random = new Random();

            for (int i = 0; i < arr_Char.Length; i++)
            {
                arr_Char[i] = CharSet[random.Next(CharSet.Length)];
            }

            var resultString = new String(arr_Char);

            return resultString;
        }

        public void SignOut()
        {
            objSeleniumMethodLib.clickElement(Link_SignOut);
            objSeleniumMethodLib.ThreadSleep(2000);
        }
        public bool UserLogin_AutomationPractice(string userName, string passWord)
        {
            objSeleniumMethodLib.clickElement(Link_SignIn);
            objSeleniumMethodLib.enterText(TB_UserName_Email, userName);
            objSeleniumMethodLib.enterText(TB_Password, passWord);
            objSeleniumMethodLib.clickElement(Button_Submit);
            if (Link_Home.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Methods for Generic Functionalities

    }

}
