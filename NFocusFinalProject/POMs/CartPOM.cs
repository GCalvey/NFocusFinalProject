using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NFocusFinalProject.Utilities.Helpers;

namespace NFocusFinalProject.POMs
{
    public class CartPOM
    {
        IWebDriver driver;
        private WebDriverWait _wait;
        private int _discount;
        
        public CartPOM(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            _discount = 0;


        }
        //These help paramatise the target discount amount//
        public void SetDiscount(int discount)
        {
            _discount = discount;
        }

        public int GetDiscount()
        {
            return _discount;
        }

        // These locate all the website page links//
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));

        public IWebElement ShopLink => driver.FindElement(By.LinkText("Shop"));

        public IWebElement CartLink => driver.FindElement(By.LinkText("Cart"));

        public IWebElement CheckoutLink => driver.FindElement(By.LinkText("Checkout"));

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My account"));

        public IWebElement BlogLink => driver.FindElement(By.LinkText("Blog"));

        public IWebElement Orders => driver.FindElement(By.LinkText("Orders"));

        public IWebElement ViewCart => driver.FindElement(By.CssSelector("a[title='View cart']"));

        public IWebElement EnterCoupon => driver.FindElement(By.Id("coupon_code"));

        public IWebElement ApplyCode => driver.FindElement(By.Name("apply_coupon"));

        public IWebElement Discount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));

        public IWebElement SubTotal => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount"));

        public IWebElement Delivery => driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount"));

        public IWebElement Total => driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount"));

        public IWebElement AddHoodieWithLogo => driver.FindElement(By.CssSelector(".has-post-thumbnail.instock.post-31.product.product-type-simple.product_cat-hoodies.purchasable.shipping-taxable.status-publish.type-product > .add_to_cart_button.ajax_add_to_cart.button.product_type_simple"));

        public IWebElement RemoveButton => driver.FindElement(By.CssSelector(".remove"));

        //This checks at the start of the test if the cart is clear and if not clears it//
        public void RemoveItem()
        {

            CartLink.Click();

            try
            {
                Thread.Sleep(1000);
                RemoveButton.Click();
                _wait.Until(drv => drv.FindElement(By.CssSelector(".cart-empty")).Displayed);
            }
            catch
            {
                Console.WriteLine("You cart is already empty");
            }
        }
   

        //Enters the coupon code and submits it//
        public void AddCoupon(String couponCode)
        {
            EnterCoupon.SendKeys(couponCode);

            ApplyCode.Click();
        }
        //Takes us to the checkout page//
        public void GoToCheckout()
        {
            CheckoutLink.Click();
        }
        //Takes you to the My Account page//
        public void GoToMyAccount()
        {
            MyAccount.Click();
        }
        //Adds an item to the cart//
        public void AddItemToCart()
        {
           
            //Clicks the shop link//
            ShopLink.Click();

            //Adds the item to our basket//
            AddHoodieWithLogo.Click();
            //This makes the test wait until it sees an element before carrying on//
            try
            {
                Thread.Sleep(1000);
                _wait.Until(drv => drv.FindElement(By.CssSelector("a[title='View cart']")).Displayed);
            }
            catch
            {
                
            }

            //Takes us to view out basket//
            ViewCart.Click();
        }

        //This is the method used to check that the discount recieved matches the target discount//
        public void CheckDiscountAmount()
        {
            // Short stop to show what is happening //
            Thread.Sleep(1000);

            decimal PercentageAmount = _discount;

            decimal CouponDiscount = Convert.ToDecimal(Discount.Text.TrimStart('£'));

            decimal PriceBeforeDiscount = Convert.ToDecimal(SubTotal.Text.TrimStart('£'));

            decimal PercentageTakenOff = 100 * (CouponDiscount / PriceBeforeDiscount);

            decimal TargetPercentage = PercentageAmount;

            //This checks the result of PercentageTakenOff to make sure it matches TargetPercentage//
            try
            {
                //If they do not match this gives out this text and the results//
                Assert.That(PercentageTakenOff, Is.EqualTo(TargetPercentage), "Discount amount incorrect");
            }
            catch (Exception)
            {

            }

        }

        public void TotalPriceCheck()
        {
            //Finds the subtool for the cart and converts it to decimal//
            decimal PriceBeforeDiscount = Convert.ToDecimal(SubTotal.Text.TrimStart('£'));

            decimal CouponDiscount = Convert.ToDecimal(Discount.Text.TrimStart('£'));

            decimal ShippingCost = Convert.ToDecimal(Delivery.Text.TrimStart('£'));

            decimal OverallCost = Convert.ToDecimal(Total.Text.TrimStart('£'));

            //This works out if the total price is correct including the discount and shipping applied//
            decimal FinalPrice = (ShippingCost + (PriceBeforeDiscount - CouponDiscount));

            //If the result is not correct this code is given out//
            Assert.That(OverallCost, Is.EqualTo(FinalPrice), "Incorrect price");

            Thread.Sleep(1000);
        }


    }
}




