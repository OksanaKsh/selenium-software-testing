using System;
using System.Collections;

namespace LitecartUITests
{
    public class DataProvider
    {
        public static string EmailValue;
        public static string CurrentEmailValue = EmailValue;
        public static string PasswordValue { get; set; } = "qwerty";
        public static string GenerateUniqueEmail()
        {
           // currentEmailValue = "user" + Guid.NewGuid() + "@gmail.com";
           EmailValue = "user" + Guid.NewGuid() + "@gmail.com";
            return EmailValue;
        }
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
                    Email = GenerateUniqueEmail(),
                    Password = PasswordValue
                };
            }
        }
    }
}
