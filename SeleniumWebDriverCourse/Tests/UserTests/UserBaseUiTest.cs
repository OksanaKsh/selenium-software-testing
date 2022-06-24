﻿
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace FirstProject
{
    public class UserBaseUiTest
    {

        public LitecartBasePage Site { get; } = new LitecartBasePage();
      
        [SetUp]
        public void Setup()
        {
            DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/en/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var a = 2;
            }
            DriverFactory.CloseBrowser();
        }
    }
}
