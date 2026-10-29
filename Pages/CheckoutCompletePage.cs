using System.Formats.Asn1;
using Microsoft.Playwright;

namespace SauceDemoproject.CheckoutComplete;

class CheckoutCompletePage
{
    IPage page;
    ILocator msg ;

    public CheckoutCompletePage(IPage page)
    {
        this.page = page;
        this.msg = page.Locator("data-test=title");
    }

    public async Task verifyMessage()
    {
        await Assertions.Expect(msg).ToHaveTextAsync("Checkout: Complete!");
    }
}