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
    public class SearchPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public SearchPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Search TextBox
        /// </summary>
        private LazyMobileElement SearchTextBox =>
            new LazyMobileElement(this.TestObject, By.Id("android:id/search_src_text"), "Search TextBox");

        /// <summary>
        /// Anime Titles
        /// </summary>
        private IEnumerable<IWebElement> AnimeTitles =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/title");

        /// <summary>
        /// Anime Details
        /// </summary>
        private IEnumerable<IWebElement> AnimeDetails =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/media");

        /// <summary>
        /// Anime Thumbnails
        /// </summary>
        private IEnumerable<IWebElement> AnimeThumbnails =>
            this.AppiumDriver.FindElementsById("net.myanimelist.app:id/thumbnail");

        /// <summary>
        /// Is search page displayed
        /// </summary>
        /// <returns>true if displayed</returns>
        public bool IsSearchPageDisplayed() 
        {
            return SearchTextBox.Displayed;
        }

        /// <summary>
        /// Enter string to search
        /// </summary>
        /// <param name="keyword">string to search</param>
        public void EnterSearchBox(string keyword) 
        {
            SearchTextBox.SendKeys(keyword);
            SearchTextBox.Click();
            this.AppiumDriver.ExecuteScript("mobile: performEditorAction", new Dictionary<string, string> { { "action", "search" } });
        }

        /// <summary>
        /// Get anime list from search result
        /// </summary>
        /// <returns>anime titles</returns>
        public List<string> GetAnimeTitles() 
        {
            var titles = AnimeTitles.ToList();
            List<string> result = new List<string>();

            foreach (var title in titles) 
            {
                result.Add(title.Text);
            }

            return result;
        }

        /// <summary>
        /// Get random item from search results
        /// </summary>
        /// <returns>random item</returns>
        public AnimeDetails GetItem() 
        {
            var title = AnimeTitles.ElementAt(0).Text;

            var text = AnimeDetails.ElementAt(0).Text;
            string[] separator = { ",", " "};
            var details = text.Split(separator, 0);
            
            return new AnimeDetails
            {
                Title = title,
                Category = details[0],
                NumberOfEpisodes = details[2],
                Season = details[5],
                Year = details[6]
            };
        }

        /// <summary>
        /// Select Item Listed based on random item
        /// </summary>
        /// <param name="name">title of the anime</param>
        public AnimeDetailsPageModel SelectItemListed(string name) 
        {
            var titles = AnimeTitles.ToList();

            foreach (var title in titles)
            {
                if (title.Text == name) 
                {
                    title.Click();
                    return GetAnimeDetailsPageModel();
                }
            }

            return null;
        }
    }
}
