using OpenQA.Selenium;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using LitecartUITests.dto;
using LitecartUITests.Dto;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LitecartUITests
{
    public class ProductDetailsPage : LitecartBasePage
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector(".regular-price"));

        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector(".campaign-price"));

        public IWebElement AddToCardButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='add_cart_product']"));
        public IWebElement SizeDropdown => DriverFactory.Driver.FindElement(By.CssSelector("select[name='options[Size]']"));

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
                    IsFontBold = CampaignPrice.IsBold(),
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
                var block = MainLitecartPage.MostPopularBlock;
                var products = block.ProductCards.IdentifyListOfProductElementsInSelectedBlock(block);
                products.First().Click();
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
                DriverFactory.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a[href='http://localhost/litecart/en/create_account']")));
            }
        }
    }
}
