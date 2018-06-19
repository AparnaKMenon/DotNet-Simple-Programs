using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.Presentation.Model
{
    class Meeting
    {
        #region Private Members

        private int _id;
        private string _description;
        private string _meetingStartTime;
        private string _meetingEndTime;
        private int _roomId;
        private string _roomName;
        private string _organizerLogin;
        private string _agenda;

        private ObservableCollection<User> _attendees;

        #endregion

        #region Properties

        //// Gets or Sets Unique integer ID for the Meeting
        public int MeetingId
        {
            get { return _id; }
            set { _id = value; }
        }

        // Gets or Sets the Meeting description
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Gets or Sets the Start time of the Meeting
        public string MeetingStartTime
        {
            get { return _meetingStartTime; }
            set { _meetingStartTime = value; }
        }

        public string MeetingEndTime
        {
            get { return _meetingEndTime; }
            set { _meetingEndTime = value; }
        }

        // Gets or Sets integer ID for the Meeting Room
        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        // Gets or Sets the string name for the Meeting Room
        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        // Gets or Sets the Name of the Meeting Organizer
        public string OrganizerLogin
        {
            get { return _organizerLogin; }
            set { _organizerLogin = value; }
        }

        // Gets or Sets the agenda of the Meeting
        public string Agenda
        {
            get { return _agenda; }
            set { _agenda = value; }
        }

        //Gets or Sets the List of Attendees in the meeting
        public ObservableCollection<User> MeetingAttendees
        {
            get { return _attendees; }
            set { _attendees = value; }
        }

        #endregion

        #region Constructors

        public Meeting()
        {
        }

        public Meeting(string description, string meetingStartTime, string meetingEndTime, 
            string roomName, string organizerLogin, string agenda)
        {
            _description = description;
            _meetingStartTime = meetingStartTime;
            _meetingEndTime = meetingEndTime;
            _roomName = roomName;
            _organizerLogin = organizerLogin;
            _agenda = agenda;
        }

        public Meeting(string description, string meetingStartTime, string meetingEndTime, int roomId,
            string roomName, string organizerLogin, string agenda, ObservableCollection <User> attendees)
        {
            _description = description;
            _meetingStartTime = meetingStartTime;
            _meetingEndTime = meetingEndTime;
            _roomId = roomId;
            _roomName = roomName;
            _organizerLogin = organizerLogin;
            _agenda = agenda;
            _attendees = attendees;
        }

        #endregion
    }
}
