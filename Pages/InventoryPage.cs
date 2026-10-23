using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PracticeOne.Pages
{
    public class InventoryPage
    { 
       private readonly IPage page;

       public InventoryPage(IPage page)
        {
            this.page = page;
        }

        private ILocator invenotryItems => page.Locator(".inventory_item");
       
        private ILocator cartBadge => page.Locator(".shopping_cart_badge");
        public async Task<List<string>> AddFirstTwoProducts()
        {
            List<string>  addedProducts = new List<string>();

            for (int i=0; i<2; i++)
            {
                ILocator product = invenotryItems.Nth(i);
                string productName = await product.Locator(".inventory_item_name").InnerTextAsync();
                await product.Locator("button").ClickAsync();

                addedProducts.Add(productName);
            }   
            return addedProducts;
        } 


         public async Task validateCart()
        {
            await Assertions.Expect(cartBadge).ToHaveTextAsync("2");     
        }
    }
}