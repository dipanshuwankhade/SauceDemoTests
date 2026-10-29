using Microsoft.Playwright;

namespace SauceDemoproject;

class LoginPage
{
    private IPage page;
    private ILocator userNameTextField;
    private ILocator userPassword;
    private ILocator loginBtn;
    public LoginPage(IPage page)
    {
        this.page = page;
        this.userNameTextField = page.GetByPlaceholder("Username");
        this.userPassword = page.GetByPlaceholder("Password");
        this.loginBtn = page.Locator("#login-button");
    }

    public async Task login(string username , string password)
    {
        await userNameTextField.FillAsync(username);
        await userPassword.FillAsync(password);
        await loginBtn.ClickAsync();

    }
}