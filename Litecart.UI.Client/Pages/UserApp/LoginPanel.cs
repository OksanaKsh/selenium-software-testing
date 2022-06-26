using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitecartUITests
{
    public class LoginPanel
    {
        static IWebElement Email => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));
        static IWebElement Password => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='password']"));
        static IWebElement LoginButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name ='login']"));

        public static void LogIn(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
