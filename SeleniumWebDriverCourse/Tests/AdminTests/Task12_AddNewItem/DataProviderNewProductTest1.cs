using System;
using System.IO;
using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using NUnit.Framework;


namespace FirstProject
{
    public class DataProviderNewProductTest
    {
        public static object[] AddNewProductData = { new object[]
        {
            new GeneralProductDto()
                {
                    Name = "TestName" + Guid.NewGuid().ToString(),
                    Code = "TestCode",
                    Quantity = 5.6,
                    UploadImages = Path.Combine(TestContext.CurrentContext.WorkDirectory.ToString() ,"Files", "testImage.jpg"),
                    DateValidFrom = DateTime.Now,
                    DateValidTo = DateTime.Now.AddDays(30)
                },

            new InformationProductDto
                {
                    Manufacturer = "ACME Corp.",
                    Supplier = "null",//?
                    Keywords = "TestKeywords",
                    ShortDescription = "TestShortDescription",
                    Description = "TestDescription",
                    HeadTitle = "TestHeadTitle",
                    MetaDescription = "TestMetaDescription"
                },

             new DataProductDto
                {
                    SKU = "TestSKU",
                    GTIN = "https://calendar.google.com/",
                    TARIC = "https://google.com/",
                    Weight = 10.5,
                    WeightMeasures = "g",
                    DimentionWidth = 6.5,
                    DimentionHeight = 7.0,
                    DimentionLength = 8.0,
                    DimentionMeasures = "km",
                    Attributes = "TestAttributes"
                }
        }
    };
    };
}

