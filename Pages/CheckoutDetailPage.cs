using Microsoft.Playwright;

namespace SauceDemoproject.CheckoutDetail;

class CheckoutDetailPage
{
    IPage page;
    ILocator finish;
    public CheckoutDetailPage(IPage page)
    {
        this.page = page;
        this.finish = page.GetByRole(AriaRole.Button, new(){Name ="Finish"});
    }

    public async Task clickToFinish()
    {
        await finish.ClickAsync();
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-complete.html");

    }
}
