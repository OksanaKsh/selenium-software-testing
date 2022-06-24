
//Сделайте сценарий для регистрации нового пользователя в учебном приложении litecart (не в админке, а в клиентской части магазина).

//Сценарий должен состоять из следующих частей:

//1) регистрация новой учётной записи с достаточно уникальным адресом электронной почты (чтобы не конфликтовало с ранее созданными пользователями,
//в том числе при предыдущих запусках того же самого сценария),
//2) выход(logout), потому что после успешной регистрации автоматически происходит вход,
//3) повторный вход в только что созданную учётную запись,
//4) и ещё раз выход.

//В качестве страны выбирайте United States, штат произвольный.
//При этом формат индекса -- пять цифр.

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Проверки можно никакие не делать, только действия -- заполнение полей, нажатия на кнопки и ссылки.
//Если сценарий дошёл до конца, то есть созданный пользователь смог выполнить вход и выход -- значит создание прошло успешно.

//В форме регистрации есть капча, её нужно отключить в админке учебного приложения
//на вкладке Settings -> Security.

using NUnit.Framework;

namespace FirstProject
{
    public class UserRegistrationTests: UserBaseUiTest
    {
        [Test]
        [Repeat(5)]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.ValidCustomers))]      
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyRegistrationNewUser(CustomerDto customer)
        {
            // Arrange
            DriverFactory.Driver.Navigate().GoToUrl(RegistrationPage.UrlCreateAccount);
            RegistrationPage registrationPage = this.Site.RegistrationPage;

            // Act && Arrange
            registrationPage.FillRegistrationForm(customer);    
            registrationPage.Logout();
            LoginPanel.LogIn(DataProvider.EmailValue,DataProvider.PasswordValue);
            registrationPage.Logout();
        }
    }
}
