using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using PageModel.WebAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageModel.WebAppPageModels
{
    /// <summary>
    /// Sign up page model
    /// </summary>
    public class SignUpPageModel : BasePageModel
    {
        /// <summary>
        /// Firstname input field
        /// </summary>
        private IWebElement FirstnameInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='firstname']"));

        /// <summary>
        /// Lastname input field
        /// </summary>
        private IWebElement LastnameInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='lastname']"));

        /// <summary>
        /// Phone input field
        /// </summary>
        private IWebElement PhoneInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='phone']"));

        /// <summary>
        /// Email input field
        /// </summary>
        private IWebElement EmailInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='email']"));

        /// <summary>
        /// Password input field
        /// </summary>
        private IWebElement PasswordInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='password']"));

        /// <summary>
        /// ConfirmPassword input field
        /// </summary>
        private IWebElement ConfirmPasswordInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='confirmpassword']"));

        /// <summary>
        /// Sign up button
        /// </summary>
        private IWebElement SignUpBtn =>
            this.AppiumDriver.FindElement(By.CssSelector("[class='signupbtn btn_full btn btn-success btn-block btn-lg']"));

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public SignUpPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Sign up an account
        /// </summary>
        /// <param name="account">account property</param>
        public void SignUpAccount(AccountModel account) 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;

            js.ExecuteScript("arguments[0].click();", FirstnameInputField);
            js.ExecuteScript($"arguments[0].value='{account.Firstname}';", FirstnameInputField);

            js.ExecuteScript("arguments[0].click();", LastnameInputField);
            js.ExecuteScript($"arguments[0].value='{account.Lastname}';", LastnameInputField);

            js.ExecuteScript("arguments[0].click();", PhoneInputField);
            js.ExecuteScript($"arguments[0].value='{account.MobileNumber}';", PhoneInputField);

            js.ExecuteScript("arguments[0].click();", EmailInputField);
            js.ExecuteScript($"arguments[0].value='{account.Email}';", EmailInputField);

            js.ExecuteScript("arguments[0].click();", PasswordInputField);
            js.ExecuteScript($"arguments[0].value='{account.Password}';", PasswordInputField);

            js.ExecuteScript("arguments[0].click();", ConfirmPasswordInputField);
            js.ExecuteScript($"arguments[0].value='{account.Password}';", ConfirmPasswordInputField);
        }

        /// <summary>
        /// Click the sign up button
        /// </summary>
        public AccountPageModel ClickSignUpButton() 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;
            js.ExecuteScript("arguments[0].click();", SignUpBtn);
            return GetAccountPageModel();
        }
    }
}
