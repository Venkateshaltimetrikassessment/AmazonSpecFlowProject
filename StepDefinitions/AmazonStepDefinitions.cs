using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using SpecFlowProject1.PageClass;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using Microsoft.VisualBasic.FileIO;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AmazonStepDefinitions : SpecflowBaseTest
    {
        private AmazonPage _amazonPage { get; }
        protected IWebDriver Driver;

        public AmazonStepDefinitions(AmazonPage amazonPage, IWebDriver driver) : base(driver)
        {
            Driver = driver;
            this._amazonPage = new AmazonPage(driver);
        }
        [Given(@"navigate to amazon portal")]
        public void GivenNavigateToAmazonPortal()
        {
            _amazonPage.NavigateToAmazon();
        }

        [Given(@"validate amazon log")]
        public void GivenValidateAmazonLog()
        {
            _amazonPage.ValidateAmazonLog();
        }

        [Given(@"select the Humburger menu button")]
        public void GivenSelectTheHumburgerMenuButton()
        {
            _amazonPage.SelectHumburgerMenu();
        }
        [When(@"search the (.*)")]
        public void WhenSearchThe(string Products)
        {
            _amazonPage.SearchProduct(Products);
        }

        [Then(@"validate the (.*)")]
        public void ThenValidateThePhone(string Products)
        {
            _amazonPage.ValidateResultInfoBar(Products);
        }
        [Given(@"search for a product")]
        public void AndSearchForAProduct()
        {
            _amazonPage.SearchForAProduct();
        }
        [Given(@"select the first product")]
        public void AndSelectTheFirstProduct()
        {
            _amazonPage.SelectFirstProduct();
        }
        [When(@"click add to cart button")]
        public void WhenClickAddToCartButton()
        {
            _amazonPage.ClickAddtoCartButton();
        }
        [Then(@"validate product added to the cart")]
        public void ThenValidateProductAddedToTheCart()
        {
            _amazonPage.ValidateProductAddedCart();
        }
        [When(@"select mainoption MobilesComputers")]
        public void WhenSelectMainoptionMobilesComputers()
        {
            _amazonPage.SelectMainOption();
        }

        [When(@"select suboption Software")]
        public void WhenSelectSuboptionSoftware()
        {
            _amazonPage.SelectSubOption();
        }
        [Then(@"validate log is present under Topcategories section")]
        public void ThenValidateLogIsPresentUnderTopcategoriesSection()
        {
            _amazonPage.ValidateCategoriesLog();
        }

    }
}
