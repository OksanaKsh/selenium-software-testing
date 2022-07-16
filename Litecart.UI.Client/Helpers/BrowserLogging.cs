
using OpenQA.Selenium;

namespace Litecart.UI.Client.Helpers
{
    public static class BrowserLogging
    {
        public static List<LogEntry> GetMessagesInBrowserLogs()
        {
            return DriverFactory.Driver.Manage().Logs.GetLog("browser").ToList();
        }
    }
}
