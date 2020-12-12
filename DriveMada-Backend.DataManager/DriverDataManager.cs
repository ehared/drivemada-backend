using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Model;
using MySql.Data.MySqlClient;
using System;

namespace DriveMada_Backend.DataManager
{
    public class DriverDataManager : IDriverDataManager
    {
        private DatabaseConnection connection;

        public DriverDataManager()
        {
            connection = new DatabaseConnection();
        }

        public bool SaveDriver(Driver driver)
        {
            var query = "INSERT INTO Driver_reg (firstName, lastName, email, password, phoneNumber, carMake, carModel, carColor, carPlate) Values " + 
                $"('{driver.FirstName}', '{driver.LastName}', '{driver.Email}', '{driver.Password}', '{driver.PhoneNumber}', '{driver.CarMake}', '{driver.CarModel}', '{driver.CarColor}', '{driver.CarPlate}');";

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);

                var dataReader = cmd.ExecuteNonQuery();

                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                // Log? 
                return false;
            }
        }
    }
}
