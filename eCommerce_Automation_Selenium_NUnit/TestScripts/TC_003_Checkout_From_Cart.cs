using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace eCommerce_Automation_Selenium_NUnit
{
    [TestFixture]
    public class TC_003_Checkout_From_Cart : BaseClass
    {
        [SetUp]
        public void TestSetup()
        {
            //This is a call to a method for trello Login.
            if (objGeneric.UserLogin_AutomationPractice(ProjectConfiguration.Selenium_Email, ProjectConfiguration.Selenium_Password))
            {
                ReportLogger.Pass("User has logged in successfully in Automation Practice");
            }
            else
            {
                ReportLogger.Fail("User has NOT logged in successfully in Automation Practice");
                Assert.Fail("User Login Failed");
            }
        }

        [Category("Regression")]
        [Test, Order(3)]
        public void TC003_Checkout_From_Cart()
        {
            List<bool> Status = new List<bool>();

            try
            {
                ReportLogger.Info("Starting test script to add Product in cart and Remove Product from Cart.");
               
                if (objSearchProduct.searchProduct(JSONDataReader.Search_Result_Count))
                {
                    ReportLogger.Pass("Products are listed as per Search Criteria.");
                    Status.Add(true);
                }
                else
                {
                    ReportLogger.Fail("Products are NOT listed as per Search Criteria.");
                    Status.Add(false);
                }

                if (objAddRemoveCart.addToCart(JSONDataReader.Text_CheckOut_Page, JSONDataReader.Price))
                {
                    ReportLogger.Pass("Product is successfully added to Cart.");
                    Status.Add(true);
                }
                else
                {
                    ReportLogger.Fail("Product is not successfully added to Cart.");
                    Status.Add(false);
                }

                if (objCheckoutFromCart.checkOutCart(JSONDataReader.Text_Order_Confirmation))
                {
                    ReportLogger.Pass("Order for Product is placed successfully.");
                    Status.Add(true);
                }
                else
                {
                    ReportLogger.Fail("Order for Product is NOT placed successfully.");
                    Status.Add(false);
                }

                if (Status.Contains(false))
                {
                    ReportLogger.Fail("Failure in Test Case TC003_Checkout_From_Cart");
                    Assert.Fail("Order is NOT placed successfully.");
                }
                else
                {
                    ReportLogger.Pass("TC003_Checkout_From_Cart is Executed Successfully.");
                }

            }
            catch (Exception e)
            {
                ReportLogger.Fail(e.Message + "Exception in TC003_Checkout_From_Cart Test Case.");
                objSeleniumMethodLib.ScreenShotonFailure();
                Assert.Fail(e.Message + "Exception in TC003_Checkout_From_Cart Test Case. ");
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
