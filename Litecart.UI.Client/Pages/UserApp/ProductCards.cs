using OpenQA.Selenium;

namespace FirstProject
{
    public class ProductCards
    {
        public List<ProductInfo> Products;

        public IWebElement Block;

        public IList<IWebElement> ListOfProductElementsInSelectedBlock;
        //public IList<IWebElement> ListOfProductElementsInSelectedBlock =>
        //    DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));
        public IList<IWebElement> IdentifyListOfProductElementsInSelectedBlock(BaseListProductsBlock block)
        {
            Block = DriverFactory.Driver.FindElement(By.CssSelector(block.Locator));

            ListOfProductElementsInSelectedBlock = Block.FindElements(By.XPath(".//li[@class='product column shadow hover-light']"));

            return ListOfProductElementsInSelectedBlock;
        }
        //public  IWebElement Block => DriverFactory.Driver.FindElements(By.CssSelector(Locator));
        //public IList<IWebElement> ListOfProductElementsInSelectedBlock =>
        //    Block.FindElements(By.XPath(".//li[@class='product']"));

        public By ProductNameLocator => By.XPath(".//div[@class ='name']");
        public By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        public By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");

        public List<ProductInfo> IdentifyProductInfo(BaseListProductsBlock block)
        {
            IdentifyListOfProductElementsInSelectedBlock(block);

            Products = new List<ProductInfo>();

            for (int i = 0; i < ListOfProductElementsInSelectedBlock.Count; i++)
            {
                Products.Add(new ProductInfo()
                {
                    ProductName = ListOfProductElementsInSelectedBlock[i].FindElement(ProductNameLocator),
                    RegularPrice = ListOfProductElementsInSelectedBlock[i].FindElement(RegularPriceLocator),
                    CampaignPrice = ListOfProductElementsInSelectedBlock[i].FindElement(CampaignPriceLocator)
                });
            }

            return Products;
        }
    }
}
