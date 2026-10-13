using Microsoft.Playwright;
using NUnit.Framework;
using SauceDemoTest.Pages;

namespace SauceDemoTest.Tests
{
    public class LoginTest
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IPage page;

        [SetUp]
        public async Task SetUp()
        {
            playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    
                    //to run without headless
                    Headless = false,
                    SlowMo = 1000,
                    Args = new[] { "--incognito" }
                });

            page = await browser.NewPageAsync();
        }

        [Test]
        public async Task ValidLoginTest()
        {
            await page.GotoAsync("https://www.saucedemo.com/");

            LoginPage login = new LoginPage(page);
            await login.Login("standard_user", "secret_sauce");

            await Assertions.Expect(page).ToHaveURLAsync(
                "https://www.saucedemo.com/inventory.html"
            );

            // products to cart
            InventoryPage inventory = new InventoryPage(page);

            List<string> productNames = await inventory.AddFirstTwoProducts();

            await inventory.AssertCartCountIsTwo();

            // open cart
            CartPage cart = new CartPage(page);
            await cart.OpenCart();

            await cart.RemoveProduct(productNames[1]);

            await cart.VerifyCartCountIsOne();

            await cart.VerifyRemainingProduct(productNames[0]);


    // Click Checkout
            await cart.ClickCheckout();

            CheckoutInformationPage information =
                new CheckoutInformationPage(page);

            await information.EnterFirstName("Dipanshu");
            await information.EnterLastName("Wankhade");
            await information.EnterPostalCode("411001");

            await information.ClickContinue();

            // overview page
            CheckOutOverviewPage overview =
                new CheckOutOverviewPage(page);

            await overview.VerifyOverviewPage();

           //cehckout 
            CheckoutCompletePage complete = new CheckoutCompletePage(page);
            await complete.VerifySelectedProduct(productNames[0]);  
            await complete.ClickFinish();

//final
            CheckoutFinishPage finish = new CheckoutFinishPage(page);
            await finish.VerifyCompletePage();
            await finish.VerifyConfirmationMessage();

        }

        [TearDown]
        public async Task TearDown()
        {
            await browser.CloseAsync();
            playwright.Dispose();
        }
    }
}