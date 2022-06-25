using FirstProject.dto;
using FirstProject.Dto;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using OpenQA.Selenium;

namespace FirstProject
{
    public class ProductInfo : LitecartBasePage
    {
        public IWebElement ProductName;
        public IWebElement RegularPrice;
        public IWebElement CampaignPrice;

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
