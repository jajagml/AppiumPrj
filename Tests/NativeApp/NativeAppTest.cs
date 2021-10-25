using Magenic.Maqs.BaseAppiumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel.NativeAppPageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.NativeApp.TestData;

namespace Tests.NativeApp
{
    [TestClass]
    public class NativeAppTest : BaseAppiumTest
    {
        private LoginPageModel loginPage;
        private HomePageModel homePage;
        private SearchPageModel searchPage;
        private AnimeDetailsPageModel animeDetailsPage;
        private SeasonalPageModel seasonalPage;
        private MyListTabPageModel myListPage;

        /// <summary>
        /// Initialize test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            loginPage = new LoginPageModel(this.TestObject);
        }

        /// <summary>
        /// Easy – Login
        /// </summary>
        [TestMethod]
        public void Login() 
        {
            //1.Open and login to the app
            loginPage.IsPageLoaded();
            var accountData = NativeAppTestData.MyDummyAccount();
            homePage = loginPage.LoginAccount(accountData);

            //2.Verify that user will be navigated to home page(TIP: Is Selected)
            homePage.IsPageLoaded();
            homePage.DismissPopUp();
            SoftAssert.Assert(() => Assert.IsTrue(homePage.IsHomeTabSelected(),
                "Verify that user will be navigated to home page"));

            //3.Click Profile icon
            homePage.ClickProfileIcon();

            //4.Verify that slideout menu will be displayed
            SoftAssert.Assert(() => Assert.IsTrue(homePage.IsSlideoutDisplayed(),
                "Verify that slideout menu will be displayed"));

            //5.Verify that username will be displayed
            SoftAssert.Assert(() => Assert.IsTrue(homePage.IsUserNameDisplayed(),
                "Verify that username will be displayed"));
            SoftAssert.FailTestIfAssertFailed();
        }

        /// <summary>
        /// Medium – Search
        /// </summary>
        [TestMethod]
        public void Search() 
        {
            //1.Open and login to the app
            loginPage.IsPageLoaded();
            var accountData = NativeAppTestData.MyDummyAccount();
            homePage = loginPage.LoginAccount(accountData);

            //2.Navigate to Search page
            homePage.IsPageLoaded();
            homePage.DismissPopUp();
            searchPage = homePage.NavigateSearchTab();
            searchPage.IsPageLoaded();

            //3.Verify that search page is displayed(TIP: Use Search Textbox)
            SoftAssert.Assert(() => Assert.IsTrue(searchPage.IsSearchPageDisplayed(),
                "Verify that search page is displayed"));

            //4.Enter 'Metal' on the keyword and search
            searchPage.EnterSearchBox("Metal");

            //5.Verify that all search research contains the keyword 'Metal'
            var resultTitles = searchPage.GetAnimeTitles();
            foreach (var result in resultTitles) 
            {
                SoftAssert.Assert(() => Assert.IsTrue(result.Contains("Metal"),
                    "Verify that all search research contains the keyword 'Metal'"));
            }

            //6.Select any item listed(Take note of details: title, category, number of episodes, season / year)
            searchPage.IsPageLoaded();
            var animeData = searchPage.GetItem();
            animeDetailsPage = searchPage.SelectItemListed(animeData.Title);
            animeDetailsPage.IsPageLoaded();

            //7.Verify that correct title will be displayed
            var results = animeDetailsPage.GetAnimeDetails();
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Title, results.Title,
                "Verify that correct title will be displayed"));

            //8.Verify that correct category will be displayed(TV, Movie, etc)
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Category,results.Category,
                "Verify that correct category will be displayed(TV, Movie, etc)"));

            //9.Verify that correct total number of episodes is displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.NumberOfEpisodes, results.NumberOfEpisodes,
                "Verify that correct total number of episodes is displayed"));

            //10.Verify that correct year is displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Year, results.Year,
                "Verify that correct year is displayed"));
            SoftAssert.FailTestIfAssertFailed();
        }

        /// <summary>
        /// Hard - Add and remove an anime
        /// </summary>
        [TestMethod]
        public void AddAndRemoveAnime() 
        {
            //1.Open and login to the app
            loginPage.IsPageLoaded();
            var accountData = NativeAppTestData.MyDummyAccount();
            homePage = loginPage.LoginAccount(accountData);

            //2.Navigate to Seasonal
            homePage.IsPageLoaded();
            homePage.DismissPopUp();
            seasonalPage = homePage.NavigateSeasonalTab();

            //3.Verify Seasonal page will be displayed
            SoftAssert.Assert(() => Assert.IsTrue(seasonalPage.IsPageLoaded(),
                "Verify Seasonal page will be displayed"));

            //4.Tap 'Last' tab
            seasonalPage.ClickLastTab();
            seasonalPage.IsPageLoaded();
            //5.Select anime from the list
            animeDetailsPage = seasonalPage.SelectAnyAnimeFromTheList();
            var animeData = animeDetailsPage.GetAnimeDetails();
            animeDetailsPage.NavigateBack();

            //6.Tap add button
            seasonalPage.IsPageLoaded();
            seasonalPage.ClickAddButton();

            //7.Select 'Completed' as status
            seasonalPage.ClickCompletedButton();

            //8.Click 'Save' button
            homePage = seasonalPage.ClickSaveButton();

            //9.Tap Back button
            //10.Tap 'My List'
            myListPage = homePage.NavigateMyListTab();
            myListPage.IsPageLoaded();

            //11.Verify that selected anime is listed
            var myListResult = myListPage.GetAnimeDetails();

            //a. Correct title will be displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Title, myListResult.Title,
                "Correct title will be displayed"));

            // b.Correct category will be displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Category, myListResult.Category,
                "Correct title will be displayed"));

            // c.Correct season/ year will be displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Season, myListResult.Season,
                "Correct season will be displayed"));
            SoftAssert.Assert(() => Assert.AreEqual(animeData.Year, myListResult.Year,
                "Correct year will be displayed"));

            // d.Correct number of episode is displayed
            SoftAssert.Assert(() => Assert.AreEqual(animeData.NumberOfEpisodes, myListResult.NumberOfEpisodes,
                "Correct number of episode is displayed"));

            //12.Tap edit button
            myListPage.ClickEditButton();

            //13.Tap Remove from list button
            myListPage.ClickRemoveFromList();

            //14.Tap 'Yes' option
            myListPage.ClickYes();

            //15.Verify that anime is removed
            SoftAssert.Assert(() => Assert.IsTrue(myListPage.IsAnimeRemove(),
                "Verify that anime is removed"));
            SoftAssert.FailTestIfAssertFailed();
        }
    }
}
