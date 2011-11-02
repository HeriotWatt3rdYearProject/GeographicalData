using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace AddData
{
    public class ConnectMySQL
    {
        MySqlConnection connection;

       public MySqlConnection Connect()
        {
            MySqlConnectionStringBuilder connBuilder =
                new MySqlConnectionStringBuilder();

            connBuilder.Add("Database", "perspectives");
            connBuilder.Add("Network Address", "46.137.157.43");
            connBuilder.Add("User Id", "group8db");
            connBuilder.Add("Port", "4088");
            connBuilder.Add("Password", "group8db");

            connection =
                new MySqlConnection(connBuilder.ConnectionString);

            //MySqlCommand cmd = connection.CreateCommand();

            connection.Open();

            return connection;
            // Here goes the code needed to perform operations on the


            // database such as querying or inserting rows into a table
         
        }

       public void CloseConnection(){

            connection.Close();

        }

    }
}