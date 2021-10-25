using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageModel.NativeAppPageModels.DataModels
{
    /// <summary>
    /// Dummy Account Model
    /// </summary>
    public class DummyAccountModel
    {
        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }
    }

    public class AnimeDetails 
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Number of episodes
        /// </summary>
        public string NumberOfEpisodes { get; set; }
        
        /// <summary>
        /// Season
        /// </summary>
        public string Season { get; set; }
        
        /// <summary>
        /// Year
        /// </summary>
        public string Year { get; set; }
    }
}
