using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class HomePageLitecart
    {
        public IWebDriver driver;

        public HomePageLitecart(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Find list of Images withDuck
        [FindsBy(How = How.CssSelector, Using = ".image-wrapper")]
        public IList<IWebElement> ListOfImages { get; set; }

        //locator of Sticker Inside image with Duck
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

