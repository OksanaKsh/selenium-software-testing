using OpenQA.Selenium;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using Litecart.UI.Client.Pages.UserApp.dto;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductDetailsPage : LitecartBasePage
    {
        IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector(".regular-price"));

        IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector(".campaign-price"));
        IWebElement AddToCardButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='add_cart_product']"));
        public IWebElement SizeDropdownElement => DriverFactory.Driver.FindElement(By.CssSelector("select[name='options[Size]']"));
        public By SizeDropdown => By.CssSelector("select[name='options[Size]']");
        public ProductDetailsDto ReadInfo()
        {
            return new ProductDetailsDto()
            {
                ProductName = ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = RegularPrice.GetPrice(),
                    Color = RegularPrice.GetColor(),
                    Font = RegularPrice.GetSize().ToDouble(),
                    IsLineThrough = RegularPrice.IsLineThrough()
                },
                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = CampaignPrice.GetPrice(),
                    Color = CampaignPrice.GetColor(),
                    Font = CampaignPrice.GetSize().ToDouble(),
                    IsFontBold =CampaignPrice.IsBold(),
                }
            };
        }
        public void AddItemToCart()
        {
            var cart = new Cart();
            SelectSizeIfPresent();
            AddToCardButton.Click();
            cart.VerifyItemWasAddedToCart();
        }

        public void SelectSizeIfPresent()
        {
            if (DriverFactory.Driver.IsElementExists(SizeDropdown))
            {
                new SelectElement(SizeDropdownElement).SelectByIndex(1);
            }
        }

        public void NavigateToMainPage()
        {
            DriverFactory.Driver.Navigate().GoToUrl(UrlUserPage);
            DriverFactory.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[id='box-account-login']")));
        }
    }
}
