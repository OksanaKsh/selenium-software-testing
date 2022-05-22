using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Litecart.UI.Client.Pages.AdminApp
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
    }

        [FindsBy(How = How.CssSelector, Using = "li#app-")]
        public IList<IWebElement> CategoryList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id^='doc-']")]
        public IList<IWebElement> SubCategoryList { get; set; }
        

        // Move along category and theirs subCategories and create a list of Headers of appeared pages
        public List<string> MoveAlongListAndClickEveryElement(IList<IWebElement> listOfElements)
        {
            List<string> listOfHeaders = new List<string>();
            CategoryElementPage categoryPage = new CategoryElementPage(driver);
            PageFactory.InitElements(driver, categoryPage);
            for (int i = 0; i < listOfElements.Count; i++)
            {
                var element = listOfElements[i];
                element.Click();

                //Add headers to the list of headers
                listOfHeaders.Add(categoryPage.Header.Text);

                for (int j = 0; j < SubCategoryList.Count; j++)
                {
                    var subCategoryElement = SubCategoryList[j];
                    subCategoryElement.Click();
                    
                    //Add headers to the list of headers
                    listOfHeaders.Add(categoryPage.Header.Text);
                }
            }
            return listOfHeaders;   
        }
    }
}
