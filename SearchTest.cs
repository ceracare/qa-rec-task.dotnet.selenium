using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace qa_rec_task.dotnet.selenium;

[TestFixture]
public class Tests
{
    private IWebDriver _webDriver;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _webDriver = new ChromeDriver();
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver.Quit();
    }

    [Test]
    public void SearchSuccess()
    {
        _webDriver.Navigate().GoToUrl("https://www.bbc.co.uk/");

        _webDriver.FindElement(By.CssSelector("[href='/search']")).Click();
        _webDriver.FindElement(By.Id("search-input")).SendKeys("Sp");
        _webDriver.FindElement(By.CssSelector("[type='submit']")).Click();

        Thread.Sleep(2000);
        _webDriver.FindElement(By.CssSelector(".ssrcss-17dzqkt-ConsentButton")).Click();

        var paragraphs = _webDriver.FindElements(By.CssSelector(".ssrcss-1q0x1qg-Paragraph"));
        var text = paragraphs[0].Text;

        Assert.True(text.Contains("sport"));
    }

    // Task 2
    //[Test]
    //public async Task SearchNegativeTest(){}
}