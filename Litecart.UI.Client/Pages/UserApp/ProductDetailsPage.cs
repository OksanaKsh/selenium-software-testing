using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Dto;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductDetailsPage
    {
        public IWebDriver driver;

        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Find product name in Campaign Block
        IWebElement NameOfProductDetailedPage = DriverFactory.driver.FindElement(By.CssSelector("h1.title"));
        public IWebElement MyProperty => driver.FindElement(By.CssSelector("h1.title"));
                             

        IWebElement RegularPriceOfProductOnDetailedPage = DriverFactory.driver.FindElement(By.CssSelector(".regular-price"));

        IWebElement CampaignPriceProductOnDetailedPage = DriverFactory.driver.FindElement(By.CssSelector(".campaign-price"));

        // Read Name, Regular and Campaign price on Detailed Product Page
        public  ProductDetailsOnDetailedPageDto ReadInfo()
        {
            return new ProductDetailsOnDetailedPageDto()
            {
                ProductName = NameOfProductDetailedPage.Text,// or .GetAttribute("textContent")
                RegularPrice = RegularPriceOfProductOnDetailedPage.Text,
                RegularPriceColor = ColorHelper.ParseColor(RegularPriceOfProductOnDetailedPage.GetCssValue("color")),
                IsLineThrough = RegularPriceOfProductOnDetailedPage.GetCssValue("text-decoration") != null ? true : false,
                RegularPriceFont = Double.Parse(String.Concat(RegularPriceOfProductOnDetailedPage.GetCssValue("font-size").Reverse().Skip(2).Reverse())),

                CampaignPrice = CampaignPriceProductOnDetailedPage.Text,
                CampaignPriceFont = Double.Parse(String.Concat(CampaignPriceProductOnDetailedPage.GetCssValue("font-size").Reverse().Skip(2).Reverse())),
                CampaignPriceColor = ColorHelper.ParseColor(CampaignPriceProductOnDetailedPage.GetCssValue("color")),
                IsFontBold = CampaignPriceProductOnDetailedPage.GetCssValue("font-weight").Equals("700") ? true : false
            };
        }
    }
}
