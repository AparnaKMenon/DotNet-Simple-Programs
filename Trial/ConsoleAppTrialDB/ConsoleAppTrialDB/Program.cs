using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace ConsoleAppTrialDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; " +
                "Password=postgres;Database=myoffice;");
            conn.Open();
            String sql = "SELECT \"ROOM_ID\",\"ROOM_NAME\" FROM \"MEETING_ROOM\" WHERE \"ROOM_ID\" NOT IN (SELECT \"ROOM_ID\" FROM \"MEETING\" WHERE \"FROM_DATE_TS\"<=to_timestamp(:to_date_ts,'DD/MM/YYYY HH24:MI') AND \"TO_DATE_TS\">to_timestamp(:from_date_ts,'DD/MM/YYYY HH24:MI'))";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("from_date_ts",NpgsqlTypes.NpgsqlDbType.Text, "11/06/2018 10:30");
            command.Parameters.AddWithValue("to_date_ts", NpgsqlTypes.NpgsqlDbType.Text, "11/06/2018 11:30");
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
                Console.Write("{0}\t{1} \n", dr[0], dr[1]);

            Console.Read();

            conn.Close();
        }
    }
}
