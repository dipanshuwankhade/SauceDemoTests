using System.Reflection.Metadata;
using Microsoft.Playwright;

namespace SauceDemoproject.CheckoutOverview;

class CheckoutOverviewPage
{
    IPage page;
    ILocator firstName;
    ILocator lastName;
    ILocator postalCode;
    ILocator pressContinue ;

    public CheckoutOverviewPage(IPage page)
    {
        this.page = page;
        this.firstName  = page.GetByPlaceholder("First Name");   
        this.lastName  = page.GetByPlaceholder("Last Name");      
        this.postalCode  = page.GetByPlaceholder("Zip/Postal Code");
        this.pressContinue =   page.Locator("data-test=continue");  
    }

    public async Task fillCheckoutInfo()
    {
        await firstName.FillAsync("Dipanshu"); 
        await Assertions.Expect(firstName).ToHaveValueAsync("Dipanshu");
       
        await lastName.IsDisabledAsync();
        await lastName.FillAsync("Wankhade");   
        await Assertions.Expect(lastName).ToHaveValueAsync("Wankhade");
        await postalCode.FillAsync("411030");  
    }

    public async Task ClickToContinueBtn(){
        await pressContinue.ClickAsync();
        await Assertions.Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-two.html");
    }
}