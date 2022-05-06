using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //Applying a coupon to our basket//
     class ApplyCouponPOM
    {
        IWebDriver driver;

        public ApplyCouponPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Finds the text box for us to enter the coupon and the submit button//
            public IWebElement Coupon_code => driver.FindElement(By.Id("coupon_code"));

            public IWebElement Apply_code => driver.FindElement(By.Name("apply_coupon"));


        //Enters the coupon code and submits it//
        public ApplyCouponPOM AddCoupon(String edgewords)
            {
                Coupon_code.SendKeys(edgewords);

                Apply_code.Click();

                return this;    
            }

    }
}
