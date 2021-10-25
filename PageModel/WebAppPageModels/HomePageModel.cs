using Magenic.Maqs.BaseAppiumTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.WebAppPageModels
{
    public class HomePageModel : BasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel"/> class
        /// </summary>
        /// <param name="testObject">The base Appium test object</param>
        public HomePageModel(AppiumTestObject testObject)
            : base(testObject)
        {
        }

        // holder of /home page
    }
}
