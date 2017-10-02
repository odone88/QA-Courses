using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace QA_Courses.Task19.Pages
{
    class CartPage: Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cart > a.link")]
        public IWebElement CartLink;

        [FindsBy(How = How.ClassName, Using = "shortcut")]
        IList<IWebElement> ProductShortcuts;

        [FindsBy(How = How.Name, Using = "remove_cart_item")]
        public IWebElement RemoveCartItemBtn;

        [FindsBy(How = How.CssSelector, Using = "#order_confirmation-wrapper tr:nth-child(2) > td.item")]
        public IWebElement Product1;

        [FindsBy(How = How.CssSelector, Using = "#order_confirmation-wrapper tr:nth-child(3) > td.item")]
        public IWebElement Product2;

        [FindsBy(How = How.CssSelector, Using = "#order_confirmation-wrapper tr:nth-child(4) > td.item")]
        public IWebElement Product3;



        public CartPage GoToCartPage()
        {
            CartLink.Click();
            return this;
        }

        public bool DeleteProductsAndCheckIfTheyStillExists()
        {
            if (ProductShortcuts.Count == 2)
            {
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
            }
            else if (ProductShortcuts.Count == 3)
            {
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
            }
            else {
                RemoveCartItemBtn.Click();
                Thread.Sleep(2000);
            }

            if (ProductShortcuts.Count == 0)
                return true;
            return false;

        }


    }
}
