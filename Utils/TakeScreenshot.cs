using System.Runtime.CompilerServices;
using Microsoft.Playwright;

class TakeScreenshot
{
    IPage page;

    public TakeScreenshot(IPage page)
    {
        this.page = page;
    }

    public async Task screenshot(string screenshotName)
    {
        await page.ScreenshotAsync(
            new PageScreenshotOptions
            {
                Path = screenshotName+".jpg"
            }
        );
    }
}