using PageModel.NativeAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.NativeApp.TestData
{
    /// <summary>
    /// Dummy Account Model
    /// </summary>
    public static class NativeAppTestData
    {
        public static DummyAccountModel MyDummyAccount() 
        {
            return new DummyAccountModel
            {
                Username = "jajamg",
                Password = "jaja1234"
            };
        }
    }
}
