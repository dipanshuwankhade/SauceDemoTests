using Microsoft.Playwright;

class CheckoutOverview
{
    IPage page;

    public CheckoutOverview(IPage page)
    {
        this.page = page;
    }

    public async Task<string> VerifyProduct()
    {
        string cartProduct  = await page.Locator(".inventory_item_name").InnerTextAsync();

        return cartProduct;
    }

    public async Task FinishOverview()
    {
        await page.Locator("#finish").ClickAsync();
        
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-complete.html");

    }
    
}