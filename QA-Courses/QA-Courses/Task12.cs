using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses
{
    [TestFixture]
    public class Task12
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public string GetFilePathFromBinDirectory(string fileName)
        {
            var binDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return $"{binDirectory}\\{fileName}";
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
        public void TestFromTaskTwelve()
        {
            driver.Url = "http://localhost/litecard/public_html/admin/login.php?redirect_url=%2Flitecard%2Fpublic_html%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//span[contains(text(),'Catalog')]")).Click();

            driver.FindElement(By.CssSelector("#content a:nth-child(2)")).Click();
            driver.FindElement(By.Name("status")).Click();
            driver.FindElement(By.Name("name[en]")).SendKeys("blabla");
            driver.FindElement(By.Name("code")).SendKeys("code1");

            driver.FindElement(By.XPath("//input[@value = '1-1']")).Click();

            driver.FindElement(By.Name("quantity")).Clear();
            //Thread.Sleep(1000);
            driver.FindElement(By.Name("quantity")).SendKeys("50");
            driver.FindElement(By.Name("new_images[]")).SendKeys(GetFilePathFromBinDirectory("bla.jpg"));
            driver.FindElement(By.Name("date_valid_from")).SendKeys(Keys.Home + "11112017");

            driver.FindElement(By.Name("date_valid_to")).SendKeys(Keys.Home + "11112019");
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form/div/ul/li[2]/a")).Click();
            

            var selectManufacturerId = new SelectElement(driver.FindElement(By.Name("manufacturer_id")));
            selectManufacturerId.SelectByText("ACME Corp.");
            

            driver.FindElement(By.Name("keywords")).SendKeys("ajas ajsdj as jasj djas jas j");
            driver.FindElement(By.Name("short_description[en]")).SendKeys("description example");
            new Actions(driver).MoveToElement(driver.FindElement(By.ClassName("trumbowyg-editor"))).Click().SendKeys("50").Build().Perform();
            

            driver.FindElement(By.Name("head_title[en]")).SendKeys("ajas ajsdj as jasj djas jas j");
            driver.FindElement(By.Name("meta_description[en]")).SendKeys("ajas ajsdj as jasj djas jas j");

            driver.FindElement(By.CssSelector("#content li:nth-child(4) > a")).Click();

            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys("1250");

            

            var currency = new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code")));
            currency.SelectByIndex(1);

            driver.FindElement(By.Name("gross_prices[USD]")).SendKeys("1300");
            driver.FindElement(By.Name("gross_prices[EUR]")).SendKeys("1250");

            driver.FindElement(By.Name("save")).Click();

            var newProduct = driver.FindElement(By.LinkText("blabla")).GetAttribute("textContent");

            Assert.AreEqual("blabla", newProduct, "Product was not added correctly. Please investigate.");





        }
        
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
        
    }
}
