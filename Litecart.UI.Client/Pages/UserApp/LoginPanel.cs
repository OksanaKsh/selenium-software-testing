using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class LoginPanel
    {
        IWebElement Email => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));
        IWebElement Password => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='password']"));
        IWebElement LoginButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name ='login']"));

        public void LogIn(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
