using System;
using NUnit.Framework;


namespace eCommerce_Automation_Selenium_NUnit
{
    [TestFixture]
    public class TC_004_SignUp : BaseClass
    {
        [SetUp]
        public void TestSetup()
        {

        }

        [Category("Regression")]
        [Test, Order(4)]
        public void TC004_SignUp()
        {
            try
            {
                //This is a call to a method for creating board.
                ReportLogger.Info("Starting test script for Signing Up New User for eCommerceSite");

                if (objECommerceHome.SignUp(objGeneric.GenerateRandomText(), objGeneric.GenerateRandomText(), objGeneric.GenerateRandomText(), objGeneric.GenerateRandomText(), objGeneric.GenerateRandomText(), objGeneric.GenerateRandomNumber(), JSONDataReader.State, JSONDataReader.Country, objGeneric.GenerateRandomNumber(), JSONDataReader.Home_Page_Title))
                {
                    ReportLogger.Pass("User Account is Created Successfully.");
                }
                else
                {
                    ReportLogger.Fail("User Account is NOT Created Successfully.");
                }

            }
            catch (Exception e)
            {
                ReportLogger.Fail(e.Message + "Exception in TC_004_SignUp Test Case. User Account is NOT Created");
                objSeleniumMethodLib.ScreenShotonFailure();
                Assert.Fail(e.Message + "Exception in TC_004_SignUp Test Case.");
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
