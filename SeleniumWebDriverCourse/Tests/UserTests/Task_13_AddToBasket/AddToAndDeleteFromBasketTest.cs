using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FirstProject
{
    public class AddToAndDeleteFromBasketTest: UserBaseUiTest
    {
        [Test]
        //[TestCaseSource(typeof(DataProvider), nameof(DataProvider.ValidCustomers))]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyAddingAndDeletingItemsToBasket(CustomerDto customer)
        {
            // Arrange
            DriverFactory.Driver.Navigate().GoToUrl(RegistrationPage.UrlCreateAccount);
            RegistrationPage registrationPage = this.Site.RegistrationPage;

            // Act && Arrange
            registrationPage.FillRegistrationForm(customer);
            DriverFactory.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href='http://localhost/litecart/en/logout'")));
            registrationPage.Logout();
            LoginPanel.LogIn(DataProvider.EmailValue, DataProvider.PasswordValue);
            registrationPage.Logout();
        }
    }
}
