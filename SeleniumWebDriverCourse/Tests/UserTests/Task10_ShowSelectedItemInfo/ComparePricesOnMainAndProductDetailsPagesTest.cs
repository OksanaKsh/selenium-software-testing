//Сделайте сценарий, который проверяет, что при клике на товар открывается правильная страница
//товара в учебном приложении litecart.

//Более точно, нужно открыть главную страницу, выбрать первый товар в блоке Campaigns
//и проверить следующее:

//а) на главной странице и на странице товара совпадает текст названия товара
//б) на главной странице и на странице товара совпадают цены (обычная и акционная)
//в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой,
//у которого в RGBa представлении одинаковые значения для каналов R, G и B)
//г) акционная жирная и красная (можно считать, что "красный" цвет это такой, у которого в RGBa
//представлении каналы G и B имеют нулевые значения)
//(цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут
//не совпадать)
//д) акционная цена крупнее, чем обычная (это тоже надо проверить на каждой странице независимо)


using System.Linq;
using FirstProject.Asserts;
using Litecart.UI.Client.Helpers.ErrorMessages;
using NUnit.Framework;

namespace FirstProject
{
    public class ComparePricesOnMainAndProductDetailsPagesTest: UserBaseUiTest
    {
        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyDataOnMainPageAndDetailedProductPageAreSame()
        {
            // Arrange
            var firstProductOnCampaignBlock = Site.MainLitecartPage.CampaignBlock.ProductCards.IdentifyProductInfo().First();
           
            // Act 
            var productInfoOnCampaignBlock = firstProductOnCampaignBlock.ReadInfo();
            firstProductOnCampaignBlock.ProductName.Click();

            ProductDetailsPage productDetailsPage = Site.ProductDetailsPage;
            var detailedProductPageInfo = productDetailsPage.ReadInfo();    

            //Assert
            Assert.That(productInfoOnCampaignBlock.ProductName, Is.EqualTo(detailedProductPageInfo.ProductName), ProductDetailsErrors.ProductNameError);            
            Assert.That(productInfoOnCampaignBlock.RegularPrice.Amount, Is.EqualTo(detailedProductPageInfo.RegularPrice.Amount),ProductDetailsErrors.PriceError);
            AssertComparePrices.VerifyThatRegularPriceIsLineThrough(productInfoOnCampaignBlock, detailedProductPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsGrey(productInfoOnCampaignBlock, detailedProductPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsBold(productInfoOnCampaignBlock, detailedProductPageInfo);
            AssertComparePrices.VerifyThatCampaignPriceIsRed(productInfoOnCampaignBlock, detailedProductPageInfo);
            AssertComparePrices.VerifyThatCampaignPriceFontIsGreaterThanRegularPriceFont(productInfoOnCampaignBlock, detailedProductPageInfo);        
        }
    }
}