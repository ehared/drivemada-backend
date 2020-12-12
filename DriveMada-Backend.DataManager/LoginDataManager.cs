using DriveMada_Backend.Model;
using MySql.Data.MySqlClient;
using System;

namespace DriveMada_Backend.DataManager
{
    public class LoginDataManager : ILoginDataManager
    {
        private DatabaseConnection connection;

        public LoginDataManager()
        {
            connection = new DatabaseConnection();
        }

        public User GetUser(User user)
        {
            var query = "SELECT u.id, u.email, u.password, u.is_banned, u.is_verified " + 
                "FROM user AS u " + 
                $"WHERE email = {user.Email}";

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);

                var dataReader = cmd.ExecuteReader();
                var dbUser = new User();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dbUser.ID = (uint) dataReader["id"];
                        dbUser.Email = (string) dataReader["email"];
                        dbUser.Password = (string) dataReader["password"];
                        //dbUser.StripeCustomerID = (string) dataReader["stripe_customer_id"];
                        //dbUser.ProfilePicture = (string) dataReader["profile_picture"];
                        //dbUser.LastUpdated = (DateTime) dataReader["last_updated"];
                        //dbUser.RegisterDate = (DateTime) dataReader["register_date"];
                        //dbUser.AvgRating = (int) dataReader["avg_rating"];
                        //dbUser.TotalReviews = (int) dataReader["total_reviews"];
                        //dbUser.isCaregiver = (bool) dataReader["is_caregiver"];
                        //dbUser.VerificationToken = (string)dataReader["verification_token"];
                        dbUser.isVerified = (bool) dataReader["is_verified"];
                        dbUser.isBanned = (bool) dataReader["is_banned"];
                        //dbUser.isTwoFactor = (bool) dataReader["is_twofactor"];
                    }
                }                

                dataReader.Close();
                connection.CloseConnection();
                return dbUser;
            } catch (Exception e)
            {
                // Log? 
                return null;
            }
        }
    }
}
