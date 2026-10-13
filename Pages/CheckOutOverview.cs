using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class CheckOutOverviewPage
    {
        private IPage page;

        public CheckOutOverviewPage(IPage page)
        {
            this.page = page;
        }

        // varify overview page 
        public async Task VerifyOverviewPage()
        {
            await Assertions.Expect(page.Locator(".title"))
                .ToHaveTextAsync("Checkout: Overview");
        }
    }
}