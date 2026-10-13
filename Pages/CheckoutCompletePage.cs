
using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class CheckoutCompletePage
    {
        private IPage page;

        public CheckoutCompletePage(IPage page)
        {
            this.page = page;
        }

        // Verify the selected product in the overview
        public async Task VerifySelectedProduct(string productName)
        {
            await Assertions.Expect(
                page.Locator(".cart_item .inventory_item_name")
            ).ToHaveTextAsync(productName);
        }

        // Click Finish to complete the order
        public async Task ClickFinish()
        {
            await page.Locator("#finish").ClickAsync();
        }
    }
}
