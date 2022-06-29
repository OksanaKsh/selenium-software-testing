using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using Litecart.UI.Client.Pages.UserApp.dto;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductInfo : LitecartBasePage
    {
        public IWebElement ProductName;
        public IWebElement RegularPrice;
        public IWebElement CampaignPrice;

        private List<ProductInfo> _products = new List<ProductInfo>();

        public List<ProductInfo> Products
        {
            get
            {
                foreach (var t in ListOfProductElementsInSelectedBlock)
                {
                    _products.Add(new ProductInfo()
                    {
                        ProductName = t.FindElement(ProductNameLocator),
                        RegularPrice = t.FindElement(RegularPriceLocator),
                        CampaignPrice = t.FindElement(CampaignPriceLocator)
                    });
                };
                return _products;
            }
        }

        public IList<IWebElement> ListOfProductElementsInSelectedBlock =>
            DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));

        public By ProductNameLocator => By.XPath(".//div[@class ='name']");
        public By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        public By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");

        public void IdentifyProductInfo()
        {
            foreach (var t in ListOfProductElementsInSelectedBlock)
            {
                Products.Add(new ProductInfo()
                {
                    ProductName = t.FindElement(ProductNameLocator),
                    RegularPrice = t.FindElement(RegularPriceLocator),
                    CampaignPrice = t.FindElement(CampaignPriceLocator)
                });
            }
        }

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
    }
}
