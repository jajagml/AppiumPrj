using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageModel.WebAppPageModels
{
    public abstract class BasePageModel : BaseAppiumPageModel
    {
        /// <summary>page url</summary>
        private readonly string pageUrl = "http://www.phptravels.net";

        /// <summary>
        /// My Account Tab
        /// </summary>
        private LazyMobileElement MyAccountTab =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='dropdown dropdown-login dropdown-tab']"), "My Account Tab");

        /// <summary>
        /// My Account Dropdown menu items
        /// </summary>
        private IEnumerable<IWebElement> MyAccountDropdownItems =>
            this.AppiumDriver.FindElementsByCssSelector("[class='dropdown-menu dropdown-menu-right show'] a");

        /// <summary>Login element</summary>
        private IWebElement Login() 
        {
            var items = MyAccountDropdownItems.ToList();

            foreach (var item in items) 
            {
                if (item.Text == "Login")
                    return item;
            }
            return null;
        }

        /// <summary>Sign Up element</summary>
        private IWebElement SignUp()
        {
            var items = MyAccountDropdownItems.ToList();

            foreach (var item in items)
            {
                if (item.Text == "Sign Up")
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public BasePageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the page loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.AppiumDriver.WaitUntilPageLoad();
        }

        /// <summary>
        /// Navigate to URL
        /// </summary>
        public void NavigateToPhpTravels()
        {
            this.TestObject.AppiumDriver.Navigate().GoToUrl(pageUrl);
        }

        /// <summary>
        /// Click My Account
        /// </summary>
        public void ClickMyAccount()
        {
            MyAccountTab.Click();
        }

        /// <summary>
        /// Click Login
        /// </summary>
        public LoginPageModel ClickLogin()
        {
            Login().Click();
            return GetLoginPageModel();
        }

        /// <summary>
        /// Click Sign Up
        /// </summary>
        public SignUpPageModel ClickSignUp()
        {
            SignUp().Click();
            return GetSignUpPageModel();
        }

        /// <summary>
        /// Get new instance of SignUpPageModel
        /// </summary>
        /// <returns>new instance of SignUpPageModel</returns>
        protected SignUpPageModel GetSignUpPageModel()
        {
            return new SignUpPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of AccountPageModel
        /// </summary>
        /// <returns>new instance of AccountPageModel</returns>
        protected AccountPageModel GetAccountPageModel()
        {
            return new AccountPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of LoginPageModel
        /// </summary>
        /// <returns>new instance of LoginPageModel</returns>
        protected LoginPageModel GetLoginPageModel()
        {
            return new LoginPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of InvoicePageModel
        /// </summary>
        /// <returns>new instance of InvoicePageModel</returns>
        protected InvoicePageModel GetInvoicePageModel()
        {
            return new InvoicePageModel(TestObject);
        }
    }
}
