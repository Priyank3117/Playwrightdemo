using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwrightdemo.Pages;

namespace Playwrightdemo
{
    [TestFixture]
    public class playwright_Pagetest : PageTest
    {
        [SetUp]
        public async Task setup()
        {

            await Page.GotoAsync(url: "https://qa.solv.com.au/#/app/login");
            
        }

        [Test]
        public async Task Pagetest()
        {
            //here the Pagetest class we inherit is provide by
            //Microsoft.Playwright.NUnit

            //it instanciate the playwright obj --> set up browser and context --> Pages for us
            //direclty use the method of Pages


            await Page.FillAsync(selector: "#account_username", value: "practical.user@automation.com");
            await Page.FillAsync(selector: "#account_password", value: "Automation@123");

            var loginButton = Page.Locator("//input[@type='button']");
            loginButton.ClickAsync();


            //it's used like assertion and pass arguments
            await Expect(Page.Locator(".wrdBreak")).ToHaveTextAsync("Welcome to SolvSafety", new LocatorAssertionsToHaveTextOptions
            {
                Timeout = 10000,

            });

        }

        [Test]
        public async Task Pomtest()
        {
            LoginPage loginPage = new LoginPage(Page);

            await loginPage.Login(username: "practical.user@automation.com", password: "Automation@123");
            await Expect(loginPage.IsDashBoardVisible()).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
            {
                Timeout = 10000
            });;
           

        }

        [Test]
        [Obsolete]
        public async Task PomTestUpgraded()
        {
            LoginPageUpgraded loginPageUpgraded = new LoginPageUpgraded(Page);

            await loginPageUpgraded.Login(username: "practical.user@automation.com", password: "Automation@123");
            await loginPageUpgraded.ClickLogin();
            await Expect(loginPageUpgraded.WlcmText).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
            {
                Timeout = 10000
            });;
           

        }
    }
}
