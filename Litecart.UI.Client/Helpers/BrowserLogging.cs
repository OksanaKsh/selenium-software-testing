
using OpenQA.Selenium;

namespace Litecart.UI.Client.Helpers
{
    public static class BrowserLogging
    {
        public static void VerifyMessagesAppearanceInBrowerLogs()
        {
            Console.WriteLine(DriverFactory.Driver.Manage().Logs.GetLog("browser").Count != 0
                ? "Logs appeared"
                : "No logs were written");
            //foreach (var logEntry in DriverFactory.Driver.Manage().Logs.GetLog("browser"))
            //{
            //    Console.WriteLine("Logs in Browser are next:" + " " + logEntry);
            //}
        }
    }
}
