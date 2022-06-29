using System;
using System.Collections;
using System.IO;
using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using NUnit.Framework;

namespace FirstProject
{
    public class DataProviderNewProduct
    {
        public static object[] AddNewProductData = { new object[] { ValidGeneralTabData, ValidInformationTabData, ValidDataTabData } };
        public static IEnumerable ValidGeneralTabData
        {
            get
            {
                yield return new GeneralProductDto()
                {
                    Name = "TestName" + Guid.NewGuid().ToString(),
                    Code = "TestCode",
                    Quantity = 5.6,
                    UploadImages = Path.Combine(TestContext.CurrentContext.WorkDirectory.ToString(), "Files", "testImage.jpg"),
                    DateValidFrom = DateTime.Now,
                    DateValidTo = DateTime.Now.AddDays(30)
                };
            }
        }

        public static IEnumerable ValidInformationTabData
        {
            get
            {
                yield return new InformationProductDto
                {
                    Manufacturer = "ACME Corp.",
                    Supplier = "null",//?
                    Keywords = "TestKeywords",
                    ShortDescription = "TestShortDescription",
                    Description = "TestDescription",
                    HeadTitle = "TestHeadtitle",
                    MetaDescription = "TestMetaDescription"
                };
            }
        }

        public static IEnumerable ValidDataTabData
        {
            get
            {
                yield return new DataProductDto
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
                };
            }
        }
    }
}
