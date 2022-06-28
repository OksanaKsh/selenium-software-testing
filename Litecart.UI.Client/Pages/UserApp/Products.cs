using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductInfo : LitecartBasePage
    {
        public IWebElement ProductName;
        public IWebElement RegularPrice;
        public IWebElement CampaignPrice;
        public List<ProductInfo> Products;
        public IList<IWebElement> ListOfProductElementsInSelectedBlock =>
            DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));

        public By ProductNameLocator => By.XPath(".//div[@class ='name']");
        public By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        public By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");

        public void IdentifyProductInfo(IList<IWebElement> listOfProductElementsInSelectedBlock)
        {
            Products = new List<ProductInfo>();

            for (int i = 0; i <listOfProductElementsInSelectedBlock.Count; i++)
            {
                Products.Add(new ProductInfo()
                {
                    ProductName = ListOfProductElementsInSelectedBlock[i].FindElement(ProductNameLocator),
                    RegularPrice = ListOfProductElementsInSelectedBlock[i].FindElement(RegularPriceLocator),
                    CampaignPrice =ListOfProductElementsInSelectedBlock[i].FindElement(CampaignPriceLocator)
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
