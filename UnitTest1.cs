using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V113.FedCm;

namespace LambdaTestNunit
{
    public class Tests
    {

        private IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }

        [TestCase("standard_user", "secret_sauce", "inventory")]
        [TestCase("standard_user", "wrong_password", "inventory")]
        public void login(string login1, string password, string expectedTitle)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            IWebElement loginInput = driver.FindElement(By.Id("user-name"));
            loginInput.SendKeys(login1);

            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            bool isLoggedIn = driver.Url.Contains(expectedTitle);
            Assert.IsTrue(isLoggedIn);
        }
        /*[Test]
        public void login2()
        {
            IWebElement napis = driver.FindElement(By.ClassName("login_logo"));
            string jest = napis.Text;
            Assert.AreEqual(jest, "siemka");
        }*/


    }
}