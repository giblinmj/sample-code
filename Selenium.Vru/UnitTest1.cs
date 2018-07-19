using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Vru;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;



namespace Selenium.Vru
{
    public class PolicyPopup
    {
        private IWebDriver _driver;

        public PolicyPopup(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "policy-popup")]
        private IWebElement _popPolicy;

        [FindsBy(How = How.ClassName, Using = "fancybox-item fancybox-close")]
        private IWebElement _Close;

        public string Text()
        {
            return _popPolicy.Text;
        }

        public void Close()
        {
            _Close.Click();
        }

    }

    public class HomeOwner
    {
        private IWebDriver _driver;
        public PolicyPopup Policy;

        public HomeOwner(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);

            Policy = new PolicyPopup(_driver);
    }



        [FindsBy(How = How.ClassName, Using = "int-img-header")]
        private IWebElement _pageName;

        //Coverage for  Fire, Lightning, theft, Wind coverage

        [FindsBy(How = How.ClassName, Using = "logo-wrap fire")]
        private IWebElement _fire;

        [FindsBy(How = How.CssSelector, Using = "img[src*='fire.png']")]
        private IWebElement _fireImg;

        [FindsBy(How = How.ClassName, Using = "logo-wrap lightning")]
        private IWebElement _lightning;

        [FindsBy(How = How.CssSelector, Using = "img[src*='lightning.png']")]
        private IWebElement _lightningImg;

        [FindsBy(How = How.ClassName, Using = "logo-wrap theft")]
        private IWebElement _theft;

        [FindsBy(How = How.CssSelector, Using = "img[src*='theft.png']")]
        private IWebElement _theftImg;

        [FindsBy(How = How.ClassName, Using = "logo-wrap wind")]
        private IWebElement _wind;

        [FindsBy(How = How.CssSelector, Using = "img[src*='wind.png']")]
        private IWebElement _windImg;

        [FindsBy(How = How.ClassName, Using = "btn bg-green fancybox")]
        public IWebElement btnUnderstandYourPolicy;

        [FindsBy(How = How.ClassName, Using = "policy-popup")]
        public IWebElement popPolicy;

        [FindsBy(How = How.ClassName, Using = "fancybox-item fancybox-close")]
        public IWebElement btnClose;


        public string PageName()
        {
            return _pageName.Text.Trim();
        }

        public bool IsDisplayedFire()
        {
            if (_fire.Text.Trim() == "Fire" && _fireImg.Displayed == true)
            { return true; }
            else
            { return false; }
        }

        public bool IsDisplayedLightning()
        {
            if (_lightning.Text.Trim() == "Lightning" && _lightningImg.Displayed == true)
            { return true; }
            else
            { return false; }
        }

        public bool IsDisplayedTheft()
        {
            if (_theft.Text.Trim() == "Theft" && _theftImg.Displayed == true)
            { return true; }
            else
            { return false; }
        }

        public bool IsDisplayedWind()
        {
            if (_wind.Text.Trim() == "Wind Damage" && _windImg.Displayed == true)
            { return true; }
            else
            { return false; }
        }
    }

    public class Leadership
    {
        private IWebDriver _driver;

        public Leadership(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string PageName()
        {
            return _pageName.Text.Trim();
        }

        [FindsBy(How = How.ClassName, Using = "int-img-header")]
        private IWebElement _pageName;

        public string Search(string Critera)
        {
            System.Collections.Generic.IList<IWebElement> rows = _driver.FindElements(By.ClassName("col-md-10 col-sm-9"));

            Console.WriteLine("Leadership Search : " + Critera);
            foreach (IWebElement row in rows)
            {
                if (row.Text.Contains(Critera))
                    return row.Text.Substring(0, row.Text.IndexOf(Environment.NewLine)).Trim();
            }
            return null;
        }




    }

    public class Menu
    {
        private IWebDriver _driver;
        private IWebElement _Product;
        private IWebElement _Personal;
        private IWebElement _HomeOwner;


        public Menu(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        private void Menu_Element()
        {
            _Product = _driver.FindElement(By.CssSelector("a[href*='/products']"));
            _Personal = _driver.FindElement(By.CssSelector("a[href*='/personal']"));
            _HomeOwner = _driver.FindElement(By.CssSelector("a[href*='/home-owners']"));
        }

        private void Wait(int Seconds)
        { System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Seconds)); }

        public void Products()
        {
            this.Menu_Element();
            //Actions action = new Actions(_driver);
            //action.MoveToElement(_Product).Perform();
            //action.MoveToElement(_Product).Click().Perform();

            _Product.Click();
            this.Wait(2);
            _Product.Click();
            this.Wait(2);

        }
 
        public void Products_Personal()
        {
            this.Menu_Element();

            _Product.Click();
            this.Wait(2);
            _Personal.Click();
            this.Wait(2);
            _Personal.Click();
            this.Wait(2);

        }

        public void Products_Personal_Homeowners()
        {
            this.Menu_Element();

            _Product.Click();
            _Personal.Click();
            _HomeOwner.Click();
            this.Wait(2);
        }

        public void Products_Personal_FloridaTakeout()
        { }

        public void Commercial()
        { }

        public void Commercial_Overview()
        { }

    }



    public class VelocityRisk
    {
        private IWebDriver _driver;
        public Menu Menu;


        public VelocityRisk(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);

            Menu = new Menu(_driver);
        }



        public string PageName()
        {
            return _driver.FindElement(By.ClassName("int-img-header")).Text.Trim();
        }



    }



    [TestClass]
    public class UnitTest1
    {
        static string driverLocationEdge = @"C:\WebDriver";
        EdgeDriver _driver = new EdgeDriver(driverLocationEdge);

        string url = "www.velocityrisk.com";

        [TestMethod]
        public void VerifyPageNames()
        {
            IWebDriver driver = _driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            var app = new VelocityRisk(driver);

            app.Menu.Products();
            Assert.AreEqual("Products", app.PageName(), "Verify the page is Products");
            Console.WriteLine("Verify the page is Products : " + app.PageName());

            app.Menu.Products_Personal();
            Assert.AreEqual("Personal Insurance", app.PageName(), "Verify the page is Personal Insurance");
            Console.WriteLine("Verify the page is Personal Insurance : " + app.PageName());

            app.Menu.Products_Personal_Homeowners();
            Assert.AreEqual("Homeowners Insurance", app.PageName(), "Verify the page is Homeowners Insurance");
            Console.WriteLine("Verify the page is Homeowners Insurance : " + app.PageName());

            //Clean up
            driver.Quit();
        }


        [TestMethod]
        public void Leadership()
        {
            IWebDriver driver = _driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            IWebElement lnkAboutUs = driver.FindElement(By.CssSelector("a[href*='/about-us']"));
            IWebElement lnkLeadership = driver.FindElement(By.CssSelector("a[href*='/about-us/leadership']"));

            lnkAboutUs.Click();
            lnkLeadership.Click();

            Leadership ldr = new Leadership(driver);
            Assert.AreEqual("Leadership", ldr.PageName(), "Verify the page loaded in Leadership");
            //Console.WriteLine(ldr.PageName());



            string ceo = ldr.Search("CEO");
            Console.WriteLine(ceo);
            Assert.AreEqual("Philip Bowie, CEO", ceo, true);

            
            //Clean up
            driver.Quit();
        }


        [TestMethod]
        public void VerifyPolicyCoverage()
        {

            IWebDriver driver = _driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            //Products Personal Homeowner
            driver.FindElement(By.CssSelector("a[href*='/products']")).Click();
            driver.FindElement(By.CssSelector("a[href*='/personal']")).Click();
            driver.FindElement(By.CssSelector("a[href*='/home-owners']")).Click();

            
            HomeOwner homeOwner = new HomeOwner(driver);

            //Verify the page is loaded
            Assert.AreEqual("Homeowners Insurance", homeOwner.PageName(), "Verify the page loaded in Homeowners Insurance");

            //Check if Fire, Lightning, Wind & Theft are displayed
            Console.WriteLine("Fire : " + homeOwner.IsDisplayedFire().ToString());
            Assert.IsTrue(homeOwner.IsDisplayedFire());

            Console.WriteLine("Lightning : " + homeOwner.IsDisplayedLightning().ToString());
            Assert.IsTrue(homeOwner.IsDisplayedLightning());

            Console.WriteLine("Theft : " + homeOwner.IsDisplayedTheft().ToString());
            Assert.IsTrue(homeOwner.IsDisplayedTheft());

            Console.WriteLine("Wind : " + homeOwner.IsDisplayedWind().ToString());
            Assert.IsTrue(homeOwner.IsDisplayedWind());


            homeOwner.btnUnderstandYourPolicy.Click();
            Console.WriteLine(homeOwner.Policy.Text());
            homeOwner.Policy.Close();

            //Clean up
            driver.Quit();
        }
    }

}