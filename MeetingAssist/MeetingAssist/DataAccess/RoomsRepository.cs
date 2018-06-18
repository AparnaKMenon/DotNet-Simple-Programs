﻿using MeetingAssist.Presentation.Model;
using Npgsql;
using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.DataAccess
{
    class RoomsRepository
    {
        public RoomsRepository()
        {
        }

        public ObservableCollection<MeetingRoom> FetchRepository(string StartTime, string EndTime)
        {
            // Connect to PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; " +
                "Password=postgres;Database=myoffice;");
            conn.Open();
            String sql = "SELECT \"ROOM_ID\",\"ROOM_NAME\" FROM \"MEETING_ROOM\" WHERE \"ROOM_ID\" NOT IN (SELECT \"ROOM_ID\" FROM \"MEETING\" WHERE \"FROM_DATE_TS\"<=to_timestamp(:to_date_ts,'DD/MM/YYYY HH24:MI') AND \"TO_DATE_TS\">to_timestamp(:from_date_ts,'DD/MM/YYYY HH24:MI'))";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("from_date_ts", NpgsqlTypes.NpgsqlDbType.Text, StartTime);
            command.Parameters.AddWithValue("to_date_ts", NpgsqlTypes.NpgsqlDbType.Text, EndTime);
            NpgsqlDataReader dr = command.ExecuteReader();

            // Output the rows of the first result set
            ObservableCollection<MeetingRoom> meetingRooms = new ObservableCollection<MeetingRoom>();
            while (dr.Read())
            {
                MeetingRoom meetingRoom = new MeetingRoom((int)dr[0], (string)dr[1]);
                meetingRooms.Add(meetingRoom);
            }

            return meetingRooms;
        }
    }
}
