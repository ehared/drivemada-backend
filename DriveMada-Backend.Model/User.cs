using System;

namespace DriveMada_Backend.Model
{
    public class User
    {
        public uint ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StripeCustomerID { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime RegisterDate { get; set; }
        public int AvgRating { get; set; }
        public int TotalReviews { get; set; }
        public bool isCaregiver { get; set; }
        public string VerificationToken { get; set; }
        public bool isVerified { get; set; }
        public bool isBanned { get; set; }
        public bool isTwoFactor { get; set; }
        public string Token { get; set; }
    }
}
