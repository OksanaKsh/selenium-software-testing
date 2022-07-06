using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litecart.UI.Client.Helpers
{
    public static class BrowserLogging
    {
        public static void VerifyMessagesAppearanceInBrowerLogs()
        {
            foreach (var logEntry in DriverFactory.Driver.Manage().Logs.GetLog("browser"))
            {
                Console.WriteLine("Logs in Browser are next:" + " " + logEntry);
            }
        }
    }
}
