using Magenic.Maqs.BaseAppiumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel.WebAppPageModels;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.WebApp.TestData;

namespace Tests.WebApp
{
    /// <summary>
    /// Web App tests Class
    /// </summary>
    [TestClass]
    public class WebAppTests : BaseAppiumTest
    {
        private HomePageModel homePage;
        private SignUpPageModel signUpPage;
        private AccountPageModel accountPage;
        private LoginPageModel loginPage;
        private InvoicePageModel invoicePage;

        /// <summary>
        /// Initialize test
        /// </summary>
        [TestInitialize]
        public void Init() 
        {
            homePage = new HomePageModel(this.TestObject);
        }

        /// <summary>
        /// Easy - Verify Sign Up Info
        /// </summary>
        [TestMethod]
        public void VerifySignUpInfo() 
        {
            //1.Open http://www.phptravels.net
            homePage.NavigateToPhpTravels();
            homePage.IsPageLoaded();

            //2.Go to My Account
            homePage.ClickMyAccount();

            //3.Click on Sign Up Link
            signUpPage = homePage.ClickSignUp();
            signUpPage.IsPageLoaded();

            //4.Fill Up all details from the Sign Up Form
            var testData = WebAppTestData.GenerateAccountData();
            signUpPage.SignUpAccount(testData);

            //5.Click Sign Up Button
            accountPage = signUpPage.ClickSignUpButton();
            accountPage.IsPageLoaded();
            
            //6.Verify you have logged in successfully
            //(Assert welcome Note: "Hi, {FirstName} {LastName}" 
            SoftAssert.Assert(() => Assert.AreEqual($"Hi, {testData.Firstname} {testData.Lastname}", accountPage.GetWelcomeBanner(),
                "Verify you have logged in successfully"));
            
            //7.Verify Date display is equal to date today(NOTE: Set Date / Time on test device to be PH Time) 13 July 2021
            var dtime = DateTime.Now.ToString("dd MMMM yyyy");
            SoftAssert.Assert(() => Assert.AreEqual(dtime, accountPage.GetDateToday(), "Verify Date display is equal to date today"));

            //8.Click on My Profile Link
            accountPage.NavigateToMyProfile();

            //9.Verify FirstName, LastName, Phone, Email is equal to the value that you've entered during sign up
            var profileDetails = accountPage.GetMyProfileDetails();
            SoftAssert.Assert(() => Assert.AreEqual(testData.Firstname, profileDetails.Firstname,
                "Verify FirstName is equal to the value that you've entered during sign up"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.Lastname, profileDetails.Lastname,
                "Verify Lastname is equal to the value that you've entered during sign up"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.MobileNumber, profileDetails.MobileNumber,
                "Verify Mobile Number is equal to the value that you've entered during sign up"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.Email, profileDetails.Email,
                "Verify Email is equal to the value that you've entered during sign up"));

            //10.Verify FirstName and LastName is disabled for editing
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsFirstNameDisabled(),
                "Verify FirstName is disabled for editing"));
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsLastNameDisabled(),
                "Verify LastName is disabled for editing"));

            SoftAssert.FailTestIfAssertFailed();
        }

        /// <summary>
        /// Medium - Verify Account page for new users and update address information
        /// </summary>
        [TestMethod]
        public void VerifyAccountPageAndUpdateAddressInformation() 
        {
            //1.Open http://www.phptravels.net and create a new user (based on Easy)
            homePage.NavigateToPhpTravels();
            homePage.IsPageLoaded();

            homePage.ClickMyAccount();

            signUpPage = homePage.ClickSignUp();
            signUpPage.IsPageLoaded();

            var testData = WebAppTestData.GenerateAccountData();
            signUpPage.SignUpAccount(testData);

            accountPage = signUpPage.ClickSignUpButton();
            accountPage.IsPageLoaded();

            //4.Verify you have logged in successfully
            //(Assert welcome Note: "Hi, {FirstName} {LastName}"
            SoftAssert.Assert(() => Assert.AreEqual($"Hi, {testData.Firstname} {testData.Lastname}", accountPage.GetWelcomeBanner(),
                "Verify you have logged in successfully"));

            //5.Assert Bookings is Active and Selected
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsBookingsActiveAndSelected(), "Verify Bookings is Active and Selected"));

            //6.Assert Message 'Nothing Booked Yet' is displayed
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsNothingBookYetIsDisplayed(), "Verify Message 'Nothing Booked Yet' is displayed"));

            //7.Click on Wishlist Tab
            accountPage.NavigateToWishlist();

            //8.Assert Message 'No Wishlist Items Found' is displayed
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsNoWishlistDisplayed(), "Verify Message 'No Wishlist Items Found' is displayed"));

            //9.Click on Newletter Tab
            accountPage.NavigateToNewsletter();

            //10.Assert that Subcribe slider is displayed
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsSubscribeSliderDisplayed(), "Verify Subcribe slider is displayed"));

            //11.Click on My Profile Tab
            accountPage.NavigateToMyProfile();

            //12.Fill up the following fields: Address, City, State / Region, Postal / Zip Code
            accountPage.FillUpAddressInformation(testData);

            //13.Click Submit
            accountPage.ClickSubmit();
            //14.Click on My Profile Tab.
            accountPage.NavigateToMyProfile();

            //15.Assert that Address, City, State / Region, Postal / Zip Code is equal to the value that you've entered during update(step 12)
            accountPage.NavigateToMyProfile();

            var profileDetails = accountPage.GetMyProfileDetails();
            SoftAssert.Assert(() => Assert.AreEqual(testData.Address, profileDetails.Address,
                "Verify Address is equal to the value that you've entered during update"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.City, profileDetails.City,
                "Verify City is equal to the value that you've entered during update"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.State, profileDetails.State,
                "Verify State is equal to the value that you've entered duringupdate"));
            SoftAssert.Assert(() => Assert.AreEqual(testData.Zip, profileDetails.Zip,
                "Verify Zip is equal to the value that you've entered during update"));

            SoftAssert.FailTestIfAssertFailed();
        }

        /// <summary>
        /// Hard - Verify booking details matches invoice page
        /// </summary>
        [TestMethod]
        public void VerifyBookingDetailsMatchesInvoicePage() 
        {
            //1.Open http://www.phptravels.net
            homePage.NavigateToPhpTravels();
            homePage.IsPageLoaded();

            //2.Go to My Account
            homePage.ClickMyAccount();

            //3.Click on Login(username: user @phptravels.com / password: demouser)
            var testData = WebAppTestData.DemoAccount();
            loginPage = homePage.ClickLogin();
            loginPage.IsPageLoaded();
            accountPage = loginPage.LoginAccount(testData);

            //4.Verify you have logged in successfully
            //(Assert welcome Note: "Hi, {FirstName} {LastName}"
            accountPage.IsPageLoaded();
            SoftAssert.Assert(() => Assert.AreEqual($"Hi, {testData.Firstname} {testData.Lastname}", accountPage.GetWelcomeBanner(),
               "Verify you have logged in successfully"));

            //5.Assert Bookings is Active and Selected
            SoftAssert.Assert(() => Assert.IsTrue(accountPage.IsBookingsActiveAndSelected(), "Verify Bookings is Active and Selected"));
            var bookingData = accountPage.GetBookingInfo();

            //6.Scroll down to Click on any Invoice Button that is still unpaid and with past due
            invoicePage = accountPage.ScrollAndClickInvoiceButton();

            //7.Assert Message highlighted in Orange Banner
            //(“Your booking status is Expired")
            invoicePage.IsPageLoaded();
            SoftAssert.Assert(() => Assert.AreEqual("Your booking status is Expired",invoicePage.GetBookingStatusHeader(),
                "Verify Message highlighted in Orange Banner"));

            //8.Verify details booking number, hotel name, and country name displayed from the booking summary
            //matches data from the invoice page
            var invoiceDetails = invoicePage.GetBookingDetails();
            SoftAssert.Assert(() => Assert.AreEqual(bookingData.BookingNumber, invoiceDetails.BookingNumber,
                "Verify details booking number is displayed from the booking summary"));
            SoftAssert.Assert(() => Assert.AreEqual(bookingData.Hotel, invoiceDetails.Hotel,
                "Verify details hotel name is displayed from the booking summary"));
            SoftAssert.Assert(() => Assert.AreEqual(bookingData.Country, invoiceDetails.Country,
                "Verify details country name is displayed from the booking summary"));
            SoftAssert.FailTestIfAssertFailed();
        }

        /// <summary>
        /// Test Sample
        /// </summary>
        public void TestSample() 
        {
            homePage.NavigateToPhpTravels();


            
        }
    }
}
