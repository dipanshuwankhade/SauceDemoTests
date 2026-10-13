using Microsoft.Playwright;
using NUnit.Framework;

namespace SauceDemoTest.Pages
{
    public class InventoryPage
    {
        private readonly IPage page;

        public InventoryPage(IPage page)
        {
            this.page = page;
        }

        private ILocator inventoryItems =>
            page.Locator(".inventory_item");

        private ILocator cartBadge =>
            page.Locator(".shopping_cart_badge");

        public async Task<List<string>> AddFirstTwoProducts()
        {

            List<String> addedProducts = new List<String>();


            for (int i = 0; i < 2; i++)
            {
                ILocator product = inventoryItems.Nth(i);

                string productName = await product
    .Locator(".inventory_item_name")
    .InnerTextAsync();

await product.Locator("button").ClickAsync();

addedProducts.Add(productName);
            }

            return addedProducts;
        }

// cart icon displays 2 items
        public async Task AssertCartCountIsTwo()
        {
            await Assertions.Expect(cartBadge)
                .ToHaveTextAsync("2");
        }
    }
}