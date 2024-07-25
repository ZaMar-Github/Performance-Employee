using Microsoft.Playwright;
using PerformanceEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PerformanceEmployee
{
    public class Dashboard
    {

        Basepage bp = new Basepage();
        Extentreport extent = new Extentreport();

        public async Task CriteriaMap(IPage page)
        {
            extent.ParentLog("Dashboard");
            extent.ChildLog("Action Performed");
            await bp.SelectDropDown(page, "//div[text()=' Criterias ']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Select Random Time Frames in Criteria Chart");
            await bp.SelectDropDown(page, "//div[text()=' Overall Performance ']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Select Random Time Frames in Over All Perfomace chart");

            // Wait for the element to be visible
            var element = await page.WaitForSelectorAsync("//div[@class='dashboad']//div[@class='grid']//div[3]//div[text()=' Behaviour ']//parent::div//span[text()='Current Month']");

            // Get the text content of the element
            var textContent = await element.InnerTextAsync();

            // Print the text content
            System.Console.WriteLine(textContent);
           await bp.SelectDropDown(page, "//div[@class='dashboad']//div[@class='grid']//div[3]//div[text()=' Behaviour ']//parent::div//span[text()='Current Month']", "Select Random Criterias is Behaviour Chart");

        
            await bp.SelectDropDown(page, "//div[text()=' Criterias Chart ']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Select Random Time Frame in Criterias Chart");
            await bp.DownTwo(page, "//div[text()='Star Performer ']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Select Random Time Frames in Star Performer dropdown");
            await bp.ScrollUp(page);
            await bp.Wait(2000);
           

        }


    }
}


