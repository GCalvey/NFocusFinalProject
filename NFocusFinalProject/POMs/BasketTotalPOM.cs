using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //Aim is to turn the majority of the Then [Then(@"I can apply a coupon to get the correct discount")] into a POM//
    class BasketTotalPOM
    {
        IWebDriver driver;

        public BasketTotalPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public IWebElement string coupon_deduction = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
        //decimal coupon_discount = Decimal.Parse(coupon_deduction.Substring(1));

        public BasketTotalPOM()
        {

        }

    }
}