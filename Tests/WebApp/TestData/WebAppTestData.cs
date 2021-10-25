using PageModel.WebAppPageModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WebApp.TestData
{
    public static class WebAppTestData
    {
        public static AccountModel GenerateAccountData() 
        {
            string dt = DateTime.Now.ToString("HHmmss");
            return new AccountModel
            {
                Firstname ="Jaja",
                Lastname ="Test",
                MobileNumber ="1234",
                Email = $"jaja{dt}@test.com",
                Password ="jaja0987",
                Address = "Singkamas",
                City = "Makati",
                State = "Metro Manila",
                Zip = "123"
            };
        }

        public static AccountModel DemoAccount() 
        {
            return new AccountModel
            {
                Firstname = "Demo",
                Lastname = "User",
                MobileNumber = "123456",
                Email = "user@phptravels.com",
                Password = "demouser",
                Address = "R2, Avenue du Maroc",
                Zip = "52000"
            };

        }
    }
}
