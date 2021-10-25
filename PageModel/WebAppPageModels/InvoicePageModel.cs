using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using PageModel.WebAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.WebAppPageModels
{
    public class InvoicePageModel : BasePageModel
    {
        /// <summary>
        /// Booking Status Header
        /// </summary>
        private LazyMobileElement BookingStatusHeader =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='success-box expired'] h4"), "Booking Status Header");

        /// <summary>
        /// Booking details labels
        /// </summary>
        private IEnumerable<IWebElement> BookingDetails =>
             this.AppiumDriver.FindElementsByCssSelector("[class='go-left float-right']");

        /// <summary>
        /// Hotel Name
        /// </summary>
        private LazyMobileElement HotelName =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='content-body'] h6"), "Hotel name");
        
        /// <summary>
        /// Country 
        /// </summary>
        private LazyMobileElement Country =>
            new LazyMobileElement(this.TestObject, By.CssSelector("[class='meta text-muted go-right']"), "Country");

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicePageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public InvoicePageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the page loaded</returns>
        public override bool IsPageLoaded()
        {
            this.AppiumDriver.SwitchTo().Window(this.AppiumDriver.WindowHandles[1]);
            return this.AppiumDriver.WaitUntilPageLoad();
        }

        /// <summary>
        /// Get the booking status header
        /// </summary>
        /// <returns>text</returns>
        public string GetBookingStatusHeader() 
        {
            this.AppiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            return BookingStatusHeader.Text;
        }

        /// <summary>
        /// Get Booking Details from Invoice Page
        /// </summary>
        /// <returns>Invoice Page</returns>
        public BookingModel GetBookingDetails() 
        {
            var bookingDetails = BookingDetails.ToList();
            return new BookingModel
            {
                Hotel = HotelName.Text,
                Country = Country.Text,
                BookingNumber = bookingDetails[4].Text
            };
        }
    }
}
