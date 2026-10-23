using System.Drawing;
using Microsoft.Playwright;

namespace PracticeOne
{

    public class LoginPage
    {
       private IPage page;

        public LoginPage(IPage page)
        {
            this.page = page;
        }

        //locator
        private ILocator Username
        {
            get
            {
                return page.Locator("#user-name");
            }
        }

        private ILocator Password => page.Locator("#password");

        private ILocator LoginButton => page.Locator("#login-button");
        
        public async Task EnterUsername(String username)
        {
            await Username.FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await Password.FillAsync(password);
        }

        public async Task ClickLogin()
        {
            await LoginButton.ClickAsync();
        }

        public async Task Login(String user, string password)
        {
            await EnterUsername(user);
            await EnterPassword(password);
            await ClickLogin();
        }
        
       
    }
}