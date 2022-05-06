using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //This selects the payment method we want to use and then places our order//
    public class PlaceAndConfirmOrderPOM
    {
        IWebDriver driver;

        public PlaceAndConfirmOrderPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locates the option we want to use as a payment method//
        public IWebElement Check_payment => driver.FindElement(By.CssSelector(".wc_payment_method.payment_method_cheque > label"));

        //Locates the button to confirm the order//
        public IWebElement Place_order => driver.FindElement(By.Id("place_order"));

        //Selects the payment method we want to use//
        public void Check_payments()
        {
            Thread.Sleep(1000);
            Check_payment.Click();
        }

        //Clicks the button to confirm our order//
        public void Order()
        {
            Place_order.Click();
        }



    }
}



