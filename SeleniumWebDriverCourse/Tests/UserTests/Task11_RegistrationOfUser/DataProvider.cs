using System;
using System.Collections;
using Litecart.UI.Client.Pages.UserApp.dto;

namespace SeleniumWebDriverCourse.UserTests
{
    public class DataProvider
    {
        public static string EmailValue = "user" + Guid.NewGuid() + "@gmail.com";
        public static string PasswordValue { get; set; } = "qwerty";
        public static IEnumerable ValidCustomers
        {

            get
            {
                yield return new CustomerDto()
                {
                    Firstname = "Adam",
                    Lastname = "Smith",
                    Phone = "+0123456789",
                    Address = "Hidden Place",
                    Postcode = "12345",
                    City = "New City",
                    Country = "US",
                    Zone = "KS",
                    Email = EmailValue,
                    Password = PasswordValue
                };
            }
        }
    }
}
