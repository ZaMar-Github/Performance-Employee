using AventStack.ExtentReports;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PerformanceEmployee
{
    public class Basepage
    {
        Extentreport extent = new Extentreport();
        public async Task Goto(IPage page, string url)
        {
            await page.GotoAsync(url);
            await extent.TakeScreenshot(page, Status.Pass, "Enter_URL");

        }
        public async Task Write(IPage page, string loc, string text, string stepdetail)
        {
            try
            {
                var locator = await page.QuerySelectorAsync(loc);
                if (locator != null)
                {
                    await locator.FillAsync(text);
                    Console.WriteLine($"{stepdetail} field is filled");
                    await extent.TakeScreenshot(page, Status.Pass, stepdetail);
                }
                else
                {
                    await extent.TakeScreenshot(page, Status.Fail, stepdetail);
                    Console.WriteLine($"Warning: Locator '{loc}' not found for {stepdetail}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task Type(IPage page, string loc, string text, string stepdetail)
        {
            try
            {
                var locator = await page.QuerySelectorAsync(loc);
                if (locator != null)
                {
                    await locator.TypeAsync(text);
                    Console.WriteLine($"{stepdetail} field is filled");
                    //await extent.TakeScreenshot(page, Status.Pass, stepdetail);
                }
                else
                {
                    Console.WriteLine($"{stepdetail} Not Found ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task SimpleClick(IPage page, string loc)
        {
            try
            {
                var locator = await page.QuerySelectorAsync(loc);
                if (locator != null)
                {
                    await locator.ClickAsync();
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

      
        public async Task Click(IPage page, string loc, string stepdetail)
        {
            try
            {
                var locator = await page.QuerySelectorAsync(loc);
                if (locator != null)
                {
                    await locator.ClickAsync();
                    Console.WriteLine($"{stepdetail} field is Clicked");
                    await extent.TakeScreenshot(page, Status.Pass, stepdetail);
                }
                else
                {
                    await extent.TakeScreenshot(page, Status.Fail, stepdetail);
                    Console.WriteLine($"{stepdetail} Not Found ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task SelectDropDown(IPage page, string loc, string detail)
        {
            try
            {
                // Query the dropdown element using the provided locator
                var dropdown = await page.QuerySelectorAsync(loc);

                // Click on the dropdown element
                await SimpleClick(page, loc);
                await extent.TakeScreenshot(page, Status.Pass, detail);
                // Perform keyboard actions to navigate the dropdown options
                await Keyboardaction(page, "down");
                await Keyboardaction(page, "down");
                await Keyboardaction(page, "down");
                await Keyboardaction(page, "enter");
                await extent.TakeScreenshot(page, Status.Pass, detail);
                // Log the action performed for the given detail
                Console.WriteLine($"{detail} field is Clicked");
            }
            catch (Exception ex)
            {
                await extent.TakeScreenshot(page, Status.Fail, detail);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DownTwo(IPage page, string loc, string detail)
        {
            try
            {
                // Query the dropdown element using the provided locator
                var dropdown = await page.QuerySelectorAsync(loc);

                // Click on the dropdown element
                await SimpleClick(page, loc);
                // Perform keyboard actions to navigate the dropdown options
                await Keyboardaction(page, "down");
                await Keyboardaction(page, "down");
                await Keyboardaction(page, "enter");

                // Log the action performed for the given detail
                Console.WriteLine($"{detail} field is Clicked");
            }
            catch (Exception ex)
            {
                await extent.TakeScreenshot(page, Status.Fail, detail);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        public async Task Assertion(IPage page, string selector, string expText, string stepdetail)
        {
            
            var element = await page.WaitForSelectorAsync(selector);
            if (element == null)
            {
                Assert.Fail($"No element found with selector: {selector}");
                return; // Ensure we do not proceed further if the element is null
            }

            var actualText = await element.InnerTextAsync();
            if (actualText == expText)
            {
                Assert.That(actualText, Is.EqualTo(expText), "Expected text matches the actual text.");
                await extent.TakeScreenshot(page, Status.Pass, stepdetail);
            }
            else
            {
                Assert.That(actualText, Is.Not.EqualTo(expText), "Expected text does not match the actual text.");
            }
        }

        public async Task Keyboardaction(IPage page, string action)
        {
            if (action == "up")
            {
                await page.Keyboard.PressAsync("ArrowUp");
            }
            else if (action == "down")
            {
                await page.Keyboard.PressAsync("ArrowDown");
            }
            else if (action == "tab")
            {
                await page.Keyboard.PressAsync("Tab");
            }
            else if (action == "enter")
            {
                await page.Keyboard.PressAsync("Enter");
            }
        }

        public async Task Wait(int wait)
        {
            await Task.Delay(wait);
        }
        public async Task ExecuteFunctionWithErrorHandling(IPage page, Func<IPage, Task> function)
        {
            try
            {
                await function(page); // Invoke the function asynchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                await extent.TakeScreenshot(page, Status.Fail);
            }
        }

        // Scroll down 
        public async Task ScrollDown(IPage page)
        {
            await page.EvaluateAsync("window.scrollBy(0, 500)");
            await Task.Delay(900);
        }
        // Scroll up 
        public async Task ScrollUp(IPage page)
        {
            await page.EvaluateAsync("window.scrollBy(0, -500)");
            await Task.Delay(900);
        }
    }
}




