using System;
using NUnit.Framework;


namespace eCommerce_Automation_Selenium_NUnit
{
    [TestFixture]
    public class TC_001_Search_Product : BaseClass
    {
        [SetUp]
        public void TestSetup()
        {
            //This is a call to a method for trello Login.
            if (objGeneric.UserLogin_AutomationPractice(ProjectConfiguration.Selenium_Email, ProjectConfiguration.Selenium_Password))
            {
                ReportLogger.Pass("User has logged in successfully in Automation Practice Site.");
            }
            else
            {
                ReportLogger.Fail("User has NOT logged in successfully in Automation Practice site.");
                Assert.Fail("User Login Failed");
            }
        }

        [Category("Regression")]
        [Test, Order(1)]
        public void TC001_Search_Product()
        {
            try
            {
                ReportLogger.Info("Starting test script to search items with 3 search criteria");

                //This is call to the method which will set Search Criteria and check if matching results are retrived.
                if (objSearchProduct.searchProduct(JSONDataReader.Search_Result_Count))
                {
                    ReportLogger.Pass("TC001_Search_Product is executed successfully.");
                }
                else
                {
                    ReportLogger.Fail("TC001_Search_Product is NOT executed successfully.");
                }
                
            }
            catch (Exception e)
            {
                ReportLogger.Fail(e.Message + "Exception in TC_001_Search_Product Test Case.");
                objSeleniumMethodLib.ScreenShotonFailure();
                Assert.Fail(e.Message + "Exception in TC_001_Search_Product Test Case. ");
            }
        }

        [TearDown]
        public void CleanUp()
        {
            try
            {

            }
            finally
            {
                //This method will log out User from ECommerce Applicaton
                objGeneric.SignOut();
                
                //driver close and Report writing
                TestCleanup();
            }
        }
    }
}
