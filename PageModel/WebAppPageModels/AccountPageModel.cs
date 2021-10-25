using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using PageModel.WebAppPageModels.DataModels;
using System;

namespace PageModel.WebAppPageModels
{
    /// <summary>
    /// Account page model
    /// </summary>
    public class AccountPageModel : BasePageModel
    {
        /// <summary>
        /// Welcome Banner element
        /// </summary>
        private LazyMobileElement WelcomeBanner =>
            new LazyMobileElement(this.TestObject, By.CssSelector("h3[class='text-align-left']"), "Welcome Banner");

        /// <summary>
        /// Date Today element
        /// </summary>
        private LazyMobileElement DateToday =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='go-right px-5'] [class='h4']"), "Date Today");

        /// <summary>
        /// Bookings Tab
        /// </summary>
        private LazyMobileElement BookingsTab =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[href='#bookings']"), "Bookings Tab");

        /// <summary>
        /// My Profile tab
        /// </summary>
        private LazyMobileElement MyProfileTab =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[href='#profile']"), "My Profile Tab");

        /// <summary>
        /// Wishlist tab
        /// </summary>
        private LazyMobileElement WishlistTab =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[href='#wishlist']"), "Wishlist Tab");

        /// <summary>
        /// Newsletter tab
        /// </summary>
        private LazyMobileElement NewsletterTab =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[href='#newsletter']"), "Newsletter Tab");

        /// <summary>
        /// NothingBookYet message
        /// </summary>
        private LazyMobileElement NothingBookYet =>
            new LazyMobileElement(this.TestObject, By.CssSelector("h4 strong"), "NothingBookYet message");

        /// <summary>
        /// NoWishlist message
        /// </summary>
        private LazyMobileElement NoWishlist =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='panel-body mywishlist'] h4"), "NoWishlist message");

        /// <summary>
        /// Subscribe Slider
        /// </summary>
        private LazyMobileElement SubscribeSlider =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='switch float-none']"), "Subscribe Slider");

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
        /// Address Input field
        /// </summary>
        private IWebElement AddressInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='address1']"));

        /// <summary>
        /// City input field
        /// </summary>
        private IWebElement CityInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='city']"));

        /// <summary>
        /// State input field
        /// </summary>
        private IWebElement StateInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='state']"));
        
        /// <summary>
        /// Zip input field
        /// </summary>
        private IWebElement ZipInputField =>
            this.AppiumDriver.FindElement(By.CssSelector("[name='zip']"));

        /// <summary>
        /// Submit button
        /// </summary>
        private IWebElement SubmitBtn =>
            this.AppiumDriver.FindElement(By.CssSelector("[type='submit']"));

        /// <summary>
        /// Invoice button
        /// </summary>
        private IWebElement InvoiceBtn =>
            this.AppiumDriver.FindElement(By.CssSelector("[class='btn btn-primary btn-action btn-block']"));

        /// <summary>
        /// Hotel name label
        /// </summary>
        private LazyMobileElement HotelName =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='dark RTL go-text-right']"),"Hotel Name");

        /// <summary>
        /// Country name label
        /// </summary>
        private LazyMobileElement Country =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='go-text-right']"), "Country");

        /// <summary>
        /// Booking number label
        /// </summary>
        private LazyMobileElement BookingNumber =>
            new LazyMobileElement(this.TestObject, By.XPath("//span[@class='grey']"), "Booking number");

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public AccountPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Get the string from welcome banner
        /// </summary>
        /// <returns>string from welcome banner</returns>
        public string GetWelcomeBanner() 
        {
            return WelcomeBanner.Text;
        }

        /// <summary>
        /// Get date today from the page
        /// </summary>
        /// <returns>date today</returns>
        public string GetDateToday()
        {
            return DateToday.Text;
        }

        /// <summary>
        /// Navigate to My Profile
        /// </summary>
        public void NavigateToMyProfile()
        {
            MyProfileTab.Click();
        }

        /// <summary>
        /// Navigate to Wishlist
        /// </summary>
        public void NavigateToWishlist()
        {
            WishlistTab.Click();
        }

        /// <summary>
        /// Navigate to Newsletter
        /// </summary>
        public void NavigateToNewsletter()
        {
            NewsletterTab.Click();
        }

        /// <summary>
        /// Get My Profile details
        /// </summary>
        /// <returns>profile details</returns>
        public AccountModel GetMyProfileDetails()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;

            return new AccountModel
            {
                Firstname = js.ExecuteScript("return arguments[0].value;", FirstnameInputField).ToString(),
                Lastname = js.ExecuteScript("return arguments[0].value;", LastnameInputField).ToString(),
                MobileNumber = js.ExecuteScript("return arguments[0].value;", PhoneInputField).ToString(),
                Email = js.ExecuteScript("return arguments[0].value;", EmailInputField).ToString(),
                Address = js.ExecuteScript("return arguments[0].value;", AddressInputField).ToString(),
                City = js.ExecuteScript("return arguments[0].value;", CityInputField).ToString(),
                State = js.ExecuteScript("return arguments[0].value;", StateInputField).ToString(),
                Zip = js.ExecuteScript("return arguments[0].value;", ZipInputField).ToString(),
            };
        }

        /// <summary>
        /// Is FirstName disabled
        /// </summary>
        /// <returns>true if element is disabled</returns>
        public bool IsFirstNameDisabled() 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;
            var isReadOnly = js.ExecuteScript("return arguments[0].getAttribute(\"readonly\");", FirstnameInputField);
            return isReadOnly != null;
        }

        /// <summary>
        /// Is LastName disabled
        /// </summary>
        /// <returns>true if element is disabled</returns>
        public bool IsLastNameDisabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;
            var isReadOnly = js.ExecuteScript("return arguments[0].getAttribute(\"readonly\");", LastnameInputField);
            return isReadOnly != null;
        }

        /// <summary>
        /// Is Bookings active and selected
        /// </summary>
        /// <returns>true if bookings is active</returns>
        public bool IsBookingsActiveAndSelected() 
        {
            var bookingsClass = BookingsTab.GetAttribute("class").ToString();            
            return bookingsClass.Contains("active");
        }

        /// <summary>
        /// Is message : Nothing Book Yet is displayed
        /// </summary>
        /// <returns>true if message is active</returns>
        public bool IsNothingBookYetIsDisplayed()
        {
            this.AppiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            return NothingBookYet.Displayed;
        }

        /// <summary>
        /// Is message : No Wishlist is displayed
        /// </summary>
        /// <returns>true if message is active</returns>
        public bool IsNoWishlistDisplayed()
        {
            this.AppiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            return NoWishlist.Displayed;
        }

        /// <summary>
        /// Is Subscribe slider displayed
        /// </summary>
        /// <returns>true if message is active</returns>
        public bool IsSubscribeSliderDisplayed()
        {
            this.AppiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            return SubscribeSlider.Displayed; ;
        }

        /// <summary>
        /// Click Submit
        /// </summary>
        public void ClickSubmit() 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;

            js.ExecuteScript("arguments[0].click();", SubmitBtn);
        }

        /// <summary>
        /// Fill up address information
        /// </summary>
        /// <param name="account">account details</param>
        public void FillUpAddressInformation(AccountModel account) 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.AppiumDriver;

            js.ExecuteScript("arguments[0].click();", AddressInputField);
            js.ExecuteScript($"arguments[0].value='{account.Address}';", AddressInputField);

            js.ExecuteScript("arguments[0].click();", CityInputField);
            js.ExecuteScript($"arguments[0].value='{account.City}';", CityInputField);

            js.ExecuteScript("arguments[0].click();", StateInputField);
            js.ExecuteScript($"arguments[0].value='{account.State}';", StateInputField);

            js.ExecuteScript("arguments[0].click();", ZipInputField);
            js.ExecuteScript($"arguments[0].value='{account.Zip}';", ZipInputField);
        }

        /// <summary>
        /// Scroll and click Invoice Button
        /// </summary>
        public InvoicePageModel ScrollAndClickInvoiceButton() 
        {
            this.AppiumDriver.WaitUntilPageLoad();
            TouchAction action = new TouchAction(this.AppiumDriver);
            action.Press(1269, 2386).MoveTo(1269, 1013).Release().Perform();
            this.AppiumDriver.WaitUntilPageLoad();
            InvoiceBtn.Click();
            return GetInvoicePageModel();
        }

        /// <summary>
        /// Get Booking info from Bookings Tab
        /// </summary>
        /// <returns>booking information</returns>
        public BookingModel GetBookingInfo() 
        {
            var text = BookingNumber.Text;
            string[] separator = { "\r\n", "\r", "\n", " " };
            var bookingNo = text.Split(separator, 0);
            return new BookingModel
            {
                Hotel = HotelName.Text,
                BookingNumber = bookingNo[5],
                Country = Country.Text
            };
        }
    }
}
