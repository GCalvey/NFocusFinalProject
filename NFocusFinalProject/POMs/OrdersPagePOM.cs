using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //Navigates us to the Orders page//
    public class OrdersPagePOM
    {
        IWebDriver driver;

        public OrdersPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locates the links to our account then to our orders//
        public IWebElement My_account => driver.FindElement(By.PartialLinkText("My account"));

        public IWebElement Orders => driver.FindElement(By.PartialLinkText("Orders"));

        //Clicks the links we located above//
        public void NavigationOrder()
        {
            My_account.Click();
            Orders.Click();
        }


    }
}
