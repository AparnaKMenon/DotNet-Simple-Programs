using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAssist.DataAccess
{
    static class DBUtil
    {
        public static NpgsqlConnection GetDBConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            NpgsqlConnection connObj = new NpgsqlConnection(connString);
            return connObj;
        }
    }
}
