
using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class CheckoutFinishPage
    {
        private IPage page;

        public CheckoutFinishPage(IPage page)
        {
            this.page = page;
        }

        // Verify the completion page
        public async Task VerifyCompletePage()
        {
            await Assertions.Expect(page.Locator(".title"))
                .ToHaveTextAsync("Checkout: Complete!");
        }

        // Verify the confirmation message
        public async Task VerifyConfirmationMessage()
        {
            await Assertions.Expect(page.Locator(".complete-header"))
                .ToHaveTextAsync("Thank you for your order!");
        }
    }
}
