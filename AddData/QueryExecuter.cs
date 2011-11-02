using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace AddData
{
    class QueryExecuter
    {
        public List <String> QueryCommand(MySqlCommand cmd, String query)
        {
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;

            List<String> TempList = new List<string>();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();


            

            while (reader.Read())
            {
                TempList.Add(reader.GetString(0));
            }

            reader.Close();
            }
            catch (Exception) { }
            return TempList; 
        }


        public static void InsertCommand(MySqlCommand cmd, string query)
        {
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }


    }
}
