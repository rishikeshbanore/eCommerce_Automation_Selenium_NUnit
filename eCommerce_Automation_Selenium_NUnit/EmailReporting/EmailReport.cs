using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

namespace eCommerce_Automation_Selenium_NUnit
{
    public class EmailReport
    {
        public void sendEmail(string Recepient_1, string Recepient_2, string Recepient_3, string Recepient_4)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(""); // Configure email client specific to organisation
            mail.From = new MailAddress(""); //Configure email sending generic address

            mail.To.Add(Recepient_1);
            mail.To.Add(Recepient_2);
            mail.To.Add(Recepient_3);
            mail.To.Add(Recepient_4);

            mail.Subject = "'UI_Automation_Trello' Test Automation Execution Report";
            mail.Body = "Dear Trello Test Team, \n \n Please find attached UI_Automation_Trello test automation execution Report. This report is triggered becuase there is/are test case(s) for which automated execution has failed. \n \n \n Best Regards, \n SQA Team";

            Attachment attachment;
            attachment = new Attachment(ExtentReportManager.GetFilePath());
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 25;
            SmtpServer.Send(mail);
        }
    }
}
