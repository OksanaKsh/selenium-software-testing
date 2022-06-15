using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class LoginPanel
    {
        static IWebElement Email => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));
        static IWebElement Password => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));
        static IWebElement LoginButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name ='email']"));

        public static void LogIn(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
