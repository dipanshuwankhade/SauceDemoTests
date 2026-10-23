
using System.Drawing;
using System.Security.AccessControl;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PracticeOne.Pages
{
    public class PlaywrightTest
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
                    Headless = false,
                    SlowMo = 500
                    // Args = new[] { "--start-maximized" }
                }
            );

            page = await browser.NewPageAsync();
        }


        [Test]
        public async Task testRun()
        {
            await page.GotoAsync("https://www.saucedemo.com/");

            LoginPage login = new LoginPage(page);
            await login.Login("standard_user","secret_sauce");
            // await page.PauseAsync();

            try
            {
                await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
            }catch
            {
                Console.WriteLine("WRONG CREDENTIALS");
            }

            InventoryPage inventory = new InventoryPage(page);
            
            List<string> productNames = await inventory.AddFirstTwoProducts();

            foreach(string name in productNames)
            {
                Console.WriteLine(name);
            }

            await inventory.validateCart();
        

            CartPage cart = new CartPage(page);
            await cart.openCart();

            string removedProduct = productNames[0];
            Console.WriteLine(removedProduct);

           string removed = await cart.removeProduct(removedProduct);

           productNames.Remove(removed); 
           Console.WriteLine("REMOVED PRODUCT FROM CART : "+removed);
           
           string remainingProductInCart = "";
           foreach(string name in productNames)
            {
                 remainingProductInCart = name;
            }
            Console.WriteLine("PRODUCT IN CART AFTER REMOVE : "+remainingProductInCart);
          await cart.VerifyCartBatchCount();
          
          await cart.ClickCheckOut();

        CheckoutPage checkoutPage = new CheckoutPage(page);

        await checkoutPage.EnterFirstName("Dipanshu ");
        await checkoutPage.EnterLastName("Wankhade");
        await checkoutPage.EnterPostCode("411030");

        await checkoutPage.Continue();


        CheckoutOverview checkoutOverview = new CheckoutOverview(page);
        string checkoutProduct = await checkoutOverview.VerifyProduct();

        Console.WriteLine("FINAL LIST OF PRODUCT IS : "+checkoutProduct);
        
        await checkoutOverview.FinishOverview();
        
        CheckoutComplete checkoutComplete = new CheckoutComplete(page);
        await checkoutComplete.VerifyMessage();

        }
    }
}
