using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Pages.UserApp.Dto;
using Litecart.UI.Client.Pages.UserApp.Interfaces;
using NUnit.Framework;

namespace Litecart.UI.Client.Pages.UserApp.Asserts
{
    public class AssertComparePrices
    {
        public static void VerifyThatRegularPriceIsGrey(ProductDetailsDto productPage)
        {
            if (productPage.RegularPrice.Color.R == productPage.RegularPrice.Color.G
                && productPage.RegularPrice.Color.G == productPage.RegularPrice.Color.B);
        }
        public static void VerifyThatRegularPriceIsLineThrough(ProductDetailsDto productPage)
        {
          if(productPage.RegularPrice.IsLineThrough);
        }
        
        public static void VerifyThatCampaignPriceIsRed(ProductDetailsDto productPage)
        {
            if (productPage.CampaignPrice.Color.B == productPage.CampaignPrice.Color.G
                && productPage.RegularPrice.Color.G == 0);
        }
        public static void VerifyThatRegularPriceIsBold(ProductDetailsDto productPage)
        {
          if (productPage.CampaignPrice.IsFontBold);
        }

        public static void VerifyThatCampaignPriceFontIsGreaterThanRegularPriceFont(ProductDetailsDto productPage)
        {
            if (productPage.CampaignPrice.Font - productPage.RegularPrice.Font > 0) ;
        }
    }
}
