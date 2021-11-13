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
            

        }
        [When(@"I press sell")]
        public void WhenIPressSell()
        {
            Assert.IsTrue(chromeDriver.FindElement(By.XPath("//*[@id='nav-xshop']/a[5]")).Displayed);
            chromeDriver.FindElement(By.XPath("//*[@id='nav-xshop']/a[5]")).Click();


        }

        [Then(@"I should navigate to sell result page")]
        public void ThenIShouldNavigateToSellResultPage()
        {
           var sell = chromeDriver.FindElement(By.XPath("//*[@id='a - page']/div[2]/div/div/div/div/div/div[1]/div/div[2]/div/div[1]/h2")).Text;
            TimeSpan.FromSeconds(2);
            Assert.IsTrue(sell.Contains("Sell on Amazon"));
        }       
        [Then(@"I should navigate to Gift Cards result page")]
        public void ThenIShouldNavigateToGiftCardsResultPage()
        {
            TimeSpan.FromSeconds(2);
            var giftCards = chromeDriver.FindElement(By.XPath("//*[@id='contentGrid_320568']/div/div[1]/div/div/div/h1")).Text;
            TimeSpan.FromSeconds(2);
            Assert.IsTrue(giftCards.ToLower().Contains("gift"));
        }
        [When(@"I press sell button")]
        public void WhenIPressSellButton()
        {
            var sellButton = chromeDriver.FindElement(By.XPath("//*[@id='nav-xshop']/a[5]"));
            TimeSpan.FromSeconds(5);
            sellButton.Click();
        }

        [When(@"I press Gift Cards button")]
        public void WhenIPressGiftCardsButton()
        {
            var GiftButton = chromeDriver.FindElement(By.XPath("//*[@id='nav-xshop']/a[4]"));
            TimeSpan.FromSeconds(5);
            GiftButton.Click();
        }



    }
}
