using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.NativeAppPageModels
{
    public class SeasonalPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeasonalPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public SeasonalPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Last Tab
        /// </summary>
        private LazyMobileElement LastTab =>
            new LazyMobileElement(this.TestObject, By.XPath("//androidx.appcompat.app.ActionBar.Tab[@content-desc='Last']"), "Last Tab");

        /// <summary>
        /// Anime Thumbnail
        /// </summary>
        private IEnumerable<IWebElement> AnimeThumbnail =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/thumbnailView");

        /// <summary>
        /// Anime Action Button
        /// </summary>
        private IEnumerable<IWebElement> AnimeActionButton =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/actionButton");

        /// <summary>
        /// Anime Title
        /// </summary>
        private IEnumerable<IWebElement> AnimeTitle =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/title");

        /// <summary>
        /// Completed Button
        /// </summary>
        private LazyMobileElement CompletedBtn =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/completed"), "Completed Button");

        /// <summary>
        /// Save Button
        /// </summary>
        private LazyMobileElement SaveBtn =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/save"), "Save Button");

        /// <summary>
        /// Click Last Tab
        /// </summary>
        public void ClickLastTab() 
        {
            LastTab.Click();
        }

        /// <summary>
        /// Select Any Anime From The List
        /// </summary>
        /// <returns>anime detail page</returns>
        public AnimeDetailsPageModel SelectAnyAnimeFromTheList() 
        {
            AnimeThumbnail.ElementAt(1).Click();
            return GetAnimeDetailsPageModel();
        }

        /// <summary>
        /// Click add button
        /// </summary>
        public void ClickAddButton() 
        {
            AnimeActionButton.ElementAt(1).Click();
        }

        /// <summary>
        /// Click completed button
        /// </summary>
        public void ClickCompletedButton() 
        {
            CompletedBtn.Click();
        }

        /// <summary>
        /// Click save button
        /// </summary>
        public HomePageModel ClickSaveButton()
        {
            SaveBtn.Click();
            return GetHomePageModel();
        }

        /// <summary>
        /// Check that the page is loaded
        /// </summary>
        /// <returns>True if the page is loaded</returns>
        public override bool IsPageLoaded()
        {
            this.AppiumDriver.WaitUntilPageLoad();
            return AnimeThumbnail.ElementAt(1).Displayed;
        }
    }
}
