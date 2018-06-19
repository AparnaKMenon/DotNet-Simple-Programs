using MeetingAssist.Presentation.Model;
using Npgsql;
using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.DataAccess
{
    class MeetingsRepository
    {
        public MeetingsRepository()
        {
        }

        //Maintains the Meeting collection locally
        static ObservableCollection<Meeting> _meetings;
   
        public ObservableCollection<Meeting> FetchRepository()
        {
            NpgsqlConnection conn = null;
            try
            {
                conn = DBUtil.GetDBConnection();
                conn.Open();
                String sql = "SELECT \"MEETING\".\"MEETING_ID\", \"MEETING\".\"DESCRIPTION\",\"MEETING\".\"AGENDA\",to_char(\"MEETING\".\"TO_DATE_TS\",'DD/MM/YYYY HH24:MI'),to_char(\"MEETING\".\"FROM_DATE_TS\",'DD/MM/YYYY HH24:MI'),\"MEETING_ROOM\".\"ROOM_NAME\",\"USER\".\"NAME\" FROM \"MEETING_ROOM\",\"MEETING\",\"USER\" WHERE \"MEETING\".\"ROOM_ID\" = \"MEETING_ROOM\".\"ROOM_ID\" AND \"USER\".\"USER_ID\" = \"MEETING\".\"ORGANIZER_ID\"";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                _meetings = new ObservableCollection<Meeting>();
                // Output the rows of the first result set
                while (dr.Read())
                {
                    int id = (int)dr[0];
                    String desc = (String)dr[1];
                    String agenda = (String)dr[2];
                    String toDtTs = (String)dr[3];
                    String fromDtTs = (String)dr[4];
                    String roomName = (String)dr[5];
                    String organizerName = (String)dr[6];

                    Meeting meeting = new Meeting(desc, fromDtTs, toDtTs, roomName, organizerName, agenda);
                    _meetings.Add(meeting);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in FetchRepository : " + e.ToString());
                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return _meetings;
        }

        public Boolean Add(Meeting meeting)
        {
            NpgsqlConnection conn = null;
            try
            {
                conn = DBUtil.GetDBConnection();
                conn.Open();
                String sql = "SELECT nextval('\"MEETING_MEETING_ID_seq\"')";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output the rows of the first result set
                long meetingId = 0;
                while (dr.Read())
                {
                    meetingId = (long)dr[0];
                }
                dr.Close();

                sql = "SELECT \"USER_ID\" FROM \"USER\" WHERE \"LOGIN_ID\"=:loginId";
                command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("loginId", NpgsqlTypes.NpgsqlDbType.Text, meeting.OrganizerLogin);

                dr = command.ExecuteReader();

                // Output the rows of the first result set
                int organizerId = 0;
                while (dr.Read())
                {
                    organizerId = (int)dr[0];
                }
                dr.Close();
                sql = "INSERT INTO \"MEETING\"(\"MEETING_ID\",\"ROOM_ID\",\"ORGANIZER_ID\",\"DESCRIPTION\",\"AGENDA\",\"FROM_DATE_TS\",\"TO_DATE_TS\") VALUES (:meetingId,:roomId,:organizerId,:desc,:agenda,to_timestamp(:toTimeTs,'DD/MM/YYYY HH24:MI'),to_timestamp(:fromTimeTs,'DD/MM/YYYY HH24:MI'))";
                command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("meetingId", NpgsqlTypes.NpgsqlDbType.Integer, meetingId);
                command.Parameters.AddWithValue("roomId", NpgsqlTypes.NpgsqlDbType.Integer, meeting.RoomId);//pass room id
                command.Parameters.AddWithValue("organizerId", NpgsqlTypes.NpgsqlDbType.Integer, organizerId);//pick organizer id
                command.Parameters.AddWithValue("desc", NpgsqlTypes.NpgsqlDbType.Text, meeting.Description);
                command.Parameters.AddWithValue("agenda", NpgsqlTypes.NpgsqlDbType.Text, meeting.Agenda);
                command.Parameters.AddWithValue("toTimeTs", NpgsqlTypes.NpgsqlDbType.Text, meeting.MeetingStartTime);
                command.Parameters.AddWithValue("fromTimeTs", NpgsqlTypes.NpgsqlDbType.Text, meeting.MeetingEndTime);
                int noOfRows = command.ExecuteNonQuery();
                if (noOfRows != 1)
                {
                    conn.Close();
                    return false;
                }
                int numOfAttendees = meeting.MeetingAttendees.Count;
                for (int i = 0; i < numOfAttendees; i++)
                {
                    User attendee = meeting.MeetingAttendees[i];
                    sql = "INSERT INTO \"MEETING_PARTICIPANT\"(\"MEETING_ID\",\"PARTICIPANT_ID\") VALUES (:meetingId,:participantId)";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("meetingId", NpgsqlTypes.NpgsqlDbType.Integer, meetingId);
                    command.Parameters.AddWithValue("participantId", NpgsqlTypes.NpgsqlDbType.Integer, attendee.Id);
                    noOfRows = command.ExecuteNonQuery();
                    if (noOfRows != 1)
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in FetchRepository : " + e.ToString());
                throw;
            }
            finally
            {
                if(conn!=null)
                    conn.Close();
            }
            return true;
        }
    }    
}