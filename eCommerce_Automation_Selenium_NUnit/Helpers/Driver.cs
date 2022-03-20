using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using System;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class Driver
    {
        public IWebDriver driver = null;
        //ChromeOptions Options = new ChromeOptions();

        public Driver()
        {
            String Browser = ProjectConfiguration.Selenium_Browser;
            String URL = ProjectConfiguration.Selenium_URL;
            try
            {
                if (driver == null)
                {
                    switch (Browser.ToLower())
                    {
                        case "chrome":

                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                            driver = new ChromeDriver();
                            break;

                        case "edge":

                            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                            EdgeOptions edgeOptions = new EdgeOptions() { UseChromium = true };
                            driver = new EdgeDriver(edgeOptions);

                            break;
                    }
                    driver.Navigate().GoToUrl(URL);
                    driver.Manage().Window.Maximize();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Driver instance is not null. Close all the drivers and try again" + e.Message);
            }
        }
    }

}


