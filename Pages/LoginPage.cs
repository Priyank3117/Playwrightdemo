using Microsoft.Playwright;

namespace Playwrightdemo.Pages
{
    public class LoginPage
    {
        //make the page object model

        private  IPage _page;
        private readonly ILocator _loginLink;
        private readonly ILocator _userName;
        private readonly ILocator _password;
        private readonly ILocator _loginButton;
        private readonly ILocator _wlcmText;

        public LoginPage(IPage page)
        {
            _page = page;
            _userName = _page.Locator("#account_username");
            _password = _page.Locator("#account_password");
            _loginButton = _page.Locator("//input[@type='button']");
            _wlcmText = _page.Locator(".wrdBreak");

        }

        public async Task Login(string username, string password)
        {
            await _userName.FillAsync(username);
            await _password.FillAsync(password);
            await _loginButton.ClickAsync();
        }

        public ILocator IsDashBoardVisible() => _wlcmText;
    }
}
