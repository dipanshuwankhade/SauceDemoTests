using System.Runtime.CompilerServices;
using Microsoft.Playwright;

namespace SauceDemoproject.inventory;

class InventoryPage
{
    IPage page;
    ILocator addToCart;

    ILocator cartCatalog;

    List<string> cartProduct;



    public InventoryPage(IPage page)
    {
        this.page = page;
        this.addToCart = page.GetByRole(AriaRole.Button, new(){Name="Add to cart"});
        this.cartCatalog = page.Locator(".shopping_cart_link");
        this.cartProduct = new List<string>();
    }    

    public async Task addProductsToCart()
    {
        for(int i=0; i<2; i++)
        {
            cartProduct.Add(await page.Locator(".inventory_item_name ").Nth(i).InnerTextAsync());
            await addToCart.First.ClickAsync();
        }
    }


    public async Task veryCartCatalogue()
    {
        await Assertions.Expect(cartCatalog).ToHaveTextAsync("2");
    }

    public async Task goToCart()
    {
        await cartCatalog.ClickAsync();
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/cart.html");
    }
}