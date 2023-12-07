// Copyright Information
// ==================================
// SoftwareTesting - PlaywrightTests - UserInterfaceTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace PlaywrightTests;

public class UserInterfaceTests

{
    //https://medium.com/version-1/playwright-a-modern-end-to-end-testing-for-web-app-with-c-language-support-c55e931273ee#:~
    [Fact]
    public static async Task VerifyGoogleSearchForPlaywright()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser = 
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        // Function to perform login test
        async Task TestLoginAsync(string username, string password)
        {
            IPage page = await context.NewPageAsync();
            // Navigate to letsusedata login page
            await page.GotoAsync("https://www.letsusedata.com/index.html");

            // Fill in the username and password
            await page.FillAsync("#txtUser", username);
            await page.FillAsync("#txtPassword", password);

            // Click on the login button
            await page.ClickAsync("button:has-text('Login')");

            // Add logic to verify successful login, e.g., checking for a specific element that appears after login
            // Example: Assert.True(await page.IsVisibleAsync("selector-for-element-visible-after-login"));

            await page.CloseAsync();
        }

        // Test login for Test1
        await TestLoginAsync("Test1", "12345678");

        // Test login for Test2
        await TestLoginAsync("Test2", "iF3sBF7c");
    }
}