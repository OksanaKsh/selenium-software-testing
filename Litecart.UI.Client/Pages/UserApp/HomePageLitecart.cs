using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class HomePageLitecart
    {
        IWebDriver driver;

        public HomePageLitecart(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = ".image-wrapper")]
        public IList<IWebElement> ListOfImages { get; set; }

        By locatorOfSticker = By.CssSelector("[class^='sticker']");

        // FindText for every sticker Image and write it to the list
        public List<string> FindTextOfStickersForEveryImage()
        {
            List<string> textOfStickers = new List<string>();

            foreach (IWebElement item in ListOfImages)
            {
                var sticker = item.FindElement(locatorOfSticker);
                textOfStickers.Add(sticker.Text);
            }
            return textOfStickers;
        }
    }
}

