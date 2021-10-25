using Magenic.Maqs.BaseAppiumTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using PageModel.NativeAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.NativeAppPageModels
{
    public class AnimeDetailsPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimeDetailsPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public AnimeDetailsPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Anime Title
        /// </summary>
        private LazyMobileElement AnimeTitle =>
            new LazyMobileElement(this.TestObject, By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[2]/android.view.View[4]")
                ,"Anime Title");

        /// <summary>
        /// Category and Year 
        /// </summary>
        private LazyMobileElement AnimeCategoryAndYear =>
            new LazyMobileElement(this.TestObject, By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[2]/android.widget.TextView[1]")
                , "Anime Category And Year");

        /// <summary>
        /// Number of episodes
        /// </summary>
        private LazyMobileElement AnimeNumberOfEpisodes =>
            new LazyMobileElement(this.TestObject, By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[2]/android.widget.TextView[3]")
                , "Anime Number of Episodes");

        /// <summary>
        /// Anime Season
        /// </summary>
        private LazyMobileElement AnimeSeason =>
            new LazyMobileElement(this.TestObject, By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[5]/android.view.View/android.view.View[2]/android.view.View[2]")
                , "Anime Season");




        /// <summary>
        /// TextView Details 
        /// </summary>
        private IEnumerable<IWebElement> TextViewDetails =>
            this.AppiumDriver.FindElementsByXPath("//android.widget.TextView");

        public AnimeDetails GetAnimeDetails() 
        {
            var title = AnimeTitle.Text;

            var categoryAndYear = AnimeCategoryAndYear.Text;
            string[] separator = { ","," "};
            var data1 = categoryAndYear.Split(separator, 0);
            var category = data1[0];

            var numberOfEpisodes = AnimeNumberOfEpisodes.Text;
            var data2 = numberOfEpisodes.Split(separator, 0);
            numberOfEpisodes = data2[0];

            this.AppiumDriver.WaitUntilPageLoad();
            TouchAction action = new TouchAction(this.AppiumDriver);
            action.Press(1187, 2282).MoveTo(1187, 766).Release().Perform();
            this.AppiumDriver.WaitUntilPageLoad();

            var session = AnimeSeason.Text;
            var data3 = session.Split(separator, 0);
            var year = data3[2];
            session = data3[1];           

            return new AnimeDetails
            {
                Title = title,
                Category = category,
                NumberOfEpisodes = numberOfEpisodes,
                Year = year,
                Season = session
            };

        }

        /// <summary>
        /// View Details 
        /// </summary>
        private IEnumerable<IWebElement> ViewDetails =>
            this.AppiumDriver.FindElementsByXPath("//android.view.View");

        public List<string> GetAllDetails() 
        {
            this.AppiumDriver.WaitUntilPageLoad();
            var allDetails = new List<string>();
            var viewDetails = ViewDetails.ToList();

            foreach (var detail in viewDetails) 
            {
                allDetails.Add(detail.Text);
            }

            return allDetails;
        }
    }

}
