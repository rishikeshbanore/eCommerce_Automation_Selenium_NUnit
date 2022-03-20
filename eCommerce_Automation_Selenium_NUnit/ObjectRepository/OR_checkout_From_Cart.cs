using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class OR_Checkout_From_Cart
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;
        public ExtentTest ReportLogger;
        string TestCaseName;

        public OR_Checkout_From_Cart(IWebDriver driver, string TCName, ExtentTest ReportLogger)
        {
            this.driver = driver;
            this.TestCaseName = TCName;
            this.ReportLogger = ReportLogger;
            objSeleniumMethodLib = new SeleniumSetMethodLibrary(this.driver, TestCaseName, ReportLogger);
        }

        #region Locators for Search Product

        //Locator for Page Container
        public IWebElement Container_PageText => driver.FindElement(By.XPath(OR_eCommerceConsts.Container_PageText));

        //Locator for Home Link
        public IWebElement Link_Home => driver.FindElement(By.XPath(OR_eCommerceConsts.Link_Home));

        //Locator for Summary- Checkout
        public IWebElement Link_Summary_Checkout => driver.FindElement(By.XPath("(//a[@title='Proceed to checkout'])[2]"));

        //Locator for Address- Checkout
        public IWebElement Link_Address_Checkout => driver.FindElement(By.XPath("(//button[@name='processAddress'])"));

        //Locator for Shipping- Checkout
        public IWebElement Link_Shipping_Checkout => driver.FindElement(By.XPath("(//button[@name='processCarrier'])"));

        //Locator for Checkbox_Terms and Conditions
        public IWebElement CB_Agree_TC => driver.FindElement(By.XPath("//*[@id='form']/div/p[2]/label"));

        //Locator for Pay by Bank Wire
        public IWebElement Button_Pay_Bank_Wire => driver.FindElement(By.XPath("//a[@class='bankwire']"));

        //Locator for Pay by Bank Wire
        public IWebElement Button_Confirm_Order => driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']"));

        #endregion Locators for Search Product

        #region Methods for Adding Product to Cart and Removing from Cart

        public bool checkOutCart(string Text)
        {
            objSeleniumMethodLib.clickElement(Link_Summary_Checkout);
            ReportLogger.Info("Clicked on Checkout Button on Summary Page");
            objSeleniumMethodLib.ThreadSleep(3000);
            objSeleniumMethodLib.clickElement(Link_Address_Checkout);
            ReportLogger.Info("Clicked on Checkout Button on Address Page");
            objSeleniumMethodLib.ThreadSleep(3000);
            objSeleniumMethodLib.clickElement(CB_Agree_TC);
            ReportLogger.Info("Clicked on Terms and Condition Check box");
            objSeleniumMethodLib.ThreadSleep(3000);
            objSeleniumMethodLib.clickElement(Link_Shipping_Checkout);
            ReportLogger.Info("Clicked on Checkout Button on Shipping Page");
            objSeleniumMethodLib.ThreadSleep(3000);
            objSeleniumMethodLib.clickElement(Button_Pay_Bank_Wire);
            ReportLogger.Info("Clicked on Pay by Bank Wire Page");
            objSeleniumMethodLib.ThreadSleep(3000);
            objSeleniumMethodLib.clickElement(Button_Confirm_Order);
            ReportLogger.Info("Clicked on Confirm Order Page.");
            objSeleniumMethodLib.ThreadSleep(3000);

            if (Container_PageText.Text.Contains(Text))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion Methods for Adding Product to Cart and Removing from Cart
    }
}
