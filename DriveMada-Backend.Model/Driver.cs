using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Model
{
    public class Driver
    {
        public uint ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarPlate { get; set; }
        public string CarColor { get; set; }
        public string PhoneNumber { get; set; }
        public string StripeCustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime RegisterDate { get; set; }
        public int AvgRating { get; set; }
        public int TotalReviews { get; set; }
        public bool isCaregiver { get; set; }
        public bool isVerified { get; set; }
        public string Token { get; set; }
    }
}
