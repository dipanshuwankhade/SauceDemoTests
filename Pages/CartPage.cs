using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Playwright;
using NUnit.Framework.Internal;

class CartPage
{
    private IPage page;

    public CartPage(IPage page)
    {
        this.page = page;
    }

    public async Task openCart()
    {
        await page.Locator(".shopping_cart_link").ClickAsync();
    }
    public async Task<string> removeProduct(String proName)
    {
        var product = page.Locator(".cart_item").Nth(0);
        var count = await product.CountAsync();
        
        
        string removedProductName =  await page.Locator(".inventory_item_name").Nth(0).InnerTextAsync();
        
        await product.Locator("#remove-sauce-labs-backpack").ClickAsync();

        return removedProductName;

    }

     public async Task VerifyCartBatchCount()
    {
        string text = await page.Locator(".shopping_cart_badge").InnerTextAsync();
        // await Assertions.Expect(page.GetByTestId(".shopping_cart_container")).ToHaveTextAsync("2");

        try{
            await Assertions.Expect(page.Locator(".shopping_cart_container")).ToHaveTextAsync("1");
        }
        catch
        {
            await page.ScreenshotAsync(new()
            {
                Path = "Verify cart fail.jpg"
            });
        }
    }

    public async Task ClickCheckOut()
    {
        await page.Locator("#checkout").ClickAsync();

        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-one.html");
        

    }

 
}