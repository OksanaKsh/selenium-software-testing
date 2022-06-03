using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using Litecart.UI.Client.Pages.UserApp.dto;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class RegistrationPage: LitecartBasePage
    {
        public IWebDriver driver;

        // Title
        IWebElement Title = DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        // TaxId field
        IWebElement TaxId = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='tax_id']"));

        // Company field
        IWebElement Company = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='company']"));

        // FirstName field
        IWebElement FirstNameInput = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='firstname'"));

        // LastName field
        IWebElement LastNameInput = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='lastname']"));

        // Address1 field
        IWebElement Address1 = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='address1']"));

        // Address2 field
        IWebElement Address2 = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='address1']"));

        // PostCode field
        IWebElement PostCode = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='postcode']"));

        // City field
        IWebElement City = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='city']"));

        // Country field
        //IWebElement Country = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='postcode'"));?? Locator

        // Email field
        IWebElement Email = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));

        // Phone field]
        IWebElement Phone = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='phone']"));

        // Newsletter subscribe field
        IWebElement Subscribe = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='newsletter']"));

        // DesiredPassword field
        IWebElement DesiredPassword = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='password']"));

        // ConfirmedPassword field
        IWebElement ConfirmedPassword = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='confirmed_password']"));

        // Create Account button
        IWebElement CreateAccountButton = DriverFactory.Driver.FindElement(By.CssSelector("input[name ='create_account']"));

        public string GenerateUniqueEmail()
        {
            Random random = new Random();
            return "user" + random.Next(5) + "@gmail.com";
        }

        //public Customer EnterValidDataIntoRegistrationForm()
        //{
        //    return new Customer() 
        //    {








        //}
    }

}