using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    
    
        class DataBaseHelper
    {
        private String serverName = "127.0.0.1";
        private String port = "3306";
        private String databaseName = "dbfinal";
        private String databaseUser = "root";
        private String databasePassword = "1234567890-=1234567890-=";

        private DataBaseHelper() { }

        private static DataBaseHelper _instance;
        public static DataBaseHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataBaseHelper();
                return _instance;
            }
        }
        public MySqlConnection getConnection()
        {
            string connectionString = $"server={serverName};port={port};user={databaseUser};database ={databaseName}; password ={databasePassword}; SslMode = Required; ";
            var connection = new
            MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public MySqlDataReader getData(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteReader();
                }
            }

        }


        public int Update(string query)
        {
            using (var connection = getConnection())
            {

                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            using (var connection = getConnection())
            {
                //connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }

        }


    }
    
}



