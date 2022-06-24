using System;
using System.Collections;

namespace FirstProject
{
    public class DataProvider
    {
        public static string EmailValue { get; set; } = GenerateUniqueEmail();
        public static string PasswordValue { get; set; } = "qwerty";
        public static string GenerateUniqueEmail()
        {
            Random random = new Random();
            return "user" + Guid.NewGuid().ToString() + "@gmail.com";
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
                    Email = EmailValue,
                    Password = PasswordValue
                };
            }
        }
    }
}
