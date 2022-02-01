using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using OpenCartTests.Tests.Anastasiia_Rokytska;

namespace OpenCartTests.Tests.Bohdan_Khudo
{
    [AllureNUnit]
    [Category("ChangePassword")]
    [TestFixture]
    public class ChangePasswordTest : TestRunner
    {
        protected override string OpenCartURL
        {
            get => "http://34.136.246.110";
        }

        public void RegisterUser(User data)
        {
            RegisterPage registerPage = new HomePage(driver).GoToRegisterPage();
            registerPage.FillRegisterForm(data);
            registerPage.ClickAgreeCheckBox();
            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();
            AHeadComponent.LoggedUser = true;
        }

        
        private const string NEW_PASSWORD = "school33";
        private const string EXPECTED_AlERT_MESSAGE = "Success: Your password has been successfully updated.";

        [AllureTag("ChangePassword")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
        [Test]
        public void ChangePassword()
        {
            ShoppingCartTests shoppingCartTests = new ShoppingCartTests();
            User testUser = shoppingCartTests.CreateUser();
            RegisterUser(testUser);
            driver.Navigate().GoToUrl(OpenCartURL);
            
            new HomePage(driver)
                .GoToMyAccountPage()
                .ClickhangeYourPassword();            

            ChangePasswordPage changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.PasswordField.SendKeys(NEW_PASSWORD);
            changePasswordPage.PasswordConfirm.SendKeys(NEW_PASSWORD);
            changePasswordPage.ClickContinueButton();
            MyAccountMessagePage myAccountMessagePage = new MyAccountMessagePage(driver);
            
            Assert.AreEqual(EXPECTED_AlERT_MESSAGE, myAccountMessagePage.GetAlertMessageText());

            myAccountMessagePage.Logout();
            User user = User.CreateBuilder().SetEMail(testUser.EMail).SetPassword(NEW_PASSWORD).Build();
            new HomePage(driver)
                .GoToLoginPage()
                .SuccessfullLogin(user);

        }
    }
}