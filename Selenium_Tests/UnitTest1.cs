using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace Selenium_Tests
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.google.com";
        }
        [Test]
        public void Test1()
        {
            //Googling the schedule website
            var search_text = driver.FindElement(By.Name("q"));
            search_text.SendKeys("Розклад КПІ"); //KPI schedule
            search_text.SendKeys(Keys.Enter);

            //Getting the first link of the result
            driver.FindElement(By.ClassName("yuRUbf")).Click();

            //Searching schedule of specified group
            var search_bar = driver.FindElement(By.Id("ctl00_MainContent_ctl00_txtboxGroup"));
            search_bar.SendKeys("КП-93");
            search_bar.SendKeys(Keys.Enter);

            //Getting the first subject on wednesday from schedule table
            var found_text = driver.FindElements(By.TagName("tr"))[1].FindElements(By.TagName("td"))[3].FindElement(By.TagName("a")).Text;
            string desired_subject = "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення"; //Computer Engineering 2. Software Quality and Testing

            //Comparing found subject with desired. Test will pass only if they're equal
            Assert.AreEqual(desired_subject, found_text);
        }
        [Test]
        public void Test2()
        {
            //Googling Epicenter website
            var search_text = driver.FindElement(By.Name("q"));
            search_text.SendKeys("Епіцентр"); //Epicenter
            search_text.SendKeys(Keys.Enter);

            //Getting the first link of the result
            driver.FindElement(By.ClassName("yuRUbf")).Click();

            //Moving to Contacts section
            driver.FindElement(By.CssSelector("a[title=\"Контакти\"]")).SendKeys(Keys.Enter); //title="Contacts"

            //Getting call center working hours info
            string found_text = driver.FindElement(By.ClassName("company__content")).FindElement(By.TagName("h3")).Text;
            string working_hours = "з 07:30 до 22:30"; //from 07:30 to 22:30

            //Checking that call center works at specified hours. Test will pass only if specified hours occur in found string
            Assert.That(found_text.Contains(working_hours), $"Epicenter's call center does not work {working_hours}");
        }
        [Test]
        public void Test3()
        {
            //Googling specified video
            string video_title = "Never Gonna Give You Up";
            var search_text = driver.FindElement(By.Name("q"));
            search_text.SendKeys(video_title);
            search_text.SendKeys(Keys.Enter);

            //Getting the first video result
            driver.FindElement(By.ClassName("H1u2de")).Click();

            //Waiting until the page is fully loaded
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);

            //Getting current view count
            string views = driver.FindElement(By.XPath("//span[@class=\"view-count style-scope ytd-video-view-count-renderer\"]")).Text;
            int actual_views = int.Parse(Regex.Replace(views, @"[^\d]", ""));
            int expected_views = 1_000_000_000;

            //Checking whether video has specified amount of views. Test will pass only if video has more views than expected
            Assert.That(actual_views>=expected_views, $"Specified video ({video_title}) hasn't reached {expected_views} views yet");
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}