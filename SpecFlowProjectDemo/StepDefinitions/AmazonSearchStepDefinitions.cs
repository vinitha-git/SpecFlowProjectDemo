using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public class AmazonSearchStepDefinitions
    {
        private string searchKeyword;

        private OpenQA.Selenium.Chrome.ChromeDriver chromeDriver;

        private AmazonSearchStepDefinitions() => chromeDriver = new ChromeDriver();

        [Given(@"I have navigated to amazon website")]
        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.amazon.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("amazon"));
        }
        
        [Given(@"I have entered  (.*) as search keyword")]
        public void GivenIHaveEnteredPhoneHolderAsSearchKeyword(String searchString)
        {
          
            this.searchKeyword = searchString.ToLower();
            var searchInputBox = chromeDriver.FindElement(By.Id("twotabsearchtextbox"));
            TimeSpan.FromSeconds(2);
            searchInputBox.SendKeys(searchKeyword);
        }

 
        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElement(By.Id("nav-search-submit-button"));
            searchButton.Click();

        }

        [Then(@"I should navigate to search result page")]
        public void ThenIShouldNavigateToSearchResultPage()
        {
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyword));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyword));

        }
    }
}
