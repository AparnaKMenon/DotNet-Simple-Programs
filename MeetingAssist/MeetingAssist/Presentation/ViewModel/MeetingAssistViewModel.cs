using MeetingAssist.BusinessLogic;
using MeetingAssist.Presentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace MeetingAssist.Presentation.ViewModel
{
    class MeetingAssistViewModel : INotifyPropertyChanged
    {
        #region Private Variables

        private readonly User _userObj;

        private string _description;

        private string _currentDateTime;

        private DateTime _startDate;
        private DateTime _startTime;

        private string _meetingStartTime;
        private string _meetingEndTime;

        private string _duration;

        private List<string> _startTimeList;
        private List<string> _durationList;

        private ObservableCollection<MeetingRoom> _meetingRooms;
        private ObservableCollection<User> _users;
        private ObservableCollection<User> _attendees;
        private ObservableCollection<Meeting> _meetings;

        private readonly MeetingManager _meetingManager;

        private int _roomId;
        private string _roomName;
        private string _organizerLogin;

        private MeetingRoom _meetingRoom;
        private readonly User _selectedAttendee;

        private string _agenda;

        #endregion

        #region Constructors

        //Constructor
        public MeetingAssistViewModel()
        {
            _userObj = new User();
            _selectedAttendee = new User();
            _meetings = new ObservableCollection<Meeting>();

            _meetingManager = new MeetingManager();

            _addAttendeeCommand = new RelayCommand(AddAttendee, CanAddAttendee);
            _addMeetingCommand = new RelayCommand(AddMeeting, CanAddMeeting);

            _attendees = new ObservableCollection<User>();

            //Populate All Comboboxes
            PopulateMeetingRooms();
            PopulateStartTimeList();
            PopulateDuration();
            PopulateUsers();
            PopulateMeetings();
        }

        #endregion

        #region Properties

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        // Gets or Sets the Start Date of the Meeting
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("DtPkrStartDate");
            }
        }

        // Gets or Sets the Start time of the Meeting
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("CmbStartTime");
            }
        }

        public string Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("CmbDuration");
            }
        }

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

        // Gets or Sets the ID of the Meeting Organizer
        public string OrganizerLogin
        {
            get { return _organizerLogin; }
            set { _organizerLogin = value; }
        }

        public string CurrentDateTime
        {
            get { return _currentDateTime; }
            set { _currentDateTime = value; }
        }

        public ObservableCollection<MeetingRoom> MeetingRooms
        {
            get { return _meetingRooms; }
            set
            {
                _meetingRooms = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("CmbAddAttendees");
            }
        }

        public ObservableCollection<User> Attendees
        {
            get { return _attendees; }
        }

        public ObservableCollection<Meeting> Meetings
        {
            get { return _meetings; }
        }

        public List<string> StartTimeList
        {
            get { return _startTimeList; }
            set
            {
                _startTimeList = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> DurationList
        {
            get { return _durationList; }
            set
            {
                _durationList = value;
                NotifyPropertyChanged();
            }
        }

        public MeetingRoom SelectedMeetingRoom
        {
            get { return _meetingRoom; }
            set
            {
                _meetingRoom = value;
                _roomId = _meetingRoom.Id;
                _roomName = _meetingRoom.Name;
                OnPropertyChanged("CmbMtngRooms");
            }
        }

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        public User SelectedUser
        {
            set
            {
                Id = value.Id;
                Name = value.Name;
                MailID = value.MailID;
            }
        }

        public int Id
        {
            get { return _userObj.Id; }
            set
            {
                _userObj.Id = value;
                OnPropertyChanged("AttendeeID");
            }
        }

        public string Name
        {
            get { return _userObj.Name; }
            set
            {
                _userObj.Name = value;
                OnPropertyChanged("AttendeeName");
            }
        }

        public string MailID
        {
            get { return _userObj.MailID; }
            set
            {
                _userObj.MailID = value;
                OnPropertyChanged("AttendeeMailID");
            }
        }

        public string Agenda
        {
            get { return _agenda; }
            set { _agenda = value; }
        }

        public int SelectedRoomIndex { get; set; }

        #endregion

        #region Commands

        private readonly ICommand _addAttendeeCommand;
        private readonly ICommand _addMeetingCommand;

        /// Gets the AddAttendeeCommand. Used for Add Attendee Button Operation
        public ICommand AddAttendeeCommand { get { return _addAttendeeCommand; } }

        /// Gets the AddMeetingCommand. Used for Book Meeting Button Operation
        public ICommand AddMeetingCommand { get { return _addMeetingCommand; } }

        private void AddAttendee(object obj)
        {
            var user = new User { Id = Id, Name = Name, MailID = MailID };
            if (_meetingManager.Add(user))
            {
                Attendees.Add(user);
            }
            else
            {
                MessageBox.Show("Attendee already present");
            }
        }

        private bool CanAddAttendee(object obj)
        {
            if (null != Name && 0 != Id && null != MailID)
                return true;
            return false;
        }

        public void AddMeeting(object obj)
        {
            var meeting = new Meeting
            {
                Description = Description,
                Agenda = Agenda,
                MeetingStartTime = MeetingStartTime,
                MeetingEndTime = MeetingEndTime,
                RoomName = RoomName,
                MeetingAttendees = _attendees,
                OrganizerLogin = _organizerLogin
            };

            if (_meetingManager.Add(meeting))
            {
                Meetings.Add(meeting);
            }
            else
            {
                MessageBox.Show("Meeting already booked");
            }
        }

        private bool CanAddMeeting(object obj)
        {
            if (null != Description && (null != _startDate) && (null != _startTime) && (null != _duration))
                return true;
            return false;
        }

        #endregion

        #region Private Methods

        private void PopulateMeetingRooms()
        {
            _meetingRooms = new ObservableCollection<MeetingRoom>();
            _meetingRooms = _meetingManager.FetchMeetingRoomList(_startDate, _startTime, _duration);
        }

        private void PopulateMeetings()
        {
            _meetings = new ObservableCollection<Meeting>();
            _meetings = _meetingManager.FetchMeetingsList();
        }

        private void PopulateStartTimeList()
        {
            //Time being Displayed on the Top left corner of the Form
            _currentDateTime = DateTime.Now.ToString("dd MMM, yyyy");

            //Setting the Date Picker control to today's Date
            _startDate = DateTime.Now;

            ////Setting the TimePicker Control to the next half hour so that booking can be done easily
            //int minute = (_startDate.Minute < 30) ? 30 : 0;
            //int hours = (minute == 30) ? (_startDate.Hour) : (_startDate.Hour) + 1;
            //string timeNow = hours.ToString() + " : " + minute.ToString();
            //int timeSelection = 0;

            _startTimeList = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                TimeSpan ts = TimeSpan.FromHours(i);
                DateTime dt = Convert.ToDateTime(ts.ToString());
                _startTimeList.Add(dt.ToString("HH") + " : 00");
                _startTimeList.Add(dt.ToString("HH") + " : 30");

                //if(hours == dt.Hour)
                //{
                //    timeSelection = i * 2;
                //}
                //if (30 == minute)
                //    timeSelection--;
            }
            //_startTime = DateTime.ParseExact(timeNow, "HH:mm", CultureInfo.InvariantCulture);
        }

        private void PopulateDuration()
        {
            _durationList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                TimeSpan ts = TimeSpan.FromHours(i);
                DateTime dt = Convert.ToDateTime(ts.ToString());
                _durationList.Add(dt.ToString("HH") + " : 00");
                _durationList.Add(dt.ToString("HH") + " : 30");
            }
        }

        private void PopulateUsers()
        {
            _users = new ObservableCollection<User>();
            _users = _meetingManager.FetchUserList();

            //Update Login name of the Organizer (current user)
            _organizerLogin = Environment.UserName;
        }

        private void CalculateMeetingTime()
        {
            _meetingManager.CalculateMeetingTime(StartDate, StartTime, Duration, out _meetingStartTime, out _meetingEndTime);
        }

        #endregion

        #region PropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// When a control's property is changed, this methods executes to fire the PropertyChanged Event
        public void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                //Handling the update of MeetingRoom Combo
                if ((("DtPkrStartDate" == propertyName) || ("CmbStartTime" == propertyName) || ("CmbDuration" == propertyName))
                    && (null != _startDate) && (null != _startTime) && (null != _duration))
                {
                    CalculateMeetingTime();
                    PopulateMeetingRooms();
                }
            }
        }

        #endregion

    }
}
