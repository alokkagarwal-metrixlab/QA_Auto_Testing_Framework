using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace QA_Auto_Testing_Framework
{
    class MainTest
    {
        //MainTests test = new MainTests();
        
        public IWebDriver driver;
        private String BaseURL = "https://dashboards.insights.metrixlab.com/";
        public TestContext TestContext { get; set; }
        //System.DateTime currentdatetime = System.DateTime.Now;        
        public WebDriverWait wait;

        /*public String currentdatetime()
        {
            DateTime now = DateTime.Now;
            string cdt1 = now.ToString("ddMMMMyyyy_hhmmsstt");
            return cdt1;
        }*/

        public IWebElement elem;

        [SetUp]

        public void startBrowser()
        {
            Console.WriteLine("Initializing start browser method.");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [NUnit.Framework.Test]        

        public void Login()
        {
            //Console.WriteLine("Initializing Login Method.");
            try
            {
                driver.Navigate().GoToUrl(BaseURL + "/");
                driver.FindElement(By.Id("UserName")).SendKeys("alok.agarwal@metrixlab.com");
                driver.FindElement(By.Id("Password")).SendKeys("MetrixLab9#");
                driver.FindElement(By.Id("divLogin")).Click();
                driver.Navigate().GoToUrl(BaseURL + "/Dashboard/Dashboard/?ProjectId=48316&ProjectDashboardId=22");

                //Click on the filter icons button
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@class='filter_icons_wrapper']")).Click();

                //Click on the calendar button
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//span[contains(text(),'Calendar')]")).Click();

                //Click on the Select All Filter button
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@value='All']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@value='All']")).Click();

                //Click on Apply filter button
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@class='filters-apply']")).Click();

                //Click on the filter icon to close the filter menu
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@class='filter_icons_wrapper']")).Click();

                //Delete the filter
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@class='delete_chosen_filter dcf_top']")).Click();

                //Click on Global Export Icon
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@class='toggle_btn toggle_btn_white export_all_widget']")).Click();
                Console.WriteLine("Clicked on Global Export Button");

                /*
                //Click on Export & Manage Button
                Thread.Sleep(240000);
                elem = driver.FindElement(By.XPath("//*[@class='export_option_btn btn_white open_modal']"));
                //Actions actions = new Actions(driver);
                //actions.MoveToElement(elem).Click().Build().Perform();

                //IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
                //jse2.ExecuteScript("arguments[0].scrollIntoView()", elem);
                //WebDriverWait wait2 = new WebDriverWait(driver, 10);
                //wait2.Until(ExpectedConditions.elementToBeClickable(By.id("navigationPageButton")));

                elem.SendKeys(Keys.Control + Keys.Separator);
                elem.SendKeys(Keys.Control + Keys.Separator);
                elem.SendKeys(Keys.Control + Keys.Separator);
                elem.SendKeys(Keys.Control + Keys.Separator);
                elem.SendKeys(Keys.Control + Keys.Separator);

                if (elem.Displayed == true)
                {
                    Console.WriteLine("We can click on Export & Manage Button.");
                    elem.Click();
                } else
                    Console.WriteLine("Cannot Click on Export & Manage Button.");

                Thread.Sleep(3000);
                elem.SendKeys(Keys.Control + (0));

                //Click on the Download button the on popup window
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//div[contains(@class,'toolbar_btn btn_grey') and .//text()='Download']")).Click();
                Console.WriteLine("Clicked on Download Button.");
                
                //Delete All the Images from the Export Panel
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//div[contains(@class,'toolbar_btn btn_white') and .//text()='Delete selected']")).Click();
                Console.WriteLine("Clicked on Delete Images Button");
                //Click on Close Button To Close the Modal Window
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//div[1][text()='Close']")).Click();
                */

                //Click on Logout Button
                Thread.Sleep(10000);
                driver.FindElement(By.XPath("//*[@id='cssmenu']/ul/li[2]/div/a")).Click();
                Thread.Sleep(3000);

                Assert.IsTrue(true, "The tests have passed.");

            }
            catch (Exception ex)
            {                
                //return false;
                Console.WriteLine(@"Error occurred on: " + ex.ToString());
                Assert.IsFalse(true, "The tests have failed.");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
