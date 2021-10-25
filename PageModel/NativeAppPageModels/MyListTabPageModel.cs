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
    public class MyListTabPageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyListTabPageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public MyListTabPageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Anime Title
        /// </summary>
        private LazyMobileElement AnimeTitle =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/title"), "Anime Title");

        /// <summary>
        /// Anime Details
        /// </summary>
        private LazyMobileElement AnimeDetails =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/media"), "Anime Details");

        /// <summary>
        /// Number of episodes
        /// </summary>
        private LazyMobileElement AnimeNumberOfEpisodes =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/numEpisodes"), "number of episodes");

        /// <summary>
        /// Edit button
        /// </summary>
        private LazyMobileElement EditBtn =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/listEdit"), "Edit button");

        /// <summary>
        /// Remove from List
        /// </summary>
        private LazyMobileElement RemoveFromList =>
            new LazyMobileElement(this.TestObject, By.Id("net.myanimelist.app:id/delete"), "Remove from List");

        /// <summary>
        /// Yes button
        /// </summary>
        private LazyMobileElement YesBtn =>
            new LazyMobileElement(this.TestObject, By.Id("android:id/button1"), "Yes button");

        /// <summary>
        /// Get anime details from my list
        /// </summary>
        /// <returns>anime details</returns>
        public AnimeDetails GetAnimeDetails() 
        {
            var title = AnimeTitle.Text;

            var text = AnimeDetails.Text;
            string[] separator = { ",", " ", "\'" };
            var details = text.Split(separator, 0);

            var episodes = AnimeNumberOfEpisodes.Text;
            var data1 = episodes.Split(separator, 0);
            episodes = data1[1];


            return new AnimeDetails
            {
                Title = title,
                Category = details[0],
                NumberOfEpisodes = episodes,
                Season = details[2],
                Year = details[3]
            };
        }

        /// <summary>
        /// Click edit button
        /// </summary>
        public void ClickEditButton() 
        {
            EditBtn.Click();
        }

        /// <summary>
        /// Click Remove from List
        /// </summary>
        public void ClickRemoveFromList() 
        {
            RemoveFromList.Click();
        }

        /// <summary>
        /// Click Yes
        /// </summary>
        public void ClickYes() 
        {
            YesBtn.Click();
        }

        /// <summary>
        /// Is anime remove
        /// </summary>
        /// <returns>true if remove</returns>
        public bool IsAnimeRemove() 
        {
            try
            {
                return AnimeTitle.Displayed;
            }
            catch 
            {
                return true;
            }
        }
    }
}
