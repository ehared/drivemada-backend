using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Model;
using MySql.Data.MySqlClient;

namespace DriveMada_Backend.DataManager
{
    public class RequestDataManager : IRequestDataManager
    {
        private DatabaseConnection connection;

        public RequestDataManager()
        {
            connection = new DatabaseConnection();
        }

        public bool AddRequest(Request request)
        {

            bool status = false;

            var query = "INSERT INTO requests (userId, latitude, longitude, sourceAddress, destinationAddress, fare, distance, requestDate) " + "Values " +
                $"('{request.userId}', '{request.latitude}', '{request.longitude}', '{request.sourceAddress}', '{request.destinationAddress}', '{request.fare}', '{request.distance}', '{request.requestDate}');";

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);

                var dataReader = cmd.ExecuteNonQuery();

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

        public IEnumerable<Request> GetAvailableRequests()
        {
            List<Request> requests = null;
            Request request = null;
            MySqlDataReader mySqlReader = null;

            var query = "SELECT * FROM requests WHERE driverId is null ORDER BY requestDate;";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlReader = cmd.ExecuteReader();

                requests = new List<Request>();

                while (mySqlReader.Read())
                {
                    request = new Request();
                    request.id = mySqlReader.GetUInt32("id");
                    request.userId = mySqlReader.GetUInt32("userId");
                    request.latitude = mySqlReader.GetDouble("latitude");
                    request.longitude = mySqlReader.GetDouble("longitude");
                    request.sourceAddress = mySqlReader.GetString("sourceAddress");
                    request.destinationAddress = mySqlReader.GetString("destinationAddress");
                    request.fare = mySqlReader.GetDouble("fare");
                    request.distance = mySqlReader.GetDouble("distance");
                    request.requestDate = mySqlReader.GetDateTime("requestDate");

                    requests.Add(request);
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

            return requests;
        }

        public IEnumerable<Request> GetClientRequests(uint userId)
        {
            List<Request> requests = null;
            Request request = null;
            MySqlDataReader mySqlDataReader = null;

            var query = "SELECT * FROM caremada.requests where userId = " + userId.ToString() + " and driverId is not null and completionDate is not null order by completionDate DESC;";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlDataReader = cmd.ExecuteReader();

                requests = new List<Request>();

                while (mySqlDataReader.Read()) // found vehicle
                {

                    request = new Request();
                    request.id = mySqlDataReader.GetUInt32("id");
                    request.userId = mySqlDataReader.GetUInt32("userId");
                    request.driverId = mySqlDataReader.GetUInt32("driverId");
                    request.latitude = mySqlDataReader.GetDouble("latitude");
                    request.longitude = mySqlDataReader.GetDouble("longitude");
                    request.sourceAddress = mySqlDataReader.GetString("sourceAddress");
                    request.destinationAddress = mySqlDataReader.GetString("destinationAddress");
                    request.fare = mySqlDataReader.GetDouble("fare");
                    request.distance = mySqlDataReader.GetDouble("distance");
                    request.requestDate = mySqlDataReader.GetDateTime("requestDate");
                    request.completionDate = mySqlDataReader.GetDateTime("completionDate");
                    requests.Add(request);
                }
                mySqlDataReader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.CloseConnection();
            }
            return requests;
        }

        public IEnumerable<Request> GetDriverRequests(uint userId)
        {
            List<Request> requests = null;
            Request request = null;
            MySqlDataReader mySqlDataReader = null;

            var query = "SELECT * FROM caremada.requests where driverId = " + userId.ToString() + " and driverId is not null and completionDate is not null order by completionDate DESC;";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlDataReader = cmd.ExecuteReader();

                requests = new List<Request>();

                while (mySqlDataReader.Read()) // found vehicle
                {

                    request = new Request();
                    request.id = mySqlDataReader.GetUInt32("id");
                    request.userId = mySqlDataReader.GetUInt32("userId");
                    request.driverId = mySqlDataReader.GetUInt32("driverId");
                    request.latitude = mySqlDataReader.GetDouble("latitude");
                    request.longitude = mySqlDataReader.GetDouble("longitude");
                    request.sourceAddress = mySqlDataReader.GetString("sourceAddress");
                    request.destinationAddress = mySqlDataReader.GetString("destinationAddress");
                    request.fare = mySqlDataReader.GetDouble("fare");
                    request.distance = mySqlDataReader.GetDouble("distance");
                    request.requestDate = mySqlDataReader.GetDateTime("requestDate");
                    request.completionDate = mySqlDataReader.GetDateTime("completionDate");
                    requests.Add(request);
                }
                mySqlDataReader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.CloseConnection();
            }
            return requests;
        }

        public bool DeleteRequest(uint reqId)
        {
            bool status = false;
            var query = "SELECT * from requests WHERE id = " + reqId + ";";
            MySqlDataReader mySqlReader = null;

            try
            {
                connection.OpenConnection();

                var cmd = new MySqlCommand(query, connection.Connection);
                // check to see if the request exists in the requests table
                mySqlReader = cmd.ExecuteReader();

                if (mySqlReader.Read()) // request exists, now delete
                {
                    mySqlReader.Close();
                    query = "DELETE from requests WHERE id = " + reqId + ";";
                    cmd = new MySqlCommand(query, connection.Connection);
                    var dataReader = cmd.ExecuteNonQuery();
                    status = true;
                }
                else // could not find request
                    status = false;
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

        public bool UpdateRequest(Request request)
        {
            bool status = false;
            MySqlDataReader mySqlReader = null;

            var query = "SELECT * FROM requests WHERE id = " + request.id + ";";

            try
            {
                connection.OpenConnection();
                var cmd = new MySqlCommand(query, connection.Connection);
                mySqlReader = cmd.ExecuteReader();


                if (mySqlReader.Read()) // found request
                {
                    mySqlReader.Close();

                    query = "UPDATE requests SET driverId = " + request.driverId + ", completionDate = '" + request.completionDate + "' where id = " + request.id + ";";

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
            }
            finally
            {
                connection.CloseConnection();
            }

            return status;
        }
    }
}
