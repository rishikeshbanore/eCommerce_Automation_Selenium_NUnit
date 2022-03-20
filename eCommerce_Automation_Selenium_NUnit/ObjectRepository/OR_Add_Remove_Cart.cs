using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class OR_Add_Remove_Cart
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;
        public ExtentTest ReportLogger;
        string TestCaseName;

        public OR_Add_Remove_Cart(IWebDriver driver, string TCName, ExtentTest ReportLogger)
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

        //Locator for Add to Comapre
        public IWebElement Link_add_To_Compare => driver.FindElement(By.XPath("//div[@id='center_column']/ul/li[2]"));

        //Locator for Image
        public IWebElement image => driver.FindElement(By.XPath("//div[@class='row']/div[2]/ul/li/div/div/div/a/img"));
        

        //Locator for Add to Cart
        public IWebElement Link_add_To_Cart=> driver.FindElement(By.XPath(".//*[text()='Add to cart']"));
        
        //Locator for Proceed to Checkout
        public IWebElement Link_Proceed_To_CheckOut => driver.FindElement(By.XPath(".//a[contains(@title,'Proceed to checkout')]"));

        //Locator to Delete from Cart
        public IWebElement Button_Delete_From_Cart => driver.FindElement(By.XPath("//td[@class='cart_delete text-center']/div/a[@title='Delete']"));
        
        #endregion Locators for Search Product

        #region Methods for Adding Product to Cart and Removing from Cart

        public bool addToCart(string Text, string Price)
        {
            ReportLogger.Info("Using Action class to hover on the control to make edit icon visible.");
            Actions action = new Actions(driver);
            action.MoveToElement(image).Build().Perform();

            objSeleniumMethodLib.clickElement(Link_add_To_Cart);

            ReportLogger.Info("Product added into Cart.");
            objSeleniumMethodLib.clickElement(Link_Proceed_To_CheckOut);

            if (Container_PageText.Text.Contains(Text) && Container_PageText.Text.Contains(Price))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool deleteFromCart(string DeleteText)
        {
            objSeleniumMethodLib.clickElement(Button_Delete_From_Cart);
            objSeleniumMethodLib.ThreadSleep(5000);

            if (Container_PageText.Text.Contains(DeleteText))
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
