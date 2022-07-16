
using OpenQA.Selenium;

namespace Litecart.UI.Client.Helpers
{
    public static class BrowserLogging
    {
        public static List<LogEntry> VerifyMessagesAppearanceInBrowserLogs()
        {

            return DriverFactory.Driver.Manage().Logs.GetLog("browser").ToList();

            //foreach (var logEntry in DriverFactory.Driver.Manage().Logs.GetLog("browser"))
            //{
            //    Console.WriteLine("Logs in Browser are next:" + " " + logEntry);
            //}
        }
    }
}
