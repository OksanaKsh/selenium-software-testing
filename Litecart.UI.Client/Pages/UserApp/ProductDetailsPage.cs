using OpenQA.Selenium;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
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
        IWebElement SizeDropdown => DriverFactory.Driver.FindElement(By.CssSelector("select[name='options[Size]']"));
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
            AddToCardButton.Click();
        }

        public void AddingThreeItemsToCart(Cart cart)
        {
            for (int i = 0; i < 3; i++)
            {
                MainLitecartPage.MostPopularBlock.Products[0].ProductName.Click();
                var initialQuantity = cart.Quantity.Text.ToInt();
                try
                {
                    var selectElement = new SelectElement(SizeDropdown);
                    selectElement.SelectByIndex(1);
                }
                catch (NoSuchElementException e) { }

                AddItemToCart();

                DriverFactory.Wait.Until(ExpectedConditions.TextToBePresentInElement(cart.Quantity, (initialQuantity + 1).ToString()));
                DriverFactory.Driver.Navigate().GoToUrl("http://localhost/litecart/en/");
                DriverFactory.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[id='box-account-login']")));
            }
        }
    }
}
