using Litecart.UI.Client.Pages.UserApp.dto;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class RegistrationPage : LitecartBasePage
    {

        public static string UrlCreateAccount = "http://localhost/litecart/en/create_account";

        public static IWebElement LogoutLink => DriverFactory.Driver.FindElement(By.CssSelector("a[href='http://localhost/litecart/en/logout'"));

        IWebElement Title => DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        IWebElement TaxIdInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='tax_id']"));

        IWebElement CompanyInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='company']"));

        IWebElement FirstNameInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='firstname'"));

        IWebElement LastNameInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='lastname']"));

        IWebElement Address1Input => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='address1']"));

        IWebElement Address2Input => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='address1']"));

        IWebElement PostcodeInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='postcode']"));

        IWebElement CityInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='city']"));

        IWebElement CountryInput => DriverFactory.Driver.FindElement(By.CssSelector("span[class ='selection'"));

        IWebElement EmailInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='email']"));

        IWebElement PhoneInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='phone']"));

        IWebElement Subscribe => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='newsletter']"));

        IWebElement PasswordInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='password']"));

        IWebElement ConfirmedPasswordInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name ='confirmed_password']"));

        IWebElement CreateAccountButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name ='create_account']"));

        public void SelectCountry(string country)
        {
            DriverFactory.Driver.FindElement(By.CssSelector("[id ^= select2-country_code]")).Click();
            DriverFactory.Driver.FindElement(By.CssSelector(
                    String.Format(".select2-results__option[id $= {0}]", country))).Click();
        }

        public void SelectZone(string zone)
        {
            string zoneVariable = String.Format("select[name='zone_code'] option[value='{0}']", zone);
            // DriverFactory.Driver.FindElement(By.CssSelector("select[name='zone_code']")).Click();
            ////wait.Until(d => d.FindElement(By.CssSelector("select[name='zone_code']")));
            DriverFactory.Driver.FindElement(By.CssSelector("select[name='zone_code']")).Click();
            DriverFactory.Driver.FindElement(By.CssSelector(
                   String.Format("select[name='zone_code'] option[value='{0}']", zone))).Click();

            //DriverFactory.Wait.Until(d => d.FindElement(By.CssSelector(zoneVariable)));
            //new SelectElement(DriverFactory.Driver.FindElement(By.CssSelector("select[name=zone_code]"))).SelectByValue(zone);
        }

        public void FillRegistrationForm(CustomerDto customer)
        {
            FirstNameInput.SendKeys(customer.Firstname);
            LastNameInput.SendKeys(customer.Lastname);
            Address1Input.SendKeys(customer.Address);
            PostcodeInput.SendKeys(customer.Postcode);
            CityInput.SendKeys(customer.City);
            SelectCountry(customer.Country);
            Thread.Sleep(2000);
            SelectZone(customer.Zone);
            EmailInput.SendKeys(customer.Email);
            PhoneInput.SendKeys(customer.Phone);
            PasswordInput.SendKeys(customer.Password);
            ConfirmedPasswordInput.SendKeys(customer.Password);
            CreateAccountButton.Click();
        }

        public void Logout()
        {
            LogoutLink.Click();
        }
    }
}