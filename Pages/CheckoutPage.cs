using Microsoft.Playwright;

class CheckoutPage
{
    private IPage page;

    public CheckoutPage(IPage page)
    {
        this.page = page;
    }

    public async Task EnterFirstName(string FName)
    {
        await page.Locator("#first-name").FillAsync(FName);
    }
    
    public async Task EnterLastName(string LName)
    {
        await page.Locator("#last-name").FillAsync(LName);

    }

    public async Task EnterPostCode(string PCode)
    {
        await page.Locator("#postal-code").FillAsync(PCode);
    }

    public async Task Continue()
    {
        await page.GetByRole(AriaRole.Button, new(){Name="continue"}).ClickAsync();
    
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-two.html");
    }



}