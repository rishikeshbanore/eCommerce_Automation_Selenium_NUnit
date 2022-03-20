using System;
using System.IO;
using Newtonsoft.Json;

namespace eCommerce_Automation_Selenium_NUnit
{
    public static class JSONDataReader
    {
        #region TestData_Files_Variable_declaration

        public static TestData_eCommerce TestData { get; }

        //public static string SourceName;
        public static string Attachment1;
        public static string Attachment2;
        public static string Text_HomePage_Verification;
        public static string Text_Task_Title;
        public static string Text_List_Title_1;
        public static string Text_List_Title_2;
        public static string Text_List_Title_3;
        public static string Text_List_Title_4;
        public static string Text_Edit_Card;
        public static string Text_Board_Title;
        public static string Country;
        public static string State;
        public static string Home_Page_Title;
        public static string Search_Result_Count;
        public static string Text_CheckOut_Page;
        public static string Price;
        public static string Text_Product_Delete;
        public static string Text_Order_Confirmation;

        #endregion TestData_Files_Variable_declaration

        // Static constructor for the class
        static JSONDataReader()
        {
            // Get the project's assembly path (<Project_Name>\bin\Debug) 
            var assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //Read Test Data file
            string ReadTestData = System.IO.File.ReadAllText(assemblyPath + "\\TestData\\TestData_eCommerce.json");

            //De serelize the Test Data File
            TestData = JsonConvert.DeserializeObject<TestData_eCommerce>(ReadTestData);

            #region Get_Test_Data_Files_Variables

            Attachment1 = TestData.Attachment1;
            Attachment2 = TestData.Attachment2;
            Text_HomePage_Verification = TestData.Text_HomePage_Verification;
            Text_Board_Title = TestData.Text_Board_Title;
            Text_Task_Title = TestData.Text_Task_Title;
            Text_List_Title_1 = TestData.Text_List_Title_1;
            Text_List_Title_2 = TestData.Text_List_Title_2;
            Text_List_Title_3 = TestData.Text_List_Title_3;
            Text_List_Title_4 = TestData.Text_List_Title_4;
            Text_Edit_Card = TestData.Text_Edit_Card;
            Country = TestData.Country;
            State = TestData.State;
            Home_Page_Title = TestData.Home_Page_Title;
            Search_Result_Count = TestData.Search_Result_Count;
            Text_CheckOut_Page = TestData.Text_CheckOut_Page;
            Price = TestData.Price;
            Text_Product_Delete = TestData.Text_Product_Delete;
            Text_Order_Confirmation = TestData.Text_Order_Confirmation;

            #endregion Get_Test_Data_Files_Variables

            //  updates the document path with local config.

            if (TestData.Equals("Attachment1"))
            {
                Attachment1 = GetTestDataPath(TestData.Attachment1);
            }

            if (TestData.Equals("Attachment2"))
            {
                Attachment2 = GetTestDataPath(TestData.Attachment2);
            }
        }

        private static string GetTestDataPath(string testDataFile)
        {
            //  pull testdata from testdata folder (in bin)
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"TestData\{testDataFile}");

            return fullPath;
        }
    }
}
