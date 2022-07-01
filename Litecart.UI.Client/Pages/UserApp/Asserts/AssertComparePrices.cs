using Litecart.UI.Client.Pages.UserApp.dto;
using NUnit.Framework;

namespace Litecart.UI.Client.Pages.UserApp.Asserts
{
    public class AssertComparePrices
    {

        public static void VerifyThatRegularPriceIsGrey(ProductDetailsDto productPage1, ProductDetailsDto productPage2)
        {
            Assert.That(productPage1.RegularPrice.Color.R, Is.EqualTo(productPage1.RegularPrice.Color.G));
            Assert.That(productPage1.RegularPrice.Color.G, Is.EqualTo(productPage1.RegularPrice.Color.B));

            Assert.That(productPage2.RegularPrice.Color.R, Is.EqualTo(productPage2.RegularPrice.Color.G));
            Assert.That(productPage2.RegularPrice.Color.G, Is.EqualTo(productPage2.RegularPrice.Color.B));
        }

        public static void VerifyThatRegularPriceIsLineThrough(ProductDetailsDto productPage1, ProductDetailsDto productPage2)
        {
            Assert.That(productPage1.RegularPrice.IsLineThrough, Is.True);
            Assert.That(productPage2.RegularPrice.IsLineThrough, Is.True);
        }

        public static void VerifyThatCampaignPriceIsRed(ProductDetailsDto productPage1, ProductDetailsDto productPage2)
        {
            Assert.That(productPage1.CampaignPrice.Color.B, Is.EqualTo(0));
            Assert.That(productPage1.CampaignPrice.Color.G, Is.EqualTo(0));

            Assert.That(productPage2.CampaignPrice.Color.B, Is.EqualTo(0));
            Assert.That(productPage2.CampaignPrice.Color.G, Is.EqualTo(0));
        }

        public static void VerifyThatRegularPriceIsBold(ProductDetailsDto productPage1, ProductDetailsDto productPage2)
        {
            Assert.That(productPage1.CampaignPrice.IsFontBold, Is.True);
            Assert.That(productPage2.CampaignPrice.IsFontBold, Is.True);
        }

        public static void VerifyThatCampaignPriceFontIsGreaterThanRegularPriceFont(ProductDetailsDto productPage1, ProductDetailsDto productPage2)
        {
            Assert.That(productPage1.CampaignPrice.Font - productPage1.RegularPrice.Font, Is.GreaterThan(0));
            Assert.That(productPage2.CampaignPrice.Font - productPage2.RegularPrice.Font, Is.GreaterThan(0));
        }
    }
}
