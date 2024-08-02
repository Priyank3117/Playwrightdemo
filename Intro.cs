using Microsoft.Playwright;


namespace Playwrightdemo
{
    [TestFixture]
    public class Intro 
    {

        [Test]
        public async Task test1()
        {
            //create instance of the playwright
            using var pw = await Playwright.CreateAsync();

            //create browser
            await using var browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            //page creation
            var Page = await browser.NewPageAsync();

            await Page.GotoAsync(url: "https://qa.solv.com.au/#/app/login");

            await Page.FillAsync(selector: "#account_username", value: "practical.user@automation.com");
            await Page.FillAsync(selector: "#account_password", value: "Automation@123");

            var loginButton = Page.Locator("//input[@type='button']");
            loginButton.ClickAsync();

        }
    }
}
