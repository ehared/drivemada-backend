using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Model;
using MySql.Data.MySqlClient;

namespace DriveMada_Backend.DataManager
{
    public class VehicleDataManager : IVehicleDataManager
    {
        private DatabaseConnection connection;

        public VehicleDataManager()
        {
            connection = new DatabaseConnection();
        }

        public bool AddVehicle(uint userId, Vehicle vehicle)
        {
            bool status = false;

            var query = "INSERT INTO vehicle (make, model, year, colour, licensePlate, size) Values " +
                $"('{vehicle.make}', '{vehicle.model}', '{vehicle.year}', '{vehicle.colour}', '{vehicle.licensePlate}', '{vehicle.size}');";

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);

                var dataReader = cmd.ExecuteNonQuery();

                uint vehicleId = (uint)cmd.LastInsertedId;

                query = "INSERT INTO driver_user (userId, vehicleId) Values " +
                $"('{userId}', '{vehicleId}');";

                cmd = new MySqlCommand(query, connection.Connection);

                dataReader = cmd.ExecuteNonQuery();

                status = true;
            }
            catch (Exception e)
            {
                // Log? 

            }
            finally
            {
                connection.CloseConnection();

            }
            return status;
        }

        public IEnumerable<Vehicle> GetVehicles(uint uid)
        {
            List<Vehicle> vehicles = null;
            Vehicle vehicle = null;
            MySqlDataReader mySqlReader = null;

            var query = "SELECT * FROM driver_user AS driver JOIN vehicle AS v ON driver.vehicleId = v.id AND driver.userId = " + uid.ToString() + " ORDER BY v.id;";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlReader = cmd.ExecuteReader();

                vehicles = new List<Vehicle>();

                while (mySqlReader.Read()) // found vehicle
                {

                    vehicle = new Vehicle();
                    vehicle.id = mySqlReader.GetUInt32("vehicleid");
                    vehicle.make = mySqlReader.GetString("make");
                    vehicle.model = mySqlReader.GetString("model");
                    vehicle.year = mySqlReader.GetInt32("year");
                    vehicle.colour = mySqlReader.GetString("colour");
                    vehicle.licensePlate = mySqlReader.GetString("licensePlate");
                    vehicle.size = mySqlReader.GetString("size");
                    vehicles.Add(vehicle);

                }
                mySqlReader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.CloseConnection();
            }

            return vehicles;
        }
        public bool DeleteVehicle(uint vid)
        {
            /* current database engine ignores foreign key constraints */

            bool status = false;
            var query = "SELECT * from vehicle WHERE id = " + vid + ";";
            MySqlDataReader mySqlReader = null;

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);
                // check to see if the vehicle exists in the vehicle table
                mySqlReader = cmd.ExecuteReader();

                if (mySqlReader.Read()) // vehicle exists, now delete
                {
                    mySqlReader.Close();
                    query = "DELETE from vehicle WHERE id = " + vid + ";";
                    cmd = new MySqlCommand(query, connection.Connection);
                    var dataReader = cmd.ExecuteNonQuery();
                    
                    // delete from driver_user table
                    query = "DELETE from driver_user WHERE vehicleId = " + vid + ";";
                    cmd = new MySqlCommand(query, connection.Connection);
                    dataReader = cmd.ExecuteNonQuery();
                    status = true;
                }
                else // could not find vehicle
                    status = false;
            }
            catch (Exception e)
            {
                // Log

            }
            finally
            {
                connection.CloseConnection();

            }
            return status;
        }
        public bool UpdateVehicle(Vehicle vehicle)
        {
            bool status = false;
            MySqlDataReader mySqlReader = null;

            var query = "SELECT * FROM vehicle WHERE id = " + vehicle.id + ";";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlReader = cmd.ExecuteReader();


                if (mySqlReader.Read()) // found vehicle
                {
                    mySqlReader.Close();

                    query = "UPDATE vehicle SET " +
                        "make='" + vehicle.make + "', " +
                        "model='" + vehicle.model + "', " +
                        "year= " + vehicle.year + ", " +
                        "colour='" + vehicle.colour + "', " +
                        "licensePlate='" + vehicle.licensePlate + "', " +
                        "size='" + vehicle.size + "' " +
                        "WHERE id = " + vehicle.id + ";";

                    cmd = new MySqlCommand(query, connection.Connection);
                    cmd.ExecuteNonQuery();
                    status = true;

                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                // TODO
            }
            finally
            {
                connection.CloseConnection();
            }

            return status;
        }
    }

}
