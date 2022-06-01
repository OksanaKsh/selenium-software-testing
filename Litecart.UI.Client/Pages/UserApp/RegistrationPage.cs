using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using Litecart.UI.Client.Pages.UserApp.dto;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class RegistrationPage
    {
        public IWebDriver driver;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            //this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        // Title
        IWebElement Title = DriverFactory.driver.FindElement(By.CssSelector("h1.title"));

        // TaxId field
        IWebElement TaxId = DriverFactory.driver.FindElement(By.CssSelector("input[name ='tax_id']"));

        // Company field
        IWebElement Company = DriverFactory.driver.FindElement(By.CssSelector("input[name ='company']"));

        // FirstName field
        IWebElement FirstNameInput = DriverFactory.driver.FindElement(By.CssSelector("input[name ='firstname'"));

        // LastName field
        IWebElement LastNameInput = DriverFactory.driver.FindElement(By.CssSelector("input[name ='lastname']"));

        // Address1 field
        IWebElement Address1 = DriverFactory.driver.FindElement(By.CssSelector("input[name ='address1']"));

        // Address2 field
        IWebElement Address2 = DriverFactory.driver.FindElement(By.CssSelector("input[name ='address1']"));

        // PostCode field
        IWebElement PostCode = DriverFactory.driver.FindElement(By.CssSelector("input[name ='postcode']"));

        // City field
        IWebElement City = DriverFactory.driver.FindElement(By.CssSelector("input[name ='city']"));

        // Country field
        //IWebElement Country = DriverFactory.driver.FindElement(By.CssSelector("input[name ='postcode'"));?? Locator

        // Email field
        IWebElement Email = DriverFactory.driver.FindElement(By.CssSelector("input[name ='email']"));

        // Phone field]
        IWebElement Phone = DriverFactory.driver.FindElement(By.CssSelector("input[name ='phone']"));

        // Newsletter subscribe field
        IWebElement Subscribe = DriverFactory.driver.FindElement(By.CssSelector("input[name ='newsletter']"));

        // DesiredPassword field
        IWebElement DesiredPassword = DriverFactory.driver.FindElement(By.CssSelector("input[name ='password']"));

        // ConfirmedPassword field
        IWebElement ConfirmedPassword = DriverFactory.driver.FindElement(By.CssSelector("input[name ='confirmed_password']"));

        // Create Account button
        IWebElement CreateAccountButton = DriverFactory.driver.FindElement(By.CssSelector("input[name ='create_account']"));

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