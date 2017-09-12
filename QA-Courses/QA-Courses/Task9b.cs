using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace QA_Courses
{
    [TestFixture]
    public class Task9b
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
        public void TestFromTaskNineb()
        {
            driver.Url = "http://localhost/litecard/public_html/admin/login.php?redirect_url=%2Flitecard%2Fpublic_html%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//span[contains(text(),'Geo Zones')]")).Click();

            List<String> listOfZonesNamesInCanada = new List<String>();
            List<String> listOfZonesNamesInEU = new List<String>();
            List<String> listOfZonesNamesInUS = new List<String>();
            var firstCountry = driver.FindElement(By.CssSelector("table.dataTable tbody tr:nth-child(2)"));
            firstCountry.FindElement(By.CssSelector("td:nth-child(3) a")).Click();

            IList<IWebElement> listOfZones = driver.FindElements(By.CssSelector("#table-zones tbody tr"));

            foreach (IWebElement item1 in listOfZones)
            {
                if (item1.GetAttribute("className") == "header" || item1.GetAttribute("rowIndex") == "11")
                {
                    continue;
                }
                SelectElement listOfGivenZones = new SelectElement(item1.FindElement(By.CssSelector("td:nth-child(3) > select")));
                var givenZone = listOfGivenZones.SelectedOption.Text;

                listOfZonesNamesInCanada.Add(givenZone);
            }

            var unsortedListOfZones = listOfZonesNamesInCanada;
            var sortedListOfZones = listOfZonesNamesInCanada.OrderBy(a => a);

            Assert.IsTrue(unsortedListOfZones.SequenceEqual(sortedListOfZones));

            driver.FindElement(By.Name("cancel")).Click();

            //EU
            var europeanUnion = driver.FindElement(By.CssSelector("table.dataTable tbody tr:nth-child(3)"));
            europeanUnion.FindElement(By.CssSelector("td:nth-child(3) a")).Click();

            IList<IWebElement> listOfZonesInEU = driver.FindElements(By.CssSelector("#table-zones tbody tr"));

            foreach (IWebElement item1 in listOfZonesInEU)
            {
                if (item1.GetAttribute("className") == "header" || item1.GetAttribute("rowIndex") == "29")
                {
                    continue;
                }
                SelectElement listOfGivenZones = new SelectElement(item1.FindElement(By.CssSelector("td:nth-child(2) > select")));
                var givenZone = listOfGivenZones.SelectedOption.Text;

                listOfZonesNamesInEU.Add(givenZone);
            }

            var unsortedListOfZonesInEU = listOfZonesNamesInEU;
            var sortedListOfZonesInEU = listOfZonesNamesInEU.OrderBy(a => a);

            Assert.IsTrue(unsortedListOfZonesInEU.SequenceEqual(sortedListOfZonesInEU));

            driver.FindElement(By.Name("cancel")).Click();

            //US

            var unitedStates = driver.FindElement(By.CssSelector("table.dataTable tbody tr:nth-child(4)"));
            unitedStates.FindElement(By.CssSelector("td:nth-child(3) a")).Click();

            IList<IWebElement> listOfZonesInUS = driver.FindElements(By.CssSelector("#table-zones tbody tr"));

            foreach (IWebElement item1 in listOfZonesInUS)
            {
                if (item1.GetAttribute("className") == "header" || item1.GetAttribute("rowIndex") == "51")
                {
                    continue;
                }
                SelectElement listOfGivenZones = new SelectElement(item1.FindElement(By.CssSelector("td:nth-child(3) > select")));
                var givenZone = listOfGivenZones.SelectedOption.Text;

                listOfZonesNamesInUS.Add(givenZone);
            }

            var unsortedListOfZonesInUS = listOfZonesNamesInUS;
            var sortedListOfZonesInUS = listOfZonesNamesInUS.OrderBy(a => a);

            Assert.IsTrue(unsortedListOfZonesInUS.SequenceEqual(sortedListOfZonesInUS));

            driver.FindElement(By.Name("cancel")).Click();


        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
