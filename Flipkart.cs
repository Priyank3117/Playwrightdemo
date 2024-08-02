using Microsoft.Playwright;

namespace Playwrightdemo
{
    [TestFixture]
    public class Flipkart
    {
        [Test]
       public async Task fk()
        {
            using var pw = await Playwright.CreateAsync();
        
            await using var browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            var contex = await browser.NewContextAsync();

            var page = await contex.NewPageAsync();

            await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            //method for get the link using the string
            await page.GetByRole(AriaRole.Link, new()
            {
                Name = "Login",
                Exact = true,
            }).ClickAsync();

        }

    }
}
