using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace QA_Courses
{
    [TestFixture]
    public class Task11
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 1; i < size + 1; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            else
                return builder.ToString();
        }


        [SetUp]
        public void start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestFromTaskEleven()
        {
            driver.Url = "http://localhost/litecard/public_html/en/";


        

        var linkToCreateAUser = driver.FindElement(By.CssSelector("div#box-account-login a"));
            linkToCreateAUser.Click();
            var firstName = driver.FindElement(By.Name("firstname"));
            var lastName = driver.FindElement(By.Name("lastname"));
            var city = driver.FindElement(By.Name("city"));
            var email = driver.FindElement(By.Name("email"));
            var phone = driver.FindElement(By.Name("phone"));
            var password = driver.FindElement(By.Name("password"));
            var confirmPassword = driver.FindElement(By.Name("confirmed_password"));
            var createAccount = driver.FindElement(By.Name("create_account"));
            var selectCountry = new SelectElement(driver.FindElement(By.Name("country_code")));
            var address1 = driver.FindElement(By.Name("address1"));
            var postcode = driver.FindElement(By.Name("postcode"));
            
            string random = RandomString(5, true);

            
            firstName.SendKeys("Mateusz");
            lastName.SendKeys("Test");
            address1.SendKeys("Filarecka 122212");
            postcode.SendKeys("31-999");
            city.SendKeys("Krakow");
            email.SendKeys(random + "@o2.pl");
            phone.SendKeys("+481251213213");
            selectCountry.SelectByText("Poland");
            password.SendKeys("123!@#");
            confirmPassword.SendKeys("123!@#");
            createAccount.Click();
            Thread.Sleep(2000);
            var linkToLogOutAUser = driver.FindElement(By.CssSelector("#box-account.box li:nth-child(4) a"));
            new Actions(driver).MoveToElement(linkToLogOutAUser).Click().Build().Perform();
              

            var emailAddress = driver.FindElement(By.Name("email"));
            var passwordToLogin = driver.FindElement(By.Name("password"));
            var loginBtn = driver.FindElement(By.Name("login"));

            emailAddress.SendKeys(random + "@o2.pl");
            passwordToLogin.SendKeys("123!@#");
            loginBtn.Click();

            Thread.Sleep(2000);

            var linkToLogOutAUserSecondTime = driver.FindElement(By.CssSelector("#box-account li:nth-child(4) a"));
            linkToLogOutAUserSecondTime.Click();

        }
        
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
        
    }
}
