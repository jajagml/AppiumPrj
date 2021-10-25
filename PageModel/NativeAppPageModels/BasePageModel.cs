using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.NativeAppPageModels
{
    public abstract class BasePageModel : BaseAppiumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public BasePageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Home Tab
        /// </summary>
        private LazyMobileElement HomeTab =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.FrameLayout[@content-desc='Home']"), "Home Tab");

        /// <summary>
        /// Search Tab
        /// </summary>
        private LazyMobileElement SearchTab =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.FrameLayout[@content-desc='Search']"), "Search Tab");

        /// <summary>
        /// Seasonal Tab
        /// </summary>
        private LazyMobileElement SeasonalTab =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.FrameLayout[@content-desc='Seasonal']"), "Seasonal Tab");

        /// <summary>
        /// My List Tab
        /// </summary>
        private LazyMobileElement MyListTab =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.FrameLayout[@content-desc='My List']"), "My List Tab");

        /// <summary>
        /// Profile Icon
        /// </summary>
        private LazyMobileElement ProfileIcon =>
            new LazyMobileElement(this.TestObject, By.XPath("//android.widget.ImageButton[@content-desc='Navigate up']"), "Profile Icon");

        /// <summary>
        /// UserName
        /// </summary>
        private LazyMobileElement UserName =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/name"), "Username");

        /// <summary>
        /// Pop-up ads dismiss
        /// </summary>
        private LazyMobileElement PopUpAdsDismiss =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/collapse_button"),"Pop-up ads dismiss");

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the page is loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.AppiumDriver.WaitUntilPageLoad();
        }

        /// <summary>
        /// Get new instance of HomePageModel
        /// </summary>
        /// <returns>new instance of HomePageModel</returns>
        protected HomePageModel GetHomePageModel()
        {
            return new HomePageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of SearchPageModel
        /// </summary>
        /// <returns>new instance of SearchPageModel</returns>
        protected SearchPageModel GetSearchPageModel()
        {
            return new SearchPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of AnimeDetailsPageModel
        /// </summary>
        /// <returns>new instance of AnimeDetailsPageModel</returns>
        protected AnimeDetailsPageModel GetAnimeDetailsPageModel()
        {
            return new AnimeDetailsPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of SeasonalPageModel
        /// </summary>
        /// <returns>new instance of SeasonalPageModel</returns>
        protected SeasonalPageModel GetSeasonalPageModel()
        {
            return new SeasonalPageModel(TestObject);
        }

        /// <summary>
        /// Get new instance of MyListTabPageModel
        /// </summary>
        /// <returns>new instance of MyListTabPageModel</returns>
        protected MyListTabPageModel GetMyListTabPageModel()
        {
            return new MyListTabPageModel(TestObject);
        }

        /// <summary>
        /// Defines if Home tab is selected
        /// </summary>
        /// <returns>true if selected</returns>
        public bool IsHomeTabSelected()
        {
            return HomeTab.Selected;
        }

        /// <summary>
        /// Click Profile Icon
        /// </summary>
        public void ClickProfileIcon()
        {
            ProfileIcon.Click();
        }

        /// <summary>
        /// Is UserName displayed
        /// </summary>
        public bool IsUserNameDisplayed()
        {
            return UserName.Displayed;
        }

        /// <summary>
        /// Is Slideout displayed
        /// </summary>
        public bool IsSlideoutDisplayed()
        {
            return UserName.Displayed;
        }

        /// <summary>
        /// Navigate to search tab
        /// </summary>
        /// <returns>search page</returns>
        public SearchPageModel NavigateSearchTab() 
        {
            SearchTab.Click();
            return GetSearchPageModel();
        }

        /// <summary>
        /// Navigate to Seasonal Tab
        /// </summary>
        /// <returns>search page</returns>
        public SeasonalPageModel NavigateSeasonalTab()
        {
            SeasonalTab.Click();
            return GetSeasonalPageModel();
        }

        /// <summary>
        /// Navigate to MyList Tab
        /// </summary>
        /// <returns>search page</returns>
        public MyListTabPageModel NavigateMyListTab()
        {
            MyListTab.Click();
            return GetMyListTabPageModel();
        }

        /// <summary>
        /// Dismiss pop up ads
        /// </summary>
        public void DismissPopUp() 
        {
            bool isDisplayed;
            try
            {
                isDisplayed =  PopUpAdsDismiss.Displayed;
            }
            catch
            {
                isDisplayed =  false;
            }

            if (isDisplayed)
                PopUpAdsDismiss.Click();
        }

        /// <summary>
        /// Navigate back
        /// </summary>
        public void NavigateBack()
        {
            this.AppiumDriver.Navigate().Back();
        }

    }
}
