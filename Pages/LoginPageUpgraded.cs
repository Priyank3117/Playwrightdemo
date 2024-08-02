using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwrightdemo.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;
        public LoginPageUpgraded(IPage page) => _page = page;


        private ILocator UserName => _page.Locator("#account_username");
        private ILocator Password => _page.Locator("#account_password");
        private ILocator LoginButton => _page.Locator("//input[@type='button']");
        public ILocator WlcmText => _page.Locator(".wrdBreak");

        public async Task Login(string username, string password)
        {
            await UserName.FillAsync(username);
            await Password.FillAsync(password);

        }

        [Obsolete]
        public async Task ClickLogin()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await LoginButton.ClickAsync();

            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/safety"
            }); 
        }


    }
}
