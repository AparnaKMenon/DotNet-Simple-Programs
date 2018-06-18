using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.Presentation.Model
{
    class Meeting
    {
        private int _id;
        //// Gets or Sets Unique integer ID for the Meeting
        public int MeetingId
        {
            get { return _id; }
            set { _id = value; }
        }

        private ObservableCollection<User> _attendees;
        public ObservableCollection<User> MeetingAttendees
        {
            get { return _attendees; }
            set { _attendees = value; }
        }

        private string _description;
        // Gets or Sets the Meeting description
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _agenda;
        // Gets or Sets the agenda of the Meeting
        public string Agenda
        {
            get { return _agenda; }
            set { _agenda = value; }
        }

        private DateTime _startDate;
        // Gets or Sets the Start Date of the Meeting
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private DateTime _startTime;
        // Gets or Sets the Start time of the Meeting
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _meetingStartTime;
        public string MeetingStartTime
        {
            get { return _meetingStartTime; }
            set { _meetingStartTime = value; }
        }

        private string _meetingEndTime;
        public string MeetingEndTime
        {
            get { return _meetingEndTime; }
            set { _meetingEndTime = value; }
        }

        private DateTime _endDate;
        // Gets or Sets the End Date of the Meeting
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private DateTime _endTime;
        // Gets or Sets the End time of the Meeting
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _roomName;
        // Gets or Sets integer ID for the Meeting Room
        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        private string _organizerLogin;
        // Gets or Sets the Name of the Meeting Organizer
        public string OrganizerLogin
        {
            get { return _organizerLogin; }
            set { _organizerLogin = value; }
        }

        public Meeting( string description, string agenda, string meetingStartTime,
            string meetingEndTime, string roomName, string organizerLogin)
        {
            _description = description;
            _agenda = agenda;
            _meetingStartTime = meetingStartTime;
            _meetingEndTime = meetingEndTime;
            _roomName = roomName;
            _organizerLogin = organizerLogin;
        }

        public Meeting()
        {

        }

        public Meeting(string roomName, string Description, string MeetingStartTime, string MeetingEndTime, string Agenda, ObservableCollection <User> attendees, string organizerLogin)
        {
            _description = Description;
            _agenda = Agenda;
            _meetingStartTime = MeetingStartTime;
            _meetingEndTime = MeetingEndTime;
            _roomName= roomName;
            _attendees = attendees;
            _organizerLogin = organizerLogin;
        }
    }
}
