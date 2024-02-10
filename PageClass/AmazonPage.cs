using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SpecFlowProject1.StepDefinitions;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using System.Linq.Expressions;

namespace SpecFlowProject1.PageClass
{
    [Binding]
    public class AmazonPage : SpecflowBaseTest
    {

        public AmazonPage(IWebDriver browser) : base(browser)

        {
            //_driver = browser;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-logo-sprites']")]
        private IWebElement Amazonlogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='twotabsearchtextbox']")]
        private IWebElement SearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement PhoneText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement ToyText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        private IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='add-to-cart-button']")]
        private IWebElement AddtoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='proceedToRetailCheckout']//following::a[1]")]
        private IWebElement GotoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-hamburger-menu']")]
        private IWebElement HumburgerMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Top categories')]//following::div[@class='bxc-grid__row   bxc-grid__row--light  '][1]")]
        private IWebElement TopLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='hmenu hmenu-visible']/li[16]")]
        private IWebElement mainopt { get; set; }

        public void NavigateToAmazon()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.in/");
        }

        public void ValidateAmazonLog()
        {
            bool AmazonLogresult = Amazonlogo.Displayed;
            Assert.That(AmazonLogresult);
        }

        public void SearchProduct(string Products)
        {
            SearchBar.Click();
            SearchBar.SendKeys(Products);
            SearchBtn.Click();
        }

        public void ValidateResultInfoBar(string Product)
        {
            if(Product == "phone")
            {
                string actualresult = PhoneText.Text;
                string actualresult1 = Regex.Replace(actualresult, "[^0-9A-Za-z _-]", "");
                Assert.That(Product, (Is.EqualTo(actualresult1)));
            }
            else
            {
                string actualresult = ToyText.Text;
                string actualresult1 = Regex.Replace(actualresult, "[^0-9A-Za-z _-]", "");
                Assert.That(Product, (Is.EqualTo(actualresult1)));
            }
        }

        public void SearchForAProduct()
        {
            SearchBar.Click();
            SearchBar.SendKeys("Toy");
            SearchBtn.Click();
        }

        public void SelectFirstProduct()
        {
            List<IWebElement>  prod = Driver.FindElements(By.XPath("//span[@class='a-price-symbol']")).ToList();
            int prod_count = prod.Count;
            for(int i = 0; i < prod_count; i++)
            {
                prod.First().Click();
                break;
            }
        }

        public void ClickAddtoCartButton()
        {

            IList<string> totWindowHandles = new List<string>(Driver.WindowHandles);
            int win_count = totWindowHandles.Count;
            if (win_count > 1)
            {
                Driver.SwitchTo().Window(totWindowHandles[1]);
                AddtoCartBtn.Click();
                GotoCartBtn.Click();
            }
            else
            {
                AddtoCartBtn.Click();
                GotoCartBtn.Click();
            }
        }
        
        public void ValidateProductAddedCart()
        {
            WebElement prodcart = (WebElement)Driver.FindElement(By.XPath("//h1[contains(text(),'Shopping Cart')]"));
            bool prodcartresult = prodcart.Displayed;
            Assert.That(prodcartresult);
        }

        public void SelectHumburgerMenu()
        {
            HumburgerMenu.Click();
        }

        public void SelectMainOption()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(mainopt).Click().Build();
            actions.Perform();
            //mainopt.Click();
            //List<IWebElement> mainoptionsele = Driver.FindElements(By.XPath("//ul[@class='hmenu hmenu-visible']//following::a[@data-menu-id='8']")).ToList();
            //int mainoptions_count = mainoptionsele.Count;
            //for (int i = 0; i < mainoptions_count; i++)
            //{
            //    WebElement mainopt = (WebElement)mainoptionsele.First();
            //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //    mainopt.Click();
            //    break;
            //}
        }

        public void SelectSubOption()
        {

            List<IWebElement> suboptionsele = Driver.FindElements(By.XPath("//div[contains(text(),'Mobiles, Tablets & More')]//following::li[11]")).ToList();
            int suboptions_count = suboptionsele.Count;
            for (int i = 0; i < suboptions_count; i++)
            {
                WebElement subopt = (WebElement)suboptionsele.First();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                subopt.Click();
                break;
            }
        }

        public void ValidateCategoriesLog()
        {
            bool Topcat = TopLogo.Displayed;
            Assert.That(Topcat);
        }
    }

}
