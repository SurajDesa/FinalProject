namespace PlaywrightTests;

public class UserInterfaceTests
{
    [Fact]
    public static async Task VerifyLetsUseDataLogin()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser = 
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        // Function to perform login test
        async Task TestLogin(string username, string password)
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
        await TestLogin("Test1", "12345678");

        // Test login for Test2
        await TestLogin("Test2", "iF3sBF7c");
    }
}
