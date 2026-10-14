using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class CartPage
    {
        private IPage page;

        public CartPage(IPage page)
        {
            this.page = page;
        }

       public async Task RemoveProduct(string productName)
{
        var product = page.Locator(".cart_item")
        .Filter(new LocatorFilterOptions
        {
            HasText = productName
        });

    await product.Locator("button").ClickAsync();
}

        // cart badge displays 1
        public async Task VerifyCartCountIsOne()
        {
            await Assertions.Expect(page.Locator(".shopping_cart_badge"))
                .ToHaveTextAsync("1");
        }

        public async Task OpenCart()
        {
            await page.Locator(".shopping_cart_link").ClickAsync();
        }

        public async Task VerifyRemainingProduct(string expectedProduct)
        {
            string actualProduct = await page
                .Locator(".cart_item .inventory_item_name")
                .InnerTextAsync();

            Assert.That(actualProduct, Is.EqualTo(expectedProduct));
        }

public async Task ClickCheckout()
{
    await page.Locator("#checkout").ClickAsync();

    await Assertions.Expect(page).ToHaveURLAsync(
        "https://www.saucedemo.com/checkout-step-one.html"
    );
}
    }
}
