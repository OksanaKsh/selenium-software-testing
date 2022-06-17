using FirstProject.dto;
using FirstProject.Dto;
using FirstProject.Interfaces;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using OpenQA.Selenium;

namespace FirstProject
{
    public class BaseListProductsBlock 
    {
        public string Name { get; set; }
        public IWebElement Locator { get; set; }
        public CampaignBlockProductInfo CampaignBlockProductInfo => new CampaignBlockProductInfo();
        public ProductDetailsDto ReadInfo(IProductInfo block)
        {
            return new ProductDetailsDto()
            {
                ProductName = block. ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = block.RegularPrice.GetPrice(),
                    Color = block.RegularPrice.GetColor(),
                    Font = block.RegularPrice.GetSize().ToDouble(),
                    IsLineThrough = block.RegularPrice.IsLineThrough()
                },
                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = block.CampaignPrice.GetPrice(),
                    Color = block.CampaignPrice.GetColor(),
                    Font = block.CampaignPrice.GetSize().ToDouble(),
                    IsFontBold = block.CampaignPrice.IsBold(),
                }
            };
        }
    }
}