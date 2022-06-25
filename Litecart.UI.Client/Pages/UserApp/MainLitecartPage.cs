namespace FirstProject
{
    public class MainLitecartPage : LitecartBasePage
    {
        public BaseListProductsBlock CampaignBlock => new BaseListProductsBlock()
        {
            Locator = "div[id='box-campaigns'][class='box']",
        };
        public BaseListProductsBlock MostPopularBlock => new BaseListProductsBlock()
        {
            Locator = "div[id='box-most-popular'][class='box']",
        };
    }
}
