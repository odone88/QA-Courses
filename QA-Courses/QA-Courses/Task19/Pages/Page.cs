using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Courses.Task19.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses.Task19.Pages
{
    public class Page:TestBase
    {
        protected WebDriverWait wait;
        private IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        }
    }
}
