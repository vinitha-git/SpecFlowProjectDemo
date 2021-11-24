using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public class AmazonSearchStepDefinitions
    {
        private string searchKeyword;

        private  ChromeDriver  chromeDriver;

        private AmazonSearchStepDefinitions() => chromeDriver = new ChromeDriver();

        [Given(@"I have navigated to amazon website")]
        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.amazon.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("amazon"));
        }
        
        [Given(@"I have entered .* as search keyword")]
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
            TimeSpan.FromSeconds(2);
         
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains("sell"));
        }       
        [Then(@"I should navigate to Gift Cards result page")]
        public void ThenIShouldNavigateToGiftCardsResultPage()
        {
            TimeSpan.FromSeconds(2);
            
             Assert.IsTrue(chromeDriver.Url.ToLower().Contains("gift"));
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
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='nav-xshop']/a[4]")));            var GiftButton = chromeDriver.FindElement(By.XPath("//*[@id='nav-xshop']/a[4]"));
            TimeSpan.FromSeconds(5);
            GiftButton.Click();
        }



    }
}
