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

        public bool AddRequest(uint userId, Request request)
        {
            bool status = false;

           
            return status;
        }

        public IEnumerable<Request> GetRequests()
        {
            List<Request> requests = null;
            Request request = null;
            MySqlDataReader mySqlReader = null;

            //var query = "SELECT * FROM driver_user AS driver JOIN vehicle AS v ON driver.vehicleId = v.id AND driver.userId = " + ring() + " ORDER BY v.id;";

            try
            {


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
        public bool DeleteRequest(uint reqId)
        {
            bool status = false;

            return status;
        }
       
    }

}
