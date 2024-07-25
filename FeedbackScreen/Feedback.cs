using Microsoft.Playwright;
using PerformanceEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PerformanceEmployee
{
    public class Feedback
    {
        Basepage bp = new Basepage();

        public async Task CheckScores(IPage page)
        {
          await page.GetByRole(AriaRole.Link, new() { Name = "Feedback" }).ClickAsync();
          await bp.Wait(2000);
          await bp.SelectDropDown(page, "//div[text()=' Category Score ']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Category score dropdown");
          await bp.Wait(900);
          await bp.SelectDropDown(page, "//div[text()='Score By Manager']/parent::div//parent::div//div[contains(@class,'smallDropdown')]", "Score By Manager Dropdown");
          await bp.Wait(900);

        }
        
        // Check Filters
        public async Task FilterOut(IPage page)
        {
            await bp.Wait(900);
            await bp.SelectDropDown(page, "//div//label[text()='Filter by Project ']/parent::div/dropdown-control", "Projects Dropdown");
            await bp.Wait(1000);
            await bp.SelectDropDown(page, "//div//label[text()='Filter by Project ']//..//i", "reset project filter");
            await bp.Click(page, "//label[text()='Filter by Date ']//..//button", "Calender");
            await bp.Wait(900);
            await bp.SimpleClick(page, "//span/div/div/div/div[1]/button[1]");
            await bp.Wait(800);
            await bp.SimpleClick(page, "//span/div/div/div/div[2]/table/tbody/tr[1]/td[7]/span");
            await bp.Wait(800);
            await bp.SimpleClick(page, "//span/div/div/div/div[1]/button[2]");
            await bp.Wait(900);
            await bp.SimpleClick(page, "//span/div/div/div/div[2]/table/tbody/tr[3]/td[5]/span");
            await bp.Wait(1000);
            await bp.Click(page, "//p-paginator/div/span[2]/button", "Click outside");
            await bp.Wait(1000);
            await bp.SimpleClick(page, "//div/div[2]/div[1]/checkbox-control/div/div/p-checkbox/div");
            await bp.Wait(1000);
            await bp.SimpleClick(page, "//div/div[2]/div[1]/checkbox-control/div/div/p-checkbox/div");
            await bp.Click(page, "//div/div/div[2]/feedback/div/div/div[2]/div/div/div[2]/div/div[2]/div[2]/span/input", "Click on search field");  
            await bp.Click(page, "//tr[1]/td[8]/div/div/button-control", "Click on Log button");
            await bp.Type(page, "//div/div/div[2]/feedback/div/div/div[2]/div/div/div[2]/div/div[2]/div[2]/span/input", "Testing", "Enter Keyword in Search field");
            await bp.Click(page, "//p-dynamicdialog/div/div/div[1]/span", "Click on Detail heading");
            await bp.Wait(900);
            await bp.Click(page, "//div/div/div[1]/div/button", "Click on Detail heading");
            await bp.Wait(900);

        }

    }
}
