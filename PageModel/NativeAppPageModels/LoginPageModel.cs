using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using PageModel.NativeAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.NativeAppPageModels
{
    public class LoginPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public LoginPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Login Holder
        /// </summary>
        private IEnumerable<IWebElement> LoginHolder =>
            this.AppiumDriver.FindElementsByXPath("//android.widget.EditText");

        /// <summary>
        /// Username input field
        /// </summary>
        private IWebElement UsernameInputField => LoginHolder.ElementAt(0);

        /// <summary>
        /// Password input field
        /// </summary>
        private IWebElement PasswordInputField => LoginHolder.ElementAt(1);

        /// <summary>
        /// Login Button
        /// </summary>
        private LazyMobileElement LoginBtn =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.Button"), "Login Button");

        public HomePageModel LoginAccount(DummyAccountModel account) 
        {
            UsernameInputField.SendKeys(account.Username);
            PasswordInputField.SendKeys(account.Password);
            LoginBtn.Click();
            return GetHomePageModel();
        }
    }
}
