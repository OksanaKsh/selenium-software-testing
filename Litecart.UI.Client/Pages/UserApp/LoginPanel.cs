using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
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
