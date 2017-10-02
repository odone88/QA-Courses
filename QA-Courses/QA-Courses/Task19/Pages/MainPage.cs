using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QA_Courses.Task19.Pages;
using QA_Courses.Task19.Driver;

namespace QA_Courses.Task19.Pages
{
    public class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        internal MainPage Open()
        {
            DriverContext.Driver.Url = "http://localhost:8080/litecard/en/";
            return this;
        }

        internal ProductPage ClickOnProduct()
        {
            DriverContext.Driver.FindElement(By.CssSelector("#box-most-popular > div > ul > li:nth-child(4) > a.link > div.name")).Click();
            return new ProductPage(DriverContext.Driver);
        }
    }
}