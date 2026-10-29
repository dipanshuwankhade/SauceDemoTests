
using Microsoft.Playwright;
using SauceDemoproject.Cart;
using SauceDemoproject.CheckoutOverview;
using SauceDemoproject.inventory;
using SauceDemoproject.CheckoutDetail;
using SauceDemoproject.CheckoutComplete;
using System.Security.Cryptography.X509Certificates;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace SauceDemoproject;
public class SauceDemoproject 
{

    [Test]
    public async Task TestRunner()
    {
        
        var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync();

        var page = await browser.NewPageAsync();
 

        await page.GotoAsync("https://www.saucedemo.com");  
       
//login with valid user creadentials
        LoginPage loginPage = new LoginPage(page);        
        await loginPage.login("standard_user","secret_sauce");
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");

//Inventory pages 
        InventoryPage inventoryPage = new InventoryPage(page);
        await inventoryPage.addProductsToCart();
        await inventoryPage.veryCartCatalogue();
        await inventoryPage.goToCart();

//cart page
        CartPage cartPage = new CartPage(page);
        await cartPage.removeProduct();    
        await cartPage.clickToCheckout();
       
//checkout overview
        CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage(page);
        await checkoutOverviewPage.fillCheckoutInfo();
        await checkoutOverviewPage.ClickToContinueBtn();

//checkout detail page
        CheckoutDetailPage checkoutDetailPage = new CheckoutDetailPage(page);
        await checkoutDetailPage.clickToFinish();

//chekout comlpete page
        CheckoutCompletePage checkoutCompeletePage = new CheckoutCompletePage(page);
        await checkoutCompeletePage.verifyMessage();    
    }
}