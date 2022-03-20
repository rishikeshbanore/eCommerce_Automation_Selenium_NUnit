using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace eCommerce_Automation_Selenium_NUnit
{
    [TestFixture]
    public class TC_002_Add_Remove_Cart : BaseClass
    {
        [SetUp]
        public void TestSetup()
        {
            //This is a call to a method for trello Login.
            if (objGeneric.UserLogin_AutomationPractice(ProjectConfiguration.Selenium_Email, ProjectConfiguration.Selenium_Password))
            {
                ReportLogger.Pass("User has logged in successfully in Automation Practice site.");
            }
            else
            {
                ReportLogger.Fail("User has NOT logged in successfully in Automation Practice site.");
                Assert.Fail("User Login Failed");
            }
        }

        [Category("Regression")]
        [Test, Order(2)]
        public void TC002_Add_Remove_Cart()
        {
            List<bool> Status = new List<bool>();

            try
            {
                ReportLogger.Info("Starting test script to add Product in cart and Remove Product from Cart.");

                //This is call to the method which will set Search Criteria and check if matching results are retrived.
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

                //This is the call to method which will add product to cart.
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

                //This is call to method which will remove product from the cart.
                if (objAddRemoveCart.deleteFromCart(JSONDataReader.Text_Product_Delete))
                {
                    ReportLogger.Pass("Product is successfully deleted from the Cart.");
                    Status.Add(true);
                }
                else
                {
                    ReportLogger.Fail("Product is NOT successfully  deleted from the Cart.");
                    Status.Add(false);
                }

                if (Status.Contains(false))
                {
                    ReportLogger.Fail("Failure in Test Case TC002_Add_Remove_Cart");
                    Assert.Fail("Add to Cart and Remove from cart operation was not successful.");
                }
                else
                {
                    ReportLogger.Pass("TC002_Add_Remove_Cart is Executed Successfully.");
                }

            }
            catch (Exception e)
            {
                ReportLogger.Fail(e.Message + "Exception in TC_002_Add_Remove_Cart Test Case.");
                objSeleniumMethodLib.ScreenShotonFailure();
                Assert.Fail(e.Message + "Exception in TC_002_Add_Remove_Cart Test Case. ");
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
