using System;
using MySql.Data.MySqlClient;

namespace DriveMada_Backend.DataManager
{
    public class DatabaseConnection
    {
        private string server;
        private int port;
        private string database;
        private string password;
        private string uid;

        public MySqlConnection Connection { get; private set; }

        public DatabaseConnection()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "198.71.240.22";
            database = "caremada";
            port = 3306;
            uid = "caremada";
            password = "C$_YEcmc,W#.";
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" +
            database + ";PORT=" + port + ";UID=" + uid + ";PASSWORD=" + password + ";";

            Connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
