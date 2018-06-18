using MeetingAssist.DataAccess;
using MeetingAssist.Presentation.Model;
using System;
using System.Collections.ObjectModel;

namespace MeetingAssist.BusinessLogic
{
    class MeetingManager
    {
        #region Private Members

        MeetingsRepository _meetingsRepository;
        RoomsRepository _roomsRepository;
        UsersRepository _usersRepository;
        AttendeesRepository _attendeesRepository;

        #endregion

        #region Constructors

        public MeetingManager()
        {
            _meetingsRepository = new MeetingsRepository();
            _roomsRepository = new RoomsRepository();
            _usersRepository = new UsersRepository();
            _attendeesRepository = new AttendeesRepository();
        }

        #endregion

        #region Public Methods

        public bool Add(User user)
        {
            //Search if the patient exists and if not add the patient.
            if (_attendeesRepository.Search(user.Id) == null)
            {
                _attendeesRepository.Add(user);
                return true;
            }
            return false;
        }

        public bool Add(Meeting meeting)
        {
            return (_meetingsRepository.Add(meeting));
        }

        public void CalculateMeetingTime(DateTime startDate, DateTime startTime, string duration, out string meetingStart, out string meetingEnd)
        {
            DateTime endDate = startDate;
            DateTime endTime = startTime;

            int Hours = endTime.Hour;
            int Minutes = endTime.Minute;
            int day = endDate.Day;

            if (null != duration)
            {
                Hours += int.Parse(duration.Split(':')[0]);
                Minutes += int.Parse(duration.Split(':')[1]);
            }

            if (Minutes >= 60)
            {
                Hours++;
                Minutes = 0;
            }

            if (Hours >= 24)
            {
                endDate = endDate.AddDays(1);
                Hours -= 24;
            }
            meetingStart = startDate.ToString("dd/MM/yyyy") + " " + startTime.Hour + ":" + startTime.Minute;
            meetingEnd = endDate.ToString("dd/MM/yyyy") + " " + Hours.ToString() + ":" + Minutes.ToString();
        }

        public ObservableCollection<User> FetchAttendeeList()
        {
            return _attendeesRepository.FetchRepository();
        }

        public ObservableCollection<User> FetchUserList()
        {
            return _usersRepository.FetchRepository();
        }

        public ObservableCollection<MeetingRoom> FetchMeetingRoomList(DateTime startDate, DateTime startTime, string duration)
        {
            string meetingStart;
            string meetingEnd;

            CalculateMeetingTime(startDate, startTime, duration, out meetingStart, out meetingEnd);

            ObservableCollection<MeetingRoom> meetingRooms = _roomsRepository.FetchRepository(meetingStart, meetingEnd);
            return meetingRooms;
        }

        public ObservableCollection<Meeting> FetchMeetingsList()
        {
            ObservableCollection<Meeting> meetings = _meetingsRepository.FetchRepository();
            return meetings;
        }

        #endregion
    }
}
