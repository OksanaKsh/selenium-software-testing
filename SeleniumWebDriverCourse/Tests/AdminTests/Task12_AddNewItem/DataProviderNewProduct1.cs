﻿using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FirstProject
{
    public class DataProviderNewProductTest1
    {
        public static IEnumerable<TestCaseData> AddNewProductData
        {
            get
            {
                yield return new TestCaseData(new GeneralProductDto()
                {
                    Name = "TestName" + Guid.NewGuid().ToString(),
                    Code = "TestCode",
                    Quantity = 5.6,
                    UploadImages = null,
                    //UploadImages = "C:\\Users\\kshan\\OneDrive\\Desktop",
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
                   HeadTitle = "TestHeadtitle",
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
                });
            }
        }
    }
}

