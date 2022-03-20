
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class OR_eCommerce_Landing_Page
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;
        public ExtentTest ReportLogger;
        string TestCaseName;

        public OR_eCommerce_Landing_Page(IWebDriver driver,string TCName, ExtentTest ReportLogger)
        {
            this.driver = driver;
            this.TestCaseName = TCName;
            this.ReportLogger = ReportLogger;
            objSeleniumMethodLib = new SeleniumSetMethodLibrary(this.driver,TestCaseName, ReportLogger);
        }

        #region Locators for OR_eCommerce_Home Page

        //Locator for Page Container
        public IWebElement Container_PageText => driver.FindElement(By.XPath(OR_eCommerceConsts.Container_PageText));

        //Locator for SignIn Link
        public IWebElement Link_SignIn => driver.FindElement(By.ClassName(OR_eCommerceConsts.Link_Sign_In));

        //Locator for SignOut Link
        public IWebElement Link_SignOut => driver.FindElement(By.ClassName(OR_eCommerceConsts.Link_Sign_Out));


        //Locator for Create button on header
        public IWebElement TB_EmailAddress => driver.FindElement(By.Id("email_create"));

        //Locator for Create an Account
        public IWebElement Button_CreateAnAccount => driver.FindElement(By.Id("SubmitCreate"));

        //Locator for Radio Button Male

        public IWebElement RB_Male => driver.FindElement(By.Id("uniform-id_gender2"));
        //Locator for First Name of Customer
        public IWebElement TB_FirstName_Customer => driver.FindElement(By.Id("customer_firstname"));

        //Locator for Last  Name of Customer
        public IWebElement TB_LastName_Customer => driver.FindElement(By.Id("customer_lastname"));

        //Locator for Password Field
        public IWebElement TB_Password => driver.FindElement(By.Id("passwd"));

        //Loctor for Address Field
        public IWebElement TB_Address_1 => driver.FindElement(By.Id("address1"));

        //Loctor for City Field
        public IWebElement TB_City => driver.FindElement(By.Id("city"));

        //Loctor for State Field
        public IWebElement DD_State => driver.FindElement(By.Id("uniform-id_state"));

        public IWebElement DD_State_List => driver.FindElement(By.Id("id_state"));

        //Locator for Country Field
        public IWebElement DD_Country => driver.FindElement(By.Id("id_country"));

        //Locator for PostCode   
        public IWebElement TB_ZipCode => driver.FindElement(By.Id("postcode"));
        
        //Locator for Mobile Phone
        public IWebElement TB_Mobile_Phone => driver.FindElement(By.Id("phone_mobile"));
        
        //Locator for Register Account Button
        public IWebElement Button_Register => driver.FindElement(By.Id("submitAccount"));

        #endregion Locators Locators for OR_eCommerce_Home Page

        #region Methods for OR_eCommerce_Home  Application


        //This method will Sign Up user for eCommerce Application.

        public bool SignUp(string randomText_email, string randomText_FirstName, string randomText_LastName, string random_Text_address, string random_Text_City, string randomNumber_Password, string state, string Country, string randomNumber_Mobile, string Home_page_title)
        {
            objSeleniumMethodLib.clickElement(Link_SignIn);

            objSeleniumMethodLib.enterText(TB_EmailAddress, randomText_email + "@gmail.com");
            ReportLogger.Info("Entered Randomely Generated email Address");
            objSeleniumMethodLib.clickElement(Button_CreateAnAccount);
            ReportLogger.Info("Clicked on Create Account Button");
            objSeleniumMethodLib.ThreadSleep(3000);
            
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", RB_Male);
            
            objSeleniumMethodLib.enterText(TB_FirstName_Customer,"FN"+ randomText_FirstName);
            ReportLogger.Info("Entered Randomely Generated First Name");
            objSeleniumMethodLib.enterText(TB_LastName_Customer, "LN" + randomText_LastName);
            ReportLogger.Info("Entered Randomely Generated Last Name");
            objSeleniumMethodLib.enterText(TB_Password, randomNumber_Password.ToString());
            ReportLogger.Info("Entered Randomely Generated Password");
            objSeleniumMethodLib.enterText(TB_Address_1, random_Text_address);
            ReportLogger.Info("Entered Randomely Generated  Address");
            objSeleniumMethodLib.enterText(TB_City, random_Text_City);
            ReportLogger.Info("Entered Randomely Generated City");

            objSeleniumMethodLib.clickElement(DD_State);
            objSeleniumMethodLib.SelectDropDown(DD_State_List, state);
            ReportLogger.Info("Selected State from Dropdown");

            objSeleniumMethodLib.enterText(TB_ZipCode, "10001");
            objSeleniumMethodLib.enterText(TB_Mobile_Phone,randomNumber_Mobile.ToString());

            ReportLogger.Info("Entered Random Mobile Number");
            objSeleniumMethodLib.clickElement(Button_Register);

            ReportLogger.Info("Clicked on Register Button");
            objSeleniumMethodLib.ThreadSleep(3000);

            if (objSeleniumMethodLib.VerifyPageTitle(Home_page_title))
            {
                ReportLogger.Info("Home Page Title verified successfully.");
                return true;
            }
            else
            {
                return false;
            }

        }


        //This method will move a card.
        //public void moveCard()
        //{
        //    objSeleniumMethodLib.clickElement(Link_Test_Board);
        //    objSeleniumMethodLib.ThreadSleep(1500);

        //    ReportLogger.Info("Using Action class to hover on the control to make edit icon visible.");
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(Button_Hidden_Edit_Icon).Build().Perform();

        //    objSeleniumMethodLib.ThreadSleep(1500);

        //    ReportLogger.Info("Using Action class to drag and drop the card from one list to another");
        //    action.ClickAndHold(Icon_Edit_Task).MoveToElement(Placeholder_Add_a_Card).Release(Placeholder_Add_a_Card).Build().Perform();

        //}

        #endregion Methods for Trello Home Page Application


    }
}
