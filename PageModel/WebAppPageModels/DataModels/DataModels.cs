using System;
using System.Collections.Generic;
using System.Text;

namespace PageModel.WebAppPageModels.DataModels
{
    /// <summary>
    /// Account model
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Mobile number
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// zip
        /// </summary>
        public string Zip { get; set; }

    }

    /// <summary>
    /// Booking model
    /// </summary>
    public class BookingModel 
    {
        /// <summary>
        /// Hotel name
        /// </summary>
        public string Hotel { get; set; }
        
        /// <summary>
        /// Country name
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// Booking number
        /// </summary>
        public string BookingNumber { get; set; }
    }
}
