using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class CheckoutInformationPage
    {
        private IPage page;

        public CheckoutInformationPage(IPage page)
        {
            this.page = page;
        }

        public async Task EnterFirstName(string firstName)
        {
            await page.Locator("#first-name").FillAsync(firstName);
        }

        public async Task EnterLastName(string lastName)
        {
          await  page.Locator("#last-name").FillAsync(lastName);
        }

        public async Task EnterPostalCode(string postalCode)
        {
            await page.Locator("#postal-code").FillAsync(postalCode);
        }

        public async Task ClickContinue()
        {
            await page.Locator("#continue").ClickAsync();

            await Assertions.Expect(page).ToHaveURLAsync(
                "https://www.saucedemo.com/checkout-step-two.html"
            );
        }
    }
}