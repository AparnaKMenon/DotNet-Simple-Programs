using MeetingAssist.Presentation.Model;
using System.Collections.ObjectModel;

namespace MeetingAssist.DataAccess
{
    class AttendeesRepository
    {
        public AttendeesRepository()
        {
        }

        //Maintains the User collection locally
        static ObservableCollection<User> _attendees = new ObservableCollection<User>();

        // Search for the entry with User ID    
        internal User Search(int id)
        {
            int index = GetIndex(id);
            if (index > -1)
                return _attendees[index];
            return null;
        }

        // Search for the User ID in the collection and return the Index 
        private int GetIndex(int id)
        {
            int index = -1;
            if (_attendees.Count > 0)
            {
                for (int i = 0; i < _attendees.Count; i++)
                {
                    if (_attendees[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        public ObservableCollection<User> FetchRepository()
        {
            ObservableCollection<User> attendees = new ObservableCollection<User>();
            attendees = _attendees;
            return attendees;
        }

        /// Add a User         
        internal void Add(User user)
        {
            _attendees.Add(user);
        }
    }
}
