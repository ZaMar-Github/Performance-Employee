using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEmployee
{
    public class Extentreport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static ExtentTest exGrandChildTest;
        public static string dirpath;
        public static string pathWithFileNameExtension;
        public void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"C:\Users\ZamarKhan\source\PerformanceEmployee\Screenshots\" + "_" + testcase;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }
        public async Task TakeScreenshot(IPage page, Status status, string stepDetail = "")
        {
            string path = @"C:\Users\ZamarKhan\source\PerformanceEmployee\Screenshots\" + stepDetail;
            pathWithFileNameExtension = @path + ".png";
            await page.Locator("body").ScreenshotAsync(new LocatorScreenshotOptions { Path = pathWithFileNameExtension });
            TestContext.AddTestAttachment(pathWithFileNameExtension);
            // Ensure exGrandChildTest is not null before logging
            if (exGrandChildTest != null)
            {
                exGrandChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(pathWithFileNameExtension).Build());
            }
            else if (exChildTest != null)
            {
                exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(pathWithFileNameExtension).Build());
            }
            else
            {
                exParentTest?.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(pathWithFileNameExtension).Build());
            }
            //exChildTest.Log(status, stepDetail, MediaEntityBuilder
            //    .CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public void ParentLog(string Pnode)
        {
            exParentTest = extentReports.CreateTest(Pnode);
        }
        public void ChildLog(string Childlog)
        {
            exChildTest = exParentTest.CreateNode(Childlog);
        }
        public void GrandChildLog(string GrandChildlog)
        {
            exGrandChildTest = exChildTest.CreateNode(GrandChildlog);
        }
        public void flush()
        {
            extentReports.Flush();
        }
    }
}

 