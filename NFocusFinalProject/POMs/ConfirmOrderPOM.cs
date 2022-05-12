using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //This selects the payment method we want to use and then places our order//
    public class ConfirmOrderPOM
    {
        IWebDriver driver;

        public ConfirmOrderPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locates the option we want to use as a payment method//
        public IWebElement CheckPayment => driver.FindElement(By.CssSelector(".wc_payment_method.payment_method_cheque > label"));

        //Locates the button to confirm the order//
        public IWebElement PlaceOrder => driver.FindElement(By.Id("place_order"));

        //Locates the links to our account then to our orders//
        public IWebElement MyAccount => driver.FindElement(By.PartialLinkText("My account"));

        public IWebElement Orders => driver.FindElement(By.PartialLinkText("Orders"));

        public IWebElement FindOrderNumber => driver.FindElement(By.CssSelector(".order > strong"));


        //Selects the payment method we want to use//
        public void Check_payments()
        {
            Thread.Sleep(1000);
            CheckPayment.Click();
        }

        //Clicks the button to confirm our order//
        public void OrderItem()
        {
            PlaceOrder.Click();
            Thread.Sleep(1000);
        }

        //This is the method that checks that order we see when place the order matches the one in our account//
        public void CheckOrderNumber()
        {
            //Waits until the order has been received by the site//
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.Url.Contains("order-received"));



            //Takes us to the order page and then checks the order numbers to confirm they match//
            string OrderNumber = Convert.ToString(FindOrderNumber.Text);
            Console.WriteLine("Your order number is " + OrderNumber);

            MyAccount.Click();
            Orders.Click();


            var OrderResults = driver.FindElement(By.ClassName("account-orders-table")).Text;
            Assert.That(OrderResults, Does.Contain(OrderNumber), "Does not contain order results");
        }


    }
}



