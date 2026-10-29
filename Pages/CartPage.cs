using Microsoft.Playwright;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace SauceDemoproject.Cart;


class CartPage
{
    IPage page;
    ILocator remove ;

    ILocator checkout;
    
    public CartPage(IPage page)
    {
        this.page = page;
        this.remove = page.GetByRole(AriaRole.Button,new(){Name="Remove"});
        this.checkout = page.GetByRole(AriaRole.Button, new(){Name="Checkout"});
    }
    
    public async Task removeProduct()
    {
        await remove.First.ClickAsync();
    }

    public async Task clickToCheckout(){
        await checkout.ClickAsync();
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-one.html");
    }
}