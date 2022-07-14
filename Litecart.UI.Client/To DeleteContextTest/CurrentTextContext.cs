using System.Collections.Concurrent;
using OpenQA.Selenium;

namespace Litecart.UI.Client.TestContext
{
    public class CurrentTextContext
    {
        //public static readonly ConcurrentDictionary<string, TestContextDataContainer> TestContextData = new();

        //public static TestContextDataContainer Data =>
        //    TestContextData.GetOrAdd(NUnit.Framework.TestContext.CurrentContext.Test.FullName,
        //        new TestContextDataContainer());
        public static readonly ConcurrentDictionary<string, IWebElement> TestContextData = new();

        //public static TestContextDataContainer Data =>
        //    TestContextData.GetOrAdd(NUnit.Framework.TestContext.CurrentContext.Test.FullName,
        //        new TestContextDataContainer());
    }
}
