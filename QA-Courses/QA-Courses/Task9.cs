using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses
{
    [TestFixture]
    public class Task9
    {
        private IWebDriver driver;
        private WebDriverWait wait;

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
        public void TestFromTaskNine()
        {
            driver.Url = "http://localhost/litecard/public_html/admin/login.php?redirect_url=%2Flitecard%2Fpublic_html%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//span[contains(text(),'Countries')]")).Click();

            List<String> listOfCountriesNames = new List<String>();
            List<String> listOfZonesNames = new List<String>();

            IList<IWebElement> listOfCountries = driver.FindElements(By.CssSelector(".row"));
            
            //here is the issue with loosing the track of the listOfCountries
            foreach (IWebElement item in listOfCountries)
            {
                var givenCountry = item.FindElement(By.CssSelector("td:nth-child(5)"));
                var givenNumberOfZones = item.FindElement(By.CssSelector("td:nth-child(6)"));
                listOfCountriesNames.Add(givenCountry.GetAttribute("textContent"));

                if (Int32.Parse(givenNumberOfZones.GetAttribute("textContent")) != 0)
                {
                    givenCountry.FindElement(By.CssSelector("a")).Click();

                    IList<IWebElement> listOfZones = driver.FindElements(By.CssSelector("table#table-zones.dataTable tbody tr"));

                    foreach (IWebElement item1 in listOfZones)
                    {
                        if (item1.GetAttribute("className") == "header" || item1.GetAttribute("rowIndex") == "14")
                            {
                            continue;                            
                        }
                        var givenZone = item1.FindElement(By.CssSelector("td:nth-child(3)"));
                        listOfZonesNames.Add(givenZone.GetAttribute("textContent"));
                    }

                    var unsortedListOfZones = listOfZonesNames;
                    var sortedListOfZones = listOfZonesNames.OrderBy(a => a);
                    
                    Assert.IsTrue(unsortedListOfZones.SequenceEqual(sortedListOfZones));
                    driver.FindElement(By.XPath("//span[contains(text(),'Countries')]")).Click();
                }
                



            }

            var unsortedListOfCountriesNames = listOfCountriesNames;
            var sortedListOfCountriesNames = listOfCountriesNames.OrderBy(a => a);
            
            Assert.IsTrue(unsortedListOfCountriesNames.SequenceEqual(sortedListOfCountriesNames));



        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
