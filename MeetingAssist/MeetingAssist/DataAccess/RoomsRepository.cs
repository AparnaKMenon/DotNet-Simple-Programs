using MeetingAssist.Presentation.Model;
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

        ////Maintains the MeetingRoom collection locally
        //List<MeetingRoom> _meetingRooms = new List<MeetingRoom>();

        //
        ///// Add a MeetingRoom 
        //
        //internal void Add(MeetingRoom meetingRoom)
        //{
        //    _meetingRooms.Add(meetingRoom);
        //}

        //
        ///// Remove a meetingRoom based on 
        //
        ///// <param name="meetingRoom">MeetingRoom to remove</param>
        //internal void Remove(MeetingRoom meetingRoom)
        //{
        //    _meetingRooms.Remove(meetingRoom);
        //}

        //
        ///// Search for the entry with MeetingRoom ID
        //
        ///// <param name="id">MeetingRoom ID</param>
        ///// <returns></returns>
        //internal MeetingRoom Search(int id)
        //{
        //    //Get the patients index in the collection
        //    int index = GetIndex(id);
        //    //If present then return the element
        //    if (index > -1)
        //        return _meetingRooms[index];
        //    return null;
        //}

        //
        ///// Search for the Room ID in the collection and return the Index
        //
        ///// <param name="id"></param>
        ///// <returns></returns>
        //private int GetIndex(int id)
        //{
        //    int index = -1;
        //    //If Collection has Items
        //    if (_meetingRooms.Count > 0)
        //    {
        //        //Loop through the collection
        //        for (int i = 0; i < _meetingRooms.Count; i++)
        //        {
        //            //If match
        //            if (_meetingRooms[i].Id == id)
        //            {
        //                index = i;
        //                break;
        //            }
        //        }
        //    }
        //    return index;
        //}

        //private void RemoveAll()
        //{
        //    //If Collection has Items
        //    if (_meetingRooms.Count > 0)
        //    {
        //        //Loop through the collection
        //        for (int i = 0; i < _meetingRooms.Count; i++)
        //        {
        //            //If match
        //            _meetingRooms.RemoveAt(i);
        //        }
        //    }
        //}

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
