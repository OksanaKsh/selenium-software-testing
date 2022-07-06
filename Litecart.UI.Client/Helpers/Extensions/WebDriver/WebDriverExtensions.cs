using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Helpers.Extensions.WebDriver
{
    public static class WebDriverExtensions
    {
        public static bool IsElementExists(this IWebDriver driver,By by)
        {
            if (driver.FindElements(by).Count!=0)
                return true;
            else return false;
        }
    }
}
