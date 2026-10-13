
using Microsoft.Playwright;

namespace SauceDemoTest
{
    public class LoginPage
    {
        private IPage page;

        public LoginPage(IPage page)
        {
            this.page = page;
        }

        //locator
        private ILocator Username => page.Locator("#user-name");
        private ILocator Password => page.Locator("#password");
        private ILocator LoginButton => page.Locator("#login-button");

        public async Task EnterUsername(string user)
        {
            await Username.FillAsync(user);
        }

        public async Task EnterPassword(string pass)
        {
            await Password.FillAsync(pass);
        }

        public async Task ClickLogin()
        {
            await LoginButton.ClickAsync();
        }

//login
        public async Task Login(string user, string pass)
        {
            await EnterUsername(user);
            await EnterPassword(pass);
            await ClickLogin();
        }
    }
}
