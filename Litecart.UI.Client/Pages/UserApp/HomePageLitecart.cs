using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class HomePageLitecart: LitecartBasePage
    {
        IList<IWebElement> ListOfImages => DriverFactory.Driver.FindElements(By.CssSelector(".image-wrapper"));
        By locatorOfSticker = By.CssSelector("[class^='sticker']");

        //public List<string> FindValuesOfStickersForImages()
        //{
        //    List<string> textOfStickers = new List<string>();

        //    foreach (IWebElement item in ListOfImages)
        //    {
        //        var sticker = item.FindElement(locatorOfSticker);
        //        textOfStickers.Add(sticker.Text);
        //    }
        //    return textOfStickers;
        //}

        public List<string> FindValuesOfStickersForImagesLinq()
        {
            List<string> textOfStickers = ListOfImages.Select(x => x.FindElement(locatorOfSticker).Text).ToList();
            return textOfStickers;
        }

    }
}

