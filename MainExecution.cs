using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PerformanceEmployee;


namespace PerformanceEmployee
{
   
        public class MainExecution : PageTest
        {
            Loginpage login = new Loginpage();
            Dashboard dash = new Dashboard();
            Feedback feedback = new Feedback();
            Extentreport extent = new Extentreport();
            [SetUp]
            public void Setup()
            {
                extent.LogReport("PerformanceEmployee");
            }
            [TearDown]
            public void Teardown()
            {
                extent.flush();
            }
            [Test]
           public async Task Login()
            {
                await login.Login(Page);
            }

           
            public async Task DashboardScreen()
            {
                await Login();
                await dash.CriteriaMap(Page);

            }

            public async Task FeedbackScreen()
            {
                await DashboardScreen();
                await Task.Delay(3000);
                //await Login();
                await feedback.CheckScores(Page);
                await Task.Delay(2000);
                await feedback.FilterOut(Page);
                await Task.Delay(3000);

            }

        }
    }







