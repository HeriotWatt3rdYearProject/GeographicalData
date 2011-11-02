using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;



namespace AddData
{
    class AddData
    {
        static void Main(string[] args)
        {
            ConnectMySQL conn = new ConnectMySQL();
            MySqlConnection OpenConnection =  conn.Connect();
            MySqlCommand cmd = OpenConnection.CreateCommand();

            QueryExecuter QExecuter = new QueryExecuter();
            List <String> Results = QExecuter.QueryCommand(cmd, "SELECT distinct organisation FROM `perspectives`.`people`;");

            GetCoords CoordFetcher = new GetCoords();
            List<LatLng> FetchedResults = new List<LatLng>();

            foreach (String str in Results) {
                var temp = CoordFetcher.GetLatLng(str);
                if (temp != null)
                {
                    FetchedResults.Add(temp);
                }
            }

            foreach (LatLng ll in FetchedResults) {

                QExecuter.QueryCommand(cmd, "INSERT INTO `perspectives`.`Organisations`(`Organisation`,`Latitude`,`Longitude`)"
                                                +"VALUES('"+ll.Organisation+"',"+ll.Latitude+","+ll.Longitude+");");
            
            }

          
            conn.CloseConnection();

        }


    }
}
