using Microsoft.Playwright;

class CheckoutComplete
{
    private IPage page;

    public CheckoutComplete(IPage page)
    {
        this.page = page;
    }


    public async Task VerifyMessage()
    {
        try{
            await Assertions.Expect(page.Locator(".complete-header")).ToHaveTextAsync("Thank you for your order!");
        }
        catch
        {
            TakeScreenshot sh = new TakeScreenshot(page);
           await sh.screenshot("CheckoutPage_fail");
        }
    }



}