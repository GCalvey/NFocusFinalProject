using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using NFocusFinalProject.POMs;
using NFocusFinalProject.TestBase;
using NUnit.Framework;
using System.Threading.Tasks;
using static NFocusFinalProject.Utilities.Helpers;

namespace NFocusFinalProject.StepDefinitions.OrderTestCase
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


            [Given(@"I am on the checkout page")]
                 void GivenIAmOnTheCheckoutPage()
            {
                CartPOM Cart = new CartPOM(driver);
                //Takes us to the checkout page//
                Cart.GoToCheckout();
            }

            
            [When(@"I use the checkout with vaild details")]
                void WhenIUseTheCheckoutWithVaildDetails()
            {
                //Enters our details for each field on the checkout page//
                CheckoutPOM Checkout = new CheckoutPOM(driver);

                Checkout.FirstNameCheckout(Environment.GetEnvironmentVariable("First_Name"));
                Checkout.LastNameDetails(Environment.GetEnvironmentVariable("Last_Name"));

                Thread.Sleep(1000);

                
                Checkout.CountryCheckout();
                Checkout.CountryChosenCheckout(Environment.GetEnvironmentVariable("Country"));
                Checkout.AddressCheckout(Environment.GetEnvironmentVariable("Address"));
                Checkout.CityCheckout(Environment.GetEnvironmentVariable("City"));
                Checkout.PostcodeCheckout(Environment.GetEnvironmentVariable("Postcode"));
                Checkout.PhoneNumberCheckout(Environment.GetEnvironmentVariable("Phone_Number"));
                Checkout.EmailCheckout(Environment.GetEnvironmentVariable("Email"));

                //Confirms the order //
                ConfirmOrderPOM PlaceOrder = new ConfirmOrderPOM(driver);

                PlaceOrder.Check_payments();
                PlaceOrder.OrderItem();
                //Screenshot our order number//
                CaptureScreenshot(driver as ITakesScreenshot, "OrderNumber");
            }

            [Then(@"My order is visble in my orders with the correct number")]
                void ThenMyOrderIsVisbleInMyOrdersWithTheCorrectNumber()
            {
                //Now the order is placed this will check that the order number in our account matches the number we just got//
                ConfirmOrderPOM ConfirmOrder = new ConfirmOrderPOM(driver);

                ConfirmOrder.CheckOrderNumber();
                CaptureScreenshot(driver as ITakesScreenshot, "AccountOrderNumber");

            }
        }
    }
}

