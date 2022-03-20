using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class OR_SearchProduct
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;
        public ExtentTest ReportLogger;
        string TestCaseName;

        public OR_SearchProduct(IWebDriver driver, string TCName, ExtentTest ReportLogger)
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

        //Locator for "Women" tab
        public IWebElement Tab_women => driver.FindElement(By.XPath(OR_eCommerceConsts.Link_Women));

        //Locator for Categories - Top
        public IWebElement CB_Tops => driver.FindElement(By.Id("uniform-layered_category_4"));

        //Locator for Categories - Top
        public IWebElement CB_Tops_LT => driver.FindElement(By.LinkText("Tops (2)"));

        //Locator for Size 
        public IWebElement CB_Size => driver.FindElement(By.LinkText("S (2)"));

        //Locator for Categories - Top
        public IWebElement CB_Colour_LT => driver.FindElement(By.LinkText("Black (1)"));

        #endregion Locators for Search Product

        #region Methods for Search Product

        public bool searchProduct(string searchcount)
        {
            objSeleniumMethodLib.clickElement(Link_Home);
            objSeleniumMethodLib.ThreadSleep(4000);
            objSeleniumMethodLib.clickElement(Tab_women);
            objSeleniumMethodLib.clickElement(CB_Tops_LT);
            ReportLogger.Info("First Search Criteria is Set");
            objSeleniumMethodLib.ThreadSleep(4000);
            objSeleniumMethodLib.clickElement(CB_Size);
            ReportLogger.Info("Second Search Criteria is Set");
            objSeleniumMethodLib.ThreadSleep(4000);
            objSeleniumMethodLib.clickElement(CB_Colour_LT);
            ReportLogger.Info("Third Search Criteria is Set");
            objSeleniumMethodLib.ThreadSleep(4000);

            if (Container_PageText.Text.Contains(searchcount))
            {
                ReportLogger.Info("Only products matching with search criteria are displayed.");
                return true;
            }
            else
            {
                ReportLogger.Info("Products NO matching with search criteria are also displayed.");
                return false;
            }
            
        }

        #endregion Methods for Search Product

    }

}
