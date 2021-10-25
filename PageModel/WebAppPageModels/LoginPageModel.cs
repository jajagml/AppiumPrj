using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using PageModel.WebAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.WebAppPageModels
{
    public class LoginPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public LoginPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Username input field
        /// </summary>
        private IWebElement UsernameInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='username']"));

        /// <summary>
        /// Password input field
        /// </summary>
        private IWebElement PasswordInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='password']"));

        /// <summary>
        /// Login button
        /// </summary>
        private IWebElement LoginBtn =>
            this.AppiumDriver.FindElement(By.CssSelector("[class='btn btn-primary btn-lg btn-block loginbtn']"));

        /// <summary>
        /// Login Account
        /// </summary>
        /// <param name="account">account details</param>
        /// <returns></returns>
        public AccountPageModel LoginAccount(AccountModel account) 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;

            js.ExecuteScript("arguments[0].click();", UsernameInputField);
            js.ExecuteScript($"arguments[0].value='{account.Email}';", UsernameInputField);

            js.ExecuteScript("arguments[0].click();", PasswordInputField);
            js.ExecuteScript($"arguments[0].value='{account.Password}';", PasswordInputField);

            js.ExecuteScript("arguments[0].click();", LoginBtn);
            return GetAccountPageModel();
        }

    }
}
