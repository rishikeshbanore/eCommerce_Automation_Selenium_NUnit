using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce_Automation_Selenium_NUnit
{
    public static class ProjectConfiguration
    {
        #region Variable declaration
        public static Dictionary<string, string> GetProjectConfig { get; }
        public static string Selenium_ApplicationName;
        public static string Selenium_Environment;
        public static string Selenium_URL;
        public static string Selenium_Browser;
        public static string Selenium_EmailReport;
        public static string Selenium_ReportWriting;
        public static string Selenium_ReportLocation;
        public static string Selenium_ReportName;
        public static string Selenium_ScreenShotLocation;
        public static string Selenium_Recipient1;
        public static string Selenium_Recipient2;
        public static string Selenium_Recipient3;
        public static string Selenium_Recipient4;
        public static string Selenium_UserName;
        public static string Selenium_Email;
        public static string Selenium_Password;
        #endregion

        // Static constructor
        static ProjectConfiguration()
        {
            // Get the project's assembly path (<Project_Name>\bin\Debug) 
            var Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Read LocalConfig.json
            string projectconfig = System.IO.File.ReadAllText(Path + "\\config\\LocalConfig.json");

            // Serialize & Deserialize JSON using JavaScriptSerializer
            GetProjectConfig =  JsonConvert.DeserializeObject<Dictionary<string, string>>(projectconfig);

            Selenium_ApplicationName = GetProjectConfig["Selenium_ApplicationName"];
            Selenium_Environment = GetProjectConfig["Selenium_Environment"];
            Selenium_URL = GetProjectConfig["Selenium_URL"];
            Selenium_Browser = GetProjectConfig["Selenium_Browser"];
            Selenium_EmailReport = GetProjectConfig["Selenium_EmailReport"];
            Selenium_ReportWriting = GetProjectConfig["Selenium_ReportWriting"];
            Selenium_ReportLocation = GetExtentReportPath(GetProjectConfig["Selenium_ReportLocation"]);
            Selenium_ScreenShotLocation = GetScreenshotPath(GetProjectConfig["Selenium_ScreenShotLocation"]);
            Selenium_ReportName = GetProjectConfig["Selenium_ReportName"];
            Selenium_Recipient1 = GetProjectConfig["Selenium_Recipient1"];
            Selenium_Recipient2 = GetProjectConfig["Selenium_Recipient2"];
            Selenium_Recipient3 = GetProjectConfig["Selenium_Recipient3"];
            Selenium_Recipient4 = GetProjectConfig["Selenium_Recipient4"];
            Selenium_UserName = GetProjectConfig["Selenium_UserName"];
            Selenium_Password = GetProjectConfig["Selenium_Password"];
            Selenium_Email = GetProjectConfig["Selenium_Email"];
        }

        // Get Chrome,IE,Edge drivers path
        public static string GetDriverPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        // Get Extent Report path
        private static string GetExtentReportPath(string reportLocation)
        {
            var extentReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportLocation);
            if (Directory.Exists(extentReportPath) == false)
            {
                Directory.CreateDirectory(extentReportPath);
            }
            return extentReportPath;
        }

        // Get Screenshot folder path
        public static string GetScreenshotPath(string screenShotLocation)
        {
            var screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, screenShotLocation);
            if (Directory.Exists(screenShotPath) == false)
            {
                Directory.CreateDirectory(screenShotPath);
            }
            return screenShotPath;
        }
    }
}
