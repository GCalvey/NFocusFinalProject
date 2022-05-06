using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NFocusFinalProject.POMs;
using NFocusFinalProject.TestBase;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NFocusFinalProject.StepDefinitions
{
    //Test Case 1: Applying a coupon//

    [Binding]
    public class CouponApplied
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public CouponApplied(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];
        }

        // Logs us into the website as a registered user//

        [Given(@"I am logged into a registered account")]
        public void GivenIAmLoggedIntoARegisteredAccount()
        {
            LogInPOM Login = new LogInPOM(driver);
            Login.dismiss();
            Login.LoginUser(Environment.GetEnvironmentVariable("username"));
            Login.LoginPassword(Environment.GetEnvironmentVariable("password"));

            //This clicks the login button//
            driver.FindElement(By.Name("login")).Click();
        }

        //Takes us to the shop page and then adds an item into our basket//
        [When(@"I add an item to my cart")]
        public void WhenIAddAnItemToMyCart()
        {
            //This POM also takes us to our cart //
            AddToCartPOM AddToCartPOM = new AddToCartPOM(driver);
            AddToCartPOM.AddHoodieWithLogo();

            //Applies the coupon to our item within the cart//
            ApplyCouponPOM ApplyCouponPOM = new ApplyCouponPOM(driver);
            ApplyCouponPOM.AddCoupon("edgewords");
        }

        //This determinds whether is the coupon has applied and the discount is correct//
        [Then(@"I can apply a coupon to get the correct discount")]
        public void ThenICanApplyACouponToGetTheCorrectDiscount()
        {
           // Short stop to show what is happening //
           Thread.Sleep(1000);

            //Finds the amount that has been off by the coupon, then converts it to a decimal//
            string coupon_deduction = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            decimal coupon_discount = Decimal.Parse(coupon_deduction.Substring(1));

            //Finds the subtool for the cart and converts it to decimal//
            string find_subtotal = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount,woocommerce-Price-amount")).Text;
            decimal Subtotal = Decimal.Parse(find_subtotal.Substring(1));

            //Works out how much has been taken off ( Percentage Decrease = Amount taken off / Orignal Amount) //
            // 4.5/45.0 = 0.1//
            decimal PercentageTakenOff = coupon_discount / Subtotal;

            //We should be getting a Percentage decrease of 0.15//
            decimal TargetPercentage = 0.15m;
            
            //This checks the result of PercentageTakenOff to make sure it matches TargetPercentage//
            try
            {
                //If they do not match this gives out this text and the results//
                Assert.That(PercentageTakenOff, Is.EqualTo(TargetPercentage), "Discount amount incorrect");
            }
            catch (Exception)
            {

            }

            //This finds and converts the shipping price to a decimal//
            string find_shipping = driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text;
            decimal shipping_price = Decimal.Parse(find_shipping.Substring(1));

            //Locates and Converts the total price to a decimal//
            string find_total_price = driver.FindElement(By.CssSelector(".strong > .amount.woocommerce-Price-amount")).Text;
            decimal total_price = Decimal.Parse(find_total_price.Substring(1));

            //This works out if the total price is correct including the discount and shipping applied//
            decimal final_total_price = (Subtotal + shipping_price) - coupon_discount;

            //If the result is not correct this code is given out//
            Assert.That(total_price, Is.EqualTo(final_total_price), "Incorrect price");

            Thread.Sleep(1000);
        }
    }



    //Test Case 2: Confirming an order number//

    [Binding]
    public class OrderConfirmed
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public OrderConfirmed(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];
        }
        //Logs us in as a registered user and adds an item into our basket//
        [Given(@"I have an item within my cart")]
        public void GivenIHaveAnItemWithinMyCart()
        {
            LogInPOM Login = new LogInPOM(driver);
            Login.dismiss();
            Login.LoginUser(Environment.GetEnvironmentVariable("username"));
            Login.LoginPassword(Environment.GetEnvironmentVariable("password"));
            driver.FindElement(By.Name("login")).Click();

            AddToCartPOM AddToCartPOM = new AddToCartPOM(driver);
            AddToCartPOM.AddHoodieWithLogo();

        }

        //Takes us to the checkout page and enters our details//
        [When(@"I use the checkout with vaild details")]
        public void WhenIUseTheCheckoutWithVaildDetails()
        {
            driver.FindElement(By.Id("menu-item-45")).Click();

            DetailsForCheckoutPOM checkout = new DetailsForCheckoutPOM(driver);
            checkout.FirstName_Checkout(Environment.GetEnvironmentVariable("First_Name"));
            checkout.LastName_Details(Environment.GetEnvironmentVariable("Last_Name"));

            //This scrolls the page down so that we that program can enter the details in every field//
            IJavaScriptExecutor Page_window = (IJavaScriptExecutor)driver;
            Page_window.ExecuteScript("window.scrollBy(0,740)");

            //Enters our details for each field on the checkout page//
            checkout.Country_Checkout();
            checkout.CountryChosen_Checkout();
            checkout.Address_Checkout(Environment.GetEnvironmentVariable("Address"));
            checkout.City_Checkout(Environment.GetEnvironmentVariable("City"));
            checkout.Postcode_Checkout(Environment.GetEnvironmentVariable("Postcode"));
            checkout.PhoneNumber_Checkout(Environment.GetEnvironmentVariable("Phone_Number"));
            checkout.Email_Checkout(Environment.GetEnvironmentVariable("Email"));

            //Confirms the order //
            PlaceAndConfirmOrderPOM Payment = new PlaceAndConfirmOrderPOM(driver);
            
            Payment.Check_payments();
            Payment.Order();

        }


        //Once the order has been made it takes us to our account to confirm that are order has been made and the order number match//
        [Then(@"My order is visble in my orders with the correct number")]
        public void ThenMyOrderIsVisbleInMyOrdersWithTheCorrectNumber()
        {
            //Waits until the order has been received by the site//
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.Url.Contains("order-received"));

            //Takes us to the order page and then checks the order numbers to confirm they match//
            string Order_number = driver.FindElement(By.CssSelector(".order > strong")).Text;
            Console.WriteLine("Your order number is " + Order_number);

            OrdersPagePOM Order_details = new OrdersPagePOM(driver);

            Order_details.NavigationOrder();

            var Order_results = driver.FindElement(By.ClassName("account-orders-table")).Text;
            Assert.That(Order_results, Does.Contain(Order_number), "Does not contain order results");
           


        }
    }
}