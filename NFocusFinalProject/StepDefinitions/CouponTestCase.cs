using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NFocusFinalProject.POMs;
using static NFocusFinalProject.Utilities.Helpers;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];
        }
        //This will be ran before each sceanario//
        [Given(@"I am logged in as a registered user")]
        public void GivenIAmLoggedInAsARegisteredUser()
        {
           //This logs us into the website as a registered user//
            LogInPOM Login = new LogInPOM(driver);
            Login.LoginUser(Environment.GetEnvironmentVariable("username"));
            Login.LoginPassword(Environment.GetEnvironmentVariable("password"));
            Login.Login();

            
        }
        //This will be ran before each sceanario//
        [Given(@"I add an item to the cart")]
        public void GivenIAddAnItemToTheCart()
        {
             //This POM also takes us to our cart //
            CartPOM Cart = new CartPOM(driver);
            //This checks at the start of the test if the cart is clear and if not clears it//
            Cart.RemoveItem();
            //Then this one adds an item to our cart//
            Cart.AddItemToCart();
        }
       
        [Given(@"I have applied a coupon '(.*)'")]
        public void GivenIHaveAppliedACoupon(string CouponCode)
        {
            //Applies the coupon to our item within the cart//
            CartPOM AddCouponToCart = new CartPOM(driver);
            AddCouponToCart.AddCoupon(CouponCode);


        }

        [When(@"I apply it I should recieve the correct amount of discount of '(.*)'%")]
        public void WhenIApplyItIShouldRecieveTheCorrectAmountOfDiscountOf(int PercentageAmount)
        {
          CartPOM DiscountCheck = new CartPOM(driver);
            //Checks the amount of discount we have recieved then compares it with the target amount//
            DiscountCheck.SetDiscount(PercentageAmount);
            DiscountCheck.CheckDiscountAmount();
            //Screenshots the coupon when//
            CaptureScreenshot(driver as ITakesScreenshot, "CouponCode");
        }

        
        [Then(@"The total price will include the discount product plus shipping")]
        public void ThenTheTotalPriceWillIncludeTheDiscountProductPlusShipping()
        {
            //Now it will make sure that the total for the cart is the correct amount including shipping and coupon discount//
            CartPOM PriceCheck = new CartPOM(driver);

            PriceCheck.TotalPriceCheck();
        }
    }
}