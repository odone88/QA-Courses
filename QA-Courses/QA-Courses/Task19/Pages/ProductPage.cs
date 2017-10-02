using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using QA_Courses.Task19.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses.Task19.Pages
{
    class ProductPage: Page
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-product > div:nth-child(1) > h1")]
        public IWebElement DuckName;

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        public IWebElement AddToCartBtn;

        [FindsBy(How = How.ClassName, Using = "quantity")]
        public IWebElement NumberOfProducts;

        [FindsBy(How = How.Id, Using = "logotype-wrapper")]
        public IWebElement LogoBtn;

        internal void GoToMainPage()
        {
            LogoBtn.Click();
        }


        internal ProductPage AddProductToCart(string numberOfProductsToWaitFor)
        {
            if (DuckName.Text == "Yellow Duck")
            {
                new SelectElement(DriverContext.Driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
            }
            AddToCartBtn.Click();
            wait.Until(ExpectedConditions.TextToBePresentInElement(NumberOfProducts, numberOfProductsToWaitFor));
            return this;
        }

    }
}
